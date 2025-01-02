USE [#Base#]

CREATE TABLE [dbo].[Zw_Contenedor_DocTom](
	[Id]				[int] IDENTITY(1,1) NOT NULL,
	[IdCont]			[int]			NOT NULL DEFAULT (0),
	[Contenedor]		[varchar](20)	NOT NULL DEFAULT (''),
	[CodFuncionario]	[char](3)		NOT NULL DEFAULT (''),
	[Fecha_Hora]		[datetime]		NULL,
	[NombreEquipo]		[varchar](50)	NOT NULL DEFAULT (''),
) ON [PRIMARY]



