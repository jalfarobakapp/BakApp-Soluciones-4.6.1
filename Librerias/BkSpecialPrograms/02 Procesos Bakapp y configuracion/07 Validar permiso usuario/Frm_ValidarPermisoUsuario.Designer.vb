<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_ValidarPermisoUsuario
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_ValidarPermisoUsuario))
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Autorizar_Permiso = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Permiso_Remoto = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Solicitar_Al_Grabar_Documento = New DevComponents.DotNetBar.ButtonItem()
        Me.BtnOtorgarPermisoPermanente = New DevComponents.DotNetBar.ButtonItem()
        Me.ReflectionLabel1 = New DevComponents.DotNetBar.Controls.ReflectionLabel()
        Me.LblCodPermiso = New DevComponents.DotNetBar.LabelX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.ReflectionImage1 = New DevComponents.DotNetBar.Controls.ReflectionImage()
        Me.Context_Menu_Solicitud_Compra = New DevComponents.DotNetBar.ContextMenuBar()
        Me.Menu_Contextual_01 = New DevComponents.DotNetBar.ButtonItem()
        Me.Lbl_Mnu_1 = New DevComponents.DotNetBar.LabelItem()
        Me.Btn_Solicitar_Usuario_Seleccionado = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Solicitar_Usuarios_Todos = New DevComponents.DotNetBar.ButtonItem()
        Me.Menu_Contextual_02 = New DevComponents.DotNetBar.ButtonItem()
        Me.LabelItem2 = New DevComponents.DotNetBar.LabelItem()
        Me.Btn_Mnu_Remoto_y_esperar = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Remoto_y_no_esperar = New DevComponents.DotNetBar.ButtonItem()
        Me.LblDescripcionPermiso = New System.Windows.Forms.Label()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Context_Menu_Solicitud_Compra, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Autorizar_Permiso, Me.Btn_Permiso_Remoto, Me.Btn_Solicitar_Al_Grabar_Documento, Me.BtnOtorgarPermisoPermanente})
        Me.Bar1.Location = New System.Drawing.Point(0, 198)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(591, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 25
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'Btn_Autorizar_Permiso
        '
        Me.Btn_Autorizar_Permiso.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Autorizar_Permiso.ForeColor = System.Drawing.Color.Black
        Me.Btn_Autorizar_Permiso.Image = CType(resources.GetObject("Btn_Autorizar_Permiso.Image"), System.Drawing.Image)
        Me.Btn_Autorizar_Permiso.ImageAlt = CType(resources.GetObject("Btn_Autorizar_Permiso.ImageAlt"), System.Drawing.Image)
        Me.Btn_Autorizar_Permiso.Name = "Btn_Autorizar_Permiso"
        Me.Btn_Autorizar_Permiso.Text = "Ingresar clave<br/>de autorización"
        '
        'Btn_Permiso_Remoto
        '
        Me.Btn_Permiso_Remoto.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Permiso_Remoto.ForeColor = System.Drawing.Color.Black
        Me.Btn_Permiso_Remoto.Image = CType(resources.GetObject("Btn_Permiso_Remoto.Image"), System.Drawing.Image)
        Me.Btn_Permiso_Remoto.ImageAlt = CType(resources.GetObject("Btn_Permiso_Remoto.ImageAlt"), System.Drawing.Image)
        Me.Btn_Permiso_Remoto.Name = "Btn_Permiso_Remoto"
        Me.Btn_Permiso_Remoto.Text = "Solicitar <br/>permiso remoto"
        '
        'Btn_Solicitar_Al_Grabar_Documento
        '
        Me.Btn_Solicitar_Al_Grabar_Documento.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Solicitar_Al_Grabar_Documento.ForeColor = System.Drawing.Color.Black
        Me.Btn_Solicitar_Al_Grabar_Documento.Image = CType(resources.GetObject("Btn_Solicitar_Al_Grabar_Documento.Image"), System.Drawing.Image)
        Me.Btn_Solicitar_Al_Grabar_Documento.ImageAlt = CType(resources.GetObject("Btn_Solicitar_Al_Grabar_Documento.ImageAlt"), System.Drawing.Image)
        Me.Btn_Solicitar_Al_Grabar_Documento.Name = "Btn_Solicitar_Al_Grabar_Documento"
        Me.Btn_Solicitar_Al_Grabar_Documento.Text = "Solicitar permiso al final<br/>de grabar el documento"
        '
        'BtnOtorgarPermisoPermanente
        '
        Me.BtnOtorgarPermisoPermanente.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnOtorgarPermisoPermanente.ForeColor = System.Drawing.Color.Black
        Me.BtnOtorgarPermisoPermanente.Image = CType(resources.GetObject("BtnOtorgarPermisoPermanente.Image"), System.Drawing.Image)
        Me.BtnOtorgarPermisoPermanente.ImageAlt = CType(resources.GetObject("BtnOtorgarPermisoPermanente.ImageAlt"), System.Drawing.Image)
        Me.BtnOtorgarPermisoPermanente.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.BtnOtorgarPermisoPermanente.Name = "BtnOtorgarPermisoPermanente"
        Me.BtnOtorgarPermisoPermanente.Tooltip = "Otorgar el permiso permanentemente"
        '
        'ReflectionLabel1
        '
        Me.ReflectionLabel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        '
        '
        '
        Me.ReflectionLabel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ReflectionLabel1.ForeColor = System.Drawing.Color.Black
        Me.ReflectionLabel1.Location = New System.Drawing.Point(62, 11)
        Me.ReflectionLabel1.Name = "ReflectionLabel1"
        Me.ReflectionLabel1.Size = New System.Drawing.Size(408, 52)
        Me.ReflectionLabel1.TabIndex = 26
        Me.ReflectionLabel1.Text = "<b><font size=""+4" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & """><i></i><font color=""#B02B2C"">Usted no posee permiso para rea" &
    "lizar esta acción</font></font></b>"
        '
        'LblCodPermiso
        '
        Me.LblCodPermiso.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LblCodPermiso.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LblCodPermiso.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCodPermiso.ForeColor = System.Drawing.Color.Black
        Me.LblCodPermiso.Location = New System.Drawing.Point(85, 69)
        Me.LblCodPermiso.Name = "LblCodPermiso"
        Me.LblCodPermiso.Size = New System.Drawing.Size(146, 23)
        Me.LblCodPermiso.TabIndex = 1
        Me.LblCodPermiso.Text = "LabelX2"
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX1.ForeColor = System.Drawing.Color.Black
        Me.LabelX1.Location = New System.Drawing.Point(12, 66)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(61, 28)
        Me.LabelX1.TabIndex = 0
        Me.LabelX1.Text = "Código :"
        '
        'ReflectionImage1
        '
        Me.ReflectionImage1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        '
        '
        '
        Me.ReflectionImage1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ReflectionImage1.BackgroundStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.ReflectionImage1.ForeColor = System.Drawing.Color.Black
        Me.ReflectionImage1.Image = CType(resources.GetObject("ReflectionImage1.Image"), System.Drawing.Image)
        Me.ReflectionImage1.Location = New System.Drawing.Point(12, 11)
        Me.ReflectionImage1.Name = "ReflectionImage1"
        Me.ReflectionImage1.Size = New System.Drawing.Size(44, 49)
        Me.ReflectionImage1.TabIndex = 28
        '
        'Context_Menu_Solicitud_Compra
        '
        Me.Context_Menu_Solicitud_Compra.AntiAlias = True
        Me.Context_Menu_Solicitud_Compra.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Context_Menu_Solicitud_Compra.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Menu_Contextual_01, Me.Menu_Contextual_02})
        Me.Context_Menu_Solicitud_Compra.Location = New System.Drawing.Point(313, 73)
        Me.Context_Menu_Solicitud_Compra.Name = "Context_Menu_Solicitud_Compra"
        Me.Context_Menu_Solicitud_Compra.Size = New System.Drawing.Size(262, 25)
        Me.Context_Menu_Solicitud_Compra.Stretch = True
        Me.Context_Menu_Solicitud_Compra.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Context_Menu_Solicitud_Compra.TabIndex = 50
        Me.Context_Menu_Solicitud_Compra.TabStop = False
        Me.Context_Menu_Solicitud_Compra.Text = "ContextMenuBar1"
        '
        'Menu_Contextual_01
        '
        Me.Menu_Contextual_01.AutoExpandOnClick = True
        Me.Menu_Contextual_01.Name = "Menu_Contextual_01"
        Me.Menu_Contextual_01.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Lbl_Mnu_1, Me.Btn_Solicitar_Usuario_Seleccionado, Me.Btn_Solicitar_Usuarios_Todos})
        Me.Menu_Contextual_01.Text = "Opciones"
        '
        'Lbl_Mnu_1
        '
        Me.Lbl_Mnu_1.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.Lbl_Mnu_1.BorderSide = DevComponents.DotNetBar.eBorderSide.Bottom
        Me.Lbl_Mnu_1.BorderType = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.Lbl_Mnu_1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(21, Byte), Integer), CType(CType(110, Byte), Integer))
        Me.Lbl_Mnu_1.Name = "Lbl_Mnu_1"
        Me.Lbl_Mnu_1.PaddingBottom = 1
        Me.Lbl_Mnu_1.PaddingLeft = 10
        Me.Lbl_Mnu_1.PaddingTop = 1
        Me.Lbl_Mnu_1.SingleLineColor = System.Drawing.Color.FromArgb(CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer))
        Me.Lbl_Mnu_1.Text = "Solicitar permiso remoto"
        '
        'Btn_Solicitar_Usuario_Seleccionado
        '
        Me.Btn_Solicitar_Usuario_Seleccionado.Image = CType(resources.GetObject("Btn_Solicitar_Usuario_Seleccionado.Image"), System.Drawing.Image)
        Me.Btn_Solicitar_Usuario_Seleccionado.Name = "Btn_Solicitar_Usuario_Seleccionado"
        Me.Btn_Solicitar_Usuario_Seleccionado.Text = "Enviar solicitud a un usario en particular"
        '
        'Btn_Solicitar_Usuarios_Todos
        '
        Me.Btn_Solicitar_Usuarios_Todos.Image = CType(resources.GetObject("Btn_Solicitar_Usuarios_Todos.Image"), System.Drawing.Image)
        Me.Btn_Solicitar_Usuarios_Todos.Name = "Btn_Solicitar_Usuarios_Todos"
        Me.Btn_Solicitar_Usuarios_Todos.Text = "Enviar solicitud a todos los usuarios con este permiso"
        '
        'Menu_Contextual_02
        '
        Me.Menu_Contextual_02.AutoExpandOnClick = True
        Me.Menu_Contextual_02.Name = "Menu_Contextual_02"
        Me.Menu_Contextual_02.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItem2, Me.Btn_Mnu_Remoto_y_esperar, Me.Btn_Remoto_y_no_esperar})
        Me.Menu_Contextual_02.Text = "Opciones"
        '
        'LabelItem2
        '
        Me.LabelItem2.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.LabelItem2.BorderSide = DevComponents.DotNetBar.eBorderSide.Bottom
        Me.LabelItem2.BorderType = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.LabelItem2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(21, Byte), Integer), CType(CType(110, Byte), Integer))
        Me.LabelItem2.Name = "LabelItem2"
        Me.LabelItem2.PaddingBottom = 1
        Me.LabelItem2.PaddingLeft = 10
        Me.LabelItem2.PaddingTop = 1
        Me.LabelItem2.SingleLineColor = System.Drawing.Color.FromArgb(CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer))
        Me.LabelItem2.Text = "Solicitar permiso remoto"
        '
        'Btn_Mnu_Remoto_y_esperar
        '
        Me.Btn_Mnu_Remoto_y_esperar.Image = CType(resources.GetObject("Btn_Mnu_Remoto_y_esperar.Image"), System.Drawing.Image)
        Me.Btn_Mnu_Remoto_y_esperar.Name = "Btn_Mnu_Remoto_y_esperar"
        Me.Btn_Mnu_Remoto_y_esperar.Text = "Solicitar permiso remoto y esperar en línea"
        '
        'Btn_Remoto_y_no_esperar
        '
        Me.Btn_Remoto_y_no_esperar.Image = CType(resources.GetObject("Btn_Remoto_y_no_esperar.Image"), System.Drawing.Image)
        Me.Btn_Remoto_y_no_esperar.Name = "Btn_Remoto_y_no_esperar"
        Me.Btn_Remoto_y_no_esperar.Text = "Solicitar permiso remoto y no esperar"
        '
        'LblDescripcionPermiso
        '
        Me.LblDescripcionPermiso.BackColor = System.Drawing.Color.Transparent
        Me.LblDescripcionPermiso.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LblDescripcionPermiso.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblDescripcionPermiso.Location = New System.Drawing.Point(12, 101)
        Me.LblDescripcionPermiso.Name = "LblDescripcionPermiso"
        Me.LblDescripcionPermiso.Size = New System.Drawing.Size(567, 90)
        Me.LblDescripcionPermiso.TabIndex = 3
        Me.LblDescripcionPermiso.Text = "Label1 naj akshd ashd kjass dkas kdh askhd kashd kjas kdhaks dhkjash dkas" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'Frm_ValidarPermisoUsuario
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(591, 239)
        Me.Controls.Add(Me.Context_Menu_Solicitud_Compra)
        Me.Controls.Add(Me.LabelX1)
        Me.Controls.Add(Me.ReflectionImage1)
        Me.Controls.Add(Me.LblDescripcionPermiso)
        Me.Controls.Add(Me.ReflectionLabel1)
        Me.Controls.Add(Me.LblCodPermiso)
        Me.Controls.Add(Me.Bar1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_ValidarPermisoUsuario"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Permiso de usuario"
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Context_Menu_Solicitud_Compra, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents ReflectionLabel1 As DevComponents.DotNetBar.Controls.ReflectionLabel
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LblCodPermiso As DevComponents.DotNetBar.LabelX
    Friend WithEvents Btn_Permiso_Remoto As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ReflectionImage1 As DevComponents.DotNetBar.Controls.ReflectionImage
    Friend WithEvents BtnOtorgarPermisoPermanente As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Context_Menu_Solicitud_Compra As DevComponents.DotNetBar.ContextMenuBar
    Public WithEvents Menu_Contextual_01 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Lbl_Mnu_1 As DevComponents.DotNetBar.LabelItem
    Public WithEvents Btn_Solicitar_Usuario_Seleccionado As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_Solicitar_Usuarios_Todos As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LblDescripcionPermiso As System.Windows.Forms.Label
    Public WithEvents Menu_Contextual_02 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelItem2 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents Btn_Mnu_Remoto_y_esperar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Remoto_y_no_esperar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Autorizar_Permiso As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Solicitar_Al_Grabar_Documento As DevComponents.DotNetBar.ButtonItem
End Class
