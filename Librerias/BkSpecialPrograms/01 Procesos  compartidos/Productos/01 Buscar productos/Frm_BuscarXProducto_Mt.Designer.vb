<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_BuscarXProducto_Mt
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_BuscarXProducto_Mt))
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.Radio2 = New System.Windows.Forms.RadioButton
        Me.Radio1 = New System.Windows.Forms.RadioButton
        Me.Txtcodigo = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Txtdescripcion = New System.Windows.Forms.TextBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Grilla = New System.Windows.Forms.DataGridView
        Me.MenuContextual = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.Mnu_VerEstadisticas = New System.Windows.Forms.ToolStripMenuItem
        Me.VerAsocicaciónDelProductoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.Bar1 = New DevComponents.DotNetBar.Bar
        Me.BtnEditarProducto = New DevComponents.DotNetBar.ButtonItem
        Me.BtnExportaExcel = New DevComponents.DotNetBar.ButtonItem
        Me.BtnBuscarClasificacion = New DevComponents.DotNetBar.ButtonItem
        Me.BtnBusAlternativas = New DevComponents.DotNetBar.ButtonItem
        Me.BtnxSalir = New DevComponents.DotNetBar.ButtonItem
        Me.Highlighter1 = New DevComponents.DotNetBar.Validator.Highlighter
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuContextual.SuspendLayout()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.TextBox1)
        Me.GroupBox2.Controls.Add(Me.Radio2)
        Me.GroupBox2.Controls.Add(Me.Radio1)
        Me.GroupBox2.Controls.Add(Me.Txtcodigo)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Txtdescripcion)
        Me.GroupBox2.ForeColor = System.Drawing.Color.Black
        Me.GroupBox2.Location = New System.Drawing.Point(7, 4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(766, 79)
        Me.GroupBox2.TabIndex = 21
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Busqueda"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
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
        'Radio2
        '
        Me.Radio2.AutoSize = True
        Me.Radio2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Radio2.ForeColor = System.Drawing.Color.Black
        Me.Radio2.Location = New System.Drawing.Point(638, 21)
        Me.Radio2.Name = "Radio2"
        Me.Radio2.Size = New System.Drawing.Size(122, 17)
        Me.Radio2.TabIndex = 20
        Me.Radio2.TabStop = True
        Me.Radio2.Text = "Código Alternativo"
        Me.Radio2.UseVisualStyleBackColor = False
        Me.Radio2.Visible = False
        '
        'Radio1
        '
        Me.Radio1.AutoSize = True
        Me.Radio1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Radio1.Checked = True
        Me.Radio1.ForeColor = System.Drawing.Color.Black
        Me.Radio1.Location = New System.Drawing.Point(508, 21)
        Me.Radio1.Name = "Radio1"
        Me.Radio1.Size = New System.Drawing.Size(111, 17)
        Me.Radio1.TabIndex = 19
        Me.Radio1.TabStop = True
        Me.Radio1.Text = "Código principal"
        Me.Radio1.UseVisualStyleBackColor = False
        Me.Radio1.Visible = False
        '
        'Txtcodigo
        '
        Me.Txtcodigo.BackColor = System.Drawing.Color.White
        Me.Txtcodigo.ForeColor = System.Drawing.Color.Black
        Me.Highlighter1.SetHighlightOnFocus(Me.Txtcodigo, True)
        Me.Txtcodigo.Location = New System.Drawing.Point(201, 21)
        Me.Txtcodigo.Name = "Txtcodigo"
        Me.Txtcodigo.Size = New System.Drawing.Size(108, 22)
        Me.Txtcodigo.TabIndex = 0
        Me.Txtcodigo.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(7, 30)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(137, 13)
        Me.Label4.TabIndex = 15
        Me.Label4.Text = "Descripción del producto"
        '
        'Txtdescripcion
        '
        Me.Txtdescripcion.BackColor = System.Drawing.Color.White
        Me.Txtdescripcion.ForeColor = System.Drawing.Color.Black
        Me.Highlighter1.SetHighlightOnFocus(Me.Txtdescripcion, True)
        Me.Txtdescripcion.Location = New System.Drawing.Point(10, 46)
        Me.Txtdescripcion.Name = "Txtdescripcion"
        Me.Txtdescripcion.Size = New System.Drawing.Size(750, 22)
        Me.Txtdescripcion.TabIndex = 1
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GroupBox1.Controls.Add(Me.Grilla)
        Me.GroupBox1.ForeColor = System.Drawing.Color.Black
        Me.GroupBox1.Location = New System.Drawing.Point(7, 89)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(766, 351)
        Me.GroupBox1.TabIndex = 20
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Haga doble clic o presione Enter sobre la fila para seleccionar"
        '
        'Grilla
        '
        Me.Grilla.AllowUserToAddRows = False
        Me.Grilla.AllowUserToDeleteRows = False
        Me.Grilla.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.PeachPuff
        Me.Grilla.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.Grilla.BackgroundColor = System.Drawing.Color.White
        Me.Grilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Grilla.ContextMenuStrip = Me.MenuContextual
        Me.Grilla.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Highlighter1.SetHighlightOnFocus(Me.Grilla, True)
        Me.Grilla.Location = New System.Drawing.Point(3, 18)
        Me.Grilla.Name = "Grilla"
        Me.Grilla.ReadOnly = True
        Me.Grilla.RowHeadersVisible = False
        Me.Grilla.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Grilla.Size = New System.Drawing.Size(760, 330)
        Me.Grilla.TabIndex = 2
        Me.Grilla.TabStop = False
        '
        'MenuContextual
        '
        Me.MenuContextual.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Mnu_VerEstadisticas, Me.VerAsocicaciónDelProductoToolStripMenuItem})
        Me.MenuContextual.Name = "ContextMenuStrip1"
        Me.MenuContextual.Size = New System.Drawing.Size(225, 48)
        '
        'Mnu_VerEstadisticas
        '
        Me.Mnu_VerEstadisticas.Image = Global.BkSpecialPrograms.My.Resources.Resources.graph_sales
        Me.Mnu_VerEstadisticas.Name = "Mnu_VerEstadisticas"
        Me.Mnu_VerEstadisticas.Size = New System.Drawing.Size(224, 22)
        Me.Mnu_VerEstadisticas.Text = "Ver estadísticas del producto"
        '
        'VerAsocicaciónDelProductoToolStripMenuItem
        '
        Me.VerAsocicaciónDelProductoToolStripMenuItem.Image = Global.BkSpecialPrograms.My.Resources.Resources.tree2
        Me.VerAsocicaciónDelProductoToolStripMenuItem.Name = "VerAsocicaciónDelProductoToolStripMenuItem"
        Me.VerAsocicaciónDelProductoToolStripMenuItem.Size = New System.Drawing.Size(224, 22)
        Me.VerAsocicaciónDelProductoToolStripMenuItem.Text = "Ver clasificaciones"
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.BtnEditarProducto, Me.BtnExportaExcel, Me.BtnBuscarClasificacion, Me.BtnBusAlternativas, Me.BtnxSalir})
        Me.Bar1.Location = New System.Drawing.Point(0, 446)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(779, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 22
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'BtnEditarProducto
        '
        Me.BtnEditarProducto.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnEditarProducto.ForeColor = System.Drawing.Color.Black
        Me.BtnEditarProducto.Name = "BtnEditarProducto"
        Me.BtnEditarProducto.Tooltip = "Editar producto"
        Me.BtnEditarProducto.Visible = False
        '
        'BtnExportaExcel
        '
        Me.BtnExportaExcel.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnExportaExcel.ForeColor = System.Drawing.Color.Black
        Me.BtnExportaExcel.Image = CType(resources.GetObject("BtnExportaExcel.Image"), System.Drawing.Image)
        Me.BtnExportaExcel.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.BtnExportaExcel.Name = "BtnExportaExcel"
        Me.BtnExportaExcel.Tooltip = "Exportar a Excel"
        '
        'BtnBuscarClasificacion
        '
        Me.BtnBuscarClasificacion.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnBuscarClasificacion.ForeColor = System.Drawing.Color.Black
        Me.BtnBuscarClasificacion.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.BtnBuscarClasificacion.Name = "BtnBuscarClasificacion"
        Me.BtnBuscarClasificacion.Text = "Buscar por clasificación"
        Me.BtnBuscarClasificacion.Visible = False
        '
        'BtnBusAlternativas
        '
        Me.BtnBusAlternativas.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnBusAlternativas.ForeColor = System.Drawing.Color.Black
        Me.BtnBusAlternativas.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.BtnBusAlternativas.Name = "BtnBusAlternativas"
        Me.BtnBusAlternativas.Text = "Buscar código alternativo"
        Me.BtnBusAlternativas.Visible = False
        '
        'BtnxSalir
        '
        Me.BtnxSalir.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnxSalir.ForeColor = System.Drawing.Color.Black
        Me.BtnxSalir.Image = CType(resources.GetObject("BtnxSalir.Image"), System.Drawing.Image)
        Me.BtnxSalir.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.BtnxSalir.Name = "BtnxSalir"
        '
        'Highlighter1
        '
        Me.Highlighter1.ContainerControl = Me
        Me.Highlighter1.FocusHighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red
        Me.Highlighter1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        '
        'Frm_BuscarXProducto_Mt
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(779, 487)
        Me.ControlBox = False
        Me.Controls.Add(Me.Bar1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "Frm_BuscarXProducto_Mt"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Busqueda de productos"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuContextual.ResumeLayout(False)
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Txtcodigo As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Txtdescripcion As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Grilla As System.Windows.Forms.DataGridView
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents BtnExportaExcel As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents BtnxSalir As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Highlighter1 As DevComponents.DotNetBar.Validator.Highlighter
    Public WithEvents Radio2 As System.Windows.Forms.RadioButton
    Public WithEvents Radio1 As System.Windows.Forms.RadioButton
    Public WithEvents BtnBusAlternativas As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents MenuContextual As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents Mnu_VerEstadisticas As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents BtnEditarProducto As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents VerAsocicaciónDelProductoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents BtnBuscarClasificacion As DevComponents.DotNetBar.ButtonItem
End Class
