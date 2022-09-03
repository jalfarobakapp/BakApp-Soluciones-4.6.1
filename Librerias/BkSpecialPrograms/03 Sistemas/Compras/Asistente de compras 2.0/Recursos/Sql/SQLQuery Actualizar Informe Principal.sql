        
Update  #TablaPaso# Set  Bloqueapr = (Select top 1 BLOQUEAPR From MAEPR Where KOPR = #TablaPaso#.Codigo)

Select *         
From #TablaPaso#
Where 1 > 0
#Condicion#
Order By #Campo_Orden1# 


--SELECT KOPRCT As Codigo,
--	   ISNULL(MAEDDO_1.IDMAEDDO,0) AS IDMAEDDO,
--       ISNULL(MAEDDO_1.IDMAEEDO,0) AS IDMAEEDO,
--       CASE TIDO 
--			When 'OCC' Then 'Ult. Doc. por recepcionar'
--			When 'GRC' Then 'Ultima recepción' 
--			When 'GDD' Then 'Ultima devolución' 
--	   END AS Obs, 
--       ISNULL(MAEDDO_1.TIDO,'') AS Tipo,
--       ISNULL(MAEDDO_1.NUDO,'') AS Numero, 
--       ISNULL(dbo.MAEEN.NOKOEN,'') AS Razon, 
--       ISNULL((Select top 1 NOKOEN From MAEEN Where KOEN = MAEDDO_1.ENDOFI),'') as EntFisica, 
--       ISNULL(MAEDDO_1.FEEMLI,'') AS Fecha, 
--       ISNULL(MAEDDO_1.CAPRCO1,'') AS CantUd1, 
--       ISNULL(MAEDDO_1.UD01PR,'') AS Un1, 
--       ISNULL(MAEDDO_1.CAPRCO2,'') AS CantUd2, 
--       ISNULL(MAEDDO_1.UD02PR,'') AS Un2 
--FROM         dbo.MAEDDO AS MAEDDO_1 LEFT OUTER JOIN
--dbo.MAEEN ON MAEDDO_1.ENDO = dbo.MAEEN.KOEN AND MAEDDO_1.SUENDO = dbo.MAEEN.SUEN
--WHERE MAEDDO_1.IDMAEDDO In (Select IdOCC From #TablaPaso# --Where Codigo = KOPRCT
--                            Union
--                            Select IdGRC From #TablaPaso# --Where Codigo = KOPRCT
--                            Union
--                            Select IdGDD From #TablaPaso# )--Where Codigo = KOPRCT)
--And KOPRCT In (Select Codigo From #OldTablaPaso# Where 1 > 0 #OldCondicion#)                            
--Order By Codigo  

        
	            

                
                