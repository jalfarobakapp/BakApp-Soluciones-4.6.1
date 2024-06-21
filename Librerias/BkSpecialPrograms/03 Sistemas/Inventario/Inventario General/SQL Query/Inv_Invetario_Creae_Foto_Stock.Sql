Declare @IdInventario Int = #IdInventario#,
        @Ano Char(4) = '#Ano#',
        @Mes Char(2) = '#Mes#',
        @Dia Char(2) = '#Dia#',
        @Empresa Char(2) = '#Empresa#',
        @Sucursal Char(3) = '#Sucursal#',
        @Bodega Char(3) = '#Bodega#'


INSERT INTO Zw_Inv_FotoInventario 
(IdInventario,Ano,Mes,Dia,IdBodega,Empresa,Sucursal,Bodega,Tipr,CodigoPR,CodigoRaPR,CodigoTePR,DescripcionPR,
 StFisicoUd1,PPP,PUltCompra,FechaFoto,HoraFoto,SuperFamilia,Familia,SubFamilia,Marca,Rubro,ClasLibre,Zona)
SELECT @IdInventario,@Ano,@Mes,@Dia,0,@Empresa,@Sucursal,@Bodega,MAEPR.TIPR,MAEPR.KOPR, MAEPR.KOPRRA, MAEPR.KOPRTE, 
MAEPR.NOKOPR, SUM(MAEST.STFI1) AS STOCK,ISNULL(MAEPREM.PM, 0) AS PM, ISNULL(MAEPREM.PPUL01, 0) AS PPUL01,
GETDATE()AS F1,GETDATE() AS H1,
ISNULL(MAEPR.FMPR,''),
ISNULL(MAEPR.PFPR,''),
ISNULL(MAEPR.HFPR,''),
ISNULL(MAEPR.MRPR,''),
ISNULL(MAEPR.RUPR,''),
ISNULL(MAEPR.CLALIBPR,''),
ISNULL(MAEPR.ZONAPR,'')
FROM         MAEPREM LEFT OUTER JOIN
MAEPR ON MAEPREM.KOPR = MAEPR.KOPR LEFT OUTER JOIN
MAEST ON MAEPR.KOPR = MAEST.KOPR
WHERE     (MAEST.KOSU = @Sucursal) AND (MAEST.KOBO = @Bodega) AND (MAEPREM.EMPRESA = @Empresa)
GROUP BY MAEPREM.EMPRESA, MAEST.KOSU, MAEST.KOBO, MAEPR.KOPR, 
MAEPR.KOPRRA, MAEPR.KOPRTE, MAEPR.NOKOPR, MAEPREM.PM, MAEPREM.PPUL01,MAEPR.TIPR,
MAEPR.FMPR,
MAEPR.PFPR,
MAEPR.HFPR,
MAEPR.MRPR,
MAEPR.RUPR,
MAEPR.CLALIBPR,
MAEPR.ZONAPR


INSERT INTO Zw_Inv_FotoInventario (IdInventario,Ano,Mes,Dia,IdBodega,Empresa,Sucursal,Bodega,Tipr,CodigoPR,
CodigoRaPR,CodigoTePR,DescripcionPR,StFisicoUd1,PPP,PUltCompra,FechaFoto,HoraFoto,
SuperFamilia,Familia,SubFamilia,Marca,Rubro,ClasLibre,Zona)
SELECT @IdInventario,@Ano,@Mes,@Dia,0,@Empresa,@Sucursal,@Bodega,MAEPR.TIPR, MAEPR.KOPR, MAEPR.KOPRRA,MAEPR.KOPRTE, 
MAEPR.NOKOPR, 0 AS STOCK,ISNULL(MAEPREM.PM, 0) AS PM, ISNULL(MAEPREM.PPUL01, 0) AS PPUL01,
GETDATE()AS F1,GETDATE() AS H1,
ISNULL(MAEPR.FMPR,''),
ISNULL(MAEPR.PFPR,''),
ISNULL(MAEPR.HFPR,''),
ISNULL(MAEPR.MRPR,''),
ISNULL(MAEPR.RUPR,''),
ISNULL(MAEPR.CLALIBPR,''),
ISNULL(MAEPR.ZONAPR,'')
FROM         MAEPREM LEFT OUTER JOIN
MAEPR ON MAEPREM.KOPR = MAEPR.KOPR
WHERE     (MAEPR.KOPR NOT IN (SELECT CodigoPR FROM Zw_Inv_FotoInventario WHERE IdInventario = @IdInventario)) 
order by MAEPR.KOPR 


Update Zw_Inv_FotoInventario Set 
                       Nom_Rubro = Isnull((Select top 1 NOKORU From TABRU Where KORU = Rubro),''),
                       Nom_Marca = Isnull((Select Top 1 NOKOMR From TABMR Where KOMR = Marca),''),
                       Nom_Zona = Isnull((Select Top 1 NOKOZO From TABZO Where KOZO = Zona),''),
                       Nom_SuperFamilia = Isnull((Select Top 1 NOKOFM From TABFM Where KOFM = SuperFamilia),''),
                       Nom_Familia = Isnull((Select Top 1 NOKOPF From TABPF 
                                            Where KOFM = SuperFamilia And KOPF = Familia),''),
                       Nom_SubFamilia = Isnull((Select Top 1 NOKOHF From TABHF
                                            Where KOFM = SuperFamilia And KOPF = Familia And KOHF = SubFamilia),''),
                       Nom_ClasLibre = Isnull((Select Top 1 NOKOCARAC From TABCARAC 
                                            Where KOTABLA = 'CLALIBPR' And KOCARAC = ClasLibre),'')
