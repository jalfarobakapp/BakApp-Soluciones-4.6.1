DECLARE @Empresa     AS CHAR(2),
        @ListaPrecio AS VARCHAR(3),
		@Fecha_Desde AS DATETIME,
        @Fecha_Hasta AS DATETIME;

/*
-- Últimos 6 meses
SELECT @Fecha_Desde = '#Fecha_Desde#', -- DATEADD(MONTH,-12,GETDATE()),
       @Fecha_Hasta = '#Fecha_Hasta#', -- GETDATE(),
       @Empresa     = '#Empresa#',
       @ListaPrecio = '#ListaPrecio#';

SELECT 
       Ult.EMPRESA	
       ,Ult.IDMAEEDO
       ,Ult.IDMAEDDO
       ,Ult.TIDO
       ,Ult.NUDO
       ,Ult.SULIDO
       ,Ult.BOSULIDO
       ,Ult.FEEMLI          AS 'FECHA'
       ,Ult.ENDO
       ,Ult.SUENDO
       ,Mae.NOKOEN
       ,Ult.TIPR
       ,Ult.PRCT
       ,Ult.UDTRPR
       ,Ult.RLUDPR
       ,Ult.CAPRCO1
       ,Ult.CAPRCO2
       ,Ult.UD01PR
       ,Ult.UD02PR
	   ,Mp.KOPR              AS 'KOPRCT'
       ,Ult.NOKOPR
       ,Ult.PPPRNE
       ,CAST(0 AS FLOAT)    AS 'Precio_Neto_UN'
       ,CAST(0 AS FLOAT)    AS 'Precio_Bruto_UN'
       ,Ult.PPPRNERE1
       ,Ult.PPPRNERE2
       ,Ult.VANELI
       ,Ult.VABRLI
       ,Mpen.PPUL01
       ,Mpen.PPUL02
       ,Mpen.PM
       ,Fcc.TIDO            AS 'TIDO_FCC'
       ,Fcc.NUDO            AS 'NUDO_FCC'
       ,ISNULL((
               SELECT ROUND(SUM(CR.VALDCR) * 1.0 / NULLIF(Ult.CAPRCO1,0),5)
               FROM MAEDCR CR
               WHERE CR.IDDDODCR = Ult.IDMAEDDO
       ),0) AS 'Flete_Neto'
       ,CAST(0 AS FLOAT)    AS 'Flete_Bruto'
       ,CAST(0 AS FLOAT)    AS 'Costo_FleteBrutoAct'
       ,CAST(0 AS FLOAT)    AS 'Costo_FleteNetoAct'
       ,CAST('' AS VARCHAR(13)) AS 'CodigoOferta'
       ,CAST('' AS VARCHAR(50)) AS 'NombreOferta'
       ,CAST(NULL AS DATETIME)  AS 'FechaInicioOferta'
       ,CAST(NULL AS DATETIME)  AS 'FechaFinOferta'
       ,CAST(0 AS BIT)          AS 'OfertaActiva'
       ,CAST(0 AS FLOAT)        AS 'MontoOferta_Neto'
       ,CAST(0 AS FLOAT)        AS 'MontoOferta'

       -- Nuevos campos
       ,CAST(0 AS FLOAT) AS 'Margen_Oferta_Valor'
       ,CAST(0 AS FLOAT) AS 'Margen_Oferta_Porc'
       ,CAST(0 AS FLOAT) AS 'Markup_Oferta_Porc'

       ,@ListaPrecio       AS 'ListaPrecio'
       ,CAST('' AS CHAR(1)) AS MELT
       ,CAST(0 AS FLOAT) AS 'Precio_ListaNeto'
       ,CAST(0 AS FLOAT) AS 'Precio_ListaBruto'
       ,CAST(0 AS FLOAT) AS 'Margen_Lista_Valor'
       ,CAST(0 AS FLOAT) AS 'Margen_Lista_Porc'
       ,CAST(0 AS FLOAT) AS 'Markup_Lista_Porc'

       ,CAST(0 AS FLOAT) AS 'IVA'
       ,CAST(0 AS FLOAT) AS 'IMP'
       ,CAST(0 AS FLOAT) AS 'IMPUESTOS'

       ,Mp.FMPR
       ,Spf.NOKOFM
       ,Mp.PFPR
       ,Fm.NOKOPF
       ,Mp.HFPR
       ,Sbf.NOKOHF
       ,Mp.MRPR
       ,Mr.NOKOMR
       ,Mp.KOFUPR
       ,Jf.NOKOFU
       ,Mp.ZONAPR
       ,Tz.NOKOCARAC AS 'NOKOZOPR'
       ,Mp.CLALIBPR
       ,Tc.NOKOCARAC AS 'NOCLALIBPR'
Into #Tbl_Paso2
FROM MAEPR Mp WITH (NOLOCK)

   OUTER APPLY (
        SELECT TOP 1 *
        FROM MAEDDO D WITH (NOLOCK)
        WHERE D.KOPRCT = Mp.KOPR
          AND D.TIDO = 'GRC' AND EMPRESA = @Empresa
        ORDER BY D.FEEMLI DESC, D.IDMAEDDO DESC
    ) Ult
    LEFT JOIN MAEEN Mae WITH (NOLOCK) ON Ult.ENDO = Mae.KOEN AND Ult.SUENDO = Mae.SUEN
    LEFT JOIN MAEPREM Mpen WITH (NOLOCK) ON Mpen.KOPR = Mp.KOPR AND Mpen.EMPRESA = @Empresa
    LEFT JOIN MAEDDO Fcc WITH (NOLOCK) ON Ult.IDMAEDDO = Fcc.IDRST AND Fcc.TIDO = 'FCC'
    LEFT JOIN TABFM Spf WITH (NOLOCK) ON Spf.KOFM = Mp.FMPR
    LEFT JOIN TABPF Fm WITH (NOLOCK) ON Fm.KOFM = Mp.FMPR AND Fm.KOPF = Mp.PFPR
    LEFT JOIN TABHF Sbf WITH (NOLOCK) ON Sbf.KOFM = Mp.FMPR AND Sbf.KOPF = Mp.PFPR AND Sbf.KOHF = Mp.HFPR
    LEFT JOIN TABMR Mr WITH (NOLOCK) ON Mr.KOMR = Mp.MRPR
    LEFT JOIN TABFU Jf WITH (NOLOCK) ON Jf.KOFU = Mp.KOFUPR
    LEFT JOIN TABCARAC Tz WITH (NOLOCK) ON Tz.KOCARAC = Mp.ZONAPR AND Tz.KOTABLA = 'ZONAPRODUC'
    LEFT JOIN TABCARAC Tc WITH (NOLOCK) ON Tc.KOCARAC = Mp.CLALIBPR AND Tc.KOTABLA = 'CLALIBPR'
WHERE EXISTS (
        SELECT 1 
        FROM MAEDDO V WITH (NOLOCK)
        WHERE V.KOPRCT = Mp.KOPR
          AND V.TIDO IN ('BLV','FCV')
          AND V.FEEMLI BETWEEN @Fecha_Desde AND @Fecha_Hasta
);
*/

SELECT @Fecha_Desde = '#Fecha_Desde#',
       @Fecha_Hasta = '#Fecha_Hasta#',
       @Empresa     = '#Empresa#',
       @ListaPrecio = '#ListaPrecio#';

---------------------------------------------------------
-- PRODUCTOS CON VENTA EN EL PERIODO
---------------------------------------------------------

SELECT DISTINCT
       V.KOPRCT
INTO #ProductosConVenta
FROM MAEDDO V WITH (NOLOCK)
WHERE V.TIDO IN ('BLV','FCV')
  AND V.FEEMLI BETWEEN @Fecha_Desde AND @Fecha_Hasta;

CREATE CLUSTERED INDEX IX_ProductosConVenta ON #ProductosConVenta (KOPRCT);

---------------------------------------------------------
-- ULTIMA GRC POR PRODUCTO
---------------------------------------------------------

;WITH UltGRC AS (
    SELECT D.EMPRESA,
           D.IDMAEEDO,
           D.IDMAEDDO,
           D.TIDO,
           D.NUDO,
           D.SULIDO,
           D.BOSULIDO,
           D.FEEMLI,
           D.ENDO,
           D.SUENDO,
           D.TIPR,
           D.PRCT,
           D.KOPRCT,
           D.UDTRPR,
           D.RLUDPR,
           D.CAPRCO1,
           D.CAPRCO2,
           D.UD01PR,
           D.UD02PR,
           D.NOKOPR,
           D.PPPRNE,
           D.PPPRNERE1,
           D.PPPRNERE2,
           D.VANELI,
           D.VABRLI,
           D.POTENCIA,
           ROW_NUMBER() OVER (PARTITION BY D.KOPRCT ORDER BY D.FEEMLI DESC, D.IDMAEDDO DESC) AS Rn
    FROM MAEDDO D WITH (NOLOCK)
    INNER JOIN #ProductosConVenta Pv ON Pv.KOPRCT = D.KOPRCT
    WHERE D.TIDO = 'GRC'
      AND D.EMPRESA = @Empresa
)

SELECT
       Ult.EMPRESA
       ,Ult.IDMAEEDO
       ,Ult.IDMAEDDO
       ,Ult.TIDO
       ,Ult.NUDO
       ,Ult.SULIDO
       ,Ult.BOSULIDO
       ,Ult.FEEMLI          AS 'FECHA'
       ,Ult.ENDO
       ,Ult.SUENDO
       ,Mae.NOKOEN
       ,Ult.TIPR
       ,Ult.PRCT
       ,Ult.UDTRPR
       ,Ult.RLUDPR
       ,Ult.CAPRCO1
       ,Ult.CAPRCO2
       ,Ult.UD01PR
       ,Ult.UD02PR
       ,Mp.KOPR              AS 'KOPRCT'
       ,Ult.NOKOPR
       ,Ult.PPPRNE
       ,CAST(0 AS FLOAT)     AS 'Precio_Neto_UN'
       ,CAST(0 AS FLOAT)     AS 'Precio_Bruto_UN'
       ,Ult.PPPRNERE1
       ,Ult.PPPRNERE2
       ,Ult.VANELI
       ,Ult.VABRLI
       ,Mpen.PPUL01
       ,Mpen.PPUL02
       ,Mpen.PM
       ,Fcc.TIDO             AS 'TIDO_FCC'
       ,Fcc.NUDO             AS 'NUDO_FCC'
       ,ISNULL((
                SELECT ROUND(SUM(CR.VALDCR) * 1.0 / NULLIF(Ult.CAPRCO1,0),5)
                FROM MAEDCR CR
                WHERE CR.IDDDODCR = Ult.IDMAEDDO
        ),0) AS 'Flete_Neto'
       ,CAST(0 AS FLOAT)     AS 'Flete_Bruto'
       ,CAST(0 AS FLOAT)     AS 'Costo_FleteBrutoAct'
       ,CAST(0 AS FLOAT)     AS 'Costo_FleteNetoAct'
       ,CAST('' AS VARCHAR(13)) AS 'CodigoOferta'
       ,CAST('' AS VARCHAR(50)) AS 'NombreOferta'
       ,CAST(NULL AS DATETIME)  AS 'FechaInicioOferta'
       ,CAST(NULL AS DATETIME)  AS 'FechaFinOferta'
       ,CAST(0 AS BIT)          AS 'OfertaActiva'
       ,CAST(0 AS FLOAT)        AS 'MontoOferta_Neto'
       ,CAST(0 AS FLOAT)        AS 'MontoOferta'
       ,CAST(0 AS FLOAT)        AS 'Margen_Oferta_Valor'
       ,CAST(0 AS FLOAT)        AS 'Margen_Oferta_Porc'
       ,CAST(0 AS FLOAT)        AS 'Markup_Oferta_Porc'
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
       ,Mp.FMPR
       ,Spf.NOKOFM
       ,Mp.PFPR
       ,Fm.NOKOPF
       ,Mp.HFPR
       ,Sbf.NOKOHF
       ,Mp.MRPR
       ,Mr.NOKOMR
       ,Mp.KOFUPR
       ,Jf.NOKOFU
       ,Mp.ZONAPR
       ,Tz.NOKOCARAC AS 'NOKOZOPR'
       ,Mp.CLALIBPR
       ,Tc.NOKOCARAC AS 'NOCLALIBPR'
INTO #Tbl_Paso2
FROM #ProductosConVenta Pv
INNER JOIN MAEPR Mp WITH (NOLOCK) ON Mp.KOPR = Pv.KOPRCT
LEFT JOIN UltGRC Ult ON Ult.KOPRCT = Pv.KOPRCT AND Ult.Rn = 1
LEFT JOIN MAEEN Mae WITH (NOLOCK) ON Ult.ENDO = Mae.KOEN AND Ult.SUENDO = Mae.SUEN
LEFT JOIN MAEPREM Mpen WITH (NOLOCK) ON Mpen.KOPR = Mp.KOPR AND Mpen.EMPRESA = @Empresa
LEFT JOIN MAEDDO Fcc WITH (NOLOCK) ON Ult.IDMAEDDO = Fcc.IDRST AND Fcc.TIDO = 'FCC'
LEFT JOIN TABFM Spf WITH (NOLOCK) ON Spf.KOFM = Mp.FMPR
LEFT JOIN TABPF Fm WITH (NOLOCK) ON Fm.KOFM = Mp.FMPR AND Fm.KOPF = Mp.PFPR
LEFT JOIN TABHF Sbf WITH (NOLOCK) ON Sbf.KOFM = Mp.FMPR AND Sbf.KOPF = Mp.PFPR AND Sbf.KOHF = Mp.HFPR
LEFT JOIN TABMR Mr WITH (NOLOCK) ON Mr.KOMR = Mp.MRPR
LEFT JOIN TABFU Jf WITH (NOLOCK) ON Jf.KOFU = Mp.KOFUPR
LEFT JOIN TABCARAC Tz WITH (NOLOCK) ON Tz.KOCARAC = Mp.ZONAPR AND Tz.KOTABLA = 'ZONAPRODUC'
LEFT JOIN TABCARAC Tc WITH (NOLOCK) ON Tc.KOCARAC = Mp.CLALIBPR AND Tc.KOTABLA = 'CLALIBPR';

CREATE CLUSTERED INDEX IX_Tbl_Paso2_KOPRCT_FECHA ON #Tbl_Paso2 (KOPRCT, FECHA);


---------------------------------------------------------
-- IMPUESTOS (IVA + IMPUESTOS ESPECÍFICOS)
---------------------------------------------------------

UPDATE T
SET T.IVA = CAST(Mp.POIVPR / 100.0 AS DECIMAL(10,5)),
    T.IMP = CAST(ISNULL((
            SELECT SUM(Im.POIM) / 100.0
            FROM TABIMPR Ip WITH (NOLOCK)
            INNER JOIN TABIM Im WITH (NOLOCK) ON Im.KOIM = Ip.KOIM
            WHERE Ip.KOPR = T.KOPRCT
        ),0) AS DECIMAL(10,5)),
    T.IMPUESTOS = CAST(
            (Mp.POIVPR / 100.0) +
            ISNULL((
                SELECT SUM(Im.POIM) / 100.0
                FROM TABIMPR Ip WITH (NOLOCK)
                INNER JOIN TABIM Im WITH (NOLOCK) ON Im.KOIM = Ip.KOIM
                WHERE Ip.KOPR = T.KOPRCT
            ),0)
        AS DECIMAL(10,5))
FROM #Tbl_Paso2 T
INNER JOIN MAEPR Mp WITH (NOLOCK) ON Mp.KOPR = T.KOPRCT;


---------------------------------------------------------
-- FLETE BRUTO
---------------------------------------------------------

UPDATE #Tbl_Paso2
SET Flete_Bruto =
    CASE 
        WHEN IVA = 0 THEN Flete_Neto
        ELSE ROUND(
                ISNULL(Flete_Neto,0) * (1 + IVA),
            0)
    END;

---------------------------------------------------------
-- COSTO FLETE ACTUAL (CORREGIDO CON IMPUESTOS)
---------------------------------------------------------

UPDATE T
SET Costo_FleteBrutoAct = ROUND(ISNULL(R.RECARGO,0),0),
    Costo_FleteNetoAct  =
        CASE 
            WHEN T.IMPUESTOS = 0 THEN ISNULL(R.RECARGO,0)
            ELSE ISNULL(ROUND(
                    ISNULL(R.RECARGO,0) / NULLIF(1 + T.IVA,0),
                5),0)
        END
FROM #Tbl_Paso2 T
INNER JOIN TABRECPR R WITH (NOLOCK)
        ON R.KOEN = T.ENDO 
       AND R.KOPR = T.KOPRCT;


---------------------------------------------------------
-- PRECIO DE VENTA
---------------------------------------------------------

UPDATE T
SET 
    T.MELT = Pp.MELT,
    T.Precio_ListaBruto =
        CASE 
            WHEN Pp.MELT = 'B' THEN ISNULL(P.PP01UD,0)
            ELSE ROUND(ISNULL(P.PP01UD,0) * (1 + T.IMPUESTOS), 5)
        END,
    T.Precio_ListaNeto =
        CASE 
            WHEN Pp.MELT = 'N' THEN ISNULL(P.PP01UD,0)
            ELSE ISNULL(ROUND(ISNULL(P.PP01UD,0) / NULLIF(1 + T.IMPUESTOS,0), 5),0)
        END
FROM #Tbl_Paso2 T
INNER JOIN TABPRE P WITH (NOLOCK)
        ON P.KOLT = @ListaPrecio 
       AND P.KOPR = T.KOPRCT
INNER JOIN TABPP Pp WITH (NOLOCK)
        ON Pp.KOLT = P.KOLT;

---------------------------------------------------------
-- PRECIO NETO Y BRUTO REAL
-- SE AGREGA EL VALOR DEL FLETE NETO AL NETO
---------------------------------------------------------

UPDATE B
SET Precio_Neto_UN = ISNULL(ROUND(B.VANELI / NULLIF(B.CAPRCO1,0),5),0) + ISNULL(B.Flete_Neto,0),
    Precio_Bruto_UN = ISNULL(ROUND(B.VABRLI / NULLIF(B.CAPRCO1,0),5),0) + ISNULL(B.Flete_Bruto,0)
FROM #Tbl_Paso2 B


---------------------------------------------------------
-- MARGENES SEGUN LISTA DE PRECIOS
---------------------------------------------------------

Update #Tbl_Paso2 Set Margen_Lista_Valor = Precio_ListaNeto - Precio_Neto_UN, 
	Margen_Lista_Porc = (
		Case 
			When ISNULL(Precio_ListaNeto,0)=0 THEN 0 
			Else ROUND(((Precio_ListaNeto - Precio_Neto_UN)/Precio_ListaNeto)*100,2)/100 End)

---------------------------------------------------------
-- OFERTAS ACTIVAS


UPDATE #Tbl_Paso2
SET CodigoOferta = '',
    NombreOferta = '',
    FechaInicioOferta = NULL,
    FechaFinOferta = NULL,
    OfertaActiva = 0,
    MontoOferta = 0;

;WITH Paso2 AS (
    SELECT Mr.*,
           CAST(Mr.FTOFERTA AS DATETIME) AS FTOFERTA_Anterior,
           (CASE WHEN GETDATE() BETWEEN Mr.FIOFERTA AND Mr.FTOFERTA THEN 'Si' ELSE 'No' END) AS Activa
    FROM MAEERES Mr WITH (NOLOCK)
    WHERE Mr.TIPORESE = 'din'
),
MinOferta AS (
    SELECT D.ELEMENTO AS Producto,
           MIN(P.VALDESC) AS MinValDesc
    FROM MAEDRES D WITH (NOLOCK)
    INNER JOIN Paso2 P ON P.CODIGO = D.CODIGO
    WHERE P.Activa = 'Si'
    GROUP BY D.ELEMENTO
)
UPDATE T
SET T.CodigoOferta      = P.CODIGO,
    T.NombreOferta      = P.DESCRIPTOR,
    T.FechaInicioOferta = P.FIOFERTA,
    T.FechaFinOferta    = P.FTOFERTA,
    T.OfertaActiva      = CASE WHEN P.Activa = 'Si' THEN 1 ELSE 0 END,
    T.MontoOferta       = P.VALDESC
FROM #Tbl_Paso2 T
INNER JOIN MAEDRES D WITH (NOLOCK) ON D.ELEMENTO = T.KOPRCT
INNER JOIN Paso2 P ON P.CODIGO = D.CODIGO
INNER JOIN MinOferta M ON M.Producto = D.ELEMENTO AND M.MinValDesc = P.VALDESC
WHERE P.Activa = 'Si';

---------------------------------------------------------
-- MontoOferta NETO (CORREGIDO CON IMPUESTOS)
---------------------------------------------------------

UPDATE #Tbl_Paso2
SET MontoOferta_Neto =
    CASE 
        WHEN IMPUESTOS = 0 THEN MontoOferta
        ELSE ISNULL(ROUND(MontoOferta / NULLIF(1 + IMPUESTOS,0), 5),0)
    END;
-- New

---------------------------------------------------------
-- MARGENES SEGUN OFERTA
---------------------------------------------------------

Update #Tbl_Paso2 Set Margen_Oferta_Valor = MontoOferta_Neto - Precio_Neto_UN, 
	Margen_Oferta_Porc = (
		Case 
			When ISNULL(MontoOferta_Neto,0)=0 THEN 0 
			Else ROUND(((MontoOferta_Neto - Precio_Neto_UN)/MontoOferta_Neto)*100,2)/100 End)
---

---------------------------------------------------------
-- GRC ANTERIOR Y ULTIMA VENTA PRECALCULADOS
---------------------------------------------------------

;WITH GRC_Ant_Cte AS (
    SELECT
        T2.KOPRCT AS 'KOPRCT_Join',
        Ddo.IDMAEEDO        AS 'IDMAEEDO_Ant',
        Ddo.IDMAEDDO        AS 'IDMAEDDO_Ant',
        Ddo.TIDO            AS 'TIDO_Ant',
        Ddo.NUDO            AS 'NUDO_Ant',
        Ddo.FEEMLI          AS 'FECHA_Ant',
        Ddo.ENDO            AS 'ENDO_Ant',
        Ddo.SUENDO          AS 'SUENDO_Ant',
        Ddo.CAPRCO1         AS 'CAPRCO1_Ant',
        Ddo.CAPRCO2         AS 'CAPRCO2_Ant',
        Ddo.PPPRNE          AS 'PPPRNE_Ant',
        ISNULL(ROUND(Ddo.VANELI / NULLIF(Ddo.CAPRCO1,0),5),0) +
        CASE
            WHEN ISNULL(MpAnt.POIVPR,0) = 0 THEN ISNULL(Ddo.POTENCIA,0)
            ELSE ISNULL(ROUND(ISNULL(Ddo.POTENCIA,0) / NULLIF(1 + (ISNULL(MpAnt.POIVPR,0) / 100.0),0),5),0)
        END AS 'Precio_Neto_UN_Ant',
        ISNULL(ROUND(Ddo.VABRLI / NULLIF(Ddo.CAPRCO1,0),5),0) + ROUND(ISNULL(Ddo.POTENCIA,0),0) AS 'Precio_Bruto_UN_Ant',
        Ddo.VANELI          AS 'VANELI_Ant',
        Ddo.VABRLI          AS 'VABRLI_Ant',
        Ddo.PPPRNERE1       AS 'PPPRNERE1_Ant',
        Ddo.PPPRNERE2       AS 'PPPRNERE2_Ant',
        Mpen.PPUL01         AS 'PPUL01_Ant',
        Mpen.PPUL02         AS 'PPUL02_Ant',
        Mpen.PM             AS 'PM_Ant',
        Fcc.TIDO            AS 'TIDO_FCC_Ant',
        Fcc.NUDO            AS 'NUDO_FCC_Ant',
        ROUND(ISNULL(Ddo.POTENCIA,0),0) AS 'Flete_Bruto_Ant',
        CASE
            WHEN ISNULL(MpAnt.POIVPR,0) = 0 THEN ISNULL(Ddo.POTENCIA,0)
            ELSE ISNULL(ROUND(ISNULL(Ddo.POTENCIA,0) / NULLIF(1 + (ISNULL(MpAnt.POIVPR,0) / 100.0),0),5),0)
        END AS 'Flete_Neto_Ant',
        ROUND(ISNULL(Ddo.POTENCIA,0),0) AS 'FLETE_BR_Ant',
        CASE
            WHEN ISNULL(MpAnt.POIVPR,0) = 0 THEN ISNULL(Ddo.POTENCIA,0)
            ELSE ISNULL(ROUND(ISNULL(Ddo.POTENCIA,0) / NULLIF(1 + (ISNULL(MpAnt.POIVPR,0) / 100.0),0),5),0)
        END AS 'FLETE_NT_Ant',
        ROW_NUMBER() OVER (PARTITION BY T2.KOPRCT ORDER BY Ddo.FEEMLI DESC, Ddo.IDMAEDDO DESC) AS Rn
    FROM #Tbl_Paso2 T2
    INNER JOIN MAEDDO Ddo WITH (NOLOCK)
            ON Ddo.TIDO = 'GRC'
           AND Ddo.KOPRCT = T2.KOPRCT
           AND Ddo.FEEMLI < T2.FECHA
           AND Ddo.EMPRESA = @Empresa
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
    KOPRCT_Join,
    IDMAEEDO_Ant,
    IDMAEDDO_Ant,
    TIDO_Ant,
    NUDO_Ant,
    FECHA_Ant,
    ENDO_Ant,
    SUENDO_Ant,
    CAPRCO1_Ant,
    CAPRCO2_Ant,
    PPPRNE_Ant,
    Precio_Neto_UN_Ant,
    Precio_Bruto_UN_Ant,
    VANELI_Ant,
    VABRLI_Ant,
    PPPRNERE1_Ant,
    PPPRNERE2_Ant,
    PPUL01_Ant,
    PPUL02_Ant,
    PM_Ant,
    TIDO_FCC_Ant,
    NUDO_FCC_Ant,
    Flete_Bruto_Ant,
    Flete_Neto_Ant,
    FLETE_BR_Ant,
    FLETE_NT_Ant
INTO #GRC_Ant
FROM GRC_Ant_Cte
WHERE Rn = 1;

CREATE CLUSTERED INDEX IX_GRC_Ant ON #GRC_Ant (KOPRCT_Join);

;WITH Venta_Ant_Cte AS (
    SELECT
        T2.KOPRCT AS 'KOPRCT_Join',
        Ddo.IDMAEEDO        AS 'IDMAEEDO_Vta',
        Ddo.IDMAEDDO        AS 'IDMAEDDO_Vta',
        Ddo.TIDO            AS 'TIDO_Vta',
        Ddo.NUDO            AS 'NUDO_Vta',
        Ddo.TIDO + '-' + Ddo.NUDO AS 'ULT_Vta',
        Ddo.FEEMLI          AS 'FEEMLI_Vta',
        Ddo.ENDO            AS 'ENDO_Vta',
        Ddo.SUENDO          AS 'SUENDO_Vta',
        Ddo.CAPRCO1         AS 'CAPRCO1_Vta',
        Ddo.CAPRCO2         AS 'CAPRCO2_Vta',
        Ddo.PPPRNE          AS 'PPPRNE_Vta',
        ISNULL(ROUND(Ddo.VANELI / NULLIF(Ddo.CAPRCO1,0),2),0) AS 'Precio_Neto_UN_Vta',
        ISNULL(ROUND(Ddo.VABRLI / NULLIF(Ddo.CAPRCO1,0),0),0) AS 'Precio_Bruto_UN_Vta',
        Ddo.VANELI          AS 'VANELI_Vta',
        Ddo.VABRLI          AS 'VABRLI_Vta',
        Ddo.PPPRNERE1       AS 'PPPRNERE1_Vta',
        Ddo.PPPRNERE2       AS 'PPPRNERE2_Vta',
        Mpen.PPUL01         AS 'PPUL01_Vta',
        Mpen.PPUL02         AS 'PPUL02_Vta',
        Mpen.PM             AS 'PM_Vta',
        Ddo.POIMGLLI        AS 'POIMGLLI_Vta',
        Ddo.POIVLI          AS 'POIVLI_Vta',
        ROW_NUMBER() OVER (PARTITION BY T2.KOPRCT ORDER BY Ddo.FEEMLI DESC, Ddo.IDMAEDDO DESC) AS Rn
    FROM #Tbl_Paso2 T2
    INNER JOIN MAEDDO Ddo WITH (NOLOCK)
            ON Ddo.KOPRCT = T2.KOPRCT
           AND Ddo.TIDO IN ('FCV','BLV')
           AND Ddo.FEEMLI BETWEEN @Fecha_Desde AND @Fecha_Hasta
    LEFT JOIN MAEPREM Mpen WITH (NOLOCK)
           ON Mpen.KOPR = Ddo.KOPRCT
          AND Mpen.EMPRESA = @Empresa
)
SELECT
    KOPRCT_Join,
    IDMAEEDO_Vta,
    IDMAEDDO_Vta,
    TIDO_Vta,
    NUDO_Vta,
    ULT_Vta,
    FEEMLI_Vta,
    ENDO_Vta,
    SUENDO_Vta,
    CAPRCO1_Vta,
    CAPRCO2_Vta,
    PPPRNE_Vta,
    Precio_Neto_UN_Vta,
    Precio_Bruto_UN_Vta,
    VANELI_Vta,
    VABRLI_Vta,
    PPPRNERE1_Vta,
    PPPRNERE2_Vta,
    PPUL01_Vta,
    PPUL02_Vta,
    PM_Vta,
    POIMGLLI_Vta,
    POIVLI_Vta
INTO #Venta_Ant
FROM Venta_Ant_Cte
WHERE Rn = 1;

CREATE CLUSTERED INDEX IX_Venta_Ant ON #Venta_Ant (KOPRCT_Join);

SELECT
    T2.*,
    CASE WHEN ISNULL(T2.RLUDPR,0) = 0 THEN 0
         ELSE ROUND(ISNULL(T2.PPPRNERE2,0) / T2.RLUDPR,3)
    END AS 'Ult_Compra',
    ISNULL(Lc.Mcosto,0) AS 'Mcosto',

    ROUND((T2.Precio_Neto_UN - ISNULL(GRC_Ant.Precio_Neto_UN_Ant,0)),2) AS 'Dif_UCCValor',
    CASE WHEN ISNULL(GRC_Ant.Precio_Neto_UN_Ant,0) = 0 OR ISNULL(T2.Precio_Neto_UN,0) = 0 THEN 0
         ELSE ROUND(((T2.Precio_Neto_UN - GRC_Ant.Precio_Neto_UN_Ant) / NULLIF(T2.Precio_Neto_UN,0)) * 100,2) / 100
    END AS 'Dif_UCCPorc',

    CASE
        WHEN T2.TIDO_FCC IS NOT NULL THEN 'Si'
        ELSE 'No'
    END AS TieneFCC,

    CASE
        WHEN GRC_Ant.TIDO_FCC_Ant IS NOT NULL THEN 'Si'
        ELSE 'No'
    END AS TieneFCC_Ant,

    ROUND((ISNULL(Venta_Ant.PPPRNERE1_Vta,0) - T2.Precio_Neto_UN),2) AS 'Margen_Valor',
    CASE WHEN ISNULL(Venta_Ant.PPPRNERE1_Vta,0) = 0 THEN 0
         ELSE ROUND(((Venta_Ant.PPPRNERE1_Vta - T2.Precio_Neto_UN) / Venta_Ant.PPPRNERE1_Vta) * 100,2) / 100
    END AS 'Margen_Porc',
    CASE WHEN ISNULL(T2.Precio_Neto_UN,0) = 0 THEN 0
         ELSE ROUND(((Venta_Ant.PPPRNERE1_Vta - T2.Precio_Neto_UN) / NULLIF(T2.Precio_Neto_UN,0)) * 100,2) / 100
    END AS 'Markup_Porc',

    CASE WHEN ISNULL(T2.MontoOferta_Neto,0) = 0 THEN 0
         ELSE ROUND((ISNULL(T2.MontoOferta_Neto,0) - T2.Precio_Neto_UN),2)
    END AS 'MargenOferta_Valor',
    CASE WHEN ISNULL(T2.MontoOferta_Neto,0) = 0 THEN 0
         ELSE ROUND(((T2.MontoOferta_Neto - T2.Precio_Neto_UN) / T2.MontoOferta_Neto) * 100,2) / 100
    END AS 'MargenOferta_Porc',
    CASE
        WHEN ISNULL(T2.MontoOferta_Neto,0) = 0 THEN 0
        WHEN ISNULL(T2.Precio_Neto_UN,0) = 0 THEN 0
        ELSE ROUND(((T2.MontoOferta_Neto - T2.Precio_Neto_UN) / NULLIF(T2.Precio_Neto_UN,0)) * 100,2) / 100
    END AS 'MarkupOferta_Porc',

    GRC_Ant.IDMAEEDO_Ant,
    GRC_Ant.IDMAEDDO_Ant,
    GRC_Ant.TIDO_Ant,
    GRC_Ant.NUDO_Ant,
    GRC_Ant.FECHA_Ant,
    GRC_Ant.ENDO_Ant,
    GRC_Ant.SUENDO_Ant,
    GRC_Ant.CAPRCO1_Ant,
    GRC_Ant.CAPRCO2_Ant,
    GRC_Ant.PPPRNE_Ant,
    GRC_Ant.Precio_Neto_UN_Ant,
    GRC_Ant.Precio_Bruto_UN_Ant,
    GRC_Ant.VANELI_Ant,
    GRC_Ant.VABRLI_Ant,
    GRC_Ant.PPPRNERE1_Ant,
    GRC_Ant.PPPRNERE2_Ant,
    GRC_Ant.PPUL01_Ant,
    GRC_Ant.PPUL02_Ant,
    GRC_Ant.PM_Ant,
    GRC_Ant.TIDO_FCC_Ant,
    GRC_Ant.NUDO_FCC_Ant,
    GRC_Ant.Flete_Bruto_Ant,
    GRC_Ant.Flete_Neto_Ant,
    GRC_Ant.FLETE_BR_Ant,
    GRC_Ant.FLETE_NT_Ant,

    Venta_Ant.IDMAEEDO_Vta,
    Venta_Ant.IDMAEDDO_Vta,
    Venta_Ant.TIDO_Vta,
    Venta_Ant.NUDO_Vta,
    Venta_Ant.ULT_Vta,
    Venta_Ant.FEEMLI_Vta,
    Venta_Ant.ENDO_Vta,
    Venta_Ant.SUENDO_Vta,
    Venta_Ant.CAPRCO1_Vta,
    Venta_Ant.CAPRCO2_Vta,
    Venta_Ant.PPPRNE_Vta,
    Venta_Ant.Precio_Neto_UN_Vta,
    Venta_Ant.Precio_Bruto_UN_Vta,
    Venta_Ant.VANELI_Vta,
    Venta_Ant.VABRLI_Vta,
    Venta_Ant.PPPRNERE1_Vta,
    Venta_Ant.PPPRNERE2_Vta,
    Venta_Ant.PPUL01_Vta,
    Venta_Ant.PPUL02_Vta,
    Venta_Ant.PM_Vta,
    Venta_Ant.POIMGLLI_Vta,
    Venta_Ant.POIVLI_Vta
FROM #Tbl_Paso2 T2
LEFT JOIN #Global_BaseBk#Zw_ListaLC_ValPro Lc WITH (NOLOCK)
       ON T2.KOPRCT = Lc.Codigo
INNER JOIN #GRC_Ant GRC_Ant
        ON GRC_Ant.KOPRCT_Join = T2.KOPRCT
INNER JOIN #Venta_Ant Venta_Ant
        ON Venta_Ant.KOPRCT_Join = T2.KOPRCT
--#Condicion#
ORDER BY T2.KOPRCT;

DROP TABLE #Venta_Ant;
DROP TABLE #GRC_Ant;
DROP TABLE #Tbl_Paso2;
DROP TABLE #ProductosConVenta;

--SELECT 
--    T2.*,
--    CASE WHEN ISNULL(T2.RLUDPR,0) = 0 THEN 0
--         ELSE ROUND(ISNULL(T2.PPPRNERE2,0) / T2.RLUDPR,3)
--    END AS 'Ult_Compra',
--    ISNULL(Lc.Mcosto,0) AS 'Mcosto',

--    -- Diferencias GRC vs GRC anterior
--    ROUND((T2.Precio_Neto_UN - ISNULL(GRC_Ant.Precio_Neto_UN_Ant,0)),2) AS 'Dif_UCCValor',
--    CASE WHEN ISNULL(GRC_Ant.Precio_Neto_UN_Ant,0) = 0 OR ISNULL(T2.Precio_Neto_UN,0) = 0 THEN 0
--         ELSE ROUND(((T2.Precio_Neto_UN - GRC_Ant.Precio_Neto_UN_Ant) / NULLIF(T2.Precio_Neto_UN,0)) * 100,2) / 100
--    END AS 'Dif_UCCPorc',

--    -- Tiene FCC (solo GRC actual)
--    CASE 
--        WHEN T2.TIDO_FCC IS NOT NULL THEN 'Si' 
--        ELSE 'No' 
--    END AS TieneFCC,

--    -- Tiene FCC anterior (solo GRC anterior)
--    CASE 
--        WHEN GRC_Ant.TIDO_FCC_Ant IS NOT NULL THEN 'Si' 
--        ELSE 'No' 
--    END AS TieneFCC_Ant,

--    ROUND((ISNULL(Venta_Ant.PPPRNERE1_Vta,0) - T2.Precio_Neto_UN),2) AS 'Margen_Valor',
--    CASE WHEN ISNULL(Venta_Ant.PPPRNERE1_Vta,0) = 0 THEN 0
--         ELSE ROUND(((Venta_Ant.PPPRNERE1_Vta - T2.Precio_Neto_UN) / Venta_Ant.PPPRNERE1_Vta) * 100,2) / 100
--    END AS 'Margen_Porc',
--    CASE WHEN ISNULL(T2.Precio_Neto_UN,0) = 0 THEN 0
--         ELSE ROUND(((Venta_Ant.PPPRNERE1_Vta - T2.Precio_Neto_UN) / NULLIF(T2.Precio_Neto_UN,0)) * 100,2) / 100
--    END AS 'Markup_Porc',

--    CASE WHEN ISNULL(T2.MontoOferta_Neto,0) = 0 THEN 0
--         ELSE ROUND((ISNULL(T2.MontoOferta_Neto,0) - T2.Precio_Neto_UN),2) 
--    END AS 'MargenOferta_Valor',
--    CASE WHEN ISNULL(T2.MontoOferta_Neto,0) = 0 THEN 0
--         ELSE ROUND(((T2.MontoOferta_Neto - T2.Precio_Neto_UN) / T2.MontoOferta_Neto) * 100,2) / 100
--    END AS 'MargenOferta_Porc',
--    CASE 
--        WHEN ISNULL(T2.MontoOferta_Neto,0) = 0 THEN 0 
--        ELSE 
--            CASE 
--                WHEN ISNULL(T2.Precio_Neto_UN,0) = 0 THEN 0
--                ELSE ROUND(((T2.MontoOferta_Neto - T2.Precio_Neto_UN) / NULLIF(T2.Precio_Neto_UN,0)) * 100,2) / 100
--            END 
--    END AS 'MarkupOferta_Porc',

--    -- GRC anterior
--    GRC_Ant.*

--    -- Última venta
--    ,Venta_Ant.*

--FROM #Tbl_Paso2 T2
--LEFT JOIN #Global_BaseBk#Zw_ListaLC_ValPro Lc WITH (NOLOCK)
--       ON T2.KOPRCT = Lc.Codigo
--      -- AND (Lc.FechaModif <> '20260909' OR Lc.FechaModif IS NULL)

--CROSS APPLY (
--    SELECT TOP 1
--        Ddo.IDMAEEDO        AS 'IDMAEEDO_Ant',
--        Ddo.IDMAEDDO        AS 'IDMAEDDO_Ant',
--        Ddo.TIDO            AS 'TIDO_Ant',
--        Ddo.NUDO            AS 'NUDO_Ant',
--        Ddo.FEEMLI          AS 'FECHA_Ant',
--        Ddo.ENDO            AS 'ENDO_Ant',
--        Ddo.SUENDO          AS 'SUENDO_Ant',
--        Ddo.CAPRCO1         AS 'CAPRCO1_Ant',
--        Ddo.CAPRCO2         AS 'CAPRCO2_Ant',
--        Ddo.PPPRNE          AS 'PPPRNE_Ant',
--        ISNULL(ROUND(Ddo.VANELI / NULLIF(Ddo.CAPRCO1,0),5),0) +
--        CASE 
--            WHEN ISNULL(MpAnt.POIVPR,0) = 0 THEN ISNULL(Ddo.POTENCIA,0)
--            ELSE ISNULL(ROUND(ISNULL(Ddo.POTENCIA,0) / NULLIF(1 + (ISNULL(MpAnt.POIVPR,0) / 100.0),0),5),0)
--        END AS 'Precio_Neto_UN_Ant',
--        ISNULL(ROUND(Ddo.VABRLI / NULLIF(Ddo.CAPRCO1,0),5),0) + ROUND(ISNULL(Ddo.POTENCIA,0),0) AS 'Precio_Bruto_UN_Ant',
--        Ddo.VANELI          AS 'VANELI_Ant',
--        Ddo.VABRLI          AS 'VABRLI_Ant',
--        Ddo.PPPRNERE1       AS 'PPPRNERE1_Ant',
--        Ddo.PPPRNERE2       AS 'PPPRNERE2_Ant',
--        Mpen.PPUL01         AS 'PPUL01_Ant',
--        Mpen.PPUL02         AS 'PPUL02_Ant',
--        Mpen.PM             AS 'PM_Ant',
--        Fcc.TIDO            AS 'TIDO_FCC_Ant',
--        Fcc.NUDO            AS 'NUDO_FCC_Ant',
--        ROUND(ISNULL(Ddo.POTENCIA,0),0) AS 'Flete_Bruto_Ant',
--        CASE 
--            WHEN ISNULL(MpAnt.POIVPR,0) = 0 THEN ISNULL(Ddo.POTENCIA,0)
--            ELSE ISNULL(ROUND(ISNULL(Ddo.POTENCIA,0) / NULLIF(1 + (ISNULL(MpAnt.POIVPR,0) / 100.0),0),5),0)
--        END AS 'Flete_Neto_Ant',
--        ROUND(ISNULL(Ddo.POTENCIA,0),0) AS 'FLETE_BR_Ant',
--        CASE 
--            WHEN ISNULL(MpAnt.POIVPR,0) = 0 THEN ISNULL(Ddo.POTENCIA,0)
--            ELSE ISNULL(ROUND(ISNULL(Ddo.POTENCIA,0) / NULLIF(1 + (ISNULL(MpAnt.POIVPR,0) / 100.0),0),5),0)
--        END AS 'FLETE_NT_Ant'
--    FROM MAEDDO Ddo WITH (NOLOCK)
--    LEFT JOIN MAEPREM Mpen WITH (NOLOCK) ON Mpen.KOPR = Ddo.KOPRCT AND Mpen.EMPRESA = @Empresa
--    LEFT JOIN MAEDDO Fcc WITH (NOLOCK) ON Ddo.IDMAEDDO = Fcc.IDRST AND Fcc.TIDO = 'FCC'
--    LEFT JOIN MAEPR MpAnt WITH (NOLOCK) ON MpAnt.KOPR = Ddo.KOPRCT
--    WHERE Ddo.TIDO = 'GRC'
--      AND Ddo.KOPRCT = T2.KOPRCT
--      AND Ddo.FEEMLI < T2.FECHA
--      AND Ddo.EMPRESA = @Empresa
--    ORDER BY Ddo.FEEMLI DESC
--) AS GRC_Ant

--CROSS APPLY (
--    SELECT TOP 1
--        Ddo.IDMAEEDO        AS 'IDMAEEDO_Vta',
--        Ddo.IDMAEDDO        AS 'IDMAEDDO_Vta',
--        Ddo.TIDO            AS 'TIDO_Vta',
--        Ddo.NUDO            AS 'NUDO_Vta',
--        Ddo.TIDO + '-' + Ddo.NUDO AS 'ULT_Vta',
--        Ddo.FEEMLI          AS 'FEEMLI_Vta',
--        Ddo.ENDO            AS 'ENDO_Vta',
--        Ddo.SUENDO          AS 'SUENDO_Vta',
--        Ddo.CAPRCO1         AS 'CAPRCO1_Vta',
--        Ddo.CAPRCO2         AS 'CAPRCO2_Vta',
--        Ddo.PPPRNE          AS 'PPPRNE_Vta',
--        ISNULL(ROUND(Ddo.VANELI / NULLIF(Ddo.CAPRCO1,0),2),0) AS 'Precio_Neto_UN_Vta',
--        ISNULL(ROUND(Ddo.VABRLI / NULLIF(Ddo.CAPRCO1,0),0),0) AS 'Precio_Bruto_UN_Vta',
--        Ddo.VANELI          AS 'VANELI_Vta',
--        Ddo.VABRLI          AS 'VABRLI_Vta',
--        Ddo.PPPRNERE1       AS 'PPPRNERE1_Vta',
--        Ddo.PPPRNERE2       AS 'PPPRNERE2_Vta',
--        Mpen.PPUL01         AS 'PPUL01_Vta',
--        Mpen.PPUL02         AS 'PPUL02_Vta',
--        Mpen.PM             AS 'PM_Vta',
--        Ddo.POIMGLLI        AS 'POIMGLLI_Vta',
--        Ddo.POIVLI          AS 'POIVLI_Vta'
--    FROM MAEDDO Ddo WITH (NOLOCK)
--    LEFT JOIN MAEPREM Mpen WITH (NOLOCK) ON Mpen.KOPR = Ddo.KOPRCT AND Mpen.EMPRESA = @Empresa
--    WHERE Ddo.TIDO IN ('FCV','BLV')
--      AND Ddo.KOPRCT = T2.KOPRCT
--      AND Ddo.FEEMLI BETWEEN @Fecha_Desde AND @Fecha_Hasta
--    ORDER BY Ddo.FEEMLI DESC
--) AS Venta_Ant
----#Condicion#

--ORDER BY T2.KOPRCT;

--DROP TABLE #Tbl_Paso2;