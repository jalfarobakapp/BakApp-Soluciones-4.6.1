DECLARE 
@Empresa char(2),
@Codigo char(13),
@ListaPrecio Char(3)

select @Empresa = '#Empresa#',@ListaPrecio = '#ListaPrecio#'

SELECT Top 200
       MP.TIPR,
       MP.KOPR,
       MP.NOKOPR,
       MP.UD01PR,
       MP.UD02PR,
       MP.RLUD,
       Isnull( TP.PP01UD,0) As PP01UD,
       Isnull( TP.PP01UD,0) As PP02UD
  FROM MAEPR MP INNER JOIN MAEPREM 
    ON MAEPREM.KOPR=MP.KOPR 
    AND MAEPREM.EMPRESA=@Empresa  
        LEFT JOIN TABPRE TP 
    ON MP.KOPR=TP.KOPR 
    AND TP.KOLT=@ListaPrecio   
WHERE  
    MP.ATPR<>'OCU' AND 
    MP.TIPR<>'SSN'  
    #Reemplazos#
    ORDER BY MP.KOPR  OPTION ( FAST 20 )