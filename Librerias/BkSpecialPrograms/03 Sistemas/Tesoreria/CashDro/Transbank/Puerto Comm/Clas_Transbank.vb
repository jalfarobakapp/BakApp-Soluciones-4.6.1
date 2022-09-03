Public Class Clas_Transbank

    Dim _Confirmar_Monto As Boolean
    Dim _Ingrese_Clave As Boolean
    Dim _Respuesta_Transbank_Codificada As String
    Dim _Respuesta_Transbank_Decodificada As String
    Dim _Ult_Respuesta As String
    Dim _Requirimiento As String
    Dim _Resp_dispositivo As String
    Dim _Respuesta_Transbank As String
    'Dim _RtbDisplay As New RichTextBox

    Dim _Comando_Transaccion_Venta As String
    Dim _Comando_Datos_Ultima_Venta As String

    Dim _Comando_Transbank As String

    Public _Tiempo_Respuesta_Transbank As New Timer
    Public _Tiempo_De_Espera As New Timer

    Dim _Segundos_Espera As Integer

    Dim _Status As String

    Dim _Cerrar As Boolean

    Dim _Primer_Envio As Boolean

    Private comm As New Clas_Comm_Manager()

    Public ReadOnly Property Pro_Cerrar() As Boolean
        Get
            Return _Cerrar
        End Get
    End Property
    Public Property Pro_Confirmar_Monto() As Boolean
        Get
            Return _Confirmar_Monto
        End Get
        Set(ByVal value As Boolean)
            _Confirmar_Monto = value
        End Set
    End Property
    Public Property Pro_Ingrese_Clave() As Boolean
        Get
            Return _Ingrese_Clave
        End Get
        Set(ByVal value As Boolean)
            _Ingrese_Clave = value
        End Set
    End Property

    Public ReadOnly Property Pro_Respuesta_Transbank() As String
        Get
            Return _Respuesta_Transbank
        End Get
    End Property
    Public ReadOnly Property Pro_Status() As String
        Get
            Return _Status
        End Get
    End Property

    Public Property Pro_Respuesta_Transbank_Codificada() As String
        Get
            Return _Respuesta_Transbank_Codificada
        End Get
        Set(ByVal value As String)
            _Respuesta_Transbank_Codificada = value
        End Set
    End Property
    Public Property Pro_Respuesta_Transbank_Decodificada() As String
        Get
            Return _Respuesta_Transbank_Decodificada
        End Get
        Set(ByVal value As String)
            _Respuesta_Transbank_Decodificada = value
        End Set
    End Property
    Public Property Pro_Ult_Respuesta() As String
        Get
            Return _Ult_Respuesta
        End Get
        Set(ByVal value As String)
            _Ult_Respuesta = value
        End Set
    End Property
    Public Property Pro_Requirimiento() As String
        Get
            Return _Requirimiento
        End Get
        Set(ByVal value As String)
            _Requirimiento = value
        End Set
    End Property
    Public Property Pro_Resp_dispositivo() As String
        Get
            Return _Resp_dispositivo
        End Get
        Set(ByVal value As String)
            _Resp_dispositivo = value
        End Set
    End Property

    'Public Property Pro_RtbDisplay() As RichTextBox
    '    Get
    '        Return _RtbDisplay
    '    End Get
    '    Set(ByVal value As RichTextBox)
    '        _RtbDisplay = value
    '    End Set
    'End Property

    'Public ReadOnly Property Pro_Comando_Transaccion_Venta() As String
    '    Get
    '        Return _Comando_Transaccion_Venta
    '    End Get
    'End Property
    'Public ReadOnly Property Pro_Comando_Datos_Ultima_Venta() As String
    '    Get
    '        Return _Comando_Datos_Ultima_Venta
    '    End Get
    'End Property

    Public Property Pro_Puerto_Comm() As Clas_Comm_Manager
        Get
            Return comm
        End Get
        Set(ByVal value As Clas_Comm_Manager)
            comm = value
            ' comm.Pro_RichTextBox = _RtbDisplay
        End Set
    End Property

    Public Sub New() 'String)

        'comm.Pro_PortName = _Puerto
        'comm.Pro_Parity = _Paridad
        'comm.Pro_StopBits = _Bist_Parada
        'comm.Pro_DataBits = _Bist_Datos
        'comm.Pro_BaudRate = _Baudios
        'comm.Pro_RichTextBox = _RtbDisplay
        'comm.Fx_Abrir_Puerto()

        '_Lbl_Status = Lbl_Statuas

        '_Comando_Transaccion_Venta = "0200|Monto|0|0|1"
        '_Comando_Datos_Ultima_Venta = "0250|1"

        _Tiempo_De_Espera.Interval = 10000
        _Tiempo_De_Espera.Enabled = True
        _Tiempo_Respuesta_Transbank.Enabled = True

        _Tiempo_Respuesta_Transbank.Stop()

        _Primer_Envio = True
        'AddHandler _Tiempo_Respuesta_Transbank.Tick, AddressOf Tiempo_Respuesta_Tick
        ' AddHandler _Tiempo_De_Espera.Tick, AddressOf Tiempo_Respuesta_Tick

    End Sub

    Sub Sb_Ejecutrar_Transaccion(ByVal Comando_Transbank) 'ByVal _Monto As String)

        _Primer_Envio = True
        _Respuesta_Transbank = String.Empty
        comm.Pro_RichTextBox.Text = String.Empty

        _Comando_Transbank = Comando_Transbank
        'Dim _Cadena = _Comando_Transbank 'Replace(Pro_Comando_Transaccion_Venta, "Monto", _Monto)

        Dim _Lrc As String = Fx_Generar_LRC(_Comando_Transbank)

        If _Lrc.Length = 1 Then _Lrc = "0" & _Lrc

        Pro_Requirimiento = "02" & Fx_Asc2Hex(_Comando_Transbank) & "03" & _Lrc

        comm.Pro_Mensaje = Pro_Requirimiento
        comm.Pro_Type = Clas_Comm_Manager.MessageType.Normal
        comm.Sb_Escribir_Datos(Pro_Requirimiento)  'WriteData(txtSend.Text)

        _Status = String.Empty

        _Tiempo_Respuesta_Transbank.Start()

    End Sub

    Function Fx_Generar_LRC(ByVal _Cadena As String) As String

        Dim i As Integer

        Dim _Xor As Integer

        Dim _LRC = (30 Xor 32)

        _Cadena = Trim(_Cadena)

        For i = 1 To Len(Trim(_Cadena)) - 1

            Dim _A
            Dim _B

            If i = 1 Then
                _A = Mid(_Cadena, i, 1)
                _B = Mid(_Cadena, i + 1, 1)

                _A = Asc(_A)
                _B = Asc(_B)

                _Xor = _A Xor _B

                '_Escribe_Xor = "(" & _A & " XOR " & _B & ")"

            Else
                _A = _Xor
                _B = Mid(_Cadena, i + 1, 1)

                If _B = "|" Then
                    _B = &H7C
                Else
                    _B = Asc(_B) ' Fx_Asc2Hex(_B)
                End If

                _Xor = _A Xor _B
                '_Escribe_Xor = "(" & _Escribe_Xor & " XOR " & _B & ")"

            End If

        Next i

        Dim _Xhor = Fx_Asc2Hex(_Xor)

        _Xor = _Xor Xor &H3

        Dim _New_Xor = Hex(_Xor)

        'Dim _Lrc_Chr = Chr(CInt("&H" & _New_Xor))

        Return _New_Xor ' "02" & Fx_Asc2Hex(Txt_Cadena_LRC.Text) & "03" & _New_Xor

    End Function

    Function Fx_Asc2Hex(ByVal StrName As String) As String
        Dim cont As Integer = 0
        Dim strAcum As String = ""
        For cont = 1 To Len(StrName)
            strAcum &= Hex(Asc(Mid(StrName, cont, 1)))
        Next cont
        Return strAcum
    End Function

    Function Fx_Decodificar_Respuesta_Transbank(ByVal _Respuesta As String) As String

        Dim asciiOUT As System.Text.StringBuilder = New System.Text.StringBuilder

        Dim Bytes As New List(Of String)
        Bytes.AddRange(_Respuesta.Split(" ".ToCharArray, StringSplitOptions.RemoveEmptyEntries))
        For Each s As String In Bytes

            If s.Length = 2 Then
                asciiOUT.Append(Chr("&H" & s))
            End If
        Next
        Return asciiOUT.ToString

    End Function

    Sub Sb_Enviar_ACK()

        comm.Pro_Mensaje = "06"
        comm.Pro_Type = Clas_Comm_Manager.MessageType.Normal
        comm.Sb_Escribir_Datos("06")  'WriteData(txtSend.Text)

    End Sub

    Function Fx_Tabla1_Respuestas(ByVal _Respuesta As String) As String

        _Cerrar = True
        _Respuesta_Transbank = _Respuesta

        Select Case _Respuesta
            Case "00"
                Return "Aprobado"
            Case "01"
                Return "Rechazado"
            Case "02"
                Return "Autorizador no Responde"
            Case "03"
                Return "Fallo Conexión"
            Case "04"
                Return "Transacción ya fue Anulada"
            Case "05"
                Return "No existe transacción para Anular"
            Case "06"
                Return "Tarjeta no Soportada"
            Case "07"
                Return "Transacción Cancelada"
            Case "08"
                Return "No puede Anular Transacción Debito"
            Case "09"
                Return "Error Lectura de Tarjeta"
            Case "10"
                Return "Monto menor al mínimo permitido"
            Case "11"
                Return "No existe venta"
            Case "12"
                Return "Transacción no soportada"
            Case "13"
                Return "Debe ejecutar cierre"
            Case "14"
                Return "Error Encriptando PAN (BCYCLE)"
            Case "15"
                Return "Error Operando con Debito (BCYCLE)"
            Case "80"
                _Cerrar = False
                Return "Confirme el Monto"
            Case "81"
                _Cerrar = False
                Return "Ingrese Clave (PIN)"
            Case "82"
                _Cerrar = False
                Return "Procesando Transaccion"
            Case "90"
                Return "Inicialización Exitosa"
            Case "91"
                Return "Inicialización Fallida"
            Case "92"
                Return "Lector no conectado"

        End Select

    End Function

    Private Sub Tiempo_De_Espera_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs)

        _Tiempo_De_Espera.Stop()

        comm.Fx_Cerrar_Puerto()
        comm.Fx_Abrir_Puerto()

        Sb_Ejecutrar_Transaccion(_Comando_Transbank)


    End Sub

    Private Sub Tiempo_Respuesta_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs)

        _Tiempo_Respuesta_Transbank.Stop()
        If Not Fx_Time_Out(_Primer_Envio) Then
            _Primer_Envio = False
            _Tiempo_Respuesta_Transbank.Start()
        End If

    End Sub

    Function Fx_Time_Out(ByVal _Primer_Envio As Boolean) As Boolean

        _Respuesta_Transbank_Codificada = String.Empty
        _Respuesta_Transbank_Codificada = comm.Pro_Respuesta

        If _Respuesta_Transbank_Codificada.Contains("06") Then
            _Resp_dispositivo = "ACK"
            If _Primer_Envio Then
                _Status = "INSERTE Y RETIRE TARJETA"
                Exit Function
            End If
        ElseIf _Respuesta_Transbank_Codificada.Contains("15") Then
            _Resp_dispositivo = "NAK"
            _Status = "TRANSBANK...NAK"
        End If

        'Dim _Decodificada = Fx_Decodificar_Respuesta_Transbank(_Respuesta_Transbank_Codificada)

        _Respuesta_Transbank_Codificada = _Respuesta_Transbank_Codificada.Replace(Chr(10), "")
        _Respuesta_Transbank_Codificada = _Respuesta_Transbank_Codificada.Replace(Chr(13), "")
        _Respuesta_Transbank_Codificada = _Respuesta_Transbank_Codificada.Replace("02", "")
        _Respuesta_Transbank_Codificada = _Respuesta_Transbank_Codificada.Replace("06", "")

        If _Respuesta_Transbank_Codificada.Contains("03") Then

            If _Resp_dispositivo = "ACK" Then

                '_Ult_Respuesta = Replace(_Ult_Respuesta, "", "")

                _Respuesta_Transbank_Decodificada = Fx_Decodificar_Respuesta_Transbank(_Respuesta_Transbank_Codificada)
                _Respuesta_Transbank_Decodificada = Replace(_Respuesta_Transbank_Decodificada, _Ult_Respuesta, "")

                'If _Ult_Respuesta <> Txt_Respuesta_Transbank_Decodificada.Text Then
                '_Ult_Respuesta = Replace(Txt_Respuesta_Transbank_Decodificada.Text, _Ult_Respuesta, "")
                'End If

                Dim _Pos As String = Trim(_Respuesta_Transbank_Decodificada)

                '_Pos = _Ult_Respuesta
                _Pos = Replace(_Pos, Chr(10), "")
                _Pos = Replace(_Pos, Chr(13), "")
                _Pos = Replace(_Pos, Chr(3), "")

                _Pos = Replace(_Pos, "}", "")
                _Pos = Replace(_Pos, "{", "")

                _Pos = Trim(_Pos)

                Dim _Resp() As String '= Split(_Pos, "|", 2)

                If Not (_Pos Is Nothing) Then

                    If _Pos.Contains("0210|") Then

                        _Resp = Split(_Pos, "0210")
                        _Pos = "0210" & _Resp(1)

                        _Pos = Replace(_Pos, "~", "")
                        _Pos = Replace(_Pos, "y", "")

                        _Resp = Split(_Pos, "|")

                        _Respuesta_Transbank_Decodificada = _Pos
                        _Status = UCase(Fx_Tabla1_Respuestas(_Resp(1)))

                        comm.Pro_Mensaje = "06"
                        comm.Pro_Type = Clas_Comm_Manager.MessageType.Normal
                        comm.Sb_Escribir_Datos("06")  'WriteData(txtSend.Text)

                        _Tiempo_De_Espera.Start()

                        Return True

                    ElseIf _Pos.Contains("0260|") Then

                        _Resp = Split(_Pos, "0260")
                        _Pos = "0260" & _Resp(1)

                        _Resp = Split(_Pos, "|")

                        comm.Pro_Mensaje = "06"
                        comm.Pro_Type = Clas_Comm_Manager.MessageType.Normal
                        comm.Sb_Escribir_Datos("06")  'WriteData(txtSend.Text)

                        _Respuesta_Transbank_Decodificada = _Pos

                        _Status = UCase(Fx_Tabla1_Respuestas(_Resp(1)))

                        Return True

                    ElseIf _Pos.Contains("0900|") Then

                        Dim _Estatus As String

                        _Resp = Split(_Pos, "|")

                        _Estatus = _Resp(_Resp.Length - 1)
                        _Estatus = Replace(_Estatus, "~", "")

                        If _Estatus = "|" Or String.IsNullOrEmpty(_Estatus) Then
                            _Estatus = _Resp(_Resp.Length - 2)
                        End If

                        _Estatus = Replace(_Estatus, "|", "") ' Mid(_Resp(1), 1, 2)

                        _Status = UCase(Fx_Tabla1_Respuestas(_Estatus))

                        _Confirmar_Monto = False
                        _Ingrese_Clave = True

                    ElseIf _Pos.Contains("0200|") Then

                    Else

                        Dim A = 0
                        '_Tiempo_De_Espera.Start()

                        'Sb_Ejecutrar_Transaccion(_Comando_Transbank)


                    End If

                End If

            End If
        Else 'If String.IsNullOrEmpty(Trim(_Respuesta_Transbank_Codificada.Contains("03"))) Then
            'If _Resp_dispositivo = "ACK" Then
            'comm.Fx_Cerrar_Puerto()
            'comm.Fx_Abrir_Puerto()
            'Sb_Ejecutrar_Transaccion(_Comando_Transbank)
            'End If
        End If

    End Function

End Class
