-- =============================================
-- Autores        : <BakApp,Jorge Alfaro>
-- Fecha Creación : <25-04-2013>
-- Descripcion    :	<Generar Tabla de paso para ultimos documentos generados por productos>
-- Versión        : 1.0.1
-- =============================================

CREATE PROCEDURE Trae_UltGRCxProducto (@FechaInicio Date,
                                             @FechaTermino Date,
                                             @ConsideraFechas Char(1))
as

DECLARE
@Tbl_Paso2 TABLE(
  Id int identity(1,1) not null primary key,
  TIDO     Char(3),
  NUDO     Char(10),
  ENDO     Char(10),
  SUENDO   Char(20), 
  NOKOEN   Char(50), 
  SULIDO   Char(3),
  BOSULIDO Char(3),
  FEEMLI   Datetime,
  KOPRCT   Char(13),
  NOKOPR   Char(50),
  UDTRPR   Int,
  RLUDPR   Float,
  CAPRCO1  Float,
  CAPRCO2  Float,
  UD01PR   Char(13),
  UD02PR   Char(13),
  PPPRNE  Float,
  PPPRNERE1  Float,
  PPPRNERE2  Float
)

IF EXISTS (SELECT * FROM sysobjects WHERE name='MAEDDO_PASO') BEGIN
DROP TABLE MAEDDO_PASO END


IF EXISTS (SELECT * FROM sysobjects WHERE name='@1Tbl') BEGIN
DROP TABLE @1Tbl END

If @ConsideraFechas = 'S' BEGIN
SELECT DISTINCT KOPRCT, MAX(FEEMLI) AS FECHA, TIDO,MAX(NUDO) AS NUDO
into MAEDDO_PASO
FROM         dbo.MAEDDO
WHERE MAEDDO.FEEMLI BETWEEN @FechaInicio AND @FechaTermino AND TIDO IN ('GRC')
GROUP BY KOPRCT, TIDO
ORDER BY KOPRCT
END

/*
If @ConsideraFechas = 'N' BEGIN
SELECT DISTINCT KOPRCT, MAX(FEEMLI) AS FECHA, TIDO,MAX(NUDO) AS NUDO
into MAEDDO_PASO
FROM         dbo.MAEDDO
WHERE TIDO = 'GRC' AND KOPRCT IN (SELECT Codigo FROM @2Tbl)
GROUP BY KOPRCT, TIDO
ORDER BY KOPRCT
END
*/

INSERT INTO @Tbl_Paso2 (TIDO,NUDO,SULIDO,BOSULIDO,FEEMLI,ENDO,SUENDO,NOKOEN,KOPRCT,UDTRPR,RLUDPR,
                        CAPRCO1,CAPRCO2,UD01PR,UD02PR,NOKOPR,PPPRNE,PPPRNERE1,PPPRNERE2)
SELECT DISTINCT 
                   dbo.MAEDDO.TIDO, 
                   dbo.MAEDDO.NUDO, 
				   dbo.MAEDDO.SULIDO,
				   dbo.MAEDDO.BOSULIDO,
                   dbo.MAEDDO_PASO.FECHA, 
                   dbo.MAEDDO.ENDO, 
                   dbo.MAEDDO.SUENDO, 
                   dbo.MAEEN.NOKOEN, 
                   dbo.MAEDDO.KOPRCT, 
                   dbo.MAEDDO.UDTRPR, 
                   dbo.MAEDDO.RLUDPR, 
                   dbo.MAEDDO.CAPRCO1, 
                   dbo.MAEDDO.CAPRCO2, 
                   dbo.MAEDDO.UD01PR, 
                   dbo.MAEDDO.UD02PR, 
                   dbo.MAEDDO.NOKOPR,
                   dbo.MAEDDO.PPPRNE,
                   dbo.MAEDDO.PPPRNERE1,
                   dbo.MAEDDO.PPPRNERE2
FROM         dbo.MAEDDO RIGHT OUTER JOIN
                      dbo.MAEDDO_PASO ON dbo.MAEDDO.KOPRCT = dbo.MAEDDO_PASO.KOPRCT AND dbo.MAEDDO.TIDO = dbo.MAEDDO_PASO.TIDO AND 
                      dbo.MAEDDO.NUDO = dbo.MAEDDO_PASO.NUDO LEFT OUTER JOIN
                      dbo.MAEEN ON dbo.MAEDDO.ENDO = dbo.MAEEN.KOEN AND dbo.MAEDDO.SUENDO = dbo.MAEEN.SUEN
GROUP BY dbo.MAEDDO.NUDO, dbo.MAEDDO.ENDO, dbo.MAEDDO.SUENDO, dbo.MAEEN.NOKOEN, dbo.MAEDDO.KOPRCT, dbo.MAEDDO.UDTRPR, dbo.MAEDDO.RLUDPR, 
                      dbo.MAEDDO.CAPRCO1, dbo.MAEDDO.CAPRCO2, dbo.MAEDDO.UD01PR, dbo.MAEDDO.UD02PR, dbo.MAEDDO.PPPRNE, dbo.MAEDDO.NOKOPR, 
                      dbo.MAEDDO_PASO.FECHA, dbo.MAEDDO.TIDO,dbo.MAEDDO.SULIDO,dbo.MAEDDO.BOSULIDO,dbo.MAEDDO.PPPRNERE1,dbo.MAEDDO.PPPRNERE2
ORDER BY dbo.MAEDDO.KOPRCT
DROP TABLE MAEDDO_PASO

SELECT * into @1Tbl from @Tbl_Paso2