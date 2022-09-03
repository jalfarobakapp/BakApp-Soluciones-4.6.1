USE [#Base#]

CREATE TABLE [dbo].[Zw_Prod_PrestaShop](
	[Sitio]				[varchar](100)	NOT NULL DEFAULT (''),
	[Id_product]		[int]			NOT NULL DEFAULT (0),
	[Codigo]			[varchar](13)	NOT NULL DEFAULT (''),
	[Descripcion]		[varchar](128)	NOT NULL DEFAULT (''),
	[Stock]				[float]			NOT NULL DEFAULT (0),
	[Precio]			[float]			NOT NULL DEFAULT (0),
	[Active]			[bit]			NOT NULL DEFAULT (0),
	[Usar_Padre]		[bit]			NOT NULL DEFAULT (0),
	[Stock_Rd]			[float]			NOT NULL DEFAULT (0),
	[Precio_Rd]			[float]			NOT NULL DEFAULT (0),
	[Primario]			[bit]			NOT NULL DEFAULT (0),
	[FH_Actualizacion]	[datetime]		NOT NULL DEFAULT (Getdate()),
	[FH_Revision]		[datetime]		NOT NULL DEFAULT (Getdate()),
 CONSTRAINT [PK_Zw_Prod_PrestaShop] PRIMARY KEY CLUSTERED 
(
	[Sitio] ASC,
	[Id_product] ASC,
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


