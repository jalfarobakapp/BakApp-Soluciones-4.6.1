<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Frm_Anotaciones_Ver_Anotaciones
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Anotaciones_Ver_Anotaciones))
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.ContextMenuBar1 = New DevComponents.DotNetBar.ContextMenuBar()
        Me.Menu_Contextual_01 = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Ver_Anotacion = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Editar_Anotacion_Evento = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Eliminar_tabla = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Opciones_Link = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Ver_Link = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Ir_Ubicacion_Link = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Ver_Documento = New DevComponents.DotNetBar.ButtonItem()
        Me.Menu_Contextual_02 = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Agregar_Anotacion_Simple = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Agregar_Anotacion_Tabulada = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Agregar_Anotacion_Link = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Ligar_traza_externa = New DevComponents.DotNetBar.ButtonItem()
        Me.Grilla = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Agregar_Anotacion = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Exportar_a_Excel = New DevComponents.DotNetBar.ButtonItem()
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
        Me.GroupPanel1.Location = New System.Drawing.Point(12, 12)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(845, 369)
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
        Me.GroupPanel1.TabIndex = 39
        Me.GroupPanel1.Text = "Detalle"
        '
        'ContextMenuBar1
        '
        Me.ContextMenuBar1.AntiAlias = True
        Me.ContextMenuBar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ContextMenuBar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Menu_Contextual_01, Me.Menu_Contextual_02})
        Me.ContextMenuBar1.Location = New System.Drawing.Point(277, 93)
        Me.ContextMenuBar1.Name = "ContextMenuBar1"
        Me.ContextMenuBar1.Size = New System.Drawing.Size(341, 25)
        Me.ContextMenuBar1.Stretch = True
        Me.ContextMenuBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ContextMenuBar1.TabIndex = 44
        Me.ContextMenuBar1.TabStop = False
        Me.ContextMenuBar1.Text = "ContextMenuBar1"
        '
        'Menu_Contextual_01
        '
        Me.Menu_Contextual_01.AutoExpandOnClick = True
        Me.Menu_Contextual_01.Name = "Menu_Contextual_01"
        Me.Menu_Contextual_01.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Ver_Anotacion, Me.Btn_Editar_Anotacion_Evento, Me.Btn_Eliminar_tabla, Me.Btn_Opciones_Link, Me.Btn_Ver_Documento})
        Me.Menu_Contextual_01.Text = "Opciones"
        '
        'Btn_Ver_Anotacion
        '
        Me.Btn_Ver_Anotacion.Image = CType(resources.GetObject("Btn_Ver_Anotacion.Image"), System.Drawing.Image)
        Me.Btn_Ver_Anotacion.Name = "Btn_Ver_Anotacion"
        Me.Btn_Ver_Anotacion.Text = "Ver Anotación"
        '
        'Btn_Editar_Anotacion_Evento
        '
        Me.Btn_Editar_Anotacion_Evento.Image = CType(resources.GetObject("Btn_Editar_Anotacion_Evento.Image"), System.Drawing.Image)
        Me.Btn_Editar_Anotacion_Evento.Name = "Btn_Editar_Anotacion_Evento"
        Me.Btn_Editar_Anotacion_Evento.Text = "Editar Anotación/Evento"
        '
        'Btn_Eliminar_tabla
        '
        Me.Btn_Eliminar_tabla.Image = CType(resources.GetObject("Btn_Eliminar_tabla.Image"), System.Drawing.Image)
        Me.Btn_Eliminar_tabla.Name = "Btn_Eliminar_tabla"
        Me.Btn_Eliminar_tabla.Text = "Eliminar Anotación/Evento"
        '
        'Btn_Opciones_Link
        '
        Me.Btn_Opciones_Link.Image = CType(resources.GetObject("Btn_Opciones_Link.Image"), System.Drawing.Image)
        Me.Btn_Opciones_Link.Name = "Btn_Opciones_Link"
        Me.Btn_Opciones_Link.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Ver_Link, Me.Btn_Ir_Ubicacion_Link})
        Me.Btn_Opciones_Link.Text = "Opciones del link"
        '
        'Btn_Ver_Link
        '
        Me.Btn_Ver_Link.Image = CType(resources.GetObject("Btn_Ver_Link.Image"), System.Drawing.Image)
        Me.Btn_Ver_Link.Name = "Btn_Ver_Link"
        Me.Btn_Ver_Link.Text = "Ver link asociado"
        '
        'Btn_Ir_Ubicacion_Link
        '
        Me.Btn_Ir_Ubicacion_Link.Image = CType(resources.GetObject("Btn_Ir_Ubicacion_Link.Image"), System.Drawing.Image)
        Me.Btn_Ir_Ubicacion_Link.Name = "Btn_Ir_Ubicacion_Link"
        Me.Btn_Ir_Ubicacion_Link.Text = "Ir a la ubicación del archivo"
        '
        'Btn_Ver_Documento
        '
        Me.Btn_Ver_Documento.Image = CType(resources.GetObject("Btn_Ver_Documento.Image"), System.Drawing.Image)
        Me.Btn_Ver_Documento.Name = "Btn_Ver_Documento"
        Me.Btn_Ver_Documento.Text = "Ver documento (ligado a traza externa)"
        '
        'Menu_Contextual_02
        '
        Me.Menu_Contextual_02.AutoExpandOnClick = True
        Me.Menu_Contextual_02.Name = "Menu_Contextual_02"
        Me.Menu_Contextual_02.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Agregar_Anotacion_Simple, Me.Btn_Agregar_Anotacion_Tabulada, Me.Btn_Agregar_Anotacion_Link, Me.Btn_Ligar_traza_externa})
        Me.Menu_Contextual_02.Text = "Opciones Agregar Anotaciones"
        '
        'Btn_Agregar_Anotacion_Simple
        '
        Me.Btn_Agregar_Anotacion_Simple.Image = CType(resources.GetObject("Btn_Agregar_Anotacion_Simple.Image"), System.Drawing.Image)
        Me.Btn_Agregar_Anotacion_Simple.Name = "Btn_Agregar_Anotacion_Simple"
        Me.Btn_Agregar_Anotacion_Simple.Text = "Agregar anotación/evento simple"
        '
        'Btn_Agregar_Anotacion_Tabulada
        '
        Me.Btn_Agregar_Anotacion_Tabulada.Image = CType(resources.GetObject("Btn_Agregar_Anotacion_Tabulada.Image"), System.Drawing.Image)
        Me.Btn_Agregar_Anotacion_Tabulada.Name = "Btn_Agregar_Anotacion_Tabulada"
        Me.Btn_Agregar_Anotacion_Tabulada.Text = "Agregar anotación/evento tabulada"
        '
        'Btn_Agregar_Anotacion_Link
        '
        Me.Btn_Agregar_Anotacion_Link.Image = CType(resources.GetObject("Btn_Agregar_Anotacion_Link.Image"), System.Drawing.Image)
        Me.Btn_Agregar_Anotacion_Link.Name = "Btn_Agregar_Anotacion_Link"
        Me.Btn_Agregar_Anotacion_Link.Text = "Estableser un link (Archivo)"
        '
        'Btn_Ligar_traza_externa
        '
        Me.Btn_Ligar_traza_externa.Image = CType(resources.GetObject("Btn_Ligar_traza_externa.Image"), System.Drawing.Image)
        Me.Btn_Ligar_traza_externa.Name = "Btn_Ligar_traza_externa"
        Me.Btn_Ligar_traza_externa.Text = "Ligar traza con documento externo"
        '
        'Grilla
        '
        Me.Grilla.AllowUserToAddRows = False
        Me.Grilla.AllowUserToDeleteRows = False
        Me.Grilla.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.Grilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.White
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
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.Grilla.RowHeadersVisible = False
        Me.Grilla.RowTemplate.Height = 25
        Me.Grilla.Size = New System.Drawing.Size(839, 346)
        Me.Grilla.TabIndex = 41
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Agregar_Anotacion, Me.Btn_Exportar_a_Excel})
        Me.Bar1.Location = New System.Drawing.Point(0, 392)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(865, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 40
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'Btn_Agregar_Anotacion
        '
        Me.Btn_Agregar_Anotacion.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Agregar_Anotacion.ForeColor = System.Drawing.Color.Black
        Me.Btn_Agregar_Anotacion.Image = CType(resources.GetObject("Btn_Agregar_Anotacion.Image"), System.Drawing.Image)
        Me.Btn_Agregar_Anotacion.Name = "Btn_Agregar_Anotacion"
        Me.Btn_Agregar_Anotacion.Text = "Agregar anotaciones"
        '
        'Btn_Exportar_a_Excel
        '
        Me.Btn_Exportar_a_Excel.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Exportar_a_Excel.ForeColor = System.Drawing.Color.Black
        Me.Btn_Exportar_a_Excel.Image = CType(resources.GetObject("Btn_Exportar_a_Excel.Image"), System.Drawing.Image)
        Me.Btn_Exportar_a_Excel.Name = "Btn_Exportar_a_Excel"
        Me.Btn_Exportar_a_Excel.Tooltip = "Exportar Excel"
        '
        'Frm_Anotaciones_Ver_Anotaciones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(865, 433)
        Me.Controls.Add(Me.Bar1)
        Me.Controls.Add(Me.GroupPanel1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Anotaciones_Ver_Anotaciones"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Nomina de ventos asociados"
        Me.GroupPanel1.ResumeLayout(False)
        CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents Btn_Agregar_Anotacion As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Exportar_a_Excel As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ContextMenuBar1 As DevComponents.DotNetBar.ContextMenuBar
    Friend WithEvents Menu_Contextual_01 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Editar_Anotacion_Evento As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Eliminar_tabla As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Opciones_Link As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Ir_Ubicacion_Link As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Ver_Link As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Ver_Documento As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Menu_Contextual_02 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Agregar_Anotacion_Simple As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Agregar_Anotacion_Tabulada As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Agregar_Anotacion_Link As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Ligar_traza_externa As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Ver_Anotacion As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Grilla As DevComponents.DotNetBar.Controls.DataGridViewX
End Class
