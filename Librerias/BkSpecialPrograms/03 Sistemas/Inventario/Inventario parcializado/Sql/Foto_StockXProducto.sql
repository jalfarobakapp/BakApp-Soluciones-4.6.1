DECLARE 
@Empresa char(2),@Sucursal char(3),@Bodega char(3),@Codigo char(13)

select @Empresa = '#Empresa#',@Sucursal = '#Sucursal#',@Bodega = '#Bodega#',@Codigo = '#Codigo#'

BEGIN TRY
 DROP TABLE #_TblPaso
 END TRY
 BEGIN CATCH
END CATCH

SELECT 
       MAEDDO.TIDO,
       MAEDDO.NUDO,
       CASE 
       WHEN MAEDDO.CAPRAD1 <> 0 THEN 
           CASE 
             WHEN MAEDDO.TIDO IN ('FCC','NCV','GRI','GRC','GRD','GRP') THEN CAPRCO1
             WHEN MAEDDO.TIDO IN ('FCV','FDV','BLV','BSV','NCC','GDV','GDI','GDP','GDD','GTI') THEN CAPRCO1*-1
             WHEN MAEDDO.TIDO IN ('GAR') THEN CAPRAD1
             ELSE 0
            END
       WHEN MAEDDO.TIDO IN ('GRI','GRC','GRD','GRP','GDV','GDI','GDP','GDD','GTI') THEN 
           CASE 
            WHEN MAEDDO.TIDO IN ('GRI','GRC','GRD','GRP') THEN CAPRCO1
             WHEN MAEDDO.TIDO IN ('GDV','GDI','GDP','GDD','GTI') THEN CAPRCO1*-1
             WHEN MAEDDO.TIDO IN ('GAR') THEN CAPRAD1
             ELSE 0
            END
       ELSE 0     
       END AS 'STFISICOUD1',
       CASE 
       WHEN MAEDDO.CAPRAD2 <> 0 THEN 
           CASE 
             WHEN MAEDDO.TIDO IN ('FCC','NCV','GRI','GRC','GRD','GRP') THEN CAPRCO2
             WHEN MAEDDO.TIDO IN ('FCV','FDV','BLV','BSV','NCC','GDV','GDI','GDP','GDD','GTI') THEN CAPRCO2*-1
             WHEN MAEDDO.TIDO IN ('GAR') THEN CAPRAD2
             ELSE 0
            END
       WHEN MAEDDO.TIDO IN ('GRI','GRC','GRD','GRP','GDV','GDI','GDP','GDD','GTI') THEN 
           CASE 
            WHEN MAEDDO.TIDO IN ('GRI','GRC','GRD','GRP') THEN CAPRCO2
             WHEN MAEDDO.TIDO IN ('GDV','GDI','GDP','GDD','GTI') THEN CAPRCO2*-1
             WHEN MAEDDO.TIDO IN ('GAR') THEN CAPRAD2
             ELSE 0
            END
       ELSE 0     
       END AS 'STFISICOUD2'
       Into #_TblPaso
       FROM MAEDDO WITH ( NOLOCK )  LEFT JOIN MAEEDO 
            ON MAEDDO.IDMAEEDO=MAEEDO.IDMAEEDO  
            LEFT JOIN MAEEN 
            ON MAEDDO.ENDO=MAEEN.KOEN 
            AND MAEDDO.SUENDO=MAEEN.SUEN  
             --LEFT JOIN MAEPPPME 
             --ON MAEDDO.IDMAEDDO=MAEPPPME.IDMAEDDO   <-- SOLO PARA NUEVA VERSION RANDOM
             --AND MAEPPPME.MODO='US$'  
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
       WHERE MAEDDO.KOPRCT=@Codigo 
       AND MAEEDO.EMPRESA=@Empresa
       AND ( MAEDDO.LILG NOT IN ('GR','IM' ) 
       OR ( MAEDDO.TIDO IN ('NVV','NVI') 
       AND MAEDDO.ESFALI<>' ' ) )  
       AND MAEDDO.SULIDO=@Sucursal 
       AND MAEDDO.BOSULIDO=@Bodega  
       --Filtro_Condicion_Extra
       
       ORDER BY MAEDDO.KOPRCT,MAEEDO.FEEMDO,MAEEDO.HORAGRAB,MAEDDO.SEMILLA,MAEDDO.IDMAEEDO

Select Isnull(SUM(STFISICOUD1),0) AS STFISICOUD1,Isnull(SUM(STFISICOUD2),0) AS STFISICOUD2 from #_TblPaso           

Drop Table #_TblPaso       
