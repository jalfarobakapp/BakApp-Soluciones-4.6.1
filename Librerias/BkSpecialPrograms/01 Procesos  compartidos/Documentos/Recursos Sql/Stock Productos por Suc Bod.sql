DECLARE 
@Empresa char(2),
@Codigo char(13),
@ListaPrecio Char(3)

Select @Empresa = '#Empresa#',@ListaPrecio = '#ListaPrecio#',@Codigo = '#Codigo#'

SELECT 
       MST.EMPRESA,
       MST.KOSU,
       MST.KOBO,
       LTRIM(RTRIM(MST.KOSU))+'-'+LTRIM(RTRIM(MST.KOBO)) as SUC_BOD,
       MST.KOPR,
       MST.STFI#Ud#,        -- STOCK FISICO
       MST.STDV#Ud#,        -- STOCK DEVENGADO
       MST.DESPNOFAC#Ud#,   -- DESPACHADO SIN FACTURAR 
       MST.STOCNV#Ud#,      -- STOCK COMPROMETIDO
       MST.STDV#Ud#C,       -- COMPRAS NO RECEPCIONADAS
       MST.RECENOFAC#Ud#,   -- RECEPCIONADO SIN FACTURAR
       MST.STOCNV#Ud#C,     -- STOCK PEDIDO
       TB.DATOSUBIC      -- UBICACION EN BODEGA
FROM MAEST MST WITH ( NOLOCK )  
LEFT OUTER JOIN TABBOPR TB ON MST.KOSU=TB.KOSU 
AND MST.KOBO=TB.KOBO 
AND MST.KOPR=TB.KOPR  
WHERE MST.KOPR=@Codigo AND MST.EMPRESA=@Empresa
Union
SELECT 
       'ZZ' as EMPRESA,
       '..' as KOSU,
       '..' as KOBO,
       'Total' as SUC_BOD,
       MST.KOPR AS KOPR,
       SUM(MST.STFI1) AS STFI1,             -- STOCK FISICO
       SUM(MST.STDV1) AS STDV1 ,            -- STOCK DEVENGADO
       SUM(MST.DESPNOFAC1) AS DESPNOFAC1,   -- DESPACHADO SIN FACTURAR 
       SUM(MST.STOCNV1) AS STOCNV1,         -- STOCK COMPROMETIDO
       SUM(MST.STDV1C) AS STDV1C,           -- COMPRAS NO RECEPCIONADAS
       SUM(MST.RECENOFAC1) AS RECENOFAC1,   -- RECEPCIONADO SIN FACTURAR
       SUM(MST.STOCNV1C) AS STOCNV1C,       -- STOCK PEDIDO
       '' AS DATOSUBIC      -- UBICACION EN BODEGA
FROM MAEST MST WITH ( NOLOCK )  
WHERE MST.KOPR=@Codigo AND MST.EMPRESA=@Empresa
GROUP BY KOPR
/*
       MST.STTR#Ud#,
       MST.PRESALCLI#Ud#,
       MST.PRESDEPRO#Ud#,
       MST.CONSALCLI#Ud#,
       MST.CONSDEPRO#Ud#,
       MST.DEVENGNCV#Ud#,
       MST.DEVENGNCC#Ud#,
       MST.DEVSINNCV#Ud#,
       MST.DEVSINNCC#Ud#,
       MST.STENFAB#Ud#,
       MST.STREQFAB#Ud#,
*/
