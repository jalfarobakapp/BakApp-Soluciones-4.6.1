<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_RecargosXProd
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
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_RecargosXProd))
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Grilla = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.Bar2 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Aceptar = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Calcular_Recargo = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Traer_Documento = New DevComponents.DotNetBar.ButtonItem()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_Valor_Recargo = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Txt_Total_Cantidades = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.Tiempo = New System.Windows.Forms.Timer(Me.components)
        Me.CircularProgress1 = New DevComponents.DotNetBar.Controls.CircularProgress()
        Me.CmbTipoDeDocumentos = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.Chk_BuscarDocDeHoy = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.GroupPanel1.SuspendLayout()
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupPanel1
        '
        Me.GroupPanel1.BackColor = System.Drawing.Color.White
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.Grilla)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Location = New System.Drawing.Point(12, 29)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(867, 345)
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
        Me.GroupPanel1.TabIndex = 35
        Me.GroupPanel1.Text = "Recargos"
        '
        'Grilla
        '
        Me.Grilla.AllowUserToAddRows = False
        Me.Grilla.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.Grilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Grilla.DefaultCellStyle = DataGridViewCellStyle8
        Me.Grilla.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grilla.EnableHeadersVisualStyles = False
        Me.Grilla.GridColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.Grilla.Location = New System.Drawing.Point(0, 0)
        Me.Grilla.Name = "Grilla"
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla.RowHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.Grilla.Size = New System.Drawing.Size(861, 322)
        Me.Grilla.StandardTab = True
        Me.Grilla.TabIndex = 28
        '
        'Bar2
        '
        Me.Bar2.AntiAlias = True
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar2.Enabled = False
        Me.Bar2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Aceptar, Me.Btn_Calcular_Recargo, Me.Btn_Traer_Documento})
        Me.Bar2.Location = New System.Drawing.Point(0, 411)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(890, 41)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Bar2.TabIndex = 36
        Me.Bar2.TabStop = False
        Me.Bar2.Text = "Bar2"
        '
        'Btn_Aceptar
        '
        Me.Btn_Aceptar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Aceptar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Aceptar.Image = CType(resources.GetObject("Btn_Aceptar.Image"), System.Drawing.Image)
        Me.Btn_Aceptar.ImageAlt = CType(resources.GetObject("Btn_Aceptar.ImageAlt"), System.Drawing.Image)
        Me.Btn_Aceptar.Name = "Btn_Aceptar"
        Me.Btn_Aceptar.Tooltip = "Grabar"
        '
        'Btn_Calcular_Recargo
        '
        Me.Btn_Calcular_Recargo.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Calcular_Recargo.ForeColor = System.Drawing.Color.Black
        Me.Btn_Calcular_Recargo.Image = CType(resources.GetObject("Btn_Calcular_Recargo.Image"), System.Drawing.Image)
        Me.Btn_Calcular_Recargo.ImageAlt = CType(resources.GetObject("Btn_Calcular_Recargo.ImageAlt"), System.Drawing.Image)
        Me.Btn_Calcular_Recargo.Name = "Btn_Calcular_Recargo"
        Me.Btn_Calcular_Recargo.Tooltip = "Trasladar el valor de la celda ""Precio Neto"""
        '
        'Btn_Traer_Documento
        '
        Me.Btn_Traer_Documento.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Traer_Documento.ForeColor = System.Drawing.Color.Black
        Me.Btn_Traer_Documento.Image = CType(resources.GetObject("Btn_Traer_Documento.Image"), System.Drawing.Image)
        Me.Btn_Traer_Documento.ImageAlt = CType(resources.GetObject("Btn_Traer_Documento.ImageAlt"), System.Drawing.Image)
        Me.Btn_Traer_Documento.Name = "Btn_Traer_Documento"
        Me.Btn_Traer_Documento.Tooltip = "Buscar documentos para asociar"
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.ForeColor = System.Drawing.Color.Black
        Me.LabelX1.Location = New System.Drawing.Point(705, 7)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(83, 23)
        Me.LabelX1.TabIndex = 37
        Me.LabelX1.Text = "Valor recargo"
        Me.LabelX1.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'Txt_Valor_Recargo
        '
        Me.Txt_Valor_Recargo.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Valor_Recargo.Border.Class = "TextBoxBorder"
        Me.Txt_Valor_Recargo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Valor_Recargo.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Valor_Recargo.ForeColor = System.Drawing.Color.Black
        Me.Txt_Valor_Recargo.Location = New System.Drawing.Point(794, 8)
        Me.Txt_Valor_Recargo.Name = "Txt_Valor_Recargo"
        Me.Txt_Valor_Recargo.PreventEnterBeep = True
        Me.Txt_Valor_Recargo.ReadOnly = True
        Me.Txt_Valor_Recargo.Size = New System.Drawing.Size(85, 22)
        Me.Txt_Valor_Recargo.TabIndex = 38
        Me.Txt_Valor_Recargo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Txt_Total_Cantidades
        '
        Me.Txt_Total_Cantidades.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Total_Cantidades.Border.Class = "TextBoxBorder"
        Me.Txt_Total_Cantidades.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Total_Cantidades.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Total_Cantidades.ForeColor = System.Drawing.Color.Black
        Me.Txt_Total_Cantidades.Location = New System.Drawing.Point(794, 378)
        Me.Txt_Total_Cantidades.Name = "Txt_Total_Cantidades"
        Me.Txt_Total_Cantidades.PreventEnterBeep = True
        Me.Txt_Total_Cantidades.Size = New System.Drawing.Size(85, 22)
        Me.Txt_Total_Cantidades.TabIndex = 40
        Me.Txt_Total_Cantidades.Text = "0"
        Me.Txt_Total_Cantidades.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LabelX2
        '
        Me.LabelX2.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.ForeColor = System.Drawing.Color.Black
        Me.LabelX2.Location = New System.Drawing.Point(695, 377)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(93, 23)
        Me.LabelX2.TabIndex = 39
        Me.LabelX2.Text = "Total Cantidades"
        Me.LabelX2.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'Tiempo
        '
        Me.Tiempo.Interval = 7000
        '
        'CircularProgress1
        '
        Me.CircularProgress1.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.CircularProgress1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.CircularProgress1.Location = New System.Drawing.Point(664, 380)
        Me.CircularProgress1.Name = "CircularProgress1"
        Me.CircularProgress1.ProgressBarType = DevComponents.DotNetBar.eCircularProgressType.Dot
        Me.CircularProgress1.Size = New System.Drawing.Size(38, 31)
        Me.CircularProgress1.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP
        Me.CircularProgress1.TabIndex = 41
        '
        'CmbTipoDeDocumentos
        '
        Me.CmbTipoDeDocumentos.DisplayMember = "Text"
        Me.CmbTipoDeDocumentos.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.CmbTipoDeDocumentos.ForeColor = System.Drawing.Color.Black
        Me.CmbTipoDeDocumentos.FormattingEnabled = True
        Me.CmbTipoDeDocumentos.ItemHeight = 16
        Me.CmbTipoDeDocumentos.Location = New System.Drawing.Point(161, 376)
        Me.CmbTipoDeDocumentos.Name = "CmbTipoDeDocumentos"
        Me.CmbTipoDeDocumentos.Size = New System.Drawing.Size(236, 22)
        Me.CmbTipoDeDocumentos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.CmbTipoDeDocumentos.TabIndex = 42
        '
        'Chk_BuscarDocDeHoy
        '
        Me.Chk_BuscarDocDeHoy.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Chk_BuscarDocDeHoy.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Chk_BuscarDocDeHoy.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_BuscarDocDeHoy.CheckBoxImageChecked = CType(resources.GetObject("Chk_BuscarDocDeHoy.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_BuscarDocDeHoy.Checked = True
        Me.Chk_BuscarDocDeHoy.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Chk_BuscarDocDeHoy.CheckValue = "Y"
        Me.Chk_BuscarDocDeHoy.FocusCuesEnabled = False
        Me.Chk_BuscarDocDeHoy.ForeColor = System.Drawing.Color.Black
        Me.Chk_BuscarDocDeHoy.Location = New System.Drawing.Point(403, 378)
        Me.Chk_BuscarDocDeHoy.Name = "Chk_BuscarDocDeHoy"
        Me.Chk_BuscarDocDeHoy.Size = New System.Drawing.Size(155, 19)
        Me.Chk_BuscarDocDeHoy.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_BuscarDocDeHoy.TabIndex = 43
        Me.Chk_BuscarDocDeHoy.Text = "Buscar documentos de hoy"
        '
        'LabelX3
        '
        Me.LabelX3.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.ForeColor = System.Drawing.Color.Black
        Me.LabelX3.Location = New System.Drawing.Point(12, 375)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(143, 23)
        Me.LabelX3.TabIndex = 44
        Me.LabelX3.Text = "Doc. por defecto para buscar"
        Me.LabelX3.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'Frm_RecargosXProd
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(890, 452)
        Me.Controls.Add(Me.LabelX3)
        Me.Controls.Add(Me.CmbTipoDeDocumentos)
        Me.Controls.Add(Me.Chk_BuscarDocDeHoy)
        Me.Controls.Add(Me.CircularProgress1)
        Me.Controls.Add(Me.Txt_Total_Cantidades)
        Me.Controls.Add(Me.LabelX2)
        Me.Controls.Add(Me.Txt_Valor_Recargo)
        Me.Controls.Add(Me.LabelX1)
        Me.Controls.Add(Me.Bar2)
        Me.Controls.Add(Me.GroupPanel1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_RecargosXProd"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Calculo y forma de distribución de recargos"
        Me.GroupPanel1.ResumeLayout(False)
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Grilla As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents Btn_Aceptar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Traer_Documento As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Txt_Valor_Recargo As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Btn_Calcular_Recargo As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Txt_Total_Cantidades As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Tiempo As Timer
    Friend WithEvents CircularProgress1 As DevComponents.DotNetBar.Controls.CircularProgress
    Public WithEvents CmbTipoDeDocumentos As DevComponents.DotNetBar.Controls.ComboBoxEx
    Public WithEvents Chk_BuscarDocDeHoy As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
End Class
