Declare @Identificador_NodoPadre Int = #Identificador_NodoPadre#
Declare @Porc_Creciminto Float = #Porc_Creciminto#
Declare @Dias_Proyeccion Float = #Dias_Proyeccion#
Declare @Dias_Abastecer Int
Declare @Marca_Proyeccion Int = #Marca_Proyeccion#
Declare @RotCalculo Char(1) = '#RotCalculo#'
Declare @Fecha_Actual Date = GetDate()

Set @Porc_Creciminto = @Porc_Creciminto /100.0 + 1        
Set @Dias_Abastecer = #Dias_Abastecer#--@Dias_Proyeccion * 4
        
        --select @Porc_Creciminto,10/100.0 +1
 
-- TABLA AGRUPADORA DE PRODUCTOS INDIVIDUALMENTE       

SELECT  Codigo,
        Descripcion,
        Codigo_Nodo,
		Codigo_Nodo_Madre,
        Descripcion_Madre As Producto,
        UD#Ud#,Rtu, 
        SUM(StockUd#Ud#_Prod) As StockUd#Ud#, 
        SUM(StockEnTransitoUd1_Prod) As StockEnTransitoUd#Ud#, 
        SUM(StockPedidoUd#Ud#_Prod) As StockPedidoUd#Ud#, 
        SUM(StockFacSinRecepUd#Ud#_Prod) As StockFacSinRecepUd#Ud#,
		Stock_CriticoUd#Ud#_Rd,
        RotDiariaUd#Ud#, 
        RotMensualUd#Ud#, 
        RotDiariaUd#Ud#_Prod, 
        RotMensualUd#Ud#_Prod,
        
        SUM(SumTotalQtyUd#Ud#) AS SumTotalQtyUd#Ud#,
		Fecha_Inicio,
		Fecha_Fin,
		Cast(0 As float) As Dias_Fecha,
		Cast(0 As float) As Meses_Fecha,

        SUM(SumTotalQtyUd#Ud#_Ult_3Mes) AS SumTotalQtyUd#Ud#_Ult_3Mes,
        SUM(SumTotalQtyUd#Ud#_Ult_3Cio) AS SumTotalQtyUd#Ud#_Ult_3Cio,

        CAST(0 As Float) As Promedio_3Meses,
		CAST(0 As Float) As Tendencia,
        CAST(0 As Float) As RotCalculo, 
        CAST(0 As Float) As Stock_Asegurado_Dias, 
        CAST(0 As Float) As Stock_Asegurado_Proyeccion, 
        CAST(0 As Float) As Duracion_Dias, 
        CAST(0 As Float) As Duracion_Proyeccion, 
        CAST(0 As Float) As Duracion_Proyeccion_Recepcion, 
        CAST(0 As Float) As Cant_Comprar,
	    CAST(0 As Float) As Cant_Comprar_Sug,
	    CAST(0 As Float) As Cant_Comprar_Sug_Red,
		@Dias_Abastecer AS Dias_Abastecer,
		Cast(0 As Float) As Proyeccion_Abastecer,
		Cast(0 As Int) As Idmaeedo,
		Cast('' As CHAR(3)) As Tido,
		Cast('' As Varchar(10)) As Nudo,
		CAST(Null As DATE) As Fecha_Recep
		Into #Tbl_Paso_Proyecto
FROM #TablaPaso#

Where Codigo In (SELECT Codigo FROM #Tbl_BakApp#Zw_Prod_Asociacion 
				 WHERE Codigo_Nodo In (Select Distinct Codigo_Nodo From #Tbl_BakApp#Zw_TblArbol_Asociaciones 
				 --Where Identificacdor_NodoPadre = @Identificador_NodoPadre))--= @Codigo_Nodo)
				 Where Codigo_Nodo In #Filtro_Nodos#))
And Es_Agrupador = 0	

Group by UD1,Rtu,Codigo,Descripcion,Codigo_Nodo,Codigo_Nodo_Madre,Descripcion_Madre,Stock_CriticoUd1_Rd,RotDiariaUd1,RotDiariaUd1_Prod,RotMensualUd1,RotMensualUd1_Prod,Fecha_Inicio,Fecha_Fin

Update #Tbl_Paso_Proyecto Set Dias_Fecha = DATEDIFF(D,Fecha_Inicio,Fecha_Fin)                                  
Update #Tbl_Paso_Proyecto Set Meses_Fecha = DATEDIFF(M,Fecha_Inicio,Fecha_Fin)                                      

Update #Tbl_Paso_Proyecto Set Idmaeedo = Isnull((Select Top 1 IDMAEEDO 
                                                     From MAEDDO 
                                                     Where KOPRCT = Codigo 
                                                           And TIDO IN ('OCC','FCC') 
                                                           And ESLIDO = '' 
                                                          -- And FEERLI >= @Fecha_Actual 
                                                     Order By FEERLI),0)                                           

Update #Tbl_Paso_Proyecto Set Tido = Edo.TIDO,Nudo = Edo.NUDO,Fecha_Recep = Edo.FEERLI
FROM   #Tbl_Paso_Proyecto Zp INNER JOIN
       MAEDDO Edo ON Zp.Idmaeedo = Edo.IDMAEEDO
                                          
---- ROTACION DIARIA

--If @RotCalculo = 'D'
--Begin
--Update #Tbl_Paso_Proyecto Set RotCalculo = RotDiariaUd#Ud#
--End


--Update #Tbl_Paso_Proyecto Set Stock_Asegurado_Dias = ROUND(((StockUd1)/ case When RotCalculo > 0 then RotCalculo Else 1 End),0)
--Update #Tbl_Paso_Proyecto Set Stock_Asegurado_Proyeccion = ROUND(((StockUd1)/ case When RotCalculo > 0 then RotCalculo Else 1 End * @Porc_Creciminto)/@Dias_Proyeccion,0)

--Update #Tbl_Paso_Proyecto Set Duracion_Dias = ROUND(((StockUd#Ud#+StockPedidoUd#Ud#)/ case When RotCalculo > 0 then RotCalculo Else 1 End),0)
--Update #Tbl_Paso_Proyecto Set Duracion_Proyeccion = ROUND(((StockUd#Ud#+StockPedidoUd#Ud#)/ case When RotCalculo > 0 then RotCalculo Else 1 End * @Porc_Creciminto)/@Dias_Proyeccion,0)
--Update #Tbl_Paso_Proyecto Set Duracion_Proyeccion_Recepcion = ROUND(((StockPedidoUd#Ud#)/ case When RotCalculo > 0 then RotCalculo Else 1 End * @Porc_Creciminto)/@Dias_Proyeccion,0)


Update #Tbl_Paso_Proyecto Set Cant_Comprar = ROUND((RotCalculo*@Porc_Creciminto)*@Dias_Abastecer,0)
Update #Tbl_Paso_Proyecto Set Cant_Comprar_Sug = ROUND(Cant_Comprar - (StockUd#Ud#+StockPedidoUd#Ud#+StockFacSinRecepUd#Ud#+StockEnTransitoUd#Ud#),0)
Update #Tbl_Paso_Proyecto Set Cant_Comprar_Sug_Red = Cant_Comprar_Sug 

                              
Update #Tbl_Paso_Proyecto Set Proyeccion_Abastecer = CEILING(ROUND(Dias_Abastecer/@Dias_Proyeccion,2))



SELECT  Codigo_Nodo,
		Codigo_Nodo_Madre,
        Producto,
        Sum(StockUd#Ud#) As StockUd#Ud#, 
        SUM(StockEnTransitoUd#Ud#) As StockEnTransitoUd#Ud#, 
        Sum(StockPedidoUd#Ud#) As StockPedidoUd#Ud#, 
        RotDiariaUd#Ud#, 
        RotMensualUd#Ud#, 
		Sum(StockFacSinRecepUd#Ud#) As StockFacSinRecepUd#Ud#,
        Stock_CriticoUd#Ud#_Rd,
        SUM(RotCalculo) As RotCalculo, --
        CAST(0 As Float) As Venta_Periodo, 

        SUM(SumTotalQtyUd1) AS SumTotalQtyUd1,
        CAST(0 As Float) AS Promedio_Diario,
		CAST(0 As Float) AS Promedio_Mensual,
		Fecha_Inicio,
		Fecha_Fin,
		Dias_Fecha,
		Meses_Fecha,

        SUM(SumTotalQtyUd#Ud#_Ult_3Mes) AS SumTotalQtyUd#Ud#_Ult_3Mes,
		CAST(0 As Float) AS Promedio_3Mes,

        CAST(0 As Float) AS Venta_Ult_3Cio,
		SUM(SumTotalQtyUd#Ud#_Ult_3Cio) AS SumTotalQtyUd#Ud#_Ult_3Cio,
		CAST(0 As Float) As Tendencia,

        CAST(0 As Float) As Stock_Asegurado_Dias,--SUM(Stock_Asegurado_Dias) As Stock_Asegurado_Dias, 
        CAST(0 As Float) As Stock_Asegurado_Proyeccion,--SUM(Stock_Asegurado_Proyeccion) As Stock_Asegurado_Proyeccion,      
        CAST(0 As Float) As Duracion_Dias,--SUM(Duracion_Dias) As Duracion_Dias, 
        CAST(0 As Float) As Duracion_Proyeccion,--SUM(Duracion_Proyeccion) As Duracion_Proyeccion, 
        CAST(0 As Float) As Duracion_Proyeccion_Recepcion,--SUM(Duracion_Proyeccion_Recepcion) As Duracion_Proyeccion_Recepcion, 
        SUM(Cant_Comprar) As Cant_Comprar,
        SUM(Cant_Comprar_Sug) AS Cant_Comprar_Sug,
        SUM(Cant_Comprar_Sug_Red) AS Cant_Comprar_Sug_Red,
	    Dias_Abastecer,
	    Proyeccion_Abastecer,
        CAST(0 As int) As 'Idmaeedo_ProxRC',
		CAST('' As char(3)) As 'Tido_ProxRC',
		CAST('' As char(10)) As 'Nudo_ProxRC',
		CAST(Null As datetime) As 'Feerli_ProxRC',
		CAST(0 As int) AS 'Dias_ProxRC',
		CAST(0 As float) As 'Meses_ProxRC',
		CAST(0 As float) As 'RotDiaria_NoQuiebra', 
		CAST(0 As float) As 'RotMensual_NoQuiebra', 
		CAST(0 As bit) As 'SugCmbPrecio',
	    #Campos_Proyeccion#
	    CAST('' As Char(1)) As 'Fin'
Into #Tbl_Paso_Proyecto_01	    
FROM #Tbl_Paso_Proyecto
Group By Codigo_Nodo,Codigo_Nodo_Madre,Producto,Dias_Abastecer,Proyeccion_Abastecer,Stock_CriticoUd1_Rd,RotDiariaUd1,RotMensualUd1,Fecha_Inicio,Fecha_Fin,Dias_Fecha,Meses_Fecha
Order by Producto


Update #Tbl_Paso_Proyecto_01 Set Promedio_Diario = Round(SumTotalQtyUd1/Dias_Fecha,2)
Update #Tbl_Paso_Proyecto_01 Set Promedio_Mensual = Round(SumTotalQtyUd1/Meses_Fecha,0)

If @RotCalculo = 'D'
Update #Tbl_Paso_Proyecto_01 Set RotCalculo = RotDiariaUd1

If @RotCalculo = 'P'
Begin
Update #Tbl_Paso_Proyecto_01 Set RotCalculo = Promedio_Diario
End

Set @Dias_Proyeccion = 30

Update #Tbl_Paso_Proyecto_01 Set Cant_Comprar = ROUND((RotCalculo*@Porc_Creciminto)*@Dias_Abastecer,0)
Update #Tbl_Paso_Proyecto_01 Set Cant_Comprar_Sug = ROUND(Cant_Comprar - (StockUd#Ud#+StockPedidoUd#Ud#+StockFacSinRecepUd#Ud#+StockEnTransitoUd#Ud#),0)
Update #Tbl_Paso_Proyecto_01 Set Cant_Comprar_Sug_Red = Cant_Comprar_Sug 


Update #Tbl_Paso_Proyecto_01 Set Venta_Periodo = RotCalculo * @Dias_Proyeccion

-- Tendencia

Update #Tbl_Paso_Proyecto_01 Set Venta_Ult_3Cio = SumTotalQtyUd#Ud#_Ult_3Cio/3 
Update #Tbl_Paso_Proyecto_01 Set Promedio_3Mes = Round(SumTotalQtyUd#Ud#_Ult_3Mes/3,2) 
Update #Tbl_Paso_Proyecto_01 Set Tendencia = Round(SumTotalQtyUd#Ud#_Ult_3Cio/Promedio_3Mes,5) Where Promedio_3Mes > 0
Update #Tbl_Paso_Proyecto_01 Set Tendencia = Tendencia-1 Where Tendencia < 0
Update #Tbl_Paso_Proyecto_01 Set Tendencia = (1-Tendencia)*-1 Where Tendencia < 1 And Tendencia > 0
Update #Tbl_Paso_Proyecto_01 Set Tendencia = Tendencia - 1 Where Tendencia > 1
Update #Tbl_Paso_Proyecto_01 Set Tendencia = Round(Tendencia,2)
Update #Tbl_Paso_Proyecto_01 Set Tendencia = 0 Where SumTotalQtyUd#Ud#_Ult_3Cio = Promedio_3Mes
Update #Tbl_Paso_Proyecto_01 Set Tendencia = -1 Where SumTotalQtyUd#Ud#_Ult_3Cio = 0 And Promedio_3Mes > 0

--Update #Tbl_Paso_Proyecto_01 Set Tendencia = 0 Where Round(Tendencia,0) = 1

Update #Tbl_Paso_Proyecto_01 Set Stock_Asegurado_Dias = ROUND((StockUd#Ud#+StockEnTransitoUd#Ud#)/ RotCalculo,0)
Where RotCalculo > 0 													

Update #Tbl_Paso_Proyecto_01 Set Stock_Asegurado_Proyeccion = ROUND(((StockUd#Ud#/ RotCalculo)* @Porc_Creciminto)/@Dias_Proyeccion,0)
Where RotCalculo > 0 

Update #Tbl_Paso_Proyecto_01 Set Duracion_Dias = ROUND((StockUd#Ud#+StockPedidoUd#Ud#+StockFacSinRecepUd#Ud#+StockEnTransitoUd#Ud#)/RotCalculo,0)
Where RotCalculo > 0 													
						
--SELECT 57600/350.5													

Update #Tbl_Paso_Proyecto_01 Set Duracion_Proyeccion = 
		ROUND((((StockUd#Ud#+StockPedidoUd#Ud#+StockFacSinRecepUd#Ud#+StockEnTransitoUd#Ud#)/RotCalculo) * @Porc_Creciminto)/@Dias_Proyeccion,0)
Where RotCalculo > 0 

Update #Tbl_Paso_Proyecto_01 Set Duracion_Proyeccion_Recepcion = 
		ROUND(((StockPedidoUd#Ud#+StockFacSinRecepUd#Ud#)/ RotCalculo * @Porc_Creciminto)/@Dias_Proyeccion,0)
Where RotCalculo > 0 

--

Update #Tbl_Paso_Proyecto_01 Set Stock_Asegurado_Dias = ROUND((StockUd#Ud#+StockEnTransitoUd#Ud#)/1,0)
Where RotCalculo = 0 													

Update #Tbl_Paso_Proyecto_01 Set Stock_Asegurado_Proyeccion = ROUND((((StockUd#Ud#+StockEnTransitoUd#Ud#)/1)* @Porc_Creciminto)/@Dias_Proyeccion,0)
Where RotCalculo = 0

Update #Tbl_Paso_Proyecto_01 Set Duracion_Dias = 
		ROUND((StockUd#Ud#+StockPedidoUd#Ud#+StockFacSinRecepUd#Ud#+StockEnTransitoUd#Ud#)/1,0)
Where RotCalculo = 0

Update #Tbl_Paso_Proyecto_01 Set Duracion_Proyeccion = 
		ROUND((((StockUd#Ud#+StockPedidoUd#Ud#+StockFacSinRecepUd#Ud#+StockEnTransitoUd#Ud#)/1) * @Porc_Creciminto)/@Dias_Proyeccion,0)
Where RotCalculo = 0

Update #Tbl_Paso_Proyecto_01 Set Duracion_Proyeccion_Recepcion = 
		ROUND(((StockPedidoUd#Ud#+StockFacSinRecepUd#Ud#+StockEnTransitoUd#Ud#)/1 * @Porc_Creciminto)/@Dias_Proyeccion,0)
Where RotCalculo = 0

--



#Update_Campos_Proyeccion#	

                                                                                                                                                                                                                                                                                                                
Update #Tbl_Paso_Proyecto_01 Set Cant_Comprar = 0,Cant_Comprar_Sug = 0,Cant_Comprar_Sug_Red = 0
Where Duracion_Proyeccion > Proyeccion_Abastecer 
Update #Tbl_Paso_Proyecto_01 Set Cant_Comprar = 0
Where Cant_Comprar < 0 

Update #Tbl_Paso_Proyecto_01 Set Cant_Comprar_Sug = 0
Where Cant_Comprar_Sug < 0 

Update #Tbl_Paso_Proyecto_01 Set Cant_Comprar_Sug_Red = 0
Where Cant_Comprar_Sug_Red < 0 


-- Sumar Totales
SELECT  Sum(StockUd1) As StockUd, 
        Sum(StockPedidoUd1) As StockPedidoUd, 
        Sum(StockFacSinRecepUd1) As StockFacSinRecepUd,
        Sum(RotDiariaUd1) As RotDiariaUd, 
        Sum(Venta_Periodo) As RotMensualUd,
        Cast(0 As Float) As Prom_Pond,				
		Sum(Cant_Comprar_Sug) AS Cant_Comprar_Sug,
		Cast(0 As Float) AS Cant_Comprar_Sug2
		
Into #Tbl_Paso_Proyecto_02	    
FROM #Tbl_Paso_Proyecto_01

Update #Tbl_Paso_Proyecto_02 Set Prom_Pond = Round((StockUd+StockPedidoUd+StockFacSinRecepUd) / RotMensualUd,2) Where RotMensualUd > 0
Update #Tbl_Paso_Proyecto_02 Set Cant_Comprar_Sug2 = Ceiling(Round(Cant_Comprar_Sug/23000,2))


Select KOPRCT As Codigo,Ps1.Codigo_Nodo_Madre,IDMAEEDO,TIDO,NUDO,ENDO,SUENDO,Isnull(NOKOEN,'???') As Razon,
       UD01PR,CAPRCO1,CAPREX1,(CAPRCO1-(CAPRAD1+CAPREX1)) As Saldo, FEERLI 
Into #PasoUltComp
From MAEDDO Ddo
Left Join MAEEN On KOEN = ENDO And SUEN = SUENDO
Left Join #Tbl_Paso_Proyecto Ps1 On Ps1.Codigo = Ddo.KOPRCT 
Where KOPRCT In (Select Codigo From #Tbl_Paso_Proyecto) And TIDO In ('OCC','FCC') And ESLIDO = '' 
Order By FEERLI 

Update #Tbl_Paso_Proyecto_01 Set Idmaeedo_ProxRC = Isnull((Select Top 1 IDMAEEDO From #PasoUltComp Ps1 Where Ps1.Codigo_Nodo_Madre = #Tbl_Paso_Proyecto_01.Codigo_Nodo_Madre Order By FEERLI),0)

Update #Tbl_Paso_Proyecto_01 Set Tido_ProxRC = TIDO,Nudo_ProxRC = NUDO,Feerli_ProxRC = FEERLI
From #Tbl_Paso_Proyecto_01
Inner Join #PasoUltComp On Idmaeedo_ProxRC = IDMAEEDO

Update #Tbl_Paso_Proyecto_01 Set Dias_ProxRC = DATEDIFF(Day,GETDATE(),Feerli_ProxRC),Meses_ProxRC = DATEDIFF(month,GETDATE(),Feerli_ProxRC)
Where Idmaeedo_ProxRC > 0

Update #Tbl_Paso_Proyecto_01 Set RotDiaria_NoQuiebra = Round((StockUd#Ud#/Dias_ProxRC),0),RotMensual_NoQuiebra = Round((StockUd#Ud#/Dias_ProxRC) * @Dias_Proyeccion,0)
Where Idmaeedo_ProxRC > 0 And Dias_ProxRC <> 0

Update #Tbl_Paso_Proyecto_01 Set SugCmbPrecio = 1
Where RotDiaria_NoQuiebra < RotCalculo And RotDiaria_NoQuiebra > 0

-- Nuevo estudio
Update #Tbl_Paso_Proyecto_01 Set 
SugCmbPrecio = 1
,RotDiaria_NoQuiebra = Round((StockUd#Ud#/@Dias_Abastecer),0)
,RotMensual_NoQuiebra = Round((StockUd#Ud#/@Dias_Abastecer) * @Dias_Proyeccion,0)
Where StockPedidoUd#Ud# = 0 
And StockFacSinRecepUd#Ud# = 0 
And Stock_Asegurado_Dias < @Dias_Abastecer 
And StockUd#Ud# > 0 And Duracion_Proyeccion > 0

Select * From #Tbl_Paso_Proyecto Order by Producto
Select * From #Tbl_Paso_Proyecto_01
Select * From #PasoUltComp
Select * From #Tbl_Paso_Proyecto_02

Select Codigo_Nodo_Madre,Producto,StockUd#Ud#,Promedio_Mensual,RotMensualUd#Ud#,RotMensual_NoQuiebra,SugCmbPrecio,Cast(0 As Float) As 'PPV',
Cast(0 As Float) As MinPrecio,Cast(0 As Float) As 'MaxPrecio',CAST(0 As Bit) As 'RevisarPrecio'
From #Tbl_Paso_Proyecto_01 
Where SugCmbPrecio = 1

Drop Table #Tbl_Paso_Proyecto
Drop Table #Tbl_Paso_Proyecto_01
Drop Table #Tbl_Paso_Proyecto_02
Drop Table #PasoUltComp



/*
Select * From #Tbl_Paso_Proyecto Order by Producto
Select * From #Tbl_Paso_Proyecto_01

Select KOPRCT As Codigo,IDMAEEDO,TIDO,NUDO,ENDO,SUENDO,(Select Top 1 NOKOEN From MAEEN Where KOEN+SUEN = ENDO+SUENDO) As Razon,
       UD0#Ud#PR,CAPRCO#Ud#,CAPREX#Ud#,(CAPRCO#Ud#-(CAPRAD#Ud#+CAPREX#Ud#)) As Saldo, FEERLI 
       From MAEDDO 
Where KOPRCT  In (Select Codigo From #Tbl_Paso_Proyecto) And 
      TIDO In ('OCC','FCC') And ESLIDO = '' 
      Order By FEERLI 

Select * From #Tbl_Paso_Proyecto_02

Drop Table #Tbl_Paso_Proyecto
Drop Table #Tbl_Paso_Proyecto_01
Drop Table #Tbl_Paso_Proyecto_02

*/