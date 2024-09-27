USE [#Base#]

CREATE TABLE [dbo].[Zw_Inv_Contador](
	[Id]		[int] IDENTITY(1,1) NOT NULL,
	[Rut]		[varchar](10)	NOT NULL DEFAULT (''),
	[Nombre]	[varchar](50)	NOT NULL DEFAULT (''),
	[Telefono]	[varchar](20)	NOT NULL DEFAULT (''),
	[Email]		[varchar](80)	NOT NULL DEFAULT (''),
	[Activo]	[bit]			NOT NULL DEFAULT (0)
) ON [PRIMARY]



