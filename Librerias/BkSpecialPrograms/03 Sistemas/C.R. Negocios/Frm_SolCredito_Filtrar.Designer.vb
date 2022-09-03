<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_SolCredito_Filtrar
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_SolCredito_Filtrar))
        Me.Grupo_Filtro_Estados = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.ItemPanel2 = New DevComponents.DotNetBar.ItemPanel()
        Me.Chk_Cerrados_Autorizado = New DevComponents.DotNetBar.CheckBoxItem()
        Me.Chk_Cerrados_Rechazados = New DevComponents.DotNetBar.CheckBoxItem()
        Me.Chk_Cerrados_Pre_Aprobados = New DevComponents.DotNetBar.CheckBoxItem()
        Me.ItemPanel1 = New DevComponents.DotNetBar.ItemPanel()
        Me.Chk_StandBy = New DevComponents.DotNetBar.CheckBoxItem()
        Me.Chk_Ingresado = New DevComponents.DotNetBar.CheckBoxItem()
        Me.Chk_Analisis = New DevComponents.DotNetBar.CheckBoxItem()
        Me.Chk_En_Procesado = New DevComponents.DotNetBar.CheckBoxItem()
        Me.Chk_Completado = New DevComponents.DotNetBar.CheckBoxItem()
        Me.Chk_Nulas = New DevComponents.DotNetBar.CheckBoxItem()
        Me.Grupo_Filtro_NroNegocio = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Txt_NroNegocio = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Rdb_NroNegocio_Todas = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_NroNegocio_Una = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.LblNroNegocio = New DevComponents.DotNetBar.LabelX()
        Me.Grupo_Filtro_Vendedor = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Rdb_Vendedor_Uno = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Cmb_Vendedor = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.Rdb_Vendedor_Todos = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Grupo_Filtro_Fecha_Emision = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.LblFecha_Emision2 = New System.Windows.Forms.Label()
        Me.Rdb_Fecha_Emision_Todas = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Dtp_Fecha_Emision_Hasta = New System.Windows.Forms.DateTimePicker()
        Me.Rdb_Fecha_Emision_Entre = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.LblFecha_Emision1 = New System.Windows.Forms.Label()
        Me.Dtp_Fecha_Emision_Desde = New System.Windows.Forms.DateTimePicker()
        Me.Grupo_Filtro_Cliente = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.TxtRazonCliente = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Rdb_Cliente_Todo = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.BtnBuscarCliente = New DevComponents.DotNetBar.ButtonX()
        Me.Rdb_Cliente_Uno = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.BtnFiltrar = New DevComponents.DotNetBar.ButtonItem()
        Me.BtnxSalir = New DevComponents.DotNetBar.ButtonItem()
        Me.Grupo_Filtro_Fecha_Cierre = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.LblFecha_Cierre2 = New System.Windows.Forms.Label()
        Me.Rdb_Fecha_Cierre_Todas = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Dtp_Fecha_Cierre_Hasta = New System.Windows.Forms.DateTimePicker()
        Me.Rdb_Fecha_Cierre_Entre = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.LblFecha_Cierre1 = New System.Windows.Forms.Label()
        Me.Dtp_Fecha_Cierre_Desde = New System.Windows.Forms.DateTimePicker()
        Me.Grupo_Filtro_Estados.SuspendLayout()
        Me.Grupo_Filtro_NroNegocio.SuspendLayout()
        Me.Grupo_Filtro_Vendedor.SuspendLayout()
        Me.Grupo_Filtro_Fecha_Emision.SuspendLayout()
        Me.Grupo_Filtro_Cliente.SuspendLayout()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Grupo_Filtro_Fecha_Cierre.SuspendLayout()
        Me.SuspendLayout()
        '
        'Grupo_Filtro_Estados
        '
        Me.Grupo_Filtro_Estados.BackColor = System.Drawing.Color.White
        Me.Grupo_Filtro_Estados.CanvasColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Grupo_Filtro_Estados.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Grupo_Filtro_Estados.Controls.Add(Me.ItemPanel2)
        Me.Grupo_Filtro_Estados.Controls.Add(Me.ItemPanel1)
        Me.Grupo_Filtro_Estados.DisabledBackColor = System.Drawing.Color.Empty
        Me.Grupo_Filtro_Estados.Location = New System.Drawing.Point(12, 302)
        Me.Grupo_Filtro_Estados.Name = "Grupo_Filtro_Estados"
        Me.Grupo_Filtro_Estados.Size = New System.Drawing.Size(460, 171)
        '
        '
        '
        Me.Grupo_Filtro_Estados.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Grupo_Filtro_Estados.Style.BackColorGradientAngle = 90
        Me.Grupo_Filtro_Estados.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Grupo_Filtro_Estados.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Filtro_Estados.Style.BorderBottomWidth = 1
        Me.Grupo_Filtro_Estados.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.Grupo_Filtro_Estados.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Filtro_Estados.Style.BorderLeftWidth = 1
        Me.Grupo_Filtro_Estados.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Filtro_Estados.Style.BorderRightWidth = 1
        Me.Grupo_Filtro_Estados.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Filtro_Estados.Style.BorderTopWidth = 1
        Me.Grupo_Filtro_Estados.Style.CornerDiameter = 4
        Me.Grupo_Filtro_Estados.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Grupo_Filtro_Estados.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.Grupo_Filtro_Estados.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.Grupo_Filtro_Estados.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.Grupo_Filtro_Estados.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Grupo_Filtro_Estados.TabIndex = 63
        Me.Grupo_Filtro_Estados.Text = "Estados"
        '
        'ItemPanel2
        '
        Me.ItemPanel2.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.ItemPanel2.BackgroundStyle.BackColor = System.Drawing.Color.White
        Me.ItemPanel2.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ItemPanel2.BackgroundStyle.BorderBottomWidth = 1
        Me.ItemPanel2.BackgroundStyle.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.ItemPanel2.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ItemPanel2.BackgroundStyle.BorderLeftWidth = 1
        Me.ItemPanel2.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ItemPanel2.BackgroundStyle.BorderRightWidth = 1
        Me.ItemPanel2.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ItemPanel2.BackgroundStyle.BorderTopWidth = 1
        Me.ItemPanel2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ItemPanel2.ContainerControlProcessDialogKey = True
        Me.ItemPanel2.DragDropSupport = True
        Me.ItemPanel2.ForeColor = System.Drawing.Color.Black
        Me.ItemPanel2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Chk_Cerrados_Autorizado, Me.Chk_Cerrados_Rechazados, Me.Chk_Cerrados_Pre_Aprobados})
        Me.ItemPanel2.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
        Me.ItemPanel2.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.ItemPanel2.Location = New System.Drawing.Point(121, 3)
        Me.ItemPanel2.Name = "ItemPanel2"
        Me.ItemPanel2.Size = New System.Drawing.Size(122, 138)
        Me.ItemPanel2.TabIndex = 3
        Me.ItemPanel2.Text = "ItemPanel2"
        '
        'Chk_Cerrados_Autorizado
        '
        Me.Chk_Cerrados_Autorizado.Checked = True
        Me.Chk_Cerrados_Autorizado.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Chk_Cerrados_Autorizado.Name = "Chk_Cerrados_Autorizado"
        Me.Chk_Cerrados_Autorizado.Text = "AUTORIZADOS"
        '
        'Chk_Cerrados_Rechazados
        '
        Me.Chk_Cerrados_Rechazados.Checked = True
        Me.Chk_Cerrados_Rechazados.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Chk_Cerrados_Rechazados.Name = "Chk_Cerrados_Rechazados"
        Me.Chk_Cerrados_Rechazados.Text = "RECHAZADOS"
        '
        'Chk_Cerrados_Pre_Aprobados
        '
        Me.Chk_Cerrados_Pre_Aprobados.Checked = True
        Me.Chk_Cerrados_Pre_Aprobados.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Chk_Cerrados_Pre_Aprobados.Name = "Chk_Cerrados_Pre_Aprobados"
        Me.Chk_Cerrados_Pre_Aprobados.Text = "PRE-APROBADOS"
        '
        'ItemPanel1
        '
        Me.ItemPanel1.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.ItemPanel1.BackgroundStyle.BackColor = System.Drawing.Color.White
        Me.ItemPanel1.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ItemPanel1.BackgroundStyle.BorderBottomWidth = 1
        Me.ItemPanel1.BackgroundStyle.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.ItemPanel1.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ItemPanel1.BackgroundStyle.BorderLeftWidth = 1
        Me.ItemPanel1.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ItemPanel1.BackgroundStyle.BorderRightWidth = 1
        Me.ItemPanel1.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ItemPanel1.BackgroundStyle.BorderTopWidth = 1
        Me.ItemPanel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ItemPanel1.ContainerControlProcessDialogKey = True
        Me.ItemPanel1.DragDropSupport = True
        Me.ItemPanel1.ForeColor = System.Drawing.Color.Black
        Me.ItemPanel1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Chk_StandBy, Me.Chk_Ingresado, Me.Chk_Analisis, Me.Chk_En_Procesado, Me.Chk_Completado, Me.Chk_Nulas})
        Me.ItemPanel1.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
        Me.ItemPanel1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.ItemPanel1.Location = New System.Drawing.Point(6, 4)
        Me.ItemPanel1.Name = "ItemPanel1"
        Me.ItemPanel1.Size = New System.Drawing.Size(109, 138)
        Me.ItemPanel1.TabIndex = 2
        Me.ItemPanel1.Text = "ItemPanel1"
        '
        'Chk_StandBy
        '
        Me.Chk_StandBy.Checked = True
        Me.Chk_StandBy.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Chk_StandBy.Name = "Chk_StandBy"
        Me.Chk_StandBy.Text = "STAND- BY"
        '
        'Chk_Ingresado
        '
        Me.Chk_Ingresado.Checked = True
        Me.Chk_Ingresado.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Chk_Ingresado.Name = "Chk_Ingresado"
        Me.Chk_Ingresado.Text = "INGRESADOS"
        '
        'Chk_Analisis
        '
        Me.Chk_Analisis.Checked = True
        Me.Chk_Analisis.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Chk_Analisis.Name = "Chk_Analisis"
        Me.Chk_Analisis.Text = "ANALISIS"
        '
        'Chk_En_Procesado
        '
        Me.Chk_En_Procesado.Checked = True
        Me.Chk_En_Procesado.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Chk_En_Procesado.Name = "Chk_En_Procesado"
        Me.Chk_En_Procesado.Text = "PROCESADOS"
        '
        'Chk_Completado
        '
        Me.Chk_Completado.Checked = True
        Me.Chk_Completado.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Chk_Completado.Name = "Chk_Completado"
        Me.Chk_Completado.Text = "COMPLETADOS"
        '
        'Chk_Nulas
        '
        Me.Chk_Nulas.Checked = True
        Me.Chk_Nulas.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Chk_Nulas.Name = "Chk_Nulas"
        Me.Chk_Nulas.Text = "NULAS"
        '
        'Grupo_Filtro_NroNegocio
        '
        Me.Grupo_Filtro_NroNegocio.BackColor = System.Drawing.Color.White
        Me.Grupo_Filtro_NroNegocio.CanvasColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Grupo_Filtro_NroNegocio.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Grupo_Filtro_NroNegocio.Controls.Add(Me.Txt_NroNegocio)
        Me.Grupo_Filtro_NroNegocio.Controls.Add(Me.Rdb_NroNegocio_Todas)
        Me.Grupo_Filtro_NroNegocio.Controls.Add(Me.Rdb_NroNegocio_Una)
        Me.Grupo_Filtro_NroNegocio.Controls.Add(Me.LblNroNegocio)
        Me.Grupo_Filtro_NroNegocio.DisabledBackColor = System.Drawing.Color.Empty
        Me.Grupo_Filtro_NroNegocio.Location = New System.Drawing.Point(12, 12)
        Me.Grupo_Filtro_NroNegocio.Name = "Grupo_Filtro_NroNegocio"
        Me.Grupo_Filtro_NroNegocio.Size = New System.Drawing.Size(291, 52)
        '
        '
        '
        Me.Grupo_Filtro_NroNegocio.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Grupo_Filtro_NroNegocio.Style.BackColorGradientAngle = 90
        Me.Grupo_Filtro_NroNegocio.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Grupo_Filtro_NroNegocio.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Filtro_NroNegocio.Style.BorderBottomWidth = 1
        Me.Grupo_Filtro_NroNegocio.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.Grupo_Filtro_NroNegocio.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Filtro_NroNegocio.Style.BorderLeftWidth = 1
        Me.Grupo_Filtro_NroNegocio.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Filtro_NroNegocio.Style.BorderRightWidth = 1
        Me.Grupo_Filtro_NroNegocio.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Filtro_NroNegocio.Style.BorderTopWidth = 1
        Me.Grupo_Filtro_NroNegocio.Style.CornerDiameter = 4
        Me.Grupo_Filtro_NroNegocio.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Grupo_Filtro_NroNegocio.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.Grupo_Filtro_NroNegocio.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.Grupo_Filtro_NroNegocio.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.Grupo_Filtro_NroNegocio.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Grupo_Filtro_NroNegocio.TabIndex = 61
        Me.Grupo_Filtro_NroNegocio.Text = "Negocio"
        '
        'Txt_NroNegocio
        '
        Me.Txt_NroNegocio.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_NroNegocio.Border.Class = "TextBoxBorder"
        Me.Txt_NroNegocio.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_NroNegocio.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_NroNegocio.FocusHighlightEnabled = True
        Me.Txt_NroNegocio.ForeColor = System.Drawing.Color.Black
        Me.Txt_NroNegocio.Location = New System.Drawing.Point(178, 2)
        Me.Txt_NroNegocio.Name = "Txt_NroNegocio"
        Me.Txt_NroNegocio.PreventEnterBeep = True
        Me.Txt_NroNegocio.Size = New System.Drawing.Size(100, 22)
        Me.Txt_NroNegocio.TabIndex = 22
        '
        'Rdb_NroNegocio_Todas
        '
        Me.Rdb_NroNegocio_Todas.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_NroNegocio_Todas.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_NroNegocio_Todas.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_NroNegocio_Todas.Checked = True
        Me.Rdb_NroNegocio_Todas.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Rdb_NroNegocio_Todas.CheckValue = "Y"
        Me.Rdb_NroNegocio_Todas.ForeColor = System.Drawing.Color.Black
        Me.Rdb_NroNegocio_Todas.Location = New System.Drawing.Point(6, 2)
        Me.Rdb_NroNegocio_Todas.Name = "Rdb_NroNegocio_Todas"
        Me.Rdb_NroNegocio_Todas.Size = New System.Drawing.Size(49, 23)
        Me.Rdb_NroNegocio_Todas.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_NroNegocio_Todas.TabIndex = 49
        Me.Rdb_NroNegocio_Todas.Text = "Todas"
        '
        'Rdb_NroNegocio_Una
        '
        Me.Rdb_NroNegocio_Una.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_NroNegocio_Una.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_NroNegocio_Una.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_NroNegocio_Una.ForeColor = System.Drawing.Color.Black
        Me.Rdb_NroNegocio_Una.Location = New System.Drawing.Point(61, 3)
        Me.Rdb_NroNegocio_Una.Name = "Rdb_NroNegocio_Una"
        Me.Rdb_NroNegocio_Una.Size = New System.Drawing.Size(47, 23)
        Me.Rdb_NroNegocio_Una.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_NroNegocio_Una.TabIndex = 48
        Me.Rdb_NroNegocio_Una.Text = "Una"
        '
        'LblNroNegocio
        '
        Me.LblNroNegocio.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LblNroNegocio.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LblNroNegocio.ForeColor = System.Drawing.Color.Black
        Me.LblNroNegocio.Location = New System.Drawing.Point(114, 2)
        Me.LblNroNegocio.Name = "LblNroNegocio"
        Me.LblNroNegocio.Size = New System.Drawing.Size(65, 23)
        Me.LblNroNegocio.TabIndex = 21
        Me.LblNroNegocio.Text = "N° Negocio"
        '
        'Grupo_Filtro_Vendedor
        '
        Me.Grupo_Filtro_Vendedor.BackColor = System.Drawing.Color.White
        Me.Grupo_Filtro_Vendedor.CanvasColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Grupo_Filtro_Vendedor.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Grupo_Filtro_Vendedor.Controls.Add(Me.Rdb_Vendedor_Uno)
        Me.Grupo_Filtro_Vendedor.Controls.Add(Me.Cmb_Vendedor)
        Me.Grupo_Filtro_Vendedor.Controls.Add(Me.Rdb_Vendedor_Todos)
        Me.Grupo_Filtro_Vendedor.DisabledBackColor = System.Drawing.Color.Empty
        Me.Grupo_Filtro_Vendedor.Location = New System.Drawing.Point(12, 70)
        Me.Grupo_Filtro_Vendedor.Name = "Grupo_Filtro_Vendedor"
        Me.Grupo_Filtro_Vendedor.Size = New System.Drawing.Size(600, 52)
        '
        '
        '
        Me.Grupo_Filtro_Vendedor.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Grupo_Filtro_Vendedor.Style.BackColorGradientAngle = 90
        Me.Grupo_Filtro_Vendedor.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Grupo_Filtro_Vendedor.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Filtro_Vendedor.Style.BorderBottomWidth = 1
        Me.Grupo_Filtro_Vendedor.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.Grupo_Filtro_Vendedor.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Filtro_Vendedor.Style.BorderLeftWidth = 1
        Me.Grupo_Filtro_Vendedor.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Filtro_Vendedor.Style.BorderRightWidth = 1
        Me.Grupo_Filtro_Vendedor.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Filtro_Vendedor.Style.BorderTopWidth = 1
        Me.Grupo_Filtro_Vendedor.Style.CornerDiameter = 4
        Me.Grupo_Filtro_Vendedor.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Grupo_Filtro_Vendedor.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.Grupo_Filtro_Vendedor.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.Grupo_Filtro_Vendedor.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.Grupo_Filtro_Vendedor.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Grupo_Filtro_Vendedor.TabIndex = 59
        Me.Grupo_Filtro_Vendedor.Text = "Vendedor"
        '
        'Rdb_Vendedor_Uno
        '
        Me.Rdb_Vendedor_Uno.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Vendedor_Uno.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Vendedor_Uno.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Vendedor_Uno.Checked = True
        Me.Rdb_Vendedor_Uno.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Rdb_Vendedor_Uno.CheckValue = "Y"
        Me.Rdb_Vendedor_Uno.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Vendedor_Uno.Location = New System.Drawing.Point(61, 4)
        Me.Rdb_Vendedor_Uno.Name = "Rdb_Vendedor_Uno"
        Me.Rdb_Vendedor_Uno.Size = New System.Drawing.Size(112, 23)
        Me.Rdb_Vendedor_Uno.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Vendedor_Uno.TabIndex = 48
        Me.Rdb_Vendedor_Uno.Text = "Uno en particular"
        '
        'Cmb_Vendedor
        '
        Me.Cmb_Vendedor.DisplayMember = "Text"
        Me.Cmb_Vendedor.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.Cmb_Vendedor.FocusHighlightEnabled = True
        Me.Cmb_Vendedor.ForeColor = System.Drawing.Color.Black
        Me.Cmb_Vendedor.FormattingEnabled = True
        Me.Cmb_Vendedor.ItemHeight = 16
        Me.Cmb_Vendedor.Location = New System.Drawing.Point(178, 5)
        Me.Cmb_Vendedor.Name = "Cmb_Vendedor"
        Me.Cmb_Vendedor.Size = New System.Drawing.Size(413, 22)
        Me.Cmb_Vendedor.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Cmb_Vendedor.TabIndex = 16
        '
        'Rdb_Vendedor_Todos
        '
        Me.Rdb_Vendedor_Todos.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Vendedor_Todos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Vendedor_Todos.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Vendedor_Todos.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Vendedor_Todos.Location = New System.Drawing.Point(6, 2)
        Me.Rdb_Vendedor_Todos.Name = "Rdb_Vendedor_Todos"
        Me.Rdb_Vendedor_Todos.Size = New System.Drawing.Size(59, 23)
        Me.Rdb_Vendedor_Todos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Vendedor_Todos.TabIndex = 49
        Me.Rdb_Vendedor_Todos.Text = "Todas"
        '
        'Grupo_Filtro_Fecha_Emision
        '
        Me.Grupo_Filtro_Fecha_Emision.BackColor = System.Drawing.Color.White
        Me.Grupo_Filtro_Fecha_Emision.CanvasColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Grupo_Filtro_Fecha_Emision.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Grupo_Filtro_Fecha_Emision.Controls.Add(Me.LblFecha_Emision2)
        Me.Grupo_Filtro_Fecha_Emision.Controls.Add(Me.Rdb_Fecha_Emision_Todas)
        Me.Grupo_Filtro_Fecha_Emision.Controls.Add(Me.Dtp_Fecha_Emision_Hasta)
        Me.Grupo_Filtro_Fecha_Emision.Controls.Add(Me.Rdb_Fecha_Emision_Entre)
        Me.Grupo_Filtro_Fecha_Emision.Controls.Add(Me.LblFecha_Emision1)
        Me.Grupo_Filtro_Fecha_Emision.Controls.Add(Me.Dtp_Fecha_Emision_Desde)
        Me.Grupo_Filtro_Fecha_Emision.DisabledBackColor = System.Drawing.Color.Empty
        Me.Grupo_Filtro_Fecha_Emision.Location = New System.Drawing.Point(12, 128)
        Me.Grupo_Filtro_Fecha_Emision.Name = "Grupo_Filtro_Fecha_Emision"
        Me.Grupo_Filtro_Fecha_Emision.Size = New System.Drawing.Size(600, 52)
        '
        '
        '
        Me.Grupo_Filtro_Fecha_Emision.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Grupo_Filtro_Fecha_Emision.Style.BackColorGradientAngle = 90
        Me.Grupo_Filtro_Fecha_Emision.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Grupo_Filtro_Fecha_Emision.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Filtro_Fecha_Emision.Style.BorderBottomWidth = 1
        Me.Grupo_Filtro_Fecha_Emision.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.Grupo_Filtro_Fecha_Emision.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Filtro_Fecha_Emision.Style.BorderLeftWidth = 1
        Me.Grupo_Filtro_Fecha_Emision.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Filtro_Fecha_Emision.Style.BorderRightWidth = 1
        Me.Grupo_Filtro_Fecha_Emision.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Filtro_Fecha_Emision.Style.BorderTopWidth = 1
        Me.Grupo_Filtro_Fecha_Emision.Style.CornerDiameter = 4
        Me.Grupo_Filtro_Fecha_Emision.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Grupo_Filtro_Fecha_Emision.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.Grupo_Filtro_Fecha_Emision.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.Grupo_Filtro_Fecha_Emision.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.Grupo_Filtro_Fecha_Emision.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Grupo_Filtro_Fecha_Emision.TabIndex = 58
        Me.Grupo_Filtro_Fecha_Emision.Text = "Fecha emisión"
        '
        'LblFecha_Emision2
        '
        Me.LblFecha_Emision2.AutoSize = True
        Me.LblFecha_Emision2.BackColor = System.Drawing.Color.Transparent
        Me.LblFecha_Emision2.ForeColor = System.Drawing.Color.Black
        Me.LblFecha_Emision2.Location = New System.Drawing.Point(386, 8)
        Me.LblFecha_Emision2.Name = "LblFecha_Emision2"
        Me.LblFecha_Emision2.Size = New System.Drawing.Size(36, 13)
        Me.LblFecha_Emision2.TabIndex = 5
        Me.LblFecha_Emision2.Text = "Hasta"
        '
        'Rdb_Fecha_Emision_Todas
        '
        Me.Rdb_Fecha_Emision_Todas.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Fecha_Emision_Todas.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Fecha_Emision_Todas.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Fecha_Emision_Todas.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Fecha_Emision_Todas.Location = New System.Drawing.Point(3, 3)
        Me.Rdb_Fecha_Emision_Todas.Name = "Rdb_Fecha_Emision_Todas"
        Me.Rdb_Fecha_Emision_Todas.Size = New System.Drawing.Size(47, 23)
        Me.Rdb_Fecha_Emision_Todas.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Fecha_Emision_Todas.TabIndex = 22
        Me.Rdb_Fecha_Emision_Todas.Text = "Todas"
        '
        'Dtp_Fecha_Emision_Hasta
        '
        Me.Dtp_Fecha_Emision_Hasta.BackColor = System.Drawing.Color.White
        Me.Dtp_Fecha_Emision_Hasta.ForeColor = System.Drawing.Color.Black
        Me.Dtp_Fecha_Emision_Hasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Dtp_Fecha_Emision_Hasta.Location = New System.Drawing.Point(441, 4)
        Me.Dtp_Fecha_Emision_Hasta.Name = "Dtp_Fecha_Emision_Hasta"
        Me.Dtp_Fecha_Emision_Hasta.Size = New System.Drawing.Size(84, 22)
        Me.Dtp_Fecha_Emision_Hasta.TabIndex = 4
        '
        'Rdb_Fecha_Emision_Entre
        '
        Me.Rdb_Fecha_Emision_Entre.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Fecha_Emision_Entre.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Fecha_Emision_Entre.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Fecha_Emision_Entre.Checked = True
        Me.Rdb_Fecha_Emision_Entre.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Rdb_Fecha_Emision_Entre.CheckValue = "Y"
        Me.Rdb_Fecha_Emision_Entre.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Fecha_Emision_Entre.Location = New System.Drawing.Point(61, 3)
        Me.Rdb_Fecha_Emision_Entre.Name = "Rdb_Fecha_Emision_Entre"
        Me.Rdb_Fecha_Emision_Entre.Size = New System.Drawing.Size(106, 23)
        Me.Rdb_Fecha_Emision_Entre.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Fecha_Emision_Entre.TabIndex = 27
        Me.Rdb_Fecha_Emision_Entre.Text = "Rango de fechas"
        '
        'LblFecha_Emision1
        '
        Me.LblFecha_Emision1.AutoSize = True
        Me.LblFecha_Emision1.BackColor = System.Drawing.Color.Transparent
        Me.LblFecha_Emision1.ForeColor = System.Drawing.Color.Black
        Me.LblFecha_Emision1.Location = New System.Drawing.Point(204, 8)
        Me.LblFecha_Emision1.Name = "LblFecha_Emision1"
        Me.LblFecha_Emision1.Size = New System.Drawing.Size(39, 13)
        Me.LblFecha_Emision1.TabIndex = 3
        Me.LblFecha_Emision1.Text = "Desde"
        '
        'Dtp_Fecha_Emision_Desde
        '
        Me.Dtp_Fecha_Emision_Desde.BackColor = System.Drawing.Color.White
        Me.Dtp_Fecha_Emision_Desde.ForeColor = System.Drawing.Color.Black
        Me.Dtp_Fecha_Emision_Desde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Dtp_Fecha_Emision_Desde.Location = New System.Drawing.Point(264, 4)
        Me.Dtp_Fecha_Emision_Desde.Name = "Dtp_Fecha_Emision_Desde"
        Me.Dtp_Fecha_Emision_Desde.Size = New System.Drawing.Size(84, 22)
        Me.Dtp_Fecha_Emision_Desde.TabIndex = 2
        '
        'Grupo_Filtro_Cliente
        '
        Me.Grupo_Filtro_Cliente.BackColor = System.Drawing.Color.White
        Me.Grupo_Filtro_Cliente.CanvasColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Grupo_Filtro_Cliente.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Grupo_Filtro_Cliente.Controls.Add(Me.TxtRazonCliente)
        Me.Grupo_Filtro_Cliente.Controls.Add(Me.Rdb_Cliente_Todo)
        Me.Grupo_Filtro_Cliente.Controls.Add(Me.BtnBuscarCliente)
        Me.Grupo_Filtro_Cliente.Controls.Add(Me.Rdb_Cliente_Uno)
        Me.Grupo_Filtro_Cliente.DisabledBackColor = System.Drawing.Color.Empty
        Me.Grupo_Filtro_Cliente.Location = New System.Drawing.Point(12, 244)
        Me.Grupo_Filtro_Cliente.Name = "Grupo_Filtro_Cliente"
        Me.Grupo_Filtro_Cliente.Size = New System.Drawing.Size(600, 52)
        '
        '
        '
        Me.Grupo_Filtro_Cliente.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Grupo_Filtro_Cliente.Style.BackColorGradientAngle = 90
        Me.Grupo_Filtro_Cliente.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Grupo_Filtro_Cliente.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Filtro_Cliente.Style.BorderBottomWidth = 1
        Me.Grupo_Filtro_Cliente.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.Grupo_Filtro_Cliente.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Filtro_Cliente.Style.BorderLeftWidth = 1
        Me.Grupo_Filtro_Cliente.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Filtro_Cliente.Style.BorderRightWidth = 1
        Me.Grupo_Filtro_Cliente.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Filtro_Cliente.Style.BorderTopWidth = 1
        Me.Grupo_Filtro_Cliente.Style.CornerDiameter = 4
        Me.Grupo_Filtro_Cliente.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Grupo_Filtro_Cliente.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.Grupo_Filtro_Cliente.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.Grupo_Filtro_Cliente.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.Grupo_Filtro_Cliente.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Grupo_Filtro_Cliente.TabIndex = 57
        Me.Grupo_Filtro_Cliente.Text = "Cliente"
        '
        'TxtRazonCliente
        '
        Me.TxtRazonCliente.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TxtRazonCliente.Border.Class = "TextBoxBorder"
        Me.TxtRazonCliente.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtRazonCliente.DisabledBackColor = System.Drawing.Color.White
        Me.TxtRazonCliente.Enabled = False
        Me.TxtRazonCliente.ForeColor = System.Drawing.Color.Black
        Me.TxtRazonCliente.Location = New System.Drawing.Point(161, 3)
        Me.TxtRazonCliente.Name = "TxtRazonCliente"
        Me.TxtRazonCliente.PreventEnterBeep = True
        Me.TxtRazonCliente.ReadOnly = True
        Me.TxtRazonCliente.Size = New System.Drawing.Size(430, 22)
        Me.TxtRazonCliente.TabIndex = 9
        '
        'Rdb_Cliente_Todo
        '
        Me.Rdb_Cliente_Todo.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Cliente_Todo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Cliente_Todo.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Cliente_Todo.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Cliente_Todo.Location = New System.Drawing.Point(3, 3)
        Me.Rdb_Cliente_Todo.Name = "Rdb_Cliente_Todo"
        Me.Rdb_Cliente_Todo.Size = New System.Drawing.Size(47, 23)
        Me.Rdb_Cliente_Todo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Cliente_Todo.TabIndex = 22
        Me.Rdb_Cliente_Todo.Text = "Todos"
        '
        'BtnBuscarCliente
        '
        Me.BtnBuscarCliente.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BtnBuscarCliente.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.BtnBuscarCliente.Image = CType(resources.GetObject("BtnBuscarCliente.Image"), System.Drawing.Image)
        Me.BtnBuscarCliente.Location = New System.Drawing.Point(114, 4)
        Me.BtnBuscarCliente.Name = "BtnBuscarCliente"
        Me.BtnBuscarCliente.Size = New System.Drawing.Size(39, 23)
        Me.BtnBuscarCliente.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.BtnBuscarCliente.TabIndex = 6
        Me.BtnBuscarCliente.Tooltip = "Buscar cliente"
        '
        'Rdb_Cliente_Uno
        '
        Me.Rdb_Cliente_Uno.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Cliente_Uno.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Cliente_Uno.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Cliente_Uno.Checked = True
        Me.Rdb_Cliente_Uno.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Rdb_Cliente_Uno.CheckValue = "Y"
        Me.Rdb_Cliente_Uno.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Cliente_Uno.Location = New System.Drawing.Point(61, 3)
        Me.Rdb_Cliente_Uno.Name = "Rdb_Cliente_Uno"
        Me.Rdb_Cliente_Uno.Size = New System.Drawing.Size(47, 23)
        Me.Rdb_Cliente_Uno.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Cliente_Uno.TabIndex = 27
        Me.Rdb_Cliente_Uno.Text = "Uno"
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.BtnFiltrar, Me.BtnxSalir})
        Me.Bar1.Location = New System.Drawing.Point(0, 493)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(623, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 64
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'BtnFiltrar
        '
        Me.BtnFiltrar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnFiltrar.ForeColor = System.Drawing.Color.Black
        Me.BtnFiltrar.Image = CType(resources.GetObject("BtnFiltrar.Image"), System.Drawing.Image)
        Me.BtnFiltrar.Name = "BtnFiltrar"
        Me.BtnFiltrar.Text = "Aplicar filtro"
        '
        'BtnxSalir
        '
        Me.BtnxSalir.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnxSalir.ForeColor = System.Drawing.Color.Black
        Me.BtnxSalir.Image = CType(resources.GetObject("BtnxSalir.Image"), System.Drawing.Image)
        Me.BtnxSalir.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.BtnxSalir.Name = "BtnxSalir"
        Me.BtnxSalir.Tooltip = "Salir"
        '
        'Grupo_Filtro_Fecha_Cierre
        '
        Me.Grupo_Filtro_Fecha_Cierre.BackColor = System.Drawing.Color.White
        Me.Grupo_Filtro_Fecha_Cierre.CanvasColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Grupo_Filtro_Fecha_Cierre.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Grupo_Filtro_Fecha_Cierre.Controls.Add(Me.LblFecha_Cierre2)
        Me.Grupo_Filtro_Fecha_Cierre.Controls.Add(Me.Rdb_Fecha_Cierre_Todas)
        Me.Grupo_Filtro_Fecha_Cierre.Controls.Add(Me.Dtp_Fecha_Cierre_Hasta)
        Me.Grupo_Filtro_Fecha_Cierre.Controls.Add(Me.Rdb_Fecha_Cierre_Entre)
        Me.Grupo_Filtro_Fecha_Cierre.Controls.Add(Me.LblFecha_Cierre1)
        Me.Grupo_Filtro_Fecha_Cierre.Controls.Add(Me.Dtp_Fecha_Cierre_Desde)
        Me.Grupo_Filtro_Fecha_Cierre.DisabledBackColor = System.Drawing.Color.Empty
        Me.Grupo_Filtro_Fecha_Cierre.Location = New System.Drawing.Point(12, 186)
        Me.Grupo_Filtro_Fecha_Cierre.Name = "Grupo_Filtro_Fecha_Cierre"
        Me.Grupo_Filtro_Fecha_Cierre.Size = New System.Drawing.Size(600, 52)
        '
        '
        '
        Me.Grupo_Filtro_Fecha_Cierre.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Grupo_Filtro_Fecha_Cierre.Style.BackColorGradientAngle = 90
        Me.Grupo_Filtro_Fecha_Cierre.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Grupo_Filtro_Fecha_Cierre.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Filtro_Fecha_Cierre.Style.BorderBottomWidth = 1
        Me.Grupo_Filtro_Fecha_Cierre.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.Grupo_Filtro_Fecha_Cierre.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Filtro_Fecha_Cierre.Style.BorderLeftWidth = 1
        Me.Grupo_Filtro_Fecha_Cierre.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Filtro_Fecha_Cierre.Style.BorderRightWidth = 1
        Me.Grupo_Filtro_Fecha_Cierre.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Filtro_Fecha_Cierre.Style.BorderTopWidth = 1
        Me.Grupo_Filtro_Fecha_Cierre.Style.CornerDiameter = 4
        Me.Grupo_Filtro_Fecha_Cierre.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Grupo_Filtro_Fecha_Cierre.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.Grupo_Filtro_Fecha_Cierre.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.Grupo_Filtro_Fecha_Cierre.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.Grupo_Filtro_Fecha_Cierre.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Grupo_Filtro_Fecha_Cierre.TabIndex = 65
        Me.Grupo_Filtro_Fecha_Cierre.Text = "Fecha cierre"
        '
        'LblFecha_Cierre2
        '
        Me.LblFecha_Cierre2.AutoSize = True
        Me.LblFecha_Cierre2.BackColor = System.Drawing.Color.Transparent
        Me.LblFecha_Cierre2.ForeColor = System.Drawing.Color.Black
        Me.LblFecha_Cierre2.Location = New System.Drawing.Point(386, 8)
        Me.LblFecha_Cierre2.Name = "LblFecha_Cierre2"
        Me.LblFecha_Cierre2.Size = New System.Drawing.Size(36, 13)
        Me.LblFecha_Cierre2.TabIndex = 5
        Me.LblFecha_Cierre2.Text = "Hasta"
        '
        'Rdb_Fecha_Cierre_Todas
        '
        Me.Rdb_Fecha_Cierre_Todas.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Fecha_Cierre_Todas.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Fecha_Cierre_Todas.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Fecha_Cierre_Todas.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Fecha_Cierre_Todas.Location = New System.Drawing.Point(3, 3)
        Me.Rdb_Fecha_Cierre_Todas.Name = "Rdb_Fecha_Cierre_Todas"
        Me.Rdb_Fecha_Cierre_Todas.Size = New System.Drawing.Size(47, 23)
        Me.Rdb_Fecha_Cierre_Todas.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Fecha_Cierre_Todas.TabIndex = 22
        Me.Rdb_Fecha_Cierre_Todas.Text = "Todas"
        '
        'Dtp_Fecha_Cierre_Hasta
        '
        Me.Dtp_Fecha_Cierre_Hasta.BackColor = System.Drawing.Color.White
        Me.Dtp_Fecha_Cierre_Hasta.ForeColor = System.Drawing.Color.Black
        Me.Dtp_Fecha_Cierre_Hasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Dtp_Fecha_Cierre_Hasta.Location = New System.Drawing.Point(441, 4)
        Me.Dtp_Fecha_Cierre_Hasta.Name = "Dtp_Fecha_Cierre_Hasta"
        Me.Dtp_Fecha_Cierre_Hasta.Size = New System.Drawing.Size(84, 22)
        Me.Dtp_Fecha_Cierre_Hasta.TabIndex = 4
        '
        'Rdb_Fecha_Cierre_Entre
        '
        Me.Rdb_Fecha_Cierre_Entre.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Fecha_Cierre_Entre.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Fecha_Cierre_Entre.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Fecha_Cierre_Entre.Checked = True
        Me.Rdb_Fecha_Cierre_Entre.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Rdb_Fecha_Cierre_Entre.CheckValue = "Y"
        Me.Rdb_Fecha_Cierre_Entre.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Fecha_Cierre_Entre.Location = New System.Drawing.Point(61, 3)
        Me.Rdb_Fecha_Cierre_Entre.Name = "Rdb_Fecha_Cierre_Entre"
        Me.Rdb_Fecha_Cierre_Entre.Size = New System.Drawing.Size(106, 23)
        Me.Rdb_Fecha_Cierre_Entre.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Fecha_Cierre_Entre.TabIndex = 27
        Me.Rdb_Fecha_Cierre_Entre.Text = "Rango de fechas"
        '
        'LblFecha_Cierre1
        '
        Me.LblFecha_Cierre1.AutoSize = True
        Me.LblFecha_Cierre1.BackColor = System.Drawing.Color.Transparent
        Me.LblFecha_Cierre1.ForeColor = System.Drawing.Color.Black
        Me.LblFecha_Cierre1.Location = New System.Drawing.Point(204, 8)
        Me.LblFecha_Cierre1.Name = "LblFecha_Cierre1"
        Me.LblFecha_Cierre1.Size = New System.Drawing.Size(39, 13)
        Me.LblFecha_Cierre1.TabIndex = 3
        Me.LblFecha_Cierre1.Text = "Desde"
        '
        'Dtp_Fecha_Cierre_Desde
        '
        Me.Dtp_Fecha_Cierre_Desde.BackColor = System.Drawing.Color.White
        Me.Dtp_Fecha_Cierre_Desde.ForeColor = System.Drawing.Color.Black
        Me.Dtp_Fecha_Cierre_Desde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Dtp_Fecha_Cierre_Desde.Location = New System.Drawing.Point(264, 4)
        Me.Dtp_Fecha_Cierre_Desde.Name = "Dtp_Fecha_Cierre_Desde"
        Me.Dtp_Fecha_Cierre_Desde.Size = New System.Drawing.Size(84, 22)
        Me.Dtp_Fecha_Cierre_Desde.TabIndex = 2
        '
        'Frm_SolCredito_Filtrar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(623, 534)
        Me.ControlBox = False
        Me.Controls.Add(Me.Grupo_Filtro_Fecha_Cierre)
        Me.Controls.Add(Me.Bar1)
        Me.Controls.Add(Me.Grupo_Filtro_Estados)
        Me.Controls.Add(Me.Grupo_Filtro_NroNegocio)
        Me.Controls.Add(Me.Grupo_Filtro_Vendedor)
        Me.Controls.Add(Me.Grupo_Filtro_Fecha_Emision)
        Me.Controls.Add(Me.Grupo_Filtro_Cliente)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_SolCredito_Filtrar"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Filtro de negocios"
        Me.Grupo_Filtro_Estados.ResumeLayout(False)
        Me.Grupo_Filtro_NroNegocio.ResumeLayout(False)
        Me.Grupo_Filtro_Vendedor.ResumeLayout(False)
        Me.Grupo_Filtro_Fecha_Emision.ResumeLayout(False)
        Me.Grupo_Filtro_Fecha_Emision.PerformLayout()
        Me.Grupo_Filtro_Cliente.ResumeLayout(False)
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Grupo_Filtro_Fecha_Cierre.ResumeLayout(False)
        Me.Grupo_Filtro_Fecha_Cierre.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Grupo_Filtro_Estados As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents ItemPanel1 As DevComponents.DotNetBar.ItemPanel
    Public WithEvents Chk_Ingresado As DevComponents.DotNetBar.CheckBoxItem
    Public WithEvents Chk_En_Procesado As DevComponents.DotNetBar.CheckBoxItem
    Public WithEvents Chk_Completado As DevComponents.DotNetBar.CheckBoxItem
    Public WithEvents Chk_Nulas As DevComponents.DotNetBar.CheckBoxItem
    Public WithEvents Chk_StandBy As DevComponents.DotNetBar.CheckBoxItem
    Friend WithEvents Grupo_Filtro_NroNegocio As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Txt_NroNegocio As DevComponents.DotNetBar.Controls.TextBoxX
    Public WithEvents Rdb_NroNegocio_Todas As DevComponents.DotNetBar.Controls.CheckBoxX
    Public WithEvents Rdb_NroNegocio_Una As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents LblNroNegocio As DevComponents.DotNetBar.LabelX
    Friend WithEvents Grupo_Filtro_Vendedor As DevComponents.DotNetBar.Controls.GroupPanel
    Public WithEvents Rdb_Vendedor_Uno As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Cmb_Vendedor As DevComponents.DotNetBar.Controls.ComboBoxEx
    Public WithEvents Rdb_Vendedor_Todos As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Grupo_Filtro_Fecha_Emision As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents LblFecha_Emision2 As System.Windows.Forms.Label
    Public WithEvents Rdb_Fecha_Emision_Todas As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Dtp_Fecha_Emision_Hasta As System.Windows.Forms.DateTimePicker
    Public WithEvents Rdb_Fecha_Emision_Entre As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents LblFecha_Emision1 As System.Windows.Forms.Label
    Friend WithEvents Dtp_Fecha_Emision_Desde As System.Windows.Forms.DateTimePicker
    Friend WithEvents Grupo_Filtro_Cliente As DevComponents.DotNetBar.Controls.GroupPanel
    Public WithEvents TxtRazonCliente As DevComponents.DotNetBar.Controls.TextBoxX
    Public WithEvents Rdb_Cliente_Todo As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents BtnBuscarCliente As DevComponents.DotNetBar.ButtonX
    Public WithEvents Rdb_Cliente_Uno As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents BtnFiltrar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents BtnxSalir As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Grupo_Filtro_Fecha_Cierre As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents LblFecha_Cierre2 As System.Windows.Forms.Label
    Public WithEvents Rdb_Fecha_Cierre_Todas As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Dtp_Fecha_Cierre_Hasta As System.Windows.Forms.DateTimePicker
    Public WithEvents Rdb_Fecha_Cierre_Entre As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents LblFecha_Cierre1 As System.Windows.Forms.Label
    Friend WithEvents Dtp_Fecha_Cierre_Desde As System.Windows.Forms.DateTimePicker
    Friend WithEvents ItemPanel2 As DevComponents.DotNetBar.ItemPanel
    Public WithEvents Chk_Cerrados_Autorizado As DevComponents.DotNetBar.CheckBoxItem
    Public WithEvents Chk_Cerrados_Rechazados As DevComponents.DotNetBar.CheckBoxItem
    Public WithEvents Chk_Cerrados_Pre_Aprobados As DevComponents.DotNetBar.CheckBoxItem
    Public WithEvents Chk_Analisis As DevComponents.DotNetBar.CheckBoxItem
End Class
