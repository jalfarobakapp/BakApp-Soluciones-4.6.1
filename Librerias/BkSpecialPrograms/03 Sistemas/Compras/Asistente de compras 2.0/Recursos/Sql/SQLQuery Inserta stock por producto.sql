

Select KOPR,Cast('' As Varchar(30)) As Codigo_Nodo_Madre,
       Sum(STFI1) As STFI1,
       CAST(0 As Float) As StfiBodExt1,
       Sum(STFI2) As STFI2,
       CAST(0 As Float) As StfiBodExt2,
       Sum(STDV1) As STDV1,Sum(STDV2) As STDV2,
       Sum(STOCNV1C) As STOCNV1C,
       Sum(STOCNV2C) As STOCNV2C,
       Sum(STDV1C) As STDV1C,
       Sum(STDV2C) As STDV2C,
       Sum(STTR1) As STTR1,
       Sum(STTR2) As STTR2,
       CAST(0 As Float) As StPedNVIUd1,
	   CAST(0 As Float) As StPedNVIUd2,
       CAST(0 As Float) As StTransitoUd1,
	   CAST(0 As Float) As StTransitoUd2
Into #Paso
From MAEST
Where KOPR In (Select Codigo From #TablaPaso#) #Filtro_Bodega#--And EMPRESA+KOSU+KOBO In ('01CM PR','01WCMWCM')
Group By KOPR


--InsertarStockFisicoDeBodegaExterna

--InsertarStockPedidoEnNVI

Update #Paso Set Codigo_Nodo_Madre = (Select Top 1 Codigo_Nodo_Madre From #TablaPaso# Where KOPR = Codigo)

Select Codigo_Nodo_Madre,
        Sum(STFI1) As STFI1,Sum(STFI2) As STFI2,
        Sum(STDV1) As STDV1,Sum(STDV2) As STDV2,
        Sum(STOCNV1C) As STOCNV1C,Sum(STOCNV2C) As STOCNV2C,
        Sum(STDV1C) As STDV1C,Sum(STDV2C) As STDV2C,
        Sum(StPedNVIUd1) As StPedNVIUd1,Sum(StPedNVIUd2) As StPedNVIUd2,
        Sum(StTransitoUd1) As StTransitoUd1,Sum(StTransitoUd2) As StTransitoUd2,
        Sum(STTR1) As STTR1,Sum(STTR2) As STTR2
Into #Paso1
From #Paso
Group By Codigo_Nodo_Madre

Select * From #Paso1
Order by Codigo_Nodo_Madre


UPDATE #TablaPaso#

SET 

StockUd1_Prod = Round(STFI1,2),
StockUd2_Prod = Round(STFI2,2),
Stock_Fisico_Ud1_Prod = Round(STFI1,2),
Stock_Fisico_Ud2_Prod = Round(STFI2,2),
Stock_Devengado_Ud1 = Round(STDV1,2),
Stock_Devengado_Ud2 = Round(STDV2,2),
StockPedidoUd1_Prod = Round(STOCNV1C,2),
StockPedidoUd2_Prod = Round(STOCNV2C,2),
StockFacSinRecepUd1_Prod = Round(STDV1C,2),
StockFacSinRecepUd2_Prod = Round(STDV2C,2),
StockPedidoNVIUd1_Prod = Round(StPedNVIUd1,2),
StockPedidoNVIUd2_Prod = Round(StPedNVIUd2,2),
StockTransitoUd1_Prod = Round(StTransitoUd1,2),
StockTransitoUd2_Prod = Round(StTransitoUd1,2),
StockEnTransitoUd1_Prod = Round(STTR1,2),
StockEnTransitoUd2_Prod = Round(STTR2,2)

From #Paso 
Inner Join #TablaPaso# Ztbl On Ztbl.Codigo = #Paso.KOPR


UPDATE #TablaPaso#

SET 

StockUd1 = Round(STFI1,2),
StockUd2 = Round(STFI2,2),
Stock_Fisico_Ud1 = Round(STFI1,2),
Stock_Fisico_Ud2 = Round(STFI2,2),
StockPedidoUd1 = Round(STOCNV1C,2),
StockPedidoUd2 = Round(STOCNV2C,2),
Stock_Devengado_Ud1 = Round(STDV1,2),
Stock_Devengado_Ud2 = Round(STDV2,2),
StockFacSinRecepUd1 = Round(STDV1C,2),
StockFacSinRecepUd2 = Round(STDV2C,2),
StockPedidoNVIUd1 = Round(StPedNVIUd1,2),
StockPedidoNVIUd2 = Round(StPedNVIUd2,2),
StockTransitoUd1 = Round(StTransitoUd1,2),
StockTransitoUd2 = Round(StTransitoUd2,2),
StockEnTransitoUd1 = Round(STTR1,2),
StockEnTransitoUd2 = Round(STTR2,2)

From #Paso1 
Inner Join #TablaPaso# Ztbl On Ztbl.Codigo_Nodo_Madre = #Paso1.Codigo_Nodo_Madre


Drop Table #Paso
Drop Table #Paso1

