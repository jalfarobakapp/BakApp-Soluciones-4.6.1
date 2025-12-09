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
                                                    _SumarStockDisponible As Boolean) As LsValiciones.Mensajes

        Dim _Mensaje As New LsValiciones.Mensajes

        Dim _StockPedidoUd1 = String.Empty

        If _SumarStockDisponible Then
            _StockPedidoUd1 = " + StockPedidoUd1"
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
    StockUd1 + StockEnTransitoUd1{_StockPedidoUd1} AS StockDisponible,
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
FROM {_Tbl_Asc_02_Asociaciones}
--WHERE StockUd1 + StockEnTransitoUd1 > 0

Update {_TablaPasoRotacion_Clasificacion} Set Duracion_Stock_Meses = Round(StockDisponible/NULLIF(Rotacion,0),0)
Update {_TablaPasoRotacion_Clasificacion} Set Syncro = (Duracion_Stock_Meses-MesesSobreStock)*Rotacion
Update {_TablaPasoRotacion_Clasificacion} Set PalletSY = Floor(Syncro/NULLIF(KilosXPallet,0))
Update {_TablaPasoRotacion_Clasificacion} Set SobreStock = 'No' Where PalletSY <= 0 --Duracion_Stock_Meses <= MesesSobreStock
Update {_TablaPasoRotacion_Clasificacion} Set SobreStock = 'Si' Where PalletSY > 0 --Duracion_Stock_Meses > MesesSobreStock
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

        Dim _StockPedidoUd1 = String.Empty

        If _SumarStockDisponible Then
            _StockPedidoUd1 = " + StockPedidoUd1"
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
    StockUd1 + StockEnTransitoUd1{_StockPedidoUd1} AS StockDisponible,
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
     FROM (VALUES (RotMensualUd1_Prod), (RotMensualUd1_Prod),
                  (Promedio_MensualUd1_Prod), (PromMensualUd1_Ul3Mes_Prod)) AS value(v)
    ) AS Rotacion,
    Duracion_Stock AS Duracion_Stock_Meses,
    MesesSobreStock,
    SobreStock,
    600
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

-- Calcular StockSemanal como el stock de la última semana del mes

OPEN cur;
FETCH NEXT FROM cur INTO @Codigo;

WHILE @@FETCH_STATUS = 0
BEGIN
    -- Stock inicial del producto
    SELECT @StockActual = StockUd1 + StockEnTransitoUd1
    FROM {TablaPasoRotacion_Productos}
    WHERE Codigo = @Codigo;

    -- Recorremos semanas en orden
    DECLARE semCur CURSOR FOR
    SELECT Semana, Periodo, VentaSemanal, LlegadaSemanal
    FROM {TablaCalendarioMesesSemanasProductos}
    WHERE Codigo = @Codigo
    ORDER BY Periodo, Semana;

    OPEN semCur;
    FETCH NEXT FROM semCur INTO @Semana, @Periodo, @VentaSemanal, @LlegadasSemanal;

    WHILE @@FETCH_STATUS = 0
    BEGIN
        -- Si no hay stock inicial, no se descuenta venta
        IF @StockActual = 0
            SET @VentaSemanal = 0;

        -- Calcular stock para la semana
        SET @StockActual = @StockActual - @VentaSemanal + @LlegadasSemanal;

        -- Evitar negativos
        IF @StockActual < 0
            SET @StockActual = 0;

        -- Actualizar la tabla
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


-- Calcular StockMes como el stock de la última semana del mes
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

-- Calcular LlegadasMes como la suma de llegadas semanales del mes
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


-- Poblar fechas desde/hasta para cada semana
UPDATE c
SET c.FechaDesde = DATEADD(DAY, 1 - DATEPART(WEEKDAY, f.FechaBase), f.FechaBase),
    c.FechaHasta = DATEADD(DAY, 7 - DATEPART(WEEKDAY, f.FechaBase), f.FechaBase)
FROM {TablaCalendarioMesesSemanasProductos} c
CROSS APPLY (
    SELECT DATEADD(WEEK, c.Semana - DATEPART(WEEK, GETDATE()), GETDATE()) AS FechaBase
) f;



-- Para agregar nuevos calculos que me pasa Gonzalo

DECLARE @NMes Int = 6; -- horizonte en meses (variable)
DECLARE @XMeses Int = 2;

-- 1. Calcular stock necesario para N meses y N-2 meses
UPDATE c
SET c.StockNecesarioNMeses = p.Rotacion * @NMes,
    c.StockNecesarioNMenosXMeses = p.Rotacion * (@NMes - @XMeses)
FROM {TablaCalendarioMesesSemanasProductos} c
JOIN {TablaPasoRotacion_Productos} p ON c.Codigo = p.Codigo;



-- 2. Simular consumo Mes a Mes

DECLARE @VentaMensual FLOAT;

DECLARE cur CURSOR FOR
SELECT DISTINCT Codigo FROM {TablaCalendarioMesesSemanasProductos};

OPEN cur;
FETCH NEXT FROM cur INTO @Codigo;

WHILE @@FETCH_STATUS = 0
BEGIN
    -- Stock inicial = stock necesario para N meses
    SELECT @StockActual = MAX(StockNecesarioNMeses)+MAX(VentaMes),
           @VentaMensual = MAX(VentaMes)
    FROM {TablaCalendarioMesesSemanasProductos}
    WHERE Codigo = @Codigo;

    -- Recorrer meses en orden
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
       -- Descontar solo ventas mensuales (sin sumar llegadas)
        SET @StockActual = @StockActual - @VentaMensual;
        IF @StockActual < 0 SET @StockActual = 0;

        -- Actualizar campo StockProyectado en todas las semanas del mes
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


--DECLARE @NSem INT = @NMes * 24; -- horizonte en semanas (variable)

-- 1. Calcular stock necesario para N semanas y N-2 semanas
UPDATE c
SET c.StockNecesarioNSemanas = c.StockNecesarioNMeses --c.VentaSemanal * @NSem
    -- c.StockNecesarioNSemanasMenos2 = c.VentaSemanal * (@NSem - 2)
FROM {TablaCalendarioMesesSemanasProductos} c;

-- 2. Simular consumo semana a semana

DECLARE cur CURSOR FOR
SELECT DISTINCT Codigo FROM {TablaCalendarioMesesSemanasProductos};

OPEN cur;
FETCH NEXT FROM cur INTO @Codigo;

WHILE @@FETCH_STATUS = 0
BEGIN
    -- Stock inicial = stock necesario para N semanas
    SELECT @StockActual = MAX(StockNecesarioNSemanas)+MAX(VentaSemanal),
           @VentaSemanal = MAX(VentaSemanal)
    FROM {TablaCalendarioMesesSemanasProductos}
    WHERE Codigo = @Codigo;

    -- Recorrer semanas en orden
    DECLARE semCur CURSOR FOR
    SELECT Semana, Periodo
    FROM {TablaCalendarioMesesSemanasProductos}
    WHERE Codigo = @Codigo
    ORDER BY Periodo, Semana;

    OPEN semCur;
    FETCH NEXT FROM semCur INTO @Semana, @Periodo;

    WHILE @@FETCH_STATUS = 0
    BEGIN
        -- Descontar ventas semanales
        SET @StockActual = @StockActual - @VentaSemanal;
        IF @StockActual < 0 SET @StockActual = 0;

        -- Actualizar campo StockProyectadoSemanal
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

-- Calcular StockSemanal como el stock de la última semana del mes

OPEN cur;
FETCH NEXT FROM cur INTO @Codigo_Nodo_Madre;

WHILE @@FETCH_STATUS = 0
BEGIN
    -- Stock inicial del producto
    SELECT @StockActual = StockUd1 + StockEnTransitoUd1
    FROM {TablaPasoRotacion_Clasificacion}
    WHERE Codigo_Nodo_Madre = @Codigo_Nodo_Madre;

    -- Recorremos semanas en orden
    DECLARE semCur CURSOR FOR
    SELECT Semana, Periodo, VentaSemanal, LlegadaSemanal
    FROM {TablaCalendarioMesesSemanasClasificacion}
    WHERE Codigo_Nodo_Madre = @Codigo_Nodo_Madre
    ORDER BY Periodo, Semana;

    OPEN semCur;
    FETCH NEXT FROM semCur INTO @Semana, @Periodo, @VentaSemanal, @LlegadasSemanal;

    WHILE @@FETCH_STATUS = 0
    BEGIN
        -- Si no hay stock inicial, no se descuenta venta
        IF @StockActual = 0
            SET @VentaSemanal = 0;

        -- Calcular stock para la semana
        SET @StockActual = @StockActual - @VentaSemanal + @LlegadasSemanal;

        -- Evitar negativos
        IF @StockActual < 0
            SET @StockActual = 0;

        -- Actualizar la tabla
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


-- Calcular StockMes como el stock de la última semana del mes
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

-- Calcular LlegadasMes como la suma de llegadas semanales del mes
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


-- Poblar fechas desde/hasta para cada semana
UPDATE c
SET c.FechaDesde = DATEADD(DAY, 1 - DATEPART(WEEKDAY, f.FechaBase), f.FechaBase),
    c.FechaHasta = DATEADD(DAY, 7 - DATEPART(WEEKDAY, f.FechaBase), f.FechaBase)
FROM {TablaCalendarioMesesSemanasClasificacion} c
CROSS APPLY (
    SELECT DATEADD(WEEK, c.Semana - DATEPART(WEEK, GETDATE()), GETDATE()) AS FechaBase
) f;



-- Para agregar nuevos calculos que me pasa Gonzalo

DECLARE @NMes Int = 6; -- horizonte en meses (variable)
DECLARE @XMeses Int = 2;

-- 1. Calcular stock necesario para N meses y N-2 meses
UPDATE c
SET c.StockNecesarioNMeses = p.Rotacion * @NMes,
    c.StockNecesarioNMenosXMeses = p.Rotacion * (@NMes - @XMeses)
FROM {TablaCalendarioMesesSemanasClasificacion} c
JOIN {TablaPasoRotacion_Clasificacion} p ON c.Codigo_Nodo_Madre = p.Codigo_Nodo_Madre;



-- 2. Simular consumo Mes a Mes

DECLARE @VentaMensual FLOAT;

DECLARE cur CURSOR FOR
SELECT DISTINCT Codigo_Nodo_Madre FROM {TablaCalendarioMesesSemanasClasificacion};

OPEN cur;
FETCH NEXT FROM cur INTO @Codigo_Nodo_Madre;

WHILE @@FETCH_STATUS = 0
BEGIN
    -- Stock inicial = stock necesario para N meses
    SELECT @StockActual = MAX(StockNecesarioNMeses)+MAX(VentaMes),
           @VentaMensual = MAX(VentaMes)
    FROM {TablaCalendarioMesesSemanasClasificacion}
    WHERE Codigo_Nodo_Madre = @Codigo_Nodo_Madre;

    -- Recorrer meses en orden
    DECLARE mesCur CURSOR FOR
    SELECT Mes, Periodo
    FROM {TablaCalendarioMesesSemanasClasificacion}
    WHERE Codigo_Nodo_Madre = @Codigo_Nodo_Madre
    GROUP BY Mes, Periodo
    ORDER BY Periodo, Mes;


    OPEN mesCur;
    FETCH NEXT FROM mesCur INTO @Mes, @Periodo;

    WHILE @@FETCH_STATUS = 0
    BEGIN
       -- Descontar solo ventas mensuales (sin sumar llegadas)
        SET @StockActual = @StockActual - @VentaMensual;
        IF @StockActual < 0 SET @StockActual = 0;

        -- Actualizar campo StockProyectado en todas las semanas del mes
        UPDATE {TablaCalendarioMesesSemanasClasificacion}
        SET StockProyectadoMensual = @StockActual
        WHERE Codigo_Nodo_Madre = @Codigo_Nodo_Madre AND Mes = @Mes AND Periodo = @Periodo;

        FETCH NEXT FROM mesCur INTO @Mes, @Periodo;
    END

    CLOSE mesCur;
    DEALLOCATE mesCur;

    FETCH NEXT FROM cur INTO @Codigo_Nodo_Madre;
END

CLOSE cur;
DEALLOCATE cur;


--DECLARE @NSem INT = @NMes * 24; -- horizonte en semanas (variable)

-- 1. Calcular stock necesario para N semanas y N-2 semanas
UPDATE c
SET c.StockNecesarioNSemanas = c.StockNecesarioNMeses --c.VentaSemanal * @NSem
    -- c.StockNecesarioNSemanasMenos2 = c.VentaSemanal * (@NSem - 2)
FROM {TablaCalendarioMesesSemanasClasificacion} c;

-- 2. Simular consumo semana a semana

DECLARE cur CURSOR FOR
SELECT DISTINCT Codigo_Nodo_Madre FROM {TablaCalendarioMesesSemanasClasificacion};

OPEN cur;
FETCH NEXT FROM cur INTO @Codigo_Nodo_Madre;

WHILE @@FETCH_STATUS = 0
BEGIN
    -- Stock inicial = stock necesario para N semanas
    SELECT @StockActual = MAX(StockNecesarioNSemanas)+MAX(VentaSemanal),
           @VentaSemanal = MAX(VentaSemanal)
    FROM {TablaCalendarioMesesSemanasClasificacion}
    WHERE Codigo_Nodo_Madre = @Codigo_Nodo_Madre;

    -- Recorrer semanas en orden
    DECLARE semCur CURSOR FOR
    SELECT Semana, Periodo
    FROM {TablaCalendarioMesesSemanasClasificacion}
    WHERE Codigo_Nodo_Madre = @Codigo_Nodo_Madre
    ORDER BY Periodo, Semana;

    OPEN semCur;
    FETCH NEXT FROM semCur INTO @Semana, @Periodo;

    WHILE @@FETCH_STATUS = 0
    BEGIN
        -- Descontar ventas semanales
        SET @StockActual = @StockActual - @VentaSemanal;
        IF @StockActual < 0 SET @StockActual = 0;

        -- Actualizar campo StockProyectadoSemanal
        UPDATE {TablaCalendarioMesesSemanasClasificacion}
        SET StockProyectadoSemanal = @StockActual
        WHERE Codigo_Nodo_Madre = @Codigo_Nodo_Madre AND Semana = @Semana AND Periodo = @Periodo;

        FETCH NEXT FROM semCur INTO @Semana, @Periodo;
    END

    CLOSE semCur;
    DEALLOCATE semCur;

    FETCH NEXT FROM cur INTO @Codigo_Nodo_Madre;
END

CLOSE cur;
DEALLOCATE cur;

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

