Imports BkSpecialPrograms
Imports DevComponents.DotNetBar
Public Class Cl_Sincroniza

    Dim _SqlRandom As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim _SqlWms As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Public Property Cadena_ConexionSQL_Server_Wms

    Public Sub New()

    End Sub

    Sub Sb_Ejecutar_Revision(Txt_Log As Object, _FechaRevision As DateTime)

        _SqlRandom = New Class_SQL(Cadena_ConexionSQL_Server)
        _SqlWms = New Class_SQL(Cadena_ConexionSQL_Server_Wms)

        Consulta_sql = "Select IDMAEEDO From [@WMS_GATEWAY_TRANSFERENCIA]" & vbCrLf &
                       "Where (CONVERT(varchar, FECHA_DOWNLOAD, 112)) = '" & Format(_FechaRevision, "yyyyMMdd") & "'" & vbCrLf &
                       "And IDMAEEDO In (Select Idmaeedo From " & _Global_BaseBk & "Zw_Docu_Ent Where Pickear = 1 And Estaenwms = 0)"
        Dim _Tbl_wms As DataTable = _SqlRandom.Fx_Get_Tablas(Consulta_sql)
        Dim _Filtro As String = Generar_Filtro_IN(_Tbl_wms, "", "IDMAEEDO", True, False, "")

        If _Filtro <> "()" Then
            Consulta_sql = "Update " & _Global_BaseBk & "Zw_Docu_Ent Set Estaenwms = 1 Where Tido = 'NVV' And Idmaeedo In " & _Filtro
            If _SqlRandom.Ej_consulta_IDU(Consulta_sql, False) Then
                Sb_AddToLog("Sincronizando notas", "Se actualizan " & _Tbl_wms.Rows.Count & " registro(s) en tabla Zw_Docu_Ent, campo Estaenwms = 1", Txt_Log)
            Else
                Sb_AddToLog("Sincronizando notas", "¡¡¡Problema al revisar si notas existen en WMS!!!", Txt_Log)
            End If
        End If

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Stmp_Enc Where Estado = 'PREPA' --And Numero = '#T00000569'"
        Dim _Tbl As DataTable = _SqlRandom.Fx_Get_Tablas(Consulta_sql)

        For Each _Fila As DataRow In _Tbl.Rows

            Dim _Id_Enc As Integer = _Fila.Item("Id")
            Dim _Idmaeedoo As Integer = _Fila.Item("Idmaeedo")
            Dim _Nudo As String = _Fila.Item("Nudo")

            'Sb_AddToLog("Sincronizando notas", "Revisando NVV" & _Nudo, Txt_Log)

            Dim _Cl_Stmp As New Cl_Stmp
            _Cl_Stmp.Fx_Llenar_Encabezado(_Id_Enc)
            _Cl_Stmp.Fx_Llenar_Detalle(_Id_Enc)

            _Cl_Stmp.Zw_Stmp_Enc.Fecha_Facturar = FechaDelServidor()

            Dim _Mensaje As New LsValiciones.Mensajes

            _Mensaje = _Cl_Stmp.Fx_Revisar_WMSVillar(_Idmaeedoo, _Nudo, Cadena_ConexionSQL_Server_Wms)

            If _Mensaje.EsCorrecto Then

                _Mensaje.Detalle += ", Nota de venta #" & _Nudo
                Sb_AddToLog("Sincronizando notas", _Mensaje.Detalle, Txt_Log)

                _Mensaje = Fx_EnviarAImprimnirListaDeVerificacion(_Idmaeedoo, "NVV", _Nudo, True)

                Sb_AddToLog(_Mensaje.Detalle, _Mensaje.Detalle, Txt_Log)

            End If

            Application.DoEvents()

        Next

    End Sub

    Sub Sb_Ejecutar_Revision_IncorporarNVVAutomaticamenteAStem(Txt_Log As Object, _FechaRevision As DateTime)

        _SqlRandom = New Class_SQL(Cadena_ConexionSQL_Server)

        Dim _FechaServidor As DateTime = FechaDelServidor()

        Consulta_sql = "Select Top 10 Edo.IDMAEEDO,Edo.TIDO,Edo.NUDO" & vbCrLf &
                       "From [@WMS_GATEWAY_TRANSFERENCIA] Wms" & vbCrLf &
                       "Inner Join MAEEDO Edo On Edo.IDMAEEDO = Wms.IDMAEEDO" & vbCrLf &
                       "Where (CONVERT(varchar, FECHA_DOWNLOAD, 112)) = '" & Format(_FechaRevision, "yyyyMMdd") & "'" & vbCrLf &
                       "And Wms.IDMAEEDO Not In (Select Idmaeedo From " & _Global_BaseBk & "Zw_Stmp_Enc Where (CONVERT(varchar, FechaCreacion, 112)) = '" & Format(_FechaRevision, "yyyyMMdd") & "')" & vbCrLf &
                       "And Edo.SUDO = '01' And Edo.TIDO = 'NVV'"
        Dim _Tbl_wms As DataTable = _SqlRandom.Fx_Get_Tablas(Consulta_sql)

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
                                     "DWB")

            If _Mensaje_Stem.EsCorrecto Then
                Sb_AddToLog(_Mensaje_Stem.Detalle, _Mensaje_Stem.Mensaje, Txt_Log)
            Else
                Sb_AddToLog("Error al importar datos", _Mensaje_Stem.Mensaje, Txt_Log)
            End If

            Application.DoEvents()

        Next

    End Sub

    Sub Sb_MarcarFacturadasPorFuera(Txt_Log As Object, _FechaRevision As DateTime)

        _SqlRandom = New Class_SQL(Cadena_ConexionSQL_Server)

        'Deja los documentos en Facturadas cuando ya estan listos y el diablito no alcanza a tomarlos.
        Consulta_sql = "Select Distinct Edo.IDMAEEDO,Edo.TIDO,Edo.NUDO,Edo.ENDO,Edo.SUENDO,Edo.FEEMDO," &
                       "DdoFcv.IDMAEEDO As 'IDMAEEDO_Fcv',DdoFcv.TIDO As 'TD',DdoFcv.NUDO As 'NUDO_Fcv'--,DdoFcv.FEEMLI as 'F.Cierre'" & vbCrLf &
                       "Into #PasoFacturadas" & vbCrLf &
                       "From MAEDDO Ddo" & vbCrLf &
                       "Inner Join MAEEDO Edo On Edo.IDMAEEDO = Ddo.IDMAEEDO" & vbCrLf &
                       "Inner Join MAEDDO DdoFcv on Ddo.IDMAEDDO = DdoFcv.IDRST And DdoFcv.ARCHIRST = 'MAEDDO'" & vbCrLf &
                       "Where Edo.IDMAEEDO In (Select Idmaeedo From " & _Global_BaseBk & "Zw_Stmp_Enc " &
                       "Where Estado In ('PREPA','COMPL') And CONVERT(varchar, FechaCreacion, 112) = '" & Format(_FechaRevision, "yyyyMMdd") & "')" & vbCrLf &
                       "Order By Edo.TIDO,Edo.NUDO" & vbCrLf &
                        vbCrLf &
                       "Update " & _Global_BaseBk & "Zw_Stmp_Enc Set Estado = 'FACTU',Facturar = 1,IdmaeedoGen = Ps.IDMAEEDO_Fcv,TidoGen = Ps.TD,NudoGen = Ps.NUDO_Fcv" & vbCrLf &
                       "From " & _Global_BaseBk & "Zw_Stmp_Enc Enc" & vbCrLf &
                       "Inner Join #PasoFacturadas Ps On Enc.Idmaeedo = Ps.IDMAEEDO" & vbCrLf &
                       "Drop Table #PasoFacturadas"

        _SqlRandom.Ej_consulta_IDU(Consulta_sql)

    End Sub

    Function Fx_EnviarAImprimnirListaDeVerificacion(_Idmaeedo As Integer,
                                                    _Tido As String,
                                                    _Nudo As String,
                                                    _Impreso As Boolean) As LsValiciones.Mensajes

        _SqlRandom = New Class_SQL(Cadena_ConexionSQL_Server)
        Dim _Mensaje As New LsValiciones.Mensajes

        Dim _NombreEquipo As String = "VILLARSERVERCOR"
        Dim _Impresora As String = "Despacho1_B1"
        Dim _NombreFormato As String = "Lista verificacion WMS"

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


End Class
