USE [#Base#]

CREATE TABLE [dbo].[Zw_Linea_Oferta](
	[Idmaeedo]			[int]			NOT NULL,
	[Tido]				[varchar](3)	NOT NULL DEFAULT (''),
	[Nudo]				[varchar](10)	NOT NULL DEFAULT (''),
	[Idmaeddo]			[int]			NOT NULL DEFAULT (0),
	[Nulido]			[varchar](5)	NOT NULL DEFAULT (''),
	[Id_Oferta]			[int]			NOT NULL DEFAULT (0),
	[Es_Padre_Oferta]	[int]			NOT NULL DEFAULT (0),
	[Oferta]			[varchar](13)	NOT NULL DEFAULT (''),
	[Padre_Oferta]		[int]			NOT NULL DEFAULT (0),
	[Hijo_Oferta]		[int]			NOT NULL DEFAULT (0),
	[Cantidad_Oferta]	[float]			NOT NULL DEFAULT (0),
	[Porcdesc_Oferta]	[float]			NOT NULL DEFAULT (0),
 CONSTRAINT [PK_Zw_Linea_Oferta] PRIMARY KEY CLUSTERED 
(
	[Idmaeddo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
