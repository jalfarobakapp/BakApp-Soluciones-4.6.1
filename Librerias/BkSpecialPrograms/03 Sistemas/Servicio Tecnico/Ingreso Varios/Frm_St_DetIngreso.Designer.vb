<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Frm_St_DetIngreso
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_St_DetIngreso))
        Me.Txt_Producto = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX11 = New DevComponents.DotNetBar.LabelX()
        Me.Bar2 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Grabar = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Eliminar = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Check_In = New DevComponents.DotNetBar.ButtonItem()
        Me.GroupPanel2 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.ContextMenuBar1 = New DevComponents.DotNetBar.ContextMenuBar()
        Me.Menu_Contextual_Documentos_Grarantia = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Documento_Sistema = New DevComponents.DotNetBar.ButtonItem()
        Me.Documento_Externo = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Doc_Externo_Boleta = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Doc_Externo_Factura = New DevComponents.DotNetBar.ButtonItem()
        Me.Txt_Defecto_segun_cliente = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX10 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX8 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_Nota_Etapa_01 = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Grupo_Chk_Tipo_Reparacion = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.Chk_Serv_Demostracion_Maquina = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Btn_Documento_Garantia = New DevComponents.DotNetBar.ButtonX()
        Me.Btn_Direccion_Servicio = New DevComponents.DotNetBar.ButtonX()
        Me.Chk_Serv_Garantia = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Chk_Serv_Mantenimiento_Preventivo = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Chk_Serv_Recoleccion = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Chk_Serv_Presupuesto_Pre_Aprobado = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Chk_Serv_Mantenimiento_Correctivo = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Chk_Serv_Reparacion_Stock = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Chk_Serv_Domicilio = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.GroupPanel3 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Txt_NroSerie = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX17 = New DevComponents.DotNetBar.LabelX()
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel()
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
        Me.Input_Cantidad = New DevComponents.Editors.IntegerInput()
        Me.LabelX12 = New DevComponents.DotNetBar.LabelX()
        Me.Chk_SinNroSerie = New DevComponents.DotNetBar.Controls.CheckBoxX()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel2.SuspendLayout()
        CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Grupo_Chk_Tipo_Reparacion.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.GroupPanel3.SuspendLayout()
        Me.TableLayoutPanel4.SuspendLayout()
        CType(Me.Input_Cantidad, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Txt_Producto
        '
        Me.Txt_Producto.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Producto.Border.Class = "TextBoxBorder"
        Me.Txt_Producto.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Producto.ButtonCustom.Image = CType(resources.GetObject("Txt_Producto.ButtonCustom.Image"), System.Drawing.Image)
        Me.Txt_Producto.ButtonCustom.Visible = True
        Me.Txt_Producto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_Producto.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Producto.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Txt_Producto.FocusHighlightEnabled = True
        Me.Txt_Producto.ForeColor = System.Drawing.Color.Black
        Me.Txt_Producto.Location = New System.Drawing.Point(85, 2)
        Me.Txt_Producto.Name = "Txt_Producto"
        Me.Txt_Producto.ReadOnly = True
        Me.Txt_Producto.Size = New System.Drawing.Size(433, 22)
        Me.Txt_Producto.TabIndex = 88
        Me.Txt_Producto.TabStop = False
        Me.Txt_Producto.WatermarkText = "DEBE INGRESAR EL PRODUCTO DEL CLIENTE..."
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
        Me.LabelX11.Location = New System.Drawing.Point(3, 3)
        Me.LabelX11.Name = "LabelX11"
        Me.LabelX11.Size = New System.Drawing.Size(89, 19)
        Me.LabelX11.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.LabelX11.TabIndex = 88
        Me.LabelX11.Text = "Producto"
        '
        'Bar2
        '
        Me.Bar2.AntiAlias = True
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Grabar, Me.Btn_Eliminar, Me.Btn_Check_In})
        Me.Bar2.Location = New System.Drawing.Point(0, 330)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(796, 41)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Bar2.TabIndex = 101
        Me.Bar2.TabStop = False
        Me.Bar2.Text = "Bar2"
        '
        'Btn_Grabar
        '
        Me.Btn_Grabar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Grabar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Grabar.Image = CType(resources.GetObject("Btn_Grabar.Image"), System.Drawing.Image)
        Me.Btn_Grabar.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.Btn_Grabar.Name = "Btn_Grabar"
        Me.Btn_Grabar.Tooltip = "Grabar"
        '
        'Btn_Eliminar
        '
        Me.Btn_Eliminar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Eliminar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Eliminar.Image = CType(resources.GetObject("Btn_Eliminar.Image"), System.Drawing.Image)
        Me.Btn_Eliminar.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.Btn_Eliminar.Name = "Btn_Eliminar"
        Me.Btn_Eliminar.Tooltip = "Eliminar Sub-Orden"
        '
        'Btn_Check_In
        '
        Me.Btn_Check_In.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Check_In.FontBold = True
        Me.Btn_Check_In.ForeColor = System.Drawing.Color.Red
        Me.Btn_Check_In.Image = CType(resources.GetObject("Btn_Check_In.Image"), System.Drawing.Image)
        Me.Btn_Check_In.Name = "Btn_Check_In"
        Me.Btn_Check_In.Text = "Check-In"
        Me.Btn_Check_In.Visible = False
        '
        'GroupPanel2
        '
        Me.GroupPanel2.BackColor = System.Drawing.Color.White
        Me.GroupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel2.Controls.Add(Me.ContextMenuBar1)
        Me.GroupPanel2.Controls.Add(Me.Txt_Defecto_segun_cliente)
        Me.GroupPanel2.Controls.Add(Me.LabelX10)
        Me.GroupPanel2.Controls.Add(Me.LabelX8)
        Me.GroupPanel2.Controls.Add(Me.Txt_Nota_Etapa_01)
        Me.GroupPanel2.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel2.Location = New System.Drawing.Point(12, 227)
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
        Me.GroupPanel2.TabIndex = 98
        '
        'ContextMenuBar1
        '
        Me.ContextMenuBar1.AntiAlias = True
        Me.ContextMenuBar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ContextMenuBar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Menu_Contextual_Documentos_Grarantia})
        Me.ContextMenuBar1.Location = New System.Drawing.Point(428, 18)
        Me.ContextMenuBar1.Name = "ContextMenuBar1"
        Me.ContextMenuBar1.Size = New System.Drawing.Size(261, 25)
        Me.ContextMenuBar1.Stretch = True
        Me.ContextMenuBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ContextMenuBar1.TabIndex = 73
        Me.ContextMenuBar1.TabStop = False
        Me.ContextMenuBar1.Text = "ContextMenuBar1"
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
        Me.Txt_Defecto_segun_cliente.Location = New System.Drawing.Point(152, 3)
        Me.Txt_Defecto_segun_cliente.MaxLength = 1000
        Me.Txt_Defecto_segun_cliente.Multiline = True
        Me.Txt_Defecto_segun_cliente.Name = "Txt_Defecto_segun_cliente"
        Me.Txt_Defecto_segun_cliente.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.Txt_Defecto_segun_cliente.Size = New System.Drawing.Size(613, 53)
        Me.Txt_Defecto_segun_cliente.TabIndex = 2
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
        'Txt_Nota_Etapa_01
        '
        Me.Txt_Nota_Etapa_01.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Nota_Etapa_01.Border.Class = "TextBoxBorder"
        Me.Txt_Nota_Etapa_01.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Nota_Etapa_01.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_Nota_Etapa_01.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Nota_Etapa_01.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Txt_Nota_Etapa_01.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Nota_Etapa_01.ForeColor = System.Drawing.Color.Black
        Me.Txt_Nota_Etapa_01.Location = New System.Drawing.Point(152, 62)
        Me.Txt_Nota_Etapa_01.MaxLength = 1000
        Me.Txt_Nota_Etapa_01.Name = "Txt_Nota_Etapa_01"
        Me.Txt_Nota_Etapa_01.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.Txt_Nota_Etapa_01.Size = New System.Drawing.Size(613, 22)
        Me.Txt_Nota_Etapa_01.TabIndex = 3
        '
        'Grupo_Chk_Tipo_Reparacion
        '
        Me.Grupo_Chk_Tipo_Reparacion.BackColor = System.Drawing.Color.White
        Me.Grupo_Chk_Tipo_Reparacion.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Grupo_Chk_Tipo_Reparacion.Controls.Add(Me.TableLayoutPanel2)
        Me.Grupo_Chk_Tipo_Reparacion.DisabledBackColor = System.Drawing.Color.Empty
        Me.Grupo_Chk_Tipo_Reparacion.Location = New System.Drawing.Point(548, 12)
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
        Me.Grupo_Chk_Tipo_Reparacion.TabIndex = 97
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
        Me.TableLayoutPanel2.Controls.Add(Me.Btn_Direccion_Servicio, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Chk_Serv_Garantia, 0, 6)
        Me.TableLayoutPanel2.Controls.Add(Me.Chk_Serv_Mantenimiento_Preventivo, 0, 5)
        Me.TableLayoutPanel2.Controls.Add(Me.Chk_Serv_Recoleccion, 0, 4)
        Me.TableLayoutPanel2.Controls.Add(Me.Chk_Serv_Presupuesto_Pre_Aprobado, 0, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.Chk_Serv_Mantenimiento_Correctivo, 0, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.Chk_Serv_Reparacion_Stock, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.Chk_Serv_Domicilio, 0, 0)
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
        Me.Chk_Serv_Demostracion_Maquina.Size = New System.Drawing.Size(167, 18)
        Me.Chk_Serv_Demostracion_Maquina.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Serv_Demostracion_Maquina.TabIndex = 88
        Me.Chk_Serv_Demostracion_Maquina.TabStop = False
        Me.Chk_Serv_Demostracion_Maquina.Text = "Demostración de maquina"
        '
        'Btn_Documento_Garantia
        '
        Me.Btn_Documento_Garantia.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Documento_Garantia.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Documento_Garantia.Enabled = False
        Me.Btn_Documento_Garantia.Image = CType(resources.GetObject("Btn_Documento_Garantia.Image"), System.Drawing.Image)
        Me.Btn_Documento_Garantia.Location = New System.Drawing.Point(176, 135)
        Me.Btn_Documento_Garantia.Name = "Btn_Documento_Garantia"
        Me.Btn_Documento_Garantia.Size = New System.Drawing.Size(38, 16)
        Me.Btn_Documento_Garantia.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Documento_Garantia.TabIndex = 90
        Me.Btn_Documento_Garantia.TabStop = False
        Me.Btn_Documento_Garantia.Tooltip = "Dirección del servicio"
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
        Me.Btn_Direccion_Servicio.TabStop = False
        Me.Btn_Direccion_Servicio.Tooltip = "Dirección del servicio"
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
        Me.Chk_Serv_Garantia.TabStop = False
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
        Me.Chk_Serv_Mantenimiento_Preventivo.TabStop = False
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
        Me.Chk_Serv_Recoleccion.TabStop = False
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
        Me.Chk_Serv_Presupuesto_Pre_Aprobado.TabStop = False
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
        Me.Chk_Serv_Mantenimiento_Correctivo.TabStop = False
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
        Me.Chk_Serv_Reparacion_Stock.TabStop = False
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
        Me.Chk_Serv_Domicilio.TabIndex = 3
        Me.Chk_Serv_Domicilio.TabStop = False
        Me.Chk_Serv_Domicilio.Text = "Servicio a domicilio"
        '
        'GroupPanel3
        '
        Me.GroupPanel3.BackColor = System.Drawing.Color.White
        Me.GroupPanel3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel3.Controls.Add(Me.Chk_SinNroSerie)
        Me.GroupPanel3.Controls.Add(Me.Txt_NroSerie)
        Me.GroupPanel3.Controls.Add(Me.LabelX17)
        Me.GroupPanel3.Controls.Add(Me.TableLayoutPanel4)
        Me.GroupPanel3.Controls.Add(Me.Txt_Producto)
        Me.GroupPanel3.Controls.Add(Me.LabelX11)
        Me.GroupPanel3.Controls.Add(Me.Input_Cantidad)
        Me.GroupPanel3.Controls.Add(Me.LabelX12)
        Me.GroupPanel3.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel3.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.GroupPanel3.Location = New System.Drawing.Point(12, 12)
        Me.GroupPanel3.Name = "GroupPanel3"
        Me.GroupPanel3.Size = New System.Drawing.Size(530, 209)
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
        Me.GroupPanel3.TabIndex = 103
        '
        'Txt_NroSerie
        '
        Me.Txt_NroSerie.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_NroSerie.Border.Class = "TextBoxBorder"
        Me.Txt_NroSerie.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_NroSerie.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_NroSerie.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_NroSerie.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Txt_NroSerie.ForeColor = System.Drawing.Color.Black
        Me.Txt_NroSerie.Location = New System.Drawing.Point(3, 177)
        Me.Txt_NroSerie.Name = "Txt_NroSerie"
        Me.Txt_NroSerie.Size = New System.Drawing.Size(515, 22)
        Me.Txt_NroSerie.TabIndex = 1
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
        Me.LabelX17.Location = New System.Drawing.Point(3, 151)
        Me.LabelX17.Name = "LabelX17"
        Me.LabelX17.Size = New System.Drawing.Size(220, 20)
        Me.LabelX17.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.LabelX17.TabIndex = 96
        Me.LabelX17.Text = "Número de serie (Chasis/Pieza/Parte)"
        '
        'TableLayoutPanel4
        '
        Me.TableLayoutPanel4.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel4.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Outset
        Me.TableLayoutPanel4.ColumnCount = 4
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.81481!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 37.62183!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.54582!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.66534!))
        Me.TableLayoutPanel4.Controls.Add(Me.LabelX19, 0, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.LabelX20, 0, 1)
        Me.TableLayoutPanel4.Controls.Add(Me.Lbl_Familia, 1, 1)
        Me.TableLayoutPanel4.Controls.Add(Me.Lbl_Super_Familia, 1, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.Lbl_Marca, 3, 1)
        Me.TableLayoutPanel4.Controls.Add(Me.LabelX21, 2, 1)
        Me.TableLayoutPanel4.Controls.Add(Me.LabelX22, 1, 2)
        Me.TableLayoutPanel4.Controls.Add(Me.Lbl_Clas_Libre, 3, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.Lbl_Rubro, 3, 2)
        Me.TableLayoutPanel4.Controls.Add(Me.LabelX23, 2, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.Lbl_Sub_Familia, 1, 2)
        Me.TableLayoutPanel4.Controls.Add(Me.LabelX24, 0, 2)
        Me.TableLayoutPanel4.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel4.Location = New System.Drawing.Point(3, 30)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        Me.TableLayoutPanel4.RowCount = 3
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel4.Size = New System.Drawing.Size(515, 81)
        Me.TableLayoutPanel4.TabIndex = 94
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
        Me.LabelX19.Size = New System.Drawing.Size(69, 15)
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
        Me.Lbl_Familia.Location = New System.Drawing.Point(82, 31)
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
        Me.Lbl_Super_Familia.Location = New System.Drawing.Point(82, 5)
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
        Me.Lbl_Marca.Location = New System.Drawing.Point(344, 31)
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
        Me.LabelX21.Location = New System.Drawing.Point(274, 31)
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
        Me.LabelX22.Location = New System.Drawing.Point(274, 57)
        Me.LabelX22.Name = "LabelX22"
        Me.LabelX22.Size = New System.Drawing.Size(62, 18)
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
        Me.Lbl_Clas_Libre.Location = New System.Drawing.Point(344, 5)
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
        Me.Lbl_Rubro.Location = New System.Drawing.Point(344, 57)
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
        Me.LabelX23.Location = New System.Drawing.Point(274, 5)
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
        Me.Lbl_Sub_Familia.Location = New System.Drawing.Point(82, 57)
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
        'Input_Cantidad
        '
        Me.Input_Cantidad.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Input_Cantidad.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Input_Cantidad.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Input_Cantidad.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.Input_Cantidad.ForeColor = System.Drawing.Color.Black
        Me.Input_Cantidad.Location = New System.Drawing.Point(456, 151)
        Me.Input_Cantidad.MaxValue = 100
        Me.Input_Cantidad.MinValue = 0
        Me.Input_Cantidad.Name = "Input_Cantidad"
        Me.Input_Cantidad.ShowUpDown = True
        Me.Input_Cantidad.Size = New System.Drawing.Size(62, 22)
        Me.Input_Cantidad.TabIndex = 0
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
        Me.LabelX12.Location = New System.Drawing.Point(396, 151)
        Me.LabelX12.Name = "LabelX12"
        Me.LabelX12.Size = New System.Drawing.Size(54, 20)
        Me.LabelX12.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.LabelX12.TabIndex = 89
        Me.LabelX12.Text = "Cantidad"
        '
        'Chk_SinNroSerie
        '
        Me.Chk_SinNroSerie.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_SinNroSerie.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_SinNroSerie.CheckBoxImageChecked = CType(resources.GetObject("Chk_SinNroSerie.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_SinNroSerie.FocusCuesEnabled = False
        Me.Chk_SinNroSerie.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.Chk_SinNroSerie.ForeColor = System.Drawing.Color.Black
        Me.Chk_SinNroSerie.Location = New System.Drawing.Point(229, 151)
        Me.Chk_SinNroSerie.Name = "Chk_SinNroSerie"
        Me.Chk_SinNroSerie.Size = New System.Drawing.Size(136, 20)
        Me.Chk_SinNroSerie.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_SinNroSerie.TabIndex = 97
        Me.Chk_SinNroSerie.TabStop = False
        Me.Chk_SinNroSerie.Text = "Sin número de serie"
        '
        'Frm_St_DetIngreso
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(796, 371)
        Me.Controls.Add(Me.GroupPanel3)
        Me.Controls.Add(Me.Bar2)
        Me.Controls.Add(Me.GroupPanel2)
        Me.Controls.Add(Me.Grupo_Chk_Tipo_Reparacion)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_St_DetIngreso"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "SUB ORDEN DE SERVICIO"
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel2.ResumeLayout(False)
        CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Grupo_Chk_Tipo_Reparacion.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.GroupPanel3.ResumeLayout(False)
        Me.TableLayoutPanel4.ResumeLayout(False)
        CType(Me.Input_Cantidad, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Txt_Producto As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX11 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents Btn_Grabar As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_Check_In As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents GroupPanel2 As DevComponents.DotNetBar.Controls.GroupPanel
    Public WithEvents Txt_Defecto_segun_cliente As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX10 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX8 As DevComponents.DotNetBar.LabelX
    Public WithEvents Txt_Nota_Etapa_01 As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Grupo_Chk_Tipo_Reparacion As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents Chk_Serv_Demostracion_Maquina As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Btn_Documento_Garantia As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Btn_Direccion_Servicio As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Chk_Serv_Garantia As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Chk_Serv_Mantenimiento_Preventivo As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Chk_Serv_Recoleccion As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Chk_Serv_Presupuesto_Pre_Aprobado As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Chk_Serv_Mantenimiento_Correctivo As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Chk_Serv_Reparacion_Stock As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Chk_Serv_Domicilio As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents GroupPanel3 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents TableLayoutPanel4 As TableLayoutPanel
    Friend WithEvents LabelX19 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX20 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Lbl_Familia As DevComponents.DotNetBar.LabelX
    Friend WithEvents Lbl_Super_Familia As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX12 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Lbl_Marca As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX21 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX22 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Lbl_Clas_Libre As DevComponents.DotNetBar.LabelX
    Friend WithEvents Lbl_Rubro As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX23 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Lbl_Sub_Familia As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX24 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Txt_NroSerie As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX17 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Btn_Eliminar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ContextMenuBar1 As DevComponents.DotNetBar.ContextMenuBar
    Friend WithEvents Menu_Contextual_Documentos_Grarantia As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Documento_Sistema As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Documento_Externo As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Doc_Externo_Boleta As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Doc_Externo_Factura As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Input_Cantidad As DevComponents.Editors.IntegerInput
    Friend WithEvents Chk_SinNroSerie As DevComponents.DotNetBar.Controls.CheckBoxX
End Class
