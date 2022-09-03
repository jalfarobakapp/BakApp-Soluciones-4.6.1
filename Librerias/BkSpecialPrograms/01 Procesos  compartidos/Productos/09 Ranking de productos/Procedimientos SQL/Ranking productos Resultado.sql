



Select 0 As Orden,'Presencia' As CodRanking_desc,'Presencia' As Presencia,
		Cast(80 as float) As PorcentMarcar,Cast(0 as float) As CantProdMarcados,Cast(0 as float) As PorcAcumuladoProd,
	    Cast('Indica si el producto esta dentro de los articulos que cumplen con la condición Pro-Presencia:
			  Cantidad de documentos que esta presente el producto marcado, es decir, la suma de Boletas, Facturas, 
              Guias (Sin facturar) y menos las Notas de credito que el producto se encuentra presente' As Varchar(1000)) As DescripRk
Union
Select 1 As Orden,'Margen' As CodRanking_desc,'Margen' As Presencia,
		Cast(80 as float) As PorcentMarcar,Cast(0 as float) As CantProdMarcados,Cast(0 as float) As PorcAcumuladoProd,
		Cast('Indica si el producto esta dentro de los articulos que cumplen con la condición Pro-Margen:
              % de margen según el margen total calculado entre todos los productos.
              Se marcaran solo como Pro-Margen aquellos productos que tengan la condicion Pro-Presencia' As Varchar(1000)) As DescripRk
Union
Select 2 As Orden,'Ventas' As CodRanking_desc,'Ventas' As Presencia,
		Cast(80 as float) As PorcentMarcar,Cast(0 as float) As CantProdMarcados,Cast(0 as float) As PorcAcumuladoProd,
		Cast('Indica si el producto esta dentro de los articulos que cumplen con la condición Pro-Ventas:
              Suma total del precio de venta del producto.
              Se marcaran solo como Pro-Ventas aquellos productos que tengan la condicion Pro-Presencia 
              y no tengan marcada la condición Pro_Margen' As Varchar(1000)) As DescripRk
Union
Select 3 As Orden,'Cantidad' As CodRanking_desc,'Cantidad' As Presencia,
		Cast(80 as float) As PorcentMarcar,Cast(0 as float) As CantProdMarcados,Cast(0 as float) As PorcAcumuladoProd,
		Cast('Indica si el producto esta dentro de los articulos que cumplen con la condición Pro-Cantidad:
              Suma total de la cantidad vendida por cada producto
              Se marcaran solo como Pro-Cantidad aquellos productos que tengan la condicion Pro-Presencia
              y no tengan marcada la condición Pro_Margen ni Pro_Ventas"' As Varchar(1000)) As DescripRk
Union
Select 3 As Orden,'Ranking Top' As CodRanking_desc,'Top' As Presencia,
		Cast(20 as float) As PorcentMarcar,Cast(0 as float) As CantProdMarcados,Cast(0 as float) As PorcAcumuladoProd,
		Cast('' As Varchar(1000)) As DescripRk
Order By Orden
