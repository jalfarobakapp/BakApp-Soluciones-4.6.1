Imports System.Data.SqlClient
Imports System.IO
Imports BkSpecialPrograms
Imports BkSpecialPrograms.Bk_GenDoc2DTE
Imports BkSpecialPrograms.LsValiciones
Imports Newtonsoft.Json

Public Class Cl_ProcesaDatos
    Dim _SqlRandom As Class_SQL
    Dim Consulta_sql As String
    Public Property DirectorioActual As String
    Public Property NombreArchivo_Configuracion As String
    Public Property Configuracion As Configuracion
    Public Sub New()
        ' Ahora solo necesitamos conectarnos a la base de datos de Random/Bakapp
        _SqlRandom = New Class_SQL(Cadena_ConexionSQL_Server)
    End Sub

    '' <summary>
    '' Busca NVVs de Shopify/B2B y las inyecta a las tablas de despacho de Bakapp.
    '' </summary>
    Sub Sb_Procesar_Despachos_ECommerce(Txt_Log As Object)
        Try
            _SqlRandom = New Class_SQL(Cadena_ConexionSQL_Server)
            '-----------------------------------------------------------------------------------------
            '1. BUSCAR NOTAS DE VENTA (NVV) DEL E-COMMERCE QUE NO TENGAN DESPACHO ASIGNADO
            Consulta_sql = $"SELECT TOP 10
    e.IDMAEEDO, e.TIDO, e.NUDO, e.ENDO, e.SUENDO,
    m.NOKOEN, m.PAEN, m.CIEN, m.CMEN,
    e.EMPRESA, e.SUDO,
    o.OBDO, e.CAPRCO, o.OCDO,
    o.TEXTO1, o.TEXTO2, o.TEXTO3,
    d.BOSULIDO AS 'Bodega',
    e.KOFUDO As 'Funcionario',
    e.VABRDO  As 'Valor',
    Isnull(ce.IDMAEDPCE,0) AS 'IDMAEDPCE',
    Isnull(ce.REFANTI,'') As 'REFANTI',
    Isnull(ce.VADP,0) As 'VADP',
    Case When Isnull(ce.VADP,0) >= e.VABRDO Then 1 Else 0 End As 'PagoSuficiente'
FROM MAEEDO e
INNER JOIN MAEEDOOB o 
    ON e.IDMAEEDO = o.IDMAEEDO
INNER JOIN MAEEN m 
    ON e.ENDO = m.KOEN 
   AND e.SUENDO = m.SUEN
CROSS APPLY (
    SELECT TOP 1 BOSULIDO
    FROM MAEDDO
    WHERE IDMAEEDO = e.IDMAEEDO
    ORDER BY IDMAEDDO -- asegura la primera línea del detalle
) d
LEFT JOIN MAEDPCE ce On ce.ARCHIRSD = 'MAEEDO' And ce.IDRSD = e.IDMAEEDO
WHERE e.TIDO = 'NVV'
  AND e.NUDO LIKE 'B2B%'
  AND NOT EXISTS (
        SELECT 1
        FROM {Frm_Sincronizador._Global_BaseBk}Zw_Docu_Ent z
        WHERE z.Idmaeedo = e.IDMAEEDO
  )
          AND e.IDMAEEDO In (976810,976811)
        "

            Dim _Tbl_Pendientes As DataTable = _SqlRandom.Fx_Get_DataTable(Consulta_sql, False)

            If Not String.IsNullOrEmpty(_SqlRandom.Pro_Error) Then
                Sb_AddToLog("Demonio Despachos", $"Error al consultar la base de datos: {_SqlRandom.Pro_Error}", Txt_Log)
                Return
            End If

            ' --- AQUÍ ESTÁ LA CORRECCIÓN CLAVE ---
            ' 1. Validamos si el objeto es nulo (Pasa cuando se pierde la conexión a la BD)

            ' 2. Si no es nulo, validamos si viene vacío
            If _Tbl_Pendientes.Rows.Count = 0 Then
                Sb_AddToLog("Demonio Despachos", "No se encontraron NVVs pendientes", Txt_Log)

                ' No hay nada nuevo que despachar
                Return
            End If
            ' -------------------------------------

            Sb_AddToLog("Demonio Despachos", "Se encontraron " & _Tbl_Pendientes.Rows.Count & " NVVs pendientes.", Txt_Log)

            ' -----------------------------------------------------------------------------------------
            ' 2. PASAR LOS DATOS DEL DATATABLE A LA LISTA DE OBJETOS
            ' -----------------------------------------------------------------------------------------
            Dim listaRespuestas As New List(Of RespuestaSQL)()

            For Each row As DataRow In _Tbl_Pendientes.Rows
                Try
                    Dim respuesta As New RespuestaSQL() With {
                         .IDMAEEDO = Convert.ToInt32(row("IDMAEEDO")),
                         .TIDO = row("TIDO").ToString().Trim(),
                         .NUDO = row("NUDO").ToString().Trim(),
                         .ENDO = row("ENDO").ToString().Trim(),
                         .SUENDO = row("SUENDO").ToString().Trim(),
                         .NOKOEN = row("NOKOEN").ToString().Trim(),
                         .PAEN = row("PAEN").ToString().Trim(),
                         .CIEN = row("CIEN").ToString().Trim(),
                         .CMEN = row("CMEN").ToString().Trim(),
                         .EMPRESA = row("EMPRESA").ToString().Trim(),
                         .SUDO = row("SUDO").ToString().Trim(),
                         .OBDO = row("OBDO").ToString().Trim(),
                         .CAPRCO = If(IsDBNull(row("CAPRCO")), 0D, Convert.ToDecimal(row("CAPRCO"))),
                         .OCDO = row("OCDO").ToString().Trim(),
                         .TEXTO1 = row("TEXTO1").ToString().Trim(),
                         .TEXTO2 = row("TEXTO2").ToString().Trim(),
                         .TEXTO3 = row("TEXTO3").ToString().Trim(),
                         .CodFuncionario = row("Funcionario").ToString().Trim(),
                         .Bodega = row("Bodega").ToString().Trim(),
                         .Valor = Convert.ToInt32(row("Valor")),
                         .IDMAEDPCE = Convert.ToInt32(row("IDMAEDPCE")),
                         .REFANTI = row("REFANTI").ToString().Trim(),
                         .VADP = Convert.ToDecimal(row("VADP")),
                         .PagoSuficiente = Convert.ToInt32(row("PagoSuficiente"))
                    }
                    listaRespuestas.Add(respuesta)
                Catch exRow As Exception
                    ' Si falla la conversión de UNA fila, lo logueamos pero seguimos con la siguiente
                    Sb_AddToLog("Demonio Despachos", $"Error al mapear la fila NVV (ID: {row("IDMAEEDO")}). Error: {exRow.Message}", Txt_Log)
                End Try
            Next

            ' -----------------------------------------------------------------------------------------
            ' 3. PROCESAR CADA DOCUMENTO INDIVIDUALMENTE
            ' -----------------------------------------------------------------------------------------
            For Each NVV As RespuestaSQL In listaRespuestas
                Try
                    Dim numeroDocumento As String = NVV.NUDO
                    Dim correoCliente As String = NVV.TEXTO3
                    Dim idMaeedo As Integer = NVV.IDMAEEDO

                    Sb_Insertar_Log_Gestiones(NVV, $"Procesando documento: {numeroDocumento} (ID: {idMaeedo})")
                    Sb_AddToLog("Demonio Despachos", $"Procesando documento: {numeroDocumento} (ID: {idMaeedo})", Txt_Log)

                    Dim Respuesta_Tr As LsValiciones.Mensajes = Fx_Transaccion(Txt_Log, NVV)

                    ' Validamos el resultado
                    If Respuesta_Tr.EsCorrecto Then
                        Sb_Insertar_Log_Gestiones(NVV, $"El documento {numeroDocumento} fue procesado e insertado correctamente en el módulo de despachos.")
                        Sb_AddToLog("Demonio Despachos", $"El documento {numeroDocumento} fue procesado e insertado correctamente en el módulo de despachos.", Txt_Log)

                        Dim _Cl_Stmp As New Cl_Stmp
                        Dim _FechaParaFacturar As DateTime = DateTime.Now.AddDays(1)
                        Dim _Mensaje_Stem As New LsValiciones.Mensajes

                        ' Validamos si el pago fue suficiente (1)
                        If NVV.PagoSuficiente = 1 Then
                            Sb_Insertar_Log_Gestiones(NVV, $"Iniciando la creación del ticket para enviar el documento {NVV.NUDO} (Pago validado).")
                            Sb_AddToLog("Demonio Despachos", $"Iniciando la creación del ticket para enviar el documento {NVV.NUDO} (Pago validado).", Txt_Log)

                            _Mensaje_Stem = _Cl_Stmp.Fx_Crear_Ticket(NVV.IDMAEEDO, NVV.TIDO, NVV.NUDO, True, _FechaParaFacturar, "R", False, NVV.EMPRESA, NVV.SUENDO, NVV.CodFuncionario, True, NVV.IDMAEDPCE, NVV.CodFuncionario)

                            If _Mensaje_Stem.EsCorrecto Then
                                If NVV.EMPRESA = "02" Then
                                    Sb_AddToLog("Demonio Despachos", $"se cambia momentaneamente la empresa para el documento {NVV.NUDO}!", Txt_Log)
                                    Dim mensajeCambio As New LsValiciones.Mensajes
                                    mensajeCambio = Fx_CambiarBodegaSeaGarden2MeatGarden(NVV.IDMAEEDO)
                                    If mensajeCambio.EsCorrecto Then
                                        Sb_Insertar_Log_Gestiones(NVV, $"La empresa del documento {NVV.NUDO} fue cambiada exitosamente a MeatGarden.")
                                        Sb_AddToLog("Demonio Despachos", $"La empresa del documento {NVV.NUDO} fue cambiada exitosamente a MeatGarden.", Txt_Log)
                                    Else
                                        Sb_Insertar_Log_Gestiones(NVV, $"Error cambiando empresa: detalle : {mensajeCambio.Detalle} - {mensajeCambio.Mensaje}.")
                                        Sb_AddToLog("Demonio Despachos", $"Error cambiando empresa: detalle : {mensajeCambio.Detalle} - {mensajeCambio.Mensaje}.", Txt_Log)
                                    End If

                                End If
                                Sb_Insertar_Log_Gestiones(NVV, $"El ticket de entrega de mercadería fue generado exitosamente para el documento {NVV.NUDO}")

                                Sb_AddToLog("Demonio Despachos", $"El ticket de entrega de mercadería fue generado exitosamente para el documento {NVV.NUDO}!", Txt_Log)
                            Else
                                Sb_Insertar_Log_Gestiones(NVV, $"Error al crear ticket para el documento {NVV.NUDO}. Detalle: {_Mensaje_Stem.Detalle} - {_Mensaje_Stem.Mensaje}")
                                Sb_AddToLog("Demonio Despachos", $"Error al crear ticket para el documento {NVV.NUDO}. Detalle: {_Mensaje_Stem.Detalle} - {_Mensaje_Stem.Mensaje}", Txt_Log)
                            End If
                        Else
                            Sb_Insertar_Log_Gestiones(NVV, $"Se omite la creación de ticket para el documento {NVV.NUDO} porque el pago registrado no cubre el total o no existe.")
                            Sb_AddToLog("Demonio Despachos", $"Se omite la creación de ticket para el documento {NVV.NUDO} porque el pago registrado no cubre el total o no existe.", Txt_Log)
                        End If
                    Else
                        ' Si falló la transacción SQL interna
                        Sb_Insertar_Log_Gestiones(NVV, $"Error al procesar documento {numeroDocumento}. Razón: {Respuesta_Tr.Detalle} - {Respuesta_Tr.Mensaje}")
                        Sb_AddToLog("Demonio Despachos", $"Error al procesar documento {numeroDocumento}. Razón: {Respuesta_Tr.Detalle} - {Respuesta_Tr.Mensaje}", Txt_Log)
                    End If

                Catch exDoc As Exception
                    ' ESTO ES CRÍTICO: Si falla UN documento por cualquier error de código, lo atrapamos aquí
                    ' Dejamos un registro y el FOR EACH continuará con el siguiente documento.
                    Sb_AddToLog("Demonio Despachos", $"EXCEPCIÓN CRÍTICA procesando NVV {NVV.NUDO}: {exDoc.Message}", Txt_Log)
                    Sb_Insertar_Log_Gestiones(NVV, $"Excepción de código al intentar procesar: {exDoc.Message}")
                End Try
            Next

        Catch exGeneral As Exception
            ' Si falla la consulta a BD principal, o cualquier cosa fuera del bucle, atrapamos la caída total.
            Sb_AddToLog("Demonio Despachos", $"Fallo general o de conexión en Sb_Procesar_Despachos_ECommerce: {exGeneral.Message}", Txt_Log)
        End Try
    End Sub
    Public Sub PreCarga(Txt_Log As Object)
        'PreCarga cargar las notas de venta  que quedaron excluidas de pickeo
        Try
            _SqlRandom = New Class_SQL(Cadena_ConexionSQL_Server)
            '-----------------------------------------------------------------------------------------
            '1. BUSCAR NOTAS DE VENTA (NVV) DEL E-COMMERCE QUE NO TENGAN DESPACHO ASIGNADO
            Consulta_sql = $"SELECT TOP 200
    e.IDMAEEDO, e.TIDO, e.NUDO, e.ENDO, e.SUENDO,
    m.NOKOEN, m.PAEN, m.CIEN, m.CMEN,
    e.EMPRESA, e.SUDO,
    o.OBDO, e.CAPRCO, o.OCDO,
    o.TEXTO1, o.TEXTO2, o.TEXTO3,
    d.BOSULIDO AS 'Bodega',
    e.KOFUDO As 'Funcionario',
    e.VABRDO As 'Valor',
    Isnull(ce.IDMAEDPCE,0) AS 'IDMAEDPCE',
    Isnull(ce.REFANTI,'') As 'REFANTI',
    Isnull(ce.VADP,0) As 'VADP',
    Case When Isnull(ce.VADP,0) >= e.VABRDO Then 1 Else 0 End As 'PagoSuficiente'
FROM MAEEDO e
INNER JOIN MAEEDOOB o 
    ON e.IDMAEEDO = o.IDMAEEDO
INNER JOIN MAEEN m 
    ON e.ENDO = m.KOEN 
   AND e.SUENDO = m.SUEN
CROSS APPLY (
    SELECT TOP 1 BOSULIDO
    FROM MAEDDO
    WHERE IDMAEEDO = e.IDMAEEDO
    ORDER BY IDMAEDDO -- asegura la primera línea del detalle
) d
LEFT JOIN MAEDPCE ce On ce.ARCHIRSD = 'MAEEDO' And ce.IDRSD = e.IDMAEEDO
WHERE e.TIDO = 'NVV'
  AND e.NUDO LIKE 'B2B%'
  -- 1. Validamos que exista en la cabecera de entregas y sea B2B
  AND EXISTS (
        SELECT 1
        FROM {Frm_Sincronizador._Global_BaseBk}Zw_Docu_Ent z
        WHERE z.Idmaeedo = e.IDMAEEDO
          AND z.B2B = 1 
  )
  -- 2. Validamos que NO exista el ticket de entrega (Zw_Stmp_Enc)
  AND NOT EXISTS (
        SELECT 1 
        FROM {Frm_Sincronizador._Global_BaseBk}Zw_Stmp_Enc s
        WHERE s.Idmaeedo = e.IDMAEEDO
  )
        AND e.IDMAEEDO In (976810,976811)
        "

            Dim _Tbl_Pendientes As DataTable = _SqlRandom.Fx_Get_DataTable(Consulta_sql, False)

            If Not String.IsNullOrEmpty(_SqlRandom.Pro_Error) Then
                Sb_AddToLog("Demonio Despachos", $"Error al consultar la base de datos: {_SqlRandom.Pro_Error}", Txt_Log)
                Return
            End If

            ' --- AQUÍ ESTÁ LA CORRECCIÓN CLAVE ---
            ' 1. Validamos si el objeto es nulo (Pasa cuando se pierde la conexión a la BD)

            ' 2. Si no es nulo, validamos si viene vacío
            If _Tbl_Pendientes.Rows.Count = 0 Then
                Sb_AddToLog("Demonio Despachos", "No se encontraron NVVs pendientes de mandar a sistema de entrega de mercaderia", Txt_Log)

                ' No hay nada nuevo que despachar
                Return
            End If
            ' -------------------------------------

            Sb_AddToLog("Demonio Despachos", "Se encontraron " & _Tbl_Pendientes.Rows.Count & " NVVs pendientes de pasar a sistema de entrega de mercaderia.", Txt_Log)


            ' -----------------------------------------------------------------------------------------
            ' 2. PASAR LOS DATOS DEL DATATABLE A LA LISTA DE OBJETOS
            ' -----------------------------------------------------------------------------------------
            Dim listaRespuestas As New List(Of RespuestaSQL)()

            For Each row As DataRow In _Tbl_Pendientes.Rows
                Try
                    Dim respuesta As New RespuestaSQL() With {
                         .IDMAEEDO = Convert.ToInt32(row("IDMAEEDO")),
                         .TIDO = row("TIDO").ToString().Trim(),
                         .NUDO = row("NUDO").ToString().Trim(),
                         .ENDO = row("ENDO").ToString().Trim(),
                         .SUENDO = row("SUENDO").ToString().Trim(),
                         .NOKOEN = row("NOKOEN").ToString().Trim(),
                         .PAEN = row("PAEN").ToString().Trim(),
                         .CIEN = row("CIEN").ToString().Trim(),
                         .CMEN = row("CMEN").ToString().Trim(),
                         .EMPRESA = row("EMPRESA").ToString().Trim(),
                         .SUDO = row("SUDO").ToString().Trim(),
                         .OBDO = row("OBDO").ToString().Trim(),
                         .CAPRCO = If(IsDBNull(row("CAPRCO")), 0D, Convert.ToDecimal(row("CAPRCO"))),
                         .OCDO = row("OCDO").ToString().Trim(),
                         .TEXTO1 = row("TEXTO1").ToString().Trim(),
                         .TEXTO2 = row("TEXTO2").ToString().Trim(),
                         .TEXTO3 = row("TEXTO3").ToString().Trim(),
                         .CodFuncionario = row("Funcionario").ToString().Trim(),
                         .Bodega = row("Bodega").ToString().Trim(),
                         .Valor = Convert.ToInt32(row("Valor")),
                         .IDMAEDPCE = Convert.ToInt32(row("IDMAEDPCE")),
                         .REFANTI = row("REFANTI").ToString().Trim(),
                         .VADP = Convert.ToDecimal(row("VADP")),
                         .PagoSuficiente = Convert.ToInt32(row("PagoSuficiente"))
                    }
                    listaRespuestas.Add(respuesta)
                Catch exRow As Exception
                    ' Si falla la conversión de UNA fila, lo logueamos pero seguimos con la siguiente
                    Sb_AddToLog("Demonio Despachos", $"Error al mapear la fila NVV (ID: {row("IDMAEEDO")}). Error: {exRow.Message}", Txt_Log)
                End Try
            Next

            ' -----------------------------------------------------------------------------------------
            ' 3. PROCESAR CADA DOCUMENTO INDIVIDUALMENTE
            ' -----------------------------------------------------------------------------------------
            For Each NVV2 As RespuestaSQL In listaRespuestas
                Try
                    Dim numeroDocumento As String = NVV2.NUDO
                    Dim correoCliente As String = NVV2.TEXTO3
                    Dim idMaeedo As Integer = NVV2.IDMAEEDO

                    Sb_Insertar_Log_Gestiones(NVV2, $"Procesando documento: {numeroDocumento} (ID: {idMaeedo})")
                    Sb_AddToLog("Demonio Despachos", $"Procesando documento: {numeroDocumento} (ID: {idMaeedo})", Txt_Log)
                    ' Validamos el resultado

                    Dim _Cl_Stmp As New Cl_Stmp
                    Dim _FechaParaFacturar As DateTime = DateTime.Now.AddDays(1)
                    Dim _Mensaje_Stem As New LsValiciones.Mensajes

                    ' Validamos si el pago fue suficiente (1)
                    If NVV2.PagoSuficiente = 1 Then
                        Sb_Insertar_Log_Gestiones(NVV2, $"Iniciando la creación del ticket para enviar el documento {NVV2.NUDO} (Pago validado).")
                        Sb_AddToLog("Demonio Despachos", $"Iniciando la creación del ticket para enviar el documento {NVV2.NUDO} (Pago validado).", Txt_Log)

                        _Mensaje_Stem = _Cl_Stmp.Fx_Crear_Ticket(NVV2.IDMAEEDO, NVV2.TIDO, NVV2.NUDO, True, _FechaParaFacturar, "R", False, NVV2.EMPRESA, NVV2.SUENDO, NVV2.CodFuncionario, True, NVV2.IDMAEDPCE, NVV2.CodFuncionario)

                        If _Mensaje_Stem.EsCorrecto Then
                            Sb_Insertar_Log_Gestiones(NVV2, $"El ticket de entrega de mercadería fue generado exitosamente para el documento {NVV2.NUDO}")

                            '
                            Sb_AddToLog("Demonio Despachos", $"El ticket de entrega de mercadería fue generado exitosamente para el documento {NVV2.NUDO}!", Txt_Log)
                            Dim mensajeCambio As New LsValiciones.Mensajes
                            mensajeCambio = Fx_CambiarBodegaSeaGarden2MeatGarden(NVV2.IDMAEEDO)
                            If mensajeCambio.EsCorrecto Then
                                Sb_Insertar_Log_Gestiones(NVV2, $"La empresa del documento {NVV2.NUDO} fue cambiada exitosamente a MeatGarden.")
                                Sb_AddToLog("Demonio Despachos", $"La empresa del documento {NVV2.NUDO} fue cambiada exitosamente a MeatGarden.", Txt_Log)
                            Else
                                Sb_Insertar_Log_Gestiones(NVV2, $"Error cambiando empresa: detalle : {mensajeCambio.Detalle} - {mensajeCambio.Mensaje}.")
                                Sb_AddToLog("Demonio Despachos", $"Error cambiando empresa: detalle : {mensajeCambio.Detalle} - {mensajeCambio.Mensaje}.", Txt_Log)
                            End If
                        Else
                            Sb_Insertar_Log_Gestiones(NVV2, $"Error al crear ticket para el documento {NVV2.NUDO}. Detalle: {_Mensaje_Stem.Detalle} - {_Mensaje_Stem.Mensaje}")
                            Sb_AddToLog("Demonio Despachos", $"Error al crear ticket para el documento {NVV2.NUDO}. Detalle: {_Mensaje_Stem.Detalle} - {_Mensaje_Stem.Mensaje}", Txt_Log)
                        End If
                    Else
                        Sb_Insertar_Log_Gestiones(NVV2, $"Se omite la creación de ticket para el documento {NVV2.NUDO} porque el pago registrado no cubre el total o no existe.")
                        Sb_AddToLog("Demonio Despachos", $"Se omite la creación de ticket para el documento {NVV2.NUDO} porque el pago registrado no cubre el total o no existe.", Txt_Log)
                    End If



                Catch exDoc As Exception
                    ' ESTO ES CRÍTICO: Si falla UN documento por cualquier error de código, lo atrapamos aquí
                    ' Dejamos un registro y el FOR EACH continuará con el siguiente documento.
                    Sb_AddToLog("Demonio Despachos", $"EXCEPCIÓN CRÍTICA procesando NVV {NVV2.NUDO}: {exDoc.Message}", Txt_Log)
                    Sb_Insertar_Log_Gestiones(NVV2, $"Excepción de código al intentar procesar: {exDoc.Message}")
                End Try
            Next



        Catch exGeneral As Exception
            ' Si falla la consulta a BD principal, o cualquier cosa fuera del bucle, atrapamos la caída total.
            Sb_AddToLog("Demonio Despachos", $"Fallo general o de conexión en Sb_Procesar_Despachos_ECommerce: {exGeneral.Message}", Txt_Log)
        End Try



    End Sub
    Private Function Fx_Transaccion(Txt_Log As Object, NVV As RespuestaSQL) As LsValiciones.Mensajes
        Dim _Mensaje As New LsValiciones.Mensajes
        Dim Msg As New LsValiciones.Mensajes
        Dim Mis_Consultas As New List(Of String)
        Dim MiDetalle As New List(Of RespuestaDetalle)
        Dim _NombreEquipo As String = Environment.MachineName

        Dim Consulta_Insert As String = $"
            INSERT INTO {Frm_Sincronizador._Global_BaseBk}Zw_Docu_Ent
                       ([Idmaeedo]
                       ,[NombreEquipo]
                       ,[TipoEstacion]
                       ,[Empresa]
                       ,[Modalidad]
                       ,[Tido]
                       ,[Nudo]
                       ,[FechaHoraGrab]
                       ,[HabilitadaFac]
                       ,[FunAutorizaFac]
                       ,[FechaHoraAutoriza]
                       ,[Pickear]
                       ,[Estaenwms]
                       ,[Customizable]
                       ,[PreVenta]
                       ,[IdCont]
                       ,[Contenedor]
                       ,[SobreStock]
                       ,[PdaRMovil]
                       ,[Idpdaenca]
                       ,[Empresa_Ori]
                       ,[Idmaeedo_Clon]
                       ,[LeyendaMorosidad]
                       ,[B2B])
                 VALUES
                       ({NVV.IDMAEEDO}              -- Idmaeedo
                       ,'{_NombreEquipo}'           -- NombreEquipo
                       ,'B2B'                          -- TipoEstacion
                       ,'{NVV.EMPRESA}'             -- Empresa
                       ,'WEB'                       -- Modalidad
                       ,'{NVV.TIDO}'                -- Tido
                       ,'{NVV.NUDO}'                -- Nudo
                       ,GETDATE()                   -- FechaHoraGrab (Función SQL nativa)
                       ,1                           -- HabilitadaFac
                       ,'{NVV.CodFuncionario}'                                          -- FunAutorizaFac
                       ,NULL                        -- FechaHoraAutoriza
                       ,1                           -- Pickear
                       ,0                           -- Estaenwms
                       ,0                           -- Customizable
                       ,0                           -- PreVenta
                       ,0                           -- IdCont
                       ,''                          -- Contenedor
                       ,0                           -- SobreStock
                       ,0                           -- PdaRMovil
                       ,0                           -- Idpdaenca
                       ,'{NVV.EMPRESA}'                            -- Empresa_Ori
                       ,0                           -- Idmaeedo_Clon
                       ,''                          -- LeyendaMorosidad
                       ,1);"

        Mis_Consultas.Add(Consulta_Insert)

        Msg = Fx_Traer_Detalle(NVV.IDMAEEDO, Txt_Log) ' PASÉ Txt_Log PARA REGISTRAR ERRORES INTERNOS
        If Msg.EsCorrecto Then
            MiDetalle = CType(Msg.Tag, List(Of RespuestaDetalle))
        Else
            Sb_AddToLog("Demonio Despachos", $"Error al traer detalle para documento: {NVV.NUDO} (ID: {NVV.IDMAEEDO}). Detalle: {Msg.Detalle}", Txt_Log)
            Return Msg
        End If

        For Each det As RespuestaDetalle In MiDetalle
            Dim descripcionLimpia As String = det.Descripcion.Replace("'", "''")

            Dim Consulta_Insert_Det As String = $"
            INSERT INTO {Frm_Sincronizador._Global_BaseBk}Zw_Docu_Det
                       ([Idmaeddo]
                       ,[Idmaeedo]
                       ,[Tido]
                       ,[Nudo]
                       ,[Codigo]
                       ,[Descripcion]
                       ,[RtuVariable]
                       ,[Empresa]
                       ,[Sucursal]
                       ,[Bodega]
                       ,[IdCont]
                       ,[Contenedor]
                       ,[Grupo]
                       ,[SobreStock]
                       ,[Id_SobreStock]
                       ,[Moneda_SobreStock]
                       ,[Precio_SobreStock]
                       ,[Qty_SobreStock]
                       ,[Qty_SobreStockD]
                       ,[Qty_SobreStockE]
                       ,[Qty_SobreStockDv])
                 VALUES
                       ({det.Idmaeddo}               -- Idmaeddo
                       ,{det.Idameedo}               -- Idmaeedo
                       ,'{det.Tido}'                 -- Tido
                       ,'{det.Nudo}'                 -- Nudo
                       ,'{det.Codigo}'               -- Codigo
                       ,'{descripcionLimpia}'        -- Descripcion
                       ,0                            -- RtuVariable (Forzado a 0)
                       ,'{det.Empresa}'              -- Empresa
                       ,'{det.Sucursal}'             -- Sucursal
                       ,'{det.Bodega}'               -- Bodega
                       ,0                            -- IdCont
                       ,''                           -- Contenedor
                       ,''                           -- Grupo
                       ,0                            -- SobreStock
                       ,0                            -- Id_SobreStock
                       ,''                           -- Moneda_SobreStock
                       ,0                            -- Precio_SobreStock
                       ,0                            -- Qty_SobreStock
                       ,0                            -- Qty_SobreStockD
                       ,0                            -- Qty_SobreStockE
                       ,0);"
            Mis_Consultas.Add(Consulta_Insert_Det)
        Next

        Dim _Tipo_Despacho As String = ""
        Dim _Direccion As String = ""
        Dim _Comuna As String = ""
        Dim _Ciudad As String = ""
        Dim _Pais As String = ""

        Dim ObdoLimpio As String = ""
        If Not String.IsNullOrEmpty(NVV.OBDO) Then
            ObdoLimpio = NVV.OBDO.Trim()
        End If
        Dim _Trans As String

        If ObdoLimpio.Replace(" ", "").Contains("Direccióndeenvío:,,,") Then
            _Tipo_Despacho = "RT"
            _Trans = ""
        Else
            _Tipo_Despacho = "DD"
            _Trans = "SEAGARDEN"
            Dim prefijo As String = "Dirección de envío:"
            Dim datosUbicacion As String = ObdoLimpio

            If datosUbicacion.StartsWith(prefijo, StringComparison.OrdinalIgnoreCase) Then
                datosUbicacion = datosUbicacion.Substring(prefijo.Length).Trim()
            End If

            Dim partes() As String = datosUbicacion.Split(","c)
            If partes.Length > 0 Then _Direccion = partes(0).Trim().ToUpper().Replace("'", "''")
            If partes.Length > 1 Then _Comuna = partes(1).Trim().ToUpper().Replace("'", "''")
            If partes.Length > 2 Then _Ciudad = partes(2).Trim().ToUpper().Replace("'", "''")
            If partes.Length > 3 Then _Pais = partes(3).Trim().ToUpper().Replace("'", "''")
        End If

        Try
            Dim Consulta_Ultimo_Despacho As String = $"
                SELECT MAX(CAST(Nro_Despacho AS INT)) AS UltimoNro 
                FROM {Frm_Sincronizador._Global_BaseBk}Zw_Despachos 
                WHERE Nro_Despacho NOT LIKE 'P%' 
                  AND ISNUMERIC(Nro_Despacho) = 1"

            Dim Tbl_UltimoNro As DataTable = _SqlRandom.Fx_Get_DataTable(Consulta_Ultimo_Despacho, False)
            If Not String.IsNullOrEmpty(_SqlRandom.Pro_Error) Then

                _Mensaje.EsCorrecto = False
                _Mensaje.Detalle = "Error de preparación de consultas."
                _Mensaje.Mensaje = $"Demonio Despachos Error al consultar la base de datos: {_SqlRandom.Pro_Error}"
                Return _Mensaje
            End If
            Dim _Nro_Despacho As String = "0000000001"

            If Tbl_UltimoNro IsNot Nothing AndAlso Tbl_UltimoNro.Rows.Count > 0 Then
                Dim rowNro = Tbl_UltimoNro.Rows(0)("UltimoNro")
                If Not IsDBNull(rowNro) Then
                    Dim SiguienteNro As Integer = Convert.ToInt32(rowNro) + 1
                    _Nro_Despacho = SiguienteNro.ToString("D10")
                End If
            End If

            Dim _RUT As String = NVV.ENDO
            Dim _dIGITO As String = RutDigito(_RUT)
            _RUT = FormatNumber(_RUT, 0) & "-" & _dIGITO
            _RUT = _RUT.Replace(",", ".")

            Dim Consulta_Insert_Despachos As String = $"
                INSERT INTO {Frm_Sincronizador._Global_BaseBk}Zw_Despachos
                           ([Id_Despacho_Padre]
                           ,[Nro_Despacho]
                           ,[Nro_Sub]
                           ,[Empresa]
                           ,[Sucursal]
                           ,[Bodega]
                           ,[Confirmado]
                           ,[CodFuncionario]
                           ,[Fecha_Emision]
                           ,[Fecha_Compromiso]
                           ,[Fecha_Despacho]
                           ,[Fecha_Cierre]
                           ,[Tipo_Despacho]
                           ,[Tipo_Envio]
                           ,[Tipo_Venta]
                           ,[Estado]
                           ,[Referencia]
                           ,[CodEntidad]
                           ,[CodSucEntidad]
                           ,[Rut]
                           ,[Nombre_Entidad]
                           ,[Pais]
                           ,[Ciudad]
                           ,[Comuna]
                           ,[Direccion]
                           ,[Telefono]
                           ,[Email]
                           ,[Transportista]
                           ,[Transpor_Por_Pagar]
                           ,[Entregar_Con_Doc_Pagados]
                           ,[Tipo_Entrega]
                           ,[Fecha_Entrega_Transpor]
                           ,[CodFuncionario_Transpor]
                           ,[Entregado_Por]
                           ,[Nombre_Transpor]
                           ,[Nro_Encomienda]
                           ,[Observaciones]
                           ,[Sucursal_Retiro]
                           ,[CodPais]
                           ,[CodCiudad]
                           ,[CodComuna]
                           ,[Nombre_Contacto]
                           ,[EntregaPaletizada])
                     VALUES
                           (0                            -- Id_Despacho_Padre
                           ,'{_Nro_Despacho}'            -- Nro_Despacho
                           ,'000'                        -- Nro_Sub
                           ,'{NVV.EMPRESA}'              -- Empresa
                           ,'{NVV.SUDO}'                -- Sucursal 
                           ,'{NVV.Bodega}'              -- Bodega 
                           ,0                            -- Confirmado
                           ,'{NVV.CodFuncionario}'                               -- CodFuncionario
                           ,GETDATE()                    -- Fecha_Emision
                           ,GETDATE() + 1 -- Fecha_Compromiso
                           ,NULL                         -- Fecha_Despacho
                           ,NULL                         -- Fecha_Cierre
                           ,'CLI'            -- Tipo_Despacho
                           ,'{_Tipo_Despacho}'                                           -- Tipo_Envio
                           ,'0001'                           -- Tipo_Venta
                           ,'ING'                           -- Estado
                           ,''                 -- Referencia 
                           ,'{NVV.ENDO}'                 -- CodEntidad
                           ,''               -- CodSucEntidad
                           ,'{_RUT}'                 -- Rut 
                           ,'{NVV.NOKOEN}'                                           -- Nombre_Entidad
                           ,'{_Pais}'                    -- Pais
                           ,'{_Ciudad}'                  -- Ciudad
                           ,'{_Comuna}'                  -- Comuna
                           ,'{_Direccion}'               -- Direccion
                           ,'{NVV.TEXTO2 }'                      -- Telefono
                           ,'{NVV.TEXTO3}'                       -- Email
                           ,'{_Trans}'                           -- Transportista
                           ,0                            -- Transpor_Por_Pagar
                           ,0                            -- Entregar_Con_Doc_Pagados
                           ,''                           -- Tipo_Entrega
                           ,NULL                         -- Fecha_Entrega_Transpor
                           ,''                           -- CodFuncionario_Transpor
                           ,''                           -- Entregado_Por
                           ,''                           -- Nombre_Transpor
                           ,''                           -- Nro_Encomienda
                           ,'B2B'                            -- Observaciones
                           ,''                           -- Sucursal_Retiro
                           ,'{NVV.PAEN}'                           -- CodPais
                           ,'{NVV.CIEN}'                           -- CodCiudad
                           ,'{NVV.CMEN}'                           -- CodComuna
                           ,''                           -- Nombre_Contacto
                           ,0);"

            Mis_Consultas.Add(Consulta_Insert_Despachos)

            Dim Consulta_Insert_Despachos_Doc As String = $"
          INSERT INTO {Frm_Sincronizador._Global_BaseBk}Zw_Despachos_Doc
                     ([Id_Despacho]
                     ,[Nro_Despacho]
                     ,[Archidrst]
                     ,[Idrst]
                     ,[Tido]
                     ,[Nudo]
                     ,[CantC]
                     ,[CantD]
                     ,[CantE]
                     ,[CantR]
                     ,[CantDesp]
                     ,[Activo]
                     ,[Nudonodefi]
                     ,[Id_Documentos_Padre]
                     ,[Reasignado])
               SELECT Id_Despacho                                  -- Id_Despacho (Rescatado de la tabla)
                     ,Nro_Despacho                                 -- Nro_Despacho (Rescatado de la tabla)
                     ,'MAEEDO'                                     -- Archidrst
                     ,{NVV.IDMAEEDO}                               -- Idrst
                     ,'{NVV.TIDO}'                                 -- Tido
                     ,'{NVV.NUDO}'                                 -- Nudo
                     ,{NVV.CAPRCO.ToString().Replace(",", ".")}    -- CantC
                     ,0                                            -- CantD
                     ,0                                            -- CantE
                     ,{NVV.CAPRCO.ToString().Replace(",", ".")}                                               -- CantR
                     ,0                                            -- CantDesp
                     ,1                                            -- Activo
                     ,0                                            -- Nudonodefi
                     ,0                                            -- Id_Documentos_Padre
                     ,0                                            -- Reasignado
               FROM {Frm_Sincronizador._Global_BaseBk}Zw_Despachos
               WHERE Nro_Despacho = '{_Nro_Despacho}' 
                 AND Empresa = '{NVV.EMPRESA}';"
            Mis_Consultas.Add(Consulta_Insert_Despachos_Doc)

            For Each det As RespuestaDetalle In MiDetalle
                Dim descripcionLimpia As String = det.Descripcion.Replace("'", "''")
                Dim Consulta_Insert_Despachos_Doc_Det As String = $"
                    INSERT INTO {Frm_Sincronizador._Global_BaseBk}Zw_Despachos_Doc_Det
                               ([Id_Documentos]
                               ,[Id_Despacho]
                               ,[Nro_Despacho]
                               ,[Empresa]
                               ,[Sucursal]
                               ,[Bodega]
                               ,[Idmaeedo]
                               ,[Idmaeddo]
                               ,[Tido]
                               ,[Nudo]
                               ,[Codigo]
                               ,[Descripcion]
                               ,[Untrans]
                               ,[UdTrans]
                               ,[Rtu]
                               ,[CantCUd1]
                               ,[CantCUd2]
                               ,[CantDUd1]
                               ,[CantDUd2]
                               ,[CantEUd1]
                               ,[CantEUd2]
                               ,[CantRUd1]
                               ,[CantRUd2]
                               ,[DespUd1]
                               ,[DespUd2]
                               ,[CodFuncionario_Desp]
                               ,[Archirst]
                               ,[Idrst]
                               ,[Activo])
                         SELECT Id_Documentos                                -- Id_Documentos
                               ,Id_Despacho                                  -- Id_Despacho
                               ,'{_Nro_Despacho}'                            -- Nro_Despacho
                               ,'{det.Empresa}'                              -- Empresa
                               ,'{det.Sucursal}'                             -- Sucursal
                               ,'{det.Bodega}'                               -- Bodega
                               ,{det.Idameedo}                               -- Idmaeedo
                               ,{det.Idmaeddo}                               -- Idmaeddo
                               ,'{det.Tido}'                                 -- Tido
                               ,'{det.Nudo}'                                 -- Nudo
                               ,'{det.Codigo}'                               -- Codigo
                               ,'{descripcionLimpia}'                        -- Descripcion
                               ,{det.Untrans}                                -- Untrans
                               ,'{det.Udtrans}'                              -- UdTrans
                               ,{det.Rtu.ToString().Replace(",", ".")}       -- Rtu
                               ,{det.CantCUd1.ToString().Replace(",", ".")}  -- CantCUd1
                               ,{det.CantCUd2.ToString().Replace(",", ".")}  -- CantCUd2
                               ,0                                            -- CantDUd1
                               ,0                                            -- CantDUd2
                               ,0                                            -- CantEUd1
                               ,0                                            -- CantEUd2
                               ,0                                            -- CantRUd1
                               ,0                                            -- CantRUd2
                               ,0                                            -- DespUd1
                               ,0                                            -- DespUd2
                               ,''                                           -- CodFuncionario_Desp
                               ,'MAEDDO'                                     -- Archirst
                               ,{det.Idmaeddo}                               -- Idrst
                               ,1                                            -- Activo
                         FROM {Frm_Sincronizador._Global_BaseBk}Zw_Despachos_Doc
                         WHERE Nro_Despacho = '{_Nro_Despacho}';"
                Mis_Consultas.Add(Consulta_Insert_Despachos_Doc_Det)
            Next
        Catch exData As Exception
            _Mensaje.EsCorrecto = False
            _Mensaje.Detalle = "Error de preparación de consultas."
            _Mensaje.Mensaje = exData.Message
            Return _Mensaje
        End Try

        ' =================================================================
        ' EJECUCIÓN TRANSACCIONAL EN SQL SERVER
        ' =================================================================
        Dim myTrans As System.Data.SqlClient.SqlTransaction = Nothing
        Dim Comando As System.Data.SqlClient.SqlCommand
        Dim Cn2 As New System.Data.SqlClient.SqlConnection
        Dim SQL_ServerClass As New Class_SQL(Cadena_ConexionSQL_Server)

        Try
            SQL_ServerClass.Sb_Abrir_Conexion(Cn2)
            myTrans = Cn2.BeginTransaction()

            For Each Consulta As String In Mis_Consultas
                Comando = New System.Data.SqlClient.SqlCommand(Consulta, Cn2)
                Comando.Transaction = myTrans
                Comando.ExecuteNonQuery()
            Next

            myTrans.Commit()
            SQL_ServerClass.Sb_Cerrar_Conexion(Cn2)

            _Mensaje.EsCorrecto = True
            _Mensaje.Detalle = "Transacción completada con éxito."
            _Mensaje.Mensaje = "Se generó el registro y el despacho correctamente."

        Catch ex As Exception
            _Mensaje.EsCorrecto = False
            _Mensaje.Detalle = "Error al grabar la transacción DB"
            _Mensaje.Mensaje = ex.Message
            _Mensaje.Id = 0

            Try
                If Not IsNothing(myTrans) Then myTrans.Rollback()
            Catch exRollback As Exception
                Sb_AddToLog("Demonio Despachos", $"Error al intentar hacer Rollback: {exRollback.Message}", Txt_Log)
            End Try
            SQL_ServerClass.Sb_Cerrar_Conexion(Cn2)

            Sb_AddToLog("Demonio Despachos", $"Error Transaccional: {ex.Message}", Txt_Log)
        End Try

        Return _Mensaje
    End Function

    ' Agregamos el Try Catch aquí también para evitar caídas silenciosas
    Private Function Fx_Traer_Detalle(IDMAEEDO As String, Optional Txt_Log As Object = Nothing) As LsValiciones.Mensajes
        Dim Msg As LsValiciones.Mensajes = New LsValiciones.Mensajes
        Dim listaDetalles As New List(Of RespuestaDetalle)()

        Try
            Consulta_sql = $"Select d.IDMAEEDO As 'Idameedo',d.IDMAEDDO As 'Idmaeddo',d.TIDO As 'Tido',d.NUDO As 'Nudo',d.KOPRCT As 'Codigo',d.NOKOPR As 'Descripcion',Cast(0 As Bit) As 'RtuVariable',d.EMPRESA As 'Empresa',d.SULIDO As 'Sucursal',d.BOSULIDO As 'Bodega',d.UDTRPR As 'Untrans',Case When d.UDTRPR = 1 then d.UD01PR else d.UD01PR End As 'Udtrans',d.RLUDPR As 'Rtu',d.CAPRCO1 As 'CantCUd1',d.CAPRCO2 As 'CantCUd2'
    From MAEDDO d
    Where d.IDMAEEDO = {IDMAEEDO}"
            Dim _Tbl_Pendientes As DataTable = _SqlRandom.Fx_Get_DataTable(Consulta_sql, False)

            If _Tbl_Pendientes IsNot Nothing AndAlso _Tbl_Pendientes.Rows.Count > 0 Then
                For Each row As DataRow In _Tbl_Pendientes.Rows
                    Dim detalle As New RespuestaDetalle()
                    detalle.Idameedo = Convert.ToInt32(row("Idameedo"))
                    detalle.Idmaeddo = Convert.ToInt32(row("Idmaeddo"))
                    detalle.Tido = row("Tido").ToString().Trim()
                    detalle.Nudo = row("Nudo").ToString().Trim()
                    detalle.Codigo = row("Codigo").ToString().Trim()
                    detalle.Descripcion = row("Descripcion").ToString().Trim()
                    detalle.RtuVariable = Convert.ToBoolean(row("RtuVariable"))
                    detalle.Empresa = row("Empresa").ToString().Trim()
                    detalle.Sucursal = row("Sucursal").ToString().Trim()
                    detalle.Bodega = row("Bodega").ToString().Trim()

                    detalle.Untrans = Convert.ToInt32(row("Untrans"))
                    detalle.Udtrans = row("Udtrans").ToString().Trim()
                    detalle.Rtu = Convert.ToDouble(row("Rtu"))
                    detalle.CantCUd1 = Convert.ToDouble(row("CantCUd1"))
                    detalle.CantCUd2 = Convert.ToDouble(row("CantCUd2"))
                    listaDetalles.Add(detalle)
                Next
            Else
                Msg.EsCorrecto = False
                Msg.Mensaje = "No se encontraron detalles para el IDMAEEDO proporcionado."
                Msg.Detalle = "El DataTable está vacío o es nulo."
                Msg.Tag = listaDetalles
                Return Msg
            End If

            Msg.EsCorrecto = True
            Msg.Mensaje = "Se encontro detalle"
            Msg.Tag = listaDetalles
            Return Msg

        Catch ex As Exception
            Msg.EsCorrecto = False
            Msg.Mensaje = "Ocurrió un error inesperado al consultar los detalles de la base de datos."
            Msg.Detalle = ex.Message
            Msg.Tag = listaDetalles

            If Txt_Log IsNot Nothing Then
                Sb_AddToLog("Demonio Despachos", $"Error en Fx_Traer_Detalle (ID: {IDMAEEDO}): {ex.Message}", Txt_Log)
            End If

            Return Msg
        End Try
    End Function

    Public Function Fx_Testear_Conexion(Txt_Log As Object) As Mensajes
        Dim _Mensaje As New Mensajes
        Dim Cn2 As New SqlConnection
        _SqlRandom = New Class_SQL(Cadena_ConexionSQL_Server)

        Try
            Dim Consulta_sql As String = "SELECT 1"
            Dim _Tbl_Prueba As DataTable = _SqlRandom.Fx_Get_DataTable(Consulta_sql)

            If Not IsNothing(_Tbl_Prueba) AndAlso _Tbl_Prueba.Rows.Count > 0 Then
                _Mensaje.EsCorrecto = True
                _Mensaje.Detalle = "tick recibido"
                _Mensaje.Mensaje = "OK."
                Sb_AddToLog("Demonio Shopify", "Tick Correcto: " & _Mensaje.Mensaje, Txt_Log)
                Return _Mensaje
            Else
                _Mensaje.EsCorrecto = True ' Dejaste esto en True, lo mantengo igual.
                _Mensaje.Detalle = "tick recibido"
                _Mensaje.Mensaje = "ERROR."
                Sb_AddToLog("Demonio Shopify", "Tick Incorrecto: " & _Mensaje.Mensaje, Txt_Log)
                Return _Mensaje
            End If

        Catch ex As Exception
            _Mensaje.EsCorrecto = True ' Igual, se mantiene como lo tenías.
            _Mensaje.Detalle = "conexion fallida"
            _Mensaje.Mensaje = "ERROR."
            Sb_AddToLog("Demonio Shopify", "Sin Conexion: " & _Mensaje.Mensaje, Txt_Log)
            Return _Mensaje
        End Try
    End Function

    Private Sub Sb_Insertar_Log_Gestiones(NVV As RespuestaSQL, Texto_Accion As String)
        Dim _AccionLimpia As String = Texto_Accion.Replace("'", "''")
        Dim _NombreEquipo As String = Environment.MachineName

        Dim Consulta_Log As String = $"
            INSERT INTO {Frm_Sincronizador._Global_BaseBk}Zw_Log_Gestiones
                       ([Empresa]
                       ,[NombreEquipo]
                       ,[Funcionario]
                       ,[Modalidad]
                       ,[Archirst]
                       ,[Idrst]
                       ,[Fecha_Hora]
                       ,[CodAccion]
                       ,[Accion]
                       ,[CodPermiso]
                       ,[Kopr]
                       ,[Koen]
                       ,[Suen]
                       ,[Solicitud_Permiso]
                       ,[Funcionario_Autoriza]
                       ,[PermisoRemoto]
                       ,[Id_Rem]
                       ,[NroRemota]
                       ,[Tido]
                       ,[Nudo])
                 VALUES
                       (''              -- Empresa
                       ,'{_NombreEquipo}'             -- NombreEquipo
                       ,'B2B'       -- Funcionario
                       ,'WEB'                    -- Modalidad 
                       ,'MAEEDO'                     -- Archirst 
                       ,{NVV.IDMAEEDO}               -- Idrst
                       ,GETDATE()                    -- Fecha_Hora
                       ,''                   -- CodAccion
                       ,'B2B: {_AccionLimpia}'            -- Accion 
                       ,''                           -- CodPermiso
                       ,''                           -- Kopr
                       ,'{NVV.ENDO}'                 -- Koen
                       ,'{NVV.SUENDO}'               -- Suen
                       ,0                            -- Solicitud_Permiso
                       ,''                           -- Funcionario_Autoriza
                       ,0                            -- PermisoRemoto
                       ,0                            -- Id_Rem
                       ,''                           -- NroRemota
                       ,'{NVV.TIDO}'                 -- Tido
                       ,'{NVV.NUDO}');"

        Dim Cn2 As New System.Data.SqlClient.SqlConnection
        Dim SQL_ServerClass As New Class_SQL(Cadena_ConexionSQL_Server)

        Try
            SQL_ServerClass.Sb_Abrir_Conexion(Cn2)
            Dim Comando As New System.Data.SqlClient.SqlCommand(Consulta_Log, Cn2)
            Comando.ExecuteNonQuery()
            SQL_ServerClass.Sb_Cerrar_Conexion(Cn2)
        Catch ex As Exception
            SQL_ServerClass.Sb_Cerrar_Conexion(Cn2)
            ' Descomentado para asegurarte que si falla esto, también se avise por archivo físico.
            ' Sb_AddToLog("Demonio Despachos", $"Error al insertar log en BD para {NVV.NUDO}: {ex.Message}", Txt_Log)
        End Try
    End Sub



    Public Sub GestionarCorreos(Txt_Log As Object)

        ' PreCarga: Buscar FCV (B2B) para encolar el envío de correos
        Try
            Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
            Dim _Documentos_Enviados As Integer = 0

            ' -----------------------------------------------------------------------------------------
            ' 1. BUSCAR FACTURAS (FCV) B2B DE LOS ÚLTIMOS 7 DÍAS QUE NO ESTÉN EN LA COLA DE CORREOS
            ' -----------------------------------------------------------------------------------------
            Consulta_sql = $"SELECT 
    Z.Id, Z.Idmaeedo, Z.NombreEquipo, Z.TipoEstacion, Z.Empresa, Z.Modalidad, Z.Tido, Z.Nudo, 
    Z.FechaHoraGrab, Z.HabilitadaFac, Z.FunAutorizaFac, Z.FechaHoraAutoriza, Z.Pickear, 
    Z.Estaenwms, Z.Customizable, Z.PreVenta, Z.IdCont, Z.Contenedor, Z.SobreStock, Z.PdaRMovil, 
    Z.Idpdaenca, Z.Empresa_Ori, Z.Idmaeedo_Clon, Z.LeyendaMorosidad, Z.B2B, 
    Isnull(Dsp.Email,'') As 'Email'
FROM {Frm_Sincronizador._Global_BaseBk}Zw_Docu_Ent AS Z
Left join {Frm_Sincronizador._Global_BaseBk}Zw_Despachos_Doc doc on doc.Idrst = Z.Idmaeedo And Z.Tido = doc.Tido And Z.Nudo = doc.Nudo
Left Join {Frm_Sincronizador._Global_BaseBk}Zw_Despachos Dsp on doc.Id_Despacho = Dsp.Id_Despacho
WHERE Z.B2B = 1
  AND Z.Tido = 'FCV'
  AND Z.FechaHoraGrab >= DATEADD(DAY, -7, CAST(GETDATE() AS date))
  AND Z.FechaHoraGrab < DATEADD(DAY, 1, CAST(GETDATE() AS date))
  AND NOT EXISTS (
        SELECT 1
        FROM {Frm_Sincronizador._Global_BaseBk}Zw_Demonio_Doc_Emitidos_Aviso_Correo AS D
        WHERE D.Idmaeedo = Z.Idmaeedo
          AND D.Tido = Z.Tido
          AND D.Nudo = Z.Nudo
          AND D.Id_Dte = 0
  )
ORDER BY Z.Id DESC"

            Dim _Tbl_Pendientes As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql, False)

            If Not String.IsNullOrEmpty(_Sql.Pro_Error) Then
                Sb_AddToLog("Demonio Despachos", $"Error al consultar la base de datos: {_Sql.Pro_Error}", Txt_Log)
                Return
            End If

            If _Tbl_Pendientes Is Nothing OrElse _Tbl_Pendientes.Rows.Count = 0 Then
                Sb_AddToLog("Demonio Despachos", "No se encontraron facturas FCV pendientes para encolar correos.", Txt_Log)
                Return
            End If

            Sb_AddToLog("Demonio Despachos", $"Se encontraron {_Tbl_Pendientes.Rows.Count} facturas para procesar envío de correos.", Txt_Log)

            ' -----------------------------------------------------------------------------------------
            ' 2. CONFIGURACIÓN DEL CORREO 
            ' -----------------------------------------------------------------------------------------




            ' -----------------------------------------------------------------------------------------
            ' 3. PROCESAR CADA DOCUMENTO Y ENCOLARLO
            ' -----------------------------------------------------------------------------------------
            For Each row As DataRow In _Tbl_Pendientes.Rows

                Dim _Idmaeedo As Integer = 0
                Dim _Nudo As String = "Desconocido"

                ' Creamos un objeto de respuesta para satisfacer los parámetros de Sb_Insertar_Log_Gestiones
                Dim _DocLog As New RespuestaSQL()

                Try
                    ' Asignación de variables
                    _Idmaeedo = Convert.ToInt32(row("Idmaeedo"))
                    _Nudo = row("Nudo").ToString().Trim()
                    Dim _Tido As String = row("Tido").ToString().Trim()
                    Dim _EmailDestino As String = row("Email").ToString().Trim()
                    Dim Empresa As String = row("Empresa").ToString().Trim()

                    ' Llenamos el objeto de log para que Sb_Insertar_Log_Gestiones no falle
                    _DocLog.IDMAEEDO = _Idmaeedo
                    _DocLog.NUDO = _Nudo
                    _DocLog.TIDO = _Tido
                    _DocLog.EMPRESA = Empresa

                    Dim _NombreFormato_Correo As String = ""


                    Dim _Nombre_Correo = ""
                    If Empresa = "01" Then
                        _Nombre_Correo = Frm_Sincronizador.Correos.Empresa1_NombreCorreo
                        _NombreFormato_Correo = Frm_Sincronizador.Correos.Empresa1_Formato
                    ElseIf Empresa = "02" Then
                        _Nombre_Correo = Frm_Sincronizador.Correos.Empresa2_NombreCorreo
                        _NombreFormato_Correo = Frm_Sincronizador.Correos.Empresa2_Formato

                    End If
                    Dim _Para_Maeenmail As Boolean = False
                    Dim _Kofudo As String = "B2B"

                    Dim _Asunto As String = ""
                    Dim _CuerpoMensaje As String = ""

                    Consulta_sql = $"SELECT Top 1 * FROM {Frm_Sincronizador._Global_BaseBk}Zw_Correos WHERE Nombre_Correo = '{_Nombre_Correo}'"
                    Dim _Row_Correo As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql, False)

                    If Not String.IsNullOrEmpty(_Sql.Pro_Error) Then
                        Sb_AddToLog("Demonio Despachos", $"Error al buscar la plantilla de correo: {_Sql.Pro_Error}", Txt_Log)
                        Return
                    End If

                    If Not IsNothing(_Row_Correo) Then
                        _Asunto = _Row_Correo.Item("Asunto").ToString()
                        _CuerpoMensaje = _Row_Correo.Item("CuerpoMensaje").ToString().Replace("'", "''")
                    Else
                        Sb_AddToLog("Demonio Despachos", $"ERROR: No se encontró la plantilla '{_Nombre_Correo}'. No se pueden procesar los correos.", Txt_Log)
                        Return
                    End If



                    ' --- LOGS 1: Inicio del proceso ---
                    Sb_AddToLog("Demonio Despachos", $"Encolando documento: {_Nudo} (ID: {_Idmaeedo})", Txt_Log)
                    Sb_Insertar_Log_Gestiones(_DocLog, $"Iniciando encolado de correo para el documento {_Nudo}")

                    ' Armar el INSERT
                    Consulta_sql = $"Insert Into {Frm_Sincronizador._Global_BaseBk}Zw_Demonio_Doc_Emitidos_Aviso_Correo 
                                    (NombreEquipo, Nombre_Correo, CodFuncionario, Asunto, Para, Cc, Idmaeedo, 
                                     Tido, Nudo, NombreFormato, Enviar, Intentos, Enviado, Adjuntar_Documento, Mensaje, Fecha, Para_Maeenmail) 
                                     Select '', '{_Nombre_Correo}', '{_Kofudo}', '{_Asunto}', '{_EmailDestino}', '', IDMAEEDO, TIDO, NUDO, 
                                     '{_NombreFormato_Correo}', 1, 0, 0, 1, '{_CuerpoMensaje}', Getdate(), {Convert.ToInt32(_Para_Maeenmail)} 
                                     From MAEEDO Where IDMAEEDO = {_Idmaeedo}"

                    If _Sql.Ej_consulta_IDU(Consulta_sql, False) Then
                        _Documentos_Enviados += 1

                        ' --- LOGS 2: Éxito ---
                        Sb_AddToLog("Demonio Despachos", $"Documento {_Nudo} encolado exitosamente.", Txt_Log)
                        Sb_Insertar_Log_Gestiones(_DocLog, $"El documento {_Nudo} fue encolado exitosamente en Zw_Demonio_Doc_Emitidos_Aviso_Correo.")
                    Else
                        ' --- LOGS 3: Error de ejecución de SQL ---
                        Sb_AddToLog("Demonio Despachos", $"Error al ejecutar el Insert para el documento {_Nudo}. Detalle: {_Sql.Pro_Error}", Txt_Log)
                        Sb_Insertar_Log_Gestiones(_DocLog, $"Error de base de datos al encolar {_Nudo}. Detalle: {_Sql.Pro_Error}")
                    End If

                Catch exDoc As Exception
                    ' --- LOGS 4: Despachos CRÍTICA (A prueba de errores) ---
                    Sb_AddToLog("Demonio Correos", $"EXCEPCIÓN CRÍTICA procesando FCV {_Nudo}: {exDoc.Message}", Txt_Log)
                    Sb_Insertar_Log_Gestiones(_DocLog, $"Excepción de código al intentar procesar: {exDoc.Message}")
                End Try
            Next

            Sb_AddToLog("Demonio Despachos", $"Proceso finalizado. Total de correos encolados: {_Documentos_Enviados}", Txt_Log)

        Catch exGeneral As Exception
            ' Atrapamos caídas totales del método (como pérdida de conexión a SQL)
            Sb_AddToLog("Demonio Despachos", $"Fallo general en GestionarCorreos: {exGeneral.Message}", Txt_Log)
        End Try

    End Sub
    Function Fx_CambiarBodegaSeaGarden2MeatGarden(_Idmaeedo As Integer) As LsValiciones.Mensajes

        Dim _Mensaje As New LsValiciones.Mensajes
        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
        Try

            Consulta_sql = "Select Top 1 EMPRESA As Empresa, SULIDO As Sucursal, BOSULIDO As Bodega From MAEDDO Where IDMAEEDO = " & _Idmaeedo
            Dim _Row_Maeddo As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

            Dim _Empresa As String
            Dim _Sucursal As String
            Dim _Bodega As String

            If Not IsNothing(_Row_Maeddo) Then

                _Empresa = _Row_Maeddo.Item("Empresa")
                _Sucursal = _Row_Maeddo.Item("Sucursal")
                _Bodega = _Row_Maeddo.Item("Bodega")

                If String.IsNullOrEmpty(_Empresa) Or String.IsNullOrEmpty(_Sucursal) Or String.IsNullOrEmpty(_Bodega) Then
                    _Mensaje.EsCorrecto = False
                    _Mensaje.Mensaje = "No se pudo obtener la empresa, sucursal o bodega de la nota de venta"
                    Return _Mensaje
                End If

            Else

                _Mensaje.EsCorrecto = False
                _Mensaje.Mensaje = "No se encontró información de la nota de venta"
                Return _Mensaje

            End If

            Dim EmpSucBod As String = _Empresa & ";" & _Sucursal & ";" & _Bodega

            Consulta_sql = "Select Tabla, DescripcionTabla, CodigoTabla, NombreTabla" & vbCrLf &
                           "From " & Frm_Sincronizador._Global_BaseBk & "Zw_TablaDeCaracterizaciones" & vbCrLf &
                           "Where Tabla = 'SEA2MEATGARDEN' And NombreTabla = '" & EmpSucBod & "'"
            Dim _Row As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

            If IsNothing(_Row) Then
                _Mensaje.EsCorrecto = False
                _Mensaje.Mensaje = "No se encontró la caracterización para la empresa, sucursal y bodega: " & EmpSucBod
                Return _Mensaje
            End If

            Sb_ClonarNVV(_Idmaeedo)

            Dim _ESB = _Row.Item("CodigoTabla").ToString.Split(";"c)

            _Empresa = _ESB(0).Trim
            _Sucursal = _ESB(1).Trim
            _Bodega = _ESB(2).Trim

            Consulta_sql = "Declare @Idmaeedo Int = " & _Idmaeedo & vbCrLf &
                           "Update MAEEDO Set EMPRESA = '" & _Empresa & "',SUDO = '" & _Sucursal & "' Where IDMAEEDO = @Idmaeedo" & vbCrLf &
                           "Update MAEDDO Set EMPRESA = '" & _Empresa & "',SULIDO = '" & _Sucursal & "',BOSULIDO = '" & _Bodega & "' Where IDMAEEDO = @Idmaeedo" & vbCrLf &
                           "Update " & Frm_Sincronizador._Global_BaseBk & "Zw_Despachos Set Empresa = '" & _Empresa & "',Sucursal = '" & _Sucursal & "',Bodega = '" & _Bodega &
                                "' Where Id_Despacho In (Select Id_Despacho From " & Frm_Sincronizador._Global_BaseBk & "Zw_Despachos_Doc WHERE (Idrst = @Idmaeedo) AND (Archidrst = 'MAEEDO'))" & vbCrLf &
                           "Update " & Frm_Sincronizador._Global_BaseBk & "Zw_Stmp_Enc Set Empresa = '" & _Empresa & "',Sucursal = '" & _Sucursal & "' Where Idmaeedo = @Idmaeedo" & vbCrLf &
                           "Update " & Frm_Sincronizador._Global_BaseBk & "Zw_Docu_Ent Set Empresa_Ori = Empresa Where Idmaeedo = @Idmaeedo" & vbCrLf &
                           "Update " & Frm_Sincronizador._Global_BaseBk & "Zw_Docu_Ent Set Empresa = '" & _Empresa & "' Where Idmaeedo = @Idmaeedo"

            If _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql, False) Then

                ' Toda la lógica del formulario Frm_Consolidacion_Stock_PP fue removida.
                ' El proceso termina exitosamente aquí a nivel de base de datos.

                _Mensaje.EsCorrecto = True
                _Mensaje.Mensaje = "Se cambió la bodega y se clonó la NVV correctamente."

            Else
                _Mensaje.EsCorrecto = False
                _Mensaje.Mensaje = "Ocurrió un error al ejecutar la actualización en la base de datos."
            End If

        Catch ex As Exception
            _Mensaje.EsCorrecto = False
            _Mensaje.Mensaje = "Ocurrió una excepción en el código: " & ex.Message
        End Try

        Return _Mensaje

    End Function
    Sub Sb_ClonarNVV(_Idmaeedo As Integer)
        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)

        Consulta_sql = $"

DECLARE @Idmaeedo INT = {_Idmaeedo};    -- Documento original
DECLARE @New_Idmaeedo INT;              -- Nuevo ID clonado

    ---------------------------------------------------------
    -- 1) CLONAR MAEEDO (ENCABEZADO)
    ---------------------------------------------------------
    INSERT INTO MAEEDO (
        EMPRESA, TIDO, NUDO, ENDO, SUENDO, ENDOFI, TIGEDO, SUDO, LUVTDO, FEEMDO,
        KOFUDO, ESDO, ESPGDO, CAPRCO, CAPRAD, CAPREX, CAPRNC, MEARDO, MODO, TIMODO,
        TAMODO, NUCTAP, VACTDTNEDO, VACTDTBRDO, NUIVDO, POIVDO, VAIVDO, NUIMDO,
        VAIMDO, VANEDO, VABRDO, POPIDO, VAPIDO, FE01VEDO, FEULVEDO, NUVEDO, VAABDO,
        MARCA, FEER, NUTRANSMI, NUCOCO, KOTU, LIBRO, LCLV, ESFADO, KOTRPCVH, NULICO,
        PERIODO, NUDONODEFI, TRANSMASI, POIVARET, VAIVARET, RESUMEN, LAHORA,
        KOFUAUDO, KOOPDO, ESPRODDO, DESPACHO, HORAGRAB, RUTCONTACT, SUBTIDO,
        TIDOELEC, ESDOIMP, CUOGASDIF, BODESTI, PROYECTO, FECHATRIB, NUMOPERVEN,
        BLOQUEAPAG, VALORRET, FLIQUIFCV, VADEIVDO, KOCANAL, KOCRYPT, LEYZONA,
        KOSIFIC, LISACTIVA, KOFUAUTO, SUENDOFI, VAIVDOZF, ENDOMANDA, FLUVTCALZA,
        ARCHIXML, IDXML, SERIENUDO, VALORAJU, PODETRAC, DETRACCION, TIPOOPCOM,
        CREFIYAF, NRODETRAC, IDPDAENCA, TIDEVE, TIDEVEFE, TIDEVEHO, RUTPORTA
    )
    SELECT
        EMPRESA, TIDO, NUDO, ENDO, SUENDO, ENDOFI, TIGEDO, SUDO, LUVTDO, FEEMDO,
        KOFUDO, ESDO, ESPGDO, CAPRCO, CAPRAD, CAPREX, CAPRNC, MEARDO, MODO, TIMODO,
        TAMODO, NUCTAP, VACTDTNEDO, VACTDTBRDO, NUIVDO, POIVDO, VAIVDO, NUIMDO,
        VAIMDO, VANEDO, VABRDO, POPIDO, VAPIDO, FE01VEDO, FEULVEDO, NUVEDO, VAABDO,
        MARCA, FEER, NUTRANSMI, NUCOCO, KOTU, LIBRO, LCLV, ESFADO, KOTRPCVH, NULICO,
        PERIODO, NUDONODEFI, TRANSMASI, POIVARET, VAIVARET, RESUMEN, LAHORA,
        KOFUAUDO, KOOPDO, ESPRODDO, DESPACHO, HORAGRAB, RUTCONTACT, SUBTIDO,
        TIDOELEC, ESDOIMP, CUOGASDIF, BODESTI, PROYECTO, FECHATRIB, NUMOPERVEN,
        BLOQUEAPAG, VALORRET, FLIQUIFCV, VADEIVDO, KOCANAL, 'CLON_'+CAST(@Idmaeedo AS VARCHAR(20)),
        LEYZONA, KOSIFIC, LISACTIVA, KOFUAUTO, SUENDOFI, VAIVDOZF, ENDOMANDA,
        FLUVTCALZA, ARCHIXML, IDXML, SERIENUDO, VALORAJU, PODETRAC, DETRACCION,
        TIPOOPCOM, CREFIYAF, NRODETRAC, IDPDAENCA, TIDEVE, TIDEVEFE, TIDEVEHO, RUTPORTA
    FROM MAEEDO
    WHERE IDMAEEDO = @Idmaeedo;

    SET @New_Idmaeedo = SCOPE_IDENTITY();

    ---------------------------------------------------------
    -- 2) CLONAR MAEDDO (DETALLE) SIN OUTPUT
    ---------------------------------------------------------
    INSERT INTO MAEDDO (
        IDMAEEDO, ARCHIRST, IDRST, EMPRESA, TIDO, NUDO, ENDO, SUENDO, ENDOFI,
        LILG, NULIDO, SULIDO, LUVTLIDO, BOSULIDO, KOFULIDO, NULILG, PRCT, TICT,
        TIPR, NUSEPR, KOPRCT, UDTRPR, RLUDPR, CAPRCO1, CAPRAD1, CAPREX1, CAPRNC1,
        UD01PR, CAPRCO2, CAPRAD2, CAPREX2, CAPRNC2, UD02PR, KOLTPR, MOPPPR,
        TIMOPPPR, TAMOPPPR, PPPRNELT, PPPRNE, PPPRBRLT, PPPRBR, NUDTLI, PODTGLLI,
        VADTNELI, VADTBRLI, POIVLI, VAIVLI, NUIMLI, POIMGLLI, VAIMLI, VANELI,
        VABRLI, TIGELI, EMPREPA, TIDOPA, NUDOPA, ENDOPA, NULIDOPA, LLEVADESP,
        FEEMLI, FEERLI, PPPRPM, OPERACION, CODMAQ, ESLIDO, PPPRNERE1, PPPRNERE2,
        ESFALI, CAFACO, CAFAAD, CAFAEX, CMLIDO, NULOTE, FVENLOTE, ARPROD, NULIPROD,
        NUCOCO, NULICO, PERIODO, FCRELOTE, SUBLOTE, NOKOPR, ALTERNAT, PRENDIDO,
        OBSERVA, KOFUAULIDO, KOOPLIDO, MGLTPR, PPOPPR, TIPOMG, ESPRODLI, CAPRODCO,
        CAPRODAD, CAPRODEX, CAPRODRE, TASADORIG, CUOGASDIF, SEMILLA, PROYECTO,
        POTENCIA, HUMEDAD, IDTABITPRE, IDODDGDV, LINCONDESP, PODEIVLI, VADEIVLI,
        PRIIDETIQ, KOLORESCA, KOENVASE, PPPRPMSUC, PPPRPMIFRS, COSTOTRIB, COSTOIFRS,
        SUENDOFI, COMISION, FLUVTCALZA, FEERLIMODI
    )
    SELECT
        @New_Idmaeedo,
        d.ARCHIRST, d.IDRST, d.EMPRESA, d.TIDO, d.NUDO, d.ENDO, d.SUENDO, d.ENDOFI,
        d.LILG, d.NULIDO, d.SULIDO, d.LUVTLIDO, d.BOSULIDO, d.KOFULIDO, d.NULILG,
        d.PRCT, d.TICT, d.TIPR, d.NUSEPR, d.KOPRCT, d.UDTRPR, d.RLUDPR,
        d.CAPRCO1, d.CAPRAD1, d.CAPREX1, d.CAPRNC1,
        d.UD01PR, d.CAPRCO2, d.CAPRAD2, d.CAPREX2, d.CAPRNC2,
        d.UD02PR, d.KOLTPR, d.MOPPPR, d.TIMOPPPR, d.TAMOPPPR, d.PPPRNELT, d.PPPRNE,
        d.PPPRBRLT, d.PPPRBR, d.NUDTLI, d.PODTGLLI, d.VADTNELI, d.VADTBRLI,
        d.POIVLI, d.VAIVLI, d.NUIMLI, d.POIMGLLI, d.VAIMLI, d.VANELI, d.VABRLI,
        d.TIGELI, d.EMPREPA, d.TIDOPA, d.NUDOPA, d.ENDOPA, d.NULIDOPA, d.LLEVADESP,
        d.FEEMLI, d.FEERLI, d.PPPRPM, d.OPERACION, d.CODMAQ, d.ESLIDO, d.PPPRNERE1,
        d.PPPRNERE2, d.ESFALI, d.CAFACO, d.CAFAAD, d.CAFAEX, d.CMLIDO, d.NULOTE,
        d.FVENLOTE, d.ARPROD, d.NULIPROD, d.NUCOCO, d.NULICO, d.PERIODO, d.FCRELOTE,
        d.SUBLOTE, d.NOKOPR, d.ALTERNAT, d.PRENDIDO, d.OBSERVA, d.KOFUAULIDO,
        d.KOOPLIDO, d.MGLTPR, d.PPOPPR, d.TIPOMG, d.ESPRODLI, d.CAPRODCO,
        d.CAPRODAD, d.CAPRODEX, d.CAPRODRE, d.TASADORIG, d.CUOGASDIF, d.SEMILLA,
        d.PROYECTO, d.POTENCIA, d.HUMEDAD, d.IDTABITPRE, d.IDODDGDV, d.LINCONDESP,
        d.PODEIVLI, d.VADEIVLI, d.PRIIDETIQ, d.KOLORESCA, d.KOENVASE, d.PPPRPMSUC,
        d.PPPRPMIFRS, d.COSTOTRIB, d.COSTOIFRS, d.SUENDOFI, d.COMISION,
        d.FLUVTCALZA, d.FEERLIMODI
    FROM MAEDDO d
    WHERE d.IDMAEEDO = @Idmaeedo;

    ---------------------------------------------------------

	Update {Frm_Sincronizador._Global_BaseBk}Zw_Docu_Ent Set Idmaeedo_Clon = @New_Idmaeedo Where Idmaeedo = @Idmaeedo
"

        If Not _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql) Then
            Throw New System.Exception("Error al ejecutar el proceso de clonación de NVV." & vbCrLf & _Sql.Pro_Error)
        End If

    End Sub
End Class
