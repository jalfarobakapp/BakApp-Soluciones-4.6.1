<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Frm_Rc_Configuracion
    Inherits DevComponents.DotNetBar.Metro.MetroForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Rc_Configuracion))
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Bar2 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Correos = New DevComponents.DotNetBar.ButtonItem()
        Me.Cmb_Estados = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.Lbl_Modelo = New DevComponents.DotNetBar.LabelX()
        Me.Cmb_Tipo_Reclamos = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.Btn_Tipo_Reclamos = New DevComponents.DotNetBar.ButtonX()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.Btn_Sub_Tipo_Reclamos = New DevComponents.DotNetBar.ButtonX()
        Me.Grilla_Correos = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.LabelX12 = New DevComponents.DotNetBar.LabelX()
        Me.ContextMenuBar1 = New DevComponents.DotNetBar.ContextMenuBar()
        Me.Menu_Contextual = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Mnu_Correo = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Para = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Mnu_Quitar_Correo = New DevComponents.DotNetBar.ButtonItem()
        Me.Grupo_Tipo = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.GroupPanel2 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Btn_Preguntas = New DevComponents.DotNetBar.ButtonX()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Grilla_Correos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Grupo_Tipo.SuspendLayout()
        Me.GroupPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Bar2
        '
        Me.Bar2.AntiAlias = True
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Correos})
        Me.Bar2.Location = New System.Drawing.Point(0, 313)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(477, 41)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Bar2.TabIndex = 102
        Me.Bar2.TabStop = False
        Me.Bar2.Text = "Bar2"
        '
        'Btn_Correos
        '
        Me.Btn_Correos.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Correos.ForeColor = System.Drawing.Color.Black
        Me.Btn_Correos.Image = CType(resources.GetObject("Btn_Correos.Image"), System.Drawing.Image)
        Me.Btn_Correos.Name = "Btn_Correos"
        Me.Btn_Correos.Text = "Conf. correos"
        Me.Btn_Correos.Tooltip = "Mantención de correos de salida SMTP del sistema"
        '
        'Cmb_Estados
        '
        Me.Cmb_Estados.DisplayMember = "Text"
        Me.Cmb_Estados.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.Cmb_Estados.ForeColor = System.Drawing.Color.Black
        Me.Cmb_Estados.FormattingEnabled = True
        Me.Cmb_Estados.ItemHeight = 16
        Me.Cmb_Estados.Location = New System.Drawing.Point(86, 11)
        Me.Cmb_Estados.Name = "Cmb_Estados"
        Me.Cmb_Estados.Size = New System.Drawing.Size(365, 22)
        Me.Cmb_Estados.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Cmb_Estados.TabIndex = 109
        '
        'Lbl_Modelo
        '
        Me.Lbl_Modelo.AutoSize = True
        Me.Lbl_Modelo.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_Modelo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Modelo.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Modelo.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Modelo.Location = New System.Drawing.Point(3, 13)
        Me.Lbl_Modelo.Name = "Lbl_Modelo"
        Me.Lbl_Modelo.Size = New System.Drawing.Size(46, 20)
        Me.Lbl_Modelo.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Lbl_Modelo.TabIndex = 107
        Me.Lbl_Modelo.Text = "Estados"
        '
        'Cmb_Tipo_Reclamos
        '
        Me.Cmb_Tipo_Reclamos.DisplayMember = "Text"
        Me.Cmb_Tipo_Reclamos.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.Cmb_Tipo_Reclamos.ForeColor = System.Drawing.Color.Black
        Me.Cmb_Tipo_Reclamos.FormattingEnabled = True
        Me.Cmb_Tipo_Reclamos.ItemHeight = 16
        Me.Cmb_Tipo_Reclamos.Location = New System.Drawing.Point(86, 16)
        Me.Cmb_Tipo_Reclamos.Name = "Cmb_Tipo_Reclamos"
        Me.Cmb_Tipo_Reclamos.Size = New System.Drawing.Size(331, 22)
        Me.Cmb_Tipo_Reclamos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Cmb_Tipo_Reclamos.TabIndex = 118
        '
        'Btn_Tipo_Reclamos
        '
        Me.Btn_Tipo_Reclamos.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Tipo_Reclamos.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Tipo_Reclamos.Image = CType(resources.GetObject("Btn_Tipo_Reclamos.Image"), System.Drawing.Image)
        Me.Btn_Tipo_Reclamos.Location = New System.Drawing.Point(423, 18)
        Me.Btn_Tipo_Reclamos.Name = "Btn_Tipo_Reclamos"
        Me.Btn_Tipo_Reclamos.Size = New System.Drawing.Size(28, 22)
        Me.Btn_Tipo_Reclamos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Tipo_Reclamos.TabIndex = 117
        Me.Btn_Tipo_Reclamos.Tooltip = "Mantención de tabla de modelos de marcas de vehículos"
        '
        'LabelX3
        '
        Me.LabelX3.AutoSize = True
        Me.LabelX3.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX3.ForeColor = System.Drawing.Color.Black
        Me.LabelX3.Location = New System.Drawing.Point(3, 18)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(77, 20)
        Me.LabelX3.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.LabelX3.TabIndex = 116
        Me.LabelX3.Text = "Tipo reclamo"
        '
        'Btn_Sub_Tipo_Reclamos
        '
        Me.Btn_Sub_Tipo_Reclamos.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Sub_Tipo_Reclamos.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Sub_Tipo_Reclamos.Image = CType(resources.GetObject("Btn_Sub_Tipo_Reclamos.Image"), System.Drawing.Image)
        Me.Btn_Sub_Tipo_Reclamos.Location = New System.Drawing.Point(86, 44)
        Me.Btn_Sub_Tipo_Reclamos.Name = "Btn_Sub_Tipo_Reclamos"
        Me.Btn_Sub_Tipo_Reclamos.Size = New System.Drawing.Size(155, 22)
        Me.Btn_Sub_Tipo_Reclamos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Sub_Tipo_Reclamos.TabIndex = 120
        Me.Btn_Sub_Tipo_Reclamos.Text = "Sub-tipos de reclamos"
        Me.Btn_Sub_Tipo_Reclamos.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Left
        '
        'Grilla_Correos
        '
        Me.Grilla_Correos.AllowUserToAddRows = False
        Me.Grilla_Correos.AllowUserToDeleteRows = False
        Me.Grilla_Correos.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla_Correos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.Grilla_Correos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Grilla_Correos.DefaultCellStyle = DataGridViewCellStyle5
        Me.Grilla_Correos.EnableHeadersVisualStyles = False
        Me.Grilla_Correos.GridColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.Grilla_Correos.Location = New System.Drawing.Point(3, 62)
        Me.Grilla_Correos.Name = "Grilla_Correos"
        Me.Grilla_Correos.ReadOnly = True
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla_Correos.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.Grilla_Correos.RowHeadersVisible = False
        Me.Grilla_Correos.RowTemplate.Height = 25
        Me.Grilla_Correos.Size = New System.Drawing.Size(448, 80)
        Me.Grilla_Correos.TabIndex = 122
        '
        'LabelX12
        '
        Me.LabelX12.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX12.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX12.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX12.ForeColor = System.Drawing.Color.Black
        Me.LabelX12.Location = New System.Drawing.Point(3, 33)
        Me.LabelX12.Name = "LabelX12"
        Me.LabelX12.Size = New System.Drawing.Size(427, 23)
        Me.LabelX12.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.LabelX12.TabIndex = 123
        Me.LabelX12.Text = "Combinación de envio de correos automaticos, despues de cada acción"
        '
        'ContextMenuBar1
        '
        Me.ContextMenuBar1.AntiAlias = True
        Me.ContextMenuBar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ContextMenuBar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Menu_Contextual})
        Me.ContextMenuBar1.Location = New System.Drawing.Point(246, 90)
        Me.ContextMenuBar1.Name = "ContextMenuBar1"
        Me.ContextMenuBar1.Size = New System.Drawing.Size(130, 25)
        Me.ContextMenuBar1.Stretch = True
        Me.ContextMenuBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ContextMenuBar1.TabIndex = 124
        Me.ContextMenuBar1.TabStop = False
        Me.ContextMenuBar1.Text = "ContextMenuBar1"
        '
        'Menu_Contextual
        '
        Me.Menu_Contextual.AutoExpandOnClick = True
        Me.Menu_Contextual.Name = "Menu_Contextual"
        Me.Menu_Contextual.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Mnu_Correo, Me.Btn_Para, Me.Btn_Mnu_Quitar_Correo})
        Me.Menu_Contextual.Text = "Opciones"
        '
        'Btn_Mnu_Correo
        '
        Me.Btn_Mnu_Correo.Image = CType(resources.GetObject("Btn_Mnu_Correo.Image"), System.Drawing.Image)
        Me.Btn_Mnu_Correo.Name = "Btn_Mnu_Correo"
        Me.Btn_Mnu_Correo.Text = "Ingresar/editar correo"
        '
        'Btn_Para
        '
        Me.Btn_Para.Image = CType(resources.GetObject("Btn_Para.Image"), System.Drawing.Image)
        Me.Btn_Para.Name = "Btn_Para"
        Me.Btn_Para.Text = "Para:..."
        '
        'Btn_Mnu_Quitar_Correo
        '
        Me.Btn_Mnu_Quitar_Correo.Image = CType(resources.GetObject("Btn_Mnu_Quitar_Correo.Image"), System.Drawing.Image)
        Me.Btn_Mnu_Quitar_Correo.Name = "Btn_Mnu_Quitar_Correo"
        Me.Btn_Mnu_Quitar_Correo.Text = "Quitar correo"
        '
        'Grupo_Tipo
        '
        Me.Grupo_Tipo.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Grupo_Tipo.CanvasColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Grupo_Tipo.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Grupo_Tipo.Controls.Add(Me.Btn_Preguntas)
        Me.Grupo_Tipo.Controls.Add(Me.LabelX3)
        Me.Grupo_Tipo.Controls.Add(Me.Btn_Tipo_Reclamos)
        Me.Grupo_Tipo.Controls.Add(Me.Cmb_Tipo_Reclamos)
        Me.Grupo_Tipo.Controls.Add(Me.Btn_Sub_Tipo_Reclamos)
        Me.Grupo_Tipo.DisabledBackColor = System.Drawing.Color.Empty
        Me.Grupo_Tipo.Location = New System.Drawing.Point(10, 179)
        Me.Grupo_Tipo.Name = "Grupo_Tipo"
        Me.Grupo_Tipo.Size = New System.Drawing.Size(460, 125)
        '
        '
        '
        Me.Grupo_Tipo.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Grupo_Tipo.Style.BackColorGradientAngle = 90
        Me.Grupo_Tipo.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Grupo_Tipo.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Tipo.Style.BorderBottomWidth = 1
        Me.Grupo_Tipo.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.Grupo_Tipo.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Tipo.Style.BorderLeftWidth = 1
        Me.Grupo_Tipo.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Tipo.Style.BorderRightWidth = 1
        Me.Grupo_Tipo.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Tipo.Style.BorderTopWidth = 1
        Me.Grupo_Tipo.Style.CornerDiameter = 4
        Me.Grupo_Tipo.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Grupo_Tipo.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.Grupo_Tipo.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.Grupo_Tipo.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.Grupo_Tipo.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.Grupo_Tipo.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Grupo_Tipo.TabIndex = 125
        Me.Grupo_Tipo.Text = "Tipos de reclamos"
        '
        'GroupPanel2
        '
        Me.GroupPanel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GroupPanel2.CanvasColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GroupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel2.Controls.Add(Me.ContextMenuBar1)
        Me.GroupPanel2.Controls.Add(Me.Lbl_Modelo)
        Me.GroupPanel2.Controls.Add(Me.Grilla_Correos)
        Me.GroupPanel2.Controls.Add(Me.LabelX12)
        Me.GroupPanel2.Controls.Add(Me.Cmb_Estados)
        Me.GroupPanel2.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel2.Location = New System.Drawing.Point(10, 2)
        Me.GroupPanel2.Name = "GroupPanel2"
        Me.GroupPanel2.Size = New System.Drawing.Size(460, 171)
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
        Me.GroupPanel2.TabIndex = 126
        Me.GroupPanel2.Text = "Estados"
        '
        'Btn_Preguntas
        '
        Me.Btn_Preguntas.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Preguntas.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Preguntas.Image = CType(resources.GetObject("Btn_Preguntas.Image"), System.Drawing.Image)
        Me.Btn_Preguntas.Location = New System.Drawing.Point(86, 72)
        Me.Btn_Preguntas.Name = "Btn_Preguntas"
        Me.Btn_Preguntas.Size = New System.Drawing.Size(155, 22)
        Me.Btn_Preguntas.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Preguntas.TabIndex = 123
        Me.Btn_Preguntas.Text = "Preguntas"
        Me.Btn_Preguntas.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Left
        '
        'Frm_Rc_Configuracion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(477, 354)
        Me.Controls.Add(Me.GroupPanel2)
        Me.Controls.Add(Me.Grupo_Tipo)
        Me.Controls.Add(Me.Bar2)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Rc_Configuracion"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Configuración de sistema de reclamos"
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Grilla_Correos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Grupo_Tipo.ResumeLayout(False)
        Me.Grupo_Tipo.PerformLayout()
        Me.GroupPanel2.ResumeLayout(False)
        Me.GroupPanel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents Btn_Correos As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Cmb_Estados As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents Lbl_Modelo As DevComponents.DotNetBar.LabelX
    Friend WithEvents Cmb_Tipo_Reclamos As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents Btn_Tipo_Reclamos As DevComponents.DotNetBar.ButtonX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Btn_Sub_Tipo_Reclamos As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Grilla_Correos As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents LabelX12 As DevComponents.DotNetBar.LabelX
    Friend WithEvents ContextMenuBar1 As DevComponents.DotNetBar.ContextMenuBar
    Friend WithEvents Menu_Contextual As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_Mnu_Correo As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Mnu_Quitar_Correo As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Grupo_Tipo As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents GroupPanel2 As DevComponents.DotNetBar.Controls.GroupPanel
    Public WithEvents Btn_Para As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Preguntas As DevComponents.DotNetBar.ButtonX
End Class
