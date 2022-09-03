'Imports Lib_Bakapp_VarClassFunc
Imports DevComponents.DotNetBar
Imports System.IO

Public Class Frm_Equipos_CashDro_Equipo

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Row_Estacion_CashDro As DataRow

    Dim _Grabar As Boolean
    Dim _NombreEquipo As String

    Dim comm As New Clas_Comm_Manager()

    Public ReadOnly Property Pro_Grabar() As Boolean
        Get
            Return _Grabar
        End Get
    End Property
    Public Property Pro_Row_Estacion_CashDro() As DataRow
        Get
            Return _Row_Estacion_CashDro
        End Get
        Set(ByVal value As DataRow)
            _Row_Estacion_CashDro = value
        End Set
    End Property

    Public Sub New(ByVal NombreEquipo As String)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        _NombreEquipo = NombreEquipo

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Estaciones_CashDro Where NombreEquipo = '" & _NombreEquipo & "'"
        _Row_Estacion_CashDro = _Sql.Fx_Get_DataRow(Consulta_sql)

        Sb_Color_Botones_Barra(Bar1)

    End Sub

    Private Sub Frm_Equipos_CashDro_Equipo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.Text = "CONFIGURACION LOCAL CAJERO AUTOMATICO,  TERMINAL: " & _NombreEquipo

        Sb_Cargar_ComboBoxEx_TablaDeCaracterizaciones(Cmb_Tbk_Puerto, "RS232_PUERTOS", "", True)
        Sb_Cargar_ComboBoxEx_TablaDeCaracterizaciones(Cmb_Tbk_Tasa_de_baudios, "RS232_BAUDIOS", "", True)
        Sb_Cargar_ComboBoxEx_TablaDeCaracterizaciones(Cmb_Tbk_Paridad, "RS232_PARIDAD", "", True)
        Sb_Cargar_ComboBoxEx_TablaDeCaracterizaciones(Cmb_Tbk_Bits_de_parada, "RS232_BITSPARADA", "", True)
        Sb_Cargar_ComboBoxEx_TablaDeCaracterizaciones(Cmb_Tbk_Bits_de_datos, "RS232_BISTDATOS", "", True)

        Cmb_Tbk_Puerto.SelectedValue = "01"
        Cmb_Tbk_Tasa_de_baudios.SelectedValue = "9600"
        Cmb_Tbk_Paridad.SelectedValue = "01"
        Cmb_Tbk_Bits_de_parada.SelectedValue = "01"
        Cmb_Tbk_Bits_de_datos.SelectedValue = "8"

        Sb_Leer_Row()

        AddHandler Rdb_Post_Autoservicio.CheckedChanged, AddressOf Me.Sb_Revisar_Post
        AddHandler Rdb_Post_Integrado.CheckedChanged, AddressOf Me.Sb_Revisar_Post

        Sb_Revisar_Post()

    End Sub

    Sub Sb_Leer_Row()

        With _Row_Estacion_CashDro

            Txt_NombreEquipo.Text = _NombreEquipo

            Consulta_sql = "Select * From TABFU Where KOFU = '" & .Item("Funcionario") & "'"
            Dim _Row_Funcionario As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

            If IsNothing(_Row_Funcionario) Then

                Txt_Funcionario.Tag = String.Empty

            Else

                Txt_Funcionario.Tag = _Row_Funcionario.Item("KOFU")
                Txt_Funcionario.Text = _Row_Funcionario.Item("KOFU").Trim & " - " & _Row_Funcionario.Item("NOKOFU").Trim

            End If

            Txt_Modalidad.Tag = .Item("Modalidad")
            Txt_Modalidad.Text = .Item("Modalidad")

            Txt_Ip_CashDro.Text = .Item("Ip_CashDro")
            Txt_Usuario_CashDro.Text = .Item("Usuario_CashDro")
            Txt_Contrasena_CashDro.Text = .Item("Contrasena_CashDro")

            Sw_EFV.Value = .Item("EFV")
            Sw_TJV.Value = .Item("TJV")
            Sw_NCV.Value = .Item("NCV")

            Input_Tiempo_Espera.Value = .Item("Tiempo_Espera")
            Chk_Fase_Prueba_Efectivo.Checked = .Item("Fase_Prueba")
            Chk_Fase_Prueba_Tarjeta.Checked = .Item("Fase_Prueba_Tarjeta")
            Chk_Fase_Prueba_Nota_De_Credito.Checked = .Item("Fase_Prueba_Nota_De_Credito")

            Txt_Directorio_Demonio.Text = .Item("Directorio_Demonio")
            Chk_Abrir_Demonio.Checked = .Item("Abrir_Demonio")

            Cmb_Tbk_Puerto.SelectedValue = .Item("Tbk_Puerto")
            Cmb_Tbk_Tasa_de_baudios.SelectedValue = .Item("Tbk_Tasa_de_baudios")
            Cmb_Tbk_Paridad.SelectedValue = .Item("Tbk_Paridad")
            Cmb_Tbk_Bits_de_parada.SelectedValue = .Item("Tbk_Bits_de_parada")
            Cmb_Tbk_Bits_de_datos.SelectedValue = .Item("Tbk_Bits_de_datos")

            Rdb_Tbk_Hexadecimal.Checked = .Item("Tbk_Hexadecimal")
            Rdb_Tbk_Texto.Checked = .Item("Tbk_Texto")

            Txt_Tbk_Post_Codigo_Comercio.Text = .Item("Tbk_Post_Codigo_Comercio")
            Txt_Tbk_Post_Terminal.Text = .Item("Tbk_Post_Terminal")
            Txt_Tbk_Post_Version.Text = .Item("Tbk_Post_Version")

            Lbl_Codigo_TJV_Credito.Tag = .Item("TJV_Emdp_Credito")
            Lbl_Codigo_TJV_Credito.Text = "Código de banco para tarjeta de CREDITO (" & Lbl_Codigo_TJV_Credito.Tag & ")"

            Lbl_Codigo_TJV_Debito.Tag = .Item("TJV_Emdp_Debito")
            Lbl_Codigo_TJV_Debito.Text = "Código de banco para tarjeta de DEBITO (" & Lbl_Codigo_TJV_Debito.Tag & ")"

            Lbl_Impresora_Predeterminada.Text = .Item("Impresora_Predeterminada")

            If Not .Item("Post_Autoservicio") And Not .Item("Post_Integrado") Then
                .Item("Post_Autoservicio") = True
            End If

            Rdb_Post_Autoservicio.Checked = .Item("Post_Autoservicio")
            Rdb_Post_Integrado.Checked = .Item("Post_Integrado")

            Chk_Usar_Post_Integrado.Checked = .Item("Usar_Post_Integrado")

        End With

    End Sub

    Sub Sb_Grabar()

        Dim _Reg = _Sql.Fx_Cuenta_Registros("MAEUS", "KOUS = '" & Txt_Funcionario.Tag & "' And KOOP Like 'MO-" & Txt_Modalidad.Tag & "'")

        If Rdb_Post_Autoservicio.Checked Then

            If Not CBool(_Reg) Then

                MessageBoxEx.Show(Me, "El usuario " & Txt_Funcionario.Text & " no tiene permiso para trabajar con esta modalidad: " & Txt_Modalidad.Tag,
                                  "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return

            End If

            If String.IsNullOrEmpty(Lbl_Codigo_TJV_Credito.Tag) Then
                MessageBoxEx.Show(Me, "Debe seleccionar un código para la tarjeta de crédito", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return
            End If

            If String.IsNullOrEmpty(Lbl_Codigo_TJV_Debito.Tag) Then
                MessageBoxEx.Show(Me, "Debe seleccionar un código para la tarjeta de debito", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return
            End If

        End If

        Consulta_sql = "Delete " & _Global_BaseBk & "Zw_Estaciones_CashDro Where NombreEquipo = '" & _NombreEquipo & "'" &
                        vbCrLf &
                        vbCrLf &
                       "Insert Into " & _Global_BaseBk & "Zw_Estaciones_CashDro (NombreEquipo,Funcionario,Modalidad,Ip_CashDro,Usuario_CashDro," &
                       "Contrasena_CashDro,EFV,TJV,NCV,Tiempo_Espera,Fase_Prueba,Directorio_Demonio,Abrir_Demonio," &
                       "Tbk_Puerto,Tbk_Tasa_de_baudios,Tbk_Paridad,Tbk_Bits_de_parada,Tbk_Bits_de_datos,Tbk_Hexadecimal," &
                       "Tbk_Texto,Tbk_Post_Codigo_Comercio,Tbk_Post_Terminal,Tbk_Post_Version,Impresora_Predeterminada," &
                       "Fase_Prueba_Tarjeta,Fase_Prueba_Nota_De_Credito,TJV_Emdp_Credito,TJV_Emdp_Debito,Post_Autoservicio," &
                       "Post_Integrado,Usar_Post_Integrado) Values " &
                       vbCrLf &
                       "('" & _NombreEquipo & "','" & Txt_Funcionario.Tag & "','" & Txt_Modalidad.Tag &
                       "','" & Txt_Ip_CashDro.Text & "','" & Txt_Usuario_CashDro.Text & "','" & Txt_Contrasena_CashDro.Text &
                       "'," & CInt(Sw_EFV.Value) * -1 & "," & CInt(Sw_TJV.Value) * -1 & "," & CInt(Sw_NCV.Value) * -1 &
                       "," & Input_Tiempo_Espera.Value & "," & CInt(Chk_Fase_Prueba_Efectivo.Checked) * -1 &
                       ",'" & Txt_Directorio_Demonio.Text & "'," & CInt(Chk_Abrir_Demonio.Checked) * -1 & ",'" & Cmb_Tbk_Puerto.SelectedValue &
                       "','" & Cmb_Tbk_Tasa_de_baudios.SelectedValue & "','" & Cmb_Tbk_Paridad.SelectedValue &
                       "','" & Cmb_Tbk_Bits_de_parada.SelectedValue & "','" & Cmb_Tbk_Bits_de_datos.SelectedValue &
                       "'," & CInt(Rdb_Tbk_Hexadecimal.Checked) * -1 & "," & CInt(Rdb_Tbk_Texto.Checked) * -1 &
                       ",'" & Trim(Txt_Tbk_Post_Codigo_Comercio.Text) & "','" & Trim(Txt_Tbk_Post_Terminal.Text) &
                       "','" & Trim(Txt_Tbk_Post_Version.Text) & "','" & Lbl_Impresora_Predeterminada.Text &
                       "'," & CInt(Chk_Fase_Prueba_Tarjeta.Checked) * -1 & "," & CInt(Chk_Fase_Prueba_Nota_De_Credito.Checked) * -1 &
                       ",'" & Lbl_Codigo_TJV_Credito.Tag & "','" & Lbl_Codigo_TJV_Debito.Tag &
                       "'," & Convert.ToInt32(Rdb_Post_Autoservicio.Checked) &
                       "," & Convert.ToInt32(Rdb_Post_Integrado.Checked) &
                       "," & Convert.ToInt32(Chk_Usar_Post_Integrado.Checked) & ")"

        If _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql) Then

            _Grabar = True
            Me.Close()

        End If

    End Sub

    Private Sub Frm_Equipos_CashDro_Equipo_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub Btn_Grabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Grabar.Click
        Sb_Grabar()
    End Sub

    Private Sub Btn_Directorio_Demonio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Directorio_Demonio.Click

        Dim _FolderBrowserDialog As New FolderBrowserDialog

        With _FolderBrowserDialog

            .Reset() ' resetea  

            ' leyenda  
            .Description = " Seleccionar una carpeta "
            ' Path " Mis documentos "  
            .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)

            ' deshabilita el botón " crear nueva carpeta "  
            .ShowNewFolderButton = False
            '.RootFolder = Environment.SpecialFolder.Desktop  
            '.RootFolder = Environment.SpecialFolder.StartMenu  

            Dim ret As DialogResult = .ShowDialog ' abre el diálogo  

            ' si se presionó el botón aceptar ...  
            If ret = Windows.Forms.DialogResult.OK Then

                Dim nFiles As ObjectModel.ReadOnlyCollection(Of String)

                nFiles = My.Computer.FileSystem.GetFiles(.SelectedPath)

                Dim _Directorio_Seleccionado As String = .SelectedPath

                If File.Exists(_Directorio_Seleccionado & "\BakApp_Demonio.exe") Then
                    Dim _NombreEquipo As String = _Global_Row_EstacionBk.Item("NombreEquipo")

                    Consulta_sql = "Update " & _Global_BaseBk & "Zw_Estaciones_CashDro Set Directorio_Demonio = '" & _Directorio_Seleccionado & "'" & vbCrLf &
                                   "Where NombreEquipo = '" & _NombreEquipo & "'"

                    If _Sql.Ej_consulta_IDU(Consulta_sql) Then
                        Txt_Directorio_Demonio.Text = _Directorio_Seleccionado
                    Else
                        Txt_Directorio_Demonio.Text = String.Empty
                    End If
                Else
                    MessageBoxEx.Show(Me,
                    "No se encontro el archivo BakApp_Demonio.exe en el directorio (" & _Directorio_Seleccionado & ")",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If
            End If

            .Dispose()

        End With

    End Sub

    Function Fx_Time_Out(ByVal comm As Clas_Comm_Manager) As Boolean

        Dim _Respuesta_Transbank_Codificada
        Dim _Respuesta_Transbank_Decodificada

        Dim _Clas_Transbank As Clas_Transbank

        With _Clas_Transbank

            Dim _Resp_dispositivo = .Pro_Resp_dispositivo

            _Respuesta_Transbank_Codificada = String.Empty
            _Respuesta_Transbank_Codificada = comm.Pro_Respuesta

            If _Respuesta_Transbank_Codificada.Contains("06") Then
                _Resp_dispositivo = "ACK"
                Lbl_Status.Text = "INSERTE Y RETIRE TARJETA"
            ElseIf _Respuesta_Transbank_Codificada.Contains("15") Then
                _Resp_dispositivo = "NAK"
                Lbl_Status.Text = "TRANSBANK...NAK"
            End If

            _Respuesta_Transbank_Codificada = _Respuesta_Transbank_Codificada.Replace(Chr(10), "")
            _Respuesta_Transbank_Codificada = _Respuesta_Transbank_Codificada.Replace(Chr(13), "")
            _Respuesta_Transbank_Codificada = _Respuesta_Transbank_Codificada.Replace("02", "")
            _Respuesta_Transbank_Codificada = _Respuesta_Transbank_Codificada.Replace("06", "")

            If _Respuesta_Transbank_Codificada.Contains("03") Then

                If _Resp_dispositivo = "ACK" Then

                    '_Ult_Respuesta = Replace(_Ult_Respuesta, "", "")

                    _Respuesta_Transbank_Decodificada = .Fx_Decodificar_Respuesta_Transbank(_Respuesta_Transbank_Codificada)
                    _Respuesta_Transbank_Decodificada = Replace(_Respuesta_Transbank_Decodificada, .Pro_Ult_Respuesta, "")

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

                            ' RESPUESTA TRANSACCION VENTA

                            _Resp = Split(_Pos, "0210")
                            _Pos = "0210" & _Resp(1)

                            _Pos = Replace(_Pos, "~", "")
                            _Pos = Replace(_Pos, "y", "")

                            _Resp = Split(_Pos, "|")

                            _Respuesta_Transbank_Decodificada = _Pos
                            Lbl_Status.Text = UCase(.Fx_Tabla1_Respuestas(_Resp(1)))

                            If _Resp(1) = "00" Then
                                '_Pagado = True
                            ElseIf _Resp(1) = "07" Then
                                '_Cerrar_Formulario = True
                            End If

                            comm.Pro_Mensaje = "06"
                            comm.Pro_Type = Clas_Comm_Manager.MessageType.Normal
                            comm.Sb_Escribir_Datos("06")  'WriteData(txtSend.Text)

                            Return True

                        ElseIf _Pos.Contains("0260|") Then

                            ' RESPUESTA DATOS ULTIMAVENTA

                            _Resp = Split(_Pos, "0260")
                            _Pos = "0260" & _Resp(1)

                            _Resp = Split(_Pos, "|")

                            comm.Pro_Mensaje = "06"
                            comm.Pro_Type = Clas_Comm_Manager.MessageType.Normal
                            comm.Sb_Escribir_Datos("06")  'WriteData(txtSend.Text)

                            _Respuesta_Transbank_Decodificada = _Pos

                            Lbl_Status.Text = UCase(.Fx_Tabla1_Respuestas(_Resp(1)))
                            ' _Cerrar_Formulario = True
                            comm.Fx_Cerrar_Puerto()

                            Return True

                        ElseIf _Pos.Contains("0710|") Then

                            '  RESPUESTA DETALLE DE TOTALES

                            _Resp = Split(_Pos, "0710")
                            _Pos = "0710" & _Resp(1)

                            _Resp = Split(_Pos, "|")

                            comm.Pro_Mensaje = "06"
                            comm.Pro_Type = Clas_Comm_Manager.MessageType.Normal
                            comm.Sb_Escribir_Datos("06")  'WriteData(txtSend.Text)

                            _Respuesta_Transbank_Decodificada = _Pos

                            Lbl_Status.Text = UCase(.Fx_Tabla1_Respuestas(_Resp(1)))

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

                            Lbl_Status.Text = UCase(.Fx_Tabla1_Respuestas(_Estatus))

                            .Pro_Confirmar_Monto = False
                            .Pro_Ingrese_Clave = True

                        End If

                    End If

                End If

            End If

        End With

    End Function

    Private Sub Btn_Probar_Transbank_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Probar_Transbank.Click

        _Row_Estacion_CashDro.Item("Tbk_Puerto") = Cmb_Tbk_Puerto.Text
        _Row_Estacion_CashDro.Item("Tbk_Paridad") = Cmb_Tbk_Paridad.Text
        _Row_Estacion_CashDro.Item("Tbk_Bits_de_parada") = Cmb_Tbk_Bits_de_parada.Text
        _Row_Estacion_CashDro.Item("Tbk_Bits_de_datos") = Cmb_Tbk_Bits_de_datos.Text
        _Row_Estacion_CashDro.Item("Tbk_Tasa_de_baudios") = Cmb_Tbk_Tasa_de_baudios.Text
        'comm.Pro_RichTextBox = rtbDisplay

        If Rdb_Tbk_Hexadecimal.Checked() Then
            comm.Pro_CurrentTransmissionType = Clas_Comm_Manager.TransmissionType.Hex
        Else
            comm.Pro_CurrentTransmissionType = Clas_Comm_Manager.TransmissionType.Text
        End If


        Dim _Monto As String = InputBox("Prom", "Title", "")

        _Monto = Val(_Monto)

        Dim _Traer_Voucher As Boolean

        If _Row_Estacion_CashDro.Item("Post_Autoservicio") Then

            If MessageBoxEx.Show(Me, "¿Desea traer datos del Voucher desde el dispositivo?", "Traer Voucher",
                                         MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                _Traer_Voucher = True
            End If

        End If

        If _Monto > 0 Then

            Dim Fm As New Frm_Cashdro_Pago_Tarjeta(_Row_Estacion_CashDro, "0",
                                                   _Monto, Frm_Cashdro_Pago_Tarjeta.Enum_Accion.Transaccion_Venta, _Traer_Voucher)
            Fm.ShowDialog(Me)

            Dim _Pagado As Boolean = Fm.Pro_Pagado
            Dim _Comando_Transaccion As String = Fm.Pro_Comando_Transaccion
            Dim _Respuesta As String = Fm.Pro_Respuesta_Decodificada
            Dim _Status As String = Fm.Pro_Status

            Fm.Dispose()

            MessageBoxEx.Show(Me, _Respuesta, _Status)
            Lbl_Status.Text = "Prueba: " & _Status & "-" & _Respuesta
            Clipboard.Clear()

            Dim _Clipboard As String
            _Clipboard = "Comando enviado: " & _Comando_Transaccion & vbCrLf &
                         "Respuesta: " & _Respuesta
            If Not String.IsNullOrEmpty(_Respuesta) Then Clipboard.SetText(_Clipboard)

        End If

    End Sub


    Private Sub Btn_Anular_Ultima_Transaccion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Anular_Transaccion.Click

        _Row_Estacion_CashDro.Item("Tbk_Puerto") = Cmb_Tbk_Puerto.Text
        _Row_Estacion_CashDro.Item("Tbk_Paridad") = Cmb_Tbk_Paridad.Text
        _Row_Estacion_CashDro.Item("Tbk_Bits_de_parada") = Cmb_Tbk_Bits_de_parada.Text
        _Row_Estacion_CashDro.Item("Tbk_Bits_de_datos") = Cmb_Tbk_Bits_de_datos.Text
        _Row_Estacion_CashDro.Item("Tbk_Tasa_de_baudios") = Cmb_Tbk_Tasa_de_baudios.Text

        If Rdb_Tbk_Hexadecimal.Checked() Then
            comm.Pro_CurrentTransmissionType = Clas_Comm_Manager.TransmissionType.Hex
        Else
            comm.Pro_CurrentTransmissionType = Clas_Comm_Manager.TransmissionType.Text
        End If

        Dim _NroDocumento As String = "0"

        ' Envio a Post Integrado
        If Rdb_Post_Integrado.Checked Then

            _NroDocumento = String.Empty

            Dim _Aceptar As Boolean = InputBox_Bk(Me, "Ingrese número de transacción para anular", "Anular",
                                                  _NroDocumento, False,,, True, _Tipo_Imagen.Texto,, _Tipo_Caracter.Cualquier_caracter, False)

            If Not _Aceptar Then
                Return
            End If

        End If


        Dim Fm As New Frm_Cashdro_Pago_Tarjeta(_Row_Estacion_CashDro, _NroDocumento,
                                                   0, Frm_Cashdro_Pago_Tarjeta.Enum_Accion.Anular_Venta, False)
        Fm.ShowDialog(Me)

        Dim _Pagado As Boolean = Fm.Pro_Pagado
        Dim _Comando_Transaccion As String = Fm.Pro_Comando_Transaccion
        Dim _Respuesta As String = Fm.Pro_Respuesta_Decodificada
        Dim _Status As String = Fm.Pro_Status

        Fm.Dispose()

        MessageBoxEx.Show(Me, _Respuesta, _Status)
        Lbl_Status.Text = "Prueba: " & _Status & "-" & _Respuesta
        Clipboard.Clear()

        Dim _Clipboard As String
        _Clipboard = "Comando enviado: " & _Comando_Transaccion & vbCrLf &
                     "Respuesta: " & _Respuesta
        If Not String.IsNullOrEmpty(_Respuesta) Then Clipboard.SetText(_Clipboard)

    End Sub


    Private Sub Btn_Cargar_Llaves_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Cargar_Llaves.Click

        _Row_Estacion_CashDro.Item("Tbk_Puerto") = Cmb_Tbk_Puerto.Text
        _Row_Estacion_CashDro.Item("Tbk_Paridad") = Cmb_Tbk_Paridad.Text
        _Row_Estacion_CashDro.Item("Tbk_Bits_de_parada") = Cmb_Tbk_Bits_de_parada.Text
        _Row_Estacion_CashDro.Item("Tbk_Bits_de_datos") = Cmb_Tbk_Bits_de_datos.Text
        _Row_Estacion_CashDro.Item("Tbk_Tasa_de_baudios") = Cmb_Tbk_Tasa_de_baudios.Text

        If Rdb_Tbk_Hexadecimal.Checked() Then
            comm.Pro_CurrentTransmissionType = Clas_Comm_Manager.TransmissionType.Hex
        Else
            comm.Pro_CurrentTransmissionType = Clas_Comm_Manager.TransmissionType.Text
        End If

        Dim Fm As New Frm_Cashdro_Pago_Tarjeta(_Row_Estacion_CashDro, "0",
                                                   0, Frm_Cashdro_Pago_Tarjeta.Enum_Accion.Cargar_Llaves, False)
        Fm.ShowDialog(Me)

        Dim _Pagado As Boolean = Fm.Pro_Pagado
        Dim _Comando_Transaccion As String = Fm.Pro_Comando_Transaccion
        Dim _Respuesta As String = Fm.Pro_Respuesta_Decodificada
        Dim _Status As String = Fm.Pro_Status

        Fm.Dispose()

        MessageBoxEx.Show(Me, _Respuesta, _Status)
        Lbl_Status.Text = "Prueba: " & _Status & "-" & _Respuesta
        Clipboard.Clear()

        Dim _Clipboard As String
        _Clipboard = "Comando enviado: " & _Comando_Transaccion & vbCrLf &
                     "Respuesta: " & _Respuesta
        If Not String.IsNullOrEmpty(_Respuesta) Then Clipboard.SetText(_Clipboard)

    End Sub

    Private Sub Btn_Cierre_Terminal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Cierre_Terminal.Click

        _Row_Estacion_CashDro.Item("Tbk_Puerto") = Cmb_Tbk_Puerto.Text
        _Row_Estacion_CashDro.Item("Tbk_Paridad") = Cmb_Tbk_Paridad.Text
        _Row_Estacion_CashDro.Item("Tbk_Bits_de_parada") = Cmb_Tbk_Bits_de_parada.Text
        _Row_Estacion_CashDro.Item("Tbk_Bits_de_datos") = Cmb_Tbk_Bits_de_datos.Text
        _Row_Estacion_CashDro.Item("Tbk_Tasa_de_baudios") = Cmb_Tbk_Tasa_de_baudios.Text

        If Rdb_Tbk_Hexadecimal.Checked() Then
            comm.Pro_CurrentTransmissionType = Clas_Comm_Manager.TransmissionType.Hex
        Else
            comm.Pro_CurrentTransmissionType = Clas_Comm_Manager.TransmissionType.Text
        End If

        Dim Fm As New Frm_Cashdro_Pago_Tarjeta(_Row_Estacion_CashDro, "0",
                                                   0, Frm_Cashdro_Pago_Tarjeta.Enum_Accion.Cerrar_Terminal, False)
        Fm.ShowDialog(Me)

        Dim _Pagado As Boolean = Fm.Pro_Pagado
        Dim _Comando_Transaccion As String = Fm.Pro_Comando_Transaccion
        Dim _Respuesta As String = Fm.Pro_Respuesta_Decodificada
        Dim _Status As String = Fm.Pro_Status

        Fm.Dispose()

        MessageBoxEx.Show(Me, _Respuesta, _Status)
        Lbl_Status.Text = "Prueba: " & _Status & "-" & _Respuesta
        Clipboard.Clear()

        Dim _Clipboard As String
        _Clipboard = "Comando enviado: " & _Comando_Transaccion & vbCrLf &
                     "Respuesta: " & _Respuesta
        If Not String.IsNullOrEmpty(_Respuesta) Then Clipboard.SetText(_Clipboard)

        Dim _Log_Datos_Ultima_Venta_Transbank = Replace(_Respuesta, "'", "")

        Dim _Datos_Tarjeta = Split(_Log_Datos_Ultima_Venta_Transbank, "|")
        Dim _Largo As Integer = CType(_Datos_Tarjeta, System.Array).Length

        Try

            Dim _Codigo_Respuesta = _Datos_Tarjeta(1)
            Dim _Voucher As String

            If _Codigo_Respuesta = "00" Then
                _Voucher = _Datos_Tarjeta(4)
                If MessageBoxEx.Show(Me, "¿Desea imprimir el voucher?", "Imprimir Voucher", MessageBoxButtons.YesNo,
                                 MessageBoxIcon.Question) = DialogResult.Yes Then
                    Dim _Cl_Voucher As New Clas_Imprimir_Voucher()
                    _Cl_Voucher.Fx_Imprimir_Voucher2(Me, _Voucher, Lbl_Impresora_Predeterminada.Text)
                End If
            End If
        Catch ex As Exception
            MessageBoxEx.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub


    Private Sub Btn_Pooling_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Pooling.Click

        _Row_Estacion_CashDro.Item("Tbk_Puerto") = Cmb_Tbk_Puerto.Text
        _Row_Estacion_CashDro.Item("Tbk_Paridad") = Cmb_Tbk_Paridad.Text
        _Row_Estacion_CashDro.Item("Tbk_Bits_de_parada") = Cmb_Tbk_Bits_de_parada.Text
        _Row_Estacion_CashDro.Item("Tbk_Bits_de_datos") = Cmb_Tbk_Bits_de_datos.Text
        _Row_Estacion_CashDro.Item("Tbk_Tasa_de_baudios") = Cmb_Tbk_Tasa_de_baudios.Text

        If Rdb_Tbk_Hexadecimal.Checked() Then
            comm.Pro_CurrentTransmissionType = Clas_Comm_Manager.TransmissionType.Hex
        Else
            comm.Pro_CurrentTransmissionType = Clas_Comm_Manager.TransmissionType.Text
        End If

        Dim Fm As New Frm_Cashdro_Pago_Tarjeta(_Row_Estacion_CashDro, "0",
                                                   0, Frm_Cashdro_Pago_Tarjeta.Enum_Accion.Pooling, False)
        Fm.ShowDialog(Me)

        Dim _Pagado As Boolean = Fm.Pro_Pagado
        Dim _Comando_Transaccion As String = Fm.Pro_Comando_Transaccion
        Dim _Respuesta As String = Fm.Pro_Respuesta_Decodificada
        Dim _Status As String = Fm.Pro_Status

        Fm.Dispose()

        MessageBoxEx.Show(Me, _Respuesta, _Status)
        Lbl_Status.Text = "Prueba: " & _Status & "-" & _Respuesta
        Clipboard.Clear()

        Dim _Clipboard As String
        _Clipboard = "Comando enviado: " & _Comando_Transaccion & vbCrLf &
                     "Respuesta: " & _Respuesta
        If Not String.IsNullOrEmpty(_Respuesta) Then Clipboard.SetText(_Clipboard)

    End Sub

    Private Sub Btn_Datos_Ultima_Venta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Datos_Ultima_Venta.Click

        _Row_Estacion_CashDro.Item("Tbk_Puerto") = Cmb_Tbk_Puerto.Text
        _Row_Estacion_CashDro.Item("Tbk_Paridad") = Cmb_Tbk_Paridad.Text
        _Row_Estacion_CashDro.Item("Tbk_Bits_de_parada") = Cmb_Tbk_Bits_de_parada.Text
        _Row_Estacion_CashDro.Item("Tbk_Bits_de_datos") = Cmb_Tbk_Bits_de_datos.Text
        _Row_Estacion_CashDro.Item("Tbk_Tasa_de_baudios") = Cmb_Tbk_Tasa_de_baudios.Text

        If Rdb_Tbk_Hexadecimal.Checked() Then
            comm.Pro_CurrentTransmissionType = Clas_Comm_Manager.TransmissionType.Hex
        Else
            comm.Pro_CurrentTransmissionType = Clas_Comm_Manager.TransmissionType.Text
        End If

        Dim _Traer_Voucher As Boolean

        If _Row_Estacion_CashDro.Item("Post_Autoservicio") Then

            If MessageBoxEx.Show(Me, "¿Desea traer datos del Voucher desde el dispositivo?", "Traer Voucher",
                                         MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                _Traer_Voucher = True
            End If

        End If

        Dim Fm As New Frm_Cashdro_Pago_Tarjeta(_Row_Estacion_CashDro, "0",
                                                   0, Frm_Cashdro_Pago_Tarjeta.Enum_Accion.Datos_Ultima_Venta, _Traer_Voucher)
        Fm.ShowDialog(Me)

        Dim _Pagado As Boolean = Fm.Pro_Pagado
        Dim _Comando_Transaccion As String = Fm.Pro_Comando_Transaccion
        Dim _Respuesta As String = Fm.Pro_Respuesta_Decodificada
        Dim _Status As String = Fm.Pro_Status

        Fm.Dispose()

        MessageBoxEx.Show(Me, _Respuesta, _Status)
        Lbl_Status.Text = "Prueba: " & _Status & "-" & _Respuesta
        Clipboard.Clear()

        Dim _Clipboard As String
        _Clipboard = "Comando enviado: " & _Comando_Transaccion & vbCrLf &
                     "Respuesta: " & _Respuesta
        If Not String.IsNullOrEmpty(_Respuesta) Then Clipboard.SetText(_Clipboard)


        Dim _Log_Datos_Ultima_Venta_Transbank = Replace(_Respuesta, "'", "")

        Dim _Datos_Tarjeta = Split(_Log_Datos_Ultima_Venta_Transbank, "|")
        Dim _Largo As Integer = CType(_Datos_Tarjeta, System.Array).Length

        Try

            Dim _Codigo_Respuesta = _Datos_Tarjeta(1)
            Dim _Voucher As String

            If _Codigo_Respuesta = "00" Then
                _Voucher = _Datos_Tarjeta(15)
                If MessageBoxEx.Show(Me, "¿Desea imprimir el voucher?", "Imprimir Voucher", MessageBoxButtons.YesNo,
                                 MessageBoxIcon.Question) = DialogResult.Yes Then
                    Dim _Cl_Voucher As New Clas_Imprimir_Voucher()
                    _Cl_Voucher.Fx_Imprimir_Voucher2(Me, _Voucher, Lbl_Impresora_Predeterminada.Text)
                End If
            End If
        Catch ex As Exception
            MessageBoxEx.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub

    Private Sub Btn_Inicializacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Inicializacion.Click

        _Row_Estacion_CashDro.Item("Tbk_Puerto") = Cmb_Tbk_Puerto.Text
        _Row_Estacion_CashDro.Item("Tbk_Paridad") = Cmb_Tbk_Paridad.Text
        _Row_Estacion_CashDro.Item("Tbk_Bits_de_parada") = Cmb_Tbk_Bits_de_parada.Text
        _Row_Estacion_CashDro.Item("Tbk_Bits_de_datos") = Cmb_Tbk_Bits_de_datos.Text
        _Row_Estacion_CashDro.Item("Tbk_Tasa_de_baudios") = Cmb_Tbk_Tasa_de_baudios.Text

        If Rdb_Tbk_Hexadecimal.Checked() Then
            comm.Pro_CurrentTransmissionType = Clas_Comm_Manager.TransmissionType.Hex
        Else
            comm.Pro_CurrentTransmissionType = Clas_Comm_Manager.TransmissionType.Text
        End If

        Dim _Acccion As Frm_Cashdro_Pago_Tarjeta.Enum_Accion

        If Rdb_Post_Autoservicio.Checked Then _Acccion = Frm_Cashdro_Pago_Tarjeta.Enum_Accion.Inicializar
        If Rdb_Post_Integrado.Checked Then _Acccion = Frm_Cashdro_Pago_Tarjeta.Enum_Accion.Detalle_Totales

        Dim Fm As New Frm_Cashdro_Pago_Tarjeta(_Row_Estacion_CashDro, "0",
                                                   0, _Acccion, False)
        Fm.ShowDialog(Me)

        Dim _Pagado As Boolean = Fm.Pro_Pagado
        Dim _Comando_Transaccion As String = Fm.Pro_Comando_Transaccion
        Dim _Respuesta As String = Fm.Pro_Respuesta_Decodificada
        Dim _Status As String = Fm.Pro_Status

        Fm.Dispose()

        MessageBoxEx.Show(Me, _Respuesta, _Status)

        Lbl_Status.Text = "Prueba: " & _Status & "-" & _Respuesta
        Clipboard.Clear()

        Dim _Clipboard As String
        _Clipboard = "Comando enviado: " & _Comando_Transaccion & vbCrLf &
                     "Respuesta: " & _Respuesta
        If Not String.IsNullOrEmpty(_Respuesta) Then Clipboard.SetText(_Clipboard)

    End Sub

    Private Sub Btn_Imprimir_Detalle_Terminal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Imprimir_Detalle_Terminal.Click

        Dim Fm As New Frm_Imprimir_Cierres_Transbank(_NombreEquipo, Frm_Imprimir_Cierres_Transbank._Enum_Tipo_Cierre.Transbank)
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Private Sub Btn_Cambiar_Impresora_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Cambiar_Impresora.Click

        Dim Fm As New Frm_Seleccionar_Impresoras(Lbl_Impresora_Predeterminada.Text)
        Fm.ShowDialog(Me)
        If Fm.Pro_Aceptar Then
            Lbl_Impresora_Predeterminada.Text = Trim(Fm.Pro_Impresora_Seleccionada)
        End If
        Fm.Dispose()

    End Sub

    Private Sub Btn_Codigo_TJV_Credito_Click(sender As Object, e As EventArgs) Handles Btn_Codigo_TJV_Credito.Click

        Dim Fm As New Frm_Seleccionar_Emisor_Doc_Pago(Frm_Pagos_Seleccionar_CH_TJ.Enum_Tipo_Pago.TJ)
        Fm.ShowDialog(Me)

        If Not (Fm.Pro_Row_Tabendp Is Nothing) Then

            Lbl_Codigo_TJV_Credito.Tag = Fm.Pro_Row_Tabendp.Item("KOENDP").ToString.Trim
            Lbl_Codigo_TJV_Credito.Text = "Código de banco para tarjeta de CREDITO (" & Lbl_Codigo_TJV_Credito.Tag & ")"

        End If

        Fm.Dispose()

    End Sub

    Private Sub Btn_Codigo_TJV_Debito_Click(sender As Object, e As EventArgs) Handles Btn_Codigo_TJV_Debito.Click

        Dim Fm As New Frm_Seleccionar_Emisor_Doc_Pago(Frm_Pagos_Seleccionar_CH_TJ.Enum_Tipo_Pago.TJ)
        Fm.ShowDialog(Me)

        If Not (Fm.Pro_Row_Tabendp Is Nothing) Then

            Lbl_Codigo_TJV_Debito.Tag = Fm.Pro_Row_Tabendp.Item("KOENDP").ToString.Trim
            Lbl_Codigo_TJV_Debito.Text = "Código de banco para tarjeta de DEBITO (" & Lbl_Codigo_TJV_Debito.Tag & ")"

        End If

        Fm.Dispose()

    End Sub

    Private Sub Btn_Buscar_Funcionario_Click(sender As Object, e As EventArgs) Handles Btn_Buscar_Funcionario.Click

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        _Filtrar.Pro_Nombre_Encabezado_Informe = "FUNCIONARIOS DE LA EMPRESA"

        If _Filtrar.Fx_Filtrar(Nothing,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Funcionarios_Random, "",
                               Nothing, False, True) Then

            Dim _Tbl_Transportista As DataTable = _Filtrar.Pro_Tbl_Filtro

            Dim _Row As DataRow = _Tbl_Transportista.Rows(0)

            Dim _Kofu = _Row.Item("Codigo").ToString.Trim
            Dim _Nokofu = _Row.Item("Descripcion").ToString.Trim

            Txt_Funcionario.Tag = _Kofu
            Txt_Funcionario.Text = _Kofu.Trim & " - " & _Nokofu.Trim

        End If

    End Sub

    Private Sub Btn_Buscar_Modalidades_Click(sender As Object, e As EventArgs) Handles Btn_Buscar_Modalidades.Click

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        _Filtrar.Pro_Nombre_Encabezado_Informe = "MODALIDADES DE LA EMPRESA"

        _Filtrar.Tabla = "CONFIEST"
        _Filtrar.Campo = "MODALIDAD"
        _Filtrar.Descripcion = "MODALIDAD"

        If _Filtrar.Fx_Filtrar(Nothing,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Otra, "And MODALIDAD <> '  '",
                               Nothing, False, True) Then

            Dim _Tbl_Transportista As DataTable = _Filtrar.Pro_Tbl_Filtro

            Dim _Row As DataRow = _Tbl_Transportista.Rows(0)

            Dim _Modalidad = _Row.Item("Codigo").ToString.Trim

            Txt_Modalidad.Tag = _Modalidad
            Txt_Modalidad.Text = _Modalidad

        End If

    End Sub

    Private Sub Btn_Conf_ConfEstacion_Click(sender As Object, e As EventArgs) Handles Btn_Conf_ConfEstacion.Click
        Dim _Autorizado As Boolean

        Dim Fm_Pass As New Frm_Clave_Administrador
        Fm_Pass.ShowDialog(Me)
        _Autorizado = Fm_Pass.Pro_Autorizado
        Fm_Pass.Dispose()

        If _Autorizado Then
            Dim _Id = _Global_Row_EstacionBk.Item("Id")
            Dim Fm As New Frm_RegistrarEquipo(Frm_RegistrarEquipo.Enum_Accion.Editar, _Id, False)
            Fm.ShowDialog(Me)
            Fm.Dispose()
        End If
    End Sub

    Private Sub Btn_Conf_ConfImpDiablito_Click(sender As Object, e As EventArgs) Handles Btn_Conf_ConfImpDiablito.Click
        Dim Fm As New Frm_Imp_Diablito_X_Est(Txt_Funcionario.Tag, False)
        Fm.Tido = "000"
        Fm.ShowDialog(Me)
        Fm.Dispose()
    End Sub

    Sub Sb_Revisar_Post()

        If Rdb_Post_Autoservicio.Checked Then
            Btn_Anular_Transaccion.Text = "Anular ultima transacción"
            Btn_Inicializacion.Text = "Inicializacion"
        End If

        ' Envio a Post Integrado
        If Rdb_Post_Integrado.Checked Then
            Btn_Anular_Transaccion.Text = "Anular transacción"
            Btn_Inicializacion.Text = "Detalle de Totales"
        End If

        Btn_Imprimir_Ventas.Visible = Rdb_Post_Integrado.Checked

    End Sub

    Private Sub Btn_Imprimir_Ventas_Click(sender As Object, e As EventArgs) Handles Btn_Imprimir_Ventas.Click

        _Row_Estacion_CashDro.Item("Tbk_Puerto") = Cmb_Tbk_Puerto.Text
        _Row_Estacion_CashDro.Item("Tbk_Paridad") = Cmb_Tbk_Paridad.Text
        _Row_Estacion_CashDro.Item("Tbk_Bits_de_parada") = Cmb_Tbk_Bits_de_parada.Text
        _Row_Estacion_CashDro.Item("Tbk_Bits_de_datos") = Cmb_Tbk_Bits_de_datos.Text
        _Row_Estacion_CashDro.Item("Tbk_Tasa_de_baudios") = Cmb_Tbk_Tasa_de_baudios.Text

        If Rdb_Tbk_Hexadecimal.Checked() Then
            comm.Pro_CurrentTransmissionType = Clas_Comm_Manager.TransmissionType.Hex
        Else
            comm.Pro_CurrentTransmissionType = Clas_Comm_Manager.TransmissionType.Text
        End If

        Dim Fm As New Frm_Cashdro_Pago_Tarjeta(_Row_Estacion_CashDro, "0",
                                                   0, Frm_Cashdro_Pago_Tarjeta.Enum_Accion.Imprimir_Ventas, False)
        Fm.ShowDialog(Me)

        Dim _Pagado As Boolean = Fm.Pro_Pagado
        Dim _Comando_Transaccion As String = Fm.Pro_Comando_Transaccion
        Dim _Respuesta As String = Fm.Pro_Respuesta_Decodificada
        Dim _Status As String = Fm.Pro_Status

        Fm.Dispose()

        MessageBoxEx.Show(Me, _Respuesta, _Status)
        Lbl_Status.Text = "Prueba: " & _Status & "-" & _Respuesta
        Clipboard.Clear()

        Dim _Clipboard As String
        _Clipboard = "Comando enviado: " & _Comando_Transaccion & vbCrLf &
                     "Respuesta: " & _Respuesta
        If Not String.IsNullOrEmpty(_Respuesta) Then Clipboard.SetText(_Clipboard)


    End Sub

End Class
