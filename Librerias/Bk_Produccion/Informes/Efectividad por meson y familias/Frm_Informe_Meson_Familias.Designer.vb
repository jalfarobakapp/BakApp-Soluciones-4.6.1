<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Frm_Informe_Meson_Familias
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Informe_Meson_Familias))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Me.Grupo_Venta_Diaria = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.ContextMenuBar1 = New DevComponents.DotNetBar.ContextMenuBar()
        Me.Menu_Contextual_Informe = New DevComponents.DotNetBar.ButtonItem()
        Me.LabelItem2 = New DevComponents.DotNetBar.LabelItem()
        Me.Btn_Informe_X_Mesones = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Informe_X_Super_Familias = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Informe_X_Familias = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Informe_X_Sub_Familias = New DevComponents.DotNetBar.ButtonItem()
        Me.LabelItem1 = New DevComponents.DotNetBar.LabelItem()
        Me.Btn_Ver_Meson = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Informe_X_Productos = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Grafico_Anual = New DevComponents.DotNetBar.ButtonItem()
        Me.Menu_Contextual_Filtros_Productos = New DevComponents.DotNetBar.ButtonItem()
        Me.LabelItem3 = New DevComponents.DotNetBar.LabelItem()
        Me.Btn_Filtro_Pro_Productos = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Filtro_Pro_Super_Familias = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Filtro_Pro_Familias = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Filtro_Pro_Sub_Familias = New DevComponents.DotNetBar.ButtonItem()
        Me.Menu_Contextual_Filtros_Funcionarios = New DevComponents.DotNetBar.ButtonItem()
        Me.LabelItem5 = New DevComponents.DotNetBar.LabelItem()
        Me.Btn_Filtro_Responzables = New DevComponents.DotNetBar.ButtonItem()
        Me.Menu_Contextual_Filtros_Mesones_Operaciones = New DevComponents.DotNetBar.ButtonItem()
        Me.LabelItem7 = New DevComponents.DotNetBar.LabelItem()
        Me.Btn_Filtro_Mesones = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Filtro_Opreciones = New DevComponents.DotNetBar.ButtonItem()
        Me.Grilla = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Actualizar_Informe = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Excel = New DevComponents.DotNetBar.ButtonItem()
        Me.Cmb_Vista_Informe = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.Chk_Ver_Leyenda = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Grafico_Pie = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.Num_Agrupador_Pie = New System.Windows.Forms.NumericUpDown()
        Me.Rdb_Pie_Descripcion = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_Pie_Codigo = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Btn_Totar_Pie_Izquierda = New DevComponents.DotNetBar.ButtonX()
        Me.Btn_Totar_Pie_Derecha = New DevComponents.DotNetBar.ButtonX()
        Me.Chk_Ver_Pie_3D = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Btn_Filtrar_Mesones = New DevComponents.DotNetBar.ButtonX()
        Me.Btn_Filtrar_Productos = New DevComponents.DotNetBar.ButtonX()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.Lbl_FS_desde = New DevComponents.DotNetBar.LabelX()
        Me.Dtp_Fecha_Desde = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.Lbl_FS_hasta = New DevComponents.DotNetBar.LabelX()
        Me.Dtp_Fecha_Hasta = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.Grupo_Venta_Diaria.SuspendLayout()
        CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Grafico_Pie, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Num_Agrupador_Pie, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Dtp_Fecha_Desde, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Dtp_Fecha_Hasta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Grupo_Venta_Diaria
        '
        Me.Grupo_Venta_Diaria.BackColor = System.Drawing.Color.White
        Me.Grupo_Venta_Diaria.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Grupo_Venta_Diaria.Controls.Add(Me.ContextMenuBar1)
        Me.Grupo_Venta_Diaria.Controls.Add(Me.Grilla)
        Me.Grupo_Venta_Diaria.DisabledBackColor = System.Drawing.Color.Empty
        Me.Grupo_Venta_Diaria.Location = New System.Drawing.Point(12, 91)
        Me.Grupo_Venta_Diaria.Name = "Grupo_Venta_Diaria"
        Me.Grupo_Venta_Diaria.Size = New System.Drawing.Size(752, 489)
        '
        '
        '
        Me.Grupo_Venta_Diaria.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Grupo_Venta_Diaria.Style.BackColorGradientAngle = 90
        Me.Grupo_Venta_Diaria.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Grupo_Venta_Diaria.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Venta_Diaria.Style.BorderBottomWidth = 1
        Me.Grupo_Venta_Diaria.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.Grupo_Venta_Diaria.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Venta_Diaria.Style.BorderLeftWidth = 1
        Me.Grupo_Venta_Diaria.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Venta_Diaria.Style.BorderRightWidth = 1
        Me.Grupo_Venta_Diaria.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Venta_Diaria.Style.BorderTopWidth = 1
        Me.Grupo_Venta_Diaria.Style.CornerDiameter = 4
        Me.Grupo_Venta_Diaria.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Grupo_Venta_Diaria.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.Grupo_Venta_Diaria.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.Grupo_Venta_Diaria.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.Grupo_Venta_Diaria.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.Grupo_Venta_Diaria.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Grupo_Venta_Diaria.TabIndex = 105
        Me.Grupo_Venta_Diaria.Text = "Detalle del informe"
        '
        'ContextMenuBar1
        '
        Me.ContextMenuBar1.AntiAlias = True
        Me.ContextMenuBar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ContextMenuBar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Menu_Contextual_Informe, Me.Menu_Contextual_Filtros_Productos, Me.Menu_Contextual_Filtros_Funcionarios, Me.Menu_Contextual_Filtros_Mesones_Operaciones})
        Me.ContextMenuBar1.Location = New System.Drawing.Point(121, 104)
        Me.ContextMenuBar1.Name = "ContextMenuBar1"
        Me.ContextMenuBar1.Size = New System.Drawing.Size(569, 25)
        Me.ContextMenuBar1.Stretch = True
        Me.ContextMenuBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ContextMenuBar1.TabIndex = 96
        Me.ContextMenuBar1.TabStop = False
        Me.ContextMenuBar1.Text = "ContextMenuBar1"
        '
        'Menu_Contextual_Informe
        '
        Me.Menu_Contextual_Informe.AutoExpandOnClick = True
        Me.Menu_Contextual_Informe.Name = "Menu_Contextual_Informe"
        Me.Menu_Contextual_Informe.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItem2, Me.Btn_Informe_X_Mesones, Me.Btn_Informe_X_Super_Familias, Me.Btn_Informe_X_Familias, Me.Btn_Informe_X_Sub_Familias, Me.LabelItem1, Me.Btn_Ver_Meson, Me.Btn_Informe_X_Productos, Me.Btn_Grafico_Anual})
        Me.Menu_Contextual_Informe.Text = "Sub Informes"
        '
        'LabelItem2
        '
        Me.LabelItem2.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.LabelItem2.BorderSide = DevComponents.DotNetBar.eBorderSide.Bottom
        Me.LabelItem2.BorderType = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.LabelItem2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(21, Byte), Integer), CType(CType(110, Byte), Integer))
        Me.LabelItem2.Name = "LabelItem2"
        Me.LabelItem2.PaddingBottom = 1
        Me.LabelItem2.PaddingLeft = 10
        Me.LabelItem2.PaddingTop = 1
        Me.LabelItem2.SingleLineColor = System.Drawing.Color.FromArgb(CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer))
        Me.LabelItem2.Text = "Informes Agrupados"
        '
        'Btn_Informe_X_Mesones
        '
        Me.Btn_Informe_X_Mesones.Image = CType(resources.GetObject("Btn_Informe_X_Mesones.Image"), System.Drawing.Image)
        Me.Btn_Informe_X_Mesones.Name = "Btn_Informe_X_Mesones"
        Me.Btn_Informe_X_Mesones.Text = "Ver informe por <b><font color=""#C0504D"">MESONES</font></b>"
        '
        'Btn_Informe_X_Super_Familias
        '
        Me.Btn_Informe_X_Super_Familias.Image = CType(resources.GetObject("Btn_Informe_X_Super_Familias.Image"), System.Drawing.Image)
        Me.Btn_Informe_X_Super_Familias.Name = "Btn_Informe_X_Super_Familias"
        Me.Btn_Informe_X_Super_Familias.Text = "Ver informe por <b><font color=""#0072BC"">SUPER FAMILIAS</font></b>"
        '
        'Btn_Informe_X_Familias
        '
        Me.Btn_Informe_X_Familias.Image = CType(resources.GetObject("Btn_Informe_X_Familias.Image"), System.Drawing.Image)
        Me.Btn_Informe_X_Familias.Name = "Btn_Informe_X_Familias"
        Me.Btn_Informe_X_Familias.Text = "Ver informe por <b><font color=""#0072BC"">FAMILIAS</font></b>"
        '
        'Btn_Informe_X_Sub_Familias
        '
        Me.Btn_Informe_X_Sub_Familias.Image = CType(resources.GetObject("Btn_Informe_X_Sub_Familias.Image"), System.Drawing.Image)
        Me.Btn_Informe_X_Sub_Familias.Name = "Btn_Informe_X_Sub_Familias"
        Me.Btn_Informe_X_Sub_Familias.Text = "Ver informe por <b><font color=""#0072BC"">SUB-FAMILIAS</font></b>"
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
        Me.LabelItem1.Text = "Informe detallado"
        '
        'Btn_Ver_Meson
        '
        Me.Btn_Ver_Meson.Image = CType(resources.GetObject("Btn_Ver_Meson.Image"), System.Drawing.Image)
        Me.Btn_Ver_Meson.Name = "Btn_Ver_Meson"
        Me.Btn_Ver_Meson.Text = "Ver mesón"
        '
        'Btn_Informe_X_Productos
        '
        Me.Btn_Informe_X_Productos.Image = CType(resources.GetObject("Btn_Informe_X_Productos.Image"), System.Drawing.Image)
        Me.Btn_Informe_X_Productos.Name = "Btn_Informe_X_Productos"
        Me.Btn_Informe_X_Productos.Text = "Ver detalle de los <b><font color=""#22B14C"">Productos->Detalle</font></b>"
        '
        'Btn_Grafico_Anual
        '
        Me.Btn_Grafico_Anual.Image = CType(resources.GetObject("Btn_Grafico_Anual.Image"), System.Drawing.Image)
        Me.Btn_Grafico_Anual.Name = "Btn_Grafico_Anual"
        Me.Btn_Grafico_Anual.Text = "Ver grafico de movimientos<b><font color=""#22B14C""> Ultimos 12 meses</font></b>"
        '
        'Menu_Contextual_Filtros_Productos
        '
        Me.Menu_Contextual_Filtros_Productos.AutoExpandOnClick = True
        Me.Menu_Contextual_Filtros_Productos.Name = "Menu_Contextual_Filtros_Productos"
        Me.Menu_Contextual_Filtros_Productos.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItem3, Me.Btn_Filtro_Pro_Productos, Me.Btn_Filtro_Pro_Super_Familias, Me.Btn_Filtro_Pro_Familias, Me.Btn_Filtro_Pro_Sub_Familias})
        Me.Menu_Contextual_Filtros_Productos.Text = "Filtros Productos"
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
        Me.LabelItem3.Text = "Productos"
        '
        'Btn_Filtro_Pro_Productos
        '
        Me.Btn_Filtro_Pro_Productos.Image = CType(resources.GetObject("Btn_Filtro_Pro_Productos.Image"), System.Drawing.Image)
        Me.Btn_Filtro_Pro_Productos.Name = "Btn_Filtro_Pro_Productos"
        Me.Btn_Filtro_Pro_Productos.Text = "Filtrar por <b><font color=""#0072BC"">PRODUCTOS" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "</font></b>"
        '
        'Btn_Filtro_Pro_Super_Familias
        '
        Me.Btn_Filtro_Pro_Super_Familias.Image = CType(resources.GetObject("Btn_Filtro_Pro_Super_Familias.Image"), System.Drawing.Image)
        Me.Btn_Filtro_Pro_Super_Familias.Name = "Btn_Filtro_Pro_Super_Familias"
        Me.Btn_Filtro_Pro_Super_Familias.Text = "Filtrar por <b><font color=""#0072BC"">SUPER FAMILIAS</font></b>"
        '
        'Btn_Filtro_Pro_Familias
        '
        Me.Btn_Filtro_Pro_Familias.Image = CType(resources.GetObject("Btn_Filtro_Pro_Familias.Image"), System.Drawing.Image)
        Me.Btn_Filtro_Pro_Familias.Name = "Btn_Filtro_Pro_Familias"
        Me.Btn_Filtro_Pro_Familias.Text = "Filtrar por <b><font color=""#0072BC"">FAMILIAS</font></b>"
        '
        'Btn_Filtro_Pro_Sub_Familias
        '
        Me.Btn_Filtro_Pro_Sub_Familias.Image = CType(resources.GetObject("Btn_Filtro_Pro_Sub_Familias.Image"), System.Drawing.Image)
        Me.Btn_Filtro_Pro_Sub_Familias.Name = "Btn_Filtro_Pro_Sub_Familias"
        Me.Btn_Filtro_Pro_Sub_Familias.Text = "Filtrar por <b><font color=""#4E5D30""><font color=""#0072BC"">SUB FAMILIAS</font></f" &
    "ont></b>"
        '
        'Menu_Contextual_Filtros_Funcionarios
        '
        Me.Menu_Contextual_Filtros_Funcionarios.AutoExpandOnClick = True
        Me.Menu_Contextual_Filtros_Funcionarios.Name = "Menu_Contextual_Filtros_Funcionarios"
        Me.Menu_Contextual_Filtros_Funcionarios.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItem5, Me.Btn_Filtro_Responzables})
        Me.Menu_Contextual_Filtros_Funcionarios.Text = "Filtros Funcionarios"
        '
        'LabelItem5
        '
        Me.LabelItem5.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.LabelItem5.BorderSide = DevComponents.DotNetBar.eBorderSide.Bottom
        Me.LabelItem5.BorderType = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.LabelItem5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(21, Byte), Integer), CType(CType(110, Byte), Integer))
        Me.LabelItem5.Name = "LabelItem5"
        Me.LabelItem5.PaddingBottom = 1
        Me.LabelItem5.PaddingLeft = 10
        Me.LabelItem5.PaddingTop = 1
        Me.LabelItem5.SingleLineColor = System.Drawing.Color.FromArgb(CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer))
        Me.LabelItem5.Text = "Productos"
        '
        'Btn_Filtro_Responzables
        '
        Me.Btn_Filtro_Responzables.Image = CType(resources.GetObject("Btn_Filtro_Responzables.Image"), System.Drawing.Image)
        Me.Btn_Filtro_Responzables.Name = "Btn_Filtro_Responzables"
        Me.Btn_Filtro_Responzables.Text = "Filtrar por <b><font color=""#0072BC"">OPERARIO</font></b>"
        '
        'Menu_Contextual_Filtros_Mesones_Operaciones
        '
        Me.Menu_Contextual_Filtros_Mesones_Operaciones.AutoExpandOnClick = True
        Me.Menu_Contextual_Filtros_Mesones_Operaciones.Name = "Menu_Contextual_Filtros_Mesones_Operaciones"
        Me.Menu_Contextual_Filtros_Mesones_Operaciones.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItem7, Me.Btn_Filtro_Mesones, Me.Btn_Filtro_Opreciones})
        Me.Menu_Contextual_Filtros_Mesones_Operaciones.Text = "Filtros Mesones/Operaciones"
        '
        'LabelItem7
        '
        Me.LabelItem7.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.LabelItem7.BorderSide = DevComponents.DotNetBar.eBorderSide.Bottom
        Me.LabelItem7.BorderType = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.LabelItem7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(21, Byte), Integer), CType(CType(110, Byte), Integer))
        Me.LabelItem7.Name = "LabelItem7"
        Me.LabelItem7.PaddingBottom = 1
        Me.LabelItem7.PaddingLeft = 10
        Me.LabelItem7.PaddingTop = 1
        Me.LabelItem7.SingleLineColor = System.Drawing.Color.FromArgb(CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer))
        Me.LabelItem7.Text = "Productos"
        '
        'Btn_Filtro_Mesones
        '
        Me.Btn_Filtro_Mesones.Image = CType(resources.GetObject("Btn_Filtro_Mesones.Image"), System.Drawing.Image)
        Me.Btn_Filtro_Mesones.Name = "Btn_Filtro_Mesones"
        Me.Btn_Filtro_Mesones.Text = "Filtrar por <b><font color=""#0072BC"">MESON</font></b>"
        '
        'Btn_Filtro_Opreciones
        '
        Me.Btn_Filtro_Opreciones.Image = CType(resources.GetObject("Btn_Filtro_Opreciones.Image"), System.Drawing.Image)
        Me.Btn_Filtro_Opreciones.Name = "Btn_Filtro_Opreciones"
        Me.Btn_Filtro_Opreciones.Text = "Filtrar por <b><font color=""#0072BC"">OPERACION</font></b>"
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
        Me.Grilla.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.Grilla.RowHeadersVisible = False
        Me.Grilla.Size = New System.Drawing.Size(746, 466)
        Me.Grilla.TabIndex = 3
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Actualizar_Informe, Me.Btn_Excel})
        Me.Bar1.Location = New System.Drawing.Point(0, 586)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(1418, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 104
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'Btn_Actualizar_Informe
        '
        Me.Btn_Actualizar_Informe.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Actualizar_Informe.ForeColor = System.Drawing.Color.Black
        Me.Btn_Actualizar_Informe.Image = CType(resources.GetObject("Btn_Actualizar_Informe.Image"), System.Drawing.Image)
        Me.Btn_Actualizar_Informe.ImageAlt = CType(resources.GetObject("Btn_Actualizar_Informe.ImageAlt"), System.Drawing.Image)
        Me.Btn_Actualizar_Informe.Name = "Btn_Actualizar_Informe"
        Me.Btn_Actualizar_Informe.Tooltip = "Actualizar informe"
        '
        'Btn_Excel
        '
        Me.Btn_Excel.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Excel.ForeColor = System.Drawing.Color.Black
        Me.Btn_Excel.Image = CType(resources.GetObject("Btn_Excel.Image"), System.Drawing.Image)
        Me.Btn_Excel.ImageAlt = CType(resources.GetObject("Btn_Excel.ImageAlt"), System.Drawing.Image)
        Me.Btn_Excel.Name = "Btn_Excel"
        Me.Btn_Excel.Tooltip = "Exportar a Excel"
        '
        'Cmb_Vista_Informe
        '
        Me.Cmb_Vista_Informe.DisplayMember = "Text"
        Me.Cmb_Vista_Informe.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.Cmb_Vista_Informe.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmb_Vista_Informe.ForeColor = System.Drawing.Color.Black
        Me.Cmb_Vista_Informe.FormattingEnabled = True
        Me.Cmb_Vista_Informe.ItemHeight = 23
        Me.Cmb_Vista_Informe.Location = New System.Drawing.Point(172, 50)
        Me.Cmb_Vista_Informe.MaximumSize = New System.Drawing.Size(322, 0)
        Me.Cmb_Vista_Informe.Name = "Cmb_Vista_Informe"
        Me.Cmb_Vista_Informe.Size = New System.Drawing.Size(283, 29)
        Me.Cmb_Vista_Informe.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Cmb_Vista_Informe.TabIndex = 109
        '
        'LabelX1
        '
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.LabelX1.ForeColor = System.Drawing.Color.Black
        Me.LabelX1.Location = New System.Drawing.Point(15, 50)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(151, 23)
        Me.LabelX1.TabIndex = 110
        Me.LabelX1.Text = "VISTA DEL INFORME"
        '
        'Chk_Ver_Leyenda
        '
        Me.Chk_Ver_Leyenda.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Chk_Ver_Leyenda.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_Ver_Leyenda.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Ver_Leyenda.Checked = True
        Me.Chk_Ver_Leyenda.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Chk_Ver_Leyenda.CheckValue = "Y"
        Me.Chk_Ver_Leyenda.ForeColor = System.Drawing.Color.Black
        Me.Chk_Ver_Leyenda.Location = New System.Drawing.Point(1126, 537)
        Me.Chk_Ver_Leyenda.Name = "Chk_Ver_Leyenda"
        Me.Chk_Ver_Leyenda.Size = New System.Drawing.Size(83, 23)
        Me.Chk_Ver_Leyenda.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Ver_Leyenda.TabIndex = 119
        Me.Chk_Ver_Leyenda.Text = "Ver Leyenda"
        '
        'Grafico_Pie
        '
        ChartArea1.Name = "ChartArea1"
        Me.Grafico_Pie.ChartAreas.Add(ChartArea1)
        Legend1.Font = New System.Drawing.Font("Courier New", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Legend1.ForeColor = System.Drawing.Color.Maroon
        Legend1.IsTextAutoFit = False
        Legend1.Name = "Legend1"
        Legend1.TitleAlignment = System.Drawing.StringAlignment.Near
        Me.Grafico_Pie.Legends.Add(Legend1)
        Me.Grafico_Pie.Location = New System.Drawing.Point(780, 63)
        Me.Grafico_Pie.Name = "Grafico_Pie"
        Series1.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.DashDot
        Series1.ChartArea = "ChartArea1"
        Series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie
        Series1.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Series1.Legend = "Legend1"
        Series1.Name = "Series1"
        Series1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.BrightPastel
        Me.Grafico_Pie.Series.Add(Series1)
        Me.Grafico_Pie.Size = New System.Drawing.Size(626, 453)
        Me.Grafico_Pie.TabIndex = 118
        Me.Grafico_Pie.Text = "Chart1"
        '
        'LabelX2
        '
        Me.LabelX2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LabelX2.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.ForeColor = System.Drawing.Color.Black
        Me.LabelX2.Location = New System.Drawing.Point(909, 536)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(101, 23)
        Me.LabelX2.TabIndex = 117
        Me.LabelX2.Text = "Agrupar por % <="
        '
        'Num_Agrupador_Pie
        '
        Me.Num_Agrupador_Pie.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Num_Agrupador_Pie.BackColor = System.Drawing.Color.White
        Me.Num_Agrupador_Pie.ForeColor = System.Drawing.Color.Black
        Me.Num_Agrupador_Pie.Location = New System.Drawing.Point(1016, 538)
        Me.Num_Agrupador_Pie.Maximum = New Decimal(New Integer() {20, 0, 0, 0})
        Me.Num_Agrupador_Pie.Name = "Num_Agrupador_Pie"
        Me.Num_Agrupador_Pie.Size = New System.Drawing.Size(40, 22)
        Me.Num_Agrupador_Pie.TabIndex = 116
        '
        'Rdb_Pie_Descripcion
        '
        Me.Rdb_Pie_Descripcion.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Rdb_Pie_Descripcion.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Pie_Descripcion.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Pie_Descripcion.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Pie_Descripcion.Checked = True
        Me.Rdb_Pie_Descripcion.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Rdb_Pie_Descripcion.CheckValue = "Y"
        Me.Rdb_Pie_Descripcion.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Pie_Descripcion.Location = New System.Drawing.Point(776, 546)
        Me.Rdb_Pie_Descripcion.Name = "Rdb_Pie_Descripcion"
        Me.Rdb_Pie_Descripcion.Size = New System.Drawing.Size(100, 23)
        Me.Rdb_Pie_Descripcion.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Pie_Descripcion.TabIndex = 115
        Me.Rdb_Pie_Descripcion.Text = "Ver Descripción"
        '
        'Rdb_Pie_Codigo
        '
        Me.Rdb_Pie_Codigo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Rdb_Pie_Codigo.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Pie_Codigo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Pie_Codigo.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Pie_Codigo.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Pie_Codigo.Location = New System.Drawing.Point(776, 526)
        Me.Rdb_Pie_Codigo.Name = "Rdb_Pie_Codigo"
        Me.Rdb_Pie_Codigo.Size = New System.Drawing.Size(56, 23)
        Me.Rdb_Pie_Codigo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Pie_Codigo.TabIndex = 114
        Me.Rdb_Pie_Codigo.Text = "Ver %"
        '
        'Btn_Totar_Pie_Izquierda
        '
        Me.Btn_Totar_Pie_Izquierda.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Totar_Pie_Izquierda.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Btn_Totar_Pie_Izquierda.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Totar_Pie_Izquierda.Image = CType(resources.GetObject("Btn_Totar_Pie_Izquierda.Image"), System.Drawing.Image)
        Me.Btn_Totar_Pie_Izquierda.Location = New System.Drawing.Point(1297, 537)
        Me.Btn_Totar_Pie_Izquierda.Name = "Btn_Totar_Pie_Izquierda"
        Me.Btn_Totar_Pie_Izquierda.Size = New System.Drawing.Size(57, 23)
        Me.Btn_Totar_Pie_Izquierda.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Totar_Pie_Izquierda.TabIndex = 113
        Me.Btn_Totar_Pie_Izquierda.Text = "Rotar "
        '
        'Btn_Totar_Pie_Derecha
        '
        Me.Btn_Totar_Pie_Derecha.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Totar_Pie_Derecha.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Btn_Totar_Pie_Derecha.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Totar_Pie_Derecha.Image = CType(resources.GetObject("Btn_Totar_Pie_Derecha.Image"), System.Drawing.Image)
        Me.Btn_Totar_Pie_Derecha.ImagePosition = DevComponents.DotNetBar.eImagePosition.Right
        Me.Btn_Totar_Pie_Derecha.Location = New System.Drawing.Point(1360, 536)
        Me.Btn_Totar_Pie_Derecha.Name = "Btn_Totar_Pie_Derecha"
        Me.Btn_Totar_Pie_Derecha.Size = New System.Drawing.Size(57, 23)
        Me.Btn_Totar_Pie_Derecha.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Totar_Pie_Derecha.TabIndex = 112
        Me.Btn_Totar_Pie_Derecha.Text = "Rotar "
        '
        'Chk_Ver_Pie_3D
        '
        Me.Chk_Ver_Pie_3D.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Chk_Ver_Pie_3D.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_Ver_Pie_3D.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Ver_Pie_3D.Checked = True
        Me.Chk_Ver_Pie_3D.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Chk_Ver_Pie_3D.CheckValue = "Y"
        Me.Chk_Ver_Pie_3D.ForeColor = System.Drawing.Color.Black
        Me.Chk_Ver_Pie_3D.Location = New System.Drawing.Point(1217, 537)
        Me.Chk_Ver_Pie_3D.Name = "Chk_Ver_Pie_3D"
        Me.Chk_Ver_Pie_3D.Size = New System.Drawing.Size(73, 23)
        Me.Chk_Ver_Pie_3D.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Ver_Pie_3D.TabIndex = 111
        Me.Chk_Ver_Pie_3D.Text = "Ver en 3D"
        '
        'Btn_Filtrar_Mesones
        '
        Me.Btn_Filtrar_Mesones.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Filtrar_Mesones.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Filtrar_Mesones.Image = CType(resources.GetObject("Btn_Filtrar_Mesones.Image"), System.Drawing.Image)
        Me.Btn_Filtrar_Mesones.ImageAlt = CType(resources.GetObject("Btn_Filtrar_Mesones.ImageAlt"), System.Drawing.Image)
        Me.Btn_Filtrar_Mesones.Location = New System.Drawing.Point(607, 12)
        Me.Btn_Filtrar_Mesones.Name = "Btn_Filtrar_Mesones"
        Me.Btn_Filtrar_Mesones.Size = New System.Drawing.Size(113, 25)
        Me.Btn_Filtrar_Mesones.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Filtrar_Mesones.TabIndex = 122
        Me.Btn_Filtrar_Mesones.Text = "Filtrar Mesones"
        '
        'Btn_Filtrar_Productos
        '
        Me.Btn_Filtrar_Productos.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Filtrar_Productos.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Filtrar_Productos.Image = CType(resources.GetObject("Btn_Filtrar_Productos.Image"), System.Drawing.Image)
        Me.Btn_Filtrar_Productos.ImageAlt = CType(resources.GetObject("Btn_Filtrar_Productos.ImageAlt"), System.Drawing.Image)
        Me.Btn_Filtrar_Productos.Location = New System.Drawing.Point(482, 12)
        Me.Btn_Filtrar_Productos.Name = "Btn_Filtrar_Productos"
        Me.Btn_Filtrar_Productos.Size = New System.Drawing.Size(119, 25)
        Me.Btn_Filtrar_Productos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Filtrar_Productos.TabIndex = 121
        Me.Btn_Filtrar_Productos.Text = "Filtrar Productos"
        '
        'LabelX3
        '
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX3.ForeColor = System.Drawing.Color.Black
        Me.LabelX3.Location = New System.Drawing.Point(1170, 12)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(229, 23)
        Me.LabelX3.TabIndex = 125
        Me.LabelX3.Text = "<font color=""#349FCE"">INFORME DE PRODUCCION</font>"
        '
        'Lbl_FS_desde
        '
        '
        '
        '
        Me.Lbl_FS_desde.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_FS_desde.ForeColor = System.Drawing.Color.Black
        Me.Lbl_FS_desde.Location = New System.Drawing.Point(15, 12)
        Me.Lbl_FS_desde.Name = "Lbl_FS_desde"
        Me.Lbl_FS_desde.Size = New System.Drawing.Size(32, 19)
        Me.Lbl_FS_desde.TabIndex = 126
        Me.Lbl_FS_desde.Text = "Desde"
        '
        'Dtp_Fecha_Desde
        '
        '
        '
        '
        Me.Dtp_Fecha_Desde.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Dtp_Fecha_Desde.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Desde.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.Dtp_Fecha_Desde.ButtonDropDown.Visible = True
        Me.Dtp_Fecha_Desde.ForeColor = System.Drawing.Color.Black
        Me.Dtp_Fecha_Desde.IsPopupCalendarOpen = False
        Me.Dtp_Fecha_Desde.Location = New System.Drawing.Point(58, 12)
        '
        '
        '
        Me.Dtp_Fecha_Desde.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_Fecha_Desde.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Desde.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.Dtp_Fecha_Desde.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.Dtp_Fecha_Desde.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.Dtp_Fecha_Desde.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_Fecha_Desde.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.Dtp_Fecha_Desde.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Dtp_Fecha_Desde.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.Dtp_Fecha_Desde.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.Dtp_Fecha_Desde.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Desde.MonthCalendar.DisplayMonth = New Date(2016, 7, 1, 0, 0, 0, 0)
        Me.Dtp_Fecha_Desde.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday
        Me.Dtp_Fecha_Desde.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.Dtp_Fecha_Desde.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_Fecha_Desde.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Dtp_Fecha_Desde.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_Fecha_Desde.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Dtp_Fecha_Desde.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Desde.MonthCalendar.TodayButtonVisible = True
        Me.Dtp_Fecha_Desde.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.Dtp_Fecha_Desde.Name = "Dtp_Fecha_Desde"
        Me.Dtp_Fecha_Desde.Size = New System.Drawing.Size(79, 22)
        Me.Dtp_Fecha_Desde.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Dtp_Fecha_Desde.TabIndex = 127
        Me.Dtp_Fecha_Desde.Value = New Date(2016, 7, 8, 16, 32, 31, 0)
        '
        'Lbl_FS_hasta
        '
        '
        '
        '
        Me.Lbl_FS_hasta.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_FS_hasta.ForeColor = System.Drawing.Color.Black
        Me.Lbl_FS_hasta.Location = New System.Drawing.Point(145, 12)
        Me.Lbl_FS_hasta.Name = "Lbl_FS_hasta"
        Me.Lbl_FS_hasta.Size = New System.Drawing.Size(28, 19)
        Me.Lbl_FS_hasta.TabIndex = 129
        Me.Lbl_FS_hasta.Text = "Hasta"
        '
        'Dtp_Fecha_Hasta
        '
        '
        '
        '
        Me.Dtp_Fecha_Hasta.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Dtp_Fecha_Hasta.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Hasta.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.Dtp_Fecha_Hasta.ButtonDropDown.Visible = True
        Me.Dtp_Fecha_Hasta.ForeColor = System.Drawing.Color.Black
        Me.Dtp_Fecha_Hasta.IsPopupCalendarOpen = False
        Me.Dtp_Fecha_Hasta.Location = New System.Drawing.Point(186, 12)
        '
        '
        '
        Me.Dtp_Fecha_Hasta.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_Fecha_Hasta.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Hasta.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.Dtp_Fecha_Hasta.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.Dtp_Fecha_Hasta.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.Dtp_Fecha_Hasta.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_Fecha_Hasta.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.Dtp_Fecha_Hasta.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Dtp_Fecha_Hasta.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.Dtp_Fecha_Hasta.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.Dtp_Fecha_Hasta.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Hasta.MonthCalendar.DisplayMonth = New Date(2016, 7, 1, 0, 0, 0, 0)
        Me.Dtp_Fecha_Hasta.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday
        Me.Dtp_Fecha_Hasta.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.Dtp_Fecha_Hasta.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_Fecha_Hasta.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Dtp_Fecha_Hasta.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_Fecha_Hasta.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Dtp_Fecha_Hasta.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Hasta.MonthCalendar.TodayButtonVisible = True
        Me.Dtp_Fecha_Hasta.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.Dtp_Fecha_Hasta.Name = "Dtp_Fecha_Hasta"
        Me.Dtp_Fecha_Hasta.Size = New System.Drawing.Size(81, 22)
        Me.Dtp_Fecha_Hasta.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Dtp_Fecha_Hasta.TabIndex = 128
        Me.Dtp_Fecha_Hasta.Value = New Date(2016, 7, 8, 16, 33, 0, 0)
        '
        'Frm_Informe_Meson_Familias
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1418, 627)
        Me.Controls.Add(Me.Lbl_FS_desde)
        Me.Controls.Add(Me.Dtp_Fecha_Desde)
        Me.Controls.Add(Me.Lbl_FS_hasta)
        Me.Controls.Add(Me.Dtp_Fecha_Hasta)
        Me.Controls.Add(Me.LabelX3)
        Me.Controls.Add(Me.Btn_Filtrar_Mesones)
        Me.Controls.Add(Me.Btn_Filtrar_Productos)
        Me.Controls.Add(Me.Chk_Ver_Leyenda)
        Me.Controls.Add(Me.Grafico_Pie)
        Me.Controls.Add(Me.LabelX2)
        Me.Controls.Add(Me.Num_Agrupador_Pie)
        Me.Controls.Add(Me.Rdb_Pie_Descripcion)
        Me.Controls.Add(Me.Rdb_Pie_Codigo)
        Me.Controls.Add(Me.Btn_Totar_Pie_Izquierda)
        Me.Controls.Add(Me.Btn_Totar_Pie_Derecha)
        Me.Controls.Add(Me.Chk_Ver_Pie_3D)
        Me.Controls.Add(Me.Cmb_Vista_Informe)
        Me.Controls.Add(Me.LabelX1)
        Me.Controls.Add(Me.Grupo_Venta_Diaria)
        Me.Controls.Add(Me.Bar1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Informe_Meson_Familias"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MetroForm"
        Me.Grupo_Venta_Diaria.ResumeLayout(False)
        CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Grafico_Pie, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Num_Agrupador_Pie, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Dtp_Fecha_Desde, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Dtp_Fecha_Hasta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Grupo_Venta_Diaria As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents ContextMenuBar1 As DevComponents.DotNetBar.ContextMenuBar
    Friend WithEvents Menu_Contextual_Informe As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelItem2 As DevComponents.DotNetBar.LabelItem
    Public WithEvents Btn_Informe_X_Super_Familias As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_Informe_X_Familias As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_Informe_X_Sub_Familias As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelItem1 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents Btn_Informe_X_Productos As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Grilla As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents Btn_Excel As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Cmb_Vista_Informe As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Btn_Actualizar_Informe As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_Informe_X_Mesones As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Ver_Meson As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Grafico_Anual As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Chk_Ver_Leyenda As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Grafico_Pie As DataVisualization.Charting.Chart
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Num_Agrupador_Pie As NumericUpDown
    Friend WithEvents Rdb_Pie_Descripcion As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_Pie_Codigo As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Btn_Totar_Pie_Izquierda As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Btn_Totar_Pie_Derecha As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Chk_Ver_Pie_3D As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Btn_Filtrar_Mesones As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Btn_Filtrar_Productos As DevComponents.DotNetBar.ButtonX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Menu_Contextual_Filtros_Productos As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelItem3 As DevComponents.DotNetBar.LabelItem
    Public WithEvents Btn_Filtro_Pro_Productos As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_Filtro_Pro_Super_Familias As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_Filtro_Pro_Familias As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_Filtro_Pro_Sub_Familias As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Menu_Contextual_Filtros_Funcionarios As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelItem5 As DevComponents.DotNetBar.LabelItem
    Public WithEvents Btn_Filtro_Responzables As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Lbl_FS_desde As DevComponents.DotNetBar.LabelX
    Friend WithEvents Dtp_Fecha_Desde As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents Lbl_FS_hasta As DevComponents.DotNetBar.LabelX
    Friend WithEvents Dtp_Fecha_Hasta As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents Menu_Contextual_Filtros_Mesones_Operaciones As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelItem7 As DevComponents.DotNetBar.LabelItem
    Public WithEvents Btn_Filtro_Mesones As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_Filtro_Opreciones As DevComponents.DotNetBar.ButtonItem
End Class
