
DECLARE 

@Fecha_Inicio Date = '#Fecha_Inicio#', 
@Fecha_Fin    Date = '#Fecha_Fin#'
 
BEGIN TRY
 DROP TABLE #INFVEN
 END TRY
 BEGIN CATCH
END CATCH


 
SELECT EDO.IDMAEEDO, EDO.TIDO, EDO.NUDO, 
       EDO.ENDO, EDO.SUENDO, 
       (SELECT TOP 1 NOKOEN FROM MAEEN WHERE KOEN = ENDO AND SUEN = SUENDO) AS RAZON,
       EDO.SUDO,
       EDO.FEEMDO, EDO.FEULVEDO, EDO.KOFUDO, 
       (SELECT TOP 1 KOFULIDO FROM MAEDDO Ddo WHERE Ddo.IDMAEEDO = EDO.IDMAEEDO) As COD_VENDEDOR,
       (SELECT TOP 1 NOKOFU 
       FROM TABFU 
       WHERE KOFU = (SELECT TOP 1 KOFULIDO FROM MAEDDO Ddo WHERE Ddo.IDMAEEDO = EDO.IDMAEEDO)) AS VENDEDOR,
       EDO.MODO, EDO.TIMODO, 
	   EDO.TAMODO,EDO.CAPRAD, EDO.CAPREX,
	   EDO.VANEDO, EDO.VAIVDO, EDO.VABRDO,
		COALESCE(TABZO.NOKOZO,'') AS NOKOZO,
		COALESCE(TABRU.NOKORU,'') AS NOKORU,
		COALESCE(TABSU.NOKOSU,'') AS NOSUDO,
		COALESCE(TABFU.NOKOFU,'') AS NOKOFU,
		COALESCE(MAEEN.NOKOEN,'') AS NOKOEN,
		COALESCE(MAEEN.ZOEN,  '') AS ZOEN,
		COALESCE(MAEEN.RUEN,'') AS RUEN,
		CASE  
			WHEN EDO.TIMODO='E' THEN 
					EDO.VANEDO*EDO.TAMODO* ( 
						CASE 
							WHEN EDO.TIDO IN ('NCV','NCX','NEV') OR EDO.TIDO='NCC' THEN -1 
							ELSE 1 
							END )  
			ELSE EDO.VANEDO* ( 
						CASE 
							WHEN EDO.TIDO IN ('NCV','NCX','NEV') OR EDO.TIDO='NCC' THEN -1 
							ELSE 1 
							END )  
		END AS NETO
INTO #INFVEN
FROM MAEEDO EDO WITH ( NOLOCK ) 
		    LEFT JOIN MAEEN WITH ( NOLOCK ) ON 
				MAEEN.KOEN=EDO.ENDO AND MAEEN.SUEN=EDO.SUENDO  
			LEFT JOIN TABZO WITH ( NOLOCK ) ON 
				TABZO.KOZO=MAEEN.ZOEN  
			LEFT JOIN TABRU WITH ( NOLOCK ) ON 
				TABRU.KORU=MAEEN.RUEN  
			LEFT JOIN TABSU WITH ( NOLOCK ) ON 
				TABSU.KOSU=EDO.SUDO  
			LEFT JOIN TABFU WITH ( NOLOCK ) ON 
				TABFU.KOFU=EDO.KOFUDO 
WHERE 

(EDO.TIDO IN ('BLV','BLX','BSV','ESC','FCV',
              'FDB','FDV','FDX','FDZ','FEE',
              'FEV','FVL','FVT','FVX','FVZ',
              'FXV','FYV','NCE',
			  'NCV','NCX','NCZ','NEV','RIN') AND 
EDO.FEEMDO BETWEEN @Fecha_Inicio AND @Fecha_Fin AND 
EDO.EMPRESA='01' AND 
#Nudonodefi#
EDO.ESDO<>'N' ) 
#Filtro_Externo#

-- INFORME VENTAS

Update #INFVEN Set VANEDO = VANEDO * -1,
                   VAIVDO = VAIVDO * -1,  
                   VABRDO = VABRDO * -1
Where TIDO In ('NCV','NCX','NEV','NCZ')                   

-- INFORME POR DOCUMENTOS                    
Select IDMAEEDO,TIDO,NUDO,ENDO,SUENDO,RAZON,FEEMDO,COD_VENDEDOR,VENDEDOR,VANEDO,VAIVDO,VABRDO From #INFVEN
Order by FEEMDO

-- INFORME POR CLIENTES
Select ENDO,SUENDO,RAZON,COD_VENDEDOR,VENDEDOR,SUM(VANEDO) AS VANEDO,SUM(VAIVDO) AS VAIVDO,SUM(VABRDO) AS VABRDO From #INFVEN
Group By ENDO,SUENDO,RAZON,COD_VENDEDOR,VENDEDOR
Order by RAZON

-- INFORME POR VENDEDOR
Select COD_VENDEDOR,VENDEDOR,SUM(VANEDO) AS VANEDO,SUM(VABRDO) AS VABRDO From #INFVEN
Group By COD_VENDEDOR,VENDEDOR
Order by VENDEDOR

-- INFORME SUMA TOTALES
Select SUM(VANEDO) AS VANEDO,SUM(VABRDO) AS VABRDO From #INFVEN

DROP  TABLE #INFVEN 