<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Demonio_ConfAsisCompra
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Demonio_ConfAsisCompra))
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Grabar = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_ConfAsisCompra = New DevComponents.DotNetBar.ButtonItem()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_Modalidad = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Cmb_Tido = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.Grupo_Resumen = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Btn_ConfProgramacion = New DevComponents.DotNetBar.ButtonX()
        Me.Txt_Resumen = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Btn_Eliminar = New DevComponents.DotNetBar.ButtonItem()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Grupo_Resumen.SuspendLayout()
        Me.SuspendLayout()
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Grabar, Me.Btn_ConfAsisCompra, Me.Btn_Eliminar})
        Me.Bar1.Location = New System.Drawing.Point(0, 143)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(487, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 119
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'Btn_Grabar
        '
        Me.Btn_Grabar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Grabar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Grabar.Image = CType(resources.GetObject("Btn_Grabar.Image"), System.Drawing.Image)
        Me.Btn_Grabar.ImageAlt = CType(resources.GetObject("Btn_Grabar.ImageAlt"), System.Drawing.Image)
        Me.Btn_Grabar.Name = "Btn_Grabar"
        Me.Btn_Grabar.Tooltip = "Grabar"
        '
        'Btn_ConfAsisCompra
        '
        Me.Btn_ConfAsisCompra.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_ConfAsisCompra.ForeColor = System.Drawing.Color.Black
        Me.Btn_ConfAsisCompra.Image = CType(resources.GetObject("Btn_ConfAsisCompra.Image"), System.Drawing.Image)
        Me.Btn_ConfAsisCompra.ImageAlt = CType(resources.GetObject("Btn_ConfAsisCompra.ImageAlt"), System.Drawing.Image)
        Me.Btn_ConfAsisCompra.Name = "Btn_ConfAsisCompra"
        Me.Btn_ConfAsisCompra.Tooltip = "Configuraci�n de asistente de compra"
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.ForeColor = System.Drawing.Color.Black
        Me.LabelX1.Location = New System.Drawing.Point(6, 12)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(75, 23)
        Me.LabelX1.TabIndex = 120
        Me.LabelX1.Text = "Modalidad"
        '
        'Txt_Modalidad
        '
        Me.Txt_Modalidad.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Modalidad.Border.Class = "TextBoxBorder"
        Me.Txt_Modalidad.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Modalidad.ButtonCustom.Visible = True
        Me.Txt_Modalidad.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Modalidad.ForeColor = System.Drawing.Color.Black
        Me.Txt_Modalidad.Location = New System.Drawing.Point(71, 15)
        Me.Txt_Modalidad.Name = "Txt_Modalidad"
        Me.Txt_Modalidad.PreventEnterBeep = True
        Me.Txt_Modalidad.ReadOnly = True
        Me.Txt_Modalidad.Size = New System.Drawing.Size(86, 22)
        Me.Txt_Modalidad.TabIndex = 134
        Me.Txt_Modalidad.TabStop = False
        Me.Txt_Modalidad.Tag = "Lunes"
        '
        'Cmb_Tido
        '
        Me.Cmb_Tido.DisplayMember = "Text"
        Me.Cmb_Tido.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.Cmb_Tido.ForeColor = System.Drawing.Color.Black
        Me.Cmb_Tido.FormattingEnabled = True
        Me.Cmb_Tido.ItemHeight = 16
        Me.Cmb_Tido.Location = New System.Drawing.Point(229, 14)
        Me.Cmb_Tido.Name = "Cmb_Tido"
        Me.Cmb_Tido.Size = New System.Drawing.Size(252, 22)
        Me.Cmb_Tido.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Cmb_Tido.TabIndex = 175
        '
        'LabelX2
        '
        Me.LabelX2.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.ForeColor = System.Drawing.Color.Black
        Me.LabelX2.Location = New System.Drawing.Point(163, 14)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(75, 23)
        Me.LabelX2.TabIndex = 176
        Me.LabelX2.Text = "Documento"
        '
        'Grupo_Resumen
        '
        Me.Grupo_Resumen.BackColor = System.Drawing.Color.White
        Me.Grupo_Resumen.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Grupo_Resumen.Controls.Add(Me.Btn_ConfProgramacion)
        Me.Grupo_Resumen.Controls.Add(Me.Txt_Resumen)
        Me.Grupo_Resumen.DisabledBackColor = System.Drawing.Color.Empty
        Me.Grupo_Resumen.Location = New System.Drawing.Point(6, 53)
        Me.Grupo_Resumen.Name = "Grupo_Resumen"
        Me.Grupo_Resumen.Size = New System.Drawing.Size(475, 84)
        '
        '
        '
        Me.Grupo_Resumen.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Grupo_Resumen.Style.BackColorGradientAngle = 90
        Me.Grupo_Resumen.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Grupo_Resumen.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Resumen.Style.BorderBottomWidth = 1
        Me.Grupo_Resumen.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.Grupo_Resumen.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Resumen.Style.BorderLeftWidth = 1
        Me.Grupo_Resumen.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Resumen.Style.BorderRightWidth = 1
        Me.Grupo_Resumen.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Resumen.Style.BorderTopWidth = 1
        Me.Grupo_Resumen.Style.CornerDiameter = 4
        Me.Grupo_Resumen.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Grupo_Resumen.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.Grupo_Resumen.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.Grupo_Resumen.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.Grupo_Resumen.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.Grupo_Resumen.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Grupo_Resumen.TabIndex = 187
        Me.Grupo_Resumen.Text = "Resumen, descripci�n de la programaci�n"
        '
        'Btn_ConfProgramacion
        '
        Me.Btn_ConfProgramacion.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_ConfProgramacion.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_ConfProgramacion.Enabled = False
        Me.Btn_ConfProgramacion.Image = CType(resources.GetObject("Btn_ConfProgramacion.Image"), System.Drawing.Image)
        Me.Btn_ConfProgramacion.Location = New System.Drawing.Point(426, 3)
        Me.Btn_ConfProgramacion.Name = "Btn_ConfProgramacion"
        Me.Btn_ConfProgramacion.Size = New System.Drawing.Size(40, 55)
        Me.Btn_ConfProgramacion.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_ConfProgramacion.TabIndex = 35
        Me.Btn_ConfProgramacion.Tooltip = "Programaci�n"
        '
        'Txt_Resumen
        '
        Me.Txt_Resumen.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Resumen.Border.Class = "TextBoxBorder"
        Me.Txt_Resumen.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Resumen.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Resumen.ForeColor = System.Drawing.Color.Black
        Me.Txt_Resumen.Location = New System.Drawing.Point(2, 3)
        Me.Txt_Resumen.Multiline = True
        Me.Txt_Resumen.Name = "Txt_Resumen"
        Me.Txt_Resumen.PreventEnterBeep = True
        Me.Txt_Resumen.Size = New System.Drawing.Size(418, 55)
        Me.Txt_Resumen.TabIndex = 1
        '
        'Btn_Eliminar
        '
        Me.Btn_Eliminar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Eliminar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Eliminar.Image = CType(resources.GetObject("Btn_Eliminar.Image"), System.Drawing.Image)
        Me.Btn_Eliminar.ImageAlt = CType(resources.GetObject("Btn_Eliminar.ImageAlt"), System.Drawing.Image)
        Me.Btn_Eliminar.Name = "Btn_Eliminar"
        Me.Btn_Eliminar.Tooltip = "Configuraci�n de asistente de compra"
        '
        'Frm_Demonio_ConfAsisCompra
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(487, 184)
        Me.Controls.Add(Me.Grupo_Resumen)
        Me.Controls.Add(Me.Cmb_Tido)
        Me.Controls.Add(Me.LabelX2)
        Me.Controls.Add(Me.Txt_Modalidad)
        Me.Controls.Add(Me.LabelX1)
        Me.Controls.Add(Me.Bar1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Demonio_ConfAsisCompra"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Configuraci�n"
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Grupo_Resumen.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents Btn_Grabar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Txt_Modalidad As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Cmb_Tido As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Btn_ConfAsisCompra As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Grupo_Resumen As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Btn_ConfProgramacion As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Txt_Resumen As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Btn_Eliminar As DevComponents.DotNetBar.ButtonItem
End Class