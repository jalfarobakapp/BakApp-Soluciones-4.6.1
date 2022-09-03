DECLARE 
@Empresa Char(2) = '#Empresa#',
@Fecha1 Date = '#FechaInicio#',
@Fecha2 Date = '#FechaTermino#',
@CodFuncionario Char(3) = '#Funcionario#'


SELECT      Cast('' As Varchar(20)) As Codigo_Nodo_Madre,
            TIDO,
			NUDO,
			FEEMLI,
            KOPRCT As Codigo,
            YEAR(FEEMLI) as 'Año',
			MONTH(FEEMLI) as 'Mes',
            ROUND(SUM(
            CASE WHEN TIDO IN ('NCE','NCV','NCX','NCZ','NEV') THEN CAPRCO1 * -1
	        WHEN TIDO IN ('GDV','GDP') THEN CAPRCO1-CAPREX1
	       	ELSE CAPRCO1 END	       	
	       	),2) As 'CantUd1',
	        ROUND(SUM(
            CASE WHEN TIDO IN ('NCE','NCV','NCX','NCZ','NEV') THEN - 1 * CAPRCO2
	        WHEN TIDO IN ('GDV','GDP') THEN CAPRCO2-CAPREX2
	       	ELSE CAPRCO2 END	       	
	       	),2) As 'CantUd2'
			Into #Paso
       FROM MAEDDO WITH ( NOLOCK )  
       --INNER JOIN MAEEDO AS EDO ON IDMAEEDO=EDO.IDMAEEDO  
       WHERE EMPRESA= @Empresa AND FEEMLI BETWEEN @Fecha1 And @Fecha2
       AND 
       TIDO IN  
	   ('FCV', 'FDB', 'FDV', 'FDX', 'FDZ', 'FEV', 'FVL', 'FVT', 'FVX', 'FVZ','FEE', 'BLV',
	    'GDV','GDP','NCE', 'NCV', 'NCX', 'NCZ', 'NEV')
	   #Filtro_Bodega#
	   #Filtro_Codigo#
       
       AND LILG IN ('SI','GR')  

	    #Entidades_Excluidas#
            
GROUP BY SULIDO,BOSULIDO,KOPRCT,TIDO,NUDO,FEEMLI  


Update #TablaPaso# Set #Campo_SumTotalQtyUd1# = Isnull((Select Sum(CantUd1) From #Paso Z2 Where Z2.Codigo = Z1.Codigo),0),
                       #Campo_SumTotalQtyUd2# = Isnull((Select Sum(CantUd2) From #Paso Z2 Where Z2.Codigo = Z1.Codigo),0)
From #TablaPaso# Z1

Drop table #Paso


