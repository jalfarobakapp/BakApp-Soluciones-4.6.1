USE [#Base#]


CREATE TABLE [dbo].[Zw_UnificadosHitory](
	[Id]				[int] IDENTITY(1,1) NOT NULL,
	[CodNew]			[varchar](13)	NOT NULL DEFAULT (''),
	[CodOld]			[varchar](13)	NOT NULL DEFAULT (''),
	[DescripcionOld]	[varchar](50)	NOT NULL DEFAULT (''),
	[Ud1Old]			[char](2)		NOT NULL DEFAULT (''),
	[Ud2Old]			[char](2)		NOT NULL DEFAULT (''),
	[RtuOld]			[float]			NOT NULL DEFAULT (0),
	[Responzable]		[char](3)		NOT NULL DEFAULT (''),
	[Fecha]				[datetime]		NOT NULL DEFAULT Getdate(),
	[Accion]			[varchar](200)	NOT NULL DEFAULT ('')
) ON [PRIMARY]



