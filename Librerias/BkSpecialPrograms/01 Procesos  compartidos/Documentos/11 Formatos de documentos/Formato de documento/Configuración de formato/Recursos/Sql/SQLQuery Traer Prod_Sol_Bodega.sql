

SELECT Id, CodSolicitud, Estado, Funcionario, 
       (Select NOKOFU From TABFU Where KOFU = Funcionario) As Nokofu,
       Codigo, Descripcion, 
       Empresa, Sucursal, Bodega, 
	   (Select Top 1 RAZON From CONFIGP Where EMPRESA = Empresa) as Razon,
	   (Select Top 1 NOKOSU From TABSU Where EMPRESA = Empresa And KOSU = Sucursal) As Nokosu,
	   (Select Top 1 NOKOBO From TABBO Where EMPRESA = Empresa And KOSU = Sucursal And KOBO = Bodega) As Nokobo,
	   Ubicacion, 
	   (Select Top 1 STFI1 From MAEST Where KOPR = Codigo And EMPRESA = Empresa And KOSU = Sucursal And KOBO = Bodega) As StockUd1,
	   (Select Top 1 STFI1 From MAEST Where KOPR = Codigo And EMPRESA = Empresa And KOSU = Sucursal And KOBO = Bodega) As StockUd2,
	   CONVERT(Date, FechaHora_Solicita) As Fecha,
	   CONVERT(VARCHAR, FechaHora_Solicita, 108) As Hora
FROM #Base_Bakapp#Zw_Prod_SolBodega 
WHERE Id = #Id# 