DECLARE 
@NroGRI         Char(10),
@NroGDI         Char(10),
@FechaInv       Date,
@ListaCosto     Char(3),
@Modalidad      Char(3),
@Empresa        Char(2),
@Sucursal       Char(3),
@Endo           Char(13),
@Funcionario    Char(3),
@Caprco         Float,
@Vaivdo         Float,
@Vanedo         Float,
@Vabrdo         Float,
@Observaciones  Varchar(100)


Set @Modalidad     = '#Modalidad#'
Set @Empresa       = '#Empresa#'
Set @Sucursal      = '#Sucursal#'  
Set @NroGRI        = '#NroGRI#'
Set @NroGDI        = '#NroGDI#'
Set @FechaInv      = '#FechaInv#'
Set @ListaCosto    = '#ListaCosto#'
Set @Funcionario   = '#Funcionario#'
Set @Caprco        = 0
Set @Vaivdo        = 0
Set @Vanedo        = 0
Set @Vabrdo        = 0
Set @Observaciones = '#Observaciones#'


Set @Endo    = (SELECT RUT FROM CONFIGP WHERE EMPRESA=@Empresa )


Set @Caprco     = (Select Isnull(Sum(ConsolidStockUd1*-1),0) AS CAPRCO
                   FROM  dbo.Zw_TmpInv_InvParcial
                   Where Levantado = 0 and FechaInv = @FechaInv
                   and ConsolidStockUd1 < 0)

Set @Vanedo     = (Select Isnull(Sum((ConsolidStockUd1*(CostoUnitUd1*-1))),0) AS VANELI
                   FROM  dbo.Zw_TmpInv_InvParcial
                   Where Levantado = 0 and FechaInv = @FechaInv
                   and ConsolidStockUd1 < 0)
				 
Set @Vaivdo = @Vanedo * 0.19				 
Set @Vabrdo = Round(@Vanedo + @Vaivdo,0)


IF @Caprco > 0 Begin
 INSERT INTO x_maeedo 
             (MODALIDAD, EMPRESA, TIDO, NUDO, ENDO, SUENDO, SUDO, FEEMDO, KOFUDO, CAPRCO, VAIVDO, VANEDO, VABRDO, FEER, OBDO) Values 
			 (@Modalidad,@Empresa,'GRI',@NroGRI,@Endo,'',@Sucursal,@FechaInv,@Funcionario,@Caprco,@Vaivdo,@Vanedo,@Vabrdo,@FechaInv,@Observaciones)
			 

 INSERT INTO dbo.x_maeddo (TIDO, NUDO, NULIDO, BOSULIDO, KOPRCT, UDTRPR, CAPRCO1, CAPRCO2, KOLTPR, NUDTLI, PPPRNELT, PPPRNE, PPPRBRLT, PPPRBR, PPPRNERE1, 
                         PPPRNERE2, POIMGLLI, VAIMLI, PODTGLLI, VADTNELI, POIVLI, VAIVLI, VANELI, VABRLI, LINCONDESP)

 SELECT    'GRI' AS TIDO,
           @NroGRI AS NUDO,
           '' AS NULIDO,
           Bodega AS BOSULIDO,
           CodigoPr AS KOPRCT,
           1 AS UDTRPR,
           ConsolidStockUd1*-1 AS CAPRCO1,
           ConsolidStockUd2*-1 AS CAPRCO2,
           @ListaCosto AS KOLTPR,
           0 AS NUDTLI,
           CostoUnitUd1 AS PPPRNELT,
           CostoUnitUd1 AS PPPRNE,
           ROUND(CostoUnitUd1*1.19,0) AS PPPRBRLT,
           ROUND(CostoUnitUd1*1.19,0) AS PPPRBR,
           CostoUnitUd1 AS PPPRNERE1, 
           CostoUnitUd2 AS PPPRNERE2,
           0 AS POIMGLLI,
           0 AS VAIMLI,
           0 AS PODTGLLI,
           0 AS VADNELI,
           19 AS POIVLI,
    (ConsolidStockUd1*(CostoUnitUd1*-1))*0.19 AS VAIVLI,
           (ConsolidStockUd1*(CostoUnitUd1*-1)) AS VANELI,
 ROUND((ConsolidStockUd1*(CostoUnitUd1*-1))*1.19,0) AS VABRLI,
           1 AS LINCONDESP
                   --   StockActual, FechaInv, HoraInv, ConsolidStockUd1, ConsolidStockUd2, IDMAEDDO, Levantado, Orden
 FROM  dbo.Zw_TmpInv_InvParcial
 Where Levantado = 0 and FechaInv = @FechaInv
 and ConsolidStockUd1 < 0
End


Set @Caprco        = 0
Set @Vaivdo        = 0
Set @Vanedo        = 0
Set @Vabrdo        = 0

Set @Caprco     = (Select Isnull(Sum(ConsolidStockUd1),0) AS CAPRCO
                   FROM  dbo.Zw_TmpInv_InvParcial
                   Where Levantado = 0 and FechaInv = @FechaInv
                   and ConsolidStockUd1 > 0)

Set @Vanedo     = (Select Isnull(Sum((ConsolidStockUd1*(CostoUnitUd1))),0) AS VANELI
                   FROM  dbo.Zw_TmpInv_InvParcial
                   Where Levantado = 0 and FechaInv = @FechaInv
                   and ConsolidStockUd1 > 0)
				 
Set @Vaivdo = @Vanedo * 0.19				 
Set @Vabrdo = Round(@Vanedo + @Vaivdo,0)


IF @Caprco > 0 Begin
 INSERT INTO x_maeedo 
             (MODALIDAD, EMPRESA, TIDO, NUDO, ENDO, SUENDO, SUDO, FEEMDO, KOFUDO, CAPRCO, VAIVDO, VANEDO, VABRDO, FEER, OBDO) Values 
			 (@Modalidad,@Empresa,'GDI',@NroGDI,@Endo,'',@Sucursal,@FechaInv,@Funcionario,@Caprco,@Vaivdo,@Vanedo,@Vabrdo,@FechaInv,@Observaciones)



 INSERT INTO dbo.x_maeddo (TIDO, NUDO, NULIDO, BOSULIDO, KOPRCT, UDTRPR, CAPRCO1, CAPRCO2, KOLTPR, NUDTLI, PPPRNELT, PPPRNE, PPPRBRLT, PPPRBR, PPPRNERE1, 
                         PPPRNERE2, POIMGLLI, VAIMLI, PODTGLLI, VADTNELI, POIVLI, VAIVLI, VANELI, VABRLI, LINCONDESP)
 SELECT     'GDI' AS TIDO,
           @NroGDI AS NUDO,
           '' AS NULIDO,
           Bodega AS BOSULIDO,
           CodigoPr AS KOPRCT,
           1 AS UDTRPR,
           ConsolidStockUd1 AS CAPRCO1,
           ConsolidStockUd2 AS CAPRCO2,
           '02C' AS KOLTPR,
           0 AS NUDTLI,
           CostoUnitUd1 AS PPPRNELT,
           CostoUnitUd1 AS PPPRNE,
           ROUND(CostoUnitUd1*1.19,0) AS PPPRBRLT,
           ROUND(CostoUnitUd1*1.19,0) AS PPPRBR,
           CostoUnitUd1 AS PPPRNERE1, 
           CostoUnitUd2 AS PPPRNERE2,
           0 AS POIMGLLI,
           0 AS VAIMLI,
           0 AS PODTGLLI,
           0 AS VADNELI,
           19 AS POIVLI,
    (ConsolidStockUd1*(CostoUnitUd1))*0.19 AS VAIVLI,
           (ConsolidStockUd1*(CostoUnitUd1)) AS VANELI,
 ROUND((ConsolidStockUd1*(CostoUnitUd1))*1.19,0) AS VABRLI,
           1 AS LINCONDESP
                   --   StockActual, FechaInv, HoraInv, ConsolidStockUd1, ConsolidStockUd2, IDMAEDDO, Levantado, Orden
 FROM  dbo.Zw_TmpInv_InvParcial
 Where Levantado = 0 and FechaInv = @FechaInv
 and ConsolidStockUd1 > 0
End



/*

SELECT     TIDO, NUDO, NULIDO, BOSULIDO, KOPRCT, UDTRPR, CAPRCO1, CAPRCO2, KOLTPR, NUDTLI, PPPRNELT, PPPRNE, PPPRBRLT, PPPRBR, PPPRNERE1, 
                      PPPRNERE2, POIMGLLI, VAIMLI, PODTGLLI, VADTNELI, POIVLI, VAIVLI, VANELI, VABRLI, LINCONDESP
FROM         dbo.x_maeddo
where TIDO IN ('GRI','GDI')
*/