
--truncate table  W_TmpFotoInventario
INSERT INTO W_TmpFotoInventario (Empresa,Sucursal,Bodega,CodigoPR,CodigoRaPR,CodigoTePR,DescripcionPR,StFisicoUd1,PPP,PUltCompra,FechaFoto,HoraFoto)
SELECT     TOP (200) MAEPREM.EMPRESA, MAEST.KOSU, MAEST.KOBO, MAEST.KOPR, MAEPR.KOPRRA, MAEPR.KOPRTE, 
           MAEPR.NOKOPR, MAEST.STFI1,ISNULL(MAEPREM.PM, 0) AS PM, ISNULL(MAEPREM.PPUL01, 0) AS PPUL01,
           GETDATE()AS F1,'10:30:00' AS H1
FROM         MAEPREM LEFT OUTER JOIN
                      MAEPR ON MAEPREM.KOPR = MAEPR.KOPR LEFT OUTER JOIN
                      MAEST ON MAEPR.KOPR = MAEST.KOPR
WHERE     (MAEST.KOSU = 'CM') AND (MAEST.KOBO = 'PR') AND (MAEPREM.EMPRESA = '01')

select * from W_TmpFotoInventario