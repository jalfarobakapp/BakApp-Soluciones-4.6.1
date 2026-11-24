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
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Imagenes_20x20 = New System.Windows.Forms.ImageList(Me.components)
        Me.GroupPanel3 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Lbl_ResumenFacturasCruce = New DevComponents.DotNetBar.LabelX()
        Me.LabelX6 = New DevComponents.DotNetBar.LabelX()
        Me.Lbl_Vendedor = New DevComponents.DotNetBar.LabelX()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
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
        Me.Btn_DesbloquearPago = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_BloquearPago = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_InfoBloqueo = New DevComponents.DotNetBar.ButtonItem()
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
        Me.GroupPanel2 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Lbl_TotalSeleccion = New DevComponents.DotNetBar.LabelX()
        Me.GroupPanel4 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Lbl_TotalAnticipos = New DevComponents.DotNetBar.LabelX()
        Me.Chk_Fecha_Asignacion = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Chk_SoloMatchFacVencidas = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Chk_MarcarSoloMatchExactos = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Chk_VerSoloSinMatch = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Chk_Seleccionar_SinMatchExacto = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Btn_Ver_Documento = New DevComponents.DotNetBar.ButtonItem()
        Me.GroupPanel3.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.GroupPanel1.SuspendLayout()
        CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Grilla_Maedpce, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel2.SuspendLayout()
        Me.GroupPanel4.SuspendLayout()
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
        Me.GroupPanel3.Size = New System.Drawing.Size(977, 160)
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
        Me.TableLayoutPanel1.Controls.Add(Me.Lbl_ResumenFacturasCruce, 1, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelX6, 0, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.Lbl_Vendedor, 1, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelX4, 0, 4)
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
        Me.TableLayoutPanel1.RowCount = 6
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(965, 107)
        Me.TableLayoutPanel1.TabIndex = 2
        '
        'Lbl_ResumenFacturasCruce
        '
        Me.Lbl_ResumenFacturasCruce.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_ResumenFacturasCruce.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_ResumenFacturasCruce.ForeColor = System.Drawing.Color.Black
        Me.Lbl_ResumenFacturasCruce.Location = New System.Drawing.Point(112, 88)
        Me.Lbl_ResumenFacturasCruce.Name = "Lbl_ResumenFacturasCruce"
        Me.Lbl_ResumenFacturasCruce.Size = New System.Drawing.Size(713, 11)
        Me.Lbl_ResumenFacturasCruce.TabIndex = 201
        Me.Lbl_ResumenFacturasCruce.Text = "..."
        '
        'LabelX6
        '
        Me.LabelX6.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX6.ForeColor = System.Drawing.Color.Black
        Me.LabelX6.Location = New System.Drawing.Point(3, 88)
        Me.LabelX6.Name = "LabelX6"
        Me.LabelX6.Size = New System.Drawing.Size(86, 14)
        Me.LabelX6.TabIndex = 201
        Me.LabelX6.Text = "Referencias"
        '
        'Lbl_Vendedor
        '
        Me.Lbl_Vendedor.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_Vendedor.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Vendedor.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Vendedor.Location = New System.Drawing.Point(112, 71)
        Me.Lbl_Vendedor.Name = "Lbl_Vendedor"
        Me.Lbl_Vendedor.Size = New System.Drawing.Size(713, 11)
        Me.Lbl_Vendedor.TabIndex = 199
        Me.Lbl_Vendedor.Text = "..."
        '
        'LabelX4
        '
        Me.LabelX4.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.ForeColor = System.Drawing.Color.Black
        Me.LabelX4.Location = New System.Drawing.Point(3, 71)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(86, 11)
        Me.LabelX4.TabIndex = 6
        Me.LabelX4.Text = "Vendedor"
        '
        'Lbl_Referencia
        '
        Me.Lbl_Referencia.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_Referencia.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Referencia.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Referencia.Location = New System.Drawing.Point(112, 54)
        Me.Lbl_Referencia.Name = "Lbl_Referencia"
        Me.Lbl_Referencia.Size = New System.Drawing.Size(713, 10)
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
        Me.Labelx5.Location = New System.Drawing.Point(3, 54)
        Me.Labelx5.Name = "Labelx5"
        Me.Labelx5.Size = New System.Drawing.Size(86, 10)
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
        Me.Lbl_Banco_Cta_Cte.Location = New System.Drawing.Point(112, 37)
        Me.Lbl_Banco_Cta_Cte.Name = "Lbl_Banco_Cta_Cte"
        Me.Lbl_Banco_Cta_Cte.Size = New System.Drawing.Size(713, 10)
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
        Me.Lbl_Tipo_Documento.Location = New System.Drawing.Point(112, 3)
        Me.Lbl_Tipo_Documento.Name = "Lbl_Tipo_Documento"
        Me.Lbl_Tipo_Documento.Size = New System.Drawing.Size(713, 10)
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
        Me.LabelX3.Location = New System.Drawing.Point(3, 37)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(86, 10)
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
        Me.LabelX1.Size = New System.Drawing.Size(86, 10)
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
        Me.LabelX2.Location = New System.Drawing.Point(3, 20)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(75, 10)
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
        Me.Lbl_Razon_Social.Location = New System.Drawing.Point(112, 20)
        Me.Lbl_Razon_Social.Name = "Lbl_Razon_Social"
        Me.Lbl_Razon_Social.Size = New System.Drawing.Size(713, 10)
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
        Me.Lbl_Informacion.Location = New System.Drawing.Point(6, 115)
        Me.Lbl_Informacion.Name = "Lbl_Informacion"
        Me.Lbl_Informacion.Size = New System.Drawing.Size(962, 20)
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
        Me.MetroStatusBar1.Location = New System.Drawing.Point(0, 615)
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
        Me.Chk_Seleccionar_Todo.Location = New System.Drawing.Point(12, 347)
        Me.Chk_Seleccionar_Todo.Name = "Chk_Seleccionar_Todo"
        Me.Chk_Seleccionar_Todo.Size = New System.Drawing.Size(99, 23)
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
        Me.GroupPanel1.Size = New System.Drawing.Size(1136, 344)
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
        Me.Menu_Contextual_01.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItem1, Me.Btn_Ver_Documento, Me.Btn_Ver_Cta_Cte, Me.Btn_DesbloquearPago, Me.Btn_BloquearPago, Me.Btn_InfoBloqueo})
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
        'Btn_DesbloquearPago
        '
        Me.Btn_DesbloquearPago.Image = CType(resources.GetObject("Btn_DesbloquearPago.Image"), System.Drawing.Image)
        Me.Btn_DesbloquearPago.Name = "Btn_DesbloquearPago"
        Me.Btn_DesbloquearPago.Text = "Desbloquear pago"
        '
        'Btn_BloquearPago
        '
        Me.Btn_BloquearPago.Image = CType(resources.GetObject("Btn_BloquearPago.Image"), System.Drawing.Image)
        Me.Btn_BloquearPago.Name = "Btn_BloquearPago"
        Me.Btn_BloquearPago.Text = "Bloquear pago"
        Me.Btn_BloquearPago.Tooltip = "Bloquear pago para ser utilizado"
        '
        'Btn_InfoBloqueo
        '
        Me.Btn_InfoBloqueo.Image = CType(resources.GetObject("Btn_InfoBloqueo.Image"), System.Drawing.Image)
        Me.Btn_InfoBloqueo.ImageAlt = CType(resources.GetObject("Btn_InfoBloqueo.ImageAlt"), System.Drawing.Image)
        Me.Btn_InfoBloqueo.Name = "Btn_InfoBloqueo"
        Me.Btn_InfoBloqueo.Text = "Informacion de bloqueo"
        Me.Btn_InfoBloqueo.Tooltip = "Bloquear pago para ser utilizado"
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
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla_Maedpce.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.Grilla_Maedpce.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Grilla_Maedpce.DefaultCellStyle = DataGridViewCellStyle5
        Me.Grilla_Maedpce.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grilla_Maedpce.EnableHeadersVisualStyles = False
        Me.Grilla_Maedpce.GridColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.Grilla_Maedpce.Location = New System.Drawing.Point(0, 0)
        Me.Grilla_Maedpce.Name = "Grilla_Maedpce"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla_Maedpce.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.Grilla_Maedpce.Size = New System.Drawing.Size(1130, 321)
        Me.Grilla_Maedpce.StandardTab = True
        Me.Grilla_Maedpce.TabIndex = 53
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Grabar_Autorizacion, Me.Btn_Actualizar, Me.Btn_MatchDocumentos, Me.Btn_Importar_Pagos})
        Me.Bar1.Location = New System.Drawing.Point(0, 574)
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
        Me.Chk_Seleccionar_MatchExacto.Location = New System.Drawing.Point(117, 347)
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
        Me.Chk_MostrarSoloMatchExactos.Location = New System.Drawing.Point(435, 347)
        Me.Chk_MostrarSoloMatchExactos.Name = "Chk_MostrarSoloMatchExactos"
        Me.Chk_MostrarSoloMatchExactos.Size = New System.Drawing.Size(129, 23)
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
        Me.Chk_MostrarSoloSeleccionados.Location = New System.Drawing.Point(570, 347)
        Me.Chk_MostrarSoloSeleccionados.Name = "Chk_MostrarSoloSeleccionados"
        Me.Chk_MostrarSoloSeleccionados.Size = New System.Drawing.Size(128, 23)
        Me.Chk_MostrarSoloSeleccionados.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_MostrarSoloSeleccionados.TabIndex = 91
        Me.Chk_MostrarSoloSeleccionados.Text = "Ver solo Seleccionados"
        '
        'GroupPanel2
        '
        Me.GroupPanel2.BackColor = System.Drawing.Color.White
        Me.GroupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel2.Controls.Add(Me.Lbl_TotalSeleccion)
        Me.GroupPanel2.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel2.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.GroupPanel2.Location = New System.Drawing.Point(995, 401)
        Me.GroupPanel2.Name = "GroupPanel2"
        Me.GroupPanel2.Size = New System.Drawing.Size(153, 58)
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
        Me.GroupPanel2.TabIndex = 138
        Me.GroupPanel2.Text = "Total a selección"
        '
        'Lbl_TotalSeleccion
        '
        Me.Lbl_TotalSeleccion.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_TotalSeleccion.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_TotalSeleccion.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_TotalSeleccion.ForeColor = System.Drawing.Color.Black
        Me.Lbl_TotalSeleccion.Location = New System.Drawing.Point(3, 3)
        Me.Lbl_TotalSeleccion.Name = "Lbl_TotalSeleccion"
        Me.Lbl_TotalSeleccion.Size = New System.Drawing.Size(141, 23)
        Me.Lbl_TotalSeleccion.TabIndex = 34
        Me.Lbl_TotalSeleccion.Text = "0"
        Me.Lbl_TotalSeleccion.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'GroupPanel4
        '
        Me.GroupPanel4.BackColor = System.Drawing.Color.White
        Me.GroupPanel4.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel4.Controls.Add(Me.Lbl_TotalAnticipos)
        Me.GroupPanel4.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel4.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.GroupPanel4.Location = New System.Drawing.Point(995, 469)
        Me.GroupPanel4.Name = "GroupPanel4"
        Me.GroupPanel4.Size = New System.Drawing.Size(153, 58)
        '
        '
        '
        Me.GroupPanel4.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.GroupPanel4.Style.BackColorGradientAngle = 90
        Me.GroupPanel4.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.GroupPanel4.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel4.Style.BorderBottomWidth = 1
        Me.GroupPanel4.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupPanel4.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel4.Style.BorderLeftWidth = 1
        Me.GroupPanel4.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel4.Style.BorderRightWidth = 1
        Me.GroupPanel4.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel4.Style.BorderTopWidth = 1
        Me.GroupPanel4.Style.CornerDiameter = 4
        Me.GroupPanel4.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanel4.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanel4.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GroupPanel4.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupPanel4.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanel4.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanel4.TabIndex = 139
        Me.GroupPanel4.Text = "Total Anticipos"
        '
        'Lbl_TotalAnticipos
        '
        Me.Lbl_TotalAnticipos.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_TotalAnticipos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_TotalAnticipos.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_TotalAnticipos.ForeColor = System.Drawing.Color.Black
        Me.Lbl_TotalAnticipos.Location = New System.Drawing.Point(3, 3)
        Me.Lbl_TotalAnticipos.Name = "Lbl_TotalAnticipos"
        Me.Lbl_TotalAnticipos.Size = New System.Drawing.Size(141, 23)
        Me.Lbl_TotalAnticipos.TabIndex = 34
        Me.Lbl_TotalAnticipos.Text = "0"
        Me.Lbl_TotalAnticipos.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'Chk_Fecha_Asignacion
        '
        Me.Chk_Fecha_Asignacion.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Chk_Fecha_Asignacion.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Fecha_Asignacion.CheckBoxImageChecked = CType(resources.GetObject("Chk_Fecha_Asignacion.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_Fecha_Asignacion.Checked = True
        Me.Chk_Fecha_Asignacion.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Chk_Fecha_Asignacion.CheckValue = "Y"
        Me.Chk_Fecha_Asignacion.FocusCuesEnabled = False
        Me.Chk_Fecha_Asignacion.ForeColor = System.Drawing.Color.Black
        Me.Chk_Fecha_Asignacion.Location = New System.Drawing.Point(911, 348)
        Me.Chk_Fecha_Asignacion.Name = "Chk_Fecha_Asignacion"
        Me.Chk_Fecha_Asignacion.Size = New System.Drawing.Size(231, 23)
        Me.Chk_Fecha_Asignacion.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Fecha_Asignacion.TabIndex = 197
        Me.Chk_Fecha_Asignacion.Text = "Fecha de asignación del pago. Fecha actual"
        '
        'Chk_SoloMatchFacVencidas
        '
        Me.Chk_SoloMatchFacVencidas.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Chk_SoloMatchFacVencidas.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_SoloMatchFacVencidas.CheckBoxImageChecked = CType(resources.GetObject("Chk_SoloMatchFacVencidas.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_SoloMatchFacVencidas.Checked = True
        Me.Chk_SoloMatchFacVencidas.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Chk_SoloMatchFacVencidas.CheckValue = "Y"
        Me.Chk_SoloMatchFacVencidas.FocusCuesEnabled = False
        Me.Chk_SoloMatchFacVencidas.ForeColor = System.Drawing.Color.Black
        Me.Chk_SoloMatchFacVencidas.Location = New System.Drawing.Point(12, 370)
        Me.Chk_SoloMatchFacVencidas.Name = "Chk_SoloMatchFacVencidas"
        Me.Chk_SoloMatchFacVencidas.Size = New System.Drawing.Size(197, 21)
        Me.Chk_SoloMatchFacVencidas.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_SoloMatchFacVencidas.TabIndex = 198
        Me.Chk_SoloMatchFacVencidas.Text = "Solo Match a documentos vencidos"
        '
        'Chk_MarcarSoloMatchExactos
        '
        Me.Chk_MarcarSoloMatchExactos.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Chk_MarcarSoloMatchExactos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_MarcarSoloMatchExactos.CheckBoxImageChecked = CType(resources.GetObject("Chk_MarcarSoloMatchExactos.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_MarcarSoloMatchExactos.FocusCuesEnabled = False
        Me.Chk_MarcarSoloMatchExactos.ForeColor = System.Drawing.Color.Black
        Me.Chk_MarcarSoloMatchExactos.Location = New System.Drawing.Point(215, 370)
        Me.Chk_MarcarSoloMatchExactos.Name = "Chk_MarcarSoloMatchExactos"
        Me.Chk_MarcarSoloMatchExactos.Size = New System.Drawing.Size(153, 21)
        Me.Chk_MarcarSoloMatchExactos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_MarcarSoloMatchExactos.TabIndex = 199
        Me.Chk_MarcarSoloMatchExactos.Text = "Procesar solo Match Exactos"
        '
        'Chk_VerSoloSinMatch
        '
        Me.Chk_VerSoloSinMatch.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Chk_VerSoloSinMatch.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_VerSoloSinMatch.CheckBoxImageChecked = CType(resources.GetObject("Chk_VerSoloSinMatch.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_VerSoloSinMatch.FocusCuesEnabled = False
        Me.Chk_VerSoloSinMatch.ForeColor = System.Drawing.Color.Black
        Me.Chk_VerSoloSinMatch.Location = New System.Drawing.Point(704, 347)
        Me.Chk_VerSoloSinMatch.Name = "Chk_VerSoloSinMatch"
        Me.Chk_VerSoloSinMatch.Size = New System.Drawing.Size(116, 23)
        Me.Chk_VerSoloSinMatch.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_VerSoloSinMatch.TabIndex = 200
        Me.Chk_VerSoloSinMatch.Text = "Ver solo sin Match"
        '
        'Chk_Seleccionar_SinMatchExacto
        '
        Me.Chk_Seleccionar_SinMatchExacto.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Chk_Seleccionar_SinMatchExacto.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Seleccionar_SinMatchExacto.CheckBoxImageChecked = CType(resources.GetObject("Chk_Seleccionar_SinMatchExacto.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_Seleccionar_SinMatchExacto.FocusCuesEnabled = False
        Me.Chk_Seleccionar_SinMatchExacto.ForeColor = System.Drawing.Color.Black
        Me.Chk_Seleccionar_SinMatchExacto.Location = New System.Drawing.Point(264, 347)
        Me.Chk_Seleccionar_SinMatchExacto.Name = "Chk_Seleccionar_SinMatchExacto"
        Me.Chk_Seleccionar_SinMatchExacto.Size = New System.Drawing.Size(163, 23)
        Me.Chk_Seleccionar_SinMatchExacto.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Seleccionar_SinMatchExacto.TabIndex = 201
        Me.Chk_Seleccionar_SinMatchExacto.Text = "Seleccionar Sin Match Exacto"
        '
        'Btn_Ver_Documento
        '
        Me.Btn_Ver_Documento.Image = CType(resources.GetObject("Btn_Ver_Documento.Image"), System.Drawing.Image)
        Me.Btn_Ver_Documento.ImageAlt = CType(resources.GetObject("Btn_Ver_Documento.ImageAlt"), System.Drawing.Image)
        Me.Btn_Ver_Documento.Name = "Btn_Ver_Documento"
        Me.Btn_Ver_Documento.Text = "Ver documento"
        '
        'Frm_CruceAntiNoVinculados
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1158, 637)
        Me.Controls.Add(Me.Chk_Seleccionar_SinMatchExacto)
        Me.Controls.Add(Me.Chk_VerSoloSinMatch)
        Me.Controls.Add(Me.Chk_MarcarSoloMatchExactos)
        Me.Controls.Add(Me.Chk_SoloMatchFacVencidas)
        Me.Controls.Add(Me.Chk_Fecha_Asignacion)
        Me.Controls.Add(Me.GroupPanel4)
        Me.Controls.Add(Me.GroupPanel2)
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
        Me.GroupPanel2.ResumeLayout(False)
        Me.GroupPanel4.ResumeLayout(False)
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
    Friend WithEvents GroupPanel2 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Lbl_TotalSeleccion As DevComponents.DotNetBar.LabelX
    Friend WithEvents GroupPanel4 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Lbl_TotalAnticipos As DevComponents.DotNetBar.LabelX
    Friend WithEvents Chk_Fecha_Asignacion As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Chk_SoloMatchFacVencidas As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Lbl_Vendedor As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Chk_MarcarSoloMatchExactos As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Chk_VerSoloSinMatch As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Lbl_ResumenFacturasCruce As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX6 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Btn_DesbloquearPago As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_BloquearPago As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Chk_Seleccionar_SinMatchExacto As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Btn_InfoBloqueo As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Ver_Documento As DevComponents.DotNetBar.ButtonItem
End Class
