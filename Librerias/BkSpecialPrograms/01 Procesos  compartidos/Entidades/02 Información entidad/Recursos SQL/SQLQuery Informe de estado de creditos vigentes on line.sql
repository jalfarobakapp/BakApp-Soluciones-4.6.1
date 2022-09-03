-- CONSULTA SQL PARA INFORME SEA GARDEN 
-- INFORME INFORME DE ESTADO DE CRÉDITOS VIGENTES ON LINE
-- CARTERA

-- CARTERA
/*
SELECT     TOP (100) PERCENT dbo.MAEDPCE.TIDP AS TIPO_DOC, dbo.MAEDPCE.EMDP AS BANCO, dbo.MAEDPCE.ENDP AS CODIGO, dbo.MAEEN.NOKOEN AS CLIENTE, dbo.MAEDPCE.FEVEDP, 
                      dbo.MAEDPCE.VADP AS MONTO, dbo.MAEDPCE.CUDP AS CUENTA, dbo.MAEDPCE.NUCUDP AS N_DOC
FROM         dbo.MAEDPCE INNER JOIN
                      dbo.MAEEN ON dbo.MAEDPCE.ENDP = dbo.MAEEN.KOEN
WHERE     (dbo.MAEDPCE.TIDP = 'CHV') AND (dbo.MAEDPCE.FEVEDP > GETDATE())
ORDER BY CODIGO
*/
-- CARTERA DETALLE

SELECT   dbo.MAEEN.KOEN AS CODIGO, 
         dbo.MAEEN.NOKOEN AS CLIENTE, 
         dbo.MAEEN.CRCH AS EN_CHEQUES, 
         Isnull(SUM(dbo.MAEDPCE.VADP),0) AS CARTERA, 
         dbo.MAEEN.SUEN, 
         dbo.MAEEN.CRSD, 
         dbo.MAEEN.CRTO, 
         dbo.MAEEN.CPEN
         Into #Paso_Cartera_Det
FROM     dbo.MAEDPCE RIGHT OUTER JOIN
                      dbo.MAEEN ON dbo.MAEDPCE.ENDP = dbo.MAEEN.KOEN
WHERE dbo.MAEDPCE.TIDP In ('CHV') AND (dbo.MAEDPCE.FEVEDP > GETDATE() Or dbo.MAEDPCE.ESPGDP In ('P','R') ) 

GROUP BY dbo.MAEEN.KOEN, dbo.MAEEN.NOKOEN, dbo.MAEEN.CRCH, dbo.MAEEN.SUEN, dbo.MAEEN.CRSD, dbo.MAEEN.CRTO, dbo.MAEEN.CPEN
ORDER BY CARTERA DESC


SELECT Mae.KOEN, Mae.SUEN, Mae.NOKOEN, Mae.CPEN AS CONDICION, Mae.CRSD AS SIN_DOC, 
       SUM(CASE 
			   WHEN Edo.TIDO = 'NCV' THEN (Edo.VABRDO - Edo.VAABDO) * - 1 
			   ELSE (Edo.VABRDO - Edo.VAABDO) * 1 
		   END) AS DEUDA_VIGENTE, 
           CASE 
			   WHEN SUM(CASE 
					        WHEN Edo.TIDO = 'NCV' THEN (Edo.VABRDO - Edo.VAABDO) * - 1 
					        ELSE (Edo.VABRDO - Edo.VAABDO) * 1 
					    END) >= Mae.CRSD THEN 
											  SUM(CASE 
											          WHEN Edo.TIDO = 'NCV' THEN (Edo.VABRDO - Edo.VAABDO) * - 1 
											          ELSE (Edo.VABRDO - Edo.VAABDO) * 1 
											      END) - Mae.CRSD 
			   ELSE 0 END AS VAR_SD, 
			CASE 
			    WHEN SUM(CASE 
			                 WHEN Edo.TIDO = 'NCV' THEN (Edo.VABRDO - Edo.VAABDO) * - 1 
			                 ELSE (Edo.VABRDO - Edo.VAABDO) * 1 
			              END) < Mae.CRSD THEN Mae.CRSD - SUM(CASE 
			                                                      WHEN Edo.TIDO = 'NCV' THEN (Edo.VABRDO - Edo.VAABDO) * - 1 
			                                                      ELSE (Edo.VABRDO - Edo.VAABDO) * 1 
			                                                   END) 
			    ELSE 0 END AS DISP_SD, 
	     Mae.CRCH AS CR_CHEQUES, 
	     Isnull(Ct.CARTERA,0) As CARTERA,
	     CASE WHEN (Isnull(Ct.CARTERA,0) >= Mae.CRCH) THEN Isnull(Ct.CARTERA,0) - Mae.CRCH 
	          ELSE 0 
	     END AS VAR_CH, 
         CASE WHEN (Isnull(Ct.CARTERA,0) < Mae.CRCH) 
                      THEN Mae.CRCH - Isnull(Ct.CARTERA,0) 
                      ELSE 0 END AS DISP_CH, Mae.CRTO AS CR_TOTAL, 
         SUM(CASE 
                  WHEN Edo.TIDO = 'NCV' THEN (Edo.VABRDO - Edo.VAABDO) * - 1 
                  ELSE (Edo.VABRDO - Edo.VAABDO) * 1 END) 
                      + Isnull(Ct.CARTERA,0) AS TOT_DEUDA, 
         (CASE 
               WHEN (SUM(CASE 
                             WHEN Edo.TIDO = 'NCV' THEN (Edo.VABRDO - Edo.VAABDO) * - 1 
                             ELSE (Edo.VABRDO - Edo.VAABDO) * 1 
                          END) + Isnull(Ct.CARTERA,0)) < Mae.CRTO THEN (SUM(CASE 
                                                                      WHEN Edo.TIDO = 'NCV' THEN (Edo.VABRDO - Edo.VAABDO) * - 1 
                                                                      ELSE (Edo.VABRDO - Edo.VAABDO) * 1 
                                                                  END) + Isnull(Ct.CARTERA,0)) - (Mae.CRTO) 
                ELSE 0 
             END) * - 1 AS DISPONIBLE
         Into #Paso_Inf_Creditos
FROM         dbo.MAEEDO Edo FULL OUTER JOIN
             dbo.#Paso_Cartera_Det Ct ON Edo.ENDO = Ct.CODIGO And Edo.SUENDO = Ct.SUEN FULL OUTER JOIN
             dbo.MAEEN Mae ON Edo.SUENDO = Mae.SUEN AND Edo.ENDO = Mae.KOEN
WHERE     Edo.TIDO In ('BLV','BLX','BSV','ESC','FCV','FDB','FDV','FDX','FDZ','FEE','FEV',
	                   'FVL','FVT','FVX','FVZ','NCE','NCV','NCX','NCZ','NEV','RIN') --And Mae.KOEN = '05058413' 
Group By Ct.CARTERA,Mae.KOEN,Mae.SUEN,Mae.NOKOEN,Mae.CRSD, Mae.CRCH, Mae.CRTO, Mae.CPEN
ORDER BY Mae.KOEN

Select * From #Paso_Inf_Creditos

Drop Table #Paso_Cartera_Det
Drop Table #Paso_Inf_Creditos

