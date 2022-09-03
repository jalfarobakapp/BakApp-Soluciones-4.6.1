
-- 'STOCK DESPACHADO SIN FACTURAR ************ DESPNOFAC1

BEGIN TRY
 DROP TABLE #INF_STOCK
 END TRY
 BEGIN CATCH
END CATCH

DECLARE 

@Empresa   Char(2),
@Sucursal  Char(3),
@Bodega    Char(3),
@Codigo    Char(13),
@Fecha  Date  

Select @Empresa  = '#Empresa#',
       @Sucursal = '#Sucursal#',
       @Bodega   = '#Bodega#', 
	   @Codigo   = '#@Codigo#',
	   @Fecha    = '#Fecha#'

SELECT D.KOPRCT,D.EMPRESA,E.TIDO,E.SUBTIDO,D.SULIDO,D.BOSULIDO,

	   D.CAPRCO1 - (D.CAPREX1 + D.CAPRAD1) AS 'CantidadUd1',
       D.CAPRCO2 - (D.CAPREX2 + D.CAPRAD2) AS 'CantidadUd2'

      Into #INF_STOCK        
       FROM MAEDDO AS D WITH ( NOLOCK )  
       INNER JOIN MAEEDO AS E ON E.IDMAEEDO=D.IDMAEEDO  
       WHERE D.PRCT=0 AND D.LILG IN ('SI','CR')  
             AND D.KOPRCT IN ( @Codigo ) 
             AND D.TIDO IN ('GDV')
             AND D.EMPRESA  =@Empresa 
             AND D.SULIDO   =@Sucursal
             AND D.BOSULIDO =@Bodega
             AND D.FEEMLI   <= @Fecha 

SELECT ISNULL(SUM(CantidadUd1),0) AS CantidadUd1,ISNULL(SUM(CantidadUd2),0) AS CantidadUd2 FROM #INF_STOCK

DROP TABLE #INF_STOCK       