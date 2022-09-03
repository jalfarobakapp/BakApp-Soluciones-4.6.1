

DECLARE @CodEntidad(13) = '#CodEntidad#',
        @SucEntidad(10) = '#SucEntidad#'

--  TABLA DATOS DE LA ENTIDAD DEL DOCUMENTO
SELECT  * FROM  MAEEN WHERE KOEN = @CodEntidad AND SUEN = @SucEntidad


DECLARE
@CodEntidad_Fisica(13) = '#CodEntidad_Fisica#',
@SucEntidad_Fisica(10) = '#SucEntidad_Fisica#'

		
--  TABLA DATOS DE LA ENTIDAD DE DESPACHO DEL DOCUMENTO
SELECT top 1 * FROM MAEEN
Where KOEN = @CodEntidad_Fisica

