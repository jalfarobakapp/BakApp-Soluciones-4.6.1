
BEGIN TRY
 DROP TABLE #INFVEN
 END TRY
 BEGIN CATCH
END CATCH

BEGIN TRY
 DROP TABLE #INFVENR
 END TRY
 BEGIN CATCH
END CATCH

Declare @Fecha_Inicio Datetime,
        @Fecha_Fin Datetime,
        @Empresa Char(2)

Select @Fecha_Inicio = '#Fecha_Inicio#',
        @Fecha_Fin = '#Fecha_Fin#',
        @Empresa = '#Empresa#'

SELECT CAST( 0 AS Bit) AS Chk, 
       EDO.IDMAEEDO,VEN.IDMAEVEN, EDO.ENDO,EDO.SUENDO,
       Isnull((Select top 1 RTEN From MAEEN Where KOEN = EDO.ENDO And SUEN = EDO.SUENDO),'') As RTEN,
       CAST('' AS Varchar(15)) AS RUT,
       Isnull((Select top 1 NOKOEN From MAEEN Where KOEN = EDO.ENDO And SUEN = EDO.SUENDO),'') As NOKOEN,
       EDO.TIDO,
       Isnull((Select Top 1 NOTIDO From TABTIDO Where TIDO = EDO.TIDO),'') As Tipo,
       EDO.NUDO,
       EDO.FEEMDO,VEN.FEVE,DATEDIFF(DD,FEEMDO,FEVE) AS DIAS,DATEDIFF(DD,GETDATE(),FEVE) AS DIAS_ATRASO,
	(CASE  
		WHEN EDO.TIMODO='E' THEN VEN.VAVE*EDO.TAMODO*( 
			CASE 
				WHEN EDO.TIDO IN ('NCV','NCX','NEV') OR EDO.TIDO='NCC' THEN -1 
				ELSE 1 
			END) 
		ELSE VEN.VAVE*( 
			CASE 
				WHEN EDO.TIDO IN ('NCV','NCX','NEV') OR EDO.TIDO='NCC' THEN -1 
				ELSE 1 
			END) 
	END) AS VAVE ,

	(CASE  
		WHEN EDO.TIMODO='E' THEN VEN.VAABVE*EDO.TAMODO*( 
			CASE 
				WHEN EDO.TIDO IN ('NCV','NCX','NEV') OR EDO.TIDO='NCC' THEN -1 
				ELSE 1 
			END ) 
		ELSE VEN.VAABVE*( 
			CASE 
				WHEN EDO.TIDO IN ('NCV','NCX','NEV') OR EDO.TIDO='NCC' THEN -1 
				ELSE 1 
			END ) 
	END) AS VAABVE,
    VAABDO,
	CAST( 0 AS Float) AS SALDO,
    VABRDO-VAABDO AS SALDO_Total,
	Cast(0 As Float) As Valor_Abonado_Maeven,
    VEN.ESPGVE,
    CAST( 0 AS Bit) AS SOSPECHA_STOCK,
    CAST( 0 AS Bit) AS SOSPECHA_DEVOLUCION,
    CAST( 0 AS Bit) AS REVISADO_PAGAR,
    CAST( 0 AS Bit) AS AUTORIZADO_PAGAR,
    EDO.FEULVEDO,
    'Documentos' as Deuda,
    CAST('MAEEDO' As Varchar(10)) As ARCHIRVE,
    EDO.IDMAEEDO AS IDRVE,
    CAST(
         Isnull((Select Top 1 CONVERT(VARCHAR, FEVENTO, 103)+' -> '+KOTABLA+' -> '+KOCARAC+' -> '+NOKOCARAC  
		 From MEVENTO 
		 Where KOTABLA = 'COBRANZA' And ARCHIRVE = 'MAEEDO' And IDRVE = EDO.IDMAEEDO Order by IDEVENTO Desc),'') 
         As Varchar(1000)) As 'ULT_EVENTO',   
    Cast(0 As Bit) As 'Revisar_Documento'
    			 
 INTO #INFVEN 		 
 
 FROM MAEVEN AS VEN WITH ( NOLOCK )  
	INNER JOIN MAEEDO AS EDO ON EDO.IDMAEEDO=VEN.IDMAEEDO  
	LEFT JOIN MAEEN WITH (NOLOCK) ON MAEEN.KOEN=EDO.ENDO AND MAEEN.SUEN=EDO.SUENDO  
	LEFT JOIN TABSU ON TABSU.KOSU=EDO.SUDO  
	LEFT JOIN TABFU ON TABFU.KOFU=EDO.KOFUDO  
	LEFT JOIN TABLUG ON TABLUG.LUVT=EDO.LUVTDO  
 
 WHERE 
    EDO.NUDONODEFI = 0 AND
	EDO.TIDO IN ('BLV','BLX','BSV','ESC','FCV','FDB','FDV','FDX','FDZ','FEE','FEV',
	             'FVL','FVT','FVX','FVZ','NCE','NCV','NCX','NCZ','NEV','RIN')  AND 
	EDO.EMPRESA = @Empresa AND 
	VEN.FEVE  BETWEEN @Fecha_Inicio AND @Fecha_Fin
	--#Filtro_Adicional_Maeedo#
	--#Entidades_Excluidas#
	--#Filtro_Adicional#
	AND VEN.ESPGVE <> 'C' 
ORDER BY EDO.FEEMDO	

Update #INFVEN Set DIAS_ATRASO = 0 Where TIDO In ('NCE','NCV','NCX','NCZ','NEV','NCC')

-- INSERTA DOCUMENTOS DE PAGO PENDIENTES DE LA ENTIDAD

INSERT INTO #INFVEN(IDMAEEDO,              -- 1
                    IDMAEVEN,              -- 2
					ENDO,                  -- 3
					SUENDO,                -- 4
					RTEN,                  -- 5
					RUT,                   -- 6
					NOKOEN,                -- 7
					TIDO,                  -- 8
					Tipo,                  -- 9
                    NUDO,                  -- 10
					FEEMDO,                -- 11
					FEVE,                  -- 12
					DIAS,                  -- 13
					DIAS_ATRASO,           -- 14
					VAVE,                  -- 15
					VAABVE,                -- 16
                    SALDO,                 -- 17
					ESPGVE,                -- 18
					SOSPECHA_STOCK,        -- 19
					SOSPECHA_DEVOLUCION,   -- 20
					REVISADO_PAGAR,        -- 21
					AUTORIZADO_PAGAR,      -- 22
					FEULVEDO,              -- 23
					Deuda,                 -- 24
					ARCHIRVE,              -- 25 
					IDRVE,                 -- 26
					ULT_EVENTO)            -- 27 
                    
SELECT DPCE.IDMAEDPCE AS IDMAEEDO,                                                   -- 1
       0 AS IDMAEVEN,                                                                -- 2
	   DPCE.ENDP AS ENDO,                                                            -- 3
	   '' AS SUENDO,                                                                 -- 4
       ISNULL((SELECT TOP 1 RTEN FROM MAEEN WHERE KOEN = DPCE.ENDP),'') AS RTEN,     -- 5
       CAST('' AS Varchar(15)) AS RUT,                                               -- 6
       ISNULL((SELECT TOP 1 NOKOEN FROM MAEEN WHERE KOEN = DPCE.ENDP),'') AS NOKOEN, -- 7
	   DPCE.TIDP AS TIDO,                                                            -- 8
       (Select Top 1 NOKOENDP From TABENDP Where KOENDP = DPCE.EMDP) AS 'Tipo',      -- 9
       Isnull(DPCE.NUCUDP,'') AS NUDO,                                               -- 10
       DPCE.FEEMDP AS FEEMDO,                                                        -- 11
	   DPCE.FEVEDP AS FEVE,                                                          -- 12
       DATEDIFF(DD,DPCE.FEEMDP,DPCE.FEVEDP) AS DIAS,                                 -- 13
	   DATEDIFF(DD,GETDATE(),DPCE.FEVEDP) AS DIAS_ATRASO,                            -- 14
       DPCE.VADP AS VAVE,                                                            -- 15
	   DPCE.VAABDP AS VAABVE,                                                        -- 16
	   (DPCE.VADP - DPCE.VAABDP) AS SALDO,                                           -- 17
       '' AS ESPGVE,                                                                 -- 18
       CAST( 0 AS Bit) AS SOSPECHA_STOCK,                                            -- 19
       CAST( 0 AS Bit) AS SOSPECHA_DEVOLUCION,                                       -- 20
       CAST( 0 AS Bit) AS REVISADO_PAGAR,                                            -- 21
       CAST( 0 AS Bit) AS AUTORIZAR_PAGAR,                                           -- 22
       DPCE.FEVEDP AS FEULVEDO,                                                      -- 23
       'Pagos' as Deuda,                                                             -- 24
       'MAEDPCE',                                                                    -- 25
	   DPCE.IDMAEDPCE,                                                               -- 26
       Isnull((Select Top 1 CONVERT(VARCHAR, FEVENTO, 103)+' -> '+KOTABLA+' -> '+KOCARAC+' -> '+NOKOCARAC  
	    	   From MEVENTO 
		       Where KOTABLA = 'COBRANZA' And ARCHIRVE = 'MAEDPCE' And IDRVE = DPCE.IDMAEDPCE Order by IDEVENTO Desc),'') -- 27
   	    
FROM MAEDPCE AS DPCE  WITH ( NOLOCK )  
WHERE 
	--DPCE.ENDP In (Select Distinct ENDO From #INFVEN)  AND 
	--DPCE.TIDP IN  ('ATB','CHV','CPV','CRV','DEP','EFV','LTV','PAV','RBV','RGV','RIV','TJV','VUE')  AND 
    DPCE.TIDP IN  ('ATB','CHV','CPV','CRV','DEP','LTV','PAV','RBV','RGV','RIV','VUE')  AND 	
	( DPCE.ESPGDP = 'P' OR DPCE.ESPGDP = 'R' )  AND 
	DPCE.EMPRESA = @Empresa And 
	DPCE.FEVEDP  BETWEEN @Fecha_Inicio AND @Fecha_Fin 
	--#Filtro_Adicional_Maedpce#
    --#Filtro_Adicional# 
    --_Entidades_Excluidas#
-----------------------------------------------------------------------------------------------------------	 


--UPDATE #INFVEN SET SALDO = COALESCE(VAVE-VAABVE ,0.0) 

Update #INFVEN Set Valor_Abonado_Maeven = (Select Sum(VAABVE) From MAEVEN Where #INFVEN.IDMAEEDO = MAEVEN.IDMAEEDO)
UPDATE #INFVEN SET SALDO = COALESCE(VAVE-VAABVE ,0.0) 
Update #INFVEN Set Revisar_Documento = 1 Where VAABDO <> Valor_Abonado_Maeven
 

