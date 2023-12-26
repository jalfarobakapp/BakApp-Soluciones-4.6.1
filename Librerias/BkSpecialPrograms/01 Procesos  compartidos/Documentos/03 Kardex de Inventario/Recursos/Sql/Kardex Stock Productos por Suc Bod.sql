DECLARE 
@Empresa char(2),
@Codigo char(13),
@ListaPrecio Char(3),
@Kofu Char(3)

Select @Empresa = '#Empresa#',@ListaPrecio = '#ListaPrecio#',@Codigo = '#Codigo#', @Kofu = '#Kofu#'

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
       CAST(0 As float) As StTeorico
       --TB.DATOSUBIC      -- UBICACION EN BODEGA
Into #Paso
FROM MAEST MST WITH ( NOLOCK )  
--LEFT OUTER JOIN TABBOPR TB ON MST.KOSU=TB.KOSU 
--AND MST.KOBO=TB.KOBO 
--AND MST.KOPR=TB.KOPR  
WHERE MST.KOPR=@Codigo AND MST.EMPRESA=@Empresa

Update #Paso Set StTeorico = STFI#Ud#+STDV#Ud#C+STOCNV#Ud#C-STOCNV#Ud#

Insert Into #Paso
Select EMPRESA,KOSU,KOBO,LTRIM(RTRIM(KOSU))+'-'+LTRIM(RTRIM(KOBO)),@Codigo,0,0,0,0,0,0,0,0 From TABBO WHere EMPRESA+KOSU+KOBO Not In (Select EMPRESA+KOSU+KOBO From #Paso)

Select P.*,Bpr.DATOSUBIC From #Paso P
Left Join TABBOPR Bpr On P.EMPRESA = Bpr.EMPRESA And P.KOSU = Bpr.KOSU And P.KOBO = Bpr.KOBO And P.KOPR = Bpr.KOPR
Where P.EMPRESA+P.KOSU+P.KOBO In
(SELECT Replace(CodPermiso,'Bo','')
FROM   #Global_BaseBk#ZW_PermisosVsUsuarios
WHERE  (CodUsuario = @Kofu) And CodPermiso Like 'Bo%' )

Drop table #Paso