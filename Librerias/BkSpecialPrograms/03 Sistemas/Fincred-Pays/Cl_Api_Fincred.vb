Imports System.Net
Imports BkSpecialPrograms.Cl_APIs
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Namespace Cl_APIs

    Public Class Cl_Api_Fincred

        Public Property TramaRespuesta As Cl_APIs.TramaRespuesta
        Public Property JsonRespuesta As String
        Public Property JsonDocumentos As String

        Function ConsultarDatos(_json As String) As Respuesta

            Dim _Respuesta As New Respuesta

            JsonRespuesta = String.Empty
            TramaRespuesta = New Cl_APIs.TramaRespuesta

            Try

                Dim _address = ObtenerAddress()
                Dim _requestUrl As String = ObtenerRequestUrl()
                Using _webClient As WebClient = New WebClient()
                    ServicePointManager.SecurityProtocol = CType(3072, SecurityProtocolType)
                    _webClient.BaseAddress = _address
                    'Return _webClient.DownloadString(_requestUrl + _json)
                    JsonRespuesta = _webClient.DownloadString(_requestUrl + _json)
                End Using

                TramaRespuesta = JsonConvert.DeserializeObject(Of Cl_APIs.TramaRespuesta)(JsonRespuesta)

                Dim _TramaRespuesta As JObject = JsonConvert.DeserializeObject(Of Object)(JsonRespuesta)
                JsonDocumentos = _TramaRespuesta.GetValue("documentos").ToString()


                Select Case TramaRespuesta.estado_transaccion
                    Case 0
                        _Respuesta.EsCorrecto = False
                    Case 1
                        _Respuesta.EsCorrecto = True
                    Case 2
                        _Respuesta.EsCorrecto = False
                End Select

                If IsNothing(TramaRespuesta.documentos) Then
                    _Respuesta.EsCorrecto = False
                Else
                    If TramaRespuesta.documentos(0).autorizacion = "RECHAZADO" Then
                        _Respuesta.EsCorrecto = False
                    Else
                        _Respuesta.EsCorrecto = True
                    End If
                End If

                If Not _Respuesta.EsCorrecto Then
                    _Respuesta.MensajeError = TramaRespuesta.descripcion_negacion
                End If

                _Respuesta.TramaRespuesta = TramaRespuesta

            Catch ex As Exception
                _Respuesta.EsCorrecto = False
                _Respuesta.MensajeError = ex.Message
            End Try

            Return _Respuesta

        End Function

        'Function ObtenerToken() As String
        '    Dim token As String = "FCcbee66b69882652d8a2b662c983e4fa2P"
        '    Return token
        'End Function

        Function ObtenerAddress() As String
            Dim token As String = "https://api.fincred.cl/"
            Return token
        End Function
        Function ObtenerRequestUrl() As String
            Dim token As String = "Fincred?payload="
            Return token
        End Function

        Function CrearJsonConsulta(_trama As Trama) As String
            Dim _json As String
            _json = "{""trama"":""" & _trama.trama & """,
""token"":""" & _trama.token & """,
""usuario"":""" & _trama.usuario & """,
""clave"":""" & _trama.clave & """,
""producto"":" & _trama.producto & ",
""origen_transaccion"":" & _trama.origen_transaccion & ",
""rut_girador"":""" & _trama.rut_girador & """,
""rut_comprador"":""" & _trama.rut_comprador & """,
""numero_transaccion_cliente"":""" & _trama.numero_transaccion_cliente & """,
""numero_documento_transaccion"":""" & _trama.numero_documento_transaccion & """,
""banco"":" & _trama.banco & ",
""monto_total_venta"":" & _trama.monto_total_venta & ",
""cantidad_documentos_venta"":" & _trama.cantidad_documentos_venta & ",
""num_primer_doc"":" & _trama.num_primer_doc & ",
""fec_primer_venc"":""" & _trama.fec_primer_venc & """,
""num_telefono"":""" & _trama.num_telefono & """
}"
            Return _json
        End Function

        Function CrearListaDocumento(_json As String) As List(Of documentos)

            TramaRespuesta = JsonConvert.DeserializeObject(Of Cl_APIs.TramaRespuesta)(_json)

            Dim _TramaRespuesta As JObject = JsonConvert.DeserializeObject(Of Object)(_json)

            Dim _documentos As String = _TramaRespuesta.GetValue("documentos").ToString()
            Dim _Lista = TramaRespuesta.documentos ' JsonConvert.DeserializeObject(Of List(Of documentos))(_documentos)
            Return _Lista

        End Function


    End Class

    Public Class Trama
        Public Property trama As String
        Public Property token As String
        Public Property usuario As String
        Public Property clave As String
        Public Property producto As Integer
        Public Property origen_transaccion As Integer
        Public Property rut_girador As String
        Public Property rut_comprador As String
        Public Property numero_transaccion_cliente As String
        Public Property numero_documento_transaccion As String
        Public Property banco As Integer
        Public Property monto_total_venta As Integer
        Public Property cantidad_documentos_venta As Integer
        Public Property num_primer_doc As Integer
        Public Property fec_primer_venc As String
        Public Property num_telefono As String
    End Class

    Public Class TramaRespuesta
        Public Property trama As String
        Public Property token As String
        Public Property usuario As String
        Public Property clave As String
        Public Property producto As Integer
        Public Property origen_transaccion As Integer
        Public Property rut_girador As String
        Public Property rut_comprador As String
        Public Property numero_transaccion_cliente As Integer
        Public Property numero_documento_transaccion As String
        Public Property banco As Integer
        Public Property monto_total_venta As Integer
        Public Property cantidad_documentos_venta As Integer
        Public Property estado_transaccion As Integer
        Public Property codigo_negacion_transaccion As Integer
        Public Property descripcion_negacion As String
        Public Property documentos As List(Of Cl_APIs.documentos)

    End Class

    Public Class documentos
        Public Property nro_documento As Integer
        Public Property monto_documento As Integer
        Public Property fecha_vencimiento As String
        Public Property autorizacion As String
    End Class

    Public Class Respuesta
        Public Property EsCorrecto As Boolean
        Public Property MensajeError As String
        Public Property TramaRespuesta As TramaRespuesta

    End Class

End Namespace

Namespace Cl_Fincred_Bakapp

    Public Class Cl_Fincred_SQL

        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
        Dim Consulta_sql As String

        Public Property Fincred_Config As New Fincred_Config
        Public Property Respuesta As Respuesta

        Enum Producto
            Cheques
            Facturas
            Pagares
        End Enum

        'Dim _Producto As Producto

        Public Sub New(_Id_Config As Integer)

            Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Fincred_Config Where Id = " & _Id_Config
            Dim _Row_Fincred_Config As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

            If Not IsNothing(_Row_Fincred_Config) Then

                Fincred_Config = New Fincred_Config
                Fincred_Config.Id = _Row_Fincred_Config.Item("Id")
                Fincred_Config.Token = _Row_Fincred_Config.Item("Token")
                Fincred_Config.Usuario = _Row_Fincred_Config.Item("Usuario")
                Fincred_Config.Clave = _Row_Fincred_Config.Item("Clave")
                Fincred_Config.NombreSucursal = _Row_Fincred_Config.Item("NombreSucursal")
                Fincred_Config.AmbientePruebas = _Row_Fincred_Config.Item("AmbientePruebas")

            End If

        End Sub

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="_Rut_girador"></param>
        ''' <param name="_Rut_comprador"></param>
        ''' <param name="_Numero_transaccion_cliente"></param>
        ''' <param name="_Numero_documento_transaccion"></param>
        ''' <param name="_Producto"></param>
        ''' <param name="_Banco"></param>
        ''' <param name="_Monto_total_venta"></param>
        ''' <param name="_Cantidad_documentos_venta"></param>
        ''' <param name="_Num_primer_doc"></param>
        ''' <param name="_Fec_primer_venc">Se debe enviar la fecha de vencimiento del primer cheque en caso del producto cheque, fecha de vencimiento de factura en caso de producto (Formato DDMMAAAA)</param>
        ''' <param name="_Num_telefono"></param>
        ''' <returns></returns>
        Function Fx_Generar_Consulta(_Rut_girador As String,
                                     _Rut_comprador As String,
                                     _Numero_transaccion_cliente As Integer,
                                     _Numero_documento_transaccion As String,
                                     _Producto As Producto,
                                     _Banco As Integer,
                                     _Monto_total_venta As Double,
                                     _Cantidad_documentos_venta As Integer,
                                     _Num_primer_doc As Integer,
                                     _Fec_primer_venc As String,
                                     _Num_telefono As String) As Boolean

            Respuesta = Nothing

            Dim _Cl_API_Fincred As New Cl_APIs.Cl_Api_Fincred

            'Dim _token As String = String.Empty ' "FCcbee66b69882652d8a2b662c983e4fa2P"

            Dim _trama As New Trama

            _trama.trama = "pays"
            _trama.token = Fincred_Config.Token
            _trama.usuario = Fincred_Config.Usuario
            _trama.clave = Fincred_Config.Clave
            _trama.producto = _Producto
            _trama.origen_transaccion = 2
            _trama.rut_girador = _Rut_girador
            _trama.rut_comprador = _Rut_comprador
            _trama.numero_transaccion_cliente = _Numero_transaccion_cliente
            _trama.numero_documento_transaccion = _Numero_documento_transaccion
            _trama.banco = _Banco
            _trama.monto_total_venta = _Monto_total_venta
            _trama.cantidad_documentos_venta = _Cantidad_documentos_venta
            _trama.num_primer_doc = _Num_primer_doc
            _trama.fec_primer_venc = _Fec_primer_venc
            _trama.num_telefono = _Num_telefono

            Dim _json As String = _Cl_API_Fincred.CrearJsonConsulta(_trama)
            Dim _Respuesta As Respuesta = _Cl_API_Fincred.ConsultarDatos(_json)

            Respuesta = _Respuesta

            Return True

        End Function

    End Class

    Public Class Fincred_Config
        Public Property Id As Integer
        Public Property Token As String
        Public Property Usuario As String
        Public Property Clave As String
        Public Property NombreSucursal As String
        Public Property AmbientePruebas As Boolean

    End Class

End Namespace





