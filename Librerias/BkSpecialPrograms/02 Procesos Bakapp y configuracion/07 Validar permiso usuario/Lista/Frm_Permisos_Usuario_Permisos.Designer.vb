<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Permisos_Usuario_Permisos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Permisos_Usuario_Permisos))
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Grupo_Permisos = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.ContextMenuBar1 = New DevComponents.DotNetBar.ContextMenuBar()
        Me.Menu_Contextual_Permisos = New DevComponents.DotNetBar.ButtonItem()
        Me.LabelItem3 = New DevComponents.DotNetBar.LabelItem()
        Me.Btn_Asignar_Permiso_A_Otro_Usuario = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Ver_Usuario_Con_Este_Permiso = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Porc_Dscto = New DevComponents.DotNetBar.ButtonItem()
        Me.Grilla_Permisos = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.Bar2 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Grabar_Permisos = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Duplicar_Permisos_Usuario_A_Otro = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Exportar_Excel_Permisos_Usuario = New DevComponents.DotNetBar.ButtonItem()
        Me.ChkSeleccionar = New DevComponents.DotNetBar.CheckBoxItem()
        Me.Btn_Ver_Permisos_Seleccionados = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Mis_Jefes = New DevComponents.DotNetBar.ButtonItem()
        Me.Chk_Es_Supervisor = New DevComponents.DotNetBar.CheckBoxItem()
        Me.CheckBoxItem2 = New DevComponents.DotNetBar.CheckBoxItem()
        Me.Btn_Actualizar_Lista_Permisos = New DevComponents.DotNetBar.ButtonItem()
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_Descripcion = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.MetroStatusBar1 = New DevComponents.DotNetBar.Metro.MetroStatusBar()
        Me.Lbl_Status = New DevComponents.DotNetBar.LabelItem()
        Me.GroupPanel2 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Grilla_Familias = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.Grupo_Permisos.SuspendLayout()
        CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Grilla_Permisos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel1.SuspendLayout()
        Me.GroupPanel2.SuspendLayout()
        CType(Me.Grilla_Familias, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Grupo_Permisos
        '
        Me.Grupo_Permisos.BackColor = System.Drawing.Color.White
        Me.Grupo_Permisos.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Grupo_Permisos.Controls.Add(Me.ContextMenuBar1)
        Me.Grupo_Permisos.Controls.Add(Me.Grilla_Permisos)
        Me.Grupo_Permisos.DisabledBackColor = System.Drawing.Color.Empty
        Me.Grupo_Permisos.Location = New System.Drawing.Point(310, 66)
        Me.Grupo_Permisos.Name = "Grupo_Permisos"
        Me.Grupo_Permisos.Size = New System.Drawing.Size(845, 453)
        '
        '
        '
        Me.Grupo_Permisos.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Grupo_Permisos.Style.BackColorGradientAngle = 90
        Me.Grupo_Permisos.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Grupo_Permisos.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Permisos.Style.BorderBottomWidth = 1
        Me.Grupo_Permisos.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.Grupo_Permisos.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Permisos.Style.BorderLeftWidth = 1
        Me.Grupo_Permisos.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Permisos.Style.BorderRightWidth = 1
        Me.Grupo_Permisos.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Permisos.Style.BorderTopWidth = 1
        Me.Grupo_Permisos.Style.CornerDiameter = 4
        Me.Grupo_Permisos.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Grupo_Permisos.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.Grupo_Permisos.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.Grupo_Permisos.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.Grupo_Permisos.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.Grupo_Permisos.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Grupo_Permisos.TabIndex = 15
        Me.Grupo_Permisos.Text = "Permisos.."
        '
        'ContextMenuBar1
        '
        Me.ContextMenuBar1.AntiAlias = True
        Me.ContextMenuBar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ContextMenuBar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Menu_Contextual_Permisos})
        Me.ContextMenuBar1.Location = New System.Drawing.Point(156, 58)
        Me.ContextMenuBar1.Name = "ContextMenuBar1"
        Me.ContextMenuBar1.Size = New System.Drawing.Size(306, 25)
        Me.ContextMenuBar1.Stretch = True
        Me.ContextMenuBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ContextMenuBar1.TabIndex = 47
        Me.ContextMenuBar1.TabStop = False
        Me.ContextMenuBar1.Text = "ContextMenuBar1"
        '
        'Menu_Contextual_Permisos
        '
        Me.Menu_Contextual_Permisos.AutoExpandOnClick = True
        Me.Menu_Contextual_Permisos.Name = "Menu_Contextual_Permisos"
        Me.Menu_Contextual_Permisos.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItem3, Me.Btn_Asignar_Permiso_A_Otro_Usuario, Me.Btn_Ver_Usuario_Con_Este_Permiso, Me.Btn_Porc_Dscto})
        Me.Menu_Contextual_Permisos.Text = "Opciones productos"
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
        Me.LabelItem3.Text = "Opciones del producto"
        '
        'Btn_Asignar_Permiso_A_Otro_Usuario
        '
        Me.Btn_Asignar_Permiso_A_Otro_Usuario.Image = CType(resources.GetObject("Btn_Asignar_Permiso_A_Otro_Usuario.Image"), System.Drawing.Image)
        Me.Btn_Asignar_Permiso_A_Otro_Usuario.Name = "Btn_Asignar_Permiso_A_Otro_Usuario"
        Me.Btn_Asignar_Permiso_A_Otro_Usuario.Text = "Asignar este permiso a otros usuarios"
        '
        'Btn_Ver_Usuario_Con_Este_Permiso
        '
        Me.Btn_Ver_Usuario_Con_Este_Permiso.Image = CType(resources.GetObject("Btn_Ver_Usuario_Con_Este_Permiso.Image"), System.Drawing.Image)
        Me.Btn_Ver_Usuario_Con_Este_Permiso.Name = "Btn_Ver_Usuario_Con_Este_Permiso"
        Me.Btn_Ver_Usuario_Con_Este_Permiso.Text = "Ver usuarios que tienen este permiso"
        '
        'Btn_Porc_Dscto
        '
        Me.Btn_Porc_Dscto.Image = CType(resources.GetObject("Btn_Porc_Dscto.Image"), System.Drawing.Image)
        Me.Btn_Porc_Dscto.Name = "Btn_Porc_Dscto"
        Me.Btn_Porc_Dscto.Text = "Descuento permitido"
        '
        'Grilla_Permisos
        '
        Me.Grilla_Permisos.AllowUserToAddRows = False
        Me.Grilla_Permisos.AllowUserToDeleteRows = False
        Me.Grilla_Permisos.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla_Permisos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.Grilla_Permisos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle10.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Grilla_Permisos.DefaultCellStyle = DataGridViewCellStyle10
        Me.Grilla_Permisos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grilla_Permisos.EnableHeadersVisualStyles = False
        Me.Grilla_Permisos.GridColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.Grilla_Permisos.Location = New System.Drawing.Point(0, 0)
        Me.Grilla_Permisos.Name = "Grilla_Permisos"
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle11.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla_Permisos.RowHeadersDefaultCellStyle = DataGridViewCellStyle11
        Me.Grilla_Permisos.RowHeadersVisible = False
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.Black
        Me.Grilla_Permisos.RowsDefaultCellStyle = DataGridViewCellStyle12
        Me.Grilla_Permisos.RowTemplate.Height = 25
        Me.Grilla_Permisos.Size = New System.Drawing.Size(839, 430)
        Me.Grilla_Permisos.TabIndex = 21
        '
        'Bar2
        '
        Me.Bar2.AntiAlias = True
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Grabar_Permisos, Me.Btn_Duplicar_Permisos_Usuario_A_Otro, Me.Btn_Exportar_Excel_Permisos_Usuario, Me.ChkSeleccionar, Me.Btn_Ver_Permisos_Seleccionados, Me.Btn_Mis_Jefes, Me.Chk_Es_Supervisor, Me.CheckBoxItem2, Me.Btn_Actualizar_Lista_Permisos})
        Me.Bar2.Location = New System.Drawing.Point(0, 525)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(1167, 41)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Bar2.TabIndex = 16
        Me.Bar2.TabStop = False
        Me.Bar2.Text = "Bar2"
        '
        'Btn_Grabar_Permisos
        '
        Me.Btn_Grabar_Permisos.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Grabar_Permisos.ForeColor = System.Drawing.Color.Black
        Me.Btn_Grabar_Permisos.Image = CType(resources.GetObject("Btn_Grabar_Permisos.Image"), System.Drawing.Image)
        Me.Btn_Grabar_Permisos.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.Btn_Grabar_Permisos.Name = "Btn_Grabar_Permisos"
        Me.Btn_Grabar_Permisos.Tooltip = "Grabar permisos"
        '
        'Btn_Duplicar_Permisos_Usuario_A_Otro
        '
        Me.Btn_Duplicar_Permisos_Usuario_A_Otro.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Duplicar_Permisos_Usuario_A_Otro.ForeColor = System.Drawing.Color.Black
        Me.Btn_Duplicar_Permisos_Usuario_A_Otro.Image = CType(resources.GetObject("Btn_Duplicar_Permisos_Usuario_A_Otro.Image"), System.Drawing.Image)
        Me.Btn_Duplicar_Permisos_Usuario_A_Otro.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.Btn_Duplicar_Permisos_Usuario_A_Otro.Name = "Btn_Duplicar_Permisos_Usuario_A_Otro"
        Me.Btn_Duplicar_Permisos_Usuario_A_Otro.Tooltip = "Duplicar los permisos de este usuario a otros"
        '
        'Btn_Exportar_Excel_Permisos_Usuario
        '
        Me.Btn_Exportar_Excel_Permisos_Usuario.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Exportar_Excel_Permisos_Usuario.ForeColor = System.Drawing.Color.Black
        Me.Btn_Exportar_Excel_Permisos_Usuario.Image = CType(resources.GetObject("Btn_Exportar_Excel_Permisos_Usuario.Image"), System.Drawing.Image)
        Me.Btn_Exportar_Excel_Permisos_Usuario.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.Btn_Exportar_Excel_Permisos_Usuario.Name = "Btn_Exportar_Excel_Permisos_Usuario"
        Me.Btn_Exportar_Excel_Permisos_Usuario.Tooltip = "Exportar a Excel permisos del usuario activo"
        '
        'ChkSeleccionar
        '
        Me.ChkSeleccionar.Name = "ChkSeleccionar"
        Me.ChkSeleccionar.Text = "Seleccionar todo"
        '
        'Btn_Ver_Permisos_Seleccionados
        '
        Me.Btn_Ver_Permisos_Seleccionados.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Ver_Permisos_Seleccionados.ForeColor = System.Drawing.Color.Black
        Me.Btn_Ver_Permisos_Seleccionados.Image = CType(resources.GetObject("Btn_Ver_Permisos_Seleccionados.Image"), System.Drawing.Image)
        Me.Btn_Ver_Permisos_Seleccionados.Name = "Btn_Ver_Permisos_Seleccionados"
        Me.Btn_Ver_Permisos_Seleccionados.Tooltip = "Ver solo permisos seleccionados"
        '
        'Btn_Mis_Jefes
        '
        Me.Btn_Mis_Jefes.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Mis_Jefes.ForeColor = System.Drawing.Color.Black
        Me.Btn_Mis_Jefes.Image = CType(resources.GetObject("Btn_Mis_Jefes.Image"), System.Drawing.Image)
        Me.Btn_Mis_Jefes.Name = "Btn_Mis_Jefes"
        Me.Btn_Mis_Jefes.Tooltip = "Mis Jefes (Permisos de OCC)"
        '
        'Chk_Es_Supervisor
        '
        Me.Chk_Es_Supervisor.Name = "Chk_Es_Supervisor"
        Me.Chk_Es_Supervisor.Text = "Es Supervisor"
        Me.Chk_Es_Supervisor.Tooltip = "Puede otorgar permisos a otros usuarios"
        '
        'CheckBoxItem2
        '
        Me.CheckBoxItem2.Name = "CheckBoxItem2"
        Me.CheckBoxItem2.Text = "Es Administrador"
        Me.CheckBoxItem2.Visible = False
        '
        'Btn_Actualizar_Lista_Permisos
        '
        Me.Btn_Actualizar_Lista_Permisos.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Actualizar_Lista_Permisos.ForeColor = System.Drawing.Color.Black
        Me.Btn_Actualizar_Lista_Permisos.Image = CType(resources.GetObject("Btn_Actualizar_Lista_Permisos.Image"), System.Drawing.Image)
        Me.Btn_Actualizar_Lista_Permisos.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.Btn_Actualizar_Lista_Permisos.Name = "Btn_Actualizar_Lista_Permisos"
        Me.Btn_Actualizar_Lista_Permisos.Tooltip = "Actualizar lista de permisos de la base de datos"
        Me.Btn_Actualizar_Lista_Permisos.Visible = False
        '
        'GroupPanel1
        '
        Me.GroupPanel1.BackColor = System.Drawing.Color.White
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.LabelX1)
        Me.GroupPanel1.Controls.Add(Me.Txt_Descripcion)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Location = New System.Drawing.Point(310, 7)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(845, 53)
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
        Me.GroupPanel1.TabIndex = 17
        Me.GroupPanel1.Text = "Búsqueda de permiso, puede buscar por código o descripción"
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.ForeColor = System.Drawing.Color.Black
        Me.LabelX1.Location = New System.Drawing.Point(3, 0)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(41, 23)
        Me.LabelX1.TabIndex = 12
        Me.LabelX1.Text = "Buscar"
        '
        'Txt_Descripcion
        '
        Me.Txt_Descripcion.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Descripcion.Border.Class = "TextBoxBorder"
        Me.Txt_Descripcion.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Descripcion.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Descripcion.FocusHighlightEnabled = True
        Me.Txt_Descripcion.ForeColor = System.Drawing.Color.Black
        Me.Txt_Descripcion.Location = New System.Drawing.Point(50, 3)
        Me.Txt_Descripcion.Name = "Txt_Descripcion"
        Me.Txt_Descripcion.PreventEnterBeep = True
        Me.Txt_Descripcion.Size = New System.Drawing.Size(786, 22)
        Me.Txt_Descripcion.TabIndex = 2
        '
        'MetroStatusBar1
        '
        Me.MetroStatusBar1.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.MetroStatusBar1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.MetroStatusBar1.ContainerControlProcessDialogKey = True
        Me.MetroStatusBar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.MetroStatusBar1.DragDropSupport = True
        Me.MetroStatusBar1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MetroStatusBar1.ForeColor = System.Drawing.Color.Black
        Me.MetroStatusBar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Lbl_Status})
        Me.MetroStatusBar1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.MetroStatusBar1.Location = New System.Drawing.Point(0, 566)
        Me.MetroStatusBar1.Name = "MetroStatusBar1"
        Me.MetroStatusBar1.Size = New System.Drawing.Size(1167, 22)
        Me.MetroStatusBar1.TabIndex = 18
        Me.MetroStatusBar1.Text = "MetroStatusBar1"
        '
        'Lbl_Status
        '
        Me.Lbl_Status.Name = "Lbl_Status"
        Me.Lbl_Status.Text = "Lbl_Status"
        '
        'GroupPanel2
        '
        Me.GroupPanel2.BackColor = System.Drawing.Color.White
        Me.GroupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel2.Controls.Add(Me.Grilla_Familias)
        Me.GroupPanel2.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel2.Location = New System.Drawing.Point(5, 7)
        Me.GroupPanel2.Name = "GroupPanel2"
        Me.GroupPanel2.Size = New System.Drawing.Size(299, 512)
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
        Me.GroupPanel2.TabIndex = 19
        Me.GroupPanel2.Text = "Grupo de permisos"
        '
        'Grilla_Familias
        '
        Me.Grilla_Familias.AllowUserToAddRows = False
        Me.Grilla_Familias.AllowUserToDeleteRows = False
        Me.Grilla_Familias.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle13.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle13.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle13.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla_Familias.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle13
        Me.Grilla_Familias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle14.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle14.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle14.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle14.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Grilla_Familias.DefaultCellStyle = DataGridViewCellStyle14
        Me.Grilla_Familias.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grilla_Familias.EnableHeadersVisualStyles = False
        Me.Grilla_Familias.GridColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.Grilla_Familias.Location = New System.Drawing.Point(0, 0)
        Me.Grilla_Familias.Name = "Grilla_Familias"
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle15.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle15.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle15.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla_Familias.RowHeadersDefaultCellStyle = DataGridViewCellStyle15
        Me.Grilla_Familias.RowHeadersVisible = False
        DataGridViewCellStyle16.SelectionForeColor = System.Drawing.Color.Black
        Me.Grilla_Familias.RowsDefaultCellStyle = DataGridViewCellStyle16
        Me.Grilla_Familias.RowTemplate.Height = 25
        Me.Grilla_Familias.Size = New System.Drawing.Size(293, 489)
        Me.Grilla_Familias.TabIndex = 22
        '
        'Frm_Permisos_Usuario_Permisos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1167, 588)
        Me.Controls.Add(Me.GroupPanel2)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Controls.Add(Me.Bar2)
        Me.Controls.Add(Me.Grupo_Permisos)
        Me.Controls.Add(Me.MetroStatusBar1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Permisos_Usuario_Permisos"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MetroForm"
        Me.Grupo_Permisos.ResumeLayout(False)
        CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Grilla_Permisos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel1.ResumeLayout(False)
        Me.GroupPanel2.ResumeLayout(False)
        CType(Me.Grilla_Familias, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Grupo_Permisos As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents Btn_Grabar_Permisos As DevComponents.DotNetBar.ButtonItem
    Public WithEvents ChkSeleccionar As DevComponents.DotNetBar.CheckBoxItem
    Friend WithEvents ContextMenuBar1 As DevComponents.DotNetBar.ContextMenuBar
    Friend WithEvents Menu_Contextual_Permisos As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelItem3 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents Btn_Asignar_Permiso_A_Otro_Usuario As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Ver_Usuario_Con_Este_Permiso As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Duplicar_Permisos_Usuario_A_Otro As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Exportar_Excel_Permisos_Usuario As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Public WithEvents Txt_Descripcion As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents MetroStatusBar1 As DevComponents.DotNetBar.Metro.MetroStatusBar
    Friend WithEvents Lbl_Status As DevComponents.DotNetBar.LabelItem
    Friend WithEvents Btn_Ver_Permisos_Seleccionados As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Actualizar_Lista_Permisos As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Porc_Dscto As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents GroupPanel2 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Btn_Mis_Jefes As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Grilla_Permisos As DevComponents.DotNetBar.Controls.DataGridViewX
    Public WithEvents Chk_Es_Supervisor As DevComponents.DotNetBar.CheckBoxItem
    Public WithEvents CheckBoxItem2 As DevComponents.DotNetBar.CheckBoxItem
    Friend WithEvents Grilla_Familias As DevComponents.DotNetBar.Controls.DataGridViewX
End Class
