<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Dimensiones_Pr
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Dimensiones_Pr))
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Txt_Largo = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Txt_Ancho = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Txt_Alto = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Txt_Peso = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.Bar2 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Grabar = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Duplicar_Dimensiones = New DevComponents.DotNetBar.ButtonItem()
        Me.GroupPanel1.SuspendLayout()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupPanel1
        '
        Me.GroupPanel1.BackColor = System.Drawing.Color.White
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.Txt_Largo)
        Me.GroupPanel1.Controls.Add(Me.Txt_Ancho)
        Me.GroupPanel1.Controls.Add(Me.Txt_Alto)
        Me.GroupPanel1.Controls.Add(Me.Txt_Peso)
        Me.GroupPanel1.Controls.Add(Me.LabelX1)
        Me.GroupPanel1.Controls.Add(Me.LabelX2)
        Me.GroupPanel1.Controls.Add(Me.LabelX4)
        Me.GroupPanel1.Controls.Add(Me.LabelX3)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Location = New System.Drawing.Point(12, 12)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(339, 156)
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
        Me.GroupPanel1.TabIndex = 9
        Me.GroupPanel1.Text = "Datos de peso y volumen"
        '
        'Txt_Largo
        '
        Me.Txt_Largo.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Largo.Border.Class = "TextBoxBorder"
        Me.Txt_Largo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Largo.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Largo.ForeColor = System.Drawing.Color.Black
        Me.Txt_Largo.Location = New System.Drawing.Point(181, 101)
        Me.Txt_Largo.Name = "Txt_Largo"
        Me.Txt_Largo.PreventEnterBeep = True
        Me.Txt_Largo.Size = New System.Drawing.Size(74, 22)
        Me.Txt_Largo.TabIndex = 15
        Me.Txt_Largo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.Txt_Largo.WatermarkText = "0,000"
        '
        'Txt_Ancho
        '
        Me.Txt_Ancho.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Ancho.Border.Class = "TextBoxBorder"
        Me.Txt_Ancho.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Ancho.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Ancho.ForeColor = System.Drawing.Color.Black
        Me.Txt_Ancho.Location = New System.Drawing.Point(181, 73)
        Me.Txt_Ancho.Name = "Txt_Ancho"
        Me.Txt_Ancho.PreventEnterBeep = True
        Me.Txt_Ancho.Size = New System.Drawing.Size(74, 22)
        Me.Txt_Ancho.TabIndex = 14
        Me.Txt_Ancho.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.Txt_Ancho.WatermarkText = "0,000"
        '
        'Txt_Alto
        '
        Me.Txt_Alto.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Alto.Border.Class = "TextBoxBorder"
        Me.Txt_Alto.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Alto.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Alto.ForeColor = System.Drawing.Color.Black
        Me.Txt_Alto.Location = New System.Drawing.Point(181, 45)
        Me.Txt_Alto.Name = "Txt_Alto"
        Me.Txt_Alto.PreventEnterBeep = True
        Me.Txt_Alto.Size = New System.Drawing.Size(74, 22)
        Me.Txt_Alto.TabIndex = 13
        Me.Txt_Alto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.Txt_Alto.WatermarkText = "0,000"
        '
        'Txt_Peso
        '
        Me.Txt_Peso.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Peso.Border.Class = "TextBoxBorder"
        Me.Txt_Peso.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Peso.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Peso.ForeColor = System.Drawing.Color.Black
        Me.Txt_Peso.Location = New System.Drawing.Point(181, 17)
        Me.Txt_Peso.Name = "Txt_Peso"
        Me.Txt_Peso.PreventEnterBeep = True
        Me.Txt_Peso.Size = New System.Drawing.Size(74, 22)
        Me.Txt_Peso.TabIndex = 12
        Me.Txt_Peso.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.Txt_Peso.WatermarkText = "0,000"
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.LabelX1.ForeColor = System.Drawing.Color.Black
        Me.LabelX1.Location = New System.Drawing.Point(43, 102)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(75, 23)
        Me.LabelX1.TabIndex = 7
        Me.LabelX1.Text = "Largo (Cm)"
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
        Me.LabelX2.Location = New System.Drawing.Point(43, 73)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(75, 23)
        Me.LabelX2.TabIndex = 6
        Me.LabelX2.Text = "Ancho (Cm)"
        '
        'LabelX4
        '
        Me.LabelX4.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.LabelX4.ForeColor = System.Drawing.Color.Black
        Me.LabelX4.Location = New System.Drawing.Point(43, 45)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(75, 23)
        Me.LabelX4.TabIndex = 3
        Me.LabelX4.Text = "Alto (Cm)"
        '
        'LabelX3
        '
        Me.LabelX3.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.LabelX3.ForeColor = System.Drawing.Color.Black
        Me.LabelX3.Location = New System.Drawing.Point(43, 19)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(75, 23)
        Me.LabelX3.TabIndex = 2
        Me.LabelX3.Text = "Peso (Kg)"
        '
        'Bar2
        '
        Me.Bar2.AntiAlias = True
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Grabar, Me.Btn_Duplicar_Dimensiones})
        Me.Bar2.Location = New System.Drawing.Point(0, 183)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(363, 41)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Bar2.TabIndex = 44
        Me.Bar2.TabStop = False
        Me.Bar2.Text = "Bar2"
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
        'Btn_Duplicar_Dimensiones
        '
        Me.Btn_Duplicar_Dimensiones.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Duplicar_Dimensiones.ForeColor = System.Drawing.Color.Black
        Me.Btn_Duplicar_Dimensiones.Image = CType(resources.GetObject("Btn_Duplicar_Dimensiones.Image"), System.Drawing.Image)
        Me.Btn_Duplicar_Dimensiones.ImageAlt = CType(resources.GetObject("Btn_Duplicar_Dimensiones.ImageAlt"), System.Drawing.Image)
        Me.Btn_Duplicar_Dimensiones.Name = "Btn_Duplicar_Dimensiones"
        Me.Btn_Duplicar_Dimensiones.Tooltip = "Copiar estas dimensiones a otros productos"
        '
        'Frm_Dimensiones_Pr
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(363, 224)
        Me.Controls.Add(Me.Bar2)
        Me.Controls.Add(Me.GroupPanel1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Dimensiones_Pr"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MetroForm"
        Me.GroupPanel1.ResumeLayout(False)
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents Btn_Grabar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Duplicar_Dimensiones As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Txt_Peso As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Txt_Largo As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Txt_Ancho As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Txt_Alto As DevComponents.DotNetBar.Controls.TextBoxX
End Class
