--Zw_PsLp#Funcionario#

Insert Into #Tbl_Paso_LP# (KOLT,KOPR,KOPRRA,KOPRTE,ECUACION,FEVI,RLUD,PP01UD,MG01UD,DTMA01UD,PP02UD,
                           MG02UD,DTMA02UD,PPUL01,PPUL02,PM01,PM02,C_INSUMOS,C_MAQUINAS,C_M_OBRA,
                           C_FABRIC,C_COMPRA,C_LIBRE,ECUACIONU2,EMG01UD,EMG02UD,EDTMA01UD,EDTMA02UD,
					       FMPR,PFPR,HFPR,MRPR,RUPR,NOKOPR,UD01PR,UD02PR,IVA,Codigo#Otros_Campos1#)
					  
SELECT                Tp.KOLT,Tp.KOPR,Tp.KOPRRA,Tp.KOPRTE,Tp.ECUACION,Tp.FEVI,Tp.RLUD,Tp.PP01UD,Tp.MG01UD,
                      Tp.DTMA01UD,Tp.PP02UD,Tp.MG02UD,Tp.DTMA02UD,Tp.PPUL01,Tp.PPUL02,Tp.PM01,Tp.PM02,
                      Tp.C_INSUMOS,Tp.C_MAQUINAS,Tp.C_M_OBRA,Tp.C_FABRIC,Tp.C_COMPRA,Tp.C_LIBRE,Tp.ECUACIONU2,
                      Tp.EMG01UD,Tp.EMG02UD,Tp.EDTMA01UD,Tp.EDTMA02UD,Mp.FMPR,Mp.PFPR,Mp.HFPR,Mp.MRPR,
                      Mp.RUPR,Mp.NOKOPR,Mp.UD01PR,Mp.UD02PR,Mp.POIVPR,Tp.KOPR#Otros_Campos2#
					  
FROM         dbo.TABPRE Tp LEFT OUTER JOIN
                      dbo.MAEPR Mp ON Tp.KOPR = Mp.KOPR
WHERE 1 > 0 
--Mp.KOPR In ()                      
#Filtro_Productos#					  
AND Tp.KOPR not in (Select KOPR From #Tbl_Paso_LP#)
AND Tp.KOLT In #Listas#


/*
Update #Tbl_Paso_LP# Set ILA = (SELECT SUM(ISNULL(dbo.TABIM.POIM, 0)) AS Impuestos
                     FROM         dbo.MAEPR LEFT OUTER JOIN
                                  dbo.TABIMPR ON dbo.MAEPR.KOPR = dbo.TABIMPR.KOPR LEFT OUTER JOIN
                                  dbo.TABIM ON dbo.TABIMPR.KOIM = dbo.TABIM.KOIM
                     WHERE MAEPR.KOPR = '#Codigo#'
                     GROUP BY dbo.MAEPR.KOPR)
                     
*/
                     
					  
