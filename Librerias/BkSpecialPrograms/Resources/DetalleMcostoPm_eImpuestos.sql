Declare @Ila Float, @Codigo Char(13)

IF EXISTS (SELECT * FROM sysobjects WHERE name='#TablaPaso#') BEGIN
DROP TABLE #TablaPaso#
END

Set @Codigo = '#Codigo#'

Set @Ila = (SELECT    SUM(ISNULL(dbo.TABIM.POIM, 0)) AS Impuestos
             FROM         dbo.MAEPR LEFT OUTER JOIN
                          dbo.TABIMPR ON dbo.MAEPR.KOPR = dbo.TABIMPR.KOPR LEFT OUTER JOIN
                          dbo.TABIM ON dbo.TABIMPR.KOIM = dbo.TABIM.KOIM
             GROUP BY dbo.MAEPR.KOPR, dbo.MAEPR.NOKOPR
             HAVING      (dbo.MAEPR.KOPR = @Codigo))
			 
SELECT      ISNULL(dbo.MAEPR.NOKOPR, 0) AS 'NOKOPR', 
            ISNULL(dbo.MAEPREM.PM, 0) AS 'PM', 
			ISNULL(dbo.MAEPREM.PPUL01, 0) AS 'PUL', 
              CASE 
			   WHEN ISNULL(dbo.MAEPREM.PPUL01, 0) > ISNULL(dbo.MAEPREM.PM, 0) THEN ISNULL(dbo.MAEPREM.PPUL01, 0) 
			   ELSE ISNULL(dbo.MAEPREM.PM, 0) END AS 'MCOSTO', 
			ISNULL(dbo.MAEPR.RLUD, 0) AS 'RLUD', 
			ISNULL(dbo.MAEPR.UD01PR, 0) AS 'UD01PR', 
			ISNULL(dbo.MAEPR.UD02PR, 0) AS 'UD02PR', 
            ISNULL(dbo.MAEPR.POIVPR,0)/100 AS 'IVAFORM', 
			@Ila/100 AS 'ILAVALOR', 
			ISNULL(dbo.MAEPR.POIVPR+@Ila,0)/100 AS 'TotalImpuestos'
			Into #TablaPaso#
FROM         dbo.MAEPR LEFT OUTER JOIN
                      dbo.MAEPREM ON dbo.MAEPR.KOPR = dbo.MAEPREM.KOPR
WHERE     (dbo.MAEPR.KOPR = @Codigo)			 

--,ISNULL(dbo.PDIMEN.ILAVALOR/100,0) AS ILAVALOR, 
-- ISNULL((dbo.PDIMEN.ILAVALOR + dbo.PDIMEN.IVAFORM)/100,0) AS TotalImpuestos 