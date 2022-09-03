<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_RcSe_Ges_Sub_Estados
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_RcSe_Ges_Sub_Estados))
        Me.Bar2 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Fijar_Estado = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Archivos_Adjuntos = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Grabar = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Editar = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Cancelar = New DevComponents.DotNetBar.ButtonItem()
        Me.Lbl_Documento = New DevComponents.DotNetBar.LabelX()
        Me.Grupo_Documento_Adjunto = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Lbl_Fecha_recepcion = New DevComponents.DotNetBar.LabelX()
        Me.Lbl_Receptor = New DevComponents.DotNetBar.LabelX()
        Me.Btn_Quitar_Documento = New DevComponents.DotNetBar.ButtonX()
        Me.Btn_Ver_Documento = New DevComponents.DotNetBar.ButtonX()
        Me.Btn_Adjuntar_Doc = New DevComponents.DotNetBar.ButtonX()
        Me.Grupo_Observaciones = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Imagenes_32x32 = New System.Windows.Forms.ImageList(Me.components)
        Me.Txt_Observacion = New DevComponents.DotNetBar.Controls.TextBoxX()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Grupo_Documento_Adjunto.SuspendLayout()
        Me.Grupo_Observaciones.SuspendLayout()
        Me.SuspendLayout()
        '
        'Bar2
        '
        Me.Bar2.AntiAlias = True
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Fijar_Estado, Me.Btn_Archivos_Adjuntos, Me.Btn_Grabar, Me.Btn_Editar, Me.Btn_Cancelar})
        Me.Bar2.Location = New System.Drawing.Point(0, 299)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(557, 41)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Bar2.TabIndex = 89
        Me.Bar2.TabStop = False
        Me.Bar2.Text = "Bar2"
        '
        'Btn_Fijar_Estado
        '
        Me.Btn_Fijar_Estado.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Fijar_Estado.ForeColor = System.Drawing.Color.Black
        Me.Btn_Fijar_Estado.Image = CType(resources.GetObject("Btn_Fijar_Estado.Image"), System.Drawing.Image)
        Me.Btn_Fijar_Estado.Name = "Btn_Fijar_Estado"
        Me.Btn_Fijar_Estado.Text = "ACEPTAR"
        Me.Btn_Fijar_Estado.Tooltip = "Fijar estado"
        '
        'Btn_Archivos_Adjuntos
        '
        Me.Btn_Archivos_Adjuntos.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Archivos_Adjuntos.ForeColor = System.Drawing.Color.Black
        Me.Btn_Archivos_Adjuntos.Image = CType(resources.GetObject("Btn_Archivos_Adjuntos.Image"), System.Drawing.Image)
        Me.Btn_Archivos_Adjuntos.Name = "Btn_Archivos_Adjuntos"
        Me.Btn_Archivos_Adjuntos.Tooltip = "Archivos adjuntos"
        '
        'Btn_Grabar
        '
        Me.Btn_Grabar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Grabar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Grabar.Image = CType(resources.GetObject("Btn_Grabar.Image"), System.Drawing.Image)
        Me.Btn_Grabar.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.Btn_Grabar.Name = "Btn_Grabar"
        Me.Btn_Grabar.Tooltip = "Grabar [F4]"
        Me.Btn_Grabar.Visible = False
        '
        'Btn_Editar
        '
        Me.Btn_Editar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Editar.FontBold = True
        Me.Btn_Editar.ForeColor = System.Drawing.Color.Red
        Me.Btn_Editar.Image = CType(resources.GetObject("Btn_Editar.Image"), System.Drawing.Image)
        Me.Btn_Editar.Name = "Btn_Editar"
        Me.Btn_Editar.Tooltip = "Editar"
        Me.Btn_Editar.Visible = False
        '
        'Btn_Cancelar
        '
        Me.Btn_Cancelar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Cancelar.FontBold = True
        Me.Btn_Cancelar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Cancelar.Image = CType(resources.GetObject("Btn_Cancelar.Image"), System.Drawing.Image)
        Me.Btn_Cancelar.Name = "Btn_Cancelar"
        Me.Btn_Cancelar.Text = "Cancelar edición"
        Me.Btn_Cancelar.Visible = False
        '
        'Lbl_Documento
        '
        Me.Lbl_Documento.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_Documento.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Documento.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Documento.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Documento.Location = New System.Drawing.Point(3, 7)
        Me.Lbl_Documento.Name = "Lbl_Documento"
        Me.Lbl_Documento.Size = New System.Drawing.Size(395, 23)
        Me.Lbl_Documento.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Lbl_Documento.TabIndex = 121
        Me.Lbl_Documento.Text = "Número :"
        '
        'Grupo_Documento_Adjunto
        '
        Me.Grupo_Documento_Adjunto.BackColor = System.Drawing.Color.White
        Me.Grupo_Documento_Adjunto.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Grupo_Documento_Adjunto.Controls.Add(Me.Lbl_Fecha_recepcion)
        Me.Grupo_Documento_Adjunto.Controls.Add(Me.Lbl_Receptor)
        Me.Grupo_Documento_Adjunto.Controls.Add(Me.Btn_Quitar_Documento)
        Me.Grupo_Documento_Adjunto.Controls.Add(Me.Btn_Ver_Documento)
        Me.Grupo_Documento_Adjunto.Controls.Add(Me.Btn_Adjuntar_Doc)
        Me.Grupo_Documento_Adjunto.Controls.Add(Me.Lbl_Documento)
        Me.Grupo_Documento_Adjunto.DisabledBackColor = System.Drawing.Color.Empty
        Me.Grupo_Documento_Adjunto.Location = New System.Drawing.Point(12, 12)
        Me.Grupo_Documento_Adjunto.Name = "Grupo_Documento_Adjunto"
        Me.Grupo_Documento_Adjunto.Size = New System.Drawing.Size(537, 110)
        '
        '
        '
        Me.Grupo_Documento_Adjunto.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Grupo_Documento_Adjunto.Style.BackColorGradientAngle = 90
        Me.Grupo_Documento_Adjunto.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Grupo_Documento_Adjunto.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Documento_Adjunto.Style.BorderBottomWidth = 1
        Me.Grupo_Documento_Adjunto.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.Grupo_Documento_Adjunto.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Documento_Adjunto.Style.BorderLeftWidth = 1
        Me.Grupo_Documento_Adjunto.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Documento_Adjunto.Style.BorderRightWidth = 1
        Me.Grupo_Documento_Adjunto.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Documento_Adjunto.Style.BorderTopWidth = 1
        Me.Grupo_Documento_Adjunto.Style.CornerDiameter = 4
        Me.Grupo_Documento_Adjunto.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Grupo_Documento_Adjunto.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.Grupo_Documento_Adjunto.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.Grupo_Documento_Adjunto.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.Grupo_Documento_Adjunto.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.Grupo_Documento_Adjunto.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Grupo_Documento_Adjunto.TabIndex = 91
        Me.Grupo_Documento_Adjunto.Text = "Documento adjunto"
        '
        'Lbl_Fecha_recepcion
        '
        Me.Lbl_Fecha_recepcion.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_Fecha_recepcion.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Fecha_recepcion.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Fecha_recepcion.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Fecha_recepcion.Location = New System.Drawing.Point(3, 54)
        Me.Lbl_Fecha_recepcion.Name = "Lbl_Fecha_recepcion"
        Me.Lbl_Fecha_recepcion.Size = New System.Drawing.Size(187, 23)
        Me.Lbl_Fecha_recepcion.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Lbl_Fecha_recepcion.TabIndex = 126
        Me.Lbl_Fecha_recepcion.Text = "Fecha recepción :"
        '
        'Lbl_Receptor
        '
        Me.Lbl_Receptor.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_Receptor.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Receptor.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Receptor.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Receptor.Location = New System.Drawing.Point(3, 30)
        Me.Lbl_Receptor.Name = "Lbl_Receptor"
        Me.Lbl_Receptor.Size = New System.Drawing.Size(187, 23)
        Me.Lbl_Receptor.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Lbl_Receptor.TabIndex = 125
        Me.Lbl_Receptor.Text = "Receptor :"
        '
        'Btn_Quitar_Documento
        '
        Me.Btn_Quitar_Documento.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Quitar_Documento.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Quitar_Documento.Image = CType(resources.GetObject("Btn_Quitar_Documento.Image"), System.Drawing.Image)
        Me.Btn_Quitar_Documento.Location = New System.Drawing.Point(497, 8)
        Me.Btn_Quitar_Documento.Name = "Btn_Quitar_Documento"
        Me.Btn_Quitar_Documento.Size = New System.Drawing.Size(31, 22)
        Me.Btn_Quitar_Documento.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Quitar_Documento.TabIndex = 124
        Me.Btn_Quitar_Documento.TabStop = False
        Me.Btn_Quitar_Documento.Tooltip = "Quitar documento"
        '
        'Btn_Ver_Documento
        '
        Me.Btn_Ver_Documento.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Ver_Documento.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Ver_Documento.Image = CType(resources.GetObject("Btn_Ver_Documento.Image"), System.Drawing.Image)
        Me.Btn_Ver_Documento.Location = New System.Drawing.Point(460, 8)
        Me.Btn_Ver_Documento.Name = "Btn_Ver_Documento"
        Me.Btn_Ver_Documento.Size = New System.Drawing.Size(31, 22)
        Me.Btn_Ver_Documento.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Ver_Documento.TabIndex = 123
        Me.Btn_Ver_Documento.TabStop = False
        Me.Btn_Ver_Documento.Tooltip = "Ver documento"
        '
        'Btn_Adjuntar_Doc
        '
        Me.Btn_Adjuntar_Doc.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Adjuntar_Doc.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Adjuntar_Doc.Image = CType(resources.GetObject("Btn_Adjuntar_Doc.Image"), System.Drawing.Image)
        Me.Btn_Adjuntar_Doc.Location = New System.Drawing.Point(423, 8)
        Me.Btn_Adjuntar_Doc.Name = "Btn_Adjuntar_Doc"
        Me.Btn_Adjuntar_Doc.Size = New System.Drawing.Size(31, 22)
        Me.Btn_Adjuntar_Doc.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Adjuntar_Doc.TabIndex = 122
        Me.Btn_Adjuntar_Doc.TabStop = False
        Me.Btn_Adjuntar_Doc.Tooltip = "Adjuntar documento"
        '
        'Grupo_Observaciones
        '
        Me.Grupo_Observaciones.BackColor = System.Drawing.Color.White
        Me.Grupo_Observaciones.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Grupo_Observaciones.Controls.Add(Me.Txt_Observacion)
        Me.Grupo_Observaciones.DisabledBackColor = System.Drawing.Color.Empty
        Me.Grupo_Observaciones.Location = New System.Drawing.Point(12, 128)
        Me.Grupo_Observaciones.Name = "Grupo_Observaciones"
        Me.Grupo_Observaciones.Size = New System.Drawing.Size(537, 165)
        '
        '
        '
        Me.Grupo_Observaciones.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Grupo_Observaciones.Style.BackColorGradientAngle = 90
        Me.Grupo_Observaciones.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Grupo_Observaciones.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Observaciones.Style.BorderBottomWidth = 1
        Me.Grupo_Observaciones.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.Grupo_Observaciones.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Observaciones.Style.BorderLeftWidth = 1
        Me.Grupo_Observaciones.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Observaciones.Style.BorderRightWidth = 1
        Me.Grupo_Observaciones.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Observaciones.Style.BorderTopWidth = 1
        Me.Grupo_Observaciones.Style.CornerDiameter = 4
        Me.Grupo_Observaciones.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Grupo_Observaciones.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.Grupo_Observaciones.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.Grupo_Observaciones.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.Grupo_Observaciones.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.Grupo_Observaciones.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Grupo_Observaciones.TabIndex = 92
        Me.Grupo_Observaciones.Text = "Observaciones"
        '
        'Imagenes_32x32
        '
        Me.Imagenes_32x32.ImageStream = CType(resources.GetObject("Imagenes_32x32.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.Imagenes_32x32.TransparentColor = System.Drawing.Color.Transparent
        Me.Imagenes_32x32.Images.SetKeyName(0, "warning.png")
        Me.Imagenes_32x32.Images.SetKeyName(1, "Warning 32.png")
        '
        'Txt_Observacion
        '
        Me.Txt_Observacion.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Observacion.Border.Class = "TextBoxBorder"
        Me.Txt_Observacion.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Observacion.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Observacion.ForeColor = System.Drawing.Color.Black
        Me.Txt_Observacion.Location = New System.Drawing.Point(3, 3)
        Me.Txt_Observacion.Multiline = True
        Me.Txt_Observacion.Name = "Txt_Observacion"
        Me.Txt_Observacion.PreventEnterBeep = True
        Me.Txt_Observacion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.Txt_Observacion.Size = New System.Drawing.Size(525, 136)
        Me.Txt_Observacion.TabIndex = 3
        '
        'Frm_RcSe_Ges_Sub_Estados
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(557, 340)
        Me.Controls.Add(Me.Grupo_Observaciones)
        Me.Controls.Add(Me.Grupo_Documento_Adjunto)
        Me.Controls.Add(Me.Bar2)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_RcSe_Ges_Sub_Estados"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MetroForm"
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Grupo_Documento_Adjunto.ResumeLayout(False)
        Me.Grupo_Observaciones.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Public WithEvents Btn_Archivos_Adjuntos As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Lbl_Documento As DevComponents.DotNetBar.LabelX
    Friend WithEvents Grupo_Documento_Adjunto As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Btn_Quitar_Documento As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Btn_Ver_Documento As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Btn_Adjuntar_Doc As DevComponents.DotNetBar.ButtonX
    Public WithEvents Btn_Fijar_Estado As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_Editar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Grabar As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_Cancelar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Grupo_Observaciones As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Lbl_Fecha_recepcion As DevComponents.DotNetBar.LabelX
    Friend WithEvents Lbl_Receptor As DevComponents.DotNetBar.LabelX
    Friend WithEvents Imagenes_32x32 As ImageList
    Friend WithEvents Txt_Observacion As DevComponents.DotNetBar.Controls.TextBoxX
End Class
