DECLARE @Fecha DATETIME;
DECLARE @VentaMinima INT = {VentaMinima};
DECLARE @Endo VARCHAR(10) = '{Endo}'            -- Puedes cambiar este valor segun sea necesario
DECLARE @Meses INT = -{Meses};                  -- Puedes cambiar este valor segun sea necesario
DECLARE @VentaEnCurso FLOAT = {VentaEnCurso};   -- Puedes cambiar este valor segun sea necesario

SET @Fecha = DATEADD(MONTH, @Meses, DATEADD(DAY, 1-DAY(GETDATE()), CAST(GETDATE() AS DATE)));
SELECT @Fecha AS PrimerDiaDelMes;

-- Consulta principal
SELECT 
    YEAR(FEEMLI) AS Year,
    MONTH(FEEMLI) AS Mes,
    ENDO,
    TIDO,
    SUM(CAPRCO1) AS CAPRCO1,
    SUM(CAPRAD1) AS CAPRAD1,
    SUM(CAPREX1) AS CAPREX1,
    SUM(CAPRCO1 - (CAPREX1 + CAPRAD1)) AS Saldo,
    CASE 
        WHEN TIDO = 'NVV' THEN SUM(PPPRNE * (CAPRCO1 - (CAPREX1 + CAPRAD1)))
        WHEN TIDO = 'NCV' THEN SUM(VANELI) * -1
        ELSE SUM(VANELI)
    END AS TotalNeto,
    FEEMLI
FROM MAEDDO 
WHERE ENDO = @Endo 
  AND FEEMLI >= @Fecha
  AND TIDO IN ('NVV', 'FCV', 'NCV')
GROUP BY YEAR(FEEMLI), MONTH(FEEMLI), ENDO, TIDO, FEEMLI
ORDER BY Year, Mes;

-- Listado agrupado por año, mes, ENDO y TotalNeto con verificación de VentaMinima y VentaEnCurso en la última fila
WITH Totales AS (
    SELECT 
        YEAR(FEEMLI) AS Year,
        MONTH(FEEMLI) AS Mes,
        ENDO,
        SUM(CASE 
            WHEN TIDO = 'NVV' THEN PPPRNE * (CAPRCO1 - (CAPREX1 + CAPRAD1))
            WHEN TIDO = 'NCV' THEN VANELI * -1
            ELSE VANELI
        END) AS TotalNeto
    FROM MAEDDO 
    WHERE ENDO = @Endo 
      AND FEEMLI >= @Fecha
      AND TIDO IN ('NVV', 'FCV', 'NCV')
    GROUP BY YEAR(FEEMLI), MONTH(FEEMLI), ENDO
),
Cumplimiento AS (
    SELECT 
        Year,
        Mes,
        ENDO,
        CASE 
            WHEN ROW_NUMBER() OVER (ORDER BY Year, Mes) = (SELECT COUNT(*) FROM Totales) THEN TotalNeto + @VentaEnCurso
            ELSE TotalNeto
        END AS TotalNeto,
        CASE 
            WHEN CASE 
                WHEN ROW_NUMBER() OVER (ORDER BY Year, Mes) = (SELECT COUNT(*) FROM Totales) THEN TotalNeto + @VentaEnCurso
                ELSE TotalNeto
            END >= @VentaMinima THEN 'Cumple'
            ELSE 'No Cumple'
        END AS CumpleVentaMinima,
        CASE 
            WHEN CASE 
                WHEN ROW_NUMBER() OVER (ORDER BY Year, Mes) = (SELECT COUNT(*) FROM Totales) THEN TotalNeto + @VentaEnCurso
                ELSE TotalNeto
            END >= @VentaMinima THEN 1
            ELSE 0
        END AS Cumple
    FROM Totales
)
-- Aquí se usa la CTE Cumplimiento
SELECT 
    Year,
    Mes,
    ENDO,
    TotalNeto,
    CumpleVentaMinima,
    Cumple
Into #Cumpli
FROM Cumplimiento
ORDER BY Year, Mes;

Select * From #Cumpli

-- Agrupación final por ENDO y Cumple
-- Esta parte también debe estar dentro del mismo bloque de la consulta
SELECT 
    ENDO,NOKOEN,
    CASE 
        WHEN SUM(Cumple) > 0 THEN 'Cumple'
        ELSE 'No Cumple'
    END AS Cumple,LVEN
FROM #Cumpli
Left Join MAEEN On KOEN = ENDO
GROUP BY ENDO,NOKOEN,LVEN

Drop table #Cumpli
