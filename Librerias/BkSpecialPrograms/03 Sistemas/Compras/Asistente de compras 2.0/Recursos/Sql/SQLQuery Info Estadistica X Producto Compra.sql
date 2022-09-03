Declare
@CodFuncionario  Char(3),
@FechaInicio     Datetime,
@FechaTermino    Datetime,
@Mes             Int

SELECT @CodFuncionario = '#Funcionario#',@FechaInicio = '#FechaInicio#',@FechaTermino = '#FechaTermino#',@Mes = #Mes# 


SELECT KOPRCT as 'Codigo',
       FEEMLI as 'Fecha',  
       DATENAME(month,FEEMLI) as 'Mes_Palabra',
       DATEPART(week, FEEMLI) as 'Semana',
       MONTH(FEEMLI) as 'Mes',
       YEAR(FEEMLI) as 'Ano',
       ROUND(SUM(
       
       CASE WHEN TIDO IN ('NCC') THEN - 1 * CAPRCO1
	        WHEN TIDO IN ('GRC') THEN CAPRCO1-CAPREX1
	       	ELSE CAPRCO1 END	       	
	       	),2) As 'CantUd1',
	   ROUND(SUM(
	   CASE WHEN TIDO IN ('NCC') THEN - 1 * CAPRCO2
	        WHEN TIDO IN ('GRC') THEN CAPRCO2-CAPREX2
	       	ELSE CAPRCO2 END),2) As 'CantUd2',
	       	
	   ROUND(SUM( CASE WHEN TIDO IN ('NCC') THEN - 1 * VANELI 
       WHEN TIDO IN ('GRC') THEN CASE When CAPRCO1-CAPREX1 = 0 Then 0 Else CAPRCO1-CAPREX1 * (VANELI/CAPRCO1) End 
            ELSE VANELI END),0)  As 'Valor',
          
       Round(Sum( CASE WHEN TIDO IN ('NCC') THEN - 1 * VABRLI 
       WHEN TIDO IN ('GRC') THEN CASE When CAPRCO1-CAPREX1 = 0 Then 0 Else CAPRCO1-CAPREX1 * (VABRLI/CAPRCO1) End
            ELSE VABRLI END),0)  As 'ValorB' 

       Into #Paso1#
       From MAEDDO 
       Where 
       KOPRCT In #Codigo# And 
       TIDO IN ('FCC', 'GRC','NCC') And
	   FEEMLI BETWEEN @FechaInicio AND @FechaTermino  

       #Filtro_Entidades_Excluidas#
       #Filtro_Bodega#  
       
GROUP BY KOPRCT,FEEMLI


---- Tabla de ventas a Entidades Excluidas

Select KOPRCT as 'Codigo',
       FEEMLI as 'Fecha',  
       Datename(Month,FEEMLI) as 'Mes_Palabra',
       Datepart(week, FEEMLI) as 'Semana',
       Month(FEEMLI) as 'Mes',
       Year(FEEMLI) as 'Ano',
       Round(Sum(
       
       CASE WHEN TIDO IN ('NCC') THEN - 1 * CAPRCO1
	        WHEN TIDO IN ('GRC') THEN CAPRCO1-CAPREX1
	       	ELSE CAPRCO1 END	       	
	       	),2) As 'CantUd1',
	   Round(Sum(
	   CASE WHEN TIDO IN ('NCC') THEN - 1 * CAPRCO2
	        WHEN TIDO IN ('GRC') THEN CAPRCO2-CAPREX2
	       	ELSE CAPRCO2 END),2) As 'CantUd2',
	       	
	   ROUND(SUM( CASE WHEN TIDO IN ('NCC') THEN - 1 * VANELI 
       WHEN TIDO IN ('GRC') THEN CASE When CAPRCO1-CAPREX1 = 0 Then 0 Else CAPRCO1-CAPREX1 * (VANELI/CAPRCO1) End 
            ELSE VANELI END),0)  As 'Valor',
          
       Round(Sum( CASE WHEN TIDO IN ('NCC') THEN - 1 * VABRLI 
       WHEN TIDO IN ('GRC') THEN CASE When CAPRCO1-CAPREX1 = 0 Then 0 Else CAPRCO1-CAPREX1 * (VABRLI/CAPRCO1) End
            ELSE VABRLI END),0)  As 'ValorB' 

       Into #Cmps_EntExcluidas#
       From MAEDDO 
       Where 
       KOPRCT In #Codigo# And 
       TIDO IN ('FCC', 'GRC','NCC') And
	   FEEMLI BETWEEN @FechaInicio AND @FechaTermino  

       And Ltrim(Rtrim(ENDO))+Ltrim(Rtrim(SUENDO)) IN 
       (SELECT Rtrim(Ltrim(Codigo))+Rtrim(Ltrim(Sucursal)) From #_Global_BaseBk#Zw_TblInf_EntExcluidas Where Funcionario = @CodFuncionario And Excluida in ('V','A','T'))
       #Filtro_Bodega#  
       
GROUP BY KOPRCT,FEEMLI

--#Insertar_Otras_Filas#

--Select Ltrim(Rtrim(Mes_Palabra))+'-'+Ltrim(Rtrim(STR(Ano))) as Periodo,Mes,

Select Ltrim(Rtrim(Mes_Palabra))+'-'+Ltrim(Rtrim(STR(Ano))) as 'Periodo',
       Rtrim(Ltrim(Str(Ano)))+'-'+Case When Mes < 10 Then '0'+Rtrim(Ltrim(Str(Mes))) Else Rtrim(Ltrim(Str(Mes))) End As 'Periodo2',
       Ano,
       Mes,
       Round(Sum(CantUd1),2) as 'Ud1',
       Round(Sum(CantUd2),2) as 'Ud2',
       CASE When Sum(Valor) = 0 OR Sum(CantUd1) = 0 Then 0 Else Round(Sum(Valor)/Sum(CantUd1),0) End As 'ValorUnit',
       CASE When Sum(ValorB) = 0 OR Sum(CantUd1) = 0 Then 0 Else Round(Sum(ValorB)/Sum(CantUd1),0) End As 'ValorUnitB',
       Round(Sum(CantUd1),2) * Sum(Valor) As 'Valor',
       Round(Sum(CantUd1),2) * Sum(ValorB) As 'ValorB',
       	   -- Campos Nuevos
	   Cast(0 As Float) As 'Ud1_EE', 
	   Cast(0 As Float) As 'Ud2_EE',
	   Cast(0 As Float) As 'ValorUnit_EE',
	   Cast(0 As Float) As 'ValorUnitB_EE',
	   Cast(0 As Float) As 'Valor_EE',
	   Cast(0 As Float) As 'ValorB_EE'
Into #Meses
From #Paso1#
WHERE  Codigo In #Codigo#
GROUP BY Mes_Palabra,Ano,Mes
ORDER BY Ano,Mes


-- Datos Entidades_Excluidas

Select Ltrim(Rtrim(Mes_Palabra))+'-'+Ltrim(Rtrim(STR(Ano))) as 'Periodo',
       Rtrim(Ltrim(Str(Ano)))+'-'+Case When Mes < 10 Then '0'+Rtrim(Ltrim(Str(Mes))) Else Rtrim(Ltrim(Str(Mes))) End As 'Periodo2',
       Ano,
       Mes,
       Round(Sum(CantUd1),2) as 'Ud1',
       Round(Sum(CantUd2),2) as 'Ud2',
       CASE When Sum(Valor) = 0 OR Sum(CantUd1) = 0 Then 0 Else Round(Sum(Valor)/Sum(CantUd1),0) End As 'ValorUnit',
       CASE When Sum(ValorB) = 0 OR Sum(CantUd1) = 0 Then 0 Else Round(Sum(ValorB)/Sum(CantUd1),0) End As 'ValorUnitB',
       Round(Sum(CantUd1),2) * Sum(Valor) As 'Valor',
       Round(Sum(CantUd1),2) * Sum(ValorB) As 'ValorB'
Into #Meses_Ent_Excluidad
From #Cmps_EntExcluidas#
WHERE  Codigo In #Codigo#
GROUP BY Mes_Palabra,Ano,Mes
ORDER BY Ano,Mes

--- Recorre e incorpora nuevas fechas que no tienen venta

DECLARE @cnt INT = 0, 
        @Meses_R Int = 13, -- Datediff(Month,@FechaInicio,@FechaTermino),
        @Fecha As datetime = @FechaInicio
DECLARE @Ano2 As Int,
		@Mes2 As Int,
		@Reg as Int

WHILE @cnt < @Meses_R
BEGIN
   
   Select @Ano2 = Year(@Fecha),@Mes2 = Month(@Fecha)

   Set @Reg = (Select Count(*) From #Meses Where Ano = @Ano2 And Mes = @Mes2)

   If @Reg = 0
   Begin
		Insert Into #Meses (Periodo,Periodo2,Ano,Mes,Ud1,Ud2,ValorUnit,ValorUnitB,Valor,ValorB,Ud1_EE,Ud2_EE,ValorUnit_EE,ValorUnitB_EE,Valor_EE,ValorB_EE) Values
			(DATENAME(Month,@Fecha)+'-'+Rtrim(Ltrim(Str(@Ano2))),
			Rtrim(Ltrim(Str(@Ano2)))+'-'+Case When @Mes2 < 10 Then '0'+Rtrim(Ltrim(Str(@Mes2))) Else Rtrim(Ltrim(Str(@Mes2))) End,
			@Ano2,@Mes2,0,0,0,0,0,0,0,0,0,0,0,0)
   End
   Set @Fecha = DATEADD(MONTH,1,@Fecha)
   Set @cnt = @cnt+1

END

--- Actualizar datos en Grilla meses con datos de entidadesexcluidas

Update #Meses Set Ud1_EE = Ee.Ud1 ,Ud2_EE = Ee.Ud2,Valor_EE = Ee.Valor,ValorB_EE = Ee.ValorB,ValorUnit_EE = Ee.ValorUnit,ValorUnitB_EE = Ee.ValorUnitB
From #Meses
Inner Join #Meses_Ent_Excluidad Ee On #Meses.Periodo = Ee.Periodo

---

SELECT RANK() over (order by Semana) Semana ,Round(Sum(CantUd1),0) as Ud1,Round(Sum(CantUd2),0) as Ud2,Ltrim(Rtrim(Mes_Palabra))+'-'+Ltrim(Rtrim(STR(Ano))) as Periodo
Into #Semanas
FROM #Paso1#
WHERE Codigo In #Codigo# --And Mes = @Mes
Group By Mes_Palabra,Semana,Ano,Mes
ORDER BY Semana

Select * From #Meses ORDER BY Ano Desc,Mes Desc
Select * From #Semanas

Select Ano,Mes,Ltrim(Rtrim(Mes_Palabra))+'-'+Ltrim(Rtrim(STR(Ano))) as Periodo,
Round(Sum(CantUd1),2) as Ud1,Round(Sum(CantUd2),2) as Ud2,
CASE When Sum(Valor) = 0 OR Sum(CantUd1) = 0 Then 0 Else Round(Sum(Valor)/Sum(CantUd1),0) End As 'ValorUnit',
CASE When Sum(ValorB) = 0 OR Sum(CantUd1) = 0 Then 0 Else Round(Sum(ValorB)/Sum(CantUd1),0) End As 'ValorUnitB',
Round(Sum(CantUd1),2) * Sum(Valor) As 'Valor',
Round(Sum(CantUd1),2) * Sum(ValorB) As 'ValorB'
From #Paso1#
WHERE Codigo In #Codigo#
And Valor <> 0
GROUP BY Mes_Palabra,Ano,Mes
Union
Select Ano,Mes,Ltrim(Rtrim(Mes_Palabra))+'-'+Ltrim(Rtrim(STR(Ano))) as Periodo,
0 As Ud1,
0 As Ud2,
0 As ValorUnit,
0 As ValorUnitB,
Sum(Valor) As Valor,
Sum(ValorB) As ValorB
From #Paso1#
WHERE Codigo In #Codigo#
And Valor = 0 and Mes_Palabra+str(Ano) Not in 
(Select Mes_Palabra+str(Ano) From #Paso1# where Valor <> 0 and Codigo In #Codigo#)
GROUP BY Mes_Palabra,Ano,Mes
Order by Ano,Mes 

Drop Table #Paso1#
Drop Table #Cmps_EntExcluidas#
Drop Table #Meses
Drop Table #Meses_Ent_Excluidad
Drop Table #Semanas
