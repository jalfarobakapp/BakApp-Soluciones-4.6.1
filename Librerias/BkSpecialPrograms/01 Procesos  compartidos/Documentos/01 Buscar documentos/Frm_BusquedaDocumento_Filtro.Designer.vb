<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_BusquedaDocumento_Filtro
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_BusquedaDocumento_Filtro))
        Me.Btn_Entidad_Una = New DevComponents.DotNetBar.ButtonX()
        Me.Rdb_Entidad_Una = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Txt_Entidad = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.ChkBuscarEntidadFisica = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_Entidad_Todas = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.TxtNroDocumento = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.BtnAceptar = New DevComponents.DotNetBar.ButtonItem()
        Me.Rdb_Tipo_Documento_Algunos = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_Tipo_Documento_Uno = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.CmbTipoDeDocumentos = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.Btn_Documentos = New DevComponents.DotNetBar.ButtonX()
        Me.LblNroDocumento = New DevComponents.DotNetBar.LabelX()
        Me.Rdb_Fecha_Emision_Cualquiera = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_Fecha_Emision_Desde_Hasta = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.LblFecha1 = New DevComponents.DotNetBar.LabelX()
        Me.LblFecha2 = New DevComponents.DotNetBar.LabelX()
        Me.Rdb_Estado_Todos = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_Estado_Vigente = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_Estado_Cerradas = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_Funcionarios_Uno = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.CmbFuncionarios = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.Btn_Funcionarios = New DevComponents.DotNetBar.ButtonX()
        Me.Rdb_Funcionarios_Todos = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_Funcionarios_Algunos = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.CmbCantFilas = New System.Windows.Forms.ComboBox()
        Me.Grupo_documento = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.Rdb_Sucursal_Doc_Algunas = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_Sucursal_Doc_Todas = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.Rdb_Ver_Primeros = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_Ver_Ultimos = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Grupo_Fecha = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.DtpFechaFin = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.DtpFechaInicio = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.Grupo_Estado_Documento = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Grupo_Entidad = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Chk_Todas_Sucursales = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Grupo_Funcionario = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Grupo_Producto = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Btn_Producto_Uno = New DevComponents.DotNetBar.ButtonX()
        Me.Rdb_Producto_Todos = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_Producto_Uno = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Txt_Producto = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Chk_Mostrar_Vales_Transitorios = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Txt_Placapat = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_CodRetirador = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_Ocdo = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Grupo_documento.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.Grupo_Fecha.SuspendLayout()
        CType(Me.DtpFechaFin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DtpFechaInicio, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Grupo_Estado_Documento.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Grupo_Entidad.SuspendLayout()
        Me.Grupo_Funcionario.SuspendLayout()
        Me.Grupo_Producto.SuspendLayout()
        Me.GroupPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Btn_Entidad_Una
        '
        Me.Btn_Entidad_Una.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Entidad_Una.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Entidad_Una.Image = CType(resources.GetObject("Btn_Entidad_Una.Image"), System.Drawing.Image)
        Me.Btn_Entidad_Una.Location = New System.Drawing.Point(135, 45)
        Me.Btn_Entidad_Una.Name = "Btn_Entidad_Una"
        Me.Btn_Entidad_Una.Size = New System.Drawing.Size(31, 23)
        Me.Btn_Entidad_Una.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Entidad_Una.TabIndex = 28
        Me.Btn_Entidad_Una.Tooltip = "Ver selección"
        '
        'Rdb_Entidad_Una
        '
        Me.Rdb_Entidad_Una.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Entidad_Una.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Entidad_Una.CheckBoxImageChecked = CType(resources.GetObject("Rdb_Entidad_Una.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Rdb_Entidad_Una.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Entidad_Una.FocusCuesEnabled = False
        Me.Rdb_Entidad_Una.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Entidad_Una.Location = New System.Drawing.Point(3, 45)
        Me.Rdb_Entidad_Una.Name = "Rdb_Entidad_Una"
        Me.Rdb_Entidad_Una.Size = New System.Drawing.Size(106, 23)
        Me.Rdb_Entidad_Una.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Entidad_Una.TabIndex = 27
        Me.Rdb_Entidad_Una.Text = "Uno en especifico"
        '
        'Txt_Entidad
        '
        Me.Txt_Entidad.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Entidad.Border.Class = "TextBoxBorder"
        Me.Txt_Entidad.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Entidad.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Entidad.Enabled = False
        Me.Txt_Entidad.ForeColor = System.Drawing.Color.Black
        Me.Txt_Entidad.Location = New System.Drawing.Point(172, 46)
        Me.Txt_Entidad.Name = "Txt_Entidad"
        Me.Txt_Entidad.PreventEnterBeep = True
        Me.Txt_Entidad.ReadOnly = True
        Me.Txt_Entidad.Size = New System.Drawing.Size(487, 22)
        Me.Txt_Entidad.TabIndex = 9
        '
        'ChkBuscarEntidadFisica
        '
        Me.ChkBuscarEntidadFisica.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.ChkBuscarEntidadFisica.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ChkBuscarEntidadFisica.CheckBoxImageChecked = CType(resources.GetObject("ChkBuscarEntidadFisica.CheckBoxImageChecked"), System.Drawing.Image)
        Me.ChkBuscarEntidadFisica.FocusCuesEnabled = False
        Me.ChkBuscarEntidadFisica.ForeColor = System.Drawing.Color.Black
        Me.ChkBuscarEntidadFisica.Location = New System.Drawing.Point(559, 15)
        Me.ChkBuscarEntidadFisica.Name = "ChkBuscarEntidadFisica"
        Me.ChkBuscarEntidadFisica.Size = New System.Drawing.Size(100, 23)
        Me.ChkBuscarEntidadFisica.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ChkBuscarEntidadFisica.TabIndex = 18
        Me.ChkBuscarEntidadFisica.Text = "Es entidad física"
        '
        'Rdb_Entidad_Todas
        '
        Me.Rdb_Entidad_Todas.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Entidad_Todas.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Entidad_Todas.CheckBoxImageChecked = CType(resources.GetObject("Rdb_Entidad_Todas.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Rdb_Entidad_Todas.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Entidad_Todas.Checked = True
        Me.Rdb_Entidad_Todas.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Rdb_Entidad_Todas.CheckValue = "Y"
        Me.Rdb_Entidad_Todas.FocusCuesEnabled = False
        Me.Rdb_Entidad_Todas.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Entidad_Todas.Location = New System.Drawing.Point(3, 15)
        Me.Rdb_Entidad_Todas.Name = "Rdb_Entidad_Todas"
        Me.Rdb_Entidad_Todas.Size = New System.Drawing.Size(56, 23)
        Me.Rdb_Entidad_Todas.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Entidad_Todas.TabIndex = 22
        Me.Rdb_Entidad_Todas.Text = "Todas"
        '
        'TxtNroDocumento
        '
        Me.TxtNroDocumento.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TxtNroDocumento.Border.Class = "TextBoxBorder"
        Me.TxtNroDocumento.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtNroDocumento.DisabledBackColor = System.Drawing.Color.White
        Me.TxtNroDocumento.FocusHighlightEnabled = True
        Me.TxtNroDocumento.ForeColor = System.Drawing.Color.Black
        Me.TxtNroDocumento.Location = New System.Drawing.Point(276, 32)
        Me.TxtNroDocumento.Name = "TxtNroDocumento"
        Me.TxtNroDocumento.PreventEnterBeep = True
        Me.TxtNroDocumento.Size = New System.Drawing.Size(110, 22)
        Me.TxtNroDocumento.TabIndex = 3
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.BtnAceptar})
        Me.Bar1.Location = New System.Drawing.Point(0, 557)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(700, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 12
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'BtnAceptar
        '
        Me.BtnAceptar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnAceptar.ForeColor = System.Drawing.Color.Black
        Me.BtnAceptar.Image = CType(resources.GetObject("BtnAceptar.Image"), System.Drawing.Image)
        Me.BtnAceptar.ImageAlt = CType(resources.GetObject("BtnAceptar.ImageAlt"), System.Drawing.Image)
        Me.BtnAceptar.Name = "BtnAceptar"
        Me.BtnAceptar.Text = "Buscar"
        Me.BtnAceptar.Tooltip = "Seleccionar documento"
        '
        'Rdb_Tipo_Documento_Algunos
        '
        Me.Rdb_Tipo_Documento_Algunos.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Tipo_Documento_Algunos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Tipo_Documento_Algunos.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Tipo_Documento_Algunos.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Tipo_Documento_Algunos.Location = New System.Drawing.Point(737, 87)
        Me.Rdb_Tipo_Documento_Algunos.Name = "Rdb_Tipo_Documento_Algunos"
        Me.Rdb_Tipo_Documento_Algunos.Size = New System.Drawing.Size(65, 23)
        Me.Rdb_Tipo_Documento_Algunos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Tipo_Documento_Algunos.TabIndex = 19
        Me.Rdb_Tipo_Documento_Algunos.Text = "Algunos"
        '
        'Rdb_Tipo_Documento_Uno
        '
        Me.Rdb_Tipo_Documento_Uno.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Tipo_Documento_Uno.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Tipo_Documento_Uno.CheckBoxImageChecked = CType(resources.GetObject("Rdb_Tipo_Documento_Uno.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Rdb_Tipo_Documento_Uno.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Tipo_Documento_Uno.FocusCuesEnabled = False
        Me.Rdb_Tipo_Documento_Uno.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Tipo_Documento_Uno.Location = New System.Drawing.Point(4, 3)
        Me.Rdb_Tipo_Documento_Uno.Name = "Rdb_Tipo_Documento_Uno"
        Me.Rdb_Tipo_Documento_Uno.Size = New System.Drawing.Size(157, 23)
        Me.Rdb_Tipo_Documento_Uno.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Tipo_Documento_Uno.TabIndex = 24
        Me.Rdb_Tipo_Documento_Uno.Text = "Uno en especifico"
        '
        'CmbTipoDeDocumentos
        '
        Me.CmbTipoDeDocumentos.DisplayMember = "Text"
        Me.CmbTipoDeDocumentos.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.CmbTipoDeDocumentos.ForeColor = System.Drawing.Color.Black
        Me.CmbTipoDeDocumentos.FormattingEnabled = True
        Me.CmbTipoDeDocumentos.ItemHeight = 16
        Me.CmbTipoDeDocumentos.Location = New System.Drawing.Point(4, 32)
        Me.CmbTipoDeDocumentos.Name = "CmbTipoDeDocumentos"
        Me.CmbTipoDeDocumentos.Size = New System.Drawing.Size(262, 22)
        Me.CmbTipoDeDocumentos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.CmbTipoDeDocumentos.TabIndex = 23
        '
        'Btn_Documentos
        '
        Me.Btn_Documentos.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Documentos.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Documentos.Image = CType(resources.GetObject("Btn_Documentos.Image"), System.Drawing.Image)
        Me.Btn_Documentos.Location = New System.Drawing.Point(808, 87)
        Me.Btn_Documentos.Name = "Btn_Documentos"
        Me.Btn_Documentos.Size = New System.Drawing.Size(31, 23)
        Me.Btn_Documentos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Documentos.TabIndex = 22
        Me.Btn_Documentos.Tooltip = "Ver selección"
        '
        'LblNroDocumento
        '
        Me.LblNroDocumento.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LblNroDocumento.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LblNroDocumento.ForeColor = System.Drawing.Color.Black
        Me.LblNroDocumento.Location = New System.Drawing.Point(276, 3)
        Me.LblNroDocumento.Name = "LblNroDocumento"
        Me.LblNroDocumento.Size = New System.Drawing.Size(75, 23)
        Me.LblNroDocumento.TabIndex = 21
        Me.LblNroDocumento.Text = "N° documento"
        '
        'Rdb_Fecha_Emision_Cualquiera
        '
        Me.Rdb_Fecha_Emision_Cualquiera.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Fecha_Emision_Cualquiera.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Fecha_Emision_Cualquiera.CheckBoxImageChecked = CType(resources.GetObject("Rdb_Fecha_Emision_Cualquiera.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Rdb_Fecha_Emision_Cualquiera.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Fecha_Emision_Cualquiera.Checked = True
        Me.Rdb_Fecha_Emision_Cualquiera.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Rdb_Fecha_Emision_Cualquiera.CheckValue = "Y"
        Me.Rdb_Fecha_Emision_Cualquiera.FocusCuesEnabled = False
        Me.Rdb_Fecha_Emision_Cualquiera.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Fecha_Emision_Cualquiera.Location = New System.Drawing.Point(3, 3)
        Me.Rdb_Fecha_Emision_Cualquiera.Name = "Rdb_Fecha_Emision_Cualquiera"
        Me.Rdb_Fecha_Emision_Cualquiera.Size = New System.Drawing.Size(97, 23)
        Me.Rdb_Fecha_Emision_Cualquiera.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Fecha_Emision_Cualquiera.TabIndex = 25
        Me.Rdb_Fecha_Emision_Cualquiera.Text = "Todas"
        '
        'Rdb_Fecha_Emision_Desde_Hasta
        '
        Me.Rdb_Fecha_Emision_Desde_Hasta.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Fecha_Emision_Desde_Hasta.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Fecha_Emision_Desde_Hasta.CheckBoxImageChecked = CType(resources.GetObject("Rdb_Fecha_Emision_Desde_Hasta.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Rdb_Fecha_Emision_Desde_Hasta.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Fecha_Emision_Desde_Hasta.FocusCuesEnabled = False
        Me.Rdb_Fecha_Emision_Desde_Hasta.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Fecha_Emision_Desde_Hasta.Location = New System.Drawing.Point(3, 23)
        Me.Rdb_Fecha_Emision_Desde_Hasta.Name = "Rdb_Fecha_Emision_Desde_Hasta"
        Me.Rdb_Fecha_Emision_Desde_Hasta.Size = New System.Drawing.Size(97, 26)
        Me.Rdb_Fecha_Emision_Desde_Hasta.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Fecha_Emision_Desde_Hasta.TabIndex = 24
        Me.Rdb_Fecha_Emision_Desde_Hasta.Text = "Emitidos entre"
        '
        'LblFecha1
        '
        Me.LblFecha1.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LblFecha1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LblFecha1.ForeColor = System.Drawing.Color.Black
        Me.LblFecha1.Location = New System.Drawing.Point(3, 57)
        Me.LblFecha1.Name = "LblFecha1"
        Me.LblFecha1.Size = New System.Drawing.Size(46, 23)
        Me.LblFecha1.TabIndex = 22
        Me.LblFecha1.Text = "Desde"
        '
        'LblFecha2
        '
        Me.LblFecha2.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LblFecha2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LblFecha2.ForeColor = System.Drawing.Color.Black
        Me.LblFecha2.Location = New System.Drawing.Point(3, 93)
        Me.LblFecha2.Name = "LblFecha2"
        Me.LblFecha2.Size = New System.Drawing.Size(36, 23)
        Me.LblFecha2.TabIndex = 23
        Me.LblFecha2.Text = "Hasta"
        '
        'Rdb_Estado_Todos
        '
        Me.Rdb_Estado_Todos.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Estado_Todos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Estado_Todos.CheckBoxImageChecked = CType(resources.GetObject("Rdb_Estado_Todos.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Rdb_Estado_Todos.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Estado_Todos.Checked = True
        Me.Rdb_Estado_Todos.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Rdb_Estado_Todos.CheckValue = "Y"
        Me.Rdb_Estado_Todos.FocusCuesEnabled = False
        Me.Rdb_Estado_Todos.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Estado_Todos.Location = New System.Drawing.Point(3, 3)
        Me.Rdb_Estado_Todos.Name = "Rdb_Estado_Todos"
        Me.Rdb_Estado_Todos.Size = New System.Drawing.Size(74, 23)
        Me.Rdb_Estado_Todos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Estado_Todos.TabIndex = 23
        Me.Rdb_Estado_Todos.Text = "Todas"
        '
        'Rdb_Estado_Vigente
        '
        Me.Rdb_Estado_Vigente.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Estado_Vigente.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Estado_Vigente.CheckBoxImageChecked = CType(resources.GetObject("Rdb_Estado_Vigente.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Rdb_Estado_Vigente.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Estado_Vigente.FocusCuesEnabled = False
        Me.Rdb_Estado_Vigente.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Estado_Vigente.Location = New System.Drawing.Point(3, 32)
        Me.Rdb_Estado_Vigente.Name = "Rdb_Estado_Vigente"
        Me.Rdb_Estado_Vigente.Size = New System.Drawing.Size(74, 31)
        Me.Rdb_Estado_Vigente.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Estado_Vigente.TabIndex = 22
        Me.Rdb_Estado_Vigente.Text = "Vigente"
        '
        'Rdb_Estado_Cerradas
        '
        Me.Rdb_Estado_Cerradas.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Estado_Cerradas.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Estado_Cerradas.CheckBoxImageChecked = CType(resources.GetObject("Rdb_Estado_Cerradas.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Rdb_Estado_Cerradas.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Estado_Cerradas.FocusCuesEnabled = False
        Me.Rdb_Estado_Cerradas.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Estado_Cerradas.Location = New System.Drawing.Point(3, 69)
        Me.Rdb_Estado_Cerradas.Name = "Rdb_Estado_Cerradas"
        Me.Rdb_Estado_Cerradas.Size = New System.Drawing.Size(74, 23)
        Me.Rdb_Estado_Cerradas.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Estado_Cerradas.TabIndex = 21
        Me.Rdb_Estado_Cerradas.Text = "Cerrado"
        '
        'Rdb_Funcionarios_Uno
        '
        Me.Rdb_Funcionarios_Uno.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Funcionarios_Uno.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Funcionarios_Uno.CheckBoxImageChecked = CType(resources.GetObject("Rdb_Funcionarios_Uno.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Rdb_Funcionarios_Uno.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Funcionarios_Uno.FocusCuesEnabled = False
        Me.Rdb_Funcionarios_Uno.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Funcionarios_Uno.Location = New System.Drawing.Point(181, 12)
        Me.Rdb_Funcionarios_Uno.Name = "Rdb_Funcionarios_Uno"
        Me.Rdb_Funcionarios_Uno.Size = New System.Drawing.Size(106, 24)
        Me.Rdb_Funcionarios_Uno.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Funcionarios_Uno.TabIndex = 26
        Me.Rdb_Funcionarios_Uno.Text = "Uno en especifico"
        '
        'CmbFuncionarios
        '
        Me.CmbFuncionarios.DisplayMember = "Text"
        Me.CmbFuncionarios.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.CmbFuncionarios.ForeColor = System.Drawing.Color.Black
        Me.CmbFuncionarios.FormattingEnabled = True
        Me.CmbFuncionarios.ItemHeight = 16
        Me.CmbFuncionarios.Location = New System.Drawing.Point(293, 13)
        Me.CmbFuncionarios.Name = "CmbFuncionarios"
        Me.CmbFuncionarios.Size = New System.Drawing.Size(366, 22)
        Me.CmbFuncionarios.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.CmbFuncionarios.TabIndex = 25
        '
        'Btn_Funcionarios
        '
        Me.Btn_Funcionarios.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Funcionarios.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Funcionarios.Image = CType(resources.GetObject("Btn_Funcionarios.Image"), System.Drawing.Image)
        Me.Btn_Funcionarios.Location = New System.Drawing.Point(135, 13)
        Me.Btn_Funcionarios.Name = "Btn_Funcionarios"
        Me.Btn_Funcionarios.Size = New System.Drawing.Size(31, 23)
        Me.Btn_Funcionarios.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Funcionarios.TabIndex = 23
        Me.Btn_Funcionarios.Tooltip = "Ver selección"
        '
        'Rdb_Funcionarios_Todos
        '
        Me.Rdb_Funcionarios_Todos.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Funcionarios_Todos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Funcionarios_Todos.CheckBoxImageChecked = CType(resources.GetObject("Rdb_Funcionarios_Todos.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Rdb_Funcionarios_Todos.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Funcionarios_Todos.Checked = True
        Me.Rdb_Funcionarios_Todos.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Rdb_Funcionarios_Todos.CheckValue = "Y"
        Me.Rdb_Funcionarios_Todos.FocusCuesEnabled = False
        Me.Rdb_Funcionarios_Todos.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Funcionarios_Todos.Location = New System.Drawing.Point(3, 13)
        Me.Rdb_Funcionarios_Todos.Name = "Rdb_Funcionarios_Todos"
        Me.Rdb_Funcionarios_Todos.Size = New System.Drawing.Size(56, 22)
        Me.Rdb_Funcionarios_Todos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Funcionarios_Todos.TabIndex = 20
        Me.Rdb_Funcionarios_Todos.Text = "Todos"
        '
        'Rdb_Funcionarios_Algunos
        '
        Me.Rdb_Funcionarios_Algunos.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Funcionarios_Algunos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Funcionarios_Algunos.CheckBoxImageChecked = CType(resources.GetObject("Rdb_Funcionarios_Algunos.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Rdb_Funcionarios_Algunos.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Funcionarios_Algunos.FocusCuesEnabled = False
        Me.Rdb_Funcionarios_Algunos.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Funcionarios_Algunos.Location = New System.Drawing.Point(65, 13)
        Me.Rdb_Funcionarios_Algunos.Name = "Rdb_Funcionarios_Algunos"
        Me.Rdb_Funcionarios_Algunos.Size = New System.Drawing.Size(64, 22)
        Me.Rdb_Funcionarios_Algunos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Funcionarios_Algunos.TabIndex = 19
        Me.Rdb_Funcionarios_Algunos.Text = "Algunos"
        '
        'CmbCantFilas
        '
        Me.CmbCantFilas.BackColor = System.Drawing.Color.White
        Me.CmbCantFilas.ForeColor = System.Drawing.Color.Black
        Me.CmbCantFilas.FormatString = "N0"
        Me.CmbCantFilas.FormattingEnabled = True
        Me.CmbCantFilas.Items.AddRange(New Object() {"10", "20", "30", "40", "50", "100", "200", "1000", "10000", "100000"})
        Me.CmbCantFilas.Location = New System.Drawing.Point(193, 65)
        Me.CmbCantFilas.Name = "CmbCantFilas"
        Me.CmbCantFilas.Size = New System.Drawing.Size(73, 21)
        Me.CmbCantFilas.TabIndex = 26
        Me.CmbCantFilas.Text = "50"
        '
        'Grupo_documento
        '
        Me.Grupo_documento.BackColor = System.Drawing.Color.White
        Me.Grupo_documento.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Grupo_documento.Controls.Add(Me.TableLayoutPanel3)
        Me.Grupo_documento.Controls.Add(Me.LabelX1)
        Me.Grupo_documento.Controls.Add(Me.TableLayoutPanel2)
        Me.Grupo_documento.Controls.Add(Me.CmbCantFilas)
        Me.Grupo_documento.Controls.Add(Me.Rdb_Tipo_Documento_Uno)
        Me.Grupo_documento.Controls.Add(Me.CmbTipoDeDocumentos)
        Me.Grupo_documento.Controls.Add(Me.LblNroDocumento)
        Me.Grupo_documento.Controls.Add(Me.TxtNroDocumento)
        Me.Grupo_documento.DisabledBackColor = System.Drawing.Color.Empty
        Me.Grupo_documento.Location = New System.Drawing.Point(12, 12)
        Me.Grupo_documento.Name = "Grupo_documento"
        Me.Grupo_documento.Size = New System.Drawing.Size(395, 155)
        '
        '
        '
        Me.Grupo_documento.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Grupo_documento.Style.BackColorGradientAngle = 90
        Me.Grupo_documento.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Grupo_documento.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_documento.Style.BorderBottomWidth = 1
        Me.Grupo_documento.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.Grupo_documento.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_documento.Style.BorderLeftWidth = 1
        Me.Grupo_documento.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_documento.Style.BorderRightWidth = 1
        Me.Grupo_documento.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_documento.Style.BorderTopWidth = 1
        Me.Grupo_documento.Style.CornerDiameter = 4
        Me.Grupo_documento.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Grupo_documento.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.Grupo_documento.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.Grupo_documento.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.Grupo_documento.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.Grupo_documento.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Grupo_documento.TabIndex = 29
        Me.Grupo_documento.Text = "Filtro de documentos"
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel3.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.[Single]
        Me.TableLayoutPanel3.ColumnCount = 3
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 91.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 126.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.Rdb_Sucursal_Doc_Algunas, 2, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.Rdb_Sucursal_Doc_Todas, 1, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.LabelX2, 0, 0)
        Me.TableLayoutPanel3.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(4, 99)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 1
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(382, 25)
        Me.TableLayoutPanel3.TabIndex = 36
        '
        'Rdb_Sucursal_Doc_Algunas
        '
        Me.Rdb_Sucursal_Doc_Algunas.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Sucursal_Doc_Algunas.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Sucursal_Doc_Algunas.CheckBoxImageChecked = CType(resources.GetObject("Rdb_Sucursal_Doc_Algunas.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Rdb_Sucursal_Doc_Algunas.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Sucursal_Doc_Algunas.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Sucursal_Doc_Algunas.Location = New System.Drawing.Point(258, 4)
        Me.Rdb_Sucursal_Doc_Algunas.Name = "Rdb_Sucursal_Doc_Algunas"
        Me.Rdb_Sucursal_Doc_Algunas.Size = New System.Drawing.Size(94, 17)
        Me.Rdb_Sucursal_Doc_Algunas.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Sucursal_Doc_Algunas.TabIndex = 3
        Me.Rdb_Sucursal_Doc_Algunas.Text = "Algunos"
        '
        'Rdb_Sucursal_Doc_Todas
        '
        Me.Rdb_Sucursal_Doc_Todas.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Sucursal_Doc_Todas.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Sucursal_Doc_Todas.CheckBoxImageChecked = CType(resources.GetObject("Rdb_Sucursal_Doc_Todas.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Rdb_Sucursal_Doc_Todas.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Sucursal_Doc_Todas.Checked = True
        Me.Rdb_Sucursal_Doc_Todas.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Rdb_Sucursal_Doc_Todas.CheckValue = "Y"
        Me.Rdb_Sucursal_Doc_Todas.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Sucursal_Doc_Todas.Location = New System.Drawing.Point(166, 4)
        Me.Rdb_Sucursal_Doc_Todas.Name = "Rdb_Sucursal_Doc_Todas"
        Me.Rdb_Sucursal_Doc_Todas.Size = New System.Drawing.Size(85, 17)
        Me.Rdb_Sucursal_Doc_Todas.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Sucursal_Doc_Todas.TabIndex = 1
        Me.Rdb_Sucursal_Doc_Todas.Text = "Todos"
        '
        'LabelX2
        '
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.ForeColor = System.Drawing.Color.Black
        Me.LabelX2.Location = New System.Drawing.Point(4, 4)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(131, 17)
        Me.LabelX2.TabIndex = 4
        Me.LabelX2.Text = "Sucursal documento"
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.ForeColor = System.Drawing.Color.Black
        Me.LabelX1.Location = New System.Drawing.Point(4, 63)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(23, 23)
        Me.LabelX1.TabIndex = 35
        Me.LabelX1.Text = "Ver"
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.Rdb_Ver_Primeros, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Rdb_Ver_Ultimos, 1, 0)
        Me.TableLayoutPanel2.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(38, 61)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(148, 32)
        Me.TableLayoutPanel2.TabIndex = 34
        '
        'Rdb_Ver_Primeros
        '
        Me.Rdb_Ver_Primeros.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Ver_Primeros.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Ver_Primeros.CheckBoxImageChecked = CType(resources.GetObject("Rdb_Ver_Primeros.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Rdb_Ver_Primeros.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Ver_Primeros.FocusCuesEnabled = False
        Me.Rdb_Ver_Primeros.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Ver_Primeros.Location = New System.Drawing.Point(3, 3)
        Me.Rdb_Ver_Primeros.Name = "Rdb_Ver_Primeros"
        Me.Rdb_Ver_Primeros.Size = New System.Drawing.Size(68, 22)
        Me.Rdb_Ver_Primeros.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Ver_Primeros.TabIndex = 23
        Me.Rdb_Ver_Primeros.Text = "Primeros"
        '
        'Rdb_Ver_Ultimos
        '
        Me.Rdb_Ver_Ultimos.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Ver_Ultimos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Ver_Ultimos.CheckBoxImageChecked = CType(resources.GetObject("Rdb_Ver_Ultimos.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Rdb_Ver_Ultimos.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Ver_Ultimos.Checked = True
        Me.Rdb_Ver_Ultimos.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Rdb_Ver_Ultimos.CheckValue = "Y"
        Me.Rdb_Ver_Ultimos.FocusCuesEnabled = False
        Me.Rdb_Ver_Ultimos.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Ver_Ultimos.Location = New System.Drawing.Point(77, 3)
        Me.Rdb_Ver_Ultimos.Name = "Rdb_Ver_Ultimos"
        Me.Rdb_Ver_Ultimos.Size = New System.Drawing.Size(65, 22)
        Me.Rdb_Ver_Ultimos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Ver_Ultimos.TabIndex = 22
        Me.Rdb_Ver_Ultimos.Text = "Ultimos"
        '
        'Grupo_Fecha
        '
        Me.Grupo_Fecha.BackColor = System.Drawing.Color.White
        Me.Grupo_Fecha.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Grupo_Fecha.Controls.Add(Me.DtpFechaFin)
        Me.Grupo_Fecha.Controls.Add(Me.DtpFechaInicio)
        Me.Grupo_Fecha.Controls.Add(Me.Rdb_Fecha_Emision_Cualquiera)
        Me.Grupo_Fecha.Controls.Add(Me.Rdb_Fecha_Emision_Desde_Hasta)
        Me.Grupo_Fecha.Controls.Add(Me.LblFecha2)
        Me.Grupo_Fecha.Controls.Add(Me.LblFecha1)
        Me.Grupo_Fecha.DisabledBackColor = System.Drawing.Color.Empty
        Me.Grupo_Fecha.Location = New System.Drawing.Point(413, 12)
        Me.Grupo_Fecha.Name = "Grupo_Fecha"
        Me.Grupo_Fecha.Size = New System.Drawing.Size(155, 155)
        '
        '
        '
        Me.Grupo_Fecha.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Grupo_Fecha.Style.BackColorGradientAngle = 90
        Me.Grupo_Fecha.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Grupo_Fecha.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Fecha.Style.BorderBottomWidth = 1
        Me.Grupo_Fecha.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.Grupo_Fecha.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Fecha.Style.BorderLeftWidth = 1
        Me.Grupo_Fecha.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Fecha.Style.BorderRightWidth = 1
        Me.Grupo_Fecha.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Fecha.Style.BorderTopWidth = 1
        Me.Grupo_Fecha.Style.CornerDiameter = 4
        Me.Grupo_Fecha.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Grupo_Fecha.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.Grupo_Fecha.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.Grupo_Fecha.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.Grupo_Fecha.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.Grupo_Fecha.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Grupo_Fecha.TabIndex = 30
        Me.Grupo_Fecha.Text = "Fecha de emisión"
        '
        'DtpFechaFin
        '
        Me.DtpFechaFin.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.DtpFechaFin.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.DtpFechaFin.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.DtpFechaFin.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.DtpFechaFin.ButtonDropDown.Visible = True
        Me.DtpFechaFin.ForeColor = System.Drawing.Color.Black
        Me.DtpFechaFin.IsPopupCalendarOpen = False
        Me.DtpFechaFin.Location = New System.Drawing.Point(56, 95)
        '
        '
        '
        Me.DtpFechaFin.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.DtpFechaFin.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.DtpFechaFin.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.DtpFechaFin.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.DtpFechaFin.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.DtpFechaFin.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.DtpFechaFin.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.DtpFechaFin.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.DtpFechaFin.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.DtpFechaFin.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.DtpFechaFin.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.DtpFechaFin.MonthCalendar.DisplayMonth = New Date(2016, 7, 1, 0, 0, 0, 0)
        Me.DtpFechaFin.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday
        Me.DtpFechaFin.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.DtpFechaFin.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.DtpFechaFin.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.DtpFechaFin.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.DtpFechaFin.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.DtpFechaFin.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.DtpFechaFin.MonthCalendar.TodayButtonVisible = True
        Me.DtpFechaFin.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.DtpFechaFin.Name = "DtpFechaFin"
        Me.DtpFechaFin.Size = New System.Drawing.Size(83, 22)
        Me.DtpFechaFin.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.DtpFechaFin.TabIndex = 36
        Me.DtpFechaFin.Value = New Date(2016, 7, 8, 16, 33, 0, 0)
        '
        'DtpFechaInicio
        '
        Me.DtpFechaInicio.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.DtpFechaInicio.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.DtpFechaInicio.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.DtpFechaInicio.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.DtpFechaInicio.ButtonDropDown.Visible = True
        Me.DtpFechaInicio.ForeColor = System.Drawing.Color.Black
        Me.DtpFechaInicio.IsPopupCalendarOpen = False
        Me.DtpFechaInicio.Location = New System.Drawing.Point(56, 58)
        '
        '
        '
        Me.DtpFechaInicio.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.DtpFechaInicio.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.DtpFechaInicio.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.DtpFechaInicio.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.DtpFechaInicio.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.DtpFechaInicio.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.DtpFechaInicio.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.DtpFechaInicio.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.DtpFechaInicio.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.DtpFechaInicio.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.DtpFechaInicio.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.DtpFechaInicio.MonthCalendar.DisplayMonth = New Date(2016, 7, 1, 0, 0, 0, 0)
        Me.DtpFechaInicio.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday
        Me.DtpFechaInicio.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.DtpFechaInicio.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.DtpFechaInicio.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.DtpFechaInicio.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.DtpFechaInicio.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.DtpFechaInicio.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.DtpFechaInicio.MonthCalendar.TodayButtonVisible = True
        Me.DtpFechaInicio.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.DtpFechaInicio.Name = "DtpFechaInicio"
        Me.DtpFechaInicio.Size = New System.Drawing.Size(83, 22)
        Me.DtpFechaInicio.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.DtpFechaInicio.TabIndex = 35
        Me.DtpFechaInicio.Value = New Date(2016, 7, 8, 16, 33, 0, 0)
        '
        'Grupo_Estado_Documento
        '
        Me.Grupo_Estado_Documento.BackColor = System.Drawing.Color.White
        Me.Grupo_Estado_Documento.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Grupo_Estado_Documento.Controls.Add(Me.TableLayoutPanel1)
        Me.Grupo_Estado_Documento.DisabledBackColor = System.Drawing.Color.Empty
        Me.Grupo_Estado_Documento.Location = New System.Drawing.Point(574, 12)
        Me.Grupo_Estado_Documento.Name = "Grupo_Estado_Documento"
        Me.Grupo_Estado_Documento.Size = New System.Drawing.Size(118, 155)
        '
        '
        '
        Me.Grupo_Estado_Documento.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Grupo_Estado_Documento.Style.BackColorGradientAngle = 90
        Me.Grupo_Estado_Documento.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Grupo_Estado_Documento.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Estado_Documento.Style.BorderBottomWidth = 1
        Me.Grupo_Estado_Documento.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.Grupo_Estado_Documento.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Estado_Documento.Style.BorderLeftWidth = 1
        Me.Grupo_Estado_Documento.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Estado_Documento.Style.BorderRightWidth = 1
        Me.Grupo_Estado_Documento.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Estado_Documento.Style.BorderTopWidth = 1
        Me.Grupo_Estado_Documento.Style.CornerDiameter = 4
        Me.Grupo_Estado_Documento.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Grupo_Estado_Documento.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.Grupo_Estado_Documento.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.Grupo_Estado_Documento.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.Grupo_Estado_Documento.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.Grupo_Estado_Documento.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Grupo_Estado_Documento.TabIndex = 31
        Me.Grupo_Estado_Documento.Text = "Estado documento"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Rdb_Estado_Vigente, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Rdb_Estado_Todos, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Rdb_Estado_Cerradas, 0, 2)
        Me.TableLayoutPanel1.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(17, 23)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(80, 89)
        Me.TableLayoutPanel1.TabIndex = 33
        '
        'Grupo_Entidad
        '
        Me.Grupo_Entidad.BackColor = System.Drawing.Color.White
        Me.Grupo_Entidad.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Grupo_Entidad.Controls.Add(Me.Chk_Todas_Sucursales)
        Me.Grupo_Entidad.Controls.Add(Me.Btn_Entidad_Una)
        Me.Grupo_Entidad.Controls.Add(Me.Rdb_Entidad_Todas)
        Me.Grupo_Entidad.Controls.Add(Me.Rdb_Entidad_Una)
        Me.Grupo_Entidad.Controls.Add(Me.ChkBuscarEntidadFisica)
        Me.Grupo_Entidad.Controls.Add(Me.Txt_Entidad)
        Me.Grupo_Entidad.DisabledBackColor = System.Drawing.Color.Empty
        Me.Grupo_Entidad.Location = New System.Drawing.Point(12, 173)
        Me.Grupo_Entidad.Name = "Grupo_Entidad"
        Me.Grupo_Entidad.Size = New System.Drawing.Size(680, 100)
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
        Me.Grupo_Entidad.TabIndex = 32
        Me.Grupo_Entidad.Text = "Entidad del documento"
        '
        'Chk_Todas_Sucursales
        '
        Me.Chk_Todas_Sucursales.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_Todas_Sucursales.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Todas_Sucursales.CheckBoxImageChecked = CType(resources.GetObject("Chk_Todas_Sucursales.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_Todas_Sucursales.FocusCuesEnabled = False
        Me.Chk_Todas_Sucursales.ForeColor = System.Drawing.Color.Black
        Me.Chk_Todas_Sucursales.Location = New System.Drawing.Point(398, 15)
        Me.Chk_Todas_Sucursales.Name = "Chk_Todas_Sucursales"
        Me.Chk_Todas_Sucursales.Size = New System.Drawing.Size(151, 23)
        Me.Chk_Todas_Sucursales.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Todas_Sucursales.TabIndex = 29
        Me.Chk_Todas_Sucursales.Text = "Buscar todas las sucursales"
        '
        'Grupo_Funcionario
        '
        Me.Grupo_Funcionario.BackColor = System.Drawing.Color.White
        Me.Grupo_Funcionario.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Grupo_Funcionario.Controls.Add(Me.Rdb_Funcionarios_Uno)
        Me.Grupo_Funcionario.Controls.Add(Me.Rdb_Funcionarios_Todos)
        Me.Grupo_Funcionario.Controls.Add(Me.CmbFuncionarios)
        Me.Grupo_Funcionario.Controls.Add(Me.Rdb_Funcionarios_Algunos)
        Me.Grupo_Funcionario.Controls.Add(Me.Btn_Funcionarios)
        Me.Grupo_Funcionario.DisabledBackColor = System.Drawing.Color.Empty
        Me.Grupo_Funcionario.Location = New System.Drawing.Point(12, 279)
        Me.Grupo_Funcionario.Name = "Grupo_Funcionario"
        Me.Grupo_Funcionario.Size = New System.Drawing.Size(680, 68)
        '
        '
        '
        Me.Grupo_Funcionario.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Grupo_Funcionario.Style.BackColorGradientAngle = 90
        Me.Grupo_Funcionario.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Grupo_Funcionario.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Funcionario.Style.BorderBottomWidth = 1
        Me.Grupo_Funcionario.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.Grupo_Funcionario.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Funcionario.Style.BorderLeftWidth = 1
        Me.Grupo_Funcionario.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Funcionario.Style.BorderRightWidth = 1
        Me.Grupo_Funcionario.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Funcionario.Style.BorderTopWidth = 1
        Me.Grupo_Funcionario.Style.CornerDiameter = 4
        Me.Grupo_Funcionario.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Grupo_Funcionario.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.Grupo_Funcionario.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.Grupo_Funcionario.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.Grupo_Funcionario.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.Grupo_Funcionario.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Grupo_Funcionario.TabIndex = 33
        Me.Grupo_Funcionario.Text = "Funcionario que creo el documento"
        '
        'Grupo_Producto
        '
        Me.Grupo_Producto.BackColor = System.Drawing.Color.White
        Me.Grupo_Producto.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Grupo_Producto.Controls.Add(Me.Btn_Producto_Uno)
        Me.Grupo_Producto.Controls.Add(Me.Rdb_Producto_Todos)
        Me.Grupo_Producto.Controls.Add(Me.Rdb_Producto_Uno)
        Me.Grupo_Producto.Controls.Add(Me.Txt_Producto)
        Me.Grupo_Producto.DisabledBackColor = System.Drawing.Color.Empty
        Me.Grupo_Producto.Location = New System.Drawing.Point(12, 353)
        Me.Grupo_Producto.Name = "Grupo_Producto"
        Me.Grupo_Producto.Size = New System.Drawing.Size(680, 88)
        '
        '
        '
        Me.Grupo_Producto.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Grupo_Producto.Style.BackColorGradientAngle = 90
        Me.Grupo_Producto.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Grupo_Producto.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Producto.Style.BorderBottomWidth = 1
        Me.Grupo_Producto.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.Grupo_Producto.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Producto.Style.BorderLeftWidth = 1
        Me.Grupo_Producto.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Producto.Style.BorderRightWidth = 1
        Me.Grupo_Producto.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Producto.Style.BorderTopWidth = 1
        Me.Grupo_Producto.Style.CornerDiameter = 4
        Me.Grupo_Producto.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Grupo_Producto.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.Grupo_Producto.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.Grupo_Producto.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.Grupo_Producto.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.Grupo_Producto.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Grupo_Producto.TabIndex = 34
        Me.Grupo_Producto.Text = "Contiene producto en particular"
        '
        'Btn_Producto_Uno
        '
        Me.Btn_Producto_Uno.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Producto_Uno.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Producto_Uno.Image = CType(resources.GetObject("Btn_Producto_Uno.Image"), System.Drawing.Image)
        Me.Btn_Producto_Uno.Location = New System.Drawing.Point(135, 32)
        Me.Btn_Producto_Uno.Name = "Btn_Producto_Uno"
        Me.Btn_Producto_Uno.Size = New System.Drawing.Size(31, 23)
        Me.Btn_Producto_Uno.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Producto_Uno.TabIndex = 28
        Me.Btn_Producto_Uno.Tooltip = "Ver selección"
        '
        'Rdb_Producto_Todos
        '
        Me.Rdb_Producto_Todos.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Producto_Todos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Producto_Todos.CheckBoxImageChecked = CType(resources.GetObject("Rdb_Producto_Todos.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Rdb_Producto_Todos.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Producto_Todos.Checked = True
        Me.Rdb_Producto_Todos.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Rdb_Producto_Todos.CheckValue = "Y"
        Me.Rdb_Producto_Todos.FocusCuesEnabled = False
        Me.Rdb_Producto_Todos.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Producto_Todos.Location = New System.Drawing.Point(3, 3)
        Me.Rdb_Producto_Todos.Name = "Rdb_Producto_Todos"
        Me.Rdb_Producto_Todos.Size = New System.Drawing.Size(56, 23)
        Me.Rdb_Producto_Todos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Producto_Todos.TabIndex = 22
        Me.Rdb_Producto_Todos.Text = "Todos"
        '
        'Rdb_Producto_Uno
        '
        Me.Rdb_Producto_Uno.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Producto_Uno.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Producto_Uno.CheckBoxImageChecked = CType(resources.GetObject("Rdb_Producto_Uno.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Rdb_Producto_Uno.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Producto_Uno.FocusCuesEnabled = False
        Me.Rdb_Producto_Uno.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Producto_Uno.Location = New System.Drawing.Point(3, 32)
        Me.Rdb_Producto_Uno.Name = "Rdb_Producto_Uno"
        Me.Rdb_Producto_Uno.Size = New System.Drawing.Size(106, 23)
        Me.Rdb_Producto_Uno.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Producto_Uno.TabIndex = 27
        Me.Rdb_Producto_Uno.Text = "Uno en especifico"
        '
        'Txt_Producto
        '
        Me.Txt_Producto.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Producto.Border.Class = "TextBoxBorder"
        Me.Txt_Producto.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Producto.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Producto.Enabled = False
        Me.Txt_Producto.ForeColor = System.Drawing.Color.Black
        Me.Txt_Producto.Location = New System.Drawing.Point(172, 33)
        Me.Txt_Producto.Name = "Txt_Producto"
        Me.Txt_Producto.PreventEnterBeep = True
        Me.Txt_Producto.ReadOnly = True
        Me.Txt_Producto.Size = New System.Drawing.Size(487, 22)
        Me.Txt_Producto.TabIndex = 9
        '
        'Chk_Mostrar_Vales_Transitorios
        '
        Me.Chk_Mostrar_Vales_Transitorios.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Chk_Mostrar_Vales_Transitorios.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Chk_Mostrar_Vales_Transitorios.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Mostrar_Vales_Transitorios.CheckBoxImageChecked = CType(resources.GetObject("Chk_Mostrar_Vales_Transitorios.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_Mostrar_Vales_Transitorios.Checked = True
        Me.Chk_Mostrar_Vales_Transitorios.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Chk_Mostrar_Vales_Transitorios.CheckValue = "Y"
        Me.Chk_Mostrar_Vales_Transitorios.FocusCuesEnabled = False
        Me.Chk_Mostrar_Vales_Transitorios.ForeColor = System.Drawing.Color.Black
        Me.Chk_Mostrar_Vales_Transitorios.Location = New System.Drawing.Point(12, 532)
        Me.Chk_Mostrar_Vales_Transitorios.Name = "Chk_Mostrar_Vales_Transitorios"
        Me.Chk_Mostrar_Vales_Transitorios.Size = New System.Drawing.Size(183, 19)
        Me.Chk_Mostrar_Vales_Transitorios.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Mostrar_Vales_Transitorios.TabIndex = 35
        Me.Chk_Mostrar_Vales_Transitorios.Text = "Mostrar vales transitorios"
        '
        'GroupPanel1
        '
        Me.GroupPanel1.BackColor = System.Drawing.Color.White
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.Txt_Placapat)
        Me.GroupPanel1.Controls.Add(Me.LabelX5)
        Me.GroupPanel1.Controls.Add(Me.Txt_CodRetirador)
        Me.GroupPanel1.Controls.Add(Me.LabelX4)
        Me.GroupPanel1.Controls.Add(Me.Txt_Ocdo)
        Me.GroupPanel1.Controls.Add(Me.LabelX3)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Location = New System.Drawing.Point(12, 447)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(680, 74)
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
        Me.GroupPanel1.TabIndex = 36
        Me.GroupPanel1.Text = "Ordenes de compra / Retiradores de mercadería / Patente asociada"
        '
        'Txt_Placapat
        '
        Me.Txt_Placapat.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Placapat.Border.Class = "TextBoxBorder"
        Me.Txt_Placapat.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Placapat.ButtonCustom.Image = CType(resources.GetObject("Txt_Placapat.ButtonCustom.Image"), System.Drawing.Image)
        Me.Txt_Placapat.ButtonCustom.Visible = True
        Me.Txt_Placapat.ButtonCustom2.Image = CType(resources.GetObject("Txt_Placapat.ButtonCustom2.Image"), System.Drawing.Image)
        Me.Txt_Placapat.ButtonCustom2.Visible = True
        Me.Txt_Placapat.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Placapat.ForeColor = System.Drawing.Color.Black
        Me.Txt_Placapat.Location = New System.Drawing.Point(537, 23)
        Me.Txt_Placapat.MaxLength = 20
        Me.Txt_Placapat.Name = "Txt_Placapat"
        Me.Txt_Placapat.PreventEnterBeep = True
        Me.Txt_Placapat.ReadOnly = True
        Me.Txt_Placapat.Size = New System.Drawing.Size(122, 22)
        Me.Txt_Placapat.TabIndex = 7
        '
        'LabelX5
        '
        Me.LabelX5.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX5.ForeColor = System.Drawing.Color.Black
        Me.LabelX5.Location = New System.Drawing.Point(537, 3)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.Size = New System.Drawing.Size(89, 23)
        Me.LabelX5.TabIndex = 6
        Me.LabelX5.Text = "Placa Patente"
        '
        'Txt_CodRetirador
        '
        Me.Txt_CodRetirador.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_CodRetirador.Border.Class = "TextBoxBorder"
        Me.Txt_CodRetirador.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_CodRetirador.ButtonCustom.Visible = True
        Me.Txt_CodRetirador.ButtonCustom2.Visible = True
        Me.Txt_CodRetirador.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_CodRetirador.ForeColor = System.Drawing.Color.Black
        Me.Txt_CodRetirador.Location = New System.Drawing.Point(138, 23)
        Me.Txt_CodRetirador.MaxLength = 20
        Me.Txt_CodRetirador.Name = "Txt_CodRetirador"
        Me.Txt_CodRetirador.PreventEnterBeep = True
        Me.Txt_CodRetirador.ReadOnly = True
        Me.Txt_CodRetirador.Size = New System.Drawing.Size(391, 22)
        Me.Txt_CodRetirador.TabIndex = 9
        '
        'LabelX4
        '
        Me.LabelX4.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.ForeColor = System.Drawing.Color.Black
        Me.LabelX4.Location = New System.Drawing.Point(139, 3)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(161, 23)
        Me.LabelX4.TabIndex = 8
        Me.LabelX4.Text = "Retirador de mercaderías"
        '
        'Txt_Ocdo
        '
        Me.Txt_Ocdo.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Ocdo.Border.Class = "TextBoxBorder"
        Me.Txt_Ocdo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Ocdo.ButtonCustom.Image = CType(resources.GetObject("Txt_Ocdo.ButtonCustom.Image"), System.Drawing.Image)
        Me.Txt_Ocdo.ButtonCustom.Visible = True
        Me.Txt_Ocdo.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Ocdo.ForeColor = System.Drawing.Color.Black
        Me.Txt_Ocdo.Location = New System.Drawing.Point(9, 23)
        Me.Txt_Ocdo.MaxLength = 20
        Me.Txt_Ocdo.Name = "Txt_Ocdo"
        Me.Txt_Ocdo.PreventEnterBeep = True
        Me.Txt_Ocdo.Size = New System.Drawing.Size(120, 22)
        Me.Txt_Ocdo.TabIndex = 3
        '
        'LabelX3
        '
        Me.LabelX3.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.ForeColor = System.Drawing.Color.Black
        Me.LabelX3.Location = New System.Drawing.Point(9, 3)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(89, 23)
        Me.LabelX3.TabIndex = 2
        Me.LabelX3.Text = "Orden de compra"
        '
        'Frm_BusquedaDocumento_Filtro
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(700, 598)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Controls.Add(Me.Chk_Mostrar_Vales_Transitorios)
        Me.Controls.Add(Me.Grupo_Producto)
        Me.Controls.Add(Me.Grupo_Funcionario)
        Me.Controls.Add(Me.Grupo_Entidad)
        Me.Controls.Add(Me.Grupo_Estado_Documento)
        Me.Controls.Add(Me.Grupo_Fecha)
        Me.Controls.Add(Me.Grupo_documento)
        Me.Controls.Add(Me.Bar1)
        Me.Controls.Add(Me.Btn_Documentos)
        Me.Controls.Add(Me.Rdb_Tipo_Documento_Algunos)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_BusquedaDocumento_Filtro"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Buscar documento"
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Grupo_documento.ResumeLayout(False)
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.Grupo_Fecha.ResumeLayout(False)
        CType(Me.DtpFechaFin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DtpFechaInicio, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Grupo_Estado_Documento.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Grupo_Entidad.ResumeLayout(False)
        Me.Grupo_Funcionario.ResumeLayout(False)
        Me.Grupo_Producto.ResumeLayout(False)
        Me.GroupPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Public WithEvents Txt_Entidad As DevComponents.DotNetBar.Controls.TextBoxX
    Public WithEvents ChkBuscarEntidadFisica As DevComponents.DotNetBar.Controls.CheckBoxX
    Public WithEvents TxtNroDocumento As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents BtnAceptar As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Rdb_Tipo_Documento_Algunos As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents LblNroDocumento As DevComponents.DotNetBar.LabelX
    Public WithEvents Rdb_Fecha_Emision_Cualquiera As DevComponents.DotNetBar.Controls.CheckBoxX
    Public WithEvents Rdb_Fecha_Emision_Desde_Hasta As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents LblFecha1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LblFecha2 As DevComponents.DotNetBar.LabelX
    Public WithEvents Rdb_Entidad_Todas As DevComponents.DotNetBar.Controls.CheckBoxX
    Public WithEvents Rdb_Estado_Vigente As DevComponents.DotNetBar.Controls.CheckBoxX
    Public WithEvents Rdb_Estado_Cerradas As DevComponents.DotNetBar.Controls.CheckBoxX
    Public WithEvents Rdb_Funcionarios_Todos As DevComponents.DotNetBar.Controls.CheckBoxX
    Public WithEvents Rdb_Funcionarios_Algunos As DevComponents.DotNetBar.Controls.CheckBoxX
    Public WithEvents Rdb_Tipo_Documento_Uno As DevComponents.DotNetBar.Controls.CheckBoxX
    Public WithEvents CmbTipoDeDocumentos As DevComponents.DotNetBar.Controls.ComboBoxEx
    Public WithEvents Btn_Documentos As DevComponents.DotNetBar.ButtonX
    Public WithEvents Btn_Funcionarios As DevComponents.DotNetBar.ButtonX
    Friend WithEvents CmbCantFilas As System.Windows.Forms.ComboBox
    Public WithEvents Rdb_Funcionarios_Uno As DevComponents.DotNetBar.Controls.CheckBoxX
    Public WithEvents CmbFuncionarios As DevComponents.DotNetBar.Controls.ComboBoxEx
    Public WithEvents Btn_Entidad_Una As DevComponents.DotNetBar.ButtonX
    Public WithEvents Rdb_Entidad_Una As DevComponents.DotNetBar.Controls.CheckBoxX
    Public WithEvents Rdb_Estado_Todos As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Grupo_Fecha As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Grupo_Estado_Documento As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Public WithEvents Grupo_Funcionario As DevComponents.DotNetBar.Controls.GroupPanel
    Public WithEvents Grupo_documento As DevComponents.DotNetBar.Controls.GroupPanel
    Public WithEvents Btn_Producto_Uno As DevComponents.DotNetBar.ButtonX
    Public WithEvents Rdb_Producto_Todos As DevComponents.DotNetBar.Controls.CheckBoxX
    Public WithEvents Rdb_Producto_Uno As DevComponents.DotNetBar.Controls.CheckBoxX
    Public WithEvents Txt_Producto As DevComponents.DotNetBar.Controls.TextBoxX
    Public WithEvents Grupo_Entidad As DevComponents.DotNetBar.Controls.GroupPanel
    Public WithEvents Grupo_Producto As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Public WithEvents Rdb_Ver_Ultimos As DevComponents.DotNetBar.Controls.CheckBoxX
    Public WithEvents Rdb_Ver_Primeros As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TableLayoutPanel3 As TableLayoutPanel
    Friend WithEvents Rdb_Sucursal_Doc_Algunas As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_Sucursal_Doc_Todas As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents DtpFechaFin As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents DtpFechaInicio As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Public WithEvents Chk_Todas_Sucursales As DevComponents.DotNetBar.Controls.CheckBoxX
    Public WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Txt_Placapat As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Txt_Ocdo As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Txt_CodRetirador As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Public WithEvents Chk_Mostrar_Vales_Transitorios As DevComponents.DotNetBar.Controls.CheckBoxX
End Class
