DECLARE 

@Empresa   Char(2),
@Sucursal  Char(3),
@Bodega    Char(3),
@Codigo    Char(13),
@Orden     Int,
@StockUd1  Float,
@StockUd2  Float,
@Fecha  Date  

Select @Empresa  = '#Empresa#',
       @Sucursal = '#Sucursal#',
       @Bodega   = '#Bodega#', 
	   @Codigo   = '#@Codigo#',
	   @Fecha    = '#Fecha#'

SELECT D.KOPRCT,D.EMPRESA,E.TIDO,E.SUBTIDO,D.SULIDO,D.BOSULIDO,
        CASE  
             WHEN E.TIDO IN ('FCV','FVX','FDV','BLV','NCC')       THEN SUM(D.CAPRAD1) * -1
             WHEN E.TIDO IN ('GRI','GRC','GRD','GRP')             THEN SUM(D.CAPRCO1)
             WHEN E.TIDO IN ('NCV','FCC','FCT','BLC','NCX','FDC') THEN SUM(D.CAPRAD1)
             WHEN E.TIDO IN ('GDV','GTI','GDI','GDP','GDD')       THEN SUM(D.CAPRCO1) * -1
             WHEN E.TIDO IN ('GAR') THEN SUM(D.CAPRAD1)
       END AS 'CantidadUd1',
       CASE  
             WHEN E.TIDO IN ('FCV','FVX','FDV','BLV','NCC')       THEN SUM(D.CAPRAD2) * -1
             WHEN E.TIDO IN ('GRI','GRC','GRD','GRP')             THEN SUM(D.CAPRCO2)
             WHEN E.TIDO IN ('NCV','FCC','FCT','BLC','NCX','FDC') THEN SUM(D.CAPRAD2)
             WHEN E.TIDO IN ('GDV','GTI','GDI','GDP','GDD')       THEN SUM(D.CAPRCO2) * -1
             WHEN E.TIDO IN ('GAR') THEN SUM(D.CAPRAD2) 
      END AS 'CantidadUd2'
      Into Zw_TblStockConsolid        
       FROM MAEDDO AS D WITH ( NOLOCK )  
       INNER JOIN MAEEDO AS E ON E.IDMAEEDO=D.IDMAEEDO  
       WHERE D.PRCT=0 AND D.LILG IN ('SI','CR')  
             AND D.KOPRCT IN ( @Codigo ) 
             AND D.TIDO NOT IN ('COV','OCC','NVV','NVI','OCI')
             AND D.EMPRESA  =@Empresa 
             AND D.SULIDO   =@Sucursal
             AND D.BOSULIDO =@Bodega
             AND D.FEEMLI   <= @Fecha 
GROUP BY D.KOPRCT,D.EMPRESA,E.TIDO,E.SUBTIDO,D.SULIDO,D.BOSULIDO 

SELECT ISNULL(SUM(CantidadUd1),0) AS CantidadUd1,ISNULL(SUM(CantidadUd2),0) AS CantidadUd2 FROM Zw_TblStockConsolid

          