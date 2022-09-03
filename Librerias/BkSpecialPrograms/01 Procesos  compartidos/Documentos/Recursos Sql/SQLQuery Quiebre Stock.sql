DECLARE 
@Empresa char(2),
@Sucursal char(3),
@Bodega char(3),
@Codigo char(13),
@nWhile int,
@nRegistros int,
@Ul_Id int,
@Stock_Fi float,
@Mes_Ac varchar(20),
@Mes_Ul varchar(20)

--@Fecha1 date,
--@Fecha2 date

select @Empresa = '#Empresa#',@Sucursal = '#Sucursal#',@Bodega = '#Bodega#',@Codigo = '#Codigo#',@Stock_Fi = 0
--@Fecha1 = '20130901',@Fecha2 = '20140831'

--drop table _Zw_Paso_Quiebre_Stock 

CREATE TABLE [dbo].[_Zw_Paso_Quiebre_Stock](
    [Id]                   [int] IDENTITY(1, 1) NOT NULL,
    [Fecha]                Date, 
	[Mes_Palabra]          [varchar](20)  Default '',
	[Semana]               [float]        Default (0),
	[Mes]                  [int]          Default (0),
	[Ano]                  [int]          Default (0),
	[Cant_Mov_Stock]       [float]        Default (0),
	[Stock]                [float]        Default (0)
) ON [PRIMARY]


Insert Into _Zw_Paso_Quiebre_Stock (Fecha,Mes_Palabra,Semana,Mes,Ano,Cant_Mov_Stock)

SELECT MAEDDO.FEEMLI AS 'Fecha',
       DATENAME(month,MAEDDO.FEEMLI) as 'Mes_Palabra',
       DATEPART(week, MAEDDO.FEEMLI) as 'Semana',
       MONTH(MAEDDO.FEEMLI) as 'Mes',
       YEAR(MAEDDO.FEEMLI) as 'Ano',
       CASE 
       WHEN MAEDDO.CAPRAD1 <> 0 THEN 
           CASE 
            WHEN MAEDDO.TIDO IN ('FCC','NCV','GRI','GRC','GRD','GRP') THEN CAPRCO1
             WHEN MAEDDO.TIDO IN ('FCV','BLV','NCC','GDV','GDI','GDP','GDD','GTI') THEN CAPRCO1*-1
             ELSE 0
            END
       WHEN MAEDDO.TIDO IN ('GRI','GRC','GRD','GRP','GDV','GDI','GDP','GDD','GTI') THEN 
           CASE 
            WHEN MAEDDO.TIDO IN ('GRI','GRC','GRD','GRP') THEN CAPRCO1
             WHEN MAEDDO.TIDO IN ('GDV','GDI','GDP','GDD','GTI') THEN CAPRCO1*-1
             ELSE 0
            END
       ELSE 0     
       END AS 'Cant_Mov_Stock'
       FROM MAEDDO WITH ( NOLOCK )  LEFT JOIN MAEEDO 
            ON MAEDDO.IDMAEEDO=MAEEDO.IDMAEEDO  
            LEFT JOIN MAEEN 
            ON MAEDDO.ENDO=MAEEN.KOEN 
            AND MAEDDO.SUENDO=MAEEN.SUEN  
             LEFT JOIN MAEPPPME 
             ON MAEDDO.IDMAEDDO=MAEPPPME.IDMAEDDO 
             AND MAEPPPME.MODO='US$'  
              LEFT JOIN POTD 
              ON POTD.IDPOTD=MAEDDO.IDRST 
              AND MAEDDO.ARCHIRST='POTD'  
               LEFT JOIN POTL 
               ON POTL.IDPOTL=MAEDDO.IDRST 
               AND MAEDDO.ARCHIRST='POTL'  
                LEFT JOIN PODCE 
                ON PODCE.IDPODCE=MAEDDO.IDRST 
                AND MAEDDO.ARCHIRST='PODCE'  
                 LEFT JOIN PODCD 
                 ON PODCD.IDPODCD=MAEDDO.IDRST 
                 AND MAEDDO.ARCHIRST='PODCD' 
       WHERE MAEDDO.KOPRCT=@Codigo 
       AND MAEEDO.EMPRESA=@Empresa
       AND ( MAEDDO.LILG NOT IN ('GR','IM' ) 
       OR ( MAEDDO.TIDO IN ('NVV','NVI') 
       AND MAEDDO.ESFALI<>' ' ) )  
      -- AND MAEDDO.SULIDO=@Sucursal 
       --AND MAEDDO.BOSULIDO=@Bodega  
       #Filtro_Bodega#
--       AND MAEDDO.FEEMLI BETWEEN @Fecha1 AND @Fecha2
       ORDER BY MAEDDO.KOPRCT,MAEEDO.FEEMDO,MAEEDO.HORAGRAB,MAEDDO.SEMILLA,MAEDDO.IDMAEEDO

     Set @nRegistros = (Select COUNT(*) From _Zw_Paso_Quiebre_Stock)
     SET @nWhile=1


     WHILE(@nRegistros>0 AND @nWhile<=@nRegistros)
     BEGIN
     
     Set @Stock_Fi = @Stock_Fi + (Select top 1 Cant_Mov_Stock From _Zw_Paso_Quiebre_Stock Where Id = @nWhile)
     --Update _Zw_Paso_Quiebre_Stock Set Stock = @Stock_Fi Where Id = @nWhile
     Set @Mes_Ul = (Select top 1 Mes_Palabra From _Zw_Paso_Quiebre_Stock Where Id = @nWhile)
     Set @Ul_Id = @nWhile
     
     Set @nWhile=@nWhile+1
     Set @Mes_Ac = (Select top 1 Mes_Palabra From _Zw_Paso_Quiebre_Stock Where Id = @nWhile)
     
     If (@Mes_Ul <> @Mes_Ac)
       Update _Zw_Paso_Quiebre_Stock Set Stock = @Stock_Fi Where Id = @Ul_Id       
     
    END
    
    --print @Stock_Fi
    
    Update _Zw_Paso_Quiebre_Stock Set Stock = @Stock_Fi Where Id = @nRegistros
    Delete _Zw_Paso_Quiebre_Stock Where Stock = 0
    
    
    
    
    
    
    
    
    DECLARE 

@Empresa   Char(2),
@Sucursal  Char(3),
@Bodega    Char(3),
@Codigo    Char(13),
@Orden     Int,
@StockUd1  Float,
@StockUd2  Float,
@Fecha  Date  

Select @Empresa  = '#Empresa#',
       @Sucursal = '#Sucursal#',
       @Bodega   = '#Bodega#', 
	   @Codigo   = '#@Codigo#',
	   @Orden    = #Int#,
	   @Fecha    = '#Fecha#'


--IF EXISTS (SELECT * FROM sysobjects WHERE name='Zw_TblStockConsolid') BEGIN
--DROP TABLE Zw_TblStockConsolid
--END


SELECT D.KOPRCT,D.EMPRESA,E.TIDO,E.SUBTIDO,D.SULIDO,D.BOSULIDO,

       CASE 
            WHEN MAEDDO.TIDO IN ('FCC','NCV','GRI','GRC','GRD','GRP') THEN CAPRCO1
            WHEN MAEDDO.TIDO IN ('FCV','BLV','NCC','GDV','GDI','GDP','GDD','GTI') THEN CAPRCO1*-1
            ELSE 0
       END AS 'CantidadUd1',
       CASE 
            WHEN MAEDDO.TIDO IN ('FCC','NCV','GRI','GRC','GRD','GRP') THEN CAPRCO2
            WHEN MAEDDO.TIDO IN ('FCV','BLV','NCC','GDV','GDI','GDP','GDD','GTI') THEN CAPRCO2*-1
            ELSE 0
       END AS 'CantidadUd2'
       Into Zw_TblStockConsolid        
       FROM MAEDDO AS D WITH ( NOLOCK )  
       INNER JOIN MAEEDO AS E ON E.IDMAEEDO=D.IDMAEEDO  
       WHERE D.PRCT=0 AND D.LILG IN ('SI','CR')  
             AND D.KOPRCT IN ( @Codigo ) 
             AND D.TIDO NOT IN ('COV','OCC','NVV','NVI','OCI','GRI','GRC','GRD','GRP','GAR','GTI','NCC')
             AND D.EMPRESA  =@Empresa 
             --AND D.SULIDO   =@Sucursal
             --AND D.BOSULIDO =@Bodega
             #FiltroBodegas#
             AND D.FEEMLI   < @Fecha 
GROUP BY D.KOPRCT,D.EMPRESA,E.TIDO,E.SUBTIDO,D.SULIDO,D.BOSULIDO 

--SELECT @StockUd1 = ISNULL(SUM(CantidadUd1),0),@StockUd2 = ISNULL(SUM(CantidadUd2),0)
--FROM Zw_TblStockConsolid
--WHERE KOPRCT = @Codigo
			  
--UPDATE 	Zw_TmpInv_InvParcial Set ConsolidStockUd1 = @StockUd1, 
--                                 ConsolidStockUd2 =	@StockUd2
--Where Semilla = @Orden 								 
					
--IF EXISTS (SELECT * FROM sysobjects WHERE name='Zw_TblStockConsolid') BEGIN
--DROP TABLE Zw_TblStockConsolid
--END					
			  
 /*
 SELECT * FROM Zw_TblStockConsolid
 SELECT KOPRCT,SUM(CantidadUd1) as CantidadUd1,SUM(CantidadUd2) as CantidadUd2             
 FROM Zw_TblStockConsolid
 GROUP BY KOPRCT
 */             