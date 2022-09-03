
Insert into Zw_ProdRanking 
            (Codigo, Descripcion, Puntos_Rk, Ranking_Top, Rk_Presencia, Rk_Cantidad, Rk_Precio, Rk_Margen, 
             Bv, Fv, Gv, Nc, Otro, Presencia, Top_Ranking,Top_Presencia, Top_Cantidad, Top_Precio, Top_Margen, 
             Cod_Clas, Clasificacion, Pc_Ranking, Pc_Presencia, Pc_Cantidad, Pc_Precio, Pc_Margen, TotalCosto, 
             TotalPrecio, TotalCantid, Total_Mrg, Porc_Markup, Porc_Margen)

Select       Codigo, Descripcion, Puntos_Rk, Ranking_Top, Rk_Presencia, Rk_Cantidad, Rk_Precio, Rk_Margen, 
             Bv, Fv, Gv, Nc, Otro, Presencia, Top_Ranking,Top_Presencia, Top_Cantidad, Top_Precio, Top_Margen, 
             Cod_Clas, Clasificacion, Pc_Ranking, Pc_Presencia, Pc_Cantidad, Pc_Precio, Pc_Margen, TotalCosto, 
             TotalPrecio, TotalCantid, Total_Mrg, Porc_Markup, Porc_Margen      
From TblPasoRanking             

--Select KOPR,CLALIBPR,MRPR,RUPR,ZONAPR,FMPR INTO RESP_CLASS FROM MAEPR 

--Update MAEPR SET Campo_Clas = ''
--Update MAEPR SET Campo_Clas = (Select top 1 Cod_Clas From Zw_ProdRanking  Where KOPR = Codigo ) 