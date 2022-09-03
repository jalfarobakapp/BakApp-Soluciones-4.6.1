
SELECT TOP (1) 
              'Ult. Guía' AS Obs, 
               ISNULL(EDD.TIDO,'') AS Tipo,
               ISNULL(EDD.NUDO,'') AS Numero, 
               ISNULL(dbo.MAEEN.NOKOEN,'') AS Razon, 
                ISNULL((Select top 1 NOKOEN From MAEEN Where KOEN = EDD.ENDOFI),'') as EntFisica, 
               ISNULL(EDD.FEEMLI,'') AS Fecha, 
               CASE WHEN EDD.UDTRPR = 1 THEN EDD.UD01PR ELSE EDD.UD02PR END AS 'UD',
               CASE WHEN EDD.UDTRPR = 1 THEN CAPRCO1 ELSE CAPRCO2 END AS 'Cant',
               EDD.PPPRNE,     -- Precio neto del producto Unidad de venta
               EDD.PODTGLLI,   -- Porcentaje de descuento de la linea 
               CASE 
                   WHEN EDD.PODTGLLI > 0 THEN EDD.PODTGLLI/100 
                   ELSE 0
               END 
               AS PC_DESC,     -- Porcentaje de descuento de la linea 
               EDD.VADTNELI,   -- Valor descuento de la linea 
               EDD.VANELI     -- Valor Neto de la linea (total neto)
FROM         dbo.MAEDDO AS EDD LEFT OUTER JOIN
dbo.MAEEN ON EDD.ENDO = dbo.MAEEN.KOEN AND EDD.SUENDO = dbo.MAEEN.SUEN
WHERE EDD.IDMAEDDO = #IdGrc#
UNION
SELECT TOP (1) 
              'Ult. Factura' AS Obs, 
              ISNULL(EDD.TIDO,'') AS Tipo,
               ISNULL(EDD.NUDO,'') AS Numero, 
               ISNULL(dbo.MAEEN.NOKOEN,'') AS Razon, 
                ISNULL((Select top 1 NOKOEN From MAEEN Where KOEN = EDD.ENDOFI),'') as EntFisica, 
               ISNULL(EDD.FEEMLI,'') AS Fecha, 
               CASE WHEN EDD.UDTRPR = 1 THEN EDD.UD01PR ELSE EDD.UD02PR END AS 'UD',
               CASE WHEN EDD.UDTRPR = 1 THEN CAPRCO1 ELSE CAPRCO2 END AS 'Cant',
               EDD.PPPRNE,     -- Precio neto del producto Unidad de venta
               EDD.PODTGLLI,   -- Porcentaje de descuento de la linea 
               CASE 
                   WHEN EDD.PODTGLLI > 0 THEN EDD.PODTGLLI/100 
                   ELSE 0
               END 
               AS PC_DESC,     -- Porcentaje de descuento de la linea 
               EDD.VADTNELI,   -- Valor descuento de la linea 
               EDD.VANELI     -- Valor Neto de la linea (total neto)
FROM         dbo.MAEDDO AS EDD LEFT OUTER JOIN
dbo.MAEEN ON EDD.ENDO = dbo.MAEEN.KOEN AND EDD.SUENDO = dbo.MAEEN.SUEN
WHERE EDD.IDMAEDDO = #IdFcc#