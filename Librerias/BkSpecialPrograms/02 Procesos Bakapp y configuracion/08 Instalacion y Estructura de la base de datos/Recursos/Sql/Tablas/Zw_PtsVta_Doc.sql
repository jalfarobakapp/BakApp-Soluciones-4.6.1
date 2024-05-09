USE [#Base#]

CREATE TABLE [dbo].[Zw_PtsVta_Doc](
	[Id]				[int]			IDENTITY(1,1) NOT NULL,
	[Idmaeedo]			[int]			NOT NULL DEFAULT (0),
	[CodEntidad]		[varchar](13)	NOT NULL DEFAULT (''),
	[CodSucEntidad]		[varchar](20)	NOT NULL DEFAULT (''),
	[Tido]				[varchar](3)	NOT NULL DEFAULT (''),
	[Nudo]				[varchar](10)	NOT NULL DEFAULT (''),
	[Nudonodefi]		[bit]			NOT NULL DEFAULT (0),
	[Feemdo]			[datetime]		NULL,
	[Vabrdo]			[float]			NOT NULL DEFAULT (0),
	[FechaVenPtos]		[datetime]		NULL,
	[PtsGanados]		[float]			NOT NULL DEFAULT (0),
	[PtsUsados]			[float]			NOT NULL DEFAULT (0),
 CONSTRAINT [PK_Zw_PtsVta_Doc] PRIMARY KEY CLUSTERED 
(
	[CodEntidad] ASC,
	[CodSucEntidad] ASC,
	[Tido] ASC,
	[Nudo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

