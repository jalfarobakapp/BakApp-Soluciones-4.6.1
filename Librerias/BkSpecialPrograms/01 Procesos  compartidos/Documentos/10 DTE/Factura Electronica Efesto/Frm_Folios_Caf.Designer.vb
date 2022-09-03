<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Frm_Folios_Caf
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Folios_Caf))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.ContextMenuBar1 = New DevComponents.DotNetBar.ContextMenuBar()
        Me.Menu_Contextual_Operadores = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Editar = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Plan = New DevComponents.DotNetBar.ButtonItem()
        Me.Grilla_Parejas = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Subir_Folios = New DevComponents.DotNetBar.ButtonItem()
        Me.Cmb_TipoDoc = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.MStb_Barra = New DevComponents.DotNetBar.Metro.MetroStatusBar()
        Me.Lbl_Etiqueta = New DevComponents.DotNetBar.LabelItem()
        Me.GroupPanel1.SuspendLayout()
        CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Grilla_Parejas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupPanel1
        '
        Me.GroupPanel1.BackColor = System.Drawing.Color.White
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.ContextMenuBar1)
        Me.GroupPanel1.Controls.Add(Me.Grilla_Parejas)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        resources.ApplyResources(Me.GroupPanel1, "GroupPanel1")
        Me.GroupPanel1.Name = "GroupPanel1"
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
        '
        'ContextMenuBar1
        '
        Me.ContextMenuBar1.AntiAlias = True
        resources.ApplyResources(Me.ContextMenuBar1, "ContextMenuBar1")
        Me.ContextMenuBar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Menu_Contextual_Operadores})
        Me.ContextMenuBar1.Name = "ContextMenuBar1"
        Me.ContextMenuBar1.Stretch = True
        Me.ContextMenuBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ContextMenuBar1.TabStop = False
        '
        'Menu_Contextual_Operadores
        '
        Me.Menu_Contextual_Operadores.AutoExpandOnClick = True
        Me.Menu_Contextual_Operadores.Name = "Menu_Contextual_Operadores"
        Me.Menu_Contextual_Operadores.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Editar, Me.Btn_Plan})
        resources.ApplyResources(Me.Menu_Contextual_Operadores, "Menu_Contextual_Operadores")
        '
        'Btn_Editar
        '
        Me.Btn_Editar.Image = CType(resources.GetObject("Btn_Editar.Image"), System.Drawing.Image)
        Me.Btn_Editar.Name = "Btn_Editar"
        resources.ApplyResources(Me.Btn_Editar, "Btn_Editar")
        '
        'Btn_Plan
        '
        Me.Btn_Plan.Image = CType(resources.GetObject("Btn_Plan.Image"), System.Drawing.Image)
        Me.Btn_Plan.Name = "Btn_Plan"
        resources.ApplyResources(Me.Btn_Plan, "Btn_Plan")
        '
        'Grilla_Parejas
        '
        Me.Grilla_Parejas.AllowUserToAddRows = False
        Me.Grilla_Parejas.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla_Parejas.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.Grilla_Parejas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Grilla_Parejas.DefaultCellStyle = DataGridViewCellStyle2
        resources.ApplyResources(Me.Grilla_Parejas, "Grilla_Parejas")
        Me.Grilla_Parejas.EnableHeadersVisualStyles = False
        Me.Grilla_Parejas.GridColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.Grilla_Parejas.Name = "Grilla_Parejas"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla_Parejas.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.Grilla_Parejas.StandardTab = True
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        resources.ApplyResources(Me.Bar1, "Bar1")
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Subir_Folios})
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabStop = False
        '
        'Btn_Subir_Folios
        '
        Me.Btn_Subir_Folios.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Subir_Folios.ForeColor = System.Drawing.Color.Black
        Me.Btn_Subir_Folios.Image = CType(resources.GetObject("Btn_Subir_Folios.Image"), System.Drawing.Image)
        Me.Btn_Subir_Folios.ImageAlt = CType(resources.GetObject("Btn_Subir_Folios.ImageAlt"), System.Drawing.Image)
        Me.Btn_Subir_Folios.Name = "Btn_Subir_Folios"
        resources.ApplyResources(Me.Btn_Subir_Folios, "Btn_Subir_Folios")
        '
        'Cmb_TipoDoc
        '
        Me.Cmb_TipoDoc.DisplayMember = "Text"
        Me.Cmb_TipoDoc.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.Cmb_TipoDoc.ForeColor = System.Drawing.Color.Black
        Me.Cmb_TipoDoc.FormattingEnabled = True
        resources.ApplyResources(Me.Cmb_TipoDoc, "Cmb_TipoDoc")
        Me.Cmb_TipoDoc.Name = "Cmb_TipoDoc"
        Me.Cmb_TipoDoc.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.ForeColor = System.Drawing.Color.Black
        resources.ApplyResources(Me.LabelX1, "LabelX1")
        Me.LabelX1.Name = "LabelX1"
        '
        'MStb_Barra
        '
        Me.MStb_Barra.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.MStb_Barra.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.MStb_Barra.ContainerControlProcessDialogKey = True
        resources.ApplyResources(Me.MStb_Barra, "MStb_Barra")
        Me.MStb_Barra.DragDropSupport = True
        Me.MStb_Barra.ForeColor = System.Drawing.Color.Black
        Me.MStb_Barra.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Lbl_Etiqueta})
        Me.MStb_Barra.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.MStb_Barra.Name = "MStb_Barra"
        '
        'Lbl_Etiqueta
        '
        Me.Lbl_Etiqueta.Name = "Lbl_Etiqueta"
        resources.ApplyResources(Me.Lbl_Etiqueta, "Lbl_Etiqueta")
        '
        'Frm_Folios_Caf
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Bar1)
        Me.Controls.Add(Me.Cmb_TipoDoc)
        Me.Controls.Add(Me.LabelX1)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Controls.Add(Me.MStb_Barra)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Folios_Caf"
        Me.ShowInTaskbar = False
        Me.GroupPanel1.ResumeLayout(False)
        CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Grilla_Parejas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents ContextMenuBar1 As DevComponents.DotNetBar.ContextMenuBar
    Friend WithEvents Menu_Contextual_Operadores As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Editar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Plan As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Grilla_Parejas As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents Btn_Subir_Folios As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Cmb_TipoDoc As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents MStb_Barra As DevComponents.DotNetBar.Metro.MetroStatusBar
    Friend WithEvents Lbl_Etiqueta As DevComponents.DotNetBar.LabelItem
End Class
