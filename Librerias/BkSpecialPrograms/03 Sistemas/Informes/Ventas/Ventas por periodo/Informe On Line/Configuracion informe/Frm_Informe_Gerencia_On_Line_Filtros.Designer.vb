<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Informe_Gerencia_On_Line_Filtros
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Informe_Gerencia_On_Line_Filtros))
        Me.GroupPanel4 = New DevComponents.DotNetBar.Controls.GroupPanel
        Me.Chk_Solo_Stock_Fisico = New DevComponents.DotNetBar.Controls.CheckBoxX
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX
        Me.Rdb_Super_Familia_Algunos = New DevComponents.DotNetBar.Controls.CheckBoxX
        Me.Rdb_Super_Familia_Todos = New DevComponents.DotNetBar.Controls.CheckBoxX
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX
        Me.Rdb_Sucursales_Algunas = New DevComponents.DotNetBar.Controls.CheckBoxX
        Me.Rdb_Sucursales_Todas = New DevComponents.DotNetBar.Controls.CheckBoxX
        Me.Bar1 = New DevComponents.DotNetBar.Bar
        Me.Btn_Agregar_Conexion = New DevComponents.DotNetBar.ButtonItem
        Me.BtnCancelar = New DevComponents.DotNetBar.ButtonItem
        Me.GroupPanel4.SuspendLayout()
        Me.TableLayoutPanel4.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupPanel4
        '
        Me.GroupPanel4.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GroupPanel4.CanvasColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GroupPanel4.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel4.Controls.Add(Me.Chk_Solo_Stock_Fisico)
        Me.GroupPanel4.Controls.Add(Me.TableLayoutPanel4)
        Me.GroupPanel4.Controls.Add(Me.TableLayoutPanel3)
        Me.GroupPanel4.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel4.Location = New System.Drawing.Point(12, 12)
        Me.GroupPanel4.Name = "GroupPanel4"
        Me.GroupPanel4.Size = New System.Drawing.Size(361, 114)
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
        Me.GroupPanel4.TabIndex = 37
        Me.GroupPanel4.Text = "Filtros"
        '
        'Chk_Solo_Stock_Fisico
        '
        Me.Chk_Solo_Stock_Fisico.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_Solo_Stock_Fisico.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Solo_Stock_Fisico.ForeColor = System.Drawing.Color.Black
        Me.Chk_Solo_Stock_Fisico.Location = New System.Drawing.Point(8, 62)
        Me.Chk_Solo_Stock_Fisico.Name = "Chk_Solo_Stock_Fisico"
        Me.Chk_Solo_Stock_Fisico.Size = New System.Drawing.Size(206, 23)
        Me.Chk_Solo_Stock_Fisico.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Solo_Stock_Fisico.TabIndex = 0
        Me.Chk_Solo_Stock_Fisico.Text = "Solo movimientos con stock físico"
        '
        'TableLayoutPanel4
        '
        Me.TableLayoutPanel4.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel4.ColumnCount = 3
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 91.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 111.0!))
        Me.TableLayoutPanel4.Controls.Add(Me.LabelX3, 0, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.Rdb_Super_Familia_Algunos, 2, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.Rdb_Super_Familia_Todos, 1, 0)
        Me.TableLayoutPanel4.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel4.Location = New System.Drawing.Point(8, 31)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        Me.TableLayoutPanel4.RowCount = 1
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel4.Size = New System.Drawing.Size(339, 25)
        Me.TableLayoutPanel4.TabIndex = 4
        '
        'LabelX3
        '
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.ForeColor = System.Drawing.Color.Black
        Me.LabelX3.Location = New System.Drawing.Point(3, 3)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(131, 19)
        Me.LabelX3.TabIndex = 4
        Me.LabelX3.Text = "Super Familia"
        '
        'Rdb_Super_Familia_Algunos
        '
        Me.Rdb_Super_Familia_Algunos.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Super_Familia_Algunos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Super_Familia_Algunos.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Super_Familia_Algunos.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Super_Familia_Algunos.Location = New System.Drawing.Point(231, 3)
        Me.Rdb_Super_Familia_Algunos.Name = "Rdb_Super_Familia_Algunos"
        Me.Rdb_Super_Familia_Algunos.Size = New System.Drawing.Size(94, 19)
        Me.Rdb_Super_Familia_Algunos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Super_Familia_Algunos.TabIndex = 3
        Me.Rdb_Super_Familia_Algunos.Text = "Algunos"
        '
        'Rdb_Super_Familia_Todos
        '
        Me.Rdb_Super_Familia_Todos.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Super_Familia_Todos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Super_Familia_Todos.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Super_Familia_Todos.Checked = True
        Me.Rdb_Super_Familia_Todos.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Rdb_Super_Familia_Todos.CheckValue = "Y"
        Me.Rdb_Super_Familia_Todos.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Super_Familia_Todos.Location = New System.Drawing.Point(140, 3)
        Me.Rdb_Super_Familia_Todos.Name = "Rdb_Super_Familia_Todos"
        Me.Rdb_Super_Familia_Todos.Size = New System.Drawing.Size(85, 19)
        Me.Rdb_Super_Familia_Todos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Super_Familia_Todos.TabIndex = 1
        Me.Rdb_Super_Familia_Todos.Text = "Todos"
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel3.ColumnCount = 3
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 91.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 111.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.LabelX2, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.Rdb_Sucursales_Algunas, 2, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.Rdb_Sucursales_Todas, 1, 0)
        Me.TableLayoutPanel3.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(8, 3)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 1
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(339, 25)
        Me.TableLayoutPanel3.TabIndex = 3
        '
        'LabelX2
        '
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.ForeColor = System.Drawing.Color.Black
        Me.LabelX2.Location = New System.Drawing.Point(3, 3)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(131, 19)
        Me.LabelX2.TabIndex = 4
        Me.LabelX2.Text = "Sucursales"
        '
        'Rdb_Sucursales_Algunas
        '
        Me.Rdb_Sucursales_Algunas.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Sucursales_Algunas.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Sucursales_Algunas.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Sucursales_Algunas.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Sucursales_Algunas.Location = New System.Drawing.Point(231, 3)
        Me.Rdb_Sucursales_Algunas.Name = "Rdb_Sucursales_Algunas"
        Me.Rdb_Sucursales_Algunas.Size = New System.Drawing.Size(94, 19)
        Me.Rdb_Sucursales_Algunas.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Sucursales_Algunas.TabIndex = 3
        Me.Rdb_Sucursales_Algunas.Text = "Algunas"
        '
        'Rdb_Sucursales_Todas
        '
        Me.Rdb_Sucursales_Todas.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Sucursales_Todas.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Sucursales_Todas.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Sucursales_Todas.Checked = True
        Me.Rdb_Sucursales_Todas.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Rdb_Sucursales_Todas.CheckValue = "Y"
        Me.Rdb_Sucursales_Todas.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Sucursales_Todas.Location = New System.Drawing.Point(140, 3)
        Me.Rdb_Sucursales_Todas.Name = "Rdb_Sucursales_Todas"
        Me.Rdb_Sucursales_Todas.Size = New System.Drawing.Size(85, 19)
        Me.Rdb_Sucursales_Todas.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Sucursales_Todas.TabIndex = 1
        Me.Rdb_Sucursales_Todas.Text = "Todas "
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Agregar_Conexion, Me.BtnCancelar})
        Me.Bar1.Location = New System.Drawing.Point(0, 143)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(389, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 91
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'Btn_Agregar_Conexion
        '
        Me.Btn_Agregar_Conexion.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Agregar_Conexion.ForeColor = System.Drawing.Color.Black
        Me.Btn_Agregar_Conexion.Image = CType(resources.GetObject("Btn_Agregar_Conexion.Image"), System.Drawing.Image)
        Me.Btn_Agregar_Conexion.Name = "Btn_Agregar_Conexion"
        Me.Btn_Agregar_Conexion.Text = "Grabar Filtros"
        '
        'BtnCancelar
        '
        Me.BtnCancelar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnCancelar.ForeColor = System.Drawing.Color.Black
        Me.BtnCancelar.Image = CType(resources.GetObject("BtnCancelar.Image"), System.Drawing.Image)
        Me.BtnCancelar.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Tooltip = "Cancelar"
        '
        'Frm_Informe_Gerencia_On_Line_Filtros
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(389, 184)
        Me.ControlBox = False
        Me.Controls.Add(Me.Bar1)
        Me.Controls.Add(Me.GroupPanel4)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Informe_Gerencia_On_Line_Filtros"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Filtros Informe Ventas  On-Line"
        Me.GroupPanel4.ResumeLayout(False)
        Me.TableLayoutPanel4.ResumeLayout(False)
        Me.TableLayoutPanel3.ResumeLayout(False)
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupPanel4 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Chk_Solo_Stock_Fisico As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents TableLayoutPanel4 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Rdb_Super_Familia_Algunos As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_Super_Familia_Todos As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents TableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Rdb_Sucursales_Algunas As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_Sucursales_Todas As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents Btn_Agregar_Conexion As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents BtnCancelar As DevComponents.DotNetBar.ButtonItem
End Class
