Imports System.ComponentModel
Imports DevComponents.DotNetBar


Public Class Cl_Pago_Cashdro

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_Sql As String

    Dim WithEvents _Tiempo As New Timer
    Dim WithEvents _BackgroundWorker As New BackgroundWorker

    Dim _Tbl_Productos As DataTable
    Dim _Lista As String
    Dim _CirProgress As CircularProgressItem

    Dim _NombreEquipo As String
    Dim _Row_CashDro As DataRow
    Dim _Post_Autoservicio, _Post_Integrado As Boolean

    Public Sub New(NombreEquipo As String)

        '_BackgroundWorker.WorkerReportsProgress = True
        '_BackgroundWorker.WorkerSupportsCancellation = True

        _NombreEquipo = NombreEquipo

        Consulta_Sql = "Select * From " & _Global_BaseBk & "Zw_Estaciones_CashDro" & vbCrLf &
                       "Where NombreEquipo = '" & _NombreEquipo & "'"
        _Row_CashDro = _Sql.Fx_Get_DataRow(Consulta_Sql)

        '_Tiempo.Interval = 1 * (1000 * 60) ' 1 minuto
        '_Tiempo.Enabled = True
        '_Tiempo.Start()

    End Sub

    Private Sub BackgroundWorker_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles _BackgroundWorker.DoWork

        Dim worker As BackgroundWorker = TryCast(sender, BackgroundWorker)

        Try

            If Not worker.CancellationPending Then

                If worker.CancellationPending = True Then
                    e.Cancel = True
                Else
                    System.Windows.Forms.Application.DoEvents()
                End If

                _NombreEquipo = _Global_Row_EstacionBk.Item("NombreEquipo")

                Sb_Pagar_Pendientes_Efectivo(False)
                Sb_Pagar_Pendientes_Nota_De_Credito()
                Sb_Pagar_Pendientes_Tarjeta(False)
                Sb_Pagar_Pendientes_Vuelto_Casdro()

            End If

        Catch ex As Exception
            e.Cancel = True
        End Try

    End Sub

    Private Sub BackgroundWorker1_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles _BackgroundWorker.ProgressChanged
        'Lbl_Progreso.Text = (e.ProgressPercentage.ToString() & "%")
        'ProgressBarItem1.Value = e.ProgressPercentage
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles _BackgroundWorker.RunWorkerCompleted

        If e.Cancelled Then
            'Lbl_Progreso.Text = "Canceled!"
        ElseIf e.[Error] IsNot Nothing Then
            'Lbl_Progreso.Text = "Error: " & e.[Error].Message
        Else
            _Tiempo.Start()
            'Lbl_Progreso.Text = "Done!"
            'If _BackgroundWorker.IsBusy <> True Then
            '_BackgroundWorker.RunWorkerAsync()
            'End If
        End If

    End Sub


    Sub Sb_Pagar_Pendientes_Efectivo(_Pagar_de_a_uno As Boolean)

        '_NombreEquipo = "ROBOTINA"

        Dim _Top = String.Empty

        If _Pagar_de_a_uno Then
            _Top = " Top 1 "
        End If

        Consulta_Sql = "Select " & _Top & "* From " & _Global_BaseBk & "Zw_CashDro_Operaciones" & vbCrLf &
                       "Where Pagado_CashDro = 1 And Pagado_Random = 0 And Idmaeedo <> 0 And Tipo_De_Pago = 'EFV'" & Space(1) &
                       "And posid = '" & _NombreEquipo & "' Order By Id"
        Dim _Tbl_Pagos_Pendientes As DataTable = _Sql.Fx_Get_Tablas(Consulta_Sql)

        If CBool(_Tbl_Pagos_Pendientes.Rows.Count) Then

            For Each _Row_CashDro_Operaciones As DataRow In _Tbl_Pagos_Pendientes.Rows

                'Dim _Row_CashDro_Operaciones As DataRow = _Tbl_Pagos_Pendientes.Rows(0)

                Dim _Id = _Row_CashDro_Operaciones.Item("Id")
                Dim _OperationId = _Row_CashDro_Operaciones.Item("OperationId")
                Dim _Idmaeedo = _Row_CashDro_Operaciones.Item("Idmaeedo")
                Dim _Monto = _Row_CashDro_Operaciones.Item("Monto")
                Dim _Ajuste_Sencillo = _Row_CashDro_Operaciones.Item("Ajuste_Sencillo")

                _Monto -= _Ajuste_Sencillo

                Dim _Fecha_Pago As Date = FormatDateTime(_Row_CashDro_Operaciones.Item("FechaHora_Inicio"), DateFormat.ShortDate)
                Dim _Idmaedpce As Integer

                Consulta_Sql = "Select Top 1 TIDO,NUDO,ESPGDO,VAABDO - VABRDO AS SALDO" & vbCrLf &
                               "From MAEEDO" & vbCrLf &
                               "Where IDMAEEDO = " & _Idmaeedo
                Dim _Row_Maeedo As DataRow = _Sql.Fx_Get_DataRow(Consulta_Sql)

                If Not (_Row_Maeedo Is Nothing) Then

                    Dim _Tido = _Row_Maeedo.Item("TIDO")
                    Dim _Nudo = _Row_Maeedo.Item("NUDO")

                    Dim Fm As New Frm_Pagos_Documentos("")
                    Fm.Sb_Nuevo_Documento()

                    If Fm.Fx_Buscar_Documento(_Tido & _Nudo, False) Then

                        Dim _Fila As DataGridViewRow = Fm.Grilla_Maedpce.Rows(0)

                        _Fila.Cells("TIDP").Value = "EFV"
                        _Fila.Cells("ESPGDP").Value = "C"
                        _Fila.Cells("VADP").Value = _Monto
                        _Fila.Cells("FEEMDP").Value = _Fecha_Pago
                        _Fila.Cells("FEVEDP").Value = _Fecha_Pago

                        Fm.Sb_Sumar_Totales()
                        Fm.Sb_Grabar_Pago_A_Documento(False, True, _Idmaedpce)

                    End If
                    Fm.Dispose()


                    If CBool(_Idmaedpce) Then

                        Consulta_Sql = "Select Top 1 TIDO,NUDO,ESPGDO,VAABDO - VABRDO AS SALDO" & vbCrLf &
                                       "From MAEEDO" & vbCrLf &
                                       "Where IDMAEEDO = " & _Idmaeedo
                        _Row_Maeedo = _Sql.Fx_Get_DataRow(Consulta_Sql)

                        If Not (_Row_Maeedo Is Nothing) Then

                            Dim _Espgdo = _Row_Maeedo.Item("ESPGDO")
                            Dim _Saldo = _Row_Maeedo.Item("SALDO")

                            If _Espgdo = "C" Or _Saldo = 0 Then

                                Consulta_Sql = "Update " & _Global_BaseBk & "Zw_CashDro_Operaciones Set" & Space(1) &
                                               "Tido = '" & _Tido & "'," &
                                               "Nudo = '" & _Nudo & "'," &
                                               "Pagado_Random = 1," &
                                               "FechaHora_Fin = Getdate()," &
                                               "Idmaedpce = " & _Idmaedpce & "," &
                                               "Valor_Asignado = " & De_Num_a_Tx_01(_Monto, False, 5) & vbCrLf &
                                               "Where Id = " & _Id
                                _Sql.Ej_consulta_IDU(Consulta_Sql)

                            Else

                                Consulta_Sql = "Update " & _Global_BaseBk & "Zw_CashDro_Operaciones Set" & Space(1) &
                                               "Tido = '" & _Tido & "'," &
                                               "Nudo = '" & _Nudo & "'," &
                                               "Pagado_CashDro = 1," &
                                               "Pagado_Random = " & CInt(CBool(_Idmaedpce)) * -1 & "," &
                                               "FechaHora_Fin = Getdate()," &
                                               "Idmaedpce = " & _Idmaedpce & "," &
                                               "Valor_Asignado = " & De_Num_a_Tx_01(_Monto, False, 5) & vbCrLf &
                                              "Where Id = " & _Id
                                _Sql.Ej_consulta_IDU(Consulta_Sql)

                            End If

                        End If

                    Else

                        Consulta_Sql = "SELECT CD.IDMAEDPCE,CD.TIDOPA,CD.ARCHIRST,CD.IDRST,CD.FEASDP,CD.VAASDP,PROPIO.TIDP,PROPIO.NUDP,
                                        PROPIO.ENDP,PROPIO.FEEMDP,PROPIO.FEVEDP,PROPIO.VADP,PROPIO.TIMODP,PROPIO.MODP,PROPIO.TAMODP,
                                        PROPIO.TIMODP,PROPIO.REFANTI,CD.TCASIG
                                        FROM MAEDPCD AS CD  WITH ( NOLOCK )  
                                        LEFT JOIN MAEDPCE AS PROPIO ON CD.IDMAEDPCE=PROPIO.IDMAEDPCE  
                                        WHERE CD.ARCHIRST='MAEEDO'  AND CD.IDRST=" & _Idmaeedo & " ORDER BY CD.FEASDP"
                        Dim _Tbl As DataTable = _Sql.Fx_Get_Tablas(Consulta_Sql)

                        For Each _Fl As DataRow In _Tbl.Rows

                            Dim _PROPIO_TIDP = _Fl.Item("TIDP")
                            Dim _Vadp = _Fl.Item("VADP")
                            _Idmaedpce = _Fl.Item("IDMAEDPCE")

                            If _PROPIO_TIDP = "EFV" And _Vadp = _Monto Then

                                Consulta_Sql = "Update " & _Global_BaseBk & "Zw_CashDro_Operaciones Set" & Space(1) &
                                                "Tido = '" & _Tido & "'," &
                                                "Nudo = '" & _Nudo & "'," &
                                                "Pagado_Random = 1," &
                                                "FechaHora_Fin = Getdate()," &
                                                "Idmaedpce = " & _Idmaedpce & "," &
                                                "Valor_Asignado = " & De_Num_a_Tx_01(_Monto, False, 5) & vbCrLf &
                                                "Where Id = " & _Id
                                _Sql.Ej_consulta_IDU(Consulta_Sql)

                                Exit For

                            End If

                        Next


                    End If


                Else

                    Consulta_Sql = "Update " & _Global_BaseBk & "Zw_CashDro_Operaciones Set" & Space(1) &
                                   "Idmaeedo = 0" & vbCrLf &
                                   "Where Id = " & _Id
                    _Sql.Ej_consulta_IDU(Consulta_Sql)

                End If

            Next

        End If

    End Sub

    Sub Sb_Pagar_Pendientes_Tarjeta(_Pagar_de_a_uno As Boolean)

        '_NombreEquipo = "ROBOTINA"

        Dim _Top = String.Empty

        If _Pagar_de_a_uno Then
            _Top = " Top 1 "
        End If

        Consulta_Sql = "Select " & _Top & "* From " & _Global_BaseBk & "Zw_CashDro_Operaciones" & vbCrLf &
                       "Where Pagado_Transbank = 1 And Pagado_Random = 0 And Idmaeedo <> 0 And" & Space(1) &
                       "Tipo_De_Pago = 'TJV' And Error_Extraccion_Respuesta_Transbank = 0" & Space(1) &
                       "And posid = '" & _NombreEquipo & "' Order By Id Desc"

        Dim _Tbl_Pagos_Pendientes As DataTable = _Sql.Fx_Get_Tablas(Consulta_Sql)

        Dim _Datos_Tarjeta
        Dim _Error_Extraccion_Respuesta_Transbank As Boolean

        Dim _Row_Maeedo As DataRow


        If CBool(_Tbl_Pagos_Pendientes.Rows.Count) Then

            For Each _Row_CashDro_Operaciones As DataRow In _Tbl_Pagos_Pendientes.Rows

                Dim _Respuesta_Tarjeta As String
                Dim _Id = _Row_CashDro_Operaciones.Item("Id")
                Dim _OperationId = _Row_CashDro_Operaciones.Item("OperationId")
                Dim _Idmaeedo = _Row_CashDro_Operaciones.Item("Idmaeedo")
                Dim _Monto = _Row_CashDro_Operaciones.Item("Monto")
                Dim _Fecha_Pago As Date = FormatDateTime(_Row_CashDro_Operaciones.Item("FechaHora_Inicio"), DateFormat.ShortDate)


                _Respuesta_Tarjeta = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_CashDro_Transbank_Log", "Log_Datos_Ultima_Venta_Transbank",
                                                       "Idmaeedo_Referencia = " & _Idmaeedo & " And Respuesta_Inicial = 0 Order By Id Desc")

                If String.IsNullOrEmpty(_Respuesta_Tarjeta) Then
                    _Respuesta_Tarjeta = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_CashDro_Transbank_Log", "Log_Datos_Ultima_Venta_Transbank",
                                                       "Idmaeedo_Referencia = " & _Idmaeedo & " And Respuesta_Inicial = 1 Order By Id Desc")
                End If


                Dim _Comando = String.Empty
                Dim _Codigo_Respuesta = String.Empty
                Dim _Codigo_de_comercio = String.Empty
                Dim _Terminal_ID = String.Empty
                Dim _Numero_Ticket_Boleta = String.Empty
                Dim _Codigo_Autorizacion = String.Empty
                'Dim _Monto = _Datos_Tarjeta(6)
                Dim _Ultimos_4_Digitos_Tarjeta = String.Empty
                Dim _Numero_Operacion = String.Empty
                Dim _Tipo_de_Tarjeta = String.Empty
                'Dim _Fecha_Contable = String.Empty
                'Dim _Numero_de_Cuenta = String.Empty
                Dim _Emdp As String
                Dim _Idmaedpce As Integer

                Dim _Cod_Tarjeta = String.Empty


                Consulta_Sql = "Select Top 1 TIDO,NUDO,ESPGDO,VAABDO - VABRDO AS SALDO" & vbCrLf &
                               "From MAEEDO" & vbCrLf &
                               "Where IDMAEEDO = " & _Idmaeedo
                _Row_Maeedo = _Sql.Fx_Get_DataRow(Consulta_Sql)

                Dim _Tido = "???"
                Dim _Nudo = "???"

                If Not (_Row_Maeedo Is Nothing) Then
                    _Tido = _Row_Maeedo.Item("TIDO")
                    _Nudo = _Row_Maeedo.Item("NUDO")
                End If


                If Not String.IsNullOrEmpty(Trim(_Respuesta_Tarjeta)) Then

                    _Datos_Tarjeta = Split(_Respuesta_Tarjeta, "|")

                    Dim _Largo As Integer = CType(_Datos_Tarjeta, System.Array).Length

                    _Post_Autoservicio = _Row_CashDro.Item("Post_Autoservicio")
                    _Post_Integrado = _Row_CashDro.Item("Post_Integrado")

                    Try

                        _Comando = _Datos_Tarjeta(0)
                        _Codigo_Respuesta = _Datos_Tarjeta(1)
                        _Codigo_de_comercio = _Datos_Tarjeta(2)
                        _Terminal_ID = _Datos_Tarjeta(3)
                        _Numero_Ticket_Boleta = _Datos_Tarjeta(4)
                        _Codigo_Autorizacion = _Datos_Tarjeta(5)

                        If _Post_Autoservicio Then
                            _Ultimos_4_Digitos_Tarjeta = Rellenar(_Datos_Tarjeta(7), 20, "*", False)
                            _Numero_Operacion = _Datos_Tarjeta(8)
                            _Tipo_de_Tarjeta = _Datos_Tarjeta(9)
                        End If

                        If _Post_Integrado Then
                            _Ultimos_4_Digitos_Tarjeta = Rellenar(_Datos_Tarjeta(9), 20, "*", False)
                            _Numero_Operacion = _Datos_Tarjeta(10)
                            _Tipo_de_Tarjeta = _Datos_Tarjeta(11)
                        End If

                        If _Tipo_de_Tarjeta = "CR" Then
                            _Emdp = _Row_CashDro.Item("TJV_Emdp_Credito")
                        ElseIf _Tipo_de_Tarjeta = "DB" Then
                            _Emdp = _Row_CashDro.Item("TJV_Emdp_Debito")
                        End If

                    Catch ex As Exception

                        _Error_Extraccion_Respuesta_Transbank = True

                        Consulta_Sql = "Update " & _Global_BaseBk & "Zw_CashDro_Operaciones Set" & Space(1) &
                                       "Tido = '" & _Tido & "'," &
                                       "Nudo = '" & _Nudo & "'," &
                                       "Error_Extraccion_Respuesta_Transbank = 1," &
                                       "Log_Error = 'Revisar estado de cuentas en Transbank'," &
                                       "FechaHora_Fin = Getdate()" & vbCrLf &
                                       "Where Id = " & _Id
                        _Sql.Ej_consulta_IDU(Consulta_Sql)

                        Exit Sub

                    End Try

                End If

                'Dim _Abreviacion_Tarjeta = _Datos_Tarjeta(12)
                'Dim _Fecha_Transaccion = _Datos_Tarjeta(13)
                'Dim _Hora_Transaccion = _Datos_Tarjeta(14)

                If Not (_Row_Maeedo Is Nothing) Then

                    Dim Fm As New Frm_Pagos_Documentos("")
                    Fm.Sb_Nuevo_Documento()

                    If Fm.Fx_Buscar_Documento(_Tido & _Nudo, False) Then

                        Dim _Fila As DataGridViewRow = Fm.Grilla_Maedpce.Rows(0)

                        _Fila.Cells("TIDP").Value = "TJV"
                        _Fila.Cells("ESPGDP").Value = "P"
                        _Fila.Cells("VADP").Value = _Monto

                        _Fila.Cells("EMDP").Value = _Emdp
                        _Fila.Cells("CUDP").Value = _Codigo_Autorizacion
                        _Fila.Cells("NUCUDP").Value = _Numero_Operacion

                        _Fila.Cells("REFANTI").Value = _Ultimos_4_Digitos_Tarjeta

                        _Fila.Cells("NUTRANSMI").Value = _Cod_Tarjeta
                        _Fila.Cells("DOCUENANTI").Value = _Terminal_ID
                        _Fila.Cells("FEEMDP").Value = _Fecha_Pago
                        _Fila.Cells("FEVEDP").Value = _Fecha_Pago

                        Fm.Sb_Sumar_Totales()
                        Fm.Sb_Grabar_Pago_A_Documento(False, True, _Idmaedpce)

                    End If
                    Fm.Dispose()

                    If CBool(_Idmaedpce) Then

                        Consulta_Sql = "Select Top 1 TIDO,NUDO,ESPGDO,VAABDO - VABRDO AS SALDO" & vbCrLf &
                              "From MAEEDO" & vbCrLf &
                              "Where IDMAEEDO = " & _Idmaeedo
                        _Row_Maeedo = _Sql.Fx_Get_DataRow(Consulta_Sql)


                        If Not (_Row_Maeedo Is Nothing) Then

                            Dim _Espgdo = _Row_Maeedo.Item("ESPGDO")
                            Dim _Saldo = _Row_Maeedo.Item("SALDO")

                            If _Espgdo = "C" Or _Saldo = 0 Then

                                Consulta_Sql = "Update " & _Global_BaseBk & "Zw_CashDro_Operaciones Set" & Space(1) &
                                           "Tido = '" & _Tido & "'," &
                                           "Nudo = '" & _Nudo & "'," &
                                           "Pagado_Random = 1," &
                                           "FechaHora_Fin = Getdate()," &
                                           "Idmaedpce = " & _Idmaedpce & "," &
                                           "Valor_Asignado = " & De_Num_a_Tx_01(_Monto, False, 5) & vbCrLf &
                                           "Where Id = " & _Id
                                _Sql.Ej_consulta_IDU(Consulta_Sql)

                            Else

                                Consulta_Sql = "Update " & _Global_BaseBk & "Zw_CashDro_Operaciones Set" & Space(1) &
                                           "Tido = '" & _Tido & "'," &
                                           "Nudo = '" & _Nudo & "'," &
                                           "Pagado_Random = 1," &
                                           "FechaHora_Fin = Getdate()," &
                                           "Idmaedpce = " & _Idmaedpce & "," &
                                           "Valor_Asignado = " & De_Num_a_Tx_01(_Monto, False, 5) & vbCrLf &
                                           "Where Id = " & _Id
                                _Sql.Ej_consulta_IDU(Consulta_Sql)

                            End If

                        End If

                    Else

                        Consulta_Sql = "SELECT CD.IDMAEDPCE,CD.TIDOPA,CD.ARCHIRST,CD.IDRST,CD.FEASDP,CD.VAASDP,PROPIO.TIDP,PROPIO.NUDP,
                                        PROPIO.ENDP,PROPIO.FEEMDP,PROPIO.FEVEDP,PROPIO.VADP,PROPIO.TIMODP,PROPIO.MODP,PROPIO.TAMODP,
                                        PROPIO.TIMODP,PROPIO.REFANTI,CD.TCASIG
                                        FROM MAEDPCD AS CD  WITH ( NOLOCK )  
                                        LEFT JOIN MAEDPCE AS PROPIO ON CD.IDMAEDPCE=PROPIO.IDMAEDPCE  
                                        WHERE CD.ARCHIRST='MAEEDO'  AND CD.IDRST=" & _Idmaeedo & " ORDER BY CD.FEASDP"
                        Dim _Tbl As DataTable = _Sql.Fx_Get_Tablas(Consulta_Sql)

                        For Each _Fl As DataRow In _Tbl.Rows

                            Dim _PROPIO_TIDP = _Fl.Item("TIDP")
                            Dim _Vadp = _Fl.Item("VADP")
                            _Idmaedpce = _Fl.Item("IDMAEDPCE")

                            If _PROPIO_TIDP = "TJV" And _Vadp = _Monto Then

                                Consulta_Sql = "Update " & _Global_BaseBk & "Zw_CashDro_Operaciones Set" & Space(1) &
                                                "Tido = '" & _Tido & "'," &
                                                "Nudo = '" & _Nudo & "'," &
                                                "Pagado_Random = 1," &
                                                "FechaHora_Fin = Getdate()," &
                                                "Idmaedpce = " & _Idmaedpce & "," &
                                                "Valor_Asignado = " & De_Num_a_Tx_01(_Monto, False, 5) & vbCrLf &
                                                "Where Id = " & _Id
                                _Sql.Ej_consulta_IDU(Consulta_Sql)

                                Exit For

                            End If

                        Next


                    End If

                Else

                    Consulta_Sql = "Update " & _Global_BaseBk & "Zw_CashDro_Operaciones Set" & Space(1) &
                               "Idmaeedo = 0" & vbCrLf &
                               "Where Id = " & _Id
                    _Sql.Ej_consulta_IDU(Consulta_Sql)

                End If

            Next

        End If

    End Sub

    Sub Sb_Pagar_Pendientes_Nota_De_Credito()

        '_NombreEquipo = "ROBOTINA"

        Consulta_Sql = "Select * From " & _Global_BaseBk & "Zw_CashDro_Operaciones" & vbCrLf &
                       "Where Tipo_De_Pago in ('ncv','NCV') And" & Space(1) &
                       "Pagado_Nota_de_credito = 1 And Pagado_Random = 0 And Idmaeedo <> 0 And posid = '" & _NombreEquipo & "' And Vuelto_Entregado = 0"
        Dim _Tbl_Pagos_Pendientes As DataTable = _Sql.Fx_Get_Tablas(Consulta_Sql)


        If CBool(_Tbl_Pagos_Pendientes.Rows.Count) Then

            For Each _Row_Operacion_NCV As DataRow In _Tbl_Pagos_Pendientes.Rows

                Dim _Id = _Row_Operacion_NCV.Item("Id")
                Dim _OperationId = _Row_Operacion_NCV.Item("OperationId")
                Dim _Idmaeedo_DOC As Integer = _Row_Operacion_NCV.Item("Idmaeedo")
                Dim _Idmaeedo_NCV As Integer = _Row_Operacion_NCV.Item("Idmaeedo_NCV")
                Dim _Pagado_Nota_de_credito As Boolean = _Row_Operacion_NCV.Item("Pagado_Nota_de_credito")

                Dim _Monto As Double = _Row_Operacion_NCV.Item("Monto")
                Dim _Fecha_Pago As Date = FormatDateTime(_Row_Operacion_NCV.Item("FechaHora_Inicio"), DateFormat.ShortDate)
                Dim _Idmaedpce As Integer

                Dim _Vuelto = _Row_Operacion_NCV.Item("Vuelto")
                Dim _Saldo As Double

                Consulta_Sql = "Select Top 1 IDMAEEDO,TIDO,NUDO,ENDO,ESPGDO,VAABDO,VABRDO,VABRDO - VAABDO AS SALDO" & vbCrLf &
                               "From MAEEDO" & vbCrLf &
                               "Where IDMAEEDO = " & _Idmaeedo_DOC
                Dim _Row_Documento As DataRow = _Sql.Fx_Get_DataRow(Consulta_Sql)


                If Not (_Row_Documento Is Nothing) Then

                    Dim _Tido = _Row_Documento.Item("TIDO")
                    Dim _Nudo = _Row_Documento.Item("NUDO")
                    Dim _Endo = _Row_Documento.Item("ENDO")
                    _Saldo = _Row_Documento.Item("SALDO")

                    If _Saldo > 0 Then

                        Consulta_Sql = "Select Top 1 * From MAEEDO Where IDMAEEDO = " & _Idmaeedo_NCV
                        Dim _Row_NCV As DataRow = _Sql.Fx_Get_DataRow(Consulta_Sql)

                        Dim _Tido_NCV = _Row_NCV.Item("TIDO")
                        Dim _Nudo_NCV = _Row_NCV.Item("NUDO")
                        Dim _Endo_NCV = _Row_NCV.Item("ENDO")


                        Dim Fm As New Frm_Pagos_Documentos("")
                        Fm.Sb_Nuevo_Documento()

                        If Fm.Fx_Buscar_Documento(_Tido & _Nudo, False) Then

                            Dim _Fila As DataGridViewRow = Fm.Grilla_Maedpce.Rows(0)

                            _Fila.Cells("TIDP").Value = "ncv"
                            _Fila.Cells("ESPGDP").Value = "C"
                            _Fila.Cells("VADP").Value = _Monto

                            Dim _Koen = _Endo
                            Dim _Rut = RutEmpresa

                            _Fila.Cells("ENDP").Value = _Rut
                            _Fila.Cells("EMDP").Value = _Koen
                            _Fila.Cells("FEEMDP").Value = _Fecha_Pago
                            _Fila.Cells("FEVEDP").Value = _Fecha_Pago

                            _Fila.Cells("REFANTI").Value = _Tido_NCV & "-" & _Nudo_NCV & "-" & _Endo_NCV
                            _Fila.Cells("IDMAEEDO").Value = _Idmaeedo_NCV
                            _Fila.Cells("SALDO").Value = _Monto

                            Fm.Sb_Sumar_Totales()
                            Fm.Sb_Grabar_Pago_A_Documento(False, True, _Idmaedpce)

                        End If
                        Fm.Dispose()


                        Consulta_Sql = "Select Top 1 TIDO,NUDO,ENDO,ESPGDO,VAABDO - VABRDO AS SALDO" & vbCrLf &
                                      "From MAEEDO" & vbCrLf &
                                      "Where IDMAEEDO = " & _Idmaeedo_DOC
                        _Row_Documento = _Sql.Fx_Get_DataRow(Consulta_Sql)

                        If CBool(_Idmaedpce) Then

                            If Not (_Row_Documento Is Nothing) Then

                                Dim _Espgdo = _Row_Documento.Item("ESPGDO")
                                _Saldo = _Row_Documento.Item("SALDO")

                                Consulta_Sql = "Update " & _Global_BaseBk & "Zw_CashDro_Operaciones Set" & Space(1) &
                                           "Tido = '" & _Tido & "'," &
                                           "Nudo = '" & _Nudo & "'," &
                                           "Pagado_Random = 1," &
                                           "FechaHora_Fin = Getdate()," &
                                           "Idmaedpce = " & _Idmaedpce & "," &
                                           "Valor_Asignado = " & De_Num_a_Tx_01(_Monto, False, 5) & vbCrLf &
                                           "Where Id = " & _Id
                                _Sql.Ej_consulta_IDU(Consulta_Sql)

                            End If

                        Else

                            Consulta_Sql = "SELECT CD.IDMAEDPCE,CD.TIDOPA,CD.ARCHIRST,CD.IDRST,CD.FEASDP,CD.VAASDP,PROPIO.TIDP,PROPIO.NUDP,
                                        PROPIO.ENDP,PROPIO.FEEMDP,PROPIO.FEVEDP,PROPIO.VADP,PROPIO.TIMODP,PROPIO.MODP,PROPIO.TAMODP,
                                        PROPIO.TIMODP,PROPIO.REFANTI,CD.TCASIG
                                        FROM MAEDPCD AS CD  WITH ( NOLOCK )  
                                        LEFT JOIN MAEDPCE AS PROPIO ON CD.IDMAEDPCE=PROPIO.IDMAEDPCE  
                                        WHERE CD.ARCHIRST='MAEEDO'  AND CD.IDRST=" & _Idmaeedo_DOC & " ORDER BY CD.FEASDP"
                            Dim _Tbl As DataTable = _Sql.Fx_Get_Tablas(Consulta_Sql)

                            For Each _Fl As DataRow In _Tbl.Rows

                                Dim _PROPIO_TIDP = _Fl.Item("TIDP")
                                Dim _Vadp = _Fl.Item("VADP")
                                _Idmaedpce = _Fl.Item("IDMAEDPCE")

                                If _PROPIO_TIDP = "ncv" And _Vadp = _Monto Then

                                    Consulta_Sql = "Update " & _Global_BaseBk & "Zw_CashDro_Operaciones Set" & Space(1) &
                                                    "Tido = '" & _Tido & "'," &
                                                    "Nudo = '" & _Nudo & "'," &
                                                    "Pagado_Random = 1," &
                                                    "FechaHora_Fin = Getdate()," &
                                                    "Idmaedpce = " & _Idmaedpce & "," &
                                                    "Valor_Asignado = " & De_Num_a_Tx_01(_Monto, False, 5) & vbCrLf &
                                                    "Where Id = " & _Id
                                    _Sql.Ej_consulta_IDU(Consulta_Sql)

                                    Exit For

                                End If

                            Next

                        End If


                    End If

                Else

                    Consulta_Sql = "Update " & _Global_BaseBk & "Zw_CashDro_Operaciones Set" & Space(1) &
                                   "Idmaeedo = 0" & vbCrLf &
                                   "Where Id = " & _Id
                    _Sql.Ej_consulta_IDU(Consulta_Sql)

                End If

            Next

        End If

    End Sub

    Sub Sb_Pagar_Pendientes_Vuelto_Casdro()

        Consulta_Sql = "Select * From " & _Global_BaseBk & "Zw_CashDro_Operaciones" & vbCrLf &
                       "Where Pagado_CashDro = 1 And Pagado_Random = 0 And Idmaeedo <> 0 And Tipo_De_Pago = 'EFC'" & Space(1) &
                       "And posid = '" & _NombreEquipo & "'"
        Dim _Tbl_Pagos_Pendientes As DataTable = _Sql.Fx_Get_Tablas(Consulta_Sql)

        For Each _Row_Operacion As DataRow In _Tbl_Pagos_Pendientes.Rows

            Dim _Id = _Row_Operacion.Item("Id")
            Dim _OperationId = _Row_Operacion.Item("OperationId")
            Dim _Empresa = _Row_Operacion.Item("Empresa")
            Dim _Sucursal = _Row_Operacion.Item("Sucursal")
            Dim _Caja = _Row_Operacion.Item("Caja")

            Dim _Fecha_Emision As Date = FormatDateTime(_Row_Operacion.Item("FechaHora_Inicio"), DateFormat.ShortDate)
            Dim _Vuelto As Double = _Row_Operacion.Item("Vuelto")
            Dim _Monto As Double = _Row_Operacion.Item("Monto")
            Dim _Ajuste_Sencillo As Double = _Row_Operacion.Item("Ajuste_Sencillo")

            Dim _Saldo As Double = _Monto + _Ajuste_Sencillo

            Dim _Idmaeedo = _Row_Operacion.Item("Idmaeedo")
            Dim _Idmaedpce As Integer

            Consulta_Sql = "Select Top 1 *,Cast(1 As Bit) As Chk,Cast(" & De_Num_a_Tx_01(_Saldo, False, 5) & " As Float) As SALDO" & vbCrLf &
                           "FROM MAEVEN AS VEN WITH ( NOLOCK )" & vbCrLf &
                           "INNER JOIN MAEEDO AS EDO ON EDO.IDMAEEDO=VEN.IDMAEEDO" & vbCrLf &
                           "LEFT JOIN MAEEN WITH (NOLOCK) ON MAEEN.KOEN=EDO.ENDO AND MAEEN.SUEN=EDO.SUENDO" & vbCrLf &
                           "LEFT JOIN TABSU ON TABSU.KOSU=EDO.SUDO" & vbCrLf &
                           "LEFT JOIN TABFU ON TABFU.KOFU=EDO.KOFUDO" & vbCrLf &
                           "LEFT JOIN TABLUG ON TABLUG.LUVT=EDO.LUVTDO" & vbCrLf &
                           "Where EDO.IDMAEEDO = " & _Idmaeedo

            Dim _Tbl_NCV As DataTable = _Sql.Fx_Get_Tablas(Consulta_Sql)

            Dim _Endo = _Tbl_NCV.Rows(0).Item("ENDO")
            Dim _Nudo = _Tbl_NCV.Rows(0).Item("NUDO")
            Dim _Vadp As Double

            If _Saldo > _Vuelto Then ' _Monto  > _Vuelto Then
                _Vadp = _Saldo '_Vadp = _Monto
            Else
                _Vadp = _Vuelto
            End If

            If _Vadp > _Tbl_NCV.Rows(0).Item("SALDO") Then
                _Vadp = _Tbl_NCV.Rows(0).Item("SALDO")
            Else
                _Tbl_NCV.Rows(0).Item("SALDO") = _Vadp
            End If

            Consulta_Sql = "SELECT TOP 1 * FROM MAEMO WHERE KOMO = 'US$' AND FEMO = '" & Format(FechaDelServidor, "yyyyMMdd") & "' ORDER BY IDMAEMO DESC"
            Dim _RowMoneda_USdolar = _Sql.Fx_Get_DataRow(Consulta_Sql)

            Dim _Tamodp As Double

            If Not IsNothing(_RowMoneda_USdolar) Then
                _Tamodp = _RowMoneda_USdolar.Item("VAMO")
            Else
                _Tamodp = 1
            End If

            Dim _Pagar As New Clas_Pagar
            '_Idmaedpce = _Pagar.Fx_Crear_Pago_y_Pagar("EFC", _Endo, "", _Empresa, _Sucursal, _Caja, "", "", "",
            '                                          _Fecha_Emision, _Fecha_Emision, "$", "N", 1,
            '                                          "Vuelto Cashdro NCV: " & _Nudo, 1,
            '                                          FUNCIONARIO, _Vadp,
            '                                          _Vadp, 0, "A", 0, "P", 0, "", 0, 123456, _Tbl_NCV)

            _Idmaedpce = _Pagar.Fx_Crear_Pago_y_Pagar("EFC", _Endo, "", _Empresa, _Sucursal, _Caja, "", "", "",
                                                      _Fecha_Emision, _Fecha_Emision, "$", "N", _Tamodp,
                                                      "Vuelto Cashdro NCV: " & _Nudo, 1,
                                                      FUNCIONARIO, _Vadp,
                                                      _Vadp, 0, "A", _Vadp, "C", 0, "", 0, 123456, _Tbl_NCV)

            If Convert.ToBoolean(_Idmaedpce) Then

                'If _Ajuste_Sencillo > 0 Then

                '    _Pagar.Fx_Crear_Pago_Anticipo("EFV", _Endo, "", _Empresa, _Sucursal, _Caja, "", "", "",
                '                                      _Fecha_Emision, _Fecha_Emision, "$", "N", 1,
                '                                      "Ajuste sencillo. Bakapp", 1,
                '                                      FUNCIONARIO,
                '                                      _Ajuste_Sencillo, 0, 0, "P", _Ajuste_Sencillo, "C", 0, "", 0, 123456)

                'End If

                Consulta_Sql = "Update " & _Global_BaseBk & "Zw_CashDro_Operaciones Set" & Space(1) &
                               "Pagado_Random = 1," &
                               "FechaHora_Fin = Getdate()," &
                               "Idmaedpce = " & _Idmaedpce & "," &
                               "Vuelto = 0," &
                               "Valor_Asignado = " & De_Num_a_Tx_01(_Vadp, False, 5) & vbCrLf &
                               "Where Id = " & _Id
                _Sql.Ej_consulta_IDU(Consulta_Sql)

            End If

        Next

    End Sub

    Private Sub _Tiempo_Tick(sender As Object, e As EventArgs) Handles _Tiempo.Tick

        _BackgroundWorker.RunWorkerAsync()
        _Tiempo.Stop()

    End Sub

End Class
