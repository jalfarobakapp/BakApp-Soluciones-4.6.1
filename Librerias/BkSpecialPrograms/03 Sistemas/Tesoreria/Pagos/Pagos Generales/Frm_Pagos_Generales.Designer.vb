<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Pagos_Generales
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
        Dim DataGridViewCellStyle19 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle20 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle21 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle22 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle23 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle24 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Pagos_Generales))
        Dim DataGridViewCellStyle25 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle26 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle27 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Grupo_Pagos = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Grilla_Pagos = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.Grupo_Entidad = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Grilla_Encabezado = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.BtnGrabar = New DevComponents.DotNetBar.ButtonItem()
        Me.BtnActualizarLista = New DevComponents.DotNetBar.ButtonItem()
        Me.Grupo_Estado_Cta = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Grilla_Estado_de_Cuentas = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.Chk_Fecha_Asignacion = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Btn_Agregar_Pago = New DevComponents.DotNetBar.ButtonX()
        Me.Metro_Bar_Color = New DevComponents.DotNetBar.Metro.MetroStatusBar()
        Me.Lbl_Estatus = New DevComponents.DotNetBar.LabelItem()
        Me.Lbl_Banco_Cta_Cte = New DevComponents.DotNetBar.LabelX()
        Me.Btn_BuscarDocumento = New DevComponents.DotNetBar.ButtonItem()
        Me.Grupo_Pagos.SuspendLayout()
        CType(Me.Grilla_Pagos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Grupo_Entidad.SuspendLayout()
        CType(Me.Grilla_Encabezado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Grupo_Estado_Cta.SuspendLayout()
        CType(Me.Grilla_Estado_de_Cuentas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Grupo_Pagos
        '
        Me.Grupo_Pagos.BackColor = System.Drawing.Color.White
        Me.Grupo_Pagos.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Grupo_Pagos.Controls.Add(Me.Grilla_Pagos)
        Me.Grupo_Pagos.DisabledBackColor = System.Drawing.Color.Empty
        Me.Grupo_Pagos.Location = New System.Drawing.Point(12, 89)
        Me.Grupo_Pagos.Name = "Grupo_Pagos"
        Me.Grupo_Pagos.Size = New System.Drawing.Size(760, 139)
        '
        '
        '
        Me.Grupo_Pagos.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Grupo_Pagos.Style.BackColorGradientAngle = 90
        Me.Grupo_Pagos.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Grupo_Pagos.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Pagos.Style.BorderBottomWidth = 1
        Me.Grupo_Pagos.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.Grupo_Pagos.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Pagos.Style.BorderLeftWidth = 1
        Me.Grupo_Pagos.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Pagos.Style.BorderRightWidth = 1
        Me.Grupo_Pagos.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Pagos.Style.BorderTopWidth = 1
        Me.Grupo_Pagos.Style.CornerDiameter = 4
        Me.Grupo_Pagos.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Grupo_Pagos.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.Grupo_Pagos.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.Grupo_Pagos.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.Grupo_Pagos.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.Grupo_Pagos.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Grupo_Pagos.TabIndex = 33
        Me.Grupo_Pagos.Text = "Registro de Pagos"
        '
        'Grilla_Pagos
        '
        Me.Grilla_Pagos.AllowUserToAddRows = False
        Me.Grilla_Pagos.AllowUserToDeleteRows = False
        Me.Grilla_Pagos.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle19.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle19.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle19.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle19.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle19.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla_Pagos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle19
        Me.Grilla_Pagos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle20.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle20.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle20.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle20.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle20.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Grilla_Pagos.DefaultCellStyle = DataGridViewCellStyle20
        Me.Grilla_Pagos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grilla_Pagos.EnableHeadersVisualStyles = False
        Me.Grilla_Pagos.GridColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.Grilla_Pagos.Location = New System.Drawing.Point(0, 0)
        Me.Grilla_Pagos.Name = "Grilla_Pagos"
        DataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle21.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle21.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle21.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle21.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle21.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle21.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla_Pagos.RowHeadersDefaultCellStyle = DataGridViewCellStyle21
        Me.Grilla_Pagos.Size = New System.Drawing.Size(754, 116)
        Me.Grilla_Pagos.StandardTab = True
        Me.Grilla_Pagos.TabIndex = 1
        '
        'Grupo_Entidad
        '
        Me.Grupo_Entidad.BackColor = System.Drawing.Color.White
        Me.Grupo_Entidad.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Grupo_Entidad.Controls.Add(Me.Grilla_Encabezado)
        Me.Grupo_Entidad.DisabledBackColor = System.Drawing.Color.Empty
        Me.Grupo_Entidad.Location = New System.Drawing.Point(12, 23)
        Me.Grupo_Entidad.Name = "Grupo_Entidad"
        Me.Grupo_Entidad.Size = New System.Drawing.Size(760, 60)
        '
        '
        '
        Me.Grupo_Entidad.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Grupo_Entidad.Style.BackColorGradientAngle = 90
        Me.Grupo_Entidad.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Grupo_Entidad.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Entidad.Style.BorderBottomWidth = 1
        Me.Grupo_Entidad.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.Grupo_Entidad.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Entidad.Style.BorderLeftWidth = 1
        Me.Grupo_Entidad.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Entidad.Style.BorderRightWidth = 1
        Me.Grupo_Entidad.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Entidad.Style.BorderTopWidth = 1
        Me.Grupo_Entidad.Style.CornerDiameter = 4
        Me.Grupo_Entidad.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Grupo_Entidad.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.Grupo_Entidad.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.Grupo_Entidad.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.Grupo_Entidad.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.Grupo_Entidad.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Grupo_Entidad.TabIndex = 34
        Me.Grupo_Entidad.Text = "Datos de la entidad"
        '
        'Grilla_Encabezado
        '
        Me.Grilla_Encabezado.AllowUserToAddRows = False
        Me.Grilla_Encabezado.AllowUserToDeleteRows = False
        Me.Grilla_Encabezado.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle22.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle22.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle22.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle22.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle22.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle22.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla_Encabezado.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle22
        Me.Grilla_Encabezado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle23.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle23.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle23.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle23.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle23.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle23.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Grilla_Encabezado.DefaultCellStyle = DataGridViewCellStyle23
        Me.Grilla_Encabezado.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grilla_Encabezado.EnableHeadersVisualStyles = False
        Me.Grilla_Encabezado.GridColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.Grilla_Encabezado.Location = New System.Drawing.Point(0, 0)
        Me.Grilla_Encabezado.Name = "Grilla_Encabezado"
        DataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle24.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle24.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle24.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle24.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle24.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle24.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla_Encabezado.RowHeadersDefaultCellStyle = DataGridViewCellStyle24
        Me.Grilla_Encabezado.Size = New System.Drawing.Size(754, 37)
        Me.Grilla_Encabezado.StandardTab = True
        Me.Grilla_Encabezado.TabIndex = 0
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.BtnGrabar, Me.BtnActualizarLista, Me.Btn_BuscarDocumento})
        Me.Bar1.Location = New System.Drawing.Point(0, 575)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(784, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 35
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'BtnGrabar
        '
        Me.BtnGrabar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnGrabar.ForeColor = System.Drawing.Color.Black
        Me.BtnGrabar.Image = CType(resources.GetObject("BtnGrabar.Image"), System.Drawing.Image)
        Me.BtnGrabar.ImageAlt = CType(resources.GetObject("BtnGrabar.ImageAlt"), System.Drawing.Image)
        Me.BtnGrabar.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.BtnGrabar.Name = "BtnGrabar"
        Me.BtnGrabar.Tooltip = "Grabar [F4]"
        '
        'BtnActualizarLista
        '
        Me.BtnActualizarLista.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnActualizarLista.ForeColor = System.Drawing.Color.Black
        Me.BtnActualizarLista.Image = CType(resources.GetObject("BtnActualizarLista.Image"), System.Drawing.Image)
        Me.BtnActualizarLista.ImageAlt = CType(resources.GetObject("BtnActualizarLista.ImageAlt"), System.Drawing.Image)
        Me.BtnActualizarLista.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.BtnActualizarLista.Name = "BtnActualizarLista"
        Me.BtnActualizarLista.Tooltip = "Limpiar"
        '
        'Grupo_Estado_Cta
        '
        Me.Grupo_Estado_Cta.BackColor = System.Drawing.Color.White
        Me.Grupo_Estado_Cta.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Grupo_Estado_Cta.Controls.Add(Me.Grilla_Estado_de_Cuentas)
        Me.Grupo_Estado_Cta.DisabledBackColor = System.Drawing.Color.Empty
        Me.Grupo_Estado_Cta.Location = New System.Drawing.Point(9, 263)
        Me.Grupo_Estado_Cta.Name = "Grupo_Estado_Cta"
        Me.Grupo_Estado_Cta.Size = New System.Drawing.Size(760, 306)
        '
        '
        '
        Me.Grupo_Estado_Cta.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Grupo_Estado_Cta.Style.BackColorGradientAngle = 90
        Me.Grupo_Estado_Cta.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Grupo_Estado_Cta.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Estado_Cta.Style.BorderBottomWidth = 1
        Me.Grupo_Estado_Cta.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.Grupo_Estado_Cta.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Estado_Cta.Style.BorderLeftWidth = 1
        Me.Grupo_Estado_Cta.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Estado_Cta.Style.BorderRightWidth = 1
        Me.Grupo_Estado_Cta.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Estado_Cta.Style.BorderTopWidth = 1
        Me.Grupo_Estado_Cta.Style.CornerDiameter = 4
        Me.Grupo_Estado_Cta.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Grupo_Estado_Cta.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.Grupo_Estado_Cta.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.Grupo_Estado_Cta.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.Grupo_Estado_Cta.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.Grupo_Estado_Cta.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Grupo_Estado_Cta.TabIndex = 36
        Me.Grupo_Estado_Cta.Text = "Estado de cuenta"
        '
        'Grilla_Estado_de_Cuentas
        '
        Me.Grilla_Estado_de_Cuentas.AllowUserToAddRows = False
        Me.Grilla_Estado_de_Cuentas.AllowUserToDeleteRows = False
        Me.Grilla_Estado_de_Cuentas.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle25.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle25.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle25.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle25.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle25.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle25.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle25.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla_Estado_de_Cuentas.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle25
        Me.Grilla_Estado_de_Cuentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle26.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle26.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle26.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle26.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle26.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle26.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle26.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Grilla_Estado_de_Cuentas.DefaultCellStyle = DataGridViewCellStyle26
        Me.Grilla_Estado_de_Cuentas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grilla_Estado_de_Cuentas.EnableHeadersVisualStyles = False
        Me.Grilla_Estado_de_Cuentas.GridColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.Grilla_Estado_de_Cuentas.Location = New System.Drawing.Point(0, 0)
        Me.Grilla_Estado_de_Cuentas.Name = "Grilla_Estado_de_Cuentas"
        DataGridViewCellStyle27.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle27.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle27.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle27.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle27.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle27.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle27.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla_Estado_de_Cuentas.RowHeadersDefaultCellStyle = DataGridViewCellStyle27
        Me.Grilla_Estado_de_Cuentas.Size = New System.Drawing.Size(754, 283)
        Me.Grilla_Estado_de_Cuentas.StandardTab = True
        Me.Grilla_Estado_de_Cuentas.TabIndex = 2
        '
        'Chk_Fecha_Asignacion
        '
        Me.Chk_Fecha_Asignacion.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Chk_Fecha_Asignacion.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Fecha_Asignacion.ForeColor = System.Drawing.Color.Black
        Me.Chk_Fecha_Asignacion.Location = New System.Drawing.Point(535, 3)
        Me.Chk_Fecha_Asignacion.Name = "Chk_Fecha_Asignacion"
        Me.Chk_Fecha_Asignacion.Size = New System.Drawing.Size(237, 23)
        Me.Chk_Fecha_Asignacion.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Fecha_Asignacion.TabIndex = 37
        Me.Chk_Fecha_Asignacion.Text = "Fecha de asignación del pago. Fecha actual"
        '
        'Btn_Agregar_Pago
        '
        Me.Btn_Agregar_Pago.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Agregar_Pago.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Agregar_Pago.Image = CType(resources.GetObject("Btn_Agregar_Pago.Image"), System.Drawing.Image)
        Me.Btn_Agregar_Pago.ImageAlt = CType(resources.GetObject("Btn_Agregar_Pago.ImageAlt"), System.Drawing.Image)
        Me.Btn_Agregar_Pago.Location = New System.Drawing.Point(12, 231)
        Me.Btn_Agregar_Pago.Name = "Btn_Agregar_Pago"
        Me.Btn_Agregar_Pago.Size = New System.Drawing.Size(93, 26)
        Me.Btn_Agregar_Pago.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Agregar_Pago.TabIndex = 51
        Me.Btn_Agregar_Pago.Text = "Agregar Reg."
        Me.Btn_Agregar_Pago.Tooltip = "Agregar un nuevo registro"
        '
        'Metro_Bar_Color
        '
        Me.Metro_Bar_Color.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Metro_Bar_Color.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Metro_Bar_Color.ContainerControlProcessDialogKey = True
        Me.Metro_Bar_Color.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Metro_Bar_Color.DragDropSupport = True
        Me.Metro_Bar_Color.Font = New System.Drawing.Font("Segoe UI", 10.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Metro_Bar_Color.ForeColor = System.Drawing.Color.Black
        Me.Metro_Bar_Color.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Lbl_Estatus})
        Me.Metro_Bar_Color.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.Metro_Bar_Color.Location = New System.Drawing.Point(0, 616)
        Me.Metro_Bar_Color.Name = "Metro_Bar_Color"
        Me.Metro_Bar_Color.Size = New System.Drawing.Size(784, 22)
        Me.Metro_Bar_Color.TabIndex = 56
        Me.Metro_Bar_Color.Text = "MetroStatusBar1"
        '
        'Lbl_Estatus
        '
        Me.Lbl_Estatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Estatus.Name = "Lbl_Estatus"
        Me.Lbl_Estatus.Text = "LabelItem2"
        '
        'Lbl_Banco_Cta_Cte
        '
        Me.Lbl_Banco_Cta_Cte.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_Banco_Cta_Cte.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Banco_Cta_Cte.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Banco_Cta_Cte.Location = New System.Drawing.Point(111, 234)
        Me.Lbl_Banco_Cta_Cte.Name = "Lbl_Banco_Cta_Cte"
        Me.Lbl_Banco_Cta_Cte.Size = New System.Drawing.Size(661, 13)
        Me.Lbl_Banco_Cta_Cte.TabIndex = 57
        Me.Lbl_Banco_Cta_Cte.Text = "..."
        '
        'Btn_BuscarDocumento
        '
        Me.Btn_BuscarDocumento.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_BuscarDocumento.ForeColor = System.Drawing.Color.Black
        Me.Btn_BuscarDocumento.Image = CType(resources.GetObject("Btn_BuscarDocumento.Image"), System.Drawing.Image)
        Me.Btn_BuscarDocumento.ImageAlt = CType(resources.GetObject("Btn_BuscarDocumento.ImageAlt"), System.Drawing.Image)
        Me.Btn_BuscarDocumento.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.Btn_BuscarDocumento.Name = "Btn_BuscarDocumento"
        Me.Btn_BuscarDocumento.Tooltip = "Buscar documento en listado de estado de cuenta"
        '
        'Frm_Pagos_Generales
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 638)
        Me.Controls.Add(Me.Lbl_Banco_Cta_Cte)
        Me.Controls.Add(Me.Btn_Agregar_Pago)
        Me.Controls.Add(Me.Chk_Fecha_Asignacion)
        Me.Controls.Add(Me.Grupo_Estado_Cta)
        Me.Controls.Add(Me.Bar1)
        Me.Controls.Add(Me.Grupo_Entidad)
        Me.Controls.Add(Me.Grupo_Pagos)
        Me.Controls.Add(Me.Metro_Bar_Color)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Pagos_Generales"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MetroForm"
        Me.Grupo_Pagos.ResumeLayout(False)
        CType(Me.Grilla_Pagos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Grupo_Entidad.ResumeLayout(False)
        CType(Me.Grilla_Encabezado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Grupo_Estado_Cta.ResumeLayout(False)
        CType(Me.Grilla_Estado_de_Cuentas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Grupo_Pagos As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Grupo_Entidad As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents BtnActualizarLista As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Grupo_Estado_Cta As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Chk_Fecha_Asignacion As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Grilla_Pagos As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents Grilla_Encabezado As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents Grilla_Estado_de_Cuentas As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents Btn_Agregar_Pago As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Metro_Bar_Color As DevComponents.DotNetBar.Metro.MetroStatusBar
    Friend WithEvents Lbl_Estatus As DevComponents.DotNetBar.LabelItem
    Friend WithEvents BtnGrabar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Lbl_Banco_Cta_Cte As DevComponents.DotNetBar.LabelX
    Friend WithEvents Btn_BuscarDocumento As DevComponents.DotNetBar.ButtonItem
End Class
