<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Patentes
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Patentes))
        Me.GroupPanel3 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Grilla = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.Bar2 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Nuevo_Despacho = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Buscar_Despacho = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Actualizar = New DevComponents.DotNetBar.ButtonItem()
        Me.BtnExportarExcel = New DevComponents.DotNetBar.ButtonItem()
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Txt_Modelo = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_Marca = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_Patente = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.GroupPanel3.SuspendLayout()
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupPanel3
        '
        Me.GroupPanel3.BackColor = System.Drawing.Color.White
        Me.GroupPanel3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel3.Controls.Add(Me.Grilla)
        Me.GroupPanel3.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel3.Location = New System.Drawing.Point(12, 123)
        Me.GroupPanel3.Name = "GroupPanel3"
        Me.GroupPanel3.Size = New System.Drawing.Size(553, 433)
        '
        '
        '
        Me.GroupPanel3.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.GroupPanel3.Style.BackColorGradientAngle = 90
        Me.GroupPanel3.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.GroupPanel3.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel3.Style.BorderBottomWidth = 1
        Me.GroupPanel3.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupPanel3.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel3.Style.BorderLeftWidth = 1
        Me.GroupPanel3.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel3.Style.BorderRightWidth = 1
        Me.GroupPanel3.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel3.Style.BorderTopWidth = 1
        Me.GroupPanel3.Style.CornerDiameter = 4
        Me.GroupPanel3.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanel3.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanel3.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GroupPanel3.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupPanel3.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanel3.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanel3.TabIndex = 159
        Me.GroupPanel3.Text = "DETALLE"
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
        Me.Grilla.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.Grilla.Size = New System.Drawing.Size(547, 410)
        Me.Grilla.StandardTab = True
        Me.Grilla.TabIndex = 28
        '
        'Bar2
        '
        Me.Bar2.AntiAlias = True
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Nuevo_Despacho, Me.Btn_Buscar_Despacho, Me.Btn_Actualizar, Me.BtnExportarExcel})
        Me.Bar2.Location = New System.Drawing.Point(0, 562)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(577, 41)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Bar2.TabIndex = 158
        Me.Bar2.TabStop = False
        Me.Bar2.Text = "Bar2"
        '
        'Btn_Nuevo_Despacho
        '
        Me.Btn_Nuevo_Despacho.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Nuevo_Despacho.ForeColor = System.Drawing.Color.Black
        Me.Btn_Nuevo_Despacho.Image = CType(resources.GetObject("Btn_Nuevo_Despacho.Image"), System.Drawing.Image)
        Me.Btn_Nuevo_Despacho.ImageAlt = CType(resources.GetObject("Btn_Nuevo_Despacho.ImageAlt"), System.Drawing.Image)
        Me.Btn_Nuevo_Despacho.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.Btn_Nuevo_Despacho.Name = "Btn_Nuevo_Despacho"
        Me.Btn_Nuevo_Despacho.Tooltip = "Crear Orden de despacho"
        '
        'Btn_Buscar_Despacho
        '
        Me.Btn_Buscar_Despacho.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Buscar_Despacho.ForeColor = System.Drawing.Color.Black
        Me.Btn_Buscar_Despacho.Image = CType(resources.GetObject("Btn_Buscar_Despacho.Image"), System.Drawing.Image)
        Me.Btn_Buscar_Despacho.ImageAlt = CType(resources.GetObject("Btn_Buscar_Despacho.ImageAlt"), System.Drawing.Image)
        Me.Btn_Buscar_Despacho.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.Btn_Buscar_Despacho.Name = "Btn_Buscar_Despacho"
        Me.Btn_Buscar_Despacho.Tooltip = "Buscar Orden de despacho"
        '
        'Btn_Actualizar
        '
        Me.Btn_Actualizar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Actualizar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Actualizar.Image = CType(resources.GetObject("Btn_Actualizar.Image"), System.Drawing.Image)
        Me.Btn_Actualizar.ImageAlt = CType(resources.GetObject("Btn_Actualizar.ImageAlt"), System.Drawing.Image)
        Me.Btn_Actualizar.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.Btn_Actualizar.Name = "Btn_Actualizar"
        Me.Btn_Actualizar.Tooltip = "Refrescar datos"
        '
        'BtnExportarExcel
        '
        Me.BtnExportarExcel.ForeColor = System.Drawing.Color.Black
        Me.BtnExportarExcel.Image = CType(resources.GetObject("BtnExportarExcel.Image"), System.Drawing.Image)
        Me.BtnExportarExcel.ImageAlt = CType(resources.GetObject("BtnExportarExcel.ImageAlt"), System.Drawing.Image)
        Me.BtnExportarExcel.Name = "BtnExportarExcel"
        Me.BtnExportarExcel.Tooltip = "Exportar a excel (Vista actual)"
        '
        'GroupPanel1
        '
        Me.GroupPanel1.BackColor = System.Drawing.Color.White
        Me.GroupPanel1.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.LabelX4)
        Me.GroupPanel1.Controls.Add(Me.Txt_Patente)
        Me.GroupPanel1.Controls.Add(Me.Txt_Modelo)
        Me.GroupPanel1.Controls.Add(Me.LabelX2)
        Me.GroupPanel1.Controls.Add(Me.Txt_Marca)
        Me.GroupPanel1.Controls.Add(Me.LabelX1)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Location = New System.Drawing.Point(12, 2)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(553, 115)
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
        Me.GroupPanel1.TabIndex = 160
        Me.GroupPanel1.Text = "GroupPanel1"
        '
        'Txt_Modelo
        '
        Me.Txt_Modelo.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Modelo.Border.Class = "TextBoxBorder"
        Me.Txt_Modelo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Modelo.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Modelo.ForeColor = System.Drawing.Color.Black
        Me.Txt_Modelo.Location = New System.Drawing.Point(84, 65)
        Me.Txt_Modelo.Name = "Txt_Modelo"
        Me.Txt_Modelo.PreventEnterBeep = True
        Me.Txt_Modelo.Size = New System.Drawing.Size(258, 22)
        Me.Txt_Modelo.TabIndex = 3
        '
        'LabelX2
        '
        Me.LabelX2.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Location = New System.Drawing.Point(3, 64)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(75, 23)
        Me.LabelX2.TabIndex = 2
        Me.LabelX2.Text = "LabelX2"
        '
        'Txt_Marca
        '
        Me.Txt_Marca.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Marca.Border.Class = "TextBoxBorder"
        Me.Txt_Marca.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Marca.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Marca.ForeColor = System.Drawing.Color.Black
        Me.Txt_Marca.Location = New System.Drawing.Point(84, 37)
        Me.Txt_Marca.Name = "Txt_Marca"
        Me.Txt_Marca.PreventEnterBeep = True
        Me.Txt_Marca.Size = New System.Drawing.Size(258, 22)
        Me.Txt_Marca.TabIndex = 1
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Location = New System.Drawing.Point(3, 36)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(75, 23)
        Me.LabelX1.TabIndex = 0
        Me.LabelX1.Text = "LabelX1"
        '
        'LabelX4
        '
        Me.LabelX4.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.ForeColor = System.Drawing.Color.Black
        Me.LabelX4.Location = New System.Drawing.Point(0, 6)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(51, 23)
        Me.LabelX4.TabIndex = 59
        Me.LabelX4.Text = "PATENTE"
        Me.LabelX4.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'Txt_Patente
        '
        Me.Txt_Patente.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Patente.Border.Class = "TextBoxBorder"
        Me.Txt_Patente.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Patente.ButtonCustom.Image = CType(resources.GetObject("Txt_Patente.ButtonCustom.Image"), System.Drawing.Image)
        Me.Txt_Patente.ButtonCustom2.Image = CType(resources.GetObject("Txt_Patente.ButtonCustom2.Image"), System.Drawing.Image)
        Me.Txt_Patente.ButtonCustom2.Visible = True
        Me.Txt_Patente.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Patente.FocusHighlightColor = System.Drawing.Color.PaleTurquoise
        Me.Txt_Patente.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.Txt_Patente.ForeColor = System.Drawing.Color.Black
        Me.Txt_Patente.Location = New System.Drawing.Point(84, 6)
        Me.Txt_Patente.MaxLength = 6
        Me.Txt_Patente.Name = "Txt_Patente"
        Me.Txt_Patente.PreventEnterBeep = True
        Me.Txt_Patente.Size = New System.Drawing.Size(88, 22)
        Me.Txt_Patente.TabIndex = 60
        Me.Txt_Patente.Text = "WWWW99"
        Me.Txt_Patente.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Txt_Patente.WatermarkText = "Ingrese parte del código, descripción, familia, etc.. del producto a buscar"
        '
        'Frm_Patentes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(577, 603)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Controls.Add(Me.GroupPanel3)
        Me.Controls.Add(Me.Bar2)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Patentes"
        Me.Text = "MetroForm"
        Me.GroupPanel3.ResumeLayout(False)
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupPanel3 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Grilla As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Public WithEvents Btn_Nuevo_Despacho As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_Buscar_Despacho As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_Actualizar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents BtnExportarExcel As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Txt_Modelo As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Txt_Marca As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Public WithEvents Txt_Patente As DevComponents.DotNetBar.Controls.TextBoxX
End Class
