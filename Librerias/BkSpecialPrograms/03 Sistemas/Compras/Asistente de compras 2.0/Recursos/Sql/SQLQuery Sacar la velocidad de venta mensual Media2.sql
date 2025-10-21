DECLARE 
@Empresa Char(2) = '#Empresa#',
@Fecha1 Date = '#FechaInicio#',
@Fecha2 Date = '#FechaTermino#',
@CodFuncionario Char(3) = '#Funcionario#',
@Dias Float,
@Meses Float,
@Incluir_Sabado Bit,
@Incluir_Domingo Bit


Select @Incluir_Sabado = #Incluir_Sabado#, @Incluir_Domingo = #Incluir_Domingo#

SET DATEFIRST 1
Declare @dias_habiles Float=0;
Declare @dias_habiles_mes Float=0;
Declare @dias_semana Float=0;
Declare @dias_sabado Float=0;
Declare @dias_domingo Float=0;
Declare @meses_habiles Float;
Declare @FechaIni date = @Fecha1;
Declare @FechaFin date = @Fecha2;

WHILE @FechaIni <= @FechaFin
BEGIN

   If datepart(dw, @FechaIni) In (1,2,3,4,5) SET @dias_semana=@dias_semana+1 -- Domingo
   If datepart(dw, @FechaIni) In (6)         SET @dias_sabado=@dias_sabado+1 -- Domingo
   If datepart(dw, @FechaIni) In (7)         SET @dias_domingo=@dias_domingo+1 -- Domingo
   Set @FechaIni=dateadd(dd,1,@FechaIni)

END  

Set @dias_habiles = @dias_semana

If @Incluir_Sabado = 1
Set @dias_habiles = @dias_habiles+@dias_sabado

If @Incluir_Domingo = 1
Set @dias_habiles = @dias_habiles+@dias_domingo

--Select @dias_semana As Dias_Semana,@dias_sabado As Dias_Sabado,@dias_domingo As Dias_Domingo

Set @Dias = Datediff(D,@Fecha1,@Fecha2)
Set	@Meses = Round(@Dias/30.41666,1)
Set @meses_habiles= Round(@dias_habiles/30.41666,3)
Set @dias_habiles_mes=@dias_habiles/@Meses

--Select @Fecha1 As 'F.Desde',@Fecha2 As 'F.Hasta', @dias_habiles As 'Dias Habiles',@Dias as Dias,@Meses As Meses, @meses_habiles As meses_habiles,@dias_habiles_mes As Dias_Habil_X_Mes


--Set @Dias = Datediff( D,@Fecha1,@Fecha2)
--Set	@Meses = Round(@Dias/31,2)


Select      Cast('' As Varchar(20)) As Codigo_Nodo_Madre,
            TIDO,
			NUDO,
			FEEMLI,
            KOPRCT As Codigo,
			DAY(FEEMLI) as 'Dia',
            MONTH(FEEMLI) as 'Mes',
			YEAR(FEEMLI) as 'Año',
            ROUND(SUM(
            CASE WHEN TIDO IN ('NCE','NCV','NCX','NCZ','NEV','GRI') THEN CAPRCO1 * -1
	        WHEN TIDO IN ('GDV','GDP') THEN CAPRCO1-CAPREX1
	       	ELSE CAPRCO1 END	       	
	       	),5) As 'CantUd1',
	        ROUND(SUM(
            CASE WHEN TIDO IN ('NCE','NCV','NCX','NCZ','NEV','GRI') THEN - 1 * CAPRCO2
	        WHEN TIDO IN ('GDV','GDP') THEN CAPRCO2-CAPREX2
	       	ELSE CAPRCO2 END	       	
	       	),5) As 'CantUd2'
			Into #Paso
       FROM MAEDDO WITH ( NOLOCK )  
       --INNER JOIN MAEEDO AS EDO ON IDMAEEDO=EDO.IDMAEEDO  
       WHERE EMPRESA= @Empresa AND FEEMLI BETWEEN @Fecha1 And @Fecha2
       --AND 
       --TIDO IN  
	   --('FCV', 'FDB', 'FDV', 'FDX', 'FDZ', 'FEV', 'FVL', 'FVT', 'FVX', 'FVZ','FEE', 'BLV',
	   -- 'GDV','GDP','NCE', 'NCV', 'NCX', 'NCZ', 'NEV')
       #Filtro_Documentos#
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
						 --Isnull(Round(Sum(CantUd1)/@meses_habiles,2),2) As Promedio_Ud1,
                         Isnull(Round(Sum(CantUd1)/@Meses,2),2) As Promedio_Ud1,
                         Isnull(Round(STDEVP(CantUd1),2),0) As DvSt_Ud1,
			             Isnull(Round(Var(CantUd1),2),0) As Varianza_Ud1,
			             Cast(0 As Float) As Media_Ud1,
			             --Isnull(Round(Sum(CantUd2)/@meses_habiles,1),2) As Promedio_Ud2,
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
						 @dias_habiles As Dias,
						 @meses_habiles As Meses,
						 --Isnull(Round((Sum(CantUd1)/@dias_habiles)*@dias_habiles_mes,2),2) As Promedio_Ud1,
						 Isnull(Round(Sum(CantUd1)/@Meses,2),2) As Promedio_Ud1,
                         Isnull(Round(STDEVP(CantUd1),2),0) As DvSt_Ud1,
			             Isnull(Round(Var(CantUd1),2),0) As Varianza_Ud1,
			             Cast(0 As Float) As Media_Ud1,
			             --Isnull(Round(Sum(CantUd2)/@meses_habiles,2),2) As Promedio_Ud2,
                         Isnull(Round(Sum(CantUd2)/@Meses,2),2) As Promedio_Ud2,
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


Update #TablaPaso# Set #Campo_RotUd1Mes# = Isnull((Select Media_Ud1 From #MediaCal# Z2 Where Z1.#Codigo_Revision# = Z2.#Codigo_Revision#),0),
                       #Campo_Promedio_Ud1Mes# = Isnull((Select Promedio_Ud1 From #MediaCal# Z2 Where Z1.#Codigo_Revision# = Z2.#Codigo_Revision#),0)
From #TablaPaso# Z1

--Update #TablaPaso# Set #Campo_RotUd2Mes# = #Campo_RotUd1Mes#/Rtu,#Campo_Promedio_Ud2Mes# = #Campo_Promedio_Ud1Mes#/Rtu

Update #TablaPaso# Set #Campo_RotUd2Mes# = Round(#Campo_RotUd1Mes#/Rtu,5)
Update #TablaPaso# Set #Campo_Promedio_Ud2Mes# = Round(#Campo_Promedio_Ud1Mes#/Rtu,5)

--Update #TablaPaso# Set #Campo_Promedio_Ud1Dia# = Round(#Campo_Promedio_Ud1Mes#/@dias_habiles_mes,5)
--Update #TablaPaso# Set #Campo_Promedio_Ud2Dia# = Round(#Campo_Promedio_Ud2Mes#/@dias_habiles_mes,5)

Update #TablaPaso# Set #Campo_Promedio_Ud1Dia# = Round(#Campo_Promedio_Ud1Mes#/30.41666,5)
Update #TablaPaso# Set #Campo_Promedio_Ud2Dia# = Round(#Campo_Promedio_Ud2Mes#/30.41666,5)

Update #TablaPaso# Set #Campo_RotUd1Dia# = Round(#Campo_RotUd1Mes#/@dias_habiles_mes,5)
Update #TablaPaso# Set #Campo_RotUd2Dia# = Round(#Campo_RotUd2Mes#/@dias_habiles_mes,5)  


Drop table #Paso
Drop table #Dia
Drop table #Mes
Drop table #MediaMes
Drop table #MediaDias

