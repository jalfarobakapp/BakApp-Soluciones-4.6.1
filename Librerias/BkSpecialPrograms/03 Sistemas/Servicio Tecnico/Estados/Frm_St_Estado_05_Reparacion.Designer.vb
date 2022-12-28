<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_St_Estado_05_Reparacion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_St_Estado_05_Reparacion))
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.GroupPanel2 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Chk_No_se_pudo_reparar_el_equipo = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Txt_Reparacion_Realizada = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Txt_Horas_Mano_de_Obra = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.Grupo_Asignacion_Tecnico = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Chk_Tec_Domicilio = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Chk_Taller_Externo = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rating_Star = New DevComponents.DotNetBar.Controls.RatingStar()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.Cmb_Tecnico = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.GroupPanel3 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Grilla = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.Bar2 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Fijar_Estado = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Grabar = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Editar = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Cancelar = New DevComponents.DotNetBar.ButtonItem()
        Me.GroupPanel4 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Txt_Nota = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Imagenes_16x16 = New System.Windows.Forms.ImageList(Me.components)
        Me.GroupPanel2.SuspendLayout()
        Me.Grupo_Asignacion_Tecnico.SuspendLayout()
        Me.GroupPanel3.SuspendLayout()
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupPanel2
        '
        Me.GroupPanel2.BackColor = System.Drawing.Color.White
        Me.GroupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel2.Controls.Add(Me.Chk_No_se_pudo_reparar_el_equipo)
        Me.GroupPanel2.Controls.Add(Me.Txt_Reparacion_Realizada)
        Me.GroupPanel2.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel2.Location = New System.Drawing.Point(12, 114)
        Me.GroupPanel2.Name = "GroupPanel2"
        Me.GroupPanel2.Size = New System.Drawing.Size(631, 146)
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
        Me.GroupPanel2.TabIndex = 98
        Me.GroupPanel2.Text = "Reparación Realizada"
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
        Me.Chk_No_se_pudo_reparar_el_equipo.Location = New System.Drawing.Point(3, 104)
        Me.Chk_No_se_pudo_reparar_el_equipo.Name = "Chk_No_se_pudo_reparar_el_equipo"
        Me.Chk_No_se_pudo_reparar_el_equipo.Size = New System.Drawing.Size(263, 16)
        Me.Chk_No_se_pudo_reparar_el_equipo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_No_se_pudo_reparar_el_equipo.TabIndex = 102
        Me.Chk_No_se_pudo_reparar_el_equipo.Text = "NO SE PUDO REPARAR EL EQUIPO"
        '
        'Txt_Reparacion_Realizada
        '
        Me.Txt_Reparacion_Realizada.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Reparacion_Realizada.Border.Class = "TextBoxBorder"
        Me.Txt_Reparacion_Realizada.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Reparacion_Realizada.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_Reparacion_Realizada.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Reparacion_Realizada.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Txt_Reparacion_Realizada.FocusHighlightEnabled = True
        Me.Txt_Reparacion_Realizada.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Reparacion_Realizada.ForeColor = System.Drawing.Color.Black
        Me.Txt_Reparacion_Realizada.Location = New System.Drawing.Point(3, 3)
        Me.Txt_Reparacion_Realizada.MaxLength = 1000
        Me.Txt_Reparacion_Realizada.Multiline = True
        Me.Txt_Reparacion_Realizada.Name = "Txt_Reparacion_Realizada"
        Me.Txt_Reparacion_Realizada.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.Txt_Reparacion_Realizada.Size = New System.Drawing.Size(619, 95)
        Me.Txt_Reparacion_Realizada.TabIndex = 7
        '
        'Txt_Horas_Mano_de_Obra
        '
        Me.Txt_Horas_Mano_de_Obra.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Horas_Mano_de_Obra.Border.Class = "TextBoxBorder"
        Me.Txt_Horas_Mano_de_Obra.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Horas_Mano_de_Obra.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_Horas_Mano_de_Obra.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Horas_Mano_de_Obra.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Txt_Horas_Mano_de_Obra.FocusHighlightEnabled = True
        Me.Txt_Horas_Mano_de_Obra.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Horas_Mano_de_Obra.ForeColor = System.Drawing.Color.Black
        Me.Txt_Horas_Mano_de_Obra.Location = New System.Drawing.Point(551, 47)
        Me.Txt_Horas_Mano_de_Obra.MaxLength = 300
        Me.Txt_Horas_Mano_de_Obra.Name = "Txt_Horas_Mano_de_Obra"
        Me.Txt_Horas_Mano_de_Obra.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.Txt_Horas_Mano_de_Obra.Size = New System.Drawing.Size(58, 22)
        Me.Txt_Horas_Mano_de_Obra.TabIndex = 70
        Me.Txt_Horas_Mano_de_Obra.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
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
        Me.LabelX1.Location = New System.Drawing.Point(379, 47)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(166, 23)
        Me.LabelX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.LabelX1.TabIndex = 69
        Me.LabelX1.Text = "Mano de obra (Cant. Horas)"
        '
        'Grupo_Asignacion_Tecnico
        '
        Me.Grupo_Asignacion_Tecnico.BackColor = System.Drawing.Color.White
        Me.Grupo_Asignacion_Tecnico.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Grupo_Asignacion_Tecnico.Controls.Add(Me.Chk_Tec_Domicilio)
        Me.Grupo_Asignacion_Tecnico.Controls.Add(Me.Txt_Horas_Mano_de_Obra)
        Me.Grupo_Asignacion_Tecnico.Controls.Add(Me.Chk_Taller_Externo)
        Me.Grupo_Asignacion_Tecnico.Controls.Add(Me.LabelX1)
        Me.Grupo_Asignacion_Tecnico.Controls.Add(Me.Rating_Star)
        Me.Grupo_Asignacion_Tecnico.Controls.Add(Me.Cmb_Tecnico)
        Me.Grupo_Asignacion_Tecnico.Controls.Add(Me.LabelX3)
        Me.Grupo_Asignacion_Tecnico.DisabledBackColor = System.Drawing.Color.Empty
        Me.Grupo_Asignacion_Tecnico.Location = New System.Drawing.Point(12, 12)
        Me.Grupo_Asignacion_Tecnico.Name = "Grupo_Asignacion_Tecnico"
        Me.Grupo_Asignacion_Tecnico.Size = New System.Drawing.Size(631, 96)
        '
        '
        '
        Me.Grupo_Asignacion_Tecnico.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Grupo_Asignacion_Tecnico.Style.BackColorGradientAngle = 90
        Me.Grupo_Asignacion_Tecnico.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Grupo_Asignacion_Tecnico.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Asignacion_Tecnico.Style.BorderBottomWidth = 1
        Me.Grupo_Asignacion_Tecnico.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.Grupo_Asignacion_Tecnico.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Asignacion_Tecnico.Style.BorderLeftWidth = 1
        Me.Grupo_Asignacion_Tecnico.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Asignacion_Tecnico.Style.BorderRightWidth = 1
        Me.Grupo_Asignacion_Tecnico.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Asignacion_Tecnico.Style.BorderTopWidth = 1
        Me.Grupo_Asignacion_Tecnico.Style.CornerDiameter = 4
        Me.Grupo_Asignacion_Tecnico.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Grupo_Asignacion_Tecnico.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.Grupo_Asignacion_Tecnico.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.Grupo_Asignacion_Tecnico.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.Grupo_Asignacion_Tecnico.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.Grupo_Asignacion_Tecnico.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Grupo_Asignacion_Tecnico.TabIndex = 99
        Me.Grupo_Asignacion_Tecnico.Text = "Asignación de técnico o taller para realizar la reparación"
        '
        'Chk_Tec_Domicilio
        '
        Me.Chk_Tec_Domicilio.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_Tec_Domicilio.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Tec_Domicilio.CheckBoxImageChecked = CType(resources.GetObject("Chk_Tec_Domicilio.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_Tec_Domicilio.FocusCuesEnabled = False
        Me.Chk_Tec_Domicilio.ForeColor = System.Drawing.Color.Black
        Me.Chk_Tec_Domicilio.Location = New System.Drawing.Point(203, 54)
        Me.Chk_Tec_Domicilio.Name = "Chk_Tec_Domicilio"
        Me.Chk_Tec_Domicilio.Size = New System.Drawing.Size(146, 16)
        Me.Chk_Tec_Domicilio.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Tec_Domicilio.TabIndex = 71
        Me.Chk_Tec_Domicilio.Text = "Técnico para domicilio"
        '
        'Chk_Taller_Externo
        '
        Me.Chk_Taller_Externo.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_Taller_Externo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Taller_Externo.CheckBoxImageChecked = CType(resources.GetObject("Chk_Taller_Externo.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_Taller_Externo.FocusCuesEnabled = False
        Me.Chk_Taller_Externo.ForeColor = System.Drawing.Color.Black
        Me.Chk_Taller_Externo.Location = New System.Drawing.Point(3, 54)
        Me.Chk_Taller_Externo.Name = "Chk_Taller_Externo"
        Me.Chk_Taller_Externo.Size = New System.Drawing.Size(183, 16)
        Me.Chk_Taller_Externo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Taller_Externo.TabIndex = 70
        Me.Chk_Taller_Externo.Text = "Taller externo - técnico externo"
        '
        'Rating_Star
        '
        Me.Rating_Star.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rating_Star.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rating_Star.ForeColor = System.Drawing.Color.Black
        Me.Rating_Star.IsEditable = False
        Me.Rating_Star.Location = New System.Drawing.Point(542, 13)
        Me.Rating_Star.Name = "Rating_Star"
        Me.Rating_Star.Size = New System.Drawing.Size(71, 23)
        Me.Rating_Star.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Rating_Star.TabIndex = 69
        Me.Rating_Star.TextColor = System.Drawing.Color.Empty
        '
        'LabelX3
        '
        Me.LabelX3.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX3.ForeColor = System.Drawing.Color.Black
        Me.LabelX3.Location = New System.Drawing.Point(3, 14)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(154, 23)
        Me.LabelX3.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.LabelX3.TabIndex = 64
        Me.LabelX3.Text = "Técnico / Taller externo"
        '
        'Cmb_Tecnico
        '
        Me.Cmb_Tecnico.DisplayMember = "Text"
        Me.Cmb_Tecnico.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.Cmb_Tecnico.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Cmb_Tecnico.FocusHighlightEnabled = True
        Me.Cmb_Tecnico.ForeColor = System.Drawing.Color.Black
        Me.Cmb_Tecnico.ItemHeight = 16
        Me.Cmb_Tecnico.Location = New System.Drawing.Point(148, 14)
        Me.Cmb_Tecnico.Name = "Cmb_Tecnico"
        Me.Cmb_Tecnico.Size = New System.Drawing.Size(366, 22)
        Me.Cmb_Tecnico.TabIndex = 68
        '
        'GroupPanel3
        '
        Me.GroupPanel3.BackColor = System.Drawing.Color.White
        Me.GroupPanel3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel3.Controls.Add(Me.Grilla)
        Me.GroupPanel3.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel3.Location = New System.Drawing.Point(12, 266)
        Me.GroupPanel3.Name = "GroupPanel3"
        Me.GroupPanel3.Size = New System.Drawing.Size(631, 189)
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
        Me.GroupPanel3.TabIndex = 100
        Me.GroupPanel3.Text = "Partes/Repuestos/Productos Utilizados"
        '
        'Grilla
        '
        Me.Grilla.AllowUserToAddRows = False
        Me.Grilla.AllowUserToDeleteRows = False
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
        Me.Grilla.Size = New System.Drawing.Size(625, 166)
        Me.Grilla.TabIndex = 1
        '
        'Bar2
        '
        Me.Bar2.AntiAlias = True
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Fijar_Estado, Me.Btn_Grabar, Me.Btn_Editar, Me.Btn_Cancelar})
        Me.Bar2.Location = New System.Drawing.Point(0, 529)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(653, 41)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Bar2.TabIndex = 101
        Me.Bar2.TabStop = False
        Me.Bar2.Text = "Bar2"
        '
        'Btn_Fijar_Estado
        '
        Me.Btn_Fijar_Estado.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Fijar_Estado.ForeColor = System.Drawing.Color.Black
        Me.Btn_Fijar_Estado.Image = CType(resources.GetObject("Btn_Fijar_Estado.Image"), System.Drawing.Image)
        Me.Btn_Fijar_Estado.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Center
        Me.Btn_Fijar_Estado.Name = "Btn_Fijar_Estado"
        Me.Btn_Fijar_Estado.Text = "Fijar Estado"
        Me.Btn_Fijar_Estado.Visible = False
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
        'GroupPanel4
        '
        Me.GroupPanel4.BackColor = System.Drawing.Color.White
        Me.GroupPanel4.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel4.Controls.Add(Me.Txt_Nota)
        Me.GroupPanel4.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel4.Location = New System.Drawing.Point(12, 461)
        Me.GroupPanel4.Name = "GroupPanel4"
        Me.GroupPanel4.Size = New System.Drawing.Size(631, 53)
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
        Me.GroupPanel4.TabIndex = 102
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
        Me.Txt_Nota.Size = New System.Drawing.Size(625, 22)
        Me.Txt_Nota.TabIndex = 64
        '
        'Imagenes_16x16
        '
        Me.Imagenes_16x16.ImageStream = CType(resources.GetObject("Imagenes_16x16.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.Imagenes_16x16.TransparentColor = System.Drawing.Color.Transparent
        Me.Imagenes_16x16.Images.SetKeyName(0, "OK")
        Me.Imagenes_16x16.Images.SetKeyName(1, "NO")
        Me.Imagenes_16x16.Images.SetKeyName(2, "WARNING")
        '
        'Frm_St_Estado_05_Reparacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(653, 570)
        Me.Controls.Add(Me.GroupPanel4)
        Me.Controls.Add(Me.Bar2)
        Me.Controls.Add(Me.GroupPanel3)
        Me.Controls.Add(Me.Grupo_Asignacion_Tecnico)
        Me.Controls.Add(Me.GroupPanel2)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_St_Estado_05_Reparacion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reparación y Cierre"
        Me.GroupPanel2.ResumeLayout(False)
        Me.Grupo_Asignacion_Tecnico.ResumeLayout(False)
        Me.GroupPanel3.ResumeLayout(False)
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel4.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupPanel2 As DevComponents.DotNetBar.Controls.GroupPanel
    Public WithEvents Txt_Reparacion_Realizada As DevComponents.DotNetBar.Controls.TextBoxX
    Public WithEvents Txt_Horas_Mano_de_Obra As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Grupo_Asignacion_Tecnico As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Chk_Tec_Domicilio As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Chk_Taller_Externo As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rating_Star As DevComponents.DotNetBar.Controls.RatingStar
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Cmb_Tecnico As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents GroupPanel3 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Grilla As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents Btn_Fijar_Estado As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Chk_No_se_pudo_reparar_el_equipo As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents GroupPanel4 As DevComponents.DotNetBar.Controls.GroupPanel
    Public WithEvents Txt_Nota As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Imagenes_16x16 As System.Windows.Forms.ImageList
    Friend WithEvents Btn_Grabar As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_Editar As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_Cancelar As DevComponents.DotNetBar.ButtonItem
End Class
