<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_08_Asis_Compra_IncorpProveedor
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_08_Asis_Compra_IncorpProveedor))
        Me.Chk_Ent_Fisica = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.BtnProcesarInf = New DevComponents.DotNetBar.ButtonItem()
        Me.BtnEntidadesExcluidas = New DevComponents.DotNetBar.ButtonItem()
        Me.Dtp_Fecha_Tope_Proveedores_Automaticos = New System.Windows.Forms.DateTimePicker()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Rdb_Ud2_Compra = New System.Windows.Forms.RadioButton()
        Me.Rdb_Ud1_Compra = New System.Windows.Forms.RadioButton()
        Me.ProgressBarX1 = New DevComponents.DotNetBar.Controls.ProgressBarX()
        Me.Chk_Mostrar_Solo_Stock_Critico = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.Cmb_Documento_Compra = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.GroupPanel2 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.GroupPanel3 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Chk_Restar_Stok_Bodega = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Chk_Sumar_Rotacion_Hermanos = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Chk_Traer_Productos_De_Reemplazo = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.GroupPanel4 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Rd_Costo_Lista_Proveedor = New System.Windows.Forms.RadioButton()
        Me.Rd_Costo_Ultimo_Documento_Seleccionado = New System.Windows.Forms.RadioButton()
        Me.GroupPanel6 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Chk_No_Considera_Con_Stock_Pedido_OCC_NVI = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.GroupPanel7 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Input_Dias_a_Abastecer = New DevComponents.Editors.IntegerInput()
        Me.Input_Tiempo_Reposicion = New DevComponents.Editors.IntegerInput()
        Me.LabelX7 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX6 = New DevComponents.DotNetBar.LabelX()
        Me.GroupPanel5 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Cmb_Proyeccion_Tiempo_Reposicion_ = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.Cmb_Proyeccion_Metodo_Abastecer_ = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.Chk_Agrupar_Productos_De_Reemplazo = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.GroupPanel8 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Chk_Domingo = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Chk_Sabado = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Chk_Incluir_Ent_Excluidas = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Timer_Ejecucion_Automatica = New System.Windows.Forms.Timer(Me.components)
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel1.SuspendLayout()
        Me.GroupPanel2.SuspendLayout()
        Me.GroupPanel3.SuspendLayout()
        Me.GroupPanel4.SuspendLayout()
        Me.GroupPanel6.SuspendLayout()
        Me.GroupPanel7.SuspendLayout()
        CType(Me.Input_Dias_a_Abastecer, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Input_Tiempo_Reposicion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel5.SuspendLayout()
        Me.GroupPanel8.SuspendLayout()
        Me.SuspendLayout()
        '
        'Chk_Ent_Fisica
        '
        Me.Chk_Ent_Fisica.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_Ent_Fisica.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Ent_Fisica.ForeColor = System.Drawing.Color.Black
        Me.Chk_Ent_Fisica.Location = New System.Drawing.Point(3, 23)
        Me.Chk_Ent_Fisica.Name = "Chk_Ent_Fisica"
        Me.Chk_Ent_Fisica.Size = New System.Drawing.Size(102, 23)
        Me.Chk_Ent_Fisica.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Ent_Fisica.TabIndex = 22
        Me.Chk_Ent_Fisica.Text = "Es entidad física"
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.BtnProcesarInf, Me.BtnEntidadesExcluidas})
        Me.Bar1.Location = New System.Drawing.Point(0, 167)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(757, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 29
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'BtnProcesarInf
        '
        Me.BtnProcesarInf.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnProcesarInf.ForeColor = System.Drawing.Color.Black
        Me.BtnProcesarInf.Image = CType(resources.GetObject("BtnProcesarInf.Image"), System.Drawing.Image)
        Me.BtnProcesarInf.Name = "BtnProcesarInf"
        Me.BtnProcesarInf.Text = "Procesar"
        '
        'BtnEntidadesExcluidas
        '
        Me.BtnEntidadesExcluidas.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnEntidadesExcluidas.ForeColor = System.Drawing.Color.Black
        Me.BtnEntidadesExcluidas.Image = CType(resources.GetObject("BtnEntidadesExcluidas.Image"), System.Drawing.Image)
        Me.BtnEntidadesExcluidas.Name = "BtnEntidadesExcluidas"
        Me.BtnEntidadesExcluidas.Text = "Entidades excluidas"
        Me.BtnEntidadesExcluidas.Visible = False
        '
        'Dtp_Fecha_Tope_Proveedores_Automaticos
        '
        Me.Dtp_Fecha_Tope_Proveedores_Automaticos.BackColor = System.Drawing.Color.White
        Me.Dtp_Fecha_Tope_Proveedores_Automaticos.ForeColor = System.Drawing.Color.Black
        Me.Dtp_Fecha_Tope_Proveedores_Automaticos.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Dtp_Fecha_Tope_Proveedores_Automaticos.Location = New System.Drawing.Point(52, 10)
        Me.Dtp_Fecha_Tope_Proveedores_Automaticos.Name = "Dtp_Fecha_Tope_Proveedores_Automaticos"
        Me.Dtp_Fecha_Tope_Proveedores_Automaticos.Size = New System.Drawing.Size(95, 22)
        Me.Dtp_Fecha_Tope_Proveedores_Automaticos.TabIndex = 0
        Me.Dtp_Fecha_Tope_Proveedores_Automaticos.Value = New Date(2014, 8, 1, 0, 0, 0, 0)
        '
        'Rdb_Ud2_Compra
        '
        Me.Rdb_Ud2_Compra.AutoSize = True
        Me.Rdb_Ud2_Compra.BackColor = System.Drawing.Color.Transparent
        Me.Rdb_Ud2_Compra.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Ud2_Compra.Location = New System.Drawing.Point(3, 33)
        Me.Rdb_Ud2_Compra.Name = "Rdb_Ud2_Compra"
        Me.Rdb_Ud2_Compra.Size = New System.Drawing.Size(127, 17)
        Me.Rdb_Ud2_Compra.TabIndex = 1
        Me.Rdb_Ud2_Compra.TabStop = True
        Me.Rdb_Ud2_Compra.Text = "2 [Segunda Unidad]"
        Me.Rdb_Ud2_Compra.UseVisualStyleBackColor = False
        '
        'Rdb_Ud1_Compra
        '
        Me.Rdb_Ud1_Compra.AutoSize = True
        Me.Rdb_Ud1_Compra.BackColor = System.Drawing.Color.Transparent
        Me.Rdb_Ud1_Compra.Checked = True
        Me.Rdb_Ud1_Compra.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Ud1_Compra.Location = New System.Drawing.Point(3, 10)
        Me.Rdb_Ud1_Compra.Name = "Rdb_Ud1_Compra"
        Me.Rdb_Ud1_Compra.Size = New System.Drawing.Size(119, 17)
        Me.Rdb_Ud1_Compra.TabIndex = 0
        Me.Rdb_Ud1_Compra.TabStop = True
        Me.Rdb_Ud1_Compra.Text = "1 [Primera Unidad]"
        Me.Rdb_Ud1_Compra.UseVisualStyleBackColor = False
        '
        'ProgressBarX1
        '
        Me.ProgressBarX1.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.ProgressBarX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ProgressBarX1.ForeColor = System.Drawing.Color.Black
        Me.ProgressBarX1.Location = New System.Drawing.Point(12, 112)
        Me.ProgressBarX1.Name = "ProgressBarX1"
        Me.ProgressBarX1.Size = New System.Drawing.Size(732, 23)
        Me.ProgressBarX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.ProgressBarX1.TabIndex = 33
        Me.ProgressBarX1.Text = "0%"
        Me.ProgressBarX1.TextVisible = True
        '
        'Chk_Mostrar_Solo_Stock_Critico
        '
        Me.Chk_Mostrar_Solo_Stock_Critico.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_Mostrar_Solo_Stock_Critico.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Mostrar_Solo_Stock_Critico.Checked = True
        Me.Chk_Mostrar_Solo_Stock_Critico.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Chk_Mostrar_Solo_Stock_Critico.CheckValue = "Y"
        Me.Chk_Mostrar_Solo_Stock_Critico.Enabled = False
        Me.Chk_Mostrar_Solo_Stock_Critico.ForeColor = System.Drawing.Color.Black
        Me.Chk_Mostrar_Solo_Stock_Critico.Location = New System.Drawing.Point(3, 59)
        Me.Chk_Mostrar_Solo_Stock_Critico.Name = "Chk_Mostrar_Solo_Stock_Critico"
        Me.Chk_Mostrar_Solo_Stock_Critico.Size = New System.Drawing.Size(150, 21)
        Me.Chk_Mostrar_Solo_Stock_Critico.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Mostrar_Solo_Stock_Critico.TabIndex = 17
        Me.Chk_Mostrar_Solo_Stock_Critico.Text = "Mostrar solo Stock critico"
        '
        'GroupPanel1
        '
        Me.GroupPanel1.BackColor = System.Drawing.Color.White
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.LabelX3)
        Me.GroupPanel1.Controls.Add(Me.Cmb_Documento_Compra)
        Me.GroupPanel1.Controls.Add(Me.LabelX2)
        Me.GroupPanel1.Controls.Add(Me.LabelX1)
        Me.GroupPanel1.Controls.Add(Me.Dtp_Fecha_Tope_Proveedores_Automaticos)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Location = New System.Drawing.Point(12, 6)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(524, 100)
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
        Me.GroupPanel1.TabIndex = 37
        Me.GroupPanel1.Text = "Fecha de tope para seleccionar proveedor"
        '
        'LabelX3
        '
        Me.LabelX3.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.ForeColor = System.Drawing.Color.Black
        Me.LabelX3.Location = New System.Drawing.Point(183, 10)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(70, 23)
        Me.LabelX3.TabIndex = 41
        Me.LabelX3.Text = "<b>Documento:</b> "
        '
        'Cmb_Documento_Compra
        '
        Me.Cmb_Documento_Compra.DisplayMember = "Text"
        Me.Cmb_Documento_Compra.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.Cmb_Documento_Compra.ForeColor = System.Drawing.Color.Black
        Me.Cmb_Documento_Compra.FormattingEnabled = True
        Me.Cmb_Documento_Compra.ItemHeight = 16
        Me.Cmb_Documento_Compra.Location = New System.Drawing.Point(259, 9)
        Me.Cmb_Documento_Compra.Name = "Cmb_Documento_Compra"
        Me.Cmb_Documento_Compra.Size = New System.Drawing.Size(208, 22)
        Me.Cmb_Documento_Compra.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Cmb_Documento_Compra.TabIndex = 40
        '
        'LabelX2
        '
        Me.LabelX2.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.ForeColor = System.Drawing.Color.Black
        Me.LabelX2.Location = New System.Drawing.Point(3, 9)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(43, 23)
        Me.LabelX2.TabIndex = 39
        Me.LabelX2.Text = "<b>Fecha:</b> "
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.ForeColor = System.Drawing.Color.Black
        Me.LabelX1.Location = New System.Drawing.Point(3, 38)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(506, 32)
        Me.LabelX1.TabIndex = 38
        Me.LabelX1.Text = "<b>Fecha tope de búsqueda del precio mínimo según proveedor con el mejor precio." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Si no encuentra guías, traerá la última compra recepcionada del producto.</b>" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) &
    ""
        '
        'GroupPanel2
        '
        Me.GroupPanel2.BackColor = System.Drawing.Color.White
        Me.GroupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel2.Controls.Add(Me.Chk_Ent_Fisica)
        Me.GroupPanel2.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel2.Location = New System.Drawing.Point(982, 21)
        Me.GroupPanel2.Name = "GroupPanel2"
        Me.GroupPanel2.Size = New System.Drawing.Size(133, 104)
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
        Me.GroupPanel2.TabIndex = 38
        Me.GroupPanel2.Text = "Proveedor seleccionado"
        '
        'GroupPanel3
        '
        Me.GroupPanel3.BackColor = System.Drawing.Color.White
        Me.GroupPanel3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel3.Controls.Add(Me.Chk_Restar_Stok_Bodega)
        Me.GroupPanel3.Controls.Add(Me.Chk_Sumar_Rotacion_Hermanos)
        Me.GroupPanel3.Controls.Add(Me.Chk_Traer_Productos_De_Reemplazo)
        Me.GroupPanel3.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel3.Location = New System.Drawing.Point(783, 12)
        Me.GroupPanel3.Name = "GroupPanel3"
        Me.GroupPanel3.Size = New System.Drawing.Size(177, 104)
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
        Me.GroupPanel3.TabIndex = 39
        Me.GroupPanel3.Text = "Producto reemplazo"
        '
        'Chk_Restar_Stok_Bodega
        '
        Me.Chk_Restar_Stok_Bodega.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_Restar_Stok_Bodega.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Restar_Stok_Bodega.ForeColor = System.Drawing.Color.Black
        Me.Chk_Restar_Stok_Bodega.Location = New System.Drawing.Point(4, 46)
        Me.Chk_Restar_Stok_Bodega.Name = "Chk_Restar_Stok_Bodega"
        Me.Chk_Restar_Stok_Bodega.Size = New System.Drawing.Size(170, 23)
        Me.Chk_Restar_Stok_Bodega.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Restar_Stok_Bodega.TabIndex = 44
        Me.Chk_Restar_Stok_Bodega.Text = "Restar stock de bodega (s)"
        '
        'Chk_Sumar_Rotacion_Hermanos
        '
        Me.Chk_Sumar_Rotacion_Hermanos.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_Sumar_Rotacion_Hermanos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Sumar_Rotacion_Hermanos.ForeColor = System.Drawing.Color.Black
        Me.Chk_Sumar_Rotacion_Hermanos.Location = New System.Drawing.Point(4, 23)
        Me.Chk_Sumar_Rotacion_Hermanos.Name = "Chk_Sumar_Rotacion_Hermanos"
        Me.Chk_Sumar_Rotacion_Hermanos.Size = New System.Drawing.Size(170, 23)
        Me.Chk_Sumar_Rotacion_Hermanos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Sumar_Rotacion_Hermanos.TabIndex = 43
        Me.Chk_Sumar_Rotacion_Hermanos.Text = "Sumar Rotación de hermanos"
        '
        'Chk_Traer_Productos_De_Reemplazo
        '
        Me.Chk_Traer_Productos_De_Reemplazo.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_Traer_Productos_De_Reemplazo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Traer_Productos_De_Reemplazo.ForeColor = System.Drawing.Color.Black
        Me.Chk_Traer_Productos_De_Reemplazo.Location = New System.Drawing.Point(4, 3)
        Me.Chk_Traer_Productos_De_Reemplazo.Name = "Chk_Traer_Productos_De_Reemplazo"
        Me.Chk_Traer_Productos_De_Reemplazo.Size = New System.Drawing.Size(170, 23)
        Me.Chk_Traer_Productos_De_Reemplazo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Traer_Productos_De_Reemplazo.TabIndex = 42
        Me.Chk_Traer_Productos_De_Reemplazo.Text = "Traer productos de reemplazo"
        '
        'GroupPanel4
        '
        Me.GroupPanel4.BackColor = System.Drawing.Color.White
        Me.GroupPanel4.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel4.Controls.Add(Me.Rd_Costo_Lista_Proveedor)
        Me.GroupPanel4.Controls.Add(Me.Rd_Costo_Ultimo_Documento_Seleccionado)
        Me.GroupPanel4.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel4.Location = New System.Drawing.Point(542, 6)
        Me.GroupPanel4.Name = "GroupPanel4"
        Me.GroupPanel4.Size = New System.Drawing.Size(202, 100)
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
        Me.GroupPanel4.TabIndex = 40
        Me.GroupPanel4.Text = "Costo del producto"
        '
        'Rd_Costo_Lista_Proveedor
        '
        Me.Rd_Costo_Lista_Proveedor.AutoSize = True
        Me.Rd_Costo_Lista_Proveedor.BackColor = System.Drawing.Color.Transparent
        Me.Rd_Costo_Lista_Proveedor.ForeColor = System.Drawing.Color.Black
        Me.Rd_Costo_Lista_Proveedor.Location = New System.Drawing.Point(6, 46)
        Me.Rd_Costo_Lista_Proveedor.Name = "Rd_Costo_Lista_Proveedor"
        Me.Rd_Costo_Lista_Proveedor.Size = New System.Drawing.Size(171, 17)
        Me.Rd_Costo_Lista_Proveedor.TabIndex = 111
        Me.Rd_Costo_Lista_Proveedor.Text = "Precio de lista del proveedor"
        Me.Rd_Costo_Lista_Proveedor.UseVisualStyleBackColor = False
        '
        'Rd_Costo_Ultimo_Documento_Seleccionado
        '
        Me.Rd_Costo_Ultimo_Documento_Seleccionado.AutoSize = True
        Me.Rd_Costo_Ultimo_Documento_Seleccionado.BackColor = System.Drawing.Color.Transparent
        Me.Rd_Costo_Ultimo_Documento_Seleccionado.Checked = True
        Me.Rd_Costo_Ultimo_Documento_Seleccionado.ForeColor = System.Drawing.Color.Black
        Me.Rd_Costo_Ultimo_Documento_Seleccionado.Location = New System.Drawing.Point(6, 23)
        Me.Rd_Costo_Ultimo_Documento_Seleccionado.Name = "Rd_Costo_Ultimo_Documento_Seleccionado"
        Me.Rd_Costo_Ultimo_Documento_Seleccionado.Size = New System.Drawing.Size(180, 17)
        Me.Rd_Costo_Ultimo_Documento_Seleccionado.TabIndex = 110
        Me.Rd_Costo_Ultimo_Documento_Seleccionado.TabStop = True
        Me.Rd_Costo_Ultimo_Documento_Seleccionado.Text = "Desde la última GRC/OCC/FCC"
        Me.Rd_Costo_Ultimo_Documento_Seleccionado.UseVisualStyleBackColor = False
        '
        'GroupPanel6
        '
        Me.GroupPanel6.BackColor = System.Drawing.Color.White
        Me.GroupPanel6.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel6.Controls.Add(Me.Chk_No_Considera_Con_Stock_Pedido_OCC_NVI)
        Me.GroupPanel6.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel6.Location = New System.Drawing.Point(980, 336)
        Me.GroupPanel6.Name = "GroupPanel6"
        Me.GroupPanel6.Size = New System.Drawing.Size(165, 105)
        '
        '
        '
        Me.GroupPanel6.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.GroupPanel6.Style.BackColorGradientAngle = 90
        Me.GroupPanel6.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.GroupPanel6.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel6.Style.BorderBottomWidth = 1
        Me.GroupPanel6.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupPanel6.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel6.Style.BorderLeftWidth = 1
        Me.GroupPanel6.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel6.Style.BorderRightWidth = 1
        Me.GroupPanel6.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel6.Style.BorderTopWidth = 1
        Me.GroupPanel6.Style.CornerDiameter = 4
        Me.GroupPanel6.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanel6.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanel6.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GroupPanel6.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupPanel6.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanel6.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanel6.TabIndex = 42
        Me.GroupPanel6.Text = "Si tiene OCC"
        '
        'Chk_No_Considera_Con_Stock_Pedido_OCC_NVI
        '
        Me.Chk_No_Considera_Con_Stock_Pedido_OCC_NVI.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_No_Considera_Con_Stock_Pedido_OCC_NVI.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_No_Considera_Con_Stock_Pedido_OCC_NVI.ForeColor = System.Drawing.Color.Black
        Me.Chk_No_Considera_Con_Stock_Pedido_OCC_NVI.Location = New System.Drawing.Point(13, 1)
        Me.Chk_No_Considera_Con_Stock_Pedido_OCC_NVI.Name = "Chk_No_Considera_Con_Stock_Pedido_OCC_NVI"
        Me.Chk_No_Considera_Con_Stock_Pedido_OCC_NVI.Size = New System.Drawing.Size(142, 79)
        Me.Chk_No_Considera_Con_Stock_Pedido_OCC_NVI.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_No_Considera_Con_Stock_Pedido_OCC_NVI.TabIndex = 110
        Me.Chk_No_Considera_Con_Stock_Pedido_OCC_NVI.Text = resources.GetString("Chk_No_Considera_Con_Stock_Pedido_OCC_NVI.Text")
        '
        'GroupPanel7
        '
        Me.GroupPanel7.BackColor = System.Drawing.Color.White
        Me.GroupPanel7.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel7.Controls.Add(Me.Rdb_Ud2_Compra)
        Me.GroupPanel7.Controls.Add(Me.Rdb_Ud1_Compra)
        Me.GroupPanel7.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel7.Location = New System.Drawing.Point(778, 156)
        Me.GroupPanel7.Name = "GroupPanel7"
        Me.GroupPanel7.Size = New System.Drawing.Size(133, 105)
        '
        '
        '
        Me.GroupPanel7.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.GroupPanel7.Style.BackColorGradientAngle = 90
        Me.GroupPanel7.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.GroupPanel7.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel7.Style.BorderBottomWidth = 1
        Me.GroupPanel7.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupPanel7.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel7.Style.BorderLeftWidth = 1
        Me.GroupPanel7.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel7.Style.BorderRightWidth = 1
        Me.GroupPanel7.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel7.Style.BorderTopWidth = 1
        Me.GroupPanel7.Style.CornerDiameter = 4
        Me.GroupPanel7.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanel7.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanel7.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GroupPanel7.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupPanel7.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanel7.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanel7.TabIndex = 43
        Me.GroupPanel7.Text = "Unidades de compra"
        '
        'Input_Dias_a_Abastecer
        '
        Me.Input_Dias_a_Abastecer.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Input_Dias_a_Abastecer.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Input_Dias_a_Abastecer.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Input_Dias_a_Abastecer.ButtonClear.Visible = True
        Me.Input_Dias_a_Abastecer.FocusHighlightEnabled = True
        Me.Input_Dias_a_Abastecer.ForeColor = System.Drawing.Color.Black
        Me.Input_Dias_a_Abastecer.Location = New System.Drawing.Point(81, 10)
        Me.Input_Dias_a_Abastecer.MaxValue = 2000
        Me.Input_Dias_a_Abastecer.MinValue = 1
        Me.Input_Dias_a_Abastecer.Name = "Input_Dias_a_Abastecer"
        Me.Input_Dias_a_Abastecer.ShowUpDown = True
        Me.Input_Dias_a_Abastecer.Size = New System.Drawing.Size(61, 22)
        Me.Input_Dias_a_Abastecer.TabIndex = 108
        Me.Input_Dias_a_Abastecer.Value = 100
        '
        'Input_Tiempo_Reposicion
        '
        Me.Input_Tiempo_Reposicion.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Input_Tiempo_Reposicion.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Input_Tiempo_Reposicion.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Input_Tiempo_Reposicion.ButtonClear.Visible = True
        Me.Input_Tiempo_Reposicion.FocusHighlightEnabled = True
        Me.Input_Tiempo_Reposicion.ForeColor = System.Drawing.Color.Black
        Me.Input_Tiempo_Reposicion.Location = New System.Drawing.Point(81, 38)
        Me.Input_Tiempo_Reposicion.MaxValue = 365
        Me.Input_Tiempo_Reposicion.MinValue = 0
        Me.Input_Tiempo_Reposicion.Name = "Input_Tiempo_Reposicion"
        Me.Input_Tiempo_Reposicion.ShowUpDown = True
        Me.Input_Tiempo_Reposicion.Size = New System.Drawing.Size(61, 22)
        Me.Input_Tiempo_Reposicion.TabIndex = 107
        Me.Input_Tiempo_Reposicion.Value = 7
        '
        'LabelX7
        '
        Me.LabelX7.AutoSize = True
        Me.LabelX7.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX7.ForeColor = System.Drawing.Color.Black
        Me.LabelX7.Location = New System.Drawing.Point(6, 36)
        Me.LabelX7.Name = "LabelX7"
        Me.LabelX7.Size = New System.Drawing.Size(69, 17)
        Me.LabelX7.TabIndex = 106
        Me.LabelX7.Text = "Tiempo Rep. "
        '
        'LabelX6
        '
        Me.LabelX6.AutoSize = True
        Me.LabelX6.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX6.ForeColor = System.Drawing.Color.Black
        Me.LabelX6.Location = New System.Drawing.Point(6, 10)
        Me.LabelX6.Name = "LabelX6"
        Me.LabelX6.Size = New System.Drawing.Size(69, 17)
        Me.LabelX6.TabIndex = 105
        Me.LabelX6.Text = "Comprar para"
        '
        'GroupPanel5
        '
        Me.GroupPanel5.BackColor = System.Drawing.Color.White
        Me.GroupPanel5.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel5.Controls.Add(Me.Cmb_Proyeccion_Tiempo_Reposicion_)
        Me.GroupPanel5.Controls.Add(Me.Cmb_Proyeccion_Metodo_Abastecer_)
        Me.GroupPanel5.Controls.Add(Me.LabelX6)
        Me.GroupPanel5.Controls.Add(Me.Input_Dias_a_Abastecer)
        Me.GroupPanel5.Controls.Add(Me.Input_Tiempo_Reposicion)
        Me.GroupPanel5.Controls.Add(Me.LabelX7)
        Me.GroupPanel5.Controls.Add(Me.Chk_Mostrar_Solo_Stock_Critico)
        Me.GroupPanel5.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel5.Location = New System.Drawing.Point(917, 156)
        Me.GroupPanel5.Name = "GroupPanel5"
        Me.GroupPanel5.Size = New System.Drawing.Size(214, 105)
        '
        '
        '
        Me.GroupPanel5.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.GroupPanel5.Style.BackColorGradientAngle = 90
        Me.GroupPanel5.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.GroupPanel5.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel5.Style.BorderBottomWidth = 1
        Me.GroupPanel5.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupPanel5.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel5.Style.BorderLeftWidth = 1
        Me.GroupPanel5.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel5.Style.BorderRightWidth = 1
        Me.GroupPanel5.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel5.Style.BorderTopWidth = 1
        Me.GroupPanel5.Style.CornerDiameter = 4
        Me.GroupPanel5.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanel5.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanel5.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GroupPanel5.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupPanel5.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanel5.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanel5.TabIndex = 109
        Me.GroupPanel5.Text = "Proveedor seleccionado"
        '
        'Cmb_Proyeccion_Tiempo_Reposicion_
        '
        Me.Cmb_Proyeccion_Tiempo_Reposicion_.DisplayMember = "Text"
        Me.Cmb_Proyeccion_Tiempo_Reposicion_.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.Cmb_Proyeccion_Tiempo_Reposicion_.ForeColor = System.Drawing.Color.Black
        Me.Cmb_Proyeccion_Tiempo_Reposicion_.FormattingEnabled = True
        Me.Cmb_Proyeccion_Tiempo_Reposicion_.ItemHeight = 16
        Me.Cmb_Proyeccion_Tiempo_Reposicion_.Location = New System.Drawing.Point(148, 38)
        Me.Cmb_Proyeccion_Tiempo_Reposicion_.Name = "Cmb_Proyeccion_Tiempo_Reposicion_"
        Me.Cmb_Proyeccion_Tiempo_Reposicion_.Size = New System.Drawing.Size(57, 22)
        Me.Cmb_Proyeccion_Tiempo_Reposicion_.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Cmb_Proyeccion_Tiempo_Reposicion_.TabIndex = 113
        '
        'Cmb_Proyeccion_Metodo_Abastecer_
        '
        Me.Cmb_Proyeccion_Metodo_Abastecer_.DisplayMember = "Text"
        Me.Cmb_Proyeccion_Metodo_Abastecer_.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.Cmb_Proyeccion_Metodo_Abastecer_.ForeColor = System.Drawing.Color.Black
        Me.Cmb_Proyeccion_Metodo_Abastecer_.FormattingEnabled = True
        Me.Cmb_Proyeccion_Metodo_Abastecer_.ItemHeight = 16
        Me.Cmb_Proyeccion_Metodo_Abastecer_.Location = New System.Drawing.Point(148, 10)
        Me.Cmb_Proyeccion_Metodo_Abastecer_.Name = "Cmb_Proyeccion_Metodo_Abastecer_"
        Me.Cmb_Proyeccion_Metodo_Abastecer_.Size = New System.Drawing.Size(57, 22)
        Me.Cmb_Proyeccion_Metodo_Abastecer_.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Cmb_Proyeccion_Metodo_Abastecer_.TabIndex = 112
        '
        'Chk_Agrupar_Productos_De_Reemplazo
        '
        Me.Chk_Agrupar_Productos_De_Reemplazo.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_Agrupar_Productos_De_Reemplazo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Agrupar_Productos_De_Reemplazo.ForeColor = System.Drawing.Color.Black
        Me.Chk_Agrupar_Productos_De_Reemplazo.Location = New System.Drawing.Point(778, 127)
        Me.Chk_Agrupar_Productos_De_Reemplazo.Name = "Chk_Agrupar_Productos_De_Reemplazo"
        Me.Chk_Agrupar_Productos_De_Reemplazo.Size = New System.Drawing.Size(524, 23)
        Me.Chk_Agrupar_Productos_De_Reemplazo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Agrupar_Productos_De_Reemplazo.TabIndex = 110
        Me.Chk_Agrupar_Productos_De_Reemplazo.Text = "Agrupar compras en un solo producto en base a sus reemplazos"
        '
        'GroupPanel8
        '
        Me.GroupPanel8.BackColor = System.Drawing.Color.White
        Me.GroupPanel8.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel8.Controls.Add(Me.Chk_Domingo)
        Me.GroupPanel8.Controls.Add(Me.Chk_Sabado)
        Me.GroupPanel8.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel8.Location = New System.Drawing.Point(771, 267)
        Me.GroupPanel8.Name = "GroupPanel8"
        Me.GroupPanel8.Size = New System.Drawing.Size(177, 69)
        '
        '
        '
        Me.GroupPanel8.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.GroupPanel8.Style.BackColorGradientAngle = 90
        Me.GroupPanel8.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.GroupPanel8.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel8.Style.BorderBottomWidth = 1
        Me.GroupPanel8.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupPanel8.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel8.Style.BorderLeftWidth = 1
        Me.GroupPanel8.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel8.Style.BorderRightWidth = 1
        Me.GroupPanel8.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel8.Style.BorderTopWidth = 1
        Me.GroupPanel8.Style.CornerDiameter = 4
        Me.GroupPanel8.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanel8.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanel8.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GroupPanel8.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupPanel8.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanel8.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanel8.TabIndex = 111
        Me.GroupPanel8.Text = "Calculo rotación"
        '
        'Chk_Domingo
        '
        Me.Chk_Domingo.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_Domingo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Domingo.ForeColor = System.Drawing.Color.Black
        Me.Chk_Domingo.Location = New System.Drawing.Point(4, 23)
        Me.Chk_Domingo.Name = "Chk_Domingo"
        Me.Chk_Domingo.Size = New System.Drawing.Size(170, 23)
        Me.Chk_Domingo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Domingo.TabIndex = 43
        Me.Chk_Domingo.Text = "Considerar domingos"
        '
        'Chk_Sabado
        '
        Me.Chk_Sabado.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_Sabado.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Sabado.ForeColor = System.Drawing.Color.Black
        Me.Chk_Sabado.Location = New System.Drawing.Point(4, 3)
        Me.Chk_Sabado.Name = "Chk_Sabado"
        Me.Chk_Sabado.Size = New System.Drawing.Size(170, 23)
        Me.Chk_Sabado.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Sabado.TabIndex = 42
        Me.Chk_Sabado.Text = "Considerar sábados"
        '
        'Chk_Incluir_Ent_Excluidas
        '
        Me.Chk_Incluir_Ent_Excluidas.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Chk_Incluir_Ent_Excluidas.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Incluir_Ent_Excluidas.ForeColor = System.Drawing.Color.Black
        Me.Chk_Incluir_Ent_Excluidas.Location = New System.Drawing.Point(12, 141)
        Me.Chk_Incluir_Ent_Excluidas.Name = "Chk_Incluir_Ent_Excluidas"
        Me.Chk_Incluir_Ent_Excluidas.Size = New System.Drawing.Size(732, 23)
        Me.Chk_Incluir_Ent_Excluidas.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Incluir_Ent_Excluidas.TabIndex = 112
        Me.Chk_Incluir_Ent_Excluidas.Text = "Incluir los proveedores que estan en entidades excluidas (Uso recomendado para ge" &
    "nerar NVI)"
        '
        'Timer_Ejecucion_Automatica
        '
        Me.Timer_Ejecucion_Automatica.Interval = 2000
        '
        'Frm_08_Asis_Compra_IncorpProveedor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(757, 208)
        Me.Controls.Add(Me.Chk_Incluir_Ent_Excluidas)
        Me.Controls.Add(Me.GroupPanel8)
        Me.Controls.Add(Me.Chk_Agrupar_Productos_De_Reemplazo)
        Me.Controls.Add(Me.GroupPanel5)
        Me.Controls.Add(Me.GroupPanel7)
        Me.Controls.Add(Me.GroupPanel6)
        Me.Controls.Add(Me.GroupPanel4)
        Me.Controls.Add(Me.GroupPanel3)
        Me.Controls.Add(Me.GroupPanel2)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Controls.Add(Me.ProgressBarX1)
        Me.Controls.Add(Me.Bar1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_08_Asis_Compra_IncorpProveedor"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Sistema para agrupar productos con mejor precio vs sus reemplazos"
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel1.ResumeLayout(False)
        Me.GroupPanel2.ResumeLayout(False)
        Me.GroupPanel3.ResumeLayout(False)
        Me.GroupPanel4.ResumeLayout(False)
        Me.GroupPanel4.PerformLayout()
        Me.GroupPanel6.ResumeLayout(False)
        Me.GroupPanel7.ResumeLayout(False)
        Me.GroupPanel7.PerformLayout()
        CType(Me.Input_Dias_a_Abastecer, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Input_Tiempo_Reposicion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel5.ResumeLayout(False)
        Me.GroupPanel5.PerformLayout()
        Me.GroupPanel8.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents BtnProcesarInf As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents ProgressBarX1 As DevComponents.DotNetBar.Controls.ProgressBarX
    Friend WithEvents BtnEntidadesExcluidas As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Chk_Ent_Fisica As DevComponents.DotNetBar.Controls.CheckBoxX
    Public WithEvents Dtp_Fecha_Tope_Proveedores_Automaticos As System.Windows.Forms.DateTimePicker
    Public WithEvents Chk_Mostrar_Solo_Stock_Critico As DevComponents.DotNetBar.Controls.CheckBoxX
    Public WithEvents Rdb_Ud2_Compra As System.Windows.Forms.RadioButton
    Public WithEvents Rdb_Ud1_Compra As System.Windows.Forms.RadioButton
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents GroupPanel2 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents GroupPanel3 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents GroupPanel4 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Chk_Traer_Productos_De_Reemplazo As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents GroupPanel6 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents GroupPanel7 As DevComponents.DotNetBar.Controls.GroupPanel
    Private WithEvents Input_Dias_a_Abastecer As DevComponents.Editors.IntegerInput
    Private WithEvents Input_Tiempo_Reposicion As DevComponents.Editors.IntegerInput
    Friend WithEvents LabelX7 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX6 As DevComponents.DotNetBar.LabelX
    Friend WithEvents GroupPanel5 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Chk_No_Considera_Con_Stock_Pedido_OCC_NVI As DevComponents.DotNetBar.Controls.CheckBoxX
    Public WithEvents Rd_Costo_Lista_Proveedor As System.Windows.Forms.RadioButton
    Public WithEvents Rd_Costo_Ultimo_Documento_Seleccionado As System.Windows.Forms.RadioButton
    Friend WithEvents Chk_Sumar_Rotacion_Hermanos As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Chk_Agrupar_Productos_De_Reemplazo As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Chk_Restar_Stok_Bodega As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Cmb_Documento_Compra As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents GroupPanel8 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Chk_Domingo As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Chk_Sabado As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Cmb_Proyeccion_Tiempo_Reposicion_ As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents Cmb_Proyeccion_Metodo_Abastecer_ As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents Timer_Ejecucion_Automatica As Timer
    Public WithEvents Chk_Incluir_Ent_Excluidas As DevComponents.DotNetBar.Controls.CheckBoxX
End Class
