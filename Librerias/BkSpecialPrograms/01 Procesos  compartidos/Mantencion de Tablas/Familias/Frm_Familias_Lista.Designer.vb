<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Familias_Lista
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Familias_Lista))
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.GroupPanel2 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.ContextMenuBar1 = New DevComponents.DotNetBar.ContextMenuBar()
        Me.Menu_Contextual_Super_Familia = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Edit_Super_Familia = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Elim_Super_Familia = New DevComponents.DotNetBar.ButtonItem()
        Me.Menu_Contextual_Familia = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Edit_Familia = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Elim_Familia = New DevComponents.DotNetBar.ButtonItem()
        Me.Menu_Contextual_Sub_Familia = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Edit_SubFamilia = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Elim_SubFamilia = New DevComponents.DotNetBar.ButtonItem()
        Me.Grilla = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_Descripcion = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Aceptar = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Exportar_Excel = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Crear = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Sincronizar = New DevComponents.DotNetBar.ButtonItem()
        Me.Lbl_Encabezado = New DevComponents.DotNetBar.LabelX()
        Me.WarningBox = New DevComponents.DotNetBar.Controls.WarningBox()
        Me.GroupPanel2.SuspendLayout()
        CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel1.SuspendLayout()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupPanel2
        '
        Me.GroupPanel2.BackColor = System.Drawing.Color.White
        Me.GroupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel2.Controls.Add(Me.ContextMenuBar1)
        Me.GroupPanel2.Controls.Add(Me.Grilla)
        Me.GroupPanel2.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel2.Location = New System.Drawing.Point(8, 93)
        Me.GroupPanel2.Name = "GroupPanel2"
        Me.GroupPanel2.Size = New System.Drawing.Size(570, 386)
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
        Me.GroupPanel2.TabIndex = 22
        Me.GroupPanel2.Text = "Detalle"
        '
        'ContextMenuBar1
        '
        Me.ContextMenuBar1.AntiAlias = True
        Me.ContextMenuBar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ContextMenuBar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Menu_Contextual_Super_Familia, Me.Menu_Contextual_Familia, Me.Menu_Contextual_Sub_Familia})
        Me.ContextMenuBar1.Location = New System.Drawing.Point(110, 58)
        Me.ContextMenuBar1.Name = "ContextMenuBar1"
        Me.ContextMenuBar1.Size = New System.Drawing.Size(334, 25)
        Me.ContextMenuBar1.Stretch = True
        Me.ContextMenuBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ContextMenuBar1.TabIndex = 48
        Me.ContextMenuBar1.TabStop = False
        Me.ContextMenuBar1.Text = "ContextMenuBar1"
        '
        'Menu_Contextual_Super_Familia
        '
        Me.Menu_Contextual_Super_Familia.AutoExpandOnClick = True
        Me.Menu_Contextual_Super_Familia.Name = "Menu_Contextual_Super_Familia"
        Me.Menu_Contextual_Super_Familia.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Edit_Super_Familia, Me.Btn_Elim_Super_Familia})
        Me.Menu_Contextual_Super_Familia.Text = "Super Familias"
        '
        'Btn_Edit_Super_Familia
        '
        Me.Btn_Edit_Super_Familia.Image = CType(resources.GetObject("Btn_Edit_Super_Familia.Image"), System.Drawing.Image)
        Me.Btn_Edit_Super_Familia.Name = "Btn_Edit_Super_Familia"
        Me.Btn_Edit_Super_Familia.Text = "Editar nombre de Super Familia"
        '
        'Btn_Elim_Super_Familia
        '
        Me.Btn_Elim_Super_Familia.Image = CType(resources.GetObject("Btn_Elim_Super_Familia.Image"), System.Drawing.Image)
        Me.Btn_Elim_Super_Familia.Name = "Btn_Elim_Super_Familia"
        Me.Btn_Elim_Super_Familia.Text = "Eliminar Super Familia"
        '
        'Menu_Contextual_Familia
        '
        Me.Menu_Contextual_Familia.AutoExpandOnClick = True
        Me.Menu_Contextual_Familia.Name = "Menu_Contextual_Familia"
        Me.Menu_Contextual_Familia.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Edit_Familia, Me.Btn_Elim_Familia})
        Me.Menu_Contextual_Familia.Text = "Familias"
        '
        'Btn_Edit_Familia
        '
        Me.Btn_Edit_Familia.Image = CType(resources.GetObject("Btn_Edit_Familia.Image"), System.Drawing.Image)
        Me.Btn_Edit_Familia.Name = "Btn_Edit_Familia"
        Me.Btn_Edit_Familia.Text = "Editar nombre de la Familia"
        '
        'Btn_Elim_Familia
        '
        Me.Btn_Elim_Familia.Image = CType(resources.GetObject("Btn_Elim_Familia.Image"), System.Drawing.Image)
        Me.Btn_Elim_Familia.Name = "Btn_Elim_Familia"
        Me.Btn_Elim_Familia.Text = "Eliminar la Familia"
        '
        'Menu_Contextual_Sub_Familia
        '
        Me.Menu_Contextual_Sub_Familia.AutoExpandOnClick = True
        Me.Menu_Contextual_Sub_Familia.Name = "Menu_Contextual_Sub_Familia"
        Me.Menu_Contextual_Sub_Familia.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Edit_SubFamilia, Me.Btn_Elim_SubFamilia})
        Me.Menu_Contextual_Sub_Familia.Text = "Sub Familias"
        '
        'Btn_Edit_SubFamilia
        '
        Me.Btn_Edit_SubFamilia.Image = CType(resources.GetObject("Btn_Edit_SubFamilia.Image"), System.Drawing.Image)
        Me.Btn_Edit_SubFamilia.Name = "Btn_Edit_SubFamilia"
        Me.Btn_Edit_SubFamilia.Text = "Editar nombre de la Sub-Familia"
        '
        'Btn_Elim_SubFamilia
        '
        Me.Btn_Elim_SubFamilia.Image = CType(resources.GetObject("Btn_Elim_SubFamilia.Image"), System.Drawing.Image)
        Me.Btn_Elim_SubFamilia.Name = "Btn_Elim_SubFamilia"
        Me.Btn_Elim_SubFamilia.Text = "Eliminar la Sub-Familia"
        '
        'Grilla
        '
        Me.Grilla.AllowUserToAddRows = False
        Me.Grilla.AllowUserToDeleteRows = False
        Me.Grilla.BackgroundColor = System.Drawing.Color.White
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
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.White
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
        Me.Grilla.Name = "Grilla"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.Grilla.Size = New System.Drawing.Size(564, 363)
        Me.Grilla.StandardTab = True
        Me.Grilla.TabIndex = 29
        '
        'GroupPanel1
        '
        Me.GroupPanel1.BackColor = System.Drawing.Color.White
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.LabelX2)
        Me.GroupPanel1.Controls.Add(Me.Txt_Descripcion)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Location = New System.Drawing.Point(8, 33)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(570, 54)
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
        Me.GroupPanel1.TabIndex = 21
        Me.GroupPanel1.Text = "Buscar"
        '
        'LabelX2
        '
        Me.LabelX2.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.ForeColor = System.Drawing.Color.Black
        Me.LabelX2.Location = New System.Drawing.Point(4, 0)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(68, 23)
        Me.LabelX2.TabIndex = 13
        Me.LabelX2.Text = "Descripción"
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
        Me.Txt_Descripcion.ForeColor = System.Drawing.Color.Black
        Me.Txt_Descripcion.Location = New System.Drawing.Point(78, 3)
        Me.Txt_Descripcion.Name = "Txt_Descripcion"
        Me.Txt_Descripcion.PreventEnterBeep = True
        Me.Txt_Descripcion.Size = New System.Drawing.Size(483, 22)
        Me.Txt_Descripcion.TabIndex = 2
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Aceptar, Me.Btn_Exportar_Excel, Me.Btn_Crear, Me.Btn_Sincronizar})
        Me.Bar1.Location = New System.Drawing.Point(0, 534)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(585, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 20
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'Btn_Aceptar
        '
        Me.Btn_Aceptar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Aceptar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Aceptar.Image = CType(resources.GetObject("Btn_Aceptar.Image"), System.Drawing.Image)
        Me.Btn_Aceptar.ImageAlt = CType(resources.GetObject("Btn_Aceptar.ImageAlt"), System.Drawing.Image)
        Me.Btn_Aceptar.Name = "Btn_Aceptar"
        Me.Btn_Aceptar.Text = "Aceptar"
        '
        'Btn_Exportar_Excel
        '
        Me.Btn_Exportar_Excel.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Exportar_Excel.ForeColor = System.Drawing.Color.Black
        Me.Btn_Exportar_Excel.Image = CType(resources.GetObject("Btn_Exportar_Excel.Image"), System.Drawing.Image)
        Me.Btn_Exportar_Excel.ImageAlt = CType(resources.GetObject("Btn_Exportar_Excel.ImageAlt"), System.Drawing.Image)
        Me.Btn_Exportar_Excel.Name = "Btn_Exportar_Excel"
        Me.Btn_Exportar_Excel.Tooltip = "Exportar a Excel"
        '
        'Btn_Crear
        '
        Me.Btn_Crear.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Crear.ForeColor = System.Drawing.Color.Black
        Me.Btn_Crear.Image = CType(resources.GetObject("Btn_Crear.Image"), System.Drawing.Image)
        Me.Btn_Crear.ImageAlt = CType(resources.GetObject("Btn_Crear.ImageAlt"), System.Drawing.Image)
        Me.Btn_Crear.Name = "Btn_Crear"
        Me.Btn_Crear.Text = "Aceptar"
        '
        'Btn_Sincronizar
        '
        Me.Btn_Sincronizar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Sincronizar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Sincronizar.Image = CType(resources.GetObject("Btn_Sincronizar.Image"), System.Drawing.Image)
        Me.Btn_Sincronizar.ImageAlt = CType(resources.GetObject("Btn_Sincronizar.ImageAlt"), System.Drawing.Image)
        Me.Btn_Sincronizar.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.Btn_Sincronizar.Name = "Btn_Sincronizar"
        Me.Btn_Sincronizar.Text = "Sincronizar BDExt."
        Me.Btn_Sincronizar.Tooltip = "Sincronizar tablas de familias con bases de datos externas"
        '
        'Lbl_Encabezado
        '
        Me.Lbl_Encabezado.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_Encabezado.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Encabezado.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Encabezado.Location = New System.Drawing.Point(8, 4)
        Me.Lbl_Encabezado.Name = "Lbl_Encabezado"
        Me.Lbl_Encabezado.Size = New System.Drawing.Size(570, 23)
        Me.Lbl_Encabezado.TabIndex = 24
        Me.Lbl_Encabezado.Text = "Descripción"
        '
        'WarningBox
        '
        Me.WarningBox.BackColor = System.Drawing.Color.White
        Me.WarningBox.CloseButtonVisible = False
        Me.WarningBox.ForeColor = System.Drawing.Color.Black
        Me.WarningBox.Image = CType(resources.GetObject("WarningBox.Image"), System.Drawing.Image)
        Me.WarningBox.Location = New System.Drawing.Point(8, 482)
        Me.WarningBox.Name = "WarningBox"
        Me.WarningBox.OptionsText = "Información..."
        Me.WarningBox.Size = New System.Drawing.Size(570, 33)
        Me.WarningBox.TabIndex = 25
        Me.WarningBox.Text = "<b>Atención: </b>Esta tabla esta bloqueada desde la configuración general"
        Me.WarningBox.Visible = False
        '
        'Frm_Familias_Lista
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(585, 575)
        Me.Controls.Add(Me.WarningBox)
        Me.Controls.Add(Me.Lbl_Encabezado)
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
        Me.Name = "Frm_Familias_Lista"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MetroForm"
        Me.GroupPanel2.ResumeLayout(False)
        CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel1.ResumeLayout(False)
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupPanel2 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents ContextMenuBar1 As DevComponents.DotNetBar.ContextMenuBar
    Friend WithEvents Menu_Contextual_Super_Familia As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Edit_Super_Familia As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Elim_Super_Familia As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Edit_Familia As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Elim_Familia As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Edit_SubFamilia As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Elim_SubFamilia As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Grilla As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Public WithEvents Txt_Descripcion As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents Btn_Crear As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Exportar_Excel As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Lbl_Encabezado As DevComponents.DotNetBar.LabelX
    Friend WithEvents Menu_Contextual_Familia As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Menu_Contextual_Sub_Familia As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Sincronizar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents WarningBox As DevComponents.DotNetBar.Controls.WarningBox
    Friend WithEvents Btn_Aceptar As DevComponents.DotNetBar.ButtonItem
End Class
