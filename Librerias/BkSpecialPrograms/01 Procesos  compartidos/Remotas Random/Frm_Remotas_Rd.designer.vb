<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Remotas_Rd
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Remotas_Rd))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.Lbl_TotalBruto = New DevComponents.DotNetBar.LabelX
        Me.Lbl_Descripcion_Adicional = New DevComponents.DotNetBar.LabelX
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel
        Me.ContextMenuBar1 = New DevComponents.DotNetBar.ContextMenuBar
        Me.Menu_Contextual_01 = New DevComponents.DotNetBar.ButtonItem
        Me.LabelItem1 = New DevComponents.DotNetBar.LabelItem
        Me.Btn_Autorizar_Permiso = New DevComponents.DotNetBar.ButtonItem
        Me.Btn_Rechazar_Permiso = New DevComponents.DotNetBar.ButtonItem
        Me.Lbl_Opciones_adicionales = New DevComponents.DotNetBar.LabelItem
        Me.Btn_Ver_deuda_pendiente = New DevComponents.DotNetBar.ButtonItem
        Me.Grilla = New DevComponents.DotNetBar.Controls.DataGridViewX
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel
        Me.Label1 = New DevComponents.DotNetBar.LabelX
        Me.Lbl_Nombre_Solicitante = New DevComponents.DotNetBar.LabelX
        Me.LabelX18 = New DevComponents.DotNetBar.LabelX
        Me.LabelX19 = New DevComponents.DotNetBar.LabelX
        Me.Lbl_Descripcion_del_permiso = New DevComponents.DotNetBar.LabelX
        Me.GroupPanel2 = New DevComponents.DotNetBar.Controls.GroupPanel
        Me.Btn_Cambiar_de_empresa = New DevComponents.DotNetBar.ButtonItem
        Me.Btn_Refresh = New DevComponents.DotNetBar.ButtonItem
        Me.Bar1 = New DevComponents.DotNetBar.Bar
        Me.Timer_Notificaciones = New System.Windows.Forms.Timer(Me.components)
        Me.GroupPanel1.SuspendLayout()
        CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel4.SuspendLayout()
        Me.GroupPanel2.SuspendLayout()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Lbl_TotalBruto
        '
        Me.Lbl_TotalBruto.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Lbl_TotalBruto.BackgroundStyle.BackColor = System.Drawing.SystemColors.Control
        Me.Lbl_TotalBruto.BackgroundStyle.Class = "RibbonGalleryContainer"
        Me.Lbl_TotalBruto.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_TotalBruto.ForeColor = System.Drawing.Color.Black
        Me.Lbl_TotalBruto.Location = New System.Drawing.Point(156, 47)
        Me.Lbl_TotalBruto.Name = "Lbl_TotalBruto"
        Me.Lbl_TotalBruto.Size = New System.Drawing.Size(129, 16)
        Me.Lbl_TotalBruto.TabIndex = 85
        Me.Lbl_TotalBruto.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'Lbl_Descripcion_Adicional
        '
        Me.Lbl_Descripcion_Adicional.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Lbl_Descripcion_Adicional.BackgroundStyle.BackColor = System.Drawing.SystemColors.Control
        Me.Lbl_Descripcion_Adicional.BackgroundStyle.Class = "RibbonGalleryContainer"
        Me.Lbl_Descripcion_Adicional.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Descripcion_Adicional.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Descripcion_Adicional.Location = New System.Drawing.Point(156, 25)
        Me.Lbl_Descripcion_Adicional.Name = "Lbl_Descripcion_Adicional"
        Me.Lbl_Descripcion_Adicional.Size = New System.Drawing.Size(599, 16)
        Me.Lbl_Descripcion_Adicional.TabIndex = 84
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX1.ForeColor = System.Drawing.Color.Black
        Me.LabelX1.Location = New System.Drawing.Point(3, 69)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(147, 16)
        Me.LabelX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.LabelX1.TabIndex = 86
        Me.LabelX1.Text = "Razon social"
        '
        'GroupPanel1
        '
        Me.GroupPanel1.BackColor = System.Drawing.Color.White
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.ContextMenuBar1)
        Me.GroupPanel1.Controls.Add(Me.Grilla)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Location = New System.Drawing.Point(6, 12)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(770, 353)
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
        Me.GroupPanel1.TabIndex = 119
        Me.GroupPanel1.Text = "Para hacer gestión haga doble clic sobre la fila seleccionada"
        '
        'ContextMenuBar1
        '
        Me.ContextMenuBar1.AntiAlias = True
        Me.ContextMenuBar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ContextMenuBar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Menu_Contextual_01})
        Me.ContextMenuBar1.Location = New System.Drawing.Point(75, 43)
        Me.ContextMenuBar1.Name = "ContextMenuBar1"
        Me.ContextMenuBar1.Size = New System.Drawing.Size(153, 25)
        Me.ContextMenuBar1.Stretch = True
        Me.ContextMenuBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ContextMenuBar1.TabIndex = 81
        Me.ContextMenuBar1.TabStop = False
        Me.ContextMenuBar1.Text = "ContextMenuBar1"
        '
        'Menu_Contextual_01
        '
        Me.Menu_Contextual_01.AutoExpandOnClick = True
        Me.Menu_Contextual_01.Name = "Menu_Contextual_01"
        Me.Menu_Contextual_01.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItem1, Me.Btn_Autorizar_Permiso, Me.Btn_Rechazar_Permiso, Me.Lbl_Opciones_adicionales, Me.Btn_Ver_deuda_pendiente})
        Me.Menu_Contextual_01.Text = "Opciones Remotas"
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
        Me.LabelItem1.Text = "Acción"
        '
        'Btn_Autorizar_Permiso
        '
        Me.Btn_Autorizar_Permiso.Image = CType(resources.GetObject("Btn_Autorizar_Permiso.Image"), System.Drawing.Image)
        Me.Btn_Autorizar_Permiso.Name = "Btn_Autorizar_Permiso"
        Me.Btn_Autorizar_Permiso.Text = "AUTORIZAR"
        '
        'Btn_Rechazar_Permiso
        '
        Me.Btn_Rechazar_Permiso.Image = CType(resources.GetObject("Btn_Rechazar_Permiso.Image"), System.Drawing.Image)
        Me.Btn_Rechazar_Permiso.Name = "Btn_Rechazar_Permiso"
        Me.Btn_Rechazar_Permiso.Text = "RECHAZAR"
        '
        'Lbl_Opciones_adicionales
        '
        Me.Lbl_Opciones_adicionales.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.Lbl_Opciones_adicionales.BorderSide = DevComponents.DotNetBar.eBorderSide.Bottom
        Me.Lbl_Opciones_adicionales.BorderType = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.Lbl_Opciones_adicionales.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(21, Byte), Integer), CType(CType(110, Byte), Integer))
        Me.Lbl_Opciones_adicionales.Name = "Lbl_Opciones_adicionales"
        Me.Lbl_Opciones_adicionales.PaddingBottom = 1
        Me.Lbl_Opciones_adicionales.PaddingLeft = 10
        Me.Lbl_Opciones_adicionales.PaddingTop = 1
        Me.Lbl_Opciones_adicionales.SingleLineColor = System.Drawing.Color.FromArgb(CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer))
        Me.Lbl_Opciones_adicionales.Text = "Opciones adicionales"
        '
        'Btn_Ver_deuda_pendiente
        '
        Me.Btn_Ver_deuda_pendiente.Image = CType(resources.GetObject("Btn_Ver_deuda_pendiente.Image"), System.Drawing.Image)
        Me.Btn_Ver_deuda_pendiente.Name = "Btn_Ver_deuda_pendiente"
        Me.Btn_Ver_deuda_pendiente.Text = "Ver deuda pendiente"
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
        Me.Grilla.MultiSelect = False
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
        Me.Grilla.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.Grilla.Size = New System.Drawing.Size(764, 330)
        Me.Grilla.TabIndex = 1
        '
        'TableLayoutPanel4
        '
        Me.TableLayoutPanel4.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel4.ColumnCount = 2
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.31662!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 79.68338!))
        Me.TableLayoutPanel4.Controls.Add(Me.Lbl_TotalBruto, 1, 2)
        Me.TableLayoutPanel4.Controls.Add(Me.LabelX1, 0, 3)
        Me.TableLayoutPanel4.Controls.Add(Me.Lbl_Descripcion_Adicional, 1, 1)
        Me.TableLayoutPanel4.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.Lbl_Nombre_Solicitante, 1, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.LabelX18, 0, 1)
        Me.TableLayoutPanel4.Controls.Add(Me.LabelX19, 0, 2)
        Me.TableLayoutPanel4.Controls.Add(Me.Lbl_Descripcion_del_permiso, 1, 3)
        Me.TableLayoutPanel4.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel4.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        Me.TableLayoutPanel4.RowCount = 4
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel4.Size = New System.Drawing.Size(758, 88)
        Me.TableLayoutPanel4.TabIndex = 83
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Label1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(3, 3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(147, 16)
        Me.Label1.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Label1.TabIndex = 64
        Me.Label1.Text = "Funcionario solicitante"
        '
        'Lbl_Nombre_Solicitante
        '
        Me.Lbl_Nombre_Solicitante.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Lbl_Nombre_Solicitante.BackgroundStyle.BackColor = System.Drawing.SystemColors.Control
        Me.Lbl_Nombre_Solicitante.BackgroundStyle.Class = "RibbonGalleryContainer"
        Me.Lbl_Nombre_Solicitante.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Nombre_Solicitante.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Nombre_Solicitante.Location = New System.Drawing.Point(156, 3)
        Me.Lbl_Nombre_Solicitante.Name = "Lbl_Nombre_Solicitante"
        Me.Lbl_Nombre_Solicitante.Size = New System.Drawing.Size(599, 16)
        Me.Lbl_Nombre_Solicitante.TabIndex = 81
        '
        'LabelX18
        '
        Me.LabelX18.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX18.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX18.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX18.ForeColor = System.Drawing.Color.Black
        Me.LabelX18.Location = New System.Drawing.Point(3, 25)
        Me.LabelX18.Name = "LabelX18"
        Me.LabelX18.Size = New System.Drawing.Size(147, 16)
        Me.LabelX18.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.LabelX18.TabIndex = 61
        Me.LabelX18.Text = "Antecedentes adicionales"
        '
        'LabelX19
        '
        Me.LabelX19.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX19.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX19.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX19.ForeColor = System.Drawing.Color.Black
        Me.LabelX19.Location = New System.Drawing.Point(3, 47)
        Me.LabelX19.Name = "LabelX19"
        Me.LabelX19.Size = New System.Drawing.Size(147, 16)
        Me.LabelX19.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.LabelX19.TabIndex = 59
        Me.LabelX19.Text = "Monto del documento"
        '
        'Lbl_Descripcion_del_permiso
        '
        Me.Lbl_Descripcion_del_permiso.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Lbl_Descripcion_del_permiso.BackgroundStyle.BackColor = System.Drawing.SystemColors.Control
        Me.Lbl_Descripcion_del_permiso.BackgroundStyle.Class = "RibbonGalleryContainer"
        Me.Lbl_Descripcion_del_permiso.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Descripcion_del_permiso.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Descripcion_del_permiso.Location = New System.Drawing.Point(156, 69)
        Me.Lbl_Descripcion_del_permiso.Name = "Lbl_Descripcion_del_permiso"
        Me.Lbl_Descripcion_del_permiso.Size = New System.Drawing.Size(599, 16)
        Me.Lbl_Descripcion_del_permiso.TabIndex = 87
        '
        'GroupPanel2
        '
        Me.GroupPanel2.BackColor = System.Drawing.Color.White
        Me.GroupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel2.Controls.Add(Me.TableLayoutPanel4)
        Me.GroupPanel2.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel2.Location = New System.Drawing.Point(6, 379)
        Me.GroupPanel2.Name = "GroupPanel2"
        Me.GroupPanel2.Size = New System.Drawing.Size(770, 123)
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
        Me.GroupPanel2.TabIndex = 121
        Me.GroupPanel2.Text = "Información adicional de la línea activa"
        '
        'Btn_Cambiar_de_empresa
        '
        Me.Btn_Cambiar_de_empresa.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Cambiar_de_empresa.ForeColor = System.Drawing.Color.Black
        Me.Btn_Cambiar_de_empresa.Image = CType(resources.GetObject("Btn_Cambiar_de_empresa.Image"), System.Drawing.Image)
        Me.Btn_Cambiar_de_empresa.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.Btn_Cambiar_de_empresa.Name = "Btn_Cambiar_de_empresa"
        Me.Btn_Cambiar_de_empresa.Text = "Cambiar de empresa"
        '
        'Btn_Refresh
        '
        Me.Btn_Refresh.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Refresh.ForeColor = System.Drawing.Color.Black
        Me.Btn_Refresh.Image = CType(resources.GetObject("Btn_Refresh.Image"), System.Drawing.Image)
        Me.Btn_Refresh.Name = "Btn_Refresh"
        Me.Btn_Refresh.Text = "Refresh"
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Refresh, Me.Btn_Cambiar_de_empresa})
        Me.Bar1.Location = New System.Drawing.Point(0, 520)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(784, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 120
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'Timer_Notificaciones
        '
        Me.Timer_Notificaciones.Interval = 10000
        '
        'Frm_Remotas_Rd
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 561)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Controls.Add(Me.GroupPanel2)
        Me.Controls.Add(Me.Bar1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Remotas_Rd"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "PERMISOS SOLICITADOS REMOTAMENTE, EMPRESA CONECTADA: {0}"
        Me.GroupPanel1.ResumeLayout(False)
        CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel4.ResumeLayout(False)
        Me.GroupPanel2.ResumeLayout(False)
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Lbl_TotalBruto As DevComponents.DotNetBar.LabelX
    Friend WithEvents Lbl_Descripcion_Adicional As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents ContextMenuBar1 As DevComponents.DotNetBar.ContextMenuBar
    Friend WithEvents Menu_Contextual_01 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelItem1 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents Btn_Ver_deuda_pendiente As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Autorizar_Permiso As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Grilla As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents TableLayoutPanel4 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Lbl_Nombre_Solicitante As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX18 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX19 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Lbl_Descripcion_del_permiso As DevComponents.DotNetBar.LabelX
    Friend WithEvents GroupPanel2 As DevComponents.DotNetBar.Controls.GroupPanel
    Public WithEvents Btn_Cambiar_de_empresa As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_Refresh As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents Timer_Notificaciones As System.Windows.Forms.Timer
    Friend WithEvents Btn_Rechazar_Permiso As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Lbl_Opciones_adicionales As DevComponents.DotNetBar.LabelItem
End Class
