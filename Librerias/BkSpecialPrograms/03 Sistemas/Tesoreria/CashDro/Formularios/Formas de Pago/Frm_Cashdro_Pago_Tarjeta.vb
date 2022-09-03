Imports DevComponents.DotNetBar
Imports System.IO
Imports System.Threading

Public Class Frm_Cashdro_Pago_Tarjeta

    Dim comm As New Clas_Comm_Manager()

    Dim _Puerto_Bloqueado As Boolean

    Dim _Monto As String
    Dim _Resp_dispositivo As String
    Dim _Pagado As Boolean

    Dim _Datos_Ultima_Venta As String
    Dim _Cerrar_Formulario As Boolean
    Dim _Comando_Transaccion As String

    Dim _Respuesta_Transbank_Codificada As String
    Dim _Respuesta_Transbank_Decodificada As String

    Dim _Respuesta_Transbank As String
    Dim _Intentos_Venta As Integer

    Dim _Row_CashDro As DataRow

    Dim _Error_Conexion As Boolean
    Dim _Cierra_Usuario As Boolean

    Dim _Respuesta_Trans_D() As String

    Enum Enum_Accion
        Transaccion_Venta
        Datos_Ultima_Venta
        Anular_Venta
        Cargar_Llaves
        Cerrar_Terminal
        Pooling
        Inicializar
        Detalle_Totales
        Imprimir_Ventas
    End Enum

    Dim _Accion As Enum_Accion
    Enum Enum_Tipo_Post
        Post_Autoservicio
        Post_Integrado
    End Enum

    Dim _Tipo_Post As Enum_Tipo_Post

    Public ReadOnly Property Pro_Respuesta_Transbank() As String
        Get
            Return _Respuesta_Transbank
        End Get
    End Property
    Public ReadOnly Property Pro_Pagado() As Boolean
        Get
            Return _Pagado
        End Get
    End Property
    Public ReadOnly Property Pro_Resp_Tbk_Datos_Ultima_Venta() As String
        Get
            Return _Datos_Ultima_Venta
        End Get
    End Property
    Public ReadOnly Property Pro_Respuesta_Decodificada() As String
        Get
            Return Txt_Respuesta_Transbank_Decodificada.Text
        End Get
    End Property
    Public ReadOnly Property Pro_Status() As String
        Get
            Return Lbl_Status.Text
        End Get
    End Property
    Public ReadOnly Property Pro_Erro_Conexion() As Boolean
        Get
            Return _Error_Conexion
        End Get
    End Property
    Public Property Pro_Puerto_Bloqueado As Boolean
        Get
            Return _Puerto_Bloqueado
        End Get
        Set(value As Boolean)
            _Puerto_Bloqueado = value
        End Set
    End Property
    Public Property Pro_Cierra_Usuario As Boolean
        Get
            Return _Cierra_Usuario
        End Get
        Set(value As Boolean)
            _Cierra_Usuario = value
        End Set
    End Property
    Public Property Pro_Comando_Transaccion As String
        Get
            Return _Comando_Transaccion
        End Get
        Set(value As String)
            _Comando_Transaccion = value
        End Set
    End Property
    Public Property Pro_Respuesta_Trans_D As String()
        Get
            Return _Respuesta_Trans_D
        End Get
        Set(value As String())
            _Respuesta_Trans_D = value
        End Set
    End Property

    Public Sub New(Row_CashDro As DataRow,
                   NroDocumento As String,
                   Monto As Double,
                   Accion As Enum_Accion,
                   Traer_Voucher As Boolean)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        '_Clas_Transbank.Pro_Puerto_Comm = comm

        rtbDisplay.Visible = True

        _Row_CashDro = Row_CashDro
        _Monto = Monto

        NroDocumento = NroDocumento.TrimStart("0")
        If String.IsNullOrEmpty(NroDocumento) Then NroDocumento = "0"

        _Accion = Accion 'Enum_Accion.Transaccion_Venta

        Dim _Post_Autoservicio, _Post_Integrado As Boolean

        _Post_Autoservicio = _Row_CashDro.Item("Post_Autoservicio")
        _Post_Integrado = _Row_CashDro.Item("Post_Integrado")

        If _Post_Autoservicio Then Me._Tipo_Post = Enum_Tipo_Post.Post_Autoservicio
        If _Post_Integrado Then Me._Tipo_Post = Enum_Tipo_Post.Post_Integrado

        Dim _Con_Voucher As Integer = CInt(Traer_Voucher) * -1

        Tiempo_Cierre.Stop()

        Select Case _Accion

            Case Enum_Accion.Transaccion_Venta

                Lbl_Total_A_Pagar.Text = "TOTAL: " & FormatCurrency(_Monto, 0)

                If _Tipo_Post = Enum_Tipo_Post.Post_Autoservicio Then _Comando_Transaccion = "0200|Monto|" & NroDocumento & "|" & _Con_Voucher & "|1" '0200|5000|0|0|1
                If _Tipo_Post = Enum_Tipo_Post.Post_Integrado Then _Comando_Transaccion = "0200|Monto|" & NroDocumento & "|||0"

                _Comando_Transaccion = Replace(_Comando_Transaccion, "Monto", _Monto)

            Case Enum_Accion.Anular_Venta

                Lbl_Total_A_Pagar.Text = "ANULAR VENTA"

                If _Tipo_Post = Enum_Tipo_Post.Post_Autoservicio Then _Comando_Transaccion = "1200"
                If _Tipo_Post = Enum_Tipo_Post.Post_Integrado Then _Comando_Transaccion = "1200|" & NroDocumento

            Case Enum_Accion.Datos_Ultima_Venta

                Lbl_Total_A_Pagar.Text = "DATOS ULTIMA VENTA"

                If _Tipo_Post = Enum_Tipo_Post.Post_Autoservicio Then _Comando_Transaccion = "0250|" & _Con_Voucher
                If _Tipo_Post = Enum_Tipo_Post.Post_Integrado Then _Comando_Transaccion = "0250|"

                Tiempo_Cierre.Interval = 15 * 1000
                Tiempo_Cierre.Start()

            Case Enum_Accion.Cerrar_Terminal

                Lbl_Total_A_Pagar.Text = "CERRAR TERMINAL"
                _Comando_Transaccion = "0500|1"

            Case Enum_Accion.Cargar_Llaves

                Lbl_Total_A_Pagar.Text = "CARGAR LLAVES"
                _Comando_Transaccion = "0800"

            Case Enum_Accion.Pooling

                Lbl_Total_A_Pagar.Text = "POLLING"
                _Comando_Transaccion = "0100"

            Case Enum_Accion.Inicializar

                Lbl_Total_A_Pagar.Text = "INICIALIZAR"
                _Comando_Transaccion = "0070"

            Case Enum_Accion.Detalle_Totales

                Lbl_Total_A_Pagar.Text = "DETALLE DE TOTALES"
                _Comando_Transaccion = "0700||"

            Case Enum_Accion.Imprimir_Ventas

                Lbl_Total_A_Pagar.Text = "IMPRIMIENDO VENTAS"
                _Comando_Transaccion = "0260|0|"

        End Select

    End Sub

    Private Sub Frm_Cashdro_Pago_Tarjeta_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Lbl_Status.Text = String.Empty

        comm.Pro_PortName = _Row_CashDro.Item("Tbk_Puerto")
        comm.Pro_Parity = _Row_CashDro.Item("Tbk_Paridad")
        comm.Pro_StopBits = _Row_CashDro.Item("Tbk_Bits_de_parada")
        comm.Pro_DataBits = _Row_CashDro.Item("Tbk_Bits_de_datos")
        comm.Pro_BaudRate = _Row_CashDro.Item("Tbk_Tasa_de_baudios")
        comm.Pro_RichTextBox = rtbDisplay

        comm.Pro_CurrentTransmissionType = Clas_Comm_Manager.TransmissionType.Hex
        comm.Pro_RichTextBox = rtbDisplay

        If Not comm.Fx_Abrir_Puerto() Then
            _Puerto_Bloqueado = True
        End If

        Tiempo_Abrir.Enabled = True
        Tiempo_Abrir.Start()
        Tiempo_Label.Interval = 500

    End Sub

    Sub Sb_Ejecutar_Transaccion_Transbank(ByVal _Comando_Transaccion As String)

        Txt_Respuesta_Transbank_Codificada.Text = String.Empty
        Txt_Respuesta_Transbank_Decodificada.Text = String.Empty
        Txt_Requirimiento.Text = String.Empty

        _Resp_dispositivo = String.Empty

        rtbDisplay.Text = String.Empty

        Dim _Lrc As String = Fx_Generar_LRC(_Comando_Transaccion)

        If _Lrc.Length = 1 Then _Lrc = "0" & _Lrc

        Dim _Requirimiento As String = "02" & Fx_Asc2Hex(_Comando_Transaccion) & "03" & _Lrc

        Txt_Requirimiento.Text = _Requirimiento

        comm.Pro_RichTextBox.Text = String.Empty
        comm.Pro_Mensaje = _Requirimiento
        comm.Pro_Type = Clas_Comm_Manager.MessageType.Normal
        comm.Sb_Escribir_Datos(_Requirimiento)

        Tiempo_Respuesta_Transbank.Start()

        Lbl_Status.Text = String.Empty

    End Sub

    Private Sub Tiempo_Abrir_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tiempo_Abrir.Tick

        Tiempo_Abrir.Stop()
        _Respuesta_Transbank = String.Empty

        If Not _Puerto_Bloqueado Then

            RemoveHandler Tiempo_Respuesta_Transbank.Tick, AddressOf Tiempo_Respuesta_Datos_Ultima_Venta_Tick
            RemoveHandler Tiempo_Respuesta_Transbank.Tick, AddressOf Tiempo_Respuesta_Transaccion_Venta_Tick
            RemoveHandler Tiempo_Respuesta_Transbank.Tick, AddressOf Tiempo_Respuesta_Anular_Ultima_Venta_Tick

            Select Case _Accion
                Case Enum_Accion.Transaccion_Venta
                    AddHandler Tiempo_Respuesta_Transbank.Tick, AddressOf Tiempo_Respuesta_Transaccion_Venta_Tick
                Case Enum_Accion.Datos_Ultima_Venta
                    AddHandler Tiempo_Respuesta_Transbank.Tick, AddressOf Tiempo_Respuesta_Datos_Ultima_Venta_Tick
                Case Enum_Accion.Anular_Venta
                    AddHandler Tiempo_Respuesta_Transbank.Tick, AddressOf Tiempo_Respuesta_Anular_Ultima_Venta_Tick
                Case Enum_Accion.Cerrar_Terminal
                    AddHandler Tiempo_Respuesta_Transbank.Tick, AddressOf Tiempo_Respuesta_Cierre_Tick
                Case Enum_Accion.Cargar_Llaves
                    AddHandler Tiempo_Respuesta_Transbank.Tick, AddressOf Tiempo_Respuesta_Cargar_Llaves_Tick
                Case Enum_Accion.Pooling
                    AddHandler Tiempo_Respuesta_Transbank.Tick, AddressOf Tiempo_Respuesta_Polling_Tick
                Case Enum_Accion.Inicializar
                    AddHandler Tiempo_Respuesta_Transbank.Tick, AddressOf Tiempo_Respuesta_Inicializar_Tick
                Case Enum_Accion.Detalle_Totales
                    AddHandler Tiempo_Respuesta_Transbank.Tick, AddressOf Tiempo_Respuesta_Detalle_Totales_Tick
                Case Enum_Accion.Imprimir_Ventas
                    AddHandler Tiempo_Respuesta_Transbank.Tick, AddressOf Tiempo_Respuesta_Impresion_Detalle_Ventas_Tick
            End Select

            Sb_Ejecutar_Transaccion_Transbank(_Comando_Transaccion)
        Else
            Me.Close()
        End If

    End Sub

    Private Sub Tiempo_Respuesta_Transaccion_Venta_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Tiempo_Respuesta_Transbank.Stop()

        Dim _Rechazado As Boolean

        If Fx_Time_Transaccion_Venta(_Respuesta_Transbank, _Intentos_Venta, _Rechazado) Then

            If _Resp_dispositivo = "ACK" Then

                If _Respuesta_Transbank = "00" Then

                    'Sb_Datos_Ultima_Venta()
                    _Pagado = True
                    Me.Close()

                Else

                    If _Rechazado Then

                        Tiempo_Label.Stop()
                        Lbl_Status.Visible = True
                        Beep()
                        Lbl_Status.Text = UCase(Fx_Tabla1_Respuestas(_Respuesta_Transbank))
                        Lbl_Status.ForeColor = Color.Red
                        Tiempo_Cierre.Start()

                    Else

                        Me.Close()

                    End If

                End If

            ElseIf _Resp_dispositivo = "NAK" Then

                If _Intentos_Venta < 3 Then

                    Tiempo_Abrir.Start()
                    Me.Text = "PAGO CON TARJETA (" & _Intentos_Venta + 1 & ")"
                    Lbl_Status.Text = "OPERE TRANSBANK..." '"INSERTE Y RETIRE TARJETA"

                Else

                    Me.Close()

                End If

            Else

                If Not String.IsNullOrEmpty(_Respuesta_Transbank) Then

                    Tiempo_Respuesta_Transbank.Stop()
                    Txt_Respuesta_Transbank_Decodificada.Text = _Respuesta_Transbank
                    Lbl_Status.Text = "Error!"
                    Me.Close()

                End If

            End If

        Else

            Tiempo_Respuesta_Transbank.Start()

        End If

    End Sub

    Private Sub Tiempo_Respuesta_Transaccion_Venta_Tick_Old(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Tiempo_Respuesta_Transbank.Stop()

        Dim _Rechazado As Boolean

        If Fx_Time_Transaccion_Venta(_Respuesta_Transbank, _Intentos_Venta, _Rechazado) Then

            If _Resp_dispositivo = "ACK" Then

                If _Respuesta_Transbank = "00" Then

                    Sb_Datos_Ultima_Venta()

                Else

                    If _Rechazado Then

                        Tiempo_Label.Stop()
                        Lbl_Status.Visible = True
                        Beep()
                        Lbl_Status.Text = UCase(Fx_Tabla1_Respuestas(_Respuesta_Transbank))
                        Lbl_Status.ForeColor = Color.Red
                        Tiempo_Cierre.Start()

                    Else

                        Me.Close()

                    End If

                End If

            ElseIf _Resp_dispositivo = "NAK" Then

                If _Intentos_Venta < 3 Then

                    Tiempo_Abrir.Start()
                    Me.Text = "PAGO CON TARJETA (" & _Intentos_Venta + 1 & ")"
                    Lbl_Status.Text = "OPERE TRANSBANK..." '"INSERTE Y RETIRE TARJETA"

                Else

                    Me.Close()

                End If

            Else

                If Not String.IsNullOrEmpty(_Respuesta_Transbank) Then

                    Tiempo_Respuesta_Transbank.Stop()
                    Txt_Respuesta_Transbank_Decodificada.Text = _Respuesta_Transbank
                    Lbl_Status.Text = "Error!"
                    Me.Close()

                End If

            End If

        Else

            Tiempo_Respuesta_Transbank.Start()

        End If

    End Sub
    Private Sub Tiempo_Respuesta_Datos_Ultima_Venta_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Tiempo_Respuesta_Transbank.Stop()

        Dim _Rechazado As Boolean

        If Fx_Time_Datos_Ultima_Venta() Then
            If _Resp_dispositivo = "ACK" Then
                Me.Close()
            ElseIf _Resp_dispositivo = "NAK" Then
                If _Intentos_Venta < 3 Then
                    Sb_Datos_Ultima_Venta()
                End If
            End If
        Else
            Tiempo_Respuesta_Transbank.Start()
        End If
        'Tiempo_Respuesta.Enabled = True

    End Sub

    Private Sub Tiempo_Respuesta_Anular_Ultima_Venta_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Tiempo_Respuesta_Transbank.Stop()

        If Fx_Time_Anular_Ultima_Venta() Then
            If _Resp_dispositivo = "ACK" Then
                Me.Close()
            ElseIf _Resp_dispositivo = "NAK" Then
                If _Intentos_Venta < 3 Then
                    Sb_Ejecutar_Transaccion_Transbank(_Comando_Transaccion)
                End If
            End If
        Else
            Tiempo_Respuesta_Transbank.Start()
        End If

    End Sub

    Private Sub Tiempo_Respuesta_Cargar_Llaves_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Tiempo_Respuesta_Transbank.Stop()

        If Fx_Time_Cargar_Llaves() Then
            If _Resp_dispositivo = "ACK" Then
                Me.Close()
            ElseIf _Resp_dispositivo = "NAK" Then
                If _Intentos_Venta < 3 Then
                    Sb_Ejecutar_Transaccion_Transbank(_Comando_Transaccion)
                End If
            End If
        Else
            Tiempo_Respuesta_Transbank.Start()
        End If

    End Sub

    Private Sub Tiempo_Respuesta_Cierre_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Tiempo_Respuesta_Transbank.Stop()

        If Fx_Time_Cierre() Then
            If _Resp_dispositivo = "ACK" Then
                Me.Close()
            ElseIf _Resp_dispositivo = "NAK" Then
                If _Intentos_Venta < 3 Then
                    Sb_Ejecutar_Transaccion_Transbank(_Comando_Transaccion)
                End If
            End If
        Else
            Tiempo_Respuesta_Transbank.Start()
        End If

    End Sub

    Private Sub Tiempo_Respuesta_Polling_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Tiempo_Respuesta_Transbank.Stop()

        Dim _Rechazado As Boolean

        If Fx_Time_Polling(_Intentos_Venta) Then
            If _Resp_dispositivo = "ACK" Then
                Me.Close()
            ElseIf _Resp_dispositivo = "NAK" Then
                If _Intentos_Venta < 3 Then
                    Sb_Ejecutar_Transaccion_Transbank(_Comando_Transaccion)
                Else
                    Me.Close()
                End If
            End If

            If String.IsNullOrEmpty(_Resp_dispositivo) Then
                Tiempo_Respuesta_Transbank.Start()
            End If

        Else
            Tiempo_Respuesta_Transbank.Start()
        End If

    End Sub

    Private Sub Tiempo_Respuesta_Detalle_Totales_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Tiempo_Respuesta_Transbank.Stop()

        If Fx_Time_Respuesta_Detalle_Totales() Then
            If _Resp_dispositivo = "ACK" Then
                Me.Close()
            ElseIf _Resp_dispositivo = "NAK" Then
                If _Intentos_Venta < 3 Then
                    Sb_Ejecutar_Transaccion_Transbank(_Comando_Transaccion)
                End If
            End If
        Else
            Tiempo_Respuesta_Transbank.Start()
        End If

    End Sub

    Private Sub Tiempo_Respuesta_Impresion_Detalle_Ventas_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Tiempo_Respuesta_Transbank.Stop()

        If Fx_Time_Inicializacion() Then
            If _Resp_dispositivo = "ACK" Then
                Me.Close()
            ElseIf _Resp_dispositivo = "NAK" Then
                If _Intentos_Venta < 3 Then
                    Sb_Ejecutar_Transaccion_Transbank(_Comando_Transaccion)
                End If
            End If
        Else
            Tiempo_Respuesta_Transbank.Start()
        End If

    End Sub

    Private Sub Tiempo_Respuesta_Inicializar_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Tiempo_Respuesta_Transbank.Stop()

        Dim _Rechazado As Boolean

        If Fx_Time_Inicializacion() Then
            If _Resp_dispositivo = "ACK" Then
                Me.Close()
            ElseIf _Resp_dispositivo = "NAK" Then
                If _Intentos_Venta < 3 Then
                    Sb_Ejecutar_Transaccion_Transbank(_Comando_Transaccion)
                End If
            End If
        Else
            Tiempo_Respuesta_Transbank.Start()
        End If

    End Sub

    Sub Sb_Datos_Ultima_Venta()

        RemoveHandler Tiempo_Respuesta_Transbank.Tick, AddressOf Tiempo_Respuesta_Transaccion_Venta_Tick
        AddHandler Tiempo_Respuesta_Transbank.Tick, AddressOf Tiempo_Respuesta_Datos_Ultima_Venta_Tick

        Dim _Cadena = "0250|1"

        Sb_Ejecutar_Transaccion_Transbank(_Cadena)

    End Sub

    Function Fx_Time_Transaccion_Venta_Old(ByRef _Respuesta_Transbank As String,
                                      ByRef _Intentos As Integer,
                                      ByRef _Rechazado As Boolean) As Boolean

        Dim _Pos As String = String.Empty

        Txt_Respuesta_Transbank_Codificada.Text = String.Empty
        Txt_Respuesta_Transbank_Codificada.Text = comm.Pro_Respuesta

        Dim _Type = comm.Pro_Type

        If _Type = Clas_Comm_Manager.MessageType.Error Then
            _Error_Conexion = True
            _Pagado = False
            _Respuesta_Transbank = Txt_Respuesta_Transbank_Codificada.Text
            Txt_Respuesta_Transbank_Decodificada.Text = Txt_Respuesta_Transbank_Codificada.Text
            Return True
        End If

        If Txt_Respuesta_Transbank_Codificada.Text.Contains("06") Then
            _Resp_dispositivo = "ACK"
            Lbl_Status.Text = "OPERE TRANSBANK..." '"INSERTE Y RETIRE TARJETA"
        ElseIf Txt_Respuesta_Transbank_Codificada.Text.Contains("15") Then
            _Resp_dispositivo = "NAK"
            _Intentos += 1
            Return True
            'Lbl_Status.Text = "TRANSBANK...NAK"
        End If

        Txt_Respuesta_Transbank_Codificada.Text = Txt_Respuesta_Transbank_Codificada.Text.Replace(Chr(10), "")
        Txt_Respuesta_Transbank_Codificada.Text = Txt_Respuesta_Transbank_Codificada.Text.Replace(Chr(13), "")
        Txt_Respuesta_Transbank_Codificada.Text = Txt_Respuesta_Transbank_Codificada.Text.Replace("02", "")
        Txt_Respuesta_Transbank_Codificada.Text = Txt_Respuesta_Transbank_Codificada.Text.Replace("06", "")

        If Txt_Respuesta_Transbank_Codificada.Text.Contains("03") Then

            Txt_Respuesta_Transbank_Decodificada.Text = Fx_Decodificar_Respuesta_Transbank(Txt_Respuesta_Transbank_Codificada.Text)

            _Pos = Trim(Txt_Respuesta_Transbank_Decodificada.Text)

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
                    _Respuesta_Trans_D = _Resp

                    Txt_Respuesta_Transbank_Decodificada.Text = _Pos

                    If Lbl_Status.Text <> "OPERE TRANSBANK..." Then
                        Lbl_Status.Text = UCase(Fx_Tabla1_Respuestas(_Resp(1)))
                    End If

                    _Respuesta_Transbank = _Resp(1)

                    If _Resp.Length >= 2 Then

                        If _Respuesta_Transbank = "00" Then

                            _Pagado = True

                            If _Resp.Length >= 9 Then

                                If _Resp(0) = "0210" Then
                                    comm.Pro_Mensaje = "06"
                                    comm.Pro_Type = Clas_Comm_Manager.MessageType.Normal
                                    comm.Sb_Escribir_Datos("06")  'WriteData(txtSend.Text)
                                    Return True
                                End If

                            End If

                        Else

                            If _Respuesta_Transbank = "01" Then
                                _Rechazado = True
                            End If

                            comm.Pro_Mensaje = "06"
                            comm.Pro_Type = Clas_Comm_Manager.MessageType.Normal
                            comm.Sb_Escribir_Datos("06")  'WriteData(txtSend.Text)
                            Return True

                        End If

                    End If

                ElseIf _Pos.Contains("0900|") Then

                    Dim _Estatus As String

                    _Resp = Split(_Pos, "|")

                    _Estatus = _Resp(_Resp.Length - 1)
                    _Estatus = Replace(_Estatus, "~", "")

                    If _Estatus = "|" Or String.IsNullOrEmpty(_Estatus) Then
                        _Estatus = _Resp(_Resp.Length - 2)
                    End If

                    _Estatus = Replace(_Estatus, "|", "") ' Mid(_Resp(1), 1, 2)

                    If Lbl_Status.Text <> "OPERE TRANSBANK..." Then
                        Lbl_Status.Text = UCase(Fx_Tabla1_Respuestas(_Estatus))
                    End If

                    Tiempo_Label.Stop()
                    Lbl_Status.Visible = True

                End If

            End If

        End If

    End Function

    Function Fx_Time_Transaccion_Venta(ByRef _Respuesta_Transbank As String,
                                       ByRef _Intentos As Integer,
                                       ByRef _Rechazado As Boolean) As Boolean

        Dim _Pos As String = String.Empty

        Txt_Respuesta_Transbank_Codificada.Text = String.Empty
        Txt_Respuesta_Transbank_Codificada.Text = comm.Pro_Respuesta

        Dim _Type = comm.Pro_Type

        If _Type = Clas_Comm_Manager.MessageType.Error Then

            _Error_Conexion = True
            _Pagado = False
            _Respuesta_Transbank = Txt_Respuesta_Transbank_Codificada.Text
            Txt_Respuesta_Transbank_Decodificada.Text = Txt_Respuesta_Transbank_Codificada.Text
            Return True

        End If

        If Txt_Respuesta_Transbank_Codificada.Text.Contains("06") Then

            _Resp_dispositivo = "ACK"
            Lbl_Status.Text = "OPERE TRANSBANK..." '"INSERTE Y RETIRE TARJETA"

        ElseIf Txt_Respuesta_Transbank_Codificada.Text.Contains("15") Then

            _Resp_dispositivo = "NAK"
            _Intentos += 1
            Return True

        End If

        Txt_Respuesta_Transbank_Codificada.Text = Txt_Respuesta_Transbank_Codificada.Text.Replace(Chr(10), "")
        Txt_Respuesta_Transbank_Codificada.Text = Txt_Respuesta_Transbank_Codificada.Text.Replace(Chr(13), "")
        Txt_Respuesta_Transbank_Codificada.Text = Txt_Respuesta_Transbank_Codificada.Text.Replace("02", "")
        Txt_Respuesta_Transbank_Codificada.Text = Txt_Respuesta_Transbank_Codificada.Text.Replace("06", "")

        If Txt_Respuesta_Transbank_Codificada.Text.Contains("03") Then

            Txt_Respuesta_Transbank_Decodificada.Text = Fx_Decodificar_Respuesta_Transbank(Txt_Respuesta_Transbank_Codificada.Text)

            _Pos = Trim(Txt_Respuesta_Transbank_Decodificada.Text)

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
                    _Respuesta_Trans_D = _Resp

                    Txt_Respuesta_Transbank_Decodificada.Text = _Pos

                    If Lbl_Status.Text <> "OPERE TRANSBANK..." Then
                        Lbl_Status.Text = UCase(Fx_Tabla1_Respuestas(_Resp(1)))
                    End If

                    _Respuesta_Transbank = _Resp(1)

                    If _Resp.Length >= 2 Then

                        If _Respuesta_Transbank = "00" Then

                            _Pagado = True
                            Lbl_Status.Text = UCase(Fx_Tabla1_Respuestas(_Resp(1)))

                            comm.Pro_Mensaje = "06"
                            comm.Pro_Type = Clas_Comm_Manager.MessageType.Normal
                            comm.Sb_Escribir_Datos("06")  'WriteData(txtSend.Text)
                            Return True

                        Else

                            If _Respuesta_Transbank = "01" Then
                                _Rechazado = True
                            End If

                            comm.Pro_Mensaje = "06"
                            comm.Pro_Type = Clas_Comm_Manager.MessageType.Normal
                            comm.Sb_Escribir_Datos("06")  'WriteData(txtSend.Text)
                            Return True

                        End If

                    End If

                ElseIf _Pos.Contains("0900|") Then

                    Dim _Estatus As String

                    _Resp = Split(_Pos, "|")

                    _Estatus = _Resp(_Resp.Length - 1)
                    _Estatus = Replace(_Estatus, "~", "")

                    If _Estatus = "|" Or String.IsNullOrEmpty(_Estatus) Then
                        _Estatus = _Resp(_Resp.Length - 2)
                    End If

                    _Estatus = Replace(_Estatus, "|", "")

                    If Lbl_Status.Text <> "OPERE TRANSBANK..." Then
                        Lbl_Status.Text = UCase(Fx_Tabla1_Respuestas(_Estatus))
                    End If

                    Tiempo_Label.Stop()
                    Lbl_Status.Visible = True

                End If

            End If

        End If

    End Function

    Function Fx_Time_Datos_Ultima_Venta() As Boolean

        Dim _Pos As String = String.Empty

        Txt_Respuesta_Transbank_Codificada.Text = String.Empty
        Txt_Respuesta_Transbank_Codificada.Text = comm.Pro_Respuesta

        If Txt_Respuesta_Transbank_Codificada.Text.Contains("06") Then
            _Resp_dispositivo = "ACK"
        ElseIf Txt_Respuesta_Transbank_Codificada.Text.Contains("15") Then
            _Resp_dispositivo = "NAK"
            Return True
        End If

        Dim _Type = comm.Pro_Type

        If _Type = Clas_Comm_Manager.MessageType.Error Then
            _Error_Conexion = True
            _Resp_dispositivo = "ACK"
            Txt_Respuesta_Transbank_Decodificada.Text = Txt_Respuesta_Transbank_Codificada.Text
            Return True
        End If

        Txt_Respuesta_Transbank_Codificada.Text = Txt_Respuesta_Transbank_Codificada.Text.Replace(Chr(10), "")
        Txt_Respuesta_Transbank_Codificada.Text = Txt_Respuesta_Transbank_Codificada.Text.Replace(Chr(13), "")
        Txt_Respuesta_Transbank_Codificada.Text = Txt_Respuesta_Transbank_Codificada.Text.Replace("02", "")
        Txt_Respuesta_Transbank_Codificada.Text = Txt_Respuesta_Transbank_Codificada.Text.Replace("06", "")

        If Txt_Respuesta_Transbank_Codificada.Text.Contains("03") Then

            Txt_Respuesta_Transbank_Decodificada.Text = Fx_Decodificar_Respuesta_Transbank(Txt_Respuesta_Transbank_Codificada.Text)

            _Pos = Trim(Txt_Respuesta_Transbank_Decodificada.Text)

            _Pos = Replace(_Pos, Chr(10), "")
            _Pos = Replace(_Pos, Chr(13), "")
            _Pos = Replace(_Pos, Chr(3), "")

            _Pos = Replace(_Pos, "}", "")
            _Pos = Replace(_Pos, "{", "")

            _Pos = Trim(_Pos)

            Dim _Resp() As String

            If Not (_Pos Is Nothing) Then

                If _Pos.Contains("0260|") Then

                    _Resp = Split(_Pos, "0260")
                    _Pos = "0260" & _Resp(1)

                    _Resp = Split(_Pos, "|")

                    If _Resp.Length > 14 Then

                        _Resp_dispositivo = "ACK"

                        comm.Pro_Mensaje = "06"
                        comm.Pro_Type = Clas_Comm_Manager.MessageType.Normal
                        comm.Sb_Escribir_Datos("06")  'WriteData(txtSend.Text)

                        Txt_Respuesta_Transbank_Decodificada.Text = _Pos
                        Lbl_Status.Text = UCase(Fx_Tabla1_Respuestas(_Resp(1)))

                        Return True

                    ElseIf _Resp.Length > 1 Then

                        _Resp = Split(_Pos, "0260")
                        _Pos = "0260" & _Resp(1)

                        _Resp = Split(_Pos, "|")

                        Dim _Respuesta As String = _Resp(1)

                        If _Respuesta.Length = 2 Then

                            If _Respuesta <> "00" Then
                                _Resp_dispositivo = "ACK"

                                comm.Pro_Mensaje = "06"
                                comm.Pro_Type = Clas_Comm_Manager.MessageType.Normal
                                comm.Sb_Escribir_Datos("06")  'WriteData(txtSend.Text)

                                Txt_Respuesta_Transbank_Decodificada.Text = _Pos

                                Lbl_Status.Text = UCase(Fx_Tabla1_Respuestas(_Resp(1)))

                                Return True

                            End If

                        End If

                    End If

                End If

            End If

        End If

    End Function

    Function Fx_Time_Anular_Ultima_Venta() As Boolean

        Dim _Pos As String = String.Empty

        Txt_Respuesta_Transbank_Codificada.Text = String.Empty
        Txt_Respuesta_Transbank_Codificada.Text = comm.Pro_Respuesta

        If Txt_Respuesta_Transbank_Codificada.Text.Contains("06") Then
            _Resp_dispositivo = "ACK"
        ElseIf Txt_Respuesta_Transbank_Codificada.Text.Contains("15") Then
            _Resp_dispositivo = "NAK"
            Return True
        End If

        Dim _Type = comm.Pro_Type

        If _Type = Clas_Comm_Manager.MessageType.Error Then
            _Error_Conexion = True
            _Resp_dispositivo = "ACK"
            Txt_Respuesta_Transbank_Decodificada.Text = Txt_Respuesta_Transbank_Codificada.Text
            Return True
        End If

        Txt_Respuesta_Transbank_Codificada.Text = Txt_Respuesta_Transbank_Codificada.Text.Replace(Chr(10), "")
        Txt_Respuesta_Transbank_Codificada.Text = Txt_Respuesta_Transbank_Codificada.Text.Replace(Chr(13), "")
        Txt_Respuesta_Transbank_Codificada.Text = Txt_Respuesta_Transbank_Codificada.Text.Replace("02", "")
        Txt_Respuesta_Transbank_Codificada.Text = Txt_Respuesta_Transbank_Codificada.Text.Replace("06", "")

        If Txt_Respuesta_Transbank_Codificada.Text.Contains("03") Then

            'If _Resp_dispositivo = "ACK" Then

            Txt_Respuesta_Transbank_Decodificada.Text = Fx_Decodificar_Respuesta_Transbank(Txt_Respuesta_Transbank_Codificada.Text)
            'Txt_Respuesta_Transbank_Decodificada.Text = Replace(Txt_Respuesta_Transbank_Decodificada.Text, _Ult_Respuesta, "")

            _Pos = Trim(Txt_Respuesta_Transbank_Decodificada.Text)

            _Pos = Replace(_Pos, Chr(10), "")
            _Pos = Replace(_Pos, Chr(13), "")
            _Pos = Replace(_Pos, Chr(3), "")

            _Pos = Replace(_Pos, "}", "")
            _Pos = Replace(_Pos, "{", "")

            _Pos = Trim(_Pos)

            Dim _Resp() As String

            If Not (_Pos Is Nothing) Then

                If _Pos.Contains("1210|") Then

                    _Resp = Split(_Pos, "1210")
                    _Pos = "1210" & _Resp(1)

                    _Resp = Split(_Pos, "|")

                    If _Resp.Length > 5 Then

                        _Resp_dispositivo = "ACK"

                        comm.Pro_Mensaje = "06"
                        comm.Pro_Type = Clas_Comm_Manager.MessageType.Normal
                        comm.Sb_Escribir_Datos("06")

                        Txt_Respuesta_Transbank_Decodificada.Text = _Pos

                        Lbl_Status.Text = UCase(Fx_Tabla1_Respuestas(_Resp(1)))

                        Return True

                    End If

                End If

            End If

        End If

    End Function

    Function Fx_Time_Cargar_Llaves() As Boolean

        Dim _Pos As String = String.Empty

        Txt_Respuesta_Transbank_Codificada.Text = String.Empty
        Txt_Respuesta_Transbank_Codificada.Text = comm.Pro_Respuesta

        If Txt_Respuesta_Transbank_Codificada.Text.Contains("06") Then
            _Resp_dispositivo = "ACK"
        ElseIf Txt_Respuesta_Transbank_Codificada.Text.Contains("15") Then
            _Resp_dispositivo = "NAK"
            Return True
        End If

        Dim _Type = comm.Pro_Type

        If _Type = Clas_Comm_Manager.MessageType.Error Then
            _Error_Conexion = True
            _Resp_dispositivo = "ACK"
            Txt_Respuesta_Transbank_Decodificada.Text = Txt_Respuesta_Transbank_Codificada.Text
            Return True
        End If

        Txt_Respuesta_Transbank_Codificada.Text = Txt_Respuesta_Transbank_Codificada.Text.Replace(Chr(10), "")
        Txt_Respuesta_Transbank_Codificada.Text = Txt_Respuesta_Transbank_Codificada.Text.Replace(Chr(13), "")
        Txt_Respuesta_Transbank_Codificada.Text = Txt_Respuesta_Transbank_Codificada.Text.Replace("02", "")
        Txt_Respuesta_Transbank_Codificada.Text = Txt_Respuesta_Transbank_Codificada.Text.Replace("06", "")

        If Txt_Respuesta_Transbank_Codificada.Text.Contains("03") Then

            Txt_Respuesta_Transbank_Decodificada.Text = Fx_Decodificar_Respuesta_Transbank(Txt_Respuesta_Transbank_Codificada.Text)

            _Pos = Trim(Txt_Respuesta_Transbank_Decodificada.Text)

            _Pos = Replace(_Pos, Chr(10), "")
            _Pos = Replace(_Pos, Chr(13), "")
            _Pos = Replace(_Pos, Chr(3), "")

            _Pos = Replace(_Pos, "}", "")
            _Pos = Replace(_Pos, "{", "")

            _Pos = Trim(_Pos)

            Dim _Resp() As String

            If Not (_Pos Is Nothing) Then

                If _Pos.Contains("0810|") Then

                    _Resp = Split(_Pos, "0810")
                    _Pos = "0810" & _Resp(1)

                    _Resp = Split(_Pos, "|")

                    If _Resp.Length > 3 Then

                        _Resp_dispositivo = "ACK"

                        comm.Pro_Mensaje = "06"
                        comm.Pro_Type = Clas_Comm_Manager.MessageType.Normal
                        comm.Sb_Escribir_Datos("06")

                        Txt_Respuesta_Transbank_Decodificada.Text = _Pos

                        Lbl_Status.Text = UCase(Fx_Tabla1_Respuestas(_Resp(1)))

                        Return True

                    End If

                End If

            End If

        End If

    End Function

    Function Fx_Time_Cierre() As Boolean

        Dim _Pos As String = String.Empty

        Txt_Respuesta_Transbank_Codificada.Text = String.Empty
        Txt_Respuesta_Transbank_Codificada.Text = comm.Pro_Respuesta

        If Txt_Respuesta_Transbank_Codificada.Text.Contains("06") Then
            _Resp_dispositivo = "ACK"
        ElseIf Txt_Respuesta_Transbank_Codificada.Text.Contains("15") Then
            _Resp_dispositivo = "NAK"
            Return True
        End If

        Dim _Type = comm.Pro_Type

        If _Type = Clas_Comm_Manager.MessageType.Error Then
            _Error_Conexion = True
            _Resp_dispositivo = "ACK"
            Txt_Respuesta_Transbank_Decodificada.Text = Txt_Respuesta_Transbank_Codificada.Text
            Return True
        End If

        Txt_Respuesta_Transbank_Codificada.Text = Txt_Respuesta_Transbank_Codificada.Text.Replace(Chr(10), "")
        Txt_Respuesta_Transbank_Codificada.Text = Txt_Respuesta_Transbank_Codificada.Text.Replace(Chr(13), "")
        Txt_Respuesta_Transbank_Codificada.Text = Txt_Respuesta_Transbank_Codificada.Text.Replace("02", "")
        Txt_Respuesta_Transbank_Codificada.Text = Txt_Respuesta_Transbank_Codificada.Text.Replace("06", "")

        If Txt_Respuesta_Transbank_Codificada.Text.Contains("03") Then

            Txt_Respuesta_Transbank_Decodificada.Text = Fx_Decodificar_Respuesta_Transbank(Txt_Respuesta_Transbank_Codificada.Text)

            _Pos = Trim(Txt_Respuesta_Transbank_Decodificada.Text)

            _Pos = Replace(_Pos, Chr(10), "")
            _Pos = Replace(_Pos, Chr(13), "")
            _Pos = Replace(_Pos, Chr(3), "")

            _Pos = Replace(_Pos, "}", "")
            _Pos = Replace(_Pos, "{", "")

            _Pos = Trim(_Pos)

            Dim _Resp() As String

            If Not (_Pos Is Nothing) Then

                If _Pos.Contains("0510|") Then

                    _Resp = Split(_Pos, "0510")
                    _Pos = "0510" & _Resp(1)

                    _Resp = Split(_Pos, "|")

                    If _Resp.Length >= 4 Then

                        _Resp_dispositivo = "ACK"

                        comm.Pro_Mensaje = "06"
                        comm.Pro_Type = Clas_Comm_Manager.MessageType.Normal
                        comm.Sb_Escribir_Datos("06")

                        Txt_Respuesta_Transbank_Decodificada.Text = _Pos

                        Lbl_Status.Text = UCase(Fx_Tabla1_Respuestas(_Resp(1)))

                        Return True

                    End If

                End If

            End If

        End If

    End Function

    Function Fx_Time_Polling(ByRef _Intentos As Integer) As Boolean

        Dim _Pos As String = String.Empty

        Txt_Respuesta_Transbank_Codificada.Text = String.Empty
        Txt_Respuesta_Transbank_Codificada.Text = comm.Pro_Respuesta

        If Txt_Respuesta_Transbank_Codificada.Text.Contains("06") Then
            _Resp_dispositivo = "ACK"
        ElseIf Txt_Respuesta_Transbank_Codificada.Text.Contains("15") Then
            _Resp_dispositivo = "NAK"
        End If

        Dim _Type = comm.Pro_Type

        If _Type = Clas_Comm_Manager.MessageType.Error Then
            _Error_Conexion = True
            _Resp_dispositivo = "NAK"
            Txt_Respuesta_Transbank_Decodificada.Text = Txt_Respuesta_Transbank_Codificada.Text
            Lbl_Status.Text = Txt_Respuesta_Transbank_Codificada.Text
            _Intentos += 1
            Return True
        Else
            _Error_Conexion = False
        End If

        Txt_Respuesta_Transbank_Decodificada.Text = Fx_Decodificar_Respuesta_Transbank(Txt_Respuesta_Transbank_Codificada.Text)
        Lbl_Status.Text = _Resp_dispositivo

        Return True

    End Function

    Function Fx_Time_Inicializacion() As Boolean

        Dim _Pos As String = String.Empty

        Txt_Respuesta_Transbank_Codificada.Text = String.Empty
        Txt_Respuesta_Transbank_Codificada.Text = comm.Pro_Respuesta

        If Txt_Respuesta_Transbank_Codificada.Text.Contains("06") Then
            _Resp_dispositivo = "ACK"
        ElseIf Txt_Respuesta_Transbank_Codificada.Text.Contains("15") Then
            _Resp_dispositivo = "NAK"
        End If

        Dim _Type = comm.Pro_Type

        If _Type = Clas_Comm_Manager.MessageType.Error Then
            _Error_Conexion = True
            _Resp_dispositivo = "ACK"
            Txt_Respuesta_Transbank_Decodificada.Text = Txt_Respuesta_Transbank_Codificada.Text
            Return True
        End If

        Txt_Respuesta_Transbank_Decodificada.Text = Fx_Decodificar_Respuesta_Transbank(Txt_Respuesta_Transbank_Codificada.Text)

        If Txt_Respuesta_Transbank_Decodificada.Text = "0260|0|7" Then
            _Resp_dispositivo = "ACK"
        End If

        Lbl_Status.Text = _Resp_dispositivo

        Return True

    End Function

    Function Fx_Time_Respuesta_Detalle_Totales() As Boolean

        Dim _Pos As String = String.Empty

        Txt_Respuesta_Transbank_Codificada.Text = String.Empty
        Txt_Respuesta_Transbank_Codificada.Text = comm.Pro_Respuesta

        If Txt_Respuesta_Transbank_Codificada.Text.Contains("06") Then
            _Resp_dispositivo = "ACK"
        ElseIf Txt_Respuesta_Transbank_Codificada.Text.Contains("15") Then
            _Resp_dispositivo = "NAK"
            Return True
        End If

        Dim _Type = comm.Pro_Type

        If _Type = Clas_Comm_Manager.MessageType.Error Then
            _Error_Conexion = True
            _Resp_dispositivo = "ACK"
            Txt_Respuesta_Transbank_Decodificada.Text = Txt_Respuesta_Transbank_Codificada.Text
            Return True
        End If

        Txt_Respuesta_Transbank_Codificada.Text = Txt_Respuesta_Transbank_Codificada.Text.Replace(Chr(10), "")
        Txt_Respuesta_Transbank_Codificada.Text = Txt_Respuesta_Transbank_Codificada.Text.Replace(Chr(13), "")
        Txt_Respuesta_Transbank_Codificada.Text = Txt_Respuesta_Transbank_Codificada.Text.Replace("02", "")
        Txt_Respuesta_Transbank_Codificada.Text = Txt_Respuesta_Transbank_Codificada.Text.Replace("06", "")

        If Txt_Respuesta_Transbank_Codificada.Text.Contains("03") Then

            Txt_Respuesta_Transbank_Decodificada.Text = Fx_Decodificar_Respuesta_Transbank(Txt_Respuesta_Transbank_Codificada.Text)

            _Pos = Trim(Txt_Respuesta_Transbank_Decodificada.Text)

            _Pos = Replace(_Pos, Chr(10), "")
            _Pos = Replace(_Pos, Chr(13), "")
            _Pos = Replace(_Pos, Chr(3), "")

            _Pos = Replace(_Pos, "}", "")
            _Pos = Replace(_Pos, "{", "")

            _Pos = Trim(_Pos)

            'Dim _Resp() As String

            If Not (_Pos Is Nothing) Then

                If _Pos.Contains("07") Then

                    '_Resp = Split(_Pos, "0510")
                    '_Pos = "0510" & _Resp(1)

                    '_Resp = Split(_Pos, "|")

                    'If _Resp.Length >= 4 Then

                    _Resp_dispositivo = "ACK"

                    comm.Pro_Mensaje = "06"
                    comm.Pro_Type = Clas_Comm_Manager.MessageType.Normal
                    comm.Sb_Escribir_Datos("06")

                    Txt_Respuesta_Transbank_Decodificada.Text = _Pos

                    Lbl_Status.Text = UCase(Fx_Tabla1_Respuestas("00"))

                    Return True

                    'End If

                End If

            End If

        End If

        Return True

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

    Public Function Fx_Hex2Bit(ByVal hex As String) As Long
        Dim bin As String = ""
        bin = Convert.ToString(Convert.ToInt32(hex, 16), 2)
        Return bin
    End Function

    Sub Sb_Enviar_ACK()

        comm.Pro_Mensaje = "06"
        comm.Pro_Type = Clas_Comm_Manager.MessageType.Normal
        comm.Sb_Escribir_Datos("06")  'WriteData(txtSend.Text)

    End Sub

    Sub Sb_Enviar_NAK()

        comm.Pro_Mensaje = "15"
        comm.Pro_Type = Clas_Comm_Manager.MessageType.Normal
        comm.Sb_Escribir_Datos("15")  'WriteData(txtSend.Text)

    End Sub

    Function Fx_Tabla1_Respuestas(ByVal _Respuesta As String) As String

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
            Case "16"
                Return "Error formato respuesta del host"
            Case "17"
                Return "Error en los 4 últimos dígitos."
            Case "18"
                Return "Menú invalido"
            Case "19"
                Return "ERROR_TARJ_DIST"
            Case "20"
                Return "Tarjeta inválida"
            Case "21"
                Return "Anulación no permitida"
            Case "22"
                Return "TIMEOUT"
            Case "24"
                Return "Impresora sin papel"
            Case "25"
                Return "Fecha inválida"
            Case "26"
                Return "Debe cargar llaves"
            Case "27"
                Return "Debe actualizar"
            Case "54"
                Return "Rechazado"
            Case "60"
                Return "Error en número de cuotas"
            Case "61"
                Return "Error en armado de solicitud"
            Case "62"
                Return "Problema con el pinpad interno"
            Case "65"
                Return "Error al procesar la respuesta del host"
            Case "67"
                Return "Superó número máximo de ventas, debe ejecutar cierre"
            Case "68"
                Return "Error genérico, falla al ingresar montos"
            Case "70"
                Return "Error de formato campo de boleta MAX 6"
            Case "71"
                Return "Error de largo campo de impresión"
            Case "72"
                Return "Error de monto venta, debe ser mayor que 0"
            Case "73"
                Return "Terminal ID no configurado"
            Case "74"
                Return "Debe ejecutar cierre"
            Case "75"
                Return "Comercio no tiene tarjetas configuradas"
            Case "76"
                Return "Superó número máximo de ventas, debe ejecutar cierre"
            Case "77"
                Return "Debe ejecutar cierre"
            Case "78"
                Return "Esperando leer tarjeta"
            Case "79"
                Return "Solicitando confirmar monto"
            Case "80"
                Return "Confirme el Monto"
            Case "81"
                Return "Ingrese Clave (PIN)"
            Case "82"
                Return "Procesando Transaccion"
            Case "90"
                Return "Inicialización Exitosa"
            Case "91"
                Return "Inicialización Fallida"
            Case "92"
                Return "Lector no conectado"
        End Select

    End Function

    Private Sub Tiempo_Cierre_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tiempo_Cierre.Tick
        Sb_Enviar_ACK()
        _Cierra_Usuario = True
        Me.Close()
    End Sub

    Private Sub Frm_Cashdro_Pago_Tarjeta_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed

        If _Accion = Enum_Accion.Detalle_Totales Then

            '2 Segundos de demora
            Thread.Sleep(3000)

            comm.Pro_Mensaje = "06"
            comm.Pro_Type = Clas_Comm_Manager.MessageType.Normal
            comm.Sb_Escribir_Datos("06")

        End If

        '2 Segundos de demora
        Thread.Sleep(2000)
        comm.Fx_Cerrar_Puerto()
    End Sub

    Private Sub Tiempo_Label_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tiempo_Label.Tick
        If Lbl_Status.Visible Then
            Lbl_Status.Visible = False
        Else
            Lbl_Status.Visible = True
        End If
    End Sub

    Private Sub Btn_Cancelar_Click(sender As Object, e As EventArgs) Handles Btn_Cancelar.Click
        _Cierra_Usuario = True
        Me.Close()
    End Sub

    Private Sub Bar2_DoubleClick(sender As Object, e As EventArgs) Handles Bar2.DoubleClick
        Btn_Cancelar.Visible = True
        Me.Refresh()
    End Sub

    Private Sub Lbl_Total_A_Pagar_DoubleClick(sender As Object, e As EventArgs) Handles Lbl_Total_A_Pagar.DoubleClick
        Btn_Cancelar.Visible = True
        Me.Refresh()
    End Sub

    Private Sub Lbl_Status_DoubleClick(sender As Object, e As EventArgs) Handles Lbl_Status.DoubleClick
        Btn_Cancelar.Visible = True
        Me.Refresh()
    End Sub
End Class
