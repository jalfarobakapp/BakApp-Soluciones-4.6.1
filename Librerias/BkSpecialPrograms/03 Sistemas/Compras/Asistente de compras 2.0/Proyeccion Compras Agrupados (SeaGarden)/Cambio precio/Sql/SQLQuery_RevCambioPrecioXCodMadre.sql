DECLARE @Empresa		    Char(2)  = '{Empresa}'
DECLARE @CantidadMax	    Float = {CantidadMax}	    -- <-- ACA PONER LA CANTIDAD DE KILOS PARA REVISAER	
DECLARE @CantidadNoQuiebra	Float = {CantidadNoQuiebra}
DECLARE @Lista		        Char(3) = '{Lista}'
DECLARE @IDMAEDDO		    Int
DECLARE @cantidad		    Decimal(10,2)
DECLARE @suma_acumulada     Decimal(10,2) = 0
DECLARE @CodigoMadre	    Varchar(20) = '{CodMadre}' --< -- ACA VA EL CODIGO DE LA CLASIFICACION DEL PRODUCTO
DECLARE @Descripcion	    Varchar(50) = (Select top 1 Descripcion From {Bakapp}Zw_TblArbol_Asociaciones Where Codigo_Madre = @CodigoMadre) --TILAPIA IVP' = 
DECLARE @FechaDesde		    Datetime = '{FechaDesde}'
DECLARE @FechaHasta		    Datetime = '{FechaHasta}' 

--DECLARE @Empresa        Char(2)  = '01'
--DECLARE @CantidadMax    Float = 4413    -- <-- ACA PONER LA CANTIDAD DE KILOS    
--DECLARE @Lista          Char(3) = '01P'
--DECLARE @IDMAEDDO       Int
--DECLARE @cantidad       Decimal(10,2)
--DECLARE @suma_acumulada Decimal(10,2) = 0
--DECLARE @CodigoMadre    Varchar(20) = 'IMPOR15' --< -- ACA VA EL CODIGO DE LA CLASIFICACION DEL PRODUCTO
--DECLARE @Descripcion    Varchar(50) = (Select top 1 Descripcion From BAKAPP_SG.dbo.Zw_TblArbol_Asociaciones Where Codigo_Madre = @CodigoMadre) --TILAPIA IVP' = 
--DECLARE @FechaDesde     Datetime = '20240604'
--DECLARE @FechaHasta     Datetime = '20240904' 

-- Selección de datos y creación de tabla temporal
SELECT 
    Ddo.IDMAEEDO,
    Ddo.ENDO,
    Ddo.SUENDO,
    MAEEN.NOKOEN,
    ISNULL(Ddo.ENDOFI,'') AS ENDOFI,
    ISNULL((SELECT TOP 1 NOKOEN FROM MAEEN WHERE KOEN = Ddo.ENDOFI),'') AS NOMENDOFI,
    Ddo.TIDO,
    Ddo.NUDO,
    Ddo.SULIDO,
    Ddo.BOSULIDO,
    Ddo.FEEMLI,
	@CodigoMadre AS 'CodigoMadre',
    Ddo.KOPRCT,
    Ddo.NOKOPR,
    CASE Ddo.UDTRPR WHEN 1 THEN Ddo.UD01PR ELSE Ddo.UD02PR END AS UN,
    CASE Ddo.UDTRPR WHEN 1 THEN Ddo.CAPRCO1 ELSE Ddo.CAPRCO2 END AS CANTIDAD,
    Ddo.VANELI,
    Cast(0 As Float) As 'TotalNeto',
    MAEEDO.MODO,
    Ddo.KOLTPR,
    CASE Ddo.UDTRPR WHEN 1 THEN Ddo.PPPRNERE1 ELSE Ddo.PPPRNERE2 END AS 'PrecioVenta',
    Lp.PP01UD As 'PrecioLista',
    Cast(0 As Float) As 'Precio',
    Lpbk.Flete,
    Ddo.UDTRPR,
    Cast(0 As Bit) As 'Marca',
    ISNULL((SELECT TOP 1 E.NOKOEN FROM MAEEN AS E WHERE E.KOEN=MAEEDO.ENDOFI),'') AS NOKOFI  
INTO #Detalle
FROM MAEDDO Ddo WITH (NOLOCK)  
    INNER JOIN MAEEDO ON MAEEDO.IDMAEEDO = Ddo.IDMAEEDO  
    LEFT JOIN MAEEN ON Ddo.ENDO = MAEEN.KOEN AND Ddo.SUENDO = MAEEN.SUEN  
    INNER JOIN BAKAPP_SG.dbo.Zw_Prod_Asociacion Asoc ON Ddo.KOPRCT = Asoc.Codigo
    INNER JOIN BAKAPP_SG.dbo.Zw_TblArbol_Asociaciones Arb ON Asoc.Codigo_Nodo = Arb.Codigo_Nodo
    LEFT JOIN TABPRE Lp ON Lp.KOLT = @Lista AND Lp.KOPR = Ddo.KOPRCT 
    LEFT JOIN BAKAPP_SG.dbo.Zw_ListaPreGlobal Lpbk ON Lpbk.Lista = SUBSTRING(Ddo.KOLTPR, 6, 3)
WHERE Ddo.LILG IN ('SI', 'GR')  
    AND Ddo.TIDO = 'FCV' 
    AND KOPRCT IN (SELECT Codigo FROM BAKAPP_SG.dbo.Zw_Prod_Asociacion WHERE Codigo_Nodo IN 
        (SELECT Prod.Codigo_Nodo 
         FROM BAKAPP_SG.dbo.Zw_Prod_Asociacion Prod
         INNER JOIN BAKAPP_SG.dbo.Zw_TblArbol_Asociaciones Asoc ON Prod.Codigo_Nodo = Asoc.Codigo_Nodo AND Asoc.Es_Seleccionable = 1
         WHERE Asoc.Codigo_Madre = @CodigoMadre))
    AND FEEMLI BETWEEN @FechaDesde AND @FechaHasta
    AND Arb.Codigo_Madre = @CodigoMadre

-- Actualización de precios
UPDATE #Detalle SET Precio = PrecioVenta - Flete
UPDATE #Detalle SET Precio = PrecioLista 
WHERE LTRIM(RTRIM(ENDO))+RTRIM(LTRIM(SUENDO))
 IN (Select Distinct LTRIM(RTRIM(Codigo))+LTRIM(RTRIM(Sucursal)) From BAKAPP_SG.dbo.Zw_TblInf_EntExcluidas
Where Excluida in ('V','A','T'))

-- Cálculo del total neto
UPDATE #Detalle SET TotalNeto = Precio * CANTIDAD

-- Cursor para marcar las filas según la lógica especificada
DECLARE @IDMAEEDO_Cursor INT
DECLARE @Cantidad_Cursor DECIMAL(10,2)
DECLARE @Precio_Cursor DECIMAL(10,2)

DECLARE cursor_marca CURSOR FOR
SELECT IDMAEEDO, CANTIDAD, Precio
FROM #Detalle
ORDER BY Precio DESC

OPEN cursor_marca
FETCH NEXT FROM cursor_marca INTO @IDMAEEDO_Cursor, @Cantidad_Cursor, @Precio_Cursor

WHILE @@FETCH_STATUS = 0
BEGIN
    IF @suma_acumulada + @Cantidad_Cursor <= @CantidadMax
    BEGIN
        UPDATE #Detalle
        SET Marca = 1
        WHERE IDMAEEDO = @IDMAEEDO_Cursor

        SET @suma_acumulada = @suma_acumulada + @Cantidad_Cursor
    END
    ELSE
    BEGIN
        BREAK
    END

    FETCH NEXT FROM cursor_marca INTO @IDMAEEDO_Cursor, @Cantidad_Cursor, @Precio_Cursor
END

CLOSE cursor_marca
DEALLOCATE cursor_marca


-- Resumen de resultados
SELECT 
    @CodigoMadre AS 'CodigoMadre',
    @Descripcion AS 'Descripcion',
	@CantidadMax As 'CantidadMax',
    @CantidadNoQuiebra As 'CantidadNoQuiebra',
    SUM(CANTIDAD) AS 'Cantidad', -- Cantidad a la que se llego a tope para el estudio
    SUM(TotalNeto) AS 'TotalNeto',
    ROUND(SUM(TotalNeto) / SUM(CANTIDAD), 0) AS 'Ppv',
    (SELECT MIN(Precio) FROM #Detalle) AS 'Minprecio',
    (SELECT MAX(Precio) FROM #Detalle) AS 'Maxprecio',
	CAST(0 As Bit) As 'RevisarPrecio'
Into #Resultado
FROM #Detalle
INNER JOIN MAEPR Mp ON Mp.KOPR = #Detalle.KOPRCT
LEFT JOIN TABPRE Tp ON Mp.KOPR = Tp.KOPR AND Tp.KOLT = @Lista
Where Marca = 1

Select Distinct @CodigoMadre As 'CodigoMadre',@Lista As 'Lista',FEVI As 'FechaGrab',KOPRCT As 'Codigo',MAEPR.NOKOPR As 'Descripcion',PP01UD As 'PrecioLista'
Into #Precios
From #Detalle 
Inner Join MAEPR On KOPR = KOPRCT
Left Join TABPRE Pre On Pre.KOLT = @Lista And KOPRCT = Pre.KOPR
Where Marca = 1

-- Actualización del campo RevisarPrecio en la tabla #Resultado
UPDATE #Resultado
SET RevisarPrecio = CASE 
                        WHEN (SELECT COUNT(*) FROM #Precios) > 1 THEN 1 
                        ELSE 0 
                    END

Select * From #Resultado
Select * From #Precios
Select * From #Detalle Where Marca = 1 ORDER BY Precio DESC

-- Eliminación de la tabla temporal
DROP TABLE #Detalle
DROP TABLE #Resultado
DROP TABLE #Precios

