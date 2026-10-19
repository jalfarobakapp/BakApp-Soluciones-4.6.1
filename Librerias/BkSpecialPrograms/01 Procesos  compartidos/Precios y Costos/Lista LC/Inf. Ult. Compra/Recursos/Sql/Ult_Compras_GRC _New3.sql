DECLARE @Fecha_Desde AS DATETIME,
        @Fecha_Hasta AS DATETIME,
        @Empresa     AS CHAR(2),
        @ListaPrecio AS VARCHAR(3);

SELECT @Fecha_Desde = '#Fecha_Desde#',
       @Fecha_Hasta = '#Fecha_Hasta#',
       @Empresa     = '#Empresa#',
       @ListaPrecio = '#ListaPrecio#';

---------------------------------------------------------
-- GRC SELECCIONADAS EN EL PERIODO
-- PRIMER FILTRO LIVIANO: SOLO IDS Y CAMPOS CLAVE
---------------------------------------------------------

SELECT
       Ddo.IDMAEEDO
       ,Ddo.IDMAEDDO
       ,Ddo.KOPRCT
       ,Ddo.FEEMLI
INTO #GRC_Seleccionadas
FROM MAEDDO Ddo WITH (NOLOCK)
WHERE Ddo.TIDO = 'GRC'
  AND Ddo.EMPRESA = @Empresa
  AND Ddo.FEEMLI BETWEEN @Fecha_Desde AND @Fecha_Hasta
  #Condicion_Productos#;

CREATE CLUSTERED INDEX IX_GRC_Seleccionadas_IDMAEDDO
    ON #GRC_Seleccionadas (IDMAEDDO);

CREATE NONCLUSTERED INDEX IX_GRC_Seleccionadas_KOPRCT_FEEMLI
    ON #GRC_Seleccionadas (KOPRCT, FEEMLI, IDMAEDDO);

---------------------------------------------------------
-- DETALLE COMPLETO DE LAS GRC SELECCIONADAS
---------------------------------------------------------

SELECT
       Ddo.IDMAEEDO
       ,Ddo.IDMAEDDO
       ,Ddo.TIDO
       ,Ddo.NUDO
       ,Ddo.SULIDO
       ,Ddo.BOSULIDO
       ,Ddo.FEEMLI AS 'FECHA'
       ,Ddo.ENDO
       ,Ddo.SUENDO
       ,Mae.NOKOEN
       ,Ddo.TIPR
       ,Ddo.PRCT
       ,Ddo.KOPRCT
       ,Ddo.UDTRPR
       ,Ddo.RLUDPR
       ,Ddo.CAPRCO1
       ,Ddo.CAPRCO2
       ,Ddo.UD01PR
       ,Ddo.UD02PR
       ,Ddo.NOKOPR
       ,Ddo.PPPRNE
       ,CAST(0 AS FLOAT)        AS 'Precio_Neto_UN'
       ,CAST(0 AS FLOAT)        AS 'Precio_Bruto_UN'
       ,Ddo.PPPRNERE1
       ,Ddo.PPPRNERE2
       ,Ddo.VANELI
       ,Ddo.VABRLI
       ,Mpen.PPUL01
       ,Mpen.PPUL02
       ,Mpen.PM
       ,Fcc.TIDO                AS 'TIDO_FCC'
       ,Fcc.NUDO                AS 'NUDO_FCC'
       ,CAST(0 AS FLOAT)        AS 'Flete_Neto'
       ,ROUND(Ddo.POTENCIA, 0)  AS 'Potencia'
       ,CAST(0 AS FLOAT)        AS 'Flete_Bruto'
       ,CAST(0 AS FLOAT)        AS 'Costo_FleteBrutoAct'
       ,CAST(0 AS FLOAT)        AS 'Costo_FleteNetoAct'
       ,CAST('' AS VARCHAR(13)) AS 'CodigoOferta'
       ,CAST('' AS VARCHAR(50)) AS 'NombreOferta'
       ,CAST(NULL AS DATETIME)  AS 'FechaInicioOferta'
       ,CAST(NULL AS DATETIME)  AS 'FechaFinOferta'
       ,CAST(0 AS BIT)          AS 'OfertaActiva'
       ,CAST(0 AS FLOAT)        AS 'MontoOferta_Neto'
       ,CAST(0 AS FLOAT)        AS 'MontoOferta'
       ,@ListaPrecio            AS 'ListaPrecio'
       ,CAST('' AS CHAR(1))     AS MELT
       ,CAST(0 AS FLOAT)        AS 'Precio_ListaNeto'
       ,CAST(0 AS FLOAT)        AS 'Precio_ListaBruto'
       ,CAST(0 AS FLOAT)        AS 'Margen_Lista_Valor'
       ,CAST(0 AS FLOAT)        AS 'Margen_Lista_Porc'
       ,CAST(0 AS FLOAT)        AS 'Markup_Lista_Porc'
       ,CAST(0 AS FLOAT)        AS 'IVA'
       ,CAST(0 AS FLOAT)        AS 'IMP'
       ,CAST(0 AS FLOAT)        AS 'IMPUESTOS'
       ,ISNULL(Mp.FMPR, '')      AS 'FMPR'
       ,ISNULL(Spf.NOKOFM, '')   AS 'NOKOFM'
       ,ISNULL(Mp.PFPR, '')      AS 'PFPR'
       ,ISNULL(Fm.NOKOPF, '')    AS 'NOKOPF'
       ,ISNULL(Mp.HFPR, '')      AS 'HFPR'
       ,ISNULL(Sbf.NOKOHF, '')   AS 'NOKOHF'
       ,ISNULL(Mp.MRPR, '')      AS 'MRPR'
       ,ISNULL(Mr.NOKOMR, '')    AS 'NOKOMR'
       ,ISNULL(Mp.KOFUPR, '')    AS 'KOFUPR'
       ,ISNULL(Jf.NOKOFU, '')    AS 'NOKOFU'
       ,ISNULL(Mp.ZONAPR, '')    AS 'ZONAPR'
       ,ISNULL(Tz.NOKOCARAC, '') AS 'NOKOZOPR'
       ,ISNULL(Mp.CLALIBPR, '')  AS 'CLALIBPR'
       ,ISNULL(Tc.NOKOCARAC, '') AS 'NOCLALIBPR'
INTO #Tbl_Paso2
FROM #GRC_Seleccionadas Sel
INNER JOIN MAEDDO Ddo WITH (NOLOCK)
        ON Ddo.IDMAEDDO = Sel.IDMAEDDO
       AND Ddo.IDMAEEDO = Sel.IDMAEEDO
LEFT JOIN MAEEN Mae WITH (NOLOCK)
       ON Ddo.ENDO = Mae.KOEN
      AND Ddo.SUENDO = Mae.SUEN
LEFT JOIN MAEPREM Mpen WITH (NOLOCK)
       ON Mpen.KOPR = Ddo.KOPRCT
      AND Mpen.EMPRESA = @Empresa
LEFT JOIN MAEDDO Fcc WITH (NOLOCK)
       ON Ddo.IDMAEDDO = Fcc.IDRST
      AND Fcc.TIDO = 'FCC'
LEFT JOIN MAEPR Mp WITH (NOLOCK)
       ON Mp.KOPR = Ddo.KOPRCT
LEFT JOIN TABFM Spf WITH (NOLOCK)
       ON Spf.KOFM = Mp.FMPR
LEFT JOIN TABPF Fm WITH (NOLOCK)
       ON Fm.KOFM = Mp.FMPR
      AND Fm.KOPF = Mp.PFPR
LEFT JOIN TABHF Sbf WITH (NOLOCK)
       ON Sbf.KOFM = Mp.FMPR
      AND Sbf.KOPF = Mp.PFPR
      AND Sbf.KOHF = Mp.HFPR
LEFT JOIN TABMR Mr WITH (NOLOCK)
       ON Mr.KOMR = Mp.MRPR
LEFT JOIN TABFU Jf WITH (NOLOCK)
       ON Jf.KOFU = Mp.KOFUPR
LEFT JOIN TABCARAC Tz WITH (NOLOCK)
       ON Tz.KOCARAC = Mp.ZONAPR
      AND Tz.KOTABLA = 'ZONAPRODUC'
LEFT JOIN TABCARAC Tc WITH (NOLOCK)
       ON Tc.KOCARAC = Mp.CLALIBPR
      AND Tc.KOTABLA = 'CLALIBPR';

CREATE CLUSTERED INDEX IX_Tbl_Paso2_KOPRCT_FECHA_IDMAEDDO
    ON #Tbl_Paso2 (KOPRCT, FECHA, IDMAEDDO);

---------------------------------------------------------
-- IMPUESTOS
---------------------------------------------------------

SELECT
       P.KOPRCT AS KOPR
       ,CAST(Mp.POIVPR / 100.0 AS DECIMAL(10,5)) AS IVA
       ,CAST(ISNULL(SUM(Im.POIM) / 100.0, 0) AS DECIMAL(10,5)) AS IMP
       ,CAST((Mp.POIVPR / 100.0) + ISNULL(SUM(Im.POIM) / 100.0, 0) AS DECIMAL(10,5)) AS IMPUESTOS
INTO #ImpuestosPorProducto
FROM (
    SELECT DISTINCT
           KOPRCT
    FROM #Tbl_Paso2
) P
INNER JOIN MAEPR Mp WITH (NOLOCK)
        ON Mp.KOPR = P.KOPRCT
LEFT JOIN TABIMPR Ip WITH (NOLOCK)
       ON Ip.KOPR = P.KOPRCT
LEFT JOIN TABIM Im WITH (NOLOCK)
       ON Im.KOIM = Ip.KOIM
GROUP BY P.KOPRCT,
         Mp.POIVPR;

CREATE CLUSTERED INDEX IX_ImpuestosPorProducto
    ON #ImpuestosPorProducto (KOPR);

UPDATE T
SET T.IVA = I.IVA,
    T.IMP = I.IMP,
    T.IMPUESTOS = I.IMPUESTOS
FROM #Tbl_Paso2 T
INNER JOIN #ImpuestosPorProducto I
        ON I.KOPR = T.KOPRCT;

---------------------------------------------------------
-- FLETE NETO ACTUAL
---------------------------------------------------------

SELECT
       T.IDMAEDDO
       ,ISNULL(ROUND(SUM(CR.VALDCR) * 1.0 / NULLIF(MAX(T.CAPRCO1), 0), 5), 0) AS Flete_Neto
INTO #FleteActual
FROM #Tbl_Paso2 T
LEFT JOIN MAEDCR CR WITH (NOLOCK)
       ON CR.IDDDODCR = T.IDMAEDDO
GROUP BY T.IDMAEDDO;

CREATE CLUSTERED INDEX IX_FleteActual
    ON #FleteActual (IDMAEDDO);

UPDATE T
SET T.Flete_Neto = F.Flete_Neto
FROM #Tbl_Paso2 T
INNER JOIN #FleteActual F
        ON F.IDMAEDDO = T.IDMAEDDO;

---------------------------------------------------------
-- FLETE BRUTO
---------------------------------------------------------

UPDATE #Tbl_Paso2
SET Flete_Bruto =
    CASE
        WHEN IVA = 0 THEN Flete_Neto
        ELSE ROUND(ISNULL(Flete_Neto, 0) * (1 + IVA), 0)
    END;

---------------------------------------------------------
-- COSTO FLETE ACTUAL
---------------------------------------------------------

UPDATE T
SET Costo_FleteBrutoAct = ROUND(ISNULL(R.RECARGO, 0), 0),
    Costo_FleteNetoAct =
        CASE
            WHEN T.IMPUESTOS = 0 THEN ISNULL(R.RECARGO, 0)
            ELSE ISNULL(ROUND(ISNULL(R.RECARGO, 0) / NULLIF(1 + T.IVA, 0), 5), 0)
        END
FROM #Tbl_Paso2 T
INNER JOIN TABRECPR R WITH (NOLOCK)
        ON R.KOEN = T.ENDO
       AND R.KOPR = T.KOPRCT;

---------------------------------------------------------
-- PRECIO DE VENTA
---------------------------------------------------------

UPDATE T
SET T.MELT = Pp.MELT,
    T.Precio_ListaBruto =
        CASE
            WHEN Pp.MELT = 'B' THEN ISNULL(P.PP01UD, 0)
            ELSE ROUND(ISNULL(P.PP01UD, 0) * (1 + T.IMPUESTOS), 5)
        END,
    T.Precio_ListaNeto =
        CASE
            WHEN Pp.MELT = 'N' THEN ISNULL(P.PP01UD, 0)
            ELSE ISNULL(ROUND(ISNULL(P.PP01UD, 0) / NULLIF(1 + T.IMPUESTOS, 0), 5), 0)
        END
FROM #Tbl_Paso2 T
INNER JOIN TABPRE P WITH (NOLOCK)
        ON P.KOLT = @ListaPrecio
       AND P.KOPR = T.KOPRCT
INNER JOIN TABPP Pp WITH (NOLOCK)
        ON Pp.KOLT = P.KOLT;

---------------------------------------------------------
-- PRECIO NETO Y BRUTO REAL
---------------------------------------------------------

UPDATE B
SET Precio_Neto_UN = ISNULL(ROUND(B.VANELI / NULLIF(B.CAPRCO1, 0), 5), 0) + ISNULL(B.Flete_Neto, 0),
    Precio_Bruto_UN = ISNULL(ROUND(B.VABRLI / NULLIF(B.CAPRCO1, 0), 5), 0) + ISNULL(B.Flete_Bruto, 0)
FROM #Tbl_Paso2 B;

---------------------------------------------------------
-- MARGENES SEGUN LISTA DE PRECIOS
---------------------------------------------------------

UPDATE #Tbl_Paso2
SET Margen_Lista_Valor = Precio_ListaNeto - Precio_Neto_UN,
    Margen_Lista_Porc =
        CASE
            WHEN ISNULL(Precio_ListaNeto, 0) = 0 THEN 0
            ELSE ROUND(((Precio_ListaNeto - Precio_Neto_UN) / Precio_ListaNeto) * 100, 2) / 100
        END;

---------------------------------------------------------
-- OFERTAS ACTIVAS
---------------------------------------------------------

UPDATE #Tbl_Paso2
SET CodigoOferta = '',
    NombreOferta = '',
    FechaInicioOferta = NULL,
    FechaFinOferta = NULL,
    OfertaActiva = 0,
    MontoOferta = 0;

;WITH Paso2 AS (
    SELECT
           Mr.*
           ,CAST(Mr.FTOFERTA AS DATETIME) AS FTOFERTA_Anterior
           ,CASE WHEN GETDATE() BETWEEN Mr.FIOFERTA AND Mr.FTOFERTA THEN 'Si' ELSE 'No' END AS Activa
    FROM MAEERES Mr WITH (NOLOCK)
    WHERE Mr.TIPORESE = 'din'
),
MinOferta AS (
    SELECT
           D.ELEMENTO AS Producto
           ,MIN(P.VALDESC) AS MinValDesc
    FROM MAEDRES D WITH (NOLOCK)
    INNER JOIN Paso2 P
            ON P.CODIGO = D.CODIGO
    WHERE P.Activa = 'Si'
    GROUP BY D.ELEMENTO
)
UPDATE T
SET T.CodigoOferta = P.CODIGO,
    T.NombreOferta = P.DESCRIPTOR,
    T.FechaInicioOferta = P.FIOFERTA,
    T.FechaFinOferta = P.FTOFERTA,
    T.OfertaActiva = CASE WHEN P.Activa = 'Si' THEN 1 ELSE 0 END,
    T.MontoOferta = P.VALDESC
FROM #Tbl_Paso2 T
INNER JOIN MAEDRES D WITH (NOLOCK)
        ON D.ELEMENTO = T.KOPRCT
INNER JOIN Paso2 P
        ON P.CODIGO = D.CODIGO
INNER JOIN MinOferta M
        ON M.Producto = D.ELEMENTO
       AND M.MinValDesc = P.VALDESC
WHERE P.Activa = 'Si';

---------------------------------------------------------
-- MONTO OFERTA NETO
---------------------------------------------------------

UPDATE #Tbl_Paso2
SET MontoOferta_Neto =
    CASE
        WHEN IMPUESTOS = 0 THEN MontoOferta
        ELSE ISNULL(ROUND(MontoOferta / NULLIF(1 + IMPUESTOS, 0), 5), 0)
    END;

---------------------------------------------------------
-- GRC ANTERIOR PRECALCULADO
---------------------------------------------------------

;WITH GRC_Ant_Cte AS (
    SELECT
           T2.IDMAEDDO AS IDMAEDDO_Join
           ,Ddo.IDMAEEDO AS 'IDMAEEDO_Ant'
           ,Ddo.IDMAEDDO AS 'IDMAEDDO_Ant'
           ,Ddo.TIDO AS 'TIDO_Ant'
           ,Ddo.NUDO AS 'NUDO_Ant'
           ,Ddo.FEEMLI AS 'FECHA_Ant'
           ,Ddo.ENDO AS 'ENDO_Ant'
           ,Ddo.SUENDO AS 'SUENDO_Ant'
           ,Ddo.CAPRCO1 AS 'CAPRCO1_Ant'
           ,Ddo.CAPRCO2 AS 'CAPRCO2_Ant'
           ,Ddo.PPPRNE AS 'PPPRNE_Ant'
           ,Ddo.VANELI AS 'VANELI_Ant'
           ,Ddo.VABRLI AS 'VABRLI_Ant'
           ,Ddo.PPPRNERE1 AS 'PPPRNERE1_Ant'
           ,Ddo.PPPRNERE2 AS 'PPPRNERE2_Ant'
           ,Mpen.PPUL01 AS 'PPUL01_Ant'
           ,Mpen.PPUL02 AS 'PPUL02_Ant'
           ,Mpen.PM AS 'PM_Ant'
           ,Fcc.TIDO AS 'TIDO_FCC_Ant'
           ,Fcc.NUDO AS 'NUDO_FCC_Ant'
           ,ISNULL(MpAnt.POIVPR, 0) AS 'POIVPR_Ant'
           ,ROW_NUMBER() OVER (PARTITION BY T2.IDMAEDDO ORDER BY Ddo.FEEMLI DESC, Ddo.IDMAEDDO DESC) AS Rn
    FROM #Tbl_Paso2 T2
    INNER JOIN MAEDDO Ddo WITH (NOLOCK)
            ON Ddo.TIDO = 'GRC'
           AND Ddo.EMPRESA = @Empresa
           AND Ddo.KOPRCT = T2.KOPRCT
           AND (
                Ddo.FEEMLI < T2.FECHA OR
                (Ddo.FEEMLI = T2.FECHA AND Ddo.IDMAEDDO < T2.IDMAEDDO)
           )
    LEFT JOIN MAEPREM Mpen WITH (NOLOCK)
           ON Mpen.KOPR = Ddo.KOPRCT
          AND Mpen.EMPRESA = @Empresa
    LEFT JOIN MAEDDO Fcc WITH (NOLOCK)
           ON Ddo.IDMAEDDO = Fcc.IDRST
          AND Fcc.TIDO = 'FCC'
    LEFT JOIN MAEPR MpAnt WITH (NOLOCK)
           ON MpAnt.KOPR = Ddo.KOPRCT
)
SELECT
       IDMAEDDO_Join
       ,IDMAEEDO_Ant
       ,IDMAEDDO_Ant
       ,TIDO_Ant
       ,NUDO_Ant
       ,FECHA_Ant
       ,ENDO_Ant
       ,SUENDO_Ant
       ,CAPRCO1_Ant
       ,CAPRCO2_Ant
       ,PPPRNE_Ant
       ,VANELI_Ant
       ,VABRLI_Ant
       ,PPPRNERE1_Ant
       ,PPPRNERE2_Ant
       ,PPUL01_Ant
       ,PPUL02_Ant
       ,PM_Ant
       ,TIDO_FCC_Ant
       ,NUDO_FCC_Ant
       ,POIVPR_Ant
INTO #GRC_Ant_Base
FROM GRC_Ant_Cte
WHERE Rn = 1;

CREATE CLUSTERED INDEX IX_GRC_Ant_Base
    ON #GRC_Ant_Base (IDMAEDDO_Join);

SELECT
       X.IDMAEDDO_Ant
       ,ISNULL(ROUND(SUM(CR.VALDCR) * 1.0 / NULLIF(MAX(X.CAPRCO1_Ant), 0), 5), 0) AS Flete_Neto_Ant
INTO #FleteGRC_Ant
FROM (
    SELECT DISTINCT
           IDMAEDDO_Ant
           ,CAPRCO1_Ant
    FROM #GRC_Ant_Base
) X
LEFT JOIN MAEDCR CR WITH (NOLOCK)
       ON CR.IDDDODCR = X.IDMAEDDO_Ant
GROUP BY X.IDMAEDDO_Ant;

CREATE CLUSTERED INDEX IX_FleteGRC_Ant
    ON #FleteGRC_Ant (IDMAEDDO_Ant);

SELECT
       B.IDMAEDDO_Join
       ,B.IDMAEEDO_Ant
       ,B.IDMAEDDO_Ant
       ,B.TIDO_Ant
       ,B.NUDO_Ant
       ,B.FECHA_Ant
       ,B.ENDO_Ant
       ,B.SUENDO_Ant
       ,B.CAPRCO1_Ant
       ,B.CAPRCO2_Ant
       ,B.PPPRNE_Ant
       ,ISNULL(ROUND(B.VANELI_Ant / NULLIF(B.CAPRCO1_Ant, 0), 5), 0) + ISNULL(F.Flete_Neto_Ant, 0) AS 'Precio_Neto_UN_Ant'
       ,ISNULL(ROUND(B.VABRLI_Ant / NULLIF(B.CAPRCO1_Ant, 0), 5), 0) +
        CASE
            WHEN B.POIVPR_Ant = 0 THEN ISNULL(F.Flete_Neto_Ant, 0)
            ELSE ROUND(ISNULL(F.Flete_Neto_Ant, 0) * (1 + (B.POIVPR_Ant / 100.0)), 0)
        END AS 'Precio_Bruto_UN_Ant'
       ,B.VANELI_Ant
       ,B.VABRLI_Ant
       ,B.PPPRNERE1_Ant
       ,B.PPPRNERE2_Ant
       ,B.PPUL01_Ant
       ,B.PPUL02_Ant
       ,B.PM_Ant
       ,B.TIDO_FCC_Ant
       ,B.NUDO_FCC_Ant
       ,CASE
            WHEN B.POIVPR_Ant = 0 THEN ISNULL(F.Flete_Neto_Ant, 0)
            ELSE ROUND(ISNULL(F.Flete_Neto_Ant, 0) * (1 + (B.POIVPR_Ant / 100.0)), 0)
        END AS 'Flete_Bruto_Ant'
       ,ISNULL(F.Flete_Neto_Ant, 0) AS 'Flete_Neto_Ant'
       ,CASE
            WHEN B.POIVPR_Ant = 0 THEN ISNULL(F.Flete_Neto_Ant, 0)
            ELSE ROUND(ISNULL(F.Flete_Neto_Ant, 0) * (1 + (B.POIVPR_Ant / 100.0)), 0)
        END AS 'FLETE_BR_Ant'
       ,ISNULL(F.Flete_Neto_Ant, 0) AS 'FLETE_NT_Ant'
INTO #GRC_Ant
FROM #GRC_Ant_Base B
LEFT JOIN #FleteGRC_Ant F
       ON F.IDMAEDDO_Ant = B.IDMAEDDO_Ant;

CREATE CLUSTERED INDEX IX_GRC_Ant
    ON #GRC_Ant (IDMAEDDO_Join);

---------------------------------------------------------
-- ULTIMA VENTA ANTERIOR PRECALCULADA
---------------------------------------------------------

;WITH Venta_Ant_Cte AS (
    SELECT
           T2.IDMAEDDO AS IDMAEDDO_Join
           ,Ddo.IDMAEEDO AS 'IDMAEEDO_Vta'
           ,Ddo.IDMAEDDO AS 'IDMAEDDO_Vta'
           ,Ddo.TIDO AS 'TIDO_Vta'
           ,Ddo.NUDO AS 'NUDO_Vta'
           ,Ddo.TIDO + '-' + Ddo.NUDO AS 'ULT_Vta'
           ,Ddo.FEEMLI AS 'FEEMLI_Vta'
           ,Ddo.ENDO AS 'ENDO_Vta'
           ,Ddo.SUENDO AS 'SUENDO_Vta'
           ,Ddo.CAPRCO1 AS 'CAPRCO1_Vta'
           ,Ddo.CAPRCO2 AS 'CAPRCO2_Vta'
           ,Ddo.PPPRNE AS 'PPPRNE_Vta'
           ,ISNULL(ROUND(Ddo.VANELI / NULLIF(Ddo.CAPRCO1, 0), 2), 0) AS 'Precio_Neto_UN_Vta'
           ,ISNULL(ROUND(Ddo.VABRLI / NULLIF(Ddo.CAPRCO1, 0), 0), 0) AS 'Precio_Bruto_UN_Vta'
           ,Ddo.VANELI AS 'VANELI_Vta'
           ,Ddo.VABRLI AS 'VABRLI_Vta'
           ,Ddo.PPPRNERE1 AS 'PPPRNERE1_Vta'
           ,Ddo.PPPRNERE2 AS 'PPPRNERE2_Vta'
           ,Mpen.PPUL01 AS 'PPUL01_Vta'
           ,Mpen.PPUL02 AS 'PPUL02_Vta'
           ,Mpen.PM AS 'PM_Vta'
           ,Ddo.POIMGLLI AS 'POIMGLLI_Vta'
           ,Ddo.POIVLI AS 'POIVLI_Vta'
           ,ROW_NUMBER() OVER (PARTITION BY T2.IDMAEDDO ORDER BY Ddo.FEEMLI DESC, Ddo.IDMAEDDO DESC) AS Rn
    FROM #Tbl_Paso2 T2
    INNER JOIN MAEDDO Ddo WITH (NOLOCK)
            ON Ddo.KOPRCT = T2.KOPRCT
           AND Ddo.TIDO IN ('FCV', 'BLV')
           AND Ddo.EMPRESA = @Empresa
           AND (
                Ddo.FEEMLI < T2.FECHA OR
                (Ddo.FEEMLI = T2.FECHA AND Ddo.IDMAEDDO < T2.IDMAEDDO)
           )
    LEFT JOIN MAEPREM Mpen WITH (NOLOCK)
           ON Mpen.KOPR = Ddo.KOPRCT
          AND Mpen.EMPRESA = @Empresa
)
SELECT
       IDMAEDDO_Join
       ,IDMAEEDO_Vta
       ,IDMAEDDO_Vta
       ,TIDO_Vta
       ,NUDO_Vta
       ,ULT_Vta
       ,FEEMLI_Vta
       ,ENDO_Vta
       ,SUENDO_Vta
       ,CAPRCO1_Vta
       ,CAPRCO2_Vta
       ,PPPRNE_Vta
       ,Precio_Neto_UN_Vta
       ,Precio_Bruto_UN_Vta
       ,VANELI_Vta
       ,VABRLI_Vta
       ,PPPRNERE1_Vta
       ,PPPRNERE2_Vta
       ,PPUL01_Vta
       ,PPUL02_Vta
       ,PM_Vta
       ,POIMGLLI_Vta
       ,POIVLI_Vta
INTO #Venta_Ant
FROM Venta_Ant_Cte
WHERE Rn = 1;

CREATE CLUSTERED INDEX IX_Venta_Ant
    ON #Venta_Ant (IDMAEDDO_Join);

---------------------------------------------------------
-- RESULTADO FINAL
---------------------------------------------------------

SELECT
       T2.*
       ,CASE
            WHEN ISNULL(T2.RLUDPR, 0) = 0 THEN 0
            ELSE ROUND(ISNULL(T2.PPPRNERE2, 0) / T2.RLUDPR, 3)
        END AS 'Ult_Compra'
       ,ISNULL(Lc.Mcosto, 0) AS 'Mcosto'
       ,ISNULL(NULLIF(Lcr.Estado, ''), 'Pendiente') AS 'Estado'
       ,Lcr.FechaRev AS 'FechaProceso'
       ,ROUND((T2.Precio_Neto_UN - ISNULL(GRC_Ant.Precio_Neto_UN_Ant, 0)), 2) AS 'Dif_UCCValor'
       ,CASE
            WHEN ISNULL(GRC_Ant.Precio_Neto_UN_Ant, 0) = 0 OR ISNULL(T2.Precio_Neto_UN, 0) = 0 THEN 0
            ELSE ROUND(((T2.Precio_Neto_UN - GRC_Ant.Precio_Neto_UN_Ant) / NULLIF(T2.Precio_Neto_UN, 0)) * 100, 2) / 100
        END AS 'Dif_UCCPorc'
       ,CASE
            WHEN T2.TIDO_FCC IS NOT NULL THEN 'Si'
            ELSE 'No'
        END AS TieneFCC
       ,CASE
            WHEN GRC_Ant.TIDO_FCC_Ant IS NOT NULL THEN 'Si'
            ELSE 'No'
        END AS TieneFCC_Ant
       ,ROUND((ISNULL(Venta_Ant.PPPRNERE1_Vta, 0) - T2.Precio_Neto_UN), 2) AS 'Margen_Valor'
       ,CASE
            WHEN ISNULL(Venta_Ant.PPPRNERE1_Vta, 0) = 0 THEN 0
            ELSE ROUND(((Venta_Ant.PPPRNERE1_Vta - T2.Precio_Neto_UN) / Venta_Ant.PPPRNERE1_Vta) * 100, 2) / 100
        END AS 'Margen_Porc'
       ,CASE
            WHEN ISNULL(T2.Precio_Neto_UN, 0) = 0 THEN 0
            ELSE ROUND(((Venta_Ant.PPPRNERE1_Vta - T2.Precio_Neto_UN) / NULLIF(T2.Precio_Neto_UN, 0)) * 100, 2) / 100
        END AS 'Markup_Porc'
       ,CASE
            WHEN ISNULL(T2.MontoOferta_Neto, 0) = 0 THEN 0
            ELSE ROUND((ISNULL(T2.MontoOferta_Neto, 0) - T2.Precio_Neto_UN), 2)
        END AS 'MargenOferta_Valor'
       ,CASE
            WHEN ISNULL(T2.MontoOferta_Neto, 0) = 0 THEN 0
            ELSE ROUND(((T2.MontoOferta_Neto - T2.Precio_Neto_UN) / T2.MontoOferta_Neto) * 100, 2) / 100
        END AS 'MargenOferta_Porc'
       ,CASE
            WHEN ISNULL(T2.MontoOferta_Neto, 0) = 0 THEN 0
            WHEN ISNULL(T2.Precio_Neto_UN, 0) = 0 THEN 0
            ELSE ROUND(((T2.MontoOferta_Neto - T2.Precio_Neto_UN) / NULLIF(T2.Precio_Neto_UN, 0)) * 100, 2) / 100
        END AS 'MarkupOferta_Porc'
       ,GRC_Ant.IDMAEEDO_Ant
       ,GRC_Ant.IDMAEDDO_Ant
       ,GRC_Ant.TIDO_Ant
       ,GRC_Ant.NUDO_Ant
       ,GRC_Ant.FECHA_Ant
       ,GRC_Ant.ENDO_Ant
       ,GRC_Ant.SUENDO_Ant
       ,GRC_Ant.CAPRCO1_Ant
       ,GRC_Ant.CAPRCO2_Ant
       ,GRC_Ant.PPPRNE_Ant
       ,GRC_Ant.Precio_Neto_UN_Ant
       ,GRC_Ant.Precio_Bruto_UN_Ant
       ,GRC_Ant.VANELI_Ant
       ,GRC_Ant.VABRLI_Ant
       ,GRC_Ant.PPPRNERE1_Ant
       ,GRC_Ant.PPPRNERE2_Ant
       ,GRC_Ant.PPUL01_Ant
       ,GRC_Ant.PPUL02_Ant
       ,GRC_Ant.PM_Ant
       ,GRC_Ant.TIDO_FCC_Ant
       ,GRC_Ant.NUDO_FCC_Ant
       ,GRC_Ant.Flete_Bruto_Ant
       ,GRC_Ant.Flete_Neto_Ant
       ,GRC_Ant.FLETE_BR_Ant
       ,GRC_Ant.FLETE_NT_Ant
       ,Venta_Ant.IDMAEEDO_Vta
       ,Venta_Ant.IDMAEDDO_Vta
       ,Venta_Ant.TIDO_Vta
       ,Venta_Ant.NUDO_Vta
       ,Venta_Ant.ULT_Vta
       ,Venta_Ant.FEEMLI_Vta
       ,Venta_Ant.ENDO_Vta
       ,Venta_Ant.SUENDO_Vta
       ,Venta_Ant.CAPRCO1_Vta
       ,Venta_Ant.CAPRCO2_Vta
       ,Venta_Ant.PPPRNE_Vta
       ,Venta_Ant.Precio_Neto_UN_Vta
       ,Venta_Ant.Precio_Bruto_UN_Vta
       ,Venta_Ant.VANELI_Vta
       ,Venta_Ant.VABRLI_Vta
       ,Venta_Ant.PPPRNERE1_Vta
       ,Venta_Ant.PPPRNERE2_Vta
       ,Venta_Ant.PPUL01_Vta
       ,Venta_Ant.PPUL02_Vta
       ,Venta_Ant.PM_Vta
       ,Venta_Ant.POIMGLLI_Vta
       ,Venta_Ant.POIVLI_Vta
FROM #Tbl_Paso2 T2
LEFT JOIN #Global_BaseBk#Zw_ListaLC_ValPro Lc WITH (NOLOCK)
       ON T2.KOPRCT = Lc.Codigo
LEFT JOIN #Global_BaseBk#Zw_ListaLC_ValPro_Recep Lcr WITH (NOLOCK)
       ON Lcr.Idmaeddo = T2.IDMAEDDO
      AND Lcr.Idmaeedo = T2.IDMAEEDO
INNER JOIN #GRC_Ant GRC_Ant
        ON GRC_Ant.IDMAEDDO_Join = T2.IDMAEDDO
INNER JOIN #Venta_Ant Venta_Ant
        ON Venta_Ant.IDMAEDDO_Join = T2.IDMAEDDO
--#Condicion#
ORDER BY T2.KOPRCT,
         T2.FECHA,
         T2.IDMAEDDO;

DROP TABLE #Venta_Ant;
DROP TABLE #GRC_Ant;
DROP TABLE #FleteGRC_Ant;
DROP TABLE #GRC_Ant_Base;
DROP TABLE #FleteActual;
DROP TABLE #ImpuestosPorProducto;
DROP TABLE #Tbl_Paso2;
DROP TABLE #GRC_Seleccionadas;