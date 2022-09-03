DECLARE 
@Codigo char(13),
@Precio float,
@ListaPrecio Char (3)

Set @Codigo = '#Codigo#'
Set @ListaPrecio = '#ListaPrecio#'
Set @Precio = (SELECT PP01UD FROM TABPRE WHERE KOLT = @ListaPrecio and KOPR = @Codigo)


-- MARGEN DEL PRODUCTO.

SELECT @Codigo as Codigo,KOLT,
       (SELECT NOKOLT FROM TABPP WHERE KOLT = TABPRE.KOLT ) as Lista,
	   PP01UD as Costo,ROUND(@Precio / 1.19,0) as Precio,
                  Case when @Precio > 0 then
                      ROUND(((ROUND(@Precio / 1.19,0)-PP01UD)/ROUND(@Precio / 1.19,0))* 100,3) 
                     else 100 end as 'Porc_Markup'
                    ,
                  Case When  PP01UD > 0 then
                      ROUND(((ROUND(@Precio / 1.19,0)-PP01UD)/PP01UD)*100,3)
                     else 100 end as 'Porc_Margen'
from TABPRE where KOPR = @Codigo
AND KOLT IN (SELECT KOLT FROM TABPP WHERE TILT = 'C' AND KOLT <> '05C')
