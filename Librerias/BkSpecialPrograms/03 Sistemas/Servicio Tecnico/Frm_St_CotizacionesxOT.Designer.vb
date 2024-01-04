<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_St_CotizacionesxOT
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_St_CotizacionesxOT))
        Me.GroupPanel2 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Grilla = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.Btn_GenerarPDF = New DevComponents.DotNetBar.ButtonItem()
        Me.Chk_Marcar_Todas = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Rdb_DocTodos = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_DocCOV = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_DocNVV = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.GroupPanel2.SuspendLayout()
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupPanel2
        '
        Me.GroupPanel2.BackColor = System.Drawing.Color.White
        Me.GroupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel2.Controls.Add(Me.Grilla)
        Me.GroupPanel2.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel2.Location = New System.Drawing.Point(12, 12)
        Me.GroupPanel2.Name = "GroupPanel2"
        Me.GroupPanel2.Size = New System.Drawing.Size(840, 239)
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
        Me.GroupPanel2.TabIndex = 122
        Me.GroupPanel2.Text = "Detalle de documentos asociados a las Sub-Ot"
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
        Me.Grilla.MultiSelect = False
        Me.Grilla.Name = "Grilla"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.Grilla.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.Grilla.Size = New System.Drawing.Size(834, 216)
        Me.Grilla.TabIndex = 1
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_GenerarPDF})
        Me.Bar1.Location = New System.Drawing.Point(0, 317)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(865, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 123
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'Btn_GenerarPDF
        '
        Me.Btn_GenerarPDF.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_GenerarPDF.ForeColor = System.Drawing.Color.Black
        Me.Btn_GenerarPDF.Image = CType(resources.GetObject("Btn_GenerarPDF.Image"), System.Drawing.Image)
        Me.Btn_GenerarPDF.ImageAlt = CType(resources.GetObject("Btn_GenerarPDF.ImageAlt"), System.Drawing.Image)
        Me.Btn_GenerarPDF.Name = "Btn_GenerarPDF"
        Me.Btn_GenerarPDF.Text = "Crear PDF"
        '
        'Chk_Marcar_Todas
        '
        Me.Chk_Marcar_Todas.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Chk_Marcar_Todas.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Marcar_Todas.FocusCuesEnabled = False
        Me.Chk_Marcar_Todas.ForeColor = System.Drawing.Color.Black
        Me.Chk_Marcar_Todas.Location = New System.Drawing.Point(12, 286)
        Me.Chk_Marcar_Todas.Name = "Chk_Marcar_Todas"
        Me.Chk_Marcar_Todas.Size = New System.Drawing.Size(100, 23)
        Me.Chk_Marcar_Todas.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Marcar_Todas.TabIndex = 124
        Me.Chk_Marcar_Todas.Text = "Marcar todas"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.21212!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 29.62963!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.15825!))
        Me.TableLayoutPanel1.Controls.Add(Me.Rdb_DocTodos, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Rdb_DocCOV, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Rdb_DocNVV, 2, 0)
        Me.TableLayoutPanel1.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(120, 257)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(266, 28)
        Me.TableLayoutPanel1.TabIndex = 140
        '
        'Rdb_DocTodos
        '
        Me.Rdb_DocTodos.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_DocTodos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_DocTodos.CheckBoxImageChecked = CType(resources.GetObject("Rdb_DocTodos.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Rdb_DocTodos.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_DocTodos.Checked = True
        Me.Rdb_DocTodos.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Rdb_DocTodos.CheckValue = "Y"
        Me.Rdb_DocTodos.FocusCuesEnabled = False
        Me.Rdb_DocTodos.ForeColor = System.Drawing.Color.Black
        Me.Rdb_DocTodos.Location = New System.Drawing.Point(3, 3)
        Me.Rdb_DocTodos.Name = "Rdb_DocTodos"
        Me.Rdb_DocTodos.Size = New System.Drawing.Size(50, 20)
        Me.Rdb_DocTodos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_DocTodos.TabIndex = 134
        Me.Rdb_DocTodos.TabStop = False
        Me.Rdb_DocTodos.Text = "Todos"
        '
        'Rdb_DocCOV
        '
        Me.Rdb_DocCOV.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_DocCOV.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_DocCOV.CheckBoxImageChecked = CType(resources.GetObject("Rdb_DocCOV.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Rdb_DocCOV.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_DocCOV.FocusCuesEnabled = False
        Me.Rdb_DocCOV.ForeColor = System.Drawing.Color.Black
        Me.Rdb_DocCOV.Location = New System.Drawing.Point(59, 3)
        Me.Rdb_DocCOV.Name = "Rdb_DocCOV"
        Me.Rdb_DocCOV.Size = New System.Drawing.Size(71, 19)
        Me.Rdb_DocCOV.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_DocCOV.TabIndex = 135
        Me.Rdb_DocCOV.TabStop = False
        Me.Rdb_DocCOV.Text = "Cotizaciones"
        '
        'Rdb_DocNVV
        '
        Me.Rdb_DocNVV.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_DocNVV.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_DocNVV.CheckBoxImageChecked = CType(resources.GetObject("Rdb_DocNVV.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Rdb_DocNVV.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_DocNVV.FocusCuesEnabled = False
        Me.Rdb_DocNVV.ForeColor = System.Drawing.Color.Black
        Me.Rdb_DocNVV.Location = New System.Drawing.Point(137, 3)
        Me.Rdb_DocNVV.Name = "Rdb_DocNVV"
        Me.Rdb_DocNVV.Size = New System.Drawing.Size(103, 19)
        Me.Rdb_DocNVV.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_DocNVV.TabIndex = 136
        Me.Rdb_DocNVV.TabStop = False
        Me.Rdb_DocNVV.Text = "Notas de venta"
        '
        'LabelX2
        '
        Me.LabelX2.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.ForeColor = System.Drawing.Color.Black
        Me.LabelX2.Location = New System.Drawing.Point(12, 257)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(102, 23)
        Me.LabelX2.TabIndex = 139
        Me.LabelX2.Text = "Ver docuemntos:"
        '
        'Frm_St_CotizacionesxOT
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(865, 358)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.LabelX2)
        Me.Controls.Add(Me.Chk_Marcar_Todas)
        Me.Controls.Add(Me.Bar1)
        Me.Controls.Add(Me.GroupPanel2)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_St_CotizacionesxOT"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "DOCUMENTOS ASOCIADOS"
        Me.GroupPanel2.ResumeLayout(False)
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupPanel2 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Grilla As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Public WithEvents Btn_GenerarPDF As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Chk_Marcar_Todas As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents Rdb_DocTodos As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_DocCOV As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_DocNVV As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
End Class
