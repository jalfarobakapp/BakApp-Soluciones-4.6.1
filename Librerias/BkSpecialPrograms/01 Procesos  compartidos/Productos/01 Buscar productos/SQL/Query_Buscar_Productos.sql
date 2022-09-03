
Declare @Empresa Char(2) = '#Empresa#',
        @Sucursal Char(3) = '#Sucursal#',
        @Bodega Char(3) = '#Bodega#',
        @Lista Char(3) = '#Lista#'

SELECT  TOP 30 Mpe.EMPRESA, 
               Mp.KOPR, 
               Mp.NOKOPR, 
               Mp.KOPRRA, 
               Mp.NOKOPRRA, 
               Mp.KOPRTE, 
               Mp.KOGE, 
               Mp.NMARCA, 
               Mp.UD01PR, 
               Mp.UD02PR, 
               Mp.RLUD, 
               Mp.POIVPR, 
               Mp.NUIMPR, 
               Tb.KOSU, 
               Tb.KOBO, 
               Tb.DATOSUBIC, 
               TABMR.KOMR, 
               TABMR.NOKOMR, 
               TABFM.KOFM, 
               TABFM.NOKOFM, 
               TABPF.KOPF, 
               TABPF.NOKOPF, 
               TABHF.KOHF, 
               TABHF.NOKOHF, 
               TABRU.KORU, 
               TABRU.NOKORU, 
               TABZO.KOZO, 
               TABZO.NOKOZO, 
               MAEST.STFI1, 
               MAEST.STFI2, 
               Mpe.PPUL01, 
               Mpe.PPUL02, 
               Mpe.PM, 
               TABPRE.ECUACION, 
               TABPRE.PP01UD, 
               TABPRE.MG01UD, 
               TABPRE.DTMA01UD, 
               TABPRE.PP02UD, 
               TABPRE.MG02UD, 
               TABPRE.DTMA02UD,Cast(0 As Bit) As Ecu_Generada
--Into #Paso_Productos                      
FROM         TABMR RIGHT OUTER JOIN
                      MAEST RIGHT OUTER JOIN
                      TABBOPR Tb ON MAEST.EMPRESA = Tb.EMPRESA AND MAEST.KOSU = Tb.KOSU AND MAEST.KOBO = Tb.KOBO AND 
                      MAEST.KOPR = Tb.KOPR RIGHT OUTER JOIN
                      MAEPREM AS Mpe ON Tb.KOPR = Mpe.KOPR AND Tb.EMPRESA = Mpe.EMPRESA LEFT OUTER JOIN
                      TABRU RIGHT OUTER JOIN
                      TABZO RIGHT OUTER JOIN
                      TABPRE RIGHT OUTER JOIN
                      MAEPR AS Mp ON TABPRE.KOPR = Mp.KOPR LEFT OUTER JOIN
                      TABHF ON Mp.FMPR = TABHF.KOFM AND Mp.PFPR = TABHF.KOPF AND Mp.HFPR = TABHF.KOHF LEFT OUTER JOIN
                      TABPF ON Mp.FMPR = TABPF.KOFM AND Mp.PFPR = TABPF.KOPF LEFT OUTER JOIN
                      TABFM ON Mp.FMPR = TABFM.KOFM ON TABZO.KOZO = Mp.ZONAPR ON TABRU.KORU = Mp.RUPR ON Mpe.KOPR = Mp.KOPR ON TABMR.KOMR = Mp.MRPR
WHERE 1 > 0

AND (TABBOPR.KOSU = @Sucursal) 
AND (TABBOPR.KOBO = @Bodega) 
AND (Mpe.EMPRESA = @Empresa) 
AND (TABPRE.KOLT = @Lista)

       #Sql_Filtro1#
       #Ocultos#
       #Bloqueapr#
       #Filtro_Productos#
       --AND NOT COALESCE(Mp.BLOQUEAPR,'') IN ( 'V','T' )-- And Para_Buscar = 1

--ORDER BY Codigo  





