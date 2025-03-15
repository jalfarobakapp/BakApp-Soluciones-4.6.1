<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Cantidades_Ud_Disintas
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Cantidades_Ud_Disintas))
        Me.LblUnidad2 = New System.Windows.Forms.Label()
        Me.LblUnidad1 = New System.Windows.Forms.Label()
        Me.TxtRTU = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BtnAceptar = New DevComponents.DotNetBar.ButtonX()
        Me.Btn_Ver_Stock = New DevComponents.DotNetBar.ButtonX()
        Me.TxtCantUD1 = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.TxtCantUD2 = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Chk_RtuVariable = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Img_RtuAPI = New DevComponents.DotNetBar.Controls.ReflectionImage()
        Me.Imagenes_16x16 = New System.Windows.Forms.ImageList(Me.components)
        Me.Imagenes_16x16_Dark = New System.Windows.Forms.ImageList(Me.components)
        Me.SuspendLayout()
        '
        'LblUnidad2
        '
        Me.LblUnidad2.AutoSize = True
        Me.LblUnidad2.BackColor = System.Drawing.Color.White
        Me.LblUnidad2.ForeColor = System.Drawing.Color.Black
        Me.LblUnidad2.Location = New System.Drawing.Point(230, 59)
        Me.LblUnidad2.Name = "LblUnidad2"
        Me.LblUnidad2.Size = New System.Drawing.Size(29, 13)
        Me.LblUnidad2.TabIndex = 16
        Me.LblUnidad2.Text = "UD2"
        '
        'LblUnidad1
        '
        Me.LblUnidad1.AutoSize = True
        Me.LblUnidad1.BackColor = System.Drawing.Color.White
        Me.LblUnidad1.ForeColor = System.Drawing.Color.Black
        Me.LblUnidad1.Location = New System.Drawing.Point(230, 9)
        Me.LblUnidad1.Name = "LblUnidad1"
        Me.LblUnidad1.Size = New System.Drawing.Size(29, 13)
        Me.LblUnidad1.TabIndex = 15
        Me.LblUnidad1.Text = "UD1"
        '
        'TxtRTU
        '
        Me.TxtRTU.BackColor = System.Drawing.Color.White
        Me.TxtRTU.Enabled = False
        Me.TxtRTU.ForeColor = System.Drawing.Color.Black
        Me.TxtRTU.Location = New System.Drawing.Point(122, 32)
        Me.TxtRTU.Name = "TxtRTU"
        Me.TxtRTU.ReadOnly = True
        Me.TxtRTU.Size = New System.Drawing.Size(100, 22)
        Me.TxtRTU.TabIndex = 14
        Me.TxtRTU.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.White
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(12, 35)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(39, 13)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "R.T.U. "
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.White
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(12, 59)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(105, 13)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Unidad Secundaria"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.White
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(89, 13)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Unidad Primaria"
        '
        'BtnAceptar
        '
        Me.BtnAceptar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BtnAceptar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.BtnAceptar.Location = New System.Drawing.Point(15, 84)
        Me.BtnAceptar.Name = "BtnAceptar"
        Me.BtnAceptar.Size = New System.Drawing.Size(207, 23)
        Me.BtnAceptar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.BtnAceptar.TabIndex = 17
        Me.BtnAceptar.Text = "ACEPTAR"
        '
        'Btn_Ver_Stock
        '
        Me.Btn_Ver_Stock.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Ver_Stock.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Ver_Stock.Image = CType(resources.GetObject("Btn_Ver_Stock.Image"), System.Drawing.Image)
        Me.Btn_Ver_Stock.ImageAlt = CType(resources.GetObject("Btn_Ver_Stock.ImageAlt"), System.Drawing.Image)
        Me.Btn_Ver_Stock.Location = New System.Drawing.Point(228, 84)
        Me.Btn_Ver_Stock.Name = "Btn_Ver_Stock"
        Me.Btn_Ver_Stock.Size = New System.Drawing.Size(27, 23)
        Me.Btn_Ver_Stock.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Ver_Stock.TabIndex = 18
        '
        'TxtCantUD1
        '
        Me.TxtCantUD1.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TxtCantUD1.Border.Class = "TextBoxBorder"
        Me.TxtCantUD1.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtCantUD1.DisabledBackColor = System.Drawing.Color.White
        Me.TxtCantUD1.FocusHighlightEnabled = True
        Me.TxtCantUD1.ForeColor = System.Drawing.Color.Black
        Me.TxtCantUD1.Location = New System.Drawing.Point(122, 7)
        Me.TxtCantUD1.Name = "TxtCantUD1"
        Me.TxtCantUD1.PreventEnterBeep = True
        Me.TxtCantUD1.Size = New System.Drawing.Size(100, 22)
        Me.TxtCantUD1.TabIndex = 19
        Me.TxtCantUD1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.TxtCantUD1.WatermarkText = "0"
        '
        'TxtCantUD2
        '
        Me.TxtCantUD2.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TxtCantUD2.Border.Class = "TextBoxBorder"
        Me.TxtCantUD2.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtCantUD2.DisabledBackColor = System.Drawing.Color.White
        Me.TxtCantUD2.FocusHighlightEnabled = True
        Me.TxtCantUD2.ForeColor = System.Drawing.Color.Black
        Me.TxtCantUD2.Location = New System.Drawing.Point(122, 57)
        Me.TxtCantUD2.Name = "TxtCantUD2"
        Me.TxtCantUD2.PreventEnterBeep = True
        Me.TxtCantUD2.Size = New System.Drawing.Size(100, 22)
        Me.TxtCantUD2.TabIndex = 20
        Me.TxtCantUD2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.TxtCantUD2.WatermarkText = "0"
        '
        'Chk_RtuVariable
        '
        Me.Chk_RtuVariable.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Chk_RtuVariable.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_RtuVariable.CheckBoxImageChecked = CType(resources.GetObject("Chk_RtuVariable.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_RtuVariable.FocusCuesEnabled = False
        Me.Chk_RtuVariable.ForeColor = System.Drawing.Color.Black
        Me.Chk_RtuVariable.Location = New System.Drawing.Point(12, 113)
        Me.Chk_RtuVariable.Name = "Chk_RtuVariable"
        Me.Chk_RtuVariable.Size = New System.Drawing.Size(194, 25)
        Me.Chk_RtuVariable.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_RtuVariable.TabIndex = 119
        Me.Chk_RtuVariable.Text = "Desactivar razón de transformación"
        '
        'Img_RtuAPI
        '
        Me.Img_RtuAPI.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Img_RtuAPI.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Img_RtuAPI.ForeColor = System.Drawing.Color.Black
        Me.Img_RtuAPI.Location = New System.Drawing.Point(86, 32)
        Me.Img_RtuAPI.Name = "Img_RtuAPI"
        Me.Img_RtuAPI.Size = New System.Drawing.Size(30, 22)
        Me.Img_RtuAPI.TabIndex = 120
        '
        'Imagenes_16x16
        '
        Me.Imagenes_16x16.ImageStream = CType(resources.GetObject("Imagenes_16x16.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.Imagenes_16x16.TransparentColor = System.Drawing.Color.Transparent
        Me.Imagenes_16x16.Images.SetKeyName(0, "warning.png")
        Me.Imagenes_16x16.Images.SetKeyName(1, "ok.png")
        Me.Imagenes_16x16.Images.SetKeyName(2, "cancel.png")
        Me.Imagenes_16x16.Images.SetKeyName(3, "delete_button_error.png")
        Me.Imagenes_16x16.Images.SetKeyName(4, "clock.png")
        Me.Imagenes_16x16.Images.SetKeyName(5, "clock-import.png")
        Me.Imagenes_16x16.Images.SetKeyName(6, "clock-info.png")
        Me.Imagenes_16x16.Images.SetKeyName(7, "tag_green.png")
        Me.Imagenes_16x16.Images.SetKeyName(8, "note_text.png")
        Me.Imagenes_16x16.Images.SetKeyName(9, "note.png")
        Me.Imagenes_16x16.Images.SetKeyName(10, "comment-number-1.png")
        Me.Imagenes_16x16.Images.SetKeyName(11, "comment-number-2.png")
        Me.Imagenes_16x16.Images.SetKeyName(12, "comment-number-3.png")
        Me.Imagenes_16x16.Images.SetKeyName(13, "comment-number-4.png")
        Me.Imagenes_16x16.Images.SetKeyName(14, "comment-number-5.png")
        Me.Imagenes_16x16.Images.SetKeyName(15, "comment-number-6.png")
        Me.Imagenes_16x16.Images.SetKeyName(16, "comment-number-7.png")
        Me.Imagenes_16x16.Images.SetKeyName(17, "comment-number-8.png")
        Me.Imagenes_16x16.Images.SetKeyName(18, "comment-number-9.png")
        Me.Imagenes_16x16.Images.SetKeyName(19, "comment-number-9-plus.png")
        Me.Imagenes_16x16.Images.SetKeyName(20, "menu-more.png")
        Me.Imagenes_16x16.Images.SetKeyName(21, "symbol-delete.png")
        Me.Imagenes_16x16.Images.SetKeyName(22, "symbol-ok-warning.png")
        Me.Imagenes_16x16.Images.SetKeyName(23, "symbol-remove.png")
        '
        'Imagenes_16x16_Dark
        '
        Me.Imagenes_16x16_Dark.ImageStream = CType(resources.GetObject("Imagenes_16x16_Dark.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.Imagenes_16x16_Dark.TransparentColor = System.Drawing.Color.Transparent
        Me.Imagenes_16x16_Dark.Images.SetKeyName(0, "warning.png")
        Me.Imagenes_16x16_Dark.Images.SetKeyName(1, "ok.png")
        Me.Imagenes_16x16_Dark.Images.SetKeyName(2, "cancel.png")
        Me.Imagenes_16x16_Dark.Images.SetKeyName(3, "delete_button_error.png")
        Me.Imagenes_16x16_Dark.Images.SetKeyName(4, "clock.png")
        Me.Imagenes_16x16_Dark.Images.SetKeyName(5, "clock-import.png")
        Me.Imagenes_16x16_Dark.Images.SetKeyName(6, "clock-info.png")
        Me.Imagenes_16x16_Dark.Images.SetKeyName(7, "tag_green.png")
        Me.Imagenes_16x16_Dark.Images.SetKeyName(8, "note_text.png")
        Me.Imagenes_16x16_Dark.Images.SetKeyName(9, "note.png")
        Me.Imagenes_16x16_Dark.Images.SetKeyName(10, "menu-more.png")
        Me.Imagenes_16x16_Dark.Images.SetKeyName(11, "comment-number-9.png")
        Me.Imagenes_16x16_Dark.Images.SetKeyName(12, "comment-number-9-plus.png")
        Me.Imagenes_16x16_Dark.Images.SetKeyName(13, "comment-number-8.png")
        Me.Imagenes_16x16_Dark.Images.SetKeyName(14, "comment-number-7.png")
        Me.Imagenes_16x16_Dark.Images.SetKeyName(15, "comment-number-6.png")
        Me.Imagenes_16x16_Dark.Images.SetKeyName(16, "comment-number-5.png")
        Me.Imagenes_16x16_Dark.Images.SetKeyName(17, "comment-number-4.png")
        Me.Imagenes_16x16_Dark.Images.SetKeyName(18, "comment-number-3.png")
        Me.Imagenes_16x16_Dark.Images.SetKeyName(19, "comment-number-2.png")
        Me.Imagenes_16x16_Dark.Images.SetKeyName(20, "comment-number-1.png")
        Me.Imagenes_16x16_Dark.Images.SetKeyName(21, "symbol-delete.png")
        Me.Imagenes_16x16_Dark.Images.SetKeyName(22, "symbol-ok-warning.png")
        Me.Imagenes_16x16_Dark.Images.SetKeyName(23, "symbol-remove.png")
        '
        'Frm_Cantidades_Ud_Disintas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(263, 142)
        Me.ControlBox = False
        Me.Controls.Add(Me.Img_RtuAPI)
        Me.Controls.Add(Me.Chk_RtuVariable)
        Me.Controls.Add(Me.TxtCantUD2)
        Me.Controls.Add(Me.TxtCantUD1)
        Me.Controls.Add(Me.Btn_Ver_Stock)
        Me.Controls.Add(Me.BtnAceptar)
        Me.Controls.Add(Me.LblUnidad2)
        Me.Controls.Add(Me.LblUnidad1)
        Me.Controls.Add(Me.TxtRTU)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Cantidades_Ud_Disintas"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ingreso cantidades"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents BtnAceptar As DevComponents.DotNetBar.ButtonX
    Public WithEvents LblUnidad2 As System.Windows.Forms.Label
    Public WithEvents LblUnidad1 As System.Windows.Forms.Label
    Public WithEvents TxtRTU As System.Windows.Forms.TextBox
    Friend WithEvents Btn_Ver_Stock As DevComponents.DotNetBar.ButtonX
    Friend WithEvents TxtCantUD1 As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents TxtCantUD2 As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Chk_RtuVariable As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Img_RtuAPI As DevComponents.DotNetBar.Controls.ReflectionImage
    Friend WithEvents Imagenes_16x16 As ImageList
    Friend WithEvents Imagenes_16x16_Dark As ImageList
End Class
