<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_01_Inventario_Actual
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_01_Inventario_Actual))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.Bar2 = New DevComponents.DotNetBar.Bar
        Me.BtnActualizar = New DevComponents.DotNetBar.ButtonItem
        Me.BtnExcel = New DevComponents.DotNetBar.ButtonItem
        Me.BtnBuscarProducto = New DevComponents.DotNetBar.ButtonItem
        Me.BtnCerrar = New DevComponents.DotNetBar.ButtonItem
        Me.BtnCerrarSinDiferencias = New DevComponents.DotNetBar.ButtonItem
        Me.BtnCerrarInventariados = New DevComponents.DotNetBar.ButtonItem
        Me.BtnCerrarTodosInvCero = New DevComponents.DotNetBar.ButtonItem
        Me.BtnLevantados = New DevComponents.DotNetBar.ButtonItem
        Me.ButtonItem1 = New DevComponents.DotNetBar.ButtonItem
        Me.BtnExporAjuTodos = New DevComponents.DotNetBar.ButtonItem
        Me.BtnExporAjuCerrados = New DevComponents.DotNetBar.ButtonItem
        Me.BtnSalir = New DevComponents.DotNetBar.ButtonItem
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Grilla = New System.Windows.Forms.DataGridView
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.DetalleDelCToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.UltimodMovimientosCompraYVentasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.GroupBox7 = New System.Windows.Forms.GroupBox
        Me.LblTotal_Diferencia = New DevComponents.DotNetBar.LabelX
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.LblTotal_Inventario = New DevComponents.DotNetBar.LabelX
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.LblTotal_FotoStock = New DevComponents.DotNetBar.LabelX
        Me.Bar1 = New DevComponents.DotNetBar.Bar
        Me.BtnFiltroSectores = New DevComponents.DotNetBar.ButtonItem
        Me.ChkTodosLosSectores = New DevComponents.DotNetBar.CheckBoxItem
        Me.ChkMostrarSoloInv = New DevComponents.DotNetBar.CheckBoxItem
        Me.ButtonItem2 = New DevComponents.DotNetBar.ButtonItem
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Bar2
        '
        Me.Bar2.AntiAlias = True
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.BtnActualizar, Me.BtnExcel, Me.BtnBuscarProducto, Me.BtnCerrar, Me.ButtonItem1, Me.BtnSalir})
        Me.Bar2.Location = New System.Drawing.Point(0, 472)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(1001, 41)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Bar2.TabIndex = 30
        Me.Bar2.TabStop = False
        Me.Bar2.Text = "Bar2"
        '
        'BtnActualizar
        '
        Me.BtnActualizar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnActualizar.ForeColor = System.Drawing.Color.Black
        Me.BtnActualizar.Image = CType(resources.GetObject("BtnActualizar.Image"), System.Drawing.Image)
        Me.BtnActualizar.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.BtnActualizar.Name = "BtnActualizar"
        '
        'BtnExcel
        '
        Me.BtnExcel.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnExcel.ForeColor = System.Drawing.Color.Black
        Me.BtnExcel.Image = CType(resources.GetObject("BtnExcel.Image"), System.Drawing.Image)
        Me.BtnExcel.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.BtnExcel.Name = "BtnExcel"
        '
        'BtnBuscarProducto
        '
        Me.BtnBuscarProducto.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnBuscarProducto.ForeColor = System.Drawing.Color.Black
        Me.BtnBuscarProducto.Image = CType(resources.GetObject("BtnBuscarProducto.Image"), System.Drawing.Image)
        Me.BtnBuscarProducto.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.BtnBuscarProducto.Name = "BtnBuscarProducto"
        '
        'BtnCerrar
        '
        Me.BtnCerrar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnCerrar.ForeColor = System.Drawing.Color.Black
        Me.BtnCerrar.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.BtnCerrar.Name = "BtnCerrar"
        Me.BtnCerrar.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.BtnCerrarSinDiferencias, Me.BtnCerrarInventariados, Me.BtnCerrarTodosInvCero, Me.BtnLevantados})
        '
        'BtnCerrarSinDiferencias
        '
        Me.BtnCerrarSinDiferencias.Name = "BtnCerrarSinDiferencias"
        Me.BtnCerrarSinDiferencias.Text = "Cerrar todos los productos sin diferencia de inventario"
        '
        'BtnCerrarInventariados
        '
        Me.BtnCerrarInventariados.Name = "BtnCerrarInventariados"
        Me.BtnCerrarInventariados.Text = "Cerrar todos los productos con cantidad inventariada mayor a cero"
        '
        'BtnCerrarTodosInvCero
        '
        Me.BtnCerrarTodosInvCero.Name = "BtnCerrarTodosInvCero"
        Me.BtnCerrarTodosInvCero.Text = "Cerrar todos los con cantidad igual a cero"
        '
        'BtnLevantados
        '
        Me.BtnLevantados.Name = "BtnLevantados"
        Me.BtnLevantados.Text = "Marcar como levantados todos los productos cerrados"
        '
        'ButtonItem1
        '
        Me.ButtonItem1.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem1.ForeColor = System.Drawing.Color.Black
        Me.ButtonItem1.Image = CType(resources.GetObject("ButtonItem1.Image"), System.Drawing.Image)
        Me.ButtonItem1.Name = "ButtonItem1"
        Me.ButtonItem1.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.BtnExporAjuTodos, Me.BtnExporAjuCerrados})
        Me.ButtonItem1.Text = "Expotar archivo apara ajuste"
        '
        'BtnExporAjuTodos
        '
        Me.BtnExporAjuTodos.Name = "BtnExporAjuTodos"
        Me.BtnExporAjuTodos.Text = "Exportar todo"
        '
        'BtnExporAjuCerrados
        '
        Me.BtnExporAjuCerrados.Name = "BtnExporAjuCerrados"
        Me.BtnExporAjuCerrados.Text = "Exportar solo cerrados"
        '
        'BtnSalir
        '
        Me.BtnSalir.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnSalir.ForeColor = System.Drawing.Color.Black
        Me.BtnSalir.Image = CType(resources.GetObject("BtnSalir.Image"), System.Drawing.Image)
        Me.BtnSalir.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.BtnSalir.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.BtnSalir.Name = "BtnSalir"
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.White
        Me.GroupBox2.Controls.Add(Me.Grilla)
        Me.GroupBox2.ForeColor = System.Drawing.Color.Black
        Me.GroupBox2.Location = New System.Drawing.Point(12, 47)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(977, 341)
        Me.GroupBox2.TabIndex = 31
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Detalle de inventario"
        '
        'Grilla
        '
        Me.Grilla.AllowUserToAddRows = False
        Me.Grilla.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Grilla.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.Grilla.BackgroundColor = System.Drawing.Color.White
        Me.Grilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Grilla.ContextMenuStrip = Me.ContextMenuStrip1
        Me.Grilla.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grilla.Location = New System.Drawing.Point(3, 18)
        Me.Grilla.Name = "Grilla"
        Me.Grilla.ReadOnly = True
        Me.Grilla.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.Grilla.Size = New System.Drawing.Size(971, 320)
        Me.Grilla.TabIndex = 0
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DetalleDelCToolStripMenuItem, Me.UltimodMovimientosCompraYVentasToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(292, 48)
        '
        'DetalleDelCToolStripMenuItem
        '
        Me.DetalleDelCToolStripMenuItem.Name = "DetalleDelCToolStripMenuItem"
        Me.DetalleDelCToolStripMenuItem.Size = New System.Drawing.Size(291, 22)
        Me.DetalleDelCToolStripMenuItem.Text = "Detalle del inventario del producto activo"
        '
        'UltimodMovimientosCompraYVentasToolStripMenuItem
        '
        Me.UltimodMovimientosCompraYVentasToolStripMenuItem.Name = "UltimodMovimientosCompraYVentasToolStripMenuItem"
        Me.UltimodMovimientosCompraYVentasToolStripMenuItem.Size = New System.Drawing.Size(291, 22)
        Me.UltimodMovimientosCompraYVentasToolStripMenuItem.Text = "Ver estadísticas del producto"
        '
        'GroupBox7
        '
        Me.GroupBox7.BackColor = System.Drawing.Color.White
        Me.GroupBox7.Controls.Add(Me.LblTotal_Diferencia)
        Me.GroupBox7.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold)
        Me.GroupBox7.ForeColor = System.Drawing.Color.Black
        Me.GroupBox7.Location = New System.Drawing.Point(829, 394)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(160, 59)
        Me.GroupBox7.TabIndex = 42
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "Diferencia"
        '
        'LblTotal_Diferencia
        '
        Me.LblTotal_Diferencia.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LblTotal_Diferencia.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LblTotal_Diferencia.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotal_Diferencia.ForeColor = System.Drawing.Color.Black
        Me.LblTotal_Diferencia.Location = New System.Drawing.Point(6, 30)
        Me.LblTotal_Diferencia.Name = "LblTotal_Diferencia"
        Me.LblTotal_Diferencia.Size = New System.Drawing.Size(148, 23)
        Me.LblTotal_Diferencia.TabIndex = 34
        Me.LblTotal_Diferencia.Text = "0"
        Me.LblTotal_Diferencia.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.White
        Me.GroupBox1.Controls.Add(Me.LblTotal_Inventario)
        Me.GroupBox1.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold)
        Me.GroupBox1.ForeColor = System.Drawing.Color.Black
        Me.GroupBox1.Location = New System.Drawing.Point(654, 394)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(160, 59)
        Me.GroupBox1.TabIndex = 43
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Inventario"
        '
        'LblTotal_Inventario
        '
        Me.LblTotal_Inventario.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LblTotal_Inventario.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LblTotal_Inventario.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotal_Inventario.ForeColor = System.Drawing.Color.Black
        Me.LblTotal_Inventario.Location = New System.Drawing.Point(6, 30)
        Me.LblTotal_Inventario.Name = "LblTotal_Inventario"
        Me.LblTotal_Inventario.Size = New System.Drawing.Size(148, 23)
        Me.LblTotal_Inventario.TabIndex = 34
        Me.LblTotal_Inventario.Text = "0"
        Me.LblTotal_Inventario.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.White
        Me.GroupBox3.Controls.Add(Me.LblTotal_FotoStock)
        Me.GroupBox3.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold)
        Me.GroupBox3.ForeColor = System.Drawing.Color.Black
        Me.GroupBox3.Location = New System.Drawing.Point(480, 394)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(159, 59)
        Me.GroupBox3.TabIndex = 44
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Foto Stock"
        '
        'LblTotal_FotoStock
        '
        Me.LblTotal_FotoStock.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LblTotal_FotoStock.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LblTotal_FotoStock.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotal_FotoStock.ForeColor = System.Drawing.Color.Black
        Me.LblTotal_FotoStock.Location = New System.Drawing.Point(6, 26)
        Me.LblTotal_FotoStock.Name = "LblTotal_FotoStock"
        Me.LblTotal_FotoStock.Size = New System.Drawing.Size(147, 23)
        Me.LblTotal_FotoStock.TabIndex = 34
        Me.LblTotal_FotoStock.Text = "0"
        Me.LblTotal_FotoStock.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.BtnFiltroSectores, Me.ChkTodosLosSectores, Me.ChkMostrarSoloInv, Me.ButtonItem2})
        Me.Bar1.Location = New System.Drawing.Point(0, 0)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(1001, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 45
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'BtnFiltroSectores
        '
        Me.BtnFiltroSectores.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnFiltroSectores.Enabled = False
        Me.BtnFiltroSectores.Image = CType(resources.GetObject("BtnFiltroSectores.Image"), System.Drawing.Image)
        Me.BtnFiltroSectores.Name = "BtnFiltroSectores"
        Me.BtnFiltroSectores.Text = "Filtrar por sector tomado"
        '
        'ChkTodosLosSectores
        '
        Me.ChkTodosLosSectores.Checked = True
        Me.ChkTodosLosSectores.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkTodosLosSectores.Name = "ChkTodosLosSectores"
        Me.ChkTodosLosSectores.Text = "Mostrar todos los sectores"
        '
        'ChkMostrarSoloInv
        '
        Me.ChkMostrarSoloInv.Name = "ChkMostrarSoloInv"
        Me.ChkMostrarSoloInv.Text = "Mostrar solo productos inventariados"
        '
        'ButtonItem2
        '
        Me.ButtonItem2.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem2.Image = CType(resources.GetObject("ButtonItem2.Image"), System.Drawing.Image)
        Me.ButtonItem2.Name = "ButtonItem2"
        Me.ButtonItem2.Text = "Ver inf. por Familias"
        '
        'Frm_01_Inventario_Actual
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1001, 513)
        Me.ControlBox = False
        Me.Controls.Add(Me.Bar1)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox7)
        Me.Controls.Add(Me.Bar2)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Frm_01_Inventario_Actual"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Inventario Actual"
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents BtnActualizar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents BtnSalir As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Grilla As System.Windows.Forms.DataGridView
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents DetalleDelCToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UltimodMovimientosCompraYVentasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents LblTotal_Diferencia As DevComponents.DotNetBar.LabelX
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents LblTotal_Inventario As DevComponents.DotNetBar.LabelX
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents LblTotal_FotoStock As DevComponents.DotNetBar.LabelX
    Friend WithEvents BtnExcel As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents BtnBuscarProducto As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents BtnCerrar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents BtnCerrarSinDiferencias As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents BtnLevantados As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents BtnCerrarInventariados As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem1 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents BtnCerrarTodosInvCero As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents BtnExporAjuTodos As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents BtnExporAjuCerrados As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents BtnFiltroSectores As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ChkTodosLosSectores As DevComponents.DotNetBar.CheckBoxItem
    Friend WithEvents ButtonItem2 As DevComponents.DotNetBar.ButtonItem
    Public WithEvents ChkMostrarSoloInv As DevComponents.DotNetBar.CheckBoxItem
End Class
