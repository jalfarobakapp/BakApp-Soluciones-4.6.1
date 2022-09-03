

-- DATOS DEL ENCABEZADO DEL DOCUMENTO
DECLARE @IdMaeedo Int = '#IdMaeedo#'

SELECT *,convert(nvarchar, convert(datetime, (HORAGRAB*1.0/3600)/24), 108) AS 'Hora_Emision'
FROM   MAEEDO

Where IDMAEEDO = @IdMaeedo

-- DATOS DETALLE DEL DOCUMENTO
Select *,
       CASE WHEN UDTRPR = 1 THEN
                        UD01PR
                   ELSE UD02PR
              END     
              AS 'UD', -- Unidad de transaccion (Caracter)
              CASE WHEN TICT = '' THEN
                   CASE
                        WHEN UDTRPR = 1 THEN
                             CAPRCO1
                        ELSE CAPRCO2
                   END     
                   ELSE 0
              END 
              AS 'CANTIDAD',
              CASE 
                   WHEN ESLIDO = 'C' AND UDTRPR = 1 THEN
                        CAPRAD1
                   WHEN ESLIDO = 'C' AND UDTRPR = 2 THEN
                        CAPRAD2
                   ELSE          
                        CASE
                             WHEN UDTRPR = 1 THEN
                             CAPREX1
                        ELSE CAPREX2
                        END
              END               
              AS 'DESPACHADO', -- Cantidad Despachada
              CASE 
                   WHEN ESLIDO = 'C' THEN 0
                   ELSE          
                        CASE
                             WHEN UDTRPR = 1 THEN
                                  (CAPRCO1-CAPREX1)
                             ELSE (CAPRCO2-CAPREX2)
                        END
              END               
              AS 'SALDO', -- Saldo Cantidad 
              Isnull((Select top 1 RLUD From MAEPR Where KOPR = KOPRCT),'') as 'RTU',
              Isnull((Select top 1 KOPRTE From MAEPR Where KOPR = KOPRCT),'') as 'COD_TECNICO'
 From MAEDDO 
 Where IDMAEEDO = @IdMaeedo
 #Condicion_Adicional#

 -- OBSERVACIONES DEL DOCUMENTO
 Select * From MAEEDOOB Where IDMAEEDO = @IdMaeedo
 
 
 



