'Imports Lib_Bakapp_VarClassFunc
Imports DevComponents.DotNetBar
Imports System.Web
Imports System.Net
Imports System.IO
Imports System.Text
Imports Newtonsoft.Json
Imports System.Xml.Linq
Imports System.Xml
Imports System.Object
Imports System.Web.Script.Serialization

Public Class Clas_Chasdro

    Dim _Ip_CashDro As String
    Dim _Name As String
    Dim _Password As String

    Dim _posid As String = _Global_Row_EstacionBk.Item("NombreEquipo")
    Dim _posuser As String = FUNCIONARIO
    Dim _Respuesta As String

    Dim _Consulta_CashDro As String
    Dim _operationId As Integer

    Dim _Code As Integer
    Dim _Data As String
    Dim _Code_Respuesta As Boolean

    Dim _State As String
    Dim _WithError As Boolean

    Dim _Total As Double
    Dim _Total_In As Double
    Dim _Total_Out As Double
    Dim _Amountchangenotavailable As Double

    Public Property Pro_OperationId() As Integer
        Get
            Return _operationId
        End Get
        Set(ByVal value As Integer)
            _operationId = value

            If _operationId = 0 Then
                _WithError = False
                _State = String.Empty
                _Total = 0
                _Total_In = 0
                _Total_Out = 0
                _Amountchangenotavailable = 0
                _Code = 0
                _Data = String.Empty
                _Respuesta = String.Empty
            End If

        End Set
    End Property

    Public ReadOnly Property Pro_Respuesta() As String
        Get
            Return _Respuesta
        End Get
    End Property
    Public ReadOnly Property Pro_Total() As Double
        Get
            Return _Total / 100
        End Get
    End Property
    Public ReadOnly Property Pro_Total_In() As Double
        Get
            Return _Total_In / 100
        End Get
    End Property
    Public ReadOnly Property Pro_Total_Out() As Double
        Get
            Dim _Valor = _Total_Out / 100
            Return _Valor
        End Get
    End Property
    Public ReadOnly Property Pro_Amountchangenotavailable() As Double
        Get
            Return _Amountchangenotavailable / 100
        End Get
    End Property
    Public ReadOnly Property Pro_State() As String
        Get
            Return _State
        End Get
    End Property
    Public ReadOnly Property Pro_WithError() As Boolean
        Get
            Return _WithError
        End Get
    End Property
    Public ReadOnly Property Pro_Code() As Integer
        Get
            Return _Code
        End Get
    End Property
    Public ReadOnly Property Pro_Data() As String
        Get
            Return _Data
        End Get
    End Property
    Public ReadOnly Property Pro_Code_Respuesta() As Boolean
        Get
            Return _Code_Respuesta
        End Get
    End Property

    Public Sub New(ByVal Ip_CashDro As String, _
                   ByVal Usuario As String, _
                   ByVal Contrasena As String)

        _Ip_CashDro = Ip_CashDro
        _Name = Usuario
        _Password = Contrasena

    End Sub

    Function Fx_Comprobar_Conexion_CashDro() As Boolean

        _Consulta_CashDro = "https://" & _Ip_CashDro & "/Cashdro3WS/index.php?operation=doTest&" & _
                            "name=" & _Name & "&password=" & _Password

        _Respuesta = Fx_Conectar_CashDro(_Consulta_CashDro)
        Dim _Conectado As Boolean

        If Not _WithError Then

            Dim _Json = Fx_Datos_Json(_Respuesta) 'Split(_Respuesta, ":", 2)
            Dim _Code = Split(_Json(0), ":")

            Try
                _Conectado = CBool(_Code(1))
            Catch ex As Exception
                _Conectado = False
            End Try

        End If

        Return _Conectado

        '{"code":1,"data":""}
        '{"code":-1,"data":"Authentication Failed("}")

    End Function

    Function Fx_Conectar_CashDro(ByVal _Uri As String)

        Try

            System.Net.ServicePointManager.Expect100Continue = False
            System.Net.ServicePointManager.ServerCertificateValidationCallback = _
            New System.Net.Security.RemoteCertificateValidationCallback(AddressOf ValidarCertificado)


            ' Create a request for the URL. 
            Dim request As WebRequest = _
              WebRequest.Create(_Uri)
            ' If required by the server, set the credentials.
            request.Credentials = CredentialCache.DefaultCredentials
            ' Get the response.
            Dim response As WebResponse = request.GetResponse()
            ' Display the status.
            Console.WriteLine(CType(response, HttpWebResponse).StatusDescription)
            ' Get the stream containing content returned by the server.
            Dim dataStream As Stream = response.GetResponseStream()
            ' Open the stream using a StreamReader for easy access.
            Dim reader As New StreamReader(dataStream)
            ' Read the content.
            Dim responseFromServer As String = reader.ReadToEnd()
            ' Display the content.
            Console.WriteLine(responseFromServer)

            ' Clean up the streams and the response.
            reader.Close()
            response.Close()

            Return Trim(responseFromServer)

        Catch ex As Exception
            _WithError = True
            Return ex.Message & vbCrLf & "Ip Servidor: " & _Ip_CashDro '"Sin Conexion"
        End Try

    End Function

    Private Function ValidarCertificado(ByVal sender As Object, ByVal certificate As System.Security.Cryptography.X509Certificates.X509Certificate, ByVal chain As System.Security.Cryptography.X509Certificates.X509Chain, ByVal sslPolicyErrors As System.Net.Security.SslPolicyErrors) As Boolean
        Return True
    End Function

    Function Fx_Datos_Json(ByVal _Respuesta As String) As String()

        Dim _Rs = Replace(_Respuesta, Chr(34), "")
        _Rs = Replace(_Rs, "\", "")
        _Rs = Replace(_Rs, "{", "")
        _Rs = Replace(_Rs, "}", "")
        _Rs = Replace(_Rs, vbCrLf, "")
        _Rs = Replace(_Rs, vbTab, "")

        Dim _Sep() = Split(_Rs, ",")

        Return _Sep

    End Function

    Function Sb_Peticion_Venta(ByVal _Monto As Double)

        ' EN MANUAL CASHDRO
        ' 2.2 Petición de operación
        ' 2.2.1 Venta

        'Dicha petición tiene la finalidad de informar al CashDro del tipo de operación que
        'deseamos realizar y de las características de la misma, para posteriormente poder
        'ejecutarla mediante la URL Ejecutar una operación descrita en el apartado 2.3.
        'Mientras no se ejecuten las peticiones enviadas al web service, estas se mantendrán en
        'cola con su respectivo numero de operación y pudiendo ser ejecutadas en el orden
        'deseado.

        If Fx_Comprobar_Conexion_CashDro() Then

            _Monto = _Monto * 100

            _Consulta_CashDro = "https://" & _Ip_CashDro & "/Cashdro3WS/index.php?operation=startOperation&" & _
                                "name=" & _Name & "&" & _
                                "password=" & _Password & "&type=4&" & _
                                "posid=" & _posid & "&" & _
                                "posuser=" & _posuser & "&" & _
                                "parameters={" & Chr(34) & "amount" & Chr(34) & ":" & Chr(34) & _Monto & Chr(34) & "}"

            _Respuesta = Fx_Conectar_CashDro(_Consulta_CashDro)

            Sb_Cargar_Respuesta_Casdro(_Respuesta, _Code, _Data)

            If _Code = 1 Then

                _operationId = _Data

                _Consulta_CashDro = "https://" & _Ip_CashDro & "/Cashdro3WS/index.php?operation=acknowledgeOperationId&" & _
                                    "name=" & _Name & "&password=" & _Password & "&operationId=" & _operationId

                _Respuesta = Fx_Conectar_CashDro(_Consulta_CashDro)

                Sb_Cargar_Respuesta_Casdro(_Respuesta, _Code, _Data)

            End If

        End If

    End Function

    Function Sb_Peticion_Pago(ByVal _Monto As Double)

        ' EN MANUAL CASHDRO
        ' 2.2 Petición de operación
        ' 2.2.2 Pago

        'Dicha petición tiene la finalidad de informar al CashDro del tipo de operación que
        'deseamos realizar y de las características de la misma, para posteriormente poder
        'ejecutarla mediante la URL Ejecutar una operación descrita en el apartado 2.3.
        'Mientras no se ejecuten las peticiones enviadas al web service, estas se mantendrán en
        'cola con su respectivo numero de operación y pudiendo ser ejecutadas en el orden
        'deseado.

        If Fx_Comprobar_Conexion_CashDro() Then

            _Monto = _Monto * 100

            _Consulta_CashDro = "https://" & _Ip_CashDro & "/Cashdro3WS/index.php?operation=startOperation&" & _
                                "name=" & _Name & "&" & _
                                "password=" & _Password & "&" & _
                                "type=3&" & _
                                "posid=" & _posid & "&" & _
                                "posuser=" & _posuser & "&" & _
                                "parameters={" & Chr(34) & "amount" & Chr(34) & ":" & Chr(34) & _Monto & Chr(34) & "}"


            _Respuesta = Fx_Conectar_CashDro(_Consulta_CashDro)

            Sb_Cargar_Respuesta_Casdro(_Respuesta, _Code, _Data)

            If _Code = 1 Then

                _operationId = _Data

                _Consulta_CashDro = "https://" & _Ip_CashDro & "/Cashdro3WS/index.php?operation=acknowledgeOperationId&" & _
                                    "name=" & _Name & "&password=" & _Password & "&operationId=" & _operationId

                _Respuesta = Fx_Conectar_CashDro(_Consulta_CashDro)

                Sb_Cargar_Respuesta_Casdro(_Respuesta, _Code, _Data)

            End If

        End If

    End Function

    Function Fx_Revisar_Pago(ByVal _operationId As Integer) As String

        Dim _Operacion = String.Empty
        Dim _Estado = String.Empty

        Sb_Consultar_Estado_Operacion(_operationId)

        Dim _Arreglo() = Fx_Datos_Json(_Respuesta)

        For Each _Arr In _Arreglo

            Dim _Fila = Split(_Arr, ":")

            If _Fila.Length = 2 Then
                If _Fila(0) = "state" Then

                    _Estado = _Fila(1)

                    Select Case _Fila(1)
                        Case "I"
                            _Operacion = "la operación no existe"
                        Case "Q"
                            _Operacion = "la operación está en cola"
                        Case "E"
                            _Operacion = "la operación está en ejecución"
                        Case "F"
                            _Operacion = "la operación está finalizada"
                            _operationId = 0

                            For Each _Arr2 In _Arreglo
                                Dim _Fila2 = Split(_Arr2, ":")
                                If _Fila2(0) = "total" Then _Total = _Fila2(1)
                                If _Fila2(0) = "totalin" Then _Total_In = _Fila2(1)
                                If _Fila2(0) = "totalout" Then _Total_Out = _Fila2(1)
                                If _Fila2(0) = "Amountchangenotavailable" Then
                                    _Amountchangenotavailable = _Fila2(1)
                                    Exit For
                                End If
                            Next

                        Case Else
                            _Operacion = "Estado desconocido!!!"
                    End Select

                    Exit For
                End If
            End If

        Next

        Return _Estado

    End Function

    Enum Enum_Type_Cancelar_Operacion
        Nada
        Finaliza_La_Operacion
        Cancela_La_Operacion
    End Enum

    Function Sb_Cerrar_Transaccion_Importar_Operacion(ByVal _operationId As Integer)

        _Consulta_CashDro = "https://" & _Ip_CashDro & "/Cashdro3WS/index.php?operation=setOperationImported&" & _
                            "name=" & _Name & "&password=" & _Password & "&operationId=" & _operationId

        _Respuesta = Fx_Conectar_CashDro(_Consulta_CashDro)

        Sb_Cargar_Respuesta_Casdro(_Respuesta, _Code, _Data)

    End Function

    Function Sb_Cancelar_Operacion(ByVal _operationId As Integer, ByVal _Type As Enum_Type_Cancelar_Operacion)

        _Consulta_CashDro = "https://" & _Ip_CashDro & "/Cashdro3WS/index.php?operation=finishOperation&" & _
                            "name=" & _Name & "&password=" & _Password & "&operationId=" & _operationId & "&type=" & _Type

        _Respuesta = Fx_Conectar_CashDro(_Consulta_CashDro)

        Sb_Cargar_Respuesta_Casdro(_Respuesta, _Code, _Data)

        Select Case _Code
            Case 1, -1, -2, -99, -999

        End Select

    End Function

    Sub Sb_Cargar_Respuesta_Casdro(ByVal _Respuesta As String, _
                                   ByRef _Code As String, _
                                   ByRef _Data As String)

        _Code_Respuesta = False

        If _Respuesta.Equals("Sin Conexion") Then
            _Code_Respuesta = True
            _Code = 0
            _Data = String.Empty
        Else

            Dim _Json = Fx_Datos_Json(_Respuesta) 'Split(_Respuesta, ":", 2)

            Dim _Cod = Split(_Json(0), ":")
            Dim _Dat = Split(_Json(1), ":")

            Try
                _Code = _Cod(1)
                _Data = _Dat(1)
                _Code_Respuesta = True
            Catch ex As Exception
                _Code = 0
                _Data = String.Empty
            End Try

        End If

    End Sub

    Sub Sb_Consultar_Estado_Operacion(ByVal _operationId As Integer)

        _State = String.Empty

        Dim _T = False
        Dim _TIn = False
        Dim _Tout = False
        Dim _Amo = False

        _Consulta_CashDro = "https://" & _Ip_CashDro & "/Cashdro3WS/index.php?operation=askOperation&" & _
                           "operationId=" & _operationId & "&name=" & _Name & "&password=" & _Password

        _Respuesta = Fx_Conectar_CashDro(_Consulta_CashDro)

        Dim _Arreglo() = Fx_Datos_Json(_Respuesta)

        For Each _Arr In _Arreglo

            Dim _Fila = Split(_Arr, ":")

            If _Fila.Length = 2 Then

                If _Fila(0) = "state" Then
                    If String.IsNullOrEmpty(_State) Then
                        _State = _Fila(1)
                    End If
                End If

                If _Fila(0) = "total" Then
                    If Not _T Then
                        _Total = _Fila(1)
                        _T = True
                    End If
                End If

                If _Fila(0) = "totalin" Then
                    If Not _TIn Then
                        _Total_In = _Fila(1)
                        _TIn = True
                    End If
                End If

                If _Fila(0) = "totalout" Then
                    If Not _Tout Then
                        _Total_Out = _Fila(1)
                        _Tout = True
                    End If
                End If

                If _Fila(0) = "Amountchangenotavailable" Then
                    If Not _Amo Then
                        _Amountchangenotavailable = _Fila(1)
                        _Amo = True
                    End If
                End If

                If _Fila(0) = "withError" Then _WithError = _Fila(1)

                If _State = "F" Then
                    Dim s = 0
                End If

            End If

        Next

    End Sub


End Class




