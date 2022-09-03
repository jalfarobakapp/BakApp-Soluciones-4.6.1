Declare 
@Empresa        Char(2) = '#Empresa#',
@Sucursal       Char(3),
@Bodega         Char(3),
@Fecha1         Date = '#FechaDesde#',
@Fecha2         Date = '#FechaHasta#',
@CodFuncionario Char(3) = '#Funcionario#',
@Codigo         Char(13) = '#Codigo#'




  
   INSERT INTO Zw_TblMargen (Tido,Presencia,Nudo,Feemli,Nulido,Koprct,Nokopr,
                            CantidadUd1,PNetoUnit,CostoUnit,
                            Porct_Ila,Porct_Iva,Ila,Iva,Funcionario)       

   SELECT     DDO.TIDO,
              Case When DDO.TIDO in ('NCE', 'NCV', 'NCX', 'NCZ', 'NEV') THEN - 1 ELSE 1 END,
              DDO.NUDO,
              FEEMLI,
              NULIDO,
              KOPRCT AS 'Codigo',
              (Select top 1 NOKOPR From MAEPR Where KOPR = DDO.KOPRCT) AS 'Descripcion',
              ROUND(CASE 
                    WHEN DDO.TIDO IN ('GDV','GDP')                   THEN DDO.CAPRCO1-DDO.CAPREX1  
                    WHEN DDO.TIDO IN ('NCE','NCV','NCX','NCZ','NEV') THEN - 1 * CAPRCO1
				    ELSE CAPRCO1 
					END,2)     As 'CantidadUd1',
			 DDO.PPPRNERE1  As 'PrecioNetoUnit',
			 DDO.PPPRPM As 'CostoUnit', 
			 Impuestos  AS 'Porct_Ila',
			 POIVLI     AS 'Porct_Iva',	
			 CASE 
			      WHEN DDO.CAPRCO1 > 0 THEN ROUND(VAIMLI/CAPRCO1,2)
			      ELSE 0 END As 'Ila',
			  CASE 
			      WHEN DDO.CAPRCO1 > 0 THEN	ROUND(VAIVLI/CAPRCO1,2)
			      ELSE 0 END As 'Iva',
			 ''
           FROM   MAEEDO AS EDO WITH ( NOLOCK )  
	   INNER JOIN MAEDDO DDO ON DDO.IDMAEEDO=EDO.IDMAEEDO 
	   AND DDO.LILG NOT IN ( 'GR','IM' )  
	   LEFT JOIN MAEPR ON MAEPR.KOPR=DDO.KOPRCT  
	   LEFT JOIN Zw_TblMrgImp ON Zw_TblMrgImp.Koprct=DDO.KOPRCT  
              WHERE 
                   DDO.FEEMLI BETWEEN @Fecha1 AND @Fecha2
			   AND DDO.EMPRESA=@Empresa  
			   AND DDO.TIDO IN 
			   ('BLV','BLX','BSV','ESC','FCV','FDB','FDV','FDX','FDZ','FEE','FEV','FVL','FVT',
                'FVX','FVZ','GDP','GDV','NCE','NCV','NCX','NCZ','NEV','RIN') 
			   AND NOT ( EDO.TIDO='GDV' AND DDO.ARCHIRST IN ('POTD','POTPR','POTL') ) -- No incluye Guias desde OT 
			   AND NOT ( EDO.TIDO='GDP' AND EDO.SUBTIDO<>'CON' )  -- No incluye Guias en consignación
			   AND DDO.PRCT=0  
			   AND MAEPR.TIPR<>'SSN' 
			   AND MAEPR.TIPR NOT IN ('SSN','FLN')  -- NO INCLUIR PRODUCTOS TIPO SERVICIO NI MULTIPROPOSITO   
               AND DDO.TICT = ''                    -- NO INCLUIR CONCEPTOS  ('R') Recargo,('D') Descuento 
               AND  LTRIM(RTRIM(DDO.ENDO))+RTRIM(LTRIM(DDO.SUENDO))  
	  NOT IN (SELECT LTRIM(RTRIM(Codigo))+LTRIM(RTRIM(Sucursal)) From Zw_TblInf_EntExcluidas
       Where Funcionario = @CodFuncionario And Excluida in ('V','A','T')) 
       --AND DDO.KOPRCT = @Codigo  
  