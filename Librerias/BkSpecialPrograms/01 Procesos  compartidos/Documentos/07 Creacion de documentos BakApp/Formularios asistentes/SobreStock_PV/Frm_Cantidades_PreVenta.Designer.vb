<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Cantidades_PreVenta
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Cantidades_PreVenta))
        Me.Img_RtuAPI = New DevComponents.DotNetBar.Controls.ReflectionImage()
        Me.Chk_DesacRazTransf = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Txt_CantUD2 = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Txt_CantUD1 = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Btn_VerStock = New DevComponents.DotNetBar.ButtonX()
        Me.Btn_Aceptar = New DevComponents.DotNetBar.ButtonX()
        Me.Lbl_Ud2 = New System.Windows.Forms.Label()
        Me.Lbl_Ud1 = New System.Windows.Forms.Label()
        Me.Txt_RTU = New System.Windows.Forms.TextBox()
        Me.Txt_CantidadPreVenta = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Line1 = New DevComponents.DotNetBar.Controls.Line()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.Lbl_Rtu = New DevComponents.DotNetBar.LabelX()
        Me.Line2 = New DevComponents.DotNetBar.Controls.Line()
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_CantMinFormato = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX6 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_CantidadDisponible = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_Ud1XPqte = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX7 = New DevComponents.DotNetBar.LabelX()
        Me.DInput_PrecioXUd1 = New DevComponents.Editors.DoubleInput()
        CType(Me.DInput_PrecioXUd1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Img_RtuAPI
        '
        Me.Img_RtuAPI.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Img_RtuAPI.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Img_RtuAPI.ForeColor = System.Drawing.Color.Black
        Me.Img_RtuAPI.Location = New System.Drawing.Point(86, 92)
        Me.Img_RtuAPI.Name = "Img_RtuAPI"
        Me.Img_RtuAPI.Size = New System.Drawing.Size(30, 22)
        Me.Img_RtuAPI.TabIndex = 132
        '
        'Chk_DesacRazTransf
        '
        Me.Chk_DesacRazTransf.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Chk_DesacRazTransf.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_DesacRazTransf.CheckBoxImageChecked = CType(resources.GetObject("Chk_DesacRazTransf.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_DesacRazTransf.Enabled = False
        Me.Chk_DesacRazTransf.FocusCuesEnabled = False
        Me.Chk_DesacRazTransf.ForeColor = System.Drawing.Color.Black
        Me.Chk_DesacRazTransf.Location = New System.Drawing.Point(12, 173)
        Me.Chk_DesacRazTransf.Name = "Chk_DesacRazTransf"
        Me.Chk_DesacRazTransf.Size = New System.Drawing.Size(194, 25)
        Me.Chk_DesacRazTransf.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_DesacRazTransf.TabIndex = 131
        Me.Chk_DesacRazTransf.Text = "Desactivar razón de transformación"
        '
        'Txt_CantUD2
        '
        Me.Txt_CantUD2.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_CantUD2.Border.Class = "TextBoxBorder"
        Me.Txt_CantUD2.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_CantUD2.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_CantUD2.ForeColor = System.Drawing.Color.Black
        Me.Txt_CantUD2.Location = New System.Drawing.Point(122, 117)
        Me.Txt_CantUD2.Name = "Txt_CantUD2"
        Me.Txt_CantUD2.PreventEnterBeep = True
        Me.Txt_CantUD2.ReadOnly = True
        Me.Txt_CantUD2.Size = New System.Drawing.Size(100, 22)
        Me.Txt_CantUD2.TabIndex = 130
        Me.Txt_CantUD2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Txt_CantUD2.WatermarkText = "0"
        '
        'Txt_CantUD1
        '
        Me.Txt_CantUD1.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_CantUD1.Border.Class = "TextBoxBorder"
        Me.Txt_CantUD1.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_CantUD1.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_CantUD1.ForeColor = System.Drawing.Color.Black
        Me.Txt_CantUD1.Location = New System.Drawing.Point(122, 67)
        Me.Txt_CantUD1.Name = "Txt_CantUD1"
        Me.Txt_CantUD1.PreventEnterBeep = True
        Me.Txt_CantUD1.ReadOnly = True
        Me.Txt_CantUD1.Size = New System.Drawing.Size(100, 22)
        Me.Txt_CantUD1.TabIndex = 129
        Me.Txt_CantUD1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Txt_CantUD1.WatermarkText = "0"
        '
        'Btn_VerStock
        '
        Me.Btn_VerStock.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_VerStock.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_VerStock.Image = CType(resources.GetObject("Btn_VerStock.Image"), System.Drawing.Image)
        Me.Btn_VerStock.ImageAlt = CType(resources.GetObject("Btn_VerStock.ImageAlt"), System.Drawing.Image)
        Me.Btn_VerStock.Location = New System.Drawing.Point(228, 144)
        Me.Btn_VerStock.Name = "Btn_VerStock"
        Me.Btn_VerStock.Size = New System.Drawing.Size(27, 23)
        Me.Btn_VerStock.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_VerStock.TabIndex = 128
        '
        'Btn_Aceptar
        '
        Me.Btn_Aceptar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Aceptar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Aceptar.Location = New System.Drawing.Point(15, 144)
        Me.Btn_Aceptar.Name = "Btn_Aceptar"
        Me.Btn_Aceptar.Size = New System.Drawing.Size(207, 23)
        Me.Btn_Aceptar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Aceptar.TabIndex = 127
        Me.Btn_Aceptar.Text = "ACEPTAR"
        '
        'Lbl_Ud2
        '
        Me.Lbl_Ud2.AutoSize = True
        Me.Lbl_Ud2.BackColor = System.Drawing.Color.White
        Me.Lbl_Ud2.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Ud2.Location = New System.Drawing.Point(230, 119)
        Me.Lbl_Ud2.Name = "Lbl_Ud2"
        Me.Lbl_Ud2.Size = New System.Drawing.Size(29, 13)
        Me.Lbl_Ud2.TabIndex = 126
        Me.Lbl_Ud2.Text = "UD2"
        '
        'Lbl_Ud1
        '
        Me.Lbl_Ud1.AutoSize = True
        Me.Lbl_Ud1.BackColor = System.Drawing.Color.White
        Me.Lbl_Ud1.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Ud1.Location = New System.Drawing.Point(230, 69)
        Me.Lbl_Ud1.Name = "Lbl_Ud1"
        Me.Lbl_Ud1.Size = New System.Drawing.Size(29, 13)
        Me.Lbl_Ud1.TabIndex = 125
        Me.Lbl_Ud1.Text = "UD1"
        '
        'Txt_RTU
        '
        Me.Txt_RTU.BackColor = System.Drawing.Color.White
        Me.Txt_RTU.Enabled = False
        Me.Txt_RTU.ForeColor = System.Drawing.Color.Black
        Me.Txt_RTU.Location = New System.Drawing.Point(122, 92)
        Me.Txt_RTU.Name = "Txt_RTU"
        Me.Txt_RTU.ReadOnly = True
        Me.Txt_RTU.Size = New System.Drawing.Size(100, 22)
        Me.Txt_RTU.TabIndex = 124
        Me.Txt_RTU.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Txt_CantidadPreVenta
        '
        Me.Txt_CantidadPreVenta.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_CantidadPreVenta.Border.Class = "TextBoxBorder"
        Me.Txt_CantidadPreVenta.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_CantidadPreVenta.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_CantidadPreVenta.ForeColor = System.Drawing.Color.Black
        Me.Txt_CantidadPreVenta.Location = New System.Drawing.Point(122, 25)
        Me.Txt_CantidadPreVenta.Name = "Txt_CantidadPreVenta"
        Me.Txt_CantidadPreVenta.PreventEnterBeep = True
        Me.Txt_CantidadPreVenta.Size = New System.Drawing.Size(100, 22)
        Me.Txt_CantidadPreVenta.TabIndex = 135
        Me.Txt_CantidadPreVenta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Txt_CantidadPreVenta.WatermarkText = "0"
        '
        'Line1
        '
        Me.Line1.BackColor = System.Drawing.Color.White
        Me.Line1.ForeColor = System.Drawing.Color.Black
        Me.Line1.Location = New System.Drawing.Point(15, 51)
        Me.Line1.Name = "Line1"
        Me.Line1.Size = New System.Drawing.Size(240, 23)
        Me.Line1.TabIndex = 136
        Me.Line1.Text = "Line1"
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.ForeColor = System.Drawing.Color.Black
        Me.LabelX1.Location = New System.Drawing.Point(15, 25)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(102, 23)
        Me.LabelX1.TabIndex = 137
        Me.LabelX1.Text = "Cantidad de Pallet"
        '
        'LabelX2
        '
        Me.LabelX2.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.ForeColor = System.Drawing.Color.Black
        Me.LabelX2.Location = New System.Drawing.Point(15, 67)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(102, 23)
        Me.LabelX2.TabIndex = 138
        Me.LabelX2.Text = "Unidad primaria"
        '
        'LabelX3
        '
        Me.LabelX3.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.ForeColor = System.Drawing.Color.Black
        Me.LabelX3.Location = New System.Drawing.Point(15, 117)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(102, 23)
        Me.LabelX3.TabIndex = 139
        Me.LabelX3.Text = "Unidad Secundaria"
        '
        'Lbl_Rtu
        '
        Me.Lbl_Rtu.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Lbl_Rtu.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Rtu.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Rtu.Location = New System.Drawing.Point(15, 92)
        Me.Lbl_Rtu.Name = "Lbl_Rtu"
        Me.Lbl_Rtu.Size = New System.Drawing.Size(102, 23)
        Me.Lbl_Rtu.TabIndex = 140
        Me.Lbl_Rtu.Text = "R.T.U."
        '
        'Line2
        '
        Me.Line2.BackColor = System.Drawing.Color.White
        Me.Line2.ForeColor = System.Drawing.Color.Black
        Me.Line2.Location = New System.Drawing.Point(12, 204)
        Me.Line2.Name = "Line2"
        Me.Line2.Size = New System.Drawing.Size(243, 23)
        Me.Line2.TabIndex = 141
        Me.Line2.Text = "Line2"
        '
        'LabelX5
        '
        Me.LabelX5.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX5.ForeColor = System.Drawing.Color.Black
        Me.LabelX5.Location = New System.Drawing.Point(12, 257)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.Size = New System.Drawing.Size(101, 36)
        Me.LabelX5.TabIndex = 143
        Me.LabelX5.Text = "Cantidad minima" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "de venta (Pallet)"
        '
        'Txt_CantMinFormato
        '
        Me.Txt_CantMinFormato.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_CantMinFormato.Border.Class = "TextBoxBorder"
        Me.Txt_CantMinFormato.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_CantMinFormato.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_CantMinFormato.ForeColor = System.Drawing.Color.Black
        Me.Txt_CantMinFormato.Location = New System.Drawing.Point(122, 266)
        Me.Txt_CantMinFormato.Name = "Txt_CantMinFormato"
        Me.Txt_CantMinFormato.PreventEnterBeep = True
        Me.Txt_CantMinFormato.ReadOnly = True
        Me.Txt_CantMinFormato.Size = New System.Drawing.Size(100, 22)
        Me.Txt_CantMinFormato.TabIndex = 142
        Me.Txt_CantMinFormato.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Txt_CantMinFormato.WatermarkText = "0"
        '
        'LabelX6
        '
        Me.LabelX6.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX6.ForeColor = System.Drawing.Color.Black
        Me.LabelX6.Location = New System.Drawing.Point(11, 296)
        Me.LabelX6.Name = "LabelX6"
        Me.LabelX6.Size = New System.Drawing.Size(102, 23)
        Me.LabelX6.TabIndex = 144
        Me.LabelX6.Text = "Pallet disponibles"
        '
        'Txt_CantidadDisponible
        '
        Me.Txt_CantidadDisponible.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_CantidadDisponible.Border.Class = "TextBoxBorder"
        Me.Txt_CantidadDisponible.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_CantidadDisponible.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_CantidadDisponible.ForeColor = System.Drawing.Color.Black
        Me.Txt_CantidadDisponible.Location = New System.Drawing.Point(122, 299)
        Me.Txt_CantidadDisponible.Name = "Txt_CantidadDisponible"
        Me.Txt_CantidadDisponible.PreventEnterBeep = True
        Me.Txt_CantidadDisponible.ReadOnly = True
        Me.Txt_CantidadDisponible.Size = New System.Drawing.Size(100, 22)
        Me.Txt_CantidadDisponible.TabIndex = 145
        Me.Txt_CantidadDisponible.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Txt_CantidadDisponible.WatermarkText = "0"
        '
        'LabelX4
        '
        Me.LabelX4.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.ForeColor = System.Drawing.Color.Black
        Me.LabelX4.Location = New System.Drawing.Point(12, 233)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(101, 18)
        Me.LabelX4.TabIndex = 147
        Me.LabelX4.Text = "Kilos por Pallet" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'Txt_Ud1XPqte
        '
        Me.Txt_Ud1XPqte.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Ud1XPqte.Border.Class = "TextBoxBorder"
        Me.Txt_Ud1XPqte.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Ud1XPqte.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Ud1XPqte.ForeColor = System.Drawing.Color.Black
        Me.Txt_Ud1XPqte.Location = New System.Drawing.Point(122, 233)
        Me.Txt_Ud1XPqte.Name = "Txt_Ud1XPqte"
        Me.Txt_Ud1XPqte.PreventEnterBeep = True
        Me.Txt_Ud1XPqte.ReadOnly = True
        Me.Txt_Ud1XPqte.Size = New System.Drawing.Size(100, 22)
        Me.Txt_Ud1XPqte.TabIndex = 146
        Me.Txt_Ud1XPqte.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Txt_Ud1XPqte.WatermarkText = "0"
        '
        'LabelX7
        '
        Me.LabelX7.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX7.ForeColor = System.Drawing.Color.Black
        Me.LabelX7.Location = New System.Drawing.Point(12, 325)
        Me.LabelX7.Name = "LabelX7"
        Me.LabelX7.Size = New System.Drawing.Size(102, 23)
        Me.LabelX7.TabIndex = 148
        Me.LabelX7.Text = "Precio de venta"
        '
        'DInput_PrecioXUd1
        '
        Me.DInput_PrecioXUd1.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.DInput_PrecioXUd1.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.DInput_PrecioXUd1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.DInput_PrecioXUd1.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.DInput_PrecioXUd1.ForeColor = System.Drawing.Color.Black
        Me.DInput_PrecioXUd1.Increment = 0.1R
        Me.DInput_PrecioXUd1.Location = New System.Drawing.Point(122, 327)
        Me.DInput_PrecioXUd1.MinValue = 0R
        Me.DInput_PrecioXUd1.Name = "DInput_PrecioXUd1"
        Me.DInput_PrecioXUd1.ShowUpDown = True
        Me.DInput_PrecioXUd1.Size = New System.Drawing.Size(100, 22)
        Me.DInput_PrecioXUd1.TabIndex = 172
        '
        'Frm_Cantidades_PreVenta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(270, 358)
        Me.Controls.Add(Me.DInput_PrecioXUd1)
        Me.Controls.Add(Me.LabelX7)
        Me.Controls.Add(Me.LabelX4)
        Me.Controls.Add(Me.Txt_Ud1XPqte)
        Me.Controls.Add(Me.Txt_CantidadDisponible)
        Me.Controls.Add(Me.LabelX6)
        Me.Controls.Add(Me.LabelX5)
        Me.Controls.Add(Me.Txt_CantMinFormato)
        Me.Controls.Add(Me.Line2)
        Me.Controls.Add(Me.Lbl_Rtu)
        Me.Controls.Add(Me.LabelX3)
        Me.Controls.Add(Me.LabelX2)
        Me.Controls.Add(Me.LabelX1)
        Me.Controls.Add(Me.Txt_CantidadPreVenta)
        Me.Controls.Add(Me.Img_RtuAPI)
        Me.Controls.Add(Me.Chk_DesacRazTransf)
        Me.Controls.Add(Me.Txt_CantUD2)
        Me.Controls.Add(Me.Txt_CantUD1)
        Me.Controls.Add(Me.Btn_VerStock)
        Me.Controls.Add(Me.Btn_Aceptar)
        Me.Controls.Add(Me.Lbl_Ud2)
        Me.Controls.Add(Me.Lbl_Ud1)
        Me.Controls.Add(Me.Txt_RTU)
        Me.Controls.Add(Me.Line1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Cantidades_PreVenta"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cantidades PRE-VENTA"
        CType(Me.DInput_PrecioXUd1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Img_RtuAPI As DevComponents.DotNetBar.Controls.ReflectionImage
    Friend WithEvents Chk_DesacRazTransf As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Txt_CantUD2 As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Txt_CantUD1 As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Btn_VerStock As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Btn_Aceptar As DevComponents.DotNetBar.ButtonX
    Public WithEvents Lbl_Ud2 As Label
    Public WithEvents Lbl_Ud1 As Label
    Public WithEvents Txt_RTU As TextBox
    Friend WithEvents Txt_CantidadPreVenta As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Line1 As DevComponents.DotNetBar.Controls.Line
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Lbl_Rtu As DevComponents.DotNetBar.LabelX
    Friend WithEvents Line2 As DevComponents.DotNetBar.Controls.Line
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Txt_CantMinFormato As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX6 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Txt_CantidadDisponible As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Txt_Ud1XPqte As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX7 As DevComponents.DotNetBar.LabelX
    Friend WithEvents DInput_PrecioXUd1 As DevComponents.Editors.DoubleInput
End Class
