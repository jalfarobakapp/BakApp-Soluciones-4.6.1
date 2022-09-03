Select 
'Tot. Compras' as 'Concepto',
(Select Isnull(sum(#SumTotalQtyUd#),0) from #Tabla_de_Paso# 
Where Tipo = 'C'
And Fecha >= DATEADD(day, -1, GETDATE())) as 'Del Día',
(select Isnull(sum(#SumTotalQtyUd#),0) from #Tabla_de_Paso# 
Where Tipo = 'C'
And Fecha >= DATEADD(WEEK, -1, GETDATE())) as 'Ult.Semana',
(Select Isnull(sum(#SumTotalQtyUd#),0) from #Tabla_de_Paso# 
Where Tipo = 'C'
And Fecha >= DATEADD(DAY, -30, GETDATE())) as 'Ult.30 días',
(Select Isnull(sum(#SumTotalQtyUd#),0) from #Tabla_de_Paso# 
Where Tipo = 'C'
And Fecha >= DATEADD(DAY, -90, GETDATE())) as 'Ult.90 días',
(Select Isnull(sum(#SumTotalQtyUd#),0) from #Tabla_de_Paso# 
Where Tipo = 'C'
And Fecha >= DATEADD(MONTH, -6, GETDATE())) as 'Ult.6 Meses',
(select Isnull(sum(#SumTotalQtyUd#),0) from #Tabla_de_Paso# 
Where Tipo = 'C'
And Fecha >= DATEADD(MONTH, -12, GETDATE())) as 'Ult.12 Meses'
Union
Select
'Tot. Ventas' as 'Concepto',
(Select Isnull(sum(#SumTotalQtyUd#),0) from #Tabla_de_Paso# 
Where Tipo = 'V'
And Fecha >= DATEADD(day, -1, GETDATE())) as 'Del Día',
(select Isnull(sum(#SumTotalQtyUd#),0) from #Tabla_de_Paso# 
Where Tipo = 'V'
And Fecha >= DATEADD(WEEK, -1, GETDATE())) as 'Ult.Semana',
(Select Isnull(sum(#SumTotalQtyUd#),0) from #Tabla_de_Paso# 
Where Tipo = 'V'
And Fecha >= DATEADD(DAY, -30, GETDATE())) as 'Ult.30 días',
(Select Isnull(sum(#SumTotalQtyUd#),0) from #Tabla_de_Paso# 
Where Tipo = 'V'
And Fecha >= DATEADD(DAY, -90, GETDATE())) as 'Ult.90 días',
(Select Isnull(sum(#SumTotalQtyUd#),0) from #Tabla_de_Paso# 
Where Tipo = 'V'
And Fecha >= DATEADD(MONTH, -6, GETDATE())) as 'Ult.6 Meses',
(select Isnull(sum(#SumTotalQtyUd#),0) from #Tabla_de_Paso# 
Where Tipo = 'V'
And Fecha >= DATEADD(MONTH, -12, GETDATE())) as 'Ult.12 Meses'