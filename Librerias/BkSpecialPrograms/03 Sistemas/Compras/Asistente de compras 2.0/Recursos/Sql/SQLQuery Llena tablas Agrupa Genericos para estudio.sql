


Declare @Tiempo_Reposicion As Int = #Tiempo_Reposicion#,
        @Dias_Avastecer As Int = #Dias_Avastecer#,
        @Porc_Crecimiento As Float = #Porc_Crecimiento#
        
Select --CodigoGenerico,
        --(Select top 1 NOKOPR From MAEPR Where CodigoGenerico = KOPR) AS Descripcion, 
        Codigo_Nodo_Madre,
        Descripcion_Madre,
        RotDiariaUd1 As RotDiariaUd,
        SumTotalQtyUd1 As SumTotalQtyUd,
        Cast(0 As Float) As Stock_CriticoUd_Rd,
        Cast(0 As Bit) As Con_Stock_CriticoUd,
        Cast(0 As Float) as Cant_Comprar_Sin_Restar_Stock, --Cantidad a Comprar Sin Restar el Stock de bodega
        Cast(0 As Float) as Cant_Comprar_Restando_Stock, --Cantidad a Comprar Restando el Stock de bodega
        Dias_Calculo As Dias,
        --Cast(0 As Float) As Dias,
        Stock_Fisico_Ud1 As StockUd,
        StockPedidoUd1 As StockPedidoUd,
        TStock,FCV,BLV,GDV,NCV,TDV
Into #Paso         
From #Tabla#
#Condicion_Especial#

Group By Codigo_Nodo_Madre,Descripcion_Madre,Dias_Calculo,RotDiariaUd1,SumTotalQtyUd1,Stock_Fisico_Ud1,StockPedidoUd1,TStock,FCV,BLV,GDV,NCV,TDV


#Update_Dias#

--Update #Paso Set RotDiariaUd = Case When Dias > 0 Then ROUND(SumTotalQtyUd/Dias,3) Else 0 End
--Update #Paso Set TStock = Case When StockUd > 0 And RotDiariaUd > 0 Then CEILING(ROUND(StockUd / RotDiariaUd,0)) else 0 end

Update #Paso Set Stock_CriticoUd_Rd = CEILING(Round(@Tiempo_Reposicion * RotDiariaUd,0))

Update #Paso set Cant_Comprar_Sin_Restar_Stock = CEILING(Round((@Dias_Avastecer * RotDiariaUd) * @Porc_Crecimiento,3)) 
Update #Paso set Cant_Comprar_Restando_Stock = CEILING(Round((@Dias_Avastecer * RotDiariaUd) * @Porc_Crecimiento,3)) -  StockUd

Update #Paso set Cant_Comprar_Sin_Restar_Stock = 0 Where Cant_Comprar_Sin_Restar_Stock < 0
Update #Paso set Cant_Comprar_Restando_Stock = 0 Where Cant_Comprar_Restando_Stock < 0


Update #Paso set Con_Stock_CriticoUd = 1 
Where StockUd-Stock_CriticoUd_Rd <= 0

Select * From #Paso 
Where 1 > 0
#Condicion#
--And CodigoGenerico = '2240082610K00'
--And Cant_Comprar_Restando_Stock > 0
--And StockPedidoUd#Ud# > 0
Drop Table #Paso


/*
Select CodigoGenerico,
       Cast('' As Varchar(50)) As Descripcion,
       Dias_Avastecer,
       SUM(StockUd#Ud#) as StockUd#Ud#,
       SUM(StockUd2) as StockUd2,
       SUM(Stock_CriticoUd#Ud#_Rd) as Stock_CriticoUd#Ud#_Rd,
       SUM(Stock_CriticoUd2_Rd) as Stock_CriticoUd2_Rd,
       SUM(StockUd#Ud#)-SUM(Stock_CriticoUd#Ud#_Rd) As Diferencia_StCriUd#Ud#,
       SUM(StockUd2)-SUM(Stock_CriticoUd2_Rd) As Diferencia_StCriUd2,
       SUM(StockPedidoUd#Ud#) As StockPedidoUd#Ud#,
       SUM(StockPedidoUd2) As StockPedidoUd2,
       --SUM(StockUd#Ud#)/Sum(RotDiariaUd#Ud#) as TStock,
       SUM(TStock) as TStock,
       SUM(CantSugeridaTot) as Cant_Comprar_SnStock, --Cantidad a Comprar Sin Restar el Stock de bodega
       SUM(CantSugeridaTot) - SUM(StockUd#Ud#) as Cant_Comprar_ReStock, --Cantidad a Comprar Restando el Stock de bodega
       Sum(RotDiariaUd#Ud#) as RotDiariaUd#Ud#,
       Sum(RotDiariaUd2) as RotDiariaUd2,
       SUM(RotEstacionalUd#Ud#) as RotEstacionalUd#Ud#,
       SUM(FCV) as FCV,
       SUM(BLV) as BLV,
       SUM(GDV) as GDV,
       SUM(NCV) as NCV,
       SUM(TDV) as TDV
       
Into #Paso
FROM  #Tabla#
Where 1 = 1 
And Oculto = ''  
 
Group By CodigoGenerico,Dias_Avastecer    

Update #Paso Set Descripcion = (Select Top 1 NOKOPR From MAEPR T1 Where KOPR = CodigoGenerico)

Select * From #Paso
Where 1 > 0 
#Condicion#

Drop Table #Paso

--Diferencia_StCriUd#Ud# < 0 And Cant_Comprar_ReStock

--having  SUM(StockUd#Ud#)-SUM(Stock_CriticoUd#Ud#_Rd) < 0
--And SUM(CantSugeridaTot) - SUM(StockUd#Ud#) > 0
*/