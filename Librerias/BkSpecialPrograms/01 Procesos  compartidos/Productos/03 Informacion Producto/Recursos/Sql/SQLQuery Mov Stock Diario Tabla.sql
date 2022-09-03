DECLARE 
@Empresa char(2),
@Fecha_Desde datetime,
@Fecha_Hasta datetime

select @Empresa = '#Empresa#',
       @Fecha_Desde = '#Fecha_Desde#',
       @Fecha_Hasta = '#Fecha_Hasta#'

SELECT 
        ISNULL(SUM(CASE 
                 WHEN MAEDDO.TIDO IN ('OCC') 
                 THEN CASE WHEN MAEDDO.CAPREX#Ud# <> 0 THEN CAPRCO#Ud# ELSE 0 END 
                 ELSE 0
               END),0) AS 'Solicitud_Compra_Ud',
    ISNULL(SUM(CASE 
                 WHEN MAEDDO.TIDO IN ('FCC','NCV')
                    THEN CASE WHEN MAEDDO.CAPRAD#Ud# <> 0 THEN CAPRCO#Ud# ELSE 0 END
                 WHEN MAEDDO.TIDO IN ('GRC','GRD','GRP') THEN CAPRCO#Ud#     
                 ELSE 0
               END),0) AS 'Ingreso_Compra_Ud',
    ISNULL(SUM(CASE 
                 WHEN MAEDDO.TIDO IN ('GRI') THEN CAPRCO#Ud# 
                 ELSE 0
                 END),0) AS 'Ingreso_Interno_Ud', 
    ISNULL(SUM(CASE 
                 WHEN MAEDDO.TIDO IN ('FCV','BLV','BSV')
                    THEN CASE WHEN MAEDDO.CAPRAD#Ud# <> 0 THEN CAPRCO#Ud#*-1 ELSE 0 END
                 WHEN MAEDDO.TIDO IN ('GDV','GDP','GDD') THEN CAPRCO#Ud#*-1     
                 ELSE 0
               END),0) AS 'Salida_Venta_Ud',  
    ISNULL(SUM(CASE 
                 WHEN MAEDDO.TIDO IN ('GDI','GTI') THEN CAPRCO#Ud#*-1   
                 ELSE 0
                 END),0) AS 'Salida_Interno_Ud',       
 
       CONVERT(VARCHAR(8), MAEDDO.FEEMLI, 112) AS FECHA
       
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
       WHERE 1 > 0
       
       AND MAEDDO.KOPRCT IN #Codigo#
       
       AND MAEEDO.EMPRESA=@Empresa
       AND ( MAEDDO.LILG NOT IN ('GR','IM' ) 
       OR ( MAEDDO.TIDO IN ('NVV','NVI') 
       AND MAEDDO.ESFALI<>' ' ) )  
       AND MAEDDO.EMPRESA=@Empresa 
       #FiltroBodegas#
       AND MAEDDO.FEEMLI BETWEEN @Fecha_Desde AND @Fecha_Hasta
       
       GROUP BY MAEDDO.FEEMLI 
       
       
      /*
       ISNULL(SUM(CASE 
               WHEN MAEDDO.CAPRAD#Ud# <> 0 THEN 
                CASE 
                 WHEN MAEDDO.TIDO IN ('FCC','NCV','GRI','GRC','GRD','GRP') THEN CAPRCO#Ud#
                 WHEN MAEDDO.TIDO IN ('FCV','BLV','BSV','NCC','GDV','GDI','GDP','GDD','GTI') THEN CAPRCO#Ud#*-1
                 ELSE 0
                END
               WHEN MAEDDO.TIDO IN ('GRI','GRC','GRD','GRP','GDV','GDI','GDP','GDD','GTI') THEN 
                CASE 
                 WHEN MAEDDO.TIDO IN ('GRI','GRC','GRD','GRP') THEN CAPRCO#Ud#
                 WHEN MAEDDO.TIDO IN ('GDV','GDI','GDP','GDD','GTI') THEN CAPRCO#Ud#*-1
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
       END),0) AS 'Mov_Ud2',
       */