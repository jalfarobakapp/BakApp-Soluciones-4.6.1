<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_EntExcluidas
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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_EntExcluidas))
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.BtnGrabar = New DevComponents.DotNetBar.ButtonItem()
        Me.BtnBuscarEntidad = New DevComponents.DotNetBar.ButtonItem()
        Me.BtnExportarExcel = New DevComponents.DotNetBar.ButtonItem()
        Me.MenuContextual = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.IncorporarEntidadToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Mnucontex_COMRA = New System.Windows.Forms.ToolStripMenuItem()
        Me.Mnucontex_VENTA = New System.Windows.Forms.ToolStripMenuItem()
        Me.Mnucontex_AMBAS = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.DespachoMercaderiaPendienteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TodoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.QuitarEntidadToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Rd_Compra = New DevComponents.DotNetBar.Command(Me.components)
        Me.Rd_Venta = New DevComponents.DotNetBar.Command(Me.components)
        Me.Rd_Ambas = New DevComponents.DotNetBar.Command(Me.components)
        Me.Rd_Despacho = New DevComponents.DotNetBar.Command(Me.components)
        Me.Rd_Todo = New DevComponents.DotNetBar.Command(Me.components)
        Me.Grilla = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuContextual.SuspendLayout()
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.BtnGrabar, Me.BtnBuscarEntidad, Me.BtnExportarExcel})
        Me.Bar1.Location = New System.Drawing.Point(0, 308)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(547, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 10
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'BtnGrabar
        '
        Me.BtnGrabar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnGrabar.ForeColor = System.Drawing.Color.Black
        Me.BtnGrabar.Image = Global.BkSpecialPrograms.My.Resources.Resources.save
        Me.BtnGrabar.Name = "BtnGrabar"
        '
        'BtnBuscarEntidad
        '
        Me.BtnBuscarEntidad.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnBuscarEntidad.ForeColor = System.Drawing.Color.Black
        Me.BtnBuscarEntidad.Image = Global.BkSpecialPrograms.My.Resources.Resources.table_customer_add
        Me.BtnBuscarEntidad.Name = "BtnBuscarEntidad"
        Me.BtnBuscarEntidad.Text = "Traer entidad"
        '
        'BtnExportarExcel
        '
        Me.BtnExportarExcel.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnExportarExcel.ForeColor = System.Drawing.Color.Black
        Me.BtnExportarExcel.Image = Global.BkSpecialPrograms.My.Resources.Resources.export_to_excel
        Me.BtnExportarExcel.Name = "BtnExportarExcel"
        Me.BtnExportarExcel.Tooltip = "Exportar a Excel"
        '
        'MenuContextual
        '
        Me.MenuContextual.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.IncorporarEntidadToolStripMenuItem, Me.ToolStripSeparator1, Me.QuitarEntidadToolStripMenuItem})
        Me.MenuContextual.Name = "MenuContextual_Venta"
        Me.MenuContextual.Size = New System.Drawing.Size(201, 54)
        '
        'IncorporarEntidadToolStripMenuItem
        '
        Me.IncorporarEntidadToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Mnucontex_COMRA, Me.Mnucontex_VENTA, Me.Mnucontex_AMBAS, Me.ToolStripSeparator2, Me.DespachoMercaderiaPendienteToolStripMenuItem, Me.TodoToolStripMenuItem})
        Me.IncorporarEntidadToolStripMenuItem.Image = Global.BkSpecialPrograms.My.Resources.Resources.customer_remove
        Me.IncorporarEntidadToolStripMenuItem.Name = "IncorporarEntidadToolStripMenuItem"
        Me.IncorporarEntidadToolStripMenuItem.Size = New System.Drawing.Size(200, 22)
        Me.IncorporarEntidadToolStripMenuItem.Text = "Excluir en informes de..."
        '
        'Mnucontex_COMRA
        '
        Me.Mnucontex_COMRA.Name = "Mnucontex_COMRA"
        Me.Mnucontex_COMRA.Size = New System.Drawing.Size(252, 22)
        Me.Mnucontex_COMRA.Text = "Informes de Compra"
        '
        'Mnucontex_VENTA
        '
        Me.Mnucontex_VENTA.Name = "Mnucontex_VENTA"
        Me.Mnucontex_VENTA.Size = New System.Drawing.Size(252, 22)
        Me.Mnucontex_VENTA.Text = "Informes de Venta"
        '
        'Mnucontex_AMBAS
        '
        Me.Mnucontex_AMBAS.Name = "Mnucontex_AMBAS"
        Me.Mnucontex_AMBAS.Size = New System.Drawing.Size(252, 22)
        Me.Mnucontex_AMBAS.Text = "Ambos informes"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(249, 6)
        '
        'DespachoMercaderiaPendienteToolStripMenuItem
        '
        Me.DespachoMercaderiaPendienteToolStripMenuItem.Name = "DespachoMercaderiaPendienteToolStripMenuItem"
        Me.DespachoMercaderiaPendienteToolStripMenuItem.Size = New System.Drawing.Size(252, 22)
        Me.DespachoMercaderiaPendienteToolStripMenuItem.Text = "Despacho (Mercadería pendiente)"
        '
        'TodoToolStripMenuItem
        '
        Me.TodoToolStripMenuItem.Name = "TodoToolStripMenuItem"
        Me.TodoToolStripMenuItem.Size = New System.Drawing.Size(252, 22)
        Me.TodoToolStripMenuItem.Text = "Todo"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(197, 6)
        '
        'QuitarEntidadToolStripMenuItem
        '
        Me.QuitarEntidadToolStripMenuItem.Image = Global.BkSpecialPrograms.My.Resources.Resources.delete3
        Me.QuitarEntidadToolStripMenuItem.Name = "QuitarEntidadToolStripMenuItem"
        Me.QuitarEntidadToolStripMenuItem.Size = New System.Drawing.Size(200, 22)
        Me.QuitarEntidadToolStripMenuItem.Text = "Quitar entidad"
        '
        'Rd_Compra
        '
        Me.Rd_Compra.Checked = False
        Me.Rd_Compra.Name = "Rd_Compra"
        Me.Rd_Compra.Text = "Informes de compra"
        '
        'Rd_Venta
        '
        Me.Rd_Venta.Name = "Rd_Venta"
        Me.Rd_Venta.Text = "Informes de venta"
        '
        'Rd_Ambas
        '
        Me.Rd_Ambas.Name = "Rd_Ambas"
        Me.Rd_Ambas.Text = "Ambos informes (compra y venta)"
        '
        'Rd_Despacho
        '
        Me.Rd_Despacho.Name = "Rd_Despacho"
        Me.Rd_Despacho.Text = "Despacho (Mercadería pendiente)"
        '
        'Rd_Todo
        '
        Me.Rd_Todo.Name = "Rd_Todo"
        Me.Rd_Todo.Text = "Todo"
        '
        'Grilla
        '
        Me.Grilla.AllowUserToAddRows = False
        Me.Grilla.AllowUserToDeleteRows = False
        Me.Grilla.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.Grilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Grilla.ContextMenuStrip = Me.MenuContextual
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
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
        Me.Grilla.Name = "Grilla"
        Me.Grilla.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.Grilla.Size = New System.Drawing.Size(518, 267)
        Me.Grilla.StandardTab = True
        Me.Grilla.TabIndex = 67
        '
        'GroupPanel1
        '
        Me.GroupPanel1.BackColor = System.Drawing.Color.White
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.Grilla)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Location = New System.Drawing.Point(11, 12)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(524, 290)
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
        Me.GroupPanel1.TabIndex = 68
        Me.GroupPanel1.Text = "Entidades"
        '
        'Frm_EntExcluidas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(547, 349)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Controls.Add(Me.Bar1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_EntExcluidas"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Entidades excluidas"
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuContextual.ResumeLayout(False)
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents BtnGrabar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents MenuContextual As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents IncorporarEntidadToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents QuitarEntidadToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Mnucontex_COMRA As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Mnucontex_VENTA As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Mnucontex_AMBAS As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BtnBuscarEntidad As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents BtnExportarExcel As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Rd_Compra As DevComponents.DotNetBar.Command
    Friend WithEvents Rd_Venta As DevComponents.DotNetBar.Command
    Friend WithEvents Rd_Ambas As DevComponents.DotNetBar.Command
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents DespachoMercaderiaPendienteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TodoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Rd_Despacho As DevComponents.DotNetBar.Command
    Friend WithEvents Rd_Todo As DevComponents.DotNetBar.Command
    Friend WithEvents Grilla As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
End Class
