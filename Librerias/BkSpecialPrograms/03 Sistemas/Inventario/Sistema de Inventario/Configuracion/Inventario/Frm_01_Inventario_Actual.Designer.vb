<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_01_Inventario_Actual
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_01_Inventario_Actual))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Bar2 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Actualizar = New DevComponents.DotNetBar.ButtonItem()
        Me.BtnCerrar = New DevComponents.DotNetBar.ButtonItem()
        Me.BtnCerrarSinDiferencias = New DevComponents.DotNetBar.ButtonItem()
        Me.BtnCerrarInventariados = New DevComponents.DotNetBar.ButtonItem()
        Me.BtnCerrarTodosInvCero = New DevComponents.DotNetBar.ButtonItem()
        Me.BtnLevantados = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_ExportarAjuste = New DevComponents.DotNetBar.ButtonItem()
        Me.LblTotal_Diferencia = New DevComponents.DotNetBar.LabelX()
        Me.LblTotal_Inventario = New DevComponents.DotNetBar.LabelX()
        Me.LblTotal_FotoStock = New DevComponents.DotNetBar.LabelX()
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Menu_Contextual = New DevComponents.DotNetBar.ContextMenuBar()
        Me.Menu_Contextual_01 = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_RevisarProducto = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Copiar = New DevComponents.DotNetBar.ButtonItem()
        Me.Menu_Contextual_ExportarAjuste = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_ExportarAjuste_Todo = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_ExportarAjuste_Cerrados = New DevComponents.DotNetBar.ButtonItem()
        Me.Grilla = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.GroupPanel2 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.GroupPanel3 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.GroupPanel4 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_Filtrar = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Chk_MostrarSoloInventariados = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.ButtonItem1 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem2 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem3 = New DevComponents.DotNetBar.ButtonItem()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel1.SuspendLayout()
        CType(Me.Menu_Contextual, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel2.SuspendLayout()
        Me.GroupPanel3.SuspendLayout()
        Me.GroupPanel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'Bar2
        '
        Me.Bar2.AntiAlias = True
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Actualizar, Me.Btn_ExportarAjuste, Me.BtnCerrar})
        Me.Bar2.Location = New System.Drawing.Point(0, 603)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(1078, 41)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Bar2.TabIndex = 30
        Me.Bar2.TabStop = False
        Me.Bar2.Text = "Bar2"
        '
        'Btn_Actualizar
        '
        Me.Btn_Actualizar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Actualizar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Actualizar.Image = CType(resources.GetObject("Btn_Actualizar.Image"), System.Drawing.Image)
        Me.Btn_Actualizar.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.Btn_Actualizar.Name = "Btn_Actualizar"
        '
        'BtnCerrar
        '
        Me.BtnCerrar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnCerrar.ForeColor = System.Drawing.Color.Black
        Me.BtnCerrar.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.BtnCerrar.Name = "BtnCerrar"
        Me.BtnCerrar.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.BtnCerrarSinDiferencias, Me.BtnCerrarInventariados, Me.BtnCerrarTodosInvCero, Me.BtnLevantados})
        '
        'BtnCerrarSinDiferencias
        '
        Me.BtnCerrarSinDiferencias.Name = "BtnCerrarSinDiferencias"
        Me.BtnCerrarSinDiferencias.Text = "Cerrar todos los productos sin diferencia de inventario"
        '
        'BtnCerrarInventariados
        '
        Me.BtnCerrarInventariados.Name = "BtnCerrarInventariados"
        Me.BtnCerrarInventariados.Text = "Cerrar todos los productos con cantidad inventariada mayor a cero"
        '
        'BtnCerrarTodosInvCero
        '
        Me.BtnCerrarTodosInvCero.Name = "BtnCerrarTodosInvCero"
        Me.BtnCerrarTodosInvCero.Text = "Cerrar todos los con cantidad igual a cero"
        '
        'BtnLevantados
        '
        Me.BtnLevantados.Name = "BtnLevantados"
        Me.BtnLevantados.Text = "Marcar como levantados todos los productos cerrados"
        '
        'Btn_ExportarAjuste
        '
        Me.Btn_ExportarAjuste.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_ExportarAjuste.ForeColor = System.Drawing.Color.Black
        Me.Btn_ExportarAjuste.Image = CType(resources.GetObject("Btn_ExportarAjuste.Image"), System.Drawing.Image)
        Me.Btn_ExportarAjuste.Name = "Btn_ExportarAjuste"
        Me.Btn_ExportarAjuste.Text = "Expotar archivo apara ajuste"
        '
        'LblTotal_Diferencia
        '
        Me.LblTotal_Diferencia.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LblTotal_Diferencia.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LblTotal_Diferencia.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotal_Diferencia.ForeColor = System.Drawing.Color.Black
        Me.LblTotal_Diferencia.Location = New System.Drawing.Point(3, 11)
        Me.LblTotal_Diferencia.Name = "LblTotal_Diferencia"
        Me.LblTotal_Diferencia.Size = New System.Drawing.Size(148, 23)
        Me.LblTotal_Diferencia.TabIndex = 34
        Me.LblTotal_Diferencia.Text = "0"
        Me.LblTotal_Diferencia.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'LblTotal_Inventario
        '
        Me.LblTotal_Inventario.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LblTotal_Inventario.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LblTotal_Inventario.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotal_Inventario.ForeColor = System.Drawing.Color.Black
        Me.LblTotal_Inventario.Location = New System.Drawing.Point(1, 11)
        Me.LblTotal_Inventario.Name = "LblTotal_Inventario"
        Me.LblTotal_Inventario.Size = New System.Drawing.Size(148, 23)
        Me.LblTotal_Inventario.TabIndex = 34
        Me.LblTotal_Inventario.Text = "0"
        Me.LblTotal_Inventario.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'LblTotal_FotoStock
        '
        Me.LblTotal_FotoStock.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LblTotal_FotoStock.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LblTotal_FotoStock.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotal_FotoStock.ForeColor = System.Drawing.Color.Black
        Me.LblTotal_FotoStock.Location = New System.Drawing.Point(2, 11)
        Me.LblTotal_FotoStock.Name = "LblTotal_FotoStock"
        Me.LblTotal_FotoStock.Size = New System.Drawing.Size(147, 23)
        Me.LblTotal_FotoStock.TabIndex = 34
        Me.LblTotal_FotoStock.Text = "0"
        Me.LblTotal_FotoStock.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'GroupPanel1
        '
        Me.GroupPanel1.BackColor = System.Drawing.Color.White
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.Menu_Contextual)
        Me.GroupPanel1.Controls.Add(Me.Grilla)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Location = New System.Drawing.Point(12, 29)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(1054, 483)
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
        Me.GroupPanel1.TabIndex = 46
        Me.GroupPanel1.Text = "Detalle de inventario"
        '
        'Menu_Contextual
        '
        Me.Menu_Contextual.AntiAlias = True
        Me.Menu_Contextual.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Menu_Contextual.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Menu_Contextual_01, Me.Menu_Contextual_ExportarAjuste, Me.ButtonItem1})
        Me.Menu_Contextual.Location = New System.Drawing.Point(45, 53)
        Me.Menu_Contextual.Name = "Menu_Contextual"
        Me.Menu_Contextual.Size = New System.Drawing.Size(519, 25)
        Me.Menu_Contextual.Stretch = True
        Me.Menu_Contextual.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Menu_Contextual.TabIndex = 49
        Me.Menu_Contextual.TabStop = False
        Me.Menu_Contextual.Text = "ContextMenuBar1"
        '
        'Menu_Contextual_01
        '
        Me.Menu_Contextual_01.AutoExpandOnClick = True
        Me.Menu_Contextual_01.Name = "Menu_Contextual_01"
        Me.Menu_Contextual_01.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_RevisarProducto, Me.Btn_Copiar})
        Me.Menu_Contextual_01.Text = "Opciones documento"
        '
        'Btn_RevisarProducto
        '
        Me.Btn_RevisarProducto.Image = CType(resources.GetObject("Btn_RevisarProducto.Image"), System.Drawing.Image)
        Me.Btn_RevisarProducto.ImageAlt = CType(resources.GetObject("Btn_RevisarProducto.ImageAlt"), System.Drawing.Image)
        Me.Btn_RevisarProducto.Name = "Btn_RevisarProducto"
        Me.Btn_RevisarProducto.Text = "Revisar inventario del producto"
        '
        'Btn_Copiar
        '
        Me.Btn_Copiar.Image = CType(resources.GetObject("Btn_Copiar.Image"), System.Drawing.Image)
        Me.Btn_Copiar.ImageAlt = CType(resources.GetObject("Btn_Copiar.ImageAlt"), System.Drawing.Image)
        Me.Btn_Copiar.Name = "Btn_Copiar"
        Me.Btn_Copiar.Text = "Copiar (portapapeles)"
        '
        'Menu_Contextual_ExportarAjuste
        '
        Me.Menu_Contextual_ExportarAjuste.AutoExpandOnClick = True
        Me.Menu_Contextual_ExportarAjuste.Name = "Menu_Contextual_ExportarAjuste"
        Me.Menu_Contextual_ExportarAjuste.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_ExportarAjuste_Todo, Me.Btn_ExportarAjuste_Cerrados})
        Me.Menu_Contextual_ExportarAjuste.Text = "Opciones exportar ajuste"
        '
        'Btn_ExportarAjuste_Todo
        '
        Me.Btn_ExportarAjuste_Todo.Image = CType(resources.GetObject("Btn_ExportarAjuste_Todo.Image"), System.Drawing.Image)
        Me.Btn_ExportarAjuste_Todo.ImageAlt = CType(resources.GetObject("Btn_ExportarAjuste_Todo.ImageAlt"), System.Drawing.Image)
        Me.Btn_ExportarAjuste_Todo.Name = "Btn_ExportarAjuste_Todo"
        Me.Btn_ExportarAjuste_Todo.Text = "Exportar todo"
        '
        'Btn_ExportarAjuste_Cerrados
        '
        Me.Btn_ExportarAjuste_Cerrados.Image = CType(resources.GetObject("Btn_ExportarAjuste_Cerrados.Image"), System.Drawing.Image)
        Me.Btn_ExportarAjuste_Cerrados.ImageAlt = CType(resources.GetObject("Btn_ExportarAjuste_Cerrados.ImageAlt"), System.Drawing.Image)
        Me.Btn_ExportarAjuste_Cerrados.Name = "Btn_ExportarAjuste_Cerrados"
        Me.Btn_ExportarAjuste_Cerrados.Text = "Exportar solo cerrados"
        '
        'Grilla
        '
        Me.Grilla.AllowUserToAddRows = False
        Me.Grilla.BackgroundColor = System.Drawing.Color.White
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
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
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
        Me.Grilla.Size = New System.Drawing.Size(1048, 460)
        Me.Grilla.StandardTab = True
        Me.Grilla.TabIndex = 30
        '
        'GroupPanel2
        '
        Me.GroupPanel2.BackColor = System.Drawing.Color.White
        Me.GroupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel2.Controls.Add(Me.LblTotal_FotoStock)
        Me.GroupPanel2.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel2.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold)
        Me.GroupPanel2.Location = New System.Drawing.Point(580, 518)
        Me.GroupPanel2.Name = "GroupPanel2"
        Me.GroupPanel2.Size = New System.Drawing.Size(158, 65)
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
        Me.GroupPanel2.Text = "Foto Stock"
        '
        'GroupPanel3
        '
        Me.GroupPanel3.BackColor = System.Drawing.Color.White
        Me.GroupPanel3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel3.Controls.Add(Me.LblTotal_Inventario)
        Me.GroupPanel3.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel3.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold)
        Me.GroupPanel3.Location = New System.Drawing.Point(744, 518)
        Me.GroupPanel3.Name = "GroupPanel3"
        Me.GroupPanel3.Size = New System.Drawing.Size(158, 65)
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
        Me.GroupPanel3.TabIndex = 48
        Me.GroupPanel3.Text = "Inventario"
        '
        'GroupPanel4
        '
        Me.GroupPanel4.BackColor = System.Drawing.Color.White
        Me.GroupPanel4.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel4.Controls.Add(Me.LblTotal_Diferencia)
        Me.GroupPanel4.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel4.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold)
        Me.GroupPanel4.Location = New System.Drawing.Point(908, 518)
        Me.GroupPanel4.Name = "GroupPanel4"
        Me.GroupPanel4.Size = New System.Drawing.Size(158, 65)
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
        Me.GroupPanel4.TabIndex = 49
        Me.GroupPanel4.Text = "Diferencia"
        '
        'LabelX2
        '
        Me.LabelX2.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.ForeColor = System.Drawing.Color.Black
        Me.LabelX2.Image = CType(resources.GetObject("LabelX2.Image"), System.Drawing.Image)
        Me.LabelX2.ImagePosition = DevComponents.DotNetBar.eImagePosition.Right
        Me.LabelX2.ImageTextSpacing = 3
        Me.LabelX2.Location = New System.Drawing.Point(12, 0)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(57, 23)
        Me.LabelX2.TabIndex = 178
        Me.LabelX2.Text = "Buscar"
        '
        'Txt_Filtrar
        '
        Me.Txt_Filtrar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Txt_Filtrar.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Filtrar.Border.Class = "TextBoxBorder"
        Me.Txt_Filtrar.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Filtrar.ButtonCustom2.Image = CType(resources.GetObject("Txt_Filtrar.ButtonCustom2.Image"), System.Drawing.Image)
        Me.Txt_Filtrar.ButtonCustom2.Visible = True
        Me.Txt_Filtrar.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Filtrar.ForeColor = System.Drawing.Color.Black
        Me.Txt_Filtrar.Location = New System.Drawing.Point(75, 1)
        Me.Txt_Filtrar.Name = "Txt_Filtrar"
        Me.Txt_Filtrar.PreventEnterBeep = True
        Me.Txt_Filtrar.Size = New System.Drawing.Size(504, 22)
        Me.Txt_Filtrar.TabIndex = 177
        '
        'Chk_MostrarSoloInventariados
        '
        Me.Chk_MostrarSoloInventariados.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_MostrarSoloInventariados.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_MostrarSoloInventariados.CheckBoxImageChecked = CType(resources.GetObject("Chk_MostrarSoloInventariados.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_MostrarSoloInventariados.FocusCuesEnabled = False
        Me.Chk_MostrarSoloInventariados.ForeColor = System.Drawing.Color.Black
        Me.Chk_MostrarSoloInventariados.Location = New System.Drawing.Point(12, 518)
        Me.Chk_MostrarSoloInventariados.Name = "Chk_MostrarSoloInventariados"
        Me.Chk_MostrarSoloInventariados.Size = New System.Drawing.Size(238, 23)
        Me.Chk_MostrarSoloInventariados.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_MostrarSoloInventariados.TabIndex = 179
        Me.Chk_MostrarSoloInventariados.Text = "Mostrar solo productos inventariados"
        '
        'ButtonItem1
        '
        Me.ButtonItem1.AutoExpandOnClick = True
        Me.ButtonItem1.Name = "ButtonItem1"
        Me.ButtonItem1.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItem2, Me.ButtonItem3})
        Me.ButtonItem1.Text = "Opciones exportar ajuste"
        '
        'ButtonItem2
        '
        Me.ButtonItem2.Image = CType(resources.GetObject("ButtonItem2.Image"), System.Drawing.Image)
        Me.ButtonItem2.ImageAlt = CType(resources.GetObject("ButtonItem2.ImageAlt"), System.Drawing.Image)
        Me.ButtonItem2.Name = "ButtonItem2"
        Me.ButtonItem2.Text = "Exportar todo"
        '
        'ButtonItem3
        '
        Me.ButtonItem3.Image = CType(resources.GetObject("ButtonItem3.Image"), System.Drawing.Image)
        Me.ButtonItem3.ImageAlt = CType(resources.GetObject("ButtonItem3.ImageAlt"), System.Drawing.Image)
        Me.ButtonItem3.Name = "ButtonItem3"
        Me.ButtonItem3.Text = "Exportar solo cerrados"
        '
        'Frm_01_Inventario_Actual
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1078, 644)
        Me.Controls.Add(Me.Chk_MostrarSoloInventariados)
        Me.Controls.Add(Me.LabelX2)
        Me.Controls.Add(Me.Txt_Filtrar)
        Me.Controls.Add(Me.GroupPanel4)
        Me.Controls.Add(Me.GroupPanel3)
        Me.Controls.Add(Me.GroupPanel2)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Controls.Add(Me.Bar2)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_01_Inventario_Actual"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Inventario Actual"
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel1.ResumeLayout(False)
        CType(Me.Menu_Contextual, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel2.ResumeLayout(False)
        Me.GroupPanel3.ResumeLayout(False)
        Me.GroupPanel4.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents Btn_Actualizar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LblTotal_Diferencia As DevComponents.DotNetBar.LabelX
    Friend WithEvents LblTotal_Inventario As DevComponents.DotNetBar.LabelX
    Friend WithEvents LblTotal_FotoStock As DevComponents.DotNetBar.LabelX
    Friend WithEvents BtnCerrar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents BtnCerrarSinDiferencias As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents BtnLevantados As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents BtnCerrarInventariados As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_ExportarAjuste As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents BtnCerrarTodosInvCero As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Menu_Contextual As DevComponents.DotNetBar.ContextMenuBar
    Friend WithEvents Menu_Contextual_01 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_RevisarProducto As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Copiar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Grilla As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents GroupPanel2 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents GroupPanel3 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents GroupPanel4 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Txt_Filtrar As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Chk_MostrarSoloInventariados As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Menu_Contextual_ExportarAjuste As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_ExportarAjuste_Todo As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_ExportarAjuste_Cerrados As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem1 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem2 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem3 As DevComponents.DotNetBar.ButtonItem
End Class