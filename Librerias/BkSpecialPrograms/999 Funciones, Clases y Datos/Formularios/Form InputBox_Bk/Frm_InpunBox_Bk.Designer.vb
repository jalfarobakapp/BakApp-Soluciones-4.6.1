<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_InpunBox_Bk
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_InpunBox_Bk))
        Me.TxtDescripcion = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Rf_Imagen = New DevComponents.DotNetBar.Controls.ReflectionImage()
        Me.BtnAceptar = New DevComponents.DotNetBar.ButtonX()
        Me.LblComentario_Centro = New DevComponents.DotNetBar.LabelX()
        Me.BtnCancelar = New DevComponents.DotNetBar.ButtonX()
        Me.TouchKeyboard1 = New DevComponents.DotNetBar.Keyboard.TouchKeyboard()
        Me.Imagenes_48x48_Ligth = New System.Windows.Forms.ImageList(Me.components)
        Me.Imagenes_48x48_Dark = New System.Windows.Forms.ImageList(Me.components)
        Me.Chk_1 = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Btn_BuscarCarpeta = New DevComponents.DotNetBar.ButtonX()
        Me.Btn_Calendario = New DevComponents.DotNetBar.ButtonX()
        Me.SuspendLayout()
        '
        'TxtDescripcion
        '
        Me.TxtDescripcion.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TxtDescripcion.Border.Class = "TextBoxBorder"
        Me.TxtDescripcion.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtDescripcion.DisabledBackColor = System.Drawing.Color.White
        Me.TxtDescripcion.ForeColor = System.Drawing.Color.Black
        Me.TxtDescripcion.Location = New System.Drawing.Point(7, 90)
        Me.TxtDescripcion.Multiline = True
        Me.TxtDescripcion.Name = "TxtDescripcion"
        Me.TxtDescripcion.PreventEnterBeep = True
        Me.TxtDescripcion.Size = New System.Drawing.Size(593, 69)
        Me.TxtDescripcion.TabIndex = 0
        Me.TxtDescripcion.Text = "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'Rf_Imagen
        '
        '
        '
        '
        Me.Rf_Imagen.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rf_Imagen.BackgroundStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.Rf_Imagen.Image = CType(resources.GetObject("Rf_Imagen.Image"), System.Drawing.Image)
        Me.Rf_Imagen.Location = New System.Drawing.Point(530, -7)
        Me.Rf_Imagen.Name = "Rf_Imagen"
        Me.Rf_Imagen.Size = New System.Drawing.Size(70, 91)
        Me.Rf_Imagen.TabIndex = 6
        '
        'BtnAceptar
        '
        Me.BtnAceptar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BtnAceptar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.BtnAceptar.Image = CType(resources.GetObject("BtnAceptar.Image"), System.Drawing.Image)
        Me.BtnAceptar.ImageAlt = CType(resources.GetObject("BtnAceptar.ImageAlt"), System.Drawing.Image)
        Me.BtnAceptar.Location = New System.Drawing.Point(8, 191)
        Me.BtnAceptar.Name = "BtnAceptar"
        Me.BtnAceptar.Size = New System.Drawing.Size(92, 38)
        Me.BtnAceptar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.BtnAceptar.TabIndex = 7
        Me.BtnAceptar.Text = "Aceptar"
        '
        'LblComentario_Centro
        '
        '
        '
        '
        Me.LblComentario_Centro.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LblComentario_Centro.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblComentario_Centro.Location = New System.Drawing.Point(12, 12)
        Me.LblComentario_Centro.Name = "LblComentario_Centro"
        Me.LblComentario_Centro.Size = New System.Drawing.Size(512, 72)
        Me.LblComentario_Centro.TabIndex = 9
        Me.LblComentario_Centro.Text = "Comentario..." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "XXXXXXXXXXYYYYYYYYYYCCCCCCCCCCXXXXXXXXX" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "XZZXDSREFTE" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.LblComentario_Centro.TextLineAlignment = System.Drawing.StringAlignment.Near
        '
        'BtnCancelar
        '
        Me.BtnCancelar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BtnCancelar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.BtnCancelar.Image = CType(resources.GetObject("BtnCancelar.Image"), System.Drawing.Image)
        Me.BtnCancelar.ImageAlt = CType(resources.GetObject("BtnCancelar.ImageAlt"), System.Drawing.Image)
        Me.BtnCancelar.Location = New System.Drawing.Point(106, 191)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(92, 38)
        Me.BtnCancelar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.BtnCancelar.TabIndex = 11
        Me.BtnCancelar.Text = "Cancelar"
        Me.BtnCancelar.Visible = False
        '
        'TouchKeyboard1
        '
        Me.TouchKeyboard1.FloatingLocation = New System.Drawing.Point(0, 0)
        Me.TouchKeyboard1.FloatingSize = New System.Drawing.Size(740, 250)
        Me.TouchKeyboard1.Location = New System.Drawing.Point(0, 0)
        Me.TouchKeyboard1.Size = New System.Drawing.Size(740, 250)
        Me.TouchKeyboard1.Text = ""
        '
        'Imagenes_48x48_Ligth
        '
        Me.Imagenes_48x48_Ligth.ImageStream = CType(resources.GetObject("Imagenes_48x48_Ligth.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.Imagenes_48x48_Ligth.TransparentColor = System.Drawing.Color.Transparent
        Me.Imagenes_48x48_Ligth.Images.SetKeyName(0, "Texto")
        Me.Imagenes_48x48_Ligth.Images.SetKeyName(1, "Editar_Tabla")
        Me.Imagenes_48x48_Ligth.Images.SetKeyName(2, "Buscar_documento")
        Me.Imagenes_48x48_Ligth.Images.SetKeyName(3, "Correo")
        Me.Imagenes_48x48_Ligth.Images.SetKeyName(4, "Alerta")
        Me.Imagenes_48x48_Ligth.Images.SetKeyName(5, "Ubicacion")
        Me.Imagenes_48x48_Ligth.Images.SetKeyName(6, "Transferencia_Bancaria")
        Me.Imagenes_48x48_Ligth.Images.SetKeyName(7, "Cheque_Numero")
        Me.Imagenes_48x48_Ligth.Images.SetKeyName(8, "Barra")
        Me.Imagenes_48x48_Ligth.Images.SetKeyName(9, "CodQR")
        Me.Imagenes_48x48_Ligth.Images.SetKeyName(10, "Imagen1")
        Me.Imagenes_48x48_Ligth.Images.SetKeyName(11, "Imagen2")
        Me.Imagenes_48x48_Ligth.Images.SetKeyName(12, "Key")
        Me.Imagenes_48x48_Ligth.Images.SetKeyName(13, "Money1")
        Me.Imagenes_48x48_Ligth.Images.SetKeyName(14, "Money2")
        Me.Imagenes_48x48_Ligth.Images.SetKeyName(15, "Storage")
        Me.Imagenes_48x48_Ligth.Images.SetKeyName(16, "Product")
        Me.Imagenes_48x48_Ligth.Images.SetKeyName(17, "Folder")
        Me.Imagenes_48x48_Ligth.Images.SetKeyName(18, "Fecha")
        '
        'Imagenes_48x48_Dark
        '
        Me.Imagenes_48x48_Dark.ImageStream = CType(resources.GetObject("Imagenes_48x48_Dark.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.Imagenes_48x48_Dark.TransparentColor = System.Drawing.Color.Transparent
        Me.Imagenes_48x48_Dark.Images.SetKeyName(0, "Texto")
        Me.Imagenes_48x48_Dark.Images.SetKeyName(1, "Editar_Tabla")
        Me.Imagenes_48x48_Dark.Images.SetKeyName(2, "Cheque_Numero")
        Me.Imagenes_48x48_Dark.Images.SetKeyName(3, "Transferencia_Bancaria")
        Me.Imagenes_48x48_Dark.Images.SetKeyName(4, "Ubicacion")
        Me.Imagenes_48x48_Dark.Images.SetKeyName(5, "Alerta")
        Me.Imagenes_48x48_Dark.Images.SetKeyName(6, "Correo")
        Me.Imagenes_48x48_Dark.Images.SetKeyName(7, "Buscar_documento")
        Me.Imagenes_48x48_Dark.Images.SetKeyName(8, "Barra")
        Me.Imagenes_48x48_Dark.Images.SetKeyName(9, "CodQR")
        Me.Imagenes_48x48_Dark.Images.SetKeyName(10, "Imagen2")
        Me.Imagenes_48x48_Dark.Images.SetKeyName(11, "Imagen1")
        Me.Imagenes_48x48_Dark.Images.SetKeyName(12, "Key")
        Me.Imagenes_48x48_Dark.Images.SetKeyName(13, "Money1")
        Me.Imagenes_48x48_Dark.Images.SetKeyName(14, "Money2")
        Me.Imagenes_48x48_Dark.Images.SetKeyName(15, "Storage")
        Me.Imagenes_48x48_Dark.Images.SetKeyName(16, "Product")
        Me.Imagenes_48x48_Dark.Images.SetKeyName(17, "Folder")
        Me.Imagenes_48x48_Dark.Images.SetKeyName(18, "Fecha")
        '
        'Chk_1
        '
        Me.Chk_1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Chk_1.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Chk_1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_1.CheckBoxImageChecked = CType(resources.GetObject("Chk_1.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_1.Checked = True
        Me.Chk_1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Chk_1.CheckValue = "Y"
        Me.Chk_1.FocusCuesEnabled = False
        Me.Chk_1.ForeColor = System.Drawing.Color.Black
        Me.Chk_1.Location = New System.Drawing.Point(8, 166)
        Me.Chk_1.Name = "Chk_1"
        Me.Chk_1.Size = New System.Drawing.Size(183, 19)
        Me.Chk_1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_1.TabIndex = 36
        Me.Chk_1.Text = "Mostrar vales transitorios"
        Me.Chk_1.Visible = False
        '
        'Btn_BuscarCarpeta
        '
        Me.Btn_BuscarCarpeta.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_BuscarCarpeta.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_BuscarCarpeta.Image = CType(resources.GetObject("Btn_BuscarCarpeta.Image"), System.Drawing.Image)
        Me.Btn_BuscarCarpeta.ImageAlt = CType(resources.GetObject("Btn_BuscarCarpeta.ImageAlt"), System.Drawing.Image)
        Me.Btn_BuscarCarpeta.Location = New System.Drawing.Point(468, 191)
        Me.Btn_BuscarCarpeta.Name = "Btn_BuscarCarpeta"
        Me.Btn_BuscarCarpeta.Size = New System.Drawing.Size(132, 38)
        Me.Btn_BuscarCarpeta.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_BuscarCarpeta.TabIndex = 37
        Me.Btn_BuscarCarpeta.Text = "Buscar carpeta..."
        '
        'Btn_Calendario
        '
        Me.Btn_Calendario.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Calendario.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Calendario.Image = CType(resources.GetObject("Btn_Calendario.Image"), System.Drawing.Image)
        Me.Btn_Calendario.ImageAlt = CType(resources.GetObject("Btn_Calendario.ImageAlt"), System.Drawing.Image)
        Me.Btn_Calendario.Location = New System.Drawing.Point(361, 191)
        Me.Btn_Calendario.Name = "Btn_Calendario"
        Me.Btn_Calendario.Size = New System.Drawing.Size(101, 38)
        Me.Btn_Calendario.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Calendario.TabIndex = 38
        Me.Btn_Calendario.Text = "Calendario"
        '
        'Frm_InpunBox_Bk
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(602, 231)
        Me.ControlBox = False
        Me.Controls.Add(Me.Btn_Calendario)
        Me.Controls.Add(Me.Btn_BuscarCarpeta)
        Me.Controls.Add(Me.Chk_1)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Controls.Add(Me.LblComentario_Centro)
        Me.Controls.Add(Me.BtnAceptar)
        Me.Controls.Add(Me.Rf_Imagen)
        Me.Controls.Add(Me.TxtDescripcion)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_InpunBox_Bk"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MetroForm"
        Me.TopLeftCornerSize = 50
        Me.TopMost = True
        Me.TopRightCornerSize = 50
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Rf_Imagen As DevComponents.DotNetBar.Controls.ReflectionImage
    Friend WithEvents BtnAceptar As DevComponents.DotNetBar.ButtonX
    Public WithEvents LblComentario_Centro As DevComponents.DotNetBar.LabelX
    Public WithEvents TxtDescripcion As DevComponents.DotNetBar.Controls.TextBoxX
    Public WithEvents BtnCancelar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents TouchKeyboard1 As DevComponents.DotNetBar.Keyboard.TouchKeyboard
    Friend WithEvents Imagenes_48x48_Ligth As ImageList
    Friend WithEvents Imagenes_48x48_Dark As ImageList
    Public WithEvents Chk_1 As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Btn_BuscarCarpeta As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Btn_Calendario As DevComponents.DotNetBar.ButtonX
End Class
