
Declare @Empresa Char(2) = '#Empresa#'

/*  ***** CON ESTAS LINEAS SE PUEDEN VER LAS NOTAS DE VENTAS SOCIADASA LA OT *****

SELECT TOP 20 POTL.*,POTLCOM.DESDE AS TIDO,POTLCOM.NUMECOTI AS NUDO,POTLCOM.FABRICAR AS FABNVV,POTLCOM.REALIZADO AS REALNVV,POTLCOM.DESISTIDO AS DESISNVV,
         POTLCOM.ASIGNADO AS ASISNVV FROM POTL LEFT JOIN POTLCOM ON POTLCOM.IDPOTL=POTL.IDPOTL  
		 WHERE  POTL.IDPOTE=133 ORDER BY POTL.EMPRESA ,POTL.NUMOT ,POTL.NREG  OPTION ( FAST 20 ) 

SELECT * FROM POTLCOM -- TABLA QUE GUARDA LOS VINCULOS DE LAS NVV CON LAS OT
*/

SELECT POTE.*,
	   Isnull(Pd.Grado,0) AS Grado_Prioridad,Cast(1 As Bit) As Terminada 
Into #Paso_Pote
FROM POTE 
Left JOIN #Base_Bakapp#Zw_Pdp_OT_Prioridad Pd ON Pd.Idpote=IDPOTE
WHERE ESODD = '#Tipo_OT#' And EMPRESA = @Empresa 
AND NUMOT+REFERENCIA LIKE '%#Filtro#%' 
ORDER BY NUMOT


SELECT POTL.IDPOTL,IDPOTE,POTL.NUMOT,NREG,ESTADO,POTL.CODIGO,POTL.UDAD,CODNOMEN,POTL.FABRICAR,POTL.REALIZADO,DIFERENCIA,MARCANOM,GLOSA,NIVEL,
       Cast('' As Varchar(5)) As PERTENECE,
       NIVELSUP,Cast(0 As Int) As Idpotl_Padre, 
       (SELECT CASE WHEN COUNT(*)>0 THEN 'EN PROCESO' WHEN COUNT(*)<=0 THEN 'EN ESPERA' END 
		FROM #Base_Bakapp#Zw_Pdp_MesonVsProductos WHERE Idpotl=POTL.IDPOTL) AS ACTIVE,Cast ('' As Varchar(3)) As Estado_PT,
		Isnull(Plcom.ARCHIRST,'') As Archirst_Doc_Comercial,
		Isnull(Plcom.IDRST,0) As Id_Doc_Comercial,
		Isnull(Plcom.DESDE,'') As Tido_Doc_Comercial,
		Isnull(Plcom.NUMECOTI,'') As Nudo_Doc_Comercial

Into #Paso_Potl
FROM POTL 
Left Join POTLCOM Plcom On POTL.IDPOTL = Plcom.IDPOTL
Where IDPOTE In (Select IDPOTE From #Paso_Pote)
ORDER BY NUMOT, NREG

Update #Paso_Potl Set PERTENECE = Isnull((Select Top 1  PERTENECE From POTD Where NUMOT = #Paso_Potl.NUMOT And CODIGO = #Paso_Potl.CODIGO And CODNOMEN = #Paso_Potl.CODNOMEN And SUBNREG <> '' ),NREG)

Update #Paso_Potl set Estado_PT = Isnull((SELECT Top 1 Estado
		FROM  #Base_Bakapp#Zw_Pdp_MesonVsProductos Z2 
			WHERE Z1.IDPOTL=Z2.Idpotl And Estado = 'PT' ),'')
From #Paso_Potl Z1

SELECT IDPOTPR,IDPOTL,NUMOT,NREGOTL,CODIGO,CODMAQOT,
       POTPR.OPERACION,POTPR.ORDEN,
       COALESCE(ORDEN,'000') As Orden2,
	   FABRICAR,REALIZADO,FABRICAR-REALIZADO AS FALTANTE,
       #Base_Bakapp#Zw_Pdc_Mesones.Codmeson,NOMBREOP,Nommeson,Virtual,ActivaAlPrincipio,
	   Isnull((SELECT Top 1 Estado
		FROM  #Base_Bakapp#Zw_Pdp_MesonVsProductos 
			WHERE Idpotpr=IDPOTPR),'') as Est_Meson,
	   (SELECT COUNT(*) 
		FROM  #Base_Bakapp#Zw_Pdp_MesonVsProductos 
			WHERE Idpotpr=IDPOTPR) as Activos, 
	   (SELECT COUNT(*) 
	    FROM #Base_Bakapp#Zw_Pdp_MaquinaVsProductos
		WHERE Idpotpr=IDPOTPR And Estado <> 'FMQ') as ActivosMaq,
		Isnull((SELECT Top 1 Saldo_Fabricar
		FROM  #Base_Bakapp#Zw_Pdp_MesonVsProductos 
			WHERE Idpotpr=IDPOTPR),0) as Saldo_Fabricar,
			Isnull((SELECT Top 1 Porc_Fabricacion
		FROM  #Base_Bakapp#Zw_Pdp_MesonVsProductos 
			WHERE Idpotpr=IDPOTPR),0) as Porc_Fabricacion,
			Isnull((SELECT Top 1 Reproceso
		FROM  #Base_Bakapp#Zw_Pdp_MesonVsProductos 
			WHERE Idpotpr=IDPOTPR),0) as Reproceso,
			Isnull((SELECT Top 1 Cant_Reproceso
		FROM  #Base_Bakapp#Zw_Pdp_MesonVsProductos 
			WHERE Idpotpr=IDPOTPR),0) as Cant_Reproceso
Into #Paso_Potpr
		FROM POTPR 
			INNER JOIN #Base_Bakapp#Zw_Pdc_MesonVsMaquina ON 
				#Base_Bakapp#Zw_Pdc_MesonVsMaquina.Codmaq=POTPR.CODMAQOT 
					INNER JOIN #Base_Bakapp#Zw_Pdc_Mesones ON 
						#Base_Bakapp#Zw_Pdc_MesonVsMaquina.Codmeson=#Base_Bakapp#Zw_Pdc_Mesones.Codmeson 
							INNER JOIN POPER ON 
								POPER.OPERACION=POTPR.OPERACION 
WHERE IDPOTL In (Select IDPOTL From #Paso_Potl )

ORDER BY ORDEN --ASC

--Update #Paso_Potl Set Idpotl_Padre = Isnull((Select IDPOTL From POTL Z2 Where Z2.IDPOTE = #Paso_Potl.IDPOTE And Z2.NREG = #Paso_Potl.NIVELSUP And Z2.IDPOTL <> #Paso_Potl.IDPOTL),IDPOTL)
Update #Paso_Potl Set Idpotl_Padre = Isnull((Select IDPOTL From POTL Z2 Where Z2.IDPOTE = #Paso_Potl.IDPOTE And Z2.NREG = #Paso_Potl.PERTENECE And Z2.IDPOTL <> #Paso_Potl.IDPOTL),IDPOTL)

Update #Paso_Pote Set Terminada = 0
Where IDPOTE In 
(Select IDPOTE From #Paso_Potl 
Where Estado_PT = '' and NIVEL = 0)

--Select * From #Paso_Pote
--Select * From #Paso_Potl
--Select * From #Paso_Potpr

#Select_Tablas#

Drop table #Paso_Pote
Drop table #Paso_Potl
Drop table #Paso_Potpr