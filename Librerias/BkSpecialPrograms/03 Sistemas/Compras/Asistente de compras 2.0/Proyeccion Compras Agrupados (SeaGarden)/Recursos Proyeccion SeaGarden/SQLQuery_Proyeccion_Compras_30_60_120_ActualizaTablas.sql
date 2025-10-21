SET NOCOUNT ON;

Declare @Identificador_NodoPadre Int = #Identificador_NodoPadre#
Declare @Porc_Creciminto Float = #Porc_Creciminto#
Declare @Dias_Proyeccion Float = #Dias_Proyeccion#
Declare @Dias_Abastecer Int
Declare @Marca_Proyeccion Int = #Marca_Proyeccion#
Declare @RotCalculo varchar(2) = '#RotCalculo#'
Declare @Fecha_Actual Date = GetDate()
--Declare @MesesSobreStock Int = #MesesSobreStock#

Set @Porc_Creciminto = @Porc_Creciminto /100.0 + 1        
Set @Dias_Abastecer = #Dias_Abastecer#--@Dias_Proyeccion * 4

-- D = MEDIANA
-- P = PROMEDIO
-- 3M = ULTIMOS 3 MESES
-- X = ULTIMOS 3 MESES MAS ULTIMO TERCIO / 2


-- Actualización de RotCalculo en ambas tablas
UPDATE dbo.Tbl_Asc_01_Productos
SET RotCalculo = 
    CASE @RotCalculo
        WHEN 'D' THEN RotMensualUd#Ud#_Prod
        WHEN 'P' THEN Promedio_MensualUd#Ud#_Prod
        WHEN 'X' THEN PromUlt3CioPromUlt3Meses_Ud#Ud#_Prod
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

UPDATE dbo.Tbl_Asc_01_Productos Set Duracion_Proyeccion = 
    ROUND((((StockUd#Ud#+StockPedidoUd#Ud#+StockFacSinRecepUd#Ud#+StockEnTransitoUd#Ud#)/NULLIF(RotCalculo,1)) * @Porc_Creciminto),2)
WHERE RotCalculo > 0;

UPDATE dbo.Tbl_Asc_01_Productos Set Duracion_Proyeccion_Recepcion = 
    ROUND(((StockPedidoUd#Ud#+StockFacSinRecepUd#Ud#)/ NULLIF(RotCalculo,1) * @Porc_Creciminto),2)
WHERE RotCalculo > 0;

-- Sobre Stock
UPDATE dbo.Tbl_Asc_01_Productos Set SobreStock = 'No' Where Duracion_Proyeccion < MesesSobreStock;
UPDATE dbo.Tbl_Asc_02_Asociaciones Set SobreStock = 'No' Where Duracion_Proyeccion < MesesSobreStock;
UPDATE dbo.Tbl_Asc_01_Productos Set SobreStock = 'Si' Where Duracion_Proyeccion >= MesesSobreStock;
UPDATE dbo.Tbl_Asc_02_Asociaciones Set SobreStock = 'Si' Where Duracion_Proyeccion >= MesesSobreStock;

-- Casos RotCalculo = 0
UPDATE dbo.Tbl_Asc_02_Asociaciones Set Stock_Asegurado_Dias = ROUND((StockUd#Ud#+StockEnTransitoUd#Ud#)/1,0) Where RotCalculo = 0;
UPDATE dbo.Tbl_Asc_02_Asociaciones Set Stock_Asegurado_Proyeccion = ROUND((((StockUd#Ud#+StockEnTransitoUd#Ud#)/1)* @Porc_Creciminto)/@Dias_Proyeccion,0) Where RotCalculo = 0;
UPDATE dbo.Tbl_Asc_02_Asociaciones Set Duracion_Dias = ROUND((StockUd#Ud#+StockPedidoUd#Ud#+StockFacSinRecepUd#Ud#+StockEnTransitoUd#Ud#)/1,0) Where RotCalculo = 0;

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
SELECT * From dbo.Tbl_Asc_01_Productos 
--FiltroProductosSoloConStock Where (StockUd#Ud#+StockPedidoUd#Ud#+StockFacSinRecepUd#Ud#+StockEnTransitoUd#Ud#) <> 0
Order by Producto;

SELECT * From dbo.Tbl_Asc_02_Asociaciones;
SELECT * From dbo.Tbl_Asc_04_DocUltComp;
SELECT * From dbo.Tbl_Asc_03_Totales;

SELECT Codigo_Nodo_Madre,Producto,StockUd#Ud#,Promedio_Mensual,RotMensualUd#Ud#,RotMensual_NoQuiebra,SugCmbPrecio,Cast(0 As Float) As PPV,
    Cast(0 As Float) As MinPrecio,Cast(0 As Float) As MaxPrecio,CAST(0 As Bit) As RevisarPrecio
From dbo.Tbl_Asc_02_Asociaciones 
Where SugCmbPrecio = 1;