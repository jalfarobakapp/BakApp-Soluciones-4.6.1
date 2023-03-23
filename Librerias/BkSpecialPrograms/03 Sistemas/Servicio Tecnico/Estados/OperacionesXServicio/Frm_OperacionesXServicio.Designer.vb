<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_OperacionesXServicio
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_OperacionesXServicio))
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Grupo_Presupuesto = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Txt_Receta = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.Grupo_Grilla = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.ContextMenuBar1 = New DevComponents.DotNetBar.ContextMenuBar()
        Me.Menu_Contextual_01 = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Mnu_AgregaOperacionMismaReceta = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Mnu_AsociarProductos = New DevComponents.DotNetBar.ButtonItem()
        Me.Grilla = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.Bar2 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Grabar = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Agregar_Producto = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Editar = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Cancelar = New DevComponents.DotNetBar.ButtonItem()
        Me.Grupo_Presupuesto.SuspendLayout()
        Me.Grupo_Grilla.SuspendLayout()
        CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Grupo_Presupuesto
        '
        Me.Grupo_Presupuesto.BackColor = System.Drawing.Color.White
        Me.Grupo_Presupuesto.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Grupo_Presupuesto.Controls.Add(Me.Txt_Receta)
        Me.Grupo_Presupuesto.Controls.Add(Me.LabelX2)
        Me.Grupo_Presupuesto.DisabledBackColor = System.Drawing.Color.Empty
        Me.Grupo_Presupuesto.Location = New System.Drawing.Point(9, 2)
        Me.Grupo_Presupuesto.Name = "Grupo_Presupuesto"
        Me.Grupo_Presupuesto.Size = New System.Drawing.Size(608, 37)
        '
        '
        '
        Me.Grupo_Presupuesto.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Grupo_Presupuesto.Style.BackColorGradientAngle = 90
        Me.Grupo_Presupuesto.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Grupo_Presupuesto.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Presupuesto.Style.BorderBottomWidth = 1
        Me.Grupo_Presupuesto.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.Grupo_Presupuesto.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Presupuesto.Style.BorderLeftWidth = 1
        Me.Grupo_Presupuesto.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Presupuesto.Style.BorderRightWidth = 1
        Me.Grupo_Presupuesto.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Presupuesto.Style.BorderTopWidth = 1
        Me.Grupo_Presupuesto.Style.CornerDiameter = 4
        Me.Grupo_Presupuesto.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Grupo_Presupuesto.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.Grupo_Presupuesto.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.Grupo_Presupuesto.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.Grupo_Presupuesto.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.Grupo_Presupuesto.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Grupo_Presupuesto.TabIndex = 102
        '
        'Txt_Receta
        '
        Me.Txt_Receta.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Receta.Border.Class = "TextBoxBorder"
        Me.Txt_Receta.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Receta.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_Receta.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Receta.Enabled = False
        Me.Txt_Receta.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Txt_Receta.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Receta.ForeColor = System.Drawing.Color.Black
        Me.Txt_Receta.Location = New System.Drawing.Point(54, 3)
        Me.Txt_Receta.MaxLength = 300
        Me.Txt_Receta.Name = "Txt_Receta"
        Me.Txt_Receta.ReadOnly = True
        Me.Txt_Receta.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.Txt_Receta.Size = New System.Drawing.Size(548, 22)
        Me.Txt_Receta.TabIndex = 71
        '
        'LabelX2
        '
        Me.LabelX2.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX2.ForeColor = System.Drawing.Color.Black
        Me.LabelX2.Location = New System.Drawing.Point(3, 3)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(51, 23)
        Me.LabelX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.LabelX2.TabIndex = 64
        Me.LabelX2.Text = "Servicio"
        '
        'Grupo_Grilla
        '
        Me.Grupo_Grilla.BackColor = System.Drawing.Color.White
        Me.Grupo_Grilla.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Grupo_Grilla.Controls.Add(Me.ContextMenuBar1)
        Me.Grupo_Grilla.Controls.Add(Me.Grilla)
        Me.Grupo_Grilla.DisabledBackColor = System.Drawing.Color.Empty
        Me.Grupo_Grilla.Location = New System.Drawing.Point(9, 45)
        Me.Grupo_Grilla.Name = "Grupo_Grilla"
        Me.Grupo_Grilla.Size = New System.Drawing.Size(608, 282)
        '
        '
        '
        Me.Grupo_Grilla.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Grupo_Grilla.Style.BackColorGradientAngle = 90
        Me.Grupo_Grilla.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Grupo_Grilla.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Grilla.Style.BorderBottomWidth = 1
        Me.Grupo_Grilla.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.Grupo_Grilla.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Grilla.Style.BorderLeftWidth = 1
        Me.Grupo_Grilla.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Grilla.Style.BorderRightWidth = 1
        Me.Grupo_Grilla.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Grilla.Style.BorderTopWidth = 1
        Me.Grupo_Grilla.Style.CornerDiameter = 4
        Me.Grupo_Grilla.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Grupo_Grilla.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.Grupo_Grilla.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.Grupo_Grilla.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.Grupo_Grilla.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.Grupo_Grilla.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Grupo_Grilla.TabIndex = 101
        Me.Grupo_Grilla.Text = "Operaciones a realizar"
        '
        'ContextMenuBar1
        '
        Me.ContextMenuBar1.AntiAlias = True
        Me.ContextMenuBar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ContextMenuBar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Menu_Contextual_01})
        Me.ContextMenuBar1.Location = New System.Drawing.Point(136, 117)
        Me.ContextMenuBar1.Name = "ContextMenuBar1"
        Me.ContextMenuBar1.Size = New System.Drawing.Size(330, 25)
        Me.ContextMenuBar1.Stretch = True
        Me.ContextMenuBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ContextMenuBar1.TabIndex = 56
        Me.ContextMenuBar1.TabStop = False
        Me.ContextMenuBar1.Text = "ContextMenuBar1"
        '
        'Menu_Contextual_01
        '
        Me.Menu_Contextual_01.AutoExpandOnClick = True
        Me.Menu_Contextual_01.Name = "Menu_Contextual_01"
        Me.Menu_Contextual_01.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Mnu_AgregaOperacionMismaReceta, Me.Btn_Mnu_AsociarProductos})
        Me.Menu_Contextual_01.Text = "Opciones"
        '
        'Btn_Mnu_AgregaOperacionMismaReceta
        '
        Me.Btn_Mnu_AgregaOperacionMismaReceta.Image = CType(resources.GetObject("Btn_Mnu_AgregaOperacionMismaReceta.Image"), System.Drawing.Image)
        Me.Btn_Mnu_AgregaOperacionMismaReceta.ImageAlt = CType(resources.GetObject("Btn_Mnu_AgregaOperacionMismaReceta.ImageAlt"), System.Drawing.Image)
        Me.Btn_Mnu_AgregaOperacionMismaReceta.Name = "Btn_Mnu_AgregaOperacionMismaReceta"
        Me.Btn_Mnu_AgregaOperacionMismaReceta.Text = "Agregar operación de la misma receta"
        '
        'Btn_Mnu_AsociarProductos
        '
        Me.Btn_Mnu_AsociarProductos.Image = CType(resources.GetObject("Btn_Mnu_AsociarProductos.Image"), System.Drawing.Image)
        Me.Btn_Mnu_AsociarProductos.ImageAlt = CType(resources.GetObject("Btn_Mnu_AsociarProductos.ImageAlt"), System.Drawing.Image)
        Me.Btn_Mnu_AsociarProductos.Name = "Btn_Mnu_AsociarProductos"
        Me.Btn_Mnu_AsociarProductos.Text = "Agregar otras operaciones"
        '
        'Grilla
        '
        Me.Grilla.AllowUserToAddRows = False
        Me.Grilla.AllowUserToDeleteRows = False
        Me.Grilla.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.Grilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Grilla.DefaultCellStyle = DataGridViewCellStyle5
        Me.Grilla.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grilla.EnableHeadersVisualStyles = False
        Me.Grilla.GridColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.Grilla.Location = New System.Drawing.Point(0, 0)
        Me.Grilla.MultiSelect = False
        Me.Grilla.Name = "Grilla"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.Grilla.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.Grilla.Size = New System.Drawing.Size(602, 259)
        Me.Grilla.TabIndex = 3
        '
        'Bar2
        '
        Me.Bar2.AntiAlias = True
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Grabar, Me.Btn_Agregar_Producto, Me.Btn_Editar, Me.Btn_Cancelar})
        Me.Bar2.Location = New System.Drawing.Point(0, 340)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(625, 41)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Bar2.TabIndex = 100
        Me.Bar2.TabStop = False
        Me.Bar2.Text = "Bar2"
        '
        'Btn_Grabar
        '
        Me.Btn_Grabar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Grabar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Grabar.Image = CType(resources.GetObject("Btn_Grabar.Image"), System.Drawing.Image)
        Me.Btn_Grabar.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.Btn_Grabar.Name = "Btn_Grabar"
        Me.Btn_Grabar.Tooltip = "Grabar [F4]"
        '
        'Btn_Agregar_Producto
        '
        Me.Btn_Agregar_Producto.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Agregar_Producto.ForeColor = System.Drawing.Color.Black
        Me.Btn_Agregar_Producto.Image = CType(resources.GetObject("Btn_Agregar_Producto.Image"), System.Drawing.Image)
        Me.Btn_Agregar_Producto.Name = "Btn_Agregar_Producto"
        Me.Btn_Agregar_Producto.Text = "Agregar operación"
        '
        'Btn_Editar
        '
        Me.Btn_Editar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Editar.FontBold = True
        Me.Btn_Editar.ForeColor = System.Drawing.Color.Red
        Me.Btn_Editar.Image = CType(resources.GetObject("Btn_Editar.Image"), System.Drawing.Image)
        Me.Btn_Editar.Name = "Btn_Editar"
        Me.Btn_Editar.Tooltip = "Editar"
        Me.Btn_Editar.Visible = False
        '
        'Btn_Cancelar
        '
        Me.Btn_Cancelar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Cancelar.FontBold = True
        Me.Btn_Cancelar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Cancelar.Image = CType(resources.GetObject("Btn_Cancelar.Image"), System.Drawing.Image)
        Me.Btn_Cancelar.Name = "Btn_Cancelar"
        Me.Btn_Cancelar.Text = "Cancelar edición"
        Me.Btn_Cancelar.Visible = False
        '
        'Frm_OperacionesXServicio
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(625, 381)
        Me.Controls.Add(Me.Grupo_Presupuesto)
        Me.Controls.Add(Me.Grupo_Grilla)
        Me.Controls.Add(Me.Bar2)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_OperacionesXServicio"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MetroForm"
        Me.Grupo_Presupuesto.ResumeLayout(False)
        Me.Grupo_Grilla.ResumeLayout(False)
        CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Grupo_Presupuesto As DevComponents.DotNetBar.Controls.GroupPanel
    Public WithEvents Txt_Receta As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Grupo_Grilla As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Grilla As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents Btn_Grabar As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_Editar As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_Cancelar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Agregar_Producto As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ContextMenuBar1 As DevComponents.DotNetBar.ContextMenuBar
    Friend WithEvents Menu_Contextual_01 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Mnu_AgregaOperacionMismaReceta As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Mnu_AsociarProductos As DevComponents.DotNetBar.ButtonItem
End Class
