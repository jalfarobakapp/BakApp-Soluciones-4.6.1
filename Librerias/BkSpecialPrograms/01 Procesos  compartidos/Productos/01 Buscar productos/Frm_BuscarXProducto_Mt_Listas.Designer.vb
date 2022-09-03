<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_BuscarXProducto_Mt_Listas
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_BuscarXProducto_Mt_Listas))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.Bar1 = New DevComponents.DotNetBar.Bar
        Me.BtnExportarExcel = New DevComponents.DotNetBar.ButtonItem
        Me.BtnActualizarLista = New DevComponents.DotNetBar.ButtonItem
        Me.BtnSalir = New DevComponents.DotNetBar.ButtonItem
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Txtdescripcion = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX
        Me.TxtCodigo = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX
        Me.Label1 = New System.Windows.Forms.Label
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Grilla = New System.Windows.Forms.DataGridView
        Me.MenuContextual = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.Mnu_VerEstadisticas = New System.Windows.Forms.ToolStripMenuItem
        Me.VerAsocicaciónDelProductoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.TxtDescripcion_RD = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.Label2 = New System.Windows.Forms.Label
        Me.TextBox2 = New System.Windows.Forms.TextBox
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuContextual.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.BtnExportarExcel, Me.BtnActualizarLista, Me.BtnSalir})
        Me.Bar1.Location = New System.Drawing.Point(0, 520)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(980, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 28
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'BtnExportarExcel
        '
        Me.BtnExportarExcel.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnExportarExcel.ForeColor = System.Drawing.Color.Black
        Me.BtnExportarExcel.Image = Global.BkSpecialPrograms.My.Resources.Resources.export_to_excel
        Me.BtnExportarExcel.Name = "BtnExportarExcel"
        Me.BtnExportarExcel.Tooltip = "Foto del producto"
        '
        'BtnActualizarLista
        '
        Me.BtnActualizarLista.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnActualizarLista.ForeColor = System.Drawing.Color.Black
        Me.BtnActualizarLista.Image = CType(resources.GetObject("BtnActualizarLista.Image"), System.Drawing.Image)
        Me.BtnActualizarLista.Name = "BtnActualizarLista"
        Me.BtnActualizarLista.Tooltip = "Actualizar lista de costos"
        '
        'BtnSalir
        '
        Me.BtnSalir.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnSalir.FontBold = True
        Me.BtnSalir.ForeColor = System.Drawing.Color.Red
        Me.BtnSalir.Image = Global.BkSpecialPrograms.My.Resources.Resources.button_rounded_red_delete
        Me.BtnSalir.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.BtnSalir.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.BtnSalir.Name = "BtnSalir"
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.White
        Me.GroupBox2.Controls.Add(Me.Txtdescripcion)
        Me.GroupBox2.Controls.Add(Me.LabelX2)
        Me.GroupBox2.Controls.Add(Me.TxtCodigo)
        Me.GroupBox2.Controls.Add(Me.LabelX1)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.TextBox1)
        Me.GroupBox2.ForeColor = System.Drawing.Color.Black
        Me.GroupBox2.Location = New System.Drawing.Point(8, 6)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(965, 54)
        Me.GroupBox2.TabIndex = 27
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Cadena de búsqueda del producto, para buscar ingrese algo del código o la descrip" & _
            "ción y luego presione Enter"
        '
        'Txtdescripcion
        '
        Me.Txtdescripcion.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txtdescripcion.Border.Class = "TextBoxBorder"
        Me.Txtdescripcion.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txtdescripcion.DisabledBackColor = System.Drawing.Color.White
        Me.Txtdescripcion.FocusHighlightColor = System.Drawing.Color.PaleTurquoise
        Me.Txtdescripcion.ForeColor = System.Drawing.Color.Black
        Me.Txtdescripcion.Location = New System.Drawing.Point(316, 21)
        Me.Txtdescripcion.Name = "Txtdescripcion"
        Me.Txtdescripcion.PreventEnterBeep = True
        Me.Txtdescripcion.Size = New System.Drawing.Size(643, 22)
        Me.Txtdescripcion.TabIndex = 0
        Me.Txtdescripcion.WatermarkText = "Ingrese parte de la  descripción del producto a buscar"
        '
        'LabelX2
        '
        Me.LabelX2.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.ForeColor = System.Drawing.Color.Black
        Me.LabelX2.Location = New System.Drawing.Point(249, 21)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(82, 23)
        Me.LabelX2.TabIndex = 25
        Me.LabelX2.Text = "Descripción"
        '
        'TxtCodigo
        '
        Me.TxtCodigo.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TxtCodigo.Border.Class = "TextBoxBorder"
        Me.TxtCodigo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtCodigo.DisabledBackColor = System.Drawing.Color.White
        Me.TxtCodigo.FocusHighlightColor = System.Drawing.Color.PaleTurquoise
        Me.TxtCodigo.ForeColor = System.Drawing.Color.Black
        Me.TxtCodigo.Location = New System.Drawing.Point(51, 22)
        Me.TxtCodigo.Name = "TxtCodigo"
        Me.TxtCodigo.PreventEnterBeep = True
        Me.TxtCodigo.Size = New System.Drawing.Size(167, 22)
        Me.TxtCodigo.TabIndex = 23
        Me.TxtCodigo.WatermarkText = "Ingrese parte del código"
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.ForeColor = System.Drawing.Color.Black
        Me.LabelX1.Location = New System.Drawing.Point(10, 21)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(53, 23)
        Me.LabelX1.TabIndex = 24
        Me.LabelX1.Text = "Código"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.White
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(7, 79)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(137, 13)
        Me.Label1.TabIndex = 22
        Me.Label1.Text = "Descripción del producto"
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.Color.White
        Me.TextBox1.ForeColor = System.Drawing.Color.Black
        Me.TextBox1.Location = New System.Drawing.Point(10, 95)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(750, 22)
        Me.TextBox1.TabIndex = 3
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.White
        Me.GroupBox1.Controls.Add(Me.Grilla)
        Me.GroupBox1.ForeColor = System.Drawing.Color.Black
        Me.GroupBox1.Location = New System.Drawing.Point(8, 66)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(965, 378)
        Me.GroupBox1.TabIndex = 25
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Haga doble clic sobre la fila para seleccionar"
        '
        'Grilla
        '
        Me.Grilla.AllowUserToAddRows = False
        Me.Grilla.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.PeachPuff
        Me.Grilla.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.Grilla.BackgroundColor = System.Drawing.Color.White
        Me.Grilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Grilla.ContextMenuStrip = Me.MenuContextual
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Blue
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Yellow
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Grilla.DefaultCellStyle = DataGridViewCellStyle2
        Me.Grilla.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grilla.Location = New System.Drawing.Point(3, 18)
        Me.Grilla.Name = "Grilla"
        Me.Grilla.ReadOnly = True
        Me.Grilla.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.Grilla.Size = New System.Drawing.Size(959, 357)
        Me.Grilla.TabIndex = 1
        '
        'MenuContextual
        '
        Me.MenuContextual.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Mnu_VerEstadisticas, Me.VerAsocicaciónDelProductoToolStripMenuItem})
        Me.MenuContextual.Name = "ContextMenuStrip1"
        Me.MenuContextual.Size = New System.Drawing.Size(226, 48)
        '
        'Mnu_VerEstadisticas
        '
        Me.Mnu_VerEstadisticas.Image = Global.BkSpecialPrograms.My.Resources.Resources.graph_sales
        Me.Mnu_VerEstadisticas.Name = "Mnu_VerEstadisticas"
        Me.Mnu_VerEstadisticas.Size = New System.Drawing.Size(225, 22)
        Me.Mnu_VerEstadisticas.Text = "Ver estadísticas del producto"
        '
        'VerAsocicaciónDelProductoToolStripMenuItem
        '
        Me.VerAsocicaciónDelProductoToolStripMenuItem.Image = Global.BkSpecialPrograms.My.Resources.Resources.tree2
        Me.VerAsocicaciónDelProductoToolStripMenuItem.Name = "VerAsocicaciónDelProductoToolStripMenuItem"
        Me.VerAsocicaciónDelProductoToolStripMenuItem.Size = New System.Drawing.Size(225, 22)
        Me.VerAsocicaciónDelProductoToolStripMenuItem.Text = "Ver clasificaciones"
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.White
        Me.GroupBox3.Controls.Add(Me.TxtDescripcion_RD)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Controls.Add(Me.TextBox2)
        Me.GroupBox3.ForeColor = System.Drawing.Color.Black
        Me.GroupBox3.Location = New System.Drawing.Point(7, 450)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(966, 54)
        Me.GroupBox3.TabIndex = 29
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Descripción del producto en el sistema"
        '
        'TxtDescripcion_RD
        '
        Me.TxtDescripcion_RD.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TxtDescripcion_RD.Border.Class = "TextBoxBorder"
        Me.TxtDescripcion_RD.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtDescripcion_RD.DisabledBackColor = System.Drawing.Color.White
        Me.TxtDescripcion_RD.FocusHighlightColor = System.Drawing.Color.PaleTurquoise
        Me.TxtDescripcion_RD.ForeColor = System.Drawing.Color.Black
        Me.TxtDescripcion_RD.Location = New System.Drawing.Point(10, 21)
        Me.TxtDescripcion_RD.Name = "TxtDescripcion_RD"
        Me.TxtDescripcion_RD.PreventEnterBeep = True
        Me.TxtDescripcion_RD.Size = New System.Drawing.Size(945, 22)
        Me.TxtDescripcion_RD.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.White
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(7, 79)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(137, 13)
        Me.Label2.TabIndex = 22
        Me.Label2.Text = "Descripción del producto"
        '
        'TextBox2
        '
        Me.TextBox2.BackColor = System.Drawing.Color.White
        Me.TextBox2.ForeColor = System.Drawing.Color.Black
        Me.TextBox2.Location = New System.Drawing.Point(10, 95)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(750, 22)
        Me.TextBox2.TabIndex = 3
        '
        'Frm_BuscarXProducto_Mt_Listas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(980, 561)
        Me.ControlBox = False
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.Bar1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Frm_BuscarXProducto_Mt_Listas"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Listado de productos lista de costos"
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuContextual.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents BtnExportarExcel As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents BtnSalir As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Public WithEvents Txtdescripcion As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Grilla As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Public WithEvents TxtDescripcion_RD As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Public WithEvents TxtCodigo As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents MenuContextual As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents Mnu_VerEstadisticas As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents VerAsocicaciónDelProductoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BtnActualizarLista As DevComponents.DotNetBar.ButtonItem
End Class
