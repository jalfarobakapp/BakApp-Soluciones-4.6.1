﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_ImpBarras_PorDocumento
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
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_ImpBarras_PorDocumento))
        Me.Highlighter1 = New DevComponents.DotNetBar.Validator.Highlighter()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.Btnimprimiretiquetas = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_imprimir_Archivo = New DevComponents.DotNetBar.ButtonItem()
        Me.BtnConfiguracion = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Conf_PuertoEtiqueta = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Conf_ConfEstacion = New DevComponents.DotNetBar.ButtonItem()
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.GrillaEncabezado = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.GroupPanel2 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.ContextMenuBar1 = New DevComponents.DotNetBar.ContextMenuBar()
        Me.Menu_Contextual_Permisos = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Editar = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Ver_Usuario_Con_Este_Permiso = New DevComponents.DotNetBar.ButtonItem()
        Me.Grilla = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.LblEntidadFisica = New DevComponents.DotNetBar.LabelX()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.Grupo_Puerto = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.CmbPuerto = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.GroupPanel3 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Btn_ConfPuertoXEtiquetaXEquipo = New DevComponents.DotNetBar.ButtonX()
        Me.Cmbetiquetas = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel1.SuspendLayout()
        CType(Me.GrillaEncabezado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel2.SuspendLayout()
        CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Grupo_Puerto.SuspendLayout()
        Me.GroupPanel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Highlighter1
        '
        Me.Highlighter1.ContainerControl = Me
        Me.Highlighter1.FocusHighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red
        Me.Highlighter1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btnimprimiretiquetas, Me.Btn_imprimir_Archivo, Me.BtnConfiguracion})
        Me.Bar1.Location = New System.Drawing.Point(0, 478)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(830, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2010
        Me.Bar1.TabIndex = 65
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'Btnimprimiretiquetas
        '
        Me.Btnimprimiretiquetas.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btnimprimiretiquetas.ForeColor = System.Drawing.Color.Black
        Me.Btnimprimiretiquetas.Image = CType(resources.GetObject("Btnimprimiretiquetas.Image"), System.Drawing.Image)
        Me.Btnimprimiretiquetas.ImageAlt = CType(resources.GetObject("Btnimprimiretiquetas.ImageAlt"), System.Drawing.Image)
        Me.Btnimprimiretiquetas.Name = "Btnimprimiretiquetas"
        Me.Btnimprimiretiquetas.Text = "Imprimir etiquetas"
        '
        'Btn_imprimir_Archivo
        '
        Me.Btn_imprimir_Archivo.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_imprimir_Archivo.ForeColor = System.Drawing.Color.Black
        Me.Btn_imprimir_Archivo.Image = CType(resources.GetObject("Btn_imprimir_Archivo.Image"), System.Drawing.Image)
        Me.Btn_imprimir_Archivo.ImageAlt = CType(resources.GetObject("Btn_imprimir_Archivo.ImageAlt"), System.Drawing.Image)
        Me.Btn_imprimir_Archivo.Name = "Btn_imprimir_Archivo"
        Me.Btn_imprimir_Archivo.Text = "Imprimir a un archivo"
        '
        'BtnConfiguracion
        '
        Me.BtnConfiguracion.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnConfiguracion.ForeColor = System.Drawing.Color.Black
        Me.BtnConfiguracion.Image = CType(resources.GetObject("BtnConfiguracion.Image"), System.Drawing.Image)
        Me.BtnConfiguracion.ImageAlt = CType(resources.GetObject("BtnConfiguracion.ImageAlt"), System.Drawing.Image)
        Me.BtnConfiguracion.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.BtnConfiguracion.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.BtnConfiguracion.Name = "BtnConfiguracion"
        Me.BtnConfiguracion.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Conf_PuertoEtiqueta, Me.Btn_Conf_ConfEstacion})
        Me.BtnConfiguracion.Tooltip = "Configuración de sistema"
        '
        'Btn_Conf_PuertoEtiqueta
        '
        Me.Btn_Conf_PuertoEtiqueta.Image = CType(resources.GetObject("Btn_Conf_PuertoEtiqueta.Image"), System.Drawing.Image)
        Me.Btn_Conf_PuertoEtiqueta.ImageAlt = CType(resources.GetObject("Btn_Conf_PuertoEtiqueta.ImageAlt"), System.Drawing.Image)
        Me.Btn_Conf_PuertoEtiqueta.Name = "Btn_Conf_PuertoEtiqueta"
        Me.Btn_Conf_PuertoEtiqueta.Text = "Configuración puerto y etiqueta por defecto"
        '
        'Btn_Conf_ConfEstacion
        '
        Me.Btn_Conf_ConfEstacion.Image = CType(resources.GetObject("Btn_Conf_ConfEstacion.Image"), System.Drawing.Image)
        Me.Btn_Conf_ConfEstacion.ImageAlt = CType(resources.GetObject("Btn_Conf_ConfEstacion.ImageAlt"), System.Drawing.Image)
        Me.Btn_Conf_ConfEstacion.Name = "Btn_Conf_ConfEstacion"
        Me.Btn_Conf_ConfEstacion.Text = "Configuración de estación local"
        '
        'GroupPanel1
        '
        Me.GroupPanel1.BackColor = System.Drawing.Color.White
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.GrillaEncabezado)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Location = New System.Drawing.Point(12, 12)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(806, 80)
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
        Me.GroupPanel1.TabIndex = 66
        Me.GroupPanel1.Text = "Encabezado del documento"
        '
        'GrillaEncabezado
        '
        Me.GrillaEncabezado.AllowUserToAddRows = False
        Me.GrillaEncabezado.AllowUserToDeleteRows = False
        Me.GrillaEncabezado.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GrillaEncabezado.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.GrillaEncabezado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GrillaEncabezado.DefaultCellStyle = DataGridViewCellStyle5
        Me.GrillaEncabezado.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GrillaEncabezado.EnableHeadersVisualStyles = False
        Me.GrillaEncabezado.GridColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.GrillaEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.GrillaEncabezado.Name = "GrillaEncabezado"
        Me.GrillaEncabezado.ReadOnly = True
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GrillaEncabezado.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.GrillaEncabezado.RowHeadersVisible = False
        Me.GrillaEncabezado.RowHeadersWidth = 51
        Me.GrillaEncabezado.Size = New System.Drawing.Size(800, 53)
        Me.GrillaEncabezado.TabIndex = 0
        '
        'GroupPanel2
        '
        Me.GroupPanel2.BackColor = System.Drawing.Color.White
        Me.GroupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel2.Controls.Add(Me.ContextMenuBar1)
        Me.GroupPanel2.Controls.Add(Me.Grilla)
        Me.GroupPanel2.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel2.Location = New System.Drawing.Point(12, 127)
        Me.GroupPanel2.Name = "GroupPanel2"
        Me.GroupPanel2.Size = New System.Drawing.Size(806, 284)
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
        Me.GroupPanel2.TabIndex = 67
        Me.GroupPanel2.Text = "Detalle del documento"
        '
        'ContextMenuBar1
        '
        Me.ContextMenuBar1.AntiAlias = True
        Me.ContextMenuBar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ContextMenuBar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Menu_Contextual_Permisos})
        Me.ContextMenuBar1.Location = New System.Drawing.Point(212, 110)
        Me.ContextMenuBar1.Name = "ContextMenuBar1"
        Me.ContextMenuBar1.Size = New System.Drawing.Size(306, 29)
        Me.ContextMenuBar1.Stretch = True
        Me.ContextMenuBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ContextMenuBar1.TabIndex = 57
        Me.ContextMenuBar1.TabStop = False
        Me.ContextMenuBar1.Text = "ContextMenuBar1"
        '
        'Menu_Contextual_Permisos
        '
        Me.Menu_Contextual_Permisos.AutoExpandOnClick = True
        Me.Menu_Contextual_Permisos.Name = "Menu_Contextual_Permisos"
        Me.Menu_Contextual_Permisos.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Editar, Me.Btn_Ver_Usuario_Con_Este_Permiso})
        Me.Menu_Contextual_Permisos.Text = "Opciones productos"
        '
        'Btn_Editar
        '
        Me.Btn_Editar.Image = CType(resources.GetObject("Btn_Editar.Image"), System.Drawing.Image)
        Me.Btn_Editar.ImageAlt = CType(resources.GetObject("Btn_Editar.ImageAlt"), System.Drawing.Image)
        Me.Btn_Editar.Name = "Btn_Editar"
        Me.Btn_Editar.Text = "Editar"
        '
        'Btn_Ver_Usuario_Con_Este_Permiso
        '
        Me.Btn_Ver_Usuario_Con_Este_Permiso.Image = CType(resources.GetObject("Btn_Ver_Usuario_Con_Este_Permiso.Image"), System.Drawing.Image)
        Me.Btn_Ver_Usuario_Con_Este_Permiso.ImageAlt = CType(resources.GetObject("Btn_Ver_Usuario_Con_Este_Permiso.ImageAlt"), System.Drawing.Image)
        Me.Btn_Ver_Usuario_Con_Este_Permiso.Name = "Btn_Ver_Usuario_Con_Este_Permiso"
        Me.Btn_Ver_Usuario_Con_Este_Permiso.Text = "Eliminar"
        '
        'Grilla
        '
        Me.Grilla.AllowUserToAddRows = False
        Me.Grilla.AllowUserToDeleteRows = False
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
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.Grilla.RowHeadersVisible = False
        Me.Grilla.RowHeadersWidth = 51
        Me.Grilla.Size = New System.Drawing.Size(800, 257)
        Me.Grilla.TabIndex = 1
        '
        'LblEntidadFisica
        '
        Me.LblEntidadFisica.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LblEntidadFisica.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LblEntidadFisica.ForeColor = System.Drawing.Color.Black
        Me.LblEntidadFisica.Location = New System.Drawing.Point(75, 98)
        Me.LblEntidadFisica.Name = "LblEntidadFisica"
        Me.LblEntidadFisica.Size = New System.Drawing.Size(547, 23)
        Me.LblEntidadFisica.TabIndex = 70
        Me.LblEntidadFisica.Text = "LabelX3"
        '
        'LabelX4
        '
        Me.LabelX4.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.ForeColor = System.Drawing.Color.Black
        Me.LabelX4.Location = New System.Drawing.Point(12, 98)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(75, 23)
        Me.LabelX4.TabIndex = 69
        Me.LabelX4.Text = "Ent. física:"
        '
        'Grupo_Puerto
        '
        Me.Grupo_Puerto.BackColor = System.Drawing.Color.White
        Me.Grupo_Puerto.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Grupo_Puerto.Controls.Add(Me.CmbPuerto)
        Me.Grupo_Puerto.DisabledBackColor = System.Drawing.Color.Empty
        Me.Grupo_Puerto.Location = New System.Drawing.Point(519, 414)
        Me.Grupo_Puerto.Name = "Grupo_Puerto"
        Me.Grupo_Puerto.Size = New System.Drawing.Size(157, 59)
        '
        '
        '
        Me.Grupo_Puerto.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Grupo_Puerto.Style.BackColorGradientAngle = 90
        Me.Grupo_Puerto.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Grupo_Puerto.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Puerto.Style.BorderBottomWidth = 1
        Me.Grupo_Puerto.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.Grupo_Puerto.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Puerto.Style.BorderLeftWidth = 1
        Me.Grupo_Puerto.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Puerto.Style.BorderRightWidth = 1
        Me.Grupo_Puerto.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Puerto.Style.BorderTopWidth = 1
        Me.Grupo_Puerto.Style.CornerDiameter = 4
        Me.Grupo_Puerto.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Grupo_Puerto.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.Grupo_Puerto.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.Grupo_Puerto.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.Grupo_Puerto.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.Grupo_Puerto.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Grupo_Puerto.TabIndex = 79
        Me.Grupo_Puerto.Text = "Puerto salida"
        '
        'CmbPuerto
        '
        Me.CmbPuerto.DisplayMember = "Text"
        Me.CmbPuerto.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.CmbPuerto.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbPuerto.ForeColor = System.Drawing.Color.Black
        Me.CmbPuerto.FormattingEnabled = True
        Me.CmbPuerto.ItemHeight = 19
        Me.CmbPuerto.Location = New System.Drawing.Point(1, 5)
        Me.CmbPuerto.Name = "CmbPuerto"
        Me.CmbPuerto.Size = New System.Drawing.Size(147, 25)
        Me.CmbPuerto.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.CmbPuerto.TabIndex = 0
        '
        'GroupPanel3
        '
        Me.GroupPanel3.BackColor = System.Drawing.Color.White
        Me.GroupPanel3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel3.Controls.Add(Me.Btn_ConfPuertoXEtiquetaXEquipo)
        Me.GroupPanel3.Controls.Add(Me.Cmbetiquetas)
        Me.GroupPanel3.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel3.Location = New System.Drawing.Point(12, 414)
        Me.GroupPanel3.Name = "GroupPanel3"
        Me.GroupPanel3.Size = New System.Drawing.Size(501, 59)
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
        Me.GroupPanel3.TabIndex = 80
        Me.GroupPanel3.Text = "Etiqueta"
        '
        'Btn_ConfPuertoXEtiquetaXEquipo
        '
        Me.Btn_ConfPuertoXEtiquetaXEquipo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_ConfPuertoXEtiquetaXEquipo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_ConfPuertoXEtiquetaXEquipo.Image = CType(resources.GetObject("Btn_ConfPuertoXEtiquetaXEquipo.Image"), System.Drawing.Image)
        Me.Btn_ConfPuertoXEtiquetaXEquipo.ImageAlt = CType(resources.GetObject("Btn_ConfPuertoXEtiquetaXEquipo.ImageAlt"), System.Drawing.Image)
        Me.Btn_ConfPuertoXEtiquetaXEquipo.Location = New System.Drawing.Point(466, 5)
        Me.Btn_ConfPuertoXEtiquetaXEquipo.Name = "Btn_ConfPuertoXEtiquetaXEquipo"
        Me.Btn_ConfPuertoXEtiquetaXEquipo.Size = New System.Drawing.Size(26, 25)
        Me.Btn_ConfPuertoXEtiquetaXEquipo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_ConfPuertoXEtiquetaXEquipo.TabIndex = 80
        Me.Btn_ConfPuertoXEtiquetaXEquipo.Tooltip = "Seleccionar puerto de salida según etiqueta por equipo"
        '
        'Cmbetiquetas
        '
        Me.Cmbetiquetas.DisplayMember = "Text"
        Me.Cmbetiquetas.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.Cmbetiquetas.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmbetiquetas.ForeColor = System.Drawing.Color.Black
        Me.Cmbetiquetas.FormattingEnabled = True
        Me.Cmbetiquetas.ItemHeight = 19
        Me.Cmbetiquetas.Location = New System.Drawing.Point(3, 5)
        Me.Cmbetiquetas.Name = "Cmbetiquetas"
        Me.Cmbetiquetas.Size = New System.Drawing.Size(457, 25)
        Me.Cmbetiquetas.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Cmbetiquetas.TabIndex = 74
        '
        'Frm_ImpBarras_PorDocumento
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 19.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(830, 519)
        Me.Controls.Add(Me.GroupPanel3)
        Me.Controls.Add(Me.Grupo_Puerto)
        Me.Controls.Add(Me.LblEntidadFisica)
        Me.Controls.Add(Me.LabelX4)
        Me.Controls.Add(Me.GroupPanel2)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Controls.Add(Me.Bar1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_ImpBarras_PorDocumento"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Impresión de código de barras por documento"
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel1.ResumeLayout(False)
        CType(Me.GrillaEncabezado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel2.ResumeLayout(False)
        CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Grupo_Puerto.ResumeLayout(False)
        Me.GroupPanel3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Highlighter1 As DevComponents.DotNetBar.Validator.Highlighter
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents Btnimprimiretiquetas As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents GroupPanel2 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents GrillaEncabezado As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents LblEntidadFisica As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Btn_imprimir_Archivo As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Grilla As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents ContextMenuBar1 As DevComponents.DotNetBar.ContextMenuBar
    Friend WithEvents Menu_Contextual_Permisos As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Editar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Ver_Usuario_Con_Este_Permiso As DevComponents.DotNetBar.ButtonItem
    Public WithEvents BtnConfiguracion As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Conf_PuertoEtiqueta As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Conf_ConfEstacion As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Grupo_Puerto As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents CmbPuerto As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents GroupPanel3 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Btn_ConfPuertoXEtiquetaXEquipo As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Cmbetiquetas As DevComponents.DotNetBar.Controls.ComboBoxEx
End Class
