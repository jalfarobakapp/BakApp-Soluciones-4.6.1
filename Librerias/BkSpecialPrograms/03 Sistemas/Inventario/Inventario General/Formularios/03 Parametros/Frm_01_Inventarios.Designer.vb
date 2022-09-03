<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_01_Inventarios
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_01_Inventarios))
        Me.Bar1 = New DevComponents.DotNetBar.Bar
        Me.BtnLimpiarCodigo = New DevComponents.DotNetBar.ButtonItem
        Me.BtnCrearNuevoInventario = New DevComponents.DotNetBar.ButtonItem
        Me.BtnxSalir = New DevComponents.DotNetBar.ButtonItem
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Grilla = New System.Windows.Forms.DataGridView
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.CrearNuevoInventarioToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.EliminarFilaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DtpFechaFl = New System.Windows.Forms.DateTimePicker
        Me.ChkFiltroFecha = New System.Windows.Forms.CheckBox
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.BtnLimpiarCodigo, Me.BtnCrearNuevoInventario, Me.BtnxSalir})
        Me.Bar1.Location = New System.Drawing.Point(0, 397)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(573, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 22
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'BtnLimpiarCodigo
        '
        Me.BtnLimpiarCodigo.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnLimpiarCodigo.ForeColor = System.Drawing.Color.Black
        Me.BtnLimpiarCodigo.Image = Global.BkSpecialPrograms.My.Resources.Resources.export_to_excel
        Me.BtnLimpiarCodigo.Name = "BtnLimpiarCodigo"
        Me.BtnLimpiarCodigo.Tooltip = "Exportar a Excel"
        '
        'BtnCrearNuevoInventario
        '
        Me.BtnCrearNuevoInventario.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnCrearNuevoInventario.ForeColor = System.Drawing.Color.Black
        Me.BtnCrearNuevoInventario.Name = "BtnCrearNuevoInventario"
        Me.BtnCrearNuevoInventario.Tooltip = "Crear nuevo inventario"
        '
        'BtnxSalir
        '
        Me.BtnxSalir.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnxSalir.ForeColor = System.Drawing.Color.Black
        Me.BtnxSalir.Image = Global.BkSpecialPrograms.My.Resources.Resources.button_rounded_red_delete
        Me.BtnxSalir.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.BtnxSalir.Name = "BtnxSalir"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GroupBox1.Controls.Add(Me.Grilla)
        Me.GroupBox1.ForeColor = System.Drawing.Color.Black
        Me.GroupBox1.Location = New System.Drawing.Point(0, 49)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(568, 324)
        Me.GroupBox1.TabIndex = 21
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Fechas de inventarios"
        '
        'Grilla
        '
        Me.Grilla.AllowUserToAddRows = False
        Me.Grilla.AllowUserToDeleteRows = False
        Me.Grilla.BackgroundColor = System.Drawing.Color.White
        Me.Grilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Grilla.ContextMenuStrip = Me.ContextMenuStrip1
        Me.Grilla.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grilla.Location = New System.Drawing.Point(3, 18)
        Me.Grilla.Name = "Grilla"
        Me.Grilla.ReadOnly = True
        Me.Grilla.Size = New System.Drawing.Size(562, 303)
        Me.Grilla.TabIndex = 0
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CrearNuevoInventarioToolStripMenuItem, Me.EditarToolStripMenuItem, Me.ToolStripSeparator1, Me.EliminarFilaToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(195, 76)
        '
        'CrearNuevoInventarioToolStripMenuItem
        '
        Me.CrearNuevoInventarioToolStripMenuItem.Name = "CrearNuevoInventarioToolStripMenuItem"
        Me.CrearNuevoInventarioToolStripMenuItem.Size = New System.Drawing.Size(194, 22)
        Me.CrearNuevoInventarioToolStripMenuItem.Text = "Crear nuevo inventario"
        '
        'EditarToolStripMenuItem
        '
        Me.EditarToolStripMenuItem.Name = "EditarToolStripMenuItem"
        Me.EditarToolStripMenuItem.Size = New System.Drawing.Size(194, 22)
        Me.EditarToolStripMenuItem.Text = "Editar Inventario"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(191, 6)
        '
        'EliminarFilaToolStripMenuItem
        '
        Me.EliminarFilaToolStripMenuItem.Image = Global.BkSpecialPrograms.My.Resources.Resources.delete2
        Me.EliminarFilaToolStripMenuItem.Name = "EliminarFilaToolStripMenuItem"
        Me.EliminarFilaToolStripMenuItem.Size = New System.Drawing.Size(194, 22)
        Me.EliminarFilaToolStripMenuItem.Text = "Eliminar fila"
        '
        'DtpFechaFl
        '
        Me.DtpFechaFl.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.DtpFechaFl.ForeColor = System.Drawing.Color.Black
        Me.DtpFechaFl.Location = New System.Drawing.Point(3, 12)
        Me.DtpFechaFl.Name = "DtpFechaFl"
        Me.DtpFechaFl.Size = New System.Drawing.Size(255, 22)
        Me.DtpFechaFl.TabIndex = 23
        '
        'ChkFiltroFecha
        '
        Me.ChkFiltroFecha.AutoSize = True
        Me.ChkFiltroFecha.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ChkFiltroFecha.ForeColor = System.Drawing.Color.Black
        Me.ChkFiltroFecha.Location = New System.Drawing.Point(264, 18)
        Me.ChkFiltroFecha.Name = "ChkFiltroFecha"
        Me.ChkFiltroFecha.Size = New System.Drawing.Size(108, 17)
        Me.ChkFiltroFecha.TabIndex = 24
        Me.ChkFiltroFecha.Text = "Filtrar por fecha"
        Me.ChkFiltroFecha.UseVisualStyleBackColor = False
        '
        'Frm_01_Inventarios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(573, 438)
        Me.ControlBox = False
        Me.Controls.Add(Me.DtpFechaFl)
        Me.Controls.Add(Me.Bar1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ChkFiltroFecha)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Frm_01_Inventarios"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Inventarios generales del sistema"
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents BtnLimpiarCodigo As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents BtnCrearNuevoInventario As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents BtnxSalir As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Grilla As System.Windows.Forms.DataGridView
    Friend WithEvents DtpFechaFl As System.Windows.Forms.DateTimePicker
    Friend WithEvents ChkFiltroFecha As System.Windows.Forms.CheckBox
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents CrearNuevoInventarioToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents EliminarFilaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
