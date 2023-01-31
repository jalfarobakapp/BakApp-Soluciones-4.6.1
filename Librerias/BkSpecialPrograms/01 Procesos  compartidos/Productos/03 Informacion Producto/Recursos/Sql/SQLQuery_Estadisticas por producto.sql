DECLARE 
@Empresa Char(2),
--@Codigo Varchar(13),
@Fecha1 Datetime,
@Fecha2 Datetime,
@CodFuncionario Char(3)


Select @Empresa = '#Empresa#',@Fecha1 = '#Fecha1#',@Fecha2 = '#Fecha2#',@CodFuncionario = '#Funcionario#'

--drop table #Tabla_de_Paso#
CREATE TABLE [dbo].[#Tabla_de_Paso#](
[Tipo]                  [Char](1)     DEFAULT '',
[Sucursal]              [Char](3)     DEFAULT '',
[Bodega]                [Char](3)     DEFAULT '',
[Fecha]                 [Datetime],
[Mes_Palabra]           [Varchar](20) DEFAULT '',
[Semana]                [Int]         DEFAULT (0),
[Dia]                   [Int]         DEFAULT (0),
[Mes]                   [Int]         DEFAULT (0),
[Ano]                   [Int]         DEFAULT (0),
[SumTotalQtyUd1]        [float]       DEFAULT (0),
[SumTotalQtyUd2]        [float]       DEFAULT (0))
ON [PRIMARY]

Insert Into #Tabla_de_Paso# (Tipo,Sucursal,Bodega,Fecha,Mes_Palabra,Semana,Dia,Mes,Ano,SumTotalQtyUd1,SumTotalQtyUd2)

SELECT 
       'V',
	   DDO.SULIDO,
	   DDO.BOSULIDO,
       EDO.FEEMDO,
       DATENAME(month,EDO.FEEMDO) as 'Mes Palabra',
       DATEPART(week, EDO.FEEMDO) as 'Semana',
       DAY(EDO.FEEMDO) as 'Dia',
       MONTH(EDO.FEEMDO) as 'Mes',
       YEAR(EDO.FEEMDO) as 'Año',
	   ROUND(SUM(
            CASE WHEN DDO.TIDO IN ('NCE','NCV','NCX','NCZ','NEV','GRI') THEN - 1 * DDO.CAPRCO1
	        WHEN DDO.TIDO IN ('GDV','GDP') THEN DDO.CAPRCO1-DDO.CAPREX1
	       	ELSE DDO.CAPRCO1 END	       	
	       	),2) As 'CantUd1',
	   ROUND(SUM(
            CASE WHEN DDO.TIDO IN ('NCE','NCV','NCX','NCZ','NEV','GRI') THEN - 1 * DDO.CAPRCO2
	        WHEN DDO.TIDO IN ('GDV','GDP') THEN DDO.CAPRCO2-DDO.CAPREX2
	       	ELSE DDO.CAPRCO2 END	       	
	       	),2) As 'CantUd2'
       FROM MAEDDO AS DDO  WITH ( NOLOCK )  
       INNER JOIN MAEEDO AS EDO ON DDO.IDMAEEDO=EDO.IDMAEEDO  
       WHERE EDO.EMPRESA= @Empresa AND DDO.FEEMLI BETWEEN @Fecha1 And @Fecha2

       And (DDO.TIDO IN ('FCV', 'FDB', 'FDV', 'FDX', 'FDZ', 'FEV', 'FVL', 'FVT', 'FVX', 'FVZ','FEE', 'BLV','GDV','GDP','NCE', 'NCV', 'NCX', 'NCZ', 'NEV') 
            Or 
       DDO.TIDO In ('GDI','GRI') And DDO.ARCHIRST = 'POTD')
	   #FiltroBodegas# 
       AND DDO.KOPRCT In #Codigo#
       AND DDO.LILG IN ('SI','GR')  
       #Filtro_Extra#
       #Filtro_Entidades_Excluidas#  
	   GROUP BY DDO.SULIDO,DDO.BOSULIDO,EDO.FEEMDO  
	   
Union

SELECT 'C',
       DDO.SULIDO,
	   DDO.BOSULIDO,
       EDO.FEEMDO,
       DATENAME(month,EDO.FEEMDO) as 'Mes Palabra',
       DATEPART(week, EDO.FEEMDO) as 'Semana',
       DAY(EDO.FEEMDO) as 'Dia',
       MONTH(EDO.FEEMDO) as 'Mes',
       YEAR(EDO.FEEMDO) as 'Año',
       SUM(DDO.CAPRCO1) As 'CantUd1',
       SUM(DDO.CAPRCO2) As 'CantUd2'  
       FROM MAEDDO AS DDO  WITH ( NOLOCK )  
       INNER JOIN MAEEDO AS EDO ON DDO.IDMAEEDO=EDO.IDMAEEDO  
       WHERE EDO.EMPRESA= @Empresa AND EDO.FEEMDO BETWEEN @Fecha1 And @Fecha2
       AND EDO.TIDO IN  ('BLC','FCC','FCT','FDC','RGA')  
       #FiltroBodegas#
       AND DDO.KOPRCT In #Codigo# 
       AND DDO.LILG IN ('SI','GR') 
       #Filtro_Extra# 
       GROUP BY DDO.SULIDO,DDO.BOSULIDO,EDO.FEEMDO  
       ORDER BY EDO.FEEMDO DESC 
	   
	   
	   