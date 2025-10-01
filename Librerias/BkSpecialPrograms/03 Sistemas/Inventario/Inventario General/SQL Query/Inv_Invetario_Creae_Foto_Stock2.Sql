Declare @IdInventario Int = #IdInventario#,
        @Empresa Char(2) = '#Empresa#',
        @Sucursal Char(3) = '#Sucursal#',
        @Bodega Char(3) = '#Bodega#'


Insert Into Zw_Inv_FotoInventario 
(IdInventario,Empresa,Sucursal,Bodega,Tipr,Codigo,CodigoRap,CodigoTec,Descripcion,
 StFisicoUd1,StFisicoUd2,Costo,PPP,PUltCompra,FechaFoto,HoraFoto,SuperFamilia,Familia,SubFamilia,Marca,Rubro,ClasLibre,Zona)

Select @IdInventario,@Empresa,@Sucursal,@Bodega,Mp.TIPR,Mp.KOPR,Mp.KOPRRA,Mp.KOPRTE, 
Mp.NOKOPR,SUM(Mst.STFI1) AS StFisicoUd1,SUM(Mst.STFI2) AS StFisicoUd2,
ISNULL(Men.PM,0) AS Costo,ISNULL(Men.PM,0) AS PM,ISNULL(Men.PPUL01, 0) AS PPUL01,
GETDATE()AS F1,GETDATE() AS H1,
ISNULL(Mp.FMPR,''),
ISNULL(Mp.PFPR,''),
ISNULL(Mp.HFPR,''),
ISNULL(Mp.MRPR,''),
ISNULL(Mp.RUPR,''),
ISNULL(Mp.CLALIBPR,''),
ISNULL(Mp.ZONAPR,'')
From MAEST Mst With (Nolock)
Left Join MAEPR Mp With (Nolock) On Mp.KOPR = Mst.KOPR
Left Join MAEPREM Men With (Nolock) On Men.KOPR = Mst.KOPR And Men.EMPRESA = @Empresa
Where Mst.EMPRESA = @Empresa And Mst.KOSU = @Sucursal And Mst.KOBO = @Bodega
Group By Men.EMPRESA, Mst.KOSU, Mst.KOBO, Mp.KOPR, 
Mp.KOPRRA,Mp.KOPRTE,Mp.NOKOPR,Men.PM, Men.PPUL01,Mp.TIPR,
Mp.FMPR,
Mp.PFPR,
Mp.HFPR,
Mp.MRPR,
Mp.RUPR,
Mp.CLALIBPR,
Mp.ZONAPR


INSERT INTO Zw_Inv_FotoInventario (IdInventario,Empresa,Sucursal,Bodega,Tipr,Codigo,
CodigoRap,CodigoTec,Descripcion,StFisicoUd1,StFisicoUd2,Costo,PPP,PUltCompra,FechaFoto,HoraFoto,
SuperFamilia,Familia,SubFamilia,Marca,Rubro,ClasLibre,Zona)
SELECT @IdInventario,@Empresa,@Sucursal,@Bodega,MAEPR.TIPR, MAEPR.KOPR, MAEPR.KOPRRA,MAEPR.KOPRTE, 
MAEPR.NOKOPR,0 AS StFisicoUd1,0 AS StFisicoUd2,ISNULL(MAEPREM.PM, 0) AS Costo,ISNULL(MAEPREM.PM, 0) AS PM, ISNULL(MAEPREM.PPUL01, 0) AS PPUL01,
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
WHERE     (MAEPR.KOPR NOT IN (SELECT Codigo FROM Zw_Inv_FotoInventario WHERE IdInventario = @IdInventario)) 
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

