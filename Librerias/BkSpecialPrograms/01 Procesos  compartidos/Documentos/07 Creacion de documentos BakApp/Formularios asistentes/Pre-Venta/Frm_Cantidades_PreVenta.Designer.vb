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
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Txt_CantidadPreVenta = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Lbl_Cantidad = New System.Windows.Forms.Label()
        Me.Line1 = New DevComponents.DotNetBar.Controls.Line()
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
        Me.Txt_CantUD2.Size = New System.Drawing.Size(100, 22)
        Me.Txt_CantUD2.TabIndex = 130
        Me.Txt_CantUD2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Txt_CantUD2.WatermarkText = "0"
        '
        'Txt_CantUD1
        '
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
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.White
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(12, 95)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(39, 13)
        Me.Label3.TabIndex = 123
        Me.Label3.Text = "R.T.U. "
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.White
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(12, 119)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(105, 13)
        Me.Label2.TabIndex = 122
        Me.Label2.Text = "Unidad Secundaria"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.White
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(12, 69)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(89, 13)
        Me.Label1.TabIndex = 121
        Me.Label1.Text = "Unidad Primaria"
        '
        'Txt_CantidadPreVenta
        '
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
        'Lbl_Cantidad
        '
        Me.Lbl_Cantidad.AutoSize = True
        Me.Lbl_Cantidad.BackColor = System.Drawing.Color.White
        Me.Lbl_Cantidad.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Cantidad.Location = New System.Drawing.Point(12, 27)
        Me.Lbl_Cantidad.Name = "Lbl_Cantidad"
        Me.Lbl_Cantidad.Size = New System.Drawing.Size(101, 13)
        Me.Lbl_Cantidad.TabIndex = 133
        Me.Lbl_Cantidad.Text = "Cantidad de Pallet"
        '
        'Line1
        '
        Me.Line1.BackColor = System.Drawing.Color.White
        Me.Line1.ForeColor = System.Drawing.Color.Black
        Me.Line1.Location = New System.Drawing.Point(15, 43)
        Me.Line1.Name = "Line1"
        Me.Line1.Size = New System.Drawing.Size(240, 23)
        Me.Line1.TabIndex = 136
        Me.Line1.Text = "Line1"
        '
        'Frm_Cantidades_PreVenta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(270, 209)
        Me.Controls.Add(Me.Txt_CantidadPreVenta)
        Me.Controls.Add(Me.Lbl_Cantidad)
        Me.Controls.Add(Me.Img_RtuAPI)
        Me.Controls.Add(Me.Chk_DesacRazTransf)
        Me.Controls.Add(Me.Txt_CantUD2)
        Me.Controls.Add(Me.Txt_CantUD1)
        Me.Controls.Add(Me.Btn_VerStock)
        Me.Controls.Add(Me.Btn_Aceptar)
        Me.Controls.Add(Me.Lbl_Ud2)
        Me.Controls.Add(Me.Lbl_Ud1)
        Me.Controls.Add(Me.Txt_RTU)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
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
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Txt_CantidadPreVenta As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Lbl_Cantidad As Label
    Friend WithEvents Line1 As DevComponents.DotNetBar.Controls.Line
End Class
