
Update TblPasoRanking set Clasificacion = 'Pro-Presencia' 
Where Top_Presencia = 'X' and Top_Margen = '' And Top_Precio = '' and Top_Cantidad = ''


Update TblPasoRanking set Clasificacion = 'Margen' 
Where Top_Margen = 'X' And Top_Presencia = ''

Update TblPasoRanking set Clasificacion = 'Ventas' 
Where Top_Precio = 'X' 
and Clasificacion <> 'Pro-Margen' And Top_Presencia = ''

Update TblPasoRanking set Clasificacion = 'Cantidad' 
Where Top_Cantidad = 'X'
and Clasificacion not in ('Pro-Margen','Pro-Ventas') And Top_Presencia = ''


Update TblPasoRanking set Clasificacion = 'Pro-Margen' 
Where Top_Presencia = 'X' and Top_Margen = 'X' 

Update TblPasoRanking set Clasificacion = 'Pro-Ventas' 
Where Top_Presencia = 'X' And Top_Precio = 'X' 
and Clasificacion <> 'Pro-Margen' 

Update TblPasoRanking set Clasificacion = 'Pro-Cantidad' 
Where Top_Presencia = 'X' and Top_Cantidad = 'X'
and Clasificacion not in ('Pro-Margen','Pro-Ventas')

Update TblPasoRanking set Clasificacion = 'Vip' 
Where Top_Presencia = 'X' and Top_Margen = 'X' And Top_Precio = 'X' and Top_Cantidad = 'X'

Update TblPasoRanking set Clasificacion = 'S/Rk' 
Where Clasificacion = ''
