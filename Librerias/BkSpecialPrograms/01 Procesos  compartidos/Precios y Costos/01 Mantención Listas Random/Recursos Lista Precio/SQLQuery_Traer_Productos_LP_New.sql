--Zw_PsLp#Funcionario#

Insert Into #Tbl_Paso_LP# (KOLT,KOPR,KOPRRA,KOPRTE,ECUACION,FEVI,RLUD,PP01UD,MG01UD,DTMA01UD,PP02UD,
                           MG02UD,DTMA02UD,PPUL01,PPUL02,PM01,PM02,C_INSUMOS,C_MAQUINAS,C_M_OBRA,
                           C_FABRIC,C_COMPRA,C_LIBRE,ECUACIONU2,EMG01UD,EMG02UD,EDTMA01UD,EDTMA02UD,
					       FMPR,PFPR,HFPR,MRPR,RUPR,NOKOPR,UD01PR,UD02PR,IVA,Codigo#Otros_Campos1#)
					  
SELECT Tp.KOLT,Tp.KOPR,Tp.KOPRRA,Tp.KOPRTE,Isnull(Tp.ECUACION,''),Tp.FEVI,Isnull(Tp.RLUD,Mp.RLUD),Isnull(Tp.PP01UD,0),Isnull(Tp.MG01UD,0),
       Isnull(Tp.DTMA01UD,0),Isnull(Tp.PP02UD,0),Isnull(Tp.MG02UD,0),Isnull(Tp.DTMA02UD,0),Isnull(Tp.PPUL01,0),Isnull(Tp.PPUL02,0),
       Isnull(Tp.PM01,0),Isnull(Tp.PM02,0),Isnull(Tp.C_INSUMOS,0),Isnull(Tp.C_MAQUINAS,0),Isnull(Tp.C_M_OBRA,0),Isnull(Tp.C_FABRIC,0),
       Isnull(Tp.C_COMPRA,0),Isnull(Tp.C_LIBRE,0),Isnull(Tp.ECUACIONU2,''),
       Isnull(Tp.EMG01UD,0),Isnull(Tp.EMG02UD,0),Isnull(Tp.EDTMA01UD,0),
       Isnull(Tp.EDTMA02UD,0),Mp.FMPR,Mp.PFPR,Mp.HFPR,Mp.MRPR,
       Mp.RUPR,Mp.NOKOPR,Mp.UD01PR,Mp.UD02PR,Mp.POIVPR,Tp.KOPR
       #Otros_Campos2#
					  
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
                     
					  
