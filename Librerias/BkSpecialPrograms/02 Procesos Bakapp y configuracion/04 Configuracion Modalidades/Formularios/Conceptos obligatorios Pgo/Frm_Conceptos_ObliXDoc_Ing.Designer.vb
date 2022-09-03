<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Conceptos_ObliXDoc_Ing
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Conceptos_ObliXDoc_Ing))
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Cmb_Vista_Informe = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.Btn_Buscar_Concepto = New DevComponents.DotNetBar.ButtonX()
        Me.Txt_Concepto = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.Btn_Buscar_Tidp = New DevComponents.DotNetBar.ButtonX()
        Me.Txt_Tidp = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.Btn_Buscar_Tido = New DevComponents.DotNetBar.ButtonX()
        Me.Txt_Tido = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Agregar = New DevComponents.DotNetBar.ButtonItem()
        Me.GroupPanel1.SuspendLayout()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupPanel1
        '
        Me.GroupPanel1.BackColor = System.Drawing.Color.White
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.Cmb_Vista_Informe)
        Me.GroupPanel1.Controls.Add(Me.LabelX4)
        Me.GroupPanel1.Controls.Add(Me.Btn_Buscar_Concepto)
        Me.GroupPanel1.Controls.Add(Me.Txt_Concepto)
        Me.GroupPanel1.Controls.Add(Me.LabelX3)
        Me.GroupPanel1.Controls.Add(Me.Btn_Buscar_Tidp)
        Me.GroupPanel1.Controls.Add(Me.Txt_Tidp)
        Me.GroupPanel1.Controls.Add(Me.LabelX2)
        Me.GroupPanel1.Controls.Add(Me.Btn_Buscar_Tido)
        Me.GroupPanel1.Controls.Add(Me.Txt_Tido)
        Me.GroupPanel1.Controls.Add(Me.LabelX1)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Location = New System.Drawing.Point(12, 12)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(537, 160)
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
        Me.GroupPanel1.TabIndex = 0
        Me.GroupPanel1.Text = "Detalle del concepto obligatorio"
        '
        'Cmb_Vista_Informe
        '
        Me.Cmb_Vista_Informe.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Cmb_Vista_Informe.DisplayMember = "Text"
        Me.Cmb_Vista_Informe.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.Cmb_Vista_Informe.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.Cmb_Vista_Informe.ForeColor = System.Drawing.Color.Black
        Me.Cmb_Vista_Informe.FormattingEnabled = True
        Me.Cmb_Vista_Informe.ItemHeight = 16
        Me.Cmb_Vista_Informe.Location = New System.Drawing.Point(206, 105)
        Me.Cmb_Vista_Informe.MaximumSize = New System.Drawing.Size(322, 0)
        Me.Cmb_Vista_Informe.Name = "Cmb_Vista_Informe"
        Me.Cmb_Vista_Informe.Size = New System.Drawing.Size(322, 22)
        Me.Cmb_Vista_Informe.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Cmb_Vista_Informe.TabIndex = 111
        '
        'LabelX4
        '
        Me.LabelX4.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.ForeColor = System.Drawing.Color.Black
        Me.LabelX4.Location = New System.Drawing.Point(3, 104)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(261, 23)
        Me.LabelX4.TabIndex = 12
        Me.LabelX4.Text = "Condición extra para validar documento:"
        '
        'Btn_Buscar_Concepto
        '
        Me.Btn_Buscar_Concepto.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Buscar_Concepto.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Buscar_Concepto.Location = New System.Drawing.Point(453, 75)
        Me.Btn_Buscar_Concepto.Name = "Btn_Buscar_Concepto"
        Me.Btn_Buscar_Concepto.Size = New System.Drawing.Size(75, 22)
        Me.Btn_Buscar_Concepto.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Buscar_Concepto.TabIndex = 8
        Me.Btn_Buscar_Concepto.Text = "Buscar"
        '
        'Txt_Concepto
        '
        Me.Txt_Concepto.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Concepto.Border.Class = "TextBoxBorder"
        Me.Txt_Concepto.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Concepto.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Concepto.ForeColor = System.Drawing.Color.Black
        Me.Txt_Concepto.Location = New System.Drawing.Point(102, 75)
        Me.Txt_Concepto.Name = "Txt_Concepto"
        Me.Txt_Concepto.PreventEnterBeep = True
        Me.Txt_Concepto.ReadOnly = True
        Me.Txt_Concepto.Size = New System.Drawing.Size(345, 22)
        Me.Txt_Concepto.TabIndex = 7
        '
        'LabelX3
        '
        Me.LabelX3.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.ForeColor = System.Drawing.Color.Black
        Me.LabelX3.Location = New System.Drawing.Point(3, 75)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(93, 23)
        Me.LabelX3.TabIndex = 6
        Me.LabelX3.Text = "Concepto"
        '
        'Btn_Buscar_Tidp
        '
        Me.Btn_Buscar_Tidp.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Buscar_Tidp.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Buscar_Tidp.Location = New System.Drawing.Point(453, 48)
        Me.Btn_Buscar_Tidp.Name = "Btn_Buscar_Tidp"
        Me.Btn_Buscar_Tidp.Size = New System.Drawing.Size(75, 22)
        Me.Btn_Buscar_Tidp.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Buscar_Tidp.TabIndex = 5
        Me.Btn_Buscar_Tidp.Text = "Buscar"
        '
        'Txt_Tidp
        '
        Me.Txt_Tidp.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Tidp.Border.Class = "TextBoxBorder"
        Me.Txt_Tidp.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Tidp.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Tidp.ForeColor = System.Drawing.Color.Black
        Me.Txt_Tidp.Location = New System.Drawing.Point(102, 47)
        Me.Txt_Tidp.Name = "Txt_Tidp"
        Me.Txt_Tidp.PreventEnterBeep = True
        Me.Txt_Tidp.ReadOnly = True
        Me.Txt_Tidp.Size = New System.Drawing.Size(345, 22)
        Me.Txt_Tidp.TabIndex = 4
        '
        'LabelX2
        '
        Me.LabelX2.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.ForeColor = System.Drawing.Color.Black
        Me.LabelX2.Location = New System.Drawing.Point(3, 47)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(93, 23)
        Me.LabelX2.TabIndex = 3
        Me.LabelX2.Text = "Tipo de pago"
        '
        'Btn_Buscar_Tido
        '
        Me.Btn_Buscar_Tido.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Buscar_Tido.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Buscar_Tido.Location = New System.Drawing.Point(453, 20)
        Me.Btn_Buscar_Tido.Name = "Btn_Buscar_Tido"
        Me.Btn_Buscar_Tido.Size = New System.Drawing.Size(75, 22)
        Me.Btn_Buscar_Tido.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Buscar_Tido.TabIndex = 2
        Me.Btn_Buscar_Tido.Text = "Buscar"
        '
        'Txt_Tido
        '
        Me.Txt_Tido.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Tido.Border.Class = "TextBoxBorder"
        Me.Txt_Tido.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Tido.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Tido.ForeColor = System.Drawing.Color.Black
        Me.Txt_Tido.Location = New System.Drawing.Point(102, 19)
        Me.Txt_Tido.Name = "Txt_Tido"
        Me.Txt_Tido.PreventEnterBeep = True
        Me.Txt_Tido.ReadOnly = True
        Me.Txt_Tido.Size = New System.Drawing.Size(345, 22)
        Me.Txt_Tido.TabIndex = 1
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.ForeColor = System.Drawing.Color.Black
        Me.LabelX1.Location = New System.Drawing.Point(3, 19)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(93, 23)
        Me.LabelX1.TabIndex = 0
        Me.LabelX1.Text = "Tipo documento"
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Agregar})
        Me.Bar1.Location = New System.Drawing.Point(0, 182)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(561, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 66
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'Btn_Agregar
        '
        Me.Btn_Agregar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Agregar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Agregar.Image = CType(resources.GetObject("Btn_Agregar.Image"), System.Drawing.Image)
        Me.Btn_Agregar.ImageAlt = CType(resources.GetObject("Btn_Agregar.ImageAlt"), System.Drawing.Image)
        Me.Btn_Agregar.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.Btn_Agregar.Name = "Btn_Agregar"
        Me.Btn_Agregar.Tooltip = "Grabar"
        '
        'Frm_Conceptos_ObliXDoc_Ing
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(561, 223)
        Me.Controls.Add(Me.Bar1)
        Me.Controls.Add(Me.GroupPanel1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Conceptos_ObliXDoc_Ing"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CONCEPTOS OBLIGATORIO SEGUN TIPO DE PAGO"
        Me.GroupPanel1.ResumeLayout(False)
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Btn_Buscar_Concepto As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Txt_Concepto As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Btn_Buscar_Tidp As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Txt_Tidp As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Btn_Buscar_Tido As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Txt_Tido As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents Btn_Agregar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Cmb_Vista_Informe As DevComponents.DotNetBar.Controls.ComboBoxEx
End Class
