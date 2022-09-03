SELECT DISTINCT TOP 100 
            
              MS.CodigoRd AS KOPR,
            --MS.DescripcionPr AS NOKOPR,
            --MS.DescripcionBusqueda AS DESCR_LARGA,
              (SELECT TOP 1 NOKOPR FROM MAEPR WHERE KOPR = MS.CodigoRd) AS NOKOPR,
              --ISNULL((SELECT TOP 1 PP01UD FROM TABPRE WHERE KOLT = '#Lista#' AND KOPR = MS.CodigoRd),0) 
              Isnull((Select Top 1 Precio From Zw_ListaPreProducto where Lista = '#Lista#' AND Codigo = MS.CodigoRd),0)
              AS PP01UD,
              ISNULL((SELECT TOP 1 dbo.MAEST.STFI1 FROM MAEST 
                      WHERE EMPRESA = '#Empresa#' AND 
                            KOSU = '#Sucursal#' AND 
                            KOBO = '#Bodega#' AND 
                            KOPR = MS.CodigoRd),0) AS STOCK,
              (SELECT TOP 1 NOKOCARAC FROM TABCARAC
              WHERE KOTABLA = 'CLALIBPR' AND KOCARAC = MP.CLALIBPR) AS CLALIBPR
              ,
              Ltrim(Rtrim(ISNULL((SELECT TOP 1 DATOSUBIC FROM TABBOPR 
                      WHERE EMPRESA = '#Empresa#' AND 
                            KOSU = '#Sucursal#' AND 
                            KOBO = '#Bodega#' AND 
                            KOPR = MS.CodigoRd),''))) AS DATOSUBIC,
              ISNULL((SELECT TOP 1 NOKOCARAC FROM TABCARAC       
                      WHERE KOCARAC = MP.CLALIBPR AND KOTABLA = 'CLALIBPR'),'') AS FAMILIA          
      
FROM           Zw_ProductosSI AS MS RIGHT OUTER JOIN
                      dbo.MAEPR AS MP WITH (NOLOCK) ON MS.CodigoRd = MP.KOPR 
                      
WHERE  
      (MS.DescripcionBusqueda LIKE '%#Descripcion#%') AND 
	   MP.ATPR<>'OCU' AND NOT 
       COALESCE(MP.BLOQUEAPR,'') IN ( 'V','T' )

ORDER BY CodigoRd       

