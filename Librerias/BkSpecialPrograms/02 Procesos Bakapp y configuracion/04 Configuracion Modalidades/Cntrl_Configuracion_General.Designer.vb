<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Cntrl_Configuracion_General
    Inherits System.Windows.Forms.UserControl

    'UserControl reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Cntrl_Configuracion_General))
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Grabar = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Numeraciones_Documento = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Excluir_Documentos = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_DocConceptosVsPagos = New DevComponents.DotNetBar.ButtonItem()
        Me.BtnSalir = New DevComponents.DotNetBar.ButtonItem()
        Me.Chk_Revisar_Tasa_de_Cambio = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.pageSlider1 = New DevComponents.DotNetBar.Controls.PageSlider()
        Me.Spage_SOC = New DevComponents.DotNetBar.Controls.PageSliderPage()
        Me.Chk_Usar_Validador_Prod_X_Compras = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Chk_No_Solicitar_Permiso_Entidad_Preferencial = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_Crear_FCC_Desde_GRC_Vinculado_SII = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.LabelX13 = New DevComponents.DotNetBar.LabelX()
        Me.Chk_SOC_Prod_Crea_Solo_Marcas_Proveedor = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.LabelX6 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.Cmb_SOC_Buscar_Producto = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.Cmb_SOC_CodTurno = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.LabelX12 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_Prod_Crea_Max_Carac_Nom = New DevComponents.DotNetBar.Controls.MaskedTextBoxAdv()
        Me.Txt_SOC_Valor_1ra_Aprobacion = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX8 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_Dias_Apela = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Cmb_SOC_Tipo_Creacion_Producto_Normal_Matriz = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Rdb_SOC_Aprueba_Solo_G1 = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_SOC_Aprueba_G1_y_G2 = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX()
        Me.SPage_Opciones_Generales = New DevComponents.DotNetBar.Controls.PageSliderPage()
        Me.Input_Monto_Max_CRV_FacMasiva = New DevComponents.Editors.IntegerInput()
        Me.Lbl_Monto_CRV = New DevComponents.DotNetBar.LabelX()
        Me.LabelX15 = New DevComponents.DotNetBar.LabelX()
        Me.Cmb_Nodo_Raiz_Asociados = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.Grupo_Codigo_Automatico = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel()
        Me.Txt_Pr_AutoPr_Max_Cant_Caracteres_Del_Codigo = New DevComponents.Editors.IntegerInput()
        Me.LabelX14 = New DevComponents.DotNetBar.LabelX()
        Me.Cmb_Pr_AutoPr_Tablas_Para_Iniciales_Cod_Automatico = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.LabelX18 = New DevComponents.DotNetBar.LabelX()
        Me.Rdb_Pr_AutoPr_Correlativo_Por_Iniciales = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_Pr_AutoPr_Correlativo_General = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.chk_Pr_Creacion_Exigir_Dimensiones = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Chk_Alerta_Costo_Lista_Distinto_Costo_Proveedor = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Chk_Revisar_OCC_Pendientes_X_Productos = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Chk_Grabar_Despachos_Con_Huella = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Chk_Pedir_Permiso_Para_Usar_Stanby = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Chk_BloqEdiConcepRecargo = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Chk_BloqEdiConcepDescuento = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Chk_Pr_Creacion_Exigir_Codigo_Alternativo = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Chk_Pr_Creacion_Exigir_Clasificacion_busqueda = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Chk_Pr_Creacion_Exigir_Precio = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Chk_Pr_Desc_Producto_Solo_Mayusculas = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Chk_Pr_AutoPr_Crear_Codigo_Principal_Automatico = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Chk_Revisar_Taza_Solo_Mon_Extranjeras = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Chk_Solicitar_Permiso_OCC_SOC = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Chk_Centro_Costo_Obligatorio_OCC = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Chk_Utilizar_NVV_En_Credito_X_Cliente = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Chk_No_Permitir_Grabar_Con_Dscto_Superado = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.SPage_Venta = New DevComponents.DotNetBar.Controls.PageSliderPage()
        Me.Chk_Conservar_Bodega_Sig_Linea_Venta = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Input_Dias_Max_Fecha_Despacho = New DevComponents.Editors.IntegerInput()
        Me.Chk_Dias_Max_Fecha_Despacho_Dom = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Chk_Dias_Max_Fecha_Despacho_Sab = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.LabelX16 = New DevComponents.DotNetBar.LabelX()
        Me.TableLayoutPanel5 = New System.Windows.Forms.TableLayoutPanel()
        Me.Chk_Preguntar_Documento = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Chk_Conservar_Responzable_Doc_Relacionado = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Chk_Redondear_Dscto_Cero = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Chk_Vnta_Ofrecer_Otras_Bod_Stock_Insuficiente = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Chk_Preguntar_Si_Cambia_Responsable_Doc_Relacionado = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX9 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_Dias_Venci_Coti = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Cmb_TipoValor_Bruto_Neto = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.Grupo_Especial_Venta_01 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.LabelX10 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX11 = New DevComponents.DotNetBar.LabelX()
        Me.Btn_Buscar_Cliente = New DevComponents.DotNetBar.ButtonX()
        Me.Txt_Producto_Comodin = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Txt_Cliente = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Btn_Buscar_producto = New DevComponents.DotNetBar.ButtonX()
        Me.LabelX7 = New DevComponents.DotNetBar.LabelX()
        Me.Lbl_Modalidad = New DevComponents.DotNetBar.LabelX()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pageSlider1.SuspendLayout()
        Me.Spage_SOC.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.GroupPanel1.SuspendLayout()
        Me.SPage_Opciones_Generales.SuspendLayout()
        CType(Me.Input_Monto_Max_CRV_FacMasiva, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Grupo_Codigo_Automatico.SuspendLayout()
        Me.TableLayoutPanel4.SuspendLayout()
        CType(Me.Txt_Pr_AutoPr_Max_Cant_Caracteres_Del_Codigo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SPage_Venta.SuspendLayout()
        CType(Me.Input_Dias_Max_Fecha_Despacho, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel5.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.Grupo_Especial_Venta_01.SuspendLayout()
        Me.SuspendLayout()
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Grabar, Me.Btn_Numeraciones_Documento, Me.Btn_Excluir_Documentos, Me.Btn_DocConceptosVsPagos, Me.BtnSalir})
        Me.Bar1.Location = New System.Drawing.Point(0, 558)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(784, 57)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 8
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'Btn_Grabar
        '
        Me.Btn_Grabar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Grabar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Grabar.Image = CType(resources.GetObject("Btn_Grabar.Image"), System.Drawing.Image)
        Me.Btn_Grabar.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.Btn_Grabar.Name = "Btn_Grabar"
        Me.Btn_Grabar.Text = "Grabar"
        '
        'Btn_Numeraciones_Documento
        '
        Me.Btn_Numeraciones_Documento.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Numeraciones_Documento.ForeColor = System.Drawing.Color.Black
        Me.Btn_Numeraciones_Documento.Image = CType(resources.GetObject("Btn_Numeraciones_Documento.Image"), System.Drawing.Image)
        Me.Btn_Numeraciones_Documento.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.Btn_Numeraciones_Documento.Name = "Btn_Numeraciones_Documento"
        Me.Btn_Numeraciones_Documento.Text = "Numeración"
        '
        'Btn_Excluir_Documentos
        '
        Me.Btn_Excluir_Documentos.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Excluir_Documentos.ForeColor = System.Drawing.Color.Black
        Me.Btn_Excluir_Documentos.Image = CType(resources.GetObject("Btn_Excluir_Documentos.Image"), System.Drawing.Image)
        Me.Btn_Excluir_Documentos.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.Btn_Excluir_Documentos.Name = "Btn_Excluir_Documentos"
        Me.Btn_Excluir_Documentos.Text = "Doc. Excluidos"
        '
        'Btn_DocConceptosVsPagos
        '
        Me.Btn_DocConceptosVsPagos.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_DocConceptosVsPagos.ForeColor = System.Drawing.Color.Black
        Me.Btn_DocConceptosVsPagos.Image = CType(resources.GetObject("Btn_DocConceptosVsPagos.Image"), System.Drawing.Image)
        Me.Btn_DocConceptosVsPagos.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.Btn_DocConceptosVsPagos.Name = "Btn_DocConceptosVsPagos"
        Me.Btn_DocConceptosVsPagos.Text = "Doc. Conceptos vs pagos"
        Me.Btn_DocConceptosVsPagos.Tooltip = "Documentos con conceptos obligatorios según tipo de pago"
        '
        'BtnSalir
        '
        Me.BtnSalir.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnSalir.ForeColor = System.Drawing.Color.Black
        Me.BtnSalir.Image = CType(resources.GetObject("BtnSalir.Image"), System.Drawing.Image)
        Me.BtnSalir.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.BtnSalir.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.BtnSalir.Name = "BtnSalir"
        Me.BtnSalir.Text = "Volver..."
        '
        'Chk_Revisar_Tasa_de_Cambio
        '
        '
        '
        '
        Me.Chk_Revisar_Tasa_de_Cambio.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Revisar_Tasa_de_Cambio.Location = New System.Drawing.Point(3, 3)
        Me.Chk_Revisar_Tasa_de_Cambio.Name = "Chk_Revisar_Tasa_de_Cambio"
        Me.Chk_Revisar_Tasa_de_Cambio.Size = New System.Drawing.Size(283, 13)
        Me.Chk_Revisar_Tasa_de_Cambio.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Revisar_Tasa_de_Cambio.TabIndex = 9
        Me.Chk_Revisar_Tasa_de_Cambio.Text = "Revisar tasa de cambio"
        '
        'pageSlider1
        '
        Me.pageSlider1.AnimationTime = 250
        Me.pageSlider1.Controls.Add(Me.Spage_SOC)
        Me.pageSlider1.Controls.Add(Me.SPage_Opciones_Generales)
        Me.pageSlider1.Controls.Add(Me.SPage_Venta)
        Me.pageSlider1.IndicatorVisible = False
        Me.pageSlider1.Location = New System.Drawing.Point(17, 55)
        Me.pageSlider1.Name = "pageSlider1"
        Me.pageSlider1.SelectedPage = Me.SPage_Venta
        Me.pageSlider1.Size = New System.Drawing.Size(757, 484)
        Me.pageSlider1.TabIndex = 55
        Me.pageSlider1.Text = "pageSlider1"
        '
        'Spage_SOC
        '
        Me.Spage_SOC.Controls.Add(Me.Chk_Usar_Validador_Prod_X_Compras)
        Me.Spage_SOC.Controls.Add(Me.Chk_No_Solicitar_Permiso_Entidad_Preferencial)
        Me.Spage_SOC.Controls.Add(Me.Rdb_Crear_FCC_Desde_GRC_Vinculado_SII)
        Me.Spage_SOC.Controls.Add(Me.TableLayoutPanel2)
        Me.Spage_SOC.Controls.Add(Me.GroupPanel1)
        Me.Spage_SOC.Controls.Add(Me.LabelX5)
        Me.Spage_SOC.Location = New System.Drawing.Point(-1394, 4)
        Me.Spage_SOC.Name = "Spage_SOC"
        Me.Spage_SOC.Size = New System.Drawing.Size(651, 476)
        Me.Spage_SOC.TabIndex = 4
        '
        'Chk_Usar_Validador_Prod_X_Compras
        '
        '
        '
        '
        Me.Chk_Usar_Validador_Prod_X_Compras.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Usar_Validador_Prod_X_Compras.Location = New System.Drawing.Point(13, 384)
        Me.Chk_Usar_Validador_Prod_X_Compras.Name = "Chk_Usar_Validador_Prod_X_Compras"
        Me.Chk_Usar_Validador_Prod_X_Compras.Size = New System.Drawing.Size(342, 23)
        Me.Chk_Usar_Validador_Prod_X_Compras.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Usar_Validador_Prod_X_Compras.TabIndex = 80
        Me.Chk_Usar_Validador_Prod_X_Compras.Text = "Avisar a funcionario validador de códigos al generar OCC"
        '
        'Chk_No_Solicitar_Permiso_Entidad_Preferencial
        '
        '
        '
        '
        Me.Chk_No_Solicitar_Permiso_Entidad_Preferencial.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_No_Solicitar_Permiso_Entidad_Preferencial.Location = New System.Drawing.Point(13, 360)
        Me.Chk_No_Solicitar_Permiso_Entidad_Preferencial.Name = "Chk_No_Solicitar_Permiso_Entidad_Preferencial"
        Me.Chk_No_Solicitar_Permiso_Entidad_Preferencial.Size = New System.Drawing.Size(342, 23)
        Me.Chk_No_Solicitar_Permiso_Entidad_Preferencial.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_No_Solicitar_Permiso_Entidad_Preferencial.TabIndex = 79
        Me.Chk_No_Solicitar_Permiso_Entidad_Preferencial.Text = "No solicitar permiso a entidades preferenciales"
        '
        'Rdb_Crear_FCC_Desde_GRC_Vinculado_SII
        '
        '
        '
        '
        Me.Rdb_Crear_FCC_Desde_GRC_Vinculado_SII.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Crear_FCC_Desde_GRC_Vinculado_SII.Location = New System.Drawing.Point(13, 337)
        Me.Rdb_Crear_FCC_Desde_GRC_Vinculado_SII.Name = "Rdb_Crear_FCC_Desde_GRC_Vinculado_SII"
        Me.Rdb_Crear_FCC_Desde_GRC_Vinculado_SII.Size = New System.Drawing.Size(342, 23)
        Me.Rdb_Crear_FCC_Desde_GRC_Vinculado_SII.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Crear_FCC_Desde_GRC_Vinculado_SII.TabIndex = 78
        Me.Rdb_Crear_FCC_Desde_GRC_Vinculado_SII.Text = "Crear FCC al grabar GRC vinculada en el SII"
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.Controls.Add(Me.LabelX13, 0, 6)
        Me.TableLayoutPanel2.Controls.Add(Me.Chk_SOC_Prod_Crea_Solo_Marcas_Proveedor, 0, 5)
        Me.TableLayoutPanel2.Controls.Add(Me.LabelX6, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.LabelX2, 0, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.LabelX3, 0, 4)
        Me.TableLayoutPanel2.Controls.Add(Me.Cmb_SOC_Buscar_Producto, 1, 4)
        Me.TableLayoutPanel2.Controls.Add(Me.Cmb_SOC_CodTurno, 1, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.LabelX12, 0, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.Txt_Prod_Crea_Max_Carac_Nom, 1, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.Txt_SOC_Valor_1ra_Aprobacion, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.LabelX8, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.Txt_Dias_Apela, 1, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.Cmb_SOC_Tipo_Creacion_Producto_Normal_Matriz, 1, 6)
        Me.TableLayoutPanel2.Enabled = False
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(13, 159)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 7
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(625, 172)
        Me.TableLayoutPanel2.TabIndex = 77
        '
        'LabelX13
        '
        '
        '
        '
        Me.LabelX13.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX13.Location = New System.Drawing.Point(3, 147)
        Me.LabelX13.Name = "LabelX13"
        Me.LabelX13.Size = New System.Drawing.Size(349, 18)
        Me.LabelX13.TabIndex = 78
        Me.LabelX13.Text = "Como crear los productos desde las solicitudes de compra"
        '
        'Chk_SOC_Prod_Crea_Solo_Marcas_Proveedor
        '
        Me.Chk_SOC_Prod_Crea_Solo_Marcas_Proveedor.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_SOC_Prod_Crea_Solo_Marcas_Proveedor.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_SOC_Prod_Crea_Solo_Marcas_Proveedor.ForeColor = System.Drawing.Color.Black
        Me.Chk_SOC_Prod_Crea_Solo_Marcas_Proveedor.Location = New System.Drawing.Point(3, 123)
        Me.Chk_SOC_Prod_Crea_Solo_Marcas_Proveedor.Name = "Chk_SOC_Prod_Crea_Solo_Marcas_Proveedor"
        Me.Chk_SOC_Prod_Crea_Solo_Marcas_Proveedor.Size = New System.Drawing.Size(416, 15)
        Me.Chk_SOC_Prod_Crea_Solo_Marcas_Proveedor.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_SOC_Prod_Crea_Solo_Marcas_Proveedor.TabIndex = 78
        Me.Chk_SOC_Prod_Crea_Solo_Marcas_Proveedor.Text = "Mostrar solo marcas del proveedor en formulario de creación de productos"
        '
        'LabelX6
        '
        '
        '
        '
        Me.LabelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX6.Location = New System.Drawing.Point(3, 3)
        Me.LabelX6.Name = "LabelX6"
        Me.LabelX6.Size = New System.Drawing.Size(216, 18)
        Me.LabelX6.TabIndex = 65
        Me.LabelX6.Text = "Valor máximo aprobación G1"
        '
        'LabelX2
        '
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Location = New System.Drawing.Point(3, 75)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(176, 18)
        Me.LabelX2.TabIndex = 70
        Me.LabelX2.Text = "Turno para solicitudes de compra"
        '
        'LabelX3
        '
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.Location = New System.Drawing.Point(3, 99)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(220, 18)
        Me.LabelX3.TabIndex = 67
        Me.LabelX3.Text = "Como buscar los productos del proveedor"
        '
        'Cmb_SOC_Buscar_Producto
        '
        Me.Cmb_SOC_Buscar_Producto.DisplayMember = "Text"
        Me.Cmb_SOC_Buscar_Producto.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.Cmb_SOC_Buscar_Producto.ForeColor = System.Drawing.Color.Black
        Me.Cmb_SOC_Buscar_Producto.FormattingEnabled = True
        Me.Cmb_SOC_Buscar_Producto.ItemHeight = 16
        Me.Cmb_SOC_Buscar_Producto.Location = New System.Drawing.Point(425, 99)
        Me.Cmb_SOC_Buscar_Producto.Name = "Cmb_SOC_Buscar_Producto"
        Me.Cmb_SOC_Buscar_Producto.Size = New System.Drawing.Size(199, 22)
        Me.Cmb_SOC_Buscar_Producto.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Cmb_SOC_Buscar_Producto.TabIndex = 68
        '
        'Cmb_SOC_CodTurno
        '
        Me.Cmb_SOC_CodTurno.DisplayMember = "Text"
        Me.Cmb_SOC_CodTurno.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.Cmb_SOC_CodTurno.ForeColor = System.Drawing.Color.Black
        Me.Cmb_SOC_CodTurno.FormattingEnabled = True
        Me.Cmb_SOC_CodTurno.ItemHeight = 16
        Me.Cmb_SOC_CodTurno.Location = New System.Drawing.Point(425, 75)
        Me.Cmb_SOC_CodTurno.Name = "Cmb_SOC_CodTurno"
        Me.Cmb_SOC_CodTurno.Size = New System.Drawing.Size(199, 22)
        Me.Cmb_SOC_CodTurno.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Cmb_SOC_CodTurno.TabIndex = 71
        '
        'LabelX12
        '
        '
        '
        '
        Me.LabelX12.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX12.Location = New System.Drawing.Point(3, 51)
        Me.LabelX12.Name = "LabelX12"
        Me.LabelX12.Size = New System.Drawing.Size(307, 18)
        Me.LabelX12.TabIndex = 74
        Me.LabelX12.Text = "Máximo de caracteres para formato de creación de productos"
        '
        'Txt_Prod_Crea_Max_Carac_Nom
        '
        '
        '
        '
        Me.Txt_Prod_Crea_Max_Carac_Nom.BackgroundStyle.Class = "TextBoxBorder"
        Me.Txt_Prod_Crea_Max_Carac_Nom.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Prod_Crea_Max_Carac_Nom.ButtonClear.Visible = True
        Me.Txt_Prod_Crea_Max_Carac_Nom.Location = New System.Drawing.Point(425, 51)
        Me.Txt_Prod_Crea_Max_Carac_Nom.Mask = "99"
        Me.Txt_Prod_Crea_Max_Carac_Nom.Name = "Txt_Prod_Crea_Max_Carac_Nom"
        Me.Txt_Prod_Crea_Max_Carac_Nom.Size = New System.Drawing.Size(50, 18)
        Me.Txt_Prod_Crea_Max_Carac_Nom.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Txt_Prod_Crea_Max_Carac_Nom.TabIndex = 76
        Me.Txt_Prod_Crea_Max_Carac_Nom.Text = ""
        '
        'Txt_SOC_Valor_1ra_Aprobacion
        '
        Me.Txt_SOC_Valor_1ra_Aprobacion.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_SOC_Valor_1ra_Aprobacion.Border.Class = "TextBoxBorder"
        Me.Txt_SOC_Valor_1ra_Aprobacion.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_SOC_Valor_1ra_Aprobacion.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_SOC_Valor_1ra_Aprobacion.ForeColor = System.Drawing.Color.Black
        Me.Txt_SOC_Valor_1ra_Aprobacion.Location = New System.Drawing.Point(425, 3)
        Me.Txt_SOC_Valor_1ra_Aprobacion.Name = "Txt_SOC_Valor_1ra_Aprobacion"
        Me.Txt_SOC_Valor_1ra_Aprobacion.PreventEnterBeep = True
        Me.Txt_SOC_Valor_1ra_Aprobacion.Size = New System.Drawing.Size(100, 20)
        Me.Txt_SOC_Valor_1ra_Aprobacion.TabIndex = 66
        Me.Txt_SOC_Valor_1ra_Aprobacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LabelX8
        '
        '
        '
        '
        Me.LabelX8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX8.Location = New System.Drawing.Point(3, 27)
        Me.LabelX8.Name = "LabelX8"
        Me.LabelX8.Size = New System.Drawing.Size(216, 18)
        Me.LabelX8.TabIndex = 72
        Me.LabelX8.Text = "Días para apelar compra de productos"
        '
        'Txt_Dias_Apela
        '
        Me.Txt_Dias_Apela.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Dias_Apela.Border.Class = "TextBoxBorder"
        Me.Txt_Dias_Apela.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Dias_Apela.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Dias_Apela.ForeColor = System.Drawing.Color.Black
        Me.Txt_Dias_Apela.Location = New System.Drawing.Point(425, 27)
        Me.Txt_Dias_Apela.Name = "Txt_Dias_Apela"
        Me.Txt_Dias_Apela.PreventEnterBeep = True
        Me.Txt_Dias_Apela.Size = New System.Drawing.Size(100, 20)
        Me.Txt_Dias_Apela.TabIndex = 73
        Me.Txt_Dias_Apela.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Cmb_SOC_Tipo_Creacion_Producto_Normal_Matriz
        '
        Me.Cmb_SOC_Tipo_Creacion_Producto_Normal_Matriz.DisplayMember = "Text"
        Me.Cmb_SOC_Tipo_Creacion_Producto_Normal_Matriz.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.Cmb_SOC_Tipo_Creacion_Producto_Normal_Matriz.ForeColor = System.Drawing.Color.Black
        Me.Cmb_SOC_Tipo_Creacion_Producto_Normal_Matriz.FormattingEnabled = True
        Me.Cmb_SOC_Tipo_Creacion_Producto_Normal_Matriz.ItemHeight = 16
        Me.Cmb_SOC_Tipo_Creacion_Producto_Normal_Matriz.Location = New System.Drawing.Point(425, 147)
        Me.Cmb_SOC_Tipo_Creacion_Producto_Normal_Matriz.Name = "Cmb_SOC_Tipo_Creacion_Producto_Normal_Matriz"
        Me.Cmb_SOC_Tipo_Creacion_Producto_Normal_Matriz.Size = New System.Drawing.Size(199, 22)
        Me.Cmb_SOC_Tipo_Creacion_Producto_Normal_Matriz.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Cmb_SOC_Tipo_Creacion_Producto_Normal_Matriz.TabIndex = 79
        '
        'GroupPanel1
        '
        Me.GroupPanel1.BackColor = System.Drawing.Color.Transparent
        Me.GroupPanel1.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.Rdb_SOC_Aprueba_Solo_G1)
        Me.GroupPanel1.Controls.Add(Me.Rdb_SOC_Aprueba_G1_y_G2)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Enabled = False
        Me.GroupPanel1.Location = New System.Drawing.Point(13, 82)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(514, 71)
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
        Me.GroupPanel1.TabIndex = 69
        Me.GroupPanel1.Text = "Como aprobar nivel gerencia"
        '
        'Rdb_SOC_Aprueba_Solo_G1
        '
        Me.Rdb_SOC_Aprueba_Solo_G1.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_SOC_Aprueba_Solo_G1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_SOC_Aprueba_Solo_G1.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_SOC_Aprueba_Solo_G1.Location = New System.Drawing.Point(12, 3)
        Me.Rdb_SOC_Aprueba_Solo_G1.Name = "Rdb_SOC_Aprueba_Solo_G1"
        Me.Rdb_SOC_Aprueba_Solo_G1.Size = New System.Drawing.Size(312, 23)
        Me.Rdb_SOC_Aprueba_Solo_G1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_SOC_Aprueba_Solo_G1.TabIndex = 62
        Me.Rdb_SOC_Aprueba_Solo_G1.Text = "Aprobar solo gerencia 1 (G1)"
        '
        'Rdb_SOC_Aprueba_G1_y_G2
        '
        Me.Rdb_SOC_Aprueba_G1_y_G2.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_SOC_Aprueba_G1_y_G2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_SOC_Aprueba_G1_y_G2.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_SOC_Aprueba_G1_y_G2.Location = New System.Drawing.Point(12, 23)
        Me.Rdb_SOC_Aprueba_G1_y_G2.Name = "Rdb_SOC_Aprueba_G1_y_G2"
        Me.Rdb_SOC_Aprueba_G1_y_G2.Size = New System.Drawing.Size(312, 23)
        Me.Rdb_SOC_Aprueba_G1_y_G2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_SOC_Aprueba_G1_y_G2.TabIndex = 63
        Me.Rdb_SOC_Aprueba_G1_y_G2.Text = "Aprobar con gerencia 1 y 2 (G1 y G2)"
        '
        'LabelX5
        '
        '
        '
        '
        Me.LabelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX5.Dock = System.Windows.Forms.DockStyle.Top
        Me.LabelX5.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX5.Location = New System.Drawing.Point(0, 0)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.Size = New System.Drawing.Size(651, 52)
        Me.LabelX5.TabIndex = 1
        Me.LabelX5.Text = "Solicitudes de compra"
        Me.LabelX5.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'SPage_Opciones_Generales
        '
        Me.SPage_Opciones_Generales.Controls.Add(Me.Input_Monto_Max_CRV_FacMasiva)
        Me.SPage_Opciones_Generales.Controls.Add(Me.Lbl_Monto_CRV)
        Me.SPage_Opciones_Generales.Controls.Add(Me.LabelX15)
        Me.SPage_Opciones_Generales.Controls.Add(Me.Cmb_Nodo_Raiz_Asociados)
        Me.SPage_Opciones_Generales.Controls.Add(Me.Grupo_Codigo_Automatico)
        Me.SPage_Opciones_Generales.Controls.Add(Me.TableLayoutPanel1)
        Me.SPage_Opciones_Generales.Controls.Add(Me.LabelX4)
        Me.SPage_Opciones_Generales.Location = New System.Drawing.Point(-695, 4)
        Me.SPage_Opciones_Generales.Name = "SPage_Opciones_Generales"
        Me.SPage_Opciones_Generales.Size = New System.Drawing.Size(651, 476)
        Me.SPage_Opciones_Generales.TabIndex = 3
        '
        'Input_Monto_Max_CRV_FacMasiva
        '
        '
        '
        '
        Me.Input_Monto_Max_CRV_FacMasiva.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Input_Monto_Max_CRV_FacMasiva.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Input_Monto_Max_CRV_FacMasiva.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.Input_Monto_Max_CRV_FacMasiva.Location = New System.Drawing.Point(335, 304)
        Me.Input_Monto_Max_CRV_FacMasiva.MaxValue = 10000
        Me.Input_Monto_Max_CRV_FacMasiva.MinValue = 0
        Me.Input_Monto_Max_CRV_FacMasiva.Name = "Input_Monto_Max_CRV_FacMasiva"
        Me.Input_Monto_Max_CRV_FacMasiva.ShowUpDown = True
        Me.Input_Monto_Max_CRV_FacMasiva.Size = New System.Drawing.Size(64, 20)
        Me.Input_Monto_Max_CRV_FacMasiva.TabIndex = 92
        '
        'Lbl_Monto_CRV
        '
        '
        '
        '
        Me.Lbl_Monto_CRV.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Monto_CRV.Location = New System.Drawing.Point(16, 303)
        Me.Lbl_Monto_CRV.Name = "Lbl_Monto_CRV"
        Me.Lbl_Monto_CRV.Size = New System.Drawing.Size(313, 19)
        Me.Lbl_Monto_CRV.TabIndex = 90
        Me.Lbl_Monto_CRV.Text = "Monto máximo para pagar saldo con CRV (facturación masiva)"
        '
        'LabelX15
        '
        '
        '
        '
        Me.LabelX15.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX15.Location = New System.Drawing.Point(22, 427)
        Me.LabelX15.Name = "LabelX15"
        Me.LabelX15.Size = New System.Drawing.Size(168, 18)
        Me.LabelX15.TabIndex = 80
        Me.LabelX15.Text = "Carpeta raíz productos asociados"
        '
        'Cmb_Nodo_Raiz_Asociados
        '
        Me.Cmb_Nodo_Raiz_Asociados.DisplayMember = "Text"
        Me.Cmb_Nodo_Raiz_Asociados.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.Cmb_Nodo_Raiz_Asociados.ForeColor = System.Drawing.Color.Black
        Me.Cmb_Nodo_Raiz_Asociados.FormattingEnabled = True
        Me.Cmb_Nodo_Raiz_Asociados.ItemHeight = 16
        Me.Cmb_Nodo_Raiz_Asociados.Location = New System.Drawing.Point(196, 427)
        Me.Cmb_Nodo_Raiz_Asociados.Name = "Cmb_Nodo_Raiz_Asociados"
        Me.Cmb_Nodo_Raiz_Asociados.Size = New System.Drawing.Size(161, 22)
        Me.Cmb_Nodo_Raiz_Asociados.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Cmb_Nodo_Raiz_Asociados.TabIndex = 81
        '
        'Grupo_Codigo_Automatico
        '
        Me.Grupo_Codigo_Automatico.BackColor = System.Drawing.Color.Transparent
        Me.Grupo_Codigo_Automatico.CanvasColor = System.Drawing.SystemColors.Control
        Me.Grupo_Codigo_Automatico.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Grupo_Codigo_Automatico.Controls.Add(Me.TableLayoutPanel4)
        Me.Grupo_Codigo_Automatico.Controls.Add(Me.Rdb_Pr_AutoPr_Correlativo_Por_Iniciales)
        Me.Grupo_Codigo_Automatico.Controls.Add(Me.Rdb_Pr_AutoPr_Correlativo_General)
        Me.Grupo_Codigo_Automatico.DisabledBackColor = System.Drawing.Color.Empty
        Me.Grupo_Codigo_Automatico.Location = New System.Drawing.Point(437, 415)
        Me.Grupo_Codigo_Automatico.Name = "Grupo_Codigo_Automatico"
        Me.Grupo_Codigo_Automatico.Size = New System.Drawing.Size(174, 34)
        '
        '
        '
        Me.Grupo_Codigo_Automatico.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Grupo_Codigo_Automatico.Style.BackColorGradientAngle = 90
        Me.Grupo_Codigo_Automatico.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Grupo_Codigo_Automatico.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Codigo_Automatico.Style.BorderBottomWidth = 1
        Me.Grupo_Codigo_Automatico.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.Grupo_Codigo_Automatico.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Codigo_Automatico.Style.BorderLeftWidth = 1
        Me.Grupo_Codigo_Automatico.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Codigo_Automatico.Style.BorderRightWidth = 1
        Me.Grupo_Codigo_Automatico.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Codigo_Automatico.Style.BorderTopWidth = 1
        Me.Grupo_Codigo_Automatico.Style.CornerDiameter = 4
        Me.Grupo_Codigo_Automatico.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Grupo_Codigo_Automatico.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.Grupo_Codigo_Automatico.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.Grupo_Codigo_Automatico.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.Grupo_Codigo_Automatico.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.Grupo_Codigo_Automatico.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Grupo_Codigo_Automatico.TabIndex = 21
        Me.Grupo_Codigo_Automatico.Text = "Como crear los códigos automaticamente"
        Me.Grupo_Codigo_Automatico.Visible = False
        '
        'TableLayoutPanel4
        '
        Me.TableLayoutPanel4.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel4.ColumnCount = 2
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65.41666!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34.58333!))
        Me.TableLayoutPanel4.Controls.Add(Me.Txt_Pr_AutoPr_Max_Cant_Caracteres_Del_Codigo, 1, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.LabelX14, 0, 1)
        Me.TableLayoutPanel4.Controls.Add(Me.Cmb_Pr_AutoPr_Tablas_Para_Iniciales_Cod_Automatico, 1, 1)
        Me.TableLayoutPanel4.Controls.Add(Me.LabelX18, 0, 0)
        Me.TableLayoutPanel4.Location = New System.Drawing.Point(0, 32)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        Me.TableLayoutPanel4.RowCount = 2
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel4.Size = New System.Drawing.Size(480, 56)
        Me.TableLayoutPanel4.TabIndex = 78
        '
        'Txt_Pr_AutoPr_Max_Cant_Caracteres_Del_Codigo
        '
        Me.Txt_Pr_AutoPr_Max_Cant_Caracteres_Del_Codigo.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Pr_AutoPr_Max_Cant_Caracteres_Del_Codigo.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Txt_Pr_AutoPr_Max_Cant_Caracteres_Del_Codigo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Pr_AutoPr_Max_Cant_Caracteres_Del_Codigo.ButtonClear.Visible = True
        Me.Txt_Pr_AutoPr_Max_Cant_Caracteres_Del_Codigo.FocusHighlightEnabled = True
        Me.Txt_Pr_AutoPr_Max_Cant_Caracteres_Del_Codigo.ForeColor = System.Drawing.Color.Black
        Me.Txt_Pr_AutoPr_Max_Cant_Caracteres_Del_Codigo.Location = New System.Drawing.Point(316, 3)
        Me.Txt_Pr_AutoPr_Max_Cant_Caracteres_Del_Codigo.MaxValue = 13
        Me.Txt_Pr_AutoPr_Max_Cant_Caracteres_Del_Codigo.MinValue = 6
        Me.Txt_Pr_AutoPr_Max_Cant_Caracteres_Del_Codigo.Name = "Txt_Pr_AutoPr_Max_Cant_Caracteres_Del_Codigo"
        Me.Txt_Pr_AutoPr_Max_Cant_Caracteres_Del_Codigo.ShowUpDown = True
        Me.Txt_Pr_AutoPr_Max_Cant_Caracteres_Del_Codigo.Size = New System.Drawing.Size(49, 20)
        Me.Txt_Pr_AutoPr_Max_Cant_Caracteres_Del_Codigo.TabIndex = 101
        Me.Txt_Pr_AutoPr_Max_Cant_Caracteres_Del_Codigo.Value = 13
        '
        'LabelX14
        '
        '
        '
        '
        Me.LabelX14.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX14.Location = New System.Drawing.Point(3, 31)
        Me.LabelX14.Name = "LabelX14"
        Me.LabelX14.Size = New System.Drawing.Size(307, 18)
        Me.LabelX14.TabIndex = 78
        Me.LabelX14.Text = "Tabla para inicales del código automatico"
        '
        'Cmb_Pr_AutoPr_Tablas_Para_Iniciales_Cod_Automatico
        '
        Me.Cmb_Pr_AutoPr_Tablas_Para_Iniciales_Cod_Automatico.DisplayMember = "Text"
        Me.Cmb_Pr_AutoPr_Tablas_Para_Iniciales_Cod_Automatico.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.Cmb_Pr_AutoPr_Tablas_Para_Iniciales_Cod_Automatico.ForeColor = System.Drawing.Color.Black
        Me.Cmb_Pr_AutoPr_Tablas_Para_Iniciales_Cod_Automatico.FormattingEnabled = True
        Me.Cmb_Pr_AutoPr_Tablas_Para_Iniciales_Cod_Automatico.ItemHeight = 16
        Me.Cmb_Pr_AutoPr_Tablas_Para_Iniciales_Cod_Automatico.Location = New System.Drawing.Point(316, 31)
        Me.Cmb_Pr_AutoPr_Tablas_Para_Iniciales_Cod_Automatico.Name = "Cmb_Pr_AutoPr_Tablas_Para_Iniciales_Cod_Automatico"
        Me.Cmb_Pr_AutoPr_Tablas_Para_Iniciales_Cod_Automatico.Size = New System.Drawing.Size(161, 22)
        Me.Cmb_Pr_AutoPr_Tablas_Para_Iniciales_Cod_Automatico.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Cmb_Pr_AutoPr_Tablas_Para_Iniciales_Cod_Automatico.TabIndex = 79
        '
        'LabelX18
        '
        '
        '
        '
        Me.LabelX18.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX18.Location = New System.Drawing.Point(3, 3)
        Me.LabelX18.Name = "LabelX18"
        Me.LabelX18.Size = New System.Drawing.Size(307, 18)
        Me.LabelX18.TabIndex = 74
        Me.LabelX18.Text = "Máximo de caracteres para los códigos automáticos"
        '
        'Rdb_Pr_AutoPr_Correlativo_Por_Iniciales
        '
        Me.Rdb_Pr_AutoPr_Correlativo_Por_Iniciales.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Pr_AutoPr_Correlativo_Por_Iniciales.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Pr_AutoPr_Correlativo_Por_Iniciales.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Pr_AutoPr_Correlativo_Por_Iniciales.Location = New System.Drawing.Point(188, 3)
        Me.Rdb_Pr_AutoPr_Correlativo_Por_Iniciales.Name = "Rdb_Pr_AutoPr_Correlativo_Por_Iniciales"
        Me.Rdb_Pr_AutoPr_Correlativo_Por_Iniciales.Size = New System.Drawing.Size(147, 23)
        Me.Rdb_Pr_AutoPr_Correlativo_Por_Iniciales.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Pr_AutoPr_Correlativo_Por_Iniciales.TabIndex = 64
        Me.Rdb_Pr_AutoPr_Correlativo_Por_Iniciales.Text = "Correlativo por iniciales"
        '
        'Rdb_Pr_AutoPr_Correlativo_General
        '
        Me.Rdb_Pr_AutoPr_Correlativo_General.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Pr_AutoPr_Correlativo_General.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Pr_AutoPr_Correlativo_General.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Pr_AutoPr_Correlativo_General.Location = New System.Drawing.Point(3, 3)
        Me.Rdb_Pr_AutoPr_Correlativo_General.Name = "Rdb_Pr_AutoPr_Correlativo_General"
        Me.Rdb_Pr_AutoPr_Correlativo_General.Size = New System.Drawing.Size(179, 23)
        Me.Rdb_Pr_AutoPr_Correlativo_General.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Pr_AutoPr_Correlativo_General.TabIndex = 65
        Me.Rdb_Pr_AutoPr_Correlativo_General.Text = "Correlativo único por empresa"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.Controls.Add(Me.chk_Pr_Creacion_Exigir_Dimensiones, 1, 7)
        Me.TableLayoutPanel1.Controls.Add(Me.Chk_Alerta_Costo_Lista_Distinto_Costo_Proveedor, 1, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.Chk_Revisar_OCC_Pendientes_X_Productos, 1, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.Chk_Grabar_Despachos_Con_Huella, 1, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.Chk_Pedir_Permiso_Para_Usar_Stanby, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.Chk_BloqEdiConcepRecargo, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Chk_BloqEdiConcepDescuento, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Chk_Pr_Creacion_Exigir_Codigo_Alternativo, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.Chk_Pr_Creacion_Exigir_Clasificacion_busqueda, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.Chk_Pr_Creacion_Exigir_Precio, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Chk_Revisar_Tasa_de_Cambio, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Chk_Pr_Desc_Producto_Solo_Mayusculas, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Chk_Pr_AutoPr_Crear_Codigo_Principal_Automatico, 0, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.Chk_Revisar_Taza_Solo_Mon_Extranjeras, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Chk_Solicitar_Permiso_OCC_SOC, 0, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.Chk_Centro_Costo_Obligatorio_OCC, 0, 7)
        Me.TableLayoutPanel1.Controls.Add(Me.Chk_Utilizar_NVV_En_Credito_X_Cliente, 0, 8)
        Me.TableLayoutPanel1.Controls.Add(Me.Chk_No_Permitir_Grabar_Con_Dscto_Superado, 0, 9)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(16, 53)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 13
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(632, 244)
        Me.TableLayoutPanel1.TabIndex = 20
        '
        'chk_Pr_Creacion_Exigir_Dimensiones
        '
        Me.chk_Pr_Creacion_Exigir_Dimensiones.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.chk_Pr_Creacion_Exigir_Dimensiones.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.chk_Pr_Creacion_Exigir_Dimensiones.ForeColor = System.Drawing.Color.Black
        Me.chk_Pr_Creacion_Exigir_Dimensiones.Location = New System.Drawing.Point(298, 181)
        Me.chk_Pr_Creacion_Exigir_Dimensiones.Name = "chk_Pr_Creacion_Exigir_Dimensiones"
        Me.chk_Pr_Creacion_Exigir_Dimensiones.Size = New System.Drawing.Size(283, 14)
        Me.chk_Pr_Creacion_Exigir_Dimensiones.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.chk_Pr_Creacion_Exigir_Dimensiones.TabIndex = 93
        Me.chk_Pr_Creacion_Exigir_Dimensiones.Text = "Al crear el producto exigir dimensiones"
        '
        'Chk_Alerta_Costo_Lista_Distinto_Costo_Proveedor
        '
        '
        '
        '
        Me.Chk_Alerta_Costo_Lista_Distinto_Costo_Proveedor.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Alerta_Costo_Lista_Distinto_Costo_Proveedor.Location = New System.Drawing.Point(298, 143)
        Me.Chk_Alerta_Costo_Lista_Distinto_Costo_Proveedor.Name = "Chk_Alerta_Costo_Lista_Distinto_Costo_Proveedor"
        Me.Chk_Alerta_Costo_Lista_Distinto_Costo_Proveedor.Size = New System.Drawing.Size(324, 32)
        Me.Chk_Alerta_Costo_Lista_Distinto_Costo_Proveedor.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Alerta_Costo_Lista_Distinto_Costo_Proveedor.TabIndex = 94
        Me.Chk_Alerta_Costo_Lista_Distinto_Costo_Proveedor.Text = "Alertar si costos de proveedores son distintos al costo de lista del documento"
        '
        'Chk_Revisar_OCC_Pendientes_X_Productos
        '
        '
        '
        '
        Me.Chk_Revisar_OCC_Pendientes_X_Productos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Revisar_OCC_Pendientes_X_Productos.Location = New System.Drawing.Point(298, 122)
        Me.Chk_Revisar_OCC_Pendientes_X_Productos.Name = "Chk_Revisar_OCC_Pendientes_X_Productos"
        Me.Chk_Revisar_OCC_Pendientes_X_Productos.Size = New System.Drawing.Size(324, 14)
        Me.Chk_Revisar_OCC_Pendientes_X_Productos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Revisar_OCC_Pendientes_X_Productos.TabIndex = 93
        Me.Chk_Revisar_OCC_Pendientes_X_Productos.Text = "Revisar si hay OCC Pendientes antes de grabar una OCC"
        '
        'Chk_Grabar_Despachos_Con_Huella
        '
        '
        '
        '
        Me.Chk_Grabar_Despachos_Con_Huella.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Grabar_Despachos_Con_Huella.Location = New System.Drawing.Point(298, 86)
        Me.Chk_Grabar_Despachos_Con_Huella.Name = "Chk_Grabar_Despachos_Con_Huella"
        Me.Chk_Grabar_Despachos_Con_Huella.Size = New System.Drawing.Size(324, 30)
        Me.Chk_Grabar_Despachos_Con_Huella.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Grabar_Despachos_Con_Huella.TabIndex = 85
        Me.Chk_Grabar_Despachos_Con_Huella.Text = "Grabar gestión de despacho validando al usuario con la huella digital"
        '
        'Chk_Pedir_Permiso_Para_Usar_Stanby
        '
        '
        '
        '
        Me.Chk_Pedir_Permiso_Para_Usar_Stanby.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Pedir_Permiso_Para_Usar_Stanby.Location = New System.Drawing.Point(298, 66)
        Me.Chk_Pedir_Permiso_Para_Usar_Stanby.Name = "Chk_Pedir_Permiso_Para_Usar_Stanby"
        Me.Chk_Pedir_Permiso_Para_Usar_Stanby.Size = New System.Drawing.Size(324, 14)
        Me.Chk_Pedir_Permiso_Para_Usar_Stanby.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Pedir_Permiso_Para_Usar_Stanby.TabIndex = 84
        Me.Chk_Pedir_Permiso_Para_Usar_Stanby.Text = "Pedir permisos para utilizar opción Stand-By en documentos"
        '
        'Chk_BloqEdiConcepRecargo
        '
        '
        '
        '
        Me.Chk_BloqEdiConcepRecargo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_BloqEdiConcepRecargo.Location = New System.Drawing.Point(298, 45)
        Me.Chk_BloqEdiConcepRecargo.Name = "Chk_BloqEdiConcepRecargo"
        Me.Chk_BloqEdiConcepRecargo.Size = New System.Drawing.Size(297, 15)
        Me.Chk_BloqEdiConcepRecargo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_BloqEdiConcepRecargo.TabIndex = 83
        Me.Chk_BloqEdiConcepRecargo.Text = "Bloquear la edición de conceptos de recargo en doc."
        '
        'Chk_BloqEdiConcepDescuento
        '
        '
        '
        '
        Me.Chk_BloqEdiConcepDescuento.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_BloqEdiConcepDescuento.Location = New System.Drawing.Point(298, 24)
        Me.Chk_BloqEdiConcepDescuento.Name = "Chk_BloqEdiConcepDescuento"
        Me.Chk_BloqEdiConcepDescuento.Size = New System.Drawing.Size(297, 15)
        Me.Chk_BloqEdiConcepDescuento.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_BloqEdiConcepDescuento.TabIndex = 82
        Me.Chk_BloqEdiConcepDescuento.Text = "Bloquear la edición de conceptos de descuento en doc."
        '
        'Chk_Pr_Creacion_Exigir_Codigo_Alternativo
        '
        Me.Chk_Pr_Creacion_Exigir_Codigo_Alternativo.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_Pr_Creacion_Exigir_Codigo_Alternativo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Pr_Creacion_Exigir_Codigo_Alternativo.ForeColor = System.Drawing.Color.Black
        Me.Chk_Pr_Creacion_Exigir_Codigo_Alternativo.Location = New System.Drawing.Point(3, 86)
        Me.Chk_Pr_Creacion_Exigir_Codigo_Alternativo.Name = "Chk_Pr_Creacion_Exigir_Codigo_Alternativo"
        Me.Chk_Pr_Creacion_Exigir_Codigo_Alternativo.Size = New System.Drawing.Size(283, 14)
        Me.Chk_Pr_Creacion_Exigir_Codigo_Alternativo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Pr_Creacion_Exigir_Codigo_Alternativo.TabIndex = 24
        Me.Chk_Pr_Creacion_Exigir_Codigo_Alternativo.Text = "Al crear el producto exigir código alternativo"
        '
        'Chk_Pr_Creacion_Exigir_Clasificacion_busqueda
        '
        Me.Chk_Pr_Creacion_Exigir_Clasificacion_busqueda.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_Pr_Creacion_Exigir_Clasificacion_busqueda.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Pr_Creacion_Exigir_Clasificacion_busqueda.ForeColor = System.Drawing.Color.Black
        Me.Chk_Pr_Creacion_Exigir_Clasificacion_busqueda.Location = New System.Drawing.Point(3, 66)
        Me.Chk_Pr_Creacion_Exigir_Clasificacion_busqueda.Name = "Chk_Pr_Creacion_Exigir_Clasificacion_busqueda"
        Me.Chk_Pr_Creacion_Exigir_Clasificacion_busqueda.Size = New System.Drawing.Size(283, 14)
        Me.Chk_Pr_Creacion_Exigir_Clasificacion_busqueda.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Pr_Creacion_Exigir_Clasificacion_busqueda.TabIndex = 23
        Me.Chk_Pr_Creacion_Exigir_Clasificacion_busqueda.Text = "Al crear el producto exigir clasificación de búsqueda"
        '
        'Chk_Pr_Creacion_Exigir_Precio
        '
        Me.Chk_Pr_Creacion_Exigir_Precio.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_Pr_Creacion_Exigir_Precio.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Pr_Creacion_Exigir_Precio.ForeColor = System.Drawing.Color.Black
        Me.Chk_Pr_Creacion_Exigir_Precio.Location = New System.Drawing.Point(3, 45)
        Me.Chk_Pr_Creacion_Exigir_Precio.Name = "Chk_Pr_Creacion_Exigir_Precio"
        Me.Chk_Pr_Creacion_Exigir_Precio.Size = New System.Drawing.Size(283, 15)
        Me.Chk_Pr_Creacion_Exigir_Precio.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Pr_Creacion_Exigir_Precio.TabIndex = 22
        Me.Chk_Pr_Creacion_Exigir_Precio.Text = "Al crear el producto exigir el precio"
        '
        'Chk_Pr_Desc_Producto_Solo_Mayusculas
        '
        Me.Chk_Pr_Desc_Producto_Solo_Mayusculas.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_Pr_Desc_Producto_Solo_Mayusculas.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Pr_Desc_Producto_Solo_Mayusculas.ForeColor = System.Drawing.Color.Black
        Me.Chk_Pr_Desc_Producto_Solo_Mayusculas.Location = New System.Drawing.Point(3, 24)
        Me.Chk_Pr_Desc_Producto_Solo_Mayusculas.Name = "Chk_Pr_Desc_Producto_Solo_Mayusculas"
        Me.Chk_Pr_Desc_Producto_Solo_Mayusculas.Size = New System.Drawing.Size(283, 15)
        Me.Chk_Pr_Desc_Producto_Solo_Mayusculas.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Pr_Desc_Producto_Solo_Mayusculas.TabIndex = 19
        Me.Chk_Pr_Desc_Producto_Solo_Mayusculas.Text = "Crear descripción de productos con solo mayúsculas"
        '
        'Chk_Pr_AutoPr_Crear_Codigo_Principal_Automatico
        '
        Me.Chk_Pr_AutoPr_Crear_Codigo_Principal_Automatico.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_Pr_AutoPr_Crear_Codigo_Principal_Automatico.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Pr_AutoPr_Crear_Codigo_Principal_Automatico.ForeColor = System.Drawing.Color.Black
        Me.Chk_Pr_AutoPr_Crear_Codigo_Principal_Automatico.Location = New System.Drawing.Point(3, 122)
        Me.Chk_Pr_AutoPr_Crear_Codigo_Principal_Automatico.Name = "Chk_Pr_AutoPr_Crear_Codigo_Principal_Automatico"
        Me.Chk_Pr_AutoPr_Crear_Codigo_Principal_Automatico.Size = New System.Drawing.Size(283, 15)
        Me.Chk_Pr_AutoPr_Crear_Codigo_Principal_Automatico.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Pr_AutoPr_Crear_Codigo_Principal_Automatico.TabIndex = 20
        Me.Chk_Pr_AutoPr_Crear_Codigo_Principal_Automatico.Text = "Crear código principal automaticamente"
        '
        'Chk_Revisar_Taza_Solo_Mon_Extranjeras
        '
        '
        '
        '
        Me.Chk_Revisar_Taza_Solo_Mon_Extranjeras.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Revisar_Taza_Solo_Mon_Extranjeras.Location = New System.Drawing.Point(298, 3)
        Me.Chk_Revisar_Taza_Solo_Mon_Extranjeras.Name = "Chk_Revisar_Taza_Solo_Mon_Extranjeras"
        Me.Chk_Revisar_Taza_Solo_Mon_Extranjeras.Size = New System.Drawing.Size(152, 15)
        Me.Chk_Revisar_Taza_Solo_Mon_Extranjeras.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Revisar_Taza_Solo_Mon_Extranjeras.TabIndex = 22
        Me.Chk_Revisar_Taza_Solo_Mon_Extranjeras.Text = "Solo monedas extranjeras"
        '
        'Chk_Solicitar_Permiso_OCC_SOC
        '
        '
        '
        '
        Me.Chk_Solicitar_Permiso_OCC_SOC.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Solicitar_Permiso_OCC_SOC.Location = New System.Drawing.Point(3, 143)
        Me.Chk_Solicitar_Permiso_OCC_SOC.Name = "Chk_Solicitar_Permiso_OCC_SOC"
        Me.Chk_Solicitar_Permiso_OCC_SOC.Size = New System.Drawing.Size(289, 15)
        Me.Chk_Solicitar_Permiso_OCC_SOC.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Solicitar_Permiso_OCC_SOC.TabIndex = 82
        Me.Chk_Solicitar_Permiso_OCC_SOC.Text = "Solictar permisos al grabar OCC"
        '
        'Chk_Centro_Costo_Obligatorio_OCC
        '
        '
        '
        '
        Me.Chk_Centro_Costo_Obligatorio_OCC.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Centro_Costo_Obligatorio_OCC.Location = New System.Drawing.Point(3, 181)
        Me.Chk_Centro_Costo_Obligatorio_OCC.Name = "Chk_Centro_Costo_Obligatorio_OCC"
        Me.Chk_Centro_Costo_Obligatorio_OCC.Size = New System.Drawing.Size(276, 15)
        Me.Chk_Centro_Costo_Obligatorio_OCC.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Centro_Costo_Obligatorio_OCC.TabIndex = 82
        Me.Chk_Centro_Costo_Obligatorio_OCC.Text = "Ingresar C.Costo en las compras obligatoriamente"
        '
        'Chk_Utilizar_NVV_En_Credito_X_Cliente
        '
        '
        '
        '
        Me.Chk_Utilizar_NVV_En_Credito_X_Cliente.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Utilizar_NVV_En_Credito_X_Cliente.Location = New System.Drawing.Point(3, 202)
        Me.Chk_Utilizar_NVV_En_Credito_X_Cliente.Name = "Chk_Utilizar_NVV_En_Credito_X_Cliente"
        Me.Chk_Utilizar_NVV_En_Credito_X_Cliente.Size = New System.Drawing.Size(276, 14)
        Me.Chk_Utilizar_NVV_En_Credito_X_Cliente.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Utilizar_NVV_En_Credito_X_Cliente.TabIndex = 83
        Me.Chk_Utilizar_NVV_En_Credito_X_Cliente.Text = "Considera NVV abiertas como cupo utilizado"
        '
        'Chk_No_Permitir_Grabar_Con_Dscto_Superado
        '
        '
        '
        '
        Me.Chk_No_Permitir_Grabar_Con_Dscto_Superado.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_No_Permitir_Grabar_Con_Dscto_Superado.Location = New System.Drawing.Point(3, 222)
        Me.Chk_No_Permitir_Grabar_Con_Dscto_Superado.Name = "Chk_No_Permitir_Grabar_Con_Dscto_Superado"
        Me.Chk_No_Permitir_Grabar_Con_Dscto_Superado.Size = New System.Drawing.Size(276, 14)
        Me.Chk_No_Permitir_Grabar_Con_Dscto_Superado.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_No_Permitir_Grabar_Con_Dscto_Superado.TabIndex = 84
        Me.Chk_No_Permitir_Grabar_Con_Dscto_Superado.Text = "No Permitir Grabar Venta Con Dscto Superado"
        '
        'LabelX4
        '
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.Dock = System.Windows.Forms.DockStyle.Top
        Me.LabelX4.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX4.Location = New System.Drawing.Point(0, 0)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(651, 52)
        Me.LabelX4.TabIndex = 0
        Me.LabelX4.Text = "Opciones generales"
        Me.LabelX4.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'SPage_Venta
        '
        Me.SPage_Venta.Controls.Add(Me.Chk_Conservar_Bodega_Sig_Linea_Venta)
        Me.SPage_Venta.Controls.Add(Me.Input_Dias_Max_Fecha_Despacho)
        Me.SPage_Venta.Controls.Add(Me.Chk_Dias_Max_Fecha_Despacho_Dom)
        Me.SPage_Venta.Controls.Add(Me.Chk_Dias_Max_Fecha_Despacho_Sab)
        Me.SPage_Venta.Controls.Add(Me.LabelX16)
        Me.SPage_Venta.Controls.Add(Me.TableLayoutPanel5)
        Me.SPage_Venta.Controls.Add(Me.TableLayoutPanel3)
        Me.SPage_Venta.Controls.Add(Me.Grupo_Especial_Venta_01)
        Me.SPage_Venta.Controls.Add(Me.LabelX7)
        Me.SPage_Venta.Location = New System.Drawing.Point(4, 4)
        Me.SPage_Venta.Name = "SPage_Venta"
        Me.SPage_Venta.Size = New System.Drawing.Size(651, 476)
        Me.SPage_Venta.TabIndex = 5
        '
        'Chk_Conservar_Bodega_Sig_Linea_Venta
        '
        Me.Chk_Conservar_Bodega_Sig_Linea_Venta.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_Conservar_Bodega_Sig_Linea_Venta.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Conservar_Bodega_Sig_Linea_Venta.Location = New System.Drawing.Point(9, 215)
        Me.Chk_Conservar_Bodega_Sig_Linea_Venta.Name = "Chk_Conservar_Bodega_Sig_Linea_Venta"
        Me.Chk_Conservar_Bodega_Sig_Linea_Venta.Size = New System.Drawing.Size(635, 14)
        Me.Chk_Conservar_Bodega_Sig_Linea_Venta.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Conservar_Bodega_Sig_Linea_Venta.TabIndex = 90
        Me.Chk_Conservar_Bodega_Sig_Linea_Venta.Text = "Conservar la bodega en la siguiente línea de un documento de ventas"
        Me.Chk_Conservar_Bodega_Sig_Linea_Venta.TextColor = System.Drawing.Color.Black
        '
        'Input_Dias_Max_Fecha_Despacho
        '
        '
        '
        '
        Me.Input_Dias_Max_Fecha_Despacho.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Input_Dias_Max_Fecha_Despacho.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Input_Dias_Max_Fecha_Despacho.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.Input_Dias_Max_Fecha_Despacho.Location = New System.Drawing.Point(323, 242)
        Me.Input_Dias_Max_Fecha_Despacho.MaxValue = 365
        Me.Input_Dias_Max_Fecha_Despacho.Name = "Input_Dias_Max_Fecha_Despacho"
        Me.Input_Dias_Max_Fecha_Despacho.ShowUpDown = True
        Me.Input_Dias_Max_Fecha_Despacho.Size = New System.Drawing.Size(49, 20)
        Me.Input_Dias_Max_Fecha_Despacho.TabIndex = 86
        '
        'Chk_Dias_Max_Fecha_Despacho_Dom
        '
        '
        '
        '
        Me.Chk_Dias_Max_Fecha_Despacho_Dom.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Dias_Max_Fecha_Despacho_Dom.Location = New System.Drawing.Point(9, 284)
        Me.Chk_Dias_Max_Fecha_Despacho_Dom.Name = "Chk_Dias_Max_Fecha_Despacho_Dom"
        Me.Chk_Dias_Max_Fecha_Despacho_Dom.Size = New System.Drawing.Size(216, 20)
        Me.Chk_Dias_Max_Fecha_Despacho_Dom.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Dias_Max_Fecha_Despacho_Dom.TabIndex = 89
        Me.Chk_Dias_Max_Fecha_Despacho_Dom.Text = "Considerar domingo en despacho"
        '
        'Chk_Dias_Max_Fecha_Despacho_Sab
        '
        '
        '
        '
        Me.Chk_Dias_Max_Fecha_Despacho_Sab.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Dias_Max_Fecha_Despacho_Sab.Location = New System.Drawing.Point(9, 267)
        Me.Chk_Dias_Max_Fecha_Despacho_Sab.Name = "Chk_Dias_Max_Fecha_Despacho_Sab"
        Me.Chk_Dias_Max_Fecha_Despacho_Sab.Size = New System.Drawing.Size(248, 14)
        Me.Chk_Dias_Max_Fecha_Despacho_Sab.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Dias_Max_Fecha_Despacho_Sab.TabIndex = 87
        Me.Chk_Dias_Max_Fecha_Despacho_Sab.Text = "Considerar sábado en despacho"
        '
        'LabelX16
        '
        '
        '
        '
        Me.LabelX16.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX16.Location = New System.Drawing.Point(9, 242)
        Me.LabelX16.Name = "LabelX16"
        Me.LabelX16.Size = New System.Drawing.Size(301, 19)
        Me.LabelX16.TabIndex = 88
        Me.LabelX16.Text = "máximo de días para despacho en notas de venta"
        '
        'TableLayoutPanel5
        '
        Me.TableLayoutPanel5.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel5.ColumnCount = 1
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel5.Controls.Add(Me.Chk_Preguntar_Documento, 0, 0)
        Me.TableLayoutPanel5.Controls.Add(Me.Chk_Conservar_Responzable_Doc_Relacionado, 0, 3)
        Me.TableLayoutPanel5.Controls.Add(Me.Chk_Redondear_Dscto_Cero, 0, 1)
        Me.TableLayoutPanel5.Controls.Add(Me.Chk_Vnta_Ofrecer_Otras_Bod_Stock_Insuficiente, 0, 2)
        Me.TableLayoutPanel5.Controls.Add(Me.Chk_Preguntar_Si_Cambia_Responsable_Doc_Relacionado, 0, 4)
        Me.TableLayoutPanel5.Location = New System.Drawing.Point(6, 112)
        Me.TableLayoutPanel5.Name = "TableLayoutPanel5"
        Me.TableLayoutPanel5.RowCount = 5
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel5.Size = New System.Drawing.Size(642, 100)
        Me.TableLayoutPanel5.TabIndex = 85
        '
        'Chk_Preguntar_Documento
        '
        Me.Chk_Preguntar_Documento.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_Preguntar_Documento.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Preguntar_Documento.Location = New System.Drawing.Point(3, 3)
        Me.Chk_Preguntar_Documento.Name = "Chk_Preguntar_Documento"
        Me.Chk_Preguntar_Documento.Size = New System.Drawing.Size(461, 14)
        Me.Chk_Preguntar_Documento.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Preguntar_Documento.TabIndex = 74
        Me.Chk_Preguntar_Documento.Text = "<font color=""#000000"">Preguntar documento primero (Post-Venta)</font><font color=" &
    """#000000""></font>"
        Me.Chk_Preguntar_Documento.TextColor = System.Drawing.Color.Black
        '
        'Chk_Conservar_Responzable_Doc_Relacionado
        '
        Me.Chk_Conservar_Responzable_Doc_Relacionado.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_Conservar_Responzable_Doc_Relacionado.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Conservar_Responzable_Doc_Relacionado.Location = New System.Drawing.Point(3, 63)
        Me.Chk_Conservar_Responzable_Doc_Relacionado.Name = "Chk_Conservar_Responzable_Doc_Relacionado"
        Me.Chk_Conservar_Responzable_Doc_Relacionado.Size = New System.Drawing.Size(635, 14)
        Me.Chk_Conservar_Responzable_Doc_Relacionado.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Conservar_Responzable_Doc_Relacionado.TabIndex = 84
        Me.Chk_Conservar_Responzable_Doc_Relacionado.Text = "<font color=""#000000"">Conservar como responsable del documento al funcionario de " &
    "origen cuando se genera un documento desde otro documento</font>"
        Me.Chk_Conservar_Responzable_Doc_Relacionado.TextColor = System.Drawing.Color.Black
        '
        'Chk_Redondear_Dscto_Cero
        '
        Me.Chk_Redondear_Dscto_Cero.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_Redondear_Dscto_Cero.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Redondear_Dscto_Cero.Location = New System.Drawing.Point(3, 23)
        Me.Chk_Redondear_Dscto_Cero.Name = "Chk_Redondear_Dscto_Cero"
        Me.Chk_Redondear_Dscto_Cero.Size = New System.Drawing.Size(461, 14)
        Me.Chk_Redondear_Dscto_Cero.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Redondear_Dscto_Cero.TabIndex = 82
        Me.Chk_Redondear_Dscto_Cero.Text = "<font color=""#000000"">Redondear en los descuentos a cero</font><font color=""#0000" &
    "00""></font>"
        Me.Chk_Redondear_Dscto_Cero.TextColor = System.Drawing.Color.Black
        '
        'Chk_Vnta_Ofrecer_Otras_Bod_Stock_Insuficiente
        '
        Me.Chk_Vnta_Ofrecer_Otras_Bod_Stock_Insuficiente.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_Vnta_Ofrecer_Otras_Bod_Stock_Insuficiente.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Vnta_Ofrecer_Otras_Bod_Stock_Insuficiente.Location = New System.Drawing.Point(3, 43)
        Me.Chk_Vnta_Ofrecer_Otras_Bod_Stock_Insuficiente.Name = "Chk_Vnta_Ofrecer_Otras_Bod_Stock_Insuficiente"
        Me.Chk_Vnta_Ofrecer_Otras_Bod_Stock_Insuficiente.Size = New System.Drawing.Size(461, 14)
        Me.Chk_Vnta_Ofrecer_Otras_Bod_Stock_Insuficiente.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Vnta_Ofrecer_Otras_Bod_Stock_Insuficiente.TabIndex = 83
        Me.Chk_Vnta_Ofrecer_Otras_Bod_Stock_Insuficiente.Text = "Ofrecer otras bodegas cuando hay stock insuficiente"
        Me.Chk_Vnta_Ofrecer_Otras_Bod_Stock_Insuficiente.TextColor = System.Drawing.Color.Black
        '
        'Chk_Preguntar_Si_Cambia_Responsable_Doc_Relacionado
        '
        Me.Chk_Preguntar_Si_Cambia_Responsable_Doc_Relacionado.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_Preguntar_Si_Cambia_Responsable_Doc_Relacionado.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Preguntar_Si_Cambia_Responsable_Doc_Relacionado.Location = New System.Drawing.Point(3, 83)
        Me.Chk_Preguntar_Si_Cambia_Responsable_Doc_Relacionado.Name = "Chk_Preguntar_Si_Cambia_Responsable_Doc_Relacionado"
        Me.Chk_Preguntar_Si_Cambia_Responsable_Doc_Relacionado.Size = New System.Drawing.Size(635, 14)
        Me.Chk_Preguntar_Si_Cambia_Responsable_Doc_Relacionado.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Preguntar_Si_Cambia_Responsable_Doc_Relacionado.TabIndex = 84
        Me.Chk_Preguntar_Si_Cambia_Responsable_Doc_Relacionado.Text = "<font color=""#000000"">Preguntar si cambia al responsable del documento cuando se " &
    "genera desde otro documento" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "</font>"
        Me.Chk_Preguntar_Si_Cambia_Responsable_Doc_Relacionado.TextColor = System.Drawing.Color.Black
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel3.ColumnCount = 2
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 66.81128!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.18872!))
        Me.TableLayoutPanel3.Controls.Add(Me.LabelX1, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.LabelX9, 0, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.Txt_Dias_Venci_Coti, 1, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.Cmb_TipoValor_Bruto_Neto, 1, 1)
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(6, 53)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 2
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(471, 53)
        Me.TableLayoutPanel3.TabIndex = 81
        '
        'LabelX1
        '
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Location = New System.Drawing.Point(3, 3)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(280, 19)
        Me.LabelX1.TabIndex = 12
        Me.LabelX1.Text = "Días para el vencimiento de las cotizaciones"
        '
        'LabelX9
        '
        '
        '
        '
        Me.LabelX9.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX9.Location = New System.Drawing.Point(3, 29)
        Me.LabelX9.Name = "LabelX9"
        Me.LabelX9.Size = New System.Drawing.Size(280, 19)
        Me.LabelX9.TabIndex = 72
        Me.LabelX9.Text = "Tipo de valor en documentos de venta"
        '
        'Txt_Dias_Venci_Coti
        '
        Me.Txt_Dias_Venci_Coti.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Dias_Venci_Coti.Border.Class = "TextBoxBorder"
        Me.Txt_Dias_Venci_Coti.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Dias_Venci_Coti.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Dias_Venci_Coti.ForeColor = System.Drawing.Color.Black
        Me.Txt_Dias_Venci_Coti.Location = New System.Drawing.Point(317, 3)
        Me.Txt_Dias_Venci_Coti.Name = "Txt_Dias_Venci_Coti"
        Me.Txt_Dias_Venci_Coti.PreventEnterBeep = True
        Me.Txt_Dias_Venci_Coti.Size = New System.Drawing.Size(49, 20)
        Me.Txt_Dias_Venci_Coti.TabIndex = 13
        '
        'Cmb_TipoValor_Bruto_Neto
        '
        Me.Cmb_TipoValor_Bruto_Neto.DisplayMember = "Text"
        Me.Cmb_TipoValor_Bruto_Neto.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.Cmb_TipoValor_Bruto_Neto.ForeColor = System.Drawing.Color.Black
        Me.Cmb_TipoValor_Bruto_Neto.FormattingEnabled = True
        Me.Cmb_TipoValor_Bruto_Neto.ItemHeight = 16
        Me.Cmb_TipoValor_Bruto_Neto.Location = New System.Drawing.Point(317, 29)
        Me.Cmb_TipoValor_Bruto_Neto.Name = "Cmb_TipoValor_Bruto_Neto"
        Me.Cmb_TipoValor_Bruto_Neto.Size = New System.Drawing.Size(140, 22)
        Me.Cmb_TipoValor_Bruto_Neto.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Cmb_TipoValor_Bruto_Neto.TabIndex = 73
        '
        'Grupo_Especial_Venta_01
        '
        Me.Grupo_Especial_Venta_01.BackColor = System.Drawing.Color.Transparent
        Me.Grupo_Especial_Venta_01.CanvasColor = System.Drawing.SystemColors.Control
        Me.Grupo_Especial_Venta_01.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Grupo_Especial_Venta_01.Controls.Add(Me.LabelX10)
        Me.Grupo_Especial_Venta_01.Controls.Add(Me.LabelX11)
        Me.Grupo_Especial_Venta_01.Controls.Add(Me.Btn_Buscar_Cliente)
        Me.Grupo_Especial_Venta_01.Controls.Add(Me.Txt_Producto_Comodin)
        Me.Grupo_Especial_Venta_01.Controls.Add(Me.Txt_Cliente)
        Me.Grupo_Especial_Venta_01.Controls.Add(Me.Btn_Buscar_producto)
        Me.Grupo_Especial_Venta_01.DisabledBackColor = System.Drawing.Color.Empty
        Me.Grupo_Especial_Venta_01.Location = New System.Drawing.Point(9, 324)
        Me.Grupo_Especial_Venta_01.Name = "Grupo_Especial_Venta_01"
        Me.Grupo_Especial_Venta_01.Size = New System.Drawing.Size(622, 133)
        '
        '
        '
        Me.Grupo_Especial_Venta_01.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Grupo_Especial_Venta_01.Style.BackColorGradientAngle = 90
        Me.Grupo_Especial_Venta_01.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Grupo_Especial_Venta_01.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Especial_Venta_01.Style.BorderBottomWidth = 1
        Me.Grupo_Especial_Venta_01.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.Grupo_Especial_Venta_01.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Especial_Venta_01.Style.BorderLeftWidth = 1
        Me.Grupo_Especial_Venta_01.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Especial_Venta_01.Style.BorderRightWidth = 1
        Me.Grupo_Especial_Venta_01.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Especial_Venta_01.Style.BorderTopWidth = 1
        Me.Grupo_Especial_Venta_01.Style.CornerDiameter = 4
        Me.Grupo_Especial_Venta_01.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Grupo_Especial_Venta_01.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.Grupo_Especial_Venta_01.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.Grupo_Especial_Venta_01.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.Grupo_Especial_Venta_01.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.Grupo_Especial_Venta_01.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Grupo_Especial_Venta_01.TabIndex = 80
        Me.Grupo_Especial_Venta_01.Text = "Especial venta"
        '
        'LabelX10
        '
        Me.LabelX10.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX10.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX10.Location = New System.Drawing.Point(3, 4)
        Me.LabelX10.Name = "LabelX10"
        Me.LabelX10.Size = New System.Drawing.Size(207, 23)
        Me.LabelX10.TabIndex = 76
        Me.LabelX10.Text = "Cliente por defecto"
        '
        'LabelX11
        '
        Me.LabelX11.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX11.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX11.Location = New System.Drawing.Point(3, 56)
        Me.LabelX11.Name = "LabelX11"
        Me.LabelX11.Size = New System.Drawing.Size(346, 23)
        Me.LabelX11.TabIndex = 79
        Me.LabelX11.Text = "Producto no creado para cotizaciones y notas de venta (comodín)"
        '
        'Btn_Buscar_Cliente
        '
        Me.Btn_Buscar_Cliente.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Buscar_Cliente.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Buscar_Cliente.Image = CType(resources.GetObject("Btn_Buscar_Cliente.Image"), System.Drawing.Image)
        Me.Btn_Buscar_Cliente.Location = New System.Drawing.Point(2, 27)
        Me.Btn_Buscar_Cliente.Name = "Btn_Buscar_Cliente"
        Me.Btn_Buscar_Cliente.Size = New System.Drawing.Size(39, 23)
        Me.Btn_Buscar_Cliente.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Buscar_Cliente.TabIndex = 74
        Me.Btn_Buscar_Cliente.Tooltip = "Buscar cliente"
        '
        'Txt_Producto_Comodin
        '
        Me.Txt_Producto_Comodin.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Producto_Comodin.Border.Class = "TextBoxBorder"
        Me.Txt_Producto_Comodin.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Producto_Comodin.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Producto_Comodin.Enabled = False
        Me.Txt_Producto_Comodin.ForeColor = System.Drawing.Color.Black
        Me.Txt_Producto_Comodin.Location = New System.Drawing.Point(47, 82)
        Me.Txt_Producto_Comodin.Name = "Txt_Producto_Comodin"
        Me.Txt_Producto_Comodin.PreventEnterBeep = True
        Me.Txt_Producto_Comodin.ReadOnly = True
        Me.Txt_Producto_Comodin.Size = New System.Drawing.Size(566, 20)
        Me.Txt_Producto_Comodin.TabIndex = 78
        '
        'Txt_Cliente
        '
        Me.Txt_Cliente.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Cliente.Border.Class = "TextBoxBorder"
        Me.Txt_Cliente.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Cliente.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Cliente.Enabled = False
        Me.Txt_Cliente.ForeColor = System.Drawing.Color.Black
        Me.Txt_Cliente.Location = New System.Drawing.Point(47, 30)
        Me.Txt_Cliente.Name = "Txt_Cliente"
        Me.Txt_Cliente.PreventEnterBeep = True
        Me.Txt_Cliente.ReadOnly = True
        Me.Txt_Cliente.Size = New System.Drawing.Size(566, 20)
        Me.Txt_Cliente.TabIndex = 75
        '
        'Btn_Buscar_producto
        '
        Me.Btn_Buscar_producto.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Buscar_producto.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Buscar_producto.Image = CType(resources.GetObject("Btn_Buscar_producto.Image"), System.Drawing.Image)
        Me.Btn_Buscar_producto.Location = New System.Drawing.Point(3, 79)
        Me.Btn_Buscar_producto.Name = "Btn_Buscar_producto"
        Me.Btn_Buscar_producto.Size = New System.Drawing.Size(39, 23)
        Me.Btn_Buscar_producto.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Buscar_producto.TabIndex = 77
        Me.Btn_Buscar_producto.Tooltip = "Buscar cliente"
        '
        'LabelX7
        '
        '
        '
        '
        Me.LabelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX7.Dock = System.Windows.Forms.DockStyle.Top
        Me.LabelX7.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX7.Location = New System.Drawing.Point(0, 0)
        Me.LabelX7.Name = "LabelX7"
        Me.LabelX7.Size = New System.Drawing.Size(651, 52)
        Me.LabelX7.TabIndex = 14
        Me.LabelX7.Text = "General Ventas"
        Me.LabelX7.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'Lbl_Modalidad
        '
        '
        '
        '
        Me.Lbl_Modalidad.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Modalidad.Font = New System.Drawing.Font("Century Gothic", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Modalidad.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(159, Byte), Integer), CType(CType(206, Byte), Integer))
        Me.Lbl_Modalidad.Location = New System.Drawing.Point(4, 0)
        Me.Lbl_Modalidad.Name = "Lbl_Modalidad"
        Me.Lbl_Modalidad.Size = New System.Drawing.Size(245, 49)
        Me.Lbl_Modalidad.TabIndex = 56
        Me.Lbl_Modalidad.Text = "<font color=""#349FCE""><b>MENÚ PRINCIPAL</b></font>"
        '
        'Cntrl_Configuracion_General
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Lbl_Modalidad)
        Me.Controls.Add(Me.pageSlider1)
        Me.Controls.Add(Me.Bar1)
        Me.Name = "Cntrl_Configuracion_General"
        Me.Size = New System.Drawing.Size(784, 615)
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pageSlider1.ResumeLayout(False)
        Me.Spage_SOC.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.GroupPanel1.ResumeLayout(False)
        Me.SPage_Opciones_Generales.ResumeLayout(False)
        CType(Me.Input_Monto_Max_CRV_FacMasiva, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Grupo_Codigo_Automatico.ResumeLayout(False)
        Me.TableLayoutPanel4.ResumeLayout(False)
        CType(Me.Txt_Pr_AutoPr_Max_Cant_Caracteres_Del_Codigo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.SPage_Venta.ResumeLayout(False)
        CType(Me.Input_Dias_Max_Fecha_Despacho, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel5.ResumeLayout(False)
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.Grupo_Especial_Venta_01.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents Btn_Grabar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents BtnSalir As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Chk_Revisar_Tasa_de_Cambio As DevComponents.DotNetBar.Controls.CheckBoxX
    Private WithEvents pageSlider1 As DevComponents.DotNetBar.Controls.PageSlider
    Private WithEvents SPage_Opciones_Generales As DevComponents.DotNetBar.Controls.PageSliderPage
    Private WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Private WithEvents Spage_SOC As DevComponents.DotNetBar.Controls.PageSliderPage
    Private WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Rdb_SOC_Aprueba_Solo_G1 As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_SOC_Aprueba_G1_y_G2 As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Cmb_SOC_Buscar_Producto As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Txt_SOC_Valor_1ra_Aprobacion As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX6 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Cmb_SOC_CodTurno As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents SPage_Venta As DevComponents.DotNetBar.Controls.PageSliderPage
    Private WithEvents LabelX7 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Txt_Dias_Venci_Coti As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Txt_Dias_Apela As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX8 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Cmb_TipoValor_Bruto_Neto As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents LabelX9 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX10 As DevComponents.DotNetBar.LabelX
    Public WithEvents Txt_Cliente As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Btn_Buscar_Cliente As DevComponents.DotNetBar.ButtonX
    Friend WithEvents LabelX11 As DevComponents.DotNetBar.LabelX
    Public WithEvents Txt_Producto_Comodin As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Btn_Buscar_producto As DevComponents.DotNetBar.ButtonX
    Friend WithEvents LabelX12 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Grupo_Especial_Venta_01 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Txt_Prod_Crea_Max_Carac_Nom As DevComponents.DotNetBar.Controls.MaskedTextBoxAdv
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Chk_Pr_Desc_Producto_Solo_Mayusculas As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Chk_SOC_Prod_Crea_Solo_Marcas_Proveedor As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents TableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents LabelX13 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Cmb_SOC_Tipo_Creacion_Producto_Normal_Matriz As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents Grupo_Codigo_Automatico As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Rdb_Pr_AutoPr_Correlativo_Por_Iniciales As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_Pr_AutoPr_Correlativo_General As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Chk_Pr_AutoPr_Crear_Codigo_Principal_Automatico As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents TableLayoutPanel4 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents LabelX14 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Cmb_Pr_AutoPr_Tablas_Para_Iniciales_Cod_Automatico As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents LabelX18 As DevComponents.DotNetBar.LabelX
    Private WithEvents Txt_Pr_AutoPr_Max_Cant_Caracteres_Del_Codigo As DevComponents.Editors.IntegerInput
    Friend WithEvents Chk_Pr_Creacion_Exigir_Codigo_Alternativo As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Chk_Pr_Creacion_Exigir_Clasificacion_busqueda As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Chk_Pr_Creacion_Exigir_Precio As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Chk_Preguntar_Documento As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Btn_Numeraciones_Documento As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Excluir_Documentos As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Chk_Revisar_Taza_Solo_Mon_Extranjeras As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Chk_Redondear_Dscto_Cero As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents LabelX15 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Cmb_Nodo_Raiz_Asociados As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents Lbl_Modalidad As DevComponents.DotNetBar.LabelX
    Friend WithEvents Chk_Vnta_Ofrecer_Otras_Bod_Stock_Insuficiente As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Chk_Preguntar_Si_Cambia_Responsable_Doc_Relacionado As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Chk_Conservar_Responzable_Doc_Relacionado As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents TableLayoutPanel5 As TableLayoutPanel
    Friend WithEvents Input_Dias_Max_Fecha_Despacho As DevComponents.Editors.IntegerInput
    Friend WithEvents Chk_Dias_Max_Fecha_Despacho_Dom As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Chk_Dias_Max_Fecha_Despacho_Sab As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents LabelX16 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Chk_Centro_Costo_Obligatorio_OCC As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Chk_Solicitar_Permiso_OCC_SOC As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_Crear_FCC_Desde_GRC_Vinculado_SII As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Chk_No_Solicitar_Permiso_Entidad_Preferencial As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Chk_Utilizar_NVV_En_Credito_X_Cliente As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Chk_No_Permitir_Grabar_Con_Dscto_Superado As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Chk_BloqEdiConcepRecargo As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Chk_BloqEdiConcepDescuento As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Chk_Pedir_Permiso_Para_Usar_Stanby As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Chk_Conservar_Bodega_Sig_Linea_Venta As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Chk_Grabar_Despachos_Con_Huella As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Lbl_Monto_CRV As DevComponents.DotNetBar.LabelX
    Friend WithEvents Input_Monto_Max_CRV_FacMasiva As DevComponents.Editors.IntegerInput
    Friend WithEvents Btn_DocConceptosVsPagos As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Chk_Usar_Validador_Prod_X_Compras As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Chk_Revisar_OCC_Pendientes_X_Productos As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Chk_Alerta_Costo_Lista_Distinto_Costo_Proveedor As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents chk_Pr_Creacion_Exigir_Dimensiones As DevComponents.DotNetBar.Controls.CheckBoxX
End Class
