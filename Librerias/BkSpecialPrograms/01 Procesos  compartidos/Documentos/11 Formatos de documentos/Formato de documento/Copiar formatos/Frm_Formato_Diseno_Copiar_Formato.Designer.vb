<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Formato_Diseno_Copiar_Formato
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Formato_Diseno_Copiar_Formato))
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Copiar_Formato = New DevComponents.DotNetBar.ButtonItem()
        Me.Lbl_TiempoRest = New DevComponents.DotNetBar.LabelItem()
        Me.Grupo_documento = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Txt_NombreFormato = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Lbl_NombreFormato = New DevComponents.DotNetBar.LabelX()
        Me.Chk_Copiar_en_formato_por_defecto = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.Lbl_Documento_Origen = New DevComponents.DotNetBar.LabelX()
        Me.CmbTipoDeDocumentos = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.LblNroDocumento = New DevComponents.DotNetBar.LabelX()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Grupo_documento.SuspendLayout()
        Me.SuspendLayout()
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Copiar_Formato, Me.Lbl_TiempoRest})
        Me.Bar1.Location = New System.Drawing.Point(0, 156)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(497, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 87
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'Btn_Copiar_Formato
        '
        Me.Btn_Copiar_Formato.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Copiar_Formato.ForeColor = System.Drawing.Color.Black
        Me.Btn_Copiar_Formato.Image = CType(resources.GetObject("Btn_Copiar_Formato.Image"), System.Drawing.Image)
        Me.Btn_Copiar_Formato.Name = "Btn_Copiar_Formato"
        Me.Btn_Copiar_Formato.Tooltip = "Grabar"
        '
        'Lbl_TiempoRest
        '
        Me.Lbl_TiempoRest.ForeColor = System.Drawing.Color.Black
        Me.Lbl_TiempoRest.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.Lbl_TiempoRest.Name = "Lbl_TiempoRest"
        Me.Lbl_TiempoRest.Text = "."
        '
        'Grupo_documento
        '
        Me.Grupo_documento.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Grupo_documento.CanvasColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Grupo_documento.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Grupo_documento.Controls.Add(Me.Txt_NombreFormato)
        Me.Grupo_documento.Controls.Add(Me.Lbl_NombreFormato)
        Me.Grupo_documento.Controls.Add(Me.Chk_Copiar_en_formato_por_defecto)
        Me.Grupo_documento.Controls.Add(Me.LabelX3)
        Me.Grupo_documento.Controls.Add(Me.Lbl_Documento_Origen)
        Me.Grupo_documento.Controls.Add(Me.CmbTipoDeDocumentos)
        Me.Grupo_documento.Controls.Add(Me.LblNroDocumento)
        Me.Grupo_documento.DisabledBackColor = System.Drawing.Color.Empty
        Me.Grupo_documento.Location = New System.Drawing.Point(12, 0)
        Me.Grupo_documento.Name = "Grupo_documento"
        Me.Grupo_documento.Size = New System.Drawing.Size(473, 146)
        '
        '
        '
        Me.Grupo_documento.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Grupo_documento.Style.BackColorGradientAngle = 90
        Me.Grupo_documento.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Grupo_documento.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_documento.Style.BorderBottomWidth = 1
        Me.Grupo_documento.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.Grupo_documento.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_documento.Style.BorderLeftWidth = 1
        Me.Grupo_documento.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_documento.Style.BorderRightWidth = 1
        Me.Grupo_documento.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_documento.Style.BorderTopWidth = 1
        Me.Grupo_documento.Style.CornerDiameter = 4
        Me.Grupo_documento.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Grupo_documento.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.Grupo_documento.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.Grupo_documento.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.Grupo_documento.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.Grupo_documento.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Grupo_documento.TabIndex = 88
        Me.Grupo_documento.Text = "Filtro de documentos"
        '
        'Txt_NombreFormato
        '
        Me.Txt_NombreFormato.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_NombreFormato.Border.Class = "TextBoxBorder"
        Me.Txt_NombreFormato.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_NombreFormato.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_NombreFormato.ForeColor = System.Drawing.Color.Black
        Me.Txt_NombreFormato.Location = New System.Drawing.Point(93, 90)
        Me.Txt_NombreFormato.MaxLength = 50
        Me.Txt_NombreFormato.Name = "Txt_NombreFormato"
        Me.Txt_NombreFormato.PreventEnterBeep = True
        Me.Txt_NombreFormato.Size = New System.Drawing.Size(371, 22)
        Me.Txt_NombreFormato.TabIndex = 32
        '
        'Lbl_NombreFormato
        '
        Me.Lbl_NombreFormato.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_NombreFormato.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_NombreFormato.ForeColor = System.Drawing.Color.Black
        Me.Lbl_NombreFormato.Location = New System.Drawing.Point(3, 90)
        Me.Lbl_NombreFormato.Name = "Lbl_NombreFormato"
        Me.Lbl_NombreFormato.Size = New System.Drawing.Size(84, 23)
        Me.Lbl_NombreFormato.TabIndex = 31
        Me.Lbl_NombreFormato.Text = "Nombre formato"
        '
        'Chk_Copiar_en_formato_por_defecto
        '
        Me.Chk_Copiar_en_formato_por_defecto.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_Copiar_en_formato_por_defecto.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Copiar_en_formato_por_defecto.ForeColor = System.Drawing.Color.Black
        Me.Chk_Copiar_en_formato_por_defecto.Location = New System.Drawing.Point(3, 61)
        Me.Chk_Copiar_en_formato_por_defecto.Name = "Chk_Copiar_en_formato_por_defecto"
        Me.Chk_Copiar_en_formato_por_defecto.Size = New System.Drawing.Size(189, 23)
        Me.Chk_Copiar_en_formato_por_defecto.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Copiar_en_formato_por_defecto.TabIndex = 30
        Me.Chk_Copiar_en_formato_por_defecto.Text = "Copiar en formato por defecto"
        '
        'LabelX3
        '
        Me.LabelX3.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.ForeColor = System.Drawing.Color.Black
        Me.LabelX3.Location = New System.Drawing.Point(3, 32)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(75, 23)
        Me.LabelX3.TabIndex = 29
        Me.LabelX3.Text = "Destino"
        '
        'Lbl_Documento_Origen
        '
        Me.Lbl_Documento_Origen.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_Documento_Origen.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Documento_Origen.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Documento_Origen.Location = New System.Drawing.Point(93, 3)
        Me.Lbl_Documento_Origen.Name = "Lbl_Documento_Origen"
        Me.Lbl_Documento_Origen.Size = New System.Drawing.Size(282, 23)
        Me.Lbl_Documento_Origen.TabIndex = 28
        Me.Lbl_Documento_Origen.Text = "N° documento"
        '
        'CmbTipoDeDocumentos
        '
        Me.CmbTipoDeDocumentos.DisplayMember = "Text"
        Me.CmbTipoDeDocumentos.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.CmbTipoDeDocumentos.ForeColor = System.Drawing.Color.Black
        Me.CmbTipoDeDocumentos.FormattingEnabled = True
        Me.CmbTipoDeDocumentos.ItemHeight = 16
        Me.CmbTipoDeDocumentos.Location = New System.Drawing.Point(93, 32)
        Me.CmbTipoDeDocumentos.Name = "CmbTipoDeDocumentos"
        Me.CmbTipoDeDocumentos.Size = New System.Drawing.Size(371, 22)
        Me.CmbTipoDeDocumentos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.CmbTipoDeDocumentos.TabIndex = 23
        '
        'LblNroDocumento
        '
        Me.LblNroDocumento.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LblNroDocumento.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LblNroDocumento.ForeColor = System.Drawing.Color.Black
        Me.LblNroDocumento.Location = New System.Drawing.Point(3, 3)
        Me.LblNroDocumento.Name = "LblNroDocumento"
        Me.LblNroDocumento.Size = New System.Drawing.Size(75, 23)
        Me.LblNroDocumento.TabIndex = 21
        Me.LblNroDocumento.Text = "N° documento"
        '
        'Frm_Formato_Diseno_Copiar_Formato
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(497, 197)
        Me.Controls.Add(Me.Grupo_documento)
        Me.Controls.Add(Me.Bar1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Formato_Diseno_Copiar_Formato"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Copiar formato"
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Grupo_documento.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents Btn_Copiar_Formato As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Lbl_TiempoRest As DevComponents.DotNetBar.LabelItem
    Public WithEvents Grupo_documento As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Lbl_Documento_Origen As DevComponents.DotNetBar.LabelX
    Public WithEvents CmbTipoDeDocumentos As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents LblNroDocumento As DevComponents.DotNetBar.LabelX
    Friend WithEvents Chk_Copiar_en_formato_por_defecto As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Txt_NombreFormato As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Lbl_NombreFormato As DevComponents.DotNetBar.LabelX
End Class
