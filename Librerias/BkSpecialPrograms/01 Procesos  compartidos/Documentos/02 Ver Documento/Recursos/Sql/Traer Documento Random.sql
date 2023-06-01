DECLARE @Idmaeedo int 

Select @Idmaeedo = #Idmaeedo#   

SELECT TOP 1 *,
	   SUBSTRING(CONVERT(NVARCHAR, CONVERT(datetime, (EDO.HORAGRAB*1.0/3600)/24), 108),1,5) AS HORA,
	   CAST('' AS Varchar(10)) As NUMECOM,
       ISNULL((SELECT TOP 1 NOKOEN FROM MAEEN WHERE KOEN = EDO.ENDO AND SUEN = EDO.SUENDO),'') AS 'RAZON',
       ISNULL(EDO.ENDOFI,'') AS 'ENT_FISICA',
       ISNULL((SELECT TOP 1 NOKOEN FROM MAEEN WHERE KOEN = EDO.ENDOFI),'') AS 'RAZON_FISICA',
       ISNULL((SELECT TOP 1 NOKOFU FROM TABFU WHERE KOFU = EDO.KOFUDO),'') AS 'FUNCIONARIO',
       ISNULL((SELECT TOP 1 NOTIDO FROM TABTIDO TTD WHERE EDO.TIDO = TTD.TIDO),'') AS 'TIPODOCUMENTO',
       ISNULL((SELECT TOP 1 NOTIDO FROM TABTIDO TTD WHERE EDO.TIDO = TTD.TIDO),'') AS 'NOTIDO',
       Cast('' As Varchar(10)) As LISACTIVA,
       CASE 
            WHEN TIDOELEC = 1 
                THEN 'Si' 
                ELSE 'No' 
       END As 'ELECTRONICO',
       CASE 
            WHEN ESDO = '' THEN 'Vigente'
            WHEN ESDO = 'C' THEN 'Cerrado'
            WHEN ESDO = 'N' THEN 'Nulo'
            ELSE 'Otro' 
       End As 'ESTADO' 
FROM MAEEDO EDO WITH ( NOLOCK )  
WHERE  EDO.IDMAEEDO=@Idmaeedo  


SELECT 
              EDD.IDMAEDDO,
              EDD.IDMAEEDO,
			  EDD.TIDO,
			  EDD.NUDO,
              SUBSTRING(EDD.NULIDO,4,2) AS ITEM,
              EDD.EMPRESA,    -- Empresa de la linea
              EDD.SULIDO,     -- Sucursal de la linea
              EDD.BOSULIDO,   -- Bodega de la linea
              Cast(CASE WHEN TIDO LIKE 'G%' THEN 1 ELSE EDD.LINCONDESP END As Bit) As 'LINCONDESP',  -- Despacho stock
			  EDD.KOFULIDO,   -- Vendedor
			  EDD.NULIDO,     -- Nro. linea
              EDD.KOPRCT,     -- Código producto
              EDD.NOKOPR,     -- Descripcion producto
              EDD.RLUDPR,      -- Rtu
              EDD.UDTRPR,     -- Unidad de transaccion (Número)
              CASE
                   WHEN EDD.UDTRPR = 1 
                   THEN UD01PR
                   ELSE UD02PR
              END     
              AS UD, -- Unidad de transaccion (Caracter)
              CASE WHEN EDD.TICT = '' THEN
                   CASE
                        WHEN EDD.UDTRPR = 1 
                        THEN CAPRCO1
                        ELSE CAPRCO2
                   END     
                   ELSE 0
              END
              AS CANTIDAD, -- Unidad de transaccion (Caracter)
              CASE WHEN EDD.TICT = '' THEN
                   CASE
                        WHEN EDD.UDTRPR = 1 
                        THEN CAPRAD1
                        ELSE CAPRAD1
                   END     
                   ELSE 0
              END
              AS CANT_AUTO_JUST, -- Cantidada autojustificada
              CASE WHEN EDD.TICT = '' THEN
                   CASE
                        WHEN EDD.UDTRPR = 1 
                        THEN CAPREX1
                        ELSE CAPREX1
                   END     
                   ELSE 0
              END  
              AS CANT_POR_RELACION, -- Cantidada quitada desde documento relacionado
              EDD.UD01PR,     -- Unidad 1
              EDD.UD02PR,     -- Unidad 2
              EDD.CAPRCO1,    -- Cantidad documento Ud1
              EDD.CAPRAD1,    -- Cantidad despachada Ud1
              EDD.CAPREX1,    -- Cantidad pendiente de despacho Ud1 // Devengado
              EDD.CAPRCO2,    -- Cantidad documento Ud2
              EDD.CAPRAD2,    -- Cantidad despachada Ud2
              EDD.CAPREX2,    -- Cantidad pendiente de despacho Ud2 // Devengado
              CASE WHEN EDD.TIPR IN ('FPN','FIN','FUN') THEN
				CASE
					WHEN EDD.UDTRPR = 1 
                        THEN (EDD.CAPRCO1-(EDD.CAPRAD1+EDD.CAPREX1))
					    ELSE (EDD.CAPRCO2-(EDD.CAPRAD2+EDD.CAPREX2))
				END     
			  ELSE 0 
			  END 
			  AS SALDO,   -- Saldo Cantidad
              EDD.KOLTPR,     -- Lista de precios de la línea
              EDD.MOPPPR,     -- Moneda de la línea
              EDD.TIMOPPPR,   -- Tipo de Moneda, Nacional o Extranjera
              EDD.TAMOPPPR,   -- Tipo de cambio
              EDD.PPPRNE,     -- Precio Neto del producto Unidad de venta
              EDD.PPPRBR,     -- Precio Bruto del producto Unidad de venta
              EDD.PPPRPM,     -- Costo Promedio al momento de la transacción, por documento
              EDD.PODTGLLI,   -- Porcentaje de descuento de la linea 
              CASE 
                   WHEN EDD.PODTGLLI > 0 
                    THEN EDD.PODTGLLI/100 
                    ELSE 0
              END 
              AS PC_DESC,     -- Porcentaje de descuento de la linea 
              EDD.VADTNELI,   -- Valor Neto descuento de la linea 
			  EDD.POIVLI,     -- Porcentaje IVA
			  EDD.POIMGLLI,   -- Porcentaje Otros Impuestos
			  EDD.VAIVLI,	  -- Valor IVA linea	
			  EDD.VAIMLI,     -- Valor Otros Impuestos linea
              EDD.VANELI,     -- Valor Neto de la linea (total neto)
              EDD.VADTBRLI,   -- Valor Bruto descuento de la linea 
              EDD.VABRLI,     -- Valor Bruto de la linea (total neto)
              EDD.TIDOPA,     -- Tipo de documento sustentatorio
			  EDD.NUDOPA,     -- Nro. de documento sustentatorio
			  EDD.ENDOPA,     -- Entidad del documento sustentatorio
			  EDD.NULIDOPA,   -- Nro. de la linea del documento sustentatorio
			  EDD.ARCHIRST,   -- Tabla de origen del documento sustentatorio
			  EDD.IDRST,      -- Indice del documento sustentatorio
			  EDD.ESLIDO,     -- Estado de la línea
			  EDD.TIPR,		  -- Tipo de producto	
			  EDD.PRCT,	      -- Es producto (0) o concepto (1)
			  EDD.TICT,		  -- Tipo de Concepto (R) Recargo, (D) Descuento
			  CASE 
				WHEN ESLIDO = '' THEN 'Vigente'
				WHEN ESLIDO = 'C' THEN 'Cerrado'
				WHEN ESLIDO = 'N' THEN 'Nulo'
                ELSE 'Otro' 
              End As 'ESTADO',
			  EDD.LILG,    
			  EDD.FEERLI,     --
			  EDD.OBSERVA,    -- Observacion de la linea
			  ISNULL((SELECT TOP 1 IDMAEEDO FROM MAEDDO WHERE IDMAEDDO = EDD.IDRST),'') AS IDMAEEDO_PA,
			  SUBSTRING( EDD.KOLTPR,6,3) AS 'LISTA', -- Lista de precios o costos
			  EDD.ALTERNAT,    -- Código alternativo del proveedor
              EDD.POTENCIA
			  
   FROM MAEDDO EDD 
   WHERE  
        EDD.IDMAEEDO=@Idmaeedo  
        ORDER BY EDD.IDMAEDDO ,EDD.NULIDO  
        
SELECT * FROM MAEEDOOB
WHERE IDMAEEDO = @Idmaeedo        

SELECT TOP 1 CCOMPRD1.*,NUMECOM,PERIODO 
FROM CCOMPRD1  WITH ( NOLOCK ) 
	INNER JOIN CCOMPRD ON CCOMPRD1.IDCOMPRD = CCOMPRD.IDCOMPRD 
		INNER JOIN CCOMPRE ON CCOMPRD.IDCOMPRE = CCOMPRE.IDCOMPRE  
		WHERE CCOMPRD1.ARCHIRST='MAEEDO' AND CCOMPRD1.IDRST=@Idmaeedo 

SELECT * FROM MAEVEN Where IDMAEEDO = @Idmaeedo
        
