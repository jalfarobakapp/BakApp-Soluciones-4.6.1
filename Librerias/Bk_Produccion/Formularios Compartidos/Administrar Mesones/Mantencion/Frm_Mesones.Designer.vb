<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Frm_Mesones
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Mesones))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Crear = New DevComponents.DotNetBar.ButtonItem()
        Me.GroupPanel4 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.ContextMenuBar1 = New DevComponents.DotNetBar.ContextMenuBar()
        Me.Menu_Contextual_Meson = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Mnu_Editar_Meson = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Eliminar_Meson = New DevComponents.DotNetBar.ButtonItem()
        Me.LabelItem1 = New DevComponents.DotNetBar.LabelItem()
        Me.Btn_Agregar_Maquina = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Agregar_Operario = New DevComponents.DotNetBar.ButtonItem()
        Me.Menu_Contextual_Maquina = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Mnu_Quitar_Maquina = New DevComponents.DotNetBar.ButtonItem()
        Me.Menu_Contextual_Operario = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Mnu_Quitar_Operario = New DevComponents.DotNetBar.ButtonItem()
        Me.Grilla_Mesones = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.Grilla_Maquinas = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.Grilla_Operarios = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.Imagenes_16x16 = New System.Windows.Forms.ImageList(Me.components)
        Me.SuperTabControl1 = New DevComponents.DotNetBar.SuperTabControl()
        Me.SuperTabControlPanel2 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.SuperTabItem2 = New DevComponents.DotNetBar.SuperTabItem()
        Me.SuperTabControlPanel1 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.SuperTabItem1 = New DevComponents.DotNetBar.SuperTabItem()
        Me.Rdb_Ordenar_Codigo = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_Ordenar_Descripcion = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Btn_Bajar_Producto = New DevComponents.DotNetBar.ButtonX()
        Me.Btn_Subir_Producto = New DevComponents.DotNetBar.ButtonX()
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_Operacion_Reproceso = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_Operacion_Equivalente = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Txt_Operacion = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel4.SuspendLayout()
        CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Grilla_Mesones, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Grilla_Maquinas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Grilla_Operarios, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SuperTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuperTabControl1.SuspendLayout()
        Me.SuperTabControlPanel2.SuspendLayout()
        Me.SuperTabControlPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Crear})
        Me.Bar1.Location = New System.Drawing.Point(0, 594)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(756, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 95
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'Btn_Crear
        '
        Me.Btn_Crear.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Crear.ForeColor = System.Drawing.Color.Black
        Me.Btn_Crear.Image = CType(resources.GetObject("Btn_Crear.Image"), System.Drawing.Image)
        Me.Btn_Crear.Name = "Btn_Crear"
        Me.Btn_Crear.Text = "Crear mesón"
        '
        'GroupPanel4
        '
        Me.GroupPanel4.BackColor = System.Drawing.Color.White
        Me.GroupPanel4.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel4.Controls.Add(Me.ContextMenuBar1)
        Me.GroupPanel4.Controls.Add(Me.Grilla_Mesones)
        Me.GroupPanel4.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel4.Location = New System.Drawing.Point(7, 12)
        Me.GroupPanel4.Name = "GroupPanel4"
        Me.GroupPanel4.Size = New System.Drawing.Size(737, 276)
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
        Me.GroupPanel4.TabIndex = 94
        Me.GroupPanel4.Text = "Mesones de la empresa"
        '
        'ContextMenuBar1
        '
        Me.ContextMenuBar1.AntiAlias = True
        Me.ContextMenuBar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ContextMenuBar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Menu_Contextual_Meson, Me.Menu_Contextual_Maquina, Me.Menu_Contextual_Operario})
        Me.ContextMenuBar1.Location = New System.Drawing.Point(131, 63)
        Me.ContextMenuBar1.Name = "ContextMenuBar1"
        Me.ContextMenuBar1.Size = New System.Drawing.Size(334, 25)
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
        Me.Menu_Contextual_Meson.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Mnu_Editar_Meson, Me.Btn_Eliminar_Meson, Me.LabelItem1, Me.Btn_Agregar_Maquina, Me.Btn_Agregar_Operario})
        Me.Menu_Contextual_Meson.Text = "Opciones"
        '
        'Btn_Mnu_Editar_Meson
        '
        Me.Btn_Mnu_Editar_Meson.Image = CType(resources.GetObject("Btn_Mnu_Editar_Meson.Image"), System.Drawing.Image)
        Me.Btn_Mnu_Editar_Meson.Name = "Btn_Mnu_Editar_Meson"
        Me.Btn_Mnu_Editar_Meson.Text = "Editar mesón"
        '
        'Btn_Eliminar_Meson
        '
        Me.Btn_Eliminar_Meson.Image = CType(resources.GetObject("Btn_Eliminar_Meson.Image"), System.Drawing.Image)
        Me.Btn_Eliminar_Meson.Name = "Btn_Eliminar_Meson"
        Me.Btn_Eliminar_Meson.Text = "Eliminar mesón"
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
        Me.LabelItem1.Text = "Asignación"
        '
        'Btn_Agregar_Maquina
        '
        Me.Btn_Agregar_Maquina.Image = CType(resources.GetObject("Btn_Agregar_Maquina.Image"), System.Drawing.Image)
        Me.Btn_Agregar_Maquina.Name = "Btn_Agregar_Maquina"
        Me.Btn_Agregar_Maquina.Text = "Agregar maquina"
        '
        'Btn_Agregar_Operario
        '
        Me.Btn_Agregar_Operario.Image = CType(resources.GetObject("Btn_Agregar_Operario.Image"), System.Drawing.Image)
        Me.Btn_Agregar_Operario.Name = "Btn_Agregar_Operario"
        Me.Btn_Agregar_Operario.Text = "Asignar operario"
        '
        'Menu_Contextual_Maquina
        '
        Me.Menu_Contextual_Maquina.AutoExpandOnClick = True
        Me.Menu_Contextual_Maquina.Name = "Menu_Contextual_Maquina"
        Me.Menu_Contextual_Maquina.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Mnu_Quitar_Maquina})
        Me.Menu_Contextual_Maquina.Text = "Opciones"
        '
        'Btn_Mnu_Quitar_Maquina
        '
        Me.Btn_Mnu_Quitar_Maquina.Image = CType(resources.GetObject("Btn_Mnu_Quitar_Maquina.Image"), System.Drawing.Image)
        Me.Btn_Mnu_Quitar_Maquina.Name = "Btn_Mnu_Quitar_Maquina"
        Me.Btn_Mnu_Quitar_Maquina.Text = "Quitar maquina"
        '
        'Menu_Contextual_Operario
        '
        Me.Menu_Contextual_Operario.AutoExpandOnClick = True
        Me.Menu_Contextual_Operario.Name = "Menu_Contextual_Operario"
        Me.Menu_Contextual_Operario.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Mnu_Quitar_Operario})
        Me.Menu_Contextual_Operario.Text = "Opciones"
        '
        'Btn_Mnu_Quitar_Operario
        '
        Me.Btn_Mnu_Quitar_Operario.Image = CType(resources.GetObject("Btn_Mnu_Quitar_Operario.Image"), System.Drawing.Image)
        Me.Btn_Mnu_Quitar_Operario.Name = "Btn_Mnu_Quitar_Operario"
        Me.Btn_Mnu_Quitar_Operario.Text = "Quitar operario"
        '
        'Grilla_Mesones
        '
        Me.Grilla_Mesones.AllowUserToAddRows = False
        Me.Grilla_Mesones.AllowUserToDeleteRows = False
        Me.Grilla_Mesones.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla_Mesones.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.Grilla_Mesones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Grilla_Mesones.DefaultCellStyle = DataGridViewCellStyle2
        Me.Grilla_Mesones.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grilla_Mesones.EnableHeadersVisualStyles = False
        Me.Grilla_Mesones.GridColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.Grilla_Mesones.Location = New System.Drawing.Point(0, 0)
        Me.Grilla_Mesones.MultiSelect = False
        Me.Grilla_Mesones.Name = "Grilla_Mesones"
        Me.Grilla_Mesones.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla_Mesones.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.Grilla_Mesones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.Grilla_Mesones.Size = New System.Drawing.Size(731, 253)
        Me.Grilla_Mesones.TabIndex = 1
        '
        'Grilla_Maquinas
        '
        Me.Grilla_Maquinas.AllowUserToAddRows = False
        Me.Grilla_Maquinas.AllowUserToDeleteRows = False
        Me.Grilla_Maquinas.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla_Maquinas.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.Grilla_Maquinas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Grilla_Maquinas.DefaultCellStyle = DataGridViewCellStyle5
        Me.Grilla_Maquinas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grilla_Maquinas.EnableHeadersVisualStyles = False
        Me.Grilla_Maquinas.GridColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.Grilla_Maquinas.Location = New System.Drawing.Point(0, 0)
        Me.Grilla_Maquinas.MultiSelect = False
        Me.Grilla_Maquinas.Name = "Grilla_Maquinas"
        Me.Grilla_Maquinas.ReadOnly = True
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla_Maquinas.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.Grilla_Maquinas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.Grilla_Maquinas.Size = New System.Drawing.Size(737, 130)
        Me.Grilla_Maquinas.TabIndex = 1
        '
        'Grilla_Operarios
        '
        Me.Grilla_Operarios.AllowUserToAddRows = False
        Me.Grilla_Operarios.AllowUserToDeleteRows = False
        Me.Grilla_Operarios.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla_Operarios.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.Grilla_Operarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Grilla_Operarios.DefaultCellStyle = DataGridViewCellStyle8
        Me.Grilla_Operarios.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grilla_Operarios.EnableHeadersVisualStyles = False
        Me.Grilla_Operarios.GridColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.Grilla_Operarios.Location = New System.Drawing.Point(0, 0)
        Me.Grilla_Operarios.MultiSelect = False
        Me.Grilla_Operarios.Name = "Grilla_Operarios"
        Me.Grilla_Operarios.ReadOnly = True
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla_Operarios.RowHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.Grilla_Operarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.Grilla_Operarios.Size = New System.Drawing.Size(737, 130)
        Me.Grilla_Operarios.TabIndex = 1
        '
        'Imagenes_16x16
        '
        Me.Imagenes_16x16.ImageStream = CType(resources.GetObject("Imagenes_16x16.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.Imagenes_16x16.TransparentColor = System.Drawing.Color.Transparent
        Me.Imagenes_16x16.Images.SetKeyName(0, "delete.png")
        Me.Imagenes_16x16.Images.SetKeyName(1, "application-option.png")
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
        Me.SuperTabControl1.Controls.Add(Me.SuperTabControlPanel2)
        Me.SuperTabControl1.Controls.Add(Me.SuperTabControlPanel1)
        Me.SuperTabControl1.ForeColor = System.Drawing.Color.Black
        Me.SuperTabControl1.Location = New System.Drawing.Point(7, 431)
        Me.SuperTabControl1.Name = "SuperTabControl1"
        Me.SuperTabControl1.ReorderTabsEnabled = True
        Me.SuperTabControl1.SelectedTabFont = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold)
        Me.SuperTabControl1.SelectedTabIndex = 0
        Me.SuperTabControl1.Size = New System.Drawing.Size(737, 157)
        Me.SuperTabControl1.TabFont = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SuperTabControl1.TabIndex = 98
        Me.SuperTabControl1.Tabs.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.SuperTabItem2, Me.SuperTabItem1})
        Me.SuperTabControl1.Text = "SuperTabControl1"
        '
        'SuperTabControlPanel2
        '
        Me.SuperTabControlPanel2.Controls.Add(Me.Grilla_Maquinas)
        Me.SuperTabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel2.Location = New System.Drawing.Point(0, 27)
        Me.SuperTabControlPanel2.Name = "SuperTabControlPanel2"
        Me.SuperTabControlPanel2.Size = New System.Drawing.Size(737, 130)
        Me.SuperTabControlPanel2.TabIndex = 0
        Me.SuperTabControlPanel2.TabItem = Me.SuperTabItem2
        '
        'SuperTabItem2
        '
        Me.SuperTabItem2.AttachedControl = Me.SuperTabControlPanel2
        Me.SuperTabItem2.GlobalItem = False
        Me.SuperTabItem2.Name = "SuperTabItem2"
        Me.SuperTabItem2.Text = "Maquinas del mesón"
        '
        'SuperTabControlPanel1
        '
        Me.SuperTabControlPanel1.Controls.Add(Me.Grilla_Operarios)
        Me.SuperTabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel1.Location = New System.Drawing.Point(0, 27)
        Me.SuperTabControlPanel1.Name = "SuperTabControlPanel1"
        Me.SuperTabControlPanel1.Size = New System.Drawing.Size(737, 130)
        Me.SuperTabControlPanel1.TabIndex = 1
        Me.SuperTabControlPanel1.TabItem = Me.SuperTabItem1
        '
        'SuperTabItem1
        '
        Me.SuperTabItem1.AttachedControl = Me.SuperTabControlPanel1
        Me.SuperTabItem1.GlobalItem = False
        Me.SuperTabItem1.Name = "SuperTabItem1"
        Me.SuperTabItem1.Text = "Operarios asignado al mesón"
        '
        'Rdb_Ordenar_Codigo
        '
        Me.Rdb_Ordenar_Codigo.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Rdb_Ordenar_Codigo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Ordenar_Codigo.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Ordenar_Codigo.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Ordenar_Codigo.Location = New System.Drawing.Point(453, 397)
        Me.Rdb_Ordenar_Codigo.Name = "Rdb_Ordenar_Codigo"
        Me.Rdb_Ordenar_Codigo.Size = New System.Drawing.Size(124, 23)
        Me.Rdb_Ordenar_Codigo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Ordenar_Codigo.TabIndex = 99
        Me.Rdb_Ordenar_Codigo.Text = "Ordenar por código"
        Me.Rdb_Ordenar_Codigo.Visible = False
        '
        'Rdb_Ordenar_Descripcion
        '
        Me.Rdb_Ordenar_Descripcion.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Rdb_Ordenar_Descripcion.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Ordenar_Descripcion.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Ordenar_Descripcion.Checked = True
        Me.Rdb_Ordenar_Descripcion.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Rdb_Ordenar_Descripcion.CheckValue = "Y"
        Me.Rdb_Ordenar_Descripcion.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Ordenar_Descripcion.Location = New System.Drawing.Point(574, 397)
        Me.Rdb_Ordenar_Descripcion.Name = "Rdb_Ordenar_Descripcion"
        Me.Rdb_Ordenar_Descripcion.Size = New System.Drawing.Size(163, 23)
        Me.Rdb_Ordenar_Descripcion.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Ordenar_Descripcion.TabIndex = 100
        Me.Rdb_Ordenar_Descripcion.Text = "Ordenar por descripción"
        Me.Rdb_Ordenar_Descripcion.Visible = False
        '
        'Btn_Bajar_Producto
        '
        Me.Btn_Bajar_Producto.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Bajar_Producto.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Bajar_Producto.Image = CType(resources.GetObject("Btn_Bajar_Producto.Image"), System.Drawing.Image)
        Me.Btn_Bajar_Producto.Location = New System.Drawing.Point(96, 397)
        Me.Btn_Bajar_Producto.Name = "Btn_Bajar_Producto"
        Me.Btn_Bajar_Producto.Size = New System.Drawing.Size(83, 28)
        Me.Btn_Bajar_Producto.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Bajar_Producto.TabIndex = 111
        Me.Btn_Bajar_Producto.Text = "Bajar fila"
        '
        'Btn_Subir_Producto
        '
        Me.Btn_Subir_Producto.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Subir_Producto.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Subir_Producto.Image = CType(resources.GetObject("Btn_Subir_Producto.Image"), System.Drawing.Image)
        Me.Btn_Subir_Producto.Location = New System.Drawing.Point(7, 397)
        Me.Btn_Subir_Producto.Name = "Btn_Subir_Producto"
        Me.Btn_Subir_Producto.Size = New System.Drawing.Size(83, 28)
        Me.Btn_Subir_Producto.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Subir_Producto.TabIndex = 110
        Me.Btn_Subir_Producto.Text = "Subir fila"
        '
        'LabelX5
        '
        Me.LabelX5.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX5.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.LabelX5.ForeColor = System.Drawing.Color.Black
        Me.LabelX5.Location = New System.Drawing.Point(10, 337)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.Size = New System.Drawing.Size(68, 23)
        Me.LabelX5.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.LabelX5.TabIndex = 118
        Me.LabelX5.Text = "Equivalente"
        '
        'LabelX4
        '
        Me.LabelX4.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.LabelX4.ForeColor = System.Drawing.Color.Black
        Me.LabelX4.Location = New System.Drawing.Point(10, 364)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(51, 23)
        Me.LabelX4.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.LabelX4.TabIndex = 117
        Me.LabelX4.Text = "Reproceso"
        '
        'Txt_Operacion_Reproceso
        '
        Me.Txt_Operacion_Reproceso.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Operacion_Reproceso.Border.Class = "TextBoxBorder"
        Me.Txt_Operacion_Reproceso.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Operacion_Reproceso.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Operacion_Reproceso.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Txt_Operacion_Reproceso.FocusHighlightEnabled = True
        Me.Txt_Operacion_Reproceso.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.Txt_Operacion_Reproceso.ForeColor = System.Drawing.Color.Black
        Me.Txt_Operacion_Reproceso.Location = New System.Drawing.Point(141, 364)
        Me.Txt_Operacion_Reproceso.MaxLength = 13
        Me.Txt_Operacion_Reproceso.Name = "Txt_Operacion_Reproceso"
        Me.Txt_Operacion_Reproceso.ReadOnly = True
        Me.Txt_Operacion_Reproceso.Size = New System.Drawing.Size(603, 22)
        Me.Txt_Operacion_Reproceso.TabIndex = 116
        '
        'LabelX3
        '
        Me.LabelX3.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.LabelX3.ForeColor = System.Drawing.Color.Black
        Me.LabelX3.Location = New System.Drawing.Point(10, 311)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(51, 23)
        Me.LabelX3.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.LabelX3.TabIndex = 115
        Me.LabelX3.Text = "Regular"
        '
        'Txt_Operacion_Equivalente
        '
        Me.Txt_Operacion_Equivalente.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Operacion_Equivalente.Border.Class = "TextBoxBorder"
        Me.Txt_Operacion_Equivalente.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Operacion_Equivalente.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Operacion_Equivalente.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Txt_Operacion_Equivalente.FocusHighlightEnabled = True
        Me.Txt_Operacion_Equivalente.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.Txt_Operacion_Equivalente.ForeColor = System.Drawing.Color.Black
        Me.Txt_Operacion_Equivalente.Location = New System.Drawing.Point(141, 338)
        Me.Txt_Operacion_Equivalente.MaxLength = 13
        Me.Txt_Operacion_Equivalente.Name = "Txt_Operacion_Equivalente"
        Me.Txt_Operacion_Equivalente.ReadOnly = True
        Me.Txt_Operacion_Equivalente.Size = New System.Drawing.Size(603, 22)
        Me.Txt_Operacion_Equivalente.TabIndex = 114
        '
        'Txt_Operacion
        '
        Me.Txt_Operacion.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Operacion.Border.Class = "TextBoxBorder"
        Me.Txt_Operacion.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Operacion.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Operacion.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Txt_Operacion.FocusHighlightEnabled = True
        Me.Txt_Operacion.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.Txt_Operacion.ForeColor = System.Drawing.Color.Black
        Me.Txt_Operacion.Location = New System.Drawing.Point(141, 312)
        Me.Txt_Operacion.MaxLength = 13
        Me.Txt_Operacion.Name = "Txt_Operacion"
        Me.Txt_Operacion.ReadOnly = True
        Me.Txt_Operacion.Size = New System.Drawing.Size(603, 22)
        Me.Txt_Operacion.TabIndex = 113
        '
        'LabelX2
        '
        Me.LabelX2.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.LabelX2.ForeColor = System.Drawing.Color.Black
        Me.LabelX2.Location = New System.Drawing.Point(10, 291)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(133, 23)
        Me.LabelX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.LabelX2.TabIndex = 112
        Me.LabelX2.Text = "OPERACION ASOCIADA"
        '
        'Frm_Mesones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(756, 635)
        Me.Controls.Add(Me.LabelX5)
        Me.Controls.Add(Me.LabelX4)
        Me.Controls.Add(Me.Txt_Operacion_Reproceso)
        Me.Controls.Add(Me.LabelX3)
        Me.Controls.Add(Me.Txt_Operacion_Equivalente)
        Me.Controls.Add(Me.Txt_Operacion)
        Me.Controls.Add(Me.LabelX2)
        Me.Controls.Add(Me.Btn_Bajar_Producto)
        Me.Controls.Add(Me.Btn_Subir_Producto)
        Me.Controls.Add(Me.Rdb_Ordenar_Descripcion)
        Me.Controls.Add(Me.Rdb_Ordenar_Codigo)
        Me.Controls.Add(Me.SuperTabControl1)
        Me.Controls.Add(Me.Bar1)
        Me.Controls.Add(Me.GroupPanel4)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Mesones"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MANTENCION DE MESONES"
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel4.ResumeLayout(False)
        CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Grilla_Mesones, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Grilla_Maquinas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Grilla_Operarios, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SuperTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SuperTabControl1.ResumeLayout(False)
        Me.SuperTabControlPanel2.ResumeLayout(False)
        Me.SuperTabControlPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Public WithEvents Btn_Crear As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents GroupPanel4 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Grilla_Mesones As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents Grilla_Maquinas As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents ContextMenuBar1 As DevComponents.DotNetBar.ContextMenuBar
    Friend WithEvents Menu_Contextual_Meson As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Mnu_Editar_Meson As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Eliminar_Meson As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Agregar_Maquina As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Menu_Contextual_Maquina As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Mnu_Quitar_Maquina As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Agregar_Operario As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Grilla_Operarios As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents Menu_Contextual_Operario As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Mnu_Quitar_Operario As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelItem1 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents Imagenes_16x16 As System.Windows.Forms.ImageList
    Friend WithEvents SuperTabControl1 As DevComponents.DotNetBar.SuperTabControl
    Friend WithEvents SuperTabControlPanel1 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents SuperTabItem1 As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents SuperTabControlPanel2 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents SuperTabItem2 As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents Rdb_Ordenar_Codigo As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_Ordenar_Descripcion As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Btn_Bajar_Producto As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Btn_Subir_Producto As DevComponents.DotNetBar.ButtonX
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Public WithEvents Txt_Operacion_Reproceso As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Public WithEvents Txt_Operacion_Equivalente As DevComponents.DotNetBar.Controls.TextBoxX
    Public WithEvents Txt_Operacion As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
End Class
