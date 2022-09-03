Imports System.Net
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class Cl_Wordpress

    Dim _Nombre_Pagina As String
    Dim _Consumer_key_get As String
    Dim _Consumer_secret_get As String
    Dim _Consumer_key_put As String
    Dim _Consumer_secret_put As String
    Dim _Cod_Lista As String

    Dim _Row_Wordpress_Keys As DataRow

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Public Property Row_Wordpress_Keys As DataRow
        Get
            Return _Row_Wordpress_Keys
        End Get
        Set(value As DataRow)
            _Row_Wordpress_Keys = value
        End Set
    End Property

    Public Property Cod_Lista As String
        Get
            Return _Cod_Lista
        End Get
        Set(value As String)
            _Cod_Lista = value
        End Set
    End Property

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
            Dim Producto As DataTable = _Sql.Fx_Get_Tablas(ConsultaSQL)
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
End Class
