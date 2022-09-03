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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_InpunBox_Bk))
        Me.TxtDescripcion = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.Rf_Imagen = New DevComponents.DotNetBar.Controls.ReflectionImage
        Me.BtnAceptar = New DevComponents.DotNetBar.ButtonX
        Me.LblComentario_Centro = New DevComponents.DotNetBar.LabelX
        Me.BtnCancelar = New DevComponents.DotNetBar.ButtonX
        Me.TouchKeyboard1 = New DevComponents.DotNetBar.Keyboard.TouchKeyboard
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
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
        Me.TxtDescripcion.Location = New System.Drawing.Point(4, 120)
        Me.TxtDescripcion.Multiline = True
        Me.TxtDescripcion.Name = "TxtDescripcion"
        Me.TxtDescripcion.PreventEnterBeep = True
        Me.TxtDescripcion.Size = New System.Drawing.Size(443, 56)
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
        Me.Rf_Imagen.Image = Global.Funciones_BakApp.My.Resources.Resources.comment_edit
        Me.Rf_Imagen.Location = New System.Drawing.Point(12, 12)
        Me.Rf_Imagen.Name = "Rf_Imagen"
        Me.Rf_Imagen.Size = New System.Drawing.Size(105, 102)
        Me.Rf_Imagen.TabIndex = 6
        '
        'BtnAceptar
        '
        Me.BtnAceptar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BtnAceptar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.BtnAceptar.Image = Global.Funciones_BakApp.My.Resources.Resources.ok_button
        Me.BtnAceptar.Location = New System.Drawing.Point(338, 3)
        Me.BtnAceptar.Name = "BtnAceptar"
        Me.BtnAceptar.Size = New System.Drawing.Size(107, 38)
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
        Me.LblComentario_Centro.Location = New System.Drawing.Point(106, 12)
        Me.LblComentario_Centro.Name = "LblComentario_Centro"
        Me.LblComentario_Centro.Size = New System.Drawing.Size(217, 87)
        Me.LblComentario_Centro.TabIndex = 9
        Me.LblComentario_Centro.Text = "Comentario..."
        Me.LblComentario_Centro.TextLineAlignment = System.Drawing.StringAlignment.Near
        '
        'BtnCancelar
        '
        Me.BtnCancelar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BtnCancelar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.BtnCancelar.Image = CType(resources.GetObject("BtnCancelar.Image"), System.Drawing.Image)
        Me.BtnCancelar.Location = New System.Drawing.Point(338, 47)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(107, 38)
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
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "Barra")
        Me.ImageList1.Images.SetKeyName(1, "Texto")
        Me.ImageList1.Images.SetKeyName(2, "Editar_Tabla")
        Me.ImageList1.Images.SetKeyName(3, "Buscar_Documento")
        Me.ImageList1.Images.SetKeyName(4, "Transferencia_Bancaria")
        Me.ImageList1.Images.SetKeyName(5, "Ubicacion")
        Me.ImageList1.Images.SetKeyName(6, "Correo")
        Me.ImageList1.Images.SetKeyName(7, "Cheque_Numero")
        '
        'Frm_InpunBox_Bk
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(453, 185)
        Me.ControlBox = False
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
        Me.TopMost = True
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Rf_Imagen As DevComponents.DotNetBar.Controls.ReflectionImage
    Friend WithEvents BtnAceptar As DevComponents.DotNetBar.ButtonX
    Public WithEvents LblComentario_Centro As DevComponents.DotNetBar.LabelX
    Public WithEvents TxtDescripcion As DevComponents.DotNetBar.Controls.TextBoxX
    Public WithEvents BtnCancelar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents TouchKeyboard1 As DevComponents.DotNetBar.Keyboard.TouchKeyboard
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
End Class
