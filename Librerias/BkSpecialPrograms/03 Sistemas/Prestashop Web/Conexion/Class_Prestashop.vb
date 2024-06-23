Imports DevComponents.DotNetBar
Imports DevComponents.DotNetBar.Controls

Public Class Class_Prestashop

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Clas_Ps As Class_MySQL
    Dim _Cadena_Conexion_MySql As String

    Dim _Row_Prestashop As DataRow
    Dim _Sitio As String
    Dim _Cancelar As Boolean

    Dim _Progress_Porcent As New CircularProgress
    Dim _Progress_Canti As New CircularProgress

    Dim _Etiqueta1 As New LabelX
    Dim _Etiqueta2 As New LabelX

    Dim _Formulario_Padre As Form

    Public Property Sitio As String
        Get
            Return _Sitio
        End Get
        Set(value As String)
            _Sitio = value
        End Set
    End Property

    Public Property Progress_Porcent As CircularProgress
        Get
            Return _Progress_Porcent
        End Get
        Set(value As CircularProgress)
            _Progress_Porcent = value
        End Set
    End Property

    Public Property Progress_Canti As CircularProgress
        Get
            Return _Progress_Canti
        End Get
        Set(value As CircularProgress)
            _Progress_Canti = value
        End Set
    End Property

    Public Property Cancelar As Boolean
        Get
            Return _Cancelar
        End Get
        Set(value As Boolean)
            _Cancelar = value
        End Set
    End Property

    Public Property Etiqueta1 As Object
        Get
            Return _Etiqueta1
        End Get
        Set(value As Object)
            _Etiqueta1 = value
        End Set
    End Property

    Public Property Etiqueta2 As Object
        Get
            Return _Etiqueta2
        End Get
        Set(value As Object)
            _Etiqueta2 = value
        End Set
    End Property

    Public Property Formulario_Padre As Form
        Get
            Return _Formulario_Padre
        End Get
        Set(value As Form)
            _Formulario_Padre = value
        End Set
    End Property

    Public Sub New(Sitio As String)

        _Sitio = Sitio

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_PrestaShop Where Nombre_Pagina = '" & Sitio & "'"
        _Row_Prestashop = _Sql.Fx_Get_DataRow(Consulta_sql)

        If Not IsNothing(_Row_Prestashop) Then
            _Cadena_Conexion_MySql = Fx_Cadena_Conexion_MySql()
            _Clas_Ps = New Class_MySQL(_Cadena_Conexion_MySql)
        End If

    End Sub

    Function Fx_Cadena_Conexion_MySql() As String

        Dim _Host As String = _Row_Prestashop.Item("Host")
        Dim _Usuario As String = _Row_Prestashop.Item("Usuario")
        Dim _Clave As String = _Row_Prestashop.Item("Clave")
        Dim _Base_Datos As String = _Row_Prestashop.Item("Base_Datos")

        Dim _Puerto_X_Defecto As Boolean = _Row_Prestashop.Item("Puerto_X_Defecto")
        Dim _Puerto = String.Empty

        If Not _Puerto_X_Defecto Then
            _Puerto = "Port=" & _Row_Prestashop.Item("Puerto") & ";"
        End If

        Dim _Ruta = "Host=" & _Host & ";Database=" & _Base_Datos &
                    ";Uid=" & _Usuario & ";Password=" & _Clave & ";" & _Puerto
        Return _Ruta

    End Function

    Function Fx_Tbl_Productos_Nuevos() As DataTable

        ' Limpiamos productos que esten repetidos y con Id_product diferente en la base de datos 
        Consulta_sql = "Select Z1.*," &
                       "(Select Count(*) From " & _Global_BaseBk & "Zw_Prod_PrestaShop Z2 Where Z2.Codigo = Z1.Codigo And Sitio = '" & Sitio & "') As Cuenta
                        Into #Paso
                        From " & _Global_BaseBk & "Zw_Prod_PrestaShop Z1 
                        Where Sitio = '" & _Sitio & "'

                        Delete " & _Global_BaseBk & "Zw_Prod_PrestaShop Where Id_product In (Select Id_product From #Paso Where Cuenta > 1)

                        Drop Table #Paso"

        _Sql.Ej_consulta_IDU(Consulta_sql)


        Consulta_sql = "Select Id_product From " & _Global_BaseBk & "Zw_Prod_PrestaShop Where Sitio = '" & _Sitio & "'"
        Dim _Tbl_Prod_PrestaShop As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

        Dim _Filtro_id_product As String = Generar_Filtro_IN(_Tbl_Prod_PrestaShop, "", "id_product", True, False, "")

        If Convert.ToBoolean(_Tbl_Prod_PrestaShop.Rows.Count) Then
            _Filtro_id_product = "Where P1.id_product Not In " & _Filtro_id_product & " And reference <> ''"
        Else
            _Filtro_id_product = String.Empty
        End If

        Consulta_sql = "Select '" & Sitio & "' As Nombre_Pagina,P1.id_product,reference As Codigo,P4.name as Descripcion,P2.price As Precio,P3.quantity As Cantidad,P1.active 
                            From ps_product P1 
                            inner Join ps_product_shop P2 On P1.id_product = P2.id_product
                            inner Join ps_stock_available P3 On P1.id_product = P3.id_product
                            inner join ps_product_lang P4 On P1.id_product = P4.id_product" & vbCrLf &
                            _Filtro_id_product
        Dim _Tbl As DataTable = _Clas_Ps.Fx_Get_Datatable(Consulta_sql)

        Return _Tbl

    End Function

    Function Fx_Tbl_Productos_Prestashop(_Sitio As String, _Tbl_Prod_Algunos As DataTable, _Campo_Codigo As String) As DataTable

        Dim _Filtro_Algunos As String = String.Empty

        If Not IsNothing(_Tbl_Prod_Algunos) Then
            If Convert.ToBoolean(_Tbl_Prod_Algunos.Rows.Count) Then
                _Filtro_Algunos = Generar_Filtro_IN(_Tbl_Prod_Algunos, "", _Campo_Codigo, False, False, "'")
                _Filtro_Algunos = "And Codigo In " & _Filtro_Algunos
            End If
        End If

        Consulta_sql = "Select Id_product From " & _Global_BaseBk & "Zw_Prod_PrestaShop Where Sitio = '" & _Sitio & "'" & Space(1) & _Filtro_Algunos

        Dim _Tbl_Prod_PrestaShop As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

        Dim _Filtro_id_product As String = Generar_Filtro_IN(_Tbl_Prod_PrestaShop, "", "id_product", True, False, "")

        If Convert.ToBoolean(_Tbl_Prod_PrestaShop.Rows.Count) Then
            _Filtro_id_product = "Where P1.id_product In " & _Filtro_id_product
        Else
            _Filtro_id_product = String.Empty
        End If

        'Consulta_sql = "Select '" & Sitio & "' As Nombre_Pagina,P1.id_product,reference As Codigo,P4.name as Descripcion,P2.price As Precio,P3.quantity As Cantidad,P1.active 
        '                From ps_product P1 
        '                inner Join ps_product_shop P2 On P1.id_product = P2.id_product
        '                inner Join ps_stock_available P3 On P1.id_product = P3.id_product
        '                inner join ps_product_lang P4 On P1.id_product = P4.id_product" & vbCrLf &
        '                _Filtro_id_product

        Consulta_sql = "Select '" & Sitio & "' As Nombre_Pagina,P1.id_product,reference As Codigo,ifnull(P4.name,'S/D') as Descripcion,ifnull(P2.price,0) As Precio,ifnull(P3.quantity,0) As Cantidad,P1.active 
                        From ps_product P1 
                        Left Join ps_product_shop P2 On P1.id_product = P2.id_product
                        left Join ps_stock_available P3 On P1.id_product = P3.id_product
                        left join ps_product_lang P4 On P1.id_product = P4.id_product" & vbCrLf &
                        _Filtro_id_product

        Fx_Tbl_Productos_Prestashop = _Clas_Ps.Fx_Get_Datatable(Consulta_sql)

    End Function

    Sub Sb_Insertar_Nuevos_Productos_Desde_Prestashop_Hacia_Tabla_Prod_PrestaShop(_Actualizar_Todos As Boolean)

        Dim _Codigo As String
        Dim _Descripcion As String

        Consulta_sql = "Delete " & _Global_BaseBk & "Zw_Prod_PrestaShop Where Sitio = '" & Sitio & "' And Codigo = ''"
        _Sql.Ej_consulta_IDU(Consulta_sql)

        If _Actualizar_Todos Then

            Consulta_sql = "Delete " & _Global_BaseBk & "Zw_Prod_PrestaShop Where Sitio = '" & Sitio & "'"
            _Sql.Ej_consulta_IDU(Consulta_sql)

        End If

        Dim _Tbl_Productos As DataTable = Fx_Tbl_Productos_Nuevos()

        Try

            Dim _Cant_Encontrados As Long = 0
            Dim _Cant_NO_Encontrados As Long = 0

            Progress_Porcent.Maximum = 100
            Progress_Canti.Maximum = _Tbl_Productos.Rows.Count

            Dim Contador As Long = 0
            Progress_Canti.Value = 0
            Progress_Porcent.Value = 0

            Dim _Codigo_Pagina As String = _Row_Prestashop.Item("Codigo_Pagina")
            Dim _Cod_Lista As String = _Row_Prestashop.Item("Cod_Lista")
            Dim _Stock_Maximo As Double = _Row_Prestashop.Item("Stock_Maximo")

            For Each _Fila As DataRow In _Tbl_Productos.Rows

                System.Windows.Forms.Application.DoEvents()

                Dim _Fl As Integer = 0

                Dim _Id_product = _Fila.Item("id_product")
                _Codigo = _Fila.Item("Codigo")
                _Descripcion = _Fila.Item("Descripcion")

                Dim _Stock As Double = NuloPorNro(_Fila.Item("Cantidad"), 0)
                Dim _Precio As Double = NuloPorNro(_Fila.Item("Precio"), 0)

                Dim _Stock_Rd As Double = 0 'Fx_Traer_Stock(_Codigo, _Stock_Maximo, 1) '_Fila.Item("Cantidad")
                Dim _Precio_Rd As Double = 0 'Fx_Traer_Precio(_Codigo, _Cod_Lista, 1) '_Fila.Item("Precio")

                Dim _Active As Boolean = _Fila.Item("active")

                'If Not String.IsNullOrEmpty(_Codigo) Then

                Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Prod_PrestaShop (Sitio,Id_product,Codigo,Descripcion,Stock,Precio,Active,Usar_Padre,Stock_Rd,Precio_Rd) Values" & Space(1) &
                               "('" & _Sitio & "'," & _Id_product & ",'" & _Codigo & "','" & _Descripcion &
                               "'," & De_Num_a_Tx_01(_Stock, False, 5) & "," & De_Num_a_Tx_01(_Precio, False, 5) &
                               "," & Convert.ToInt32(_Active) & ",1," &
                               De_Num_a_Tx_01(_Stock_Rd, False, 5) & "," & De_Num_a_Tx_01(_Precio_Rd, False, 5) & ")"

                If _Sql.Ej_consulta_IDU(Consulta_sql, False) Then

                    'Fx_Add_Log_Gestion(FUNCIONARIO, Modalidad, "", 0, "Prestashop",
                    '                   "Se inserta producto en tabla Zw_Prod_PrestaShop Sitio: " & _Sitio, "", _Codigo, "", "", False, "")
                Else

                    Fx_Add_Log_Gestion(FUNCIONARIO, Modalidad, "", 0, "Prestashop",
                               "Error al inserta producto en tabla Zw_Prod_PrestaShop. Sitio: " & _Sitio & " Error: " & _Sql.Pro_Error,
                               "", _Codigo, "", "", False, "")

                End If

                'Else

                '    Fx_Add_Log_Gestion(FUNCIONARIO, Modalidad, "", 0, "Prestashop",
                '               "Error al inserta producto en tabla Zw_Prod_PrestaShop. Sitio: " & _Sitio & " Error: Id_product = " & _Id_product & ", Referencia vacia.", "", _Codigo, "", "", False, "")

                'End If

                If Contador = 3148 Then
                    Dim ACA = 0
                End If

                _Etiqueta1.Text = _Sitio & ", Producto: " & _Codigo.Trim & " - " & _Descripcion.Trim
                _Etiqueta2.Text = "Insertando nuevos productos desde Prestashop hacia tabla [Prod_PrestaShop]: " & FormatNumber(Contador, 0) & " de " & FormatNumber(_Tbl_Productos.Rows.Count, 0)


                Contador += 1
                Progress_Porcent.Value = ((Contador * 100) / _Tbl_Productos.Rows.Count) 'Mas
                Progress_Canti.Value += 1

                If _Cancelar Then
                    If MessageBoxEx.Show("¿Esta seguro de detener el proceso?", "Detener proceso",
                                         MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                        Exit For
                    Else
                        _Cancelar = False
                    End If
                End If

            Next

            Progress_Canti.Value = 0
            Progress_Porcent.Value = 0

        Catch ex As Exception
            Fx_Add_Log_Gestion(FUNCIONARIO, Modalidad, "", 0, "Prestashop",
                               "Error al inserta producto en tabla Zw_Prod_PrestaShop. Sitio: " & _Sitio & Space(1) & ex.Message, "", _Codigo,
                               "", "", False, "")
        Finally

        End Try

    End Sub

    Sub Sb_Actualizar_Tabla_Prod_PrestaShop(_Tbl_Productos As DataTable)

        _Cancelar = False

        Dim _Codigo As String
        Dim _Descripcion As String

        Try

            Dim _Cant_Encontrados As Long = 0
            Dim _Cant_NO_Encontrados As Long = 0

            Dim Contador As Long = 0
            Progress_Canti.Value = 0
            Progress_Porcent.Value = 0

            Dim _Codigo_Pagina As String = _Row_Prestashop.Item("Codigo_Pagina")
            Dim _Cod_Lista As String = _Row_Prestashop.Item("Cod_Lista")
            Dim _Stock_Maximo As Double = _Row_Prestashop.Item("Stock_Maximo")

            Dim _Sitio = _Row_Prestashop.Item("Nombre_Pagina")

            If IsNothing(_Tbl_Productos) Then

                _Tbl_Productos = Fx_Tbl_Productos_Prestashop(_Sitio, Nothing, "")

            End If

            If IsNothing(_Tbl_Productos) Then
                Return
            End If

            Progress_Porcent.Maximum = 100
            Progress_Canti.Maximum = _Tbl_Productos.Rows.Count

            For Each _Fila As DataRow In _Tbl_Productos.Rows

                Application.DoEvents()

                Dim _Fl As Integer = 0

                Dim _Id_product = _Fila.Item("id_product")

                _Codigo = _Fila.Item("Codigo")

                If _Codigo = "96403099K00" Then
                    Dim _aca = 0
                End If

                Try
                    _Descripcion = NuloPorNro(_Fila.Item("Descripcion"), "??? Valor Nulo")
                Catch ex As Exception
                    _Descripcion = "??? Valor Nulo"
                End Try

                Dim _Stock As Double = NuloPorNro(_Fila.Item("Cantidad"), 0)
                Dim _Precio As Double = NuloPorNro(_Fila.Item("Precio"), 0)

                Dim _Stock_Rd As Double
                Dim _Precio_Rd As Double

                Try
                    _Precio_Rd = Fx_Traer_Precio(_Codigo, _Cod_Lista, 1)
                Catch ex As Exception
                    _Precio_Rd = 0
                End Try


                Dim _Active As Boolean = _Fila.Item("active")
                Dim _Active_Rd As Boolean = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Prod_PrestaShop", "Active",
                                                              "Sitio = '" & _Sitio & "' And Id_product = " & _Id_product,,,, True)

                _Precio = Math.Round(_Precio, 2)
                _Precio_Rd = Math.Round(_Precio_Rd, 2)

                If _Precio_Rd = 0 Then
                    _Precio_Rd = _Precio
                End If

                Consulta_sql = "Update " & _Global_BaseBk & "Zw_Prod_PrestaShop Set 
                                Descripcion = '" & _Descripcion & "',
                                Active = " & Convert.ToInt32(_Active) & ",
                                Stock = " & De_Num_a_Tx_01(_Stock, False, 5) & ",
                                Precio = " & De_Num_a_Tx_01(_Precio, False, 5) & ",--
                                --Stock_Rd = " & De_Num_a_Tx_01(_Stock_Rd, False, 5) & ",
                                Precio_Rd = " & De_Num_a_Tx_01(_Precio_Rd, False, 5) & ",
                                FH_Actualizacion = Getdate()
                                Where Sitio = '" & _Sitio & "' And Id_product = " & _Id_product

                _Sql.Ej_consulta_IDU(Consulta_sql, False)

                _Etiqueta1.Text = _Sitio & ", Producto: " & _Codigo.Trim & " - " & _Descripcion.Trim

                Contador += 1
                Progress_Porcent.Value = ((Contador * 100) / _Tbl_Productos.Rows.Count) 'Mas
                Progress_Canti.Value += 1

                _Etiqueta2.Text = "Productos encontrador: " & FormatNumber(Contador, 0) & " de " & FormatNumber(_Tbl_Productos.Rows.Count, 0)

                Application.DoEvents()

                If _Cancelar Then
                    If MessageBoxEx.Show("¿Esta seguro de detener el proceso?", "Detener proceso",
                                         MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                        Exit For
                    Else
                        _Cancelar = False
                    End If
                End If

            Next

            Progress_Canti.Value = 0
            Progress_Porcent.Value = 0

            'Actualizamos los stock de los productos en la tabla de productos en Prestashop del Sitio en revisión, 
            'stock consolidado en las bodegas asignadas desde la tabla de caracterizaciones, Tabla 'PRESTASHOP_BOD' Llave = EMPRESA+SUCURSAL+BODEGA

            '******* Ahora los stock se activan segun la bodega que este activa en la tabla Zw_Prestashop_ps_warehouse

            Consulta_sql = "Select KOPR As Codigo,Sum(STFI1-STDV1) As 'Stock Fisico',Sum(STOCNV1) As 'Comprometido',
	                               Cast(0 As Float) As Nvv,Cast(0 As Float) As Nvi,	
	                               Sum(STFI1)-Sum(STOCNV1)-Isnull(Sum(StBk.StComp1),0) As 'Stock Disponible'
                            Into #Paso
                            From MAEST 
                            Left Join " & _Global_BaseBk & "Zw_Prod_Stock StBk On StBk.Codigo = KOPR And StBk.Empresa = EMPRESA And StBk.Sucursal = KOSU And StBk.Bodega = KOBO
                            Where 
                            Rtrim(Ltrim(EMPRESA))+Rtrim(Ltrim(KOSU))+Rtrim(Ltrim(KOBO)) In (Select Rtrim(Ltrim(Empresa))+Rtrim(Ltrim(Sucursal))+Rtrim(Ltrim(Bodega)) 
                            From " & _Global_BaseBk & "Zw_Prestashop_ps_warehouse Where Codigo_Pagina = '" & _Codigo_Pagina & "' And Activo = 1)
                            Group By KOPR

                            Select KOPRCT As Codigo,Isnull(Sum(CAPRCO1-CAPRAD1-CAPREX1),0) As Saldo 
                            Into #Nvv
                            From MAEDDO
                            Where TIDO = 'NVV' And KOPRCT In (Select Codigo From #Paso)
                            And ESLIDO = ''
                            Group By KOPRCT

                            Select KOPRCT As Codigo,Isnull(Sum(CAPRCO1-CAPRAD1-CAPREX1),0) As Saldo 
                            Into #Nvi
                            From MAEDDO
                            Where TIDO = 'NVI' And KOPRCT In (Select Codigo From #Paso)
                            And ESLIDO = ''
                            Group By KOPRCT

                                --Select PsPr.*,#Paso.[Stock Fisico],#Paso.[Stock Disponible],Case When #Paso.[Stock Disponible] <> PsPr.Stock_Rd And #Paso.[Stock Disponible] < 50 Then 'Dif' Else '' End As Dif From #Paso 
                                --Inner Join " & _Global_BaseBk & "Zw_Prod_PrestaShop PsPr On PsPr.Sitio = '" & _Sitio & "' And PsPr.Codigo = #Paso.Codigo

                            Update #Paso Set Nvv = Isnull(#Nvv.Saldo,0),Nvi = Isnull(#Nvi.Saldo,0)
                            From #Paso 
                            Left Join #Nvv On #Nvv.Codigo = #Paso.Codigo
                            Left Join #Nvi On #Nvi.Codigo = #Paso.Codigo

                            Update #Paso Set [Stock Disponible] = [Stock Fisico]-Nvv 
                            Update #Paso Set [Stock Disponible] = 0 Where [Stock Disponible] < 0

                            Update " & _Global_BaseBk & "Zw_Prod_PrestaShop Set Stock_Rd = #Paso.[Stock Disponible]
                            From #Paso 
                            Inner Join " & _Global_BaseBk & "Zw_Prod_PrestaShop PsPr On PsPr.Sitio = '" & _Sitio & "' And PsPr.Codigo = #Paso.Codigo

                            Drop Table #Paso
                            Drop Table #Nvv
                            Drop Table #Nvi"


            Consulta_sql = "Select KOPR As Codigo,Sum(STFI1-STDV1) As 'Stock Fisico',Sum(STOCNV1) As 'Comprometido',
	                               Cast(0 As Float) As Nvv,Cast(0 As Float) As Nvi,	
	                               Sum(STFI1)-Sum(STOCNV1)-Isnull(Sum(StBk.StComp1),0) As 'Stock Disponible'
                            Into #Paso
                            From MAEST 
                            Left Join " & _Global_BaseBk & "Zw_Prod_Stock StBk On StBk.Codigo = KOPR And StBk.Empresa = EMPRESA And StBk.Sucursal = KOSU And StBk.Bodega = KOBO
                            Where 
                            Rtrim(Ltrim(EMPRESA))+Rtrim(Ltrim(KOSU))+Rtrim(Ltrim(KOBO)) In (Select Rtrim(Ltrim(Empresa))+Rtrim(Ltrim(Sucursal))+Rtrim(Ltrim(Bodega)) 
                            From " & _Global_BaseBk & "Zw_Prestashop_ps_warehouse Where Codigo_Pagina = '" & _Codigo_Pagina & "' And Activo = 1)
                            Group By KOPR

                            Update " & _Global_BaseBk & "Zw_Prod_PrestaShop Set Stock_Rd = #Paso.[Stock Disponible]
                            From #Paso 
                            Inner Join " & _Global_BaseBk & "Zw_Prod_PrestaShop PsPr On PsPr.Sitio = '" & _Sitio & "' And PsPr.Codigo = #Paso.Codigo

                            Drop Table #Paso"

            _Sql.Ej_consulta_IDU(Consulta_sql, False)

            Consulta_sql = "Update " & _Global_BaseBk & "Zw_Prod_PrestaShop Set Precio_Rd = Precio 
                            Where Sitio = '" & _Sitio & "' And Precio_Rd = 0 And Precio > 0"
            _Sql.Ej_consulta_IDU(Consulta_sql, False)

        Catch ex As Exception

            MessageBoxEx.Show(_Codigo & " - " & _Descripcion & vbCrLf & vbCrLf & ex.Message, "Problemas!!", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub

    Sub Sb_Actualizar_Datos_En_Prestashop(_Tbl_Prod_PrestaShop As DataTable, _Actualizacion_Completa As Boolean)

        _Cancelar = False

        'Dim _Actualizacion_Completa As Boolean

        If Not IsNothing(_Tbl_Prod_PrestaShop) Then

            Dim _Filtro_Productos As String = Generar_Filtro_IN(_Tbl_Prod_PrestaShop, "", "Codigo", False, False, "'")

            If Convert.ToBoolean(_Tbl_Prod_PrestaShop.Rows.Count) Then
                _Filtro_Productos = "And Codigo In " & _Filtro_Productos
            End If

            Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Prod_PrestaShop 
                            Where Sitio = '" & _Sitio & "'" & Space(1) & _Filtro_Productos
            _Tbl_Prod_PrestaShop = _Sql.Fx_Get_DataTable(Consulta_sql)

        Else

            If _Actualizacion_Completa Then
                Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Prod_PrestaShop 
                            Where Sitio = '" & _Sitio & "'"
            Else
                Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Prod_PrestaShop 
                            Where Sitio = '" & _Sitio & "' And (Stock <> Stock_Rd Or Precio <> Precio_Rd) And Stock_Rd <= 50"
            End If
            _Tbl_Prod_PrestaShop = _Sql.Fx_Get_DataTable(Consulta_sql)

            '_Actualizacion_Completa = True

        End If

        Progress_Porcent.Maximum = 100
        Progress_Canti.Maximum = _Tbl_Prod_PrestaShop.Rows.Count

        _Cadena_Conexion_MySql = Fx_Cadena_Conexion_MySql()
        Dim _Clas_Ps As New Class_MySQL(_Cadena_Conexion_MySql)

        Dim _Contador = 0

        For Each _Fila As DataRow In _Tbl_Prod_PrestaShop.Rows

            Dim _Id_product As Integer = _Fila.Item("Id_product")
            Dim _Codigo As String = _Fila.Item("Codigo")
            Dim _Descripcion As String = _Fila.Item("Descripcion")

            Dim _Precio_Old As Double = _Fila.Item("Precio")
            Dim _Stock_Old As Double = _Fila.Item("Stock")

            Dim _Stock_Rd As Double = _Fila.Item("Stock_Rd")
            Dim _Precio_Rd As Double = _Fila.Item("Precio_Rd")
            Dim _Active As Boolean = _Fila.Item("Active")
            Dim _Usar_Padre As Boolean = _Fila.Item("Usar_Padre")

            Dim _Error As String = String.Empty

            ' ACTUALIZAR PRECIOS

            Application.DoEvents()

            _Precio_Old = Math.Round(_Precio_Old, 2)
            _Precio_Rd = Math.Round(_Precio_Rd, 2)

            Dim _Actualizar_Precios As Boolean = (_Precio_Old <> _Precio_Rd)

            '_Actualizacion_Completa = False

            If _Actualizacion_Completa Then _Actualizar_Precios = True

            If _Actualizar_Precios Then

                Consulta_sql = "Update ps_product_shop set price = " & De_Num_a_Tx_01(_Precio_Rd, False, 8) & vbCrLf &
                           "Where id_product = " & Trim(_Id_product)

                If _Clas_Ps.Fx_Ej_consulta_IDU(Consulta_sql, False) Then

                    Consulta_sql = "Update ps_product set price = " & De_Num_a_Tx_01(_Precio_Rd, False, 8) & vbCrLf &
                               "Where id_product = " & Trim(_Id_product)

                    If _Clas_Ps.Fx_Ej_consulta_IDU(Consulta_sql, False) Then

                        'Fx_Add_Log_Gestion(FUNCIONARIO, Modalidad, "", 0, "Prestashop", "Se actualiza precio Sitio " & _Sitio &
                        '               ". Precio anterior " & FormatCurrency(_Precio_Old, 3) &
                        '               ", Nuevo Precio " & FormatCurrency(_Precio_Rd, 3), "", _Codigo, "", "", False, "")

                    Else

                        _Error = _Clas_Ps.Pro_Error

                    End If

                Else

                    _Error = "Error!! al insertar Precio"

                End If

                If Not String.IsNullOrEmpty(_Error) Then

                    Fx_Add_Log_Gestion(Nothing, Modalidad, "", 0, "Prestashop",
                                       "Error_Prestashop_Precio! " & _Sitio & Space(1) & _Clas_Ps.Pro_Error, "", _Codigo,
                                       "", "", False, FUNCIONARIO)
                    _Error = String.Empty

                End If

            End If

            If _Codigo = "1161068K03IND" Then
                Dim _a = 1
            End If

            ' ACTUALIZAR STOCK

            Dim _Stock_Maximo As Double = _Row_Prestashop.Item("Stock_Maximo")

            If _Stock_Rd > _Stock_Maximo Then _Stock_Rd = _Stock_Maximo

            Dim _Actualizar_Stock As Boolean = (_Stock_Old <> _Stock_Rd)

            If _Actualizacion_Completa Then _Actualizar_Stock = True



            If _Actualizar_Stock Then

                Dim _Codigo_Pagina As String = _Row_Prestashop.Item("Codigo_Pagina")
                Dim _Grabar_Stock_X_Bodega As Boolean = _Row_Prestashop.Item("Grabar_Stock_X_Bodega")

                If _Grabar_Stock_X_Bodega Then

                    Consulta_sql = "Select Codigo_Pagina, Empresa, Sucursal, Bodega, id_warehouse
                                From " & _Global_BaseBk & "Zw_Prestashop_ps_warehouse
                                Where Codigo_Pagina = '" & _Codigo_Pagina & "' And Activo = 1 And id_warehouse <> 0 Order By id_warehouse"
                    Dim _Tbl As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

                    For Each _FilaSt As DataRow In _Tbl.Rows

                        Try

                            Dim _id_warehouse = _FilaSt.Item("id_warehouse")
                            Dim _Empresa = _FilaSt.Item("Empresa")
                            Dim _Sucursal = _FilaSt.Item("Sucursal")
                            Dim _Bodega = _FilaSt.Item("Bodega")
                            Dim _Stock As Double

                            'Dim _Stock As Double = _Sql.Fx_Trae_Dato("MAEST", "STFI1",
                            '                                         "EMPRESA = '" & _Empresa & "' " &
                            '                                         "And KOSU = '" & _Sucursal & "' " &
                            '                                         "And KOBO = '" & _Bodega & "' " &
                            '                                         "And KOPR = '" & _Codigo & "'", True)

                            Consulta_sql = "Select KOPR As Codigo,Isnull(STFI1,0)-Isnull(STDV1,0) As 'Stock Fisico',Isnull(STOCNV1,0) As 'Comprometido'," & vbCrLf &
                                           "Isnull(STFI1,0)-Isnull(STOCNV1,0)-Isnull(StBk.StComp1,0) As 'StockDisponible'" & vbCrLf &
                                           "From MAEST" & vbCrLf &
                                           "Left Join " & _Global_BaseBk & "Zw_Prod_Stock StBk On " &
                                                "StBk.Codigo = KOPR And StBk.Empresa = EMPRESA And StBk.Sucursal = KOSU And StBk.Bodega = KOBO" & vbCrLf &
                                           "Where" & vbCrLf &
                                           "RTrim(LTrim(EMPRESA))+Rtrim(Ltrim(KOSU))+Rtrim(Ltrim(KOBO)) In (Select Rtrim(Ltrim(Empresa))+Rtrim(Ltrim(Sucursal))+Rtrim(Ltrim(Bodega))" & vbCrLf &
                                           "From " & _Global_BaseBk & "Zw_Prestashop_ps_warehouse Where Codigo_Pagina = '" & _Codigo_Pagina & "' And Activo = 1)" & vbCrLf &
                                           "And EMPRESA = '" & _Empresa & "' And KOSU = '" & _Sucursal & "' And KOBO = '" & _Bodega & "' And KOPR = '" & _Codigo & "'"

                            Dim _Row_StockXBod As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

                            If IsNothing(_Row_StockXBod) Then
                                _Stock = 0
                            Else
                                _Stock = _Row_StockXBod.Item("StockDisponible")
                            End If

                            If _Stock > _Stock_Maximo Then
                                _Stock = _Stock_Maximo
                            End If

                            Consulta_sql = "Select * From ps_stock Where id_warehouse = " & _id_warehouse & " And id_product = " & _Id_product
                            Dim _Row As DataRow = _Clas_Ps.Fx_Get_DataRow(Consulta_sql)

                            ' Se insertan los Stock por bodega, sucursal en Prestashop...

                            If IsNothing(_Row) Then
                                Consulta_sql = "Insert Into ps_stock (id_warehouse, id_product, id_product_attribute, reference, ean13, isbn, upc, physical_quantity, usable_quantity, price_te) Values
                                       (" & _id_warehouse & "," & _Id_product & ",0,'" & _Codigo & "','','',''," & De_Num_a_Tx_01(_Stock, False, 3) & ",0," & De_Num_a_Tx_01(_Precio_Rd, False, 8) & ")"
                            Else
                                Consulta_sql = "Update ps_stock Set physical_quantity = " & De_Num_a_Tx_01(_Stock, False, 3) & ",price_te = " & De_Num_a_Tx_01(_Precio_Rd, False, 8) & " Where id_warehouse = " & _id_warehouse & " And id_product = " & _Id_product
                            End If

                            _Clas_Ps.Fx_Ej_consulta_IDU(Consulta_sql, False)

                            ' Revisamos si existe el producto en la tabla ps_warehouse_product_location, sino existe lo insertamos

                            Consulta_sql = "Select * From ps_warehouse_product_location Where id_warehouse = " & _id_warehouse & " And id_product = " & _Id_product
                            _Row = _Clas_Ps.Fx_Get_DataRow(Consulta_sql)

                            If IsNothing(_Row) Then
                                Consulta_sql = "Insert Into ps_warehouse_product_location (id_product,id_product_attribute,id_warehouse,location) Values " &
                                               "(" & _Id_product & ",0,'" & _id_warehouse & "','')"
                                _Clas_Ps.Fx_Ej_consulta_IDU(Consulta_sql, False)
                            End If

                            Etiqueta1.Text = "Producto: " & _Descripcion & ". SucBod: " & _Sucursal & "-" & _Bodega
                            Application.DoEvents()

                        Catch ex As Exception
                            MessageBoxEx.Show(ex.Message)
                        End Try

                    Next

                End If

                Consulta_sql = "Update ps_product Set advanced_stock_management = " & Convert.ToInt32(_Grabar_Stock_X_Bodega) & vbCrLf &
                               "Where id_product = " & _Id_product
                _Clas_Ps.Fx_Ej_consulta_IDU(Consulta_sql, False)

                Consulta_sql = "Update ps_stock_available set quantity= " & De_Num_a_Tx_01(_Stock_Rd) & vbCrLf &
                               "Where id_product = " & Trim(_Id_product) & vbCrLf

                If _Clas_Ps.Fx_Ej_consulta_IDU(Consulta_sql, False) Then

                    'Fx_Add_Log_Gestion(FUNCIONARIO, Modalidad, "", 0, "Prestashop", "Se actualiza Stock. Sitio: " & _Sitio &
                    '                       ". Stock anterior " & FormatNumber(_Stock_Old, 3) &
                    '                       ", Nuevo stock " & FormatNumber(_Stock_Rd, 3), "", _Codigo, "", "", False, "")

                Else

                    _Error = _Clas_Ps.Pro_Error

                End If

                If Not String.IsNullOrEmpty(_Error) Then

                    Fx_Add_Log_Gestion(Nothing, Modalidad, "", 0, "Prestashop",
                                       "Error_Prestashop_Stock! " & _Sitio & Space(1) & _Clas_Ps.Pro_Error, "", _Codigo, "",
                                       "", False, FUNCIONARIO)
                    _Error = String.Empty

                End If

            End If

            If _Actualizar_Stock Or _Actualizar_Precios Then
                Consulta_sql = "Update " & _Global_BaseBk & "Zw_Prod_PrestaShop Set FH_Revision = Getdate() Where Sitio = '" & Sitio & "' And Codigo = '" & _Codigo & "'"
                _Sql.Ej_consulta_IDU(Consulta_sql, False)
            End If

            _Contador += 1
            Progress_Porcent.Value = ((_Contador * 100) / _Tbl_Prod_PrestaShop.Rows.Count)
            Progress_Canti.Value += 1

            Etiqueta1.Text = "Producto: " & _Descripcion

            Etiqueta2.Text = "Productos procesados: " &
                              FormatNumber(_Contador, 0) & " de " & FormatNumber(_Tbl_Prod_PrestaShop.Rows.Count, 0)

            If _Cancelar Then
                If MessageBoxEx.Show("¿Esta seguro de detener el proceso?", "Detener proceso",
                                      MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    Exit For
                Else
                    _Cancelar = False
                End If
            End If

        Next

        Progress_Canti.Value = 0
        Progress_Porcent.Value = 0

        Consulta_sql = "Update " & _Global_BaseBk & "Zw_Prod_PrestaShop Set Precio = Precio_Rd, Stock = Stock_Rd Where Sitio = '" & _Sitio & "'"
        _Sql.Ej_consulta_IDU(Consulta_sql, False)

        Consulta_sql = "Update " & _Global_BaseBk & "Zw_Prod_PrestaShop Set Stock = 50 Where Sitio = '" & _Sitio & "' And Stock > " & _Row_Prestashop.Item("Stock_Maximo")
        _Sql.Ej_consulta_IDU(Consulta_sql, False)

    End Sub

    Sub Sb_Activar_Desactivar_Datos_En_Prestashop()

        Dim _Codigo_Padre_Primario As Boolean = _Row_Prestashop.Item("Codigo_Padre_Primario")

        Dim _Desactivar_01 As Boolean = _Row_Prestashop.Item("Desactiva_01")
        Dim _Desactivar_02 As Boolean = _Row_Prestashop.Item("Desactiva_02")
        Dim _Desactivar_03 As Boolean = _Row_Prestashop.Item("Desactiva_03")
        Dim _Desactivar_04 As Boolean = _Row_Prestashop.Item("Desactiva_04")

        Dim _Condiciones_Inactivar As String

        If _Codigo_Padre_Primario Then

            If _Desactivar_01 Then

                _Condiciones_Inactivar = "-- Desactiva Si es Importado/Primario y tiene stock es igual a 0" & vbCrLf &
                                         "Update #Paso Set Active = 0 Where Primario = 1 And Stock_Rd = 0" & vbCrLf

            End If

            If _Desactivar_02 Then

                _Condiciones_Inactivar += "-- Desactiva Si es hijo y el stock del padre es mayor o igual a cero" & vbCrLf &
                                         "Update #Paso Set Active = 0 Where Padre <> '' And Stock_Padre > 0" & vbCrLf

            End If

            If _Desactivar_03 Then

                _Condiciones_Inactivar += "-- Desactiva Si el precio es 0" & vbCrLf &
                                          "Update #Paso Set Active = 0 Where Precio <= 0" & vbCrLf

            End If

            If _Desactivar_04 Then

                Dim _Minimo_Stock As Double = _Row_Prestashop.Item("Minimo_Stock")

                _Condiciones_Inactivar += "-- Desactiva Si el stock es <= Al Minimo Stock" & vbCrLf &
                                          "Update #Paso Set Active = 0 Where Stock <= " & _Minimo_Stock & vbCrLf

            End If

            If Not String.IsNullOrEmpty(_Condiciones_Inactivar) Then

                Consulta_sql = My.Resources.Recursos_Prestashop.SQLQuery_Active_Productos
                Consulta_sql = Replace(Consulta_sql, "#Sitio#", Sitio)
                Consulta_sql = Replace(Consulta_sql, "#Global_Base_Bakapp#", _Global_BaseBk)
                Consulta_sql = Replace(Consulta_sql, "#Condiciones_Inactivar#", _Condiciones_Inactivar)

                If _Sql.Ej_consulta_IDU(Consulta_sql, False) Then

                    Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Prod_PrestaShop 
                        Where Sitio = '" & _Sitio & "' And Active = 1"
                    Dim _Tbl_Prod_PrestaShop_Activos As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

                    Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Prod_PrestaShop 
                        Where Sitio = '" & _Sitio & "' And Active = 0"
                    Dim _Tbl_Prod_PrestaShop_Inactivos As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

                    Dim _Filtro_id_product_Activos As String = Generar_Filtro_IN(_Tbl_Prod_PrestaShop_Activos, "", "Id_product", False, False, "")
                    Dim _Filtro_id_product_Inactivos As String = Generar_Filtro_IN(_Tbl_Prod_PrestaShop_Inactivos, "", "Id_product", False, False, "")


                    If Convert.ToBoolean(_Tbl_Prod_PrestaShop_Activos.Rows.Count) Then

                        Consulta_sql = "Update ps_product set active = b'1'" & vbCrLf &
                                       "Where id_product in " & _Filtro_id_product_Activos

                        If _Clas_Ps.Fx_Ej_consulta_IDU(Consulta_sql, False) Then

                            Consulta_sql = "Update ps_product_shop set active = b'1'" & vbCrLf &
                                           "Where id_product in " & _Filtro_id_product_Activos
                            _Clas_Ps.Fx_Ej_consulta_IDU(Consulta_sql, False)

                        End If

                    End If

                    If Convert.ToBoolean(_Tbl_Prod_PrestaShop_Inactivos.Rows.Count) Then

                        Consulta_sql = "Update ps_product set active = b'0'" & vbCrLf &
                                       "Where id_product in " & _Filtro_id_product_Inactivos

                        If _Clas_Ps.Fx_Ej_consulta_IDU(Consulta_sql, False) Then

                            Consulta_sql = "Update ps_product_shop set active = b'0'" & vbCrLf &
                                           "Where id_product in " & _Filtro_id_product_Inactivos
                            _Clas_Ps.Fx_Ej_consulta_IDU(Consulta_sql, False)

                        End If

                    End If

                End If

            End If

        End If

    End Sub

    Function Fx_Traer_Precio(_Codigo As String, _Cod_Lista As String, _UnTrans As Integer) As Double

        Dim _Row_Precios As DataRow
        Dim _Row_Lista As DataRow

        Consulta_sql = "Select Top 1 * From TABPRE Where KOLT = '" & _Cod_Lista & "' And KOPR = '" & _Codigo & "'"
        _Row_Precios = _Sql.Fx_Get_DataRow(Consulta_sql)

        If IsNothing(_Row_Precios) Then Return 0

        Consulta_sql = "Select Top 1 * From TABPP Where KOLT = '" & _Cod_Lista & "'"
        _Row_Lista = _Sql.Fx_Get_DataRow(Consulta_sql)

        If IsNothing(_Row_Lista) Then Return 0

        Dim _Precio As Double = _Row_Precios.Item("PP0" & _UnTrans & "UD")
        Dim _Ecuacion As String = NuloPorNro(_Row_Precios.Item("ECUACION"), "")
        Dim _Melt As String = _Row_Lista.Item("MELT")

        If Trim(_Ecuacion) = Trim(LCase(_Ecuacion)) Then

            Dim _Tiene_C As Boolean = InStr(1, _Ecuacion, "<")
            Dim _Tiene_Cor As Boolean = InStr(1, _Ecuacion, "[")

            If Not _Tiene_C Then

                If Not _Tiene_Cor Then

                    Dim _Campo_Precio
                    Dim _Campo_Ecuacion

                    If _UnTrans = 1 Then
                        _Campo_Precio = "PP01UD"
                        _Campo_Ecuacion = "ECUACION"
                    Else
                        _Campo_Precio = "PP02UD"
                        _Campo_Ecuacion = "ECUACIONU2"
                    End If

                    _Precio = Fx_Precio_Formula_Random(_Row_Precios, _Campo_Precio, _Campo_Ecuacion, Nothing, True, "", 1, 1)

                    If _Melt = "B" Then
                        _Precio = Math.Round(_Precio / 1.19, 6)
                    End If

                End If

            End If

        End If

        Return _Precio

    End Function

    Function Fx_Traer_Stock(_Codigo As String, _Stock_Maximo As Double, _UnTrans As Integer) As Double

        Dim _Stock As Double = _Sql.Fx_Trae_Dato("MAEST", "SUM(STFI" & _UnTrans & ")", "KOPR = '" & _Codigo & "'", True)
        Dim _Stock_Total = _Stock

        If _Stock > _Stock_Maximo Then _Stock = _Stock_Maximo

        Return _Stock

    End Function


End Class
