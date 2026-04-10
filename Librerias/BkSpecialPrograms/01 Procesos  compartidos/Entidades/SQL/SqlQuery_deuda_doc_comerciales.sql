Declare @CodEntidad Char(13),
        @SucEntidad Char(10),
        @Fecha Datetime,
        @Empresa Char(2),
        @Tolerancia Int

Select @CodEntidad = '#CodEntidad#',
       @SucEntidad = '#SucEntidad#',
       @Fecha = '#Fecha#',
       @Empresa = '#Empresa#',
       @Tolerancia = #ToleranciaDocMoroso#

-- DEUDA TOTAL INCLUYE DOCUMENTOS TRANSITORIOS

SELECT MAEVEN.*,MAEVEN.VAVE-MAEVEN.VAABVE AS SALDO,DATEDIFF(day,FEVE,GETDATE()) DIAS_ATRASO,
       MAEEDO.TIDO,MAEEDO.NUDO,MAEEDO.ENDO,MAEEDO.NUDONODEFI 
FROM MAEVEN LEFT JOIN MAEEDO ON MAEEDO.IDMAEEDO=MAEVEN.IDMAEEDO  
WHERE  
MAEEDO.EMPRESA = @Empresa 
AND MAEVEN.ESPGVE = ''  
AND  MAEVEN.FEVE<=@Fecha
AND MAEEDO.TIDO IN  ('BLV','BSV','BLX','FCV','FDB','FDV','FDX','FDZ','FEV','FVL','FVT','FVX','FVZ','RIN','ESC','FEE')
AND MAEEDO.ENDO = @CodEntidad --AND MAEEDO.SUENDO = @SucEntidad 
AND MAEVEN.VAVE-MAEVEN.VAABVE > @Tolerancia
ORDER BY MAEEDO.ENDO ,MAEVEN.ESPGVE ,MAEVEN.FEVE  --OPTION ( FAST 20 ) 

