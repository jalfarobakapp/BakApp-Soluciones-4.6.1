<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Desp_04_Depachar
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Desp_04_Depachar))
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Despachar = New DevComponents.DotNetBar.ButtonItem()
        Me.Txt_Entregado_Por = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.Cmb_Tipo_Entrega = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.Txt_Observaciones = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_Nombre_Transpor = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Lbl_Link_Nombre_Transpor = New DevComponents.DotNetBar.LabelX()
        Me.Lbl_Link_Entregado_Por = New DevComponents.DotNetBar.LabelX()
        Me.Btn_CodFuncionario_Transpor = New DevComponents.DotNetBar.ButtonX()
        Me.Btn_Entregado_Por = New DevComponents.DotNetBar.ButtonX()
        Me.Highlighter1 = New DevComponents.DotNetBar.Validator.Highlighter()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Despachar})
        Me.Bar1.Location = New System.Drawing.Point(0, 220)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(556, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 132
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'Btn_Despachar
        '
        Me.Btn_Despachar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Despachar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Despachar.Image = CType(resources.GetObject("Btn_Despachar.Image"), System.Drawing.Image)
        Me.Btn_Despachar.ImageAlt = CType(resources.GetObject("Btn_Despachar.ImageAlt"), System.Drawing.Image)
        Me.Btn_Despachar.Name = "Btn_Despachar"
        Me.Btn_Despachar.Text = "DESPACHADO"
        '
        'Txt_Entregado_Por
        '
        Me.Txt_Entregado_Por.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Entregado_Por.Border.Class = "TextBoxBorder"
        Me.Txt_Entregado_Por.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Entregado_Por.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_Entregado_Por.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Entregado_Por.ForeColor = System.Drawing.Color.Black
        Me.Highlighter1.SetHighlightOnFocus(Me.Txt_Entregado_Por, True)
        Me.Txt_Entregado_Por.Location = New System.Drawing.Point(141, 65)
        Me.Txt_Entregado_Por.Name = "Txt_Entregado_Por"
        Me.Txt_Entregado_Por.PreventEnterBeep = True
        Me.Txt_Entregado_Por.ReadOnly = True
        Me.Txt_Entregado_Por.Size = New System.Drawing.Size(363, 22)
        Me.Txt_Entregado_Por.TabIndex = 95
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.ForeColor = System.Drawing.Color.Black
        Me.LabelX1.Location = New System.Drawing.Point(15, 12)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(114, 19)
        Me.LabelX1.TabIndex = 0
        Me.LabelX1.Text = "Entregado a"
        '
        'Cmb_Tipo_Entrega
        '
        Me.Cmb_Tipo_Entrega.DisplayMember = "Text"
        Me.Cmb_Tipo_Entrega.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.Cmb_Tipo_Entrega.ForeColor = System.Drawing.Color.Black
        Me.Cmb_Tipo_Entrega.FormattingEnabled = True
        Me.Highlighter1.SetHighlightOnFocus(Me.Cmb_Tipo_Entrega, True)
        Me.Cmb_Tipo_Entrega.ItemHeight = 16
        Me.Cmb_Tipo_Entrega.Location = New System.Drawing.Point(141, 9)
        Me.Cmb_Tipo_Entrega.Name = "Cmb_Tipo_Entrega"
        Me.Cmb_Tipo_Entrega.Size = New System.Drawing.Size(363, 22)
        Me.Cmb_Tipo_Entrega.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Cmb_Tipo_Entrega.TabIndex = 134
        '
        'Txt_Observaciones
        '
        Me.Txt_Observaciones.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Observaciones.Border.Class = "TextBoxBorder"
        Me.Txt_Observaciones.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Observaciones.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_Observaciones.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Observaciones.ForeColor = System.Drawing.Color.Black
        Me.Highlighter1.SetHighlightOnFocus(Me.Txt_Observaciones, True)
        Me.Txt_Observaciones.Location = New System.Drawing.Point(15, 126)
        Me.Txt_Observaciones.Multiline = True
        Me.Txt_Observaciones.Name = "Txt_Observaciones"
        Me.Txt_Observaciones.PreventEnterBeep = True
        Me.Txt_Observaciones.Size = New System.Drawing.Size(530, 80)
        Me.Txt_Observaciones.TabIndex = 134
        '
        'LabelX4
        '
        Me.LabelX4.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.ForeColor = System.Drawing.Color.Black
        Me.LabelX4.Location = New System.Drawing.Point(15, 103)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(138, 20)
        Me.LabelX4.TabIndex = 135
        Me.LabelX4.Text = "Observaciones"
        '
        'Txt_Nombre_Transpor
        '
        Me.Txt_Nombre_Transpor.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Nombre_Transpor.Border.Class = "TextBoxBorder"
        Me.Txt_Nombre_Transpor.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Nombre_Transpor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_Nombre_Transpor.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Nombre_Transpor.ForeColor = System.Drawing.Color.Black
        Me.Highlighter1.SetHighlightOnFocus(Me.Txt_Nombre_Transpor, True)
        Me.Txt_Nombre_Transpor.Location = New System.Drawing.Point(141, 37)
        Me.Txt_Nombre_Transpor.Name = "Txt_Nombre_Transpor"
        Me.Txt_Nombre_Transpor.PreventEnterBeep = True
        Me.Txt_Nombre_Transpor.Size = New System.Drawing.Size(363, 22)
        Me.Txt_Nombre_Transpor.TabIndex = 136
        '
        'Lbl_Link_Nombre_Transpor
        '
        Me.Lbl_Link_Nombre_Transpor.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_Link_Nombre_Transpor.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Link_Nombre_Transpor.Cursor = System.Windows.Forms.Cursors.Default
        Me.Lbl_Link_Nombre_Transpor.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Link_Nombre_Transpor.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Link_Nombre_Transpor.Location = New System.Drawing.Point(15, 37)
        Me.Lbl_Link_Nombre_Transpor.Name = "Lbl_Link_Nombre_Transpor"
        Me.Lbl_Link_Nombre_Transpor.Size = New System.Drawing.Size(114, 20)
        Me.Lbl_Link_Nombre_Transpor.TabIndex = 30
        Me.Lbl_Link_Nombre_Transpor.Text = "Funcionario transporta"
        '
        'Lbl_Link_Entregado_Por
        '
        Me.Lbl_Link_Entregado_Por.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_Link_Entregado_Por.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Link_Entregado_Por.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.Lbl_Link_Entregado_Por.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Link_Entregado_Por.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Link_Entregado_Por.Location = New System.Drawing.Point(15, 63)
        Me.Lbl_Link_Entregado_Por.Name = "Lbl_Link_Entregado_Por"
        Me.Lbl_Link_Entregado_Por.Size = New System.Drawing.Size(114, 20)
        Me.Lbl_Link_Entregado_Por.TabIndex = 136
        Me.Lbl_Link_Entregado_Por.Text = "Entregado por"
        '
        'Btn_CodFuncionario_Transpor
        '
        Me.Btn_CodFuncionario_Transpor.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_CodFuncionario_Transpor.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_CodFuncionario_Transpor.Image = CType(resources.GetObject("Btn_CodFuncionario_Transpor.Image"), System.Drawing.Image)
        Me.Btn_CodFuncionario_Transpor.ImageAlt = CType(resources.GetObject("Btn_CodFuncionario_Transpor.ImageAlt"), System.Drawing.Image)
        Me.Btn_CodFuncionario_Transpor.Location = New System.Drawing.Point(507, 37)
        Me.Btn_CodFuncionario_Transpor.Name = "Btn_CodFuncionario_Transpor"
        Me.Btn_CodFuncionario_Transpor.Size = New System.Drawing.Size(38, 21)
        Me.Btn_CodFuncionario_Transpor.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_CodFuncionario_Transpor.TabIndex = 137
        Me.Btn_CodFuncionario_Transpor.TabStop = False
        Me.Btn_CodFuncionario_Transpor.Tooltip = "Buscar Cliente"
        '
        'Btn_Entregado_Por
        '
        Me.Btn_Entregado_Por.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Entregado_Por.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Entregado_Por.Image = CType(resources.GetObject("Btn_Entregado_Por.Image"), System.Drawing.Image)
        Me.Btn_Entregado_Por.ImageAlt = CType(resources.GetObject("Btn_Entregado_Por.ImageAlt"), System.Drawing.Image)
        Me.Btn_Entregado_Por.Location = New System.Drawing.Point(507, 66)
        Me.Btn_Entregado_Por.Name = "Btn_Entregado_Por"
        Me.Btn_Entregado_Por.Size = New System.Drawing.Size(38, 21)
        Me.Btn_Entregado_Por.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Entregado_Por.TabIndex = 138
        Me.Btn_Entregado_Por.TabStop = False
        Me.Btn_Entregado_Por.Tooltip = "Buscar Cliente"
        '
        'Highlighter1
        '
        Me.Highlighter1.FocusHighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Green
        Me.Highlighter1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        '
        'Frm_Desp_04_Depachar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(556, 261)
        Me.Controls.Add(Me.Btn_Entregado_Por)
        Me.Controls.Add(Me.Btn_CodFuncionario_Transpor)
        Me.Controls.Add(Me.Txt_Entregado_Por)
        Me.Controls.Add(Me.Txt_Nombre_Transpor)
        Me.Controls.Add(Me.Lbl_Link_Entregado_Por)
        Me.Controls.Add(Me.Cmb_Tipo_Entrega)
        Me.Controls.Add(Me.LabelX1)
        Me.Controls.Add(Me.Lbl_Link_Nombre_Transpor)
        Me.Controls.Add(Me.LabelX4)
        Me.Controls.Add(Me.Txt_Observaciones)
        Me.Controls.Add(Me.Bar1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Desp_04_Depachar"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "DESPACHAR"
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Public WithEvents Btn_Despachar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Public WithEvents Cmb_Tipo_Entrega As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents Txt_Entregado_Por As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Txt_Observaciones As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Txt_Nombre_Transpor As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Lbl_Link_Nombre_Transpor As DevComponents.DotNetBar.LabelX
    Friend WithEvents Lbl_Link_Entregado_Por As DevComponents.DotNetBar.LabelX
    Friend WithEvents Btn_CodFuncionario_Transpor As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Btn_Entregado_Por As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Highlighter1 As DevComponents.DotNetBar.Validator.Highlighter
End Class
