<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Permisos_Usuario_Lista
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Permisos_Usuario_Lista))
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Bar2 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Ver_Permisos_de_usuarios_activo = New DevComponents.DotNetBar.ButtonItem()
        Me.Chk_Solo_Activos = New DevComponents.DotNetBar.CheckBoxItem()
        Me.Btn_Reparar_Permisos = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Actualizar_Lista_Permisos = New DevComponents.DotNetBar.ButtonItem()
        Me.Grupo_Funcionarios = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Grilla = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.GroupPanel2 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Txtdescripcion = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Rdb_Ambos = New DevComponents.DotNetBar.CheckBoxItem()
        Me.Rdb_Clientes = New DevComponents.DotNetBar.CheckBoxItem()
        Me.Rdb_Proveedores = New DevComponents.DotNetBar.CheckBoxItem()
        Me.MetroStatusBar1 = New DevComponents.DotNetBar.Metro.MetroStatusBar()
        Me.Lbl_Status = New DevComponents.DotNetBar.LabelItem()
        Me.Rdb_Todos_Pueden_Dar_Permisos = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Rdb_Solo_Supervisores_Dan_Permisos = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Btn_Exportar_Excel_Permisos_Usuarios = New DevComponents.DotNetBar.ButtonItem()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Grupo_Funcionarios.SuspendLayout()
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel2.SuspendLayout()
        Me.GroupPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Bar2
        '
        Me.Bar2.AntiAlias = True
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Ver_Permisos_de_usuarios_activo, Me.Btn_Exportar_Excel_Permisos_Usuarios, Me.Chk_Solo_Activos, Me.Btn_Reparar_Permisos, Me.Btn_Actualizar_Lista_Permisos})
        Me.Bar2.Location = New System.Drawing.Point(0, 589)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(556, 41)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Bar2.TabIndex = 12
        Me.Bar2.TabStop = False
        Me.Bar2.Text = "Bar2"
        '
        'Btn_Ver_Permisos_de_usuarios_activo
        '
        Me.Btn_Ver_Permisos_de_usuarios_activo.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Ver_Permisos_de_usuarios_activo.ForeColor = System.Drawing.Color.Black
        Me.Btn_Ver_Permisos_de_usuarios_activo.Image = CType(resources.GetObject("Btn_Ver_Permisos_de_usuarios_activo.Image"), System.Drawing.Image)
        Me.Btn_Ver_Permisos_de_usuarios_activo.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.Btn_Ver_Permisos_de_usuarios_activo.Name = "Btn_Ver_Permisos_de_usuarios_activo"
        Me.Btn_Ver_Permisos_de_usuarios_activo.Tooltip = "Ver permisos del usuario"
        '
        'Chk_Solo_Activos
        '
        Me.Chk_Solo_Activos.Checked = True
        Me.Chk_Solo_Activos.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Chk_Solo_Activos.Name = "Chk_Solo_Activos"
        Me.Chk_Solo_Activos.Text = "Ver solo activos"
        '
        'Btn_Reparar_Permisos
        '
        Me.Btn_Reparar_Permisos.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Reparar_Permisos.ForeColor = System.Drawing.Color.Black
        Me.Btn_Reparar_Permisos.Image = CType(resources.GetObject("Btn_Reparar_Permisos.Image"), System.Drawing.Image)
        Me.Btn_Reparar_Permisos.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.Btn_Reparar_Permisos.Name = "Btn_Reparar_Permisos"
        Me.Btn_Reparar_Permisos.Tooltip = "Reparar los permisos asignados"
        '
        'Btn_Actualizar_Lista_Permisos
        '
        Me.Btn_Actualizar_Lista_Permisos.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Actualizar_Lista_Permisos.ForeColor = System.Drawing.Color.Black
        Me.Btn_Actualizar_Lista_Permisos.Image = CType(resources.GetObject("Btn_Actualizar_Lista_Permisos.Image"), System.Drawing.Image)
        Me.Btn_Actualizar_Lista_Permisos.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.Btn_Actualizar_Lista_Permisos.Name = "Btn_Actualizar_Lista_Permisos"
        Me.Btn_Actualizar_Lista_Permisos.Tooltip = "Actualizar lista de permisos de la base de datos"
        '
        'Grupo_Funcionarios
        '
        Me.Grupo_Funcionarios.BackColor = System.Drawing.Color.White
        Me.Grupo_Funcionarios.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Grupo_Funcionarios.Controls.Add(Me.Grilla)
        Me.Grupo_Funcionarios.DisabledBackColor = System.Drawing.Color.Empty
        Me.Grupo_Funcionarios.Location = New System.Drawing.Point(6, 73)
        Me.Grupo_Funcionarios.Name = "Grupo_Funcionarios"
        Me.Grupo_Funcionarios.Size = New System.Drawing.Size(542, 410)
        '
        '
        '
        Me.Grupo_Funcionarios.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Grupo_Funcionarios.Style.BackColorGradientAngle = 90
        Me.Grupo_Funcionarios.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Grupo_Funcionarios.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Funcionarios.Style.BorderBottomWidth = 1
        Me.Grupo_Funcionarios.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.Grupo_Funcionarios.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Funcionarios.Style.BorderLeftWidth = 1
        Me.Grupo_Funcionarios.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Funcionarios.Style.BorderRightWidth = 1
        Me.Grupo_Funcionarios.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Funcionarios.Style.BorderTopWidth = 1
        Me.Grupo_Funcionarios.Style.CornerDiameter = 4
        Me.Grupo_Funcionarios.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Grupo_Funcionarios.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.Grupo_Funcionarios.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.Grupo_Funcionarios.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.Grupo_Funcionarios.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.Grupo_Funcionarios.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Grupo_Funcionarios.TabIndex = 13
        Me.Grupo_Funcionarios.Text = "Seleccione la entidad con doble clic o enter sobre la línea"
        '
        'Grilla
        '
        Me.Grilla.AllowUserToAddRows = False
        Me.Grilla.AllowUserToDeleteRows = False
        Me.Grilla.AllowUserToOrderColumns = True
        Me.Grilla.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.Grilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle10.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Grilla.DefaultCellStyle = DataGridViewCellStyle10
        Me.Grilla.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grilla.EnableHeadersVisualStyles = False
        Me.Grilla.GridColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.Grilla.Location = New System.Drawing.Point(0, 0)
        Me.Grilla.Name = "Grilla"
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle11.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla.RowHeadersDefaultCellStyle = DataGridViewCellStyle11
        Me.Grilla.RowHeadersVisible = False
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.Black
        Me.Grilla.RowsDefaultCellStyle = DataGridViewCellStyle12
        Me.Grilla.RowTemplate.Height = 25
        Me.Grilla.Size = New System.Drawing.Size(536, 387)
        Me.Grilla.TabIndex = 20
        '
        'GroupPanel2
        '
        Me.GroupPanel2.BackColor = System.Drawing.Color.White
        Me.GroupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel2.Controls.Add(Me.Txtdescripcion)
        Me.GroupPanel2.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel2.Location = New System.Drawing.Point(6, 6)
        Me.GroupPanel2.Name = "GroupPanel2"
        Me.GroupPanel2.Size = New System.Drawing.Size(542, 61)
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
        Me.GroupPanel2.TabIndex = 14
        Me.GroupPanel2.Text = "Buscar producto ingrese algo del rut, código o descripción de la entidad"
        '
        'Txtdescripcion
        '
        Me.Txtdescripcion.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txtdescripcion.Border.Class = "TextBoxBorder"
        Me.Txtdescripcion.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txtdescripcion.DisabledBackColor = System.Drawing.Color.White
        Me.Txtdescripcion.ForeColor = System.Drawing.Color.Black
        Me.Txtdescripcion.Location = New System.Drawing.Point(3, 13)
        Me.Txtdescripcion.Name = "Txtdescripcion"
        Me.Txtdescripcion.PreventEnterBeep = True
        Me.Txtdescripcion.Size = New System.Drawing.Size(530, 22)
        Me.Txtdescripcion.TabIndex = 0
        '
        'Rdb_Ambos
        '
        Me.Rdb_Ambos.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Ambos.Checked = True
        Me.Rdb_Ambos.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Rdb_Ambos.Name = "Rdb_Ambos"
        Me.Rdb_Ambos.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Rdb_Clientes})
        Me.Rdb_Ambos.Text = "Buscar ambos"
        '
        'Rdb_Clientes
        '
        Me.Rdb_Clientes.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Clientes.Name = "Rdb_Clientes"
        Me.Rdb_Clientes.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Rdb_Proveedores})
        Me.Rdb_Clientes.Text = "Solo clientes"
        '
        'Rdb_Proveedores
        '
        Me.Rdb_Proveedores.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Proveedores.Name = "Rdb_Proveedores"
        Me.Rdb_Proveedores.Text = "Solo proveedores"
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
        Me.MetroStatusBar1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MetroStatusBar1.ForeColor = System.Drawing.Color.Black
        Me.MetroStatusBar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Lbl_Status})
        Me.MetroStatusBar1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.MetroStatusBar1.Location = New System.Drawing.Point(0, 630)
        Me.MetroStatusBar1.Name = "MetroStatusBar1"
        Me.MetroStatusBar1.Size = New System.Drawing.Size(556, 22)
        Me.MetroStatusBar1.TabIndex = 19
        Me.MetroStatusBar1.Text = "MetroStatusBar1"
        '
        'Lbl_Status
        '
        Me.Lbl_Status.Name = "Lbl_Status"
        Me.Lbl_Status.Text = "Lbl_Status"
        '
        'Rdb_Todos_Pueden_Dar_Permisos
        '
        Me.Rdb_Todos_Pueden_Dar_Permisos.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Todos_Pueden_Dar_Permisos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Todos_Pueden_Dar_Permisos.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Todos_Pueden_Dar_Permisos.Checked = True
        Me.Rdb_Todos_Pueden_Dar_Permisos.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Rdb_Todos_Pueden_Dar_Permisos.CheckValue = "Y"
        Me.Rdb_Todos_Pueden_Dar_Permisos.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Todos_Pueden_Dar_Permisos.Location = New System.Drawing.Point(3, 36)
        Me.Rdb_Todos_Pueden_Dar_Permisos.Name = "Rdb_Todos_Pueden_Dar_Permisos"
        Me.Rdb_Todos_Pueden_Dar_Permisos.Size = New System.Drawing.Size(536, 23)
        Me.Rdb_Todos_Pueden_Dar_Permisos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Todos_Pueden_Dar_Permisos.TabIndex = 20
        Me.Rdb_Todos_Pueden_Dar_Permisos.Text = "Cualquier usuario puede dar permisos a otros usuarios."
        '
        'GroupPanel1
        '
        Me.GroupPanel1.BackColor = System.Drawing.Color.White
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.Rdb_Solo_Supervisores_Dan_Permisos)
        Me.GroupPanel1.Controls.Add(Me.Rdb_Todos_Pueden_Dar_Permisos)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Location = New System.Drawing.Point(6, 489)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(542, 94)
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
        Me.GroupPanel1.TabIndex = 21
        Me.GroupPanel1.Text = "Permisos en tiempo de ejecución"
        '
        'Rdb_Solo_Supervisores_Dan_Permisos
        '
        Me.Rdb_Solo_Supervisores_Dan_Permisos.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Solo_Supervisores_Dan_Permisos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Solo_Supervisores_Dan_Permisos.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Solo_Supervisores_Dan_Permisos.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Solo_Supervisores_Dan_Permisos.Location = New System.Drawing.Point(3, 7)
        Me.Rdb_Solo_Supervisores_Dan_Permisos.Name = "Rdb_Solo_Supervisores_Dan_Permisos"
        Me.Rdb_Solo_Supervisores_Dan_Permisos.Size = New System.Drawing.Size(518, 23)
        Me.Rdb_Solo_Supervisores_Dan_Permisos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Solo_Supervisores_Dan_Permisos.TabIndex = 21
        Me.Rdb_Solo_Supervisores_Dan_Permisos.Text = "Solo los usuarios con permisos de supervisor pueden dar permios a otros usuarios " &
    "(Recomendado)."
        '
        'Btn_Exportar_Excel_Permisos_Usuarios
        '
        Me.Btn_Exportar_Excel_Permisos_Usuarios.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Exportar_Excel_Permisos_Usuarios.ForeColor = System.Drawing.Color.Black
        Me.Btn_Exportar_Excel_Permisos_Usuarios.Image = CType(resources.GetObject("Btn_Exportar_Excel_Permisos_Usuarios.Image"), System.Drawing.Image)
        Me.Btn_Exportar_Excel_Permisos_Usuarios.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.Btn_Exportar_Excel_Permisos_Usuarios.Name = "Btn_Exportar_Excel_Permisos_Usuarios"
        Me.Btn_Exportar_Excel_Permisos_Usuarios.Tooltip = "Exportar a Excel todos los permisos de los usuarios"
        '
        'Frm_Permisos_Usuario_Lista
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(556, 652)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Controls.Add(Me.Bar2)
        Me.Controls.Add(Me.MetroStatusBar1)
        Me.Controls.Add(Me.Grupo_Funcionarios)
        Me.Controls.Add(Me.GroupPanel2)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Permisos_Usuario_Lista"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Usuarios del sistema"
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Grupo_Funcionarios.ResumeLayout(False)
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel2.ResumeLayout(False)
        Me.GroupPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents Btn_Ver_Permisos_de_usuarios_activo As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Grupo_Funcionarios As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents GroupPanel2 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Txtdescripcion As DevComponents.DotNetBar.Controls.TextBoxX
    Public WithEvents Rdb_Ambos As DevComponents.DotNetBar.CheckBoxItem
    Public WithEvents Rdb_Clientes As DevComponents.DotNetBar.CheckBoxItem
    Public WithEvents Rdb_Proveedores As DevComponents.DotNetBar.CheckBoxItem
    Friend WithEvents Chk_Solo_Activos As DevComponents.DotNetBar.CheckBoxItem
    Friend WithEvents Btn_Actualizar_Lista_Permisos As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents MetroStatusBar1 As DevComponents.DotNetBar.Metro.MetroStatusBar
    Friend WithEvents Lbl_Status As DevComponents.DotNetBar.LabelItem
    Friend WithEvents Btn_Reparar_Permisos As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Grilla As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents Rdb_Todos_Pueden_Dar_Permisos As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Rdb_Solo_Supervisores_Dan_Permisos As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Btn_Exportar_Excel_Permisos_Usuarios As DevComponents.DotNetBar.ButtonItem
End Class
