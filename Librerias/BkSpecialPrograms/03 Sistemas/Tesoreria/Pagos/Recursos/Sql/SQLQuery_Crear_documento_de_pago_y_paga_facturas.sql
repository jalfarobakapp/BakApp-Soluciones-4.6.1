SELECT CURRENT_TIMESTAMP AS FECHA, CONVERT( VARCHAR(45), CURRENT_TIMESTAMP, 9 ) AS HORA 
go
-- 48749.87
SELECT TOP 1 * FROM TABUSER WITH ( NOLOCK )  WHERE IP='61482' AND SISTEMA='gestion'
go
-- 48749.90
UPDATE TABUSER SET  FECHA=CURRENT_TIMESTAMP  WHERE IP='61482' AND SISTEMA='gestion' 
go
-- 48749.93
BEGIN TRANSACTION
go
-- 48749.93
SELECT COALESCE(MAX(IDMAEDPCD),1) AS MAXNUDO  FROM MAEDPCD WITH ( NOLOCK ) 
go
-- 48749.98
SELECT CURRENT_TIMESTAMP AS FECHA, CONVERT( VARCHAR(45), CURRENT_TIMESTAMP, 9 ) AS HORA 
go
-- 48750.00
SELECT COALESCE(MAX(NUDP),'0000000000') AS MAXNUDO  FROM MAEDPCE WITH ( NOLOCK )  WHERE EMPRESA='01'  AND CJREDP='CM' AND TIDP='CHV' 
go
-- 48750.02
SELECT TOP 1 * FROM MAEDPCE WITH ( NOLOCK )  WHERE EMPRESA='01' AND TIDP='CHV' AND NUDP='CM00004938' AND ENDP='15463484     '
go
-- 48750.10
INSERT INTO MAEDPCE (EMPRESA,TIDP,NUDP,ENDP,NUCUDP,CUDP,EMDP,SUEMDP,FEEMDP,FEVEDP,MODP,TIMODP,TAMODP,REFANTI,SUREDP,CJREDP,KOTU,KOFUDP,KOTNDP,SUTNDP,
                     TUVOPROTES,VADP,VAASDP,VAVUDP,ESASDP,VAABDP,ESPGDP,CUOTAS,HORAGRAB,LAHORA,ARCHIRSD,IDRSD,REFERENCIA) 
					 VALUES ( '01','CHV','CM00004938','15463484     ','123456  ','1234569         ','012          ','   ',{d '2016-02-26'},{d '2016-02-26'},'$  ','N',
					 701.39000,'                                                                                ','CM ','CM','1','ZZZ','79514800-0   ','CM',
					 0,17120.00000,17120.00000,0.00000,'A',0.0,'P',1.00000,48717,{d '2016-02-26'},'        ',0,212856.000000)
go
-- 48750.15
SELECT @@IDENTITY AS ULTID
go
-- 48750.31
SELECT TOP 1 IDMAEEDO,EMPRESA,ENDO,TIDO,NUDO,VAPIDO,VAABDO,TIMODO,BLOQUEAPAG FROM MAEEDO WITH ( NOLOCK )  WHERE IDMAEEDO=397198
go
-- 48750.33
UPDATE MAEEDO SET VAABDO= COALESCE(VAABDO,0) +17120.00000  WHERE IDMAEEDO=397198
go
-- 48750.36
UPDATE MAEEDO SET ESPGDO=CASE WHEN ROUND(VABRDO,2)-ROUND(VAABDO,2)-COALESCE(ROUND(VAIVARET,2),0) <= 0 THEN 'C'  ELSE ESPGDO END  WHERE IDMAEEDO=397198
go
-- 48750.38
SELECT VAVE,VAABVE,IDMAEVEN  FROM MAEVEN WITH ( NOLOCK )  WHERE IDMAEEDO=397198 AND ESPGVE<>'C' 
go
-- 48750.41
UPDATE MAEVEN SET VAABVE= COALESCE(VAABVE,0.0)+17120.00000  WHERE IDMAEVEN=218764
go
-- 48750.44
UPDATE MAEVEN SET ESPGVE=CASE WHEN ROUND(VAVE,2)-ROUND(VAABVE,2) <= 0 THEN 'C' ELSE ESPGVE END  WHERE IDMAEVEN=218764
go
-- 48750.47
INSERT INTO MAEDPCD ( IDMAEDPCE,VAASDP,FEASDP,IDRST,TIDOPA,ARCHIRST,TCASIG,REFERENCIA,KOFUASDP,SUASDP,CJASDP,HORAGRAB,LAHORA) 
VALUES ( 182144,17120.00000,{d '2016-02-26'},397198,'FCV','MAEEDO  ',701.39000,212856.000000,'ZZZ','CM ','CM',48718,{d '2016-02-26'})
go
-- 48750.49
COMMIT TRANSACTION
go
-- 48750.61
