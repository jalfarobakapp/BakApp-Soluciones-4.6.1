Declare

@Empresa         Char(2) = '#Empresa#',
@Sucursal        Char(3) = '#Sucursal#',
@Bodega          Char(3) = '#Bodega#',
@Codigo          Char(13) = '#Codigo#',
@CodFuncionario  Char(3) = '#Funcionario#',
@FechaInicio     Date = '#FechaInicio#',
@FechaTermino    Date = '#FechaTermino#'

Select(Isnull((   
      select ROUND(SUM(
	   CASE WHEN TIDO IN ('NCE','NCV','NCX','NCZ','NEV') THEN - 1 * CAPRCO1
	        WHEN TIDO IN ('GDV','GDP') THEN CAPRCO1-CAPREX1 
	       	ELSE CAPRCO1 END),2)  
       --From MAEDDO WITH (NOLOCK) 
       
       From MAEDDO 
       Where KOPRCT = @Codigo 
       AND TIDO in ('FCV', 'FDB', 'FDV', 'FDX', 'FDZ', 'FEV', 'FVL', 'FVT', 'FVX', 'FVZ','FEE', 'BLV',
	                'GDV','GDP','NCE', 'NCV', 'NCX', 'NCZ', 'NEV') 
       AND NOT ( TIDO='GDV' AND ARCHIRST IN ('POTD','POTPR','POTL') ) -- No incluye Guias desde OT 
	   	   AND PRCT=0  
	   AND TICT = ''                    -- NO INCLUIR CONCEPTOS  ('R') Recargo,('D') Descu	             
       AND IDMAEEDO NOT IN (SELECT IDMAEEDO FROM MAEEDO WHERE TIDO='GDP' AND SUBTIDO='CON')  -- No incluye Guias en consignación)
       AND 
	  (FEEMLI BETWEEN @FechaInicio AND @FechaTermino) AND 
	  (EMPRESA = @Empresa ) AND 
	  (SULIDO = @Sucursal) And 
	  (BOSULIDO = @Bodega) 
	  #Entidades_Excluidas#),0)) As SumTotalQtyUd1,
     (Isnull((   
      select ROUND(SUM(
	   CASE WHEN TIDO IN ('NCE','NCV','NCX','NCZ','NEV') THEN - 1 * CAPRCO2
	        WHEN TIDO IN ('GDV','GDP') THEN CAPRCO2-CAPREX2
	       	ELSE CAPRCO2 END),2)  
       --From MAEDDO WITH (NOLOCK) 
       
      From MAEDDO 
       Where KOPRCT = @Codigo 
       AND TIDO in ('FCV', 'FDB', 'FDV', 'FDX', 'FDZ', 'FEV', 'FVL', 'FVT', 'FVX', 'FVZ','FEE', 'BLV',
	                'GDV','GDP','NCE', 'NCV', 'NCX', 'NCZ', 'NEV') 
       AND NOT ( TIDO='GDV' AND ARCHIRST IN ('POTD','POTPR','POTL') ) -- No incluye Guias desde OT 
	   	   AND PRCT=0  
	   AND TICT = ''                    -- NO INCLUIR CONCEPTOS  ('R') Recargo,('D') Descu	             
       AND IDMAEEDO NOT IN (SELECT IDMAEEDO FROM MAEEDO WHERE TIDO='GDP' AND SUBTIDO='CON')  -- No incluye Guias en consignación)
       AND 
	  (FEEMLI BETWEEN @FechaInicio AND @FechaTermino) And 
	  (EMPRESA = @Empresa ) And 
	  (SULIDO = @Sucursal) And 
	  (BOSULIDO = @Bodega)  
	  #Entidades_Excluidas#),0)) As SumTotalQtyUd2
	  
     
     
   
      
