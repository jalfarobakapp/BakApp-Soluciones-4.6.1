<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Frm_Inv_Ubicaciones
    Inherits DevComponents.DotNetBar.Metro.MetroForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Inv_Ubicaciones))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.ContextMenuBar1 = New DevComponents.DotNetBar.ContextMenuBar()
        Me.Menu_Contextual_Zonas = New DevComponents.DotNetBar.ButtonItem()
        Me.LabelItem1 = New DevComponents.DotNetBar.LabelItem()
        Me.Btn_EditarUbicacion = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_EliminarUbicacion = New DevComponents.DotNetBar.ButtonItem()
        Me.LabelItem2 = New DevComponents.DotNetBar.LabelItem()
        Me.Btn_AbrirUbicacion = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_CerrarUbicacion = New DevComponents.DotNetBar.ButtonItem()
        Me.LabelItem3 = New DevComponents.DotNetBar.LabelItem()
        Me.Btn_Copiar = New DevComponents.DotNetBar.ButtonItem()
        Me.Menu_Contextual_Importar_Lista = New DevComponents.DotNetBar.ButtonItem()
        Me.LabelItem4 = New DevComponents.DotNetBar.LabelItem()
        Me.Btn_ImportarExcel = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_ImportarExcelEjemplo = New DevComponents.DotNetBar.ButtonItem()
        Me.Grilla = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Crear_Ubicacion = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Importar_Desde_Excel = New DevComponents.DotNetBar.ButtonItem()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.Cmb_Bodegas = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.GroupPanel1.SuspendLayout()
        CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupPanel1
        '
        Me.GroupPanel1.BackColor = System.Drawing.Color.White
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.ContextMenuBar1)
        Me.GroupPanel1.Controls.Add(Me.Grilla)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Location = New System.Drawing.Point(12, 41)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(708, 405)
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
        Me.GroupPanel1.TabIndex = 33
        Me.GroupPanel1.Text = "Zonas"
        '
        'ContextMenuBar1
        '
        Me.ContextMenuBar1.AntiAlias = True
        Me.ContextMenuBar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ContextMenuBar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Menu_Contextual_Zonas, Me.Menu_Contextual_Importar_Lista})
        Me.ContextMenuBar1.Location = New System.Drawing.Point(31, 37)
        Me.ContextMenuBar1.Name = "ContextMenuBar1"
        Me.ContextMenuBar1.Size = New System.Drawing.Size(480, 25)
        Me.ContextMenuBar1.Stretch = True
        Me.ContextMenuBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ContextMenuBar1.TabIndex = 48
        Me.ContextMenuBar1.TabStop = False
        Me.ContextMenuBar1.Text = "ContextMenuBar1"
        '
        'Menu_Contextual_Zonas
        '
        Me.Menu_Contextual_Zonas.AutoExpandOnClick = True
        Me.Menu_Contextual_Zonas.Name = "Menu_Contextual_Zonas"
        Me.Menu_Contextual_Zonas.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItem1, Me.Btn_EditarUbicacion, Me.Btn_EliminarUbicacion, Me.LabelItem2, Me.Btn_AbrirUbicacion, Me.Btn_CerrarUbicacion, Me.LabelItem3, Me.Btn_Copiar})
        Me.Menu_Contextual_Zonas.Text = "Opciones Despacho"
        '
        'LabelItem1
        '
        Me.LabelItem1.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.LabelItem1.BorderSide = DevComponents.DotNetBar.eBorderSide.Bottom
        Me.LabelItem1.BorderType = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.LabelItem1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(21, Byte), Integer), CType(CType(110, Byte), Integer))
        Me.LabelItem1.Name = "LabelItem1"
        Me.LabelItem1.PaddingBottom = 1
        Me.LabelItem1.PaddingLeft = 10
        Me.LabelItem1.PaddingTop = 1
        Me.LabelItem1.SingleLineColor = System.Drawing.Color.FromArgb(CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer))
        Me.LabelItem1.Text = "Ubicación"
        '
        'Btn_EditarUbicacion
        '
        Me.Btn_EditarUbicacion.Image = CType(resources.GetObject("Btn_EditarUbicacion.Image"), System.Drawing.Image)
        Me.Btn_EditarUbicacion.ImageAlt = CType(resources.GetObject("Btn_EditarUbicacion.ImageAlt"), System.Drawing.Image)
        Me.Btn_EditarUbicacion.Name = "Btn_EditarUbicacion"
        Me.Btn_EditarUbicacion.Text = "Editar Ubicación"
        Me.Btn_EditarUbicacion.Tooltip = "Dar "
        '
        'Btn_EliminarUbicacion
        '
        Me.Btn_EliminarUbicacion.Image = CType(resources.GetObject("Btn_EliminarUbicacion.Image"), System.Drawing.Image)
        Me.Btn_EliminarUbicacion.ImageAlt = CType(resources.GetObject("Btn_EliminarUbicacion.ImageAlt"), System.Drawing.Image)
        Me.Btn_EliminarUbicacion.Name = "Btn_EliminarUbicacion"
        Me.Btn_EliminarUbicacion.Text = "Eliminar Ubicación"
        Me.Btn_EliminarUbicacion.Tooltip = "Dar "
        '
        'LabelItem2
        '
        Me.LabelItem2.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.LabelItem2.BorderSide = DevComponents.DotNetBar.eBorderSide.Bottom
        Me.LabelItem2.BorderType = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.LabelItem2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(21, Byte), Integer), CType(CType(110, Byte), Integer))
        Me.LabelItem2.ImageTextSpacing = 1
        Me.LabelItem2.Name = "LabelItem2"
        Me.LabelItem2.PaddingBottom = 1
        Me.LabelItem2.PaddingLeft = 10
        Me.LabelItem2.PaddingTop = 1
        Me.LabelItem2.SingleLineColor = System.Drawing.Color.FromArgb(CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer))
        Me.LabelItem2.Text = "-------------------------------------------"
        '
        'Btn_AbrirUbicacion
        '
        Me.Btn_AbrirUbicacion.Image = CType(resources.GetObject("Btn_AbrirUbicacion.Image"), System.Drawing.Image)
        Me.Btn_AbrirUbicacion.ImageAlt = CType(resources.GetObject("Btn_AbrirUbicacion.ImageAlt"), System.Drawing.Image)
        Me.Btn_AbrirUbicacion.Name = "Btn_AbrirUbicacion"
        Me.Btn_AbrirUbicacion.Text = "Abrir Ubicación"
        Me.Btn_AbrirUbicacion.Tooltip = "Dar "
        '
        'Btn_CerrarUbicacion
        '
        Me.Btn_CerrarUbicacion.Image = CType(resources.GetObject("Btn_CerrarUbicacion.Image"), System.Drawing.Image)
        Me.Btn_CerrarUbicacion.ImageAlt = CType(resources.GetObject("Btn_CerrarUbicacion.ImageAlt"), System.Drawing.Image)
        Me.Btn_CerrarUbicacion.Name = "Btn_CerrarUbicacion"
        Me.Btn_CerrarUbicacion.Text = "Cerrar Ubicación"
        Me.Btn_CerrarUbicacion.Tooltip = "Dar "
        '
        'LabelItem3
        '
        Me.LabelItem3.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.LabelItem3.BorderSide = DevComponents.DotNetBar.eBorderSide.Bottom
        Me.LabelItem3.BorderType = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.LabelItem3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(21, Byte), Integer), CType(CType(110, Byte), Integer))
        Me.LabelItem3.ImageTextSpacing = 1
        Me.LabelItem3.Name = "LabelItem3"
        Me.LabelItem3.PaddingBottom = 1
        Me.LabelItem3.PaddingLeft = 10
        Me.LabelItem3.PaddingTop = 1
        Me.LabelItem3.SingleLineColor = System.Drawing.Color.FromArgb(CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer))
        Me.LabelItem3.Text = "-------------------------------------------"
        '
        'Btn_Copiar
        '
        Me.Btn_Copiar.Image = CType(resources.GetObject("Btn_Copiar.Image"), System.Drawing.Image)
        Me.Btn_Copiar.ImageAlt = CType(resources.GetObject("Btn_Copiar.ImageAlt"), System.Drawing.Image)
        Me.Btn_Copiar.Name = "Btn_Copiar"
        Me.Btn_Copiar.Text = "Copiar (portapapeles)"
        '
        'Menu_Contextual_Importar_Lista
        '
        Me.Menu_Contextual_Importar_Lista.AutoExpandOnClick = True
        Me.Menu_Contextual_Importar_Lista.Name = "Menu_Contextual_Importar_Lista"
        Me.Menu_Contextual_Importar_Lista.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItem4, Me.Btn_ImportarExcel, Me.Btn_ImportarExcelEjemplo})
        Me.Menu_Contextual_Importar_Lista.Text = "Opciones Importar lista"
        '
        'LabelItem4
        '
        Me.LabelItem4.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.LabelItem4.BorderSide = DevComponents.DotNetBar.eBorderSide.Bottom
        Me.LabelItem4.BorderType = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.LabelItem4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(21, Byte), Integer), CType(CType(110, Byte), Integer))
        Me.LabelItem4.Name = "LabelItem4"
        Me.LabelItem4.PaddingBottom = 1
        Me.LabelItem4.PaddingLeft = 10
        Me.LabelItem4.PaddingTop = 1
        Me.LabelItem4.SingleLineColor = System.Drawing.Color.FromArgb(CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer))
        Me.LabelItem4.Text = "Importar lista"
        '
        'Btn_ImportarExcel
        '
        Me.Btn_ImportarExcel.Image = CType(resources.GetObject("Btn_ImportarExcel.Image"), System.Drawing.Image)
        Me.Btn_ImportarExcel.ImageAlt = CType(resources.GetObject("Btn_ImportarExcel.ImageAlt"), System.Drawing.Image)
        Me.Btn_ImportarExcel.Name = "Btn_ImportarExcel"
        Me.Btn_ImportarExcel.Text = "Buscar archivo y levantar"
        '
        'Btn_ImportarExcelEjemplo
        '
        Me.Btn_ImportarExcelEjemplo.Image = CType(resources.GetObject("Btn_ImportarExcelEjemplo.Image"), System.Drawing.Image)
        Me.Btn_ImportarExcelEjemplo.ImageAlt = CType(resources.GetObject("Btn_ImportarExcelEjemplo.ImageAlt"), System.Drawing.Image)
        Me.Btn_ImportarExcelEjemplo.Name = "Btn_ImportarExcelEjemplo"
        Me.Btn_ImportarExcelEjemplo.Text = "Ayuda, ejemplo archivo excel."
        '
        'Grilla
        '
        Me.Grilla.AllowUserToAddRows = False
        Me.Grilla.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.Grilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
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
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.Grilla.Size = New System.Drawing.Size(702, 382)
        Me.Grilla.StandardTab = True
        Me.Grilla.TabIndex = 30
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Crear_Ubicacion, Me.Btn_Importar_Desde_Excel})
        Me.Bar1.Location = New System.Drawing.Point(0, 459)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(732, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 32
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'Btn_Crear_Ubicacion
        '
        Me.Btn_Crear_Ubicacion.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Crear_Ubicacion.ForeColor = System.Drawing.Color.Black
        Me.Btn_Crear_Ubicacion.Image = CType(resources.GetObject("Btn_Crear_Ubicacion.Image"), System.Drawing.Image)
        Me.Btn_Crear_Ubicacion.ImageAlt = CType(resources.GetObject("Btn_Crear_Ubicacion.ImageAlt"), System.Drawing.Image)
        Me.Btn_Crear_Ubicacion.Name = "Btn_Crear_Ubicacion"
        Me.Btn_Crear_Ubicacion.Tooltip = "Crear Inventario"
        '
        'Btn_Importar_Desde_Excel
        '
        Me.Btn_Importar_Desde_Excel.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Importar_Desde_Excel.ForeColor = System.Drawing.Color.Black
        Me.Btn_Importar_Desde_Excel.Image = CType(resources.GetObject("Btn_Importar_Desde_Excel.Image"), System.Drawing.Image)
        Me.Btn_Importar_Desde_Excel.ImageAlt = CType(resources.GetObject("Btn_Importar_Desde_Excel.ImageAlt"), System.Drawing.Image)
        Me.Btn_Importar_Desde_Excel.Name = "Btn_Importar_Desde_Excel"
        Me.Btn_Importar_Desde_Excel.Text = "Importar"
        Me.Btn_Importar_Desde_Excel.Tooltip = "Importar ubicaciones/sectores masivamente desde Excel"
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.ForeColor = System.Drawing.Color.Black
        Me.LabelX1.Location = New System.Drawing.Point(15, 12)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(45, 23)
        Me.LabelX1.TabIndex = 34
        Me.LabelX1.Text = "Bodega"
        '
        'Cmb_Bodegas
        '
        Me.Cmb_Bodegas.DisplayMember = "Text"
        Me.Cmb_Bodegas.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.Cmb_Bodegas.ForeColor = System.Drawing.Color.Black
        Me.Cmb_Bodegas.FormattingEnabled = True
        Me.Cmb_Bodegas.ItemHeight = 16
        Me.Cmb_Bodegas.Location = New System.Drawing.Point(66, 13)
        Me.Cmb_Bodegas.Name = "Cmb_Bodegas"
        Me.Cmb_Bodegas.Size = New System.Drawing.Size(654, 22)
        Me.Cmb_Bodegas.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Cmb_Bodegas.TabIndex = 35
        '
        'Frm_Inv_Ubicaciones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(732, 500)
        Me.Controls.Add(Me.Cmb_Bodegas)
        Me.Controls.Add(Me.LabelX1)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Controls.Add(Me.Bar1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Inv_Ubicaciones"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MetroForm"
        Me.GroupPanel1.ResumeLayout(False)
        CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Grilla As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents Btn_Crear_Ubicacion As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Cmb_Bodegas As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents ContextMenuBar1 As DevComponents.DotNetBar.ContextMenuBar
    Friend WithEvents Menu_Contextual_Zonas As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_EditarUbicacion As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_EliminarUbicacion As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelItem1 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents Btn_AbrirUbicacion As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_CerrarUbicacion As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelItem3 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents Btn_Copiar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelItem2 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents Menu_Contextual_Importar_Lista As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelItem4 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents Btn_ImportarExcel As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_ImportarExcelEjemplo As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Importar_Desde_Excel As DevComponents.DotNetBar.ButtonItem
End Class
