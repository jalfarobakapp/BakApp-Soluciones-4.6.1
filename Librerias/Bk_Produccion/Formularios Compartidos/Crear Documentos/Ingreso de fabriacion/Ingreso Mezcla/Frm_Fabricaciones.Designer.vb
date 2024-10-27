<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Fabricaciones
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Fabricaciones))
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.Btn_IngresarNuevaFabricacion = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_VerReceta = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Actualizar = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Grabar = New DevComponents.DotNetBar.ButtonItem()
        Me.GroupPanel4 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Menu_Contextual = New DevComponents.DotNetBar.ContextMenuBar()
        Me.Menu_Contextual_01 = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Editar = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Eliminar = New DevComponents.DotNetBar.ButtonItem()
        Me.Menu_contextual_02 = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_VerRecetaCompleta = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_VerRecetaSinProdExcluidos = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_VerRecetaSoloProdExcluidos = New DevComponents.DotNetBar.ButtonItem()
        Me.Grilla = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.GroupPanel7 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Lbl_Fabricar = New DevComponents.DotNetBar.LabelX()
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Lbl_Fabricado = New DevComponents.DotNetBar.LabelX()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.Dtp_Fecha_Ingreso = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_Receta = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Chk_GDI_Consumo = New DevComponents.DotNetBar.CheckBoxItem()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel4.SuspendLayout()
        CType(Me.Menu_Contextual, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel7.SuspendLayout()
        Me.GroupPanel1.SuspendLayout()
        CType(Me.Dtp_Fecha_Ingreso, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_IngresarNuevaFabricacion, Me.Btn_VerReceta, Me.Btn_Actualizar, Me.Btn_Grabar, Me.Chk_GDI_Consumo})
        Me.Bar1.Location = New System.Drawing.Point(0, 488)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(748, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 105
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'Btn_IngresarNuevaFabricacion
        '
        Me.Btn_IngresarNuevaFabricacion.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_IngresarNuevaFabricacion.ForeColor = System.Drawing.Color.Black
        Me.Btn_IngresarNuevaFabricacion.Image = CType(resources.GetObject("Btn_IngresarNuevaFabricacion.Image"), System.Drawing.Image)
        Me.Btn_IngresarNuevaFabricacion.ImageAlt = CType(resources.GetObject("Btn_IngresarNuevaFabricacion.ImageAlt"), System.Drawing.Image)
        Me.Btn_IngresarNuevaFabricacion.Name = "Btn_IngresarNuevaFabricacion"
        Me.Btn_IngresarNuevaFabricacion.Tooltip = "Agregar fabricación (F2)"
        '
        'Btn_VerReceta
        '
        Me.Btn_VerReceta.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_VerReceta.ForeColor = System.Drawing.Color.Black
        Me.Btn_VerReceta.Image = CType(resources.GetObject("Btn_VerReceta.Image"), System.Drawing.Image)
        Me.Btn_VerReceta.ImageAlt = CType(resources.GetObject("Btn_VerReceta.ImageAlt"), System.Drawing.Image)
        Me.Btn_VerReceta.Name = "Btn_VerReceta"
        Me.Btn_VerReceta.Tooltip = "Visualizar los detalles de la receta o nomenclatura (F2)"
        '
        'Btn_Actualizar
        '
        Me.Btn_Actualizar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Actualizar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Actualizar.Image = CType(resources.GetObject("Btn_Actualizar.Image"), System.Drawing.Image)
        Me.Btn_Actualizar.ImageAlt = CType(resources.GetObject("Btn_Actualizar.ImageAlt"), System.Drawing.Image)
        Me.Btn_Actualizar.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.Btn_Actualizar.Name = "Btn_Actualizar"
        Me.Btn_Actualizar.Tooltip = "Refrescar datos (F5)"
        '
        'Btn_Grabar
        '
        Me.Btn_Grabar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Grabar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Grabar.Image = CType(resources.GetObject("Btn_Grabar.Image"), System.Drawing.Image)
        Me.Btn_Grabar.ImageAlt = CType(resources.GetObject("Btn_Grabar.ImageAlt"), System.Drawing.Image)
        Me.Btn_Grabar.Name = "Btn_Grabar"
        Me.Btn_Grabar.Tooltip = "Grabar OT y GRI (F8)"
        '
        'GroupPanel4
        '
        Me.GroupPanel4.BackColor = System.Drawing.Color.White
        Me.GroupPanel4.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel4.Controls.Add(Me.Menu_Contextual)
        Me.GroupPanel4.Controls.Add(Me.Grilla)
        Me.GroupPanel4.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel4.Location = New System.Drawing.Point(12, 41)
        Me.GroupPanel4.Name = "GroupPanel4"
        Me.GroupPanel4.Size = New System.Drawing.Size(727, 372)
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
        Me.GroupPanel4.TabIndex = 104
        Me.GroupPanel4.Text = "Detalle de las mezclas fabricadas"
        '
        'Menu_Contextual
        '
        Me.Menu_Contextual.AntiAlias = True
        Me.Menu_Contextual.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Menu_Contextual.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Menu_Contextual_01, Me.Menu_contextual_02})
        Me.Menu_Contextual.Location = New System.Drawing.Point(130, 41)
        Me.Menu_Contextual.Name = "Menu_Contextual"
        Me.Menu_Contextual.Size = New System.Drawing.Size(329, 25)
        Me.Menu_Contextual.Stretch = True
        Me.Menu_Contextual.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Menu_Contextual.TabIndex = 57
        Me.Menu_Contextual.TabStop = False
        Me.Menu_Contextual.Text = "ContextMenuBar1"
        '
        'Menu_Contextual_01
        '
        Me.Menu_Contextual_01.AutoExpandOnClick = True
        Me.Menu_Contextual_01.Name = "Menu_Contextual_01"
        Me.Menu_Contextual_01.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Editar, Me.Btn_Eliminar})
        Me.Menu_Contextual_01.Text = "Opciones"
        '
        'Btn_Editar
        '
        Me.Btn_Editar.Image = CType(resources.GetObject("Btn_Editar.Image"), System.Drawing.Image)
        Me.Btn_Editar.ImageAlt = CType(resources.GetObject("Btn_Editar.ImageAlt"), System.Drawing.Image)
        Me.Btn_Editar.Name = "Btn_Editar"
        Me.Btn_Editar.Text = "Editar cantidad ingresada"
        '
        'Btn_Eliminar
        '
        Me.Btn_Eliminar.Image = CType(resources.GetObject("Btn_Eliminar.Image"), System.Drawing.Image)
        Me.Btn_Eliminar.ImageAlt = CType(resources.GetObject("Btn_Eliminar.ImageAlt"), System.Drawing.Image)
        Me.Btn_Eliminar.Name = "Btn_Eliminar"
        Me.Btn_Eliminar.Text = "Eliminar fabricación"
        '
        'Menu_contextual_02
        '
        Me.Menu_contextual_02.AutoExpandOnClick = True
        Me.Menu_contextual_02.Name = "Menu_contextual_02"
        Me.Menu_contextual_02.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_VerRecetaCompleta, Me.Btn_VerRecetaSinProdExcluidos, Me.Btn_VerRecetaSoloProdExcluidos})
        Me.Menu_contextual_02.Text = "Opciones"
        '
        'Btn_VerRecetaCompleta
        '
        Me.Btn_VerRecetaCompleta.Image = CType(resources.GetObject("Btn_VerRecetaCompleta.Image"), System.Drawing.Image)
        Me.Btn_VerRecetaCompleta.ImageAlt = CType(resources.GetObject("Btn_VerRecetaCompleta.ImageAlt"), System.Drawing.Image)
        Me.Btn_VerRecetaCompleta.Name = "Btn_VerRecetaCompleta"
        Me.Btn_VerRecetaCompleta.Text = "Ver receta completa"
        '
        'Btn_VerRecetaSinProdExcluidos
        '
        Me.Btn_VerRecetaSinProdExcluidos.Image = CType(resources.GetObject("Btn_VerRecetaSinProdExcluidos.Image"), System.Drawing.Image)
        Me.Btn_VerRecetaSinProdExcluidos.ImageAlt = CType(resources.GetObject("Btn_VerRecetaSinProdExcluidos.ImageAlt"), System.Drawing.Image)
        Me.Btn_VerRecetaSinProdExcluidos.Name = "Btn_VerRecetaSinProdExcluidos"
        Me.Btn_VerRecetaSinProdExcluidos.Text = "Ver la receta solo con productos de marcas NO excluidas."
        '
        'Btn_VerRecetaSoloProdExcluidos
        '
        Me.Btn_VerRecetaSoloProdExcluidos.Image = CType(resources.GetObject("Btn_VerRecetaSoloProdExcluidos.Image"), System.Drawing.Image)
        Me.Btn_VerRecetaSoloProdExcluidos.ImageAlt = CType(resources.GetObject("Btn_VerRecetaSoloProdExcluidos.ImageAlt"), System.Drawing.Image)
        Me.Btn_VerRecetaSoloProdExcluidos.Name = "Btn_VerRecetaSoloProdExcluidos"
        Me.Btn_VerRecetaSoloProdExcluidos.Text = "Ver la receta solo con productos de marcas excluidas."
        '
        'Grilla
        '
        Me.Grilla.AllowUserToAddRows = False
        Me.Grilla.AllowUserToDeleteRows = False
        Me.Grilla.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.Grilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Grilla.DefaultCellStyle = DataGridViewCellStyle5
        Me.Grilla.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grilla.EnableHeadersVisualStyles = False
        Me.Grilla.GridColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.Grilla.Location = New System.Drawing.Point(0, 0)
        Me.Grilla.MultiSelect = False
        Me.Grilla.Name = "Grilla"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.Grilla.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.Grilla.Size = New System.Drawing.Size(721, 349)
        Me.Grilla.TabIndex = 1
        '
        'GroupPanel7
        '
        Me.GroupPanel7.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupPanel7.BackColor = System.Drawing.Color.White
        Me.GroupPanel7.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel7.Controls.Add(Me.Lbl_Fabricar)
        Me.GroupPanel7.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupPanel7.Location = New System.Drawing.Point(424, 424)
        Me.GroupPanel7.Name = "GroupPanel7"
        Me.GroupPanel7.Size = New System.Drawing.Size(153, 58)
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
        Me.GroupPanel7.TabIndex = 167
        Me.GroupPanel7.Text = "Fabricar"
        '
        'Lbl_Fabricar
        '
        Me.Lbl_Fabricar.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_Fabricar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Fabricar.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Fabricar.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Fabricar.Location = New System.Drawing.Point(7, 4)
        Me.Lbl_Fabricar.Name = "Lbl_Fabricar"
        Me.Lbl_Fabricar.Size = New System.Drawing.Size(141, 23)
        Me.Lbl_Fabricar.TabIndex = 34
        Me.Lbl_Fabricar.Text = "0"
        Me.Lbl_Fabricar.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'GroupPanel1
        '
        Me.GroupPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupPanel1.BackColor = System.Drawing.Color.White
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.Lbl_Fabricado)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupPanel1.Location = New System.Drawing.Point(583, 424)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(153, 58)
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
        Me.GroupPanel1.TabIndex = 165
        Me.GroupPanel1.Text = "Fabricado"
        '
        'Lbl_Fabricado
        '
        Me.Lbl_Fabricado.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_Fabricado.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Fabricado.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Fabricado.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Fabricado.Location = New System.Drawing.Point(3, 3)
        Me.Lbl_Fabricado.Name = "Lbl_Fabricado"
        Me.Lbl_Fabricado.Size = New System.Drawing.Size(141, 23)
        Me.Lbl_Fabricado.TabIndex = 34
        Me.Lbl_Fabricado.Text = "0"
        Me.Lbl_Fabricado.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'LabelX4
        '
        Me.LabelX4.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX4.ForeColor = System.Drawing.Color.Black
        Me.LabelX4.Location = New System.Drawing.Point(12, 419)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(208, 23)
        Me.LabelX4.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.LabelX4.TabIndex = 169
        Me.LabelX4.Text = "FECHA INGRESO FABRICACION"
        '
        'Dtp_Fecha_Ingreso
        '
        Me.Dtp_Fecha_Ingreso.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Dtp_Fecha_Ingreso.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Dtp_Fecha_Ingreso.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Ingreso.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.Dtp_Fecha_Ingreso.ButtonDropDown.Visible = True
        Me.Dtp_Fecha_Ingreso.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Dtp_Fecha_Ingreso.ForeColor = System.Drawing.Color.Black
        Me.Dtp_Fecha_Ingreso.IsPopupCalendarOpen = False
        Me.Dtp_Fecha_Ingreso.Location = New System.Drawing.Point(217, 419)
        '
        '
        '
        Me.Dtp_Fecha_Ingreso.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_Fecha_Ingreso.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Ingreso.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.Dtp_Fecha_Ingreso.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.Dtp_Fecha_Ingreso.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.Dtp_Fecha_Ingreso.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_Fecha_Ingreso.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.Dtp_Fecha_Ingreso.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Dtp_Fecha_Ingreso.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.Dtp_Fecha_Ingreso.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.Dtp_Fecha_Ingreso.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Ingreso.MonthCalendar.DisplayMonth = New Date(2018, 1, 1, 0, 0, 0, 0)
        Me.Dtp_Fecha_Ingreso.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday
        Me.Dtp_Fecha_Ingreso.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.Dtp_Fecha_Ingreso.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_Fecha_Ingreso.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Dtp_Fecha_Ingreso.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_Fecha_Ingreso.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Dtp_Fecha_Ingreso.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Ingreso.MonthCalendar.TodayButtonVisible = True
        Me.Dtp_Fecha_Ingreso.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.Dtp_Fecha_Ingreso.Name = "Dtp_Fecha_Ingreso"
        Me.Dtp_Fecha_Ingreso.Size = New System.Drawing.Size(96, 25)
        Me.Dtp_Fecha_Ingreso.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Dtp_Fecha_Ingreso.TabIndex = 168
        Me.Dtp_Fecha_Ingreso.TabStop = False
        Me.Dtp_Fecha_Ingreso.Value = New Date(2018, 1, 30, 12, 16, 22, 0)
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.ForeColor = System.Drawing.Color.Black
        Me.LabelX1.Location = New System.Drawing.Point(12, 12)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(48, 23)
        Me.LabelX1.TabIndex = 170
        Me.LabelX1.Text = "RECETA: "
        '
        'Txt_Receta
        '
        Me.Txt_Receta.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Receta.Border.Class = "TextBoxBorder"
        Me.Txt_Receta.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Receta.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_Receta.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Receta.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Receta.ForeColor = System.Drawing.Color.Black
        Me.Txt_Receta.Location = New System.Drawing.Point(66, 13)
        Me.Txt_Receta.Name = "Txt_Receta"
        Me.Txt_Receta.PreventEnterBeep = True
        Me.Txt_Receta.ReadOnly = True
        Me.Txt_Receta.Size = New System.Drawing.Size(673, 22)
        Me.Txt_Receta.TabIndex = 171
        Me.Txt_Receta.Text = "DSDSD SDS DSD - SD SDSDFSAFSFSDF A DSAF SDF SDF SDFSD"
        '
        'Chk_GDI_Consumo
        '
        Me.Chk_GDI_Consumo.CheckBoxImageChecked = CType(resources.GetObject("Chk_GDI_Consumo.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_GDI_Consumo.Checked = True
        Me.Chk_GDI_Consumo.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Chk_GDI_Consumo.Name = "Chk_GDI_Consumo"
        Me.Chk_GDI_Consumo.Text = "Crear GDI de consumo"
        '
        'Frm_Fabricaciones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(748, 529)
        Me.Controls.Add(Me.Txt_Receta)
        Me.Controls.Add(Me.LabelX1)
        Me.Controls.Add(Me.Dtp_Fecha_Ingreso)
        Me.Controls.Add(Me.GroupPanel7)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Controls.Add(Me.Bar1)
        Me.Controls.Add(Me.GroupPanel4)
        Me.Controls.Add(Me.LabelX4)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Fabricaciones"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FORMULARIO PARA LA CREACION DE MEZCLAS"
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel4.ResumeLayout(False)
        CType(Me.Menu_Contextual, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel7.ResumeLayout(False)
        Me.GroupPanel1.ResumeLayout(False)
        CType(Me.Dtp_Fecha_Ingreso, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Public WithEvents Btn_IngresarNuevaFabricacion As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_Actualizar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents GroupPanel4 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Grilla As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents GroupPanel7 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Lbl_Fabricar As DevComponents.DotNetBar.LabelX
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Lbl_Fabricado As DevComponents.DotNetBar.LabelX
    Friend WithEvents Menu_Contextual As DevComponents.DotNetBar.ContextMenuBar
    Friend WithEvents Menu_Contextual_01 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Editar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Eliminar As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_Grabar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Dtp_Fecha_Ingreso As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Txt_Receta As DevComponents.DotNetBar.Controls.TextBoxX
    Public WithEvents Btn_VerReceta As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Menu_contextual_02 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_VerRecetaCompleta As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_VerRecetaSinProdExcluidos As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_VerRecetaSoloProdExcluidos As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Chk_GDI_Consumo As DevComponents.DotNetBar.CheckBoxItem
End Class
