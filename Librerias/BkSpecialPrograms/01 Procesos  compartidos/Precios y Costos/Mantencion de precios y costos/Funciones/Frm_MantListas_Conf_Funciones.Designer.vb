<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_MantListas_Conf_Funciones
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_MantListas_Conf_Funciones))
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Txt_Formula_Fx = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.GroupPanel2 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.contextMenuBar1 = New DevComponents.DotNetBar.ContextMenuBar()
        Me.bEditPopup = New DevComponents.DotNetBar.ButtonItem()
        Me.bCut = New DevComponents.DotNetBar.ButtonItem()
        Me.bCopy = New DevComponents.DotNetBar.ButtonItem()
        Me.bPaste = New DevComponents.DotNetBar.ButtonItem()
        Me.bSelectAll = New DevComponents.DotNetBar.ButtonItem()
        Me.Grilla = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.Bar2 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Grabar = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Probar_Funcion = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Ayuda = New DevComponents.DotNetBar.ButtonItem()
        Me.Chk_Aplica_FX_Documento = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.GroupPanel1.SuspendLayout()
        Me.GroupPanel2.SuspendLayout()
        CType(Me.contextMenuBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupPanel1
        '
        Me.GroupPanel1.BackColor = System.Drawing.Color.White
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.Txt_Formula_Fx)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Location = New System.Drawing.Point(9, 269)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(642, 114)
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
        Me.GroupPanel1.TabIndex = 4
        Me.GroupPanel1.Text = "Función"
        '
        'Txt_Formula_Fx
        '
        Me.Txt_Formula_Fx.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Formula_Fx.Border.Class = "TextBoxBorder"
        Me.Txt_Formula_Fx.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Formula_Fx.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_Formula_Fx.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Formula_Fx.ForeColor = System.Drawing.Color.Black
        Me.Txt_Formula_Fx.Location = New System.Drawing.Point(3, 3)
        Me.Txt_Formula_Fx.Multiline = True
        Me.Txt_Formula_Fx.Name = "Txt_Formula_Fx"
        Me.Txt_Formula_Fx.PreventEnterBeep = True
        Me.Txt_Formula_Fx.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.Txt_Formula_Fx.Size = New System.Drawing.Size(630, 85)
        Me.Txt_Formula_Fx.TabIndex = 4
        '
        'GroupPanel2
        '
        Me.GroupPanel2.BackColor = System.Drawing.Color.White
        Me.GroupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel2.Controls.Add(Me.contextMenuBar1)
        Me.GroupPanel2.Controls.Add(Me.Grilla)
        Me.GroupPanel2.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel2.Location = New System.Drawing.Point(9, 12)
        Me.GroupPanel2.Name = "GroupPanel2"
        Me.GroupPanel2.Size = New System.Drawing.Size(642, 251)
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
        Me.GroupPanel2.TabIndex = 5
        Me.GroupPanel2.Text = "Dimensiones para el uso de las funciones"
        '
        'contextMenuBar1
        '
        Me.contextMenuBar1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.contextMenuBar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.bEditPopup})
        Me.contextMenuBar1.Location = New System.Drawing.Point(265, 84)
        Me.contextMenuBar1.Name = "contextMenuBar1"
        Me.contextMenuBar1.Size = New System.Drawing.Size(150, 25)
        Me.contextMenuBar1.Stretch = True
        Me.contextMenuBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.contextMenuBar1.TabIndex = 34
        Me.contextMenuBar1.TabStop = False
        '
        'bEditPopup
        '
        Me.bEditPopup.AutoExpandOnClick = True
        Me.bEditPopup.GlobalName = "bEditPopup"
        Me.bEditPopup.Name = "bEditPopup"
        Me.bEditPopup.PopupAnimation = DevComponents.DotNetBar.ePopupAnimation.SystemDefault
        Me.bEditPopup.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.bCut, Me.bCopy, Me.bPaste, Me.bSelectAll})
        Me.bEditPopup.Text = "bEditPopup"
        '
        'bCut
        '
        Me.bCut.BeginGroup = True
        Me.bCut.GlobalName = "bCut"
        Me.bCut.Image = CType(resources.GetObject("bCut.Image"), System.Drawing.Image)
        Me.bCut.ImageIndex = 5
        Me.bCut.Name = "bCut"
        Me.bCut.PopupAnimation = DevComponents.DotNetBar.ePopupAnimation.SystemDefault
        Me.bCut.Text = "Cu&t"
        '
        'bCopy
        '
        Me.bCopy.GlobalName = "bCopy"
        Me.bCopy.Image = CType(resources.GetObject("bCopy.Image"), System.Drawing.Image)
        Me.bCopy.ImageIndex = 4
        Me.bCopy.Name = "bCopy"
        Me.bCopy.PopupAnimation = DevComponents.DotNetBar.ePopupAnimation.SystemDefault
        Me.bCopy.Text = "&Copy"
        '
        'bPaste
        '
        Me.bPaste.GlobalName = "bPaste"
        Me.bPaste.Image = CType(resources.GetObject("bPaste.Image"), System.Drawing.Image)
        Me.bPaste.ImageIndex = 12
        Me.bPaste.Name = "bPaste"
        Me.bPaste.PopupAnimation = DevComponents.DotNetBar.ePopupAnimation.SystemDefault
        Me.bPaste.Text = "&Paste"
        '
        'bSelectAll
        '
        Me.bSelectAll.BeginGroup = True
        Me.bSelectAll.GlobalName = "bSelectAll"
        Me.bSelectAll.Image = CType(resources.GetObject("bSelectAll.Image"), System.Drawing.Image)
        Me.bSelectAll.Name = "bSelectAll"
        Me.bSelectAll.PopupAnimation = DevComponents.DotNetBar.ePopupAnimation.SystemDefault
        Me.bSelectAll.Text = "Select &All"
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
        Me.Grilla.Name = "Grilla"
        Me.Grilla.ReadOnly = True
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.Grilla.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Grilla.Size = New System.Drawing.Size(636, 228)
        Me.Grilla.StandardTab = True
        Me.Grilla.TabIndex = 28
        '
        'Bar2
        '
        Me.Bar2.AntiAlias = True
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Grabar, Me.Btn_Probar_Funcion, Me.Btn_Ayuda})
        Me.Bar2.Location = New System.Drawing.Point(0, 418)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(663, 41)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Bar2.TabIndex = 32
        Me.Bar2.TabStop = False
        Me.Bar2.Text = "Bar2"
        '
        'Btn_Grabar
        '
        Me.Btn_Grabar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Grabar.Image = CType(resources.GetObject("Btn_Grabar.Image"), System.Drawing.Image)
        Me.Btn_Grabar.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.Btn_Grabar.Name = "Btn_Grabar"
        Me.Btn_Grabar.Tooltip = "Mantención de formula global"
        '
        'Btn_Probar_Funcion
        '
        Me.Btn_Probar_Funcion.ForeColor = System.Drawing.Color.Black
        Me.Btn_Probar_Funcion.Image = CType(resources.GetObject("Btn_Probar_Funcion.Image"), System.Drawing.Image)
        Me.Btn_Probar_Funcion.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.Btn_Probar_Funcion.Name = "Btn_Probar_Funcion"
        Me.Btn_Probar_Funcion.Tooltip = "Probar"
        '
        'Btn_Ayuda
        '
        Me.Btn_Ayuda.ForeColor = System.Drawing.Color.Black
        Me.Btn_Ayuda.Image = CType(resources.GetObject("Btn_Ayuda.Image"), System.Drawing.Image)
        Me.Btn_Ayuda.ImageAlt = CType(resources.GetObject("Btn_Ayuda.ImageAlt"), System.Drawing.Image)
        Me.Btn_Ayuda.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.Btn_Ayuda.Name = "Btn_Ayuda"
        Me.Btn_Ayuda.Tooltip = "Ayuda para entender como se utilizan las funciones"
        '
        'Chk_Aplica_FX_Documento
        '
        Me.Chk_Aplica_FX_Documento.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Chk_Aplica_FX_Documento.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Aplica_FX_Documento.ForeColor = System.Drawing.Color.Black
        Me.Chk_Aplica_FX_Documento.Location = New System.Drawing.Point(9, 389)
        Me.Chk_Aplica_FX_Documento.Name = "Chk_Aplica_FX_Documento"
        Me.Chk_Aplica_FX_Documento.Size = New System.Drawing.Size(252, 23)
        Me.Chk_Aplica_FX_Documento.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Aplica_FX_Documento.TabIndex = 33
        Me.Chk_Aplica_FX_Documento.Text = "Aplicar formula en busqueda de productos"
        '
        'Frm_MantListas_Conf_Funciones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(663, 459)
        Me.Controls.Add(Me.Chk_Aplica_FX_Documento)
        Me.Controls.Add(Me.Bar2)
        Me.Controls.Add(Me.GroupPanel2)
        Me.Controls.Add(Me.GroupPanel1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_MantListas_Conf_Funciones"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Mantención de fonciones y formulas para los precios"
        Me.GroupPanel1.ResumeLayout(False)
        Me.GroupPanel2.ResumeLayout(False)
        CType(Me.contextMenuBar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents GroupPanel2 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Grilla As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Public WithEvents Btn_Grabar As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_Probar_Funcion As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Chk_Aplica_FX_Documento As DevComponents.DotNetBar.Controls.CheckBoxX
    Private WithEvents contextMenuBar1 As DevComponents.DotNetBar.ContextMenuBar
    Private WithEvents bEditPopup As DevComponents.DotNetBar.ButtonItem
    Private WithEvents bCut As DevComponents.DotNetBar.ButtonItem
    Private WithEvents bCopy As DevComponents.DotNetBar.ButtonItem
    Private WithEvents bPaste As DevComponents.DotNetBar.ButtonItem
    Private WithEvents bSelectAll As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Txt_Formula_Fx As DevComponents.DotNetBar.Controls.TextBoxX
    Public WithEvents Btn_Ayuda As DevComponents.DotNetBar.ButtonItem
End Class
