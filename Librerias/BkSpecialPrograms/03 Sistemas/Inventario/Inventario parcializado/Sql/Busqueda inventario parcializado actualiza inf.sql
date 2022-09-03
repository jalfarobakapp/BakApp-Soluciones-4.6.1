
Declare @Empresa char(2),
        @Sucursal Char(3),
		@Bodega Char(3)

Select @Empresa  = '#Empresa',
       @Sucursal = '#Sucursal',
       @Bodega   = '#Bodega'

INSERT INTO TblMaeprPaso (KOPR,NOKOPR,OCULTO)
SELECT KOPR,NOKOPR,ATPR FROM MAEPR
WHERE KOPR NOT IN (SELECT KOPR FROM TblMaeprPaso)

UPDATE TblMaeprPaso SET CONTADO = 'Invantariado' 
WHERE KOPR IN (SELECT CodigoPr FROM Zw_TmpInv_InvParcial
Where Empresa = @Empresa And Sucursal = @Sucursal And Bodega = @Bodega And DejaStockCero = 0)

UPDATE TblMaeprPaso SET STOCK = dbo.MAEST.STFI1
FROM         dbo.TblMaeprPaso LEFT OUTER JOIN
                      dbo.MAEST ON dbo.TblMaeprPaso.KOPR = dbo.MAEST.KOPR
WHERE     (dbo.MAEST.EMPRESA = @Empresa) AND (dbo.MAEST.KOSU = @Sucursal) AND (dbo.MAEST.KOBO = @Bodega)