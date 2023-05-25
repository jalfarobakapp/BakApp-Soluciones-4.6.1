<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_St_Documento
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
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_St_Documento))
        Me.GroupPanel13 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Grilla = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Txt_Maquina = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Txt_Marca = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Txt_Modelo = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Txt_Categoria = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.Btn_Tipo_Maquina = New DevComponents.DotNetBar.ButtonX()
        Me.Btn_Marca = New DevComponents.DotNetBar.ButtonX()
        Me.Btn_Modelo = New DevComponents.DotNetBar.ButtonX()
        Me.Btn_Categorias = New DevComponents.DotNetBar.ButtonX()
        Me.LabelX12 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX11 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_Nro_Serie = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX17 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_Producto = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Btn_Producto = New DevComponents.DotNetBar.ButtonX()
        Me.Grupo_Chk_Tipo_Reparacion = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.Chk_Serv_Demostracion_Maquina = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Btn_Documento_Garantia = New DevComponents.DotNetBar.ButtonX()
        Me.Chk_Serv_Garantia = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Chk_Serv_Mantenimiento_Preventivo = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Chk_Serv_Recoleccion = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Chk_Serv_Presupuesto_Pre_Aprobado = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Chk_Serv_Mantenimiento_Correctivo = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Chk_Serv_Reparacion_Stock = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Chk_Serv_Domicilio = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Btn_Direccion_Servicio = New DevComponents.DotNetBar.ButtonX()
        Me.GroupPanel2 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Txt_Defecto_segun_cliente = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX10 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX8 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_Nota = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Progeso_Gestion = New DevComponents.DotNetBar.ProgressSteps()
        Me.Estado_01_Ingreso = New DevComponents.DotNetBar.StepItem()
        Me.Estado_02_Asignar_Tecnico = New DevComponents.DotNetBar.StepItem()
        Me.Estado_03_Presupuesto = New DevComponents.DotNetBar.StepItem()
        Me.Estado_04_Cotizacion = New DevComponents.DotNetBar.StepItem()
        Me.Estado_05_Reparacion_Cierre = New DevComponents.DotNetBar.StepItem()
        Me.Estado_06_Aviso = New DevComponents.DotNetBar.StepItem()
        Me.Estado_07_Entrega = New DevComponents.DotNetBar.StepItem()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.Bar2 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Grabar = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Editar = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Cancelar = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Anular = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Check_In = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Cerrar_OT = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Imprimir = New DevComponents.DotNetBar.ButtonItem()
        Me.Imagenes_32x32 = New System.Windows.Forms.ImageList(Me.components)
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Btn_Contacto = New DevComponents.DotNetBar.ButtonX()
        Me.Txt_Nombre_Contacto = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX9 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_Email_Contacto = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX7 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_Telefono_Contacto = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX6 = New DevComponents.DotNetBar.LabelX()
        Me.ContextMenuBar1 = New DevComponents.DotNetBar.ContextMenuBar()
        Me.Menu_Contextual_Garantia = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Garantia_Ver_Documento = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Garantia_Agregar_Documento = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Garantia_Cambiar_Documento = New DevComponents.DotNetBar.ButtonItem()
        Me.Menu_Contextual_Impresion = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Imprimir_Acta_ingreso = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Imprimir_Evaluacion_Tecnico = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Imprimir_Reporte_Final = New DevComponents.DotNetBar.ButtonItem()
        Me.Menu_Contextual_Documentos_Grarantia = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Documento_Sistema = New DevComponents.DotNetBar.ButtonItem()
        Me.Documento_Externo = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Doc_Externo_Boleta = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Doc_Externo_Factura = New DevComponents.DotNetBar.ButtonItem()
        Me.Menu_Contextual_GRP = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_GRP_Ver_Documento = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_GRP_Crear_Guia = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_GRP_Quitar = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_GRP_Asociar = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Grabar_Y_Cerrar = New DevComponents.DotNetBar.Command(Me.components)
        Me.Btn_GAF = New DevComponents.DotNetBar.Command(Me.components)
        Me.Tabs_Producto = New DevComponents.DotNetBar.SuperTabControl()
        Me.SuperTabControlPanel1 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.GroupPanel3 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel()
        Me.ButtonX2 = New DevComponents.DotNetBar.ButtonX()
        Me.Lbl_GRP = New DevComponents.DotNetBar.LabelX()
        Me.LabelX19 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX20 = New DevComponents.DotNetBar.LabelX()
        Me.Lbl_Familia = New DevComponents.DotNetBar.LabelX()
        Me.Lbl_Super_Familia = New DevComponents.DotNetBar.LabelX()
        Me.Lbl_Marca = New DevComponents.DotNetBar.LabelX()
        Me.LabelX21 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX22 = New DevComponents.DotNetBar.LabelX()
        Me.Lbl_Clas_Libre = New DevComponents.DotNetBar.LabelX()
        Me.Lbl_Rubro = New DevComponents.DotNetBar.LabelX()
        Me.LabelX23 = New DevComponents.DotNetBar.LabelX()
        Me.Lbl_Sub_Familia = New DevComponents.DotNetBar.LabelX()
        Me.LabelX24 = New DevComponents.DotNetBar.LabelX()
        Me.Btn_Ver_GRP_PRE = New DevComponents.DotNetBar.ButtonX()
        Me.Tab_Producto = New DevComponents.DotNetBar.SuperTabItem()
        Me.SuperTabControlPanel2 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.GroupPanel4 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Tab_Maquina = New DevComponents.DotNetBar.SuperTabItem()
        Me.Highlighter1 = New DevComponents.DotNetBar.Validator.Highlighter()
        Me.GroupPanel13.SuspendLayout()
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Grupo_Chk_Tipo_Reparacion.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.GroupPanel2.SuspendLayout()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel1.SuspendLayout()
        CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Tabs_Producto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Tabs_Producto.SuspendLayout()
        Me.SuperTabControlPanel1.SuspendLayout()
        Me.GroupPanel3.SuspendLayout()
        Me.TableLayoutPanel4.SuspendLayout()
        Me.SuperTabControlPanel2.SuspendLayout()
        Me.GroupPanel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupPanel13
        '
        Me.GroupPanel13.BackColor = System.Drawing.Color.White
        Me.GroupPanel13.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel13.Controls.Add(Me.Grilla)
        Me.GroupPanel13.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel13.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.GroupPanel13.Location = New System.Drawing.Point(12, 2)
        Me.GroupPanel13.Name = "GroupPanel13"
        Me.GroupPanel13.Size = New System.Drawing.Size(774, 53)
        '
        '
        '
        Me.GroupPanel13.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.GroupPanel13.Style.BackColorGradientAngle = 90
        Me.GroupPanel13.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.GroupPanel13.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel13.Style.BorderBottomWidth = 1
        Me.GroupPanel13.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupPanel13.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel13.Style.BorderLeftWidth = 1
        Me.GroupPanel13.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel13.Style.BorderRightWidth = 1
        Me.GroupPanel13.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel13.Style.BorderTopWidth = 1
        Me.GroupPanel13.Style.CornerDiameter = 4
        Me.GroupPanel13.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanel13.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanel13.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GroupPanel13.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupPanel13.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanel13.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanel13.TabIndex = 79
        '
        'Grilla
        '
        Me.Grilla.AllowUserToAddRows = False
        Me.Grilla.AllowUserToDeleteRows = False
        Me.Grilla.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        DataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle10
        Me.Grilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        DataGridViewCellStyle11.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Grilla.DefaultCellStyle = DataGridViewCellStyle11
        Me.Grilla.EnableHeadersVisualStyles = False
        Me.Grilla.GridColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.Grilla.Location = New System.Drawing.Point(3, 3)
        Me.Grilla.Name = "Grilla"
        Me.Grilla.ReadOnly = True
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        DataGridViewCellStyle12.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla.RowHeadersDefaultCellStyle = DataGridViewCellStyle12
        Me.Grilla.RowHeadersVisible = False
        Me.Grilla.RowTemplate.Height = 25
        Me.Grilla.Size = New System.Drawing.Size(762, 39)
        Me.Grilla.TabIndex = 0
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.15175!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 69.6498!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.392996!))
        Me.TableLayoutPanel1.Controls.Add(Me.Txt_Maquina, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Txt_Marca, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Txt_Modelo, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Txt_Categoria, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelX2, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelX5, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelX1, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelX3, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.Btn_Tipo_Maquina, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Btn_Marca, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Btn_Modelo, 2, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Btn_Categorias, 2, 3)
        Me.TableLayoutPanel1.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 4
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(518, 117)
        Me.TableLayoutPanel1.TabIndex = 68
        '
        'Txt_Maquina
        '
        Me.Txt_Maquina.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Maquina.Border.Class = "TextBoxBorder"
        Me.Txt_Maquina.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Maquina.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_Maquina.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Maquina.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Txt_Maquina.FocusHighlightEnabled = True
        Me.Txt_Maquina.ForeColor = System.Drawing.Color.Black
        Me.Txt_Maquina.Location = New System.Drawing.Point(122, 3)
        Me.Txt_Maquina.Name = "Txt_Maquina"
        Me.Txt_Maquina.Size = New System.Drawing.Size(351, 22)
        Me.Txt_Maquina.TabIndex = 63
        '
        'Txt_Marca
        '
        Me.Txt_Marca.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Marca.Border.Class = "TextBoxBorder"
        Me.Txt_Marca.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Marca.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_Marca.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Marca.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Txt_Marca.FocusHighlightEnabled = True
        Me.Txt_Marca.ForeColor = System.Drawing.Color.Black
        Me.Txt_Marca.Location = New System.Drawing.Point(122, 32)
        Me.Txt_Marca.Name = "Txt_Marca"
        Me.Txt_Marca.Size = New System.Drawing.Size(351, 22)
        Me.Txt_Marca.TabIndex = 68
        '
        'Txt_Modelo
        '
        Me.Txt_Modelo.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Modelo.Border.Class = "TextBoxBorder"
        Me.Txt_Modelo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Modelo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_Modelo.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Modelo.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Txt_Modelo.FocusHighlightEnabled = True
        Me.Txt_Modelo.ForeColor = System.Drawing.Color.Black
        Me.Txt_Modelo.Location = New System.Drawing.Point(122, 61)
        Me.Txt_Modelo.Name = "Txt_Modelo"
        Me.Txt_Modelo.Size = New System.Drawing.Size(351, 22)
        Me.Txt_Modelo.TabIndex = 88
        '
        'Txt_Categoria
        '
        Me.Txt_Categoria.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Categoria.Border.Class = "TextBoxBorder"
        Me.Txt_Categoria.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Categoria.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_Categoria.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Categoria.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Txt_Categoria.FocusHighlightEnabled = True
        Me.Txt_Categoria.ForeColor = System.Drawing.Color.Black
        Me.Txt_Categoria.Location = New System.Drawing.Point(122, 90)
        Me.Txt_Categoria.Name = "Txt_Categoria"
        Me.Txt_Categoria.Size = New System.Drawing.Size(351, 22)
        Me.Txt_Categoria.TabIndex = 88
        '
        'LabelX2
        '
        Me.LabelX2.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX2.ForeColor = System.Drawing.Color.Black
        Me.LabelX2.Location = New System.Drawing.Point(3, 3)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(102, 19)
        Me.LabelX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.LabelX2.TabIndex = 64
        Me.LabelX2.Text = "Tipo de maquina"
        '
        'LabelX5
        '
        Me.LabelX5.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX5.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX5.ForeColor = System.Drawing.Color.Black
        Me.LabelX5.Location = New System.Drawing.Point(3, 32)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.Size = New System.Drawing.Size(89, 19)
        Me.LabelX5.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.LabelX5.TabIndex = 44
        Me.LabelX5.Text = "Marca"
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX1.ForeColor = System.Drawing.Color.Black
        Me.LabelX1.Location = New System.Drawing.Point(3, 61)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(89, 19)
        Me.LabelX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.LabelX1.TabIndex = 61
        Me.LabelX1.Text = "Modelo"
        '
        'LabelX3
        '
        Me.LabelX3.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX3.ForeColor = System.Drawing.Color.Black
        Me.LabelX3.Location = New System.Drawing.Point(3, 90)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(89, 19)
        Me.LabelX3.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.LabelX3.TabIndex = 66
        Me.LabelX3.Text = "Categoría "
        '
        'Btn_Tipo_Maquina
        '
        Me.Btn_Tipo_Maquina.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Tipo_Maquina.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Tipo_Maquina.Image = CType(resources.GetObject("Btn_Tipo_Maquina.Image"), System.Drawing.Image)
        Me.Btn_Tipo_Maquina.Location = New System.Drawing.Point(482, 3)
        Me.Btn_Tipo_Maquina.Name = "Btn_Tipo_Maquina"
        Me.Btn_Tipo_Maquina.Size = New System.Drawing.Size(28, 19)
        Me.Btn_Tipo_Maquina.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Tipo_Maquina.TabIndex = 88
        Me.Btn_Tipo_Maquina.Tooltip = "Buscar Tipo de Maquina"
        '
        'Btn_Marca
        '
        Me.Btn_Marca.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Marca.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Marca.Image = CType(resources.GetObject("Btn_Marca.Image"), System.Drawing.Image)
        Me.Btn_Marca.Location = New System.Drawing.Point(482, 32)
        Me.Btn_Marca.Name = "Btn_Marca"
        Me.Btn_Marca.Size = New System.Drawing.Size(28, 19)
        Me.Btn_Marca.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Marca.TabIndex = 59
        Me.Btn_Marca.Tooltip = "Buscar Marca"
        '
        'Btn_Modelo
        '
        Me.Btn_Modelo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Modelo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Modelo.Image = CType(resources.GetObject("Btn_Modelo.Image"), System.Drawing.Image)
        Me.Btn_Modelo.Location = New System.Drawing.Point(482, 61)
        Me.Btn_Modelo.Name = "Btn_Modelo"
        Me.Btn_Modelo.Size = New System.Drawing.Size(28, 19)
        Me.Btn_Modelo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Modelo.TabIndex = 62
        Me.Btn_Modelo.Tooltip = "Buscar Modelo"
        '
        'Btn_Categorias
        '
        Me.Btn_Categorias.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Categorias.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Categorias.Image = CType(resources.GetObject("Btn_Categorias.Image"), System.Drawing.Image)
        Me.Btn_Categorias.Location = New System.Drawing.Point(482, 90)
        Me.Btn_Categorias.Name = "Btn_Categorias"
        Me.Btn_Categorias.Size = New System.Drawing.Size(28, 18)
        Me.Btn_Categorias.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Categorias.TabIndex = 67
        Me.Btn_Categorias.Tooltip = "Buscar Categoría "
        '
        'LabelX12
        '
        Me.LabelX12.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX12.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX12.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX12.ForeColor = System.Drawing.Color.Black
        Me.LabelX12.Location = New System.Drawing.Point(5, 83)
        Me.LabelX12.Name = "LabelX12"
        Me.LabelX12.Size = New System.Drawing.Size(51, 19)
        Me.LabelX12.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.LabelX12.TabIndex = 89
        Me.LabelX12.Text = "GRP"
        '
        'LabelX11
        '
        Me.LabelX11.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX11.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX11.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX11.ForeColor = System.Drawing.Color.Black
        Me.LabelX11.Location = New System.Drawing.Point(6, 6)
        Me.LabelX11.Name = "LabelX11"
        Me.LabelX11.Size = New System.Drawing.Size(89, 19)
        Me.LabelX11.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.LabelX11.TabIndex = 88
        Me.LabelX11.Text = "Producto"
        '
        'Txt_Nro_Serie
        '
        Me.Txt_Nro_Serie.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Nro_Serie.Border.Class = "TextBoxBorder"
        Me.Txt_Nro_Serie.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Nro_Serie.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_Nro_Serie.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Nro_Serie.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Txt_Nro_Serie.ForeColor = System.Drawing.Color.Black
        Me.Highlighter1.SetHighlightOnFocus(Me.Txt_Nro_Serie, True)
        Me.Txt_Nro_Serie.Location = New System.Drawing.Point(183, 246)
        Me.Txt_Nro_Serie.Name = "Txt_Nro_Serie"
        Me.Txt_Nro_Serie.Size = New System.Drawing.Size(359, 22)
        Me.Txt_Nro_Serie.TabIndex = 9
        '
        'LabelX17
        '
        Me.LabelX17.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX17.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX17.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX17.ForeColor = System.Drawing.Color.Black
        Me.LabelX17.Location = New System.Drawing.Point(12, 246)
        Me.LabelX17.Name = "LabelX17"
        Me.LabelX17.Size = New System.Drawing.Size(174, 18)
        Me.LabelX17.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.LabelX17.TabIndex = 48
        Me.LabelX17.Text = "Número (Serie/Chasis/Placa)"
        '
        'Txt_Producto
        '
        Me.Txt_Producto.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Producto.Border.Class = "TextBoxBorder"
        Me.Txt_Producto.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Producto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_Producto.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Producto.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Txt_Producto.FocusHighlightEnabled = True
        Me.Txt_Producto.ForeColor = System.Drawing.Color.Black
        Me.Txt_Producto.Location = New System.Drawing.Point(71, 5)
        Me.Txt_Producto.Name = "Txt_Producto"
        Me.Txt_Producto.ReadOnly = True
        Me.Txt_Producto.Size = New System.Drawing.Size(410, 22)
        Me.Txt_Producto.TabIndex = 88
        Me.Txt_Producto.WatermarkText = "DEBE INGRESAR EL PRODUCTO DEL CLIENTE..."
        '
        'Btn_Producto
        '
        Me.Btn_Producto.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Producto.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Producto.Image = CType(resources.GetObject("Btn_Producto.Image"), System.Drawing.Image)
        Me.Btn_Producto.Location = New System.Drawing.Point(487, 5)
        Me.Btn_Producto.Name = "Btn_Producto"
        Me.Btn_Producto.Size = New System.Drawing.Size(34, 22)
        Me.Btn_Producto.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Producto.TabIndex = 90
        Me.Btn_Producto.Tooltip = "Buscar Categoría "
        '
        'Grupo_Chk_Tipo_Reparacion
        '
        Me.Grupo_Chk_Tipo_Reparacion.BackColor = System.Drawing.Color.White
        Me.Grupo_Chk_Tipo_Reparacion.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Grupo_Chk_Tipo_Reparacion.Controls.Add(Me.TableLayoutPanel2)
        Me.Grupo_Chk_Tipo_Reparacion.DisabledBackColor = System.Drawing.Color.Empty
        Me.Grupo_Chk_Tipo_Reparacion.Location = New System.Drawing.Point(548, 61)
        Me.Grupo_Chk_Tipo_Reparacion.Name = "Grupo_Chk_Tipo_Reparacion"
        Me.Grupo_Chk_Tipo_Reparacion.Size = New System.Drawing.Size(238, 209)
        '
        '
        '
        Me.Grupo_Chk_Tipo_Reparacion.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Grupo_Chk_Tipo_Reparacion.Style.BackColorGradientAngle = 90
        Me.Grupo_Chk_Tipo_Reparacion.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Grupo_Chk_Tipo_Reparacion.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Chk_Tipo_Reparacion.Style.BorderBottomWidth = 1
        Me.Grupo_Chk_Tipo_Reparacion.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.Grupo_Chk_Tipo_Reparacion.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Chk_Tipo_Reparacion.Style.BorderLeftWidth = 1
        Me.Grupo_Chk_Tipo_Reparacion.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Chk_Tipo_Reparacion.Style.BorderRightWidth = 1
        Me.Grupo_Chk_Tipo_Reparacion.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Chk_Tipo_Reparacion.Style.BorderTopWidth = 1
        Me.Grupo_Chk_Tipo_Reparacion.Style.CornerDiameter = 4
        Me.Grupo_Chk_Tipo_Reparacion.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Grupo_Chk_Tipo_Reparacion.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.Grupo_Chk_Tipo_Reparacion.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.Grupo_Chk_Tipo_Reparacion.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.Grupo_Chk_Tipo_Reparacion.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.Grupo_Chk_Tipo_Reparacion.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Grupo_Chk_Tipo_Reparacion.TabIndex = 82
        Me.Grupo_Chk_Tipo_Reparacion.Text = "Tipo de reparación"
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 44.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.Chk_Serv_Demostracion_Maquina, 0, 7)
        Me.TableLayoutPanel2.Controls.Add(Me.Btn_Documento_Garantia, 1, 6)
        Me.TableLayoutPanel2.Controls.Add(Me.Chk_Serv_Garantia, 0, 6)
        Me.TableLayoutPanel2.Controls.Add(Me.Chk_Serv_Mantenimiento_Preventivo, 0, 5)
        Me.TableLayoutPanel2.Controls.Add(Me.Chk_Serv_Recoleccion, 0, 4)
        Me.TableLayoutPanel2.Controls.Add(Me.Chk_Serv_Presupuesto_Pre_Aprobado, 0, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.Chk_Serv_Mantenimiento_Correctivo, 0, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.Chk_Serv_Reparacion_Stock, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.Chk_Serv_Domicilio, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Btn_Direccion_Servicio, 1, 0)
        Me.TableLayoutPanel2.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 8
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(217, 180)
        Me.TableLayoutPanel2.TabIndex = 68
        '
        'Chk_Serv_Demostracion_Maquina
        '
        '
        '
        '
        Me.Chk_Serv_Demostracion_Maquina.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Serv_Demostracion_Maquina.CheckBoxImageChecked = CType(resources.GetObject("Chk_Serv_Demostracion_Maquina.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_Serv_Demostracion_Maquina.FocusCuesEnabled = False
        Me.Chk_Serv_Demostracion_Maquina.ForeColor = System.Drawing.Color.Black
        Me.Chk_Serv_Demostracion_Maquina.Location = New System.Drawing.Point(3, 157)
        Me.Chk_Serv_Demostracion_Maquina.Name = "Chk_Serv_Demostracion_Maquina"
        Me.Chk_Serv_Demostracion_Maquina.Size = New System.Drawing.Size(167, 20)
        Me.Chk_Serv_Demostracion_Maquina.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Serv_Demostracion_Maquina.TabIndex = 88
        Me.Chk_Serv_Demostracion_Maquina.Text = "Demostración de maquina"
        '
        'Btn_Documento_Garantia
        '
        Me.Btn_Documento_Garantia.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Documento_Garantia.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Documento_Garantia.Image = CType(resources.GetObject("Btn_Documento_Garantia.Image"), System.Drawing.Image)
        Me.Btn_Documento_Garantia.Location = New System.Drawing.Point(176, 135)
        Me.Btn_Documento_Garantia.Name = "Btn_Documento_Garantia"
        Me.Btn_Documento_Garantia.Size = New System.Drawing.Size(38, 16)
        Me.Btn_Documento_Garantia.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Documento_Garantia.TabIndex = 90
        Me.Btn_Documento_Garantia.Tooltip = "Dirección del servicio"
        '
        'Chk_Serv_Garantia
        '
        '
        '
        '
        Me.Chk_Serv_Garantia.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Serv_Garantia.CheckBoxImageChecked = CType(resources.GetObject("Chk_Serv_Garantia.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_Serv_Garantia.FocusCuesEnabled = False
        Me.Chk_Serv_Garantia.ForeColor = System.Drawing.Color.Black
        Me.Chk_Serv_Garantia.Location = New System.Drawing.Point(3, 135)
        Me.Chk_Serv_Garantia.Name = "Chk_Serv_Garantia"
        Me.Chk_Serv_Garantia.Size = New System.Drawing.Size(70, 15)
        Me.Chk_Serv_Garantia.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Serv_Garantia.TabIndex = 70
        Me.Chk_Serv_Garantia.Text = "Garantía"
        '
        'Chk_Serv_Mantenimiento_Preventivo
        '
        '
        '
        '
        Me.Chk_Serv_Mantenimiento_Preventivo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Serv_Mantenimiento_Preventivo.CheckBoxImageChecked = CType(resources.GetObject("Chk_Serv_Mantenimiento_Preventivo.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_Serv_Mantenimiento_Preventivo.FocusCuesEnabled = False
        Me.Chk_Serv_Mantenimiento_Preventivo.ForeColor = System.Drawing.Color.Black
        Me.Chk_Serv_Mantenimiento_Preventivo.Location = New System.Drawing.Point(3, 113)
        Me.Chk_Serv_Mantenimiento_Preventivo.Name = "Chk_Serv_Mantenimiento_Preventivo"
        Me.Chk_Serv_Mantenimiento_Preventivo.Size = New System.Drawing.Size(167, 14)
        Me.Chk_Serv_Mantenimiento_Preventivo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Serv_Mantenimiento_Preventivo.TabIndex = 70
        Me.Chk_Serv_Mantenimiento_Preventivo.Text = "Mantenimiento preventivo"
        '
        'Chk_Serv_Recoleccion
        '
        '
        '
        '
        Me.Chk_Serv_Recoleccion.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Serv_Recoleccion.CheckBoxImageChecked = CType(resources.GetObject("Chk_Serv_Recoleccion.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_Serv_Recoleccion.FocusCuesEnabled = False
        Me.Chk_Serv_Recoleccion.ForeColor = System.Drawing.Color.Black
        Me.Chk_Serv_Recoleccion.Location = New System.Drawing.Point(3, 91)
        Me.Chk_Serv_Recoleccion.Name = "Chk_Serv_Recoleccion"
        Me.Chk_Serv_Recoleccion.Size = New System.Drawing.Size(167, 15)
        Me.Chk_Serv_Recoleccion.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Serv_Recoleccion.TabIndex = 70
        Me.Chk_Serv_Recoleccion.Text = "Servicio de recolección"
        '
        'Chk_Serv_Presupuesto_Pre_Aprobado
        '
        '
        '
        '
        Me.Chk_Serv_Presupuesto_Pre_Aprobado.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Serv_Presupuesto_Pre_Aprobado.CheckBoxImageChecked = CType(resources.GetObject("Chk_Serv_Presupuesto_Pre_Aprobado.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_Serv_Presupuesto_Pre_Aprobado.FocusCuesEnabled = False
        Me.Chk_Serv_Presupuesto_Pre_Aprobado.ForeColor = System.Drawing.Color.Black
        Me.Chk_Serv_Presupuesto_Pre_Aprobado.Location = New System.Drawing.Point(3, 69)
        Me.Chk_Serv_Presupuesto_Pre_Aprobado.Name = "Chk_Serv_Presupuesto_Pre_Aprobado"
        Me.Chk_Serv_Presupuesto_Pre_Aprobado.Size = New System.Drawing.Size(167, 14)
        Me.Chk_Serv_Presupuesto_Pre_Aprobado.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Serv_Presupuesto_Pre_Aprobado.TabIndex = 70
        Me.Chk_Serv_Presupuesto_Pre_Aprobado.Text = "Presupuesto Pre-Aprobado"
        '
        'Chk_Serv_Mantenimiento_Correctivo
        '
        '
        '
        '
        Me.Chk_Serv_Mantenimiento_Correctivo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Serv_Mantenimiento_Correctivo.CheckBoxImageChecked = CType(resources.GetObject("Chk_Serv_Mantenimiento_Correctivo.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_Serv_Mantenimiento_Correctivo.FocusCuesEnabled = False
        Me.Chk_Serv_Mantenimiento_Correctivo.ForeColor = System.Drawing.Color.Black
        Me.Chk_Serv_Mantenimiento_Correctivo.Location = New System.Drawing.Point(3, 47)
        Me.Chk_Serv_Mantenimiento_Correctivo.Name = "Chk_Serv_Mantenimiento_Correctivo"
        Me.Chk_Serv_Mantenimiento_Correctivo.Size = New System.Drawing.Size(167, 13)
        Me.Chk_Serv_Mantenimiento_Correctivo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Serv_Mantenimiento_Correctivo.TabIndex = 70
        Me.Chk_Serv_Mantenimiento_Correctivo.Text = "Mantenimiento correctivo"
        '
        'Chk_Serv_Reparacion_Stock
        '
        '
        '
        '
        Me.Chk_Serv_Reparacion_Stock.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Serv_Reparacion_Stock.CheckBoxImageChecked = CType(resources.GetObject("Chk_Serv_Reparacion_Stock.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_Serv_Reparacion_Stock.FocusCuesEnabled = False
        Me.Chk_Serv_Reparacion_Stock.ForeColor = System.Drawing.Color.Black
        Me.Chk_Serv_Reparacion_Stock.Location = New System.Drawing.Point(3, 25)
        Me.Chk_Serv_Reparacion_Stock.Name = "Chk_Serv_Reparacion_Stock"
        Me.Chk_Serv_Reparacion_Stock.Size = New System.Drawing.Size(167, 14)
        Me.Chk_Serv_Reparacion_Stock.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Serv_Reparacion_Stock.TabIndex = 70
        Me.Chk_Serv_Reparacion_Stock.Text = "Reparación de Stock (Interno)"
        '
        'Chk_Serv_Domicilio
        '
        '
        '
        '
        Me.Chk_Serv_Domicilio.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Serv_Domicilio.CheckBoxImageChecked = CType(resources.GetObject("Chk_Serv_Domicilio.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_Serv_Domicilio.FocusCuesEnabled = False
        Me.Chk_Serv_Domicilio.ForeColor = System.Drawing.Color.Black
        Me.Chk_Serv_Domicilio.Location = New System.Drawing.Point(3, 3)
        Me.Chk_Serv_Domicilio.Name = "Chk_Serv_Domicilio"
        Me.Chk_Serv_Domicilio.Size = New System.Drawing.Size(167, 16)
        Me.Chk_Serv_Domicilio.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Serv_Domicilio.TabIndex = 69
        Me.Chk_Serv_Domicilio.Text = "Servicio a domicilio"
        '
        'Btn_Direccion_Servicio
        '
        Me.Btn_Direccion_Servicio.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Direccion_Servicio.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Direccion_Servicio.Image = CType(resources.GetObject("Btn_Direccion_Servicio.Image"), System.Drawing.Image)
        Me.Btn_Direccion_Servicio.Location = New System.Drawing.Point(176, 3)
        Me.Btn_Direccion_Servicio.Name = "Btn_Direccion_Servicio"
        Me.Btn_Direccion_Servicio.Size = New System.Drawing.Size(38, 16)
        Me.Btn_Direccion_Servicio.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Direccion_Servicio.TabIndex = 89
        Me.Btn_Direccion_Servicio.Tooltip = "Dirección del servicio"
        '
        'GroupPanel2
        '
        Me.GroupPanel2.BackColor = System.Drawing.Color.White
        Me.GroupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel2.Controls.Add(Me.Txt_Defecto_segun_cliente)
        Me.GroupPanel2.Controls.Add(Me.LabelX10)
        Me.GroupPanel2.Controls.Add(Me.LabelX8)
        Me.GroupPanel2.Controls.Add(Me.Txt_Nota)
        Me.GroupPanel2.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel2.Location = New System.Drawing.Point(12, 343)
        Me.GroupPanel2.Name = "GroupPanel2"
        Me.GroupPanel2.Size = New System.Drawing.Size(774, 93)
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
        Me.GroupPanel2.TabIndex = 83
        '
        'Txt_Defecto_segun_cliente
        '
        Me.Txt_Defecto_segun_cliente.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Defecto_segun_cliente.Border.Class = "TextBoxBorder"
        Me.Txt_Defecto_segun_cliente.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Defecto_segun_cliente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_Defecto_segun_cliente.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Defecto_segun_cliente.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Txt_Defecto_segun_cliente.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Defecto_segun_cliente.ForeColor = System.Drawing.Color.Black
        Me.Highlighter1.SetHighlightOnFocus(Me.Txt_Defecto_segun_cliente, True)
        Me.Txt_Defecto_segun_cliente.Location = New System.Drawing.Point(152, 3)
        Me.Txt_Defecto_segun_cliente.MaxLength = 1000
        Me.Txt_Defecto_segun_cliente.Multiline = True
        Me.Txt_Defecto_segun_cliente.Name = "Txt_Defecto_segun_cliente"
        Me.Txt_Defecto_segun_cliente.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.Txt_Defecto_segun_cliente.Size = New System.Drawing.Size(613, 53)
        Me.Txt_Defecto_segun_cliente.TabIndex = 64
        '
        'LabelX10
        '
        Me.LabelX10.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX10.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX10.Dock = System.Windows.Forms.DockStyle.Top
        Me.LabelX10.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX10.ForeColor = System.Drawing.Color.Black
        Me.LabelX10.Location = New System.Drawing.Point(0, 0)
        Me.LabelX10.Name = "LabelX10"
        Me.LabelX10.Size = New System.Drawing.Size(768, 23)
        Me.LabelX10.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.LabelX10.TabIndex = 72
        Me.LabelX10.Text = "Defecto según el cliente"
        '
        'LabelX8
        '
        Me.LabelX8.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX8.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX8.ForeColor = System.Drawing.Color.Black
        Me.LabelX8.Location = New System.Drawing.Point(3, 61)
        Me.LabelX8.Name = "LabelX8"
        Me.LabelX8.Size = New System.Drawing.Size(42, 23)
        Me.LabelX8.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.LabelX8.TabIndex = 71
        Me.LabelX8.Text = "Nota :"
        '
        'Txt_Nota
        '
        Me.Txt_Nota.BackColor = System.Drawing.Color.White
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
        Me.Txt_Nota.Location = New System.Drawing.Point(152, 62)
        Me.Txt_Nota.MaxLength = 1000
        Me.Txt_Nota.Name = "Txt_Nota"
        Me.Txt_Nota.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.Txt_Nota.Size = New System.Drawing.Size(613, 22)
        Me.Txt_Nota.TabIndex = 64
        '
        'Progeso_Gestion
        '
        Me.Progeso_Gestion.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Progeso_Gestion.AutoSize = True
        Me.Progeso_Gestion.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Progeso_Gestion.BackgroundStyle.Class = "ProgressSteps"
        Me.Progeso_Gestion.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Progeso_Gestion.ContainerControlProcessDialogKey = True
        Me.Progeso_Gestion.ForeColor = System.Drawing.Color.Black
        Me.Progeso_Gestion.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Estado_01_Ingreso, Me.Estado_02_Asignar_Tecnico, Me.Estado_03_Presupuesto, Me.Estado_04_Cotizacion, Me.Estado_05_Reparacion_Cierre, Me.Estado_06_Aviso, Me.Estado_07_Entrega})
        Me.Progeso_Gestion.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.Progeso_Gestion.Location = New System.Drawing.Point(12, 473)
        Me.Progeso_Gestion.Name = "Progeso_Gestion"
        Me.Progeso_Gestion.Size = New System.Drawing.Size(774, 45)
        Me.Progeso_Gestion.TabIndex = 84
        '
        'Estado_01_Ingreso
        '
        Me.Estado_01_Ingreso.HotTracking = False
        Me.Estado_01_Ingreso.MinimumSize = New System.Drawing.Size(100, 0)
        Me.Estado_01_Ingreso.Name = "Estado_01_Ingreso"
        Me.Estado_01_Ingreso.SymbolSize = 10.0!
        Me.Estado_01_Ingreso.Text = "<font size=""+2""><b>Ingreso</b></font><br/><font size=""-1"">Espera<br/>1ra etapa</f" &
    "ont>"
        Me.Estado_01_Ingreso.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Center
        Me.Estado_01_Ingreso.Tooltip = "Creación de Orden de trabajo"
        '
        'Estado_02_Asignar_Tecnico
        '
        Me.Estado_02_Asignar_Tecnico.HotTracking = False
        Me.Estado_02_Asignar_Tecnico.MinimumSize = New System.Drawing.Size(100, 0)
        Me.Estado_02_Asignar_Tecnico.Name = "Estado_02_Asignar_Tecnico"
        Me.Estado_02_Asignar_Tecnico.SymbolSize = 13.0!
        Me.Estado_02_Asignar_Tecnico.Text = "<font size=""+2""><b>Asignar</b></font><br/><font size=""-1"">...<br/>2da etapa</font" &
    ">"
        Me.Estado_02_Asignar_Tecnico.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Center
        Me.Estado_02_Asignar_Tecnico.Tooltip = "Asignación de técnico"
        '
        'Estado_03_Presupuesto
        '
        Me.Estado_03_Presupuesto.HotTracking = False
        Me.Estado_03_Presupuesto.Name = "Estado_03_Presupuesto"
        Me.Estado_03_Presupuesto.SymbolSize = 13.0!
        Me.Estado_03_Presupuesto.Text = "<font size=""+2""><b>Presupuesto</b></font><br/><font size=""-1"">...<br/>3ra etapa</" &
    "font>"
        '
        'Estado_04_Cotizacion
        '
        Me.Estado_04_Cotizacion.HotTracking = False
        Me.Estado_04_Cotizacion.MinimumSize = New System.Drawing.Size(100, 0)
        Me.Estado_04_Cotizacion.Name = "Estado_04_Cotizacion"
        Me.Estado_04_Cotizacion.SymbolSize = 13.0!
        Me.Estado_04_Cotizacion.Text = "<font size=""+2""><b>Cotización</b></font><br/><font size=""-1"">...<br/>4ta etapa</f" &
    "ont>"
        Me.Estado_04_Cotizacion.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Center
        Me.Estado_04_Cotizacion.Tooltip = "Generación de cotizacion"
        '
        'Estado_05_Reparacion_Cierre
        '
        Me.Estado_05_Reparacion_Cierre.HotTracking = False
        Me.Estado_05_Reparacion_Cierre.Name = "Estado_05_Reparacion_Cierre"
        Me.Estado_05_Reparacion_Cierre.SymbolSize = 13.0!
        Me.Estado_05_Reparacion_Cierre.Text = "<font size=""+2""><b>Reparación</b></font><br/><font size=""-1"">...<br/>5ta etapa</f" &
    "ont>"
        '
        'Estado_06_Aviso
        '
        Me.Estado_06_Aviso.HotTracking = False
        Me.Estado_06_Aviso.Name = "Estado_06_Aviso"
        Me.Estado_06_Aviso.SymbolSize = 13.0!
        Me.Estado_06_Aviso.Text = "<font size=""+2""><b>Aviso</b></font><br/><font size=""-1"">...<br/> 6ta Etapa</font>" &
    ""
        '
        'Estado_07_Entrega
        '
        Me.Estado_07_Entrega.HotTracking = False
        Me.Estado_07_Entrega.Name = "Estado_07_Entrega"
        Me.Estado_07_Entrega.SymbolSize = 13.0!
        Me.Estado_07_Entrega.Text = "<font size=""+2""><b>Entrega/Facturación</b></font><br/><font size=""-1"">...<br/>7ma" &
    " Etapa</font>"
        '
        'LabelX4
        '
        Me.LabelX4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LabelX4.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.ForeColor = System.Drawing.Color.Black
        Me.LabelX4.Location = New System.Drawing.Point(12, 444)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(291, 23)
        Me.LabelX4.TabIndex = 85
        Me.LabelX4.Text = "<font color=""#4E5D30""><b><font color=""#22B14C""><font color=""#0072BC"">WORKFLOW</fo" &
    "nt></font></b></font> (Flujo de trabajo)"
        '
        'Bar2
        '
        Me.Bar2.AntiAlias = True
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Grabar, Me.Btn_Editar, Me.Btn_Cancelar, Me.Btn_Anular, Me.Btn_Check_In, Me.Btn_Cerrar_OT, Me.Btn_Imprimir})
        Me.Bar2.Location = New System.Drawing.Point(0, 544)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(798, 41)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Bar2.TabIndex = 86
        Me.Bar2.TabStop = False
        Me.Bar2.Text = "Bar2"
        '
        'Btn_Grabar
        '
        Me.Btn_Grabar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Grabar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Grabar.Image = CType(resources.GetObject("Btn_Grabar.Image"), System.Drawing.Image)
        Me.Btn_Grabar.ImageAlt = CType(resources.GetObject("Btn_Grabar.ImageAlt"), System.Drawing.Image)
        Me.Btn_Grabar.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.Btn_Grabar.Name = "Btn_Grabar"
        Me.Btn_Grabar.Tooltip = "Grabar [F4]"
        '
        'Btn_Editar
        '
        Me.Btn_Editar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Editar.FontBold = True
        Me.Btn_Editar.ForeColor = System.Drawing.Color.Red
        Me.Btn_Editar.Image = CType(resources.GetObject("Btn_Editar.Image"), System.Drawing.Image)
        Me.Btn_Editar.ImageAlt = CType(resources.GetObject("Btn_Editar.ImageAlt"), System.Drawing.Image)
        Me.Btn_Editar.Name = "Btn_Editar"
        Me.Btn_Editar.Tooltip = "Editar OT"
        Me.Btn_Editar.Visible = False
        '
        'Btn_Cancelar
        '
        Me.Btn_Cancelar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Cancelar.FontBold = True
        Me.Btn_Cancelar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Cancelar.Image = CType(resources.GetObject("Btn_Cancelar.Image"), System.Drawing.Image)
        Me.Btn_Cancelar.ImageAlt = CType(resources.GetObject("Btn_Cancelar.ImageAlt"), System.Drawing.Image)
        Me.Btn_Cancelar.Name = "Btn_Cancelar"
        Me.Btn_Cancelar.Text = "Cancelar edición"
        Me.Btn_Cancelar.Visible = False
        '
        'Btn_Anular
        '
        Me.Btn_Anular.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Anular.ForeColor = System.Drawing.Color.Black
        Me.Btn_Anular.Image = CType(resources.GetObject("Btn_Anular.Image"), System.Drawing.Image)
        Me.Btn_Anular.ImageAlt = CType(resources.GetObject("Btn_Anular.ImageAlt"), System.Drawing.Image)
        Me.Btn_Anular.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.Btn_Anular.Name = "Btn_Anular"
        Me.Btn_Anular.Tooltip = "Eliminar"
        Me.Btn_Anular.Visible = False
        '
        'Btn_Check_In
        '
        Me.Btn_Check_In.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Check_In.FontBold = True
        Me.Btn_Check_In.ForeColor = System.Drawing.Color.Red
        Me.Btn_Check_In.Image = CType(resources.GetObject("Btn_Check_In.Image"), System.Drawing.Image)
        Me.Btn_Check_In.ImageAlt = CType(resources.GetObject("Btn_Check_In.ImageAlt"), System.Drawing.Image)
        Me.Btn_Check_In.Name = "Btn_Check_In"
        Me.Btn_Check_In.Text = "Check-In"
        '
        'Btn_Cerrar_OT
        '
        Me.Btn_Cerrar_OT.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Cerrar_OT.ForeColor = System.Drawing.Color.Black
        Me.Btn_Cerrar_OT.Image = CType(resources.GetObject("Btn_Cerrar_OT.Image"), System.Drawing.Image)
        Me.Btn_Cerrar_OT.ImageAlt = CType(resources.GetObject("Btn_Cerrar_OT.ImageAlt"), System.Drawing.Image)
        Me.Btn_Cerrar_OT.Name = "Btn_Cerrar_OT"
        Me.Btn_Cerrar_OT.Text = "Cerrar O.T."
        Me.Btn_Cerrar_OT.Tooltip = "Cierra definitivamente la orden de trabajo, no se pueden hacer mas modificaciones" &
    ""
        Me.Btn_Cerrar_OT.Visible = False
        '
        'Btn_Imprimir
        '
        Me.Btn_Imprimir.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Imprimir.ForeColor = System.Drawing.Color.Black
        Me.Btn_Imprimir.Image = CType(resources.GetObject("Btn_Imprimir.Image"), System.Drawing.Image)
        Me.Btn_Imprimir.ImageAlt = CType(resources.GetObject("Btn_Imprimir.ImageAlt"), System.Drawing.Image)
        Me.Btn_Imprimir.Name = "Btn_Imprimir"
        Me.Btn_Imprimir.Tooltip = "Imprimir"
        Me.Btn_Imprimir.Visible = False
        '
        'Imagenes_32x32
        '
        Me.Imagenes_32x32.ImageStream = CType(resources.GetObject("Imagenes_32x32.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.Imagenes_32x32.TransparentColor = System.Drawing.Color.Transparent
        Me.Imagenes_32x32.Images.SetKeyName(0, "warning.png")
        '
        'GroupPanel1
        '
        Me.GroupPanel1.BackColor = System.Drawing.Color.White
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.Btn_Contacto)
        Me.GroupPanel1.Controls.Add(Me.Txt_Nombre_Contacto)
        Me.GroupPanel1.Controls.Add(Me.LabelX9)
        Me.GroupPanel1.Controls.Add(Me.Txt_Email_Contacto)
        Me.GroupPanel1.Controls.Add(Me.LabelX7)
        Me.GroupPanel1.Controls.Add(Me.Txt_Telefono_Contacto)
        Me.GroupPanel1.Controls.Add(Me.LabelX6)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Location = New System.Drawing.Point(12, 276)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(774, 64)
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
        Me.GroupPanel1.TabIndex = 87
        '
        'Btn_Contacto
        '
        Me.Btn_Contacto.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Contacto.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Contacto.Image = CType(resources.GetObject("Btn_Contacto.Image"), System.Drawing.Image)
        Me.Btn_Contacto.ImageAlt = CType(resources.GetObject("Btn_Contacto.ImageAlt"), System.Drawing.Image)
        Me.Btn_Contacto.Location = New System.Drawing.Point(715, 6)
        Me.Btn_Contacto.Name = "Btn_Contacto"
        Me.Btn_Contacto.Size = New System.Drawing.Size(50, 48)
        Me.Btn_Contacto.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Contacto.TabIndex = 74
        Me.Btn_Contacto.Tooltip = "buscar contactos del cliente"
        '
        'Txt_Nombre_Contacto
        '
        Me.Txt_Nombre_Contacto.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Nombre_Contacto.Border.Class = "TextBoxBorder"
        Me.Txt_Nombre_Contacto.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Nombre_Contacto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_Nombre_Contacto.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Nombre_Contacto.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Txt_Nombre_Contacto.ForeColor = System.Drawing.Color.Black
        Me.Highlighter1.SetHighlightOnFocus(Me.Txt_Nombre_Contacto, True)
        Me.Txt_Nombre_Contacto.Location = New System.Drawing.Point(152, 6)
        Me.Txt_Nombre_Contacto.MaxLength = 50
        Me.Txt_Nombre_Contacto.Name = "Txt_Nombre_Contacto"
        Me.Txt_Nombre_Contacto.Size = New System.Drawing.Size(557, 22)
        Me.Txt_Nombre_Contacto.TabIndex = 73
        '
        'LabelX9
        '
        Me.LabelX9.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX9.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX9.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX9.ForeColor = System.Drawing.Color.Black
        Me.LabelX9.Location = New System.Drawing.Point(6, 2)
        Me.LabelX9.Name = "LabelX9"
        Me.LabelX9.Size = New System.Drawing.Size(133, 23)
        Me.LabelX9.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.LabelX9.TabIndex = 72
        Me.LabelX9.Text = "Nombre del contacto"
        '
        'Txt_Email_Contacto
        '
        Me.Txt_Email_Contacto.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Email_Contacto.Border.Class = "TextBoxBorder"
        Me.Txt_Email_Contacto.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Email_Contacto.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower
        Me.Txt_Email_Contacto.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Email_Contacto.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Txt_Email_Contacto.ForeColor = System.Drawing.Color.Black
        Me.Highlighter1.SetHighlightOnFocus(Me.Txt_Email_Contacto, True)
        Me.Txt_Email_Contacto.Location = New System.Drawing.Point(451, 33)
        Me.Txt_Email_Contacto.MaxLength = 50
        Me.Txt_Email_Contacto.Name = "Txt_Email_Contacto"
        Me.Txt_Email_Contacto.Size = New System.Drawing.Size(258, 22)
        Me.Txt_Email_Contacto.TabIndex = 71
        '
        'LabelX7
        '
        Me.LabelX7.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX7.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX7.ForeColor = System.Drawing.Color.Black
        Me.LabelX7.Location = New System.Drawing.Point(335, 32)
        Me.LabelX7.Name = "LabelX7"
        Me.LabelX7.Size = New System.Drawing.Size(110, 23)
        Me.LabelX7.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.LabelX7.TabIndex = 70
        Me.LabelX7.Text = "Email de contacto"
        '
        'Txt_Telefono_Contacto
        '
        Me.Txt_Telefono_Contacto.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Telefono_Contacto.Border.Class = "TextBoxBorder"
        Me.Txt_Telefono_Contacto.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Telefono_Contacto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_Telefono_Contacto.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Telefono_Contacto.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Txt_Telefono_Contacto.ForeColor = System.Drawing.Color.Black
        Me.Highlighter1.SetHighlightOnFocus(Me.Txt_Telefono_Contacto, True)
        Me.Txt_Telefono_Contacto.Location = New System.Drawing.Point(152, 32)
        Me.Txt_Telefono_Contacto.MaxLength = 20
        Me.Txt_Telefono_Contacto.Name = "Txt_Telefono_Contacto"
        Me.Txt_Telefono_Contacto.Size = New System.Drawing.Size(150, 22)
        Me.Txt_Telefono_Contacto.TabIndex = 69
        '
        'LabelX6
        '
        Me.LabelX6.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX6.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX6.ForeColor = System.Drawing.Color.Black
        Me.LabelX6.Location = New System.Drawing.Point(6, 31)
        Me.LabelX6.Name = "LabelX6"
        Me.LabelX6.Size = New System.Drawing.Size(133, 23)
        Me.LabelX6.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.LabelX6.TabIndex = 65
        Me.LabelX6.Text = "Teléfono de contacto"
        '
        'ContextMenuBar1
        '
        Me.ContextMenuBar1.AntiAlias = True
        Me.ContextMenuBar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ContextMenuBar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Menu_Contextual_Garantia, Me.Menu_Contextual_Impresion, Me.Menu_Contextual_Documentos_Grarantia, Me.Menu_Contextual_GRP})
        Me.ContextMenuBar1.Location = New System.Drawing.Point(202, 442)
        Me.ContextMenuBar1.Name = "ContextMenuBar1"
        Me.ContextMenuBar1.Size = New System.Drawing.Size(586, 25)
        Me.ContextMenuBar1.Stretch = True
        Me.ContextMenuBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ContextMenuBar1.TabIndex = 65
        Me.ContextMenuBar1.TabStop = False
        Me.ContextMenuBar1.Text = "ContextMenuBar1"
        '
        'Menu_Contextual_Garantia
        '
        Me.Menu_Contextual_Garantia.AutoExpandOnClick = True
        Me.Menu_Contextual_Garantia.Name = "Menu_Contextual_Garantia"
        Me.Menu_Contextual_Garantia.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Garantia_Ver_Documento, Me.Btn_Garantia_Agregar_Documento, Me.Btn_Garantia_Cambiar_Documento})
        Me.Menu_Contextual_Garantia.Text = "Opciones encabezado"
        '
        'Btn_Garantia_Ver_Documento
        '
        Me.Btn_Garantia_Ver_Documento.Image = CType(resources.GetObject("Btn_Garantia_Ver_Documento.Image"), System.Drawing.Image)
        Me.Btn_Garantia_Ver_Documento.Name = "Btn_Garantia_Ver_Documento"
        Me.Btn_Garantia_Ver_Documento.Text = "Ver documento"
        '
        'Btn_Garantia_Agregar_Documento
        '
        Me.Btn_Garantia_Agregar_Documento.Image = CType(resources.GetObject("Btn_Garantia_Agregar_Documento.Image"), System.Drawing.Image)
        Me.Btn_Garantia_Agregar_Documento.Name = "Btn_Garantia_Agregar_Documento"
        Me.Btn_Garantia_Agregar_Documento.Text = "Agregar documento"
        '
        'Btn_Garantia_Cambiar_Documento
        '
        Me.Btn_Garantia_Cambiar_Documento.Image = CType(resources.GetObject("Btn_Garantia_Cambiar_Documento.Image"), System.Drawing.Image)
        Me.Btn_Garantia_Cambiar_Documento.Name = "Btn_Garantia_Cambiar_Documento"
        Me.Btn_Garantia_Cambiar_Documento.Text = "Cambiar documento"
        '
        'Menu_Contextual_Impresion
        '
        Me.Menu_Contextual_Impresion.AutoExpandOnClick = True
        Me.Menu_Contextual_Impresion.Name = "Menu_Contextual_Impresion"
        Me.Menu_Contextual_Impresion.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Imprimir_Acta_ingreso, Me.Btn_Imprimir_Evaluacion_Tecnico, Me.Btn_Imprimir_Reporte_Final})
        Me.Menu_Contextual_Impresion.Text = "Opciones encabezado"
        '
        'Btn_Imprimir_Acta_ingreso
        '
        Me.Btn_Imprimir_Acta_ingreso.Image = CType(resources.GetObject("Btn_Imprimir_Acta_ingreso.Image"), System.Drawing.Image)
        Me.Btn_Imprimir_Acta_ingreso.Name = "Btn_Imprimir_Acta_ingreso"
        Me.Btn_Imprimir_Acta_ingreso.Text = "Imprimir Acta de Ingreso"
        Me.Btn_Imprimir_Acta_ingreso.Visible = False
        '
        'Btn_Imprimir_Evaluacion_Tecnico
        '
        Me.Btn_Imprimir_Evaluacion_Tecnico.Image = CType(resources.GetObject("Btn_Imprimir_Evaluacion_Tecnico.Image"), System.Drawing.Image)
        Me.Btn_Imprimir_Evaluacion_Tecnico.Name = "Btn_Imprimir_Evaluacion_Tecnico"
        Me.Btn_Imprimir_Evaluacion_Tecnico.Text = "Imprimir Evaluación Técnico"
        Me.Btn_Imprimir_Evaluacion_Tecnico.Visible = False
        '
        'Btn_Imprimir_Reporte_Final
        '
        Me.Btn_Imprimir_Reporte_Final.Image = CType(resources.GetObject("Btn_Imprimir_Reporte_Final.Image"), System.Drawing.Image)
        Me.Btn_Imprimir_Reporte_Final.Name = "Btn_Imprimir_Reporte_Final"
        Me.Btn_Imprimir_Reporte_Final.Text = "Imprimir Reporte Final"
        Me.Btn_Imprimir_Reporte_Final.Visible = False
        '
        'Menu_Contextual_Documentos_Grarantia
        '
        Me.Menu_Contextual_Documentos_Grarantia.AutoExpandOnClick = True
        Me.Menu_Contextual_Documentos_Grarantia.Name = "Menu_Contextual_Documentos_Grarantia"
        Me.Menu_Contextual_Documentos_Grarantia.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Documento_Sistema, Me.Documento_Externo})
        Me.Menu_Contextual_Documentos_Grarantia.Text = "Opciones Documentos"
        '
        'Btn_Documento_Sistema
        '
        Me.Btn_Documento_Sistema.Image = CType(resources.GetObject("Btn_Documento_Sistema.Image"), System.Drawing.Image)
        Me.Btn_Documento_Sistema.Name = "Btn_Documento_Sistema"
        Me.Btn_Documento_Sistema.Text = "Documento del sistema"
        Me.Btn_Documento_Sistema.Tooltip = "Buscar documento en base de datos del sistema y linkear"
        '
        'Documento_Externo
        '
        Me.Documento_Externo.Image = CType(resources.GetObject("Documento_Externo.Image"), System.Drawing.Image)
        Me.Documento_Externo.Name = "Documento_Externo"
        Me.Documento_Externo.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Doc_Externo_Boleta, Me.Btn_Doc_Externo_Factura})
        Me.Documento_Externo.Text = "Documento Externo"
        Me.Documento_Externo.Tooltip = "Poner numero de la boleta o factura del cliente"
        '
        'Btn_Doc_Externo_Boleta
        '
        Me.Btn_Doc_Externo_Boleta.Image = CType(resources.GetObject("Btn_Doc_Externo_Boleta.Image"), System.Drawing.Image)
        Me.Btn_Doc_Externo_Boleta.Name = "Btn_Doc_Externo_Boleta"
        Me.Btn_Doc_Externo_Boleta.Text = "BOLETA"
        '
        'Btn_Doc_Externo_Factura
        '
        Me.Btn_Doc_Externo_Factura.Image = CType(resources.GetObject("Btn_Doc_Externo_Factura.Image"), System.Drawing.Image)
        Me.Btn_Doc_Externo_Factura.Name = "Btn_Doc_Externo_Factura"
        Me.Btn_Doc_Externo_Factura.Text = "FACTURA"
        '
        'Menu_Contextual_GRP
        '
        Me.Menu_Contextual_GRP.AutoExpandOnClick = True
        Me.Menu_Contextual_GRP.Name = "Menu_Contextual_GRP"
        Me.Menu_Contextual_GRP.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_GRP_Ver_Documento, Me.Btn_GRP_Crear_Guia, Me.Btn_GRP_Quitar, Me.Btn_GRP_Asociar})
        Me.Menu_Contextual_GRP.Text = "Opciones Documentos"
        '
        'Btn_GRP_Ver_Documento
        '
        Me.Btn_GRP_Ver_Documento.Image = CType(resources.GetObject("Btn_GRP_Ver_Documento.Image"), System.Drawing.Image)
        Me.Btn_GRP_Ver_Documento.Name = "Btn_GRP_Ver_Documento"
        Me.Btn_GRP_Ver_Documento.Text = "Ver GRP"
        Me.Btn_GRP_Ver_Documento.Tooltip = "Ver documento"
        '
        'Btn_GRP_Crear_Guia
        '
        Me.Btn_GRP_Crear_Guia.Image = CType(resources.GetObject("Btn_GRP_Crear_Guia.Image"), System.Drawing.Image)
        Me.Btn_GRP_Crear_Guia.Name = "Btn_GRP_Crear_Guia"
        Me.Btn_GRP_Crear_Guia.Text = "Crear GRP"
        Me.Btn_GRP_Crear_Guia.Tooltip = "Crear GRP para servicio tecnico"
        '
        'Btn_GRP_Quitar
        '
        Me.Btn_GRP_Quitar.Image = CType(resources.GetObject("Btn_GRP_Quitar.Image"), System.Drawing.Image)
        Me.Btn_GRP_Quitar.Name = "Btn_GRP_Quitar"
        Me.Btn_GRP_Quitar.Text = "Quitar GRP"
        Me.Btn_GRP_Quitar.Tooltip = "Ver documento"
        Me.Btn_GRP_Quitar.Visible = False
        '
        'Btn_GRP_Asociar
        '
        Me.Btn_GRP_Asociar.Image = CType(resources.GetObject("Btn_GRP_Asociar.Image"), System.Drawing.Image)
        Me.Btn_GRP_Asociar.Name = "Btn_GRP_Asociar"
        Me.Btn_GRP_Asociar.Text = "Asociar GRP existente"
        Me.Btn_GRP_Asociar.Tooltip = "Poner numero de la boleta o factura del cliente"
        '
        'Btn_Grabar_Y_Cerrar
        '
        Me.Btn_Grabar_Y_Cerrar.Checked = False
        Me.Btn_Grabar_Y_Cerrar.Image = CType(resources.GetObject("Btn_Grabar_Y_Cerrar.Image"), System.Drawing.Image)
        Me.Btn_Grabar_Y_Cerrar.Name = "Btn_Grabar_Y_Cerrar"
        Me.Btn_Grabar_Y_Cerrar.Text = "<font size=""+2"">Grabar y cerrar</font>"
        '
        'Btn_GAF
        '
        Me.Btn_GAF.Checked = False
        Me.Btn_GAF.Name = "Btn_GAF"
        Me.Btn_GAF.Text = "<font size=""+2"">Gerencia administración y finanzas</font><br/>#Estado#"
        '
        'Tabs_Producto
        '
        Me.Tabs_Producto.BackColor = System.Drawing.Color.White
        '
        '
        '
        '
        '
        '
        Me.Tabs_Producto.ControlBox.CloseBox.Name = ""
        '
        '
        '
        Me.Tabs_Producto.ControlBox.MenuBox.Name = ""
        Me.Tabs_Producto.ControlBox.Name = ""
        Me.Tabs_Producto.ControlBox.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Tabs_Producto.ControlBox.MenuBox, Me.Tabs_Producto.ControlBox.CloseBox})
        Me.Tabs_Producto.Controls.Add(Me.SuperTabControlPanel1)
        Me.Tabs_Producto.Controls.Add(Me.SuperTabControlPanel2)
        Me.Tabs_Producto.ForeColor = System.Drawing.Color.Black
        Me.Tabs_Producto.Location = New System.Drawing.Point(12, 61)
        Me.Tabs_Producto.Name = "Tabs_Producto"
        Me.Tabs_Producto.ReorderTabsEnabled = True
        Me.Tabs_Producto.SelectedTabFont = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Tabs_Producto.SelectedTabIndex = 0
        Me.Tabs_Producto.Size = New System.Drawing.Size(530, 179)
        Me.Tabs_Producto.TabFont = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Tabs_Producto.TabIndex = 92
        Me.Tabs_Producto.Tabs.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Tab_Producto, Me.Tab_Maquina})
        Me.Tabs_Producto.TabStyle = DevComponents.DotNetBar.eSuperTabStyle.Office2010BackstageBlue
        Me.Tabs_Producto.Text = "SuperTabControl1"
        '
        'SuperTabControlPanel1
        '
        Me.SuperTabControlPanel1.Controls.Add(Me.GroupPanel3)
        Me.SuperTabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel1.Location = New System.Drawing.Point(0, 25)
        Me.SuperTabControlPanel1.Name = "SuperTabControlPanel1"
        Me.SuperTabControlPanel1.Size = New System.Drawing.Size(530, 154)
        Me.SuperTabControlPanel1.TabIndex = 1
        Me.SuperTabControlPanel1.TabItem = Me.Tab_Producto
        '
        'GroupPanel3
        '
        Me.GroupPanel3.BackColor = System.Drawing.Color.White
        Me.GroupPanel3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel3.Controls.Add(Me.Txt_Producto)
        Me.GroupPanel3.Controls.Add(Me.TableLayoutPanel4)
        Me.GroupPanel3.Controls.Add(Me.LabelX11)
        Me.GroupPanel3.Controls.Add(Me.Btn_Producto)
        Me.GroupPanel3.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupPanel3.Location = New System.Drawing.Point(0, 0)
        Me.GroupPanel3.Name = "GroupPanel3"
        Me.GroupPanel3.Size = New System.Drawing.Size(530, 154)
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
        Me.GroupPanel3.TabIndex = 94
        '
        'TableLayoutPanel4
        '
        Me.TableLayoutPanel4.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel4.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Outset
        Me.TableLayoutPanel4.ColumnCount = 4
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.73307!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 36.45418!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.54582!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.66534!))
        Me.TableLayoutPanel4.Controls.Add(Me.ButtonX2, 3, 3)
        Me.TableLayoutPanel4.Controls.Add(Me.Lbl_GRP, 1, 3)
        Me.TableLayoutPanel4.Controls.Add(Me.LabelX19, 0, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.LabelX20, 0, 1)
        Me.TableLayoutPanel4.Controls.Add(Me.Lbl_Familia, 1, 1)
        Me.TableLayoutPanel4.Controls.Add(Me.Lbl_Super_Familia, 1, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.LabelX12, 0, 3)
        Me.TableLayoutPanel4.Controls.Add(Me.Lbl_Marca, 3, 1)
        Me.TableLayoutPanel4.Controls.Add(Me.LabelX21, 2, 1)
        Me.TableLayoutPanel4.Controls.Add(Me.LabelX22, 1, 2)
        Me.TableLayoutPanel4.Controls.Add(Me.Lbl_Clas_Libre, 3, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.Lbl_Rubro, 3, 2)
        Me.TableLayoutPanel4.Controls.Add(Me.LabelX23, 2, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.Lbl_Sub_Familia, 1, 2)
        Me.TableLayoutPanel4.Controls.Add(Me.LabelX24, 0, 2)
        Me.TableLayoutPanel4.Controls.Add(Me.Btn_Ver_GRP_PRE, 2, 3)
        Me.TableLayoutPanel4.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel4.Location = New System.Drawing.Point(6, 33)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        Me.TableLayoutPanel4.RowCount = 4
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel4.Size = New System.Drawing.Size(515, 110)
        Me.TableLayoutPanel4.TabIndex = 93
        '
        'ButtonX2
        '
        Me.ButtonX2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX2.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX2.Image = CType(resources.GetObject("ButtonX2.Image"), System.Drawing.Image)
        Me.ButtonX2.Location = New System.Drawing.Point(346, 83)
        Me.ButtonX2.Name = "ButtonX2"
        Me.ButtonX2.Size = New System.Drawing.Size(102, 22)
        Me.ButtonX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX2.TabIndex = 96
        Me.ButtonX2.Text = "Crear GRP_PRE"
        Me.ButtonX2.Visible = False
        '
        'Lbl_GRP
        '
        Me.Lbl_GRP.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_GRP.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_GRP.ForeColor = System.Drawing.Color.Black
        Me.Lbl_GRP.Location = New System.Drawing.Point(91, 83)
        Me.Lbl_GRP.Name = "Lbl_GRP"
        Me.Lbl_GRP.Size = New System.Drawing.Size(177, 19)
        Me.Lbl_GRP.TabIndex = 94
        Me.Lbl_GRP.Text = "LabelX13"
        '
        'LabelX19
        '
        Me.LabelX19.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX19.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX19.ForeColor = System.Drawing.Color.Black
        Me.LabelX19.Location = New System.Drawing.Point(5, 5)
        Me.LabelX19.Name = "LabelX19"
        Me.LabelX19.Size = New System.Drawing.Size(78, 15)
        Me.LabelX19.TabIndex = 33
        Me.LabelX19.Text = "Super Familia"
        '
        'LabelX20
        '
        Me.LabelX20.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX20.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX20.ForeColor = System.Drawing.Color.Black
        Me.LabelX20.Location = New System.Drawing.Point(5, 31)
        Me.LabelX20.Name = "LabelX20"
        Me.LabelX20.Size = New System.Drawing.Size(59, 15)
        Me.LabelX20.TabIndex = 35
        Me.LabelX20.Text = "Familia"
        '
        'Lbl_Familia
        '
        Me.Lbl_Familia.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_Familia.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Familia.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Familia.Location = New System.Drawing.Point(91, 31)
        Me.Lbl_Familia.Name = "Lbl_Familia"
        Me.Lbl_Familia.Size = New System.Drawing.Size(177, 15)
        Me.Lbl_Familia.TabIndex = 36
        Me.Lbl_Familia.Text = "LblFamilia"
        '
        'Lbl_Super_Familia
        '
        Me.Lbl_Super_Familia.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_Super_Familia.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Super_Familia.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Super_Familia.Location = New System.Drawing.Point(91, 5)
        Me.Lbl_Super_Familia.Name = "Lbl_Super_Familia"
        Me.Lbl_Super_Familia.Size = New System.Drawing.Size(177, 17)
        Me.Lbl_Super_Familia.TabIndex = 34
        Me.Lbl_Super_Familia.Text = "LblSuperFamilia"
        '
        'Lbl_Marca
        '
        Me.Lbl_Marca.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_Marca.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Marca.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Marca.Location = New System.Drawing.Point(346, 31)
        Me.Lbl_Marca.Name = "Lbl_Marca"
        Me.Lbl_Marca.Size = New System.Drawing.Size(164, 15)
        Me.Lbl_Marca.TabIndex = 40
        Me.Lbl_Marca.Text = "LblMarca"
        '
        'LabelX21
        '
        Me.LabelX21.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX21.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX21.ForeColor = System.Drawing.Color.Black
        Me.LabelX21.Location = New System.Drawing.Point(276, 31)
        Me.LabelX21.Name = "LabelX21"
        Me.LabelX21.Size = New System.Drawing.Size(62, 15)
        Me.LabelX21.TabIndex = 38
        Me.LabelX21.Text = "Marca"
        '
        'LabelX22
        '
        Me.LabelX22.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX22.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX22.ForeColor = System.Drawing.Color.Black
        Me.LabelX22.Location = New System.Drawing.Point(91, 57)
        Me.LabelX22.Name = "LabelX22"
        Me.LabelX22.Size = New System.Drawing.Size(177, 18)
        Me.LabelX22.TabIndex = 42
        Me.LabelX22.Text = "Rubro"
        '
        'Lbl_Clas_Libre
        '
        Me.Lbl_Clas_Libre.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_Clas_Libre.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Clas_Libre.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Clas_Libre.Location = New System.Drawing.Point(346, 5)
        Me.Lbl_Clas_Libre.Name = "Lbl_Clas_Libre"
        Me.Lbl_Clas_Libre.Size = New System.Drawing.Size(164, 15)
        Me.Lbl_Clas_Libre.TabIndex = 41
        Me.Lbl_Clas_Libre.Text = "LblClasLibre"
        '
        'Lbl_Rubro
        '
        Me.Lbl_Rubro.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_Rubro.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Rubro.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Rubro.Location = New System.Drawing.Point(346, 57)
        Me.Lbl_Rubro.Name = "Lbl_Rubro"
        Me.Lbl_Rubro.Size = New System.Drawing.Size(164, 15)
        Me.Lbl_Rubro.TabIndex = 39
        Me.Lbl_Rubro.Text = "LblRubro"
        '
        'LabelX23
        '
        Me.LabelX23.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX23.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX23.ForeColor = System.Drawing.Color.Black
        Me.LabelX23.Location = New System.Drawing.Point(276, 5)
        Me.LabelX23.Name = "LabelX23"
        Me.LabelX23.Size = New System.Drawing.Size(62, 15)
        Me.LabelX23.TabIndex = 43
        Me.LabelX23.Text = "Clas. Libre"
        '
        'Lbl_Sub_Familia
        '
        Me.Lbl_Sub_Familia.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_Sub_Familia.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Sub_Familia.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Sub_Familia.Location = New System.Drawing.Point(276, 57)
        Me.Lbl_Sub_Familia.Name = "Lbl_Sub_Familia"
        Me.Lbl_Sub_Familia.Size = New System.Drawing.Size(62, 18)
        Me.Lbl_Sub_Familia.TabIndex = 44
        Me.Lbl_Sub_Familia.Text = "LblSubFamilia"
        '
        'LabelX24
        '
        Me.LabelX24.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX24.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX24.ForeColor = System.Drawing.Color.Black
        Me.LabelX24.Location = New System.Drawing.Point(5, 57)
        Me.LabelX24.Name = "LabelX24"
        Me.LabelX24.Size = New System.Drawing.Size(59, 15)
        Me.LabelX24.TabIndex = 37
        Me.LabelX24.Text = "Sub Familia"
        '
        'Btn_Ver_GRP_PRE
        '
        Me.Btn_Ver_GRP_PRE.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Ver_GRP_PRE.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Ver_GRP_PRE.Image = CType(resources.GetObject("Btn_Ver_GRP_PRE.Image"), System.Drawing.Image)
        Me.Btn_Ver_GRP_PRE.Location = New System.Drawing.Point(276, 83)
        Me.Btn_Ver_GRP_PRE.Name = "Btn_Ver_GRP_PRE"
        Me.Btn_Ver_GRP_PRE.Size = New System.Drawing.Size(62, 22)
        Me.Btn_Ver_GRP_PRE.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Ver_GRP_PRE.TabIndex = 95
        Me.Btn_Ver_GRP_PRE.Text = "GRP"
        Me.Btn_Ver_GRP_PRE.Tooltip = "Guía de recepción"
        '
        'Tab_Producto
        '
        Me.Tab_Producto.AttachedControl = Me.SuperTabControlPanel1
        Me.Tab_Producto.GlobalItem = False
        Me.Tab_Producto.Name = "Tab_Producto"
        Me.Tab_Producto.Text = "Maquina (Producto del sistema)"
        '
        'SuperTabControlPanel2
        '
        Me.SuperTabControlPanel2.Controls.Add(Me.GroupPanel4)
        Me.SuperTabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel2.Location = New System.Drawing.Point(0, 0)
        Me.SuperTabControlPanel2.Name = "SuperTabControlPanel2"
        Me.SuperTabControlPanel2.Size = New System.Drawing.Size(530, 179)
        Me.SuperTabControlPanel2.TabIndex = 0
        Me.SuperTabControlPanel2.TabItem = Me.Tab_Maquina
        '
        'GroupPanel4
        '
        Me.GroupPanel4.BackColor = System.Drawing.Color.White
        Me.GroupPanel4.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel4.Controls.Add(Me.TableLayoutPanel1)
        Me.GroupPanel4.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupPanel4.Location = New System.Drawing.Point(0, 0)
        Me.GroupPanel4.Name = "GroupPanel4"
        Me.GroupPanel4.Size = New System.Drawing.Size(530, 179)
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
        Me.GroupPanel4.TabIndex = 93
        '
        'Tab_Maquina
        '
        Me.Tab_Maquina.AttachedControl = Me.SuperTabControlPanel2
        Me.Tab_Maquina.GlobalItem = False
        Me.Tab_Maquina.Name = "Tab_Maquina"
        Me.Tab_Maquina.Text = "Maquina externa"
        '
        'Highlighter1
        '
        Me.Highlighter1.ContainerControl = Me
        Me.Highlighter1.FocusHighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red
        Me.Highlighter1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        '
        'Frm_St_Documento
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(798, 585)
        Me.Controls.Add(Me.Tabs_Producto)
        Me.Controls.Add(Me.ContextMenuBar1)
        Me.Controls.Add(Me.Txt_Nro_Serie)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Controls.Add(Me.LabelX4)
        Me.Controls.Add(Me.Bar2)
        Me.Controls.Add(Me.Progeso_Gestion)
        Me.Controls.Add(Me.LabelX17)
        Me.Controls.Add(Me.GroupPanel2)
        Me.Controls.Add(Me.Grupo_Chk_Tipo_Reparacion)
        Me.Controls.Add(Me.GroupPanel13)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_St_Documento"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MetroForm"
        Me.GroupPanel13.ResumeLayout(False)
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Grupo_Chk_Tipo_Reparacion.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.GroupPanel2.ResumeLayout(False)
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel1.ResumeLayout(False)
        CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Tabs_Producto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Tabs_Producto.ResumeLayout(False)
        Me.SuperTabControlPanel1.ResumeLayout(False)
        Me.GroupPanel3.ResumeLayout(False)
        Me.TableLayoutPanel4.ResumeLayout(False)
        Me.SuperTabControlPanel2.ResumeLayout(False)
        Me.GroupPanel4.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupPanel13 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Grilla As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents Txt_Nro_Serie As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX17 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Btn_Modelo As DevComponents.DotNetBar.ButtonX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Btn_Marca As DevComponents.DotNetBar.ButtonX
    Public WithEvents Txt_Maquina As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Btn_Categorias As DevComponents.DotNetBar.ButtonX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Grupo_Chk_Tipo_Reparacion As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Chk_Serv_Mantenimiento_Preventivo As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Chk_Serv_Recoleccion As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Chk_Serv_Presupuesto_Pre_Aprobado As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Chk_Serv_Mantenimiento_Correctivo As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Chk_Serv_Reparacion_Stock As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Chk_Serv_Domicilio As DevComponents.DotNetBar.Controls.CheckBoxX
    Public WithEvents Txt_Defecto_segun_cliente As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents GroupPanel2 As DevComponents.DotNetBar.Controls.GroupPanel
    Private WithEvents Progeso_Gestion As DevComponents.DotNetBar.ProgressSteps
    Private WithEvents Estado_01_Ingreso As DevComponents.DotNetBar.StepItem
    Private WithEvents Estado_02_Asignar_Tecnico As DevComponents.DotNetBar.StepItem
    Private WithEvents Estado_04_Cotizacion As DevComponents.DotNetBar.StepItem
    Private WithEvents Estado_03_Presupuesto As DevComponents.DotNetBar.StepItem
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents BtnGrabar As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_Logistica As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents BtnSalir As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents Btn_Grabar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Imagenes_32x32 As System.Windows.Forms.ImageList
    Friend WithEvents Chk_Serv_Garantia As DevComponents.DotNetBar.Controls.CheckBoxX
    Public WithEvents Btn_Editar As DevComponents.DotNetBar.ButtonItem
    Private WithEvents Estado_05_Reparacion_Cierre As DevComponents.DotNetBar.StepItem
    Friend WithEvents Estado_06_Aviso As DevComponents.DotNetBar.StepItem
    Friend WithEvents Estado_07_Entrega As DevComponents.DotNetBar.StepItem
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Public WithEvents Txt_Nota As DevComponents.DotNetBar.Controls.TextBoxX
    Public WithEvents Btn_Check_In As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Txt_Marca As DevComponents.DotNetBar.Controls.TextBoxX
    Public WithEvents Txt_Modelo As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Btn_Tipo_Maquina As DevComponents.DotNetBar.ButtonX
    Public WithEvents Txt_Categoria As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Btn_Direccion_Servicio As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Btn_Documento_Garantia As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ContextMenuBar1 As DevComponents.DotNetBar.ContextMenuBar
    Friend WithEvents Menu_Contextual_Garantia As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Garantia_Agregar_Documento As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Garantia_Ver_Documento As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Garantia_Cambiar_Documento As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_Cancelar As DevComponents.DotNetBar.ButtonItem
    Private WithEvents Btn_Grabar_Y_Cerrar As DevComponents.DotNetBar.Command
    Private WithEvents Btn_GAF As DevComponents.DotNetBar.Command
    Friend WithEvents Btn_Anular As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Cerrar_OT As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Imprimir As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Menu_Contextual_Impresion As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Imprimir_Acta_ingreso As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Imprimir_Evaluacion_Tecnico As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Imprimir_Reporte_Final As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Menu_Contextual_Documentos_Grarantia As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Documento_Sistema As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Documento_Externo As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Doc_Externo_Boleta As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Doc_Externo_Factura As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelX6 As DevComponents.DotNetBar.LabelX
    Public WithEvents Txt_Email_Contacto As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX7 As DevComponents.DotNetBar.LabelX
    Public WithEvents Txt_Telefono_Contacto As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX8 As DevComponents.DotNetBar.LabelX
    Public WithEvents Txt_Nombre_Contacto As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX9 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX10 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Chk_Serv_Demostracion_Maquina As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Txt_Producto As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX11 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX12 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Btn_Producto As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Tabs_Producto As DevComponents.DotNetBar.SuperTabControl
    Friend WithEvents SuperTabControlPanel2 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents Tab_Maquina As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents SuperTabControlPanel1 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents Tab_Producto As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents GroupPanel3 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents GroupPanel4 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents TableLayoutPanel4 As TableLayoutPanel
    Friend WithEvents Lbl_GRP As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX19 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX20 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Lbl_Familia As DevComponents.DotNetBar.LabelX
    Friend WithEvents Lbl_Super_Familia As DevComponents.DotNetBar.LabelX
    Friend WithEvents Lbl_Marca As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX21 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX22 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Lbl_Clas_Libre As DevComponents.DotNetBar.LabelX
    Friend WithEvents Lbl_Rubro As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX23 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Lbl_Sub_Familia As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX24 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Btn_Ver_GRP_PRE As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ButtonX2 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Menu_Contextual_GRP As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_GRP_Ver_Documento As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_GRP_Crear_Guia As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_GRP_Asociar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_GRP_Quitar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Contacto As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Highlighter1 As DevComponents.DotNetBar.Validator.Highlighter
End Class
