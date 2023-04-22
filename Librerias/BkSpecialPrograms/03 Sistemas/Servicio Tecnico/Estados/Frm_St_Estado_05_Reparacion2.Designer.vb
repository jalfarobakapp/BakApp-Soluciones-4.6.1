<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_St_Estado_05_Reparacion2
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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_St_Estado_05_Reparacion2))
        Me.Grupo_Presupuesto = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Txt_Tecnico_Taller = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Txt_NroSerie = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.Grupo_Grilla = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Grilla = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.Bar2 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Fijar_Estado = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Grabar = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Editar = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Cancelar = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Agregar_Producto = New DevComponents.DotNetBar.ButtonItem()
        Me.Imagenes_16x16 = New System.Windows.Forms.ImageList(Me.components)
        Me.Chk_No_se_pudo_reparar_el_equipo = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.GroupPanel4 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Txt_Nota = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Grupo_Presupuesto.SuspendLayout()
        Me.Grupo_Grilla.SuspendLayout()
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'Grupo_Presupuesto
        '
        Me.Grupo_Presupuesto.BackColor = System.Drawing.Color.White
        Me.Grupo_Presupuesto.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Grupo_Presupuesto.Controls.Add(Me.Txt_Tecnico_Taller)
        Me.Grupo_Presupuesto.Controls.Add(Me.Txt_NroSerie)
        Me.Grupo_Presupuesto.Controls.Add(Me.LabelX1)
        Me.Grupo_Presupuesto.Controls.Add(Me.LabelX2)
        Me.Grupo_Presupuesto.DisabledBackColor = System.Drawing.Color.Empty
        Me.Grupo_Presupuesto.Location = New System.Drawing.Point(9, 1)
        Me.Grupo_Presupuesto.Name = "Grupo_Presupuesto"
        Me.Grupo_Presupuesto.Size = New System.Drawing.Size(608, 71)
        '
        '
        '
        Me.Grupo_Presupuesto.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Grupo_Presupuesto.Style.BackColorGradientAngle = 90
        Me.Grupo_Presupuesto.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Grupo_Presupuesto.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Presupuesto.Style.BorderBottomWidth = 1
        Me.Grupo_Presupuesto.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.Grupo_Presupuesto.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Presupuesto.Style.BorderLeftWidth = 1
        Me.Grupo_Presupuesto.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Presupuesto.Style.BorderRightWidth = 1
        Me.Grupo_Presupuesto.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Presupuesto.Style.BorderTopWidth = 1
        Me.Grupo_Presupuesto.Style.CornerDiameter = 4
        Me.Grupo_Presupuesto.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Grupo_Presupuesto.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.Grupo_Presupuesto.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.Grupo_Presupuesto.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.Grupo_Presupuesto.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.Grupo_Presupuesto.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Grupo_Presupuesto.TabIndex = 102
        Me.Grupo_Presupuesto.Text = "Datos del técnico y el producto a reparar"
        '
        'Txt_Tecnico_Taller
        '
        Me.Txt_Tecnico_Taller.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Tecnico_Taller.Border.Class = "TextBoxBorder"
        Me.Txt_Tecnico_Taller.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Tecnico_Taller.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_Tecnico_Taller.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Tecnico_Taller.Enabled = False
        Me.Txt_Tecnico_Taller.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Txt_Tecnico_Taller.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Tecnico_Taller.ForeColor = System.Drawing.Color.Black
        Me.Txt_Tecnico_Taller.Location = New System.Drawing.Point(51, 17)
        Me.Txt_Tecnico_Taller.MaxLength = 300
        Me.Txt_Tecnico_Taller.Name = "Txt_Tecnico_Taller"
        Me.Txt_Tecnico_Taller.ReadOnly = True
        Me.Txt_Tecnico_Taller.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.Txt_Tecnico_Taller.Size = New System.Drawing.Size(250, 22)
        Me.Txt_Tecnico_Taller.TabIndex = 0
        '
        'Txt_NroSerie
        '
        Me.Txt_NroSerie.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_NroSerie.Border.Class = "TextBoxBorder"
        Me.Txt_NroSerie.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_NroSerie.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_NroSerie.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_NroSerie.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Txt_NroSerie.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_NroSerie.ForeColor = System.Drawing.Color.Black
        Me.Txt_NroSerie.Location = New System.Drawing.Point(454, 17)
        Me.Txt_NroSerie.MaxLength = 300
        Me.Txt_NroSerie.Name = "Txt_NroSerie"
        Me.Txt_NroSerie.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.Txt_NroSerie.Size = New System.Drawing.Size(145, 22)
        Me.Txt_NroSerie.TabIndex = 1
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
        Me.LabelX1.Location = New System.Drawing.Point(346, 16)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(102, 23)
        Me.LabelX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.LabelX1.TabIndex = 69
        Me.LabelX1.Text = "Número de serie"
        '
        'LabelX2
        '
        Me.LabelX2.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX2.ForeColor = System.Drawing.Color.Black
        Me.LabelX2.Location = New System.Drawing.Point(0, 17)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(51, 23)
        Me.LabelX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.LabelX2.TabIndex = 64
        Me.LabelX2.Text = "Técnico"
        '
        'Grupo_Grilla
        '
        Me.Grupo_Grilla.BackColor = System.Drawing.Color.White
        Me.Grupo_Grilla.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Grupo_Grilla.Controls.Add(Me.Grilla)
        Me.Grupo_Grilla.DisabledBackColor = System.Drawing.Color.Empty
        Me.Grupo_Grilla.Location = New System.Drawing.Point(9, 78)
        Me.Grupo_Grilla.Name = "Grupo_Grilla"
        Me.Grupo_Grilla.Size = New System.Drawing.Size(608, 283)
        '
        '
        '
        Me.Grupo_Grilla.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Grupo_Grilla.Style.BackColorGradientAngle = 90
        Me.Grupo_Grilla.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Grupo_Grilla.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Grilla.Style.BorderBottomWidth = 1
        Me.Grupo_Grilla.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.Grupo_Grilla.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Grilla.Style.BorderLeftWidth = 1
        Me.Grupo_Grilla.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Grilla.Style.BorderRightWidth = 1
        Me.Grupo_Grilla.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Grilla.Style.BorderTopWidth = 1
        Me.Grupo_Grilla.Style.CornerDiameter = 4
        Me.Grupo_Grilla.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Grupo_Grilla.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.Grupo_Grilla.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.Grupo_Grilla.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.Grupo_Grilla.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.Grupo_Grilla.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Grupo_Grilla.TabIndex = 101
        Me.Grupo_Grilla.Text = "Servicios realizados"
        '
        'Grilla
        '
        Me.Grilla.AllowUserToAddRows = False
        Me.Grilla.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.Grilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Grilla.DefaultCellStyle = DataGridViewCellStyle5
        Me.Grilla.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grilla.EnableHeadersVisualStyles = False
        Me.Grilla.GridColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.Grilla.Location = New System.Drawing.Point(0, 0)
        Me.Grilla.MultiSelect = False
        Me.Grilla.Name = "Grilla"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.Grilla.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.Grilla.Size = New System.Drawing.Size(602, 260)
        Me.Grilla.TabIndex = 2
        '
        'Bar2
        '
        Me.Bar2.AntiAlias = True
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Fijar_Estado, Me.Btn_Grabar, Me.Btn_Editar, Me.Btn_Cancelar, Me.Btn_Agregar_Producto})
        Me.Bar2.Location = New System.Drawing.Point(0, 454)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(625, 41)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Bar2.TabIndex = 100
        Me.Bar2.TabStop = False
        Me.Bar2.Text = "Bar2"
        '
        'Btn_Fijar_Estado
        '
        Me.Btn_Fijar_Estado.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Fijar_Estado.ForeColor = System.Drawing.Color.Black
        Me.Btn_Fijar_Estado.Image = CType(resources.GetObject("Btn_Fijar_Estado.Image"), System.Drawing.Image)
        Me.Btn_Fijar_Estado.Name = "Btn_Fijar_Estado"
        Me.Btn_Fijar_Estado.Text = "Fijar Estado"
        '
        'Btn_Grabar
        '
        Me.Btn_Grabar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Grabar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Grabar.Image = CType(resources.GetObject("Btn_Grabar.Image"), System.Drawing.Image)
        Me.Btn_Grabar.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.Btn_Grabar.Name = "Btn_Grabar"
        Me.Btn_Grabar.Tooltip = "Grabar [F4]"
        '
        'Btn_Editar
        '
        Me.Btn_Editar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Editar.FontBold = True
        Me.Btn_Editar.ForeColor = System.Drawing.Color.Red
        Me.Btn_Editar.Image = CType(resources.GetObject("Btn_Editar.Image"), System.Drawing.Image)
        Me.Btn_Editar.Name = "Btn_Editar"
        Me.Btn_Editar.Tooltip = "Editar"
        Me.Btn_Editar.Visible = False
        '
        'Btn_Cancelar
        '
        Me.Btn_Cancelar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Cancelar.FontBold = True
        Me.Btn_Cancelar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Cancelar.Image = CType(resources.GetObject("Btn_Cancelar.Image"), System.Drawing.Image)
        Me.Btn_Cancelar.Name = "Btn_Cancelar"
        Me.Btn_Cancelar.Text = "Cancelar edición"
        Me.Btn_Cancelar.Visible = False
        '
        'Btn_Agregar_Producto
        '
        Me.Btn_Agregar_Producto.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Agregar_Producto.ForeColor = System.Drawing.Color.Black
        Me.Btn_Agregar_Producto.Image = CType(resources.GetObject("Btn_Agregar_Producto.Image"), System.Drawing.Image)
        Me.Btn_Agregar_Producto.Name = "Btn_Agregar_Producto"
        Me.Btn_Agregar_Producto.Text = "Agregar servicio"
        '
        'Imagenes_16x16
        '
        Me.Imagenes_16x16.ImageStream = CType(resources.GetObject("Imagenes_16x16.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.Imagenes_16x16.TransparentColor = System.Drawing.Color.Transparent
        Me.Imagenes_16x16.Images.SetKeyName(0, "OK")
        Me.Imagenes_16x16.Images.SetKeyName(1, "NO")
        Me.Imagenes_16x16.Images.SetKeyName(2, "WARNING")
        '
        'Chk_No_se_pudo_reparar_el_equipo
        '
        Me.Chk_No_se_pudo_reparar_el_equipo.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_No_se_pudo_reparar_el_equipo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_No_se_pudo_reparar_el_equipo.CheckBoxImageChecked = CType(resources.GetObject("Chk_No_se_pudo_reparar_el_equipo.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_No_se_pudo_reparar_el_equipo.FocusCuesEnabled = False
        Me.Chk_No_se_pudo_reparar_el_equipo.ForeColor = System.Drawing.Color.Black
        Me.Chk_No_se_pudo_reparar_el_equipo.Location = New System.Drawing.Point(9, 367)
        Me.Chk_No_se_pudo_reparar_el_equipo.Name = "Chk_No_se_pudo_reparar_el_equipo"
        Me.Chk_No_se_pudo_reparar_el_equipo.Size = New System.Drawing.Size(263, 16)
        Me.Chk_No_se_pudo_reparar_el_equipo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_No_se_pudo_reparar_el_equipo.TabIndex = 103
        Me.Chk_No_se_pudo_reparar_el_equipo.Text = "NO SE PUDO REPARAR EL EQUIPO"
        '
        'GroupPanel4
        '
        Me.GroupPanel4.BackColor = System.Drawing.Color.White
        Me.GroupPanel4.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel4.Controls.Add(Me.Txt_Nota)
        Me.GroupPanel4.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel4.Location = New System.Drawing.Point(9, 389)
        Me.GroupPanel4.Name = "GroupPanel4"
        Me.GroupPanel4.Size = New System.Drawing.Size(608, 53)
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
        Me.GroupPanel4.TabIndex = 104
        Me.GroupPanel4.Text = "Nota"
        '
        'Txt_Nota
        '
        Me.Txt_Nota.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Nota.Border.Class = "TextBoxBorder"
        Me.Txt_Nota.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Nota.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_Nota.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Nota.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Txt_Nota.FocusHighlightEnabled = True
        Me.Txt_Nota.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Nota.ForeColor = System.Drawing.Color.Black
        Me.Txt_Nota.Location = New System.Drawing.Point(0, 3)
        Me.Txt_Nota.MaxLength = 300
        Me.Txt_Nota.Name = "Txt_Nota"
        Me.Txt_Nota.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.Txt_Nota.Size = New System.Drawing.Size(602, 22)
        Me.Txt_Nota.TabIndex = 64
        '
        'Frm_St_Estado_05_Reparacion2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(625, 495)
        Me.Controls.Add(Me.GroupPanel4)
        Me.Controls.Add(Me.Chk_No_se_pudo_reparar_el_equipo)
        Me.Controls.Add(Me.Grupo_Presupuesto)
        Me.Controls.Add(Me.Grupo_Grilla)
        Me.Controls.Add(Me.Bar2)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_St_Estado_05_Reparacion2"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MetroForm"
        Me.Grupo_Presupuesto.ResumeLayout(False)
        Me.Grupo_Grilla.ResumeLayout(False)
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel4.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Grupo_Presupuesto As DevComponents.DotNetBar.Controls.GroupPanel
    Public WithEvents Txt_Tecnico_Taller As DevComponents.DotNetBar.Controls.TextBoxX
    Public WithEvents Txt_NroSerie As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Grupo_Grilla As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Grilla As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents Btn_Fijar_Estado As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Grabar As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_Editar As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_Cancelar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Agregar_Producto As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Imagenes_16x16 As ImageList
    Friend WithEvents Chk_No_se_pudo_reparar_el_equipo As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents GroupPanel4 As DevComponents.DotNetBar.Controls.GroupPanel
    Public WithEvents Txt_Nota As DevComponents.DotNetBar.Controls.TextBoxX
End Class
