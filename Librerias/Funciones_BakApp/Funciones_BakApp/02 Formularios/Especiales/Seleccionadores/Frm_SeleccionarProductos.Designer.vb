<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_SeleccionarProductos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_SeleccionarProductos))
        Me.Grilla1 = New System.Windows.Forms.DataGridView
        Me.Grilla2 = New System.Windows.Forms.DataGridView
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX
        Me.TxtDescripcionL = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.BtnDeDerIzq = New DevComponents.DotNetBar.ButtonX
        Me.CmmdDesSeleccionar = New DevComponents.DotNetBar.Command(Me.components)
        Me.BtnDeIzqDer = New DevComponents.DotNetBar.ButtonX
        Me.CmmdSeleccionar = New DevComponents.DotNetBar.Command(Me.components)
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel
        Me.TxtCodigo = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX
        Me.Bar1 = New DevComponents.DotNetBar.Bar
        Me.BtnExportarExcel = New DevComponents.DotNetBar.ButtonItem
        Me.BtnAceptar = New DevComponents.DotNetBar.ButtonItem
        Me.BtnCancelar = New DevComponents.DotNetBar.ButtonItem
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MoverProductosSeleccionadosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.QuitarProductosDeLaSelecciónToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.GroupPanel2 = New DevComponents.DotNetBar.Controls.GroupPanel
        CType(Me.Grilla1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Grilla2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel1.SuspendLayout()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.GroupPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Grilla1
        '
        Me.Grilla1.AllowUserToAddRows = False
        Me.Grilla1.AllowUserToDeleteRows = False
        Me.Grilla1.BackgroundColor = System.Drawing.Color.White
        Me.Grilla1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Grilla1.Location = New System.Drawing.Point(3, 63)
        Me.Grilla1.Name = "Grilla1"
        Me.Grilla1.ReadOnly = True
        Me.Grilla1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Grilla1.Size = New System.Drawing.Size(388, 406)
        Me.Grilla1.TabIndex = 0
        '
        'Grilla2
        '
        Me.Grilla2.AllowUserToAddRows = False
        Me.Grilla2.AllowUserToDeleteRows = False
        Me.Grilla2.BackgroundColor = System.Drawing.Color.White
        Me.Grilla2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Grilla2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grilla2.Location = New System.Drawing.Point(0, 0)
        Me.Grilla2.Name = "Grilla2"
        Me.Grilla2.ReadOnly = True
        Me.Grilla2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Grilla2.Size = New System.Drawing.Size(394, 472)
        Me.Grilla2.TabIndex = 1
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.ForeColor = System.Drawing.Color.Black
        Me.LabelX1.Location = New System.Drawing.Point(12, 0)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(178, 23)
        Me.LabelX1.TabIndex = 2
        Me.LabelX1.Text = "Maestro de productos"
        '
        'TxtDescripcionL
        '
        Me.TxtDescripcionL.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TxtDescripcionL.Border.Class = "TextBoxBorder"
        Me.TxtDescripcionL.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtDescripcionL.DisabledBackColor = System.Drawing.Color.White
        Me.TxtDescripcionL.ForeColor = System.Drawing.Color.Black
        Me.TxtDescripcionL.Location = New System.Drawing.Point(73, 33)
        Me.TxtDescripcionL.Name = "TxtDescripcionL"
        Me.TxtDescripcionL.PreventEnterBeep = True
        Me.TxtDescripcionL.Size = New System.Drawing.Size(318, 22)
        Me.TxtDescripcionL.TabIndex = 4
        '
        'BtnDeDerIzq
        '
        Me.BtnDeDerIzq.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BtnDeDerIzq.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.BtnDeDerIzq.Command = Me.CmmdDesSeleccionar
        Me.BtnDeDerIzq.Image = Global.Funciones_BakApp.My.Resources.Resources.arrow_left
        Me.BtnDeDerIzq.Location = New System.Drawing.Point(418, 52)
        Me.BtnDeDerIzq.Name = "BtnDeDerIzq"
        Me.BtnDeDerIzq.Size = New System.Drawing.Size(36, 52)
        Me.BtnDeDerIzq.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.BtnDeDerIzq.TabIndex = 6
        '
        'CmmdDesSeleccionar
        '
        Me.CmmdDesSeleccionar.Name = "CmmdDesSeleccionar"
        '
        'BtnDeIzqDer
        '
        Me.BtnDeIzqDer.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BtnDeIzqDer.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.BtnDeIzqDer.Command = Me.CmmdSeleccionar
        Me.BtnDeIzqDer.Image = Global.Funciones_BakApp.My.Resources.Resources.arrow_right
        Me.BtnDeIzqDer.Location = New System.Drawing.Point(418, 135)
        Me.BtnDeIzqDer.Name = "BtnDeIzqDer"
        Me.BtnDeIzqDer.Size = New System.Drawing.Size(36, 52)
        Me.BtnDeIzqDer.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.BtnDeIzqDer.TabIndex = 7
        '
        'CmmdSeleccionar
        '
        Me.CmmdSeleccionar.Name = "CmmdSeleccionar"
        '
        'LabelX4
        '
        Me.LabelX4.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.ForeColor = System.Drawing.Color.Black
        Me.LabelX4.Location = New System.Drawing.Point(3, 33)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(71, 23)
        Me.LabelX4.TabIndex = 9
        Me.LabelX4.Text = "Descripción"
        '
        'GroupPanel1
        '
        Me.GroupPanel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GroupPanel1.CanvasColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.GroupPanel1.Controls.Add(Me.TxtCodigo)
        Me.GroupPanel1.Controls.Add(Me.LabelX2)
        Me.GroupPanel1.Controls.Add(Me.TxtDescripcionL)
        Me.GroupPanel1.Controls.Add(Me.Grilla1)
        Me.GroupPanel1.Controls.Add(Me.LabelX4)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Location = New System.Drawing.Point(12, 29)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(400, 495)
        '
        '
        '
        Me.GroupPanel1.Style.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GroupPanel1.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.GroupPanel1.Style.BackColorGradientAngle = 90
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
        Me.GroupPanel1.TabIndex = 10
        Me.GroupPanel1.Text = "Busqueda rapida"
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
        Me.TxtCodigo.ForeColor = System.Drawing.Color.Black
        Me.TxtCodigo.Location = New System.Drawing.Point(73, 5)
        Me.TxtCodigo.Name = "TxtCodigo"
        Me.TxtCodigo.PreventEnterBeep = True
        Me.TxtCodigo.Size = New System.Drawing.Size(116, 22)
        Me.TxtCodigo.TabIndex = 10
        '
        'LabelX2
        '
        Me.LabelX2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.ForeColor = System.Drawing.Color.Black
        Me.LabelX2.Location = New System.Drawing.Point(3, 5)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(71, 23)
        Me.LabelX2.TabIndex = 11
        Me.LabelX2.Text = "Código"
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.BtnExportarExcel, Me.BtnAceptar, Me.BtnCancelar})
        Me.Bar1.Location = New System.Drawing.Point(0, 530)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(865, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 11
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'BtnExportarExcel
        '
        Me.BtnExportarExcel.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnExportarExcel.ForeColor = System.Drawing.Color.Black
        Me.BtnExportarExcel.Name = "BtnExportarExcel"
        Me.BtnExportarExcel.Tooltip = "Exportar a Excel"
        '
        'BtnAceptar
        '
        Me.BtnAceptar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnAceptar.ForeColor = System.Drawing.Color.Black
        Me.BtnAceptar.Image = Global.Funciones_BakApp.My.Resources.Resources.ok_button
        Me.BtnAceptar.Name = "BtnAceptar"
        Me.BtnAceptar.Text = "Aceptar"
        '
        'BtnCancelar
        '
        Me.BtnCancelar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnCancelar.ForeColor = System.Drawing.Color.Black
        Me.BtnCancelar.Image = Global.Funciones_BakApp.My.Resources.Resources.button_rounded_red_delete
        Me.BtnCancelar.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Text = "Cancelar"
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MoverProductosSeleccionadosToolStripMenuItem, Me.QuitarProductosDeLaSelecciónToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(254, 48)
        '
        'MoverProductosSeleccionadosToolStripMenuItem
        '
        Me.MoverProductosSeleccionadosToolStripMenuItem.Name = "MoverProductosSeleccionadosToolStripMenuItem"
        Me.MoverProductosSeleccionadosToolStripMenuItem.Size = New System.Drawing.Size(253, 22)
        Me.MoverProductosSeleccionadosToolStripMenuItem.Text = "Mover productos a la seleccion..."
        '
        'QuitarProductosDeLaSelecciónToolStripMenuItem
        '
        Me.QuitarProductosDeLaSelecciónToolStripMenuItem.Name = "QuitarProductosDeLaSelecciónToolStripMenuItem"
        Me.QuitarProductosDeLaSelecciónToolStripMenuItem.Size = New System.Drawing.Size(253, 22)
        Me.QuitarProductosDeLaSelecciónToolStripMenuItem.Text = "Quitar productos de la selección..."
        '
        'GroupPanel2
        '
        Me.GroupPanel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GroupPanel2.CanvasColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GroupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.GroupPanel2.Controls.Add(Me.Grilla2)
        Me.GroupPanel2.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel2.Location = New System.Drawing.Point(460, 29)
        Me.GroupPanel2.Name = "GroupPanel2"
        Me.GroupPanel2.Size = New System.Drawing.Size(400, 495)
        '
        '
        '
        Me.GroupPanel2.Style.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GroupPanel2.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.GroupPanel2.Style.BackColorGradientAngle = 90
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
        Me.GroupPanel2.TabIndex = 16
        Me.GroupPanel2.Text = "Productos seleccionados"
        '
        'Frm_SeleccionarProductos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(865, 571)
        Me.ControlBox = False
        Me.Controls.Add(Me.Bar1)
        Me.Controls.Add(Me.GroupPanel2)
        Me.Controls.Add(Me.BtnDeIzqDer)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Controls.Add(Me.LabelX1)
        Me.Controls.Add(Me.BtnDeDerIzq)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_SeleccionarProductos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Selección de productos para filtro"
        CType(Me.Grilla1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Grilla2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel1.ResumeLayout(False)
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.GroupPanel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Grilla1 As System.Windows.Forms.DataGridView
    Friend WithEvents Grilla2 As System.Windows.Forms.DataGridView
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TxtDescripcionL As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents BtnDeDerIzq As DevComponents.DotNetBar.ButtonX
    Friend WithEvents BtnDeIzqDer As DevComponents.DotNetBar.ButtonX
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents CmmdSeleccionar As DevComponents.DotNetBar.Command
    Friend WithEvents CmmdDesSeleccionar As DevComponents.DotNetBar.Command
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents BtnExportarExcel As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents BtnAceptar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents MoverProductosSeleccionadosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents QuitarProductosDeLaSelecciónToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GroupPanel2 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents TxtCodigo As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents BtnCancelar As DevComponents.DotNetBar.ButtonItem
End Class
