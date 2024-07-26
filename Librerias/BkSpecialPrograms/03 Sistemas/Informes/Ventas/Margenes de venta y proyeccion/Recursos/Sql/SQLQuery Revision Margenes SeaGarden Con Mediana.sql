DECLARE 

@Fecha1 Date = '#Fecha_Desde#',
@Fecha2 Date = '#Fecha_Hasta#',
@Total_Neto Float,
@PP_Mrg Float,
@Total_Margen Float

SELECT	IDMAEEDO,TIDO,NUDO,ENDO,SUENDO,KOPRCT,UDTRPR,CAPRCO1,CAPRCO2,PPPRNELT,PPPRNE,PPPRBRLT,PPPRBR,POIVLI,VAIVLI,
        VANELI,VABRLI,PPPRPM, 
        ROUND(PPPRPM * CAPRCO1,0) AS COSTO,
		CASE WHEN VANELI > 0 THEN ROUND((VANELI-(PPPRPM * CAPRCO1))/VANELI,4) ELSE 0 END AS MG,
		ROUND(VANELI-ROUND(PPPRPM * CAPRCO1,0),0) AS MARGEN
Into #Paso_Detalle
FROM MAEDDO 
WHERE TIDO In ('BLV','BLX','BSV','ESC','FCV','FDB','FDV','FDX','FDZ','FEE','FEV','FVL','FVT','FVX','FVZ','FXV','FYV','NCE','NCV','NCX','NCZ','NEV') 
AND FEEMLI between @Fecha1 And @Fecha2
#EntExcluidas#

Update #Paso_Detalle Set VANELI = VANELI *-1,VAIVLI= VAIVLI*-1,VABRLI =VABRLI*-1,MG = MG*-1,MARGEN = MARGEN*-1,COSTO = COSTO*-1
Where TIDO In ('NCE','NCV','NCX','NCZ','NEV')


Select Ps.IDMAEEDO,Ps.TIDO,Ps.NUDO,Ps.ENDO,Ps.SUENDO,Isnull(Ma.NOKOEN,'') As NOKOEN,Edo.FEEMDO,SUM(VANELI) AS NETO,
       Sum(COSTO) As COSTO,
       Case When Sum(VANELI) = 0 Then 0 Else ROUND((SUM(VANELI)-(Sum(COSTO)))/Sum(VANELI),4) End As MG,
       SUM(VANELI)-(Sum(COSTO)) As MARGEN,
       Cast(0 As Float) As NETO_X_MG,Cast(0 As Float) As PP_MRG
Into #Paso_Totales
From #Paso_Detalle Ps
	Inner Join MAEEDO Edo On Edo.IDMAEEDO = Ps.IDMAEEDO
	Left Join MAEEN Ma On Ma.KOEN = Edo.ENDO And Ma.SUEN = Edo.SUENDO
Group By Ps.IDMAEEDO,Ps.TIDO,Ps.NUDO,Ps.ENDO,Ps.SUENDO,Ma.NOKOEN,Edo.FEEMDO

Set @Total_Neto = (Select Sum(NETO) From #Paso_Totales)
Set @Total_Margen = (Select Sum(MARGEN) From #Paso_Totales)
UPDATE #Paso_Totales Set NETO_X_MG = NETO*MG
UPDATE #Paso_Totales Set PP_MRG = round( NETO_X_MG / @Total_Neto,5)
Set @PP_Mrg = (Select Sum(PP_MRG) From #Paso_Totales)

Select Edo.FEEMDO,SUM(VANELI) AS NETO
Into #Paso_Fechas
From #Paso_Detalle Ps
	Inner Join MAEEDO Edo On Edo.IDMAEEDO = Ps.IDMAEEDO
Group By Edo.FEEMDO

Select Isnull(Round(AVG(NETO),0),2) As Promedio,
                        Isnull(Round(STDEVP(NETO),2),0) As DvSt,
			            Isnull(Round(Var(NETO),2),0) As Varianza,
			            Cast(0 As Float) As Mediana

Into #Media			  
From #Paso_Fechas


Update #Media Set Mediana = ((
		Select Top 1 NETO
		From   (
				Select	Top 50 Percent NETO
				From	#Paso_Fechas Z2
				Where NETO Is NOT NULL And NETO <> 0 --And Z1.FECHA = Z2.FEEMDO
				Order By NETO
				) As A
		Order By NETO DESC) + 
		(
		Select Top 1 NETO
		From   (
				Select	Top 50 Percent NETO
				From	#Paso_Fechas Z2
				Where	NETO Is NOT NULL And NETO <> 0 --And Z1.FECHA = Z2.FEEMDO
				Order By NETO DESC
				) As A
		Order By NETO Asc)) / 2
		
From #Media Z1

Update #Media Set Mediana = ISNULL(Mediana,0)
							              
Select * From #Paso_Totales
Select * From #Paso_Detalle
select * From #Paso_Fechas Order By FEEMDO
Select * From #Media
Select Isnull(@Total_Neto,0) As Total_Neto,Isnull(@PP_Mrg,0) As PP_Mrg,Isnull(@Total_Margen,0) As Total_Margen

Drop Table #Paso_Totales
Drop Table #Paso_Detalle
Drop table #Media
Drop table #Paso_Fechas


