<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_ConfPuntosVta
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_ConfPuntosVta))
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Grabar = New DevComponents.DotNetBar.ButtonItem()
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Txt_Concepto = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX11 = New DevComponents.DotNetBar.LabelX()
        Me.Input_ValMinPedCajear = New DevComponents.Editors.IntegerInput()
        Me.LabelX10 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX9 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX8 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX7 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX6 = New DevComponents.DotNetBar.LabelX()
        Me.Input_MinPtosCanjear = New DevComponents.Editors.IntegerInput()
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX()
        Me.Input_REquivPesos = New DevComponents.Editors.IntegerInput()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.Input_RCadaPuntos = New DevComponents.Editors.IntegerInput()
        Me.Input_GEquivPuntos = New DevComponents.Editors.IntegerInput()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.Input_GCadaPesos = New DevComponents.Editors.IntegerInput()
        Me.Chk_Activo = New DevComponents.DotNetBar.Controls.CheckBoxX()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel1.SuspendLayout()
        CType(Me.Input_ValMinPedCajear, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Input_MinPtosCanjear, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Input_REquivPesos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Input_RCadaPuntos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Input_GEquivPuntos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Input_GCadaPesos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Grabar})
        Me.Bar1.Location = New System.Drawing.Point(0, 233)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(533, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 98
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'Btn_Grabar
        '
        Me.Btn_Grabar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Grabar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Grabar.Image = CType(resources.GetObject("Btn_Grabar.Image"), System.Drawing.Image)
        Me.Btn_Grabar.ImageAlt = CType(resources.GetObject("Btn_Grabar.ImageAlt"), System.Drawing.Image)
        Me.Btn_Grabar.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.Btn_Grabar.Name = "Btn_Grabar"
        Me.Btn_Grabar.Tooltip = "Grabar"
        '
        'GroupPanel1
        '
        Me.GroupPanel1.BackColor = System.Drawing.Color.White
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.Txt_Concepto)
        Me.GroupPanel1.Controls.Add(Me.LabelX11)
        Me.GroupPanel1.Controls.Add(Me.Input_ValMinPedCajear)
        Me.GroupPanel1.Controls.Add(Me.LabelX10)
        Me.GroupPanel1.Controls.Add(Me.LabelX9)
        Me.GroupPanel1.Controls.Add(Me.LabelX8)
        Me.GroupPanel1.Controls.Add(Me.LabelX7)
        Me.GroupPanel1.Controls.Add(Me.LabelX6)
        Me.GroupPanel1.Controls.Add(Me.Input_MinPtosCanjear)
        Me.GroupPanel1.Controls.Add(Me.LabelX5)
        Me.GroupPanel1.Controls.Add(Me.Input_REquivPesos)
        Me.GroupPanel1.Controls.Add(Me.LabelX4)
        Me.GroupPanel1.Controls.Add(Me.Input_RCadaPuntos)
        Me.GroupPanel1.Controls.Add(Me.Input_GEquivPuntos)
        Me.GroupPanel1.Controls.Add(Me.LabelX3)
        Me.GroupPanel1.Controls.Add(Me.LabelX2)
        Me.GroupPanel1.Controls.Add(Me.LabelX1)
        Me.GroupPanel1.Controls.Add(Me.Input_GCadaPesos)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Location = New System.Drawing.Point(12, 12)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(512, 184)
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
        Me.GroupPanel1.TabIndex = 99
        Me.GroupPanel1.Text = "Detalle"
        '
        'Txt_Concepto
        '
        Me.Txt_Concepto.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Concepto.Border.Class = "TextBoxBorder"
        Me.Txt_Concepto.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Concepto.ButtonCustom.Image = CType(resources.GetObject("Txt_Concepto.ButtonCustom.Image"), System.Drawing.Image)
        Me.Txt_Concepto.ButtonCustom.Visible = True
        Me.Txt_Concepto.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Concepto.ForeColor = System.Drawing.Color.Black
        Me.Txt_Concepto.Location = New System.Drawing.Point(68, 130)
        Me.Txt_Concepto.Name = "Txt_Concepto"
        Me.Txt_Concepto.PreventEnterBeep = True
        Me.Txt_Concepto.ReadOnly = True
        Me.Txt_Concepto.Size = New System.Drawing.Size(429, 22)
        Me.Txt_Concepto.TabIndex = 73
        '
        'LabelX11
        '
        Me.LabelX11.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX11.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX11.ForeColor = System.Drawing.Color.Black
        Me.LabelX11.Location = New System.Drawing.Point(3, 129)
        Me.LabelX11.Name = "LabelX11"
        Me.LabelX11.Size = New System.Drawing.Size(59, 23)
        Me.LabelX11.TabIndex = 72
        Me.LabelX11.Text = "Concepto"
        '
        'Input_ValMinPedCajear
        '
        Me.Input_ValMinPedCajear.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Input_ValMinPedCajear.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Input_ValMinPedCajear.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Input_ValMinPedCajear.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.Input_ValMinPedCajear.ForeColor = System.Drawing.Color.Black
        Me.Input_ValMinPedCajear.Location = New System.Drawing.Point(266, 100)
        Me.Input_ValMinPedCajear.MaxValue = 9999999
        Me.Input_ValMinPedCajear.MinValue = 0
        Me.Input_ValMinPedCajear.Name = "Input_ValMinPedCajear"
        Me.Input_ValMinPedCajear.ShowUpDown = True
        Me.Input_ValMinPedCajear.Size = New System.Drawing.Size(55, 22)
        Me.Input_ValMinPedCajear.TabIndex = 5
        '
        'LabelX10
        '
        Me.LabelX10.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX10.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX10.ForeColor = System.Drawing.Color.Black
        Me.LabelX10.Location = New System.Drawing.Point(327, 100)
        Me.LabelX10.Name = "LabelX10"
        Me.LabelX10.Size = New System.Drawing.Size(63, 23)
        Me.LabelX10.TabIndex = 71
        Me.LabelX10.Text = "$"
        '
        'LabelX9
        '
        Me.LabelX9.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX9.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX9.ForeColor = System.Drawing.Color.Black
        Me.LabelX9.Location = New System.Drawing.Point(327, 72)
        Me.LabelX9.Name = "LabelX9"
        Me.LabelX9.Size = New System.Drawing.Size(63, 23)
        Me.LabelX9.TabIndex = 70
        Me.LabelX9.Text = "puntos"
        '
        'LabelX8
        '
        Me.LabelX8.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX8.ForeColor = System.Drawing.Color.Black
        Me.LabelX8.Location = New System.Drawing.Point(457, 14)
        Me.LabelX8.Name = "LabelX8"
        Me.LabelX8.Size = New System.Drawing.Size(40, 23)
        Me.LabelX8.TabIndex = 69
        Me.LabelX8.Text = "puntos"
        Me.LabelX8.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'LabelX7
        '
        Me.LabelX7.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX7.ForeColor = System.Drawing.Color.Black
        Me.LabelX7.Location = New System.Drawing.Point(220, 14)
        Me.LabelX7.Name = "LabelX7"
        Me.LabelX7.Size = New System.Drawing.Size(40, 23)
        Me.LabelX7.TabIndex = 68
        Me.LabelX7.Text = "Cada $"
        '
        'LabelX6
        '
        Me.LabelX6.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX6.ForeColor = System.Drawing.Color.Black
        Me.LabelX6.Location = New System.Drawing.Point(3, 100)
        Me.LabelX6.Name = "LabelX6"
        Me.LabelX6.Size = New System.Drawing.Size(232, 23)
        Me.LabelX6.TabIndex = 66
        Me.LabelX6.Text = "Valor mínimo de pedido para canjear"
        '
        'Input_MinPtosCanjear
        '
        Me.Input_MinPtosCanjear.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Input_MinPtosCanjear.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Input_MinPtosCanjear.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Input_MinPtosCanjear.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.Input_MinPtosCanjear.ForeColor = System.Drawing.Color.Black
        Me.Input_MinPtosCanjear.Location = New System.Drawing.Point(266, 72)
        Me.Input_MinPtosCanjear.MaxValue = 9999999
        Me.Input_MinPtosCanjear.MinValue = 0
        Me.Input_MinPtosCanjear.Name = "Input_MinPtosCanjear"
        Me.Input_MinPtosCanjear.ShowUpDown = True
        Me.Input_MinPtosCanjear.Size = New System.Drawing.Size(55, 22)
        Me.Input_MinPtosCanjear.TabIndex = 4
        '
        'LabelX5
        '
        Me.LabelX5.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX5.ForeColor = System.Drawing.Color.Black
        Me.LabelX5.Location = New System.Drawing.Point(3, 71)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.Size = New System.Drawing.Size(174, 23)
        Me.LabelX5.TabIndex = 64
        Me.LabelX5.Text = "Puntos mínimos para canjear"
        '
        'Input_REquivPesos
        '
        Me.Input_REquivPesos.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Input_REquivPesos.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Input_REquivPesos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Input_REquivPesos.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.Input_REquivPesos.ForeColor = System.Drawing.Color.Black
        Me.Input_REquivPesos.Location = New System.Drawing.Point(396, 42)
        Me.Input_REquivPesos.MaxValue = 100
        Me.Input_REquivPesos.MinValue = 1
        Me.Input_REquivPesos.Name = "Input_REquivPesos"
        Me.Input_REquivPesos.ShowUpDown = True
        Me.Input_REquivPesos.Size = New System.Drawing.Size(55, 22)
        Me.Input_REquivPesos.TabIndex = 3
        Me.Input_REquivPesos.Value = 1
        '
        'LabelX4
        '
        Me.LabelX4.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.ForeColor = System.Drawing.Color.Black
        Me.LabelX4.Location = New System.Drawing.Point(327, 41)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(63, 23)
        Me.LabelX4.TabIndex = 63
        Me.LabelX4.Text = "Puntos = $"
        '
        'Input_RCadaPuntos
        '
        Me.Input_RCadaPuntos.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Input_RCadaPuntos.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Input_RCadaPuntos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Input_RCadaPuntos.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.Input_RCadaPuntos.ForeColor = System.Drawing.Color.Black
        Me.Input_RCadaPuntos.Location = New System.Drawing.Point(266, 42)
        Me.Input_RCadaPuntos.MaxValue = 100
        Me.Input_RCadaPuntos.MinValue = 1
        Me.Input_RCadaPuntos.Name = "Input_RCadaPuntos"
        Me.Input_RCadaPuntos.ShowUpDown = True
        Me.Input_RCadaPuntos.Size = New System.Drawing.Size(55, 22)
        Me.Input_RCadaPuntos.TabIndex = 2
        Me.Input_RCadaPuntos.Value = 1
        '
        'Input_GEquivPuntos
        '
        Me.Input_GEquivPuntos.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Input_GEquivPuntos.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Input_GEquivPuntos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Input_GEquivPuntos.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.Input_GEquivPuntos.ForeColor = System.Drawing.Color.Black
        Me.Input_GEquivPuntos.Location = New System.Drawing.Point(396, 14)
        Me.Input_GEquivPuntos.MaxValue = 9999999
        Me.Input_GEquivPuntos.MinValue = 1
        Me.Input_GEquivPuntos.Name = "Input_GEquivPuntos"
        Me.Input_GEquivPuntos.ShowUpDown = True
        Me.Input_GEquivPuntos.Size = New System.Drawing.Size(55, 22)
        Me.Input_GEquivPuntos.TabIndex = 1
        Me.Input_GEquivPuntos.Value = 1
        '
        'LabelX3
        '
        Me.LabelX3.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.ForeColor = System.Drawing.Color.Black
        Me.LabelX3.Location = New System.Drawing.Point(327, 13)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(63, 23)
        Me.LabelX3.TabIndex = 60
        Me.LabelX3.Text = "="
        Me.LabelX3.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'LabelX2
        '
        Me.LabelX2.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.ForeColor = System.Drawing.Color.Black
        Me.LabelX2.Location = New System.Drawing.Point(3, 42)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(174, 23)
        Me.LabelX2.TabIndex = 57
        Me.LabelX2.Text = "Redención de puntos"
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.ForeColor = System.Drawing.Color.Black
        Me.LabelX1.Location = New System.Drawing.Point(3, 13)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(174, 23)
        Me.LabelX1.TabIndex = 1
        Me.LabelX1.Text = "Ganar puntos"
        '
        'Input_GCadaPesos
        '
        Me.Input_GCadaPesos.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Input_GCadaPesos.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Input_GCadaPesos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Input_GCadaPesos.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.Input_GCadaPesos.ForeColor = System.Drawing.Color.Black
        Me.Input_GCadaPesos.Location = New System.Drawing.Point(266, 13)
        Me.Input_GCadaPesos.MaxValue = 9999999
        Me.Input_GCadaPesos.MinValue = 1
        Me.Input_GCadaPesos.Name = "Input_GCadaPesos"
        Me.Input_GCadaPesos.ShowUpDown = True
        Me.Input_GCadaPesos.Size = New System.Drawing.Size(55, 22)
        Me.Input_GCadaPesos.TabIndex = 0
        Me.Input_GCadaPesos.Value = 100
        '
        'Chk_Activo
        '
        Me.Chk_Activo.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_Activo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Activo.CheckBoxImageChecked = CType(resources.GetObject("Chk_Activo.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_Activo.FocusCuesEnabled = False
        Me.Chk_Activo.ForeColor = System.Drawing.Color.Black
        Me.Chk_Activo.Location = New System.Drawing.Point(12, 202)
        Me.Chk_Activo.Name = "Chk_Activo"
        Me.Chk_Activo.Size = New System.Drawing.Size(194, 15)
        Me.Chk_Activo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Activo.TabIndex = 100
        Me.Chk_Activo.TabStop = False
        Me.Chk_Activo.Text = "Sistema de fidelización activo"
        '
        'Frm_ConfPuntosVta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(533, 274)
        Me.Controls.Add(Me.Chk_Activo)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Controls.Add(Me.Bar1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_ConfPuntosVta"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MANTENCION DE SISTEMA DE PUNTOS POR VENTAS"
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel1.ResumeLayout(False)
        CType(Me.Input_ValMinPedCajear, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Input_MinPtosCanjear, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Input_REquivPesos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Input_RCadaPuntos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Input_GEquivPuntos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Input_GCadaPesos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents Btn_Grabar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Input_GCadaPesos As DevComponents.Editors.IntegerInput
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Input_REquivPesos As DevComponents.Editors.IntegerInput
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Input_RCadaPuntos As DevComponents.Editors.IntegerInput
    Friend WithEvents Input_GEquivPuntos As DevComponents.Editors.IntegerInput
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Input_MinPtosCanjear As DevComponents.Editors.IntegerInput
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX6 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX8 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX7 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Input_ValMinPedCajear As DevComponents.Editors.IntegerInput
    Friend WithEvents LabelX10 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX9 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Txt_Concepto As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX11 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Chk_Activo As DevComponents.DotNetBar.Controls.CheckBoxX
End Class
