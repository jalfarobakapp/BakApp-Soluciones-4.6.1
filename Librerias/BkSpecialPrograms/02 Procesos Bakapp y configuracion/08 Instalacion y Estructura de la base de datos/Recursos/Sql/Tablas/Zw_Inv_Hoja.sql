USE [#Base#]

CREATE TABLE [dbo].[Zw_Inv_Hoja](
	[Id]					[int] IDENTITY(1,1) NOT NULL,
	[IdInventario]			[int]			NOT NULL DEFAULT (0),
	[Nro_Hoja]				[varchar](5)	NOT NULL DEFAULT (''),
	[NombreEquipo]			[varchar](20)	NOT NULL DEFAULT (''),
	[FechaCreacion]			[datetime]		NULL,
	[CodResponsable]		[char](3)		NOT NULL DEFAULT (''),
	[IdContador1]			[int]			NOT NULL DEFAULT (0),
	[IdContador2]			[int]			NOT NULL DEFAULT (0),
	[FechaLevantamiento]	[datetime]		NULL,
	[Reconteo]				[bit]			NOT NULL DEFAULT (0)
) ON [PRIMARY]



