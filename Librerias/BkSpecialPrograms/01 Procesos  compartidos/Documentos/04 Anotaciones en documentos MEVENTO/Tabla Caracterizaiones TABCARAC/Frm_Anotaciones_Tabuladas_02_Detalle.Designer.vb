<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Anotaciones_Tabuladas_02_Detalle
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Anotaciones_Tabuladas_02_Detalle))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Incorporar_anotaciones = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Incorporar_Linea_Activa = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Incorporar_Solo_Tickeados = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Incorporar_todas = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Crear_Tabla = New DevComponents.DotNetBar.ButtonItem()
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.ContextMenuBar1 = New DevComponents.DotNetBar.ContextMenuBar()
        Me.Menu_Editar_Eliminar = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Editar_tabla = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Eliminar_tabla = New DevComponents.DotNetBar.ButtonItem()
        Me.Menu_Ligar_documentos = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Enlazar_documento = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Quitar_Link = New DevComponents.DotNetBar.ButtonItem()
        Me.Grilla = New DevComponents.DotNetBar.Controls.DataGridViewX()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel1.SuspendLayout()
        CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Incorporar_anotaciones, Me.Btn_Crear_Tabla})
        Me.Bar1.Location = New System.Drawing.Point(0, 311)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(794, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 44
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'Btn_Incorporar_anotaciones
        '
        Me.Btn_Incorporar_anotaciones.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Incorporar_anotaciones.ForeColor = System.Drawing.Color.Black
        Me.Btn_Incorporar_anotaciones.Image = CType(resources.GetObject("Btn_Incorporar_anotaciones.Image"), System.Drawing.Image)
        Me.Btn_Incorporar_anotaciones.Name = "Btn_Incorporar_anotaciones"
        Me.Btn_Incorporar_anotaciones.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Incorporar_Linea_Activa, Me.Btn_Incorporar_Solo_Tickeados, Me.Btn_Incorporar_todas})
        Me.Btn_Incorporar_anotaciones.Text = "Incorporar anotaciones"
        Me.Btn_Incorporar_anotaciones.Tooltip = "Crear nueva fila"
        '
        'Btn_Incorporar_Linea_Activa
        '
        Me.Btn_Incorporar_Linea_Activa.Image = CType(resources.GetObject("Btn_Incorporar_Linea_Activa.Image"), System.Drawing.Image)
        Me.Btn_Incorporar_Linea_Activa.Name = "Btn_Incorporar_Linea_Activa"
        Me.Btn_Incorporar_Linea_Activa.Text = "Incorporar evento activo de la lista al documento"
        '
        'Btn_Incorporar_Solo_Tickeados
        '
        Me.Btn_Incorporar_Solo_Tickeados.Image = CType(resources.GetObject("Btn_Incorporar_Solo_Tickeados.Image"), System.Drawing.Image)
        Me.Btn_Incorporar_Solo_Tickeados.Name = "Btn_Incorporar_Solo_Tickeados"
        Me.Btn_Incorporar_Solo_Tickeados.Text = "Incorporar lista de eventos marcados al documento"
        '
        'Btn_Incorporar_todas
        '
        Me.Btn_Incorporar_todas.Image = CType(resources.GetObject("Btn_Incorporar_todas.Image"), System.Drawing.Image)
        Me.Btn_Incorporar_todas.Name = "Btn_Incorporar_todas"
        Me.Btn_Incorporar_todas.Text = "Incorporar todo el conjunto de anotaciones al documento"
        '
        'Btn_Crear_Tabla
        '
        Me.Btn_Crear_Tabla.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Crear_Tabla.ForeColor = System.Drawing.Color.Black
        Me.Btn_Crear_Tabla.Image = CType(resources.GetObject("Btn_Crear_Tabla.Image"), System.Drawing.Image)
        Me.Btn_Crear_Tabla.Name = "Btn_Crear_Tabla"
        Me.Btn_Crear_Tabla.Tooltip = "Crear nueva fila"
        '
        'GroupPanel1
        '
        Me.GroupPanel1.BackColor = System.Drawing.Color.White
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.ContextMenuBar1)
        Me.GroupPanel1.Controls.Add(Me.Grilla)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Location = New System.Drawing.Point(12, 3)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(770, 290)
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
        Me.GroupPanel1.TabIndex = 43
        Me.GroupPanel1.Text = "Detalle"
        '
        'ContextMenuBar1
        '
        Me.ContextMenuBar1.AntiAlias = True
        Me.ContextMenuBar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ContextMenuBar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Menu_Editar_Eliminar, Me.Menu_Ligar_documentos})
        Me.ContextMenuBar1.Location = New System.Drawing.Point(106, 75)
        Me.ContextMenuBar1.Name = "ContextMenuBar1"
        Me.ContextMenuBar1.Size = New System.Drawing.Size(243, 25)
        Me.ContextMenuBar1.Stretch = True
        Me.ContextMenuBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ContextMenuBar1.TabIndex = 43
        Me.ContextMenuBar1.TabStop = False
        Me.ContextMenuBar1.Text = "ContextMenuBar1"
        '
        'Menu_Editar_Eliminar
        '
        Me.Menu_Editar_Eliminar.AutoExpandOnClick = True
        Me.Menu_Editar_Eliminar.Name = "Menu_Editar_Eliminar"
        Me.Menu_Editar_Eliminar.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Editar_tabla, Me.Btn_Eliminar_tabla})
        Me.Menu_Editar_Eliminar.Text = "Opciones"
        '
        'Btn_Editar_tabla
        '
        Me.Btn_Editar_tabla.Image = CType(resources.GetObject("Btn_Editar_tabla.Image"), System.Drawing.Image)
        Me.Btn_Editar_tabla.Name = "Btn_Editar_tabla"
        Me.Btn_Editar_tabla.Text = "Editar descripción"
        '
        'Btn_Eliminar_tabla
        '
        Me.Btn_Eliminar_tabla.Image = CType(resources.GetObject("Btn_Eliminar_tabla.Image"), System.Drawing.Image)
        Me.Btn_Eliminar_tabla.Name = "Btn_Eliminar_tabla"
        Me.Btn_Eliminar_tabla.Text = "Eliminar fila"
        '
        'Menu_Ligar_documentos
        '
        Me.Menu_Ligar_documentos.AutoExpandOnClick = True
        Me.Menu_Ligar_documentos.Name = "Menu_Ligar_documentos"
        Me.Menu_Ligar_documentos.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Enlazar_documento, Me.Btn_Quitar_Link})
        Me.Menu_Ligar_documentos.Text = "Opciones Liga"
        '
        'Btn_Enlazar_documento
        '
        Me.Btn_Enlazar_documento.Image = CType(resources.GetObject("Btn_Enlazar_documento.Image"), System.Drawing.Image)
        Me.Btn_Enlazar_documento.Name = "Btn_Enlazar_documento"
        Me.Btn_Enlazar_documento.Text = "Buscar un documento para enlazarlo al evento"
        '
        'Btn_Quitar_Link
        '
        Me.Btn_Quitar_Link.Image = CType(resources.GetObject("Btn_Quitar_Link.Image"), System.Drawing.Image)
        Me.Btn_Quitar_Link.Name = "Btn_Quitar_Link"
        Me.Btn_Quitar_Link.Text = "Quitar link"
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
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.Grilla.Size = New System.Drawing.Size(764, 267)
        Me.Grilla.StandardTab = True
        Me.Grilla.TabIndex = 45
        '
        'Frm_Anotaciones_Tabuladas_02_Detalle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(794, 352)
        Me.Controls.Add(Me.Bar1)
        Me.Controls.Add(Me.GroupPanel1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Anotaciones_Tabuladas_02_Detalle"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MetroForm"
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel1.ResumeLayout(False)
        CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents Btn_Crear_Tabla As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents ContextMenuBar1 As DevComponents.DotNetBar.ContextMenuBar
    Friend WithEvents Menu_Editar_Eliminar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Editar_tabla As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Eliminar_tabla As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Incorporar_anotaciones As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Incorporar_Linea_Activa As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Incorporar_Solo_Tickeados As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Incorporar_todas As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Menu_Ligar_documentos As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Enlazar_documento As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Quitar_Link As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Grilla As DevComponents.DotNetBar.Controls.DataGridViewX
End Class
