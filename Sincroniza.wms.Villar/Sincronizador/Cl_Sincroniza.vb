Imports BkSpecialPrograms

Public Class Cl_Sincroniza

    Dim _SqlRandom As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim _SqlWms As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Public Property Cadena_ConexionSQL_Server_Wms
    Public Property ConfiguracionLocal As Configuracion

    Public Sub New()

    End Sub

    Sub Sb_Ejecutar_Revision(Txt_Log As Object, _FechaRevision As DateTime)

        _SqlRandom = New Class_SQL(Cadena_ConexionSQL_Server)
        _SqlWms = New Class_SQL(Cadena_ConexionSQL_Server_Wms)

        Consulta_sql = "Update " & _Global_BaseBk & "Zw_Stmp_Enc Set FechaCierre = Getdate(),CodFuncionario_Cierra = 'wms',Estado = 'CERRA'" & vbCrLf &
                       "From [@WMS_GATEWAY_TRANSFERENCIA]" & vbCrLf &
                       "Inner Join " & _Global_BaseBk & "Zw_Stmp_Enc On Idmaeedo = IDMAEEDO" & vbCrLf &
                       "And Estado Not In ('CERRA') And UPLOAD In (2) "
        _SqlRandom.Ej_consulta_IDU(Consulta_sql, False)

        Consulta_sql = "Select IDMAEEDO From [@WMS_GATEWAY_TRANSFERENCIA]" & vbCrLf &
                       "Where 1>0 --(CONVERT(varchar, FECHA_DOWNLOAD, 112)) = '" & Format(_FechaRevision, "yyyyMMdd") & "'" & vbCrLf &
                       "And IDMAEEDO In (Select Idmaeedo From " & _Global_BaseBk & "Zw_Docu_Ent Where Pickear = 1 And Estaenwms = 0)"
        Dim _Tbl_wms As DataTable = _SqlRandom.Fx_Get_DataTable(Consulta_sql)
        Dim _Filtro As String = Generar_Filtro_IN(_Tbl_wms, "", "IDMAEEDO", True, False, "")

        If _Filtro <> "()" Then
            Consulta_sql = "Update " & _Global_BaseBk & "Zw_Docu_Ent Set Estaenwms = 1 Where Tido = 'NVV' And Idmaeedo In " & _Filtro
            If _SqlRandom.Ej_consulta_IDU(Consulta_sql, False) Then
                Sb_AddToLog("Sincronizando notas", "Se actualizan " & _Tbl_wms.Rows.Count & " registro(s) en tabla Zw_Docu_Ent, campo Estaenwms = 1", Txt_Log)
            Else
                Sb_AddToLog("Sincronizando notas", "¡¡¡Problema al revisar si notas existen en WMS!!!", Txt_Log)
            End If
        End If

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Stmp_Enc Where Estado In ('INGRE','PREPA','COMPL') And Planificada = 0"
        Dim _Tbl As DataTable = _SqlRandom.Fx_Get_DataTable(Consulta_sql)

        For Each _Fila As DataRow In _Tbl.Rows

            Dim _Id_Enc As Integer = _Fila.Item("Id")
            Dim _Idmaeedoo As Integer = _Fila.Item("Idmaeedo")
            Dim _Nudo As String = _Fila.Item("Nudo")
            Dim _Estado As String = _Fila.Item("Estado")

            Consulta_sql = "Select Top 1 * From history_master Where (oid = '" & _Nudo & "') AND (trans_obj = 'OBORD') Order by trans_seq_num Desc "
            Dim _RowEliminada As DataRow = _SqlWms.Fx_Get_DataRow(Consulta_sql)

            If Not IsNothing(_RowEliminada) AndAlso _Estado = "CANCE" Then

                Dim _trans_act_mod As String = NuloPorNro(_RowEliminada.Item("trans_act_mod"), "")

                If _trans_act_mod = "CANCEL" Then

                    Consulta_sql = "Update " & _Global_BaseBk & "Zw_Stmp_Enc Set Estado = 'CANCE' Where Id = " & _Id_Enc
                    _SqlRandom.Ej_consulta_IDU(Consulta_sql)

                    Sb_AddToLog("Sincronizando notas", "NVV" & _Nudo & " - Documento CANCELADO en WMS", Txt_Log)

                End If

            Else

                Consulta_sql = "Select TOP 1 trans_act_mod,dt_start from viaware.dbo.history_master where oid='" & _Nudo & "' and trans_act='STAT' Order by dt_start Desc"
                Dim _RowPlanificada As DataRow = _SqlWms.Fx_Get_DataRow(Consulta_sql)

                If Not IsNothing(_RowPlanificada) Then

                    Dim _trans_act_mod As String = _RowPlanificada.Item("trans_act_mod").ToString.Trim '='RDY'

                    If _trans_act_mod = "RDY" Or _trans_act_mod = "RELEASE" Then

                        Dim _FechaPlanificacion As String = Format(_RowPlanificada.Item("dt_start"), "yyyyMMdd HH:mm:ss")

                        Consulta_sql = "Update " & _Global_BaseBk & "Zw_Stmp_Enc Set Planificada = 1, FechaPlanificacion = '" & _FechaPlanificacion & "'" & vbCrLf &
                                       "Where Id = " & _Id_Enc
                        _SqlRandom.Ej_consulta_IDU(Consulta_sql)

                        Sb_AddToLog("Sincronizando notas", "Planificada NVV" & _Nudo, Txt_Log)

                    End If

                End If

            End If

        Next

        Consulta_sql = "Update " & _Global_BaseBk & "Zw_Stmp_Enc Set Estado = 'PREPA' Where Estado = 'INGRE' And Planificada = 1"
        _SqlRandom.Ej_consulta_IDU(Consulta_sql)

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Stmp_Enc Where Estado In ('PREPA') And Planificada = 1"
        _Tbl = _SqlRandom.Fx_Get_DataTable(Consulta_sql)

        For Each _Fila As DataRow In _Tbl.Rows

            Dim _Id_Enc As Integer = _Fila.Item("Id")
            Dim _Idmaeedoo As Integer = _Fila.Item("Idmaeedo")
            Dim _TidoGen As String = _Fila.Item("TidoGen")
            Dim _DocEmitir As String = _Fila.Item("DocEmitir")
            Dim _Nudo As String = _Fila.Item("Nudo")
            Dim _Facturar As Boolean = _Fila.Item("Facturar")
            Dim _Planificada = True

            Consulta_sql = "Select TOP 1 trans_act_mod,dt_start from viaware.dbo.history_master where oid='" & _Nudo & "' and trans_act='STAT' Order by trans_seq_num Desc"
            Dim _RowPlanificada As DataRow = _SqlWms.Fx_Get_DataRow(Consulta_sql)

            Dim _trans_act_mod As String

            If IsNothing(_RowPlanificada) Then
                _trans_act_mod = "XXX"
            Else
                _trans_act_mod = _RowPlanificada.Item("trans_act_mod").ToString.Trim
            End If

            If _trans_act_mod <> "RDY" AndAlso _trans_act_mod <> "RELEASE" Then

                Consulta_sql = "Update " & _Global_BaseBk & "Zw_Stmp_Enc Set Planificada = 0, FechaPlanificacion = Null" & vbCrLf &
                               "Where Id = " & _Id_Enc
                _SqlRandom.Ej_consulta_IDU(Consulta_sql)
                _Planificada = False
                Sb_AddToLog("Sincronizando notas", "NVV" & _Nudo & " - Deshabilitada", Txt_Log)

            End If

            If _Planificada Then

                'Sb_AddToLog("Sincronizando notas", "Revisando NVV" & _Nudo, Txt_Log)

                Dim _Cl_Stmp As New Cl_Stmp
                _Cl_Stmp.Fx_Llenar_Encabezado(_Id_Enc)
                _Cl_Stmp.Fx_Llenar_Detalle(_Id_Enc)

                _Cl_Stmp.Zw_Stmp_Enc.Fecha_Facturar = FechaDelServidor()

                Dim _Mensaje As New LsValiciones.Mensajes

                _Mensaje = _Cl_Stmp.Fx_Revisar_WMSVillar(_Idmaeedoo, "NVV", _Nudo, Cadena_ConexionSQL_Server_Wms)

                If _Mensaje.EsCorrecto Then

                    _DocEmitir = _Cl_Stmp.Zw_Stmp_Enc.DocEmitir

                    _Mensaje.Detalle += ", Nota de venta #" & _Nudo
                    Sb_AddToLog("Sincronizando notas", _Mensaje.Detalle, Txt_Log)

                    'Dim _Tipo_wms As String

                    '_Tipo_wms = _SqlRandom.Fx_Trae_Dato("[@WMS_GATEWAY_TRANSFERENCIA]", "TIPO_WMS", "IDMAEEDO = " & _Idmaeedoo,, False)

                    'If _Facturar Then

                    '    ' 0 = Contado, 1 = Credito, 2 = Guia
                    '    Dim _CodFuncionario_Factura As String

                    '    If _DocEmitir = "BLV" Or _DocEmitir = "FCV" Then
                    '        If _Cl_Stmp.Zw_Stmp_Enc.TipoPago = "Contado" Then
                    '            _CodFuncionario_Factura = ConfiguracionLocal.Ls_FunFcvGdvAuto.Item(0).CodFuncionario
                    '        End If

                    '        If _Cl_Stmp.Zw_Stmp_Enc.TipoPago = "Credito" Then
                    '            _CodFuncionario_Factura = ConfiguracionLocal.Ls_FunFcvGdvAuto.Item(1).CodFuncionario
                    '        End If
                    '    End If

                    '    If _DocEmitir = "GDV" Then
                    '        _CodFuncionario_Factura = ConfiguracionLocal.Ls_FunFcvGdvAuto.Item(2).CodFuncionario
                    '    End If

                    '    Consulta_sql = "Update " & _Global_BaseBk & "Zw_Stmp_Enc Set CodFuncionario_Factura = '" & _CodFuncionario_Factura & "' Where Id = " & _Id_Enc
                    '    _SqlRandom.Ej_consulta_IDU(Consulta_sql)

                    '    'Imprimir Retiros inmediatos
                    '    If _Tipo_wms.Contains("A") Then

                    '        If ConfiguracionLocal.Ls_ImpFormatos.Item(0).Imprimir Then

                    '            With ConfiguracionLocal.Ls_ImpFormatos.Item(0)

                    '                _Mensaje = Fx_EnviarAImprimnirListaDeVerificacion(_Idmaeedoo, "NVV", _Nudo, True,
                    '                                                              .NombreEquipoImprime, .Impresora, .NombreFormato)

                    '            End With

                    '            Sb_AddToLog(_Mensaje.Detalle, _Mensaje.Detalle, Txt_Log)

                    '        End If

                    '    End If

                    '    'Imprimir Despachos
                    '    If _Tipo_wms.Contains("O") Then

                    '        If ConfiguracionLocal.Ls_ImpFormatos.Item(1).Imprimir Then

                    '            With ConfiguracionLocal.Ls_ImpFormatos.Item(1)

                    '                _Mensaje = Fx_EnviarAImprimnirListaDeVerificacion(_Idmaeedoo, "NVV", _Nudo, True,
                    '                                                              .NombreEquipoImprime, .Impresora, .NombreFormato)
                    '                Sb_AddToLog(_Mensaje.Detalle, _Mensaje.Detalle, Txt_Log)

                    '            End With

                    '        End If

                    '    End If

                    '    'If ConfiguracionLocal.Ls_ImpFormatos.Item(2).Imprimir Then

                    '    '    With ConfiguracionLocal.Ls_ImpFormatos.Item(2)

                    '    '        _Mensaje = Fx_EnviarAImprimnirListaDeVerificacion(_Idmaeedoo, "NVV", _Nudo, True,
                    '    '                                                      .NombreEquipoImprime, .Impresora, .NombreFormato)

                    '    '    End With

                    '    '    Sb_AddToLog(_Mensaje.Detalle, _Mensaje.Detalle, Txt_Log)

                    '    'End If

                    'End If

                End If

            End If

            Application.DoEvents()

        Next

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Stmp_Enc Where Estado In ('COMPL') And Facturar = 1 And Planificada = 1 And CodFuncionario_Factura = ''"
        _Tbl = _SqlRandom.Fx_Get_DataTable(Consulta_sql)

        For Each _Fila As DataRow In _Tbl.Rows

            Dim _Id_Enc As Integer = _Fila.Item("Id")
            Dim _Idmaeedo As Integer = _Fila.Item("Idmaeedo")
            Dim _DocEmitir As String = _Fila.Item("DocEmitir")
            Dim _TipoPago As String = _Fila.Item("TipoPago")
            Dim _Nudo As String = _Fila.Item("Nudo")
            Dim _Accion As String = _Fila.Item("Accion")
            Dim _CodFuncionario_Factura = String.Empty
            Dim _Planificada As Boolean = _Fila.Item("Planificada")

            'Sb_AddToLog("Sincronizando notas", "Revisando NVV" & _Nudo, Txt_Log)

            Consulta_sql = "Update " & _Global_BaseBk & "Zw_Stmp_Det Set " &
                           "Cantidad = 0,Caprco1_Real = 0,Caprco2_Real = 0,Pickeado = 0,CodFuncionario_Pickea = '', EnProceso = 0" & vbCrLf &
                           "Where Id_Enc = " & _Id_Enc & vbCrLf &
                           "Delete " & _Global_BaseBk & "Zw_Stmp_DetPick" & vbCrLf &
                           "Where Id_Enc = " & _Id_Enc & vbCrLf &
                           "Delete MEVENTO Where ARCHIRVE = 'MAEEDO' And IDRVE = " & _Idmaeedo & vbCrLf &
                           "Delete MEVENTO Where ARCHIRVE = 'MAEDDO' And IDRVE In (Select IDMAEDDO From MAEDDO Where IDMAEEDO = " & _Idmaeedo & ")"
            _SqlRandom.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql, False)

            Dim _Cl_Stmp As New Cl_Stmp
            _Cl_Stmp.Fx_Llenar_Encabezado(_Id_Enc)
            _Cl_Stmp.Fx_Llenar_Detalle(_Id_Enc)

            _Cl_Stmp.Zw_Stmp_Enc.Fecha_Facturar = FechaDelServidor()

            Dim _Mensaje As New LsValiciones.Mensajes

            _Mensaje = _Cl_Stmp.Fx_Revisar_WMSVillar_Completadas(_Idmaeedo, "NVV", _Nudo, Cadena_ConexionSQL_Server_Wms)

            If Not _Mensaje.EsCorrecto Then

                If _Cl_Stmp.Zw_Stmp_Enc.Estado = "COMPL" Then

                    Consulta_sql = "Update " & _Global_BaseBk & "Zw_Stmp_Enc Set Estado = 'PREPA',Reasignada = 1 Where Id = " & _Cl_Stmp.Zw_Stmp_Enc.Id
                    _SqlRandom.Ej_consulta_IDU(Consulta_sql, False)

                    Sb_AddToLog("Sincronizando notas", "El documento se vuelve a dejar en preparación", Txt_Log)

                End If

            End If

            If _Mensaje.EsCorrecto Then

                _DocEmitir = _Cl_Stmp.Zw_Stmp_Enc.DocEmitir

                _Mensaje.Detalle += ", Nota de venta : " & _Nudo
                Sb_AddToLog("Sincronizando notas", _Mensaje.Detalle, Txt_Log)

                Dim _Tipo_wms As String

                _Tipo_wms = _SqlRandom.Fx_Trae_Dato("[@WMS_GATEWAY_TRANSFERENCIA]", "TIPO_WMS", "IDMAEEDO = " & _Idmaeedo,, False)

                ' 0 = Contado, 1 = Credito, 2 = Guia
                'Dim _CodFuncionario_Factura2 As String

                If _DocEmitir = "BLV" Or _DocEmitir = "FCV" Then

                    If _Cl_Stmp.Zw_Stmp_Enc.TipoPago = "Contado" Then
                        _CodFuncionario_Factura = ConfiguracionLocal.Ls_FunFcvGdvAuto.Item(0).CodFuncionario
                    End If

                    If _Cl_Stmp.Zw_Stmp_Enc.TipoPago = "Credito" Then
                        _CodFuncionario_Factura = ConfiguracionLocal.Ls_FunFcvGdvAuto.Item(1).CodFuncionario
                    End If

                    'Si es un pedido de B2B se redirecciona directamente hacia la impresora de creditos mediante la caja facturadora
                    Dim _Reg As Integer = _SqlRandom.Fx_Cuenta_Registros("[@MGT_2_PEDIDOS]", "ID_ERP=" & _Idmaeedo, False)

                    If CBool(_Reg) Then
                        _CodFuncionario_Factura = ConfiguracionLocal.Ls_FunFcvGdvAuto.Item(1).CodFuncionario
                    End If

                End If

                If _DocEmitir = "GDV" Then
                    _CodFuncionario_Factura = ConfiguracionLocal.Ls_FunFcvGdvAuto.Item(2).CodFuncionario
                End If

                Consulta_sql = "Update " & _Global_BaseBk & "Zw_Stmp_Enc Set CodFuncionario_Factura = '" & _CodFuncionario_Factura & "' Where Id = " & _Id_Enc
                _SqlRandom.Ej_consulta_IDU(Consulta_sql)

                'Imprimir Retiros inmediatos
                If _Tipo_wms.Contains("A") Then

                    If ConfiguracionLocal.Ls_ImpFormatos.Item(0).Imprimir Then

                        With ConfiguracionLocal.Ls_ImpFormatos.Item(0)

                            _Mensaje = Fx_EnviarAImprimirListaDeVerificacion(_Idmaeedo, "NVV", _Nudo, True,
                                                                          .NombreEquipoImprime, .Impresora, .NombreFormato)

                        End With

                        Sb_AddToLog(_Mensaje.Detalle, _Mensaje.Detalle, Txt_Log)

                    End If

                End If

                'Imprimir Despachos
                If _Tipo_wms.Contains("O") Then

                    If ConfiguracionLocal.Ls_ImpFormatos.Item(1).Imprimir Then

                        With ConfiguracionLocal.Ls_ImpFormatos.Item(1)

                            _Mensaje = Fx_EnviarAImprimirListaDeVerificacion(_Idmaeedo, "NVV", _Nudo, True,
                                                                          .NombreEquipoImprime, .Impresora, .NombreFormato)
                            Sb_AddToLog(_Mensaje.Detalle, _Mensaje.Detalle, Txt_Log)

                        End With

                    End If

                End If

            End If

        Next

    End Sub

    Sub Sb_Ejecutar_Revision_IncorporarNVVAutomaticamenteAStem(Txt_Log As Object, _FechaRevisionDesde As DateTime, _FechaRevisionHasta As DateTime)

        _SqlRandom = New Class_SQL(Cadena_ConexionSQL_Server)

        Dim _FechaServidor As DateTime = FechaDelServidor()

        Consulta_sql = "Select Top 10 Edo.IDMAEEDO,Edo.TIDO,Edo.NUDO" & vbCrLf &
                       "From [@WMS_GATEWAY_TRANSFERENCIA] Wms" & vbCrLf &
                       "Inner Join MAEEDO Edo On Edo.IDMAEEDO = Wms.IDMAEEDO" & vbCrLf &
                       "Where (CONVERT(varchar, FECHA_DOWNLOAD, 112)) = '" & Format(_FechaRevisionDesde, "yyyyMMdd") & "'" & vbCrLf &
                       "And Wms.IDMAEEDO Not In (Select Idmaeedo From " & _Global_BaseBk & "Zw_Stmp_Enc Where (CONVERT(varchar, FechaCreacion, 112)) = '" & Format(_FechaRevisionDesde, "yyyyMMdd") & "')" & vbCrLf &
                       "And Edo.SUDO = '01' And Edo.TIDO = 'NVV'"

        Dim _FechaDesde As String = Format(_FechaRevisionDesde, "yyyyMMdd")
        Dim _FechaHasta As String = Format(_FechaRevisionHasta, "yyyyMMdd")

        Consulta_sql = "Select Top 10 Edo.IDMAEEDO,Edo.TIDO,Edo.NUDO" & vbCrLf &
                       "From [@WMS_GATEWAY_TRANSFERENCIA] Wms" & vbCrLf &
                       "Inner Join MAEEDO Edo On Edo.IDMAEEDO = Wms.IDMAEEDO" & vbCrLf &
                       "Where" & vbCrLf &
                       "CONVERT(varchar, FECHA_DOWNLOAD, 112) Between '" & _FechaDesde & "' And '" & _FechaHasta & "'" & vbCrLf &
                       "And Wms.IDMAEEDO Not In (Select Idmaeedo From " & _Global_BaseBk & "Zw_Stmp_Enc Where (CONVERT(varchar, FechaCreacion, 112) Between '" & _FechaDesde & "' And '" & _FechaHasta & "'))" & vbCrLf &
                       "And Edo.SUDO = '01' And Edo.TIDO = 'NVV'"

        Dim _Tbl_wms As DataTable = _SqlRandom.Fx_Get_DataTable(Consulta_sql)

        For Each _Fila As DataRow In _Tbl_wms.Rows

            Dim _Cl_Stmp As New Cl_Stmp
            Dim _Mensaje_Stem As New LsValiciones.Mensajes

            Dim _Idmaeedo As Integer = _Fila.Item("IDMAEEDO")
            Dim _Tido As String = _Fila.Item("TIDO")
            Dim _Nudo As String = _Fila.Item("NUDO")

            Dim _Reg As Integer = _SqlRandom.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Docu_Ent",
                                                                "Empresa = '01'" &
                                                                " And Idmaeedo = " & _Idmaeedo &
                                                                " And Tido = '" & _Tido & "'" &
                                                                " And Nudo = '" & _Nudo & "'")

            If CBool(_Reg) Then

                Consulta_sql = "Update " & _Global_BaseBk & "Zw_Docu_Ent Set Estaenwms = 1" & vbCrLf &
                               "Where Idmaeedo = " & _Idmaeedo & " And Tido = '" & _Tido & "' And Nudo = '" & _Nudo & "'"
                _SqlRandom.Ej_consulta_IDU(Consulta_sql)

            Else

                Dim _NombreEquipo As String = "DiablitoWMS"
                Dim _TipoEstacion As String = "N"

                Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Docu_Ent (Idmaeedo,NombreEquipo,TipoEstacion,Empresa,Modalidad,Tido,Nudo," &
                           "FechaHoraGrab,HabilitadaFac,FunAutorizaFac,Pickear,Estaenwms)" & vbCrLf &
                           "Select IDMAEEDO,'" & _NombreEquipo & "','" & _TipoEstacion & "',EMPRESA,'?',TIDO,NUDO,LAHORA,0,'',1,1" & vbCrLf &
                           "From MAEEDO Where IDMAEEDO = " & _Idmaeedo & vbCrLf &
                           "Insert Into " & _Global_BaseBk & "Zw_Docu_Det (Idmaeddo,Idmaeedo,Tido,Nudo,Codigo,Descripcion,RtuVariable)" & vbCrLf &
                           "Select IDMAEDDO,IDMAEEDO,TIDO,NUDO,KOPRCT,NOKOPR,0" & vbCrLf &
                           "From MAEDDO Where IDMAEEDO = " & _Idmaeedo
                _SqlRandom.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql)

            End If

            _Mensaje_Stem = _Cl_Stmp.Fx_Crear_Ticket(_Idmaeedo,
                                                     _Tido,
                                                     _Nudo,
                                                     False,
                                                     _FechaServidor,
                                                     "R",
                                                     True,
                                                     "01",
                                                     "01",
                                                     "DWB",
                                                     False, 0, "")

            If _Mensaje_Stem.EsCorrecto Then
                Sb_AddToLog(_Mensaje_Stem.Detalle, _Mensaje_Stem.Mensaje, Txt_Log)
            Else
                Sb_AddToLog("Error al importar datos", _Mensaje_Stem.Mensaje, Txt_Log)
            End If

            Application.DoEvents()

        Next

    End Sub

    Sub Sb_MarcarFacturadasPorFuera(Txt_Log As Object)

        _SqlRandom = New Class_SQL(Cadena_ConexionSQL_Server)

        'Deja los documentos en Facturadas cuando ya estan listos y el diablito no alcanza a tomarlos.
        Consulta_sql = "Select Distinct Edo.IDMAEEDO,Edo.TIDO,Edo.NUDO,Edo.ENDO,Edo.SUENDO,Edo.FEEMDO," &
                       "DdoFcv.IDMAEEDO As 'IDMAEEDO_Fcv',DdoFcv.TIDO As 'TD',DdoFcv.NUDO As 'NUDO_Fcv'--,DdoFcv.FEEMLI as 'F.Cierre'" & vbCrLf &
                       "Into #PasoFacturadas" & vbCrLf &
                       "From MAEDDO Ddo" & vbCrLf &
                       "Inner Join MAEEDO Edo On Edo.IDMAEEDO = Ddo.IDMAEEDO" & vbCrLf &
                       "Inner Join MAEDDO DdoFcv on Ddo.IDMAEDDO = DdoFcv.IDRST And DdoFcv.ARCHIRST = 'MAEDDO'" & vbCrLf &
                       "Where Edo.IDMAEEDO In (Select Idmaeedo From " & _Global_BaseBk & "Zw_Stmp_Enc " &
                       "Where Estado In ('PREPA','COMPL'))" & vbCrLf &
                       "Order By Edo.TIDO,Edo.NUDO" & vbCrLf &
                        vbCrLf &
                       "Update " & _Global_BaseBk & "Zw_Stmp_Enc Set Estado = 'FACTU',Facturar = 1,IdmaeedoGen = Ps.IDMAEEDO_Fcv,TidoGen = Ps.TD,NudoGen = Ps.NUDO_Fcv" & vbCrLf &
                       "From " & _Global_BaseBk & "Zw_Stmp_Enc Enc" & vbCrLf &
                       "Inner Join #PasoFacturadas Ps On Enc.Idmaeedo = Ps.IDMAEEDO" & vbCrLf &
                       "Drop Table #PasoFacturadas"

        _SqlRandom.Ej_consulta_IDU(Consulta_sql)

    End Sub

    Function Fx_EnviarAImprimirListaDeVerificacion(_Idmaeedo As Integer,
                                                    _Tido As String,
                                                    _Nudo As String,
                                                    _Impreso As Boolean,
                                                    _NombreEquipo As String,
                                                    _Impresora As String,
                                                    _NombreFormato As String) As LsValiciones.Mensajes

        _SqlRandom = New Class_SQL(Cadena_ConexionSQL_Server)
        Dim _Mensaje As New LsValiciones.Mensajes

        'Dim _NombreEquipo As String = "VILLARSERVERCOR"
        'Dim _Impresora As String = "Despacho1_B1"
        'Dim _NombreFormato As String = "Lista verificacion WMS con Picking" '"Lista verificacion WMS"

        Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Demonio_Doc_Emitidos_Cola_Impresion (NombreEquipo,Idmaeedo,Tido,Nudo,Funcionario,Fecha,NombreFormato,Impresora,Impreso)" & vbCrLf &
                       "Values ('" & _NombreEquipo & "'," & _Idmaeedo & ",'" & _Tido & "','" & _Nudo & "','wms',GETDATE(),'" & _NombreFormato & "','" & _Impresora & "'," & Convert.ToInt32(_Impreso) & ")"

        If _SqlRandom.Ej_consulta_IDU(Consulta_sql, False) Then
            _Mensaje.EsCorrecto = True
            _Mensaje.Detalle = "Imprimir documento completado"
            _Mensaje.Mensaje = "Se envia correctamente el documento: " & _Tido & " - " & _Nudo & " a imprimir."
        Else
            _Mensaje.Detalle = "Problema al imprimir."
            _Mensaje.Mensaje = _SqlRandom.Pro_Error
        End If

        Return _Mensaje

    End Function

    Sub Sb_RevisarCompletadasCanceladas(Txt_Log As Object)

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Stmp_Enc Where (Estado = 'COMPL')"
        Dim _Tbl As DataTable = _SqlRandom.Fx_Get_DataTable(Consulta_sql)

        For Each _Fila As DataRow In _Tbl.Rows

            Dim _Id_Enc As Integer = _Fila.Item("Id")
            Dim _Idmaeedoo As Integer = _Fila.Item("Idmaeedo")
            Dim _Nudo As String = _Fila.Item("Nudo")
            Dim _Estado As String = _Fila.Item("Estado")


            Consulta_sql = "Select TOP 1 trans_act_mod,dt_start from viaware.dbo.history_master where oid='" & _Nudo & "' and trans_act='STAT' Order by trans_seq_num Desc"
            Dim _RowPlanificada As DataRow = _SqlWms.Fx_Get_DataRow(Consulta_sql)

            Dim _trans_act_mod As String

            If IsNothing(_RowPlanificada) Then
                _trans_act_mod = "XXX"
            Else
                _trans_act_mod = _RowPlanificada.Item("trans_act_mod").ToString.Trim '='RDY'
            End If

            If _trans_act_mod = "CANCEL" Then

                Consulta_sql = "Update " & _Global_BaseBk & "Zw_Stmp_Enc Set Estado ='CANCE'" & vbCrLf &
                               "Where Id = " & _Id_Enc
                _SqlRandom.Ej_consulta_IDU(Consulta_sql)

                Sb_AddToLog("Sincronizando notas", "NVV" & _Nudo & " - Cancelada", Txt_Log)

            End If

        Next

    End Sub

    Sub Sb_RevisarCanceladasLiberadas(Txt_Log As Object, _FechaRevision As DateTime)

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Stmp_Enc Where Estado = 'CANCE' And CONVERT(varchar, FechaCreacion, 112) = '" & Format(_FechaRevision, "yyyyMMdd") & "'"
        Dim _Tbl As DataTable = _SqlRandom.Fx_Get_DataTable(Consulta_sql)

        For Each _Fila As DataRow In _Tbl.Rows

            Dim _Id_Enc As Integer = _Fila.Item("Id")
            Dim _Idmaeedoo As Integer = _Fila.Item("Idmaeedo")
            Dim _Nudo As String = _Fila.Item("Nudo")
            Dim _Estado As String = _Fila.Item("Estado")

            Consulta_sql = "Select TOP 1 trans_act_mod,dt_start from viaware.dbo.history_master where oid='" & _Nudo & "' and trans_act='STAT' Order by trans_seq_num Desc"
            Dim _RowPlanificada As DataRow = _SqlWms.Fx_Get_DataRow(Consulta_sql)

            Dim _trans_act_mod As String

            If IsNothing(_RowPlanificada) Then
                _trans_act_mod = "XXX"
            Else
                _trans_act_mod = _RowPlanificada.Item("trans_act_mod").ToString.Trim '='RDY'
            End If

            If _trans_act_mod = "RDY" Or _trans_act_mod = "RELEASE" Then

                Consulta_sql = "Update " & _Global_BaseBk & "Zw_Stmp_Enc Set Estado ='PREPA'" & vbCrLf &
                               "Where Id = " & _Id_Enc
                _SqlRandom.Ej_consulta_IDU(Consulta_sql)

                Sb_AddToLog("Sincronizando notas", "NVV" & _Nudo & " - Liberada", Txt_Log)

            End If

            'End If

        Next

    End Sub

    Sub Sb_RevisarRezagadasSinFuncionarioQueFactura(Txt_Log As Object)

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Stmp_Enc Where Facturar = 1 And Estado = 'COMPL' And EnvFacAutoBk = 0 And CodFuncionario_Factura = ''"
        Dim _Tbl As DataTable = _SqlRandom.Fx_Get_DataTable(Consulta_sql)

        For Each _Fila As DataRow In _Tbl.Rows

            Dim _Id As Integer = _Fila.Item("Id")
            Dim _Idmaeedo As Integer = _Fila.Item("Idmaeedo")
            Dim _DocEmitir As String = _Fila.Item("DocEmitir")
            Dim _TipoPago As String = _Fila.Item("TipoPago")
            Dim _Nudo As String = _Fila.Item("Nudo")
            Dim _Accion As String = _Fila.Item("Accion")
            Dim _CodFuncionario_Factura = String.Empty

            If _DocEmitir = "BLV" Or _DocEmitir = "FCV" Then
                If _TipoPago = "Contado" Then
                    _CodFuncionario_Factura = ConfiguracionLocal.Ls_FunFcvGdvAuto.Item(0).CodFuncionario
                End If

                If _TipoPago = "Credito" Then
                    _CodFuncionario_Factura = ConfiguracionLocal.Ls_FunFcvGdvAuto.Item(1).CodFuncionario
                End If

                'Si es un pedido de B2B se redirecciona directamente hacia la impresora de creditos mediante la caja facturadora
                Dim _Reg As Integer = _SqlRandom.Fx_Cuenta_Registros("[@MGT_2_PEDIDOS]", "ID_ERP=" & _Idmaeedo, False)

                If CBool(_Reg) Then
                    _CodFuncionario_Factura = ConfiguracionLocal.Ls_FunFcvGdvAuto.Item(1).CodFuncionario
                End If

            End If

            If _DocEmitir = "GDV" Then
                _CodFuncionario_Factura = ConfiguracionLocal.Ls_FunFcvGdvAuto.Item(2).CodFuncionario
            End If

            Consulta_sql = "Update " & _Global_BaseBk & "Zw_Stmp_Enc Set CodFuncionario_Factura = '" & _CodFuncionario_Factura & "' Where Id = " & _Id
            _SqlRandom.Ej_consulta_IDU(Consulta_sql)

            Sb_AddToLog("Sincronizando notas", "NVV " & _Nudo & " - Se marca funcionario que factura = '" & _CodFuncionario_Factura & "'", Txt_Log)

            ''Imprimir Despachos
            If _Accion.Contains("O") Then

                If ConfiguracionLocal.Ls_ImpFormatos.Item(1).Imprimir Then

                    With ConfiguracionLocal.Ls_ImpFormatos.Item(1)

                        Dim _Mensaje As New LsValiciones.Mensajes

                        _Mensaje = Fx_EnviarAImprimirListaDeVerificacion(_Idmaeedo, "NVV", _Nudo, True,
                                                                          .NombreEquipoImprime, .Impresora, .NombreFormato)
                        Sb_AddToLog(_Mensaje.Detalle, _Mensaje.Detalle, Txt_Log)

                    End With

                End If

            End If

        Next

    End Sub

    Sub Sb_RevisarFacturadasConfirmadasSinCerrar(Txt_Log As Object)

        Consulta_sql = "Select Id,Idmaeedo,Numero,Nudo,Estado From " & _Global_BaseBk & "Zw_Stmp_Enc Where Estado In ('FACTU')"
        Dim _Tbl As DataTable = _SqlRandom.Fx_Get_DataTable(Consulta_sql)

        For Each _Fila As DataRow In _Tbl.Rows

            Dim _Id_Enc As Integer = _Fila.Item("Id")
            Dim _Idmaeedoo As Integer = _Fila.Item("Idmaeedo")
            Dim _Numero As String = _Fila.Item("Numero")
            Dim _Nudo As String = _Fila.Item("Nudo")
            Dim _Estado As String = _Fila.Item("Estado")

            'Dim _Reg As Integer = _SqlRandom.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Stmp_SalaEspera", "Numero = '" & _Numero & "'")

            'If CBool(_Reg) Then
            '    Continue For
            'End If

            Consulta_sql = "Select TOP 1 trans_act_mod,dt_start from viaware.dbo.history_master " & vbCrLf &
                           "where oid='" & _Nudo & "' AND (trans_class = 'OBO') AND (trans_obj = 'OBORD') AND (trans_act = 'SHIP')"
            Dim _RowConfirmada As DataRow = _SqlWms.Fx_Get_DataRow(Consulta_sql)

            Dim _dt_start As String

            If Not IsNothing(_RowConfirmada) Then

                _dt_start = Format(_RowConfirmada.Item("dt_start"), "yyyyMMdd HH:mm")

                Consulta_sql = "Update " & _Global_BaseBk & "Zw_Stmp_Enc Set Estado ='CERRA',FechaCierre = '" & _dt_start & "'" & vbCrLf &
                               "Where Id = " & _Id_Enc
                _SqlRandom.Ej_consulta_IDU(Consulta_sql)

                Sb_AddToLog("Sincronizando notas", "NVV" & _Nudo & " - Confirmada en WMS, Cerrada en Bakapp Sgem", Txt_Log)

            End If

        Next

    End Sub

    Sub Sb_ActualizarFechaPickeo(Txt_Log As Object, _FechaRevision As DateTime)

        _SqlRandom = New Class_SQL(Cadena_ConexionSQL_Server)
        _SqlWms = New Class_SQL(Cadena_ConexionSQL_Server_Wms)

        Consulta_sql = "Select Id,Idmaeedo,Numero,Nudo,Estado From " & _Global_BaseBk & "Zw_Stmp_Enc" & vbCrLf &
                       "Where Estado In ('FACTU','CERRA','COMPL') And FechaPickeoAct = 0" & vbCrLf &
                       "And CONVERT(varchar, FechaCreacion, 112) >= '" & Format(_FechaRevision, "yyyyMMdd") & "'"
        Dim _Tbl As DataTable = _SqlRandom.Fx_Get_DataTable(Consulta_sql)

        Dim _Contador = 1

        For Each _Fila As DataRow In _Tbl.Rows

            Dim _Id_Enc As Integer = _Fila.Item("Id")
            Dim _Idmaeedoo As Integer = _Fila.Item("Idmaeedo")
            Dim _Numero As String = _Fila.Item("Numero")
            Dim _Nudo As String = _Fila.Item("Nudo")
            Dim _Estado As String = _Fila.Item("Estado")

            Consulta_sql = "Select Top 1 dt_start" & vbCrLf &
                           "From history_master" & vbCrLf &
                           "Where oid = '" & _Nudo & "' And ((trans_class = 'CONT' AND trans_obj = 'OBO' AND trans_act = 'PICK' AND trans_act_mod = 'FINAL') or " &
                           "(trans_class = 'INVE' AND trans_obj = 'OBO' AND trans_act = 'PICK'))" & vbCrLf &
                           "Order By trans_seq_num Desc"
            Dim _Row As DataRow = _SqlWms.Fx_Get_DataRow(Consulta_sql)

            Dim _dt_start As String

            If Not IsNothing(_Row) Then

                _dt_start = Format(_Row.Item("dt_start"), "yyyyMMdd HH:mm:ss")

                Consulta_sql = "Update " & _Global_BaseBk & "Zw_Stmp_Enc Set FechaPickeoAct = 1,FechaPickeado = '" & _dt_start & "'" & vbCrLf &
                               "Where Id = " & _Id_Enc
                _SqlRandom.Ej_consulta_IDU(Consulta_sql)

                Sb_AddToLog("Sincronizando notas", "NVV" & _Nudo & " - Actualiza Fecha de Pickeo", Txt_Log)

            End If

            _Contador += 1

        Next

    End Sub


    'Sub Sb_RevisarIngresadasRezagadas(Txt_Log As Object)

    '    Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Stmp_Enc Where Estado In ('INGRE')"
    '    Dim _Tbl As DataTable = _SqlRandom.Fx_Get_DataTable(Consulta_sql)

    '    For Each _Fila As DataRow In _Tbl.Rows

    '        Dim _Id_Enc As Integer = _Fila.Item("Id")
    '        Dim _Idmaeedoo As Integer = _Fila.Item("Idmaeedo")
    '        Dim _Nudo As String = _Fila.Item("Nudo")
    '        Dim _Estado As String = _Fila.Item("Estado")
    '        Dim _Anular As Boolean

    '        Consulta_sql = "Select TOP 1 trans_act_mod,dt_start from viaware.dbo.history_master " & vbCrLf &
    '                       "where oid='" & _Nudo & "' AND (trans_class = 'OBO') AND (trans_obj = 'OBORD') AND (trans_act = 'DELETE')"
    '        Dim _RowEliminada As DataRow = _SqlWms.Fx_Get_DataRow(Consulta_sql)

    '        If IsNothing(_RowEliminada) Then

    '            Consulta_sql = "select Top 1 * from om_f where ob_oid = '" & _Nudo & "'"
    '            _RowEliminada = _SqlWms.Fx_Get_DataRow(Consulta_sql)

    '            If IsNothing(_RowEliminada) Then
    '                _Anular = True
    '            End If

    '        Else
    '            _Anular = True
    '        End If

    '        If _Anular Then

    '            Consulta_sql = "Update " & _Global_BaseBk & "Zw_Stmp_Enc Set Estado ='NULO'" & vbCrLf &
    '                           "Where Id = " & _Id_Enc
    '            _SqlRandom.Ej_consulta_IDU(Consulta_sql)

    '            Sb_AddToLog("Sincronizando notas", "NVV" & _Nudo & " - Anulada ya que esta eliminada en WMS", Txt_Log)

    '        End If

    '    Next

    'End Sub

End Class
