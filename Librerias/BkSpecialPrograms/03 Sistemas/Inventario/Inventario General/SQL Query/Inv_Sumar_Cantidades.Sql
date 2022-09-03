
/*
SELECT     TOP (200) Semilla, Ano, Mes, Dia, IdBodega, CodEmpresa, CodSucursal, CodBodega, SemillaUbicacion, UbicacionBodega, Nro_Hoja, Item_Hoja, Fila, Columna, Ubic, 
                      CodigoLeidoArchTxt, Codproducto, Codrapido, Codtecnico, DescripcionProducto, CodBarras, FechaInventario, CantidadInventariada, Cantidad_Recontada, 
                      LC_Producto, PPP, PUC, PLCostoPR, VecesInventariado, Observaciones, Responsable, Nombre_Responzable, Contador, Contador_1, Contador_2, Recontado, 
                      Actualizado_por, Obs_Actualizacion
FROM         ZW_TmpInvProductosInventariados
*/
Declare @Empresa Char(2) = '#Empresa#',
        @Sucursal Char(3) = '#Sucursal#',
        @Bodega Char(3) = '#Bodega#',
        @FechaInv Date = '#FechaInv#'

SELECT     Codproducto, SUM(Case 
                                When Recontado = 0 then ISNULL(CantidadInventariada, 0)
                                When Recontado = 1 then ISNULL(Cantidad_Recontada, 0)
                            End) AS TotalInv
Into ZW_TmpInvPs01@Funcionario
FROM         dbo.ZW_TmpInvProductosInventariados

Where 
      CodEmpresa = @Empresa And 
      CodSucursal = @Sucursal And 
      CodBodega = @Bodega And 
      Fecha_Inventario_Gral = @FechaInv
GROUP BY Codproducto
/*
where 
      Ano = @Ano And 
      Mes = @Mes And 
      Dia = @Dia And 
      --Codproducto = '@Codigo' and 
      IdBodega =@IdBodega OR    
      Ano = @Ano And 
      Mes = @Mes And 
      Dia = @Dia And 
      --Codproducto >= '@Codigo' 
      --and 
      IdBodega =@IdBodega
GROUP BY Codproducto*/