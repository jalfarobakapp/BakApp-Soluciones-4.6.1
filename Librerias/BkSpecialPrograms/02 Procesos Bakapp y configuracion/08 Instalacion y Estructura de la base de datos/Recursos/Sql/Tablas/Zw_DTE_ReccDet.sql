USE [#Base#]

CREATE TABLE [dbo].[Zw_DTE_ReccDet](
	[Id]			[int]			IDENTITY(1,1) NOT NULL,
	[Id_Enc]		[int]			NOT NULL DEFAULT (0),
	[Aceptado]		[bit]			NOT NULL DEFAULT (0),
	[Glosa]			[varchar](100)	NOT NULL DEFAULT (''),
	[RutEmisor]		[varchar](20)	NOT NULL DEFAULT (''),
	[TipoDTE]		[int]			NOT NULL DEFAULT (0),
	[Folio]			[varchar](10)	NOT NULL DEFAULT (0),
	[FchEmis]		[datetime]		NULL,
	[Revisado]		[bit]			NOT NULL DEFAULT (0),
	[Xml]			[varchar](max)	NOT NULL DEFAULT (''),
 CONSTRAINT [PK_Zw_DTE_ReccDet] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]


