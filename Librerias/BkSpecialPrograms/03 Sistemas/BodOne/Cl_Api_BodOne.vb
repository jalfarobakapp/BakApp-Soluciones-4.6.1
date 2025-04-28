Imports System.Net.Http
Imports System.Text
Imports Newtonsoft.Json

Public Class Cl_Api_BodOne
    Private ReadOnly _httpClient As HttpClient

    ''' <summary>
    ''' Inicializa el cliente HTTP
    ''' </summary>
    Public Sub New()
        _httpClient = New HttpClient()
    End Sub

    ''' <summary>
    ''' Método genérico para enviar solicitudes POST a una API
    ''' </summary>
    ''' <typeparam name="TResponse">Tipo de dato esperado en la respuesta</typeparam>
    ''' <param name="url">Dirección de la API</param>
    ''' <param name="requestBody">Diccionario con los datos que se enviarán en el cuerpo de la solicitud</param>
    ''' <param name="authorizationToken">Token de autorización para el encabezado</param>
    ''' <returns>Un objeto de tipo Mensajes con el resultado de la operación</returns>
    Public Function Post(Of TResponse)(url As String, requestBody As Dictionary(Of String, Object), authorizationToken As String) As LsValiciones.Mensajes
        Dim mensaje As New LsValiciones.Mensajes

        Try
            ' Configura el encabezado de autorización
            _httpClient.DefaultRequestHeaders.Clear()
            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Token {authorizationToken}")

            ' Serializa el cuerpo de la solicitud a JSON
            Dim jsonContent = JsonConvert.SerializeObject(requestBody)
            Dim content = New StringContent(jsonContent, Encoding.UTF8, "application/json")

            ' Envía la solicitud POST y obtiene la respuesta
            Dim response = _httpClient.PostAsync(url, content).Result

            ' Verifica que la respuesta sea exitosa
            response.EnsureSuccessStatusCode()

            ' Deserializa la respuesta al tipo especificado
            Dim jsonResponse = response.Content.ReadAsStringAsync().Result
            Dim resultado As TResponse = JsonConvert.DeserializeObject(Of TResponse)(jsonResponse)

            ' Configura el mensaje en caso de éxito
            mensaje.EsCorrecto = True
            mensaje.Resultado = resultado.ToString()
            mensaje.Detalle = "Operación completada con éxito."
            mensaje.Mensaje = "La solicitud a la API fue exitosa."
            mensaje.Icono = MessageBoxIcon.Information

        Catch ex As Exception
            ' Configura el mensaje en caso de error
            mensaje.EsCorrecto = False
            mensaje.Detalle = "Error en la solicitud a la API."
            mensaje.Mensaje = ex.Message
            mensaje.Icono = MessageBoxIcon.Error
        End Try

        Return mensaje
    End Function

End Class

