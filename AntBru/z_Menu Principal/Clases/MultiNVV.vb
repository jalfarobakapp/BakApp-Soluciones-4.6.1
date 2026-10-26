Imports BkSpecialPrograms
Imports BkSpecialPrograms.LsValiciones

Public Class MultiNVV
    Dim Sql As New Class_SQL(Cadena_ConexionSQL_Server)



    Public Function Proceso_MultiNvv(Id_Documento_Ori As String, Nudo_NVV As String) As Mensajes
        Dim msgFinal As New Mensajes With {
            .EsCorrecto = False,
            .Mensaje = "Iniciando proceso...",
            .Detalle = ""
        }

        Try
            ' 1. Generar los documentos NVV a partir del documento origen
            Dim listaResultados As List(Of Mensajes) = GeneraNVV(Id_Documento_Ori, Nudo_NVV)

            ' 2. Analizar los resultados de la generación
            Dim documentosGenerados As Integer = 0
            Dim detalleErrores As String = ""

            For Each resultado In listaResultados
                If resultado.EsCorrecto Then
                    documentosGenerados += 1
                Else
                    detalleErrores &= resultado.Detalle & vbCrLf
                End If
            Next

            ' Si no se generó ningún documento, se interrumpe el proceso
            If documentosGenerados = 0 Then
                msgFinal.EsCorrecto = False
                msgFinal.Mensaje = "No se logró generar ningún documento NVV."
                msgFinal.Detalle = detalleErrores
                Return msgFinal
            End If
            msgFinal.Tag = listaResultados
            ' 3. Asociar los despachos y heredar datos a los documentos hijos creados
            ' Convertimos Id_Documento_Ori a Integer ya que Asociar_despachos lo requiere numérico
            Dim idMaeedoInt As Integer = CInt(Id_Documento_Ori)
            Dim resultadoAsociacion As Mensajes = Asociar_despachos(Nudo_NVV, idMaeedoInt)

            ' 4. Consolidar el resultado final
            If Not resultadoAsociacion.EsCorrecto Then
                msgFinal.EsCorrecto = False
                msgFinal.Mensaje = $"Se generaron {documentosGenerados} documento(s), pero falló la asociación de despachos."
                msgFinal.Detalle = resultadoAsociacion.Mensaje & vbCrLf & resultadoAsociacion.Detalle
            Else
                msgFinal.EsCorrecto = True
                msgFinal.Mensaje = $"Proceso completado. Se generaron {documentosGenerados} documento(s) NVV y se asociaron los despachos correctamente."

                ' Adjuntar advertencias si hubo errores parciales en la generación de algún documento
                If Not String.IsNullOrEmpty(detalleErrores) Then
                    msgFinal.Detalle = "El proceso finalizó con advertencias:" & vbCrLf & detalleErrores
                End If
            End If

        Catch ex As Exception
            msgFinal.EsCorrecto = False
            msgFinal.Mensaje = "Error general al procesar múltiples NVV."
            msgFinal.Detalle = ex.Message
        End Try

        Return msgFinal
    End Function

    Public Function GeneraNVV(Id_Documento_Ori As String, Nudo_NVV As String) As List(Of Mensajes)
        ' Cambiamos el retorno a List(Of Mensajes) porque se pueden generar múltiples documentos


        Dim listaMensajes As New List(Of Mensajes)()

        Dim _Tido = "NVV"
        Dim _CampoPrecio As String
        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
        Dim Consulta_sql As String

        Dim _Fecha_Emision As DateTime? = DateTime.Now

        If True Then
            _CampoPrecio = "PPPRNE" ' Neto
        Else
            _CampoPrecio = "PPPRBR" ' Bruto
        End If

        ' Validamos si existe el documento de origen
        Consulta_sql = $"Select * From MAEEDO Where IDMAEEDO = {Id_Documento_Ori}"
        Dim _Row_OCC As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql, False)

        If IsNothing(_Row_OCC) Then
            Dim msgError As New Mensajes
            msgError.EsCorrecto = False
            msgError.Detalle = "No se encontro coincidencia del documento de origen"
            listaMensajes.Add(msgError)
            Return listaMensajes
        End If

        Try
            ' 1. OBTENER LOS TIPOS ÚNICOS DE CLALIBPR PRESENTES EN EL DETALLE DEL DOCUMENTO ORIGEN
            Consulta_sql = $"
                SELECT DISTINCT Mp.CLALIBPR 
                FROM MAEDDO Ddo WITH (NOLOCK)
                INNER JOIN MAEPR Mp On Mp.KOPR = Ddo.KOPRCT
                Where TIDO = 'NVV' And NUDO = '{Nudo_NVV}'
                AND (Ddo.ESLIDO<>'C' OR Ddo.ESFALI='I') 
                AND Ddo.TICT = ''"

            Dim dtClasificaciones As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql, False)

            If dtClasificaciones Is Nothing OrElse dtClasificaciones.Rows.Count = 0 Then
                Dim msgError As New Mensajes With {.EsCorrecto = False, .Detalle = "No hay detalles válidos para procesar."}
                listaMensajes.Add(msgError)
                Return listaMensajes
            End If

            ' 2. ITERAR POR CADA CLASIFICACIÓN DISTINTA Y CREAR UN DOCUMENTO
            For Each rowClasif As DataRow In dtClasificaciones.Rows
                Dim _Clasificacion As String = rowClasif("CLALIBPR").ToString().Trim()
                Dim _Mensaje As New Mensajes

                Try
                    ' 3. ARMAR LA QUERY USANDO EL ID DINÁMICO Y LA CLASIFICACIÓN ACTUAL DEL BUCLE
                    Consulta_sql = $"Declare @Idmaeedo Int = {Id_Documento_Ori}

                    SELECT * FROM MAEEDO Where IDMAEEDO = @Idmaeedo

                    SELECT *, CASE WHEN UDTRPR = 1 THEN CAPRCO1-CAPREX1 ELSE CAPRCO2-CAPREX2 END AS 'Cantidad',
                    CAPRCO1-CAPREX1 AS 'CantUd1_Dori', CAPRCO2-CAPREX2 AS 'CantUd2_Dori',
                    PPPRNE AS 'Precio',
                    0 As Id_Oferta, '' As Oferta, 0 As Es_Padre_Oferta, 0 As Padre_Oferta, 0 As Hijo_Oferta,
                    0 As Cantidad_Oferta, 0 As Porcdesc_Oferta
                    FROM MAEDDO WITH (NOLOCK) 
                    Inner Join MAEPR Mp On Mp.KOPR = KOPRCT
                    Where IDMAEEDO = @Idmaeedo AND (ESLIDO<>'C' OR ESFALI='I') AND TICT = ''
                    And Mp.CLALIBPR = '{_Clasificacion}'
                    ORDER BY IDMAEEDO, IDMAEDDO 

                    SELECT * FROM MAEIMLI Where IDMAEEDO = @Idmaeedo 
                    SELECT * FROM MAEDTLI Where IDMAEEDO = @Idmaeedo 
                    SELECT TOP 1 * FROM MAEEDOOB Where IDMAEEDO = @Idmaeedo"

                    ' Obtenemos el Dataset específico para esta clasificación
                    Dim _Ds_Maeedo_Origen As DataSet = _Sql.Fx_Get_DataSet(Consulta_sql, False)

                    ' Instanciamos el formulario y creamos el documento
                    Dim Fm_Post As New Frm_Formulario_Documento(_Tido, csGlobales.Enum_Tipo_Documento.Compra, False, _RevisarListaSuperior:=False)
                    Fm_Post.Sb_Limpiar(Mod_Modalidad)
                    'Fm_Post.Pro_Nudo = Nudo_NVV

                    Fm_Post.Sb_Crear_Documento_Desde_Otros_Documentos(Nothing, _Ds_Maeedo_Origen, False, False, _Fecha_Emision, False, True, _ConservaTrazabilidad:=True)
                    _Mensaje = Fm_Post.Fx_Grabar_Documento(False, csGlobales.Mod_Enum_Listados_Globales.Enum_Tipo_de_Grabacion.Nuevo_documento, False,
                                                           _Mostrar_Mensaje:=False, _ConservaTrazabilidad:=True)
                    Fm_Post.Dispose()

                    ' Validar si grabó correctamente
                    If _Mensaje.EsCorrecto Then
                        Consulta_sql = $"SELECT * FROM MAEEDO WHERE IDMAEEDO = {_Mensaje.Id}"
                        Dim _Docummento As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql, False)

                        _Mensaje.Tag = _Docummento
                    Else
                    End If

                Catch exLoop As Exception
                    _Mensaje.EsCorrecto = False
                    _Mensaje.Mensaje = exLoop.Message
                End Try

                ' Agregamos el resultado de esta clasificación a la lista maestra
                listaMensajes.Add(_Mensaje)
            Next

        Catch ex As Exception
            Dim msgError As New Mensajes With {.EsCorrecto = False, .Detalle = ex.Message}
            listaMensajes.Add(msgError)
        End Try

        Return listaMensajes
    End Function

    Function Asociar_despachos(Nudo As String, Idmaeedo As Integer) As Mensajes
        Dim msg As New Mensajes
        msg.EsCorrecto = False
        msg.Detalle = "Error al asociar despachos y actualizar los documentos relacionados."
        msg.Mensaje = "Error al asociar despachos y actualizar los documentos relacionados."
        Dim SqlQuery As String = $"INSERT INTO {_Global_BaseBk}Zw_Despachos_Doc (
    Id_Despacho, 
    Nro_Despacho, 
    Archidrst, 
    Idrst, 
    Tido, 
    Nudo, 
    CantC, 
    CantD, 
    CantE, 
    CantR, 
    CantDesp, 
    Activo, 
    Nudonodefi, 
    Id_Documentos_Padre, 
    Reasignado
)
SELECT 
    DESP.Id_Despacho,
    DESP.Nro_Despacho,
    DESP.Archidrst,      -- Mantiene 'MAEEDO' del registro base (puedes cambiarlo a 'MAEDDO' si lo requieres)
    MAE2.IDMAEEDO,       -- Nuevo Idrst: IDMAEDDO de cada detalle (MAE2)
    DESP.Tido,
    MAE2.NUDO,           -- Nuevo Nudo: Número de documento de cada detalle
    EDO2.CAPRCO,         -- Nuevo CantC: CAPRCO del documento individual
    DESP.CantD,
    DESP.CantE,
    DESP.CantR,
    DESP.CantDesp,
    1,
    DESP.Nudonodefi,
    DESP.Id_Documentos_Padre,
    DESP.Reasignado
FROM MAEDDO MAE
INNER JOIN MAEDDO MAE2 ON MAE2.IDRST = MAE.IDMAEDDO
INNER JOIN MAEEDO EDO2 ON EDO2.IDMAEEDO = MAE2.IDMAEEDO
CROSS JOIN {_Global_BaseBk}Zw_Despachos_Doc DESP
WHERE MAE.NUDO = '{Nudo}'
  AND DESP.Nudo = '{Nudo}';

Update {_Global_BaseBk}Zw_Despachos_Doc Set Activo = 0 where Nudo = '{Nudo}';"

        Dim SqlQuery_2 = $"INSERT INTO {_Global_BaseBk}Zw_Despachos_Doc_Det (
    [Id_Documentos], 
    [Id_Despacho],
    [Nro_Despacho],
    [Empresa],
    [Sucursal],
    [Bodega],
    [Idmaeedo],
    [Idmaeddo],
    [Tido],
    [Nudo],
    [Codigo],
    [Descripcion],
    [Untrans],
    [UdTrans],
    [Rtu],
    [CantCUd1],
    [CantCUd2],
    [CantDUd1],
    [CantDUd2],
    [CantEUd1],
    [CantEUd2],
    [CantRUd1],
    [CantRUd2],
    [DespUd1],
    [DespUd2],
    [CodFuncionario_Desp],
    [Archirst],
    [Idrst],
    [Activo]
)
SELECT 
    DE.Id_Documentos,
    DET.[Id_Despacho],
    DET.[Nro_Despacho],
    DET.[Empresa],
    DET.[Sucursal],
    DET.[Bodega],
    MAE2.IDMAEEDO,       -- Nuevo Idmaeedo del detalle hijo
    MAE2.IDMAEDDO,       -- Nuevo Idmaeddo del detalle hijo
    DET.[Tido],
    MAE2.NUDO,           -- Nuevo Nudo del detalle hijo
    DET.[Codigo],        -- Mantiene el código original
    DET.[Descripcion],   -- Mantiene la descripción original
    MAE2.UDTRPR,
    DET.[UdTrans],
    MAE2.RLUDPR,
    MAE2.CAPRCO1,        -- Nuevo CantCUd1 
    MAE2.CAPRCO2,        -- Nuevo CantCUd2 
    DET.[CantDUd1],
    DET.[CantDUd2],
    DET.[CantEUd1],
    DET.[CantEUd2],
    DET.[CantRUd1],
    DET.[CantRUd2],
    DET.[DespUd1],
    DET.[DespUd2],
    DET.[CodFuncionario_Desp],
    DET.[Archirst],
    DET.[Idrst],       
    1
FROM MAEDDO MAE
INNER JOIN MAEDDO MAE2 ON MAE2.IDRST = MAE.IDMAEDDO
INNER JOIN [{_Global_BaseBk}]Zw_Despachos_Doc_Det DET ON DET.Idmaeddo = MAE.IDMAEDDO
INNER JOIN [{_Global_BaseBk}]Zw_Despachos_Doc DE on MAE2.IDMAEEDO = DE.Idrst
WHERE MAE.NUDO = '{Nudo}';

Update [{_Global_BaseBk}]Zw_Despachos_Doc_Det set Activo = 0 Where Nudo = '{Nudo}';"


        Dim sqlQuery3 = $"UPDATE Hijo
SET 
    Hijo.HabilitadaFac = Padre.HabilitadaFac,
    Hijo.FunAutorizaFac = Padre.FunAutorizaFac,
    Hijo.FechaHoraAutoriza = Padre.FechaHoraAutoriza,
    Hijo.Estaenwms = Padre.Estaenwms,
    Hijo.Customizable = Padre.Customizable,
    Hijo.PreVenta = Padre.PreVenta,
    Hijo.IdCont = Padre.IdCont,
    Hijo.Contenedor = Padre.Contenedor,
    Hijo.SobreStock = Padre.SobreStock,
    Hijo.PdaRMovil = Padre.PdaRMovil,
    Hijo.Idpdaenca = Padre.Idpdaenca,
    Hijo.Empresa_Ori = Padre.Empresa_Ori,
    Hijo.Idmaeedo_Clon = Padre.Idmaeedo_Clon,
    Hijo.LeyendaMorosidad = Padre.LeyendaMorosidad,
    Hijo.B2B = Padre.B2B,
    Hijo.UsaCiaSeguro = Padre.UsaCiaSeguro,
    Hijo.CodEntidad_Cia = Padre.CodEntidad_Cia,
    Hijo.CodSucEntidad_Cia = Padre.CodSucEntidad_Cia,
    Hijo.Cn_TipoCompra = Padre.Cn_TipoCompra,
    Hijo.TipoCompra = Padre.TipoCompra,
    Hijo.Id_Despacho = Padre.Id_Despacho,
    Hijo.Id_Enc_InterStock = Padre.Id_Enc_InterStock,
    Hijo.Venta_Feria = Padre.Venta_Feria,
    Hijo.Id_Feria = Padre.Id_Feria,
    Hijo.TipoCarga = Padre.TipoCarga
FROM {_Global_BaseBk}Zw_Docu_Ent Hijo
CROSS JOIN (
    SELECT * 
    FROM [{_Global_BaseBk}]Zw_Docu_Ent 
    WHERE Idmaeedo ={Idmaeedo}
) Padre
WHERE Hijo.Idmaeedo IN (
    SELECT MAE2.IDMAEEDO 
    FROM MAEDDO MAE 
    INNER JOIN MAEDDO MAE2 ON MAE2.IDRST = MAE.IDMAEDDO 
    WHERE MAE.IDMAEEDO = {Idmaeedo}
);"

        Dim SqlQuery4 = $"INSERT INTO {_Global_BaseBk}Zw_Docu_Det (
    Idmaeddo, 
    Idmaeedo, 
    Tido, 
    Nudo, 
    Codigo, 
    Descripcion, 
    RtuVariable, 
    Empresa, 
    Sucursal, 
    Bodega, 
    IdCont, 
    Contenedor, 
    Grupo, 
    SobreStock, 
    Id_SobreStock, 
    Moneda_SobreStock, 
    Precio_SobreStock, 
    Qty_SobreStock, 
    Qty_SobreStockD, 
    Qty_SobreStockE, 
    Qty_SobreStockDv, 
    Id_Det_SincroStock, 
    Id_Feria, 
    TipoCarga
)
SELECT 
    MAE_Hijo.IDMAEDDO,       
    MAE_Hijo.IDMAEEDO,       
    MAE_Hijo.TIDO,           
    MAE_Hijo.NUDO,           
    Padre.Codigo,            
    Padre.Descripcion, 
    Padre.RtuVariable, 
    Padre.Empresa, 
    Padre.Sucursal, 
    Padre.Bodega, 
    Padre.IdCont, 
    Padre.Contenedor, 
    Padre.Grupo, 
    Padre.SobreStock, 
    Padre.Id_SobreStock, 
    Padre.Moneda_SobreStock, 
    Padre.Precio_SobreStock, 
    Padre.Qty_SobreStock, 
    Padre.Qty_SobreStockD, 
    Padre.Qty_SobreStockE, 
    Padre.Qty_SobreStockDv, 
    Padre.Id_Det_SincroStock, 
    Padre.Id_Feria, 
    Padre.TipoCarga
FROM MAEDDO MAE_Padre
INNER JOIN MAEDDO MAE_Hijo ON MAE_Hijo.IDRST = MAE_Padre.IDMAEDDO
INNER JOIN {_Global_BaseBk}Zw_Docu_Det Padre ON Padre.Idmaeddo = MAE_Padre.IDMAEDDO
WHERE MAE_Padre.IDMAEEDO = {Idmaeedo};"

        ' Concatenar todas las sentencias en un solo bloque de ejecución
        Dim consultaCompleta As String = SqlQuery & vbCrLf & SqlQuery_2 & vbCrLf & sqlQuery3 & vbCrLf & SqlQuery4

        ' Ejecutar el bloque completo
        Dim result As Boolean = Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(consultaCompleta)

        If Not result Then
            msg.Mensaje = "Error en la transaccion"
            Return msg
        End If
        msg.Mensaje = "Proceso de asociacion de despachos y actualizacion de documentos completado exitosamente."
        msg.EsCorrecto = True
        Return msg
    End Function
End Class




