<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Cambio_Codigos_UnoxUno
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Cambio_Codigos_UnoxUno))
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_Codigo_Tecnico_New = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_Codigo_Tecnico_Old = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.ChkCambiarCodigoTecnico = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Txt_Codigo_New = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_Descripcion = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_Codigo_Old = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.Bar2 = New DevComponents.DotNetBar.Bar()
        Me.BtnCambiarCodigo = New DevComponents.DotNetBar.ButtonItem()
        Me.GroupPanel1.SuspendLayout()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupPanel1
        '
        Me.GroupPanel1.BackColor = System.Drawing.Color.White
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.LabelX5)
        Me.GroupPanel1.Controls.Add(Me.Txt_Codigo_Tecnico_New)
        Me.GroupPanel1.Controls.Add(Me.LabelX4)
        Me.GroupPanel1.Controls.Add(Me.Txt_Codigo_Tecnico_Old)
        Me.GroupPanel1.Controls.Add(Me.ChkCambiarCodigoTecnico)
        Me.GroupPanel1.Controls.Add(Me.Txt_Codigo_New)
        Me.GroupPanel1.Controls.Add(Me.LabelX3)
        Me.GroupPanel1.Controls.Add(Me.Txt_Descripcion)
        Me.GroupPanel1.Controls.Add(Me.LabelX2)
        Me.GroupPanel1.Controls.Add(Me.Txt_Codigo_Old)
        Me.GroupPanel1.Controls.Add(Me.LabelX1)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Location = New System.Drawing.Point(7, 12)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(629, 109)
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
        '
        'LabelX5
        '
        Me.LabelX5.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX5.ForeColor = System.Drawing.Color.Black
        Me.LabelX5.Location = New System.Drawing.Point(280, 3)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.Size = New System.Drawing.Size(77, 23)
        Me.LabelX5.TabIndex = 11
        Me.LabelX5.Text = "Código técnico"
        '
        'Txt_Codigo_Tecnico_New
        '
        Me.Txt_Codigo_Tecnico_New.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Codigo_Tecnico_New.Border.Class = "TextBoxBorder"
        Me.Txt_Codigo_Tecnico_New.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Codigo_Tecnico_New.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Codigo_Tecnico_New.ForeColor = System.Drawing.Color.Black
        Me.Txt_Codigo_Tecnico_New.Location = New System.Drawing.Point(363, 71)
        Me.Txt_Codigo_Tecnico_New.MaxLength = 20
        Me.Txt_Codigo_Tecnico_New.Name = "Txt_Codigo_Tecnico_New"
        Me.Txt_Codigo_Tecnico_New.PreventEnterBeep = True
        Me.Txt_Codigo_Tecnico_New.Size = New System.Drawing.Size(114, 22)
        Me.Txt_Codigo_Tecnico_New.TabIndex = 10
        '
        'LabelX4
        '
        Me.LabelX4.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.ForeColor = System.Drawing.Color.Black
        Me.LabelX4.Location = New System.Drawing.Point(257, 70)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(100, 23)
        Me.LabelX4.TabIndex = 9
        Me.LabelX4.Text = "Nuevo cód. Técnico"
        '
        'Txt_Codigo_Tecnico_Old
        '
        Me.Txt_Codigo_Tecnico_Old.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Codigo_Tecnico_Old.Border.Class = "TextBoxBorder"
        Me.Txt_Codigo_Tecnico_Old.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Codigo_Tecnico_Old.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Codigo_Tecnico_Old.ForeColor = System.Drawing.Color.Black
        Me.Txt_Codigo_Tecnico_Old.Location = New System.Drawing.Point(363, 3)
        Me.Txt_Codigo_Tecnico_Old.Name = "Txt_Codigo_Tecnico_Old"
        Me.Txt_Codigo_Tecnico_Old.PreventEnterBeep = True
        Me.Txt_Codigo_Tecnico_Old.ReadOnly = True
        Me.Txt_Codigo_Tecnico_Old.Size = New System.Drawing.Size(114, 22)
        Me.Txt_Codigo_Tecnico_Old.TabIndex = 8
        '
        'ChkCambiarCodigoTecnico
        '
        Me.ChkCambiarCodigoTecnico.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.ChkCambiarCodigoTecnico.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ChkCambiarCodigoTecnico.CheckBoxImageChecked = CType(resources.GetObject("ChkCambiarCodigoTecnico.CheckBoxImageChecked"), System.Drawing.Image)
        Me.ChkCambiarCodigoTecnico.FocusCuesEnabled = False
        Me.ChkCambiarCodigoTecnico.ForeColor = System.Drawing.Color.Black
        Me.ChkCambiarCodigoTecnico.Location = New System.Drawing.Point(483, 70)
        Me.ChkCambiarCodigoTecnico.Name = "ChkCambiarCodigoTecnico"
        Me.ChkCambiarCodigoTecnico.Size = New System.Drawing.Size(137, 23)
        Me.ChkCambiarCodigoTecnico.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ChkCambiarCodigoTecnico.TabIndex = 6
        Me.ChkCambiarCodigoTecnico.Text = "Cambiar código técnico"
        '
        'Txt_Codigo_New
        '
        Me.Txt_Codigo_New.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Codigo_New.Border.Class = "TextBoxBorder"
        Me.Txt_Codigo_New.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Codigo_New.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Codigo_New.ForeColor = System.Drawing.Color.Black
        Me.Txt_Codigo_New.Location = New System.Drawing.Point(86, 69)
        Me.Txt_Codigo_New.MaxLength = 13
        Me.Txt_Codigo_New.Name = "Txt_Codigo_New"
        Me.Txt_Codigo_New.PreventEnterBeep = True
        Me.Txt_Codigo_New.Size = New System.Drawing.Size(154, 22)
        Me.Txt_Codigo_New.TabIndex = 5
        '
        'LabelX3
        '
        Me.LabelX3.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.ForeColor = System.Drawing.Color.Black
        Me.LabelX3.Location = New System.Drawing.Point(3, 69)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(77, 23)
        Me.LabelX3.TabIndex = 4
        Me.LabelX3.Text = "Nuevo código"
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
        Me.Txt_Descripcion.Location = New System.Drawing.Point(86, 32)
        Me.Txt_Descripcion.Name = "Txt_Descripcion"
        Me.Txt_Descripcion.PreventEnterBeep = True
        Me.Txt_Descripcion.ReadOnly = True
        Me.Txt_Descripcion.Size = New System.Drawing.Size(534, 22)
        Me.Txt_Descripcion.TabIndex = 3
        '
        'LabelX2
        '
        Me.LabelX2.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.ForeColor = System.Drawing.Color.Black
        Me.LabelX2.Location = New System.Drawing.Point(3, 31)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(77, 23)
        Me.LabelX2.TabIndex = 2
        Me.LabelX2.Text = "Descripción"
        '
        'Txt_Codigo_Old
        '
        Me.Txt_Codigo_Old.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Codigo_Old.Border.Class = "TextBoxBorder"
        Me.Txt_Codigo_Old.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Codigo_Old.ButtonCustom.Image = CType(resources.GetObject("Txt_Codigo_Old.ButtonCustom.Image"), System.Drawing.Image)
        Me.Txt_Codigo_Old.ButtonCustom.Visible = True
        Me.Txt_Codigo_Old.ButtonCustom2.Image = CType(resources.GetObject("Txt_Codigo_Old.ButtonCustom2.Image"), System.Drawing.Image)
        Me.Txt_Codigo_Old.ButtonCustom2.Visible = True
        Me.Txt_Codigo_Old.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Codigo_Old.ForeColor = System.Drawing.Color.Black
        Me.Txt_Codigo_Old.Location = New System.Drawing.Point(86, 4)
        Me.Txt_Codigo_Old.Name = "Txt_Codigo_Old"
        Me.Txt_Codigo_Old.PreventEnterBeep = True
        Me.Txt_Codigo_Old.Size = New System.Drawing.Size(154, 22)
        Me.Txt_Codigo_Old.TabIndex = 1
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
        Me.LabelX1.Size = New System.Drawing.Size(77, 23)
        Me.LabelX1.TabIndex = 0
        Me.LabelX1.Text = "Código original"
        '
        'Bar2
        '
        Me.Bar2.AntiAlias = True
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.BtnCambiarCodigo})
        Me.Bar2.Location = New System.Drawing.Point(0, 134)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(644, 41)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Bar2.TabIndex = 41
        Me.Bar2.TabStop = False
        Me.Bar2.Text = "Bar2"
        '
        'BtnCambiarCodigo
        '
        Me.BtnCambiarCodigo.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnCambiarCodigo.ForeColor = System.Drawing.Color.Black
        Me.BtnCambiarCodigo.Image = CType(resources.GetObject("BtnCambiarCodigo.Image"), System.Drawing.Image)
        Me.BtnCambiarCodigo.ImageAlt = CType(resources.GetObject("BtnCambiarCodigo.ImageAlt"), System.Drawing.Image)
        Me.BtnCambiarCodigo.Name = "BtnCambiarCodigo"
        Me.BtnCambiarCodigo.Text = "Cambiar código"
        '
        'Frm_Cambio_Codigos_UnoxUno
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(644, 175)
        Me.Controls.Add(Me.Bar2)
        Me.Controls.Add(Me.GroupPanel1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Cambio_Codigos_UnoxUno"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cambiar código del producto"
        Me.GroupPanel1.ResumeLayout(False)
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Public WithEvents BtnCambiarCodigo As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Txt_Codigo_Old As DevComponents.DotNetBar.Controls.TextBoxX
    Public WithEvents Txt_Descripcion As DevComponents.DotNetBar.Controls.TextBoxX
    Public WithEvents Txt_Codigo_New As DevComponents.DotNetBar.Controls.TextBoxX
    Public WithEvents ChkCambiarCodigoTecnico As DevComponents.DotNetBar.Controls.CheckBoxX
    Public WithEvents Txt_Codigo_Tecnico_Old As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Public WithEvents Txt_Codigo_Tecnico_New As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
End Class
