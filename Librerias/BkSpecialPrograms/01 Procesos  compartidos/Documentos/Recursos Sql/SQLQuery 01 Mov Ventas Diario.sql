DECLARE 
@Empresa char(2),
@Sucursal char(3),
@Bodega char(3),
@Fecha datetime

select @Empresa = '#Empresa#',
       @Sucursal = '#Sucursal#',
       @Bodega = '#Bodega#',
       @Fecha = '#Fecha#'

SELECT 
 SUM(CASE 
       WHEN MAEDDO.CAPRAD1 <> 0 THEN 
           CASE 
             WHEN MAEDDO.TIDO IN ('NCV') THEN CAPRCO1*-1
             WHEN MAEDDO.TIDO IN ('FCV','BLV','GDV') THEN CAPRCO1
             ELSE 0
            END
       WHEN MAEDDO.TIDO IN ('GDV') THEN 
           CASE 
             WHEN MAEDDO.TIDO IN ('GDV') THEN CAPRCO1
             ELSE 0
            END
       ELSE 0     
       END) AS 'Mov_Ud1',
 SUM(CASE 
       WHEN MAEDDO.CAPRAD2 <> 0 THEN 
           CASE 
             WHEN MAEDDO.TIDO IN ('NCV') THEN CAPRCO2*-2
             WHEN MAEDDO.TIDO IN ('FCV','BLV','GDV') THEN CAPRCO2
             ELSE 0
            END
       WHEN MAEDDO.TIDO IN ('GDV') THEN 
           CASE 
             WHEN MAEDDO.TIDO IN ('GDV') THEN CAPRCO2
             ELSE 0
            END
       ELSE 0     
       END) AS 'Mov_Ud2'       

 FROM MAEDDO WITH ( NOLOCK ) -- LEFT JOIN MAEEDO 
       WHERE KOPRCT In #Codigo# --=@Codigo 
       AND EMPRESA=@Empresa
       AND ( LILG NOT IN ('GR','IM' ) 
       OR ( TIDO IN ('NVV','NVI') 
       AND ESFALI<>' ' ) )  
       AND EMPRESA=@Empresa 
       #FiltroBodegas#
       --AND MAEDDO.SULIDO=@Sucursal 
       --AND MAEDDO.BOSULIDO=@Bodega  
       AND FEEMLI = @Fecha
       AND TIDO IN ('FCV','BLV','GDV','NCV')
       #EntExcluidas# 
       