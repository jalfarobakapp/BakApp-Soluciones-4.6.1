

INSERT INTO #Tbl_Paso# (Lista,Codigo,Descripcion,Rtu,Ud1,Ud2,Formula,Redondear,Costo,Precio,Margen,
                                  Margen_Adicional,Costo2,Precio2,Margen2,Margen_Adicional2,
                                  DsctoMax,Dscto1,Dscto2,Dscto3,Dscto4,Dscto5,Flete,CostoLt,LtCosto,Porc_Iva,Porc_Ila,
                                  ValoresNetos,Nuevo_Item)
SELECT Lista, 
       Codigo, 
       (Select top 1 NOKOPR from MAEPR Where KOPR = Codigo) as Descripcion, 
       (Select top 1 RLUD from MAEPR Where KOPR = Codigo) as Rtu,
       (Select top 1 UD01PR from MAEPR Where KOPR = Codigo) as Ud1,
       (Select top 1 UD02PR from MAEPR Where KOPR = Codigo) as Ud2,
       Formula, 
       Redondear,
       Costo,
       Precio,
       Margen,
       Margen_Adicional,
       Costo2,
       Precio2,
       Margen2,
       Margen_Adicional2,
       DsctoMax, 
       Dscto1, 
       Dscto2, 
       Dscto3, 
       Dscto4, 
       Dscto5, 
       Flete,
Isnull((Select top 1 PP01UD From TABPRE 
WHERE KOPR = Codigo And KOLT =(Select Top 1 SUBSTRING(LISCOSTO,6,3) From MAEPR Where KOPR = Codigo)),0) as CostoLt,
(SELECT Top 1 SUBSTRING(LISCOSTO,6,3) From MAEPR Where KOPR = Codigo) as LtCosto,
(SELECT top 1 POIVPR FROM MAEPR WHERE KOPR = Codigo),
(SELECT SUM(ISNULL(dbo.TABIM.POIM, 0)) AS Impuestos
             FROM         dbo.MAEPR LEFT OUTER JOIN
                          dbo.TABIMPR ON dbo.MAEPR.KOPR = dbo.TABIMPR.KOPR LEFT OUTER JOIN
                          dbo.TABIM ON dbo.TABIMPR.KOIM = dbo.TABIM.KOIM
                          WHERE MAEPR.KOPR = Codigo
             GROUP BY dbo.MAEPR.KOPR),
(Select Top 1 ValoresNetos From Zw_ListaPreGlobal Where Lista IN '#Lista#'),0          
FROM Zw_ListaPreProducto
Where Lista In '#Lista#'
#Filtro#
AND Codigo not in (Select Codigo From #Tbl_Paso#)

/*
Update #Tbl_Paso# Set 
                       Rubro = Isnull(dbo.TABRU.NOKORU,''),
                       Marca =Isnull(dbo.TABMR.NOKOMR,''),
                       Zona = Isnull(dbo.TABZO.NOKOZO,''),
                       SuperFamilia = Isnull(dbo.TABFM.NOKOFM,''),
                       Familia = Isnull(dbo.TABPF.NOKOPF,''),
                       SubFamilia = Isnull(dbo.TABHF.NOKOHF,''),
                       ClasLibre = Isnull(dbo.TABCARAC.NOKOCARAC,'')
FROM         dbo.TABZO RIGHT OUTER JOIN
                      dbo.TABFM RIGHT OUTER JOIN
                      dbo.MAEPR RIGHT OUTER JOIN
                      #Tbl_Paso# ON dbo.MAEPR.KOPR = #Tbl_Paso#.Codigo LEFT OUTER JOIN
                      dbo.TABHF ON dbo.MAEPR.FMPR = dbo.TABHF.KOFM AND dbo.MAEPR.PFPR = dbo.TABHF.KOPF AND dbo.MAEPR.HFPR = dbo.TABHF.KOHF LEFT OUTER JOIN
                      dbo.TABPF ON dbo.MAEPR.FMPR = dbo.TABPF.KOFM AND dbo.MAEPR.PFPR = dbo.TABPF.KOPF ON dbo.TABFM.KOFM = dbo.MAEPR.FMPR LEFT OUTER JOIN
                      dbo.TABCARAC ON dbo.MAEPR.CLALIBPR = dbo.TABCARAC.KOCARAC ON dbo.TABZO.KOZO = dbo.MAEPR.ZONAPR LEFT OUTER JOIN
                      dbo.TABMR ON dbo.MAEPR.MRPR = dbo.TABMR.KOMR LEFT OUTER JOIN
                      dbo.TABRU ON dbo.MAEPR.RUPR = dbo.TABRU.KORU
                    
 
Update #Tbl_Paso# Set Impuestos = Porc_Iva+Porc_Ila

*/  





