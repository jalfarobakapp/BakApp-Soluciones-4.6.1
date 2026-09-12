DECLARE @Fecha_Desde AS DATETIME,
        @Fecha_Hasta AS DATETIME,
        @Empresa     AS CHAR(2),
        @ListaPrecio AS VARCHAR(3);

SELECT @Fecha_Desde = '#Fecha_Desde#',
       @Fecha_Hasta = '#Fecha_Hasta#',
       @Empresa     = '#Empresa#',
       @ListaPrecio = '#ListaPrecio#';

SELECT DISTINCT
        Ddo.IDMAEEDO
       ,Ddo.IDMAEDDO
       ,Ddo.TIDO
       ,Ddo.NUDO
       ,Ddo.SULIDO
       ,Ddo.BOSULIDO
       ,Ddo.FEEMLI As 'FECHA'
       ,Ddo.ENDO
       ,Ddo.SUENDO
       ,MAEEN.NOKOEN
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
       ,CAST(0 AS FLOAT)		As 'Precio_Neto_UN'
	   ,CAST(0 AS FLOAT)		As 'Precio_Bruto_UN'
       ,Ddo.PPPRNERE1		
	   ,Ddo.PPPRNERE2
	   ,Ddo.VANELI
	   ,Ddo.VABRLI
       ,Mpen.PPUL01
       ,Mpen.PPUL02
       ,Mpen.PM
       ,Fcc.TIDO                As 'TIDO_FCC'
       ,Fcc.NUDO                As 'NUDO_FCC'

       ,ISNULL((
                SELECT ROUND(SUM(CR.VALDCR) * 1.0 / NULLIF(Ddo.CAPRCO1,0),5)
                FROM MAEDCR CR
                WHERE CR.IDDDODCR = Ddo.IDMAEDDO
        ),0) AS 'Flete_Neto'	  
	   ,ROUND(Ddo.POTENCIA,0)   AS 'Potencia'
	   ,CAST(0 AS FLOAT)	    AS 'Flete_Bruto'

       ,CAST(0 AS FLOAT)        As 'Costo_FleteBrutoAct'
       ,CAST(0 AS FLOAT)        As 'Costo_FleteNetoAct'
       ,CAST('' AS VARCHAR(13)) As 'CodigoOferta'
       ,CAST('' AS VARCHAR(50)) As 'NombreOferta'
       ,CAST(NULL AS DATETIME)  As 'FechaInicioOferta'
       ,CAST(NULL AS DATETIME)  As 'FechaFinOferta'
       ,CAST(0 AS BIT)          As 'OfertaActiva'
       ,CAST(0 AS FLOAT)		AS 'MontoOferta_Neto'
	   ,CAST(0 AS FLOAT)        As 'MontoOferta'
              
	   ,@ListaPrecio			As 'ListaPrecio'
	   ,Cast('' As Char(1))		As MELT
       ,CAST(0 AS FLOAT)        As 'Precio_ListaNeto'
       ,CAST(0 AS FLOAT)        As 'Precio_ListaBruto'
	   ,CAST(0 AS FLOAT)        As 'Margen_Lista_Valor'
	   ,CAST(0 AS FLOAT)        As 'Margen_Lista_Porc'
	   ,CAST(0 AS FLOAT)        As 'Markup_Lista_Porc'
	   
       -- NUEVOS CAMPOS DE IMPUESTOS
       ,CAST(0 AS FLOAT)		AS 'IVA'
       ,CAST(0 AS FLOAT)		AS 'IMP'
       ,CAST(0 AS FLOAT)		AS 'IMPUESTOS'
       
       ,Isnull(Mp.FMPR,'')		As 'FMPR' 
	   ,Isnull(Spf.NOKOFM,'')	As 'NOKOFM'
	   ,Isnull(Mp.PFPR,'')		As 'PFPR'
	   ,Isnull(Fm.NOKOPF,'')	As 'NOKOPF'
	   ,Isnull(Mp.HFPR,'')		As 'HFPR'
	   ,Isnull(Sbf.NOKOHF,'')	As 'NOKOHF'
	   ,Isnull(Mp.MRPR,'')		As 'MRPR'
	   ,Isnull(Mr.NOKOMR,'')	As 'NOKOMR'
	   ,Isnull(Mp.KOFUPR,'')	As 'KOFUPR'
	   ,Isnull(Jf.NOKOFU,'')	As 'NOKOFU'
       ,ISNULL(Mp.ZONAPR,'')	As 'ZONAPR'
	   ,ISNULL(Tz.NOKOCARAC,'')	As 'NOKOZOPR'
	   ,ISNULL(Mp.CLALIBPR,'')	As 'CLALIBPR'
	   ,ISNULL(Tc.NOKOCARAC,'')	As 'NOCLALIBPR'
INTO #Tbl_Paso2
FROM MAEDDO Ddo
    Left Join MAEEN ON Ddo.ENDO = MAEEN.KOEN AND Ddo.SUENDO = MAEEN.SUEN
        Left Join MAEPREM Mpen ON Mpen.KOPR = Ddo.KOPRCT AND Mpen.EMPRESA = @Empresa
            Left Join MAEDDO Fcc ON Ddo.IDMAEDDO = Fcc.IDRST AND Fcc.TIDO = 'FCC'
                Left Join MAEPR Mp On Mp.KOPR = Ddo.KOPRCT
                    Left Join TABFM Spf On Spf.KOFM = Mp.FMPR
                        Left Join TABPF Fm On Fm.KOFM = Mp.FMPR And Fm.KOPF = Mp.PFPR
                            Left Join TABHF Sbf On Sbf.KOFM = Mp.FMPR And Sbf.KOPF = Mp.PFPR And Sbf.KOHF = Mp.HFPR
                                Left Join TABMR Mr On Mr.KOMR = Mp.MRPR
                                    Left Join TABFU Jf On Jf.KOFU = Mp.KOFUPR
                                        Left Join TABCARAC Tz On Tz.KOCARAC = Mp.ZONAPR And Tz.KOTABLA = 'ZONAPRODUC'
											Left Join TABCARAC Tc On Tc.KOCARAC = Mp.CLALIBPR And Tc.KOTABLA = 'CLALIBPR'
WHERE Ddo.TIDO = 'GRC'
  And Ddo.FEEMLI Between @Fecha_Desde And @Fecha_Hasta
  --
GROUP BY Ddo.IDMAEEDO, Ddo.IDMAEDDO, Ddo.NUDO, Ddo.ENDO, Ddo.SUENDO, MAEEN.NOKOEN,
         Ddo.TIPR, Ddo.PRCT, Ddo.KOPRCT, Ddo.UDTRPR, Ddo.RLUDPR, Ddo.CAPRCO1,
         Ddo.CAPRCO2, Ddo.UD01PR, Ddo.UD02PR, Ddo.PPPRNE, Ddo.NOKOPR, Ddo.FEEMLI,
         Ddo.TIDO, Ddo.SULIDO, Ddo.BOSULIDO, Ddo.PPPRNERE1, Ddo.PPPRNERE2,Ddo.VANELI,Ddo.VABRLI,
         Mpen.PPUL01, Mpen.PPUL02, Mpen.PM, Fcc.TIDO, Fcc.NUDO, Ddo.POTENCIA,
         Mp.FMPR,Spf.NOKOFM,Mp.PFPR,Fm.NOKOPF,Mp.HFPR,Sbf.NOKOHF,
		 Mp.MRPR,Mr.NOKOMR,Mp.KOFUPR,Jf.NOKOFU,Mp.ZONAPR,Tz.NOKOCARAC,Mp.CLALIBPR,Tc.NOKOCARAC;

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
-- FLETE BRUTO 
---------------------------------------------------------

UPDATE #Tbl_Paso2
SET Flete_Bruto =
    CASE 
        WHEN IVA = 0 THEN Flete_Neto
        ELSE ROUND(
                ISNULL(Flete_Neto,0) * (1 + IVA),
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
-- PRECIO NETO Y BRUTO REAL
-- SE AGREGA EL VALOR DEL FLETE NETO AL NETO
---------------------------------------------------------

UPDATE B
SET 
	Precio_Neto_UN = ROUND(B.VANELI/B.CAPRCO1,5)+Flete_Neto, 
	Precio_Bruto_UN = ROUND(B.VABRLI/B.CAPRCO1,5)
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

SELECT 
    T2.*,
    ROUND(ISNULL(T2.PPPRNERE2,0)/ISNULL(T2.RLUDPR,0),3) AS 'Ult_Compra',
    ISNULL(Lc.Mcosto,0) AS 'Mcosto',

    -- Diferencias GRC vs GRC anterior
    ROUND((T2.Precio_Neto_UN - (ISNULL(GRC_Ant.Precio_Neto_UN_Ant,0)+ISNULL(+GRC_Ant.Flete_Neto_Ant,0))),2) AS 'Dif_UCCValor',
    CASE WHEN (ISNULL(GRC_Ant.Precio_Neto_UN_Ant,0)+ISNULL(+GRC_Ant.Flete_Neto_Ant,0))=0 THEN 0
         ELSE ROUND(((T2.Precio_Neto_UN - (GRC_Ant.Precio_Neto_UN_Ant+GRC_Ant.Flete_Neto_Ant))/T2.Precio_Neto_UN)*100,2)/100
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
         ELSE ROUND(((Venta_Ant.PPPRNERE1_Vta - (T2.Precio_Neto_UN))/Venta_Ant.PPPRNERE1_Vta)*100,2)/100
    END AS 'Margen_Porc',
    CASE WHEN ISNULL(T2.Precio_Neto_UN,0)+ISNULL(T2.Flete_Neto,0)=0 THEN 0
         ELSE ROUND(((Venta_Ant.PPPRNERE1_Vta - (T2.Precio_Neto_UN))/(T2.Precio_Neto_UN))*100,2)/100
    END AS 'Markup_Porc',

	CASE WHEN ISNULL(T2.MontoOferta_Neto,0)=0 THEN 0
		ELSE ROUND((ISNULL(T2.MontoOferta_Neto,0) - (T2.Precio_Neto_UN)),2) 
	END AS 'MargenOferta_Valor',
    CASE WHEN ISNULL(T2.MontoOferta_Neto,0)=0 THEN 0
         ELSE ROUND(((T2.MontoOferta_Neto - (T2.Precio_Neto_UN))/T2.MontoOferta_Neto)*100,2)/100
    END AS 'MargenOferta_Porc',
    CASE 
		WHEN ISNULL(T2.MontoOferta_Neto,0)=0 THEN 0 
		ELSE 
			CASE 
				WHEN ISNULL(T2.Precio_Neto_UN,0)+ISNULL(T2.Flete_Neto,0)=0 THEN 0
				ELSE ROUND(((T2.MontoOferta_Neto - (T2.Precio_Neto_UN))/(T2.Precio_Neto_UN))*100,2)/100
			END 
	END AS 'MarkupOferta_Porc',
    -- GRC anterior
    GRC_Ant.*

    -- Última venta
    ,Venta_Ant.*

FROM #Tbl_Paso2 T2
LEFT JOIN #Global_BaseBk#Zw_ListaLC_ValPro Lc
       ON T2.KOPRCT = Lc.Codigo
      --AND (Lc.FechaModif <> '#Fecha_Hasta#' OR Lc.FechaModif IS NULL)
      

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
        ISNULL((
                SELECT ROUND(SUM(CR.VALDCR) * 1.0 / NULLIF(Ddo.CAPRCO1,0),5)
                FROM MAEDCR CR
                WHERE CR.IDDDODCR = Ddo.IDMAEDDO
        ),0) AS 'Flete_Neto_Ant',
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
      AND Ddo.FEEMLI < T2.FECHA
    ORDER BY Ddo.FEEMLI DESC
) AS Venta_Ant
--#Condicion#

ORDER BY T2.KOPRCT;

DROP TABLE #Tbl_Paso2;
