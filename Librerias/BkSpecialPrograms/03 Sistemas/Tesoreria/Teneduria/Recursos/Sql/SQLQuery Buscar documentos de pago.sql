
Declare @Empresa As Char(2) = '#Empresa#'

SELECT DISTINCT #Top# MAEDPCE.*,
		CASE ESPGDP 
			WHEN 'P' THEN 'Pendiente' 
			WHEN 'C' THEN 'Pagado' 
			WHEN 'N' THEN 'Anulado' 
			WHEN 'E' THEN 'Eliminado' 
			WHEN 'R' THEN 'Protestado' 
			ELSE '????'
		END AS ESTADO,	
	   MAEDPCE.ESPGDP AS ESPGANT,
	   MAEDPCE.KOTNDP AS KOTNANT,
	   MAEDPCE.SUTNDP AS SUTNANT,
       0.0 AS ABONONU,
       (SELECT TOP 1 MAEEN.NOKOEN FROM MAEEN WHERE MAEEN.KOEN=MAEDPCE.ENDP ) AS NOKOEN,
       TABTN.NOTN,
       TABTN.TITN,
       TABTN.SUTN,
       TABSU.NOKOSU,
      (SELECT TOP 1 NUMECOM  FROM CCOMPRE 
			INNER JOIN CCOMPRD  ON CCOMPRE.IDCOMPRE=CCOMPRD.IDCOMPRE  
				INNER JOIN CCOMPRD1 ON CCOMPRD1.IDCOMPRD=CCOMPRD.IDCOMPRD 
					AND CCOMPRD1.ARCHIRST='MAEDPCE'  AND CCOMPRD1.IDRST=MAEDPCE.IDMAEDPCE ) AS NUMECOM  
FROM MAEDPCE WITH ( NOLOCK )  
	LEFT JOIN TABTN ON TABTN.KOTN=MAEDPCE.KOTNDP  
		LEFT JOIN TABSU ON TABSU.KOSU=MAEDPCE.SUTNDP   
WHERE 1 > 0
AND MAEDPCE.EMPRESA = @Empresa 
#Filtro#
--AND MAEDPCE.TIDP IN ( 'CHC' ) AND MAEDPCE.FEEMDP > '20180101' 