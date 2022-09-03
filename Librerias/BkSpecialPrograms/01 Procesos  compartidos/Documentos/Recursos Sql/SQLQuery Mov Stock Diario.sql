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
  ISNULL(SUM(CASE 
               WHEN MAEDDO.CAPRAD1 <> 0 THEN 
                CASE 
                 WHEN MAEDDO.TIDO IN ('FCC','NCV','GRI','GRC','GRD','GRP') THEN CAPRCO1
                 WHEN MAEDDO.TIDO IN ('FCV','BLV','BSV','NCC','GDV','GDI','GDP','GDD','GTI') THEN CAPRCO1*-1
                 ELSE 0
                END
               WHEN MAEDDO.TIDO IN ('GRI','GRC','GRD','GRP','GDV','GDI','GDP','GDD','GTI') THEN 
                CASE 
                 WHEN MAEDDO.TIDO IN ('GRI','GRC','GRD','GRP') THEN CAPRCO1
                 WHEN MAEDDO.TIDO IN ('GDV','GDI','GDP','GDD','GTI') THEN CAPRCO1*-1
                 ELSE 0
                END
               ELSE 0     
             END),0) AS 'Mov_Ud1',
  ISNULL(SUM(CASE 
         WHEN MAEDDO.CAPRAD2 <> 0 THEN 
           CASE 
            WHEN MAEDDO.TIDO IN ('FCC','NCV','GRI','GRC','GRD','GRP') THEN CAPRCO2
             WHEN MAEDDO.TIDO IN ('FCV','BLV','BSV','NCC','GDV','GDI','GDP','GDD','GTI') THEN CAPRCO2*-1
             ELSE 0
            END
         WHEN MAEDDO.TIDO IN ('GRI','GRC','GRD','GRP','GDV','GDI','GDP','GDD','GTI') THEN 
           CASE 
            WHEN MAEDDO.TIDO IN ('GRI','GRC','GRD','GRP') THEN CAPRCO2
             WHEN MAEDDO.TIDO IN ('GDV','GDI','GDP','GDD','GTI') THEN CAPRCO2*-1
             ELSE 0
            END
       ELSE 0     
       END),0) AS 'Mov_Ud2'
       
       FROM MAEDDO WITH ( NOLOCK )  LEFT JOIN MAEEDO 
            ON MAEDDO.IDMAEEDO=MAEEDO.IDMAEEDO  
            LEFT JOIN MAEEN 
            ON MAEDDO.ENDO=MAEEN.KOEN 
            AND MAEDDO.SUENDO=MAEEN.SUEN  
             LEFT JOIN MAEPPPME 
             ON MAEDDO.IDMAEDDO=MAEPPPME.IDMAEDDO 
             AND MAEPPPME.MODO='US$'  
              LEFT JOIN POTD 
              ON POTD.IDPOTD=MAEDDO.IDRST 
              AND MAEDDO.ARCHIRST='POTD'  
               LEFT JOIN POTL 
               ON POTL.IDPOTL=MAEDDO.IDRST 
               AND MAEDDO.ARCHIRST='POTL'  
                LEFT JOIN PODCE 
                ON PODCE.IDPODCE=MAEDDO.IDRST 
                AND MAEDDO.ARCHIRST='PODCE'  
                 LEFT JOIN PODCD 
                 ON PODCD.IDPODCD=MAEDDO.IDRST 
                 AND MAEDDO.ARCHIRST='PODCD' 
       WHERE MAEDDO.KOPRCT IN #Codigo#--@Codigo 
       AND MAEEDO.EMPRESA=@Empresa
       AND ( MAEDDO.LILG NOT IN ('GR','IM' ) 
       OR ( MAEDDO.TIDO IN ('NVV','NVI') 
       AND MAEDDO.ESFALI<>' ' ) )  
       AND MAEDDO.EMPRESA=@Empresa 
       --AND MAEDDO.SULIDO=@Sucursal 
       --AND MAEDDO.BOSULIDO=@Bodega  
       #FiltroBodegas#
       AND MAEDDO.FEEMLI = @Fecha