
SELECT KOFULIDO,
       'VALORNETO'=SUM(VALORNETO),
       'VABRDO'=SUM(VABRDO*0),
       'VAIVDO'=SUM(VAIVDO*0),
       'VANEDO'=SUM(VANEDO*0),
       'VAABDO'=SUM(VAABDO*0),
       'VASADO'=SUM(VASADO*0)  
       INTO #VENVEN_6 
       FROM #VENVEN WITH ( NOLOCK )  GROUP BY KOFULIDO 
SELECT DISTINCT #VENVEN.KOFULIDO,#VENVEN.TIDO,#VENVEN.NUDO,#VENVEN.ENDO,#VENVEN.SUENDO, 
                #VENVEN.VANEDO,#VENVEN.VAIVDO,#VENVEN.VABRDO,#VENVEN.VAABDO,#VENVEN.VASADO 
       INTO #VENVEN_AUX 
       FROM #VENVEN WITH ( NOLOCK ) 
UPDATE #VENVEN_6 SET 
       VANEDO=(SELECT SUM(AUX.VANEDO) FROM #VENVEN_AUX AUX WITH ( NOLOCK ) 
                WHERE AUX.KOFULIDO=#VENVEN_6.KOFULIDO ),
       VABRDO=(SELECT SUM(AUX.VABRDO) FROM #VENVEN_AUX AUX WITH ( NOLOCK ) 
                WHERE AUX.KOFULIDO=#VENVEN_6.KOFULIDO ),
       VAIVDO=(SELECT SUM(AUX.VAIVDO) FROM #VENVEN_AUX AUX WITH ( NOLOCK ) 
                WHERE AUX.KOFULIDO=#VENVEN_6.KOFULIDO ),
       VAABDO=(SELECT SUM(AUX.VAABDO) FROM #VENVEN_AUX AUX WITH ( NOLOCK ) 
                WHERE AUX.KOFULIDO=#VENVEN_6.KOFULIDO ),
       VASADO=(SELECT SUM(AUX.VASADO) FROM #VENVEN_AUX AUX WITH ( NOLOCK ) 
                WHERE AUX.KOFULIDO=#VENVEN_6.KOFULIDO ) 

CREATE INDEX VENVEN_6123851 ON #VENVEN_6 (KOFULIDO)

SELECT  #VENVEN_6.KOFULIDO,
        TABFU.NOKOFU,
        #VENVEN_6.VALORNETO,
        #VENVEN_6.VANEDO,
        #VENVEN_6.VAIVDO,
        #VENVEN_6.VAABDO,
        #VENVEN_6.VASADO
FROM #VENVEN_6  LEFT JOIN TABFU ON TABFU.KOFU=#VENVEN_6.KOFULIDO  
ORDER BY #VENVEN_6.VANEDO DESC  OPTION ( FAST 20 ) 

DROP TABLE #VENVEN 
DROP TABLE #VENVEN_6 
DROP TABLE #VENVEN_AUX 