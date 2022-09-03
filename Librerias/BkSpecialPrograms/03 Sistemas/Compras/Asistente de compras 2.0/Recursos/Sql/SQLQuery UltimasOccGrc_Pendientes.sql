
SELECT TOP (1) ISNULL(MAEDDO_1.IDMAEEDO,0) AS IDMAEEDO,
               KOPRCT As Codigo,
               'Ult. Doc. por recepcionar' AS Obs, 
               ISNULL(MAEDDO_1.TIDO,'') AS Tipo,
               ISNULL(MAEDDO_1.NUDO,'') AS Numero, 
               ISNULL(dbo.MAEEN.NOKOEN,'') AS Razon, 
                ISNULL((Select top 1 NOKOEN From MAEEN Where KOEN = MAEDDO_1.ENDOFI),'') as EntFisica, 
               ISNULL(MAEDDO_1.FEEMLI,'') AS Fecha, 
               ISNULL(MAEDDO_1.CAPRCO1,'') AS CantUd1, 
               ISNULL(MAEDDO_1.UD01PR,'') AS Un1, 
               ISNULL(MAEDDO_1.CAPRCO2,'') AS CantUd2, 
               ISNULL(MAEDDO_1.UD02PR,'') AS Un2 
FROM         dbo.MAEDDO AS MAEDDO_1 LEFT OUTER JOIN
dbo.MAEEN ON MAEDDO_1.ENDO = dbo.MAEEN.KOEN AND MAEDDO_1.SUENDO = dbo.MAEEN.SUEN
WHERE MAEDDO_1.IDMAEDDO In (Select IdOCC From #TablaPaso#) --#IdOcc#
UNION
SELECT TOP (1) ISNULL(MAEDDO_1.IDMAEEDO,0) AS IDMAEEDO, 
               KOPRCT As Codigo, 
               'Ultima recepción' AS [Obs.], 
               ISNULL(MAEDDO_1.TIDO,'') AS Tipo,
               ISNULL(MAEDDO_1.NUDO,'') AS Numero, 
               ISNULL(dbo.MAEEN.NOKOEN,'') AS Razon, 
               ISNULL((Select top 1 NOKOEN From MAEEN Where KOEN = MAEDDO_1.ENDOFI),'') as EntFisica, 
               ISNULL(MAEDDO_1.FEEMLI,'') AS Fecha, 
               ISNULL(MAEDDO_1.CAPRCO1,'') AS CantUd1, 
               ISNULL(MAEDDO_1.UD01PR,'') AS Un1, 
               ISNULL(MAEDDO_1.CAPRCO2,'') AS CantUd2, 
               ISNULL(MAEDDO_1.UD02PR,'') AS Un2 
FROM         dbo.MAEDDO AS MAEDDO_1 LEFT OUTER JOIN
dbo.MAEEN ON MAEDDO_1.ENDO = dbo.MAEEN.KOEN AND MAEDDO_1.SUENDO = dbo.MAEEN.SUEN
WHERE MAEDDO_1.IDMAEDDO = (Select IdGRC From #TablaPaso#) -- #IdGrc#