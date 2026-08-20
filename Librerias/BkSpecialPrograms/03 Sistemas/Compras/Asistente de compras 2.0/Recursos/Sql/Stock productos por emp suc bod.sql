DECLARE 
@Empresa char(2),
@Codigo char(13)

select @Empresa = '#Empresa#',
       @Codigo = '#Codigo#'


CREATE TABLE [dbo].[#Paso] (
    [Orden]                         [Int]           DEFAULT (0),
    [CodPermiso]                    [Char](10)      DEFAULT '',
    [Empresa]                       [Char](2)       DEFAULT '',
    [Sucursal]                      [Char](3)       DEFAULT '',
	[Bodega]                        [Char](3)       DEFAULT '',
    [EMP_SUC_BOD]                   [Varchar](8)    DEFAULT '',
    [SUC_BOD]                       [Char](6)       DEFAULT '',
    [NOKOBO]                        [Varchar](50)   DEFAULT (0),
	[Codigo]                        [VarChar](13)   DEFAULT '',
	[ST_FISICO]                     [Float]         DEFAULT (0),
	[ST_DEVENGADO]                  [Float]         DEFAULT (0),
	[ST_DESP_SIN_FACTURAR]          [Float]         DEFAULT (0),
    [ST_TRANSITO]                   [Float]         DEFAULT (0),    
	[ST_COMPROMETIDO]               [Float]         DEFAULT (0),
	[ST_COMPROMETIDO_BK]            [Float]         DEFAULT (0), 
	[ST_DISPONIBLE]                 [Float]         DEFAULT (0),
	[ST_COMPRAS_NO_RECEPCIONADAS]   [Float]         DEFAULT (0),
	[ST_RECEP_SIN_FACTURAR]         [Float]         DEFAULT (0),
	[ST_PEDIDO]                     [Float]         DEFAULT (0),
	[ST_PEDIDO_BK]                  [Float]         DEFAULT (0),	
	)

/* ============================================================
   1) CARGAR BODEGAS DE LA EMPRESA CONSULTADA
   ============================================================ */
Insert Into #Paso (CodPermiso,Empresa,Sucursal,Bodega,EMP_SUC_BOD,SUC_BOD,NOKOBO,Codigo,
                   ST_FISICO,ST_DEVENGADO,ST_DESP_SIN_FACTURAR,ST_TRANSITO,ST_COMPROMETIDO,ST_COMPROMETIDO_BK,ST_DISPONIBLE,
                   ST_COMPRAS_NO_RECEPCIONADAS,ST_RECEP_SIN_FACTURAR,ST_PEDIDO,ST_PEDIDO_BK)
Select 
    'Bo'+EMPRESA+KOSU+KOBO,
    EMPRESA,
    KOSU,
    KOBO,
    Ltrim(Rtrim(EMPRESA))+Ltrim(Rtrim(KOSU))+Ltrim(Rtrim(KOBO)),
    KOSU+KOBO,
    NOKOBO,
    @Codigo,
    0,0,0,0,0,0,0,0,0,0,0
From TABBO 
Where 1 > 0
And EMPRESA = @Empresa

/* ============================================================
   2) ORDEN DE BODEGAS
   ============================================================ */
--Update #Paso Set Orden = Isnull((Select Orden From #Global_BaseBk#Zw_TablaDeCaracterizaciones 
--						                        		 Where Tabla = '#Tabla#' And CodigoTabla = EMP_SUC_BOD),0)

UPDATE #Paso 
SET Orden = ISNULL((
        SELECT Orden 
        FROM #Global_BaseBk#Zw_TablaDeCaracterizaciones 
        WHERE Tabla = '#Tabla#' 
          AND CodigoTabla = EMP_SUC_BOD
    ),0)


/* ============================================================
   3) STOCK REAL (TODO EN UNIDAD 2)
   ============================================================ */

--Update #Paso Set 
--			ST_FISICO = Isnull((Select Sum(STFI#Ud#) From MAEST Where EMPRESA = Empresa And KOSU = Sucursal And KOBO = Bodega And KOPR In #Codigos#),0),
--			ST_DEVENGADO = Isnull((Select Sum(STDV#Ud#) From MAEST Where EMPRESA = Empresa And KOSU = Sucursal And KOBO = Bodega And KOPR In #Codigos#),0),
--			ST_DESP_SIN_FACTURAR = Isnull((Select Sum(DESPNOFAC#Ud#) From MAEST Where EMPRESA = Empresa And KOSU = Sucursal And KOBO = Bodega And KOPR In #Codigos#),0),
--			ST_COMPROMETIDO = Isnull((Select Sum(STOCNV#Ud#) From MAEST Where EMPRESA = Empresa And KOSU = Sucursal And KOBO = Bodega And KOPR In #Codigos#),0),
--			--ST_DISPONIBLE = Isnull((Select Sum(STFI#Ud#-STOCNV#Ud#) From MAEST Where EMPRESA = Empresa And KOSU = Sucursal And KOBO = Bodega And KOPR In #Codigos#),0),
--			ST_COMPRAS_NO_RECEPCIONADAS = Isnull((Select Sum(STDV#Ud#C) From MAEST Where EMPRESA = Empresa And KOSU = Sucursal And KOBO = Bodega And KOPR In #Codigos#),0),
--			ST_RECEP_SIN_FACTURAR = Isnull((Select Sum(RECENOFAC#Ud#) From MAEST Where EMPRESA = Empresa And KOSU = Sucursal And KOBO = Bodega And KOPR In #Codigos#),0),
--			ST_PEDIDO = Isnull((Select Sum(STOCNV#Ud#C) From MAEST Where EMPRESA = Empresa And KOSU = Sucursal And KOBO = Bodega And KOPR In #Codigos#),0),

--            ST_COMPROMETIDO_BK = Isnull((Select Sum(StComp#Ud#) From #Global_BaseBk#Zw_Prod_Stock Stk Where Stk.Empresa = #Paso.Empresa And Stk.Sucursal = #Paso.Sucursal And Stk.Bodega = #Paso.Bodega And Stk.Codigo In #Codigos#),0), --
--			ST_PEDIDO_BK = Isnull((Select Sum(StPedi#Ud#) From #Global_BaseBk#Zw_Prod_Stock Stk Where Stk.Empresa = #Paso.Empresa And Stk.Sucursal = #Paso.Sucursal And Stk.Bodega = #Paso.Bodega And Stk.Codigo In #Codigos#),0) --

UPDATE P
SET 
    ST_FISICO = ISNULL((SELECT SUM(STFI#Ud#) FROM MAEST 
                        WHERE EMPRESA=P.Empresa AND KOSU=P.Sucursal AND KOBO=P.Bodega AND KOPR In #Codigos#),0),

    ST_DEVENGADO = ISNULL((SELECT SUM(STDV#Ud#) FROM MAEST 
                           WHERE EMPRESA=P.Empresa AND KOSU=P.Sucursal AND KOBO=P.Bodega AND KOPR In #Codigos#),0),

    ST_DESP_SIN_FACTURAR = ISNULL((SELECT SUM(DESPNOFAC#Ud#) FROM MAEST 
                                   WHERE EMPRESA=P.Empresa AND KOSU=P.Sucursal AND KOBO=P.Bodega AND KOPR In #Codigos#),0),

    ST_TRANSITO = ISNULL((SELECT SUM(STTR#Ud#) FROM MAEST 
                          WHERE EMPRESA=P.Empresa AND KOSU=P.Sucursal AND KOBO=P.Bodega AND KOPR In #Codigos#),0),

    ST_COMPROMETIDO = ISNULL((SELECT SUM(STOCNV#Ud#) FROM MAEST 
                              WHERE EMPRESA=P.Empresa AND KOSU=P.Sucursal AND KOBO=P.Bodega AND KOPR In #Codigos#),0),

    ST_COMPRAS_NO_RECEPCIONADAS = ISNULL((SELECT SUM(STDV#Ud#C) FROM MAEST 
                                          WHERE EMPRESA=P.Empresa AND KOSU=P.Sucursal AND KOBO=P.Bodega AND KOPR In #Codigos#),0),

    ST_RECEP_SIN_FACTURAR = ISNULL((SELECT SUM(RECENOFAC#Ud#) FROM MAEST 
                                    WHERE EMPRESA=P.Empresa AND KOSU=P.Sucursal AND KOBO=P.Bodega AND KOPR In #Codigos#),0),

    ST_PEDIDO = ISNULL((SELECT SUM(STOCNV#Ud#C) FROM MAEST 
                        WHERE EMPRESA=P.Empresa AND KOSU=P.Sucursal AND KOBO=P.Bodega AND KOPR In #Codigos#),0),

    ST_COMPROMETIDO_BK = ISNULL((SELECT SUM(StComp#Ud#) FROM #Global_BaseBk#Zw_Prod_Stock 
                                 WHERE Empresa=P.Empresa AND Sucursal=P.Sucursal AND Bodega=P.Bodega AND Codigo In #Codigos#),0),

    ST_PEDIDO_BK = ISNULL((SELECT SUM(StPedi#Ud#) FROM #Global_BaseBk#Zw_Prod_Stock 
                           WHERE Empresa=P.Empresa AND Sucursal=P.Sucursal AND Bodega=P.Bodega AND Codigo In #Codigos#),0)
FROM #Paso P



/* ============================================================
   4) CONSOLIDACIÓN BIDIRECCIONAL (01 ↔ 02) EN UNIDAD 2
   ============================================================ */
UPDATE P
SET 
    -- Si la bodega principal tiene negativo, lo tratamos como 0 para el cálculo con equivalencia, 
    -- o sumamos únicamente los positivos equivalentes.
    ST_FISICO = CASE WHEN ST_FISICO < 0 THEN 0 ELSE ST_FISICO END +
        ISNULL((
            SELECT SUM(
                    CASE 
                        WHEN ISNULL(M.STFI2,0) < 0 THEN 0 
                        ELSE ISNULL(M.STFI2,0) 
                    END
                  )
            FROM MAEST M
            INNER JOIN #Global_BaseBk#Zw_InterStock_Equivalencia E
                ON (
                        (E.Empresa_A = P.Empresa AND E.Sucursal_A = P.Sucursal AND E.Bodega_A = P.Bodega
                         AND M.EMPRESA = E.Empresa_B AND M.KOSU = E.Sucursal_B AND M.KOBO = E.Bodega_B)

                     OR (E.Empresa_B = P.Empresa AND E.Sucursal_B = P.Sucursal AND E.Bodega_B = P.Bodega
                         AND M.EMPRESA = E.Empresa_A AND M.KOSU = E.Sucursal_A AND M.KOBO = E.Bodega_A)
                   )
                AND E.Activo2 = 1
            WHERE M.KOPR = @Codigo
        ),0),

    ST_COMPROMETIDO = CASE WHEN ST_COMPROMETIDO < 0 THEN 0 ELSE ST_COMPROMETIDO END +
        ISNULL((
            SELECT SUM(
                    CASE 
                        WHEN ISNULL(M.STOCNV2,0) < 0 THEN 0 
                        ELSE ISNULL(M.STOCNV2,0) 
                    END
                  )
            FROM MAEST M
            INNER JOIN #Global_BaseBk#Zw_InterStock_Equivalencia E
                ON (
                        (E.Empresa_A = P.Empresa AND E.Sucursal_A = P.Sucursal AND E.Bodega_A = P.Bodega
                         AND M.EMPRESA = E.Empresa_B AND M.KOSU = E.Sucursal_B AND M.KOBO = E.Bodega_B)

                     OR (E.Empresa_B = P.Empresa AND E.Sucursal_B = P.Sucursal AND E.Bodega_B = P.Bodega
                         AND M.EMPRESA = E.Empresa_A AND M.KOSU = E.Sucursal_A AND M.KOBO = E.Bodega_A)
                   )
                AND E.Activo2 = 1
            WHERE M.KOPR = @Codigo
        ),0),

    ST_COMPROMETIDO_BK = CASE WHEN ST_COMPROMETIDO_BK < 0 THEN 0 ELSE ST_COMPROMETIDO_BK END +
        ISNULL((
            SELECT SUM(
                    CASE 
                        WHEN ISNULL(S.StComp2,0) < 0 THEN 0 
                        ELSE ISNULL(S.StComp2,0) 
                    END
                  )
            FROM #Global_BaseBk#Zw_Prod_Stock S
            INNER JOIN #Global_BaseBk#Zw_InterStock_Equivalencia E
                ON (
                        (E.Empresa_A = P.Empresa AND E.Sucursal_A = P.Sucursal AND E.Bodega_A = P.Bodega
                         AND S.Empresa = E.Empresa_B AND S.Sucursal = E.Sucursal_B AND S.Bodega = E.Bodega_B)

                     OR (E.Empresa_B = P.Empresa AND E.Sucursal_B = P.Sucursal AND E.Bodega_B = P.Bodega
                         AND S.Empresa = E.Empresa_A AND S.Sucursal = E.Sucursal_A AND S.Bodega = E.Bodega_A)
                   )
                AND E.Activo2 = 1
            WHERE S.Codigo = @Codigo
        ),0)
FROM #Paso P



/* ============================================================
   5) CALCULAR DISPONIBLE CONSOLIDADO
   ============================================================ */
UPDATE #Paso 
SET ST_DISPONIBLE = 
      CASE WHEN ST_FISICO < 0 THEN 0 ELSE ST_FISICO END -
      CASE WHEN ST_COMPROMETIDO < 0 THEN 0 ELSE ST_COMPROMETIDO END - 
      CASE WHEN ST_COMPROMETIDO_BK < 0 THEN 0 ELSE ST_COMPROMETIDO_BK END

UPDATE #Paso SET ST_DISPONIBLE = 0 WHERE ST_DISPONIBLE < 0


--#Update_Conficion_Adicional#

Insert Into #Paso (CodPermiso,Empresa,Sucursal,Bodega,SUC_BOD,NOKOBO,Codigo,
                   ST_FISICO,ST_DEVENGADO,ST_DESP_SIN_FACTURAR,ST_TRANSITO,ST_COMPROMETIDO,ST_DISPONIBLE,
                   ST_COMPRAS_NO_RECEPCIONADAS,ST_RECEP_SIN_FACTURAR,ST_PEDIDO,ST_COMPROMETIDO_BK,ST_PEDIDO_BK,Orden)
Select 'zzz',
       '10' As EMPRESA,
       '' As KOSU,
       '' As KOBO,
       '' As SUC_BOD,
       'Totales' As NOKOBO,
       '' As KOPR,
       Sum(ST_FISICO) As ST_FISICO, 
       Sum(ST_DEVENGADO) As ST_DEVENGADO, 
       Sum(ST_DESP_SIN_FACTURAR) As ST_DESP_SIN_FACTURAR,
       Sum(ST_TRANSITO) As ST_TRANSITO,
       Sum(ST_COMPROMETIDO) As ST_COMPROMETIDO,
       Sum(ST_DISPONIBLE) As ST_DISPONIBLE,
       Sum(ST_COMPRAS_NO_RECEPCIONADAS) As ST_COMPRAS_NO_RECEPCIONADAS,
       Sum(ST_RECEP_SIN_FACTURAR) As ST_RECEP_SIN_FACTURAR,
       Sum(ST_PEDIDO) As ST_PEDIDO,
       SUM(ST_COMPROMETIDO_BK) As ST_COMPROMETIDO_BK,--
	   SUM(ST_PEDIDO_BK) As ST_PEDIDO_BK,--
       999
From #Paso
Where 1 > 0
#Filtro#
Order By EMPRESA

Select * From #Paso
Where 1 > 0
#Filtro#
Or CodPermiso = 'zzz'
Order by Orden

Drop Table #Paso

/*
       MST.STTR1,
       MST.PRESALCLI1,
       MST.PRESDEPRO1,
       MST.CONSALCLI1,
       MST.CONSDEPRO1,
       MST.DEVENGNCV1,
       MST.DEVENGNCC1,
       MST.DEVSINNCV1,
       MST.DEVSINNCC1,
       MST.STENFAB1,
       MST.STREQFAB1,
*/
