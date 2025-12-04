<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_CruceAntiNoVinculados
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_CruceAntiNoVinculados))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Imagenes_20x20 = New System.Windows.Forms.ImageList(Me.components)
        Me.GroupPanel3 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Lbl_Referencia = New DevComponents.DotNetBar.LabelX()
        Me.Labelx5 = New DevComponents.DotNetBar.LabelX()
        Me.Lbl_Banco_Cta_Cte = New DevComponents.DotNetBar.LabelX()
        Me.Lbl_Tipo_Documento = New DevComponents.DotNetBar.LabelX()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.Lbl_Razon_Social = New DevComponents.DotNetBar.LabelX()
        Me.Lbl_Informacion = New DevComponents.DotNetBar.LabelX()
        Me.MetroStatusBar1 = New DevComponents.DotNetBar.Metro.MetroStatusBar()
        Me.Barra_Progreso = New DevComponents.DotNetBar.ProgressBarItem()
        Me.Lbl_Status = New DevComponents.DotNetBar.LabelItem()
        Me.Btn_MatchDocumentos = New DevComponents.DotNetBar.ButtonItem()
        Me.Chk_Seleccionar_Todo = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.ContextMenuBar1 = New DevComponents.DotNetBar.ContextMenuBar()
        Me.Menu_Contextual_01 = New DevComponents.DotNetBar.ButtonItem()
        Me.LabelItem1 = New DevComponents.DotNetBar.LabelItem()
        Me.Btn_Ver_Cta_Cte = New DevComponents.DotNetBar.ButtonItem()
        Me.Menu_Contextual_02 = New DevComponents.DotNetBar.ButtonItem()
        Me.LabelItem2 = New DevComponents.DotNetBar.LabelItem()
        Me.Btn_Doc_Asociado_Ver = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_AnticipoNVV = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_CruceDocParaPago = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Doc_Asociado_Quitar = New DevComponents.DotNetBar.ButtonItem()
        Me.Menu_Contextual_Exportar_Excel = New DevComponents.DotNetBar.ButtonItem()
        Me.LabelItem10 = New DevComponents.DotNetBar.LabelItem()
        Me.Btn_Mnu_ExportarExcelVistaActual = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Mnu_ExportarExcelTodo = New DevComponents.DotNetBar.ButtonItem()
        Me.Grilla_Maedpce = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Grabar_Autorizacion = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Actualizar = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Importar_Pagos = New DevComponents.DotNetBar.ButtonItem()
        Me.Chk_Seleccionar_MatchExacto = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Chk_MostrarSoloMatchExactos = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Chk_MostrarSoloSeleccionados = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.GroupPanel3.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.GroupPanel1.SuspendLayout()
        CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Grilla_Maedpce, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Imagenes_20x20
        '
        Me.Imagenes_20x20.ImageStream = CType(resources.GetObject("Imagenes_20x20.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.Imagenes_20x20.TransparentColor = System.Drawing.Color.Transparent
        Me.Imagenes_20x20.Images.SetKeyName(0, "ok_button.png")
        Me.Imagenes_20x20.Images.SetKeyName(1, "bank-add2.png")
        Me.Imagenes_20x20.Images.SetKeyName(2, "bank-warn.png")
        Me.Imagenes_20x20.Images.SetKeyName(3, "bank-error.png")
        Me.Imagenes_20x20.Images.SetKeyName(4, "bank_transfert.png")
        Me.Imagenes_20x20.Images.SetKeyName(5, "bank.png")
        Me.Imagenes_20x20.Images.SetKeyName(6, "add.png")
        Me.Imagenes_20x20.Images.SetKeyName(7, "warning.png")
        Me.Imagenes_20x20.Images.SetKeyName(8, "stop.png")
        Me.Imagenes_20x20.Images.SetKeyName(9, "delete.png")
        Me.Imagenes_20x20.Images.SetKeyName(10, "delete_button_error.png")
        Me.Imagenes_20x20.Images.SetKeyName(11, "bank-error.png")
        '
        'GroupPanel3
        '
        Me.GroupPanel3.BackColor = System.Drawing.Color.White
        Me.GroupPanel3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel3.Controls.Add(Me.TableLayoutPanel1)
        Me.GroupPanel3.Controls.Add(Me.Lbl_Informacion)
        Me.GroupPanel3.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel3.Location = New System.Drawing.Point(12, 397)
        Me.GroupPanel3.Name = "GroupPanel3"
        Me.GroupPanel3.Size = New System.Drawing.Size(1136, 131)
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
        Me.GroupPanel3.TabIndex = 87
        Me.GroupPanel3.Text = "Información adicional del docmento de pago"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.34402!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 88.65598!))
        Me.TableLayoutPanel1.Controls.Add(Me.Lbl_Referencia, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.Labelx5, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.Lbl_Banco_Cta_Cte, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Lbl_Tipo_Documento, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelX3, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelX1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelX2, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Lbl_Razon_Social, 1, 1)
        Me.TableLayoutPanel1.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 4
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(811, 75)
        Me.TableLayoutPanel1.TabIndex = 2
        '
        'Lbl_Referencia
        '
        Me.Lbl_Referencia.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_Referencia.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Referencia.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Referencia.Location = New System.Drawing.Point(95, 57)
        Me.Lbl_Referencia.Name = "Lbl_Referencia"
        Me.Lbl_Referencia.Size = New System.Drawing.Size(713, 15)
        Me.Lbl_Referencia.TabIndex = 6
        Me.Lbl_Referencia.Text = "..."
        '
        'Labelx5
        '
        Me.Labelx5.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Labelx5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Labelx5.ForeColor = System.Drawing.Color.Black
        Me.Labelx5.Location = New System.Drawing.Point(3, 57)
        Me.Labelx5.Name = "Labelx5"
        Me.Labelx5.Size = New System.Drawing.Size(86, 15)
        Me.Labelx5.TabIndex = 5
        Me.Labelx5.Text = "Referencia"
        '
        'Lbl_Banco_Cta_Cte
        '
        Me.Lbl_Banco_Cta_Cte.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_Banco_Cta_Cte.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Banco_Cta_Cte.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Banco_Cta_Cte.Location = New System.Drawing.Point(95, 39)
        Me.Lbl_Banco_Cta_Cte.Name = "Lbl_Banco_Cta_Cte"
        Me.Lbl_Banco_Cta_Cte.Size = New System.Drawing.Size(713, 12)
        Me.Lbl_Banco_Cta_Cte.TabIndex = 6
        Me.Lbl_Banco_Cta_Cte.Text = "..."
        '
        'Lbl_Tipo_Documento
        '
        Me.Lbl_Tipo_Documento.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_Tipo_Documento.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Tipo_Documento.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Tipo_Documento.Location = New System.Drawing.Point(95, 3)
        Me.Lbl_Tipo_Documento.Name = "Lbl_Tipo_Documento"
        Me.Lbl_Tipo_Documento.Size = New System.Drawing.Size(713, 12)
        Me.Lbl_Tipo_Documento.TabIndex = 6
        Me.Lbl_Tipo_Documento.Text = "..."
        '
        'LabelX3
        '
        Me.LabelX3.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.ForeColor = System.Drawing.Color.Black
        Me.LabelX3.Location = New System.Drawing.Point(3, 39)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(86, 12)
        Me.LabelX3.TabIndex = 4
        Me.LabelX3.Text = "Banco, Cta.Cte."
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.ForeColor = System.Drawing.Color.Black
        Me.LabelX1.Location = New System.Drawing.Point(3, 3)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(86, 12)
        Me.LabelX1.TabIndex = 4
        Me.LabelX1.Text = "Tipo documento"
        '
        'LabelX2
        '
        Me.LabelX2.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.ForeColor = System.Drawing.Color.Black
        Me.LabelX2.Location = New System.Drawing.Point(3, 21)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(75, 12)
        Me.LabelX2.TabIndex = 3
        Me.LabelX2.Text = "Razon Social"
        '
        'Lbl_Razon_Social
        '
        Me.Lbl_Razon_Social.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_Razon_Social.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Razon_Social.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Razon_Social.Location = New System.Drawing.Point(95, 21)
        Me.Lbl_Razon_Social.Name = "Lbl_Razon_Social"
        Me.Lbl_Razon_Social.Size = New System.Drawing.Size(713, 12)
        Me.Lbl_Razon_Social.TabIndex = 5
        Me.Lbl_Razon_Social.Text = "..."
        '
        'Lbl_Informacion
        '
        Me.Lbl_Informacion.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_Informacion.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Informacion.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Informacion.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Informacion.Location = New System.Drawing.Point(3, 84)
        Me.Lbl_Informacion.Name = "Lbl_Informacion"
        Me.Lbl_Informacion.Size = New System.Drawing.Size(981, 20)
        Me.Lbl_Informacion.TabIndex = 0
        Me.Lbl_Informacion.Text = "Problemas:"
        '
        'MetroStatusBar1
        '
        Me.MetroStatusBar1.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.MetroStatusBar1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.MetroStatusBar1.ContainerControlProcessDialogKey = True
        Me.MetroStatusBar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.MetroStatusBar1.DragDropSupport = True
        Me.MetroStatusBar1.Font = New System.Drawing.Font("Segoe UI", 10.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MetroStatusBar1.ForeColor = System.Drawing.Color.Black
        Me.MetroStatusBar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Barra_Progreso, Me.Lbl_Status})
        Me.MetroStatusBar1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.MetroStatusBar1.Location = New System.Drawing.Point(0, 575)
        Me.MetroStatusBar1.Name = "MetroStatusBar1"
        Me.MetroStatusBar1.Size = New System.Drawing.Size(1158, 22)
        Me.MetroStatusBar1.TabIndex = 88
        Me.MetroStatusBar1.Text = "MetroStatusBar1"
        '
        'Barra_Progreso
        '
        '
        '
        '
        Me.Barra_Progreso.BackStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Barra_Progreso.ChunkGradientAngle = 0!
        Me.Barra_Progreso.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways
        Me.Barra_Progreso.Name = "Barra_Progreso"
        Me.Barra_Progreso.RecentlyUsed = False
        Me.Barra_Progreso.Visible = False
        '
        'Lbl_Status
        '
        Me.Lbl_Status.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Lbl_Status.Name = "Lbl_Status"
        Me.Lbl_Status.Text = "Status..."
        '
        'Btn_MatchDocumentos
        '
        Me.Btn_MatchDocumentos.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_MatchDocumentos.ForeColor = System.Drawing.Color.Black
        Me.Btn_MatchDocumentos.Image = CType(resources.GetObject("Btn_MatchDocumentos.Image"), System.Drawing.Image)
        Me.Btn_MatchDocumentos.ImageAlt = CType(resources.GetObject("Btn_MatchDocumentos.ImageAlt"), System.Drawing.Image)
        Me.Btn_MatchDocumentos.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.Btn_MatchDocumentos.Name = "Btn_MatchDocumentos"
        Me.Btn_MatchDocumentos.Tooltip = "Sugerir FCV/Ref. Automáticamente en forma masiva"
        '
        'Chk_Seleccionar_Todo
        '
        Me.Chk_Seleccionar_Todo.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Chk_Seleccionar_Todo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Seleccionar_Todo.CheckBoxImageChecked = CType(resources.GetObject("Chk_Seleccionar_Todo.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_Seleccionar_Todo.FocusCuesEnabled = False
        Me.Chk_Seleccionar_Todo.ForeColor = System.Drawing.Color.Black
        Me.Chk_Seleccionar_Todo.Location = New System.Drawing.Point(12, 366)
        Me.Chk_Seleccionar_Todo.Name = "Chk_Seleccionar_Todo"
        Me.Chk_Seleccionar_Todo.Size = New System.Drawing.Size(106, 23)
        Me.Chk_Seleccionar_Todo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Seleccionar_Todo.TabIndex = 84
        Me.Chk_Seleccionar_Todo.Text = "Seleccionar todo"
        '
        'GroupPanel1
        '
        Me.GroupPanel1.BackColor = System.Drawing.Color.White
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.ContextMenuBar1)
        Me.GroupPanel1.Controls.Add(Me.Grilla_Maedpce)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Location = New System.Drawing.Point(12, 1)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(1136, 359)
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
        Me.GroupPanel1.TabIndex = 85
        Me.GroupPanel1.Text = "Detalle"
        '
        'ContextMenuBar1
        '
        Me.ContextMenuBar1.AntiAlias = True
        Me.ContextMenuBar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ContextMenuBar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Menu_Contextual_01, Me.Menu_Contextual_02, Me.Menu_Contextual_Exportar_Excel})
        Me.ContextMenuBar1.Location = New System.Drawing.Point(42, 48)
        Me.ContextMenuBar1.Name = "ContextMenuBar1"
        Me.ContextMenuBar1.Size = New System.Drawing.Size(472, 25)
        Me.ContextMenuBar1.Stretch = True
        Me.ContextMenuBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ContextMenuBar1.TabIndex = 46
        Me.ContextMenuBar1.TabStop = False
        Me.ContextMenuBar1.Text = "ContextMenuBar1"
        '
        'Menu_Contextual_01
        '
        Me.Menu_Contextual_01.AutoExpandOnClick = True
        Me.Menu_Contextual_01.Name = "Menu_Contextual_01"
        Me.Menu_Contextual_01.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItem1, Me.Btn_Ver_Cta_Cte})
        Me.Menu_Contextual_01.Text = "Opciones documento"
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
        Me.LabelItem1.Text = "Opciones"
        '
        'Btn_Ver_Cta_Cte
        '
        Me.Btn_Ver_Cta_Cte.Image = CType(resources.GetObject("Btn_Ver_Cta_Cte.Image"), System.Drawing.Image)
        Me.Btn_Ver_Cta_Cte.Name = "Btn_Ver_Cta_Cte"
        Me.Btn_Ver_Cta_Cte.Text = "Ver Cta.Cte. entidad (saldos a favor)"
        '
        'Menu_Contextual_02
        '
        Me.Menu_Contextual_02.AutoExpandOnClick = True
        Me.Menu_Contextual_02.Name = "Menu_Contextual_02"
        Me.Menu_Contextual_02.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItem2, Me.Btn_Doc_Asociado_Ver, Me.Btn_AnticipoNVV, Me.Btn_CruceDocParaPago, Me.Btn_Doc_Asociado_Quitar})
        Me.Menu_Contextual_02.Text = "Asociar documentos"
        '
        'LabelItem2
        '
        Me.LabelItem2.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.LabelItem2.BorderSide = DevComponents.DotNetBar.eBorderSide.Bottom
        Me.LabelItem2.BorderType = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.LabelItem2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(21, Byte), Integer), CType(CType(110, Byte), Integer))
        Me.LabelItem2.Name = "LabelItem2"
        Me.LabelItem2.PaddingBottom = 1
        Me.LabelItem2.PaddingLeft = 10
        Me.LabelItem2.PaddingTop = 1
        Me.LabelItem2.SingleLineColor = System.Drawing.Color.FromArgb(CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer))
        Me.LabelItem2.Text = "Opciones"
        '
        'Btn_Doc_Asociado_Ver
        '
        Me.Btn_Doc_Asociado_Ver.Image = CType(resources.GetObject("Btn_Doc_Asociado_Ver.Image"), System.Drawing.Image)
        Me.Btn_Doc_Asociado_Ver.Name = "Btn_Doc_Asociado_Ver"
        Me.Btn_Doc_Asociado_Ver.Text = "Ver documento asociado (NVV-0000000000)"
        '
        'Btn_AnticipoNVV
        '
        Me.Btn_AnticipoNVV.Image = CType(resources.GetObject("Btn_AnticipoNVV.Image"), System.Drawing.Image)
        Me.Btn_AnticipoNVV.Name = "Btn_AnticipoNVV"
        Me.Btn_AnticipoNVV.Text = "Ingresar documento ('NVV','RES','PRO') al anticipo"
        '
        'Btn_CruceDocParaPago
        '
        Me.Btn_CruceDocParaPago.Image = CType(resources.GetObject("Btn_CruceDocParaPago.Image"), System.Drawing.Image)
        Me.Btn_CruceDocParaPago.Name = "Btn_CruceDocParaPago"
        Me.Btn_CruceDocParaPago.Text = "Ingresar documento ('FCV','BLV') cruce de pago automático" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'Btn_Doc_Asociado_Quitar
        '
        Me.Btn_Doc_Asociado_Quitar.Image = CType(resources.GetObject("Btn_Doc_Asociado_Quitar.Image"), System.Drawing.Image)
        Me.Btn_Doc_Asociado_Quitar.Name = "Btn_Doc_Asociado_Quitar"
        Me.Btn_Doc_Asociado_Quitar.Text = "Quitar documento asociado al anticipo" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'Menu_Contextual_Exportar_Excel
        '
        Me.Menu_Contextual_Exportar_Excel.AutoExpandOnClick = True
        Me.Menu_Contextual_Exportar_Excel.Name = "Menu_Contextual_Exportar_Excel"
        Me.Menu_Contextual_Exportar_Excel.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItem10, Me.Btn_Mnu_ExportarExcelVistaActual, Me.Btn_Mnu_ExportarExcelTodo})
        Me.Menu_Contextual_Exportar_Excel.Text = "Opciones Exportar Excel"
        '
        'LabelItem10
        '
        Me.LabelItem10.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.LabelItem10.BorderSide = DevComponents.DotNetBar.eBorderSide.Bottom
        Me.LabelItem10.BorderType = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.LabelItem10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(21, Byte), Integer), CType(CType(110, Byte), Integer))
        Me.LabelItem10.Name = "LabelItem10"
        Me.LabelItem10.PaddingBottom = 1
        Me.LabelItem10.PaddingLeft = 10
        Me.LabelItem10.PaddingTop = 1
        Me.LabelItem10.SingleLineColor = System.Drawing.Color.FromArgb(CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer))
        Me.LabelItem10.Text = "Exportar lista"
        '
        'Btn_Mnu_ExportarExcelVistaActual
        '
        Me.Btn_Mnu_ExportarExcelVistaActual.Image = CType(resources.GetObject("Btn_Mnu_ExportarExcelVistaActual.Image"), System.Drawing.Image)
        Me.Btn_Mnu_ExportarExcelVistaActual.ImageAlt = CType(resources.GetObject("Btn_Mnu_ExportarExcelVistaActual.ImageAlt"), System.Drawing.Image)
        Me.Btn_Mnu_ExportarExcelVistaActual.Name = "Btn_Mnu_ExportarExcelVistaActual"
        Me.Btn_Mnu_ExportarExcelVistaActual.Text = "Exportar vista actual"
        '
        'Btn_Mnu_ExportarExcelTodo
        '
        Me.Btn_Mnu_ExportarExcelTodo.Image = CType(resources.GetObject("Btn_Mnu_ExportarExcelTodo.Image"), System.Drawing.Image)
        Me.Btn_Mnu_ExportarExcelTodo.ImageAlt = CType(resources.GetObject("Btn_Mnu_ExportarExcelTodo.ImageAlt"), System.Drawing.Image)
        Me.Btn_Mnu_ExportarExcelTodo.Name = "Btn_Mnu_ExportarExcelTodo"
        Me.Btn_Mnu_ExportarExcelTodo.Text = "Exportar todo"
        '
        'Grilla_Maedpce
        '
        Me.Grilla_Maedpce.AllowUserToAddRows = False
        Me.Grilla_Maedpce.AllowUserToDeleteRows = False
        Me.Grilla_Maedpce.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla_Maedpce.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.Grilla_Maedpce.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Grilla_Maedpce.DefaultCellStyle = DataGridViewCellStyle2
        Me.Grilla_Maedpce.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grilla_Maedpce.EnableHeadersVisualStyles = False
        Me.Grilla_Maedpce.GridColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.Grilla_Maedpce.Location = New System.Drawing.Point(0, 0)
        Me.Grilla_Maedpce.Name = "Grilla_Maedpce"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla_Maedpce.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.Grilla_Maedpce.Size = New System.Drawing.Size(1130, 336)
        Me.Grilla_Maedpce.StandardTab = True
        Me.Grilla_Maedpce.TabIndex = 53
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Grabar_Autorizacion, Me.Btn_Actualizar, Me.Btn_MatchDocumentos, Me.Btn_Importar_Pagos})
        Me.Bar1.Location = New System.Drawing.Point(0, 534)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(1158, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 86
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'Btn_Grabar_Autorizacion
        '
        Me.Btn_Grabar_Autorizacion.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Grabar_Autorizacion.ForeColor = System.Drawing.Color.Black
        Me.Btn_Grabar_Autorizacion.Image = CType(resources.GetObject("Btn_Grabar_Autorizacion.Image"), System.Drawing.Image)
        Me.Btn_Grabar_Autorizacion.ImageAlt = CType(resources.GetObject("Btn_Grabar_Autorizacion.ImageAlt"), System.Drawing.Image)
        Me.Btn_Grabar_Autorizacion.Name = "Btn_Grabar_Autorizacion"
        Me.Btn_Grabar_Autorizacion.Tooltip = "Grabar pagos"
        '
        'Btn_Actualizar
        '
        Me.Btn_Actualizar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Actualizar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Actualizar.Image = CType(resources.GetObject("Btn_Actualizar.Image"), System.Drawing.Image)
        Me.Btn_Actualizar.ImageAlt = CType(resources.GetObject("Btn_Actualizar.ImageAlt"), System.Drawing.Image)
        Me.Btn_Actualizar.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.Btn_Actualizar.Name = "Btn_Actualizar"
        Me.Btn_Actualizar.Tooltip = "Refrescar datos"
        '
        'Btn_Importar_Pagos
        '
        Me.Btn_Importar_Pagos.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Importar_Pagos.ForeColor = System.Drawing.Color.Black
        Me.Btn_Importar_Pagos.Image = CType(resources.GetObject("Btn_Importar_Pagos.Image"), System.Drawing.Image)
        Me.Btn_Importar_Pagos.ImageAlt = CType(resources.GetObject("Btn_Importar_Pagos.ImageAlt"), System.Drawing.Image)
        Me.Btn_Importar_Pagos.Name = "Btn_Importar_Pagos"
        Me.Btn_Importar_Pagos.Tooltip = "Importar pagos"
        '
        'Chk_Seleccionar_MatchExacto
        '
        Me.Chk_Seleccionar_MatchExacto.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Chk_Seleccionar_MatchExacto.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Seleccionar_MatchExacto.CheckBoxImageChecked = CType(resources.GetObject("Chk_Seleccionar_MatchExacto.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_Seleccionar_MatchExacto.FocusCuesEnabled = False
        Me.Chk_Seleccionar_MatchExacto.ForeColor = System.Drawing.Color.Black
        Me.Chk_Seleccionar_MatchExacto.Location = New System.Drawing.Point(117, 366)
        Me.Chk_Seleccionar_MatchExacto.Name = "Chk_Seleccionar_MatchExacto"
        Me.Chk_Seleccionar_MatchExacto.Size = New System.Drawing.Size(143, 23)
        Me.Chk_Seleccionar_MatchExacto.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Seleccionar_MatchExacto.TabIndex = 89
        Me.Chk_Seleccionar_MatchExacto.Text = "Seleccionar Match Exacto"
        '
        'Chk_MostrarSoloMatchExactos
        '
        Me.Chk_MostrarSoloMatchExactos.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Chk_MostrarSoloMatchExactos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_MostrarSoloMatchExactos.CheckBoxImageChecked = CType(resources.GetObject("Chk_MostrarSoloMatchExactos.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_MostrarSoloMatchExactos.FocusCuesEnabled = False
        Me.Chk_MostrarSoloMatchExactos.ForeColor = System.Drawing.Color.Black
        Me.Chk_MostrarSoloMatchExactos.Location = New System.Drawing.Point(266, 366)
        Me.Chk_MostrarSoloMatchExactos.Name = "Chk_MostrarSoloMatchExactos"
        Me.Chk_MostrarSoloMatchExactos.Size = New System.Drawing.Size(138, 23)
        Me.Chk_MostrarSoloMatchExactos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_MostrarSoloMatchExactos.TabIndex = 90
        Me.Chk_MostrarSoloMatchExactos.Text = "Ver solo Match Exactos"
        '
        'Chk_MostrarSoloSeleccionados
        '
        Me.Chk_MostrarSoloSeleccionados.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Chk_MostrarSoloSeleccionados.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_MostrarSoloSeleccionados.CheckBoxImageChecked = CType(resources.GetObject("Chk_MostrarSoloSeleccionados.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_MostrarSoloSeleccionados.FocusCuesEnabled = False
        Me.Chk_MostrarSoloSeleccionados.ForeColor = System.Drawing.Color.Black
        Me.Chk_MostrarSoloSeleccionados.Location = New System.Drawing.Point(410, 366)
        Me.Chk_MostrarSoloSeleccionados.Name = "Chk_MostrarSoloSeleccionados"
        Me.Chk_MostrarSoloSeleccionados.Size = New System.Drawing.Size(166, 23)
        Me.Chk_MostrarSoloSeleccionados.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_MostrarSoloSeleccionados.TabIndex = 91
        Me.Chk_MostrarSoloSeleccionados.Text = "Ver solo Seleccionados"
        '
        'Frm_CruceAntiNoVinculados
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1158, 597)
        Me.Controls.Add(Me.Chk_MostrarSoloSeleccionados)
        Me.Controls.Add(Me.Chk_MostrarSoloMatchExactos)
        Me.Controls.Add(Me.Chk_Seleccionar_MatchExacto)
        Me.Controls.Add(Me.GroupPanel3)
        Me.Controls.Add(Me.Chk_Seleccionar_Todo)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Controls.Add(Me.Bar1)
        Me.Controls.Add(Me.MetroStatusBar1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_CruceAntiNoVinculados"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Informe de situación de Anticipos de Clientes"
        Me.GroupPanel3.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.GroupPanel1.ResumeLayout(False)
        CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Grilla_Maedpce, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Imagenes_20x20 As ImageList
    Friend WithEvents GroupPanel3 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents Lbl_Referencia As DevComponents.DotNetBar.LabelX
    Friend WithEvents Labelx5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Lbl_Banco_Cta_Cte As DevComponents.DotNetBar.LabelX
    Friend WithEvents Lbl_Tipo_Documento As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Lbl_Razon_Social As DevComponents.DotNetBar.LabelX
    Friend WithEvents Lbl_Informacion As DevComponents.DotNetBar.LabelX
    Friend WithEvents MetroStatusBar1 As DevComponents.DotNetBar.Metro.MetroStatusBar
    Friend WithEvents Barra_Progreso As DevComponents.DotNetBar.ProgressBarItem
    Friend WithEvents Lbl_Status As DevComponents.DotNetBar.LabelItem
    Public WithEvents Btn_MatchDocumentos As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Chk_Seleccionar_Todo As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents ContextMenuBar1 As DevComponents.DotNetBar.ContextMenuBar
    Friend WithEvents Menu_Contextual_01 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelItem1 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents Btn_Ver_Cta_Cte As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Menu_Contextual_02 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelItem2 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents Btn_Doc_Asociado_Ver As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_AnticipoNVV As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_CruceDocParaPago As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Doc_Asociado_Quitar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Grilla_Maedpce As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents Btn_Grabar_Autorizacion As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Importar_Pagos As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_Actualizar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Chk_Seleccionar_MatchExacto As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Chk_MostrarSoloMatchExactos As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Menu_Contextual_Exportar_Excel As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelItem10 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents Btn_Mnu_ExportarExcelVistaActual As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Mnu_ExportarExcelTodo As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Chk_MostrarSoloSeleccionados As DevComponents.DotNetBar.Controls.CheckBoxX
End Class
