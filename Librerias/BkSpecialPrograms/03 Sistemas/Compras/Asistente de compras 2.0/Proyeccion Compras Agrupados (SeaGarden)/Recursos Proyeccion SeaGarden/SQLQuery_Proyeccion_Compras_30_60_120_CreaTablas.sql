SET NOCOUNT ON;

Declare @Identificador_NodoPadre Int = #Identificador_NodoPadre#
Declare @Porc_Creciminto Float = #Porc_Creciminto#
Declare @Dias_Proyeccion Float = #Dias_Proyeccion#
Declare @Dias_Abastecer Int
Declare @Marca_Proyeccion Int = #Marca_Proyeccion#
Declare @RotCalculo varchar(2) = '#RotCalculo#'
Declare @Fecha_Actual Date = GetDate()
Declare @MesesPreImportacion Int = #MesesPreImportacion#

Set @Porc_Creciminto = @Porc_Creciminto /100.0 + 1        
Set @Dias_Abastecer = #Dias_Abastecer#--@Dias_Proyeccion * 4
        

--Declare @Identificador_NodoPadre Int = 2;
--Declare @Porc_Creciminto Float = 0;
--Declare @Dias_Proyeccion Float = 22;
--Declare @Dias_Abastecer Int;
--Declare @Marca_Proyeccion Int = 3;
--Declare @RotCalculo varchar(2) = '3M';
--Declare @Fecha_Actual DATETIME = GETDATE();
--Declare @MesesPreImportacion Int = 6;

--Set @Porc_Creciminto = @Porc_Creciminto / 100.0 + 1;        
--Set @Dias_Abastecer = 130; -- @Dias_Proyeccion * 4

-- Crear/limpiar tablas fijas en dbo
IF OBJECT_ID('dbo.Tbl_Asc_01_Productos', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.Tbl_Asc_01_Productos (
        Codigo VARCHAR(100),
        Descripcion VARCHAR(400),
        Codigo_Nodo VARCHAR(50),
        Codigo_Nodo_Madre VARCHAR(50),
        Producto VARCHAR(400),
        UD#Ud# VARCHAR(50),
        Rtu VARCHAR(50),
        StockUd#Ud# FLOAT,
        StockEnTransitoUd#Ud# FLOAT,
        StockPedidoUd#Ud# FLOAT,
        StockFacSinRecepUd#Ud# FLOAT,
        Stock_CriticoUd#Ud#_Rd FLOAT,
        RotDiariaUd#Ud# FLOAT,
        RotMensualUd#Ud# FLOAT,
        RotDiariaUd#Ud#_Prod FLOAT,
        RotMensualUd#Ud#_Prod FLOAT,
        Promedio_Ud#Ud#_Prod FLOAT,
        Promedio_MensualUd#Ud#_Prod FLOAT,
        RotMensualUd#Ud#_Ult_3Mes_Prod FLOAT,
        PromMensualUd#Ud#_Ul3Mes_Prod FLOAT,
        PromUlt3CioPromUlt3Meses_Ud#Ud#_Prod FLOAT,
        SumTotalQtyUd#Ud# FLOAT,
        Fecha_Inicio DATE,
        Fecha_Fin DATE,
        Dias_Fecha FLOAT,
        Meses_Fecha FLOAT,
        SumTotalQtyUd#Ud#_Ult_3Mes FLOAT,
        SumTotalQtyUd#Ud#_Ult_3Cio FLOAT,
        Promedio_3Meses FLOAT,
        Tendencia FLOAT,
        RotCalculo FLOAT,
        Stock_Asegurado_Dias FLOAT,
        Stock_Asegurado_Proyeccion FLOAT,
        Duracion_Dias FLOAT,
        Duracion_Proyeccion FLOAT,
        Duracion_Proyeccion_Recepcion FLOAT,
        Cant_Comprar FLOAT,
        Cant_Comprar_Sug FLOAT,
        Cant_Comprar_Sug_Red FLOAT,
        Dias_Abastecer INT,
        Proyeccion_Abastecer FLOAT,
        Idmaeedo INT,
        Tido CHAR(3),
        Nudo VARCHAR(20),
        Fecha_Recep DATE
    );
END
ELSE
BEGIN
    TRUNCATE TABLE dbo.Tbl_Asc_01_Productos;
END

IF OBJECT_ID('dbo.Tbl_Asc_02_Asociaciones', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.Tbl_Asc_02_Asociaciones (
        Codigo_Nodo VARCHAR(50),
        Codigo_Nodo_Madre VARCHAR(50),
        Producto VARCHAR(400),
        StockUd#Ud# FLOAT,
        StockEnTransitoUd#Ud# FLOAT,
        StockPedidoUd#Ud# FLOAT,
        RotDiariaUd#Ud# FLOAT,
        RotMensualUd#Ud# FLOAT,
        StockFacSinRecepUd#Ud# FLOAT,
        Stock_CriticoUd#Ud#_Rd FLOAT,
        RotCalculo FLOAT,
        Venta_Periodo FLOAT,
        SumTotalQtyUd#Ud# FLOAT,
        Promedio_Diario FLOAT,
        Promedio_Mensual FLOAT,
        Promedio_DiarioUltMMU3Mes FLOAT,
        Promedio_UltMesMasPromUlt3Mes FLOAT,
        Fecha_Inicio DATE,
        Fecha_Fin DATE,
        Dias_Fecha FLOAT,
        Meses_Fecha FLOAT,
        SumTotalQtyUd#Ud#_Ult_3Mes FLOAT,
        Promedio_Diario3Mes FLOAT,
        Promedio_3Mes FLOAT,
        Venta_Ult_3Cio FLOAT,
        SumTotalQtyUd#Ud#_Ult_3Cio FLOAT,
        Tendencia FLOAT,
        Stock_Asegurado_Dias FLOAT,
        Stock_Asegurado_Proyeccion FLOAT,
        Duracion_Dias FLOAT,
        Duracion_Proyeccion FLOAT,
        Duracion_Proyeccion_Recepcion FLOAT,
        Cant_Comprar FLOAT,
        Cant_Comprar_Sug FLOAT,
        Cant_Comprar_Sug_Red FLOAT,
        Dias_Abastecer INT,
        Proyeccion_Abastecer FLOAT,
        PreImportacion VARCHAR(2),
        Idmaeedo_ProxRC INT,
        Tido_ProxRC CHAR(3),
        Nudo_ProxRC VARCHAR(10),
        Feerli_ProxRC DATETIME,
        Dias_ProxRC INT,
        Meses_ProxRC FLOAT,
        RotDiaria_NoQuiebra FLOAT,
        RotMensual_NoQuiebra FLOAT,
        SugCmbPrecio BIT,
        [01_P] CHAR(1),
        [02_P] CHAR(1),
        [03_P] CHAR(1),
        [04_P] CHAR(1),
        [05_P] CHAR(1),
        [06_P] CHAR(1),
        [07_P] CHAR(1),
        [08_P] CHAR(1),
        [09_P] CHAR(1),
        [10_P] CHAR(1),
        [11_P] CHAR(1),
        [12_P] CHAR(1),
        Fin CHAR(1)
    );
END
ELSE
BEGIN
    TRUNCATE TABLE dbo.Tbl_Asc_02_Asociaciones;
END

IF OBJECT_ID('dbo.Tbl_Asc_03_Totales', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.Tbl_Asc_03_Totales (
        StockUd FLOAT,
        StockPedidoUd FLOAT,
        StockFacSinRecepUd FLOAT,
        RotDiariaUd FLOAT,
        RotMensualUd FLOAT,
        Prom_Pond FLOAT,
        Cant_Comprar_Sug FLOAT,
        Cant_Comprar_Sug2 FLOAT
    );
END
ELSE
BEGIN
    TRUNCATE TABLE dbo.Tbl_Asc_03_Totales;
END

IF OBJECT_ID('dbo.Tbl_Asc_04_DocUltComp', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.Tbl_Asc_04_DocUltComp (
        Codigo VARCHAR(100),
        Codigo_Nodo_Madre VARCHAR(50),
        IDMAEEDO INT,
        TIDO CHAR(3),
        NUDO VARCHAR(20),
        ENDO VARCHAR(50),
        SUENDO VARCHAR(50),
        Razon VARCHAR(400),
        UD01PR VARCHAR(50),
        CAPRCO1 DECIMAL(18,2),
        CAPREX1 DECIMAL(18,2),
        Saldo DECIMAL(18,2),
        FEERLI DATETIME
    );
END
ELSE
BEGIN
    TRUNCATE TABLE dbo.Tbl_Asc_04_DocUltComp;
END

-- TABLA AGRUPADORA DE PRODUCTOS INDIVIDUALMENTE
INSERT INTO dbo.Tbl_Asc_01_Productos (
    Codigo, Descripcion, Codigo_Nodo, Codigo_Nodo_Madre, Producto, UD#Ud#, Rtu,
    StockUd#Ud#, StockEnTransitoUd#Ud#, StockPedidoUd#Ud#, StockFacSinRecepUd#Ud#,
    Stock_CriticoUd#Ud#_Rd, RotDiariaUd#Ud#, RotMensualUd#Ud#, RotDiariaUd#Ud#_Prod,
    RotMensualUd#Ud#_Prod, Promedio_Ud#Ud#_Prod, Promedio_MensualUd#Ud#_Prod,
    RotMensualUd#Ud#_Ult_3Mes_Prod, PromMensualUd#Ud#_Ul3Mes_Prod,
    PromUlt3CioPromUlt3Meses_Ud#Ud#_Prod, SumTotalQtyUd#Ud#, Fecha_Inicio, Fecha_Fin,
    Dias_Fecha, Meses_Fecha, SumTotalQtyUd#Ud#_Ult_3Mes, SumTotalQtyUd#Ud#_Ult_3Cio,
    Promedio_3Meses, Tendencia, RotCalculo, Stock_Asegurado_Dias,
    Stock_Asegurado_Proyeccion, Duracion_Dias, Duracion_Proyeccion,
    Duracion_Proyeccion_Recepcion, Cant_Comprar, Cant_Comprar_Sug,
    Cant_Comprar_Sug_Red, Dias_Abastecer, Proyeccion_Abastecer,
    Idmaeedo, Tido, Nudo, Fecha_Recep
)
SELECT
    Codigo,
    Descripcion,
    Codigo_Nodo,
    Codigo_Nodo_Madre,
    Descripcion_Madre As Producto,
    UD#Ud#, Rtu, 
    SUM(StockUd#Ud#_Prod) As StockUd#Ud#, 
    SUM(StockEnTransitoUd#Ud#_Prod) As StockEnTransitoUd#Ud#, 
    SUM(StockPedidoUd#Ud#_Prod) As StockPedidoUd#Ud#, 
    SUM(StockFacSinRecepUd#Ud#_Prod) As StockFacSinRecepUd#Ud#,
    Stock_CriticoUd#Ud#_Rd,
    RotDiariaUd#Ud#, 
    RotMensualUd#Ud#, 
    RotDiariaUd#Ud#_Prod, 
    RotMensualUd#Ud#_Prod,
    Promedio_Ud#Ud#_Prod,
    Promedio_MensualUd#Ud#_Prod,
    RotMensualUd#Ud#_Ult_3Mes_Prod,
    PromMensualUd#Ud#_Ul3Mes_Prod,
    PromUlt3CioPromUlt3Meses_Ud#Ud#_Prod,
    SUM(SumTotalQtyUd#Ud#) AS SumTotalQtyUd#Ud#,
    Fecha_Inicio,
    Fecha_Fin,
    CAST(0 As float) As Dias_Fecha,
    CAST(0 As float) As Meses_Fecha,
    SUM(SumTotalQtyUd#Ud#_Ult_3Mes) AS SumTotalQtyUd#Ud#_Ult_3Mes,
    SUM(SumTotalQtyUd#Ud#_Ult_3Cio) AS SumTotalQtyUd#Ud#_Ult_3Cio,
    CAST(0 As Float) As Promedio_3Meses,
    CAST(0 As Float) As Tendencia,
    CAST(0 As Float) As RotCalculo, 
    CAST(0 As Float) As Stock_Asegurado_Dias, 
    CAST(0 As Float) As Stock_Asegurado_Proyeccion, 
    CAST(0 As Float) As Duracion_Dias, 
    CAST(0 As Float) As Duracion_Proyeccion, 
    CAST(0 As Float) As Duracion_Proyeccion_Recepcion, 
    CAST(0 As Float) As Cant_Comprar,
    CAST(0 As Float) As Cant_Comprar_Sug,
    CAST(0 As Float) As Cant_Comprar_Sug_Red,
    @Dias_Abastecer AS Dias_Abastecer,
    CAST(0 As Float) As Proyeccion_Abastecer,
    CAST(0 As Int) As Idmaeedo,
    CAST('' As CHAR(3)) As Tido,
    CAST('' As Varchar(10)) As Nudo,
    Null As Fecha_Recep
FROM Zw_InfCompras01RDF
WHERE Codigo IN (
    SELECT Codigo
    FROM BAKAPP_SG.dbo.Zw_Prod_Asociacion 
    WHERE Codigo_Nodo IN (
        SELECT DISTINCT Codigo_Nodo
        FROM BAKAPP_SG.dbo.Zw_TblArbol_Asociaciones 
        WHERE Identificacdor_NodoPadre = @Identificador_NodoPadre
    )
)
AND Es_Agrupador = 0
GROUP BY UD#Ud#, Rtu, Codigo, Descripcion, Codigo_Nodo, Codigo_Nodo_Madre, Descripcion_Madre,
         Stock_CriticoUd#Ud#_Rd, RotDiariaUd#Ud#, RotDiariaUd#Ud#_Prod, RotMensualUd#Ud#, RotMensualUd#Ud#_Prod,
         Fecha_Inicio, Fecha_Fin,
         Promedio_Ud#Ud#_Prod, Promedio_MensualUd#Ud#_Prod, RotMensualUd#Ud#_Ult_3Mes_Prod,
         PromMensualUd#Ud#_Ul3Mes_Prod, PromUlt3CioPromUlt3Meses_Ud#Ud#_Prod;

-- Actualizaciones posteriores: reemplazar referencias a #Tbl_Asc_01_Productos por dbo.Tbl_Asc_01_Productos
UPDATE dbo.Tbl_Asc_01_Productos SET Dias_Fecha = DATEDIFF(DAY, Fecha_Inicio, Fecha_Fin);
UPDATE dbo.Tbl_Asc_01_Productos SET Meses_Fecha = DATEDIFF(MONTH, Fecha_Inicio, Fecha_Fin);

UPDATE p
SET Idmaeedo = ISNULL(m.IDMAEEDO, 0)
FROM dbo.Tbl_Asc_01_Productos p
OUTER APPLY (
    SELECT TOP 1 IDMAEEDO
    FROM MAEDDO d
    WHERE d.KOPRCT = p.Codigo
      AND d.TIDO IN ('OCC', 'FCC')
      AND d.ESLIDO = ''
    ORDER BY d.FEERLI
) m;

Update Tbl_Asc_01_Productos Set Tido = Edo.TIDO,Nudo = Edo.NUDO,Fecha_Recep = Edo.FEERLI
FROM   Tbl_Asc_01_Productos Zp INNER JOIN
       MAEDDO Edo ON Zp.Idmaeedo = Edo.IDMAEEDO

-- Actualizaciones de cálculo: mantuve tus lógicas pero apuntando a las tablas fijas
UPDATE dbo.Tbl_Asc_01_Productos SET Cant_Comprar = ROUND((RotCalculo*@Porc_Creciminto)*@Dias_Abastecer,0);
UPDATE dbo.Tbl_Asc_01_Productos SET Cant_Comprar_Sug = ROUND(Cant_Comprar - (StockUd#Ud#+StockPedidoUd#Ud#+StockFacSinRecepUd#Ud#+StockEnTransitoUd#Ud#),0);
UPDATE dbo.Tbl_Asc_01_Productos SET Cant_Comprar_Sug_Red = Cant_Comprar_Sug;
UPDATE dbo.Tbl_Asc_01_Productos SET Proyeccion_Abastecer = CEILING(ROUND(Dias_Abastecer/@Dias_Proyeccion,2));

-- Agregar datos agregados a Tbl_Asc_02_Asociaciones (antes: SELECT ... INTO #Tbl_Asc_02_Asociaciones)
INSERT INTO dbo.Tbl_Asc_02_Asociaciones (
    Codigo_Nodo, Codigo_Nodo_Madre, Producto, StockUd#Ud#, StockEnTransitoUd#Ud#, StockPedidoUd#Ud#,
    RotDiariaUd#Ud#, RotMensualUd#Ud#, StockFacSinRecepUd#Ud#, Stock_CriticoUd#Ud#_Rd, RotCalculo,
    Venta_Periodo, SumTotalQtyUd#Ud#, Promedio_Diario, Promedio_Mensual, Promedio_DiarioUltMMU3Mes,
    Promedio_UltMesMasPromUlt3Mes, Fecha_Inicio, Fecha_Fin, Dias_Fecha, Meses_Fecha,
    SumTotalQtyUd#Ud#_Ult_3Mes, Promedio_Diario3Mes, Promedio_3Mes, Venta_Ult_3Cio,
    SumTotalQtyUd#Ud#_Ult_3Cio, Tendencia, Stock_Asegurado_Dias, Stock_Asegurado_Proyeccion,
    Duracion_Dias, Duracion_Proyeccion, Duracion_Proyeccion_Recepcion, Cant_Comprar,
    Cant_Comprar_Sug, Cant_Comprar_Sug_Red, Dias_Abastecer, Proyeccion_Abastecer,
    PreImportacion, Idmaeedo_ProxRC, Tido_ProxRC, Nudo_ProxRC, Feerli_ProxRC,
    Dias_ProxRC, Meses_ProxRC, RotDiaria_NoQuiebra, RotMensual_NoQuiebra, SugCmbPrecio,
    [01_P],[02_P],[03_P],[04_P],[05_P],[06_P],[07_P],[08_P],[09_P],[10_P],[11_P],[12_P], Fin
)
SELECT
    Codigo_Nodo,
    Codigo_Nodo_Madre,
    Producto,
    Sum(StockUd#Ud#) As StockUd#Ud#, 
    SUM(StockEnTransitoUd#Ud#) As StockEnTransitoUd#Ud#, 
    Sum(StockPedidoUd#Ud#) As StockPedidoUd#Ud#, 
    RotDiariaUd#Ud#, 
    RotMensualUd#Ud#, 
    Sum(StockFacSinRecepUd#Ud#) As StockFacSinRecepUd#Ud#,
    Stock_CriticoUd#Ud#_Rd,
    SUM(RotCalculo) As RotCalculo,
    CAST(0 As Float) As Venta_Periodo,
    SUM(SumTotalQtyUd#Ud#) As SumTotalQtyUd#Ud#,
    CAST(0 As Float) As Promedio_Diario,
    CAST(0 As Float) As Promedio_Mensual,
    CAST(0 As Float) As Promedio_DiarioUltMMU3Mes,
    CAST(0 As Float) As Promedio_UltMesMasPromUlt3Mes,
    Fecha_Inicio,
    Fecha_Fin,
    Dias_Fecha,
    Meses_Fecha,
    SUM(SumTotalQtyUd#Ud#_Ult_3Mes) AS SumTotalQtyUd#Ud#_Ult_3Mes,
    CAST(0 As Float) As Promedio_Diario3Mes,
    CAST(0 As Float) As Promedio_3Mes,
    CAST(0 As Float) As Venta_Ult_3Cio,
    SUM(SumTotalQtyUd#Ud#_Ult_3Cio) AS SumTotalQtyUd#Ud#_Ult_3Cio,
    CAST(0 As Float) As Tendencia,
    CAST(0 As Float) As Stock_Asegurado_Dias,
    CAST(0 As Float) As Stock_Asegurado_Proyeccion,
    CAST(0 As Float) As Duracion_Dias,
    CAST(0 As Float) As Duracion_Proyeccion,
    CAST(0 As Float) As Duracion_Proyeccion_Recepcion,
    SUM(Cant_Comprar) As Cant_Comprar,
    SUM(Cant_Comprar_Sug) As Cant_Comprar_Sug,
    SUM(Cant_Comprar_Sug_Red) As Cant_Comprar_Sug_Red,
    Dias_Abastecer,
    Proyeccion_Abastecer,
    Cast('No' As varchar(2)) As PreImportacion,
    CAST(0 As int) As Idmaeedo_ProxRC,
    CAST('' As char(3)) As Tido_ProxRC,
    CAST('' As char(10)) As Nudo_ProxRC,
    CAST(Null As datetime) As Feerli_ProxRC,
    CAST(0 As int) AS Dias_ProxRC,
    CAST(0 As float) As Meses_ProxRC,
    CAST(0 As float) As RotDiaria_NoQuiebra,
    CAST(0 As float) As RotMensual_NoQuiebra,
    CAST(0 As bit) As SugCmbPrecio,
    CAST('' As Char(1)) As [01_P],
    CAST('' As Char(1)) As [02_P],
    CAST('' As Char(1)) As [03_P],
    CAST('' As Char(1)) As [04_P],
    CAST('' As Char(1)) As [05_P],
    CAST('' As Char(1)) As [06_P],
    CAST('' As Char(1)) As [07_P],
    CAST('' As Char(1)) As [08_P],
    CAST('' As Char(1)) As [09_P],
    CAST('' As Char(1)) As [10_P],
    CAST('' As Char(1)) As [11_P],
    CAST('' As Char(1)) As [12_P],
    CAST('' As Char(1)) As Fin
FROM dbo.Tbl_Asc_01_Productos
Group By Codigo_Nodo, Codigo_Nodo_Madre, Producto, Dias_Abastecer, Proyeccion_Abastecer,
         Stock_CriticoUd#Ud#_Rd, RotDiariaUd#Ud#, RotMensualUd#Ud#, Fecha_Inicio, Fecha_Fin, Dias_Fecha, Meses_Fecha
Order by Producto;

-- Actualizaciones sobre Tbl_Asc_02_Asociaciones (mismo contenido que tu script original)
UPDATE dbo.Tbl_Asc_02_Asociaciones SET Promedio_Diario = Round(SumTotalQtyUd#Ud#/Dias_Fecha,2);
UPDATE dbo.Tbl_Asc_02_Asociaciones SET Promedio_Mensual = Round(Promedio_Diario*30.666,2);
UPDATE dbo.Tbl_Asc_02_Asociaciones SET Promedio_3Mes = Round(SumTotalQtyUd#Ud#_Ult_3Mes/3,2);
UPDATE dbo.Tbl_Asc_02_Asociaciones SET Promedio_Diario3Mes = Round(Promedio_3Mes/30.666,2);
UPDATE dbo.Tbl_Asc_02_Asociaciones SET Promedio_UltMesMasPromUlt3Mes = Round((SumTotalQtyUd#Ud#_Ult_3Cio+Promedio_3Mes)/2,2);
UPDATE dbo.Tbl_Asc_02_Asociaciones SET Promedio_DiarioUltMMU3Mes = Round(Promedio_UltMesMasPromUlt3Mes/30.666,2);

-- Actualización de RotCalculo en ambas tablas
UPDATE dbo.Tbl_Asc_01_Productos
SET RotCalculo = 
    CASE @RotCalculo
        WHEN 'D' THEN RotDiariaUd#Ud#_Prod
        WHEN 'P' THEN Promedio_MensualUd#Ud#_Prod
        WHEN 'X' THEN RotMensualUd#Ud#_Ult_3Mes_Prod
        WHEN '3M' THEN PromMensualUd#Ud#_Ul3Mes_Prod
        ELSE RotCalculo
    END;

UPDATE dbo.Tbl_Asc_02_Asociaciones
SET RotCalculo = 
    CASE @RotCalculo
        WHEN 'D' THEN RotDiariaUd#Ud#
        WHEN 'P' THEN Promedio_Diario
        WHEN 'X' THEN Promedio_DiarioUltMMU3Mes
        WHEN '3M' THEN Promedio_Diario3Mes
        ELSE RotCalculo
    END;

IF @RotCalculo <> 'D'
BEGIN
    Set @Dias_Proyeccion = 30.666;
END

-- Más cálculos
UPDATE dbo.Tbl_Asc_02_Asociaciones Set Cant_Comprar = ROUND((RotCalculo*@Porc_Creciminto)*@Dias_Abastecer,0);
UPDATE dbo.Tbl_Asc_02_Asociaciones Set Cant_Comprar_Sug = ROUND(Cant_Comprar - (StockUd#Ud#+StockPedidoUd#Ud#+StockFacSinRecepUd#Ud#+StockEnTransitoUd#Ud#),0);
UPDATE dbo.Tbl_Asc_02_Asociaciones Set Cant_Comprar_Sug_Red = Cant_Comprar_Sug;
UPDATE dbo.Tbl_Asc_02_Asociaciones Set Venta_Periodo = RotCalculo * @Dias_Proyeccion;

UPDATE dbo.Tbl_Asc_02_Asociaciones Set Venta_Ult_3Cio = SumTotalQtyUd#Ud#_Ult_3Cio/3;
UPDATE dbo.Tbl_Asc_02_Asociaciones Set Tendencia = Round(SumTotalQtyUd#Ud#_Ult_3Cio/Promedio_3Mes,5) Where Promedio_3Mes > 0;
UPDATE dbo.Tbl_Asc_02_Asociaciones Set Tendencia = Tendencia-1 Where Tendencia < 0;
UPDATE dbo.Tbl_Asc_02_Asociaciones Set Tendencia = (1-Tendencia)*-1 Where Tendencia < 1 And Tendencia > 0;
UPDATE dbo.Tbl_Asc_02_Asociaciones Set Tendencia = Tendencia - 1 Where Tendencia > 1;
UPDATE dbo.Tbl_Asc_02_Asociaciones Set Tendencia = Round(Tendencia,2);
UPDATE dbo.Tbl_Asc_02_Asociaciones Set Tendencia = 0 Where SumTotalQtyUd#Ud#_Ult_3Cio = Promedio_3Mes;
UPDATE dbo.Tbl_Asc_02_Asociaciones Set Tendencia = -1 Where SumTotalQtyUd#Ud#_Ult_3Cio = 0 And Promedio_3Mes > 0;

UPDATE dbo.Tbl_Asc_02_Asociaciones Set Stock_Asegurado_Dias = ROUND((StockUd#Ud#+StockEnTransitoUd#Ud#)/ NULLIF(RotCalculo,1),0)
WHERE RotCalculo > 0;

UPDATE dbo.Tbl_Asc_02_Asociaciones Set Stock_Asegurado_Proyeccion = ROUND(((StockUd#Ud#/ NULLIF(RotCalculo,1))* @Porc_Creciminto)/@Dias_Proyeccion,0)
WHERE RotCalculo > 0;

UPDATE dbo.Tbl_Asc_02_Asociaciones Set Duracion_Dias = ROUND((StockUd#Ud#+StockPedidoUd#Ud#+StockFacSinRecepUd#Ud#+StockEnTransitoUd#Ud#)/NULLIF(RotCalculo,1),0)
WHERE RotCalculo > 0;

UPDATE dbo.Tbl_Asc_02_Asociaciones Set Duracion_Proyeccion = 
    ROUND((((StockUd#Ud#+StockPedidoUd#Ud#+StockFacSinRecepUd#Ud#+StockEnTransitoUd#Ud#)/NULLIF(RotCalculo,1)) * @Porc_Creciminto)/@Dias_Proyeccion,2)
WHERE RotCalculo > 0;

UPDATE dbo.Tbl_Asc_02_Asociaciones Set Duracion_Proyeccion_Recepcion = 
    ROUND(((StockPedidoUd#Ud#+StockFacSinRecepUd#Ud#)/ NULLIF(RotCalculo,1) * @Porc_Creciminto)/@Dias_Proyeccion,2)
WHERE RotCalculo > 0;

-- Pre importación
UPDATE dbo.Tbl_Asc_02_Asociaciones Set PreImportacion = 'Si' Where Duracion_Proyeccion > @MesesPreImportacion;

-- Casos RotCalculo = 0
UPDATE dbo.Tbl_Asc_02_Asociaciones Set Stock_Asegurado_Dias = ROUND((StockUd#Ud#+StockEnTransitoUd#Ud#)/1,0) Where RotCalculo = 0;
UPDATE dbo.Tbl_Asc_02_Asociaciones Set Stock_Asegurado_Proyeccion = ROUND((((StockUd#Ud#+StockEnTransitoUd#Ud#)/1)* @Porc_Creciminto)/@Dias_Proyeccion,0) Where RotCalculo = 0;
UPDATE dbo.Tbl_Asc_02_Asociaciones Set Duracion_Dias = ROUND((StockUd#Ud#+StockPedidoUd#Ud#+StockFacSinRecepUd#Ud#+StockEnTransitoUd#Ud#)/1,0) Where RotCalculo = 0;

-- Actualizaciones de marcadores 01..12
UPDATE dbo.Tbl_Asc_02_Asociaciones Set [01_P] = CASE WHEN Duracion_Proyeccion >= 1 THEN CASE WHEN @Marca_Proyeccion < 1 THEN 'O' ELSE 'X' END ELSE '-' END;
UPDATE dbo.Tbl_Asc_02_Asociaciones Set [02_P] = CASE WHEN Duracion_Proyeccion >= 2 THEN CASE WHEN @Marca_Proyeccion < 2 THEN 'O' ELSE 'X' END ELSE '-' END;
UPDATE dbo.Tbl_Asc_02_Asociaciones Set [03_P] = CASE WHEN Duracion_Proyeccion >= 3 THEN CASE WHEN @Marca_Proyeccion < 3 THEN 'O' ELSE 'X' END ELSE '-' END;
UPDATE dbo.Tbl_Asc_02_Asociaciones Set [04_P] = CASE WHEN Duracion_Proyeccion >= 4 THEN CASE WHEN @Marca_Proyeccion < 4 THEN 'O' ELSE 'X' END ELSE '-' END;
UPDATE dbo.Tbl_Asc_02_Asociaciones Set [05_P] = CASE WHEN Duracion_Proyeccion >= 5 THEN CASE WHEN @Marca_Proyeccion < 5 THEN 'O' ELSE 'X' END ELSE '-' END;
UPDATE dbo.Tbl_Asc_02_Asociaciones Set [06_P] = CASE WHEN Duracion_Proyeccion >= 6 THEN CASE WHEN @Marca_Proyeccion < 6 THEN 'O' ELSE 'X' END ELSE '-' END;
UPDATE dbo.Tbl_Asc_02_Asociaciones Set [07_P] = CASE WHEN Duracion_Proyeccion >= 7 THEN CASE WHEN @Marca_Proyeccion < 7 THEN 'O' ELSE 'X' END ELSE '-' END;
UPDATE dbo.Tbl_Asc_02_Asociaciones Set [08_P] = CASE WHEN Duracion_Proyeccion >= 8 THEN CASE WHEN @Marca_Proyeccion < 8 THEN 'O' ELSE 'X' END ELSE '-' END;
UPDATE dbo.Tbl_Asc_02_Asociaciones Set [09_P] = CASE WHEN Duracion_Proyeccion >= 9 THEN CASE WHEN @Marca_Proyeccion < 9 THEN 'O' ELSE 'X' END ELSE '-' END;
UPDATE dbo.Tbl_Asc_02_Asociaciones Set [10_P] = CASE WHEN Duracion_Proyeccion >= 10 THEN CASE WHEN @Marca_Proyeccion < 10 THEN 'O' ELSE 'X' END ELSE '-' END;
UPDATE dbo.Tbl_Asc_02_Asociaciones Set [11_P] = CASE WHEN Duracion_Proyeccion >= 11 THEN CASE WHEN @Marca_Proyeccion < 11 THEN 'O' ELSE 'X' END ELSE '-' END;
UPDATE dbo.Tbl_Asc_02_Asociaciones Set [12_P] = CASE WHEN Duracion_Proyeccion >= 12 THEN CASE WHEN @Marca_Proyeccion < 12 THEN 'O' ELSE 'X' END ELSE '-' END;

UPDATE dbo.Tbl_Asc_02_Asociaciones Set Cant_Comprar = 0, Cant_Comprar_Sug = 0, Cant_Comprar_Sug_Red = 0
Where Duracion_Proyeccion > Proyeccion_Abastecer;
UPDATE dbo.Tbl_Asc_02_Asociaciones Set Cant_Comprar = 0 Where Cant_Comprar < 0;
UPDATE dbo.Tbl_Asc_02_Asociaciones Set Cant_Comprar_Sug = 0 Where Cant_Comprar_Sug < 0;
UPDATE dbo.Tbl_Asc_02_Asociaciones Set Cant_Comprar_Sug_Red = 0 Where Cant_Comprar_Sug_Red < 0;

-- Totales en Tbl_Asc_03_Totales (antes INTO #Tbl_Asc_03_Totales)
INSERT INTO dbo.Tbl_Asc_03_Totales (StockUd, StockPedidoUd, StockFacSinRecepUd, RotDiariaUd, RotMensualUd, Prom_Pond, Cant_Comprar_Sug, Cant_Comprar_Sug2)
SELECT
    Sum(StockUd#Ud#) As StockUd, 
    Sum(StockPedidoUd#Ud#) As StockPedidoUd, 
    Sum(StockFacSinRecepUd#Ud#) As StockFacSinRecepUd,
    Sum(RotDiariaUd#Ud#) As RotDiariaUd, 
    Sum(Venta_Periodo) As RotMensualUd,
    Cast(0 As Float) As Prom_Pond,				
    Sum(Cant_Comprar_Sug) AS Cant_Comprar_Sug,
    Cast(0 As Float) AS Cant_Comprar_Sug2
FROM dbo.Tbl_Asc_02_Asociaciones;

UPDATE dbo.Tbl_Asc_03_Totales Set Prom_Pond = Round((StockUd+StockPedidoUd+StockFacSinRecepUd) / NULLIF(RotMensualUd,0),2) Where RotMensualUd > 0;
UPDATE dbo.Tbl_Asc_03_Totales Set Cant_Comprar_Sug2 = Ceiling(Round(Cant_Comprar_Sug/23000,2));

-- Tbl_Asc_04_DocUltComp (antes SELECT ... INTO #Tbl_Asc_04_DocUltComp)
INSERT INTO dbo.Tbl_Asc_04_DocUltComp (Codigo, Codigo_Nodo_Madre, IDMAEEDO, TIDO, NUDO, ENDO, SUENDO, Razon, UD01PR, CAPRCO1, CAPREX1, Saldo, FEERLI)
SELECT
    KOPRCT As Codigo,
    Ps1.Codigo_Nodo_Madre,
    IDMAEEDO,
    TIDO,
    NUDO,
    ENDO,
    SUENDO,
    Isnull(NOKOEN,'???') As Razon,
    UD01PR,
    CAPRCO1,
    CAPREX1,
    (CAPRCO1-(CAPRAD1+CAPREX1)) As Saldo,
    FEERLI 
FROM MAEDDO Ddo
Left Join MAEEN On KOEN = ENDO And SUEN = SUENDO
Left Join dbo.Tbl_Asc_01_Productos Ps1 On Ps1.Codigo = Ddo.KOPRCT 
Where KOPRCT In (Select Codigo From dbo.Tbl_Asc_01_Productos) And TIDO In ('OCC','FCC') And ESLIDO = '' 
Order By FEERLI;

-- Actualizaciones que referencian Tbl_Asc_04_DocUltComp y Tbl_Asc_02_Asociaciones
UPDATE p
SET Idmaeedo_ProxRC = ISNULL((SELECT TOP 1 IDMAEEDO FROM dbo.Tbl_Asc_04_DocUltComp pc WHERE pc.Codigo_Nodo_Madre = p.Codigo_Nodo_Madre ORDER BY FEERLI), 0)
FROM dbo.Tbl_Asc_02_Asociaciones p;

UPDATE dbo.Tbl_Asc_02_Asociaciones
SET Tido_ProxRC = pc.TIDO, Nudo_ProxRC = pc.NUDO, Feerli_ProxRC = pc.FEERLI
FROM dbo.Tbl_Asc_02_Asociaciones t
INNER JOIN dbo.Tbl_Asc_04_DocUltComp pc ON t.Idmaeedo_ProxRC = pc.IDMAEEDO;

UPDATE dbo.Tbl_Asc_02_Asociaciones Set Dias_ProxRC = DATEDIFF(DAY,GETDATE(),Feerli_ProxRC), Meses_ProxRC = DATEDIFF(MONTH,GETDATE(),Feerli_ProxRC)
Where Idmaeedo_ProxRC > 0;

UPDATE dbo.Tbl_Asc_02_Asociaciones Set RotDiaria_NoQuiebra = Round((StockUd#Ud#/Dias_ProxRC),0), RotMensual_NoQuiebra = Round((StockUd#Ud#/Dias_ProxRC) * @Dias_Proyeccion,0)
Where Idmaeedo_ProxRC > 0 And Dias_ProxRC <> 0;

UPDATE dbo.Tbl_Asc_02_Asociaciones Set SugCmbPrecio = 1
Where RotDiaria_NoQuiebra < RotCalculo And RotDiaria_NoQuiebra > 0;

-- Nuevo estudio
UPDATE dbo.Tbl_Asc_02_Asociaciones Set 
    SugCmbPrecio = 1,
    RotDiaria_NoQuiebra = Round((StockUd#Ud#/@Dias_Abastecer),0),
    RotMensual_NoQuiebra = Round((StockUd#Ud#/@Dias_Abastecer) * @Dias_Proyeccion,0)
Where StockPedidoUd#Ud# = 0 
And StockFacSinRecepUd#Ud# = 0 
And Stock_Asegurado_Dias < @Dias_Abastecer 
And StockUd#Ud# > 0 And Duracion_Proyeccion > 0;

-- Salidas que antes imprimían SELECT * FROM #...
SELECT * From dbo.Tbl_Asc_01_Productos Order by Producto;
SELECT * From dbo.Tbl_Asc_02_Asociaciones;
SELECT * From dbo.Tbl_Asc_04_DocUltComp;
SELECT * From dbo.Tbl_Asc_03_Totales;

SELECT Codigo_Nodo_Madre,Producto,StockUd#Ud#,Promedio_Mensual,RotMensualUd#Ud#,RotMensual_NoQuiebra,SugCmbPrecio,Cast(0 As Float) As PPV,
    Cast(0 As Float) As MinPrecio,Cast(0 As Float) As MaxPrecio,CAST(0 As Bit) As RevisarPrecio
From dbo.Tbl_Asc_02_Asociaciones 
Where SugCmbPrecio = 1;

-- NOTA: ya no se eliminan las tablas al final porque son tablas permanentes en dbo.
-- Si quieres vaciarlas al terminar, usa TRUNCATE TABLE dbo.Tbl_Asc_01_Productos; etc.

--Drop Table dbo.Tbl_Asc_01_Productos;
--Drop Table dbo.Tbl_Asc_02_Asociaciones;
--Drop Table dbo.Tbl_Asc_04_DocUltComp;
--Drop Table dbo.Tbl_Asc_03_Totales;

