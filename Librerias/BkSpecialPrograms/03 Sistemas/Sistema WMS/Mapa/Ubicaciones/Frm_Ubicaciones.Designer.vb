<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Ubicaciones
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
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Ubicaciones))
        Me.Grupo_Estante = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.ContextMenuBar1 = New DevComponents.DotNetBar.ContextMenuBar()
        Me.Menu_Contextual_Columna = New DevComponents.DotNetBar.ButtonItem()
        Me.LabelItem4 = New DevComponents.DotNetBar.LabelItem()
        Me.Btn_Mnu_Eliminar_Columnas = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Mnu_Cambiar_Nombre_Columna = New DevComponents.DotNetBar.ButtonItem()
        Me.Menu_Contextual_Fila = New DevComponents.DotNetBar.ButtonItem()
        Me.Lbl_Sector = New DevComponents.DotNetBar.LabelItem()
        Me.Btn_Mnu_Eliminar_Fila = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Mnu_Objeto_Propiedades = New DevComponents.DotNetBar.ButtonItem()
        Me.Menu_Contextual_Ubicacion = New DevComponents.DotNetBar.ButtonItem()
        Me.LabelItem1 = New DevComponents.DotNetBar.LabelItem()
        Me.Btn_Mnu_Ver_Productos_Ubicacion = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Mnu_Dejar_Ubacion_Sub_Sector = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Mnu_Bloquear_Ubicacion = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Mnu_Desbloquear_Ubicacion = New DevComponents.DotNetBar.ButtonItem()
        Me.Menu_Contextual_Sub_Sector = New DevComponents.DotNetBar.ButtonItem()
        Me.LabelItem3 = New DevComponents.DotNetBar.LabelItem()
        Me.Btn_Mnu_Ver_Sub_Sector = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Mnu_Quitar_Sub_Sector = New DevComponents.DotNetBar.ButtonItem()
        Me.Grilla = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.Bar2 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Grabar = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Agregar_Nivel = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Agregar_Columna = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Imprir = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Ver_Mapa = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Imprimir_Toma_Inventario = New DevComponents.DotNetBar.ButtonItem()
        Me.GroupPanel2 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.TxtDescripcion_Ubic = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.TxtCodigo_Ubic = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.Chk_Modificar_Sector = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Lbl_Estatus_Ubicacion = New DevComponents.DotNetBar.LabelX()
        Me.Btn_Ver = New DevComponents.DotNetBar.ButtonX()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Panel_Ayuda = New DevComponents.DotNetBar.ExpandablePanel()
        Me.LabelX6 = New DevComponents.DotNetBar.LabelX()
        Me.Btn_Mnu_Sector_Cambiar_Codigo = New DevComponents.DotNetBar.ButtonItem()
        Me.Grupo_Estante.SuspendLayout()
        CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel2.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel_Ayuda.SuspendLayout()
        Me.SuspendLayout()
        '
        'Grupo_Estante
        '
        Me.Grupo_Estante.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Grupo_Estante.BackColor = System.Drawing.Color.White
        Me.Grupo_Estante.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Grupo_Estante.Controls.Add(Me.ContextMenuBar1)
        Me.Grupo_Estante.Controls.Add(Me.Grilla)
        Me.Grupo_Estante.DisabledBackColor = System.Drawing.Color.Empty
        Me.Grupo_Estante.Location = New System.Drawing.Point(12, 94)
        Me.Grupo_Estante.Name = "Grupo_Estante"
        Me.Grupo_Estante.Size = New System.Drawing.Size(760, 349)
        '
        '
        '
        Me.Grupo_Estante.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Grupo_Estante.Style.BackColorGradientAngle = 90
        Me.Grupo_Estante.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Grupo_Estante.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Estante.Style.BorderBottomWidth = 1
        Me.Grupo_Estante.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.Grupo_Estante.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Estante.Style.BorderLeftWidth = 1
        Me.Grupo_Estante.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Estante.Style.BorderRightWidth = 1
        Me.Grupo_Estante.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Estante.Style.BorderTopWidth = 1
        Me.Grupo_Estante.Style.CornerDiameter = 4
        Me.Grupo_Estante.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Grupo_Estante.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.Grupo_Estante.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.Grupo_Estante.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.Grupo_Estante.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.Grupo_Estante.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Grupo_Estante.TabIndex = 0
        Me.Grupo_Estante.Text = "Ubicaciones"
        '
        'ContextMenuBar1
        '
        Me.ContextMenuBar1.AntiAlias = True
        Me.ContextMenuBar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ContextMenuBar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Menu_Contextual_Columna, Me.Menu_Contextual_Fila, Me.Menu_Contextual_Ubicacion, Me.Menu_Contextual_Sub_Sector})
        Me.ContextMenuBar1.Location = New System.Drawing.Point(61, 118)
        Me.ContextMenuBar1.Name = "ContextMenuBar1"
        Me.ContextMenuBar1.Size = New System.Drawing.Size(686, 25)
        Me.ContextMenuBar1.Stretch = True
        Me.ContextMenuBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ContextMenuBar1.TabIndex = 48
        Me.ContextMenuBar1.TabStop = False
        Me.ContextMenuBar1.Text = "ContextMenuBar1"
        '
        'Menu_Contextual_Columna
        '
        Me.Menu_Contextual_Columna.AutoExpandOnClick = True
        Me.Menu_Contextual_Columna.Name = "Menu_Contextual_Columna"
        Me.Menu_Contextual_Columna.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItem4, Me.Btn_Mnu_Eliminar_Columnas, Me.Btn_Mnu_Cambiar_Nombre_Columna})
        Me.Menu_Contextual_Columna.Text = "Opciones encabezado columnas"
        '
        'LabelItem4
        '
        Me.LabelItem4.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.LabelItem4.BorderSide = DevComponents.DotNetBar.eBorderSide.Bottom
        Me.LabelItem4.BorderType = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.LabelItem4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(21, Byte), Integer), CType(CType(110, Byte), Integer))
        Me.LabelItem4.Name = "LabelItem4"
        Me.LabelItem4.PaddingBottom = 1
        Me.LabelItem4.PaddingLeft = 10
        Me.LabelItem4.PaddingTop = 1
        Me.LabelItem4.SingleLineColor = System.Drawing.Color.FromArgb(CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer))
        Me.LabelItem4.Text = "Opciones para la columna"
        '
        'Btn_Mnu_Eliminar_Columnas
        '
        Me.Btn_Mnu_Eliminar_Columnas.Image = CType(resources.GetObject("Btn_Mnu_Eliminar_Columnas.Image"), System.Drawing.Image)
        Me.Btn_Mnu_Eliminar_Columnas.Name = "Btn_Mnu_Eliminar_Columnas"
        Me.Btn_Mnu_Eliminar_Columnas.Text = "Eliminar columnas"
        '
        'Btn_Mnu_Cambiar_Nombre_Columna
        '
        Me.Btn_Mnu_Cambiar_Nombre_Columna.Image = CType(resources.GetObject("Btn_Mnu_Cambiar_Nombre_Columna.Image"), System.Drawing.Image)
        Me.Btn_Mnu_Cambiar_Nombre_Columna.Name = "Btn_Mnu_Cambiar_Nombre_Columna"
        Me.Btn_Mnu_Cambiar_Nombre_Columna.Text = "Cambiar nombre de la columna"
        '
        'Menu_Contextual_Fila
        '
        Me.Menu_Contextual_Fila.AutoExpandOnClick = True
        Me.Menu_Contextual_Fila.Name = "Menu_Contextual_Fila"
        Me.Menu_Contextual_Fila.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Lbl_Sector, Me.Btn_Mnu_Eliminar_Fila, Me.Btn_Mnu_Objeto_Propiedades})
        Me.Menu_Contextual_Fila.Text = "Opciones encabezado filas"
        '
        'Lbl_Sector
        '
        Me.Lbl_Sector.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.Lbl_Sector.BorderSide = DevComponents.DotNetBar.eBorderSide.Bottom
        Me.Lbl_Sector.BorderType = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.Lbl_Sector.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(21, Byte), Integer), CType(CType(110, Byte), Integer))
        Me.Lbl_Sector.Name = "Lbl_Sector"
        Me.Lbl_Sector.PaddingBottom = 1
        Me.Lbl_Sector.PaddingLeft = 10
        Me.Lbl_Sector.PaddingTop = 1
        Me.Lbl_Sector.SingleLineColor = System.Drawing.Color.FromArgb(CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer))
        Me.Lbl_Sector.Text = "Opciones para la fila"
        '
        'Btn_Mnu_Eliminar_Fila
        '
        Me.Btn_Mnu_Eliminar_Fila.Image = CType(resources.GetObject("Btn_Mnu_Eliminar_Fila.Image"), System.Drawing.Image)
        Me.Btn_Mnu_Eliminar_Fila.Name = "Btn_Mnu_Eliminar_Fila"
        Me.Btn_Mnu_Eliminar_Fila.Text = "Eliminar fila (nivel)"
        '
        'Btn_Mnu_Objeto_Propiedades
        '
        Me.Btn_Mnu_Objeto_Propiedades.Image = CType(resources.GetObject("Btn_Mnu_Objeto_Propiedades.Image"), System.Drawing.Image)
        Me.Btn_Mnu_Objeto_Propiedades.Name = "Btn_Mnu_Objeto_Propiedades"
        Me.Btn_Mnu_Objeto_Propiedades.Text = "Cambiar nombre de la fila"
        '
        'Menu_Contextual_Ubicacion
        '
        Me.Menu_Contextual_Ubicacion.AutoExpandOnClick = True
        Me.Menu_Contextual_Ubicacion.Name = "Menu_Contextual_Ubicacion"
        Me.Menu_Contextual_Ubicacion.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItem1, Me.Btn_Mnu_Ver_Productos_Ubicacion, Me.Btn_Mnu_Dejar_Ubacion_Sub_Sector, Me.Btn_Mnu_Bloquear_Ubicacion, Me.Btn_Mnu_Desbloquear_Ubicacion})
        Me.Menu_Contextual_Ubicacion.Text = "Opciones Ubicacion"
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
        Me.LabelItem1.Text = "Opciones de la ubicación"
        '
        'Btn_Mnu_Ver_Productos_Ubicacion
        '
        Me.Btn_Mnu_Ver_Productos_Ubicacion.Image = CType(resources.GetObject("Btn_Mnu_Ver_Productos_Ubicacion.Image"), System.Drawing.Image)
        Me.Btn_Mnu_Ver_Productos_Ubicacion.Name = "Btn_Mnu_Ver_Productos_Ubicacion"
        Me.Btn_Mnu_Ver_Productos_Ubicacion.Text = "Ver productos en la ubicación"
        '
        'Btn_Mnu_Dejar_Ubacion_Sub_Sector
        '
        Me.Btn_Mnu_Dejar_Ubacion_Sub_Sector.Image = CType(resources.GetObject("Btn_Mnu_Dejar_Ubacion_Sub_Sector.Image"), System.Drawing.Image)
        Me.Btn_Mnu_Dejar_Ubacion_Sub_Sector.Name = "Btn_Mnu_Dejar_Ubacion_Sub_Sector"
        Me.Btn_Mnu_Dejar_Ubacion_Sub_Sector.Text = "Dejar ubicación como <b>Sub-Sector</b>"
        '
        'Btn_Mnu_Bloquear_Ubicacion
        '
        Me.Btn_Mnu_Bloquear_Ubicacion.ForeColor = System.Drawing.Color.Red
        Me.Btn_Mnu_Bloquear_Ubicacion.Image = CType(resources.GetObject("Btn_Mnu_Bloquear_Ubicacion.Image"), System.Drawing.Image)
        Me.Btn_Mnu_Bloquear_Ubicacion.Name = "Btn_Mnu_Bloquear_Ubicacion"
        Me.Btn_Mnu_Bloquear_Ubicacion.Text = "Bloquear ubicación "
        '
        'Btn_Mnu_Desbloquear_Ubicacion
        '
        Me.Btn_Mnu_Desbloquear_Ubicacion.ForeColor = System.Drawing.Color.Green
        Me.Btn_Mnu_Desbloquear_Ubicacion.Image = CType(resources.GetObject("Btn_Mnu_Desbloquear_Ubicacion.Image"), System.Drawing.Image)
        Me.Btn_Mnu_Desbloquear_Ubicacion.Name = "Btn_Mnu_Desbloquear_Ubicacion"
        Me.Btn_Mnu_Desbloquear_Ubicacion.Text = "Desbloquear ubicación "
        '
        'Menu_Contextual_Sub_Sector
        '
        Me.Menu_Contextual_Sub_Sector.AutoExpandOnClick = True
        Me.Menu_Contextual_Sub_Sector.Name = "Menu_Contextual_Sub_Sector"
        Me.Menu_Contextual_Sub_Sector.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItem3, Me.Btn_Mnu_Sector_Cambiar_Codigo, Me.Btn_Mnu_Ver_Sub_Sector, Me.Btn_Mnu_Quitar_Sub_Sector})
        Me.Menu_Contextual_Sub_Sector.Text = "Opciones Sub-sector"
        '
        'LabelItem3
        '
        Me.LabelItem3.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.LabelItem3.BorderSide = DevComponents.DotNetBar.eBorderSide.Bottom
        Me.LabelItem3.BorderType = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.LabelItem3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(21, Byte), Integer), CType(CType(110, Byte), Integer))
        Me.LabelItem3.Name = "LabelItem3"
        Me.LabelItem3.PaddingBottom = 1
        Me.LabelItem3.PaddingLeft = 10
        Me.LabelItem3.PaddingTop = 1
        Me.LabelItem3.SingleLineColor = System.Drawing.Color.FromArgb(CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer))
        Me.LabelItem3.Text = "Opciones Sub-Sector"
        '
        'Btn_Mnu_Ver_Sub_Sector
        '
        Me.Btn_Mnu_Ver_Sub_Sector.Image = CType(resources.GetObject("Btn_Mnu_Ver_Sub_Sector.Image"), System.Drawing.Image)
        Me.Btn_Mnu_Ver_Sub_Sector.Name = "Btn_Mnu_Ver_Sub_Sector"
        Me.Btn_Mnu_Ver_Sub_Sector.Text = "Ver Sub-Sector"
        '
        'Btn_Mnu_Quitar_Sub_Sector
        '
        Me.Btn_Mnu_Quitar_Sub_Sector.Image = CType(resources.GetObject("Btn_Mnu_Quitar_Sub_Sector.Image"), System.Drawing.Image)
        Me.Btn_Mnu_Quitar_Sub_Sector.Name = "Btn_Mnu_Quitar_Sub_Sector"
        Me.Btn_Mnu_Quitar_Sub_Sector.Text = "Dejar como ubicación (Quitar categoría de Sub-Sector)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'Grilla
        '
        Me.Grilla.AllowUserToAddRows = False
        Me.Grilla.AllowUserToDeleteRows = False
        Me.Grilla.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
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
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
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
        Me.Grilla.Name = "Grilla"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.Grilla.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.ColumnHeaderSelect
        Me.Grilla.Size = New System.Drawing.Size(754, 326)
        Me.Grilla.TabIndex = 11
        '
        'Bar2
        '
        Me.Bar2.AntiAlias = True
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Grabar, Me.Btn_Agregar_Nivel, Me.Btn_Agregar_Columna, Me.Btn_Imprir, Me.Btn_Ver_Mapa, Me.Btn_Imprimir_Toma_Inventario})
        Me.Bar2.Location = New System.Drawing.Point(0, 520)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(784, 41)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Bar2.TabIndex = 44
        Me.Bar2.TabStop = False
        Me.Bar2.Text = "Bar2"
        '
        'Btn_Grabar
        '
        Me.Btn_Grabar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Grabar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Grabar.Image = CType(resources.GetObject("Btn_Grabar.Image"), System.Drawing.Image)
        Me.Btn_Grabar.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.Btn_Grabar.Name = "Btn_Grabar"
        Me.Btn_Grabar.Tooltip = "Agregar sub-clasificación"
        '
        'Btn_Agregar_Nivel
        '
        Me.Btn_Agregar_Nivel.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Agregar_Nivel.ForeColor = System.Drawing.Color.Black
        Me.Btn_Agregar_Nivel.Image = CType(resources.GetObject("Btn_Agregar_Nivel.Image"), System.Drawing.Image)
        Me.Btn_Agregar_Nivel.Name = "Btn_Agregar_Nivel"
        Me.Btn_Agregar_Nivel.Tooltip = "Agregar Fila (Nivel)"
        '
        'Btn_Agregar_Columna
        '
        Me.Btn_Agregar_Columna.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Agregar_Columna.ForeColor = System.Drawing.Color.Black
        Me.Btn_Agregar_Columna.Image = CType(resources.GetObject("Btn_Agregar_Columna.Image"), System.Drawing.Image)
        Me.Btn_Agregar_Columna.Name = "Btn_Agregar_Columna"
        Me.Btn_Agregar_Columna.Tooltip = "Agregar Columna"
        '
        'Btn_Imprir
        '
        Me.Btn_Imprir.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Imprir.ForeColor = System.Drawing.Color.Black
        Me.Btn_Imprir.Image = CType(resources.GetObject("Btn_Imprir.Image"), System.Drawing.Image)
        Me.Btn_Imprir.Name = "Btn_Imprir"
        Me.Btn_Imprir.Tooltip = "Imprimir Ubicaciones (Impresora Barras)"
        '
        'Btn_Ver_Mapa
        '
        Me.Btn_Ver_Mapa.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Ver_Mapa.ForeColor = System.Drawing.Color.Black
        Me.Btn_Ver_Mapa.Image = CType(resources.GetObject("Btn_Ver_Mapa.Image"), System.Drawing.Image)
        Me.Btn_Ver_Mapa.Name = "Btn_Ver_Mapa"
        Me.Btn_Ver_Mapa.Text = "Ver la ubicación en el mapa"
        '
        'Btn_Imprimir_Toma_Inventario
        '
        Me.Btn_Imprimir_Toma_Inventario.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Imprimir_Toma_Inventario.ForeColor = System.Drawing.Color.Black
        Me.Btn_Imprimir_Toma_Inventario.Image = CType(resources.GetObject("Btn_Imprimir_Toma_Inventario.Image"), System.Drawing.Image)
        Me.Btn_Imprimir_Toma_Inventario.Name = "Btn_Imprimir_Toma_Inventario"
        Me.Btn_Imprimir_Toma_Inventario.Text = "Imprimir toma inventario"
        Me.Btn_Imprimir_Toma_Inventario.Tooltip = "Imprimir listado de productos para toma de inventario"
        '
        'GroupPanel2
        '
        Me.GroupPanel2.BackColor = System.Drawing.Color.White
        Me.GroupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel2.Controls.Add(Me.TxtDescripcion_Ubic)
        Me.GroupPanel2.Controls.Add(Me.TxtCodigo_Ubic)
        Me.GroupPanel2.Controls.Add(Me.LabelX3)
        Me.GroupPanel2.Controls.Add(Me.LabelX4)
        Me.GroupPanel2.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel2.Location = New System.Drawing.Point(12, 1)
        Me.GroupPanel2.Name = "GroupPanel2"
        Me.GroupPanel2.Size = New System.Drawing.Size(760, 58)
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
        Me.GroupPanel2.TabIndex = 47
        '
        'TxtDescripcion_Ubic
        '
        Me.TxtDescripcion_Ubic.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TxtDescripcion_Ubic.Border.Class = "TextBoxBorder"
        Me.TxtDescripcion_Ubic.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtDescripcion_Ubic.DisabledBackColor = System.Drawing.Color.White
        Me.TxtDescripcion_Ubic.ForeColor = System.Drawing.Color.Black
        Me.TxtDescripcion_Ubic.Location = New System.Drawing.Point(127, 24)
        Me.TxtDescripcion_Ubic.Name = "TxtDescripcion_Ubic"
        Me.TxtDescripcion_Ubic.PreventEnterBeep = True
        Me.TxtDescripcion_Ubic.Size = New System.Drawing.Size(624, 22)
        Me.TxtDescripcion_Ubic.TabIndex = 5
        '
        'TxtCodigo_Ubic
        '
        Me.TxtCodigo_Ubic.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TxtCodigo_Ubic.Border.Class = "TextBoxBorder"
        Me.TxtCodigo_Ubic.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtCodigo_Ubic.DisabledBackColor = System.Drawing.Color.White
        Me.TxtCodigo_Ubic.ForeColor = System.Drawing.Color.Black
        Me.TxtCodigo_Ubic.Location = New System.Drawing.Point(3, 24)
        Me.TxtCodigo_Ubic.Name = "TxtCodigo_Ubic"
        Me.TxtCodigo_Ubic.PreventEnterBeep = True
        Me.TxtCodigo_Ubic.Size = New System.Drawing.Size(118, 22)
        Me.TxtCodigo_Ubic.TabIndex = 4
        '
        'LabelX3
        '
        Me.LabelX3.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.ForeColor = System.Drawing.Color.Black
        Me.LabelX3.Location = New System.Drawing.Point(127, 3)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(171, 23)
        Me.LabelX3.TabIndex = 3
        Me.LabelX3.Text = "Nombre del sector"
        '
        'LabelX4
        '
        Me.LabelX4.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.ForeColor = System.Drawing.Color.Black
        Me.LabelX4.Location = New System.Drawing.Point(3, 3)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(75, 23)
        Me.LabelX4.TabIndex = 0
        Me.LabelX4.Text = "Código"
        '
        'Chk_Modificar_Sector
        '
        Me.Chk_Modificar_Sector.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Chk_Modificar_Sector.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Chk_Modificar_Sector.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Modificar_Sector.ForeColor = System.Drawing.Color.Black
        Me.Chk_Modificar_Sector.Location = New System.Drawing.Point(12, 478)
        Me.Chk_Modificar_Sector.Name = "Chk_Modificar_Sector"
        Me.Chk_Modificar_Sector.Size = New System.Drawing.Size(100, 23)
        Me.Chk_Modificar_Sector.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Modificar_Sector.TabIndex = 48
        Me.Chk_Modificar_Sector.Text = "Modificar sector"
        '
        'Lbl_Estatus_Ubicacion
        '
        Me.Lbl_Estatus_Ubicacion.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Lbl_Estatus_Ubicacion.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Lbl_Estatus_Ubicacion.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Estatus_Ubicacion.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Estatus_Ubicacion.Location = New System.Drawing.Point(125, 449)
        Me.Lbl_Estatus_Ubicacion.Name = "Lbl_Estatus_Ubicacion"
        Me.Lbl_Estatus_Ubicacion.Size = New System.Drawing.Size(657, 23)
        Me.Lbl_Estatus_Ubicacion.TabIndex = 49
        Me.Lbl_Estatus_Ubicacion.Text = "Ubicación: <b>UBICACION</b>, Productos asociados: <b>00</b>"
        '
        'Btn_Ver
        '
        Me.Btn_Ver.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Ver.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Btn_Ver.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Ver.Image = CType(resources.GetObject("Btn_Ver.Image"), System.Drawing.Image)
        Me.Btn_Ver.Location = New System.Drawing.Point(12, 449)
        Me.Btn_Ver.Name = "Btn_Ver"
        Me.Btn_Ver.Size = New System.Drawing.Size(107, 23)
        Me.Btn_Ver.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Ver.TabIndex = 50
        Me.Btn_Ver.Text = "Ver productos"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.TableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.[Single]
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.LabelX1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelX2, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelX5, 0, 1)
        Me.TableLayoutPanel1.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(15, 103)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(83, 68)
        Me.TableLayoutPanel1.TabIndex = 96
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.ForeColor = System.Drawing.Color.Black
        Me.LabelX1.Location = New System.Drawing.Point(4, 4)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(75, 15)
        Me.LabelX1.TabIndex = 91
        Me.LabelX1.Text = "Columnas"
        Me.LabelX1.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'LabelX2
        '
        Me.LabelX2.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.ForeColor = System.Drawing.Color.Black
        Me.LabelX2.Location = New System.Drawing.Point(4, 48)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(75, 16)
        Me.LabelX2.TabIndex = 93
        Me.LabelX2.Text = "Ubicacion"
        Me.LabelX2.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'LabelX5
        '
        Me.LabelX5.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX5.ForeColor = System.Drawing.Color.Black
        Me.LabelX5.Location = New System.Drawing.Point(4, 26)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.Size = New System.Drawing.Size(75, 15)
        Me.LabelX5.TabIndex = 92
        Me.LabelX5.Text = "Niveles (Filas)"
        Me.LabelX5.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.White
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox1.ForeColor = System.Drawing.Color.Black
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(100, 34)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(192, 174)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 95
        Me.PictureBox1.TabStop = False
        '
        'Panel_Ayuda
        '
        Me.Panel_Ayuda.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel_Ayuda.CanvasColor = System.Drawing.SystemColors.Control
        Me.Panel_Ayuda.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Panel_Ayuda.Controls.Add(Me.LabelX6)
        Me.Panel_Ayuda.Controls.Add(Me.TableLayoutPanel1)
        Me.Panel_Ayuda.Controls.Add(Me.PictureBox1)
        Me.Panel_Ayuda.DisabledBackColor = System.Drawing.Color.Empty
        Me.Panel_Ayuda.Expanded = False
        Me.Panel_Ayuda.ExpandedBounds = New System.Drawing.Rectangle(470, 65, 312, 261)
        Me.Panel_Ayuda.HideControlsWhenCollapsed = True
        Me.Panel_Ayuda.Location = New System.Drawing.Point(460, 65)
        Me.Panel_Ayuda.Name = "Panel_Ayuda"
        Me.Panel_Ayuda.Size = New System.Drawing.Size(312, 26)
        Me.Panel_Ayuda.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.Panel_Ayuda.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Panel_Ayuda.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.Panel_Ayuda.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
        Me.Panel_Ayuda.Style.GradientAngle = 90
        Me.Panel_Ayuda.TabIndex = 97
        Me.Panel_Ayuda.TitleStyle.Alignment = System.Drawing.StringAlignment.Center
        Me.Panel_Ayuda.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Panel_Ayuda.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner
        Me.Panel_Ayuda.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.Panel_Ayuda.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.Panel_Ayuda.TitleStyle.GradientAngle = 90
        Me.Panel_Ayuda.TitleText = "Grafica de Ayuda"
        '
        'LabelX6
        '
        Me.LabelX6.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX6.ForeColor = System.Drawing.Color.Black
        Me.LabelX6.Location = New System.Drawing.Point(15, 218)
        Me.LabelX6.Name = "LabelX6"
        Me.LabelX6.Size = New System.Drawing.Size(277, 38)
        Me.LabelX6.TabIndex = 97
        Me.LabelX6.Text = "<b>Nota:</b> Para dejar una celda bloqueada debe poner ""<b><font color=""#ED1C24"">" &
    "...</font></b>"" (3 puntos) esto dejara la ceda inabilitada."
        '
        'Btn_Mnu_Sector_Cambiar_Codigo
        '
        Me.Btn_Mnu_Sector_Cambiar_Codigo.Image = CType(resources.GetObject("Btn_Mnu_Sector_Cambiar_Codigo.Image"), System.Drawing.Image)
        Me.Btn_Mnu_Sector_Cambiar_Codigo.Name = "Btn_Mnu_Sector_Cambiar_Codigo"
        Me.Btn_Mnu_Sector_Cambiar_Codigo.Text = "Cambiar código"
        '
        'Frm_Ubicaciones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 561)
        Me.Controls.Add(Me.Panel_Ayuda)
        Me.Controls.Add(Me.GroupPanel2)
        Me.Controls.Add(Me.Bar2)
        Me.Controls.Add(Me.Chk_Modificar_Sector)
        Me.Controls.Add(Me.Grupo_Estante)
        Me.Controls.Add(Me.Btn_Ver)
        Me.Controls.Add(Me.Lbl_Estatus_Ubicacion)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximumSize = New System.Drawing.Size(1260, 600)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(800, 511)
        Me.Name = "Frm_Ubicaciones"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MetroForm"
        Me.Grupo_Estante.ResumeLayout(False)
        CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel2.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel_Ayuda.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Grupo_Estante As DevComponents.DotNetBar.Controls.GroupPanel
    Public WithEvents Grilla As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Public WithEvents Btn_Grabar As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_Agregar_Columna As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_Agregar_Nivel As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents GroupPanel2 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Public WithEvents TxtDescripcion_Ubic As DevComponents.DotNetBar.Controls.TextBoxX
    Public WithEvents TxtCodigo_Ubic As DevComponents.DotNetBar.Controls.TextBoxX
    Public WithEvents Btn_Imprir As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Chk_Modificar_Sector As DevComponents.DotNetBar.Controls.CheckBoxX
    Public WithEvents Btn_Ver_Mapa As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Lbl_Estatus_Ubicacion As DevComponents.DotNetBar.LabelX
    Friend WithEvents Btn_Ver As DevComponents.DotNetBar.ButtonX
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Panel_Ayuda As DevComponents.DotNetBar.ExpandablePanel
    Friend WithEvents LabelX6 As DevComponents.DotNetBar.LabelX
    Public WithEvents Btn_Imprimir_Toma_Inventario As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ContextMenuBar1 As DevComponents.DotNetBar.ContextMenuBar
    Friend WithEvents Menu_Contextual_Columna As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelItem4 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents Btn_Mnu_Eliminar_Columnas As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Mnu_Cambiar_Nombre_Columna As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Menu_Contextual_Fila As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Lbl_Sector As DevComponents.DotNetBar.LabelItem
    Friend WithEvents Btn_Mnu_Eliminar_Fila As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Mnu_Objeto_Propiedades As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Menu_Contextual_Ubicacion As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelItem1 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents Btn_Mnu_Ver_Productos_Ubicacion As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Mnu_Dejar_Ubacion_Sub_Sector As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Menu_Contextual_Sub_Sector As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelItem3 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents Btn_Mnu_Ver_Sub_Sector As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Mnu_Quitar_Sub_Sector As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Mnu_Bloquear_Ubicacion As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Mnu_Desbloquear_Ubicacion As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Mnu_Sector_Cambiar_Codigo As DevComponents.DotNetBar.ButtonItem
End Class
