Declare @FechaInv date = '#Fecha#'

SELECT    CodigoPr AS 'Codigo',
          Descripcion as 'Descripcion',
          Rtu as 'Rtu', 
          ConsolidStockUd1*-1 AS 'Cantidad',
          CostoUnitUd1 as 'Precio',
          (Select top 1 POIVPR from MAEPR Where KOPR = CodigoPr) as 'Iva',
          0 as 'Ila',
          0 AS 'Prct',
          '' as 'Tict',
          (Select top 1 TIPR from MAEPR Where KOPR = CodigoPr) as 'Tipr',
          1 as 'EsNeto',
          'GRI' as 'Tido', 
          '' as 'Lista',
          Sucursal as 'Sucursal',
          Bodega as 'Bodega',
          1 as 'UdTrans',
          (Select top 1 UD01PR from MAEPR Where KOPR = CodigoPr) as 'UnTrans',
          (Select top 1 UD01PR from MAEPR Where KOPR = CodigoPr) as 'Ud1Linea',
          (Select top 1 UD02PR from MAEPR Where KOPR = CodigoPr) as 'Ud2Linea'
 FROM  dbo.Zw_TmpInv_InvParcial
 Where Levantado = 0 and FechaInv = @FechaInv
 #Filtro#--and ConsolidStockUd1 < 0
 

