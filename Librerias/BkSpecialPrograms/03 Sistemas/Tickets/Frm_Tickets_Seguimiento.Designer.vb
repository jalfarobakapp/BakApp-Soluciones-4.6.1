<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Tickets_Seguimiento
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Tickets_Seguimiento))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Menu_Contextual = New DevComponents.DotNetBar.ContextMenuBar()
        Me.Menu_Contextual_01 = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_EditarFuncionario = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_QuitarVendedor = New DevComponents.DotNetBar.ButtonItem()
        Me.Grilla_Acciones = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.GrupoTicket = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Lbl_FUlt_Respuesta = New DevComponents.DotNetBar.LabelX()
        Me.Lbl_FUlt_Mensaje = New DevComponents.DotNetBar.LabelX()
        Me.Lbl_Tipo = New DevComponents.DotNetBar.LabelX()
        Me.Lbl_FechaCreacion = New DevComponents.DotNetBar.LabelX()
        Me.Lbl_Area = New DevComponents.DotNetBar.LabelX()
        Me.Lbl_Estado = New DevComponents.DotNetBar.LabelX()
        Me.LabelX6 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.Bar2 = New DevComponents.DotNetBar.Bar()
        Me.Btn_MensajeRespuesta = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_CambiarEstado = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Eliminar = New DevComponents.DotNetBar.ButtonItem()
        Me.Txt_Descripcion = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.GroupPanel3 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.LabelX7 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_Producto = New DevComponents.DotNetBar.LabelX()
        Me.GroupPanel1.SuspendLayout()
        CType(Me.Menu_Contextual, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Grilla_Acciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrupoTicket.SuspendLayout()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupPanel1
        '
        Me.GroupPanel1.BackColor = System.Drawing.Color.White
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.Menu_Contextual)
        Me.GroupPanel1.Controls.Add(Me.Grilla_Acciones)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Location = New System.Drawing.Point(12, 151)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(667, 252)
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
        Me.GroupPanel1.TabIndex = 161
        Me.GroupPanel1.Text = "Historia"
        '
        'Menu_Contextual
        '
        Me.Menu_Contextual.AntiAlias = True
        Me.Menu_Contextual.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Menu_Contextual.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Menu_Contextual_01})
        Me.Menu_Contextual.Location = New System.Drawing.Point(27, 23)
        Me.Menu_Contextual.Name = "Menu_Contextual"
        Me.Menu_Contextual.Size = New System.Drawing.Size(411, 25)
        Me.Menu_Contextual.Stretch = True
        Me.Menu_Contextual.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Menu_Contextual.TabIndex = 48
        Me.Menu_Contextual.TabStop = False
        Me.Menu_Contextual.Text = "ContextMenuBar1"
        '
        'Menu_Contextual_01
        '
        Me.Menu_Contextual_01.AutoExpandOnClick = True
        Me.Menu_Contextual_01.Name = "Menu_Contextual_01"
        Me.Menu_Contextual_01.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_EditarFuncionario, Me.Btn_QuitarVendedor})
        Me.Menu_Contextual_01.Text = "Opciones"
        '
        'Btn_EditarFuncionario
        '
        Me.Btn_EditarFuncionario.Image = CType(resources.GetObject("Btn_EditarFuncionario.Image"), System.Drawing.Image)
        Me.Btn_EditarFuncionario.ImageAlt = CType(resources.GetObject("Btn_EditarFuncionario.ImageAlt"), System.Drawing.Image)
        Me.Btn_EditarFuncionario.Name = "Btn_EditarFuncionario"
        Me.Btn_EditarFuncionario.Text = "Editar funcionario"
        '
        'Btn_QuitarVendedor
        '
        Me.Btn_QuitarVendedor.Image = CType(resources.GetObject("Btn_QuitarVendedor.Image"), System.Drawing.Image)
        Me.Btn_QuitarVendedor.ImageAlt = CType(resources.GetObject("Btn_QuitarVendedor.ImageAlt"), System.Drawing.Image)
        Me.Btn_QuitarVendedor.Name = "Btn_QuitarVendedor"
        Me.Btn_QuitarVendedor.Text = "Quitar vendedor"
        '
        'Grilla_Acciones
        '
        Me.Grilla_Acciones.AllowUserToAddRows = False
        Me.Grilla_Acciones.AllowUserToDeleteRows = False
        Me.Grilla_Acciones.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla_Acciones.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.Grilla_Acciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Grilla_Acciones.DefaultCellStyle = DataGridViewCellStyle2
        Me.Grilla_Acciones.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grilla_Acciones.EnableHeadersVisualStyles = False
        Me.Grilla_Acciones.GridColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.Grilla_Acciones.Location = New System.Drawing.Point(0, 0)
        Me.Grilla_Acciones.Name = "Grilla_Acciones"
        Me.Grilla_Acciones.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla_Acciones.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.Grilla_Acciones.Size = New System.Drawing.Size(661, 229)
        Me.Grilla_Acciones.StandardTab = True
        Me.Grilla_Acciones.TabIndex = 27
        '
        'GrupoTicket
        '
        Me.GrupoTicket.BackColor = System.Drawing.Color.White
        Me.GrupoTicket.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GrupoTicket.Controls.Add(Me.Txt_Producto)
        Me.GrupoTicket.Controls.Add(Me.LabelX7)
        Me.GrupoTicket.Controls.Add(Me.Lbl_FUlt_Respuesta)
        Me.GrupoTicket.Controls.Add(Me.Lbl_FUlt_Mensaje)
        Me.GrupoTicket.Controls.Add(Me.Lbl_Tipo)
        Me.GrupoTicket.Controls.Add(Me.Lbl_FechaCreacion)
        Me.GrupoTicket.Controls.Add(Me.Lbl_Area)
        Me.GrupoTicket.Controls.Add(Me.Lbl_Estado)
        Me.GrupoTicket.Controls.Add(Me.LabelX6)
        Me.GrupoTicket.Controls.Add(Me.LabelX5)
        Me.GrupoTicket.Controls.Add(Me.LabelX4)
        Me.GrupoTicket.Controls.Add(Me.LabelX3)
        Me.GrupoTicket.Controls.Add(Me.LabelX2)
        Me.GrupoTicket.Controls.Add(Me.LabelX1)
        Me.GrupoTicket.DisabledBackColor = System.Drawing.Color.Empty
        Me.GrupoTicket.Location = New System.Drawing.Point(12, 5)
        Me.GrupoTicket.Name = "GrupoTicket"
        Me.GrupoTicket.Size = New System.Drawing.Size(667, 140)
        '
        '
        '
        Me.GrupoTicket.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.GrupoTicket.Style.BackColorGradientAngle = 90
        Me.GrupoTicket.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.GrupoTicket.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GrupoTicket.Style.BorderBottomWidth = 1
        Me.GrupoTicket.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GrupoTicket.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GrupoTicket.Style.BorderLeftWidth = 1
        Me.GrupoTicket.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GrupoTicket.Style.BorderRightWidth = 1
        Me.GrupoTicket.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GrupoTicket.Style.BorderTopWidth = 1
        Me.GrupoTicket.Style.CornerDiameter = 4
        Me.GrupoTicket.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GrupoTicket.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GrupoTicket.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GrupoTicket.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GrupoTicket.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GrupoTicket.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GrupoTicket.TabIndex = 162
        Me.GrupoTicket.Text = "Ticket"
        '
        'Lbl_FUlt_Respuesta
        '
        Me.Lbl_FUlt_Respuesta.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_FUlt_Respuesta.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_FUlt_Respuesta.ForeColor = System.Drawing.Color.Black
        Me.Lbl_FUlt_Respuesta.Location = New System.Drawing.Point(396, 61)
        Me.Lbl_FUlt_Respuesta.Name = "Lbl_FUlt_Respuesta"
        Me.Lbl_FUlt_Respuesta.Size = New System.Drawing.Size(153, 23)
        Me.Lbl_FUlt_Respuesta.TabIndex = 12
        Me.Lbl_FUlt_Respuesta.Text = "Tipo"
        '
        'Lbl_FUlt_Mensaje
        '
        Me.Lbl_FUlt_Mensaje.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_FUlt_Mensaje.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_FUlt_Mensaje.ForeColor = System.Drawing.Color.Black
        Me.Lbl_FUlt_Mensaje.Location = New System.Drawing.Point(396, 32)
        Me.Lbl_FUlt_Mensaje.Name = "Lbl_FUlt_Mensaje"
        Me.Lbl_FUlt_Mensaje.Size = New System.Drawing.Size(153, 23)
        Me.Lbl_FUlt_Mensaje.TabIndex = 11
        Me.Lbl_FUlt_Mensaje.Text = "Tipo"
        '
        'Lbl_Tipo
        '
        Me.Lbl_Tipo.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_Tipo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Tipo.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Tipo.Location = New System.Drawing.Point(396, 3)
        Me.Lbl_Tipo.Name = "Lbl_Tipo"
        Me.Lbl_Tipo.Size = New System.Drawing.Size(153, 23)
        Me.Lbl_Tipo.TabIndex = 10
        Me.Lbl_Tipo.Text = "Tipo"
        '
        'Lbl_FechaCreacion
        '
        Me.Lbl_FechaCreacion.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_FechaCreacion.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_FechaCreacion.ForeColor = System.Drawing.Color.Black
        Me.Lbl_FechaCreacion.Location = New System.Drawing.Point(117, 61)
        Me.Lbl_FechaCreacion.Name = "Lbl_FechaCreacion"
        Me.Lbl_FechaCreacion.Size = New System.Drawing.Size(177, 23)
        Me.Lbl_FechaCreacion.TabIndex = 9
        Me.Lbl_FechaCreacion.Text = "Tipo"
        '
        'Lbl_Area
        '
        Me.Lbl_Area.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_Area.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Area.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Area.Location = New System.Drawing.Point(117, 32)
        Me.Lbl_Area.Name = "Lbl_Area"
        Me.Lbl_Area.Size = New System.Drawing.Size(177, 23)
        Me.Lbl_Area.TabIndex = 8
        Me.Lbl_Area.Text = "Tipo"
        '
        'Lbl_Estado
        '
        Me.Lbl_Estado.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_Estado.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Estado.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Estado.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Estado.Location = New System.Drawing.Point(117, 3)
        Me.Lbl_Estado.Name = "Lbl_Estado"
        Me.Lbl_Estado.Size = New System.Drawing.Size(123, 23)
        Me.Lbl_Estado.TabIndex = 7
        Me.Lbl_Estado.Text = "Tipo"
        '
        'LabelX6
        '
        Me.LabelX6.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX6.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX6.ForeColor = System.Drawing.Color.Black
        Me.LabelX6.Location = New System.Drawing.Point(301, 61)
        Me.LabelX6.Name = "LabelX6"
        Me.LabelX6.Size = New System.Drawing.Size(89, 23)
        Me.LabelX6.TabIndex = 5
        Me.LabelX6.Text = "Última respuesta"
        '
        'LabelX5
        '
        Me.LabelX5.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX5.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX5.ForeColor = System.Drawing.Color.Black
        Me.LabelX5.Location = New System.Drawing.Point(301, 32)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.Size = New System.Drawing.Size(89, 23)
        Me.LabelX5.TabIndex = 4
        Me.LabelX5.Text = "Ultimo mensaje"
        '
        'LabelX4
        '
        Me.LabelX4.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX4.ForeColor = System.Drawing.Color.Black
        Me.LabelX4.Location = New System.Drawing.Point(301, 3)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(114, 23)
        Me.LabelX4.TabIndex = 3
        Me.LabelX4.Text = "Tipo"
        '
        'LabelX3
        '
        Me.LabelX3.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX3.ForeColor = System.Drawing.Color.Black
        Me.LabelX3.Location = New System.Drawing.Point(3, 61)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(114, 23)
        Me.LabelX3.TabIndex = 2
        Me.LabelX3.Text = "Fecha de creación"
        '
        'LabelX2
        '
        Me.LabelX2.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX2.ForeColor = System.Drawing.Color.Black
        Me.LabelX2.Location = New System.Drawing.Point(3, 32)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(114, 23)
        Me.LabelX2.TabIndex = 1
        Me.LabelX2.Text = "Area/Departamento"
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX1.ForeColor = System.Drawing.Color.Black
        Me.LabelX1.Location = New System.Drawing.Point(3, 3)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(75, 23)
        Me.LabelX1.TabIndex = 0
        Me.LabelX1.Text = "Estado"
        '
        'Bar2
        '
        Me.Bar2.AntiAlias = True
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_MensajeRespuesta, Me.Btn_CambiarEstado, Me.Btn_Eliminar})
        Me.Bar2.Location = New System.Drawing.Point(0, 536)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(689, 41)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Bar2.TabIndex = 165
        Me.Bar2.TabStop = False
        Me.Bar2.Text = "Bar2"
        '
        'Btn_MensajeRespuesta
        '
        Me.Btn_MensajeRespuesta.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_MensajeRespuesta.ForeColor = System.Drawing.Color.Black
        Me.Btn_MensajeRespuesta.Image = CType(resources.GetObject("Btn_MensajeRespuesta.Image"), System.Drawing.Image)
        Me.Btn_MensajeRespuesta.ImageAlt = CType(resources.GetObject("Btn_MensajeRespuesta.ImageAlt"), System.Drawing.Image)
        Me.Btn_MensajeRespuesta.Name = "Btn_MensajeRespuesta"
        Me.Btn_MensajeRespuesta.Text = "Agregar mensaje"
        '
        'Btn_CambiarEstado
        '
        Me.Btn_CambiarEstado.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_CambiarEstado.ForeColor = System.Drawing.Color.Black
        Me.Btn_CambiarEstado.Image = CType(resources.GetObject("Btn_CambiarEstado.Image"), System.Drawing.Image)
        Me.Btn_CambiarEstado.ImageAlt = CType(resources.GetObject("Btn_CambiarEstado.ImageAlt"), System.Drawing.Image)
        Me.Btn_CambiarEstado.Name = "Btn_CambiarEstado"
        Me.Btn_CambiarEstado.Text = "Cambiar Estado"
        '
        'Btn_Eliminar
        '
        Me.Btn_Eliminar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Eliminar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Eliminar.Image = CType(resources.GetObject("Btn_Eliminar.Image"), System.Drawing.Image)
        Me.Btn_Eliminar.ImageAlt = CType(resources.GetObject("Btn_Eliminar.ImageAlt"), System.Drawing.Image)
        Me.Btn_Eliminar.Name = "Btn_Eliminar"
        Me.Btn_Eliminar.Tooltip = "Eliminar comisión"
        '
        'Txt_Descripcion
        '
        Me.Txt_Descripcion.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Descripcion.Border.Class = "TextBoxBorder"
        Me.Txt_Descripcion.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Descripcion.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Descripcion.ForeColor = System.Drawing.Color.Black
        Me.Txt_Descripcion.Location = New System.Drawing.Point(3, 3)
        Me.Txt_Descripcion.MaxLength = 30
        Me.Txt_Descripcion.Multiline = True
        Me.Txt_Descripcion.Name = "Txt_Descripcion"
        Me.Txt_Descripcion.PreventEnterBeep = True
        Me.Txt_Descripcion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.Txt_Descripcion.Size = New System.Drawing.Size(655, 73)
        Me.Txt_Descripcion.TabIndex = 166
        '
        'GroupPanel3
        '
        Me.GroupPanel3.BackColor = System.Drawing.Color.White
        Me.GroupPanel3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel3.Controls.Add(Me.Txt_Descripcion)
        Me.GroupPanel3.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel3.Location = New System.Drawing.Point(12, 409)
        Me.GroupPanel3.Name = "GroupPanel3"
        Me.GroupPanel3.Size = New System.Drawing.Size(667, 106)
        '
        '
        '
        Me.GroupPanel3.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.GroupPanel3.Style.BackColorGradientAngle = 90
        Me.GroupPanel3.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.GroupPanel3.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel3.Style.BorderBottomWidth = 1
        Me.GroupPanel3.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupPanel3.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel3.Style.BorderLeftWidth = 1
        Me.GroupPanel3.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel3.Style.BorderRightWidth = 1
        Me.GroupPanel3.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel3.Style.BorderTopWidth = 1
        Me.GroupPanel3.Style.CornerDiameter = 4
        Me.GroupPanel3.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanel3.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanel3.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GroupPanel3.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupPanel3.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanel3.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanel3.TabIndex = 168
        Me.GroupPanel3.Text = "Descripción..."
        '
        'LabelX7
        '
        Me.LabelX7.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX7.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX7.ForeColor = System.Drawing.Color.Black
        Me.LabelX7.Location = New System.Drawing.Point(3, 90)
        Me.LabelX7.Name = "LabelX7"
        Me.LabelX7.Size = New System.Drawing.Size(114, 23)
        Me.LabelX7.TabIndex = 13
        Me.LabelX7.Text = "Producto"
        '
        'Txt_Producto
        '
        Me.Txt_Producto.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Txt_Producto.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Producto.ForeColor = System.Drawing.Color.Black
        Me.Txt_Producto.Location = New System.Drawing.Point(117, 90)
        Me.Txt_Producto.Name = "Txt_Producto"
        Me.Txt_Producto.Size = New System.Drawing.Size(541, 23)
        Me.Txt_Producto.TabIndex = 14
        Me.Txt_Producto.Text = "Tipo"
        '
        'Frm_Tickets_Seguimiento
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(689, 577)
        Me.Controls.Add(Me.GroupPanel3)
        Me.Controls.Add(Me.Bar2)
        Me.Controls.Add(Me.GrupoTicket)
        Me.Controls.Add(Me.GroupPanel1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Tickets_Seguimiento"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MetroForm"
        Me.GroupPanel1.ResumeLayout(False)
        CType(Me.Menu_Contextual, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Grilla_Acciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrupoTicket.ResumeLayout(False)
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Menu_Contextual As DevComponents.DotNetBar.ContextMenuBar
    Friend WithEvents Menu_Contextual_01 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_EditarFuncionario As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_QuitarVendedor As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Grilla_Acciones As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents GrupoTicket As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents LabelX6 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Lbl_FUlt_Respuesta As DevComponents.DotNetBar.LabelX
    Friend WithEvents Lbl_FUlt_Mensaje As DevComponents.DotNetBar.LabelX
    Friend WithEvents Lbl_Tipo As DevComponents.DotNetBar.LabelX
    Friend WithEvents Lbl_FechaCreacion As DevComponents.DotNetBar.LabelX
    Friend WithEvents Lbl_Area As DevComponents.DotNetBar.LabelX
    Friend WithEvents Lbl_Estado As DevComponents.DotNetBar.LabelX
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents Btn_Eliminar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_CambiarEstado As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Txt_Descripcion As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents GroupPanel3 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Btn_MensajeRespuesta As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Txt_Producto As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX7 As DevComponents.DotNetBar.LabelX
End Class
