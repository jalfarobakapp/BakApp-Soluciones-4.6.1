Declare @Codigo Char(13) = '#Codigo#',
        @Empresa Char(2) = '#Empresa#'

SELECT     Zw_UXP.Codigo as 'Codigo', 
           Zw_UXP.CodSector as 'CodSector', 
           Zw_UXP.IdUbicacion as 'IdUbicacion', 
           Zw_SXB.Empresa as 'Empresa', 
           Zw_SXB.Sucursal as 'Sucursal', 
           Zw_SXB.Bodega as 'Bodega', 
           Zw_SXB.Lugar_ 'Lugar_', 
           Zw_SXB.Sector_ as 'Sector_', 
           Zw_SXB.Lugar_+', '+Zw_SXB.Sector_ as 'Ubicacion', 
           Zw_UXS.Columna as 'Columna', 
           Zw_UXS.Fila as 'Fila', 
           Zw_UXS.Desc_Ubicacion as 'Desc_Ubicacion',
           Zw_UXP.Primaria as 'Primaria'

FROM       Zw_Tbl_SecXBod_UbicXproducto AS Zw_UXP 
                                       LEFT OUTER JOIN
           Zw_Tbl_SecXBod_ AS Zw_SXB 
                                       ON Zw_UXP.CodSector = Zw_SXB.CodSector LEFT OUTER JOIN
           Zw_Tbl_SecXBod_Ubicaciones AS Zw_UXS 
                                       ON Zw_UXP.IdUbicacion = Zw_UXS.IdUbicacion
WHERE     (Zw_UXP.Codigo = @Codigo)  And 
          (Zw_SXB.Empresa = @Empresa)
          order by Zw_UXP.Primaria desc
          
/* CONSULTA PARA ACTUALIZAR LAS UBICACIONES DE RANDOM CON BAKAPP

update TABBOPR SET DATOSUBIC = (SELECT Desc_Ubicacion From Zw_Tbl_SecXBod_Ubicaciones Where
                                IdUbicacion = 
                                (SELECT TOP 1 IdUbicacion 
                                        From Zw_Tbl_SecXBod_UbicXproducto Where Codigo = TABBOPR.KOPR And Primaria = 1 ))
WHERE KOPR in (Select Codigo From Zw_Tbl_SecXBod_UbicXproducto)     
AND KOBO = '001'

*/          
