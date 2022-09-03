DECLARE @Entidad Char(13),
        @Fecha Date

Set @Entidad = '#Entidad#'
Set @Fecha = GetDate()--''		


IF EXISTS (SELECT * FROM sysobjects WHERE name='TblSaldoCli') BEGIN
DROP TABLE TblSaldoCli
END


CREATE TABLE [dbo].[TblSaldoCli](
	[TIDO]           [char](3)     NOT NULL,
	[NUDO]           [char](10)    NOT NULL,
	[ENDO]           [char](13)    NOT NULL,
	[SUENDO]         [char](10)    NULL,
	[SUDO]           [char](3)     NULL,
	[FEEMDO]         [datetime]    NULL,
	[FEULVEDO]       [datetime]    NULL,
	[KOFUDO]         [char](3)     NULL,
	[NOKOEN]         [varchar](50) NULL,
	[Saldo1]         [float]       NULL,
	[Saldo2]         [float]       NOT NULL,
	[Saldo3]         [float]       NOT NULL,
	[NUVEDO]         [float]       NULL,
	[FechaUlv]       [datetime]    NULL,
	[DiasDiferencia] [int]         NULL,
	[TIMODO]         [char](1)     NULL,
	[MODO]           [char](3)     NULL,
	[TAMODO]         [float]       NULL
) ON [PRIMARY]

Insert into TblSaldoCli
SELECT 
       EDO.TIDO,
	   EDO.NUDO,
	   EDO.ENDO,
	   EDO.SUENDO,
	   EDO.SUDO,
	   EDO.FEEMDO,
	   EDO.FEULVEDO,
	   EDO.KOFUDO,
	   EN.NOKOEN,
         (EDO.VABRDO-EDO.VAIVARET)* ( CASE WHEN EDO.TIDO='NCV' OR EDO.TIDO='NCC' OR EDO.TIDO='NCX' OR EDO.TIDO='NEV' THEN -1 ELSE 1 END ) as 'Saldo1', 
         (CASE 
		       WHEN EDO.TIDO='NCV' OR EDO.TIDO='NCC' OR EDO.TIDO='NCX' OR EDO.TIDO='NEV' THEN -1 ELSE 1 END ) 
         *isnull(( SELECT SUM(CASE  
           WHEN E.TIMODP='N' AND EX.TIMODO='N' THEN D.VAASDP  
           WHEN E.TIMODP='N' AND EX.TIMODO='E' THEN D.VAASDP  
           WHEN E.TIMODP='E' AND EX.TIMODO='N' THEN D.VAASDP*D.TCASIG  
           WHEN E.TIMODP='E' AND EX.TIMODO='E' THEN D.VAASDP*D.TCASIG  
		   ELSE 0.0 END)  
           FROM MAEDPCD AS D WITH ( NOLOCK )  LEFT JOIN MAEDPCE AS E ON D.IDMAEDPCE=E.IDMAEDPCE  
           LEFT JOIN MAEEDO  AS EX ON EX.IDMAEEDO=D.IDRST  
           WHERE D.FEASDP <= @Fecha AND 
           D.IDRST=EDO.IDMAEEDO  AND 
           D.TIDOPA=EDO.TIDO  AND 
           D.ARCHIRST='MAEEDO  ' ),0) as 'Saldo2', 
         ( CASE 
           WHEN EDO.TIDO='NCV' OR EDO.TIDO='NCC' OR EDO.TIDO='NCX' OR EDO.TIDO='NEV' THEN -1 
           ELSE 1 
           END ) *
         Isnull(( SELECT SUM(CASE  
                     WHEN E.TIMODP='N' AND D.TCASIG=0    THEN 0   
					 WHEN E.TIMODP='N' AND EX.TIMODO='N' THEN D.VAASDP/D.TCASIG  
					 WHEN E.TIMODP='N' AND EX.TIMODO='E' THEN D.VAASDP/D.TCASIG  
					 WHEN E.TIMODP='E' AND EX.TIMODO='N' THEN D.VAASDP  
					 WHEN E.TIMODP='E' AND EX.TIMODO='E' THEN D.VAASDP  ELSE 0.0 END)  
					 FROM MAEDPCD AS D WITH ( NOLOCK )  LEFT JOIN MAEDPCE AS E  ON D.IDMAEDPCE=E.IDMAEDPCE  
					 LEFT JOIN MAEEDO  AS EX ON EX.IDMAEEDO=D.IDRST  
					 WHERE D.FEASDP <= @Fecha AND 
					 D.IDRST=EDO.IDMAEEDO  AND 
					 D.TIDOPA=EDO.TIDO  AND 
					 D.ARCHIRST='MAEEDO  ' ),0) as 'Saldo3',
					 EDO.NUVEDO,
					 COALESCE( (SELECT TOP 1 MAEVEN.FEVE FROM MAEVEN WITH ( NOLOCK )  
					 WHERE MAEVEN.FEVE <= @Fecha AND MAEVEN.ESPGVE<>'C'  AND MAEVEN.IDMAEEDO=EDO.IDMAEEDO  
					 ORDER BY MAEVEN.IDMAEVEN DESC, MAEVEN.FEVE DESC ) ,
					 EDO.FEULVEDO ) AS 'FechaUlv',
					 DATEDIFF( dd,COALESCE( (SELECT TOP 1 MAEVEN.FEVE FROM MAEVEN WITH ( NOLOCK )  
					 WHERE MAEVEN.FEVE <= @Fecha AND 
					 MAEVEN.ESPGVE<>'C'  AND 
					 MAEVEN.IDMAEEDO=EDO.IDMAEEDO  
					 ORDER BY MAEVEN.IDMAEVEN DESC ,
					  MAEVEN.FEVE DESC ),
					 EDO.FEULVEDO ) ,
					 @Fecha) * -1 as 'DiasDiferencia',
					 EDO.TIMODO, 
					 EDO.MODO, 
					 EDO.TAMODO 
				  
					 FROM MAEEDO EDO WITH ( NOLOCK )  
					 LEFT JOIN TABSU ON TABSU.KOSU=EDO.SUDO  
					 LEFT JOIN TABFU ON TABFU.KOFU=EDO.KOFUDO  
					 LEFT JOIN TABLUG ON TABLUG.LUVT=EDO.LUVTDO AND 
					 TABLUG.EMPRESA='01'  
					 INNER JOIN MAEEN EN ON EN.KOEN=EDO.ENDO AND 
					 EN.SUEN=EDO.SUENDO  
					 AND EN.KOEN = @Entidad--( SELECT FTMPENSQL.INI01 FROM #M3759943 AS FTMPENSQL WITH ( NOLOCK ) 
					 --WHERE EN.KOEN=FTMPENSQL.INI01 ) 
					 WHERE EDO.TIDO IN ('BLV','BSV','ESC','FCV','FDB','FDV','FDX','FDZ','FEE','FEV','FVL','FVT','FVX','FVZ','NCE',
					 'NCV','NCX','NCZ','NEV','RIN') AND 
					 EDO.EMPRESA='01'  AND 
					 EDO.FEEMDO <= @Fecha AND 
					 EDO.ESDO<>'N'  AND EDO.VABRDO<>0.0 
					 order by NUDO
					 
Delete TblSaldoCli					 
Where (TIDO = 'NCV' and  Saldo2 <= Saldo1) 

Delete TblSaldoCli					 
Where (TIDO IN ('BLV','FCV') and  Saldo2 >= Saldo1)

Update TblSaldoCli Set Saldo3 = -1*(Saldo2 - Saldo1)
Where TIDO = 'NCV'

Update TblSaldoCli Set Saldo3 = Saldo1 - Saldo2
Where TIDO IN ('FCV','BLV')
                      			 