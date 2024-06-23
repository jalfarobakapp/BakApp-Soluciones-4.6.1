Imports System.Net
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class Cl_Wordpress

    Dim _Nombre_Pagina As String
    Dim _Consumer_key_get As String
    Dim _Consumer_secret_get As String
    Dim _Consumer_key_put As String
    Dim _Consumer_secret_put As String
    'Dim _Cod_Lista As String

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Public Property Row_Wordpress_Keys As DataRow
    Public Property Cod_Lista As String
    Public Property Log_Progreso As String
    Public Property Procesando As Boolean

    Public Sub New()
        Sb_Traer_Keys()
    End Sub

    Sub Sb_Traer_Keys()

        Consulta_sql = "Select Top 1 * From " & _Global_BaseBk & "Zw_Wordpress"
        _Row_Wordpress_Keys = _Sql.Fx_Get_DataRow(Consulta_sql)

        If Not IsNothing(_Row_Wordpress_Keys) Then
            _Nombre_Pagina = _Row_Wordpress_Keys.Item("Nombre_Pagina")
            _Consumer_key_get = _Row_Wordpress_Keys.Item("Consumer_Key_Get")
            _Consumer_secret_get = _Row_Wordpress_Keys.Item("Consumer_Secret_Get")
            _Consumer_key_put = _Row_Wordpress_Keys.Item("Consumer_Key_Put")
            _Consumer_secret_put = _Row_Wordpress_Keys.Item("Consumer_Secret_Put")
            _Cod_Lista = _Row_Wordpress_Keys.Item("Cod_Lista")
        End If

    End Sub

    Function GetRequest(Api As String, Parametros As String) As String
        Try

            Dim RequestURL
            Using webClient As WebClient = New WebClient()
                ServicePointManager.SecurityProtocol = CType(3072, SecurityProtocolType)
                webClient.BaseAddress = _Nombre_Pagina ' "https://ferrecor.cl"
                RequestURL = Api & "consumer_key=" & _Consumer_key_get & "&consumer_secret=" & _Consumer_secret_get & Parametros
                Dim response = webClient.DownloadString(RequestURL)
                Dim hola As String
                hola = ""
                Return response
            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

    Function PutRequest(Api As String, Json As String) As String
        Dim RequestURL
        Using webClient As WebClient = New WebClient()
            ServicePointManager.SecurityProtocol = CType(3072, SecurityProtocolType)
            webClient.BaseAddress = _Nombre_Pagina ' "https://ferrecor.cl"
            RequestURL = Api & "consumer_key=" & _Consumer_key_put & "&consumer_secret=" & _Consumer_secret_put
            webClient.Headers(HttpRequestHeader.ContentType) = "application/json"
            Dim response = webClient.UploadString(RequestURL, WebRequestMethods.Http.Put, Json)
            Return response
        End Using
    End Function

    'Function ActualizarStock(Codigo_Producto As String, StockProducto As String) As String
    '    Try
    '        'Dim JsonString As String = "{""stock_quantity"": " & StockProducto & "}"
    '        Dim JsonString As String = "{""meta_data"":[{""key"":""update_random"",""value"":""true""},{""key"":""last_update_random"",""value"": """ & Now.ToString("yyyy-MM-ddTHH:mm:ss") & """}],""stock_quantity"": " & StockProducto & "}"
    '        Dim Respuesta As String = PutRequest("/wp-json/wc/v3/products/" & Codigo_Producto & "?", JsonString)
    '        Return "True"
    '    Catch ex As Exception
    '        Return ex.Message
    '    End Try
    'End Function

    Function ActualizarStock(Codigo_Producto As String, StockProducto As String, PrecioProducto As String) As String
        Try
            'Dim JsonString As String = "{""stock_quantity"": " & StockProducto & "}"
            Dim JsonString As String = "{""meta_data"":[{""key"":""update_random"",""value"":""true""},{""key"":""last_update_random"",""value"": """ & Now.ToString("yyyy-MM-ddTHH:mm:ss") & """}],""stock_quantity"": """ & StockProducto & """,""price"": """ & PrecioProducto & """,""regular_price"": """ & PrecioProducto & """}"
            Dim Respuesta As String = PutRequest("/wp-json/wc/v3/products/" & Codigo_Producto & "?", JsonString)
            Return "True"
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function

    Function ObtenerProductos() As JArray
        Try
            Dim Respuesta As String = GetRequest("/wp-json/wc/v3/products?", "&_fields[]= name&_fields[]=sku&_fields[]=price&_fields[]=stock_quantity&_fields[]=id")
            Dim Arr As JArray = JsonConvert.DeserializeObject(Of Object)(Respuesta)
            Return Arr
        Catch Ex As Exception
            Return Nothing
        End Try
    End Function

    Function ConsultarProducto(Kopr As String) As Boolean
        Try
            Dim ConsultaSQL = "Select KOPR From MAEPR Where KOPR='" & Kopr & "'"
            Dim Producto As DataTable = _Sql.Fx_Get_DataTable(ConsultaSQL)
            Dim Filas As Integer = Producto.Rows.Count
            If Filas > 0 Then
                Return True
            Else
                Return False
            End If
        Catch Ex As Exception
            Return False
        End Try
    End Function

    Sub Sb_Sincronizar_Productos_Precios_Stock_Con_Web(_Empresa As String)

        Procesando = True

        Try

            Dim _PrecioNeto As Boolean = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Wordpress", "PrecioNeto", "1>0")

            Dim _Campo_Precio As String

            If _PrecioNeto Then
                _Campo_Precio = "PrecioNeto"
            Else
                _Campo_Precio = "PrecioBruto"
            End If

            'en la tabla Zw_TablaDeCaracterizaciones Se deben grabar las bodegas para los filtros en el campo CodigoTabla
            'Ejemplo: Tabla = 'WORDPRESS_BOD', Campo = '01SUCBOD',NombreTabla = 'NOMBRE BODEGA'

            Consulta_sql = "Select CodigoTabla From " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones Where Tabla = 'WORDPRESS_BOD'"
            Dim _Tbl_Bodegas As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql, False)

            Dim _Filtros_Bod As String = "And EMPRESA = '" & _Empresa & "'" & vbCrLf

            If CBool(_Tbl_Bodegas.Rows.Count) Then
                _Filtros_Bod = Generar_Filtro_IN(_Tbl_Bodegas, "", "CodigoTabla", False, False, "'")
                _Filtros_Bod = "And Ms.EMPRESA+Ms.KOSU+Ms.KOBO In " & _Filtros_Bod & vbCrLf
            End If

            Consulta_sql = "Select Ms.KOPR,Case When Round(Sum(STFI1),0) >=0 Then Round(Sum(STFI1),0) Else 0 End As STFI1,
                    Isnull(Round(Tp.PP01UD/1.19,0),0) As PrecioNeto,
                    Round(Tp.PP01UD,0) As PrecioBruto
                    Into #Paso From MAEST Ms
                    Left Join TABPRE Tp On KOLT = '" & Cod_Lista & "' And Ms.KOPR = Tp.KOPR
                    Where Ms.KOPR In (Select Sku From " & _Global_BaseBk & "Zw_Wordpress_Productos)" & vbCrLf &
            _Filtros_Bod & vbCrLf &
            "Group By Ms.KOPR,Tp.PP01UD" &
            vbCrLf &
            "Insert " & _Global_BaseBk & "Zw_Demonio_Wordpress (Id_Producto,Sku,Stock,Precio,Descripcion,Fecha,Revisado,Error,Log_Error,Fecha_Hora,Empresa)
                    
                    Select Id_Producto,Sku,STFI1,Round(T1." & _Campo_Precio & ",0),Descripcion,Getdate(),0,0,'',Getdate(),Empresa 
                    From #Paso T1 
                    Inner Join " & _Global_BaseBk & "[Zw_Wordpress_Productos] T2 ON T1.KOPR=T2.Sku 
                    Where (T1.STFI1<>T2.Stock Or Round(T1." & _Campo_Precio & ",0) <> Round(T2.Precio,0))
                    Drop Table #Paso"

            _Sql.Ej_consulta_IDU(Consulta_sql, False)

            Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Demonio_Wordpress Where Revisado = 0"
            Dim _TblStockActualizado As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

            Dim _Contador = 1

            For Each _Fila As DataRow In _TblStockActualizado.Rows

                Dim _Id As Integer = _Fila.Item("Id")
                Dim _Id_Producto As Integer = _Fila.Item("Id_Producto")
                Dim _Sku As String = _Fila.Item("Sku")
                Dim _Stock As String = De_Num_a_Tx_01(_Fila.Item("Stock"), False, 5)
                Dim _Precio As String = De_Num_a_Tx_01(_Fila.Item("Precio"), False, 5)
                Dim _Stock_Producto As String
                Dim _Precio_Producto As String
                Dim _Log_Error = String.Empty

                _Stock_Producto = _Stock
                _Precio_Producto = _Precio

                If _Fila.Item("Stock") < 0 Then
                    _Stock_Producto = "0"
                    _Log_Error = "Stock negativo " & _Stock
                    _Stock = "0"
                End If

                Dim _Respuesta As String = ActualizarStock(_Id_Producto, _Stock_Producto, _Precio_Producto)

                If _Respuesta = "True" Then
                    Consulta_sql = "Update " & _Global_BaseBk & "Zw_Demonio_Wordpress" & vbCrLf &
                                   "Set Revisado = 1,Error = 0,Log_Error = '" & _Log_Error & "',Fecha_Hora=Getdate()" & vbCrLf &
                                   "Where Id='" & _Id & "'" & vbCrLf &
                                   "Update " & _Global_BaseBk & "Zw_Wordpress_Productos" & vbCrLf &
                                   "Set Stock='" & _Stock & "',Precio='" & _Precio & "',Actualizacion=Getdate()" & vbCrLf &
                                   "Where Id_Producto=" & _Id_Producto

                Else
                    Consulta_sql = "Update " & _Global_BaseBk & "Zw_Demonio_Wordpress " &
                                   "SET Revisado=1,Error=1,Log_Error = '" & _Respuesta & "',Fecha_Hora=Getdate()" & vbCrLf &
                                   "Where Id=" & _Id
                End If

                If _Sql.Ej_consulta_IDU(Consulta_sql, False) Then

                End If

                Application.DoEvents()

                Log_Progreso = "Revisando " & FormatNumber(_Contador, 0) & " de " & FormatNumber(_TblStockActualizado.Rows.Count, 0) & " productos..."
                _Contador += 1

            Next

        Catch ex As Exception
            Log_Progreso += ex.Message & vbCrLf
        Finally
            Procesando = False
        End Try

    End Sub

End Class
