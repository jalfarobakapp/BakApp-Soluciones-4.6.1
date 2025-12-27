<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Transporte_DTE
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Transporte_DTE))
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Grabar = New DevComponents.DotNetBar.ButtonItem()
        Me.GroupPanel2 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.LabelX7 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_RUTChofer = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Txt_Chofer = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX6 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_CiudadDest = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_DirDest = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Txt_Patente = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Lbl_CodRef = New DevComponents.DotNetBar.LabelX()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_CmnaDest = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_RUTTrans = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Line1 = New DevComponents.DotNetBar.Controls.Line()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Grabar})
        Me.Bar1.Location = New System.Drawing.Point(0, 262)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(539, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 45
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
        'GroupPanel2
        '
        Me.GroupPanel2.BackColor = System.Drawing.Color.White
        Me.GroupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel2.Controls.Add(Me.LabelX7)
        Me.GroupPanel2.Controls.Add(Me.Txt_RUTChofer)
        Me.GroupPanel2.Controls.Add(Me.Txt_Chofer)
        Me.GroupPanel2.Controls.Add(Me.LabelX6)
        Me.GroupPanel2.Controls.Add(Me.Txt_CiudadDest)
        Me.GroupPanel2.Controls.Add(Me.LabelX5)
        Me.GroupPanel2.Controls.Add(Me.Txt_DirDest)
        Me.GroupPanel2.Controls.Add(Me.Txt_Patente)
        Me.GroupPanel2.Controls.Add(Me.Lbl_CodRef)
        Me.GroupPanel2.Controls.Add(Me.LabelX4)
        Me.GroupPanel2.Controls.Add(Me.LabelX1)
        Me.GroupPanel2.Controls.Add(Me.Txt_CmnaDest)
        Me.GroupPanel2.Controls.Add(Me.LabelX2)
        Me.GroupPanel2.Controls.Add(Me.LabelX3)
        Me.GroupPanel2.Controls.Add(Me.Txt_RUTTrans)
        Me.GroupPanel2.Controls.Add(Me.Line1)
        Me.GroupPanel2.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel2.Location = New System.Drawing.Point(12, 6)
        Me.GroupPanel2.Name = "GroupPanel2"
        Me.GroupPanel2.Size = New System.Drawing.Size(516, 244)
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
        Me.GroupPanel2.TabIndex = 46
        '
        'LabelX7
        '
        Me.LabelX7.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX7.ForeColor = System.Drawing.Color.Black
        Me.LabelX7.Location = New System.Drawing.Point(6, 59)
        Me.LabelX7.Name = "LabelX7"
        Me.LabelX7.Size = New System.Drawing.Size(89, 23)
        Me.LabelX7.TabIndex = 49
        Me.LabelX7.Text = "Rut Chofer"
        '
        'Txt_RUTChofer
        '
        Me.Txt_RUTChofer.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_RUTChofer.Border.Class = "TextBoxBorder"
        Me.Txt_RUTChofer.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_RUTChofer.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_RUTChofer.ForeColor = System.Drawing.Color.Black
        Me.Txt_RUTChofer.Location = New System.Drawing.Point(98, 59)
        Me.Txt_RUTChofer.MaxLength = 10
        Me.Txt_RUTChofer.Name = "Txt_RUTChofer"
        Me.Txt_RUTChofer.PreventEnterBeep = True
        Me.Txt_RUTChofer.Size = New System.Drawing.Size(85, 22)
        Me.Txt_RUTChofer.TabIndex = 2
        '
        'Txt_Chofer
        '
        Me.Txt_Chofer.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Chofer.Border.Class = "TextBoxBorder"
        Me.Txt_Chofer.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Chofer.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_Chofer.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Chofer.ForeColor = System.Drawing.Color.Black
        Me.Txt_Chofer.Location = New System.Drawing.Point(98, 87)
        Me.Txt_Chofer.MaxLength = 40
        Me.Txt_Chofer.Name = "Txt_Chofer"
        Me.Txt_Chofer.PreventEnterBeep = True
        Me.Txt_Chofer.Size = New System.Drawing.Size(399, 22)
        Me.Txt_Chofer.TabIndex = 3
        '
        'LabelX6
        '
        Me.LabelX6.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX6.ForeColor = System.Drawing.Color.Black
        Me.LabelX6.Location = New System.Drawing.Point(6, 127)
        Me.LabelX6.Name = "LabelX6"
        Me.LabelX6.Size = New System.Drawing.Size(62, 23)
        Me.LabelX6.TabIndex = 45
        Me.LabelX6.Text = "Destino"
        '
        'Txt_CiudadDest
        '
        Me.Txt_CiudadDest.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_CiudadDest.Border.Class = "TextBoxBorder"
        Me.Txt_CiudadDest.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_CiudadDest.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_CiudadDest.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_CiudadDest.ForeColor = System.Drawing.Color.Black
        Me.Txt_CiudadDest.Location = New System.Drawing.Point(98, 210)
        Me.Txt_CiudadDest.MaxLength = 20
        Me.Txt_CiudadDest.Name = "Txt_CiudadDest"
        Me.Txt_CiudadDest.PreventEnterBeep = True
        Me.Txt_CiudadDest.Size = New System.Drawing.Size(194, 22)
        Me.Txt_CiudadDest.TabIndex = 6
        '
        'LabelX5
        '
        Me.LabelX5.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX5.ForeColor = System.Drawing.Color.Black
        Me.LabelX5.Location = New System.Drawing.Point(6, 209)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.Size = New System.Drawing.Size(89, 23)
        Me.LabelX5.TabIndex = 43
        Me.LabelX5.Text = "Ciudad"
        '
        'Txt_DirDest
        '
        Me.Txt_DirDest.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_DirDest.Border.Class = "TextBoxBorder"
        Me.Txt_DirDest.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_DirDest.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_DirDest.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_DirDest.ForeColor = System.Drawing.Color.Black
        Me.Txt_DirDest.Location = New System.Drawing.Point(98, 153)
        Me.Txt_DirDest.MaxLength = 70
        Me.Txt_DirDest.Name = "Txt_DirDest"
        Me.Txt_DirDest.PreventEnterBeep = True
        Me.Txt_DirDest.Size = New System.Drawing.Size(399, 22)
        Me.Txt_DirDest.TabIndex = 4
        '
        'Txt_Patente
        '
        Me.Txt_Patente.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Patente.Border.Class = "TextBoxBorder"
        Me.Txt_Patente.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Patente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_Patente.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Patente.ForeColor = System.Drawing.Color.Black
        Me.Txt_Patente.Location = New System.Drawing.Point(98, 5)
        Me.Txt_Patente.MaxLength = 10
        Me.Txt_Patente.Name = "Txt_Patente"
        Me.Txt_Patente.PreventEnterBeep = True
        Me.Txt_Patente.Size = New System.Drawing.Size(85, 22)
        Me.Txt_Patente.TabIndex = 0
        '
        'Lbl_CodRef
        '
        Me.Lbl_CodRef.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_CodRef.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_CodRef.ForeColor = System.Drawing.Color.Black
        Me.Lbl_CodRef.Location = New System.Drawing.Point(6, 153)
        Me.Lbl_CodRef.Name = "Lbl_CodRef"
        Me.Lbl_CodRef.Size = New System.Drawing.Size(89, 23)
        Me.Lbl_CodRef.TabIndex = 40
        Me.Lbl_CodRef.Text = "Dirección"
        '
        'LabelX4
        '
        Me.LabelX4.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.ForeColor = System.Drawing.Color.Black
        Me.LabelX4.Location = New System.Drawing.Point(6, 84)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(89, 23)
        Me.LabelX4.TabIndex = 38
        Me.LabelX4.Text = "Chofer"
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.ForeColor = System.Drawing.Color.Black
        Me.LabelX1.Location = New System.Drawing.Point(6, 5)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(89, 23)
        Me.LabelX1.TabIndex = 5
        Me.LabelX1.Text = "Patente"
        '
        'Txt_CmnaDest
        '
        Me.Txt_CmnaDest.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_CmnaDest.Border.Class = "TextBoxBorder"
        Me.Txt_CmnaDest.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_CmnaDest.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_CmnaDest.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_CmnaDest.ForeColor = System.Drawing.Color.Black
        Me.Txt_CmnaDest.Location = New System.Drawing.Point(98, 182)
        Me.Txt_CmnaDest.MaxLength = 20
        Me.Txt_CmnaDest.Name = "Txt_CmnaDest"
        Me.Txt_CmnaDest.PreventEnterBeep = True
        Me.Txt_CmnaDest.Size = New System.Drawing.Size(194, 22)
        Me.Txt_CmnaDest.TabIndex = 5
        '
        'LabelX2
        '
        Me.LabelX2.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.ForeColor = System.Drawing.Color.Black
        Me.LabelX2.Location = New System.Drawing.Point(6, 31)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(89, 23)
        Me.LabelX2.TabIndex = 0
        Me.LabelX2.Text = "Rut transportista"
        '
        'LabelX3
        '
        Me.LabelX3.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.ForeColor = System.Drawing.Color.Black
        Me.LabelX3.Location = New System.Drawing.Point(6, 182)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(89, 23)
        Me.LabelX3.TabIndex = 2
        Me.LabelX3.Text = "Comuna"
        '
        'Txt_RUTTrans
        '
        Me.Txt_RUTTrans.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_RUTTrans.Border.Class = "TextBoxBorder"
        Me.Txt_RUTTrans.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_RUTTrans.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_RUTTrans.ForeColor = System.Drawing.Color.Black
        Me.Txt_RUTTrans.Location = New System.Drawing.Point(98, 31)
        Me.Txt_RUTTrans.MaxLength = 10
        Me.Txt_RUTTrans.Name = "Txt_RUTTrans"
        Me.Txt_RUTTrans.PreventEnterBeep = True
        Me.Txt_RUTTrans.Size = New System.Drawing.Size(85, 22)
        Me.Txt_RUTTrans.TabIndex = 1
        '
        'Line1
        '
        Me.Line1.BackColor = System.Drawing.Color.Transparent
        Me.Line1.ForeColor = System.Drawing.Color.Black
        Me.Line1.Location = New System.Drawing.Point(6, 113)
        Me.Line1.Name = "Line1"
        Me.Line1.Size = New System.Drawing.Size(491, 23)
        Me.Line1.TabIndex = 47
        Me.Line1.Text = "Line1"
        '
        'Frm_Transporte_DTE
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(539, 303)
        Me.Controls.Add(Me.Bar1)
        Me.Controls.Add(Me.GroupPanel2)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Transporte_DTE"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Transporte"
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents Btn_Grabar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents GroupPanel2 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Lbl_CodRef As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Txt_CmnaDest As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Txt_RUTTrans As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Txt_Patente As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Txt_CiudadDest As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Txt_DirDest As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX6 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Txt_Chofer As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Line1 As DevComponents.DotNetBar.Controls.Line
    Friend WithEvents LabelX7 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Txt_RUTChofer As DevComponents.DotNetBar.Controls.TextBoxX
End Class
