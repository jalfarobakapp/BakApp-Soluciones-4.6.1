USE [#Base#]

CREATE TABLE [dbo].[Zw_Contenedor_StockProd](
	[Empresa]		[char](2)		NOT NULL DEFAULT (''),
	[IdCont]		[int]			NOT NULL DEFAULT (0),
	[Contenedor]	[varchar](20)	NOT NULL DEFAULT (''),
	[Idmaeedo_Rela] [int]			NOT NULL DEFAULT (0),
	[Idmaeddo_Rela] [int]			NOT NULL DEFAULT (0),
	[Tido_Rela]		[char](3)		NOT NULL DEFAULT (''),
	[Nudo_Rela]		[varchar](10)	NOT NULL DEFAULT (''),
	[Codigo]		[varchar](13)	NOT NULL DEFAULT (''),
	[StcfiUd1]		[float]			NOT NULL DEFAULT (0),
	[StcfiUd2]		[float]			NOT NULL DEFAULT (0),
	[StcCompUd1]	[float]			NOT NULL DEFAULT (0),
	[StcCompUd2]	[float]			NOT NULL DEFAULT (0)
) ON [PRIMARY]
