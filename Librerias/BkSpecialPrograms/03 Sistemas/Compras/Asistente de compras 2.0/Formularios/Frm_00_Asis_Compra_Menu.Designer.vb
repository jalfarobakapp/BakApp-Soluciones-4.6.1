<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Frm_00_Asis_Compra_Menu
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_00_Asis_Compra_Menu))
        Me.Txt_Proveedor = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Bar = New DevComponents.DotNetBar.Bar()
        Me.Btn_GrabarConfiguracion = New DevComponents.DotNetBar.ButtonItem()
        Me.BtnProcesarInf = New DevComponents.DotNetBar.ButtonItem()
        Me.Chk_Procesar_Uno_A_Uno = New DevComponents.DotNetBar.CheckBoxItem()
        Me.Btn_Imprimir_Maestra = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Cancelar = New DevComponents.DotNetBar.ButtonItem()
        Me.Circular_Progress1 = New DevComponents.DotNetBar.CircularProgressItem()
        Me.ControlContainerItem1 = New DevComponents.DotNetBar.ControlContainerItem()
        Me.Dtp_Fecha_Vta_Desde_Estacional = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Dtp_Fecha_Estacional_Hasta = New System.Windows.Forms.DateTimePicker()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Cmb_Cantidad_Dias_Ultima_Venta = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.TableLayoutPanel6 = New System.Windows.Forms.TableLayoutPanel()
        Me.Rdb_Productos_Proveedor = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_Productos_Todos = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_Productos_Ranking = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_Productos_Familias_Marcas_Etc = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_Productos_Seleccionar = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_Productos_Con_Movimientos_De_Venta = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_Productos_Vendidos_Los_Ultimos_Dias = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Layout_Producto = New System.Windows.Forms.TableLayoutPanel()
        Me.Lbl_Desde = New DevComponents.DotNetBar.LabelX()
        Me.Lbl_Hasta = New DevComponents.DotNetBar.LabelX()
        Me.Dtp_Fecha_Movimientos_Hasta = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.Dtp_Fecha_Movimientos_Desde = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.Btn_Seleccionar_Productos_X_Clasificacion_RD = New DevComponents.DotNetBar.ButtonX()
        Me.BtnSeleccionarProductos = New DevComponents.DotNetBar.ButtonX()
        Me.Input_Productos_Ranking = New DevComponents.Editors.IntegerInput()
        Me.STabConfiguracion = New DevComponents.DotNetBar.SuperTabControl()
        Me.SuperTabControlPanel3 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.Line1 = New DevComponents.DotNetBar.Controls.Line()
        Me.Layaut_UlProdXProv = New System.Windows.Forms.TableLayoutPanel()
        Me.LabelX15 = New DevComponents.DotNetBar.LabelX()
        Me.Input_MesesCP = New DevComponents.Editors.IntegerInput()
        Me.LabelX16 = New DevComponents.DotNetBar.LabelX()
        Me.Input_UltDocumentosCP = New DevComponents.Editors.IntegerInput()
        Me.TableLayoutPanel8 = New System.Windows.Forms.TableLayoutPanel()
        Me.LabelX9 = New DevComponents.DotNetBar.LabelX()
        Me.Rdb_Ud1_Compra = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_Ud2_Compra = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.TableLayoutPanel5 = New System.Windows.Forms.TableLayoutPanel()
        Me.Cmb_Tiempo_Reposicion_Dias_Meses = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.Cmb_Metodo_Abastecer_Dias_Meses = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.LabelX7 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX6 = New DevComponents.DotNetBar.LabelX()
        Me.Chk_Sabado = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Chk_Domingo = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Input_Dias_a_Abastecer = New DevComponents.Editors.IntegerInput()
        Me.Input_Tiempo_Reposicion = New DevComponents.Editors.IntegerInput()
        Me.Chk_IncluirUltCXprov = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Tab_Indicadores = New DevComponents.DotNetBar.SuperTabItem()
        Me.SuperTabControlPanel8 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.SuperTabControl1 = New DevComponents.DotNetBar.SuperTabControl()
        Me.SuperTabControlPanel9 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.LabelX26 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_NombreFormato_PDF_OCC = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Txt_CorreoCc_OCC = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX22 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_CtaCorreoEnvioAutomatizado_OCC = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX21 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX23 = New DevComponents.DotNetBar.LabelX()
        Me.SubTabConfAuto_OCC = New DevComponents.DotNetBar.SuperTabItem()
        Me.SuperTabControlPanel10 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.GroupPanel2 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.LabelX24 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX25 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_NombreFormato_PDF_NVI = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Btn_Bodega_NVI_Estudio = New DevComponents.DotNetBar.ButtonX()
        Me.Txt_CorreoCc_NVI = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Txt_CtaCorreoEnvioAutomatizado_NVI = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX27 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX28 = New DevComponents.DotNetBar.LabelX()
        Me.SubTabConfAuto_NVI = New DevComponents.DotNetBar.SuperTabItem()
        Me.Tab_Automatizacion = New DevComponents.DotNetBar.SuperTabItem()
        Me.SuperTabControlPanel2 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.Chk_DbExt_SincronizarPRBD = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Grupo_DbExt = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Chk_SumerStockExternoAlFisico = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.LabelX17 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_DbExt_NombreBod_Des = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Txt_ProvEspecial = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX20 = New DevComponents.DotNetBar.LabelX()
        Me.Btn_Buscar_ProvEspecial = New DevComponents.DotNetBar.ButtonX()
        Me.Txt_DbExt_NombreBod_Ori = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Txt_DbExt_Nombre_Conexion = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX19 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX18 = New DevComponents.DotNetBar.LabelX()
        Me.Tab_ConexionExterna = New DevComponents.DotNetBar.SuperTabItem()
        Me.SuperTabControlPanel5 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.ReflectionImage1 = New DevComponents.DotNetBar.Controls.ReflectionImage()
        Me.Chk_Advertir_Rotacion = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.LabelX12 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX13 = New DevComponents.DotNetBar.LabelX()
        Me.Input_Dias_Advertencia_Rotacion = New DevComponents.Editors.IntegerInput()
        Me.SuperTabItem5 = New DevComponents.DotNetBar.SuperTabItem()
        Me.SuperTabControlPanel7 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.LabelX10 = New DevComponents.DotNetBar.LabelX()
        Me.Chk_Cargar_Rotacion_Estacional = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.SuperTabItem7 = New DevComponents.DotNetBar.SuperTabItem()
        Me.SuperTabControlPanel1 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.Dtp_Fecha_Vta_Desde = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.Input_Ultimos_Meses_Vta_Promedio = New DevComponents.Editors.IntegerInput()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.Btn_Bodegas_Stock = New DevComponents.DotNetBar.ButtonX()
        Me.LabelX14 = New DevComponents.DotNetBar.LabelX()
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel()
        Me.Rdb_Rot_Promedio = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_Rot_Mediana = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.Rdb_Rango_Fechas_Vta_Promedio = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_Rango_Meses_Vta_Promedio = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Chk_Incluir_Salidas_GDI_OT = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Chk_Rotacion_Con_Ent_Excluidas = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Chk_Sumar_Rotacion_Hermanos = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Dtp_Fecha_Vta_Hasta = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.Btn_Bodega_Vta_Estudio = New DevComponents.DotNetBar.ButtonX()
        Me.Tab_CalVnta = New DevComponents.DotNetBar.SuperTabItem()
        Me.SuperTabControlPanel4 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.Chk_Restar_Stock_TransitoGti = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Chk_Restar_Stock_PedidoOcc = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Chk_Restar_Stock_PedidoNvi = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Btn_Ent_Excluidas = New DevComponents.DotNetBar.ButtonX()
        Me.Chk_QuitarProdExcluidos = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Btn_ProductosExcluidos = New DevComponents.DotNetBar.ButtonX()
        Me.Chk_Mostrar_Solo_Stock_Critico = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Chk_No_Considera_Con_Stock_Pedido_OCC_NVI = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Chk_Sacar_Productos_Sin_Rotacion = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Chk_Restar_Stok_Bodega = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Chk_Quitar_Bloqueados_Compra = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Tab_Excluir_Incluir = New DevComponents.DotNetBar.SuperTabItem()
        Me.SuperTabControlPanel6 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.Input_FechaTopeBusquedaProveedores = New DevComponents.Editors.IntegerInput()
        Me.Dtp_Fecha_Tope_Proveedores_Automaticos = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.LabelX11 = New DevComponents.DotNetBar.LabelX()
        Me.Cmb_Documento_Compra = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.TableLayoutPanel7 = New System.Windows.Forms.TableLayoutPanel()
        Me.Rd_Costo_Lista_Proveedor = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rd_Costo_Ultimo_Documento_Seleccionado = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.LabelX8 = New DevComponents.DotNetBar.LabelX()
        Me.Cmb_Lista_de_costos = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.Tab_Costos_OCC = New DevComponents.DotNetBar.SuperTabItem()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.Rdb_RotMeses = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_RotDias = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Grupo_Productos = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Btn_Filtrar_ProdProveedor = New DevComponents.DotNetBar.ButtonX()
        Me.Chk_Solo_Proveedores_CodAlternativo = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Cmb_Tipo_de_compra = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX()
        Me.Btn_Buscar_Proveedor = New DevComponents.DotNetBar.ButtonX()
        Me.Chk_Traer_Productos_De_Reemplazo = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Chk_Ent_Fisica = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Chk_Incluir_Servicios = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.MetroStatusBar1 = New DevComponents.DotNetBar.Metro.MetroStatusBar()
        Me.Barra_Progreso = New DevComponents.DotNetBar.ProgressBarItem()
        Me.Lbl_Status = New DevComponents.DotNetBar.LabelItem()
        Me.Timer_Ejecucion_Automatica = New System.Windows.Forms.Timer(Me.components)
        Me.HelpProvider1 = New System.Windows.Forms.HelpProvider()
        Me.Chk_Sumar_Vta_Ult_Year = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.ButtonItem3 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem4 = New DevComponents.DotNetBar.ButtonItem()
        Me.BtnFiltroMarca = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem5 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem6 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem7 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem8 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem9 = New DevComponents.DotNetBar.ButtonItem()
        Me.Chk_NoEnviarCorreosAProveedores = New DevComponents.DotNetBar.Controls.CheckBoxX()
        CType(Me.Bar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel6.SuspendLayout()
        Me.Layout_Producto.SuspendLayout()
        CType(Me.Dtp_Fecha_Movimientos_Hasta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Dtp_Fecha_Movimientos_Desde, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Input_Productos_Ranking, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.STabConfiguracion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.STabConfiguracion.SuspendLayout()
        Me.SuperTabControlPanel3.SuspendLayout()
        Me.Layaut_UlProdXProv.SuspendLayout()
        CType(Me.Input_MesesCP, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Input_UltDocumentosCP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel8.SuspendLayout()
        Me.TableLayoutPanel5.SuspendLayout()
        CType(Me.Input_Dias_a_Abastecer, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Input_Tiempo_Reposicion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuperTabControlPanel8.SuspendLayout()
        CType(Me.SuperTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuperTabControl1.SuspendLayout()
        Me.SuperTabControlPanel9.SuspendLayout()
        Me.GroupPanel1.SuspendLayout()
        Me.SuperTabControlPanel10.SuspendLayout()
        Me.GroupPanel2.SuspendLayout()
        Me.SuperTabControlPanel2.SuspendLayout()
        Me.Grupo_DbExt.SuspendLayout()
        Me.SuperTabControlPanel5.SuspendLayout()
        CType(Me.Input_Dias_Advertencia_Rotacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuperTabControlPanel7.SuspendLayout()
        Me.SuperTabControlPanel1.SuspendLayout()
        CType(Me.Dtp_Fecha_Vta_Desde, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Input_Ultimos_Meses_Vta_Promedio, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel4.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.Dtp_Fecha_Vta_Hasta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuperTabControlPanel4.SuspendLayout()
        Me.SuperTabControlPanel6.SuspendLayout()
        CType(Me.Input_FechaTopeBusquedaProveedores, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Dtp_Fecha_Tope_Proveedores_Automaticos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel7.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.Grupo_Productos.SuspendLayout()
        Me.SuspendLayout()
        '
        'Txt_Proveedor
        '
        Me.Txt_Proveedor.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Proveedor.Border.Class = "TextBoxBorder"
        Me.Txt_Proveedor.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Proveedor.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Proveedor.ForeColor = System.Drawing.Color.Black
        Me.Txt_Proveedor.Location = New System.Drawing.Point(56, 220)
        Me.Txt_Proveedor.Name = "Txt_Proveedor"
        Me.Txt_Proveedor.PreventEnterBeep = True
        Me.Txt_Proveedor.ReadOnly = True
        Me.Txt_Proveedor.Size = New System.Drawing.Size(355, 22)
        Me.Txt_Proveedor.TabIndex = 10
        '
        'Bar
        '
        Me.Bar.AntiAlias = True
        Me.Bar.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_GrabarConfiguracion, Me.BtnProcesarInf, Me.Chk_Procesar_Uno_A_Uno, Me.Btn_Imprimir_Maestra, Me.Btn_Cancelar, Me.Circular_Progress1})
        Me.Bar.Location = New System.Drawing.Point(0, 580)
        Me.Bar.Name = "Bar"
        Me.Bar.Size = New System.Drawing.Size(564, 41)
        Me.Bar.Stretch = True
        Me.Bar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar.TabIndex = 13
        Me.Bar.TabStop = False
        Me.Bar.Text = "Bar1"
        '
        'Btn_GrabarConfiguracion
        '
        Me.Btn_GrabarConfiguracion.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_GrabarConfiguracion.FontBold = True
        Me.Btn_GrabarConfiguracion.ForeColor = System.Drawing.Color.Navy
        Me.Btn_GrabarConfiguracion.Image = CType(resources.GetObject("Btn_GrabarConfiguracion.Image"), System.Drawing.Image)
        Me.Btn_GrabarConfiguracion.ImageAlt = CType(resources.GetObject("Btn_GrabarConfiguracion.ImageAlt"), System.Drawing.Image)
        Me.Btn_GrabarConfiguracion.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.Btn_GrabarConfiguracion.Name = "Btn_GrabarConfiguracion"
        Me.Btn_GrabarConfiguracion.Tooltip = "Grabar configuración actual"
        '
        'BtnProcesarInf
        '
        Me.BtnProcesarInf.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnProcesarInf.ForeColor = System.Drawing.Color.Black
        Me.BtnProcesarInf.Image = CType(resources.GetObject("BtnProcesarInf.Image"), System.Drawing.Image)
        Me.BtnProcesarInf.ImageAlt = CType(resources.GetObject("BtnProcesarInf.ImageAlt"), System.Drawing.Image)
        Me.BtnProcesarInf.Name = "BtnProcesarInf"
        Me.BtnProcesarInf.Text = "Procesar informe"
        '
        'Chk_Procesar_Uno_A_Uno
        '
        Me.Chk_Procesar_Uno_A_Uno.CheckBoxImageChecked = CType(resources.GetObject("Chk_Procesar_Uno_A_Uno.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_Procesar_Uno_A_Uno.Checked = True
        Me.Chk_Procesar_Uno_A_Uno.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Chk_Procesar_Uno_A_Uno.Name = "Chk_Procesar_Uno_A_Uno"
        Me.Chk_Procesar_Uno_A_Uno.Text = "Procesar uno a uno"
        '
        'Btn_Imprimir_Maestra
        '
        Me.Btn_Imprimir_Maestra.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Imprimir_Maestra.ForeColor = System.Drawing.Color.Black
        Me.Btn_Imprimir_Maestra.Image = CType(resources.GetObject("Btn_Imprimir_Maestra.Image"), System.Drawing.Image)
        Me.Btn_Imprimir_Maestra.ImageAlt = CType(resources.GetObject("Btn_Imprimir_Maestra.ImageAlt"), System.Drawing.Image)
        Me.Btn_Imprimir_Maestra.Name = "Btn_Imprimir_Maestra"
        Me.Btn_Imprimir_Maestra.Tooltip = "Imprimir listado de productos"
        Me.Btn_Imprimir_Maestra.Visible = False
        '
        'Btn_Cancelar
        '
        Me.Btn_Cancelar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Cancelar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Cancelar.Image = CType(resources.GetObject("Btn_Cancelar.Image"), System.Drawing.Image)
        Me.Btn_Cancelar.ImageAlt = CType(resources.GetObject("Btn_Cancelar.ImageAlt"), System.Drawing.Image)
        Me.Btn_Cancelar.Name = "Btn_Cancelar"
        Me.Btn_Cancelar.Text = "Detener proceso"
        Me.Btn_Cancelar.Visible = False
        '
        'Circular_Progress1
        '
        Me.Circular_Progress1.Name = "Circular_Progress1"
        Me.Circular_Progress1.ProgressBarType = DevComponents.DotNetBar.eCircularProgressType.Dot
        Me.Circular_Progress1.Visible = False
        '
        'ControlContainerItem1
        '
        Me.ControlContainerItem1.AllowItemResize = False
        Me.ControlContainerItem1.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways
        Me.ControlContainerItem1.Name = "ControlContainerItem1"
        '
        'Dtp_Fecha_Vta_Desde_Estacional
        '
        Me.Dtp_Fecha_Vta_Desde_Estacional.BackColor = System.Drawing.Color.White
        Me.Dtp_Fecha_Vta_Desde_Estacional.ForeColor = System.Drawing.Color.Black
        Me.Dtp_Fecha_Vta_Desde_Estacional.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Dtp_Fecha_Vta_Desde_Estacional.Location = New System.Drawing.Point(52, 68)
        Me.Dtp_Fecha_Vta_Desde_Estacional.Name = "Dtp_Fecha_Vta_Desde_Estacional"
        Me.Dtp_Fecha_Vta_Desde_Estacional.Size = New System.Drawing.Size(102, 22)
        Me.Dtp_Fecha_Vta_Desde_Estacional.TabIndex = 0
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(160, 71)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(36, 13)
        Me.Label6.TabIndex = 3
        Me.Label6.Text = "Hasta"
        '
        'Dtp_Fecha_Estacional_Hasta
        '
        Me.Dtp_Fecha_Estacional_Hasta.BackColor = System.Drawing.Color.White
        Me.Dtp_Fecha_Estacional_Hasta.ForeColor = System.Drawing.Color.Black
        Me.Dtp_Fecha_Estacional_Hasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Dtp_Fecha_Estacional_Hasta.Location = New System.Drawing.Point(202, 68)
        Me.Dtp_Fecha_Estacional_Hasta.Name = "Dtp_Fecha_Estacional_Hasta"
        Me.Dtp_Fecha_Estacional_Hasta.Size = New System.Drawing.Size(105, 22)
        Me.Dtp_Fecha_Estacional_Hasta.TabIndex = 1
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(9, 71)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(39, 13)
        Me.Label7.TabIndex = 2
        Me.Label7.Text = "Desde"
        '
        'Cmb_Cantidad_Dias_Ultima_Venta
        '
        Me.Cmb_Cantidad_Dias_Ultima_Venta.DisplayMember = "Text"
        Me.Cmb_Cantidad_Dias_Ultima_Venta.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.Cmb_Cantidad_Dias_Ultima_Venta.ForeColor = System.Drawing.Color.Black
        Me.Cmb_Cantidad_Dias_Ultima_Venta.FormattingEnabled = True
        Me.Cmb_Cantidad_Dias_Ultima_Venta.ItemHeight = 16
        Me.Cmb_Cantidad_Dias_Ultima_Venta.Location = New System.Drawing.Point(54, 29)
        Me.Cmb_Cantidad_Dias_Ultima_Venta.Name = "Cmb_Cantidad_Dias_Ultima_Venta"
        Me.Cmb_Cantidad_Dias_Ultima_Venta.Size = New System.Drawing.Size(98, 22)
        Me.Cmb_Cantidad_Dias_Ultima_Venta.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Cmb_Cantidad_Dias_Ultima_Venta.TabIndex = 10
        '
        'TableLayoutPanel6
        '
        Me.TableLayoutPanel6.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel6.ColumnCount = 1
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel6.Controls.Add(Me.Rdb_Productos_Proveedor, 0, 6)
        Me.TableLayoutPanel6.Controls.Add(Me.Rdb_Productos_Todos, 0, 0)
        Me.TableLayoutPanel6.Controls.Add(Me.Rdb_Productos_Ranking, 0, 5)
        Me.TableLayoutPanel6.Controls.Add(Me.Rdb_Productos_Familias_Marcas_Etc, 0, 4)
        Me.TableLayoutPanel6.Controls.Add(Me.Rdb_Productos_Seleccionar, 0, 3)
        Me.TableLayoutPanel6.Controls.Add(Me.Rdb_Productos_Con_Movimientos_De_Venta, 0, 2)
        Me.TableLayoutPanel6.Controls.Add(Me.Rdb_Productos_Vendidos_Los_Ultimos_Dias, 0, 1)
        Me.TableLayoutPanel6.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel6.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel6.Name = "TableLayoutPanel6"
        Me.TableLayoutPanel6.RowCount = 7
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.TableLayoutPanel6.Size = New System.Drawing.Size(206, 183)
        Me.TableLayoutPanel6.TabIndex = 50
        '
        'Rdb_Productos_Proveedor
        '
        '
        '
        '
        Me.Rdb_Productos_Proveedor.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Productos_Proveedor.CheckBoxImageChecked = CType(resources.GetObject("Rdb_Productos_Proveedor.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Rdb_Productos_Proveedor.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Productos_Proveedor.FocusCuesEnabled = False
        Me.Rdb_Productos_Proveedor.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Productos_Proveedor.Location = New System.Drawing.Point(3, 159)
        Me.Rdb_Productos_Proveedor.Name = "Rdb_Productos_Proveedor"
        Me.Rdb_Productos_Proveedor.Size = New System.Drawing.Size(200, 21)
        Me.Rdb_Productos_Proveedor.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Productos_Proveedor.TabIndex = 59
        Me.Rdb_Productos_Proveedor.Text = "Comprados a un proveedor"
        '
        'Rdb_Productos_Todos
        '
        '
        '
        '
        Me.Rdb_Productos_Todos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Productos_Todos.CheckBoxImageChecked = CType(resources.GetObject("Rdb_Productos_Todos.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Rdb_Productos_Todos.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Productos_Todos.Checked = True
        Me.Rdb_Productos_Todos.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Rdb_Productos_Todos.CheckValue = "Y"
        Me.Rdb_Productos_Todos.FocusCuesEnabled = False
        Me.Rdb_Productos_Todos.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Productos_Todos.Location = New System.Drawing.Point(3, 3)
        Me.Rdb_Productos_Todos.Name = "Rdb_Productos_Todos"
        Me.Rdb_Productos_Todos.Size = New System.Drawing.Size(92, 20)
        Me.Rdb_Productos_Todos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Productos_Todos.TabIndex = 53
        Me.Rdb_Productos_Todos.Text = "Todos"
        '
        'Rdb_Productos_Ranking
        '
        '
        '
        '
        Me.Rdb_Productos_Ranking.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Productos_Ranking.CheckBoxImageChecked = CType(resources.GetObject("Rdb_Productos_Ranking.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Rdb_Productos_Ranking.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Productos_Ranking.FocusCuesEnabled = False
        Me.Rdb_Productos_Ranking.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Productos_Ranking.Location = New System.Drawing.Point(3, 133)
        Me.Rdb_Productos_Ranking.Name = "Rdb_Productos_Ranking"
        Me.Rdb_Productos_Ranking.Size = New System.Drawing.Size(200, 20)
        Me.Rdb_Productos_Ranking.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Productos_Ranking.TabIndex = 58
        Me.Rdb_Productos_Ranking.Text = "Los mejores del Ranking"
        '
        'Rdb_Productos_Familias_Marcas_Etc
        '
        '
        '
        '
        Me.Rdb_Productos_Familias_Marcas_Etc.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Productos_Familias_Marcas_Etc.CheckBoxImageChecked = CType(resources.GetObject("Rdb_Productos_Familias_Marcas_Etc.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Rdb_Productos_Familias_Marcas_Etc.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Productos_Familias_Marcas_Etc.FocusCuesEnabled = False
        Me.Rdb_Productos_Familias_Marcas_Etc.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Productos_Familias_Marcas_Etc.Location = New System.Drawing.Point(3, 107)
        Me.Rdb_Productos_Familias_Marcas_Etc.Name = "Rdb_Productos_Familias_Marcas_Etc"
        Me.Rdb_Productos_Familias_Marcas_Etc.Size = New System.Drawing.Size(200, 20)
        Me.Rdb_Productos_Familias_Marcas_Etc.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Productos_Familias_Marcas_Etc.TabIndex = 57
        Me.Rdb_Productos_Familias_Marcas_Etc.Text = "Seleccionar productos Familias, marcas, etc..."
        '
        'Rdb_Productos_Seleccionar
        '
        '
        '
        '
        Me.Rdb_Productos_Seleccionar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Productos_Seleccionar.CheckBoxImageChecked = CType(resources.GetObject("Rdb_Productos_Seleccionar.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Rdb_Productos_Seleccionar.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Productos_Seleccionar.FocusCuesEnabled = False
        Me.Rdb_Productos_Seleccionar.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Productos_Seleccionar.Location = New System.Drawing.Point(3, 81)
        Me.Rdb_Productos_Seleccionar.Name = "Rdb_Productos_Seleccionar"
        Me.Rdb_Productos_Seleccionar.Size = New System.Drawing.Size(167, 20)
        Me.Rdb_Productos_Seleccionar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Productos_Seleccionar.TabIndex = 56
        Me.Rdb_Productos_Seleccionar.Text = "Seleccionar productos"
        '
        'Rdb_Productos_Con_Movimientos_De_Venta
        '
        '
        '
        '
        Me.Rdb_Productos_Con_Movimientos_De_Venta.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Productos_Con_Movimientos_De_Venta.CheckBoxImageChecked = CType(resources.GetObject("Rdb_Productos_Con_Movimientos_De_Venta.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Rdb_Productos_Con_Movimientos_De_Venta.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Productos_Con_Movimientos_De_Venta.FocusCuesEnabled = False
        Me.Rdb_Productos_Con_Movimientos_De_Venta.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Productos_Con_Movimientos_De_Venta.Location = New System.Drawing.Point(3, 55)
        Me.Rdb_Productos_Con_Movimientos_De_Venta.Name = "Rdb_Productos_Con_Movimientos_De_Venta"
        Me.Rdb_Productos_Con_Movimientos_De_Venta.Size = New System.Drawing.Size(167, 20)
        Me.Rdb_Productos_Con_Movimientos_De_Venta.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Productos_Con_Movimientos_De_Venta.TabIndex = 55
        Me.Rdb_Productos_Con_Movimientos_De_Venta.Text = "Con movimientos de venta"
        '
        'Rdb_Productos_Vendidos_Los_Ultimos_Dias
        '
        '
        '
        '
        Me.Rdb_Productos_Vendidos_Los_Ultimos_Dias.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Productos_Vendidos_Los_Ultimos_Dias.CheckBoxImageChecked = CType(resources.GetObject("Rdb_Productos_Vendidos_Los_Ultimos_Dias.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Rdb_Productos_Vendidos_Los_Ultimos_Dias.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Productos_Vendidos_Los_Ultimos_Dias.FocusCuesEnabled = False
        Me.Rdb_Productos_Vendidos_Los_Ultimos_Dias.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Productos_Vendidos_Los_Ultimos_Dias.Location = New System.Drawing.Point(3, 29)
        Me.Rdb_Productos_Vendidos_Los_Ultimos_Dias.Name = "Rdb_Productos_Vendidos_Los_Ultimos_Dias"
        Me.Rdb_Productos_Vendidos_Los_Ultimos_Dias.Size = New System.Drawing.Size(167, 20)
        Me.Rdb_Productos_Vendidos_Los_Ultimos_Dias.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Productos_Vendidos_Los_Ultimos_Dias.TabIndex = 54
        Me.Rdb_Productos_Vendidos_Los_Ultimos_Dias.Text = "Vendidos los últimos"
        '
        'Layout_Producto
        '
        Me.Layout_Producto.BackColor = System.Drawing.Color.Transparent
        Me.Layout_Producto.ColumnCount = 4
        Me.Layout_Producto.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.77003!))
        Me.Layout_Producto.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 36.23693!))
        Me.Layout_Producto.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.24042!))
        Me.Layout_Producto.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32.75261!))
        Me.Layout_Producto.Controls.Add(Me.Lbl_Desde, 0, 2)
        Me.Layout_Producto.Controls.Add(Me.Lbl_Hasta, 2, 2)
        Me.Layout_Producto.Controls.Add(Me.Dtp_Fecha_Movimientos_Hasta, 3, 2)
        Me.Layout_Producto.Controls.Add(Me.Dtp_Fecha_Movimientos_Desde, 1, 2)
        Me.Layout_Producto.Controls.Add(Me.Btn_Seleccionar_Productos_X_Clasificacion_RD, 1, 4)
        Me.Layout_Producto.Controls.Add(Me.BtnSeleccionarProductos, 1, 3)
        Me.Layout_Producto.Controls.Add(Me.Cmb_Cantidad_Dias_Ultima_Venta, 1, 1)
        Me.Layout_Producto.Controls.Add(Me.Input_Productos_Ranking, 1, 5)
        Me.Layout_Producto.ForeColor = System.Drawing.Color.Black
        Me.Layout_Producto.Location = New System.Drawing.Point(215, 3)
        Me.Layout_Producto.Name = "Layout_Producto"
        Me.Layout_Producto.RowCount = 7
        Me.Layout_Producto.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.Layout_Producto.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.Layout_Producto.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.Layout_Producto.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.Layout_Producto.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.Layout_Producto.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.Layout_Producto.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.Layout_Producto.Size = New System.Drawing.Size(289, 183)
        Me.Layout_Producto.TabIndex = 29
        '
        'Lbl_Desde
        '
        '
        '
        '
        Me.Lbl_Desde.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Desde.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Desde.Location = New System.Drawing.Point(3, 55)
        Me.Lbl_Desde.Name = "Lbl_Desde"
        Me.Lbl_Desde.Size = New System.Drawing.Size(45, 18)
        Me.Lbl_Desde.TabIndex = 115
        Me.Lbl_Desde.Text = "Desde"
        Me.Lbl_Desde.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'Lbl_Hasta
        '
        '
        '
        '
        Me.Lbl_Hasta.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Hasta.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Hasta.Location = New System.Drawing.Point(158, 55)
        Me.Lbl_Hasta.Name = "Lbl_Hasta"
        Me.Lbl_Hasta.Size = New System.Drawing.Size(32, 18)
        Me.Lbl_Hasta.TabIndex = 116
        Me.Lbl_Hasta.Text = "Hasta"
        Me.Lbl_Hasta.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'Dtp_Fecha_Movimientos_Hasta
        '
        '
        '
        '
        Me.Dtp_Fecha_Movimientos_Hasta.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Dtp_Fecha_Movimientos_Hasta.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Movimientos_Hasta.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.Dtp_Fecha_Movimientos_Hasta.ButtonDropDown.Visible = True
        Me.Dtp_Fecha_Movimientos_Hasta.ForeColor = System.Drawing.Color.Black
        Me.Dtp_Fecha_Movimientos_Hasta.IsPopupCalendarOpen = False
        Me.Dtp_Fecha_Movimientos_Hasta.Location = New System.Drawing.Point(196, 55)
        '
        '
        '
        Me.Dtp_Fecha_Movimientos_Hasta.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_Fecha_Movimientos_Hasta.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Movimientos_Hasta.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.Dtp_Fecha_Movimientos_Hasta.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.Dtp_Fecha_Movimientos_Hasta.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.Dtp_Fecha_Movimientos_Hasta.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_Fecha_Movimientos_Hasta.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.Dtp_Fecha_Movimientos_Hasta.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Dtp_Fecha_Movimientos_Hasta.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.Dtp_Fecha_Movimientos_Hasta.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.Dtp_Fecha_Movimientos_Hasta.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Movimientos_Hasta.MonthCalendar.DisplayMonth = New Date(2018, 10, 1, 0, 0, 0, 0)
        Me.Dtp_Fecha_Movimientos_Hasta.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday
        Me.Dtp_Fecha_Movimientos_Hasta.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.Dtp_Fecha_Movimientos_Hasta.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_Fecha_Movimientos_Hasta.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Dtp_Fecha_Movimientos_Hasta.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_Fecha_Movimientos_Hasta.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Dtp_Fecha_Movimientos_Hasta.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Movimientos_Hasta.MonthCalendar.TodayButtonVisible = True
        Me.Dtp_Fecha_Movimientos_Hasta.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.Dtp_Fecha_Movimientos_Hasta.Name = "Dtp_Fecha_Movimientos_Hasta"
        Me.Dtp_Fecha_Movimientos_Hasta.Size = New System.Drawing.Size(90, 22)
        Me.Dtp_Fecha_Movimientos_Hasta.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Dtp_Fecha_Movimientos_Hasta.TabIndex = 66
        Me.Dtp_Fecha_Movimientos_Hasta.Value = New Date(2018, 10, 19, 11, 12, 43, 0)
        '
        'Dtp_Fecha_Movimientos_Desde
        '
        '
        '
        '
        Me.Dtp_Fecha_Movimientos_Desde.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Dtp_Fecha_Movimientos_Desde.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Movimientos_Desde.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.Dtp_Fecha_Movimientos_Desde.ButtonDropDown.Visible = True
        Me.Dtp_Fecha_Movimientos_Desde.ForeColor = System.Drawing.Color.Black
        Me.Dtp_Fecha_Movimientos_Desde.IsPopupCalendarOpen = False
        Me.Dtp_Fecha_Movimientos_Desde.Location = New System.Drawing.Point(54, 55)
        '
        '
        '
        Me.Dtp_Fecha_Movimientos_Desde.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_Fecha_Movimientos_Desde.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Movimientos_Desde.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.Dtp_Fecha_Movimientos_Desde.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.Dtp_Fecha_Movimientos_Desde.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.Dtp_Fecha_Movimientos_Desde.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_Fecha_Movimientos_Desde.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.Dtp_Fecha_Movimientos_Desde.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Dtp_Fecha_Movimientos_Desde.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.Dtp_Fecha_Movimientos_Desde.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.Dtp_Fecha_Movimientos_Desde.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Movimientos_Desde.MonthCalendar.DisplayMonth = New Date(2018, 10, 1, 0, 0, 0, 0)
        Me.Dtp_Fecha_Movimientos_Desde.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday
        Me.Dtp_Fecha_Movimientos_Desde.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.Dtp_Fecha_Movimientos_Desde.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_Fecha_Movimientos_Desde.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Dtp_Fecha_Movimientos_Desde.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_Fecha_Movimientos_Desde.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Dtp_Fecha_Movimientos_Desde.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Movimientos_Desde.MonthCalendar.TodayButtonVisible = True
        Me.Dtp_Fecha_Movimientos_Desde.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.Dtp_Fecha_Movimientos_Desde.Name = "Dtp_Fecha_Movimientos_Desde"
        Me.Dtp_Fecha_Movimientos_Desde.Size = New System.Drawing.Size(98, 22)
        Me.Dtp_Fecha_Movimientos_Desde.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Dtp_Fecha_Movimientos_Desde.TabIndex = 65
        Me.Dtp_Fecha_Movimientos_Desde.Value = New Date(2018, 10, 19, 11, 12, 43, 0)
        '
        'Btn_Seleccionar_Productos_X_Clasificacion_RD
        '
        Me.Btn_Seleccionar_Productos_X_Clasificacion_RD.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Seleccionar_Productos_X_Clasificacion_RD.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Seleccionar_Productos_X_Clasificacion_RD.FocusCuesEnabled = False
        Me.Btn_Seleccionar_Productos_X_Clasificacion_RD.Image = CType(resources.GetObject("Btn_Seleccionar_Productos_X_Clasificacion_RD.Image"), System.Drawing.Image)
        Me.Btn_Seleccionar_Productos_X_Clasificacion_RD.Location = New System.Drawing.Point(54, 107)
        Me.Btn_Seleccionar_Productos_X_Clasificacion_RD.Name = "Btn_Seleccionar_Productos_X_Clasificacion_RD"
        Me.Btn_Seleccionar_Productos_X_Clasificacion_RD.Size = New System.Drawing.Size(98, 20)
        Me.Btn_Seleccionar_Productos_X_Clasificacion_RD.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Seleccionar_Productos_X_Clasificacion_RD.TabIndex = 52
        Me.Btn_Seleccionar_Productos_X_Clasificacion_RD.Text = "Familias, etc..."
        Me.Btn_Seleccionar_Productos_X_Clasificacion_RD.Tooltip = "Buscar productos"
        '
        'BtnSeleccionarProductos
        '
        Me.BtnSeleccionarProductos.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BtnSeleccionarProductos.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.BtnSeleccionarProductos.FocusCuesEnabled = False
        Me.BtnSeleccionarProductos.Image = CType(resources.GetObject("BtnSeleccionarProductos.Image"), System.Drawing.Image)
        Me.BtnSeleccionarProductos.ImageAlt = CType(resources.GetObject("BtnSeleccionarProductos.ImageAlt"), System.Drawing.Image)
        Me.BtnSeleccionarProductos.Location = New System.Drawing.Point(54, 81)
        Me.BtnSeleccionarProductos.Name = "BtnSeleccionarProductos"
        Me.BtnSeleccionarProductos.Size = New System.Drawing.Size(98, 20)
        Me.BtnSeleccionarProductos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.BtnSeleccionarProductos.TabIndex = 13
        Me.BtnSeleccionarProductos.Text = "Buscar prod."
        Me.BtnSeleccionarProductos.Tooltip = "Buscar productos"
        '
        'Input_Productos_Ranking
        '
        Me.Input_Productos_Ranking.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Input_Productos_Ranking.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Input_Productos_Ranking.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Input_Productos_Ranking.ButtonClear.Visible = True
        Me.Input_Productos_Ranking.FocusHighlightEnabled = True
        Me.Input_Productos_Ranking.ForeColor = System.Drawing.Color.Black
        Me.Input_Productos_Ranking.Location = New System.Drawing.Point(54, 133)
        Me.Input_Productos_Ranking.Name = "Input_Productos_Ranking"
        Me.Input_Productos_Ranking.ShowUpDown = True
        Me.Input_Productos_Ranking.Size = New System.Drawing.Size(98, 22)
        Me.Input_Productos_Ranking.TabIndex = 102
        Me.Input_Productos_Ranking.Value = 100
        '
        'STabConfiguracion
        '
        Me.STabConfiguracion.BackColor = System.Drawing.Color.White
        '
        '
        '
        '
        '
        '
        Me.STabConfiguracion.ControlBox.CloseBox.Name = ""
        '
        '
        '
        Me.STabConfiguracion.ControlBox.MenuBox.Name = ""
        Me.STabConfiguracion.ControlBox.Name = ""
        Me.STabConfiguracion.ControlBox.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.STabConfiguracion.ControlBox.MenuBox, Me.STabConfiguracion.ControlBox.CloseBox})
        Me.STabConfiguracion.Controls.Add(Me.SuperTabControlPanel3)
        Me.STabConfiguracion.Controls.Add(Me.SuperTabControlPanel8)
        Me.STabConfiguracion.Controls.Add(Me.SuperTabControlPanel2)
        Me.STabConfiguracion.Controls.Add(Me.SuperTabControlPanel5)
        Me.STabConfiguracion.Controls.Add(Me.SuperTabControlPanel7)
        Me.STabConfiguracion.Controls.Add(Me.SuperTabControlPanel1)
        Me.STabConfiguracion.Controls.Add(Me.SuperTabControlPanel4)
        Me.STabConfiguracion.Controls.Add(Me.SuperTabControlPanel6)
        Me.STabConfiguracion.ForeColor = System.Drawing.Color.Black
        Me.STabConfiguracion.Location = New System.Drawing.Point(14, 322)
        Me.STabConfiguracion.Name = "STabConfiguracion"
        Me.STabConfiguracion.ReorderTabsEnabled = True
        Me.STabConfiguracion.SelectedTabFont = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold)
        Me.STabConfiguracion.SelectedTabIndex = 0
        Me.STabConfiguracion.Size = New System.Drawing.Size(539, 232)
        Me.STabConfiguracion.TabFont = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.STabConfiguracion.TabIndex = 49
        Me.STabConfiguracion.Tabs.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Tab_Indicadores, Me.Tab_Costos_OCC, Me.Tab_Excluir_Incluir, Me.Tab_CalVnta, Me.SuperTabItem7, Me.SuperTabItem5, Me.Tab_ConexionExterna, Me.Tab_Automatizacion})
        Me.STabConfiguracion.Text = "SuperTabControl2"
        '
        'SuperTabControlPanel3
        '
        Me.SuperTabControlPanel3.CanvasColor = System.Drawing.Color.Empty
        Me.SuperTabControlPanel3.Controls.Add(Me.Line1)
        Me.SuperTabControlPanel3.Controls.Add(Me.Layaut_UlProdXProv)
        Me.SuperTabControlPanel3.Controls.Add(Me.TableLayoutPanel8)
        Me.SuperTabControlPanel3.Controls.Add(Me.TableLayoutPanel5)
        Me.SuperTabControlPanel3.Controls.Add(Me.Chk_IncluirUltCXprov)
        Me.SuperTabControlPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel3.Location = New System.Drawing.Point(0, 27)
        Me.SuperTabControlPanel3.Name = "SuperTabControlPanel3"
        Me.SuperTabControlPanel3.Size = New System.Drawing.Size(539, 205)
        Me.SuperTabControlPanel3.TabIndex = 1
        Me.SuperTabControlPanel3.TabItem = Me.Tab_Indicadores
        '
        'Line1
        '
        Me.Line1.BackColor = System.Drawing.Color.Transparent
        Me.Line1.ForeColor = System.Drawing.Color.Black
        Me.Line1.Location = New System.Drawing.Point(13, 107)
        Me.Line1.Name = "Line1"
        Me.Line1.Size = New System.Drawing.Size(490, 8)
        Me.Line1.TabIndex = 55
        Me.Line1.Text = "Line1"
        '
        'Layaut_UlProdXProv
        '
        Me.Layaut_UlProdXProv.BackColor = System.Drawing.Color.Transparent
        Me.Layaut_UlProdXProv.ColumnCount = 2
        Me.Layaut_UlProdXProv.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.68159!))
        Me.Layaut_UlProdXProv.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 86.31841!))
        Me.Layaut_UlProdXProv.Controls.Add(Me.LabelX15, 1, 1)
        Me.Layaut_UlProdXProv.Controls.Add(Me.Input_MesesCP, 0, 0)
        Me.Layaut_UlProdXProv.Controls.Add(Me.LabelX16, 1, 0)
        Me.Layaut_UlProdXProv.Controls.Add(Me.Input_UltDocumentosCP, 0, 1)
        Me.Layaut_UlProdXProv.ForeColor = System.Drawing.Color.Black
        Me.Layaut_UlProdXProv.Location = New System.Drawing.Point(12, 134)
        Me.Layaut_UlProdXProv.Name = "Layaut_UlProdXProv"
        Me.Layaut_UlProdXProv.RowCount = 2
        Me.Layaut_UlProdXProv.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.Layaut_UlProdXProv.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.Layaut_UlProdXProv.Size = New System.Drawing.Size(423, 59)
        Me.Layaut_UlProdXProv.TabIndex = 54
        '
        'LabelX15
        '
        Me.LabelX15.AutoSize = True
        '
        '
        '
        Me.LabelX15.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX15.ForeColor = System.Drawing.Color.Black
        Me.LabelX15.Location = New System.Drawing.Point(60, 32)
        Me.LabelX15.Name = "LabelX15"
        Me.LabelX15.Size = New System.Drawing.Size(293, 17)
        Me.LabelX15.TabIndex = 50
        Me.LabelX15.Text = "Ultimos pedidos  a estudiar por cumplimiento de proveedor"
        '
        'Input_MesesCP
        '
        Me.Input_MesesCP.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Input_MesesCP.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Input_MesesCP.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Input_MesesCP.FocusHighlightEnabled = True
        Me.Input_MesesCP.ForeColor = System.Drawing.Color.Black
        Me.Input_MesesCP.Location = New System.Drawing.Point(3, 3)
        Me.Input_MesesCP.MaxValue = 12
        Me.Input_MesesCP.MinValue = 3
        Me.Input_MesesCP.Name = "Input_MesesCP"
        Me.Input_MesesCP.ShowUpDown = True
        Me.Input_MesesCP.Size = New System.Drawing.Size(51, 22)
        Me.Input_MesesCP.TabIndex = 104
        Me.Input_MesesCP.Value = 3
        '
        'LabelX16
        '
        Me.LabelX16.AutoSize = True
        '
        '
        '
        Me.LabelX16.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX16.ForeColor = System.Drawing.Color.Black
        Me.LabelX16.Location = New System.Drawing.Point(60, 3)
        Me.LabelX16.Name = "LabelX16"
        Me.LabelX16.Size = New System.Drawing.Size(345, 17)
        Me.LabelX16.TabIndex = 27
        Me.LabelX16.Text = "Ultimas ordenes de compra a estudiar por cumplimiento de proveedor"
        '
        'Input_UltDocumentosCP
        '
        Me.Input_UltDocumentosCP.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Input_UltDocumentosCP.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Input_UltDocumentosCP.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Input_UltDocumentosCP.FocusHighlightEnabled = True
        Me.Input_UltDocumentosCP.ForeColor = System.Drawing.Color.Black
        Me.Input_UltDocumentosCP.Location = New System.Drawing.Point(3, 32)
        Me.Input_UltDocumentosCP.MaxValue = 6
        Me.Input_UltDocumentosCP.MinValue = 3
        Me.Input_UltDocumentosCP.Name = "Input_UltDocumentosCP"
        Me.Input_UltDocumentosCP.ShowUpDown = True
        Me.Input_UltDocumentosCP.Size = New System.Drawing.Size(51, 22)
        Me.Input_UltDocumentosCP.TabIndex = 103
        Me.Input_UltDocumentosCP.Value = 3
        '
        'TableLayoutPanel8
        '
        Me.TableLayoutPanel8.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel8.ColumnCount = 3
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34.61538!))
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65.38461!))
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 204.0!))
        Me.TableLayoutPanel8.Controls.Add(Me.LabelX9, 0, 0)
        Me.TableLayoutPanel8.Controls.Add(Me.Rdb_Ud1_Compra, 1, 0)
        Me.TableLayoutPanel8.Controls.Add(Me.Rdb_Ud2_Compra, 2, 0)
        Me.TableLayoutPanel8.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel8.Location = New System.Drawing.Point(12, 71)
        Me.TableLayoutPanel8.Name = "TableLayoutPanel8"
        Me.TableLayoutPanel8.RowCount = 1
        Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel8.Size = New System.Drawing.Size(405, 26)
        Me.TableLayoutPanel8.TabIndex = 53
        '
        'LabelX9
        '
        Me.LabelX9.AutoSize = True
        '
        '
        '
        Me.LabelX9.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX9.ForeColor = System.Drawing.Color.Black
        Me.LabelX9.Location = New System.Drawing.Point(3, 3)
        Me.LabelX9.Name = "LabelX9"
        Me.LabelX9.Size = New System.Drawing.Size(64, 17)
        Me.LabelX9.TabIndex = 52
        Me.LabelX9.Text = "Ud. compra :"
        '
        'Rdb_Ud1_Compra
        '
        '
        '
        '
        Me.Rdb_Ud1_Compra.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Ud1_Compra.CheckBoxImageChecked = CType(resources.GetObject("Rdb_Ud1_Compra.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Rdb_Ud1_Compra.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Ud1_Compra.Checked = True
        Me.Rdb_Ud1_Compra.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Rdb_Ud1_Compra.CheckValue = "Y"
        Me.Rdb_Ud1_Compra.FocusCuesEnabled = False
        Me.Rdb_Ud1_Compra.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Ud1_Compra.Location = New System.Drawing.Point(72, 3)
        Me.Rdb_Ud1_Compra.Name = "Rdb_Ud1_Compra"
        Me.Rdb_Ud1_Compra.Size = New System.Drawing.Size(125, 20)
        Me.Rdb_Ud1_Compra.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Ud1_Compra.TabIndex = 57
        Me.Rdb_Ud1_Compra.Text = "[Ud. 1] Primera Unidad "
        '
        'Rdb_Ud2_Compra
        '
        '
        '
        '
        Me.Rdb_Ud2_Compra.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Ud2_Compra.CheckBoxImageChecked = CType(resources.GetObject("Rdb_Ud2_Compra.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Rdb_Ud2_Compra.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Ud2_Compra.FocusCuesEnabled = False
        Me.Rdb_Ud2_Compra.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Ud2_Compra.Location = New System.Drawing.Point(203, 3)
        Me.Rdb_Ud2_Compra.Name = "Rdb_Ud2_Compra"
        Me.Rdb_Ud2_Compra.Size = New System.Drawing.Size(143, 20)
        Me.Rdb_Ud2_Compra.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Ud2_Compra.TabIndex = 58
        Me.Rdb_Ud2_Compra.Text = "[Ud. 2] Segunda Unidad"
        '
        'TableLayoutPanel5
        '
        Me.TableLayoutPanel5.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel5.ColumnCount = 4
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 63.0!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 37.0!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 81.0!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 176.0!))
        Me.TableLayoutPanel5.Controls.Add(Me.Cmb_Tiempo_Reposicion_Dias_Meses, 1, 1)
        Me.TableLayoutPanel5.Controls.Add(Me.Cmb_Metodo_Abastecer_Dias_Meses, 1, 0)
        Me.TableLayoutPanel5.Controls.Add(Me.LabelX7, 0, 1)
        Me.TableLayoutPanel5.Controls.Add(Me.LabelX6, 0, 0)
        Me.TableLayoutPanel5.Controls.Add(Me.Chk_Sabado, 3, 0)
        Me.TableLayoutPanel5.Controls.Add(Me.Chk_Domingo, 3, 1)
        Me.TableLayoutPanel5.Controls.Add(Me.Input_Dias_a_Abastecer, 2, 0)
        Me.TableLayoutPanel5.Controls.Add(Me.Input_Tiempo_Reposicion, 2, 1)
        Me.TableLayoutPanel5.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel5.Location = New System.Drawing.Point(12, 11)
        Me.TableLayoutPanel5.Name = "TableLayoutPanel5"
        Me.TableLayoutPanel5.RowCount = 2
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel5.Size = New System.Drawing.Size(457, 52)
        Me.TableLayoutPanel5.TabIndex = 27
        '
        'Cmb_Tiempo_Reposicion_Dias_Meses
        '
        Me.Cmb_Tiempo_Reposicion_Dias_Meses.DisplayMember = "Text"
        Me.Cmb_Tiempo_Reposicion_Dias_Meses.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.Cmb_Tiempo_Reposicion_Dias_Meses.ForeColor = System.Drawing.Color.Black
        Me.Cmb_Tiempo_Reposicion_Dias_Meses.FormattingEnabled = True
        Me.Cmb_Tiempo_Reposicion_Dias_Meses.ItemHeight = 16
        Me.Cmb_Tiempo_Reposicion_Dias_Meses.Location = New System.Drawing.Point(129, 29)
        Me.Cmb_Tiempo_Reposicion_Dias_Meses.Name = "Cmb_Tiempo_Reposicion_Dias_Meses"
        Me.Cmb_Tiempo_Reposicion_Dias_Meses.Size = New System.Drawing.Size(68, 22)
        Me.Cmb_Tiempo_Reposicion_Dias_Meses.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Cmb_Tiempo_Reposicion_Dias_Meses.TabIndex = 52
        '
        'Cmb_Metodo_Abastecer_Dias_Meses
        '
        Me.Cmb_Metodo_Abastecer_Dias_Meses.DisplayMember = "Text"
        Me.Cmb_Metodo_Abastecer_Dias_Meses.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.Cmb_Metodo_Abastecer_Dias_Meses.ForeColor = System.Drawing.Color.Black
        Me.Cmb_Metodo_Abastecer_Dias_Meses.FormattingEnabled = True
        Me.HelpProvider1.SetHelpString(Me.Cmb_Metodo_Abastecer_Dias_Meses, "")
        Me.Cmb_Metodo_Abastecer_Dias_Meses.ItemHeight = 16
        Me.Cmb_Metodo_Abastecer_Dias_Meses.Location = New System.Drawing.Point(129, 3)
        Me.Cmb_Metodo_Abastecer_Dias_Meses.Name = "Cmb_Metodo_Abastecer_Dias_Meses"
        Me.HelpProvider1.SetShowHelp(Me.Cmb_Metodo_Abastecer_Dias_Meses, True)
        Me.Cmb_Metodo_Abastecer_Dias_Meses.Size = New System.Drawing.Size(68, 22)
        Me.Cmb_Metodo_Abastecer_Dias_Meses.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Cmb_Metodo_Abastecer_Dias_Meses.TabIndex = 51
        '
        'LabelX7
        '
        Me.LabelX7.AutoSize = True
        '
        '
        '
        Me.LabelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX7.ForeColor = System.Drawing.Color.Black
        Me.LabelX7.Location = New System.Drawing.Point(3, 29)
        Me.LabelX7.Name = "LabelX7"
        Me.LabelX7.Size = New System.Drawing.Size(95, 17)
        Me.LabelX7.TabIndex = 50
        Me.LabelX7.Text = "Tiempo Reposición"
        '
        'LabelX6
        '
        Me.LabelX6.AutoSize = True
        '
        '
        '
        Me.LabelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX6.ForeColor = System.Drawing.Color.Black
        Me.LabelX6.Location = New System.Drawing.Point(3, 3)
        Me.LabelX6.Name = "LabelX6"
        Me.LabelX6.Size = New System.Drawing.Size(119, 17)
        Me.LabelX6.TabIndex = 27
        Me.LabelX6.Text = "Comprar para abastecer"
        '
        'Chk_Sabado
        '
        Me.Chk_Sabado.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_Sabado.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Sabado.CheckBoxImageChecked = CType(resources.GetObject("Chk_Sabado.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_Sabado.FocusCuesEnabled = False
        Me.Chk_Sabado.ForeColor = System.Drawing.Color.Black
        Me.HelpProvider1.SetHelpString(Me.Chk_Sabado, "Considera los días sábados como días hábiles")
        Me.Chk_Sabado.Location = New System.Drawing.Point(284, 3)
        Me.Chk_Sabado.Name = "Chk_Sabado"
        Me.HelpProvider1.SetShowHelp(Me.Chk_Sabado, True)
        Me.Chk_Sabado.Size = New System.Drawing.Size(138, 20)
        Me.Chk_Sabado.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Sabado.TabIndex = 21
        Me.Chk_Sabado.Text = "Considerar día Sábado"
        '
        'Chk_Domingo
        '
        Me.Chk_Domingo.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_Domingo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Domingo.CheckBoxImageChecked = CType(resources.GetObject("Chk_Domingo.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_Domingo.FocusCuesEnabled = False
        Me.Chk_Domingo.ForeColor = System.Drawing.Color.Black
        Me.HelpProvider1.SetHelpString(Me.Chk_Domingo, "Considera los días domingos como días hábiles")
        Me.Chk_Domingo.Location = New System.Drawing.Point(284, 29)
        Me.Chk_Domingo.Name = "Chk_Domingo"
        Me.HelpProvider1.SetShowHelp(Me.Chk_Domingo, True)
        Me.Chk_Domingo.Size = New System.Drawing.Size(139, 20)
        Me.Chk_Domingo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Domingo.TabIndex = 22
        Me.Chk_Domingo.Text = "Considerar día Domingo"
        '
        'Input_Dias_a_Abastecer
        '
        Me.Input_Dias_a_Abastecer.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Input_Dias_a_Abastecer.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Input_Dias_a_Abastecer.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Input_Dias_a_Abastecer.ButtonClear.Visible = True
        Me.Input_Dias_a_Abastecer.FocusHighlightEnabled = True
        Me.Input_Dias_a_Abastecer.ForeColor = System.Drawing.Color.Black
        Me.HelpProvider1.SetHelpString(Me.Input_Dias_a_Abastecer, resources.GetString("Input_Dias_a_Abastecer.HelpString"))
        Me.Input_Dias_a_Abastecer.Location = New System.Drawing.Point(203, 3)
        Me.Input_Dias_a_Abastecer.MaxValue = 2000
        Me.Input_Dias_a_Abastecer.MinValue = 1
        Me.Input_Dias_a_Abastecer.Name = "Input_Dias_a_Abastecer"
        Me.HelpProvider1.SetShowHelp(Me.Input_Dias_a_Abastecer, True)
        Me.Input_Dias_a_Abastecer.ShowUpDown = True
        Me.Input_Dias_a_Abastecer.Size = New System.Drawing.Size(69, 22)
        Me.Input_Dias_a_Abastecer.TabIndex = 104
        Me.Input_Dias_a_Abastecer.Value = 100
        '
        'Input_Tiempo_Reposicion
        '
        Me.Input_Tiempo_Reposicion.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Input_Tiempo_Reposicion.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Input_Tiempo_Reposicion.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Input_Tiempo_Reposicion.ButtonClear.Visible = True
        Me.Input_Tiempo_Reposicion.FocusHighlightEnabled = True
        Me.Input_Tiempo_Reposicion.ForeColor = System.Drawing.Color.Black
        Me.Input_Tiempo_Reposicion.Location = New System.Drawing.Point(203, 29)
        Me.Input_Tiempo_Reposicion.MaxValue = 365
        Me.Input_Tiempo_Reposicion.MinValue = 0
        Me.Input_Tiempo_Reposicion.Name = "Input_Tiempo_Reposicion"
        Me.Input_Tiempo_Reposicion.ShowUpDown = True
        Me.Input_Tiempo_Reposicion.Size = New System.Drawing.Size(69, 22)
        Me.Input_Tiempo_Reposicion.TabIndex = 103
        Me.Input_Tiempo_Reposicion.Value = 7
        '
        'Chk_IncluirUltCXprov
        '
        Me.Chk_IncluirUltCXprov.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_IncluirUltCXprov.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_IncluirUltCXprov.CheckBoxImageChecked = CType(resources.GetObject("Chk_IncluirUltCXprov.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_IncluirUltCXprov.FocusCuesEnabled = False
        Me.Chk_IncluirUltCXprov.ForeColor = System.Drawing.Color.Black
        Me.Chk_IncluirUltCXprov.Location = New System.Drawing.Point(15, 114)
        Me.Chk_IncluirUltCXprov.Name = "Chk_IncluirUltCXprov"
        Me.Chk_IncluirUltCXprov.Size = New System.Drawing.Size(332, 17)
        Me.Chk_IncluirUltCXprov.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_IncluirUltCXprov.TabIndex = 21
        Me.Chk_IncluirUltCXprov.Text = "Incluir % de cumplimiento de compras por proveedor"
        '
        'Tab_Indicadores
        '
        Me.Tab_Indicadores.AttachedControl = Me.SuperTabControlPanel3
        Me.Tab_Indicadores.GlobalItem = False
        Me.Tab_Indicadores.Name = "Tab_Indicadores"
        Me.Tab_Indicadores.Text = "Indicadores"
        '
        'SuperTabControlPanel8
        '
        Me.SuperTabControlPanel8.Controls.Add(Me.SuperTabControl1)
        Me.SuperTabControlPanel8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel8.Location = New System.Drawing.Point(0, 27)
        Me.SuperTabControlPanel8.Name = "SuperTabControlPanel8"
        Me.SuperTabControlPanel8.Size = New System.Drawing.Size(539, 205)
        Me.SuperTabControlPanel8.TabIndex = 0
        Me.SuperTabControlPanel8.TabItem = Me.Tab_Automatizacion
        '
        'SuperTabControl1
        '
        Me.SuperTabControl1.BackColor = System.Drawing.Color.White
        '
        '
        '
        '
        '
        '
        Me.SuperTabControl1.ControlBox.CloseBox.Name = ""
        '
        '
        '
        Me.SuperTabControl1.ControlBox.MenuBox.Name = ""
        Me.SuperTabControl1.ControlBox.Name = ""
        Me.SuperTabControl1.ControlBox.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.SuperTabControl1.ControlBox.MenuBox, Me.SuperTabControl1.ControlBox.CloseBox})
        Me.SuperTabControl1.Controls.Add(Me.SuperTabControlPanel9)
        Me.SuperTabControl1.Controls.Add(Me.SuperTabControlPanel10)
        Me.SuperTabControl1.ForeColor = System.Drawing.Color.Black
        Me.SuperTabControl1.Location = New System.Drawing.Point(6, 7)
        Me.SuperTabControl1.Name = "SuperTabControl1"
        Me.SuperTabControl1.ReorderTabsEnabled = True
        Me.SuperTabControl1.SelectedTabFont = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold)
        Me.SuperTabControl1.SelectedTabIndex = 1
        Me.SuperTabControl1.Size = New System.Drawing.Size(527, 195)
        Me.SuperTabControl1.TabFont = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SuperTabControl1.TabIndex = 116
        Me.SuperTabControl1.Tabs.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.SubTabConfAuto_OCC, Me.SubTabConfAuto_NVI})
        Me.SuperTabControl1.Text = "SuperTabControl1"
        '
        'SuperTabControlPanel9
        '
        Me.SuperTabControlPanel9.Controls.Add(Me.GroupPanel1)
        Me.SuperTabControlPanel9.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel9.Location = New System.Drawing.Point(0, 27)
        Me.SuperTabControlPanel9.Name = "SuperTabControlPanel9"
        Me.SuperTabControlPanel9.Size = New System.Drawing.Size(527, 168)
        Me.SuperTabControlPanel9.TabIndex = 1
        Me.SuperTabControlPanel9.TabItem = Me.SubTabConfAuto_OCC
        '
        'GroupPanel1
        '
        Me.GroupPanel1.BackColor = System.Drawing.Color.White
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.Chk_NoEnviarCorreosAProveedores)
        Me.GroupPanel1.Controls.Add(Me.LabelX26)
        Me.GroupPanel1.Controls.Add(Me.Txt_NombreFormato_PDF_OCC)
        Me.GroupPanel1.Controls.Add(Me.Txt_CorreoCc_OCC)
        Me.GroupPanel1.Controls.Add(Me.LabelX22)
        Me.GroupPanel1.Controls.Add(Me.Txt_CtaCorreoEnvioAutomatizado_OCC)
        Me.GroupPanel1.Controls.Add(Me.LabelX21)
        Me.GroupPanel1.Controls.Add(Me.LabelX23)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Location = New System.Drawing.Point(3, 3)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(521, 162)
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
        Me.GroupPanel1.TabIndex = 10022
        '
        'LabelX26
        '
        Me.LabelX26.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelX26.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX26.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX26.ForeColor = System.Drawing.Color.Black
        Me.LabelX26.Location = New System.Drawing.Point(1, 132)
        Me.LabelX26.Name = "LabelX26"
        Me.LabelX26.SingleLineColor = System.Drawing.Color.Transparent
        Me.LabelX26.Size = New System.Drawing.Size(512, 23)
        Me.LabelX26.TabIndex = 10025
        Me.LabelX26.Text = "Nota: para no enviar los correos a los proveedores, solo deje vacía la casilla Co" &
    "rreo de envió"
        '
        'Txt_NombreFormato_PDF_OCC
        '
        Me.Txt_NombreFormato_PDF_OCC.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_NombreFormato_PDF_OCC.Border.Class = "TextBoxBorder"
        Me.Txt_NombreFormato_PDF_OCC.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_NombreFormato_PDF_OCC.ButtonCustom.Image = CType(resources.GetObject("Txt_NombreFormato_PDF_OCC.ButtonCustom.Image"), System.Drawing.Image)
        Me.Txt_NombreFormato_PDF_OCC.ButtonCustom.Visible = True
        Me.Txt_NombreFormato_PDF_OCC.ButtonCustom2.Image = CType(resources.GetObject("Txt_NombreFormato_PDF_OCC.ButtonCustom2.Image"), System.Drawing.Image)
        Me.Txt_NombreFormato_PDF_OCC.ButtonCustom2.Visible = True
        Me.Txt_NombreFormato_PDF_OCC.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_NombreFormato_PDF_OCC.ForeColor = System.Drawing.Color.Black
        Me.Txt_NombreFormato_PDF_OCC.Location = New System.Drawing.Point(106, 37)
        Me.Txt_NombreFormato_PDF_OCC.Name = "Txt_NombreFormato_PDF_OCC"
        Me.Txt_NombreFormato_PDF_OCC.PreventEnterBeep = True
        Me.Txt_NombreFormato_PDF_OCC.ReadOnly = True
        Me.Txt_NombreFormato_PDF_OCC.Size = New System.Drawing.Size(406, 22)
        Me.Txt_NombreFormato_PDF_OCC.TabIndex = 10016
        '
        'Txt_CorreoCc_OCC
        '
        Me.Txt_CorreoCc_OCC.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_CorreoCc_OCC.Border.Class = "TextBoxBorder"
        Me.Txt_CorreoCc_OCC.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_CorreoCc_OCC.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_CorreoCc_OCC.ForeColor = System.Drawing.Color.Black
        Me.Txt_CorreoCc_OCC.Location = New System.Drawing.Point(106, 66)
        Me.Txt_CorreoCc_OCC.Name = "Txt_CorreoCc_OCC"
        Me.Txt_CorreoCc_OCC.PreventEnterBeep = True
        Me.Txt_CorreoCc_OCC.Size = New System.Drawing.Size(406, 22)
        Me.Txt_CorreoCc_OCC.TabIndex = 10014
        '
        'LabelX22
        '
        Me.LabelX22.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelX22.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX22.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX22.ForeColor = System.Drawing.Color.Black
        Me.LabelX22.Location = New System.Drawing.Point(0, 65)
        Me.LabelX22.Name = "LabelX22"
        Me.LabelX22.SingleLineColor = System.Drawing.Color.Transparent
        Me.LabelX22.Size = New System.Drawing.Size(87, 23)
        Me.LabelX22.TabIndex = 10013
        Me.LabelX22.Text = "Mail info. Cc OCC"
        '
        'Txt_CtaCorreoEnvioAutomatizado_OCC
        '
        Me.Txt_CtaCorreoEnvioAutomatizado_OCC.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_CtaCorreoEnvioAutomatizado_OCC.Border.Class = "TextBoxBorder"
        Me.Txt_CtaCorreoEnvioAutomatizado_OCC.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_CtaCorreoEnvioAutomatizado_OCC.ButtonCustom.Image = CType(resources.GetObject("Txt_CtaCorreoEnvioAutomatizado_OCC.ButtonCustom.Image"), System.Drawing.Image)
        Me.Txt_CtaCorreoEnvioAutomatizado_OCC.ButtonCustom.Visible = True
        Me.Txt_CtaCorreoEnvioAutomatizado_OCC.ButtonCustom2.Image = CType(resources.GetObject("Txt_CtaCorreoEnvioAutomatizado_OCC.ButtonCustom2.Image"), System.Drawing.Image)
        Me.Txt_CtaCorreoEnvioAutomatizado_OCC.ButtonCustom2.Visible = True
        Me.Txt_CtaCorreoEnvioAutomatizado_OCC.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_CtaCorreoEnvioAutomatizado_OCC.ForeColor = System.Drawing.Color.Black
        Me.Txt_CtaCorreoEnvioAutomatizado_OCC.Location = New System.Drawing.Point(106, 7)
        Me.Txt_CtaCorreoEnvioAutomatizado_OCC.Name = "Txt_CtaCorreoEnvioAutomatizado_OCC"
        Me.Txt_CtaCorreoEnvioAutomatizado_OCC.PreventEnterBeep = True
        Me.Txt_CtaCorreoEnvioAutomatizado_OCC.ReadOnly = True
        Me.Txt_CtaCorreoEnvioAutomatizado_OCC.Size = New System.Drawing.Size(406, 22)
        Me.Txt_CtaCorreoEnvioAutomatizado_OCC.TabIndex = 90
        Me.Txt_CtaCorreoEnvioAutomatizado_OCC.Tag = "9999"
        '
        'LabelX21
        '
        Me.LabelX21.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelX21.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX21.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX21.ForeColor = System.Drawing.Color.Black
        Me.LabelX21.Location = New System.Drawing.Point(0, 7)
        Me.LabelX21.Name = "LabelX21"
        Me.LabelX21.SingleLineColor = System.Drawing.Color.Transparent
        Me.LabelX21.Size = New System.Drawing.Size(87, 23)
        Me.LabelX21.TabIndex = 10012
        Me.LabelX21.Text = "Correo de envío"
        '
        'LabelX23
        '
        Me.LabelX23.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX23.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX23.ForeColor = System.Drawing.Color.Black
        Me.LabelX23.Location = New System.Drawing.Point(0, 37)
        Me.LabelX23.Name = "LabelX23"
        Me.LabelX23.Size = New System.Drawing.Size(97, 22)
        Me.LabelX23.TabIndex = 10015
        Me.LabelX23.Text = "Fomato imp. PDF"
        '
        'SubTabConfAuto_OCC
        '
        Me.SubTabConfAuto_OCC.AttachedControl = Me.SuperTabControlPanel9
        Me.SubTabConfAuto_OCC.GlobalItem = False
        Me.SubTabConfAuto_OCC.Name = "SubTabConfAuto_OCC"
        Me.SubTabConfAuto_OCC.Text = "OCC proveedores"
        '
        'SuperTabControlPanel10
        '
        Me.SuperTabControlPanel10.Controls.Add(Me.GroupPanel2)
        Me.SuperTabControlPanel10.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel10.Location = New System.Drawing.Point(0, 27)
        Me.SuperTabControlPanel10.Name = "SuperTabControlPanel10"
        Me.SuperTabControlPanel10.Size = New System.Drawing.Size(527, 168)
        Me.SuperTabControlPanel10.TabIndex = 0
        Me.SuperTabControlPanel10.TabItem = Me.SubTabConfAuto_NVI
        '
        'GroupPanel2
        '
        Me.GroupPanel2.BackColor = System.Drawing.Color.White
        Me.GroupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel2.Controls.Add(Me.LabelX24)
        Me.GroupPanel2.Controls.Add(Me.LabelX25)
        Me.GroupPanel2.Controls.Add(Me.Txt_NombreFormato_PDF_NVI)
        Me.GroupPanel2.Controls.Add(Me.Btn_Bodega_NVI_Estudio)
        Me.GroupPanel2.Controls.Add(Me.Txt_CorreoCc_NVI)
        Me.GroupPanel2.Controls.Add(Me.Txt_CtaCorreoEnvioAutomatizado_NVI)
        Me.GroupPanel2.Controls.Add(Me.LabelX27)
        Me.GroupPanel2.Controls.Add(Me.LabelX28)
        Me.GroupPanel2.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel2.Location = New System.Drawing.Point(3, 3)
        Me.GroupPanel2.Name = "GroupPanel2"
        Me.GroupPanel2.Size = New System.Drawing.Size(521, 162)
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
        Me.GroupPanel2.TabIndex = 10023
        '
        'LabelX24
        '
        Me.LabelX24.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelX24.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX24.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX24.ForeColor = System.Drawing.Color.Black
        Me.LabelX24.Location = New System.Drawing.Point(0, 128)
        Me.LabelX24.Name = "LabelX24"
        Me.LabelX24.SingleLineColor = System.Drawing.Color.Transparent
        Me.LabelX24.Size = New System.Drawing.Size(512, 23)
        Me.LabelX24.TabIndex = 10025
        Me.LabelX24.Text = "Nota: para no enviar los correos a los proveedores, solo deje vacía la casilla Co" &
    "rreo de envió"
        '
        'LabelX25
        '
        Me.LabelX25.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelX25.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX25.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX25.ForeColor = System.Drawing.Color.Black
        Me.LabelX25.Location = New System.Drawing.Point(0, 65)
        Me.LabelX25.Name = "LabelX25"
        Me.LabelX25.SingleLineColor = System.Drawing.Color.Transparent
        Me.LabelX25.Size = New System.Drawing.Size(103, 23)
        Me.LabelX25.TabIndex = 10018
        Me.LabelX25.Text = "Mail info. aviso NVI"
        '
        'Txt_NombreFormato_PDF_NVI
        '
        Me.Txt_NombreFormato_PDF_NVI.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_NombreFormato_PDF_NVI.Border.Class = "TextBoxBorder"
        Me.Txt_NombreFormato_PDF_NVI.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_NombreFormato_PDF_NVI.ButtonCustom.Image = CType(resources.GetObject("Txt_NombreFormato_PDF_NVI.ButtonCustom.Image"), System.Drawing.Image)
        Me.Txt_NombreFormato_PDF_NVI.ButtonCustom.Visible = True
        Me.Txt_NombreFormato_PDF_NVI.ButtonCustom2.Image = CType(resources.GetObject("Txt_NombreFormato_PDF_NVI.ButtonCustom2.Image"), System.Drawing.Image)
        Me.Txt_NombreFormato_PDF_NVI.ButtonCustom2.Visible = True
        Me.Txt_NombreFormato_PDF_NVI.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_NombreFormato_PDF_NVI.ForeColor = System.Drawing.Color.Black
        Me.Txt_NombreFormato_PDF_NVI.Location = New System.Drawing.Point(106, 37)
        Me.Txt_NombreFormato_PDF_NVI.Name = "Txt_NombreFormato_PDF_NVI"
        Me.Txt_NombreFormato_PDF_NVI.PreventEnterBeep = True
        Me.Txt_NombreFormato_PDF_NVI.ReadOnly = True
        Me.Txt_NombreFormato_PDF_NVI.Size = New System.Drawing.Size(406, 22)
        Me.Txt_NombreFormato_PDF_NVI.TabIndex = 10016
        '
        'Btn_Bodega_NVI_Estudio
        '
        Me.Btn_Bodega_NVI_Estudio.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Bodega_NVI_Estudio.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Bodega_NVI_Estudio.Image = CType(resources.GetObject("Btn_Bodega_NVI_Estudio.Image"), System.Drawing.Image)
        Me.Btn_Bodega_NVI_Estudio.ImageAlt = CType(resources.GetObject("Btn_Bodega_NVI_Estudio.ImageAlt"), System.Drawing.Image)
        Me.Btn_Bodega_NVI_Estudio.Location = New System.Drawing.Point(106, 96)
        Me.Btn_Bodega_NVI_Estudio.Name = "Btn_Bodega_NVI_Estudio"
        Me.Btn_Bodega_NVI_Estudio.Size = New System.Drawing.Size(201, 29)
        Me.Btn_Bodega_NVI_Estudio.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Bodega_NVI_Estudio.TabIndex = 10017
        Me.Btn_Bodega_NVI_Estudio.Text = "Bodegas de estudio de stock NVI"
        '
        'Txt_CorreoCc_NVI
        '
        Me.Txt_CorreoCc_NVI.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_CorreoCc_NVI.Border.Class = "TextBoxBorder"
        Me.Txt_CorreoCc_NVI.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_CorreoCc_NVI.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_CorreoCc_NVI.ForeColor = System.Drawing.Color.Black
        Me.Txt_CorreoCc_NVI.Location = New System.Drawing.Point(106, 66)
        Me.Txt_CorreoCc_NVI.Name = "Txt_CorreoCc_NVI"
        Me.Txt_CorreoCc_NVI.PreventEnterBeep = True
        Me.Txt_CorreoCc_NVI.Size = New System.Drawing.Size(406, 22)
        Me.Txt_CorreoCc_NVI.TabIndex = 10014
        '
        'Txt_CtaCorreoEnvioAutomatizado_NVI
        '
        Me.Txt_CtaCorreoEnvioAutomatizado_NVI.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_CtaCorreoEnvioAutomatizado_NVI.Border.Class = "TextBoxBorder"
        Me.Txt_CtaCorreoEnvioAutomatizado_NVI.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_CtaCorreoEnvioAutomatizado_NVI.ButtonCustom.Image = CType(resources.GetObject("Txt_CtaCorreoEnvioAutomatizado_NVI.ButtonCustom.Image"), System.Drawing.Image)
        Me.Txt_CtaCorreoEnvioAutomatizado_NVI.ButtonCustom.Visible = True
        Me.Txt_CtaCorreoEnvioAutomatizado_NVI.ButtonCustom2.Image = CType(resources.GetObject("Txt_CtaCorreoEnvioAutomatizado_NVI.ButtonCustom2.Image"), System.Drawing.Image)
        Me.Txt_CtaCorreoEnvioAutomatizado_NVI.ButtonCustom2.Visible = True
        Me.Txt_CtaCorreoEnvioAutomatizado_NVI.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_CtaCorreoEnvioAutomatizado_NVI.ForeColor = System.Drawing.Color.Black
        Me.Txt_CtaCorreoEnvioAutomatizado_NVI.Location = New System.Drawing.Point(106, 7)
        Me.Txt_CtaCorreoEnvioAutomatizado_NVI.Name = "Txt_CtaCorreoEnvioAutomatizado_NVI"
        Me.Txt_CtaCorreoEnvioAutomatizado_NVI.PreventEnterBeep = True
        Me.Txt_CtaCorreoEnvioAutomatizado_NVI.ReadOnly = True
        Me.Txt_CtaCorreoEnvioAutomatizado_NVI.Size = New System.Drawing.Size(406, 22)
        Me.Txt_CtaCorreoEnvioAutomatizado_NVI.TabIndex = 90
        Me.Txt_CtaCorreoEnvioAutomatizado_NVI.Tag = "9999"
        '
        'LabelX27
        '
        Me.LabelX27.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelX27.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX27.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX27.ForeColor = System.Drawing.Color.Black
        Me.LabelX27.Location = New System.Drawing.Point(0, 7)
        Me.LabelX27.Name = "LabelX27"
        Me.LabelX27.SingleLineColor = System.Drawing.Color.Transparent
        Me.LabelX27.Size = New System.Drawing.Size(87, 23)
        Me.LabelX27.TabIndex = 10012
        Me.LabelX27.Text = "Correo de envío"
        '
        'LabelX28
        '
        Me.LabelX28.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX28.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX28.ForeColor = System.Drawing.Color.Black
        Me.LabelX28.Location = New System.Drawing.Point(0, 37)
        Me.LabelX28.Name = "LabelX28"
        Me.LabelX28.Size = New System.Drawing.Size(97, 22)
        Me.LabelX28.TabIndex = 10015
        Me.LabelX28.Text = "Fomato imp. PDF"
        '
        'SubTabConfAuto_NVI
        '
        Me.SubTabConfAuto_NVI.AttachedControl = Me.SuperTabControlPanel10
        Me.SubTabConfAuto_NVI.GlobalItem = False
        Me.SubTabConfAuto_NVI.Name = "SubTabConfAuto_NVI"
        Me.SubTabConfAuto_NVI.Text = "NVI solicitudes internas"
        '
        'Tab_Automatizacion
        '
        Me.Tab_Automatizacion.AttachedControl = Me.SuperTabControlPanel8
        Me.Tab_Automatizacion.GlobalItem = False
        Me.Tab_Automatizacion.Name = "Tab_Automatizacion"
        Me.Tab_Automatizacion.Text = "Conf. Automatización"
        '
        'SuperTabControlPanel2
        '
        Me.SuperTabControlPanel2.Controls.Add(Me.Chk_DbExt_SincronizarPRBD)
        Me.SuperTabControlPanel2.Controls.Add(Me.Grupo_DbExt)
        Me.SuperTabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel2.Location = New System.Drawing.Point(0, 0)
        Me.SuperTabControlPanel2.Name = "SuperTabControlPanel2"
        Me.SuperTabControlPanel2.Size = New System.Drawing.Size(539, 232)
        Me.SuperTabControlPanel2.TabIndex = 0
        Me.SuperTabControlPanel2.TabItem = Me.Tab_ConexionExterna
        '
        'Chk_DbExt_SincronizarPRBD
        '
        Me.Chk_DbExt_SincronizarPRBD.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_DbExt_SincronizarPRBD.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_DbExt_SincronizarPRBD.ForeColor = System.Drawing.Color.Black
        Me.Chk_DbExt_SincronizarPRBD.Location = New System.Drawing.Point(7, 5)
        Me.Chk_DbExt_SincronizarPRBD.Name = "Chk_DbExt_SincronizarPRBD"
        Me.Chk_DbExt_SincronizarPRBD.Size = New System.Drawing.Size(518, 23)
        Me.Chk_DbExt_SincronizarPRBD.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_DbExt_SincronizarPRBD.TabIndex = 10020
        Me.Chk_DbExt_SincronizarPRBD.Text = "Sincronizar productos entre ambas bases para estudios"
        '
        'Grupo_DbExt
        '
        Me.Grupo_DbExt.BackColor = System.Drawing.Color.White
        Me.Grupo_DbExt.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Grupo_DbExt.Controls.Add(Me.Chk_SumerStockExternoAlFisico)
        Me.Grupo_DbExt.Controls.Add(Me.LabelX17)
        Me.Grupo_DbExt.Controls.Add(Me.Txt_DbExt_NombreBod_Des)
        Me.Grupo_DbExt.Controls.Add(Me.Txt_ProvEspecial)
        Me.Grupo_DbExt.Controls.Add(Me.LabelX20)
        Me.Grupo_DbExt.Controls.Add(Me.Btn_Buscar_ProvEspecial)
        Me.Grupo_DbExt.Controls.Add(Me.Txt_DbExt_NombreBod_Ori)
        Me.Grupo_DbExt.Controls.Add(Me.Txt_DbExt_Nombre_Conexion)
        Me.Grupo_DbExt.Controls.Add(Me.LabelX19)
        Me.Grupo_DbExt.Controls.Add(Me.LabelX18)
        Me.Grupo_DbExt.DisabledBackColor = System.Drawing.Color.Empty
        Me.Grupo_DbExt.Location = New System.Drawing.Point(7, 34)
        Me.Grupo_DbExt.Name = "Grupo_DbExt"
        Me.Grupo_DbExt.Size = New System.Drawing.Size(518, 159)
        '
        '
        '
        Me.Grupo_DbExt.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Grupo_DbExt.Style.BackColorGradientAngle = 90
        Me.Grupo_DbExt.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Grupo_DbExt.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_DbExt.Style.BorderBottomWidth = 1
        Me.Grupo_DbExt.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.Grupo_DbExt.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_DbExt.Style.BorderLeftWidth = 1
        Me.Grupo_DbExt.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_DbExt.Style.BorderRightWidth = 1
        Me.Grupo_DbExt.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_DbExt.Style.BorderTopWidth = 1
        Me.Grupo_DbExt.Style.CornerDiameter = 4
        Me.Grupo_DbExt.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Grupo_DbExt.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.Grupo_DbExt.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.Grupo_DbExt.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.Grupo_DbExt.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.Grupo_DbExt.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Grupo_DbExt.TabIndex = 10021
        '
        'Chk_SumerStockExternoAlFisico
        '
        Me.Chk_SumerStockExternoAlFisico.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_SumerStockExternoAlFisico.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_SumerStockExternoAlFisico.CheckBoxImageChecked = CType(resources.GetObject("Chk_SumerStockExternoAlFisico.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_SumerStockExternoAlFisico.FocusCuesEnabled = False
        Me.Chk_SumerStockExternoAlFisico.ForeColor = System.Drawing.Color.Black
        Me.Chk_SumerStockExternoAlFisico.Location = New System.Drawing.Point(133, 94)
        Me.Chk_SumerStockExternoAlFisico.Name = "Chk_SumerStockExternoAlFisico"
        Me.Chk_SumerStockExternoAlFisico.Size = New System.Drawing.Size(210, 20)
        Me.Chk_SumerStockExternoAlFisico.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_SumerStockExternoAlFisico.TabIndex = 10020
        Me.Chk_SumerStockExternoAlFisico.Text = "Sumar stock externo al físico"
        '
        'LabelX17
        '
        Me.LabelX17.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX17.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX17.ForeColor = System.Drawing.Color.Black
        Me.LabelX17.Location = New System.Drawing.Point(3, 11)
        Me.LabelX17.Name = "LabelX17"
        Me.LabelX17.SingleLineColor = System.Drawing.Color.Transparent
        Me.LabelX17.Size = New System.Drawing.Size(128, 23)
        Me.LabelX17.TabIndex = 10012
        Me.LabelX17.Text = "Nombre conexión activa"
        '
        'Txt_DbExt_NombreBod_Des
        '
        Me.Txt_DbExt_NombreBod_Des.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_DbExt_NombreBod_Des.Border.Class = "TextBoxBorder"
        Me.Txt_DbExt_NombreBod_Des.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_DbExt_NombreBod_Des.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_DbExt_NombreBod_Des.ForeColor = System.Drawing.Color.Black
        Me.Txt_DbExt_NombreBod_Des.Location = New System.Drawing.Point(133, 66)
        Me.Txt_DbExt_NombreBod_Des.Name = "Txt_DbExt_NombreBod_Des"
        Me.Txt_DbExt_NombreBod_Des.PreventEnterBeep = True
        Me.Txt_DbExt_NombreBod_Des.ReadOnly = True
        Me.Txt_DbExt_NombreBod_Des.Size = New System.Drawing.Size(373, 22)
        Me.Txt_DbExt_NombreBod_Des.TabIndex = 10019
        '
        'Txt_ProvEspecial
        '
        Me.Txt_ProvEspecial.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_ProvEspecial.Border.Class = "TextBoxBorder"
        Me.Txt_ProvEspecial.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_ProvEspecial.ButtonCustom.Image = CType(resources.GetObject("Txt_ProvEspecial.ButtonCustom.Image"), System.Drawing.Image)
        Me.Txt_ProvEspecial.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_ProvEspecial.ForeColor = System.Drawing.Color.Black
        Me.Txt_ProvEspecial.Location = New System.Drawing.Point(53, 128)
        Me.Txt_ProvEspecial.Name = "Txt_ProvEspecial"
        Me.Txt_ProvEspecial.PreventEnterBeep = True
        Me.Txt_ProvEspecial.ReadOnly = True
        Me.Txt_ProvEspecial.Size = New System.Drawing.Size(453, 22)
        Me.Txt_ProvEspecial.TabIndex = 11
        '
        'LabelX20
        '
        Me.LabelX20.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX20.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX20.ForeColor = System.Drawing.Color.Black
        Me.LabelX20.Location = New System.Drawing.Point(3, 63)
        Me.LabelX20.Name = "LabelX20"
        Me.LabelX20.SingleLineColor = System.Drawing.Color.Transparent
        Me.LabelX20.Size = New System.Drawing.Size(128, 23)
        Me.LabelX20.TabIndex = 10018
        Me.LabelX20.Text = "Bodega de destino"
        '
        'Btn_Buscar_ProvEspecial
        '
        Me.Btn_Buscar_ProvEspecial.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Buscar_ProvEspecial.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Buscar_ProvEspecial.Image = CType(resources.GetObject("Btn_Buscar_ProvEspecial.Image"), System.Drawing.Image)
        Me.Btn_Buscar_ProvEspecial.ImageAlt = CType(resources.GetObject("Btn_Buscar_ProvEspecial.ImageAlt"), System.Drawing.Image)
        Me.Btn_Buscar_ProvEspecial.Location = New System.Drawing.Point(0, 128)
        Me.Btn_Buscar_ProvEspecial.Name = "Btn_Buscar_ProvEspecial"
        Me.Btn_Buscar_ProvEspecial.Size = New System.Drawing.Size(46, 22)
        Me.Btn_Buscar_ProvEspecial.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Buscar_ProvEspecial.TabIndex = 12
        Me.Btn_Buscar_ProvEspecial.Tooltip = "Buscar proveedor"
        '
        'Txt_DbExt_NombreBod_Ori
        '
        Me.Txt_DbExt_NombreBod_Ori.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_DbExt_NombreBod_Ori.Border.Class = "TextBoxBorder"
        Me.Txt_DbExt_NombreBod_Ori.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_DbExt_NombreBod_Ori.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_DbExt_NombreBod_Ori.ForeColor = System.Drawing.Color.Black
        Me.Txt_DbExt_NombreBod_Ori.Location = New System.Drawing.Point(133, 38)
        Me.Txt_DbExt_NombreBod_Ori.Name = "Txt_DbExt_NombreBod_Ori"
        Me.Txt_DbExt_NombreBod_Ori.PreventEnterBeep = True
        Me.Txt_DbExt_NombreBod_Ori.ReadOnly = True
        Me.Txt_DbExt_NombreBod_Ori.Size = New System.Drawing.Size(373, 22)
        Me.Txt_DbExt_NombreBod_Ori.TabIndex = 10017
        '
        'Txt_DbExt_Nombre_Conexion
        '
        Me.Txt_DbExt_Nombre_Conexion.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_DbExt_Nombre_Conexion.Border.Class = "TextBoxBorder"
        Me.Txt_DbExt_Nombre_Conexion.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_DbExt_Nombre_Conexion.ButtonCustom.Image = CType(resources.GetObject("Txt_DbExt_Nombre_Conexion.ButtonCustom.Image"), System.Drawing.Image)
        Me.Txt_DbExt_Nombre_Conexion.ButtonCustom.Visible = True
        Me.Txt_DbExt_Nombre_Conexion.ButtonCustom2.Image = CType(resources.GetObject("Txt_DbExt_Nombre_Conexion.ButtonCustom2.Image"), System.Drawing.Image)
        Me.Txt_DbExt_Nombre_Conexion.ButtonCustom2.Visible = True
        Me.Txt_DbExt_Nombre_Conexion.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_DbExt_Nombre_Conexion.ForeColor = System.Drawing.Color.Black
        Me.Txt_DbExt_Nombre_Conexion.Location = New System.Drawing.Point(133, 11)
        Me.Txt_DbExt_Nombre_Conexion.Name = "Txt_DbExt_Nombre_Conexion"
        Me.Txt_DbExt_Nombre_Conexion.PreventEnterBeep = True
        Me.Txt_DbExt_Nombre_Conexion.ReadOnly = True
        Me.Txt_DbExt_Nombre_Conexion.Size = New System.Drawing.Size(373, 22)
        Me.Txt_DbExt_Nombre_Conexion.TabIndex = 10014
        Me.Txt_DbExt_Nombre_Conexion.Tag = "0"
        '
        'LabelX19
        '
        Me.LabelX19.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX19.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX19.ForeColor = System.Drawing.Color.Black
        Me.LabelX19.Location = New System.Drawing.Point(3, 35)
        Me.LabelX19.Name = "LabelX19"
        Me.LabelX19.SingleLineColor = System.Drawing.Color.Transparent
        Me.LabelX19.Size = New System.Drawing.Size(128, 23)
        Me.LabelX19.TabIndex = 10016
        Me.LabelX19.Text = "Bodega de origen"
        '
        'LabelX18
        '
        Me.LabelX18.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX18.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX18.ForeColor = System.Drawing.Color.Black
        Me.LabelX18.Location = New System.Drawing.Point(3, 99)
        Me.LabelX18.Name = "LabelX18"
        Me.LabelX18.SingleLineColor = System.Drawing.Color.Transparent
        Me.LabelX18.Size = New System.Drawing.Size(128, 23)
        Me.LabelX18.TabIndex = 10015
        Me.LabelX18.Text = "Proveedor estrella"
        '
        'Tab_ConexionExterna
        '
        Me.Tab_ConexionExterna.AttachedControl = Me.SuperTabControlPanel2
        Me.Tab_ConexionExterna.GlobalItem = False
        Me.Tab_ConexionExterna.Name = "Tab_ConexionExterna"
        Me.Tab_ConexionExterna.Text = "Bod.Ext. Prov. Especial"
        '
        'SuperTabControlPanel5
        '
        Me.SuperTabControlPanel5.Controls.Add(Me.ReflectionImage1)
        Me.SuperTabControlPanel5.Controls.Add(Me.Chk_Advertir_Rotacion)
        Me.SuperTabControlPanel5.Controls.Add(Me.LabelX12)
        Me.SuperTabControlPanel5.Controls.Add(Me.LabelX13)
        Me.SuperTabControlPanel5.Controls.Add(Me.Input_Dias_Advertencia_Rotacion)
        Me.SuperTabControlPanel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel5.Location = New System.Drawing.Point(0, 0)
        Me.SuperTabControlPanel5.Name = "SuperTabControlPanel5"
        Me.SuperTabControlPanel5.Size = New System.Drawing.Size(539, 232)
        Me.SuperTabControlPanel5.TabIndex = 0
        Me.SuperTabControlPanel5.TabItem = Me.SuperTabItem5
        '
        'ReflectionImage1
        '
        Me.ReflectionImage1.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.ReflectionImage1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ReflectionImage1.BackgroundStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.ReflectionImage1.ForeColor = System.Drawing.Color.Black
        Me.ReflectionImage1.Image = CType(resources.GetObject("ReflectionImage1.Image"), System.Drawing.Image)
        Me.ReflectionImage1.Location = New System.Drawing.Point(401, 14)
        Me.ReflectionImage1.Name = "ReflectionImage1"
        Me.ReflectionImage1.Size = New System.Drawing.Size(98, 78)
        Me.ReflectionImage1.TabIndex = 112
        '
        'Chk_Advertir_Rotacion
        '
        Me.Chk_Advertir_Rotacion.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_Advertir_Rotacion.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Advertir_Rotacion.ForeColor = System.Drawing.Color.Black
        Me.Chk_Advertir_Rotacion.Location = New System.Drawing.Point(20, 30)
        Me.Chk_Advertir_Rotacion.Name = "Chk_Advertir_Rotacion"
        Me.Chk_Advertir_Rotacion.Size = New System.Drawing.Size(245, 23)
        Me.Chk_Advertir_Rotacion.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Advertir_Rotacion.TabIndex = 108
        Me.Chk_Advertir_Rotacion.Text = "Advertir rotación"
        '
        'LabelX12
        '
        Me.LabelX12.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX12.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX12.ForeColor = System.Drawing.Color.Black
        Me.LabelX12.Location = New System.Drawing.Point(250, 59)
        Me.LabelX12.Name = "LabelX12"
        Me.LabelX12.Size = New System.Drawing.Size(149, 23)
        Me.LabelX12.TabIndex = 111
        Me.LabelX12.Text = "días desde el último estudio"
        '
        'LabelX13
        '
        Me.LabelX13.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX13.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX13.ForeColor = System.Drawing.Color.Black
        Me.LabelX13.Location = New System.Drawing.Point(20, 58)
        Me.LabelX13.Name = "LabelX13"
        Me.LabelX13.Size = New System.Drawing.Size(156, 23)
        Me.LabelX13.TabIndex = 109
        Me.LabelX13.Text = "Advierte cuando tenga más de"
        '
        'Input_Dias_Advertencia_Rotacion
        '
        Me.Input_Dias_Advertencia_Rotacion.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Input_Dias_Advertencia_Rotacion.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Input_Dias_Advertencia_Rotacion.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Input_Dias_Advertencia_Rotacion.ButtonClear.Visible = True
        Me.Input_Dias_Advertencia_Rotacion.FocusHighlightEnabled = True
        Me.Input_Dias_Advertencia_Rotacion.ForeColor = System.Drawing.Color.Black
        Me.Input_Dias_Advertencia_Rotacion.Location = New System.Drawing.Point(177, 59)
        Me.Input_Dias_Advertencia_Rotacion.MaxValue = 365
        Me.Input_Dias_Advertencia_Rotacion.MinValue = 1
        Me.Input_Dias_Advertencia_Rotacion.Name = "Input_Dias_Advertencia_Rotacion"
        Me.Input_Dias_Advertencia_Rotacion.ShowUpDown = True
        Me.Input_Dias_Advertencia_Rotacion.Size = New System.Drawing.Size(67, 22)
        Me.Input_Dias_Advertencia_Rotacion.TabIndex = 110
        Me.Input_Dias_Advertencia_Rotacion.Value = 7
        '
        'SuperTabItem5
        '
        Me.SuperTabItem5.AttachedControl = Me.SuperTabControlPanel5
        Me.SuperTabItem5.GlobalItem = False
        Me.SuperTabItem5.Name = "SuperTabItem5"
        Me.SuperTabItem5.Text = "Advertir Rotación"
        Me.SuperTabItem5.Visible = False
        '
        'SuperTabControlPanel7
        '
        Me.SuperTabControlPanel7.Controls.Add(Me.LabelX10)
        Me.SuperTabControlPanel7.Controls.Add(Me.Chk_Cargar_Rotacion_Estacional)
        Me.SuperTabControlPanel7.Controls.Add(Me.Dtp_Fecha_Vta_Desde_Estacional)
        Me.SuperTabControlPanel7.Controls.Add(Me.Label7)
        Me.SuperTabControlPanel7.Controls.Add(Me.Dtp_Fecha_Estacional_Hasta)
        Me.SuperTabControlPanel7.Controls.Add(Me.Label6)
        Me.SuperTabControlPanel7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel7.Enabled = False
        Me.SuperTabControlPanel7.Location = New System.Drawing.Point(0, 0)
        Me.SuperTabControlPanel7.Name = "SuperTabControlPanel7"
        Me.SuperTabControlPanel7.Size = New System.Drawing.Size(539, 232)
        Me.SuperTabControlPanel7.TabIndex = 0
        Me.SuperTabControlPanel7.TabItem = Me.SuperTabItem7
        '
        'LabelX10
        '
        Me.LabelX10.AutoSize = True
        Me.LabelX10.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX10.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX10.ForeColor = System.Drawing.Color.Black
        Me.LabelX10.Location = New System.Drawing.Point(11, 42)
        Me.LabelX10.Name = "LabelX10"
        Me.LabelX10.Size = New System.Drawing.Size(185, 17)
        Me.LabelX10.TabIndex = 52
        Me.LabelX10.Text = "<b>Rango de fecha rotación estacional</b>"
        '
        'Chk_Cargar_Rotacion_Estacional
        '
        Me.Chk_Cargar_Rotacion_Estacional.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_Cargar_Rotacion_Estacional.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Cargar_Rotacion_Estacional.ForeColor = System.Drawing.Color.Black
        Me.Chk_Cargar_Rotacion_Estacional.Location = New System.Drawing.Point(12, 12)
        Me.Chk_Cargar_Rotacion_Estacional.Name = "Chk_Cargar_Rotacion_Estacional"
        Me.Chk_Cargar_Rotacion_Estacional.Size = New System.Drawing.Size(241, 23)
        Me.Chk_Cargar_Rotacion_Estacional.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Cargar_Rotacion_Estacional.TabIndex = 51
        Me.Chk_Cargar_Rotacion_Estacional.Text = "Cargar rotación estacional para los productos"
        '
        'SuperTabItem7
        '
        Me.SuperTabItem7.AttachedControl = Me.SuperTabControlPanel7
        Me.SuperTabItem7.GlobalItem = False
        Me.SuperTabItem7.Name = "SuperTabItem7"
        Me.SuperTabItem7.Text = "Rotación estacional"
        Me.SuperTabItem7.Visible = False
        '
        'SuperTabControlPanel1
        '
        Me.SuperTabControlPanel1.CanvasColor = System.Drawing.Color.Empty
        Me.SuperTabControlPanel1.Controls.Add(Me.Dtp_Fecha_Vta_Desde)
        Me.SuperTabControlPanel1.Controls.Add(Me.Input_Ultimos_Meses_Vta_Promedio)
        Me.SuperTabControlPanel1.Controls.Add(Me.LabelX2)
        Me.SuperTabControlPanel1.Controls.Add(Me.Btn_Bodegas_Stock)
        Me.SuperTabControlPanel1.Controls.Add(Me.LabelX14)
        Me.SuperTabControlPanel1.Controls.Add(Me.TableLayoutPanel4)
        Me.SuperTabControlPanel1.Controls.Add(Me.TableLayoutPanel2)
        Me.SuperTabControlPanel1.Controls.Add(Me.LabelX1)
        Me.SuperTabControlPanel1.Controls.Add(Me.TableLayoutPanel1)
        Me.SuperTabControlPanel1.Controls.Add(Me.Dtp_Fecha_Vta_Hasta)
        Me.SuperTabControlPanel1.Controls.Add(Me.Btn_Bodega_Vta_Estudio)
        Me.SuperTabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel1.Location = New System.Drawing.Point(0, 0)
        Me.SuperTabControlPanel1.Name = "SuperTabControlPanel1"
        Me.SuperTabControlPanel1.Size = New System.Drawing.Size(539, 232)
        Me.SuperTabControlPanel1.TabIndex = 0
        Me.SuperTabControlPanel1.TabItem = Me.Tab_CalVnta
        '
        'Dtp_Fecha_Vta_Desde
        '
        Me.Dtp_Fecha_Vta_Desde.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Dtp_Fecha_Vta_Desde.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Dtp_Fecha_Vta_Desde.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Vta_Desde.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.Dtp_Fecha_Vta_Desde.ButtonDropDown.Visible = True
        Me.Dtp_Fecha_Vta_Desde.ForeColor = System.Drawing.Color.Black
        Me.Dtp_Fecha_Vta_Desde.IsPopupCalendarOpen = False
        Me.Dtp_Fecha_Vta_Desde.Location = New System.Drawing.Point(289, 43)
        '
        '
        '
        Me.Dtp_Fecha_Vta_Desde.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_Fecha_Vta_Desde.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Vta_Desde.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.Dtp_Fecha_Vta_Desde.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.Dtp_Fecha_Vta_Desde.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.Dtp_Fecha_Vta_Desde.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_Fecha_Vta_Desde.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.Dtp_Fecha_Vta_Desde.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Dtp_Fecha_Vta_Desde.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.Dtp_Fecha_Vta_Desde.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.Dtp_Fecha_Vta_Desde.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Vta_Desde.MonthCalendar.DisplayMonth = New Date(2018, 10, 1, 0, 0, 0, 0)
        Me.Dtp_Fecha_Vta_Desde.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday
        Me.Dtp_Fecha_Vta_Desde.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.Dtp_Fecha_Vta_Desde.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_Fecha_Vta_Desde.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Dtp_Fecha_Vta_Desde.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_Fecha_Vta_Desde.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Dtp_Fecha_Vta_Desde.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Vta_Desde.MonthCalendar.TodayButtonVisible = True
        Me.Dtp_Fecha_Vta_Desde.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.Dtp_Fecha_Vta_Desde.Name = "Dtp_Fecha_Vta_Desde"
        Me.Dtp_Fecha_Vta_Desde.Size = New System.Drawing.Size(81, 22)
        Me.Dtp_Fecha_Vta_Desde.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Dtp_Fecha_Vta_Desde.TabIndex = 63
        Me.Dtp_Fecha_Vta_Desde.Value = New Date(2018, 10, 19, 11, 12, 43, 0)
        '
        'Input_Ultimos_Meses_Vta_Promedio
        '
        Me.Input_Ultimos_Meses_Vta_Promedio.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Input_Ultimos_Meses_Vta_Promedio.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Input_Ultimos_Meses_Vta_Promedio.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Input_Ultimos_Meses_Vta_Promedio.ButtonClear.Visible = True
        Me.Input_Ultimos_Meses_Vta_Promedio.FocusHighlightEnabled = True
        Me.Input_Ultimos_Meses_Vta_Promedio.ForeColor = System.Drawing.Color.Black
        Me.Input_Ultimos_Meses_Vta_Promedio.Location = New System.Drawing.Point(235, 68)
        Me.Input_Ultimos_Meses_Vta_Promedio.MaxValue = 24
        Me.Input_Ultimos_Meses_Vta_Promedio.MinValue = 1
        Me.Input_Ultimos_Meses_Vta_Promedio.Name = "Input_Ultimos_Meses_Vta_Promedio"
        Me.Input_Ultimos_Meses_Vta_Promedio.ShowUpDown = True
        Me.Input_Ultimos_Meses_Vta_Promedio.Size = New System.Drawing.Size(47, 22)
        Me.Input_Ultimos_Meses_Vta_Promedio.TabIndex = 109
        Me.Input_Ultimos_Meses_Vta_Promedio.Value = 12
        '
        'LabelX2
        '
        Me.LabelX2.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.ForeColor = System.Drawing.Color.Black
        Me.LabelX2.Location = New System.Drawing.Point(235, 46)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(47, 19)
        Me.LabelX2.TabIndex = 114
        Me.LabelX2.Text = "Desde"
        Me.LabelX2.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'Btn_Bodegas_Stock
        '
        Me.Btn_Bodegas_Stock.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Bodegas_Stock.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Bodegas_Stock.FocusCuesEnabled = False
        Me.Btn_Bodegas_Stock.Image = CType(resources.GetObject("Btn_Bodegas_Stock.Image"), System.Drawing.Image)
        Me.Btn_Bodegas_Stock.ImageAlt = CType(resources.GetObject("Btn_Bodegas_Stock.ImageAlt"), System.Drawing.Image)
        Me.Btn_Bodegas_Stock.Location = New System.Drawing.Point(9, 5)
        Me.Btn_Bodegas_Stock.Name = "Btn_Bodegas_Stock"
        Me.Btn_Bodegas_Stock.Size = New System.Drawing.Size(235, 29)
        Me.Btn_Bodegas_Stock.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Bodegas_Stock.TabIndex = 114
        Me.Btn_Bodegas_Stock.Text = "Bodegas de estudio de stock COMPRA"
        '
        'LabelX14
        '
        Me.LabelX14.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX14.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX14.ForeColor = System.Drawing.Color.Black
        Me.LabelX14.Location = New System.Drawing.Point(12, 98)
        Me.LabelX14.Name = "LabelX14"
        Me.LabelX14.SingleLineColor = System.Drawing.Color.Transparent
        Me.LabelX14.Size = New System.Drawing.Size(252, 23)
        Me.LabelX14.TabIndex = 10012
        Me.LabelX14.Text = "Para calcular las compras usar la rotación de venta?"
        '
        'TableLayoutPanel4
        '
        Me.TableLayoutPanel4.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel4.ColumnCount = 2
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28.44828!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 71.55173!))
        Me.TableLayoutPanel4.Controls.Add(Me.Rdb_Rot_Promedio, 1, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.Rdb_Rot_Mediana, 0, 0)
        Me.TableLayoutPanel4.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel4.Location = New System.Drawing.Point(272, 97)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        Me.TableLayoutPanel4.RowCount = 1
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel4.Size = New System.Drawing.Size(232, 21)
        Me.TableLayoutPanel4.TabIndex = 116
        '
        'Rdb_Rot_Promedio
        '
        '
        '
        '
        Me.Rdb_Rot_Promedio.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Rot_Promedio.CheckBoxImageChecked = CType(resources.GetObject("Rdb_Rot_Promedio.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Rdb_Rot_Promedio.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Rot_Promedio.FocusCuesEnabled = False
        Me.Rdb_Rot_Promedio.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Rot_Promedio.Location = New System.Drawing.Point(69, 3)
        Me.Rdb_Rot_Promedio.Name = "Rdb_Rot_Promedio"
        Me.Rdb_Rot_Promedio.Size = New System.Drawing.Size(124, 15)
        Me.Rdb_Rot_Promedio.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Rot_Promedio.TabIndex = 115
        Me.Rdb_Rot_Promedio.Text = "Promedio"
        '
        'Rdb_Rot_Mediana
        '
        '
        '
        '
        Me.Rdb_Rot_Mediana.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Rot_Mediana.CheckBoxImageChecked = CType(resources.GetObject("Rdb_Rot_Mediana.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Rdb_Rot_Mediana.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Rot_Mediana.Checked = True
        Me.Rdb_Rot_Mediana.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Rdb_Rot_Mediana.CheckValue = "Y"
        Me.Rdb_Rot_Mediana.FocusCuesEnabled = False
        Me.Rdb_Rot_Mediana.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Rot_Mediana.Location = New System.Drawing.Point(3, 3)
        Me.Rdb_Rot_Mediana.Name = "Rdb_Rot_Mediana"
        Me.Rdb_Rot_Mediana.Size = New System.Drawing.Size(60, 15)
        Me.Rdb_Rot_Mediana.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Rot_Mediana.TabIndex = 114
        Me.Rdb_Rot_Mediana.Text = "Mediana"
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel2.ColumnCount = 1
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 79.47762!))
        Me.TableLayoutPanel2.Controls.Add(Me.Rdb_Rango_Fechas_Vta_Promedio, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Rdb_Rango_Meses_Vta_Promedio, 0, 1)
        Me.TableLayoutPanel2.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(9, 40)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 2
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.9434!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 49.0566!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(220, 51)
        Me.TableLayoutPanel2.TabIndex = 52
        '
        'Rdb_Rango_Fechas_Vta_Promedio
        '
        '
        '
        '
        Me.Rdb_Rango_Fechas_Vta_Promedio.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Rango_Fechas_Vta_Promedio.CheckBoxImageChecked = CType(resources.GetObject("Rdb_Rango_Fechas_Vta_Promedio.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Rdb_Rango_Fechas_Vta_Promedio.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Rango_Fechas_Vta_Promedio.FocusCuesEnabled = False
        Me.Rdb_Rango_Fechas_Vta_Promedio.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Rango_Fechas_Vta_Promedio.Location = New System.Drawing.Point(3, 3)
        Me.Rdb_Rango_Fechas_Vta_Promedio.Name = "Rdb_Rango_Fechas_Vta_Promedio"
        Me.Rdb_Rango_Fechas_Vta_Promedio.Size = New System.Drawing.Size(214, 19)
        Me.Rdb_Rango_Fechas_Vta_Promedio.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Rango_Fechas_Vta_Promedio.TabIndex = 53
        Me.Rdb_Rango_Fechas_Vta_Promedio.Text = "Ventas generadas entre un periodo"
        '
        'Rdb_Rango_Meses_Vta_Promedio
        '
        '
        '
        '
        Me.Rdb_Rango_Meses_Vta_Promedio.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Rango_Meses_Vta_Promedio.CheckBoxImageChecked = CType(resources.GetObject("Rdb_Rango_Meses_Vta_Promedio.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Rdb_Rango_Meses_Vta_Promedio.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Rango_Meses_Vta_Promedio.Checked = True
        Me.Rdb_Rango_Meses_Vta_Promedio.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Rdb_Rango_Meses_Vta_Promedio.CheckValue = "Y"
        Me.Rdb_Rango_Meses_Vta_Promedio.FocusCuesEnabled = False
        Me.Rdb_Rango_Meses_Vta_Promedio.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Rango_Meses_Vta_Promedio.Location = New System.Drawing.Point(3, 28)
        Me.Rdb_Rango_Meses_Vta_Promedio.Name = "Rdb_Rango_Meses_Vta_Promedio"
        Me.Rdb_Rango_Meses_Vta_Promedio.Size = New System.Drawing.Size(214, 20)
        Me.Rdb_Rango_Meses_Vta_Promedio.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Rango_Meses_Vta_Promedio.TabIndex = 52
        Me.Rdb_Rango_Meses_Vta_Promedio.Text = "Ventas generadas en los últimos meses"
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.ForeColor = System.Drawing.Color.Black
        Me.LabelX1.Location = New System.Drawing.Point(376, 46)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(39, 19)
        Me.LabelX1.TabIndex = 113
        Me.LabelX1.Text = "Hasta"
        Me.LabelX1.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Chk_Incluir_Salidas_GDI_OT, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Chk_Rotacion_Con_Ent_Excluidas, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Chk_Sumar_Rotacion_Hermanos, 0, 0)
        Me.TableLayoutPanel1.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(9, 124)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(501, 64)
        Me.TableLayoutPanel1.TabIndex = 52
        '
        'Chk_Incluir_Salidas_GDI_OT
        '
        Me.Chk_Incluir_Salidas_GDI_OT.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_Incluir_Salidas_GDI_OT.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Incluir_Salidas_GDI_OT.CheckBoxImageChecked = CType(resources.GetObject("Chk_Incluir_Salidas_GDI_OT.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_Incluir_Salidas_GDI_OT.FocusCuesEnabled = False
        Me.Chk_Incluir_Salidas_GDI_OT.ForeColor = System.Drawing.Color.Black
        Me.Chk_Incluir_Salidas_GDI_OT.Location = New System.Drawing.Point(3, 45)
        Me.Chk_Incluir_Salidas_GDI_OT.Name = "Chk_Incluir_Salidas_GDI_OT"
        Me.Chk_Incluir_Salidas_GDI_OT.Size = New System.Drawing.Size(495, 16)
        Me.Chk_Incluir_Salidas_GDI_OT.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Incluir_Salidas_GDI_OT.TabIndex = 10013
        Me.Chk_Incluir_Salidas_GDI_OT.Text = "Incluir salidas hacia producción para el estudio (GDI hacia ODT)"
        '
        'Chk_Rotacion_Con_Ent_Excluidas
        '
        Me.Chk_Rotacion_Con_Ent_Excluidas.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_Rotacion_Con_Ent_Excluidas.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Rotacion_Con_Ent_Excluidas.CheckBoxImageChecked = CType(resources.GetObject("Chk_Rotacion_Con_Ent_Excluidas.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_Rotacion_Con_Ent_Excluidas.FocusCuesEnabled = False
        Me.Chk_Rotacion_Con_Ent_Excluidas.ForeColor = System.Drawing.Color.Black
        Me.Chk_Rotacion_Con_Ent_Excluidas.Location = New System.Drawing.Point(3, 24)
        Me.Chk_Rotacion_Con_Ent_Excluidas.Name = "Chk_Rotacion_Con_Ent_Excluidas"
        Me.Chk_Rotacion_Con_Ent_Excluidas.Size = New System.Drawing.Size(495, 15)
        Me.Chk_Rotacion_Con_Ent_Excluidas.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Rotacion_Con_Ent_Excluidas.TabIndex = 53
        Me.Chk_Rotacion_Con_Ent_Excluidas.Text = "Rotación incluye ventas a Entidades Excluidas (recomendado solo para importacione" &
    "s)"
        '
        'Chk_Sumar_Rotacion_Hermanos
        '
        Me.Chk_Sumar_Rotacion_Hermanos.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_Sumar_Rotacion_Hermanos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Sumar_Rotacion_Hermanos.CheckBoxImageChecked = CType(resources.GetObject("Chk_Sumar_Rotacion_Hermanos.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_Sumar_Rotacion_Hermanos.FocusCuesEnabled = False
        Me.Chk_Sumar_Rotacion_Hermanos.ForeColor = System.Drawing.Color.Black
        Me.Chk_Sumar_Rotacion_Hermanos.Location = New System.Drawing.Point(3, 3)
        Me.Chk_Sumar_Rotacion_Hermanos.Name = "Chk_Sumar_Rotacion_Hermanos"
        Me.Chk_Sumar_Rotacion_Hermanos.Size = New System.Drawing.Size(495, 15)
        Me.Chk_Sumar_Rotacion_Hermanos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Sumar_Rotacion_Hermanos.TabIndex = 53
        Me.Chk_Sumar_Rotacion_Hermanos.Text = "Sumar rotación de hermanos (agrupar en un solo producto)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'Dtp_Fecha_Vta_Hasta
        '
        Me.Dtp_Fecha_Vta_Hasta.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Dtp_Fecha_Vta_Hasta.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Dtp_Fecha_Vta_Hasta.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Vta_Hasta.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.Dtp_Fecha_Vta_Hasta.ButtonDropDown.Visible = True
        Me.Dtp_Fecha_Vta_Hasta.ForeColor = System.Drawing.Color.Black
        Me.Dtp_Fecha_Vta_Hasta.IsPopupCalendarOpen = False
        Me.Dtp_Fecha_Vta_Hasta.Location = New System.Drawing.Point(421, 43)
        '
        '
        '
        Me.Dtp_Fecha_Vta_Hasta.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_Fecha_Vta_Hasta.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Vta_Hasta.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.Dtp_Fecha_Vta_Hasta.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.Dtp_Fecha_Vta_Hasta.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.Dtp_Fecha_Vta_Hasta.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_Fecha_Vta_Hasta.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.Dtp_Fecha_Vta_Hasta.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Dtp_Fecha_Vta_Hasta.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.Dtp_Fecha_Vta_Hasta.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.Dtp_Fecha_Vta_Hasta.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Vta_Hasta.MonthCalendar.DisplayMonth = New Date(2018, 10, 1, 0, 0, 0, 0)
        Me.Dtp_Fecha_Vta_Hasta.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday
        Me.Dtp_Fecha_Vta_Hasta.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.Dtp_Fecha_Vta_Hasta.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_Fecha_Vta_Hasta.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Dtp_Fecha_Vta_Hasta.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_Fecha_Vta_Hasta.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Dtp_Fecha_Vta_Hasta.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Vta_Hasta.MonthCalendar.TodayButtonVisible = True
        Me.Dtp_Fecha_Vta_Hasta.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.Dtp_Fecha_Vta_Hasta.Name = "Dtp_Fecha_Vta_Hasta"
        Me.Dtp_Fecha_Vta_Hasta.Size = New System.Drawing.Size(80, 22)
        Me.Dtp_Fecha_Vta_Hasta.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Dtp_Fecha_Vta_Hasta.TabIndex = 64
        Me.Dtp_Fecha_Vta_Hasta.Value = New Date(2018, 10, 19, 11, 12, 43, 0)
        '
        'Btn_Bodega_Vta_Estudio
        '
        Me.Btn_Bodega_Vta_Estudio.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Bodega_Vta_Estudio.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Bodega_Vta_Estudio.FocusCuesEnabled = False
        Me.Btn_Bodega_Vta_Estudio.Image = CType(resources.GetObject("Btn_Bodega_Vta_Estudio.Image"), System.Drawing.Image)
        Me.Btn_Bodega_Vta_Estudio.ImageAlt = CType(resources.GetObject("Btn_Bodega_Vta_Estudio.ImageAlt"), System.Drawing.Image)
        Me.Btn_Bodega_Vta_Estudio.Location = New System.Drawing.Point(250, 4)
        Me.Btn_Bodega_Vta_Estudio.Name = "Btn_Bodega_Vta_Estudio"
        Me.Btn_Bodega_Vta_Estudio.Size = New System.Drawing.Size(181, 30)
        Me.Btn_Bodega_Vta_Estudio.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Bodega_Vta_Estudio.TabIndex = 112
        Me.Btn_Bodega_Vta_Estudio.Text = "Bodegas de estudio VENTA"
        '
        'Tab_CalVnta
        '
        Me.Tab_CalVnta.AttachedControl = Me.SuperTabControlPanel1
        Me.Tab_CalVnta.GlobalItem = False
        Me.Tab_CalVnta.Name = "Tab_CalVnta"
        Me.Tab_CalVnta.Text = "Calc. Vta. promedio"
        '
        'SuperTabControlPanel4
        '
        Me.SuperTabControlPanel4.CanvasColor = System.Drawing.Color.Empty
        Me.SuperTabControlPanel4.Controls.Add(Me.Chk_Restar_Stock_TransitoGti)
        Me.SuperTabControlPanel4.Controls.Add(Me.Chk_Restar_Stock_PedidoOcc)
        Me.SuperTabControlPanel4.Controls.Add(Me.Chk_Restar_Stock_PedidoNvi)
        Me.SuperTabControlPanel4.Controls.Add(Me.Btn_Ent_Excluidas)
        Me.SuperTabControlPanel4.Controls.Add(Me.Chk_QuitarProdExcluidos)
        Me.SuperTabControlPanel4.Controls.Add(Me.Btn_ProductosExcluidos)
        Me.SuperTabControlPanel4.Controls.Add(Me.Chk_Mostrar_Solo_Stock_Critico)
        Me.SuperTabControlPanel4.Controls.Add(Me.Chk_No_Considera_Con_Stock_Pedido_OCC_NVI)
        Me.SuperTabControlPanel4.Controls.Add(Me.Chk_Sacar_Productos_Sin_Rotacion)
        Me.SuperTabControlPanel4.Controls.Add(Me.Chk_Restar_Stok_Bodega)
        Me.SuperTabControlPanel4.Controls.Add(Me.Chk_Quitar_Bloqueados_Compra)
        Me.SuperTabControlPanel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel4.Location = New System.Drawing.Point(0, 0)
        Me.SuperTabControlPanel4.Name = "SuperTabControlPanel4"
        Me.SuperTabControlPanel4.Size = New System.Drawing.Size(539, 232)
        Me.SuperTabControlPanel4.TabIndex = 0
        Me.SuperTabControlPanel4.TabItem = Me.Tab_Excluir_Incluir
        '
        'Chk_Restar_Stock_TransitoGti
        '
        Me.Chk_Restar_Stock_TransitoGti.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_Restar_Stock_TransitoGti.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Restar_Stock_TransitoGti.CheckBoxImageChecked = CType(resources.GetObject("Chk_Restar_Stock_TransitoGti.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_Restar_Stock_TransitoGti.FocusCuesEnabled = False
        Me.Chk_Restar_Stock_TransitoGti.ForeColor = System.Drawing.Color.Black
        Me.Chk_Restar_Stock_TransitoGti.Location = New System.Drawing.Point(15, 78)
        Me.Chk_Restar_Stock_TransitoGti.Name = "Chk_Restar_Stock_TransitoGti"
        Me.Chk_Restar_Stock_TransitoGti.Size = New System.Drawing.Size(163, 19)
        Me.Chk_Restar_Stock_TransitoGti.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Restar_Stock_TransitoGti.TabIndex = 120
        Me.Chk_Restar_Stock_TransitoGti.Text = "Restar Stock en transito (GTI)"
        '
        'Chk_Restar_Stock_PedidoOcc
        '
        Me.Chk_Restar_Stock_PedidoOcc.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_Restar_Stock_PedidoOcc.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Restar_Stock_PedidoOcc.CheckBoxImageChecked = CType(resources.GetObject("Chk_Restar_Stock_PedidoOcc.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_Restar_Stock_PedidoOcc.FocusCuesEnabled = False
        Me.Chk_Restar_Stock_PedidoOcc.ForeColor = System.Drawing.Color.Black
        Me.Chk_Restar_Stock_PedidoOcc.Location = New System.Drawing.Point(15, 100)
        Me.Chk_Restar_Stock_PedidoOcc.Name = "Chk_Restar_Stock_PedidoOcc"
        Me.Chk_Restar_Stock_PedidoOcc.Size = New System.Drawing.Size(197, 19)
        Me.Chk_Restar_Stock_PedidoOcc.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Restar_Stock_PedidoOcc.TabIndex = 119
        Me.Chk_Restar_Stock_PedidoOcc.Text = "Restar Stock pedido (OCC)"
        '
        'Chk_Restar_Stock_PedidoNvi
        '
        Me.Chk_Restar_Stock_PedidoNvi.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_Restar_Stock_PedidoNvi.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Restar_Stock_PedidoNvi.CheckBoxImageChecked = CType(resources.GetObject("Chk_Restar_Stock_PedidoNvi.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_Restar_Stock_PedidoNvi.FocusCuesEnabled = False
        Me.Chk_Restar_Stock_PedidoNvi.ForeColor = System.Drawing.Color.Black
        Me.Chk_Restar_Stock_PedidoNvi.Location = New System.Drawing.Point(15, 57)
        Me.Chk_Restar_Stock_PedidoNvi.Name = "Chk_Restar_Stock_PedidoNvi"
        Me.Chk_Restar_Stock_PedidoNvi.Size = New System.Drawing.Size(197, 19)
        Me.Chk_Restar_Stock_PedidoNvi.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Restar_Stock_PedidoNvi.TabIndex = 118
        Me.Chk_Restar_Stock_PedidoNvi.Text = "Restar Stock pedido (NVI)"
        '
        'Btn_Ent_Excluidas
        '
        Me.Btn_Ent_Excluidas.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Ent_Excluidas.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Ent_Excluidas.FocusCuesEnabled = False
        Me.Btn_Ent_Excluidas.Image = CType(resources.GetObject("Btn_Ent_Excluidas.Image"), System.Drawing.Image)
        Me.Btn_Ent_Excluidas.ImageAlt = CType(resources.GetObject("Btn_Ent_Excluidas.ImageAlt"), System.Drawing.Image)
        Me.Btn_Ent_Excluidas.Location = New System.Drawing.Point(346, 82)
        Me.Btn_Ent_Excluidas.Name = "Btn_Ent_Excluidas"
        Me.Btn_Ent_Excluidas.Size = New System.Drawing.Size(179, 30)
        Me.Btn_Ent_Excluidas.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Ent_Excluidas.TabIndex = 113
        Me.Btn_Ent_Excluidas.Text = "Entidades excluidas"
        '
        'Chk_QuitarProdExcluidos
        '
        Me.Chk_QuitarProdExcluidos.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_QuitarProdExcluidos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_QuitarProdExcluidos.CheckBoxImageChecked = CType(resources.GetObject("Chk_QuitarProdExcluidos.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_QuitarProdExcluidos.FocusCuesEnabled = False
        Me.Chk_QuitarProdExcluidos.ForeColor = System.Drawing.Color.Black
        Me.Chk_QuitarProdExcluidos.Location = New System.Drawing.Point(345, 20)
        Me.Chk_QuitarProdExcluidos.Name = "Chk_QuitarProdExcluidos"
        Me.Chk_QuitarProdExcluidos.Size = New System.Drawing.Size(151, 23)
        Me.Chk_QuitarProdExcluidos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_QuitarProdExcluidos.TabIndex = 117
        Me.Chk_QuitarProdExcluidos.Text = "Quitar productos excluidos"
        '
        'Btn_ProductosExcluidos
        '
        Me.Btn_ProductosExcluidos.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_ProductosExcluidos.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_ProductosExcluidos.FocusCuesEnabled = False
        Me.Btn_ProductosExcluidos.Image = CType(resources.GetObject("Btn_ProductosExcluidos.Image"), System.Drawing.Image)
        Me.Btn_ProductosExcluidos.ImageAlt = CType(resources.GetObject("Btn_ProductosExcluidos.ImageAlt"), System.Drawing.Image)
        Me.Btn_ProductosExcluidos.Location = New System.Drawing.Point(345, 45)
        Me.Btn_ProductosExcluidos.Name = "Btn_ProductosExcluidos"
        Me.Btn_ProductosExcluidos.Size = New System.Drawing.Size(180, 29)
        Me.Btn_ProductosExcluidos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_ProductosExcluidos.TabIndex = 116
        Me.Btn_ProductosExcluidos.Text = "Productos excluidos"
        '
        'Chk_Mostrar_Solo_Stock_Critico
        '
        Me.Chk_Mostrar_Solo_Stock_Critico.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_Mostrar_Solo_Stock_Critico.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Mostrar_Solo_Stock_Critico.CheckBoxImageChecked = CType(resources.GetObject("Chk_Mostrar_Solo_Stock_Critico.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_Mostrar_Solo_Stock_Critico.FocusCuesEnabled = False
        Me.Chk_Mostrar_Solo_Stock_Critico.ForeColor = System.Drawing.Color.Black
        Me.Chk_Mostrar_Solo_Stock_Critico.Location = New System.Drawing.Point(15, 152)
        Me.Chk_Mostrar_Solo_Stock_Critico.Name = "Chk_Mostrar_Solo_Stock_Critico"
        Me.Chk_Mostrar_Solo_Stock_Critico.Size = New System.Drawing.Size(139, 20)
        Me.Chk_Mostrar_Solo_Stock_Critico.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Mostrar_Solo_Stock_Critico.TabIndex = 115
        Me.Chk_Mostrar_Solo_Stock_Critico.Text = "Mostrar solo Stock critico"
        '
        'Chk_No_Considera_Con_Stock_Pedido_OCC_NVI
        '
        Me.Chk_No_Considera_Con_Stock_Pedido_OCC_NVI.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_No_Considera_Con_Stock_Pedido_OCC_NVI.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_No_Considera_Con_Stock_Pedido_OCC_NVI.CheckBoxImageChecked = CType(resources.GetObject("Chk_No_Considera_Con_Stock_Pedido_OCC_NVI.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_No_Considera_Con_Stock_Pedido_OCC_NVI.FocusCuesEnabled = False
        Me.Chk_No_Considera_Con_Stock_Pedido_OCC_NVI.ForeColor = System.Drawing.Color.Black
        Me.Chk_No_Considera_Con_Stock_Pedido_OCC_NVI.Location = New System.Drawing.Point(292, 142)
        Me.Chk_No_Considera_Con_Stock_Pedido_OCC_NVI.Name = "Chk_No_Considera_Con_Stock_Pedido_OCC_NVI"
        Me.Chk_No_Considera_Con_Stock_Pedido_OCC_NVI.Size = New System.Drawing.Size(233, 50)
        Me.Chk_No_Considera_Con_Stock_Pedido_OCC_NVI.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_No_Considera_Con_Stock_Pedido_OCC_NVI.TabIndex = 27
        Me.Chk_No_Considera_Con_Stock_Pedido_OCC_NVI.Text = "No considerar productos <br/>" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "con <b>Stock pedido</b>. ( Tiene <b><font color=""#" &
    "ED1C24"">OCC</font></b> o <b><font color=""#ED1C24"">NVI </font></b>)<br/>" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(Para a" &
    "signación de proveedor automático)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'Chk_Sacar_Productos_Sin_Rotacion
        '
        Me.Chk_Sacar_Productos_Sin_Rotacion.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_Sacar_Productos_Sin_Rotacion.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Sacar_Productos_Sin_Rotacion.CheckBoxImageChecked = CType(resources.GetObject("Chk_Sacar_Productos_Sin_Rotacion.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_Sacar_Productos_Sin_Rotacion.FocusCuesEnabled = False
        Me.Chk_Sacar_Productos_Sin_Rotacion.ForeColor = System.Drawing.Color.Black
        Me.Chk_Sacar_Productos_Sin_Rotacion.Location = New System.Drawing.Point(15, 14)
        Me.Chk_Sacar_Productos_Sin_Rotacion.Name = "Chk_Sacar_Productos_Sin_Rotacion"
        Me.Chk_Sacar_Productos_Sin_Rotacion.Size = New System.Drawing.Size(163, 24)
        Me.Chk_Sacar_Productos_Sin_Rotacion.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Sacar_Productos_Sin_Rotacion.TabIndex = 15
        Me.Chk_Sacar_Productos_Sin_Rotacion.Text = "Sacar productos sin rotación"
        '
        'Chk_Restar_Stok_Bodega
        '
        Me.Chk_Restar_Stok_Bodega.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_Restar_Stok_Bodega.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Restar_Stok_Bodega.CheckBoxImageChecked = CType(resources.GetObject("Chk_Restar_Stok_Bodega.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_Restar_Stok_Bodega.FocusCuesEnabled = False
        Me.Chk_Restar_Stok_Bodega.ForeColor = System.Drawing.Color.Black
        Me.Chk_Restar_Stok_Bodega.Location = New System.Drawing.Point(15, 36)
        Me.Chk_Restar_Stok_Bodega.Name = "Chk_Restar_Stok_Bodega"
        Me.Chk_Restar_Stok_Bodega.Size = New System.Drawing.Size(269, 19)
        Me.Chk_Restar_Stok_Bodega.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Restar_Stok_Bodega.TabIndex = 25
        Me.Chk_Restar_Stok_Bodega.Text = "Restar Stock físico de bodega"
        '
        'Chk_Quitar_Bloqueados_Compra
        '
        Me.Chk_Quitar_Bloqueados_Compra.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_Quitar_Bloqueados_Compra.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Quitar_Bloqueados_Compra.CheckBoxImageChecked = CType(resources.GetObject("Chk_Quitar_Bloqueados_Compra.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_Quitar_Bloqueados_Compra.FocusCuesEnabled = False
        Me.Chk_Quitar_Bloqueados_Compra.ForeColor = System.Drawing.Color.Black
        Me.Chk_Quitar_Bloqueados_Compra.Location = New System.Drawing.Point(15, 172)
        Me.Chk_Quitar_Bloqueados_Compra.Name = "Chk_Quitar_Bloqueados_Compra"
        Me.Chk_Quitar_Bloqueados_Compra.Size = New System.Drawing.Size(151, 23)
        Me.Chk_Quitar_Bloqueados_Compra.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Quitar_Bloqueados_Compra.TabIndex = 26
        Me.Chk_Quitar_Bloqueados_Compra.Text = "Quitar bloqueados compra"
        '
        'Tab_Excluir_Incluir
        '
        Me.Tab_Excluir_Incluir.AttachedControl = Me.SuperTabControlPanel4
        Me.Tab_Excluir_Incluir.GlobalItem = False
        Me.Tab_Excluir_Incluir.Name = "Tab_Excluir_Incluir"
        Me.Tab_Excluir_Incluir.Text = "Excluir / Incluir (Opc. dinámicas)"
        '
        'SuperTabControlPanel6
        '
        Me.SuperTabControlPanel6.CanvasColor = System.Drawing.Color.Empty
        Me.SuperTabControlPanel6.Controls.Add(Me.Input_FechaTopeBusquedaProveedores)
        Me.SuperTabControlPanel6.Controls.Add(Me.Dtp_Fecha_Tope_Proveedores_Automaticos)
        Me.SuperTabControlPanel6.Controls.Add(Me.LabelX11)
        Me.SuperTabControlPanel6.Controls.Add(Me.Cmb_Documento_Compra)
        Me.SuperTabControlPanel6.Controls.Add(Me.TableLayoutPanel7)
        Me.SuperTabControlPanel6.Controls.Add(Me.LabelX4)
        Me.SuperTabControlPanel6.Controls.Add(Me.LabelX3)
        Me.SuperTabControlPanel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel6.Location = New System.Drawing.Point(0, 0)
        Me.SuperTabControlPanel6.Name = "SuperTabControlPanel6"
        Me.SuperTabControlPanel6.Size = New System.Drawing.Size(539, 232)
        Me.SuperTabControlPanel6.TabIndex = 0
        Me.SuperTabControlPanel6.TabItem = Me.Tab_Costos_OCC
        '
        'Input_FechaTopeBusquedaProveedores
        '
        Me.Input_FechaTopeBusquedaProveedores.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Input_FechaTopeBusquedaProveedores.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Input_FechaTopeBusquedaProveedores.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Input_FechaTopeBusquedaProveedores.ButtonClear.Visible = True
        Me.Input_FechaTopeBusquedaProveedores.FocusHighlightEnabled = True
        Me.Input_FechaTopeBusquedaProveedores.ForeColor = System.Drawing.Color.Black
        Me.Input_FechaTopeBusquedaProveedores.Location = New System.Drawing.Point(290, 144)
        Me.Input_FechaTopeBusquedaProveedores.MaxValue = 24
        Me.Input_FechaTopeBusquedaProveedores.MinValue = 1
        Me.Input_FechaTopeBusquedaProveedores.Name = "Input_FechaTopeBusquedaProveedores"
        Me.Input_FechaTopeBusquedaProveedores.ShowUpDown = True
        Me.Input_FechaTopeBusquedaProveedores.Size = New System.Drawing.Size(53, 22)
        Me.Input_FechaTopeBusquedaProveedores.TabIndex = 111
        Me.Input_FechaTopeBusquedaProveedores.Value = 3
        '
        'Dtp_Fecha_Tope_Proveedores_Automaticos
        '
        Me.Dtp_Fecha_Tope_Proveedores_Automaticos.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Dtp_Fecha_Tope_Proveedores_Automaticos.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Dtp_Fecha_Tope_Proveedores_Automaticos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Tope_Proveedores_Automaticos.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.Dtp_Fecha_Tope_Proveedores_Automaticos.ButtonDropDown.Visible = True
        Me.Dtp_Fecha_Tope_Proveedores_Automaticos.ForeColor = System.Drawing.Color.Black
        Me.Dtp_Fecha_Tope_Proveedores_Automaticos.IsPopupCalendarOpen = False
        Me.Dtp_Fecha_Tope_Proveedores_Automaticos.Location = New System.Drawing.Point(13, 167)
        '
        '
        '
        Me.Dtp_Fecha_Tope_Proveedores_Automaticos.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_Fecha_Tope_Proveedores_Automaticos.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Tope_Proveedores_Automaticos.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.Dtp_Fecha_Tope_Proveedores_Automaticos.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.Dtp_Fecha_Tope_Proveedores_Automaticos.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.Dtp_Fecha_Tope_Proveedores_Automaticos.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_Fecha_Tope_Proveedores_Automaticos.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.Dtp_Fecha_Tope_Proveedores_Automaticos.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Dtp_Fecha_Tope_Proveedores_Automaticos.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.Dtp_Fecha_Tope_Proveedores_Automaticos.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.Dtp_Fecha_Tope_Proveedores_Automaticos.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Tope_Proveedores_Automaticos.MonthCalendar.DisplayMonth = New Date(2018, 10, 1, 0, 0, 0, 0)
        Me.Dtp_Fecha_Tope_Proveedores_Automaticos.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday
        Me.Dtp_Fecha_Tope_Proveedores_Automaticos.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.Dtp_Fecha_Tope_Proveedores_Automaticos.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_Fecha_Tope_Proveedores_Automaticos.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Dtp_Fecha_Tope_Proveedores_Automaticos.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_Fecha_Tope_Proveedores_Automaticos.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Dtp_Fecha_Tope_Proveedores_Automaticos.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Tope_Proveedores_Automaticos.MonthCalendar.TodayButtonVisible = True
        Me.Dtp_Fecha_Tope_Proveedores_Automaticos.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.Dtp_Fecha_Tope_Proveedores_Automaticos.Name = "Dtp_Fecha_Tope_Proveedores_Automaticos"
        Me.Dtp_Fecha_Tope_Proveedores_Automaticos.Size = New System.Drawing.Size(80, 22)
        Me.Dtp_Fecha_Tope_Proveedores_Automaticos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Dtp_Fecha_Tope_Proveedores_Automaticos.TabIndex = 66
        Me.Dtp_Fecha_Tope_Proveedores_Automaticos.Value = New Date(2018, 10, 19, 11, 12, 43, 0)
        Me.Dtp_Fecha_Tope_Proveedores_Automaticos.Visible = False
        '
        'LabelX11
        '
        Me.LabelX11.AutoSize = True
        Me.LabelX11.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX11.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX11.ForeColor = System.Drawing.Color.Black
        Me.LabelX11.Location = New System.Drawing.Point(13, 144)
        Me.LabelX11.Name = "LabelX11"
        Me.LabelX11.Size = New System.Drawing.Size(271, 17)
        Me.LabelX11.TabIndex = 52
        Me.LabelX11.Text = "Meses fecha tope de busqueda de compra a proveedor"
        '
        'Cmb_Documento_Compra
        '
        Me.Cmb_Documento_Compra.DisplayMember = "Text"
        Me.Cmb_Documento_Compra.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.Cmb_Documento_Compra.ForeColor = System.Drawing.Color.Black
        Me.Cmb_Documento_Compra.FormattingEnabled = True
        Me.Cmb_Documento_Compra.ItemHeight = 16
        Me.Cmb_Documento_Compra.Location = New System.Drawing.Point(12, 69)
        Me.Cmb_Documento_Compra.Name = "Cmb_Documento_Compra"
        Me.Cmb_Documento_Compra.Size = New System.Drawing.Size(221, 22)
        Me.Cmb_Documento_Compra.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Cmb_Documento_Compra.TabIndex = 53
        '
        'TableLayoutPanel7
        '
        Me.TableLayoutPanel7.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel7.ColumnCount = 4
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.266409!))
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32.23938!))
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.02657!))
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.79696!))
        Me.TableLayoutPanel7.Controls.Add(Me.Rd_Costo_Lista_Proveedor, 2, 0)
        Me.TableLayoutPanel7.Controls.Add(Me.Rd_Costo_Ultimo_Documento_Seleccionado, 1, 0)
        Me.TableLayoutPanel7.Controls.Add(Me.LabelX8, 0, 0)
        Me.TableLayoutPanel7.Controls.Add(Me.Cmb_Lista_de_costos, 3, 0)
        Me.TableLayoutPanel7.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel7.Location = New System.Drawing.Point(9, 15)
        Me.TableLayoutPanel7.Name = "TableLayoutPanel7"
        Me.TableLayoutPanel7.RowCount = 1
        Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel7.Size = New System.Drawing.Size(527, 26)
        Me.TableLayoutPanel7.TabIndex = 50
        '
        'Rd_Costo_Lista_Proveedor
        '
        '
        '
        '
        Me.Rd_Costo_Lista_Proveedor.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rd_Costo_Lista_Proveedor.CheckBoxImageChecked = CType(resources.GetObject("Rd_Costo_Lista_Proveedor.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Rd_Costo_Lista_Proveedor.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rd_Costo_Lista_Proveedor.FocusCuesEnabled = False
        Me.Rd_Costo_Lista_Proveedor.ForeColor = System.Drawing.Color.Black
        Me.Rd_Costo_Lista_Proveedor.Location = New System.Drawing.Point(220, 3)
        Me.Rd_Costo_Lista_Proveedor.Name = "Rd_Costo_Lista_Proveedor"
        Me.Rd_Costo_Lista_Proveedor.Size = New System.Drawing.Size(88, 20)
        Me.Rd_Costo_Lista_Proveedor.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rd_Costo_Lista_Proveedor.TabIndex = 55
        Me.Rd_Costo_Lista_Proveedor.Text = "Desde L.Costos"
        '
        'Rd_Costo_Ultimo_Documento_Seleccionado
        '
        '
        '
        '
        Me.Rd_Costo_Ultimo_Documento_Seleccionado.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rd_Costo_Ultimo_Documento_Seleccionado.CheckBoxImageChecked = CType(resources.GetObject("Rd_Costo_Ultimo_Documento_Seleccionado.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Rd_Costo_Ultimo_Documento_Seleccionado.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rd_Costo_Ultimo_Documento_Seleccionado.Checked = True
        Me.Rd_Costo_Ultimo_Documento_Seleccionado.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Rd_Costo_Ultimo_Documento_Seleccionado.CheckValue = "Y"
        Me.Rd_Costo_Ultimo_Documento_Seleccionado.FocusCuesEnabled = False
        Me.Rd_Costo_Ultimo_Documento_Seleccionado.ForeColor = System.Drawing.Color.Black
        Me.Rd_Costo_Ultimo_Documento_Seleccionado.Location = New System.Drawing.Point(51, 3)
        Me.Rd_Costo_Ultimo_Documento_Seleccionado.Name = "Rd_Costo_Ultimo_Documento_Seleccionado"
        Me.Rd_Costo_Ultimo_Documento_Seleccionado.Size = New System.Drawing.Size(162, 20)
        Me.Rd_Costo_Ultimo_Documento_Seleccionado.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rd_Costo_Ultimo_Documento_Seleccionado.TabIndex = 56
        Me.Rd_Costo_Ultimo_Documento_Seleccionado.Text = "Desde la última GRC/OCC/FCC"
        '
        'LabelX8
        '
        Me.LabelX8.AutoSize = True
        '
        '
        '
        Me.LabelX8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX8.ForeColor = System.Drawing.Color.Black
        Me.LabelX8.Location = New System.Drawing.Point(3, 3)
        Me.LabelX8.Name = "LabelX8"
        Me.LabelX8.Size = New System.Drawing.Size(41, 17)
        Me.LabelX8.TabIndex = 51
        Me.LabelX8.Text = "<b>Costos :</b>"
        '
        'Cmb_Lista_de_costos
        '
        Me.Cmb_Lista_de_costos.DisplayMember = "Text"
        Me.Cmb_Lista_de_costos.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.Cmb_Lista_de_costos.ForeColor = System.Drawing.Color.Black
        Me.Cmb_Lista_de_costos.FormattingEnabled = True
        Me.Cmb_Lista_de_costos.ItemHeight = 16
        Me.Cmb_Lista_de_costos.Location = New System.Drawing.Point(314, 3)
        Me.Cmb_Lista_de_costos.Name = "Cmb_Lista_de_costos"
        Me.Cmb_Lista_de_costos.Size = New System.Drawing.Size(210, 22)
        Me.Cmb_Lista_de_costos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Cmb_Lista_de_costos.TabIndex = 67
        '
        'LabelX4
        '
        Me.LabelX4.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.ForeColor = System.Drawing.Color.Black
        Me.LabelX4.Location = New System.Drawing.Point(12, 97)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(506, 32)
        Me.LabelX4.TabIndex = 52
        Me.LabelX4.Text = "<b>Fecha tope de búsqueda del precio mínimo según proveedor con el mejor precio." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Si no encuentra guías, traerá la última compra recepcionada del producto.</b>" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) &
    ""
        '
        'LabelX3
        '
        Me.LabelX3.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.ForeColor = System.Drawing.Color.Black
        Me.LabelX3.Location = New System.Drawing.Point(12, 47)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(135, 23)
        Me.LabelX3.TabIndex = 54
        Me.LabelX3.Text = "Documento seleccionado:"
        '
        'Tab_Costos_OCC
        '
        Me.Tab_Costos_OCC.AttachedControl = Me.SuperTabControlPanel6
        Me.Tab_Costos_OCC.GlobalItem = False
        Me.Tab_Costos_OCC.Name = "Tab_Costos_OCC"
        Me.Tab_Costos_OCC.Text = "Costos para OCC"
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel3.ColumnCount = 2
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 42.01183!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 57.98817!))
        Me.TableLayoutPanel3.Controls.Add(Me.Rdb_RotMeses, 1, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.Rdb_RotDias, 0, 0)
        Me.TableLayoutPanel3.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(703, 120)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 1
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(169, 21)
        Me.TableLayoutPanel3.TabIndex = 114
        Me.TableLayoutPanel3.Visible = False
        '
        'Rdb_RotMeses
        '
        '
        '
        '
        Me.Rdb_RotMeses.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_RotMeses.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_RotMeses.Checked = True
        Me.Rdb_RotMeses.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Rdb_RotMeses.CheckValue = "Y"
        Me.Rdb_RotMeses.ForeColor = System.Drawing.Color.Black
        Me.Rdb_RotMeses.Location = New System.Drawing.Point(73, 3)
        Me.Rdb_RotMeses.Name = "Rdb_RotMeses"
        Me.Rdb_RotMeses.Size = New System.Drawing.Size(93, 15)
        Me.Rdb_RotMeses.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_RotMeses.TabIndex = 115
        Me.Rdb_RotMeses.Text = "Rot. Meses"
        '
        'Rdb_RotDias
        '
        '
        '
        '
        Me.Rdb_RotDias.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_RotDias.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_RotDias.ForeColor = System.Drawing.Color.Black
        Me.Rdb_RotDias.Location = New System.Drawing.Point(3, 3)
        Me.Rdb_RotDias.Name = "Rdb_RotDias"
        Me.Rdb_RotDias.Size = New System.Drawing.Size(64, 15)
        Me.Rdb_RotDias.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_RotDias.TabIndex = 114
        Me.Rdb_RotDias.Text = "Rot. Días"
        '
        'Grupo_Productos
        '
        Me.Grupo_Productos.BackColor = System.Drawing.Color.White
        Me.Grupo_Productos.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Grupo_Productos.Controls.Add(Me.Btn_Filtrar_ProdProveedor)
        Me.Grupo_Productos.Controls.Add(Me.Chk_Solo_Proveedores_CodAlternativo)
        Me.Grupo_Productos.Controls.Add(Me.Txt_Proveedor)
        Me.Grupo_Productos.Controls.Add(Me.Cmb_Tipo_de_compra)
        Me.Grupo_Productos.Controls.Add(Me.LabelX5)
        Me.Grupo_Productos.Controls.Add(Me.TableLayoutPanel6)
        Me.Grupo_Productos.Controls.Add(Me.Layout_Producto)
        Me.Grupo_Productos.Controls.Add(Me.Btn_Buscar_Proveedor)
        Me.Grupo_Productos.Controls.Add(Me.Chk_Traer_Productos_De_Reemplazo)
        Me.Grupo_Productos.Controls.Add(Me.Chk_Ent_Fisica)
        Me.Grupo_Productos.DisabledBackColor = System.Drawing.Color.Empty
        Me.Grupo_Productos.Location = New System.Drawing.Point(14, 12)
        Me.Grupo_Productos.Name = "Grupo_Productos"
        Me.Grupo_Productos.Size = New System.Drawing.Size(539, 304)
        '
        '
        '
        Me.Grupo_Productos.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Grupo_Productos.Style.BackColorGradientAngle = 90
        Me.Grupo_Productos.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Grupo_Productos.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Productos.Style.BorderBottomWidth = 1
        Me.Grupo_Productos.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.Grupo_Productos.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Productos.Style.BorderLeftWidth = 1
        Me.Grupo_Productos.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Productos.Style.BorderRightWidth = 1
        Me.Grupo_Productos.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Productos.Style.BorderTopWidth = 1
        Me.Grupo_Productos.Style.CornerDiameter = 4
        Me.Grupo_Productos.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Grupo_Productos.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.Grupo_Productos.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.Grupo_Productos.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.Grupo_Productos.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.Grupo_Productos.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Grupo_Productos.TabIndex = 50
        Me.Grupo_Productos.Text = "Selección de productos"
        '
        'Btn_Filtrar_ProdProveedor
        '
        Me.Btn_Filtrar_ProdProveedor.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Filtrar_ProdProveedor.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Filtrar_ProdProveedor.FocusCuesEnabled = False
        Me.Btn_Filtrar_ProdProveedor.Image = CType(resources.GetObject("Btn_Filtrar_ProdProveedor.Image"), System.Drawing.Image)
        Me.Btn_Filtrar_ProdProveedor.ImageAlt = CType(resources.GetObject("Btn_Filtrar_ProdProveedor.ImageAlt"), System.Drawing.Image)
        Me.Btn_Filtrar_ProdProveedor.Location = New System.Drawing.Point(417, 220)
        Me.Btn_Filtrar_ProdProveedor.Name = "Btn_Filtrar_ProdProveedor"
        Me.Btn_Filtrar_ProdProveedor.Size = New System.Drawing.Size(96, 22)
        Me.Btn_Filtrar_ProdProveedor.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Filtrar_ProdProveedor.TabIndex = 10014
        Me.Btn_Filtrar_ProdProveedor.Text = "Buscar prod."
        Me.Btn_Filtrar_ProdProveedor.Tooltip = "Filtrar solo algunos productos del proveedor"
        '
        'Chk_Solo_Proveedores_CodAlternativo
        '
        Me.Chk_Solo_Proveedores_CodAlternativo.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_Solo_Proveedores_CodAlternativo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Solo_Proveedores_CodAlternativo.CheckBoxImageChecked = CType(resources.GetObject("Chk_Solo_Proveedores_CodAlternativo.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_Solo_Proveedores_CodAlternativo.FocusCuesEnabled = False
        Me.Chk_Solo_Proveedores_CodAlternativo.ForeColor = System.Drawing.Color.Black
        Me.Chk_Solo_Proveedores_CodAlternativo.Location = New System.Drawing.Point(274, 192)
        Me.Chk_Solo_Proveedores_CodAlternativo.Name = "Chk_Solo_Proveedores_CodAlternativo"
        Me.Chk_Solo_Proveedores_CodAlternativo.Size = New System.Drawing.Size(241, 23)
        Me.Chk_Solo_Proveedores_CodAlternativo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Solo_Proveedores_CodAlternativo.TabIndex = 10013
        Me.Chk_Solo_Proveedores_CodAlternativo.Text = "Traer solo proveedores con código alternativo"
        '
        'Cmb_Tipo_de_compra
        '
        Me.Cmb_Tipo_de_compra.DisplayMember = "Text"
        Me.Cmb_Tipo_de_compra.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.Cmb_Tipo_de_compra.ForeColor = System.Drawing.Color.Black
        Me.Cmb_Tipo_de_compra.FormattingEnabled = True
        Me.Cmb_Tipo_de_compra.ItemHeight = 16
        Me.Cmb_Tipo_de_compra.Location = New System.Drawing.Point(94, 249)
        Me.Cmb_Tipo_de_compra.Name = "Cmb_Tipo_de_compra"
        Me.Cmb_Tipo_de_compra.Size = New System.Drawing.Size(167, 22)
        Me.Cmb_Tipo_de_compra.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Cmb_Tipo_de_compra.TabIndex = 10012
        '
        'LabelX5
        '
        Me.LabelX5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelX5.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX5.ForeColor = System.Drawing.Color.Black
        Me.LabelX5.Location = New System.Drawing.Point(1, 248)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.SingleLineColor = System.Drawing.Color.Transparent
        Me.LabelX5.Size = New System.Drawing.Size(87, 23)
        Me.LabelX5.TabIndex = 10011
        Me.LabelX5.Text = "Tipo de compra"
        '
        'Btn_Buscar_Proveedor
        '
        Me.Btn_Buscar_Proveedor.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Buscar_Proveedor.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Buscar_Proveedor.Image = CType(resources.GetObject("Btn_Buscar_Proveedor.Image"), System.Drawing.Image)
        Me.Btn_Buscar_Proveedor.ImageAlt = CType(resources.GetObject("Btn_Buscar_Proveedor.ImageAlt"), System.Drawing.Image)
        Me.Btn_Buscar_Proveedor.Location = New System.Drawing.Point(3, 221)
        Me.Btn_Buscar_Proveedor.Name = "Btn_Buscar_Proveedor"
        Me.Btn_Buscar_Proveedor.Size = New System.Drawing.Size(46, 21)
        Me.Btn_Buscar_Proveedor.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Buscar_Proveedor.TabIndex = 9
        Me.Btn_Buscar_Proveedor.Tooltip = "Buscar proveedor"
        '
        'Chk_Traer_Productos_De_Reemplazo
        '
        Me.Chk_Traer_Productos_De_Reemplazo.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_Traer_Productos_De_Reemplazo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Traer_Productos_De_Reemplazo.CheckBoxImageChecked = CType(resources.GetObject("Chk_Traer_Productos_De_Reemplazo.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_Traer_Productos_De_Reemplazo.Checked = True
        Me.Chk_Traer_Productos_De_Reemplazo.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Chk_Traer_Productos_De_Reemplazo.CheckValue = "Y"
        Me.Chk_Traer_Productos_De_Reemplazo.FocusCuesEnabled = False
        Me.Chk_Traer_Productos_De_Reemplazo.ForeColor = System.Drawing.Color.Black
        Me.Chk_Traer_Productos_De_Reemplazo.Location = New System.Drawing.Point(3, 192)
        Me.Chk_Traer_Productos_De_Reemplazo.Name = "Chk_Traer_Productos_De_Reemplazo"
        Me.Chk_Traer_Productos_De_Reemplazo.Size = New System.Drawing.Size(170, 23)
        Me.Chk_Traer_Productos_De_Reemplazo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Traer_Productos_De_Reemplazo.TabIndex = 24
        Me.Chk_Traer_Productos_De_Reemplazo.Text = "Traer productos de reemplazo"
        '
        'Chk_Ent_Fisica
        '
        Me.Chk_Ent_Fisica.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_Ent_Fisica.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Ent_Fisica.CheckBoxImageChecked = CType(resources.GetObject("Chk_Ent_Fisica.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_Ent_Fisica.FocusCuesEnabled = False
        Me.Chk_Ent_Fisica.ForeColor = System.Drawing.Color.Black
        Me.Chk_Ent_Fisica.Location = New System.Drawing.Point(272, 248)
        Me.Chk_Ent_Fisica.Name = "Chk_Ent_Fisica"
        Me.Chk_Ent_Fisica.Size = New System.Drawing.Size(241, 23)
        Me.Chk_Ent_Fisica.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Ent_Fisica.TabIndex = 50
        Me.Chk_Ent_Fisica.Text = "considerar proveedor(es) como entidad física"
        '
        'Chk_Incluir_Servicios
        '
        Me.Chk_Incluir_Servicios.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_Incluir_Servicios.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Incluir_Servicios.Enabled = False
        Me.Chk_Incluir_Servicios.ForeColor = System.Drawing.Color.Black
        Me.Chk_Incluir_Servicios.Location = New System.Drawing.Point(702, 89)
        Me.Chk_Incluir_Servicios.Name = "Chk_Incluir_Servicios"
        Me.Chk_Incluir_Servicios.Size = New System.Drawing.Size(170, 23)
        Me.Chk_Incluir_Servicios.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Incluir_Servicios.TabIndex = 51
        Me.Chk_Incluir_Servicios.Text = "Incluir servicios"
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
        Me.MetroStatusBar1.Location = New System.Drawing.Point(0, 621)
        Me.MetroStatusBar1.Name = "MetroStatusBar1"
        Me.MetroStatusBar1.Size = New System.Drawing.Size(564, 22)
        Me.MetroStatusBar1.TabIndex = 52
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
        'Timer_Ejecucion_Automatica
        '
        Me.Timer_Ejecucion_Automatica.Interval = 2000
        '
        'Chk_Sumar_Vta_Ult_Year
        '
        Me.Chk_Sumar_Vta_Ult_Year.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_Sumar_Vta_Ult_Year.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Sumar_Vta_Ult_Year.CheckBoxImageChecked = CType(resources.GetObject("Chk_Sumar_Vta_Ult_Year.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_Sumar_Vta_Ult_Year.Enabled = False
        Me.Chk_Sumar_Vta_Ult_Year.FocusCuesEnabled = False
        Me.Chk_Sumar_Vta_Ult_Year.ForeColor = System.Drawing.Color.Black
        Me.Chk_Sumar_Vta_Ult_Year.Location = New System.Drawing.Point(14, 560)
        Me.Chk_Sumar_Vta_Ult_Year.Name = "Chk_Sumar_Vta_Ult_Year"
        Me.Chk_Sumar_Vta_Ult_Year.Size = New System.Drawing.Size(353, 22)
        Me.Chk_Sumar_Vta_Ult_Year.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Sumar_Vta_Ult_Year.TabIndex = 115
        Me.Chk_Sumar_Vta_Ult_Year.Text = "Actualizar datos de ultimas ventas en un año BLV y FCV"
        Me.Chk_Sumar_Vta_Ult_Year.Visible = False
        '
        'ButtonItem3
        '
        Me.ButtonItem3.Image = CType(resources.GetObject("ButtonItem3.Image"), System.Drawing.Image)
        Me.ButtonItem3.Name = "ButtonItem3"
        Me.ButtonItem3.Text = "Bodegas"
        '
        'ButtonItem4
        '
        Me.ButtonItem4.Image = CType(resources.GetObject("ButtonItem4.Image"), System.Drawing.Image)
        Me.ButtonItem4.Name = "ButtonItem4"
        Me.ButtonItem4.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.BtnFiltroMarca, Me.ButtonItem5, Me.ButtonItem6, Me.ButtonItem7, Me.ButtonItem8})
        Me.ButtonItem4.Text = "Filtrar productos"
        '
        'BtnFiltroMarca
        '
        Me.BtnFiltroMarca.Name = "BtnFiltroMarca"
        Me.BtnFiltroMarca.Text = "Marca"
        '
        'ButtonItem5
        '
        Me.ButtonItem5.Name = "ButtonItem5"
        Me.ButtonItem5.Text = "Clasificación libre"
        '
        'ButtonItem6
        '
        Me.ButtonItem6.Name = "ButtonItem6"
        Me.ButtonItem6.Text = "Rubro"
        '
        'ButtonItem7
        '
        Me.ButtonItem7.Name = "ButtonItem7"
        Me.ButtonItem7.Text = "Zona"
        '
        'ButtonItem8
        '
        Me.ButtonItem8.Name = "ButtonItem8"
        Me.ButtonItem8.Text = "Super familia"
        '
        'ButtonItem9
        '
        Me.ButtonItem9.Image = CType(resources.GetObject("ButtonItem9.Image"), System.Drawing.Image)
        Me.ButtonItem9.Name = "ButtonItem9"
        Me.ButtonItem9.Text = "Entidades excluidas"
        '
        'Chk_NoEnviarCorreosAProveedores
        '
        Me.Chk_NoEnviarCorreosAProveedores.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_NoEnviarCorreosAProveedores.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_NoEnviarCorreosAProveedores.CheckBoxImageChecked = CType(resources.GetObject("Chk_NoEnviarCorreosAProveedores.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_NoEnviarCorreosAProveedores.Checked = True
        Me.Chk_NoEnviarCorreosAProveedores.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Chk_NoEnviarCorreosAProveedores.CheckValue = "Y"
        Me.Chk_NoEnviarCorreosAProveedores.FocusCuesEnabled = False
        Me.Chk_NoEnviarCorreosAProveedores.ForeColor = System.Drawing.Color.Black
        Me.Chk_NoEnviarCorreosAProveedores.Location = New System.Drawing.Point(106, 94)
        Me.Chk_NoEnviarCorreosAProveedores.Name = "Chk_NoEnviarCorreosAProveedores"
        Me.Chk_NoEnviarCorreosAProveedores.Size = New System.Drawing.Size(217, 23)
        Me.Chk_NoEnviarCorreosAProveedores.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_NoEnviarCorreosAProveedores.TabIndex = 10026
        Me.Chk_NoEnviarCorreosAProveedores.Text = "No enviar los correos a los proveedores"
        '
        'Frm_00_Asis_Compra_Menu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(564, 643)
        Me.Controls.Add(Me.Chk_Sumar_Vta_Ult_Year)
        Me.Controls.Add(Me.TableLayoutPanel3)
        Me.Controls.Add(Me.Chk_Incluir_Servicios)
        Me.Controls.Add(Me.Grupo_Productos)
        Me.Controls.Add(Me.STabConfiguracion)
        Me.Controls.Add(Me.Bar)
        Me.Controls.Add(Me.MetroStatusBar1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.HelpButton = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_00_Asis_Compra_Menu"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Asistente de compra según rotación de venta"
        CType(Me.Bar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel6.ResumeLayout(False)
        Me.Layout_Producto.ResumeLayout(False)
        CType(Me.Dtp_Fecha_Movimientos_Hasta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Dtp_Fecha_Movimientos_Desde, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Input_Productos_Ranking, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.STabConfiguracion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.STabConfiguracion.ResumeLayout(False)
        Me.SuperTabControlPanel3.ResumeLayout(False)
        Me.Layaut_UlProdXProv.ResumeLayout(False)
        Me.Layaut_UlProdXProv.PerformLayout()
        CType(Me.Input_MesesCP, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Input_UltDocumentosCP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel8.ResumeLayout(False)
        Me.TableLayoutPanel8.PerformLayout()
        Me.TableLayoutPanel5.ResumeLayout(False)
        Me.TableLayoutPanel5.PerformLayout()
        CType(Me.Input_Dias_a_Abastecer, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Input_Tiempo_Reposicion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SuperTabControlPanel8.ResumeLayout(False)
        CType(Me.SuperTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SuperTabControl1.ResumeLayout(False)
        Me.SuperTabControlPanel9.ResumeLayout(False)
        Me.GroupPanel1.ResumeLayout(False)
        Me.SuperTabControlPanel10.ResumeLayout(False)
        Me.GroupPanel2.ResumeLayout(False)
        Me.SuperTabControlPanel2.ResumeLayout(False)
        Me.Grupo_DbExt.ResumeLayout(False)
        Me.SuperTabControlPanel5.ResumeLayout(False)
        CType(Me.Input_Dias_Advertencia_Rotacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SuperTabControlPanel7.ResumeLayout(False)
        Me.SuperTabControlPanel7.PerformLayout()
        Me.SuperTabControlPanel1.ResumeLayout(False)
        CType(Me.Dtp_Fecha_Vta_Desde, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Input_Ultimos_Meses_Vta_Promedio, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel4.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.Dtp_Fecha_Vta_Hasta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SuperTabControlPanel4.ResumeLayout(False)
        Me.SuperTabControlPanel6.ResumeLayout(False)
        Me.SuperTabControlPanel6.PerformLayout()
        CType(Me.Input_FechaTopeBusquedaProveedores, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Dtp_Fecha_Tope_Proveedores_Automaticos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel7.ResumeLayout(False)
        Me.TableLayoutPanel7.PerformLayout()
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.Grupo_Productos.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Bar As DevComponents.DotNetBar.Bar
    Friend WithEvents Txt_Proveedor As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Btn_Buscar_Proveedor As DevComponents.DotNetBar.ButtonX
    Friend WithEvents BtnProcesarInf As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Chk_Sacar_Productos_Sin_Rotacion As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Dtp_Fecha_Vta_Desde_Estacional As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Dtp_Fecha_Estacional_Hasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Chk_Domingo As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Chk_Sabado As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents ControlContainerItem1 As DevComponents.DotNetBar.ControlContainerItem
    Friend WithEvents Chk_Restar_Stok_Bodega As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Chk_Quitar_Bloqueados_Compra As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents ButtonItem3 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem4 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents BtnFiltroMarca As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem5 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem6 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem7 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem8 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem9 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Cmb_Cantidad_Dias_Ultima_Venta As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents Chk_No_Considera_Con_Stock_Pedido_OCC_NVI As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents BtnSeleccionarProductos As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Chk_Traer_Productos_De_Reemplazo As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents STabConfiguracion As DevComponents.DotNetBar.SuperTabControl
    Friend WithEvents SuperTabControlPanel6 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents Tab_Costos_OCC As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents SuperTabControlPanel3 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents Tab_Indicadores As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents Layout_Producto As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel6 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Chk_Ent_Fisica As DevComponents.DotNetBar.Controls.CheckBoxX
    Private WithEvents Input_Productos_Ranking As DevComponents.Editors.IntegerInput
    Friend WithEvents TableLayoutPanel5 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents LabelX6 As DevComponents.DotNetBar.LabelX
    Friend WithEvents SuperTabControlPanel7 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents SuperTabItem7 As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents LabelX7 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Chk_Cargar_Rotacion_Estacional As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents TableLayoutPanel7 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents LabelX8 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX10 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX9 As DevComponents.DotNetBar.LabelX
    Friend WithEvents SuperTabControlPanel4 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents Tab_Excluir_Incluir As DevComponents.DotNetBar.SuperTabItem
    Private WithEvents Input_Dias_a_Abastecer As DevComponents.Editors.IntegerInput
    Private WithEvents Input_Tiempo_Reposicion As DevComponents.Editors.IntegerInput
    Friend WithEvents LabelX11 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TableLayoutPanel8 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents SuperTabControlPanel5 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents SuperTabItem5 As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents ReflectionImage1 As DevComponents.DotNetBar.Controls.ReflectionImage
    Friend WithEvents Chk_Advertir_Rotacion As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents LabelX12 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX13 As DevComponents.DotNetBar.LabelX
    Private WithEvents Input_Dias_Advertencia_Rotacion As DevComponents.Editors.IntegerInput
    Friend WithEvents Grupo_Productos As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Chk_Incluir_Servicios As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Cmb_Tiempo_Reposicion_Dias_Meses As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents Cmb_Metodo_Abastecer_Dias_Meses As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents SuperTabControlPanel1 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents Tab_CalVnta As DevComponents.DotNetBar.SuperTabItem
    Private WithEvents Input_Ultimos_Meses_Vta_Promedio As DevComponents.Editors.IntegerInput
    Friend WithEvents Btn_Bodega_Vta_Estudio As DevComponents.DotNetBar.ButtonX
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Chk_Rotacion_Con_Ent_Excluidas As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Chk_Sumar_Rotacion_Hermanos As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Rdb_Rango_Meses_Vta_Promedio As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Btn_Ent_Excluidas As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Btn_Seleccionar_Productos_X_Clasificacion_RD As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Rdb_Productos_Vendidos_Los_Ultimos_Dias As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_Productos_Todos As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_Productos_Proveedor As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_Productos_Ranking As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_Productos_Familias_Marcas_Etc As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_Productos_Seleccionar As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_Productos_Con_Movimientos_De_Venta As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Dtp_Fecha_Movimientos_Hasta As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents Dtp_Fecha_Movimientos_Desde As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents Dtp_Fecha_Vta_Desde As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents Dtp_Fecha_Vta_Hasta As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents Rdb_Ud2_Compra As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_Ud1_Compra As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rd_Costo_Ultimo_Documento_Seleccionado As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Lbl_Desde As DevComponents.DotNetBar.LabelX
    Friend WithEvents Lbl_Hasta As DevComponents.DotNetBar.LabelX
    Friend WithEvents Dtp_Fecha_Tope_Proveedores_Automaticos As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents Rd_Costo_Lista_Proveedor As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Btn_Bodegas_Stock As DevComponents.DotNetBar.ButtonX
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Chk_Mostrar_Solo_Stock_Critico As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_Rango_Fechas_Vta_Promedio As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Cmb_Tipo_de_compra As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Cmb_Documento_Compra As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents MetroStatusBar1 As DevComponents.DotNetBar.Metro.MetroStatusBar
    Friend WithEvents Lbl_Status As DevComponents.DotNetBar.LabelItem
    Friend WithEvents Barra_Progreso As DevComponents.DotNetBar.ProgressBarItem
    Friend WithEvents Chk_Procesar_Uno_A_Uno As DevComponents.DotNetBar.CheckBoxItem
    Friend WithEvents Cmb_Lista_de_costos As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents Btn_Imprimir_Maestra As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Chk_Solo_Proveedores_CodAlternativo As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Btn_Filtrar_ProdProveedor As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Rdb_RotMeses As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_RotDias As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents TableLayoutPanel3 As TableLayoutPanel
    Friend WithEvents LabelX14 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TableLayoutPanel4 As TableLayoutPanel
    Friend WithEvents Rdb_Rot_Promedio As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_Rot_Mediana As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Btn_Cancelar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Circular_Progress1 As DevComponents.DotNetBar.CircularProgressItem
    Friend WithEvents Timer_Ejecucion_Automatica As Timer
    Friend WithEvents Layaut_UlProdXProv As TableLayoutPanel
    Friend WithEvents LabelX15 As DevComponents.DotNetBar.LabelX
    Private WithEvents Input_MesesCP As DevComponents.Editors.IntegerInput
    Friend WithEvents LabelX16 As DevComponents.DotNetBar.LabelX
    Private WithEvents Input_UltDocumentosCP As DevComponents.Editors.IntegerInput
    Friend WithEvents Chk_IncluirUltCXprov As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Line1 As DevComponents.DotNetBar.Controls.Line
    Friend WithEvents Chk_Incluir_Salidas_GDI_OT As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents HelpProvider1 As HelpProvider
    Friend WithEvents Chk_Sumar_Vta_Ult_Year As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents SuperTabControlPanel2 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents LabelX17 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Btn_Buscar_ProvEspecial As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Txt_ProvEspecial As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Tab_ConexionExterna As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents LabelX18 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Txt_DbExt_Nombre_Conexion As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Txt_DbExt_NombreBod_Des As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX20 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Txt_DbExt_NombreBod_Ori As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX19 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Chk_DbExt_SincronizarPRBD As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Grupo_DbExt As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents SuperTabControlPanel8 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Tab_Automatizacion As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents Txt_CtaCorreoEnvioAutomatizado_OCC As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Txt_CorreoCc_OCC As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX22 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX21 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Txt_NombreFormato_PDF_OCC As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX23 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Btn_Bodega_NVI_Estudio As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Btn_GrabarConfiguracion As DevComponents.DotNetBar.ButtonItem
    Private WithEvents Input_FechaTopeBusquedaProveedores As DevComponents.Editors.IntegerInput
    Friend WithEvents SuperTabControl1 As DevComponents.DotNetBar.SuperTabControl
    Friend WithEvents SuperTabControlPanel9 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents SubTabConfAuto_OCC As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents SuperTabControlPanel10 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents GroupPanel2 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents LabelX25 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Txt_NombreFormato_PDF_NVI As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Txt_CorreoCc_NVI As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Txt_CtaCorreoEnvioAutomatizado_NVI As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX27 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX28 As DevComponents.DotNetBar.LabelX
    Friend WithEvents SubTabConfAuto_NVI As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents Chk_SumerStockExternoAlFisico As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Chk_QuitarProdExcluidos As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Btn_ProductosExcluidos As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Chk_Restar_Stock_PedidoNvi As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Chk_Restar_Stock_PedidoOcc As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Chk_Restar_Stock_TransitoGti As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents LabelX26 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX24 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Chk_NoEnviarCorreosAProveedores As DevComponents.DotNetBar.Controls.CheckBoxX
End Class
