<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Frm_BuscarOT
    Inherits DevComponents.DotNetBar.Metro.MetroForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_BuscarOT))
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.GroupPanel4 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Txt_Descripcion = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.GroupPanel2 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Grilla_Pote = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Salir = New DevComponents.DotNetBar.ButtonItem()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Rdb_Vigentes = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_Cerradas = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_Todas = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.BtnIrAlFin = New DevComponents.DotNetBar.ButtonItem()
        Me.BtnIrAptincipio = New DevComponents.DotNetBar.ButtonItem()
        Me.GroupPanel4.SuspendLayout()
        Me.GroupPanel2.SuspendLayout()
        CType(Me.Grilla_Pote, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupPanel4
        '
        Me.GroupPanel4.BackColor = System.Drawing.Color.White
        Me.GroupPanel4.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel4.Controls.Add(Me.Txt_Descripcion)
        Me.GroupPanel4.Controls.Add(Me.LabelX1)
        Me.GroupPanel4.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel4.Location = New System.Drawing.Point(12, 12)
        Me.GroupPanel4.Name = "GroupPanel4"
        Me.GroupPanel4.Size = New System.Drawing.Size(736, 78)
        '
        '
        '
        Me.GroupPanel4.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.GroupPanel4.Style.BackColorGradientAngle = 90
        Me.GroupPanel4.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.GroupPanel4.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel4.Style.BorderBottomWidth = 1
        Me.GroupPanel4.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupPanel4.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel4.Style.BorderLeftWidth = 1
        Me.GroupPanel4.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel4.Style.BorderRightWidth = 1
        Me.GroupPanel4.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel4.Style.BorderTopWidth = 1
        Me.GroupPanel4.Style.CornerDiameter = 4
        Me.GroupPanel4.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanel4.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanel4.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GroupPanel4.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupPanel4.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanel4.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanel4.TabIndex = 110
        Me.GroupPanel4.Text = "Buscar OT por Numero o referencia"
        '
        'Txt_Descripcion
        '
        Me.Txt_Descripcion.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Descripcion.Border.Class = "TextBoxBorder"
        Me.Txt_Descripcion.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Descripcion.ButtonCustom.Image = CType(resources.GetObject("Txt_Descripcion.ButtonCustom.Image"), System.Drawing.Image)
        Me.Txt_Descripcion.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Descripcion.ForeColor = System.Drawing.Color.Black
        Me.Txt_Descripcion.Location = New System.Drawing.Point(3, 30)
        Me.Txt_Descripcion.Name = "Txt_Descripcion"
        Me.Txt_Descripcion.PreventEnterBeep = True
        Me.Txt_Descripcion.Size = New System.Drawing.Size(727, 22)
        Me.Txt_Descripcion.TabIndex = 3
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.ForeColor = System.Drawing.Color.Black
        Me.LabelX1.Location = New System.Drawing.Point(3, 10)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(228, 23)
        Me.LabelX1.TabIndex = 5
        Me.LabelX1.Text = "Número de OT o Referencia"
        '
        'GroupPanel2
        '
        Me.GroupPanel2.BackColor = System.Drawing.Color.White
        Me.GroupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel2.Controls.Add(Me.Grilla_Pote)
        Me.GroupPanel2.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel2.Location = New System.Drawing.Point(12, 96)
        Me.GroupPanel2.Name = "GroupPanel2"
        Me.GroupPanel2.Size = New System.Drawing.Size(736, 339)
        '
        '
        '
        Me.GroupPanel2.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.GroupPanel2.Style.BackColorGradientAngle = 90
        Me.GroupPanel2.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.GroupPanel2.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel2.Style.BorderBottomWidth = 1
        Me.GroupPanel2.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupPanel2.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel2.Style.BorderLeftWidth = 1
        Me.GroupPanel2.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel2.Style.BorderRightWidth = 1
        Me.GroupPanel2.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel2.Style.BorderTopWidth = 1
        Me.GroupPanel2.Style.CornerDiameter = 4
        Me.GroupPanel2.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanel2.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanel2.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GroupPanel2.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupPanel2.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanel2.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanel2.TabIndex = 109
        Me.GroupPanel2.Text = "Ordenes de trabajo (Seleccione la OT con doble clic)"
        '
        'Grilla_Pote
        '
        Me.Grilla_Pote.AllowUserToAddRows = False
        Me.Grilla_Pote.AllowUserToDeleteRows = False
        Me.Grilla_Pote.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla_Pote.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.Grilla_Pote.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Grilla_Pote.DefaultCellStyle = DataGridViewCellStyle5
        Me.Grilla_Pote.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grilla_Pote.EnableHeadersVisualStyles = False
        Me.Grilla_Pote.GridColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.Grilla_Pote.Location = New System.Drawing.Point(0, 0)
        Me.Grilla_Pote.MultiSelect = False
        Me.Grilla_Pote.Name = "Grilla_Pote"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla_Pote.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.Grilla_Pote.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.Grilla_Pote.Size = New System.Drawing.Size(730, 316)
        Me.Grilla_Pote.TabIndex = 1
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.BtnIrAptincipio, Me.BtnIrAlFin, Me.Btn_Salir})
        Me.Bar1.Location = New System.Drawing.Point(0, 474)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(760, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 111
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'Btn_Salir
        '
        Me.Btn_Salir.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Salir.ForeColor = System.Drawing.Color.Black
        Me.Btn_Salir.Image = CType(resources.GetObject("Btn_Salir.Image"), System.Drawing.Image)
        Me.Btn_Salir.ImageAlt = CType(resources.GetObject("Btn_Salir.ImageAlt"), System.Drawing.Image)
        Me.Btn_Salir.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.Btn_Salir.Name = "Btn_Salir"
        Me.Btn_Salir.Tooltip = "Aplicar busqueda"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.Controls.Add(Me.Rdb_Vigentes, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Rdb_Cerradas, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Rdb_Todas, 2, 0)
        Me.TableLayoutPanel1.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(12, 441)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(238, 28)
        Me.TableLayoutPanel1.TabIndex = 140
        '
        'Rdb_Vigentes
        '
        Me.Rdb_Vigentes.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Vigentes.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Vigentes.CheckBoxImageChecked = CType(resources.GetObject("Rdb_Vigentes.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Rdb_Vigentes.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Vigentes.Checked = True
        Me.Rdb_Vigentes.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Rdb_Vigentes.CheckValue = "Y"
        Me.Rdb_Vigentes.FocusCuesEnabled = False
        Me.Rdb_Vigentes.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Vigentes.Location = New System.Drawing.Point(3, 3)
        Me.Rdb_Vigentes.Name = "Rdb_Vigentes"
        Me.Rdb_Vigentes.Size = New System.Drawing.Size(60, 22)
        Me.Rdb_Vigentes.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Vigentes.TabIndex = 134
        Me.Rdb_Vigentes.TabStop = False
        Me.Rdb_Vigentes.Text = "Vigentes"
        '
        'Rdb_Cerradas
        '
        Me.Rdb_Cerradas.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Cerradas.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Cerradas.CheckBoxImageChecked = CType(resources.GetObject("Rdb_Cerradas.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Rdb_Cerradas.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Cerradas.FocusCuesEnabled = False
        Me.Rdb_Cerradas.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Cerradas.Location = New System.Drawing.Point(82, 3)
        Me.Rdb_Cerradas.Name = "Rdb_Cerradas"
        Me.Rdb_Cerradas.Size = New System.Drawing.Size(71, 22)
        Me.Rdb_Cerradas.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Cerradas.TabIndex = 135
        Me.Rdb_Cerradas.TabStop = False
        Me.Rdb_Cerradas.Text = "Cerradas"
        '
        'Rdb_Todas
        '
        Me.Rdb_Todas.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Todas.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Todas.CheckBoxImageChecked = CType(resources.GetObject("Rdb_Todas.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Rdb_Todas.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Todas.FocusCuesEnabled = False
        Me.Rdb_Todas.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Todas.Location = New System.Drawing.Point(161, 3)
        Me.Rdb_Todas.Name = "Rdb_Todas"
        Me.Rdb_Todas.Size = New System.Drawing.Size(72, 22)
        Me.Rdb_Todas.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Todas.TabIndex = 136
        Me.Rdb_Todas.TabStop = False
        Me.Rdb_Todas.Text = "Todas"
        '
        'BtnIrAlFin
        '
        Me.BtnIrAlFin.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnIrAlFin.ForeColor = System.Drawing.Color.Black
        Me.BtnIrAlFin.Image = CType(resources.GetObject("BtnIrAlFin.Image"), System.Drawing.Image)
        Me.BtnIrAlFin.ImageAlt = CType(resources.GetObject("BtnIrAlFin.ImageAlt"), System.Drawing.Image)
        Me.BtnIrAlFin.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.BtnIrAlFin.Name = "BtnIrAlFin"
        Me.BtnIrAlFin.Tooltip = "Ir al último registro"
        '
        'BtnIrAptincipio
        '
        Me.BtnIrAptincipio.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnIrAptincipio.ForeColor = System.Drawing.Color.Black
        Me.BtnIrAptincipio.Image = CType(resources.GetObject("BtnIrAptincipio.Image"), System.Drawing.Image)
        Me.BtnIrAptincipio.ImageAlt = CType(resources.GetObject("BtnIrAptincipio.ImageAlt"), System.Drawing.Image)
        Me.BtnIrAptincipio.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.BtnIrAptincipio.Name = "BtnIrAptincipio"
        Me.BtnIrAptincipio.Tooltip = "Ir al primer registro"
        '
        'Frm_BuscarOT
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(760, 515)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.Bar1)
        Me.Controls.Add(Me.GroupPanel4)
        Me.Controls.Add(Me.GroupPanel2)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_BuscarOT"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "BUSCAR ORDEN DE TRABAJO"
        Me.GroupPanel4.ResumeLayout(False)
        Me.GroupPanel2.ResumeLayout(False)
        CType(Me.Grilla_Pote, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupPanel4 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Txt_Descripcion As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents GroupPanel2 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Grilla_Pote As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Public WithEvents Btn_Salir As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents Rdb_Vigentes As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_Cerradas As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_Todas As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents BtnIrAptincipio As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents BtnIrAlFin As DevComponents.DotNetBar.ButtonItem
End Class
