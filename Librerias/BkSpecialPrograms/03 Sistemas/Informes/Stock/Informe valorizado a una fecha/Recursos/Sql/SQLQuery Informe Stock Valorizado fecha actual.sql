Declare 
@Fecha_6_Meses_Menos Date = Dateadd(MONTH,-6,Getdate()),
@Fecha_1_Ano_Menos Date = Dateadd(YEAR,-1,Getdate()),
@Fecha_2_Ano_Menos Date = Dateadd(YEAR,-2,Getdate()),
@Fecha_3_Ano_Menos Date = Dateadd(YEAR,-3,Getdate())

SELECT
			TABBOPR.KOPR,
			TABBOPR.EMPRESA,
			TABBOPR.KOSU,
		    CAST('' AS VARCHAR (50)) AS SUCURSAL,
			TABBOPR.KOBO,
			CAST('' AS VARCHAR (50)) AS BODEGA,
			MAEPR.NOKOPR,MAEPR.UD01PR,MAEPR.UD02PR,MAEPREM.PM, 
			MAEPREM.TIMOUL,MAEPREM.PPUL01,MAEPREM.PPUL02,MAEPREM.TAUL,MAEPREM.VALI,MAEPREM.PMIN, 
			MAEPR.FMPR,
			CAST('' AS VARCHAR(50)) AS SUPER_FAMILIA,
			MAEPR.PFPR,
			CAST('' AS VARCHAR(50)) AS FAMILIA,
			MAEPR.HFPR,
			CAST('' AS VARCHAR(50)) AS SUB_FAMILIA,
			MAEPR.MRPR,
			CAST('' AS VARCHAR(50)) AS MARCA,
			MAEPR.RUPR,
			CAST('' AS VARCHAR(50)) AS RUBRO,
			MAEPR.CLALIBPR,
			CAST('' AS VARCHAR(200)) AS CLAS_LIBRE,
			CAST(NULL AS DATETIME ) AS ULT_COMPRA,
			CAST(NULL AS DATETIME ) AS ULT_VENTA,
			'STFI'=ISNULL(MAEST.STFI1,0.0),
            'VALSTOCK'=MAEST.STFI1*MAEPREM.PM,
            'PRMEDIO'=MAEPREM.PM,
            'UNIDAD'=MAEPR.UD01PR,
            CAST('' AS VARCHAR(3)) AS COD_OBSOLENCIA,
            CAST('' AS VARCHAR(30)) AS OBSOLENCIA,
            ISNULL((Select Top 1 IDMAEDDO 
            From MAEDDO Do Where Do.KOPRCT = MAEPR.KOPR And TIDO IN ('FCV','FDV','BLV') Order By FEEMLI Desc),0) As Idmaeddo,
            CAST(NULL AS DATE) AS Fecha
            
INTO #STOCKVAL 

FROM TABBOPR WITH ( NOLOCK )  
	INNER  JOIN MAEPREM ON MAEPREM.EMPRESA='01' AND 
		MAEPREM.KOPR=TABBOPR.KOPR  
			INNER JOIN MAEPR ON MAEPR.KOPR=MAEPREM.KOPR AND 
				TABBOPR.KOPR=MAEPR.KOPR  
					#Excluir_Productos_SSN#         --  AND MAEPR.TIPR <> 'SSN'  -- EXLUIR PRODUCTOS TIPO SERVICIO
				    #Excluir_Productos_FLN#         --  AND MAEPR.TIPR <> 'FLN'  -- EXCLUIR PRODUCTOS TIPO LIBRE
				    #Filtros_Productos#               --  AND MAEPR.FMPR IN ( '001 ','003 ')
				    #Excluir_Productos_Bloqueados#  -- NOT COALESCE(MAEPR.BLOQUEAPR,'') IN ( 'C','V','T','X' )  
						INNER  JOIN MAEST ON TABBOPR.EMPRESA='01' AND 
							TABBOPR.KOSU=MAEST.KOSU AND 
							TABBOPR.KOBO=MAEST.KOBO AND 
							TABBOPR.KOPR=MAEST.KOPR  
 
WHERE 1 > 0
#Filtro_Bodegas#


UPDATE #STOCKVAL SET FMPR = '' 
WHERE FMPR NOT IN (SELECT KOFM FROM TABFM)

UPDATE #STOCKVAL SET SUCURSAL = ISNULL((SELECT TOP 1 NOKOSU FROM TABSU Ts 
                                        WHERE Ts.EMPRESA = #STOCKVAL.EMPRESA And 
                                        Ts.KOSU = #STOCKVAL.KOSU),'')  
                                        
UPDATE #STOCKVAL SET BODEGA = ISNULL((SELECT TOP 1 NOKOBO FROM TABBO Ts 
							  WHERE Ts.EMPRESA = #STOCKVAL.EMPRESA And 
									Ts.KOSU = #STOCKVAL.KOSU And 
									Ts.KOBO = #STOCKVAL.KOBO ),'')  

----------------------- CLASIFICACIONES DEL PRODUCTO ------------------------------------------------------------
									
UPDATE #STOCKVAL SET SUPER_FAMILIA = ISNULL((SELECT TOP 1 NOKOFM FROM TABFM Tf 
                                             WHERE Tf.KOFM = #STOCKVAL.FMPR),'Sin Super Famila')
UPDATE #STOCKVAL SET FAMILIA = ISNULL((SELECT TOP 1 NOKOPF FROM TABPF Pf 
                                             WHERE Pf.KOFM = #STOCKVAL.FMPR And
                                                   Pf.KOPF = #STOCKVAL.PFPR ),'Sin Famila')
UPDATE #STOCKVAL SET SUB_FAMILIA = ISNULL((SELECT TOP 1 NOKOHF FROM TABHF Hf 
                                             WHERE Hf.KOFM = #STOCKVAL.FMPR And
                                                   Hf.KOPF = #STOCKVAL.PFPR And
                                                   Hf.KOHF = #STOCKVAL.HFPR ),'Sin Sub-Famila')                                                   

UPDATE #STOCKVAL SET MARCA = ISNULL((SELECT TOP 1 NOKOMR FROM TABMR Tm WHERE Tm.KOMR = #STOCKVAL.MRPR),'Sin Marca')
UPDATE #STOCKVAL SET RUBRO = ISNULL((SELECT TOP 1 NOKORU FROM TABRU Tr WHERE Tr.KORU = #STOCKVAL.RUPR),'Sin Rubro')
UPDATE #STOCKVAL SET CLAS_LIBRE = ISNULL((SELECT TOP 1 NOKOCARAC 
										  FROM TABCARAC Tr 
											WHERE Tr.KOTABLA = 'CLALIBPR' AND Tr.KOCARAC = #STOCKVAL.CLALIBPR),'Sin Clasificación')

--------------------------------------------------------------------------------------------------------------

UPDATE #STOCKVAL SET PRMEDIO= 0 WHERE PRMEDIO IS NULL

UPDATE #STOCKVAL SET Fecha = ISNULL((Select Top 1 FEEMLI From MAEDDO Do Where Do.IDMAEDDO = #STOCKVAL.Idmaeddo),'19000101')

UPDATE #STOCKVAL SET COD_OBSOLENCIA = '001',OBSOLENCIA = '> 6 MESES'
WHERE Fecha >= @Fecha_6_Meses_Menos

UPDATE #STOCKVAL SET COD_OBSOLENCIA = '002',OBSOLENCIA = '< 6 MESES'
Where Fecha < @Fecha_6_Meses_Menos And Fecha >= @Fecha_1_Ano_Menos

UPDATE #STOCKVAL SET COD_OBSOLENCIA = '003',OBSOLENCIA = '< 1 AÑO'
Where Fecha < @Fecha_1_Ano_Menos And Fecha >= @Fecha_2_Ano_Menos

UPDATE #STOCKVAL SET COD_OBSOLENCIA = '004',OBSOLENCIA = '< 2 AÑO'
Where Fecha <  @Fecha_2_Ano_Menos And Fecha >= @Fecha_3_Ano_Menos

UPDATE #STOCKVAL SET COD_OBSOLENCIA = '005',OBSOLENCIA = '< 3 AÑO'
Where Fecha <  @Fecha_3_Ano_Menos 

/*
Select '> 6 Meses' As Meses,SUM(STFI) AS STFI,SUM(VALSTOCK) as VALSTOCK
From #Paso_01
Where Fecha >= @Fecha_6_Meses_Menos
Union
Select '< 6 Meses' As Meses,SUM(STFI) AS STFI,SUM(VALSTOCK) as VALSTOCK
From #Paso_01
Where Fecha < @Fecha_6_Meses_Menos And Fecha >= @Fecha_1_Ano_Menos 
Union
Select '< 1 Año' As Meses,SUM(STFI) AS STFI,SUM(VALSTOCK) as VALSTOCK
From #Paso_01
Where Fecha < @Fecha_1_Ano_Menos 
Union
Select '< 2 Año' As Meses,SUM(STFI) AS STFI,SUM(VALSTOCK) as VALSTOCK
From #Paso_01
Where Fecha <  @Fecha_2_Ano_Menos 
Union
Select '< 3 Año' As Meses,SUM(STFI) AS STFI,SUM(VALSTOCK) as VALSTOCK
From #Paso_01
Where Fecha <  @Fecha_3_Ano_Menos 
*/

SELECT * 
Into #Tabla_Paso#
FROM #STOCKVAL 

CREATE INDEX Ix_ISV_#Funcionario#_01 ON #Tabla_Paso# (EMPRESA,KOSU,KOBO)
CREATE INDEX Ix_ISV_#Funcionario#_02 ON #Tabla_Paso# (EMPRESA,KOSU,FMPR)
CREATE INDEX Ix_ISV_#Funcionario#_03 ON #Tabla_Paso# (EMPRESA,KOPR)
CREATE INDEX Ix_ISV_#Funcionario#_04 ON #Tabla_Paso# (KOPR)
CREATE INDEX Ix_ISV_#Funcionario#_05 ON #Tabla_Paso# (COD_OBSOLENCIA)

DROP TABLE #STOCKVAL
