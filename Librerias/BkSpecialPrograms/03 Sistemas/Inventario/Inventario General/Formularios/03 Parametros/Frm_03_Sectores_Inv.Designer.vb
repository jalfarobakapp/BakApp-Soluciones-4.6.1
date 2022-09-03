<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_03_Sectores_Inv
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_03_Sectores_Inv))
        Me.GrupoDetalle = New System.Windows.Forms.GroupBox
        Me.Grilla_Inv = New DevComponents.DotNetBar.Controls.DataGridViewX
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.VerProductosContadosEnEsteSectorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AbrirCerrarSectorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AsignarUsuarioAlSectorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Txtdescripcion = New System.Windows.Forms.TextBox
        Me.Bar2 = New DevComponents.DotNetBar.Bar
        Me.BtnBuscarProductos = New DevComponents.DotNetBar.ButtonItem
        Me.LblUsuarioCargo = New System.Windows.Forms.Label
        Me.GrupoDetalle.SuspendLayout()
        CType(Me.Grilla_Inv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GrupoDetalle
        '
        Me.GrupoDetalle.BackColor = System.Drawing.Color.White
        Me.GrupoDetalle.Controls.Add(Me.Grilla_Inv)
        Me.GrupoDetalle.ForeColor = System.Drawing.Color.Black
        Me.GrupoDetalle.Location = New System.Drawing.Point(7, 87)
        Me.GrupoDetalle.Name = "GrupoDetalle"
        Me.GrupoDetalle.Size = New System.Drawing.Size(626, 260)
        Me.GrupoDetalle.TabIndex = 8
        Me.GrupoDetalle.TabStop = False
        Me.GrupoDetalle.Text = "Detalle del documento. Doble clic sobre la fila para seleccionar la ubicación"
        '
        'Grilla_Inv
        '
        Me.Grilla_Inv.AllowUserToAddRows = False
        Me.Grilla_Inv.AllowUserToDeleteRows = False
        Me.Grilla_Inv.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla_Inv.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.Grilla_Inv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Grilla_Inv.ContextMenuStrip = Me.ContextMenuStrip1
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Blue
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Grilla_Inv.DefaultCellStyle = DataGridViewCellStyle2
        Me.Grilla_Inv.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grilla_Inv.EnableHeadersVisualStyles = False
        Me.Grilla_Inv.GridColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.Grilla_Inv.Location = New System.Drawing.Point(3, 18)
        Me.Grilla_Inv.Name = "Grilla_Inv"
        Me.Grilla_Inv.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla_Inv.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.Grilla_Inv.Size = New System.Drawing.Size(620, 239)
        Me.Grilla_Inv.StandardTab = True
        Me.Grilla_Inv.TabIndex = 27
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.VerProductosContadosEnEsteSectorToolStripMenuItem, Me.AbrirCerrarSectorToolStripMenuItem, Me.AsignarUsuarioAlSectorToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(276, 70)
        '
        'VerProductosContadosEnEsteSectorToolStripMenuItem
        '
        Me.VerProductosContadosEnEsteSectorToolStripMenuItem.Name = "VerProductosContadosEnEsteSectorToolStripMenuItem"
        Me.VerProductosContadosEnEsteSectorToolStripMenuItem.Size = New System.Drawing.Size(275, 22)
        Me.VerProductosContadosEnEsteSectorToolStripMenuItem.Text = "Ver productos contados en este sector"
        '
        'AbrirCerrarSectorToolStripMenuItem
        '
        Me.AbrirCerrarSectorToolStripMenuItem.Name = "AbrirCerrarSectorToolStripMenuItem"
        Me.AbrirCerrarSectorToolStripMenuItem.Size = New System.Drawing.Size(275, 22)
        Me.AbrirCerrarSectorToolStripMenuItem.Text = "Abrir/Cerrar Sector"
        '
        'AsignarUsuarioAlSectorToolStripMenuItem
        '
        Me.AsignarUsuarioAlSectorToolStripMenuItem.Name = "AsignarUsuarioAlSectorToolStripMenuItem"
        Me.AsignarUsuarioAlSectorToolStripMenuItem.Size = New System.Drawing.Size(275, 22)
        Me.AsignarUsuarioAlSectorToolStripMenuItem.Text = "Asignar usuario al sector"
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.White
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.TextBox1)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Txtdescripcion)
        Me.GroupBox2.ForeColor = System.Drawing.Color.Black
        Me.GroupBox2.Location = New System.Drawing.Point(7, 2)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(626, 79)
        Me.GroupBox2.TabIndex = 22
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Busqueda"
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
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.White
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(7, 30)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(210, 13)
        Me.Label4.TabIndex = 15
        Me.Label4.Text = "Buscar ubicación, código, descripción..."
        '
        'Txtdescripcion
        '
        Me.Txtdescripcion.BackColor = System.Drawing.Color.White
        Me.Txtdescripcion.ForeColor = System.Drawing.Color.Black
        Me.Txtdescripcion.Location = New System.Drawing.Point(10, 46)
        Me.Txtdescripcion.Name = "Txtdescripcion"
        Me.Txtdescripcion.Size = New System.Drawing.Size(610, 22)
        Me.Txtdescripcion.TabIndex = 1
        '
        'Bar2
        '
        Me.Bar2.AntiAlias = True
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.BtnBuscarProductos})
        Me.Bar2.Location = New System.Drawing.Point(0, 395)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(638, 41)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Bar2.TabIndex = 45
        Me.Bar2.TabStop = False
        Me.Bar2.Text = "Bar2"
        '
        'BtnBuscarProductos
        '
        Me.BtnBuscarProductos.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnBuscarProductos.ForeColor = System.Drawing.Color.Black
        Me.BtnBuscarProductos.Image = CType(resources.GetObject("BtnBuscarProductos.Image"), System.Drawing.Image)
        Me.BtnBuscarProductos.Name = "BtnBuscarProductos"
        Me.BtnBuscarProductos.Text = "Buscar producto (Solo para información)"
        Me.BtnBuscarProductos.Tooltip = "Grabar"
        '
        'LblUsuarioCargo
        '
        Me.LblUsuarioCargo.AutoSize = True
        Me.LblUsuarioCargo.BackColor = System.Drawing.Color.White
        Me.LblUsuarioCargo.ForeColor = System.Drawing.Color.Black
        Me.LblUsuarioCargo.Location = New System.Drawing.Point(7, 359)
        Me.LblUsuarioCargo.Name = "LblUsuarioCargo"
        Me.LblUsuarioCargo.Size = New System.Drawing.Size(91, 13)
        Me.LblUsuarioCargo.TabIndex = 46
        Me.LblUsuarioCargo.Text = "Usuario a cargo:"
        '
        'Frm_03_Sectores_Inv
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(638, 436)
        Me.Controls.Add(Me.Bar2)
        Me.Controls.Add(Me.LblUsuarioCargo)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GrupoDetalle)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_03_Sectores_Inv"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Seleccion de sectores"
        Me.GrupoDetalle.ResumeLayout(False)
        CType(Me.Grilla_Inv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GrupoDetalle As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Txtdescripcion As System.Windows.Forms.TextBox
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents BtnBuscarProductos As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents VerProductosContadosEnEsteSectorToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AbrirCerrarSectorToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AsignarUsuarioAlSectorToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LblUsuarioCargo As System.Windows.Forms.Label
    Public WithEvents Grilla_Inv As DevComponents.DotNetBar.Controls.DataGridViewX
End Class
