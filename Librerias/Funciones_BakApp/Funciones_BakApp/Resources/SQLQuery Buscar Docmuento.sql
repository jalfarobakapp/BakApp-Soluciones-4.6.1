SELECT 
        IDMAEEDO,
        TIDO,
        NUDO,
        ENDO,
        SUENDO,
        ISNULL((SELECT TOP 1 NOKOEN FROM MAEEN WHERE KOEN = ENDO AND SUEN = SUENDO ),'') AS RAZON,
        FEEMDO,
        FEULVEDO,
        KOFUDO,
        SUDO,
        CASE 
            WHEN ESDO = '' THEN 'Vigente'
            WHEN ESDO = 'C' THEN 'Cerrado'
            WHEN ESDO = 'N' THEN 'Nulo'
            ELSE 'Otro' End As ESTADO,
        EMPRESA 
     FROM MAEEDO WITH ( NOLOCK )  
        WHERE  
             EMPRESA='#Empresa#' 
			 #TipoDocumento#--AND TIDO='COV'  
			 #NroDocumento#--AND NUDO IN ('')
			 #Entidad#--AND ENDO='15463484'  AND SUENDO = '' 
             #Fecha#--AND FEEMDO BETWEEN '20140714' AND '20140714' 
            ORDER BY FEEMDO DESC,HORAGRAB DESC  OPTION ( FAST 20 ) 