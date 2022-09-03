<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Demonio_03_Doc_Impresos_X_Estacion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Demonio_03_Doc_Impresos_X_Estacion))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.ContextMenuBar1 = New DevComponents.DotNetBar.ContextMenuBar()
        Me.Menu_Contextual_01 = New DevComponents.DotNetBar.ButtonItem()
        Me.LabelItem1 = New DevComponents.DotNetBar.LabelItem()
        Me.Btn_Ver_Documento = New DevComponents.DotNetBar.ButtonItem()
        Me.LabelItem2 = New DevComponents.DotNetBar.LabelItem()
        Me.Btn_Enviar_Correo_Adjunto = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Cambiar_Entidad_Documento = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Imprimir_Documento = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Revisar_Problema = New DevComponents.DotNetBar.ButtonItem()
        Me.Grilla = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.DtpFecharevision = New System.Windows.Forms.DateTimePicker()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Imprimir = New DevComponents.DotNetBar.ButtonItem()
        Me.Chk_Seleccionar_Todo = New DevComponents.DotNetBar.CheckBoxItem()
        Me.BtnActualizar = New DevComponents.DotNetBar.ButtonItem()
        Me.BtnBuscarDocumentos = New DevComponents.DotNetBar.ButtonItem()
        Me.BtnConfigurar = New DevComponents.DotNetBar.ButtonItem()
        Me.BtnMinimizar = New DevComponents.DotNetBar.ButtonItem()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.Cmb_Tido = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.Imagenes_20x20 = New System.Windows.Forms.ImageList(Me.components)
        Me.GroupPanel1.SuspendLayout()
        CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupPanel1
        '
        Me.GroupPanel1.BackColor = System.Drawing.Color.White
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.ContextMenuBar1)
        Me.GroupPanel1.Controls.Add(Me.Grilla)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Location = New System.Drawing.Point(12, 40)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(750, 379)
        '
        '
        '
        Me.GroupPanel1.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.GroupPanel1.Style.BackColorGradientAngle = 90
        Me.GroupPanel1.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.GroupPanel1.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel1.Style.BorderBottomWidth = 1
        Me.GroupPanel1.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupPanel1.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel1.Style.BorderLeftWidth = 1
        Me.GroupPanel1.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel1.Style.BorderRightWidth = 1
        Me.GroupPanel1.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel1.Style.BorderTopWidth = 1
        Me.GroupPanel1.Style.CornerDiameter = 4
        Me.GroupPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanel1.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanel1.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GroupPanel1.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanel1.TabIndex = 0
        '
        'ContextMenuBar1
        '
        Me.ContextMenuBar1.AntiAlias = True
        Me.ContextMenuBar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ContextMenuBar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Menu_Contextual_01})
        Me.ContextMenuBar1.Location = New System.Drawing.Point(261, 50)
        Me.ContextMenuBar1.Name = "ContextMenuBar1"
        Me.ContextMenuBar1.Size = New System.Drawing.Size(153, 25)
        Me.ContextMenuBar1.Stretch = True
        Me.ContextMenuBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ContextMenuBar1.TabIndex = 46
        Me.ContextMenuBar1.TabStop = False
        Me.ContextMenuBar1.Text = "ContextMenuBar1"
        '
        'Menu_Contextual_01
        '
        Me.Menu_Contextual_01.AutoExpandOnClick = True
        Me.Menu_Contextual_01.Name = "Menu_Contextual_01"
        Me.Menu_Contextual_01.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItem1, Me.Btn_Ver_Documento, Me.LabelItem2, Me.Btn_Enviar_Correo_Adjunto, Me.Btn_Cambiar_Entidad_Documento, Me.Btn_Imprimir_Documento, Me.Btn_Revisar_Problema})
        Me.Menu_Contextual_01.Text = "Opciones"
        '
        'LabelItem1
        '
        Me.LabelItem1.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.LabelItem1.BorderSide = DevComponents.DotNetBar.eBorderSide.Bottom
        Me.LabelItem1.BorderType = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.LabelItem1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(21, Byte), Integer), CType(CType(110, Byte), Integer))
        Me.LabelItem1.Name = "LabelItem1"
        Me.LabelItem1.PaddingBottom = 1
        Me.LabelItem1.PaddingLeft = 10
        Me.LabelItem1.PaddingTop = 1
        Me.LabelItem1.SingleLineColor = System.Drawing.Color.FromArgb(CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer))
        Me.LabelItem1.Text = "Opciones"
        '
        'Btn_Ver_Documento
        '
        Me.Btn_Ver_Documento.Image = CType(resources.GetObject("Btn_Ver_Documento.Image"), System.Drawing.Image)
        Me.Btn_Ver_Documento.Name = "Btn_Ver_Documento"
        Me.Btn_Ver_Documento.Text = "Ver documento"
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
        Me.LabelItem2.Text = "Opciones especiales"
        '
        'Btn_Enviar_Correo_Adjunto
        '
        Me.Btn_Enviar_Correo_Adjunto.Image = CType(resources.GetObject("Btn_Enviar_Correo_Adjunto.Image"), System.Drawing.Image)
        Me.Btn_Enviar_Correo_Adjunto.Name = "Btn_Enviar_Correo_Adjunto"
        Me.Btn_Enviar_Correo_Adjunto.Text = "Enviar documento por correo"
        Me.Btn_Enviar_Correo_Adjunto.Visible = False
        '
        'Btn_Cambiar_Entidad_Documento
        '
        Me.Btn_Cambiar_Entidad_Documento.Image = CType(resources.GetObject("Btn_Cambiar_Entidad_Documento.Image"), System.Drawing.Image)
        Me.Btn_Cambiar_Entidad_Documento.Name = "Btn_Cambiar_Entidad_Documento"
        Me.Btn_Cambiar_Entidad_Documento.Text = "Cambiar entidad del documento"
        Me.Btn_Cambiar_Entidad_Documento.Visible = False
        '
        'Btn_Imprimir_Documento
        '
        Me.Btn_Imprimir_Documento.Image = CType(resources.GetObject("Btn_Imprimir_Documento.Image"), System.Drawing.Image)
        Me.Btn_Imprimir_Documento.Name = "Btn_Imprimir_Documento"
        Me.Btn_Imprimir_Documento.Text = "Imprimir documento"
        '
        'Btn_Revisar_Problema
        '
        Me.Btn_Revisar_Problema.Image = CType(resources.GetObject("Btn_Revisar_Problema.Image"), System.Drawing.Image)
        Me.Btn_Revisar_Problema.Name = "Btn_Revisar_Problema"
        Me.Btn_Revisar_Problema.Text = "Revisar problema!!"
        '
        'Grilla
        '
        Me.Grilla.AllowUserToAddRows = False
        Me.Grilla.AllowUserToDeleteRows = False
        Me.Grilla.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.Grilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Grilla.DefaultCellStyle = DataGridViewCellStyle2
        Me.Grilla.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grilla.EnableHeadersVisualStyles = False
        Me.Grilla.GridColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.Grilla.Location = New System.Drawing.Point(0, 0)
        Me.Grilla.Name = "Grilla"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.Grilla.Size = New System.Drawing.Size(744, 373)
        Me.Grilla.StandardTab = True
        Me.Grilla.TabIndex = 29
        '
        'DtpFecharevision
        '
        Me.DtpFecharevision.BackColor = System.Drawing.Color.White
        Me.DtpFecharevision.ForeColor = System.Drawing.Color.Black
        Me.DtpFecharevision.Location = New System.Drawing.Point(130, 13)
        Me.DtpFecharevision.Name = "DtpFecharevision"
        Me.DtpFecharevision.Size = New System.Drawing.Size(216, 22)
        Me.DtpFecharevision.TabIndex = 5
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Imprimir, Me.Chk_Seleccionar_Todo, Me.BtnActualizar, Me.BtnBuscarDocumentos})
        Me.Bar1.Location = New System.Drawing.Point(0, 437)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(773, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 6
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'Btn_Imprimir
        '
        Me.Btn_Imprimir.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Imprimir.ForeColor = System.Drawing.Color.Black
        Me.Btn_Imprimir.Image = CType(resources.GetObject("Btn_Imprimir.Image"), System.Drawing.Image)
        Me.Btn_Imprimir.Name = "Btn_Imprimir"
        Me.Btn_Imprimir.Text = "Imprimir seleccionados"
        '
        'Chk_Seleccionar_Todo
        '
        Me.Chk_Seleccionar_Todo.Name = "Chk_Seleccionar_Todo"
        Me.Chk_Seleccionar_Todo.Text = "Seleccionar todo"
        '
        'BtnActualizar
        '
        Me.BtnActualizar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnActualizar.ForeColor = System.Drawing.Color.Black
        Me.BtnActualizar.Image = CType(resources.GetObject("BtnActualizar.Image"), System.Drawing.Image)
        Me.BtnActualizar.Name = "BtnActualizar"
        Me.BtnActualizar.Tooltip = "Actualizar"
        '
        'BtnBuscarDocumentos
        '
        Me.BtnBuscarDocumentos.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnBuscarDocumentos.ForeColor = System.Drawing.Color.Black
        Me.BtnBuscarDocumentos.Image = CType(resources.GetObject("BtnBuscarDocumentos.Image"), System.Drawing.Image)
        Me.BtnBuscarDocumentos.Name = "BtnBuscarDocumentos"
        Me.BtnBuscarDocumentos.Text = "Buscar documento"
        Me.BtnBuscarDocumentos.Visible = False
        '
        'BtnConfigurar
        '
        Me.BtnConfigurar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnConfigurar.ForeColor = System.Drawing.Color.Black
        Me.BtnConfigurar.Image = CType(resources.GetObject("BtnConfigurar.Image"), System.Drawing.Image)
        Me.BtnConfigurar.Name = "BtnConfigurar"
        Me.BtnConfigurar.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.BtnMinimizar})
        Me.BtnConfigurar.Text = "Configurar"
        '
        'BtnMinimizar
        '
        Me.BtnMinimizar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnMinimizar.ForeColor = System.Drawing.Color.Black
        Me.BtnMinimizar.Image = CType(resources.GetObject("BtnMinimizar.Image"), System.Drawing.Image)
        Me.BtnMinimizar.Name = "BtnMinimizar"
        Me.BtnMinimizar.Text = "Minimizar"
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.ForeColor = System.Drawing.Color.Black
        Me.LabelX1.Location = New System.Drawing.Point(15, 12)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(109, 23)
        Me.LabelX1.TabIndex = 7
        Me.LabelX1.Text = "Fecha de impresión:"
        '
        'Cmb_Tido
        '
        Me.Cmb_Tido.DisplayMember = "Text"
        Me.Cmb_Tido.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.Cmb_Tido.ForeColor = System.Drawing.Color.Black
        Me.Cmb_Tido.FormattingEnabled = True
        Me.Cmb_Tido.ItemHeight = 16
        Me.Cmb_Tido.Location = New System.Drawing.Point(480, 14)
        Me.Cmb_Tido.Name = "Cmb_Tido"
        Me.Cmb_Tido.Size = New System.Drawing.Size(182, 22)
        Me.Cmb_Tido.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Cmb_Tido.TabIndex = 8
        '
        'LabelX2
        '
        Me.LabelX2.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.ForeColor = System.Drawing.Color.Black
        Me.LabelX2.Location = New System.Drawing.Point(365, 14)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(109, 23)
        Me.LabelX2.TabIndex = 9
        Me.LabelX2.Text = "Tipo de documentos"
        '
        'Imagenes_20x20
        '
        Me.Imagenes_20x20.ImageStream = CType(resources.GetObject("Imagenes_20x20.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.Imagenes_20x20.TransparentColor = System.Drawing.Color.Transparent
        Me.Imagenes_20x20.Images.SetKeyName(0, "print-warn.png")
        Me.Imagenes_20x20.Images.SetKeyName(1, "print-ok.png")
        Me.Imagenes_20x20.Images.SetKeyName(2, "print-error.png")
        '
        'Frm_Demonio_03_Doc_Impresos_X_Estacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(773, 478)
        Me.Controls.Add(Me.LabelX2)
        Me.Controls.Add(Me.Cmb_Tido)
        Me.Controls.Add(Me.LabelX1)
        Me.Controls.Add(Me.Bar1)
        Me.Controls.Add(Me.DtpFecharevision)
        Me.Controls.Add(Me.GroupPanel1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Demonio_03_Doc_Impresos_X_Estacion"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Listado de documentos impresos"
        Me.GroupPanel1.ResumeLayout(False)
        CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Grilla As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents DtpFecharevision As System.Windows.Forms.DateTimePicker
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents BtnConfigurar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents BtnMinimizar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents BtnBuscarDocumentos As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents BtnActualizar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Cmb_Tido As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Btn_Imprimir As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Chk_Seleccionar_Todo As DevComponents.DotNetBar.CheckBoxItem
    Friend WithEvents Imagenes_20x20 As System.Windows.Forms.ImageList
    Friend WithEvents ContextMenuBar1 As DevComponents.DotNetBar.ContextMenuBar
    Friend WithEvents Menu_Contextual_01 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelItem1 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents Btn_Ver_Documento As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelItem2 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents Btn_Enviar_Correo_Adjunto As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Cambiar_Entidad_Documento As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Imprimir_Documento As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Revisar_Problema As DevComponents.DotNetBar.ButtonItem
End Class
