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

Public Class Frm_Configuracion_CashDro

    Dim _Ip_CashDro = "192.168.1.20"
    Dim _Usuario = "admin"
    Dim _Contraseña = "12345"

    Dim _Consulta_CashDro As String
    Dim _operationId As Integer

    Dim _CashDro As Clas_Chasdro

    Dim _Tiempo_Espera As Integer = 0
    Dim _Tiempo_Maximo As Integer = 30

    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Private Sub Frm_Configuracion_CashDro_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        _CashDro = New Clas_Chasdro(_Ip_CashDro, _Usuario, _Contraseña)

    End Sub

    Function Fx_Conectar_CashDro(ByVal _Uri As String)


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


    End Function

    Private Function ValidarCertificado(ByVal sender As Object, ByVal certificate As System.Security.Cryptography.X509Certificates.X509Certificate, ByVal chain As System.Security.Cryptography.X509Certificates.X509Chain, ByVal sslPolicyErrors As System.Net.Security.SslPolicyErrors) As Boolean
        Return True
    End Function

   
    Private Sub Txt_Peticion_Venta_Valor_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Txt_Peticion_Venta_Valor.KeyDown

        If e.KeyValue = Keys.Enter Then

            _CashDro.Sb_Peticion_Venta(Txt_Peticion_Venta_Valor.Text)
            _operationId = _CashDro.Pro_OperationId


            If CBool(_operationId) Then
                Txt_operationId.Text = _operationId
                Timer1.Enabled = True
            End If

        End If

    End Sub

    Private Sub Txt_Consultar_X_Operacion_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)

        If e.KeyValue = Keys.Enter Then

            Dim _operationId = "" 'Txt_Consultar_X_Operacion.Text

            _Consulta_CashDro = "https://" & _Ip_CashDro & "/Cashdro3WS/index.php?operation=askOperation&" & _
                           "operationId=" & _operationId & "&name=" & _Usuario & "&password=" & _Contraseña

            Dim _Respuesta = Fx_Conectar_CashDro(_Consulta_CashDro)

            Dim _Arreglo() = Fx_Datos_Json(_Respuesta)

            MsgBox(_Respuesta)
        End If

    End Sub

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


    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick

        Timer1.Enabled = False

        With _CashDro

            If _Tiempo_Espera = _Tiempo_Maximo Then
                _Tiempo_Espera = 0

                .Sb_Cancelar_Operacion(_operationId, Clas_Chasdro.Enum_Type_Cancelar_Operacion.Cancela_La_Operacion)

                If .Pro_Code_Respuesta Then

                    MessageBoxEx.Show(Me, "OPERACION CANCELADA AUTOMATICAMENTE", _
                                      "Tiempo de espera terminado, máximo . " & _Tiempo_Maximo & " Segundos", _
                                      MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    '_CashDro.Pro_OperationId = 0
                    '_operationId = 0

                End If

            End If


            .Sb_Consultar_Estado_Operacion(_operationId)

            Dim _State As String = .Pro_State
            Dim _WithError As Boolean = .Pro_WithError

            Txt_Respuesta_Arturito.Text = _CashDro.Pro_Respuesta

            If _WithError Then

                .Sb_Cancelar_Operacion(_operationId, Clas_Chasdro.Enum_Type_Cancelar_Operacion.Cancela_La_Operacion)

                If .Pro_Code_Respuesta Then

                    MessageBoxEx.Show(Me, "ERROR EN CAJERO, DEBE REVISAR LA MAQUINA MANUALMENTE" & vbCrLf & _
                                      "OPERACION CANCELADA", _
                                      "ERROR INTERNO CASHDRO", _
                                      MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    _CashDro.Pro_OperationId = 0
                    _operationId = 0

                End If

            Else
                Select Case _State
                    Case "I"
                        Me.Text = "la operación no existe"
                    Case "Q"
                        Me.Text = "la operación está en cola"
                        Timer1.Enabled = True
                    Case "E"
                        Me.Text = "la operación está en ejecución"
                        Timer1.Enabled = True
                    Case "F"

                        .Sb_Consultar_Estado_Operacion(_operationId)

                        Dim _Total As Double = .Pro_Total
                        Dim _Total_In As Double = .Pro_Total_In
                        Dim _Total_Out As Double = .Pro_Total_Out
                        Dim _Amountchangenotavailable As Double = .Pro_Amountchangenotavailable

                        Me.Text = "la operación está finalizada"
                        _CashDro.Pro_OperationId = 0
                        _operationId = 0

                        MessageBoxEx.Show(Me, "la operación está finalizada" & vbCrLf & _
                                          "Total: " & FormatCurrency(_Total, 0) & vbCrLf & _
                                          "Efectivo:" & FormatCurrency(_Total_In, 0) & vbCrLf & _
                                          "Vuelto:" & FormatCurrency(_Total_Out, 0) & vbCrLf & _
                                          "Cambio no disponible: " & FormatCurrency(_Amountchangenotavailable, 0), _
                                          "Respuesta Arturito", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    Case Else
                        Me.Text = "Estado desconocido!!!"
                End Select
            End If
        End With

        _Tiempo_Espera += 1


    End Sub



    Private Sub Btn_Cancelar_Solicitud_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Cancelar_Solicitud.Click

        If Not String.IsNullOrEmpty(Txt_operationId.Text) Then
            Dim _operationId = Txt_operationId.Text
            _CashDro.Sb_Cancelar_Operacion(_operationId, Clas_Chasdro.Enum_Type_Cancelar_Operacion.Cancela_La_Operacion)
            If _CashDro.Pro_Code_Respuesta Then

                Timer1.Enabled = True

                Txt_Respuesta_Arturito.Text = _CashDro.Pro_Respuesta
                MessageBoxEx.Show(Me, "Accion cancelada por el usuario", _
                                  "Cancelar", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
        End If

    End Sub

    Private Sub Btn_Consultar_Operacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Consultar_Operacion.Click

        If Not String.IsNullOrEmpty(Txt_operationId.Text) Then
            Dim _operationId = Txt_operationId.Text
            _CashDro.Sb_Consultar_Estado_Operacion(_operationId)

            Txt_Respuesta_Arturito.Text = _CashDro.Pro_Respuesta

        End If

    End Sub
End Class

