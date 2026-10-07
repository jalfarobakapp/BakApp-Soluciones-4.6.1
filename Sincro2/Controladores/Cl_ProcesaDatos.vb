Imports System.Data.SqlClient
Imports System.Text
Imports BkSpecialPrograms
Imports BkSpecialPrograms.LsValiciones
Imports DevComponents.DotNetBar

Public Class Cl_ProcesaDatos
    Dim Consulta_sql As String
    Public Property DirectorioActual As String
    Public Property NombreArchivo_Configuracion As String
    Public Property Configuracion As Configuracion

    Public Property Empresa01 As Empresa
    Public Property Empresa02 As Empresa

    Public Property Global_BaseBk As String

    Public Function Fx_RellenarInterStockCredito(Txt_Log As Object) As Mensajes
        Dim _Mensaje As New Mensajes
        _Mensaje.EsCorrecto = False

        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)

        Try
            ' MODIFICADO: Se cambia al acceso estructurado por Empresa01 y Empresa02
            Dim tablas() As DataTable = {
                Empresa01.EntidadDeCompra,
                Empresa02.EntidadDeCompra,
                Empresa01.EntidadDeVenta,
                Empresa02.EntidadDeVenta
            }

            Dim codigosExcluir As New HashSet(Of String)()

            'For Each dt As DataTable In tablas
            '    If dt IsNot Nothing AndAlso dt.Columns.Contains("codigo") Then
            '        For Each row As DataRow In dt.Rows
            '            If Not IsDBNull(row("codigo")) Then
            '                Dim codigo As String = row("Codigo").ToString().Trim().Replace("'", "''")
            '                If Not String.IsNullOrEmpty(codigo) Then
            '                    codigosExcluir.Add(codigo)
            '                End If
            '            End If
            '        Next
            '    End If
            'Next

            Dim filtroExclusion As String = ""

            filtroExclusion = $"WHERE ENDO NOT In ('77988832','77988832-0','76095906-5','76095906')"
            'If codigosExcluir.Count > 0 Then
            '    filtroExclusion = $"WHERE ENDO NOT IN ('{String.Join("','", codigosExcluir)}')"
            'End If

            Dim Consulta_Select As String = GenerarConsultaSelectInterStockCredito(filtroExclusion)
            Dim _Tbl_Datos As DataTable = _Sql.Fx_Get_DataTable(Consulta_Select, False)

            If IsNothing(_Tbl_Datos) Then Throw New Exception("No se pudo obtener la tabla de datos inicial de credito.")

            If _Tbl_Datos.Rows.Count = 0 Then
                _Mensaje.EsCorrecto = True
                _Mensaje.Detalle = "Sin documentos nuevos por procesar."
                _Mensaje.Mensaje = "OK."
                LogSeguro("Demonio SincroStock", "No hay facturas nuevas para evaluar stock.", Txt_Log)
                Return _Mensaje
            End If

            Dim _CantidadDocumentos As Integer = _Tbl_Datos.DefaultView.ToTable(True, "IDMAEEDO").Rows.Count
            LogSeguro("Demonio SincroStock", $"Se encontraron {_CantidadDocumentos} documento(s) de credito nuevo(s) para evaluar.", Txt_Log)

            Dim _Consultas_Insert As New StringBuilder()
            _Consultas_Insert.AppendLine("DECLARE @Id_Enc INT;")

            Dim _Idmaeedo_Actual As Integer = 0

            For Each Fila As DataRow In _Tbl_Datos.Rows
                Dim _Idmaeedo As Integer = Fila("IDMAEEDO")
                Dim _Nudo As String = Fila("NUDO").ToString()

                If _Idmaeedo <> _Idmaeedo_Actual Then
                    Dim _EmpresaDoc As String = Fila("EMPRESA").ToString()
                    LogSeguro("Demonio SincroStock", $"Procesando documento {_Nudo} de la empresa {_EmpresaDoc}", Txt_Log)

                    ConstruirInsertEncabezadoCredito(_Consultas_Insert, Fila, _Idmaeedo, _EmpresaDoc, _Nudo)
                    _Idmaeedo_Actual = _Idmaeedo
                End If

                ConstruirInsertDetalleCredito(_Consultas_Insert, Fila, _Idmaeedo, _Nudo)
            Next

            ConstruirUpdateProcesar(_Consultas_Insert)

            Dim EjecucionCorrecta As Boolean = _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(_Consultas_Insert.ToString(), False)

            If EjecucionCorrecta Then
                _Mensaje.EsCorrecto = True
                _Mensaje.Detalle = $"Se procesaron {_Tbl_Datos.Rows.Count} líneas de detalle en total."
                _Mensaje.Mensaje = "OK."
                LogSeguro("Demonio SincroStock", "Fin del procesamiento de documentos de credito con éxito.", Txt_Log)
            Else
                Throw New Exception("La transacción de Inserción falló en SQL Server.")
            End If

        Catch ex As Exception
            _Mensaje.EsCorrecto = False
            _Mensaje.Detalle = "Fallo en la ejecución: " & ex.Message
            _Mensaje.Mensaje = "ERROR."
            LogSeguro("Demonio SincroStock", "ERROR CRÍTICO: " & ex.Message, Txt_Log)
        Finally
            If _Sql IsNot Nothing Then _Sql.Sb_Cerrar_Conexion2() ' Opcional: Cerrar explícitamente si aplica
        End Try

        Return _Mensaje
    End Function

    Public Function Fx_RellenarInterStock(Txt_Log As Object) As Mensajes
        Dim _Mensaje As New Mensajes
        _Mensaje.EsCorrecto = False

        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)

        Try
            ' MODIFICADO: Se cambia al acceso estructurado por Empresa01 y Empresa02
            Dim tablas() As DataTable = {
                Empresa01.EntidadDeCompra,
                Empresa02.EntidadDeCompra,
                Empresa01.EntidadDeVenta,
                Empresa02.EntidadDeVenta
            }

            Dim codigosExcluir As New HashSet(Of String)()

            For Each dt As DataTable In tablas
                If dt IsNot Nothing AndAlso dt.Columns.Contains("codigo") Then
                    For Each row As DataRow In dt.Rows
                        If Not IsDBNull(row("codigo")) Then
                            Dim codigo As String = row("Codigo").ToString().Trim().Replace("'", "''")
                            If Not String.IsNullOrEmpty(codigo) Then
                                codigosExcluir.Add(codigo)
                            End If
                        End If
                    Next
                End If
            Next

            Dim filtroExclusion As String = ""

            filtroExclusion = $"WHERE ENDO NOT In ('77988832','77988832-0','76095906-5','76095906')"
            'If codigosExcluir.Count > 0 Then
            '    filtroExclusion = $"WHERE ENDO NOT IN ('{String.Join("','", codigosExcluir)}')"
            'End If

            Dim Consulta_Select As String = GenerarConsultaSelectInterStock(filtroExclusion)
            Dim _Tbl_Datos As DataTable = _Sql.Fx_Get_DataTable(Consulta_Select, False)

            If IsNothing(_Tbl_Datos) Then Throw New Exception("No se pudo obtener la tabla de datos inicial.")

            If _Tbl_Datos.Rows.Count = 0 Then
                _Mensaje.EsCorrecto = True
                _Mensaje.Detalle = "Sin documentos nuevos por procesar."
                _Mensaje.Mensaje = "OK."
                LogSeguro("Demonio SincroStock", "No hay facturas nuevas para evaluar stock.", Txt_Log)
                Return _Mensaje
            End If

            Dim _CantidadDocumentos As Integer = _Tbl_Datos.DefaultView.ToTable(True, "IDMAEEDO").Rows.Count
            LogSeguro("Demonio SincroStock", $"Se encontraron {_CantidadDocumentos} documento(s) nuevo(s) para evaluar.", Txt_Log)

            Dim _Consultas_Insert As New StringBuilder()
            _Consultas_Insert.AppendLine("DECLARE @Id_Enc INT;")

            Dim _Idmaeedo_Actual As Integer = 0

            For Each Fila As DataRow In _Tbl_Datos.Rows
                Dim _Idmaeedo As Integer = Fila("IDMAEEDO")
                Dim _Nudo As String = Fila("NUDO").ToString()

                If _Idmaeedo <> _Idmaeedo_Actual Then
                    Dim _EmpresaDoc As String = Fila("EMPRESA").ToString()
                    LogSeguro("Demonio SincroStock", $"Procesando documento {_Nudo} de la empresa {_EmpresaDoc}", Txt_Log)

                    ConstruirInsertEncabezado(_Consultas_Insert, Fila, _Idmaeedo, _EmpresaDoc, _Nudo)
                    _Idmaeedo_Actual = _Idmaeedo
                End If

                ConstruirInsertDetalle(_Consultas_Insert, Fila, _Idmaeedo, _Nudo)
            Next

            ConstruirUpdateProcesar(_Consultas_Insert)

            Dim EjecucionCorrecta As Boolean = _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(_Consultas_Insert.ToString(), False)

            If EjecucionCorrecta Then
                _Mensaje.EsCorrecto = True
                _Mensaje.Detalle = $"Se procesaron {_Tbl_Datos.Rows.Count} líneas de detalle en total."
                _Mensaje.Mensaje = "OK."
                LogSeguro("Demonio SincroStock", "Fin del procesamiento de documentos con éxito.", Txt_Log)
            Else
                Throw New Exception("La transacción de Inserción falló en SQL Server.")
            End If

        Catch ex As Exception
            _Mensaje.EsCorrecto = False
            _Mensaje.Detalle = "Fallo en la ejecución: " & ex.Message
            _Mensaje.Mensaje = "ERROR."
            LogSeguro("Demonio SincroStock", "ERROR CRÍTICO: " & ex.Message, Txt_Log)
        Finally
            If _Sql IsNot Nothing Then _Sql.Sb_Cerrar_Conexion2() ' Opcional: Cerrar explícitamente si aplica
        End Try

        Return _Mensaje
    End Function
    Public Function Fx_GenerarNCC(_Formulario As Form, _Idmaeedo_Origen As Integer, _Empresa As Empresa, Txt_Log As Object, idEnc As String, nudo As String) As LsValiciones.Mensajes
        Dim _Mensaje As New LsValiciones.Mensajes

        Try

            Dim empresa As String = _Empresa.Numero
            Dim fechaEmision As DateTime = ObtenerFecha(idEnc)
            Dim _Modalidad As String = _Empresa.ModalidadFCV.Rows(0).Item("Codigo").ToString().Trim()
            Dim query As String = $"
            select top 1 Id_Enc from {Global_BaseBk}Zw_InterStock_Det where Idmaeedo_FCC = {_Idmaeedo_Origen} and Tido = 'FCV'
"

            Dim _Tido_Destino As String = "NCC"
            CambioEmpresa(empresa, _Modalidad)
            Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)

            Dim Id_Enc_FCV As Integer = _Sql.Fx_Get_DataRow(query).Item("Id_Enc")
            _Mensaje = Fx_Crear_Documento_Desde_Otro_Automaticamente_SincroStock_NCC(idEnc, Id_Enc_FCV, _Formulario, _Tido_Destino, _Idmaeedo_Origen, fechaEmision, empresa, _Modalidad, False, nudo)

            If _Mensaje.EsCorrecto Then
                Consulta_sql = $"SELECT * FROM MAEEDO WHERE IDMAEEDO = {_Mensaje.Id}"
                Dim _Docummento As DataSet = _Sql.Fx_Get_DataSet(Consulta_sql, True, False)

                _Mensaje.Tag = _Docummento.Tables(0).Rows(0).Item("NUDO").ToString()
                LogSeguro("Demonio SincroStock", $"NCC creada correctamente con Numero de documento: { _Mensaje.Tag}", Txt_Log)
                LogSeguro("Demonio SincroStock", $"Proceso NCC finalizado correctamente con IDMAEEDO: {_Mensaje.Id}.", Txt_Log)
            Else
                LogSeguro("Demonio SincroStock", $"Proceso NCC fallido { _Mensaje.Mensaje}.", Txt_Log)
                Return _Mensaje
            End If

            ActualizarVinculoSincroStockNCC(_Mensaje.Id, idEnc, Txt_Log)

        Catch ex As Exception
            _Mensaje.EsCorrecto = False
            _Mensaje.Detalle = "Excepción no controlada al generar NCC."
            _Mensaje.Mensaje = ex.Message
            LogSeguro("Demonio SincroStock", "Error GenerarNCC: " & ex.Message, Txt_Log)
        Finally
            ' Agregar limpieza aquí si se reservó memoria extra
        End Try

        Return _Mensaje
    End Function

    Public Function Fx_GenerarNCV(_Formulario As Form, _Idmaeedo_Origen As Integer, _Empresa As Empresa, Txt_Log As Object, idEnc As String) As LsValiciones.Mensajes
        Dim _Mensaje As New LsValiciones.Mensajes

        Try

            Dim empresa As String = _Empresa.Numero
            Dim fechaEmision As DateTime = ObtenerFecha(idEnc)
            Dim _Modalidad As String = _Empresa.ModalidadFCV.Rows(0).Item("Codigo").ToString().Trim()
            Dim query As String = $"
            select top 1 Id_Enc from {Global_BaseBk}Zw_InterStock_Det where Idmaeedo_FCV = {_Idmaeedo_Origen} AND Tido = 'FCV'
"

            Dim _Tido_Destino As String = "NCV"
            CambioEmpresa(empresa, _Modalidad)
            Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)

            Dim Id_Enc_FCV As Integer = _Sql.Fx_Get_DataRow(query).Item("Id_Enc")
            _Mensaje = Fx_Crear_Documento_Desde_Otro_Automaticamente_SincroStock_NCV(idEnc, Id_Enc_FCV, _Formulario, _Tido_Destino, _Idmaeedo_Origen, fechaEmision, empresa, _Modalidad, False)

            If _Mensaje.EsCorrecto Then
                Consulta_sql = $"SELECT * FROM MAEEDO WHERE IDMAEEDO = {_Mensaje.Id}"
                Dim _Docummento As DataSet = _Sql.Fx_Get_DataSet(Consulta_sql, True, False)

                _Mensaje.Tag = _Docummento.Tables(0).Rows(0).Item("NUDO").ToString()
                LogSeguro("Demonio SincroStock", $"NCV creada correctamente con Numero de documento: { _Mensaje.Tag}", Txt_Log)
                LogSeguro("Demonio SincroStock", $"Proceso NCV finalizado correctamente con IDMAEEDO: {_Mensaje.Id}.", Txt_Log)
            Else
                LogSeguro("Demonio SincroStock", $"Proceso NCV fallido { _Mensaje.Mensaje}.", Txt_Log)
                Return _Mensaje
            End If

            ActualizarVinculoSincroStockNCV(_Mensaje.Id, idEnc, Txt_Log)

        Catch ex As Exception
            _Mensaje.EsCorrecto = False
            _Mensaje.Detalle = "Excepción no controlada al generar NCV."
            _Mensaje.Mensaje = ex.Message
            LogSeguro("Demonio SincroStock", "Error GenerarNCV: " & ex.Message, Txt_Log)
        Finally
            ' Agregar limpieza aquí si se reservó memoria extra
        End Try

        Return _Mensaje
    End Function
    Public Function Fx_GenerarFCV(_Formulario As Form, _Idmaeedo_Origen As Integer, _Empresa As Empresa, Txt_Log As Object, idEnc As String) As LsValiciones.Mensajes
        Dim _Mensaje As New LsValiciones.Mensajes

        Try

            Dim empresa As String = _Empresa.Numero
            Dim fechaEmision As DateTime = ObtenerFecha(idEnc)
            Dim _Modalidad As String = _Empresa.ModalidadFCV.Rows(0).Item("Codigo").ToString().Trim()
            Dim _Tido_Destino As String = "FCV"
            CambioEmpresa(empresa, _Modalidad)
            Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)

            _Mensaje = Fx_Crear_Documento_Desde_Otro_Automaticamente_SincroStock(idEnc, _Formulario, _Tido_Destino, _Idmaeedo_Origen, fechaEmision, empresa, _Modalidad, False)

            If _Mensaje.EsCorrecto Then
                Consulta_sql = $"SELECT * FROM MAEEDO WHERE IDMAEEDO = {_Mensaje.Id}"
                Dim _Docummento As DataSet = _Sql.Fx_Get_DataSet(Consulta_sql, True, False)

                _Mensaje.Tag = _Docummento.Tables(0).Rows(0).Item("NUDO").ToString()
                LogSeguro("Demonio SincroStock", $"FCV creada correctamente con Numero de documento: { _Mensaje.Tag}", Txt_Log)
                LogSeguro("Demonio SincroStock", $"Proceso FCV finalizado correctamente con IDMAEEDO: {_Mensaje.Id}.", Txt_Log)
            Else
                LogSeguro("Demonio SincroStock", $"Proceso FCV fallido { _Mensaje.Mensaje}.", Txt_Log)
                Return _Mensaje
            End If

            ActualizarVinculoSincroStockFCV(_Mensaje.Id, _Idmaeedo_Origen, Txt_Log)

        Catch ex As Exception
            _Mensaje.EsCorrecto = False
            _Mensaje.Detalle = "Excepción no controlada al generar FCV."
            _Mensaje.Mensaje = ex.Message
            LogSeguro("Demonio SincroStock", "Error GenerarFCV: " & ex.Message, Txt_Log)
        Finally
            ' Agregar limpieza aquí si se reservó memoria extra
        End Try

        Return _Mensaje
    End Function
    Function VerificaRelacion(id_enc As Integer, tido As String, ByRef nudo_encontrado As String, ByRef idmaeedo_encontrado As String) As Boolean
        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)

        ' Usando exactamente tu consulta para buscar si el documento ya se registró
        Dim consulta As String = $"SELECT Nudo, Idmaeedo FROM {Global_BaseBk}Zw_Docu_Ent WHERE Id_Enc_InterStock = {id_enc} and Tido = '{tido}'"

        Dim tbl As DataTable = _Sql.Fx_Get_DataSet(consulta, True, False).Tables(0)

        ' Verificamos si la consulta devolvió resultados
        If tbl IsNot Nothing AndAlso tbl.Rows.Count > 0 Then
            ' Extraemos los datos de la primera fila encontrada
            nudo_encontrado = tbl.Rows(0)("Nudo").ToString()
            idmaeedo_encontrado = tbl.Rows(0)("Idmaeedo").ToString()
            Return True ' El documento ya existe
        End If

        ' Si no encontró nada, no hay documento previo
        Return False
    End Function
    Function ActualizarVinculoSincroStock(id_enc As Integer, tido As String, nudo As String) As Boolean
        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
        Dim consulta As String = $"UPDATE {_Global_BaseBk}Zw_Docu_Ent SET Tido = '{tido}', Nudo = '{nudo}' WHERE Id_Enc_InterStock = {id_enc}"
        Try
            _Sql.Ej_consulta_IDU(consulta, False)
            Return True
        Catch ex As Exception
            ' Manejo de errores si es necesario
            Return False
        End Try
    End Function
    Function Fx_Crear_Documento_Desde_Otro_Automaticamente_SincroStock(Id_Enc As Integer,
                                                                      _Formulario As Form,
                                                                       _Tido_Destino As String,
                                                                       _Idmaeedo_Origen As Integer,
                                                                       _Fecha_Emision As DateTime,
                                                                       _Empresa As String,
                                                                       _Modalidad As String,
                                                                       _CerrarDespFact As Boolean) As LsValiciones.Mensajes

        Dim _Mensaje As New LsValiciones.Mensajes
        Dim _Modalidad_Old = Mod_Modalidad
        Dim Fm_Post As Frm_Formulario_Documento = Nothing

        Try
            Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
            Dim _Reg As Integer = _Sql.Fx_Cuenta_Registros("CONFIEST", "MODALIDAD = '" & _Modalidad & "'", False)

            If _Reg = 0 Then Throw New System.Exception("No existe la modalidad " & _Modalidad)

            Dim _RowFormato As DataRow = Fx_Formato_Modalidad(_Formulario, _Empresa, _Modalidad, _Tido_Destino, False)
            If IsNothing(_RowFormato) Then Throw New System.Exception("No existe formato de documento para la modalidad")

            Consulta_sql = "Select * From MAEEDO Where IDMAEEDO = " & _Idmaeedo_Origen
            Dim _Row_Documento As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql, False)

            Dim _Msj_GrabarDoc As New LsValiciones.Mensajes

            If Not IsNothing(_Row_Documento) Then
                Dim _Meardo = _Row_Documento.Item("MEARDO")
                Dim _Tido = _Row_Documento.Item("TIDO")
                Dim _Nudo = _Row_Documento.Item("NUDO")

                Dim _Msj_Tsc As LsValiciones.Mensajes = Fx_Revisar_Tasa_Cambio(Nothing, _Fecha_Emision,, False)
                If Not _Msj_Tsc.EsCorrecto Then
                    _Mensaje.ErrorDeConexionSQL = _Msj_Tsc.ErrorDeConexionSQL
                    Throw New System.Exception(_Mensaje.Mensaje)
                End If

                If Not Fx_Se_Puede_Trasladar_Para_Crear_Otro_Documento(_Idmaeedo_Origen) Then
                    Throw New System.Exception("Nota de venta Nro: " & _Nudo & " se encuentra cerrado completamente")
                End If

                Dim _CampoPrecio As String = If(_Meardo = "N", "PPPRNE", "PPPRBR")

                Consulta_sql = "Select * From MAEEDO Where IDMAEEDO = " & _Idmaeedo_Origen & vbCrLf &
                            "Select *,Case When UDTRPR = 1 Then CAPRCO1-CAPREX1 ELSE CAPRCO2-CAPREX2 End As 'Cantidad'," & vbCrLf &
                            "CAPRCO1-CAPREX1 As 'CantUd1_Dori',CAPRCO2-CAPREX2 As 'CantUd2_Dori'," & vbCrLf &
                            "Case WHEN UDTRPR = 1 Then " & _CampoPrecio & " Else " & _CampoPrecio & "*RLUDPR End AS 'Precio'," & vbCrLf &
                            "0 As Id_Oferta,'' As Oferta,0 As Es_Padre_Oferta,0 As Padre_Oferta,0 As Hijo_Oferta,0 As Cantidad_Oferta,0 As Porcdesc_Oferta" & vbCrLf &
                            "From MAEDDO  With ( NOLOCK )" & vbCrLf &
                            "Where IDMAEEDO = " & _Idmaeedo_Origen & "  AND ( ESLIDO<>'C' OR ESFALI='I' ) AND TICT = ''" & vbCrLf &
                            "Order by IDMAEEDO,IDMAEDDO" & vbCrLf &
                            "Select * From MAEIMLI Where IDMAEEDO = " & _Idmaeedo_Origen & vbCrLf &
                            "Select * From MAEDTLI Where IDMAEEDO = " & _Idmaeedo_Origen & vbCrLf &
                            "Select TOP 1 * From MAEEDOOB Where IDMAEEDO = " & _Idmaeedo_Origen

                Dim _Ds_Maeedo_Origen As DataSet = _Sql.Fx_Get_DataSet(Consulta_sql, True, False)

                Mod_Modalidad = _Modalidad

                Fm_Post = New Frm_Formulario_Documento(_Tido_Destino, csGlobales.Enum_Tipo_Documento.Venta, False,,,,,, True)
                Fm_Post.Sb_Limpiar(_Modalidad)

                Fm_Post.Sb_Crear_Documento_Desde_Otros_Documentos(_Formulario, _Ds_Maeedo_Origen, False, False, _Fecha_Emision, False, True, Id_Enc_InterStock:=Id_Enc)

                _Msj_GrabarDoc = Fm_Post.Fx_Grabar_Documento(False, csGlobales.Mod_Enum_Listados_Globales.Enum_Tipo_de_Grabacion.Nuevo_documento, True, False,,, False)

                If _Msj_GrabarDoc.EsCorrecto Then
                    Fm_Post.Sb_Activar_Orden_De_Despacho(_Msj_GrabarDoc.Id)
                End If
            End If

            If _Msj_GrabarDoc.EsCorrecto Then
                Consulta_sql = "Select * From MAEEDO Where IDMAEEDO = " & _Msj_GrabarDoc.Id
                Dim _Row As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql, False)

                _Mensaje.EsCorrecto = True
                _Mensaje.Detalle = "Documento: " & _Row.Item("TIDO") & "-" & _Row.Item("NUDO") & " grabado con exito"
                _Mensaje.Mensaje = "Nota de venta gestionada correctamente Ok."
                _Mensaje.Id = _Msj_GrabarDoc.Id
                _Mensaje.Tag = _Row
            Else
                _Mensaje = _Msj_GrabarDoc
            End If

        Catch ex As Exception
            _Mensaje.EsCorrecto = False
            _Mensaje.Detalle = "Error al grabar documento"
            _Mensaje.Mensaje = ex.Message
        Finally
            If Fm_Post IsNot Nothing Then Fm_Post.Dispose()
            Mod_Modalidad = _Modalidad_Old
        End Try

        Return _Mensaje
    End Function
    Function Fx_Se_Puede_Trasladar_Para_Crear_Otro_Documento_Credito(_Idmaeedo As Integer) As Boolean

        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)

        Consulta_sql = "SELECT *
                        FROM MAEDDO  WITH ( NOLOCK ) 
                        WHERE IDMAEEDO =  " & _Idmaeedo

        Dim _Tbl_Saldo_Facturar As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql, False)

        If Not String.IsNullOrEmpty(_Sql.Pro_Error) Then
            Return False
        End If

        Return CBool(_Tbl_Saldo_Facturar.Rows.Count)

    End Function
    Function Fx_Crear_Documento_Desde_Otro_Automaticamente_SincroStock_NCV(_Id_Enc_Ncv As Integer,
                                                                           _Id_Enc_Fcv_Ori As Integer,
                                                                           _Formulario As Form,
                                                                           _Tido_Destino As String,
                                                                           _Idmaeedo_Origen As Integer,
                                                                           _Fecha_Emision As DateTime,
                                                                           _Empresa As String,
                                                                           _Modalidad As String,
                                                                           _CerrarDespFact As Boolean) As LsValiciones.Mensajes

        Dim _Mensaje As New LsValiciones.Mensajes
        Dim _Modalidad_Old = Mod_Modalidad
        Dim Fm_Post As Frm_Formulario_Documento = Nothing

        Try
            Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
            Dim _Reg As Integer = _Sql.Fx_Cuenta_Registros("CONFIEST", "MODALIDAD = '" & _Modalidad & "'", False)

            If _Reg = 0 Then Throw New System.Exception("No existe la modalidad " & _Modalidad)

            Dim _RowFormato As DataRow = Fx_Formato_Modalidad(_Formulario, _Empresa, _Modalidad, _Tido_Destino, False)
            If IsNothing(_RowFormato) Then Throw New System.Exception("No existe formato de documento para la modalidad")

            Consulta_sql = "Select * From MAEEDO Where IDMAEEDO = " & _Idmaeedo_Origen
            Dim _Row_Documento As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql, False)

            Dim _Msj_GrabarDoc As New LsValiciones.Mensajes

            If Not IsNothing(_Row_Documento) Then
                Dim _Meardo = _Row_Documento.Item("MEARDO")
                Dim _Tido = _Row_Documento.Item("TIDO")
                Dim _Nudo = _Row_Documento.Item("NUDO")

                Dim _Msj_Tsc As LsValiciones.Mensajes = Fx_Revisar_Tasa_Cambio(Nothing, _Fecha_Emision,, False)
                If Not _Msj_Tsc.EsCorrecto Then
                    _Mensaje.ErrorDeConexionSQL = _Msj_Tsc.ErrorDeConexionSQL
                    Throw New System.Exception(_Mensaje.Mensaje)
                End If

                If Not Fx_Se_Puede_Trasladar_Para_Crear_Otro_Documento_Credito(_Idmaeedo_Origen) Then
                    Throw New System.Exception("Nota de venta Nro: " & _Nudo & " se encuentra cerrado completamente")
                End If

                Dim _CampoPrecio As String = If(_Meardo = "N", "PPPRNE", "PPPRBR")

                'Consulta_sql = $"
                '                Select * From MAEEDO Where IDMAEEDO = {_Idmaeedo_Origen}
                '                Select *,Case When UDTRPR = 1 Then CAPRCO1-CAPREX1 ELSE CAPRCO2-CAPREX2 End As 'Cantidad',
                '                CAPRCO1-CAPREX1 As 'CantUd1_Dori',CAPRCO2-CAPREX2 As 'CantUd2_Dori',
                '                Case WHEN UDTRPR = 1 Then {_CampoPrecio} Else {_CampoPrecio}*RLUDPR End AS 'Precio',
                '                0 As Id_Oferta,'' As Oferta,0 As Es_Padre_Oferta,0 As Padre_Oferta,0 As Hijo_Oferta,0 As Cantidad_Oferta,0 As Porcdesc_Oferta
                '                From MAEDDO  With ( NOLOCK )
                '                Where IDMAEEDO = {_Idmaeedo_Origen}  AND ( ESLIDO<>'C' OR ESFALI='I' ) AND TICT = ''
                '                Order by IDMAEEDO,IDMAEDDO
                '                Select * From MAEIMLI Where IDMAEEDO = {_Idmaeedo_Origen}
                '                Select * From MAEDTLI Where IDMAEEDO = {_Idmaeedo_Origen}
                '                Select TOP 1 * From MAEEDOOB Where IDMAEEDO = {_Idmaeedo_Origen}"

                Consulta_sql = $"
                                Declare @Idmaeedo_Origen Int = {_Idmaeedo_Origen}
                                Declare @Id_Enc_Fcv_Ori Int = {_Id_Enc_Fcv_Ori}
                                Declare @Id_Enc_Ncv_Ori Int = { _Id_Enc_Ncv}
                                Select * From MAEEDO Where IDMAEEDO =@Idmaeedo_Origen
                                Select Ma.*,Det.*,Det2.*,Case When UDTRPR = 1 Then  (CASE 
								WHEN Det2.Comprarud1 <= (CAPRCO1 - CAPRNC1) THEN Det2.Comprarud1
								WHEN Det2.Comprarud1 >( CAPRCO1 - CAPRNC1 )then CAPRCO1 - CAPRNC1
								END) ELSE (CASE 
								WHEN Det2.Comprarud2 <= (CAPRCO2 - CAPRNC2 ) THEN Det2.Comprarud2
								WHEN Det2.Comprarud2 > (CAPRCO2 - CAPRNC2) then CAPRCO2 - CAPRNC2
								END) End As 'Cantidad', (CASE 
								WHEN Det2.Comprarud2 <= (CAPRCO2 - CAPRNC2) THEN Det2.Comprarud2
								WHEN Det2.Comprarud2 > (CAPRCO2 - CAPRNC2)  then CAPRCO2 - CAPRNC2
								END) as 'Cantidad2',
                                (CAPRAD1+CAPREX1)-CAPRNC1 As 'CantUd1_Dori',
								(CAPRAD2+CAPREX2)-CAPRNC2 As 'CantUd2_Dori',
                                Case WHEN UDTRPR = 1 Then PPPRNE Else PPPRNE*RLUDPR End AS 'Precio',Det.Costo,
                                0 As Id_Oferta,'' As Oferta,0 As Es_Padre_Oferta,0 As Padre_Oferta,0 As Hijo_Oferta,0 As Cantidad_Oferta,0 As Porcdesc_Oferta
                                From MAEDDO Ma  With ( NOLOCK )
                                Left Join {Global_BaseBk}Zw_InterStock_Det Det On Det.Idmaeddo_FCV = IDMAEDDO And Det.Id_Enc = @Id_Enc_Fcv_Ori
								inner Join {Global_BaseBk}Zw_InterStock_Det Det2 On  Det2.Id_Enc = @Id_Enc_Ncv_Ori  And Det2.Idmaeddo_FCV= IDMAEDDO
                                Where IDMAEEDO =@Idmaeedo_Origen -- AND ( ESLIDO<>'C' OR ESFALI='I' ) AND TICT = ''
                                Order by IDMAEEDO,IDMAEDDO
                             
                                Select * From MAEIMLI Where IDMAEEDO =@Idmaeedo_Origen
                                Select * From MAEDTLI Where IDMAEEDO =@Idmaeedo_Origen
                                Select TOP 1 * From MAEEDOOB Where IDMAEEDO =@Idmaeedo_Origen"

                Dim _Ds_Maeedo_Origen As DataSet = _Sql.Fx_Get_DataSet(Consulta_sql, True, False)
                ' 1. Identificar la tabla de detalle (segundo Select de la consulta SQL)
                Dim dtDetalle As DataTable = _Ds_Maeedo_Origen.Tables(1)

                ' 2. Filtrar y eliminar las filas que tengan Cantidad y Cantidad2 en 0
                Dim filasVacias() As DataRow = dtDetalle.Select("Cantidad <= 0 AND Cantidad2 <= 0")

                For Each fila As DataRow In filasVacias
                    fila.Delete()
                Next
                dtDetalle.AcceptChanges()

                ' 3. Validar si el DataSet trajo la cabecera vacía, o si nos quedamos sin detalle tras el filtro
                If _Ds_Maeedo_Origen.Tables(0).Rows.Count = 0 OrElse dtDetalle.Rows.Count = 0 Then

                    ' 4. Configurar el objeto mensaje en formato ERROR y retornarlo
                    _Mensaje.EsCorrecto = False
                    _Mensaje.Detalle = "El documento no contiene ítems válidos."
                    _Mensaje.Mensaje = "Error: No hay credito disponible para devolver"
                    _Mensaje.Id = 0 ' O el ID correspondiente a una operación fallida (_Msj_GrabarDoc.Id si aplica)


                    Return _Mensaje

                End If
                Mod_Modalidad = _Modalidad

                Fm_Post = New Frm_Formulario_Documento(_Tido_Destino, csGlobales.Enum_Tipo_Documento.Venta, False,,,,,, True)
                Fm_Post.Sb_Limpiar(_Modalidad)

                Fm_Post.Sb_Crear_Documento_Desde_Otros_Documentos(_Formulario, _Ds_Maeedo_Origen, False, False, _Fecha_Emision, False, True, Id_Enc_InterStock:=_Id_Enc_Ncv, EsAutomatico:=True)

                _Msj_GrabarDoc = Fm_Post.Fx_Grabar_Documento(False, csGlobales.Mod_Enum_Listados_Globales.Enum_Tipo_de_Grabacion.Nuevo_documento, True, False,,, False,,, True)

                If _Msj_GrabarDoc.EsCorrecto Then
                    Fm_Post.Sb_Activar_Orden_De_Despacho(_Msj_GrabarDoc.Id)
                End If
            End If

            If _Msj_GrabarDoc.EsCorrecto Then
                Consulta_sql = "Select * From MAEEDO Where IDMAEEDO = " & _Msj_GrabarDoc.Id
                Dim _Row As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql, False)

                _Mensaje.EsCorrecto = True
                _Mensaje.Detalle = "Documento: " & _Row.Item("TIDO") & "-" & _Row.Item("NUDO") & " grabado con exito"
                _Mensaje.Mensaje = "Nota de venta gestionada correctamente Ok."
                _Mensaje.Id = _Msj_GrabarDoc.Id
                _Mensaje.Tag = _Row
            Else
                _Mensaje = _Msj_GrabarDoc
            End If

        Catch ex As Exception
            _Mensaje.EsCorrecto = False
            _Mensaje.Detalle = "Error al grabar documento"
            _Mensaje.Mensaje = ex.Message
        Finally
            If Fm_Post IsNot Nothing Then Fm_Post.Dispose()
            Mod_Modalidad = _Modalidad_Old
        End Try

        Return _Mensaje
    End Function



    Function Fx_Crear_Documento_Desde_Otro_Automaticamente_SincroStock_NCC(_Id_Enc_Ncv As Integer,
                                                                           _Id_Enc_Fcv_Ori As Integer,
                                                                           _Formulario As Form,
                                                                           _Tido_Destino As String,
                                                                           _Idmaeedo_Origen As Integer,
                                                                           _Fecha_Emision As DateTime,
                                                                           _Empresa As String,
                                                                           _Modalidad As String,
                                                                           _CerrarDespFact As Boolean, NUDO_NCV As String) As LsValiciones.Mensajes

        Dim _Mensaje As New LsValiciones.Mensajes
        Dim _Modalidad_Old = Mod_Modalidad
        Dim Fm_Post As Frm_Formulario_Documento = Nothing

        Try
            Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
            Dim _Reg As Integer = _Sql.Fx_Cuenta_Registros("CONFIEST", "MODALIDAD = '" & _Modalidad & "'", False)

            If _Reg = 0 Then Throw New System.Exception("No existe la modalidad " & _Modalidad)

            'Dim _RowFormato As DataRow = Fx_Formato_Modalidad(_Formulario, _Empresa, _Modalidad, _Tido_Destino, False)
            'If IsNothing(_RowFormato) Then Throw New System.Exception("No existe formato de documento para la modalidad")

            Consulta_sql = "Select * From MAEEDO Where IDMAEEDO = " & _Idmaeedo_Origen
            Dim _Row_Documento As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql, False)

            Dim _Msj_GrabarDoc As New LsValiciones.Mensajes

            If Not IsNothing(_Row_Documento) Then
                Dim _Meardo = _Row_Documento.Item("MEARDO")
                Dim _Tido = _Row_Documento.Item("TIDO")
                Dim _Nudo = _Row_Documento.Item("NUDO")

                Dim _Msj_Tsc As LsValiciones.Mensajes = Fx_Revisar_Tasa_Cambio(Nothing, _Fecha_Emision,, False)
                If Not _Msj_Tsc.EsCorrecto Then
                    _Mensaje.ErrorDeConexionSQL = _Msj_Tsc.ErrorDeConexionSQL
                    Throw New System.Exception(_Mensaje.Mensaje)
                End If

                If Not Fx_Se_Puede_Trasladar_Para_Crear_Otro_Documento_Credito(_Idmaeedo_Origen) Then
                    Throw New System.Exception("Nota de venta Nro: " & _Nudo & " se encuentra cerrado completamente")
                End If

                Dim _CampoPrecio As String = If(_Meardo = "N", "PPPRNE", "PPPRBR")

                'Consulta_sql = $"
                '                Select * From MAEEDO Where IDMAEEDO = {_Idmaeedo_Origen}
                '                Select *,Case When UDTRPR = 1 Then CAPRCO1-CAPREX1 ELSE CAPRCO2-CAPREX2 End As 'Cantidad',
                '                CAPRCO1-CAPREX1 As 'CantUd1_Dori',CAPRCO2-CAPREX2 As 'CantUd2_Dori',
                '                Case WHEN UDTRPR = 1 Then {_CampoPrecio} Else {_CampoPrecio}*RLUDPR End AS 'Precio',
                '                0 As Id_Oferta,'' As Oferta,0 As Es_Padre_Oferta,0 As Padre_Oferta,0 As Hijo_Oferta,0 As Cantidad_Oferta,0 As Porcdesc_Oferta
                '                From MAEDDO  With ( NOLOCK )
                '                Where IDMAEEDO = {_Idmaeedo_Origen}  AND ( ESLIDO<>'C' OR ESFALI='I' ) AND TICT = ''
                '                Order by IDMAEEDO,IDMAEDDO
                '                Select * From MAEIMLI Where IDMAEEDO = {_Idmaeedo_Origen}
                '                Select * From MAEDTLI Where IDMAEEDO = {_Idmaeedo_Origen}
                '                Select TOP 1 * From MAEEDOOB Where IDMAEEDO = {_Idmaeedo_Origen}"

                Consulta_sql = $"
                                Declare @Idmaeedo_Origen Int = {_Idmaeedo_Origen}
                                Declare @Id_Enc_Fcv_Ori Int = {_Id_Enc_Fcv_Ori}
                                Declare @Id_Enc_Ncv_Ori Int = { _Id_Enc_Ncv}

                                Select * From MAEEDO Where IDMAEEDO =@Idmaeedo_Origen
                                Select *,Case When UDTRPR = 1 Then  (CASE 
								WHEN Det2.Comprarud1 <= (CAPRCO1 - CAPRNC1) THEN Det2.Comprarud1
								WHEN Det2.Comprarud1 >( CAPRCO1 - CAPRNC1 )then CAPRCO1 - CAPRNC1
								END) ELSE (CASE 
								WHEN Det2.Comprarud2 <= (CAPRCO2 - CAPRNC2 ) THEN Det2.Comprarud2
								WHEN Det2.Comprarud2 > (CAPRCO2 - CAPRNC2) then CAPRCO2 - CAPRNC2
								END) End As 'Cantidad', (CASE 
								WHEN Det2.Comprarud2 <= (CAPRCO2 - CAPRNC2) THEN Det2.Comprarud2
								WHEN Det2.Comprarud2 > (CAPRCO2 - CAPRNC2)  then CAPRCO2 - CAPRNC2
								END) as 'Cantidad2',
                                (CAPRAD1+CAPREX1)-CAPRNC1 As 'CantUd1_Dori',
								(CAPRAD2+CAPREX2)-CAPRNC2 As 'CantUd2_Dori',
                                Case WHEN UDTRPR = 1 Then PPPRNE Else PPPRNE*RLUDPR End AS 'Precio',Det.Costo,
                                0 As Id_Oferta,'' As Oferta,0 As Es_Padre_Oferta,0 As Padre_Oferta,0 As Hijo_Oferta,0 As Cantidad_Oferta,0 As Porcdesc_Oferta
                                From MAEDDO  With ( NOLOCK )
                                Left Join {Global_BaseBk}Zw_InterStock_Det Det On Det.Idmaeddo_FCC = IDMAEDDO And Det.Id_Enc = @Id_Enc_Fcv_Ori
                                inner Join {Global_BaseBk}Zw_InterStock_Det Det2 On  Det2.Id_Enc = @Id_Enc_Ncv_Ori  And Det2.Idmaeddo_FCC = IDMAEDDO
                                Where IDMAEEDO =@Idmaeedo_Origen -- AND ( ESLIDO<>'C' OR ESFALI='I' ) AND TICT = ''
                                Order by IDMAEEDO,IDMAEDDO
                                Select * From MAEIMLI Where IDMAEEDO =@Idmaeedo_Origen
                                Select * From MAEDTLI Where IDMAEEDO =@Idmaeedo_Origen
                                Select TOP 1 * From MAEEDOOB Where IDMAEEDO =@Idmaeedo_Origen"

                Dim _Ds_Maeedo_Origen As DataSet = _Sql.Fx_Get_DataSet(Consulta_sql, True, False)


                Dim dtDetalle As DataTable = _Ds_Maeedo_Origen.Tables(1)

                ' 2. Filtrar y eliminar las filas que tengan Cantidad y Cantidad2 en 0
                Dim filasVacias() As DataRow = dtDetalle.Select("Cantidad <= 0 AND Cantidad2 <= 0")

                For Each fila As DataRow In filasVacias
                    fila.Delete()
                Next
                dtDetalle.AcceptChanges()

                ' 3. Validar si el DataSet trajo la cabecera vacía, o si nos quedamos sin detalle tras el filtro
                If _Ds_Maeedo_Origen.Tables(0).Rows.Count = 0 OrElse dtDetalle.Rows.Count = 0 Then

                    ' 4. Configurar el objeto mensaje en formato ERROR y retornarlo
                    _Mensaje.EsCorrecto = False
                    _Mensaje.Detalle = "El documento no contiene ítems válidos."
                    _Mensaje.Mensaje = "Error: No hay credito disponible para devolver"

                    _Mensaje.Id = 0 ' O el ID correspondiente a una operación fallida (_Msj_GrabarDoc.Id si aplica)


                    Return _Mensaje

                End If
                Mod_Modalidad = _Modalidad

                Fm_Post = New Frm_Formulario_Documento(_Tido_Destino, csGlobales.Enum_Tipo_Documento.Compra, False,,,,,, True)
                Fm_Post.Sb_Limpiar(Mod_Modalidad)
                Fm_Post.Pro_Nudo = NUDO_NCV
                Fm_Post.Sb_Crear_Documento_Desde_Otros_Documentos(_Formulario, _Ds_Maeedo_Origen, False, False, _Fecha_Emision, False, True, Id_Enc_InterStock:=_Id_Enc_Ncv, EsAutomatico:=True)

                _Msj_GrabarDoc = Fm_Post.Fx_Grabar_Documento(False, csGlobales.Mod_Enum_Listados_Globales.Enum_Tipo_de_Grabacion.Nuevo_documento, False, False,,, False,,, True)

                If _Msj_GrabarDoc.EsCorrecto Then
                    Fm_Post.Sb_Activar_Orden_De_Despacho(_Msj_GrabarDoc.Id)
                End If
            End If

            If _Msj_GrabarDoc.EsCorrecto Then
                Consulta_sql = "Select * From MAEEDO Where IDMAEEDO = " & _Msj_GrabarDoc.Id
                Dim _Row As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql, False)

                _Mensaje.EsCorrecto = True
                _Mensaje.Detalle = "Documento: " & _Row.Item("TIDO") & "-" & _Row.Item("NUDO") & " grabado con exito"
                _Mensaje.Mensaje = "Nota de venta gestionada correctamente Ok."
                _Mensaje.Id = _Msj_GrabarDoc.Id
                _Mensaje.Tag = _Row
            Else
                _Mensaje = _Msj_GrabarDoc
            End If

        Catch ex As Exception
            _Mensaje.EsCorrecto = False
            _Mensaje.Detalle = "Error al grabar documento"
            _Mensaje.Mensaje = ex.Message
        Finally
            If Fm_Post IsNot Nothing Then Fm_Post.Dispose()
            Mod_Modalidad = _Modalidad_Old
        End Try

        Return _Mensaje
    End Function
    Public Sub CambioEmpresa(CodEmpresa As String, Modalidad As String)
        Dim _Mod As New Clas_Modalidades
        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)

        Try
            Mod_Empresa = CodEmpresa
            Mod_Modalidad = Modalidad

            Consulta_sql = $"Select top 1 Cest.*,Cfgp.RAZON From CONFIEST Cest WITH (NOLOCK) Inner Join CONFIGP Cfgp On Cest.EMPRESA = Cfgp.EMPRESA Where MODALIDAD = '{Mod_Modalidad}' And Cest.EMPRESA = '{Mod_Empresa}'"
            _Global_Row_Modalidad = _Sql.Fx_Get_DataRow(Consulta_sql, False)

            Mod_Empresa = _Global_Row_Modalidad.Item("EMPRESA")
            Mod_Sucursal = _Global_Row_Modalidad.Item("ESUCURSAL")
            Mod_Bodega = _Global_Row_Modalidad.Item("EBODEGA")
            Mod_Caja = _Global_Row_Modalidad.Item("ECAJA")
            Mod_ListaPrecioVenta = Mid(_Global_Row_Modalidad.Item("ELISTAVEN"), 6, 3)
            Mod_ListaPrecioCosto = Mid(_Global_Row_Modalidad.Item("ELISTACOM"), 6, 3)

            _Mod.Sb_Actualiza_Formatos_X_Modalidad()


            _Mod.Sb_Actualizar_Variables_Modalidad(Mod_Modalidad)

        Catch ex As Exception
            Throw New Exception("Error durante el proceso de CambioEmpresa: " & ex.Message)
        Finally
            ' Si fuese necesario cerrar SQL, se haría aquí.
        End Try

    End Sub

#Region "Métodos Auxiliares Extraídos"

    Private Function GenerarDocumentoInterno(TipoDoc As String, RowEntidad As DataRow, CodEmpresa As String, Modalidad As String, TblDetalle As DataTable, IdMaeedoFCV As String, Txt_Log As Object, _Observaciones As String, _Orden_compra As String, NudoOr As String, fechaDoc As Date, id_Enc As Integer) As Mensajes
        Dim msg As New Mensajes
        msg.EsCorrecto = False
        Dim Fm As Frm_Formulario_Documento = Nothing
        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)

        Try
            ' 1. Ajustar el contexto global a la empresa y modalidad correspondientes
            CambioEmpresa(CodEmpresa, Modalidad)
            LogSeguro("Demonio SincroStock", $"Generando documento {TipoDoc} para FCV: {NudoOr} / Entidad: {RowEntidad("ENDO")} / Modalidad: {Modalidad}", Txt_Log)

            Dim tipoEnum = If(TipoDoc = "OCC", csGlobales.Mod_Enum_Listados_Globales.Enum_Tipo_Documento.Compra, csGlobales.Mod_Enum_Listados_Globales.Enum_Tipo_Documento.Venta)
            Fm = New Frm_Formulario_Documento(TipoDoc, tipoEnum, False, True, False, False, False)

            ' 2. IMPORTANTE: Limpiar/Inicializar el formulario con la modalidad específica 
            ' para que asuma sucursales, bodegas, listas y formatos correctos.
            Fm.Sb_Limpiar(Modalidad)

            Fm.Pro_RowEntidad = RowEntidad
            Fm.Sb_Crear_Documento_Interno_Con_Tabla_SincroStock(TblDetalle,
                                                                fechaDoc,
                                                                "Codigo", "Cantidad", "Costo", _Observaciones, _Orden_compra, False, False, id_Enc)

            msg = Fm.Fx_Grabar_Documento(False, , True, _Mostrar_Mensaje:=False)

            If msg.EsCorrecto Then
                Consulta_sql = $"SELECT * FROM MAEEDO WHERE IDMAEEDO = {msg.Id}"
                Dim _Docummento As DataSet = _Sql.Fx_Get_DataSet(Consulta_sql, False, False)

                msg.Tag = _Docummento
                LogSeguro("Demonio SincroStock", $"{TipoDoc} creada correctamente con Numero de documento: {_Docummento.Tables(0).Rows(0).Item("NUDO").ToString()}", Txt_Log)
            Else
                LogSeguro("Demonio SincroStock", $"Error al crear {TipoDoc}: {msg.Mensaje}", Txt_Log)
            End If

        Catch ex As Exception
            msg.Mensaje = "Error en GenerarDocumentoInterno: " & ex.Message
            LogSeguro("Demonio SincroStock", $"Excepción creando {TipoDoc}: {ex.Message}", Txt_Log)
        Finally
            If Fm IsNot Nothing Then Fm.Dispose()
        End Try

        Return msg
    End Function

    Private Sub ActualizarVinculoSincroStock(TipoDoc As String, IdDocGenerado As String, IdMaeedoFCV As Integer, Txt_Log As Object)
        Dim sufijo = TipoDoc
        Dim SqlQuery As String = $"
UPDATE Ddet SET Ddet.Id_Det_SincroStock = CONVERT(int, Ddo.OBSERVA)
FROM MAEDDO Ddo
INNER JOIN {_Global_BaseBk}Zw_InterStock_Det Det ON Det.Id_Det = CONVERT(int, Ddo.OBSERVA)
INNER JOIN {_Global_BaseBk}Zw_Docu_Det Ddet ON Ddet.Idmaeddo = Ddo.IDMAEDDO
WHERE Ddo.IDMAEEDO = {IdDocGenerado} AND Ddo.OBSERVA NOT LIKE '%[^0-9]%';

UPDATE Det SET 
    Det.Empresa_{sufijo} = Ddo.EMPRESA, Det.Sucursal_{sufijo} = Ddo.SULIDO, Det.Bodega_{sufijo} = Ddo.BOSULIDO,
    Det.Idmaeedo_{sufijo} = Ddo.IDMAEEDO, Det.Idmaeddo_{sufijo} = Ddo.IDMAEDDO, Det.Tido_{sufijo} = Ddo.TIDO, Det.Nudo_{sufijo} = Ddo.NUDO
FROM {_Global_BaseBk}Zw_InterStock_Det Det
INNER JOIN {_Global_BaseBk}Zw_Docu_Det Ddet ON Ddet.Id_Det_SincroStock = Det.Id_Det
INNER JOIN MAEDDO Ddo ON Ddo.IDMAEDDO = Ddet.Idmaeddo
WHERE Det.Idmaeedo = {IdMaeedoFCV} AND Ddo.IDMAEEDO = {IdDocGenerado} And Ddo.TIDO = '{TipoDoc}';"

        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
        Try
            LogSeguro("Demonio SincroStock", $"Ejecutando actualización de tablas SincroStock para {TipoDoc}...", Txt_Log)
            If _Sql.Ej_consulta_IDU(SqlQuery, False) Then
                LogSeguro("Demonio SincroStock", $"Proceso SQL Exitoso: Tablas actualizadas para {TipoDoc}", Txt_Log)
            Else
                LogSeguro("Demonio SincroStock", $"Fallo SQL al actualizar tablas para {TipoDoc}", Txt_Log)
            End If
        Catch ex As Exception
            LogSeguro("Demonio SincroStock", $"Excepción en ActualizarVinculoSincroStock ({TipoDoc}): " & ex.Message, Txt_Log)
        Finally
            ' Liberar comandos o conexiones si aplica en Class_SQL
        End Try
    End Sub
    Sub ActualizarVinculoSincroStockFCC(IdDocGenerado As String, IdMaeedoNVV As Integer, Txt_Log As Object)
        Dim TipoDoc As String = "FCC"
        Dim sufijo = TipoDoc

        Dim SqlQuery As String = $"
UPDATE Ddet SET Ddet.Id_Det_SincroStock = CONVERT(int, Ddo.OBSERVA)
FROM MAEDDO Ddo
INNER JOIN {_Global_BaseBk}Zw_InterStock_Det Det ON Det.Id_Det = CONVERT(int, Ddo.OBSERVA)
INNER JOIN {_Global_BaseBk}Zw_Docu_Det Ddet ON Ddet.Idmaeddo = Ddo.IDMAEDDO
WHERE Ddo.IDMAEEDO = {IdDocGenerado} AND Ddo.OBSERVA NOT LIKE '%[^0-9]%';

UPDATE Det SET 
    Det.Empresa_{sufijo} = Ddo.EMPRESA,
    Det.Idmaeedo_{sufijo} = Ddo.IDMAEEDO, 
    Det.Idmaeddo_{sufijo} = Ddo.IDMAEDDO, 
    Det.Tido_{sufijo} = Ddo.TIDO, 
    Det.Nudo_{sufijo} = Ddo.NUDO
FROM {_Global_BaseBk}Zw_InterStock_Det Det
INNER JOIN MAEDDO Ddo ON Ddo.IDRST = Det.Idmaeddo_OCC
WHERE Det.Idmaeedo = {IdMaeedoNVV} AND Ddo.IDMAEEDO = {IdDocGenerado} And Ddo.TIDO = '{TipoDoc}';"

        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
        Try
            LogSeguro("Demonio SincroStock", $"Ejecutando actualización de tablas SincroStock para {TipoDoc}...", Txt_Log)
            If _Sql.Ej_consulta_IDU(SqlQuery, False) Then
                LogSeguro("Demonio SincroStock", $"Proceso SQL Exitoso: Tablas actualizadas para {TipoDoc}", Txt_Log)
            Else
                LogSeguro("Demonio SincroStock", $"Fallo SQL al actualizar tablas para {TipoDoc}", Txt_Log)
            End If
        Catch ex As Exception
            LogSeguro("Demonio SincroStock", $"Excepción en ActualizarVinculoSincroStockFCV: " & ex.Message, Txt_Log)
        Finally
            ' Liberar comandos o conexiones si aplica
        End Try
    End Sub
    Sub ActualizarVinculoSincroStockFCV(IdDocGenerado As String, IdMaeedoNVV As Integer, Txt_Log As Object)
        Dim TipoDoc As String = "FCV"
        Dim sufijo = TipoDoc

        Dim SqlQuery As String = $"
UPDATE Ddet SET Ddet.Id_Det_SincroStock = CONVERT(int, Ddo.OBSERVA)
FROM MAEDDO Ddo
INNER JOIN {_Global_BaseBk}Zw_InterStock_Det Det ON Det.Id_Det = CONVERT(int, Ddo.OBSERVA)
INNER JOIN {_Global_BaseBk}Zw_Docu_Det Ddet ON Ddet.Idmaeddo = Ddo.IDMAEDDO
WHERE Ddo.IDMAEEDO = {IdDocGenerado} AND Ddo.OBSERVA NOT LIKE '%[^0-9]%';

UPDATE Det SET 
    Det.Empresa_{sufijo} = Ddo.EMPRESA,
    Det.Idmaeedo_{sufijo} = Ddo.IDMAEEDO, 
    Det.Idmaeddo_{sufijo} = Ddo.IDMAEDDO, 
    Det.Tido_{sufijo} = Ddo.TIDO, 
    Det.Nudo_{sufijo} = Ddo.NUDO
FROM {_Global_BaseBk}Zw_InterStock_Det Det
INNER JOIN MAEDDO Ddo ON Ddo.IDRST = Det.Idmaeddo_NVV
WHERE Det.Idmaeedo_NVV = {IdMaeedoNVV} AND Ddo.IDMAEEDO = {IdDocGenerado} And Ddo.TIDO = '{TipoDoc}';"

        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
        Try
            LogSeguro("Demonio SincroStock", $"Ejecutando actualización de tablas SincroStock para {TipoDoc}...", Txt_Log)
            If _Sql.Ej_consulta_IDU(SqlQuery, False) Then
                LogSeguro("Demonio SincroStock", $"Proceso SQL Exitoso: Tablas actualizadas para {TipoDoc}", Txt_Log)
            Else
                LogSeguro("Demonio SincroStock", $"Fallo SQL al actualizar tablas para {TipoDoc}", Txt_Log)
            End If
        Catch ex As Exception
            LogSeguro("Demonio SincroStock", $"Excepción en ActualizarVinculoSincroStockFCV: " & ex.Message, Txt_Log)
        Finally
            ' Liberar comandos o conexiones si aplica
        End Try
    End Sub
    Sub ActualizarVinculoSincroStockNCC(IdDocGenerado As String, idEnc As Integer, Txt_Log As Object)
        Dim TipoDoc As String = "NCC"
        Dim sufijo = TipoDoc

        Dim SqlQuery As String = $"
UPDATE Ddet SET Ddet.Id_Det_SincroStock = CONVERT(int, Ddo.OBSERVA)
FROM MAEDDO Ddo
INNER JOIN {_Global_BaseBk}Zw_InterStock_Det Det ON Det.Id_Det = CONVERT(int, Ddo.OBSERVA)
INNER JOIN {_Global_BaseBk}Zw_Docu_Det Ddet ON Ddet.Idmaeddo = Ddo.IDMAEDDO
WHERE Ddo.IDMAEEDO = {IdDocGenerado} AND Ddo.OBSERVA NOT LIKE '%[^0-9]%';

UPDATE Det SET 
    Det.Empresa_{sufijo} = Ddo.EMPRESA,
    Det.Idmaeedo_{sufijo} = Ddo.IDMAEEDO, 
    Det.Idmaeddo_{sufijo} = Ddo.IDMAEDDO, 
    Det.Tido_{sufijo} = Ddo.TIDO, 
    Det.Nudo_{sufijo} = Ddo.NUDO
FROM {_Global_BaseBk}Zw_InterStock_Det Det
INNER JOIN MAEDDO Ddo ON Ddo.IDRST = Det.Idmaeddo_FCC
WHERE Det.Id_Enc = {idEnc} AND Ddo.IDMAEEDO = {IdDocGenerado} And Ddo.TIDO = '{TipoDoc}';"

        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
        Try
            LogSeguro("Demonio SincroStock", $"Ejecutando actualización de tablas SincroStock para {TipoDoc}...", Txt_Log)
            If _Sql.Ej_consulta_IDU(SqlQuery, False) Then
                LogSeguro("Demonio SincroStock", $"Proceso SQL Exitoso: Tablas actualizadas para {TipoDoc}", Txt_Log)
            Else
                LogSeguro("Demonio SincroStock", $"Fallo SQL al actualizar tablas para {TipoDoc}", Txt_Log)
            End If
        Catch ex As Exception
            LogSeguro("Demonio SincroStock", $"Excepción en ActualizarVinculoSincroStockFCV: " & ex.Message, Txt_Log)
        Finally
            ' Liberar comandos o conexiones si aplica
        End Try
    End Sub

    Sub ActualizarVinculoSincroStockNCV(IdDocGenerado As String, idEnc As Integer, Txt_Log As Object)
        Dim TipoDoc As String = "NCV"
        Dim sufijo = TipoDoc

        Dim SqlQuery As String = $"
UPDATE Ddet SET Ddet.Id_Det_SincroStock = CONVERT(int, Ddo.OBSERVA)
FROM MAEDDO Ddo
INNER JOIN {_Global_BaseBk}Zw_InterStock_Det Det ON Det.Id_Det = CONVERT(int, Ddo.OBSERVA)
INNER JOIN {_Global_BaseBk}Zw_Docu_Det Ddet ON Ddet.Idmaeddo = Ddo.IDMAEDDO
WHERE Ddo.IDMAEEDO = {IdDocGenerado} AND Ddo.OBSERVA NOT LIKE '%[^0-9]%';

UPDATE Det SET 
    Det.Empresa_{sufijo} = Ddo.EMPRESA,
    Det.Idmaeedo_{sufijo} = Ddo.IDMAEEDO, 
    Det.Idmaeddo_{sufijo} = Ddo.IDMAEDDO, 
    Det.Tido_{sufijo} = Ddo.TIDO, 
    Det.Nudo_{sufijo} = Ddo.NUDO
FROM {_Global_BaseBk}Zw_InterStock_Det Det
INNER JOIN MAEDDO Ddo ON Ddo.IDRST = Det.Idmaeddo_FCV
WHERE Det.Id_Enc = {idEnc} AND Ddo.IDMAEEDO = {IdDocGenerado} And Ddo.TIDO = '{TipoDoc}';"

        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
        Try
            LogSeguro("Demonio SincroStock", $"Ejecutando actualización de tablas SincroStock para {TipoDoc}...", Txt_Log)
            If _Sql.Ej_consulta_IDU(SqlQuery, False) Then
                LogSeguro("Demonio SincroStock", $"Proceso SQL Exitoso: Tablas actualizadas para {TipoDoc}", Txt_Log)
            Else
                LogSeguro("Demonio SincroStock", $"Fallo SQL al actualizar tablas para {TipoDoc}", Txt_Log)
            End If
        Catch ex As Exception
            LogSeguro("Demonio SincroStock", $"Excepción en ActualizarVinculoSincroStockFCV: " & ex.Message, Txt_Log)
        Finally
            ' Liberar comandos o conexiones si aplica
        End Try
    End Sub

    Private Sub ActualizarEstadoEncabezado(Id_Enc As Integer, Estado As String, Procesando As Integer, Procesar As Integer, ErrorFlag As Integer, Observacion As String, Txt_Log As Object)
        Dim ObservacionLimpia As String = Observacion.Replace("'", "''")
        Dim SqlQuery As String = $"UPDATE {_Global_BaseBk}Zw_InterStock_Enc SET Estado = '{Estado}', Observacion = '{ObservacionLimpia}', Procesando = {Procesando}, Procesar = {Procesar}, Error = {ErrorFlag} WHERE Id_Enc = {Id_Enc}"
        If ErrorFlag = 1 Then
            SqlQuery = $"UPDATE {_Global_BaseBk}Zw_InterStock_Enc SET Estado = 'FALLIDA', Observacion = '{ObservacionLimpia}', Procesando = {Procesando}, Procesar = {Procesar}, Error = {ErrorFlag} WHERE Id_Enc = {Id_Enc}"
        Else
            SqlQuery = $"UPDATE {_Global_BaseBk}Zw_InterStock_Enc SET Estado = '{Estado}', Observacion = '{ObservacionLimpia}', Procesando = {Procesando}, Procesar = {Procesar}, Error = {ErrorFlag} WHERE Id_Enc = {Id_Enc}"
        End If
        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
        Try
            If _Sql.Ej_consulta_IDU(SqlQuery, False) Then
                LogSeguro("Demonio SincroStock", $"Estado actualizado a {Estado} para Id_enc = {Id_Enc}", Txt_Log)
            Else
                LogSeguro("Demonio SincroStock", $"Error al actualizar el estado a {Estado} para Id_enc= {Id_Enc}", Txt_Log)
            End If
        Catch ex As Exception
            LogSeguro("Demonio SincroStock", $"Excepción al actualizar estado: " & ex.Message, Txt_Log)
        Finally
            ' Cierre opcional
        End Try
    End Sub


    Private Sub ActualizarEstadoEncabezadoFecha(IdMaeedo As Integer, Txt_Log As Object)
        Dim fechaAammdd As String = Now.ToString("yyyyMMdd")
        fechaAammdd = Format(fechaAammdd, "yyyyMMdd")
        Dim SqlQuery As String = $"UPDATE {_Global_BaseBk}Zw_InterStock_Enc SET FechaProceso = CONVERT(VARCHAR(8), GETDATE(), 112) WHERE Id_Enc = {IdMaeedo}"

        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
        Try
            If _Sql.Ej_consulta_IDU(SqlQuery, False) Then
                LogSeguro("Demonio SincroStock", $"Estado actualizado a FechaProceso para Id_Enc = {IdMaeedo}", Txt_Log)
            Else
                LogSeguro("Demonio SincroStock", $"Error al actualizar el estado a FechaProceso para Id_Enc= {IdMaeedo}", Txt_Log)
            End If
        Catch ex As Exception
            LogSeguro("Demonio SincroStock", $"Excepción al actualizar estado: " & ex.Message, Txt_Log)
        Finally
            ' Cierre opcional
        End Try
    End Sub

    Private Sub CerrarEstadoEncabezado(IdMaeedo As Integer, Txt_Log As Object)
        Dim SqlQuery As String = $"UPDATE {_Global_BaseBk}Zw_InterStock_Enc SET Estado = 'PROCESADA', Observacion = 'Proceso finalizado', Procesando = 0 , Procesar = 0, Error = 0,Procesada = 1 WHERE Id_Enc = {IdMaeedo}"

        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
        Try
            If _Sql.Ej_consulta_IDU(SqlQuery, False) Then
                LogSeguro("Demonio SincroStock", $"Estado actualizado a PROCESADA para IdMaeedo = {IdMaeedo}", Txt_Log)
            Else
                LogSeguro("Demonio SincroStock", $"Error al actualizar el estado a PROCESADA para IdMaeedo= {IdMaeedo}", Txt_Log)
            End If
        Catch ex As Exception
            LogSeguro("Demonio SincroStock", $"Excepción al actualizar estado: " & ex.Message, Txt_Log)
        Finally
            ' Cierre opcional
        End Try
    End Sub
    Private Function ObtenerEntidadMaestro(Koen As String, Suen As String) As DataRow
        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
        Try
            Dim qry As String = $"Select Top 1 *,KOEN AS ENDO, SUEN AS SUENDO From MAEEN Where KOEN = '{Koen}' And SUEN = '{Suen}'"
            Return _Sql.Fx_Get_DataRow(qry, False)
        Catch ex As Exception
            Throw New Exception("Error en ObtenerEntidadMaestro: " & ex.Message)
        Finally
            If _Sql IsNot Nothing Then _Sql.Sb_Cerrar_Conexion2()
        End Try
    End Function

    Private Function ObtenerDetallesInterStockVentaCredito(Id_Enc As Integer) As DataTable
        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
        Try
            Dim qry As String = $"
SELECT 
    CASE 
        WHEN dt.Bodega = eq.Bodega_A AND dt.Sucursal = eq.Sucursal_A THEN eq.Empresa_B
        ELSE eq.Empresa_A
    END AS Empresa,
    CASE 
        WHEN dt.Bodega = eq.Bodega_A AND dt.Sucursal = eq.Sucursal_A THEN eq.Sucursal_B
        ELSE eq.Sucursal_A
    END AS Sucursal,
    
    CASE 
        WHEN dt.Bodega = eq.Bodega_A AND dt.Sucursal = eq.Sucursal_A THEN eq.Bodega_B
        ELSE eq.Bodega_A
    END AS Bodega,
    
    Codigo,
    
	 Comprarud1
	 As Cantidad,
    
	 Comprarud1
	 As 'CantDoriUd1',
     Comprarud2
	 As 'CantDoriUd2',
    Costo,
    Id_Det As 'Observa' 
FROM {Global_BaseBk}Zw_InterStock_Det dt 
INNER JOIN {Global_BaseBk}Zw_InterStock_Equivalencia eq 
    ON (dt.Sucursal = eq.Sucursal_A AND dt.Bodega = eq.Bodega_A And dt.Empresa = eq.Empresa_A) 
    OR (dt.Sucursal = eq.Sucursal_B AND dt.Bodega = eq.Bodega_B And dt.Empresa = eq.Empresa_B)
INNER JOIN MAEST Ma
    ON Ma.KOBO = (
        CASE 
            WHEN dt.Bodega = eq.Bodega_A AND dt.Sucursal = eq.Sucursal_A THEN eq.Bodega_B 
            ELSE eq.Bodega_A 
        END
    ) and Ma.KOPR =  Codigo
WHERE dt.Id_Enc = {Id_Enc} 
  AND Comprarud1 > 0 

  AND eq.Activo2 = 1
 
                
"

            Return _Sql.Fx_Get_DataTable(qry, False)
        Catch ex As Exception
            Throw New Exception("Error en ObtenerDetallesInterStock: " & ex.Message)
        Finally
            If _Sql IsNot Nothing Then _Sql.Sb_Cerrar_Conexion2()
        End Try
    End Function
    Private Function ObtenerDetallesInterStockVenta(Id_Enc As Integer) As DataTable
        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
        Try
            Dim qry As String = $"
SELECT 
    CASE 
        WHEN dt.Bodega = eq.Bodega_A AND dt.Sucursal = eq.Sucursal_A THEN eq.Empresa_B
        ELSE eq.Empresa_A
    END AS Empresa,
    CASE 
        WHEN dt.Bodega = eq.Bodega_A AND dt.Sucursal = eq.Sucursal_A THEN eq.Sucursal_B
        ELSE eq.Sucursal_A
    END AS Sucursal,
    
    CASE 
        WHEN dt.Bodega = eq.Bodega_A AND dt.Sucursal = eq.Sucursal_A THEN eq.Bodega_B
        ELSE eq.Bodega_A
    END AS Bodega,
    
    Codigo,
    (CASE 
	when Ma.STFI1 <= 0 THEN 0
	When Ma.STFI1 < Comprarud1 then Ma.STFI1
	Else Comprarud1
	END) As Cantidad,
    (CASE 
	when Ma.STFI1 <= 0 THEN 0
	When Ma.STFI1 < Comprarud1 then Ma.STFI1
	Else Comprarud1
	END) As 'CantDoriUd1',
    (CASE 
	when Ma.STFI2 <= 0 THEN 0
	When Ma.STFI2 < Comprarud2 then Ma.STFI2
	Else Comprarud2
	END)  As 'CantDoriUd2',
    Costo,
    Id_Det As 'Observa' 
FROM {Global_BaseBk}Zw_InterStock_Det dt 
INNER JOIN {Global_BaseBk}Zw_InterStock_Equivalencia eq 
    ON (dt.Sucursal = eq.Sucursal_A AND dt.Bodega = eq.Bodega_A And dt.Empresa = eq.Empresa_A) 
    OR (dt.Sucursal = eq.Sucursal_B AND dt.Bodega = eq.Bodega_B And dt.Empresa = eq.Empresa_B)
INNER JOIN MAEST Ma
    ON Ma.KOBO = (
        CASE 
            WHEN dt.Bodega = eq.Bodega_A AND dt.Sucursal = eq.Sucursal_A THEN eq.Bodega_B 
            ELSE eq.Bodega_A 
        END
    ) and Ma.KOPR =  Codigo
WHERE dt.Id_Enc = {Id_Enc} 
  AND Comprarud1 > 0 
  AND Costo > 0 
  AND eq.Activo2 = 1
  AND (CASE 
        when Ma.STFI1 <= 0 THEN 0
        When Ma.STFI1 < Comprarud1 then Ma.STFI1
        Else Comprarud1
      END) > 0
                
"

            Return _Sql.Fx_Get_DataTable(qry, False)
        Catch ex As Exception
            Throw New Exception("Error en ObtenerDetallesInterStock: " & ex.Message)
        Finally
            If _Sql IsNot Nothing Then _Sql.Sb_Cerrar_Conexion2()
        End Try
    End Function
    Private Function ObtenerDetallesInterStockCompraCredito(Id_Enc As Integer) As DataTable
        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
        Try
            Dim qry As String = $"
SELECT 
    CASE 
        WHEN dt.Bodega = eq.Bodega_A AND dt.Sucursal = eq.Sucursal_A THEN eq.Empresa_A
        ELSE eq.Empresa_B
    END AS Empresa,
    CASE 
        WHEN dt.Bodega = eq.Bodega_A AND dt.Sucursal = eq.Sucursal_A THEN eq.Sucursal_A
        ELSE eq.Sucursal_B
    END AS Sucursal,
    
    CASE 
        WHEN dt.Bodega = eq.Bodega_A AND dt.Sucursal = eq.Sucursal_A THEN eq.Bodega_A
        ELSE eq.Bodega_B
    END AS Bodega,
    
    Codigo,
  
Comprarud1
As Cantidad,
 Comprarud1
  As 'CantDoriUd1',
    Comprarud2
  As 'CantDoriUd2',
    Costo,
    Id_Det As 'Observa' 
FROM {Global_BaseBk}Zw_InterStock_Det dt 
INNER JOIN {Global_BaseBk}Zw_InterStock_Equivalencia eq 
    ON (dt.Sucursal = eq.Sucursal_A AND dt.Bodega = eq.Bodega_A And dt.Empresa = eq.Empresa_A) 
    OR (dt.Sucursal = eq.Sucursal_B AND dt.Bodega = eq.Bodega_B And dt.Empresa = eq.Empresa_B)
INNER JOIN MAEST Ma
    ON Ma.KOBO = (
        CASE 
            WHEN dt.Bodega = eq.Bodega_A AND dt.Sucursal = eq.Sucursal_A THEN eq.Bodega_B 
            ELSE eq.Bodega_A 
        END
    ) and Ma.KOPR =  Codigo
WHERE dt.Id_Enc = {Id_Enc} 
  AND Comprarud1 > 0 
  AND eq.Activo2 = 1
"

            Return _Sql.Fx_Get_DataTable(qry, False)
        Catch ex As Exception
            Throw New Exception("Error en ObtenerDetallesInterStock: " & ex.Message)
        Finally
            If _Sql IsNot Nothing Then _Sql.Sb_Cerrar_Conexion2()
        End Try
    End Function
    Private Function ObtenerDetallesInterStockCompra(Id_Enc As Integer) As DataTable
        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
        Try
            Dim qry As String = $"
SELECT 
    CASE 
        WHEN dt.Bodega = eq.Bodega_A AND dt.Sucursal = eq.Sucursal_A THEN eq.Empresa_A
        ELSE eq.Empresa_B
    END AS Empresa,
    CASE 
        WHEN dt.Bodega = eq.Bodega_A AND dt.Sucursal = eq.Sucursal_A THEN eq.Sucursal_A
        ELSE eq.Sucursal_B
    END AS Sucursal,
    
    CASE 
        WHEN dt.Bodega = eq.Bodega_A AND dt.Sucursal = eq.Sucursal_A THEN eq.Bodega_A
        ELSE eq.Bodega_B
    END AS Bodega,
    
    Codigo,
    (CASE 
	when Ma.STFI1 <= 0 THEN 0
	When Ma.STFI1 < Comprarud1 then Ma.STFI1
	Else Comprarud1
	END) As Cantidad,
     (CASE 
	when Ma.STFI1 <= 0 THEN 0
	When Ma.STFI1 < Comprarud1 then Ma.STFI1
	Else Comprarud1
	END)  As 'CantDoriUd1',
     (CASE 
	when Ma.STFI2 <= 0 THEN 0
	When Ma.STFI2 < Comprarud2 then Ma.STFI2
	Else Comprarud2
	END)  As 'CantDoriUd2',
    Costo,
    Id_Det As 'Observa' 
FROM {Global_BaseBk}Zw_InterStock_Det dt 
INNER JOIN {Global_BaseBk}Zw_InterStock_Equivalencia eq 
    ON (dt.Sucursal = eq.Sucursal_A AND dt.Bodega = eq.Bodega_A And dt.Empresa = eq.Empresa_A) 
    OR (dt.Sucursal = eq.Sucursal_B AND dt.Bodega = eq.Bodega_B And dt.Empresa = eq.Empresa_B)
INNER JOIN MAEST Ma
    ON Ma.KOBO = (
        CASE 
            WHEN dt.Bodega = eq.Bodega_A AND dt.Sucursal = eq.Sucursal_A THEN eq.Bodega_B 
            ELSE eq.Bodega_A 
        END
    ) and Ma.KOPR =  Codigo
WHERE dt.Id_Enc = {Id_Enc} 
  AND Comprarud1 > 0 
  AND Costo > 0 
  AND eq.Activo2 = 1
  AND (CASE 
        when Ma.STFI1 <= 0 THEN 0
        When Ma.STFI1 < Comprarud1 then Ma.STFI1
        Else Comprarud1
      END) > 0

                
"

            Return _Sql.Fx_Get_DataTable(qry, False)
        Catch ex As Exception
            Throw New Exception("Error en ObtenerDetallesInterStock: " & ex.Message)
        Finally
            If _Sql IsNot Nothing Then _Sql.Sb_Cerrar_Conexion2()
        End Try
    End Function
    Private Function GenerarConsultaSelectInterStock(filtroExclusion As String) As String
        Dim retorno As String = $"
        Declare @FechaDesde Datetime = CAST(GetDate() AS DATE);
        Declare @FechaHasta Datetime = GetDate();
        SET NOCOUNT ON;
        -- 1. Eliminamos la tabla temporal si existe previamente (evita errores al ejecutar varias veces)
        IF OBJECT_ID('tempdb..#BaseDatos') IS NOT NULL 
            DROP TABLE #BaseDatos;

        -- 2. Volcamos los datos principales a una Tabla Temporal (#BaseDatos) con NOLOCK
        SELECT Ddo.IDMAEEDO, Ddo.IDMAEDDO, Ddo.TIDO, Ddo.NUDO, Ddo.ENDO, Ddo.SUENDO, 
               Ddo.EMPRESA, Ddo.SULIDO, Ddo.BOSULIDO, Ddo.KOPRCT, Ddo.CAPRCO1, Ddo.CAPRCO2, Ddo.FEEMLI as Fecha,
               Mst.STFI1, Mst.STFI2, Ddo.FEEMLI,
               SUM(Ddo.CAPRCO1) OVER(PARTITION BY Ddo.EMPRESA, Ddo.SULIDO, Ddo.BOSULIDO, Ddo.KOPRCT) AS TotalUd1,
               SUM(Ddo.CAPRCO2) OVER(PARTITION BY Ddo.EMPRESA, Ddo.SULIDO, Ddo.BOSULIDO, Ddo.KOPRCT) AS TotalUd2
        INTO #BaseDatos
        FROM MAEDDO Ddo WITH (NOLOCK)
        LEFT JOIN MAEST Mst WITH (NOLOCK) ON Ddo.EMPRESA = Mst.EMPRESA AND Ddo.SULIDO = Mst.KOSU AND Ddo.BOSULIDO = Mst.KOBO AND Ddo.KOPRCT = Mst.KOPR
        WHERE Ddo.IDMAEEDO IN (
            SELECT Edo.IDMAEEDO FROM MAEEDO Edo WITH (NOLOCK)
            INNER JOIN MAEDDO Ddo2 WITH (NOLOCK) ON Edo.IDMAEEDO = Ddo2.IDMAEEDO
            WHERE Edo.TIDO = 'FCV' AND Ddo2.LINCONDESP = 1 
              AND Ddo2.FEEMLI >= @FechaDesde AND Ddo2.FEEMLI <= @FechaHasta 
              AND NOT EXISTS (SELECT 1 FROM {Global_BaseBk}Zw_InterStock_Det ZI WITH (NOLOCK) WHERE ZI.Idmaeddo = Ddo2.IDMAEDDO)
        ) AND Ddo.TIPR = 'FPN' AND Ddo.PRCT = 0 And TICT = ''
        -- FILTRO: Verificamos que la bodega (BOSULIDO) exista como Bodega_A o Bodega_B
        AND EXISTS (
            SELECT 1 
            FROM {Global_BaseBk}Zw_InterStock_Equivalencia Eq WITH (NOLOCK)
            WHERE Activo2 = 1 and (Eq.Bodega_A = Ddo.BOSULIDO OR Eq.Bodega_B = Ddo.BOSULIDO)  
        );

        -- 3. EL SECRETO DEL RENDIMIENTO: Creamos un índice sobre los campos que usa el acumulado
        CREATE CLUSTERED INDEX IX_BaseDatos_Acumulado 
        ON #BaseDatos (EMPRESA, SULIDO, BOSULIDO, KOPRCT, FEEMLI, IDMAEDDO);

        -- 4. Ejecutamos la lógica leyendo directamente desde la tabla temporal indexada
        WITH Mov AS (
            SELECT b1.*,
                (SELECT SUM(b2.CAPRCO1) 
                 FROM #BaseDatos b2 
                 WHERE b2.EMPRESA = b1.EMPRESA AND b2.SULIDO = b1.SULIDO 
                   AND b2.BOSULIDO = b1.BOSULIDO AND b2.KOPRCT = b1.KOPRCT
                   AND (b2.FEEMLI < b1.FEEMLI OR (b2.FEEMLI = b1.FEEMLI AND b2.IDMAEDDO <= b1.IDMAEDDO))
                ) AS AcumUd1,
                (SELECT SUM(b2.CAPRCO2) 
                 FROM #BaseDatos b2 
                 WHERE b2.EMPRESA = b1.EMPRESA AND b2.SULIDO = b1.SULIDO 
                   AND b2.BOSULIDO = b1.BOSULIDO AND b2.KOPRCT = b1.KOPRCT
                   AND (b2.FEEMLI < b1.FEEMLI OR (b2.FEEMLI = b1.FEEMLI AND b2.IDMAEDDO <= b1.IDMAEDDO))
                ) AS AcumUd2
            FROM #BaseDatos b1
        ),
        Calc AS (
            SELECT *,
                ROUND(STFI1 + TotalUd1, 5) AS StockInicialUd1, ROUND(STFI2 + TotalUd2, 5) AS StockInicialUd2,
                ROUND((STFI1 + TotalUd1) - (AcumUd1 - CAPRCO1), 5) AS StockAntesUd1, ROUND((STFI2 + TotalUd2) - (AcumUd2 - CAPRCO2), 5) AS StockAntesUd2,
                ROUND((STFI1 + TotalUd1) - AcumUd1, 5) AS StockDespuesUd1, ROUND((STFI2 + TotalUd2) - AcumUd2, 5) AS StockDespuesUd2
            FROM Mov
        ),
        ResultadoFinal AS (
            SELECT C.*, ISNULL(Een.NOKOEN, 'SIN NOMBRE') AS Nokoen, CAST('' As varchar(3)) AS ListaP,
                CASE WHEN StockDespuesUd1 < 0 THEN 1 ELSE 0 END AS Ud1_negativo,
                CASE WHEN StockDespuesUd2 < 0 THEN 1 ELSE 0 END AS Ud2_negativo,
                CASE WHEN StockDespuesUd1 >= 0 THEN 0 WHEN StockAntesUd1 >= 0 THEN ROUND(ABS(StockDespuesUd1),5) ELSE ROUND(CAPRCO1,5) END AS Comprarud1,
                CASE WHEN StockDespuesUd2 >= 0 THEN 0 WHEN StockAntesUd2 >= 0 THEN ROUND(ABS(StockDespuesUd2),5) ELSE ROUND(CAPRCO2,5) END AS Comprarud2
            FROM Calc C
            LEFT JOIN MAEEN Een WITH (NOLOCK) ON C.ENDO = Een.KOEN AND C.SUENDO = Een.SUEN
        )
        SELECT * 
        FROM ResultadoFinal
        {filtroExclusion}
        AND IDMAEEDO NOT IN (
    SELECT Idmaeedo 
    FROM {Global_BaseBk}Zw_InterStock_Enc 
)
        ORDER BY IDMAEEDO, IDMAEDDO;
        
        -- 5. Limpieza de memoria
        DROP TABLE #BaseDatos;
        "

        Return retorno
    End Function
    'Private Function GenerarConsultaSelectInterStock(filtroExclusion As String) As String
    '    Dim retorno As String = $"
    '    Declare @FechaDesde Datetime = GetDate() - 30;
    '    Declare @FechaHasta Datetime = GetDate();
    '    WITH Mov AS (
    '        SELECT Ddo.IDMAEEDO, Ddo.IDMAEDDO, Ddo.TIDO, Ddo.NUDO, Ddo.ENDO, Ddo.SUENDO, 
    '               Ddo.EMPRESA, Ddo.SULIDO, Ddo.BOSULIDO, Ddo.KOPRCT, Ddo.CAPRCO1, Ddo.CAPRCO2, Ddo.FEEMLI as Fecha,
    '               Mst.STFI1, Mst.STFI2, Ddo.FEEMLI,
    '               SUM(Ddo.CAPRCO1) OVER(PARTITION BY Ddo.EMPRESA, Ddo.SULIDO, Ddo.BOSULIDO, Ddo.KOPRCT ORDER BY Ddo.FEEMLI, Ddo.IDMAEDDO) AS AcumUd1,
    '               SUM(Ddo.CAPRCO2) OVER(PARTITION BY Ddo.EMPRESA, Ddo.SULIDO, Ddo.BOSULIDO, Ddo.KOPRCT ORDER BY Ddo.FEEMLI, Ddo.IDMAEDDO) AS AcumUd2,
    '               SUM(Ddo.CAPRCO1) OVER(PARTITION BY Ddo.EMPRESA, Ddo.SULIDO, Ddo.BOSULIDO, Ddo.KOPRCT) AS TotalUd1,
    '               SUM(Ddo.CAPRCO2) OVER(PARTITION BY Ddo.EMPRESA, Ddo.SULIDO, Ddo.BOSULIDO, Ddo.KOPRCT) AS TotalUd2
    '        FROM MAEDDO Ddo
    '        LEFT JOIN MAEST Mst ON Ddo.EMPRESA = Mst.EMPRESA AND Ddo.SULIDO = Mst.KOSU AND Ddo.BOSULIDO = Mst.KOBO AND Ddo.KOPRCT = Mst.KOPR
    '        WHERE Ddo.IDMAEEDO IN (
    '            SELECT Edo.IDMAEEDO FROM MAEEDO Edo 
    '            INNER JOIN MAEDDO Ddo ON Edo.IDMAEEDO = Ddo.IDMAEEDO
    '            WHERE Edo.TIDO = 'FCV' AND Ddo.LINCONDESP = 1 
    '              AND Ddo.FEEMLI >= @FechaDesde AND Ddo.FEEMLI <= @FechaHasta 
    '              AND NOT EXISTS (SELECT 1 FROM {Global_BaseBk}Zw_InterStock_Det ZI WHERE ZI.Idmaeddo = Ddo.IDMAEDDO)
    '        )
    '    ),
    '    Calc AS (
    '        SELECT *,
    '            ROUND(STFI1 + TotalUd1, 5) AS StockInicialUd1, ROUND(STFI2 + TotalUd2, 5) AS StockInicialUd2,
    '            ROUND((STFI1 + TotalUd1) - (AcumUd1 - CAPRCO1), 5) AS StockAntesUd1, ROUND((STFI2 + TotalUd2) - (AcumUd2 - CAPRCO2), 5) AS StockAntesUd2,
    '            ROUND((STFI1 + TotalUd1) - AcumUd1, 5) AS StockDespuesUd1, ROUND((STFI2 + TotalUd2) - AcumUd2, 5) AS StockDespuesUd2
    '        FROM Mov
    '    )
    '    SELECT C.*, ISNULL(Een.NOKOEN, 'SIN NOMBRE') AS Nokoen,CAST('' As varchar(3)) AS ListaP,
    '        CASE WHEN StockDespuesUd1 < 0 THEN 1 ELSE 0 END AS Ud1_negativo,
    '        CASE WHEN StockDespuesUd2 < 0 THEN 1 ELSE 0 END AS Ud2_negativo,
    '        CASE WHEN StockDespuesUd1 >= 0 THEN 0 WHEN StockAntesUd1 >= 0 THEN ROUND(ABS(StockDespuesUd1),5) ELSE ROUND(CAPRCO1,5) END AS Comprarud1,
    '        CASE WHEN StockDespuesUd2 >= 0 THEN 0 WHEN StockAntesUd2 >= 0 THEN ROUND(ABS(StockDespuesUd2),5) ELSE ROUND(CAPRCO2,5) END AS Comprarud2
    '    FROM Calc C
    '    LEFT JOIN MAEEN Een ON C.ENDO = Een.KOEN AND C.SUENDO = Een.SUEN
    '    {filtroExclusion}
    '    ORDER BY C.IDMAEEDO, C.IDMAEDDO;"

    '    Dim retorno_Prueba = $"
    '    Declare @FechaDesde Datetime = CAST(GetDate() AS DATE);
    '    Declare @FechaHasta Datetime = GetDate();
    '    WITH Mov AS (
    '        SELECT Ddo.IDMAEEDO, Ddo.IDMAEDDO, Ddo.TIDO, Ddo.NUDO, Ddo.ENDO, Ddo.SUENDO, 
    '               Ddo.EMPRESA, Ddo.SULIDO, Ddo.BOSULIDO, Ddo.KOPRCT, Ddo.CAPRCO1, Ddo.CAPRCO2, Ddo.FEEMLI as Fecha,
    '               Mst.STFI1, Mst.STFI2, Ddo.FEEMLI,
    '               SUM(Ddo.CAPRCO1) OVER(PARTITION BY Ddo.EMPRESA, Ddo.SULIDO, Ddo.BOSULIDO, Ddo.KOPRCT ORDER BY Ddo.FEEMLI, Ddo.IDMAEDDO) AS AcumUd1,
    '               SUM(Ddo.CAPRCO2) OVER(PARTITION BY Ddo.EMPRESA, Ddo.SULIDO, Ddo.BOSULIDO, Ddo.KOPRCT ORDER BY Ddo.FEEMLI, Ddo.IDMAEDDO) AS AcumUd2,
    '               SUM(Ddo.CAPRCO1) OVER(PARTITION BY Ddo.EMPRESA, Ddo.SULIDO, Ddo.BOSULIDO, Ddo.KOPRCT) AS TotalUd1,
    '               SUM(Ddo.CAPRCO2) OVER(PARTITION BY Ddo.EMPRESA, Ddo.SULIDO, Ddo.BOSULIDO, Ddo.KOPRCT) AS TotalUd2
    '        FROM MAEDDO Ddo
    '        LEFT JOIN MAEST Mst ON Ddo.EMPRESA = Mst.EMPRESA AND Ddo.SULIDO = Mst.KOSU AND Ddo.BOSULIDO = Mst.KOBO AND Ddo.KOPRCT = Mst.KOPR
    '        WHERE Ddo.IDMAEEDO IN (
    '            SELECT Edo.IDMAEEDO FROM MAEEDO Edo 
    '            INNER JOIN MAEDDO Ddo ON Edo.IDMAEEDO = Ddo.IDMAEEDO
    '            WHERE Edo.TIDO = 'FCV' AND Ddo.LINCONDESP = 1 
    '              AND Ddo.FEEMLI >= @FechaDesde AND Ddo.FEEMLI <= @FechaHasta 
    '              AND NOT EXISTS (SELECT 1 FROM {Global_BaseBk}Zw_InterStock_Det ZI WHERE ZI.Idmaeddo = Ddo.IDMAEDDO)
    '        ) 
    '    ),
    '    Calc AS (
    '        SELECT *,
    '            ROUND(STFI1 + TotalUd1, 5) AS StockInicialUd1, ROUND(STFI2 + TotalUd2, 5) AS StockInicialUd2,
    '            ROUND((STFI1 + TotalUd1) - (AcumUd1 - CAPRCO1), 5) AS StockAntesUd1, ROUND((STFI2 + TotalUd2) - (AcumUd2 - CAPRCO2), 5) AS StockAntesUd2,
    '            ROUND((STFI1 + TotalUd1) - AcumUd1, 5) AS StockDespuesUd1, ROUND((STFI2 + TotalUd2) - AcumUd2, 5) AS StockDespuesUd2
    '        FROM Mov
    '    )
    '    SELECT C.*, ISNULL(Een.NOKOEN, 'SIN NOMBRE') AS Nokoen,'' AS ListaP,
    '        CASE WHEN StockDespuesUd1 < 0 THEN 1 ELSE 0 END AS Ud1_negativo,
    '        CASE WHEN StockDespuesUd2 < 0 THEN 1 ELSE 0 END AS Ud2_negativo,
    '        CASE WHEN StockDespuesUd1 >= 0 THEN 0 WHEN StockAntesUd1 >= 0 THEN ROUND(ABS(StockDespuesUd1),5) ELSE ROUND(CAPRCO1,5) END AS Comprarud1,
    '        CASE WHEN StockDespuesUd2 >= 0 THEN 0 WHEN StockAntesUd2 >= 0 THEN ROUND(ABS(StockDespuesUd2),5) ELSE ROUND(CAPRCO2,5) END AS Comprarud2
    '    FROM Calc C
    '    LEFT JOIN MAEEN Een ON C.ENDO = Een.KOEN AND C.SUENDO = Een.SUEN
    '    {filtroExclusion}
    '    ORDER BY C.IDMAEEDO, C.IDMAEDDO;"
    '    Return retorno_Prueba

    'End Function

    Private Function GenerarConsultaSelectInterStockCredito(filtroExclusion As String) As String
        Dim retorno As String = $"
        DECLARE @FechaDesde DATETIME = CAST((GETDATE() - 1) AS DATE);
        DECLARE @FechaHasta DATETIME = GETDATE();

        SET NOCOUNT ON;

        IF OBJECT_ID('tempdb..#BaseDatos') IS NOT NULL 
            DROP TABLE #BaseDatos;

        SELECT 
            Ddo.IDMAEEDO, Ddo.IDMAEDDO, Ddo.TIDO, Ddo.NUDO, Ddo.ENDO, Ddo.SUENDO, 
            Ddo.EMPRESA, Ddo.SULIDO, Ddo.BOSULIDO, Ddo.KOPRCT, Ddo.CAPRCO1, Ddo.CAPRCO2, 
            Ddo.FEEMLI AS Fecha,
            Mst.STFI1, Mst.STFI2, Ddo.FEEMLI,
            Ddo.IDRST,   -- IMPORTANTE: ID de la factura asociada
            SUM(Ddo.CAPRCO1) OVER(PARTITION BY Ddo.EMPRESA, Ddo.SULIDO, Ddo.BOSULIDO, Ddo.KOPRCT) AS TotalUd1,
            SUM(Ddo.CAPRCO2) OVER(PARTITION BY Ddo.EMPRESA, Ddo.SULIDO, Ddo.BOSULIDO, Ddo.KOPRCT) AS TotalUd2
        INTO #BaseDatos
        FROM MAEDDO Ddo WITH (NOLOCK)
        LEFT JOIN MAEST Mst WITH (NOLOCK) 
               ON Ddo.EMPRESA = Mst.EMPRESA 
              AND Ddo.SULIDO = Mst.KOSU 
              AND Ddo.BOSULIDO = Mst.KOBO 
              AND Ddo.KOPRCT = Mst.KOPR
        WHERE Ddo.IDMAEEDO IN (
            SELECT Edo.IDMAEEDO
            FROM MAEEDO Edo WITH (NOLOCK)
            INNER JOIN MAEDDO Ddo2 WITH (NOLOCK) ON Edo.IDMAEEDO = Ddo2.IDMAEEDO
            WHERE (Edo.TIDO = 'NCV' OR Edo.TIDO = 'GRD')
              AND Ddo2.LINCONDESP = 1
              AND Ddo2.FEEMLI >= @FechaDesde
              AND Ddo2.FEEMLI <= @FechaHasta

              -- NCV que NO están en InterStock
              AND NOT EXISTS (
                    SELECT 1 
                    FROM {Global_BaseBk}Zw_InterStock_Det ZI WITH (NOLOCK) 
                    WHERE ZI.Idmaeddo = Ddo2.IDMAEDDO 
              )

              -- NUEVO FILTRO: La factura asociada (IDRST) debe estar en Zw_InterStock_Det
              AND EXISTS (
                    SELECT 1
                    FROM MAEDDO Fcv WITH (NOLOCK)
                    INNER JOIN {Global_BaseBk}Zw_InterStock_Det ZI2 WITH (NOLOCK)
                        ON ZI2.Idmaeddo = Fcv.IDMAEDDO
                    WHERE Fcv.IDMAEDDO = Ddo2.IDRST AND ZI2.Idmaeedo_OCC <> 0
              )
        )
        AND Ddo.TIPR = 'FPN'
        AND Ddo.PRCT = 0
        AND Ddo.TICT = ''

        -- FILTRO: Bodega válida según equivalencia
        AND EXISTS (
            SELECT 1 
            FROM {Global_BaseBk}Zw_InterStock_Equivalencia Eq WITH (NOLOCK)
            WHERE Eq.Activo2 = 1 
              AND (Eq.Bodega_A = Ddo.BOSULIDO OR Eq.Bodega_B = Ddo.BOSULIDO)
        );

        -- Índice para acelerar acumulados
        CREATE CLUSTERED INDEX IX_BaseDatos_Acumulado 
        ON #BaseDatos (EMPRESA, SULIDO, BOSULIDO, KOPRCT, FEEMLI, IDMAEDDO);

        WITH Mov AS (
            SELECT b1.*,
                (SELECT SUM(b2.CAPRCO1)
                 FROM #BaseDatos b2
                 WHERE b2.EMPRESA = b1.EMPRESA 
                   AND b2.SULIDO = b1.SULIDO
                   AND b2.BOSULIDO = b1.BOSULIDO
                   AND b2.KOPRCT = b1.KOPRCT
                   AND (b2.FEEMLI < b1.FEEMLI 
                        OR (b2.FEEMLI = b1.FEEMLI AND b2.IDMAEDDO <= b1.IDMAEDDO))
                ) AS AcumUd1,
                (SELECT SUM(b2.CAPRCO2)
                 FROM #BaseDatos b2
                 WHERE b2.EMPRESA = b1.EMPRESA 
                   AND b2.SULIDO = b1.SULIDO
                   AND b2.BOSULIDO = b1.BOSULIDO
                   AND b2.KOPRCT = b1.KOPRCT
                   AND (b2.FEEMLI < b1.FEEMLI 
                        OR (b2.FEEMLI = b1.FEEMLI AND b2.IDMAEDDO <= b1.IDMAEDDO))
                ) AS AcumUd2
            FROM #BaseDatos b1
        ),
        Calc AS (
            SELECT *
            FROM Mov
        ),
        ResultadoFinal AS (
            SELECT 
                C.*, 
                ISNULL(Een.NOKOEN, 'SIN NOMBRE') AS Nokoen,
                CAST('' AS VARCHAR(3)) AS ListaP,

                -- CAMPOS DE LA FACTURA ASOCIADA
                Fcv.IDMAEDDO AS IDMAEDDO_Fcv,
                Fcv.TIDO AS TIDO_Fcv,
                Fcv.NUDO AS NUDO_Fcv,
                Fcv.ENDO AS ENDO_Fcv,
                Fcv.SUENDO AS SUENDO_Fcv,
                Fcv.CAPRCO1 AS CAPRCO1_Fcv,
                Fcv.CAPRCO2 AS CAPRCO2_Fcv

            FROM Calc C
            LEFT JOIN MAEEN Een WITH (NOLOCK) 
                   ON C.ENDO = Een.KOEN AND C.SUENDO = Een.SUEN
            LEFT JOIN MAEDDO Fcv WITH (NOLOCK)
                   ON C.IDRST = Fcv.IDMAEDDO
        )
        SELECT 
            r.*, 
            dt.Idmaeedo_FCC AS Idmaeedo_FCC, 
            dt.Idmaeddo_FCC AS IDMAEDDO_FCC, 
            dt.Tido_FCC AS TIDO_FCC, 
            dt.Nudo_FCC AS NUDO_FCC, 
            dt.Empresa_FCC AS Empresa_FCC,
            dt.Idmaeedo_FCV AS Idmaeedo_FCV1, 
            dt.Idmaeddo_FCV as IDMAEDDO_FCV1,
            dt.Tido_FCV AS TIDO_FCV1, 
            dt.Nudo_FCV AS NUDO_FCV1, 
            dt.Empresa_FCV AS Empresa_FCV1

        FROM ResultadoFinal r
        INNER JOIN {Global_BaseBk}Zw_InterStock_Det dt ON dt.Idmaeddo = r.IDMAEDDO_Fcv
        {filtroExclusion}
        AND r.IDMAEEDO NOT IN (
              SELECT Idmaeedo 
              FROM {Global_BaseBk}Zw_InterStock_Enc
        )
        ORDER BY r.IDMAEEDO, r.IDMAEDDO;

        DROP TABLE #BaseDatos;
        "

        Return retorno
    End Function
    Private Sub ConstruirInsertEncabezado(sb As StringBuilder, Fila As DataRow, Idmaeedo As Integer, EmpresaDoc As String, Nudo As String)
        Dim NokoenLimpio As String = Fila("Nokoen").ToString().Replace("'", "''")
        sb.AppendLine($"
        IF NOT EXISTS (SELECT 1 FROM {Global_BaseBk}Zw_InterStock_Enc WHERE Idmaeedo = {Idmaeedo})
        BEGIN
            INSERT INTO {Global_BaseBk}Zw_InterStock_Enc
            (Idmaeedo, Empresa, Tido, Nudo, Endo, Suendo, Nokoen, Estado, Procesar, Procesando, Procesada, Error, Observacion, FechaIngreso)
            VALUES ({Idmaeedo}, '{EmpresaDoc}', '{Fila("TIDO")}', '{Nudo}', '{Fila("ENDO")}', '{Fila("SUENDO")}', 
             '{NokoenLimpio}', 'PENDIENTE',0 , 0, 0, 0, '', '{Format(Fila("Fecha"), "yyyyMMdd")}');
            SET @Id_Enc = SCOPE_IDENTITY(); 
        END
        ELSE BEGIN
            SELECT @Id_Enc = Id_Enc FROM {Global_BaseBk}Zw_InterStock_Enc WHERE Idmaeedo = {Idmaeedo};
        END")
    End Sub
    Private Sub ConstruirInsertEncabezadoCredito(sb As StringBuilder, Fila As DataRow, Idmaeedo As Integer, EmpresaDoc As String, Nudo As String)
        Dim NokoenLimpio As String = Fila("Nokoen").ToString().Replace("'", "''")
        sb.AppendLine($"
        IF NOT EXISTS (SELECT 1 FROM {Global_BaseBk}Zw_InterStock_Enc WHERE Idmaeedo = {Idmaeedo})
        BEGIN
            INSERT INTO {Global_BaseBk}Zw_InterStock_Enc
            (Idmaeedo, Empresa, Tido, Nudo, Endo, Suendo, Nokoen, Estado, Procesar, Procesando, Procesada, Error, Observacion, FechaIngreso)
            VALUES ({Idmaeedo}, '{EmpresaDoc}', '{Fila("TIDO")}', '{Nudo}', '{Fila("ENDO")}', '{Fila("SUENDO")}', 
             '{NokoenLimpio}', 'PENDIENTE',1 , 0, 0, 0, '', '{Format(Fila("Fecha"), "yyyyMMdd")}');
            SET @Id_Enc = SCOPE_IDENTITY(); 
        END
        ELSE BEGIN
            SELECT @Id_Enc = Id_Enc FROM {Global_BaseBk}Zw_InterStock_Enc WHERE Idmaeedo = {Idmaeedo};
        END")
    End Sub
    Private Sub ConstruirInsertDetalleCredito(sb As StringBuilder, Fila As DataRow, Idmaeedo As Integer, Nudo As String)
        Dim formateaNum = Function(val As Object) val.ToString().Replace(",", ".")

        sb.AppendLine($"
INSERT INTO {Global_BaseBk}Zw_InterStock_Det 
(
    Id_Enc, Idmaeedo, Idmaeddo, Tido, Nudo, Endo, Suendo, Empresa, Sucursal, Bodega, Codigo, Caprco1, Caprco2, CodLista,
    Empresa_FCV, Idmaeedo_FCV, Idmaeddo_FCV, Tido_FCV, Nudo_FCV,
    Empresa_FCC, Idmaeedo_FCC, Idmaeddo_FCC, Tido_FCC, Nudo_FCC,
    Comprarud1,Comprarud2
)
VALUES 
(
    @Id_Enc, 
    {Idmaeedo}, 
    {Fila("IDMAEDDO")}, 
    '{Fila("TIDO")}', 
    '{Nudo}', 
    '{Fila("ENDO")}', 
    '{Fila("SUENDO")}', 
    '{Fila("EMPRESA")}', 
    '{Fila("SULIDO")}', 
    '{Fila("BOSULIDO")}', 
    '{Fila("KOPRCT")}', 
    {formateaNum(Fila("CAPRCO1"))}, 
    {formateaNum(Fila("CAPRCO2"))}, 
    '{Fila("ListaP")}', 

    -- Campos FCV
   '{Fila("Empresa_FCV1")}', 
    {Fila("Idmaeedo_FCV1")}, 
    {Fila("IDMAEDDO_FCV1")}, 
    '{Fila("TIDO_FCV1")}', 
    '{Fila("NUDO_FCV1")}',
    
    -- Campos FCC
    '{Fila("Empresa_FCC")}', 
    {Fila("Idmaeedo_FCC")}, 
    {Fila("IDMAEDDO_FCC")}, 
    '{Fila("TIDO_FCC")}', 
    '{Fila("NUDO_FCC")}',
     -- Campos compra
    {formateaNum(Fila("CAPRCO1"))},
    {formateaNum(Fila("CAPRCO2"))}
);")
    End Sub
    Private Sub ConstruirInsertDetalle(sb As StringBuilder, Fila As DataRow, Idmaeedo As Integer, Nudo As String)
        Dim formateaNum = Function(val As Object) val.ToString().Replace(",", ".")
        sb.AppendLine($"
    INSERT INTO {Global_BaseBk}Zw_InterStock_Det 
    (Id_Enc, Idmaeedo, Idmaeddo, Tido, Nudo, Endo, Suendo, Empresa, Sucursal, Bodega, Codigo, Caprco1, Caprco2, 
     Stockinicialud1, Stockinicialud2, Stockantesud1, Stockantesud2, Stockdespuesud1, Stockdespuesud2, 
     Ud1_negativo, Ud2_negativo, Comprarud1, Comprarud2,CodLista)
    VALUES (@Id_Enc, {Idmaeedo}, {Fila("IDMAEDDO")}, '{Fila("TIDO")}', '{Nudo}', '{Fila("ENDO")}', '{Fila("SUENDO")}', 
     '{Fila("EMPRESA")}', '{Fila("SULIDO")}', '{Fila("BOSULIDO")}', '{Fila("KOPRCT")}', 
     {formateaNum(Fila("CAPRCO1"))}, {formateaNum(Fila("CAPRCO2"))}, {formateaNum(Fila("StockInicialUd1"))}, {formateaNum(Fila("StockInicialUd2"))}, 
     {formateaNum(Fila("StockAntesUd1"))}, {formateaNum(Fila("StockAntesUd2"))}, {formateaNum(Fila("StockDespuesUd1"))}, {formateaNum(Fila("StockDespuesUd2"))}, 
     {Fila("Ud1_negativo")}, {Fila("Ud2_negativo")}, {formateaNum(Fila("Comprarud1"))}, {formateaNum(Fila("Comprarud2"))}, '{Fila("ListaP")}');")
    End Sub

    Private Sub ConstruirUpdateProcesar(sb As StringBuilder)
        sb.AppendLine($"
        UPDATE Enc SET Enc.Procesar = 1
        FROM {Global_BaseBk}Zw_InterStock_Enc Enc
        WHERE Enc.Estado = 'PENDIENTE' AND Enc.Procesar = 0 And Enc.Procesando = 0 And Enc.Error = 0 And Enc.Procesada = 0 AND EXISTS (
            SELECT 1 FROM {Global_BaseBk}Zw_InterStock_Det Det 
            WHERE Det.Id_Enc = Enc.Id_Enc AND (Det.Comprarud1 > 0)
        );")
        sb.AppendLine($"
        UPDATE Enc SET Enc.Estado = 'EXCLUIDA', Enc.Observacion = 'Documento omitido'
        FROM {Global_BaseBk}Zw_InterStock_Enc Enc
        WHERE Enc.Estado = 'PENDIENTE'AND Enc.Procesar = 0 And Enc.Procesando = 0 And Enc.Error = 0 And Enc.Procesada = 0 AND EXISTS (
            SELECT 1 FROM {Global_BaseBk}Zw_InterStock_Det Det 
            WHERE Det.Id_Enc = Enc.Id_Enc AND (Det.Comprarud1 = 0)
        );")
    End Sub

#End Region

    Public Function actualiza_precio() As Mensajes
        Dim _Mensaje As New Mensajes
        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)

        Try
            Dim Consulta_sql As String = $"
        SELECT *
        FROM {_Global_BaseBk}Zw_InterStock_Enc Enc
        INNER JOIN {_Global_BaseBk}Zw_InterStock_Det Det ON Enc.Id_Enc = Det.Id_Enc
        WHERE Enc.Procesar = 1 
          AND Det.Costo = 0"

            Dim _Tbl_Detalles As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql, False)

            If Not IsNothing(_Tbl_Detalles) AndAlso _Tbl_Detalles.Rows.Count > 0 Then
                Dim _Consultas_Update As New System.Text.StringBuilder()

                For Each fila As DataRow In _Tbl_Detalles.Rows
                    Dim empresa As String = fila("Empresa").ToString()



                    Dim dtEntidadComprador As DataTable = Nothing
                    Dim dtEntidadVendedor As DataTable = Nothing
                    Dim dtModComprador As DataTable = Nothing
                    Dim dtModVendedor As DataTable = Nothing
                    Dim CodEmpresaVendedor As String

                    ' MODIFICADO: Mapeo de tablas internas usando la nueva estructura de clases por Empresa
                    If empresa = "01" Then
                        dtEntidadComprador = Empresa01.EntidadDeCompra
                        dtEntidadVendedor = Empresa02.EntidadDeVenta
                        dtModComprador = Empresa01.ModalidadOCC
                        dtModVendedor = Empresa02.ModalidadNVV
                        CodEmpresaVendedor = "02"
                    Else
                        dtEntidadComprador = Empresa02.EntidadDeCompra
                        dtEntidadVendedor = Empresa01.EntidadDeVenta
                        dtModComprador = Empresa02.ModalidadOCC
                        dtModVendedor = Empresa01.ModalidadNVV
                        CodEmpresaVendedor = "01"
                    End If
                    Dim Lista As String = ""

                    Dim Consulta_Lista As String = $"Select top 1 RIGHT(LVEN, 3) AS CodLista from MAEEN where KOEN = '{dtEntidadVendedor.Rows(0).Item("Codigo").ToString().Trim()}'"
                    Dim _Tbl_precio As DataTable = _Sql.Fx_Get_DataTable(Consulta_Lista, False)
                    If Not IsNothing(_Tbl_precio) AndAlso _Tbl_precio.Rows.Count > 0 Then
                        For Each fila1 As DataRow In _Tbl_precio.Rows
                            Lista = fila1("CodLista").ToString()
                        Next
                    Else
                        _Mensaje.EsCorrecto = False
                        _Mensaje.Detalle = "No se pudo obtener la lista de precios del vendedor."
                        Return _Mensaje
                    End If


                    Dim idDetalle As String = fila("Id_Det").ToString()
                    Dim _Codto As Double
                    Dim ListaCodigos As New List(Of String)()
                    ListaCodigos.Add("MERMA")
                    If ListaCodigos.Contains(fila("Codigo")) Then

                        _Codto = 0

                    Else

                        _Codto = calcula_precio(Lista, fila("Codigo").ToString(), fila("EMPRESA").ToString())

                    End If
                    Dim Costo As Double = Math.Round(_Codto, 5)
                    _Consultas_Update.AppendLine($"UPDATE {_Global_BaseBk}Zw_InterStock_Det SET Costo = {De_Num_a_Tx_01(Costo, False, 5)}, CodLista = '{Lista}' WHERE Id_Det = {idDetalle};")
                Next

                Dim EjecucionCorrecta As Boolean = _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(_Consultas_Update.ToString(), False)

                If EjecucionCorrecta Then
                    _Mensaje.EsCorrecto = True
                    _Mensaje.Detalle = $"Se actualizaron los costos de {_Tbl_Detalles.Rows.Count} líneas de detalle."
                    _Mensaje.Mensaje = "OK."
                Else
                    Throw New Exception("La actualización masiva de precios falló en SQL Server.")
                End If
            Else
                _Mensaje.EsCorrecto = True
                _Mensaje.Detalle = "No se encontraron detalles con costo cero para encabezados pendientes de procesar."
                _Mensaje.Mensaje = "OK."
            End If

        Catch ex As Exception
            _Mensaje.EsCorrecto = False
            _Mensaje.Detalle = "Error en actualiza_precio: " & ex.Message
            _Mensaje.Mensaje = "ERROR."
        Finally
            If _Sql IsNot Nothing Then _Sql.Sb_Cerrar_Conexion2()
        End Try

        Return _Mensaje
    End Function

    Public Function calcula_precio(_CodLista As String, _Codigo As String, _Empresa As String) As Double
        Dim _Koen As String = String.Empty
        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
        Dim _PrecioListaUd1 As Double = 0

        Try
            ' MODIFICADO: Adaptado para leer los códigos y modalidades desde Empresa01 y Empresa02
            If _Empresa = "01" Then
                _Koen = Empresa02.EntidadDeCompra.Rows(0).Item("Codigo").ToString().Trim()
                Dim Modalidad As String = Empresa02.ModalidadNVV.Rows(0).Item("Codigo").ToString().Trim()
                CambioEmpresa("02", Modalidad)
            Else
                _Koen = Empresa01.EntidadDeCompra.Rows(0).Item("Codigo").ToString().Trim()
                Dim Modalidad As String = Empresa01.ModalidadNVV.Rows(0).Item("Codigo").ToString().Trim()
                CambioEmpresa("01", Modalidad)
            End If

            Dim _RowPrecios As DataRow
            Dim _Ecuacion As String
            Dim _Ecuacionu2 As String
            Dim _PrecioListaUd2 As Double

            Consulta_sql = "Select Top 1 *,(Select top 1 MELT From TABPP Where KOLT = '" & _CodLista & "') as MELT From TABPRE" & vbCrLf &
                           "Where KOLT = '" & _CodLista & "' And KOPR = '" & _Codigo & "'"
            _RowPrecios = _Sql.Fx_Get_DataRow(Consulta_sql, False)

            If _RowPrecios IsNot Nothing Then
                Dim _DescMaximo As Double = NuloPorNro(_RowPrecios.Item("DTMA01UD"), 0)
                _Ecuacion = NuloPorNro(_RowPrecios.Item("ECUACION").ToString.Trim, "")
                _Ecuacionu2 = NuloPorNro(_RowPrecios.Item("ECUACIONU2").ToString.Trim, "")

                If String.IsNullOrEmpty(_Ecuacion.Trim) Then
                    _Ecuacion = _Sql.Fx_Trae_Dato("TABPP", "ECUDEF01UD", "KOLT = '" & _CodLista & "'", _Mostrar_Error:=False).ToString.Trim
                End If

                If String.IsNullOrEmpty(_Ecuacionu2.Trim) Then
                    _Ecuacionu2 = _Sql.Fx_Trae_Dato("TABPP", "ECUDEF02UD", "KOLT = '" & _CodLista & "'", _Mostrar_Error:=False).ToString.Trim
                End If

                _PrecioListaUd1 = Fx_Funcion_Ecuacion_Random(Nothing, _Koen, _Ecuacion, _Codigo, 1, _RowPrecios, 0, 0, 0, False)
                _PrecioListaUd2 = Fx_Funcion_Ecuacion_Random(Nothing, _Koen, _Ecuacionu2, _Codigo, 2, _RowPrecios, 0, 0, 0, False)
            End If

        Catch ex As Exception
            _PrecioListaUd1 = 0
        Finally
            If _Sql IsNot Nothing Then _Sql.Sb_Cerrar_Conexion2()
        End Try

        Return _PrecioListaUd1
    End Function


    Public Function ObtenerFecha(IdEnc As String) As Date
        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
        Dim _Fecha As Date = Date.MinValue
        Try
            Consulta_sql = $"SELECT FechaIngreso AS FechaActual FROM {Global_BaseBk}Zw_InterStock_Enc  WHERE Id_Enc = " & IdEnc
            Dim _Row As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql, False)
            If _Row IsNot Nothing Then
                _Fecha = Convert.ToDateTime(_Row.Item("FechaActual"))
            End If
        Catch ex As Exception
            Throw New Exception("Error al obtener la fecha actual: " & ex.Message)
        Finally
            If _Sql IsNot Nothing Then _Sql.Sb_Cerrar_Conexion2()
        End Try
        Return _Fecha
    End Function

    Public Sub SincronizarDocumentos(IdEnc As String, Txt_Log As Object)
        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
        Dim Consulta_sql_p As String = $"
-- 1. ACTUALIZAR LAS OCC (Resta 10)
UPDATE m
SET HORAGRAB = orig.HORAGRAB - 10
FROM MAEEDO m
INNER JOIN {Global_BaseBk}Zw_InterStock_Det d ON m.IDMAEEDO = d.Idmaeedo_OCC
INNER JOIN {Global_BaseBk}Zw_InterStock_Enc e ON e.Id_Enc = d.Id_Enc 
INNER JOIN MAEEDO orig ON d.Idmaeedo = orig.IDMAEEDO    
WHERE e.Id_Enc = {IdEnc} 
  AND d.Tido_OCC IS NOT NULL AND d.Tido_OCC <> '';

-- 2. ACTUALIZAR LAS NVV (Resta 8)
UPDATE m
SET HORAGRAB = orig.HORAGRAB - 8
FROM MAEEDO m
INNER JOIN {Global_BaseBk}Zw_InterStock_Det d ON m.IDMAEEDO = d.Idmaeedo_NVV
INNER JOIN {Global_BaseBk}Zw_InterStock_Enc e ON e.Id_Enc = d.Id_Enc 
INNER JOIN MAEEDO orig ON d.Idmaeedo = orig.IDMAEEDO 
WHERE e.Id_Enc = {IdEnc} 
  AND d.Tido_NVV IS NOT NULL AND d.Tido_NVV <> '';

-- 3. ACTUALIZAR LAS FCV (Resta 6)
UPDATE m
SET HORAGRAB = orig.HORAGRAB - 6
FROM MAEEDO m
INNER JOIN {Global_BaseBk}Zw_InterStock_Det d ON m.IDMAEEDO = d.Idmaeedo_FCV
INNER JOIN {Global_BaseBk}Zw_InterStock_Enc e ON e.Id_Enc = d.Id_Enc 
INNER JOIN MAEEDO orig ON d.Idmaeedo = orig.IDMAEEDO  -- <-- Corregido aquí
WHERE e.Id_Enc = {IdEnc} 
  AND d.Tido_FCV IS NOT NULL AND d.Tido_FCV <> '' 
  AND m.IDMAEEDO <> d.Idmaeedo;  -- <-- Optimizado para usar IDMAEEDO

-- 4. ACTUALIZAR LAS FCC (Resta 4)
UPDATE m
SET HORAGRAB = orig.HORAGRAB - 4
FROM MAEEDO m
INNER JOIN {Global_BaseBk}Zw_InterStock_Det d ON m.IDMAEEDO = d.Idmaeedo_FCC
INNER JOIN {Global_BaseBk}Zw_InterStock_Enc e ON e.Id_Enc = d.Id_Enc 
INNER JOIN MAEEDO orig ON d.Idmaeedo = orig.IDMAEEDO
WHERE e.Id_Enc = {IdEnc} 
  AND d.Tido_FCC IS NOT NULL AND d.Tido_FCC <> '';"

        Dim EjecucionCorrecta As Boolean = _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql_p, False)

        If EjecucionCorrecta Then

            LogSeguro("Demonio SincroStock", "Fin del procesamiento de documentos con éxito.", Txt_Log)
        Else
            LogSeguro("Demonio SincroStock", "Fin del procesamiento de documentos con Error.", Txt_Log)

        End If
    End Sub

    Public Sub SincronizarDocumentosCredito(IdEnc As String, Txt_Log As Object)
        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
        Dim Consulta_sql_p As String = $"
-- 1. ACTUALIZAR LAS NCC (Suma 6)
UPDATE m
SET HORAGRAB = orig.HORAGRAB + 6
FROM MAEEDO m
INNER JOIN {Global_BaseBk}Zw_InterStock_Det d ON m.IDMAEEDO = d.Idmaeedo_NCC
INNER JOIN {Global_BaseBk}Zw_InterStock_Enc e ON e.Id_Enc = d.Id_Enc 
INNER JOIN MAEEDO orig ON d.Idmaeedo = orig.IDMAEEDO
WHERE e.Id_Enc = {IdEnc} 
  AND d.Tido_NCC IS NOT NULL AND d.Tido_NCC <> '' 
  AND m.IDMAEEDO <> d.Idmaeedo;

-- 2. ACTUALIZAR LAS NCV (Suma 4)
UPDATE m
SET HORAGRAB = orig.HORAGRAB + 4
FROM MAEEDO m
INNER JOIN {Global_BaseBk}Zw_InterStock_Det d ON m.IDMAEEDO = d.Idmaeedo_NCV
INNER JOIN {Global_BaseBk}Zw_InterStock_Enc e ON e.Id_Enc = d.Id_Enc 
INNER JOIN MAEEDO orig ON d.Idmaeedo = orig.IDMAEEDO
WHERE e.Id_Enc = {IdEnc} 
  AND d.Tido_NCV IS NOT NULL AND d.Tido_NCV <> '';"
        Dim EjecucionCorrecta As Boolean = _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql_p, False)

        If EjecucionCorrecta Then

            LogSeguro("Demonio SincroStock", "Fin del procesamiento de documentos con éxito.", Txt_Log)
        Else
            LogSeguro("Demonio SincroStock", "Fin del procesamiento de documentos con Error.", Txt_Log)

        End If
    End Sub

    Public Function GeneraFCC(Txt_Log As Object, Idmaeedo_OCC As String, Id_Enc As Integer, EmpresaGenera As Empresa, Nudo As String)
        CambioEmpresa(EmpresaGenera.Numero, EmpresaGenera.ModalidadFCC.Rows(0).Item("Codigo").ToString().Trim())

        Dim _Tido = "FCC"
        Dim _Idmaeedo_OCC As String = Idmaeedo_OCC
        Dim _CampoPrecio As String
        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)

        Consulta_sql = $"Select * From MAEEDO Where IDMAEEDO = {_Idmaeedo_OCC}"
        Dim _Row_Maeedo_OCC As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql, False)

        Dim _Koen As String = _Row_Maeedo_OCC.Item("ENDO")
        Dim _Suen As String = _Row_Maeedo_OCC.Item("SUENDO")
        Dim _Nudo As String = Nudo
        Dim Mensaje As Mensajes

        Dim _Fecha_Emision As DateTime? = ObtenerFecha(Id_Enc)
        LogSeguro("Demonio SincroStock", $"Empezando la creacion de la FCC para el documento con IDMAEEDO : {_Idmaeedo_OCC}.", Txt_Log)


        If True Then
            ' Neto
            _CampoPrecio = "PPPRNE"
        Else
            ' Bruto
            _CampoPrecio = "PPPRBR"
        End If

        Consulta_sql = $"Select * From MAEEDO Where IDMAEEDO = {_Idmaeedo_OCC}"
        Dim _Row_OCC As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql, False)

        If Not IsNothing(_Row_OCC) Then

            Try

                Consulta_sql = $"
                   SELECT * FROM MAEEDO Where IDMAEEDO = {_Idmaeedo_OCC}
                   SELECT *,CASE WHEN UDTRPR = 1 THEN CAPRCO1-CAPREX1 ELSE CAPRCO2-CAPREX2 END AS 'Cantidad',
                   CAPRCO1-CAPREX1 AS 'CantUd1_Dori',CAPRCO2-CAPREX2 AS 'CantUd2_Dori',
                   CASE WHEN UDTRPR = 1 THEN {_CampoPrecio} ELSE {_CampoPrecio}*RLUDPR END AS 'Precio',
                   0 As Id_Oferta,
                   '' As Oferta,
                   0 As Es_Padre_Oferta,
                   0 As Padre_Oferta,
                   0 As Hijo_Oferta,
                   0 As Cantidad_Oferta,
                   0 As Porcdesc_Oferta
                   FROM MAEDDO  WITH ( NOLOCK ) 
                   Where IDMAEEDO = {_Idmaeedo_OCC} AND ( ESLIDO<>'C' OR ESFALI='I' ) AND TICT = ''
                   ORDER BY IDMAEEDO,IDMAEDDO 
                   SELECT * FROM MAEIMLI
                   Where IDMAEEDO = {_Idmaeedo_OCC} 
                   SELECT * FROM MAEDTLI
                   Where IDMAEEDO = {_Idmaeedo_OCC} 
                   SELECT TOP 1 * FROM MAEEDOOB Where IDMAEEDO = {_Idmaeedo_OCC}"

                Dim _Mensaje As New LsValiciones.Mensajes

                Dim _Ds_Maeedo_Origen As DataSet = _Sql.Fx_Get_DataSet(Consulta_sql, False)

                Dim Fm_Post As New Frm_Formulario_Documento(_Tido, csGlobales.Enum_Tipo_Documento.Compra, False)
                Fm_Post.Pro_SubTido = "100"
                Fm_Post.Sb_Limpiar(Mod_Modalidad)
                Fm_Post.Pro_Nudo = _Nudo
                'Fm_Post.HoraAlPrincipioDelDia = True
                'Fm_Post.Sb_Crear_Documento_Desde_Otros_Documentos_SincroStock(Id_Enc, Nothing, _Ds_Maeedo_Origen, False, False, _Fecha_Emision, False, True)


                Fm_Post.Sb_Crear_Documento_Desde_Otros_Documentos(Nothing, _Ds_Maeedo_Origen, False, False, _Fecha_Emision, False, True, Id_Enc_InterStock:=Id_Enc)
                _Mensaje = Fm_Post.Fx_Grabar_Documento(False, csGlobales.Mod_Enum_Listados_Globales.Enum_Tipo_de_Grabacion.Nuevo_documento, False, _Mostrar_Mensaje:=False)
                Fm_Post.Dispose()

                If _Mensaje.EsCorrecto Then
                    Consulta_sql = $"SELECT * FROM MAEEDO WHERE IDMAEEDO = {_Mensaje.Id}"
                    Dim _Docummento As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql, False)

                    If Not String.IsNullOrWhiteSpace(_Sql.Pro_Error) Then
                        ' error
                    End If

                    _Mensaje.Tag = _Docummento
                    LogSeguro("Demonio SincroStock", $"FCC creada correctamente con Numero de documento: {_Docummento.Rows(0).Item("NUDO").ToString()}", Txt_Log)
                    Return _Mensaje

                Else
                    LogSeguro("Demonio SincroStock", $"Error al crear la FCC : {_Mensaje.Mensaje}", Txt_Log)
                    Return _Mensaje


                End If


            Catch ex As Exception

                LogSeguro("Demonio SincroStock", $"Error al crear la FCC : {ex.Message}", Txt_Log)


            Finally



            End Try

        Else
            Mensaje.EsCorrecto = False
            Mensaje.Detalle = "No se encontro coincidencia"
            LogSeguro("Demonio SincroStock", "No se encontro coincidencia", Txt_Log)
            Return Mensaje

        End If

        Mensaje.EsCorrecto = False
        Mensaje.Detalle = "Error al crear la FCC"


        Return Mensaje
    End Function
    Public Function obtenerFCV(Id_enc As Integer) As Integer
        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
        Dim query As String = $"Select top 1 Idmaeedo_FCV from {Global_BaseBk}Zw_InterStock_Det where Id_Enc = {Id_enc} And Idmaeedo_FCV > 0"
        Dim result As Object = _Sql.Fx_Get_DataRow(query).Item("Idmaeedo_FCV")
        If result IsNot Nothing AndAlso IsNumeric(result) Then
            Return Convert.ToInt32(result)
        Else
            Return 0
        End If
    End Function
    Public Function obtenerNCV(Id_enc As Integer) As String
        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
        Dim query As String = $"Select top 1 Nudo_NCV from {Global_BaseBk}Zw_InterStock_Det where Id_Enc = {Id_enc} And Nudo_NCV <> '' "
        Dim result As Object = _Sql.Fx_Get_DataRow(query).Item("Nudo_NCV")
        If result IsNot Nothing AndAlso IsNumeric(result) Then
            Return Convert.ToString(result)
        Else
            Return Nothing
        End If
    End Function
    Public Function GenerarDocumentosCredito(Txt_Log As Object) As Mensajes
        Dim _Mensaje As New Mensajes
        _Mensaje.EsCorrecto = False
        _Mensaje.Detalle = "No se encontraron documentos para procesar."

        Try
            Dim Documentos As DataTable = ObtenerDocsCredito()
            LogSeguro("Demonio SincroStock", $"Se encontraron {Documentos.Rows.Count} documentos para procesar.", Txt_Log)

            If Documentos IsNot Nothing Then
                For Each Doc As DataRow In Documentos.Rows

                    Dim encabezado As New DocumentoEncabezado(Doc)
                    LogSeguro("Demonio SincroStock", $"Procesando documento {encabezado.Nudo} de la empresa: {encabezado.Empresa}", Txt_Log)

                    Dim Empresa_Compra As Empresa
                    Dim Empresa_Venta As Empresa
                    If encabezado.Empresa = "01" Then
                        Empresa_Compra = Empresa01
                        Empresa_Venta = Empresa02
                    Else
                        Empresa_Compra = Empresa02
                        Empresa_Venta = Empresa01
                    End If

                    ' CORRECCIÓN 1: Convertir Id_Enc a String para que ObtenerFecha no arroje error
                    Dim fechaDoc As Date = ObtenerFecha(encabezado.Id_Enc.ToString())

                    Dim _Koen_OCC As String = Empresa_Compra.EntidadDeVenta.Rows(0).Item("Codigo").ToString().Trim()

                    Dim _Koen_OCC_PROVEEDOR As String = Empresa_Venta.EntidadDeVenta.Rows(0).Item("Codigo").ToString().Trim()
                    Dim _Koen_NVV_COMPRADOR As String = Empresa_Venta.EntidadDeCompra.Rows(0).Item("Codigo").ToString().Trim()
                    Dim Modalidad_OCC_GENERADOR As String = Empresa_Compra.ModalidadOCC.Rows(0).Item("Codigo").ToString().Trim()
                    Dim Modalidad_NVV_GENERADOR As String = Empresa_Venta.ModalidadNVV.Rows(0).Item("Codigo").ToString().Trim()

                    Dim _Row_Entidad_OCC_PROVEEDOR As DataRow = ObtenerEntidadMaestro(_Koen_OCC_PROVEEDOR, "")
                    Dim _Row_Entidad_NVV_COMPRADOR As DataRow = ObtenerEntidadMaestro(_Koen_NVV_COMPRADOR, "")




                    ' CORRECCIÓN 2: Declarar explícitamente como Integer para funciones posteriores
                    Dim _Idmaeedo_FCV As String = encabezado.Idmaeedo


                    Dim Id_Enc As Integer = encabezado.Id_Enc

                    Dim _Idmaeedo_FCC As Integer = TraeIDFCC(Id_Enc)

                    If _Idmaeedo_FCC = 0 Then
                        LogSeguro("Demonio SincroStock", "Error rescatando FCC.", Txt_Log)
                        _Mensaje.EsCorrecto = False
                        _Mensaje.Mensaje = "Error rescatando FCC."
                        Continue For
                    End If

                    ActualizarEstadoEncabezado(Id_Enc, "PROCESANDO", 1, 0, 0, "Procesando en Daemon", Txt_Log)
                    ActualizarEstadoEncabezadoFecha(Id_Enc, Txt_Log)

                    Dim _TblDetalle As DataTable = ObtenerDetallesInterStockCompraCredito(encabezado.Id_Enc)
                    If IsNothing(_TblDetalle) OrElse Not CBool(_TblDetalle.Rows.Count) Then
                        Dim msgError As String = "No hay precio o cantidad en los productos"
                        ActualizarEstadoEncabezado(Id_Enc, "PROCESANDO", 0, 0, 1, $"Error al crear documentos: {msgError}", Txt_Log)
                        _Mensaje.EsCorrecto = False
                        _Mensaje.Mensaje = msgError
                        LogSeguro("Demonio SincroStock", "No hay productos elegibles.", Txt_Log)
                        Continue For
                    End If
                    Dim _TblDetalleCompra As DataTable = ObtenerDetallesInterStockCompraCredito(encabezado.Id_Enc)
                    If IsNothing(_TblDetalleCompra) OrElse Not CBool(_TblDetalleCompra.Rows.Count) Then
                        Dim msgError As String = "No hay precio o cantidad en los productos"
                        ActualizarEstadoEncabezado(Id_Enc, "PROCESANDO", 0, 0, 1, $"Error al crear documentos: {msgError}", Txt_Log)
                        _Mensaje.EsCorrecto = False
                        _Mensaje.Mensaje = msgError
                        LogSeguro("Demonio SincroStock", "No hay productos elegibles.", Txt_Log)
                        Continue For
                    End If
                    Dim _TblDetalleVenta As DataTable = ObtenerDetallesInterStockVentaCredito(encabezado.Id_Enc)
                    If IsNothing(_TblDetalleVenta) OrElse Not CBool(_TblDetalleVenta.Rows.Count) Then
                        Dim msgError As String = "Error al traer equivalencia"
                        ActualizarEstadoEncabezado(Id_Enc, "PROCESANDO", 0, 0, 1, $"Error al crear documentos: {msgError}", Txt_Log)
                        _Mensaje.EsCorrecto = False
                        _Mensaje.Mensaje = msgError
                        LogSeguro("Demonio SincroStock", "Error al traer equivalencia.", Txt_Log)
                        Continue For
                    End If

                    Dim _Observaciones As String = $"Documento generado automáticamente desde FCV: {encabezado.Nudo}."

                    Dim IdMaeedo_FCV As Integer = obtenerFCV(Id_Enc)
                    If IdMaeedo_FCV = 0 Then
                        Dim msgError As String = "No se pudo obtener el IDMAEEDO de la FCV."
                        ActualizarEstadoEncabezado(Id_Enc, "PROCESANDO", 0, 0, 1, $"Error al crear documentos: {msgError}", Txt_Log)
                        _Mensaje.EsCorrecto = False
                        _Mensaje.Mensaje = msgError
                        LogSeguro("Demonio SincroStock", msgError, Txt_Log)
                        Continue For
                    End If


                    '--- PROCESO 
                    'CORRECCIÓN 3: Forzar tipos correctos. (Form, Integer, Empresa, Object, String)
                    Dim MensajeFCV As Mensajes = Fx_GenerarNCV(Nothing, Convert.ToInt32(IdMaeedo_FCV), Empresa_Venta, Txt_Log, encabezado.Id_Enc.ToString())

                    If MensajeFCV.EsCorrecto Then
                        LogSeguro("Demonio SincroStock", $"Proceso NCV finalizado correctamente con IDMAEEDO: {MensajeFCV.Id}.", Txt_Log)
                    Else
                        LogSeguro("Demonio SincroStock", $"Proceso NCV fallido {MensajeFCV.Mensaje}.", Txt_Log)
                        ActualizarEstadoEncabezado(Id_Enc, "PROCESANDO", 0, 0, 1, $"Error al crear NCV: {MensajeFCV.Mensaje}", Txt_Log)

                        _Mensaje = MensajeFCV
                        Continue For
                    End If
                    Dim NUDO_NCV As String = MensajeFCV.Tag
                    Dim IdMaeedo_NCV As Integer = MensajeFCV.Id
                    ' --- PROCESO NCC ---
                    ' CORRECCIÓN 4: Convertir Id_Enc a String para que coincida con la firma.

                    '------------------------------------------------------

                    'ESTO SOLO VA PARA PRUEBAS
                    'Dim NUDO_NCV As String = obtenerNCV(Id_Enc)
                    'If IsNothing(NUDO_NCV) Then
                    '    Dim msgError As String = "No se pudo obtener el NUDO de la FCV."
                    '    ActualizarEstadoEncabezado(Id_Enc, "PROCESANDO", 0, 0, 1, $"Error al crear documentos: {msgError}", Txt_Log)
                    '    _Mensaje.EsCorrecto = False
                    '    _Mensaje.Mensaje = msgError
                    '    LogSeguro("Demonio SincroStock", msgError, Txt_Log)
                    '    Continue For

                    'End If

                    '--------------------------------------------------------


                    Dim MensajeNCC As Mensajes = Fx_GenerarNCC(Nothing, _Idmaeedo_FCC, Empresa_Compra, Txt_Log, encabezado.Id_Enc.ToString(), NUDO_NCV)
                    If MensajeNCC.EsCorrecto Then
                        LogSeguro("Demonio SincroStock", $"Proceso NCC finalizado correctamente con IDMAEEDO: {MensajeNCC.Id}.", Txt_Log)
                    Else
                        LogSeguro("Demonio SincroStock", $"Proceso NCC fallido {MensajeNCC.Mensaje}.", Txt_Log)
                        ActualizarEstadoEncabezado(Id_Enc, "PROCESANDO", 0, 0, 1, $"Error al crear NCC: {MensajeNCC.Mensaje}", Txt_Log)
                        Continue For
                    End If

                    _Mensaje.EsCorrecto = True
                    _Mensaje.Detalle = "Proceso de documentos de credito finalizado"
                    _Mensaje.Mensaje = "OK"
                    SincronizarDocumentosCredito(encabezado.Id_Enc, Txt_Log)
                    CerrarEstadoEncabezado(encabezado.Id_Enc, Txt_Log)
                Next
            End If

        Catch ex As Exception
            _Mensaje.EsCorrecto = False
            _Mensaje.Detalle = "Error general en el proceso: " & ex.Message
            _Mensaje.Mensaje = "ERROR"
            LogSeguro("Demonio SincroStock", $"Excepción en GenerarDocumentos: {ex.Message}", Txt_Log)
        End Try

        Return _Mensaje
    End Function
    Public Function GenerarDocumentos(Txt_Log As Object) As Mensajes
        Dim _Mensaje As New Mensajes
        _Mensaje.EsCorrecto = False
        _Mensaje.Detalle = "No se encontraron documentos para procesar."

        Try
            Dim Documentos As DataTable = ObtenerDocs()
            LogSeguro("Demonio SincroStock", $"Se encontraron {Documentos.Rows.Count} documentos para procesar.", Txt_Log)

            If Documentos IsNot Nothing Then
                For Each Doc As DataRow In Documentos.Rows

                    Dim encabezado As New DocumentoEncabezado(Doc)
                    LogSeguro("Demonio SincroStock", $"Procesando documento {encabezado.Nudo} de la empresa: {encabezado.Empresa}", Txt_Log)

                    Dim Empresa_Compra As Empresa
                    Dim Empresa_Venta As Empresa
                    If encabezado.Empresa = "01" Then
                        Empresa_Compra = Empresa01
                        Empresa_Venta = Empresa02
                    Else
                        Empresa_Compra = Empresa02
                        Empresa_Venta = Empresa01
                    End If

                    ' CORRECCIÓN 1: Convertir Id_Enc a String para que ObtenerFecha no arroje error
                    Dim fechaDoc As Date = ObtenerFecha(encabezado.Id_Enc.ToString())

                    Dim _Koen_OCC As String = Empresa_Compra.EntidadDeVenta.Rows(0).Item("Codigo").ToString().Trim()

                    Dim _Koen_OCC_PROVEEDOR As String = Empresa_Venta.EntidadDeVenta.Rows(0).Item("Codigo").ToString().Trim()
                    Dim _Koen_NVV_COMPRADOR As String = Empresa_Venta.EntidadDeCompra.Rows(0).Item("Codigo").ToString().Trim()
                    Dim Modalidad_OCC_GENERADOR As String = Empresa_Compra.ModalidadOCC.Rows(0).Item("Codigo").ToString().Trim()
                    Dim Modalidad_NVV_GENERADOR As String = Empresa_Venta.ModalidadNVV.Rows(0).Item("Codigo").ToString().Trim()

                    Dim _Row_Entidad_OCC_PROVEEDOR As DataRow = ObtenerEntidadMaestro(_Koen_OCC_PROVEEDOR, "")
                    Dim _Row_Entidad_NVV_COMPRADOR As DataRow = ObtenerEntidadMaestro(_Koen_NVV_COMPRADOR, "")

                    Dim MensajeActua As Mensajes
                    MensajeActua = Actualizar_Entidades(Empresa_Venta, encabezado.Id_Enc.ToString(), Txt_Log)
                    If MensajeActua.EsCorrecto = False Then
                        _Mensaje.EsCorrecto = False
                        _Mensaje.Mensaje = MensajeActua.Mensaje
                        Continue For
                    End If

                    ' CORRECCIÓN 2: Declarar explícitamente como Integer para funciones posteriores
                    Dim _Idmaeedo_FCV As String = encabezado.Idmaeedo
                    Dim _Id_Enc As Integer = encabezado.Id_Enc

                    ActualizarEstadoEncabezado(_Id_Enc, "PROCESANDO", 1, 0, 0, "Procesando en Daemon", Txt_Log)
                    ActualizarEstadoEncabezadoFecha(_Id_Enc, Txt_Log)

                    Dim _TblDetalle As DataTable = ObtenerDetallesInterStockCompra(encabezado.Id_Enc)
                    If IsNothing(_TblDetalle) OrElse Not CBool(_TblDetalle.Rows.Count) Then
                        Dim msgError As String = "No hay precio o cantidad en los productos"
                        ActualizarEstadoEncabezado(_Id_Enc, "PROCESANDO", 0, 0, 1, $"Error al crear documentos: {msgError}", Txt_Log)
                        _Mensaje.EsCorrecto = False
                        _Mensaje.Mensaje = msgError
                        LogSeguro("Demonio SincroStock", "No hay productos elegibles.", Txt_Log)
                        Continue For
                    End If
                    Dim _TblDetalleCompra As DataTable = ObtenerDetallesInterStockCompra(encabezado.Id_Enc)
                    If IsNothing(_TblDetalleCompra) OrElse Not CBool(_TblDetalleCompra.Rows.Count) Then
                        Dim msgError As String = "No hay precio o cantidad en los productos"
                        ActualizarEstadoEncabezado(_Id_Enc, "PROCESANDO", 0, 0, 1, $"Error al crear documentos: {msgError}", Txt_Log)
                        _Mensaje.EsCorrecto = False
                        _Mensaje.Mensaje = msgError
                        LogSeguro("Demonio SincroStock", "No hay productos elegibles.", Txt_Log)
                        Continue For
                    End If
                    Dim _TblDetalleVenta As DataTable = ObtenerDetallesInterStockVenta(encabezado.Id_Enc)
                    If IsNothing(_TblDetalleVenta) OrElse Not CBool(_TblDetalleVenta.Rows.Count) Then
                        Dim msgError As String = "Error al traer equivalencia"
                        ActualizarEstadoEncabezado(_Id_Enc, "PROCESANDO", 0, 0, 1, $"Error al crear documentos: {msgError}", Txt_Log)
                        _Mensaje.EsCorrecto = False
                        _Mensaje.Mensaje = msgError
                        LogSeguro("Demonio SincroStock", "Error al traer equivalencia.", Txt_Log)
                        Continue For
                    End If

                    Dim _Observaciones As String = $"Documento generado automáticamente desde FCV: {encabezado.Nudo}."

                    ' --- PROCESO OCC ---
                    Dim MensajeOCC As Mensajes = GenerarDocumentoInterno("OCC",
                                                                         _Row_Entidad_OCC_PROVEEDOR,
                                                                         Empresa_Compra.Numero,
                                                                         Empresa_Compra.ModalidadOCC.Rows(0).Item("Codigo").ToString().Trim(),
                                                                         _TblDetalleCompra,
                                                                         _Idmaeedo_FCV,
                                                                         Txt_Log,
                                                                         _Observaciones, "", encabezado.Nudo, fechaDoc, encabezado.Id_Enc)

                    If Not MensajeOCC.EsCorrecto Then
                        ActualizarEstadoEncabezado(_Idmaeedo_FCV, "PROCESANDO", 0, 0, 1, $"Error al crear OCC: {MensajeOCC.Mensaje}", Txt_Log)
                        Continue For
                    End If

                    Dim IdMaeedo_OCC As String = MensajeOCC.Id
                    ActualizarVinculoSincroStock("OCC", IdMaeedo_OCC, _Idmaeedo_FCV, Txt_Log)

                    Dim _Orden_compra As String = CType(MensajeOCC.Tag, DataSet).Tables(0).Rows(0).Item("NUDO").ToString()
                    _Observaciones = String.Empty

                    ' --- PROCESO NVV ---
                    Dim MensajeNVV As Mensajes = GenerarDocumentoInterno("NVV",
                                                                         _Row_Entidad_NVV_COMPRADOR,
                                                                         Empresa_Venta.Numero,
                                                                         Empresa_Venta.ModalidadNVV.Rows(0).Item("Codigo").ToString().Trim(),
                                                                         _TblDetalleVenta,
                                                                         _Idmaeedo_FCV,
                                                                         Txt_Log,
                                                                         _Observaciones,
                                                                         _Orden_compra,
                                                                         encabezado.Nudo, fechaDoc, encabezado.Id_Enc)

                    If Not MensajeNVV.EsCorrecto Then
                        ActualizarEstadoEncabezado(_Id_Enc, "PROCESANDO", 0, 0, 1, $"Error al crear NVV: {MensajeNVV.Mensaje}", Txt_Log)
                        _Mensaje = MensajeNVV
                        Continue For
                    End If

                    Dim IdMaeedo_NVV As String = MensajeNVV.Id

                    ActualizarVinculoSincroStock("NVV", IdMaeedo_NVV, _Idmaeedo_FCV, Txt_Log)
                    LogSeguro("Demonio SincroStock", "Proceso NVV finalizado.", Txt_Log)

                    ' --- PROCESO FCV ---
                    ' CORRECCIÓN 3: Forzar tipos correctos. (Form, Integer, Empresa, Object, String)
                    Dim MensajeFCV As Mensajes = Fx_GenerarFCV(Nothing, Convert.ToInt32(IdMaeedo_NVV), Empresa_Venta, Txt_Log, encabezado.Id_Enc.ToString())

                    If MensajeFCV.EsCorrecto Then
                        LogSeguro("Demonio SincroStock", $"Proceso FCV finalizado correctamente con IDMAEEDO: {MensajeFCV.Id}.", Txt_Log)
                    Else
                        LogSeguro("Demonio SincroStock", $"Proceso FCV fallido {MensajeFCV.Mensaje}.", Txt_Log)
                        ActualizarEstadoEncabezado(_Id_Enc, "PROCESANDO", 0, 0, 1, $"Error al crear FCV: {MensajeFCV.Mensaje}", Txt_Log)
                        _Mensaje = MensajeFCV
                        Continue For
                    End If
                    Dim nudo As String = MensajeFCV.Tag

                    ' --- PROCESO FCC ---
                    ' CORRECCIÓN 4: Convertir Id_Enc a String para que coincida con la firma.
                    Dim MensajeFCC As Mensajes = GeneraFCC(Txt_Log, IdMaeedo_OCC, encabezado.Id_Enc, Empresa_Compra, nudo)
                    If MensajeFCC.EsCorrecto Then
                        LogSeguro("Demonio SincroStock", $"Proceso FCC finalizado correctamente con IDMAEEDO: {MensajeFCC.Id}.", Txt_Log)
                    Else
                        LogSeguro("Demonio SincroStock", $"Proceso FCC fallido {MensajeFCC.Mensaje}.", Txt_Log)
                        ActualizarEstadoEncabezado(_Id_Enc, "PROCESANDO", 0, 0, 1, $"Error al crear FCC: {MensajeFCC.Mensaje}", Txt_Log)
                        Continue For
                    End If
                    ActualizarVinculoSincroStockFCC(MensajeFCC.Id, _Idmaeedo_FCV, Txt_Log)

                    _Mensaje.EsCorrecto = True
                    _Mensaje.Detalle = "Proceso de documentos procesados finalizado"
                    _Mensaje.Mensaje = "OK"
                    SincronizarDocumentos(encabezado.Id_Enc, Txt_Log)
                    CerrarEstadoEncabezado(encabezado.Id_Enc, Txt_Log)
                Next
            End If

        Catch ex As Exception
            _Mensaje.EsCorrecto = False
            _Mensaje.Detalle = "Error general en el proceso: " & ex.Message
            _Mensaje.Mensaje = "ERROR"
            LogSeguro("Demonio SincroStock", $"Excepción en GenerarDocumentos: {ex.Message}", Txt_Log)
        End Try

        Return _Mensaje
    End Function
    Public Function ObtenerDocsCredito() As DataTable
        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
        Try
            Dim Consulta_sql As String = $"
            Select * from {Global_BaseBk}Zw_InterStock_Enc Where Procesar = 1 And (Tido = 'NCV' OR Tido = 'GRD');"

            Return _Sql.Fx_Get_DataTable(Consulta_sql, False)
        Catch ex As Exception
            Throw New Exception("Error en ObtenerDocs: " & ex.Message)
        Finally
            If _Sql IsNot Nothing Then _Sql.Sb_Cerrar_Conexion2()
        End Try
    End Function
    Public Function ObtenerDocs() As DataTable
        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
        Try
            Dim Consulta_sql As String = $"
            Select * from {Global_BaseBk}Zw_InterStock_Enc Where Procesar = 1 And Tido = 'FCV';"

            Return _Sql.Fx_Get_DataTable(Consulta_sql, False)
        Catch ex As Exception
            Throw New Exception("Error en ObtenerDocs: " & ex.Message)
        Finally
            If _Sql IsNot Nothing Then _Sql.Sb_Cerrar_Conexion2()
        End Try
    End Function

    Public Function Actualizar_Entidades(Empresa_Venta As Empresa, Id_Enc As String, Txt_Log As Object) As Mensajes

        Dim _Koen_OCC As String = Empresa_Venta.EntidadDeVenta.Rows(0).Item("Codigo").ToString().Trim()
        Dim _Koen_NVV As String = Empresa_Venta.EntidadDeCompra.Rows(0).Item("Codigo").ToString().Trim()

        Dim _Row_Entidad_OCC As DataRow = ObtenerEntidadMaestro(_Koen_OCC, "")
        Dim _Row_Entidad_NVV As DataRow = ObtenerEntidadMaestro(_Koen_NVV, "")

        Dim SUEND_OCC As String = _Row_Entidad_OCC.Item("SUENDO").ToString().Trim()
        Dim SUEND_NVV As String = _Row_Entidad_NVV.Item("SUENDO").ToString().Trim()
        Dim Endo_NVV As String = _Row_Entidad_NVV.Item("ENDO").ToString().Trim()
        Dim Endo_OCC As String = _Row_Entidad_OCC.Item("ENDO").ToString().Trim()
        Dim SQL_QUERY As String = $"Update {Global_BaseBk}Zw_InterStock_Det SET Suendo_OCC = '{SUEND_OCC}', Suendo_NVV = '{SUEND_NVV}', Endo_NVV = '{Endo_NVV}', Endo_OCC = '{Endo_OCC}' where Id_Enc = {Id_Enc}"

        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)

        Dim EjecucionCorrecta As Boolean = _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(SQL_QUERY, False)
        Dim _Mensaje As New Mensajes
        If EjecucionCorrecta Then
            _Mensaje.EsCorrecto = True
            _Mensaje.Detalle = $"Se actualizaron las entidades."
            _Mensaje.Mensaje = "OK."
            LogSeguro("Demonio SincroStock", "Fin del procesamiento de documentos con éxito.", Txt_Log)
        Else
            _Mensaje.EsCorrecto = False
            _Mensaje.Detalle = "La transacción de Inserción falló en SQL Server."
            Throw New Exception("La transacción de Inserción falló en SQL Server.")

        End If

        Return _Mensaje
    End Function

    Public Function ContinuarProcesosInterrumpidos(Txt_Log As Object) As Mensajes
        Dim _Mensaje As New Mensajes
        _Mensaje.EsCorrecto = False
        _Mensaje.Detalle = "No se encontraron documentos interrumpidos para procesar."

        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)

        Try
            ' 1. Buscamos encabezados que se hayan quedado en estado 'PROCESANDO' y tengan documentos faltantes en el detalle
            Dim Consulta_sql As String = $"
        SELECT DISTINCT Enc.*
        FROM {Global_BaseBk}Zw_InterStock_Enc Enc
        INNER JOIN {Global_BaseBk}Zw_InterStock_Det Det ON Enc.Id_Enc = Det.Id_Enc
        WHERE Enc.Procesando = 1
          AND (ISNULL(Det.Idmaeedo_OCC, 0) = 0 
            OR ISNULL(Det.Idmaeedo_NVV, 0) = 0 
            OR ISNULL(Det.Idmaeedo_FCV, 0) = 0 
            OR ISNULL(Det.Idmaeedo_FCC, 0) = 0) And Enc.Tido = 'FCV'
        "

            Dim Documentos As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql, False)

            If Documentos Is Nothing OrElse Documentos.Rows.Count = 0 Then
                _Mensaje.EsCorrecto = True
                _Mensaje.Detalle = "No hay procesos interrumpidos."
                _Mensaje.Mensaje = "OK"
                LogSeguro("Demonio SincroStock", "No se encontraron procesos interrumpidos para reanudar.", Txt_Log)
                Return _Mensaje
            End If

            LogSeguro("Demonio SincroStock", $"Se encontraron {Documentos.Rows.Count} documentos interrumpidos para reanudar.", Txt_Log)

            For Each Doc As DataRow In Documentos.Rows
                Dim encabezado As New DocumentoEncabezado(Doc)
                LogSeguro("Demonio SincroStock", $"Reanudando documento {encabezado.Nudo} de la empresa: {encabezado.Empresa}", Txt_Log)

                Dim Empresa_Compra As Empresa
                Dim Empresa_Venta As Empresa
                If encabezado.Empresa = "01" Then
                    Empresa_Compra = Empresa01
                    Empresa_Venta = Empresa02
                Else
                    Empresa_Compra = Empresa02
                    Empresa_Venta = Empresa01
                End If

                Dim fechaDoc As Date = ObtenerFecha(encabezado.Id_Enc.ToString())

                Dim _Koen_OCC_PROVEEDOR As String = Empresa_Venta.EntidadDeVenta.Rows(0).Item("Codigo").ToString().Trim()
                Dim _Koen_NVV_COMPRADOR As String = Empresa_Venta.EntidadDeCompra.Rows(0).Item("Codigo").ToString().Trim()

                Dim _Row_Entidad_OCC_PROVEEDOR As DataRow = ObtenerEntidadMaestro(_Koen_OCC_PROVEEDOR, "")
                Dim _Row_Entidad_NVV_COMPRADOR As DataRow = ObtenerEntidadMaestro(_Koen_NVV_COMPRADOR, "")

                Dim MensajeActua = Actualizar_Entidades(Empresa_Venta, encabezado.Id_Enc.ToString(), Txt_Log)
                If MensajeActua.EsCorrecto = False Then
                    LogSeguro("Demonio SincroStock", $"Error actualizando entidades en reanudación: {MensajeActua.Mensaje}", Txt_Log)
                    Continue For
                End If

                Dim _Idmaeedo_FCV As String = encabezado.Idmaeedo
                Dim id_Enc As Integer = encabezado.Id_Enc
                ActualizarEstadoEncabezadoFecha(id_Enc, Txt_Log)

                Dim _TblDetalle As DataTable = ObtenerDetallesInterStockCompra(encabezado.Id_Enc)
                If IsNothing(_TblDetalle) OrElse Not CBool(_TblDetalle.Rows.Count) Then
                    Dim msgError As String = "No hay precio o cantidad en los productos"
                    ActualizarEstadoEncabezado(id_Enc, "PROCESANDO", 0, 0, 1, $"Error al crear documentos: {msgError}", Txt_Log)
                    _Mensaje.EsCorrecto = False
                    _Mensaje.Mensaje = msgError
                    LogSeguro("Demonio SincroStock", "No hay productos elegibles.", Txt_Log)
                    Continue For

                End If
                Dim _TblDetalleCompra As DataTable = ObtenerDetallesInterStockCompra(encabezado.Id_Enc)
                If IsNothing(_TblDetalleCompra) OrElse Not CBool(_TblDetalleCompra.Rows.Count) Then
                    Dim msgError As String = "No hay precio o cantidad en los productos"
                    ActualizarEstadoEncabezado(id_Enc, "PROCESANDO", 0, 0, 1, $"Error al crear documentos: {msgError}", Txt_Log)
                    _Mensaje.EsCorrecto = False
                    _Mensaje.Mensaje = msgError
                    LogSeguro("Demonio SincroStock", "No hay productos elegibles.", Txt_Log)
                    Continue For

                End If
                Dim _TblDetalleVenta As DataTable = ObtenerDetallesInterStockVenta(encabezado.Id_Enc)
                If IsNothing(_TblDetalleVenta) OrElse Not CBool(_TblDetalleVenta.Rows.Count) Then
                    Dim msgError As String = "Error al traer equivalencia"
                    ActualizarEstadoEncabezado(id_Enc, "PROCESANDO", 0, 0, 1, $"Error al crear documentos: {msgError}", Txt_Log)
                    _Mensaje.EsCorrecto = False
                    _Mensaje.Mensaje = msgError
                    LogSeguro("Demonio SincroStock", "Error al traer equivalencia.", Txt_Log)
                    Continue For

                End If



                If Not CBool(_TblDetalle.Rows.Count) Then
                    LogSeguro("Demonio SincroStock", "No hay productos elegibles para reanudar.", Txt_Log)
                    Continue For
                End If

                ' 2. Revisamos qué documentos ya se generaron para este proceso
                Dim qryStatus = $"
            SELECT TOP 1 
                ISNULL(Idmaeedo_OCC, 0) AS Id_OCC, 
                ISNULL(Idmaeedo_NVV, 0) AS Id_NVV, 
                ISNULL(Idmaeedo_FCV, 0) AS Id_FCV, 
                ISNULL(Idmaeedo_FCC, 0) AS Id_FCC, 
                ISNULL(Nudo_OCC, '') AS Nudo_OCC, 
                ISNULL(Nudo_FCV, '') AS Nudo_FCV 
            FROM {Global_BaseBk}Zw_InterStock_Det 
            WHERE Id_Enc = {encabezado.Id_Enc}"

                Dim dtStatus As DataTable = _Sql.Fx_Get_DataTable(qryStatus, False)
                If dtStatus Is Nothing OrElse dtStatus.Rows.Count = 0 Then Continue For

                Dim drStatus As DataRow = dtStatus.Rows(0)
                Dim IdMaeedo_OCC As String = drStatus("Id_OCC").ToString()
                Dim IdMaeedo_NVV As String = drStatus("Id_NVV").ToString()
                Dim IdMaeedo_FCV_Gen As String = drStatus("Id_FCV").ToString()
                Dim IdMaeedo_FCC As String = drStatus("Id_FCC").ToString()

                Dim _Orden_compra As String = drStatus("Nudo_OCC").ToString()
                Dim nudo_fcv As String = drStatus("Nudo_FCV").ToString()
                Dim _Observaciones As String = $"Documento generado automáticamente desde FCV: {encabezado.Nudo}."

                Dim nudo_recuperado As String = ""
                Dim idmaeedo_recuperado As String = ""

                ' --- 3. REANUDAR OCC ---
                If IdMaeedo_OCC = "0" Then
                    If VerificaRelacion(encabezado.Id_Enc, "OCC", nudo_recuperado, idmaeedo_recuperado) Then
                        LogSeguro("Demonio SincroStock", $"OCC ya existía ({nudo_recuperado}). Ejecutando vínculo.", Txt_Log)
                        Actualizar_vinculo_incompleto(encabezado.Id_Enc, encabezado.Nudo)
                        IdMaeedo_OCC = idmaeedo_recuperado
                        _Orden_compra = nudo_recuperado
                    Else
                        LogSeguro("Demonio SincroStock", "Retomando: Generación de OCC faltante.", Txt_Log)
                        Dim MensajeOCC = GenerarDocumentoInterno("OCC", _Row_Entidad_OCC_PROVEEDOR, Empresa_Compra.Numero, Empresa_Compra.ModalidadOCC.Rows(0).Item("Codigo").ToString().Trim(), _TblDetalleCompra, _Idmaeedo_FCV, Txt_Log, _Observaciones, "", encabezado.Nudo, fechaDoc, encabezado.Id_Enc)

                        If Not MensajeOCC.EsCorrecto Then
                            ActualizarEstadoEncabezado(id_Enc, "PROCESANDO", 0, 0, 1, $"Error reanudando OCC: {MensajeOCC.Mensaje}", Txt_Log)
                            Continue For
                        End If
                        IdMaeedo_OCC = MensajeOCC.Id.ToString()
                        ActualizarVinculoSincroStock("OCC", IdMaeedo_OCC, CInt(_Idmaeedo_FCV), Txt_Log)
                        _Orden_compra = CType(MensajeOCC.Tag, DataSet).Tables(0).Rows(0).Item("NUDO").ToString()
                    End If
                End If

                _Observaciones = String.Empty

                ' --- 4. REANUDAR NVV ---
                If IdMaeedo_NVV = "0" Then
                    If VerificaRelacion(encabezado.Id_Enc, "NVV", nudo_recuperado, idmaeedo_recuperado) Then
                        LogSeguro("Demonio SincroStock", $"NVV ya existía ({nudo_recuperado}). Ejecutando vínculo.", Txt_Log)
                        Actualizar_vinculo_incompleto(encabezado.Id_Enc, encabezado.Nudo)
                        IdMaeedo_NVV = idmaeedo_recuperado
                    Else
                        LogSeguro("Demonio SincroStock", "Retomando: Generación de NVV faltante.", Txt_Log)
                        Dim MensajeNVV = GenerarDocumentoInterno("NVV", _Row_Entidad_NVV_COMPRADOR, Empresa_Venta.Numero, Empresa_Venta.ModalidadNVV.Rows(0).Item("Codigo").ToString().Trim(), _TblDetalleVenta, _Idmaeedo_FCV, Txt_Log, _Observaciones, _Orden_compra, encabezado.Nudo, fechaDoc, encabezado.Id_Enc)

                        If Not MensajeNVV.EsCorrecto Then
                            ActualizarEstadoEncabezado(id_Enc, "PROCESANDO", 0, 0, 1, $"Error reanudando NVV: {MensajeNVV.Mensaje}", Txt_Log)
                            Continue For
                        End If
                        IdMaeedo_NVV = MensajeNVV.Id.ToString()
                        ActualizarVinculoSincroStock("NVV", IdMaeedo_NVV, CInt(_Idmaeedo_FCV), Txt_Log)
                    End If
                End If

                ' --- 5. REANUDAR FCV ---
                If IdMaeedo_FCV_Gen = "0" Then
                    If VerificaRelacion(encabezado.Id_Enc, "FCV", nudo_recuperado, idmaeedo_recuperado) Then
                        LogSeguro("Demonio SincroStock", $"FCV destino ya existía ({nudo_recuperado}). Ejecutando vínculo.", Txt_Log)
                        Actualizar_vinculo_incompleto(encabezado.Id_Enc, encabezado.Nudo)
                        IdMaeedo_FCV_Gen = idmaeedo_recuperado
                        nudo_fcv = nudo_recuperado
                    Else
                        LogSeguro("Demonio SincroStock", "Retomando: Generación de FCV destino faltante.", Txt_Log)
                        Dim MensajeFCV = Fx_GenerarFCV(Nothing, Convert.ToInt32(IdMaeedo_NVV), Empresa_Venta, Txt_Log, encabezado.Id_Enc.ToString())

                        If Not MensajeFCV.EsCorrecto Then
                            ActualizarEstadoEncabezado(id_Enc, "PROCESANDO", 0, 0, 1, $"Error reanudando FCV: {MensajeFCV.Mensaje}", Txt_Log)
                            Continue For
                        End If
                        IdMaeedo_FCV_Gen = MensajeFCV.Id.ToString()
                        nudo_fcv = MensajeFCV.Tag.ToString()
                    End If
                End If

                ' --- 6. REANUDAR FCC ---
                If IdMaeedo_FCC = "0" Then
                    If VerificaRelacion(encabezado.Id_Enc, "FCC", nudo_recuperado, idmaeedo_recuperado) Then
                        LogSeguro("Demonio SincroStock", $"FCC ya existía ({nudo_recuperado}). Ejecutando vínculo.", Txt_Log)
                        Actualizar_vinculo_incompleto(encabezado.Id_Enc, encabezado.Nudo)
                        IdMaeedo_FCC = idmaeedo_recuperado
                        CerrarEstadoEncabezado(encabezado.Id_Enc, Txt_Log)
                        SincronizarDocumentos(encabezado.Id_Enc.ToString(), Txt_Log)

                    Else
                        LogSeguro("Demonio SincroStock", "Retomando: Generación de FCC faltante.", Txt_Log)
                        Dim MensajeFCC = GeneraFCC(Txt_Log, IdMaeedo_OCC, encabezado.Id_Enc, Empresa_Compra, nudo_fcv)

                        If Not MensajeFCC.EsCorrecto Then
                            ActualizarEstadoEncabezado(id_Enc, "PROCESANDO", 0, 0, 1, $"Error reanudando FCC: {MensajeFCC.Mensaje}", Txt_Log)
                            Continue For
                        End If
                        IdMaeedo_FCC = MensajeFCC.Id.ToString()
                        ActualizarVinculoSincroStockFCC(IdMaeedo_FCC, CInt(_Idmaeedo_FCV), Txt_Log)
                        ActualizarEstadoEncabezado(id_Enc, "PROCESADA", 1, 0, 0, "Reanudación exitosa", Txt_Log)
                        CerrarEstadoEncabezado(encabezado.Id_Enc, Txt_Log)
                        SincronizarDocumentos(encabezado.Id_Enc.ToString(), Txt_Log)
                    End If
                End If

                ' 7. Finalizar y sincronizar

            Next

            _Mensaje.EsCorrecto = True
            _Mensaje.Detalle = "Proceso de reanudación finalizado con éxito."
            _Mensaje.Mensaje = "OK"

        Catch ex As Exception
            _Mensaje.EsCorrecto = False
            _Mensaje.Detalle = "Error al intentar reanudar documentos: " & ex.Message
            _Mensaje.Mensaje = "ERROR"
            LogSeguro("Demonio SincroStock", $"Excepción en ContinuarProcesosInterrumpidos: {ex.Message}", Txt_Log)
        Finally
            If _Sql IsNot Nothing Then _Sql.Sb_Cerrar_Conexion2()
        End Try

        Return _Mensaje
    End Function


    'Public Function GenerarDocumentosFallidos(Txt_Log As Object) As Mensajes
    '    Dim _Mensaje As New Mensajes
    '    _Mensaje.EsCorrecto = False
    '    _Mensaje.Detalle = "No se encontraron documentos para procesar."

    '    Dim Documentos As DataTable = ObtenerDocs()
    '    LogSeguro("Demonio SincroStock", $"Se encontraron {Documentos.Rows.Count} documentos para procesar.", Txt_Log)

    '    ' INSTANCIAMOS EL GENERADOR ALEATORIO
    '    Dim rnd As New Random()

    '    If Documentos IsNot Nothing Then
    '        For Each Doc As DataRow In Documentos.Rows

    '            ' Generamos un número del 1 al 4 para decidir dónde morirá el proceso
    '            ' 1 = Muere después de OCC
    '            ' 2 = Muere después de NVV
    '            ' 3 = Muere después de FCV
    '            ' 4 = Completa el ciclo exitosamente
    '            Dim puntoMuerto As Integer = rnd.Next(1, 5)
    '            LogSeguro("Demonio SincroStock", $"[TEST] El proceso morirá en el paso: {puntoMuerto}", Txt_Log)

    '            Dim encabezado As New DocumentoEncabezado(Doc)
    '            LogSeguro("Demonio SincroStock", $"Procesando documento {encabezado.Nudo} de la empresa: {encabezado.Empresa}", Txt_Log)

    '            Dim Empresa_Compra As Empresa
    '            Dim Empresa_Venta As Empresa
    '            If encabezado.Empresa = "01" Then
    '                Empresa_Compra = Empresa01
    '                Empresa_Venta = Empresa02
    '            Else
    '                Empresa_Compra = Empresa02
    '                Empresa_Venta = Empresa01
    '            End If

    '            Dim fechaDoc As Date = ObtenerFecha(encabezado.Id_Enc.ToString())

    '            Dim _Koen_OCC As String = Empresa_Compra.EntidadDeVenta.Rows(0).Item("Codigo").ToString().Trim()

    '            Dim _Koen_OCC_PROVEEDOR As String = Empresa_Venta.EntidadDeVenta.Rows(0).Item("Codigo").ToString().Trim()
    '            Dim _Koen_NVV_COMPRADOR As String = Empresa_Venta.EntidadDeCompra.Rows(0).Item("Codigo").ToString().Trim()
    '            Dim Modalidad_OCC_GENERADOR As String = Empresa_Compra.ModalidadOCC.Rows(0).Item("Codigo").ToString().Trim()
    '            Dim Modalidad_NVV_GENERADOR As String = Empresa_Venta.ModalidadNVV.Rows(0).Item("Codigo").ToString().Trim()

    '            Dim _Row_Entidad_OCC_PROVEEDOR As DataRow = ObtenerEntidadMaestro(_Koen_OCC_PROVEEDOR, "")
    '            Dim _Row_Entidad_NVV_COMPRADOR As DataRow = ObtenerEntidadMaestro(_Koen_NVV_COMPRADOR, "")

    '            Dim MensajeActua As Mensajes
    '            MensajeActua = Actualizar_Entidades(Empresa_Venta, encabezado.Id_Enc.ToString(), Txt_Log)
    '            If MensajeActua.EsCorrecto = False Then
    '                _Mensaje.EsCorrecto = False
    '                _Mensaje.Mensaje = MensajeActua.Mensaje
    '                Return _Mensaje
    '            End If

    '            Dim _Idmaeedo_FCV As String = encabezado.Idmaeedo
    '            ActualizarEstadoEncabezado(_Idmaeedo_FCV, "PROCESANDO", 1, 0, 0, "Procesando en Daemon", Txt_Log)


    '            Dim _TblDetalle As DataTable = ObtenerDetallesInterStockCompra(encabezado.Id_Enc)
    '            If IsNothing(_TblDetalle) OrElse Not CBool(_TblDetalle.Rows.Count) Then
    '                Dim msgError As String = "No hay precio o cantidad en los productos"
    '                ActualizarEstadoEncabezado(_Idmaeedo_FCV, "PROCESANDO", 0, 0, 1, $"Error al crear documentos: {msgError}", Txt_Log)
    '                _Mensaje.EsCorrecto = False
    '                _Mensaje.Mensaje = msgError
    '                LogSeguro("Demonio SincroStock", "No hay productos elegibles.", Txt_Log)
    '                Return _Mensaje
    '            End If
    '            Dim _TblDetalleCompra As DataTable = ObtenerDetallesInterStockCompra(encabezado.Id_Enc)
    '            If IsNothing(_TblDetalleCompra) OrElse Not CBool(_TblDetalleCompra.Rows.Count) Then
    '                Dim msgError As String = "No hay precio o cantidad en los productos"
    '                ActualizarEstadoEncabezado(_Idmaeedo_FCV, "PROCESANDO", 0, 0, 1, $"Error al crear documentos: {msgError}", Txt_Log)
    '                _Mensaje.EsCorrecto = False
    '                _Mensaje.Mensaje = msgError
    '                LogSeguro("Demonio SincroStock", "No hay productos elegibles.", Txt_Log)
    '                Return _Mensaje
    '            End If
    '            Dim _TblDetalleVenta As DataTable = ObtenerDetallesInterStockVenta(encabezado.Id_Enc)
    '            If IsNothing(_TblDetalleVenta) OrElse Not CBool(_TblDetalleVenta.Rows.Count) Then
    '                Dim msgError As String = "Error al traer equivalencia"
    '                ActualizarEstadoEncabezado(_Idmaeedo_FCV, "PROCESANDO", 0, 0, 1, $"Error al crear documentos: {msgError}", Txt_Log)
    '                _Mensaje.EsCorrecto = False
    '                _Mensaje.Mensaje = msgError
    '                LogSeguro("Demonio SincroStock", "Error al traer equivalencia.", Txt_Log)
    '                Return _Mensaje
    '            End If




    '            Dim _Observaciones As String = $"Documento generado automáticamente desde FCV: {encabezado.Nudo}."

    '            ' --- PROCESO OCC ---
    '            Dim MensajeOCC As Mensajes = GenerarDocumentoInterno("OCC", _Row_Entidad_OCC_PROVEEDOR, Empresa_Compra.Numero, Empresa_Compra.ModalidadOCC.Rows(0).Item("Codigo").ToString().Trim(), _TblDetalleCompra, _Idmaeedo_FCV, Txt_Log, _Observaciones, "", encabezado.Nudo, fechaDoc, encabezado.Id_Enc)

    '            If Not MensajeOCC.EsCorrecto Then
    '                ActualizarEstadoEncabezado(_Idmaeedo_FCV, "PROCESANDO", 0, 0, 1, $"Error al crear OCC: {MensajeOCC.Mensaje}", Txt_Log)
    '                Return MensajeOCC
    '            End If

    '            Dim IdMaeedo_OCC As String = MensajeOCC.Id
    '            Dim _Orden_compra As String = CType(MensajeOCC.Tag, DataSet).Tables(0).Rows(0).Item("NUDO").ToString()
    '            _Observaciones = String.Empty

    '            ' [INTERRUPCIÓN ALEATORIA 1]
    '            If puntoMuerto = 1 Then
    '                _Mensaje.EsCorrecto = False
    '                _Mensaje.Mensaje = "Muerte simulada aleatoria después de crear la OCC."
    '                LogSeguro("Demonio SincroStock", _Mensaje.Mensaje, Txt_Log)
    '                Return _Mensaje
    '            End If
    '            ActualizarVinculoSincroStock("OCC", IdMaeedo_OCC, _Idmaeedo_FCV, Txt_Log)

    '            ' --- PROCESO NVV ---
    '            Dim MensajeNVV As Mensajes = GenerarDocumentoInterno("NVV", _Row_Entidad_NVV_COMPRADOR, Empresa_Venta.Numero, Empresa_Venta.ModalidadNVV.Rows(0).Item("Codigo").ToString().Trim(), _TblDetalleVenta, _Idmaeedo_FCV, Txt_Log, _Observaciones, _Orden_compra, encabezado.Nudo, fechaDoc, encabezado.Id_Enc)

    '            If Not MensajeNVV.EsCorrecto Then
    '                ActualizarEstadoEncabezado(_Idmaeedo_FCV, "PROCESANDO", 0, 0, 1, $"Error al crear NVV: {MensajeNVV.Mensaje}", Txt_Log)
    '                Return MensajeNVV
    '            End If

    '            Dim IdMaeedo_NVV As String = MensajeNVV.Id
    '            LogSeguro("Demonio SincroStock", "Proceso NVV finalizado.", Txt_Log)

    '            ' [INTERRUPCIÓN ALEATORIA 2]
    '            If puntoMuerto = 2 Then
    '                _Mensaje.EsCorrecto = False
    '                _Mensaje.Mensaje = "Muerte simulada aleatoria después de crear la NVV."
    '                LogSeguro("Demonio SincroStock", _Mensaje.Mensaje, Txt_Log)
    '                Return _Mensaje
    '            End If
    '            ActualizarVinculoSincroStock("NVV", IdMaeedo_NVV, _Idmaeedo_FCV, Txt_Log)

    '            ' --- PROCESO FCV ---
    '            Dim MensajeFCV As Mensajes = Fx_GenerarFCV(Nothing, Convert.ToInt32(IdMaeedo_NVV), Empresa_Venta, Txt_Log, encabezado.Id_Enc.ToString())

    '            If MensajeFCV.EsCorrecto Then
    '                LogSeguro("Demonio SincroStock", $"Proceso FCV finalizado correctamente con IDMAEEDO: {MensajeFCV.Id}.", Txt_Log)
    '            Else
    '                LogSeguro("Demonio SincroStock", $"Proceso FCV fallido {MensajeFCV.Mensaje}.", Txt_Log)
    '                ActualizarEstadoEncabezado(_Idmaeedo_FCV, "PROCESANDO", 0, 0, 1, $"Error al crear FCV: {MensajeFCV.Mensaje}", Txt_Log)
    '                Return MensajeFCV
    '            End If
    '            Dim nudo As String = MensajeFCV.Tag

    '            ' [INTERRUPCIÓN ALEATORIA 3]
    '            If puntoMuerto = 3 Then
    '                _Mensaje.EsCorrecto = False
    '                _Mensaje.Mensaje = "Muerte simulada aleatoria después de crear la FCV."
    '                LogSeguro("Demonio SincroStock", _Mensaje.Mensaje, Txt_Log)
    '                Return _Mensaje
    '            End If

    '            ' --- PROCESO FCC ---
    '            Dim MensajeFCC As Mensajes = GeneraFCC(Txt_Log, IdMaeedo_OCC, encabezado.Id_Enc, Empresa_Compra, nudo)
    '            If MensajeFCC.EsCorrecto Then
    '                LogSeguro("Demonio SincroStock", $"Proceso FCC finalizado correctamente con IDMAEEDO: {MensajeFCC.Id}.", Txt_Log)
    '            Else
    '                LogSeguro("Demonio SincroStock", $"Proceso FCC fallido {MensajeFCC.Mensaje}.", Txt_Log)
    '                ActualizarEstadoEncabezado(_Idmaeedo_FCV, "PROCESANDO", 0, 0, 1, $"Error al crear FCC: {MensajeFCC.Mensaje}", Txt_Log)
    '                Return MensajeFCC
    '            End If
    '            ActualizarVinculoSincroStockFCC(MensajeFCC.Id, _Idmaeedo_FCV, Txt_Log)

    '            _Mensaje.EsCorrecto = True
    '            _Mensaje.Detalle = "Proceso de documentos procesados finalizado"
    '            _Mensaje.Mensaje = "OK"
    '            SincronizarDocumentos(encabezado.Id_Enc, Txt_Log)
    '        Next
    '    End If

    '    Return _Mensaje
    'End Function

    Function Actualizar_vinculo_incompleto(Id_enc As Integer, nudo As String) As Mensajes
        Dim Mensaje As New Mensajes
        Mensaje.EsCorrecto = False
        Dim Sql As New Class_SQL(Cadena_ConexionSQL_Server)

        ' Armamos ambas consultas (Encabezado y Detalle) en un solo bloque.
        ' Se separan con un punto y coma (;)
        Dim query As String = $"
-- 1. Actualización del Encabezado
UPDATE {Global_BaseBk}Zw_InterStock_Enc 
SET Nudo = '{nudo}' 
WHERE Id_Enc = {Id_enc};

-- 2. Actualización del Detalle
WITH DocumentosOrigen AS (
    SELECT 
        ent.Id_Enc_InterStock,
        
        -- Datos FCV
        MAX(CASE WHEN ent.Tido = 'FCV' THEN ent.Empresa END) AS Empresa_FCV,
        MAX(CASE WHEN ent.Tido = 'FCV' THEN ent.Idmaeedo END) AS Idmaeedo_FCV,
        MAX(CASE WHEN ent.Tido = 'FCV' THEN ent.Tido END) AS Tido_FCV,
        MAX(CASE WHEN ent.Tido = 'FCV' THEN ent.Nudo END) AS Nudo_FCV,
        MAX(CASE WHEN ent.Tido = 'FCV' THEN Ddo.IDMAEDDO END) AS Idmaeddo_FCV,
        
        -- Datos FCC
        MAX(CASE WHEN ent.Tido = 'FCC' THEN ent.Empresa END) AS Empresa_FCC,
        MAX(CASE WHEN ent.Tido = 'FCC' THEN ent.Idmaeedo END) AS Idmaeedo_FCC,
        MAX(CASE WHEN ent.Tido = 'FCC' THEN ent.Tido END) AS Tido_FCC,
        MAX(CASE WHEN ent.Tido = 'FCC' THEN ent.Nudo END) AS Nudo_FCC,
        MAX(CASE WHEN ent.Tido = 'FCC' THEN Ddo.IDMAEDDO END) AS Idmaeddo_FCC,

        -- Datos NVV (Sucursal, Bodega, Endo y Suendo desde Ma)
        MAX(CASE WHEN ent.Tido = 'NVV' THEN ent.Empresa END) AS Empresa_NVV,
        MAX(CASE WHEN ent.Tido = 'NVV' THEN ent.Idmaeedo END) AS Idmaeedo_NVV,
        MAX(CASE WHEN ent.Tido = 'NVV' THEN ent.Tido END) AS Tido_NVV,
        MAX(CASE WHEN ent.Tido = 'NVV' THEN ent.Nudo END) AS Nudo_NVV,
        MAX(CASE WHEN ent.Tido = 'NVV' THEN Ddo.SULIDO END) AS Sucursal_NVV, 
        MAX(CASE WHEN ent.Tido = 'NVV' THEN Ddo.BOSULIDO END) AS Bodega_NVV,
        MAX(CASE WHEN ent.Tido = 'NVV' THEN Ddo.IDMAEDDO END) AS Idmaeddo_NVV,
        MAX(CASE WHEN ent.Tido = 'NVV' THEN Ma.ENDO END) AS Endo_NVV,
        MAX(CASE WHEN ent.Tido = 'NVV' THEN Ma.SUENDO END) AS Suendo_NVV,

        -- Datos OCC (Sucursal, Bodega, Endo y Suendo desde Ma)
        MAX(CASE WHEN ent.Tido = 'OCC' THEN ent.Empresa END) AS Empresa_OCC,
        MAX(CASE WHEN ent.Tido = 'OCC' THEN ent.Idmaeedo END) AS Idmaeedo_OCC,
        MAX(CASE WHEN ent.Tido = 'OCC' THEN ent.Tido END) AS Tido_OCC,
        MAX(CASE WHEN ent.Tido = 'OCC' THEN ent.Nudo END) AS Nudo_OCC,
        MAX(CASE WHEN ent.Tido = 'OCC' THEN Ddo.SULIDO END) AS Sucursal_OCC,
        MAX(CASE WHEN ent.Tido = 'OCC' THEN Ddo.BOSULIDO END) AS Bodega_OCC,
        MAX(CASE WHEN ent.Tido = 'OCC' THEN Ddo.IDMAEDDO END) AS Idmaeddo_OCC,
        MAX(CASE WHEN ent.Tido = 'OCC' THEN Ma.ENDO END) AS Endo_OCC,
        MAX(CASE WHEN ent.Tido = 'OCC' THEN Ma.SUENDO END) AS Suendo_OCC

    FROM {Global_BaseBk}Zw_Docu_Ent ent
    INNER JOIN MAEEDO Ma ON Ma.IDMAEEDO = ent.Idmaeedo 
                        AND Ma.EMPRESA = ent.Empresa 
                        AND Ma.NUDO = ent.Nudo
    INNER JOIN MAEDDO Ddo on Ddo.IDMAEEDO = Ma.IDMAEEDO
    WHERE ent.Id_Enc_InterStock = {Id_enc}
      AND ent.Tido IN ('FCV', 'FCC', 'NVV', 'OCC')
    GROUP BY ent.Id_Enc_InterStock
)
UPDATE det
SET 
    -- Actualizamos FCV
    det.Empresa_FCV  = ISNULL(origen.Empresa_FCV, det.Empresa_FCV),
    det.Idmaeedo_FCV = ISNULL(origen.Idmaeedo_FCV, det.Idmaeedo_FCV),
    det.Tido_FCV     = ISNULL(origen.Tido_FCV, det.Tido_FCV),
    det.Nudo_FCV     = ISNULL(origen.Nudo_FCV, det.Nudo_FCV),
    det.Idmaeddo_FCV = ISNULL(origen.Idmaeddo_FCV, det.Idmaeddo_FCV),

    -- Actualizamos FCC
    det.Empresa_FCC  = ISNULL(origen.Empresa_FCC, det.Empresa_FCC),
    det.Idmaeedo_FCC = ISNULL(origen.Idmaeedo_FCC, det.Idmaeedo_FCC),
    det.Tido_FCC     = ISNULL(origen.Tido_FCC, det.Tido_FCC),
    det.Nudo_FCC     = ISNULL(origen.Nudo_FCC, det.Nudo_FCC),
    det.Idmaeddo_FCC = ISNULL(origen.Idmaeddo_FCC, det.Idmaeddo_FCC),

    -- Actualizamos NVV
    det.Empresa_NVV  = ISNULL(origen.Empresa_NVV, det.Empresa_NVV),
    det.Idmaeedo_NVV = ISNULL(origen.Idmaeedo_NVV, det.Idmaeedo_NVV),
    det.Tido_NVV     = ISNULL(origen.Tido_NVV, det.Tido_NVV),
    det.Nudo_NVV     = ISNULL(origen.Nudo_NVV, det.Nudo_NVV),
    det.Sucursal_NVV = ISNULL(origen.Sucursal_NVV, det.Sucursal_NVV),
    det.Bodega_NVV   = ISNULL(origen.Bodega_NVV, det.Bodega_NVV),
    det.Idmaeddo_NVV = ISNULL(origen.Idmaeddo_NVV, det.Idmaeddo_NVV),
    det.Endo_NVV     = ISNULL(origen.Endo_NVV, det.Endo_NVV),
    det.Suendo_NVV   = ISNULL(origen.Suendo_NVV, det.Suendo_NVV),

    -- Actualizamos OCC
    det.Empresa_OCC  = ISNULL(origen.Empresa_OCC, det.Empresa_OCC),
    det.Idmaeedo_OCC = ISNULL(origen.Idmaeedo_OCC, det.Idmaeedo_OCC),
    det.Tido_OCC     = ISNULL(origen.Tido_OCC, det.Tido_OCC),
    det.Nudo_OCC     = ISNULL(origen.Nudo_OCC, det.Nudo_OCC),
    det.Sucursal_OCC = ISNULL(origen.Sucursal_OCC, det.Sucursal_OCC),
    det.Bodega_OCC   = ISNULL(origen.Bodega_OCC, det.Bodega_OCC),
    det.Idmaeddo_OCC = ISNULL(origen.Idmaeddo_OCC, det.Idmaeddo_OCC),
    det.Endo_OCC     = ISNULL(origen.Endo_OCC, det.Endo_OCC),
    det.Suendo_OCC   = ISNULL(origen.Suendo_OCC, det.Suendo_OCC)

FROM {Global_BaseBk}Zw_InterStock_Det det
INNER JOIN DocumentosOrigen origen ON det.Id_Enc = origen.Id_Enc_InterStock;
"

        ' Ejecutamos la consulta.
        ' NOTA: Utiliza el método que corresponda en tu Class_SQL para ejecutar comandos que no devuelven datos (ExecuteNonQuery).
        If Sql.Ej_consulta_IDU(query, False) Then
            Mensaje.EsCorrecto = True
            Mensaje.Mensaje = "Vínculo actualizado correctamente."
        Else
            Mensaje.EsCorrecto = False
            Mensaje.Mensaje = "Ocurrió un error al intentar actualizar el vínculo."
        End If

        Return Mensaje
    End Function


    ''' <summary>
    ''' Escribe en el log de forma segura para evitar errores de subprocesos cruzados (Cross-Thread).
    ''' </summary>
    Private Sub LogSeguro(Titulo As String, Mensaje As String, Txt_Log As Object)
        Dim ctrl As Control = TryCast(Txt_Log, Control)

        If ctrl IsNot Nothing AndAlso ctrl.InvokeRequired Then
            ' Si estamos en un hilo secundario, delegamos la acción al hilo de la UI
            ctrl.Invoke(Sub() Sb_AddToLog(Titulo, Mensaje, Txt_Log))
        Else
            ' Si ya estamos en el hilo principal o no es un control, lo ejecutamos directo
            Sb_AddToLog(Titulo, Mensaje, Txt_Log)
        End If
    End Sub

    Private Function TraeIDFCC(Id_Enc) As Integer
        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
        Dim query As String = $"
    Select top 1 Idmaeedo_FCC from {Global_BaseBk}Zw_InterStock_Det where Id_Enc = {Id_Enc} And Idmaeedo_FCC > 0
"
        Dim RowD As DataRow = _Sql.Fx_Get_DataRow(query, False)
        If IsNothing(RowD) Then
            Return 0
        Else
            Return RowD.Item("Idmaeedo_FCC")
        End If
    End Function


End Class
