DECLARE 
@Codigo      char(13),
@Empresa     Char( 2),
@FECHAINICIO as date,
@FECHATERMINO as date

Set @Codigo = '#Codigo#'
Set @FECHAINICIO  = '#Fecha1#'
Set @FECHATERMINO = '#Fecha2#'
Set @Empresa = '#Empresa#'
-- SELECCION DE VENTAS DE UN PERIODO

SELECT SULIDO,
       (SELECT NOKOSU FROM TABSU WHERE EMPRESA = '01' AND KOSU = MD.SULIDO ) AS Sucursal,
       UD01PR,
       ROUND(SUM(CASE TIDO 
					            WHEN 'NCE' THEN - 1 * CAPRCO1 
								WHEN 'NCV' THEN - 1 * CAPRCO1 
								WHEN 'NCX' THEN - 1 * CAPRCO1 
								WHEN 'NCZ' THEN - 1 * CAPRCO1 
								WHEN 'NEV' THEN - 1 * CAPRCO1 
								ELSE CAPRCO1 END), 0) as 'CANTIDADUd1',
	   UD02PR,
	   ROUND(SUM(CASE TIDO 
					            WHEN 'NCE' THEN - 1 * CAPRCO2 
								WHEN 'NCV' THEN - 1 * CAPRCO2 
								WHEN 'NCX' THEN - 1 * CAPRCO2 
								WHEN 'NCZ' THEN - 1 * CAPRCO2 
								WHEN 'NEV' THEN - 1 * CAPRCO2 
								ELSE CAPRCO2 END), 0) as 'CANTIDADUd2',							
	   ROUND(SUM(CASE TIDO 
					            WHEN 'NCE' THEN - 1 * PPPRBR 
								WHEN 'NCV' THEN - 1 * PPPRBR 
								WHEN 'NCX' THEN - 1 * PPPRBR 
								WHEN 'NCZ' THEN - 1 * PPPRBR 
								WHEN 'NEV' THEN - 1 * PPPRBR 
								ELSE PPPRBR END), 0) as 'TOTAL'						
	   --ROUND(SUM(PPPRBR), 0) AS 'TOTAL'
FROM         MAEDDO AS MD
WHERE     (MD.TIDO IN ('FCV', 'FDB', 'FDV', 'FDX', 'FDZ', 'FEV', 'FVL', 'FVT', 'FVX', 
                               'FVZ', 'FEE', 'BLV', 'NCE', 'NCV', 'NCX', 'NCZ', 'NEV') AND 
                      (MD.FEEMLI BETWEEN @FECHAINICIO AND @FECHATERMINO) AND 
                      (MD.EMPRESA = @Empresa) AND 
                      (MD.SULIDO IN (#Sucursal#)) AND --IN (select KOSU FROM TABSU)) AND
                      (MD.KOPRCT = @Codigo))
GROUP BY SULIDO,UD01PR,UD02PR