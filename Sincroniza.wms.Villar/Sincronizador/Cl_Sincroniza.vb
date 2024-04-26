Imports BkSpecialPrograms
Imports DevComponents.DotNetBar
Public Class Cl_Sincroniza

    Dim _SqlRandom As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim _SqlWms As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Public Property Cadena_ConexionSQL_Server_Wms

    Public Sub New()

        Cadena_ConexionSQL_Server_Wms = "data source = wmstest.villar.cl; initial catalog = viaware; user id = sa_wms; password = sa_wms"
        _SqlRandom = New Class_SQL(Cadena_ConexionSQL_Server)
        _SqlWms = New Class_SQL(Cadena_ConexionSQL_Server_Wms)

    End Sub

    Sub Sb_Ejecutar_Revision(Txt_Log As Object, _FechaRevision As DateTime)

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

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Stmp_Enc Where Estado = 'PREPA'"
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
            End If

            Application.DoEvents()

        Next

    End Sub

End Class
