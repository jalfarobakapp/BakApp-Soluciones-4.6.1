<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Desp_03_Preparar_Armar_Bulto
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Desp_03_Preparar_Armar_Bulto))
        Me.ReflectionImage1 = New DevComponents.DotNetBar.Controls.ReflectionImage()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_Codigo_Barras = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Despachar = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Autorizar_Permiso = New DevComponents.DotNetBar.ButtonItem()
        Me.lvFics = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Imagnes_32x32 = New System.Windows.Forms.ImageList(Me.components)
        Me.Imagnes_16x16 = New System.Windows.Forms.ImageList(Me.components)
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_Observaciones = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Highlighter1 = New DevComponents.DotNetBar.Validator.Highlighter()
        Me.Rfle_Huella = New DevComponents.DotNetBar.Controls.ReflectionImage()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ReflectionImage1
        '
        Me.ReflectionImage1.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.ReflectionImage1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ReflectionImage1.BackgroundStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.ReflectionImage1.ForeColor = System.Drawing.Color.Black
        Me.ReflectionImage1.Image = CType(resources.GetObject("ReflectionImage1.Image"), System.Drawing.Image)
        Me.ReflectionImage1.Location = New System.Drawing.Point(289, 5)
        Me.ReflectionImage1.Name = "ReflectionImage1"
        Me.ReflectionImage1.ReflectionEnabled = False
        Me.ReflectionImage1.Size = New System.Drawing.Size(30, 30)
        Me.ReflectionImage1.TabIndex = 134
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.ForeColor = System.Drawing.Color.Black
        Me.LabelX1.Location = New System.Drawing.Point(12, 7)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(60, 23)
        Me.LabelX1.TabIndex = 133
        Me.LabelX1.Text = "Documento"
        '
        'Txt_Codigo_Barras
        '
        Me.Txt_Codigo_Barras.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Codigo_Barras.Border.Class = "TextBoxBorder"
        Me.Txt_Codigo_Barras.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Codigo_Barras.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Codigo_Barras.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Codigo_Barras.ForeColor = System.Drawing.Color.Black
        Me.Highlighter1.SetHighlightOnFocus(Me.Txt_Codigo_Barras, True)
        Me.Txt_Codigo_Barras.Location = New System.Drawing.Point(78, 4)
        Me.Txt_Codigo_Barras.MaxLength = 20
        Me.Txt_Codigo_Barras.Name = "Txt_Codigo_Barras"
        Me.Txt_Codigo_Barras.PreventEnterBeep = True
        Me.Txt_Codigo_Barras.Size = New System.Drawing.Size(205, 29)
        Me.Txt_Codigo_Barras.TabIndex = 132
        Me.Txt_Codigo_Barras.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Despachar, Me.Btn_Autorizar_Permiso})
        Me.Bar1.Location = New System.Drawing.Point(0, 330)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(784, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 131
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'Btn_Despachar
        '
        Me.Btn_Despachar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Despachar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Despachar.Image = CType(resources.GetObject("Btn_Despachar.Image"), System.Drawing.Image)
        Me.Btn_Despachar.ImageAlt = CType(resources.GetObject("Btn_Despachar.ImageAlt"), System.Drawing.Image)
        Me.Btn_Despachar.Name = "Btn_Despachar"
        Me.Btn_Despachar.Text = "ACEPTAR"
        '
        'Btn_Autorizar_Permiso
        '
        Me.Btn_Autorizar_Permiso.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Autorizar_Permiso.ForeColor = System.Drawing.Color.Black
        Me.Btn_Autorizar_Permiso.Image = CType(resources.GetObject("Btn_Autorizar_Permiso.Image"), System.Drawing.Image)
        Me.Btn_Autorizar_Permiso.ImageAlt = CType(resources.GetObject("Btn_Autorizar_Permiso.ImageAlt"), System.Drawing.Image)
        Me.Btn_Autorizar_Permiso.Name = "Btn_Autorizar_Permiso"
        Me.Btn_Autorizar_Permiso.Tooltip = "Permitir el movimiento de productos sin validar"
        Me.Btn_Autorizar_Permiso.Visible = False
        '
        'lvFics
        '
        Me.lvFics.Activation = System.Windows.Forms.ItemActivation.OneClick
        Me.lvFics.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvFics.BackColor = System.Drawing.Color.White
        Me.lvFics.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3})
        Me.lvFics.ForeColor = System.Drawing.Color.Black
        Me.lvFics.FullRowSelect = True
        Me.lvFics.GridLines = True
        Me.lvFics.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lvFics.HideSelection = False
        Me.lvFics.LargeImageList = Me.Imagnes_32x32
        Me.lvFics.Location = New System.Drawing.Point(12, 41)
        Me.lvFics.MultiSelect = False
        Me.lvFics.Name = "lvFics"
        Me.lvFics.Size = New System.Drawing.Size(758, 170)
        Me.lvFics.SmallImageList = Me.Imagnes_16x16
        Me.lvFics.TabIndex = 135
        Me.lvFics.UseCompatibleStateImageBehavior = False
        Me.lvFics.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Documento"
        Me.ColumnHeader1.Width = 120
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Razón Social"
        Me.ColumnHeader2.Width = 330
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Estado"
        Me.ColumnHeader3.Width = 300
        '
        'Imagnes_32x32
        '
        Me.Imagnes_32x32.ImageStream = CType(resources.GetObject("Imagnes_32x32.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.Imagnes_32x32.TransparentColor = System.Drawing.Color.Transparent
        Me.Imagnes_32x32.Images.SetKeyName(0, "ok.png")
        Me.Imagnes_32x32.Images.SetKeyName(1, "warning.png")
        '
        'Imagnes_16x16
        '
        Me.Imagnes_16x16.ImageStream = CType(resources.GetObject("Imagnes_16x16.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.Imagnes_16x16.TransparentColor = System.Drawing.Color.Transparent
        Me.Imagnes_16x16.Images.SetKeyName(0, "cancel.png")
        Me.Imagnes_16x16.Images.SetKeyName(1, "document_text-ok.png")
        Me.Imagnes_16x16.Images.SetKeyName(2, "document_text-warn.png")
        Me.Imagnes_16x16.Images.SetKeyName(3, "warning.png")
        Me.Imagnes_16x16.Images.SetKeyName(4, "ok_button.png")
        Me.Imagnes_16x16.Images.SetKeyName(5, "document_text-error.png")
        '
        'LabelX4
        '
        Me.LabelX4.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.ForeColor = System.Drawing.Color.Black
        Me.LabelX4.Location = New System.Drawing.Point(12, 217)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(138, 20)
        Me.LabelX4.TabIndex = 137
        Me.LabelX4.Text = "Observaciones"
        '
        'Txt_Observaciones
        '
        Me.Txt_Observaciones.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Observaciones.Border.Class = "TextBoxBorder"
        Me.Txt_Observaciones.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Observaciones.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_Observaciones.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Observaciones.ForeColor = System.Drawing.Color.Black
        Me.Highlighter1.SetHighlightOnFocus(Me.Txt_Observaciones, True)
        Me.Txt_Observaciones.Location = New System.Drawing.Point(12, 240)
        Me.Txt_Observaciones.Multiline = True
        Me.Txt_Observaciones.Name = "Txt_Observaciones"
        Me.Txt_Observaciones.PreventEnterBeep = True
        Me.Txt_Observaciones.Size = New System.Drawing.Size(522, 80)
        Me.Txt_Observaciones.TabIndex = 136
        '
        'Highlighter1
        '
        Me.Highlighter1.FocusHighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Green
        Me.Highlighter1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        '
        'Rfle_Huella
        '
        Me.Rfle_Huella.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rfle_Huella.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rfle_Huella.BackgroundStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.Rfle_Huella.ForeColor = System.Drawing.Color.Black
        Me.Rfle_Huella.Image = CType(resources.GetObject("Rfle_Huella.Image"), System.Drawing.Image)
        Me.Rfle_Huella.Location = New System.Drawing.Point(737, 2)
        Me.Rfle_Huella.Name = "Rfle_Huella"
        Me.Rfle_Huella.Size = New System.Drawing.Size(35, 31)
        Me.Rfle_Huella.TabIndex = 138
        '
        'Frm_Desp_03_Preparar_Armar_Bulto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 371)
        Me.Controls.Add(Me.Rfle_Huella)
        Me.Controls.Add(Me.LabelX4)
        Me.Controls.Add(Me.Txt_Observaciones)
        Me.Controls.Add(Me.lvFics)
        Me.Controls.Add(Me.ReflectionImage1)
        Me.Controls.Add(Me.LabelX1)
        Me.Controls.Add(Me.Txt_Codigo_Barras)
        Me.Controls.Add(Me.Bar1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Desp_03_Preparar_Armar_Bulto"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "PREPARAR PEDIDO - ARMAR BULTO"
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ReflectionImage1 As DevComponents.DotNetBar.Controls.ReflectionImage
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Txt_Codigo_Barras As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Public WithEvents Btn_Despachar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Autorizar_Permiso As DevComponents.DotNetBar.ButtonItem
    Private WithEvents lvFics As ListView
    Private WithEvents ColumnHeader1 As ColumnHeader
    Private WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents Imagnes_32x32 As ImageList
    Friend WithEvents Imagnes_16x16 As ImageList
    Friend WithEvents ColumnHeader3 As ColumnHeader
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Txt_Observaciones As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Highlighter1 As DevComponents.DotNetBar.Validator.Highlighter
    Friend WithEvents Rfle_Huella As DevComponents.DotNetBar.Controls.ReflectionImage
End Class
