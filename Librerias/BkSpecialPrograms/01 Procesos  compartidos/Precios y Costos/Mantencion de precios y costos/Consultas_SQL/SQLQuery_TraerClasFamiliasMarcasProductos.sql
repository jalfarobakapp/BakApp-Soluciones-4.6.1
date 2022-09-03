

Update #TblPaso# Set 
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
                      #TblPaso# ON dbo.MAEPR.KOPR = #TblPaso#.Codigo 
                      LEFT OUTER JOIN
                      dbo.TABHF ON dbo.MAEPR.FMPR = dbo.TABHF.KOFM AND 
						dbo.MAEPR.PFPR = dbo.TABHF.KOPF AND dbo.MAEPR.HFPR = dbo.TABHF.KOHF 
						LEFT OUTER JOIN
                      dbo.TABPF ON dbo.MAEPR.FMPR = dbo.TABPF.KOFM AND 
						dbo.MAEPR.PFPR = dbo.TABPF.KOPF ON dbo.TABFM.KOFM = dbo.MAEPR.FMPR 
						LEFT OUTER JOIN
                      dbo.TABCARAC ON dbo.MAEPR.CLALIBPR = dbo.TABCARAC.KOCARAC ON dbo.TABZO.KOZO = dbo.MAEPR.ZONAPR 
                      LEFT OUTER JOIN
                      dbo.TABMR ON dbo.MAEPR.MRPR = dbo.TABMR.KOMR LEFT OUTER JOIN
                      dbo.TABRU ON dbo.MAEPR.RUPR = dbo.TABRU.KORU
                      








