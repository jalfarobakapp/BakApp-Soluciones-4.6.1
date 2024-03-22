<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Validaciones
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Validaciones))
        Me.Lv_ListaDeMensajes = New DevComponents.DotNetBar.Controls.ListViewEx()
        Me.BtnCancelar = New DevComponents.DotNetBar.ButtonX()
        Me.Txt_Mensaje = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Imagenes_16x16 = New System.Windows.Forms.ImageList(Me.components)
        Me.Imagenes_16x16_Dark = New System.Windows.Forms.ImageList(Me.components)
        Me.SuspendLayout()
        '
        'Lv_ListaDeMensajes
        '
        Me.Lv_ListaDeMensajes.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Lv_ListaDeMensajes.Border.Class = "ListViewBorder"
        Me.Lv_ListaDeMensajes.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lv_ListaDeMensajes.DisabledBackColor = System.Drawing.Color.Empty
        Me.Lv_ListaDeMensajes.ForeColor = System.Drawing.Color.Black
        Me.Lv_ListaDeMensajes.GridLines = True
        Me.Lv_ListaDeMensajes.HideSelection = False
        Me.Lv_ListaDeMensajes.Location = New System.Drawing.Point(12, 12)
        Me.Lv_ListaDeMensajes.Name = "Lv_ListaDeMensajes"
        Me.Lv_ListaDeMensajes.Size = New System.Drawing.Size(629, 327)
        Me.Lv_ListaDeMensajes.TabIndex = 0
        Me.Lv_ListaDeMensajes.UseCompatibleStateImageBehavior = False
        Me.Lv_ListaDeMensajes.View = System.Windows.Forms.View.SmallIcon
        '
        'BtnCancelar
        '
        Me.BtnCancelar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BtnCancelar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.BtnCancelar.Image = CType(resources.GetObject("BtnCancelar.Image"), System.Drawing.Image)
        Me.BtnCancelar.ImageAlt = CType(resources.GetObject("BtnCancelar.ImageAlt"), System.Drawing.Image)
        Me.BtnCancelar.Location = New System.Drawing.Point(12, 448)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(82, 38)
        Me.BtnCancelar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.BtnCancelar.TabIndex = 12
        Me.BtnCancelar.Text = "Cerrar"
        '
        'Txt_Mensaje
        '
        Me.Txt_Mensaje.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Mensaje.Border.Class = "TextBoxBorder"
        Me.Txt_Mensaje.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Mensaje.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Mensaje.ForeColor = System.Drawing.Color.Black
        Me.Txt_Mensaje.Location = New System.Drawing.Point(12, 345)
        Me.Txt_Mensaje.Multiline = True
        Me.Txt_Mensaje.Name = "Txt_Mensaje"
        Me.Txt_Mensaje.PreventEnterBeep = True
        Me.Txt_Mensaje.ReadOnly = True
        Me.Txt_Mensaje.Size = New System.Drawing.Size(629, 97)
        Me.Txt_Mensaje.TabIndex = 13
        '
        'Imagenes_16x16
        '
        Me.Imagenes_16x16.ImageStream = CType(resources.GetObject("Imagenes_16x16.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.Imagenes_16x16.TransparentColor = System.Drawing.Color.Transparent
        Me.Imagenes_16x16.Images.SetKeyName(0, "button-ok.png")
        Me.Imagenes_16x16.Images.SetKeyName(1, "symbol-delete.png")
        Me.Imagenes_16x16.Images.SetKeyName(2, "button-cancel.png")
        Me.Imagenes_16x16.Images.SetKeyName(3, "symbol-forbidden.png")
        '
        'Imagenes_16x16_Dark
        '
        Me.Imagenes_16x16_Dark.ImageStream = CType(resources.GetObject("Imagenes_16x16_Dark.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.Imagenes_16x16_Dark.TransparentColor = System.Drawing.Color.Transparent
        Me.Imagenes_16x16_Dark.Images.SetKeyName(0, "button-ok.png")
        Me.Imagenes_16x16_Dark.Images.SetKeyName(1, "symbol-delete.png")
        Me.Imagenes_16x16_Dark.Images.SetKeyName(2, "button-cancel.png")
        Me.Imagenes_16x16_Dark.Images.SetKeyName(3, "symbol-forbidden.png")
        '
        'Frm_Validaciones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(653, 498)
        Me.Controls.Add(Me.Txt_Mensaje)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Controls.Add(Me.Lv_ListaDeMensajes)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Validaciones"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = " "
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Lv_ListaDeMensajes As DevComponents.DotNetBar.Controls.ListViewEx
    Public WithEvents BtnCancelar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Txt_Mensaje As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Imagenes_16x16 As ImageList
    Friend WithEvents Imagenes_16x16_Dark As ImageList
End Class
