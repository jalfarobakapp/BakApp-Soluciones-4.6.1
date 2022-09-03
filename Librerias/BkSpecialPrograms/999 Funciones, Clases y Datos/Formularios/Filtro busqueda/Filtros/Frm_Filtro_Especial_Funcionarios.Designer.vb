<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Filtro_Especial_Funcionarios
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Filtro_Especial_Funcionarios))
        Me.GroupPanel3 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.Rdb_Responzables_Algunos = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_Responzables_Todos = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.TableLayoutPanel5 = New System.Windows.Forms.TableLayoutPanel()
        Me.LabelX6 = New DevComponents.DotNetBar.LabelX()
        Me.Rdb_Vendedores_Algunos = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_Vendedores_Todos = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Aceptar = New DevComponents.DotNetBar.ButtonItem()
        Me.GroupPanel3.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel5.SuspendLayout()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupPanel3
        '
        Me.GroupPanel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GroupPanel3.CanvasColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GroupPanel3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel3.Controls.Add(Me.TableLayoutPanel1)
        Me.GroupPanel3.Controls.Add(Me.TableLayoutPanel5)
        Me.GroupPanel3.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel3.Location = New System.Drawing.Point(12, 12)
        Me.GroupPanel3.Name = "GroupPanel3"
        Me.GroupPanel3.Size = New System.Drawing.Size(311, 100)
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
        Me.GroupPanel3.TabIndex = 20
        Me.GroupPanel3.Text = "Filtros Funcionarios"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 84.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 106.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.LabelX1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Rdb_Responzables_Algunos, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Rdb_Responzables_Todos, 1, 0)
        Me.TableLayoutPanel1.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 13)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(296, 25)
        Me.TableLayoutPanel1.TabIndex = 48
        '
        'LabelX1
        '
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.ForeColor = System.Drawing.Color.Black
        Me.LabelX1.Location = New System.Drawing.Point(3, 3)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(100, 19)
        Me.LabelX1.TabIndex = 4
        Me.LabelX1.Text = "Responzables"
        '
        'Rdb_Responzables_Algunos
        '
        Me.Rdb_Responzables_Algunos.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Responzables_Algunos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Responzables_Algunos.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Responzables_Algunos.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Responzables_Algunos.Location = New System.Drawing.Point(193, 3)
        Me.Rdb_Responzables_Algunos.Name = "Rdb_Responzables_Algunos"
        Me.Rdb_Responzables_Algunos.Size = New System.Drawing.Size(94, 19)
        Me.Rdb_Responzables_Algunos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Responzables_Algunos.TabIndex = 3
        Me.Rdb_Responzables_Algunos.Text = "Algunos"
        '
        'Rdb_Responzables_Todos
        '
        Me.Rdb_Responzables_Todos.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Responzables_Todos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Responzables_Todos.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Responzables_Todos.Checked = True
        Me.Rdb_Responzables_Todos.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Rdb_Responzables_Todos.CheckValue = "Y"
        Me.Rdb_Responzables_Todos.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Responzables_Todos.Location = New System.Drawing.Point(109, 3)
        Me.Rdb_Responzables_Todos.Name = "Rdb_Responzables_Todos"
        Me.Rdb_Responzables_Todos.Size = New System.Drawing.Size(78, 19)
        Me.Rdb_Responzables_Todos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Responzables_Todos.TabIndex = 1
        Me.Rdb_Responzables_Todos.Text = "Todas "
        '
        'TableLayoutPanel5
        '
        Me.TableLayoutPanel5.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel5.ColumnCount = 3
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 84.0!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 106.0!))
        Me.TableLayoutPanel5.Controls.Add(Me.LabelX6, 0, 0)
        Me.TableLayoutPanel5.Controls.Add(Me.Rdb_Vendedores_Algunos, 2, 0)
        Me.TableLayoutPanel5.Controls.Add(Me.Rdb_Vendedores_Todos, 1, 0)
        Me.TableLayoutPanel5.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel5.Location = New System.Drawing.Point(3, 44)
        Me.TableLayoutPanel5.Name = "TableLayoutPanel5"
        Me.TableLayoutPanel5.RowCount = 1
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel5.Size = New System.Drawing.Size(296, 25)
        Me.TableLayoutPanel5.TabIndex = 47
        '
        'LabelX6
        '
        '
        '
        '
        Me.LabelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX6.ForeColor = System.Drawing.Color.Black
        Me.LabelX6.Location = New System.Drawing.Point(3, 3)
        Me.LabelX6.Name = "LabelX6"
        Me.LabelX6.Size = New System.Drawing.Size(100, 19)
        Me.LabelX6.TabIndex = 4
        Me.LabelX6.Text = "Vendedores"
        '
        'Rdb_Vendedores_Algunos
        '
        Me.Rdb_Vendedores_Algunos.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Vendedores_Algunos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Vendedores_Algunos.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Vendedores_Algunos.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Vendedores_Algunos.Location = New System.Drawing.Point(193, 3)
        Me.Rdb_Vendedores_Algunos.Name = "Rdb_Vendedores_Algunos"
        Me.Rdb_Vendedores_Algunos.Size = New System.Drawing.Size(94, 19)
        Me.Rdb_Vendedores_Algunos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Vendedores_Algunos.TabIndex = 3
        Me.Rdb_Vendedores_Algunos.Text = "Algunos"
        '
        'Rdb_Vendedores_Todos
        '
        Me.Rdb_Vendedores_Todos.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Vendedores_Todos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Vendedores_Todos.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Vendedores_Todos.Checked = True
        Me.Rdb_Vendedores_Todos.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Rdb_Vendedores_Todos.CheckValue = "Y"
        Me.Rdb_Vendedores_Todos.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Vendedores_Todos.Location = New System.Drawing.Point(109, 3)
        Me.Rdb_Vendedores_Todos.Name = "Rdb_Vendedores_Todos"
        Me.Rdb_Vendedores_Todos.Size = New System.Drawing.Size(78, 19)
        Me.Rdb_Vendedores_Todos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Vendedores_Todos.TabIndex = 1
        Me.Rdb_Vendedores_Todos.Text = "Todas "
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Aceptar})
        Me.Bar1.Location = New System.Drawing.Point(0, 137)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(333, 33)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 18
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'Btn_Aceptar
        '
        Me.Btn_Aceptar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Aceptar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Aceptar.Image = CType(resources.GetObject("Btn_Aceptar.Image"), System.Drawing.Image)
        Me.Btn_Aceptar.Name = "Btn_Aceptar"
        Me.Btn_Aceptar.Text = "Aceptar"
        '
        'Frm_Filtro_Especial_Funcionarios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(333, 170)
        Me.Controls.Add(Me.GroupPanel3)
        Me.Controls.Add(Me.Bar1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Filtro_Especial_Funcionarios"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Filtro Funcionarios"
        Me.GroupPanel3.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel5.ResumeLayout(False)
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupPanel3 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents TableLayoutPanel5 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents LabelX6 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Rdb_Vendedores_Algunos As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_Vendedores_Todos As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents Btn_Aceptar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Rdb_Responzables_Algunos As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_Responzables_Todos As DevComponents.DotNetBar.Controls.CheckBoxX
End Class
