BEGIN TRY
 DROP TABLE #Paso1
 END TRY
 BEGIN CATCH
END CATCH

Select #CODIGO# As CODIGO,#DESCRIPCION# As DESCRIPCION,
       UPPER(SUBSTRING(DATENAME(MONTH,FEEMLI),1,3))+'.'+DATENAME(YEAR,FEEMLI) AS Mes_Ano,
       UPPER(SUBSTRING(DATENAME(MONTH,FEEMLI),1,3)) AS Mes,DATENAME(YEAR,FEEMLI) As Ano,SUM(VANELI) As VANELI,
       CONVERT(int, MONTH(FEEMLI)) As Orden
Into #Paso1
From #Tabla_Paso#
Where 1 > 0
#Filtro_Sql#
#Filtro_Fechas#
Group By #CODIGO#,#DESCRIPCION#,FEEMLI

#Sql_Puntos_Cero#

Select CODIGO,DESCRIPCION,Mes_Ano,Mes,Ano,Orden,
       Case When Round(Sum(VANELI),0) = 0 Then Null Else Round(Sum(VANELI),0) End As Total
From #Paso1
Group By CODIGO,DESCRIPCION,Mes_Ano,Mes,Ano,Orden
Order By Ano,Orden


Drop Table #Paso1
