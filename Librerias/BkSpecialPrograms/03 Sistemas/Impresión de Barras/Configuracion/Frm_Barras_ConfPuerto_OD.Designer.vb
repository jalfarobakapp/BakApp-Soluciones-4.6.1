<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Barras_ConfPuerto_OD
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Barras_ConfPuerto_OD))
        Me.Cmb_Etiqueta = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.BtnGrabar = New DevComponents.DotNetBar.ButtonItem()
        Me.Grupo_Barras = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Cmb_Puerto = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.Rdb_Imp_Laser = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_Imp_Termica = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_Imp_Barras = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.GroupPanel3 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.LabelX22 = New DevComponents.DotNetBar.LabelX()
        Me.Btn_Cambiar_Impresora = New DevComponents.DotNetBar.ButtonX()
        Me.Lbl_Impresora_Predeterminada = New DevComponents.DotNetBar.LabelX()
        Me.Line1 = New DevComponents.DotNetBar.Controls.Line()
        Me.ReflectionImage2 = New DevComponents.DotNetBar.Controls.ReflectionImage()
        Me.Chk_Imprimir_Automaticamente = New DevComponents.DotNetBar.Controls.CheckBoxX()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Grupo_Barras.SuspendLayout()
        Me.GroupPanel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Cmb_Etiqueta
        '
        Me.Cmb_Etiqueta.DisplayMember = "Text"
        Me.Cmb_Etiqueta.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.Cmb_Etiqueta.ForeColor = System.Drawing.Color.Black
        Me.Cmb_Etiqueta.FormattingEnabled = True
        Me.Cmb_Etiqueta.ItemHeight = 16
        Me.Cmb_Etiqueta.Location = New System.Drawing.Point(172, 25)
        Me.Cmb_Etiqueta.Name = "Cmb_Etiqueta"
        Me.Cmb_Etiqueta.Size = New System.Drawing.Size(291, 22)
        Me.Cmb_Etiqueta.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Cmb_Etiqueta.TabIndex = 0
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.BtnGrabar})
        Me.Bar1.Location = New System.Drawing.Point(0, 303)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(490, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 43
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'BtnGrabar
        '
        Me.BtnGrabar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnGrabar.ForeColor = System.Drawing.Color.Black
        Me.BtnGrabar.Image = CType(resources.GetObject("BtnGrabar.Image"), System.Drawing.Image)
        Me.BtnGrabar.ImageAlt = CType(resources.GetObject("BtnGrabar.ImageAlt"), System.Drawing.Image)
        Me.BtnGrabar.Name = "BtnGrabar"
        Me.BtnGrabar.Tooltip = "Grabar"
        '
        'Grupo_Barras
        '
        Me.Grupo_Barras.BackColor = System.Drawing.Color.White
        Me.Grupo_Barras.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Grupo_Barras.Controls.Add(Me.Cmb_Etiqueta)
        Me.Grupo_Barras.Controls.Add(Me.Cmb_Puerto)
        Me.Grupo_Barras.Controls.Add(Me.LabelX1)
        Me.Grupo_Barras.Controls.Add(Me.LabelX2)
        Me.Grupo_Barras.DisabledBackColor = System.Drawing.Color.Empty
        Me.Grupo_Barras.Location = New System.Drawing.Point(12, 170)
        Me.Grupo_Barras.Name = "Grupo_Barras"
        Me.Grupo_Barras.Size = New System.Drawing.Size(472, 76)
        '
        '
        '
        Me.Grupo_Barras.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Grupo_Barras.Style.BackColorGradientAngle = 90
        Me.Grupo_Barras.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Grupo_Barras.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Barras.Style.BorderBottomWidth = 1
        Me.Grupo_Barras.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.Grupo_Barras.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Barras.Style.BorderLeftWidth = 1
        Me.Grupo_Barras.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Barras.Style.BorderRightWidth = 1
        Me.Grupo_Barras.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Barras.Style.BorderTopWidth = 1
        Me.Grupo_Barras.Style.CornerDiameter = 4
        Me.Grupo_Barras.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Grupo_Barras.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.Grupo_Barras.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.Grupo_Barras.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.Grupo_Barras.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.Grupo_Barras.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Grupo_Barras.TabIndex = 42
        Me.Grupo_Barras.Text = "Configuración impresión de barras"
        '
        'Cmb_Puerto
        '
        Me.Cmb_Puerto.DisplayMember = "Text"
        Me.Cmb_Puerto.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.Cmb_Puerto.ForeColor = System.Drawing.Color.Black
        Me.Cmb_Puerto.FormattingEnabled = True
        Me.Cmb_Puerto.ItemHeight = 16
        Me.Cmb_Puerto.Location = New System.Drawing.Point(3, 26)
        Me.Cmb_Puerto.Name = "Cmb_Puerto"
        Me.Cmb_Puerto.Size = New System.Drawing.Size(146, 22)
        Me.Cmb_Puerto.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Cmb_Puerto.TabIndex = 0
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.ForeColor = System.Drawing.Color.Black
        Me.LabelX1.Location = New System.Drawing.Point(3, 3)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(75, 23)
        Me.LabelX1.TabIndex = 1
        Me.LabelX1.Text = "Puerto"
        '
        'LabelX2
        '
        Me.LabelX2.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.ForeColor = System.Drawing.Color.Black
        Me.LabelX2.Location = New System.Drawing.Point(172, 3)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(75, 23)
        Me.LabelX2.TabIndex = 2
        Me.LabelX2.Text = "Etiqueta"
        '
        'Rdb_Imp_Laser
        '
        Me.Rdb_Imp_Laser.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Imp_Laser.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Imp_Laser.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Imp_Laser.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Imp_Laser.Location = New System.Drawing.Point(3, 13)
        Me.Rdb_Imp_Laser.Name = "Rdb_Imp_Laser"
        Me.Rdb_Imp_Laser.Size = New System.Drawing.Size(352, 23)
        Me.Rdb_Imp_Laser.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Imp_Laser.TabIndex = 0
        Me.Rdb_Imp_Laser.Text = "Imprimir en impresora laser (tamaño carta)"
        '
        'Rdb_Imp_Termica
        '
        Me.Rdb_Imp_Termica.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Imp_Termica.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Imp_Termica.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Imp_Termica.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Imp_Termica.Location = New System.Drawing.Point(3, 34)
        Me.Rdb_Imp_Termica.Name = "Rdb_Imp_Termica"
        Me.Rdb_Imp_Termica.Size = New System.Drawing.Size(352, 23)
        Me.Rdb_Imp_Termica.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Imp_Termica.TabIndex = 1
        Me.Rdb_Imp_Termica.Text = "Imprimir en impresora termica (tipo vale)"
        '
        'Rdb_Imp_Barras
        '
        Me.Rdb_Imp_Barras.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Imp_Barras.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Imp_Barras.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Imp_Barras.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Imp_Barras.Location = New System.Drawing.Point(3, 104)
        Me.Rdb_Imp_Barras.Name = "Rdb_Imp_Barras"
        Me.Rdb_Imp_Barras.Size = New System.Drawing.Size(393, 23)
        Me.Rdb_Imp_Barras.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Imp_Barras.TabIndex = 2
        Me.Rdb_Imp_Barras.Text = "Imprimir en impresora de barras (termica)"
        '
        'GroupPanel3
        '
        Me.GroupPanel3.BackColor = System.Drawing.Color.White
        Me.GroupPanel3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel3.Controls.Add(Me.LabelX22)
        Me.GroupPanel3.Controls.Add(Me.Btn_Cambiar_Impresora)
        Me.GroupPanel3.Controls.Add(Me.Lbl_Impresora_Predeterminada)
        Me.GroupPanel3.Controls.Add(Me.Rdb_Imp_Barras)
        Me.GroupPanel3.Controls.Add(Me.Rdb_Imp_Termica)
        Me.GroupPanel3.Controls.Add(Me.Rdb_Imp_Laser)
        Me.GroupPanel3.Controls.Add(Me.Line1)
        Me.GroupPanel3.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel3.Location = New System.Drawing.Point(12, 12)
        Me.GroupPanel3.Name = "GroupPanel3"
        Me.GroupPanel3.Size = New System.Drawing.Size(364, 152)
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
        Me.GroupPanel3.TabIndex = 45
        Me.GroupPanel3.Text = "Etiqueta por defecto"
        '
        'LabelX22
        '
        Me.LabelX22.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX22.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX22.ForeColor = System.Drawing.Color.Black
        Me.LabelX22.Location = New System.Drawing.Point(3, 63)
        Me.LabelX22.Name = "LabelX22"
        Me.LabelX22.Size = New System.Drawing.Size(134, 22)
        Me.LabelX22.TabIndex = 49
        Me.LabelX22.Text = "Impresora predeterminada:"
        '
        'Btn_Cambiar_Impresora
        '
        Me.Btn_Cambiar_Impresora.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Cambiar_Impresora.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Cambiar_Impresora.Image = CType(resources.GetObject("Btn_Cambiar_Impresora.Image"), System.Drawing.Image)
        Me.Btn_Cambiar_Impresora.Location = New System.Drawing.Point(305, 63)
        Me.Btn_Cambiar_Impresora.Name = "Btn_Cambiar_Impresora"
        Me.Btn_Cambiar_Impresora.Size = New System.Drawing.Size(44, 22)
        Me.Btn_Cambiar_Impresora.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Cambiar_Impresora.TabIndex = 48
        Me.Btn_Cambiar_Impresora.TabStop = False
        Me.Btn_Cambiar_Impresora.Tooltip = "Buscar impresora predeterminada"
        '
        'Lbl_Impresora_Predeterminada
        '
        Me.Lbl_Impresora_Predeterminada.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_Impresora_Predeterminada.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Impresora_Predeterminada.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Impresora_Predeterminada.Location = New System.Drawing.Point(143, 63)
        Me.Lbl_Impresora_Predeterminada.Name = "Lbl_Impresora_Predeterminada"
        Me.Lbl_Impresora_Predeterminada.Size = New System.Drawing.Size(156, 22)
        Me.Lbl_Impresora_Predeterminada.TabIndex = 50
        Me.Lbl_Impresora_Predeterminada.Text = "Impresora Voucher"
        '
        'Line1
        '
        Me.Line1.BackColor = System.Drawing.Color.Transparent
        Me.Line1.ForeColor = System.Drawing.Color.Black
        Me.Line1.Location = New System.Drawing.Point(3, 86)
        Me.Line1.Name = "Line1"
        Me.Line1.Size = New System.Drawing.Size(352, 14)
        Me.Line1.TabIndex = 68
        Me.Line1.Text = "Line1"
        '
        'ReflectionImage2
        '
        Me.ReflectionImage2.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.ReflectionImage2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ReflectionImage2.BackgroundStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.ReflectionImage2.ForeColor = System.Drawing.Color.Black
        Me.ReflectionImage2.Image = CType(resources.GetObject("ReflectionImage2.Image"), System.Drawing.Image)
        Me.ReflectionImage2.Location = New System.Drawing.Point(382, 12)
        Me.ReflectionImage2.Name = "ReflectionImage2"
        Me.ReflectionImage2.Size = New System.Drawing.Size(102, 126)
        Me.ReflectionImage2.TabIndex = 67
        '
        'Chk_Imprimir_Automaticamente
        '
        Me.Chk_Imprimir_Automaticamente.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_Imprimir_Automaticamente.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Imprimir_Automaticamente.ForeColor = System.Drawing.Color.Black
        Me.Chk_Imprimir_Automaticamente.Location = New System.Drawing.Point(12, 257)
        Me.Chk_Imprimir_Automaticamente.Name = "Chk_Imprimir_Automaticamente"
        Me.Chk_Imprimir_Automaticamente.Size = New System.Drawing.Size(407, 40)
        Me.Chk_Imprimir_Automaticamente.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Imprimir_Automaticamente.TabIndex = 0
        Me.Chk_Imprimir_Automaticamente.Text = "<b>   Imprimir automáticamente con esta configuración</b><br/>      <i> (si no es" &
    "ta tickeado pregunta siempre antes de imprimir)</i>"
        '
        'Frm_Barras_ConfPuerto_OD
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(490, 344)
        Me.Controls.Add(Me.Chk_Imprimir_Automaticamente)
        Me.Controls.Add(Me.ReflectionImage2)
        Me.Controls.Add(Me.GroupPanel3)
        Me.Controls.Add(Me.Bar1)
        Me.Controls.Add(Me.Grupo_Barras)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Barras_ConfPuerto_OD"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CONFIGURACION DE IMPRESION DE LETREROS DE ORDENES DE DESPACHO"
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Grupo_Barras.ResumeLayout(False)
        Me.GroupPanel3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Cmb_Etiqueta As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Public WithEvents BtnGrabar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Grupo_Barras As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Cmb_Puerto As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Rdb_Imp_Laser As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_Imp_Termica As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_Imp_Barras As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents GroupPanel3 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents ReflectionImage2 As DevComponents.DotNetBar.Controls.ReflectionImage
    Friend WithEvents Chk_Imprimir_Automaticamente As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents LabelX22 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Btn_Cambiar_Impresora As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Lbl_Impresora_Predeterminada As DevComponents.DotNetBar.LabelX
    Friend WithEvents Line1 As DevComponents.DotNetBar.Controls.Line
End Class
