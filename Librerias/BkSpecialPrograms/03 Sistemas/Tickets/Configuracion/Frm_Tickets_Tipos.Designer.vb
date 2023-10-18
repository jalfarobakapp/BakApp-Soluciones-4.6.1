<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Tickets_Tipos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Tickets_Tipos))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.ContextMenuBar1 = New DevComponents.DotNetBar.ContextMenuBar()
        Me.Menu_Contextual_01 = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Mnu_EditarTipo = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Mnu_EliminarTipo = New DevComponents.DotNetBar.ButtonItem()
        Me.Grilla_Tipos = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.Bar2 = New DevComponents.DotNetBar.Bar()
        Me.Btn_CrearTipo = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_ExportarExcel = New DevComponents.DotNetBar.ButtonItem()
        Me.Lbl_Area = New DevComponents.DotNetBar.LabelX()
        Me.GroupPanel1.SuspendLayout()
        CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Grilla_Tipos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupPanel1
        '
        Me.GroupPanel1.BackColor = System.Drawing.Color.White
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.ContextMenuBar1)
        Me.GroupPanel1.Controls.Add(Me.Grilla_Tipos)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Location = New System.Drawing.Point(10, 41)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(516, 389)
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
        Me.GroupPanel1.TabIndex = 117
        Me.GroupPanel1.Text = "Detalle"
        '
        'ContextMenuBar1
        '
        Me.ContextMenuBar1.AntiAlias = True
        Me.ContextMenuBar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ContextMenuBar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Menu_Contextual_01})
        Me.ContextMenuBar1.Location = New System.Drawing.Point(43, 27)
        Me.ContextMenuBar1.Name = "ContextMenuBar1"
        Me.ContextMenuBar1.Size = New System.Drawing.Size(330, 25)
        Me.ContextMenuBar1.Stretch = True
        Me.ContextMenuBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ContextMenuBar1.TabIndex = 55
        Me.ContextMenuBar1.TabStop = False
        Me.ContextMenuBar1.Text = "ContextMenuBar1"
        '
        'Menu_Contextual_01
        '
        Me.Menu_Contextual_01.AutoExpandOnClick = True
        Me.Menu_Contextual_01.Name = "Menu_Contextual_01"
        Me.Menu_Contextual_01.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Mnu_EditarTipo, Me.Btn_Mnu_EliminarTipo})
        Me.Menu_Contextual_01.Text = "Opciones"
        '
        'Btn_Mnu_EditarTipo
        '
        Me.Btn_Mnu_EditarTipo.Image = CType(resources.GetObject("Btn_Mnu_EditarTipo.Image"), System.Drawing.Image)
        Me.Btn_Mnu_EditarTipo.ImageAlt = CType(resources.GetObject("Btn_Mnu_EditarTipo.ImageAlt"), System.Drawing.Image)
        Me.Btn_Mnu_EditarTipo.Name = "Btn_Mnu_EditarTipo"
        Me.Btn_Mnu_EditarTipo.Text = "Editar tipo de requerimiento"
        '
        'Btn_Mnu_EliminarTipo
        '
        Me.Btn_Mnu_EliminarTipo.Image = CType(resources.GetObject("Btn_Mnu_EliminarTipo.Image"), System.Drawing.Image)
        Me.Btn_Mnu_EliminarTipo.ImageAlt = CType(resources.GetObject("Btn_Mnu_EliminarTipo.ImageAlt"), System.Drawing.Image)
        Me.Btn_Mnu_EliminarTipo.Name = "Btn_Mnu_EliminarTipo"
        Me.Btn_Mnu_EliminarTipo.Text = "Eliminar tipo de requerimiento"
        '
        'Grilla_Tipos
        '
        Me.Grilla_Tipos.AllowUserToAddRows = False
        Me.Grilla_Tipos.AllowUserToDeleteRows = False
        Me.Grilla_Tipos.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla_Tipos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.Grilla_Tipos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Grilla_Tipos.DefaultCellStyle = DataGridViewCellStyle2
        Me.Grilla_Tipos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grilla_Tipos.EnableHeadersVisualStyles = False
        Me.Grilla_Tipos.GridColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.Grilla_Tipos.Location = New System.Drawing.Point(0, 0)
        Me.Grilla_Tipos.MultiSelect = False
        Me.Grilla_Tipos.Name = "Grilla_Tipos"
        Me.Grilla_Tipos.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla_Tipos.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.Grilla_Tipos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.Grilla_Tipos.Size = New System.Drawing.Size(510, 366)
        Me.Grilla_Tipos.TabIndex = 1
        '
        'Bar2
        '
        Me.Bar2.AntiAlias = True
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_CrearTipo, Me.Btn_ExportarExcel})
        Me.Bar2.Location = New System.Drawing.Point(0, 447)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(538, 41)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Bar2.TabIndex = 119
        Me.Bar2.TabStop = False
        Me.Bar2.Text = "Bar2"
        '
        'Btn_CrearTipo
        '
        Me.Btn_CrearTipo.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_CrearTipo.ForeColor = System.Drawing.Color.Black
        Me.Btn_CrearTipo.Image = CType(resources.GetObject("Btn_CrearTipo.Image"), System.Drawing.Image)
        Me.Btn_CrearTipo.ImageAlt = CType(resources.GetObject("Btn_CrearTipo.ImageAlt"), System.Drawing.Image)
        Me.Btn_CrearTipo.Name = "Btn_CrearTipo"
        Me.Btn_CrearTipo.Tooltip = "Crear nuevo tipo de requerimiento"
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
        'Lbl_Area
        '
        Me.Lbl_Area.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_Area.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Area.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Area.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Area.Location = New System.Drawing.Point(10, 12)
        Me.Lbl_Area.Name = "Lbl_Area"
        Me.Lbl_Area.Size = New System.Drawing.Size(516, 23)
        Me.Lbl_Area.TabIndex = 120
        Me.Lbl_Area.Text = "AREA: XXXXXXXXXXWWWWWWWWWYYYYYYYYSSSSSSSS"
        '
        'Frm_Tickets_Tipos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(538, 488)
        Me.Controls.Add(Me.Lbl_Area)
        Me.Controls.Add(Me.Bar2)
        Me.Controls.Add(Me.GroupPanel1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Tickets_Tipos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TIPOS DE REQUERIMIENTO"
        Me.GroupPanel1.ResumeLayout(False)
        CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Grilla_Tipos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents ContextMenuBar1 As DevComponents.DotNetBar.ContextMenuBar
    Friend WithEvents Menu_Contextual_01 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Mnu_EditarTipo As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Mnu_EliminarTipo As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Grilla_Tipos As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents Btn_CrearTipo As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_ExportarExcel As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Lbl_Area As DevComponents.DotNetBar.LabelX
End Class
