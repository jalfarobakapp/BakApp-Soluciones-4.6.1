
Declare @Empresa Char(2) = '#Empresa#'

SELECT POTE.*,
	   Isnull(Pd.Grado,0) AS Grado_Prioridad,Cast(1 As Bit) As Terminada 
Into #Paso_Pote
FROM POTE 
Left JOIN #Base_Bakapp#Zw_Pdp_OT_Prioridad Pd ON Pd.Idpote=IDPOTE
WHERE ESODD = '#Tipo_OT#' And EMPRESA = @Empresa 
--AND NUMOT+REFERENCIA LIKE '%#Filtro#%' 
#NuevoFiltro#
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

Update #Paso_Potl Set Idpotl_Padre = Isnull((Select IDPOTL From POTL Z2 Where Z2.IDPOTE = #Paso_Potl.IDPOTE And Z2.NREG = #Paso_Potl.PERTENECE And Z2.IDPOTL <> #Paso_Potl.IDPOTL),IDPOTL)

Update #Paso_Pote Set Terminada = 0
Where IDPOTE In 
(Select IDPOTE From #Paso_Potl 
Where Estado_PT = '' and NIVEL = 0)

#Select_Tablas#

Drop table #Paso_Pote
Drop table #Paso_Potl
