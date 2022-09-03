/*
CREATE TABLE [dbo].[#TablaPaso#](
    [Estado]               [Bit]          Default (0), 
    [Tipr]                 [Varchar](3)   Default '',
	[Nro_Serie]            [varchar](20)  Default '',
	[Codproducto]          [char](13)     Default '',
	[Codrapido]            [varchar](6)   Default '',
	[Codtecnico]           [varchar](20)  Default '',
	[Descripcion]          [varchar](50)  Default '',
	[CodBarras]            [varchar](20)  Default '',
	[FStock_Ud1]           [float]        Default (0),
	[Cantidad_Inv]         [float]        Default (0),
	[Recontado]            [Bit]          Default (0),
	[Cerrado]              [Bit]          Default (0),
	[Levantado]            [Bit]          Default (0),
	[Dif_Inv_Cantidad]     [float]        Default (0),
	[Dif_Inv_Costo]        [float]        Default (0),
	[PPP]                  [float]        Default (0),
	[PUC]                  [float]        Default (0),
	[PLCostoPR]            [float]        Default (0),
	[Total_Costo_Foto]     [float]        Default (0),
	[Total_Costo_Inv]      [float]        Default (0),
	[Diferencia]           [varchar](20)  Default ''
	
	
) ON [PRIMARY]


select isnull((Select TOP 1 TotalInv From ZW_TmpInvPs01ZBK where Codproducto = Zi_.CodigoPR),0) ,*
from ZW_TmpInvFotoInventario Zi_
*/
Declare @IdInventario Int = #IdInventario#
         
Update ZW_TmpInvFotoInventario 
Set Cant_Inventariada =  Isnull((Select TOP 1 TotalInv 
                                 From #TablaPaso_2# where Codproducto = CodigoPR),0)
Where IdInventario = @IdInventario                               
--Where (Ano = @Ano) AND (Mes = @Mes) AND (Dia = @Dia) AND (IdBodega = @IdBodega)                                 
                            
Update ZW_TmpInvFotoInventario Set 
                       Dif_Inv_Cantidad = Cant_Inventariada - StFisicoUd1,
                       Total_Costo_Foto = Case When StFisicoUd1 < 0 Then 0 Else StFisicoUd1 * PPP End,
                       Total_Costo_Inv = Cant_Inventariada * PPP
                       
Where 
      Tipr in ('FIN','FPN','FPS','FUN','FUS') And     
      IdInventario = @IdInventario                               
                        
Update ZW_TmpInvFotoInventario Set 
                       Dif_Inv_Costo = Total_Costo_Inv - Total_Costo_Foto                      
Where 
      Tipr in ('FIN','FPN','FPS','FUN','FUS') And     
      IdInventario = @IdInventario                               
            
Update ZW_TmpInvFotoInventario Set Diferencia = Case 
                                      When Dif_Inv_Cantidad < 0 Then 'Negativa'
                                      When Dif_Inv_Cantidad > 0 Then 'Positiva'
                                      When Dif_Inv_Cantidad = 0 Then ''
                                 End  
Where 
      Tipr in ('FIN','FPN','FPS','FUN','FUS') And     
      IdInventario = @IdInventario                               
                            
                                 
/*

Insert Into #TablaPaso# (Estado,Tipr,Codproducto,Codrapido,Codtecnico,Descripcion,FStock_Ud1,
                         Cantidad_Inv,Recontado,Cerrado,Levantado,PPP,PUC)
SELECT DISTINCT 
                      --  Foto.Semilla As 'Semilla', 
                      --'1' As 'Nro_Serie',
                      Foto.Estado As 'Estado',
                      (Select Top 1 TIPR From MAEPR Where KOPR = Foto.CodigoPR) as 'Tipr',
                      Foto.CodigoPR As 'CodProducto', 
					  Foto.CodigoRaPR As 'CodRapido', 
                      Foto.CodigoTePR As 'CodTecnico', 
					  Foto.DescripcionPR As 'Descripcion', 
					  ROUND(Case When Foto.StFisicoUd1 < 0 Then 0 Else Foto.StFisicoUd1 End, 2) AS 'FStock_Ud1', 
					  ISNULL(dbo.#TablaPaso_2#.TotalInv, 0.0000) AS 'Cantidad_Inv', 
					  Foto.Recontado as 'Recontado',
					  Foto.Cerrado as 'Cerrado',
					  Foto.Levantado as 'Levantado',
                      --(
                      -- Isnull(ROUND(Foto.StFisicoUd1, 2)) - 
                      -- ISNULL(dbo.#TablaPaso_2#.TotalInv, 0)
                      -- ) As 'Dif_Inv_Cantidad',
					  ROUND(Foto.PPP, 3) AS 'PPP', 
					  (Foto.PUltCompra*1.0000) As 'PUC'
					   
FROM   dbo.#TablaPaso_2# RIGHT OUTER JOIN
       dbo.ZW_TmpInvFotoInventario As Foto ON dbo.#TablaPaso_2#.Codproducto = Foto.CodigoPR
GROUP BY Foto.Semilla, Foto.CodigoRaPR, Foto.CodigoTePR, 
                      Foto.DescripcionPR, Foto.StFisicoUd1, Foto.PPP, 
                      Foto.PUltCompra, Foto.CodigoPR, Foto.IdBodega, 
                      dbo.#TablaPaso_2#.TotalInv,Foto.Ano,Foto.Mes,Foto.Dia,Foto.Estado,
                      Foto.Recontado,Foto.Cerrado,Foto.Levantado
HAVING               (Foto.Ano = @Ano) AND 
                     (Foto.Mes = @Mes) AND 
					 (Foto.Dia = @Dia) AND 
					 (Foto.IdBodega = @IdBodega) OR
					 -- AND (Foto.CodigoPR = '') 
					 (Foto.Ano = @Ano) AND 
                     (Foto.Mes = @Mes) AND 
					 (Foto.Dia = @Dia) AND 
					 (Foto.IdBodega = @IdBodega) 
					 -- AND (Foto.CodigoPR >= '')

Update #TablaPaso# Set Dif_Inv_Cantidad = Cantidad_Inv - FStock_Ud1,
                       Total_Costo_Foto = Case When FStock_Ud1 < 0 Then 0 Else FStock_Ud1 End * PPP,
                       Total_Costo_Inv = Cantidad_Inv * PPP
Where Tipr in ('FIN','FPN','FPS','FUN','FUS')                       
                        
Update #TablaPaso# Set Dif_Inv_Costo = Total_Costo_Inv - Total_Costo_Foto                      
Where Tipr in ('FIN','FPN','FPS','FUN','FUS')     

Update #TablaPaso# Set Diferencia = Case 
                                      When Dif_Inv_Cantidad < 0 Then 'Negativa'
                                      When Dif_Inv_Cantidad > 0 Then 'Positiva'
                                      When Dif_Inv_Cantidad = 0 Then ''
                                 End     
                                      

--Delete #TablaPaso# 
--Where Codproducto                        
--In (Select KOPR FROM MAEPR Where TIPR In ('','',''))                                 
    */                             