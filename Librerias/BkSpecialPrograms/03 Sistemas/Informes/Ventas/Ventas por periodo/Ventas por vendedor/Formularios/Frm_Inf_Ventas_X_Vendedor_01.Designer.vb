<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Inf_Ventas_X_Vendedor_01
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Inf_Ventas_X_Vendedor_01))
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Procesar = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Modificar_Filtros = New DevComponents.DotNetBar.ButtonItem()
        Me.GroupPanel2 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Dtp_Fecha_Estudio_desde = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Dtp_Fecha_Estudio_hasta = New System.Windows.Forms.DateTimePicker()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Rdb_Vendedores_Algunos = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_Vendedores_Todos = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Grupo_Vendedores = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Grupo_Sucursales = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.Rdb_Sucursales_Algunos = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_Sucursales_Todos = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Grupo_Clientes = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.CheckBoxX11 = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.CheckBoxX12 = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Grupo_Documentos = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel()
        Me.Rdb_Documentos_Algunos = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_Documentos_Todos = New DevComponents.DotNetBar.Controls.CheckBoxX()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel2.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Grupo_Vendedores.SuspendLayout()
        Me.Grupo_Sucursales.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.Grupo_Clientes.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.Grupo_Documentos.SuspendLayout()
        Me.TableLayoutPanel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Procesar, Me.Btn_Modificar_Filtros})
        Me.Bar1.Location = New System.Drawing.Point(0, 297)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(329, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 89
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'Btn_Procesar
        '
        Me.Btn_Procesar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Procesar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Procesar.Image = CType(resources.GetObject("Btn_Procesar.Image"), System.Drawing.Image)
        Me.Btn_Procesar.Name = "Btn_Procesar"
        Me.Btn_Procesar.Tooltip = "Grabar"
        '
        'Btn_Modificar_Filtros
        '
        Me.Btn_Modificar_Filtros.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Modificar_Filtros.ForeColor = System.Drawing.Color.Black
        Me.Btn_Modificar_Filtros.Image = CType(resources.GetObject("Btn_Modificar_Filtros.Image"), System.Drawing.Image)
        Me.Btn_Modificar_Filtros.Name = "Btn_Modificar_Filtros"
        Me.Btn_Modificar_Filtros.Tooltip = "Modificar filtro"
        '
        'GroupPanel2
        '
        Me.GroupPanel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GroupPanel2.CanvasColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GroupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel2.Controls.Add(Me.Dtp_Fecha_Estudio_desde)
        Me.GroupPanel2.Controls.Add(Me.Label4)
        Me.GroupPanel2.Controls.Add(Me.Label5)
        Me.GroupPanel2.Controls.Add(Me.Dtp_Fecha_Estudio_hasta)
        Me.GroupPanel2.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel2.Location = New System.Drawing.Point(5, 24)
        Me.GroupPanel2.Name = "GroupPanel2"
        Me.GroupPanel2.Size = New System.Drawing.Size(314, 72)
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
        Me.GroupPanel2.TabIndex = 91
        Me.GroupPanel2.Text = "Rando de fecha periodo anterior"
        '
        'Dtp_Fecha_Estudio_desde
        '
        Me.Dtp_Fecha_Estudio_desde.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Dtp_Fecha_Estudio_desde.ForeColor = System.Drawing.Color.Black
        Me.Dtp_Fecha_Estudio_desde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Dtp_Fecha_Estudio_desde.Location = New System.Drawing.Point(51, 15)
        Me.Dtp_Fecha_Estudio_desde.Name = "Dtp_Fecha_Estudio_desde"
        Me.Dtp_Fecha_Estudio_desde.Size = New System.Drawing.Size(102, 22)
        Me.Dtp_Fecha_Estudio_desde.TabIndex = 0
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(159, 22)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(36, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Hasta"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(6, 22)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(39, 13)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "Desde"
        '
        'Dtp_Fecha_Estudio_hasta
        '
        Me.Dtp_Fecha_Estudio_hasta.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Dtp_Fecha_Estudio_hasta.ForeColor = System.Drawing.Color.Black
        Me.Dtp_Fecha_Estudio_hasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Dtp_Fecha_Estudio_hasta.Location = New System.Drawing.Point(201, 15)
        Me.Dtp_Fecha_Estudio_hasta.Name = "Dtp_Fecha_Estudio_hasta"
        Me.Dtp_Fecha_Estudio_hasta.Size = New System.Drawing.Size(97, 22)
        Me.Dtp_Fecha_Estudio_hasta.TabIndex = 1
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.Controls.Add(Me.Rdb_Vendedores_Algunos, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Rdb_Vendedores_Todos, 1, 0)
        Me.TableLayoutPanel1.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(9, 3)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(296, 23)
        Me.TableLayoutPanel1.TabIndex = 6
        '
        'Rdb_Vendedores_Algunos
        '
        Me.Rdb_Vendedores_Algunos.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Vendedores_Algunos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Vendedores_Algunos.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Vendedores_Algunos.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Vendedores_Algunos.Location = New System.Drawing.Point(109, 3)
        Me.Rdb_Vendedores_Algunos.Name = "Rdb_Vendedores_Algunos"
        Me.Rdb_Vendedores_Algunos.Size = New System.Drawing.Size(180, 17)
        Me.Rdb_Vendedores_Algunos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Vendedores_Algunos.TabIndex = 7
        Me.Rdb_Vendedores_Algunos.Text = "Algunos"
        '
        'Rdb_Vendedores_Todos
        '
        Me.Rdb_Vendedores_Todos.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Vendedores_Todos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Vendedores_Todos.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Vendedores_Todos.Checked = True
        Me.Rdb_Vendedores_Todos.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Rdb_Vendedores_Todos.CheckValue = "Y"
        Me.Rdb_Vendedores_Todos.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Vendedores_Todos.Location = New System.Drawing.Point(3, 3)
        Me.Rdb_Vendedores_Todos.Name = "Rdb_Vendedores_Todos"
        Me.Rdb_Vendedores_Todos.Size = New System.Drawing.Size(100, 16)
        Me.Rdb_Vendedores_Todos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Vendedores_Todos.TabIndex = 1
        Me.Rdb_Vendedores_Todos.Text = "Todos"
        '
        'Grupo_Vendedores
        '
        Me.Grupo_Vendedores.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Grupo_Vendedores.CanvasColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Grupo_Vendedores.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Grupo_Vendedores.Controls.Add(Me.TableLayoutPanel1)
        Me.Grupo_Vendedores.DisabledBackColor = System.Drawing.Color.Empty
        Me.Grupo_Vendedores.Enabled = False
        Me.Grupo_Vendedores.Location = New System.Drawing.Point(5, 102)
        Me.Grupo_Vendedores.Name = "Grupo_Vendedores"
        Me.Grupo_Vendedores.Size = New System.Drawing.Size(314, 58)
        '
        '
        '
        Me.Grupo_Vendedores.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Grupo_Vendedores.Style.BackColorGradientAngle = 90
        Me.Grupo_Vendedores.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Grupo_Vendedores.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Vendedores.Style.BorderBottomWidth = 1
        Me.Grupo_Vendedores.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.Grupo_Vendedores.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Vendedores.Style.BorderLeftWidth = 1
        Me.Grupo_Vendedores.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Vendedores.Style.BorderRightWidth = 1
        Me.Grupo_Vendedores.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Vendedores.Style.BorderTopWidth = 1
        Me.Grupo_Vendedores.Style.CornerDiameter = 4
        Me.Grupo_Vendedores.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Grupo_Vendedores.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.Grupo_Vendedores.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.Grupo_Vendedores.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.Grupo_Vendedores.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.Grupo_Vendedores.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Grupo_Vendedores.TabIndex = 90
        Me.Grupo_Vendedores.Text = "Vendedores"
        '
        'Grupo_Sucursales
        '
        Me.Grupo_Sucursales.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Grupo_Sucursales.CanvasColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Grupo_Sucursales.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Grupo_Sucursales.Controls.Add(Me.TableLayoutPanel2)
        Me.Grupo_Sucursales.DisabledBackColor = System.Drawing.Color.Empty
        Me.Grupo_Sucursales.Enabled = False
        Me.Grupo_Sucursales.Location = New System.Drawing.Point(5, 166)
        Me.Grupo_Sucursales.Name = "Grupo_Sucursales"
        Me.Grupo_Sucursales.Size = New System.Drawing.Size(314, 58)
        '
        '
        '
        Me.Grupo_Sucursales.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Grupo_Sucursales.Style.BackColorGradientAngle = 90
        Me.Grupo_Sucursales.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Grupo_Sucursales.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Sucursales.Style.BorderBottomWidth = 1
        Me.Grupo_Sucursales.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.Grupo_Sucursales.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Sucursales.Style.BorderLeftWidth = 1
        Me.Grupo_Sucursales.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Sucursales.Style.BorderRightWidth = 1
        Me.Grupo_Sucursales.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Sucursales.Style.BorderTopWidth = 1
        Me.Grupo_Sucursales.Style.CornerDiameter = 4
        Me.Grupo_Sucursales.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Grupo_Sucursales.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.Grupo_Sucursales.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.Grupo_Sucursales.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.Grupo_Sucursales.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.Grupo_Sucursales.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Grupo_Sucursales.TabIndex = 93
        Me.Grupo_Sucursales.Text = "Sucursales"
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel2.ColumnCount = 3
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.Controls.Add(Me.Rdb_Sucursales_Algunos, 2, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Rdb_Sucursales_Todos, 1, 0)
        Me.TableLayoutPanel2.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(9, 3)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(296, 23)
        Me.TableLayoutPanel2.TabIndex = 6
        '
        'Rdb_Sucursales_Algunos
        '
        Me.Rdb_Sucursales_Algunos.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Sucursales_Algunos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Sucursales_Algunos.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Sucursales_Algunos.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Sucursales_Algunos.Location = New System.Drawing.Point(109, 3)
        Me.Rdb_Sucursales_Algunos.Name = "Rdb_Sucursales_Algunos"
        Me.Rdb_Sucursales_Algunos.Size = New System.Drawing.Size(180, 16)
        Me.Rdb_Sucursales_Algunos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Sucursales_Algunos.TabIndex = 7
        Me.Rdb_Sucursales_Algunos.Text = "Algunos"
        '
        'Rdb_Sucursales_Todos
        '
        Me.Rdb_Sucursales_Todos.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Sucursales_Todos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Sucursales_Todos.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Sucursales_Todos.Checked = True
        Me.Rdb_Sucursales_Todos.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Rdb_Sucursales_Todos.CheckValue = "Y"
        Me.Rdb_Sucursales_Todos.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Sucursales_Todos.Location = New System.Drawing.Point(3, 3)
        Me.Rdb_Sucursales_Todos.Name = "Rdb_Sucursales_Todos"
        Me.Rdb_Sucursales_Todos.Size = New System.Drawing.Size(100, 16)
        Me.Rdb_Sucursales_Todos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Sucursales_Todos.TabIndex = 1
        Me.Rdb_Sucursales_Todos.Text = "Todos"
        '
        'Grupo_Clientes
        '
        Me.Grupo_Clientes.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Grupo_Clientes.CanvasColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Grupo_Clientes.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Grupo_Clientes.Controls.Add(Me.TableLayoutPanel3)
        Me.Grupo_Clientes.DisabledBackColor = System.Drawing.Color.Empty
        Me.Grupo_Clientes.Location = New System.Drawing.Point(344, 21)
        Me.Grupo_Clientes.Name = "Grupo_Clientes"
        Me.Grupo_Clientes.Size = New System.Drawing.Size(314, 58)
        '
        '
        '
        Me.Grupo_Clientes.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Grupo_Clientes.Style.BackColorGradientAngle = 90
        Me.Grupo_Clientes.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Grupo_Clientes.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Clientes.Style.BorderBottomWidth = 1
        Me.Grupo_Clientes.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.Grupo_Clientes.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Clientes.Style.BorderLeftWidth = 1
        Me.Grupo_Clientes.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Clientes.Style.BorderRightWidth = 1
        Me.Grupo_Clientes.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Clientes.Style.BorderTopWidth = 1
        Me.Grupo_Clientes.Style.CornerDiameter = 4
        Me.Grupo_Clientes.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Grupo_Clientes.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.Grupo_Clientes.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.Grupo_Clientes.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.Grupo_Clientes.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.Grupo_Clientes.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Grupo_Clientes.TabIndex = 94
        Me.Grupo_Clientes.Text = "Clientes"
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel3.ColumnCount = 3
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel3.Controls.Add(Me.CheckBoxX11, 2, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.CheckBoxX12, 1, 0)
        Me.TableLayoutPanel3.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(9, 3)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 1
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(296, 23)
        Me.TableLayoutPanel3.TabIndex = 6
        '
        'CheckBoxX11
        '
        Me.CheckBoxX11.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.CheckBoxX11.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.CheckBoxX11.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.CheckBoxX11.ForeColor = System.Drawing.Color.Black
        Me.CheckBoxX11.Location = New System.Drawing.Point(109, 3)
        Me.CheckBoxX11.Name = "CheckBoxX11"
        Me.CheckBoxX11.Size = New System.Drawing.Size(99, 16)
        Me.CheckBoxX11.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.CheckBoxX11.TabIndex = 7
        Me.CheckBoxX11.Text = "Algunos"
        '
        'CheckBoxX12
        '
        Me.CheckBoxX12.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.CheckBoxX12.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.CheckBoxX12.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.CheckBoxX12.Checked = True
        Me.CheckBoxX12.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBoxX12.CheckValue = "Y"
        Me.CheckBoxX12.ForeColor = System.Drawing.Color.Black
        Me.CheckBoxX12.Location = New System.Drawing.Point(3, 3)
        Me.CheckBoxX12.Name = "CheckBoxX12"
        Me.CheckBoxX12.Size = New System.Drawing.Size(100, 16)
        Me.CheckBoxX12.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.CheckBoxX12.TabIndex = 1
        Me.CheckBoxX12.Text = "Todos"
        '
        'Grupo_Documentos
        '
        Me.Grupo_Documentos.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Grupo_Documentos.CanvasColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Grupo_Documentos.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Grupo_Documentos.Controls.Add(Me.TableLayoutPanel4)
        Me.Grupo_Documentos.DisabledBackColor = System.Drawing.Color.Empty
        Me.Grupo_Documentos.Enabled = False
        Me.Grupo_Documentos.Location = New System.Drawing.Point(5, 230)
        Me.Grupo_Documentos.Name = "Grupo_Documentos"
        Me.Grupo_Documentos.Size = New System.Drawing.Size(314, 58)
        '
        '
        '
        Me.Grupo_Documentos.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Grupo_Documentos.Style.BackColorGradientAngle = 90
        Me.Grupo_Documentos.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Grupo_Documentos.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Documentos.Style.BorderBottomWidth = 1
        Me.Grupo_Documentos.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.Grupo_Documentos.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Documentos.Style.BorderLeftWidth = 1
        Me.Grupo_Documentos.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Documentos.Style.BorderRightWidth = 1
        Me.Grupo_Documentos.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Documentos.Style.BorderTopWidth = 1
        Me.Grupo_Documentos.Style.CornerDiameter = 4
        Me.Grupo_Documentos.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Grupo_Documentos.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.Grupo_Documentos.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.Grupo_Documentos.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.Grupo_Documentos.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.Grupo_Documentos.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Grupo_Documentos.TabIndex = 95
        Me.Grupo_Documentos.Text = "Documentos"
        '
        'TableLayoutPanel4
        '
        Me.TableLayoutPanel4.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel4.ColumnCount = 3
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel4.Controls.Add(Me.Rdb_Documentos_Algunos, 2, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.Rdb_Documentos_Todos, 1, 0)
        Me.TableLayoutPanel4.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel4.Location = New System.Drawing.Point(9, 3)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        Me.TableLayoutPanel4.RowCount = 1
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel4.Size = New System.Drawing.Size(296, 23)
        Me.TableLayoutPanel4.TabIndex = 6
        '
        'Rdb_Documentos_Algunos
        '
        Me.Rdb_Documentos_Algunos.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Documentos_Algunos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Documentos_Algunos.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Documentos_Algunos.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Documentos_Algunos.Location = New System.Drawing.Point(109, 3)
        Me.Rdb_Documentos_Algunos.Name = "Rdb_Documentos_Algunos"
        Me.Rdb_Documentos_Algunos.Size = New System.Drawing.Size(99, 16)
        Me.Rdb_Documentos_Algunos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Documentos_Algunos.TabIndex = 7
        Me.Rdb_Documentos_Algunos.Text = "Algunos"
        '
        'Rdb_Documentos_Todos
        '
        Me.Rdb_Documentos_Todos.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Documentos_Todos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Documentos_Todos.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Documentos_Todos.Checked = True
        Me.Rdb_Documentos_Todos.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Rdb_Documentos_Todos.CheckValue = "Y"
        Me.Rdb_Documentos_Todos.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Documentos_Todos.Location = New System.Drawing.Point(3, 3)
        Me.Rdb_Documentos_Todos.Name = "Rdb_Documentos_Todos"
        Me.Rdb_Documentos_Todos.Size = New System.Drawing.Size(100, 16)
        Me.Rdb_Documentos_Todos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Documentos_Todos.TabIndex = 1
        Me.Rdb_Documentos_Todos.Text = "Todos"
        '
        'Frm_Inf_Ventas_X_Vendedor_01
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(329, 338)
        Me.Controls.Add(Me.Grupo_Documentos)
        Me.Controls.Add(Me.Grupo_Clientes)
        Me.Controls.Add(Me.Grupo_Sucursales)
        Me.Controls.Add(Me.GroupPanel2)
        Me.Controls.Add(Me.Grupo_Vendedores)
        Me.Controls.Add(Me.Bar1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Inf_Ventas_X_Vendedor_01"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ventas por vendedor"
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel2.ResumeLayout(False)
        Me.GroupPanel2.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Grupo_Vendedores.ResumeLayout(False)
        Me.Grupo_Sucursales.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.Grupo_Clientes.ResumeLayout(False)
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.Grupo_Documentos.ResumeLayout(False)
        Me.TableLayoutPanel4.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents Btn_Procesar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents GroupPanel2 As DevComponents.DotNetBar.Controls.GroupPanel
    Public WithEvents Dtp_Fecha_Estudio_desde As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Public WithEvents Dtp_Fecha_Estudio_hasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Rdb_Vendedores_Algunos As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_Vendedores_Todos As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Rdb_Sucursales_Algunos As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_Sucursales_Todos As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents TableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents CheckBoxX11 As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents CheckBoxX12 As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents TableLayoutPanel4 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Rdb_Documentos_Algunos As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_Documentos_Todos As DevComponents.DotNetBar.Controls.CheckBoxX
    Public WithEvents Grupo_Vendedores As DevComponents.DotNetBar.Controls.GroupPanel
    Public WithEvents Grupo_Sucursales As DevComponents.DotNetBar.Controls.GroupPanel
    Public WithEvents Grupo_Clientes As DevComponents.DotNetBar.Controls.GroupPanel
    Public WithEvents Grupo_Documentos As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Btn_Modificar_Filtros As DevComponents.DotNetBar.ButtonItem
End Class
