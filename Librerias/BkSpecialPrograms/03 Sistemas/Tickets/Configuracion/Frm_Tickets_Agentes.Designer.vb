<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Tickets_Agentes
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Tickets_Agentes))
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Bar2 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Crear_Agente = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_ExportarExcel = New DevComponents.DotNetBar.ButtonItem()
        Me.GroupPanel2 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Grilla_Tipos = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.GroupPanel3 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Txt_Buscador = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX7 = New DevComponents.DotNetBar.LabelX()
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.ContextMenuBar1 = New DevComponents.DotNetBar.ContextMenuBar()
        Me.Menu_Contextual_01 = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Mnu_AsociarTipos = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Mnu_EliminarAgente = New DevComponents.DotNetBar.ButtonItem()
        Me.Menu_Contextual_02 = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Mnu_QuitarTipo = New DevComponents.DotNetBar.ButtonItem()
        Me.Grilla_Agentes = New DevComponents.DotNetBar.Controls.DataGridViewX()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel2.SuspendLayout()
        CType(Me.Grilla_Tipos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel3.SuspendLayout()
        Me.GroupPanel1.SuspendLayout()
        CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Grilla_Agentes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Bar2
        '
        Me.Bar2.AntiAlias = True
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Crear_Agente, Me.Btn_ExportarExcel})
        Me.Bar2.Location = New System.Drawing.Point(0, 510)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(535, 41)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Bar2.TabIndex = 114
        Me.Bar2.TabStop = False
        Me.Bar2.Text = "Bar2"
        '
        'Btn_Crear_Agente
        '
        Me.Btn_Crear_Agente.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Crear_Agente.ForeColor = System.Drawing.Color.Black
        Me.Btn_Crear_Agente.Image = CType(resources.GetObject("Btn_Crear_Agente.Image"), System.Drawing.Image)
        Me.Btn_Crear_Agente.ImageAlt = CType(resources.GetObject("Btn_Crear_Agente.ImageAlt"), System.Drawing.Image)
        Me.Btn_Crear_Agente.Name = "Btn_Crear_Agente"
        Me.Btn_Crear_Agente.Tooltip = "Crear nuevo tipo de descuento especial"
        '
        'Btn_ExportarExcel
        '
        Me.Btn_ExportarExcel.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_ExportarExcel.ForeColor = System.Drawing.Color.Black
        Me.Btn_ExportarExcel.Image = CType(resources.GetObject("Btn_ExportarExcel.Image"), System.Drawing.Image)
        Me.Btn_ExportarExcel.ImageAlt = CType(resources.GetObject("Btn_ExportarExcel.ImageAlt"), System.Drawing.Image)
        Me.Btn_ExportarExcel.Name = "Btn_ExportarExcel"
        Me.Btn_ExportarExcel.Tooltip = "Exportar a Excel"
        Me.Btn_ExportarExcel.Visible = False
        '
        'GroupPanel2
        '
        Me.GroupPanel2.BackColor = System.Drawing.Color.White
        Me.GroupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel2.Controls.Add(Me.Grilla_Tipos)
        Me.GroupPanel2.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel2.Location = New System.Drawing.Point(9, 345)
        Me.GroupPanel2.Name = "GroupPanel2"
        Me.GroupPanel2.Size = New System.Drawing.Size(515, 153)
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
        Me.GroupPanel2.TabIndex = 115
        Me.GroupPanel2.Text = "Tipos de Tickets que puede responder el agente"
        '
        'Grilla_Tipos
        '
        Me.Grilla_Tipos.AllowUserToAddRows = False
        Me.Grilla_Tipos.AllowUserToDeleteRows = False
        Me.Grilla_Tipos.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle13.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle13.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle13.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla_Tipos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle13
        Me.Grilla_Tipos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle14.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle14.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle14.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle14.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Grilla_Tipos.DefaultCellStyle = DataGridViewCellStyle14
        Me.Grilla_Tipos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grilla_Tipos.EnableHeadersVisualStyles = False
        Me.Grilla_Tipos.GridColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.Grilla_Tipos.Location = New System.Drawing.Point(0, 0)
        Me.Grilla_Tipos.MultiSelect = False
        Me.Grilla_Tipos.Name = "Grilla_Tipos"
        Me.Grilla_Tipos.ReadOnly = True
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle15.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle15.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle15.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla_Tipos.RowHeadersDefaultCellStyle = DataGridViewCellStyle15
        Me.Grilla_Tipos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.Grilla_Tipos.Size = New System.Drawing.Size(509, 130)
        Me.Grilla_Tipos.TabIndex = 1
        '
        'GroupPanel3
        '
        Me.GroupPanel3.BackColor = System.Drawing.Color.White
        Me.GroupPanel3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel3.Controls.Add(Me.Txt_Buscador)
        Me.GroupPanel3.Controls.Add(Me.LabelX7)
        Me.GroupPanel3.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel3.Location = New System.Drawing.Point(9, 0)
        Me.GroupPanel3.Name = "GroupPanel3"
        Me.GroupPanel3.Size = New System.Drawing.Size(515, 70)
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
        Me.GroupPanel3.TabIndex = 116
        Me.GroupPanel3.Text = "Buscador"
        '
        'Txt_Buscador
        '
        Me.Txt_Buscador.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Buscador.Border.Class = "TextBoxBorder"
        Me.Txt_Buscador.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Buscador.ButtonCustom.Image = CType(resources.GetObject("Txt_Buscador.ButtonCustom.Image"), System.Drawing.Image)
        Me.Txt_Buscador.ButtonCustom2.Image = CType(resources.GetObject("Txt_Buscador.ButtonCustom2.Image"), System.Drawing.Image)
        Me.Txt_Buscador.ButtonCustom2.Visible = True
        Me.Txt_Buscador.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Buscador.ForeColor = System.Drawing.Color.Black
        Me.Txt_Buscador.Location = New System.Drawing.Point(3, 20)
        Me.Txt_Buscador.Name = "Txt_Buscador"
        Me.Txt_Buscador.PreventEnterBeep = True
        Me.Txt_Buscador.Size = New System.Drawing.Size(506, 22)
        Me.Txt_Buscador.TabIndex = 0
        '
        'LabelX7
        '
        Me.LabelX7.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX7.ForeColor = System.Drawing.Color.Black
        Me.LabelX7.Location = New System.Drawing.Point(3, 0)
        Me.LabelX7.Name = "LabelX7"
        Me.LabelX7.Size = New System.Drawing.Size(404, 23)
        Me.LabelX7.TabIndex = 99
        Me.LabelX7.Text = "Ingrese algo de la descripción de un agente o tipo"
        '
        'GroupPanel1
        '
        Me.GroupPanel1.BackColor = System.Drawing.Color.White
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.ContextMenuBar1)
        Me.GroupPanel1.Controls.Add(Me.Grilla_Agentes)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Location = New System.Drawing.Point(9, 76)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(515, 263)
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
        Me.GroupPanel1.TabIndex = 113
        Me.GroupPanel1.Text = "Agentes"
        '
        'ContextMenuBar1
        '
        Me.ContextMenuBar1.AntiAlias = True
        Me.ContextMenuBar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ContextMenuBar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Menu_Contextual_01, Me.Menu_Contextual_02})
        Me.ContextMenuBar1.Location = New System.Drawing.Point(51, 28)
        Me.ContextMenuBar1.Name = "ContextMenuBar1"
        Me.ContextMenuBar1.Size = New System.Drawing.Size(330, 25)
        Me.ContextMenuBar1.Stretch = True
        Me.ContextMenuBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ContextMenuBar1.TabIndex = 56
        Me.ContextMenuBar1.TabStop = False
        Me.ContextMenuBar1.Text = "ContextMenuBar1"
        '
        'Menu_Contextual_01
        '
        Me.Menu_Contextual_01.AutoExpandOnClick = True
        Me.Menu_Contextual_01.Name = "Menu_Contextual_01"
        Me.Menu_Contextual_01.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Mnu_AsociarTipos, Me.Btn_Mnu_EliminarAgente})
        Me.Menu_Contextual_01.Text = "Opciones"
        '
        'Btn_Mnu_AsociarTipos
        '
        Me.Btn_Mnu_AsociarTipos.Image = CType(resources.GetObject("Btn_Mnu_AsociarTipos.Image"), System.Drawing.Image)
        Me.Btn_Mnu_AsociarTipos.ImageAlt = CType(resources.GetObject("Btn_Mnu_AsociarTipos.ImageAlt"), System.Drawing.Image)
        Me.Btn_Mnu_AsociarTipos.Name = "Btn_Mnu_AsociarTipos"
        Me.Btn_Mnu_AsociarTipos.Text = "Asociar tipos de tickets al agente"
        '
        'Btn_Mnu_EliminarAgente
        '
        Me.Btn_Mnu_EliminarAgente.Image = CType(resources.GetObject("Btn_Mnu_EliminarAgente.Image"), System.Drawing.Image)
        Me.Btn_Mnu_EliminarAgente.ImageAlt = CType(resources.GetObject("Btn_Mnu_EliminarAgente.ImageAlt"), System.Drawing.Image)
        Me.Btn_Mnu_EliminarAgente.Name = "Btn_Mnu_EliminarAgente"
        Me.Btn_Mnu_EliminarAgente.Text = "Eliminar agente"
        '
        'Menu_Contextual_02
        '
        Me.Menu_Contextual_02.AutoExpandOnClick = True
        Me.Menu_Contextual_02.Name = "Menu_Contextual_02"
        Me.Menu_Contextual_02.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Mnu_QuitarTipo})
        Me.Menu_Contextual_02.Text = "Opciones 2"
        '
        'Btn_Mnu_QuitarTipo
        '
        Me.Btn_Mnu_QuitarTipo.Image = CType(resources.GetObject("Btn_Mnu_QuitarTipo.Image"), System.Drawing.Image)
        Me.Btn_Mnu_QuitarTipo.ImageAlt = CType(resources.GetObject("Btn_Mnu_QuitarTipo.ImageAlt"), System.Drawing.Image)
        Me.Btn_Mnu_QuitarTipo.Name = "Btn_Mnu_QuitarTipo"
        Me.Btn_Mnu_QuitarTipo.Text = "Quitar tipo"
        '
        'Grilla_Agentes
        '
        Me.Grilla_Agentes.AllowUserToAddRows = False
        Me.Grilla_Agentes.AllowUserToDeleteRows = False
        Me.Grilla_Agentes.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle16.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle16.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle16.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle16.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla_Agentes.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle16
        Me.Grilla_Agentes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle17.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle17.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle17.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle17.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle17.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Grilla_Agentes.DefaultCellStyle = DataGridViewCellStyle17
        Me.Grilla_Agentes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grilla_Agentes.EnableHeadersVisualStyles = False
        Me.Grilla_Agentes.GridColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.Grilla_Agentes.Location = New System.Drawing.Point(0, 0)
        Me.Grilla_Agentes.MultiSelect = False
        Me.Grilla_Agentes.Name = "Grilla_Agentes"
        Me.Grilla_Agentes.ReadOnly = True
        DataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle18.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle18.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle18.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle18.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle18.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla_Agentes.RowHeadersDefaultCellStyle = DataGridViewCellStyle18
        Me.Grilla_Agentes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.Grilla_Agentes.Size = New System.Drawing.Size(509, 240)
        Me.Grilla_Agentes.TabIndex = 1
        '
        'Frm_Tickets_Agentes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(535, 551)
        Me.Controls.Add(Me.Bar2)
        Me.Controls.Add(Me.GroupPanel2)
        Me.Controls.Add(Me.GroupPanel3)
        Me.Controls.Add(Me.GroupPanel1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Tickets_Agentes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MANTENCION DE AGENTES DE SERVICIO PARA TICKETS"
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel2.ResumeLayout(False)
        CType(Me.Grilla_Tipos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel3.ResumeLayout(False)
        Me.GroupPanel1.ResumeLayout(False)
        CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Grilla_Agentes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents Btn_Crear_Agente As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_ExportarExcel As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents GroupPanel2 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Grilla_Tipos As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents GroupPanel3 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Txt_Buscador As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX7 As DevComponents.DotNetBar.LabelX
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Grilla_Agentes As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents ContextMenuBar1 As DevComponents.DotNetBar.ContextMenuBar
    Friend WithEvents Menu_Contextual_01 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Mnu_AsociarTipos As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Mnu_EliminarAgente As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Menu_Contextual_02 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Mnu_QuitarTipo As DevComponents.DotNetBar.ButtonItem
End Class
