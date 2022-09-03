DECLARE 
@Empresa char(2),
@Sucursal char(3),
@Bodega char(3),
@Codigo char(13)

Select @Empresa = '#Empresa#',@Sucursal = '#Sucursal#',@Bodega = '#Bodega#',@Codigo = '#Codigo#'


BEGIN TRY
 DROP TABLE #_TblPaso
 END TRY
 BEGIN CATCH
END CATCH

SELECT #Top#
       MAEEDO.IDMAEEDO,
       MAEEDO.HORAGRAB,
       convert(nvarchar, convert(datetime, (MAEEDO.HORAGRAB*1.0/3600)/24), 108) AS HORA,
       MAEEDO.TIDO,
       MAEEDO.SUBTIDO,
       MAEEDO.NUDO,
       MAEDDO.NULIDO*1 as NULIDO,
       MAEDDO.BOSULIDO,
       MAEEDO.ENDO,
       ISNULL(MAEEN.NOKOEN,'') AS NOKOEN,
       MAEDDO.FEEMLI,
       MAEDDO.NUSEPR,
       MAEDDO.CAPRCO#Ud#,
       Cast('' As Varchar(1)) As 'Sfisico',
       CASE 
       WHEN MAEDDO.CAPRAD#Ud# <> 0 THEN 
           CASE 
             --WHEN MAEDDO.TIDO IN ('FCC','NCV','GRI','GRC','GRD','GRP') THEN CAPRCO#Ud#
             --WHEN MAEDDO.TIDO IN ('FCV','FDB','FDV','FDX','FEV','FVL','FVT','FVX',
             --                     'BLV','BSV','NCC','GDV','GDI','GDP','GDD','GTI') THEN CAPRCO#Ud#*-1
             --WHEN MAEDDO.TIDO IN ('GAR') THEN CAPRAD#Ud#
             WHEN MAEDDO.TIDO IN ('FCC','NCV','GRI','GRC','GRD','GRP') THEN CAPRCO#Ud#
             WHEN MAEDDO.TIDO IN ('FCV','FDB','FDV','FDX','FEV','FVL','FVT','FVX','BLV','BSV','NCC') THEN CAPRAD#Ud#*-1
			 WHEN MAEDDO.TIDO IN ('GDV','GDI','GDP','GDD','GTI') THEN CAPRCO#Ud#*-1
             WHEN MAEDDO.TIDO IN ('GAR') THEN CAPRAD#Ud#
             ELSE 0
            END
       WHEN MAEDDO.TIDO IN ('GRI','GRC','GRD','GRP','GDV','GDI','GDP','GDD','GTI') THEN 
           CASE 
            WHEN MAEDDO.TIDO IN ('GRI','GRC','GRD','GRP') THEN CAPRCO#Ud#
             WHEN MAEDDO.TIDO IN ('GDV','GDI','GDP','GDD','GTI') THEN CAPRCO#Ud#*-1
             WHEN MAEDDO.TIDO IN ('GAR') THEN CAPRAD#Ud#
             ELSE 0
            END
       ELSE 0     
       END AS 'STFISICO',
       Cast('' As Varchar(1)) As 'Sdevengado',
       CASE 
             WHEN MAEDDO.TIDO IN ('BLV','BSV','FCV') AND MAEDDO.TIDOPA <> 'GDV' AND MAEDDO.CAPREX#Ud# > 0 THEN CAPREX#Ud#-- CAPRCO#Ud#
             WHEN MAEDDO.TIDO IN ('BLV','BSV','FCV') AND MAEDDO.TIDOPA <> 'GDV' AND MAEDDO.CAPRAD#Ud# = 0 THEN CAPRCO#Ud#
             WHEN MAEDDO.TIDO IN ('GDV') AND MAEDDO.TIDOPA IN ('BLV','FCV') THEN CAPRCO#Ud#*-1
             ELSE 0
            END
       AS 'DEVENGADO',
       Cast('' As Varchar(1)) As 'Sdespsfact',
       CASE 
       WHEN MAEDDO.TIDO IN ('GDV','FCV') THEN 
           CASE 
             WHEN MAEDDO.TIDO IN ('GDV') AND MAEDDO.TIDOPA IN ('','NVV') THEN CAPRCO#Ud#
             WHEN MAEDDO.TIDOPA IN ('GDV') AND MAEDDO.TIDO IN ('FCV') THEN CAPRCO#Ud#*-1
             ELSE 0
            END
       ELSE 0     
       END AS 'DESPSFACTURAR',
       Cast('' As Varchar(1)) As 'Scomprometido',
       CASE 
       WHEN MAEDDO.TIDO IN ('FCV','FDB','FDV','FDX','FEV','FVL','FVT','FVX','NVV','NVI','GDV','GDP','BLV','GTI') THEN
           CASE 
             WHEN MAEDDO.TIDO IN ('NVV','NVI') AND (MAEDDO.CAPRCO#Ud#-MAEDDO.CAPRAD#Ud#) > 0 THEN MAEDDO.CAPRCO#Ud#-MAEDDO.CAPRAD#Ud#
             WHEN MAEDDO.TIDOPA IN ('NVV','NVI') AND MAEDDO.TIDO IN 
             ('FCV','FDB','FDV','FDX','FEV','FVL','FVT','FVX','GDV','GDP','BLV','GTI') THEN (MAEDDO.CAPRCO#Ud#)*-1
             ELSE 0
            END
       ELSE 0     
       END AS 'COMPROMETIDO',
       Cast('' As Varchar(1)) As 'Scompranorecep',
       CASE 
       WHEN MAEDDO.TIDO IN ('FCC','GRC','BLC') THEN 
           CASE 
             WHEN MAEDDO.TIDO IN ('FCC','BLC') AND MAEDDO.TIDOPA IN ('','OCC') AND MAEDDO.CAPRAD#Ud# = 0 THEN CAPRCO#Ud#
                  --MAEDDO.CAPREX#Ud# = 0 AND MAEDDO.CAPRAD#Ud# = 0 THEN CAPRCO#Ud#
             WHEN MAEDDO.TIDO IN ('GRC') AND MAEDDO.TIDOPA IN ('FCC','BLC') THEN CAPRCO#Ud#*-1
             ELSE 0
            END
       ELSE 0     
       END AS 'COMPRANREC',
       Cast('' As Varchar(1)) As 'Srecesfact',
       CASE 
       WHEN MAEDDO.TIDO IN ('GRC','FCC') THEN-- MAEDDO.CAPREX#Ud# > 0 THEN 
           CASE 
             WHEN MAEDDO.TIDOPA IN ('','OCC') AND MAEDDO.TIDO IN ('GRC') THEN CAPRCO#Ud#
             WHEN MAEDDO.TIDOPA IN ('GRC') AND MAEDDO.TIDO IN ('FCC') THEN CAPRCO#Ud#*-1
             ELSE 0
            END
       ELSE 0     
       END AS 'RECEPSFAC',
       Cast('' As Varchar(1)) As 'Spedido',
       CASE 
       WHEN MAEDDO.TIDO IN ('GRC','FCC','OCC','OCI') THEN
           CASE 
             --WHEN MAEDDO.TIDO = 'OCC' AND TIDOPA IN ('','OCI') THEN CAPRCO#Ud# - CAPRAD#Ud#             
             --WHEN MAEDDO.TIDOPA = 'OCC' AND MAEDDO.TIDO IN ('GRC','FCC') THEN CAPRCO#Ud#*-1
             --WHEN MAEDDO.TIDOPA AND MAEDDO.TIDO IN ('OCC') AND MAEDDO.CAPREX#Ud# > 0 THEN MAEDDO.CAPRCO#Ud# - MAEDDO.CAPRAD#Ud#
             --WHEN MAEDDO.TIDOPA AND MAEDDO.TIDO IN ('OCC') AND MAEDDO.CAPREX#Ud# = 0 AND MAEDDO.CAPRAD#Ud# = 0 THEN MAEDDO.CAPRCO#Ud#
             WHEN MAEDDO.TIDO IN ('OCC','OCI') AND MAEDDO.TIDOPA = '' THEN MAEDDO.CAPRCO#Ud# - MAEDDO.CAPRAD#Ud#
             WHEN MAEDDO.TIDOPA IN ('OCC') AND MAEDDO.TIDO IN ('GRC','FCC') THEN MAEDDO.CAPRCO#Ud#*-1
             --WHEN MAEDDO.TIDO = 'OCC' AND MAEDDO.ESLIDO = 'C' THEN MAEDDO.CAPREX#Ud#
             ELSE 0
            END
       ELSE 0     
       END AS 'PEDIDO',
       MAEDDO.TIDOPA,
       MAEDDO.NUDOPA,
    -- MAEDDO.CAPRAD#Ud#,
    -- MAEDDO.CAPREX#Ud#,
    -- MAEDDO.CAPRNC1,
    -- MAEDDO.CAPRCO2,
    -- MAEDDO.CAPRAD2,
    -- MAEDDO.CAPREX2,
    -- MAEDDO.CAPRNC2,
    -- MAEDDO.IDMAEDDO,
       MAEDDO.NULOTE,
       MAEDDO.SUBLOTE,
       MAEDDO.VANELI,
       MAEDDO.VADTNELI,
       ISNULL(MAEDDO.PPPRNE,0) AS PPPRNE,
       ISNULL(MAEDDO.PPPRNERE#Ud#,0) AS PPPRNERE#Ud#,
       ISNULL(MAEDDO.PPPRPM,0) AS PPPRPM--,
       --ISNULL(MAEDDO.PPPRPMSUC,0) AS PPPRPMSUC <- SOLO PARA NUEVA VERSION RANDOM
       --,MAEDDO.PPPRPMIFRS,MAEPPPME.PPPRPMME,POTD.CANTIDADF,POTD.CANTIDADR,
       --POTD.CALIDAD,POTL.FABRICAR,POTL.REALIZADO, PODCE.CATIN01,PODCE.CARIN01,PODCD.CATPR01,PODCD.CABPR01  
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
       --ORDER BY MAEDDO.KOPRCT,MAEEDO.FEEMDO,MAEEDO.HORAGRAB,MAEDDO.SEMILLA,MAEDDO.IDMAEEDO
       #Orden#
       
Select * from #_TblPaso Order by FEEMLI
Drop Table #_TblPaso       
