<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Sectores
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Sectores))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Btn_VerInventario = New DevComponents.DotNetBar.ButtonItem()
        Me.LabelItem1 = New DevComponents.DotNetBar.LabelItem()
        Me.Btn_EditarInventario = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_EliminarInventario = New DevComponents.DotNetBar.ButtonItem()
        Me.LabelItem3 = New DevComponents.DotNetBar.LabelItem()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_Filtrar = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.ContextMenuBar1 = New DevComponents.DotNetBar.ContextMenuBar()
        Me.Menu_Contextual_MantSector = New DevComponents.DotNetBar.ButtonItem()
        Me.Lbl_Sector = New DevComponents.DotNetBar.LabelItem()
        Me.Btn_EditarUbicacion = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_EliminarUbicacion = New DevComponents.DotNetBar.ButtonItem()
        Me.LabelItem2 = New DevComponents.DotNetBar.LabelItem()
        Me.Btn_Copiar = New DevComponents.DotNetBar.ButtonItem()
        Me.Grilla = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Crear_Ubicacion = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Importar_Desde_Excel = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_ImprimirMasivamente = New DevComponents.DotNetBar.ButtonItem()
        Me.GroupPanel1.SuspendLayout()
        CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Btn_VerInventario
        '
        Me.Btn_VerInventario.Image = CType(resources.GetObject("Btn_VerInventario.Image"), System.Drawing.Image)
        Me.Btn_VerInventario.ImageAlt = CType(resources.GetObject("Btn_VerInventario.ImageAlt"), System.Drawing.Image)
        Me.Btn_VerInventario.Name = "Btn_VerInventario"
        Me.Btn_VerInventario.Text = "Ingresar al inventario"
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
        'Btn_EditarInventario
        '
        Me.Btn_EditarInventario.Image = CType(resources.GetObject("Btn_EditarInventario.Image"), System.Drawing.Image)
        Me.Btn_EditarInventario.ImageAlt = CType(resources.GetObject("Btn_EditarInventario.ImageAlt"), System.Drawing.Image)
        Me.Btn_EditarInventario.Name = "Btn_EditarInventario"
        Me.Btn_EditarInventario.Text = "Editar"
        '
        'Btn_EliminarInventario
        '
        Me.Btn_EliminarInventario.Image = CType(resources.GetObject("Btn_EliminarInventario.Image"), System.Drawing.Image)
        Me.Btn_EliminarInventario.ImageAlt = CType(resources.GetObject("Btn_EliminarInventario.ImageAlt"), System.Drawing.Image)
        Me.Btn_EliminarInventario.Name = "Btn_EliminarInventario"
        Me.Btn_EliminarInventario.Text = "Eliminar"
        '
        'LabelItem3
        '
        Me.LabelItem3.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.LabelItem3.BorderSide = DevComponents.DotNetBar.eBorderSide.Bottom
        Me.LabelItem3.BorderType = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.LabelItem3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(21, Byte), Integer), CType(CType(110, Byte), Integer))
        Me.LabelItem3.Name = "LabelItem3"
        Me.LabelItem3.PaddingBottom = 1
        Me.LabelItem3.PaddingLeft = 10
        Me.LabelItem3.PaddingTop = 1
        Me.LabelItem3.SingleLineColor = System.Drawing.Color.FromArgb(CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer))
        Me.LabelItem3.Text = "-----------------------------------------"
        '
        'LabelX2
        '
        Me.LabelX2.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.ForeColor = System.Drawing.Color.Black
        Me.LabelX2.Image = CType(resources.GetObject("LabelX2.Image"), System.Drawing.Image)
        Me.LabelX2.ImagePosition = DevComponents.DotNetBar.eImagePosition.Right
        Me.LabelX2.ImageTextSpacing = 3
        Me.LabelX2.Location = New System.Drawing.Point(12, 6)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(57, 23)
        Me.LabelX2.TabIndex = 182
        Me.LabelX2.Text = "Buscar"
        '
        'Txt_Filtrar
        '
        Me.Txt_Filtrar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Txt_Filtrar.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Filtrar.Border.Class = "TextBoxBorder"
        Me.Txt_Filtrar.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Filtrar.ButtonCustom2.Image = CType(resources.GetObject("Txt_Filtrar.ButtonCustom2.Image"), System.Drawing.Image)
        Me.Txt_Filtrar.ButtonCustom2.Visible = True
        Me.Txt_Filtrar.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Filtrar.ForeColor = System.Drawing.Color.Black
        Me.Txt_Filtrar.Location = New System.Drawing.Point(75, 7)
        Me.Txt_Filtrar.Name = "Txt_Filtrar"
        Me.Txt_Filtrar.PreventEnterBeep = True
        Me.Txt_Filtrar.Size = New System.Drawing.Size(646, 22)
        Me.Txt_Filtrar.TabIndex = 181
        '
        'GroupPanel1
        '
        Me.GroupPanel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupPanel1.BackColor = System.Drawing.Color.White
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.ContextMenuBar1)
        Me.GroupPanel1.Controls.Add(Me.Grilla)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Location = New System.Drawing.Point(12, 35)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(709, 460)
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
        Me.GroupPanel1.TabIndex = 180
        Me.GroupPanel1.Text = "Ubicaciones/Sectores"
        '
        'ContextMenuBar1
        '
        Me.ContextMenuBar1.AntiAlias = True
        Me.ContextMenuBar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ContextMenuBar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Menu_Contextual_MantSector})
        Me.ContextMenuBar1.Location = New System.Drawing.Point(31, 37)
        Me.ContextMenuBar1.Name = "ContextMenuBar1"
        Me.ContextMenuBar1.Size = New System.Drawing.Size(480, 25)
        Me.ContextMenuBar1.Stretch = True
        Me.ContextMenuBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ContextMenuBar1.TabIndex = 48
        Me.ContextMenuBar1.TabStop = False
        Me.ContextMenuBar1.Text = "ContextMenuBar1"
        '
        'Menu_Contextual_MantSector
        '
        Me.Menu_Contextual_MantSector.AutoExpandOnClick = True
        Me.Menu_Contextual_MantSector.Name = "Menu_Contextual_MantSector"
        Me.Menu_Contextual_MantSector.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Lbl_Sector, Me.Btn_EditarUbicacion, Me.Btn_EliminarUbicacion, Me.LabelItem2, Me.Btn_Copiar})
        Me.Menu_Contextual_MantSector.Text = "Opciones Despacho"
        '
        'Lbl_Sector
        '
        Me.Lbl_Sector.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.Lbl_Sector.BorderSide = DevComponents.DotNetBar.eBorderSide.Bottom
        Me.Lbl_Sector.BorderType = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.Lbl_Sector.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(21, Byte), Integer), CType(CType(110, Byte), Integer))
        Me.Lbl_Sector.Name = "Lbl_Sector"
        Me.Lbl_Sector.PaddingBottom = 1
        Me.Lbl_Sector.PaddingLeft = 10
        Me.Lbl_Sector.PaddingTop = 1
        Me.Lbl_Sector.SingleLineColor = System.Drawing.Color.FromArgb(CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer))
        Me.Lbl_Sector.Text = "Sector"
        '
        'Btn_EditarUbicacion
        '
        Me.Btn_EditarUbicacion.Image = CType(resources.GetObject("Btn_EditarUbicacion.Image"), System.Drawing.Image)
        Me.Btn_EditarUbicacion.ImageAlt = CType(resources.GetObject("Btn_EditarUbicacion.ImageAlt"), System.Drawing.Image)
        Me.Btn_EditarUbicacion.Name = "Btn_EditarUbicacion"
        Me.Btn_EditarUbicacion.Text = "Editar Sector"
        Me.Btn_EditarUbicacion.Tooltip = "Dar "
        '
        'Btn_EliminarUbicacion
        '
        Me.Btn_EliminarUbicacion.Image = CType(resources.GetObject("Btn_EliminarUbicacion.Image"), System.Drawing.Image)
        Me.Btn_EliminarUbicacion.ImageAlt = CType(resources.GetObject("Btn_EliminarUbicacion.ImageAlt"), System.Drawing.Image)
        Me.Btn_EliminarUbicacion.Name = "Btn_EliminarUbicacion"
        Me.Btn_EliminarUbicacion.Text = "Eliminar Sector"
        Me.Btn_EliminarUbicacion.Tooltip = "Dar "
        '
        'LabelItem2
        '
        Me.LabelItem2.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.LabelItem2.BorderSide = DevComponents.DotNetBar.eBorderSide.Bottom
        Me.LabelItem2.BorderType = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.LabelItem2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(21, Byte), Integer), CType(CType(110, Byte), Integer))
        Me.LabelItem2.ImageTextSpacing = 1
        Me.LabelItem2.Name = "LabelItem2"
        Me.LabelItem2.PaddingBottom = 1
        Me.LabelItem2.PaddingLeft = 10
        Me.LabelItem2.PaddingTop = 1
        Me.LabelItem2.SingleLineColor = System.Drawing.Color.FromArgb(CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer))
        Me.LabelItem2.Text = "-------------------------------------------"
        '
        'Btn_Copiar
        '
        Me.Btn_Copiar.Image = CType(resources.GetObject("Btn_Copiar.Image"), System.Drawing.Image)
        Me.Btn_Copiar.ImageAlt = CType(resources.GetObject("Btn_Copiar.ImageAlt"), System.Drawing.Image)
        Me.Btn_Copiar.Name = "Btn_Copiar"
        Me.Btn_Copiar.Text = "Copiar"
        '
        'Grilla
        '
        Me.Grilla.AllowUserToAddRows = False
        Me.Grilla.AllowUserToDeleteRows = False
        Me.Grilla.BackgroundColor = System.Drawing.Color.White
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
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
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
        Me.Grilla.Size = New System.Drawing.Size(703, 437)
        Me.Grilla.StandardTab = True
        Me.Grilla.TabIndex = 30
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Crear_Ubicacion, Me.Btn_Importar_Desde_Excel})
        Me.Bar1.Location = New System.Drawing.Point(0, 514)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(733, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 179
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'Btn_Crear_Ubicacion
        '
        Me.Btn_Crear_Ubicacion.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Crear_Ubicacion.ForeColor = System.Drawing.Color.Black
        Me.Btn_Crear_Ubicacion.Image = CType(resources.GetObject("Btn_Crear_Ubicacion.Image"), System.Drawing.Image)
        Me.Btn_Crear_Ubicacion.ImageAlt = CType(resources.GetObject("Btn_Crear_Ubicacion.ImageAlt"), System.Drawing.Image)
        Me.Btn_Crear_Ubicacion.Name = "Btn_Crear_Ubicacion"
        Me.Btn_Crear_Ubicacion.Tooltip = "Crear Inventario"
        '
        'Btn_Importar_Desde_Excel
        '
        Me.Btn_Importar_Desde_Excel.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Importar_Desde_Excel.ForeColor = System.Drawing.Color.Black
        Me.Btn_Importar_Desde_Excel.Image = CType(resources.GetObject("Btn_Importar_Desde_Excel.Image"), System.Drawing.Image)
        Me.Btn_Importar_Desde_Excel.ImageAlt = CType(resources.GetObject("Btn_Importar_Desde_Excel.ImageAlt"), System.Drawing.Image)
        Me.Btn_Importar_Desde_Excel.Name = "Btn_Importar_Desde_Excel"
        Me.Btn_Importar_Desde_Excel.Text = "Importar"
        Me.Btn_Importar_Desde_Excel.Tooltip = "Importar ubicaciones/sectores masivamente desde Excel"
        Me.Btn_Importar_Desde_Excel.Visible = False
        '
        'Btn_ImprimirMasivamente
        '
        Me.Btn_ImprimirMasivamente.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_ImprimirMasivamente.ForeColor = System.Drawing.Color.Black
        Me.Btn_ImprimirMasivamente.Image = CType(resources.GetObject("Btn_ImprimirMasivamente.Image"), System.Drawing.Image)
        Me.Btn_ImprimirMasivamente.ImageAlt = CType(resources.GetObject("Btn_ImprimirMasivamente.ImageAlt"), System.Drawing.Image)
        Me.Btn_ImprimirMasivamente.Name = "Btn_ImprimirMasivamente"
        Me.Btn_ImprimirMasivamente.Tooltip = "Imprimir sectores en forma masiva"
        '
        'Frm_Sectores
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(733, 555)
        Me.Controls.Add(Me.LabelX2)
        Me.Controls.Add(Me.Txt_Filtrar)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Controls.Add(Me.Bar1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Sectores"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "SECTORES/ESTANTES CON UBICACIONES DE LA BODEGA"
        Me.GroupPanel1.ResumeLayout(False)
        CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Btn_VerInventario As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelItem1 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents Btn_EditarInventario As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_EliminarInventario As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelItem3 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Txt_Filtrar As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents ContextMenuBar1 As DevComponents.DotNetBar.ContextMenuBar
    Friend WithEvents Menu_Contextual_MantSector As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Lbl_Sector As DevComponents.DotNetBar.LabelItem
    Friend WithEvents Btn_EditarUbicacion As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_EliminarUbicacion As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelItem2 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents Grilla As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents Btn_Crear_Ubicacion As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Importar_Desde_Excel As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_ImprimirMasivamente As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Copiar As DevComponents.DotNetBar.ButtonItem
End Class
