

-- Cerrrando producto: #Descripcion#
UPDATE MAEDDO SET CAPRAD1=0,CAPRAD2=0 WHERE IDMAEDDO=#Idmaeddo#

UPDATE MAEDDO SET ESLIDO=CASE WHEN ROUND(CAPRCO1-CAPRAD1-CAPREX1,5)=0 THEN 'C' ELSE '' END 
	WHERE IDMAEDDO=#Idmaeddo#
UPDATE MAEPR SET  STOCNV1C+=#Caprad1#,STOCNV2C+=#Caprad2# 
	WHERE KOPR = '#Codigo#' 
UPDATE MAEPREM SET STOCNV1C+=#Caprad1#,STOCNV2C+=#Caprad2# 
	WHERE EMPRESA = '#Empresa#' AND KOPR = '#Codigo#' 
UPDATE MAEST SET STOCNV1C+=#Caprad1#,STOCNV2C+=#Caprad2# 
	WHERE EMPRESA='#Empresa#' AND  KOSU='#Sucursal#' AND  KOBO='#Bodega#' AND  KOPR='#Codigo#' 



	