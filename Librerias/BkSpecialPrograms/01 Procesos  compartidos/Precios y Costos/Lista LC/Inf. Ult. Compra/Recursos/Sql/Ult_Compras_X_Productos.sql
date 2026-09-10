DECLARE @Empresa     AS CHAR(2),
        @ListaPrecio AS VARCHAR(3),
		@Fecha_Desde AS DATETIME,
        @Fecha_Hasta AS DATETIME;

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
       ,ROUND(Ult.POTENCIA,0) AS 'Flete_Bruto'
       ,CAST(0 AS FLOAT)    AS 'Flete_Neto'
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
FROM MAEPR Mp

   OUTER APPLY (
        SELECT TOP 1 *
        FROM MAEDDO D
        WHERE D.KOPRCT = Mp.KOPR
          AND D.TIDO = 'GRC' AND EMPRESA = @Empresa
        ORDER BY D.FEEMLI DESC, D.IDMAEDDO DESC
    ) Ult
    LEFT JOIN MAEEN Mae ON Ult.ENDO = Mae.KOEN AND Ult.SUENDO = Mae.SUEN
    LEFT JOIN MAEPREM Mpen ON Mpen.KOPR = Mp.KOPR AND Mpen.EMPRESA = @Empresa
    LEFT JOIN MAEDDO Fcc ON Ult.IDMAEDDO = Fcc.IDRST AND Fcc.TIDO = 'FCC'
    LEFT JOIN TABFM Spf ON Spf.KOFM = Mp.FMPR
    LEFT JOIN TABPF Fm ON Fm.KOFM = Mp.FMPR AND Fm.KOPF = Mp.PFPR
    LEFT JOIN TABHF Sbf ON Sbf.KOFM = Mp.FMPR AND Sbf.KOPF = Mp.PFPR AND Sbf.KOHF = Mp.HFPR
    LEFT JOIN TABMR Mr ON Mr.KOMR = Mp.MRPR
    LEFT JOIN TABFU Jf ON Jf.KOFU = Mp.KOFUPR
    LEFT JOIN TABCARAC Tz ON Tz.KOCARAC = Mp.ZONAPR AND Tz.KOTABLA = 'ZONAPRODUC'
    LEFT JOIN TABCARAC Tc ON Tc.KOCARAC = Mp.CLALIBPR AND Tc.KOTABLA = 'CLALIBPR'

WHERE EXISTS (
        SELECT 1
        FROM MAEDDO V
        WHERE V.KOPRCT = Mp.KOPR
          AND V.TIDO IN ('BLV','FCV')
          AND V.FEEMLI BETWEEN @Fecha_Desde AND @Fecha_Hasta
);

---------------------------------------------------------
-- IMPUESTOS (IVA + IMPUESTOS ESPECÍFICOS)
---------------------------------------------------------

UPDATE T
SET T.IVA = CAST(Mp.POIVPR / 100.0 AS DECIMAL(10,5)),
    T.IMP = CAST(ISNULL((
            SELECT SUM(Im.POIM) / 100.0
            FROM TABIMPR Ip
            INNER JOIN TABIM Im ON Im.KOIM = Ip.KOIM
            WHERE Ip.KOPR = T.KOPRCT
        ),0) AS DECIMAL(10,5)),
    T.IMPUESTOS = CAST(
            (Mp.POIVPR / 100.0) +
            ISNULL((
                SELECT SUM(Im.POIM) / 100.0
                FROM TABIMPR Ip
                INNER JOIN TABIM Im ON Im.KOIM = Ip.KOIM
                WHERE Ip.KOPR = T.KOPRCT
            ),0)
        AS DECIMAL(10,5))
FROM #Tbl_Paso2 T
INNER JOIN MAEPR Mp ON Mp.KOPR = T.KOPRCT;


---------------------------------------------------------
-- FLETE NETO (CORREGIDO CON IMPUESTOS)
---------------------------------------------------------

UPDATE #Tbl_Paso2
SET Flete_Neto =
    CASE 
        WHEN IMPUESTOS = 0 THEN Flete_Bruto
        ELSE ROUND(
                ISNULL(Flete_Bruto,0) / (1 + IVA),
            5)
    END;

---------------------------------------------------------
-- COSTO FLETE ACTUAL (CORREGIDO CON IMPUESTOS)
---------------------------------------------------------

UPDATE T
SET Costo_FleteBrutoAct = ROUND(ISNULL(R.RECARGO,0),0),
    Costo_FleteNetoAct  =
        CASE 
            WHEN T.IMPUESTOS = 0 THEN ISNULL(R.RECARGO,0)
            ELSE ROUND(
                    ISNULL(R.RECARGO,0) / (1 + T.IVA),
                5)
        END
FROM #Tbl_Paso2 T
INNER JOIN TABRECPR R 
        ON R.KOEN = T.ENDO 
       AND R.KOPR = T.KOPRCT;


---------------------------------------------------------
-- PRECIO DE VENTA
---------------------------------------------------------

UPDATE T
SET 
    -- MELT siempre se guarda
    T.MELT = Pp.MELT,

    -- Precio Lista Bruto
    T.Precio_ListaBruto =
        CASE 
            WHEN Pp.MELT = 'B' THEN ISNULL(P.PP01UD,0)
            ELSE ROUND(ISNULL(P.PP01UD,0) * (1 + T.IMPUESTOS), 5)
        END,

    -- Precio Lista Neto
    T.Precio_ListaNeto =
        CASE 
            WHEN Pp.MELT = 'N' THEN ISNULL(P.PP01UD,0)
            ELSE ROUND(ISNULL(P.PP01UD,0) / (1 + T.IMPUESTOS), 5)
        END

FROM #Tbl_Paso2 T
INNER JOIN TABPRE P 
        ON P.KOLT = @ListaPrecio 
       AND P.KOPR = T.KOPRCT
INNER JOIN TABPP Pp 
        ON Pp.KOLT = P.KOLT;

---------------------------------------------------------
-- PRECIO BRUTO REAL
---------------------------------------------------------

UPDATE B
SET Precio_Neto_UN = ROUND(B.VANELI/B.CAPRCO1,5), Precio_Bruto_UN = ROUND(B.VABRLI/B.CAPRCO1,5)
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
    FROM MAEERES Mr
    WHERE Mr.TIPORESE = 'din'
),
MinOferta AS (
    SELECT D.ELEMENTO AS Producto,
           MIN(P.VALDESC) AS MinValDesc
    FROM MAEDRES D
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
INNER JOIN MAEDRES D ON D.ELEMENTO = T.KOPRCT
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
        ELSE ROUND(MontoOferta / (1 + (IMPUESTOS)), 5)
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


SELECT 
    T2.*,
    ROUND(ISNULL(T2.PPPRNERE2,0)/ISNULL(T2.RLUDPR,0),3) AS 'Ult_Compra',
    ISNULL(Lc.Mcosto,0) AS 'Mcosto',

    -- Diferencias GRC vs GRC anterior
    ROUND((T2.Precio_Neto_UN - ISNULL(GRC_Ant.Precio_Neto_UN_Ant,0)),2) AS 'Dif_UCCValor',
    CASE WHEN ISNULL(GRC_Ant.Precio_Neto_UN_Ant,0)=0 THEN 0
         ELSE ROUND(((T2.Precio_Neto_UN - GRC_Ant.Precio_Neto_UN_Ant)/T2.Precio_Neto_UN)*100,2)/100
    END AS 'Dif_UCCPorc',

    -- Tiene FCC (solo GRC actual)
    CASE 
        WHEN T2.TIDO_FCC IS NOT NULL THEN 'Si' 
        ELSE 'No' 
    END AS TieneFCC,

    -- Tiene FCC anterior (solo GRC anterior)
    CASE 
        WHEN GRC_Ant.TIDO_FCC_Ant IS NOT NULL THEN 'Si' 
        ELSE 'No' 
    END AS TieneFCC_Ant,

	ROUND((ISNULL(Venta_Ant.PPPRNERE1_Vta,0) - (T2.Precio_Neto_UN)),2) AS 'Margen_Valor',
    CASE WHEN ISNULL(Venta_Ant.PPPRNERE1_Vta,0)=0 THEN 0
         ELSE ROUND(((Venta_Ant.PPPRNERE1_Vta - (T2.Precio_Neto_UN+T2.Flete_Neto))/Venta_Ant.PPPRNERE1_Vta)*100,2)/100
    END AS 'Margen_Porc',
    CASE WHEN ISNULL(T2.Precio_Neto_UN,0)+ISNULL(T2.Flete_Neto,0)=0 THEN 0
         ELSE ROUND(((Venta_Ant.PPPRNERE1_Vta - (T2.Precio_Neto_UN+T2.Flete_Neto))/(T2.Precio_Neto_UN+T2.Flete_Neto))*100,2)/100
    END AS 'Markup_Porc',

	CASE WHEN ISNULL(T2.MontoOferta_Neto,0)=0 THEN 0
		ELSE ROUND((ISNULL(T2.MontoOferta_Neto,0) - (T2.Precio_Neto_UN)),2) 
	END AS 'MargenOferta_Valor',
    CASE WHEN ISNULL(T2.MontoOferta_Neto,0)=0 THEN 0
         ELSE ROUND(((T2.MontoOferta_Neto - (T2.Precio_Neto_UN+T2.Flete_Neto))/T2.MontoOferta_Neto)*100,2)/100
    END AS 'MargenOferta_Porc',
    CASE 
		WHEN ISNULL(T2.MontoOferta_Neto,0)=0 THEN 0 
		ELSE 
			CASE 
				WHEN ISNULL(T2.Precio_Neto_UN,0)+ISNULL(T2.Flete_Neto,0)=0 THEN 0
				ELSE ROUND(((T2.MontoOferta_Neto - (T2.Precio_Neto_UN+T2.Flete_Neto))/(T2.Precio_Neto_UN+T2.Flete_Neto))*100,2)/100
			END 
	END AS 'MarkupOferta_Porc',
    -- GRC anterior
    GRC_Ant.*

    -- Última venta
    ,Venta_Ant.*

FROM #Tbl_Paso2 T2
LEFT JOIN #Global_BaseBk#Zw_ListaLC_ValPro Lc
       ON T2.KOPRCT = Lc.Codigo
      -- AND (Lc.FechaModif <> '20260909' OR Lc.FechaModif IS NULL)
      
       
CROSS APPLY (
    SELECT TOP 1
        Ddo.IDMAEEDO		AS 'IDMAEEDO_Ant',
        Ddo.IDMAEDDO		AS 'IDMAEDDO_Ant',
        Ddo.TIDO			AS 'TIDO_Ant',
        Ddo.NUDO			AS 'NUDO_Ant',
        Ddo.FEEMLI			AS 'FECHA_Ant',
        Ddo.ENDO			AS 'ENDO_Ant',
        Ddo.SUENDO			AS 'SUENDO_Ant',
        Ddo.CAPRCO1			AS 'CAPRCO1_Ant',
        Ddo.CAPRCO2			AS 'CAPRCO2_Ant',
        Ddo.PPPRNE			AS 'PPPRNE_Ant',
		ROUND(Ddo.VANELI/Ddo.CAPRCO1,2) As 'Precio_Neto_UN_Ant',
		ROUND(Ddo.VABRLI/Ddo.CAPRCO1,0) As 'Precio_Bruto_UN_Ant',
		Ddo.VANELI			As 'VANELI_Ant',
		Ddo.VABRLI			As 'VABRLI_Ant',
        Ddo.PPPRNERE1		AS 'PPPRNERE1_Ant',
        Ddo.PPPRNERE2		AS 'PPPRNERE2_Ant',
        Mpen.PPUL01			AS 'PPUL01_Ant',
        Mpen.PPUL02			AS 'PPUL02_Ant',
        Mpen.PM				AS 'PM_Ant',
        Fcc.TIDO			AS 'TIDO_FCC_Ant',
        Fcc.NUDO			AS 'NUDO_FCC_Ant',
        Ddo.POTENCIA		AS 'FLETE_BR_Ant',
        ROUND(ISNULL(Ddo.POTENCIA,0)/1.19,5) AS 'FLETE_NT_Ant'
    FROM MAEDDO Ddo
    LEFT JOIN MAEPREM Mpen ON Mpen.KOPR = Ddo.KOPRCT AND Mpen.EMPRESA = @Empresa
    LEFT JOIN MAEDDO Fcc ON Ddo.IDMAEDDO = Fcc.IDRST AND Fcc.TIDO = 'FCC'
    WHERE Ddo.TIDO = 'GRC'
      AND Ddo.KOPRCT = T2.KOPRCT
      AND Ddo.FEEMLI < T2.FECHA
	  AND Ddo.EMPRESA = @Empresa
    ORDER BY Ddo.FEEMLI DESC
) AS GRC_Ant

CROSS APPLY (
    SELECT TOP 1
        Ddo.IDMAEEDO		AS 'IDMAEEDO_Vta',
        Ddo.IDMAEDDO		AS 'IDMAEDDO_Vta',
        Ddo.TIDO			AS 'TIDO_Vta',
        Ddo.NUDO			AS 'NUDO_Vta',
        Ddo.TIDO+'-'+Ddo.NUDO AS 'ULT_Vta',
        Ddo.FEEMLI			AS 'FEEMLI_Vta',
        Ddo.ENDO			AS 'ENDO_Vta',
        Ddo.SUENDO			AS 'SUENDO_Vta',
        Ddo.CAPRCO1			AS 'CAPRCO1_Vta',
        Ddo.CAPRCO2			AS 'CAPRCO2_Vta',
        Ddo.PPPRNE			AS 'PPPRNE_Vta',
		ROUND(Ddo.VANELI/Ddo.CAPRCO1,2) As 'Precio_Neto_UN_Vta',
		ROUND(Ddo.VABRLI/Ddo.CAPRCO1,0) As 'Precio_Bruto_UN_Vta',
		Ddo.VANELI			AS 'VANELI_Vta',
		Ddo.VABRLI			AS 'VABRLI_Vta',
        Ddo.PPPRNERE1		AS 'PPPRNERE1_Vta',
        Ddo.PPPRNERE2		AS 'PPPRNERE2_Vta',
        Mpen.PPUL01			AS 'PPUL01_Vta',
        Mpen.PPUL02			AS 'PPUL02_Vta',
        Mpen.PM				AS 'PM_Vta',
        Ddo.POIMGLLI		AS 'POIMGLLI_Vta',
        Ddo.POIVLI			AS 'POIVLI_Vta'
    FROM MAEDDO Ddo
    LEFT JOIN MAEPREM Mpen ON Mpen.KOPR = Ddo.KOPRCT AND Mpen.EMPRESA = @Empresa
    WHERE Ddo.TIDO IN ('FCV','BLV')
      AND Ddo.KOPRCT = T2.KOPRCT
      --AND Ddo.FEEMLI < T2.FECHA
      AND Ddo.FEEMLI BETWEEN @Fecha_Desde AND @Fecha_Hasta
    ORDER BY Ddo.FEEMLI DESC
) AS Venta_Ant
--#Condicion#
--Where ((Lc.FechaModif NOT BETWEEN @Fecha_Desde AND @Fecha_Hasta) Or (Lc.FechaModif IS NULL))

ORDER BY T2.KOPRCT;

DROP TABLE #Tbl_Paso2;