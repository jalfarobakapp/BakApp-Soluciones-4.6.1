
Declare @Proveedor    Char(10) = '#Proveedor#',
        @SucProveedor Char(10) = '#SucProveedor#',
        @Lista        Char(3)  = '#Lista#' 

INSERT INTO #Tbl_Paso# (Lista,Codigo,CodAlternativo,Descripcion,Descripcion_Alt,Rtu,Ud1,Ud2,CostoUd1,CostoUd2,FechaVigencia,
                                  Desc1,Desc2,Desc3,Desc4,Desc5,Flete,Nuevo_Item)
SELECT Lista, 
       Codigo, 
       CodAlternativo,
       ISNULL((Select top 1 NOKOPR from MAEPR Where KOPR = Codigo),'NO EXITE') as Descripcion, 
       ISNULL(Descripcion_Alt,'') AS Descripcion_Alt,
       ISNULL((Select top 1 RLUD from MAEPR Where KOPR = Codigo),1) as Rtu,
       ISNULL((Select top 1 UD01PR from MAEPR Where KOPR = Codigo),'UN') as Ud1,
       ISNULL((Select top 1 UD02PR from MAEPR Where KOPR = Codigo),'UN') as Ud2,
       CostoUd1,
       CostoUd2,
       FechaVigencia, 
       Desc1, 
       Desc2, 
       Desc3, 
       Desc4, 
       Desc5, 
       Flete,
       0,
FROM Zw_ListaPreCosto
Where Lista = @Lista And Proveedor = @Proveedor --And Sucursal = @SucProveedor 
#Filtro#
AND Codigo not in (Select Codigo From #Tbl_Paso#)


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
                      








