USE [#Base#]

CREATE TABLE [dbo].[Zw_Ferias](
	[Id]			[int] IDENTITY(1,1) NOT NULL,
	[NombreFeria]	[varchar](50)       NOT NULL DEFAULT (''),
	[FechaCreacion] [datetime]          NULL,
	[FechaFeria]	[datetime]          NULL,
	[FechaInicio]	[datetime]          NULL,
	[FechaTermino]	[datetime]          NULL,
	[Activa]		[bit]               NOT NULL DEFAULT (0)
) ON [PRIMARY]




