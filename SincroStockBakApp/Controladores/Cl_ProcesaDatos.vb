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

    Public Function Fx_RellenarInterStock(Txt_Log As Object) As Mensajes
        Dim _Mensaje As New Mensajes
        _Mensaje.EsCorrecto = False

        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)

        Try
            ' MODIFICADO: Se cambia al acceso estructurado por Empresa01 y Empresa02
            Dim tablas() As DataTable = {
                Frm_Sincronizador.Empresa01.EntidadDeCompra,
                Frm_Sincronizador.Empresa02.EntidadDeCompra,
                Frm_Sincronizador.Empresa01.EntidadDeVenta,
                Frm_Sincronizador.Empresa02.EntidadDeVenta
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
            If codigosExcluir.Count > 0 Then
                filtroExclusion = $"WHERE C.ENDO NOT IN ('{String.Join("','", codigosExcluir)}')"
            End If

            Dim Consulta_Select As String = GenerarConsultaSelectInterStock(filtroExclusion)
            Dim _Tbl_Datos As DataTable = _Sql.Fx_Get_DataTable(Consulta_Select)

            If IsNothing(_Tbl_Datos) Then Throw New Exception("No se pudo obtener la tabla de datos inicial.")

            If _Tbl_Datos.Rows.Count = 0 Then
                _Mensaje.EsCorrecto = True
                _Mensaje.Detalle = "Sin documentos nuevos por procesar."
                _Mensaje.Mensaje = "OK."
                Sb_AddToLog("Demonio SincroStock", "No hay facturas nuevas para evaluar stock.", Txt_Log)
                Return _Mensaje
            End If

            Dim _CantidadDocumentos As Integer = _Tbl_Datos.DefaultView.ToTable(True, "IDMAEEDO").Rows.Count
            Sb_AddToLog("Demonio SincroStock", $"Se encontraron {_CantidadDocumentos} documento(s) nuevo(s) para evaluar.", Txt_Log)

            Dim _Consultas_Insert As New StringBuilder()
            _Consultas_Insert.AppendLine("DECLARE @Id_Enc INT;")

            Dim _Idmaeedo_Actual As Integer = 0

            For Each Fila As DataRow In _Tbl_Datos.Rows
                Dim _Idmaeedo As Integer = Fila("IDMAEEDO")
                Dim _Nudo As String = Fila("NUDO").ToString()

                If _Idmaeedo <> _Idmaeedo_Actual Then
                    Dim _EmpresaDoc As String = Fila("EMPRESA").ToString()
                    Sb_AddToLog("Demonio SincroStock", $"Procesando documento {_Nudo} de la empresa {_EmpresaDoc}", Txt_Log)

                    ConstruirInsertEncabezado(_Consultas_Insert, Fila, _Idmaeedo, _EmpresaDoc, _Nudo)
                    _Idmaeedo_Actual = _Idmaeedo
                End If

                ConstruirInsertDetalle(_Consultas_Insert, Fila, _Idmaeedo, _Nudo)
            Next

            ConstruirUpdateProcesar(_Consultas_Insert)

            Dim EjecucionCorrecta As Boolean = _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(_Consultas_Insert.ToString())

            If EjecucionCorrecta Then
                _Mensaje.EsCorrecto = True
                _Mensaje.Detalle = $"Se procesaron {_Tbl_Datos.Rows.Count} líneas de detalle en total."
                _Mensaje.Mensaje = "OK."
                Sb_AddToLog("Demonio SincroStock", "Fin del procesamiento de documentos con éxito.", Txt_Log)
            Else
                Throw New Exception("La transacción de Inserción falló en SQL Server.")
            End If

        Catch ex As Exception
            _Mensaje.EsCorrecto = False
            _Mensaje.Detalle = "Fallo en la ejecución: " & ex.Message
            _Mensaje.Mensaje = "ERROR."
            Sb_AddToLog("Demonio SincroStock", "ERROR CRÍTICO: " & ex.Message, Txt_Log)
        Finally
            If _Sql IsNot Nothing Then _Sql.Sb_Cerrar_Conexion2() ' Opcional: Cerrar explícitamente si aplica
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

            _Mensaje = Fx_Crear_Documento_Desde_Otro_Automaticamente_SincroStock(_Formulario, _Tido_Destino, _Idmaeedo_Origen, fechaEmision, empresa, _Modalidad, False)

            If _Mensaje.EsCorrecto Then
                Consulta_sql = $"SELECT * FROM MAEEDO WHERE IDMAEEDO = {_Mensaje.Id}"
                Dim _Docummento As DataSet = _Sql.Fx_Get_DataSet(Consulta_sql)

                _Mensaje.Tag = _Docummento.Tables(0).Rows(0).Item("NUDO").ToString()
                Sb_AddToLog("Demonio SincroStock", $"FCV creada correctamente con Numero de documento: { _Mensaje.Tag}", Txt_Log)
                Sb_AddToLog("Demonio SincroStock", $"Proceso FCV finalizado correctamente con IDMAEEDO: {_Mensaje.Id}.", Txt_Log)
            Else
                Sb_AddToLog("Demonio SincroStock", $"Proceso FCV fallido { _Mensaje.Mensaje}.", Txt_Log)
                Return _Mensaje
            End If

            ActualizarVinculoSincroStockFCV(_Mensaje.Id, _Idmaeedo_Origen, Txt_Log)

        Catch ex As Exception
            _Mensaje.EsCorrecto = False
            _Mensaje.Detalle = "Excepción no controlada al generar FCV."
            _Mensaje.Mensaje = ex.Message
            Sb_AddToLog("Demonio SincroStock", "Error GenerarFCV: " & ex.Message, Txt_Log)
        Finally
            ' Agregar limpieza aquí si se reservó memoria extra
        End Try

        Return _Mensaje
    End Function

    Function Fx_Crear_Documento_Desde_Otro_Automaticamente_SincroStock(_Formulario As Form,
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
            Dim _Reg As Integer = _Sql.Fx_Cuenta_Registros("CONFIEST", "MODALIDAD = '" & _Modalidad & "'")

            If _Reg = 0 Then Throw New System.Exception("No existe la modalidad " & _Modalidad)

            Dim _RowFormato As DataRow = Fx_Formato_Modalidad(_Formulario, _Empresa, _Modalidad, _Tido_Destino, False)
            If IsNothing(_RowFormato) Then Throw New System.Exception("No existe formato de documento para la modalidad")

            Consulta_sql = "Select * From MAEEDO Where IDMAEEDO = " & _Idmaeedo_Origen
            Dim _Row_Documento As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

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

                Dim _Ds_Maeedo_Origen As DataSet = _Sql.Fx_Get_DataSet(Consulta_sql)

                Mod_Modalidad = _Modalidad

                Fm_Post = New Frm_Formulario_Documento(_Tido_Destino, csGlobales.Enum_Tipo_Documento.Venta, False,,,,,, True)
                Fm_Post.Sb_Limpiar(_Modalidad)
                Fm_Post.Sb_Crear_Documento_Desde_Otros_Documentos(_Formulario, _Ds_Maeedo_Origen, False, False, _Fecha_Emision, False, True)

                _Msj_GrabarDoc = Fm_Post.Fx_Grabar_Documento(False, csGlobales.Mod_Enum_Listados_Globales.Enum_Tipo_de_Grabacion.Nuevo_documento, True, False,,, False)

                If _Msj_GrabarDoc.EsCorrecto Then
                    Fm_Post.Sb_Activar_Orden_De_Despacho(_Msj_GrabarDoc.Id)
                End If
            End If

            If _Msj_GrabarDoc.EsCorrecto Then
                Consulta_sql = "Select * From MAEEDO Where IDMAEEDO = " & _Msj_GrabarDoc.Id
                Dim _Row As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

                _Mensaje.EsCorrecto = True
                _Mensaje.Detalle = "Documento: " & _Row.Item("TIDO") & "-" & _Row.Item("NUDO") & " grabado con exito"
                _Mensaje.Mensaje = "Nota de venta gestionada correctamente Ok."
                _Mensaje.Id = _Msj_GrabarDoc.Id
                _Mensaje.Tag = _Row
            Else
                Throw New System.Exception("No fue posible generar la factura")
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
            _Global_Row_Modalidad = _Sql.Fx_Get_DataRow(Consulta_sql)

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

    Private Function GenerarDocumentoInterno(TipoDoc As String,
                                             RowEntidad As DataRow,
                                             CodEmpresa As String,
                                             Modalidad As String,
                                             TblDetalle As DataTable,
                                             IdMaeedoFCV As String,
                                             Txt_Log As Object,
                                             _Observaciones As String,
                                             _Orden_compra As String,
                                             NudoOr As String,
                                             fechaDoc As Date,
                                             Id_Enc_InterStock As Integer) As Mensajes
        Dim msg As New Mensajes
        msg.EsCorrecto = False
        Dim Fm As Frm_Formulario_Documento = Nothing
        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)

        Try
            ' 1. Ajustar el contexto global a la empresa y modalidad correspondientes
            CambioEmpresa(CodEmpresa, Modalidad)
            Sb_AddToLog("Demonio SincroStock", $"Generando documento {TipoDoc} para FCV: {NudoOr} / Entidad: {RowEntidad("ENDO")} / Modalidad: {Modalidad}", Txt_Log)

            Dim tipoEnum = If(TipoDoc = "OCC", csGlobales.Mod_Enum_Listados_Globales.Enum_Tipo_Documento.Compra, csGlobales.Mod_Enum_Listados_Globales.Enum_Tipo_Documento.Venta)
            Fm = New Frm_Formulario_Documento(TipoDoc, tipoEnum, False, True, False, False, False)

            ' 2. IMPORTANTE: Limpiar/Inicializar el formulario con la modalidad específica 
            ' para que asuma sucursales, bodegas, listas y formatos correctos.
            Fm.Sb_Limpiar(Modalidad)

            Fm.Pro_RowEntidad = RowEntidad
            Fm.Sb_Crear_Documento_Interno_Con_Tabla_SincroStock(TblDetalle, fechaDoc, "Codigo", "Cantidad", "Costo",
                                                                _Observaciones, _Orden_compra, False, False, Id_Enc_InterStock)

            msg = Fm.Fx_Grabar_Documento(False, , True)

            If msg.EsCorrecto Then
                Consulta_sql = $"SELECT * FROM MAEEDO WHERE IDMAEEDO = {msg.Id}"
                Dim _Docummento As DataSet = _Sql.Fx_Get_DataSet(Consulta_sql)

                msg.Tag = _Docummento
                Sb_AddToLog("Demonio SincroStock", $"{TipoDoc} creada correctamente con Numero de documento: {_Docummento.Tables(0).Rows(0).Item("NUDO").ToString()}", Txt_Log)
            Else
                Sb_AddToLog("Demonio SincroStock", $"Error al crear {TipoDoc}: {msg.Mensaje}", Txt_Log)
            End If

        Catch ex As Exception
            msg.Mensaje = "Error en GenerarDocumentoInterno: " & ex.Message
            Sb_AddToLog("Demonio SincroStock", $"Excepción creando {TipoDoc}: {ex.Message}", Txt_Log)
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
            Sb_AddToLog("Demonio SincroStock", $"Ejecutando actualización de tablas SincroStock para {TipoDoc}...", Txt_Log)
            If _Sql.Ej_consulta_IDU(SqlQuery) Then
                Sb_AddToLog("Demonio SincroStock", $"Proceso SQL Exitoso: Tablas actualizadas para {TipoDoc}", Txt_Log)
            Else
                Sb_AddToLog("Demonio SincroStock", $"Fallo SQL al actualizar tablas para {TipoDoc}", Txt_Log)
            End If
        Catch ex As Exception
            Sb_AddToLog("Demonio SincroStock", $"Excepción en ActualizarVinculoSincroStock ({TipoDoc}): " & ex.Message, Txt_Log)
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
            Sb_AddToLog("Demonio SincroStock", $"Ejecutando actualización de tablas SincroStock para {TipoDoc}...", Txt_Log)
            If _Sql.Ej_consulta_IDU(SqlQuery) Then
                Sb_AddToLog("Demonio SincroStock", $"Proceso SQL Exitoso: Tablas actualizadas para {TipoDoc}", Txt_Log)
            Else
                Sb_AddToLog("Demonio SincroStock", $"Fallo SQL al actualizar tablas para {TipoDoc}", Txt_Log)
            End If
        Catch ex As Exception
            Sb_AddToLog("Demonio SincroStock", $"Excepción en ActualizarVinculoSincroStockFCV: " & ex.Message, Txt_Log)
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
            Sb_AddToLog("Demonio SincroStock", $"Ejecutando actualización de tablas SincroStock para {TipoDoc}...", Txt_Log)
            If _Sql.Ej_consulta_IDU(SqlQuery) Then
                Sb_AddToLog("Demonio SincroStock", $"Proceso SQL Exitoso: Tablas actualizadas para {TipoDoc}", Txt_Log)
            Else
                Sb_AddToLog("Demonio SincroStock", $"Fallo SQL al actualizar tablas para {TipoDoc}", Txt_Log)
            End If
        Catch ex As Exception
            Sb_AddToLog("Demonio SincroStock", $"Excepción en ActualizarVinculoSincroStockFCV: " & ex.Message, Txt_Log)
        Finally
            ' Liberar comandos o conexiones si aplica
        End Try
    End Sub

    Private Sub ActualizarEstadoEncabezado(IdMaeedo As Integer, Estado As String, Procesando As Integer, Procesar As Integer, ErrorFlag As Integer, Observacion As String, Txt_Log As Object)
        Dim SqlQuery As String = $"UPDATE {_Global_BaseBk}Zw_InterStock_Enc SET Estado = '{Estado}', Observacion = '{Observacion}', Procesando = {Procesando}, Procesar = {Procesar}, Error = {ErrorFlag} WHERE Idmaeedo = {IdMaeedo}"

        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
        Try
            If _Sql.Ej_consulta_IDU(SqlQuery) Then
                Sb_AddToLog("Demonio SincroStock", $"Estado actualizado a {Estado} para IdMaeedo = {IdMaeedo}", Txt_Log)
            Else
                Sb_AddToLog("Demonio SincroStock", $"Error al actualizar el estado a {Estado} para IdMaeedo= {IdMaeedo}", Txt_Log)
            End If
        Catch ex As Exception
            Sb_AddToLog("Demonio SincroStock", $"Excepción al actualizar estado: " & ex.Message, Txt_Log)
        Finally
            ' Cierre opcional
        End Try
    End Sub

    Private Function ObtenerEntidadMaestro(Koen As String, Suen As String) As DataRow
        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
        Try
            Dim qry As String = $"Select Top 1 *,KOEN AS ENDO, SUEN AS SUENDO From MAEEN Where KOEN = '{Koen}' And SUEN = '{Suen}'"
            Return _Sql.Fx_Get_DataRow(qry)
        Catch ex As Exception
            Throw New Exception("Error en ObtenerEntidadMaestro: " & ex.Message)
        Finally
            If _Sql IsNot Nothing Then _Sql.Sb_Cerrar_Conexion2()
        End Try
    End Function

    Private Function ObtenerDetallesInterStock(IdMaeedo As Integer) As DataTable
        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
        Try
            Dim qry As String = $"Select Codigo,Comprarud1 As Cantidad,Comprarud1 As 'CantDoriUd1',Comprarud2 As 'CantDoriUd2',Costo,Id_Det As 'Observa' From {_Global_BaseBk}Zw_InterStock_Det Where Idmaeedo = {IdMaeedo} And Comprarud1 > 0 And Costo > 0"
            Return _Sql.Fx_Get_DataTable(qry)
        Catch ex As Exception
            Throw New Exception("Error en ObtenerDetallesInterStock: " & ex.Message)
        Finally
            If _Sql IsNot Nothing Then _Sql.Sb_Cerrar_Conexion2()
        End Try
    End Function

    Private Function GenerarConsultaSelectInterStock(filtroExclusion As String) As String
        Dim retorno As String = $"
        Declare @FechaDesde Datetime = GetDate() - 30;
        Declare @FechaHasta Datetime = GetDate();
        WITH Mov AS (
            SELECT Ddo.IDMAEEDO, Ddo.IDMAEDDO, Ddo.TIDO, Ddo.NUDO, Ddo.ENDO, Ddo.SUENDO, 
                   Ddo.EMPRESA, Ddo.SULIDO, Ddo.BOSULIDO, Ddo.KOPRCT, Ddo.CAPRCO1, Ddo.CAPRCO2, Ddo.FEEMLI as Fecha,
                   Mst.STFI1, Mst.STFI2, Ddo.FEEMLI,
                   SUM(Ddo.CAPRCO1) OVER(PARTITION BY Ddo.EMPRESA, Ddo.SULIDO, Ddo.BOSULIDO, Ddo.KOPRCT ORDER BY Ddo.FEEMLI, Ddo.IDMAEDDO) AS AcumUd1,
                   SUM(Ddo.CAPRCO2) OVER(PARTITION BY Ddo.EMPRESA, Ddo.SULIDO, Ddo.BOSULIDO, Ddo.KOPRCT ORDER BY Ddo.FEEMLI, Ddo.IDMAEDDO) AS AcumUd2,
                   SUM(Ddo.CAPRCO1) OVER(PARTITION BY Ddo.EMPRESA, Ddo.SULIDO, Ddo.BOSULIDO, Ddo.KOPRCT) AS TotalUd1,
                   SUM(Ddo.CAPRCO2) OVER(PARTITION BY Ddo.EMPRESA, Ddo.SULIDO, Ddo.BOSULIDO, Ddo.KOPRCT) AS TotalUd2
            FROM MAEDDO Ddo
            LEFT JOIN MAEST Mst ON Ddo.EMPRESA = Mst.EMPRESA AND Ddo.SULIDO = Mst.KOSU AND Ddo.BOSULIDO = Mst.KOBO AND Ddo.KOPRCT = Mst.KOPR
            WHERE Ddo.IDMAEEDO IN (
                SELECT Edo.IDMAEEDO FROM MAEEDO Edo 
                INNER JOIN MAEDDO Ddo ON Edo.IDMAEEDO = Ddo.IDMAEEDO
                WHERE Edo.TIDO = 'FCV' AND Ddo.LINCONDESP = 1 
                  AND Ddo.FEEMLI >= @FechaDesde AND Ddo.FEEMLI <= @FechaHasta 
                  AND NOT EXISTS (SELECT 1 FROM {Frm_Sincronizador._Global_BaseBk}Zw_InterStock_Det ZI WHERE ZI.Idmaeddo = Ddo.IDMAEDDO)
            )
        ),
        Calc AS (
            SELECT *,
                ROUND(STFI1 + TotalUd1, 5) AS StockInicialUd1, ROUND(STFI2 + TotalUd2, 5) AS StockInicialUd2,
                ROUND((STFI1 + TotalUd1) - (AcumUd1 - CAPRCO1), 5) AS StockAntesUd1, ROUND((STFI2 + TotalUd2) - (AcumUd2 - CAPRCO2), 5) AS StockAntesUd2,
                ROUND((STFI1 + TotalUd1) - AcumUd1, 5) AS StockDespuesUd1, ROUND((STFI2 + TotalUd2) - AcumUd2, 5) AS StockDespuesUd2
            FROM Mov
        )
        SELECT C.*, ISNULL(Een.NOKOEN, 'SIN NOMBRE') AS Nokoen,CAST('' As varchar(3)) AS ListaP,
            CASE WHEN StockDespuesUd1 < 0 THEN 1 ELSE 0 END AS Ud1_negativo,
            CASE WHEN StockDespuesUd2 < 0 THEN 1 ELSE 0 END AS Ud2_negativo,
            CASE WHEN StockDespuesUd1 >= 0 THEN 0 WHEN StockAntesUd1 >= 0 THEN ROUND(ABS(StockDespuesUd1),5) ELSE ROUND(CAPRCO1,5) END AS Comprarud1,
            CASE WHEN StockDespuesUd2 >= 0 THEN 0 WHEN StockAntesUd2 >= 0 THEN ROUND(ABS(StockDespuesUd2),5) ELSE ROUND(CAPRCO2,5) END AS Comprarud2
        FROM Calc C
        LEFT JOIN MAEEN Een ON C.ENDO = Een.KOEN AND C.SUENDO = Een.SUEN
        {filtroExclusion}
        ORDER BY C.IDMAEEDO, C.IDMAEDDO;"

        Dim retorno_Prueba = $"
        Declare @FechaDesde Datetime = CAST(GetDate() AS DATE);
        Declare @FechaHasta Datetime = GetDate();
        WITH Mov AS (
            SELECT Ddo.IDMAEEDO, Ddo.IDMAEDDO, Ddo.TIDO, Ddo.NUDO, Ddo.ENDO, Ddo.SUENDO, 
                   Ddo.EMPRESA, Ddo.SULIDO, Ddo.BOSULIDO, Ddo.KOPRCT, Ddo.CAPRCO1, Ddo.CAPRCO2, Ddo.FEEMLI as Fecha,
                   Mst.STFI1, Mst.STFI2, Ddo.FEEMLI,
                   SUM(Ddo.CAPRCO1) OVER(PARTITION BY Ddo.EMPRESA, Ddo.SULIDO, Ddo.BOSULIDO, Ddo.KOPRCT ORDER BY Ddo.FEEMLI, Ddo.IDMAEDDO) AS AcumUd1,
                   SUM(Ddo.CAPRCO2) OVER(PARTITION BY Ddo.EMPRESA, Ddo.SULIDO, Ddo.BOSULIDO, Ddo.KOPRCT ORDER BY Ddo.FEEMLI, Ddo.IDMAEDDO) AS AcumUd2,
                   SUM(Ddo.CAPRCO1) OVER(PARTITION BY Ddo.EMPRESA, Ddo.SULIDO, Ddo.BOSULIDO, Ddo.KOPRCT) AS TotalUd1,
                   SUM(Ddo.CAPRCO2) OVER(PARTITION BY Ddo.EMPRESA, Ddo.SULIDO, Ddo.BOSULIDO, Ddo.KOPRCT) AS TotalUd2
            FROM MAEDDO Ddo
            LEFT JOIN MAEST Mst ON Ddo.EMPRESA = Mst.EMPRESA AND Ddo.SULIDO = Mst.KOSU AND Ddo.BOSULIDO = Mst.KOBO AND Ddo.KOPRCT = Mst.KOPR
            WHERE Ddo.IDMAEEDO IN (
                SELECT Edo.IDMAEEDO FROM MAEEDO Edo 
                INNER JOIN MAEDDO Ddo ON Edo.IDMAEEDO = Ddo.IDMAEEDO
                WHERE Edo.TIDO = 'FCV' AND Ddo.LINCONDESP = 1 
                  AND Ddo.FEEMLI >= @FechaDesde AND Ddo.FEEMLI <= @FechaHasta 
                  AND NOT EXISTS (SELECT 1 FROM {Frm_Sincronizador._Global_BaseBk}Zw_InterStock_Det ZI WHERE ZI.Idmaeddo = Ddo.IDMAEDDO)
            )
        ),
        Calc AS (
            SELECT *,
                ROUND(STFI1 + TotalUd1, 5) AS StockInicialUd1, ROUND(STFI2 + TotalUd2, 5) AS StockInicialUd2,
                ROUND((STFI1 + TotalUd1) - (AcumUd1 - CAPRCO1), 5) AS StockAntesUd1, ROUND((STFI2 + TotalUd2) - (AcumUd2 - CAPRCO2), 5) AS StockAntesUd2,
                ROUND((STFI1 + TotalUd1) - AcumUd1, 5) AS StockDespuesUd1, ROUND((STFI2 + TotalUd2) - AcumUd2, 5) AS StockDespuesUd2
            FROM Mov
        )
        SELECT C.*, ISNULL(Een.NOKOEN, 'SIN NOMBRE') AS Nokoen,'' AS ListaP,
            CASE WHEN StockDespuesUd1 < 0 THEN 1 ELSE 0 END AS Ud1_negativo,
            CASE WHEN StockDespuesUd2 < 0 THEN 1 ELSE 0 END AS Ud2_negativo,
            CASE WHEN StockDespuesUd1 >= 0 THEN 0 WHEN StockAntesUd1 >= 0 THEN ROUND(ABS(StockDespuesUd1),5) ELSE ROUND(CAPRCO1,5) END AS Comprarud1,
            CASE WHEN StockDespuesUd2 >= 0 THEN 0 WHEN StockAntesUd2 >= 0 THEN ROUND(ABS(StockDespuesUd2),5) ELSE ROUND(CAPRCO2,5) END AS Comprarud2
        FROM Calc C
        LEFT JOIN MAEEN Een ON C.ENDO = Een.KOEN AND C.SUENDO = Een.SUEN
        {filtroExclusion}
        ORDER BY C.IDMAEEDO, C.IDMAEDDO;"
        Return retorno_Prueba

    End Function

    Private Sub ConstruirInsertEncabezado(sb As StringBuilder, Fila As DataRow, Idmaeedo As Integer, EmpresaDoc As String, Nudo As String)
        Dim NokoenLimpio As String = Fila("Nokoen").ToString().Replace("'", "''")
        sb.AppendLine($"
        IF NOT EXISTS (SELECT 1 FROM {Frm_Sincronizador._Global_BaseBk}Zw_InterStock_Enc WHERE Idmaeedo = {Idmaeedo})
        BEGIN
            INSERT INTO {Frm_Sincronizador._Global_BaseBk}Zw_InterStock_Enc
            (Idmaeedo, Empresa, Tido, Nudo, Endo, Suendo, Nokoen, Estado, Procesar, Procesando, Procesada, Error, Observacion, FechaIngreso)
            VALUES ({Idmaeedo}, '{EmpresaDoc}', '{Fila("TIDO")}', '{Nudo}', '{Fila("ENDO")}', '{Fila("SUENDO")}', 
             '{NokoenLimpio}', 'PENDIENTE', 0, 0, 0, 0, '', '{Format(Fila("Fecha"), "yyyyMMdd")}');
            SET @Id_Enc = SCOPE_IDENTITY(); 
        END
        ELSE BEGIN
            SELECT @Id_Enc = Id_Enc FROM {Frm_Sincronizador._Global_BaseBk}Zw_InterStock_Enc WHERE Idmaeedo = {Idmaeedo};
        END")
    End Sub

    Private Sub ConstruirInsertDetalle(sb As StringBuilder, Fila As DataRow, Idmaeedo As Integer, Nudo As String)
        Dim formateaNum = Function(val As Object) val.ToString().Replace(",", ".")
        sb.AppendLine($"
    INSERT INTO {Frm_Sincronizador._Global_BaseBk}Zw_InterStock_Det 
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
        FROM {Frm_Sincronizador._Global_BaseBk}Zw_InterStock_Enc Enc
        WHERE Enc.Estado = 'PENDIENTE' AND EXISTS (
            SELECT 1 FROM {Frm_Sincronizador._Global_BaseBk}Zw_InterStock_Det Det 
            WHERE Det.Id_Enc = Enc.Id_Enc AND (Det.Comprarud1 > 0 OR Det.Comprarud2 > 0)
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

            Dim _Tbl_Detalles As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

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
                        dtEntidadComprador = Frm_Sincronizador.Empresa01.EntidadDeCompra
                        dtEntidadVendedor = Frm_Sincronizador.Empresa02.EntidadDeVenta
                        dtModComprador = Frm_Sincronizador.Empresa01.ModalidadOCC
                        dtModVendedor = Frm_Sincronizador.Empresa02.ModalidadNVV
                        CodEmpresaVendedor = "02"
                    Else
                        dtEntidadComprador = Frm_Sincronizador.Empresa02.EntidadDeCompra
                        dtEntidadVendedor = Frm_Sincronizador.Empresa01.EntidadDeVenta
                        dtModComprador = Frm_Sincronizador.Empresa02.ModalidadOCC
                        dtModVendedor = Frm_Sincronizador.Empresa01.ModalidadNVV
                        CodEmpresaVendedor = "01"
                    End If
                    Dim Lista As String = ""

                    Dim Consulta_Lista As String = $"Select top 1 RIGHT(LVEN, 3) AS CodLista from MAEEN where KOEN = '{dtEntidadVendedor.Rows(0).Item("Codigo").ToString().Trim()}'"
                    Dim _Tbl_precio As DataTable = _Sql.Fx_Get_DataTable(Consulta_Lista)
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
                    Dim _Codto As Double = calcula_precio(Lista, fila("Codigo").ToString(), fila("EMPRESA").ToString())
                    Dim Costo As Double = Math.Round(_Codto, 5)
                    _Consultas_Update.AppendLine($"UPDATE {_Global_BaseBk}Zw_InterStock_Det SET Costo = {De_Num_a_Tx_01(Costo, False, 5)}, CodLista = '{Lista}' WHERE Id_Det = {idDetalle};")
                Next

                Dim EjecucionCorrecta As Boolean = _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(_Consultas_Update.ToString())

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
                _Koen = Frm_Sincronizador.Empresa02.EntidadDeCompra.Rows(0).Item("Codigo").ToString().Trim()
                Dim Modalidad As String = Frm_Sincronizador.Empresa02.ModalidadNVV.Rows(0).Item("Codigo").ToString().Trim()
                CambioEmpresa("02", Modalidad)
            Else
                _Koen = Frm_Sincronizador.Empresa01.EntidadDeCompra.Rows(0).Item("Codigo").ToString().Trim()
                Dim Modalidad As String = Frm_Sincronizador.Empresa01.ModalidadNVV.Rows(0).Item("Codigo").ToString().Trim()
                CambioEmpresa("01", Modalidad)
            End If

            Dim _RowPrecios As DataRow
            Dim _Ecuacion As String
            Dim _Ecuacionu2 As String
            Dim _PrecioListaUd2 As Double

            Consulta_sql = "Select Top 1 *,(Select top 1 MELT From TABPP Where KOLT = '" & _CodLista & "') as MELT From TABPRE" & vbCrLf &
                           "Where KOLT = '" & _CodLista & "' And KOPR = '" & _Codigo & "'"
            _RowPrecios = _Sql.Fx_Get_DataRow(Consulta_sql)

            If _RowPrecios IsNot Nothing Then
                Dim _DescMaximo As Double = NuloPorNro(_RowPrecios.Item("DTMA01UD"), 0)
                _Ecuacion = NuloPorNro(_RowPrecios.Item("ECUACION").ToString.Trim, "")
                _Ecuacionu2 = NuloPorNro(_RowPrecios.Item("ECUACIONU2").ToString.Trim, "")

                If String.IsNullOrEmpty(_Ecuacion.Trim) Then
                    _Ecuacion = _Sql.Fx_Trae_Dato("TABPP", "ECUDEF01UD", "KOLT = '" & _CodLista & "'").ToString.Trim
                End If

                If String.IsNullOrEmpty(_Ecuacionu2.Trim) Then
                    _Ecuacionu2 = _Sql.Fx_Trae_Dato("TABPP", "ECUDEF02UD", "KOLT = '" & _CodLista & "'").ToString.Trim
                End If

                _PrecioListaUd1 = Fx_Funcion_Ecuacion_Random(Nothing, _Koen, _Ecuacion, _Codigo, 1, _RowPrecios, 0, 0, 0, False)
                _PrecioListaUd2 = Fx_Funcion_Ecuacion_Random(Nothing, _Koen, _Ecuacionu2, _Codigo, 2, _RowPrecios, 0, 0, 0, False)
            End If

        Catch ex As Exception
            ' Manejo del error devolviendo 0 como medida de seguridad ante un cálculo fallido
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
            Consulta_sql = $"SELECT FechaIngreso AS FechaActual FROM {Frm_Sincronizador._Global_BaseBk}Zw_InterStock_Enc  WHERE Id_Enc = " & IdEnc
            Dim _Row As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)
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
    INNER JOIN {Frm_Sincronizador._Global_BaseBk}Zw_InterStock_Det d ON m.TIDO = d.Tido_OCC AND m.NUDO = d.Nudo_OCC
    INNER JOIN {Frm_Sincronizador._Global_BaseBk}Zw_InterStock_Enc e ON e.Id_Enc = d.Id_Enc 
    INNER JOIN MAEEDO orig ON d.Tido = orig.TIDO AND d.Nudo = orig.NUDO
    WHERE e.Id_Enc = {IdEnc} 
      AND d.Tido_OCC IS NOT NULL AND d.Tido_OCC <> '';

    -- 2. ACTUALIZAR LAS NVV (Resta 8)
    UPDATE m
    SET HORAGRAB = orig.HORAGRAB - 8
    FROM MAEEDO m
    INNER JOIN {Frm_Sincronizador._Global_BaseBk}Zw_InterStock_Det d ON m.TIDO = d.Tido_NVV AND m.NUDO = d.Nudo_NVV
    INNER JOIN {Frm_Sincronizador._Global_BaseBk}Zw_InterStock_Enc e ON e.Id_Enc = d.Id_Enc 
    INNER JOIN MAEEDO orig ON d.Tido = orig.TIDO AND d.Nudo = orig.NUDO
    WHERE e.Id_Enc = {IdEnc} 
      AND d.Tido_NVV IS NOT NULL AND d.Tido_NVV <> '';

    -- 3. ACTUALIZAR LAS FCV (Resta 6)
    UPDATE m
    SET HORAGRAB = orig.HORAGRAB - 6
    FROM MAEEDO m
    INNER JOIN {Frm_Sincronizador._Global_BaseBk}Zw_InterStock_Det d ON m.TIDO = d.Tido_FCV AND m.NUDO = d.Nudo_FCV
    INNER JOIN {Frm_Sincronizador._Global_BaseBk}Zw_InterStock_Enc e ON e.Id_Enc = d.Id_Enc 
    INNER JOIN MAEEDO orig ON d.Tido = orig.TIDO AND d.Nudo = orig.NUDO
    WHERE e.Id_Enc = {IdEnc} 
      AND d.Tido_FCV IS NOT NULL AND d.Tido_FCV <> '' 
      AND NOT (m.TIDO = d.Tido AND m.NUDO = d.Nudo);

    -- 4. ACTUALIZAR LAS FCC (Resta 4)
    UPDATE m
    SET HORAGRAB = orig.HORAGRAB - 4
    FROM MAEEDO m
    INNER JOIN {Frm_Sincronizador._Global_BaseBk}Zw_InterStock_Det d ON m.TIDO = d.Tido_FCC AND m.NUDO = d.Nudo_FCC
    INNER JOIN {Frm_Sincronizador._Global_BaseBk}Zw_InterStock_Enc e ON e.Id_Enc = d.Id_Enc 
    INNER JOIN MAEEDO orig ON d.Tido = orig.TIDO AND d.Nudo = orig.NUDO
    WHERE e.Id_Enc = {IdEnc} 
      AND d.Tido_FCC IS NOT NULL AND d.Tido_FCC <> '';"

        Dim EjecucionCorrecta As Boolean = _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql_p)

        If EjecucionCorrecta Then

            Sb_AddToLog("Demonio SincroStock", "Fin del procesamiento de documentos con éxito.", Txt_Log)
        Else
            Sb_AddToLog("Demonio SincroStock", "Fin del procesamiento de documentos con Error.", Txt_Log)

        End If
    End Sub


    Public Function GeneraFCC(Txt_Log As Object, Idmaeedo_OCC As String, Id_Enc As String, EmpresaGenera As Empresa, Nudo As String)
        CambioEmpresa(EmpresaGenera.Numero, EmpresaGenera.ModalidadFCC.Rows(0).Item("Codigo").ToString().Trim())

        Dim _Tido = "FCC"
        Dim _Idmaeedo_OCC As String = Idmaeedo_OCC
        Dim _CampoPrecio As String
        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)

        Consulta_sql = $"Select * From MAEEDO Where IDMAEEDO = {_Idmaeedo_OCC}"
        Dim _Row_Maeedo_OCC As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        Dim _Koen As String = _Row_Maeedo_OCC.Item("ENDO")
        Dim _Suen As String = _Row_Maeedo_OCC.Item("SUENDO")
        Dim _Nudo As String = Nudo
        Dim Mensaje As Mensajes

        Dim _Fecha_Emision As DateTime? = ObtenerFecha(Id_Enc)
        Sb_AddToLog("Demonio SincroStock", $"Empezando la creacion de la FCC para el documento con IDMAEEDO : {_Idmaeedo_OCC}.", Txt_Log)


        If True Then
            ' Neto
            _CampoPrecio = "PPPRNE"
        Else
            ' Bruto
            _CampoPrecio = "PPPRBR"
        End If

        Consulta_sql = $"Select * From MAEEDO Where IDMAEEDO = {_Idmaeedo_OCC}"
        Dim _Row_OCC As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

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

                Dim _Ds_Maeedo_Origen As DataSet = _Sql.Fx_Get_DataSet(Consulta_sql)

                Dim Fm_Post As New Frm_Formulario_Documento(_Tido, csGlobales.Enum_Tipo_Documento.Compra, False)
                Fm_Post.Pro_SubTido = "100"
                Fm_Post.Sb_Limpiar(Mod_Modalidad)
                Fm_Post.Pro_Nudo = _Nudo
                'Fm_Post.HoraAlPrincipioDelDia = True
                Fm_Post.Sb_Crear_Documento_Desde_Otros_Documentos(Nothing, _Ds_Maeedo_Origen, False, False, _Fecha_Emision, False, True)
                _Mensaje = Fm_Post.Fx_Grabar_Documento(False, csGlobales.Mod_Enum_Listados_Globales.Enum_Tipo_de_Grabacion.Nuevo_documento, False)
                Fm_Post.Dispose()

                If _Mensaje.EsCorrecto Then
                    Consulta_sql = $"SELECT * FROM MAEEDO WHERE IDMAEEDO = {_Mensaje.Id}"
                    Dim _Docummento As DataSet = _Sql.Fx_Get_DataSet(Consulta_sql)

                    _Mensaje.Tag = _Docummento
                    Sb_AddToLog("Demonio SincroStock", $"FCC creada correctamente con Numero de documento: {_Docummento.Tables(0).Rows(0).Item("NUDO").ToString()}", Txt_Log)
                    Return _Mensaje

                Else
                    Sb_AddToLog("Demonio SincroStock", $"Error al crear la FCC : {_Mensaje.Mensaje}", Txt_Log)
                    Return _Mensaje


                End If


            Catch ex As Exception

                Sb_AddToLog("Demonio SincroStock", $"Error al crear la FCC : {ex.Message}", Txt_Log)


            Finally



            End Try

        Else
            Mensaje.EsCorrecto = False
            Mensaje.Detalle = "No se encontro coincidencia"
            Sb_AddToLog("Demonio SincroStock", "No se encontro coincidencia", Txt_Log)
            Return Mensaje

        End If

        Mensaje.EsCorrecto = False
        Mensaje.Detalle = "Error al crear la FCC"


        Return Mensaje
    End Function



    Public Function GenerarDocumentos(Txt_Log As Object) As Mensajes
        Dim _Mensaje As New Mensajes
        _Mensaje.EsCorrecto = False
        _Mensaje.Detalle = "No se encontraron documentos para procesar."

        Dim Documentos As DataTable = ObtenerDocs()
        Sb_AddToLog("Demonio SincroStock", $"Se encontraron {Documentos.Rows.Count} documentos para procesar.", Txt_Log)

        If Documentos IsNot Nothing Then
            For Each Doc As DataRow In Documentos.Rows

                Dim encabezado As New DocumentoEncabezado(Doc)
                Sb_AddToLog("Demonio SincroStock", $"Procesando documento {encabezado.Nudo} de la empresa: {encabezado.Empresa}", Txt_Log)

                Dim Empresa_Compra As Empresa
                Dim Empresa_Venta As Empresa
                If encabezado.Empresa = "01" Then
                    Empresa_Compra = Frm_Sincronizador.Empresa01
                    Empresa_Venta = Frm_Sincronizador.Empresa02
                Else
                    Empresa_Compra = Frm_Sincronizador.Empresa02
                    Empresa_Venta = Frm_Sincronizador.Empresa01
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
                    Return _Mensaje
                End If
                ' CORRECCIÓN 2: Declarar explícitamente como Integer para funciones posteriores
                Dim _Idmaeedo_FCV As String = encabezado.Idmaeedo

                ActualizarEstadoEncabezado(_Idmaeedo_FCV, "PROCESANDO", 1, 0, 0, "Procesando en Daemon", Txt_Log)

                Dim _TblDetalle As DataTable = ObtenerDetallesInterStock(_Idmaeedo_FCV)
                If Not CBool(_TblDetalle.Rows.Count) Then
                    Dim msgError As String = "No hay precio o cantidad en los productos"
                    ActualizarEstadoEncabezado(_Idmaeedo_FCV, "PROCESANDO", 0, 0, 1, $"Error al crear documentos: {msgError}", Txt_Log)
                    _Mensaje.EsCorrecto = False
                    _Mensaje.Mensaje = msgError
                    Sb_AddToLog("Demonio SincroStock", "No hay productos elegibles.", Txt_Log)
                    Return _Mensaje
                End If

                Dim _Observaciones As String = $"Documento generado automáticamente desde FCV: {encabezado.Nudo}."

                ' --- PROCESO OCC ---
                Dim MensajeOCC As Mensajes = GenerarDocumentoInterno("OCC", _Row_Entidad_OCC_PROVEEDOR, Empresa_Compra.Numero, Empresa_Compra.ModalidadOCC.Rows(0).Item("Codigo").ToString().Trim(), _TblDetalle, _Idmaeedo_FCV, Txt_Log, _Observaciones, "", encabezado.Nudo, fechaDoc, 0)

                If Not MensajeOCC.EsCorrecto Then
                    ActualizarEstadoEncabezado(_Idmaeedo_FCV, "PROCESANDO", 0, 0, 1, $"Error al crear OCC: {MensajeOCC.Mensaje}", Txt_Log)
                    Return MensajeOCC
                End If

                Dim IdMaeedo_OCC As String = MensajeOCC.Id
                ActualizarVinculoSincroStock("OCC", IdMaeedo_OCC, _Idmaeedo_FCV, Txt_Log)

                Dim _Orden_compra As String = CType(MensajeOCC.Tag, DataSet).Tables(0).Rows(0).Item("NUDO").ToString()
                _Observaciones = String.Empty

                ' --- PROCESO NVV ---
                Dim MensajeNVV As Mensajes = GenerarDocumentoInterno("NVV", _Row_Entidad_NVV_COMPRADOR, Empresa_Venta.Numero, Empresa_Venta.ModalidadNVV.Rows(0).Item("Codigo").ToString().Trim(), _TblDetalle, _Idmaeedo_FCV, Txt_Log, _Observaciones, _Orden_compra, encabezado.Nudo, fechaDoc, 0)

                If Not MensajeNVV.EsCorrecto Then
                    ActualizarEstadoEncabezado(_Idmaeedo_FCV, "PROCESANDO", 0, 0, 1, $"Error al crear NVV: {MensajeNVV.Mensaje}", Txt_Log)
                    Return MensajeNVV
                End If

                Dim IdMaeedo_NVV As String = MensajeNVV.Id

                ActualizarVinculoSincroStock("NVV", IdMaeedo_NVV, _Idmaeedo_FCV, Txt_Log)
                Sb_AddToLog("Demonio SincroStock", "Proceso NVV finalizado.", Txt_Log)

                ' --- PROCESO FCV ---
                ' CORRECCIÓN 3: Forzar tipos correctos. (Form, Integer, Empresa, Object, String)
                Dim MensajeFCV As Mensajes = Fx_GenerarFCV(Nothing, Convert.ToInt32(IdMaeedo_NVV), Empresa_Venta, Txt_Log, encabezado.Id_Enc.ToString())

                If MensajeFCV.EsCorrecto Then
                    Sb_AddToLog("Demonio SincroStock", $"Proceso FCV finalizado correctamente con IDMAEEDO: {MensajeFCV.Id}.", Txt_Log)
                Else
                    Sb_AddToLog("Demonio SincroStock", $"Proceso FCV fallido {MensajeFCV.Mensaje}.", Txt_Log)
                    ActualizarEstadoEncabezado(_Idmaeedo_FCV, "PROCESANDO", 0, 0, 1, $"Error al crear FCV: {MensajeFCV.Mensaje}", Txt_Log)

                    Return MensajeFCV
                End If
                Dim nudo As String = MensajeFCV.Tag

                ' --- PROCESO FCC ---
                ' CORRECCIÓN 4: Convertir Id_Enc a String para que coincida con la firma.
                Dim MensajeFCC As Mensajes = GeneraFCC(Txt_Log, IdMaeedo_OCC, encabezado.Id_Enc.ToString(), Empresa_Compra, nudo)
                If MensajeFCC.EsCorrecto Then
                    Sb_AddToLog("Demonio SincroStock", $"Proceso FCC finalizado correctamente con IDMAEEDO: {MensajeFCC.Id}.", Txt_Log)
                Else
                    Sb_AddToLog("Demonio SincroStock", $"Proceso FCC fallido {MensajeFCC.Mensaje}.", Txt_Log)
                    ActualizarEstadoEncabezado(_Idmaeedo_FCV, "PROCESANDO", 0, 0, 1, $"Error al crear FCC: {MensajeFCC.Mensaje}", Txt_Log)
                    Return MensajeFCC
                End If
                ActualizarVinculoSincroStockFCC(MensajeFCC.Id, _Idmaeedo_FCV, Txt_Log)

                _Mensaje.EsCorrecto = True
                _Mensaje.Detalle = "Proceso de documentos procesados finalizado"
                _Mensaje.Mensaje = "OK"
                SincronizarDocumentos(encabezado.Id_Enc, Txt_Log)
            Next
        End If

        Return _Mensaje
    End Function

    Public Function ObtenerDocs() As DataTable
        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
        Try
            Dim Consulta_sql As String = $"
            Select * from {Frm_Sincronizador._Global_BaseBk}Zw_InterStock_Enc Where Procesar = 1;"

            Return _Sql.Fx_Get_DataTable(Consulta_sql)
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
        Dim SQL_QUERY As String = $"Update {Frm_Sincronizador._Global_BaseBk}Zw_InterStock_Det SET Suendo_OCC = '{SUEND_OCC}', Suendo_NVV = '{SUEND_NVV}', Endo_NVV = '{Endo_NVV}', Endo_OCC = '{Endo_OCC}' where Id_Enc = {Id_Enc}"

        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)

        Dim EjecucionCorrecta As Boolean = _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(SQL_QUERY)
        Dim _Mensaje As New Mensajes
        If EjecucionCorrecta Then
            _Mensaje.EsCorrecto = True
            _Mensaje.Detalle = $"Se actualizaron las entidades."
            _Mensaje.Mensaje = "OK."
            Sb_AddToLog("Demonio SincroStock", "Fin del procesamiento de documentos con éxito.", Txt_Log)
        Else
            _Mensaje.EsCorrecto = False
            _Mensaje.Detalle = "La transacción de Inserción falló en SQL Server."
            Throw New Exception("La transacción de Inserción falló en SQL Server.")

        End If

        Return _Mensaje
    End Function
End Class
