Imports System.Data.SqlClient
Imports System.IO
Imports BkSpecialPrograms
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


        _SqlRandom = New Class_SQL(Cadena_ConexionSQL_Server)
        '-----------------------------------------------------------------------------------------
        '1. BUSCAR NOTAS DE VENTA (NVV) DEL E-COMMERCE QUE NO TENGAN DESPACHO ASIGNADO
        '-----------------------------------------------------------------------------------------
        Consulta_sql = $"SELECT TOP 200
    e.IDMAEEDO, e.TIDO, e.NUDO, e.ENDO, e.SUENDO,
    m.NOKOEN, m.PAEN, m.CIEN, m.CMEN,
    e.EMPRESA, e.SUDO,
    o.OBDO, e.CAPRCO, o.OCDO,
    o.TEXTO1, o.TEXTO2, o.TEXTO3,
    d.BOSULIDO AS 'Bodega',
	e.KOFUDO As 'Funcionario',
    e.VABRDO As 'Valor'
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
WHERE e.TIDO = 'NVV'
  AND e.NUDO LIKE 'B2B%'
  AND NOT EXISTS (
        SELECT 1
        FROM {Frm_Sincronizador._Global_BaseBk }Zw_Docu_Ent z
        WHERE z.Idmaeedo = e.IDMAEEDO
  )"

        Dim _Tbl_Pendientes As DataTable = _SqlRandom.Fx_Get_DataTable(Consulta_sql)

        If Not CBool(_Tbl_Pendientes.Rows.Count) Then
            'No hay nada nuevo que despachar
            Return
        End If

        Sb_AddToLog("Demonio Despachos", "Se encontraron " & _Tbl_Pendientes.Rows.Count & " NVVs pendientes.", Txt_Log)

        ' -----------------------------------------------------------------------------------------
        ' 2. PASAR LOS DATOS DEL DATATABLE A LA LISTA DE OBJETOS
        ' -----------------------------------------------------------------------------------------
        Dim listaRespuestas As New List(Of RespuestaSQL)()

        For Each row As DataRow In _Tbl_Pendientes.Rows
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
                .Valor = Convert.ToInt32(row("Valor"))
            }

            listaRespuestas.Add(respuesta)
        Next
        For Each NVV As RespuestaSQL In listaRespuestas

            ' Aquí puedes acceder a las propiedades de cada objeto directamente
            Dim numeroDocumento As String = NVV.NUDO
            Dim correoCliente As String = NVV.TEXTO3
            Dim idMaeedo As Integer = NVV.IDMAEEDO


            Sb_AddToLog("Demonio Despachos", $"Procesando documento: {numeroDocumento} (ID: {idMaeedo})", Txt_Log)
            Dim Respuesta_Tr As LsValiciones.Mensajes = Fx_Transaccion(Txt_Log, NVV)

            ' 2. Validamos el resultado
            If Respuesta_Tr.EsCorrecto Then
                ' Si todo salió bien, dejamos un log de éxito
                Sb_AddToLog("Demonio Despachos", $"¡Éxito! Documento {numeroDocumento} procesado e insertado correctamente en el módulo de despachos.", Txt_Log)
            Else
                ' Si falló (ya sea por error SQL o de validación), registramos el detalle exacto del error
                Sb_AddToLog("Demonio Despachos", $"Error grave al procesar documento {numeroDocumento}. Razón: {Respuesta_Tr.Detalle} - {Respuesta_Tr.Mensaje}", Txt_Log)
            End If

        Next

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
                       ,''                          -- TipoEstacion
                       ,'{NVV.EMPRESA}'             -- Empresa
                       ,'WEB'                       -- Modalidad
                       ,'{NVV.TIDO}'                -- Tido
                       ,'{NVV.NUDO}'                -- Nudo
                       ,GETDATE()                   -- FechaHoraGrab (Función SQL nativa)
                       ,1                           -- HabilitadaFac
                       ,'{NVV.CodFuncionario}'                          -- FunAutorizaFac
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
                       ,''                          -- Empresa_Ori
                       ,0                           -- Idmaeedo_Clon
                       ,''                          -- LeyendaMorosidad
                       ,1);"

        ' Agregar la consulta a la lista transaccional
        Mis_Consultas.Add(Consulta_Insert)


        Msg = Fx_Traer_Detalle(NVV.IDMAEEDO)
        If Msg.EsCorrecto Then
            MiDetalle = CType(Msg.Tag, List(Of RespuestaDetalle))
        Else
            Sb_AddToLog("Demonio Despachos", $"Error al traer detalle para documento: {NVV.NUDO} (ID: {NVV.IDMAEEDO}). Detalle: {Msg.Detalle}", Txt_Log)
            Return Msg
        End If

        For Each det As RespuestaDetalle In MiDetalle
            ' Escapamos comillas simples en la descripción para evitar errores de sintaxis SQL
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

            ' Agregamos cada fila del detalle a la lista transaccional
            Mis_Consultas.Add(Consulta_Insert_Det)
        Next

        ' =================================================================
        ' 4. PROCESAR DIRECCIÓN DE DESPACHO (CAMPO OBDO) EN MAYÚSCULAS
        ' =================================================================
        Dim _Tipo_Despacho As String = ""
        Dim _Direccion As String = ""
        Dim _Comuna As String = ""
        Dim _Ciudad As String = ""
        Dim _Pais As String = ""

        ' Limpiamos posibles espacios en blanco extras
        Dim ObdoLimpio As String = ""
        If Not String.IsNullOrEmpty(NVV.OBDO) Then
            ObdoLimpio = NVV.OBDO.Trim()
        End If
        Dim _Trans As String
        ' Validamos si es Retiro o Despacho
        ' Quitamos los espacios para asegurar que "Dirección de envío: , , ," se evalúe correctamente
        If ObdoLimpio.Replace(" ", "").Contains("Direccióndeenvío:,,,") Then
            _Tipo_Despacho = "RT"
            _Trans = ""
        Else
            _Tipo_Despacho = "DD"
            _Trans = "SEAGARDEN"
            ' Eliminamos el prefijo "Dirección de envío: " para quedarnos solo con los datos
            Dim prefijo As String = "Dirección de envío:"
            Dim datosUbicacion As String = ObdoLimpio

            If datosUbicacion.StartsWith(prefijo, StringComparison.OrdinalIgnoreCase) Then
                datosUbicacion = datosUbicacion.Substring(prefijo.Length).Trim()
            End If

            ' Separamos el texto usando la coma como delimitador
            Dim partes() As String = datosUbicacion.Split(","c)

            ' Asignamos los valores basándonos en el orden esperado y evitamos errores si faltan datos
            If partes.Length > 0 Then _Direccion = partes(0).Trim().ToUpper().Replace("'", "''")
            If partes.Length > 1 Then _Comuna = partes(1).Trim().ToUpper().Replace("'", "''")
            If partes.Length > 2 Then _Ciudad = partes(2).Trim().ToUpper().Replace("'", "''")
            If partes.Length > 3 Then _Pais = partes(3).Trim().ToUpper().Replace("'", "''")
        End If

        ' =================================================================
        ' 5. CALCULAR EL NRO_DESPACHO (Último número + 1 ignorando 'P')
        ' =================================================================
        ' Buscamos en la BD el número mayor descartando los que empiezan con P y asegurando que sean numéricos
        Dim Consulta_Ultimo_Despacho As String = $"
            SELECT MAX(CAST(Nro_Despacho AS INT)) AS UltimoNro 
            FROM {Frm_Sincronizador._Global_BaseBk}Zw_Despachos 
            WHERE Nro_Despacho NOT LIKE 'P%' 
              AND ISNUMERIC(Nro_Despacho) = 1"

        Dim Tbl_UltimoNro As DataTable = _SqlRandom.Fx_Get_DataTable(Consulta_Ultimo_Despacho)
        Dim _Nro_Despacho As String = "0000000001" ' Valor inicial por si la tabla está vacía

        If Tbl_UltimoNro IsNot Nothing AndAlso Tbl_UltimoNro.Rows.Count > 0 Then
            Dim rowNro = Tbl_UltimoNro.Rows(0)("UltimoNro")
            If Not IsDBNull(rowNro) Then
                ' Sumamos 1 al número mayor y lo formateamos a 10 ceros (Ej: 0000000045)
                Dim SiguienteNro As Integer = Convert.ToInt32(rowNro) + 1
                _Nro_Despacho = SiguienteNro.ToString("D10")
            End If
        End If

        Dim _RUT As String
        _RUT = NVV.ENDO
        Dim _dIGITO As String = RutDigito(_RUT)
        _RUT = FormatNumber(_RUT, 0) & "-" & _dIGITO

        _RUT = _RUT.Replace(",", ".")
        ' =================================================================
        ' 6. CONSTRUCCIÓN DE LA CONSULTA (Zw_Despachos)
        ' =================================================================
        ' NOTA: Reemplaza NVV.ENDO, NVV.KOFUDO, etc., según los nombres exactos de tu clase
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
                       ,'{NVV.SUDO}'               -- Sucursal (Reemplazar si usas otra propiedad)
                       ,'{NVV.Bodega}'              -- Bodega (Reemplazar si usas otra propiedad)
                       ,0                            -- Confirmado
                       ,'{NVV.CodFuncionario}'               -- CodFuncionario
                       ,GETDATE()                    -- Fecha_Emision
                       ,GETDATE()                    -- Fecha_Compromiso
                       ,NULL                         -- Fecha_Despacho
                       ,NULL                         -- Fecha_Cierre
                       ,'CLI'           -- Tipo_Despacho
                       ,'{_Tipo_Despacho}'                           -- Tipo_Envio
                       ,'0001'                           -- Tipo_Venta
                       ,'ING'                           -- Estado
                       ,''                 -- Referencia (Se usa el Nro de la NV)
                       ,'{NVV.ENDO}'                 -- CodEntidad
                       ,''               -- CodSucEntidad
                       ,'{_RUT}'                 -- Rut (Generalmente ENDO es el RUT en Random)
                       ,'{NVV.NOKOEN}'                           -- Nombre_Entidad
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
                       ,'B2B'                           -- Observaciones
                       ,''                           -- Sucursal_Retiro
                       ,'{NVV.PAEN}'                           -- CodPais
                       ,'{NVV.CIEN}'                           -- CodCiudad
                       ,'{NVV.CMEN}'                           -- CodComuna
                       ,''                           -- Nombre_Contacto
                       ,0);"

        ' Se agrega a la transacción general
        Mis_Consultas.Add(Consulta_Insert_Despachos)

        ' =================================================================
        ' 7. INSERTAR DOCUMENTO ASOCIADO AL DESPACHO (Zw_Despachos_Doc)
        ' =================================================================
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
                 ,{NVV.CAPRCO.ToString().Replace(",", ".")}                                              -- CantR
                 ,0                                            -- CantDesp
                 ,1                                            -- Activo
                 ,0                                            -- Nudonodefi
                 ,0                                            -- Id_Documentos_Padre
                 ,0                                            -- Reasignado
           FROM {Frm_Sincronizador._Global_BaseBk}Zw_Despachos
           WHERE Nro_Despacho = '{_Nro_Despacho}' 
             AND Empresa = '{NVV.EMPRESA}';"
        ' Se agrega a la transacción general
        Mis_Consultas.Add(Consulta_Insert_Despachos_Doc)
        ' =================================================================
        ' 8. INSERTAR EL DETALLE DEL DESPACHO (Zw_Despachos_Doc_Det)
        ' =================================================================
        For Each det As RespuestaDetalle In MiDetalle
            ' Escapamos comillas simples en la descripción para evitar errores
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

            ' Agregamos la consulta de esta línea a la lista transaccional
            Mis_Consultas.Add(Consulta_Insert_Despachos_Doc_Det)
        Next


        ' =================================================================
        ' EJECUCIÓN TRANSACCIONAL EN SQL SERVER
        ' =================================================================
        Dim myTrans As System.Data.SqlClient.SqlTransaction = Nothing
        Dim Comando As System.Data.SqlClient.SqlCommand
        Dim Cn2 As New System.Data.SqlClient.SqlConnection

        ' Instanciamos la clase de SQL con la cadena de conexión
        Dim SQL_ServerClass As New Class_SQL(Cadena_ConexionSQL_Server)

        Try
            ' Abrimos conexión e iniciamos la transacción
            SQL_ServerClass.Sb_Abrir_Conexion(Cn2)
            myTrans = Cn2.BeginTransaction()

            ' Ejecutamos cada una de las consultas encoladas
            For Each Consulta As String In Mis_Consultas
                Comando = New System.Data.SqlClient.SqlCommand(Consulta, Cn2)
                Comando.Transaction = myTrans
                Comando.ExecuteNonQuery()
            Next

            ' Si todas pasan sin error, hacemos Commit
            myTrans.Commit()
            SQL_ServerClass.Sb_Cerrar_Conexion(Cn2)

            _Mensaje.EsCorrecto = True
            _Mensaje.Detalle = "Transacción completada con éxito."
            _Mensaje.Mensaje = "Se generó el registro y el despacho correctamente."

        Catch ex As Exception
            ' Si falla algo, deshacemos todo
            _Mensaje.EsCorrecto = False
            _Mensaje.Detalle = "Error al grabar la transacción"
            _Mensaje.Mensaje = ex.Message
            _Mensaje.Id = 0

            If Not IsNothing(myTrans) Then myTrans.Rollback()
            SQL_ServerClass.Sb_Cerrar_Conexion(Cn2)

            ' Registrar el error en el log
            Sb_AddToLog("Demonio Despachos", $"Error Transaccional: {ex.Message}", Txt_Log)
        End Try

        Return _Mensaje

    End Function


    Private Function Fx_Traer_Detalle(IDMAEEDO As String) As LsValiciones.Mensajes
        Dim Msg As LsValiciones.Mensajes = New LsValiciones.Mensajes
        Consulta_sql = $"Select d.IDMAEEDO As 'Idameedo',d.IDMAEDDO As 'Idmaeddo',d.TIDO As 'Tido',d.NUDO As 'Nudo',d.KOPRCT As 'Codigo',d.NOKOPR As 'Descripcion',Cast(0 As Bit) As 'RtuVariable',d.EMPRESA As 'Empresa',d.SULIDO As 'Sucursal',d.BOSULIDO As 'Bodega',d.UDTRPR As 'Untrans',Case When d.UDTRPR = 1 then d.UD01PR else d.UD01PR End As 'Udtrans',d.RLUDPR As 'Rtu',d.CAPRCO1 As 'CantCUd1',d.CAPRCO2 As 'CantCUd2'
From MAEDDO d
Where d.IDMAEEDO = {IDMAEEDO}"
        Dim _Tbl_Pendientes As DataTable = _SqlRandom.Fx_Get_DataTable(Consulta_sql)
        ' Inicializamos la lista a retornar
        Dim listaDetalles As New List(Of RespuestaDetalle)()

        ' Verificamos que el DataTable no sea nulo y tenga filas
        If _Tbl_Pendientes IsNot Nothing AndAlso _Tbl_Pendientes.Rows.Count > 0 Then
            For Each row As DataRow In _Tbl_Pendientes.Rows
                Dim detalle As New RespuestaDetalle()

                ' Mapeamos los datos y aplicamos Trim() a los textos
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
                ' Agregamos el objeto a la lista
                listaDetalles.Add(detalle)
            Next
        Else
            Msg.EsCorrecto = False
            Msg.Mensaje = "No se encontraron detalles para el IDMAEEDO proporcionado."
            Msg.Detalle = "El DataTable está vacío o es nulo."
            Msg.Tag = listaDetalles ' Retornamos la lista vacía para mantener la consistencia del tipo de retorno
            Return Msg
        End If
        Msg.EsCorrecto = True
        Msg.Mensaje = "Se encontro detalle"
        Msg.Tag = listaDetalles ' Retornamos la lista vacía para mantener la consistencia del tipo de retorno
        ' Retornamos la lista final
        Return Msg
    End Function
    Private Function Fx_Crear_Orden_Despacho(NVV As RespuestaSQL, Txt_Log As Object) As Mensajes

        Dim _Mensaje As New Mensajes

        Return _Mensaje

    End Function


    Public Function Fx_Testear_Conexion(Txt_Log As Object) As Mensajes

        Dim _Mensaje As New Mensajes
        Dim Cn2 As New SqlConnection
        _SqlRandom = New Class_SQL(Cadena_ConexionSQL_Server)



        Try

            ' Ejecutamos una consulta ultra ligera
            Dim Consulta_sql As String = "SELECT 1"
            Dim _Tbl_Prueba As DataTable = _SqlRandom.Fx_Get_DataTable(Consulta_sql)

            ' Validamos que la tabla exista y haya devuelto algo
            If Not IsNothing(_Tbl_Prueba) AndAlso _Tbl_Prueba.Rows.Count > 0 Then
                _Mensaje.EsCorrecto = True
                _Mensaje.Detalle = "tick recibido"
                _Mensaje.Mensaje = "OK."
                Sb_AddToLog("Demonio Shopify", "Tick Correcto" & ": " & _Mensaje.Mensaje, Txt_Log)
                Return _Mensaje ' Todo OK. La base de datos responde.
            Else
                _Mensaje.EsCorrecto = True
                _Mensaje.Detalle = "tick recibido"
                _Mensaje.Mensaje = "ERROR."
                Sb_AddToLog("Demonio Shopify", "Tick Incorrecto" & ": " & _Mensaje.Mensaje, Txt_Log)

                Return _Mensaje ' Falló internamente (ej. devolvió Nothing)
            End If

        Catch ex As Exception
            _Mensaje.EsCorrecto = True
            _Mensaje.Detalle = "conexion fallida"
            _Mensaje.Mensaje = "ERROR."
            Sb_AddToLog("Demonio Shopify", "Sin Conexion " & ": " & _Mensaje.Mensaje, Txt_Log)

            Return _Mensaje
        End Try
    End Function
End Class
