Imports System.Data.SqlClient
Imports DevComponents.DotNetBar

Public Class Frm_01_Asis_Compra_Resultados

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Nombre_Tbl_Paso_Informe As String

    Dim _Proceso_Automatico_Ejecutado As Boolean
    Dim _Tbl_Informe As DataTable

    Dim _Fecha_Productos_Sin_Rotacion As Date

    Dim _RowProveedor As DataRow
    Dim _Con_Proveedor_Desde_Estudio As Boolean

    Dim _Directorio_Informe = (AppPath() & "\Data\" & RutEmpresa & "\Asistente_Compras")
    Dim _RowParametros As DataRow

    Dim _Rdb_Productos_Proveedor As Boolean

    Dim Fr_Alerta_Stock As DevComponents.DotNetBar.Balloon

    Dim _Tbl_Filtro_Super_Familias As DataTable
    Dim _Tbl_Filtro_Marcas As DataTable
    Dim _Tbl_Filtro_Rubro As DataTable
    Dim _Tbl_Filtro_Clalibpr As DataTable

    Dim _Tbl_Filtro_Zonas As DataTable

    Dim _TblBodCompra As DataTable
    Dim _TblBodVenta As DataTable

    Dim _Filtro_Marcas_Todas As Boolean
    Dim _Filtro_Super_Familias_Todas As Boolean
    Dim _Filtro_Rubro_Todas As Boolean
    Dim _Filtro_Clalibpr_Todas As Boolean
    Dim _Filtro_Zonas_Todas As Boolean

    Dim _Filtro_Bodegas_Todas As Boolean

    Dim _Codigo_Rev_Ventas As String

    Dim _Cmb_Padre_Asociacion_Productos As String

    Dim _Dias_A_Abastecer As Integer
    Dim _Tiempo_De_Reposicion_Dias As Integer

    Dim _Ds As DataSet
    Dim _Dv, _Dv2 As New DataView


    Dim _Clas_Asistente_Compras As Clas_Asistente_Compras
    Dim _Nodo_Raiz_Asociados As Integer = _Global_Row_Configuracion_General.Item("Nodo_Raiz_Asociados")
    Dim Fm_Hijo As New Frm_01_Asis_Compra_Resultados_Hijo

    Dim _Codigo_Seleccionado As String
    Dim _Ud As Integer
    Dim _NombreEquipo As String = _Global_Row_EstacionBk.Item("NombreEquipo")
    Dim _Rdb_RotDias As Boolean
    Dim _Rdb_RotMeses As Boolean

    Dim _Accion_Automatica As Boolean
    Dim _Modo_NVI As Boolean
    Dim _Modo_OCC As Boolean

    Dim _Modalidad_Estudio As String

    Public Property Accion_Automatica As Boolean
        Get
            Return _Accion_Automatica
        End Get
        Set(value As Boolean)
            _Accion_Automatica = value
        End Set
    End Property

    Public Property Auto_GenerarAutomaticamenteOCCProveedorStar As Boolean
    Public Property Auto_GenerarAutomaticamenteNVI As Boolean
    Public Property Auto_GenerarAutomaticamenteOCCProveedores As Boolean
    Public Property Auto_CorreoCc As String
    Public Property Auto_Id_Correo As String
    Public Property Auto_NombreFormato_PDF As String

    Public Property Pro_Tbl_Filtro_Super_Familias() As DataTable
        Get
            Return _Tbl_Filtro_Super_Familias
        End Get
        Set(ByVal value As DataTable)
            _Tbl_Filtro_Super_Familias = value
        End Set
    End Property
    Public Property Pro_Tbl_Filtro_Marcas() As DataTable
        Get
            Return _Tbl_Filtro_Marcas
        End Get
        Set(ByVal value As DataTable)
            _Tbl_Filtro_Marcas = value
        End Set
    End Property
    Public Property Pro_Tbl_Filtro_Rubro() As DataTable
        Get
            Return _Tbl_Filtro_Rubro
        End Get
        Set(ByVal value As DataTable)
            _Tbl_Filtro_Rubro = value
        End Set
    End Property
    Public Property Pro_Tbl_Filtro_Clalibpr() As DataTable
        Get
            Return _Tbl_Filtro_Clalibpr
        End Get
        Set(ByVal value As DataTable)
            _Tbl_Filtro_Clalibpr = value
        End Set
    End Property
    Public Property Pro_Tbl_Filtro_Zonas() As DataTable
        Get
            Return _Tbl_Filtro_Zonas
        End Get
        Set(ByVal value As DataTable)
            _Tbl_Filtro_Zonas = value
        End Set
    End Property
    Public Property Pro_TblBodCompra() As DataTable
        Get
            Return _TblBodCompra
        End Get
        Set(ByVal value As DataTable)
            _TblBodCompra = value
        End Set
    End Property
    Public Property Pro_Filtro_Marcas_Todas() As Boolean
        Get
            Return _Filtro_Marcas_Todas
        End Get
        Set(ByVal value As Boolean)
            _Filtro_Marcas_Todas = value
        End Set
    End Property
    Public Property Pro_Filtro_Super_Familias_Todas() As Boolean
        Get
            Return _Filtro_Super_Familias_Todas
        End Get
        Set(ByVal value As Boolean)
            _Filtro_Super_Familias_Todas = value
        End Set
    End Property
    Public Property Pro_Filtro_Rubro_Todas() As Boolean
        Get
            Return _Filtro_Rubro_Todas
        End Get
        Set(ByVal value As Boolean)
            _Filtro_Rubro_Todas = value
        End Set
    End Property
    Public Property Pro_Filtro_Clalibpr_Todas() As Boolean
        Get
            Return _Filtro_Clalibpr_Todas
        End Get
        Set(ByVal value As Boolean)
            _Filtro_Clalibpr_Todas = value
        End Set
    End Property
    Public Property Pro_Filtro_Zonas_Todas() As Boolean
        Get
            Return _Filtro_Zonas_Todas
        End Get
        Set(ByVal value As Boolean)
            _Filtro_Zonas_Todas = value
        End Set
    End Property
    Public Property Pro_RowParametros() As DataRow
        Get
            Return _RowParametros
        End Get
        Set(ByVal value As DataRow)
            _RowParametros = value
            Sb_Parametros_Revisar()
        End Set
    End Property
    Public Property Pro_Nombre_Tbl_Paso_Informe() As String
        Get
            Return _Nombre_Tbl_Paso_Informe
        End Get
        Set(ByVal value As String)
            _Nombre_Tbl_Paso_Informe = value
        End Set
    End Property

    Public Property Ud As Integer
        Get
            If Rdb_Ud1_Compra.Checked Then : _Ud = 1 : Else : _Ud = 2 : End If
            Return _Ud
        End Get
        Set(value As Integer)
            _Ud = value
        End Set
    End Property

    Public Property Modo_NVI As Boolean
        Get
            Return _Modo_NVI
        End Get
        Set(value As Boolean)
            _Modo_NVI = value
        End Set
    End Property

    Public Property Modo_OCC As Boolean
        Get
            Return _Modo_OCC
        End Get
        Set(value As Boolean)
            _Modo_OCC = value
        End Set
    End Property

    Public Sub New(_Modalidad_Estudio As String)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        Me._Modalidad_Estudio = _Modalidad_Estudio

        Sb_Cargar_Combos()

        BackgroundWorker_Est_Venta_X_Producto.WorkerReportsProgress = True
        BackgroundWorker_Est_Venta_X_Producto.WorkerSupportsCancellation = True

        With My.Settings

            .Asis_Compra_Campo_Orden = "Codigo"
            .Asis_Compra_Campo_Orden_Orden = "Ascending"
            .Save()

        End With

        Dim _Color As Color = Color.Black

        If Global_Thema = Enum_Themas.Oscuro Then
            _Color = Color.White
        End If

        For Each _Objeto As Object In Me.RibbonControl1.Items
            If (TypeOf _Objeto Is ButtonItem) Then
                CType(_Objeto, ButtonItem).ForeColor = _Color
            End If
        Next

        _Modo_OCC = True

    End Sub

    Sub Sb_Cargar_Combos()

        Dim _Arr_Dias_Meses(,) As String = {{"1", "días"},
                                           {"30", "meses"}}
        Sb_Llenar_Combos(_Arr_Dias_Meses, Cmb_Metodo_Abastecer_Dias_Meses)
        Cmb_Metodo_Abastecer_Dias_Meses.SelectedValue = "1"

        Sb_Llenar_Combos(_Arr_Dias_Meses, Cmb_Tiempo_Reposicion_Dias_Meses)
        Cmb_Tiempo_Reposicion_Dias_Meses.SelectedValue = "1"

        Dim _Arr_Tipo_Compra(,) As String = {{"Nacional", "Nacional 1"},
                                             {"Nacional2", "Nacional 2"},
                                             {"Exterior", "Comercio exterior"}}
        Sb_Llenar_Combos(_Arr_Tipo_Compra, Fm_Hijo.Cmb_Tipo_de_compra)
        Fm_Hijo.Cmb_Tipo_de_compra.SelectedValue = "Nacional"

        Dim _Arr_Filtro(,) As String = {{"C", "Contiene:"},
                                      {"E", "Empieza por:"},
                                      {"T", "Termina en:"}}
        Sb_Llenar_Combos(_Arr_Filtro, Fm_Hijo.Cmb_Filtro_Codigo)
        Fm_Hijo.Cmb_Filtro_Codigo.SelectedValue = "C"

        Dim _Arr_Tipo_Documento(,) As String = {{"GRC", "Guía recepción compra (GRC)"},
                                            {"OCC", "Orden de compra (OCC)"},
                                            {"FCC", "Factura de compra (FCC)"}}
        Sb_Llenar_Combos(_Arr_Tipo_Documento, Fm_Hijo.Cmb_Documento_Compra)
        Fm_Hijo.Cmb_Documento_Compra.SelectedValue = "GRC"

        Consulta_sql = "Select '' As Padre,'' As Hijo Union Select KOLT As Padre,KOLT+'-'+NOKOLT As Hijo From TABPP Where TILT = 'C'"
        Dim _Tbl_LCosto As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        Consulta_sql = "Select Top 1 * From " & _Global_BaseBk & "Zw_Tmp_Prm_Informes
                        Where Funcionario = '" & FUNCIONARIO & "' And Informe = 'Compras_Asistente' And Campo = 'Cmb_Lista_de_costos' " &
                        "And NombreEquipo = '" & _NombreEquipo & "' And Modalidad = '" & _Modalidad_Estudio & "'"
        Dim _Row_Prm As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        Dim _Lista = String.Empty

        If Not IsNothing(_Row_Prm) Then
            _Lista = _Row_Prm.Item("Valor")
        End If

        For Each _Fl As DataRow In _Tbl_LCosto.Rows

            Dim _Cmb_Item = New DevComponents.Editors.ComboItem

            _Cmb_Item.Value = _Fl.Item("Padre")
            _Cmb_Item.Text = _Fl.Item("Hijo")

            If Global_Thema = Enum_Themas.Oscuro Then
                _Cmb_Item.ForeColor = Color.White
            End If

            Cmb_Lista_Costos.Items.AddRange(New Object() {_Cmb_Item})

            If _Cmb_Item.Value = _Lista Then Cmb_Lista_Costos.SelectedItem = _Cmb_Item

        Next

    End Sub

    Private Sub Frm_01_AsisCompra_Resultados_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Sb_Parametros_Informe_Sql(False)

        _Rdb_Productos_Proveedor = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Tmp_Prm_Informes", "Valor",
                                                                    "Funcionario = '" & FUNCIONARIO & "'" & Space(1) &
                                                                    "And Campo = 'Rdb_Productos_Proveedor'" & Space(1) &
                                                                    "And Informe = 'Compras_Asistente' And Modalidad = '" & _Modalidad_Estudio & "'", , , , True)

        Fm_Hijo.WindowState = FormWindowState.Maximized
        Fm_Hijo.MdiParent = Me
        Fm_Hijo.Show()

        _Rdb_RotDias = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Tmp_Prm_Informes", "Valor",
                                                                    "Funcionario = '" & FUNCIONARIO & "'" & Space(1) &
                                                                    "And Campo = 'Rdb_RotDias'" & Space(1) &
                                                                    "And Informe = 'Compras_Asistente' And Modalidad = '" & _Modalidad_Estudio & "'", , , , True)
        _Rdb_RotMeses = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Tmp_Prm_Informes", "Valor",
                                                                    "Funcionario = '" & FUNCIONARIO & "'" & Space(1) &
                                                                    "And Campo = 'Rdb_RotMeses'" & Space(1) &
                                                                    "And Informe = 'Compras_Asistente' And Modalidad = '" & _Modalidad_Estudio & "'", , , , True)

        _Rdb_RotDias = False
        _Rdb_RotMeses = True

        If Global_Thema = Enum_Themas.Oscuro Then

            Input_Dias_a_Abastecer.ForeColor = Color.White
            Cmb_Metodo_Abastecer_Dias_Meses.ForeColor = Color.White
            Input_Tiempo_Reposicion.ForeColor = Color.White
            Cmb_Tiempo_Reposicion_Dias_Meses.ForeColor = Color.White
            Input_Porc_Crecimiento.ForeColor = Color.White
            Fm_Hijo.Txt_Codigo.FocusHighlightEnabled = False
            Fm_Hijo.Txt_Descripcion.FocusHighlightEnabled = False
            Fm_Hijo.Txt_Proveedor.FocusHighlightEnabled = False

        End If

        _Clas_Asistente_Compras = New Clas_Asistente_Compras(_Nombre_Tbl_Paso_Informe)

        Consulta_sql = "IF EXISTS (SELECT * FROM sysobjects WHERE name='Zw_Tbl_PasoOCC" & FUNCIONARIO & "') BEGIN " &
                       "DROP TABLE Zw_Tbl_PasoOCC" & FUNCIONARIO & " End"
        _Sql.Ej_consulta_IDU(Consulta_sql, False)

        AddHandler Fm_Hijo.Grilla.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint
        AddHandler Fm_Hijo.Grilla.ColumnHeaderMouseClick, AddressOf Grilla_ColumnHeaderMouseClick
        AddHandler Fm_Hijo.Grill_Mensual.CellEnter, AddressOf GrillaMensual_CellEnter

        AddHandler Fm_Hijo.Btn_Filtrar_Proveedor.Click, AddressOf Btn_Filtrar_Proveedor_Click
        AddHandler Fm_Hijo.Btn_Quitar_Filtro_Proveedor.Click, AddressOf Btn_Quitar_Filtro_Proveedor_Click

        AddHandler Fm_Hijo.STab_Ventas.Click, AddressOf STab_Ventas_Compras_Click
        AddHandler Fm_Hijo.STab_Compras.Click, AddressOf STab_Ventas_Compras_Click

        Sb_Refrescar_Grilla_Principal(Fm_Hijo.Grilla, True, True)

        AddHandler Rb_Proveedores.Click, AddressOf Sb_Rb_Boton_Click
        AddHandler Rb_Herramientas.Click, AddressOf Sb_Rb_Boton_Click
        AddHandler Rb_Opcion_Indicadores.Click, AddressOf Sb_Rb_Boton_Click
        AddHandler Rb_Calculo_Cantidad.Click, AddressOf Sb_Rb_Boton_Click
        AddHandler Fm_Hijo.Txt_Codigo.KeyDown, AddressOf Txt_Codigo_KeyDown
        AddHandler Fm_Hijo.Txt_Descripcion.KeyDown, AddressOf Txt_Descripcion_KeyDown
        AddHandler Fm_Hijo.Chk_Ver_Doc_Solo_Proveedor.Click, AddressOf Sb_Actualizar_Grilla_Mensual
        AddHandler Fm_Hijo.Grilla.DataError, AddressOf Grilla_DataError

        _Con_Proveedor_Desde_Estudio = Not (_RowProveedor Is Nothing)

        BtnProceso_Prov_Auto.Enabled = Not _Con_Proveedor_Desde_Estudio
        Fm_Hijo.Btn_Filtrar_Proveedor.Enabled = Not _Con_Proveedor_Desde_Estudio
        Btn_Filtrar_Proveedor_Ribon.Enabled = Not _Con_Proveedor_Desde_Estudio
        Chk_Traer_Solo_Proveedores_Relacion_Con_El_Producto.Enabled = Not _Con_Proveedor_Desde_Estudio
        Chk_Solo_Proveedores_CodAlternativo.Enabled = Not _Con_Proveedor_Desde_Estudio
        Chk_Ent_Fisica.Enabled = Not _Con_Proveedor_Desde_Estudio

        BtnImprimirListado.Visible = Not (_RowProveedor Is Nothing)

        Fr_Alerta_Stock = New AlertCustom("", 1)

        If _Accion_Automatica Then
            Timer_Ejecucion_Automatica.Start()
        End If

        Btn_Crear_Orden_Asistente.Enabled = Modo_OCC
        Btn_Reabastecimiento_x_NVI.Visible = Modo_NVI

        If Modo_OCC Then Me.Text += " (MODO OCC)"
        If Modo_NVI Then Me.Text += " (MODO NVI)"

        Fm_Hijo.Modo_OCC = _Modo_OCC

        ItemContainer5.Enabled = _Modo_OCC
        ItemContainer11.Enabled = _Modo_OCC
        ItemContainer12.Enabled = _Modo_OCC
        Btn_PorcUltCompXProv.Enabled = _Modo_OCC
        Rb_Calculo_Cantidad.Enabled = _Modo_OCC
        Btn_Proyeccion_Mensual.Enabled = _Modo_OCC
        Rd_Costo_Ultimo_Documento_Seleccionado.Enabled = _Modo_OCC
        Rd_Costo_Lista_Proveedor.Enabled = _Modo_OCC
        Cmb_Lista_Costos.Enabled = _Modo_OCC

        If Modo_NVI Then
            BtnProceso_Prov_Auto_Especial.Enabled = False
        End If

    End Sub

    Private Sub Frm_01_AsisCompra_Resultados_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed

        If Not Accion_Automatica Then
            Sb_Parametros_Informe_Sql(True)
            If Fr_Alerta_Stock.Visible Then
                Fr_Alerta_Stock.Close()
            End If
        End If

    End Sub

    Sub LlenarGrilla()

        Consulta_sql = My.Resources.Recursos_Asis_Compras.SQLQuery_Inserta_stock_por_producto
        Consulta_sql = Replace(Consulta_sql, "#TablaPaso#", _Nombre_Tbl_Paso_Informe)
        Consulta_sql = Replace(Consulta_sql, "#CodFuncionario#", FUNCIONARIO)

        _Sql.Ej_consulta_IDU(Consulta_sql)

    End Sub

    Sub Sb_Formato_Grilla_Compras_Nacionales(Grilla As DataGridView)

        With Grilla

            Dim _DisplayIndex = 0

            OcultarEncabezadoGrilla(Grilla)

            .Columns("Comprar").Frozen = True
            .Columns("Comprar").Width = 25
            .Columns("Comprar").HeaderText = "C?"
            .Columns("Comprar").ToolTipText = "¿Comprar?"
            .Columns("Comprar").Visible = True
            .Columns("Comprar").ReadOnly = False
            .Columns("Comprar").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Codigo").Frozen = True
            .Columns("Codigo").Width = 100
            .Columns("Codigo").HeaderText = "Código"
            .Columns("Codigo").ReadOnly = True
            .Columns("Codigo").Visible = True
            .Columns("Codigo").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("CodAlternativo").Frozen = True
            .Columns("CodAlternativo").Width = 110
            'If (_RowProveedor Is Nothing) Then
            .Columns("CodAlternativo").HeaderText = "Cód. Alternativo"
            'Else
            '.Columns("CodAlternativo").HeaderText = "Cód. Proveedor"
            'End If
            .Columns("CodAlternativo").ReadOnly = True
            '.Columns("CodAlternativo").Visible = Not (_RowProveedor Is Nothing)
            .Columns("CodAlternativo").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Descripcion").Frozen = True
            .Columns("Descripcion").Width = 300
            .Columns("Descripcion").HeaderText = "Descripción"
            .Columns("Descripcion").ReadOnly = True
            .Columns("Descripcion").Visible = True
            .Columns("Descripcion").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("UD" & Ud).Width = 30
            .Columns("UD" & Ud).HeaderText = "Ud" & Ud
            .Columns("UD" & Ud).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("UD" & Ud).ToolTipText = "Unidad " & Ud
            .Columns("UD" & Ud).ReadOnly = True
            .Columns("UD" & Ud).Visible = True
            .Columns("UD" & Ud).DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Rtu").Width = 30
            .Columns("Rtu").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Rtu").ReadOnly = True
            .Columns("Rtu").Visible = True
            .Columns("Rtu").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Stock_Fisico_Ud" & Ud).Width = 45
            .Columns("Stock_Fisico_Ud" & Ud).HeaderText = "Stock actual"
            .Columns("Stock_Fisico_Ud" & Ud).DefaultCellStyle.Format = "##,###0.##"
            .Columns("Stock_Fisico_Ud" & Ud).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Stock_Fisico_Ud" & Ud).ToolTipText = "Stock consolidado según bodegas seleccionadas"
            .Columns("Stock_Fisico_Ud" & Ud).ReadOnly = True
            .Columns("Stock_Fisico_Ud" & Ud).Visible = True
            .Columns("Stock_Fisico_Ud" & Ud).DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            If Not Chk_No_Considera_Con_Stock_Pedido_OCC_NVI.Checked Then

                .Columns("StockPedidoUd" & Ud).Width = 45
                .Columns("StockPedidoUd" & Ud).HeaderText = "Stock pedido"
                .Columns("StockPedidoUd" & Ud).DefaultCellStyle.Format = "##,###0.##"
                .Columns("StockPedidoUd" & Ud).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns("StockPedidoUd" & Ud).ToolTipText = "Stock consolidado según bodegas seleccionadas"
                .Columns("StockPedidoUd" & Ud).ReadOnly = True
                .Columns("StockPedidoUd" & Ud).Visible = True
                .Columns("StockPedidoUd" & Ud).DisplayIndex = _DisplayIndex
                _DisplayIndex += 1

            End If

            .Columns("Stock_CriticoUd" & Ud & "_Rd").Width = 45
            .Columns("Stock_CriticoUd" & Ud & "_Rd").HeaderText = "Stock Critico"
            .Columns("Stock_CriticoUd" & Ud & "_Rd").DefaultCellStyle.Format = "##,###0.##"
            .Columns("Stock_CriticoUd" & Ud & "_Rd").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Stock_CriticoUd" & Ud & "_Rd").ToolTipText = "Cantidad mínima de productos para sostener el tiempo de reposición EC = (TS*RT)"
            .Columns("Stock_CriticoUd" & Ud & "_Rd").ReadOnly = True
            .Columns("Stock_CriticoUd" & Ud & "_Rd").Visible = True
            .Columns("Stock_CriticoUd" & Ud & "_Rd").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            Dim _Tex As String = Cmb_Metodo_Abastecer_Dias_Meses.Text
            Dim _L As String = Mid(_Tex, 1, 1)
            _Tex = UCase(_L) & Mid(_Tex, 2, _Tex.Length - 1)

            .Columns("TStock").Width = 40
            .Columns("TStock").HeaderText = _Tex & " S.A"
            .Columns("TStock").DefaultCellStyle.Format = "##,###0.##"
            .Columns("TStock").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("TStock").ToolTipText = _Tex & " de stock asegurado. Días que restan para que se termine el stock Diario"
            .Columns("TStock").ReadOnly = True
            .Columns("TStock").Visible = True
            .Columns("TStock").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("CantComprar").Width = 50
            .Columns("CantComprar").HeaderText = "Cant."
            .Columns("CantComprar").ToolTipText = "Cantidad a comprar"
            .Columns("CantComprar").DefaultCellStyle.Format = "##,###0.##"
            .Columns("CantComprar").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("CantComprar").Visible = True
            .Columns("CantComprar").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            Dim _Br_Nt = "Neto"

            If Rdb_Valores_Brutos.Checked Then
                _Br_Nt = "Bruto"
            End If

            Dim _Formato_Costo = "##,###0.##"

            _Formato_Costo = "##,###0"

            .Columns("Costo_Ud1Lista_" & _Br_Nt).Width = 50
            .Columns("Costo_Ud1Lista_" & _Br_Nt).HeaderText = "Costo Ud1"
            .Columns("Costo_Ud1Lista_" & _Br_Nt).ToolTipText = "Costo " & _Br_Nt & " Unidad 1"
            .Columns("Costo_Ud1Lista_" & _Br_Nt).DefaultCellStyle.Format = _Formato_Costo
            .Columns("Costo_Ud1Lista_" & _Br_Nt).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Costo_Ud1Lista_" & _Br_Nt).Visible = True
            .Columns("Costo_Ud1Lista_" & _Br_Nt).DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("DiasdeAvas_Rd").Width = 40
            .Columns("DiasdeAvas_Rd").HeaderText = "Alc."
            .Columns("DiasdeAvas_Rd").ToolTipText = "Alcanza para " & Cmb_Metodo_Abastecer_Dias_Meses.Text & ". " & vbCrLf &
                                                    "Días que cubre la compra según rotación diaria (una vez que hayan llegado los productos a bodega)"
            .Columns("DiasdeAvas_Rd").DefaultCellStyle.Format = "##,###0.##"
            .Columns("DiasdeAvas_Rd").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("DiasdeAvas_Rd").Visible = True
            .Columns("DiasdeAvas_Rd").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("CantSugeridaTot").Width = 40
            .Columns("CantSugeridaTot").HeaderText = "C.Sug"
            .Columns("CantSugeridaTot").DefaultCellStyle.Format = "##,###0.##"
            .Columns("CantSugeridaTot").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("CantSugeridaTot").ToolTipText = "Cantidad sugeridad a comprar según velocidad de venta (Rotación)"
            .Columns("CantSugeridaTot").Visible = True
            .Columns("CantSugeridaTot").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            Dim _Campo_CalUd_Diario As String
            Dim _Campo_CalUd_Mensual As String

            If Rdb_Rot_Mediana.Checked Then
                _Campo_CalUd_Diario = "RotDiariaUd"
                _Campo_CalUd_Mensual = "RotMensualUd"
            End If

            If Rdb_Rot_Promedio.Checked Then
                _Campo_CalUd_Diario = "Promedio_Ud"
                _Campo_CalUd_Mensual = "Promedio_MensualUd"
            End If

            If Cmb_Metodo_Abastecer_Dias_Meses.SelectedValue = 1 Then

                .Columns(_Campo_CalUd_Diario & Ud).Width = 50
                .Columns(_Campo_CalUd_Diario & Ud).HeaderText = "R.V.D"
                .Columns(_Campo_CalUd_Diario & Ud).DefaultCellStyle.Format = "##,###0.###"
                .Columns(_Campo_CalUd_Diario & Ud).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(_Campo_CalUd_Diario & Ud).ToolTipText = "Velocidad de venta media diaria (Rotación)"
                .Columns(_Campo_CalUd_Diario & Ud).Visible = True
                .Columns(_Campo_CalUd_Diario & Ud).DisplayIndex = _DisplayIndex
                _DisplayIndex += 1

            Else

                .Columns(_Campo_CalUd_Mensual & Ud).Width = 50
                .Columns(_Campo_CalUd_Mensual & Ud).HeaderText = "R.V.M"
                .Columns(_Campo_CalUd_Mensual & Ud).DefaultCellStyle.Format = "##,###0.##"
                .Columns(_Campo_CalUd_Mensual & Ud).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(_Campo_CalUd_Mensual & Ud).ToolTipText = "Velocidad de venta media mensual (Rotación)"
                .Columns(_Campo_CalUd_Mensual & Ud).Visible = True
                .Columns(_Campo_CalUd_Mensual & Ud).DisplayIndex = _DisplayIndex
                _DisplayIndex += 1

            End If

            .Columns("OccGenerada").Width = 35
            .Columns("OccGenerada").HeaderText = "OCC Gen"
            .Columns("OccGenerada").ToolTipText = "Tiene orden de compra generada desde este tratamiento"
            .Columns("OccGenerada").Visible = True
            .Columns("OccGenerada").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Fecha_Ult_Venta").HeaderText = "F.Ult.Venta"
            .Columns("Fecha_Ult_Venta").Width = 70
            .Columns("Fecha_Ult_Venta").DefaultCellStyle.Format = "dd/MM/yyyy"
            .Columns("Fecha_Ult_Venta").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Fecha_Ult_Venta").Visible = True
            .Columns("Fecha_Ult_Venta").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("StockUd" & Ud).Width = 70
            .Columns("StockUd" & Ud).HeaderText = "Stock en " &
                                                   Input_Tiempo_Reposicion.Value & " " &
                                                   Cmb_Tiempo_Reposicion_Dias_Meses.Text '& " Ud. " & Ud
            .Columns("StockUd" & Ud).DefaultCellStyle.Format = "##,###0.##"
            .Columns("StockUd" & Ud).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("StockUd" & Ud).ToolTipText = "Stock consolidado según bodegas seleccionadas"
            .Columns("StockUd" & Ud).ReadOnly = True
            .Columns("StockUd" & Ud).Visible = Chk_Trabajando_Con_Proyeccion.Checked
            .Columns("StockUd" & Ud).DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Clasificacion_Rk").Width = 100
            .Columns("Clasificacion_Rk").HeaderText = "Clas. Ranking"
            .Columns("Clasificacion_Rk").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .Columns("Clasificacion_Rk").ToolTipText = "Campo denominado para la clasificación se mejores productos de la empresa según Ranking"
            .Columns("Clasificacion_Rk").ReadOnly = True
            .Columns("Clasificacion_Rk").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Ranking_Top").Width = 50
            .Columns("Ranking_Top").HeaderText = "Ranking"
            .Columns("Ranking_Top").ToolTipText = "Posición del producto en el Ranking"
            .Columns("Ranking_Top").DefaultCellStyle.Format = "##,###"
            .Columns("Ranking_Top").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Ranking_Top").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            If False Then
                If Not _Proceso_Automatico_Ejecutado Then
                    .Columns("Ranking_Top").Visible = True
                    .Columns("Clasificacion_Rk").Visible = True
                Else
                    .Columns("Ranking_Top").Visible = False
                    .Columns("Clasificacion_Rk").Visible = False
                End If
            End If

            '' Creamos un nuevo estilo de celda
            ''
            'Dim cellStyle As New DataGridViewCellStyle

            'cellStyle.Font = New Font(Grilla.Font.Name, Grilla.Font.Size, FontStyle.Bold)
            'Grilla.Columns("CantSugeridaTot").DefaultCellStyle = cellStyle

            .Refresh()

        End With

    End Sub

    Sub Sb_Formato_Grilla_Compras_Nacionales2(Grilla As DataGridView)

        With Grilla

            Dim _DisplayIndex = 0

            OcultarEncabezadoGrilla(Grilla)

            .Columns("Comprar").Frozen = True
            .Columns("Comprar").Width = 25
            .Columns("Comprar").HeaderText = "C?"
            .Columns("Comprar").ToolTipText = "¿Comprar?"
            .Columns("Comprar").Visible = True
            .Columns("Comprar").ReadOnly = False
            .Columns("Comprar").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Codigo").Frozen = True
            .Columns("Codigo").Width = 100
            .Columns("Codigo").HeaderText = "Código"
            .Columns("Codigo").ReadOnly = True
            .Columns("Codigo").Visible = True
            .Columns("Codigo").DisplayIndex = _DisplayIndex
            .Columns("Codigo").SortMode = DataGridViewColumnSortMode.Automatic
            _DisplayIndex += 1

            .Columns("Descripcion").Frozen = True
            .Columns("Descripcion").Width = 300
            .Columns("Descripcion").HeaderText = "Descripción"
            .Columns("Descripcion").ReadOnly = True
            .Columns("Descripcion").Visible = True
            .Columns("Descripcion").DisplayIndex = _DisplayIndex
            .Columns("Descripcion").SortMode = DataGridViewColumnSortMode.Automatic
            _DisplayIndex += 1

            .Columns("Rtu").Width = 30
            .Columns("Rtu").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Rtu").ReadOnly = True
            .Columns("Rtu").Visible = True
            .Columns("Rtu").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("UD" & Ud).Width = 30
            .Columns("UD" & Ud).HeaderText = "Ud" & Ud
            .Columns("UD" & Ud).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("UD" & Ud).ToolTipText = "Unidad " & Ud
            .Columns("UD" & Ud).ReadOnly = True
            .Columns("UD" & Ud).Visible = True
            .Columns("UD" & Ud).DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Stock_Fisico_Ud" & Ud).Width = 45
            .Columns("Stock_Fisico_Ud" & Ud).HeaderText = "Stock actual"
            .Columns("Stock_Fisico_Ud" & Ud).DefaultCellStyle.Format = "##,###0.##"
            .Columns("Stock_Fisico_Ud" & Ud).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Stock_Fisico_Ud" & Ud).ToolTipText = "Stock consolidado según bodegas seleccionadas"
            .Columns("Stock_Fisico_Ud" & Ud).ReadOnly = True
            .Columns("Stock_Fisico_Ud" & Ud).Visible = True
            .Columns("Stock_Fisico_Ud" & Ud).DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            If Not Chk_No_Considera_Con_Stock_Pedido_OCC_NVI.Checked Then

                .Columns("StockPedidoUd" & Ud).Width = 45
                .Columns("StockPedidoUd" & Ud).HeaderText = "Stock pedido"
                .Columns("StockPedidoUd" & Ud).DefaultCellStyle.Format = "##,###0.##"
                .Columns("StockPedidoUd" & Ud).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns("StockPedidoUd" & Ud).ToolTipText = "Stock consolidado según bodegas seleccionadas"
                .Columns("StockPedidoUd" & Ud).ReadOnly = True
                .Columns("StockPedidoUd" & Ud).Visible = True
                .Columns("StockPedidoUd" & Ud).DisplayIndex = _DisplayIndex
                _DisplayIndex += 1

            End If

            .Columns("CantSugeridaTot").Width = 40
            .Columns("CantSugeridaTot").HeaderText = "C.Sug"
            .Columns("CantSugeridaTot").DefaultCellStyle.Format = "##,###0.##"
            .Columns("CantSugeridaTot").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("CantSugeridaTot").ToolTipText = "Cantidad sugeridad a comprar según velocidad de venta (Rotación)"
            .Columns("CantSugeridaTot").Visible = True
            .Columns("CantSugeridaTot").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("CantComprar").Width = 50
            .Columns("CantComprar").HeaderText = "Cant."
            .Columns("CantComprar").ToolTipText = "Cantidad a comprar"
            .Columns("CantComprar").DefaultCellStyle.Format = "##,###0.##"
            .Columns("CantComprar").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("CantComprar").Visible = True
            .Columns("CantComprar").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("DiasdeAvas_Rd").Width = 40
            .Columns("DiasdeAvas_Rd").HeaderText = "Alc."
            .Columns("DiasdeAvas_Rd").ToolTipText = "Alcanza para " & Cmb_Metodo_Abastecer_Dias_Meses.Text & ". " & vbCrLf &
                                                    "Días que cubre la compra según rotación diaria (una vez que hayan llegado los productos a bodega)"
            .Columns("DiasdeAvas_Rd").DefaultCellStyle.Format = "##,###0.##"
            .Columns("DiasdeAvas_Rd").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("DiasdeAvas_Rd").Visible = True
            .Columns("DiasdeAvas_Rd").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            Dim _Br_Nt = "Neto"
            If Rdb_Valores_Brutos.Checked Then _Br_Nt = "Bruto"

            .Columns("Costo_Ud1Lista_" & _Br_Nt).Width = 50
            .Columns("Costo_Ud1Lista_" & _Br_Nt).HeaderText = "Costo Ud1"
            .Columns("Costo_Ud1Lista_" & _Br_Nt).ToolTipText = "Costo " & _Br_Nt & " Unidad 1"
            .Columns("Costo_Ud1Lista_" & _Br_Nt).DefaultCellStyle.Format = "##,###0"
            .Columns("Costo_Ud1Lista_" & _Br_Nt).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Costo_Ud1Lista_" & _Br_Nt).Visible = True
            .Columns("Costo_Ud1Lista_" & _Br_Nt).DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            Dim _ColDif As String

            If Rdb_Valores_Netos.Checked Then _ColDif = "PorcDifCostoNetUd1"
            If Rdb_Valores_Brutos.Checked Then _ColDif = "PorcDifCostoBruUd1"

            _ColDif = "PorcDifCostoNetUd1"

            .Columns(_ColDif).Width = 50
            .Columns(_ColDif).HeaderText = "%Dif.UC"
            .Columns(_ColDif).ToolTipText = "Porcentaje de diferencia de costo del costos actual vs el precio de ultima compra." & vbCrLf &
                                                           "(No necesariamente la ultima compra es de este proveedor, confirme esta situación.)"
            .Columns(_ColDif).DefaultCellStyle.Format = "% ##,##0.##"
            .Columns(_ColDif).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(_ColDif).Visible = True
            .Columns(_ColDif).DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            '.Columns("Costo_Flete").Width = 50
            '.Columns("Costo_Flete").HeaderText = "Flete"
            '.Columns("Costo_Flete").ToolTipText = "Costo del flete por proveedor"
            '.Columns("Costo_Flete").DefaultCellStyle.Format = "##,###0.##"
            '.Columns("Costo_Flete").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            '.Columns("Costo_Flete").Visible = True
            '.Columns("Costo_Flete").DisplayIndex = _DisplayIndex
            '_DisplayIndex += 1

            .Columns("Stock_CriticoUd" & Ud & "_Rd").Width = 45
            .Columns("Stock_CriticoUd" & Ud & "_Rd").HeaderText = "Stock Critico"
            .Columns("Stock_CriticoUd" & Ud & "_Rd").DefaultCellStyle.Format = "##,###0.##"
            .Columns("Stock_CriticoUd" & Ud & "_Rd").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Stock_CriticoUd" & Ud & "_Rd").ToolTipText = "Cantidad mínima de productos para sostener el tiempo de reposición EC = (TS*RT)"
            .Columns("Stock_CriticoUd" & Ud & "_Rd").ReadOnly = True
            .Columns("Stock_CriticoUd" & Ud & "_Rd").Visible = True
            .Columns("Stock_CriticoUd" & Ud & "_Rd").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            Dim _Tex As String = Cmb_Metodo_Abastecer_Dias_Meses.Text
            Dim _L As String = Mid(_Tex, 1, 1)
            _Tex = UCase(_L) & Mid(_Tex, 2, _Tex.Length - 1)

            .Columns("TStock").Width = 40
            .Columns("TStock").HeaderText = _Tex & " S.A"
            .Columns("TStock").DefaultCellStyle.Format = "##,###0.##"
            .Columns("TStock").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("TStock").ToolTipText = _Tex & " de stock asegurado. Días que restan para que se termine el stock Diario"
            .Columns("TStock").ReadOnly = True
            .Columns("TStock").Visible = True
            .Columns("TStock").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1


            Dim _Campo_CalUd_Diario As String
            Dim _Campo_CalUd_Mensual As String

            If Rdb_Rot_Mediana.Checked Then
                _Campo_CalUd_Diario = "RotDiariaUd"
                _Campo_CalUd_Mensual = "RotMensualUd"
            End If

            If Rdb_Rot_Promedio.Checked Then
                _Campo_CalUd_Diario = "Promedio_Ud"
                _Campo_CalUd_Mensual = "Promedio_MensualUd"
            End If

            If Cmb_Metodo_Abastecer_Dias_Meses.SelectedValue = 1 Then

                .Columns(_Campo_CalUd_Diario & Ud).Width = 50
                .Columns(_Campo_CalUd_Diario & Ud).HeaderText = "R.V.D"
                .Columns(_Campo_CalUd_Diario & Ud).DefaultCellStyle.Format = "##,###0.###"
                .Columns(_Campo_CalUd_Diario & Ud).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(_Campo_CalUd_Diario & Ud).ToolTipText = "Velocidad de venta media diaria (Rotación)"
                .Columns(_Campo_CalUd_Diario & Ud).Visible = True
                .Columns(_Campo_CalUd_Diario & Ud).DisplayIndex = _DisplayIndex
                _DisplayIndex += 1

            Else

                .Columns(_Campo_CalUd_Mensual & Ud).Width = 50
                .Columns(_Campo_CalUd_Mensual & Ud).HeaderText = "R.V.M"
                .Columns(_Campo_CalUd_Mensual & Ud).DefaultCellStyle.Format = "##,###0.##"
                .Columns(_Campo_CalUd_Mensual & Ud).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(_Campo_CalUd_Mensual & Ud).ToolTipText = "Velocidad de venta media mensual (Rotación)"
                .Columns(_Campo_CalUd_Mensual & Ud).Visible = True
                .Columns(_Campo_CalUd_Mensual & Ud).DisplayIndex = _DisplayIndex
                _DisplayIndex += 1

            End If

            .Columns("OccGenerada").Width = 35
            .Columns("OccGenerada").HeaderText = "OCC Gen"
            .Columns("OccGenerada").ToolTipText = "Tiene orden de compra generada desde este tratamiento"
            .Columns("OccGenerada").Visible = True
            .Columns("OccGenerada").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Fecha_Ult_Venta").HeaderText = "F.Ult.Venta"
            .Columns("Fecha_Ult_Venta").Width = 70
            .Columns("Fecha_Ult_Venta").DefaultCellStyle.Format = "dd/MM/yyyy"
            .Columns("Fecha_Ult_Venta").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Fecha_Ult_Venta").Visible = True
            .Columns("Fecha_Ult_Venta").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("StockUd" & Ud).Width = 70
            .Columns("StockUd" & Ud).HeaderText = "Stock en " &
                                                   Input_Tiempo_Reposicion.Value & " " &
                                                   Cmb_Tiempo_Reposicion_Dias_Meses.Text '& " Ud. " & Ud
            .Columns("StockUd" & Ud).DefaultCellStyle.Format = "##,###0.##"
            .Columns("StockUd" & Ud).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("StockUd" & Ud).ToolTipText = "Stock consolidado según bodegas seleccionadas"
            .Columns("StockUd" & Ud).ReadOnly = True
            .Columns("StockUd" & Ud).Visible = Chk_Trabajando_Con_Proyeccion.Checked
            .Columns("StockUd" & Ud).DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Clasificacion_Rk").Width = 100
            .Columns("Clasificacion_Rk").HeaderText = "Clas. Ranking"
            .Columns("Clasificacion_Rk").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .Columns("Clasificacion_Rk").ToolTipText = "Campo denominado para la clasificación se mejores productos de la empresa según Ranking"
            .Columns("Clasificacion_Rk").ReadOnly = True
            .Columns("Clasificacion_Rk").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Ranking_Top").Width = 50
            .Columns("Ranking_Top").HeaderText = "Ranking"
            .Columns("Ranking_Top").ToolTipText = "Posición del producto en el Ranking"
            .Columns("Ranking_Top").DefaultCellStyle.Format = "##,###"
            .Columns("Ranking_Top").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Ranking_Top").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            If False Then
                If Not _Proceso_Automatico_Ejecutado Then
                    .Columns("Ranking_Top").Visible = True
                    .Columns("Clasificacion_Rk").Visible = True
                Else
                    .Columns("Ranking_Top").Visible = False
                    .Columns("Clasificacion_Rk").Visible = False
                End If
            End If

            '' Creamos un nuevo estilo de celda
            ''
            'Dim cellStyle As New DataGridViewCellStyle

            'cellStyle.Font = New Font(Grilla.Font.Name, Grilla.Font.Size, FontStyle.Bold)
            'Grilla.Columns("CantSugeridaTot").DefaultCellStyle = cellStyle

            .Columns("Porc_CumpUlt3Pedidos").Width = 50
            .Columns("Porc_CumpUlt3Pedidos").HeaderText = "%C.P."
            .Columns("Porc_CumpUlt3Pedidos").ToolTipText = "Porcentaje de cumplimineto del proveedor en los ultimos 3 pedidos de los ultimos 3 meses"
            .Columns("Porc_CumpUlt3Pedidos").DefaultCellStyle.Format = "% ##,##0"
            .Columns("Porc_CumpUlt3Pedidos").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Porc_CumpUlt3Pedidos").Visible = True
            .Columns("Porc_CumpUlt3Pedidos").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Refresh()

        End With

    End Sub


    Sub Sb_Formato_Grilla_Detalle_Ult_Registros(Grilla As DataGridView, _Tbl As DataTable)

        Dim _DisplayIndex = 0

        Try

            With Grilla

                .DataSource = _Tbl

                OcultarEncabezadoGrilla(Grilla, True)

                .Columns("TIDO").HeaderText = "TD"
                .Columns("TIDO").Width = 35
                .Columns("TIDO").Visible = True
                .Columns("TIDO").DisplayIndex = _DisplayIndex
                _DisplayIndex += 1

                .Columns("NUDO").HeaderText = "Número"
                .Columns("NUDO").Width = 75
                .Columns("NUDO").Visible = True
                .Columns("NUDO").DisplayIndex = _DisplayIndex
                _DisplayIndex += 1

                .Columns("ENDO").HeaderText = "Entidad"
                .Columns("ENDO").Width = 75
                .Columns("ENDO").Visible = True
                .Columns("ENDO").DisplayIndex = _DisplayIndex
                _DisplayIndex += 1

                .Columns("SUENDO").HeaderText = "Suc."
                .Columns("SUENDO").Width = 35
                .Columns("SUENDO").Visible = True
                .Columns("SUENDO").DisplayIndex = _DisplayIndex
                _DisplayIndex += 1

                .Columns("NOKOEN").HeaderText = "Proveedor"
                .Columns("NOKOEN").Width = 230
                .Columns("NOKOEN").Visible = True
                .Columns("NOKOEN").DisplayIndex = _DisplayIndex
                _DisplayIndex += 1

                .Columns("FEEMLI").HeaderText = "Fecha"
                .Columns("FEEMLI").Width = 70
                .Columns("FEEMLI").DefaultCellStyle.Format = "dd/MM/yyyy"
                .Columns("FEEMLI").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns("FEEMLI").Visible = True
                .Columns("FEEMLI").DisplayIndex = _DisplayIndex
                _DisplayIndex += 1

                .Columns("BOSULIDO").HeaderText = "Bod."
                .Columns("BOSULIDO").Width = 35
                .Columns("BOSULIDO").Visible = True
                .Columns("BOSULIDO").DisplayIndex = _DisplayIndex
                _DisplayIndex += 1

                .Columns("UD01PR").Width = 25
                .Columns("UD01PR").HeaderText = "U1"
                .Columns("UD01PR").ReadOnly = True
                .Columns("UD01PR").Visible = True
                .Columns("UD01PR").DisplayIndex = _DisplayIndex
                _DisplayIndex += 1

                .Columns("CAPRCO1").Width = 50
                .Columns("CAPRCO1").HeaderText = "Cant. Ud1"
                .Columns("CAPRCO1").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns("CAPRCO1").DefaultCellStyle.Format = "###,##0.##"
                .Columns("CAPRCO1").Visible = True
                .Columns("CAPRCO1").DisplayIndex = _DisplayIndex
                _DisplayIndex += 1

                If Ud = 2 Then

                    .Columns("UD02PR").Width = 25
                    .Columns("UD02PR").HeaderText = "U2"
                    .Columns("UD02PR").ReadOnly = True
                    .Columns("UD02PR").Visible = True
                    .Columns("UD02PR").DisplayIndex = _DisplayIndex
                    _DisplayIndex += 1

                    .Columns("CAPRCO2").Width = 50
                    .Columns("CAPRCO2").HeaderText = "Cant. Ud2"
                    .Columns("CAPRCO2").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Columns("CAPRCO2").DefaultCellStyle.Format = "###,##0.##"
                    .Columns("CAPRCO2").Visible = True
                    .Columns("CAPRCO2").DisplayIndex = _DisplayIndex
                    _DisplayIndex += 1

                End If

                .Columns("MOPPPR").Width = 30
                .Columns("MOPPPR").HeaderText = "M."
                .Columns("MOPPPR").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .Columns("MOPPPR").Visible = True
                .Columns("MOPPPR").DisplayIndex = _DisplayIndex
                _DisplayIndex += 1

                'PPPRNEUd2 Precio Neto Ud2
                'VABRUTOUd1 y VABRUTOUd2

                .Columns("PPPRNEUd1").Width = 70
                .Columns("PPPRNEUd1").HeaderText = "P.Neto U1"
                .Columns("PPPRNEUd1").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns("PPPRNEUd1").DefaultCellStyle.Format = "###,##0.##"
                .Columns("PPPRNEUd1").Visible = Rdb_Valores_Netos.Checked
                .Columns("PPPRNEUd1").DisplayIndex = _DisplayIndex
                _DisplayIndex += 1

                If Ud = 2 Then

                    .Columns("PPPRNEUd2").Width = 70
                    .Columns("PPPRNEUd2").HeaderText = "P.Neto U2"
                    .Columns("PPPRNEUd2").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Columns("PPPRNEUd2").DefaultCellStyle.Format = "###,##0.##"
                    .Columns("PPPRNEUd2").Visible = Rdb_Valores_Netos.Checked
                    .Columns("PPPRNEUd2").DisplayIndex = _DisplayIndex
                    _DisplayIndex += 1

                End If

                Dim _Br_Nt = "Neto"
                If Rdb_Valores_Brutos.Checked Then _Br_Nt = "Bruto"

                _Br_Nt = "Neto"

                .Columns("Porc_Dif_Precios_" & _Br_Nt).Width = 50
                .Columns("Porc_Dif_Precios_" & _Br_Nt).HeaderText = "Dif"
                .Columns("Porc_Dif_Precios_" & _Br_Nt).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns("Porc_Dif_Precios_" & _Br_Nt).DefaultCellStyle.Format = "% ##0.##"
                .Columns("Porc_Dif_Precios_" & _Br_Nt).Visible = True
                .Columns("Porc_Dif_Precios_" & _Br_Nt).DisplayIndex = _DisplayIndex
                _DisplayIndex += 1

                .Columns("PODTGLLI").Width = 50
                .Columns("PODTGLLI").HeaderText = "Dscto"
                .Columns("PODTGLLI").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns("PODTGLLI").DefaultCellStyle.Format = "% ###,##0.##"
                .Columns("PODTGLLI").Visible = True
                .Columns("PODTGLLI").DisplayIndex = _DisplayIndex
                _DisplayIndex += 1

                .Columns("VABRUTOUd1").Width = 70
                .Columns("VABRUTOUd1").HeaderText = "V.Bruto U1"
                .Columns("VABRUTOUd1").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns("VABRUTOUd1").DefaultCellStyle.Format = "###,##0"
                .Columns("VABRUTOUd1").Visible = Rdb_Valores_Brutos.Checked
                .Columns("VABRUTOUd1").DisplayIndex = _DisplayIndex
                _DisplayIndex += 1

                If Ud = 2 Then

                    .Columns("VABRUTOUd2").Width = 70
                    .Columns("VABRUTOUd2").HeaderText = "V.Bruto U2"
                    .Columns("VABRUTOUd2").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Columns("VABRUTOUd2").DefaultCellStyle.Format = "###,##0"
                    .Columns("VABRUTOUd2").Visible = Rdb_Valores_Brutos.Checked
                    .Columns("VABRUTOUd2").DisplayIndex = _DisplayIndex
                    _DisplayIndex += 1

                End If

                .Columns("VANELI").Width = 70
                .Columns("VANELI").HeaderText = "T.Neto"
                .Columns("VANELI").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns("VANELI").DefaultCellStyle.Format = "###,##0"
                .Columns("VANELI").Visible = True
                .Columns("VANELI").DisplayIndex = _DisplayIndex
                _DisplayIndex += 1

                .Columns("VAIMLI").Width = 60
                .Columns("VAIMLI").HeaderText = "Imp.Es."
                .Columns("VAIMLI").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns("VAIMLI").DefaultCellStyle.Format = "###,##0"
                .Columns("VAIMLI").Visible = True
                .Columns("VAIMLI").DisplayIndex = _DisplayIndex
                _DisplayIndex += 1

                .Columns("VAIVLI").Width = 60
                .Columns("VAIVLI").HeaderText = "Iva"
                .Columns("VAIVLI").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns("VAIVLI").DefaultCellStyle.Format = "###,##0"
                .Columns("VAIVLI").Visible = True
                .Columns("VAIVLI").DisplayIndex = _DisplayIndex
                _DisplayIndex += 1

                .Columns("VABRLI").Width = 70
                .Columns("VABRLI").HeaderText = "T.Bruto"
                .Columns("VABRLI").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns("VABRLI").DefaultCellStyle.Format = "###,##0"
                .Columns("VABRLI").Visible = True
                .Columns("VABRLI").DisplayIndex = _DisplayIndex
                _DisplayIndex += 1

            End With

            Dim _Br_Nt2 = "Neto"
            If Rdb_Valores_Brutos.Checked Then _Br_Nt2 = "Bruto"

            _Br_Nt2 = "Neto"

            Dim _Campo_Dif = "Porc_Dif_Precios_" & _Br_Nt2

            For Each _Fila As DataGridViewRow In Grilla.Rows

                If _Fila.Cells(_Campo_Dif).Value > 0.03 Then
                    _Fila.Cells(_Campo_Dif).Style.ForeColor = Rojo
                End If

                If _Fila.Cells(_Campo_Dif).Value < -0.03 Then
                    _Fila.Cells(_Campo_Dif).Style.ForeColor = Verde
                End If

            Next

        Catch ex As Exception

        End Try

    End Sub

    Sub Sb_Formato_Grilla_Compras_Extranjero(Grilla As DataGridView)

        Dim _Tex As String = Cmb_Metodo_Abastecer_Dias_Meses.Text
        Dim _L As String = Mid(_Tex, 1, 1)
        _Tex = UCase(_L) & Mid(_Tex, 2, _Tex.Length - 1)

        Dim _Rot_Str As String

        If Cmb_Metodo_Abastecer_Dias_Meses.SelectedValue = 1 Then
            _Rot_Str = "diaria"
        Else
            _Rot_Str = "mensual"
        End If

        With Grilla

            OcultarEncabezadoGrilla(Grilla) ',, False, , True)

            'Grilla.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None

            Dim _DisplayIndex = 0

            .Columns("Comprar").Frozen = True
            .Columns("Comprar").Width = 50
            .Columns("Comprar").HeaderText = "Comprar"
            .Columns("Comprar").ToolTipText = "¿Comprar?"
            .Columns("Comprar").Visible = True
            .Columns("Comprar").ReadOnly = False
            .Columns("Comprar").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Codigo").Frozen = True
            .Columns("Codigo").Width = 100
            .Columns("Codigo").HeaderText = "Código"
            .Columns("Codigo").ReadOnly = True
            .Columns("Codigo").Visible = True
            .Columns("Codigo").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("CodAlternativo").Frozen = True
            .Columns("CodAlternativo").Width = 80

            If (_RowProveedor Is Nothing) Then
                .Columns("CodAlternativo").HeaderText = "Cód. Alternativo"
            Else
                .Columns("CodAlternativo").HeaderText = "Cód. Proveedor"
            End If
            .Columns("CodAlternativo").ReadOnly = True
            .Columns("CodAlternativo").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Descripcion").Frozen = True
            .Columns("Descripcion").Width = 400
            .Columns("Descripcion").HeaderText = "Descripción"
            .Columns("Descripcion").ReadOnly = True
            .Columns("Descripcion").Visible = True
            .Columns("Descripcion").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            'Dim _Ud
            'If Rdb_Ud1_Compra.Checked Then : _Ud = 1 : Else : _Ud = 2 : End If

            .Columns("Stock_Fisico_Ud" & Ud).Width = 50
            .Columns("Stock_Fisico_Ud" & Ud).HeaderText = "Stock actual"
            .Columns("Stock_Fisico_Ud" & Ud).DefaultCellStyle.Format = "##,###0.##"
            .Columns("Stock_Fisico_Ud" & Ud).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Stock_Fisico_Ud" & Ud).ToolTipText = "Stock consolidado según bodegas seleccionadas"
            .Columns("Stock_Fisico_Ud" & Ud).ReadOnly = True
            .Columns("Stock_Fisico_Ud" & Ud).Visible = True
            .Columns("Stock_Fisico_Ud" & Ud).DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            Dim _Campo_CalUd_Diario As String
            Dim _Campo_CalUd_Mensual As String

            If Rdb_Rot_Mediana.Checked Then
                _Campo_CalUd_Diario = "RotDiariaUd"
                _Campo_CalUd_Mensual = "RotMensualUd"
            End If

            If Rdb_Rot_Promedio.Checked Then
                _Campo_CalUd_Diario = "Promedio_Ud"
                _Campo_CalUd_Mensual = "Promedio_MensualUd"
            End If

            If Cmb_Metodo_Abastecer_Dias_Meses.SelectedValue = 1 Then

                .Columns(_Campo_CalUd_Diario & Ud).Width = 50
                .Columns(_Campo_CalUd_Diario & Ud).HeaderText = "R.V.D"
                .Columns(_Campo_CalUd_Diario & Ud).DefaultCellStyle.Format = "##,###0.###"
                .Columns(_Campo_CalUd_Diario & Ud).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(_Campo_CalUd_Diario & Ud).ToolTipText = "Velocidad de venta media diaria (Rotación)"
                .Columns(_Campo_CalUd_Diario & Ud).Visible = True
                .Columns(_Campo_CalUd_Diario & Ud).DisplayIndex = _DisplayIndex
                _DisplayIndex += 1

            Else

                .Columns(_Campo_CalUd_Mensual & Ud).Width = 50
                .Columns(_Campo_CalUd_Mensual & Ud).HeaderText = "R.V.M"
                .Columns(_Campo_CalUd_Mensual & Ud).DefaultCellStyle.Format = "##,###0.##"
                .Columns(_Campo_CalUd_Mensual & Ud).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(_Campo_CalUd_Mensual & Ud).ToolTipText = "Velocidad de venta media mensual (Rotación)"
                .Columns(_Campo_CalUd_Mensual & Ud).Visible = True
                .Columns(_Campo_CalUd_Mensual & Ud).DisplayIndex = _DisplayIndex
                _DisplayIndex += 1

            End If

            Dim _Header As String

            _Header = "Proyección de venta en " & Input_Tiempo_Reposicion.Value & " " & _Tex

            .Columns("Stock_CriticoUd" & Ud & "_Rd").Width = 80
            .Columns("Stock_CriticoUd" & Ud & "_Rd").HeaderText = _Header '"Proyección Stock"
            .Columns("Stock_CriticoUd" & Ud & "_Rd").DefaultCellStyle.Format = "##,###0.##"
            .Columns("Stock_CriticoUd" & Ud & "_Rd").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Stock_CriticoUd" & Ud & "_Rd").ToolTipText = "Ventas proyectadas en base a la rotación x el tiempo de reposición"
            .Columns("Stock_CriticoUd" & Ud & "_Rd").ReadOnly = True
            .Columns("Stock_CriticoUd" & Ud & "_Rd").Visible = True
            .Columns("Stock_CriticoUd" & Ud & "_Rd").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            '.Columns("StockPedidoUd" & Ud).Width = 50
            '.Columns("StockPedidoUd" & Ud).HeaderText = "Stock pedido"
            '.Columns("StockPedidoUd" & Ud).DefaultCellStyle.Format = "##,###0.##"
            '.Columns("StockPedidoUd" & Ud).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            '.Columns("StockPedidoUd" & Ud).ToolTipText = "Stock consolidado según bodegas seleccionadas"
            '.Columns("StockPedidoUd" & Ud).ReadOnly = True

            'If Not Chk_No_Considera_Con_Stock_Pedido_OCC_NVI.Checked Then
            '.Columns("StockPedidoUd" & Ud).Visible = False
            'End If

            '.Columns("_Ud" & Ud).Frozen = True
            '.Columns("UD" & Ud).Width = 30
            '.Columns("UD" & Ud).HeaderText = "Ud" & Ud
            '.Columns("UD" & Ud).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            '.Columns("UD" & Ud).ToolTipText = "Unidad " & Ud
            '.Columns("UD" & Ud).ReadOnly = True
            '.Columns("UD" & Ud).Visible = True
            '.Columns("UD" & Ud).DisplayIndex = 7

            'TStock_Mens


            '.Columns("TStock").Width = 60
            '.Columns("TStock").HeaderText = _Tex & " de stock asegurado"
            '.Columns("TStock").DefaultCellStyle.Format = "##,###0.##"
            '.Columns("TStock").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            '.Columns("TStock").ToolTipText = _Tex & " que restan para que se termine el stock"
            '.Columns("TStock").ReadOnly = True
            '.Columns("TStock").Visible = True


            _Header = "Proyección de stock en " & Input_Tiempo_Reposicion.Value & " " & _Tex

            .Columns("StockUd" & Ud).Width = 70
            .Columns("StockUd" & Ud).HeaderText = _Header
            .Columns("StockUd" & Ud).DefaultCellStyle.Format = "##,###0.##"
            .Columns("StockUd" & Ud).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("StockUd" & Ud).ToolTipText = "Stock que tendremos al momento de la llegada del cargamento."
            .Columns("StockUd" & Ud).ReadOnly = True
            .Columns("StockUd" & Ud).Visible = True 'Chk_Trabajando_Con_Proyeccion.Checked
            .Columns("StockUd" & Ud).DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            '.Columns("CantSugeridaTot").Frozen = True
            .Columns("CantSugeridaTot").Width = 70
            .Columns("CantSugeridaTot").HeaderText = "Cantidad Sugerida"
            .Columns("CantSugeridaTot").DefaultCellStyle.Format = "##,###0.##"
            .Columns("CantSugeridaTot").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("CantSugeridaTot").ToolTipText = "Cantidad sugerida de compra para " & Input_Dias_a_Abastecer.Value & " " & _Tex
            .Columns("CantSugeridaTot").Visible = True
            .Columns("CantSugeridaTot").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            '.Columns("CantComprar").Frozen = True
            .Columns("CantComprar").Width = 60
            .Columns("CantComprar").HeaderText = "Cantidad"
            .Columns("CantComprar").ToolTipText = "Cantidad a comprar"
            .Columns("CantComprar").DefaultCellStyle.Format = "##,###0.##"
            .Columns("CantComprar").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("CantComprar").Visible = True
            .Columns("CantComprar").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("DiasdeAvas_Rd").Width = 60
            .Columns("DiasdeAvas_Rd").HeaderText = "Alcanza para ..." & Cmb_Metodo_Abastecer_Dias_Meses.Text
            .Columns("DiasdeAvas_Rd").ToolTipText = _Tex & " que cubre la compra según rotación " & _Rot_Str
            .Columns("DiasdeAvas_Rd").DefaultCellStyle.Format = "##,###0.##"
            .Columns("DiasdeAvas_Rd").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("DiasdeAvas_Rd").Visible = True
            .Columns("DiasdeAvas_Rd").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            '.Columns("Nom_" & Trim(CampoEstrella)).Frozen = True
            '.Columns("Clasificacion_Rk").Width = 100
            '.Columns("Clasificacion_Rk").HeaderText = "Clas. Ranking"
            '.Columns("Clasificacion_Rk").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            '.Columns("Clasificacion_Rk").ToolTipText = "Campo denominado para la clasificación se mejores productos de la empresa según Ranking"
            '.Columns("Clasificacion_Rk").ReadOnly = True


            ''.Columns("Ranking_Top").Frozen = True

            '.Columns("Ranking_Top").Width = 50
            '.Columns("Ranking_Top").HeaderText = "Ranking"
            '.Columns("Ranking_Top").ToolTipText = "Posición del producto en el Ranking"
            '.Columns("Ranking_Top").DefaultCellStyle.Format = "##,###"
            '.Columns("Ranking_Top").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            'If Not _Proceso_Automatico_Ejecutado Then
            '.Columns("Ranking_Top").Visible = True
            '.Columns("Clasificacion_Rk").Visible = True
            'Else
            '.Columns("Ranking_Top").Visible = False
            '.Columns("Clasificacion_Rk").Visible = False
            'End If


            '.Columns("Rtu").Frozen = True
            '.Columns("Rtu").Width = 40
            '.Columns("Rtu").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            '.Columns("Rtu").ReadOnly = True
            '.Columns("Rtu").Visible = True


            '.Columns("OccGenerada").Width = 50
            '.Columns("OccGenerada").HeaderText = "OCC G."
            '.Columns("OccGenerada").ToolTipText = "Tiene orden de compra generada desde este tratamiento"
            '.Columns("OccGenerada").Visible = True

            .Refresh()

        End With

    End Sub

    Function Sb_Grilla_Actualizar_Informe(Grilla As DataGridView)

        Dim _Condicion = String.Empty
        Dim _Tiempo_Reposicion = Input_Tiempo_Reposicion.Value

        If Chk_Sacar_Productos_Sin_Rotacion.Checked Then
            _Condicion = "And Fecha_Ult_Venta > '" & Format(_Fecha_Productos_Sin_Rotacion, "yyyyMMdd") & "'" & vbCrLf
        End If

        If Chk_Mostrar_Solo_Stock_Critico.Checked Then
            _Condicion += "And Con_Stock_CriticoUd" & Ud & " = 1" & vbCrLf
        End If

        If Not (_RowProveedor Is Nothing) Then

            Dim _Koen = Trim(_RowProveedor.Item("KOEN"))
            Dim _Suen = Trim(_RowProveedor.Item("SUEN"))
            Dim _Nokoen = Trim(_RowProveedor.Item("NOKOEN"))

            Fm_Hijo.Txt_Proveedor.Text = _Koen & _Suen & " - " & _Nokoen
            _Condicion += vbCrLf & "And CodProveedor = '" & _Koen & "' And CodSucProveedor = '" & _Suen & "'"

        End If

        If Chk_Quitar_Bloqueados_Compra.Checked Then
            _Condicion += "And Bloqueapr In ('V','')" & vbCrLf
        End If

        Dim _Filtro_Rubros,
            _Filtro_Marcas,
            _Filtro_Zonas,
            _Filtro_SuperFamilias,
            _Filtro_ClasLibre,
            _Filtro_Bodega,
            _Filtro_Stock_Pedido,
            _Filtro_Solo_a_Comprar,
            _Filtro_Quitar_Comprados As String

        '---- FILTROS -------------------------------

        If _Filtro_Rubro_Todas Then
            _Filtro_Rubros = String.Empty
        Else
            _Filtro_Rubros = Generar_Filtro_IN(_Tbl_Filtro_Rubro, "Chk", "Codigo", False, True, "'")
            _Filtro_Rubros = "And Codigo IN (Select KOPR From MAEPR Where RUPR In " & _Filtro_Rubros & ")"
        End If

        If _Filtro_Marcas_Todas Then
            _Filtro_Marcas = String.Empty
        Else
            _Filtro_Marcas = Generar_Filtro_IN(_Tbl_Filtro_Marcas, "Chk", "Codigo", False, True, "'")
            _Filtro_Marcas = "And Codigo IN (Select KOPR From MAEPR Where MRPR In " & _Filtro_Marcas & ")"
        End If

        If _Filtro_Super_Familias_Todas Then
            _Filtro_SuperFamilias = String.Empty
        Else
            _Filtro_SuperFamilias = Generar_Filtro_IN(_Tbl_Filtro_Super_Familias, "Chk", "Codigo", False, True, "'")
            _Filtro_SuperFamilias = "And Codigo IN (Select KOPR From MAEPR Where FMPR In " & _Filtro_SuperFamilias & ")"
        End If

        If _Filtro_Clalibpr_Todas Then
            _Filtro_ClasLibre = String.Empty
        Else
            _Filtro_ClasLibre = Generar_Filtro_IN(_Tbl_Filtro_Clalibpr, "Chk", "Codigo", False, True, "'")
            _Filtro_ClasLibre = "And Codigo IN (Select KOPR From MAEPR Where CLALIBPR In " & _Filtro_ClasLibre & ")"
        End If

        If _Filtro_Zonas_Todas Then
            _Filtro_Zonas = String.Empty
        Else
            _Filtro_Zonas = Generar_Filtro_IN(_Tbl_Filtro_Zonas, "Chk", "Codigo", False, True, "'")
            _Filtro_Zonas = "And Codigo IN (Select KOPR From MAEPR Where ZONAPR In " & _Filtro_Zonas & ")"
        End If

        '---------------------------

        If Chk_No_Considera_Con_Stock_Pedido_OCC_NVI.Checked Then
            _Filtro_Stock_Pedido = "And StockPedidoUd" & Ud & " = 0"
        Else
            _Filtro_Stock_Pedido = String.Empty
        End If

        If Chk_Mostrar_Solo_a_Comprar_Cant_Mayor_Cero.Checked Then
            _Filtro_Solo_a_Comprar = "And CantComprar > 0"
        Else
            _Filtro_Solo_a_Comprar = String.Empty
        End If

        If Chk_Quitar_Comprados.Checked Then
            _Filtro_Quitar_Comprados = "And OccGenerada = 0"
        Else
            _Filtro_Quitar_Comprados = String.Empty
        End If

        _Condicion += _Filtro_Bodega & vbCrLf &
                      _Filtro_ClasLibre & vbCrLf &
                      _Filtro_Marcas & vbCrLf &
                      _Filtro_Rubros & vbCrLf &
                      _Filtro_SuperFamilias & vbCrLf &
                      _Filtro_Zonas & vbCrLf &
                      _Filtro_Stock_Pedido & vbCrLf &
                      _Filtro_Solo_a_Comprar & vbCrLf &
                      _Filtro_Quitar_Comprados

        If Chk_Mostrar_Solo_Productos_A_Comprar.Checked Then
            _Condicion += Space(1) & "And Comprar = 1"
        End If

        If Not Chk_Traer_Productos_De_Reemplazo.Checked Then
            _Condicion += Space(1) & "And Es_Reemplazo = 0"
        End If

        If Chk_Quitar_Ventas_Calzadas.Checked Then
            _Condicion += Space(1) & "And Refleo = 0"
        End If


        If Chk_Traer_Productos_De_Reemplazo.Checked And Chk_Sumar_Rotacion_Hermanos.Checked Then '_Proceso_Automatico_Ejecutado Then
            '_Condicion += Space(1) & "And Es_Agrupador = 1"
        End If

        If Chk_Quitare_Sospechosos_Stock.Checked Then
            _Condicion += Space(1) & "And Sospecha_Baja_Rotacion = 0"
        End If

        Consulta_sql = My.Resources.Recursos_Asis_Compras.SQLQuery_Actualizar_Informe_Principal

        Consulta_sql = Replace(Consulta_sql, "#TablaPaso#", _Nombre_Tbl_Paso_Informe)
        Consulta_sql = Replace(Consulta_sql, "#Condicion#", _Condicion)

        Dim _Campo_Orden As String

        _Campo_Orden = My.Settings.Asis_Compra_Campo_Orden
        If My.Settings.Asis_Compra_Campo_Orden_Orden = "Descending" Then _Campo_Orden += " Desc"

        Consulta_sql = Replace(Consulta_sql, "#Campo_Orden1#", _Campo_Orden)

        If Not (_RowProveedor Is Nothing) Then
            _Condicion += Space(1) & "And CodProveedor = '" & _RowProveedor.Item("KOEN") & "'"
        End If

        Sb_Formato_Generico_Grilla(Grilla, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Both, True, False, False)

        Dim _New_Ds As DataSet = _Sql.Fx_Get_DataSet(Consulta_sql)

        _Tbl_Informe = _New_Ds.Tables(0)

        _Dv.Table = _New_Ds.Tables("Table")

        Grilla.DataSource = _Dv

        If Fm_Hijo.Cmb_Tipo_de_compra.SelectedValue = "Nacional" Then Sb_Formato_Grilla_Compras_Nacionales(Grilla)
        If Fm_Hijo.Cmb_Tipo_de_compra.SelectedValue = "Nacional2" Then Sb_Formato_Grilla_Compras_Nacionales2(Grilla)
        If Fm_Hijo.Cmb_Tipo_de_compra.SelectedValue = "Exterior" Then Sb_Formato_Grilla_Compras_Extranjero(Grilla)

        Dim _Bodegas_Stock = Generar_Filtro_IN(_TblBodCompra, "Chk", "Codigo", False, True, "")
        Dim _Bodegas_Venta = Generar_Filtro_IN(_TblBodVenta, "Chk", "Codigo", False, True, "")


        Consulta_sql = "Update " & _Global_BaseBk & "Zw_Prod_Log_Compras Set" & vbCrLf &
                       "Fecha_Ult_Estudio = Getdate()," &
                       "Bodegas_Stock = '" & _Bodegas_Stock & "'," &
                       "Bodegas_Venta = '" & _Bodegas_Venta & "'," &
                       "Stock_Fisico_Ud1 = Tpaso.Stock_Fisico_Ud1," &
                       "Stock_Fisico_Ud2 = Tpaso.Stock_Fisico_Ud2," &
                       "Stock_CriticoUd1_Rd = Tpaso.Stock_CriticoUd1_Rd," &
                       "Stock_CriticoUd2_Rd = Tpaso.Stock_CriticoUd2_Rd," &
                       "RotDiariaUd1 = Tpaso.RotDiariaUd1," &
                       "RotDiariaUd2 = Tpaso.RotDiariaUd2," &
                       "RotMensualUd1 = Tpaso.RotMensualUd1," &
                       "RotMensualUd2 = Tpaso.RotMensualUd2," &
                       "CantComprar = Tpaso.CantComprar," &
                       "CantSugeridaTot = Tpaso.CantSugeridaTot," &
                       "Dias_Avastecer = " & Input_Dias_a_Abastecer.Value & "," &
                       "Tiempo_Reposicion = " & Input_Tiempo_Reposicion.Value & vbCrLf &
                       "From " & _Nombre_Tbl_Paso_Informe & " Tpaso" & vbCrLf &
                       "Inner Join " & _Global_BaseBk & "Zw_Prod_Log_Compras Zlog On Tpaso.Codigo = Zlog.Codigo" & vbCrLf &
                       "Where NombreEquipo = '" & _NombreEquipo & "' And CodFuncionario = '" & FUNCIONARIO & "'"
        _Sql.Ej_consulta_IDU(Consulta_sql)

        Try
            Grilla.CurrentCell = Grilla.Rows(0).Cells("Codigo")
            Sb_Actualizar_Grilla_Mensual()
        Catch ex As Exception

        End Try

    End Function


    Private Sub CmmdBuscarInf_Executed(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmmdBuscarInf.Executed

        Dim Fm As New Frm_BkpPostBusquedaEspecial_Mt
        Fm.Pro_CodEntidad = String.Empty
        Fm.Pro_CodSucEntidad = String.Empty
        Fm.Pro_Tipo_Lista = "C"
        Fm.Pro_Lista_Busqueda = ModListaPrecioVenta
        Fm.Pro_Sucursal_Busqueda = ModSucursal
        Fm.Pro_Bodega_Busqueda = ModBodega
        Fm.Pro_Mostrar_Info = False
        Fm.Pro_Actualizar_Precios = False

        Fm.ShowDialog(Me)

        If Fm.Pro_Seleccionado Then
            Codigo_abuscar = Fm.Pro_RowProducto.Item("KOPR")
        Else
            Codigo_abuscar = String.Empty
        End If

        If Codigo_abuscar <> "" Then
            BuscarEnGrilla(Codigo_abuscar)
        End If
    End Sub

    Private Function BuscarEnGrilla(ByVal Codigo As String)

        If BuscarDatoEnGrilla(Trim(Codigo), "Codigo", Fm_Hijo.Grilla) Then
            Fm_Hijo.Grilla.CurrentCell = Fm_Hijo.Grilla.Rows(Fm_Hijo.Grilla.CurrentRow.Index).Cells("CantComprar")
            Fm_Hijo.Grilla.Focus()
        End If

    End Function

    Function RevisarExitenciaDeProducto(ByVal Codigo As String) As Boolean

        Dim Registros As Integer
        Registros = _Sql.Fx_Cuenta_Registros(_Nombre_Tbl_Paso_Informe, "Codigo = '" & Codigo & "'")

        If Registros > 0 Then
            Return True
        Else
            Return False
        End If

    End Function

    Sub AgregarProducto(ByVal Codigo As String)

        If _Sql.Ej_consulta_IDU(Consulta_sql) Then
            MsgBox("Producto incorporado correctamente", MsgBoxStyle.Information, "Agregar producto adicional")
            BuscarEnGrilla(Codigo)
        End If

    End Sub

    Private Sub CmmdImprimirList_Executed(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmmdImprimirList.Executed

        Consulta_sql = "SELECT Codigo,CodAlternativo AS CodigoAlternativo, Descripcion, UD1, UD2,Rtu" & vbCrLf &
                       "FROM " & _Nombre_Tbl_Paso_Informe & vbCrLf &
                       "ORDER BY Descripcion"
        '"WHERE ClasificacionLibre IN (SELECT Codigo FROM " & _Nombre_Tbl_Paso_InformeProEstrellas & ")" & vbCrLf & _
        '"ORDER BY Descripcion"

        Dim _Koen = _RowProveedor.Item("KOEN")
        Dim _Nokoen = _RowProveedor.Item("NOKOEN")


        'GenerarDtCompaAs(_Koen, _Nokoen, Consulta_sql)

    End Sub

    Sub Sb_Crear_OCC(Grilla As DataGridView)

        Dim _Endo, _Suendo As String
        Dim _Endofi, _Suendofi As String
        Dim _Koen, _Suen As String

        Dim _Row_Entidad As DataRow
        Dim _Row_Entidad_Fisica As DataRow

        Timer1.Enabled = False

        If Chk_Ent_Fisica.Checked Then

            _Endofi = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Tmp_Prm_Informes", "Valor",
                                        "Funcionario = '" & FUNCIONARIO & "' AND Campo = 'Koen' AND Informe = 'Compras_Asistente'")
            _Suendofi = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Tmp_Prm_Informes", "Valor",
                                        "Funcionario = '" & FUNCIONARIO & "' AND Campo = 'Suen' AND Informe = 'Compras_Asistente'")

        End If

        Dim _Todos_Los_Proveedores As Boolean

        If Not _Rdb_Productos_Proveedor Then
            _Todos_Los_Proveedores = True
        End If

        If _Todos_Los_Proveedores Then

            If (_RowProveedor Is Nothing) Then

                MessageBoxEx.Show(Me, "Debe seleccionar el proveedor en filtrar proveedor",
                                  "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return

                Dim Fm1 = New Frm_04_Asis_Compra_Proveedores(Frm_04_Asis_Compra_Proveedores.TipoBusqueda.Proveedores_Seleccionados, "", True)
                Fm1.ShowDialog(Me)

                If Not (Fm1.Pro_RowProveedor Is Nothing) Then
                    _Koen = Fm1.Pro_RowProveedor.Item("KOEN")
                    _Suen = Fm1.Pro_RowProveedor.Item("SUEN")
                Else
                    Return
                End If
            Else
                _Koen = _RowProveedor.Item("KOEN")
                _Suen = _RowProveedor.Item("SUEN")
            End If

        End If

        If Chk_Ent_Fisica.Checked Then

            If _Todos_Los_Proveedores Then
                _Endofi = Trim(_Koen)
                _Suendofi = Trim(_Suen)
            Else
                'CodEntidadFisica = NuloPorNro(Fila_.Item("CodEntidadSel"), "")
                'CodSucEntidadFisica = NuloPorNro(Fila_.Item("SucEntidadSel"), "")
            End If

            MessageBoxEx.Show(Me, "Debe seleccionar un proveedor para generar la orden de compra, " &
                              "ya que está marcada la opción entidad física", "Seleccionar proveedor",
                              MessageBoxButtons.OK, MessageBoxIcon.Information)

            Dim FmBe As New Frm_BuscarEntidad_Mt(False)
            FmBe.ShowDialog(Me)

            If FmBe.Pro_Entidad_Seleccionada Then

                _Endo = Trim(FmBe.Pro_RowEntidad.Item("KOEN"))
                _Suendo = Trim(FmBe.Pro_RowEntidad.Item("SUEN"))

                _Koen = _Endo
                _Suen = _Suendo

            Else
                MessageBoxEx.Show("No se seleccionó ningún proveedor para realizar la Orden de compra",
                                  "Falta proveedor", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

        Else
            If Not _RowProveedor Is Nothing Then
                _Koen = _RowProveedor.Item("KOEN")
                _Suen = _RowProveedor.Item("SUEN")
            End If
        End If

        Consulta_sql = "Select Top 1 *,KOEN AS ENDO, SUEN AS SUENDO From MAEEN" & vbCrLf &
                       "Where KOEN = '" & _Koen & "' And SUEN = '" & _Suen & "'"
        _Row_Entidad = _Sql.Fx_Get_DataRow(Consulta_sql)

        Consulta_sql = "Select Top 1 *,KOEN AS ENDO, SUEN AS SUENDO From MAEEN" & vbCrLf &
                       "Where KOEN = '" & _Endofi & "' And SUEN = '" & _Suendofi & "'"
        _Row_Entidad_Fisica = _Sql.Fx_Get_DataRow(Consulta_sql)

        Dim _CodProveedor As String = _Koen
        Dim _CodSucProveedor As String = _Suen

        If Chk_Ent_Fisica.Checked Then
            _CodProveedor = _Endofi
            _CodSucProveedor = _Suendofi
        End If

        Consulta_sql = My.Resources.Recursos_Asis_Compras.SQLQuery_Actualizar_Costos_en_Lista_de_Proveedores
        Dim _ElistaCom As String = Mid(_Global_Row_Configuracion_Estacion.Item("ELISTACOM"), 6, 3)

        Consulta_sql = Replace(Consulta_sql, "#Lista#", _ElistaCom)
        Consulta_sql = Replace(Consulta_sql, "#Entidad#", _CodProveedor)
        Consulta_sql = Replace(Consulta_sql, "#Sucursal#", "")
        Consulta_sql = Replace(Consulta_sql, "Zw_InfCompras", _Nombre_Tbl_Paso_Informe)
        Consulta_sql = Replace(Consulta_sql, "Zw_ListaPreCosto", _Global_BaseBk & "Zw_ListaPreCosto")

        _Sql.Ej_consulta_IDU(Consulta_sql)

        Dim _RowFormato As DataRow = Fx_Formato_Modalidad(Me, _Modalidad_Estudio, "OCC", True)
        Dim _NroLineasXpag As Integer = _RowFormato.Item("NroLineasXpag")

        Dim _Largo_Variable As Boolean = _RowFormato.Item("Largo_Variable")
        Dim _Registros As Integer = Fm_Hijo.Grilla.Rows.Count

        Dim _Top = String.Empty

        If _Largo_Variable Then
            If Not CBool(_NroLineasXpag) Then
                _NroLineasXpag = 500
            End If
        End If

        If _NroLineasXpag > 0 Then _Top = "Top " & _NroLineasXpag

        'Dim _Ud As Integer
        'If Rdb_Ud1_Compra.Checked Then : _Ud = 1 : Else : _Ud = 2 : End If

        Dim _Condicion As String = String.Empty


        If Chk_Mostrar_Solo_Stock_Critico.Checked Then
            _Condicion += "And Con_Stock_CriticoUd" & Ud & " = 1" & vbCrLf
        End If

        If Chk_No_Considera_Con_Stock_Pedido_OCC_NVI.Checked Then
            _Condicion += "And StockPedidoUd" & Ud & " = 0" & vbCrLf
        End If

        If Chk_Mostrar_Solo_a_Comprar_Cant_Mayor_Cero.Checked Then
            _Condicion += "And CantComprar > 0" & vbCrLf
        End If

        If Chk_Quitar_Comprados.Checked Then
            _Condicion += "And OccGenerada = 0" & vbCrLf
        End If

        If Chk_Mostrar_Solo_Productos_A_Comprar.Checked Then
            _Condicion += "And Comprar = 1" & vbCrLf
        End If

        If Chk_Quitar_Ventas_Calzadas.Checked Then
            _Condicion += "And Refleo = 0" & vbCrLf
        End If

        If Chk_Quitare_Sospechosos_Stock.Checked Then
            _Condicion += "And Sospecha_Baja_Rotacion = 0" & vbCrLf
        End If

        Dim _Orden_Codigo As String

        If Fm_Hijo.Grilla.SortOrder = Windows.Forms.SortOrder.Ascending Then
            _Orden_Codigo = Grilla.SortedColumn.Name
        ElseIf Grilla.SortOrder = Windows.Forms.SortOrder.Descending Then
            _Orden_Codigo = Grilla.SortedColumn.Name & " Desc"
        Else
            _Orden_Codigo = "Codigo"
        End If

        If Rd_Costo_Lista_Proveedor.Checked Then

            Dim _Lista As String = Cmb_Lista_Costos.SelectedItem.Value

            Consulta_sql = "Select 0 As IDMAEEDO,Getdate() As FEEMDO,Getdate() As FEER

                            Select Distinct " & _Top & " '" & FUNCIONARIO & "' As KOFULIDO,Tb.Codigo As KOPRCT,Tb.Descripcion As NOKOPR,
                            Tb.Descripcion as Descripcion,Tb.CodAlternativo,'" & _Lista & "' As KOLTPR,UD1,UD2,
                            0 As CostoUd1,0 As CostoUd2,0 As Precio, Tb.Rtu,CantComprar As Cantidad,
                            0 As Desc1,0 As Desc2,0 As Desc3,0 As Desc4,0 As Desc5,0 As DescSuma,0 As PRCT,'' As TICT,TIPR,0 As PODTGLLI," & Ud & " as UDTRPR,
                            Isnull(Trc.RECARGO,0) As POTENCIA,'' As KOFUAULIDO,'' As KOOPLIDO,
                            0 As IDMAEEDO,0 As IDMAEDDO,'" & ModEmpresa & "' As EMPRESA,'" & ModSucursal & "' As SULIDO,'" & ModBodega & "' As BOSULIDO,'' As ENDO,'' As SUENDO,GetDate() As FEEMLI,
                            '' As TIDO,'' As NUDO,'' As NULIDO,0 As CantUd1_Dori,0 As CantUd2_Dori,'' As OBSERVA,
                            0 As Id_Oferta,'' As Oferta,0 As Es_Padre_Oferta,0 As Padre_Oferta,
							0 As Hijo_Oferta,0 As Cantidad_Oferta,0 As Porcdesc_Oferta

                            From  " & _Nombre_Tbl_Paso_Informe & " Tb

                            Inner Join TABCODAL Tcl On Tcl.KOEN = Tb.CodProveedor And Tb.Codigo = Tcl.KOPR And Tcl.KOPRAL = Tb.CodAlternativo
                                Left Join TABRECPR Trc On Trc.KOEN = Tb.CodProveedor and Trc.KOPR = Tb.Codigo
                                    Inner Join MAEPR Mp On Mp.KOPR = Tb.Codigo
                                        Where Tb.CantComprar > 0 And Tb.CodSucProveedor = '" & _Suen & "'
                                            And Tb.CodProveedor = '" & _Koen & "' And Tb.OccGenerada = 0 And Comprar = 1
                            " & _Condicion & vbCrLf &
                            "Order by " & _Orden_Codigo & "
                             Select * From MAEIMLI Where 1<0  
                                 Select * From MAEDTLI Where 1 < 0 
                                 Select 'Documento generado desde Asistente de compras BakApp' as OBDO"

        ElseIf Rd_Costo_Ultimo_Documento_Seleccionado.Checked Then

            '[Costo_Compra_RealUd1]     [float]       DEFAULT (0),
            '[Costo_Compra_RealUd2]     [float]       DEFAULT (0),
            '[Costo_Compra]             [float]       DEFAULT (0),
            '[Dscto_Compra]             [float]       DEFAULT (0),

            Consulta_sql = "Select 0 As IDMAEEDO,Getdate() As FEEMDO,Getdate() As FEER" &
                            vbCrLf &
                           "Select Distinct " & _Top & " '" & FUNCIONARIO & "' As KOFULIDO,Codigo As KOPRCT,
                            Descripcion,Descripcion As NOKOPR,CodAlternativo,'" & ModListaPrecioCosto & "' As KOLTPR,UD1,UD2,
                            Costo_Ult_Compra as CostoUd1,Costo_Ult_Compra as CostoUd2,
                            Costo_Ult_Compra As Precio,Rtu,CantComprar As Cantidad,Dscto_Ult_Compra as Desc1,
                            0 as Desc2,0 as Desc3,0 as Desc4,0 as Desc5,0 As PRCT,'' As TICT,TIPR," & Ud & " as UDTRPR,0 as POTENCIA,'' As KOFUAULIDO,'' As KOOPLIDO,
                            0 As IDMAEEDO,0 As IDMAEDDO,'" & ModEmpresa & "' As EMPRESA,'" & ModSucursal & "' As SULIDO,'" & ModBodega & "' As BOSULIDO,
                            '' As ENDO,'' As SUENDO,
                            GetDate() As FEEMLI,'' As TIDO,'' As NUDO,'' As NULIDO,0 As CantUd1_Dori,0 As CantUd2_Dori,'' As OBSERVA,
                            0 As Id_Oferta,'' As Oferta,0 As Es_Padre_Oferta,0 As Padre_Oferta,
							0 As Hijo_Oferta,0 As Cantidad_Oferta,0 As Porcdesc_Oferta
                            From " & _Nombre_Tbl_Paso_Informe & "
                            Inner Join MAEPR Mp On Mp.KOPR = Codigo
                            Where
                            CantComprar > 0 And CodProveedor = '" & Trim(_CodProveedor) & "' And CodSucProveedor = '" & Trim(_CodSucProveedor) & "'
                            And OccGenerada = 0 And Comprar = 1" & vbCrLf &
                            _Condicion & vbCrLf & " 
                            Order by " & _Orden_Codigo & " 
                            Select * From MAEIMLI Where 1<0  
                            Select * From MAEDTLI Where 1<0  
                            Select 'Documento generado desde Asistente de compras BakApp' as OBDO"

        End If

        Dim _Ds_New_Documento As DataSet = _Sql.Fx_Get_DataSet(Consulta_sql)


        Dim _TblDetalle As DataTable = _Ds_New_Documento.Tables(1)

        If _TblDetalle.Rows.Count Then

            Me.Enabled = False

            Dim _New_Idmaeedo As Integer

            Dim Fm_Espera As New Frm_Form_Esperar
            Fm_Espera.Pro_Texto = "Armando orden de compra" & vbCrLf & "por favor espere..."
            Fm_Espera.BarraCircular.IsRunning = True
            Fm_Espera.Show(Me)

            Dim Fm_Post As New Frm_Formulario_Documento("OCC",
                                                        csGlobales.Enum_Tipo_Documento.Compra,
                                                        False, True, True)

            Fm_Post.Pro_Agrupar_Reemplazos = Chk_Traer_Productos_De_Reemplazo.Checked
            Fm_Post.Pro_RowEntidad = _Row_Entidad
            Fm_Post.Pro_RowEntidad_Despacho = _Row_Entidad_Fisica
            Fm_Post.Pro_Lista_de_precios_de_proveedores = Rd_Costo_Lista_Proveedor.Checked
            Fm_Post.Sb_Crear_Documento_Desde_Otros_Documentos(Me, _Ds_New_Documento, True, False, Nothing, False, False)

            Fm_Post.MinimizeBox = False

            Fm_Espera.Close()
            Fm_Espera.Dispose()

            Fm_Post.ShowDialog(Me)
            _New_Idmaeedo = Fm_Post.Pro_Idmaeedo
            Fm_Post.Dispose()

            Me.Enabled = True

            If CBool(_New_Idmaeedo) Then

                Consulta_sql = "Update " & _Global_BaseBk & "Zw_Prod_Log_Compras Set" & vbCrLf &
                               "Idmaeedo_Ult_occ = " & _New_Idmaeedo & "," &
                               "Fecha_Ult_occ = GetDate()" & vbCrLf &
                               "From " & _Nombre_Tbl_Paso_Informe & " Tpaso" & vbCrLf &
                               "Inner Join " & _Global_BaseBk & "Zw_Prod_Log_Compras Zlog On Tpaso.Codigo = Zlog.Codigo" & vbCrLf &
                               "Where NombreEquipo = '" & _NombreEquipo & "'" & Space(1) &
                               "And CodFuncionario = '" & FUNCIONARIO & "'" & Space(1) &
                               "And Tpaso.Codigo In (Select KOPRCT From MAEDDO Where IDMAEEDO = " & _New_Idmaeedo & ")"
                _Sql.Ej_consulta_IDU(Consulta_sql)



                Dim _Codigo As String

                Consulta_sql = "Select KOPRCT From MAEDDO Where IDMAEEDO = " & _New_Idmaeedo
                Dim _Tb As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

                If CBool(_Tb.Rows.Count) Then
                    For Each Fila As DataRow In _Tb.Rows

                        _Codigo = Fila.Item("KOPRCT")

                        Consulta_sql += "Update " & _Nombre_Tbl_Paso_Informe & vbCrLf &
                                       "Set OccGenerada = 1,IdOCC = " & _New_Idmaeedo & vbCrLf &
                                       "Where Codigo = '" & _Codigo & "'" & vbCrLf &
                                       "And CodProveedor = '" & _Koen & "' And CodSucProveedor = '" & _Suen & "'" & vbCrLf

                    Next

                    If Not String.IsNullOrEmpty(Consulta_sql) Then
                        _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql)
                    End If
                Else
                    MessageBoxEx.Show(Me, "No se encontro la orden de compra en el sistema", "Error inesperado",
                                      MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If

                Consulta_sql = String.Empty


                If MessageBoxEx.Show(Me, "¿Desea enviar la nueva orden por correo?", "Enviar orden por correo",
                                     MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                    Dim _Email_Para As String = Trim(_Sql.Fx_Trae_Dato("MAEEN", "EMAIL", "KOEN = '" & _Koen & "' And SUEN = '" & _Suen & "'"))

                    Sb_Enviar_Doc_Por_Mail(_New_Idmaeedo, _Email_Para, "Estimados.", "", Me)

                End If

                If _Rdb_Productos_Proveedor Then
                    Sb_Refrescar_Grilla_Principal(Grilla, False, False)
                Else
                    If MessageBoxEx.Show(Me, "¿Desea seguir trabajando con el mismo proveedor?" & vbCrLf & vbCrLf &
                                         "Proveedor: " & _Row_Entidad.Item("NOKOEN"), "Asistente de compras",
                                         MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                        Sb_Refrescar_Grilla_Principal(Grilla, False, False)
                    Else
                        Call Btn_Quitar_Filtro_Proveedor_Click(Nothing, Nothing)
                    End If
                End If

            End If

            If Chk_Ent_Fisica.Checked Then
                _Koen = _Endofi
                _Suen = _Suendofi
            End If

        Else
            MessageBoxEx.Show(Me, "No existen productos seleccionados para comprar desde el tratamiento",
                              "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)

        End If

        Timer1.Enabled = True

    End Sub

    Function RevisarCantidades() As Boolean

        If Fx_Suma_cantidades("CantCoprar", "W_PASO_AUDITORIASTOCK1" & FUNCIONARIO) = 0 Then

            Dim info As New TaskDialogInfo("Asistente de compras",
                            eTaskDialogIcon.Stop,
                            "No existen datos que procesar, las cantidades a comprar estan en cero",
                            "Debe ingresar cantidades de compra en el campo Cant.",
                            eTaskDialogButton.Close _
                            , eTaskDialogBackgroundColor.Red, Nothing, Nothing, Nothing, Nothing, Nothing)
            Dim result As eTaskDialogResult = TaskDialog.Show(info)

            MessageBox.Show(Me, "No existen datos que procesar, las cantidades a comprar estan en cero", "Crear Orden de Compra",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)

            Return False
        Else
            Return True
        End If
    End Function

    Function RevisarEntidad() As Boolean

        If (_RowProveedor Is Nothing) Then

            Dim info As New TaskDialogInfo("Asistente de compras",
                        eTaskDialogIcon.Exclamation,
                        "Debe seleccionar una entidad para el documento de compra",
                        "Falta el proveedor en el encabezado del documento, revise la ficha Información proveedor" & vbCrLf &
                        "A continuación aparecerá el asistente de búsqueda de entidades",
                        eTaskDialogButton.Close _
                        , eTaskDialogBackgroundColor.Red, Nothing, Nothing, Nothing, Nothing, Nothing)
            Dim result As eTaskDialogResult = TaskDialog.Show(info)

            Dim Fm As New Frm_BuscarEntidad_Mt(False)
            Fm.ShowDialog(Me)

            Dim _Sel As Boolean = Fm.Pro_Entidad_Seleccionada

            If _Sel Then
                _RowProveedor = Fm.Pro_RowEntidad
            End If

            Fm.Dispose()

            Return _Sel

        Else
            Return True
        End If

    End Function

    Private Sub BtnDejarCantEnCero_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDejarCantEnCero.Click

        If MessageBoxEx.Show(Me, "¿Confirma dejar todas las cantidades a comprar en cero [0]?" & vbCrLf &
                             "Solo de la vista actual Y productos que no han sido comprados con el asistente", "Confirmación",
                             MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then


            Consulta_sql = String.Empty

            For Each _Fila As DataGridViewRow In Fm_Hijo.Grilla.Rows

                Dim _Codigo As String = _Fila.Cells.Item("Codigo").Value
                Dim _OccGenerada As Boolean = _Fila.Cells.Item("OccGenerada").Value
                _Fila.Cells.Item("CantComprar").Value = 0

                If Not _OccGenerada Then
                    Sb_Marcar_Fila_Grilla(_Fila, False, Fx_Dias_Proyeccion)

                    Consulta_sql += "Update " & _Nombre_Tbl_Paso_Informe & " Set CantComprar = 0" & Space(1) &
                        "Where Codigo = '" & _Codigo & "'" & vbCrLf
                End If
            Next

            _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql)

            MessageBoxEx.Show(Me, "Cantidades limpias", "Cantidades en Cero",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information)

        End If

    End Sub

    Private Function SumarCantidadesComprar(
        ByVal nombre_Columna As String,
        ByVal Dgv As DataGridView) As Double

        Dim total As Double = 0

        ' recorrer las filas y obtener los items de la columna indicada en "nombre_Columna"  
        Try
            For i As Integer = 0 To Dgv.RowCount - 1
                If CDbl(Dgv.Item(nombre_Columna.ToLower, i).Value) > 0 Then
                    total += 1 'total + CDbl(Dgv.Item(nombre_Columna.ToLower, i).Value)
                End If
            Next

        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try

        ' retornar el valor  
        Return total

    End Function



    Private Sub PressEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        KeyAscii = CShort(SoloNumeros(KeyAscii))
        If KeyAscii = 0 Then
            e.Handled = True
        End If

        ' Si se pulsa la tecla Intro, pasar al siguiente
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            'If e.KeyChar = ChrW(Keys.Return) Then
            e.Handled = True
        ElseIf e.KeyChar = ","c Then
            ' si se pulsa la coma se convertirá en punto
            e.Handled = True
            SendKeys.Send(".")
        ElseIf e.KeyChar = "-"c Then
            e.Handled = True
            SendKeys.Send("")
        End If
    End Sub

    Private Sub BtnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub

    Private Sub BtnExporExcelTodo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExporExcelTodo.Click
        Consulta_sql = "SELECT * FROM " & _Nombre_Tbl_Paso_Informe
        ExportarTabla_JetExcel(Consulta_sql, Me)
    End Sub

    Private Sub ChkConsiderarRot_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        LblStockCritico.Enabled = Chk_Mostrar_Solo_Stock_Critico.Checked
        Input_Tiempo_Reposicion.Enabled = Chk_No_Considera_Con_Stock_Pedido_OCC_NVI.Checked
    End Sub


    Sub Sb_Grilla_Marcar(Grilla As DataGridView, _Marcar_Todo As Boolean)

        If Accion_Automatica Then
            Return
        End If

        With Grilla

            Dim _Dias_Proyeccion = Fx_Dias_Proyeccion()

            Dim Fm_Espera As New Frm_Form_Esperar
            Fm_Espera.Pro_Texto = "Marcando filas. Por favor espere..."
            Fm_Espera.BarraCircular.IsRunning = True
            Fm_Espera.Show(Me)

            Try
                For Each _Fila As DataGridViewRow In .Rows
                    'System.Windows.Forms.Application.DoEvents()
                    Sb_Marcar_Fila_Grilla(_Fila, _Marcar_Todo, _Dias_Proyeccion)
                Next
            Catch ex As Exception
            Finally
                Fm_Espera.Close()
                Fm_Espera.Dispose()
            End Try

        End With

    End Sub

    Sub Sb_Marcar_Fila_Grilla(_Fila As DataGridViewRow,
                              _MarcarTodo As Boolean,
                              _Dias_Proyeccion As Integer)

        Dim _Tiempo_Stock = Input_Tiempo_Reposicion.Value

        Dim ContadorDsctos As Integer = 0
        Dim _TStock As Double
        Dim StockUd1 As Double
        Dim StockUd2 As Double
        Dim Bloqueapr As String

        Dim _Stock_Fisico_Ud_Negativo As Boolean = _Fila.Cells("Stock_Fisico_Ud" & _Ud & "_Negativo").Value

        Dim _Codigo = _Fila.Cells("Codigo").Value
        Dim _Descripcion = _Fila.Cells("Descripcion").Value

        Dim CantSugeridaTot As Double = 0

        _Fila.Cells("Orden").Value = _Fila.Index

        Bloqueapr = NuloPorNro(_Fila.Cells("Bloqueapr").Value, "")

        StockUd1 = NuloPorNro(_Fila.Cells("StockUd1").Value, 0)
        StockUd2 = NuloPorNro(_Fila.Cells("StockUd2").Value, 0)

        _TStock = NuloPorNro(_Fila.Cells("TStock").Value, 2)

        If Global_Thema = Enum_Themas.Oscuro Then
            _Fila.DefaultCellStyle.ForeColor = Color.White
        Else
            _Fila.DefaultCellStyle.ForeColor = Color.Black
        End If

        Dim _Stock As Double

        If Rdb_Ud1_Compra.Checked Then
            _Stock = StockUd1
        Else
            _Stock = StockUd2
        End If

        Dim Stock_Critico = NuloPorNro(_Fila.Cells("Stock_CriticoUd" & Ud & "_Rd").Value, 0)
        Dim Con_Stock_Critico As Boolean = _Fila.Cells("Con_Stock_CriticoUd" & Ud).Value

        If Stock_Critico >= _Stock Then
            Con_Stock_Critico = True
        Else
            Con_Stock_Critico = False
        End If

        If Con_Stock_Critico Then

            _Fila.Cells("Stock_Fisico_Ud" & Ud).Style.ForeColor = Rojo
            _Fila.Cells("StockUd" & Ud).Style.ForeColor = Rojo
            _Fila.Cells("Stock_CriticoUd" & Ud & "_Rd").Style.ForeColor = Rojo

        End If

        If _TStock <= _Tiempo_Stock Then _Fila.Cells("TStock").Style.ForeColor = Rojo

        If Global_Thema = Enum_Themas.Oscuro Then

            _Fila.Cells("StockUd1").Style.ForeColor = Color.Black
            _Fila.Cells("StockUd2").Style.ForeColor = Color.Black
            _Fila.Cells("CantComprar").Style.ForeColor = Color.Black

        End If

        If _Stock_Fisico_Ud_Negativo Then
            _Fila.Cells("Stock_Fisico_Ud" & Ud).Style.Font = New Font(Font.Name, Font.Size, FontStyle.Strikeout)
        Else
            _Fila.Cells("Stock_Fisico_Ud" & Ud).Style.Font = New Font(Font.Name, Font.Size, FontStyle.Regular)
        End If

        _Fila.Cells("StockUd1").Style.BackColor = Color.LightGray
        _Fila.Cells("StockUd2").Style.BackColor = Color.LightGray
        _Fila.Cells("CantComprar").Style.BackColor = Color.FromArgb(253, 227, 102) 'Color.Yellow

        _Fila.Cells("Descripcion").Style.Font = New Font(Fm_Hijo.Grilla.Font.Name, 7)

        '_Fila.Cells("CantComprar").Style.Font = New Font(Fm_Hijo.Grilla.Font.Name, Fm_Hijo.Grilla.Font.Size, FontStyle.Bold)
        _Fila.Cells("CantComprar").Style.Alignment = DataGridViewContentAlignment.MiddleRight

        _Fila.Cells("CantSugeridaTot").Style.Font = New Font(Fm_Hijo.Grilla.Font.Name, Fm_Hijo.Grilla.Font.Size, FontStyle.Bold)
        _Fila.Cells("CantSugeridaTot").Style.Alignment = DataGridViewContentAlignment.MiddleRight

        Dim OccGenerada As Boolean = _Fila.Cells("OccGenerada").Value

        If Bloqueapr = "C" Or Bloqueapr = "T" Or OccGenerada Then

            _Fila.DefaultCellStyle.ForeColor = Color.Gray

        End If



        Dim _Cantidad = NuloPorNro(_Fila.Cells("CantComprar").Value, 0)
        Dim _RotacionDiaria = NuloPorNro(_Fila.Cells("RotDiariaUd" & Ud).Value, 0)
        Dim _RotacionMensual = NuloPorNro(_Fila.Cells("RotMensualUd" & Ud).Value, 0)

        If _Cantidad > 0 And _RotacionDiaria > 0 Then

            Dim _Alcanza As Double
            Dim _Rotacion As Double

            If Cmb_Metodo_Abastecer_Dias_Meses.SelectedValue = 1 Then
                _Rotacion = _RotacionDiaria
            ElseIf Cmb_Metodo_Abastecer_Dias_Meses.SelectedValue = 30 Then
                _Rotacion = _RotacionMensual
            End If


            If Chk_Restar_Stok_Bodega.Checked Then
                _Alcanza = Math.Round((_Cantidad + _Stock) / _Rotacion, 0)
            Else
                _Alcanza = Math.Round((_Cantidad) / _Rotacion, 0)
            End If

            _Fila.Cells("DiasdeAvas_Rd").Value = _Alcanza
        Else
            _Fila.Cells("DiasdeAvas_Rd").Value = 0
        End If

        Dim _Advierte_Rotacion = _Fila.Cells("Advierte_Rotacion").Value

        If _Advierte_Rotacion Then _Fila.Cells("RotDiariaUd" & Ud).Style.ForeColor = Rojo

        Dim _Refleo As Boolean = _Fila.Cells("Refleo").Value

        If _Refleo Then

            If Global_Thema = Enum_Themas.Oscuro Then _Fila.DefaultCellStyle.ForeColor = Color.Black
            _Fila.DefaultCellStyle.BackColor = Color.SandyBrown

        End If

        Dim _Sospecha_Baja_Rotacion As Boolean = _Fila.Cells("Sospecha_Baja_Rotacion").Value

        If _Sospecha_Baja_Rotacion And Not _Refleo Then

            If Global_Thema = Enum_Themas.Oscuro Then
                _Fila.DefaultCellStyle.ForeColor = Color.Black
            End If

            _Fila.DefaultCellStyle.BackColor = Color.Khaki

        End If

        Dim _CantComprar = _Fila.Cells("CantComprar").Value
        Dim _CantSugeridaTot = _Fila.Cells("CantSugeridaTot").Value

        If _CantSugeridaTot = 0 Then

            If CBool(_CantComprar) Then

                If _CantComprar > _CantSugeridaTot Then
                    _Fila.Cells("Codigo").Style.ForeColor = Rojo
                    _Fila.Cells("Descripcion").Style.ForeColor = Rojo
                End If

            End If

            _Fila.Cells("CantSugeridaTot").Style.ForeColor = Color.Gray

        End If

        Dim _IdGDD As Integer = NuloPorNro(Val(_Fila.Cells("IdGDD").Value), 0)

        If CBool(_IdGDD) Then

            If Global_Thema = Enum_Themas.Oscuro Then
                _Fila.DefaultCellStyle.ForeColor = Color.Black
            End If

            _Fila.DefaultCellStyle.BackColor = Color.Plum

            If CBool(_CantComprar) Then
                _Fila.Cells("Descripcion").Style.Font = New Font(Font.Name, Font.Size, FontStyle.Regular)
            Else
                _Fila.Cells("Descripcion").Style.Font = New Font(Font.Name, Font.Size, FontStyle.Strikeout)
            End If

        End If

        Dim _Fecha_Ult_Venta As Date = NuloPorNro(_Fila.Cells("Fecha_Ult_Venta").Value, #01-01-1990#)

        If Chk_Sacar_Productos_Sin_Rotacion.Checked Then
            If _Fecha_Productos_Sin_Rotacion > _Fecha_Ult_Venta Then
                _Fila.DefaultCellStyle.Font = New Font(Font.Name, Font.Size, FontStyle.Strikeout)
            End If
        Else
            _Fila.DefaultCellStyle.Font = New Font(Font.Name, Font.Size, FontStyle.Regular)
        End If


        Dim _Sospecha_Familia As Integer = _Fila.Cells("Sospecha_Familia").Value

        If _Sospecha_Familia > 1 Then

            If Global_Thema = Enum_Themas.Oscuro Then
                _Fila.DefaultCellStyle.ForeColor = Color.Black
            End If

            _Fila.Cells("Codigo").Style.BackColor = Color.Yellow
            _Fila.Cells("Descripcion").Style.BackColor = Color.Yellow

        End If

        If Chk_Trabajando_Con_Proyeccion.Checked Then

            _Fila.Cells("Stock_Fisico_Ud" & Ud).Style.ForeColor = Color.Gray

            If Chk_Trabajando_Con_Proyeccion.Checked Then

                If _TStock < Input_Dias_a_Abastecer.Value Then _Fila.Cells("TStock").Style.ForeColor = Rojo

            End If

            Dim _StockPedidoUd As Double = _Fila.Cells("StockPedidoUd" & Ud).Value

            If Not CBool(_StockPedidoUd) Then _Fila.Cells("StockPedidoUd" & Ud).Style.ForeColor = Color.Gray

        End If

        Dim _ColDif As String

        'If Rdb_Valores_Netos.Checked Then _ColDif = "PorcDifCostoNetUd1"
        'If Rdb_Valores_Brutos.Checked Then _ColDif = "PorcDifCostoBruUd1"

        _ColDif = "PorcDifCostoNetUd1"

        If _Fila.Cells(_ColDif).Value > 0.03 Then
            _Fila.Cells(_ColDif).Style.ForeColor = Rojo
        End If

        If _Fila.Cells(_ColDif).Value < -0.03 Then
            _Fila.Cells(_ColDif).Style.ForeColor = Verde
        End If


    End Sub

#Region "PROCEDIMIENTOS GRILLA PRINCIPAL"

    Private Sub Grilla_ColumnHeaderMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs)

        Dim Grilla = CType(sender, DataGridView)

        My.Settings.Asis_Compra_Campo_Orden = Grilla.SortedColumn.Name
        My.Settings.Asis_Compra_Campo_Orden_Orden = Grilla.SortOrder.ToString
        My.Settings.Save()

        Codigo_abuscar = Fm_Hijo.Grilla.Rows(Grilla.CurrentRow.Index).Cells("Codigo").Value
        BuscarEnGrilla(Codigo_abuscar)

        Sb_Grilla_Marcar(Fm_Hijo.Grilla, False)

    End Sub


    Private Sub Grilla_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)

        Dim Grilla = CType(sender, DataGridView)

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        Dim _Codigo = _Fila.Cells("Codigo").Value

        Dim _Cabeza = Grilla.Columns(Grilla.CurrentCell.ColumnIndex).Name

        Dim _Cantidad = NuloPorNro(_Fila.Cells("CantComprar").Value, 0)
        Dim _RotacionDiaria = NuloPorNro(_Fila.Cells("RotDiariaUd" & Ud).Value, 0)

        Dim _Comprar = CInt(_Fila.Cells("Comprar").Value) * -1
        Dim _Es_Agrupador = CInt(_Fila.Cells("Es_Agrupador").Value) * -1
        Dim _Dias_Meses As Integer

        If _Cabeza = "CantComprar" Then

            If Fr_Alerta_Stock.Visible Then
                Fr_Alerta_Stock.Visible = False
            End If

            Select Case Cmb_Metodo_Abastecer_Dias_Meses.SelectedValue
                Case 1
                    _Dias_Meses = Fx_Dias_Proyeccion()
                Case 30
                    _Dias_Meses = Input_Dias_a_Abastecer.Value
            End Select

            Sb_Marcar_Fila_Grilla(_Fila, False, _Dias_Meses)

            If _Cantidad = 0 Then

                _Comprar = 0

                If Not _Proceso_Automatico_Ejecutado And Not _Rdb_Productos_Proveedor Then

                    _Fila.Cells("CodProveedor").Value = String.Empty
                    _Fila.Cells("CodSucProveedor").Value = String.Empty
                    _Fila.Cells("CodAlternativo").Value = String.Empty

                    Consulta_sql = "Update " & _Nombre_Tbl_Paso_Informe & " Set " &
                                   "CodProveedor = '',CodSucProveedor = '',CodAlternativo = '' Where Codigo = '" & _Codigo & "' And Es_Agrupador = " & _Es_Agrupador
                    _Sql.Ej_consulta_IDU(Consulta_sql)

                End If

            Else
                _Comprar = 1
            End If

            Dim _DiasdeAvas_Rd As Double = _Fila.Cells("DiasdeAvas_Rd").Value
            'Dim _DiasdeAvas_Re As Double = _Fila.Cells("DiasdeAvas_Re").Value

            _Fila.Cells("Comprar").Value = CBool(_Comprar)


            Consulta_sql = "Update " & _Nombre_Tbl_Paso_Informe & " Set " &
                           "Comprar = " & _Comprar &
                           ",Comprar_Igual = " & CInt(Not _Proceso_Automatico_Ejecutado) &
                           ",CantComprar = " & De_Num_a_Tx_01(_Cantidad, False, 5) &
                           ",DiasdeAvas_Rd = " & De_Num_a_Tx_01(_DiasdeAvas_Rd, False, 5) &
                           "Where Codigo = '" & _Codigo & "' And Es_Agrupador = " & _Es_Agrupador
            _Sql.Ej_consulta_IDU(Consulta_sql)

            Grilla.Columns(_Cabeza).ReadOnly = True

        ElseIf _Cabeza = "Comprar" Then

            Consulta_sql = "Update " & _Nombre_Tbl_Paso_Informe & " Set " &
                           "Comprar = " & _Comprar & ",Comprar_Igual = 1" & vbCrLf &
                           "Where Codigo = '" & _Codigo & "' And Es_Agrupador = " & _Es_Agrupador
            _Sql.Ej_consulta_IDU(Consulta_sql)

        End If

        Timer1.Enabled = False
        Timer1.Enabled = True

    End Sub

    Private Sub Grilla_CellBeginEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs)

        Dim Grilla = CType(sender, DataGridView)

        With Grilla

            Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

            Dim _Cabeza = .Columns(.CurrentCell.ColumnIndex).Name
            Dim _Codigo = _Fila.Cells("Codigo").Value
            Dim _Descripcion = _Fila.Cells("Descripcion").Value.ToString.Trim
            Dim _CodProveedor = NuloPorNro(_Fila.Cells("CodProveedor").Value.ToString.Trim, "")
            Dim _CodSucProveedor = NuloPorNro(_Fila.Cells("CodSucProveedor").Value.ToString.Trim, "")
            Dim _CodAlternativo = NuloPorNro(_Fila.Cells("CodAlternativo").Value.ToString.Trim, "")

            Dim _Bloqueapr = Trim(_Fila.Cells("Bloqueapr").Value)
            Dim _OccGenerada As Boolean = _Fila.Cells("OccGenerada").Value

            If _Bloqueapr = "C" Or _Bloqueapr = "T" Or _Bloqueapr = "X" Then
                MessageBoxEx.Show(Me, "Producto bloqueado para compras", "Acceso denegado",
                                  MessageBoxButtons.OK, MessageBoxIcon.Stop)
                e.Cancel = True
                Return
            End If

            If _OccGenerada Then
                MessageBoxEx.Show(Me, "Producto ya fue tratado en este proceso de compras" & vbCrLf &
                                  "Ya se generó solicitud u orden de compra", "Acceso denegado",
                                  MessageBoxButtons.OK, MessageBoxIcon.Stop)
                e.Cancel = True
                Return
            End If

            If _Cabeza = "CantComprar" Then

                If String.IsNullOrEmpty(_CodProveedor) Then

                    Dim Reg As Integer

                    If Chk_Ent_Fisica.Checked Then
                        Reg = _Sql.Fx_Cuenta_Registros("TABCODAL", "KOPR = '" & _Codigo & "' And KOEN <> ''")
                    Else
                        Reg = 2
                    End If

                    If Reg > 0 Then

                        If Reg = 1 Then

                            _CodProveedor = _Sql.Fx_Trae_Dato("TABCODAL", "KOEN", "KOPR = '" & _Codigo & "'")
                            Dim Rg2 As Integer = _Sql.Fx_Cuenta_Registros("MAEEN", "KOEN = '" & _CodProveedor & "'")
                            _CodAlternativo = _Sql.Fx_Trae_Dato("TABCODAL", "KOPRAL", "KOPR = '" & _Codigo & "' And KOEN = '" & _CodProveedor & "'")

                            If Rg2 = 1 Then
                                _CodSucProveedor =
                                _Sql.Fx_Trae_Dato("MAEEN", "SUEN", "KOEN = '" & _CodProveedor & "'")
                            ElseIf Reg > 1 Then
                                Dim Fm As New Frm_BuscarEntidad_MtSuc
                                Fm.ShowDialog(Me)

                                If Fm._Suc_Seleccionada Then
                                    _CodProveedor = Fm._Tbl_SucursalSelec.Rows(0).Item("KOEN")
                                    _CodSucProveedor = Fm._Tbl_SucursalSelec.Rows(0).Item("SUEN")
                                End If
                            End If

                            _Fila.Cells("CodProveedor").Value = _CodProveedor
                            _Fila.Cells("CodSucProveedor").Value = _CodSucProveedor
                            _Fila.Cells("CodAlternativo").Value = _CodAlternativo

                        ElseIf Reg > 1 Then

                            MessageBoxEx.Show(Me, "Existe más de un proveedor para este producto",
                                              "Asociar proveedor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                            Dim _Tipo_B As Frm_04_Asis_Compra_Proveedores.TipoBusqueda

                            If Not Chk_Ent_Fisica.Checked Then
                                _Tipo_B = Frm_04_Asis_Compra_Proveedores.TipoBusqueda.Proveedores_del_producto ' 1 
                            Else
                                _Tipo_B = Frm_04_Asis_Compra_Proveedores.TipoBusqueda.Todos_los_Proveedores '3 
                            End If

                            Dim Fm As New Frm_04_Asis_Compra_Proveedores(_Tipo_B, _Codigo, False)
                            Fm.Rd_Costo_Lista_Proveedor.Checked = Rd_Costo_Lista_Proveedor.Checked
                            Fm.Rd_Costo_Ultima_GRC.Checked = Rd_Costo_Ultimo_Documento_Seleccionado.Checked
                            Fm.Chk_Solo_Proveedores_CodAlternativo.Checked = Chk_Solo_Proveedores_CodAlternativo.Checked
                            Fm.ShowDialog(Me)

                            If Fm.Pro_RowProveedor Is Nothing Then
                                Grilla.Columns(_Cabeza).ReadOnly = True
                                e.Cancel = True
                            Else

                                _CodProveedor = Fm.Pro_RowProveedor.Item("KOEN")
                                _CodSucProveedor = Fm.Pro_RowProveedor.Item("SUEN")
                                Dim _Nokoen = Trim(Fm.Pro_RowProveedor.Item("NOKOEN"))

                                Dim _Kopral = _Sql.Fx_Trae_Dato("TABCODAL", "KOPRAL",
                                                        "KOPR = '" & _Codigo & "' And KOEN = '" & _CodProveedor & "'")


                                _CodAlternativo = _Kopral.Trim

                                If Rd_Costo_Lista_Proveedor.Checked And String.IsNullOrEmpty(_CodAlternativo) Then
                                    MessageBoxEx.Show(Me, "Este proveedor no posee código alternativo para el producto" & vbCrLf &
                                                      "Para poder incorporar a este proveedor debe ingresar el código alternativo en el mantenedor de códigos alternativos" & vbCrLf & vbCrLf &
                                                      "Proveedore: " & _CodProveedor.Trim & " - " & _Nokoen.Trim,
                                                      "Falta código alternativo",
                                                      MessageBoxButtons.OK, MessageBoxIcon.Stop)

                                    _Fila.Cells("CodProveedor").Value = String.Empty
                                    _Fila.Cells("CodSucProveedor").Value = String.Empty
                                    _Fila.Cells("CodAlternativo").Value = String.Empty
                                    _Fila.Cells("CantComprar").Value = 0

                                    Grilla.Columns(_Cabeza).ReadOnly = True
                                    e.Cancel = True

                                    Return
                                End If

                                _Fila.Cells("CodProveedor").Value = _CodProveedor
                                _Fila.Cells("CodSucProveedor").Value = _CodSucProveedor
                                _Fila.Cells("CodAlternativo").Value = _CodAlternativo

                                Consulta_sql = "Update " & _Nombre_Tbl_Paso_Informe & " Set " &
                                               "CodProveedor = '" & _CodProveedor & "'," &
                                               "CodSucProveedor = '" & _CodSucProveedor & "'," &
                                               "CodAlternativo = '" & _CodAlternativo & "'" & Space(1) &
                                               "Where Codigo = '" & _Codigo & "'"
                                _Sql.Ej_consulta_IDU(Consulta_sql)

                                Fm_Hijo.LblProveedorProducto.Text = _Nokoen &
                                                            ", Código Proveedor: [" & _CodAlternativo & "], " & _Descripcion

                                Fm.Dispose()

                            End If

                        End If
                    End If

                End If

                Dim Reg2 As Integer = _Sql.Fx_Cuenta_Registros("TABCODAL", "KOEN = '" & _CodProveedor & "' And KOPR = '" & _Codigo & "'")

                _CodAlternativo = NuloPorNro(_Fila.Cells("CodAlternativo").Value.ToString.Trim, "")

                If _CodAlternativo = "##" Then

                    If Reg2 > 1 Then

                        MessageBoxEx.Show(Me, "Producto con más de un código alternativo para el proveedor" & vbCrLf &
                                          "Debe seleccionar uno por favor", "Código Alternativo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Dim Fm As New Frm_05_AsisCompra_CodAlternativos
                        Fm.ProveedorRd = _CodProveedor
                        Fm.CodigoRd = _Codigo
                        Fm.Text = "Producto: " & _Codigo & " - " & _Descripcion
                        Fm.ShowDialog(Me)

                        _CodAlternativo = Trim(Fm.CodigoAlt)
                        If Not String.IsNullOrEmpty(_CodAlternativo) Then
                            _Fila.Cells("CodAlternativo").Value = _CodAlternativo

                            Consulta_sql = "Update " & _Nombre_Tbl_Paso_Informe & " Set " &
                                           "CodProveedor = '" & _CodProveedor & "'," &
                                           "CodSucProveedor = '" & _CodSucProveedor & "'," &
                                           "CodAlternativo = '" & _CodAlternativo & "'" & Space(1) &
                                           "Where Codigo = '" & _Codigo & "'"
                            _Sql.Ej_consulta_IDU(Consulta_sql)

                            Fm_Hijo.LblProveedorProducto.Text = "" 'Txt_Proveedor.Text & ", Código Proveedor: [" & CodAlternativo & "], " & Descripcion
                        Else
                            MessageBoxEx.Show(Me, "Debe seleccionar un código alternativo para el proveedor",
                                              "Código Alternativo", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Beep()
                            e.Cancel = True
                        End If
                    End If

                End If

            End If

        End With

    End Sub

    Private Sub Grilla_EditingControlShowing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs)

        Dim Grilla = CType(sender, DataGridView)
        Dim Cabeza = Grilla.Columns(Grilla.CurrentCell.ColumnIndex).Name

        If Cabeza = "CantComprar" Then
            ' referencia a la celda  
            Dim validar As TextBox = CType(e.Control, TextBox)
            ' agregar el controlador de eventos para el KeyPress  
            AddHandler validar.KeyPress, AddressOf Validar_Keypress_Nros_Grilla
        End If
    End Sub

    Private Sub Grilla_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)

        Dim _Fila As DataGridViewRow = Fm_Hijo.Grilla.Rows(Fm_Hijo.Grilla.CurrentRow.Index)

        Dim _Codigo = _Fila.Cells("Codigo").Value
        Dim _Descripcion = _Fila.Cells("Descripcion").Value

        If _Codigo = _Codigo_Seleccionado Then
            Return
        End If

        Fm_Hijo.Grill_Mensual.DataSource = Nothing
        Fm_Hijo.Grilla_Semanal.DataSource = Nothing

        Timer1.Enabled = False
        Timer1.Enabled = True

    End Sub

    Private Sub Grilla_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)

        Try

            Dim Grilla = CType(sender, DataGridView)

            Dim _Cabeza = Grilla.Columns(Grilla.CurrentCell.ColumnIndex).Name
            Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)
            Dim _Tecla As Keys = e.KeyValue

            Dim _Codigo As String = _Fila.Cells("Codigo").Value
            Dim _UnTrans As Integer

            If Rdb_Ud1_Compra.Checked Then : _UnTrans = 1 : Else : _UnTrans = 2 : End If

            Select Case _Tecla

                Case Keys.Enter

                    If _Cabeza = "CantComprar" Then

                        ' Hay que poner una opción aca


                        'If Not Fr_Alerta_Stock.Visible Then

                        '    Fr_Alerta_Stock = New AlertCustom(_Codigo, _UnTrans)
                        '    ShowLoadAlert(Fr_Alerta_Stock, Me)

                        'End If

                        Grilla.Columns(_Cabeza).ReadOnly = False
                        Grilla.BeginEdit(True)

                    End If

                    e.SuppressKeyPress = False
                    e.Handled = True

                Case Keys.Down, Keys.Up, Keys.Next, Keys.Prior

                    Fm_Hijo.LblProveedorProducto.Text = String.Empty

                    Fm_Hijo.Grill_Mensual.DataSource = Nothing
                    Fm_Hijo.Grilla_Semanal.DataSource = Nothing

                    Timer1.Enabled = False

                Case Keys.Delete

                    e.Handled = True
                    If _Cabeza = "CantComprar" Then
                        _Fila.Cells("CantComprar").Value = 0
                    End If

            End Select
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Grilla_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)

        Try

            Dim _Fila As DataGridViewRow = sender.Rows(sender.CurrentRow.Index)

            If _Fila.Cells("Informacion_Fila").Value = String.Empty Then
                Sb_Informacion_Fila_activa(_Fila)
            End If

            Fm_Hijo.LblProveedorProducto.Text = _Fila.Cells("Informacion_Fila").Value

            'Dim _ForeColor As Color = _Fila.DefaultCellStyle.ForeColor
            'Dim _BackColor As Color = _Fila.DefaultCellStyle.BackColor

            Fm_Hijo.LblProveedorProducto.ForeColor = _Fila.DefaultCellStyle.ForeColor
            Fm_Hijo.LblProveedorProducto.BackColor = _Fila.DefaultCellStyle.BackColor

            Me.Refresh()

            Dim _Codigo = Trim(_Fila.Cells("Codigo").Value)
            _Dv2.RowFilter = String.Format("Codigo = '{0}'", _Codigo)

        Catch ex As Exception
            Fm_Hijo.LblProveedorProducto.Text = String.Empty
        End Try

    End Sub

    Private Sub Grilla_RowEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)


    End Sub

    Sub Sb_Informacion_Fila_activa(ByVal _Fila As DataGridViewRow)

        Dim _Informacion_Fila As String

        'Dim _Ud
        'If Rdb_Ud1_Compra.Checked Then : _Ud = 1 : Else : _Ud = 2 : End If

        Dim _Codigo = _Fila.Cells("Codigo").Value
        Dim _Descripcion = _Fila.Cells("Descripcion").Value
        Dim _CodAlternativo = NuloPorNro(_Fila.Cells("CodAlternativo").Value, "").ToString.Trim

        Dim _RazonProveedor As String

        Dim _Endo = Trim(NuloPorNro(_Fila.Cells("CodProveedor").Value, ""))
        Dim _Suendo = Trim(NuloPorNro(_Fila.Cells("CodSucProveedor").Value, ""))

        _RazonProveedor = Trim(_Sql.Fx_Trae_Dato("MAEEN", "NOKOEN", "KOEN = '" & _Endo & "' And SUEN = '" & _Suendo & "'"))

        If String.IsNullOrEmpty(_Endo) Then
            _Informacion_Fila = "SIN PROVEEDOR, " & _Descripcion
        Else
            _Informacion_Fila = _RazonProveedor & ", Código Proveedor: [" & _CodAlternativo & "], " & _Descripcion
        End If

        Dim _Refleo As Boolean = _Fila.Cells("Refleo").Value
        Dim _Sospecha_Baja_Rotacion As Boolean = _Fila.Cells("Sospecha_Baja_Rotacion").Value
        Dim _IdGDD As Integer = NuloPorNro(_Fila.Cells("IdGDD").Value, 0)


        Dim CodAlternativo = Trim(_Sql.Fx_Trae_Dato("TABCODAL", "KOPRAL", "KOPR = '" & _Codigo & "' And KOEN = '" & _Endo & "'"))
        Dim Descripcion_Alternativo = Trim(_Sql.Fx_Trae_Dato("TABCODAL", "NOKOPRAL", "KOPR = '" & _Codigo & "' And KOEN = '" & _Endo & "' And KOPRAL = '" & _CodAlternativo & "'"))

        Dim _Nokoen As String = Trim(_Sql.Fx_Trae_Dato("MAEEN", "NOKOEN", "KOEN = '" & _Endo & "' And SUEN = '" & _Suendo & "'"))

        If String.IsNullOrEmpty(_Endo) Then
            _Informacion_Fila = "SIN PROVEEDOR, " & _Descripcion
        Else
            _Informacion_Fila = _Nokoen & ", Código Proveedor: [" & _CodAlternativo & "], " & Descripcion_Alternativo
        End If

        If _Refleo Then
            _Informacion_Fila += Space(1) & " ***** [REFLEO] (VENTA CALZADA)****"
        End If

        If _Sospecha_Baja_Rotacion Then
            _Informacion_Fila += Space(1) & " ***** [PRODUCTO SOSPECHOSO DE BAJA ROTACION] ****"
        End If

        If _IdGDD Then
            _Informacion_Fila += Space(1) & " ***** [TIENE GUIA DE DESPACHO POR DEVOLUCION PENDIENTE DE NCC] ****"
        End If

        Dim _CantComprar As Double = _Fila.Cells("CantComprar").Value
        Dim _CantSugeridaTot As Double = _Fila.Cells("CantSugeridaTot").Value

        If _CantSugeridaTot = 0 Then
            If _CantComprar > _CantSugeridaTot Then
                _Informacion_Fila += Space(1) & " ***** [CANTIDAD A COMPRAR MAYOR A LO SUGERIDO] ****"
            End If
        End If

        Dim _Color_Fila As Color = _Fila.DefaultCellStyle.BackColor ' = Color.Khaki

        _Fila.Cells("Informacion_Fila").Value = _Informacion_Fila
        Fm_Hijo.LblProveedorProducto.BackColor = _Color_Fila
        Me.Refresh()

    End Sub


    Private Sub Grilla_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        Dim _Tecla As Keys = e.KeyValue

        If _Tecla = Keys.Down Or _Tecla = Keys.Up Or _Tecla = Keys.Next Or _Tecla = Keys.Prior Then
            Fm_Hijo.GroupBox5.Visible = True
            Timer1.Enabled = True
        End If
    End Sub

    Private Sub Grilla_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)

        Dim Grilla = CType(sender, DataGridView)

        If e.Button = Windows.Forms.MouseButtons.Right Then
            With sender
                Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)
                If Hitest.Type = DataGridViewHitTestType.Cell Then
                    .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)

                    Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

                    Dim _Star = NuloPorNro(_Fila.Cells("Star").Value, 0)
                    Rt_Star.Rating = _Star

                    ShowContextMenu(Menu_Contextual_Productos)

                End If
            End With
        End If
    End Sub

    Private Sub Grilla_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) 'Handles Grilla.CellFormatting

        Dim _Tiempo_Stock = Input_Tiempo_Reposicion.Value

        Dim _Columname As String = sender.Columns(e.ColumnIndex).Name
        Dim _Fila As DataGridViewRow = sender.Rows(e.RowIndex)

        'If _Columname.Contains("Select") Then

        '    Dim _Valor As Boolean = e.Value
        '    Dim _Color As Color
        '    If _Valor Then
        '        If Global_Thema = Enum_Themas.Oscuro Then
        '            _Color = Azul
        '        Else
        '            _Color = Color.Blue
        '        End If
        '        Grilla.Rows(e.RowIndex).Cells("CostoUd1").Style.ForeColor = _Color
        '        Grilla.Rows(e.RowIndex).Cells("CostoUd2").Style.ForeColor = _Color
        '    End If

        'End If

        Dim ContadorDsctos As Integer = 0

        Dim _TStock As Double

        Dim StockUd1 As Double
        Dim StockUd2 As Double

        Dim Bloqueapr As String

        Dim _Codigo = _Fila.Cells("Codigo").Value
        Dim _Descripcion = _Fila.Cells("Descripcion").Value

        Dim CantSugeridaTot As Double = 0

        _Fila.Cells("Orden").Value = _Fila.Index

        Bloqueapr = NuloPorNro(_Fila.Cells("Bloqueapr").Value, "")

        StockUd1 = NuloPorNro(_Fila.Cells("StockUd1").Value, 0)
        StockUd2 = NuloPorNro(_Fila.Cells("StockUd2").Value, 0)


        _TStock = NuloPorNro(_Fila.Cells("TStock").Value, 2)

        If Global_Thema = Enum_Themas.Oscuro Then
            _Fila.DefaultCellStyle.ForeColor = Color.White
        Else
            _Fila.DefaultCellStyle.ForeColor = Color.Black
        End If

        Dim _Stock As Double

        If Rdb_Ud1_Compra.Checked Then
            _Stock = StockUd1
        Else
            _Stock = StockUd2
        End If

        Dim Stock_Critico = NuloPorNro(_Fila.Cells("Stock_CriticoUd" & Ud & "_Rd").Value, 0)
        Dim Con_Stock_Critico As Boolean = _Fila.Cells("Con_Stock_CriticoUd" & Ud).Value

        If Stock_Critico >= _Stock Then
            Con_Stock_Critico = True
        Else
            Con_Stock_Critico = False
        End If

        If Con_Stock_Critico Then

            _Fila.Cells("Stock_Fisico_Ud" & Ud).Style.ForeColor = Rojo
            _Fila.Cells("StockUd" & Ud).Style.ForeColor = Rojo
            _Fila.Cells("Stock_CriticoUd" & Ud & "_Rd").Style.ForeColor = Rojo

        End If

        If _TStock <= _Tiempo_Stock Then _Fila.Cells("TStock").Style.ForeColor = Rojo

        If Global_Thema = Enum_Themas.Oscuro Then

            _Fila.Cells("StockUd1").Style.ForeColor = Color.Black
            _Fila.Cells("StockUd2").Style.ForeColor = Color.Black
            _Fila.Cells("CantComprar").Style.ForeColor = Color.Black

        End If

        _Fila.Cells("StockUd1").Style.BackColor = Color.LightGray
        _Fila.Cells("StockUd2").Style.BackColor = Color.LightGray
        _Fila.Cells("CantComprar").Style.BackColor = Color.FromArgb(253, 227, 102) 'Color.Yellow

        _Fila.Cells("Descripcion").Style.Font = New Font(Fm_Hijo.Grilla.Font.Name, 7)

        _Fila.Cells("CantComprar").Style.Font = New Font(Fm_Hijo.Grilla.Font.Name, Fm_Hijo.Grilla.Font.Size, FontStyle.Bold)
        _Fila.Cells("CantComprar").Style.Alignment = DataGridViewContentAlignment.MiddleRight

        _Fila.Cells("CantSugeridaTot").Style.Font = New Font(Fm_Hijo.Grilla.Font.Name, Fm_Hijo.Grilla.Font.Size, FontStyle.Bold)
        _Fila.Cells("CantSugeridaTot").Style.Alignment = DataGridViewContentAlignment.MiddleRight

        Dim OccGenerada As Boolean = _Fila.Cells("OccGenerada").Value

        If Bloqueapr = "C" Or Bloqueapr = "T" Or OccGenerada Then

            _Fila.DefaultCellStyle.ForeColor = Color.Gray

        End If

        Dim _Cantidad = NuloPorNro(_Fila.Cells("CantComprar").Value, 0)
        Dim _RotacionDiaria = NuloPorNro(_Fila.Cells("RotDiariaUd" & Ud).Value, 0)
        Dim _RotacionMensual = NuloPorNro(_Fila.Cells("RotMensualUd" & Ud).Value, 0)

        If _Cantidad > 0 And _RotacionDiaria > 0 Then

            Dim _Alcanza As Double
            Dim _Rotacion As Double

            If Cmb_Metodo_Abastecer_Dias_Meses.SelectedValue = 1 Then
                _Rotacion = _RotacionDiaria
            ElseIf Cmb_Metodo_Abastecer_Dias_Meses.SelectedValue = 30 Then
                _Rotacion = _RotacionMensual
            End If


            If Chk_Restar_Stok_Bodega.Checked Then
                _Alcanza = Math.Round((_Cantidad + _Stock) / _Rotacion, 0)
            Else
                _Alcanza = Math.Round((_Cantidad) / _Rotacion, 0)
            End If

            _Fila.Cells("DiasdeAvas_Rd").Value = _Alcanza
        Else
            _Fila.Cells("DiasdeAvas_Rd").Value = 0
        End If

        Dim _Advierte_Rotacion = _Fila.Cells("Advierte_Rotacion").Value

        If _Advierte_Rotacion Then _Fila.Cells("RotDiariaUd" & Ud).Style.ForeColor = Rojo

        Dim _Refleo As Boolean = _Fila.Cells("Refleo").Value

        If _Refleo Then

            If Global_Thema = Enum_Themas.Oscuro Then _Fila.DefaultCellStyle.ForeColor = Color.Black
            _Fila.DefaultCellStyle.BackColor = Color.SandyBrown

        End If

        Dim _Sospecha_Baja_Rotacion As Boolean = _Fila.Cells("Sospecha_Baja_Rotacion").Value

        If _Sospecha_Baja_Rotacion And Not _Refleo Then

            If Global_Thema = Enum_Themas.Oscuro Then
                _Fila.DefaultCellStyle.ForeColor = Color.Black
            End If

            _Fila.DefaultCellStyle.BackColor = Color.Khaki

        End If

        Dim _CantComprar = _Fila.Cells("CantComprar").Value
        Dim _CantSugeridaTot = _Fila.Cells("CantSugeridaTot").Value

        If _CantSugeridaTot = 0 Then

            If CBool(_CantComprar) Then

                If _CantComprar > _CantSugeridaTot Then
                    _Fila.Cells("Codigo").Style.ForeColor = Rojo
                    _Fila.Cells("Descripcion").Style.ForeColor = Rojo
                End If

            End If

            _Fila.Cells("CantSugeridaTot").Style.ForeColor = Color.Gray

        End If

        Dim _IdGDD As Integer = NuloPorNro(Val(_Fila.Cells("IdGDD").Value), 0)

        If CBool(_IdGDD) Then

            If Global_Thema = Enum_Themas.Oscuro Then
                _Fila.DefaultCellStyle.ForeColor = Color.Black
            End If

            _Fila.DefaultCellStyle.BackColor = Color.Plum

            If CBool(_CantComprar) Then
                _Fila.Cells("Descripcion").Style.Font = New Font(Font.Name, Font.Size, FontStyle.Regular)
            Else
                _Fila.Cells("Descripcion").Style.Font = New Font(Font.Name, Font.Size, FontStyle.Strikeout)
            End If

        End If

        Dim _Fecha_Ult_Venta As Date = NuloPorNro(_Fila.Cells("Fecha_Ult_Venta").Value, #01-01-1990#)

        If Chk_Sacar_Productos_Sin_Rotacion.Checked Then
            If _Fecha_Productos_Sin_Rotacion > _Fecha_Ult_Venta Then
                _Fila.DefaultCellStyle.Font = New Font(Font.Name, Font.Size, FontStyle.Strikeout)
            End If
        Else
            _Fila.DefaultCellStyle.Font = New Font(Font.Name, Font.Size, FontStyle.Regular)
        End If


        Dim _Sospecha_Familia As Integer = _Fila.Cells("Sospecha_Familia").Value

        If _Sospecha_Familia > 1 Then

            If Global_Thema = Enum_Themas.Oscuro Then
                _Fila.DefaultCellStyle.ForeColor = Color.Black
            End If

            _Fila.Cells("Codigo").Style.BackColor = Color.Yellow
            _Fila.Cells("Descripcion").Style.BackColor = Color.Yellow

        End If

        If Chk_Trabajando_Con_Proyeccion.Checked Then

            _Fila.Cells("Stock_Fisico_Ud" & Ud).Style.ForeColor = Color.Gray

            If Chk_Trabajando_Con_Proyeccion.Checked Then

                If _TStock < Input_Dias_a_Abastecer.Value Then _Fila.Cells("TStock").Style.ForeColor = Rojo

            End If

            Dim _StockPedidoUd As Double = _Fila.Cells("StockPedidoUd" & Ud).Value

            If Not CBool(_StockPedidoUd) Then _Fila.Cells("StockPedidoUd" & Ud).Style.ForeColor = Color.Gray

        End If

    End Sub


#End Region

#Region "PROCEDIMIENTOS INFORME PRINCIPAL GRILLA PRINCIPAL"

    Sub Sb_Refrescar_Grilla_Principal(Grilla As DataGridView,
                                      _Actualizar_Rotacion As Boolean,
                                      _Actualizar_Stock As Boolean)
        Me.Enabled = False

        RemoveHandler Grilla.CellEndEdit, AddressOf Grilla_CellEndEdit
        RemoveHandler Grilla.CellBeginEdit, AddressOf Grilla_CellBeginEdit
        RemoveHandler Grilla.EditingControlShowing, AddressOf Grilla_EditingControlShowing
        RemoveHandler Grilla.CellClick, AddressOf Grilla_CellClick
        RemoveHandler Grilla.KeyDown, AddressOf Grilla_KeyDown
        RemoveHandler Grilla.CellEnter, AddressOf Grilla_CellEnter
        RemoveHandler Grilla.KeyUp, AddressOf Grilla_KeyUp
        RemoveHandler Grilla.MouseDown, AddressOf Grilla_MouseDown
        'RemoveHandler Grilla.CellFormatting, AddressOf Grilla_CellFormatting

        Input_Tiempo_Reposicion.Enabled = True

        Sb_Actualizar_Ranking()

        Sb_Actualizar_Costos()

        If _Actualizar_Stock Then Sb_Actualizar_Stock()

        Sb_Actualizar_Rotacion("", _Actualizar_Rotacion)

        'Sb_Actualizar_Ult3ComprasXprodVsProveedor()

        Sb_Grilla_Actualizar_Informe(Grilla)

        Sb_Grilla_Marcar(Grilla, False)

        AddHandler Grilla.CellEndEdit, AddressOf Grilla_CellEndEdit
        AddHandler Grilla.CellBeginEdit, AddressOf Grilla_CellBeginEdit
        AddHandler Grilla.EditingControlShowing, AddressOf Grilla_EditingControlShowing
        AddHandler Grilla.CellClick, AddressOf Grilla_CellClick
        AddHandler Grilla.KeyDown, AddressOf Grilla_KeyDown
        AddHandler Grilla.CellEnter, AddressOf Grilla_CellEnter

        AddHandler Grilla.KeyUp, AddressOf Grilla_KeyUp
        AddHandler Grilla.MouseDown, AddressOf Grilla_MouseDown

        'AddHandler Grilla.CellFormatting, AddressOf Grilla_CellFormatting

        If Not String.IsNullOrEmpty(Fm_Hijo.Txt_Descripcion.Text) Then
            _Dv.RowFilter = String.Format("Codigo+Descripcion Like '%{0}%'", Trim(Fm_Hijo.Txt_Descripcion.Text))
            Sb_Grilla_Marcar(Grilla, False)
        End If

        Fm_Hijo.Chk_Ver_Doc_Solo_Proveedor.Enabled = Not IsNothing(_RowProveedor)
        Fm_Hijo.LabelX7.Text = "Stock físico bodegas empresa, Ud" & _Ud

        Me.Enabled = True

    End Sub

    Sub Sb_Actualizar_Ranking()

        Consulta_sql = "Update " & _Nombre_Tbl_Paso_Informe & " Set" & vbCrLf &
                       "Ranking_Top = (Select top 1 Ranking_Top From " & _Global_BaseBk & "Zw_Prod_Ranking" & vbCrLf &
                       "Where " & _Global_BaseBk & "Zw_Prod_Ranking.Codigo = " & _Nombre_Tbl_Paso_Informe & ".Codigo)" & vbCrLf &
                       "Update " & _Nombre_Tbl_Paso_Informe & " Set" & vbCrLf &
                       "Clasificacion_Rk = (Select top 1 Clasificacion From " & _Global_BaseBk & "Zw_Prod_Ranking" & vbCrLf &
                       "Where " & _Global_BaseBk & "Zw_Prod_Ranking.Codigo = " & _Nombre_Tbl_Paso_Informe & ".Codigo)" & vbCrLf &
                       "Update " & _Nombre_Tbl_Paso_Informe & " Set" & vbCrLf &
                       "Star = (Select top 1 Star From " & _Global_BaseBk & "Zw_Prod_Ranking" & vbCrLf &
                       "Where " & _Global_BaseBk & "Zw_Prod_Ranking.Codigo = " & _Nombre_Tbl_Paso_Informe & ".Codigo)"
        _Sql.Ej_consulta_IDU(Consulta_sql)


        Consulta_sql = "Update " & _Nombre_Tbl_Paso_Informe & " Set" & vbCrLf &
                       "Ranking_Top = (Select COUNT(*) FROM MAEPR)" & vbCrLf &
                       "Where Codigo not in (Select Codigo From " & _Global_BaseBk & "Zw_Prod_Ranking)"
        _Sql.Ej_consulta_IDU(Consulta_sql)

    End Sub

    Sub Sb_Actualizar_Rotacion(_Codigo As String,
                               _Actualizar_Dias_Stock_En_Bodega As Boolean)

        Me.Enabled = False

        Me.Cursor = Cursors.WaitCursor
        Me.Refresh()

        With _Clas_Asistente_Compras

            .Pro_Chk_Advertir_Rotacion = False
            .Pro_Chk_Sabado = Chk_Sabado.Checked
            .Pro_Chk_Domingo = Chk_Domingo.Checked
            .Pro_Chk_Restar_Stok_Bodega = Chk_Restar_Stok_Bodega.Checked
            .Pro_Chk_Rotacion_Con_Ent_Excluidas = Chk_Rotacion_Con_Ent_Excluidas.Checked
            .Pro_Chk_Trabajando_Con_Proyeccion = Chk_Trabajando_Con_Proyeccion.Checked

            .Pro_Input_Dias_a_Abastecer = Input_Dias_a_Abastecer.Value
            .Pro_Input_Dias_Advertencia_Rotacion = Input_Dias_a_Abastecer.Value
            .Pro_Input_Porc_Crecimiento = Input_Porc_Crecimiento.Value
            .Pro_Input_Tiempo_Reposicion = Input_Tiempo_Reposicion.Value
            .Pro_Proceso_Automatico_Ejecutado = _Proceso_Automatico_Ejecutado
            .Pro_Rdb_Agrupar_x_Asociados = Rdb_Agrupar_x_Asociados.Checked
            .Pro_Rdb_Ud1_Compra = Rdb_Ud1_Compra.Checked
            .Pro_Rdb_Ud2_Compra = Rdb_Ud2_Compra.Checked

            .Pro_Filtro_Bodegas_Todas = _Filtro_Bodegas_Todas
            .Pro_Tbl_Filtro_Bodegas = _TblBodCompra
            .Rdb_RotDias = _Rdb_RotDias
            .Rdb_RotMeses = _Rdb_RotMeses
            .Rdb_Rot_Mediana = Rdb_Rot_Mediana.Checked
            .Rdb_Rot_Promedio = Rdb_Rot_Promedio.Checked

            If Cmb_Metodo_Abastecer_Dias_Meses.SelectedValue = 1 Then
                .Pro_Proyeccion_Metodo_Abastecer = Clas_Asistente_Compras.Enum_Proyeccion.Dias
            ElseIf Cmb_Metodo_Abastecer_Dias_Meses.SelectedValue = 30 Then
                .Pro_Proyeccion_Metodo_Abastecer = Clas_Asistente_Compras.Enum_Proyeccion.Meses
            End If

            If Cmb_Tiempo_Reposicion_Dias_Meses.SelectedValue = 1 Then
                .Pro_Proyeccion_Tiempo_Reposicion = Clas_Asistente_Compras.Enum_Proyeccion.Dias
            ElseIf Cmb_Metodo_Abastecer_Dias_Meses.SelectedValue = 30 Then
                .Pro_Proyeccion_Tiempo_Reposicion = Clas_Asistente_Compras.Enum_Proyeccion.Meses
            End If

            .Sb_Actualizar_Rotacion(_Codigo, _Actualizar_Dias_Stock_En_Bodega)

        End With

        Me.Cursor = Cursors.Default
        Me.Enabled = True

    End Sub

    Sub Sb_Actualizar_Rotacion_Old(Optional ByVal _Codigo As String = "")

        Try
            Me.Enabled = False

            Me.Cursor = Cursors.WaitCursor
            Me.Refresh()

            Dim _UsarSabado = CInt(Chk_Sabado.Checked) * -1
            Dim _UsarDomingo = CInt(Chk_Domingo.Checked) * -1

            Dim _Dias_Abastecer As Integer ' = Input_Dias_a_Abastecer.Value
            Dim _Meses_Abastecer As Double ' = Input_Dias_a_Abastecer.Value

            Dim _Tiempo_Reposicion = Input_Tiempo_Reposicion.Value
            Dim _Tiempo_Reposicion_Mensual As Double

            Dim _Porc_Cre = 1 + (Input_Porc_Crecimiento.Value / 100) 'Input_Porc_Crecimiento.Value 
            Dim _Porc_Crecimiento As String = De_Num_a_Tx_01(_Porc_Cre)

            Dim _DM_Proyec_Tr, _DM_Abastecer As Double

            If Cmb_Tiempo_Reposicion_Dias_Meses.Text = "meses" Then
                _DM_Proyec_Tr = 365 / 12
            Else
                _DM_Proyec_Tr = 1
            End If

            If Cmb_Metodo_Abastecer_Dias_Meses.Text = "meses" Then
                _DM_Abastecer = Math.Round(365 / 12, 5)
            Else
                _DM_Abastecer = 1
            End If

            _Tiempo_Reposicion = Input_Tiempo_Reposicion.Value * _DM_Proyec_Tr 'Cmb_Proyeccion_Tiempo_Reposicion.SelectedValue
            _Dias_Abastecer = Input_Dias_a_Abastecer.Value * _DM_Abastecer 'Cmb_Proyeccion_Metodo_Abastecer.SelectedValue ' + _Tiempo_Reposicion

            Dim _Dias_Proyeccion = Fx_Dias_Proyeccion() '= Input_Dias_a_Abastecer.Value * Cmb_Proyeccion_Metodo_Abastecer.SelectedValue + _Tiempo_Reposicion

            _Meses_Abastecer = Math.Round(_Dias_Abastecer / _DM_Abastecer, 1) 'Cmb_Proyeccion_Metodo_Abastecer.SelectedValue '_Dias_Proyeccion
            _Tiempo_Reposicion_Mensual = Math.Round(_Tiempo_Reposicion / _DM_Proyec_Tr, 1) 'Cmb_Proyeccion_Tiempo_Reposicion.SelectedValue

            Dim _Fecha_Fin = DateAdd(DateInterval.Day, _Dias_Abastecer, FechaDelServidor)

            'DIAS HABILES A ABASTECER
            _Dias_Abastecer = Fx_Cuenta_Dias(FechaDelServidor, _Fecha_Fin, Opcion_Dias.Habiles)


            Dim _Sabados As Integer = Fx_Cuenta_Dias(FechaDelServidor, _Fecha_Fin, Opcion_Dias.Sabado)
            Dim _Domingos As Integer = Fx_Cuenta_Dias(FechaDelServidor, _Fecha_Fin, Opcion_Dias.Domingo)
            Dim _RestarStock = CInt(Chk_Restar_Stok_Bodega.Checked)

            'Dim _Ud
            'If Rdb_Ud1_Compra.Checked Then : _Ud = 1 : Else : _Ud = 2 : End If

            Consulta_sql = My.Resources.Recursos_Asis_Compras.SQLQuery_Actualizar_Rotacion_Dias_Con_Stock_En_Bodega

            Consulta_sql = Replace(Consulta_sql, "#TablaPaso#", _Nombre_Tbl_Paso_Informe)
            Consulta_sql = Replace(Consulta_sql, "#Ud#", _Ud)
            Consulta_sql = Replace(Consulta_sql, "#UsarSabado#", _UsarSabado)
            Consulta_sql = Replace(Consulta_sql, "#UsarDomingo#", _UsarDomingo)
            Consulta_sql = Replace(Consulta_sql, "#Tiempo_Reposicion#", _Tiempo_Reposicion)
            Consulta_sql = Replace(Consulta_sql, "#Dias_Avastecer#", _Dias_Abastecer)
            Consulta_sql = Replace(Consulta_sql, "#Porc_Crecimiento#", _Porc_Crecimiento)
            Consulta_sql = Replace(Consulta_sql, "#RestarStock#", _RestarStock)
            Consulta_sql = Replace(Consulta_sql, "Zw_Prod_Rotacion", _Global_BaseBk & "Zw_Prod_Rotacion")

            Dim _Filtro_Bodega As String
            Dim _Filtro_Asociados As String


            If _Filtro_Bodegas_Todas Then
                _Filtro_Bodega = String.Empty
            Else
                _Filtro_Bodega = Generar_Filtro_IN(_TblBodCompra, "Chk", "Codigo", False, True, "'")
                _Filtro_Bodega = "And Empresa+Sucursal+Bodega In " & _Filtro_Bodega
            End If

            If Chk_Rotacion_Con_Ent_Excluidas.Checked Then
                _Filtro_Bodega += Space(1) & "And Con_Ent_Excluidas = 1" ' -- And Es_Asociador = 0
            Else
                _Filtro_Bodega += Space(1) & "And Con_Ent_Excluidas = 0" '  -- And Es_Asociador = 0"
            End If

            Dim _Filtro_Productos = String.Empty

            Consulta_sql = Replace(Consulta_sql, "#Filtro_Productos#", _Filtro_Productos)
            Consulta_sql = Replace(Consulta_sql, "#Sql_Actualizar_Rotacion#", "")
            Consulta_sql = Replace(Consulta_sql, "#Filtro_Bodega#", _Filtro_Bodega)
            Consulta_sql = Replace(Consulta_sql, "#Filtro_Asociados#", "")

            _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql)


            Dim _Update_Dias As String

            _Update_Dias = "Update " & _Nombre_Tbl_Paso_Informe & " Set Dias_Calculo = Dias_Existencia_Habiles" & vbCrLf

            If Chk_Sabado.Checked Then
                _Update_Dias += "+Dias_Existencia_Sabados" & vbCrLf
            End If

            If Chk_Domingo.Checked Then
                _Update_Dias += "+Dias_Existencia_Domingos" & vbCrLf
            End If

            _Update_Dias += "Where Es_Agrupador = 0"
            _Sql.Ej_consulta_IDU(_Update_Dias)

            Consulta_sql = "Update " & _Nombre_Tbl_Paso_Informe & " Set" & Space(1) &
                           "RotDiariaUd1 = Case When Dias_Calculo > 0 Then ROUND(SumTotalQtyUd1/Dias_Calculo,3) Else 0 End," & vbCrLf &
                           "RotDiariaUd2 = Case When Dias_Calculo > 0 Then ROUND(SumTotalQtyUd2/Dias_Calculo,3) Else 0 End" & vbCrLf &
                           "Where Es_Agrupador = 0" & vbCrLf & _Filtro_Productos
            _Sql.Ej_consulta_IDU(Consulta_sql)


            ' ACTUALIZAR LOS DATOS DE LOS PRODUCTOS AGRUPADORES *************************

            _Update_Dias = "Update " & _Nombre_Tbl_Paso_Informe & " Set Dias_Calculo = (Select Max(Dias_Existencia_Habiles) From " & _Nombre_Tbl_Paso_Informe & Space(1) &
                           "Z1 Where Z1.CodigoGenerico = " & _Nombre_Tbl_Paso_Informe & ".CodigoGenerico)" & vbCrLf

            If Chk_Sabado.Checked Then
                _Update_Dias += "+(Select Max(Dias_Existencia_Sabados) From " & _Nombre_Tbl_Paso_Informe & Space(1) &
                                "Z1 Where Z1.CodigoGenerico = " & _Nombre_Tbl_Paso_Informe & ".CodigoGenerico)" & vbCrLf
            End If

            If Chk_Domingo.Checked Then
                _Update_Dias += "+(Select Max(Dias_Existencia_Domingos) From " & _Nombre_Tbl_Paso_Informe & Space(1) &
                                "Z1 Where Z1.CodigoGenerico = " & _Nombre_Tbl_Paso_Informe & ".CodigoGenerico)" & vbCrLf
            End If

            _Update_Dias += "Where Es_Agrupador = 1" & vbCrLf

            Consulta_sql = _Update_Dias & vbCrLf &
                           "Update " & _Nombre_Tbl_Paso_Informe & " Set " & vbCrLf &
                           "StockPedidoUd1 = (Select Sum(StockPedidoUd1) From " & _Nombre_Tbl_Paso_Informe & " Tb1" & Space(1) &
                           "Where Tb1.CodigoGenerico = Tb2.CodigoGenerico And Es_Agrupador = 0)," & vbCrLf &
                           "StockPedidoUd2 = (Select Sum(StockPedidoUd2) From " & _Nombre_Tbl_Paso_Informe & " Tb1" & Space(1) &
                           "Where Tb1.CodigoGenerico = Tb2.CodigoGenerico And Es_Agrupador = 0)," & vbCrLf &
                           "SumTotalQtyUd1 = (Select Sum(SumTotalQtyUd1) From " & _Nombre_Tbl_Paso_Informe & " Tb1 Where Tb1.CodigoGenerico = Tb2.CodigoGenerico And Tb1.Es_Agrupador = 0)," & vbCrLf &
                           "SumTotalQtyUd2 = (Select Sum(SumTotalQtyUd2) From " & _Nombre_Tbl_Paso_Informe & " Tb1 Where Tb1.CodigoGenerico = Tb2.CodigoGenerico And Tb1.Es_Agrupador = 0)," & vbCrLf &
                           "StockUd1 = (Select Sum(StockUd1) From " & _Nombre_Tbl_Paso_Informe & " Tb1 Where Tb1.CodigoGenerico = Tb2.CodigoGenerico And Tb1.Es_Agrupador = 0)," & vbCrLf &
                           "StockUd2 = (Select Sum(StockUd2) From " & _Nombre_Tbl_Paso_Informe & " Tb1 Where Tb1.CodigoGenerico = Tb2.CodigoGenerico And Tb1.Es_Agrupador = 0)," & vbCrLf &
                           "Stock_Fisico_Ud1 = (Select Sum(StockUd1) From " & _Nombre_Tbl_Paso_Informe & " Tb1 Where Tb1.CodigoGenerico = Tb2.CodigoGenerico And Tb1.Es_Agrupador = 0)," & vbCrLf &
                           "Stock_Fisico_Ud2 = (Select Sum(StockUd2) From " & _Nombre_Tbl_Paso_Informe & " Tb1 Where Tb1.CodigoGenerico = Tb2.CodigoGenerico And Tb1.Es_Agrupador = 0)," & vbCrLf &
                           "FCV = (Select Sum(FCV) From " & _Nombre_Tbl_Paso_Informe & " Tb1 Where Tb1.CodigoGenerico = Tb2.CodigoGenerico And Tb1.Es_Agrupador = 0)," & vbCrLf &
                           "BLV = (Select Sum(BLV) From " & _Nombre_Tbl_Paso_Informe & " Tb1 Where Tb1.CodigoGenerico = Tb2.CodigoGenerico And Tb1.Es_Agrupador = 0)," & vbCrLf &
                           "GDV = (Select Sum(GDV) From " & _Nombre_Tbl_Paso_Informe & " Tb1 Where Tb1.CodigoGenerico = Tb2.CodigoGenerico And Tb1.Es_Agrupador = 0)," & vbCrLf &
                           "NCV = (Select Sum(NCV) From " & _Nombre_Tbl_Paso_Informe & " Tb1 Where Tb1.CodigoGenerico = Tb2.CodigoGenerico And Tb1.Es_Agrupador = 0)," & vbCrLf &
                           "TDV = (Select Sum(TDV) From " & _Nombre_Tbl_Paso_Informe & " Tb1 Where Tb1.CodigoGenerico = Tb2.CodigoGenerico And Tb1.Es_Agrupador = 0)," & vbCrLf &
                           "Fecha_Ultima_Ejecucion = (Select Min(Fecha_Ultima_Ejecucion) From " & _Nombre_Tbl_Paso_Informe & " Tb1 Where Tb1.CodigoGenerico = Tb2.CodigoGenerico And Tb1.Es_Agrupador = 0)" & vbCrLf &
                           "From " & _Nombre_Tbl_Paso_Informe & " Tb2" &
                           vbCrLf &
                           vbCrLf &
                           "Where Es_Agrupador = 1" & vbCrLf &
                           "Update " & _Nombre_Tbl_Paso_Informe & " Set" & Space(1) &
                           "RotDiariaUd1 = Case When Dias_Calculo > 0 Then ROUND(SumTotalQtyUd1/Dias_Calculo,3) Else 0 End," & vbCrLf &
                           "RotDiariaUd2 = Case When Dias_Calculo > 0 Then ROUND(SumTotalQtyUd2/Dias_Calculo,3) Else 0 End" & vbCrLf &
                           "Where Es_Agrupador = 1"
            _Sql.Ej_consulta_IDU(Consulta_sql)

            Consulta_sql = "Update " & _Nombre_Tbl_Paso_Informe & " Set " & vbCrLf &
                           "RotMensualUd1 = RotDiariaUd1*" & _Dias_Proyeccion & "," & vbCrLf &
                           "RotMensualUd2 = RotDiariaUd2*" & _Dias_Proyeccion
            _Sql.Ej_consulta_IDU(Consulta_sql)
            '----------------------------------------------------------------------------------------

            Dim _Advertir_Rotacion As Boolean = _RowParametros.Item("Chk_Advertir_Rotacion")
            Dim _Dias_Advertir_Rotacion As Integer = _RowParametros.Item("Input_Dias_Advertencia_Rotacion")

            Dim _Fecha_Tope_Rotacion As Date = FormatDateTime(DateAdd(DateInterval.Day, -_Dias_Advertir_Rotacion, FechaDelServidor), DateFormat.ShortDate)
            Dim _Fecha_Rotacion As String = Format(_Fecha_Tope_Rotacion, "yyyMMdd")

            Consulta_sql = "Update " & _Nombre_Tbl_Paso_Informe & " Set Advierte_Rotacion = 0"
            _Sql.Ej_consulta_IDU(Consulta_sql)

            If _Advertir_Rotacion Then
                Consulta_sql = "Update " & _Nombre_Tbl_Paso_Informe & " Set Advierte_Rotacion = 1" & vbCrLf &
                               "Where Fecha_Ultima_Ejecucion < '" & _Fecha_Rotacion & "'"
                _Sql.Ej_consulta_IDU(Consulta_sql)
            End If

            If Chk_Trabajando_Con_Proyeccion.Checked Then

                If Cmb_Metodo_Abastecer_Dias_Meses.SelectedValue = 1 Then
                    Consulta_sql = "Update " & _Nombre_Tbl_Paso_Informe & " Set" & Space(1) &
                                   "StockUd" & Ud & " = Stock_Fisico_Ud" & Ud & "-(" & _Tiempo_Reposicion & " * RotDiariaUd" & Ud & ")" & vbCrLf &
                                   "Where Es_Agrupador = 1"
                Else
                    Consulta_sql = "Update " & _Nombre_Tbl_Paso_Informe & " Set" & Space(1) &
                                   "StockUd" & Ud & " = Stock_Fisico_Ud" & Ud & "-(" & _Tiempo_Reposicion_Mensual & " * RotMensualUd" & Ud & ")" & vbCrLf &
                                   "Where Es_Agrupador = 1"
                End If

            End If
            _Sql.Ej_consulta_IDU(Consulta_sql)

            If Cmb_Metodo_Abastecer_Dias_Meses.SelectedValue = 1 Then

                Consulta_sql = "Update " & _Nombre_Tbl_Paso_Informe & vbCrLf &
                               "Set TStock = Case" & vbCrLf &
                               "When RotDiariaUd" & Ud & " > 0 Then Case When StockUd" & Ud & " > 0 Then CEILING(ROUND(StockUd" & Ud & " / RotDiariaUd" & Ud & ",0)) else 0 end" & vbCrLf &
                               "When RotDiariaUd" & Ud & " <= 0 Then Case When StockUd" & Ud & " > 0 Then " & Input_Dias_a_Abastecer.Value & " else 0 end" & vbCrLf &
                               "End" & vbCrLf &
                               "Where(1 > 0)"
            Else

                Consulta_sql = "Update " & _Nombre_Tbl_Paso_Informe & vbCrLf &
                               "Set TStock = Case" & vbCrLf &
                               "When RotMensualUd" & Ud & " > 0 Then Case When StockUd" & Ud & " > 0 Then ROUND(StockUd" & Ud & "/RotMensualUd" & Ud & ",1) else 0 end" & vbCrLf &
                               "When RotMensualUd" & Ud & " <= 0 Then Case When StockUd" & Ud & " > 0 Then " & Input_Dias_a_Abastecer.Value & " else 0 end" & vbCrLf &
                               "End" & vbCrLf &
                               "Where(1 > 0)"

            End If
            _Sql.Ej_consulta_IDU(Consulta_sql)


            Dim _Tpo_Reposicion As String

            If Cmb_Tiempo_Reposicion_Dias_Meses.SelectedValue = 1 Then
                _Tpo_Reposicion = _Tiempo_Reposicion & " * RotDiariaUd"
            Else
                _Tpo_Reposicion = _Tiempo_Reposicion_Mensual & " * RotMensualUd"
            End If

            Consulta_sql = "Update " & _Nombre_Tbl_Paso_Informe & " Set Tiempo_Reposicion =" & _Tpo_Reposicion & Ud
            _Sql.Ej_consulta_IDU(Consulta_sql)

            If Cmb_Metodo_Abastecer_Dias_Meses.SelectedValue = 1 Then
                Consulta_sql = "Update " & _Nombre_Tbl_Paso_Informe & vbCrLf &
                               "Set Stock_CriticoUd1_Rd = CEILING(Round(" & _Tpo_Reposicion & "1,0))," & vbCrLf &
                               "Stock_CriticoUd2_Rd = CEILING(Round(" & _Tpo_Reposicion & "2,0))" & vbCrLf &
                               "Where 1 > 0" & vbCrLf & _Filtro_Productos

            Else
                Consulta_sql = "Update " & _Nombre_Tbl_Paso_Informe & vbCrLf &
                               "Set Stock_CriticoUd1_Rd = CEILING(Round(" & _Tpo_Reposicion & "1,0))," & vbCrLf &
                               "Stock_CriticoUd2_Rd = CEILING(Round(" & _Tpo_Reposicion & "2,0))" & vbCrLf &
                               "Where 1 > 0" & vbCrLf & _Filtro_Productos
            End If
            _Sql.Ej_consulta_IDU(Consulta_sql)
            '

            Consulta_sql = "Update " & _Nombre_Tbl_Paso_Informe & " Set StockUd1 = 0,StockUd2 = 0 Where StockUd" & Ud & " < 1"
            _Sql.Ej_consulta_IDU(Consulta_sql)

            Dim _Dias_Proyeccion_Venta = _Dias_Abastecer

            If Chk_Sabado.Checked Then _Dias_Proyeccion_Venta += _Sabados
            If Chk_Domingo.Checked Then _Dias_Proyeccion_Venta += _Domingos

            If Chk_Restar_Stok_Bodega.Checked Then
                If Cmb_Metodo_Abastecer_Dias_Meses.SelectedValue = 1 Then
                    Consulta_sql = "Update " & _Nombre_Tbl_Paso_Informe & " set" & vbCrLf &
                                   "CantSugeridaTot = ((RotDiariaUd" & Ud & "*" & _Dias_Proyeccion_Venta & ") * " & _Porc_Crecimiento & ") - StockUd" & Ud & vbCrLf &
                                   "Where 1 > 0" & vbCrLf & _Filtro_Productos
                Else
                    Consulta_sql = "Update " & _Nombre_Tbl_Paso_Informe & " set" & vbCrLf &
                                  "CantSugeridaTot = ((RotMensualUd" & Ud & "*" & _Meses_Abastecer & ") * " & _Porc_Crecimiento & ") - StockUd" & Ud & vbCrLf &
                                  "Where 1 > 0" & vbCrLf & _Filtro_Productos
                End If
            Else
                If Cmb_Metodo_Abastecer_Dias_Meses.SelectedValue = 1 Then
                    Consulta_sql = "Update " & _Nombre_Tbl_Paso_Informe & " set" & vbCrLf &
                                   "CantSugeridaTot = (" & _Dias_Proyeccion_Venta & " * RotDiariaUd" & Ud & ") * " & _Porc_Crecimiento & vbCrLf &
                                   "Where 1 > 0" & vbCrLf & _Filtro_Productos
                Else
                    Consulta_sql = "Update " & _Nombre_Tbl_Paso_Informe & " set" & vbCrLf &
                                   "CantSugeridaTot = (" & _Meses_Abastecer & " * (RotMensualUd" & Ud & ")) * " & _Porc_Crecimiento & vbCrLf &
                                   "Where 1 > 0" & vbCrLf & _Filtro_Productos
                End If
            End If

            _Sql.Ej_consulta_IDU(Consulta_sql)


            Consulta_sql = "UPDATE " & _Nombre_Tbl_Paso_Informe & " set Stock_CriticoUd1_Rd = 1" & vbCrLf &
                           "Where 1 > 0 And Stock_CriticoUd1_Rd = 0 " & _Filtro_Productos & vbCrLf &
                           "UPDATE " & _Nombre_Tbl_Paso_Informe & " set Stock_CriticoUd2_Rd = 1" & vbCrLf &
                           "Where 1 > 0 And Stock_CriticoUd2_Rd = 0 " & _Filtro_Productos & vbCrLf &
                           "UPDATE " & _Nombre_Tbl_Paso_Informe & " set Con_Stock_CriticoUd1 = 0 Where 1 > 0 " & _Filtro_Productos & vbCrLf &
                           "UPDATE " & _Nombre_Tbl_Paso_Informe & " set Con_Stock_CriticoUd2 = 0 Where 1 > 0 " & _Filtro_Productos
            _Sql.Ej_consulta_IDU(Consulta_sql)


            Consulta_sql = "Update " & _Nombre_Tbl_Paso_Informe & vbCrLf &
                           "Set CantSugeridaTot = 0 Where 1 > 0 And CantSugeridaTot < 0 " & _Filtro_Productos
            _Sql.Ej_consulta_IDU(Consulta_sql)


            Consulta_sql = "Update " & _Nombre_Tbl_Paso_Informe & vbCrLf &
                           "Set" & Space(1) &
                           "Con_Stock_CriticoUd1 = Case When (StockUd1 - Stock_CriticoUd1_Rd) < 0 Then 1 Else 0 End," & vbCrLf &
                           "Con_Stock_CriticoUd2 = Case When (StockUd2 - Stock_CriticoUd2_Rd) < 0 Then 1 Else 0 End" & vbCrLf &
                           "Where 1 > 0" & vbCrLf & _Filtro_Productos
            _Sql.Ej_consulta_IDU(Consulta_sql)

            Dim _Filtro_Es_Agrupador As String

            If _Proceso_Automatico_Ejecutado Then
                _Filtro_Es_Agrupador = "And Es_Agrupador = 1"
            Else
                _Filtro_Es_Agrupador = String.Empty
            End If

            Consulta_sql = "Update " & _Nombre_Tbl_Paso_Informe & " Set Comprar = 1" & vbCrLf &
                           "Where CantSugeridaTot > 0.45 And Comprar_Igual = 0" & vbCrLf &
                           _Filtro_Es_Agrupador & vbCrLf &
                           "Update " & _Nombre_Tbl_Paso_Informe & " Set Comprar = 0" & vbCrLf &
                           "Where CantSugeridaTot <= 0.45 And Comprar_Igual = 0" & vbCrLf &
                           _Filtro_Es_Agrupador

            _Sql.Ej_consulta_IDU(Consulta_sql)
            Sb_Actulizar_Refleo_Baja_Rotacion()

            Consulta_sql = "Update " & _Nombre_Tbl_Paso_Informe & " Set Sospecha_Familia = 0" & vbCrLf &
                           "Update " & _Nombre_Tbl_Paso_Informe & " Set" & vbCrLf &
                           "Sospecha_Familia = (Select COUNT(*) From " & _Nombre_Tbl_Paso_Informe & " Z2" & Space(1) &
                           "Where Z2.Codigo = Z1.Codigo And Z2.Es_Agrupador = 0 )" & vbCrLf &
                           "From " & _Nombre_Tbl_Paso_Informe & " Z1" & vbCrLf &
                           "Where Es_Agrupador = 1"
            _Sql.Ej_consulta_IDU(Consulta_sql)

        Catch ex As Exception
            MessageBoxEx.Show(ex.Message)
        Finally
            'Barra_Progreso.Value = 0
            'Barra_Progreso.Visible = False
            'Lbl_Actualizar_Rotacion.Visible = False
            Me.Cursor = Cursors.Default
            Me.Enabled = True
        End Try

        Me.Refresh()

    End Sub

    Function Fx_Actualizar_Rotacion_X_Prodcuto(ByVal _Fila As DataRow) As String


        Dim _Codigo As String = _Fila.Item("Codigo")

        If _Codigo = "" Then

        End If

        Dim _Dias_Habiles As Double = _Fila.Item("Dias_Existencia_Habiles")
        Dim _Dias_Sabado As Double = _Fila.Item("Dias_Existencia_Sabados")
        Dim _Dias_Domingo As Double = _Fila.Item("Dias_Existencia_Domingos")

        Dim _Dias_Calculo As Double

        _Dias_Calculo += _Dias_Habiles
        If Chk_Sabado.Checked Then _Dias_Calculo += _Dias_Sabado
        If Chk_Domingo.Checked Then _Dias_Calculo += _Dias_Domingo

        Dim _SumTotalQtyUd1 As Double = _Fila.Item("SumTotalQtyUd1")
        Dim _SumTotalQtyUd2 As Double = _Fila.Item("SumTotalQtyUd2")
        Dim _StockUd1 As Double = _Fila.Item("StockUd1")
        Dim _StockUd2 As Double = _Fila.Item("StockUd2")

        Dim _RotDiariaUd1, _RotDiariaUd2 As Double 'round(case When SumTotalQtyUd1 > 0 and Dias_Calculo > 0 then SumTotalQtyUd1/Dias_Calculo else 0 end,5),

        If _SumTotalQtyUd1 < _Dias_Calculo Then
            _RotDiariaUd1 = Math.Round(_SumTotalQtyUd1 / _Dias_Calculo, 5)
        End If

        If _SumTotalQtyUd2 < _Dias_Calculo Then
            _RotDiariaUd2 = Math.Round(_SumTotalQtyUd2 / _Dias_Calculo, 5)
        End If

        Dim _TStock As Double

        If _StockUd1 > 0 And _RotDiariaUd1 > 0 Then
            _TStock = Math.Round(_StockUd1 / _RotDiariaUd1, 0)
            _TStock = Math.Ceiling(_TStock)
            '_TStock = Math.Ceiling(Math.Round(_StockUd1 / _RotDiariaUd1, 0))
        End If

        Dim _Stock_CriticoUd1_Rd As Double
        _Stock_CriticoUd1_Rd = Math.Round(Input_Tiempo_Reposicion.Value * _RotDiariaUd1, 0)
        _Stock_CriticoUd1_Rd = Math.Ceiling(_Stock_CriticoUd1_Rd)

        Dim _Stock_CriticoUd2_Rd As Double
        _Stock_CriticoUd2_Rd = Math.Round(Input_Tiempo_Reposicion.Value * _RotDiariaUd2, 0)
        _Stock_CriticoUd2_Rd = Math.Ceiling(_Stock_CriticoUd2_Rd)

        If _Stock_CriticoUd1_Rd = 0 Then _Stock_CriticoUd1_Rd = 1
        If _Stock_CriticoUd2_Rd = 0 Then _Stock_CriticoUd2_Rd = 1

        Dim _CantSugeridaTot As Double

        If Rdb_Ud1_Compra.Checked Then
            _CantSugeridaTot = ((Input_Dias_a_Abastecer.Value * _RotDiariaUd1) * 1 + (Input_Porc_Crecimiento.Value / 100))
        Else
            _CantSugeridaTot = ((Input_Dias_a_Abastecer.Value * _RotDiariaUd2) * 1 + (Input_Porc_Crecimiento.Value / 100))
        End If

        If Chk_Restar_Stok_Bodega.Checked Then _CantSugeridaTot -= _StockUd1

        Dim _Con_Stock_CriticoUd1 As Boolean
        If _StockUd1 - _Stock_CriticoUd1_Rd < 0 Then _Con_Stock_CriticoUd1 = True
        Dim _Con_Stock_CriticoUd2 As Boolean
        If _StockUd2 - _Stock_CriticoUd2_Rd < 0 Then _Con_Stock_CriticoUd2 = True

        _CantSugeridaTot = Math.Round(_CantSugeridaTot, 0)
        _CantSugeridaTot = Math.Ceiling(_CantSugeridaTot)

        If _CantSugeridaTot < 0 Then _CantSugeridaTot = 0


        Fx_Actualizar_Rotacion_X_Prodcuto =
                       "Update " & _Nombre_Tbl_Paso_Informe & " Set" & vbCrLf &
                       "RotDiariaUd1 = " & De_Num_a_Tx_01(_RotDiariaUd1, False, 5) & "," &
                       "RotDiariaUd2 = " & De_Num_a_Tx_01(_RotDiariaUd2, False, 5) & "," &
                       "TStock = " & De_Num_a_Tx_01(_TStock, False, 5) & "," &
                       "Stock_CriticoUd1_Rd = " & De_Num_a_Tx_01(_Stock_CriticoUd1_Rd, False, 5) & "," &
                       "Stock_CriticoUd2_Rd = " & De_Num_a_Tx_01(_Stock_CriticoUd2_Rd, False, 5) & "," &
                       "CantSugeridaTot = " & De_Num_a_Tx_01(_CantSugeridaTot, False, 5) & vbCrLf &
                       "Where Codigo = '" & _Codigo & "'"



    End Function

    Sub Sb_Actualizar_Stock()

        _Clas_Asistente_Compras.Pro_Filtro_Bodegas_Todas = _Filtro_Bodegas_Todas
        _Clas_Asistente_Compras.Pro_Tbl_Filtro_Bodegas = _TblBodCompra
        _Clas_Asistente_Compras.Sb_Actualizar_Stock()

    End Sub

    Sub Sb_Actualizar_Costos()

        Dim _Lista As String = Cmb_Lista_Costos.SelectedItem.Value

        Consulta_sql = "Update " & _Nombre_Tbl_Paso_Informe & " Set Iva = (Select POIVPR From MAEPR Where KOPR = Codigo)
                        Update " & _Nombre_Tbl_Paso_Informe & " Set Ila = Isnull((Select Sum(POIM) From TABIM Where KOIM In (Select KOIM From TABIMPR Where KOPR = Codigo)),0)
                        Update " & _Nombre_Tbl_Paso_Informe & " Set Costo_PPP = (Select PM From MAEPREM Where EMPRESA = '" & ModEmpresa & "' And KOPR = Codigo)
                        Update " & _Nombre_Tbl_Paso_Informe & " Set Costo_UltComUd1 = (Select PPUL01 From MAEPREM Where EMPRESA = '" & ModEmpresa & "' And KOPR = Codigo)
                        Update " & _Nombre_Tbl_Paso_Informe & " Set Costo_UltComUd2 = (Select PPUL02 From MAEPREM Where EMPRESA = '" & ModEmpresa & "' And KOPR = Codigo)                        
                        Update " & _Nombre_Tbl_Paso_Informe & " Set Costo_Ud1Lista_Neto = (Select PP01UD From TABPRE Where KOLT = '" & _Lista & "' And KOPR = Codigo)
                        Update " & _Nombre_Tbl_Paso_Informe & " Set Costo_Ud2Lista_Neto = (Select PP02UD From TABPRE Where KOLT = '" & _Lista & "' And KOPR = Codigo)

                        Update " & _Nombre_Tbl_Paso_Informe & " Set Costo_Ud1Lista_Bruto = Round(Costo_Ud1Lista_Neto * (1+((Iva+Ila)/100)),0)
                        Update " & _Nombre_Tbl_Paso_Informe & " Set Costo_Ud2Lista_Bruto = Round(Costo_Ud2Lista_Neto * (1+((Iva+Ila)/100)),0)
                        Update " & _Nombre_Tbl_Paso_Informe & " Set Costo_Flete = 0"

        _Sql.Ej_consulta_IDU(Consulta_sql)

        If Not IsNothing(_RowProveedor) Then

            Dim _CodProveedor = _RowProveedor.Item("KOEN")

            Consulta_sql = "Update " & _Nombre_Tbl_Paso_Informe & " Set Costo_Flete = RECARGO,Costo_FleteNeto = RECARGO/1.19
                            From " & _Nombre_Tbl_Paso_Informe & " 
                            Inner Join TABRECPR On KOEN = '" & _CodProveedor & "' And KOPR = Codigo
                            Where CodProveedor = '" & _CodProveedor & "'"
            _Sql.Ej_consulta_IDU(Consulta_sql)

        Else

            Consulta_sql = "Update " & _Nombre_Tbl_Paso_Informe & " Set Costo_Flete = Isnull(RECARGO,0),Costo_FleteNeto = Isnull(RECARGO,0)/1.19
                            From " & _Nombre_Tbl_Paso_Informe & " 
                            Inner Join TABRECPR On KOEN = CodProveedor And KOPR = Codigo
                            Where KOEN = CodProveedor And CodProveedor <> ''"
            _Sql.Ej_consulta_IDU(Consulta_sql)

        End If

        Dim _Lista_Campos_Dscto As New List(Of String)

        _Lista_Campos_Dscto = Fx_Lista_Campos_Dscto()
        Dim _Contado = 0

        Dim _Campos_Descuentos = String.Empty
        Dim _Update_Dsctos = String.Empty

        For Each _Campo As String In _Lista_Campos_Dscto

            _Contado += 1

            If _Contado <> _Lista_Campos_Dscto.Count Then
                _Campos_Descuentos += "(1 - (" & _Campo & " / 100.0)) * "
            Else
                _Campos_Descuentos += "(1 - (" & _Campo & " / 100.0))"
            End If

            Consulta_sql = "Update " & _Nombre_Tbl_Paso_Informe & " Set " & _Campo & " = (Select " & _Campo & " From TABPRE Where KOLT = '" & _Lista & "' And KOPR = Codigo)"
            _Sql.Ej_consulta_IDU(Consulta_sql)

        Next

        Dim _Descuento_Porc = "100 * (1-(" & _Campos_Descuentos & "))"

        If CBool(_Lista_Campos_Dscto.Count) Then

            Consulta_sql = "Update " & _Nombre_Tbl_Paso_Informe & " Set Porc_Descuento = " & _Descuento_Porc
            _Sql.Ej_consulta_IDU(Consulta_sql)

            Consulta_sql = "Update " & _Nombre_Tbl_Paso_Informe & " Set Porc_Descuento = Porc_Descuento/100"
            _Sql.Ej_consulta_IDU(Consulta_sql)

            Consulta_sql = "Update " & _Nombre_Tbl_Paso_Informe & " Set Costo_Ud1Lista_Neto = Costo_Ud1Lista_Neto - (Costo_Ud1Lista_Neto * Porc_Descuento)
                            Update " & _Nombre_Tbl_Paso_Informe & " Set Costo_Ud2Lista_Neto = Costo_Ud2Lista_Neto - (Costo_Ud2Lista_Neto * Porc_Descuento)

                            Update " & _Nombre_Tbl_Paso_Informe & " Set Costo_Ud1Lista_Bruto = Round(Costo_Ud1Lista_Neto * (1+((Iva+Ila)/100)),0)
                            Update " & _Nombre_Tbl_Paso_Informe & " Set Costo_Ud2Lista_Bruto = Round(Costo_Ud2Lista_Neto * (1+((Iva+Ila)/100)),0)"
            _Sql.Ej_consulta_IDU(Consulta_sql)

            'Consulta_sql = "--Update " & _Nombre_Tbl_Paso_Informe & " Set Costo_Ud1Lista_Neto = Costo_Ud1Lista_Neto + Costo_FleteNeto
            '                --Update " & _Nombre_Tbl_Paso_Informe & " Set Costo_Ud2Lista_Neto = Costo_Ud2Lista_Neto + (Costo_FleteNeto*Rtu)

            '                Update " & _Nombre_Tbl_Paso_Informe & " Set Costo_Ud1Lista_Bruto = Round(Costo_Ud1Lista_Bruto + Costo_Flete,0)
            '                Update " & _Nombre_Tbl_Paso_Informe & " Set Costo_Ud2Lista_Bruto = Round(Costo_Ud2Lista_Bruto + (Costo_Flete*Rtu),0)"
            '_Sql.Ej_consulta_IDU(Consulta_sql)

            'Consulta_sql = "Update " & _Nombre_Tbl_Paso_Informe & " Set Costo_Ud1Lista_Neto = Costo_Ud1Lista_Neto + (Costo_Flete/1.19)
            '                Update " & _Nombre_Tbl_Paso_Informe & " Set Costo_Ud2Lista_Neto = Costo_Ud2Lista_Neto + ((Costo_Flete/1.19)*Rtu)

            '                Update " & _Nombre_Tbl_Paso_Informe & " Set Costo_Ud1Lista_Bruto = Round(Costo_Ud1Lista_Bruto + Costo_Flete,0)
            '                Update " & _Nombre_Tbl_Paso_Informe & " Set Costo_Ud2Lista_Bruto = Round(Costo_Ud2Lista_Bruto + (Costo_Flete*Rtu),0)"
            '_Sql.Ej_consulta_IDU(Consulta_sql)

        End If

        ' Incorpora campo que indica la diferencia con el costo de la ultima compra VS el costo del proveedor

        'Consulta_sql = "Update " & _Nombre_Tbl_Paso_Informe & " Set " &
        '       "PorcDifCostoBruUd1 = Round((Costo_Ud1Lista_Bruto-(Costo_UltComUd1*(1+((Iva+Ila)/100))))/(Costo_UltComUd1*(1+((Iva+Ila)/100))),2)" & vbCrLf &
        '       "Where Costo_Ud1Lista_Neto > 0 And Costo_UltComUd1 > 0"
        '_Sql.Ej_consulta_IDU(Consulta_sql)

        Consulta_sql = "Update " & _Nombre_Tbl_Paso_Informe & " Set " &
               "PorcDifCostoNetUd1 = Round((Costo_UltComUd1-Costo_Ud1Lista_Neto)/Costo_UltComUd1,2)*-1" & vbCrLf &
               "Where Costo_Ud1Lista_Neto > 0 And Costo_UltComUd1 > 0"
        _Sql.Ej_consulta_IDU(Consulta_sql)

        '_DescuentoPorc = 100 * (1 - (
        '                             (1 - (_Desc1 / 100.0)) *
        '                             (1 - (_Desc2 / 100.0)) *
        '                             (1 - (_Desc3 / 100.0)) *
        '                             (1 - (_Desc4 / 100.0)) *
        '                             (1 - (_Desc5 / 100.0))
        '                             )
        '                             )

    End Sub

    Sub Sb_Actualizar_Stock_Old()

        Dim _Filtro_Bodega As String

        If _Filtro_Bodegas_Todas Then
            _Filtro_Bodega = String.Empty
        Else
            _Filtro_Bodega = Generar_Filtro_IN(_TblBodCompra, "Chk", "Codigo", False, True, "'")
            _Filtro_Bodega = "And EMPRESA+KOSU+KOBO In " & _Filtro_Bodega
        End If

        Consulta_sql = My.Resources.Recursos_Asis_Compras.SQLQuery_Inserta_stock_por_producto
        Consulta_sql = Replace(Consulta_sql, "#TablaPaso#", _Nombre_Tbl_Paso_Informe)
        Consulta_sql = Replace(Consulta_sql, "#CodFuncionario#", FUNCIONARIO)
        Consulta_sql = Replace(Consulta_sql, "#Filtro_Bodega#", _Filtro_Bodega)

        _Sql.Ej_consulta_IDU(Consulta_sql)

    End Sub

    Sub Sb_Actualizar_Ult3ComprasXprodVsProveedor()

        If IsNothing(_RowProveedor) Then
            Return
        End If

        Dim _CodProveedor = _RowProveedor.Item("KOEN")
        Dim _CodSucProveedor = _RowProveedor.Item("SUEN")

        Consulta_sql = My.Resources.Recursos_Asis_Compras.SQLQuery_Ult_3_compras_X_producto
        Consulta_sql = Replace(Consulta_sql, "#TablaPaso#", _Nombre_Tbl_Paso_Informe)
        Consulta_sql = Replace(Consulta_sql, "#Endo#", _CodProveedor)
        Consulta_sql = Replace(Consulta_sql, "#Suendo#", _CodSucProveedor)

        _Sql.Ej_consulta_IDU(Consulta_sql)

    End Sub

#End Region

    Private Sub BtnExporExcelSelActual_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExporExcelSelActual.Click

        'EjecutarInforme()
        ExportarTabla_JetExcel_Tabla(_Tbl_Informe, Me, "Inf_Asis_Compra")
        'ExportarTabla_JetExcel(ConsultaSQLGrilla, Me)

    End Sub

    Private Sub BtnExporExcelProdComprar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExporExcelProdComprar.Click

        Dim _Nombre_Excel As String = "Productos a comprar"
        'Dim _Ud As Integer

        'If Rdb_Ud1_Compra.Checked Then
        '    _Ud = 1
        'ElseIf Rdb_Ud2_Compra.Checked Then
        '    _Ud = 2
        'End If

        Dim _Campo_Rotacion, _Rotacion_Str, _Head_PVenta, _Head_PStock, _Head_CantSug, _MD As String


        If Cmb_Metodo_Abastecer_Dias_Meses.SelectedValue = 1 Then
            _Campo_Rotacion = "RotDiariaUd" & Ud
            _Rotacion_Str = "Rotacion_diaria"
            _Head_PVenta = Input_Dias_a_Abastecer.Value & "_dias"
            _Head_PStock = Input_Tiempo_Reposicion.Value & "_dias"
            _MD = "dias"
            '_Head_CantSug = "Cant_sugerida_" &
        Else
            _Campo_Rotacion = "RotMensualUd" & Ud
            _Rotacion_Str = "Rotacion_mensual"
            _Head_PVenta = Input_Dias_a_Abastecer.Value & "_meses"
            _Head_PStock = Input_Tiempo_Reposicion.Value & "_meses"
            _MD = "meses"
        End If

        If Chk_Trabajando_Con_Proyeccion.Checked Then

            _Nombre_Excel += " Proveedor_" & Fm_Hijo.Txt_Proveedor.Text

            Consulta_sql = "Select " &
                           "Codigo AS 'Codigo', CodAlternativo AS 'CodAlternativo', " & vbCrLf &
                           "Descripcion AS 'Descripcion'," &
                           "Isnull((Select Top 1 NOKOPRAL From TABCODAL" & Space(1) &
                           "Where KOEN = CodProveedor And KOPRAL = CodAlternativo),'?????') As Descripcion_Proveedor," &
                           "Round(Stock_Fisico_Ud" & Ud & ",2) As Stock_Fisico_Ud" & Ud & "," &
                           "Round(" & _Campo_Rotacion & ",2) As " & _Rotacion_Str & "," &
                           "Round(Stock_CriticoUd" & Ud & "_Rd,2) As Proyeccion_Venta_" & Input_Tiempo_Reposicion.Value & "_" & _MD & "," & vbCrLf &
                           "Round(StockUd" & Ud & ",2) As Proyeccion_stock_" & Input_Tiempo_Reposicion.Value & "_" & _MD & "," &
                           "Round(CantSugeridaTot,2) As Cant_Sugerida_" & Input_Dias_a_Abastecer.Value & "_" & _MD & vbCrLf &
                           "From " & _Nombre_Tbl_Paso_Informe & vbCrLf &
                           "Where Comprar = 1 And Es_Agrupador = 1"
        Else
            Consulta_sql = "Select CodProveedor," &
                          "(Select top 1 NOKOEN From MAEEN Where KOEN = CodProveedor And SUEN = CodSucProveedor) as Razon," &
                          "Codigo AS 'Codigo', CodAlternativo AS 'CodAlternativo', " & vbCrLf &
                          "Descripcion AS 'Descripcion', UD2 as 'Unidad', Rtu AS 'Rtu',Round(CantComprar,2) as 'CantComprar'," &
                          "Round(CantSugeridaTot,2) As 'Cant_Sugerida'," &
                          "Round(Stock_Fisico_Ud1,2) As Stock_Fisico_Ud1,Round(Stock_Fisico_Ud2,2) As Stock_Fisico_Ud2," &
                          "Round(StockUd1,2) As StockUd1,Round(StockUd2,2) As StockUd2" & vbCrLf &
                          "From " & _Nombre_Tbl_Paso_Informe & vbCrLf &
                          "Where CantComprar > 0"
        End If

        Dim _Tbl As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        ExportarTabla_JetExcel_Tabla(_Tbl, Me, _Nombre_Excel)

    End Sub


    Private Sub ButtonItem10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '    Datos.WriteXml(AppPath() & "\Data\InfCompras_01.xml") 'Documento_vta

    End Sub


    Private Sub BtnSelectBodegas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSelectBodegas.Click

        Dim Fm As New Frm_Filtro_Especial_Informes(Frm_Filtro_Especial_Informes._Tabla_Fl._Bodegas, False)
        'Fm.Pro_Seleccionar_Todo = True
        Fm.Pro_Tbl_Filtro = _TblBodCompra

        Fm.ShowDialog(Me)

        If Fm.Pro_Filtrar Then

            _TblBodCompra = Fm.Pro_Tbl_Filtro

            If Fm.Pro_Filtrar_Todo Then
                _Filtro_Bodegas_Todas = True
            Else
                If (_TblBodCompra Is Nothing) Then
                    _Filtro_Bodegas_Todas = True
                Else
                    _Filtro_Bodegas_Todas = False
                End If
            End If
            Sb_Refrescar_Grilla_Principal(Fm_Hijo.Grilla, False, True)
        End If
        Fm.Dispose()

    End Sub

    Private Function GetRadioButtons() As Command()
        Return New Command() {Radio1, Radio2}
    End Function

    Private Sub ChkSinRotacion_CheckedChanged(ByVal sender As System.Object, ByVal e As DevComponents.DotNetBar.CheckBoxChangeEventArgs) Handles Chk_Sacar_Productos_Sin_Rotacion.CheckedChanged

        If Chk_Sacar_Productos_Sin_Rotacion.Checked Then

            Try

                Dim _Fecha As String = Format(_Fecha_Productos_Sin_Rotacion, "dd-MM-yyyy")

                If _Fecha = "01-01-0001" Then
                    _Fecha = Format(Primerdiadelmes(DateAdd(DateInterval.Month, -6, Now.Date)), "dd-MM-yyyy")
                End If

                If InputBox_Bk(Me, "Productos que no han tenido movimientos de ventas" & vbCrLf & "después de la fecha indicada" & vbCrLf & vbCrLf &
                               "Formato fecha: dd-mm-aaaa",
                               "Considerar sin rotación desde...", _Fecha, False,,, True, _Tipo_Imagen.Texto) Then
                    _Fecha_Productos_Sin_Rotacion = _Fecha

                    Chk_Sacar_Productos_Sin_Rotacion.Tooltip = "Se quitan productos que no tengan ventas despues del " & FormatDateTime(_Fecha_Productos_Sin_Rotacion, DateFormat.ShortDate)

                Else
                    Chk_Sacar_Productos_Sin_Rotacion.Checked = False
                    Return
                End If

            Catch ex As Exception
                MessageBoxEx.Show("Se quitara filtro sin rotación", "Fecha invalida", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Chk_Sacar_Productos_Sin_Rotacion.Checked = False
            End Try

        End If

        Sb_Grilla_Marcar(Fm_Hijo.Grilla, True)
        Call Btn_Actualizar_Informe_Click(Nothing, Nothing)

    End Sub

    Private Sub ChkEntidadFisica_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim Reg As Integer =
       _Sql.Fx_Cuenta_Registros(_Nombre_Tbl_Paso_Informe, "CodProveedor <> '' and CodAlternativo = ''")

        If Reg > 0 Then

            Dim dlg As System.Windows.Forms.DialogResult =
           MessageBoxEx.Show(Me, "¿Esta seguro de eliminar la(s) fila(s) seleccionada(s)?",
                             "Eliminar fila", MessageBoxButtons.YesNo)

            If dlg = System.Windows.Forms.DialogResult.Yes Then
                MsgBox("Se quitaron todos los proveedores sin Código alternativo")
            End If
        End If
    End Sub

    Private Sub ConsultaIntegradaDeStockToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim _Codigo As String = Fm_Hijo.Grilla.Rows(Fm_Hijo.Grilla.CurrentRow.Index).Cells("Codigo").Value

        Dim Fm As New Frm_Kardex_X_Producto_Lista
        Fm.Pro_Codigo = _Codigo
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Private Sub UltimosMovimientosVentasYComprasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim _Codigo As String = Fm_Hijo.Grilla.Rows(Fm_Hijo.Grilla.CurrentRow.Index).Cells("Codigo").Value

        Dim Fm As New Frm_EstadisticaProducto(_Codigo)
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Private Sub BtnProceso_Prov_Auto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnProceso_Prov_Auto.Click

        Dim Fm As New Frm_08_Asis_Compra_IncorpProveedor(_RowParametros)
        Fm.Accion_Automatica = _Accion_Automatica
        Fm.Chk_Incluir_Ent_Excluidas.Checked = Modo_NVI
        Fm.Chk_Incluir_Ent_Excluidas.Enabled = False
        Fm.ShowDialog(Me)
        _Proceso_Automatico_Ejecutado = Fm.Pro_Proceso_Generado
        Fm.Dispose()

    End Sub

    Private Sub Frm_01_AsisCompra_Resultados_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick

        Timer1.Enabled = False
        Timer1.Interval = 300

        Sb_Actualizar_Grilla_Mensual()

    End Sub

    Private Sub Btn_Estadisticas_Producto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Estadisticas_Producto.Click

        Dim _Fila As DataGridViewRow = Fm_Hijo.Grilla.Rows(Fm_Hijo.Grilla.CurrentRow.Index)

        Dim _Codigo As String = _Fila.Cells("Codigo").Value
        Dim _Fecha_Inicio As Date = _Fila.Cells("Fecha_Inicio").Value
        Dim _Fecha_Fin As Date = _Fila.Cells("Fecha_Fin").Value

        Dim _Meses = DateDiff(DateInterval.Month, _Fecha_Inicio, _Fecha_Fin)

        If _Meses > 25 Then
            _Fecha_Fin = DateAdd(DateInterval.Month, 25, _Fecha_Inicio)
        End If

        Dim _Stock_Critico As Double

        If _Codigo <> _Codigo_Seleccionado Then
            Sb_Actualizar_Grilla_Mensual()
        End If

        _Stock_Critico = _Fila.Cells("Stock_CriticoUd" & Ud & "_Rd").Value

        Dim Fm As New Frm_EstadisticaProducto(_Codigo)
        Fm.Pro_Agrupar_Reemplazos = Chk_Traer_Productos_De_Reemplazo.Checked
        Fm.Pro_Filtro_Bodegas_Todas = _Filtro_Bodegas_Todas
        Fm.Pro_Tbl_Filtro_Bodegas = _TblBodVenta
        Fm.Pro_Incluir_Analisi_Con_Ent_Excluidas = Chk_Rotacion_Con_Ent_Excluidas.Checked
        Fm.Input_Stock_Minimo.Enabled = False
        Fm.Pro_Stock_Critico = _Stock_Critico
        Fm.Pro_Fecha_Moviminetos_Stock_Desde = _Fecha_Inicio
        Fm.Pro_Fecha_Moviminetos_Stock_Hasta = _Fecha_Fin
        Fm.Rdb_Ud1.Checked = Rdb_Ud1_Compra.Checked
        Fm.Rdb_Ud2.Checked = Rdb_Ud2_Compra.Checked
        Fm.Chk_Mostrar_Solo_BLV_FCV_NCV.Checked = False
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Private Sub Btn_Quitar_Proveedor_Linea_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Quitar_Proveedor_Linea.Click

        Dim _Fila As DataGridViewRow = Fm_Hijo.Grilla.Rows(Fm_Hijo.Grilla.CurrentRow.Index)
        Dim _Tenia_Proveedor As Boolean

        Dim _Codigo = _Fila.Cells("Codigo").Value
        Dim _OccGenerada As Boolean = _Fila.Cells("OccGenerada").Value

        Dim _CodProveedor As String = Trim(_Fila.Cells("CodProveedor").Value)
        Dim _CodSucProveedor As String
        Dim _CodAlternativo As String

        If Not String.IsNullOrEmpty(_CodProveedor) Then
            _Tenia_Proveedor = True
        End If

        If _OccGenerada Then
            MessageBoxEx.Show(Me, "Producto ya fue tratado en este proceso de compras" & vbCrLf &
                              "Ya se genero solicitud u Orden de compra", "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        Dim Fm As Object

        If Chk_Traer_Solo_Proveedores_Relacion_Con_El_Producto.Checked Or Chk_Ent_Fisica.Checked Then
            Fm = New Frm_04_Asis_Compra_Proveedores(Frm_04_Asis_Compra_Proveedores.TipoBusqueda.Proveedores_del_producto,
                                                    _Codigo, False)
        Else
            Fm = New Frm_04_Asis_Compra_Proveedores(Frm_04_Asis_Compra_Proveedores.TipoBusqueda.Todos_los_Proveedores,
                                                    _Codigo, False)
        End If

        Fm.Pro_Rd_Costo_Lista_Proveedor = Rd_Costo_Lista_Proveedor.Checked
        Fm.Pro_Rd_Costo_Ultima_GRC = Rd_Costo_Ultimo_Documento_Seleccionado.Checked

        Fm.ShowDialog(Me)

        Call Grilla_CellEnter(Fm_Hijo.Grilla, Nothing)


        Rd_Costo_Lista_Proveedor.Checked = Fm.Pro_Rd_Costo_Lista_Proveedor
        Rd_Costo_Ultimo_Documento_Seleccionado.Checked = Fm.Pro_Rd_Costo_Ultima_GRC

        _CodProveedor = String.Empty
        _CodSucProveedor = String.Empty
        _CodAlternativo = String.Empty

        Dim _Row_Proveedor = Fm.Pro_RowProveedor

        Fm.Dispose()

        If (_Row_Proveedor Is Nothing) Then
            '_Fila.Cells("CantComprar").Value = 0
            Return
        Else

            _CodProveedor = _Row_Proveedor.Item("KOEN")
            _CodSucProveedor = _Row_Proveedor.Item("SUEN")

            Dim Reg As Integer =
           _Sql.Fx_Cuenta_Registros("TABCODAL", "KOEN = '" & _CodProveedor & "' AND KOPR = '" & _Codigo & "'")

            If Chk_Ent_Fisica.Checked Then

                If Reg = 0 Then
                    MessageBoxEx.Show(Me, "¡Este proveedor no posse código alternativo para este producto!",
                                      "Falta Código de proveedor",
                                      MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If

            End If

            _CodAlternativo = _Sql.Fx_Trae_Dato("TABCODAL", "KOPRAL", "KOPR = '" & _Codigo &
                                    "' And KOEN = '" & _CodProveedor & "'")

        End If

        Consulta_sql = "Update " & _Nombre_Tbl_Paso_Informe & " Set " &
                       "CodProveedor = '" & _CodProveedor & "'," &
                       "CodSucProveedor = '" & _CodSucProveedor & "'," &
                       "CodAlternativo = '" & _CodAlternativo & "'" & vbCrLf &
                       "Where Codigo = '" & _Codigo & "'"

        If _Sql.Ej_consulta_IDU(Consulta_sql) Then

            _Fila.Cells("CodProveedor").Value = _CodProveedor
            _Fila.Cells("CodSucProveedor").Value = _CodSucProveedor
            _Fila.Cells("CodAlternativo").Value = _CodAlternativo

            _Fila.Cells("Informacion_Fila").Value = String.Empty
            Call Grilla_CellEnter(Fm_Hijo.Grilla, Nothing)

        End If

        If _Tenia_Proveedor Then
            If String.IsNullOrEmpty(_CodProveedor) Then
                Beep()
                ToastNotification.Show(Me, "SE QUITO EL PROVEEDOR", Btn_Quitar_Proveedor_Linea.Image,
                              2 * 1000, eToastGlowColor.Red, eToastPosition.MiddleCenter)
            End If
        End If

    End Sub

    Private Sub Btn_Cambiar_CodAlternativo_Proveedor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Cambiar_CodAlternativo_Proveedor.Click

        Dim _Fila As DataGridViewRow = Fm_Hijo.Grilla.Rows(Fm_Hijo.Grilla.CurrentRow.Index)

        Dim _CodProveedor = Trim(NuloPorNro(_Fila.Cells("CodProveedor").Value, ""))
        Dim _Codigo = Trim(NuloPorNro(_Fila.Cells("Codigo").Value, ""))
        Dim _Descripcion = Trim(NuloPorNro(_Fila.Cells("Descripcion").Value, ""))

        Dim Fm As New Frm_05_AsisCompra_CodAlternativos
        Fm.ProveedorRd = _CodProveedor
        Fm.CodigoRd = _Codigo
        Fm.Text = "Producto: " & Fm.CodigoRd & " - " & _Descripcion
        Fm.ShowDialog(Me)

        Dim _CodAlternativo As String = Trim(Fm.CodigoAlt)

        If Not String.IsNullOrEmpty(_CodAlternativo) Then

            _Fila.Cells("CodAlternativo").Value = _CodAlternativo

            Consulta_sql = "Update " & _Nombre_Tbl_Paso_Informe & " Set " &
                           "CodAlternativo = '" & _CodAlternativo & "'" & vbCrLf &
                           "Where Codigo = '" & _Codigo & "'"
            _Sql.Ej_consulta_IDU(Consulta_sql)

            'Sb_Grilla_Detalle_Producto_Actualizar()

        End If

        Fm.Dispose()

    End Sub

    Sub Sb_Parametros_Revisar()

        With _RowParametros

            Chk_Traer_Productos_De_Reemplazo.Checked = .Item("Chk_Traer_Productos_De_Reemplazo")

            Dim _Koen = .Item("Koen")

            If String.IsNullOrEmpty(_Koen) Then
                _RowProveedor = Nothing
            Else

                Consulta_sql = "Select top 1 * From MAEEN Where KOEN = '" & _Koen & "'"
                Dim _TblProveedor As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

                If _TblProveedor.Rows.Count Then
                    _RowProveedor = _TblProveedor.Rows(0)
                    '_Row_Filtro_Proveedor = _RowProveedor

                    Fm_Hijo.Btn_Filtrar_Proveedor.Visible = False
                    Fm_Hijo.Btn_Quitar_Filtro_Proveedor.Visible = False

                    Ribon_Filtrar_Proveedor.Visible = False

                    BtnProceso_Prov_Auto.Enabled = False
                    Chk_Traer_Solo_Proveedores_Relacion_Con_El_Producto.Checked = False
                    Chk_Traer_Solo_Proveedores_Relacion_Con_El_Producto.Enabled = False
                    Me.Text = "RESULTADO INFORME ASISTENTE DE COMPRAS... PROVEEDOR: " & Trim(_Koen) & " -> " & _RowProveedor.Item("nokoen")
                Else
                    BtnImprimirListado.Visible = False
                    _RowProveedor = Nothing
                End If

            End If

            'If (_RowProveedor Is Nothing) Then
            'Txt_Proveedor.Text = String.Empty
            'Else
            'Txt_Proveedor.Text = Trim(_RowProveedor.Item("KOEN")) & " - " & Trim(_RowProveedor.Item("NOKOEN"))
            'End If

            Chk_Ent_Fisica.Checked = .Item("Chk_Ent_Fisica")

            Input_Tiempo_Reposicion.Value = .Item("Input_Tiempo_Reposicion")
            Input_Dias_a_Abastecer.Value = .Item("Input_Dias_a_Abastecer")
            Chk_Mostrar_Solo_Stock_Critico.Checked = .Item("Chk_Mostrar_Solo_Stock_Critico")
            Chk_Sabado.Checked = .Item("Chk_Sabado")
            Chk_Domingo.Checked = .Item("Chk_Domingo")

            Rd_Costo_Lista_Proveedor.Checked = .Item("Rd_Costo_Lista_Proveedor")
            Rd_Costo_Ultimo_Documento_Seleccionado.Checked = .Item("Rd_Costo_Ultima_GRC")
            Rdb_Ud1_Compra.Checked = .Item("Rdb_Ud1_Compra")
            Rdb_Ud2_Compra.Checked = .Item("Rdb_Ud2_Compra")

            'Chk_Cargar_Rotacion_Estacional.Checked = .Item("Chk_Cargar_Rotacion_Estacional")
            'Dtp_Fecha_Estacional_Desde.Value = .Item("Dtp_Fecha_Estacional_Desde")
            'Dtp_Fecha_Estacional_Hasta.Value = .Item("Dtp_Fecha_Estacional_Hasta")

            Chk_Restar_Stok_Bodega.Checked = .Item("Chk_Restar_Stok_Bodega")
            Chk_Sacar_Productos_Sin_Rotacion.Checked = .Item("Chk_Sacar_Productos_Sin_Rotacion")
            Chk_No_Considera_Con_Stock_Pedido_OCC_NVI.Checked = .Item("Chk_No_Considera_Con_Stock_Pedido_OCC_NVI")
            Chk_Quitar_Bloqueados_Compra.Checked = .Item("Chk_Quitar_Bloqueados_Compra")

            Chk_Quitar_Ventas_Calzadas.Checked = .Item("Chk_Quitar_Ventas_Calzadas")

            _Cmb_Padre_Asociacion_Productos = NuloPorNro(.Item("Cmb_Padre_Asociacion_Productos"), "")

            If Chk_Traer_Productos_De_Reemplazo.Checked Then
                Chk_Traer_Productos_De_Reemplazo.Enabled = False
            Else
                Chk_Traer_Productos_De_Reemplazo.Enabled = True
            End If

            Chk_Sumar_Rotacion_Hermanos.Checked = Chk_Traer_Productos_De_Reemplazo.Checked
            Chk_Sumar_Rotacion_Hermanos.Enabled = Chk_Traer_Productos_De_Reemplazo.Enabled

            Cmb_Metodo_Abastecer_Dias_Meses.SelectedValue = .Item("Cmb_Proyeccion_Metodo_Abastecer")
            Cmb_Tiempo_Reposicion_Dias_Meses.SelectedValue = .Item("Cmb_Proyeccion_Tiempo_Reposicion")

            Chk_Rotacion_Con_Ent_Excluidas.Checked = .Item("Chk_Rotacion_Con_Ent_Excluidas")

            Rdb_Agrupar_x_Asociados.Checked = NuloPorNro(.Item("Rdb_Agrupar_x_Asociados"), False)
            Rdb_Agrupar_x_Reemplazos.Checked = NuloPorNro(.Item("Rdb_Agrupar_x_Reemplazos"), False)

            If Not Rdb_Agrupar_x_Asociados.Checked And Not Rdb_Agrupar_x_Reemplazos.Checked Then
                Rdb_Agrupar_x_Reemplazos.Checked = True
            End If

            ' Cmb_Nodo_Raiz_Asociados.SelectedValue = NuloPorNro(.Item("Cmb_Nodo_Raiz_Asociados"), "")

        End With

    End Sub

    Sub Sb_Parametros_Actualizar()

        With _RowParametros

            .Item("Chk_Traer_Productos_De_Reemplazo") = Chk_Traer_Productos_De_Reemplazo.Checked
            .Item("Chk_Ent_Fisica") = Chk_Ent_Fisica.Checked

            .Item("Input_Tiempo_Reposicion") = Input_Tiempo_Reposicion.Value
            .Item("Input_Dias_a_Abastecer") = Input_Dias_a_Abastecer.Value
            .Item("Chk_Mostrar_Solo_Stock_Critico") = Chk_Mostrar_Solo_Stock_Critico.Checked
            .Item("Chk_Sabado") = Chk_Sabado.Checked
            .Item("Chk_Domingo") = Chk_Domingo.Checked

            .Item("Rd_Costo_Lista_Proveedor") = Rd_Costo_Lista_Proveedor.Checked
            .Item("Rd_Costo_Ultima_GRC") = Rd_Costo_Ultimo_Documento_Seleccionado.Checked
            .Item("Rdb_Ud1_Compra") = Rdb_Ud1_Compra.Checked
            .Item("Rdb_Ud2_Compra") = Rdb_Ud2_Compra.Checked

            'Chk_Cargar_Rotacion_Estacional.Checked = .Item("Chk_Cargar_Rotacion_Estacional")
            'Dtp_Fecha_Estacional_Desde.Value = .Item("Dtp_Fecha_Estacional_Desde")
            'Dtp_Fecha_Estacional_Hasta.Value = .Item("Dtp_Fecha_Estacional_Hasta")

            .Item("Chk_Restar_Stok_Bodega") = Chk_Restar_Stok_Bodega.Checked
            .Item("Chk_Sacar_Productos_Sin_Rotacion") = Chk_Sacar_Productos_Sin_Rotacion.Checked
            .Item("Chk_No_Considera_Con_Stock_Pedido_OCC_NVI") = Chk_No_Considera_Con_Stock_Pedido_OCC_NVI.Checked
            .Item("Chk_Quitar_Bloqueados_Compra") = Chk_Quitar_Bloqueados_Compra.Checked

            .Item("Cmb_Padre_Asociacion_Productos") = _Cmb_Padre_Asociacion_Productos
            .Item("Cmb_Proyeccion_Metodo_Abastecer") = Cmb_Metodo_Abastecer_Dias_Meses.SelectedValue

            .Item("Chk_Quitar_Ventas_Calzadas") = Chk_Quitar_Ventas_Calzadas.Checked

            .Item("Cmb_Proyeccion_Metodo_Abastecer") = Cmb_Metodo_Abastecer_Dias_Meses.SelectedValue
            .Item("Cmb_Proyeccion_Tiempo_Reposicion") = Cmb_Tiempo_Reposicion_Dias_Meses.SelectedValue

            .Item("Chk_Rotacion_Con_Ent_Excluidas") = Chk_Rotacion_Con_Ent_Excluidas.Checked

            .Item("Rdb_Agrupar_x_Asociados") = Rdb_Agrupar_x_Asociados.Checked
            .Item("Rdb_Agrupar_x_Reemplazos") = Rdb_Agrupar_x_Reemplazos.Checked
            '.Item("Cmb_Nodo_Raiz_Asociados") = Cmb_Nodo_Raiz_Asociados.SelectedValue

        End With

    End Sub

    Sub Sb_Parametros_Informe_Sql(ByVal _Actualizar As Boolean)

        Dim _FechaHoy As Date = FormatDateTime(FechaDelServidor, DateFormat.ShortDate)
        Dim _Fecha_Hoy = Format(_FechaHoy, "dd-MM-yyyy")

        Dim _Koen As String
        Dim _Suen As String

        If (_RowProveedor Is Nothing) Then

            _Koen = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Tmp_Prm_Informes", "Valor", "Informe = 'Compras_Asistente' And Campo = 'Koen' And Funcionario = '" & FUNCIONARIO & "' And NombreEquipo = '" & _NombreEquipo & "' And Modalidad = '" & _Modalidad_Estudio & "'")
            _Suen = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Tmp_Prm_Informes", "Valor", "Informe = 'Compras_Asistente' And Campo = 'Suen' And Funcionario = '" & FUNCIONARIO & "' And NombreEquipo = '" & _NombreEquipo & "' And Modalidad = '" & _Modalidad_Estudio & "'")

            Fm_Hijo.Txt_Proveedor.Text = String.Empty
            _RowProveedor = Fx_Traer_Datos_Entidad(_Koen, _Suen)

        End If

        If Not (_RowProveedor Is Nothing) Then

            _Koen = Trim(_RowProveedor.Item("KOEN"))
            _Suen = Trim(_RowProveedor.Item("SUEN"))

            Fm_Hijo.Txt_Proveedor.Text = Trim(_RowProveedor.Item("KOEN")) & " - " & Trim(_RowProveedor.Item("NOKOEN"))

            _Sql.Sb_Parametro_Informe_Sql(Nothing, "Compras_Asistente", "Koen", Class_SQLite.Enum_Type._String, _Koen, _Actualizar, "Seleccion_Productos")
            _Sql.Sb_Parametro_Informe_Sql(Nothing, "Compras_Asistente", "Suen", Class_SQLite.Enum_Type._String, _Suen, _Actualizar, "Seleccion_Productos")

        End If

        '   Seleccionar si el proveedor es entidad fisica
        _Sql.Sb_Parametro_Informe_Sql(Chk_Ent_Fisica, "Compras_Asistente",
                                             Chk_Ent_Fisica.Name, Class_SQLite.Enum_Type._Boolean, Chk_Ent_Fisica.Checked, _Actualizar)

        '   Seleccionar si el proveedor es entidad fisica
        _Sql.Sb_Parametro_Informe_Sql(Chk_Traer_Productos_De_Reemplazo, "Compras_Asistente",
                                             Chk_Traer_Productos_De_Reemplazo.Name, Class_SQLite.Enum_Type._Boolean, Chk_Traer_Productos_De_Reemplazo.Checked, _Actualizar)

        '   Tipo de compra, Nacional / Comercio Exterior
        _Sql.Sb_Parametro_Informe_Sql(Fm_Hijo.Cmb_Tipo_de_compra, "Compras_Asistente",
                                             Fm_Hijo.Cmb_Tipo_de_compra.Name, Class_SQLite.Enum_Type._ComboBox, Fm_Hijo.Cmb_Tipo_de_compra.SelectedValue, _Actualizar)

        '   Tiempo para aprobicionamiento
        _Sql.Sb_Parametro_Informe_Sql(Cmb_Metodo_Abastecer_Dias_Meses, "Compras_Asistente", Cmb_Metodo_Abastecer_Dias_Meses.Name,
                                             Class_SQLite.Enum_Type._ComboBox, Cmb_Metodo_Abastecer_Dias_Meses.SelectedValue, _Actualizar)
        _Sql.Sb_Parametro_Informe_Sql(Input_Dias_a_Abastecer, "Compras_Asistente",
                                             Input_Dias_a_Abastecer.Name, Class_SQLite.Enum_Type._Double, Input_Dias_a_Abastecer.Value, _Actualizar)

        '   Tiempo de reposición (Lead Time, _Actualizar)
        _Sql.Sb_Parametro_Informe_Sql(Cmb_Tiempo_Reposicion_Dias_Meses, "Compras_Asistente",
                                             Cmb_Tiempo_Reposicion_Dias_Meses.Name, Class_SQLite.Enum_Type._ComboBox, Cmb_Tiempo_Reposicion_Dias_Meses.SelectedValue, _Actualizar)
        _Sql.Sb_Parametro_Informe_Sql(Input_Tiempo_Reposicion, "Compras_Asistente",
                                             Input_Tiempo_Reposicion.Name, Class_SQLite.Enum_Type._Double, Input_Tiempo_Reposicion.Value, _Actualizar)

        '   Considera Sabado
        _Sql.Sb_Parametro_Informe_Sql(Chk_Sabado, "Compras_Asistente",
                                             Chk_Sabado.Name, Class_SQLite.Enum_Type._Boolean, Chk_Sabado.Checked, _Actualizar)
        '   Considera Domingo
        _Sql.Sb_Parametro_Informe_Sql(Chk_Domingo, "Compras_Asistente",
                                             Chk_Domingo.Name, Class_SQLite.Enum_Type._Boolean, Chk_Domingo.Checked, _Actualizar)

        '   Unidad de compra UD1
        _Sql.Sb_Parametro_Informe_Sql(Rdb_Ud1_Compra, "Compras_Asistente",
                                             Rdb_Ud1_Compra.Name, Class_SQLite.Enum_Type._Boolean, Rdb_Ud1_Compra.Checked, _Actualizar)
        '   Unidad de compra UD1
        _Sql.Sb_Parametro_Informe_Sql(Rdb_Ud2_Compra, "Compras_Asistente",
                                             Rdb_Ud2_Compra.Name, Class_SQLite.Enum_Type._Boolean, Rdb_Ud2_Compra.Checked, _Actualizar)


        '   Costos desde ultimo documento segun seleccion
        _Sql.Sb_Parametro_Informe_Sql(Rd_Costo_Lista_Proveedor, "Compras_Asistente",
                                             Rd_Costo_Lista_Proveedor.Name, Class_SQLite.Enum_Type._Boolean, Rd_Costo_Lista_Proveedor.Checked, _Actualizar)
        '   Costos desde ultimo documento segun seleccion
        _Sql.Sb_Parametro_Informe_Sql(Rd_Costo_Ultimo_Documento_Seleccionado, "Compras_Asistente",
                                             Rd_Costo_Ultimo_Documento_Seleccionado.Name, Class_SQLite.Enum_Type._Boolean, Rd_Costo_Ultimo_Documento_Seleccionado.Checked, _Actualizar)
        '   Costos de la lista del proveedor
        _Sql.Sb_Parametro_Informe_Sql(Fm_Hijo.Cmb_Documento_Compra, "Compras_Asistente",
                                             Fm_Hijo.Cmb_Documento_Compra.Name, Class_SQLite.Enum_Type._ComboBox, Fm_Hijo.Cmb_Documento_Compra.SelectedValue, _Actualizar)
        '   Costos de la lista del proveedor
        '_Sql.Sb_Parametro_Informe_Sql(Dtp_Fecha_Tope_Proveedores_Automaticos, "Compras_Asistente", _
        '                                     Dtp_Fecha_Tope_Proveedores_Automaticos.Name, Class_SQLite.Enum_Type._Date, Dtp_Fecha_Tope_Proveedores_Automaticos.Value, _Actualizar)



        '   Ticket Quitar Productos sin rotacion 
        _Sql.Sb_Parametro_Informe_Sql(Chk_Sacar_Productos_Sin_Rotacion, "Compras_Asistente",
                                             Chk_Sacar_Productos_Sin_Rotacion.Name, Class_SQLite.Enum_Type._Boolean, Chk_Sacar_Productos_Sin_Rotacion.Checked, _Actualizar)
        '   Ticket Restar Stock bodega
        _Sql.Sb_Parametro_Informe_Sql(Chk_Restar_Stok_Bodega, "Compras_Asistente",
                                             Chk_Restar_Stok_Bodega.Name, Class_SQLite.Enum_Type._Boolean, Chk_Restar_Stok_Bodega.Checked, _Actualizar)
        '   Ticket Quitar bloqueados compra
        _Sql.Sb_Parametro_Informe_Sql(Chk_Quitar_Bloqueados_Compra, "Compras_Asistente",
                                             Chk_Quitar_Bloqueados_Compra.Name, Class_SQLite.Enum_Type._Boolean, Chk_Quitar_Bloqueados_Compra.Checked, _Actualizar)
        '   Ticket Quitar con OCC o NVI
        _Sql.Sb_Parametro_Informe_Sql(Chk_No_Considera_Con_Stock_Pedido_OCC_NVI, "Compras_Asistente",
                                             Chk_No_Considera_Con_Stock_Pedido_OCC_NVI.Name, Class_SQLite.Enum_Type._Boolean, Chk_No_Considera_Con_Stock_Pedido_OCC_NVI.Checked, _Actualizar)
        '   Ticket Solo Stock critico
        _Sql.Sb_Parametro_Informe_Sql(Chk_Mostrar_Solo_Stock_Critico, "Compras_Asistente",
                                             Chk_Mostrar_Solo_Stock_Critico.Name, Class_SQLite.Enum_Type._Boolean, Chk_Mostrar_Solo_Stock_Critico.Checked, _Actualizar)

        '_Filtro_Bodegas_Est_Vta_Todas = True

        '   Venta promedio entre fechas
        '_Sql.Sb_Parametro_Informe_Sql(Rdb_Rango_Fechas_Vta_Promedio, "Compras_Asistente", _
        '                                     Rdb_Rango_Fechas_Vta_Promedio.Name, Class_SQLite.Enum_Type._Boolean, Rdb_Rango_Fechas_Vta_Promedio.Checked, _Actualizar)
        '_Sql.Sb_Parametro_Informe_Sql(Dtp_Fecha_Vta_Desde, "Compras_Asistente", _
        '                                     Dtp_Fecha_Vta_Desde.Name, Class_SQLite.Enum_Type._Date, Dtp_Fecha_Vta_Desde.Value, _Actualizar)
        '_Sql.Sb_Parametro_Informe_Sql(Dtp_Fecha_Vta_Hasta, "Compras_Asistente", _
        '                                     Dtp_Fecha_Vta_Hasta.Name, Class_SQLite.Enum_Type._Date, Dtp_Fecha_Vta_Hasta.Value, _Actualizar)

        '   Venta promedio en meses
        '_Sql.Sb_Parametro_Informe_Sql(Rdb_Rango_Meses_Vta_Promedio, "Compras_Asistente", _
        '                                     Rdb_Rango_Meses_Vta_Promedio.Name, Class_SQLite.Enum_Type._Boolean, Rdb_Rango_Meses_Vta_Promedio.Checked, _Actualizar)
        '_Sql.Sb_Parametro_Informe_Sql(Input_Ultimos_Meses_Vta_Promedio, "Compras_Asistente", _
        '                                     Input_Ultimos_Meses_Vta_Promedio.Name, Class_SQLite.Enum_Type._Double, Input_Ultimos_Meses_Vta_Promedio.Value, _Actualizar)

        '   Sumar Rotacion Hermanos, agrupar las rotaciones en un solo producto
        _Sql.Sb_Parametro_Informe_Sql(Chk_Sumar_Rotacion_Hermanos, "Compras_Asistente",
                                             Chk_Sumar_Rotacion_Hermanos.Name, Class_SQLite.Enum_Type._Boolean, Chk_Sumar_Rotacion_Hermanos.Checked, _Actualizar)

        '  Rotacion con entidades excluidas
        _Sql.Sb_Parametro_Informe_Sql(Chk_Rotacion_Con_Ent_Excluidas, "Compras_Asistente",
                                             Chk_Rotacion_Con_Ent_Excluidas.Name, Class_SQLite.Enum_Type._Boolean, Chk_Rotacion_Con_Ent_Excluidas.Checked, _Actualizar)

        '  Ocultar Bodegas sin Stock
        _Sql.Sb_Parametro_Informe_Sql(Fm_Hijo.Chk_Ocultar_BodSinStock, "Compras_Asistente",
                                             Fm_Hijo.Chk_Ocultar_BodSinStock.Name, Class_SQLite.Enum_Type._Boolean, Fm_Hijo.Chk_Ocultar_BodSinStock.Checked, _Actualizar)


        '  Solo provedores con código alternativo
        _Sql.Sb_Parametro_Informe_Sql(Chk_Solo_Proveedores_CodAlternativo, "Compras_Asistente",
                                             Chk_Solo_Proveedores_CodAlternativo.Name, Class_SQLite.Enum_Type._Boolean, Chk_Solo_Proveedores_CodAlternativo.Checked, _Actualizar, "Seleccion_Productos")

        'If Not _Eliminar_Todo Then
        Consulta_sql = "Select Chk,Codigo,Descripcion From " & _Global_BaseBk & "Zw_Tmp_Filtros_Busqueda 
                            Where Funcionario = '" & FUNCIONARIO & "' And Informe = 'Compras_Asistente' 
                            And Filtro = 'Bodegas_Stock' And NombreEquipo = '" & _NombreEquipo & "' And Modalidad = '" & _Modalidad_Estudio & "'"
        _TblBodCompra = _Sql.Fx_Get_Tablas(Consulta_sql)

        Consulta_sql = "Select Chk,Codigo,Descripcion From " & _Global_BaseBk & "Zw_Tmp_Filtros_Busqueda 
                           Where Funcionario = '" & FUNCIONARIO & "' And Informe = 'Compras_Asistente' 
                           And Filtro = 'Bodegas_Rotacion_Vta'  And NombreEquipo = '" & _NombreEquipo & "' And Modalidad = '" & _Modalidad_Estudio & "'"
        _TblBodVenta = _Sql.Fx_Get_Tablas(Consulta_sql)

        '   Calculo para saber cuanto comprar S.V.R en Mediana
        _Sql.Sb_Parametro_Informe_Sql(Rdb_Rot_Mediana, "Compras_Asistente",
                                             Rdb_Rot_Mediana.Name, Class_SQLite.Enum_Type._Boolean, Rdb_Rot_Mediana.Checked, _Actualizar)

        '   Calculo para saber cuanto comprar S.V.R en Promedio
        _Sql.Sb_Parametro_Informe_Sql(Rdb_Rot_Promedio, "Compras_Asistente",
                                             Rdb_Rot_Promedio.Name, Class_SQLite.Enum_Type._Boolean, Rdb_Rot_Promedio.Checked, _Actualizar)

        '   Incluir o no incluir movimientos hacia la producción (GDI -> ODT)
        _Sql.Sb_Parametro_Informe_Sql(Chk_Incluir_Salidas_GDI_OT, "Compras_Asistente",
                                             Chk_Incluir_Salidas_GDI_OT.Name, Class_SQLite.Enum_Type._Boolean, Chk_Incluir_Salidas_GDI_OT.Checked, _Actualizar)


    End Sub





    Private Sub Btn_Consolidar_Stock_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Consolidar_Stock.Click

        Dim _Filtro_Productos As String = Generar_Filtro_IN(_Tbl_Informe, "", "Codigo", False, False, "'")

        Dim Fm2 As New Frm_Consolidacion_Stock_PP(_Filtro_Productos)
        Fm2.ShowDialog(Me)
        Fm2.Dispose()

        Sb_Refrescar_Grilla_Principal(Fm_Hijo.Grilla, False, True)

    End Sub

    Private Sub Btn_Rotacion_Productos_Lista_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Rotacion_Productos_Lista.Click

        Dim Fm As New Frm_Rotacion_Selec_Prod_Parametros
        Fm.Chk_Incluir_Ventas_Entidades_Excluidas.Checked = Chk_Rotacion_Con_Ent_Excluidas.Checked
        Fm.Chk_Incluir_Ventas_Entidades_Excluidas.Enabled = False
        Fm.Pro_Tbl_Productos_Seleccionados = _Tbl_Informe
        Fm.Pro_Input_Dias_Advertencia_Rotacion = _RowParametros.Item("Input_Dias_Advertencia_Rotacion")
        Fm.Pro_Chk_Advertir_Rotacion = _RowParametros.Item("Chk_Advertir_Rotacion")

        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Private Sub Btn_Rotacion_Productos_Con_Rot_Vencida_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Rotacion_Productos_Con_Rot_Vencida.Click

        Dim _Fecha As Date = DateAdd(DateInterval.Month, -1, FechaDelServidor)

        Dim _Filtro_Productos As String = Generar_Filtro_IN(_Tbl_Informe, "", "Codigo", False, False, "'")

        Consulta_sql = "Select Codigo From " & _Nombre_Tbl_Paso_Informe & vbCrLf &
                       "Where Codigo In (Select Codigo From Zw_Prod_Rotacion" & vbCrLf &
                       "Where Fecha_Fin < '" & Format(_Fecha, "yyyyMMdd") & "' or Fecha_Fin is null" & vbCrLf &
                       "And Codigo Not in (Select KOPR From MAEPR Where TIPR = 'SSN')) And Codigo In " & _Filtro_Productos

        Dim _Tbl As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        If CBool(_Tbl.Rows.Count) Then

            Dim Fm As New Frm_Rotacion_Selec_Prod_Parametros
            Fm.Pro_Tbl_Productos_Seleccionados = _Tbl
            Fm.Pro_Input_Dias_Advertencia_Rotacion = _RowParametros.Item("Input_Dias_Advertencia_Rotacion")
            Fm.Pro_Chk_Advertir_Rotacion = _RowParametros.Item("Chk_Advertir_Rotacion")
            Fm.ShowDialog(Me)
            If Fm.Pro_Informe_Procesado Then
                'Call CmmdActualizarInf_Executed(Nothing, Nothing)
                'Sb_Refrescar_Grilla_Principal()
            End If
            Fm.Dispose()
        Else
            MessageBoxEx.Show(Me, "No existe información", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If


    End Sub

    Private Sub Btn_Actualizar_Rotacion_Producto_Actual_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Actualizar_Rotacion_Producto_Actual.Click

        Dim _Fila As DataGridViewRow = Fm_Hijo.Grilla.Rows(Fm_Hijo.Grilla.CurrentRow.Index)

        Dim _Codigo = _Fila.Cells("Codigo").Value
        Dim _Es_Agrupador = CInt(_Fila.Cells("Es_Agrupador").Value) * -1

        Consulta_sql = "Select '" & _Codigo & "' As Codigo"
        Dim _Tbl As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        Dim Fm As New Frm_Rotacion_Selec_Prod_Parametros
        Fm.Pro_Tbl_Productos_Seleccionados = _Tbl
        Fm.Chk_Incluir_Ventas_Entidades_Excluidas.Checked = Chk_Rotacion_Con_Ent_Excluidas.Checked
        Fm.Chk_Incluir_Ventas_Entidades_Excluidas.Enabled = False
        Fm.Pro_Input_Dias_Advertencia_Rotacion = _RowParametros.Item("Input_Dias_Advertencia_Rotacion")
        Fm.Pro_Chk_Advertir_Rotacion = _RowParametros.Item("Chk_Advertir_Rotacion")
        Fm.ShowDialog(Me)

        If Fm.Pro_Informe_Procesado Then

            Consulta_sql = "Update " & _Nombre_Tbl_Paso_Informe & " Set Dias_Existencia_Habiles = 0 Where Codigo = '" & _Codigo & "'"
            _Sql.Ej_consulta_IDU(Consulta_sql)

            Sb_Actualizar_Stock()
            Sb_Actualizar_Rotacion(_Codigo, True)

            Consulta_sql = "Select Top 1 * From " & _Nombre_Tbl_Paso_Informe & vbCrLf &
                           "Where Codigo = '" & _Codigo & "' And Es_Agrupador = " & _Es_Agrupador

            Dim _Row_Producto As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

            Dim _RotDiariaUd1 = _Row_Producto.Item("RotDiariaUd1")
            Dim _RotDiariaUd2 = _Row_Producto.Item("RotDiariaUd2")

            Dim _RotMensualUd1 = _Row_Producto.Item("RotMensualUd1")
            Dim _RotMensualUd2 = _Row_Producto.Item("RotMensualUd2")

            Dim _TStock = _Row_Producto.Item("TStock")
            Dim _Stock_CriticoUd1_Rd = _Row_Producto.Item("Stock_CriticoUd1_Rd")
            Dim _Stock_CriticoUd2_Rd = _Row_Producto.Item("Stock_CriticoUd2_Rd")
            Dim _CantSugeridaTot = _Row_Producto.Item("CantSugeridaTot")
            Dim _Refleo = _Row_Producto.Item("Refleo")
            Dim _Sospecha_Baja_Rotacion = _Row_Producto.Item("Sospecha_Baja_Rotacion")
            Dim _Comprar = _Row_Producto.Item("Comprar")

            'Dim _Ud As Integer
            'If Rdb_Ud1_Compra.Checked Then : _Ud = 1 : Else : _Ud = 2 : End If

            Dim _StockUd1 As Double = _Row_Producto.Item("StockUd1")
            Dim _StockUd2 As Double = _Row_Producto.Item("StockUd2")

            _Fila.Cells("RotDiariaUd1").Value = _RotDiariaUd1
            _Fila.Cells("RotDiariaUd2").Value = _RotDiariaUd2
            _Fila.Cells("RotMensualUd1").Value = _RotMensualUd1
            _Fila.Cells("RotMensualUd2").Value = _RotMensualUd2

            _Fila.Cells("StockUd1").Value = _StockUd1
            _Fila.Cells("StockUd2").Value = _StockUd2

            _Fila.Cells("TStock").Value = _TStock
            _Fila.Cells("Stock_CriticoUd1_Rd").Value = _Stock_CriticoUd1_Rd
            _Fila.Cells("Stock_CriticoUd2_Rd").Value = _Stock_CriticoUd2_Rd
            _Fila.Cells("CantSugeridaTot").Value = _CantSugeridaTot
            _Fila.Cells("Refleo").Value = _Refleo
            _Fila.Cells("Sospecha_Baja_Rotacion").Value = _Sospecha_Baja_Rotacion
            _Fila.Cells("Comprar").Value = _Comprar

            _Fila.Cells("Informacion_Fila").Value = String.Empty

            Sb_Marcar_Fila_Grilla(_Fila, False, Fx_Dias_Proyeccion)

            Call Grilla_CellEnter(Fm_Hijo.Grilla, Nothing)

        End If
        Fm.Dispose()

    End Sub

    Sub Sb_Actualizar_Rotacion_Productos_Agrupadores(ByVal _Fila As DataGridViewRow)

        Dim _Codigo = _Fila.Cells("Codigo").Value
        Dim _CodigoGenerico = _Fila.Cells("CodigoGenerico").Value
        Dim _Es_Agrupador = CInt(_Fila.Cells("Es_Agrupador").Value) * -1


        Consulta_sql = "Select Codigo From " & _Nombre_Tbl_Paso_Informe & vbCrLf &
               "Where CodigoGenerico = '" & _CodigoGenerico & "' And Es_Agrupador = 0"

        Dim _Tbl As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        For Each _Row As DataRow In _Tbl.Rows
            Dim _New_codigo = _Row.Item("Codigo")
            Sb_Actualizar_Rotacion(_New_codigo, True)
        Next

        Dim _Condicion_Especial = "Where CodigoGenerico = '" & _CodigoGenerico & "' And Es_Agrupador = 0" & vbCrLf

        Dim _Condicion As String = String.Empty

        If Chk_Restar_Stok_Bodega.Checked Then
            _Condicion += vbCrLf & "And Cant_Comprar_Restando_Stock > 0" '"And Cant_Comprar_ReStock > 0"
        Else
            _Condicion += vbCrLf & "Cant_Comprar_Sin_Restar_Stock > 0" '"And Cant_Comprar_SnStock > 0"
        End If

        If Chk_Mostrar_Solo_Stock_Critico.Checked Then
            _Condicion += vbCrLf & "And Con_Stock_CriticoUd = 1" '"And Diferencia_StCriUd" & Ud & " < 0"
        End If

        If Chk_No_Considera_Con_Stock_Pedido_OCC_NVI.Checked Then
            _Condicion += vbCrLf & "And StockPedidoUd <= 0"
        End If

        Dim _Update_Dias As String

        _Update_Dias = "Update #Paso Set Dias = (Select Max(Dias_Existencia_Habiles) From " & _Nombre_Tbl_Paso_Informe & Space(1) &
                       "Z1 Where Z1.CodigoGenerico = #Paso.CodigoGenerico)" & vbCrLf

        If Chk_Sabado.Checked Then
            _Update_Dias += "+(Select Max(Dias_Existencia_Sabados) From " & _Nombre_Tbl_Paso_Informe & Space(1) &
                           "Z1 Where Z1.CodigoGenerico = #Paso.CodigoGenerico)" & vbCrLf
        End If

        If Chk_Domingo.Checked Then
            _Update_Dias += "+(Select Max(Dias_Existencia_Domingos) From " & _Nombre_Tbl_Paso_Informe & Space(1) &
                           "Z1 Where Z1.CodigoGenerico = #Paso.CodigoGenerico)" & vbCrLf
        End If

        'Dim _Ud
        'If Rdb_Ud1_Compra.Checked Then : _Ud = 1 : Else : _Ud = 2 : End If

        Dim _Tbl_Genericos As DataTable
        Consulta_sql = My.Resources.Recursos_Asis_Compras.SQLQuery_Llena_tablas_Agrupa_Genericos_para_estudio
        Consulta_sql = Replace(Consulta_sql, "#Tabla#", _Nombre_Tbl_Paso_Informe)
        Consulta_sql = Replace(Consulta_sql, "#Ud#", _Ud)
        Consulta_sql = Replace(Consulta_sql, "#Condicion_Especial#", _Condicion_Especial)
        Consulta_sql = Replace(Consulta_sql, "#Condicion#", _Condicion)
        Consulta_sql = Replace(Consulta_sql, "#Tiempo_Reposicion#", Input_Tiempo_Reposicion.Value)
        Consulta_sql = Replace(Consulta_sql, "#Dias_Avastecer#", Input_Dias_a_Abastecer.Value)
        Consulta_sql = Replace(Consulta_sql, "#Porc_Crecimiento#", 1)
        Consulta_sql = Replace(Consulta_sql, "#Update_Dias#", _Update_Dias)

        _Tbl_Genericos = _Sql.Fx_Get_Tablas(Consulta_sql) '_SQL.Fx_Get_Tablas(Consulta_sql)

        If CBool(_Tbl_Genericos.Rows.Count) Then

            Dim _CantComprar As String
            ' PREGUNTA QUE CANTIDAD CALCULADA COMPRAR
            If Chk_Restar_Stok_Bodega.Checked Then
                'CANTIDAD SUGERIDA RESTANDO STOCK DE BODEGA
                _CantComprar = _Tbl_Genericos.Rows(0).Item("Cant_Comprar_Restando_Stock")
            Else
                'CANTIDAD SUGERIDAD SIN RESTAR STOCK DE BODEGA
                _CantComprar = _Tbl_Genericos.Rows(0).Item("Cant_Comprar_Sin_Restar_Stock")
            End If

            Dim _Con_Stock_CriticoUd = CInt(_Tbl_Genericos.Rows(0).Item("Con_Stock_CriticoUd")) * -1

            Dim _StockUd = De_Num_a_Tx_01(_Tbl_Genericos.Rows(0).Item("StockUd"), False, 5)
            Dim _RotDiariaUd = De_Num_a_Tx_01(_Tbl_Genericos.Rows(0).Item("RotDiariaUd"), False, 5)
            Dim _Stock_CriticoUd_Rd = De_Num_a_Tx_01(_Tbl_Genericos.Rows(0).Item("Stock_CriticoUd_Rd"), False, 5)
            Dim _StockPedidoUd = De_Num_a_Tx_01(_Tbl_Genericos.Rows(0).Item("StockPedidoUd"), False, 5)

            Consulta_sql = "Update " & _Nombre_Tbl_Paso_Informe & " Set " & vbCrLf &
                           "CantComprar = " & _CantComprar & "," & vbCrLf &
                           "StockUd" & Ud & " = " & _StockUd & "," & vbCrLf &
                           "RotDiariaUd" & Ud & " = " & _RotDiariaUd & "," & vbCrLf &
                           "Stock_CriticoUd" & Ud & "_Rd = " & _Stock_CriticoUd_Rd & "," & vbCrLf &
                           "StockPedidoUd" & Ud & " = " & _StockPedidoUd & "," & vbCrLf &
                           "Con_Stock_CriticoUd" & Ud & " = " & _Con_Stock_CriticoUd & vbCrLf &
                           "Where Codigo = '" & _Codigo & "' And Es_Agrupador = 1"
            _Sql.Ej_consulta_IDU(Consulta_sql)

            _Fila.Cells("CantComprar").Value = _CantComprar

        End If

        Sb_Actulizar_Refleo_Baja_Rotacion()

        Consulta_sql = "Select Top 1 * From " & _Nombre_Tbl_Paso_Informe & vbCrLf &
                       "Where Codigo = '" & _Codigo & "' And Es_Agrupador = " & _Es_Agrupador

        Dim _Row_Producto As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        Dim _RotDiariaUd1 = _Row_Producto.Item("RotDiariaUd1")
        Dim _RotDiariaUd2 = _Row_Producto.Item("RotDiariaUd2")
        Dim _TStock = _Row_Producto.Item("TStock")
        Dim _Stock_CriticoUd1_Rd = _Row_Producto.Item("Stock_CriticoUd1_Rd")
        Dim _Stock_CriticoUd2_Rd = _Row_Producto.Item("Stock_CriticoUd2_Rd")
        Dim _CantSugeridaTot = _Row_Producto.Item("CantSugeridaTot")
        Dim _Refleo = _Row_Producto.Item("Refleo")
        Dim _Sospecha_Baja_Rotacion = _Row_Producto.Item("Sospecha_Baja_Rotacion")
        Dim _Comprar = _Row_Producto.Item("Comprar")

        _Fila.Cells("RotDiariaUd1").Value = _RotDiariaUd1
        _Fila.Cells("RotDiariaUd2").Value = _RotDiariaUd2
        _Fila.Cells("TStock").Value = _TStock
        _Fila.Cells("Stock_CriticoUd1_Rd").Value = _Stock_CriticoUd1_Rd
        _Fila.Cells("Stock_CriticoUd2_Rd").Value = _Stock_CriticoUd2_Rd
        _Fila.Cells("CantSugeridaTot").Value = _CantSugeridaTot
        _Fila.Cells("Refleo").Value = _Refleo
        _Fila.Cells("Sospecha_Baja_Rotacion").Value = _Sospecha_Baja_Rotacion
        _Fila.Cells("Comprar").Value = _Comprar

        Sb_Marcar_Fila_Grilla(_Fila, False, Fx_Dias_Proyeccion)

    End Sub

    Sub Sb_Actulizar_Refleo_Baja_Rotacion()

        'Dim _Ud
        'If Rdb_Ud1_Compra.Checked Then : _Ud = 1 : Else : _Ud = 2 : End If

        Dim _Dias_Habiles = Fx_Cuenta_Dias(Convert.ToDateTime("01/01/" & FechaDelServidor.Year),
                                             Convert.ToDateTime("31/12/" & FechaDelServidor.Year), Opcion_Dias.Habiles)
        Dim _Dias_Sabado = Fx_Cuenta_Dias(Convert.ToDateTime("01/01/" & FechaDelServidor.Year),
                                            Convert.ToDateTime("31/12/" & FechaDelServidor.Year), Opcion_Dias.Sabado)
        Dim _Dias_Domingo = Fx_Cuenta_Dias(Convert.ToDateTime("01/01/" & FechaDelServidor.Year),
                                            Convert.ToDateTime("31/12/" & FechaDelServidor.Year), Opcion_Dias.Domingo)


        Dim _Dias = _Dias_Habiles
        Dim _Filtro_Dias As String

        If Chk_Sabado.Checked Then
            _Dias += _Dias_Sabado
            _Filtro_Dias += "+Dias_Existencia_Sabados"
        End If

        If Chk_Domingo.Checked Then
            _Dias += _Dias_Domingo
            _Filtro_Dias += "+Dias_Existencia_Domingos"
        End If

        Consulta_sql = "Update " & _Nombre_Tbl_Paso_Informe & " Set Refleo = 0,Sospecha_Baja_Rotacion = 0" &
                       vbCrLf &
                       "Update " & _Nombre_Tbl_Paso_Informe & " Set Refleo = 1" & vbCrLf &
                       "Where (Dias_Existencia_Habiles" & _Filtro_Dias & ") <=" & _Dias & Space(1) &
                       "And FCV+BLV = 1 And Comprar_Igual = 0" &
                       vbCrLf &
                       vbCrLf &
                       "Update " & _Nombre_Tbl_Paso_Informe & " Set Sospecha_Baja_Rotacion = 1" & vbCrLf &
                       "Where CantSugeridaTot > 0.5" & Space(1) &
                       "And FCV+BLV <= 5 And Refleo = 0" &
                       vbCrLf &
                       vbCrLf &
                       "Update " & _Nombre_Tbl_Paso_Informe & " Set Sospecha_Baja_Rotacion = 1" & vbCrLf &
                       "Where CantSugeridaTot < 0.45 And (FCV+BLV between 2 And 5 OR RotMensualUd" & Ud & " < 0.5)"
        '"Where CantSugeridaTot <  0.45 And FCV+BLV between 2 And 5"

        _Sql.Ej_consulta_IDU(Consulta_sql)

        Consulta_sql = "Update " & _Nombre_Tbl_Paso_Informe & " Set Comprar = 0" & vbCrLf &
                       "Where (Dias_Existencia_Habiles" & _Filtro_Dias & ") <=" & _Dias & Space(1) &
                       "And FCV+BLV = 1 And Comprar_Igual = 0" &
                       vbCrLf &
                       vbCrLf &
                       "Update " & _Nombre_Tbl_Paso_Informe & " Set Comprar = 0" & vbCrLf &
                       "Where CantSugeridaTot > 0.5" & Space(1) &
                       "And FCV+BLV <= 5 And Refleo = 0 And Comprar_Igual = 0" &
                       vbCrLf &
                       "Update " & _Nombre_Tbl_Paso_Informe & " Set Comprar = 0" & vbCrLf &
                       "Where CantSugeridaTot <  0.45 And FCV+BLV between 2 And 5 And Comprar_Igual = 0" &
                       vbCrLf &
                       "Update " & _Nombre_Tbl_Paso_Informe & " Set Comprar = 1" & vbCrLf &
                       "Where Sospecha_Baja_Rotacion = 0 And CantSugeridaTot > 0 And FCV+BLV > 5 And Comprar_Igual = 0"

        _Sql.Ej_consulta_IDU(Consulta_sql)



    End Sub

    Private Sub BtnSelectEstrellas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSelectEstrellas.Click

        Dim Fm As New Frm_Filtro_Especial_Productos
        Fm.Pro_Filtro_Clalibpr_Todas = _Filtro_Clalibpr_Todas
        Fm.Pro_Filtro_Marcas_Todas = _Filtro_Marcas_Todas
        Fm.Pro_Filtro_Rubro_Todas = _Filtro_Rubro_Todas
        Fm.Pro_Filtro_Super_Familias_Todas = _Filtro_Super_Familias_Todas
        Fm.Pro_Filtro_Zonas_Todas = _Filtro_Zonas_Todas

        Fm.Pro_Tbl_Filtro_Clalibpr = _Tbl_Filtro_Clalibpr
        Fm.Pro_Tbl_Filtro_Marcas = _Tbl_Filtro_Marcas
        Fm.Pro_Tbl_Filtro_Rubro = _Tbl_Filtro_Rubro
        Fm.Pro_Tbl_Filtro_Super_Familias = _Tbl_Filtro_Super_Familias
        Fm.Pro_Tbl_Filtro_Zonas = _Tbl_Filtro_Zonas

        Fm.ShowDialog(Me)

        _Tbl_Filtro_Clalibpr = Fm.Pro_Tbl_Filtro_Clalibpr
        _Tbl_Filtro_Marcas = Fm.Pro_Tbl_Filtro_Marcas
        _Tbl_Filtro_Rubro = Fm.Pro_Tbl_Filtro_Rubro
        _Tbl_Filtro_Super_Familias = Fm.Pro_Tbl_Filtro_Super_Familias
        _Tbl_Filtro_Zonas = Fm.Pro_Tbl_Filtro_Zonas

        _Filtro_Clalibpr_Todas = Fm.Pro_Filtro_Clalibpr_Todas
        _Filtro_Marcas_Todas = Fm.Pro_Filtro_Marcas_Todas
        _Filtro_Rubro_Todas = Fm.Pro_Filtro_Rubro_Todas
        _Filtro_Super_Familias_Todas = Fm.Pro_Filtro_Super_Familias_Todas
        _Filtro_Zonas_Todas = Fm.Pro_Filtro_Zonas_Todas

        Fm.Dispose()

    End Sub

    Private Sub Btn_Crear_Orden_Asistente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Crear_Orden_Asistente.Click

        Dim _RowFormato As DataRow = Fx_Formato_Modalidad(Me, _Modalidad_Estudio, "OCC", True)

        If Not (_RowFormato Is Nothing) Then

            Dim _MaxLineas As Integer = _RowFormato.Item("NroLineasXpag")

            Sb_Crear_OCC(Fm_Hijo.Grilla)

        End If

    End Sub

    Private Sub Btn_Crear_Orden_Compra_Nueva_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Crear_Orden_Compra_Nueva.Click

        Dim Fm As New Frm_Formulario_Documento("OCC", csGlobales.Enum_Tipo_Documento.Compra, False, False, True)
        Fm.MinimizeBox = False
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Private Sub Btn_Proyeccion_Mensual_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Proyeccion_Mensual.Click

        Sb_Parametros_Actualizar()

        Dim _Filtro_Bodega As String

        If _Filtro_Bodegas_Todas Then
            _Filtro_Bodega = String.Empty
        Else
            _Filtro_Bodega = Generar_Filtro_IN(_TblBodCompra, "Chk", "Codigo", False, True, "'")
            _Filtro_Bodega = "And EMPRESA+KOSU+KOBO In " & _Filtro_Bodega
        End If

        Consulta_sql = My.Resources.Recursos_Asis_Compras.SQLQuery_Inserta_stock_por_producto
        Consulta_sql = Replace(Consulta_sql, "#TablaPaso#", _Nombre_Tbl_Paso_Informe)
        Consulta_sql = Replace(Consulta_sql, "#CodFuncionario#", FUNCIONARIO)
        Consulta_sql = Replace(Consulta_sql, "#Filtro_Bodega#", _Filtro_Bodega)

        Dim Fm As New Frm_AsisCompra_Proyeccion(Consulta_sql, Nothing)
        Fm.Pro_Porc_Crecimiento = Input_Porc_Crecimiento.Value
        Fm.ShowDialog(Me)

        Input_Porc_Crecimiento.Value = Fm.Pro_Porc_Crecimiento

        Sb_Parametros_Revisar()

        Fm.Dispose()

    End Sub

    Private Sub Btn_Dejar_En_Cero_Refleos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Dejar_En_Cero_Refleos.Click

        If MessageBoxEx.Show(Me, "¿Confirma dejar todas las cantidades a comprar en cero [0]?" & vbCrLf &
                             "Solo de la vista actual Y productos marcados con refleo (Ventas Calzadas)", "Confirmación",
                             MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then


            Consulta_sql = String.Empty

            For Each _Fila As DataGridViewRow In Fm_Hijo.Grilla.Rows

                Dim _Codigo As String = _Fila.Cells.Item("Codigo").Value
                Dim _OccGenerada As Boolean = _Fila.Cells.Item("OccGenerada").Value
                Dim _Refleo As Boolean = _Fila.Cells.Item("Refleo").Value

                If _Refleo Then
                    _Fila.Cells.Item("CantComprar").Value = 0
                    Dim _Dias_Proyeccion As Integer = Fx_Dias_Proyeccion()
                    Sb_Marcar_Fila_Grilla(_Fila, False, _Dias_Proyeccion)

                    Consulta_sql += "Update " & _Nombre_Tbl_Paso_Informe & " Set CantComprar = 0" & Space(1) &
                                    "Where Codigo = '" & _Codigo & "'" & vbCrLf
                End If

            Next

            If Not String.IsNullOrEmpty(Consulta_sql) Then
                _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql)
            End If

            MessageBoxEx.Show(Me, "Cantidades limpias", "Cantidades en Cero",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information)

        End If

    End Sub

    Private Sub Btn_Quitar_Filtro_Proveedor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        _RowProveedor = Nothing
        Fm_Hijo.Txt_Proveedor.Text = String.Empty
        Sb_Grilla_Actualizar_Informe(Fm_Hijo.Grilla)
        Sb_Grilla_Marcar(Fm_Hijo.Grilla, False)
        Fm_Hijo.Btn_Quitar_Filtro_Proveedor.Enabled = False
        Btn_Quitar_Filtro_Proveedor_Ribon.Enabled = False

    End Sub

    Private Sub Grilla_CellMouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs)
        sender.EndEdit()
    End Sub

    Private Sub Btn_Filtrar_Proveedor_Ribon_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Filtrar_Proveedor_Ribon.Click
        Call Btn_Filtrar_Proveedor_Click(Nothing, Nothing)
    End Sub

    Private Sub Btn_Quitar_Filtro_Proveedor_Ribon_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Quitar_Filtro_Proveedor_Ribon.Click
        Call Btn_Quitar_Filtro_Proveedor_Click(Nothing, Nothing)
    End Sub

    Private Sub Btn_Expor_Excel_Productos_Agrupadores_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Expor_Excel_Productos_Agrupadores.Click
        Consulta_sql = "Select * From " & _Nombre_Tbl_Paso_Informe & vbCrLf &
                       "Where Es_Agrupador = 1"
        ExportarTabla_JetExcel(Consulta_sql, Me)
    End Sub

    Private Sub Grilla_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs)
        Try

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Btn_Entidades_Excluidas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Entidades_Excluidas.Click
        Dim Fm As New Frm_EntExcluidas
        Fm.ShowInTaskbar = False
        Fm.ShowDialog(Me)
        Fm.Dispose()
    End Sub

    Private Sub Cmb_Proyeccion_Metodo_Abastecer_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim _Valor As Integer = Cmb_Metodo_Abastecer_Dias_Meses.SelectedValue

        Cmb_Tiempo_Reposicion_Dias_Meses.SelectedValue = _Valor

        Select Case _Valor

            Case 1
                Input_Dias_a_Abastecer.MaxValue = 60
                Input_Dias_a_Abastecer.Value = 7
                Input_Tiempo_Reposicion.MaxValue = 60
                Input_Tiempo_Reposicion.Value = 1
            Case 7
                Input_Dias_a_Abastecer.MaxValue = 4
                Input_Dias_a_Abastecer.Value = 1
                Input_Tiempo_Reposicion.MaxValue = 4
                Input_Tiempo_Reposicion.Value = 1
            Case 30
                Input_Dias_a_Abastecer.MaxValue = 6
                Input_Dias_a_Abastecer.Value = 1
                Input_Tiempo_Reposicion.MaxValue = 6
                Input_Tiempo_Reposicion.Value = 1
            Case Else

        End Select

    End Sub
    Private Sub Cmb_Tiempo_Reposicion_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim _Valor As Integer = Cmb_Tiempo_Reposicion_Dias_Meses.SelectedValue

        Select Case _Valor

            Case 1
                Input_Tiempo_Reposicion.MaxValue = 60
                Input_Tiempo_Reposicion.Value = 7
            Case 7
                Input_Tiempo_Reposicion.MaxValue = 4
                Input_Tiempo_Reposicion.Value = 1
            Case 30
                Input_Tiempo_Reposicion.MaxValue = 6
                Input_Tiempo_Reposicion.Value = 1
            Case Else

        End Select

    End Sub

    Function Fx_Dias_Proyeccion() As Integer

        Dim _UsarSabado = CInt(Chk_Sabado.Checked) * -1
        Dim _UsarDomingo = CInt(Chk_Domingo.Checked) * -1
        Dim _Dias_Abastecer = Input_Dias_a_Abastecer.Value
        Dim _Tiempo_Reposicion = Input_Tiempo_Reposicion.Value
        Dim _Porc_Crecimiento = 1 + (Input_Porc_Crecimiento.Value / 100) 'Input_Porc_Crecimiento.Value 

        Dim _Fecha_Fin = DateAdd(DateInterval.Day, _Dias_Abastecer, FechaDelServidor)

        _Dias_Abastecer = Fx_Cuenta_Dias(FechaDelServidor, _Fecha_Fin, Opcion_Dias.Habiles)

        Dim _Sabados As Integer = Fx_Cuenta_Dias(FechaDelServidor, _Fecha_Fin, Opcion_Dias.Sabado)
        Dim _Domingos As Integer = Fx_Cuenta_Dias(FechaDelServidor, _Fecha_Fin, Opcion_Dias.Domingo)

        Dim _Dias_Proyeccion '= Input_Dias_a_Abastecer.Value * Cmb_Proyeccion_Metodo_Abastecer.SelectedValue + _Tiempo_Reposicion

        Dim _Campos As Integer

        Select Case Cmb_Metodo_Abastecer_Dias_Meses.SelectedValue
            Case 1
                _Dias_Proyeccion = 1 : _Campos = 60 '_Dias_Abastecer
            Case 7
                _Dias_Proyeccion = 5 : _Campos = 20
            Case 30
                _Dias_Proyeccion = 22 : _Campos = 12
        End Select

        If Chk_Sabado.Checked Then
            _Dias_Abastecer += _Sabados
            Select Case Cmb_Metodo_Abastecer_Dias_Meses.SelectedValue
                Case 7
                    _Dias_Proyeccion += 1
                Case 30
                    _Dias_Proyeccion += 2
            End Select
        End If

        If Chk_Domingo.Checked Then
            _Dias_Abastecer += _Domingos
            Select Case Cmb_Metodo_Abastecer_Dias_Meses.SelectedValue
                Case 7
                    _Dias_Proyeccion += 1
                Case 30
                    _Dias_Proyeccion += 2
            End Select
        End If

        Return _Dias_Proyeccion

    End Function

    Private Sub Btn_Productos_Reemplazo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Productos_Reemplazo.Click

        Dim _Fila As DataGridViewRow = Fm_Hijo.Grilla.Rows(Fm_Hijo.Grilla.CurrentRow.Index)

        Dim _Codigo As String = _Fila.Cells("Codigo").Value
        Dim _Grabar As Boolean


        Dim Fm As New Frm_ProductosReemplazo(_Codigo)
        Fm.ShowDialog(Me)
        _Grabar = Fm.Pro_Grabar
        Fm.Dispose()

        If _Grabar Then
            Sb_Refrescar_Grilla_Principal(Fm_Hijo.Grilla, False, True)
        End If

    End Sub

    Private Sub Btn_Poner_Cantidades_Comprar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Poner_Cantidades_Comprar.Click

        Try

            Fm_Hijo.ProgressBarX1.Visible = True
            Fm_Hijo.ProgressBarX1.Maximum = Fm_Hijo.Grilla.Rows.Count

            Dim _Dias_Proyeccion As Integer = Fx_Dias_Proyeccion()

            For Each _Row As DataGridViewRow In Fm_Hijo.Grilla.Rows
                Application.DoEvents()

                'Sb_Actualizar_Rotacion_Productos_Agrupadores(_Row)
                Dim _Codigo As String = _Row.Cells("Codigo").Value
                Dim _CantComprar As Double
                Dim _CantSugeridaTot As Double = _Row.Cells("CantSugeridaTot").Value

                _CantComprar = Math.Ceiling(_CantSugeridaTot)

                Consulta_sql = "Update " & _Nombre_Tbl_Paso_Informe & Space(1) &
                               "Set CantComprar = " & De_Num_a_Tx_01(_CantComprar, False, 5) & vbCrLf &
                               "Where Codigo = '" & _Codigo & "' And Es_Agrupador = 1"

                If _Sql.Ej_consulta_IDU(Consulta_sql) Then
                    _Row.Cells("CantComprar").Value = _CantComprar
                    Sb_Marcar_Fila_Grilla(_Row, False, _Dias_Proyeccion)
                End If

                Fm_Hijo.ProgressBarX1.Value += 1
                Fm_Hijo.ProgressBarX1.Text = "Procesados " & FormatNumber(Fm_Hijo.ProgressBarX1.Value, 0) & " de " &
                                     FormatNumber(Fm_Hijo.Grilla.Rows.Count, 0)

            Next

            MessageBoxEx.Show(Me, "Proceso generado correctamente", "Asociación automática",
                          MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBoxEx.Show(Me, ex.Message)
        Finally
            Fm_Hijo.ProgressBarX1.Value = 0
            Me.Enabled = True
            Fm_Hijo.ProgressBarX1.Visible = False
        End Try

        Me.Refresh()

    End Sub

    Private Sub Sb_Rdb_Agrupar_CheckedChanged(ByVal sender As System.Object, ByVal e As DevComponents.DotNetBar.CheckBoxChangeEventArgs)
        Fm_Hijo.Lbl_Costos_Desde.Visible = Rdb_Agrupar_x_Asociados.Checked
        'Cmb_Nodo_Raiz_Asociados.Visible = Rdb_Agrupar_x_Asociados.Checked
    End Sub

    Private Sub Btn_Agrupar_rotacion_de_reemplazos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Rb_Calculo_Cantidad.Click

        Dim _Filtro_Bodega As String

        If _Filtro_Bodegas_Todas Then
            _Filtro_Bodega = String.Empty
        Else
            _Filtro_Bodega = Generar_Filtro_IN(_TblBodCompra, "Chk", "Codigo", False, True, "'")
            _Filtro_Bodega = "And EMPRESA+KOSU+KOBO In " & _Filtro_Bodega
        End If

        Consulta_sql = My.Resources.Recursos_Asis_Compras.SQLQuery_Inserta_stock_por_producto
        Consulta_sql = Replace(Consulta_sql, "#TablaPaso#", _Nombre_Tbl_Paso_Informe)
        Consulta_sql = Replace(Consulta_sql, "#CodFuncionario#", FUNCIONARIO)
        Consulta_sql = Replace(Consulta_sql, "#Filtro_Bodega#", _Filtro_Bodega)

        Dim Fm As New Frm_AsisCompra_Proyeccion(Consulta_sql, _Clas_Asistente_Compras)

        Fm.Cmb_Metodo_Abastecer_Dias_Meses.SelectedValue = Cmb_Metodo_Abastecer_Dias_Meses.SelectedValue
        Fm.Input_Dias_a_Abastecer.Value = Input_Dias_a_Abastecer.Value
        Fm.Cmb_Tiempo_Reposicion_Dias_Meses.SelectedValue = Cmb_Tiempo_Reposicion_Dias_Meses.SelectedValue
        Fm.Input_Tiempo_Reposicion.Value = Input_Tiempo_Reposicion.Value
        Fm.Chk_Sabado.Checked = Chk_Sabado.Checked
        Fm.Chk_Domingo.Checked = Chk_Domingo.Checked
        Fm.Rdb_Ud1_Compra.Checked = Rdb_Ud1_Compra.Checked
        Fm.Rdb_Ud2_Compra.Checked = Rdb_Ud2_Compra.Checked
        Fm.Pro_Porc_Crecimiento = Input_Porc_Crecimiento.Value
        Fm.Rdb_Rot_Mediana.Checked = Rdb_Rot_Mediana.Checked
        Fm.Rdb_Rot_Promedio.Checked = Rdb_Rot_Promedio.Checked
        Fm.ShowDialog(Me)
        Rdb_Rot_Mediana.Checked = Fm.Rdb_Rot_Mediana.Checked
        Rdb_Rot_Promedio.Checked = Fm.Rdb_Rot_Promedio.Checked
        Fm.Dispose()

    End Sub

    Sub Sb_Actualizar_Rotacion_Agrupando_Por_Asociacion(ByVal _Nodo_Raiz As String)

        Try

            Consulta_sql = "Update " & _Global_BaseBk & "Zw_Prod_Stock_Enc_History" & vbCrLf &
                           "Set Codigo_Nodo_Madre = Isnull((Select Top 1 Codigo_Nodo From " & _Global_BaseBk & "Zw_Prod_Asociacion Z2" & vbCrLf &
                           "Where Para_filtro = 1 And" & Space(1) &
                           "Codigo_Nodo In (Select Codigo_Nodo From " & _Global_BaseBk & "Zw_TblArbol_Asociaciones Where Nodo_Raiz = " & _Nodo_Raiz_Asociados & " )" & Space(1) &
                           "And Z2.Codigo = Z1.Codigo),0)" & vbCrLf &
                           "From " & _Global_BaseBk & "Zw_Prod_Stock_Enc_History Z1"
            _Sql.Ej_consulta_IDU(Consulta_sql)


            Dim _Filtro_Productos = String.Empty

            Chk_Mostrar_Solo_Stock_Critico.Checked = False

            'Sb_Refrescar_Grilla_Principal()
            Me.Enabled = False

            'Consulta_sql = "Update " & _Nombre_Tbl_Paso_Informe & " Set " & vbCrLf & _
            '               "CodigoGenerico = Isnull((Select Codigo_Nodo From " & _Global_BaseBk & "Zw_Prod_Asociacion Z2" & vbCrLf & _
            '               "Where Z1.Codigo = Z2.Codigo And Para_filtro = 1 And" & vbCrLf & _
            '               "Z2.Codigo_Nodo In (Select Codigo_Nodo From " & _Global_BaseBk & "Zw_TblArbol_Asociaciones" & vbCrLf & _
            '               "Where Nodo_Raiz = " & _Nodo_Raiz & " And Es_Seleccionable =1)),''),Es_Agrupador = 0, Comprar = 1" & vbCrLf & _
            '               "From " & _Nombre_Tbl_Paso_Informe & " Z1" & vbCrLf & _
            '               "Delete " & _Nombre_Tbl_Paso_Informe & " Where CodigoGenerico = ''"

            Consulta_sql = "Update " & _Nombre_Tbl_Paso_Informe & Space(1) &
                           "Set Codigo_Nodo_Madre = (Select Codigo_Nodo_Madre From " & _Global_BaseBk & "Zw_Prod_Stock_Enc_History Z2" & Space(1) &
                           "Where Z1.Codigo = Z2.Codigo)" & vbCrLf &
                           "From " & _Nombre_Tbl_Paso_Informe & " Z1"
            _Sql.Ej_consulta_IDU(Consulta_sql)

            Consulta_sql = "Update " & _Nombre_Tbl_Paso_Informe & Space(1) &
                           "Set Descripcion_Madre = Isnull((Select Descripcion From " & _Global_BaseBk & "Zw_TblArbol_Asociaciones" & Space(1) &
                           "Where Codigo_Nodo = Codigo_Nodo_Madre),'')"
            _Sql.Ej_consulta_IDU(Consulta_sql)

            Consulta_sql = "Select Codigo,Codigo_Nodo_Madre From " & _Nombre_Tbl_Paso_Informe & vbCrLf &
                           "Order By Codigo_Nodo_Madre"
            Dim _Tbl As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

            Fm_Hijo.ProgressBarX1.Value = 0
            Fm_Hijo.ProgressBarX1.Visible = True
            Fm_Hijo.ProgressBarX1.Maximum = _Tbl.Rows.Count


            'For Each _Fila As DataRow In _Tbl.Rows

            'Application.DoEvents()

            'Dim _Codigo = _Fila.Item("Codigo")
            'Dim _Codigo_Nodo_Madre = _Fila.Item("Codigo_Nodo_Madre")
            'Dim _Descripcion_Madre = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_TblArbol_Asociaciones", "Descripcion", "Codigo_Nodo = " & _Codigo_Nodo_Madre)


            ' Consulta_sql = "Update " & _Nombre_Tbl_Paso_Informe & " Set Es_Agrupador = 1,Descripcion = '" & _Descripcion_Madre & "'" & vbCrLf & _
            '               "Where Codigo_Nodo_Madre = '" & _Codigo_Nodo_Madre & "' And Codigo = '" & _Codigo & "'"
            '_Sql.Ej_consulta_IDU(Consulta_sql)

            'Consulta_sql = "Delete " & _Nombre_Tbl_Paso_Informe & vbCrLf & _
            '               "Where Codigo_Nodo_Madre = '" & _Codigo_Nodo_Madre & "' And Codigo <> '" & _Codigo & "' And Es_Agrupador = 0"
            '_Sql.Ej_consulta_IDU(Consulta_sql)

            'ProgressBarX1.Value += 1
            'ProgressBarX1.Text = "Procesando " & FormatNumber(ProgressBarX1.Value, 0) & " de " & _
            'FormatNumber(_Tbl.Rows.Count, 0)

            'Next


            Consulta_sql = "Delete " & _Nombre_Tbl_Paso_Informe & " Where Es_Agrupador = 1"
            _Sql.Ej_consulta_IDU(Consulta_sql)

            Consulta_sql = "Select Distinct Codigo_Nodo_Madre From " & _Nombre_Tbl_Paso_Informe & vbCrLf &
                           "Where Es_Agrupador = 0 And Codigo_Nodo_Madre <> 0"
            Dim _Tbl_Informe As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

            Fm_Hijo.ProgressBarX1.Visible = True
            Fm_Hijo.ProgressBarX1.Maximum = _Tbl_Informe.Rows.Count
            Fm_Hijo.ProgressBarX1.Value = 0


            Dim _Dias_Existencia_Habiles As Integer = 0
            Dim _Dias_Existencia_Sabados As Integer = 0
            Dim _Dias_Existencia_Domingos As Integer = 0

            For Each _Row As DataRow In _Tbl_Informe.Rows '_Row As DataGridViewRow In Grilla.Rows

                Application.DoEvents()

                Dim _Codigo_Nodo_Madre = _Row.Item("Codigo_Nodo_Madre")

                Consulta_sql = "SELECT KOPR FROM MAEPR WHERE KOPR In" & Space(1) &
                               "(Select Codigo From " & _Global_BaseBk & "Zw_Prod_Asociacion" & Space(1) &
                               "Where Para_filtro = 1 And Codigo_Nodo = " & _Codigo_Nodo_Madre & ")"
                Dim _Tbl_Reemplazo As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

                _Filtro_Productos = Generar_Filtro_IN(_Tbl_Reemplazo, "", "KOPR", False, False, "'")

                Consulta_sql = "Delete " & _Nombre_Tbl_Paso_Informe & " Where Es_Agrupador = 0 And Codigo In " & _Filtro_Productos
                _Sql.Ej_consulta_IDU(Consulta_sql)

                Consulta_sql = "Insert Into " & _Nombre_Tbl_Paso_Informe & Space(1) &
                               "(Codigo,Es_Agrupador,Codigo_Nodo_Madre,Descripcion,UD1,UD2,Rtu,ClasificacionLibre," &
                               "Rubro,Marca,Zona,SuperFamilia,Familia,SubFamilia,Bloqueapr,Oculto)" & vbCrLf &
                               "SELECT " & vbCrLf &
                               "KOPR,1,'" & _Codigo_Nodo_Madre & "',NOKOPR,UD01PR,UD02PR,RLUD,CLALIBPR,RUPR,MRPR,ZONAPR,FMPR,PFPR,HFPR,BLOQUEAPR,ATPR" & vbCrLf &
                               "FROM MAEPR Mp WHERE" & vbCrLf &
                               "KOPR IN " & _Filtro_Productos & vbCrLf & vbCrLf &
                                "Insert Into " & _Nombre_Tbl_Paso_Informe & Space(1) &
                               "(Codigo,Es_Agrupador,Codigo_Nodo_Madre,Descripcion,UD1,UD2,Rtu,ClasificacionLibre," &
                               "Rubro,Marca,Zona,SuperFamilia,Familia,SubFamilia,Bloqueapr,Oculto)" & vbCrLf &
                               "SELECT " & vbCrLf &
                               "KOPR,0,'" & _Codigo_Nodo_Madre & "',NOKOPR,UD01PR,UD02PR,RLUD,CLALIBPR,RUPR,MRPR,ZONAPR,FMPR,PFPR,HFPR,BLOQUEAPR,ATPR" & vbCrLf &
                               "FROM MAEPR Mp WHERE" & vbCrLf &
                               "KOPR IN " & _Filtro_Productos
                _Sql.Ej_consulta_IDU(Consulta_sql)

                Dim _SqlQuery = String.Empty
                Dim _Codigo = String.Empty

                'For Each _Row_Reemplazo As DataRow In _Tbl_Reemplazo.Rows

                '_Codigo = _Row_Reemplazo.Item("KOPR")


                'Dim _Filtro_Bodega = Generar_Filtro_IN(_TblBodCompra, "Chk", "Codigo", False, True, "'")
                '_Filtro_Bodega = "And Empresa+Sucursal+Bodega In " & _Filtro_Bodega


                'Consulta_sql = "Select Distinct Codigo_Nodo_Madre,Fecha_Stock," & vbCrLf & _
                '               "Sum(StockUd1) as StockUd1," & vbCrLf & _
                '               "Sum(Cast(Dia_Habil As Int)) As Dia_Habil," & vbCrLf & _
                '               "Sum(Cast(Dia_Sabado As Int)) As Dia_Sabado," & vbCrLf & _
                '               "Sum(Cast(Dia_Domingo As Int)) As Dia_Domingo" & vbCrLf & _
                '               "Into #Paso" & vbCrLf & _
                '               "From " & _Global_BaseBk & "Zw_Prod_Stock_History" & vbCrLf & _
                '               "Where 1 > 0" & Space(1) & _
                '               _Filtro_Bodega & Space(1) & _
                '               "And Codigo_Nodo_Madre = '" & _Codigo_Nodo_Madre & "'  And Hubo_Stock = 1" & vbCrLf & vbCrLf & _
                '               "Group by Codigo_Nodo_Madre,Fecha_Stock,Dia_Habil,Dia_Sabado,Dia_Domingo" & vbCrLf & _
                '               "Select 'Stock' As Estado,Sum(Dia_Habil) As Dia_Habil,Sum(Dia_Sabado) As Dia_Sabado,Sum(Dia_Domingo) As Dia_Domingo" & vbCrLf & _
                '               "From #Paso" & vbCrLf & _
                '               "--Where StockUd1 > 0" & vbCrLf & vbCrLf & _
                '               "Group by Codigo_Nodo_Madre" & vbCrLf & _
                '               "Drop table #Paso"

                'Dim _Row_Historia As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)


                'If Not (_Row_Historia Is Nothing) Then

                'Dim _H = _Row_Historia.Item("Dia_Habil")
                'Dim _S = _Row_Historia.Item("Dia_Sabado")
                'Dim _D = _Row_Historia.Item("Dia_Domingo")

                'If _H > _Dias_Existencia_Habiles Then _Dias_Existencia_Habiles += _Row_Historia.Item("Dia_Habil")
                'If _S > _Dias_Existencia_Sabados Then _Dias_Existencia_Sabados += _Row_Historia.Item("Dia_Sabado")
                'If _D > _Dias_Existencia_Domingos Then _Dias_Existencia_Domingos += _Row_Historia.Item("Dia_Domingo")

                'End If

                'Next


                'Consulta_sql = "Update " & _Nombre_Tbl_Paso_Informe & vbCrLf & _
                '               "Set" & vbCrLf & _
                '               "Dias_Existencia_Habiles = " & _Dias_Existencia_Habiles & "," & _
                '               "Dias_Existencia_Sabados = " & _Dias_Existencia_Sabados & "," & _
                '               "Dias_Existencia_Domingos = " & _Dias_Existencia_Domingos & vbCrLf & _
                '               "Where Codigo_Nodo_Madre = '" & _Codigo_Nodo_Madre & "' And Es_Agrupador = 1"
                '_Sql.Ej_consulta_IDU(Consulta_sql)

                Fm_Hijo.ProgressBarX1.Value += 1
                Fm_Hijo.ProgressBarX1.Text = "Procesando " & FormatNumber(Fm_Hijo.ProgressBarX1.Value, 0) & " de " &
                                     FormatNumber(_Tbl_Informe.Rows.Count, 0)

            Next


            Consulta_sql = "Update " & _Nombre_Tbl_Paso_Informe & Space(1) &
                          "Set Descripcion_Madre = Isnull((Select Descripcion From " & _Global_BaseBk & "Zw_TblArbol_Asociaciones" & Space(1) &
                          "Where Codigo_Nodo = Codigo_Nodo_Madre),'')"
            _Sql.Ej_consulta_IDU(Consulta_sql)

            Consulta_sql = "Update " & _Nombre_Tbl_Paso_Informe & " Set IdGRC = IsNull((Select Top 1 IDMAEDDO From MAEDDO" & vbCrLf &
                                  "Where KOPRCT = Codigo And TIDO = 'GRC' Order By FEEMLI Desc),0)" & vbCrLf &
                                  "Update  " & _Nombre_Tbl_Paso_Informe & " Set IdOCC = IsNull((Select Top 1 IDMAEDDO From MAEDDO" & vbCrLf &
                                  "Where KOPRCT = Codigo And TIDO = 'OCC' And ESLIDO = '' Order By FEEMLI Desc),0)" & vbCrLf &
                                  "Update " & _Nombre_Tbl_Paso_Informe & " Set IdGDD = IsNull((Select Top 1 IDMAEDDO From MAEDDO" & vbCrLf &
                                  "Where KOPRCT = Codigo And TIDO = 'GDD' And ESLIDO = '' Order By FEEMLI Desc),0)" & vbCrLf &
                                  "Update " & _Nombre_Tbl_Paso_Informe & " Set Fecha_Ult_Venta = IsNull((Select Top 1 FEEMLI From MAEDDO Where KOPRCT = Codigo And TIDO In" & vbCrLf &
                                  "('BLV','BLX','BSV','ESC','FCV','FDB','FDV','FDX','FDZ','FEE'," &
                                  "'FEV','FVL','FVT','FVX','FVZ','NCE','NCV','NCX','NCZ','NEV','RIN')" & vbCrLf &
                                  "Order By FEEMLI Desc),'19000101')" & vbCrLf &
                                  "Where Es_Agrupador = 1"
            _Sql.Ej_consulta_IDU(Consulta_sql)

            ' Consulta_sql = "Delete " & _Nombre_Tbl_Paso_Informe & " Where Es_Agrupador = 0"
            ' _Sql.Ej_consulta_IDU(Consulta_sql)

            Chk_Traer_Productos_De_Reemplazo.Checked = True
            _Proceso_Automatico_Ejecutado = True


            Chk_Mostrar_Solo_a_Comprar_Cant_Mayor_Cero.Checked = False '_Proceso_Automatico_Ejecutado
            Chk_Sumar_Rotacion_Hermanos.Checked = True
            Chk_Restar_Stok_Bodega.Checked = True

            'Chk_Trabajando_Con_Proyeccion.Checked = True
            'Chk_Trabajando_Con_Proyeccion.Visible = _Proceso_Automatico_Ejecutado

            Sb_Refrescar_Grilla_Principal(Fm_Hijo.Grilla, True, True)
            MessageBoxEx.Show(Me, "Proceso generado correctamente", "Asociación automática",
                          MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            Chk_Trabajando_Con_Proyeccion.Checked = False
            MessageBoxEx.Show(Me, ex.Message)
        Finally
            Fm_Hijo.ProgressBarX1.Value = 0
            Me.Enabled = True
            Fm_Hijo.ProgressBarX1.Visible = False
        End Try

        Me.Refresh()

    End Sub

    Sub Sb_Actualizar_Rotacion_Agrupado_Por_Reemplazos()

        Try

            Fm_Hijo.ProgressBarX1.Visible = True
            Fm_Hijo.ProgressBarX1.Maximum = Fm_Hijo.Grilla.Rows.Count

            'Dim _Sql_Query = String.Empty
            Dim _Filtro_Productos = String.Empty

            Chk_Mostrar_Solo_Stock_Critico.Checked = False

            Sb_Refrescar_Grilla_Principal(Fm_Hijo.Grilla, True, True)
            Me.Enabled = False


            Consulta_sql = "Update " & _Nombre_Tbl_Paso_Informe & Space(1) &
                           "Set CodigoGenerico = Codigo, Es_Agrupador = 1, Comprar = 1" &
                           vbCrLf &
                           vbCrLf &
                           "--Delete " & _Nombre_Tbl_Paso_Informe & " Where Es_Agrupador = 0"
            _Sql.Ej_consulta_IDU(Consulta_sql)

            For Each _Row As DataGridViewRow In Fm_Hijo.Grilla.Rows
                Application.DoEvents()

                'Sb_Actualizar_Rotacion_Productos_Agrupadores(_Row)
                Dim _Codigo As String = _Row.Cells("Codigo").Value

                Consulta_sql = "SELECT KOPR FROM MAEPR WHERE KOPR = '" & _Codigo & "'" & vbCrLf & vbCrLf &
                               "UNION" & vbCrLf &
                               "SELECT KOPR FROM TABREMP WHERE KOPRREM = '" & _Codigo & "' AND KOPR <> '" & _Codigo & "' "

                Dim _Tbl_Reemplazo As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)
                _Filtro_Productos = Generar_Filtro_IN(_Tbl_Reemplazo, "", "KOPR", False, False, "'")

                Consulta_sql = "Insert Into " & _Nombre_Tbl_Paso_Informe & Space(1) &
                               "(Codigo,CodigoGenerico,Descripcion,UD1,UD2,Rtu,ClasificacionLibre," &
                               "Rubro,Marca,Zona,SuperFamilia,Familia,SubFamilia,Bloqueapr,Oculto)" & vbCrLf &
                               "SELECT " & vbCrLf &
                               "KOPR,'" & _Codigo & "',NOKOPR,UD01PR,UD02PR,RLUD,CLALIBPR,RUPR,MRPR,ZONAPR,FMPR,PFPR,HFPR,BLOQUEAPR,ATPR" & vbCrLf &
                               "FROM MAEPR Mp WHERE" & vbCrLf &
                               "KOPR IN " & _Filtro_Productos
                _Sql.Ej_consulta_IDU(Consulta_sql)

                Fm_Hijo.ProgressBarX1.Value += 1
                Fm_Hijo.ProgressBarX1.Text = "Procesados " & FormatNumber(Fm_Hijo.ProgressBarX1.Value, 0) & " de " &
                                     FormatNumber(Fm_Hijo.Grilla.Rows.Count, 0)

            Next

            Chk_Traer_Productos_De_Reemplazo.Checked = True

            _Proceso_Automatico_Ejecutado = True
            Chk_Traer_Productos_De_Reemplazo.Checked = True
            Chk_Mostrar_Solo_a_Comprar_Cant_Mayor_Cero.Checked = False '_Proceso_Automatico_Ejecutado
            Chk_Sumar_Rotacion_Hermanos.Checked = True
            Chk_Restar_Stok_Bodega.Checked = True

            Chk_Trabajando_Con_Proyeccion.Checked = True
            Chk_Trabajando_Con_Proyeccion.Visible = _Proceso_Automatico_Ejecutado



            Sb_Refrescar_Grilla_Principal(Fm_Hijo.Grilla, True, True)

            MessageBoxEx.Show(Me, "Proceso generado correctamente", "Asociación automática",
                          MessageBoxButtons.OK, MessageBoxIcon.Information)

            Rb_Calculo_Cantidad.Enabled = False

        Catch ex As Exception
            Chk_Trabajando_Con_Proyeccion.Checked = False
            MessageBoxEx.Show(Me, ex.Message)
        Finally
            Fm_Hijo.ProgressBarX1.Value = 0
            Me.Enabled = True
            Fm_Hijo.ProgressBarX1.Visible = False
        End Try

        Me.Refresh()

    End Sub

    Private Sub Btn_Actualizar_Rotacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Actualizar_Rotacion.Click
        ShowContextMenu(Menu_Contextual_Rotacion)
    End Sub

    Private Sub Mnu_Btn_Mant_codigos_alternativos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Mnu_Btn_Mant_codigos_alternativos.Click

        Dim _Fila As DataGridViewRow = Fm_Hijo.Grilla.Rows(Fm_Hijo.Grilla.CurrentRow.Index)

        Dim _Codigo As String = _Fila.Cells("Codigo").Value

        If Fx_Tiene_Permiso(Me, "Prod020") Then

            Dim _Tbl_Producto_Seleccionado As DataTable

            Dim CodigoPr_Sel = Trim(Fm_Hijo.Grilla.Rows(Fm_Hijo.Grilla.CurrentRow.Index).Cells("Codigo").Value)

            Consulta_sql = "Select * From MAEPR Where KOPR = '" & CodigoPr_Sel & "'"
            _Tbl_Producto_Seleccionado = _Sql.Fx_Get_Tablas(Consulta_sql)

            If Not String.IsNullOrEmpty(Trim(_Codigo)) Then

                Dim Fm_A As New Frm_CodAlternativo_Ver
                Fm_A.TxtCodigo.Text = _Codigo
                Fm_A.Txtdescripcion.Text = _Tbl_Producto_Seleccionado.Rows(0).Item("NOKOPR")
                Fm_A.TxtRTU.Text = _Tbl_Producto_Seleccionado.Rows(0).Item("RLUD")
                Fm_A.ShowDialog(Me)
                Fm_A.Dispose()

                If Not (_RowProveedor Is Nothing) Then

                    Dim _RowTabcodal As DataRow

                    Consulta_sql = "Select Top 1 * From TABCODAL" & vbCrLf &
                                   "Where KOPR = '" & _Codigo & "' And KOEN = '" & _RowProveedor.Item("KOEN") & "'"
                    _RowTabcodal = _Sql.Fx_Get_DataRow(Consulta_sql)

                    If Not (_RowTabcodal Is Nothing) Then
                        Consulta_sql = "Update " & _Nombre_Tbl_Paso_Informe & " Set CodAlternativo = '" & Trim(_RowTabcodal.Item("KOPRAL")) & "'" & vbCrLf &
                                        "Where Codigo = '" & _Codigo & "' And Es_Agrupador = " & CInt(Chk_Trabajando_Con_Proyeccion.Checked) * -1
                        _Sql.Ej_consulta_IDU(Consulta_sql)

                        _Fila.Cells("Informacion_Fila").Value = String.Empty
                        _Fila.Cells("CodAlternativo").Value = Trim(_RowTabcodal.Item("KOPRAL"))

                        Call Grilla_CellEnter(Fm_Hijo.Grilla, Nothing)
                    End If

                End If

            End If

        End If

    End Sub

    Private Sub Btn_Infor_Rotacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Infor_Rotacion.Click

        Dim _Fila As DataGridViewRow = Fm_Hijo.Grilla.Rows(Fm_Hijo.Grilla.CurrentRow.Index)

        Dim _Codigo As String = _Fila.Cells("Codigo").Value
        Dim _Descripcion As String = _Fila.Cells("Descripcion").Value

        _Clas_Asistente_Compras.Pro_Rdb_Agrupar_x_Asociados = Rdb_Agrupar_x_Asociados.Checked

        'Dim _Ud As Integer

        'If Rdb_Ud1_Compra.Checked Then
        '    _Ud = 1
        'ElseIf Rdb_Ud2_Compra.Checked Then
        '    _Ud = 2
        'End If

        _Clas_Asistente_Compras.Sb_Info_Calculo_Rotacion(Me, _Codigo, _Descripcion, _Ud)

    End Sub

    Private Sub Btn_Actualizar_Rotacion_Vta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Actualizar_Rotacion_Vta.Click
        Sb_Refrescar_Grilla_Principal(Fm_Hijo.Grilla, True, True)
    End Sub

    Private Sub Btn_Actualizar_Informe_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Actualizar_Informe.Click
        Sb_Refrescar_Grilla_Principal(Fm_Hijo.Grilla, False, False)
        If Not String.IsNullOrEmpty(Trim(Fm_Hijo.Txt_Codigo.Text)) Then Sb_Buscar_X_Codigo()
        If Not String.IsNullOrEmpty(Trim(Fm_Hijo.Txt_Descripcion.Text)) Then Sb_Buscar_X_Descripcion()
    End Sub

    Sub Sb_Buscar_X_Codigo()
        Dim _Fl As String
        Select Case Fm_Hijo.Cmb_Filtro_Codigo.SelectedValue
            Case "C" : _Fl = "%{0}%" : Case "E" : _Fl = "{0}%" : Case "T" : _Fl = "%{0}"
        End Select
        _Dv.RowFilter = String.Format("Codigo+Codigo_Nodo_Madre+CodAlternativo Like '" & _Fl & "'", Fm_Hijo.Txt_Codigo.Text.Trim)
        Sb_Grilla_Marcar(Fm_Hijo.Grilla, False)
    End Sub

    Private Sub Txt_Descripcion_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyValue = Keys.Enter Then
            Sb_Buscar_X_Descripcion()
        End If
    End Sub

    Sub Sb_Buscar_X_Descripcion()
        Dim _Lista_Descripcion = Split(Trim(Fm_Hijo.Txt_Descripcion.Text), " ", 3)

        Dim _A As String = String.Empty
        Dim _B As String = String.Empty
        Dim _C As String = String.Empty

        Select Case _Lista_Descripcion.Length
            Case 1
                _A = _Lista_Descripcion(0)
                _Dv.RowFilter = String.Format("Descripcion Like '%{0}%'", _A)
            Case 2
                _A = _Lista_Descripcion(0) : _B = _Lista_Descripcion(1)
                _Dv.RowFilter = String.Format("Descripcion Like '%{0}%' And Descripcion Like '%{1}%'", _A, _B)
            Case 3
                _A = _Lista_Descripcion(0) : _B = _Lista_Descripcion(1) : _C = _Lista_Descripcion(2)
                _Dv.RowFilter = String.Format("Descripcion Like '%{0}%' And Descripcion Like '%{1}%' And Descripcion Like '%{2}%'", _A, _B, _C)
        End Select
        Sb_Grilla_Marcar(Fm_Hijo.Grilla, False)
    End Sub

    Private Sub ButtonX1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim Fm As New Frm_EOQ
        Fm.ShowDialog(Me)
        Fm.Dispose()
    End Sub

    Private Sub Btn_Actualizar_datos_Informe_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Actualizar_datos_Informe.Click
        Sb_Refrescar_Grilla_Principal(Fm_Hijo.Grilla, False, True)
        If Not String.IsNullOrEmpty(Trim(Fm_Hijo.Txt_Codigo.Text)) Then Sb_Buscar_X_Codigo()
        If Not String.IsNullOrEmpty(Trim(Fm_Hijo.Txt_Descripcion.Text)) Then Sb_Buscar_X_Descripcion()
    End Sub

    Private Sub RibbonControl1_TabIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RibbonControl1.TabIndexChanged
        If RibbonControl1.TabIndex = 0 Then
            Fm_Hijo.Cmb_Tipo_de_compra.Visible = True
        Else
            Fm_Hijo.Cmb_Tipo_de_compra.Visible = False
        End If
    End Sub

    Private Sub Sb_Rb_Boton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If sender.Name = "Rb_Proveedores" Then
            Fm_Hijo.Lbl_Costos_Desde.Visible = True
            Fm_Hijo.Cmb_Documento_Compra.Visible = True
        Else
            Fm_Hijo.Lbl_Costos_Desde.Visible = False
            Fm_Hijo.Cmb_Documento_Compra.Visible = False
        End If
    End Sub

    Private Sub Chk_Rotacion_Con_Ent_Excluidas_CheckedChanged(ByVal sender As System.Object, ByVal e As DevComponents.DotNetBar.CheckBoxChangeEventArgs) Handles Chk_Rotacion_Con_Ent_Excluidas.CheckedChanged
        If Chk_Rotacion_Con_Ent_Excluidas.Checked Then
            If Not Fx_Tiene_Permiso(Me, "Comp0080") Then
                Chk_Rotacion_Con_Ent_Excluidas.Checked = False
            End If
        End If
    End Sub

    Dim _Tbl_Estudio_Ventas As DataTable
    Dim _Tbl_Detalle_Ult_Compras As DataTable

    Private Sub BackgroundWorker_Est_Venta_X_Producto_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker_Est_Venta_X_Producto.DoWork

        Dim points As New List(Of Double)()

        Dim Punto As Double = 0
        points.Add(Punto)

        Fm_Hijo.McsSemanales.DataPoints = points
        Fm_Hijo.MchMensuales.DataPoints = points

        Sb_Actualizar_Grilla_Mensual()

    End Sub

    Private Sub BackgroundWorker_Est_Venta_X_Producto_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles BackgroundWorker_Est_Venta_X_Producto.ProgressChanged

    End Sub

    Private Sub BackgroundWorker_Est_Venta_X_Producto_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker_Est_Venta_X_Producto.RunWorkerCompleted

        Fm_Hijo.MchMensuales.ChartType = eMicroChartType.Line
        LlenarPointMchar(Fm_Hijo.MchMensuales, _Tbl_Estudio_Ventas, 1)

        With Fm_Hijo.Grill_Mensual
            .DataSource = _Tbl_Estudio_Ventas
            .Columns("Periodo").HeaderText = "Periodo"
            .Columns("periodo").Width = 90
            .Columns("Ud1").Width = 60
            .Columns("Ud1").DefaultCellStyle.Format = "##,###0.##"
            .Columns("Ud1").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Ud2").Width = 60
            .Columns("Ud2").DefaultCellStyle.Format = "##,###0.##"
            .Columns("Ud2").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Mes").Visible = False
        End With

        With Fm_Hijo.Grilla_GRC

            .DataSource = _Tbl_Detalle_Ult_Compras

            OcultarEncabezadoGrilla(Fm_Hijo.Grilla_GRC)

            .Columns("Obs").HeaderText = "Periodo"
            .Columns("Obs").Width = 110
            .Columns("Obs").Visible = True

            .Columns("Tipo").HeaderText = "Tipo"
            .Columns("Tipo").Width = 30
            .Columns("Tipo").Visible = True

            .Columns("Numero").HeaderText = "Número"
            .Columns("Numero").Width = 80
            .Columns("Numero").Visible = True

            .Columns("EntFisica").HeaderText = "Ent. física"
            .Columns("EntFisica").Width = 200
            .Columns("EntFisica").Visible = True

            .Columns("Razon").HeaderText = "Proveedor"
            .Columns("Razon").Width = 300
            .Columns("Razon").Visible = True

            .Columns("Fecha").HeaderText = "Fecha"
            .Columns("Fecha").Width = 100
            .Columns("Fecha").DefaultCellStyle.Format = "dd/MM/yyyy"
            .Columns("Fecha").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Fecha").Visible = True

            .Columns("CantUd1").Width = 70
            .Columns("CantUd1").DefaultCellStyle.Format = "##,###.##"
            .Columns("CantUd1").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("CantUd1").Visible = True

            .Columns("Un1").Width = 50
            .Columns("Un1").Visible = True

            .Columns("Un2").Width = 50
            .Columns("Un2").Visible = True

            .Columns("CantUd2").Width = 70
            .Columns("CantUd2").DefaultCellStyle.Format = "##,###.##"
            .Columns("CantUd2").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("CantUd2").Visible = True

        End With

    End Sub

    Sub Sb_Actualizar_Grilla_Mensual()

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim _Fila As DataGridViewRow = Fm_Hijo.Grilla.Rows(Fm_Hijo.Grilla.CurrentRow.Index)

            Dim _Codigo = _Fila.Cells("Codigo").Value
            Dim _Descripcion = _Fila.Cells("Descripcion").Value

            If _Codigo = _Codigo_Seleccionado Then
                Return
            End If

            _Codigo_Seleccionado = _Codigo

            Sb_Actualizar_Grilla_Ventas_Compras_Mensuales()

            Call GrillaMensual_CellEnter(Nothing, Nothing)

            Dim _Filtro_Proveedor As String = String.Empty

            If Fm_Hijo.Chk_Ver_Doc_Solo_Proveedor.Checked Then
                If Not IsNothing(_RowProveedor) Then
                    _Filtro_Proveedor = vbCrLf & "And ENDO = '" & _RowProveedor.Item("KOEN") & "'"
                End If
            End If

            Sb_Actualizar_Grilla_Stock(Fm_Hijo.Grilla_Stock_Fisico, _Codigo, Fm_Hijo.Chk_Ocultar_BodSinStock.Checked)

            Dim _Br_Nt = "Neto"
            If Rdb_Valores_Brutos.Checked Then _Br_Nt = "Bruto"

            Dim _CostoUd1 As Double = NuloPorNro(_Fila.Cells("Costo_Ud1Lista_" & _Br_Nt).Value, 0)


            Dim _Top = 10

            Dim _Tbl_GRC As DataTable = Fx_Detalle_Ult_Doc_Compras("GRC", _Codigo, _Filtro_Proveedor, _Top, "")
            Fm_Hijo.Tab_GRC.Text = "Ult. 10 GRC"

            Dim _Tbl_OCC As DataTable = Fx_Detalle_Ult_Doc_Compras("OCC", _Codigo, _Filtro_Proveedor, _Top, "And ESLIDO = ''")
            Fm_Hijo.Tab_OCC.Text = "OCC Pendientes"
            If _Tbl_OCC.Rows.Count Then Fm_Hijo.Tab_OCC.Text += " (" & _Tbl_OCC.Rows.Count & ")"

            Dim _Tbl_FCC As DataTable = Fx_Detalle_Ult_Doc_Compras("FCC", _Codigo, _Filtro_Proveedor, _Top, "")
            Fm_Hijo.Tab_FCC.Text = "Ult. " & _Top & " FCC"

            Dim _Tbl_GDD As DataTable = Fx_Detalle_Ult_Doc_Compras("GDD", _Codigo, _Filtro_Proveedor, _Top, "And ESLIDO = ''")
            Fm_Hijo.Tab_GDD.Text = "GDD Pendientes"
            If _Tbl_GDD.Rows.Count Then Fm_Hijo.Tab_GDD.Text += " (" & _Tbl_GDD.Rows.Count & ")"

            Sb_Formato_Grilla_Detalle_Ult_Registros(Fm_Hijo.Grilla_GRC, _Tbl_GRC)
            Sb_Formato_Grilla_Detalle_Ult_Registros(Fm_Hijo.Grilla_OCC, _Tbl_OCC)
            Sb_Formato_Grilla_Detalle_Ult_Registros(Fm_Hijo.Grilla_FCC, _Tbl_FCC)
            Sb_Formato_Grilla_Detalle_Ult_Registros(Fm_Hijo.Grilla_GDD, _Tbl_GDD)

        Catch ex As Exception
        Finally
            Me.Cursor = Cursors.Default
        End Try

    End Sub

    Sub Sb_Actualizar_Grilla_Ventas_Compras_Mensuales()

        Dim _Fila As DataGridViewRow = Fm_Hijo.Grilla.Rows(Fm_Hijo.Grilla.CurrentRow.Index)

        Dim _Codigo = _Fila.Cells("Codigo").Value
        Dim _Descripcion = _Fila.Cells("Descripcion").Value

        Fm_Hijo.LabelX2.Text = "..."

        Dim _Filtro_Entidades_Excluidas As String = String.Empty

        If Not Chk_Rotacion_Con_Ent_Excluidas.Checked Then

            _Filtro_Entidades_Excluidas = "And Ltrim(Rtrim(ENDO))+Ltrim(Rtrim(SUENDO))" & vbCrLf &
                "NOT IN (SELECT Rtrim(LTrim(Codigo))+Rtrim(Ltrim(Sucursal)) From " & _Global_BaseBk & "Zw_TblInf_EntExcluidas" & vbCrLf &
                "Where Funcionario = @CodFuncionario And Excluida in ('V','A','T'))" & vbCrLf

        End If

        Fm_Hijo.Grill_Mensual.ColumnHeadersVisible = True
        Fm_Hijo.Grilla_Semanal.ColumnHeadersVisible = True

        If Chk_Traer_Productos_De_Reemplazo.Checked Then

            Consulta_sql = "Select Arbol.Codigo_Nodo,Arbol.Codigo_Madre From 
                                " & _Global_BaseBk & "Zw_Prod_Asociacion Prod
                                Inner Join " & _Global_BaseBk & "Zw_TblArbol_Asociaciones Arbol On Prod.Codigo_Nodo = Arbol.Codigo_Nodo
                                Where Arbol.Nodo_Raiz = " & _Nodo_Raiz_Asociados & " And Es_Seleccionable = 1 And Codigo = '" & _Codigo & "'"

            Dim _Tbl_Codigos_Madre As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

            Dim _Filtro_Codigos_Madre = Generar_Filtro_IN(_Tbl_Codigos_Madre, "", "Codigo_Nodo", False, False, "")

            If _Tbl_Codigos_Madre.Rows.Count = 0 Then
                _Filtro_Codigos_Madre = "('@@@')"
            End If

            Consulta_sql = "
                                Select Codigo 
                                Into #Paso
                                From " & _Global_BaseBk & "Zw_Prod_Asociacion 
                                Where Codigo_Nodo In " & _Filtro_Codigos_Madre & " And Para_filtro = 1

                                Insert Into #Paso (Codigo)
                                Select KOPR From MAEPR
                                Where KOPR = '" & _Codigo & "'

                                Select KOPR,'',NOKOPR,UD01PR,UD02PR,RLUD,CLALIBPR,RUPR,MRPR,ZONAPR,FMPR,PFPR,HFPR,BLOQUEAPR,ATPR
                                FROM MAEPR
                                Where KOPR In (Select Distinct Codigo From #Paso)

                                Drop Table #Paso"


        Else
            Consulta_sql = "Select Top 1 * From MAEPR Where KOPR = '" & _Codigo & "'"
        End If

        Dim _TblProductos As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        Dim _Filtro_Productos As String

        _Filtro_Productos = Generar_Filtro_IN(_TblProductos, "", "KOPR", False, False, "'")


        Dim F1 As Date = DateAdd(DateInterval.Year, -1, FechaDelServidor)
        F1 = Primerdiadelmes(F1)

        Dim _Fecha_Inicio As Date = F1
        Dim _Fecha_Fin As Date = ultimodiadelmes(FechaDelServidor())

        Dim _Filtro_Bodega As String
        Dim _TblBodegas As DataTable

        If Fm_Hijo.STab_Ventas.IsSelected Then
            Consulta_sql = My.Resources.Recursos_Asis_Compras.SQLQuery_Info_Estadistica_X_Producto
            _TblBodegas = _TblBodVenta
        End If

        If Fm_Hijo.STab_Compras.IsSelected Then
            Consulta_sql = My.Resources.Recursos_Asis_Compras.SQLQuery_Info_Estadistica_X_Producto_Compra
            _TblBodegas = _TblBodCompra
        End If

        If _Filtro_Bodegas_Todas Then
            _Filtro_Bodega = String.Empty
        Else
            _Filtro_Bodega = Generar_Filtro_IN(_TblBodegas, "Chk", "Codigo", False, True, "'")
            _Filtro_Bodega = "And EMPRESA+SULIDO+BOSULIDO In " & _Filtro_Bodega
            '_Filtro_Bodega = String.Empty
        End If

        Consulta_sql = Replace(Consulta_sql, "#Codigo#", _Filtro_Productos)
        Consulta_sql = Replace(Consulta_sql, "#Empresa#", ModEmpresa)
        Consulta_sql = Replace(Consulta_sql, "#Funcionario#", FUNCIONARIO)
        Consulta_sql = Replace(Consulta_sql, "#FechaInicio#", Format(_Fecha_Inicio, "yyyyMMdd"))
        Consulta_sql = Replace(Consulta_sql, "#FechaTermino#", Format(_Fecha_Fin, "yyyyMMdd"))
        Consulta_sql = Replace(Consulta_sql, "#Mes#", 1)
        Consulta_sql = Replace(Consulta_sql, "#Filtro_Entidades_Excluidas#", _Filtro_Entidades_Excluidas)
        Consulta_sql = Replace(Consulta_sql, "#Filtro_Bodega#", _Filtro_Bodega)
        Consulta_sql = Replace(Consulta_sql, "#_Global_BaseBk#", _Global_BaseBk)

        Dim _Filtro_Documentos As String

        If Chk_Incluir_Salidas_GDI_OT.Checked Then
            _Filtro_Documentos = "And (TIDO IN ('FCV', 'FDB', 'FDV', 'FDX', 'FDZ', 'FEV', 'FVL', 'FVT', 'FVX', 'FVZ','FEE', 'BLV','GDV','GDP','NCE', 'NCV', 'NCX', 'NCZ', 'NEV') Or " &
                                          "TIDO In ('GDI','GRI') And ARCHIRST = 'POTD')"
        Else
            _Filtro_Documentos = "And TIDO IN ('FCV', 'FDB', 'FDV', 'FDX', 'FDZ', 'FEV', 'FVL', 'FVT', 'FVX', 'FVZ','FEE', 'BLV','GDV','GDP','NCE', 'NCV', 'NCX', 'NCZ', 'NEV')"
        End If

        Consulta_sql = Replace(Consulta_sql, "#Filtro_Documentos#", _Filtro_Documentos)

        Dim _Ds As DataSet = _Sql.Fx_Get_DataSet(Consulta_sql)


        Sb_Formato_Generico_Grilla(Fm_Hijo.Grill_Mensual, 15, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, False, False, False)
        Sb_Formato_Generico_Grilla(Fm_Hijo.Grilla_Semanal, 13, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, False, False, False)


        _Ds.Relations.Add("Rel_Mes_x_Semana",
                     _Ds.Tables("Table").Columns("Periodo"),
                     _Ds.Tables("Table1").Columns("Periodo"), False)

        Fm_Hijo.MchMensuales.ChartType = eMicroChartType.Line

        Fm_Hijo.Grill_Mensual.DataSource = _Ds
        Fm_Hijo.Grill_Mensual.DataMember = "Table"

        Fm_Hijo.Grilla_Semanal.DataSource = _Ds
        Fm_Hijo.Grilla_Semanal.DataMember = "Table.Rel_Mes_x_Semana"

        OcultarEncabezadoGrilla(Fm_Hijo.Grill_Mensual)
        OcultarEncabezadoGrilla(Fm_Hijo.Grilla_Semanal)

        Dim _Tipo_entidad, _Tipo_Mov, _Ppm, _PpmTooltip As String

        If Fm_Hijo.STab_Ventas.IsSelected Then
            _Tipo_entidad = "clientes" : _Tipo_Mov = "ventas" : _Ppm = "PPV" : _PpmTooltip = "Precio promedio venta"
        Else
            _Tipo_entidad = "proveedores" : _Tipo_Mov = "compras" : _Ppm = "PPM" : _PpmTooltip = "Precio promedio compra"
        End If

        With Fm_Hijo.Grill_Mensual

            .Columns("Periodo2").HeaderText = "Periodo"
            .Columns("periodo2").Width = 50
            .Columns("periodo2").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("periodo2").Visible = True
            .Columns("Periodo2").SortMode = DataGridViewColumnSortMode.NotSortable

            .Columns("Ud" & _Ud).Width = 75
            .Columns("Ud" & _Ud).DefaultCellStyle.Format = "##,##0.##"
            .Columns("Ud" & _Ud).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Ud" & _Ud).Visible = True
            .Columns("Ud" & _Ud).SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Ud" & _Ud).ToolTipText = "Corresponde a las " & _Tipo_Mov & " realizadas a " & _Tipo_entidad & " en general"

            .Columns("ValorUnit").Width = 50
            .Columns("ValorUnit").HeaderText = _Ppm '"PPM"
            .Columns("ValorUnit").DefaultCellStyle.Format = "##,##0"
            .Columns("ValorUnit").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("ValorUnit").Visible = Rdb_Valores_Netos.Checked
            .Columns("ValorUnit").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("ValorUnit").ToolTipText = "Corresponde a las " & _Tipo_Mov & " realizadas a " & _Tipo_entidad & " en general"

            .Columns("ValorUnitB").Width = 50
            .Columns("ValorUnitB").HeaderText = _Ppm '"PPM"
            .Columns("ValorUnitB").DefaultCellStyle.Format = "##,##0"
            .Columns("ValorUnitB").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("ValorUnitB").Visible = Rdb_Valores_Brutos.Checked
            .Columns("ValorUnitB").SortMode = DataGridViewColumnSortMode.NotSortable

            'End If

            'If Fm_Hijo.STab_Ventas.IsSelected Then

            .Columns("Ud" & _Ud & "_EE").Width = 50
            .Columns("Ud" & _Ud & "_EE").HeaderText = "Ud" & _Ud & " EE"
            .Columns("Ud" & _Ud & "_EE").DefaultCellStyle.Format = "##,##0.##"
            .Columns("Ud" & _Ud & "_EE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Ud" & _Ud & "_EE").Visible = True
            .Columns("Ud" & _Ud & "_EE").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Ud" & _Ud & "_EE").ToolTipText = "Corresponde a las " & _Tipo_Mov & " realizadas a las entidades excluidas"

            .Columns("ValorUnit_EE").Width = 50
            .Columns("ValorUnit_EE").HeaderText = _Ppm & " EE" '"PPM EE"
            .Columns("ValorUnit_EE").DefaultCellStyle.Format = "##,##0"
            .Columns("ValorUnit_EE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("ValorUnit_EE").Visible = (Rdb_Valores_Netos.Checked And Fm_Hijo.STab_Ventas.IsSelected)
            .Columns("ValorUnit_EE").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("ValorUnit_EE").ToolTipText = "Corresponde a las " & _Tipo_Mov & " realizadas a las entidades excluidas"

            'End If

            'If Fm_Hijo.STab_Ventas.IsSelected Then

            .Columns("ValorUnit_EE").Width = 50
            .Columns("ValorUnit_EE").HeaderText = _Ppm '"PPM"
            .Columns("ValorUnit_EE").DefaultCellStyle.Format = "##,##0"
            .Columns("ValorUnit_EE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("ValorUnit_EE").Visible = Rdb_Valores_Netos.Checked
            .Columns("ValorUnit_EE").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("ValorUnit_EE").ToolTipText = "Corresponde a las " & _Tipo_Mov & " realizadas a clientes en general"

            .Columns("ValorUnitB_EE").Width = 50
            .Columns("ValorUnitB_EE").HeaderText = _Ppm & "EE" '"PMEE"
            .Columns("ValorUnitB_EE").DefaultCellStyle.Format = "##,##0"
            .Columns("ValorUnitB_EE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("ValorUnitB_EE").Visible = Rdb_Valores_Brutos.Checked
            .Columns("ValorUnitB_EE").SortMode = DataGridViewColumnSortMode.NotSortable

            'End If

        End With

        Dim _Color_Cero As Color = Color.LightGray

        If Global_Thema = Enum_Themas.Oscuro Then
            _Color_Cero = Color.FromArgb(60, 60, 60)
        End If

        For Each _FilaM As DataGridViewRow In Fm_Hijo.Grill_Mensual.Rows
            If _FilaM.Cells("Ud1").Value = 0 Then _FilaM.Cells("Ud1").Style.ForeColor = _Color_Cero
            If _FilaM.Cells("ValorUnit").Value = 0 Then _FilaM.Cells("ValorUnit").Style.ForeColor = _Color_Cero
            If Fm_Hijo.STab_Ventas.IsSelected Then
                If _FilaM.Cells("Ud1_EE").Value = 0 Then _FilaM.Cells("Ud1_EE").Style.ForeColor = _Color_Cero
                If _FilaM.Cells("ValorUnit_EE").Value = 0 Then _FilaM.Cells("ValorUnit_EE").Style.ForeColor = _Color_Cero
            End If
        Next

        Dim Campo As String = "Ud" & Ud
        Dim points As New List(Of Double)()

        Dim _Punto As Double = 0
        points.Add(_Punto)

        Fm_Hijo.McsSemanales.DataPoints = points
        Fm_Hijo.MchMensuales.DataPoints = points

        For Each _FilaP As DataGridViewRow In Fm_Hijo.Grill_Mensual.Rows
            _Punto = _FilaP.Cells(Campo).Value
            points.Add(_Punto)
        Next

        Fm_Hijo.MchMensuales.DataPoints = points

        With Fm_Hijo.Grilla_Semanal

            .Columns("Semana").Width = 60
            .Columns("Semana").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Semana").Visible = True

            .Columns("Ud1").Width = 60
            .Columns("Ud1").DefaultCellStyle.Format = "##,###0.00"
            .Columns("Ud1").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Ud1").Visible = True

            .Columns("Ud2").Width = 60
            .Columns("Ud2").DefaultCellStyle.Format = "##,###0.00"
            .Columns("Ud2").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Ud2").Visible = True

        End With

        Fm_Hijo.Grill_Mensual.Refresh()
        Fm_Hijo.Grilla_Semanal.Refresh()

        Fm_Hijo.MchMensuales.Refresh()
        Fm_Hijo.McsSemanales.Refresh()

    End Sub
    Function Fx_Detalle_Ult_Doc_Compras(_Tido As String,
                                        _Codigo As String,
                                        _Filtro_Proveedor As String,
                                        _Top As Integer,
                                        _Condicion_Adicional As String) As DataTable

        Dim _Fila As DataGridViewRow = Fm_Hijo.Grilla.Rows(Fm_Hijo.Grilla.CurrentRow.Index)
        Dim _Br_Nt = "Neto"
        If Rdb_Valores_Brutos.Checked Then _Br_Nt = "Bruto"

        _Br_Nt = "Neto"

        Dim _CostoUd1 = De_Num_a_Tx_01(NuloPorNro(_Fila.Cells("Costo_Ud1Lista_" & _Br_Nt).Value, 0), False, 5)

        Consulta_sql = "Select Top " & _Top & " IDMAEDDO,IDMAEEDO,TIDO,NUDO,ENDO,SUENDO,NOKOEN,FEEMLI,BOSULIDO,UDTRPR,UD0" & Ud & "PR As UDTRANS,UD01PR,UD02PR,
                        RLUDPR,CAPRCO1,CAPRCO2,MOPPPR,
                        Round(PODTGLLI/100,4) As PODTGLLI,
                        PPPRNERE1+POTENCIA As PPPRNEUd1,
                        Case When " & _CostoUd1 & " = 0 then 0 Else Round((" & _CostoUd1 & "-(PPPRNERE1+POTENCIA))/" & _CostoUd1 & ",2) End As Porc_Dif_Precios_Neto,
                        Case When " & _CostoUd1 & " = 0 then 0 Else Round((" & _CostoUd1 & "-((VABRLI/CAPRCO1)+POTENCIA))/" & _CostoUd1 & ",2) End As Porc_Dif_Precios_Bruto,
                        PPPRNERE2+(POTENCIA*RLUDPR) As PPPRNEUd2,
                        (VABRLI/CAPRCO1)+POTENCIA As VABRUTOUd1,
                        Round((VABRLI/CAPRCO2)+(POTENCIA*RLUDPR),0) As VABRUTOUd2,
                        PPPRNERE1,
                        PPPRNERE2,
                        VANELI,
                        VAIMLI,
                        VAIVLI,
                        VABRLI 
                       From MAEDDO Ddo
                       Left Join MAEEN On KOEN = ENDO And SUENDO = SUEN
                       Where TIDO = '" & _Tido & "' And KOPRCT = '" & _Codigo & "'" & _Filtro_Proveedor & vbCrLf &
                       _Condicion_Adicional & vbCrLf &
                       " Order By FEEMLI Desc"

        Consulta_sql = "Select Top " & _Top & " IDMAEDDO,IDMAEEDO,TIDO,NUDO,ENDO,SUENDO,NOKOEN,FEEMLI,BOSULIDO,UDTRPR,UD0" & Ud & "PR As UDTRANS,UD01PR,UD02PR,
                        RLUDPR,CAPRCO1,CAPRCO2,MOPPPR,
                        Round(PODTGLLI/100,4) As PODTGLLI,
                        PPPRNERE1+POTENCIA As PPPRNEUd1,
                        Case When " & _CostoUd1 & " = 0 then 0 Else Round((" & _CostoUd1 & "-(PPPRNERE1))/PPPRNERE1,2) End As Porc_Dif_Precios_Neto,
                        Case When " & _CostoUd1 & " = 0 then 0 Else Round((" & _CostoUd1 & "-(VABRLI/CAPRCO1))/(VABRLI/CAPRCO1),2) End As Porc_Dif_Precios_Bruto,
                        PPPRNERE2+(POTENCIA*RLUDPR) As PPPRNEUd2,
                        (VABRLI/CAPRCO1) As VABRUTOUd1,
                        Round((VABRLI/CAPRCO2)+(POTENCIA*RLUDPR),0) As VABRUTOUd2,
                        PPPRNERE1,
                        PPPRNERE2,
                        VANELI,
                        VAIMLI,
                        VAIVLI,
                        VABRLI 
                        From MAEDDO Ddo
                        Left Join MAEEN On KOEN = ENDO And SUENDO = SUEN
                        Where TIDO = '" & _Tido & "' And KOPRCT = '" & _Codigo & "'" & _Filtro_Proveedor & vbCrLf &
                        _Condicion_Adicional & vbCrLf &
                        " Order By FEEMLI Desc"

        Dim _Tbl As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        Return _Tbl

    End Function

    Private Sub STab_Ventas_Compras_Click(sender As Object, e As EventArgs)
        Sb_Actualizar_Grilla_Ventas_Compras_Mensuales()
    End Sub

    Private Sub GrillaMensual_CellEnter(sender As Object, e As DataGridViewCellEventArgs)

        Try

            Dim points As New List(Of Double)()

            Dim _Punto As Double = 0
            points.Add(_Punto)

            Fm_Hijo.McsSemanales.DataPoints = points
            Fm_Hijo.McsSemanales.ChartType = eMicroChartType.Line

            Dim Campo As String = "Ud" & Ud
            Dim _Semana = 0

            For Each _Fila As DataGridViewRow In Fm_Hijo.Grilla_Semanal.Rows
                _Punto = _Fila.Cells(Campo).Value
                _Semana += 1
                _Fila.Cells("Semana").Value = _Semana
                points.Add(_Punto)
            Next

            Fm_Hijo.McsSemanales.DataPoints = points

        Catch ex As Exception

        End Try

    End Sub

    Public Sub Sb_Actualizar_Grilla_Stock(Grilla As DataGridView, _Codigo As String, _Ocultar_BodSinStock As Boolean)

        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
        Dim _Filtro_Productos As String

        Sb_Formato_Generico_Grilla(Grilla, 15, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Both, False, False, False)

        _Filtro_Productos = "('" & _Codigo & "')"

        Consulta_sql = "Select Distinct EMPRESA+KOSU+KOBO As Cod,* From TABBO" & vbCrLf &
                       "Where EMPRESA+KOSU+KOBO" & vbCrLf &
                       "In (" & vbCrLf &
                       "Select SUBSTRING(CodPermiso, 3, 10)" & vbCrLf &
                       "From " & _Global_BaseBk & "ZW_PermisosVsUsuarios" & vbCrLf &
                       "Where CodUsuario = '" & FUNCIONARIO & "'" & Space(1) &
                       "And CodPermiso In (Select CodPermiso From " & _Global_BaseBk & "ZW_Permisos Where CodFamilia = 'Bodega'))" & vbCrLf &
                       "Or (EMPRESA = '" & ModEmpresa & "' And KOSU = '" & ModSucursal & "' And KOBO = '" & ModBodega & "')"

        Consulta_sql = "Select Distinct EMPRESA+KOSU+KOBO As Cod,* From TABBO Where EMPRESA = '" & ModEmpresa & "'"

        Dim _Tbl_Bodegas As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        Dim _Filtro As String = Generar_Filtro_IN(_Tbl_Bodegas, "", "Cod", False, False, "'")

        _Filtro = "And Empresa+Sucursal+Bodega In " & _Filtro

        Dim _Orden_Bod = "ORDEN_BOD_" & ModEmpresa.Trim & ModSucursal.Trim

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Prod_Stock Where Codigo = '" & _Codigo & "' And StfiBodExt" & Ud & " <> 0"
        Dim _TblStExt As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        Consulta_sql = My.Resources.Recursos_Alerta_Stock.Stock_productos_por_emp_suc_bod
        Consulta_sql = Replace(Consulta_sql, "#Empresa#", ModEmpresa)
        Consulta_sql = Replace(Consulta_sql, "#Codigo#", _Codigo)
        Consulta_sql = Replace(Consulta_sql, "#Codigos#", _Filtro_Productos)
        Consulta_sql = Replace(Consulta_sql, "#Ud#", Ud)
        Consulta_sql = Replace(Consulta_sql, "#Filtro#", _Filtro)
        Consulta_sql = Replace(Consulta_sql, "#Tabla#", _Orden_Bod)
        Consulta_sql = Replace(Consulta_sql, "#Global_BaseBk#", _Global_BaseBk)

        Dim _Update_Conficion_Adicional = String.Empty

        For Each _FlExt As DataRow In _TblStExt.Rows

            Dim _EmpExt As String = _FlExt.Item("Empresa")
            Dim _SucExt As String = _FlExt.Item("Sucursal")
            Dim _BodExt As String = _FlExt.Item("Bodega")

            Dim _StfiBodExt As Double = _FlExt.Item("StfiBodExt" & Ud)

            _Update_Conficion_Adicional += "Update #Paso Set ST_FISICO = ST_FISICO + " & De_Num_a_Tx_01(_StfiBodExt, False, 5) & vbCrLf &
                                           "Where Empresa = '" & _EmpExt & "' And Sucursal = '" & _SucExt & "' And Bodega = '" & _BodExt & "'" & vbCrLf

        Next

        Consulta_sql = Replace(Consulta_sql, "--#Update_Conficion_Adicional#", _Update_Conficion_Adicional)

        Dim _Tbl As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        With Grilla

            .DataSource = _Tbl

            OcultarEncabezadoGrilla(Grilla, True)

            Dim _DisplayIndex = 0

            .Columns("SUC_BOD").Visible = True
            .Columns("SUC_BOD").HeaderText = "Suc-Bod"
            .Columns("SUC_BOD").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("SUC_BOD").Width = 60
            .Columns("SUC_BOD").Frozen = True
            .Columns("SUC_BOD").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            '.Columns("NOKOBO").Visible = True
            '.Columns("NOKOBO").HeaderText = "Bodega"
            '.Columns("NOKOBO").Width = 240

            .Columns("ST_FISICO").Visible = True
            .Columns("ST_FISICO").HeaderText = "Físico"
            .Columns("ST_FISICO").Width = 60
            .Columns("ST_FISICO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("ST_FISICO").DefaultCellStyle.Format = "##,##0.##"
            .Columns("ST_FISICO").ToolTipText = "Stock Ud" & Ud
            .Columns("ST_FISICO").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("ST_PEDIDO").Visible = True
            .Columns("ST_PEDIDO").HeaderText = "Pedido"
            .Columns("ST_PEDIDO").Width = 60
            .Columns("ST_PEDIDO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("ST_PEDIDO").DefaultCellStyle.Format = "##,##0.##"
            .Columns("ST_PEDIDO").ToolTipText = "Stock Pedido OCC"
            .Columns("ST_PEDIDO").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("ST_COMPROMETIDO").Visible = True
            .Columns("ST_COMPROMETIDO").HeaderText = "Comp.RD"
            .Columns("ST_COMPROMETIDO").Width = 60
            .Columns("ST_COMPROMETIDO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("ST_COMPROMETIDO").DefaultCellStyle.Format = "##,##0.##"
            .Columns("ST_COMPROMETIDO").ToolTipText = "Stock comprometido Ud" & Ud & " (NVV)"
            .Columns("ST_COMPROMETIDO").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("ST_COMPROMETIDO_BK").Visible = True
            .Columns("ST_COMPROMETIDO_BK").HeaderText = "Comp.BK"
            .Columns("ST_COMPROMETIDO_BK").Width = 60
            .Columns("ST_COMPROMETIDO_BK").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("ST_COMPROMETIDO_BK").DefaultCellStyle.Format = "##,##0.##"
            .Columns("ST_COMPROMETIDO_BK").ToolTipText = "Stock comprometido Ud" & Ud & " (NVV - Pendientes de permisos remotos)"
            .Columns("ST_COMPROMETIDO_BK").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("ST_DEVENGADO").Visible = True
            .Columns("ST_DEVENGADO").HeaderText = "Ven.N/Entr."
            .Columns("ST_DEVENGADO").Width = 60
            .Columns("ST_DEVENGADO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("ST_DEVENGADO").DefaultCellStyle.Format = "##,##0.##"
            .Columns("ST_DEVENGADO").ToolTipText = "Ventas no despachadas (Devengados)"
            .Columns("ST_DEVENGADO").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            Dim _NomCampo As String
            Dim _ToolCampo As String

            'If String.IsNullOrEmpty(_Tido) Then
            '_NomCampo = "Teorico"
            '_ToolCampo = "Stock teórico = (Stock físico - Stock devengado- Stock comprometido)"
            'Else
            _NomCampo = "Disponible"
            _ToolCampo = "Stock disponible teóricamente Ud" & Ud & " (según configuración de calculo de stock)"
            'End If

            .Columns("ST_DISPONIBLE").Visible = True
            .Columns("ST_DISPONIBLE").HeaderText = _NomCampo
            .Columns("ST_DISPONIBLE").Width = 60
            .Columns("ST_DISPONIBLE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("ST_DISPONIBLE").DefaultCellStyle.Format = "##,##0.##"
            .Columns("ST_DISPONIBLE").ToolTipText = _ToolCampo
            .Columns("ST_DISPONIBLE").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

        End With

        For Each _Fila As DataGridViewRow In Grilla.Rows

            Dim _Suc_Bod = Trim(_Fila.Cells("SUC_BOD").Value)
            Dim _St_Fisico = _Fila.Cells("ST_FISICO").Value
            Dim _St_Devengado = _Fila.Cells("ST_DEVENGADO").Value
            Dim _St_Pedido = _Fila.Cells("ST_PEDIDO").Value
            Dim _St_Comprometido = _Fila.Cells("ST_COMPROMETIDO").Value
            Dim _St_Comprometido_Bk = _Fila.Cells("ST_COMPROMETIDO_BK").Value


            Dim _St_Disponible = _Fila.Cells("ST_DISPONIBLE").Value

            If _Ocultar_BodSinStock Then
                _Fila.Visible = CBool(_St_Fisico + _St_Devengado + _St_Pedido + _St_Comprometido + _St_Comprometido_Bk)
            End If

            Dim _Sucursal As String = _Fila.Cells("Sucursal").Value
            Dim _Bodega As String = _Fila.Cells("Bodega").Value

            If Not String.IsNullOrEmpty("FCV") Then
                _St_Disponible = Fx_Stock_Disponible("FCV", ModEmpresa, _Sucursal, _Bodega, _Codigo, _Ud, "STFI" & _Ud)
                If _St_Disponible < 0 Then _St_Disponible = 0
                _Fila.Cells("ST_DISPONIBLE").Value = _St_Disponible
            End If

            If String.IsNullOrEmpty(_Suc_Bod) Then
                If Global_Thema = Enum_Themas.Oscuro Then
                    _Fila.DefaultCellStyle.BackColor = Color.Black
                    _Fila.DefaultCellStyle.ForeColor = Color.Gold
                Else
                    _Fila.DefaultCellStyle.BackColor = Color.Gold
                End If
            Else
                If Global_Thema = Enum_Themas.Oscuro Then
                    _Fila.DefaultCellStyle.BackColor = Color.Black
                Else
                    _Fila.DefaultCellStyle.BackColor = Color.White
                End If
            End If

            For Each Columna As DataGridViewColumn In Grilla.Columns
                Dim _Columna As String = Columna.Name
                If _Columna.Contains("ST_") Then

                    Dim _Valor As Double = _Fila.Cells(_Columna).Value

                    Dim _Color_Cero As Color = Color.LightGray
                    Dim _Color_Positivo As Color = Azul
                    Dim _Color_Negativo As Color = Rojo

                    If Global_Thema = Enum_Themas.Oscuro Then
                        _Color_Cero = Color.FromArgb(60, 60, 60)
                        _Color_Positivo = Verde
                    End If

                    If _Valor = 0 Then
                        _Fila.Cells(_Columna).Style.ForeColor = _Color_Cero
                    ElseIf _Valor < 0 Then
                        _Fila.Cells(_Columna).Style.ForeColor = Rojo
                    ElseIf _Valor > 0 Then
                        _Fila.Cells(_Columna).Style.ForeColor = _Color_Positivo
                    End If

                End If
            Next

        Next

    End Sub

    Public Function GetFilledTable(ByVal query As String, _Cn As SqlConnection) As DataTable

        If _Cn.State = ConnectionState.Open Then
            ' Cerrar conexion
            _Cn.Close()
        End If

        _Cn.ConnectionString = Cadena_ConexionSQL_Server
        _Cn.Open()

        Dim _Comando As SqlClient.SqlCommand

        _Comando = New SqlCommand(Consulta_sql, _Cn)
        Dim _Sql_DReader As SqlDataReader = _Comando.ExecuteReader(CommandBehavior.KeyInfo Or CommandBehavior.CloseConnection)


        'Dim reader As OleDbDataReader = Command.ExecuteReader(CommandBehavior.KeyInfo Or CommandBehavior.CloseConnection)
        Dim schema As DataTable = _Sql_DReader.GetSchemaTable()
        Dim columns(schema.Rows.Count - 1) As DataColumn
        Dim column As DataColumn

        'Build the schema for the table that will contain the data.
        For i As Integer = 0 To columns.GetUpperBound(0) Step 1
            column = New DataColumn
            column.AllowDBNull = CBool(schema.Rows(i)("AllowDBNull"))
            column.AutoIncrement = CBool(schema.Rows(i)("IsAutoIncrement"))
            column.ColumnName = CStr(schema.Rows(i)("ColumnName"))
            column.DataType = CType(schema.Rows(i)("DataType"), Type)

            If column.DataType Is GetType(String) Then
                column.MaxLength = CInt(schema.Rows(i)("ColumnSize"))
            End If

            column.ReadOnly = CBool(schema.Rows(i)("IsReadOnly"))
            column.Unique = CBool(schema.Rows(i)("IsUnique"))
            columns(i) = column
        Next i

        Dim data As New DataTable
        Dim row As DataRow

        data.Columns.AddRange(columns)

        'Get the data itself.
        While _Sql_DReader.Read()
            row = data.NewRow()

            For i As Integer = 0 To columns.GetUpperBound(0)
                row(i) = _Sql_DReader(i)
            Next i

            data.Rows.Add(row)
        End While

        _Sql_DReader.Close()

        Return data
    End Function

    Private Sub Btn_Reabastecer_Bodega_01_Click(sender As Object, e As EventArgs) Handles Btn_Reabastecer_Bodega_01.Click

        Dim _Bod_Solicita As String
        Dim _Tbl_Productos As DataTable

        If _TblBodCompra.Rows.Count = 1 Then

            _Bod_Solicita = _TblBodCompra.Rows(0).Item("Codigo")

            Dim _Emp_Recep = Mid(_Bod_Solicita, 1, 2)
            Dim _Suc_Recep = Mid(_Bod_Solicita, 3, 3)
            Dim _Bod_Recep = Mid(_Bod_Solicita, 6, 3)

            Dim _Sql_Filtro_Condicion_Extra = "And KOBO <> '" & _Bod_Recep & "'"

            Dim _Filtrar As New Clas_Filtros_Random(Me)

            MessageBoxEx.Show(Me, "Debe indicar la(s) bodega(s) desde donde quiere solicitar los productos",
                              "Selecionar bodega", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Dim _TblPaso As String = "Tbl_PasoSolBod" & FUNCIONARIO.Trim

            _Sql.Sb_Eliminar_Tabla_De_Paso(_TblPaso)

            Consulta_sql = "CREATE TABLE [dbo].[" & _TblPaso & "](
	                        [Id]					[int] IDENTITY(1,1) NOT NULL,
	                        [Empresa]				[varchar](2) NOT NULL DEFAULT (''),
	                        [Sucursal]				[varchar](3) NOT NULL DEFAULT (''),
	                        [Bodega]				[varchar](3) NOT NULL DEFAULT (''),
	                        [Codigo]				[char](13) NOT NULL DEFAULT (''),
	                        [Descripcion]			[varchar](50) NOT NULL DEFAULT (''),
	                        [Codigo_Nodo]			[int] NOT NULL DEFAULT (0),
                            [Costo]	                [float] NOT NULL DEFAULT (0),
	                        [Stock_Fisico_Madre]	[float] NOT NULL DEFAULT (0),
	                        [Stock_Fisico_Prod]		[float] NOT NULL DEFAULT (0),
	                        [Stock_Disponible]		[float] NOT NULL DEFAULT (0),
	                        [Stock_CriticoUd1_Rd]	[float] NOT NULL DEFAULT (0),
	                        [CantComprar]			[float] NOT NULL DEFAULT (0),
	                        [TStock]				[float] NOT NULL DEFAULT (0),
	                        [RotDiariaUd1]			[float] NOT NULL DEFAULT (0),
	                        [RotMensualUd1]			[float] NOT NULL DEFAULT (0),
	                        [Dias]					[int] NOT NULL DEFAULT (0),
	                        [Solicitar]				[float] NOT NULL DEFAULT (0),
	                        [Pedir]					[float] NOT NULL DEFAULT (0),
	                        [Pedir_Hnos]			[float] NOT NULL DEFAULT (0),
                            [Observacion]			[varchar](50) NOT NULL DEFAULT (''),
                            [NVI]       			[varchar](10) NOT NULL DEFAULT (''),
                            [Idmaeedo]     			[int] NOT NULL DEFAULT (0),
                            [Ubicacion]    			[varchar](20) NOT NULL DEFAULT (''),
                            [NVI_Pendientes]     	[varchar](1000) NOT NULL DEFAULT (''),
                            [Fecha_Ult_Venta]       [Datetime],
                            ) ON [PRIMARY]"

            _Sql.Ej_consulta_IDU(Consulta_sql)

            Consulta_sql = "Select Chk,Codigo,Descripcion From " & _Global_BaseBk & "Zw_Tmp_Filtros_Busqueda" & vbCrLf &
                           "Where Funcionario = '" & FUNCIONARIO & "' And Informe = 'Compras_Asistente'" & Space(1) &
                           "And Filtro = 'Bodegas_Reabastecen' And NombreEquipo = '" & _NombreEquipo & "' And Modalidad = '" & _Modalidad_Estudio & "'"
            Dim _TblBodReabastecen As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)


            If _Filtrar.Fx_Filtrar(_TblBodReabastecen,
                                   Clas_Filtros_Random.Enum_Tabla_Fl._Bodegas, _Sql_Filtro_Condicion_Extra, Nothing, False, False) Then

                _TblBodReabastecen = _Filtrar.Pro_Tbl_Filtro

                _Sql.Sb_Actualizar_Filtro_Tmp(_TblBodReabastecen, "Compras_Asistente", "Bodegas_Reabastecen", _Modalidad_Estudio)

                Dim Fm_Espera As New Frm_Form_Esperar
                Fm_Espera.Pro_Texto = "Haciendo analisis en las bodegas. Por favor espere..."
                Fm_Espera.BarraCircular.IsRunning = True
                Fm_Espera.Show(Me)

                Try
                    Me.Enabled = False

                    For Each _FlBodegas As DataRow In _TblBodReabastecen.Rows

                        Dim _Bod_Codigo = _FlBodegas.Item("Codigo")
                        Dim _Bod_Descripcion = _FlBodegas.Item("Descripcion")

                        Dim _Emp = Trim(Mid(_Bod_Codigo, 1, 2))
                        Dim _Suc = Trim(Mid(_Bod_Codigo, 3, 3))
                        Dim _Bod = Trim(Mid(_Bod_Codigo, 6, 3))

                        Fx_Productos_A_Solicitar_Otras_Bodegas(_Emp, _Suc, _Bod, _TblPaso)

                    Next

                    Consulta_sql = "Select * Into #Paso1 From " & _TblPaso & " Z1 Where Solicitar = CantComprar And (Select Count(*) From " & _TblPaso & " Z2 Where Z1.Codigo = Z2.Codigo) > 1 Order By Codigo_Nodo
                                    Select * Into #Paso2 From " & _TblPaso & " Z1 Where Solicitar < CantComprar And (Select Count(*) From " & _TblPaso & " Z2 Where Z1.Codigo = Z2.Codigo) > 1 And Codigo In (Select Codigo From #Paso1)
                                
                                    Delete " & _TblPaso & " Where Id In (Select Id From #Paso2)
                                    Drop Table #Paso1"

                    _Sql.Ej_consulta_IDU(Consulta_sql)

                    Consulta_sql = "Select Distinct Empresa,Sucursal,Bodega From " & _TblPaso & " Z1 Where (Select Count(*) From " & _TblPaso & " Z2 Where Z1.Codigo = Z2.Codigo) > 1"
                    Dim _TblProdAmbasBodegas As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

                    If CBool(_TblProdAmbasBodegas.Rows.Count) Then

                        'MessageBoxEx.Show(Me, "Existen productos que estan con la misma disponibilidad en ")

                        For Each _FlBodegas As DataRow In _TblProdAmbasBodegas.Rows

                            Dim _Emp = _FlBodegas.Item("Empresa")
                            Dim _Suc = _FlBodegas.Item("Sucursal")
                            Dim _Bod = _FlBodegas.Item("Bodega")

                            Consulta_sql = "Delete " & _TblPaso & "
                                            Where Id In (Select Id From " & _TblPaso & " Z1  Where Empresa = '" & _Emp & "' And Sucursal = '" & _Suc & "' And Bodega = '" & _Bod & "' And (Select Count(*) From " & _TblPaso & " Z2 Where Z1.Codigo = Z2.Codigo) > 1) "
                            _Sql.Ej_consulta_IDU(Consulta_sql)
                        Next

                    End If

                    Fm_Espera.Close()

                    Consulta_sql = "Select * From " & _TblPaso
                    _Tbl_Productos = _Sql.Fx_Get_Tablas(Consulta_sql)

                    If Not CBool(_Tbl_Productos.Rows.Count) Then
                        MessageBoxEx.Show(Me, "No se encontraron productos en otras bodegas", "Reabastecimiento entre bodegas",
                                      MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Return
                    End If

                    If MessageBoxEx.Show(Me, "Total productos encontrados: " & FormatNumber(_Tbl_Productos.Rows.Count, 0) & vbCrLf & vbCrLf &
                                         "¿Desea consolidad el stock de los productos?", "Consolidar stock",
                                     vbYesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                        Dim _Filtro_Codigos_Madre = Generar_Filtro_IN(_Tbl_Productos, "", "Codigo_Nodo", False, False, "")
                        Dim _Filtro_Pro As String = Generar_Filtro_IN(_Tbl_Productos, "", "Codigo", False, False, "'")

                        Consulta_sql = "
                                Select Codigo 
                                Into #Paso
                                From " & _Global_BaseBk & "Zw_Prod_Asociacion 
                                Where Codigo_Nodo In " & _Filtro_Codigos_Madre & " And Para_filtro = 1

                                Insert Into #Paso (Codigo)
                                Select KOPR From MAEPR
                                Where KOPR In " & _Filtro_Pro & "

                                Select KOPR As Codigo,'',NOKOPR,UD01PR,UD02PR,RLUD,CLALIBPR,RUPR,MRPR,ZONAPR,FMPR,PFPR,HFPR,BLOQUEAPR,ATPR
                                FROM MAEPR
                                Where KOPR In (Select Distinct Codigo From #Paso)

                                Drop Table #Paso"

                        Dim _TblProductos_Con_Reemplazo As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

                        Dim _Filtro_Productos As String = Generar_Filtro_IN(_TblProductos_Con_Reemplazo, "", "Codigo", False, False, "'")

                        Dim Fm2 As New Frm_Consolidacion_Stock_PP(_Filtro_Productos)
                        Fm2.Pro_Ejecutar_Automaticamente = True
                        Fm2.ShowDialog(Me)
                        Fm2.Dispose()

                    End If

                    Fm_Espera = New Frm_Form_Esperar
                    Fm_Espera.Pro_Texto = "Haciendo analisis en las bodegas. Por favor espere..."
                    Fm_Espera.BarraCircular.IsRunning = True
                    Fm_Espera.Show(Me)

                    Dim _Tbl_Productos_Copy As DataTable = _Tbl_Productos.Copy()

                    ' Hay que ir incrementando e ir poniendo los productos hermanos para pedir, se deben pedir los que tengan stock suficiente...

                    For Each _Fila As DataRow In _Tbl_Productos_Copy.Rows

                        Dim _Emp_Reab As String = _Fila.Item("Empresa")
                        Dim _Suc_Reab As String = _Fila.Item("Sucursal")
                        Dim _Bod_Reab As String = _Fila.Item("Bodega")
                        Dim _Codigo As String = _Fila.Item("Codigo")
                        Dim _Codigo_Nodo As Integer = _Fila.Item("Codigo_Nodo")
                        Dim _Stock_Fisico_Madre As Double = _Fila.Item("Stock_Fisico_Madre")
                        Dim _Stock_Fisico_Prod As Double = _Fila.Item("Stock_Fisico_Prod")
                        Dim _Stock_Disponible As Double = Fx_Stock_Disponible("FCV", ModEmpresa, _Suc_Reab, _Bod_Reab, _Codigo, _Ud, "STFI" & Ud)

                        Dim _Solicitar As Double = _Fila.Item("Solicitar")
                        Dim _Pedir As Double = _Fila.Item("Pedir")
                        Dim _Pedir_Hnos As Double = _Fila.Item("Pedir_Hnos")

                        Dim _Cant_Solicitada As Double = 0
                        Dim _Saldo As Double = _Pedir_Hnos

                        Consulta_sql = "Update " & _TblPaso & " Set Stock_Disponible = " & De_Num_a_Tx_01(_Stock_Disponible, False, 5) & " 
                                        Where Empresa = '" & _Emp_Reab & "' And Sucursal = '" & _Suc_Reab & "' And Bodega = '" & _Bod_Reab & "' And Codigo = '" & _Codigo & "'"
                        _Sql.Ej_consulta_IDU(Consulta_sql)

                        If CBool(_Pedir_Hnos) Then

                            Consulta_sql = "Select Mst.*,Mp.NOKOPR,Isnull(Mpe.PM,1) As PM 
                                                From MAEST Mst
                                                Left Join MAEPR Mp On Mp.KOPR = Mst.KOPR
                                                Left Join MAEPREM Mpe On Mpe.EMPRESA = '" & _Emp_Reab & "' And Mpe.KOPR = Mp.KOPR
                                            Where Mst.EMPRESA = '" & _Emp_Reab & "' And KOSU = '" & _Suc_Reab & "' And KOBO = '" & _Bod_Reab & "' 
                                            And Mst.KOPR In (Select Codigo From " & _Global_BaseBk & "Zw_Prod_Asociacion " &
                                            "Where Codigo_Nodo = " & _Codigo_Nodo & " And Para_filtro = 1) And Mst.KOPR <> '" & _Codigo & "'
                                        Order By Mst.STFI1 Desc"
                            Dim _Tbl_Hnos As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

                            For Each _Fila_H As DataRow In _Tbl_Hnos.Rows

                                Dim _Kopr As String = _Fila_H.Item("KOPR")
                                Dim _Nokopr As String = _Fila_H.Item("NOKOPR").ToString.Trim
                                Dim _Stfi As Double = _Fila_H.Item("STFI" & Ud)
                                _Stock_Disponible = Fx_Stock_Disponible("FCV", ModEmpresa, _Suc_Reab, _Bod_Reab, _Kopr, _Ud, "STFI" & Ud)
                                Dim _Costo As Double = _Fila_H.Item("PM")
                                Dim _Salir = False

                                'If _Kopr = "0928341001JPN" Then
                                '    Dim _as = "d"
                                'End If

                                If CBool(_Stock_Disponible) Then

                                    If _Stock_Disponible >= _Saldo Then
                                        _Pedir = _Saldo
                                        _Salir = True
                                    Else
                                        _Pedir = _Stock_Disponible
                                        _Saldo -= _Pedir
                                    End If

                                    Dim _Observacion As String = "Se pide por el producto (" & _Codigo.ToString.Trim & ")"

                                    Consulta_sql = "Insert Into " & _TblPaso & " (Empresa,Sucursal,Bodega,Codigo,Descripcion,Codigo_Nodo," &
                                                "Stock_Fisico_Madre,Stock_Fisico_Prod,Stock_Disponible,Solicitar,Pedir,Pedir_Hnos,Costo,Observacion,NVI,Idmaeedo,Ubicacion) Values " &
                                                "('" & _Emp_Reab & "','" & _Suc_Reab & "','" & _Bod_Reab & "','" & _Kopr & "','" & _Nokopr &
                                                "'," & _Codigo_Nodo &
                                                "," & De_Num_a_Tx_01(_Stock_Fisico_Madre, False, 5) &
                                                "," & De_Num_a_Tx_01(_Stfi, False, 5) &
                                                "," & De_Num_a_Tx_01(_Stock_Disponible, False, 5) &
                                                "," & De_Num_a_Tx_01(_Solicitar, False, 5) &
                                                "," & De_Num_a_Tx_01(_Pedir, False, 5) &
                                                "," & De_Num_a_Tx_01(_Pedir_Hnos, False, 5) &
                                                "," & De_Num_a_Tx_01(_Costo, False, 5) & ",'" & _Observacion & "','',0,'')"
                                    _Sql.Ej_consulta_IDU(Consulta_sql)

                                    If _Salir Then
                                        Exit For
                                    End If

                                End If

                            Next

                        End If

                    Next

                    Fm_Espera.Close()

                    Consulta_sql = "Select * From " & _TblPaso
                    _Tbl_Productos = _Sql.Fx_Get_Tablas(Consulta_sql)

                    For Each _Fl As DataRow In _Tbl_Productos.Rows

                        Dim _Id As Integer = _Fl.Item("Id")
                        Dim _Empresa As String = _Fl.Item("Empresa")
                        Dim _Sucursal As String = _Fl.Item("Sucursal")
                        Dim _Bodega As String = _Fl.Item("Bodega")
                        Dim _Codigo As String = _Fl.Item("Codigo")
                        Dim _Pedir As Double = _Fl.Item("Pedir")
                        Dim _Obs As String = String.Empty

                        If CBool(_Pedir) Then

                            Consulta_sql = "Select * From MAEDDO 
                                        Where TIDO = 'NVI' And EMPRESA = '" & _Empresa & "' And SULIDO = '" & _Sucursal &
                                    "' And BOSULIDO = '" & _Bodega & "' And KOPRCT = '" & _Codigo & "' And ESLIDO = ''"
                            Dim _TblNviPdtes As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

                            Dim _C = 0

                            For Each _FlNvi As DataRow In _TblNviPdtes.Rows

                                _C += 1

                                Dim _Idmaeedo As Integer = _FlNvi.Item("IDMAEEDO")
                                Dim _Cantidad As Double = _FlNvi.Item("CAPRCO" & Ud) - (_FlNvi.Item("CAPRAD" & Ud) + _FlNvi.Item("CAPREX" & Ud))

                                Dim _Reg As Boolean = CBool(_Sql.Fx_Cuenta_Registros("MAEEDO", "IDMAEEDO = " & _Idmaeedo & " And BODESTI = '" & _Bod_Recep & "'"))

                                If _Reg Then

                                    _Obs = _FlNvi.Item("NUDO") & " - Cant: " & FormatNumber(_Cantidad, 0)

                                End If

                                If _C <> _TblNviPdtes.Rows.Count Then
                                    _Obs += ", "
                                End If

                            Next

                            Consulta_sql = "Update " & _TblPaso & " Set NVI_Pendientes = '" & _Obs & "' Where Id = " & _Id
                            _Sql.Ej_consulta_IDU(Consulta_sql)

                        End If

                    Next

                    Consulta_sql = "Update " & _TblPaso & " Set Fecha_Ult_Venta = Isnull((Select Top 1 Fecha_Ult_Venta From " & _Nombre_Tbl_Paso_Informe & " Z2 Where Z1.Codigo_Nodo = Z2.Codigo_Nodo),'19000101')
                                    From " & _TblPaso & " Z1"
                    _Sql.Ej_consulta_IDU(Consulta_sql)

                    Consulta_sql = "Select * From " & _TblPaso
                    _Tbl_Productos = _Sql.Fx_Get_Tablas(Consulta_sql)

                    Dim _Reg2 = _Sql.Fx_Cuenta_Registros(_TblPaso, "NVI_Pendientes <> ''")

                    If CBool(_Reg2) Then

                        Dim Chk_Seguir_No_Quitar As New Command
                        Chk_Seguir_No_Quitar.Checked = False
                        Chk_Seguir_No_Quitar.Name = "Chk_Seguir_No_Quitar"
                        Chk_Seguir_No_Quitar.Text = "Seguir con la gestión, no quitar productos que ya tienen NVI"

                        Dim Chk_Seguir_Quitar As New Command
                        Chk_Seguir_Quitar.Checked = False
                        Chk_Seguir_Quitar.Name = "Chk_Seguir_Quitar"
                        Chk_Seguir_Quitar.Text = "Seguir con la gestión y quitar productos que ya tienen NVI"

                        Dim _Opciones1() As Command = {Chk_Seguir_No_Quitar, Chk_Seguir_Quitar}

                        Dim _Info1 As New TaskDialogInfo("Validación del sistema",
                          eTaskDialogIcon.Shield,
                          "Algunos productos ya tienen NVI",
                          "Existen algunos productos que ya tienen solicitud hacia otras bodegas (NVI)" & Environment.NewLine &
                          "Marque su opción",
                          eTaskDialogButton.Ok + eTaskDialogButton.Cancel _
                          , eTaskDialogBackgroundColor.Red, _Opciones1, Nothing, Nothing, Nothing, Nothing)

                        Dim _Resultado1 As eTaskDialogResult = TaskDialog.Show(_Info1)

                        If _Resultado1 = eTaskDialogResult.Ok Then

                            If Chk_Seguir_No_Quitar.Checked Or Chk_Seguir_Quitar.Checked Then

                                If Chk_Seguir_Quitar.Checked Then

                                    Consulta_sql = "Update " & _TblPaso & " Set Pedir = 0 Where NVI_Pendientes <> ''"
                                    _Sql.Ej_consulta_IDU(Consulta_sql)

                                End If

                                If MessageBoxEx.Show(Me, "¿Desea exportar el resultado a Excel?", "Exportar a excel",
                                                 MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                                    Consulta_sql = "Select * From " & _TblPaso
                                    _Tbl_Productos = _Sql.Fx_Get_Tablas(Consulta_sql)

                                    ExportarTabla_JetExcel_Tabla(_Tbl_Productos, Me, "Prod. con NVI")

                                End If

                            Else

                                MessageBoxEx.Show(Me, "Debe seleccionar una opción", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                _Sql.Sb_Eliminar_Tabla_De_Paso(_TblPaso)
                                Return

                            End If

                        Else

                            _Sql.Sb_Eliminar_Tabla_De_Paso(_TblPaso)
                            Return

                        End If

                    End If

                    _Reg2 = _Sql.Fx_Cuenta_Registros(_TblPaso, "Pedir > 0")

                    If _Reg2 = 0 Then

                        Consulta_sql = "Select Ddo.IDMAEDDO,Edo.TIDO,Edo.NUDO,Codigo,Codigo_Nodo,Descripcion,CAPRCO" & Ud & " As Cantidad
                                        From MAEDDO Ddo
                                            Inner Join MAEEDO Edo On Edo.IDMAEEDO = Ddo.IDMAEEDO
                                                Inner Join " & _TblPaso & " On Codigo = KOPRCT
                                        Where Edo.TIDO = 'NVI' And Edo.SUDO = '" & _Suc_Recep & "' AND Edo.BODESTI = '" & _Bod_Recep & "' 
                                          And Ddo.ESLIDO = '' And NVI_Pendientes <> ''"
                        _Tbl_Productos_Copy = _Sql.Fx_Get_Tablas(Consulta_sql)

                        Consulta_sql = String.Empty

                        For Each _Fila As DataRow In _Tbl_Productos_Copy.Rows

                            Dim _Codigo As String = _Fila.Item("Codigo")
                            Dim _Codigo_Nodo As String = _Fila.Item("Codigo_Nodo")
                            Dim _Cantidad As Double = _Fila.Item("Cantidad")

                            If _Codigo_Nodo = 0 Then

                                Consulta_sql = "Update " & _Nombre_Tbl_Paso_Informe & " Set CantComprar = CantComprar - " & De_Num_a_Tx_01(_Cantidad, False, 5) & vbCrLf &
                                           "Where Codigo = '" & _Codigo & "'"
                                _Sql.Ej_consulta_IDU(Consulta_sql)

                            Else

                                Consulta_sql = "Update " & _Nombre_Tbl_Paso_Informe & " Set CantComprar = CantComprar - " & De_Num_a_Tx_01(_Cantidad, False, 5) & vbCrLf &
                                               "Where Codigo_Nodo = '" & _Codigo_Nodo & "'"
                                _Sql.Ej_consulta_IDU(Consulta_sql)

                            End If

                        Next

                        MessageBoxEx.Show(Me, "No hay productos que pedir a otras bodegas", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)

                        Sb_Refrescar_Grilla_Principal(Fm_Hijo.Grilla, False, False)

                        Return

                    End If

                    Dim _Fecha_Emision As Date = FechaDelServidor()

                    Dim Chk_Crear_NVI As New Command
                    Chk_Crear_NVI.Checked = False
                    Chk_Crear_NVI.Name = "Chk_Crear_NVI"
                    Chk_Crear_NVI.Text = "Crear NVI (Generar documento de compromiso interno)"

                    Dim Chk_Exportar_Excel As New Command
                    Chk_Exportar_Excel.Checked = False
                    Chk_Exportar_Excel.Name = "Chk_Exportar_Excel"
                    Chk_Exportar_Excel.Text = "Exportar el listado a Excel (No generar NVI)"

                    Dim Chk_Exportar_Excel_Crear_NVI As New Command
                    Chk_Exportar_Excel_Crear_NVI.Checked = False
                    Chk_Exportar_Excel_Crear_NVI.Name = "Chk_Exportar_Excel_Crear_NVI"
                    Chk_Exportar_Excel_Crear_NVI.Text = "Crear NVI y Exportar listado a Excel"

                    Dim Chk_Quitar_Productos As New Command
                    Chk_Quitar_Productos.Checked = False
                    Chk_Quitar_Productos.Name = "Chk_Quitar_Productos"
                    Chk_Quitar_Productos.Text = "Quitar productos del tratamiento"

                    Dim _Opciones() As Command = {Chk_Crear_NVI, Chk_Exportar_Excel_Crear_NVI, Chk_Exportar_Excel, Chk_Quitar_Productos}

                    Dim _Info As New TaskDialogInfo("Validación del sistema",
                          eTaskDialogIcon.ShieldOk,
                          "Productos encontrados en otras bodegas",
                          "Existen varios productos que no es necesario comprarlos sino que se pueden pedir a otras bodegas" & Environment.NewLine &
                          "Marque su opción",
                          eTaskDialogButton.Ok + eTaskDialogButton.Cancel _
                          , eTaskDialogBackgroundColor.Red, _Opciones, Nothing, Nothing, Nothing, Nothing)

                    Dim _Resultado As eTaskDialogResult = TaskDialog.Show(_Info)

                    If _Resultado = eTaskDialogResult.Ok Then

                        Consulta_sql = "Update " & _TblPaso & " Set Ubicacion = (Select DATOSUBIC From TABBOPR Where EMPRESA = Empresa And KOSU = Sucursal And KOBO = Bodega And KOPR = Codigo)"
                        _Sql.Ej_consulta_IDU(Consulta_sql)

                        If Chk_Crear_NVI.Checked Or Chk_Exportar_Excel_Crear_NVI.Checked Then

                            For Each _FlBodegas As DataRow In _Filtrar.Pro_Tbl_Filtro.Rows

                                Dim _Bod_Codigo = _FlBodegas.Item("Codigo")
                                Dim _Bod_Descripcion = _FlBodegas.Item("Descripcion")

                                Dim _Emp = Trim(Mid(_Bod_Codigo, 1, 2))
                                Dim _Suc = Trim(Mid(_Bod_Codigo, 3, 3))
                                Dim _Bod = Trim(Mid(_Bod_Codigo, 6, 3))

                                Dim _Tbl_ProductosSol As DataTable
                                Dim _Seguir = True

                                Do While _Seguir

                                    Consulta_sql = "Select Top 20 * From " & _TblPaso & " 
                                                    Where NVI = '' And Empresa = '" & _Emp & "' And Sucursal = '" & _Suc & "' And Pedir > 0 Order By Ubicacion"
                                    _Tbl_ProductosSol = _Sql.Fx_Get_Tablas(Consulta_sql)

                                    _Seguir = CBool(_Tbl_ProductosSol.Rows.Count)

                                    If _Seguir Then

                                        Dim _Row_NVI As DataRow = Fx_Crear_NVI_Manual(_Tbl_ProductosSol, _Suc_Recep, _Bod_Recep, _Fecha_Emision, _Ud, _TblPaso)

                                        Dim _Ids As String = Generar_Filtro_IN(_Tbl_ProductosSol, "", "Id", True, False, "")

                                        If Not IsNothing(_Row_NVI) Then
                                            Consulta_sql = "Update " & _TblPaso & " Set NVI = '" & _Row_NVI.Item("NUDO").ToString.Trim & "',Idmaeedo = " & _Row_NVI.Item("IDMAEEDO") & " Where Id In " & _Ids
                                            _Sql.Ej_consulta_IDU(Consulta_sql)
                                        Else
                                            Consulta_sql = "Update " & _TblPaso & " Set NVI = 'XXXXX',Observacion = 'No se crea NVI, el usuario no la grabo' Where Id In " & _Ids
                                            _Sql.Ej_consulta_IDU(Consulta_sql)
                                        End If

                                        'End If

                                    End If

                                Loop

                            Next

                            Consulta_sql = String.Empty

                            Consulta_sql = "Select KOPRCT As Codigo,CAPRCO" & Ud & " As Cantidad,Codigo_Nodo
                                            From MAEDDO 
                                            Left Join " & _TblPaso & " On KOPRCT = Codigo
                                            Where IDMAEEDO In
                                            (Select Distinct Idmaeedo From " & _TblPaso & " Where Idmaeedo <> 0)"

                            Dim _Tbl_ProdNVI As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

                            Consulta_sql = String.Empty

                            For Each _Fila As DataRow In _Tbl_ProdNVI.Rows

                                Dim _Codigo As String = _Fila.Item("Codigo")
                                Dim _Codigo_Nodo As String = _Fila.Item("Codigo_Nodo")
                                Dim _Cantidad As Double = _Fila.Item("Cantidad")

                                If _Codigo_Nodo = 0 Then
                                    Consulta_sql += "Update " & _Nombre_Tbl_Paso_Informe & " Set CantComprar = CantComprar - " & De_Num_a_Tx_01(_Cantidad, False, 5) & vbCrLf &
                                                    "Where Codigo = '" & _Codigo & "'" & vbCrLf
                                Else
                                    Consulta_sql += "Update " & _Nombre_Tbl_Paso_Informe & " Set CantComprar = CantComprar - " & De_Num_a_Tx_01(_Cantidad, False, 5) & vbCrLf &
                                                    "Where Codigo_Nodo = '" & _Codigo_Nodo & "'" & vbCrLf
                                End If

                            Next

                            If Not String.IsNullOrEmpty(Consulta_sql) Then

                                If _Sql.Ej_consulta_IDU(Consulta_sql) Then

                                    MessageBoxEx.Show(Me, "Los productos que fueron solicitados con NVI se quitaron las cantidades de esta solicitud" & vbCrLf & vbCrLf &
                                                  _Tbl_ProdNVI.Rows.Count & " registro(s) encontrado(s) en la(s) bodega(s) ",
                                                 "Restar stock de compra", MessageBoxButtons.OK, MessageBoxIcon.Information)

                                    Sb_Refrescar_Grilla_Principal(Fm_Hijo.Grilla, False, False)

                                End If

                            End If

                        End If

                        If Chk_Quitar_Productos.Checked Then

                            If MessageBoxEx.Show(Me, "¿Esta seguro que querer quitar los productos encontrados del tratamiento?", "Quitar productos",
                                             MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                                For Each _Fila As DataRow In _Tbl_Productos_Copy.Rows

                                    Dim _Codigo As String = _Fila.Item("Codigo")
                                    Dim _Solicitar As Double = _Fila.Item("Solicitar")

                                    Consulta_sql += "Update " & _Nombre_Tbl_Paso_Informe & " Set CantComprar = CantComprar - " & De_Num_a_Tx_01(_Solicitar, False, 5) & vbCrLf &
                                                "Where Codigo = '" & _Codigo & "'" & vbCrLf


                                Next

                                If Not String.IsNullOrEmpty(Consulta_sql) Then

                                    If _Sql.Ej_consulta_IDU(Consulta_sql) Then

                                        MessageBoxEx.Show(Me, "Se quitaron las cantidades de los productos encontrados en esta solicitud" & vbCrLf & vbCrLf &
                                                      _Tbl_Productos.Rows.Count & " registro(s) encontrado(s) en la(s) bodega(s) ",
                                                     "Restar stock de compra", MessageBoxButtons.OK, MessageBoxIcon.Information)

                                        Sb_Refrescar_Grilla_Principal(Fm_Hijo.Grilla, False, False)

                                    End If

                                End If

                            End If

                        End If

                        If Chk_Exportar_Excel.Checked Or Chk_Exportar_Excel_Crear_NVI.Checked Or Chk_Quitar_Productos.Checked Then

                            If Chk_Exportar_Excel_Crear_NVI.Checked Then

                                Consulta_sql = "Select * From " & _TblPaso & " Where Idmaeedo <> 0 Order By NVI,Ubicacion"
                                _Tbl_Productos = _Sql.Fx_Get_Tablas(Consulta_sql)

                            Else

                                Consulta_sql = "Select * From " & _TblPaso
                                _Tbl_Productos = _Sql.Fx_Get_Tablas(Consulta_sql)

                            End If

                            ExportarTabla_JetExcel_Tabla(_Tbl_Productos, Me, "Prod. a reabastecer")

                        End If

                        _Sql.Sb_Eliminar_Tabla_De_Paso(_TblPaso)

                    End If

                Catch ex As Exception
                    MessageBoxEx.Show(Me, ex.Message, "Problema al generar el estudio", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Finally
                    Me.Enabled = True
                    Fm_Espera.Close()
                End Try

            End If

        Else
            MessageBoxEx.Show(Me, "¡Debe tener seleccionada solo una bodega para el estudio de bodegas!", "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Sub

    Function Fx_Crear_NVI_Automatica(_Tbl_Productos As DataTable,
                                     _Suc_Destino As String,
                                     _Bod_Destino As String,
                                     _Fecha_Emision As Date) As DataRow

        Consulta_sql = "Select * From CONFIGP Where EMPRESA = '" & ModEmpresa & "'"
        Dim _Row_Configp As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        Dim _Koen = _Row_Configp.Item("RUT")

        Consulta_sql = "Select Top 1 * From MAEEN Where KOEN = '" & _Koen & "' And SUEN = '" & _Suc_Destino & "'"
        Dim _Row_Entidad As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        Dim _Tido = "NVI"

        Dim Fm As New Frm_Formulario_Documento(_Tido,
                                               csGlobales.Mod_Enum_Listados_Globales.Enum_Tipo_Documento.Nota_Venta_Interna,
                                               False, False, False, False, False)

        Fm.Pro_RowEntidad = _Row_Entidad
        Fm.Sb_Crear_Documento_Interno_Con_Tabla2(Me, _Tbl_Productos, _Fecha_Emision,
                                                "Codigo", "Pedir", "Costo", "Observacion", False, False)
        Fm.Pro_Bodega_Destino = _Bod_Destino
        Dim _New_Idmaeedo = Fm.Fx_Grabar_Documento(False)
        Fm.Dispose()

        If CBool(_New_Idmaeedo) Then
            Consulta_sql = "Select Top 1 * From MAEEDO Where IDMAEEDO = " & _New_Idmaeedo
            Dim _Row As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)
            Return _Row
        Else
            Return Nothing
        End If

    End Function

    Function Fx_Crear_NVI_Manual(_Tbl_Productos As DataTable,
                                 _Suc_Destino As String,
                                 _Bod_Destino As String,
                                 _Fecha_Emision As Date,
                                 _Ud As Integer,
                                 _TblPaso As String) As DataRow

        Consulta_sql = "Select * From CONFIGP Where EMPRESA = '" & ModEmpresa & "'"
        Dim _Row_Configp As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        Dim _Koen = _Row_Configp.Item("RUT")

        Consulta_sql = "Select Top 1 * From MAEEN Where KOEN = '" & _Koen & "' And SUEN = '" & _Suc_Destino & "'"
        Dim _Row_Entidad As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        Dim _Lista = ModListaPrecioCosto

        Dim _Tido = "NVI"

        Dim _Emp_Pedir As String = _Tbl_Productos.Rows(0).Item("Empresa")
        Dim _Suc_Pedir As String = _Tbl_Productos.Rows(0).Item("Sucursal")
        Dim _Bod_Pedir As String = _Tbl_Productos.Rows(0).Item("Bodega")

        'Dim _Lista As String = _Global_Row_Configuracion_General.Item("Lista_Precios_Proveedores")
        Dim _Filtro_Productos As String = Generar_Filtro_IN(_Tbl_Productos, "", "Codigo", False, False, "'")

        Consulta_sql = "Select 0 As IDMAEEDO,Getdate() As FEEMDO,Getdate() As FEER

                        Select Top 20 '" & FUNCIONARIO & "' As KOFULIDO,Tb.Codigo As KOPRCT,Tb.Descripcion As NOKOPR,
                        '' As Descripcion,'' As CodAlternativo,'" & _Lista & "' As KOLTPR,UD01PR As UD1,UD02PR As UD2,
                        Isnull(Mpm.PM,1) As CostoUd1,Isnull(Mpm.PM,1) * Mp.RLUD As CostoUd2,0 As Precio, Mp.RLUD As Rtu,Pedir As Cantidad,
                        0 As Desc1,0 As Desc2,0 As Desc3,0 As Desc4,0 As Desc5,0 As DescSuma,0 As PRCT,'' As TICT,TIPR,0 As PODTGLLI," & Ud & " as UDTRPR,
                        0 As POTENCIA,'' As KOFUAULIDO,'' As KOOPLIDO,
                        0 As IDMAEEDO,0 As IDMAEDDO,'" & _Emp_Pedir & "' As EMPRESA,'" & _Suc_Pedir & "' As SULIDO,'" & _Bod_Pedir & "' As BOSULIDO,'' As ENDO,'' As SUENDO,GetDate() As FEEMLI,
                        '' As TIDO,'' As NUDO,'' As NULIDO,0 As CantUd1_Dori,0 As CantUd2_Dori,'' As OBSERVA,
                        0 As Id_Oferta,'' As Oferta,0 As Es_Padre_Oferta,0 As Padre_Oferta,
						0 As Hijo_Oferta,0 As Cantidad_Oferta,0 As Porcdesc_Oferta

                        From  " & _TblPaso & " Tb

                        Inner Join MAEPR Mp On Mp.KOPR = Tb.Codigo
                            Left Join MAEPREM Mpm On Mpm.KOPR = Mp.KOPR And Mpm.EMPRESA = '" & _Emp_Pedir & "'
                                 Where Mp.KOPR In " & _Filtro_Productos & "
                        
                        Select * From MAEIMLI Where 1 < 0  
                        Select * From MAEDTLI Where 1 < 0 
                        Select 'Documento generado desde Asistente de compras BakApp' As OBDO"

        Dim _Ds_New_Documento As DataSet = _Sql.Fx_Get_DataSet(Consulta_sql)

        Dim _TblDetalle As DataTable = _Ds_New_Documento.Tables(1)

        If _TblDetalle.Rows.Count Then

            Me.Enabled = False

            Dim _New_Idmaeedo As Integer

            Dim Fm_Espera As New Frm_Form_Esperar
            Fm_Espera.Pro_Texto = "Armando NVI (Orden de entrega interna)" & vbCrLf & "por favor espere..."
            Fm_Espera.BarraCircular.IsRunning = True
            Fm_Espera.Show(Me)

            Dim Fm_Post As New Frm_Formulario_Documento(_Tido,
                                                        csGlobales.Enum_Tipo_Documento.Nota_Venta_Interna,
                                                        False, True, True)

            Fm_Post.Pro_Agrupar_Reemplazos = Chk_Traer_Productos_De_Reemplazo.Checked
            Fm_Post.Pro_RowEntidad = _Row_Entidad
            'Fm_Post.Pro_RowEntidad_Despacho = Nothing
            Fm_Post.Pro_Lista_de_precios_de_proveedores = Rd_Costo_Lista_Proveedor.Checked
            Fm_Post.Sb_Crear_Documento_Desde_Otros_Documentos(Me, _Ds_New_Documento, True, False, _Fecha_Emision, False, True)

            Fm_Post.MinimizeBox = False
            Fm_Post.Pro_Bodega_Destino = _Bod_Destino

            Fm_Espera.Close()
            Fm_Espera.Dispose()

            Fm_Post.ShowDialog(Me)
            _New_Idmaeedo = Fm_Post.Pro_Idmaeedo
            Fm_Post.Dispose()

            Me.Enabled = True

            If CBool(_New_Idmaeedo) Then

                If CBool(_New_Idmaeedo) Then
                    Consulta_sql = "Select Top 1 * From MAEEDO Where IDMAEEDO = " & _New_Idmaeedo
                    Dim _Row As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)
                    Return _Row
                Else
                    Return Nothing
                End If

            End If

        End If

    End Function

    Function Fx_Crear_NVI_Auto(_Tbl_Productos As DataTable,
                               _Suc_Destino As String,
                               _Bod_Destino As String,
                               _Fecha_Emision As Date,
                               _Ud As Integer,
                               _TblPaso As String) As GeneraOccAuto.Doc_Auto

        Dim _Nvi_Auto As New GeneraOccAuto.Doc_Auto

        Consulta_sql = "Select * From CONFIGP Where EMPRESA = '" & ModEmpresa & "'"
        Dim _Row_Configp As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        Dim _Koen = _Row_Configp.Item("RUT")

        Consulta_sql = "Select Top 1 * From MAEEN Where KOEN = '" & _Koen & "' And SUEN = '" & _Suc_Destino & "'"
        Dim _Row_Entidad As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        Dim _Lista = ModListaPrecioCosto

        Dim _Tido = "NVI"

        Dim _Emp_Pedir As String = _Tbl_Productos.Rows(0).Item("Empresa")
        Dim _Suc_Pedir As String = _Tbl_Productos.Rows(0).Item("Sucursal")
        Dim _Bod_Pedir As String = _Tbl_Productos.Rows(0).Item("Bodega")

        'Dim _Lista As String = _Global_Row_Configuracion_General.Item("Lista_Precios_Proveedores")
        Dim _Filtro_Productos As String = Generar_Filtro_IN(_Tbl_Productos, "", "Codigo", False, False, "'")

        Consulta_sql = "Select 0 As IDMAEEDO,Getdate() As FEEMDO,Getdate() As FEER

                        Select Top 20 '" & FUNCIONARIO & "' As KOFULIDO,Tb.Codigo As KOPRCT,Tb.Descripcion As NOKOPR,
                        '' As Descripcion,'' As CodAlternativo,'" & _Lista & "' As KOLTPR,UD01PR As UD1,UD02PR As UD2,
                        Isnull(Mpm.PM,1) As CostoUd1,Isnull(Mpm.PM,1) * Mp.RLUD As CostoUd2,0 As Precio, Mp.RLUD As Rtu,Pedir As Cantidad,
                        0 As Desc1,0 As Desc2,0 As Desc3,0 As Desc4,0 As Desc5,0 As DescSuma,0 As PRCT,'' As TICT,TIPR,0 As PODTGLLI," & Ud & " as UDTRPR,
                        0 As POTENCIA,'' As KOFUAULIDO,'' As KOOPLIDO,
                        0 As IDMAEEDO,0 As IDMAEDDO,'" & _Emp_Pedir & "' As EMPRESA,'" & _Suc_Pedir & "' As SULIDO,'" & _Bod_Pedir & "' As BOSULIDO,'' As ENDO,'' As SUENDO,GetDate() As FEEMLI,
                        '' As TIDO,'' As NUDO,'' As NULIDO,0 As CantUd1_Dori,0 As CantUd2_Dori,'' As OBSERVA,
                        0 As Id_Oferta,'' As Oferta,0 As Es_Padre_Oferta,0 As Padre_Oferta,
						0 As Hijo_Oferta,0 As Cantidad_Oferta,0 As Porcdesc_Oferta

                        From  " & _TblPaso & " Tb

                        Inner Join MAEPR Mp On Mp.KOPR = Tb.Codigo
                            Left Join MAEPREM Mpm On Mpm.KOPR = Mp.KOPR And Mpm.EMPRESA = '" & _Emp_Pedir & "'
                                 Where Mp.KOPR In " & _Filtro_Productos & "
                        
                        Select * From MAEIMLI Where 1 < 0  
                        Select * From MAEDTLI Where 1 < 0 
                        Select 'Documento generado desde Asistente de compras BakApp' As OBDO"

        Dim _Ds_New_Documento As DataSet = _Sql.Fx_Get_DataSet(Consulta_sql)

        Dim _TblDetalle As DataTable = _Ds_New_Documento.Tables(1)

        If _TblDetalle.Rows.Count Then

            Me.Enabled = False

            Dim _New_Idmaeedo As Integer

            Dim Fm_Espera As New Frm_Form_Esperar
            Fm_Espera.Pro_Texto = "Armando NVI (Orden de entrega interna)" & vbCrLf & "por favor espere..."
            Fm_Espera.BarraCircular.IsRunning = True
            Fm_Espera.Show(Me)

            Dim Fm_Post As New Frm_Formulario_Documento(_Tido,
                                                        csGlobales.Enum_Tipo_Documento.Nota_Venta_Interna,
                                                        False, True, True)

            Fm_Post.Pro_Agrupar_Reemplazos = Chk_Traer_Productos_De_Reemplazo.Checked
            Fm_Post.Pro_RowEntidad = _Row_Entidad
            Fm_Post.Pro_Lista_de_precios_de_proveedores = Rd_Costo_Lista_Proveedor.Checked
            Fm_Post.Sb_Crear_Documento_Desde_Otros_Documentos(Me, _Ds_New_Documento, True, False, _Fecha_Emision, False, True)

            Fm_Post.MinimizeBox = False
            Fm_Post.Pro_Bodega_Destino = _Bod_Destino

            Fm_Espera.Close()
            Fm_Espera.Dispose()

            Fm_Post.Fx_Grabar_Documento(False, csGlobales.Mod_Enum_Listados_Globales.Enum_Tipo_de_Grabacion.Nuevo_documento)
            _New_Idmaeedo = Fm_Post.Pro_Idmaeedo

            Fm_Post.Dispose()

            Me.Enabled = True

            If CBool(_New_Idmaeedo) Then

                If CBool(_New_Idmaeedo) Then

                    _Nvi_Auto.Idmaeedo = _New_Idmaeedo
                    _Nvi_Auto.Email = Auto_CorreoCc
                    _Nvi_Auto.Tido = "NVI"
                    _Nvi_Auto.Nudo = _Sql.Fx_Trae_Dato("MAEEDO", "NUDO", "IDMAEEDO = " & _New_Idmaeedo)
                    _Nvi_Auto.Feemdo = _Sql.Fx_Trae_Dato("MAEEDO", "FEEMDO", "IDMAEEDO = " & _New_Idmaeedo)

                End If

            End If

            Return _Nvi_Auto

        End If

    End Function

    Private Function Fx_Productos_A_Solicitar_Otras_Bodegas(_Emp_Reab As String,
                                                            _Suc_Reab As String,
                                                            _Bod_Reab As String,
                                                            _Nombre_Tbl_Paso As String) As DataTable

        Dim _Tbl_Productos As DataTable

        _Tbl_Productos = _Tbl_Informe

        Dim _Filtro_Productos = Generar_Filtro_IN(_Tbl_Productos, "", "Codigo", False, False, "'")
        Dim _Nombre_TblPaso_PrBd As String = "Tbl_PasoBod" & _Bod_Reab.Trim & FUNCIONARIO.Trim

        _Sql.Sb_Eliminar_Tabla_De_Paso(_Nombre_TblPaso_PrBd)


        Dim _Lista_Campos_Dscto As New List(Of String)

        _Lista_Campos_Dscto = Fx_Lista_Campos_Dscto()

        Dim _Campos_Descuentos = String.Empty

        For Each _Campo As String In _Lista_Campos_Dscto
            _Campos_Descuentos += "[" & _Campo & "]         [Float]        DEFAULT (0)," & vbCrLf
        Next

        Consulta_sql = My.Resources.Recursos_Asis_Compras.SQLQuery_Crear_tabla_de_paso_inf_compra
        Consulta_sql = Replace(Consulta_sql, "#TablaPaso#", _Nombre_TblPaso_PrBd)
        Consulta_sql = Replace(Consulta_sql, "#IN#", _Filtro_Productos)
        Consulta_sql = Replace(Consulta_sql, "#Campos_Descuentos#", _Campos_Descuentos)
        _Sql.Ej_consulta_IDU(Consulta_sql)

        If Chk_Sumar_Rotacion_Hermanos.Checked Then

            Consulta_sql = "Select Arbol.Codigo_Nodo,Arbol.Codigo_Madre From 
                                " & _Global_BaseBk & "Zw_Prod_Asociacion Prod
                                Inner Join " & _Global_BaseBk & "Zw_TblArbol_Asociaciones Arbol On Prod.Codigo_Nodo = Arbol.Codigo_Nodo
                                Where Arbol.Nodo_Raiz = " & _Nodo_Raiz_Asociados & " And Es_Seleccionable = 1 And Codigo In " & _Filtro_Productos

            Dim _Tbl_Codigos_Madre As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        Else

        End If

        Consulta_sql = "Insert Into " & _Nombre_TblPaso_PrBd & " (Codigo,Codigo_Nodo_Madre,Descripcion,UD1,UD2,Rtu,ClasificacionLibre,Rubro,Marca,Zona,SuperFamilia,Familia,SubFamilia,Bloqueapr,Oculto)" & vbCrLf &
                               "SELECT KOPR,'',NOKOPR,UD01PR,UD02PR,RLUD,CLALIBPR,RUPR,MRPR,ZONAPR,FMPR,PFPR,HFPR,BLOQUEAPR,ATPR" & vbCrLf &
                               "FROM MAEPR Mp WHERE KOPR IN " & _Filtro_Productos
        _Sql.Ej_consulta_IDU(Consulta_sql)


        If Chk_Sumar_Rotacion_Hermanos.Checked Then

            Consulta_sql = "Select Codigo As Kopr, Prod.Codigo_Nodo, DescripcionBusqueda,Arbol.Codigo_Madre,Arbol.Descripcion As Descripcion_Nodo
                                    Into #Paso
                                    From " & _Global_BaseBk & "Zw_Prod_Asociacion Prod
                                    Inner Join " & _Global_BaseBk & "Zw_TblArbol_Asociaciones Arbol On Prod.Codigo_Nodo = Arbol.Codigo_Nodo
                                    Where Arbol.Nodo_Raiz = " & _Nodo_Raiz_Asociados & " And Es_Seleccionable = 1

                                    Update " & _Nombre_TblPaso_PrBd & " Set 
                                        Codigo_Nodo = Isnull(#Paso.Codigo_Nodo,0),
                                        Codigo_Nodo_Madre = Isnull(Codigo_Madre,Codigo),
                                        Descripcion_Madre = Isnull(Descripcion_Nodo,Descripcion)

                                    From " & _Nombre_TblPaso_PrBd & " Z1
                                    Left Join #Paso On Kopr = Codigo

                                    Drop Table #Paso"

            _Sql.Ej_consulta_IDU(Consulta_sql)


            Consulta_sql = "Insert Into " & _Nombre_TblPaso_PrBd & "(Codigo,Codigo_Nodo,Descripcion,Codigo_Nodo_Madre,Descripcion_Madre)
                                    Select Codigo As Kopr, Prod.Codigo_Nodo, NOKOPR,Arbol.Codigo_Madre,NOKOPR As Descripcion_Nodo
                                    From " & _Global_BaseBk & "Zw_Prod_Asociacion Prod
                                    Inner Join " & _Global_BaseBk & "Zw_TblArbol_Asociaciones Arbol On Prod.Codigo_Nodo = Arbol.Codigo_Nodo
                                    Left Join MAEPR On KOPR = Codigo        
                                    Where  Prod.Codigo_Nodo In (Select Codigo_Nodo From " & _Nombre_TblPaso_PrBd & ") And Codigo Not In (Select Codigo From " & _Nombre_TblPaso_PrBd & ")"

            _Sql.Ej_consulta_IDU(Consulta_sql)

        Else

            Consulta_sql = "Update " & _Nombre_TblPaso_PrBd & " Set Codigo_Nodo_Madre = Codigo"
            _Sql.Ej_consulta_IDU(Consulta_sql)

        End If


        Me.Refresh()

        Dim _Filtro_Bodega = "And EMPRESA = '" & _Emp_Reab & "' And SULIDO = '" & _Suc_Reab & "' And BOSULIDO = '" & _Bod_Reab & "'"

        Dim _Fecha_Desde_Rot_Vta As Date
        Dim _Fecha_Hasta_Rot_vta As Date

        Dim _Rango_Fechas_Vta_Promedio As Boolean = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Tmp_Prm_Informes", "Valor",
                                                                              "Funcionario = '" & FUNCIONARIO & "' And Informe = 'Compras_Asistente' And NombreEquipo = '" & _NombreEquipo & "' And 
                                                                               Campo = 'Rdb_Rango_Fechas_Vta_Promedio'",, False, False, True)
        Dim _Rango_Meses_Vta_Promedio As Boolean = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Tmp_Prm_Informes", "Valor",
                                                                              "Funcionario = '" & FUNCIONARIO & "' And Informe = 'Compras_Asistente' And NombreEquipo = '" & _NombreEquipo & "' And 
                                                                               Campo = 'Rdb_Rango_Meses_Vta_Promedio'",, False, False, True)

        Dim _Fecha_Vta_Desde As Date = Convert.ToDateTime(_Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Tmp_Prm_Informes", "Valor",
                                                                              "Funcionario = '" & FUNCIONARIO & "' And Informe = 'Compras_Asistente' And NombreEquipo = '" & _NombreEquipo & "' And 
                                                                               Campo = 'Dtp_Fecha_Vta_Desde'"))
        Dim _Fecha_Vta_Hasta As Date = Convert.ToDateTime(_Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Tmp_Prm_Informes", "Valor",
                                                                              "Funcionario = '" & FUNCIONARIO & "' And Informe = 'Compras_Asistente' And NombreEquipo = '" & _NombreEquipo & "' And 
                                                                               Campo = 'Dtp_Fecha_Vta_Hasta'"))

        Dim _Ultimos_Meses_Vta_Promedio As Integer = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Tmp_Prm_Informes", "Valor",
                                                                              "Funcionario = '" & FUNCIONARIO & "' And Informe = 'Compras_Asistente' And NombreEquipo = '" & _NombreEquipo & "' And 
                                                                               Campo = 'Input_Ultimos_Meses_Vta_Promedio'")

        If _Rango_Fechas_Vta_Promedio Then
            _Fecha_Desde_Rot_Vta = _Fecha_Vta_Desde
            _Fecha_Hasta_Rot_vta = _Fecha_Vta_Hasta
        ElseIf _Rango_Meses_Vta_Promedio Then
            _Fecha_Hasta_Rot_vta = FormatDateTime(FechaDelServidor(), DateFormat.ShortDate)
            _Fecha_Desde_Rot_Vta = DateAdd(DateInterval.Month, -_Ultimos_Meses_Vta_Promedio, _Fecha_Hasta_Rot_vta) '#1/1/1900#
        End If

        Dim _EntExcluidas As String = String.Empty

        If Not Chk_Rotacion_Con_Ent_Excluidas.Checked Then

            _EntExcluidas = Space(1) & "And LTrim(RTrim(ENDO))+LTrim(RTrim(SUENDO))" & vbCrLf &
                                "NOT IN (SELECT LTrim(RTrim(Codigo))+LTrim(RTrim(Sucursal))" & vbCrLf &
                                "From " & _Global_BaseBk & "Zw_TblInf_EntExcluidas" & vbCrLf &
                                "Where Funcionario = '" & FUNCIONARIO & "' And Excluida in ('V','A','T'))" & Space(1)

        End If

        Consulta_sql = My.Resources.Recursos_Asis_Compras.SQLQuery_Sacar_la_velocidad_de_venta_mensual_Media
        Consulta_sql = Replace(Consulta_sql, "#Empresa#", ModEmpresa)
        Consulta_sql = Replace(Consulta_sql, "#Funcionario#", FUNCIONARIO)
        Consulta_sql = Replace(Consulta_sql, "#FechaInicio#", Format(_Fecha_Desde_Rot_Vta, "yyyyMMdd"))
        Consulta_sql = Replace(Consulta_sql, "#FechaTermino#", Format(_Fecha_Hasta_Rot_vta, "yyyyMMdd"))
        Consulta_sql = Replace(Consulta_sql, "#Filtro_Codigo#", "AND KOPRCT In (Select Codigo From #TablaPaso#)")
        Consulta_sql = Replace(Consulta_sql, "#Filtro_Bodega#", _Filtro_Bodega)
        Consulta_sql = Replace(Consulta_sql, "#Entidades_Excluidas#", _EntExcluidas)
        Consulta_sql = Replace(Consulta_sql, "#TablaPaso#", _Nombre_TblPaso_PrBd)

        Consulta_sql = Replace(Consulta_sql, "#Codigo_Revision#", "Codigo_Nodo_Madre")

        'Consulta_sql = Replace(Consulta_sql, "#Campo_RotMensualUd1#", "RotMensualUd1")
        'Consulta_sql = Replace(Consulta_sql, "#Campo_RotMensualUd2#", "RotMensualUd2")

        If _Rdb_RotDias Then
            Consulta_sql = Replace(Consulta_sql, "#Campo_RotUd1#", "RotDiariaUd1")
            Consulta_sql = Replace(Consulta_sql, "#Campo_RotUd2#", "RotDiariaUd2")
            Consulta_sql = Replace(Consulta_sql, "#MediaCal#", "#MediaDias")
        End If

        If _Rdb_RotMeses Then
            Consulta_sql = Replace(Consulta_sql, "#Campo_RotUd1#", "RotMensualUd1")
            Consulta_sql = Replace(Consulta_sql, "#Campo_RotUd2#", "RotMensualUd2")
            Consulta_sql = Replace(Consulta_sql, "#MediaCal#", "#MediaMes")
        End If

        Consulta_sql = Replace(Consulta_sql, "#Campo_Promedio_Ud1#", "Promedio_Ud1")
        Consulta_sql = Replace(Consulta_sql, "#Campo_Promedio_Ud2#", "Promedio_Ud2")

        Me.Refresh()

        _Sql.Ej_consulta_IDU(Consulta_sql)

        ' Ventas los ultimos 3 meses, para tendencia

        Me.Refresh()

        Dim _Clas_Asistente_Compras_Bod_Origen As Clas_Asistente_Compras

        _Clas_Asistente_Compras_Bod_Origen = New Clas_Asistente_Compras(_Nombre_TblPaso_PrBd)

        _Clas_Asistente_Compras_Bod_Origen.Pro_Filtro_Bodegas_Todas = False

        Consulta_sql = "Select Cast(1 As Bit) As Chk,KOBO As Codigo,NOKOBO As Descripcion 
                        From TABBO WHere EMPRESA = '" & _Emp_Reab & "' And KOSU = '" & _Suc_Reab & "' And KOBO = '" & _Bod_Reab & "'"

        Dim _Tbl_Bodegas_Fl As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        _Filtro_Bodega = "And EMPRESA = '" & _Emp_Reab & "' And KOSU = '" & _Suc_Reab & "' And KOBO = '" & _Bod_Reab & "'"

        Consulta_sql = My.Resources.Recursos_Asis_Compras.SQLQuery_Inserta_stock_por_producto
        Consulta_sql = Replace(Consulta_sql, "#TablaPaso#", _Nombre_TblPaso_PrBd)
        Consulta_sql = Replace(Consulta_sql, "#CodFuncionario#", FUNCIONARIO)
        Consulta_sql = Replace(Consulta_sql, "#Filtro_Bodega#", _Filtro_Bodega)
        Consulta_sql = Replace(Consulta_sql, "Zw_Prod_Asociacion", _Global_BaseBk & "Zw_Prod_Asociacion")

        _Sql.Ej_consulta_IDU(Consulta_sql)


        With _Clas_Asistente_Compras_Bod_Origen

            .Pro_Chk_Advertir_Rotacion = False
            .Pro_Chk_Sabado = Chk_Sabado.Checked
            .Pro_Chk_Domingo = Chk_Domingo.Checked
            .Pro_Chk_Restar_Stok_Bodega = Chk_Restar_Stok_Bodega.Checked
            .Pro_Chk_Rotacion_Con_Ent_Excluidas = Chk_Rotacion_Con_Ent_Excluidas.Checked
            .Pro_Chk_Trabajando_Con_Proyeccion = Chk_Trabajando_Con_Proyeccion.Checked

            .Pro_Input_Dias_a_Abastecer = Input_Dias_a_Abastecer.Value
            .Pro_Input_Dias_Advertencia_Rotacion = Input_Dias_a_Abastecer.Value
            .Pro_Input_Porc_Crecimiento = Input_Porc_Crecimiento.Value
            .Pro_Input_Tiempo_Reposicion = Input_Tiempo_Reposicion.Value
            .Pro_Proceso_Automatico_Ejecutado = _Proceso_Automatico_Ejecutado
            .Pro_Rdb_Agrupar_x_Asociados = Rdb_Agrupar_x_Asociados.Checked
            .Pro_Rdb_Ud1_Compra = Rdb_Ud1_Compra.Checked
            .Pro_Rdb_Ud2_Compra = Rdb_Ud2_Compra.Checked

            .Pro_Filtro_Bodegas_Todas = False
            .Pro_Tbl_Filtro_Bodegas = _Tbl_Bodegas_Fl
            .Rdb_RotDias = _Rdb_RotDias
            .Rdb_RotMeses = _Rdb_RotMeses
            .Rdb_Rot_Mediana = Rdb_Rot_Mediana.Checked
            .Rdb_Rot_Promedio = Rdb_Rot_Promedio.Checked

            If Cmb_Metodo_Abastecer_Dias_Meses.SelectedValue = 1 Then
                .Pro_Proyeccion_Metodo_Abastecer = Clas_Asistente_Compras.Enum_Proyeccion.Dias
            ElseIf Cmb_Metodo_Abastecer_Dias_Meses.SelectedValue = 30 Then
                .Pro_Proyeccion_Metodo_Abastecer = Clas_Asistente_Compras.Enum_Proyeccion.Meses
            End If

            If Cmb_Tiempo_Reposicion_Dias_Meses.SelectedValue = 1 Then
                .Pro_Proyeccion_Tiempo_Reposicion = Clas_Asistente_Compras.Enum_Proyeccion.Dias
            ElseIf Cmb_Metodo_Abastecer_Dias_Meses.SelectedValue = 30 Then
                .Pro_Proyeccion_Tiempo_Reposicion = Clas_Asistente_Compras.Enum_Proyeccion.Meses
            End If

            .Sb_Actualizar_Rotacion("", False)

        End With

        Dim _Dias_Abastecer = Input_Dias_a_Abastecer.Value
        Dim _Fecha_Servidor As Date = FechaDelServidor()

        Dim _Fecha_Fin = DateAdd(DateInterval.Day, _Dias_Abastecer, _Fecha_Servidor)

        _Dias_Abastecer = Fx_Cuenta_Dias(_Fecha_Servidor, _Fecha_Fin, Opcion_Dias.Habiles)

        Dim _Sabados As Integer = Fx_Cuenta_Dias(_Fecha_Servidor, _Fecha_Fin, Opcion_Dias.Sabado)
        Dim _Domingos As Integer = Fx_Cuenta_Dias(_Fecha_Servidor, _Fecha_Fin, Opcion_Dias.Domingo)

        If Chk_Sabado.Checked Then _Dias_Abastecer += _Sabados
        If Chk_Domingo.Checked Then _Dias_Abastecer += _Domingos

        Consulta_sql = "Insert Into " & _Nombre_Tbl_Paso & " (Empresa,Sucursal,Bodega,Codigo,Descripcion,Codigo_Nodo,Stock_Fisico_Madre," & vbCrLf &
                       "Stock_Fisico_Prod,Stock_CriticoUd" & Ud & "_Rd,CantComprar,TStock,RotDiariaUd" & Ud & ",RotMensualUd" & Ud & ",Dias,Solicitar,Pedir,Pedir_Hnos)" & vbCrLf &
                       "Select '" & _Emp_Reab & "' As Empresa,'" & _Suc_Reab & "' As Sucursal,'" & _Bod_Reab & "' As Bodega,Codigo,Isnull(Descripcion,''),Codigo_Nodo," & vbCrLf &
                       "Stock_Fisico_Ud" & Ud & " As Stock_Fisico_Madre,0 As Stock_Fisico_Prod,Stock_CriticoUd" & Ud & "_Rd,CantComprar,TStock,RotDiariaUd" & Ud & ",RotMensualUd" & Ud & "," & vbCrLf &
                        _Dias_Abastecer & " As Dias," & vbCrLf &
                       "Round(Stock_Fisico_Ud" & Ud & "-RotDiariaUd" & Ud & "*" & _Dias_Abastecer & ",0) As Solicitar," & vbCrLf &
                       "Cast(0 As Float) As Pedir,Cast(0 As Float) As Pedir_Hnos" & vbCrLf & vbCrLf &
                       "From " & _Nombre_TblPaso_PrBd & vbCrLf &
                       "Where TStock >= 30 And Round(Stock_Fisico_Ud" & Ud & "-RotDiariaUd" & Ud & "*" & _Dias_Abastecer & ",0) <= Stock_Fisico_Ud" & Ud & " And Round(Stock_Fisico_Ud" & Ud & "-RotDiariaUd" & Ud & "*" & _Dias_Abastecer & ",0) > 0" & vbCrLf & vbCrLf

        If _Sql.Ej_consulta_IDU(Consulta_sql) Then

            Consulta_sql = "Update " & _Nombre_Tbl_Paso & " Set CantComprar = Isnull((Select CantComprar From " & _Nombre_Tbl_Paso_Informe & " InfC Where InfC.Codigo = " & _Nombre_Tbl_Paso & ".Codigo),0)
                            Where Empresa = '" & _Emp_Reab & "' And Sucursal = '" & _Suc_Reab & "' And Bodega = '" & _Bod_Reab & "'"
            _Sql.Ej_consulta_IDU(Consulta_sql)

            Consulta_sql = "Update " & _Nombre_Tbl_Paso & " Set Solicitar = CantComprar 
						    Where Solicitar > CantComprar And Empresa = '" & _Emp_Reab & "' And Sucursal = '" & _Suc_Reab & "' And Bodega = '" & _Bod_Reab & "'"
            _Sql.Ej_consulta_IDU(Consulta_sql)

            Consulta_sql = "Update " & _Nombre_Tbl_Paso & " Set Stock_Fisico_Prod = Isnull((Select STFI" & Ud & " From MAEST Where EMPRESA = '" & _Emp_Reab & "' And KOSU = '" & _Suc_Reab & "' And KOBO = '" & _Bod_Reab & "' And KOPR = Codigo),0)
                            Where Empresa = '" & _Emp_Reab & "' And Sucursal = '" & _Suc_Reab & "' And Bodega = '" & _Bod_Reab & "'"
            _Sql.Ej_consulta_IDU(Consulta_sql)

            Consulta_sql = "Update " & _Nombre_Tbl_Paso & " Set Costo = Isnull((Select PM From MAEPREM Where EMPRESA = Empresa And KOPR = Codigo),1)"
            _Sql.Ej_consulta_IDU(Consulta_sql)

            Consulta_sql = "Update " & _Nombre_Tbl_Paso & " Set Pedir_Hnos = Case When Solicitar-Stock_Fisico_Prod > 0 Then Solicitar-Stock_Fisico_Prod Else 0 End
                            Where Empresa = '" & _Emp_Reab & "' And Sucursal = '" & _Suc_Reab & "' And Bodega = '" & _Bod_Reab & "'"
            _Sql.Ej_consulta_IDU(Consulta_sql)

            Consulta_sql = "Update " & _Nombre_Tbl_Paso & " Set Pedir = Case When Solicitar-Pedir_Hnos > 0 Then Solicitar-Pedir_Hnos Else 0 End
                            Where Empresa = '" & _Emp_Reab & "' And Sucursal = '" & _Suc_Reab & "' And Bodega = '" & _Bod_Reab & "'"
            _Sql.Ej_consulta_IDU(Consulta_sql)

            Consulta_sql = "Delete " & _Nombre_Tbl_Paso & " Where CantComprar <=0"
            _Sql.Ej_consulta_IDU(Consulta_sql)

        End If
        '_Tbl_Productos = _Sql.Fx_Get_Tablas(Consulta_sql)

        _Sql.Sb_Eliminar_Tabla_De_Paso(_Nombre_TblPaso_PrBd)

        'Return _Tbl_Productos

    End Function

    Private Sub BtnImprimirListado_Click(sender As Object, e As EventArgs) Handles BtnImprimirListado.Click

        Dim _CodProveedor = _RowProveedor.Item("KOEN")
        Dim _SucProveedor = _RowProveedor.Item("SUEN")

        'Dim _Ud = 1

        'If Rdb_Ud2_Compra.Checked Then
        '    _Ud = 2
        'End If

        Dim _Clas_Imprimir_AsisCompra As New Clas_Imprimir_AsisCompra()
        If _Clas_Imprimir_AsisCompra.Fx_Ejecutar_Impresion(_CodProveedor, _SucProveedor, _Ud) Then
            _Clas_Imprimir_AsisCompra.Fx_Imprimir_Archivo(Me, "")
        End If

    End Sub

    Private Sub Btn_Ver_Cardex_De_Inventario_Click(sender As Object, e As EventArgs) Handles Btn_Ver_Cardex_De_Inventario.Click

        Dim _Cabeza = Fm_Hijo.Grilla.Columns(Fm_Hijo.Grilla.CurrentCell.ColumnIndex).Name
        Dim _Fila As DataGridViewRow = Fm_Hijo.Grilla.Rows(Fm_Hijo.Grilla.CurrentRow.Index)

        Dim _Codigo As String = _Fila.Cells("Codigo").Value
        Dim _UnTrans As Integer

        If Rdb_Ud1_Compra.Checked Then : _UnTrans = 1 : Else : _UnTrans = 2 : End If

        If Fr_Alerta_Stock.Visible Then
            Fr_Alerta_Stock.Close()
        Else
            Codigo_abuscar = _Codigo
            Fr_Alerta_Stock = New AlertCustom(_Codigo, _UnTrans)
            ShowLoadAlert(Fr_Alerta_Stock, Me)
        End If

    End Sub

    Private Sub Btn_Copiar_Click(sender As Object, e As EventArgs) Handles Btn_Copiar.Click

        Dim _Fila As DataGridViewRow = Fm_Hijo.Grilla.Rows(Fm_Hijo.Grilla.CurrentRow.Index)
        Dim _Cabeza = Fm_Hijo.Grilla.Columns(Fm_Hijo.Grilla.CurrentCell.ColumnIndex).Name

        Dim Copiar = Trim(_Fila.Cells(_Cabeza).Value)
        Clipboard.SetText(Copiar)

    End Sub

    Sub LlenarPointMchar(ByVal Mchar As DevComponents.DotNetBar.MicroChart,
                         ByVal Tabla As DataTable,
                         Optional ByVal Unidad As Integer = 1)
        Dim points As New List(Of Double)()

        Dim Campo As String = "Ud" & Unidad

        For Each Fila As DataRow In Tabla.Rows
            Dim Punto As Double = Fila.Item(Campo)
            points.Add(Punto)
        Next

        Mchar.DataPoints = points

    End Sub

    Sub Btn_Filtrar_Proveedor_Click(sender As Object, e As EventArgs)

        Dim _Reg As Boolean = _Sql.Fx_Cuenta_Registros(_Nombre_Tbl_Paso_Informe, "CodProveedor <> ''")

        If _Reg Then

            Dim Fm = New Frm_04_Asis_Compra_Proveedores(Frm_04_Asis_Compra_Proveedores.TipoBusqueda.Proveedores_Seleccionados, "", True)

            Dim _Condicion As String = String.Empty


            If Chk_Mostrar_Solo_Stock_Critico.Checked Then
                _Condicion += "And Con_Stock_CriticoUd" & Ud & " = 1" & vbCrLf
            End If

            If Chk_No_Considera_Con_Stock_Pedido_OCC_NVI.Checked Then
                _Condicion += "And StockPedidoUd" & Ud & " = 0" & vbCrLf
            End If

            If Chk_Mostrar_Solo_a_Comprar_Cant_Mayor_Cero.Checked Then
                _Condicion += "And CantComprar > 0" & vbCrLf
            End If

            If Chk_Quitar_Comprados.Checked Then
                _Condicion += "And OccGenerada = 0" & vbCrLf
            End If

            If Chk_Mostrar_Solo_Productos_A_Comprar.Checked Then
                _Condicion += "And Comprar = 1" & vbCrLf
            End If

            If Chk_Quitar_Ventas_Calzadas.Checked Then
                _Condicion += "And Refleo = 0" & vbCrLf
            End If

            If Chk_Quitare_Sospechosos_Stock.Checked Then
                _Condicion += "And Sospecha_Baja_Rotacion = 0" & vbCrLf
            End If

            Fm.Pro_Conficion_Adicional = _Condicion
            Fm.Chk_Solo_Proveedores_CodAlternativo.Enabled = False
            Fm.Rd_Costo_Lista_Proveedor.Enabled = False
            Fm.Rd_Costo_Ultima_GRC.Enabled = False
            Fm.ShowDialog(Me)

            If Not (Fm.Pro_RowProveedor Is Nothing) Then
                _RowProveedor = Fm.Pro_RowProveedor
                Sb_Grilla_Actualizar_Informe(Fm_Hijo.Grilla)
                Sb_Grilla_Marcar(Fm_Hijo.Grilla, False)
                Fm_Hijo.Btn_Quitar_Filtro_Proveedor.Enabled = True
                Btn_Quitar_Filtro_Proveedor_Ribon.Enabled = True
            End If

            Fm_Hijo.Chk_Ver_Doc_Solo_Proveedor.Enabled = Not (Fm.Pro_RowProveedor Is Nothing)

            Fm.Dispose()
        Else
            MessageBoxEx.Show(Me, "No hay proveedores asociados a ningún producto",
                              "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Sub

    Private Sub Rd_Costo_Lista_Proveedor_CheckedChanged(sender As Object, e As EventArgs) Handles Rd_Costo_Lista_Proveedor.CheckedChanged
        Cmb_Lista_Costos.Enabled = Rd_Costo_Lista_Proveedor.Checked
    End Sub

    Private Sub Btn_Lista_Costos_Proveedor_Click(sender As Object, e As EventArgs) Handles Btn_Lista_Costos_Proveedor.Click

        If Fx_Tiene_Permiso(Me, "Pre0013") Then

            Dim _Tbl_Lista_Seleccionada As DataTable
            Dim _CodLista As String = _Global_Row_Configuracion_General.Item("Lista_Precios_Proveedores")

            If String.IsNullOrEmpty(_CodLista) Then

                Dim Fm As New Frm_SeleccionarListaPrecios(Frm_SeleccionarListaPrecios.Enum_Tipo_Lista.Costo, False, False)
                Fm.ShowDialog(Me)
                _Tbl_Lista_Seleccionada = Fm.Pro_Tbl_Listas_Seleccionadas
                Fm.Dispose()

                If Not (_Tbl_Lista_Seleccionada Is Nothing) Then
                    _CodLista = _Tbl_Lista_Seleccionada.Rows(0).Item("Lista")
                End If

            End If

            If Not String.IsNullOrEmpty(_CodLista.Trim) Then

                If IsNothing(_RowProveedor) Then

                    Dim Fm_E As New Frm_BuscarEntidad_Mt(False)
                    Fm_E.ShowInTaskbar = False
                    Fm_E.Text = "Busqueda de proveedores para lista de costos"
                    Fm_E.ShowDialog(Me)
                    If Fm_E.Pro_Entidad_Seleccionada Then
                        _RowProveedor = Fm_E.Pro_RowEntidad
                    End If
                    Fm_E.Dispose()

                End If

                If Not IsNothing(_RowProveedor) Then

                    Dim _Koen = _RowProveedor.Item("KOEN")
                    Dim _Suen = _RowProveedor.Item("SUEN")
                    Dim _Id_Padre As Integer

                    If _Global_Row_Configuracion_Estacion.Item("Actualizar_Lista_De_Costos_Random_Desde_Bakapp") Then

                        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_ListaPreCosto_Enc" & vbCrLf &
                               "Where Proveedor = '" & _Koen & "' And Sucursal = '" & _Suen & "' And Vigente = 1"
                        Dim _RowListaPreCosto_Enc As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

                        If IsNothing(_RowListaPreCosto_Enc) Then

                            MessageBoxEx.Show(Me, "No es posible realizar el proceso" & vbCrLf & vbCrLf &
                                  "Para poder actualizar la información de la lista de costos del proveedor debe hacer lo siguiente:" & vbCrLf & vbCrLf &
                                  "1.- Ir al menú de inicio" & vbCrLf &
                                  "2.- opción [PRECIOS Y COSTOS]" & vbCrLf &
                                  "3.- opción [LISTA DE PROVEEDORES]" & vbCrLf &
                                  "4.- Buscar al proveedor" & vbCrLf &
                                  "5.- Realizar la gestión de mantenimiento de lista de costos de ese proveedor" & vbCrLf &
                                  " * Dejar una lista de costos vigente" & vbCrLf &
                                  " * Fecha de vencimiento mayor a la fecha actual", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            Return

                        End If

                        _Id_Padre = _RowListaPreCosto_Enc.Item("Id")

                    End If

                    Dim Fm_P As New Frm_MantCostosPrecios(_RowProveedor, _CodLista)
                    Fm_P.Id_Padre = _Id_Padre
                    Fm_P.ShowDialog(Me)

                    If Fm_P.Pro_Grabacion_Realizada Then
                        If _Global_Row_Configuracion_Estacion.Item("Actualizar_Lista_De_Costos_Random_Desde_Bakapp") Then
                            Fx_Actualizar_Lista_De_Costos_Random_Desde_Bakapp(Me, _Koen, _Suen)
                        End If
                        Call Btn_Actualizar_Informe_Click(Nothing, Nothing)
                    End If

                    Fm_P.Dispose()

                Else
                    MessageBoxEx.Show(Me, "No se seleccionó ningún proveedor",
                                     "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If

            End If

        End If

    End Sub

    Private Sub Btn_Rev_Cumpl_Proveedor_Click(sender As Object, e As EventArgs) Handles Btn_Rev_Cumpl_Proveedor.Click

        Dim _Fila As DataGridViewRow = Fm_Hijo.Grilla.Rows(Fm_Hijo.Grilla.CurrentRow.Index)

        Dim _Endo As String = _Fila.Cells("CodProveedor").Value
        Dim _Suendo As String = _Fila.Cells("CodSucProveedor").Value

        If String.IsNullOrEmpty(_Endo.ToString.Trim) Then
            MessageBoxEx.Show(Me, "No hay ningun proveedor seleccionado", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        Dim _Codigo As String = _Fila.Cells("Codigo").Value

        Dim Fm As New Frm_CumplXProveedor(_Endo, _Suendo, _Codigo)
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Private Sub Timer_Ejecucion_Automatica_Tick(sender As Object, e As EventArgs) Handles Timer_Ejecucion_Automatica.Tick

        Timer_Ejecucion_Automatica.Stop()

        If Auto_GenerarAutomaticamenteOCCProveedores Then

            Call BtnProceso_Prov_Auto_Click(Nothing, Nothing)

            BtnProceso_Prov_Auto.Enabled = False
            Chk_Mostrar_Solo_a_Comprar_Cant_Mayor_Cero.Checked = _Proceso_Automatico_Ejecutado
            Chk_Quitar_Ventas_Calzadas.Checked = True
            Chk_Quitare_Sospechosos_Stock.Checked = True

            Chk_No_Considera_Con_Stock_Pedido_OCC_NVI.Checked = True
            Chk_Mostrar_Solo_a_Comprar_Cant_Mayor_Cero.Checked = True
            Chk_Quitar_Comprados.Checked = True
            Chk_Mostrar_Solo_Productos_A_Comprar.Checked = True

            Sb_Refrescar_Grilla_Principal(Fm_Hijo.Grilla, False, False)

            Consulta_sql = "Select Distinct CodProveedor As KOEN,CodSucProveedor As SUEN,
(Select Top 1 NOKOEN From MAEEN Where KOEN = CodProveedor and SUEN = CodSucProveedor ) As RAZON,
Count(Codigo) As Productos,CAST(Null As datetime) As FechaUltCompra
Into #Paso
From " & _Nombre_Tbl_Paso_Informe & "
Where CodProveedor <> '' AND CantComprar > 0 And OccGenerada = 0 And Comprar = 1
And CodProveedor In (Select KOEN From MAEEN Where KOEN+NOKOEN Like '%%')
And Con_Stock_CriticoUd1 = 1
And CantComprar > 0
And Refleo = 0
And Sospecha_Baja_Rotacion = 0
Group by CodProveedor,CodSucProveedor

Update #Paso Set FechaUltCompra = (Select Top 1 FEEMDO From MAEEDO Where TIDO = 'FCC' And ENDO = KOEN And SUENDO = SUEN Order By FEEMDO Desc)

Select * From #Paso Order By FechaUltCompra

Drop Table #Paso"

            Dim _Tbl_Proveedores As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

            Dim _Generar_OCC As New GeneraOccAuto.Generar_Doc_Auto

            For Each _Fila As DataRow In _Tbl_Proveedores.Rows

                Dim _CodEntidad As String = _Fila.Item("KOEN")
                Dim _SucEntidad As String = _Fila.Item("SUEN")
                Dim _FechaUltCompra As DateTime = _Fila.Item("FechaUltCompra")

                Sb_Genarar_OCC_Automaticas_Por_Proveedor(_CodEntidad, _SucEntidad, _Generar_OCC)

            Next

            For Each _Fl As GeneraOccAuto.Doc_Auto In _Generar_OCC.Doc_Auto

                Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Demonio_AcpAuto (NombreEquipo,Modalidad,Idmaeedo,Tido,Nudo,FechaEmision,Informacion,ErrorGrabar) Values " &
                               "('" & _NombreEquipo & "','" & _Modalidad_Estudio & "'," & _Fl.Idmaeedo & ",'" & _Fl.Tido & "','" & _Fl.Nudo & "'" &
                               ",'" & Format(_Fl.Feemdo, "yyyyMMdd") & "','" & NuloPorNro(_Fl.MensajeError, "") & "'," & Convert.ToInt32(_Fl.ErrorGrabar) & ")"
                _Sql.Ej_consulta_IDU(Consulta_sql)

                _Generar_OCC.Fx_Enviar_Notificacion_Correo_Al_Diablito(_Fl.Idmaeedo, _Fl.Email, Auto_CorreoCc, Auto_Id_Correo, Auto_NombreFormato_PDF)
                ' 37
                ' "Tam. Carta"
                MessageBoxEx.Show(Me, "Tido: " & _Fl.Tido & "-" & _Fl.Nudo & vbCrLf &
                                  "Email: " & _Fl.Email, "OCC Generada", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Next

            Me.Close()

        End If

        If Auto_GenerarAutomaticamenteOCCProveedorStar Then

            Call BtnProceso_Prov_Auto_Especial_Click(Nothing, Nothing)

            BtnProceso_Prov_Auto.Enabled = False
            Chk_Mostrar_Solo_a_Comprar_Cant_Mayor_Cero.Checked = _Proceso_Automatico_Ejecutado
            Chk_Quitar_Ventas_Calzadas.Checked = True
            Chk_Quitare_Sospechosos_Stock.Checked = True

            Chk_No_Considera_Con_Stock_Pedido_OCC_NVI.Checked = True
            Chk_Mostrar_Solo_a_Comprar_Cant_Mayor_Cero.Checked = True
            Chk_Quitar_Comprados.Checked = True
            Chk_Mostrar_Solo_Productos_A_Comprar.Checked = True

            Dim _Generar_OCC As New GeneraOccAuto.Generar_Doc_Auto

            Dim _CodEntidad As String = _RowProveedor.Item("KOEN")
            Dim _SucEntidad As String = _RowProveedor.Item("SUEN")
            '    Dim _FechaUltCompra As DateTime = _Fila.Item("FechaUltCompra")

            Sb_Genarar_OCC_Automaticas_Por_Proveedor(_CodEntidad, _SucEntidad, _Generar_OCC)

            For Each _Fl As GeneraOccAuto.Doc_Auto In _Generar_OCC.Doc_Auto

                Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Demonio_AcpAuto (NombreEquipo,Modalidad,Idmaeedo,Tido,Nudo,FechaEmision,Informacion,ErrorGrabar) Values " &
                               "('" & _NombreEquipo & "','" & _Modalidad_Estudio & "'," & _Fl.Idmaeedo & ",'" & _Fl.Tido & "','" & _Fl.Nudo & "'" &
                               ",'" & Format(_Fl.Feemdo, "yyyyMMdd") & "','" & NuloPorNro(_Fl.MensajeError, "") & "'," & Convert.ToInt32(_Fl.ErrorGrabar) & ")"
                _Sql.Ej_consulta_IDU(Consulta_sql)

                '_Generar_OCC.Fx_Enviar_Notificacion_Correo_Al_Diablito(_Fl.Idmaeedo, _Fl.Email, Auto_CorreoCc, Auto_Id_Correo, Auto_NombreFormato_PDF)
                ' 37
                ' "Tam. Carta"
                MessageBoxEx.Show(Me, "Tido: " & _Fl.Tido & "-" & _Fl.Nudo & vbCrLf &
                                  "Email: " & _Fl.Email, "OCC Generada", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Next

            Me.Close()

        End If

        If Auto_GenerarAutomaticamenteNVI Then

            Call BtnProceso_Prov_Auto_Click(Nothing, Nothing)

            BtnProceso_Prov_Auto.Enabled = False

            Chk_Restar_Stok_Bodega.Checked = True
            Chk_Quitar_Bloqueados_Compra.Checked = True
            Chk_No_Considera_Con_Stock_Pedido_OCC_NVI.Checked = True
            Chk_Mostrar_Solo_Productos_A_Comprar.Checked = True
            Chk_Mostrar_Solo_a_Comprar_Cant_Mayor_Cero.Checked = True
            Chk_Quitar_Comprados.Checked = True
            Chk_Mostrar_Solo_Stock_Critico.Checked = True
            Chk_Quitar_Ventas_Calzadas.Checked = True
            Chk_Quitare_Sospechosos_Stock.Checked = True


            Sb_Refrescar_Grilla_Principal(Fm_Hijo.Grilla, False, False)

            Dim _Generar_NVI As New GeneraOccAuto.Generar_Doc_Auto

            Sb_Estudio_NVI_Auto(_Generar_NVI)

            For Each _Fl As GeneraOccAuto.Doc_Auto In _Generar_NVI.Doc_Auto

                Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Demonio_AcpAuto (NombreEquipo,Modalidad,Idmaeedo,Tido,Nudo,FechaEmision,Informacion,ErrorGrabar) Values " &
                               "('" & _NombreEquipo & "','" & _Modalidad_Estudio & "'," & _Fl.Idmaeedo & ",'" & _Fl.Tido & "','" & _Fl.Nudo & "'" &
                               ",'" & Format(_Fl.Feemdo, "yyyyMMdd") & "','" & NuloPorNro(_Fl.MensajeError, "") & "'," & Convert.ToInt32(_Fl.ErrorGrabar) & ")"
                _Sql.Ej_consulta_IDU(Consulta_sql)

                _Generar_NVI.Fx_Enviar_Notificacion_Correo_Al_Diablito(_Fl.Idmaeedo, _Fl.Email, Auto_CorreoCc, Auto_Id_Correo, Auto_NombreFormato_PDF)

                MessageBoxEx.Show(Me, "Tido: " & _Fl.Tido & "-" & _Fl.Nudo & vbCrLf &
                                  "Email: " & _Fl.Email, "NVI Generada", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Next

            Me.Close()

        End If

    End Sub

    Private Sub Btn_PorcUltCompXProv_Click(sender As Object, e As EventArgs) Handles Btn_PorcUltCompXProv.Click

        Dim _Proceso_Realizado As Boolean

        Dim Fm As New Frm_10_Asis_Compra_Ult3OCCxProv()
        Fm.ShowDialog(Me)
        _Proceso_Realizado = Fm.Proceso_Realizado
        Fm.Dispose()

        If _Proceso_Realizado Then
            Call Btn_Actualizar_Informe_Click(Nothing, Nothing)
        End If

    End Sub

    Private Sub BtnProceso_Prov_Auto_Especial_Click(sender As Object, e As EventArgs) Handles BtnProceso_Prov_Auto_Especial.Click

        Dim _CodProveedor_Pstar As String '= "76590920"
        Dim _CodSucProveedor_Pstar As String '= String.Empty

        Dim _EmpPstar As String
        Dim _SucPstar As String
        Dim _BodPstar As String

        Dim _Id = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Tmp_Prm_Informes",
                                                 "Valor",
                                                 "Informe = 'Compras_Asistente' And Campo = 'Txt_DbExt_Nombre_Conexion' And NombreEquipo = '" & _NombreEquipo & "' " &
                                                 "And Funcionario = '" & FUNCIONARIO & "' And Modalidad = '" & _Modalidad_Estudio & "'")

        _CodProveedor_Pstar = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Tmp_Prm_Informes",
                                                 "Valor",
                                                 "Informe = 'Compras_Asistente' And Campo = 'Koen_Especial' And NombreEquipo = '" & _NombreEquipo & "' " &
                                                 "And Funcionario = '" & FUNCIONARIO & "' And Modalidad = '" & _Modalidad_Estudio & "'")
        _CodSucProveedor_Pstar = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Tmp_Prm_Informes",
                                                    "Valor",
                                                    "Informe = 'Compras_Asistente' And Campo = 'Suen_Especial' And NombreEquipo = '" & _NombreEquipo & "' " &
                                                    "And Funcionario = '" & FUNCIONARIO & "' And Modalidad = '" & _Modalidad_Estudio & "'")

        Consulta_sql = "Select * From MAEEN Where KOEN = '" & _CodProveedor_Pstar & "' And SUEN = '" & _CodSucProveedor_Pstar & "'"
        _RowProveedor = _Sql.Fx_Get_DataRow(Consulta_sql)

        If IsNothing(_RowProveedor) Then
            MessageBoxEx.Show(Me, "No esta asignado el proveedore especial para estos fines" & vbCrLf & vbCrLf &
                              "Revise la pestaña [Bod.Ext. Prov. Especial] en la configuración anterior.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_DbExt_Maest Where Id_Conexion = " & Val(_Id)
        Dim _RowDbExt_Maest As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        If Not IsNothing(_RowDbExt_Maest) Then
            _EmpPstar = _RowDbExt_Maest.Item("Empresa_Des")
            _SucPstar = _RowDbExt_Maest.Item("Sucursal_Des")
            _BodPstar = _RowDbExt_Maest.Item("Bodega_Des")
        End If

        Consulta_sql = "Update " & _Nombre_Tbl_Paso_Informe & " Set CodProveedor = '',CodSucProveedor = ''"
        _Sql.Ej_consulta_IDU(Consulta_sql)

        Consulta_sql = "Update " & _Nombre_Tbl_Paso_Informe & " Set StockUd1BodStar = StfiBodExt1,StockUd2BodStar = StfiBodExt2" & vbCrLf &
                       "From " & _Nombre_Tbl_Paso_Informe & " Tbps" & vbCrLf &
                       "Inner Join " & _Global_BaseBk & "Zw_Prod_Stock TbSt On " &
                       "TbSt.Empresa = '" & _EmpPstar & "' And TbSt.Sucursal = '" & _SucPstar & "' And TbSt.Bodega = '" & _BodPstar & "' And Tbps.Codigo = TbSt.Codigo" & vbCrLf &
                       "Where Comprar = 1 And (StfiBodExt1+StfiBodExt2) > 0"
        _Sql.Ej_consulta_IDU(Consulta_sql)

        Consulta_sql = "Update " & _Nombre_Tbl_Paso_Informe & " Set CantComprar = Case When StockUd1BodStar > CantSugeridaTot then CantSugeridaTot Else StockUd1BodStar End" & vbCrLf &
                       "Where StockUd1BodStar > 0"
        _Sql.Ej_consulta_IDU(Consulta_sql)

        Consulta_sql = "Update " & _Nombre_Tbl_Paso_Informe & Space(1) &
                       "Set CodProveedor = '" & _CodProveedor_Pstar & "'" & vbCrLf &
                       ",CodSucProveedor = '" & _CodSucProveedor_Pstar & "'" & vbCrLf &
                       "Where Comprar = 1 And CantComprar > 0 And StockUd1BodStar >= CantComprar"
        _Sql.Ej_consulta_IDU(Consulta_sql)

        Consulta_sql = "Delete " & _Nombre_Tbl_Paso_Informe & " Where CodProveedor = '' And CodSucProveedor = ''"
        _Sql.Ej_consulta_IDU(Consulta_sql)

        BtnProceso_Prov_Auto_Especial.Enabled = False
        BtnProceso_Prov_Auto.Enabled = False

        Call Btn_Actualizar_Informe_Click(Nothing, Nothing)

    End Sub

    Sub Txt_Codigo_KeyDown(sender As Object, e As KeyEventArgs)

        Dim _Buscar As Boolean
        If e.KeyValue = Keys.Enter Then
            _Buscar = True
        ElseIf e.KeyValue = Keys.Back Then
            If Fm_Hijo.Txt_Codigo.Text = String.Empty Then _Buscar = True
        End If

        If _Buscar Then
            Sb_Buscar_X_Codigo()
        End If
    End Sub

    Function Sb_Genarar_OCC_Automaticas_Por_Proveedor(_CodEntidad As String, _SucEntidad As String, ByRef _Generar_OCC As GeneraOccAuto.Generar_Doc_Auto)

        _RowProveedor = Fx_Traer_Datos_Entidad(_CodEntidad, _SucEntidad)

        Sb_Grilla_Actualizar_Informe(Fm_Hijo.Grilla)
        Sb_Grilla_Marcar(Fm_Hijo.Grilla, False)

        Fm_Hijo.Btn_Quitar_Filtro_Proveedor.Enabled = True
        Btn_Quitar_Filtro_Proveedor_Ribon.Enabled = True
        Fm_Hijo.Chk_Ver_Doc_Solo_Proveedor.Enabled = True

        '_Generar_OCC.OccGeneradas = True

        Dim _Occ_Auto As New GeneraOccAuto.Doc_Auto

        If CBool(Fm_Hijo.Grilla.RowCount) Then

            _Occ_Auto = Fx_Crear_OCC_Auto()

            _Generar_OCC.Doc_Auto.Add(_Occ_Auto)

            Sb_Refrescar_Grilla_Principal(Fm_Hijo.Grilla, False, False)

            If CBool(Fm_Hijo.Grilla.RowCount) Then
                Sb_Genarar_OCC_Automaticas_Por_Proveedor(_CodEntidad, _SucEntidad, _Generar_OCC)
            End If

        End If

    End Function

    Function Fx_Crear_OCC_Auto() As GeneraOccAuto.Doc_Auto

        Dim _Occ_Auto As New GeneraOccAuto.Doc_Auto

        Dim _Endo, _Suendo As String
        Dim _Endofi, _Suendofi As String
        Dim _Koen, _Suen As String

        Dim _Row_Entidad As DataRow
        Dim _Row_Entidad_Fisica As DataRow

        If Chk_Ent_Fisica.Checked Then

            _Endofi = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Tmp_Prm_Informes", "Valor",
                                        "Funcionario = '" & FUNCIONARIO & "' AND Campo = 'Koen' AND Informe = 'Compras_Asistente'")
            _Suendofi = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Tmp_Prm_Informes", "Valor",
                                        "Funcionario = '" & FUNCIONARIO & "' AND Campo = 'Suen' AND Informe = 'Compras_Asistente'")

        End If

        Dim _Todos_Los_Proveedores As Boolean

        If Not _Rdb_Productos_Proveedor Then
            _Todos_Los_Proveedores = True
        End If

        If _Todos_Los_Proveedores Then

            If (_RowProveedor Is Nothing) Then

                MessageBoxEx.Show(Me, "Debe seleccionar el proveedor en filtrar proveedor",
                                  "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return _Occ_Auto

                Dim Fm1 = New Frm_04_Asis_Compra_Proveedores(Frm_04_Asis_Compra_Proveedores.TipoBusqueda.Proveedores_Seleccionados, "", True)
                Fm1.ShowDialog(Me)

                If Not (Fm1.Pro_RowProveedor Is Nothing) Then
                    _Koen = Fm1.Pro_RowProveedor.Item("KOEN")
                    _Suen = Fm1.Pro_RowProveedor.Item("SUEN")
                Else
                    Return _Occ_Auto
                End If
            Else
                _Koen = _RowProveedor.Item("KOEN")
                _Suen = _RowProveedor.Item("SUEN")
            End If

        End If

        If Chk_Ent_Fisica.Checked Then

            If _Todos_Los_Proveedores Then
                _Endofi = Trim(_Koen)
                _Suendofi = Trim(_Suen)
            Else
                'CodEntidadFisica = NuloPorNro(Fila_.Item("CodEntidadSel"), "")
                'CodSucEntidadFisica = NuloPorNro(Fila_.Item("SucEntidadSel"), "")
            End If

            MessageBoxEx.Show(Me, "Debe seleccionar un proveedor para generar la orden de compra, " &
                              "ya que está marcada la opción entidad física", "Seleccionar proveedor",
                              MessageBoxButtons.OK, MessageBoxIcon.Information)

            Dim FmBe As New Frm_BuscarEntidad_Mt(False)
            FmBe.ShowDialog(Me)

            If FmBe.Pro_Entidad_Seleccionada Then

                _Endo = Trim(FmBe.Pro_RowEntidad.Item("KOEN"))
                _Suendo = Trim(FmBe.Pro_RowEntidad.Item("SUEN"))

                _Koen = _Endo
                _Suen = _Suendo

            Else
                MessageBoxEx.Show("No se seleccionó ningún proveedor para realizar la Orden de compra",
                                  "Falta proveedor", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return _Occ_Auto
            End If

        Else
            If Not _RowProveedor Is Nothing Then
                _Koen = _RowProveedor.Item("KOEN")
                _Suen = _RowProveedor.Item("SUEN")
            End If
        End If

        _Occ_Auto.Endo = _Koen
        _Occ_Auto.Suendo = _Suen

        Consulta_sql = "Select Top 1 *,KOEN AS ENDO, SUEN AS SUENDO From MAEEN" & vbCrLf &
                       "Where KOEN = '" & _Koen & "' And SUEN = '" & _Suen & "'"
        _Row_Entidad = _Sql.Fx_Get_DataRow(Consulta_sql)

        Consulta_sql = "Select Top 1 *,KOEN AS ENDO, SUEN AS SUENDO From MAEEN" & vbCrLf &
                       "Where KOEN = '" & _Endofi & "' And SUEN = '" & _Suendofi & "'"
        _Row_Entidad_Fisica = _Sql.Fx_Get_DataRow(Consulta_sql)

        Dim _CodProveedor As String = _Koen
        Dim _CodSucProveedor As String = _Suen

        If Chk_Ent_Fisica.Checked Then
            _CodProveedor = _Endofi
            _CodSucProveedor = _Suendofi
        End If

        Consulta_sql = My.Resources.Recursos_Asis_Compras.SQLQuery_Actualizar_Costos_en_Lista_de_Proveedores
        Dim _ElistaCom As String = Mid(_Global_Row_Configuracion_Estacion.Item("ELISTACOM"), 6, 3)

        Consulta_sql = Replace(Consulta_sql, "#Lista#", _ElistaCom)
        Consulta_sql = Replace(Consulta_sql, "#Entidad#", _CodProveedor)
        Consulta_sql = Replace(Consulta_sql, "#Sucursal#", "")
        Consulta_sql = Replace(Consulta_sql, "Zw_InfCompras", _Nombre_Tbl_Paso_Informe)
        Consulta_sql = Replace(Consulta_sql, "Zw_ListaPreCosto", _Global_BaseBk & "Zw_ListaPreCosto")

        _Sql.Ej_consulta_IDU(Consulta_sql)

        Dim _RowFormato As DataRow = Fx_Formato_Modalidad(Me, _Modalidad_Estudio, "OCC", True)
        Dim _NroLineasXpag As Integer = _RowFormato.Item("NroLineasXpag")

        Dim _Largo_Variable As Boolean = _RowFormato.Item("Largo_Variable")
        Dim _Registros As Integer = Fm_Hijo.Grilla.Rows.Count

        Dim _Top = String.Empty

        If _Largo_Variable Then
            If Not CBool(_NroLineasXpag) Then
                _NroLineasXpag = 500
            End If
        End If

        If _NroLineasXpag > 0 Then _Top = "Top " & _NroLineasXpag

        'Dim _Ud As Integer
        'If Rdb_Ud1_Compra.Checked Then : _Ud = 1 : Else : _Ud = 2 : End If

        Dim _Condicion As String = String.Empty


        If Chk_Mostrar_Solo_Stock_Critico.Checked Then
            _Condicion += "And Con_Stock_CriticoUd" & Ud & " = 1" & vbCrLf
        End If

        If Chk_No_Considera_Con_Stock_Pedido_OCC_NVI.Checked Then
            _Condicion += "And StockPedidoUd" & Ud & " = 0" & vbCrLf
        End If

        If Chk_Mostrar_Solo_a_Comprar_Cant_Mayor_Cero.Checked Then
            _Condicion += "And CantComprar > 0" & vbCrLf
        End If

        If Chk_Quitar_Comprados.Checked Then
            _Condicion += "And OccGenerada = 0" & vbCrLf
        End If

        If Chk_Mostrar_Solo_Productos_A_Comprar.Checked Then
            _Condicion += "And Comprar = 1" & vbCrLf
        End If

        If Chk_Quitar_Ventas_Calzadas.Checked Then
            _Condicion += "And Refleo = 0" & vbCrLf
        End If

        If Chk_Quitare_Sospechosos_Stock.Checked Then
            _Condicion += "And Sospecha_Baja_Rotacion = 0" & vbCrLf
        End If

        Dim _Orden_Codigo As String

        If Fm_Hijo.Grilla.SortOrder = Windows.Forms.SortOrder.Ascending Then
            _Orden_Codigo = Fm_Hijo.Grilla.SortedColumn.Name
        ElseIf Fm_Hijo.Grilla.SortOrder = Windows.Forms.SortOrder.Descending Then
            _Orden_Codigo = Fm_Hijo.Grilla.SortedColumn.Name & " Desc"
        Else
            _Orden_Codigo = "Codigo"
        End If

        If Rd_Costo_Lista_Proveedor.Checked Then

            Dim _Lista As String = Cmb_Lista_Costos.SelectedItem.Value

            Consulta_sql = "Select 0 As IDMAEEDO,Getdate() As FEEMDO,Getdate() As FEER

                            Select Distinct " & _Top & " '" & FUNCIONARIO & "' As KOFULIDO,Tb.Codigo As KOPRCT,Tb.Descripcion As NOKOPR,
                            Tb.Descripcion as Descripcion,Tb.CodAlternativo,'" & _Lista & "' As KOLTPR,UD1,UD2,
                            0 As CostoUd1,0 As CostoUd2,0 As Precio, Tb.Rtu,CantComprar As Cantidad,
                            0 As Desc1,0 As Desc2,0 As Desc3,0 As Desc4,0 As Desc5,0 As DescSuma,0 As PRCT,'' As TICT,TIPR,0 As PODTGLLI," & Ud & " as UDTRPR,
                            Isnull(Trc.RECARGO,0) As POTENCIA,'' As KOFUAULIDO,'' As KOOPLIDO,
                            0 As IDMAEEDO,0 As IDMAEDDO,'" & ModEmpresa & "' As EMPRESA,'" & ModSucursal & "' As SULIDO,'" & ModBodega & "' As BOSULIDO,'' As ENDO,'' As SUENDO,GetDate() As FEEMLI,
                            '' As TIDO,'' As NUDO,'' As NULIDO,0 As CantUd1_Dori,0 As CantUd2_Dori,'' As OBSERVA,
                            0 As Id_Oferta,'' As Oferta,0 As Es_Padre_Oferta,0 As Padre_Oferta,
							0 As Hijo_Oferta,0 As Cantidad_Oferta,0 As Porcdesc_Oferta

                            From  " & _Nombre_Tbl_Paso_Informe & " Tb

                            Inner Join TABCODAL Tcl On Tcl.KOEN = Tb.CodProveedor And Tb.Codigo = Tcl.KOPR And Tcl.KOPRAL = Tb.CodAlternativo
                                Left Join TABRECPR Trc On Trc.KOEN = Tb.CodProveedor and Trc.KOPR = Tb.Codigo
                                    Inner Join MAEPR Mp On Mp.KOPR = Tb.Codigo
                                        Where Tb.CantComprar > 0 And Tb.CodSucProveedor = '" & _Suen & "'
                                            And Tb.CodProveedor = '" & _Koen & "' And Tb.OccGenerada = 0 And Comprar = 1
                            " & _Condicion & vbCrLf &
                            "Order by " & _Orden_Codigo & "
                             Select * From MAEIMLI Where 1<0  
                                 Select * From MAEDTLI Where 1 < 0 
                                 Select 'Documento generado desde Asistente de compras BakApp' as OBDO"

        ElseIf Rd_Costo_Ultimo_Documento_Seleccionado.Checked Then

            '[Costo_Compra_RealUd1]     [float]       DEFAULT (0),
            '[Costo_Compra_RealUd2]     [float]       DEFAULT (0),
            '[Costo_Compra]             [float]       DEFAULT (0),
            '[Dscto_Compra]             [float]       DEFAULT (0),

            Consulta_sql = "Select 0 As IDMAEEDO,Getdate() As FEEMDO,Getdate() As FEER" &
                            vbCrLf &
                           "Select Distinct " & _Top & " '" & FUNCIONARIO & "' As KOFULIDO,Codigo As KOPRCT,
                            Descripcion,Descripcion As NOKOPR,CodAlternativo,'" & ModListaPrecioCosto & "' As KOLTPR,UD1,UD2,
                            Costo_Ult_Compra as CostoUd1,Costo_Ult_Compra as CostoUd2,
                            Costo_Ult_Compra As Precio,Rtu,CantComprar As Cantidad,Dscto_Ult_Compra as Desc1,
                            0 as Desc2,0 as Desc3,0 as Desc4,0 as Desc5,0 As PRCT,'' As TICT,TIPR," & Ud & " as UDTRPR,0 as POTENCIA,'' As KOFUAULIDO,'' As KOOPLIDO,
                            0 As IDMAEEDO,0 As IDMAEDDO,'" & ModEmpresa & "' As EMPRESA,'" & ModSucursal & "' As SULIDO,'" & ModBodega & "' As BOSULIDO,
                            '' As ENDO,'' As SUENDO,
                            GetDate() As FEEMLI,'' As TIDO,'' As NUDO,'' As NULIDO,0 As CantUd1_Dori,0 As CantUd2_Dori,'' As OBSERVA,
                            0 As Id_Oferta,'' As Oferta,0 As Es_Padre_Oferta,0 As Padre_Oferta,
							0 As Hijo_Oferta,0 As Cantidad_Oferta,0 As Porcdesc_Oferta
                            From " & _Nombre_Tbl_Paso_Informe & "
                            Inner Join MAEPR Mp On Mp.KOPR = Codigo
                            Where
                            CantComprar > 0 And CodProveedor = '" & Trim(_CodProveedor) & "' And CodSucProveedor = '" & Trim(_CodSucProveedor) & "'
                            And OccGenerada = 0 And Comprar = 1" & vbCrLf &
                            _Condicion & vbCrLf & " 
                            Order by " & _Orden_Codigo & " 
                            Select * From MAEIMLI Where 1<0  
                            Select * From MAEDTLI Where 1<0  
                            Select 'Documento generado desde Asistente de compras BakApp' as OBDO"

        End If

        Dim _Ds_New_Documento As DataSet = _Sql.Fx_Get_DataSet(Consulta_sql)


        Dim _TblDetalle As DataTable = _Ds_New_Documento.Tables(1)

        If _TblDetalle.Rows.Count Then

            Me.Enabled = False

            Dim _New_Idmaeedo As Integer

            Dim Fm_Espera As New Frm_Form_Esperar
            Fm_Espera.Pro_Texto = "Armando orden de compra" & vbCrLf & "por favor espere..."
            Fm_Espera.BarraCircular.IsRunning = True
            Fm_Espera.Show(Me)

            Dim Fm_Post As New Frm_Formulario_Documento("OCC", csGlobales.Enum_Tipo_Documento.Compra, False, True, False)

            Fm_Post.Pro_Agrupar_Reemplazos = Chk_Traer_Productos_De_Reemplazo.Checked
            Fm_Post.Pro_RowEntidad = _Row_Entidad
            Fm_Post.Pro_RowEntidad_Despacho = _Row_Entidad_Fisica
            Fm_Post.Pro_Lista_de_precios_de_proveedores = Rd_Costo_Lista_Proveedor.Checked
            Fm_Post.Sb_Crear_Documento_Desde_Otros_Documentos(Me, _Ds_New_Documento, True, False, Nothing, False, False)

            Fm_Post.MinimizeBox = False

            Fm_Espera.Close()
            Fm_Espera.Dispose()

            'Fm_Post.Sb_Grabar_Documento(_New_Idmaeedo, False)
            Fm_Post.Fx_Grabar_Documento(False, csGlobales.Mod_Enum_Listados_Globales.Enum_Tipo_de_Grabacion.Nuevo_documento)
            _New_Idmaeedo = Fm_Post.Pro_Idmaeedo
            Fm_Post.Dispose()

            Me.Enabled = True

            If CBool(_New_Idmaeedo) Then

                _Occ_Auto.Idmaeedo = _New_Idmaeedo
                _Occ_Auto.Email = Trim(_Sql.Fx_Trae_Dato("MAEEN", "EMAILCOMER", "KOEN = '" & _Koen & "' And SUEN = '" & _Suen & "'"))
                _Occ_Auto.Tido = "OCC"
                _Occ_Auto.Nudo = _Sql.Fx_Trae_Dato("MAEEDO", "NUDO", "IDMAEEDO = " & _New_Idmaeedo)
                _Occ_Auto.Feemdo = _Sql.Fx_Trae_Dato("MAEEDO", "FEEMDO", "IDMAEEDO = " & _New_Idmaeedo)

                Consulta_sql = "Update " & _Global_BaseBk & "Zw_Prod_Log_Compras Set" & vbCrLf &
                               "Idmaeedo_Ult_occ = " & _New_Idmaeedo & "," &
                               "Fecha_Ult_occ = GetDate()" & vbCrLf &
                               "From " & _Nombre_Tbl_Paso_Informe & " Tpaso" & vbCrLf &
                               "Inner Join " & _Global_BaseBk & "Zw_Prod_Log_Compras Zlog On Tpaso.Codigo = Zlog.Codigo" & vbCrLf &
                               "Where NombreEquipo = '" & _NombreEquipo & "'" & Space(1) &
                               "And CodFuncionario = '" & FUNCIONARIO & "'" & Space(1) &
                               "And Tpaso.Codigo In (Select KOPRCT From MAEDDO Where IDMAEEDO = " & _New_Idmaeedo & ")"
                _Sql.Ej_consulta_IDU(Consulta_sql)

                Dim _Codigo As String

                Consulta_sql = "Select KOPRCT From MAEDDO Where IDMAEEDO = " & _New_Idmaeedo
                Dim _Tb As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

                If CBool(_Tb.Rows.Count) Then
                    For Each Fila As DataRow In _Tb.Rows

                        _Codigo = Fila.Item("KOPRCT")

                        Consulta_sql += "Update " & _Nombre_Tbl_Paso_Informe & vbCrLf &
                                       "Set OccGenerada = 1,IdOCC = " & _New_Idmaeedo & vbCrLf &
                                       "Where Codigo = '" & _Codigo & "'" & vbCrLf &
                                       "And CodProveedor = '" & _Koen & "' And CodSucProveedor = '" & _Suen & "'" & vbCrLf

                    Next

                    If Not String.IsNullOrEmpty(Consulta_sql) Then
                        _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql)
                    End If
                Else
                    MessageBoxEx.Show(Me, "No se encontro la orden de compra en el sistema", "Error inesperado",
                                      MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If


            End If

            If Chk_Ent_Fisica.Checked Then
                _Koen = _Endofi
                _Suen = _Suendofi
            End If

        Else
            MessageBoxEx.Show(Me, "No existen productos seleccionados para comprar desde el tratamiento",
                              "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)

        End If

        Return _Occ_Auto

    End Function

    Sub Sb_Estudio_NVI_Auto(ByRef _Generar_NVI As GeneraOccAuto.Generar_Doc_Auto)

        Dim _Bod_Solicita As String
        Dim _Tbl_Productos As DataTable

        If _TblBodCompra.Rows.Count = 1 Then

            _Bod_Solicita = _TblBodCompra.Rows(0).Item("Codigo")

            Dim _Emp_Recep = Mid(_Bod_Solicita, 1, 2)
            Dim _Suc_Recep = Mid(_Bod_Solicita, 3, 3)
            Dim _Bod_Recep = Mid(_Bod_Solicita, 6, 3)

            Dim _Sql_Filtro_Condicion_Extra = "And KOBO <> '" & _Bod_Recep & "'"

            Dim _Filtrar As New Clas_Filtros_Random(Me)

            Dim _TblPaso As String = "Tbl_PasoSolBod" & FUNCIONARIO.Trim

            _Sql.Sb_Eliminar_Tabla_De_Paso(_TblPaso)

            Consulta_sql = "CREATE TABLE [dbo].[" & _TblPaso & "](
                         [Id]					[int] IDENTITY(1,1) NOT NULL,
                         [Empresa]				[varchar](2)        NOT NULL DEFAULT (''),
                         [Sucursal]				[varchar](3)        NOT NULL DEFAULT (''),
                         [Bodega]				[varchar](3)        NOT NULL DEFAULT (''),
                         [Codigo]				[char](13)          NOT NULL DEFAULT (''),
                         [Descripcion]			[varchar](50)       NOT NULL DEFAULT (''),
                         [Codigo_Nodo]			[int]               NOT NULL DEFAULT (0),
                         [Costo]	            [float]             NOT NULL DEFAULT (0),
                         [Stock_Fisico_Madre]	[float]             NOT NULL DEFAULT (0),
                         [Stock_Fisico_Prod]	[float]             NOT NULL DEFAULT (0),
                         [Stock_Disponible]		[float]             NOT NULL DEFAULT (0),
                         [Stock_CriticoUd1_Rd]	[float]             NOT NULL DEFAULT (0),
                         [CantComprar]			[float]             NOT NULL DEFAULT (0),
                         [TStock]				[float]             NOT NULL DEFAULT (0),
                         [RotDiariaUd1]			[float]             NOT NULL DEFAULT (0),
                         [RotMensualUd1]		[float]             NOT NULL DEFAULT (0),
                         [Dias]					[int]               NOT NULL DEFAULT (0),
                         [Solicitar]			[float]             NOT NULL DEFAULT (0),
                         [Pedir]				[float]             NOT NULL DEFAULT (0),
                         [Pedir_Hnos]			[float]             NOT NULL DEFAULT (0),
                         [Observacion]			[varchar](50)       NOT NULL DEFAULT (''),
                         [NVI]       			[varchar](10)       NOT NULL DEFAULT (''),
                         [Idmaeedo]     		[int]               NOT NULL DEFAULT (0),
                         [Ubicacion]    		[varchar](20)       NOT NULL DEFAULT (''),
                         [NVI_Pendientes]     	[varchar](1000)     NOT NULL DEFAULT (''),
                         [Fecha_Ult_Venta]      [Datetime],
                            ) ON [PRIMARY]"

            _Sql.Ej_consulta_IDU(Consulta_sql)

            Consulta_sql = "Select Chk,Codigo,Descripcion From " & _Global_BaseBk & "Zw_Tmp_Filtros_Busqueda" & vbCrLf &
                           "Where Funcionario = '" & FUNCIONARIO & "' And Informe = 'Compras_Asistente'" & Space(1) &
                           "And Filtro = 'Bodegas_Reabastecen' And NombreEquipo = '" & _NombreEquipo & "' And Modalidad = '" & _Modalidad_Estudio & "'"
            Dim _TblBodReabastecen As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)


            If CBool(_TblBodReabastecen.Rows.Count) Then

                _Sql.Sb_Actualizar_Filtro_Tmp(_TblBodReabastecen, "Compras_Asistente", "Bodegas_Reabastecen", _Modalidad_Estudio)

                Dim Fm_Espera As New Frm_Form_Esperar
                Fm_Espera.Pro_Texto = "Haciendo analisis en las bodegas internas. Por favor espere..."
                Fm_Espera.BarraCircular.IsRunning = True
                Fm_Espera.Show(Me)

                Try
                    Me.Enabled = False

                    For Each _FlBodegas As DataRow In _TblBodReabastecen.Rows

                        Dim _Bod_Codigo = _FlBodegas.Item("Codigo")
                        Dim _Bod_Descripcion = _FlBodegas.Item("Descripcion")

                        Dim _Emp = Trim(Mid(_Bod_Codigo, 1, 2))
                        Dim _Suc = Trim(Mid(_Bod_Codigo, 3, 3))
                        Dim _Bod = Trim(Mid(_Bod_Codigo, 6, 3))

                        Fx_Productos_A_Solicitar_Otras_Bodegas(_Emp, _Suc, _Bod, _TblPaso)

                    Next

                    Consulta_sql = "Select * Into #Paso1 From " & _TblPaso & " Z1 Where Solicitar = CantComprar And (Select Count(*) From " & _TblPaso & " Z2 Where Z1.Codigo = Z2.Codigo) > 1 Order By Codigo_Nodo
                                    Select * Into #Paso2 From " & _TblPaso & " Z1 Where Solicitar < CantComprar And (Select Count(*) From " & _TblPaso & " Z2 Where Z1.Codigo = Z2.Codigo) > 1 And Codigo In (Select Codigo From #Paso1)

                                    Delete " & _TblPaso & " Where Id In (Select Id From #Paso2)
                                    Drop Table #Paso1"

                    _Sql.Ej_consulta_IDU(Consulta_sql)

                    Consulta_sql = "Select Distinct Empresa,Sucursal,Bodega From " & _TblPaso & " Z1 Where (Select Count(*) From " & _TblPaso & " Z2 Where Z1.Codigo = Z2.Codigo) > 1"
                    Dim _TblProdAmbasBodegas As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

                    If CBool(_TblProdAmbasBodegas.Rows.Count) Then

                        For Each _FlBodegas As DataRow In _TblProdAmbasBodegas.Rows

                            Dim _Emp = _FlBodegas.Item("Empresa")
                            Dim _Suc = _FlBodegas.Item("Sucursal")
                            Dim _Bod = _FlBodegas.Item("Bodega")

                            Consulta_sql = "Delete " & _TblPaso & "
                                            Where Id In (Select Id From " & _TblPaso & " Z1  Where Empresa = '" & _Emp & "' And Sucursal = '" & _Suc & "' And Bodega = '" & _Bod & "' And (Select Count(*) From " & _TblPaso & " Z2 Where Z1.Codigo = Z2.Codigo) > 1) "
                            _Sql.Ej_consulta_IDU(Consulta_sql)
                        Next

                    End If

                    Fm_Espera.Close()

                    Consulta_sql = "Select * From " & _TblPaso
                    _Tbl_Productos = _Sql.Fx_Get_Tablas(Consulta_sql)

                    If Not CBool(_Tbl_Productos.Rows.Count) Then
                        MessageBoxEx.Show(Me, "No se encontraron productos en otras bodegas", "Reabastecimiento entre bodegas",
                                      MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Return
                    End If

                    If CBool(_Tbl_Productos.Rows.Count) Then

                        Dim _Filtro_Codigos_Madre = Generar_Filtro_IN(_Tbl_Productos, "", "Codigo_Nodo", False, False, "")
                        Dim _Filtro_Pro As String = Generar_Filtro_IN(_Tbl_Productos, "", "Codigo", False, False, "'")

                        Consulta_sql = "
                                Select Codigo 
                                Into #Paso
                                From " & _Global_BaseBk & "Zw_Prod_Asociacion 
                                Where Codigo_Nodo In " & _Filtro_Codigos_Madre & " And Para_filtro = 1

                                Insert Into #Paso (Codigo)
                                Select KOPR From MAEPR
                                Where KOPR In " & _Filtro_Pro & "

                                Select KOPR As Codigo,'',NOKOPR,UD01PR,UD02PR,RLUD,CLALIBPR,RUPR,MRPR,ZONAPR,FMPR,PFPR,HFPR,BLOQUEAPR,ATPR
                                FROM MAEPR
                                Where KOPR In (Select Distinct Codigo From #Paso)

                                Drop Table #Paso"

                        Dim _TblProductos_Con_Reemplazo As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

                        Dim _Filtro_Productos As String = Generar_Filtro_IN(_TblProductos_Con_Reemplazo, "", "Codigo", False, False, "'")

                        Dim Fm2 As New Frm_Consolidacion_Stock_PP(_Filtro_Productos)
                        Fm2.Pro_Ejecutar_Automaticamente = True
                        Fm2.ShowDialog(Me)
                        Fm2.Dispose()

                    End If

                    Fm_Espera = New Frm_Form_Esperar
                    Fm_Espera.Pro_Texto = "Haciendo analisis en las bodegas. Por favor espere..."
                    Fm_Espera.BarraCircular.IsRunning = True
                    Fm_Espera.Show(Me)

                    Dim _Tbl_Productos_Copy As DataTable = _Tbl_Productos.Copy()

                    ' Hay que ir incrementando e ir poniendo los productos hermanos para pedir, se deben pedir los que tengan stock suficiente...

                    For Each _Fila As DataRow In _Tbl_Productos_Copy.Rows

                        Dim _Emp_Reab As String = _Fila.Item("Empresa")
                        Dim _Suc_Reab As String = _Fila.Item("Sucursal")
                        Dim _Bod_Reab As String = _Fila.Item("Bodega")
                        Dim _Codigo As String = _Fila.Item("Codigo")
                        Dim _Codigo_Nodo As Integer = _Fila.Item("Codigo_Nodo")
                        Dim _Stock_Fisico_Madre As Double = _Fila.Item("Stock_Fisico_Madre")
                        Dim _Stock_Fisico_Prod As Double = _Fila.Item("Stock_Fisico_Prod")
                        Dim _Stock_Disponible As Double = Fx_Stock_Disponible("FCV", ModEmpresa, _Suc_Reab, _Bod_Reab, _Codigo, _Ud, "STFI" & Ud)

                        Dim _Solicitar As Double = _Fila.Item("Solicitar")
                        Dim _Pedir As Double = _Fila.Item("Pedir")
                        Dim _Pedir_Hnos As Double = _Fila.Item("Pedir_Hnos")

                        Dim _Cant_Solicitada As Double = 0
                        Dim _Saldo As Double = _Pedir_Hnos

                        Consulta_sql = "Update " & _TblPaso & " Set Stock_Disponible = " & De_Num_a_Tx_01(_Stock_Disponible, False, 5) & " 
                                        Where Empresa = '" & _Emp_Reab & "' And Sucursal = '" & _Suc_Reab & "' And Bodega = '" & _Bod_Reab & "' And Codigo = '" & _Codigo & "'"
                        _Sql.Ej_consulta_IDU(Consulta_sql)

                        If CBool(_Pedir_Hnos) Then

                            Consulta_sql = "Select Mst.*,Mp.NOKOPR,Isnull(Mpe.PM,1) As PM 
                                                From MAEST Mst
                                                Left Join MAEPR Mp On Mp.KOPR = Mst.KOPR
                                                Left Join MAEPREM Mpe On Mpe.EMPRESA = '" & _Emp_Reab & "' And Mpe.KOPR = Mp.KOPR
                                            Where Mst.EMPRESA = '" & _Emp_Reab & "' And KOSU = '" & _Suc_Reab & "' And KOBO = '" & _Bod_Reab & "' 
                                            And Mst.KOPR In (Select Codigo From " & _Global_BaseBk & "Zw_Prod_Asociacion " &
                                            "Where Codigo_Nodo = " & _Codigo_Nodo & " And Para_filtro = 1) And Mst.KOPR <> '" & _Codigo & "'
                                        Order By Mst.STFI1 Desc"
                            Dim _Tbl_Hnos As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

                            For Each _Fila_H As DataRow In _Tbl_Hnos.Rows

                                Dim _Kopr As String = _Fila_H.Item("KOPR")
                                Dim _Nokopr As String = _Fila_H.Item("NOKOPR").ToString.Trim
                                Dim _Stfi As Double = _Fila_H.Item("STFI" & Ud)
                                _Stock_Disponible = Fx_Stock_Disponible("FCV", ModEmpresa, _Suc_Reab, _Bod_Reab, _Kopr, _Ud, "STFI" & Ud)
                                Dim _Costo As Double = _Fila_H.Item("PM")
                                Dim _Salir = False

                                'If _Kopr = "0928341001JPN" Then
                                '    Dim _as = "d"
                                'End If

                                If CBool(_Stock_Disponible) Then

                                    If _Stock_Disponible >= _Saldo Then
                                        _Pedir = _Saldo
                                        _Salir = True
                                    Else
                                        _Pedir = _Stock_Disponible
                                        _Saldo -= _Pedir
                                    End If

                                    Dim _Observacion As String = "Se pide por el producto (" & _Codigo.ToString.Trim & ")"

                                    Consulta_sql = "Insert Into " & _TblPaso & " (Empresa,Sucursal,Bodega,Codigo,Descripcion,Codigo_Nodo," &
                                                "Stock_Fisico_Madre,Stock_Fisico_Prod,Stock_Disponible,Solicitar,Pedir,Pedir_Hnos,Costo,Observacion,NVI,Idmaeedo,Ubicacion) Values " &
                                                "('" & _Emp_Reab & "','" & _Suc_Reab & "','" & _Bod_Reab & "','" & _Kopr & "','" & _Nokopr &
                                                "'," & _Codigo_Nodo &
                                                "," & De_Num_a_Tx_01(_Stock_Fisico_Madre, False, 5) &
                                                "," & De_Num_a_Tx_01(_Stfi, False, 5) &
                                                "," & De_Num_a_Tx_01(_Stock_Disponible, False, 5) &
                                                "," & De_Num_a_Tx_01(_Solicitar, False, 5) &
                                                "," & De_Num_a_Tx_01(_Pedir, False, 5) &
                                                "," & De_Num_a_Tx_01(_Pedir_Hnos, False, 5) &
                                                "," & De_Num_a_Tx_01(_Costo, False, 5) & ",'" & _Observacion & "','',0,'')"
                                    _Sql.Ej_consulta_IDU(Consulta_sql)

                                    If _Salir Then
                                        Exit For
                                    End If

                                End If

                            Next

                        End If

                    Next

                    Fm_Espera.Close()

                    Consulta_sql = "Select * From " & _TblPaso
                    _Tbl_Productos = _Sql.Fx_Get_Tablas(Consulta_sql)

                    For Each _Fl As DataRow In _Tbl_Productos.Rows

                        Dim _Id As Integer = _Fl.Item("Id")
                        Dim _Empresa As String = _Fl.Item("Empresa")
                        Dim _Sucursal As String = _Fl.Item("Sucursal")
                        Dim _Bodega As String = _Fl.Item("Bodega")
                        Dim _Codigo As String = _Fl.Item("Codigo")
                        Dim _Pedir As Double = _Fl.Item("Pedir")
                        Dim _Obs As String = String.Empty

                        If CBool(_Pedir) Then

                            Consulta_sql = "Select * From MAEDDO 
                                        Where TIDO = 'NVI' And EMPRESA = '" & _Empresa & "' And SULIDO = '" & _Sucursal &
                                    "' And BOSULIDO = '" & _Bodega & "' And KOPRCT = '" & _Codigo & "' And ESLIDO = ''"
                            Dim _TblNviPdtes As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

                            Dim _C = 0

                            For Each _FlNvi As DataRow In _TblNviPdtes.Rows

                                _C += 1

                                Dim _Idmaeedo As Integer = _FlNvi.Item("IDMAEEDO")
                                Dim _Cantidad As Double = _FlNvi.Item("CAPRCO" & Ud) - (_FlNvi.Item("CAPRAD" & Ud) + _FlNvi.Item("CAPREX" & Ud))

                                Dim _Reg As Boolean = CBool(_Sql.Fx_Cuenta_Registros("MAEEDO", "IDMAEEDO = " & _Idmaeedo & " And BODESTI = '" & _Bod_Recep & "'"))

                                If _Reg Then

                                    _Obs = _FlNvi.Item("NUDO") & " - Cant: " & FormatNumber(_Cantidad, 0)

                                End If

                                If _C <> _TblNviPdtes.Rows.Count Then
                                    _Obs += ", "
                                End If

                            Next

                            Consulta_sql = "Update " & _TblPaso & " Set NVI_Pendientes = '" & _Obs & "' Where Id = " & _Id
                            _Sql.Ej_consulta_IDU(Consulta_sql)

                        End If

                    Next

                    Consulta_sql = "Update " & _TblPaso & " Set Fecha_Ult_Venta = Isnull((Select Top 1 Fecha_Ult_Venta From " & _Nombre_Tbl_Paso_Informe & " Z2 Where Z1.Codigo_Nodo = Z2.Codigo_Nodo),'19000101')
                                    From " & _TblPaso & " Z1"
                    _Sql.Ej_consulta_IDU(Consulta_sql)

                    Consulta_sql = "Select * From " & _TblPaso
                    _Tbl_Productos = _Sql.Fx_Get_Tablas(Consulta_sql)

                    Dim _Reg2 = _Sql.Fx_Cuenta_Registros(_TblPaso, "NVI_Pendientes <> ''")

                    If CBool(_Reg2) Then

                        Consulta_sql = "Update " & _TblPaso & " Set Pedir = 0 Where NVI_Pendientes <> ''"
                        _Sql.Ej_consulta_IDU(Consulta_sql)

#Region "_Reg2"

                        'Dim Chk_Seguir_No_Quitar As New Command
                        'Chk_Seguir_No_Quitar.Checked = False
                        'Chk_Seguir_No_Quitar.Name = "Chk_Seguir_No_Quitar"
                        'Chk_Seguir_No_Quitar.Text = "Seguir con la gestión, no quitar productos que ya tienen NVI"

                        'Dim Chk_Seguir_Quitar As New Command
                        'Chk_Seguir_Quitar.Checked = False
                        'Chk_Seguir_Quitar.Name = "Chk_Seguir_Quitar"
                        'Chk_Seguir_Quitar.Text = "Seguir con la gestión y quitar productos que ya tienen NVI"

                        'Dim _Opciones1() As Command = {Chk_Seguir_No_Quitar, Chk_Seguir_Quitar}

                        'Dim _Info1 As New TaskDialogInfo("Validación del sistema",
                        '  eTaskDialogIcon.Shield,
                        '  "Algunos productos ya tienen NVI",
                        '  "Existen algunos productos que ya tienen solicitud hacia otras bodegas (NVI)" & Environment.NewLine &
                        '  "Marque su opción",
                        '  eTaskDialogButton.Ok + eTaskDialogButton.Cancel _
                        '  , eTaskDialogBackgroundColor.Red, _Opciones1, Nothing, Nothing, Nothing, Nothing)

                        'Dim _Resultado1 As eTaskDialogResult = TaskDialog.Show(_Info1)

                        'If _Resultado1 = eTaskDialogResult.Ok Then

                        '    If Chk_Seguir_No_Quitar.Checked Or Chk_Seguir_Quitar.Checked Then

                        '        If Chk_Seguir_Quitar.Checked Then

                        '            Consulta_sql = "Update " & _TblPaso & " Set Pedir = 0 Where NVI_Pendientes <> ''"
                        '            _Sql.Ej_consulta_IDU(Consulta_sql)

                        '        End If

                        '        If MessageBoxEx.Show(Me, "¿Desea exportar el resultado a Excel?", "Exportar a excel",
                        '                         MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                        '            Consulta_sql = "Select * From " & _TblPaso
                        '            _Tbl_Productos = _Sql.Fx_Get_Tablas(Consulta_sql)

                        '            ExportarTabla_JetExcel_Tabla(_Tbl_Productos, Me, "Prod. con NVI")

                        '        End If

                        '    Else

                        '        MessageBoxEx.Show(Me, "Debe seleccionar una opción", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        '        _Sql.Sb_Eliminar_Tabla_De_Paso(_TblPaso)
                        '        Return

                        '    End If

                        'Else

                        '    _Sql.Sb_Eliminar_Tabla_De_Paso(_TblPaso)
                        '    Return

                        'End If

#End Region

                    End If

                    _Reg2 = _Sql.Fx_Cuenta_Registros(_TblPaso, "Pedir > 0")

                    If _Reg2 = 0 Then

                        Consulta_sql = "Select Ddo.IDMAEDDO,Edo.TIDO,Edo.NUDO,Codigo,Codigo_Nodo,Descripcion,CAPRCO" & Ud & " As Cantidad
                                        From MAEDDO Ddo
                                            Inner Join MAEEDO Edo On Edo.IDMAEEDO = Ddo.IDMAEEDO
                                                Inner Join " & _TblPaso & " On Codigo = KOPRCT
                                        Where Edo.TIDO = 'NVI' And Edo.SUDO = '" & _Suc_Recep & "' AND Edo.BODESTI = '" & _Bod_Recep & "' 
                                          And Ddo.ESLIDO = '' And NVI_Pendientes <> ''"
                        _Tbl_Productos_Copy = _Sql.Fx_Get_Tablas(Consulta_sql)

                        Consulta_sql = String.Empty

                        For Each _Fila As DataRow In _Tbl_Productos_Copy.Rows

                            Dim _Codigo As String = _Fila.Item("Codigo")
                            Dim _Codigo_Nodo As String = _Fila.Item("Codigo_Nodo")
                            Dim _Cantidad As Double = _Fila.Item("Cantidad")

                            If _Codigo_Nodo = 0 Then

                                Consulta_sql = "Update " & _Nombre_Tbl_Paso_Informe & " Set CantComprar = CantComprar - " & De_Num_a_Tx_01(_Cantidad, False, 5) & vbCrLf &
                                           "Where Codigo = '" & _Codigo & "'"
                                _Sql.Ej_consulta_IDU(Consulta_sql)

                            Else

                                Consulta_sql = "Update " & _Nombre_Tbl_Paso_Informe & " Set CantComprar = CantComprar - " & De_Num_a_Tx_01(_Cantidad, False, 5) & vbCrLf &
                                               "Where Codigo_Nodo = '" & _Codigo_Nodo & "'"
                                _Sql.Ej_consulta_IDU(Consulta_sql)

                            End If

                        Next

                        MessageBoxEx.Show(Me, "No hay productos que pedir a otras bodegas", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)

                        Return

                    End If

                    Dim _Fecha_Emision As Date = FechaDelServidor()

                    'Dim Chk_Crear_NVI As New Command
                    'Chk_Crear_NVI.Checked = False
                    'Chk_Crear_NVI.Name = "Chk_Crear_NVI"
                    'Chk_Crear_NVI.Text = "Crear NVI (Generar documento de compromiso interno)"

                    'Dim Chk_Exportar_Excel As New Command
                    'Chk_Exportar_Excel.Checked = False
                    'Chk_Exportar_Excel.Name = "Chk_Exportar_Excel"
                    'Chk_Exportar_Excel.Text = "Exportar el listado a Excel (No generar NVI)"

                    'Dim Chk_Exportar_Excel_Crear_NVI As New Command
                    'Chk_Exportar_Excel_Crear_NVI.Checked = False
                    'Chk_Exportar_Excel_Crear_NVI.Name = "Chk_Exportar_Excel_Crear_NVI"
                    'Chk_Exportar_Excel_Crear_NVI.Text = "Crear NVI y Exportar listado a Excel"

                    'Dim Chk_Quitar_Productos As New Command
                    'Chk_Quitar_Productos.Checked = False
                    'Chk_Quitar_Productos.Name = "Chk_Quitar_Productos"
                    'Chk_Quitar_Productos.Text = "Quitar productos del tratamiento"

                    'Dim _Opciones() As Command = {Chk_Crear_NVI, Chk_Exportar_Excel_Crear_NVI, Chk_Exportar_Excel, Chk_Quitar_Productos}

                    'Dim _Info As New TaskDialogInfo("Validación del sistema",
                    '      eTaskDialogIcon.ShieldOk,
                    '      "Productos encontrados en otras bodegas",
                    '      "Existen varios productos que no es necesario comprarlos sino que se pueden pedir a otras bodegas" & Environment.NewLine &
                    '      "Marque su opción",
                    '      eTaskDialogButton.Ok + eTaskDialogButton.Cancel _
                    '      , eTaskDialogBackgroundColor.Red, _Opciones, Nothing, Nothing, Nothing, Nothing)

                    'Dim _Resultado As eTaskDialogResult = TaskDialog.Show(_Info)

                    Dim _Crear_NVI = True

                    Consulta_sql = "Update " & _TblPaso & " Set Ubicacion = (Select DATOSUBIC From TABBOPR Where EMPRESA = Empresa And KOSU = Sucursal And KOBO = Bodega And KOPR = Codigo)"
                    _Sql.Ej_consulta_IDU(Consulta_sql)

                    If _Crear_NVI Then

                        For Each _FlBodegas As DataRow In _TblBodReabastecen.Rows

                            Dim _Bod_Codigo = _FlBodegas.Item("Codigo")
                            Dim _Bod_Descripcion = _FlBodegas.Item("Descripcion")

                            Dim _Emp = Trim(Mid(_Bod_Codigo, 1, 2))
                            Dim _Suc = Trim(Mid(_Bod_Codigo, 3, 3))
                            Dim _Bod = Trim(Mid(_Bod_Codigo, 6, 3))

                            Dim _Tbl_ProductosSol As DataTable
                            Dim _Seguir = True

                            Do While _Seguir

                                Consulta_sql = "Select Top 20 * From " & _TblPaso & " 
                                                    Where NVI = '' And Empresa = '" & _Emp & "' And Sucursal = '" & _Suc & "' And Pedir > 0 Order By Ubicacion"
                                _Tbl_ProductosSol = _Sql.Fx_Get_Tablas(Consulta_sql)

                                _Seguir = CBool(_Tbl_ProductosSol.Rows.Count)

                                If _Seguir Then

                                    Dim _Nvi_Auto As New GeneraOccAuto.Doc_Auto

                                    _Nvi_Auto = Fx_Crear_NVI_Auto(_Tbl_ProductosSol, _Suc_Recep, _Bod_Recep, _Fecha_Emision, _Ud, _TblPaso)

                                    _Generar_NVI.Doc_Auto.Add(_Nvi_Auto)

                                    Dim _Ids As String = Generar_Filtro_IN(_Tbl_ProductosSol, "", "Id", True, False, "")

                                    If CBool(_Nvi_Auto.Idmaeedo) Then
                                        Consulta_sql = "Update " & _TblPaso & " Set NVI = '" & _Nvi_Auto.Nudo & "',Idmaeedo = " & _Nvi_Auto.Idmaeedo & " Where Id In " & _Ids
                                        _Sql.Ej_consulta_IDU(Consulta_sql)
                                    Else
                                        Consulta_sql = "Update " & _TblPaso & " Set NVI = 'XXXXX',Observacion = 'No se crea NVI, el usuario no la grabo' Where Id In " & _Ids
                                        _Sql.Ej_consulta_IDU(Consulta_sql)
                                    End If

                                End If

                            Loop

                        Next

                        Consulta_sql = String.Empty

                        Consulta_sql = "Select KOPRCT As Codigo,CAPRCO" & Ud & " As Cantidad,Codigo_Nodo
                                            From MAEDDO 
                                            Left Join " & _TblPaso & " On KOPRCT = Codigo
                                            Where IDMAEEDO In
                                            (Select Distinct Idmaeedo From " & _TblPaso & " Where Idmaeedo <> 0)"

                        Dim _Tbl_ProdNVI As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

                        Consulta_sql = String.Empty

                        For Each _Fila As DataRow In _Tbl_ProdNVI.Rows

                            Dim _Codigo As String = _Fila.Item("Codigo")
                            Dim _Codigo_Nodo As String = _Fila.Item("Codigo_Nodo")
                            Dim _Cantidad As Double = _Fila.Item("Cantidad")

                            If _Codigo_Nodo = 0 Then
                                Consulta_sql += "Update " & _Nombre_Tbl_Paso_Informe & " Set CantComprar = CantComprar - " & De_Num_a_Tx_01(_Cantidad, False, 5) & vbCrLf &
                                                    "Where Codigo = '" & _Codigo & "'" & vbCrLf
                            Else
                                Consulta_sql += "Update " & _Nombre_Tbl_Paso_Informe & " Set CantComprar = CantComprar - " & De_Num_a_Tx_01(_Cantidad, False, 5) & vbCrLf &
                                                    "Where Codigo_Nodo = '" & _Codigo_Nodo & "'" & vbCrLf
                            End If

                        Next

                        If Not String.IsNullOrEmpty(Consulta_sql) Then

                            If _Sql.Ej_consulta_IDU(Consulta_sql) Then

                                MessageBoxEx.Show(Me, "Los productos que fueron solicitados con NVI se quitaron las cantidades de esta solicitud" & vbCrLf & vbCrLf &
                                                  _Tbl_ProdNVI.Rows.Count & " registro(s) encontrado(s) en la(s) bodega(s) ",
                                                 "Restar stock de compra", MessageBoxButtons.OK, MessageBoxIcon.Information)

                                Sb_Refrescar_Grilla_Principal(Fm_Hijo.Grilla, False, False)

                            End If

                        End If

                    End If

                    _Sql.Sb_Eliminar_Tabla_De_Paso(_TblPaso)

                Catch ex As Exception
                    MessageBoxEx.Show(Me, ex.Message, "Problema al generar el estudio", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Finally
                    Me.Enabled = True
                    Fm_Espera.Close()
                End Try

            End If

        Else
            MessageBoxEx.Show(Me, "¡Debe tener seleccionada solo una bodega para el estudio de bodegas!", "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If


    End Sub

End Class


Namespace GeneraOccAuto

    Public Class Generar_Doc_Auto

        Public Property DocGenerados As Boolean
        Public Property Doc_Auto As New List(Of Doc_Auto)
        Public Property Mensaje As String

        Function Fx_Enviar_Notificacion_Correo_Al_Diablito(_Idmaeedo As Integer,
                                                           _Para As String,
                                                           _Cc As String,
                                                           _Id_Correo As Integer,
                                                           _NombreFormato_PDF As String) As String

            Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
            Dim Consulta_sql As String
            Dim _Error = String.Empty

            Try

                Consulta_sql = "Select * From MAEEDO Where IDMAEEDO = " & _Idmaeedo
                Dim _Row_Maeedo As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

                Dim _Tido As String = _Row_Maeedo.Item("TIDO")
                Dim _Nudo As String = _Row_Maeedo.Item("NUDO")

                If String.IsNullOrEmpty(_Para.Trim) Then
                    Throw New System.Exception("Falta el correo del cliente")
                End If

                If Not Fx_Validar_Email(_Para) Then
                    Throw New System.Exception("El correo para: [" & _Para & "] no es una cuenta de correos valida")
                End If

                If Not String.IsNullOrEmpty(_Cc) Then

                    If Not Fx_Validar_Email(_Cc) Then

                        If _Cc.Contains(";") Then
                            Dim _Ccs = _Cc.Split(";")

                            For Each _Correos In _Ccs
                                If Not Fx_Validar_Email(_Correos) Then
                                    Throw New System.Exception("El correo CC: [" & _Correos & "] no es una cuenta de correos valida")
                                End If
                            Next
                        Else
                            If Not Fx_Validar_Email(_Cc) Then
                                Throw New System.Exception("El correo CC: [" & _Cc & "] no es una cuenta de correos valida")
                            End If
                        End If

                    End If

                End If

                'Dim _Id_Dte As Integer = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_DTE_Trackid", "Id_Dte", "Idmaeedo = " & _Idmaeedo & " And (Aceptado = 1 or Reparo = 1)", True)
                'Dim _Id_Dte As Integer = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_DTE_Trackid", "Id_Dte", "Id = " & _Id_Trackid, True)

                'If Not CBool(_Id_Dte) Then
                '    Throw New System.Exception("No se encontro registro en tabla Zw_DTE_Trackid del sistema")
                'End If

                'Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_DTE_Documentos Where Id_Dte = " & _Id_Dte
                'Dim _Row_DTE As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

                'If IsNothing(_Row_DTE) Then
                '    Throw New System.Exception("No se encontro registro en tabla Zw_DTE_Documentos del sistema")
                'End If

                'If String.IsNullOrEmpty(_Row_DTE.Item("CaratulaXml")) Then
                '    Throw New System.Exception("No se encontro el archivo CaratulaXml en la tabla Zw_DTE_Documentos del sistema")
                'End If

                'Dim _Id_Correo As Integer = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_DTE_Configuracion",
                '                                              "Valor",
                '                                              "Campo = 'Id_Correo' And Empresa = '" & ModEmpresa & "'")

                'If Not CBool(_Id_Correo) Then
                '    Throw New System.Exception("Falta asignar un correo de notificación en la configuración del sistema DTE")
                'End If

                'Dim _NombreFormato_PDF As String = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_DTE_Configuracion",
                '                                                     "Valor",
                '                                                     "Campo = 'NombreFormato_PDF_" & _Tido & "' And Empresa = '" & ModEmpresa & "'")

                Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Correos Corr Where Id = " & _Id_Correo
                Dim _Row_Correo As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

                If IsNothing(_Row_Correo) Then
                    Throw New System.Exception("No existe configuración para el envio de correos")
                End If

                Dim _Nombre_Correo As String = _Row_Correo.Item("Nombre_Correo")
                Dim _Asunto As String = _Row_Correo.Item("Asunto")
                Dim _Mensaje As String = _Row_Correo.Item("CuerpoMensaje")

                If String.IsNullOrEmpty(_Asunto) Then
                    _Asunto = "Correo de notificación de pedido " & RazonEmpresa
                End If

                _Mensaje = Replace(_Mensaje, "&lt;", "<")
                _Mensaje = Replace(_Mensaje, "&gt;", ">")
                _Mensaje = Replace(_Mensaje, "&quot;", """")

                _Mensaje = Replace(_Mensaje, "'", "''")

                If Not String.IsNullOrEmpty(_Nombre_Correo) Then

                    Dim _Fecha = "Getdate()"
                    Dim _Adjuntar_Documento As Boolean = Not String.IsNullOrEmpty(_NombreFormato_PDF)

                    Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Demonio_Doc_Emitidos_Aviso_Correo (Id_Correo,Nombre_Correo,CodFuncionario,Asunto," &
                                    "Para,Cc,Idmaeedo,Tido,Nudo,NombreFormato,Enviar,Mensaje,Fecha,Adjuntar_Documento,Doc_Adjuntos)" &
                                    vbCrLf &
                                    "Values (" & _Id_Correo & ",'" & _Nombre_Correo & "','','" & _Asunto & "','" & _Para & "','" & _Cc &
                                    "'," & _Idmaeedo & ",'" & _Tido & "','" & _Nudo & "','" & _NombreFormato_PDF & "',1,'" & _Mensaje & "'," & _Fecha &
                                    "," & Convert.ToInt32(_Adjuntar_Documento) & ",'')"

                    _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql)

                    _Error = _Sql.Pro_Error

                    If Not String.IsNullOrEmpty(_Error) Then
                        Throw New System.Exception(_Error)
                    End If

                End If

            Catch ex As Exception
                _Error = ex.Message
            End Try

            Return _Error

        End Function

    End Class

    Public Class Doc_Auto

        Public Property Idmaeedo As Integer
        Public Property Tido As String
        Public Property Nudo As String
        Public Property Feemdo As DateTime
        Public Property Endo As String
        Public Property Suendo As String
        Public Property Email As String
        Public Property ErrorGrabar As Boolean
        Public Property MensajeError As String

    End Class

End Namespace
