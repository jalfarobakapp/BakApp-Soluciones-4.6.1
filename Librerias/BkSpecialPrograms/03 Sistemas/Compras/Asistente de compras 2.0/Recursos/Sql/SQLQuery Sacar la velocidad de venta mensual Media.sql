DECLARE 
@Empresa Char(2) = '#Empresa#',
@Fecha1 Date = '#FechaInicio#',
@Fecha2 Date = '#FechaTermino#',
@CodFuncionario Char(3) = '#Funcionario#',
@Dias Float,
@Meses Float
--,@Dias_Estudio Int,
--@Tipo_Estudio Varchar(3)

Set @Dias = Datediff( D,@Fecha1,@Fecha2)
Set	@Meses = Round(@Dias/31,2)
--set @Dias_Estudio = #Dias_Estudio#
--Set @Tipo_Estudio = '#Tipo_Estudio#'


SELECT      Cast('' As Varchar(20)) As Codigo_Nodo_Madre,
            TIDO,
			NUDO,
			FEEMLI,
            KOPRCT As Codigo,
			DAY(FEEMLI) as 'Dia',
            MONTH(FEEMLI) as 'Mes',
			YEAR(FEEMLI) as 'Año',
            ROUND(SUM(
            CASE WHEN TIDO IN ('NCE','NCV','NCX','NCZ','NEV') THEN CAPRCO1 * -1
	        WHEN TIDO IN ('GDV','GDP') THEN CAPRCO1-CAPREX1
	       	ELSE CAPRCO1 END	       	
	       	),5) As 'CantUd1',
	        ROUND(SUM(
            CASE WHEN TIDO IN ('NCE','NCV','NCX','NCZ','NEV') THEN - 1 * CAPRCO2
	        WHEN TIDO IN ('GDV','GDP') THEN CAPRCO2-CAPREX2
	       	ELSE CAPRCO2 END	       	
	       	),5) As 'CantUd2'
			Into #Paso
       FROM MAEDDO WITH ( NOLOCK )  
       --INNER JOIN MAEEDO AS EDO ON IDMAEEDO=EDO.IDMAEEDO  
       WHERE EMPRESA= @Empresa AND FEEMLI BETWEEN @Fecha1 And @Fecha2
       AND 
       TIDO IN  
	   ('FCV', 'FDB', 'FDV', 'FDX', 'FDZ', 'FEV', 'FVL', 'FVT', 'FVX', 'FVZ','FEE', 'BLV',
	    'GDV','GDP','NCE', 'NCV', 'NCX', 'NCZ', 'NEV')
	   #Filtro_Bodega#
	   #Filtro_Codigo#
       
       AND LILG IN ('SI','GR')  

	    #Entidades_Excluidas#
            
GROUP BY SULIDO,BOSULIDO,KOPRCT,TIDO,NUDO,FEEMLI  

Update #Paso Set #Codigo_Revision# = (Select top 1 #Codigo_Revision# From #TablaPaso# Z2 Where Z1.Codigo = Z2.Codigo)
From #Paso Z1

Update #Paso Set #Codigo_Revision# = Codigo 
Where #Codigo_Revision# In ('0','')



Select #Codigo_Revision#,Año,Mes,Dia,Sum(CantUd1) As CantUd1,Sum(CantUd2) As CantUd2  
Into #Dia From #Paso
Group By #Codigo_Revision#,Año,Mes,Dia

Select #Codigo_Revision#,Año,Mes,Sum(CantUd1) As CantUd1,Sum(CantUd2) As CantUd2  
Into #Mes From #Paso
Group By #Codigo_Revision#,Año,Mes



If @Dias = 0
Set @Dias = 1
If @Meses = 0
Set @Meses = 1


-- Dias

Select #Codigo_Revision#,Round(Sum(CantUd1),2) As CantUd1,
						 Round(Sum(CantUd2),2) As CantUd2,
						 @Dias As Dias,
						 @Meses As Meses,
						 Isnull(Round(Sum(CantUd1)/@Dias,2),2) As Promedio_Ud1,
                         Isnull(Round(STDEVP(CantUd1),2),0) As DvSt_Ud1,
			             Isnull(Round(Var(CantUd1),2),0) As Varianza_Ud1,
			             Cast(0 As Float) As Media_Ud1,
			             Isnull(Round(Sum(CantUd2)/@Meses,1),2) As Promedio_Ud2,
                         Isnull(Round(STDEVP(CantUd2),2),0) As DvSt_Ud2,
			             Isnull(Round(Var(CantUd2),2),0) As Varianza_Ud2,
			             Cast(0 As Float) As Media_Ud2

Into #MediaDias			  
From #Dia
Group By #Codigo_Revision#
Order by #Codigo_Revision#

Update #MediaDias Set Media_Ud1 = ((
		Select Top 1 CantUd1
		From   (
				Select	Top 50 Percent CantUd1
				From	#Dia Z2
				Where	CantUd1 Is NOT NULL And Z1.#Codigo_Revision# = Z2.#Codigo_Revision# And CantUd1 <> 0
				Order By CantUd1
				) As A
		Order By CantUd1 DESC) + 
		(
		Select Top 1 CantUd1
		From   (
				Select	Top 50 Percent CantUd1
				From	#Dia Z2
				Where	CantUd1 Is NOT NULL And Z1.#Codigo_Revision# = Z2.#Codigo_Revision# And CantUd1 <> 0
				Order By CantUd1 DESC
				) As A
		Order By CantUd1 Asc)) / 2,
		Media_Ud2 = ((
		Select Top 1 CantUd2
		From   (
				Select	Top 50 Percent CantUd2
				From	#Dia Z2
				Where	CantUd2 Is NOT NULL And Z1.#Codigo_Revision# = Z2.#Codigo_Revision# And CantUd2 <> 0
				Order By CantUd2
				) As A
		Order By CantUd2 DESC) + 
		(
		Select Top 1 CantUd2
		From   (
				Select	Top 50 Percent CantUd2
				From	#Dia Z2
				Where	CantUd2 Is NOT NULL And Z1.#Codigo_Revision# = Z2.#Codigo_Revision# And CantUd2 <> 0
				Order By CantUd2 DESC
				) As A
		Order By CantUd2 Asc)) / 2
From #MediaDias Z1

-- Mes

Select #Codigo_Revision#,Round(Sum(CantUd1),2) As CantUd1,
						 Round(Sum(CantUd2),2) As CantUd2,
						 @Dias As Dias,
						 @Meses As Meses,
						 Isnull(Round(Sum(CantUd1)/@Dias,2),2) As Promedio_Ud1,
                         Isnull(Round(STDEVP(CantUd1),2),0) As DvSt_Ud1,
			             Isnull(Round(Var(CantUd1),2),0) As Varianza_Ud1,
			             Cast(0 As Float) As Media_Ud1,
			             Isnull(Round(Sum(CantUd2)/@Meses,1),2) As Promedio_Ud2,
                         Isnull(Round(STDEVP(CantUd2),2),0) As DvSt_Ud2,
			             Isnull(Round(Var(CantUd2),2),0) As Varianza_Ud2,
			             Cast(0 As Float) As Media_Ud2

Into #MediaMes			  
From #Mes
Group By #Codigo_Revision#
Order by #Codigo_Revision#

Update #MediaMes Set Media_Ud1 = ((
		Select Top 1 CantUd1
		From   (
				Select	Top 50 Percent CantUd1
				From	#Mes Z2
				Where	CantUd1 Is NOT NULL And Z1.#Codigo_Revision# = Z2.#Codigo_Revision# And CantUd1 <> 0
				Order By CantUd1
				) As A
		Order By CantUd1 DESC) + 
		(
		Select Top 1 CantUd1
		From   (
				Select	Top 50 Percent CantUd1
				From	#Mes Z2
				Where	CantUd1 Is NOT NULL And Z1.#Codigo_Revision# = Z2.#Codigo_Revision# And CantUd1 <> 0
				Order By CantUd1 DESC
				) As A
		Order By CantUd1 Asc)) / 2,
		Media_Ud2 = ((
		Select Top 1 CantUd2
		From   (
				Select	Top 50 Percent CantUd2
				From	#Mes Z2
				Where	CantUd2 Is NOT NULL And Z1.#Codigo_Revision# = Z2.#Codigo_Revision# And CantUd2 <> 0
				Order By CantUd2
				) As A
		Order By CantUd2 DESC) + 
		(
		Select Top 1 CantUd2
		From   (
				Select	Top 50 Percent CantUd2
				From	#Mes Z2
				Where	CantUd2 Is NOT NULL And Z1.#Codigo_Revision# = Z2.#Codigo_Revision# And CantUd2 <> 0
				Order By CantUd2 DESC
				) As A
		Order By CantUd2 Asc)) / 2
From #MediaMes Z1


Update #TablaPaso# Set #Campo_RotUd1# = Isnull((Select Media_Ud1 From #MediaCal# Z2 Where Z1.#Codigo_Revision# = Z2.#Codigo_Revision#),0),
                       #Campo_RotUd2# = Isnull((Select Media_Ud2 From #MediaCal# Z2 Where Z1.#Codigo_Revision# = Z2.#Codigo_Revision#),0),
                       #Campo_Promedio_Ud1# = Isnull((Select Promedio_Ud1 From #MediaCal# Z2 Where Z1.#Codigo_Revision# = Z2.#Codigo_Revision#),0),
					   #Campo_Promedio_Ud2# = Isnull((Select Promedio_Ud2 From #MediaCal# Z2 Where Z1.#Codigo_Revision# = Z2.#Codigo_Revision#),0)
From #TablaPaso# Z1


Drop table #Paso
Drop table #Dia
Drop table #Mes
Drop table #MediaMes
Drop table #MediaDias

