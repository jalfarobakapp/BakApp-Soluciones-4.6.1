Imports System.ComponentModel
Imports System.Globalization
Imports DevComponents.DotNetBar

Public Class Frm_BkpPostBusquedaEspecial_Mt

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Codigo_Sel As String
    Dim _Es_Conceto As Boolean

    Dim _Empresa, _Sucursal, _Bodega As String

    Dim _Tbl_Productos_Grilla As DataTable
    Dim _Tbl_Top20 As DataTable
    Dim _Tbl_Bodegas As DataTable
    Dim _Realizar_Busqueda As Boolean
    Dim _Filtro_Sql_Extra As String

    Dim _Tbl_Productos_Seleccionados As DataTable
    Dim _Seleccion_Multiple As Boolean
    Dim _Seleccionar_Multiple As Boolean

    Dim _Cl_ActFxDinXProductos As New Class_ActFxDinXProductos ' Actualiza formula por producto dinamicamente en tiempo de ejecucion
    Dim WithEvents _BackgroundWorker As New BackgroundWorker

    Dim _Mostrar_Stock_Disponible As Boolean
    Dim _Tido_Stock As String

    Dim _Usar_Bodegas_NVI As Boolean

    Dim _Row_Patente_rvm As DataRow

    Enum Enum_Bloquear
        No_Bloquear
        Compras
        Ventas
        Compras_y_Ventas
        Compras_Ventas_y_Produccion
        No_Bloqueados
    End Enum

    Dim _Bloqueados As Enum_Bloquear
    Dim _Row_Entidad As DataRow

    Enum Enum_Top20
        Ninguno
        Top_Compras
        Top_Ventas
    End Enum

    Dim _Top20 As Enum_Top20 = Enum_Top20.Ninguno

    Dim _Patente_rvm As String

#Region "PROPIEDADES"

    Public Property TraerTodosLosProductos As Boolean
    Public Property Pro_Empresa() As String
        Get
            Return _Empresa
        End Get
        Set(value As String)
            _Empresa = value
        End Set
    End Property
    Public Property Pro_Sucursal() As String
        Get
            Return _Sucursal
        End Get
        Set(value As String)
            _Sucursal = value
        End Set
    End Property
    Public Property Pro_Bodega() As String
        Get
            Return _Bodega
        End Get
        Set(value As String)
            _Bodega = value
        End Set
    End Property
    Public Property Pro_Filtro_Sql_Extra() As String
        Get
            Return _Filtro_Sql_Extra
        End Get
        Set(value As String)
            _Filtro_Sql_Extra = value
        End Set
    End Property

    Dim _RowBodega As DataRow

    Public Property Pro_Row_Bodega() As DataRow
        Get
            Return _RowBodega
        End Get
        Set(value As DataRow)
            _RowBodega = value
        End Set
    End Property

    Dim _CodEntidad, _CodSucEntidad As String

    Public Property Pro_CodEntidad() As String
        Get
            Return _CodEntidad
        End Get
        Set(value As String)
            _CodEntidad = value
        End Set
    End Property
    Public Property Pro_CodSucEntidad() As String
        Get
            Return _CodSucEntidad
        End Get
        Set(value As String)
            _CodSucEntidad = value
        End Set
    End Property

    Dim _ListaBusq, _BodegaBusq, _SucursalBusq As String

    Public Property Pro_Lista_Busqueda() As String
        Get
            Return _ListaBusq
        End Get
        Set(value As String)
            _ListaBusq = value
        End Set
    End Property
    Public Property Pro_Bodega_Busqueda() As String
        Get
            Return _BodegaBusq
        End Get
        Set(value As String)
            _BodegaBusq = value
        End Set
    End Property
    Public Property Pro_Sucursal_Busqueda() As String
        Get
            Return _SucursalBusq
        End Get
        Set(value As String)
            _SucursalBusq = value
        End Set
    End Property

    Dim _Seleccionado As Boolean

    Public Property Pro_Seleccionado() As Boolean
        Get
            Return _Seleccionado
        End Get
        Set(value As Boolean)
            _Seleccionado = value
        End Set
    End Property

    Dim _Tbl_Producto_Seleccionado As DataTable

    Public Property Pro_Tbl_Producto_Seleccionado() As DataTable
        Get
            Return _Tbl_Producto_Seleccionado
        End Get
        Set(value As DataTable)
            _Tbl_Producto_Seleccionado = value
        End Set
    End Property

    Dim _Tipo_Lista As String

    Public Property Pro_Tipo_Lista() As String
        Get
            Return _Tipo_Lista
        End Get
        Set(value As String)
            _Tipo_Lista = value
        End Set
    End Property

    Dim _Tabla_Lista As String

    Public Property Pro_Tabla_Listas() As String
        Get
            Return _Tabla_Lista
        End Get
        Set(value As String)
            _Tabla_Lista = value
        End Set
    End Property

    Dim _Actualizar_Precios As Boolean = True

    Public Property Pro_Actualizar_Precios() As Boolean
        Get
            Return _Actualizar_Precios
        End Get
        Set(value As Boolean)
            _Actualizar_Precios = value
        End Set
    End Property

    Dim _Mostrar_Info As Boolean

    Public Property Pro_Mostrar_Info() As Boolean
        Get
            Return _Mostrar_Info
        End Get
        Set(value As Boolean)
            _Mostrar_Info = value
        End Set
    End Property

    Dim _Campo_PreUd1,
        _Campo_PreUd2 As String

    Public Property Pro_Campo_PreUd1() As String
        Get
            Return _Campo_PreUd1
        End Get
        Set(value As String)
            _Campo_PreUd1 = value
        End Set
    End Property
    Public Property Pro_Campo_PreUd2() As String
        Get
            Return _Campo_PreUd2
        End Get
        Set(value As String)
            _Campo_PreUd2 = value
        End Set
    End Property

    Dim _Maestro_productos As Boolean

    Public Property Pro_Maestro_Productos() As Boolean
        Get
            Return _Maestro_productos
        End Get
        Set(value As Boolean)
            _Maestro_productos = value
        End Set
    End Property

    Dim _Mostrar_Clasificaciones,
        _Mostrar_Editar,
        _Mostrar_Eliminar,
        _Mostrar_Imagenes As Boolean

    Public Property Pro_Mostrar_Clasificaciones() As Boolean
        Get
            Return _Mostrar_Clasificaciones
        End Get
        Set(value As Boolean)
            _Mostrar_Clasificaciones = value
        End Set
    End Property
    Public Property Pro_Mostrar_Editar() As Boolean
        Get
            Return _Mostrar_Editar
        End Get
        Set(value As Boolean)
            _Mostrar_Editar = value
        End Set
    End Property
    Public Property Pro_Mostrar_Eliminar() As Boolean
        Get
            Return _Mostrar_Eliminar
        End Get
        Set(value As Boolean)
            _Mostrar_Eliminar = value
        End Set
    End Property
    Public Property Pro_Mostrar_Imagenes() As Boolean
        Get
            Return _Mostrar_Imagenes
        End Get
        Set(value As Boolean)
            _Mostrar_Imagenes = value
        End Set
    End Property

    Dim _Buscar_Lista_Proveedor As Boolean

    Public Property Pro_Buscar_Lista_Proveedor() As Boolean
        Get
            Return _Buscar_Lista_Proveedor
        End Get
        Set(value As Boolean)
            _Buscar_Lista_Proveedor = value
        End Set
    End Property

    Dim _Trabajar_Alternativos As Boolean

    Public Property Pro_Trabajar_Alternativos() As Boolean
        Get
            Return _Trabajar_Alternativos
        End Get
        Set(value As Boolean)
            _Trabajar_Alternativos = value
        End Set
    End Property

    Dim _Trabajar_Ubicaciones As Boolean

    Public Property Pro_Trabajar_Ubicaciones() As Boolean
        Get
            Return _Trabajar_Ubicaciones
        End Get
        Set(value As Boolean)
            _Trabajar_Ubicaciones = value
        End Set
    End Property

    Dim _Tbl_Productos As DataTable

    Public Property Pro_Tbl_Productos() As DataTable
        Get
            Return _Tbl_Productos
        End Get
        Set(value As DataTable)
            _Tbl_Productos = value
        End Set
    End Property

    Dim _RowProducto As DataRow

    Public ReadOnly Property Pro_RowProducto() As DataRow
        Get
            Return _RowProducto
        End Get
    End Property

    Dim _Text_Ultima_Busqueda = String.Empty

    Public Property Pro_Text_Ultima_Busqueda() As String
        Get
            Return _Text_Ultima_Busqueda
        End Get
        Set(value As String)
            _Text_Ultima_Busqueda = value
        End Set
    End Property

    Dim _Mostrar_Precios As Boolean = True

    Public Property Pro_Mostrar_Precios() As Boolean
        Get
            Return _Mostrar_Precios
        End Get
        Set(value As Boolean)
            _Mostrar_Precios = value
        End Set
    End Property

    Public Property Bloqueados As Enum_Bloquear
        Get
            Return _Bloqueados
        End Get
        Set(value As Enum_Bloquear)
            _Bloqueados = value
        End Set
    End Property

    Public Property Row_Entidad As DataRow
        Get
            Return _Row_Entidad
        End Get
        Set(value As DataRow)
            _Row_Entidad = value
        End Set
    End Property

    Public Property Top20 As Enum_Top20
        Get
            Return _Top20
        End Get
        Set(value As Enum_Top20)
            _Top20 = value
        End Set
    End Property

    Public Property Codigo_Sel As String
        Get
            Return _Codigo_Sel
        End Get
        Set(value As String)
            _Codigo_Sel = value
        End Set
    End Property

    Public Property Es_Conceto As Boolean
        Get
            Return _Es_Conceto
        End Get
        Set(value As Boolean)
            _Es_Conceto = value
        End Set
    End Property

    Public Property Tbl_Productos_Seleccionados As DataTable
        Get
            Return _Tbl_Productos_Seleccionados
        End Get
        Set(value As DataTable)
            _Tbl_Productos_Seleccionados = value
        End Set
    End Property

    Public Property Seleccion_Multiple As Boolean
        Get
            Return _Seleccion_Multiple
        End Get
        Set(value As Boolean)
            _Seleccion_Multiple = value
        End Set
    End Property

    Public Property Seleccionar_Multiple As Boolean
        Get
            Return _Seleccionar_Multiple
        End Get
        Set(value As Boolean)
            _Seleccionar_Multiple = value
        End Set
    End Property

    Public Property Mostrar_Stock_Disponible As Boolean
        Get
            Return _Mostrar_Stock_Disponible
        End Get
        Set(value As Boolean)
            _Mostrar_Stock_Disponible = value
        End Set
    End Property

    Public Property Tido_Stock As String
        Get
            Return _Tido_Stock
        End Get
        Set(value As String)
            _Tido_Stock = value
        End Set
    End Property

    Public Property Usar_Bodegas_NVI As Boolean
        Get
            Return _Usar_Bodegas_NVI
        End Get
        Set(value As Boolean)
            _Usar_Bodegas_NVI = value
        End Set
    End Property

    Public Property MostrarSoloServTecnico_ProIngreso As Boolean
    Public Property MostrarSoloServTecnico_ProServicio As Boolean

    Public Property Patente_rvm As String
        Get
            Return _Patente_rvm
        End Get
        Set(value As String)
            _Patente_rvm = value
        End Set
    End Property

    Public Property Row_Patente_rvm As DataRow
        Get
            Return _Row_Patente_rvm
        End Get
        Set(value As DataRow)
            _Row_Patente_rvm = value
        End Set
    End Property

#End Region

    Enum _Opcion_Buscar
        _Descripcion
        _Codigo
    End Enum

    Dim _Top = 100
    Dim _Top_Filas = 100

    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Sb_Formato_Generico_Grilla(Grilla, 18, New Font("Tahoma", 8), Color.White, ScrollBars.Vertical, True, True, _Seleccionar_Multiple)
        Sb_Formato_Generico_Grilla(GrillaBusquedaOtros, 15, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, False, False, False)

        _Seleccionado = False

        Sb_Actualizar_Tbl_Bodegas()

        Sb_Color_Botones_Barra(Bar1)
        'Sb_Color_Botones_Barra(Bar2)
        Sb_Color_Botones_Barra(Bar_Menu_Producto)

        If Global_Thema = Enum_Themas.Oscuro Then
            Btn_Seleccion_Multiple.ForeColor = Color.White
            Btn_Ocultar.ForeColor = Color.White
        End If

    End Sub
    Private Sub Frm_BkpPostBusquedaEspecial_Mt_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        If Not _Global_Row_Configuracion_General.Item("Patentes_rvm") Then
            Txtdescripcion.Width = 694
        End If

        Fx_Buscar_Patente()

        Sb_Actualizar_Tbl_Bodegas()

        Fx_Activar_Deactivar_Teclado()
        _Mostrar_Clasificaciones = True
        Sb_Llena_Combo_CantFilas()

        Dim _CondExtraProveedor As String = String.Empty

        Dim _Act_Fx As Boolean

        Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Prod_Asociacion (Codigo,Codigo_Nodo,DescripcionBusqueda,Para_filtro,Clas_unica,Producto)" & vbCrLf &
                       "Select KOPR,0,Rtrim(Ltrim(KOPR)) + ' ' + Rtrim(Ltrim(NOKOPR)),0,0,1 From MAEPR" & vbCrLf &
                       "Where KOPR Not In (Select Codigo From " & _Global_BaseBk & "Zw_Prod_Asociacion Where Producto = 1)"
        _Sql.Ej_consulta_IDU(Consulta_sql)

        If _Tipo_Lista = "C" Then

            _Act_Fx = False

            _Tabla_Lista = _Global_BaseBk & "Zw_ListaPreCosto"
            _Campo_PreUd1 = "CostoUd1"
            _Campo_PreUd2 = "CostoUd1"

            If Not String.IsNullOrEmpty(Trim(_CodEntidad)) Then
                _CondExtraProveedor = "Where Proeveedor = '" & _CodEntidad & "' And Sucursal = '" & _CodSucEntidad & "'"
            End If

        ElseIf _Tipo_Lista = "P" Then

            _Act_Fx = True

            _Tabla_Lista = _Global_BaseBk & "Zw_ListaPreProducto"

            _Campo_PreUd1 = "Precio"
            _Campo_PreUd2 = "Precio2"

        End If

        Sb_Buscar_Productos(ModEmpresa, _SucursalBusq, _BodegaBusq, _ListaBusq, True, _Opcion_Buscar._Descripcion, _Top)

        Grilla.ClearSelection()
        GrillaBusquedaOtros.ClearSelection()

        Mnu_Btn_Editar_Producto.Enabled = _Mostrar_Editar
        Mnu_Btn_Eliminar_Producto.Enabled = _Mostrar_Eliminar
        Mnu_Btn_Imagenes_producto.Visible = _Mostrar_Imagenes

        ChkMostrarOcultos.Checked = False

        If _Trabajar_Alternativos Then

            AddHandler Grilla.CellDoubleClick, AddressOf Sb_Seleccionar_Producto_doble_clic_Alternativos
            'AddHandler Btn_Seleccionar.Click, AddressOf Sb_Seleccionar_Producto_doble_clic_Alternativos

            Me.ActiveControl = TxtCodigo
        ElseIf _Trabajar_Ubicaciones Then

            AddHandler Grilla.CellDoubleClick, AddressOf Sb_Seleccionar_Producto_doble_clic_Ubicaciones
            'AddHandler Btn_Seleccionar.Click, AddressOf Sb_Seleccionar_Producto_doble_clic_Ubicaciones

            Me.ActiveControl = Txtdescripcion
        Else

            AddHandler Grilla.CellDoubleClick, AddressOf Sb_Seleccionar_Producto_doble_clic
            'AddHandler Btn_Seleccionar.Click, AddressOf Sb_Seleccionar_Producto_doble_clic

            Me.ActiveControl = Txtdescripcion
        End If

        AddHandler Grilla.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint

        If CBool(Grilla.Rows.Count) Then
            Grilla.CurrentCell = Grilla.Rows(0).Cells("Codigo")
        End If

        Me.ActiveControl = Txtdescripcion

        AddHandler Grilla.MouseDown, AddressOf Sb_Grilla_MouseDown

        _Sql.Sb_Parametro_Informe_Sql(Chk_Top20, "Buscar_Productos", Chk_Top20.Name,
                                                 Class_SQLite.Enum_Type._Boolean, False, False, "Productos")

        Btn_Maestra_Productos.Image = ImageList1.Images.Item(1)

        Select Case _Top20

            Case Enum_Top20.Top_Compras, Enum_Top20.Top_Ventas

                'Tab_Top20.Visible = True
                Btn_Top20.Visible = True

                Dim _Filtro_Tido As String

                If _Top20 = Enum_Top20.Top_Compras Then
                    _Filtro_Tido = "'BLC','FCC','FCT','FDC','RGA','SRF','FCZ','FCL','NCC','NCB'"
                ElseIf _Top20 = Enum_Top20.Top_Ventas Then
                    _Filtro_Tido = "'BLV','BSV','BLX','FCV','FDB','FDV','FDX','FDZ','FEV','FVL','FVT','FVX','FXV','FYV','FVZ','RIN','ESC','FEE','FDE','NCV','NCX','NCZ','NEV','NCE'"
                End If

                Consulta_sql = My.Resources.Recursos_Productos_.Buscar_Top20

                Consulta_sql = Replace(Consulta_sql, "#Endo#", _CodEntidad)
                Consulta_sql = Replace(Consulta_sql, "#Filtro_Tido#", _Filtro_Tido)
                Consulta_sql = Replace(Consulta_sql, "#Empresa#", ModEmpresa)
                Consulta_sql = Replace(Consulta_sql, "#Sucursal#", _SucursalBusq)
                Consulta_sql = Replace(Consulta_sql, "#Bodega#", _BodegaBusq)
                Consulta_sql = Replace(Consulta_sql, "#Lista#", _ListaBusq)

                Dim _Sql_Query = String.Empty

                For Each _Fila As DataRow In _Tbl_Bodegas.Rows

                    Dim _Emp = Trim(_Fila.Item("EMPRESA"))
                    Dim _Suc = Trim(_Fila.Item("KOSU"))
                    Dim _Bod = Trim(_Fila.Item("KOBO"))

                    _Sql_Query +=
                            "ISNULL((SELECT TOP 1 Mt.STFI1 FROM MAEST Mt" & Space(1) &
                            "WHERE Mt.EMPRESA = '" & _Emp & "' AND Mt.KOSU = '" & _Suc & "' AND " & vbCrLf &
                            "Mt.KOBO = '" & _Bod & "' AND Mt.KOPR = Mp.KOPR),0) AS [STOCK_Ud1_" & _Emp & _Suc & _Bod & "]," & vbCrLf

                Next

                Consulta_sql = Replace(Consulta_sql, "#Stock#", _Sql_Query)

                _Tbl_Top20 = _Sql.Fx_Get_Tablas(Consulta_sql)

                'Sb_Formato_Grilla()

            Case Else

                Btn_Top20.Visible = False
                'Tab_Top20.Visible = False

        End Select

        If Chk_Top20.Checked Then
            Call Btn_Top20_Click(Nothing, Nothing)
        End If

        If _Seleccionar_Multiple Then

            AddHandler Grilla.MouseUp, AddressOf Sb_Grilla_MouseUp
            AddHandler Grilla.KeyUp, AddressOf Grilla_KeyUp

        End If

        Btn_Seleccion_Multiple.Visible = _Seleccionar_Multiple
        Btn_Marcar_Seleccionados.Visible = False
        Btn_Desmarcar_Seleccionados.Visible = False

        Btn_Mnu_Pr_Editar_Producto.Enabled = _Mostrar_Editar
        Btn_Mnu_Pr_Eliminar_Producto.Enabled = _Mostrar_Eliminar

    End Sub

    Function Fx_Buscar_Patente() As Boolean

        Txt_Patente.ReadOnly = False
        Txt_Patente.Text = String.Empty
        Grupo_BusquedaProducto.Text = "Cadena de busqueda del producto"

        If String.IsNullOrEmpty(_Patente_rvm) Then
            Txt_Patente.ButtonCustom.Visible = True
            Txt_Patente.ButtonCustom2.Visible = False
            _Row_Patente_rvm = Nothing
            Return False
        End If

        Consulta_sql = "Select *,Marca+' '+Modelo+' año: '+AFabricacion As Descripcion,Marca+' '+ModeloBusqueda+' '+AFabricacion As DescripcionBusqueda" & vbCrLf &
                       "From " & _Global_BaseBk & "Zw_Patentes_rvm Where Patente = '" & _Patente_rvm & "'"
        _Row_Patente_rvm = _Sql.Fx_Get_DataRow(Consulta_sql)

        If IsNothing(_Row_Patente_rvm) Then
            _Patente_rvm = String.Empty
            Txt_Patente.ButtonCustom.Visible = True
            Txt_Patente.ButtonCustom2.Visible = False
            Return False
        End If

        If Not IsNothing(_Row_Patente_rvm) Then
            Txt_Patente.ButtonCustom.Visible = False
            Txt_Patente.ButtonCustom2.Visible = True
            _Patente_rvm = _Row_Patente_rvm.Item("Patente")
            Txt_Patente.Text = _Patente_rvm
            Grupo_BusquedaProducto.Text = "CADENA DE BUSQUEDA DE PRODUCTOS PARA EL VEHICULO: " & _Row_Patente_rvm.Item("Descripcion").ToString.Trim.ToUpper
            Txt_Patente.ReadOnly = True
        End If

        Return True

    End Function

    Sub Sb_Actualizar_Tbl_Bodegas()

        Dim _Orden_Bod = "ORDEN_BOD_" & ModEmpresa.Trim & ModSucursal.Trim

        If _Usar_Bodegas_NVI Then

            Consulta_sql = "Select DISTINCT Cast(0 As int) As Orden,Ltrim(Rtrim(EMPRESA))+Ltrim(Rtrim(KOSU))+Ltrim(Rtrim(KOBO)) As Bodega,*
                        Into #Paso
                        From TABBO
                        Where EMPRESA+KOSU+KOBO
                        In (
                        Select SUBSTRING(CodPermiso, 5, 10)
                        From " & _Global_BaseBk & "ZW_PermisosVsUsuarios
                        Where CodUsuario = '" & FUNCIONARIO & "' And CodPermiso In (Select CodPermiso From " & _Global_BaseBk & "ZW_Permisos Where CodFamilia = 'Bodega_NVI'))
                        Or (EMPRESA = '" & ModEmpresa & "' And KOSU = '" & ModSucursal & "' And KOBO = '" & ModBodega & "')
   
                        Update #Paso Set Orden = Isnull((Select Orden From " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones 
						                        		 Where Tabla = '" & _Orden_Bod & "' And CodigoTabla = Bodega),0)

                        Select * From #Paso Where EMPRESA = '" & ModEmpresa & "' Order by Orden
                        Drop Table #Paso"
        Else

            Consulta_sql = "Select DISTINCT Cast(0 As int) As Orden,Ltrim(Rtrim(EMPRESA))+Ltrim(Rtrim(KOSU))+Ltrim(Rtrim(KOBO)) As Bodega,*
                        Into #Paso
                        From TABBO
                        Where EMPRESA+KOSU+KOBO
                        In (
                        Select SUBSTRING(CodPermiso, 3, 10)
                        From " & _Global_BaseBk & "ZW_PermisosVsUsuarios
                        Where CodUsuario = '" & FUNCIONARIO & "' And CodPermiso In (Select CodPermiso From " & _Global_BaseBk & "ZW_Permisos Where CodFamilia = 'Bodega'))
                        Or (EMPRESA = '" & ModEmpresa & "' And KOSU = '" & ModSucursal & "' And KOBO = '" & ModBodega & "')
   
                        Update #Paso Set Orden = Isnull((Select Orden From " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones 
						                        		 Where Tabla = '" & _Orden_Bod & "' And CodigoTabla = Bodega),0)

                        Select * From #Paso Where EMPRESA = '" & ModEmpresa & "' Order by Orden
                        Drop Table #Paso"
        End If

        _Tbl_Bodegas = _Sql.Fx_Get_Tablas(Consulta_sql)

    End Sub

#Region "FUNCIONES"

    Sub Sb_Buscar_Productos(_Empresa As String,
                            _Sucursal As String,
                            _Bodega As String,
                            _Lista As String,
                            _Limpiar As Boolean,
                            Optional _Opcion_Buscar As _Opcion_Buscar = _Opcion_Buscar._Descripcion,
                            Optional _Top As Integer = 100)

        Try

            RemoveHandler Grilla.KeyDown, AddressOf Sb_Grilla_KeyDown

            Txt_Ficha.Text = String.Empty

            _Cl_ActFxDinXProductos.Sb_Detener()

            If _Limpiar Then
                If Not IsNothing(_Tbl_Productos_Grilla) Then _Tbl_Productos_Grilla.Clear()
                _Realizar_Busqueda = True
            End If

            If _Realizar_Busqueda Then

                Me.Cursor = Cursors.WaitCursor
                Me.Enabled = False
                CirProg_Actualizando.IsRunning = True
                CirProg_Actualizando.Visible = True
                Me.Refresh()

                Dim _Tbl As DataTable = Fx_Tbl_Buscar_Productos(_Empresa, _Sucursal, _Bodega, _Lista, _Opcion_Buscar, _Top)

                Me.Enabled = True
                Me.Cursor = Cursors.Default

                If _Tbl Is Nothing Then
                    _Realizar_Busqueda = False
                End If

                If _Limpiar Then
                    _Tbl_Productos_Grilla = _Tbl
                    Sb_Formato_Grilla()
                Else
                    For Each _Fila As DataRow In _Tbl.Rows
                        Sb_Nueva_Linea(_Fila)
                    Next
                End If
            End If

            If CBool(_Tbl_Productos_Grilla.Rows.Count) Then
                If Not _Limpiar Then
                    _Cl_ActFxDinXProductos.Sb_Iniciar(_Tbl_Productos_Grilla, _ListaBusq, CirProg_Actualizando, _Mostrar_Stock_Disponible, _Tido_Stock, _Tbl_Bodegas)
                End If
            End If

        Catch ex As Exception
            'MsgBox(ex.Message)
        Finally
            CirProg_Actualizando.Visible = False
            Me.Enabled = True
            Me.Cursor = Cursors.Default
            Me.Refresh()
            AddHandler Grilla.KeyDown, AddressOf Sb_Grilla_KeyDown
        End Try

    End Sub

    Private Sub Sb_Nueva_Linea(_Fila As DataRow)

        Dim _Sql_Query As String

        Dim NewFila As DataRow
        NewFila = _Tbl_Productos_Grilla.NewRow
        With NewFila

            .Item("Codigo") = _Fila.Item("Codigo")
            .Item("Descripcion") = _Fila.Item("Descripcion")
            .Item("Prct") = _Fila.Item("Prct")
            .Item("Rtu") = _Fila.Item("Rtu")
            .Item("Precio_UD1") = _Fila.Item("Precio_UD1")
            .Item("Precio_UD1_Bruto") = _Fila.Item("Precio_UD1_Bruto")
            .Item("Precio_UD2") = _Fila.Item("Precio_UD2")
            .Item("Precio_UD2_Bruto") = _Fila.Item("Precio_UD2_Bruto")
            .Item("Ecuacion_Ud1") = _Fila.Item("Ecuacion_Ud1")
            .Item("Ecuacion_Ud2") = _Fila.Item("Ecuacion_Ud2")
            .Item("Ecuacion_Generada") = _Fila.Item("Ecuacion_Generada")
            .Item("CLALIBPR") = _Fila.Item("CLALIBPR")
            .Item("DATOSUBIC") = _Fila.Item("DATOSUBIC")
            .Item("FAMILIA") = _Fila.Item("FAMILIA")
            .Item("Oculto") = _Fila.Item("Oculto")

            For Each _Fila_Bd As DataRow In _Tbl_Bodegas.Rows

                Dim _Emp = Trim(_Fila_Bd.Item("EMPRESA"))
                Dim _Suc = Trim(_Fila_Bd.Item("KOSU"))
                Dim _Bod = Trim(_Fila_Bd.Item("KOBO"))

                Dim _Campo_Bod As String = "STOCK_Ud1_" & _Emp & _Suc & _Bod
                .Item(_Campo_Bod) = _Fila.Item(_Campo_Bod)

            Next

            'If _Mostrar_Info Then
            'If _Mostrar_Precios Then
            ''Sb_Ejecutar_Ecuacion_Dinamica(NewFila)
            '_Cl_ActFxDinXProductos.Sb_Iniciar(_Tbl_Productos_Grilla, _ListaBusq)
            'End If
            'End If

            _Tbl_Productos_Grilla.Rows.Add(NewFila)

        End With

    End Sub

    Private Function Fx_Tbl_Buscar_Productos(_Empresa As String,
                                             _Sucursal As String,
                                             _Bodega As String,
                                             _Lista As String,
                                             _Opcion_Buscar As _Opcion_Buscar,
                                             _Top As Integer) As DataTable

        Try


            Try : Application.DoEvents() : Catch ex As Exception : End Try


            Lbl_Cargando_Productos.Visible = True

            Dim _Filtro_Productos As String = Generar_Filtro_IN(_Tbl_Productos_Grilla, "", "Codigo", False, False, "'")

            If _Filtro_Productos = "()" Then
                _Filtro_Productos = String.Empty
            Else
                _Filtro_Productos = "And KOPR Not In " & _Filtro_Productos
            End If

            Dim _CondExtraProveedor As String = String.Empty

            If Not String.IsNullOrEmpty(Trim(_CodEntidad)) Then
                _CondExtraProveedor = "And Proveedor = '" & _CodEntidad & "' And Sucursal = '" & _CodSucEntidad & "'"
            End If

            Consulta_sql = My.Resources.Recursos_Productos_.BuscarProductoBusqEspecial

            Consulta_sql = Replace(Consulta_sql, "#Empresa#", _Empresa)
            Consulta_sql = Replace(Consulta_sql, "#Sucursal#", _Sucursal)
            Consulta_sql = Replace(Consulta_sql, "#Bodega#", _Bodega)
            Consulta_sql = Replace(Consulta_sql, "#Lista#", _Lista)
            Consulta_sql = Replace(Consulta_sql, "#Condicion_Proveedor_Lista#", _CondExtraProveedor)

            If (_Tabla_Lista Is Nothing) Then

                _Tabla_Lista = "Zw_ListaPreProducto"
                _Campo_PreUd1 = "Precio"
                _Campo_PreUd2 = "Precio2"

            End If

            Consulta_sql = Replace(Consulta_sql, "#Tabla_Lista#", _Tabla_Lista)
            Consulta_sql = Replace(Consulta_sql, "#CampoPrecioUd1#", _Campo_PreUd1)
            Consulta_sql = Replace(Consulta_sql, "#CampoPrecioUd2#", _Campo_PreUd2)

            If ChkMostrarOcultos.Checked Then
                Consulta_sql = Replace(Consulta_sql, "#Ocultos#", "")
            Else
                Consulta_sql = Replace(Consulta_sql, "#Ocultos#", "AND Mp.ATPR<>'OCU'")
            End If


            Dim _Descripcion_Busqueda As String
            Dim _Codigo_Buscqueda As String
            Dim _Contiene_Codigo As Boolean

            If Txtdescripcion.Text.Contains("+") Then

                Dim _Descripciom_Arr = Split(Txtdescripcion.Text, "+", 2)

                _Contiene_Codigo = True
                _Codigo_Buscqueda = _Descripciom_Arr(0)
                _Descripcion_Busqueda = _Descripciom_Arr(1)

            Else
                _Descripcion_Busqueda = Txtdescripcion.Text.Trim
            End If

            If Not IsNothing(_Row_Patente_rvm) Then
                _Descripcion_Busqueda += Space(1) & _Row_Patente_rvm.Item("DescripcionBusqueda")
            End If


            Dim _Sql_Filtro1 As String
            Dim _Sql_Filtro2 As String

            If _Opcion_Buscar = Frm_BkpPostBusquedaEspecial_Mt._Opcion_Buscar._Descripcion Then

                If _Contiene_Codigo Then

                    _Sql_Filtro2 = (CADENA_A_BUSCAR(_Codigo_Buscqueda, "Mp.KOPR LIKE '", "And"))
                    _Sql_Filtro2 = "And Mp.KOPR Like '" & _Sql_Filtro2 & "%'"

                End If

                If Not String.IsNullOrEmpty(_Descripcion_Busqueda) Then

                    Dim _Str_Busqueda = Split(_Descripcion_Busqueda, " ")

                    _Sql_Filtro1 = String.Empty

                    For Each _Des As String In _Str_Busqueda

                        Dim _Sql_Fl As String = CADENA_A_BUSCAR(RTrim$(_Des), "DescripcionBusqueda LIKE '%")

                        If Not String.IsNullOrEmpty(_Sql_Fl) Then
                            _Sql_Filtro1 += "And Mp.KOPR IN (Select Codigo From Zw_Prod_Asociacion" & vbCrLf &
                                            "Where DescripcionBusqueda LIKE '%" & _Sql_Fl & "%')" & vbCrLf

                        End If

                    Next

                End If

            Else

                Dim _CodigoPr As String = _Sql.Fx_Trae_Dato("TABCODAL", "KOPR",
                                                    "(KOPRAL = '" & TxtCodigo.Text & "' And KOEN = '') Or " & vbCrLf &
                                                    "(KOPR = '" & TxtCodigo.Text & "')")

                If Not String.IsNullOrEmpty(TxtCodigo.Text) Then

                    Dim _Sql_Fl As String = CADENA_A_BUSCAR(RTrim$(TxtCodigo.Text), "DescripcionBusqueda LIKE '%")

                    If Not String.IsNullOrEmpty(_Sql_Fl) Then

                        _Sql_Filtro1 = "And Mp.KOPR IN (Select KOPR From TABCODAL" & vbCrLf &
                                       "Where KOPR+KOPRAL LIKE '%" & _Sql_Fl & "%')" & vbCrLf

                    End If

                End If

            End If

            Dim _Bloquear As String

            Select Case _Bloqueados
                Case Enum_Bloquear.No_Bloquear
                    _Bloquear = String.Empty
                Case Enum_Bloquear.Compras
                    _Bloquear = "And Not COALESCE(Mp.BLOQUEAPR,'') IN ('C','T','X')"
                Case Enum_Bloquear.Ventas
                    _Bloquear = "And Not COALESCE(Mp.BLOQUEAPR,'') IN ('V','T','X')"
                Case Enum_Bloquear.Compras_y_Ventas
                    _Bloquear = "And Not COALESCE(Mp.BLOQUEAPR,'') IN ('C','V','T','X')"
                Case Enum_Bloquear.Compras_Ventas_y_Produccion
                    _Bloquear = "And Not COALESCE(Mp.BLOQUEAPR,'') IN ('C','V','T','X')"
                Case Enum_Bloquear.No_Bloqueados
                    _Bloquear = "And Mp.BLOQUEAPR = ''"
            End Select

            Consulta_sql = Replace(Consulta_sql, "#Bloquear", _Bloquear)
            Consulta_sql = Replace(Consulta_sql, "100", _Top)
            Consulta_sql = Replace(Consulta_sql, "#Sql_Filtro1#", _Sql_Filtro1)
            Consulta_sql = Replace(Consulta_sql, "#Sql_Filtro2#", _Sql_Filtro2)
            Consulta_sql = Replace(Consulta_sql, "Zw_Prod_Asociacion", _Global_BaseBk & "Zw_Prod_Asociacion")

            Dim _Sql_Query = String.Empty
            Dim _Sql_Stock_Dipnible = String.Empty

            For Each _Fila As DataRow In _Tbl_Bodegas.Rows

                Dim _Emp = Trim(_Fila.Item("EMPRESA"))
                Dim _Suc = Trim(_Fila.Item("KOSU"))
                Dim _Bod = Trim(_Fila.Item("KOBO"))

                Dim _Sigla = _Emp & _Suc & _Bod

                _Sql_Query +=
                            "ISNULL((SELECT TOP 1 Mt.STFI1 FROM MAEST Mt" & Space(1) &
                            "WHERE Mt.EMPRESA = '" & _Emp & "' AND Mt.KOSU = '" & _Suc & "' AND " & vbCrLf &
                            "Mt.KOBO = '" & _Bod & "' AND Mt.KOPR = Mp.KOPR),0) AS [STOCK_Ud1_" & _Sigla & "]," & vbCrLf

            Next

            Consulta_sql = Replace(Consulta_sql, "#Stock#", _Sql_Query)
            Consulta_sql = Replace(Consulta_sql, "#Stock_Disponible#", _Sql_Stock_Dipnible)

            _Filtro_Productos = String.Empty

            If Not IsNothing(_Tbl_Productos_Grilla) Then
                If CBool(_Tbl_Productos_Grilla.Rows.Count) Then
                    Dim _Ult_Kopr = _Tbl_Productos_Grilla.Rows(_Tbl_Productos_Grilla.Rows.Count - 1).Item("Codigo")
                    _Filtro_Productos = "And Mp.KOPR > '" & _Ult_Kopr & "'"
                End If
            End If

            _Filtro_Productos += vbCrLf & _Filtro_Sql_Extra

            If MostrarSoloServTecnico_ProIngreso Then

                Dim _Reg_ProdIngreso = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Tmp_Filtros_Busqueda", "Informe = 'ServicioTecnico' And Filtro = 'ProdIngreso'")

                If CBool(_Reg_ProdIngreso) Then
                    _Filtro_Productos = vbCrLf & "And Mp.KOPR In (Select Codigo From " & _Global_BaseBk & "Zw_Tmp_Filtros_Busqueda" & vbCrLf &
                                                        "Where (Informe = 'ServicioTecnico') AND (Filtro = 'ProdIngreso'))"
                End If

            End If

            If MostrarSoloServTecnico_ProServicio Then

                Dim _Reg_ProdServicio = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Tmp_Filtros_Busqueda", "Informe = 'ServicioTecnico' And Filtro = 'ProdServicio'")

                _Filtro_Productos = vbCrLf & "And Mp.KOPR In (Select Codigo From " & _Global_BaseBk & "Zw_Tmp_Filtros_Busqueda" & vbCrLf &
                                    "Where (Informe = 'ServicioTecnico') AND (Filtro = 'ProdServicio'))"

            End If

            Consulta_sql = Replace(Consulta_sql, "#Filtro_Productos#", _Filtro_Productos)

            If TraerTodosLosProductos Then
                Consulta_sql = Replace(Consulta_sql, "Inner Join MAEPREM Mpn On Mpn.EMPRESA = @Empresa And Mpn.KOPR = Mp.KOPR ", "")
            End If

            Dim _Tbl As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

            If Not CBool(_Tbl.Rows.Count) Then
                _Tbl = Nothing
            End If

            Return _Tbl

        Catch ex As Exception
            ' MsgBox(ex.Message)
        Finally
            Lbl_Cargando_Productos.Visible = False
        End Try

    End Function

    Sub Sb_Formato_Grilla()

        Sb_Formato_Generico_Grilla(Grilla, 18, New Font("Tahoma", 8), Color.White, ScrollBars.Vertical, True, True, _Seleccionar_Multiple)

        Chk_Top20.Visible = False

        With Grilla

            Try

                .DataSource = Nothing
                .DataSource = _Tbl_Productos_Grilla

                Dim _DisplayIndex = 0

                OcultarEncabezadoGrilla(Grilla, True)

                Dim _Largo_des As Integer = 340

                .Columns("Chk").Width = 30
                .Columns("Chk").HeaderText = "Sel"
                .Columns("Chk").Visible = _Seleccionar_Multiple
                .Columns("Chk").ReadOnly = False
                .Columns("Chk").DisplayIndex = _DisplayIndex
                .Columns("Chk").Frozen = True
                _DisplayIndex += 1

                If _Global_Es_Touch Then
                    .Columns("Codigo").Width = 170
                Else
                    .Columns("Codigo").Width = 100
                End If

                .Columns("Codigo").HeaderText = "Código"
                .Columns("Codigo").Visible = True
                .Columns("Codigo").DisplayIndex = _DisplayIndex
                .Columns("Codigo").Frozen = True
                _DisplayIndex += 1

                If _Mostrar_Info Then

                    .Columns("Descripcion").Width = _Largo_des + 20
                    .Columns("Descripcion").HeaderText = "Descripción"
                    .Columns("Descripcion").Visible = True
                    .Columns("Descripcion").DisplayIndex = _DisplayIndex
                    .Columns("Descripcion").Frozen = True
                    _DisplayIndex += 1

                    If _Mostrar_Precios Then

                        .Columns("Precio_Ud1").HeaderText = "Precio $"
                        .Columns("Precio_Ud1").Width = 80
                        .Columns("Precio_Ud1").DefaultCellStyle.Format = "$ ###,##0.##"
                        .Columns("Precio_Ud1").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Columns("Precio_Ud1").Visible = True
                        .Columns("Precio_Ud1").DisplayIndex = _DisplayIndex
                        .Columns("Precio_Ud1").Frozen = True
                        _DisplayIndex += 1

                    End If


                    For Each _Fila As DataRow In _Tbl_Bodegas.Rows

                        Dim _Emp = _Fila.Item("EMPRESA").ToString.Trim
                        Dim _Suc = _Fila.Item("KOSU").ToString.Trim
                        Dim _Bod = _Fila.Item("KOBO").ToString.Trim

                        Dim _Campo_Bod As String = "STOCK_Ud1_" & _Emp & _Suc & _Bod
                        Dim _Descr_Cam As String = "St.Bod. " & _Bod
                        Dim _Ancho = 60

                        If _Mostrar_Stock_Disponible Then
                            '_Campo_Bod = "STDiponible_Ud1_" & _Emp & _Suc & _Bod
                            _Descr_Cam = "St." & _Bod
                            .Columns(_Campo_Bod).ToolTipText = "Stock disponible bodega " & _Bod
                        End If

                        .Columns(_Campo_Bod).HeaderText = _Descr_Cam
                        .Columns(_Campo_Bod).Width = 60

                        .Columns(_Campo_Bod).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Columns(_Campo_Bod).DefaultCellStyle.Format = "##,###0.##"
                        .Columns(_Campo_Bod).Visible = True
                        .Columns(_Campo_Bod).DisplayIndex = _DisplayIndex
                        _DisplayIndex += 1

                    Next

                    .Columns("DATOSUBIC").HeaderText = "Ubicación Bod. " & ModBodega
                    .Columns("DATOSUBIC").Width = 100
                    .Columns("DATOSUBIC").Visible = True
                    .Columns("DATOSUBIC").DisplayIndex = _DisplayIndex
                    _DisplayIndex += 1

                Else

                    _Largo_des += 60 + 80 + 60 + 120

                    If _Global_Es_Touch Then
                        .Columns("Descripcion").Width = 520
                    Else
                        .Columns("Descripcion").Width = _Largo_des
                    End If

                    .Columns("Descripcion").HeaderText = "Descripción"
                    .Columns("Descripcion").Visible = True
                    .Columns("Descripcion").DisplayIndex = _DisplayIndex
                    _DisplayIndex += 1

                End If

                For Each row As DataGridViewRow In .Rows
                    Dim Pr_Oculto As Boolean = NuloPorNro(row.Cells("Oculto").Value, False)
                    If Pr_Oculto Then
                        row.DefaultCellStyle.ForeColor = Color.Red
                    End If
                Next

                If _Mostrar_Info Then
                    If _Mostrar_Precios Or _Mostrar_Stock_Disponible Then
                        _Cl_ActFxDinXProductos.Sb_Iniciar(_Tbl_Productos_Grilla, _ListaBusq, CirProg_Actualizando, _Mostrar_Stock_Disponible, _Tido_Stock, _Tbl_Bodegas)
                    End If
                End If

            Catch ex As Exception

            End Try

            Grilla.Refresh()

        End With

    End Sub

    Sub Sb_Formato_Grilla_Top20()

        Sb_Formato_Generico_Grilla(Grilla, 18, New Font("Tahoma", 8), Color.White, ScrollBars.Vertical, True, True, False)

        Chk_Top20.Visible = True

        With Grilla

            Try

                .DataSource = Nothing
                .DataSource = _Tbl_Top20

                Dim _DisplayIndex = 0

                OcultarEncabezadoGrilla(Grilla, True)

                Dim _Largo_des As Integer = 300

                .Columns("Porc").HeaderText = "Porc."
                .Columns("Porc").Width = 60
                .Columns("Porc").DefaultCellStyle.Format = "% ##,##0.##"
                .Columns("Porc").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns("Porc").Visible = True
                .Columns("Porc").DisplayIndex = _DisplayIndex
                .Columns("Porc").Frozen = True
                _DisplayIndex += 1

                If _Global_Es_Touch Then
                    .Columns("Codigo").Width = 170
                Else
                    .Columns("Codigo").Width = 100
                End If

                .Columns("Codigo").HeaderText = "Código"
                .Columns("Codigo").Visible = True
                .Columns("Codigo").DisplayIndex = _DisplayIndex
                .Columns("Codigo").Frozen = True
                _DisplayIndex += 1

                If _Mostrar_Info Then

                    .Columns("Descripcion").Width = _Largo_des + 20
                    .Columns("Descripcion").HeaderText = "Descripción"
                    .Columns("Descripcion").Visible = True
                    .Columns("Descripcion").DisplayIndex = _DisplayIndex
                    .Columns("Descripcion").Frozen = True
                    _DisplayIndex += 1

                    If _Mostrar_Precios Then

                        .Columns("Precio_Ud1").HeaderText = "Precio $"
                        .Columns("Precio_Ud1").Width = 80
                        .Columns("Precio_Ud1").DefaultCellStyle.Format = "$ ###,##0.##"
                        .Columns("Precio_Ud1").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Columns("Precio_Ud1").Visible = True
                        .Columns("Precio_Ud1").DisplayIndex = _DisplayIndex
                        .Columns("Precio_Ud1").Frozen = True
                        _DisplayIndex += 1

                    End If


                    For Each _Fila As DataRow In _Tbl_Bodegas.Rows

                        Dim _Emp = Trim(_Fila.Item("EMPRESA"))
                        Dim _Suc = Trim(_Fila.Item("KOSU"))
                        Dim _Bod = Trim(_Fila.Item("KOBO"))

                        Dim _Campo_Bod As String = "STOCK_Ud1_" & _Emp & _Suc & _Bod

                        .Columns(_Campo_Bod).HeaderText = "St.Bod. " & _Bod
                        .Columns(_Campo_Bod).Width = 60

                        .Columns(_Campo_Bod).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Columns(_Campo_Bod).DefaultCellStyle.Format = "##,###0.##"
                        .Columns(_Campo_Bod).Visible = True
                        .Columns(_Campo_Bod).DisplayIndex = _DisplayIndex
                        _DisplayIndex += 1

                    Next

                    .Columns("DATOSUBIC").HeaderText = "Ubicación Bod. " & ModBodega
                    .Columns("DATOSUBIC").Width = 100
                    .Columns("DATOSUBIC").Visible = True
                    .Columns("DATOSUBIC").DisplayIndex = _DisplayIndex
                    _DisplayIndex += 1

                Else

                    _Largo_des += 60 + 80 + 60 + 120

                    If _Global_Es_Touch Then
                        .Columns("Descripcion").Width = 520
                    Else
                        .Columns("Descripcion").Width = _Largo_des
                    End If

                    .Columns("Descripcion").HeaderText = "Descripción"
                    .Columns("Descripcion").Visible = True
                    .Columns("Descripcion").DisplayIndex = _DisplayIndex
                    _DisplayIndex += 1

                End If

                For Each row As DataGridViewRow In .Rows
                    Dim Pr_Oculto As Boolean = NuloPorNro(row.Cells("Oculto").Value, False)
                    If Pr_Oculto Then
                        row.DefaultCellStyle.ForeColor = Color.Red
                    End If
                Next

            Catch ex As Exception

            End Try

            'Btn_Seleccion_Multiple.Visible = _Seleccionar_Multiple
            'Btn_Marcar_Seleccionados.Visible = False
            'Btn_Desmarcar_Seleccionados.Visible = False

            .Refresh()

        End With

    End Sub

#End Region

    Private Sub Sb_Grilla_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs)

        Try

            Dim _Codigo = Trim(Grilla.Rows(Grilla.CurrentRow.Index).Cells("Codigo").Value)

            If e.KeyValue = Keys.Tab Then

                Txtdescripcion.SelectAll()
                Txtdescripcion.Focus()
                SendKeys.Send("{F2}")

            ElseIf e.KeyValue = Keys.Down Then

                Dim _Filas As Integer = Grilla.Rows.Count - 1
                Dim _FilaSelect As Integer = Grilla.CurrentRow.Index

                If _Filas = _FilaSelect Then

                    Sb_Buscar_Productos(ModEmpresa, _SucursalBusq, _BodegaBusq, _ListaBusq, False, _Opcion_Buscar._Descripcion)

                End If

            ElseIf e.KeyValue = Keys.Enter Then

                SendKeys.Send("{F2}")
                e.Handled = True

                If _Trabajar_Alternativos Then
                    Sb_Seleccionar_Producto_doble_clic_Alternativos()
                Else
                    If _Trabajar_Ubicaciones Then
                        Sb_Seleccionar_Producto_doble_clic_Ubicaciones()
                    Else
                        Sb_Seleccionar_Producto_doble_clic()
                    End If
                End If

            ElseIf e.KeyValue = Keys.Space Then

                Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

                _Fila.Cells("Chk").Value = Not _Fila.Cells("Chk").Value

            End If

        Catch ex As Exception
            Beep()
        End Try

    End Sub

    Sub Sb_Editar_Producto(_RowProducto As DataRow)

        Dim _Fila As DataGridViewRow = Grilla.CurrentRow

        Dim _Codigo = _RowProducto.Item("KOPR")

        Dim Fm As New Frm_MtCreacionDeProducto(Cl_Producto.Enum_Accion.Editar, _Codigo, False, False)
        Fm.BtnCodAlternativosProducto.Visible = True
        Fm.ShowDialog(Me)

        If Fm.Pro_Grabar Then

            Dim _Ficha As String

            Consulta_sql = "Select * From MAEFICHD Where KOPR = '" & _Codigo & "' Order by SEMILLA"

            Dim _Tbl_Maefichd As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

            For Each _Fichas As DataRow In _Tbl_Maefichd.Rows
                _Ficha += _Fichas.Item("FICHA")
            Next

            _Fila.Cells("Ficha").Value = _Ficha

            Beep()
            ToastNotification.Show(Me, "DATOS ACTUALIZADOS CORRECTAMENTE", My.Resources.ok_button,
                                   2 * 1000, eToastGlowColor.Green, eToastPosition.MiddleCenter)
            _Fila.Cells("Descripcion").Value = Fm.Txt_Nokopr.Text

            Txt_Ficha.Text = _Ficha

        End If

        Fm.Dispose()

    End Sub

    Sub Sb_Seleccionar_Producto_doble_clic()

        Dim _Cabeza = Grilla.Columns(Grilla.CurrentCell.ColumnIndex).Name

        If _Cabeza <> "Chk" Then

            Sb_Seleccionar_Producto_Para_Trasladar()

        End If

    End Sub

    Sub Sb_Seleccionar_Producto_Para_Trasladar()

        Dim _Codigo As String = Grilla.Rows(Grilla.CurrentRow.Index).Cells("Codigo").Value
        Dim _Prct As Boolean = Grilla.Rows(Grilla.CurrentRow.Index).Cells("Prct").Value

        If Not _Prct Then

            Consulta_sql = "Select * From MAEPR Where KOPR = '" & _Codigo & "'"
            _RowProducto = _Sql.Fx_Get_DataRow(Consulta_sql)

        End If

        If _Maestro_productos Then

            Sb_Editar_Producto(_RowProducto)

        Else

            _Codigo_Sel = _Codigo
            _Es_Conceto = _Prct

            _Seleccionado = True
            Me.Close()

        End If

    End Sub

    Sub Sb_Seleccionar_Producto_doble_clic_Alternativos()

        If Fx_Tiene_Permiso(Me, "Prod020") Then

            _Tbl_Producto_Seleccionado = Nothing

            Dim CodigoPr_Sel = Trim(Grilla.Rows(Grilla.CurrentRow.Index).Cells("Codigo").Value)

            Consulta_sql = "Select * From MAEPR Where KOPR = '" & CodigoPr_Sel & "'"
            _Tbl_Producto_Seleccionado = _Sql.Fx_Get_Tablas(Consulta_sql)

            Dim _Codigo As String = _Tbl_Producto_Seleccionado.Rows(0).Item("KOPR")

            If Not String.IsNullOrEmpty(Trim(_Codigo)) Then
                Dim Fm_A As New Frm_CodAlternativo_Ver
                Fm_A.TxtCodigo.Text = _Codigo
                Fm_A.Txtdescripcion.Text = _Tbl_Producto_Seleccionado.Rows(0).Item("NOKOPR")
                Fm_A.TxtRTU.Text = _Tbl_Producto_Seleccionado.Rows(0).Item("RLUD")
                Fm_A.ShowDialog(Me)

                If _Trabajar_Alternativos Then
                    TxtCodigo.SelectAll()
                    TxtCodigo.Focus()
                Else
                    Txtdescripcion.Text = CodigoPr_Sel
                    Txtdescripcion.SelectAll()
                    Txtdescripcion.Focus()
                End If

                BuscarDatoEnGrilla(Trim(_Codigo), "Codigo", Grilla)

                Fm_A.Dispose()

            End If
        End If
    End Sub

    Sub Sb_Seleccionar_Producto_doble_clic_Ubicaciones()

        Me.Enabled = False

        If Fx_Tiene_Permiso(Me, "Ubic0002") Then

            Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

            Dim _Codigo As String = _Fila.Cells("Codigo").Value
            Dim _Descripcion As String = _Fila.Cells("Descripcion").Value

            If Not String.IsNullOrEmpty(_Codigo) Then

                Dim Fr As New Frm_01_UbicXpro(_Codigo)
                Fr.ShowDialog(Me)
                Fr.Dispose()

            End If

        End If

        Me.Enabled = True

    End Sub

    Private Sub Txtdescripcion_KeyDown_1(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles Txtdescripcion.KeyDown

        If e.KeyValue = Keys.Down Then
            Grilla.Focus()
            Me.ActiveControl = Grilla ' Txtdescripcion
        End If

        If e.KeyValue = Keys.Return Then 'Or e.KeyValue = Keys.Space Then

            If _Text_Ultima_Busqueda <> Txtdescripcion.Text Then
                _Top = _Top_Filas

                Sb_Buscar_Productos(ModEmpresa, _SucursalBusq, _BodegaBusq, _ListaBusq, True, _Opcion_Buscar._Descripcion)

                If CBool(Grilla.RowCount) Then
                    Grilla.Focus()
                    Grilla.CurrentCell = Grilla.Rows(0).Cells("Codigo")
                End If

            End If

        End If

    End Sub

    Private Sub Frm_BkpPostBusquedaEspecial_Mt_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub Txtdescripcion_TextChanged(sender As System.Object, e As System.EventArgs) Handles Txtdescripcion.TextChanged
        If String.IsNullOrEmpty(Trim(Txtdescripcion.Text)) Then
            ' BUSCA()
            '_Cl_Buscar_Productos.Sb_Buscar_Productos(Txtdescripcion.Text, Class_BuscarProductos.Enum_Opcion_Buscar._Descripcion, ChkMostrarOcultos.Checked, True)
            Sb_Buscar_Productos(ModEmpresa, _SucursalBusq, _BodegaBusq, _ListaBusq, True, _Opcion_Buscar._Descripcion)
            Grilla.ClearSelection()
            GrillaBusquedaOtros.ClearSelection()
        End If
    End Sub

    Private Sub Txtdescripcion_Enter(sender As System.Object, e As System.EventArgs) Handles Txtdescripcion.Enter
        Grilla.ClearSelection()
        GrillaBusquedaOtros.ClearSelection()
    End Sub

    Private Sub VerClasificacionesToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs)
        If Fx_Tiene_Permiso(Me, "Prod021") Then
            Dim _Codigo = Grilla.Rows(Grilla.CurrentRow.Index).Cells("Codigo").Value
            Dim _Descripcion = Grilla.Rows(Grilla.CurrentRow.Index).Cells("Descripcion").Value

            Dim Fm As New Frm_MtCreaProd_01_IngBusqEspecial
            Fm.TxtCodigo.Text = _Codigo
            Fm.TxtDescripcion.Text = _Descripcion
            Fm.ShowDialog(Me)

            Grilla.Rows(Grilla.CurrentRow.Index).Cells("Descripcion").Value = Fm.TxtDescripcion.Text

        End If
    End Sub

    Enum Tipo_Doc
        Ninguno
        Compra
        Venta
    End Enum

    Sub Sb_Ver_Informacion_Adicional_producto(_Formulario As Form,
                                              _Codigo As String,
                                              Optional _Endo As String = "",
                                              Optional _Tipo_Doc As Tipo_Doc = Tipo_Doc.Ninguno)

        Dim _Row_Producto As DataRow = Fx_Row_Producto(_Formulario, _Codigo)

        If (_Row_Producto Is Nothing) Then
            Exit Sub
        End If

        If Fx_Tiene_Permiso(Me, "Prod009") Then

            Me.Cursor = Cursors.WaitCursor

            Dim Fm As New Frm_EstadisticaProducto(_Codigo, _Endo, _Tipo_Doc)
            Fm.ShowInTaskbar = True
            Fm.ShowDialog(Me)
            Fm.Dispose()

            Me.Cursor = Cursors.Default

        End If

    End Sub

    Sub Sb_Ver_Codigos_de_reemplazo(_Formulario As Form, _Codigo As String)

        Dim _Row_Producto As DataRow = Fx_Row_Producto(_Formulario, _Codigo)

        If (_Row_Producto Is Nothing) Then
            Exit Sub
        End If

        Dim Fm_R As New Frm_ProductosReemplazo(_Codigo)
        Fm_R.ShowDialog(Me)
        Fm_R.Dispose()

    End Sub

    Private Sub BtnBuscarAlternativos_Click(sender As System.Object, e As System.EventArgs) Handles BtnBuscarAlternativos.Click
        If Fx_Tiene_Permiso(Me, "Prod020") Then
            Dim Fm As New Frm_BuscarXProducto_Mt
            Fm.CodProveedor_productos = String.Empty
            Fm.Tipo_Busqueda_Productos = Fm.Buscar_En.Codigos_Alternativos
            Fm.ListaDePrecio = ModListaPrecioVenta
            Fm.CodProveedor_productos = String.Empty

            ' Dim Razon As String = _Sql.Fx_Trae_Dato(, "NOKOEN", "MAEEN", "KOEN = '" & CodProveedor_productos & "'")
            Fm.Text = "Busqueda de códigos alternativos" ' & " - " & Razon

            Fm.ShowDialog(Me)

            Txtdescripcion.Text = Fm.CodigoPr_Sel

            Sb_Buscar_Productos(ModEmpresa, _SucursalBusq, _BodegaBusq, _ListaBusq, True, _Opcion_Buscar._Descripcion)
            Grilla.ClearSelection()
            GrillaBusquedaOtros.ClearSelection()
        End If
    End Sub

    Private Sub BtnExportaExcel_Click_1(sender As System.Object, e As System.EventArgs) Handles BtnExportaExcel.Click
        Consulta_sql = "Select * From MAEPR"
        ExportarTabla_JetExcel_Old(Consulta_sql, Me, "Maestro productos")
    End Sub

    Private Sub BtnCrearProductos_Click(sender As System.Object, e As System.EventArgs) Handles BtnCrearProductos.Click
        Sb_Crear_Nuevo_Producto()
    End Sub

    Sub Sb_Crear_Nuevo_Producto()

        If Fx_Tiene_Permiso(Me, "Prod013") Then

            Dim Fm As New Frm_MtCreacionDeProducto(Cl_Producto.Enum_Accion.Nuevo, "", False, False)
            Fm.ShowDialog(Me)

            If Fm.Pro_Grabar Then
                Txtdescripcion.Text = Fm.Pro_RowProducto.Item("KOPR")
                Sb_Buscar_Productos(ModEmpresa, _SucursalBusq, _BodegaBusq, _ListaBusq, True, _Opcion_Buscar._Descripcion)
            End If

            Fm.Dispose()

        End If

    End Sub

    Private Sub BtnEditarProducto_Click(sender As System.Object, e As System.EventArgs)
        Sb_Seleccionar_Producto_doble_clic()
    End Sub

    Private Sub BtnEliminarProducto_Click(sender As System.Object, e As System.EventArgs)
        Sb_Eliminar_Producto()
    End Sub

    Sub Sb_Eliminar_Producto()

        Dim _Codigo = Grilla.Rows(Grilla.CurrentRow.Index).Cells("Codigo").Value
        Dim _Descripcion = Grilla.Rows(Grilla.CurrentRow.Index).Cells("Descripcion").Value

        If Fx_Eliminar_Producto(_Codigo, _Descripcion) Then

            Grilla.Rows.RemoveAt(Grilla.CurrentRow.Index)
            MessageBoxEx.Show(Me, "Producto eliminado correctamente",
                              "Eliminar producto", MessageBoxButtons.OK, MessageBoxIcon.Information)

            If _Global_Row_Configuracion_General.Item("PermitirMigrarProductosBaseExterna") Then

                Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_DbExt_Conexion Where GrbProd_Nuevos = 1"
                Dim _Tbl_Conexiones As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

                For Each _FilaCx As DataRow In _Tbl_Conexiones.Rows

                    Dim _Id_Conexion As Integer = _FilaCx.Item("Id")
                    Dim _BaseDeDatos As String = _FilaCx.Item("BaseDeDatos")
                    Dim _Cl_Migrar_Producto As New Bk_Migrar_Producto.Cl_ConexionExterna

                    Dim _ConexionExternas As New Bk_Migrar_Producto.ConexionExternas

                    _ConexionExternas = _Cl_Migrar_Producto.Fx_CadenaConexionServExt(_Id_Conexion)

                    If _ConexionExternas.EsCorrecto Then

                        Dim _Sql2 = New Class_SQL(_ConexionExternas.Cadena_ConexionSQL_Server_Ext)

                        If _ConexionExternas.SincroProductos Then

                            Dim _Reg = _Sql2.Fx_Cuenta_Registros("MAEPR", "KOPR = '" & _Codigo & "'")

                            If CBool(_Reg) Then

                                Dim _Cl_EliminaProd As New Cl_EliminaProd

                                _Cl_EliminaProd = Fx_Eliminar_Producto_BaseExterna(_Codigo,
                                                                                   _ConexionExternas.Cadena_ConexionSQL_Server_Ext,
                                                                                   _ConexionExternas.Global_BaseBk)

                                If _Cl_EliminaProd.EsCorrecto Then
                                    MessageBoxEx.Show(Me, "Producto eliminado correctamente en la base de datos externa" & vbCrLf &
                                                      "Base de datos: " & _BaseDeDatos,
                                                      "Eliminar producto en base externa", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                Else

                                    Dim _Msg As String

                                    For Each _Error As String In _Cl_EliminaProd.Problemas
                                        _Msg += _Error & vbCrLf
                                    Next

                                    MessageBoxEx.Show(Me, "No se pudo eliminar el producto de la base de datos externa" & vbCrLf &
                                                      "Base de datos: " & _BaseDeDatos & vbCrLf & vbCrLf & _Msg,
                                                      "Eliminar producto en base externa",
                                                      MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                End If

                            End If

                        End If

                    Else
                        MessageBoxEx.Show(Me, "No fue posible editar el producto en base de datos externa" & vbCrLf & vbCrLf &
                                                  "Base de datos: " & _BaseDeDatos & vbCrLf & vbCrLf &
                                                  _ConexionExternas.MensajeError, "Editar producto en base externa",
                                                  MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    End If

                Next

            End If

            Sb_Buscar_Productos(ModEmpresa, _SucursalBusq, _BodegaBusq, _ListaBusq, True, _Opcion_Buscar._Descripcion)

        End If

    End Sub

    Function Fx_Eliminar_Producto(_Codigo_a_eliminar As String,
                                  _Descripcion As String)

        If Fx_Tiene_Permiso(Me, "Prod015") Then

            Dim _Maeddo As Long = _Sql.Fx_Cuenta_Registros("MAEDDO", "KOPRCT = '" & _Codigo_a_eliminar & "'")
            Dim _Tabcodal As Long = _Sql.Fx_Cuenta_Registros("TABCODAL", "KOPR = '" & _Codigo_a_eliminar & "'")
            Dim _Potd As Long = _Sql.Fx_Cuenta_Registros("POTD", "CODIGO = '" & _Codigo_a_eliminar & "'")
            Dim _Kasiddo As Long = _Sql.Fx_Cuenta_Registros("KASIDDO", "KOPRCT = '" & _Codigo_a_eliminar & "'")


            If CBool(_Maeddo) Then
                MessageBoxEx.Show(Me, "Producto está  presente en documentos de Gestión", "PRODUCTO NO PUEDE SER ELIMINADO",
                              MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return False
            End If

            If CBool(_Potd) Then
                MessageBoxEx.Show(Me, "Producto está  presente en documentos de Producción", "PRODUCTO NO PUEDE SER ELIMINADO",
                              MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return False
            End If

            If CBool(_Kasiddo) Then
                MessageBoxEx.Show(Me, "Producto está presente en documentos de Gestión (Documentos reciclados)", "PRODUCTO NO PUEDE SER ELIMINADO",
                              MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return False
            End If


            If CBool(_Tabcodal) Then
                If MessageBoxEx.Show(Me, "Este producto tiene códigos alternativos asociados" & vbCrLf &
                                "¿Desea continuar con la eliminación?", "PRODUCTO NO PUEDE SER ELIMINADO",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.No Then
                    Return False
                End If
            End If

            If MessageBoxEx.Show(Me, "¿Está seguro de eliminar este producto?" & vbCrLf & Trim(_Codigo_a_eliminar) & " - " & Trim(_Descripcion),
                                 "Eliminar producto",
                                 MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                Consulta_sql = "DELETE " & _Global_BaseBk & "Zw_ListaPreCosto WHERE (Codigo = '') AND (CodAlternativo = '')"
                _Sql.Ej_consulta_IDU(Consulta_sql)

                Consulta_sql = "DELETE PDIMEN    WHERE CODIGO ='" & _Codigo_a_eliminar & "'" & vbCrLf &
                               "DELETE MAEPROBS  WHERE KOPR   ='" & _Codigo_a_eliminar & "'" & vbCrLf &
                               "DELETE MAEFICHA  WHERE KOPR   ='" & _Codigo_a_eliminar & "'" & vbCrLf &
                               "DELETE MAEFICHD  WHERE KOPR   ='" & _Codigo_a_eliminar & "'" & vbCrLf &
                               "DELETE TABIMPR   WHERE KOPR   ='" & _Codigo_a_eliminar & "'" & vbCrLf &
                               "DELETE TABPRE    WHERE KOPR   ='" & _Codigo_a_eliminar & "'" & vbCrLf &
                               "DELETE TABBOPR   WHERE KOPR   ='" & _Codigo_a_eliminar & "'" & vbCrLf &
                               "DELETE MPROENVA  WHERE KOPR   ='" & _Codigo_a_eliminar & "'" & vbCrLf &
                               "DELETE MAEPREM   WHERE KOPR   ='" & _Codigo_a_eliminar & "'" & vbCrLf &
                               "DELETE MAEPR     WHERE KOPR   ='" & _Codigo_a_eliminar & "'" & vbCrLf &
                               "DELETE TABCODAL  WHERE KOPR   ='" & _Codigo_a_eliminar & "'" & vbCrLf &
                               "DELETE " & _Global_BaseBk & "Zw_ListaPreCosto WHERE Codigo ='" & _Codigo_a_eliminar & "' And Proveedor = ''" & vbCrLf &
                               "DELETE " & _Global_BaseBk & "Zw_ListaPreProducto WHERE Codigo ='" & _Codigo_a_eliminar & "'" & vbCrLf &
                               "DELETE " & _Global_BaseBk & "Zw_Prod_Asociacion WHERE Codigo ='" & _Codigo_a_eliminar & "'" & vbCrLf &
                               "DELETE " & _Global_BaseBk & "Zw_Prod_Dimensiones WHERE Codigo ='" & _Codigo_a_eliminar & "'" & vbCrLf &
                               "UPDATE " & _Global_BaseBk & "Zw_ListaPreCosto Set Codigo = '', Descripcion = ''" & Space(1) &
                               "WHERE  Codigo = '" & _Codigo_a_eliminar & "' AND Proveedor <> ''" & vbCrLf &
                               "DELETE " & _Global_BaseBk & "Zw_Prod_Asociacion Where Codigo = '" & _Codigo_a_eliminar & "' And Producto = 1"

                Return _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql)

            End If

        End If

    End Function


    Function Fx_Eliminar_Producto_BaseExterna(_Codigo_a_eliminar As String,
                                              _Cadena_ConexionSQL_Server_Externa As String,
                                              _Global_BaseBk_Externa As String) As Cl_EliminaProd

        Dim _Sql As New Class_SQL(_Cadena_ConexionSQL_Server_Externa)

        Dim _Cl_EliminaProd As New Cl_EliminaProd

        _Cl_EliminaProd.EsCorrecto = True
        _Cl_EliminaProd.Problemas = New List(Of String)

        Dim _Maeddo As Long = _Sql.Fx_Cuenta_Registros("MAEDDO", "KOPRCT = '" & _Codigo_a_eliminar & "'")
        Dim _Tabcodal As Long = _Sql.Fx_Cuenta_Registros("TABCODAL", "KOPR = '" & _Codigo_a_eliminar & "'")
        Dim _Potd As Long = _Sql.Fx_Cuenta_Registros("POTD", "CODIGO = '" & _Codigo_a_eliminar & "'")
        Dim _Kasiddo As Long = _Sql.Fx_Cuenta_Registros("KASIDDO", "KOPRCT = '" & _Codigo_a_eliminar & "'")

        If CBool(_Maeddo) Then
            _Cl_EliminaProd.EsCorrecto = False
            _Cl_EliminaProd.Problemas.Add("* Producto está presente en documentos de Gestión")
        End If

        If CBool(_Potd) Then
            _Cl_EliminaProd.EsCorrecto = False
            _Cl_EliminaProd.Problemas.Add("* Producto está presente en documentos de Producción")
        End If

        If CBool(_Kasiddo) Then
            _Cl_EliminaProd.EsCorrecto = False
            _Cl_EliminaProd.Problemas.Add("* Producto está presente en documentos de Gestión (Documentos reciclados)")
        End If

        Consulta_sql = "DELETE " & _Global_BaseBk_Externa & "Zw_ListaPreCosto WHERE (Codigo = '') AND (CodAlternativo = '')" & vbCrLf &
                        "DELETE PDIMEN    WHERE CODIGO ='" & _Codigo_a_eliminar & "'" & vbCrLf &
                        "DELETE MAEPROBS  WHERE KOPR   ='" & _Codigo_a_eliminar & "'" & vbCrLf &
                        "DELETE MAEFICHA  WHERE KOPR   ='" & _Codigo_a_eliminar & "'" & vbCrLf &
                        "DELETE MAEFICHD  WHERE KOPR   ='" & _Codigo_a_eliminar & "'" & vbCrLf &
                        "DELETE TABIMPR   WHERE KOPR   ='" & _Codigo_a_eliminar & "'" & vbCrLf &
                        "DELETE TABPRE    WHERE KOPR   ='" & _Codigo_a_eliminar & "'" & vbCrLf &
                        "DELETE TABBOPR   WHERE KOPR   ='" & _Codigo_a_eliminar & "'" & vbCrLf &
                        "DELETE MPROENVA  WHERE KOPR   ='" & _Codigo_a_eliminar & "'" & vbCrLf &
                        "DELETE MAEPREM   WHERE KOPR   ='" & _Codigo_a_eliminar & "'" & vbCrLf &
                        "DELETE MAEPR     WHERE KOPR   ='" & _Codigo_a_eliminar & "'" & vbCrLf &
                        "DELETE TABCODAL  WHERE KOPR   ='" & _Codigo_a_eliminar & "'" & vbCrLf &
                        "DELETE " & _Global_BaseBk_Externa & "Zw_ListaPreCosto WHERE Codigo ='" & _Codigo_a_eliminar & "' And Proveedor = ''" & vbCrLf &
                        "DELETE " & _Global_BaseBk_Externa & "Zw_ListaPreProducto WHERE Codigo ='" & _Codigo_a_eliminar & "'" & vbCrLf &
                        "DELETE " & _Global_BaseBk_Externa & "Zw_Prod_Asociacion WHERE Codigo ='" & _Codigo_a_eliminar & "'" & vbCrLf &
                        "DELETE " & _Global_BaseBk_Externa & "Zw_Prod_Dimensiones WHERE Codigo ='" & _Codigo_a_eliminar & "'" & vbCrLf &
                        "UPDATE " & _Global_BaseBk_Externa & "Zw_ListaPreCosto Set Codigo = '', Descripcion = ''" & Space(1) &
                        "WHERE  Codigo = '" & _Codigo_a_eliminar & "' AND Proveedor <> ''" & vbCrLf &
                        "DELETE " & _Global_BaseBk_Externa & "Zw_Prod_Asociacion Where Codigo = '" & _Codigo_a_eliminar & "' And Producto = 1"

        _Cl_EliminaProd.SqlQueruDelete = Consulta_sql

        If _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql) Then
            _Cl_EliminaProd.EsCorrecto = True
        Else
            _Cl_EliminaProd.EsCorrecto = False
            _Cl_EliminaProd.Problemas.Add(_Sql.Pro_Error)
        End If

        Return _Cl_EliminaProd

    End Function

    Sub Sb_Mostrar_Class(_Codigo As String)

        Consulta_sql = "Select Distinct Zw1.Codigo_Nodo,(Select Descripcion From " & _Global_BaseBk & "Zw_TblArbol_Asociaciones Zw2" & vbCrLf &
                       "Where Zw2.Codigo_Nodo = Zw1.Codigo_Nodo) As Descripcion From " & _Global_BaseBk & "Zw_Prod_Asociacion Zw1" & vbCrLf &
                       "Where Zw1.Codigo = '" & _Codigo & "' And Zw1.Codigo_Nodo In " & vbCrLf &
                       "(Select Codigo_Nodo From " & _Global_BaseBk & "Zw_TblArbol_Asociaciones Where Es_Seleccionable = 1)" & vbCrLf &
                       "And Zw1.Clas_unica = 0"
        Dim _TblClass As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)


        Dim dt As New DataTable("Tabla1")
        Dim dr As DataRow
        Dim rs As New DataSet("Ds")

        dt.Columns.Add("Codigo_Nodo", System.Type.[GetType]("System.String"))
        dt.Columns.Add("Clasificacion", System.Type.[GetType]("System.String"))

        For Each _Fila As DataRow In _TblClass.Rows
            Dim _Codigo_Nodo = _Fila.Item("Codigo_Nodo")
            Dim _Descripcion_B As String = Fx_Raiz_Clasificacion_FullPath(_Codigo_Nodo) & "\" & _Fila.Item("Descripcion")
            dr = dt.NewRow() : dr("Codigo_Nodo") = _Codigo_Nodo : dr("Clasificacion") = _Descripcion_B : dt.Rows.Add(dr)

        Next
        rs.Tables.Add(dt)

        With GrillaBusquedaOtros

            .DataSource = dt
            OcultarEncabezadoGrilla(GrillaBusquedaOtros, True)

            .Columns("Clasificacion").Width = 740
            .Columns("Clasificacion").HeaderText = "Descripción de clasificación"
            .Columns("Clasificacion").Visible = True

        End With
    End Sub

    Function Fx_Raiz_Clasificacion_FullPath(_Codigo_Nodo As String)

        Dim _Full As String = String.Empty
        Dim _CodPadre As String

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_TblArbol_Asociaciones Where Codigo_Nodo = " & _Codigo_Nodo
        Dim _Tbl As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        _CodPadre = _Tbl.Rows(0).Item("Identificacdor_NodoPadre")

        Do While (_CodPadre <> 0)

            Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_TblArbol_Asociaciones Where Codigo_Nodo = " & _CodPadre
            _Tbl = _Sql.Fx_Get_Tablas(Consulta_sql)

            _CodPadre = _Tbl.Rows(0).Item("Identificacdor_NodoPadre")
            _Full = "\" & _Tbl.Rows(0).Item("Descripcion") & _Full

        Loop

        Return _Full

    End Function

    Private Sub Grilla_Enter(sender As System.Object, e As System.EventArgs) Handles Grilla.Enter
        Bar_Menu_Producto.Enabled = True
        'Btn_Seleccionar.Enabled = True
        Me.Refresh()
    End Sub

    Private Sub Grilla_Leave(sender As System.Object, e As System.EventArgs) Handles Grilla.Leave
        Bar_Menu_Producto.Enabled = False
        'Btn_Seleccionar.Enabled = False
        Me.Refresh()
    End Sub

    Sub Sb_Imagen_Producto()

        Dim _Codigo = Trim(Grilla.Rows(Grilla.CurrentRow.Index).Cells("Codigo").Value)

        Dim Fm As New Frm_Imagenes_X_Producto(_Codigo)
        If Fm.Fx_Llenar_Grilla_Imagenes Then
            Fm.ShowDialog(Me)
        Else
            Beep()
            ToastNotification.Show(Me, "NO EXITEN IMAGENES PARA EL PRODUCTO", My.Resources.cross,
                                   1 * 1000, eToastGlowColor.Red, eToastPosition.MiddleCenter)
        End If

        Fm.Dispose()

    End Sub

    Private Sub ChkMostrarOcultos_CheckedChanged(sender As System.Object, e As DevComponents.DotNetBar.CheckBoxChangeEventArgs) Handles ChkMostrarOcultos.CheckedChanged

        If Not Fx_Tiene_Permiso(Me, "Prod004") Then
            ChkMostrarOcultos.Checked = False
        End If

        Sb_Buscar_Productos(ModEmpresa, _SucursalBusq, _BodegaBusq, _ListaBusq, True, _Opcion_Buscar._Descripcion)
        If CBool(Grilla.RowCount) Then Grilla.Focus()

    End Sub

    Sub Sb_Ejecutar_Ecuacion_Dinamica(_Fila As DataGridViewRow)

        Dim _Ecuacion = _Fila.Cells("Ecuacion_Ud1").Value
        Dim _Precio As Double

        If Not String.IsNullOrEmpty(Trim(_Ecuacion)) Then

            If Trim(_Ecuacion) = Trim(LCase(_Ecuacion)) Then

                Dim _Tiene_C As Boolean = InStr(1, _Ecuacion, "<")
                Dim _Tiene_Cor As Boolean = InStr(1, _Ecuacion, "[")

                If Not _Tiene_C Then

                    If Not _Tiene_Cor Then

                        Dim _Codigo = _Fila.Cells("Codigo").Value
                        Consulta_sql = "Select Top 1 *," & vbCrLf &
                                       "(Select top 1 MELT From TABPP Where KOLT = '" & _ListaBusq & "') as MELT" & Space(1) &
                                       "From TABPRE" & Space(1) &
                                       "Where KOLT = '" & _ListaBusq & "' And KOPR = '" & _Codigo & "'"

                        Dim _RowPrecio As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

                        _Precio = Fx_Precio_Formula_Random(_RowPrecio, "PP01UD", "ECUACION", Nothing, True, "", 1, 1)
                        _Fila.Cells("Precio_UD1").Value = _Precio
                        _Fila.Cells("Ecuacion_Generada").Value = True

                        'Consulta_sql = "Update TABPRE Set PP01UD = " & De_Num_a_Tx_01(_Precio, False, 5) & vbCrLf &
                        '               "Where KOLT = '" & _ListaBusq & "' And KOPR = '" & _Codigo & "'"
                        '_Sql.Ej_consulta_IDU(Consulta_sql, False)

                    End If

                End If

            End If

        End If


    End Sub

    Sub Sb_Ejecutar_Ecuacion_Dinamica(_Fila As DataRow)

        Dim _Ecuacion = _Fila.Item("Ecuacion_Ud1")
        Dim _Precio As Double

        If Not String.IsNullOrEmpty(Trim(_Ecuacion)) Then

            If Trim(_Ecuacion) = Trim(LCase(_Ecuacion)) Then

                Dim _Tiene_C As Boolean = InStr(1, _Ecuacion, "<")
                Dim _Tiene_Cor As Boolean = InStr(1, _Ecuacion, "[")

                If Not _Tiene_C Then

                    If Not _Tiene_Cor Then

                        Dim _Codigo = _Fila.Item("Codigo")
                        Consulta_sql = "Select Top 1 *," & vbCrLf &
                                       "(Select top 1 MELT From TABPP Where KOLT = '" & _ListaBusq & "') as MELT" & Space(1) &
                                       "From TABPRE" & Space(1) &
                                       "Where KOLT = '" & _ListaBusq & "' And KOPR = '" & _Codigo & "'"

                        Dim _RowPrecio As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

                        _Precio = Fx_Precio_Formula_Random(_RowPrecio, "PP01UD", "ECUACION", Nothing, True, "", 1, 1)
                        _Fila.Item("Precio_UD1") = _Precio
                        _Fila.Item("Ecuacion_Generada") = True

                    End If

                End If

            End If

        End If


    End Sub

    Private Sub Sb_Grilla_CellEnter(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs)

        Try

            If _Tipo_Lista = "P" Then

                If CBool(Grilla.Rows.Count) Then

                    Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)
                    Dim _Indice As Integer = Grilla.CurrentRow.Index

                    Dim _Ecuacion_Generada_ As Boolean = _Fila.Cells("Ecuacion_Generada").Value

                    If Not _Ecuacion_Generada_ Then

                        Try

                            _Ecuacion_Generada_ = _Fila.Cells("Ecuacion_Generada").Value

                            If Not _Ecuacion_Generada_ Then Sb_Ejecutar_Ecuacion_Dinamica(_Fila)

                        Catch ex As Exception

                        End Try

                    End If

                End If

            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub BtnBuscarListaCostosProveedor_Click(sender As System.Object, e As System.EventArgs) Handles BtnBuscarListaCostosProveedor.Click
        _Buscar_Lista_Proveedor = True
        Me.Close()
    End Sub

    Sub Sb_Ver_Kardex_Inventario(_Formulario As Form, _Codigo As String)

        If Fx_Tiene_Permiso(Me, "Prod002") Then
            Dim _Row_Producto As DataRow = Fx_Row_Producto(_Formulario, _Codigo)

            If (_Row_Producto Is Nothing) Then
                Exit Sub
            End If

            Dim Fm As New Frm_Kardex_X_Producto_Lista
            Fm.Pro_Codigo = _Codigo

            If _Row_Producto.Item("ATPR") = "OCU" Then
                Fm.ChkMostrarOcultos.Checked = True
            Else
                Fm.ChkMostrarOcultos.Checked = False
            End If

            Fm.ShowDialog(_Formulario)
            Fm.Dispose()

        End If

    End Sub

    Sub Sb_Ver_Clasificaciones_del_producto(_Formulario As Form, _Codigo As String)

        Dim _Row_Producto As DataRow = Fx_Row_Producto(_Formulario, _Codigo)

        If (_Row_Producto Is Nothing) Then
            Exit Sub
        End If

        Dim Fm As New Frm_Arbol_Asociacion_01
        Fm.Pro_CheckBoxes_Nodos = False
        Fm.Pro_Codigo_Producto = _Codigo
        Fm.ShowDialog(_Formulario)
        Fm.Dispose()

    End Sub

    Sub Sb_Ver_Asociaciones_del_producto(_Formulario As Form, _Codigo As String)

        If Fx_Tiene_Permiso(Me, "Prod056") Then

            Dim _Nodo_Raiz_Asociados = _Global_Row_Configuracion_General.Item("Nodo_Raiz_Asociados")
            Dim _Row_Nodo_Clasificaciones As DataRow

            Consulta_sql = "SELECT Top 1 * From " & _Global_BaseBk & "Zw_Prod_Asociacion" & vbCrLf &
                           "Where (Codigo = '" & _Codigo & "') AND (Para_filtro = 1)" & vbCrLf &
                           "And Codigo_Nodo In (Select Codigo_Nodo From " & _Global_BaseBk & "Zw_TblArbol_Asociaciones Where Nodo_Raiz = " & _Nodo_Raiz_Asociados & ")"

            _Row_Nodo_Clasificaciones = _Sql.Fx_Get_DataRow(Consulta_sql)

            Dim _Codigo_Nodo As Integer

            If _Row_Nodo_Clasificaciones Is Nothing Then
                _Codigo_Nodo = 0
            Else
                _Codigo_Nodo = _Row_Nodo_Clasificaciones.Item("Codigo_Nodo")
            End If

            Consulta_sql = "Select Top 1 * From " & _Global_BaseBk & "Zw_TblArbol_Asociaciones Where Codigo_Nodo = " & _Codigo_Nodo
            _Row_Nodo_Clasificaciones = _Sql.Fx_Get_DataRow(Consulta_sql)

            Consulta_sql = "Select KOPR From MAEPR Where KOPR In (Select Codigo From " & _Global_BaseBk & "Zw_Prod_Asociacion" & Space(1) &
                           "Where Codigo_Nodo = " & _Codigo_Nodo & " And Codigo_Nodo <> 0)" & Space(1) &
                           "--AND KOPR <> '" & _Codigo & "'"

            Dim _Tbl_Productos_Hermanos = _Sql.Fx_Get_Tablas(Consulta_sql)

            If CBool(_Tbl_Productos_Hermanos.Rows.Count) Then

                _Codigo_Nodo = _Row_Nodo_Clasificaciones.Item("Codigo_Nodo")

                Dim _Identificador_NodoPadre = _Row_Nodo_Clasificaciones.Item("Codigo_Nodo")
                Dim _FullPath = String.Empty
                Dim _Es_Seleccionable = _Row_Nodo_Clasificaciones.Item("Es_Seleccionable")
                Dim _Clas_Unica_X_Producto = _Row_Nodo_Clasificaciones.Item("Clas_Unica_X_Producto")
                Dim _Descripcion = _Row_Nodo_Clasificaciones.Item("Descripcion")
                Dim _Codigo_Madre = _Row_Nodo_Clasificaciones.Item("Codigo_Madre")

                Dim Fm As New Frm_Arbol_Asociacion_04_Productos_x_class(_Identificador_NodoPadre,
                                                                        _Codigo_Nodo,
                                                                        _Descripcion,
                                                                        _FullPath,
                                                                        _Es_Seleccionable,
                                                                        _Clas_Unica_X_Producto,
                                                                        False)
                Fm.Pro_Codigo_Heredado = _Codigo
                Fm.Text = "Clas: (Cód. " & _Codigo_Nodo & ") (Cód.Madre: " & _Codigo_Madre & ") " & _Descripcion
                Fm.ShowDialog(_Formulario)
                Fm.Dispose()

            Else
                MessageBoxEx.Show(_Formulario, "No existen productos asociados a este articulo", "Productos asociados", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If

        End If

    End Sub

    Private Function Fx_Row_Producto(_Formulario As Form, _Codigo As String) As DataRow

        Consulta_sql = "Select top 1 * From MAEPR Where KOPR = '" & _Codigo & "'"

        Dim _TblProducto As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        If CBool(_TblProducto.Rows.Count) Then
            Return _TblProducto.Rows(0)
        Else
            MessageBoxEx.Show(_Formulario, "Producto no existe en la base de datos", "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        End If

    End Function

    Sub Sb_Mantencion_Clasificacion_Codigos(_Formulario As Form, _Codigo As String)

        Dim _Row_Producto As DataRow = Fx_Row_Producto(_Formulario, _Codigo)

        If (_Row_Producto Is Nothing) Then
            Exit Sub
        End If

        If Fx_Tiene_Permiso(Me, "Prod021") Then
            Dim Fm As New Frm_MtCreaProd_01_IngBusqEspecial
            Fm.TxtCodigo.Text = _Codigo
            Fm.TxtDescripcion.Text = _Row_Producto.Item("NOKOPR")

            Fm.ShowDialog(_Formulario)
            Fm.Dispose()
        End If

    End Sub

    Sub Sb_Llena_Combo_CantFilas()

        caract_combo(CmbCantFilas)

        Dim dt As New DataTable("Tabla1")
        Dim dr As DataRow
        Dim rs As New DataSet("Ds")

        'creamos las mismas columnas que hay en el dataset
        dt.Columns.Add("Padre", System.Type.[GetType]("System.String"))
        dt.Columns.Add("Hijo", System.Type.[GetType]("System.String"))
        ',,,,,,

        dr = dt.NewRow() : dr("Padre") = "TOP 100" : dr("Hijo") = "100" : dt.Rows.Add(dr)
        dr = dt.NewRow() : dr("Padre") = "TOP 500" : dr("Hijo") = "500" : dt.Rows.Add(dr)
        dr = dt.NewRow() : dr("Padre") = "TOP 1000" : dr("Hijo") = "1.000" : dt.Rows.Add(dr)
        dr = dt.NewRow() : dr("Padre") = "TOP 2000" : dr("Hijo") = "2.000" : dt.Rows.Add(dr)
        'cerramos el datareader y la conexión
        'añadimos la tabla al dataset
        rs.Tables.Add(dt)

        With CmbCantFilas
            .DataSource = Nothing
            .DataSource = dt
        End With

    End Sub

    Sub Mnu_Sb_Cambiar_Codigo()

        If Fx_Tiene_Permiso(Me, "Prod003") Then

            Dim _Fila As DataGridViewRow = Grilla.CurrentRow
            Dim _Codigo As String = _Fila.Cells("Codigo").Value
            Dim _Codigo_Tecnico As String = _Fila.Cells("Codigo_Tecnico").Value
            Dim _Descripcion As String = _Fila.Cells("Descripcion").Value

            Dim Fm As New Frm_Cambio_Codigos_UnoxUno
            Fm.Txt_Codigo_Old.Text = _Codigo
            Fm.Txt_Descripcion.Text = _Descripcion
            Fm.Txt_Codigo_Tecnico_Old.Text = _Codigo_Tecnico
            Fm.Txt_Codigo_Tecnico_New.Text = _Codigo_Tecnico
            Fm._Cerrar_al_cambiar = True
            Fm.ShowDialog(Me)

            If Fm._CodigoCambiado Then
                _Fila.Cells("Codigo").Value = Fm.Txt_Codigo_New.Text
                Beep()
                ToastNotification.Show(Me, "CODIGO CAMBIADO CORRECTAMENTE", My.Resources.ok_button,
                                       1 * 1000, eToastGlowColor.Green, eToastPosition.MiddleCenter)
            End If
            Fm.Dispose()
        End If

    End Sub

    Sub Sb_Ver_Ubicacion_Bodega(_Formulario As Form, _Codigo As String,
                                _Empresa As String, _Sucursal As String, _Bodega As String)


        Dim _Row_Producto As DataRow = Fx_Row_Producto(_Formulario, _Codigo)

        If (_Row_Producto Is Nothing) Then
            Exit Sub
        End If

        If Fx_Tiene_Permiso(Me, "Ubic0002") Then

            ' Dim _RowBodeg As DataRow

            If (_Empresa Is Nothing) Or
               (_Sucursal Is Nothing) Or
               (_Bodega Is Nothing) Then

                Dim FmB As New Frm_SeleccionarBodega(Frm_SeleccionarBodega.Accion.Bodega)
                FmB.ShowDialog(_Formulario)

                If FmB.Pro_Seleccionado Then
                    _RowBodega = FmB.Pro_RowBodega
                    _Empresa = FmB.Pro_Empresa
                    _Sucursal = FmB.Pro_Sucursal
                    _Bodega = FmB.Pro_Bodega
                Else
                    Return
                End If
                FmB.Dispose()
            End If

            Consulta_sql = "Select '" & _Empresa & "' As 'EMPRESA'," & vbCrLf &
                      "(Select top 1 RAZON From CONFIGP Where EMPRESA = '" & _Empresa & "') As 'RAZON'," & vbCrLf &
                      "'" & _Sucursal & "' As KOSU,(Select top 1 NOKOSU From TABSU " &
                      "Where EMPRESA = '" & _Empresa & "' And KOSU = '" & _Sucursal & "') As 'NOKOSU'," & vbCrLf &
                      "'" & _Bodega & "' As 'KOBO'," &
                      "(Select top 1 NOKOBO From TABBO " &
                      "Where EMPRESA = '" & _Empresa & "' And KOSU = '" & _Sucursal & "' And KOBO = '" & _Bodega & "') As 'NOKOBO'"

            Dim _TblBod As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

            _RowBodega = _TblBod.Rows(0)

            Dim Fm As New Frm_01_UbicXpro(_Codigo)
            Fm.Pro_RowBodega = _RowBodega
            Fm.ShowDialog(_Formulario)
            Fm.Dispose()

        End If

    End Sub

    Private Sub TxtCodigo_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles TxtCodigo.KeyDown
        If e.KeyValue = Keys.Down Then
            Grilla.Focus()
            Me.ActiveControl = Grilla ' Txtdescripcion
        End If

        If e.KeyValue = Keys.Return Then
            If _Actualizar_Precios Then

                If _Tipo_Lista = "P" Then

                    Dim _CondExtraProveedor As String = String.Empty
                    If Not String.IsNullOrEmpty(Trim(_CodEntidad)) Then
                        _CondExtraProveedor = "Where Proeveedor = '" & _CodEntidad & "' And Sucursal = '" & _CodSucEntidad & "'"
                    End If

                    Actualizar_Precio_BkRandom(_ListaBusq, _Tabla_Lista, _CondExtraProveedor, True)
                    '    BUSCA()
                End If

            End If
            _Top = 30
            Sb_Buscar_Productos(ModEmpresa, _SucursalBusq, _BodegaBusq, _ListaBusq, True, _Opcion_Buscar._Codigo)
            If CBool(Grilla.RowCount) Then Grilla.Focus()
        End If

    End Sub

    'Sub Sb_Grilla_RowsPostPaint(sender As System.Object, e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs)
    '    Try
    '        'Captura el numero de filas del datagridview
    '        Dim RowsNumber As String = (e.RowIndex + 1).ToString
    '        While RowsNumber.Length < Grilla.RowCount.ToString.Length
    '            RowsNumber = "0" & RowsNumber
    '        End While
    '        Dim size As SizeF = e.Graphics.MeasureString(RowsNumber, Me.Font)
    '        If Grilla.RowHeadersWidth < CInt(size.Width + 20) Then
    '            Grilla.RowHeadersWidth = CInt(size.Width + 20)
    '        End If
    '        Dim ob As Brush = SystemBrushes.ControlText
    '        e.Graphics.DrawString(RowsNumber, Me.Font, ob, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2))
    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message, "vb.net",
    '     MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try
    'End Sub

    Private Sub Sb_Grilla_Scroll(sender As System.Object, e As System.Windows.Forms.ScrollEventArgs)

        Dim _ValorNew = e.NewValue
        Dim _ValorOld = e.OldValue

        Dim _Cima = Grilla.Rows.Count - _ValorNew
        Dim _Filas As Integer = Grilla.Rows.Count '- 1


        If _Cima < 25 Then
            'Return
            Dim _Codigo = Trim(Grilla.Rows(Grilla.Rows.Count - 1).Cells("Codigo").Value)
            Sb_Buscar_Productos(ModEmpresa, _SucursalBusq, _BodegaBusq, _ListaBusq, _Top_Filas)
            BuscarDatoEnGrilla(_Codigo, "Codigo", Grilla)

        End If

    End Sub

    'Private Sub Btn_Subir_Click(sender As System.Object, e As System.EventArgs)
    '    SendKeys.Send("{UP}")
    'End Sub

    'Private Sub Btn_Bajar_Click(sender As System.Object, e As System.EventArgs)
    '    SendKeys.Send("{DOWN}")
    'End Sub


    Function Fx_Activar_Deactivar_Teclado()

        If _Global_Es_Touch Then
            TouchKeyboard1.SetShowTouchKeyboard(TxtCodigo, DevComponents.DotNetBar.Keyboard.TouchKeyboardStyle.Inline)
            TouchKeyboard1.SetShowTouchKeyboard(Txtdescripcion, DevComponents.DotNetBar.Keyboard.TouchKeyboardStyle.Inline)

            Txtdescripcion.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            TxtCodigo.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Sb_Formato_Generico_Grilla(Grilla, 30, New Font("Tahoma", 14), Color.AliceBlue, ScrollBars.Vertical, True, True, False)
        Else
            TouchKeyboard1.SetShowTouchKeyboard(TxtCodigo, DevComponents.DotNetBar.Keyboard.TouchKeyboardStyle.No)
            TouchKeyboard1.SetShowTouchKeyboard(Txtdescripcion, DevComponents.DotNetBar.Keyboard.TouchKeyboardStyle.No)
            TouchKeyboard1.HideKeyboard()

            Txtdescripcion.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            TxtCodigo.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Sb_Formato_Generico_Grilla(Grilla, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, True, Seleccionar_Multiple)

        End If

        'Btn_Bajar.Visible = True '_Global_Es_Touch
        'Btn_Subir.Visible = True ' _Global_Es_Touch
        'Btn_Seleccionar.Visible = _Global_Es_Touch

        Me.Refresh()

    End Function

    Private Sub Btn_Mnu_Pr_Estadistica_Producto_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Mnu_Pr_Estadistica_Producto.Click
        Dim _Codigo = Grilla.Rows(Grilla.CurrentRow.Index).Cells("Codigo").Value
        Sb_Ver_Informacion_Adicional_producto(Me, _Codigo)
    End Sub

    Private Sub Btn_Mnu_Pr_Codigo_De_Reemplazo_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Mnu_Pr_Codigo_De_Reemplazo.Click
        Dim _Codigo = Grilla.Rows(Grilla.CurrentRow.Index).Cells("Codigo").Value
        Sb_Ver_Codigos_de_reemplazo(Me, _Codigo)
    End Sub

    Private Sub Btn_Mnu_Pr_Editar_Producto_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Mnu_Pr_Editar_Producto.Click
        Sb_Seleccionar_Producto_doble_clic()
    End Sub

    Private Sub Btn_Mnu_Pr_Eliminar_Producto_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Mnu_Pr_Eliminar_Producto.Click
        Sb_Eliminar_Producto()
    End Sub

    Private Sub Btn_Mnu_Pr_Crear_Producto_Click(sender As System.Object, e As System.EventArgs)
        Sb_Crear_Nuevo_Producto()
    End Sub

    Private Sub Btn_Mnu_Pr_Cambiar_Codigo_Producto_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Mnu_Pr_Cambiar_Codigo_Producto.Click
        Mnu_Sb_Cambiar_Codigo()
    End Sub

    Private Sub Btn_Mnu_Pr_Ver_Clasificacion_Producto_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Mnu_Pr_Ver_Clasificacion_Producto.Click
        Dim _Codigo As String = Grilla.Rows(Grilla.CurrentRow.Index).Cells("Codigo").Value
        Sb_Ver_Clasificaciones_del_producto(Me, _Codigo)
    End Sub

    Private Sub Btn_Mnu_Pr_Mantencion_Clasificacion_Producto_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Mnu_Pr_Mantencion_Clasificacion_Producto.Click
        Dim _Codigo As String = Grilla.Rows(Grilla.CurrentRow.Index).Cells("Codigo").Value
        Sb_Mantencion_Clasificacion_Codigos(Me, _Codigo)
    End Sub

    Private Sub Btn_Mnu_Pr_Imagen_Producto_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Mnu_Pr_Imagen_Producto.Click
        Sb_Imagen_Producto()
    End Sub

    Private Sub Btn_Mnu_Pr_Codigo_Alternativo_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Mnu_Pr_Codigo_Alternativo.Click
        Sb_Seleccionar_Producto_doble_clic_Alternativos()
    End Sub

    Private Sub Btn_Mnu_Pr_Kardex_Inventario_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Mnu_Pr_Kardex_Inventario.Click
        Dim _Codigo As String = Grilla.Rows(Grilla.CurrentRow.Index).Cells("Codigo").Value
        Sb_Ver_Kardex_Inventario(Me, _Codigo)
    End Sub

    Private Sub Btn_Mnu_Pr_Ubicacion_Producto_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Mnu_Pr_Ubicacion_Producto.Click
        Dim _Codigo As String = Grilla.Rows(Grilla.CurrentRow.Index).Cells("Codigo").Value
        Sb_Ver_Ubicacion_Bodega(Me, _Codigo, _Empresa, _Sucursal, _Bodega)
    End Sub

    Enum _Ocu
        Ocultar
        Desocultar
    End Enum

    Private Sub Btn_Ocultar_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Ocultar.Click

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        Dim _Codigo As String = _Fila.Cells("Codigo").Value 'Grilla.Rows(Grilla.CurrentRow.Index).Cells("Codigo").Value
        Dim _Oculto As Boolean = _Fila.Cells("Oculto").Value 'Grilla.Rows(Grilla.CurrentRow.Index).Cells("Oculto").Value
        Dim _Accion As _Ocu

        If _Oculto Then
            _Accion = _Ocu.Desocultar ': _Oc = False : _Color = Color.Black : Btn_Ocultar.Text = "Desocultar"
        Else
            _Accion = _Ocu.Ocultar ': _Oc = True : _Color = Color.Red : Btn_Ocultar.Text = "Ocultar"
        End If

        If Fx_Ocultar_Desocultar_Producto(Me, _Codigo, _Accion) Then
            _Fila.Cells("Oculto").Value = True
            _Fila.DefaultCellStyle.ForeColor = Color.Red
        Else
            _Fila.Cells("Oculto").Value = False
            _Fila.DefaultCellStyle.ForeColor = Color.Black
        End If

    End Sub

    Function Fx_Ocultar_Desocultar_Producto(_Formulario As Form,
                                            _Codigo As String,
                                            _Accion As _Ocu) As Boolean

        If Fx_Tiene_Permiso(Me, "Prod004") Then

            Dim _Row_Producto As DataRow = Fx_Row_Producto(_Formulario, _Codigo)

            If (_Row_Producto Is Nothing) Then
                Exit Function
            End If

            If _Accion = _Ocu.Ocultar Then

                Consulta_sql = "Update MAEPR Set ATPR = 'OCU' Where KOPR = '" & _Codigo & "'"
                If _Sql.Ej_consulta_IDU(Consulta_sql) Then

                    ToastNotification.Show(_Formulario, "PRODUCTO:" & _Row_Producto.Item("NOKOPR") & vbCrLf &
                                           "OCULTADO CORRECTAMENTE", My.Resources.burn, 3 * 1000,
                                           eToastGlowColor.Blue, eToastPosition.MiddleCenter)
                End If
                Return True

            Else

                Consulta_sql = "Update MAEPR Set ATPR = '' Where KOPR = '" & _Codigo & "'"
                If _Sql.Ej_consulta_IDU(Consulta_sql) Then

                    ToastNotification.Show(_Formulario, "PRODUCTO:" & _Row_Producto.Item("NOKOPR") & vbCrLf &
                                            "DESOCULTADO CORRECTAMENTE", My.Resources.burn, 3 * 1000,
                                            eToastGlowColor.Blue, eToastPosition.MiddleCenter)
                End If

            End If

        End If

    End Function

    Sub Sb_Dimensiones_Producto()

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)
        Dim _Codigo As String = _Fila.Cells("Codigo").Value

        Dim Fm As New Frm_Dimensiones_Pr(_Codigo, False)
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub
    Sub Sb_Ver_Archivos_Adjuntos_X_Productos()

        If Fx_Tiene_Permiso(Me, "Prod045") Then

            Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)
            Dim _Codigo As String = _Fila.Cells("Codigo").Value

            Dim Fm As New Frm_Adjuntar_Archivos_X_Productos(_Codigo)
            Fm.ShowDialog(Me)
            Fm.Dispose()

        End If

    End Sub

    Private Sub Btn_Ver_Archivos_Adjuntos_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Ver_Archivos_Adjuntos.Click
        Sb_Ver_Archivos_Adjuntos_X_Productos()
    End Sub

    Private Sub Mnu_Btn_Ver_Informacion_de_producto_Click(sender As System.Object, e As System.EventArgs) Handles Mnu_Btn_Ver_Informacion_de_producto.Click
        Dim _Codigo = Grilla.Rows(Grilla.CurrentRow.Index).Cells("Codigo").Value
        Sb_Ver_Informacion_Adicional_producto(Me, _Codigo)
    End Sub

    Private Sub Mnu_Btn_Codigos_Reemplazo_Click(sender As System.Object, e As System.EventArgs) Handles Mnu_Btn_Codigos_Reemplazo.Click
        Dim _Codigo = Grilla.Rows(Grilla.CurrentRow.Index).Cells("Codigo").Value
        Sb_Ver_Codigos_de_reemplazo(Me, _Codigo)
    End Sub

    Private Sub Mnu_Btn_Ocultar_Click(sender As System.Object, e As System.EventArgs) Handles Mnu_Btn_Ocultar.Click

        Dim _Codigo = Grilla.Rows(Grilla.CurrentRow.Index).Cells("Codigo").Value
        Dim _Descripcion = Grilla.Rows(Grilla.CurrentRow.Index).Cells("Descripcion").Value

        If Fx_Tiene_Permiso(Me, "Prod004") Then

            Dim _Oculto As Boolean = Grilla.Rows(Grilla.CurrentRow.Index).Cells("Oculto").Value
            Consulta_sql = "Update MAEPR Set ATPR = 'OCU' Where KOPR = '" & _Codigo & "'"
            If _Sql.Ej_consulta_IDU(Consulta_sql) Then

                Grilla.Rows.Item(Grilla.CurrentRow.Index).DefaultCellStyle.ForeColor = Color.Red
                Grilla.Rows(Grilla.CurrentRow.Index).Cells("Oculto").Value = True
                ToastNotification.Show(Me, "PRODUCTO:" & _Descripcion & vbCrLf &
                                       "OCULTADO CORRECTAMENTE", My.Resources.burn, 3 * 1000,
                                       eToastGlowColor.Blue, eToastPosition.MiddleCenter)
            End If

        End If
    End Sub

    Private Sub Mnu_Btn_Desocultar_Click(sender As System.Object, e As System.EventArgs) Handles Mnu_Btn_Desocultar.Click
        Dim _Codigo = Grilla.Rows(Grilla.CurrentRow.Index).Cells("Codigo").Value
        Dim _Descripcion = Grilla.Rows(Grilla.CurrentRow.Index).Cells("Descripcion").Value

        If Fx_Tiene_Permiso(Me, "Prod004") Then

            Dim _Oculto As Boolean = Grilla.Rows(Grilla.CurrentRow.Index).Cells("Oculto").Value
            Consulta_sql = "Update MAEPR Set ATPR = '' Where KOPR = '" & _Codigo & "'"
            If _Sql.Ej_consulta_IDU(Consulta_sql) Then
                Grilla.Rows.Item(Grilla.CurrentRow.Index).DefaultCellStyle.ForeColor = Color.Black
                Grilla.Rows(Grilla.CurrentRow.Index).Cells("Oculto").Value = False
                ToastNotification.Show(Me, "PRODUCTO:" & _Descripcion & vbCrLf &
                                        "DESOCULTADO CORRECTAMENTE", My.Resources.burn, 3 * 1000,
                                        eToastGlowColor.Blue, eToastPosition.MiddleCenter)
            End If

        End If
    End Sub

    Private Sub Mnu_Btn_Cambiar_Codigo_Producto_Click(sender As System.Object, e As System.EventArgs) Handles Mnu_Btn_Cambiar_Codigo_Producto.Click
        Mnu_Sb_Cambiar_Codigo()
    End Sub

    Private Sub Mnu_Btn_Editar_Producto_Click(sender As System.Object, e As System.EventArgs) Handles Mnu_Btn_Editar_Producto.Click
        Sb_Seleccionar_Producto_doble_clic()
    End Sub

    Private Sub Mnu_Btn_Eliminar_Producto_Click(sender As System.Object, e As System.EventArgs) Handles Mnu_Btn_Eliminar_Producto.Click
        Sb_Eliminar_Producto()
    End Sub

    Private Sub Mnu_Btn_Ver_Clasificaciones_producto_Click(sender As System.Object, e As System.EventArgs) Handles Mnu_Btn_Ver_Clasificaciones_producto.Click
        Dim _Codigo As String = Grilla.Rows(Grilla.CurrentRow.Index).Cells("Codigo").Value
        Sb_Ver_Clasificaciones_del_producto(Me, _Codigo)
    End Sub

    Private Sub Mnu_Btn_Productos_Asociados_Click(sender As Object, e As EventArgs) Handles Mnu_Btn_Productos_Asociados.Click
        Dim _Codigo As String = Grilla.Rows(Grilla.CurrentRow.Index).Cells("Codigo").Value
        Sb_Ver_Asociaciones_del_producto(Me, _Codigo)
    End Sub

    Private Sub Btn_Productos_Asociados_Click(sender As Object, e As EventArgs) Handles Btn_Productos_Asociados.Click
        Dim _Codigo As String = Grilla.Rows(Grilla.CurrentRow.Index).Cells("Codigo").Value
        Sb_Ver_Asociaciones_del_producto(Me, _Codigo)
    End Sub

    Private Sub Mnu_Btn_Mantencion_clasificaciones_producto_Click(sender As System.Object, e As System.EventArgs) Handles Mnu_Btn_Mantencion_clasificaciones_producto.Click
        Dim _Codigo As String = Grilla.Rows(Grilla.CurrentRow.Index).Cells("Codigo").Value
        Sb_Mantencion_Clasificacion_Codigos(Me, _Codigo)
    End Sub

    Private Sub Btn_Orden_Bodegas_Click(sender As Object, e As EventArgs) Handles Btn_Orden_Bodegas.Click

        If Fx_Tiene_Permiso(Me, "Prod062") Then

            Dim _Grabar As Boolean

            Dim Fm As New Frm_BkpPostBusquedaOrdenBod
            Fm.ShowDialog(Me)
            _Grabar = Fm.Grabar
            Fm.Dispose()

            If _Grabar Then

                Sb_Actualizar_Tbl_Bodegas()

                TxtCodigo.Text = String.Empty
                Txtdescripcion.Text = String.Empty

                Sb_Buscar_Productos(ModEmpresa, _SucursalBusq, _BodegaBusq, _ListaBusq, True, _Opcion_Buscar._Descripcion, _Top)

            End If

        End If

    End Sub

    Private Sub Mnu_Btn_Imagenes_producto_Click(sender As System.Object, e As System.EventArgs) Handles Mnu_Btn_Imagenes_producto.Click
        Sb_Imagen_Producto()
    End Sub

    Private Sub SuperTabItem1_Click(sender As Object, e As EventArgs)
        Sb_Formato_Grilla()
    End Sub

    Private Sub SuperTabItem2_Click(sender As Object, e As EventArgs)
        Sb_Formato_Grilla_Top20()
    End Sub

    Private Sub Btn_Maestra_Productos_Click(sender As Object, e As EventArgs) Handles Btn_Maestra_Productos.Click
        Btn_Top20.Checked = False
        Btn_Maestra_Productos.Checked = True
        Btn_Top20.Image = Nothing
        Btn_Maestra_Productos.Image = ImageList1.Images.Item(1)
        Sb_Formato_Grilla()
    End Sub

    Private Sub Btn_Top20_Click(sender As Object, e As EventArgs) Handles Btn_Top20.Click
        Btn_Top20.Checked = True
        Btn_Maestra_Productos.Checked = False
        Btn_Top20.Image = ImageList1.Images.Item(1)
        Btn_Maestra_Productos.Image = Nothing
        Sb_Formato_Grilla_Top20()
    End Sub

    Private Sub Mnu_Btn_Mant_codigos_alternativos_Click(sender As System.Object, e As System.EventArgs) Handles Mnu_Btn_Mant_codigos_alternativos.Click
        Sb_Seleccionar_Producto_doble_clic_Alternativos()
    End Sub

    Private Sub Btn_Seleccion_Multiple_Click(sender As Object, e As EventArgs) Handles Btn_Seleccion_Multiple.Click

        Dim _Rows = _Tbl_Productos_Grilla.Select("Chk = True", "Chk")
        Dim _Lista As New List(Of String)

        For Each _Fl As DataRow In _Tbl_Productos_Grilla.Rows

            If _Fl.Item("Chk") Then

                _Lista.Add(_Fl.Item("Codigo"))

            End If

        Next

        If _Lista.Count = 0 And Grilla.SelectedRows.Count = 1 Then

            Sb_Seleccionar_Producto_Para_Trasladar()

        Else

            If CBool(_Lista.Count) Then

                If _Rows.Length = 1 Then

                    Dim _Codigo As String = _Rows(0).Item("Codigo")
                    Consulta_sql = "Select * From MAEPR Where KOPR = '" & _Codigo & "'"
                    _RowProducto = _Sql.Fx_Get_DataRow(Consulta_sql)

                    _Codigo_Sel = _Codigo
                    _Es_Conceto = False

                    _Seleccionado = True
                    Me.Close()

                Else

                    'For Each _Fila As DataGridViewRow In Grilla.SelectedRows
                    Dim _Filtro_Productos As String = Generar_Filtro_IN_Arreglo(_Lista, False)

                    Consulta_sql = "Select * From MAEPR Where KOPR In " & _Filtro_Productos
                    _Tbl_Productos_Seleccionados = _Sql.Fx_Get_Tablas(Consulta_sql)
                    _Seleccion_Multiple = True
                    Me.Close()

                End If

            Else

                MessageBoxEx.Show(Me, "No hay productos tickeados", "Selección multiple, validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)

            End If

        End If

    End Sub

    Private Sub Mnu_Btn_Kardex_Inventario_Click(sender As System.Object, e As System.EventArgs) Handles Mnu_Btn_Kardex_Inventario.Click
        Dim _Codigo As String = Grilla.Rows(Grilla.CurrentRow.Index).Cells("Codigo").Value
        Sb_Ver_Kardex_Inventario(Me, _Codigo)
    End Sub

    Private Sub Btn_Marcar_Seleccionados_Click(sender As Object, e As EventArgs) Handles Btn_Marcar_Seleccionados.Click

        For Each _Fila As DataGridViewRow In Grilla.SelectedRows
            _Fila.Cells("Chk").Value = True
        Next

        If Grilla.SelectedRows.Count > 1 Then Grilla.ClearSelection()

        Dim _Rows = _Tbl_Productos_Grilla.Select("Chk = 1", "Codigo")

        Btn_Marcar_Seleccionados.Visible = (Grilla.SelectedRows.Count > 1)
        Btn_Desmarcar_Seleccionados.Visible = (Grilla.SelectedRows.Count > 1)

    End Sub

    Private Sub Btn_Desmarcar_Seleccionados_Click(sender As Object, e As EventArgs) Handles Btn_Desmarcar_Seleccionados.Click

        For Each _Fila As DataGridViewRow In Grilla.SelectedRows
            _Fila.Cells("Chk").Value = False
        Next

        If Grilla.SelectedRows.Count > 1 Then Grilla.ClearSelection()

        Dim _Rows = _Tbl_Productos_Grilla.Select("Chk = 1", "Codigo")
        Dim _Tickeados As Boolean
        For Each _Fl As DataRow In _Tbl_Productos_Grilla.Rows
            _Tickeados = _Fl.Item("Chk")
            If _Tickeados Then
                Exit For
            End If
        Next

        Btn_Marcar_Seleccionados.Visible = (Grilla.SelectedRows.Count > 1)
        Btn_Desmarcar_Seleccionados.Visible = (Grilla.SelectedRows.Count > 1)

    End Sub

    Private Sub Grilla_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles Grilla.CellFormatting

        Dim _Columname As String = Grilla.Columns(e.ColumnIndex).Name

        If _Columname.Contains("STOCK_Ud") Then

            Dim _Valor = e.Value

            If _Valor > 0 Then
                'e.CellStyle.ForeColor = Verde
                'e.CellStyle.Font = New Font(Grilla.Font.Name, Grilla.Font.Size, FontStyle.Bold)
            Else
                If Global_Thema = Enum_Themas.Oscuro Then
                    e.CellStyle.ForeColor = Color.FromArgb(60, 60, 60)
                Else
                    e.CellStyle.ForeColor = Color.LightGray
                End If
            End If

        End If

    End Sub

    Private Sub Btn_Dimensiones_Click(sender As Object, e As EventArgs) Handles Btn_Dimensiones.Click
        Sb_Dimensiones_Producto()
    End Sub

    Private Sub Mnu_Btn_Dimensiones_Click(sender As Object, e As EventArgs) Handles Mnu_Btn_Dimensiones.Click
        Sb_Dimensiones_Producto()
    End Sub

    Private Sub Grilla_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla.CellEnter

        Dim _Fila As DataGridViewRow = Grilla.CurrentRow

        Try
            Dim _Ficha As String = _Fila.Cells("Ficha").Value
            Txt_Ficha.Text = _Ficha
        Catch ex As Exception
            Txt_Ficha.Text = String.Empty
        End Try

    End Sub

    Private Sub Btn_Migrar_Producto_Click(sender As Object, e As EventArgs) Handles Btn_Migrar_Producto.Click

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        Dim _Codigo As String = _Fila.Cells("Codigo").Value

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_DbExt_Conexion Where GrbProd_Nuevos = 1"
        Dim _Tbl_Conexiones As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        For Each _FilaCx As DataRow In _Tbl_Conexiones.Rows

            Dim _Id_Conexion As Integer = _FilaCx.Item("Id")

            Dim _Cl_Migrar_Producto As New Bk_Migrar_Producto.Cl_Migrar_Producto(_Id_Conexion)
            If _Cl_Migrar_Producto.SePuedeMigrar Then
                If _Cl_Migrar_Producto.Fx_Migrar_Producto(_Codigo) Then
                    MessageBoxEx.Show(Me, "Producto exportado correctamente", "Migrar producto", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBoxEx.Show(Me, "No se pudo migrar el producto" & vbCrLf & _Cl_Migrar_Producto.ProError, "Problema!",
                                      MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If
            Else
                MessageBoxEx.Show(Me, _Cl_Migrar_Producto.ProError, "Problema!",
                                  MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If

        Next

    End Sub



    Private Sub Mnu_Btn_Ubicacion_Producto_Click(sender As System.Object, e As System.EventArgs) Handles Mnu_Btn_Ubicacion_Producto.Click
        Dim _Codigo As String = Grilla.Rows(Grilla.CurrentRow.Index).Cells("Codigo").Value
        Sb_Ver_Ubicacion_Bodega(Me, _Codigo, _Empresa, _Sucursal, _Bodega)
    End Sub

    Private Sub Txt_Patente_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_Patente.KeyDown
        If e.KeyValue = Keys.Enter Then
            Patente_rvm = Txt_Patente.Text
            If Fx_Buscar_Patente() Then
                Sb_Buscar_Productos(ModEmpresa, _SucursalBusq, _BodegaBusq, _ListaBusq, True, _Opcion_Buscar._Descripcion)
                Txtdescripcion.Focus()
            Else
                MessageBoxEx.Show(Me, "Patente No encontrada", "Patente RVM", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Call Txt_Patente_ButtonCustomClick(Nothing, Nothing)
            End If
        End If
    End Sub

    Private Sub Txt_Patente_ButtonCustomClick(sender As Object, e As EventArgs) Handles Txt_Patente.ButtonCustomClick

        Dim _Aceptar As Boolean = InputBox_Bk(Me, "INGRESE LA PATENTE A BUSCAR", "Buscar paten te en RVM", Patente_rvm, False, _Tipo_Mayus_Minus.Mayusculas, 6, True)

        If Not _Aceptar Then
            Return
        End If

        If Fx_Buscar_Patente() Then
            MessageBoxEx.Show(Me, "Patente encontrada: " & _Row_Patente_rvm.Item("Descripcion"), "Patente RVM", MessageBoxButtons.OK, MessageBoxIcon.Information)
            If Not String.IsNullOrEmpty(Txtdescripcion.Text) Then
                Sb_Buscar_Productos(ModEmpresa, _SucursalBusq, _BodegaBusq, _ListaBusq, True, _Opcion_Buscar._Descripcion)
            End If
            Txtdescripcion.Focus()
        Else
            MessageBoxEx.Show(Me, "Patente No encontrada", "Patente RVM", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Call Txt_Patente_ButtonCustomClick(Nothing, Nothing)
        End If
    End Sub

    Private Sub Txt_Patente_ButtonCustom2Click(sender As Object, e As EventArgs) Handles Txt_Patente.ButtonCustom2Click
        Patente_rvm = String.Empty
        Fx_Buscar_Patente()
        Sb_Buscar_Productos(ModEmpresa, _SucursalBusq, _BodegaBusq, _ListaBusq, True, _Opcion_Buscar._Descripcion)
        Txtdescripcion.Focus()
    End Sub

    Private Sub Mnu_Btn_Archivos_Asociados_Producto_Click(sender As System.Object, e As System.EventArgs) Handles Mnu_Btn_Archivos_Asociados_Producto.Click
        Sb_Ver_Archivos_Adjuntos_X_Productos()
    End Sub

    Private Sub Mnu_Btn_Copiar_Click(sender As System.Object, e As System.EventArgs) Handles Mnu_Btn_Copiar.Click
        With Grilla

            Dim _Cabeza = .Columns(.CurrentCell.ColumnIndex).Name
            Dim _Texto_Cabeza = .Columns(.CurrentCell.ColumnIndex).HeaderText

            Dim Copiar = .Rows(.CurrentRow.Index).Cells(_Cabeza).Value
            Clipboard.SetText(Copiar)

            ToastNotification.Show(Me, _Texto_Cabeza & " esta en el portapapeles", Mnu_Btn_Copiar.Image,
                                   2 * 1000, eToastGlowColor.Green, eToastPosition.MiddleCenter)


        End With
    End Sub

    Private Sub Sb_Grilla_MouseDown(sender As System.Object, e As System.Windows.Forms.MouseEventArgs)
        If e.Button = Windows.Forms.MouseButtons.Right Then
            With sender
                Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)
                If Hitest.Type = DataGridViewHitTestType.Cell Then
                    .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)

                    Mnu_Btn_Desocultar.Enabled = ChkMostrarOcultos.Checked

                    Dim _Oculto As Boolean = Grilla.Rows(Grilla.CurrentRow.Index).Cells("Oculto").Value

                    If _Oculto Then
                        Mnu_Btn_Ocultar.Checked = True
                        Mnu_Btn_Ocultar.Enabled = False
                        Mnu_Btn_Desocultar.Enabled = True
                        Mnu_Btn_Desocultar.Checked = False
                    Else
                        Mnu_Btn_Desocultar.Checked = True
                        Mnu_Btn_Desocultar.Enabled = False
                        Mnu_Btn_Ocultar.Enabled = True
                        Mnu_Btn_Ocultar.Checked = False
                    End If

                    Btn_Migrar_Producto.Visible = _Global_Row_Configuracion_General.Item("PermitirMigrarProductosBaseExterna")

                    ShowContextMenu(Menu_Contextual_01)

                End If
            End With
        End If
    End Sub

    Private Sub Grilla_MouseWheel(sender As Object, e As MouseEventArgs)
        'Return
        ' Si el ratón no tiene rueda, o el sistema operativo no
        ' admite la rueda del ratón de manera nativa, abandonamos
        ' el procedimiento.
        '
        If ((Not (SystemInformation.MouseWheelPresent)) OrElse
         (Not (SystemInformation.NativeMouseWheelSupport))) Then Return

        ' Fila actualmente seleccionada en el control DataGridView.
        '
        Dim currentRow As DataGridViewRow = sender.CurrentRow
        If (currentRow Is Nothing) Then Return

        ' Índice de la fila actual.
        '
        Dim index As Integer = currentRow.Index

        ' Número total de filas.
        '
        Dim count As Integer = sender.Rows.Count

        ' Número de líneas de desplazamiento.
        '
        Dim scrollLines As Integer = 10 'SystemInformation.MouseWheelScrollLines

        If count <= 25 Then scrollLines = 1

        ' ¿Arriba o abajo?
        '
        Dim down As Boolean = (e.Delta < 0)

        If (down) Then
            ' Abajo
            index += scrollLines

            If (index >= count) Then
                ' Es la última fila.
                Sb_Buscar_Productos(ModEmpresa, _SucursalBusq, _BodegaBusq, _ListaBusq, False, _Opcion_Buscar._Descripcion)
                Return
            End If

            ' Establecemos el valor de la nueva celda actual.
            '
            'sender.CurrentCell = sender.Rows(index).Cells(0)

        Else
            ' Arriba
            index -= scrollLines

            If (index < 1) Then
                ' Es la primera fila.
                index = 0
            End If

        End If

        ' Establecemos el valor de la nueva celda actual.
        '
        sender.CurrentCell = sender.Rows(index).Cells(0)

    End Sub
    Private Sub Frm_BkpPostBusquedaEspecial_Mt_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        _Cl_ActFxDinXProductos.Sb_Detener()
    End Sub

    Private Sub Frm_BkpPostBusquedaEspecial_Mt_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed

        Dim _NombreEquipo As String = _Global_Row_EstacionBk.Item("NombreEquipo")

        Consulta_sql = "Update " & _Global_BaseBk & "Zw_Tmp_Prm_Informes Set Modalidad = '" & Modalidad & "'
                        Where Funcionario = '" & FUNCIONARIO & "' And Informe = 'Buscar_Productos'" & Space(1) &
                       "And NombreEquipo = '" & _NombreEquipo & "' And Modalidad = ''"
        _Sql.Ej_consulta_IDU(Consulta_sql, False)

        _Sql.Sb_Parametro_Informe_Sql(Chk_Top20, "Buscar_Productos", Chk_Top20.Name,
                                         Class_SQLite.Enum_Type._Boolean, False, True, "Productos")

    End Sub

    Private Sub Sb_Grilla_MouseUp(sender As System.Object, e As System.Windows.Forms.MouseEventArgs)

        Dim keysMod As Keys = Control.ModifierKeys

        Btn_Marcar_Seleccionados.Visible = (Grilla.SelectedRows.Count > 1)
        Btn_Desmarcar_Seleccionados.Visible = (Grilla.SelectedRows.Count > 1)

        Grilla.EndEdit()
        Me.Refresh()

    End Sub

    Private Sub Grilla_KeyUp(sender As Object, e As KeyEventArgs)

        Dim _Key = e.KeyData

        If _Key = Keys.ControlKey Then

            Btn_Marcar_Seleccionados.Visible = (Grilla.SelectedRows.Count > 1)
            Btn_Desmarcar_Seleccionados.Visible = (Grilla.SelectedRows.Count > 1)

        End If

        Grilla.EndEdit()
        Me.Refresh()

    End Sub

    Private Sub ButtonItem1_Click(sender As Object, e As EventArgs) Handles ButtonItem1.Click

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        Dim _Codigo As String = _Fila.Cells("Codigo").Value

        Dim _Fecha = "01/01/1999"
        Dim _FechaTope As DateTime = DateTime.ParseExact(_Fecha, "dd/MM/yyyy", Globalization.CultureInfo.CurrentCulture, DateTimeStyles.None)

        Try
            _FechaTope = _Global_Row_Configp.Item("FECHINIPPP")
        Catch ex As Exception
            _FechaTope = DateTime.ParseExact(_Fecha, "dd/MM/yyyy", Globalization.CultureInfo.CurrentCulture, DateTimeStyles.None)
        End Try

        Dim _Recalculado As Boolean
        Dim _OldPpp As Double = _Sql.Fx_Trae_Dato("MAEPREM", "PM", "EMPRESA = '" & ModEmpresa & "' And KOPR = '" & _Codigo & "'")
        Dim _NewPpp As Double

        Dim Fm As New Frm_Recalculo_PPPxProd(_Codigo, _FechaTope)
        Fm.ShowDialog(Me)
        _Recalculado = Fm.Recalculado
        _NewPpp = Fm.NewPPP
        Fm.Dispose()

        If _Recalculado Then

            If _OldPpp <> _NewPpp Then

            End If

            MessageBoxEx.Show(Me, "PPP calculado: " & FormatCurrency(_NewPpp, 2), "Recalculo PM", MessageBoxButtons.OK, MessageBoxIcon.Information)

        End If

    End Sub


End Class

Public Class Cl_EliminaProd

    Public Property EsCorrecto As Boolean
    Public Property Problemas As List(Of String)
    Public Property SqlQueruDelete As String

End Class
