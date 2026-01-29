Public Class Cl_SobreStockXClas

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Public Property TablaPasoRotacion_Clasificacion As String
    Public Property TablaPasoRotacion_Productos As String
    Public Property TablaCalendarioMesesSemanasClasificacion As String
    Public Property TablaCalendarioMesesSemanasProductos As String

    Public Sub New()

        TablaPasoRotacion_Clasificacion = "TablaPasoRotacion_Clasificacion" & FUNCIONARIO
        TablaPasoRotacion_Productos = "TablaPasoRotacion_Productos" & FUNCIONARIO
        TablaCalendarioMesesSemanasClasificacion = "TablaCalendarioMesesSemanasClasificacion" & FUNCIONARIO
        TablaCalendarioMesesSemanasProductos = "TablaCalendarioMesesSemanasProductos" & FUNCIONARIO

    End Sub

    Function Fx_CrearTablaPaso_TablaPasoRotacionXClasificaciones() As LsValiciones.Mensajes

        Dim _Mensaje As New LsValiciones.Mensajes

        Sb_Eliminar_TablasDePasoRotacion()

        Try

            Consulta_sql = $"-- Crear la tabla con la estructura
CREATE TABLE {TablaPasoRotacion_Clasificacion}(
    Codigo_Nodo VARCHAR(50),
    Codigo_Nodo_Madre VARCHAR(50),
    Producto VARCHAR(200),
    StockUd1 Float,
    StockEnTransitoUd1 Float,
    StockPedidoUd1 Float,
    StockFacSinRecepUd1 Float,
    StockDisponible Float,    
    RotM1 FLOAT,
    RotM2 FLOAT,
    RotM3 FLOAT,
    RotM4 FLOAT,
    RotCalculo VARCHAR(10),
    Rotacion FLOAT,
    Duracion_Stock_Meses FLOAT,
    MesesSobreStock INT,
    Syncro Float,
    KilosXPallet Float,
    PalletSY Float,
    SobreStock VARCHAR(2)
);"

            If Not _Sql.Ej_consulta_IDU(Consulta_sql) Then
                ' Lanzar error aquí con información útil para depuración
                Throw New Exception(String.Format("Error al ejecutar la consulta para crear la tabla '{0}'. Consulta: {1}", TablaPasoRotacion_Clasificacion, Consulta_sql))
            End If

            _Mensaje.EsCorrecto = True
            _Mensaje.Mensaje = "Tabla temporal creada correctamente."
            _Mensaje.Icono = MessageBoxIcon.Information
            _Mensaje.Detalle = "Crear tabla de paso: " & TablaPasoRotacion_Clasificacion

        Catch ex As Exception
            ' (Opcional) Registrar o asignar información al objeto _Mensaje si la estructura lo permite
            _Mensaje.EsCorrecto = False
            _Mensaje.Mensaje = ex.Message
            _Mensaje.Icono = MessageBoxIcon.Error
            ' Volver a lanzar la excepción para que el llamador la maneje y preserve la pila
            'Throw
        End Try

        Return _Mensaje

    End Function

    Function Fx_InsertarDetalleEn_TablaPasoRotacionXClasificaciones(_Tbl_Asc_02_Asociaciones As String,
                                                                    _Tbl_Asc_01_Productos As String,
                                                                   _SumarStockDisponible As Boolean) As LsValiciones.Mensajes

        Dim _Mensaje As New LsValiciones.Mensajes

        Dim _StockPedidoMasStockFacSinRecep = String.Empty

        If _SumarStockDisponible Then
            _StockPedidoMasStockFacSinRecep = " + StockPedidoUd1 + StockFacSinRecepUd1"
        End If

        Try

            Consulta_sql = $"-- Insertar los datos en la tabla recién creada
INSERT INTO {TablaPasoRotacion_Clasificacion} (
    Codigo_Nodo,
    Codigo_Nodo_Madre,
    Producto,
    StockUd1,
    StockEnTransitoUd1,
    StockPedidoUd1,
    StockFacSinRecepUd1,
    StockDisponible,    
    RotM1,
    RotM2,
    RotM3,
    RotM4,
    RotCalculo,
    Rotacion,
    Duracion_Stock_Meses,
    MesesSobreStock,
    SobreStock,
	KilosXPallet
)
SELECT  
    Codigo_Nodo,
    Codigo_Nodo_Madre,
    Producto,
    StockUd1,
    StockEnTransitoUd1,
    StockPedidoUd1,
    StockFacSinRecepUd1,
    StockUd1 + StockEnTransitoUd1{_StockPedidoMasStockFacSinRecep} AS StockDisponible,
    RotMensualUd1 AS RotM1,
    Promedio_Mensual AS RotM2,
    Promedio_3Mes AS RotM3,
    Promedio_UltMesMasPromUlt3Mes AS RotM4,
    -- Nombre del campo que resultó mayor
    CASE 
        WHEN RotMensualUd1 >= Promedio_Mensual 
             AND RotMensualUd1 >= Promedio_3Mes
             AND RotMensualUd1 >= Promedio_UltMesMasPromUlt3Mes 
        THEN 'RotM1'
        WHEN Promedio_Mensual >= RotMensualUd1 
             AND Promedio_Mensual >= Promedio_3Mes
             AND Promedio_Mensual >= Promedio_UltMesMasPromUlt3Mes 
        THEN 'RotM2'
        WHEN Promedio_3Mes >= RotMensualUd1 
             AND Promedio_3Mes >= Promedio_Mensual 
             AND Promedio_3Mes >= Promedio_UltMesMasPromUlt3Mes 
        THEN 'RotM3'
        ELSE 'RotM4'
    END AS RotCalculo,
	    -- Valor máximo
    (SELECT MAX(v) 
     FROM (VALUES (RotMensualUd1), (Promedio_Mensual), 
                  (Promedio_UltMesMasPromUlt3Mes), (Promedio_3Mes)) AS value(v)
    ) AS Rotacion,
    Duracion_Stock AS Duracion_Stock_Meses,
    MesesSobreStock,
    SobreStock,
	600
FROM {_Tbl_Asc_02_Asociaciones};
--WHERE StockUd1 + StockEnTransitoUd1 > 0

UPDATE C
SET C.KilosXPallet = ISNULL(ROUND(T.KilosXPalletPonderado, 0), 600)
FROM {TablaPasoRotacion_Clasificacion} C
INNER JOIN (
    SELECT 
        P.Codigo_Nodo,
        SUM(P.KilosXPallet * P.StockDisponible) * 1.0 
            / NULLIF(SUM(P.StockDisponible), 0) AS KilosXPalletPonderado
    FROM {TablaPasoRotacion_Productos} P
    GROUP BY P.Codigo_Nodo
) T
    ON C.Codigo_Nodo = T.Codigo_Nodo;

Update {_TablaPasoRotacion_Clasificacion} Set Duracion_Stock_Meses = Round(StockDisponible/NULLIF(Rotacion,0),0);
Update {_TablaPasoRotacion_Clasificacion} Set Syncro = (Duracion_Stock_Meses-MesesSobreStock)*Rotacion;
Update {_TablaPasoRotacion_Clasificacion} Set PalletSY = Floor(Syncro/NULLIF(KilosXPallet,0));
Update {_TablaPasoRotacion_Clasificacion} Set SobreStock = 'No' Where PalletSY <= 0; --Duracion_Stock_Meses <= MesesSobreStock
Update {_TablaPasoRotacion_Clasificacion} Set SobreStock = 'Si' Where PalletSY > 0; --Duracion_Stock_Meses > MesesSobreStock
"
            If Not _Sql.Ej_consulta_IDU(Consulta_sql) Then
                ' Lanzar error aquí con información útil para depuración
                Throw New Exception(String.Format("Error al ejecutar la consulta para insertar datos en la tabla '{0}'. Consulta: {1}", _TablaPasoRotacion_Clasificacion, Consulta_sql))
            End If

            _Mensaje.EsCorrecto = True
            _Mensaje.Mensaje = "Datos insertados correctamente en la tabla temporal."
            _Mensaje.Icono = MessageBoxIcon.Information
            _Mensaje.Detalle = "Insertar detalle en tabla de paso: " & _TablaPasoRotacion_Clasificacion

        Catch ex As Exception
            ' (Opcional) Registrar o asignar información al objeto _Mensaje si la estructura lo permite
            _Mensaje.EsCorrecto = False
            _Mensaje.Mensaje = ex.Message
            _Mensaje.Icono = MessageBoxIcon.Error
            ' Volver a lanzar la excepción para que el llamador la maneje y preserve la pila
            'Throw
        End Try

        Return _Mensaje

    End Function

    Sub Sb_Eliminar_TablasDePasoRotacion()
        Try
            Consulta_sql = "DROP TABLE " & TablaPasoRotacion_Clasificacion
            _Sql.Ej_consulta_IDU(Consulta_sql, False)
            Consulta_sql = "DROP TABLE " & TablaPasoRotacion_Productos
            _Sql.Ej_consulta_IDU(Consulta_sql, False)
        Catch ex As Exception
        End Try
    End Sub

    Function Fx_CrearTablaPaso_TablaPasoRotacionXProductos() As LsValiciones.Mensajes

        Dim _Mensaje As New LsValiciones.Mensajes

        'Sb_Eliminar_TablasDePasoRotacion()

        Try

            Consulta_sql = $"-- Crear la tabla con la estructura
    CREATE TABLE {TablaPasoRotacion_Productos}(
    Codigo VARCHAR(50),
    Descripcion VARCHAR(200),
    Codigo_Nodo VARCHAR(50),
    Codigo_Nodo_Madre VARCHAR(50),
    Producto VARCHAR(200),
    UD1 VARCHAR(50),
    Rtu FLOAT,
    StockUd1 Float,
    StockEnTransitoUd1 Float,
    StockPedidoUd1 Float,
    StockFacSinRecepUd1 Float,
    StockDisponible Float,
    RotM1 FLOAT,
    RotM2 FLOAT,
    RotM3 FLOAT,
    RotM4 FLOAT,
    RotCalculo VARCHAR(10),
    Rotacion FLOAT,
    Duracion_Stock_Meses FLOAT,
    MesesSobreStock INT,
    Syncro FLOAT,
    KilosXPallet FLOAT,
    PalletSY FLOAT,
    SobreStock VARCHAR(2)
);"

            If Not _Sql.Ej_consulta_IDU(Consulta_sql) Then
                ' Lanzar error aquí con información útil para depuración
                Throw New Exception(String.Format("Error al ejecutar la consulta para crear la tabla '{0}'. Consulta: {1}", TablaPasoRotacion_Productos, Consulta_sql))
            End If

            _Mensaje.EsCorrecto = True
            _Mensaje.Mensaje = "Tabla temporal creada correctamente."
            _Mensaje.Icono = MessageBoxIcon.Information
            _Mensaje.Detalle = "Crear tabla de paso: " & TablaPasoRotacion_Productos

        Catch ex As Exception
            ' (Opcional) Registrar o asignar información al objeto _Mensaje si la estructura lo permite
            _Mensaje.EsCorrecto = False
            _Mensaje.Mensaje = ex.Message
            _Mensaje.Icono = MessageBoxIcon.Error
            ' Volver a lanzar la excepción para que el llamador la maneje y preserve la pila
            'Throw
        End Try

        Return _Mensaje

    End Function

    Function Fx_InsertarDetalleEn_TablaPasoRotacionXProductos(_Tbl_Asc_01_Productos As String,
                                                             _SumarStockDisponible As Boolean) As LsValiciones.Mensajes

        Dim _Mensaje As New LsValiciones.Mensajes

        Dim _StockPedidoMasStockFacSinRecep = String.Empty

        If _SumarStockDisponible Then
            _StockPedidoMasStockFacSinRecep = " + StockPedidoUd1 + StockFacSinRecepUd1"
        End If

        Try

            Consulta_sql = $"-- Insertar los datos en la tabla recién creada
INSERT INTO {TablaPasoRotacion_Productos} (
    Codigo,
    Descripcion,
    Codigo_Nodo,
    Codigo_Nodo_Madre,
    Producto,
    UD1,
    Rtu,
    StockUd1,
    StockEnTransitoUd1,
    StockPedidoUd1,
    StockFacSinRecepUd1,
    StockDisponible,
    RotM1,
    RotM2,
    RotM3,
    RotM4,
    RotCalculo,
    Rotacion,
    Duracion_Stock_Meses,
    MesesSobreStock,
    SobreStock,
    KilosXPallet
)
SELECT
    Codigo,
    Descripcion,
    Codigo_Nodo,
    Codigo_Nodo_Madre,
    Producto,
    UD1,
    Rtu,
    StockUd1,
    StockEnTransitoUd1,
    StockPedidoUd1,
    StockFacSinRecepUd1,
    StockUd1 + StockEnTransitoUd1{_StockPedidoMasStockFacSinRecep} AS StockDisponible,
    RotMensualUd1_Prod AS RotM1,
    Promedio_MensualUd1_Prod AS RotM2,
    PromMensualUd1_Ul3Mes_Prod AS RotM3,
    PromUlt3CioPromUlt3Meses_Ud1_Prod AS RotM4,
    CASE
        WHEN RotMensualUd1_Prod >= Promedio_MensualUd1_Prod
             AND RotMensualUd1_Prod >= PromMensualUd1_Ul3Mes_Prod
             AND RotMensualUd1_Prod >= PromUlt3CioPromUlt3Meses_Ud1_Prod
        THEN 'RotM1'
        WHEN Promedio_MensualUd1_Prod >= RotMensualUd1_Prod
             AND Promedio_MensualUd1_Prod >= PromMensualUd1_Ul3Mes_Prod
             AND Promedio_MensualUd1_Prod >= PromUlt3CioPromUlt3Meses_Ud1_Prod
        THEN 'RotM2'
        WHEN PromMensualUd1_Ul3Mes_Prod >= RotMensualUd1_Prod
             AND PromMensualUd1_Ul3Mes_Prod >= Promedio_MensualUd1_Prod
             AND PromMensualUd1_Ul3Mes_Prod >= PromUlt3CioPromUlt3Meses_Ud1_Prod
        THEN 'RotM3'
        ELSE 'RotM4'
    END AS RotCalculo,
    (SELECT MAX(v)
     FROM (VALUES (RotMensualUd1_Prod), (PromUlt3CioPromUlt3Meses_Ud1_Prod),
                  (Promedio_MensualUd1_Prod), (PromMensualUd1_Ul3Mes_Prod)) AS value(v)
    ) AS Rotacion,
    Duracion_Stock AS Duracion_Stock_Meses,
    MesesSobreStock,
    SobreStock,
    Isnull((Select Top 1 MULTIPLO From TABCODAL Where KOPR = Codigo And TXTMULTI = 'PALLET'),600) 
FROM {_Tbl_Asc_01_Productos}
--WHERE StockUd1 + StockEnTransitoUd1 > 0;

-- Duración de stock en meses
UPDATE {TablaPasoRotacion_Productos}
SET Duracion_Stock_Meses = Round(StockDisponible / NULLIF(Rotacion,0),0);

-- Cálculo de Syncro
UPDATE {TablaPasoRotacion_Productos}
SET Syncro = (Duracion_Stock_Meses - MesesSobreStock) * Rotacion;

-- Pallets calculados hacia abajo
UPDATE {TablaPasoRotacion_Productos} SET PalletSY = FLOOR(Syncro / NULLIF(KilosXPallet,0));

-- SobreStock
UPDATE {TablaPasoRotacion_Productos} SET SobreStock = 'No' WHERE PalletSY <= 0 -- Duracion_Stock_Meses <= MesesSobreStock;
UPDATE {TablaPasoRotacion_Productos} SET SobreStock = 'Si' WHERE PalletSY > 0 -- Duracion_Stock_Meses > MesesSobreStock;
"
            If Not _Sql.Ej_consulta_IDU(Consulta_sql) Then
                ' Lanzar error aquí con información útil para depuración
                Throw New Exception(String.Format("Error al ejecutar la consulta para insertar datos en la tabla '{0}'. Consulta: {1}", TablaPasoRotacion_Productos, Consulta_sql))
            End If

            _Mensaje.EsCorrecto = True
            _Mensaje.Mensaje = "Datos insertados correctamente en la tabla temporal."
            _Mensaje.Icono = MessageBoxIcon.Information
            _Mensaje.Detalle = "Insertar detalle en tabla de paso: " & TablaPasoRotacion_Productos

        Catch ex As Exception
            ' (Opcional) Registrar o asignar información al objeto _Mensaje si la estructura lo permite
            _Mensaje.EsCorrecto = False
            _Mensaje.Mensaje = ex.Message
            _Mensaje.Icono = MessageBoxIcon.Error
            ' Volver a lanzar la excepción para que el llamador la maneje y preserve la pila
            'Throw
        End Try

        Return _Mensaje

    End Function

    Function Fx_CrearTablaPaso_TablaCalendarioMesesSemanasClasificacion() As LsValiciones.Mensajes

        Dim _Mensaje As New LsValiciones.Mensajes

        'Sb_Eliminar_TablasDePasoRotacion()

        Try

            Consulta_sql = "DROP TABLE " & TablaCalendarioMesesSemanasClasificacion
            _Sql.Ej_consulta_IDU(Consulta_sql, False)

            Consulta_sql = $"-- 1. Crear tabla calendario extendida por clasificación
CREATE TABLE {TablaCalendarioMesesSemanasClasificacion} (
    Codigo_Nodo_Madre VARCHAR(50),
    Semana INT,
    StockSemanal FLOAT DEFAULT(0),
    VentaSemanal FLOAT DEFAULT(0),
    LlegadaSemanal FLOAT DEFAULT(0),
    Mes INT,
    NombreMes VARCHAR(20),
    Periodo INT, -- año
    StockMes FLOAT DEFAULT(0),
    VentaMes FLOAT DEFAULT(0),
    LlegadasMes FLOAT DEFAULT(0),
    FechaDesde Datetime,
    FechaHasta Datetime,
    FechaSemanaInicio Datetime,
    StockNecesarioNMeses FLOAT DEFAULT(0),			-- stock requerido para cubrir N meses
    StockProyectadoMensual FLOAT DEFAULT(0),		-- stock que va bajando mes a mes
    StockNecesarioNMenosXMeses FLOAT DEFAULT(0),
    StockNecesarioNSemanas FLOAT DEFAULT(0),       -- stock requerido para N semanas
    StockProyectadoSemanal FLOAT DEFAULT(0) 
);"

            If Not _Sql.Ej_consulta_IDU(Consulta_sql) Then
                ' Lanzar error aquí con información útil para depuración
                Throw New Exception(String.Format("Error al ejecutar la consulta para crear la tabla '{0}'. Consulta: {1}", TablaCalendarioMesesSemanasClasificacion, Consulta_sql))
            End If

            _Mensaje.EsCorrecto = True
            _Mensaje.Mensaje = "Tabla temporal creada correctamente."
            _Mensaje.Icono = MessageBoxIcon.Information
            _Mensaje.Detalle = "Crear tabla de paso: " & TablaCalendarioMesesSemanasClasificacion

        Catch ex As Exception
            ' (Opcional) Registrar o asignar información al objeto _Mensaje si la estructura lo permite
            _Mensaje.EsCorrecto = False
            _Mensaje.Mensaje = ex.Message
            _Mensaje.Icono = MessageBoxIcon.Error
            ' Volver a lanzar la excepción para que el llamador la maneje y preserve la pila
            'Throw
        End Try

        Return _Mensaje

    End Function

    Function Fx_InsertarDetalleEn_TablaCalendarioMesesClasificacion(_Codigo_Nodo_Madre As String) As LsValiciones.Mensajes

        Dim _Mensaje As New LsValiciones.Mensajes

        Try

            Consulta_sql = $"-- 2. Insertar semanas y meses para cada clasificación
;WITH Semanas AS (
    SELECT 0 AS n
    UNION ALL SELECT 1
    UNION ALL SELECT 2
    UNION ALL SELECT 3
    UNION ALL SELECT 4
    UNION ALL SELECT 5
    UNION ALL SELECT 6
    UNION ALL SELECT 7
    UNION ALL SELECT 8
    UNION ALL SELECT 9
    UNION ALL SELECT 10
    UNION ALL SELECT 11
    UNION ALL SELECT 12
    UNION ALL SELECT 13
    UNION ALL SELECT 14
    UNION ALL SELECT 15
    UNION ALL SELECT 16
    UNION ALL SELECT 17
    UNION ALL SELECT 18
    UNION ALL SELECT 19
    UNION ALL SELECT 20
    UNION ALL SELECT 21
    UNION ALL SELECT 22
    UNION ALL SELECT 23
    UNION ALL SELECT 24
    UNION ALL SELECT 25
    UNION ALL SELECT 26
    UNION ALL SELECT 27
    UNION ALL SELECT 28
    UNION ALL SELECT 29
    UNION ALL SELECT 30
    UNION ALL SELECT 31
    UNION ALL SELECT 32
    UNION ALL SELECT 33
    UNION ALL SELECT 34
    UNION ALL SELECT 35
    UNION ALL SELECT 36
    UNION ALL SELECT 37
    UNION ALL SELECT 38
    UNION ALL SELECT 39
    UNION ALL SELECT 40
    UNION ALL SELECT 41
    UNION ALL SELECT 42
    UNION ALL SELECT 43
    UNION ALL SELECT 44
    UNION ALL SELECT 45
    UNION ALL SELECT 46
    UNION ALL SELECT 47
    UNION ALL SELECT 48
    UNION ALL SELECT 49
    UNION ALL SELECT 50
    UNION ALL SELECT 51
)
INSERT INTO {TablaCalendarioMesesSemanasClasificacion} (Codigo_Nodo_Madre, Semana, Mes, NombreMes, Periodo)
SELECT
    p.Codigo_Nodo_Madre,
    DATEPART(WEEK, DATEADD(WEEK, s.n, GETDATE())) AS Semana,
    MONTH(DATEADD(WEEK, s.n, GETDATE())) AS Mes,
    DATENAME(MONTH, DATEADD(WEEK, s.n, GETDATE())) AS NombreMes,
    YEAR(DATEADD(WEEK, s.n, GETDATE())) AS Periodo
FROM {TablaPasoRotacion_Clasificacion} p
CROSS JOIN Semanas s
Where p.Codigo_Nodo_Madre = '{_Codigo_Nodo_Madre}';

-- 🔹 Poblar stock inicial y ventas (agrupadas

UPDATE c
SET c.StockSemanal = CASE WHEN c.Semana = DATEPART(WEEK, GETDATE()) 
                          THEN agg.StockInicial
                          ELSE 0 END,
    c.VentaSemanal = agg.VentaMensual / 4.0,
    c.VentaMes     = agg.VentaMensual
FROM {TablaCalendarioMesesSemanasClasificacion} c
JOIN (
    SELECT Codigo_Nodo_Madre,
           SUM(StockUd1 + StockEnTransitoUd1) AS StockInicial,
           SUM(Rotacion) AS VentaMensual
    FROM {TablaPasoRotacion_Clasificacion}
    GROUP BY Codigo_Nodo_Madre
) agg ON c.Codigo_Nodo_Madre = agg.Codigo_Nodo_Madre;

-- 🔹 Poblar llegadas futuras (agrupadas

-- Llegadas semanales
UPDATE c
SET c.LlegadaSemanal = ISNULL(c.LlegadaSemanal,0) + agg.LlegadasSem
FROM {TablaCalendarioMesesSemanasClasificacion} c
JOIN (
    SELECT Codigo_Nodo_Madre,
           DATEPART(WEEK, FEERLI) AS Semana,
           YEAR(FEERLI) AS Periodo,
           SUM(Saldo) AS LlegadasSem
    FROM Tbl_Asc_04_DocUltComp_{FUNCIONARIO}
    GROUP BY Codigo_Nodo_Madre, DATEPART(WEEK, FEERLI), YEAR(FEERLI)
) agg
ON c.Codigo_Nodo_Madre = agg.Codigo_Nodo_Madre
AND c.Semana = agg.Semana
AND c.Periodo = agg.Periodo;

-- Llegadas mensuales
UPDATE c
SET c.LlegadasMes = ISNULL(c.LlegadasMes,0) + agg.LlegadasMes
FROM {TablaCalendarioMesesSemanasClasificacion} c
JOIN (
    SELECT Codigo_Nodo_Madre,
           MONTH(FEERLI) AS Mes,
           YEAR(FEERLI) AS Periodo,
           SUM(Saldo) AS LlegadasMes
    FROM Tbl_Asc_04_DocUltComp_{FUNCIONARIO}
    GROUP BY Codigo_Nodo_Madre, MONTH(FEERLI), YEAR(FEERLI)
) agg
ON c.Codigo_Nodo_Madre = agg.Codigo_Nodo_Madre
AND c.Mes = agg.Mes
AND c.Periodo = agg.Periodo;

--🔹 Recalcular stock semana a semana (agrupado

DECLARE @Codigo_Nodo_Madre VARCHAR(50), @Semana INT, @Periodo INT;
DECLARE @StockActual FLOAT, @VentaSemanal FLOAT, @Llegadas FLOAT;

DECLARE cur CURSOR FOR
SELECT DISTINCT Codigo_Nodo_Madre FROM {TablaCalendarioMesesSemanasClasificacion};

OPEN cur;
FETCH NEXT FROM cur INTO @Codigo_Nodo_Madre;

WHILE @@FETCH_STATUS = 0
BEGIN
    -- Stock inicial de la clasificación
    SELECT @StockActual = SUM(StockUd1 + StockEnTransitoUd1)
    FROM {TablaPasoRotacion_Clasificacion}
    WHERE Codigo_Nodo_Madre = @Codigo_Nodo_Madre;

    -- Recorrer semanas en orden
    DECLARE semCur CURSOR FOR
    SELECT Semana, Periodo, VentaSemanal, LlegadaSemanal
    FROM {TablaCalendarioMesesSemanasClasificacion}
    WHERE Codigo_Nodo_Madre = @Codigo_Nodo_Madre
    ORDER BY Periodo, Semana;

    OPEN semCur;
    FETCH NEXT FROM semCur INTO @Semana, @Periodo, @VentaSemanal, @Llegadas;

    WHILE @@FETCH_STATUS = 0
    BEGIN
        IF @StockActual = 0 SET @VentaSemanal = 0;

        SET @StockActual = @StockActual - @VentaSemanal + ISNULL(@Llegadas,0);
        IF @StockActual < 0 SET @StockActual = 0;

        UPDATE {TablaCalendarioMesesSemanasClasificacion}
        SET StockSemanal = @StockActual
        WHERE Codigo_Nodo_Madre = @Codigo_Nodo_Madre AND Semana = @Semana AND Periodo = @Periodo;

        FETCH NEXT FROM semCur INTO @Semana, @Periodo, @VentaSemanal, @Llegadas;
    END

    CLOSE semCur;
    DEALLOCATE semCur;

    FETCH NEXT FROM cur INTO @Codigo_Nodo_Madre;
END

CLOSE cur;
DEALLOCATE cur;

-- 🔹 Consolidación mensual

-- StockMes = stock de la última semana del mes
UPDATE c
SET c.StockMes = s.StockSemanal
FROM {TablaCalendarioMesesSemanasClasificacion} c
CROSS APPLY (
    SELECT TOP 1 t.StockSemanal
    FROM {TablaCalendarioMesesSemanasClasificacion} t
    WHERE t.Codigo_Nodo_Madre = c.Codigo_Nodo_Madre
      AND t.Periodo = c.Periodo
      AND t.Mes = c.Mes
    ORDER BY t.Semana DESC
) s;

-- LlegadasMes = suma de llegadas semanales
UPDATE c
SET c.LlegadasMes = agg.TotalLlegadas
FROM {TablaCalendarioMesesSemanasClasificacion} c
JOIN (
    SELECT Codigo_Nodo_Madre, Periodo, Mes, SUM(LlegadaSemanal) AS TotalLlegadas
    FROM {TablaCalendarioMesesSemanasClasificacion}
    GROUP BY Codigo_Nodo_Madre, Periodo, Mes
) agg
ON c.Codigo_Nodo_Madre = agg.Codigo_Nodo_Madre
AND c.Periodo = agg.Periodo
AND c.Mes = agg.Mes;

--🔹 Fechas desde/hasta de cada semana

UPDATE c
SET c.FechaDesde = DATEADD(DAY, 1 - DATEPART(WEEKDAY, f.FechaBase), f.FechaBase),
    c.FechaHasta = DATEADD(DAY, 7 - DATEPART(WEEKDAY, f.FechaBase), f.FechaBase)
FROM {TablaCalendarioMesesSemanasClasificacion} c
CROSS APPLY (
    SELECT DATEADD(
               WEEK,
               c.Semana - DATEPART(WEEK, DATEADD(YEAR, c.Periodo - YEAR(GETDATE()), GETDATE())),
               DATEADD(YEAR, c.Periodo - YEAR(GETDATE()), GETDATE())
           ) AS FechaBase
) f;
;
"
            If Not _Sql.Ej_consulta_IDU(Consulta_sql) Then
                ' Lanzar error aquí con información útil para depuración
                Throw New Exception(String.Format("Error al ejecutar la consulta para insertar datos en la tabla '{0}'. Consulta: {1}", TablaCalendarioMesesSemanasClasificacion, Consulta_sql))
            End If

            _Mensaje.EsCorrecto = True
            _Mensaje.Mensaje = "Datos insertados correctamente en la tabla temporal."
            _Mensaje.Icono = MessageBoxIcon.Information
            _Mensaje.Detalle = "Insertar detalle en tabla de paso: " & TablaCalendarioMesesSemanasClasificacion

        Catch ex As Exception
            ' (Opcional) Registrar o asignar información al objeto _Mensaje si la estructura lo permite
            _Mensaje.EsCorrecto = False
            _Mensaje.Mensaje = ex.Message
            _Mensaje.Icono = MessageBoxIcon.Error
            ' Volver a lanzar la excepción para que el llamador la maneje y preserve la pila
            'Throw
        End Try

        Return _Mensaje

    End Function

    '    Function Fx_CrearTablaPaso_TablaCalendarioMesesSemanasProductos() As LsValiciones.Mensajes

    '        Dim _Mensaje As New LsValiciones.Mensajes

    '        'Sb_Eliminar_TablasDePasoRotacion()

    '        Try

    '            Consulta_sql = "DROP TABLE " & TablaCalendarioMesesSemanasProductos
    '            _Sql.Ej_consulta_IDU(Consulta_sql, False)

    '            Consulta_sql = $"-- 🔹 1. Crear tabla calendario extendida
    'CREATE TABLE {TablaCalendarioMesesSemanasProductos} (
    '    Codigo VARCHAR(13),
    '	Codigo_Nodo_Madre VARCHAR(50),
    '    Semana INT,
    '    StockSemanal FLOAT DEFAULT(0),
    '    VentaSemanal FLOAT DEFAULT(0),
    '    LlegadaSemanal FLOAT DEFAULT(0),
    '    Mes INT,
    '    NombreMes VARCHAR(20),
    '    Periodo Int, -- formato YYYY-MM
    '    StockMes FLOAT DEFAULT(0),
    '    VentaMes FLOAT DEFAULT(0),
    '    LlegadasMes Float DEFAULT(0),
    '    LlegadasSemanales Float DEFAULT(0),
    '    FechaDesde Datetime,
    '    FechaHasta Datetime,
    '    FechaSemanaInicio Datetime,
    '    StockNecesarioNMeses FLOAT DEFAULT(0),			-- stock requerido para cubrir N meses
    '    StockProyectadoMensual FLOAT DEFAULT(0),		-- stock que va bajando mes a mes
    '    StockNecesarioNMenosXMeses FLOAT DEFAULT(0),
    '    StockNecesarioNSemanas FLOAT DEFAULT(0),       -- stock requerido para N semanas
    '    StockProyectadoSemanal FLOAT DEFAULT(0) 
    ');"

    '            If Not _Sql.Ej_consulta_IDU(Consulta_sql) Then
    '                ' Lanzar error aquí con información útil para depuración
    '                Throw New Exception(String.Format("Error al ejecutar la consulta para crear la tabla '{0}'. Consulta: {1}", TablaCalendarioMesesSemanasProductos, Consulta_sql))
    '            End If

    '            _Mensaje.EsCorrecto = True
    '            _Mensaje.Mensaje = "Tabla temporal creada correctamente."
    '            _Mensaje.Icono = MessageBoxIcon.Information
    '            _Mensaje.Detalle = "Crear tabla de paso: " & TablaCalendarioMesesSemanasProductos

    '        Catch ex As Exception
    '            ' (Opcional) Registrar o asignar información al objeto _Mensaje si la estructura lo permite
    '            _Mensaje.EsCorrecto = False
    '            _Mensaje.Mensaje = ex.Message
    '            _Mensaje.Icono = MessageBoxIcon.Error
    '            ' Volver a lanzar la excepción para que el llamador la maneje y preserve la pila
    '            'Throw
    '        End Try

    '        Return _Mensaje

    '    End Function

    '    Function Fx_InsertarDetalleEn_TablaCalendarioMesesSemanasProductos(_Codigo_Nodo_Madre As String) As LsValiciones.Mensajes

    '        Dim _Mensaje As New LsValiciones.Mensajes

    '        Try

    '            Consulta_sql = $"--🔹 2. Insertar semanas y meses para cada producto
    '--Generamos 52 semanas (1 año) y cruzamos con productos.
    '--El campo Periodo será YYYY-MM del primer día de la semana.

    ';WITH Semanas AS (
    '    SELECT 0 AS n
    '    UNION ALL SELECT 1
    '    UNION ALL SELECT 2
    '    UNION ALL SELECT 3
    '    UNION ALL SELECT 4
    '    UNION ALL SELECT 5
    '    UNION ALL SELECT 6
    '    UNION ALL SELECT 7
    '    UNION ALL SELECT 8
    '    UNION ALL SELECT 9
    '    UNION ALL SELECT 10
    '    UNION ALL SELECT 11
    '    UNION ALL SELECT 12
    '    UNION ALL SELECT 13
    '    UNION ALL SELECT 14
    '    UNION ALL SELECT 15
    '    UNION ALL SELECT 16
    '    UNION ALL SELECT 17
    '    UNION ALL SELECT 18
    '    UNION ALL SELECT 19
    '    UNION ALL SELECT 20
    '    UNION ALL SELECT 21
    '    UNION ALL SELECT 22
    '    UNION ALL SELECT 23
    '    UNION ALL SELECT 24
    '    UNION ALL SELECT 25
    '    UNION ALL SELECT 26
    '    UNION ALL SELECT 27
    '    UNION ALL SELECT 28
    '    UNION ALL SELECT 29
    '    UNION ALL SELECT 30
    '    UNION ALL SELECT 31
    '    UNION ALL SELECT 32
    '    UNION ALL SELECT 33
    '    UNION ALL SELECT 34
    '    UNION ALL SELECT 35
    '    UNION ALL SELECT 36
    '    UNION ALL SELECT 37
    '    UNION ALL SELECT 38
    '    UNION ALL SELECT 39
    '    UNION ALL SELECT 40
    '    UNION ALL SELECT 41
    '    UNION ALL SELECT 42
    '    UNION ALL SELECT 43
    '    UNION ALL SELECT 44
    '    UNION ALL SELECT 45
    '    UNION ALL SELECT 46
    '    UNION ALL SELECT 47
    '    UNION ALL SELECT 48
    '    UNION ALL SELECT 49
    '    UNION ALL SELECT 50
    '    UNION ALL SELECT 51
    ')
    'INSERT INTO {TablaCalendarioMesesSemanasProductos} (Codigo, Codigo_Nodo_Madre, Semana, Mes, NombreMes, Periodo)
    'SELECT
    '    p.Codigo,p.Codigo_Nodo_Madre,
    '    DATEPART(WEEK, DATEADD(WEEK, s.n, GETDATE())) AS Semana,
    '    MONTH(DATEADD(WEEK, s.n, GETDATE())) AS Mes,
    '    DATENAME(MONTH, DATEADD(WEEK, s.n, GETDATE())) AS NombreMes,
    '    --YEAR(DATEADD(MONTH, n, GETDATE())) AS Periodo
    '	YEAR(DATEADD(WEEK, s.n, GETDATE())) AS Periodo

    'FROM {TablaPasoRotacion_Productos} p
    'CROSS JOIN Semanas s
    'Where p.Codigo_Nodo_Madre = '{_Codigo_Nodo_Madre}'


    '--🔹 3. Poblar stock inicial, ventas y llegadas
    '--- Stock inicial: StockUd1 + StockEnTransitoUd1 en la primera semana.
    '--- Venta mensual: Rotacion.
    '--- Venta semanal: Rotacion / 4.
    '--- Llegadas: se asignan según la fecha FEERLI de la tabla de compras.

    '-- Poblar stock inicial y ventas
    'UPDATE c
    'SET c.StockSemanal = CASE WHEN c.Semana = DATEPART(WEEK, GETDATE()) 
    '                          THEN p.StockUd1 + p.StockEnTransitoUd1
    '                          ELSE 0 END,
    '    c.VentaSemanal = p.Rotacion / 4.0,
    '    c.VentaMes = p.Rotacion
    'FROM {TablaCalendarioMesesSemanasProductos} c
    'JOIN {TablaPasoRotacion_Productos} p ON c.Codigo = p.Codigo;

    '-- Poblar llegadas futuras en semanas y meses

    'UPDATE c
    'SET c.LlegadaSemanal = ISNULL(c.LlegadaSemanal,0) + d.TotalSaldo,
    '    c.LlegadasMes   = ISNULL(c.LlegadasMes,0) + d.TotalSaldo
    'FROM {TablaCalendarioMesesSemanasProductos} c
    'JOIN (
    '    SELECT Codigo,
    '           DATEPART(WEEK, FEERLI) AS Semana,
    '           YEAR(FEERLI) AS Periodo,
    '           SUM(Saldo) AS TotalSaldo
    '    FROM Tbl_Asc_04_DocUltComp_{FUNCIONARIO}
    '    WHERE TIDO In ('OCC','FCC')
    '    GROUP BY Codigo, DATEPART(WEEK, FEERLI), YEAR(FEERLI)
    ') d
    '    ON c.Codigo = d.Codigo
    '   AND c.Semana = d.Semana
    '   AND c.Periodo = d.Periodo;



    '--🔹 4. Recalcular stock semana a semana

    'DECLARE @Codigo VARCHAR(13), @Semana INT, @Mes INT, @Periodo VARCHAR(7);
    'DECLARE @StockActual FLOAT, @VentaSemanal FLOAT, @LlegadasSemanal FLOAT;


    'DECLARE cur CURSOR FOR
    'SELECT DISTINCT Codigo FROM {TablaCalendarioMesesSemanasProductos};

    '' Calcular StockSemanal como el stock de la última semana del mes

    'OPEN cur;
    'FETCH NEXT FROM cur INTO @Codigo;

    'WHILE @@FETCH_STATUS = 0
    'BEGIN
    '    ' Stock inicial del producto
    '    SELECT @StockActual = StockUd1 + StockEnTransitoUd1
    '    FROM {TablaPasoRotacion_Productos}
    '    WHERE Codigo = @Codigo;

    '    ' Recorremos semanas en orden
    '    DECLARE semCur CURSOR FOR
    '    SELECT Semana, Periodo, VentaSemanal, LlegadaSemanal
    '    FROM {TablaCalendarioMesesSemanasProductos}
    '    WHERE Codigo = @Codigo
    '    ORDER BY Periodo, Semana;

    '    OPEN semCur;
    '    FETCH NEXT FROM semCur INTO @Semana, @Periodo, @VentaSemanal, @LlegadasSemanal;

    '    WHILE @@FETCH_STATUS = 0
    '    BEGIN
    '        ' Si no hay stock inicial, no se descuenta venta
    '        IF @StockActual = 0
    '            SET @VentaSemanal = 0;

    '        ' Aplicar llegadas y ventas
    '        stockActual = stockActual - ventaAplicada + llegadaSemanal

    '        ' Evitar negativos
    '        IF @StockActual < 0
    '            SET @StockActual = 0;

    '        ' Actualizar la tabla
    '        UPDATE {TablaCalendarioMesesSemanasProductos}
    '        SET StockSemanal = @StockActual,
    '            StockMes = @StockActual
    '        WHERE Codigo = @Codigo AND Semana = @Semana AND Periodo = @Periodo;

    '        FETCH NEXT FROM semCur INTO @Semana, @Periodo, @VentaSemanal, @LlegadasSemanal;
    '    END

    '    CLOSE semCur;
    '    DEALLOCATE semCur;

    '    FETCH NEXT FROM cur INTO @Codigo;
    'END

    'CLOSE cur;
    'DEALLOCATE cur;


    '' Calcular StockMes como el stock de la última semana del mes
    'UPDATE c
    'SET c.StockMes = s.StockSemanal
    'FROM {TablaCalendarioMesesSemanasProductos} c
    'CROSS APPLY (
    '    SELECT TOP 1 t.StockSemanal
    '    FROM {TablaCalendarioMesesSemanasProductos} t
    '    WHERE t.Codigo = c.Codigo
    '      AND t.Periodo = c.Periodo
    '      AND t.Mes = c.Mes
    '    ORDER BY t.Semana DESC
    ') s;

    '' Calcular LlegadasMes como la suma de llegadas semanales del mes
    'UPDATE c
    'SET c.LlegadasMes = agg.TotalLlegadas
    'FROM {TablaCalendarioMesesSemanasProductos} c
    'JOIN (
    '    SELECT Codigo, Periodo, Mes, SUM(LlegadaSemanal) AS TotalLlegadas
    '    FROM {TablaCalendarioMesesSemanasProductos}
    '    GROUP BY Codigo, Periodo, Mes
    ') agg
    'ON c.Codigo = agg.Codigo
    'AND c.Periodo = agg.Periodo
    'AND c.Mes = agg.Mes;


    '' Poblar fechas desde/hasta para cada semana
    'UPDATE c
    'SET c.FechaDesde = DATEADD(DAY, 1 - DATEPART(WEEKDAY, f.FechaBase), f.FechaBase),
    '    c.FechaHasta = DATEADD(DAY, 7 - DATEPART(WEEKDAY, f.FechaBase), f.FechaBase)
    'FROM {TablaCalendarioMesesSemanasProductos} c
    'CROSS APPLY (
    '    SELECT DATEADD(WEEK, c.Semana - DATEPART(WEEK, GETDATE()), GETDATE()) AS FechaBase
    ') f;



    '' Para agregar nuevos calculos que me pasa Gonzalo

    'DECLARE @NMes Int = 6; -- horizonte en meses (variable)
    'DECLARE @XMeses Int = 2;

    '' 1. Calcular stock necesario para N meses y N-2 meses
    'UPDATE c
    'SET c.StockNecesarioNMeses = p.Rotacion * @NMes,
    '    c.StockNecesarioNMenosXMeses = p.Rotacion * (@NMes - @XMeses)
    'FROM {TablaCalendarioMesesSemanasProductos} c
    'JOIN {TablaPasoRotacion_Productos} p ON c.Codigo = p.Codigo;



    '' 2. Simular consumo Mes a Mes

    'DECLARE @VentaMensual FLOAT;

    'DECLARE cur CURSOR FOR
    'SELECT DISTINCT Codigo FROM {TablaCalendarioMesesSemanasProductos};

    'OPEN cur;
    'FETCH NEXT FROM cur INTO @Codigo;

    'WHILE @@FETCH_STATUS = 0
    'BEGIN
    '    ' Stock inicial = stock necesario para N meses
    '    SELECT @StockActual = MAX(StockNecesarioNMeses)+MAX(VentaMes),
    '           @VentaMensual = MAX(VentaMes)
    '    FROM {TablaCalendarioMesesSemanasProductos}
    '    WHERE Codigo = @Codigo;

    '    ' Recorrer meses en orden
    '    DECLARE mesCur CURSOR FOR
    '    SELECT Mes, Periodo
    '    FROM {TablaCalendarioMesesSemanasProductos}
    '    WHERE Codigo = @Codigo
    '    GROUP BY Mes, Periodo
    '    ORDER BY Periodo, Mes;


    '    OPEN mesCur;
    '    FETCH NEXT FROM mesCur INTO @Mes, @Periodo;

    '    WHILE @@FETCH_STATUS = 0
    '    BEGIN
    '       ' Descontar solo ventas mensuales (sin sumar llegadas)
    '        SET @StockActual = @StockActual - @VentaMensual;
    '        IF @StockActual < 0 SET @StockActual = 0;

    '        ' Actualizar campo StockProyectado en todas las semanas del mes
    '        UPDATE {TablaCalendarioMesesSemanasProductos}
    '        SET StockProyectadoMensual = @StockActual
    '        WHERE Codigo = @Codigo AND Mes = @Mes AND Periodo = @Periodo;

    '        FETCH NEXT FROM mesCur INTO @Mes, @Periodo;
    '    END

    '    CLOSE mesCur;
    '    DEALLOCATE mesCur;

    '    FETCH NEXT FROM cur INTO @Codigo;
    'END

    'CLOSE cur;
    'DEALLOCATE cur;


    ''DECLARE @NSem INT = @NMes * 24; -- horizonte en semanas (variable)

    '' 1. Calcular stock necesario para N semanas y N-2 semanas
    'UPDATE c
    'SET c.StockNecesarioNSemanas = c.StockNecesarioNMeses --c.VentaSemanal * @NSem
    '    ' c.StockNecesarioNSemanasMenos2 = c.VentaSemanal * (@NSem - 2)
    'FROM {TablaCalendarioMesesSemanasProductos} c;

    '' 2. Simular consumo semana a semana

    'DECLARE cur CURSOR FOR
    'SELECT DISTINCT Codigo FROM {TablaCalendarioMesesSemanasProductos};

    'OPEN cur;
    'FETCH NEXT FROM cur INTO @Codigo;

    'WHILE @@FETCH_STATUS = 0
    'BEGIN
    '    ' Stock inicial = stock necesario para N semanas
    '    SELECT @StockActual = MAX(StockNecesarioNSemanas)+MAX(VentaSemanal),
    '           @VentaSemanal = MAX(VentaSemanal)
    '    FROM {TablaCalendarioMesesSemanasProductos}
    '    WHERE Codigo = @Codigo;

    '    ' Recorrer semanas en orden
    '    DECLARE semCur CURSOR FOR
    '    SELECT Semana, Periodo
    '    FROM {TablaCalendarioMesesSemanasProductos}
    '    WHERE Codigo = @Codigo
    '    ORDER BY Periodo, Semana;

    '    OPEN semCur;
    '    FETCH NEXT FROM semCur INTO @Semana, @Periodo;

    '    WHILE @@FETCH_STATUS = 0
    '    BEGIN
    '        ' Descontar ventas semanales
    '        SET @StockActual = @StockActual - @VentaSemanal;
    '        IF @StockActual < 0 SET @StockActual = 0;

    '        ' Actualizar campo StockProyectadoSemanal
    '        UPDATE {TablaCalendarioMesesSemanasProductos}
    '        SET StockProyectadoSemanal = @StockActual
    '        WHERE Codigo = @Codigo AND Semana = @Semana AND Periodo = @Periodo;

    '        FETCH NEXT FROM semCur INTO @Semana, @Periodo;
    '    END

    '    CLOSE semCur;
    '    DEALLOCATE semCur;

    '    FETCH NEXT FROM cur INTO @Codigo;
    'END

    'CLOSE cur;
    'DEALLOCATE cur;

    '"
    '            If Not _Sql.Ej_consulta_IDU(Consulta_sql) Then
    '                ' Lanzar error aquí con información útil para depuración
    '                Throw New Exception(String.Format("Error al ejecutar la consulta para insertar datos en la tabla '{0}'. Consulta: {1}", TablaCalendarioMesesSemanasProductos, Consulta_sql))
    '            End If

    '            _Mensaje.EsCorrecto = True
    '            _Mensaje.Mensaje = "Datos insertados correctamente en la tabla temporal."
    '            _Mensaje.Icono = MessageBoxIcon.Information
    '            _Mensaje.Detalle = "Insertar detalle en tabla de paso: " & TablaCalendarioMesesSemanasProductos

    '        Catch ex As Exception
    '            ' (Opcional) Registrar o asignar información al objeto _Mensaje si la estructura lo permite
    '            _Mensaje.EsCorrecto = False
    '            _Mensaje.Mensaje = ex.Message
    '            _Mensaje.Icono = MessageBoxIcon.Error
    '            ' Volver a lanzar la excepción para que el llamador la maneje y preserve la pila
    '            'Throw
    '        End Try

    '        Return _Mensaje

    '    End Function

    '    Function Fx_InsertarDetalleEn_TablaCalendarioMesesSemanasProductos_VB(_Codigo_Nodo_Madre As String) As LsValiciones.Mensajes

    '        Dim _Mensaje As New LsValiciones.Mensajes

    '        Try
    '            ' 1) Crear tabla si no existe (reutiliza método de la clase)
    '            Dim _crea = Fx_CrearTablaPaso_TablaCalendarioMesesSemanasProductos()
    '            If Not _crea.EsCorrecto Then
    '                _Mensaje.EsCorrecto = False
    '                _Mensaje.Mensaje = "No se pudo crear la tabla temporal: " & _crea.Mensaje
    '                _Mensaje.Icono = MessageBoxIcon.Error
    '                Return _Mensaje
    '            End If

    '            ' 2) Leer productos de la clasificación
    '            Dim Consulta As String
    '            Consulta = $"SELECT Codigo,Codigo_Nodo_Madre,ISNULL(StockUd1,0) AS StockUd1,ISNULL(StockEnTransitoUd1,0) AS StockEnTransitoUd1,ISNULL(Rotacion,0) AS Rotacion 
    'FROM {TablaPasoRotacion_Productos} 
    'WHERE Codigo_Nodo_Madre = '{_Codigo_Nodo_Madre}'"
    '            Dim dtProductos As DataTable = _Sql.Fx_Get_DataTable(Consulta)

    '            If dtProductos Is Nothing OrElse dtProductos.Rows.Count = 0 Then
    '                ' Nada que insertar
    '                _Mensaje.EsCorrecto = True
    '                _Mensaje.Mensaje = "No hay productos para la clasificación indicada."
    '                _Mensaje.Icono = MessageBoxIcon.Information
    '                Return _Mensaje
    '            End If

    '            ' 3) Construir INSERT masivo para 52 semanas
    '            Dim sbInsert As New System.Text.StringBuilder()
    '            sbInsert.AppendLine($"INSERT INTO {TablaCalendarioMesesSemanasProductos} (Codigo, Codigo_Nodo_Madre, Semana, StockSemanal, VentaSemanal, LlegadaSemanal, Mes, NombreMes, Periodo, StockMes, VentaMes, LlegadasMes, FechaDesde, FechaHasta, StockNecesarioNMeses, StockProyectadoMensual, StockNecesarioNMenosXMeses, StockNecesarioNSemanas, StockProyectadoSemanal) VALUES")

    '            Dim ci As New Globalization.CultureInfo("es-ES")
    '            Dim semanaActual As Integer = DatePart(DateInterval.WeekOfYear, DateTime.Now)
    '            Dim filas As New List(Of String)

    '            For Each dr As DataRow In dtProductos.Rows
    '                Dim codigo As String = dr("Codigo").ToString().Replace("'", "''")
    '                Dim codigoNodo As String = dr("Codigo_Nodo_Madre").ToString().Replace("'", "''")
    '                Dim stockUd1 As Double = Convert.ToDouble(dr("StockUd1"))
    '                Dim stockEnTransito As Double = Convert.ToDouble(dr("StockEnTransitoUd1"))
    '                Dim rotacion As Double = Convert.ToDouble(dr("Rotacion"))
    '                For n As Integer = 0 To 51
    '                    Dim fechaBase As DateTime = DateAdd(DateInterval.WeekOfYear, n, DateTime.Now)
    '                    Dim semana As Integer = DatePart(DateInterval.WeekOfYear, fechaBase)
    '                    Dim mes As Integer = fechaBase.Month
    '                    Dim nombreMes As String = fechaBase.ToString("MMMM", ci)
    '                    Dim periodo As Integer = fechaBase.Year
    '                    Dim stockSemanal As Double = If(semana = semanaActual, stockUd1 + stockEnTransito, 0.0)
    '                    Dim ventaSemanal As Double = rotacion / 4.0
    '                    Dim ventaMes As Double = rotacion
    '                    Dim llegadaSemanal As Double = 0.0
    '                    Dim llegadasMes As Double = 0.0
    '                    Dim fechaDesde As DateTime = fechaBase.AddDays(-CInt(fechaBase.DayOfWeek))
    '                    Dim fechaHasta As DateTime = fechaBase.AddDays(6 - CInt(fechaBase.DayOfWeek))
    '                    Dim stockNecesarioNMeses As Double = 0.0
    '                    Dim stockProyectadoMensual As Double = 0.0
    '                    Dim stockNecesarioNMenosXMeses As Double = 0.0
    '                    Dim stockNecesarioNSemanas As Double = 0.0
    '                    Dim stockProyectadoSemanal As Double = 0.0

    '                    filas.Add($"('{codigo}','{codigoNodo}',{semana},{stockSemanal.ToString.Replace(",", ".")},
    '                                  {ventaSemanal.ToString.Replace(",", ".")},{llegadaSemanal.ToString.Replace(",", ".")},{mes},
    '                                  '{nombreMes.Replace("'", "''")}',{periodo},{stockSemanal.ToString.Replace(",", ".")},
    '                                  {ventaMes.ToString.Replace(",", ".")},{llegadasMes.ToString.Replace(",", ".")}
    '                                  ,'{Format(fechaDesde, "yyyyMMdd")}','{Format(fechaHasta, "yyyyMMdd")}',
    '                                  {stockNecesarioNMeses.ToString.Replace(",", ".")},
    '                                  {stockProyectadoMensual.ToString.Replace(",", ".")},
    '                                  {stockNecesarioNMenosXMeses.ToString.Replace(",", ".")},
    '                                  {stockNecesarioNSemanas.ToString.Replace(",", ".")},
    '                                  {stockProyectadoSemanal.ToString.Replace(",", ".")})")
    '                Next
    '            Next

    '            If filas.Count > 0 Then
    '                sbInsert.AppendLine(String.Join("," & vbCrLf, filas))
    '                If Not _Sql.Ej_consulta_IDU(sbInsert.ToString) Then
    '                    Throw New Exception("Error al insertar filas iniciales en tabla calendario (insert masivo).")
    '                End If
    '            End If

    '            ' 4) Poblar llegadas semanales y mensuales desde Tbl_Asc_04_DocUltComp_{FUNCIONARIO}
    '            Consulta = $"SELECT Codigo, DATEPART(WEEK, FEERLI) AS Semana, YEAR(FEERLI) AS Periodo, SUM(Saldo) AS TotalSaldo FROM Tbl_Asc_04_DocUltComp_{FUNCIONARIO} WHERE TIDO IN ('OCC','FCC') GROUP BY Codigo, DATEPART(WEEK, FEERLI), YEAR(FEERLI)"
    '            Dim dtLlegadas As DataTable = _Sql.Fx_Get_DataTable(Consulta)
    '            If dtLlegadas IsNot Nothing AndAlso dtLlegadas.Rows.Count > 0 Then
    '                For Each dr As DataRow In dtLlegadas.Rows
    '                    Dim codigo As String = dr("Codigo").ToString().Replace("'", "''")
    '                    Dim semana As Integer = Convert.ToInt32(dr("Semana"))
    '                    Dim periodo As Integer = Convert.ToInt32(dr("Periodo"))
    '                    Dim totalSaldo As Double = Convert.ToDouble(dr("TotalSaldo"))
    '                    Dim upd As String = $"UPDATE {TablaCalendarioMesesSemanasProductos} SET LlegadaSemanal = ISNULL(LlegadaSemanal,0) + {totalSaldo.ToString.Replace(",", ".")}, LlegadasMes = ISNULL(LlegadasMes,0) + {totalSaldo.ToString.Replace(",", ".")} WHERE Codigo = '{codigo}' AND Semana = {semana} AND Periodo = {periodo}"
    '                    _Sql.Ej_consulta_IDU(upd, False)
    '                Next
    '            End If

    '            ' 5) Recalcular stock semana a semana en VB para cada Codigo
    '            Consulta = $"SELECT DISTINCT Codigo FROM {TablaCalendarioMesesSemanasProductos}"
    '            Dim dtCodigos As DataTable = _Sql.Fx_Get_DataTable(Consulta)
    '            If dtCodigos IsNot Nothing Then
    '                For Each drCodigo As DataRow In dtCodigos.Rows
    '                    Dim codigo As String = drCodigo("Codigo").ToString().Replace("'", "''")

    '                    ' Obtener stock inicial y rotacion del producto
    '                    Dim dtProd As DataTable = _Sql.Fx_Get_DataTable($"SELECT ISNULL(StockUd1,0) AS StockUd1, ISNULL(StockEnTransitoUd1,0) AS StockEnTransitoUd1, ISNULL(Rotacion,0) AS Rotacion FROM {TablaPasoRotacion_Productos} WHERE Codigo = '{codigo}'")
    '                    Dim stockActual As Double = 0.0
    '                    Dim ventaSemanalDef As Double = 0.0
    '                    If dtProd IsNot Nothing AndAlso dtProd.Rows.Count > 0 Then
    '                        stockActual = Convert.ToDouble(dtProd.Rows(0)("StockUd1")) + Convert.ToDouble(dtProd.Rows(0)("StockEnTransitoUd1"))
    '                        ventaSemanalDef = Convert.ToDouble(dtProd.Rows(0)("Rotacion")) / 4.0
    '                    End If

    '                    ' Leer semanas ordenadas
    '                    Dim dtSemanas As DataTable = _Sql.Fx_Get_DataTable($"SELECT Semana, Periodo, ISNULL(VentaSemanal,0) AS VentaSemanal, ISNULL(LlegadaSemanal,0) AS LlegadaSemanal FROM {TablaCalendarioMesesSemanasProductos} WHERE Codigo = '{codigo}' ORDER BY Periodo, Semana")
    '                    If dtSemanas Is Nothing Then Continue For

    '                    Dim indexWeek As Integer = 0
    '                    ' Calcular valores relacionados con la semana actual para aplicar la fracción en la segunda semana
    '                    Dim semanaActualLocal As Integer = DatePart(DateInterval.WeekOfYear, DateTime.Now)
    '                    Dim periodoActual As Integer = DateTime.Now.Year
    '                    ' Para el cálculo de días restantes se asume semana que comienza el lunes
    '                    Dim dow As Integer = If(DateTime.Now.DayOfWeek = DayOfWeek.Sunday, 7, CInt(DateTime.Now.DayOfWeek))
    '                    Dim daysRemainingInclusive As Integer = 7 - dow + 1 ' ejemplo: miércoles -> 5 días (mié..dom)

    '                    For Each rs As DataRow In dtSemanas.Rows
    '                        Dim ventaSemanalTabla As Double = Convert.ToDouble(rs("VentaSemanal"))
    '                        Dim llegadaSemanal As Double = Convert.ToDouble(rs("LlegadaSemanal"))

    '                        Dim ventaAplicada As Double

    '                        If indexWeek = 0 Then
    '                            ' Primera semana: no descontar ventas (se mantiene el stock inicial)
    '                            ventaAplicada = 0.0
    '                        ElseIf indexWeek = 1 Then
    '                            ' Segunda semana: descontar proporcional según los días restantes de la primera semana
    '                            ventaAplicada = ventaSemanalDef * (daysRemainingInclusive / 7.0)
    '                        Else
    '                            ' Semanas siguientes: descuento de venta semanal completa
    '                            ventaAplicada = ventaSemanalDef
    '                        End If

    '                        ' Si no hay stock inicial, no se descuenta venta
    '                        If stockActual = 0 Then
    '                            ventaAplicada = 0.0
    '                        End If

    '                        ' Aplicar llegadas y ventas
    '                        stockActual = stockActual - ventaAplicada + llegadaSemanal

    '                        ' Evitar negativos
    '                        If stockActual < 0 Then stockActual = 0.0

    '                        Dim semana As Integer = Convert.ToInt32(rs("Semana"))
    '                        Dim periodo As Integer = Convert.ToInt32(rs("Periodo"))

    '                        Dim upd As String = $"UPDATE {TablaCalendarioMesesSemanasProductos} SET StockSemanal = {stockActual.ToString.Replace(",", ".")}, StockMes = {stockActual.ToString.Replace(",", ".")} WHERE Codigo = '{codigo}' AND Semana = {semana} AND Periodo = {periodo}"
    '                        _Sql.Ej_consulta_IDU(upd, False)

    '                        indexWeek += 1
    '                    Next
    '                Next
    '            End If

    '            ' 6) Consolidación mensual en VB: StockMes = stock de la última semana del mes
    '            Consulta = $"SELECT DISTINCT Codigo, Periodo, Mes FROM {TablaCalendarioMesesSemanasProductos} ORDER BY Codigo, Periodo, Mes"
    '            Dim dtMeses As DataTable = _Sql.Fx_Get_DataTable(Consulta)
    '            If dtMeses IsNot Nothing Then
    '                For Each drMes As DataRow In dtMeses.Rows
    '                    Dim codigo As String = drMes("Codigo").ToString().Replace("'", "''")
    '                    Dim periodo As Integer = Convert.ToInt32(drMes("Periodo"))
    '                    Dim mes As Integer = Convert.ToInt32(drMes("Mes"))

    '                    ' Obtener la última semana del mes para este producto
    '                    Dim dtUltSemana As DataTable = _Sql.Fx_Get_DataTable($"SELECT TOP 1 StockSemanal FROM {TablaCalendarioMesesSemanasProductos} WHERE Codigo = '{codigo}' AND Periodo = {periodo} AND Mes = {mes} ORDER BY Semana DESC")
    '                    If dtUltSemana IsNot Nothing AndAlso dtUltSemana.Rows.Count > 0 Then
    '                        Dim stockMesVal As Double = Convert.ToDouble(dtUltSemana.Rows(0)("StockSemanal"))
    '                        Dim upd As String = $"UPDATE {TablaCalendarioMesesSemanasProductos} SET StockMes = {stockMesVal.ToString.Replace(",", ".")} WHERE Codigo = '{codigo}' AND Periodo = {periodo} AND Mes = {mes}"
    '                        _Sql.Ej_consulta_IDU(upd, False)
    '                    End If
    '                Next
    '            End If

    '            ' 7) Poblar FechaDesde y FechaHasta para cada fila
    '            Consulta = $"SELECT Codigo, Semana, Periodo, FechaDesde, FechaHasta FROM {TablaCalendarioMesesSemanasProductos}"
    '            Dim dtAll As DataTable = _Sql.Fx_Get_DataTable(Consulta)
    '            If dtAll IsNot Nothing Then
    '                For Each r As DataRow In dtAll.Rows
    '                    Dim codigo As String = r("Codigo").ToString().Replace("'", "''")
    '                    Dim semana As Integer = Convert.ToInt32(r("Semana"))
    '                    Dim periodo As Integer = Convert.ToInt32(r("Periodo"))

    '                    ' Reconstruir FechaBase similar a SQL: DATEADD(WEEK,Semana - SemanaActual, GETDATE()) con ajuste de año
    '                    Dim diffWeeks As Integer = semana - semanaActual
    '                    Dim fechaBase As DateTime = DateAdd(DateInterval.WeekOfYear, diffWeeks, DateTime.Now)
    '                    Dim fechaDesde As DateTime = fechaBase.AddDays(-CInt(fechaBase.DayOfWeek))
    '                    Dim fechaHasta As DateTime = fechaBase.AddDays(6 - CInt(fechaBase.DayOfWeek))

    '                    Dim upd As String = $"UPDATE {TablaCalendarioMesesSemanasProductos} SET FechaDesde = '{fechaDesde:yyyy-MM-dd HH:mm:ss}', FechaHasta = '{fechaHasta:yyyy-MM-dd HH:mm:ss}' WHERE Codigo = '{codigo}' AND Semana = {semana} AND Periodo = {periodo}"
    '                    _Sql.Ej_consulta_IDU(upd, False)
    '                Next
    '            End If

    '            ' 8) Cálculos adicionales: StockNecesarioNMeses y simulaciones
    '            Dim NMes As Integer = 6
    '            Dim XMeses As Integer = 2

    '            ' Obtener rotacion por producto y actualizar StockNecesarioNMeses y StockNecesarioNMenosXMeses
    '            Consulta = $"SELECT Codigo, ISNULL(Rotacion,0) AS Rotacion FROM {TablaPasoRotacion_Productos}"
    '            Dim dtRot As DataTable = _Sql.Fx_Get_DataTable(Consulta)
    '            If dtRot IsNot Nothing Then
    '                For Each r As DataRow In dtRot.Rows
    '                    Dim codigo As String = r("Codigo").ToString().Replace("'", "''")
    '                    Dim rot As Double = Convert.ToDouble(r("Rotacion"))
    '                    Dim sNec As Double = rot * NMes
    '                    Dim sNecMenos As Double = rot * (NMes - XMeses)
    '                    Dim upd As String = $"UPDATE {TablaCalendarioMesesSemanasProductos} SET StockNecesarioNMeses = {sNec.ToString.Replace(",", ".")}, StockNecesarioNMenosXMeses = {sNecMenos.ToString.Replace(",", ".")} WHERE Codigo = '{codigo}'"
    '                    _Sql.Ej_consulta_IDU(upd, False)
    '                Next
    '            End If

    '            ' Simulación mes a mes
    '            Consulta = $"SELECT DISTINCT Codigo FROM {TablaCalendarioMesesSemanasProductos}"
    '            dtCodigos = _Sql.Fx_Get_DataTable(Consulta)
    '            If dtCodigos IsNot Nothing Then
    '                For Each drCodigo As DataRow In dtCodigos.Rows
    '                    Dim codigo As String = drCodigo("Codigo").ToString().Replace("'", "''")

    '                    ' Obtener StockActual inicial y VentaMensual
    '                    Dim dtVals As DataTable = _Sql.Fx_Get_DataTable($"SELECT MAX(StockNecesarioNMeses) AS StockNecesarioNMeses, MAX(VentaMes) AS VentaMes FROM {TablaCalendarioMesesSemanasProductos} WHERE Codigo = '{codigo}'")
    '                    Dim stockActual As Double = 0.0
    '                    Dim ventaMensual As Double = 0.0
    '                    If dtVals IsNot Nothing AndAlso dtVals.Rows.Count > 0 Then
    '                        stockActual = Convert.ToDouble(dtVals.Rows(0)("StockNecesarioNMeses"))
    '                        ventaMensual = Convert.ToDouble(dtVals.Rows(0)("VentaMes"))
    '                    End If

    '                    ' Obtener meses ordenados
    '                    Dim dtMesOrden As DataTable = _Sql.Fx_Get_DataTable($"SELECT DISTINCT Periodo, Mes FROM {TablaCalendarioMesesSemanasProductos} WHERE Codigo = '{codigo}' ORDER BY Periodo, Mes")
    '                    If dtMesOrden Is Nothing Then Continue For

    '                    For Each rm As DataRow In dtMesOrden.Rows
    '                        Dim periodo As Integer = Convert.ToInt32(rm("Periodo"))
    '                        Dim mes As Integer = Convert.ToInt32(rm("Mes"))

    '                        ' Descontar ventas mensuales
    '                        stockActual = stockActual - ventaMensual
    '                        If stockActual < 0 Then stockActual = 0.0

    '                        Dim upd As String = $"UPDATE {TablaCalendarioMesesSemanasProductos} SET StockProyectadoMensual = {stockActual.ToString.Replace(",", ".")} WHERE Codigo = '{codigo}' AND Periodo = {periodo} AND Mes = {mes}"
    '                        _Sql.Ej_consulta_IDU(upd, False)
    '                    Next
    '                Next
    '            End If

    '            ' Simulación semana a semana (StockNecesarioNSemanas se fija igual a StockNecesarioNMeses para compatibilidad con SQL original)
    '            Dim dtAllCods As DataTable = _Sql.Fx_Get_DataTable($"SELECT DISTINCT Codigo FROM {TablaCalendarioMesesSemanasProductos}")
    '            If dtAllCods IsNot Nothing Then
    '                For Each rCod As DataRow In dtAllCods.Rows
    '                    Dim codigo As String = rCod("Codigo").ToString().Replace("'", "''")

    '                    ' Stock inicial y VentaSemanal
    '                    Dim dtVals As DataTable = _Sql.Fx_Get_DataTable($"SELECT MAX(StockNecesarioNSemanas) AS StockNecesarioNSemanas, MAX(VentaSemanal) AS VentaSemanal FROM {TablaCalendarioMesesSemanasProductos} WHERE Codigo = '{codigo}'")
    '                    Dim stockActual As Double = 0.0
    '                    Dim ventaSemanal As Double = 0.0
    '                    If dtVals IsNot Nothing AndAlso dtVals.Rows.Count > 0 Then
    '                        stockActual = Convert.ToDouble(dtVals.Rows(0)("StockNecesarioNSemanas"))
    '                        ventaSemanal = Convert.ToDouble(dtVals.Rows(0)("VentaSemanal"))
    '                    End If

    '                    ' Recorrer semanas ordenadas
    '                    Dim dtSemOrden As DataTable = _Sql.Fx_Get_DataTable($"SELECT DISTINCT Periodo, Semana FROM {TablaCalendarioMesesSemanasProductos} WHERE Codigo = '{codigo}' ORDER BY Periodo, Semana")
    '                    If dtSemOrden Is Nothing Then Continue For

    '                    For Each rs As DataRow In dtSemOrden.Rows
    '                        Dim periodo As Integer = Convert.ToInt32(rs("Periodo"))
    '                        Dim semana As Integer = Convert.ToInt32(rs("Semana"))

    '                        stockActual = stockActual - ventaSemanal
    '                        If stockActual < 0 Then stockActual = 0.0

    '                        Dim upd As String = $"UPDATE {TablaCalendarioMesesSemanasProductos} SET StockProyectadoSemanal = {stockActual.ToString.Replace(",", ".")} WHERE Codigo = '{codigo}' AND Periodo = {periodo} AND Semana = {semana}"
    '                        _Sql.Ej_consulta_IDU(upd, False)
    '                    Next
    '                Next
    '            End If

    '            _Mensaje.EsCorrecto = True
    '            _Mensaje.Mensaje = "Datos insertados y calculados correctamente en la tabla temporal (VB.NET)."
    '            _Mensaje.Icono = MessageBoxIcon.Information
    '            _Mensaje.Detalle = "Insertar detalle en tabla de paso (VB): " & TablaCalendarioMesesSemanasProductos

    '        Catch ex As Exception
    '            _Mensaje.EsCorrecto = False
    '            _Mensaje.Mensaje = ex.Message
    '            _Mensaje.Icono = MessageBoxIcon.Error
    '        End Try

    '        Return _Mensaje

    '    End Function

    Function Fx_InsertarDetalleEn_TablaCalendarioMesesSemanasClasificacion(_Codigo_Nodo_Madre As String) As LsValiciones.Mensajes

        Dim _Mensaje As New LsValiciones.Mensajes

        Try

            Consulta_sql = $"--🔹 2. Insertar semanas y meses para cada producto
--Generamos 52 semanas (1 año) y cruzamos con productos.
--El campo Periodo será YYYY-MM del primer día de la semana.

;WITH Semanas AS (
    SELECT 0 AS n
    UNION ALL SELECT 1
    UNION ALL SELECT 2
    UNION ALL SELECT 3
    UNION ALL SELECT 4
    UNION ALL SELECT 5
    UNION ALL SELECT 6
    UNION ALL SELECT 7
    UNION ALL SELECT 8
    UNION ALL SELECT 9
    UNION ALL SELECT 10
    UNION ALL SELECT 11
    UNION ALL SELECT 12
    UNION ALL SELECT 13
    UNION ALL SELECT 14
    UNION ALL SELECT 15
    UNION ALL SELECT 16
    UNION ALL SELECT 17
    UNION ALL SELECT 18
    UNION ALL SELECT 19
    UNION ALL SELECT 20
    UNION ALL SELECT 21
    UNION ALL SELECT 22
    UNION ALL SELECT 23
    UNION ALL SELECT 24
    UNION ALL SELECT 25
    UNION ALL SELECT 26
    UNION ALL SELECT 27
    UNION ALL SELECT 28
    UNION ALL SELECT 29
    UNION ALL SELECT 30
    UNION ALL SELECT 31
    UNION ALL SELECT 32
    UNION ALL SELECT 33
    UNION ALL SELECT 34
    UNION ALL SELECT 35
    UNION ALL SELECT 36
    UNION ALL SELECT 37
    UNION ALL SELECT 38
    UNION ALL SELECT 39
    UNION ALL SELECT 40
    UNION ALL SELECT 41
    UNION ALL SELECT 42
    UNION ALL SELECT 43
    UNION ALL SELECT 44
    UNION ALL SELECT 45
    UNION ALL SELECT 46
    UNION ALL SELECT 47
    UNION ALL SELECT 48
    UNION ALL SELECT 49
    UNION ALL SELECT 50
    UNION ALL SELECT 51
)
INSERT INTO {TablaCalendarioMesesSemanasClasificacion} (Codigo_Nodo_Madre, Semana, Mes, NombreMes, Periodo)
SELECT
    p.Codigo_Nodo_Madre,
    DATEPART(WEEK, DATEADD(WEEK, s.n, GETDATE())) AS Semana,
    MONTH(DATEADD(WEEK, s.n, GETDATE())) AS Mes,
    DATENAME(MONTH, DATEADD(WEEK, s.n, GETDATE())) AS NombreMes,
    --YEAR(DATEADD(MONTH, n, GETDATE())) AS Periodo
	YEAR(DATEADD(WEEK, s.n, GETDATE())) AS Periodo

FROM {TablaPasoRotacion_Clasificacion} p
CROSS JOIN Semanas s
Where p.Codigo_Nodo_Madre = '{_Codigo_Nodo_Madre}'


--🔹 3. Poblar stock inicial, ventas y llegadas
--- Stock inicial: StockUd1 + StockEnTransitoUd1 en la primera semana.
--- Venta mensual: Rotacion.
--- Venta semanal: Rotacion / 4.
--- Llegadas: se asignan según la fecha FEERLI de la tabla de compras.

-- Poblar stock inicial y ventas
UPDATE c
SET c.StockSemanal = CASE WHEN c.Semana = DATEPART(WEEK, GETDATE()) 
                          THEN p.StockUd1 + p.StockEnTransitoUd1
                          ELSE 0 END,
    c.VentaSemanal = p.Rotacion / 4.0,
    c.VentaMes = p.Rotacion
FROM {TablaCalendarioMesesSemanasClasificacion} c
JOIN {TablaPasoRotacion_Clasificacion} p ON c.Codigo_Nodo_Madre = p.Codigo_Nodo_Madre;

-- Poblar llegadas futuras en semanas y meses

UPDATE c
SET c.LlegadaSemanal = ISNULL(c.LlegadaSemanal,0) + d.TotalSaldo,
    c.LlegadasMes   = ISNULL(c.LlegadasMes,0) + d.TotalSaldo
FROM {TablaCalendarioMesesSemanasClasificacion} c
JOIN (
    SELECT Codigo_Nodo_Madre,
           DATEPART(WEEK, FEERLI) AS Semana,
           YEAR(FEERLI) AS Periodo,
           SUM(Saldo) AS TotalSaldo
    FROM Tbl_Asc_04_DocUltComp_{FUNCIONARIO}
    WHERE TIDO In ('OCC','FCC')
    GROUP BY Codigo_Nodo_Madre, DATEPART(WEEK, FEERLI), YEAR(FEERLI)
) d
    ON c.Codigo_Nodo_Madre = d.Codigo_Nodo_Madre
   AND c.Semana = d.Semana
   AND c.Periodo = d.Periodo;


--🔹 4. Recalcular stock semana a semana

DECLARE @Codigo_Nodo_Madre VARCHAR(13), @Semana INT, @Mes INT, @Periodo VARCHAR(7);
DECLARE @StockActual FLOAT, @VentaSemanal FLOAT, @LlegadasSemanal FLOAT;


DECLARE cur CURSOR FOR
SELECT DISTINCT Codigo_Nodo_Madre FROM {TablaCalendarioMesesSemanasClasificacion};

' Calcular StockSemanal como el stock de la última semana del mes

OPEN cur;
FETCH NEXT FROM cur INTO @Codigo_Nodo_Madre;

WHILE @@FETCH_STATUS = 0
BEGIN
    ' Stock inicial de la clasificación
    SELECT @StockActual = SUM(StockUd1 + StockEnTransitoUd1)
    FROM {TablaPasoRotacion_Clasificacion}
    WHERE Codigo_Nodo_Madre = @Codigo_Nodo_Madre;

    ' Recorremos semanas en orden
    DECLARE semCur CURSOR FOR
    SELECT Semana, Periodo, VentaSemanal, LlegadaSemanal
    FROM {TablaCalendarioMesesSemanasClasificacion}
    WHERE Codigo_Nodo_Madre = @Codigo_Nodo_Madre
    ORDER BY Periodo, Semana;

    OPEN semCur;
    FETCH NEXT FROM semCur INTO @Semana, @Periodo, @VentaSemanal, @LlegadasSemanal;

    WHILE @@FETCH_STATUS = 0
    BEGIN
        ' Si no hay stock inicial, no se descuenta venta
        IF @StockActual = 0
            SET @VentaSemanal = 0;

        ' Aplicar llegadas y ventas
        stockActual = stockActual - ventaAplicada + llegadaSemanal

        ' Evitar negativos
        IF @StockActual < 0
            SET @StockActual = 0;

        ' Actualizar la tabla
        UPDATE {TablaCalendarioMesesSemanasClasificacion}
        SET StockSemanal = @StockActual,
            StockMes = @StockActual
        WHERE Codigo_Nodo_Madre = @Codigo_Nodo_Madre AND Semana = @Semana AND Periodo = @Periodo;

        FETCH NEXT FROM semCur INTO @Semana, @Periodo, @VentaSemanal, @LlegadasSemanal;
    END

    CLOSE semCur;
    DEALLOCATE semCur;

    FETCH NEXT FROM cur INTO @Codigo_Nodo_Madre;
END

CLOSE cur;
DEALLOCATE cur;


' Calcular StockMes como el stock de la última semana del mes
UPDATE c
SET c.StockMes = s.StockSemanal
FROM {TablaCalendarioMesesSemanasClasificacion} c
CROSS APPLY (
    SELECT TOP 1 t.StockSemanal
    FROM {TablaCalendarioMesesSemanasClasificacion} t
    WHERE t.Codigo_Nodo_Madre = c.Codigo_Nodo_Madre
      AND t.Periodo = c.Periodo
      AND t.Mes = c.Mes
    ORDER BY t.Semana DESC
) s;

' Calcular LlegadasMes como la suma de llegadas semanales del mes
UPDATE c
SET c.LlegadasMes = agg.TotalLlegadas
FROM {TablaCalendarioMesesSemanasClasificacion} c
JOIN (
    SELECT Codigo_Nodo_Madre, Periodo, Mes, SUM(LlegadaSemanal) AS TotalLlegadas
    FROM {TablaCalendarioMesesSemanasClasificacion}
    GROUP BY Codigo_Nodo_Madre, Periodo, Mes
) agg
ON c.Codigo_Nodo_Madre = agg.Codigo_Nodo_Madre
AND c.Periodo = agg.Periodo
AND c.Mes = agg.Mes;


' Poblar fechas desde/hasta para cada semana
UPDATE c
SET c.FechaDesde = DATEADD(DAY, 1 - DATEPART(WEEKDAY, f.FechaBase), f.FechaBase),
    c.FechaHasta = DATEADD(DAY, 7 - DATEPART(WEEKDAY, f.FechaBase), f.FechaBase)
FROM {TablaCalendarioMesesSemanasClasificacion} c
CROSS APPLY (
    SELECT DATEADD(
               WEEK,
               c.Semana - DATEPART(WEEK, DATEADD(YEAR, c.Periodo - YEAR(GETDATE()), GETDATE())),
               DATEADD(YEAR, c.Periodo - YEAR(GETDATE()), GETDATE())
           ) AS FechaBase
) f;
;
"
            If Not _Sql.Ej_consulta_IDU(Consulta_sql) Then
                ' Lanzar error aquí con información útil para depuración
                Throw New Exception(String.Format("Error al ejecutar la consulta para insertar datos en la tabla '{0}'. Consulta: {1}", TablaCalendarioMesesSemanasClasificacion, Consulta_sql))
            End If

            _Mensaje.EsCorrecto = True
            _Mensaje.Mensaje = "Datos insertados correctamente en la tabla temporal."
            _Mensaje.Icono = MessageBoxIcon.Information
            _Mensaje.Detalle = "Insertar detalle en tabla de paso: " & TablaCalendarioMesesSemanasClasificacion

        Catch ex As Exception
            ' (Opcional) Registrar o asignar información al objeto _Mensaje si la estructura lo permite
            _Mensaje.EsCorrecto = False
            _Mensaje.Mensaje = ex.Message
            _Mensaje.Icono = MessageBoxIcon.Error
            ' Volver a lanzar la excepción para que el llamador la maneje y preserve la pila
            'Throw
        End Try

        Return _Mensaje

    End Function

    Function Fx_CrearTablaPaso_TablaCalendarioMesesSemanasProductos() As LsValiciones.Mensajes

        Dim _Mensaje As New LsValiciones.Mensajes

        'Sb_Eliminar_TablasDePasoRotacion()

        Try

            Consulta_sql = "DROP TABLE " & TablaCalendarioMesesSemanasProductos
            _Sql.Ej_consulta_IDU(Consulta_sql, False)

            Consulta_sql = $"-- 🔹 1. Crear tabla calendario extendida
CREATE TABLE {TablaCalendarioMesesSemanasProductos} (
    Codigo VARCHAR(13),
	Codigo_Nodo_Madre VARCHAR(50),
    Semana INT,
    StockSemanal FLOAT DEFAULT(0),
    VentaSemanal FLOAT DEFAULT(0),
    LlegadaSemanal FLOAT DEFAULT(0),
    Mes INT,
    NombreMes VARCHAR(20),
    Periodo Int, -- formato YYYY-MM
    StockMes FLOAT DEFAULT(0),
    VentaMes FLOAT DEFAULT(0),
    LlegadasMes Float DEFAULT(0),
    LlegadasSemanales Float DEFAULT(0),
    FechaDesde Datetime,
    FechaHasta Datetime,
    FechaSemanaInicio Datetime,
    StockNecesarioNMeses FLOAT DEFAULT(0),			-- stock requerido para cubrir N meses
    StockProyectadoMensual FLOAT DEFAULT(0),		-- stock que va bajando mes a mes
    StockNecesarioNMenosXMeses FLOAT DEFAULT(0),
    StockNecesarioNSemanas FLOAT DEFAULT(0),       -- stock requerido para N semanas
    StockProyectadoSemanal FLOAT DEFAULT(0) 
);"

            If Not _Sql.Ej_consulta_IDU(Consulta_sql) Then
                ' Lanzar error aquí con información útil para depuración
                Throw New Exception(String.Format("Error al ejecutar la consulta para crear la tabla '{0}'. Consulta: {1}", TablaCalendarioMesesSemanasProductos, Consulta_sql))
            End If

            _Mensaje.EsCorrecto = True
            _Mensaje.Mensaje = "Tabla temporal creada correctamente."
            _Mensaje.Icono = MessageBoxIcon.Information
            _Mensaje.Detalle = "Crear tabla de paso: " & TablaCalendarioMesesSemanasProductos

        Catch ex As Exception
            ' (Opcional) Registrar o asignar información al objeto _Mensaje si la estructura lo permite
            _Mensaje.EsCorrecto = False
            _Mensaje.Mensaje = ex.Message
            _Mensaje.Icono = MessageBoxIcon.Error
            ' Volver a lanzar la excepción para que el llamador la maneje y preserve la pila
            'Throw
        End Try

        Return _Mensaje

    End Function

    Function Fx_InsertarDetalleEn_TablaCalendarioMesesSemanasProductos(_Codigo_Nodo_Madre As String) As LsValiciones.Mensajes

        Dim _Mensaje As New LsValiciones.Mensajes

        Try

            Consulta_sql = $"--🔹 2. Insertar semanas y meses para cada producto
--Generamos 52 semanas (1 año) y cruzamos con productos.
--El campo Periodo será YYYY-MM del primer día de la semana.

;WITH Semanas AS (
    SELECT 0 AS n
    UNION ALL SELECT 1
    UNION ALL SELECT 2
    UNION ALL SELECT 3
    UNION ALL SELECT 4
    UNION ALL SELECT 5
    UNION ALL SELECT 6
    UNION ALL SELECT 7
    UNION ALL SELECT 8
    UNION ALL SELECT 9
    UNION ALL SELECT 10
    UNION ALL SELECT 11
    UNION ALL SELECT 12
    UNION ALL SELECT 13
    UNION ALL SELECT 14
    UNION ALL SELECT 15
    UNION ALL SELECT 16
    UNION ALL SELECT 17
    UNION ALL SELECT 18
    UNION ALL SELECT 19
    UNION ALL SELECT 20
    UNION ALL SELECT 21
    UNION ALL SELECT 22
    UNION ALL SELECT 23
    UNION ALL SELECT 24
    UNION ALL SELECT 25
    UNION ALL SELECT 26
    UNION ALL SELECT 27
    UNION ALL SELECT 28
    UNION ALL SELECT 29
    UNION ALL SELECT 30
    UNION ALL SELECT 31
    UNION ALL SELECT 32
    UNION ALL SELECT 33
    UNION ALL SELECT 34
    UNION ALL SELECT 35
    UNION ALL SELECT 36
    UNION ALL SELECT 37
    UNION ALL SELECT 38
    UNION ALL SELECT 39
    UNION ALL SELECT 40
    UNION ALL SELECT 41
    UNION ALL SELECT 42
    UNION ALL SELECT 43
    UNION ALL SELECT 44
    UNION ALL SELECT 45
    UNION ALL SELECT 46
    UNION ALL SELECT 47
    UNION ALL SELECT 48
    UNION ALL SELECT 49
    UNION ALL SELECT 50
    UNION ALL SELECT 51
)
INSERT INTO {TablaCalendarioMesesSemanasProductos} (Codigo, Codigo_Nodo_Madre, Semana, Mes, NombreMes, Periodo)
SELECT
    p.Codigo,p.Codigo_Nodo_Madre,
    DATEPART(WEEK, DATEADD(WEEK, s.n, GETDATE())) AS Semana,
    MONTH(DATEADD(WEEK, s.n, GETDATE())) AS Mes,
    DATENAME(MONTH, DATEADD(WEEK, s.n, GETDATE())) AS NombreMes,
    --YEAR(DATEADD(MONTH, n, GETDATE())) AS Periodo
	YEAR(DATEADD(WEEK, s.n, GETDATE())) AS Periodo

FROM {TablaPasoRotacion_Productos} p
CROSS JOIN Semanas s
Where p.Codigo_Nodo_Madre = '{_Codigo_Nodo_Madre}'


--🔹 3. Poblar stock inicial, ventas y llegadas
--- Stock inicial: StockUd1 + StockEnTransitoUd1 en la primera semana.
--- Venta mensual: Rotacion.
--- Venta semanal: Rotacion / 4.
--- Llegadas: se asignan según la fecha FEERLI de la tabla de compras.

-- Poblar stock inicial y ventas
UPDATE c
SET c.StockSemanal = CASE WHEN c.Semana = DATEPART(WEEK, GETDATE()) 
                          THEN p.StockUd1 + p.StockEnTransitoUd1
                          ELSE 0 END,
    c.VentaSemanal = p.Rotacion / 4.0,
    c.VentaMes = p.Rotacion
FROM {TablaCalendarioMesesSemanasProductos} c
JOIN {TablaPasoRotacion_Productos} p ON c.Codigo = p.Codigo;

-- Poblar llegadas futuras en semanas y meses

UPDATE c
SET c.LlegadaSemanal = ISNULL(c.LlegadaSemanal,0) + d.TotalSaldo,
    c.LlegadasMes   = ISNULL(c.LlegadasMes,0) + d.TotalSaldo
FROM {TablaCalendarioMesesSemanasProductos} c
JOIN (
    SELECT Codigo,
           DATEPART(WEEK, FEERLI) AS Semana,
           YEAR(FEERLI) AS Periodo,
           SUM(Saldo) AS TotalSaldo
    FROM Tbl_Asc_04_DocUltComp_{FUNCIONARIO}
    WHERE TIDO In ('OCC','FCC')
    GROUP BY Codigo, DATEPART(WEEK, FEERLI), YEAR(FEERLI)
) d
    ON c.Codigo = d.Codigo
   AND c.Semana = d.Semana
   AND c.Periodo = d.Periodo;



--🔹 4. Recalcular stock semana a semana

DECLARE @Codigo VARCHAR(13), @Semana INT, @Mes INT, @Periodo VARCHAR(7);
DECLARE @StockActual FLOAT, @VentaSemanal FLOAT, @LlegadasSemanal FLOAT;


DECLARE cur CURSOR FOR
SELECT DISTINCT Codigo FROM {TablaCalendarioMesesSemanasProductos};

' Calcular StockSemanal como el stock de la última semana del mes

OPEN cur;
FETCH NEXT FROM cur INTO @Codigo;

WHILE @@FETCH_STATUS = 0
BEGIN
    ' Stock inicial del producto
    SELECT @StockActual = StockUd1 + StockEnTransitoUd1
    FROM {TablaPasoRotacion_Productos}
    WHERE Codigo = @Codigo;

    ' Recorremos semanas en orden
    DECLARE semCur CURSOR FOR
    SELECT Semana, Periodo, VentaSemanal, LlegadaSemanal
    FROM {TablaCalendarioMesesSemanasProductos}
    WHERE Codigo = @Codigo
    ORDER BY Periodo, Semana;

    OPEN semCur;
    FETCH NEXT FROM semCur INTO @Semana, @Periodo, @VentaSemanal, @LlegadasSemanal;

    WHILE @@FETCH_STATUS = 0
    BEGIN
        ' Si no hay stock inicial, no se descuenta venta
        IF @StockActual = 0
            SET @VentaSemanal = 0;

        ' Aplicar llegadas y ventas
        stockActual = stockActual - ventaAplicada + llegadaSemanal

        ' Evitar negativos
        IF @StockActual < 0
            SET @StockActual = 0;

        ' Actualizar la tabla
        UPDATE {TablaCalendarioMesesSemanasProductos}
        SET StockSemanal = @StockActual,
            StockMes = @StockActual
        WHERE Codigo = @Codigo AND Semana = @Semana AND Periodo = @Periodo;

        FETCH NEXT FROM semCur INTO @Semana, @Periodo, @VentaSemanal, @LlegadasSemanal;
    END

    CLOSE semCur;
    DEALLOCATE semCur;

    FETCH NEXT FROM cur INTO @Codigo;
END

CLOSE cur;
DEALLOCATE cur;


' Calcular StockMes como el stock de la última semana del mes
UPDATE c
SET c.StockMes = s.StockSemanal
FROM {TablaCalendarioMesesSemanasProductos} c
CROSS APPLY (
    SELECT TOP 1 t.StockSemanal
    FROM {TablaCalendarioMesesSemanasProductos} t
    WHERE t.Codigo = c.Codigo
      AND t.Periodo = c.Periodo
      AND t.Mes = c.Mes
    ORDER BY t.Semana DESC
) s;

' Calcular LlegadasMes como la suma de llegadas semanales del mes
UPDATE c
SET c.LlegadasMes = agg.TotalLlegadas
FROM {TablaCalendarioMesesSemanasProductos} c
JOIN (
    SELECT Codigo, Periodo, Mes, SUM(LlegadaSemanal) AS TotalLlegadas
    FROM {TablaCalendarioMesesSemanasProductos}
    GROUP BY Codigo, Periodo, Mes
) agg
ON c.Codigo = agg.Codigo
AND c.Periodo = agg.Periodo
AND c.Mes = agg.Mes;


' Poblar fechas desde/hasta para cada semana
UPDATE c
SET c.FechaDesde = DATEADD(DAY, 1 - DATEPART(WEEKDAY, f.FechaBase), f.FechaBase),
    c.FechaHasta = DATEADD(DAY, 7 - DATEPART(WEEKDAY, f.FechaBase), f.FechaBase)
FROM {TablaCalendarioMesesSemanasProductos} c
CROSS APPLY (
    SELECT DATEADD(WEEK, c.Semana - DATEPART(WEEK, GETDATE()), GETDATE()) AS FechaBase
) f;



' Para agregar nuevos calculos que me pasa Gonzalo

DECLARE @NMes Int = 6; -- horizonte en meses (variable)
DECLARE @XMeses Int = 2;

' 1. Calcular stock necesario para N meses y N-2 meses
UPDATE c
SET c.StockNecesarioNMeses = p.Rotacion * @NMes,
    c.StockNecesarioNMenosXMeses = p.Rotacion * (@NMes - @XMeses)
FROM {TablaCalendarioMesesSemanasProductos} c
JOIN {TablaPasoRotacion_Productos} p ON c.Codigo = p.Codigo;



' 2. Simular consumo Mes a Mes

DECLARE @VentaMensual FLOAT;

DECLARE cur CURSOR FOR
SELECT DISTINCT Codigo FROM {TablaCalendarioMesesSemanasProductos};

OPEN cur;
FETCH NEXT FROM cur INTO @Codigo;

WHILE @@FETCH_STATUS = 0
BEGIN
    ' Stock inicial = stock necesario para N meses
    SELECT @StockActual = MAX(StockNecesarioNMeses)+MAX(VentaMes),
           @VentaMensual = MAX(VentaMes)
    FROM {TablaCalendarioMesesSemanasProductos}
    WHERE Codigo = @Codigo;

    ' Recorrer meses en orden
    DECLARE mesCur CURSOR FOR
    SELECT Mes, Periodo
    FROM {TablaCalendarioMesesSemanasProductos}
    WHERE Codigo = @Codigo
    GROUP BY Mes, Periodo
    ORDER BY Periodo, Mes;


    OPEN mesCur;
    FETCH NEXT FROM mesCur INTO @Mes, @Periodo;

    WHILE @@FETCH_STATUS = 0
    BEGIN
       ' Descontar solo ventas mensuales (sin sumar llegadas)
        SET @StockActual = @StockActual - @VentaMensual;
        IF @StockActual < 0 SET @StockActual = 0;

        ' Actualizar campo StockProyectado en todas las semanas del mes
        UPDATE {TablaCalendarioMesesSemanasProductos}
        SET StockProyectadoMensual = @StockActual
        WHERE Codigo = @Codigo AND Mes = @Mes AND Periodo = @Periodo;

        FETCH NEXT FROM mesCur INTO @Mes, @Periodo;
    END

    CLOSE mesCur;
    DEALLOCATE mesCur;

    FETCH NEXT FROM cur INTO @Codigo;
END

CLOSE cur;
DEALLOCATE cur;


'DECLARE @NSem INT = @NMes * 24; -- horizonte en semanas (variable)

' 1. Calcular stock necesario para N semanas y N-2 semanas
UPDATE c
SET c.StockNecesarioNSemanas = c.StockNecesarioNMeses --c.VentaSemanal * @NSem
    ' c.StockNecesarioNSemanasMenos2 = c.VentaSemanal * (@NSem - 2)
FROM {TablaCalendarioMesesSemanasProductos} c;

' 2. Simular consumo semana a semana

DECLARE cur CURSOR FOR
SELECT DISTINCT Codigo FROM {TablaCalendarioMesesSemanasProductos};

OPEN cur;
FETCH NEXT FROM cur INTO @Codigo;

WHILE @@FETCH_STATUS = 0
BEGIN
    ' Stock inicial = stock necesario para N semanas
    SELECT @StockActual = MAX(StockNecesarioNSemanas)+MAX(VentaSemanal),
           @VentaSemanal = MAX(VentaSemanal)
    FROM {TablaCalendarioMesesSemanasProductos}
    WHERE Codigo = @Codigo;

    ' Recorrer semanas en orden
    DECLARE semCur CURSOR FOR
    SELECT Semana, Periodo
    FROM {TablaCalendarioMesesSemanasProductos}
    WHERE Codigo = @Codigo
    ORDER BY Periodo, Semana;

    OPEN semCur;
    FETCH NEXT FROM semCur INTO @Semana, @Periodo;

    WHILE @@FETCH_STATUS = 0
    BEGIN
        ' Descontar ventas semanales
        SET @StockActual = @StockActual - @VentaSemanal;
        IF @StockActual < 0 SET @StockActual = 0;

        ' Actualizar campo StockProyectadoSemanal
        UPDATE {TablaCalendarioMesesSemanasProductos}
        SET StockProyectadoSemanal = @StockActual
        WHERE Codigo = @Codigo AND Semana = @Semana AND Periodo = @Periodo;

        FETCH NEXT FROM semCur INTO @Semana, @Periodo;
    END

    CLOSE semCur;
    DEALLOCATE semCur;

    FETCH NEXT FROM cur INTO @Codigo;
END

CLOSE cur;
DEALLOCATE cur;

"
            If Not _Sql.Ej_consulta_IDU(Consulta_sql) Then
                ' Lanzar error aquí con información útil para depuración
                Throw New Exception(String.Format("Error al ejecutar la consulta para insertar datos en la tabla '{0}'. Consulta: {1}", TablaCalendarioMesesSemanasProductos, Consulta_sql))
            End If

            _Mensaje.EsCorrecto = True
            _Mensaje.Mensaje = "Datos insertados correctamente en la tabla temporal."
            _Mensaje.Icono = MessageBoxIcon.Information
            _Mensaje.Detalle = "Insertar detalle en tabla de paso: " & TablaCalendarioMesesSemanasProductos

        Catch ex As Exception
            ' (Opcional) Registrar o asignar información al objeto _Mensaje si la estructura lo permite
            _Mensaje.EsCorrecto = False
            _Mensaje.Mensaje = ex.Message
            _Mensaje.Icono = MessageBoxIcon.Error
            ' Volver a lanzar la excepción para que el llamador la maneje y preserve la pila
            'Throw
        End Try

        Return _Mensaje

    End Function

    Function Fx_InsertarDetalleEn_TablaCalendarioMesesSemanasProductos_VB(_Codigo_Nodo_Madre As String,
                                                                          _Codigo As String) As LsValiciones.Mensajes

        Dim _Mensaje As New LsValiciones.Mensajes

        Try
            ' 1) Crear tabla si no existe (reutiliza método de la clase)
            Dim _crea = Fx_CrearTablaPaso_TablaCalendarioMesesSemanasProductos()
            If Not _crea.EsCorrecto Then
                _Mensaje.EsCorrecto = False
                _Mensaje.Mensaje = "No se pudo crear la tabla temporal: " & _crea.Mensaje
                _Mensaje.Icono = MessageBoxIcon.Error
                Return _Mensaje
            End If

            ' 2) Leer productos de la clasificación

            Consulta_sql = "SELECT Codigo,Codigo_Nodo_Madre,ISNULL(StockUd1,0) AS StockUd1,ISNULL(StockEnTransitoUd1,0) AS StockEnTransitoUd1," &
                           "ISNULL(StockPedidoUd1,0) AS StockPedidoUd1,ISNULL(StockFacSinRecepUd1,0) AS StockFacSinRecepUd1,ISNULL(Rotacion,0) AS Rotacion" & vbCrLf &
                           $"FROM {TablaPasoRotacion_Productos}" & vbCrLf &
                           $"WHERE Codigo_Nodo_Madre = '{_Codigo_Nodo_Madre}' And Codigo = '{_Codigo}'" & vbCrLf &
                           $"And (ISNULL(StockUd1,0)+ISNULL(StockEnTransitoUd1,0)+ISNULL(StockPedidoUd1,0)+ISNULL(StockFacSinRecepUd1,0)) > 0"

            Dim dtProductos As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

            If dtProductos Is Nothing OrElse dtProductos.Rows.Count = 0 Then
                ' Nada que insertar
                _Mensaje.EsCorrecto = False
                _Mensaje.Mensaje = "No hay productos para la clasificación indicada."
                _Mensaje.Icono = MessageBoxIcon.Information
                Return _Mensaje
            End If

            ' 3) Construir INSERT masivo para 52 semanas
            Dim sbInsert As New System.Text.StringBuilder()
            'Consulta_sql = $"INSERT INTO {TablaCalendarioMesesSemanasProductos} (Codigo, Codigo_Nodo_Madre, Semana, StockSemanal, VentaSemanal, LlegadaSemanal, Mes, NombreMes, Periodo, StockMes, VentaMes, LlegadasMes, FechaDesde, FechaHasta, StockNecesarioNMeses, StockProyectadoMensual, StockNecesarioNMenosXMeses, StockNecesarioNSemanas, StockProyectadoSemanal) VALUES"
            'sbInsert.AppendLine(Consulta_sql)

            Dim ci As New Globalization.CultureInfo("es-ES")
            Dim semanaActual As Integer = DatePart(DateInterval.WeekOfYear, DateTime.Now)
            Dim filas As New List(Of String)

            For Each dr As DataRow In dtProductos.Rows

                Dim codigo As String = dr("Codigo").ToString().Replace("'", "''")
                Dim codigoNodo As String = dr("Codigo_Nodo_Madre").ToString().Replace("'", "''")

                Dim stockUd1 As Double = Convert.ToDouble(dr("StockUd1"))
                Dim stockEnTransito As Double = Convert.ToDouble(dr("StockEnTransitoUd1"))
                Dim stockPedido As Double = Convert.ToDouble(dr("StockPedidoUd1"))
                Dim stockFacSinRecep As Double = Convert.ToDouble(dr("StockFacSinRecepUd1"))
                Dim stock As Double = stockUd1 + stockEnTransito + stockPedido + stockFacSinRecep
                Dim rotacion As Double = Convert.ToDouble(dr("Rotacion"))

                If Not CBool(stock) Then
                    Continue For
                End If

                For n As Integer = 0 To 51
                    Dim fechaBase As DateTime = DateAdd(DateInterval.WeekOfYear, n, DateTime.Now)
                    Dim semana As Integer = DatePart(DateInterval.WeekOfYear, fechaBase)
                    Dim mes As Integer = fechaBase.Month
                    Dim nombreMes As String = fechaBase.ToString("MMMM", ci)
                    Dim periodo As Integer = fechaBase.Year
                    Dim stockSemanal As Double = If(semana = semanaActual, stockUd1 + stockEnTransito, 0.0)
                    Dim ventaSemanal As Double = rotacion / 4.0
                    Dim ventaMes As Double = rotacion
                    Dim llegadaSemanal As Double = 0.0
                    Dim llegadasMes As Double = 0.0
                    Dim fechaDesde As DateTime = fechaBase.AddDays(-CInt(fechaBase.DayOfWeek))
                    Dim fechaHasta As DateTime = fechaBase.AddDays(6 - CInt(fechaBase.DayOfWeek))
                    Dim stockNecesarioNMeses As Double = 0.0
                    Dim stockProyectadoMensual As Double = 0.0
                    Dim stockNecesarioNMenosXMeses As Double = 0.0
                    Dim stockNecesarioNSemanas As Double = 0.0
                    Dim stockProyectadoSemanal As Double = 0.0

                    Consulta_sql = $"INSERT INTO {TablaCalendarioMesesSemanasProductos} (Codigo, Codigo_Nodo_Madre, Semana, StockSemanal, VentaSemanal, LlegadaSemanal, Mes, NombreMes, Periodo, StockMes, VentaMes, LlegadasMes, FechaDesde, FechaHasta, StockNecesarioNMeses, StockProyectadoMensual, StockNecesarioNMenosXMeses, StockNecesarioNSemanas, StockProyectadoSemanal) VALUES"
                    sbInsert.AppendLine(Consulta_sql)

                    Consulta_sql = $"('{codigo}','{codigoNodo}',{semana},{stockSemanal.ToString.Replace(",", ".")},
                                  {ventaSemanal.ToString.Replace(",", ".")},{llegadaSemanal.ToString.Replace(",", ".")},{mes},
                                  '{nombreMes.Replace("'", "''")}',{periodo},{stockSemanal.ToString.Replace(",", ".")},
                                  {ventaMes.ToString.Replace(",", ".")},{llegadasMes.ToString.Replace(",", ".")}
                                  ,'{Format(fechaDesde, "yyyyMMdd")}','{Format(fechaHasta, "yyyyMMdd")}',
                                  {stockNecesarioNMeses.ToString.Replace(",", ".")},
                                  {stockProyectadoMensual.ToString.Replace(",", ".")},
                                  {stockNecesarioNMenosXMeses.ToString.Replace(",", ".")},
                                  {stockNecesarioNSemanas.ToString.Replace(",", ".")},
                                  {stockProyectadoSemanal.ToString.Replace(",", ".")})"
                    sbInsert.AppendLine(Consulta_sql)

                    'filas.Add($"('{codigo}','{codigoNodo}',{semana},{stockSemanal.ToString.Replace(",", ".")},
                    '              {ventaSemanal.ToString.Replace(",", ".")},{llegadaSemanal.ToString.Replace(",", ".")},{mes},
                    '              '{nombreMes.Replace("'", "''")}',{periodo},{stockSemanal.ToString.Replace(",", ".")},
                    '              {ventaMes.ToString.Replace(",", ".")},{llegadasMes.ToString.Replace(",", ".")}
                    '              ,'{Format(fechaDesde, "yyyyMMdd")}','{Format(fechaHasta, "yyyyMMdd")}',
                    '              {stockNecesarioNMeses.ToString.Replace(",", ".")},
                    '              {stockProyectadoMensual.ToString.Replace(",", ".")},
                    '              {stockNecesarioNMenosXMeses.ToString.Replace(",", ".")},
                    '              {stockNecesarioNSemanas.ToString.Replace(",", ".")},
                    '              {stockProyectadoSemanal.ToString.Replace(",", ".")})")
                Next

                'If filas.Count > 0 Then
                'sbInsert.AppendLine(String.Join("," & vbCrLf, filas))
                If Not _Sql.Ej_consulta_IDU(sbInsert.ToString) Then
                    Throw New Exception("Error al insertar filas iniciales en tabla calendario (insert masivo).")
                End If
                'End If

                sbInsert.Clear()

            Next

            ' 4) Poblar llegadas semanales y mensuales desde Tbl_Asc_04_DocUltComp_{FUNCIONARIO}
            Consulta_sql = $"SELECT Codigo, DATEPART(WEEK, FEERLI) AS Semana, YEAR(FEERLI) AS Periodo, SUM(Saldo) AS TotalSaldo" & vbCrLf &
                           $"FROM Tbl_Asc_04_DocUltComp_{FUNCIONARIO}" & vbCrLf &
                           $"WHERE TIDO IN ('OCC','FCC') And Codigo_Nodo_Madre = '{_Codigo_Nodo_Madre}' And Codigo = '{_Codigo}'" & vbCrLf &
                           "GROUP BY Codigo, DATEPART(WEEK, FEERLI), YEAR(FEERLI)"

            Dim dtLlegadas As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

            If dtLlegadas IsNot Nothing AndAlso dtLlegadas.Rows.Count > 0 Then
                For Each dr As DataRow In dtLlegadas.Rows
                    Dim codigo As String = dr("Codigo").ToString().Replace("'", "''")
                    Dim semana As Integer = Convert.ToInt32(dr("Semana"))
                    Dim periodo As Integer = Convert.ToInt32(dr("Periodo"))
                    Dim totalSaldo As Double = Convert.ToDouble(dr("TotalSaldo"))
                    Consulta_sql = $"UPDATE {TablaCalendarioMesesSemanasProductos} SET LlegadaSemanal = ISNULL(LlegadaSemanal,0) + {totalSaldo.ToString.Replace(",", ".")}, LlegadasMes = ISNULL(LlegadasMes,0) + {totalSaldo.ToString.Replace(",", ".")} WHERE Codigo = '{codigo}' AND Semana = {semana} AND Periodo = {periodo}"
                    _Sql.Ej_consulta_IDU(Consulta_sql, False)
                Next
            End If

            Dim ventaSemanalDef As Double = 0.0
            Dim ventaPrimeraSemanalDef As Double = 0.0

            ' 5) Recalcular stock semana a semana en VB para cada Codigo
            Consulta_sql = $"SELECT DISTINCT Codigo FROM {TablaCalendarioMesesSemanasProductos} Where Codigo_Nodo_Madre = '{_Codigo_Nodo_Madre}' And Codigo = '{_Codigo}'"
            Dim dtCodigos As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)
            If dtCodigos IsNot Nothing Then
                For Each drCodigo As DataRow In dtCodigos.Rows
                    Dim codigo As String = drCodigo("Codigo").ToString().Replace("'", "''")

                    ' Obtener stock inicial y rotacion del producto
                    Consulta_sql = $"SELECT ISNULL(StockUd1,0) AS StockUd1, ISNULL(StockEnTransitoUd1,0) AS StockEnTransitoUd1, ISNULL(Rotacion,0) AS Rotacion FROM {TablaPasoRotacion_Productos} WHERE Codigo = '{codigo}'"
                    Dim dtProd As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)
                    Dim stockActual As Double = 0.0

                    If dtProd IsNot Nothing AndAlso dtProd.Rows.Count > 0 Then
                        stockActual = Convert.ToDouble(dtProd.Rows(0)("StockUd1")) + Convert.ToDouble(dtProd.Rows(0)("StockEnTransitoUd1"))
                        ventaSemanalDef = Convert.ToDouble(dtProd.Rows(0)("Rotacion")) / 4.0
                    End If

                    ' Leer semanas ordenadas
                    Consulta_sql = $"SELECT Semana, Periodo, ISNULL(VentaSemanal,0) AS VentaSemanal, ISNULL(LlegadaSemanal,0) AS LlegadaSemanal FROM {TablaCalendarioMesesSemanasProductos} WHERE Codigo = '{codigo}' ORDER BY Periodo, Semana"
                    Dim dtSemanas As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)
                    If dtSemanas Is Nothing Then Continue For

                    Dim indexWeek As Integer = 0
                    ' Calcular valores relacionados con la semana actual para aplicar la fracción en la segunda semana
                    Dim semanaActualLocal As Integer = DatePart(DateInterval.WeekOfYear, DateTime.Now)
                    Dim periodoActual As Integer = DateTime.Now.Year
                    ' Para el cálculo de días restantes se asume semana que comienza el lunes
                    Dim dow As Integer = If(DateTime.Now.DayOfWeek = DayOfWeek.Sunday, 7, CInt(DateTime.Now.DayOfWeek))
                    Dim daysRemainingInclusive As Integer = 7 - dow + 1 ' ejemplo: miércoles -> 5 días (mié..dom)

                    ventaPrimeraSemanalDef = Math.Round(ventaSemanalDef * (daysRemainingInclusive / 7.0), 2)

                    For Each rs As DataRow In dtSemanas.Rows
                        Dim ventaSemanalTabla As Double = Convert.ToDouble(rs("VentaSemanal"))
                        Dim llegadaSemanal As Double = Convert.ToDouble(rs("LlegadaSemanal"))

                        Dim ventaAplicada As Double

                        Dim semana As Integer = Convert.ToInt32(rs("Semana"))
                        Dim periodo As Integer = Convert.ToInt32(rs("Periodo"))

                        If indexWeek = 0 Then
                            ' Primera semana: no descontar ventas (se mantiene el stock inicial)
                            ventaAplicada = 0.0
                        ElseIf indexWeek = 1 Then
                            ' Segunda semana: descontar proporcional según los días restantes de la primera semana
                            ventaAplicada = ventaPrimeraSemanalDef 'Math.Round(ventaSemanalDef * (daysRemainingInclusive / 7.0), 2)
                        Else
                            ' Semanas siguientes: descuento de venta semanal completa
                            ventaAplicada = ventaSemanalDef
                        End If

                        ' Si no hay stock inicial, no se descuenta venta
                        If stockActual = 0 Then
                            ventaAplicada = 0.0
                        End If

                        ' Aplicar llegadas y ventas
                        stockActual = Math.Round(stockActual - ventaAplicada + llegadaSemanal, 2)

                        ' Evitar negativos
                        If stockActual < 0 Then stockActual = 0.0

                        Consulta_sql = $"UPDATE {TablaCalendarioMesesSemanasProductos}" & vbCrLf &
                                       $"SET StockSemanal = {stockActual.ToString.Replace(",", ".")}, StockMes = {stockActual.ToString.Replace(",", ".")}" & vbCrLf &
                                       $"WHERE Codigo = '{codigo}' AND Semana = {semana} AND Periodo = {periodo}"
                        _Sql.Ej_consulta_IDU(Consulta_sql, False)

                        indexWeek += 1
                    Next
                Next
            End If

            ' 6) Consolidación mensual en VB: StockMes = stock de la última semana del mes
            Consulta_sql = $"SELECT DISTINCT Codigo, Periodo, Mes FROM {TablaCalendarioMesesSemanasProductos} Where Codigo = '{_Codigo}' ORDER BY Codigo, Periodo, Mes"
            Dim dtMeses As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)
            If dtMeses IsNot Nothing Then
                For Each drMes As DataRow In dtMeses.Rows
                    Dim codigo As String = drMes("Codigo").ToString().Replace("'", "''")
                    Dim periodo As Integer = Convert.ToInt32(drMes("Periodo"))
                    Dim mes As Integer = Convert.ToInt32(drMes("Mes"))

                    ' Obtener la última semana del mes para este producto
                    Consulta_sql = $"SELECT TOP 1 StockSemanal FROM {TablaCalendarioMesesSemanasProductos} WHERE Codigo = '{codigo}' AND Periodo = {periodo} AND Mes = {mes} ORDER BY Semana DESC"
                    Dim dtUltSemana As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)
                    If dtUltSemana IsNot Nothing AndAlso dtUltSemana.Rows.Count > 0 Then
                        Dim stockMesVal As Double = Convert.ToDouble(dtUltSemana.Rows(0)("StockSemanal"))
                        Dim upd As String = $"UPDATE {TablaCalendarioMesesSemanasProductos} SET StockMes = {stockMesVal.ToString.Replace(",", ".")} WHERE Codigo = '{codigo}' AND Periodo = {periodo} AND Mes = {mes}"
                        _Sql.Ej_consulta_IDU(upd, False)
                    End If
                Next
            End If

            ' 7) Poblar FechaDesde y FechaHasta para cada fila
            Consulta_sql = $"SELECT Codigo, Semana, Periodo, FechaDesde, FechaHasta FROM {TablaCalendarioMesesSemanasProductos} Where Codigo = '{_Codigo}'"
            Dim dtAll As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)
            If dtAll IsNot Nothing Then
                ' Mantener control de los primeros registros por Codigo: si es el primer registro, FechaDesde = hoy
                Dim primerosPorCodigo As New System.Collections.Generic.HashSet(Of String)(StringComparer.OrdinalIgnoreCase)
                For Each r As DataRow In dtAll.Rows
                    Dim codigo As String = r("Codigo").ToString().Replace("'", "''")
                    Dim semana As Integer = Convert.ToInt32(r("Semana"))
                    Dim periodo As Integer = Convert.ToInt32(r("Periodo"))

                    ' Reconstruir FechaBase similar a SQL: DATEADD(WEEK,Semana - SemanaActual, GETDATE()) con ajuste de año
                    Dim diffWeeks As Integer = semana - semanaActual
                    Dim fechaBase As DateTime = DateAdd(DateInterval.WeekOfYear, diffWeeks, DateTime.Now)

                    Dim fechaDesde As DateTime
                    Dim fechaHasta As DateTime

                    If Not primerosPorCodigo.Contains(codigo) Then
                        ' Si es el primer registro para este Codigo, FechaDesde debe ser la fecha de hoy
                        fechaDesde = DateTime.Now
                        ' Calcular FechaHasta a partir de la FechaDesde (misma lógica de fin de semana utilizada en el resto)
                        fechaHasta = fechaDesde.AddDays(6 - CInt(fechaDesde.DayOfWeek))
                        primerosPorCodigo.Add(codigo)
                    Else
                        fechaDesde = fechaBase.AddDays(-CInt(fechaBase.DayOfWeek))
                        fechaHasta = fechaBase.AddDays(6 - CInt(fechaBase.DayOfWeek))
                    End If

                    Consulta_sql = $"UPDATE {TablaCalendarioMesesSemanasProductos} SET " & vbCrLf &
                                   $"FechaDesde = '{Format(fechaDesde, "yyyyMMdd")}', FechaHasta = '{Format(fechaHasta, "yyyyMMdd")}'" & vbCrLf &
                                   "WHERE Codigo = '{codigo}' AND Semana = {semana} AND Periodo = {periodo}"
                    _Sql.Ej_consulta_IDU(Consulta_sql, False)
                Next
            End If

            ' 8) Cálculos adicionales: StockNecesarioNMeses y simulaciones
            Dim NMes As Integer = 6
            Dim XMeses As Integer = 2

            ' Obtener rotacion por producto y actualizar StockNecesarioNMeses y StockNecesarioNMenosXMeses
            Consulta_sql = $"SELECT Codigo, ISNULL(Rotacion,0) AS Rotacion FROM {TablaPasoRotacion_Productos} Where Codigo_Nodo_Madre = '{_Codigo_Nodo_Madre}' And Codigo = '{_Codigo}'"
            Dim dtRot As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)
            If dtRot IsNot Nothing Then
                For Each r As DataRow In dtRot.Rows
                    Dim codigo As String = r("Codigo").ToString().Replace("'", "''")
                    Dim rot As Double = Convert.ToDouble(r("Rotacion"))
                    Dim sNec As Double = rot * NMes
                    Dim sNecMenos As Double = rot * (NMes - XMeses)
                    Consulta_sql = $"UPDATE {TablaCalendarioMesesSemanasProductos} SET StockNecesarioNMeses = {sNec.ToString.Replace(",", ".")}, StockNecesarioNMenosXMeses = {sNecMenos.ToString.Replace(",", ".")} WHERE Codigo = '{codigo}'"
                    _Sql.Ej_consulta_IDU(Consulta_sql, False)
                Next
            End If

            ' Simulación mes a mes
            Consulta_sql = $"SELECT DISTINCT Codigo FROM {TablaCalendarioMesesSemanasProductos} Where Codigo = '{_Codigo}'"
            dtCodigos = _Sql.Fx_Get_DataTable(Consulta_sql)
            If dtCodigos IsNot Nothing Then
                For Each drCodigo As DataRow In dtCodigos.Rows
                    Dim codigo As String = drCodigo("Codigo").ToString().Replace("'", "''")

                    ' Obtener StockActual inicial y VentaMensual
                    Consulta_sql = $"SELECT MAX(StockNecesarioNMeses) AS StockNecesarioNMeses, MAX(VentaMes) AS VentaMes FROM {TablaCalendarioMesesSemanasProductos} WHERE Codigo = '{codigo}'"
                    Dim dtVals As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)
                    Dim stockActual As Double = 0.0
                    Dim ventaMensual As Double = 0.0
                    If dtVals IsNot Nothing AndAlso dtVals.Rows.Count > 0 Then
                        stockActual = Convert.ToDouble(dtVals.Rows(0)("StockNecesarioNMeses"))
                        ventaMensual = Convert.ToDouble(dtVals.Rows(0)("VentaMes"))
                    End If

                    ' Obtener meses ordenados
                    Consulta_sql = $"SELECT DISTINCT Periodo, Mes FROM {TablaCalendarioMesesSemanasProductos} WHERE Codigo = '{codigo}' ORDER BY Periodo, Mes"
                    Dim dtMesOrden As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)
                    If dtMesOrden Is Nothing Then Continue For

                    Dim indexMonth As Integer = 0
                    For Each rm As DataRow In dtMesOrden.Rows
                        Dim periodo As Integer = Convert.ToInt32(rm("Periodo"))
                        Dim mes As Integer = Convert.ToInt32(rm("Mes"))

                        If indexMonth = 0 Then
                            ' Primer mes: mantener stockActual tal cual (empieza con StockNecesarioNMeses)
                        Else
                            ' A partir del segundo mes descontar la venta mensual
                            stockActual = stockActual - ventaMensual
                            If stockActual < 0 Then stockActual = 0.0
                        End If

                        Consulta_sql = $"UPDATE {TablaCalendarioMesesSemanasProductos} SET StockProyectadoMensual = {stockActual.ToString.Replace(",", ".")} WHERE Codigo = '{codigo}' AND Periodo = {periodo} AND Mes = {mes}"
                        _Sql.Ej_consulta_IDU(Consulta_sql, False)

                        indexMonth += 1
                    Next
                Next
            End If

            ' Simulación semana a semana (StockNecesarioNSemanas se fija igual a StockNecesarioNMeses para compatibilidad con SQL original)
            Consulta_sql = $"SELECT DISTINCT Codigo FROM {TablaCalendarioMesesSemanasProductos}"
            Dim dtAllCods As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)
            If dtAllCods IsNot Nothing Then
                For Each rCod As DataRow In dtAllCods.Rows
                    Dim codigo As String = rCod("Codigo").ToString().Replace("'", "''")

                    ' Stock inicial y VentaSemanal
                    Consulta_sql = $"SELECT MAX(StockNecesarioNMeses) AS StockNecesarioNSemanas, {ventaSemanalDef} AS VentaSemanal FROM {TablaCalendarioMesesSemanasProductos} WHERE Codigo = '{codigo}'"
                    Dim dtVals As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)
                    Dim stockActual As Double = 0.0
                    Dim ventaSemanal As Double = 0.0
                    If dtVals IsNot Nothing AndAlso dtVals.Rows.Count > 0 Then
                        stockActual = Convert.ToDouble(dtVals.Rows(0)("StockNecesarioNSemanas"))
                        ventaSemanal = Convert.ToDouble(dtVals.Rows(0)("VentaSemanal"))
                    End If

                    ' Recorrer semanas ordenadas
                    Consulta_sql = $"SELECT DISTINCT Periodo, Semana FROM {TablaCalendarioMesesSemanasProductos} WHERE Codigo = '{codigo}' ORDER BY Periodo, Semana"
                    Dim dtSemOrden As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)
                    If dtSemOrden Is Nothing Then Continue For

                    Dim indexWeek As Integer = 0
                    For Each rs As DataRow In dtSemOrden.Rows
                        Dim periodo As Integer = Convert.ToInt32(rs("Periodo"))
                        Dim semana As Integer = Convert.ToInt32(rs("Semana"))

                        If indexWeek = 0 Then
                            ' Primera semana: no descontar ventas (se mantiene el stock inicial)
                            ventaSemanal = 0.0
                            'ElseIf indexWeek = 1 Then
                            '    ' Segunda semana: descontar proporcional según los días restantes de la primera semana
                            '    ventaSemanal = ventaPrimeraSemanalDef
                        Else
                            '    ' Semanas siguientes: descuento de venta semanal completa
                            ventaSemanal = ventaSemanalDef
                        End If

                        stockActual = stockActual - ventaSemanal
                        If stockActual < 0 Then stockActual = 0.0

                        Consulta_sql = $"UPDATE {TablaCalendarioMesesSemanasProductos} SET " &
                                       $"StockProyectadoSemanal = {stockActual.ToString.Replace(",", ".")}" & vbCrLf &
                                       $"WHERE Codigo = '{codigo}' AND Periodo = {periodo} AND Semana = {semana}"
                        _Sql.Ej_consulta_IDU(Consulta_sql, False)
                        indexWeek += 1
                    Next
                Next
            End If

            _Mensaje.EsCorrecto = True
            _Mensaje.Mensaje = "Datos insertados y calculados correctamente en la tabla temporal (VB.NET)."
            _Mensaje.Icono = MessageBoxIcon.Information
            _Mensaje.Detalle = "Insertar detalle en tabla de paso (VB): " & TablaCalendarioMesesSemanasProductos

            Dim _Reg As Integer = _Sql.Fx_Cuenta_Registros(TablaCalendarioMesesSemanasProductos)

            If Not CBool(_Reg) Then
                _Mensaje.EsCorrecto = False
                _Mensaje.Mensaje = "No existe información para generar el grafíco"
            End If

        Catch ex As Exception
            _Mensaje.EsCorrecto = False
            _Mensaje.Mensaje = ex.Message
            _Mensaje.Icono = MessageBoxIcon.Error
        End Try

        Return _Mensaje

    End Function

    Function Fx_InsertarDetalleEn_TablaCalendarioMesesSemanasClasificaciones_VB(_Codigo_Nodo_Madre As String) As LsValiciones.Mensajes

        Dim _Mensaje As New LsValiciones.Mensajes

        Try
            ' 1) Crear tabla si no existe (reutiliza método de la clase)
            Dim _crea = Fx_CrearTablaPaso_TablaCalendarioMesesSemanasClasificacion()
            If Not _crea.EsCorrecto Then
                _Mensaje.EsCorrecto = False
                _Mensaje.Mensaje = "No se pudo crear la tabla temporal: " & _crea.Mensaje
                _Mensaje.Icono = MessageBoxIcon.Error
                Return _Mensaje
            End If

            ' 2) Leer productos de la clasificación

            Consulta_sql = "SELECT Codigo_Nodo_Madre,ISNULL(StockUd1,0) AS StockUd1,ISNULL(StockEnTransitoUd1,0) AS StockEnTransitoUd1," &
                           "ISNULL(StockPedidoUd1,0) AS StockPedidoUd1,ISNULL(StockFacSinRecepUd1,0) AS StockFacSinRecepUd1,ISNULL(Rotacion,0) AS Rotacion" & vbCrLf &
                           $"FROM {TablaPasoRotacion_Clasificacion}" & vbCrLf &
                           $"WHERE Codigo_Nodo_Madre = '{_Codigo_Nodo_Madre}'" & vbCrLf &
                           $"And (ISNULL(StockUd1,0)+ISNULL(StockEnTransitoUd1,0)+ISNULL(StockPedidoUd1,0)+ISNULL(StockFacSinRecepUd1,0)) > 0"

            Dim dtClasificacion As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

            If dtClasificacion Is Nothing OrElse dtClasificacion.Rows.Count = 0 Then
                ' Nada que insertar
                _Mensaje.EsCorrecto = False
                _Mensaje.Mensaje = "No hay productos para la clasificación indicada."
                _Mensaje.Icono = MessageBoxIcon.Information
                Return _Mensaje
            End If

            ' 3) Construir INSERT masivo para 52 semanas
            Dim sbInsert As New System.Text.StringBuilder()
            'Consulta_sql = $"INSERT INTO {TablaCalendarioMesesSemanasProductos} (Codigo, Codigo_Nodo_Madre, Semana, StockSemanal, VentaSemanal, LlegadaSemanal, Mes, NombreMes, Periodo, StockMes, VentaMes, LlegadasMes, FechaDesde, FechaHasta, StockNecesarioNMeses, StockProyectadoMensual, StockNecesarioNMenosXMeses, StockNecesarioNSemanas, StockProyectadoSemanal) VALUES"
            'sbInsert.AppendLine(Consulta_sql)

            Dim ci As New Globalization.CultureInfo("es-ES")
            Dim semanaActual As Integer = DatePart(DateInterval.WeekOfYear, DateTime.Now)
            Dim filas As New List(Of String)

            For Each dr As DataRow In dtClasificacion.Rows

                'Dim codigo As String = dr("Codigo").ToString().Replace("'", "''")
                Dim codigoNodo As String = dr("Codigo_Nodo_Madre").ToString().Replace("'", "''")

                Dim stockUd1 As Double = Convert.ToDouble(dr("StockUd1"))
                Dim stockEnTransito As Double = Convert.ToDouble(dr("StockEnTransitoUd1"))
                Dim stockPedido As Double = Convert.ToDouble(dr("StockPedidoUd1"))
                Dim stockFacSinRecep As Double = Convert.ToDouble(dr("StockFacSinRecepUd1"))
                Dim stock As Double = stockUd1 + stockEnTransito + stockPedido + stockFacSinRecep
                Dim rotacion As Double = Convert.ToDouble(dr("Rotacion"))

                If Not CBool(stock) Then
                    Continue For
                End If

                For n As Integer = 0 To 51
                    Dim fechaBase As DateTime = DateAdd(DateInterval.WeekOfYear, n, DateTime.Now)
                    Dim semana As Integer = DatePart(DateInterval.WeekOfYear, fechaBase)
                    Dim mes As Integer = fechaBase.Month
                    Dim nombreMes As String = fechaBase.ToString("MMMM", ci)
                    Dim periodo As Integer = fechaBase.Year
                    Dim stockSemanal As Double = If(semana = semanaActual, stockUd1 + stockEnTransito, 0.0)
                    Dim ventaSemanal As Double = rotacion / 4.0
                    Dim ventaMes As Double = rotacion
                    Dim llegadaSemanal As Double = 0.0
                    Dim llegadasMes As Double = 0.0
                    Dim fechaDesde As DateTime = fechaBase.AddDays(-CInt(fechaBase.DayOfWeek))
                    Dim fechaHasta As DateTime = fechaBase.AddDays(6 - CInt(fechaBase.DayOfWeek))
                    Dim stockNecesarioNMeses As Double = 0.0
                    Dim stockProyectadoMensual As Double = 0.0
                    Dim stockNecesarioNMenosXMeses As Double = 0.0
                    Dim stockNecesarioNSemanas As Double = 0.0
                    Dim stockProyectadoSemanal As Double = 0.0

                    Consulta_sql = $"INSERT INTO {TablaCalendarioMesesSemanasClasificacion} (Codigo_Nodo_Madre, Semana, StockSemanal, VentaSemanal, LlegadaSemanal, Mes, NombreMes, Periodo, StockMes, VentaMes, LlegadasMes, FechaDesde, FechaHasta, StockNecesarioNMeses, StockProyectadoMensual, StockNecesarioNMenosXMeses, StockNecesarioNSemanas, StockProyectadoSemanal) VALUES"
                    sbInsert.AppendLine(Consulta_sql)

                    Consulta_sql = $"('{codigoNodo}',{semana},{stockSemanal.ToString.Replace(",", ".")},
                                  {ventaSemanal.ToString.Replace(",", ".")},{llegadaSemanal.ToString.Replace(",", ".")},{mes},
                                  '{nombreMes.Replace("'", "''")}',{periodo},{stockSemanal.ToString.Replace(",", ".")},
                                  {ventaMes.ToString.Replace(",", ".")},{llegadasMes.ToString.Replace(",", ".")}
                                  ,'{Format(fechaDesde, "yyyyMMdd")}','{Format(fechaHasta, "yyyyMMdd")}',
                                  {stockNecesarioNMeses.ToString.Replace(",", ".")},
                                  {stockProyectadoMensual.ToString.Replace(",", ".")},
                                  {stockNecesarioNMenosXMeses.ToString.Replace(",", ".")},
                                  {stockNecesarioNSemanas.ToString.Replace(",", ".")},
                                  {stockProyectadoSemanal.ToString.Replace(",", ".")})"
                    sbInsert.AppendLine(Consulta_sql)

                    'filas.Add($"('{codigo}','{codigoNodo}',{semana},{stockSemanal.ToString.Replace(",", ".")},
                    '              {ventaSemanal.ToString.Replace(",", ".")},{llegadaSemanal.ToString.Replace(",", ".")},{mes},
                    '              '{nombreMes.Replace("'", "''")}',{periodo},{stockSemanal.ToString.Replace(",", ".")},
                    '              {ventaMes.ToString.Replace(",", ".")},{llegadasMes.ToString.Replace(",", ".")}
                    '              ,'{Format(fechaDesde, "yyyyMMdd")}','{Format(fechaHasta, "yyyyMMdd")}',
                    '              {stockNecesarioNMeses.ToString.Replace(",", ".")},
                    '              {stockProyectadoMensual.ToString.Replace(",", ".")},
                    '              {stockNecesarioNMenosXMeses.ToString.Replace(",", ".")},
                    '              {stockNecesarioNSemanas.ToString.Replace(",", ".")},
                    '              {stockProyectadoSemanal.ToString.Replace(",", ".")})")
                Next

                'If filas.Count > 0 Then
                'sbInsert.AppendLine(String.Join("," & vbCrLf, filas))
                If Not _Sql.Ej_consulta_IDU(sbInsert.ToString) Then
                    Throw New Exception("Error al insertar filas iniciales en tabla calendario (insert masivo).")
                End If
                'End If

                sbInsert.Clear()

            Next

            ' 4) Poblar llegadas semanales y mensuales desde Tbl_Asc_04_DocUltComp_{FUNCIONARIO}
            Consulta_sql = $"SELECT Codigo_Nodo_Madre, DATEPART(WEEK, FEERLI) AS Semana, YEAR(FEERLI) AS Periodo, SUM(Saldo) AS TotalSaldo" & vbCrLf &
                           $"FROM Tbl_Asc_04_DocUltComp_{FUNCIONARIO}" & vbCrLf &
                           $"WHERE TIDO IN ('OCC','FCC') And Codigo_Nodo_Madre = '{_Codigo_Nodo_Madre}'" & vbCrLf &
                           "GROUP BY Codigo_Nodo_Madre, DATEPART(WEEK, FEERLI), YEAR(FEERLI)"

            Dim dtLlegadas As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

            Dim _PeriodoMin As Integer = _Sql.Fx_Trae_Dato($"{TablaCalendarioMesesSemanasClasificacion}", "Min(Periodo)", "")
            Dim _SemanaMin As Integer = _Sql.Fx_Trae_Dato($"{TablaCalendarioMesesSemanasClasificacion}", "Min(Semana)", "Periodo = '" & _PeriodoMin & "'")

            If dtLlegadas IsNot Nothing AndAlso dtLlegadas.Rows.Count > 0 Then
                For Each dr As DataRow In dtLlegadas.Rows
                    Dim codigo_Nodo_Madre As String = dr("Codigo_Nodo_Madre").ToString().Replace("'", "''")
                    Dim semana As Integer = Convert.ToInt32(dr("Semana"))
                    Dim periodo As Integer = Convert.ToInt32(dr("Periodo"))
                    Dim totalSaldo As Double = Convert.ToDouble(dr("TotalSaldo"))

                    If semana < _SemanaMin Then
                        semana = _SemanaMin
                    End If

                    Consulta_sql = $"UPDATE {TablaCalendarioMesesSemanasClasificacion} SET LlegadaSemanal = ISNULL(LlegadaSemanal,0) + {totalSaldo.ToString.Replace(",", ".")}, LlegadasMes = ISNULL(LlegadasMes,0) + {totalSaldo.ToString.Replace(",", ".")} WHERE Semana = {semana} AND Periodo = {periodo}"
                    _Sql.Ej_consulta_IDU(Consulta_sql, False)
                Next
            End If

            Dim ventaSemanalDef As Double = 0.0
            Dim ventaPrimeraSemanalDef As Double = 0.0

            ' 5) Recalcular stock semana a semana en VB para cada Codigo
            Consulta_sql = $"SELECT DISTINCT Codigo_Nodo_Madre FROM {TablaCalendarioMesesSemanasClasificacion} Where Codigo_Nodo_Madre = '{_Codigo_Nodo_Madre}'"
            Dim dtCodigo_Nodo_Madre As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)
            If dtCodigo_Nodo_Madre IsNot Nothing Then
                For Each drCodigo As DataRow In dtCodigo_Nodo_Madre.Rows
                    Dim codigo_Nodo_Madre As String = drCodigo("Codigo_Nodo_Madre").ToString().Replace("'", "''")

                    ' Obtener stock inicial y rotacion del producto
                    Consulta_sql = $"SELECT ISNULL(StockUd1,0) AS StockUd1, ISNULL(StockEnTransitoUd1,0) AS StockEnTransitoUd1, ISNULL(Rotacion,0) AS Rotacion FROM {TablaPasoRotacion_Clasificacion} WHERE Codigo_Nodo_Madre = '{codigo_Nodo_Madre}'"
                    Dim dtProd As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)
                    Dim stockActual As Double = 0.0

                    If dtProd IsNot Nothing AndAlso dtProd.Rows.Count > 0 Then
                        stockActual = Convert.ToDouble(dtProd.Rows(0)("StockUd1")) + Convert.ToDouble(dtProd.Rows(0)("StockEnTransitoUd1"))
                        ventaSemanalDef = Convert.ToDouble(dtProd.Rows(0)("Rotacion")) / 4.0
                    End If

                    ' Leer semanas ordenadas
                    Consulta_sql = $"SELECT Semana, Periodo, ISNULL(VentaSemanal,0) AS VentaSemanal, ISNULL(LlegadaSemanal,0) AS LlegadaSemanal FROM {TablaCalendarioMesesSemanasClasificacion} ORDER BY Periodo, Semana"
                    Dim dtSemanas As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)
                    If dtSemanas Is Nothing Then Continue For

                    Dim indexWeek As Integer = 0
                    ' Calcular valores relacionados con la semana actual para aplicar la fracción en la segunda semana
                    Dim semanaActualLocal As Integer = DatePart(DateInterval.WeekOfYear, DateTime.Now)
                    Dim periodoActual As Integer = DateTime.Now.Year
                    ' Para el cálculo de días restantes se asume semana que comienza el lunes
                    Dim dow As Integer = If(DateTime.Now.DayOfWeek = DayOfWeek.Sunday, 7, CInt(DateTime.Now.DayOfWeek))
                    Dim daysRemainingInclusive As Integer = 7 - dow + 1 ' ejemplo: miércoles -> 5 días (mié..dom)

                    ventaPrimeraSemanalDef = Math.Round(ventaSemanalDef * (daysRemainingInclusive / 7.0), 2)

                    For Each rs As DataRow In dtSemanas.Rows
                        Dim ventaSemanalTabla As Double = Convert.ToDouble(rs("VentaSemanal"))
                        Dim llegadaSemanal As Double = Convert.ToDouble(rs("LlegadaSemanal"))

                        Dim ventaAplicada As Double

                        Dim semana As Integer = Convert.ToInt32(rs("Semana"))
                        Dim periodo As Integer = Convert.ToInt32(rs("Periodo"))

                        If indexWeek = 0 Then
                            ' Primera semana: no descontar ventas (se mantiene el stock inicial)
                            ventaAplicada = 0.0
                        ElseIf indexWeek = 1 Then
                            ' Segunda semana: descontar proporcional según los días restantes de la primera semana
                            ventaAplicada = ventaPrimeraSemanalDef 'Math.Round(ventaSemanalDef * (daysRemainingInclusive / 7.0), 2)
                        Else
                            ' Semanas siguientes: descuento de venta semanal completa
                            ventaAplicada = ventaSemanalDef
                        End If

                        ' Si no hay stock inicial, no se descuenta venta
                        If stockActual = 0 Then
                            ventaAplicada = 0.0
                        End If

                        ' Aplicar llegadas y ventas
                        stockActual = Math.Round(stockActual - ventaAplicada + llegadaSemanal, 2)

                        ' Evitar negativos
                        If stockActual < 0 Then stockActual = 0.0

                        Consulta_sql = $"UPDATE {TablaCalendarioMesesSemanasClasificacion}" & vbCrLf &
                                       $"SET StockSemanal = {stockActual.ToString.Replace(",", ".")}, StockMes = {stockActual.ToString.Replace(",", ".")}" & vbCrLf &
                                       $"WHERE Semana = {semana} AND Periodo = {periodo}"
                        _Sql.Ej_consulta_IDU(Consulta_sql, False)

                        indexWeek += 1
                    Next
                Next
            End If

            ' 6) Consolidación mensual en VB: StockMes = stock de la última semana del mes
            Consulta_sql = $"SELECT DISTINCT Codigo_Nodo_Madre, Periodo, Mes FROM {TablaCalendarioMesesSemanasClasificacion} ORDER BY Codigo_Nodo_Madre, Periodo, Mes"
            Dim dtMeses As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)
            If dtMeses IsNot Nothing Then
                For Each drMes As DataRow In dtMeses.Rows
                    Dim codigo_Nodo_Madre As String = drMes("Codigo_Nodo_Madre").ToString().Replace("'", "''")
                    Dim periodo As Integer = Convert.ToInt32(drMes("Periodo"))
                    Dim mes As Integer = Convert.ToInt32(drMes("Mes"))

                    ' Obtener la última semana del mes para este producto
                    Consulta_sql = $"SELECT TOP 1 StockSemanal FROM {TablaCalendarioMesesSemanasClasificacion} WHERE Periodo = {periodo} AND Mes = {mes} ORDER BY Semana DESC"
                    Dim dtUltSemana As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)
                    If dtUltSemana IsNot Nothing AndAlso dtUltSemana.Rows.Count > 0 Then
                        Dim stockMesVal As Double = Convert.ToDouble(dtUltSemana.Rows(0)("StockSemanal"))
                        Dim upd As String = $"UPDATE {TablaCalendarioMesesSemanasProductos} SET StockMes = {stockMesVal.ToString.Replace(",", ".")} WHERE Periodo = {periodo} AND Mes = {mes}"
                        _Sql.Ej_consulta_IDU(upd, False)
                    End If
                Next
            End If

            ' 7) Poblar FechaDesde y FechaHasta para cada fila
            Consulta_sql = $"SELECT Codigo_Nodo_Madre, Semana, Periodo, FechaDesde, FechaHasta FROM {TablaCalendarioMesesSemanasClasificacion}"
            Dim dtAll As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)
            If dtAll IsNot Nothing Then
                ' Mantener control de los primeros registros por Codigo_Nodo_Madre: si es el primer registro, FechaDesde = hoy
                Dim primerosPorCodigo As New System.Collections.Generic.HashSet(Of String)(StringComparer.OrdinalIgnoreCase)
                For Each r As DataRow In dtAll.Rows
                    Dim codigo_Nodo_Madre As String = r("Codigo_Nodo_Madre").ToString().Replace("'", "''")
                    Dim semana As Integer = Convert.ToInt32(r("Semana"))
                    Dim periodo As Integer = Convert.ToInt32(r("Periodo"))

                    ' Reconstruir FechaBase similar a SQL: DATEADD(WEEK,Semana - SemanaActual, GETDATE()) con ajuste de año
                    Dim diffWeeks As Integer = semana - semanaActual
                    Dim fechaBase As DateTime = DateAdd(DateInterval.WeekOfYear, diffWeeks, DateTime.Now)

                    Dim fechaDesde As DateTime
                    Dim fechaHasta As DateTime

                    If Not primerosPorCodigo.Contains(codigo_Nodo_Madre) Then
                        ' Si es el primer registro para este Codigo, FechaDesde debe ser la fecha de hoy
                        fechaDesde = DateTime.Now
                        ' Calcular FechaHasta a partir de la FechaDesde (misma lógica de fin de semana utilizada en el resto)
                        fechaHasta = fechaDesde.AddDays(6 - CInt(fechaDesde.DayOfWeek))
                        primerosPorCodigo.Add(codigo_Nodo_Madre)
                    Else
                        fechaDesde = fechaBase.AddDays(-CInt(fechaBase.DayOfWeek))
                        fechaHasta = fechaBase.AddDays(6 - CInt(fechaBase.DayOfWeek))
                    End If

                    Consulta_sql = $"UPDATE {TablaCalendarioMesesSemanasClasificacion} SET " & vbCrLf &
                                   $"FechaDesde = '{Format(fechaDesde, "yyyyMMdd")}', FechaHasta = '{Format(fechaHasta, "yyyyMMdd")}'" & vbCrLf &
                                   "WHERE Semana = {semana} AND Periodo = {periodo}"
                    _Sql.Ej_consulta_IDU(Consulta_sql, False)
                Next
            End If

            ' 8) Cálculos adicionales: StockNecesarioNMeses y simulaciones
            Dim NMes As Integer = 6
            Dim XMeses As Integer = 2

            ' Obtener rotacion por producto y actualizar StockNecesarioNMeses y StockNecesarioNMenosXMeses
            Consulta_sql = $"SELECT Codigo_Nodo_Madre, ISNULL(Rotacion,0) AS Rotacion FROM {TablaPasoRotacion_Clasificacion} Where Codigo_Nodo_Madre = '{_Codigo_Nodo_Madre}'"
            Dim dtRot As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)
            If dtRot IsNot Nothing Then
                For Each r As DataRow In dtRot.Rows
                    Dim codigo_Nodo_Madre As String = r("Codigo_Nodo_Madre").ToString().Replace("'", "''")
                    Dim rot As Double = Convert.ToDouble(r("Rotacion"))
                    Dim sNec As Double = rot * NMes
                    Dim sNecMenos As Double = rot * (NMes - XMeses)
                    Consulta_sql = $"UPDATE {TablaCalendarioMesesSemanasClasificacion} SET StockNecesarioNMeses = {sNec.ToString.Replace(",", ".")}, StockNecesarioNMenosXMeses = {sNecMenos.ToString.Replace(",", ".")} WHERE Codigo_Nodo_Madre = '{codigo_Nodo_Madre}'"
                    _Sql.Ej_consulta_IDU(Consulta_sql, False)
                Next
            End If

            ' Simulación mes a mes
            Consulta_sql = $"SELECT DISTINCT Codigo_Nodo_Madre FROM {TablaCalendarioMesesSemanasClasificacion}"
            dtCodigo_Nodo_Madre = _Sql.Fx_Get_DataTable(Consulta_sql)
            If dtCodigo_Nodo_Madre IsNot Nothing Then
                For Each drCodigo_Nodo_Madre As DataRow In dtCodigo_Nodo_Madre.Rows
                    Dim codigo_Nodo_Madre As String = drCodigo_Nodo_Madre("Codigo_Nodo_Madre").ToString().Replace("'", "''")

                    ' Obtener StockActual inicial y VentaMensual
                    Consulta_sql = $"SELECT MAX(StockNecesarioNMeses) AS StockNecesarioNMeses, MAX(VentaMes) AS VentaMes FROM {TablaCalendarioMesesSemanasClasificacion}"
                    Dim dtVals As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)
                    Dim stockActual As Double = 0.0
                    Dim ventaMensual As Double = 0.0
                    If dtVals IsNot Nothing AndAlso dtVals.Rows.Count > 0 Then
                        stockActual = Convert.ToDouble(dtVals.Rows(0)("StockNecesarioNMeses"))
                        ventaMensual = Convert.ToDouble(dtVals.Rows(0)("VentaMes"))
                    End If

                    ' Obtener meses ordenados
                    Consulta_sql = $"SELECT DISTINCT Periodo, Mes FROM {TablaCalendarioMesesSemanasClasificacion} ORDER BY Periodo, Mes"
                    Dim dtMesOrden As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)
                    If dtMesOrden Is Nothing Then Continue For

                    Dim indexMonth As Integer = 0
                    For Each rm As DataRow In dtMesOrden.Rows
                        Dim periodo As Integer = Convert.ToInt32(rm("Periodo"))
                        Dim mes As Integer = Convert.ToInt32(rm("Mes"))

                        If indexMonth = 0 Then
                            ' Primer mes: mantener stockActual tal cual (empieza con StockNecesarioNMeses)
                        Else
                            ' A partir del segundo mes descontar la venta mensual
                            stockActual = stockActual - ventaMensual
                            If stockActual < 0 Then stockActual = 0.0
                        End If

                        Consulta_sql = $"UPDATE {TablaCalendarioMesesSemanasClasificacion} SET StockProyectadoMensual = {stockActual.ToString.Replace(",", ".")} WHERE Periodo = {periodo} AND Mes = {mes}"
                        _Sql.Ej_consulta_IDU(Consulta_sql, False)

                        indexMonth += 1
                    Next
                Next
            End If

            ' Simulación semana a semana (StockNecesarioNSemanas se fija igual a StockNecesarioNMeses para compatibilidad con SQL original)
            Consulta_sql = $"SELECT DISTINCT Codigo_Nodo_Madre FROM {TablaCalendarioMesesSemanasClasificacion}"
            Dim dtAllCods As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)
            If dtAllCods IsNot Nothing Then
                For Each rCod As DataRow In dtAllCods.Rows
                    Dim codigo_Nodo_Madre As String = rCod("Codigo_Nodo_Madre").ToString().Replace("'", "''")

                    ' Stock inicial y VentaSemanal
                    Consulta_sql = $"SELECT MAX(StockNecesarioNMeses) AS StockNecesarioNSemanas, {ventaSemanalDef} AS VentaSemanal FROM {TablaCalendarioMesesSemanasClasificacion} WHERE Codigo_Nodo_Madre = '{codigo_Nodo_Madre}'"
                    Dim dtVals As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)
                    Dim stockActual As Double = 0.0
                    Dim ventaSemanal As Double = 0.0
                    If dtVals IsNot Nothing AndAlso dtVals.Rows.Count > 0 Then
                        stockActual = Convert.ToDouble(dtVals.Rows(0)("StockNecesarioNSemanas"))
                        ventaSemanal = Convert.ToDouble(dtVals.Rows(0)("VentaSemanal"))
                    End If

                    ' Recorrer semanas ordenadas
                    Consulta_sql = $"SELECT DISTINCT Periodo, Semana FROM {TablaCalendarioMesesSemanasClasificacion} ORDER BY Periodo, Semana"
                    Dim dtSemOrden As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)
                    If dtSemOrden Is Nothing Then Continue For

                    Dim indexWeek As Integer = 0
                    For Each rs As DataRow In dtSemOrden.Rows
                        Dim periodo As Integer = Convert.ToInt32(rs("Periodo"))
                        Dim semana As Integer = Convert.ToInt32(rs("Semana"))

                        If indexWeek = 0 Then
                            ' Primera semana: no descontar ventas (se mantiene el stock inicial)
                            ventaSemanal = 0.0
                            'ElseIf indexWeek = 1 Then
                            '    ' Segunda semana: descontar proporcional según los días restantes de la primera semana
                            '    ventaSemanal = ventaPrimeraSemanalDef
                        Else
                            '    ' Semanas siguientes: descuento de venta semanal completa
                            ventaSemanal = ventaSemanalDef
                        End If

                        stockActual = stockActual - ventaSemanal
                        If stockActual < 0 Then stockActual = 0.0

                        Consulta_sql = $"UPDATE {TablaCalendarioMesesSemanasClasificacion} SET " &
                                       $"StockProyectadoSemanal = {stockActual.ToString.Replace(",", ".")}" & vbCrLf &
                                       $"WHERE Codigo_Nodo_Madre = '{codigo_Nodo_Madre}' AND Periodo = {periodo} AND Semana = {semana}"
                        _Sql.Ej_consulta_IDU(Consulta_sql, False)
                        indexWeek += 1
                    Next
                Next
            End If

            _Mensaje.EsCorrecto = True
            _Mensaje.Mensaje = "Datos insertados y calculados correctamente en la tabla temporal (VB.NET)."
            _Mensaje.Icono = MessageBoxIcon.Information
            _Mensaje.Detalle = "Insertar detalle en tabla de paso (VB): " & TablaCalendarioMesesSemanasClasificacion

            Dim _Reg As Integer = _Sql.Fx_Cuenta_Registros(TablaCalendarioMesesSemanasClasificacion)

            If Not CBool(_Reg) Then
                _Mensaje.EsCorrecto = False
                _Mensaje.Mensaje = "No existe información para generar el grafíco"
            End If

        Catch ex As Exception
            _Mensaje.EsCorrecto = False
            _Mensaje.Mensaje = ex.Message
            _Mensaje.Icono = MessageBoxIcon.Error
        End Try

        Return _Mensaje

    End Function

    Function Fx_Select_TablaCalendarioMesesSemanasProductos(_Codigo As String) As LsValiciones.Mensajes

        Dim _Mensaje As New LsValiciones.Mensajes

        Try

            Consulta_sql = $"-- Estudio de proyección de ventas por MES

SELECT 
    Codigo,
	Codigo_Nodo_Madre,
    Periodo,
    Mes,
    NombreMes,
    MAX(StockMes) AS StockMes,          -- stock al cierre del mes
    MAX(VentaMes) AS VentaMes,          -- rotación mensual
    LlegadasMes AS LlegadasMes,     -- total llegadas del mes
	MAX(StockNecesarioNMeses) As StockNecesarioNMeses,
	MAX(StockProyectadoMensual) As StockProyectadoMensual,
	MAX(StockNecesarioNMenosXMeses) As StockNecesarioNMenosXMeses

FROM {TablaCalendarioMesesSemanasProductos}
Where Codigo = '{_Codigo}'
GROUP BY Codigo, Codigo_Nodo_Madre, Periodo, Mes, NombreMes,LlegadasMes
ORDER BY Codigo, Periodo, Mes;

-- Estudio de proyección de ventas por SEMANA

SELECT 
    Codigo,
	Codigo_Nodo_Madre,
    Periodo,
    Mes,
    NombreMes,
    Semana,
	FechaDesde,
	FechaHasta,
    StockSemanal,
    VentaSemanal,
    LlegadaSemanal,
	StockNecesarioNSemanas,
	StockProyectadoSemanal
FROM {TablaCalendarioMesesSemanasProductos}
Where Codigo = '{_Codigo}'
ORDER BY Codigo, Periodo, Mes, Semana;
"

        Catch ex As Exception

        End Try

    End Function

    Function Fx_Select_TablaCalendarioMesesSemanasClasificacion(_Codigo_Nodo_Madre As String) As LsValiciones.Mensajes

        Dim _Mensaje As New LsValiciones.Mensajes

        Try

            Consulta_sql = $"-- Estudio de proyección de ventas por MES

SELECT 
    Codigo_Nodo_Madre,
    Periodo,
    Mes,
    NombreMes,
    MAX(StockMes) AS StockMes,          -- stock al cierre del mes
    MAX(VentaMes) AS VentaMes,          -- rotación mensual
    LlegadasMes AS LlegadasMes,     -- total llegadas del mes
	MAX(StockNecesarioNMeses) As StockNecesarioNMeses,
	MAX(StockProyectadoMensual) As StockProyectadoMensual,
	MAX(StockNecesarioNMenosXMeses) As StockNecesarioNMenosXMeses

FROM {TablaCalendarioMesesSemanasClasificacion}
Where Codigo_Nodo_Madre = '{_Codigo_Nodo_Madre}'
GROUP BY Codigo_Nodo_Madre, Periodo, Mes, NombreMes,LlegadasMes
ORDER BY Codigo_Nodo_Madre, Periodo, Mes;
-- Estudio de proyección de ventas por SEMANA

SELECT 
    Codigo_Nodo_Madre,
    Periodo,
    Mes,
    NombreMes,
    Semana,
	FechaDesde,
	FechaHasta,
    StockSemanal,
    VentaSemanal,
    LlegadaSemanal,
	StockNecesarioNSemanas,
	StockProyectadoSemanal
FROM {TablaCalendarioMesesSemanasClasificacion}
Where Codigo_Nodo_Madre = '{_Codigo_Nodo_Madre}'
ORDER BY Codigo_Nodo_Madre, Periodo, Mes, Semana;
"

        Catch ex As Exception

        End Try

    End Function

End Class

