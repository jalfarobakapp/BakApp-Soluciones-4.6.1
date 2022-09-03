Declare @IdMaeddo Int = #IdMaeddo#



Select Ddo.*,
       CASE WHEN Ddo.UDTRPR = 1 THEN
                        Ddo.UD01PR
                   ELSE Ddo.UD02PR
              END     
              AS 'UD', -- Unidad de transaccion (Caracter)
              CASE WHEN Ddo.TICT = '' THEN
                   CASE
                        WHEN Ddo.UDTRPR = 1 THEN
                             Ddo.CAPRCO1
                        ELSE Ddo.CAPRCO2
                   END     
                   ELSE 0
              END 
              AS 'CANTIDAD',
              Isnull((Select top 1 Mob.OBDO From MAEEDOOB Mob Where Mob.IDMAEEDO = Ddo.IDMAEEDO),'') as 'OBSERVACION_DOC'
              
 From MAEDDO Ddo Where ARCHIRST = 'MAEDDO' AND IDRST = @IdMaeddo



			  