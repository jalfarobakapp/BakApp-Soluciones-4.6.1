<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Crear_Entidad_Mt_CiasSeguro
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Crear_Entidad_Mt_CiasSeguro))
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Menu_Contextual = New DevComponents.DotNetBar.ContextMenuBar()
        Me.Menu_Contextual_01 = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_EditarCiaSeguro = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_QuitarCiaSeguro = New DevComponents.DotNetBar.ButtonItem()
        Me.Grilla_CisSeguros = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.Btn_AsociarCiaSeguro = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_VenderSinUsarCiaSeguro = New DevComponents.DotNetBar.ButtonItem()
        Me.GroupPanel1.SuspendLayout()
        CType(Me.Menu_Contextual, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Grilla_CisSeguros, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupPanel1
        '
        Me.GroupPanel1.BackColor = System.Drawing.Color.White
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.Menu_Contextual)
        Me.GroupPanel1.Controls.Add(Me.Grilla_CisSeguros)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Location = New System.Drawing.Point(10, 6)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(781, 208)
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
        Me.GroupPanel1.TabIndex = 55
        Me.GroupPanel1.Text = "Compañias"
        '
        'Menu_Contextual
        '
        Me.Menu_Contextual.AntiAlias = True
        Me.Menu_Contextual.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Menu_Contextual.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Menu_Contextual_01})
        Me.Menu_Contextual.Location = New System.Drawing.Point(92, 31)
        Me.Menu_Contextual.Name = "Menu_Contextual"
        Me.Menu_Contextual.Size = New System.Drawing.Size(153, 25)
        Me.Menu_Contextual.Stretch = True
        Me.Menu_Contextual.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Menu_Contextual.TabIndex = 55
        Me.Menu_Contextual.TabStop = False
        Me.Menu_Contextual.Text = "ContextMenuBar1"
        '
        'Menu_Contextual_01
        '
        Me.Menu_Contextual_01.AutoExpandOnClick = True
        Me.Menu_Contextual_01.Name = "Menu_Contextual_01"
        Me.Menu_Contextual_01.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_EditarCiaSeguro, Me.Btn_QuitarCiaSeguro})
        Me.Menu_Contextual_01.Text = "Opciones"
        '
        'Btn_EditarCiaSeguro
        '
        Me.Btn_EditarCiaSeguro.Image = CType(resources.GetObject("Btn_EditarCiaSeguro.Image"), System.Drawing.Image)
        Me.Btn_EditarCiaSeguro.ImageAlt = CType(resources.GetObject("Btn_EditarCiaSeguro.ImageAlt"), System.Drawing.Image)
        Me.Btn_EditarCiaSeguro.Name = "Btn_EditarCiaSeguro"
        Me.Btn_EditarCiaSeguro.Text = "Editar monto asignado"
        '
        'Btn_QuitarCiaSeguro
        '
        Me.Btn_QuitarCiaSeguro.Image = CType(resources.GetObject("Btn_QuitarCiaSeguro.Image"), System.Drawing.Image)
        Me.Btn_QuitarCiaSeguro.ImageAlt = CType(resources.GetObject("Btn_QuitarCiaSeguro.ImageAlt"), System.Drawing.Image)
        Me.Btn_QuitarCiaSeguro.Name = "Btn_QuitarCiaSeguro"
        Me.Btn_QuitarCiaSeguro.Text = "Quitar compañia de seguro"
        '
        'Grilla_CisSeguros
        '
        Me.Grilla_CisSeguros.AllowUserToAddRows = False
        Me.Grilla_CisSeguros.AllowUserToDeleteRows = False
        Me.Grilla_CisSeguros.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla_CisSeguros.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle10
        Me.Grilla_CisSeguros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle11.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Grilla_CisSeguros.DefaultCellStyle = DataGridViewCellStyle11
        Me.Grilla_CisSeguros.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grilla_CisSeguros.EnableHeadersVisualStyles = False
        Me.Grilla_CisSeguros.GridColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.Grilla_CisSeguros.Location = New System.Drawing.Point(0, 0)
        Me.Grilla_CisSeguros.Name = "Grilla_CisSeguros"
        Me.Grilla_CisSeguros.ReadOnly = True
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle12.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla_CisSeguros.RowHeadersDefaultCellStyle = DataGridViewCellStyle12
        Me.Grilla_CisSeguros.Size = New System.Drawing.Size(775, 185)
        Me.Grilla_CisSeguros.StandardTab = True
        Me.Grilla_CisSeguros.TabIndex = 54
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_AsociarCiaSeguro, Me.Btn_VenderSinUsarCiaSeguro})
        Me.Bar1.Location = New System.Drawing.Point(0, 222)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(803, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 54
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'Btn_AsociarCiaSeguro
        '
        Me.Btn_AsociarCiaSeguro.ForeColor = System.Drawing.Color.Black
        Me.Btn_AsociarCiaSeguro.Image = CType(resources.GetObject("Btn_AsociarCiaSeguro.Image"), System.Drawing.Image)
        Me.Btn_AsociarCiaSeguro.ImageAlt = CType(resources.GetObject("Btn_AsociarCiaSeguro.ImageAlt"), System.Drawing.Image)
        Me.Btn_AsociarCiaSeguro.Name = "Btn_AsociarCiaSeguro"
        Me.Btn_AsociarCiaSeguro.Text = "  "
        '
        'Btn_VenderSinUsarCiaSeguro
        '
        Me.Btn_VenderSinUsarCiaSeguro.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_VenderSinUsarCiaSeguro.ForeColor = System.Drawing.Color.Black
        Me.Btn_VenderSinUsarCiaSeguro.Image = CType(resources.GetObject("Btn_VenderSinUsarCiaSeguro.Image"), System.Drawing.Image)
        Me.Btn_VenderSinUsarCiaSeguro.ImageAlt = CType(resources.GetObject("Btn_VenderSinUsarCiaSeguro.ImageAlt"), System.Drawing.Image)
        Me.Btn_VenderSinUsarCiaSeguro.Name = "Btn_VenderSinUsarCiaSeguro"
        Me.Btn_VenderSinUsarCiaSeguro.Text = "No usar compañia de seguros para la venta"
        '
        'Frm_Crear_Entidad_Mt_CiasSeguro
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(803, 263)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Controls.Add(Me.Bar1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Crear_Entidad_Mt_CiasSeguro"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Compañias de seguro asociadas a la entidad"
        Me.GroupPanel1.ResumeLayout(False)
        CType(Me.Menu_Contextual, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Grilla_CisSeguros, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Menu_Contextual As DevComponents.DotNetBar.ContextMenuBar
    Friend WithEvents Menu_Contextual_01 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_EditarCiaSeguro As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_QuitarCiaSeguro As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Grilla_CisSeguros As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents Btn_AsociarCiaSeguro As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_VenderSinUsarCiaSeguro As DevComponents.DotNetBar.ButtonItem
End Class
