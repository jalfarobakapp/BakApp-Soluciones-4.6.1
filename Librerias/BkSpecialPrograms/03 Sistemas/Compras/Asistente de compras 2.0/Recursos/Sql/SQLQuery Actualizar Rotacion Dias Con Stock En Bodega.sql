Declare @UsarSabado bit,
        @UsarDomingo bit,
        @Unidad int,
        @Dias_Avastecer int,
        @Tiempo_Reposicion Float,
        @Porc_Crecimiento float,
        @Porc_Cre Float,
        @RestarStock bit


UPDATE Zps Set 
		
		Zps.Fecha_Inicio = Zw_Prod_Rotacion.Fecha_Inicio,
		Zps.Fecha_Fin = Zw_Prod_Rotacion.Fecha_Fin,
		Zps.Fecha_Ultima_Ejecucion = Zw_Prod_Rotacion.Fecha_Ultima_Ejecucion
		

FROM Zw_Prod_Rotacion  RIGHT OUTER JOIN
     #TablaPaso# AS Zps ON Zw_Prod_Rotacion.Codigo = Zps.Codigo
     #Filtro_Bodega#
     #Filtro_Asociados#


UPDATE #TablaPaso# Set 
				   Dias_Existencia_Habiles = (Select Max(Dias_Existencia_Habiles) From Zw_Prod_Rotacion
				   Where #TablaPaso#.Codigo = Zw_Prod_Rotacion.Codigo 
				   #Filtro_Bodega# And Es_Asociador = 0),
				   
		           Dias_Existencia_Sabados = (Select Max(Dias_Existencia_Sabados) From Zw_Prod_Rotacion
				   Where #TablaPaso#.Codigo = Zw_Prod_Rotacion.Codigo 
		           #Filtro_Bodega# And Es_Asociador = 0),
		           
		           Dias_Existencia_Domingos = (Select Max(Dias_Existencia_Domingos) From Zw_Prod_Rotacion
				   Where #TablaPaso#.Codigo = Zw_Prod_Rotacion.Codigo 
		           #Filtro_Bodega# And Es_Asociador = 0),
		           
		           FCV = (Select Sum(Zw_Prod_Rotacion.FCV) From Zw_Prod_Rotacion
		           Where #TablaPaso#.Codigo = Zw_Prod_Rotacion.Codigo 
		           #Filtro_Bodega# And Es_Asociador = 0),
		           
		           BLV = (Select Sum(Zw_Prod_Rotacion.BLV) From Zw_Prod_Rotacion
		           Where #TablaPaso#.Codigo = Zw_Prod_Rotacion.Codigo 
		           #Filtro_Bodega# And Es_Asociador = 0),
		           
		           GDV = (Select Sum(Zw_Prod_Rotacion.GDV) From Zw_Prod_Rotacion
		           Where #TablaPaso#.Codigo = Zw_Prod_Rotacion.Codigo 
		           #Filtro_Bodega# And Es_Asociador = 0),
		           
		           NCV = (Select Sum(Zw_Prod_Rotacion.NCV) From Zw_Prod_Rotacion
		           Where #TablaPaso#.Codigo = Zw_Prod_Rotacion.Codigo 
		           #Filtro_Bodega# And Es_Asociador = 0),
		           
		           TDV = (Select Sum(Zw_Prod_Rotacion.TDV) From Zw_Prod_Rotacion
		           Where #TablaPaso#.Codigo = Zw_Prod_Rotacion.Codigo 
		           #Filtro_Bodega# And Es_Asociador = 0),
		           
		           SumTotalQtyUd1 = (Select Sum(Zw_Prod_Rotacion.SumTotalQtyUd1) From Zw_Prod_Rotacion
		           Where #TablaPaso#.Codigo = Zw_Prod_Rotacion.Codigo 
		           #Filtro_Bodega# And Es_Asociador = 0),
		           
		           SumTotalQtyUd2 = (Select Sum(Zw_Prod_Rotacion.SumTotalQtyUd2) From Zw_Prod_Rotacion
		           Where #TablaPaso#.Codigo = Zw_Prod_Rotacion.Codigo 
		           #Filtro_Bodega# And Es_Asociador = 0),
		           
		           SumTotal = (Select Sum(Zw_Prod_Rotacion.SumTotal) From Zw_Prod_Rotacion
		           Where #TablaPaso#.Codigo = Zw_Prod_Rotacion.Codigo 
		           #Filtro_Bodega# And Es_Asociador = 0),
		           
		           SumTotalVal = (Select Sum(Zw_Prod_Rotacion.SumTotalVal) From Zw_Prod_Rotacion
		           Where #TablaPaso#.Codigo = Zw_Prod_Rotacion.Codigo 
		           #Filtro_Bodega# And Es_Asociador = 0)
		           
Where 1 > 0 #Filtro_Productos#		           
		      
		      
/*

UPDATE #TablaPaso# Set 
				   Dias_Existencia_Habiles = (Select Max(Dias_Existencia_Habiles) From Zw_Prod_Rotacion
				   Where #TablaPaso#.Codigo = Zw_Prod_Rotacion.Codigo 
				   #Filtro_Bodega# And Es_Asociador = 0),
				   
		           Dias_Existencia_Sabados = (Select Max(Dias_Existencia_Sabados) From Zw_Prod_Rotacion
				   Where #TablaPaso#.Codigo = Zw_Prod_Rotacion.Codigo 
		           #Filtro_Bodega# And Es_Asociador = 0),
		           
		           Dias_Existencia_Domingos = (Select Max(Dias_Existencia_Domingos) From Zw_Prod_Rotacion
				   Where #TablaPaso#.Codigo = Zw_Prod_Rotacion.Codigo 
		           #Filtro_Bodega# And Es_Asociador = 0)
		           
Where 1 > 0 #Filtro_Productos# And Es_Agrupador = 1
		      
*/    
		           
#Sql_Actualizar_Rotacion#		           
		       
      
		           

Select  @Unidad = #Ud#,
        @Tiempo_Reposicion = #Tiempo_Reposicion#,
        @Dias_Avastecer = #Dias_Avastecer#,
        @Porc_Crecimiento = #Porc_Crecimiento#,
        @Porc_Cre =1+#Porc_Crecimiento#/100.0,
        @RestarStock = #RestarStock#
		
		
/*
				
UPDATE #TablaPaso#
SET Dias_Calculo = Dias_Existencia_Habiles,
Dias_Calculo_Est = Case When Dias_Habiles_Est < Dias_Vida_Habiles 
                   Then Dias_Habiles_Est  
                   else Dias_Vida_Habiles
                   end               

IF @UsarSabado = 1			   
UPDATE #TablaPaso#
SET Dias_Calculo = Dias_Calculo + Dias_Existencia_Sabados,
Dias_Calculo_Est = Dias_Calculo_Est + Case When Dias_Sabados_Est < Dias_Vida_Sabados 
                   Then Dias_Sabados_Est  
                   else Dias_Vida_Sabados
                   end                   

IF @UsarDomingo = 1			   
UPDATE #TablaPaso#
SET Dias_Calculo = Dias_Calculo + Dias_Existencia_Domingos,
Dias_Calculo_Est = Dias_Calculo_Est + Case When Dias_Domingos_Est < Dias_Vida_Domingos 
                   Then Dias_Domingos_Est  
                   else Dias_Vida_Domingos
                   end			

--cast((1375.0*100/1462) as decimal(10,2)) as porcentaje				
				   
UPDATE #TablaPaso# set                   
     RotDiariaUd1 = round(case When SumTotalQtyUd1 > 0 and Dias_Calculo > 0 then SumTotalQtyUd1/Dias_Calculo else 0 end,5),
     RotDiariaUd2 = round(case When SumTotalQtyUd2 > 0 and Dias_Calculo > 0 then SumTotalQtyUd2/Dias_Calculo else 0 end,5),
     RotEstacionalUd1 = round(case When SumQtyEstacionalUd1 > 0 and Dias_Calculo_Est > 0 then SumQtyEstacionalUd1/Dias_Calculo_Est else 0 end,5),
     RotEstacionalUd2 = round(case When SumQtyEstacionalUd2 > 0 and Dias_Calculo_Est > 0 then SumQtyEstacionalUd2/Dias_Calculo_Est else 0 end,5)

UPDATE #TablaPaso# set                   
     RotDiariaUd1 = cast((RotDiariaUd1) as decimal(10,5)),
     RotDiariaUd2 = cast((RotDiariaUd2) as decimal(10,5)),
     RotEstacionalUd1 = cast((RotEstacionalUd1) as decimal(10,5)),
     RotEstacionalUd2 = cast((RotEstacionalUd2) as decimal(10,5))



If @Unidad = 1
BEGIN
UPDATE #TablaPaso# set
	Tiempo_Reposicion = @Tiempo_Reposicion,                   
	TStock = Case When StockUd1 > 0 And RotDiariaUd1 > 0 Then CEILING(ROUND(StockUd1 / RotDiariaUd1,0))	else 0 end,
	TStockEstacional = Case When StockUd1 > 0 And RotEstacionalUd1 > 0 then 
		               CEILING(ROUND(StockUd1 / RotEstacionalUd1,0))	else 0 end,
	Stock_CriticoUd1_Rd = CEILING(Round(@Tiempo_Reposicion * RotDiariaUd1,0)),
	Stock_CriticoUd1_Re = CEILING(Round(@Tiempo_Reposicion * RotEstacionalUd1,0)),
	Dias_Avastecer = @Dias_Avastecer,
	Porc_Crecimiento = @Porc_Crecimiento
	Where 1 > 0 #Filtro_Productos#
END

If @Unidad = 2
	BEGIN
	UPDATE #TablaPaso# set  
	TStock = Case When StockUd2 > 0 And RotDiariaUd2 > 0 then CEILING(ROUND(StockUd2 / RotDiariaUd2,0))	else 0 end,
	TStockEstacional = Case When StockUd2 > 0 And RotEstacionalUd2 > 0 then 
		               CEILING(ROUND(StockUd2 / RotEstacionalUd2,0))	else 0 end,
	Stock_CriticoUd2_Rd = CEILING(Round(@Tiempo_Reposicion * RotDiariaUd2,0)),
	Stock_CriticoUd2_Re = CEILING(Round(@Tiempo_Reposicion * RotEstacionalUd2,0)),
	Dias_Avastecer = @Dias_Avastecer,
	Porc_Crecimiento = @Porc_Crecimiento
	Where 1 > 0 #Filtro_Productos#
END

UPDATE #TablaPaso# set
CantSugeridaTot = ((@Dias_Avastecer * RotDiariaUd#Ud#)*@Porc_Cre)-Case @RestarStock When 1 Then StockUd#Ud# else 0 end,
CantSugeridaEst = ((@Dias_Avastecer * RotEstacionalUd#Ud#)*@Porc_Cre)-Case @RestarStock When 1 Then StockUd#Ud# else 0 end 
Where 1 > 0 #Filtro_Productos#

UPDATE #TablaPaso# set Stock_CriticoUd1_Rd = 1 
Where 1 > 0 #Filtro_Productos# And Stock_CriticoUd1_Rd = 0

UPDATE #TablaPaso# set Stock_CriticoUd2_Rd = 1 
Where 1 > 0 #Filtro_Productos# And Stock_CriticoUd2_Rd = 0

UPDATE #TablaPaso# set Con_Stock_CriticoUd1 = 0 
Where 1 > 0 #Filtro_Productos#

UPDATE #TablaPaso# set Con_Stock_CriticoUd2 = 0
Where 1 > 0 #Filtro_Productos#

UPDATE #TablaPaso# set Con_Stock_CriticoUd1 = Case When (StockUd1 - Stock_CriticoUd1_Rd) < 0 Then 1 Else 0 End 
Where 1 > 0 #Filtro_Productos#
UPDATE #TablaPaso# set Con_Stock_CriticoUd2 =  Case When (StockUd2 - Stock_CriticoUd2_Rd) < 0 Then 1 Else 0 End 
Where 1 > 0 #Filtro_Productos#
	 
UPDATE #TablaPaso# set  
CantSugeridaTot = CEILING(ROUND(CantSugeridaTot,0)),
CantSugeridaEst = CEILING(ROUND(CantSugeridaEst,0))
Where 1 > 0
#Filtro_Productos# 

UPDATE #TablaPaso# set CantSugeridaTot = 0 Where 1 > 0 And CantSugeridaTot < 0 #Filtro_Productos#
UPDATE #TablaPaso# set CantSugeridaEst = 0 Where 1 > 0 And CantSugeridaEst < 0 #Filtro_Productos#

*/