<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_SQL2Excel_Diseno
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_SQL2Excel_Diseno))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Mnu_Tex_CortarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContextMenuStrip2 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.Mnu_Tex_CopiarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Mnu_Tex_PegarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Txt_Query_SQL = New DevComponents.DotNetBar.Controls.RichTextBoxEx()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.Mnu_CopiarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SuperTabItem1 = New DevComponents.DotNetBar.SuperTabItem()
        Me.SuperTabControlPanel1 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.SuperTabItem2 = New DevComponents.DotNetBar.SuperTabItem()
        Me.SuperTabControlPanel2 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.Grilla = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.SuperTabControl1 = New DevComponents.DotNetBar.SuperTabControl()
        Me.GroupPanel2 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Ejecutar_Consulta_SQL = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Guardar_Consulta = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Fuente = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Mant_Comandos_SQL = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Editar_Consulta = New DevComponents.DotNetBar.ButtonItem()
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Txt_Nombre_Query = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Rdb_Consulta_Global = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_Consulta_Personal = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.ContextMenuStrip2.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuperTabControlPanel1.SuspendLayout()
        Me.SuperTabControlPanel2.SuspendLayout()
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SuperTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuperTabControl1.SuspendLayout()
        Me.GroupPanel2.SuspendLayout()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Mnu_Tex_CortarToolStripMenuItem
        '
        Me.Mnu_Tex_CortarToolStripMenuItem.Image = CType(resources.GetObject("Mnu_Tex_CortarToolStripMenuItem.Image"), System.Drawing.Image)
        Me.Mnu_Tex_CortarToolStripMenuItem.Name = "Mnu_Tex_CortarToolStripMenuItem"
        Me.Mnu_Tex_CortarToolStripMenuItem.Size = New System.Drawing.Size(109, 22)
        Me.Mnu_Tex_CortarToolStripMenuItem.Text = "Cortar"
        '
        'ContextMenuStrip2
        '
        Me.ContextMenuStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Mnu_Tex_CortarToolStripMenuItem, Me.Mnu_Tex_CopiarToolStripMenuItem, Me.Mnu_Tex_PegarToolStripMenuItem})
        Me.ContextMenuStrip2.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip2.Size = New System.Drawing.Size(110, 70)
        '
        'Mnu_Tex_CopiarToolStripMenuItem
        '
        Me.Mnu_Tex_CopiarToolStripMenuItem.Image = CType(resources.GetObject("Mnu_Tex_CopiarToolStripMenuItem.Image"), System.Drawing.Image)
        Me.Mnu_Tex_CopiarToolStripMenuItem.Name = "Mnu_Tex_CopiarToolStripMenuItem"
        Me.Mnu_Tex_CopiarToolStripMenuItem.Size = New System.Drawing.Size(109, 22)
        Me.Mnu_Tex_CopiarToolStripMenuItem.Text = "Copiar"
        '
        'Mnu_Tex_PegarToolStripMenuItem
        '
        Me.Mnu_Tex_PegarToolStripMenuItem.Image = CType(resources.GetObject("Mnu_Tex_PegarToolStripMenuItem.Image"), System.Drawing.Image)
        Me.Mnu_Tex_PegarToolStripMenuItem.Name = "Mnu_Tex_PegarToolStripMenuItem"
        Me.Mnu_Tex_PegarToolStripMenuItem.Size = New System.Drawing.Size(109, 22)
        Me.Mnu_Tex_PegarToolStripMenuItem.Text = "Pegar"
        '
        'Txt_Query_SQL
        '
        Me.Txt_Query_SQL.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Query_SQL.BackgroundStyle.Class = "RichTextBoxBorder"
        Me.Txt_Query_SQL.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Query_SQL.ContextMenuStrip = Me.ContextMenuStrip2
        Me.Txt_Query_SQL.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Txt_Query_SQL.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Query_SQL.ForeColor = System.Drawing.Color.Black
        Me.Txt_Query_SQL.Location = New System.Drawing.Point(0, 0)
        Me.Txt_Query_SQL.Name = "Txt_Query_SQL"
        Me.Txt_Query_SQL.Rtf = "{\rtf1\ansi\ansicpg1252\deff0\nouicompat\deflang13322{\fonttbl{\f0\fnil\fcharset0" &
    " Courier New;}}" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "{\*\generator Riched20 10.0.22621}\viewkind4\uc1 " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "\pard\f0\fs2" &
    "0\par" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "}" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.Txt_Query_SQL.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical
        Me.Txt_Query_SQL.Size = New System.Drawing.Size(879, 373)
        Me.Txt_Query_SQL.TabIndex = 2
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Mnu_CopiarToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(110, 26)
        '
        'Mnu_CopiarToolStripMenuItem
        '
        Me.Mnu_CopiarToolStripMenuItem.Image = CType(resources.GetObject("Mnu_CopiarToolStripMenuItem.Image"), System.Drawing.Image)
        Me.Mnu_CopiarToolStripMenuItem.Name = "Mnu_CopiarToolStripMenuItem"
        Me.Mnu_CopiarToolStripMenuItem.Size = New System.Drawing.Size(109, 22)
        Me.Mnu_CopiarToolStripMenuItem.Text = "Copiar"
        '
        'SuperTabItem1
        '
        Me.SuperTabItem1.AttachedControl = Me.SuperTabControlPanel1
        Me.SuperTabItem1.GlobalItem = False
        Me.SuperTabItem1.Name = "SuperTabItem1"
        Me.SuperTabItem1.Text = "Consulta SQL"
        '
        'SuperTabControlPanel1
        '
        Me.SuperTabControlPanel1.Controls.Add(Me.Txt_Query_SQL)
        Me.SuperTabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel1.Location = New System.Drawing.Point(0, 25)
        Me.SuperTabControlPanel1.Name = "SuperTabControlPanel1"
        Me.SuperTabControlPanel1.Size = New System.Drawing.Size(879, 373)
        Me.SuperTabControlPanel1.TabIndex = 1
        Me.SuperTabControlPanel1.TabItem = Me.SuperTabItem1
        '
        'SuperTabItem2
        '
        Me.SuperTabItem2.AttachedControl = Me.SuperTabControlPanel2
        Me.SuperTabItem2.GlobalItem = False
        Me.SuperTabItem2.Name = "SuperTabItem2"
        Me.SuperTabItem2.Text = "Ayuda"
        Me.SuperTabItem2.Visible = False
        '
        'SuperTabControlPanel2
        '
        Me.SuperTabControlPanel2.Controls.Add(Me.Grilla)
        Me.SuperTabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel2.Location = New System.Drawing.Point(0, 0)
        Me.SuperTabControlPanel2.Name = "SuperTabControlPanel2"
        Me.SuperTabControlPanel2.Size = New System.Drawing.Size(879, 398)
        Me.SuperTabControlPanel2.TabIndex = 0
        Me.SuperTabControlPanel2.TabItem = Me.SuperTabItem2
        '
        'Grilla
        '
        Me.Grilla.AllowUserToAddRows = False
        Me.Grilla.AllowUserToDeleteRows = False
        Me.Grilla.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
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
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
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
        Me.Grilla.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.Grilla.Size = New System.Drawing.Size(879, 398)
        Me.Grilla.StandardTab = True
        Me.Grilla.TabIndex = 67
        '
        'SuperTabControl1
        '
        Me.SuperTabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SuperTabControl1.BackColor = System.Drawing.Color.White
        '
        '
        '
        '
        '
        '
        Me.SuperTabControl1.ControlBox.CloseBox.Name = ""
        '
        '
        '
        Me.SuperTabControl1.ControlBox.MenuBox.Name = ""
        Me.SuperTabControl1.ControlBox.Name = ""
        Me.SuperTabControl1.ControlBox.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.SuperTabControl1.ControlBox.MenuBox, Me.SuperTabControl1.ControlBox.CloseBox})
        Me.SuperTabControl1.Controls.Add(Me.SuperTabControlPanel1)
        Me.SuperTabControl1.Controls.Add(Me.SuperTabControlPanel2)
        Me.SuperTabControl1.ForeColor = System.Drawing.Color.Black
        Me.SuperTabControl1.Location = New System.Drawing.Point(8, 3)
        Me.SuperTabControl1.Name = "SuperTabControl1"
        Me.SuperTabControl1.ReorderTabsEnabled = True
        Me.SuperTabControl1.SelectedTabFont = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold)
        Me.SuperTabControl1.SelectedTabIndex = 0
        Me.SuperTabControl1.Size = New System.Drawing.Size(879, 398)
        Me.SuperTabControl1.TabFont = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SuperTabControl1.TabIndex = 1
        Me.SuperTabControl1.Tabs.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.SuperTabItem1, Me.SuperTabItem2})
        Me.SuperTabControl1.TabStyle = DevComponents.DotNetBar.eSuperTabStyle.Office2010BackstageBlue
        Me.SuperTabControl1.Text = "SuperTabControl1"
        '
        'GroupPanel2
        '
        Me.GroupPanel2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupPanel2.BackColor = System.Drawing.Color.White
        Me.GroupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel2.Controls.Add(Me.SuperTabControl1)
        Me.GroupPanel2.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel2.Location = New System.Drawing.Point(1, 58)
        Me.GroupPanel2.Name = "GroupPanel2"
        Me.GroupPanel2.Size = New System.Drawing.Size(896, 427)
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
        Me.GroupPanel2.TabIndex = 68
        Me.GroupPanel2.Text = "SQL"
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Ejecutar_Consulta_SQL, Me.Btn_Guardar_Consulta, Me.Btn_Fuente, Me.Btn_Mant_Comandos_SQL, Me.Btn_Editar_Consulta})
        Me.Bar1.Location = New System.Drawing.Point(0, 520)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(897, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2010
        Me.Bar1.TabIndex = 66
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'Btn_Ejecutar_Consulta_SQL
        '
        Me.Btn_Ejecutar_Consulta_SQL.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Ejecutar_Consulta_SQL.ForeColor = System.Drawing.Color.Black
        Me.Btn_Ejecutar_Consulta_SQL.Image = CType(resources.GetObject("Btn_Ejecutar_Consulta_SQL.Image"), System.Drawing.Image)
        Me.Btn_Ejecutar_Consulta_SQL.ImageAlt = CType(resources.GetObject("Btn_Ejecutar_Consulta_SQL.ImageAlt"), System.Drawing.Image)
        Me.Btn_Ejecutar_Consulta_SQL.Name = "Btn_Ejecutar_Consulta_SQL"
        Me.Btn_Ejecutar_Consulta_SQL.Tooltip = "Ejecutar consulta SQL"
        '
        'Btn_Guardar_Consulta
        '
        Me.Btn_Guardar_Consulta.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Guardar_Consulta.ForeColor = System.Drawing.Color.Black
        Me.Btn_Guardar_Consulta.Image = CType(resources.GetObject("Btn_Guardar_Consulta.Image"), System.Drawing.Image)
        Me.Btn_Guardar_Consulta.ImageAlt = CType(resources.GetObject("Btn_Guardar_Consulta.ImageAlt"), System.Drawing.Image)
        Me.Btn_Guardar_Consulta.Name = "Btn_Guardar_Consulta"
        Me.Btn_Guardar_Consulta.Tooltip = "Guardar consulta"
        '
        'Btn_Fuente
        '
        Me.Btn_Fuente.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Fuente.ForeColor = System.Drawing.Color.Black
        Me.Btn_Fuente.Image = CType(resources.GetObject("Btn_Fuente.Image"), System.Drawing.Image)
        Me.Btn_Fuente.Name = "Btn_Fuente"
        Me.Btn_Fuente.Tooltip = "Cambiar Fuente"
        Me.Btn_Fuente.Visible = False
        '
        'Btn_Mant_Comandos_SQL
        '
        Me.Btn_Mant_Comandos_SQL.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Mant_Comandos_SQL.ForeColor = System.Drawing.Color.Black
        Me.Btn_Mant_Comandos_SQL.Image = CType(resources.GetObject("Btn_Mant_Comandos_SQL.Image"), System.Drawing.Image)
        Me.Btn_Mant_Comandos_SQL.Name = "Btn_Mant_Comandos_SQL"
        Me.Btn_Mant_Comandos_SQL.Tooltip = "Grabar etiqueta"
        Me.Btn_Mant_Comandos_SQL.Visible = False
        '
        'Btn_Editar_Consulta
        '
        Me.Btn_Editar_Consulta.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Editar_Consulta.ForeColor = System.Drawing.Color.Black
        Me.Btn_Editar_Consulta.Image = CType(resources.GetObject("Btn_Editar_Consulta.Image"), System.Drawing.Image)
        Me.Btn_Editar_Consulta.Name = "Btn_Editar_Consulta"
        Me.Btn_Editar_Consulta.Tooltip = "Guardar consulta"
        Me.Btn_Editar_Consulta.Visible = False
        '
        'GroupPanel1
        '
        Me.GroupPanel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupPanel1.BackColor = System.Drawing.Color.White
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.Txt_Nombre_Query)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Location = New System.Drawing.Point(1, 0)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(896, 52)
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
        Me.GroupPanel1.TabIndex = 70
        Me.GroupPanel1.Text = "Nombe de la consulta SQL"
        '
        'Txt_Nombre_Query
        '
        Me.Txt_Nombre_Query.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Txt_Nombre_Query.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Nombre_Query.Border.Class = "TextBoxBorder"
        Me.Txt_Nombre_Query.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Nombre_Query.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Nombre_Query.ForeColor = System.Drawing.Color.Black
        Me.Txt_Nombre_Query.Location = New System.Drawing.Point(3, 3)
        Me.Txt_Nombre_Query.Name = "Txt_Nombre_Query"
        Me.Txt_Nombre_Query.PreventEnterBeep = True
        Me.Txt_Nombre_Query.Size = New System.Drawing.Size(884, 22)
        Me.Txt_Nombre_Query.TabIndex = 0
        '
        'Rdb_Consulta_Global
        '
        Me.Rdb_Consulta_Global.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Rdb_Consulta_Global.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Rdb_Consulta_Global.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Consulta_Global.CheckBoxImageChecked = CType(resources.GetObject("Rdb_Consulta_Global.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Rdb_Consulta_Global.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Consulta_Global.FocusCuesEnabled = False
        Me.Rdb_Consulta_Global.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Consulta_Global.Location = New System.Drawing.Point(119, 491)
        Me.Rdb_Consulta_Global.Name = "Rdb_Consulta_Global"
        Me.Rdb_Consulta_Global.Size = New System.Drawing.Size(100, 23)
        Me.Rdb_Consulta_Global.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Consulta_Global.TabIndex = 71
        Me.Rdb_Consulta_Global.Text = "Consulta Global"
        '
        'Rdb_Consulta_Personal
        '
        Me.Rdb_Consulta_Personal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Rdb_Consulta_Personal.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Rdb_Consulta_Personal.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Consulta_Personal.CheckBoxImageChecked = CType(resources.GetObject("Rdb_Consulta_Personal.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Rdb_Consulta_Personal.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Consulta_Personal.Checked = True
        Me.Rdb_Consulta_Personal.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Rdb_Consulta_Personal.CheckValue = "Y"
        Me.Rdb_Consulta_Personal.FocusCuesEnabled = False
        Me.Rdb_Consulta_Personal.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Consulta_Personal.Location = New System.Drawing.Point(1, 491)
        Me.Rdb_Consulta_Personal.Name = "Rdb_Consulta_Personal"
        Me.Rdb_Consulta_Personal.Size = New System.Drawing.Size(112, 23)
        Me.Rdb_Consulta_Personal.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Consulta_Personal.TabIndex = 72
        Me.Rdb_Consulta_Personal.Text = "Consulta personal"
        '
        'Frm_SQL2Excel_Diseno
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(897, 561)
        Me.Controls.Add(Me.Rdb_Consulta_Personal)
        Me.Controls.Add(Me.Rdb_Consulta_Global)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Controls.Add(Me.GroupPanel2)
        Me.Controls.Add(Me.Bar1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(800, 600)
        Me.Name = "Frm_SQL2Excel_Diseno"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CONSULTA SQL EN LINEA"
        Me.ContextMenuStrip2.ResumeLayout(False)
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.SuperTabControlPanel1.ResumeLayout(False)
        Me.SuperTabControlPanel2.ResumeLayout(False)
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SuperTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SuperTabControl1.ResumeLayout(False)
        Me.GroupPanel2.ResumeLayout(False)
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Mnu_Tex_CortarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ContextMenuStrip2 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents Mnu_Tex_CopiarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Mnu_Tex_PegarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Txt_Query_SQL As DevComponents.DotNetBar.Controls.RichTextBoxEx
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents Mnu_CopiarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SuperTabItem1 As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents SuperTabControlPanel1 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents SuperTabItem2 As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents SuperTabControlPanel2 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents SuperTabControl1 As DevComponents.DotNetBar.SuperTabControl
    Friend WithEvents GroupPanel2 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents Btn_Ejecutar_Consulta_SQL As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Guardar_Consulta As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Mant_Comandos_SQL As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Fuente As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Editar_Consulta As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Txt_Nombre_Query As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Rdb_Consulta_Global As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_Consulta_Personal As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Grilla As DevComponents.DotNetBar.Controls.DataGridViewX
End Class
