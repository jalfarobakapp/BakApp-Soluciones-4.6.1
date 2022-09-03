<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Formulario_Descuentos
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
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Formulario_Descuentos))
        Me.Lbl_DescuentoValor = New DevComponents.DotNetBar.LabelX()
        Me.Lbl_DescuentoPorc = New DevComponents.DotNetBar.LabelX()
        Me.Lbl_Total = New DevComponents.DotNetBar.LabelX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.Grilla_Descuentos = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.Lbl_Codigo = New DevComponents.DotNetBar.LabelX()
        Me.Lbl_Descripcion = New DevComponents.DotNetBar.LabelX()
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.GroupPanel2 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.CodDscto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Podt = New DevComponents.DotNetBar.Controls.DataGridViewDoubleInputColumn()
        Me.Vadt = New DevComponents.DotNetBar.Controls.DataGridViewDoubleInputColumn()
        Me.UltDscto = New DevComponents.DotNetBar.Controls.DataGridViewDoubleInputColumn()
        Me.Podt_Original = New DevComponents.DotNetBar.Controls.DataGridViewDoubleInputColumn()
        CType(Me.Grilla_Descuentos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel1.SuspendLayout()
        Me.GroupPanel2.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Lbl_DescuentoValor
        '
        Me.Lbl_DescuentoValor.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_DescuentoValor.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_DescuentoValor.ForeColor = System.Drawing.Color.Black
        Me.Lbl_DescuentoValor.Location = New System.Drawing.Point(130, 23)
        Me.Lbl_DescuentoValor.Name = "Lbl_DescuentoValor"
        Me.Lbl_DescuentoValor.Size = New System.Drawing.Size(120, 12)
        Me.Lbl_DescuentoValor.TabIndex = 33
        Me.Lbl_DescuentoValor.Text = "0"
        Me.Lbl_DescuentoValor.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'Lbl_DescuentoPorc
        '
        Me.Lbl_DescuentoPorc.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_DescuentoPorc.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_DescuentoPorc.ForeColor = System.Drawing.Color.Black
        Me.Lbl_DescuentoPorc.Location = New System.Drawing.Point(130, 4)
        Me.Lbl_DescuentoPorc.Name = "Lbl_DescuentoPorc"
        Me.Lbl_DescuentoPorc.Size = New System.Drawing.Size(120, 12)
        Me.Lbl_DescuentoPorc.TabIndex = 32
        Me.Lbl_DescuentoPorc.Text = "0"
        Me.Lbl_DescuentoPorc.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'Lbl_Total
        '
        Me.Lbl_Total.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_Total.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Total.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Total.Location = New System.Drawing.Point(130, 42)
        Me.Lbl_Total.Name = "Lbl_Total"
        Me.Lbl_Total.Size = New System.Drawing.Size(120, 13)
        Me.Lbl_Total.TabIndex = 34
        Me.Lbl_Total.Text = "0"
        Me.Lbl_Total.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'LabelX2
        '
        Me.LabelX2.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.ForeColor = System.Drawing.Color.Black
        Me.LabelX2.Location = New System.Drawing.Point(4, 4)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(75, 12)
        Me.LabelX2.TabIndex = 30
        Me.LabelX2.Text = "Total Dscto %"
        '
        'LabelX3
        '
        Me.LabelX3.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.ForeColor = System.Drawing.Color.Black
        Me.LabelX3.Location = New System.Drawing.Point(4, 42)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(75, 13)
        Me.LabelX3.TabIndex = 31
        Me.LabelX3.Text = "Total $"
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.ForeColor = System.Drawing.Color.Black
        Me.LabelX1.Location = New System.Drawing.Point(4, 23)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(75, 12)
        Me.LabelX1.TabIndex = 29
        Me.LabelX1.Text = "Total Dscto $"
        '
        'Grilla_Descuentos
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Grilla_Descuentos.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.Grilla_Descuentos.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla_Descuentos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.Grilla_Descuentos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Grilla_Descuentos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CodDscto, Me.Podt, Me.Vadt, Me.UltDscto, Me.Podt_Original})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Grilla_Descuentos.DefaultCellStyle = DataGridViewCellStyle3
        Me.Grilla_Descuentos.EnableHeadersVisualStyles = False
        Me.Grilla_Descuentos.GridColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.Grilla_Descuentos.Location = New System.Drawing.Point(0, 0)
        Me.Grilla_Descuentos.Name = "Grilla_Descuentos"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla_Descuentos.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.Grilla_Descuentos.RowHeadersVisible = False
        Me.Grilla_Descuentos.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        Me.Grilla_Descuentos.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Grilla_Descuentos.Size = New System.Drawing.Size(265, 129)
        Me.Grilla_Descuentos.TabIndex = 0
        '
        'Lbl_Codigo
        '
        Me.Lbl_Codigo.AutoSize = True
        Me.Lbl_Codigo.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_Codigo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Codigo.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Codigo.Location = New System.Drawing.Point(0, 68)
        Me.Lbl_Codigo.Name = "Lbl_Codigo"
        Me.Lbl_Codigo.Size = New System.Drawing.Size(36, 17)
        Me.Lbl_Codigo.TabIndex = 30
        Me.Lbl_Codigo.Text = "codigo"
        '
        'Lbl_Descripcion
        '
        Me.Lbl_Descripcion.AutoSize = True
        Me.Lbl_Descripcion.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_Descripcion.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Descripcion.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Descripcion.Location = New System.Drawing.Point(0, 90)
        Me.Lbl_Descripcion.Name = "Lbl_Descripcion"
        Me.Lbl_Descripcion.Size = New System.Drawing.Size(59, 17)
        Me.Lbl_Descripcion.TabIndex = 29
        Me.Lbl_Descripcion.Text = "Descripcion"
        '
        'GroupPanel1
        '
        Me.GroupPanel1.BackColor = System.Drawing.Color.White
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.Grilla_Descuentos)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Location = New System.Drawing.Point(8, 12)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(271, 152)
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
        Me.GroupPanel1.TabIndex = 39
        Me.GroupPanel1.Text = "Descuentos por producto"
        '
        'GroupPanel2
        '
        Me.GroupPanel2.BackColor = System.Drawing.Color.White
        Me.GroupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel2.Controls.Add(Me.Lbl_Descripcion)
        Me.GroupPanel2.Controls.Add(Me.TableLayoutPanel1)
        Me.GroupPanel2.Controls.Add(Me.Lbl_Codigo)
        Me.GroupPanel2.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel2.Location = New System.Drawing.Point(8, 170)
        Me.GroupPanel2.Name = "GroupPanel2"
        Me.GroupPanel2.Size = New System.Drawing.Size(271, 144)
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
        Me.GroupPanel2.TabIndex = 40
        Me.GroupPanel2.Text = "Total descuentos"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.[Single]
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Lbl_Total, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelX2, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Lbl_DescuentoValor, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelX1, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Lbl_DescuentoPorc, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelX3, 0, 2)
        Me.TableLayoutPanel1.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(1, 3)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(254, 59)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'CodDscto
        '
        Me.CodDscto.HeaderText = "Cód. Dscto."
        Me.CodDscto.Name = "CodDscto"
        '
        'Podt
        '
        '
        '
        '
        Me.Podt.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Podt.BackgroundStyle.Class = "DataGridViewNumericBorder"
        Me.Podt.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Podt.BackgroundStyle.TextColor = System.Drawing.Color.Black
        Me.Podt.HeaderText = "Dscto%"
        Me.Podt.Increment = 1.0R
        Me.Podt.Name = "Podt"
        Me.Podt.Width = 50
        '
        'Vadt
        '
        '
        '
        '
        Me.Vadt.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Vadt.BackgroundStyle.Class = "DataGridViewNumericBorder"
        Me.Vadt.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Vadt.BackgroundStyle.TextColor = System.Drawing.Color.Black
        Me.Vadt.HeaderText = "Valor"
        Me.Vadt.Increment = 1.0R
        Me.Vadt.Name = "Vadt"
        Me.Vadt.Width = 90
        '
        'UltDscto
        '
        '
        '
        '
        Me.UltDscto.BackgroundStyle.Class = "DataGridViewNumericBorder"
        Me.UltDscto.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.UltDscto.HeaderText = "UltDscto"
        Me.UltDscto.Increment = 1.0R
        Me.UltDscto.Name = "UltDscto"
        Me.UltDscto.Visible = False
        '
        'Podt_Original
        '
        '
        '
        '
        Me.Podt_Original.BackgroundStyle.Class = "DataGridViewNumericBorder"
        Me.Podt_Original.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Podt_Original.HeaderText = "Podt_Original"
        Me.Podt_Original.Increment = 1.0R
        Me.Podt_Original.MaxValue = 100.0R
        Me.Podt_Original.MinValue = -100.0R
        Me.Podt_Original.Name = "Podt_Original"
        Me.Podt_Original.Visible = False
        '
        'Frm_Formulario_Descuentos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(288, 326)
        Me.Controls.Add(Me.GroupPanel2)
        Me.Controls.Add(Me.GroupPanel1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Formulario_Descuentos"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Descuentos"
        CType(Me.Grilla_Descuentos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel1.ResumeLayout(False)
        Me.GroupPanel2.ResumeLayout(False)
        Me.GroupPanel2.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Lbl_DescuentoValor As DevComponents.DotNetBar.LabelX
    Friend WithEvents Lbl_DescuentoPorc As DevComponents.DotNetBar.LabelX
    Friend WithEvents Lbl_Total As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Grilla_Descuentos As DevComponents.DotNetBar.Controls.DataGridViewX
    Public WithEvents Lbl_Codigo As DevComponents.DotNetBar.LabelX
    Public WithEvents Lbl_Descripcion As DevComponents.DotNetBar.LabelX
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents GroupPanel2 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents CodDscto As DataGridViewTextBoxColumn
    Friend WithEvents Podt As DevComponents.DotNetBar.Controls.DataGridViewDoubleInputColumn
    Friend WithEvents Vadt As DevComponents.DotNetBar.Controls.DataGridViewDoubleInputColumn
    Friend WithEvents UltDscto As DevComponents.DotNetBar.Controls.DataGridViewDoubleInputColumn
    Friend WithEvents Podt_Original As DevComponents.DotNetBar.Controls.DataGridViewDoubleInputColumn
End Class
