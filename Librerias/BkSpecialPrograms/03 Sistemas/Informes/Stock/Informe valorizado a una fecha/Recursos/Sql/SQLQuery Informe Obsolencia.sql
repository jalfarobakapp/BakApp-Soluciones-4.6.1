
-- FILTRO OBSOLENCIA

SELECT KOSU,COD_OBSOLENCIA,OBSOLENCIA,
       SUM(STFI)AS STFI,
       CAST(0 AS FLOAT) AS PORC_STFI,
       SUM(VALSTOCK) AS VALSTOCK,
       CAST(0 AS FLOAT) AS PORC_VALSTOCK
INTO #STOCKVAL_FM 
FROM #Tabla_Paso#
WHERE 1 > 0
#FILTRO#
GROUP BY KOSU,COD_OBSOLENCIA,OBSOLENCIA

UPDATE #STOCKVAL_FM SET PORC_STFI = STFI/(SELECT SUM(STFI) FROM #STOCKVAL_FM)
WHERE STFI > 0

UPDATE #STOCKVAL_FM SET PORC_VALSTOCK = VALSTOCK/(SELECT SUM(VALSTOCK) FROM #STOCKVAL_FM)
WHERE VALSTOCK > 0

INSERT INTO #STOCKVAL_FM (KOSU,COD_OBSOLENCIA,OBSOLENCIA,STFI,PORC_STFI,VALSTOCK,PORC_VALSTOCK)
SELECT 'ZZZ','ZZZ','TOTALES',SUM(STFI),SUM(PORC_STFI),SUM(VALSTOCK),SUM(PORC_VALSTOCK)
FROM #STOCKVAL_FM

-- Select Informes X Obsolencia X Sucursal

SELECT KOSU,COD_OBSOLENCIA,OBSOLENCIA,
       SUM(STFI) AS STFI,
       ROUND(SUM(PORC_STFI),3) AS PORC_STFI,
       SUM(VALSTOCK) AS VALSTOCK,
       ROUND(SUM(PORC_VALSTOCK),3) AS PORC_VALSTOCK 
	   FROM #STOCKVAL_FM
WHERE 1 > 0 
GROUP BY KOSU,COD_OBSOLENCIA,OBSOLENCIA
ORDER BY COD_OBSOLENCIA

-- Select Informes X Obsolencia 

SELECT COD_OBSOLENCIA,OBSOLENCIA,
       SUM(STFI) AS STFI,
       ROUND(SUM(PORC_STFI),3) AS PORC_STFI,
       SUM(VALSTOCK) AS VALSTOCK,
       ROUND(SUM(PORC_VALSTOCK),3) AS PORC_VALSTOCK 
	   FROM #STOCKVAL_FM
WHERE 1 > 0 
GROUP BY COD_OBSOLENCIA,OBSOLENCIA
ORDER BY COD_OBSOLENCIA



DROP TABLE #STOCKVAL_FM
