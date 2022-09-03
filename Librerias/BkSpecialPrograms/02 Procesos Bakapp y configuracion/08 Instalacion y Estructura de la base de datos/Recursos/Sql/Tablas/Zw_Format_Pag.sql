USE [#Base#]


CREATE TABLE [dbo].[Zw_Format_Pag](
	[Id]			[int]			NOT NULL DEFAULT (0),
	[Cod_Pagina]	[varchar](10)	NOT NULL DEFAULT (''),
	[Nombre_pagina] [varchar](30)	NOT NULL DEFAULT (''),
	[Alto]			[float]			NOT NULL DEFAULT (0),
	[Ancho]			[float]			NOT NULL DEFAULT (0),
	[Largo_fijo]	[bit]			NOT NULL DEFAULT (0)
) ON [PRIMARY]


