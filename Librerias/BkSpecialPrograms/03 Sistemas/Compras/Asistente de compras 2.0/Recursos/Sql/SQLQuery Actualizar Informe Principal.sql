
Update  #TablaPaso# Set  Bloqueapr = (Select top 1 BLOQUEAPR From MAEPR Where KOPR = #TablaPaso#.Codigo)

--#BloqueaProductosPorProveedor#

Select *         
From #TablaPaso#
Where 1 > 0
#Condicion#
Order By #Campo_Orden1# 



	            

                
                