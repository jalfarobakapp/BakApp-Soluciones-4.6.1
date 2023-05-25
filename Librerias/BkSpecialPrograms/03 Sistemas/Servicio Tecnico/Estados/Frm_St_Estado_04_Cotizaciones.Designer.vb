<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_St_Estado_04_Cotizaciones
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_St_Estado_04_Cotizaciones))
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.ContextMenuBar1 = New DevComponents.DotNetBar.ContextMenuBar()
        Me.Menu_Contextual_Accion = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Presupues_Aceptado = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Presupuesto_Rechazado = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Presupuestos_Evaluacion = New DevComponents.DotNetBar.ButtonItem()
        Me.Menu_Contextual_Ver_Quitar = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Ver_documento = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Correo_Outlook = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Quitar_documento = New DevComponents.DotNetBar.ButtonItem()
        Me.Menu_Contextual_COV = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_AgregarCOVExistente = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_CrearCOVdesdePresupuesto = New DevComponents.DotNetBar.ButtonItem()
        Me.Grilla = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.Bar2 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Fijar_Estado = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_EditarPresupuesto = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Agregar_Cotizacion = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Editar = New DevComponents.DotNetBar.ButtonItem()
        Me.GroupPanel2 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Txt_Nota = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Chk_No_Existe_COV_Ni_NVV = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Highlighter1 = New DevComponents.DotNetBar.Validator.Highlighter()
        Me.GroupPanel1.SuspendLayout()
        CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel2.SuspendLayout()
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
        Me.GroupPanel1.Size = New System.Drawing.Size(506, 149)
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
        Me.GroupPanel1.TabIndex = 97
        Me.GroupPanel1.Text = "Cotizaciones"
        '
        'ContextMenuBar1
        '
        Me.ContextMenuBar1.AntiAlias = True
        Me.ContextMenuBar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ContextMenuBar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Menu_Contextual_Accion, Me.Menu_Contextual_Ver_Quitar, Me.Menu_Contextual_COV})
        Me.ContextMenuBar1.Location = New System.Drawing.Point(22, 20)
        Me.ContextMenuBar1.Name = "ContextMenuBar1"
        Me.ContextMenuBar1.Size = New System.Drawing.Size(428, 25)
        Me.ContextMenuBar1.Stretch = True
        Me.ContextMenuBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ContextMenuBar1.TabIndex = 47
        Me.ContextMenuBar1.TabStop = False
        Me.ContextMenuBar1.Text = "ContextMenuBar1"
        '
        'Menu_Contextual_Accion
        '
        Me.Menu_Contextual_Accion.AutoExpandOnClick = True
        Me.Menu_Contextual_Accion.Name = "Menu_Contextual_Accion"
        Me.Menu_Contextual_Accion.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Presupues_Aceptado, Me.Btn_Presupuesto_Rechazado, Me.Btn_Presupuestos_Evaluacion})
        Me.Menu_Contextual_Accion.Text = "Opciones encabezado"
        '
        'Btn_Presupues_Aceptado
        '
        Me.Btn_Presupues_Aceptado.Image = CType(resources.GetObject("Btn_Presupues_Aceptado.Image"), System.Drawing.Image)
        Me.Btn_Presupues_Aceptado.ImageAlt = CType(resources.GetObject("Btn_Presupues_Aceptado.ImageAlt"), System.Drawing.Image)
        Me.Btn_Presupues_Aceptado.Name = "Btn_Presupues_Aceptado"
        Me.Btn_Presupues_Aceptado.Text = "Aceptado"
        '
        'Btn_Presupuesto_Rechazado
        '
        Me.Btn_Presupuesto_Rechazado.Image = CType(resources.GetObject("Btn_Presupuesto_Rechazado.Image"), System.Drawing.Image)
        Me.Btn_Presupuesto_Rechazado.ImageAlt = CType(resources.GetObject("Btn_Presupuesto_Rechazado.ImageAlt"), System.Drawing.Image)
        Me.Btn_Presupuesto_Rechazado.Name = "Btn_Presupuesto_Rechazado"
        Me.Btn_Presupuesto_Rechazado.Text = "Rechazado"
        '
        'Btn_Presupuestos_Evaluacion
        '
        Me.Btn_Presupuestos_Evaluacion.Image = CType(resources.GetObject("Btn_Presupuestos_Evaluacion.Image"), System.Drawing.Image)
        Me.Btn_Presupuestos_Evaluacion.ImageAlt = CType(resources.GetObject("Btn_Presupuestos_Evaluacion.ImageAlt"), System.Drawing.Image)
        Me.Btn_Presupuestos_Evaluacion.Name = "Btn_Presupuestos_Evaluacion"
        Me.Btn_Presupuestos_Evaluacion.Text = "volver a dejar en evaluación"
        '
        'Menu_Contextual_Ver_Quitar
        '
        Me.Menu_Contextual_Ver_Quitar.AutoExpandOnClick = True
        Me.Menu_Contextual_Ver_Quitar.Name = "Menu_Contextual_Ver_Quitar"
        Me.Menu_Contextual_Ver_Quitar.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Ver_documento, Me.Btn_Correo_Outlook, Me.Btn_Quitar_documento})
        Me.Menu_Contextual_Ver_Quitar.Text = "Opciones Ver/Quitar"
        '
        'Btn_Ver_documento
        '
        Me.Btn_Ver_documento.Image = CType(resources.GetObject("Btn_Ver_documento.Image"), System.Drawing.Image)
        Me.Btn_Ver_documento.ImageAlt = CType(resources.GetObject("Btn_Ver_documento.ImageAlt"), System.Drawing.Image)
        Me.Btn_Ver_documento.Name = "Btn_Ver_documento"
        Me.Btn_Ver_documento.Text = "Ver documento"
        '
        'Btn_Correo_Outlook
        '
        Me.Btn_Correo_Outlook.Image = CType(resources.GetObject("Btn_Correo_Outlook.Image"), System.Drawing.Image)
        Me.Btn_Correo_Outlook.Name = "Btn_Correo_Outlook"
        Me.Btn_Correo_Outlook.Text = "Armar correo solo para Outlook"
        '
        'Btn_Quitar_documento
        '
        Me.Btn_Quitar_documento.Image = CType(resources.GetObject("Btn_Quitar_documento.Image"), System.Drawing.Image)
        Me.Btn_Quitar_documento.ImageAlt = CType(resources.GetObject("Btn_Quitar_documento.ImageAlt"), System.Drawing.Image)
        Me.Btn_Quitar_documento.Name = "Btn_Quitar_documento"
        Me.Btn_Quitar_documento.Text = "Quitar documento de la lista"
        '
        'Menu_Contextual_COV
        '
        Me.Menu_Contextual_COV.AutoExpandOnClick = True
        Me.Menu_Contextual_COV.Name = "Menu_Contextual_COV"
        Me.Menu_Contextual_COV.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_AgregarCOVExistente, Me.Btn_CrearCOVdesdePresupuesto})
        Me.Menu_Contextual_COV.Text = "Opciones cotizacion"
        '
        'Btn_AgregarCOVExistente
        '
        Me.Btn_AgregarCOVExistente.Name = "Btn_AgregarCOVExistente"
        Me.Btn_AgregarCOVExistente.Text = "Agregar cotizacion existente"
        '
        'Btn_CrearCOVdesdePresupuesto
        '
        Me.Btn_CrearCOVdesdePresupuesto.Name = "Btn_CrearCOVdesdePresupuesto"
        Me.Btn_CrearCOVdesdePresupuesto.Text = "Crear cotizacion a partir del presupuesto"
        '
        'Grilla
        '
        Me.Grilla.AllowUserToAddRows = False
        Me.Grilla.AllowUserToDeleteRows = False
        Me.Grilla.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.Grilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Grilla.DefaultCellStyle = DataGridViewCellStyle8
        Me.Grilla.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grilla.EnableHeadersVisualStyles = False
        Me.Grilla.GridColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.Grilla.Location = New System.Drawing.Point(0, 0)
        Me.Grilla.MultiSelect = False
        Me.Grilla.Name = "Grilla"
        Me.Grilla.ReadOnly = True
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla.RowHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.Grilla.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.Grilla.Size = New System.Drawing.Size(500, 126)
        Me.Grilla.TabIndex = 1
        '
        'Bar2
        '
        Me.Bar2.AntiAlias = True
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Fijar_Estado, Me.Btn_EditarPresupuesto, Me.Btn_Agregar_Cotizacion, Me.Btn_Editar})
        Me.Bar2.Location = New System.Drawing.Point(0, 264)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(530, 41)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Bar2.TabIndex = 96
        Me.Bar2.TabStop = False
        Me.Bar2.Text = "Bar2"
        '
        'Btn_Fijar_Estado
        '
        Me.Btn_Fijar_Estado.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Fijar_Estado.ForeColor = System.Drawing.Color.Black
        Me.Btn_Fijar_Estado.Image = CType(resources.GetObject("Btn_Fijar_Estado.Image"), System.Drawing.Image)
        Me.Btn_Fijar_Estado.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Center
        Me.Btn_Fijar_Estado.Name = "Btn_Fijar_Estado"
        Me.Btn_Fijar_Estado.Text = "Fijar Estado"
        Me.Btn_Fijar_Estado.Visible = False
        '
        'Btn_EditarPresupuesto
        '
        Me.Btn_EditarPresupuesto.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_EditarPresupuesto.ForeColor = System.Drawing.Color.Black
        Me.Btn_EditarPresupuesto.Image = CType(resources.GetObject("Btn_EditarPresupuesto.Image"), System.Drawing.Image)
        Me.Btn_EditarPresupuesto.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Center
        Me.Btn_EditarPresupuesto.Name = "Btn_EditarPresupuesto"
        Me.Btn_EditarPresupuesto.Text = "Editar presupuesto"
        Me.Btn_EditarPresupuesto.Visible = False
        '
        'Btn_Agregar_Cotizacion
        '
        Me.Btn_Agregar_Cotizacion.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Agregar_Cotizacion.ForeColor = System.Drawing.Color.Black
        Me.Btn_Agregar_Cotizacion.Image = CType(resources.GetObject("Btn_Agregar_Cotizacion.Image"), System.Drawing.Image)
        Me.Btn_Agregar_Cotizacion.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.Btn_Agregar_Cotizacion.Name = "Btn_Agregar_Cotizacion"
        Me.Btn_Agregar_Cotizacion.Tooltip = "Agregar cotizacion"
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
        'GroupPanel2
        '
        Me.GroupPanel2.BackColor = System.Drawing.Color.White
        Me.GroupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel2.Controls.Add(Me.Txt_Nota)
        Me.GroupPanel2.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel2.Location = New System.Drawing.Point(12, 191)
        Me.GroupPanel2.Name = "GroupPanel2"
        Me.GroupPanel2.Size = New System.Drawing.Size(503, 53)
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
        Me.GroupPanel2.TabIndex = 98
        Me.GroupPanel2.Text = "Nota"
        '
        'Txt_Nota
        '
        '
        '
        '
        Me.Txt_Nota.Border.Class = "TextBoxBorder"
        Me.Txt_Nota.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Nota.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_Nota.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Nota.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Txt_Nota.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Nota.ForeColor = System.Drawing.Color.Black
        Me.Highlighter1.SetHighlightOnFocus(Me.Txt_Nota, True)
        Me.Txt_Nota.Location = New System.Drawing.Point(6, 3)
        Me.Txt_Nota.MaxLength = 300
        Me.Txt_Nota.Name = "Txt_Nota"
        Me.Txt_Nota.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.Txt_Nota.Size = New System.Drawing.Size(488, 22)
        Me.Txt_Nota.TabIndex = 64
        '
        'Chk_No_Existe_COV_Ni_NVV
        '
        Me.Chk_No_Existe_COV_Ni_NVV.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_No_Existe_COV_Ni_NVV.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_No_Existe_COV_Ni_NVV.ForeColor = System.Drawing.Color.Black
        Me.Chk_No_Existe_COV_Ni_NVV.Location = New System.Drawing.Point(12, 167)
        Me.Chk_No_Existe_COV_Ni_NVV.Name = "Chk_No_Existe_COV_Ni_NVV"
        Me.Chk_No_Existe_COV_Ni_NVV.Size = New System.Drawing.Size(453, 18)
        Me.Chk_No_Existe_COV_Ni_NVV.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_No_Existe_COV_Ni_NVV.TabIndex = 104
        Me.Chk_No_Existe_COV_Ni_NVV.Text = "NO EXISTE COTIZACION NI NOTA DE VENTA"
        '
        'Highlighter1
        '
        Me.Highlighter1.ContainerControl = Me
        Me.Highlighter1.FocusHighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red
        Me.Highlighter1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        '
        'Frm_St_Estado_04_Cotizaciones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(530, 305)
        Me.Controls.Add(Me.Chk_No_Existe_COV_Ni_NVV)
        Me.Controls.Add(Me.GroupPanel2)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Controls.Add(Me.Bar2)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_St_Estado_04_Cotizaciones"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cotizaciones asociadas a la Orden de Trabajo"
        Me.GroupPanel1.ResumeLayout(False)
        CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Grilla As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents Btn_Agregar_Cotizacion As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ContextMenuBar1 As DevComponents.DotNetBar.ContextMenuBar
    Friend WithEvents Menu_Contextual_Accion As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Presupues_Aceptado As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Presupuesto_Rechazado As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Presupuestos_Evaluacion As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Fijar_Estado As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents GroupPanel2 As DevComponents.DotNetBar.Controls.GroupPanel
    Public WithEvents Txt_Nota As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Menu_Contextual_Ver_Quitar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Ver_documento As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Quitar_documento As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_Editar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Chk_No_Existe_COV_Ni_NVV As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Btn_Correo_Outlook As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Menu_Contextual_COV As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_AgregarCOVExistente As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_CrearCOVdesdePresupuesto As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_EditarPresupuesto As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Highlighter1 As DevComponents.DotNetBar.Validator.Highlighter
End Class
