Imports System.IO
Imports System.Net
Imports Newtonsoft.Json
Imports PdfSharp.Drawing
Imports PdfSharp.Pdf
Imports System.Drawing.Printing
Imports System.Drawing

Public Class Clas_CliexpressAPI

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Key_Cotizacion As String
    Dim _Key_Cobertura As String
    Dim _Key_Envio As String
    Dim _TCC As String
    Dim _Rut_Seller As String
    Dim _Rut_Mark As String
    Dim _CodigoRd As String
    Dim _CodTransportista As String
    Dim _NombreEtiqueta As String
    Dim _Es_Test As Boolean

    Dim _statusCode As Integer
    Dim _statusDescription As String
    Dim _errors As String

    Dim _Ruta_Etiqueta As String
    Dim _Nombre_Etiqueta As String

    Dim _Row_Envio As DataRow
    Dim _Row_Respuesta As DataRow


    Dim _PrtSettings As New PrinterSettings
    Dim DtFont As New Font("Arial", 9, FontStyle.Regular) ' Fuente del detalle
    Dim prFont As New Font("Arial", 9, FontStyle.Bold)
    Dim FontNro As New Font("Times New Roman", 14, FontStyle.Bold)
    Dim FontCon As New Font("Times New Roman", 11, FontStyle.Bold)

    Dim FteCourier_New_C_4 As New Font("Courier New", 4, FontStyle.Bold) ' Crea la fuente
    Dim FteCourier_New_C_6 As New Font("Courier New", 6, FontStyle.Bold) ' Crea la fuente
    Dim FteCourier_New_C_7 As New Font("Courier New", 7, FontStyle.Bold) ' Crea la fuente
    Dim FteCourier_New_C_8 As New Font("Courier New", 8, FontStyle.Bold) ' Crea la fuente
    Dim FteCourier_New_C_9 As New Font("Courier New", 9, FontStyle.Bold) ' Crea la fuente
    Dim FteCourier_New_C_10 As New Font("Courier New", 10, FontStyle.Bold) ' Crea la fuente
    Dim FteCourier_New_C_11 As New Font("Courier New", 11, FontStyle.Bold) ' Crea la fuente
    Dim FteCourier_New_C_12 As New Font("Courier New", 12, FontStyle.Bold) ' Crea la fuente
    Dim FteCourier_New_C_13 As New Font("Courier New", 13, FontStyle.Bold) ' Crea la fuente
    Dim FteCourier_New_C_14 As New Font("Courier New", 13, FontStyle.Bold) ' Crea la fuente


    Public Property StatusCode As Boolean
        Get
            Return _statusCode
        End Get
        Set(value As Boolean)
            _statusCode = value
        End Set
    End Property
    Public Property StatusDescription As String
        Get
            Return _statusDescription
        End Get
        Set(value As String)
            _statusDescription = value
        End Set
    End Property
    Public Property Errors As String
        Get
            Return _errors
        End Get
        Set(value As String)
            _errors = value
        End Set
    End Property
    Public Property Ruta_Etiqueta As String
        Get
            Return _Ruta_Etiqueta
        End Get
        Set(value As String)
            _Ruta_Etiqueta = value
        End Set
    End Property
    Public Property Nombre_Etiqueta As String
        Get
            Return _Nombre_Etiqueta
        End Get
        Set(value As String)
            _Nombre_Etiqueta = value
        End Set
    End Property
    Public Property CodigoRd As String
        Get
            Return _CodigoRd
        End Get
        Set(value As String)
            _CodigoRd = value
        End Set
    End Property
    Public Property CodTransportista As String
        Get
            Return _CodTransportista
        End Get
        Set(value As String)
            _CodTransportista = value
        End Set
    End Property
    Public Property NombreEtiqueta As String
        Get
            Return _NombreEtiqueta
        End Get
        Set(value As String)
            _NombreEtiqueta = value
        End Set
    End Property

    Public Sub New()

        Consulta_sql = "Select Top 1 * From " & _Global_BaseBk & "Zw_Chilexpress_Conf Order By Id Desc"
        Dim _Row_Conf As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        If IsNothing(_Row_Conf) Then
            _Key_Cobertura = String.Empty
            _Key_Cotizacion = String.Empty
            _Key_Envio = String.Empty

            _TCC = String.Empty
            _Rut_Seller = String.Empty
            _Rut_Mark = String.Empty

            _CodigoRd = String.Empty
            _CodTransportista = String.Empty
            _NombreEtiqueta = String.Empty
            _Es_Test = False
        Else
            _Key_Cobertura = _Row_Conf.Item("Key_Cobertura")
            _Key_Cotizacion = _Row_Conf.Item("Key_Cotizador")
            _Key_Envio = _Row_Conf.Item("Key_Envios")

            _TCC = _Row_Conf.Item("TCC")
            _Rut_Seller = _Row_Conf.Item("Rut_Seller")
            _Rut_Mark = _Row_Conf.Item("Rut_Mark")

            _CodigoRd = _Row_Conf.Item("CodigoRd")
            _CodTransportista = _Row_Conf.Item("CodTransportista")
            _NombreEtiqueta = _Row_Conf.Item("NombreEtiqueta")
            _Es_Test = _Row_Conf.Item("Es_Test")
        End If

        _Ruta_Etiqueta = AppPath() & "\Data\" & RutEmpresa & "\Tmp"

        If Not Directory.Exists(_Ruta_Etiqueta) Then
            System.IO.Directory.CreateDirectory(_Ruta_Etiqueta)
        End If

    End Sub

    ''' <summary>
    ''' Envio de datos
    ''' Este metodo permite hacer consultas POST a la api chilexpress y regresa la respuesta en formato json.
    ''' Los datos de entrada son el json de solicitud, la liga de la api a utilizar y la api key
    ''' </summary>
    ''' <param name="Str">ssss</param>
    ''' <param name="Api">2222</param>
    ''' <param name="Key">333</param>
    ''' <returns></returns>
    Function PostRequest(Str As String, Api As String, Key As String) As String
        Using webClient As WebClient = New WebClient()
            ServicePointManager.SecurityProtocol = CType(3072, SecurityProtocolType)
            If _Es_Test Then
                webClient.BaseAddress = "https://testservices.wschilexpress.com"
            Else
                webClient.BaseAddress = "https://services.wschilexpress.com"
            End If
            webClient.Headers.Add("Cache-Control", "no-cache")
            webClient.Headers.Add("Ocp-Apim-Subscription-Key", Key)
            webClient.Headers(HttpRequestHeader.ContentType) = "application/json"
            Dim response = webClient.UploadString(Api, Str)
            Return response
        End Using
    End Function

    ''' <summary>
    ''' Solicitud de datos.
    ''' Este metodo permite hacer consultas GET a la api chilexpress y regresa la respuesta en formato json.
    ''' Los datos de entrada son la liga de la api a utilizar incluyendo los parametros para el get y la api key
    ''' </summary>
    ''' <param name="Api"></param>
    ''' <param name="key"></param>
    ''' <returns></returns>
    Function GetRequest(Api As String, key As String) As String
        Dim response
        _errors = String.Empty
        Try
            Using webClient As WebClient = New WebClient()
                ServicePointManager.SecurityProtocol = CType(3072, SecurityProtocolType)
                If _Es_Test Then
                    webClient.BaseAddress = "https://testservices.wschilexpress.com"
                Else
                    webClient.BaseAddress = "https://services.wschilexpress.com"
                End If
                webClient.Headers.Add("Cache-Control", "no-cache")
                webClient.Headers.Add("Ocp-Apim-Subscription-Key", key)
                response = webClient.DownloadString(Api)
            End Using
        Catch ex As Exception
            response = String.Empty
            _errors = ex.Message
        End Try
        Return response
    End Function

    ''' <summary>
    ''' Convierte las respuestas de json en tabla tipo datatable
    ''' </summary>
    ''' <param name="Respuesta">Formato Json</param>
    ''' <param name="Objeto">Nombre del objeto que queremos encontrar dentro del json</param>
    ''' <returns></returns>
    Function Fx_TblFromJson(Respuesta As String, Objeto As String) As DataTable

        _statusCode = False
        _statusDescription = String.Empty
        _errors = String.Empty

        Dim result As Object
        result = JsonConvert.DeserializeObject(Of Object)(Respuesta)

        Dim _Json = "{'" & Objeto & "':" & result(Objeto).ToString & "}"

        _statusCode = result("statusCode").ToString.Trim
        _statusDescription = result("statusDescription").ToString.Trim
        _errors = result("errors").ToString.Trim

        Dim dataSet As DataSet

        dataSet = JsonConvert.DeserializeObject(Of DataSet)(_Json)

        Dim _Tbl As DataTable = dataSet.Tables(0)

        Return _Tbl

    End Function

    ''' <summary>
    ''' Cotizacion
    ''' </summary>
    ''' <param name="Respuesta"></param>
    ''' <param name="Objeto"></param>
    ''' <param name="_Es_Cotizacion">True</param>
    ''' <returns></returns>
    Function Fx_TblFromJson(Respuesta As String, Objeto As String, _Es_Cotizacion As Boolean) As DataTable

        _statusCode = False
        _statusDescription = String.Empty
        _errors = String.Empty

        Dim result As Object
        result = JsonConvert.DeserializeObject(Of Object)(Respuesta)

        result = result("data")

        Dim _Json = "{'" & Objeto & "':" & result(Objeto).ToString & "}"

        _statusCode = 0
        _statusDescription = String.Empty
        _errors = String.Empty

        Dim dataSet As DataSet

        dataSet = JsonConvert.DeserializeObject(Of DataSet)(_Json)

        Dim _Tbl As DataTable = dataSet.Tables(0)

        Return _Tbl

    End Function
    Public Sub Fx_Establecer_Conexion()
        'ConexionBD = New SqlClient.SqlConnection
        'ConexionBD.ConnectionString = "Server=186.67.37.218,1518;User Id=SIERRALTA_PRB;Password=SIERRALTA_PRB;"
        'ConexionBD.Open()
        'ConexionBD.Close()
    End Sub
    Function Fx_Traer_Regiones() As DataTable

        Dim _Respuesta As String = GetRequest("/georeference/api/v1.0/regions", _Key_Cobertura)
        Dim _Tbl As DataTable = Fx_TblFromJson(_Respuesta, "regions")

        Return _Tbl

    End Function

    Function Fx_Traer_Comunas(_CodigoRegion As String) As DataTable

        'Opciones para mostrar comunas dentro de la region
        Dim CodigoCobertura As String = 1 '"Comunas" 'ComboBox1.SelectedIndex.ToString()

        Dim _Respuesta As String = GetRequest("/georeference/api/v1.0/coverage-areas?RegionCode=" & _CodigoRegion &
                                              "&type=" & CodigoCobertura,
                                              _Key_Cobertura)
        Dim _Tbl As DataTable = Fx_TblFromJson(_Respuesta, "coverageAreas")

        Dim NewFila As DataRow
        NewFila = _Tbl.NewRow

        NewFila.Item("countyCode") = String.Empty
        NewFila.Item("countyName") = String.Empty
        NewFila.Item("regionCode") = String.Empty
        NewFila.Item("ineCountyCode") = 0
        NewFila.Item("queryMode") = 0
        NewFila.Item("coverageName") = String.Empty

        _Tbl.Rows.Add(NewFila)

        Return _Tbl

    End Function

    Function Fx_Traer_Todas_Las_Comunas() As DataTable

        Dim _Tbl_Regiones As DataTable = Fx_Traer_Regiones()
        Dim _Tbl_Todas_Comunas As DataTable = Nothing

        For Each _Region As DataRow In _Tbl_Regiones.Rows

            Dim _Tbl_Comunas As DataTable = Fx_Traer_Comunas(_Region.Item("regionId"))

            For Each _Comuna As DataRow In _Tbl_Comunas.Rows

                If IsNothing(_Tbl_Todas_Comunas) Then
                    _Tbl_Todas_Comunas = _Tbl_Comunas.Clone
                    _Tbl_Todas_Comunas.Clear()
                End If


                Dim NewFila As DataRow
                NewFila = _Tbl_Todas_Comunas.NewRow

                NewFila.Item("countyCode") = _Comuna.Item("countyCode")
                NewFila.Item("countyName") = _Comuna.Item("countyName")
                NewFila.Item("regionCode") = _Comuna.Item("regionCode")
                NewFila.Item("ineCountyCode") = _Comuna.Item("ineCountyCode")
                NewFila.Item("queryMode") = _Comuna.Item("queryMode")
                NewFila.Item("coverageName") = _Comuna.Item("coverageName")

                _Tbl_Todas_Comunas.Rows.Add(NewFila)

            Next

        Next

        Return _Tbl_Todas_Comunas

    End Function

    Function Fx_Traer_Calles(_Comuna_Destino As String, _Calle As String) As DataTable

        Dim json As String = "{
                                    ""countyName"": """ & _Comuna_Destino & """,
                                    ""streetName"": """ & _Calle & """,
                                    ""pointsOfInterestEnabled"": ""true"",
                                    ""streetNameEnabled"": ""true"",
                                    ""roadType"": ""0""
                                }"

        Dim _Respuesta As String = PostRequest(json, "/georeference/api/v1.0/streets/search", _Key_Cobertura)
        Dim _Tbl As DataTable = Fx_TblFromJson(_Respuesta, "streets")

        Return _Tbl

    End Function

    Function Fx_Traer_Nro_Calles(_idCalle As Integer, _Numero As String) As DataTable

        Dim _Respuesta As String = GetRequest("georeference/api/v1.0/streets/" & _idCalle & "/numbers?streetNumber=" & _Numero, _Key_Cobertura)
        Dim _Tbl As DataTable = Fx_TblFromJson(_Respuesta, "streetNumbers")
        Return _Tbl

    End Function

    Function Fx_Traer_Oficinas_Chilexpress(_RegionCode As String, CountyName As String)

        Dim _Respuesta As String = GetRequest("/georeference/api/v1.0/offices?Type=0&RegionCode=" & _RegionCode & "&CountyName=" & CountyName, _Key_Cobertura)
        Dim _Tbl As DataTable = Fx_TblFromJson(_Respuesta, "offices")
        Return _Tbl

    End Function

    Function Fx_Cotizar(_CodComunaOrigen As String,
                        _CodComunaDestino As String,
                        _Peso As String,
                        _Alto As String,
                        _Ancho As String,
                        _Largo As String,
                        _CodTipoProducto As String,
                        _Valor As String,
                        _CodTipoEnvio As Integer) As DataTable

        'json de solicitud para la api cotizaciones

        Dim _PesoKg = De_Num_a_Tx_01(_Peso, False, 2)
        Dim _AltoCm = De_Num_a_Tx_01(_Alto, False, 2)
        Dim _AnchoCm = De_Num_a_Tx_01(_Ancho, False, 2)
        Dim _LargoCm = De_Num_a_Tx_01(_Largo, False, 2)

        Dim json As String = "{
                                ""originCountyCode"": """ & _CodComunaOrigen & """,
                                ""destinationCountyCode"": """ & _CodComunaDestino & """,
                                ""package"": {
                                    ""weight"": """ & _PesoKg & """,
                                    ""height"": """ & _AltoCm & """,
                                    ""width"": """ & _AnchoCm & """,
                                    ""length"": """ & _LargoCm & """
                                },
                                ""productType"": " & _CodTipoProducto & ",
                                ""declaredWorth"": """ & _Valor & """,
                                ""deliveryTime"": " & _CodTipoEnvio & "
                                }"

        Dim _Respuesta As String = PostRequest(json, "/rating/api/v1.0/rates/courier", _Key_Cotizacion)
        Dim _Tbl As DataTable = Fx_TblFromJson(_Respuesta, "courierServiceOptions", True)
        Return _Tbl

        ''Consulta a api cotizaciones
        'Dim respuesta As String = PostRequest(json, "/rating/api/v1.0/rates/courier", _Key_Cotizacion)
        ''carga de cotizaciones en grilla cotizaciones
        'GridFromJson2(respuesta, "courierServiceOptions", Grilla_Cotizacion)

    End Function

    Function Fx_Guardar_Envio(New_Cl As Enti_Cotizacion) As Integer

        Dim JsonString As String = "
            {
    ""header"":  {
		""certificateNumber"": 0.0,
		""customerCardNumber"": """ & _TCC & """,
		""countyOfOriginCoverageCode"": """ & New_Cl.ComunaOrigen1 & """,
		""labelType"": 2,
		""marketplaceRut"": """ & _Rut_Mark & """,
		""sellerRut"": """ & _Rut_Seller & """
	},
	""details"": [
		{
			""addresses"": [
				{
					""addressId"": 0,
					""countyCoverageCode"": """ & New_Cl.ComunaDestino1 & """,
					""streetName"": """ & New_Cl.DireccionDestino1 & """,
					""streetNumber"": """ & New_Cl.NumeroDestino1 & """,
					""supplement"": """ & New_Cl.ComplementoDestino1 & """,
					""addressType"": ""DEST"",
					""deliveryOnCommercialOffice"": " & New_Cl.EntregaOficina1 & ",
                    ""commercialOfficeId"": """ & New_Cl.Id_oficina1 & """,
					""observation"": ""DEFAULT""
				},
				{
					""addressId"": 0,
					""countyCoverageCode"": """ & New_Cl.ComunaOrigen1 & """,
					""streetName"": """ & New_Cl.DireccionOrigen1 & """,
					""streetNumber"": """ & New_Cl.NumeroOrigen1 & """,
					""supplement"": """ & New_Cl.ComplementoOrigen1 & """,
					""addressType"": ""DEV"",
					""deliveryOnCommercialOffice"": false,
					""observation"": ""DEFAULT""
				}
			],
			""contacts"": [
				{
					""name"": """ & New_Cl.ContactoOrigen1 & """,
					""phoneNumber"": """ & New_Cl.TelefonoOrigen1 & """,
					""mail"": """ & New_Cl.CorreoOrigen1 & """,
					""contactType"": ""R""},
				{
					""name"": """ & New_Cl.ContactoDestino1 & """,
					""phoneNumber"": """ & New_Cl.TelefonoDestino1 & """,
					""mail"": """ & New_Cl.CorreoDestino1 & """,
					""contactType"": ""D""
				}
			],
			""packages"": [
				{
                    ""weight"": """ & New_Cl.Peso1 & """,
                    ""height"": """ & New_Cl.Alto1 & """,
                    ""width"": """ & New_Cl.Ancho1 & """,
                    ""length"": """ & New_Cl.Largo1 & """,
					""serviceDeliveryCode"": """ & New_Cl.IdServicio1 & """,
					""productCode"": """ & New_Cl.Producto1 & """,
					""deliveryReference"": """ & New_Cl.Referencia1 & """,
					""groupReference"": ""GRUPO"",
					""declaredValue"": """ & New_Cl.Valor1 & """,
					""declaredContent"": """ & New_Cl.Contenido1 & """,
					""extendedCoverageAreaIndicator"": false,
					""receivableAmountInDelivery"": 1000
				}
			]
		}
	]
}"

        JsonString = Replace(JsonString, "á", "a")
        JsonString = Replace(JsonString, "é", "e")
        JsonString = Replace(JsonString, "í", "i")
        JsonString = Replace(JsonString, "ó", "o")
        JsonString = Replace(JsonString, "ú", "u")

        JsonString = Replace(JsonString, "Á", "A")
        JsonString = Replace(JsonString, "É", "E")
        JsonString = Replace(JsonString, "Í", "I")
        JsonString = Replace(JsonString, "Ó", "O")
        JsonString = Replace(JsonString, "Ú", "U")

        JsonString = Replace(JsonString, "ñ", "n")
        JsonString = Replace(JsonString, "Ñ", "N")

        Dim Consulta As String = "Insert Into " & _Global_BaseBk & "Zw_Chilexpress_Env 
           ([Regionorigen]
           ,[Comunaorigen]
           ,[Direccionorigen]
           ,[Numorigen]
           ,[Comporigen]
           ,[Nombreorigen]
           ,[Telorigen]
           ,[Mailorigen]
           ,[Referencia]
           ,[Peso]
           ,[Alto]
           ,[Largo]
           ,[Ancho]
           ,[Nombredestino]
           ,[Telefonodestino]
           ,[Maildestino]
           ,[Producto]
           ,[Valor]
           ,[Regiondestino]
           ,[Comunadestino]
           ,[Direcciondestino]
           ,[Numerodestino]
           ,[Compdestino]
           ,[Idoficina]
           ,[Idservicio]
           ,[Tipoenvio]
           ,[Costoenvio]
           ,[Json]
           ,[Estatusenvio]
           ,[Contenido]
           )
     VALUES
           ('" & New_Cl.RegionOrigen1 & "'
           ,'" & New_Cl.ComunaOrigen1 & "'
           ,'" & New_Cl.DireccionOrigen1 & "'
           ,'" & New_Cl.NumeroOrigen1 & "'
           ,'" & New_Cl.ComplementoOrigen1 & "'
           ,'" & New_Cl.ContactoOrigen1 & "'
           ,'" & New_Cl.TelefonoOrigen1 & "'
           ,'" & New_Cl.CorreoOrigen1 & "'
           ,'" & New_Cl.Referencia1 & "'
           ,'" & New_Cl.Peso1 & "'
           ,'" & New_Cl.Alto1 & "'
           ,'" & New_Cl.Largo1 & "'
           ,'" & New_Cl.Ancho1 & "'
           ,'" & New_Cl.ContactoDestino1 & "'
           ,'" & New_Cl.TelefonoDestino1 & "'
           ,'" & New_Cl.CorreoDestino1 & "'
           ,'" & New_Cl.Producto1 & "'
           ,'" & New_Cl.Valor1 & "'
           ,'" & New_Cl.RegionDestino1 & "'
           ,'" & New_Cl.ComunaDestino1 & "'
           ,'" & New_Cl.DireccionDestino1 & "'
           ,'" & New_Cl.NumeroDestino1 & "'
           ,'" & New_Cl.ComplementoDestino1 & "'
           ,'" & New_Cl.Id_oficina1 & "'
           ,'" & New_Cl.IdServicio1 & "'
           ,'" & New_Cl.TipoServicio1 & "'
           ,'" & New_Cl.CostoServicio1 & "'
           ,'" & JsonString & "'
           ,'EN REVISION'
           ,'" & New_Cl.Contenido1 & "');"

        Dim _Idenvio As Integer

        If Not _Sql.Ej_Insertar_Trae_Identity(Consulta, _Idenvio, False) Then
            _errors = _Sql.Pro_Error
        End If

        Return _Idenvio

    End Function

    Function Fx_Realizar_Envio(IdEnvio As String, json As String) As Boolean

        Dim _Etiqueta As String
        Dim _Nro_Encomienda As String
        Dim _Codigo_Barras As String
        Dim _Request As String

        json = Replace(json, "á", "a")
        json = Replace(json, "é", "e")
        json = Replace(json, "í", "i")
        json = Replace(json, "ó", "o")
        json = Replace(json, "ú", "u")

        json = Replace(json, "Á", "A")
        json = Replace(json, "É", "E")
        json = Replace(json, "Í", "I")
        json = Replace(json, "Ó", "O")
        json = Replace(json, "Ú", "U")

        json = Replace(json, "ñ", "n")
        json = Replace(json, "Ñ", "N")

        _Request = PostRequest(json, "/transport-orders/api/v1.0/transport-orders", _Key_Envio)

        If IsNothing(_Request) Then
            _errors = "No se recibe respuesta desde el sito de Chilexpress"
            Return False
        End If

        Dim _Result As Object = JsonConvert.DeserializeObject(Of Object)(_Request)

        _Etiqueta = _Result("data")("detail")(0)("label")("labelData")
        _Nro_Encomienda = _Result("data")("detail")(0)("transportOrderNumber").ToString
        _Codigo_Barras = _Result("data")("detail")(0)("barcode")

        _Nro_Encomienda = Mid(_Codigo_Barras, 11, 13)

        Dim _statusCode As String = _Result("statusCode")
        Dim _statusDescription As String = _Result("statusDescription")

        Dim _statusCode2 As String = _Result("data")("detail")(0)("statusCode")
        Dim _statusDescription2 As String = _Result("data")("detail")(0)("statusDescription")

        If _statusCode <> 0 Then
            _errors = _statusDescription & vbCrLf & _statusDescription2
            Return False
        End If

        Dim _transportOrderNumber As String = _Result("data")("detail")(0)("transportOrderNumber")
        Dim _reference As String = _Result("data")("detail")(0)("reference")
        Dim _productDescription As String = _Result("data")("detail")(0)("productDescription")
        Dim _serviceDescription As String = _Result("data")("detail")(0)("serviceDescription")
        Dim _genericString1 As String = _Result("data")("detail")(0)("genericString1")
        Dim _genericString2 As String = _Result("data")("detail")(0)("genericString2")
        Dim _deliveryTypeCode As String = _Result("data")("detail")(0)("deliveryTypeCode")
        Dim _destinationCoverageAreaName As String = _Result("data")("detail")(0)("destinationCoverageAreaName")
        Dim _additionalProductDescription As String = _Result("data")("detail")(0)("additionalProductDescription")
        Dim _barcode As String = _Result("data")("detail")(0)("barcode")
        Dim _classificationData As String = _Result("data")("detail")(0)("classificationData")

        Dim _printedDate As DateTime = NuloPorNro(_Result("data")("detail")(0)("printedDate"), Nothing)

        Dim _labelVersion As String = _Result("data")("detail")(0)("labelVersion")
        Dim _distributionDescription As String = _Result("data")("detail")(0)("distributionDescription")
        Dim _companyName As String = _Result("data")("detail")(0)("companyName")
        Dim _recipient As String = _Result("data")("detail")(0)("recipient")
        Dim _address As String = _Result("data")("detail")(0)("address")
        Dim _groupReference As String = _Result("data")("detail")(0)("groupReference")
        Dim _createdDate As DateTime = _Result("data")("detail")(0)("createdDate")

        Dim Consulta As String = "Update " & _Global_BaseBk & "Zw_Chilexpress_Env " &
                                 "Set " &
                                 "Json='" & json & "'," &
                                 "Respuesta='" & _Request & "'," &
                                 "Etiqueta='" & _Etiqueta & "'," &
                                 "Nro_Encomienda='" & _Nro_Encomienda & "'," &
                                 "Codigo_Barras='" & _Codigo_Barras & "'," &
                                 "Estatusenvio='ENVIADO'" & vbCrLf &
                                 "Where Idenvio='" & IdEnvio & "'" &
                                 vbCrLf &
                                 vbCrLf &
                                 "Insert Into " & _Global_BaseBk & "Zw_Chilexpress_Res (Idenvio,transportOrderNumber,reference,productDescription,serviceDescription,genericString1," &
                                 "genericString2,deliveryTypeCode,destinationCoverageAreaName,additionalProductDescription,barcode,classificationData,printedDate," &
                                 "labelVersion, distributionDescription, companyName,recipient,address,groupReference,createdDate) Values " &
                                 "(" & IdEnvio & ",'" & _transportOrderNumber & "','" & _reference & "','" & _productDescription & "','" & _serviceDescription &
                                 "','" & _genericString1 & "','" & _genericString2 & "','" & _deliveryTypeCode & "','" & _destinationCoverageAreaName &
                                 "','" & _additionalProductDescription & "','" & _barcode & "','" & _classificationData &
                                 "','" & Format(_printedDate, "yyyyMMdd") & "'," &
                                 "'" & _labelVersion & "','" & _distributionDescription & "','" & _companyName & "','" & _recipient & "','" & _address &
                                 "','" & _groupReference & "',Getdate())"

        If Not _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta) Then
            _errors = _Sql.Pro_Error
            Return False
        End If

        Return True

    End Function

    Function Fx_Generar_Etiqueta(Etiqueta As String) As Image
        Dim Imagen As Image
        'Dim result As Object = JsonConvert.DeserializeObject(Of Object)(Respuesta)
        'Dim Etiqueta As String = result("data")("detail")(0)("label")("labelData")
        Dim bytes As Byte() = Convert.FromBase64String(Etiqueta)
        Using ms As MemoryStream = New MemoryStream(bytes)
            Imagen = Image.FromStream(ms)
        End Using
        Return Imagen
    End Function

    Public Sub SaveImage(filename As String, image As Image)
        'metodo que convierte la imagen de picturebox a imagen de jpg
        Dim dest As New Bitmap(image.Width, image.Height)
        Dim gfx As Graphics = Graphics.FromImage(dest)
        gfx.DrawImageUnscaled(image, Point.Empty)
        gfx.Dispose()
        dest.Save(filename, System.Drawing.Imaging.ImageFormat.Jpeg)
        dest.Dispose()
    End Sub

    Public Sub CrearPDF(Etiqueta As Image)

        'crearpdf
        Dim pdf As PdfDocument = New PdfDocument
        Dim pdfPage As PdfPage = pdf.AddPage
        'Tamano de Archivo PDF
        pdfPage.Width = 792 '792 x 612
        pdfPage.Height = 612

        'Convertir imagen desde picturebox para no guardarla. Este metodo tambien aplica para la imagen almacenada como variable
        Dim Imagen As New MemoryStream
        Dim dest As New Bitmap(Etiqueta.Width, Etiqueta.Height)

        dest = New Bitmap(Etiqueta)

        Dim gfx As Graphics = Graphics.FromImage(dest)
        gfx.DrawImageUnscaled(Etiqueta, Point.Empty)
        gfx.Dispose()
        dest.Save(Imagen, System.Drawing.Imaging.ImageFormat.Jpeg)
        'Mandar imagen a archivo pdf
        Dim graph As XGraphics = XGraphics.FromPdfPage(pdfPage)
        Dim img As XImage = dest ' XImage.FromStream(Imagen)
        graph.DrawImage(img, 10, 10, 300, 150)
        dest.Dispose()
        'Guardar PDF
        Dim Ventana As New SaveFileDialog

        Ventana.Filter = "Etiquetas PDF (*.pdf)|*.pdf"
        Ventana.RestoreDirectory = True
        Ventana.FileName = ("Etiqueta.pdf")

        If Ventana.ShowDialog() = DialogResult.OK Then
            pdf.Save(Ventana.FileName)
            Process.Start(Ventana.FileName)
        End If

    End Sub
    '- Crear tabla que guarde los datos de una cotizacion a punto de ser enviada a Chilexpress
    '- Los nombre de los campos deben ser los mismo que los campos que contiene un pedido a chilexpress,
    '  se diferenciaran los tipo Origen y Destino por las siguientes siglas _Ori y _Des, ejemplo (addressId_Ori - addressId_Des)
    Public Function Fx_CrearPDF(_Etiqueta As Image) As Boolean

        'crearpdf
        Dim pdf As PdfDocument = New PdfDocument
        Dim pdfPage As PdfPage = pdf.AddPage
        'Tamano de Archivo PDF
        pdfPage.Width = 612  '792 x 612
        pdfPage.Height = 792

        'Convertir imagen desde picturebox para no guardarla. Este metodo tambien aplica para la imagen almacenada como variable
        Dim Imagen As New MemoryStream
        Dim dest As New Bitmap(_Etiqueta.Width, _Etiqueta.Height)

        dest = New Bitmap(_Etiqueta)

        Dim gfx As Graphics = Graphics.FromImage(dest)
        gfx.DrawImageUnscaled(_Etiqueta, Point.Empty)
        gfx.Dispose()
        dest.Save(Imagen, System.Drawing.Imaging.ImageFormat.Jpeg)
        'Mandar imagen a archivo pdf
        Dim graph As XGraphics = XGraphics.FromPdfPage(pdfPage)
        Dim img As XImage = dest ' XImage.FromStream(Imagen)
        graph.DrawImage(img, 10, 10, 300, 150)
        dest.Dispose()
        'Guardar PDF

        _Nombre_Etiqueta = "ETQ_Chilexpress.pdf"
        '_Ruta_Etiqueta = _Ruta_Etiqueta & "\" & _Nombre_Etiqueta
        Dim _Archivo = _Ruta_Etiqueta & "\" & _Nombre_Etiqueta
        If File.Exists(_Archivo) Then File.Delete(_Archivo)

        pdf.Save(_Archivo)

        If File.Exists(_Archivo) Then
            Return True
        Else
            _Nombre_Etiqueta = String.Empty
            Return False
        End If

    End Function

    Function Fx_Generar_Envio_Desde_IdDespacho(_IdDespacho As Integer) As Boolean

        Consulta_sql = "Select Idenvio,Json From " & _Global_BaseBk & "Zw_Chilexpress_Env Where IdDespacho = " & _IdDespacho
        Dim _Row_Cotizacion As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        'Dim IdEnvio = GrillaEnvios.CurrentRow().Cells("IDENVIO").Value.ToString().Trim
        Dim _Idenvio = _Row_Cotizacion.Item("Idenvio") 'GrillaEnvios.CurrentRow().Cells("IDENVIO").Value.ToString().Trim
        Dim _JsonString = _Row_Cotizacion.Item("Json") 'GrillaEnvios.CurrentRow().Cells("JSON").Value.ToString().Trim

        'Dim Respuesta() As String = Cl_Chilexpress.Fx_Realizar_Envio(IdEnvio, JsonString)
        '_Idenvio = Cl_Chilexpress.Fx_Realizar_Envio(IdEnvio, JsonString)

        If Not Fx_Realizar_Envio(_Idenvio, _JsonString) Then
            'MessageBoxEx.Show(Me, "El envio fue generado correctamente", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information)
            'Else
            Return False
            'MessageBoxEx.Show(Me, Cl_Chilexpress.Errors, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        'LlenarGrillaEnvios()
        'Cl_Chilexpress.CrearPDF(Cl_Chilexpress.Fx_Generar_Etiqueta(Respuesta(1)))
        Return True
    End Function

    Function Fx_Trae_Row_Envio(_Idenvio As Integer, _IdDespacho As Integer) As DataRow

        If CBool(_Idenvio) Then
            Consulta_sql = "Select Top 1 * From " & _Global_BaseBk & "Zw_Chilexpress_Env Where Idenvio = " & _Idenvio
        Else
            Consulta_sql = "Select Top 1 * From " & _Global_BaseBk & "Zw_Chilexpress_Env" & vbCrLf &
                           "Where IdDespacho In (Select Id_Despacho_Padre From " & _Global_BaseBk & "Zw_Despachos Where Id_Despacho = " & _IdDespacho & ")"
        End If

        Dim _Row As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)
        Return _Row

    End Function

    Function Fx_Trae_Row_Respuesta(_Idenvio As Integer) As DataRow

        Consulta_sql = "Select Top 1 * From " & _Global_BaseBk & "Zw_Chilexpress_Res Where Idenvio = " & _Idenvio
        Dim _Row As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)
        Return _Row

    End Function

#Region "IMPRIMIR DOCUMENTO"

    Public Function Fx_Imprimir_Archivo(_Formulario As Form, _Impresora As String, _IdDespacho As Integer)

        Try

            ' ejemplo simple para imprimir en .NET
            ' Usamos una clase del tipo PrintDocument

            _Row_Envio = Fx_Trae_Row_Envio(0, _IdDespacho)

            Dim printDoc As New PrintDocument

            ' CON ESTA CONFIGURACION PODEMOS PROPORCIONAR LAS DIMENCIONES Y ESTADO DE LA PAGINA, MARGENES, LARGO Y HORIENTACION

            Dim pkCustomSize1 As New Printing.PaperSize(PaperKind.Letter, 850, 1100)

            Dim PageSetupDialog1 As New PageSetupDialog

            PageSetupDialog1.Document = printDoc
            PageSetupDialog1.PageSettings.Landscape = False

            PageSetupDialog1.PageSettings.PaperSize = pkCustomSize1
            PageSetupDialog1.PageSettings.Margins.Left = 2
            PageSetupDialog1.PageSettings.Margins.Right = 2

            PageSetupDialog1.ShowDialog()

            'Dim PageSetupDialog1 As New PageSetupDialog

            'PageSetupDialog1.Document = printDoc
            'PageSetupDialog1.PageSettings.Landscape = False
            'PageSetupDialog1.PageSettings.PaperSize = pkCustomSize1

            ' asignamos el método de evento para cada página a imprimir

            AddHandler printDoc.PrintPage, AddressOf Sb_Print_PrintPage_Etiqueta

            ' indicamos que queremos imprimir

            printDoc.DocumentName = "Etiqueta Chilexpress"

            If String.IsNullOrEmpty(_Impresora) Then

                Dim prtDialog As New PrintDialog

                If _PrtSettings Is Nothing Then
                    _PrtSettings = New PrinterSettings
                End If

                With prtDialog

                    .AllowPrintToFile = False
                    .AllowSelection = False
                    .AllowSomePages = False
                    .PrintToFile = False
                    .ShowHelp = False
                    .ShowNetwork = True

                    .PrinterSettings = _PrtSettings

                    If .ShowDialog(_Formulario) = DialogResult.OK Then
                        _Impresora = .PrinterSettings.PrinterName
                    Else
                        Return False
                    End If

                End With

            End If

            printDoc.PrinterSettings.PrinterName = _Impresora
            printDoc.Print()

            Return True

        Catch ex As Exception
            Return False
            MsgBox(ex.Message)
        End Try

    End Function

    Private Sub Sb_Print_PrintPage_Etiqueta(ByVal sender As Object, ByVal e As PrintPageEventArgs)

        Try

            ' imprimimos la cadena en el margen izquierdo
            Dim _xPos As Single = 3 'e.MarginBounds.Left
            ' La fuente a usar

            ' la posición superior
            Dim _yPos As Single = prFont.GetHeight(e.Graphics) - 10

            _xPos = 20
            _yPos = 20

            Dim _Font_Enc_1 As Font = Fx_Fuente(_Enum_Fuentes.Times_New_Roman, 14, FontStyle.Bold)
            Dim _Font_Enc_2 As Font = Fx_Fuente(_Enum_Fuentes.Times_New_Roman, 12, FontStyle.Regular)
            Dim _Font_Enc_3 As Font = Fx_Fuente(_Enum_Fuentes.Times_New_Roman, 10, FontStyle.Regular)
            Dim _Font_Enc_4 As Font = Fx_Fuente(_Enum_Fuentes.Times_New_Roman, 8, FontStyle.Regular)

            Dim _Font_C6 As Font = Fx_Fuente(_Enum_Fuentes.Courier_New, 6, FontStyle.Regular)
            Dim _Font_C8 As Font = Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Regular)
            Dim _Font_C9 As Font = Fx_Fuente(_Enum_Fuentes.Courier_New, 9, FontStyle.Regular)
            Dim _Font_C10 As Font = Fx_Fuente(_Enum_Fuentes.Courier_New, 10, FontStyle.Regular)
            Dim _Font_C12 As Font = Fx_Fuente(_Enum_Fuentes.Courier_New, 12, FontStyle.Regular)

            Dim _Font_Detalle_1 As Font = Fx_Fuente(_Enum_Fuentes.Times_New_Roman, 6, FontStyle.Regular)
            Dim _Font_Detalle_2 As Font = Fx_Fuente(_Enum_Fuentes.Times_New_Roman, 8, FontStyle.Regular)
            Dim _Font_Detalle_3 As Font = Fx_Fuente(_Enum_Fuentes.Arial, 8, FontStyle.Regular)

            Dim _Font_Detalle_Curr_1_R As Font = Fx_Fuente(_Enum_Fuentes.Courier_New, 6, FontStyle.Regular)
            Dim _Font_Detalle_Curr_2_R As Font = Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Regular)

            Dim _Font_Detalle_Curr_1_B As Font = Fx_Fuente(_Enum_Fuentes.Courier_New, 6, FontStyle.Bold)
            Dim _Font_Detalle_Curr_2_B As Font = Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Bold)

            Dim _Etiqueta As String = _Row_Envio.Item("Etiqueta")
            Dim _Etiqueta_Img As Image = Fx_Generar_Etiqueta(_Etiqueta)

            Dim _Ancho = 396 'Math.Round(792 / 2, 0) '792 x 612
            Dim _Alto = 246 'Math.Round(612 / 2, 0)

            e.Graphics.DrawImage(_Etiqueta_Img, _xPos, _yPos, _Ancho, _Alto)

            e.HasMorePages = False

        Catch ex As Exception
            My.Computer.FileSystem.WriteAllText("Log_Errores.log", ex.Message & vbCrLf & ex.StackTrace, False)
            MsgBox(ex.Message)
            MsgBox("Error lo puesde ver en archivo Log de errores")
        End Try

    End Sub

#End Region


End Class
