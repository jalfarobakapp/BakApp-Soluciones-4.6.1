<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Informe_Gerencia_On_Line
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Informe_Gerencia_On_Line))
        Me.Tiempo_Espera = New System.Windows.Forms.Timer(Me.components)
        Me.Grupo_Venta_Diaria = New DevComponents.DotNetBar.Controls.GroupPanel
        Me.Grilla_Dia = New System.Windows.Forms.DataGridView
        Me.Grupo_Venta_Mensual = New DevComponents.DotNetBar.Controls.GroupPanel
        Me.Grilla_Mes = New System.Windows.Forms.DataGridView
        Me.Grupo_Venta_Anual = New DevComponents.DotNetBar.Controls.GroupPanel
        Me.Grilla_Anual = New System.Windows.Forms.DataGridView
        Me.Grupo_Guias_Diarias = New DevComponents.DotNetBar.Controls.GroupPanel
        Me.Grilla_Guias_Dia = New System.Windows.Forms.DataGridView
        Me.Grupo_Guias_Mensuales = New DevComponents.DotNetBar.Controls.GroupPanel
        Me.Grilla_Guias_Mensual = New System.Windows.Forms.DataGridView
        Me.Bar1 = New DevComponents.DotNetBar.Bar
        Me.BtnActualizar = New DevComponents.DotNetBar.ButtonItem
        Me.Chk_Incluir_Vales_Transitorios = New DevComponents.DotNetBar.CheckBoxItem
        Me.Btn_Ver_Datos_Ano_Anterior = New DevComponents.DotNetBar.ButtonItem
        Me.Btn_Ver_Datos_Otra_Fecha = New DevComponents.DotNetBar.ButtonItem
        Me.Btn_Filtro_Super_Familia = New DevComponents.DotNetBar.ButtonItem
        Me.Progreso_Circular_Espera = New DevComponents.DotNetBar.CircularProgressItem
        Me.BtnMinimizar = New DevComponents.DotNetBar.ButtonItem
        Me.Btn_Cerrar = New DevComponents.DotNetBar.ButtonItem
        Me.Grupo_Venta_Diaria.SuspendLayout()
        CType(Me.Grilla_Dia, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Grupo_Venta_Mensual.SuspendLayout()
        CType(Me.Grilla_Mes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Grupo_Venta_Anual.SuspendLayout()
        CType(Me.Grilla_Anual, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Grupo_Guias_Diarias.SuspendLayout()
        CType(Me.Grilla_Guias_Dia, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Grupo_Guias_Mensuales.SuspendLayout()
        CType(Me.Grilla_Guias_Mensual, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Tiempo_Espera
        '
        Me.Tiempo_Espera.Interval = 10000
        '
        'Grupo_Venta_Diaria
        '
        Me.Grupo_Venta_Diaria.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Grupo_Venta_Diaria.CanvasColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Grupo_Venta_Diaria.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Grupo_Venta_Diaria.Controls.Add(Me.Grilla_Dia)
        Me.Grupo_Venta_Diaria.DisabledBackColor = System.Drawing.Color.Empty
        Me.Grupo_Venta_Diaria.Location = New System.Drawing.Point(12, 47)
        Me.Grupo_Venta_Diaria.Name = "Grupo_Venta_Diaria"
        Me.Grupo_Venta_Diaria.Size = New System.Drawing.Size(384, 305)
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
        Me.Grupo_Venta_Diaria.TabIndex = 8
        Me.Grupo_Venta_Diaria.Text = "VENTAS POR SUCURSAL FECHA: 19/10/2016"
        '
        'Grilla_Dia
        '
        Me.Grilla_Dia.AllowUserToAddRows = False
        Me.Grilla_Dia.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.PeachPuff
        Me.Grilla_Dia.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.Grilla_Dia.BackgroundColor = System.Drawing.Color.White
        Me.Grilla_Dia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Blue
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Yellow
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Grilla_Dia.DefaultCellStyle = DataGridViewCellStyle2
        Me.Grilla_Dia.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grilla_Dia.Location = New System.Drawing.Point(0, 0)
        Me.Grilla_Dia.Name = "Grilla_Dia"
        Me.Grilla_Dia.ReadOnly = True
        Me.Grilla_Dia.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Grilla_Dia.Size = New System.Drawing.Size(378, 282)
        Me.Grilla_Dia.TabIndex = 2
        '
        'Grupo_Venta_Mensual
        '
        Me.Grupo_Venta_Mensual.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Grupo_Venta_Mensual.CanvasColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Grupo_Venta_Mensual.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Grupo_Venta_Mensual.Controls.Add(Me.Grilla_Mes)
        Me.Grupo_Venta_Mensual.DisabledBackColor = System.Drawing.Color.Empty
        Me.Grupo_Venta_Mensual.Location = New System.Drawing.Point(402, 47)
        Me.Grupo_Venta_Mensual.Name = "Grupo_Venta_Mensual"
        Me.Grupo_Venta_Mensual.Size = New System.Drawing.Size(384, 305)
        '
        '
        '
        Me.Grupo_Venta_Mensual.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Grupo_Venta_Mensual.Style.BackColorGradientAngle = 90
        Me.Grupo_Venta_Mensual.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Grupo_Venta_Mensual.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Venta_Mensual.Style.BorderBottomWidth = 1
        Me.Grupo_Venta_Mensual.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.Grupo_Venta_Mensual.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Venta_Mensual.Style.BorderLeftWidth = 1
        Me.Grupo_Venta_Mensual.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Venta_Mensual.Style.BorderRightWidth = 1
        Me.Grupo_Venta_Mensual.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Venta_Mensual.Style.BorderTopWidth = 1
        Me.Grupo_Venta_Mensual.Style.CornerDiameter = 4
        Me.Grupo_Venta_Mensual.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Grupo_Venta_Mensual.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.Grupo_Venta_Mensual.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.Grupo_Venta_Mensual.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.Grupo_Venta_Mensual.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.Grupo_Venta_Mensual.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Grupo_Venta_Mensual.TabIndex = 9
        Me.Grupo_Venta_Mensual.Text = "VENTAS POR SUCURSAL ACUMULADO MENSUAL OCTUBRE"
        '
        'Grilla_Mes
        '
        Me.Grilla_Mes.AllowUserToAddRows = False
        Me.Grilla_Mes.AllowUserToDeleteRows = False
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.PeachPuff
        Me.Grilla_Mes.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle3
        Me.Grilla_Mes.BackgroundColor = System.Drawing.Color.White
        Me.Grilla_Mes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Blue
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Yellow
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Grilla_Mes.DefaultCellStyle = DataGridViewCellStyle4
        Me.Grilla_Mes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grilla_Mes.Location = New System.Drawing.Point(0, 0)
        Me.Grilla_Mes.Name = "Grilla_Mes"
        Me.Grilla_Mes.ReadOnly = True
        Me.Grilla_Mes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Grilla_Mes.Size = New System.Drawing.Size(378, 282)
        Me.Grilla_Mes.TabIndex = 2
        '
        'Grupo_Venta_Anual
        '
        Me.Grupo_Venta_Anual.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Grupo_Venta_Anual.CanvasColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Grupo_Venta_Anual.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Grupo_Venta_Anual.Controls.Add(Me.Grilla_Anual)
        Me.Grupo_Venta_Anual.DisabledBackColor = System.Drawing.Color.Empty
        Me.Grupo_Venta_Anual.Location = New System.Drawing.Point(792, 47)
        Me.Grupo_Venta_Anual.Name = "Grupo_Venta_Anual"
        Me.Grupo_Venta_Anual.Size = New System.Drawing.Size(384, 305)
        '
        '
        '
        Me.Grupo_Venta_Anual.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Grupo_Venta_Anual.Style.BackColorGradientAngle = 90
        Me.Grupo_Venta_Anual.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Grupo_Venta_Anual.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Venta_Anual.Style.BorderBottomWidth = 1
        Me.Grupo_Venta_Anual.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.Grupo_Venta_Anual.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Venta_Anual.Style.BorderLeftWidth = 1
        Me.Grupo_Venta_Anual.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Venta_Anual.Style.BorderRightWidth = 1
        Me.Grupo_Venta_Anual.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Venta_Anual.Style.BorderTopWidth = 1
        Me.Grupo_Venta_Anual.Style.CornerDiameter = 4
        Me.Grupo_Venta_Anual.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Grupo_Venta_Anual.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.Grupo_Venta_Anual.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.Grupo_Venta_Anual.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.Grupo_Venta_Anual.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.Grupo_Venta_Anual.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Grupo_Venta_Anual.TabIndex = 10
        Me.Grupo_Venta_Anual.Text = "VENTAS POR SUCURSAL ACUMULADO ANUAL"
        '
        'Grilla_Anual
        '
        Me.Grilla_Anual.AllowUserToAddRows = False
        Me.Grilla_Anual.AllowUserToDeleteRows = False
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.PeachPuff
        Me.Grilla_Anual.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle5
        Me.Grilla_Anual.BackgroundColor = System.Drawing.Color.White
        Me.Grilla_Anual.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Blue
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Yellow
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Grilla_Anual.DefaultCellStyle = DataGridViewCellStyle6
        Me.Grilla_Anual.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grilla_Anual.Location = New System.Drawing.Point(0, 0)
        Me.Grilla_Anual.Name = "Grilla_Anual"
        Me.Grilla_Anual.ReadOnly = True
        Me.Grilla_Anual.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Grilla_Anual.Size = New System.Drawing.Size(378, 282)
        Me.Grilla_Anual.TabIndex = 2
        '
        'Grupo_Guias_Diarias
        '
        Me.Grupo_Guias_Diarias.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Grupo_Guias_Diarias.CanvasColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Grupo_Guias_Diarias.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Grupo_Guias_Diarias.Controls.Add(Me.Grilla_Guias_Dia)
        Me.Grupo_Guias_Diarias.DisabledBackColor = System.Drawing.Color.Empty
        Me.Grupo_Guias_Diarias.Location = New System.Drawing.Point(12, 358)
        Me.Grupo_Guias_Diarias.Name = "Grupo_Guias_Diarias"
        Me.Grupo_Guias_Diarias.Size = New System.Drawing.Size(553, 313)
        '
        '
        '
        Me.Grupo_Guias_Diarias.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Grupo_Guias_Diarias.Style.BackColorGradientAngle = 90
        Me.Grupo_Guias_Diarias.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Grupo_Guias_Diarias.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Guias_Diarias.Style.BorderBottomWidth = 1
        Me.Grupo_Guias_Diarias.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.Grupo_Guias_Diarias.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Guias_Diarias.Style.BorderLeftWidth = 1
        Me.Grupo_Guias_Diarias.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Guias_Diarias.Style.BorderRightWidth = 1
        Me.Grupo_Guias_Diarias.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Guias_Diarias.Style.BorderTopWidth = 1
        Me.Grupo_Guias_Diarias.Style.CornerDiameter = 4
        Me.Grupo_Guias_Diarias.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Grupo_Guias_Diarias.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.Grupo_Guias_Diarias.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.Grupo_Guias_Diarias.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.Grupo_Guias_Diarias.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.Grupo_Guias_Diarias.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Grupo_Guias_Diarias.TabIndex = 11
        Me.Grupo_Guias_Diarias.Text = "GUIAS GENERADAS HOY"
        '
        'Grilla_Guias_Dia
        '
        Me.Grilla_Guias_Dia.AllowUserToAddRows = False
        Me.Grilla_Guias_Dia.AllowUserToDeleteRows = False
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.PeachPuff
        Me.Grilla_Guias_Dia.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle7
        Me.Grilla_Guias_Dia.BackgroundColor = System.Drawing.Color.White
        Me.Grilla_Guias_Dia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.Blue
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Yellow
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Grilla_Guias_Dia.DefaultCellStyle = DataGridViewCellStyle8
        Me.Grilla_Guias_Dia.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grilla_Guias_Dia.Location = New System.Drawing.Point(0, 0)
        Me.Grilla_Guias_Dia.Name = "Grilla_Guias_Dia"
        Me.Grilla_Guias_Dia.ReadOnly = True
        Me.Grilla_Guias_Dia.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Grilla_Guias_Dia.Size = New System.Drawing.Size(547, 290)
        Me.Grilla_Guias_Dia.TabIndex = 2
        '
        'Grupo_Guias_Mensuales
        '
        Me.Grupo_Guias_Mensuales.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Grupo_Guias_Mensuales.CanvasColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Grupo_Guias_Mensuales.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Grupo_Guias_Mensuales.Controls.Add(Me.Grilla_Guias_Mensual)
        Me.Grupo_Guias_Mensuales.DisabledBackColor = System.Drawing.Color.Empty
        Me.Grupo_Guias_Mensuales.Location = New System.Drawing.Point(571, 358)
        Me.Grupo_Guias_Mensuales.Name = "Grupo_Guias_Mensuales"
        Me.Grupo_Guias_Mensuales.Size = New System.Drawing.Size(605, 313)
        '
        '
        '
        Me.Grupo_Guias_Mensuales.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Grupo_Guias_Mensuales.Style.BackColorGradientAngle = 90
        Me.Grupo_Guias_Mensuales.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Grupo_Guias_Mensuales.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Guias_Mensuales.Style.BorderBottomWidth = 1
        Me.Grupo_Guias_Mensuales.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.Grupo_Guias_Mensuales.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Guias_Mensuales.Style.BorderLeftWidth = 1
        Me.Grupo_Guias_Mensuales.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Guias_Mensuales.Style.BorderRightWidth = 1
        Me.Grupo_Guias_Mensuales.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Guias_Mensuales.Style.BorderTopWidth = 1
        Me.Grupo_Guias_Mensuales.Style.CornerDiameter = 4
        Me.Grupo_Guias_Mensuales.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Grupo_Guias_Mensuales.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.Grupo_Guias_Mensuales.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.Grupo_Guias_Mensuales.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.Grupo_Guias_Mensuales.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.Grupo_Guias_Mensuales.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Grupo_Guias_Mensuales.TabIndex = 14
        Me.Grupo_Guias_Mensuales.Text = "GUIAS ACUMULADO MENSUAL"
        '
        'Grilla_Guias_Mensual
        '
        Me.Grilla_Guias_Mensual.AllowUserToAddRows = False
        Me.Grilla_Guias_Mensual.AllowUserToDeleteRows = False
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.PeachPuff
        Me.Grilla_Guias_Mensual.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle9
        Me.Grilla_Guias_Mensual.BackgroundColor = System.Drawing.Color.White
        Me.Grilla_Guias_Mensual.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.Blue
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.Yellow
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Grilla_Guias_Mensual.DefaultCellStyle = DataGridViewCellStyle10
        Me.Grilla_Guias_Mensual.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grilla_Guias_Mensual.Location = New System.Drawing.Point(0, 0)
        Me.Grilla_Guias_Mensual.Name = "Grilla_Guias_Mensual"
        Me.Grilla_Guias_Mensual.ReadOnly = True
        Me.Grilla_Guias_Mensual.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Grilla_Guias_Mensual.Size = New System.Drawing.Size(599, 290)
        Me.Grilla_Guias_Mensual.TabIndex = 2
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.BtnActualizar, Me.Chk_Incluir_Vales_Transitorios, Me.Btn_Ver_Datos_Ano_Anterior, Me.Btn_Ver_Datos_Otra_Fecha, Me.Btn_Filtro_Super_Familia, Me.Progreso_Circular_Espera, Me.BtnMinimizar, Me.Btn_Cerrar})
        Me.Bar1.Location = New System.Drawing.Point(0, 0)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(1184, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 15
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'BtnActualizar
        '
        Me.BtnActualizar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnActualizar.Name = "BtnActualizar"
        Me.BtnActualizar.Tooltip = "Actualizar información"
        '
        'Chk_Incluir_Vales_Transitorios
        '
        Me.Chk_Incluir_Vales_Transitorios.Name = "Chk_Incluir_Vales_Transitorios"
        Me.Chk_Incluir_Vales_Transitorios.Text = "Incluir documentos transitorios"
        '
        'Btn_Ver_Datos_Ano_Anterior
        '
        Me.Btn_Ver_Datos_Ano_Anterior.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Ver_Datos_Ano_Anterior.Image = CType(resources.GetObject("Btn_Ver_Datos_Ano_Anterior.Image"), System.Drawing.Image)
        Me.Btn_Ver_Datos_Ano_Anterior.Name = "Btn_Ver_Datos_Ano_Anterior"
        Me.Btn_Ver_Datos_Ano_Anterior.Text = "Ver información año anterior (misma fecha)"
        '
        'Btn_Ver_Datos_Otra_Fecha
        '
        Me.Btn_Ver_Datos_Otra_Fecha.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Ver_Datos_Otra_Fecha.Image = CType(resources.GetObject("Btn_Ver_Datos_Otra_Fecha.Image"), System.Drawing.Image)
        Me.Btn_Ver_Datos_Otra_Fecha.Name = "Btn_Ver_Datos_Otra_Fecha"
        Me.Btn_Ver_Datos_Otra_Fecha.Text = "Ver información otra fecha"
        '
        'Btn_Filtro_Super_Familia
        '
        Me.Btn_Filtro_Super_Familia.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Filtro_Super_Familia.Image = CType(resources.GetObject("Btn_Filtro_Super_Familia.Image"), System.Drawing.Image)
        Me.Btn_Filtro_Super_Familia.Name = "Btn_Filtro_Super_Familia"
        Me.Btn_Filtro_Super_Familia.Tooltip = "Filtro Super Familia"
        '
        'Progreso_Circular_Espera
        '
        Me.Progreso_Circular_Espera.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.Progreso_Circular_Espera.Name = "Progreso_Circular_Espera"
        '
        'BtnMinimizar
        '
        Me.BtnMinimizar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnMinimizar.ForeColor = System.Drawing.Color.Black
        Me.BtnMinimizar.Image = CType(resources.GetObject("BtnMinimizar.Image"), System.Drawing.Image)
        Me.BtnMinimizar.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.BtnMinimizar.Name = "BtnMinimizar"
        Me.BtnMinimizar.Tooltip = "Minimizar"
        '
        'Btn_Cerrar
        '
        Me.Btn_Cerrar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Cerrar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Cerrar.Image = CType(resources.GetObject("Btn_Cerrar.Image"), System.Drawing.Image)
        Me.Btn_Cerrar.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.Btn_Cerrar.Name = "Btn_Cerrar"
        Me.Btn_Cerrar.Tooltip = "Minimizar"
        '
        'Frm_Informe_Gerencia_On_Line
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1184, 678)
        Me.ControlBox = False
        Me.Controls.Add(Me.Bar1)
        Me.Controls.Add(Me.Grupo_Guias_Mensuales)
        Me.Controls.Add(Me.Grupo_Venta_Diaria)
        Me.Controls.Add(Me.Grupo_Venta_Mensual)
        Me.Controls.Add(Me.Grupo_Venta_Anual)
        Me.Controls.Add(Me.Grupo_Guias_Diarias)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "Frm_Informe_Gerencia_On_Line"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "INFORME DE VENTAS ON - LINE"
        Me.Grupo_Venta_Diaria.ResumeLayout(False)
        CType(Me.Grilla_Dia, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Grupo_Venta_Mensual.ResumeLayout(False)
        CType(Me.Grilla_Mes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Grupo_Venta_Anual.ResumeLayout(False)
        CType(Me.Grilla_Anual, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Grupo_Guias_Diarias.ResumeLayout(False)
        CType(Me.Grilla_Guias_Dia, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Grupo_Guias_Mensuales.ResumeLayout(False)
        CType(Me.Grilla_Guias_Mensual, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Tiempo_Espera As System.Windows.Forms.Timer
    Friend WithEvents Grupo_Venta_Diaria As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Grilla_Dia As System.Windows.Forms.DataGridView
    Friend WithEvents Grupo_Venta_Mensual As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Grilla_Mes As System.Windows.Forms.DataGridView
    Friend WithEvents Grupo_Venta_Anual As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Grilla_Anual As System.Windows.Forms.DataGridView
    Friend WithEvents Grupo_Guias_Diarias As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Grilla_Guias_Dia As System.Windows.Forms.DataGridView
    Friend WithEvents Grupo_Guias_Mensuales As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Grilla_Guias_Mensual As System.Windows.Forms.DataGridView
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents BtnActualizar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Chk_Incluir_Vales_Transitorios As DevComponents.DotNetBar.CheckBoxItem
    Friend WithEvents Progreso_Circular_Espera As DevComponents.DotNetBar.CircularProgressItem
    Friend WithEvents BtnMinimizar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Ver_Datos_Ano_Anterior As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Cerrar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Ver_Datos_Otra_Fecha As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Filtro_Super_Familia As DevComponents.DotNetBar.ButtonItem
End Class
