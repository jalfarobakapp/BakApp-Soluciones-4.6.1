
-- PROXIMAS RECEPCIONES FACTURAS DE COMPRA
-- MERCADERIA PENDIENTE DE DESPACHO.

Declare
@Empresa Char(2)
--@Fecha_Emision_Desde Date = '#Fecha_Emision_Desde#',
--@Fecha_Emision_Hasta Date = '#Fecha_Emision_Hasta#'

Select @Empresa = '#Empresa#'

SELECT ED.IDMAEEDO,
       DD.IDMAEDDO,
       ED.EMPRESA,
	   ISNULL((SELECT TOP 1 RAZON FROM CONFIGP WHERE EMPRESA = @Empresa),'??') As EMPRESA_INFORME,	   
	   ED.TIDO,    
	   ED.NUDO,
	   EN.IDMAEEN,
	   ED.ENDO,
	   ED.SUENDO,
	   EN.NOKOEN,
	   ED.ENDOFI,
	   ISNULL(ED.SUENDOFI,'') AS SUENDOFI,
	   CAST('' AS VARCHAR(50)) AS NOENDOFI,
	   EN.ZOEN,
	   EN.DIEN,
	   EN.CIEN,
	   CIUDAD.NOKOCI AS CIUDAD,
	   EN.CMEN,
	   COMUNA.NOKOCM AS COMUNA, 
	   ED.SUDO,
	   ED.FEEMDO,
	   ED.FEER,
	   ED.MODO,
	   ED.TIMODO,
	   DD.TAMOPPPR,
	   DD.FEEMLI,  
	   DD.KOFULIDO,
	   CAST('' AS VARCHAR) AS 'FUNCIONARIO',
	   DD.LILG,
	   DD.PRCT,
	   DD.NULIDO,
	   DD.FEERLI,
	   DD.SULIDO,
	   CAST('' AS VARCHAR (50)) AS SUCURSAL,
	   DD.BOSULIDO,
	   CAST('' AS VARCHAR (50)) AS BODEGA,
	   DD.LUVTLIDO,
	   PR.TIPR,
	   DD.KOPRCT,
	   PR.KOPRRA,
	   PR.KOPRTE,
	   DD.NOKOPR,
	   DD.UD0#Ud#PR,
	   DD.NUSEPR,
	   DD.CAPRCO#Ud#,
	   DD.CAPRAD#Ud#,
	   DD.CAPREX#Ud#,
	   DD.CAPRCO#Ud# - (DD.CAPRAD#Ud#+DD.CAPREX#Ud#) As 'SALDO_Ud#Ud#',
	   --DD.UD02PR,
	   --DD.CAPRCO2,
	   --DD.CAPRAD2,
	   --DD.CAPREX2,
	   --DD.CAPRCO2 - (DD.CAPRAD2+DD.CAPREX2) As 'SALDO_Ud2',
	   DD.PPPRNE,
	   DD.PPPRNERE#Ud#,
	   DD.VANELI,
	   DD.PPPRPM AS PM_TRANS,
	   CAST(0 AS FLOAT) AS PM_ACTUAL,
	   CAST(0 AS FLOAT) As 'TOT_SALDOxPRECIO',
	   CAST(0 AS FLOAT) As 'TOT_SALDOxPRECIOREAL',
	   CAST(0 AS FLOAT) As 'TOT_SALDOxPM_TRANS',
	   CAST(0 AS FLOAT) As 'TOT_SALDOxPM_ACTUAL',
	   PR.FMPR,
	   CAST('' AS VARCHAR(50)) AS SUPER_FAMILIA,
	   PR.PFPR,
	   CAST('' AS VARCHAR(50)) AS FAMILIA,
	   PR.HFPR,
	   CAST('' AS VARCHAR(50)) AS SUB_FAMILIA,
	   PR.MRPR,
	   CAST('' AS VARCHAR(50)) AS MARCA,
	   PR.RUPR,
	   CAST('' AS VARCHAR(50)) AS RUBRO,
	   PR.CLALIBPR,
	   CAST('' AS VARCHAR(200)) AS CLAS_LIBRE,
	   PR.ZONAPR,
	   ISNULL(TZ.NOKOZO,'') AS ZONA,
	   PREM.STFI1,
	   PREM.STFI2,
	   CAST(0 AS FLOAT) AS 'STFI1_CONS',
	   CAST(0 AS FLOAT) AS 'STFI2_CONS',
	   PR.PRRG,
	   (SELECT BO.DATOSUBIC  FROM TABBOPR AS BO WITH ( NOLOCK )  
		WHERE BO.KOPR=DD.KOPRCT  AND BO.KOSU=DD.SULIDO  AND BO.KOBO=DD.BOSULIDO ) AS UBICACION,
	   DD.OBSERVA,
	   ISNULL(OB.OCDO,'') AS OCDO,
	   ISNULL(OB.OBDO,'') AS OBDO 
	INTO #INF001  
		FROM  MAEEDO AS ED WITH ( NOLOCK )  
			LEFT JOIN MAEDDO AS DD WITH ( NOLOCK ) ON 
				DD.IDMAEEDO=ED.IDMAEEDO  
					LEFT JOIN MAEEN EN WITH ( NOLOCK ) ON 
						ED.ENDO = EN.KOEN AND 
						ED.SUENDO = EN.SUEN  
							LEFT JOIN MAEEDOOB OB   WITH ( NOLOCK ) ON 
								OB.IDMAEEDO=ED.IDMAEEDO  
									LEFT JOIN MAEPR    PR   WITH ( NOLOCK ) ON 
										DD.KOPRCT = PR.KOPR  
											INNER JOIN MAEPREM PREM WITH ( NOLOCK ) ON 
											PR.KOPR = PREM.KOPR AND 
											PREM.EMPRESA=@Empresa  
												LEFT JOIN TABZO TZ      WITH ( NOLOCK ) ON 
												EN.ZOEN = TZ.KOZO  
													LEFT JOIN TABCI CIUDAD  WITH ( NOLOCK ) ON 
													CIUDAD.KOPA=EN.PAEN AND 
													CIUDAD.KOCI=EN.CIEN  
														LEFT JOIN TABCM COMUNA  WITH ( NOLOCK ) ON 
														COMUNA.KOPA=EN.PAEN AND 
														COMUNA.KOCI=EN.CIEN AND 
														COMUNA.KOCM=EN.CMEN  
	WHERE  
		ED.ESDO NOT IN ('N','C')  
		AND ED.EMPRESA = @Empresa  
		AND ED.NUDONODEFI = 0  
		AND DD.LILG IN ('SI','GR')  
		#Filtro_Detalle#         -- DD.CAPRCO1<>(DD.CAPRAD1+DD.CAPREX1) AND = Solo lineas pendientes
		#Filtro_Documentos#      --ED.TIDO='FCC'  AND 
		AND ED.FEEMDO BETWEEN '#Fecha_Emision_Desde#' AND '#Fecha_Emision_Hasta#' 
		#Filtro_Fecha_Recepcion# --AND DD.FEERLI BETWEEN {d '2017-05-31'} AND {d '2017-06-30'} 
		#Filtro_Productos#
        #Filtro_FunEntidad#
	
	ORDER BY  ED.ENDO, ED.FEEMDO, ED.NUDO, DD.NULIDO

DELETE FROM #INF001 
WHERE PRCT = 1 OR LILG NOT IN ('SI','CR')
	   
UPDATE #INF001 SET STFI1=B.STFI1,STFI2=B.STFI2  
FROM MAEST AS B WITH (NOLOCK)  
WHERE 
	B.EMPRESA = @Empresa  AND 
	B.KOSU = #INF001.SULIDO  AND 
	B.KOBO = #INF001.BOSULIDO  AND 
	B.KOPR = #INF001.KOPRCT 

UPDATE #INF001 SET 
			STFI1_CONS= ISNULL((SELECT SUM(STFI1) FROM MAEST Mt WHERE Mt.EMPRESA = @Empresa And KOPR = KOPRCT) ,0),
			STFI2_CONS= ISNULL((SELECT SUM(STFI2) FROM MAEST Mt WHERE Mt.EMPRESA = @Empresa And KOPR = KOPRCT) ,0)


UPDATE #INF001 SET PM_ACTUAL = ISNULL((SELECT TOP 1 PM FROM MAEPREM WHERE KOPR = KOPRCT AND EMPRESA = @Empresa),0)
UPDATE #INF001 SET NOENDOFI = ISNULL((SELECT TOP 1 NOKOEN FROM MAEEN WHERE KOEN = ENDOFI),'')

UPDATE #INF001 SET TOT_SALDOxPRECIO = SALDO_Ud#Ud# * PPPRNE,
                   TOT_SALDOxPRECIOREAL = SALDO_Ud#Ud# * PPPRNERE#Ud#,                   
                   TOT_SALDOxPM_TRANS = SALDO_Ud#Ud# * PM_TRANS,
                   TOT_SALDOxPM_ACTUAL =  SALDO_Ud#Ud# * PM_ACTUAL  
                   
                   
UPDATE #INF001 SET SUCURSAL = ISNULL((SELECT TOP 1 NOKOSU FROM TABSU Ts 
                                        WHERE Ts.EMPRESA = @Empresa And 
                                        Ts.KOSU = SULIDO),'')  
                                        
UPDATE #INF001 SET BODEGA = ISNULL((SELECT TOP 1 NOKOBO FROM TABBO Tb 
							  WHERE Tb.EMPRESA = @Empresa And 
									Tb.KOSU = SULIDO And 
									Tb.KOBO = BOSULIDO ),'')                     

UPDATE #INF001 SET FUNCIONARIO = ISNULL((SELECT TOP 1 NOKOFU FROM TABFU WHERE KOFU = KOFULIDO),'')
----------------------- CLASIFICACIONES DEL PRODUCTO ------------------------------------------------------------
									
UPDATE #INF001 SET SUPER_FAMILIA = ISNULL((SELECT TOP 1 NOKOFM FROM TABFM Tf 
                                             WHERE Tf.KOFM = #INF001.FMPR),'Sin Super Famila')
UPDATE #INF001 SET FAMILIA = ISNULL((SELECT TOP 1 NOKOPF FROM TABPF Pf 
                                             WHERE Pf.KOFM = #INF001.FMPR And
                                                   Pf.KOPF = #INF001.PFPR ),'Famila')
UPDATE #INF001 SET SUB_FAMILIA = ISNULL((SELECT TOP 1 NOKOHF FROM TABHF Hf 
                                             WHERE Hf.KOFM = #INF001.FMPR And
                                                   Hf.KOPF = #INF001.PFPR And
                                                   Hf.KOHF = #INF001.HFPR ),'Sin Sub-Famila')                                                   

UPDATE #INF001 SET MARCA = ISNULL((SELECT TOP 1 NOKOMR FROM TABMR Tm WHERE Tm.KOMR = #INF001.MRPR),'Sin Marca')
UPDATE #INF001 SET RUBRO = ISNULL((SELECT TOP 1 NOKORU FROM TABRU Tr WHERE Tr.KORU = #INF001.RUPR),'Sin Rubro')
UPDATE #INF001 SET CLAS_LIBRE = ISNULL((SELECT TOP 1 NOKOCARAC 
										  FROM TABCARAC Tr 
											WHERE Tr.KOTABLA = 'CLALIBPR' AND Tr.KOCARAC = #INF001.CLALIBPR),'Sin Clasificación')

--------------------------------------------------------------------------------------------------------------


SELECT * 
INTO #Tabla_Paso# 
FROM #INF001 WITH ( NOLOCK )  ORDER BY ENDO ,FEEMDO ,NUDO ,TIDO ,NULIDO  OPTION ( FAST 20 ) 

--CREATE INDEX IND01 ON #Tabla_Paso# ( TIDO, NUDO, ENDO, SUENDO, NULIDO)

--CREATE INDEX Ix_IPPR_#Funcionario#_01 ON #Tabla_Paso# (EMPRESA,KOSU,KOBO)
--CREATE INDEX Ix_IPPR_#Funcionario#_02 ON #Tabla_Paso# (EMPRESA,KOSU,FMPR)
--CREATE INDEX Ix_IPPR_#Funcionario#_03 ON #Tabla_Paso# (EMPRESA,KOPR)
--CREATE INDEX Ix_IPPR_#Funcionario#_04 ON #Tabla_Paso# (KOPR)
--CREATE INDEX Ix_IPPR_#Funcionario#_05 ON #Tabla_Paso# (COD_OBSOLENCIA)

DROP TABLE #INF001