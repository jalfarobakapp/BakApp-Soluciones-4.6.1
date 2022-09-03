<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_SolCredito_Listado
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_SolCredito_Listado))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.LblEspera = New DevComponents.DotNetBar.LabelX
        Me.Barra_progreso = New DevComponents.DotNetBar.Controls.ProgressBarX
        Me.LblSegundosF = New DevComponents.DotNetBar.LabelX
        Me.Cmb_MinutosActualizacion = New DevComponents.DotNetBar.Controls.ComboBoxEx
        Me.ExpandablePanel1 = New DevComponents.DotNetBar.ExpandablePanel
        Me.ItemPanel1 = New DevComponents.DotNetBar.ItemPanel
        Me.Chk_StandBy = New DevComponents.DotNetBar.CheckBoxItem
        Me.Chk_Ingresado = New DevComponents.DotNetBar.CheckBoxItem
        Me.Chk_En_Procesado = New DevComponents.DotNetBar.CheckBoxItem
        Me.Chk_Completado = New DevComponents.DotNetBar.CheckBoxItem
        Me.Chk_Cerrado = New DevComponents.DotNetBar.CheckBoxItem
        Me.Chk_Nulas = New DevComponents.DotNetBar.CheckBoxItem
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX
        Me.Bar1 = New DevComponents.DotNetBar.Bar
        Me.BtnFiltrar = New DevComponents.DotNetBar.ButtonItem
        Me.BtnActualizar = New DevComponents.DotNetBar.ButtonItem
        Me.ChkVerAceptados = New DevComponents.DotNetBar.CheckBoxItem
        Me.ChkVerPendientesFechasPasadas = New DevComponents.DotNetBar.CheckBoxItem
        Me.Btn_Crear_Negocio = New DevComponents.DotNetBar.ButtonItem
        Me.Btn_Mantencion_Usuarios = New DevComponents.DotNetBar.ButtonItem
        Me.Btn_Exportar_Excel = New DevComponents.DotNetBar.ButtonItem
        Me.Btn_Mantencion_De_Usuarios = New DevComponents.DotNetBar.ButtonItem
        Me.Progreso_Monitoreo = New DevComponents.DotNetBar.CircularProgressItem
        Me.BtnMinimizar = New DevComponents.DotNetBar.ButtonItem
        Me.Btn_Cerrar = New DevComponents.DotNetBar.ButtonItem
        Me.Switch_ = New DevComponents.DotNetBar.Controls.SwitchButton
        Me.GroupPanel2 = New DevComponents.DotNetBar.Controls.GroupPanel
        Me.Grilla_Inf = New DevComponents.DotNetBar.Controls.DataGridViewX
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX
        Me.LblSolicitante = New DevComponents.DotNetBar.LabelX
        Me.Progeso_Gestion = New DevComponents.DotNetBar.ProgressSteps
        Me.St_00 = New DevComponents.DotNetBar.StepItem
        Me.St_01 = New DevComponents.DotNetBar.StepItem
        Me.St_02 = New DevComponents.DotNetBar.StepItem
        Me.St_03 = New DevComponents.DotNetBar.StepItem
        Me.St_04 = New DevComponents.DotNetBar.StepItem
        Me.MetroStatusBar1 = New DevComponents.DotNetBar.Metro.MetroStatusBar
        Me.LblBarraEstado = New DevComponents.DotNetBar.LabelItem
        Me.Tiempo_Act_Informe = New System.Windows.Forms.Timer(Me.components)
        Me.Imagenes_listado_20x20 = New System.Windows.Forms.ImageList(Me.components)
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.St_Extra = New DevComponents.DotNetBar.StepItem
        Me.ExpandablePanel1.SuspendLayout()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel2.SuspendLayout()
        CType(Me.Grilla_Inf, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LblEspera
        '
        Me.LblEspera.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        '
        '
        '
        Me.LblEspera.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LblEspera.ForeColor = System.Drawing.Color.Black
        Me.LblEspera.Location = New System.Drawing.Point(639, 43)
        Me.LblEspera.Name = "LblEspera"
        Me.LblEspera.Size = New System.Drawing.Size(198, 23)
        Me.LblEspera.TabIndex = 24
        Me.LblEspera.Text = "Cargando registros, por favor espere..."
        '
        'Barra_progreso
        '
        Me.Barra_progreso.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        '
        '
        '
        Me.Barra_progreso.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Barra_progreso.ForeColor = System.Drawing.Color.Black
        Me.Barra_progreso.Location = New System.Drawing.Point(843, 43)
        Me.Barra_progreso.Name = "Barra_progreso"
        Me.Barra_progreso.Size = New System.Drawing.Size(233, 23)
        Me.Barra_progreso.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Barra_progreso.TabIndex = 23
        Me.Barra_progreso.Text = "ProgressBarX1"
        Me.Barra_progreso.TextVisible = True
        '
        'LblSegundosF
        '
        Me.LblSegundosF.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        '
        '
        '
        Me.LblSegundosF.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LblSegundosF.ForeColor = System.Drawing.Color.Black
        Me.LblSegundosF.Location = New System.Drawing.Point(318, 48)
        Me.LblSegundosF.Name = "LblSegundosF"
        Me.LblSegundosF.Size = New System.Drawing.Size(44, 23)
        Me.LblSegundosF.TabIndex = 21
        Me.LblSegundosF.Text = "."
        '
        'Cmb_MinutosActualizacion
        '
        Me.Cmb_MinutosActualizacion.DisplayMember = "Text"
        Me.Cmb_MinutosActualizacion.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.Cmb_MinutosActualizacion.ForeColor = System.Drawing.Color.Black
        Me.Cmb_MinutosActualizacion.FormattingEnabled = True
        Me.Cmb_MinutosActualizacion.ItemHeight = 16
        Me.Cmb_MinutosActualizacion.Location = New System.Drawing.Point(127, 47)
        Me.Cmb_MinutosActualizacion.Name = "Cmb_MinutosActualizacion"
        Me.Cmb_MinutosActualizacion.Size = New System.Drawing.Size(96, 22)
        Me.Cmb_MinutosActualizacion.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Cmb_MinutosActualizacion.TabIndex = 19
        '
        'ExpandablePanel1
        '
        Me.ExpandablePanel1.CanvasColor = System.Drawing.SystemColors.Control
        Me.ExpandablePanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ExpandablePanel1.Controls.Add(Me.ItemPanel1)
        Me.ExpandablePanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.ExpandablePanel1.Expanded = False
        Me.ExpandablePanel1.ExpandedBounds = New System.Drawing.Rectangle(368, 43, 236, 179)
        Me.ExpandablePanel1.HideControlsWhenCollapsed = True
        Me.ExpandablePanel1.Location = New System.Drawing.Point(368, 43)
        Me.ExpandablePanel1.Name = "ExpandablePanel1"
        Me.ExpandablePanel1.Size = New System.Drawing.Size(236, 26)
        Me.ExpandablePanel1.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.ExpandablePanel1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.ExpandablePanel1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.ExpandablePanel1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.ExpandablePanel1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.ExpandablePanel1.Style.GradientAngle = 90
        Me.ExpandablePanel1.TabIndex = 22
        Me.ExpandablePanel1.TitleStyle.Alignment = System.Drawing.StringAlignment.Center
        Me.ExpandablePanel1.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.ExpandablePanel1.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner
        Me.ExpandablePanel1.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.ExpandablePanel1.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.ExpandablePanel1.TitleStyle.GradientAngle = 90
        Me.ExpandablePanel1.TitleText = "<b>Filtro para ver documentos en lista</b>"
        Me.ExpandablePanel1.Visible = False
        '
        'ItemPanel1
        '
        Me.ItemPanel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
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
        Me.ItemPanel1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Chk_StandBy, Me.Chk_Ingresado, Me.Chk_En_Procesado, Me.Chk_Completado, Me.Chk_Cerrado, Me.Chk_Nulas})
        Me.ItemPanel1.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
        Me.ItemPanel1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.ItemPanel1.Location = New System.Drawing.Point(3, 34)
        Me.ItemPanel1.Name = "ItemPanel1"
        Me.ItemPanel1.Size = New System.Drawing.Size(230, 138)
        Me.ItemPanel1.TabIndex = 3
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
        'Chk_Cerrado
        '
        Me.Chk_Cerrado.Checked = True
        Me.Chk_Cerrado.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Chk_Cerrado.Name = "Chk_Cerrado"
        Me.Chk_Cerrado.Text = "CERRADOS"
        '
        'Chk_Nulas
        '
        Me.Chk_Nulas.Checked = True
        Me.Chk_Nulas.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Chk_Nulas.Name = "Chk_Nulas"
        Me.Chk_Nulas.Text = "NULAS"
        '
        'LabelX4
        '
        Me.LabelX4.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.ForeColor = System.Drawing.Color.Black
        Me.LabelX4.Location = New System.Drawing.Point(6, 46)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(129, 23)
        Me.LabelX4.TabIndex = 18
        Me.LabelX4.Text = "Actualizar listado cada :"
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.BtnFiltrar, Me.BtnActualizar, Me.ChkVerAceptados, Me.ChkVerPendientesFechasPasadas, Me.Btn_Crear_Negocio, Me.Btn_Mantencion_Usuarios, Me.Btn_Exportar_Excel, Me.Btn_Mantencion_De_Usuarios, Me.Progreso_Monitoreo, Me.BtnMinimizar, Me.Btn_Cerrar})
        Me.Bar1.Location = New System.Drawing.Point(0, 0)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(1084, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 17
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'BtnFiltrar
        '
        Me.BtnFiltrar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnFiltrar.Image = CType(resources.GetObject("BtnFiltrar.Image"), System.Drawing.Image)
        Me.BtnFiltrar.Name = "BtnFiltrar"
        Me.BtnFiltrar.Text = "Buscar Negocios"
        '
        'BtnActualizar
        '
        Me.BtnActualizar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnActualizar.Image = CType(resources.GetObject("BtnActualizar.Image"), System.Drawing.Image)
        Me.BtnActualizar.Name = "BtnActualizar"
        Me.BtnActualizar.Tooltip = "Actualizar información"
        '
        'ChkVerAceptados
        '
        Me.ChkVerAceptados.Name = "ChkVerAceptados"
        Me.ChkVerAceptados.Text = "Ver solo pendientes     "
        Me.ChkVerAceptados.Visible = False
        '
        'ChkVerPendientesFechasPasadas
        '
        Me.ChkVerPendientesFechasPasadas.Checked = True
        Me.ChkVerPendientesFechasPasadas.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkVerPendientesFechasPasadas.Name = "ChkVerPendientesFechasPasadas"
        Me.ChkVerPendientesFechasPasadas.Text = "Ver pendientes de fechas pasadas  "
        Me.ChkVerPendientesFechasPasadas.Visible = False
        '
        'Btn_Crear_Negocio
        '
        Me.Btn_Crear_Negocio.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Crear_Negocio.FontBold = True
        Me.Btn_Crear_Negocio.Image = CType(resources.GetObject("Btn_Crear_Negocio.Image"), System.Drawing.Image)
        Me.Btn_Crear_Negocio.Name = "Btn_Crear_Negocio"
        Me.Btn_Crear_Negocio.Text = "CREAR NUEVO NEGOCIO <b><font color=""#17365D"">(SCN)</font></b>" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'Btn_Mantencion_Usuarios
        '
        Me.Btn_Mantencion_Usuarios.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Mantencion_Usuarios.FontBold = True
        Me.Btn_Mantencion_Usuarios.Image = CType(resources.GetObject("Btn_Mantencion_Usuarios.Image"), System.Drawing.Image)
        Me.Btn_Mantencion_Usuarios.Name = "Btn_Mantencion_Usuarios"
        Me.Btn_Mantencion_Usuarios.Tooltip = "Mantención de usuarios"
        '
        'Btn_Exportar_Excel
        '
        Me.Btn_Exportar_Excel.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Exportar_Excel.FontBold = True
        Me.Btn_Exportar_Excel.Image = CType(resources.GetObject("Btn_Exportar_Excel.Image"), System.Drawing.Image)
        Me.Btn_Exportar_Excel.Name = "Btn_Exportar_Excel"
        Me.Btn_Exportar_Excel.Tooltip = "Exportar a Excel"
        '
        'Btn_Mantencion_De_Usuarios
        '
        Me.Btn_Mantencion_De_Usuarios.Image = CType(resources.GetObject("Btn_Mantencion_De_Usuarios.Image"), System.Drawing.Image)
        Me.Btn_Mantencion_De_Usuarios.Name = "Btn_Mantencion_De_Usuarios"
        Me.Btn_Mantencion_De_Usuarios.Tooltip = "Mantención de entidades"
        '
        'Progreso_Monitoreo
        '
        Me.Progreso_Monitoreo.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.Progreso_Monitoreo.Name = "Progreso_Monitoreo"
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
        Me.Btn_Cerrar.Tooltip = "Cerrar"
        Me.Btn_Cerrar.Visible = False
        '
        'Switch_
        '
        Me.Switch_.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        '
        '
        '
        Me.Switch_.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Switch_.ForeColor = System.Drawing.Color.Black
        Me.Switch_.Location = New System.Drawing.Point(229, 47)
        Me.Switch_.Name = "Switch_"
        Me.Switch_.Size = New System.Drawing.Size(66, 22)
        Me.Switch_.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Switch_.TabIndex = 20
        '
        'GroupPanel2
        '
        Me.GroupPanel2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupPanel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GroupPanel2.CanvasColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GroupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel2.Controls.Add(Me.Grilla_Inf)
        Me.GroupPanel2.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel2.Location = New System.Drawing.Point(6, 77)
        Me.GroupPanel2.Name = "GroupPanel2"
        Me.GroupPanel2.Size = New System.Drawing.Size(1078, 332)
        '
        '
        '
        Me.GroupPanel2.Style.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GroupPanel2.Style.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GroupPanel2.Style.BackColorGradientAngle = 90
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
        Me.GroupPanel2.TabIndex = 25
        Me.GroupPanel2.Text = "Detalle"
        '
        'Grilla_Inf
        '
        Me.Grilla_Inf.AllowUserToAddRows = False
        Me.Grilla_Inf.AllowUserToDeleteRows = False
        Me.Grilla_Inf.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla_Inf.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.Grilla_Inf.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Grilla_Inf.DefaultCellStyle = DataGridViewCellStyle2
        Me.Grilla_Inf.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grilla_Inf.EnableHeadersVisualStyles = False
        Me.Grilla_Inf.GridColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.Grilla_Inf.Location = New System.Drawing.Point(0, 0)
        Me.Grilla_Inf.MultiSelect = False
        Me.Grilla_Inf.Name = "Grilla_Inf"
        Me.Grilla_Inf.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla_Inf.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.Grilla_Inf.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.Grilla_Inf.Size = New System.Drawing.Size(1072, 309)
        Me.Grilla_Inf.TabIndex = 0
        '
        'LabelX5
        '
        Me.LabelX5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LabelX5.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        '
        '
        '
        Me.LabelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX5.ForeColor = System.Drawing.Color.Black
        Me.LabelX5.Location = New System.Drawing.Point(6, 454)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.Size = New System.Drawing.Size(500, 23)
        Me.LabelX5.TabIndex = 29
        Me.LabelX5.Text = "<font color=""#4E5D30""><b><font color=""#22B14C""><font color=""#0072BC"">WORKFLOW</fo" & _
            "nt></font></b></font> (Flujo de trabajo)"
        '
        'LblSolicitante
        '
        Me.LblSolicitante.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LblSolicitante.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        '
        '
        '
        Me.LblSolicitante.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LblSolicitante.ForeColor = System.Drawing.Color.Black
        Me.LblSolicitante.Location = New System.Drawing.Point(6, 415)
        Me.LblSolicitante.Name = "LblSolicitante"
        Me.LblSolicitante.Size = New System.Drawing.Size(500, 23)
        Me.LblSolicitante.TabIndex = 28
        Me.LblSolicitante.Text = "Solicitador por:"
        Me.LblSolicitante.Visible = False
        '
        'Progeso_Gestion
        '
        Me.Progeso_Gestion.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Progeso_Gestion.AutoSize = True
        Me.Progeso_Gestion.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        '
        '
        '
        Me.Progeso_Gestion.BackgroundStyle.Class = "ProgressSteps"
        Me.Progeso_Gestion.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Progeso_Gestion.ContainerControlProcessDialogKey = True
        Me.Progeso_Gestion.ForeColor = System.Drawing.Color.Black
        Me.Progeso_Gestion.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.St_00, Me.St_01, Me.St_02, Me.St_03, Me.St_04, Me.St_Extra})
        Me.Progeso_Gestion.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.Progeso_Gestion.Location = New System.Drawing.Point(6, 479)
        Me.Progeso_Gestion.Name = "Progeso_Gestion"
        Me.Progeso_Gestion.Size = New System.Drawing.Size(921, 53)
        Me.Progeso_Gestion.TabIndex = 27
        '
        'St_00
        '
        Me.St_00.HotTracking = False
        Me.St_00.MinimumSize = New System.Drawing.Size(100, 0)
        Me.St_00.Name = "St_00"
        Me.St_00.SymbolSize = 13.0!
        Me.St_00.Text = "<font size=""+2""><b>Solicitud de negocio</b></font><br/><font size=""-1"">Espera<br/" & _
            ">1ra etapa</font>"
        Me.St_00.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Center
        '
        'St_01
        '
        Me.St_01.HotTracking = False
        Me.St_01.MinimumSize = New System.Drawing.Size(100, 0)
        Me.St_01.Name = "St_01"
        Me.St_01.SymbolSize = 13.0!
        Me.St_01.Text = "<font size=""+2""><b>Gerencia G.G.  </b></font><br/><font size=""-1"">Espera<br/>2da " & _
            "etapa</font>"
        Me.St_01.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Center
        '
        'St_02
        '
        Me.St_02.HotTracking = False
        Me.St_02.MinimumSize = New System.Drawing.Size(100, 0)
        Me.St_02.Name = "St_02"
        Me.St_02.SymbolSize = 13.0!
        Me.St_02.Text = "<font size=""+2""><b>Gerencia G.A.F.</b></font><br/><font size=""-1"">Espera<br/>2da " & _
            "etapa</font>"
        Me.St_02.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Center
        '
        'St_03
        '
        Me.St_03.HotTracking = False
        Me.St_03.Name = "St_03"
        Me.St_03.SymbolSize = 13.0!
        Me.St_03.Text = "<font size=""+2""><b>Gerencia G.C.C.</b></font><br/><font size=""-1"">Espera<br/>2da " & _
            "etapa</font>"
        '
        'St_04
        '
        Me.St_04.HotTracking = False
        Me.St_04.Name = "St_04"
        Me.St_04.SymbolSize = 13.0!
        Me.St_04.Text = "<font size=""+2""><b>RESOLUCION</b></font><br/><font size=""-1"">Espera<br/>5ta etapa" & _
            "</font>"
        Me.St_04.Visible = False
        '
        'MetroStatusBar1
        '
        Me.MetroStatusBar1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        '
        '
        '
        Me.MetroStatusBar1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.MetroStatusBar1.ContainerControlProcessDialogKey = True
        Me.MetroStatusBar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.MetroStatusBar1.DragDropSupport = True
        Me.MetroStatusBar1.Font = New System.Drawing.Font("Segoe UI", 10.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MetroStatusBar1.ForeColor = System.Drawing.Color.Black
        Me.MetroStatusBar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LblBarraEstado})
        Me.MetroStatusBar1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.MetroStatusBar1.Location = New System.Drawing.Point(0, 538)
        Me.MetroStatusBar1.Name = "MetroStatusBar1"
        Me.MetroStatusBar1.Size = New System.Drawing.Size(1084, 22)
        Me.MetroStatusBar1.TabIndex = 26
        Me.MetroStatusBar1.Text = "MetroStatusBar1"
        '
        'LblBarraEstado
        '
        Me.LblBarraEstado.Name = "LblBarraEstado"
        Me.LblBarraEstado.Text = "LabelItem1"
        '
        'Tiempo_Act_Informe
        '
        Me.Tiempo_Act_Informe.Interval = 1000
        '
        'Imagenes_listado_20x20
        '
        Me.Imagenes_listado_20x20.ImageStream = CType(resources.GetObject("Imagenes_listado_20x20.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.Imagenes_listado_20x20.TransparentColor = System.Drawing.Color.Transparent
        Me.Imagenes_listado_20x20.Images.SetKeyName(0, "cloud.png")
        Me.Imagenes_listado_20x20.Images.SetKeyName(1, "document_text-new.png")
        Me.Imagenes_listado_20x20.Images.SetKeyName(2, "document_text-info.png")
        Me.Imagenes_listado_20x20.Images.SetKeyName(3, "document_text-user.png")
        Me.Imagenes_listado_20x20.Images.SetKeyName(4, "document_text-ok.png")
        Me.Imagenes_listado_20x20.Images.SetKeyName(5, "document_text-remove2.png")
        Me.Imagenes_listado_20x20.Images.SetKeyName(6, "document_text-warn.png")
        Me.Imagenes_listado_20x20.Images.SetKeyName(7, "document_text-delete2.png")
        '
        'NotifyIcon1
        '
        Me.NotifyIcon1.BalloonTipText = "T2"
        Me.NotifyIcon1.BalloonTipTitle = "T1"
        Me.NotifyIcon1.Icon = CType(resources.GetObject("NotifyIcon1.Icon"), System.Drawing.Icon)
        Me.NotifyIcon1.Text = "Sistema de negocios"
        '
        'St_Extra
        '
        Me.St_Extra.HotTracking = False
        Me.St_Extra.Name = "St_Extra"
        Me.St_Extra.SymbolSize = 13.0!
        Me.St_Extra.Text = "<font size=""+2""><b>Autorización Extraordinaria</b></font><br/><font size=""-1"">Esp" & _
            "era<br/>2da etapa</font>"
        '
        'Frm_SolCredito_Listado
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1084, 560)
        Me.ControlBox = False
        Me.Controls.Add(Me.ExpandablePanel1)
        Me.Controls.Add(Me.LabelX5)
        Me.Controls.Add(Me.LblSolicitante)
        Me.Controls.Add(Me.Progeso_Gestion)
        Me.Controls.Add(Me.MetroStatusBar1)
        Me.Controls.Add(Me.GroupPanel2)
        Me.Controls.Add(Me.LblEspera)
        Me.Controls.Add(Me.Barra_progreso)
        Me.Controls.Add(Me.LblSegundosF)
        Me.Controls.Add(Me.Cmb_MinutosActualizacion)
        Me.Controls.Add(Me.LabelX4)
        Me.Controls.Add(Me.Bar1)
        Me.Controls.Add(Me.Switch_)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "Frm_SolCredito_Listado"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "LISTA DE CREDITOS Y NEGOCIOS"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ExpandablePanel1.ResumeLayout(False)
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel2.ResumeLayout(False)
        CType(Me.Grilla_Inf, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LblEspera As DevComponents.DotNetBar.LabelX
    Friend WithEvents Barra_progreso As DevComponents.DotNetBar.Controls.ProgressBarX
    Friend WithEvents LblSegundosF As DevComponents.DotNetBar.LabelX
    Friend WithEvents Cmb_MinutosActualizacion As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents ExpandablePanel1 As DevComponents.DotNetBar.ExpandablePanel
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents BtnFiltrar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents BtnActualizar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ChkVerAceptados As DevComponents.DotNetBar.CheckBoxItem
    Friend WithEvents ChkVerPendientesFechasPasadas As DevComponents.DotNetBar.CheckBoxItem
    Public WithEvents Btn_Crear_Negocio As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Progreso_Monitoreo As DevComponents.DotNetBar.CircularProgressItem
    Friend WithEvents Switch_ As DevComponents.DotNetBar.Controls.SwitchButton
    Friend WithEvents GroupPanel2 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Grilla_Inf As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LblSolicitante As DevComponents.DotNetBar.LabelX
    Private WithEvents Progeso_Gestion As DevComponents.DotNetBar.ProgressSteps
    Private WithEvents St_00 As DevComponents.DotNetBar.StepItem
    Private WithEvents St_01 As DevComponents.DotNetBar.StepItem
    Private WithEvents St_02 As DevComponents.DotNetBar.StepItem
    Private WithEvents St_03 As DevComponents.DotNetBar.StepItem
    Private WithEvents St_04 As DevComponents.DotNetBar.StepItem
    Friend WithEvents MetroStatusBar1 As DevComponents.DotNetBar.Metro.MetroStatusBar
    Friend WithEvents LblBarraEstado As DevComponents.DotNetBar.LabelItem
    Friend WithEvents Tiempo_Act_Informe As System.Windows.Forms.Timer
    Friend WithEvents ItemPanel1 As DevComponents.DotNetBar.ItemPanel
    Public WithEvents Chk_StandBy As DevComponents.DotNetBar.CheckBoxItem
    Public WithEvents Chk_Ingresado As DevComponents.DotNetBar.CheckBoxItem
    Public WithEvents Chk_En_Procesado As DevComponents.DotNetBar.CheckBoxItem
    Public WithEvents Chk_Completado As DevComponents.DotNetBar.CheckBoxItem
    Public WithEvents Chk_Cerrado As DevComponents.DotNetBar.CheckBoxItem
    Public WithEvents Chk_Nulas As DevComponents.DotNetBar.CheckBoxItem
    Friend WithEvents Imagenes_listado_20x20 As System.Windows.Forms.ImageList
    Public WithEvents Btn_Mantencion_Usuarios As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents BtnMinimizar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Cerrar As DevComponents.DotNetBar.ButtonItem
    Public WithEvents NotifyIcon1 As System.Windows.Forms.NotifyIcon
    Public WithEvents Btn_Exportar_Excel As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Mantencion_De_Usuarios As DevComponents.DotNetBar.ButtonItem
    Private WithEvents St_Extra As DevComponents.DotNetBar.StepItem
End Class
