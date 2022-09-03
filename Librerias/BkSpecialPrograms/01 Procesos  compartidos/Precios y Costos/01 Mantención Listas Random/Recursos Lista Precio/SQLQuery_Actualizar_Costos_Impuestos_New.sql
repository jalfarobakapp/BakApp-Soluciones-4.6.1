
Update #Tbl_Paso_LP# Set ILA = (SELECT SUM(ISNULL(dbo.TABIM.POIM, 0)) AS Impuestos
                     FROM         dbo.MAEPR LEFT OUTER JOIN
                                  dbo.TABIMPR ON dbo.MAEPR.KOPR = dbo.TABIMPR.KOPR LEFT OUTER JOIN
                                  dbo.TABIM ON dbo.TABIMPR.KOIM = dbo.TABIM.KOIM
                     WHERE MAEPR.KOPR = #Tbl_Paso_LP#.KOPR
                     GROUP BY dbo.MAEPR.KOPR)
                     
Update #Tbl_Paso_LP# Set PM01 = (Select Top 1 PM From MAEPREM Mp Where Mp.EMPRESA = '#Empresa#' And Mp.KOPR = #Tbl_Paso_LP#.KOPR)
Update #Tbl_Paso_LP# Set PPUL01 = (Select Top 1 PPUL01 From MAEPREM Mp Where Mp.EMPRESA = '#Empresa#' And Mp.KOPR = #Tbl_Paso_LP#.KOPR)
Update #Tbl_Paso_LP# Set PPUL02 = (Select Top 1 PPUL02 From MAEPREM Mp Where Mp.EMPRESA = '#Empresa#' And Mp.KOPR = #Tbl_Paso_LP#.KOPR)
Update #Tbl_Paso_LP# Set PMSUC = Isnull((Select Top 1 PMSUC From MAEPMSUC Mp 
											Where Mp.EMPRESA = '#Empresa#' And Mp.KOSU = '#Sucursal#' And Mp.KOPR = #Tbl_Paso_LP#.KOPR),0)
                      
Update #Tbl_Paso_LP# Set MELT = (Select Top 1 MELT From TABPP Z2 Where Z1.KOLT = Z2.KOLT)  
From #Tbl_Paso_LP# Z1                   
           
					  
