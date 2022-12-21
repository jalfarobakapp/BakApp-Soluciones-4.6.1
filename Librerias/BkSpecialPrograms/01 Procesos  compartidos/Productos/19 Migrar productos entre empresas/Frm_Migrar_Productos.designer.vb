<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Frm_Migrar_Productos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Migrar_Productos))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Btn_Config_Impresora_Diablito = New DevComponents.DotNetBar.ButtonItem()
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Btn_Buscar = New System.Windows.Forms.Button()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_KOPR = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.GroupPanel2 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Btn_Configurar = New System.Windows.Forms.Button()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_Server = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.GroupPanel3 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Grilla_Productos = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.Btn_Migrar = New System.Windows.Forms.Button()
        Me.Btn_Productos_Local = New System.Windows.Forms.Button()
        Me.Btn_Productos_Ext = New System.Windows.Forms.Button()
        Me.Btn_Campos = New System.Windows.Forms.Button()
        Me.Btn_Tablas = New System.Windows.Forms.Button()
        Me.Lbl_Progreso_Tablas = New System.Windows.Forms.Label()
        Me.Lbl_Progreso_Campos = New System.Windows.Forms.Label()
        Me.Progreso_Tablas = New System.Windows.Forms.ProgressBar()
        Me.Progreso_Campos = New System.Windows.Forms.ProgressBar()
        Me.Btn_Cancelar_Tablas = New System.Windows.Forms.Button()
        Me.Btn_Cancelar_Campos = New System.Windows.Forms.Button()
        Me.GroupPanel1.SuspendLayout()
        Me.GroupPanel2.SuspendLayout()
        Me.GroupPanel3.SuspendLayout()
        CType(Me.Grilla_Productos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Btn_Config_Impresora_Diablito
        '
        Me.Btn_Config_Impresora_Diablito.Image = CType(resources.GetObject("Btn_Config_Impresora_Diablito.Image"), System.Drawing.Image)
        Me.Btn_Config_Impresora_Diablito.Name = "Btn_Config_Impresora_Diablito"
        Me.Btn_Config_Impresora_Diablito.Text = "Impresión hacia diablito (servidor de impresiones)"
        Me.Btn_Config_Impresora_Diablito.Tooltip = "Configurar mis salidas de impresión al diablito"
        '
        'GroupPanel1
        '
        Me.GroupPanel1.BackColor = System.Drawing.Color.White
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.Btn_Buscar)
        Me.GroupPanel1.Controls.Add(Me.LabelX2)
        Me.GroupPanel1.Controls.Add(Me.Txt_KOPR)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Location = New System.Drawing.Point(8, 2)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(311, 53)
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
        Me.GroupPanel1.TabIndex = 15
        Me.GroupPanel1.Text = "Buscar producto por codigo"
        '
        'Btn_Buscar
        '
        Me.Btn_Buscar.BackColor = System.Drawing.Color.White
        Me.Btn_Buscar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Buscar.Location = New System.Drawing.Point(227, 2)
        Me.Btn_Buscar.Name = "Btn_Buscar"
        Me.Btn_Buscar.Size = New System.Drawing.Size(75, 23)
        Me.Btn_Buscar.TabIndex = 14
        Me.Btn_Buscar.Text = "Buscar"
        Me.Btn_Buscar.UseVisualStyleBackColor = False
        '
        'LabelX2
        '
        Me.LabelX2.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.ForeColor = System.Drawing.Color.Black
        Me.LabelX2.Location = New System.Drawing.Point(3, 0)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(36, 23)
        Me.LabelX2.TabIndex = 13
        Me.LabelX2.Text = "Codigo"
        '
        'Txt_KOPR
        '
        Me.Txt_KOPR.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_KOPR.Border.Class = "TextBoxBorder"
        Me.Txt_KOPR.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_KOPR.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_KOPR.FocusHighlightEnabled = True
        Me.Txt_KOPR.ForeColor = System.Drawing.Color.Black
        Me.Txt_KOPR.Location = New System.Drawing.Point(45, 3)
        Me.Txt_KOPR.Name = "Txt_KOPR"
        Me.Txt_KOPR.PreventEnterBeep = True
        Me.Txt_KOPR.Size = New System.Drawing.Size(176, 22)
        Me.Txt_KOPR.TabIndex = 2
        '
        'GroupPanel2
        '
        Me.GroupPanel2.BackColor = System.Drawing.Color.White
        Me.GroupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel2.Controls.Add(Me.Btn_Configurar)
        Me.GroupPanel2.Controls.Add(Me.LabelX1)
        Me.GroupPanel2.Controls.Add(Me.Txt_Server)
        Me.GroupPanel2.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel2.Location = New System.Drawing.Point(325, 2)
        Me.GroupPanel2.Name = "GroupPanel2"
        Me.GroupPanel2.Size = New System.Drawing.Size(285, 53)
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
        Me.GroupPanel2.TabIndex = 16
        Me.GroupPanel2.Text = "Base de datos nueva"
        '
        'Btn_Configurar
        '
        Me.Btn_Configurar.BackColor = System.Drawing.Color.White
        Me.Btn_Configurar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Configurar.Location = New System.Drawing.Point(193, 3)
        Me.Btn_Configurar.Name = "Btn_Configurar"
        Me.Btn_Configurar.Size = New System.Drawing.Size(80, 23)
        Me.Btn_Configurar.TabIndex = 14
        Me.Btn_Configurar.Text = "Configurar"
        Me.Btn_Configurar.UseVisualStyleBackColor = False
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.ForeColor = System.Drawing.Color.Black
        Me.LabelX1.Location = New System.Drawing.Point(3, 0)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(44, 23)
        Me.LabelX1.TabIndex = 13
        Me.LabelX1.Text = "Servidor"
        '
        'Txt_Server
        '
        Me.Txt_Server.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Server.Border.Class = "TextBoxBorder"
        Me.Txt_Server.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Server.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Server.Enabled = False
        Me.Txt_Server.FocusHighlightEnabled = True
        Me.Txt_Server.ForeColor = System.Drawing.Color.Black
        Me.Txt_Server.Location = New System.Drawing.Point(53, 3)
        Me.Txt_Server.Name = "Txt_Server"
        Me.Txt_Server.PreventEnterBeep = True
        Me.Txt_Server.Size = New System.Drawing.Size(134, 22)
        Me.Txt_Server.TabIndex = 2
        '
        'GroupPanel3
        '
        Me.GroupPanel3.BackColor = System.Drawing.Color.White
        Me.GroupPanel3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel3.Controls.Add(Me.Grilla_Productos)
        Me.GroupPanel3.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel3.Location = New System.Drawing.Point(8, 61)
        Me.GroupPanel3.Name = "GroupPanel3"
        Me.GroupPanel3.Size = New System.Drawing.Size(602, 114)
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
        Me.GroupPanel3.TabIndex = 52
        Me.GroupPanel3.Text = "Productos Encontrados"
        '
        'Grilla_Productos
        '
        Me.Grilla_Productos.AllowUserToAddRows = False
        Me.Grilla_Productos.AllowUserToDeleteRows = False
        Me.Grilla_Productos.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla_Productos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.Grilla_Productos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Grilla_Productos.DefaultCellStyle = DataGridViewCellStyle2
        Me.Grilla_Productos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grilla_Productos.EnableHeadersVisualStyles = False
        Me.Grilla_Productos.GridColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.Grilla_Productos.Location = New System.Drawing.Point(0, 0)
        Me.Grilla_Productos.Name = "Grilla_Productos"
        Me.Grilla_Productos.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla_Productos.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.Grilla_Productos.Size = New System.Drawing.Size(596, 91)
        Me.Grilla_Productos.StandardTab = True
        Me.Grilla_Productos.TabIndex = 28
        '
        'Btn_Migrar
        '
        Me.Btn_Migrar.BackColor = System.Drawing.Color.White
        Me.Btn_Migrar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Migrar.Location = New System.Drawing.Point(8, 272)
        Me.Btn_Migrar.Name = "Btn_Migrar"
        Me.Btn_Migrar.Size = New System.Drawing.Size(109, 50)
        Me.Btn_Migrar.TabIndex = 15
        Me.Btn_Migrar.Text = "Migrar Producto"
        Me.Btn_Migrar.UseVisualStyleBackColor = False
        '
        'Btn_Productos_Local
        '
        Me.Btn_Productos_Local.BackColor = System.Drawing.Color.White
        Me.Btn_Productos_Local.ForeColor = System.Drawing.Color.Black
        Me.Btn_Productos_Local.Location = New System.Drawing.Point(498, 237)
        Me.Btn_Productos_Local.Name = "Btn_Productos_Local"
        Me.Btn_Productos_Local.Size = New System.Drawing.Size(109, 50)
        Me.Btn_Productos_Local.TabIndex = 53
        Me.Btn_Productos_Local.Text = "Buscar Productos Faltantes en BD Local"
        Me.Btn_Productos_Local.UseVisualStyleBackColor = False
        '
        'Btn_Productos_Ext
        '
        Me.Btn_Productos_Ext.BackColor = System.Drawing.Color.White
        Me.Btn_Productos_Ext.ForeColor = System.Drawing.Color.Black
        Me.Btn_Productos_Ext.Location = New System.Drawing.Point(498, 181)
        Me.Btn_Productos_Ext.Name = "Btn_Productos_Ext"
        Me.Btn_Productos_Ext.Size = New System.Drawing.Size(109, 50)
        Me.Btn_Productos_Ext.TabIndex = 54
        Me.Btn_Productos_Ext.Text = "Buscar Productos Faltantes en BD Externa"
        Me.Btn_Productos_Ext.UseVisualStyleBackColor = False
        '
        'Btn_Campos
        '
        Me.Btn_Campos.BackColor = System.Drawing.Color.White
        Me.Btn_Campos.ForeColor = System.Drawing.Color.Black
        Me.Btn_Campos.Location = New System.Drawing.Point(238, 181)
        Me.Btn_Campos.Name = "Btn_Campos"
        Me.Btn_Campos.Size = New System.Drawing.Size(109, 68)
        Me.Btn_Campos.TabIndex = 56
        Me.Btn_Campos.Text = "Buscar Campos Faltantes en BD Ext"
        Me.Btn_Campos.UseVisualStyleBackColor = False
        '
        'Btn_Tablas
        '
        Me.Btn_Tablas.BackColor = System.Drawing.Color.White
        Me.Btn_Tablas.ForeColor = System.Drawing.Color.Black
        Me.Btn_Tablas.Location = New System.Drawing.Point(8, 181)
        Me.Btn_Tablas.Name = "Btn_Tablas"
        Me.Btn_Tablas.Size = New System.Drawing.Size(109, 68)
        Me.Btn_Tablas.TabIndex = 55
        Me.Btn_Tablas.Text = "Buscar Tablas Faltantes en BD Ext"
        Me.Btn_Tablas.UseVisualStyleBackColor = False
        '
        'Lbl_Progreso_Tablas
        '
        Me.Lbl_Progreso_Tablas.AutoSize = True
        Me.Lbl_Progreso_Tablas.BackColor = System.Drawing.Color.White
        Me.Lbl_Progreso_Tablas.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Progreso_Tablas.Location = New System.Drawing.Point(124, 181)
        Me.Lbl_Progreso_Tablas.Name = "Lbl_Progreso_Tablas"
        Me.Lbl_Progreso_Tablas.Size = New System.Drawing.Size(59, 13)
        Me.Lbl_Progreso_Tablas.TabIndex = 57
        Me.Lbl_Progreso_Tablas.Text = "Progreso: "
        '
        'Lbl_Progreso_Campos
        '
        Me.Lbl_Progreso_Campos.AutoSize = True
        Me.Lbl_Progreso_Campos.BackColor = System.Drawing.Color.White
        Me.Lbl_Progreso_Campos.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Progreso_Campos.Location = New System.Drawing.Point(353, 181)
        Me.Lbl_Progreso_Campos.Name = "Lbl_Progreso_Campos"
        Me.Lbl_Progreso_Campos.Size = New System.Drawing.Size(59, 13)
        Me.Lbl_Progreso_Campos.TabIndex = 58
        Me.Lbl_Progreso_Campos.Text = "Progreso: "
        '
        'Progreso_Tablas
        '
        Me.Progreso_Tablas.BackColor = System.Drawing.Color.White
        Me.Progreso_Tablas.ForeColor = System.Drawing.Color.Black
        Me.Progreso_Tablas.Location = New System.Drawing.Point(123, 197)
        Me.Progreso_Tablas.Name = "Progreso_Tablas"
        Me.Progreso_Tablas.Size = New System.Drawing.Size(109, 23)
        Me.Progreso_Tablas.TabIndex = 59
        '
        'Progreso_Campos
        '
        Me.Progreso_Campos.BackColor = System.Drawing.Color.White
        Me.Progreso_Campos.ForeColor = System.Drawing.Color.Black
        Me.Progreso_Campos.Location = New System.Drawing.Point(353, 197)
        Me.Progreso_Campos.Name = "Progreso_Campos"
        Me.Progreso_Campos.Size = New System.Drawing.Size(109, 23)
        Me.Progreso_Campos.TabIndex = 60
        '
        'Btn_Cancelar_Tablas
        '
        Me.Btn_Cancelar_Tablas.BackColor = System.Drawing.Color.White
        Me.Btn_Cancelar_Tablas.ForeColor = System.Drawing.Color.Black
        Me.Btn_Cancelar_Tablas.Location = New System.Drawing.Point(123, 226)
        Me.Btn_Cancelar_Tablas.Name = "Btn_Cancelar_Tablas"
        Me.Btn_Cancelar_Tablas.Size = New System.Drawing.Size(109, 23)
        Me.Btn_Cancelar_Tablas.TabIndex = 15
        Me.Btn_Cancelar_Tablas.Text = "Cancelar"
        Me.Btn_Cancelar_Tablas.UseVisualStyleBackColor = False
        Me.Btn_Cancelar_Tablas.Visible = False
        '
        'Btn_Cancelar_Campos
        '
        Me.Btn_Cancelar_Campos.BackColor = System.Drawing.Color.White
        Me.Btn_Cancelar_Campos.ForeColor = System.Drawing.Color.Black
        Me.Btn_Cancelar_Campos.Location = New System.Drawing.Point(353, 226)
        Me.Btn_Cancelar_Campos.Name = "Btn_Cancelar_Campos"
        Me.Btn_Cancelar_Campos.Size = New System.Drawing.Size(109, 23)
        Me.Btn_Cancelar_Campos.TabIndex = 61
        Me.Btn_Cancelar_Campos.Text = "Cancelar"
        Me.Btn_Cancelar_Campos.UseVisualStyleBackColor = False
        Me.Btn_Cancelar_Campos.Visible = False
        '
        'Frm_Migrar_Productos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(613, 324)
        Me.Controls.Add(Me.Btn_Cancelar_Campos)
        Me.Controls.Add(Me.Btn_Cancelar_Tablas)
        Me.Controls.Add(Me.Progreso_Campos)
        Me.Controls.Add(Me.Progreso_Tablas)
        Me.Controls.Add(Me.Lbl_Progreso_Campos)
        Me.Controls.Add(Me.Lbl_Progreso_Tablas)
        Me.Controls.Add(Me.Btn_Campos)
        Me.Controls.Add(Me.Btn_Tablas)
        Me.Controls.Add(Me.Btn_Productos_Ext)
        Me.Controls.Add(Me.Btn_Productos_Local)
        Me.Controls.Add(Me.Btn_Migrar)
        Me.Controls.Add(Me.GroupPanel3)
        Me.Controls.Add(Me.GroupPanel2)
        Me.Controls.Add(Me.GroupPanel1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Migrar_Productos"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MIGRACION DE PRODUCTOS"
        Me.GroupPanel1.ResumeLayout(False)
        Me.GroupPanel2.ResumeLayout(False)
        Me.GroupPanel3.ResumeLayout(False)
        CType(Me.Grilla_Productos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Public WithEvents Txt_KOPR As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Btn_Config_Impresora_Diablito As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Buscar As Button
    Friend WithEvents GroupPanel2 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Btn_Configurar As Button
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Public WithEvents Txt_Server As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents GroupPanel3 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Grilla_Productos As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents Btn_Migrar As Button
    Friend WithEvents Btn_Productos_Local As Button
    Friend WithEvents Btn_Productos_Ext As Button
    Friend WithEvents Btn_Campos As Button
    Friend WithEvents Btn_Tablas As Button
    Friend WithEvents Lbl_Progreso_Tablas As Label
    Friend WithEvents Lbl_Progreso_Campos As Label
    Friend WithEvents Progreso_Tablas As ProgressBar
    Friend WithEvents Progreso_Campos As ProgressBar
    Friend WithEvents Btn_Cancelar_Tablas As Button
    Friend WithEvents Btn_Cancelar_Campos As Button
End Class
