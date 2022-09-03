<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Meson_Reordenar_Productos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Meson_Reordenar_Productos))
        Me.GroupPanel2 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Grilla_Productos_En_Meson = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Grabar = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Subir_Producto = New DevComponents.DotNetBar.ButtonX()
        Me.Btn_Bajar_Producto = New DevComponents.DotNetBar.ButtonX()
        Me.Btn_Dehacer_los_cambios = New DevComponents.DotNetBar.ButtonX()
        Me.GroupPanel2.SuspendLayout()
        CType(Me.Grilla_Productos_En_Meson, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupPanel2
        '
        Me.GroupPanel2.BackColor = System.Drawing.Color.White
        Me.GroupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel2.Controls.Add(Me.Grilla_Productos_En_Meson)
        Me.GroupPanel2.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel2.Location = New System.Drawing.Point(6, 12)
        Me.GroupPanel2.Name = "GroupPanel2"
        Me.GroupPanel2.Size = New System.Drawing.Size(783, 451)
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
        Me.GroupPanel2.TabIndex = 110
        Me.GroupPanel2.Text = "Productos asignados al mesón"
        '
        'Grilla_Productos_En_Meson
        '
        Me.Grilla_Productos_En_Meson.AllowUserToAddRows = False
        Me.Grilla_Productos_En_Meson.AllowUserToDeleteRows = False
        Me.Grilla_Productos_En_Meson.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla_Productos_En_Meson.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.Grilla_Productos_En_Meson.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Grilla_Productos_En_Meson.DefaultCellStyle = DataGridViewCellStyle2
        Me.Grilla_Productos_En_Meson.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grilla_Productos_En_Meson.EnableHeadersVisualStyles = False
        Me.Grilla_Productos_En_Meson.GridColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.Grilla_Productos_En_Meson.Location = New System.Drawing.Point(0, 0)
        Me.Grilla_Productos_En_Meson.MultiSelect = False
        Me.Grilla_Productos_En_Meson.Name = "Grilla_Productos_En_Meson"
        Me.Grilla_Productos_En_Meson.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla_Productos_En_Meson.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.Grilla_Productos_En_Meson.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.Grilla_Productos_En_Meson.Size = New System.Drawing.Size(777, 428)
        Me.Grilla_Productos_En_Meson.TabIndex = 1
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Grabar})
        Me.Bar1.Location = New System.Drawing.Point(0, 506)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(795, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 112
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'Btn_Grabar
        '
        Me.Btn_Grabar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Grabar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Grabar.Image = CType(resources.GetObject("Btn_Grabar.Image"), System.Drawing.Image)
        Me.Btn_Grabar.ImageAlt = CType(resources.GetObject("Btn_Grabar.ImageAlt"), System.Drawing.Image)
        Me.Btn_Grabar.Name = "Btn_Grabar"
        Me.Btn_Grabar.Tooltip = "Grabar cambios"
        '
        'Btn_Subir_Producto
        '
        Me.Btn_Subir_Producto.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Subir_Producto.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Subir_Producto.Enabled = False
        Me.Btn_Subir_Producto.Image = CType(resources.GetObject("Btn_Subir_Producto.Image"), System.Drawing.Image)
        Me.Btn_Subir_Producto.ImageAlt = CType(resources.GetObject("Btn_Subir_Producto.ImageAlt"), System.Drawing.Image)
        Me.Btn_Subir_Producto.Location = New System.Drawing.Point(6, 469)
        Me.Btn_Subir_Producto.Name = "Btn_Subir_Producto"
        Me.Btn_Subir_Producto.Size = New System.Drawing.Size(83, 28)
        Me.Btn_Subir_Producto.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Subir_Producto.TabIndex = 108
        Me.Btn_Subir_Producto.Text = "Subir fila"
        '
        'Btn_Bajar_Producto
        '
        Me.Btn_Bajar_Producto.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Bajar_Producto.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Bajar_Producto.Enabled = False
        Me.Btn_Bajar_Producto.Image = CType(resources.GetObject("Btn_Bajar_Producto.Image"), System.Drawing.Image)
        Me.Btn_Bajar_Producto.ImageAlt = CType(resources.GetObject("Btn_Bajar_Producto.ImageAlt"), System.Drawing.Image)
        Me.Btn_Bajar_Producto.Location = New System.Drawing.Point(95, 469)
        Me.Btn_Bajar_Producto.Name = "Btn_Bajar_Producto"
        Me.Btn_Bajar_Producto.Size = New System.Drawing.Size(83, 28)
        Me.Btn_Bajar_Producto.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Bajar_Producto.TabIndex = 109
        Me.Btn_Bajar_Producto.Text = "Bajar fila"
        '
        'Btn_Dehacer_los_cambios
        '
        Me.Btn_Dehacer_los_cambios.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Dehacer_los_cambios.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Dehacer_los_cambios.Enabled = False
        Me.Btn_Dehacer_los_cambios.Image = CType(resources.GetObject("Btn_Dehacer_los_cambios.Image"), System.Drawing.Image)
        Me.Btn_Dehacer_los_cambios.Location = New System.Drawing.Point(222, 469)
        Me.Btn_Dehacer_los_cambios.Name = "Btn_Dehacer_los_cambios"
        Me.Btn_Dehacer_los_cambios.Size = New System.Drawing.Size(146, 28)
        Me.Btn_Dehacer_los_cambios.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Dehacer_los_cambios.TabIndex = 113
        Me.Btn_Dehacer_los_cambios.Text = "Deshacer los cambios"
        '
        'Frm_Meson_Reordenar_Productos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(795, 547)
        Me.Controls.Add(Me.Btn_Dehacer_los_cambios)
        Me.Controls.Add(Me.Btn_Bajar_Producto)
        Me.Controls.Add(Me.Bar1)
        Me.Controls.Add(Me.Btn_Subir_Producto)
        Me.Controls.Add(Me.GroupPanel2)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Meson_Reordenar_Productos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "REORDENAMIENTO DE PRODUCTOS EN MESON DE TRABAJO MESON: XXXXXXXXXXXXXXXXX"
        Me.GroupPanel2.ResumeLayout(False)
        CType(Me.Grilla_Productos_En_Meson, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupPanel2 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Grilla_Productos_En_Meson As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Public WithEvents Btn_Grabar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Subir_Producto As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Btn_Bajar_Producto As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Btn_Dehacer_los_cambios As DevComponents.DotNetBar.ButtonX
End Class
