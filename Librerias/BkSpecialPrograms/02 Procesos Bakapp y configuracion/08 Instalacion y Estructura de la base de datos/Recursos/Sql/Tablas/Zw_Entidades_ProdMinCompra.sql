USE [#Base#]

CREATE TABLE [dbo].[Zw_Entidades_ProdMinCompra](
	[Id]				[int] IDENTITY(1,1) NOT NULL,
	[CodEntidad]		[varchar](13)	NOT NULL DEFAULT (''),
	[CodSucEntidad]		[varchar](10)	NOT NULL DEFAULT (''),
	[Codigo]			[varchar](13)	NOT NULL DEFAULT (''),
	[UdCompra]			[int]			NOT NULL DEFAULT (0),
	[MultiploCompra]	[float]			NOT NULL DEFAULT (0),
 CONSTRAINT [PK_Zw_Entidades_ProdMinCompra] PRIMARY KEY CLUSTERED 
(
	[CodEntidad] ASC,
	[CodSucEntidad] ASC,
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]



