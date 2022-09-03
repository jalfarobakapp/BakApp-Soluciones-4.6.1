<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Agencia_Entidad
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Agencia_Entidad))
        Me.GroupPanel2 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Btn_Quitar_Transportista = New DevComponents.DotNetBar.ButtonX()
        Me.Txt_AG_Nombre_Contacto = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.Btn_Buscar_Transportista = New DevComponents.DotNetBar.ButtonX()
        Me.Txt_AG_Transportista = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX6 = New DevComponents.DotNetBar.LabelX()
        Me.Chk_AG_AgenciaxDefDespachos = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Bar2 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Grabar = New DevComponents.DotNetBar.ButtonItem()
        Me.GroupPanel2.SuspendLayout()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupPanel2
        '
        Me.GroupPanel2.BackColor = System.Drawing.Color.White
        Me.GroupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel2.Controls.Add(Me.Btn_Quitar_Transportista)
        Me.GroupPanel2.Controls.Add(Me.Txt_AG_Nombre_Contacto)
        Me.GroupPanel2.Controls.Add(Me.LabelX2)
        Me.GroupPanel2.Controls.Add(Me.Btn_Buscar_Transportista)
        Me.GroupPanel2.Controls.Add(Me.Txt_AG_Transportista)
        Me.GroupPanel2.Controls.Add(Me.LabelX6)
        Me.GroupPanel2.Controls.Add(Me.Chk_AG_AgenciaxDefDespachos)
        Me.GroupPanel2.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel2.Location = New System.Drawing.Point(12, 12)
        Me.GroupPanel2.Name = "GroupPanel2"
        Me.GroupPanel2.Size = New System.Drawing.Size(604, 127)
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
        Me.GroupPanel2.TabIndex = 57
        Me.GroupPanel2.Text = "Transportista por defecto para despachos por agencia de este cliente"
        '
        'Btn_Quitar_Transportista
        '
        Me.Btn_Quitar_Transportista.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Quitar_Transportista.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Quitar_Transportista.Image = CType(resources.GetObject("Btn_Quitar_Transportista.Image"), System.Drawing.Image)
        Me.Btn_Quitar_Transportista.Location = New System.Drawing.Point(565, 43)
        Me.Btn_Quitar_Transportista.Name = "Btn_Quitar_Transportista"
        Me.Btn_Quitar_Transportista.Size = New System.Drawing.Size(27, 22)
        Me.Btn_Quitar_Transportista.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Quitar_Transportista.TabIndex = 151
        Me.Btn_Quitar_Transportista.Tooltip = "Quitar transportista"
        '
        'Txt_AG_Nombre_Contacto
        '
        Me.Txt_AG_Nombre_Contacto.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_AG_Nombre_Contacto.Border.Class = "TextBoxBorder"
        Me.Txt_AG_Nombre_Contacto.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_AG_Nombre_Contacto.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_AG_Nombre_Contacto.ForeColor = System.Drawing.Color.Black
        Me.Txt_AG_Nombre_Contacto.Location = New System.Drawing.Point(86, 71)
        Me.Txt_AG_Nombre_Contacto.MaxLength = 50
        Me.Txt_AG_Nombre_Contacto.Name = "Txt_AG_Nombre_Contacto"
        Me.Txt_AG_Nombre_Contacto.PreventEnterBeep = True
        Me.Txt_AG_Nombre_Contacto.Size = New System.Drawing.Size(393, 22)
        Me.Txt_AG_Nombre_Contacto.TabIndex = 149
        '
        'LabelX2
        '
        Me.LabelX2.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.LabelX2.ForeColor = System.Drawing.Color.Black
        Me.LabelX2.Location = New System.Drawing.Point(3, 73)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(85, 20)
        Me.LabelX2.TabIndex = 150
        Me.LabelX2.Text = "Contacto"
        '
        'Btn_Buscar_Transportista
        '
        Me.Btn_Buscar_Transportista.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Buscar_Transportista.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Buscar_Transportista.Image = CType(resources.GetObject("Btn_Buscar_Transportista.Image"), System.Drawing.Image)
        Me.Btn_Buscar_Transportista.Location = New System.Drawing.Point(485, 43)
        Me.Btn_Buscar_Transportista.Name = "Btn_Buscar_Transportista"
        Me.Btn_Buscar_Transportista.Size = New System.Drawing.Size(74, 22)
        Me.Btn_Buscar_Transportista.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Buscar_Transportista.TabIndex = 142
        Me.Btn_Buscar_Transportista.Text = "buscar..."
        Me.Btn_Buscar_Transportista.Tooltip = "Buscar transportista"
        '
        'Txt_AG_Transportista
        '
        Me.Txt_AG_Transportista.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_AG_Transportista.Border.Class = "TextBoxBorder"
        Me.Txt_AG_Transportista.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_AG_Transportista.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_AG_Transportista.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_AG_Transportista.ForeColor = System.Drawing.Color.Black
        Me.Txt_AG_Transportista.Location = New System.Drawing.Point(86, 43)
        Me.Txt_AG_Transportista.MaxLength = 20
        Me.Txt_AG_Transportista.Name = "Txt_AG_Transportista"
        Me.Txt_AG_Transportista.PreventEnterBeep = True
        Me.Txt_AG_Transportista.ReadOnly = True
        Me.Txt_AG_Transportista.Size = New System.Drawing.Size(393, 22)
        Me.Txt_AG_Transportista.TabIndex = 144
        Me.Txt_AG_Transportista.TabStop = False
        '
        'LabelX6
        '
        Me.LabelX6.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX6.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.LabelX6.ForeColor = System.Drawing.Color.Black
        Me.LabelX6.Location = New System.Drawing.Point(3, 42)
        Me.LabelX6.Name = "LabelX6"
        Me.LabelX6.Size = New System.Drawing.Size(77, 20)
        Me.LabelX6.TabIndex = 143
        Me.LabelX6.Text = "Transportista"
        '
        'Chk_AG_AgenciaxDefDespachos
        '
        Me.Chk_AG_AgenciaxDefDespachos.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_AG_AgenciaxDefDespachos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_AG_AgenciaxDefDespachos.ForeColor = System.Drawing.Color.Black
        Me.Chk_AG_AgenciaxDefDespachos.Location = New System.Drawing.Point(3, 13)
        Me.Chk_AG_AgenciaxDefDespachos.Name = "Chk_AG_AgenciaxDefDespachos"
        Me.Chk_AG_AgenciaxDefDespachos.Size = New System.Drawing.Size(395, 23)
        Me.Chk_AG_AgenciaxDefDespachos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_AG_AgenciaxDefDespachos.TabIndex = 0
        Me.Chk_AG_AgenciaxDefDespachos.Text = "Usar a este transportista cuando tenga que hacer despachos tipo AGENCIA"
        '
        'Bar2
        '
        Me.Bar2.AntiAlias = True
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Grabar})
        Me.Bar2.Location = New System.Drawing.Point(0, 153)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(628, 41)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Bar2.TabIndex = 93
        Me.Bar2.TabStop = False
        Me.Bar2.Text = "Bar2"
        '
        'Btn_Grabar
        '
        Me.Btn_Grabar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Grabar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Grabar.Image = CType(resources.GetObject("Btn_Grabar.Image"), System.Drawing.Image)
        Me.Btn_Grabar.ImageAlt = CType(resources.GetObject("Btn_Grabar.ImageAlt"), System.Drawing.Image)
        Me.Btn_Grabar.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.Btn_Grabar.Name = "Btn_Grabar"
        Me.Btn_Grabar.Tooltip = "Grabar [F4]"
        '
        'Frm_Agencia_Entidad
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(628, 194)
        Me.Controls.Add(Me.Bar2)
        Me.Controls.Add(Me.GroupPanel2)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Agencia_Entidad"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "AGENCIA POR DEFECTO PARA LA ENTIDAD"
        Me.GroupPanel2.ResumeLayout(False)
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupPanel2 As DevComponents.DotNetBar.Controls.GroupPanel
    Public WithEvents Btn_Quitar_Transportista As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Txt_AG_Nombre_Contacto As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Public WithEvents Btn_Buscar_Transportista As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Txt_AG_Transportista As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX6 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Chk_AG_AgenciaxDefDespachos As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents Btn_Grabar As DevComponents.DotNetBar.ButtonItem
End Class
