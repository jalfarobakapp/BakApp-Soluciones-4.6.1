DECLARE 
@Codigo  Char(13) 

Select @Codigo = '#Codigo#'

SELECT    *,
            Isnull(TABMR.NOKOMR,'') as 'Marca',
            Isnull(TABFM.NOKOFM,'') as 'SuperFamilia', 
            Isnull(TABPF.NOKOPF,'') as 'Familia', 
            Isnull(TABHF.NOKOHF,'') as 'SubFamilia', 
            Isnull(TABRU.NOKORU,'') as 'Rubro',  
            Isnull(TABZO.NOKOZO,'') as 'Zona'
FROM         dbo.TABFM RIGHT OUTER JOIN
                      dbo.TABHF RIGHT OUTER JOIN
                      dbo.MAEPR LEFT OUTER JOIN
                      dbo.TABZO ON dbo.MAEPR.ZONAPR = dbo.TABZO.KOZO ON dbo.TABHF.KOFM = dbo.MAEPR.FMPR AND dbo.TABHF.KOPF = dbo.MAEPR.PFPR AND dbo.TABHF.KOHF = dbo.MAEPR.HFPR ON 
                      dbo.TABFM.KOFM = dbo.MAEPR.FMPR LEFT OUTER JOIN
                      dbo.TABRU ON dbo.MAEPR.RUPR = dbo.TABRU.KORU LEFT OUTER JOIN
                      dbo.TABMR ON dbo.MAEPR.MRPR = dbo.TABMR.KOMR LEFT OUTER JOIN
                      dbo.TABPF ON dbo.MAEPR.FMPR = dbo.TABPF.KOFM AND dbo.MAEPR.PFPR = dbo.TABPF.KOPF
WHERE     (dbo.MAEPR.KOPR = @Codigo)



